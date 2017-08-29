'AutoBright (C) James Tattersall 2017
'Utility to automatically change screen brightness using DDC commands according to sunset/sunrise times
Imports System.Net
Imports System.IO
Imports Microsoft.Win32

Public Class frmSettings
    Private PhysicalMonitors() As MonitorHelper.PHYSICAL_MONITOR 'Create a class scoped array to hold the PHYSICAL_MONITOR structures for each Physical Monitor
    Dim dimmingDownStart, dimmingDownEnd, dimmingUpStart, dimmingUpEnd As DateTime 'Variables to hold transition start and end times
    Dim transitioning As Boolean = False 'Flag for if transition has started
    Dim externalProgramRunning As Boolean = isRunning() 'Flag for if background app has been started - saves checking for process every time

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Visible = False
        If Debugger.IsAttached Then
            Visible = True
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True 'Show window automatically if debugger attached
        End If

        If My.Settings.FirstRun = True Then
            frmFirstRun.ShowDialog() 'Show first run dialog
        Else
            ScheduleTimer.Enabled = True 'Start scheduling timer
        End If

        AddHandler SystemEvents.DisplaySettingsChanged, AddressOf MonitorConfigChanged 'Add handler to handle the monitor configuration change event
        PhysicalMonitors = MonitorHelper.GetPhysicalMonitors 'Get all monitors and put into array

        AddHandler tBoxTransitionTime.KeyPress, AddressOf IntegerTBoxHandler
        AddHandler tBoxScreen1Normal.KeyPress, AddressOf IntegerTBoxHandler
        AddHandler tBoxScreen1Dimmed.KeyPress, AddressOf IntegerTBoxHandler
        AddHandler tBoxScreen2Normal.KeyPress, AddressOf IntegerTBoxHandler
        AddHandler tBoxScreen2Dimmed.KeyPress, AddressOf IntegerTBoxHandler
        AddHandler tBoxScreen3Normal.KeyPress, AddressOf IntegerTBoxHandler
        AddHandler tBoxScreen3Dimmed.KeyPress, AddressOf IntegerTBoxHandler 'Add handlers for integer only textboxes

        AddHandler tBoxOffset.KeyPress, AddressOf NegIntegerTBoxHandler 'Add handler for negative integer text box

        AddHandler tBoxLatitude.KeyPress, AddressOf DecimalTBoxHandler
        AddHandler tBoxLongitude.KeyPress, AddressOf DecimalTBoxHandler 'Add handlers for decimal only textboxes

        GetTimes() 'Fetch and process sunset/sunrise times
        UpdateSettings() 'Update all settings visible in window
        SetInitialMonitorLabelValue() 'Set values of labels to show current brightness

    End Sub

#Region "Time fetching"
    Private Sub GetTimes()
        Debug.WriteLine("INFO: Fetching times")
        Dim todayRequest As WebRequest = WebRequest.Create("http://api.sunrise-sunset.org/json?lat=" & My.Settings.LocationLatitude & "&lng=" & My.Settings.LocationLongitude & "&formatted=0")
        Dim tomorrowRequest As WebRequest = WebRequest.Create("http://api.sunrise-sunset.org/json?lat=" & My.Settings.LocationLatitude & "&lng=" & My.Settings.LocationLongitude & "&formatted=0&date=tomorrow")
        Try 'Try getting times
            Dim todayTimesJSON As String = New StreamReader(todayRequest.GetResponse.GetResponseStream()).ReadLine
            Dim tomorrowTimesJSON As String = New StreamReader(tomorrowRequest.GetResponse.GetResponseStream()).ReadLine
            My.Settings.CivilTwilightEndToday = DateTime.Parse(Mid(todayTimesJSON, 172, 25)) 'Extract civil twilight end time for today and convert to DateTime
            My.Settings.CivilTwilightEndTomorrow = DateTime.Parse(Mid(tomorrowTimesJSON, 172, 25)) 'Extract civil twilight start time for tomorrow and convert to DateTime
            My.Settings.CivilTwilightStartToday = DateTime.Parse(Mid(todayTimesJSON, 221, 25)) 'Extract civil twilight end time and convert to DateTime
            My.Settings.Save()

            lblEndTime.ForeColor = Color.Black
            lblStartTime.ForeColor = Color.Black
            'Reset colours
        Catch ex As Exception 'If fails, use last saved times
            Debug.WriteLine("ERROR: Time fetching failed, using stored times instead")
            Dim difference As Integer = DateDiff(DateInterval.Day, My.Settings.CivilTwilightEndToday, Date.Now) 'Get difference in days between last saved and present

            NotificationTrayIcon.BalloonTipIcon = ToolTipIcon.Error
            NotificationTrayIcon.BalloonTipTitle = "AutoBright - Time Fetch Failed"
            NotificationTrayIcon.BalloonTipText = "Fetching of sunrise/sunset times failed. Using times from " & difference & " day(s) ago (" & My.Settings.CivilTwilightStartToday.Date & ") instead."
            NotificationTrayIcon.ShowBalloonTip(7000)
            'Display balloon notification alert

            My.Settings.CivilTwilightEndToday = My.Settings.CivilTwilightEndToday.AddDays(difference)
            My.Settings.CivilTwilightStartToday = My.Settings.CivilTwilightStartToday.AddDays(difference)
            My.Settings.CivilTwilightEndTomorrow = My.Settings.CivilTwilightEndTomorrow.AddDays(difference)
            'Add difference in days to bring date to present

            NotificationTrayIcon.BalloonTipIcon = ToolTipIcon.None
            NotificationTrayIcon.BalloonTipTitle = ""
            NotificationTrayIcon.BalloonTipText = ""
            'Reset balloon notification settings

            lblEndTime.ForeColor = Color.Red
            lblStartTime.ForeColor = Color.Red
            'Change font colour in settings window
        Finally
            dimmingDownStart = My.Settings.CivilTwilightStartToday.AddMinutes(-1 * My.Settings.TransitionTime + My.Settings.Offset)
            dimmingDownEnd = dimmingDownStart.AddMinutes(My.Settings.TransitionTime) 'Calculate times for start and end of day->night transition

            dimmingUpStart = My.Settings.CivilTwilightEndTomorrow.AddMinutes(-1 * My.Settings.TransitionTime + -1 * My.Settings.Offset)
            dimmingUpEnd = dimmingUpStart.AddMinutes(My.Settings.TransitionTime) 'Calculate times for start and end of night->day transition

            Debug.WriteLine("INFO: dimmingDownStart = " & dimmingDownStart.ToString)
            Debug.WriteLine("INFO: dimmingDownEnd = " & dimmingDownEnd.ToString)
            Debug.WriteLine("INFO: dimmingUpStart = " & dimmingUpStart.ToString)
            Debug.WriteLine("INFO: dimmingUpEnd = " & dimmingUpEnd.ToString)

            lblStartTime.Text = "Dimming Start: " & dimmingDownStart.ToString
            lblEndTime.Text = "Dimming End: " & dimmingUpEnd.ToString
            'Set start and end times in settings window
        End Try
    End Sub
