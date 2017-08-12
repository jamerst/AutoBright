Public Class frmFirstRun
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Dim Monitors() As MonitorHelper.PHYSICAL_MONITOR = MonitorHelper.GetPhysicalMonitors
        If Monitors.Length = 0 Then
            Application.Exit()
        End If
        Select Case Monitors.Length
            Case 1
                My.Settings.Screen1Normal = MonitorHelper.GetPhysicalMonitorBrightness(Monitors(0)) * 100
            Case 2
                My.Settings.Screen1Normal = MonitorHelper.GetPhysicalMonitorBrightness(Monitors(0)) * 100
                My.Settings.Screen2Normal = MonitorHelper.GetPhysicalMonitorBrightness(Monitors(1)) * 100
            Case 3
                My.Settings.Screen1Normal = MonitorHelper.GetPhysicalMonitorBrightness(Monitors(0)) * 100
                My.Settings.Screen2Normal = MonitorHelper.GetPhysicalMonitorBrightness(Monitors(1)) * 100
                My.Settings.Screen3Normal = MonitorHelper.GetPhysicalMonitorBrightness(Monitors(2)) * 100
        End Select
        My.Settings.FirstRun = False
        frmSettings.ScheduleTimer.Enabled = True
        My.Settings.Save()
        frmSettings.ShowInTaskbar = True
        frmSettings.Show()
        frmSettings.WindowState = FormWindowState.Normal
        Me.Close()
    End Sub
End Class