#End Region

#Region "Brightness set/get"
    Private Sub SetBrightness(ByVal brightness As Integer, ByVal screen As Integer)
        Debug.WriteLine("INFO: Brightness set: " & screen & "," & brightness)
        If brightness >= 0 And brightness <= 100 And PhysicalMonitors.Length > 0 Then
            Try
                MonitorHelper.SetPhysicalMonitorBrightness(PhysicalMonitors(screen - 1), brightness / 100) 'Set the monitor brightness, using the array of physical monitors to refer to each monitor
            Catch e As Exception
                Debug.WriteLine("BRIGHTNESS SET ERROR: " & e.Message)
                DisableTimers() 'Disable all timers
                MonitorHelper.DestroyAllPhysicalMonitors(PhysicalMonitors)
                PhysicalMonitors = MonitorHelper.GetPhysicalMonitors 'Refetch all monitors
                ScheduleTimer.Enabled = True 'Re-enable scheduler
            Finally
                If InvokeRequired Then
                    Invoke(New MethodInvoker(Sub() SetMonitorLabelValue(screen))) 'Invoke brightness labal update to run on main thread
                Else
                    SetMonitorLabelValue(screen) 'Set brightness label
                End If
            End Try
        End If
    End Sub

    Private Function GetBrightness(ByVal screen As Integer)
        Try
            Return MonitorHelper.GetPhysicalMonitorBrightness(PhysicalMonitors(screen - 1)) * 100 'Return brightness of specified monitor
        Catch e As Exception
            Debug.WriteLine("BRIGHTNESS GET ERROR: " & e.Message)
            DisableTimers() 'Disable all timers
            MonitorHelper.DestroyAllPhysicalMonitors(PhysicalMonitors)
            PhysicalMonitors = MonitorHelper.GetPhysicalMonitors 'Refetch all monitors
            ScheduleTimer.Enabled = True 'Re-enable scheduler
        End Try
    End Function

    Private Sub PreviewBrightness_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles PreviewBrightness.DoWork
        Dim args() As Integer = DirectCast(e.Argument, Array) 'Fetch array of arguments - only one object can be passed as a parameter
        DisablePreview() 'Disable preview buttons to prevent exception from BackgroundWorker trying to run more than once at a time
        SetBrightness(args(0), args(2)) 'Set dimmed brightness
        Threading.Thread.Sleep(5000) 'Wait
        SetBrightness(args(1), args(2)) 'Go back to normal brightness
        EnablePreview() 'Re-enable preview buttons
    End Sub
#End Region

#Region "Monitor Config Changing"
    Private Sub MonitorConfigChanged()
        Debug.WriteLine("INFO: Monitor config change detected")
        DisableTimers()
        MonitorHelper.DestroyAllPhysicalMonitors(PhysicalMonitors)
        PhysicalMonitors = MonitorHelper.GetPhysicalMonitors 'Re-fetch monitors
        If PhysicalMonitors.Length > 0 Then 'If at least one monitor is found
            ScheduleTimer.Enabled = True 'Re-enable scheduler
            UpdateSettings() 'Update displayed settings accordingly
            SetInitialMonitorLabelValue() 'Re-set values shown in interface
        Else
            MsgBox("Error: No monitors detected. Click 'OK' to re-detect monitors. If this error persists, your monitor(s) may not be supported.", MsgBoxStyle.Critical, "AutoBright Error")
            MonitorConfigChanged()
        End If
    End Sub
#End Region

#Region "Transitions and scheduling"
    Private Sub ScheduleTimer_Tick(sender As Object, e As EventArgs) Handles ScheduleTimer.Tick
        'Debug.WriteLine("INFO: Scheduler tick")
        If Date.Now >= My.Settings.CivilTwilightEndToday And Date.Now < dimmingDownStart Then 'Daytime
            'Debug.WriteLine("STATE: Daytime")
            If My.Settings.EnableExternalProgram = True Then 'Kill background app if option enabled and if it is running
                If externalProgramRunning = True Then
                    If isRunning() = True Then
                        EndExternalProgram()
                        externalProgramRunning = False
                    End If
                End If
            End If

            Select Case PhysicalMonitors.Length
                Case 1
                    If GetBrightness(1) <> My.Settings.Screen1Normal Then
                        SetBrightness(My.Settings.Screen1Normal, 1)
                    End If
                Case 2
                    If GetBrightness(1) <> My.Settings.Screen1Normal Or GetBrightness(2) <> My.Settings.Screen2Normal Then
                        SetBrightness(My.Settings.Screen1Normal, 1)
                        SetBrightness(My.Settings.Screen2Normal, 2)
                    End If
                Case 3
                    If GetBrightness(1) <> My.Settings.Screen1Normal Or GetBrightness(2) <> My.Settings.Screen2Normal Or GetBrightness(3) <> My.Settings.Screen3Normal Then
                        SetBrightness(My.Settings.Screen1Normal, 1)
                        SetBrightness(My.Settings.Screen2Normal, 2)
                        SetBrightness(My.Settings.Screen3Normal, 3)
                    End If
            End Select
            NotificationTrayIcon.Icon = My.Resources.AutoBrightIdle
            NotificationTrayIcon.Text = "AutoBright - Idle"
        ElseIf Date.Now >= dimmingDownEnd And Date.Now < dimmingUpStart Then 'Nightime
            'Debug.WriteLine("STATE: Nightime")
            If My.Settings.EnableExternalProgram = True Then 'Start background app if option enabled
                If externalProgramRunning = False Then
                    If Not isRunning() = True Then
                        StartExternalProgram()
                        externalProgramRunning = True
                    End If
                End If
            End If

            Select Case PhysicalMonitors.Length
                Case 1
                    If GetBrightness(1) <> My.Settings.Screen1Dimmed Then
                        SetBrightness(My.Settings.Screen1Dimmed, 1)
                    End If
                Case 2
                    If GetBrightness(1) <> My.Settings.Screen1Dimmed Or GetBrightness(2) <> My.Settings.Screen2Dimmed Then
                        SetBrightness(My.Settings.Screen1Dimmed, 1)
                        SetBrightness(My.Settings.Screen2Dimmed, 2)
                    End If
                Case 3
                    If GetBrightness(1) <> My.Settings.Screen1Dimmed Or GetBrightness(2) <> My.Settings.Screen2Dimmed Or GetBrightness(3) <> My.Settings.Screen3Dimmed Then
                        SetBrightness(My.Settings.Screen1Dimmed, 1)
                        SetBrightness(My.Settings.Screen2Dimmed, 2)
                        SetBrightness(My.Settings.Screen3Dimmed, 3)
                    End If
            End Select
            NotificationTrayIcon.Icon = My.Resources.AutoBrightDimming
            NotificationTrayIcon.Text = "AutoBright - Dimming"
        ElseIf Date.Now >= dimmingUpStart And Date.Now < dimmingUpEnd And transitioning = False Then 'Transition from night to day
            'Debug.WriteLine("STATE: Night->Day")
            Select Case PhysicalMonitors.Length
                Case 1
                    If DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) > 0 Then 'No idea why I put these conditions in, but I presume it was to fix a bug, so I'll leave them alone - to prevent timer rate being 0?
                        TransitionUpTimer1.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) * 1000) / (My.Settings.Screen1Normal - My.Settings.Screen1Dimmed)) 'Set rate of timers so that every time they tick, they decrement the brightness by 1
                    End If

                    TransitionUpTimer1.Enabled = True
                Case 2
                    If DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) > 0 Then
                        TransitionUpTimer1.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) * 1000) / (My.Settings.Screen1Normal - My.Settings.Screen1Dimmed))
                        TransitionUpTimer2.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) * 1000) / (My.Settings.Screen2Normal - My.Settings.Screen2Dimmed))
                    End If

                    TransitionUpTimer1.Enabled = True
                    TransitionUpTimer2.Enabled = True
                Case 3
                    If DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) > 0 Then
                        TransitionUpTimer1.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) * 1000) / (My.Settings.Screen1Normal - My.Settings.Screen1Dimmed))
                        TransitionUpTimer2.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) * 1000) / (My.Settings.Screen2Normal - My.Settings.Screen2Dimmed))
                        TransitionUpTimer3.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingUpEnd) * 1000) / (My.Settings.Screen3Normal - My.Settings.Screen3Dimmed))
                    End If

                    TransitionUpTimer1.Enabled = True
                    TransitionUpTimer2.Enabled = True
                    TransitionUpTimer3.Enabled = True
            End Select
            transitioning = True
            NotificationTrayIcon.Icon = My.Resources.AutoBrightDimming
            NotificationTrayIcon.Text = "AutoBright - Dimming"
        ElseIf Date.Now >= dimmingDownStart And Date.Now < dimmingDownEnd And transitioning = False Then 'Transition from day to night
            'Debug.WriteLine("STATE: Day->Night")
            Select Case PhysicalMonitors.Length
                Case 1
                    If DateDiff(DateInterval.Second, Date.Now, dimmingDownEnd) > 0 Then
                        TransitionDownTimer1.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingDownEnd) * 1000) / (My.Settings.Screen1Normal - My.Settings.Screen1Dimmed))
                    End If

                    TransitionDownTimer1.Enabled = True
                Case 2
                    If DateDiff(DateInterval.Second, Date.Now, My.Settings.CivilTwilightStartToday) > 0 Then
                        TransitionDownTimer1.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingDownEnd) * 1000) / (My.Settings.Screen1Normal - My.Settings.Screen1Dimmed))
                        TransitionDownTimer2.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingDownEnd) * 1000) / (My.Settings.Screen2Normal - My.Settings.Screen2Dimmed))
                    End If

                    TransitionDownTimer1.Enabled = True
                    TransitionDownTimer2.Enabled = True
                Case 3
                    If DateDiff(DateInterval.Second, Date.Now, My.Settings.CivilTwilightStartToday) > 0 Then
                        TransitionDownTimer1.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingDownEnd) * 1000) / (My.Settings.Screen1Normal - My.Settings.Screen1Dimmed))
                        TransitionDownTimer2.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingDownEnd) * 1000) / (My.Settings.Screen2Normal - My.Settings.Screen2Dimmed))
                        TransitionDownTimer3.Interval = Math.Floor((DateDiff(DateInterval.Second, Date.Now, dimmingDownEnd) * 1000) / (My.Settings.Screen3Normal - My.Settings.Screen3Dimmed))
                    End If

                    TransitionDownTimer1.Enabled = True
                    TransitionDownTimer2.Enabled = True
                    TransitionDownTimer3.Enabled = True
            End Select
            transitioning = True
            NotificationTrayIcon.Icon = My.Resources.AutoBrightDimming
            NotificationTrayIcon.Text = "AutoBright - Dimming"
        End If
    End Sub

    Private Sub TransitionUpTimer1_Tick(sender As Object, e As EventArgs) Handles TransitionUpTimer1.Tick 'Monitor 1 night to day
        If GetBrightness(1) < My.Settings.Screen1Normal Then
            SetBrightness(GetBrightness(1) + 1, 1) 'Increase brightness by 1

        ElseIf GetBrightness(1) = My.Settings.Screen1Normal Then 'When finished
            GetTimes()
            UpdateSettings()
            'Refresh times and update settings
            transitioning = False 'Flag as no longer transitioning
            TransitionUpTimer1.Enabled = False 'Disable this timer
        End If
    End Sub

    Private Sub TransitionUpTimer2_Tick(sender As Object, e As EventArgs) Handles TransitionUpTimer2.Tick 'Monitor 2 night to day
        If GetBrightness(2) < My.Settings.Screen2Normal Then
            SetBrightness(GetBrightness(2) + 1, 2)

        ElseIf GetBrightness(2) = My.Settings.Screen2Normal Then
            GetTimes()
            UpdateSettings()
            transitioning = False
            TransitionUpTimer2.Enabled = False
        End If
    End Sub

    Private Sub TransitionUpTimer3_Tick(sender As Object, e As EventArgs) Handles TransitionUpTimer3.Tick 'Monitor 3 night to day
        If GetBrightness(3) < My.Settings.Screen3Normal Then
            SetBrightness(GetBrightness(3) + 1, 3)

        ElseIf GetBrightness(3) = My.Settings.Screen3Normal Then
            GetTimes()
            UpdateSettings()
            transitioning = False
            TransitionUpTimer3.Enabled = False
        End If
    End Sub

    Private Sub TransitionDownTimer1_Tick(sender As Object, e As EventArgs) Handles TransitionDownTimer1.Tick 'Monitor 1 day to night
        If GetBrightness(1) > My.Settings.Screen1Dimmed Then
            SetBrightness(GetBrightness(1) - 1, 1) 'Decrease brightness by 1

        ElseIf GetBrightness(1) = My.Settings.Screen1Dimmed Then
            transitioning = False
            TransitionDownTimer1.Enabled = False
        End If
    End Sub

    Private Sub TransitionDownTimer2_Tick(sender As Object, e As EventArgs) Handles TransitionDownTimer2.Tick 'Monitor 2 day to night
        If GetBrightness(2) > My.Settings.Screen2Dimmed Then
            SetBrightness(GetBrightness(2) - 1, 2)

        ElseIf GetBrightness(2) = My.Settings.Screen2Dimmed Then
            transitioning = False
            TransitionDownTimer2.Enabled = False
        End If
    End Sub

    Private Sub TransitionDownTimer3_Tick(sender As Object, e As EventArgs) Handles TransitionDownTimer3.Tick 'Monitor 3 day to night
        If GetBrightness(3) > My.Settings.Screen3Dimmed Then
            SetBrightness(GetBrightness(3) - 1, 3)

        ElseIf GetBrightness(3) = My.Settings.Screen3Dimmed Then
            transitioning = False
            TransitionDownTimer3.Enabled = False
        End If
    End Sub

    Private Sub DisableTimers()
        Debug.WriteLine("INFO: All timers disabled")
        ScheduleTimer.Enabled = False
        TransitionDownTimer1.Enabled = False
        TransitionDownTimer2.Enabled = False
        TransitionDownTimer3.Enabled = False
        TransitionUpTimer1.Enabled = False
        TransitionUpTimer2.Enabled = False
        TransitionUpTimer3.Enabled = False
    End Sub

#End Region

#Region "Screen 1 Controls"
    Private Sub tBarScreen1Normal_ValueChanged(sender As Object, e As EventArgs) Handles tBarScreen1Normal.ValueChanged
        If sender.Enabled = True Then
            tBoxScreen1Normal.Text = tBarScreen1Normal.Value
            'Update text box
        End If
    End Sub

    Private Sub tBoxScreen1Normal_TextChanged(sender As Object, e As EventArgs) Handles tBoxScreen1Normal.TextChanged
        If CheckValues(tBoxScreen1Normal) And CheckValues(tBoxScreen1Normal) Then
            tBarScreen1Normal.Value = tBoxScreen1Normal.Text
            'Update text box
        End If
    End Sub

    Private Sub tBarScreen1Dimmed_ValueChanged(sender As Object, e As EventArgs) Handles tBarScreen1Dimmed.ValueChanged
        If sender.Enabled = True Then
            tBoxScreen1Dimmed.Text = tBarScreen1Dimmed.Value
            'Update text box
        End If
    End Sub

    Private Sub tBoxScreen1Dimmed_TextChanged(sender As Object, e As EventArgs) Handles tBoxScreen1Dimmed.TextChanged
        If CheckValues(tBoxScreen1Dimmed) And CheckValues(tBoxScreen1Dimmed) Then
            tBarScreen1Dimmed.Value = tBoxScreen1Dimmed.Text
            'Update text box
        End If
    End Sub

    Private Sub btnScreen1Preview_Click(sender As Object, e As EventArgs) Handles btnScreen1Preview.Click
        Dim args As Integer() = {My.Settings.Screen1Dimmed, My.Settings.Screen1Normal, 1} 'Define array of arguments - BackgroundWorkers only accept one object as a parameter
        PreviewBrightness.RunWorkerAsync(args) 'Start background worker
    End Sub
#End Region

#Region "Screen 2 Controls"
    Private Sub tBarScreen2Normal_ValueChanged(sender As Object, e As EventArgs) Handles tBarScreen2Normal.ValueChanged
        If sender.Enabled = True Then
            tBoxScreen2Normal.Text = tBarScreen2Normal.Value
            'Update text box
        End If
    End Sub

    Private Sub tBoxScreen2Normal_TextChanged(sender As Object, e As EventArgs) Handles tBoxScreen2Normal.TextChanged
        If CheckValues(tBoxScreen2Normal) And CheckValues(tBoxScreen2Normal) Then
            tBarScreen2Normal.Value = tBoxScreen2Normal.Text
            'Update text box
        End If
    End Sub

    Private Sub tBarScreen2Dimmed_ValueChanged(sender As Object, e As EventArgs) Handles tBarScreen2Dimmed.ValueChanged
        If sender.Enabled = True Then
            tBoxScreen2Dimmed.Text = tBarScreen2Dimmed.Value
            'Update text box
        End If
    End Sub

    Private Sub tBoxScreen2Dimmed_TextChanged(sender As Object, e As EventArgs) Handles tBoxScreen2Dimmed.TextChanged
        If CheckValues(tBoxScreen2Dimmed) And CheckValues(tBoxScreen2Dimmed) Then
            tBarScreen2Dimmed.Value = tBoxScreen2Dimmed.Text
            'Update text box
        End If
    End Sub

    Private Sub btnScreen2Preview_Click(sender As Object, e As EventArgs) Handles btnScreen2Preview.Click
        Dim args As Integer() = {My.Settings.Screen2Dimmed, My.Settings.Screen2Normal, 2}  'Define array of arguments - BackgroundWorkers only accept one object as a parameter
        PreviewBrightness.RunWorkerAsync(args) 'Start background worker
    End Sub
#End Region

#Region "Screen 3 Controls"
    Private Sub tBarScreen3Normal_ValueChanged(sender As Object, e As EventArgs) Handles tBarScreen3Normal.ValueChanged
        If sender.Enabled = True Then
            tBoxScreen3Normal.Text = tBarScreen3Normal.Value
            My.Settings.Screen3Normal = tBarScreen3Normal.Value
            'Update text box and saved setting
        End If
    End Sub

    Private Sub tBoxScreen3Normal_TextChanged(sender As Object, e As EventArgs) Handles tBoxScreen3Normal.TextChanged
        If CheckValues(tBoxScreen3Normal) And CheckValues(tBoxScreen3Normal) Then
            tBarScreen3Normal.Value = tBoxScreen3Normal.Text
        End If
    End Sub

    Private Sub tBarScreen3Dimmed_ValueChanged(sender As Object, e As EventArgs) Handles tBarScreen3Dimmed.ValueChanged
        If sender.Enabled = True Then
            tBoxScreen3Dimmed.Text = tBarScreen3Dimmed.Value
            'Update text box
        End If
    End Sub

    Private Sub tBoxScreen3Dimmed_TextChanged(sender As Object, e As EventArgs) Handles tBoxScreen3Dimmed.TextChanged
        If CheckValues(tBoxScreen3Dimmed) And CheckValues(tBoxScreen3Dimmed) Then
            tBarScreen3Dimmed.Value = tBoxScreen3Dimmed.Text
        End If
    End Sub

    Private Sub btnScreen3Preview_Click(sender As Object, e As EventArgs) Handles btnScreen3Preview.Click
        Dim args As Integer() = {My.Settings.Screen3Dimmed, My.Settings.Screen3Normal, 3} 'Define array of arguments - BackgroundWorkers only accept one object as a parameter
        PreviewBrightness.RunWorkerAsync(args) 'Start background worker
    End Sub
#End Region

#Region "Preview enable/disable"
    Private Sub DisablePreview()
        gBoxScreen1.Invoke(New MethodInvoker(Sub() gBoxScreen1.Enabled = False))
        gBoxScreen2.Invoke(New MethodInvoker(Sub() gBoxScreen2.Enabled = False))
        gBoxScreen3.Invoke(New MethodInvoker(Sub() gBoxScreen3.Enabled = False))
        Invoke(New MethodInvoker(Sub() ScheduleTimer.Enabled = False))
        Debug.WriteLine("INFO: Controls and ScheduleTimer disabled")
    End Sub

    Private Sub EnablePreview()
        Select Case PhysicalMonitors.Length
            Case 1
                gBoxScreen1.Invoke(New MethodInvoker(Sub() gBoxScreen1.Enabled = True))
            Case 2
                gBoxScreen1.Invoke(New MethodInvoker(Sub() gBoxScreen1.Enabled = True))
                gBoxScreen2.Invoke(New MethodInvoker(Sub() gBoxScreen2.Enabled = True))
            Case 3
                gBoxScreen1.Invoke(New MethodInvoker(Sub() gBoxScreen1.Enabled = True))
                gBoxScreen2.Invoke(New MethodInvoker(Sub() gBoxScreen2.Enabled = True))
                gBoxScreen3.Invoke(New MethodInvoker(Sub() gBoxScreen3.Enabled = True))
        End Select
        Invoke(New MethodInvoker(Sub() ScheduleTimer.Enabled = True))
        Debug.WriteLine("INFO: Controls and ScheduleTimer enabled")
    End Sub
#End Region

#Region "Other UI"
    Private Sub UpdateSettings()
        Debug.WriteLine("INFO: Updating settings")
#Region "Update screen details"
        Select Case PhysicalMonitors.Length
            Case 0
                DisableTimers()
                MsgBox("Error: No supported monitors detected. Sorry, but your monitor(s) may not be supported. Try enabling DDC/CI in your monitor's settings, if there is an option.", 16)
                Application.Exit()
                'Disable all transitions, display error message, and exit if no monitors are found
            Case 1
                gBoxScreen1.Enabled = True
                gBoxScreen2.Enabled = False
                gBoxScreen3.Enabled = False

                tBoxScreen1Normal.Text = My.Settings.Screen1Normal
                tBoxScreen1Dimmed.Text = My.Settings.Screen1Dimmed

                tBoxScreen2Normal.Clear()
                tBarScreen2Normal.Value = 0
                tBoxScreen2Dimmed.Clear()
                tBarScreen2Dimmed.Value = 0

                tBoxScreen3Normal.Clear()
                tBarScreen3Normal.Value = 0
                tBoxScreen3Dimmed.Clear()
                tBarScreen3Dimmed.Value = 0
                'Only enable screen 1 group if 1 screen detected, disable and clear others

                gBoxScreen1.Text = "Screen 1 - " & PhysicalMonitors(0).szPhysicalMonitorDescription.ToString
                gBoxScreen2.Text = "Screen 2"
                gBoxScreen3.Text = "Screen 3"
                'Set names of monitor
            Case 2
                gBoxScreen1.Enabled = True
                gBoxScreen2.Enabled = True
                gBoxScreen3.Enabled = False

                tBoxScreen1Normal.Text = My.Settings.Screen1Normal
                tBoxScreen1Dimmed.Text = My.Settings.Screen1Dimmed

                tBoxScreen2Normal.Text = My.Settings.Screen2Normal
                tBoxScreen2Dimmed.Text = My.Settings.Screen2Dimmed

                tBoxScreen3Normal.Clear()
                tBarScreen3Normal.Value = 0
                tBoxScreen3Dimmed.Clear()
                tBarScreen3Dimmed.Value = 0
                'Enable screen 1 and 2 groups if 2 screens detected, disable and clear others

                gBoxScreen1.Text = "Screen 1 - " & PhysicalMonitors(0).szPhysicalMonitorDescription.ToString
                gBoxScreen2.Text = "Screen 2 - " & PhysicalMonitors(1).szPhysicalMonitorDescription.ToString
                gBoxScreen3.Text = "Screen 3"
                'Set names of monitors
            Case 3
                gBoxScreen1.Enabled = True
                gBoxScreen2.Enabled = True
                gBoxScreen3.Enabled = True

                tBoxScreen1Normal.Text = My.Settings.Screen1Normal
                tBoxScreen1Dimmed.Text = My.Settings.Screen1Dimmed

                tBoxScreen2Normal.Text = My.Settings.Screen2Normal
                tBoxScreen2Dimmed.Text = My.Settings.Screen2Dimmed

                tBoxScreen3Normal.Text = My.Settings.Screen3Normal
                tBoxScreen3Dimmed.Text = My.Settings.Screen3Dimmed
                'Enable screen 1, 2 and 3 groups if 3 screens detected

                gBoxScreen1.Text = "Screen 1 - " & PhysicalMonitors(0).szPhysicalMonitorDescription.ToString
                gBoxScreen2.Text = "Screen 2 - " & PhysicalMonitors(1).szPhysicalMonitorDescription.ToString
                gBoxScreen3.Text = "Screen 3 - " & PhysicalMonitors(2).szPhysicalMonitorDescription.ToString
                'Set names of monitors
        End Select
#End Region
        tBoxTransitionTime.Text = My.Settings.TransitionTime
        tBoxOffset.Text = My.Settings.Offset
        tBoxLatitude.Text = My.Settings.LocationLatitude
        tBoxLongitude.Text = My.Settings.LocationLongitude
        frmAdvanced.cBoxExternalProgram.Checked = My.Settings.EnableExternalProgram
        frmAdvanced.gBoxExternalProgram.Enabled = My.Settings.EnableExternalProgram
        frmAdvanced.tBoxPath.Text = My.Settings.ExternalProgramPath
        frmAdvanced.tBoxArg.Text = My.Settings.ExternalProgramArguments
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.TransitionTime = tBoxTransitionTime.Text
        My.Settings.Offset = tBoxOffset.Text
        My.Settings.EnableExternalProgram = frmAdvanced.cBoxExternalProgram.CheckState
        My.Settings.ExternalProgramPath = frmAdvanced.tBoxPath.Text
        My.Settings.ExternalProgramArguments = frmAdvanced.tBoxArg.Text
        My.Settings.LocationLatitude = Convert.ToDouble(tBoxLatitude.Text)
        My.Settings.LocationLongitude = Convert.ToDouble(tBoxLongitude.Text) 'Save transition time and location
        Select Case PhysicalMonitors.Length
            Case 1
                If Not CheckValues(tBoxScreen1Normal) Or Not CheckValues(tBoxScreen1Dimmed) Then
                    MsgBox("Error: Invalid brightness entered. Please enter an integer between 0 and 100.", MsgBoxStyle.Critical, "AutoBright Error")
                    Exit Sub
                End If
                If Int(tBoxScreen1Dimmed.Text) >= Int(tBoxScreen1Normal.Text) Then 'Prevent saving of invalid settings and display error message
                    MsgBox("Error: Dimmed brightness cannot be greater than or equal to normal brightness.", MsgBoxStyle.Critical, "AutoBright Error")
                Else
                    My.Settings.Screen1Normal = tBoxScreen1Normal.Text
                    My.Settings.Screen1Dimmed = tBoxScreen1Dimmed.Text
                    My.Settings.Save()
                    GetTimes()
                    UpdateSettings()
                End If
            Case 2
                If Not CheckValues(tBoxScreen1Normal) Or Not CheckValues(tBoxScreen1Dimmed) Or Not CheckValues(tBoxScreen2Normal) Or Not CheckValues(tBoxScreen2Dimmed) Then
                    MsgBox("Error: Invalid brightness entered. Please enter an integer between 0 and 100.", MsgBoxStyle.Critical, "AutoBright Error")
                    Exit Sub
                End If
                If Int(tBoxScreen1Dimmed.Text) >= Int(tBoxScreen1Normal.Text) Or Int(tBoxScreen2Dimmed.Text) >= Int(tBoxScreen2Normal.Text) Then 'Prevent saving of invalid settings and display error message
                    MsgBox("Error: Dimmed brightness cannot be greater than or equal to normal brightness.", MsgBoxStyle.Critical, "AutoBright Error")
                Else
                    My.Settings.Screen1Normal = tBoxScreen1Normal.Text
                    My.Settings.Screen1Dimmed = tBoxScreen1Dimmed.Text
                    My.Settings.Screen2Normal = tBoxScreen2Normal.Text
                    My.Settings.Screen2Dimmed = tBoxScreen2Dimmed.Text
                    My.Settings.Save()
                    GetTimes()
                    UpdateSettings()
                End If
            Case 3
                If Not CheckValues(tBoxScreen1Normal) Or Not CheckValues(tBoxScreen1Dimmed) Or Not CheckValues(tBoxScreen2Normal) Or Not CheckValues(tBoxScreen2Dimmed) Or Not CheckValues(tBoxScreen3Normal) Or Not CheckValues(tBoxScreen3Dimmed) Then
                    MsgBox("Error: Invalid brightness entered. Please enter an integer between 0 and 100.", MsgBoxStyle.Critical, "AutoBright Error")
                    Exit Sub
                End If
                If Int(tBoxScreen1Dimmed.Text) >= Int(tBoxScreen1Normal.Text) Or Int(tBoxScreen2Dimmed.Text) >= Int(tBoxScreen2Normal.Text) Or Int(tBoxScreen3Dimmed.Text) >= Int(tBoxScreen3Normal.Text) Then 'Prevent saving of invalid settings and display error message
                    MsgBox("Error: Dimmed brightness cannot be greater than or equal to normal brightness.", MsgBoxStyle.Critical, "AutoBright Error")
                Else
                    My.Settings.Screen1Normal = tBoxScreen1Normal.Text
                    My.Settings.Screen1Dimmed = tBoxScreen1Dimmed.Text
                    My.Settings.Screen2Normal = tBoxScreen2Normal.Text
                    My.Settings.Screen2Dimmed = tBoxScreen2Dimmed.Text
                    My.Settings.Screen3Normal = tBoxScreen3Normal.Text
                    My.Settings.Screen3Dimmed = tBoxScreen3Dimmed.Text
                    My.Settings.Save()
                    GetTimes()
                    UpdateSettings()
                End If
        End Select
        Debug.WriteLine("INFO: Settings saved")
    End Sub

    Private Sub btnAdvanced_Click(sender As Object, e As EventArgs) Handles btnAdvanced.Click
        frmAdvanced.ShowDialog()
    End Sub

    Private Function CheckValues(tBox As TextBox)
        If Not String.IsNullOrEmpty(tBox.Text) Then
            If tBox.Text >= 0 And tBox.Text <= 100 Then
                Return True 'Return true if number valid
            End If
        End If
        Return False 'Else return false
    End Function

    Private Sub SetMonitorLabelValue(screen As Integer) 'Sets the label value in user interface when brightness is changed
        Select Case screen
            Case 1
                lblScreen1Brightness.Text = "Screen 1 Current Brightness: " & GetBrightness(1) & "%"
            Case 2
                lblScreen2Brightness.Text = "Screen 2 Current Brightness: " & GetBrightness(2) & "%"
            Case 3
                lblScreen3Brightness.Text = "Screen 3 Current Brightness: " & GetBrightness(3) & "%"
        End Select
    End Sub

    Private Sub SetInitialMonitorLabelValue()
        Select Case PhysicalMonitors.Length
            Case 1
                lblScreen1Brightness.Enabled = True
                lblScreen2Brightness.Enabled = False
                lblScreen3Brightness.Enabled = False
                SetMonitorLabelValue(1)
            Case 2
                lblScreen1Brightness.Enabled = True
                lblScreen2Brightness.Enabled = True
                lblScreen3Brightness.Enabled = False
                SetMonitorLabelValue(1)
                SetMonitorLabelValue(2)
            Case 3
                lblScreen1Brightness.Enabled = True
                lblScreen2Brightness.Enabled = True
                lblScreen3Brightness.Enabled = True
                SetMonitorLabelValue(1)
                SetMonitorLabelValue(2)
                SetMonitorLabelValue(3) 'Enable and set values for appropriate labels
        End Select
    End Sub

    Private Sub IntegerTBoxHandler(sender As Object, e As KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 8 Then
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
            e.Handled = True
        End If
        'Only allow numbers to be entered - 48-57 are numbers, 8 is backspace
    End Sub

    Private Sub NegIntegerTBoxHandler(sender As Object, e As KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 45 Then
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
            e.Handled = True
        End If
        'Only allow numbers to be entered - 48-57 are numbers, 8 is backspace, 45 is minus
    End Sub

    Private Sub DecimalTBoxHandler(sender As Object, e As KeyPressEventArgs)
        If (Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57) And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 And Asc(e.KeyChar) <> 45 Or (sender.Text.Contains(".") And Asc(e.KeyChar) = 46) Or (sender.Text.Contains("-") And Asc(e.KeyChar) = 45) Then
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
            e.Handled = True
        End If
        'Only allow decimals (with one decimal point) to be entered - 48-57 are numbers, 8 is backspace, 46 is decimal point, 45 is minus
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        frmAbout.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        UpdateSettings()
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
        Me.ShowInTaskbar = False
        NotificationTrayIcon.Visible = True
    End Sub

#End Region

#Region "Notification Tray and closing"
    Private Sub NotificationTrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotificationTrayIcon.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True 'Show window on double click of icon
    End Sub

    Private Sub Settings_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If e.CloseReason = CloseReason.UserClosing Then
            UpdateSettings() 'Reset any changes made by user
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            Me.ShowInTaskbar = False
            NotificationTrayIcon.Visible = True
            e.Cancel = True
            'Minimize to tray if invoked by user through UI
        ElseIf e.CloseReason = CloseReason.ApplicationExitCall Or e.CloseReason = CloseReason.None Or e.CloseReason = CloseReason.TaskManagerClosing Or e.CloseReason = CloseReason.WindowsShutDown Then
            Select Case PhysicalMonitors.Length
                Case 1
                    SetBrightness(My.Settings.Screen1Normal, 1)
                Case 2
                    SetBrightness(My.Settings.Screen1Normal, 1)
                    SetBrightness(My.Settings.Screen2Normal, 2)
                Case 3
                    SetBrightness(My.Settings.Screen1Normal, 1)
                    SetBrightness(My.Settings.Screen2Normal, 2)
                    SetBrightness(My.Settings.Screen3Normal, 3)
            End Select
            'Reset brightness if actually closing
            MonitorHelper.DestroyAllPhysicalMonitors(PhysicalMonitors) 'when the form is closing you must destroy the PHYSICAL_MONITOR structures in the unmanaged memory
            EndExternalProgram()
        End If
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        Me.ShowInTaskbar = True
    End Sub

    Private Sub DisableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisableToolStripMenuItem.Click
        DisableToolStripMenuItem.Checked = Not DisableToolStripMenuItem.Checked
        If DisableToolStripMenuItem.Checked = True Then
            DisableTimers()
            EndExternalProgram()
            Select Case PhysicalMonitors.Length
                Case 1
                    SetBrightness(My.Settings.Screen1Normal, 1)
                Case 2
                    SetBrightness(My.Settings.Screen1Normal, 1)
                    SetBrightness(My.Settings.Screen2Normal, 2)
                Case 3
                    SetBrightness(My.Settings.Screen1Normal, 1)
                    SetBrightness(My.Settings.Screen2Normal, 2)
                    SetBrightness(My.Settings.Screen3Normal, 3)
            End Select
            NotificationTrayIcon.Icon = My.Resources.AutoBrightDisabled
            NotificationTrayIcon.Text = "AutoBright - Disabled"
        ElseIf DisableToolStripMenuItem.Checked = False Then
            ScheduleTimer.Enabled = True
            NotificationTrayIcon.Icon = My.Resources.AutoBrightIdle
            NotificationTrayIcon.Text = "AutoBright - Idle"
        End If
        Debug.WriteLine("INFO: Autobright Enabled: " & (Not DisableToolStripMenuItem.Checked).ToString)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Select Case PhysicalMonitors.Length
            Case 1
                SetBrightness(My.Settings.Screen1Normal, 1)
            Case 2
                SetBrightness(My.Settings.Screen1Normal, 1)
                SetBrightness(My.Settings.Screen2Normal, 2)
            Case 3
                SetBrightness(My.Settings.Screen1Normal, 1)
                SetBrightness(My.Settings.Screen2Normal, 2)
                SetBrightness(My.Settings.Screen3Normal, 3)
        End Select
        MonitorHelper.DestroyAllPhysicalMonitors(PhysicalMonitors) 'when the form is closing you must destroy the PHYSICAL_MONITOR structures in the unmanaged memory
        EndExternalProgram()
        Application.Exit()
    End Sub
#End Region

#Region "External program"
    Private Function isRunning()
        If Process.GetProcessesByName(Path.GetFileNameWithoutExtension(My.Settings.ExternalProgramPath)).Count > 0 Then
            Debug.WriteLine("INFO: External program currently running")
            Return True
        Else
            Debug.WriteLine("INFO: External program currently not running")
            Return False
        End If
    End Function

    Private Sub StartExternalProgram()
        Debug.WriteLine("INFO: Starting external program")
        externalProgramRunning = True
        Dim externalProgram = New Process
        externalProgram.StartInfo = New ProcessStartInfo() With {
        .WorkingDirectory = IO.Path.GetDirectoryName(My.Settings.ExternalProgramPath),
        .FileName = My.Settings.ExternalProgramPath,
        .Arguments = My.Settings.ExternalProgramArguments}

        externalProgram.Start() 'Run process to kill downloader process and any child processes
    End Sub

    Private Sub EndExternalProgram()
        Debug.WriteLine("INFO: Killing background process")
        externalProgramRunning = False
        Dim processKiller = New Process
        processKiller.StartInfo = New ProcessStartInfo() With {
            .WorkingDirectory = "C:\Windows\system32",
        .FileName = "C:\Windows\System32\taskkill.exe",
        .Arguments = "/f /im " & Path.GetFileName(My.Settings.ExternalProgramPath),
        .CreateNoWindow = True,
        .UseShellExecute = False}

        processKiller.Start() 'Run process to kill downloader process and any child processes
    End Sub
#End Region

End Class

