<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.TransitionDownTimer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotificationTrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.NotificationTrayContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TitleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gBoxScreen1 = New System.Windows.Forms.GroupBox()
        Me.lblScreen1DimmedLabel = New System.Windows.Forms.Label()
        Me.lblScreen1NormalLabel = New System.Windows.Forms.Label()
        Me.btnScreen1Preview = New System.Windows.Forms.Button()
        Me.tBoxScreen1Dimmed = New System.Windows.Forms.TextBox()
        Me.tBoxScreen1Normal = New System.Windows.Forms.TextBox()
        Me.tBarScreen1Dimmed = New System.Windows.Forms.TrackBar()
        Me.tBarScreen1Normal = New System.Windows.Forms.TrackBar()
        Me.gBoxScreen2 = New System.Windows.Forms.GroupBox()
        Me.lblScreen2DimmedLabel = New System.Windows.Forms.Label()
        Me.lblScreen2NormalLabel = New System.Windows.Forms.Label()
        Me.btnScreen2Preview = New System.Windows.Forms.Button()
        Me.tBoxScreen2Dimmed = New System.Windows.Forms.TextBox()
        Me.tBoxScreen2Normal = New System.Windows.Forms.TextBox()
        Me.tBarScreen2Dimmed = New System.Windows.Forms.TrackBar()
        Me.tBarScreen2Normal = New System.Windows.Forms.TrackBar()
        Me.gBoxScreen3 = New System.Windows.Forms.GroupBox()
        Me.lblScreen3DimmedLabel = New System.Windows.Forms.Label()
        Me.lblScreen3NormalLabel = New System.Windows.Forms.Label()
        Me.btnScreen3Preview = New System.Windows.Forms.Button()
        Me.tBoxScreen3Dimmed = New System.Windows.Forms.TextBox()
        Me.tBoxScreen3Normal = New System.Windows.Forms.TextBox()
        Me.tBarScreen3Dimmed = New System.Windows.Forms.TrackBar()
        Me.tBarScreen3Normal = New System.Windows.Forms.TrackBar()
        Me.gBoxOptions = New System.Windows.Forms.GroupBox()
        Me.btnAdvanced = New System.Windows.Forms.Button()
        Me.tBoxOffset = New System.Windows.Forms.TextBox()
        Me.lblOffset = New System.Windows.Forms.Label()
        Me.tBoxTransitionTime = New System.Windows.Forms.TextBox()
        Me.lblTransitionTime = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PreviewBrightness = New System.ComponentModel.BackgroundWorker()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.gBoxLocation = New System.Windows.Forms.GroupBox()
        Me.tBoxLongitude = New System.Windows.Forms.TextBox()
        Me.lblLongitude = New System.Windows.Forms.Label()
        Me.tBoxLatitude = New System.Windows.Forms.TextBox()
        Me.lblLatitude = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.TransitionUpTimer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ScheduleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TransitionDownTimer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TransitionDownTimer3 = New System.Windows.Forms.Timer(Me.components)
        Me.TransitionUpTimer2 = New System.Windows.Forms.Timer(Me.components)
        Me.TransitionUpTimer3 = New System.Windows.Forms.Timer(Me.components)
        Me.lblEndTime = New System.Windows.Forms.Label()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.gBoxInfo = New System.Windows.Forms.GroupBox()
        Me.lblScreen3Brightness = New System.Windows.Forms.Label()
        Me.lblScreen2Brightness = New System.Windows.Forms.Label()
        Me.lblScreen1Brightness = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.NotificationTrayContext.SuspendLayout()
        Me.gBoxScreen1.SuspendLayout()
        CType(Me.tBarScreen1Dimmed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tBarScreen1Normal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxScreen2.SuspendLayout()
        CType(Me.tBarScreen2Dimmed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tBarScreen2Normal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxScreen3.SuspendLayout()
        CType(Me.tBarScreen3Dimmed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tBarScreen3Normal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gBoxOptions.SuspendLayout()
        Me.gBoxLocation.SuspendLayout()
        Me.gBoxInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'TransitionDownTimer1
        '
        Me.TransitionDownTimer1.Interval = 500
        '
        'NotificationTrayIcon
        '
        Me.NotificationTrayIcon.ContextMenuStrip = Me.NotificationTrayContext
        Me.NotificationTrayIcon.Icon = CType(resources.GetObject("NotificationTrayIcon.Icon"), System.Drawing.Icon)
        Me.NotificationTrayIcon.Text = "AutoBright - Idle"
        Me.NotificationTrayIcon.Visible = True
        '
        'NotificationTrayContext
        '
        Me.NotificationTrayContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TitleToolStripMenuItem, Me.ToolStripSeparator1, Me.SettingsToolStripMenuItem, Me.DisableToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.NotificationTrayContext.Name = "NotificationTrayContect"
        Me.NotificationTrayContext.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.NotificationTrayContext.Size = New System.Drawing.Size(153, 120)
        '
        'TitleToolStripMenuItem
        '
        Me.TitleToolStripMenuItem.Image = Global.AutoBright.My.Resources.Resources.AutoBrightIdle1
        Me.TitleToolStripMenuItem.Name = "TitleToolStripMenuItem"
        Me.TitleToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TitleToolStripMenuItem.Text = "AutoBright"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'DisableToolStripMenuItem
        '
        Me.DisableToolStripMenuItem.Name = "DisableToolStripMenuItem"
        Me.DisableToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DisableToolStripMenuItem.Text = "Disable"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'gBoxScreen1
        '
        Me.gBoxScreen1.Controls.Add(Me.lblScreen1DimmedLabel)
        Me.gBoxScreen1.Controls.Add(Me.lblScreen1NormalLabel)
        Me.gBoxScreen1.Controls.Add(Me.btnScreen1Preview)
        Me.gBoxScreen1.Controls.Add(Me.tBoxScreen1Dimmed)
        Me.gBoxScreen1.Controls.Add(Me.tBoxScreen1Normal)
        Me.gBoxScreen1.Controls.Add(Me.tBarScreen1Dimmed)
        Me.gBoxScreen1.Controls.Add(Me.tBarScreen1Normal)
        Me.gBoxScreen1.Enabled = False
        Me.gBoxScreen1.Location = New System.Drawing.Point(12, 12)
        Me.gBoxScreen1.Name = "gBoxScreen1"
        Me.gBoxScreen1.Size = New System.Drawing.Size(340, 135)
        Me.gBoxScreen1.TabIndex = 22
        Me.gBoxScreen1.TabStop = False
        Me.gBoxScreen1.Text = "Screen 1"
        '
        'lblScreen1DimmedLabel
        '
        Me.lblScreen1DimmedLabel.AutoSize = True
        Me.lblScreen1DimmedLabel.Location = New System.Drawing.Point(6, 72)
        Me.lblScreen1DimmedLabel.Name = "lblScreen1DimmedLabel"
        Me.lblScreen1DimmedLabel.Size = New System.Drawing.Size(97, 13)
        Me.lblScreen1DimmedLabel.TabIndex = 14
        Me.lblScreen1DimmedLabel.Text = "Dimmed Brightness"
        '
        'lblScreen1NormalLabel
        '
        Me.lblScreen1NormalLabel.AutoSize = True
        Me.lblScreen1NormalLabel.Location = New System.Drawing.Point(6, 21)
        Me.lblScreen1NormalLabel.Name = "lblScreen1NormalLabel"
        Me.lblScreen1NormalLabel.Size = New System.Drawing.Size(92, 13)
        Me.lblScreen1NormalLabel.TabIndex = 13
        Me.lblScreen1NormalLabel.Text = "Normal Brightness"
        '
        'btnScreen1Preview
        '
        Me.btnScreen1Preview.Location = New System.Drawing.Point(254, 88)
        Me.btnScreen1Preview.Name = "btnScreen1Preview"
        Me.btnScreen1Preview.Size = New System.Drawing.Size(75, 20)
        Me.btnScreen1Preview.TabIndex = 3
        Me.btnScreen1Preview.Text = "Preview"
        Me.ToolTip.SetToolTip(Me.btnScreen1Preview, "Preview brightness levels")
        Me.btnScreen1Preview.UseVisualStyleBackColor = True
        '
        'tBoxScreen1Dimmed
        '
        Me.tBoxScreen1Dimmed.Location = New System.Drawing.Point(212, 88)
        Me.tBoxScreen1Dimmed.Name = "tBoxScreen1Dimmed"
        Me.tBoxScreen1Dimmed.ShortcutsEnabled = False
        Me.tBoxScreen1Dimmed.Size = New System.Drawing.Size(36, 20)
        Me.tBoxScreen1Dimmed.TabIndex = 2
        Me.ToolTip.SetToolTip(Me.tBoxScreen1Dimmed, "Manually type a brightness value")
        '
        'tBoxScreen1Normal
        '
        Me.tBoxScreen1Normal.Location = New System.Drawing.Point(212, 37)
        Me.tBoxScreen1Normal.Name = "tBoxScreen1Normal"
        Me.tBoxScreen1Normal.ShortcutsEnabled = False
        Me.tBoxScreen1Normal.Size = New System.Drawing.Size(36, 20)
        Me.tBoxScreen1Normal.TabIndex = 1
        Me.ToolTip.SetToolTip(Me.tBoxScreen1Normal, "Manually type a brightness value")
        '
        'tBarScreen1Dimmed
        '
        Me.tBarScreen1Dimmed.LargeChange = 10
        Me.tBarScreen1Dimmed.Location = New System.Drawing.Point(6, 88)
        Me.tBarScreen1Dimmed.Maximum = 100
        Me.tBarScreen1Dimmed.Name = "tBarScreen1Dimmed"
        Me.tBarScreen1Dimmed.Size = New System.Drawing.Size(200, 45)
        Me.tBarScreen1Dimmed.SmallChange = 5
        Me.tBarScreen1Dimmed.TabIndex = 9
        Me.tBarScreen1Dimmed.TabStop = False
        Me.tBarScreen1Dimmed.TickFrequency = 10
        Me.ToolTip.SetToolTip(Me.tBarScreen1Dimmed, "Slide to set brightness level")
        '
        'tBarScreen1Normal
        '
        Me.tBarScreen1Normal.LargeChange = 10
        Me.tBarScreen1Normal.Location = New System.Drawing.Point(6, 37)
        Me.tBarScreen1Normal.Maximum = 100
        Me.tBarScreen1Normal.Name = "tBarScreen1Normal"
        Me.tBarScreen1Normal.Size = New System.Drawing.Size(200, 45)
        Me.tBarScreen1Normal.SmallChange = 5
        Me.tBarScreen1Normal.TabIndex = 17
        Me.tBarScreen1Normal.TabStop = False
        Me.tBarScreen1Normal.TickFrequency = 10
        Me.ToolTip.SetToolTip(Me.tBarScreen1Normal, "Slide to set brightness level")
        '
        'gBoxScreen2
        '
        Me.gBoxScreen2.Controls.Add(Me.lblScreen2DimmedLabel)
        Me.gBoxScreen2.Controls.Add(Me.lblScreen2NormalLabel)
        Me.gBoxScreen2.Controls.Add(Me.btnScreen2Preview)
        Me.gBoxScreen2.Controls.Add(Me.tBoxScreen2Dimmed)
        Me.gBoxScreen2.Controls.Add(Me.tBoxScreen2Normal)
        Me.gBoxScreen2.Controls.Add(Me.tBarScreen2Dimmed)
        Me.gBoxScreen2.Controls.Add(Me.tBarScreen2Normal)
        Me.gBoxScreen2.Enabled = False
        Me.gBoxScreen2.Location = New System.Drawing.Point(12, 153)
        Me.gBoxScreen2.Name = "gBoxScreen2"
        Me.gBoxScreen2.Size = New System.Drawing.Size(340, 135)
        Me.gBoxScreen2.TabIndex = 23
        Me.gBoxScreen2.TabStop = False
        Me.gBoxScreen2.Text = "Screen 2"
        '
        'lblScreen2DimmedLabel
        '
        Me.lblScreen2DimmedLabel.AutoSize = True
        Me.lblScreen2DimmedLabel.Location = New System.Drawing.Point(6, 72)
        Me.lblScreen2DimmedLabel.Name = "lblScreen2DimmedLabel"
        Me.lblScreen2DimmedLabel.Size = New System.Drawing.Size(97, 13)
        Me.lblScreen2DimmedLabel.TabIndex = 21
        Me.lblScreen2DimmedLabel.Text = "Dimmed Brightness"
        '
        'lblScreen2NormalLabel
        '
        Me.lblScreen2NormalLabel.AutoSize = True
        Me.lblScreen2NormalLabel.Location = New System.Drawing.Point(6, 21)
        Me.lblScreen2NormalLabel.Name = "lblScreen2NormalLabel"
        Me.lblScreen2NormalLabel.Size = New System.Drawing.Size(92, 13)
        Me.lblScreen2NormalLabel.TabIndex = 20
        Me.lblScreen2NormalLabel.Text = "Normal Brightness"
        '
        'btnScreen2Preview
        '
        Me.btnScreen2Preview.Location = New System.Drawing.Point(254, 88)
        Me.btnScreen2Preview.Name = "btnScreen2Preview"
        Me.btnScreen2Preview.Size = New System.Drawing.Size(75, 23)
        Me.btnScreen2Preview.TabIndex = 6
        Me.btnScreen2Preview.Text = "Preview"
        Me.ToolTip.SetToolTip(Me.btnScreen2Preview, "Preview brightness levels")
        Me.btnScreen2Preview.UseVisualStyleBackColor = True
        '
        'tBoxScreen2Dimmed
        '
        Me.tBoxScreen2Dimmed.Location = New System.Drawing.Point(212, 88)
        Me.tBoxScreen2Dimmed.Name = "tBoxScreen2Dimmed"
        Me.tBoxScreen2Dimmed.ShortcutsEnabled = False
        Me.tBoxScreen2Dimmed.Size = New System.Drawing.Size(36, 20)
        Me.tBoxScreen2Dimmed.TabIndex = 5
        Me.ToolTip.SetToolTip(Me.tBoxScreen2Dimmed, "Manually type a brightness value")
        '
        'tBoxScreen2Normal
        '
        Me.tBoxScreen2Normal.Location = New System.Drawing.Point(212, 37)
        Me.tBoxScreen2Normal.Name = "tBoxScreen2Normal"
        Me.tBoxScreen2Normal.ShortcutsEnabled = False
        Me.tBoxScreen2Normal.Size = New System.Drawing.Size(36, 20)
        Me.tBoxScreen2Normal.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.tBoxScreen2Normal, "Manually type a brightness value")
        '
        'tBarScreen2Dimmed
        '
        Me.tBarScreen2Dimmed.LargeChange = 10
        Me.tBarScreen2Dimmed.Location = New System.Drawing.Point(6, 88)
        Me.tBarScreen2Dimmed.Maximum = 100
        Me.tBarScreen2Dimmed.Name = "tBarScreen2Dimmed"
        Me.tBarScreen2Dimmed.Size = New System.Drawing.Size(200, 45)
        Me.tBarScreen2Dimmed.SmallChange = 5
        Me.tBarScreen2Dimmed.TabIndex = 16
        Me.tBarScreen2Dimmed.TabStop = False
        Me.tBarScreen2Dimmed.TickFrequency = 10
        Me.ToolTip.SetToolTip(Me.tBarScreen2Dimmed, "Slide to set brightness level")
        '
        'tBarScreen2Normal
        '
        Me.tBarScreen2Normal.LargeChange = 10
        Me.tBarScreen2Normal.Location = New System.Drawing.Point(6, 37)
        Me.tBarScreen2Normal.Maximum = 100
        Me.tBarScreen2Normal.Name = "tBarScreen2Normal"
        Me.tBarScreen2Normal.Size = New System.Drawing.Size(200, 45)
        Me.tBarScreen2Normal.SmallChange = 5
        Me.tBarScreen2Normal.TabIndex = 15
        Me.tBarScreen2Normal.TabStop = False
        Me.tBarScreen2Normal.TickFrequency = 10
        Me.ToolTip.SetToolTip(Me.tBarScreen2Normal, "Slide to set brightness level")
        '
        'gBoxScreen3
        '
        Me.gBoxScreen3.Controls.Add(Me.lblScreen3DimmedLabel)
        Me.gBoxScreen3.Controls.Add(Me.lblScreen3NormalLabel)
        Me.gBoxScreen3.Controls.Add(Me.btnScreen3Preview)
        Me.gBoxScreen3.Controls.Add(Me.tBoxScreen3Dimmed)
        Me.gBoxScreen3.Controls.Add(Me.tBoxScreen3Normal)
        Me.gBoxScreen3.Controls.Add(Me.tBarScreen3Dimmed)
        Me.gBoxScreen3.Controls.Add(Me.tBarScreen3Normal)
        Me.gBoxScreen3.Enabled = False
        Me.gBoxScreen3.Location = New System.Drawing.Point(12, 294)
        Me.gBoxScreen3.Name = "gBoxScreen3"
        Me.gBoxScreen3.Size = New System.Drawing.Size(340, 135)
        Me.gBoxScreen3.TabIndex = 24
        Me.gBoxScreen3.TabStop = False
        Me.gBoxScreen3.Text = "Screen 3"
        '
        'lblScreen3DimmedLabel
        '
        Me.lblScreen3DimmedLabel.AutoSize = True
        Me.lblScreen3DimmedLabel.Location = New System.Drawing.Point(6, 69)
        Me.lblScreen3DimmedLabel.Name = "lblScreen3DimmedLabel"
        Me.lblScreen3DimmedLabel.Size = New System.Drawing.Size(97, 13)
        Me.lblScreen3DimmedLabel.TabIndex = 28
        Me.lblScreen3DimmedLabel.Text = "Dimmed Brightness"
        '
        'lblScreen3NormalLabel
        '
        Me.lblScreen3NormalLabel.AutoSize = True
        Me.lblScreen3NormalLabel.Location = New System.Drawing.Point(6, 21)
        Me.lblScreen3NormalLabel.Name = "lblScreen3NormalLabel"
        Me.lblScreen3NormalLabel.Size = New System.Drawing.Size(92, 13)
        Me.lblScreen3NormalLabel.TabIndex = 27
        Me.lblScreen3NormalLabel.Text = "Normal Brightness"
        '
        'btnScreen3Preview
        '
        Me.btnScreen3Preview.Location = New System.Drawing.Point(254, 88)
        Me.btnScreen3Preview.Name = "btnScreen3Preview"
        Me.btnScreen3Preview.Size = New System.Drawing.Size(75, 23)
        Me.btnScreen3Preview.TabIndex = 9
        Me.btnScreen3Preview.Text = "Preview"
        Me.ToolTip.SetToolTip(Me.btnScreen3Preview, "Preview brightness levels")
        Me.btnScreen3Preview.UseVisualStyleBackColor = True
        '
        'tBoxScreen3Dimmed
        '
        Me.tBoxScreen3Dimmed.Location = New System.Drawing.Point(212, 88)
        Me.tBoxScreen3Dimmed.Name = "tBoxScreen3Dimmed"
        Me.tBoxScreen3Dimmed.ShortcutsEnabled = False
        Me.tBoxScreen3Dimmed.Size = New System.Drawing.Size(36, 20)
        Me.tBoxScreen3Dimmed.TabIndex = 8
        Me.ToolTip.SetToolTip(Me.tBoxScreen3Dimmed, "Manually type a brightness value")
        '
        'tBoxScreen3Normal
        '
        Me.tBoxScreen3Normal.Location = New System.Drawing.Point(212, 37)
        Me.tBoxScreen3Normal.Name = "tBoxScreen3Normal"
        Me.tBoxScreen3Normal.ShortcutsEnabled = False
        Me.tBoxScreen3Normal.Size = New System.Drawing.Size(36, 20)
        Me.tBoxScreen3Normal.TabIndex = 7
        Me.ToolTip.SetToolTip(Me.tBoxScreen3Normal, "Manually type a brightness value")
        '
        'tBarScreen3Dimmed
        '
        Me.tBarScreen3Dimmed.LargeChange = 10
        Me.tBarScreen3Dimmed.Location = New System.Drawing.Point(6, 88)
        Me.tBarScreen3Dimmed.Maximum = 100
        Me.tBarScreen3Dimmed.Name = "tBarScreen3Dimmed"
        Me.tBarScreen3Dimmed.Size = New System.Drawing.Size(200, 45)
        Me.tBarScreen3Dimmed.SmallChange = 5
        Me.tBarScreen3Dimmed.TabIndex = 23
        Me.tBarScreen3Dimmed.TabStop = False
        Me.tBarScreen3Dimmed.TickFrequency = 10
        Me.ToolTip.SetToolTip(Me.tBarScreen3Dimmed, "Slide to set brightness level")
        '
        'tBarScreen3Normal
        '
        Me.tBarScreen3Normal.LargeChange = 10
        Me.tBarScreen3Normal.Location = New System.Drawing.Point(6, 37)
        Me.tBarScreen3Normal.Maximum = 100
        Me.tBarScreen3Normal.Name = "tBarScreen3Normal"
        Me.tBarScreen3Normal.Size = New System.Drawing.Size(200, 45)
        Me.tBarScreen3Normal.SmallChange = 5
        Me.tBarScreen3Normal.TabIndex = 22
        Me.tBarScreen3Normal.TabStop = False
        Me.tBarScreen3Normal.TickFrequency = 10
        Me.ToolTip.SetToolTip(Me.tBarScreen3Normal, "Slide to set brightness level")
        '
        'gBoxOptions
        '
        Me.gBoxOptions.Controls.Add(Me.btnAdvanced)
        Me.gBoxOptions.Controls.Add(Me.tBoxOffset)
        Me.gBoxOptions.Controls.Add(Me.lblOffset)
        Me.gBoxOptions.Controls.Add(Me.tBoxTransitionTime)
        Me.gBoxOptions.Controls.Add(Me.lblTransitionTime)
        Me.gBoxOptions.Location = New System.Drawing.Point(358, 12)
        Me.gBoxOptions.Name = "gBoxOptions"
        Me.gBoxOptions.Size = New System.Drawing.Size(284, 92)
        Me.gBoxOptions.TabIndex = 25
        Me.gBoxOptions.TabStop = False
        Me.gBoxOptions.Text = "Options"
        '
        'btnAdvanced
        '
        Me.btnAdvanced.Location = New System.Drawing.Point(10, 63)
        Me.btnAdvanced.Name = "btnAdvanced"
        Me.btnAdvanced.Size = New System.Drawing.Size(75, 23)
        Me.btnAdvanced.TabIndex = 13
        Me.btnAdvanced.Text = "Advanced"
        Me.btnAdvanced.UseVisualStyleBackColor = True
        '
        'tBoxOffset
        '
        Me.tBoxOffset.Location = New System.Drawing.Point(143, 37)
        Me.tBoxOffset.Margin = New System.Windows.Forms.Padding(30, 3, 3, 3)
        Me.tBoxOffset.Name = "tBoxOffset"
        Me.tBoxOffset.Size = New System.Drawing.Size(100, 20)
        Me.tBoxOffset.TabIndex = 12
        Me.ToolTip.SetToolTip(Me.tBoxOffset, "Amount to offset dimming/undimming by. Negative value will start sooner and end l" &
        "ater.")
        '
        'lblOffset
        '
        Me.lblOffset.AutoSize = True
        Me.lblOffset.Location = New System.Drawing.Point(140, 21)
        Me.lblOffset.Name = "lblOffset"
        Me.lblOffset.Size = New System.Drawing.Size(65, 13)
        Me.lblOffset.TabIndex = 11
        Me.lblOffset.Text = "Offset (mins)"
        '
        'tBoxTransitionTime
        '
        Me.tBoxTransitionTime.Location = New System.Drawing.Point(10, 37)
        Me.tBoxTransitionTime.Name = "tBoxTransitionTime"
        Me.tBoxTransitionTime.Size = New System.Drawing.Size(100, 20)
        Me.tBoxTransitionTime.TabIndex = 10
        Me.ToolTip.SetToolTip(Me.tBoxTransitionTime, "Time for change from normal to dimmed")
        '
        'lblTransitionTime
        '
        Me.lblTransitionTime.AutoSize = True
        Me.lblTransitionTime.Location = New System.Drawing.Point(7, 21)
        Me.lblTransitionTime.Name = "lblTransitionTime"
        Me.lblTransitionTime.Size = New System.Drawing.Size(109, 13)
        Me.lblTransitionTime.TabIndex = 3
        Me.lblTransitionTime.Text = "Transition Time (mins)"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(358, 404)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(88, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save"
        Me.ToolTip.SetToolTip(Me.btnSave, "Save settings changes")
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(554, 404)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(88, 23)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "Close"
        Me.ToolTip.SetToolTip(Me.btnClose, "Hide window")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PreviewBrightness
        '
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(456, 404)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(88, 23)
        Me.btnAbout.TabIndex = 16
        Me.btnAbout.Text = "About"
        Me.ToolTip.SetToolTip(Me.btnAbout, "Show info about application")
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'gBoxLocation
        '
        Me.gBoxLocation.Controls.Add(Me.tBoxLongitude)
        Me.gBoxLocation.Controls.Add(Me.lblLongitude)
        Me.gBoxLocation.Controls.Add(Me.tBoxLatitude)
        Me.gBoxLocation.Controls.Add(Me.lblLatitude)
        Me.gBoxLocation.Controls.Add(Me.lblLocation)
        Me.gBoxLocation.Location = New System.Drawing.Point(358, 110)
        Me.gBoxLocation.Name = "gBoxLocation"
        Me.gBoxLocation.Size = New System.Drawing.Size(284, 177)
        Me.gBoxLocation.TabIndex = 29
        Me.gBoxLocation.TabStop = False
        Me.gBoxLocation.Text = "Location"
        '
        'tBoxLongitude
        '
        Me.tBoxLongitude.Location = New System.Drawing.Point(6, 144)
        Me.tBoxLongitude.Name = "tBoxLongitude"
        Me.tBoxLongitude.ShortcutsEnabled = False
        Me.tBoxLongitude.Size = New System.Drawing.Size(272, 20)
        Me.tBoxLongitude.TabIndex = 12
        Me.ToolTip.SetToolTip(Me.tBoxLongitude, "Longitude for your location")
        '
        'lblLongitude
        '
        Me.lblLongitude.AutoSize = True
        Me.lblLongitude.Location = New System.Drawing.Point(6, 128)
        Me.lblLongitude.Name = "lblLongitude"
        Me.lblLongitude.Size = New System.Drawing.Size(54, 13)
        Me.lblLongitude.TabIndex = 3
        Me.lblLongitude.Text = "Longitude"
        '
        'tBoxLatitude
        '
        Me.tBoxLatitude.Location = New System.Drawing.Point(6, 105)
        Me.tBoxLatitude.Name = "tBoxLatitude"
        Me.tBoxLatitude.ShortcutsEnabled = False
        Me.tBoxLatitude.Size = New System.Drawing.Size(272, 20)
        Me.tBoxLatitude.TabIndex = 11
        Me.ToolTip.SetToolTip(Me.tBoxLatitude, "Latitude for your location")
        '
        'lblLatitude
        '
        Me.lblLatitude.AutoSize = True
        Me.lblLatitude.Location = New System.Drawing.Point(6, 89)
        Me.lblLatitude.Name = "lblLatitude"
        Me.lblLatitude.Size = New System.Drawing.Size(45, 13)
        Me.lblLatitude.TabIndex = 1
        Me.lblLatitude.Text = "Latitude"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Location = New System.Drawing.Point(7, 16)
        Me.lblLocation.MaximumSize = New System.Drawing.Size(274, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(261, 65)
        Me.lblLocation.TabIndex = 0
        Me.lblLocation.Text = "In order to get times for your location, latitude and longitude coordinates are n" &
    "eeded." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This data is handled externally by sunrise-sunset.org's API and I am n" &
    "ot responsible for any data entered."
        '
        'TransitionUpTimer1
        '
        '
        'ScheduleTimer
        '
        Me.ScheduleTimer.Interval = 1000
        '
        'TransitionDownTimer2
        '
        Me.TransitionDownTimer2.Interval = 500
        '
        'TransitionDownTimer3
        '
        '
        'TransitionUpTimer2
        '
        '
        'TransitionUpTimer3
        '
        '
        'lblEndTime
        '
        Me.lblEndTime.AutoSize = True
        Me.lblEndTime.Location = New System.Drawing.Point(6, 32)
        Me.lblEndTime.Name = "lblEndTime"
        Me.lblEndTime.Size = New System.Drawing.Size(72, 13)
        Me.lblEndTime.TabIndex = 30
        Me.lblEndTime.Text = "Dimming End:"
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Location = New System.Drawing.Point(6, 16)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(75, 13)
        Me.lblStartTime.TabIndex = 31
        Me.lblStartTime.Text = "Dimming Start:"
        '
        'gBoxInfo
        '
        Me.gBoxInfo.Controls.Add(Me.lblScreen3Brightness)
        Me.gBoxInfo.Controls.Add(Me.lblScreen2Brightness)
        Me.gBoxInfo.Controls.Add(Me.lblScreen1Brightness)
        Me.gBoxInfo.Controls.Add(Me.lblEndTime)
        Me.gBoxInfo.Controls.Add(Me.lblStartTime)
        Me.gBoxInfo.Location = New System.Drawing.Point(358, 293)
        Me.gBoxInfo.Name = "gBoxInfo"
        Me.gBoxInfo.Size = New System.Drawing.Size(284, 96)
        Me.gBoxInfo.TabIndex = 32
        Me.gBoxInfo.TabStop = False
        Me.gBoxInfo.Text = "Info"
        '
        'lblScreen3Brightness
        '
        Me.lblScreen3Brightness.AutoSize = True
        Me.lblScreen3Brightness.Location = New System.Drawing.Point(6, 80)
        Me.lblScreen3Brightness.Name = "lblScreen3Brightness"
        Me.lblScreen3Brightness.Size = New System.Drawing.Size(142, 13)
        Me.lblScreen3Brightness.TabIndex = 34
        Me.lblScreen3Brightness.Text = "Screen 3 Current Brightness:"
        '
        'lblScreen2Brightness
        '
        Me.lblScreen2Brightness.AutoSize = True
        Me.lblScreen2Brightness.Location = New System.Drawing.Point(6, 67)
        Me.lblScreen2Brightness.Name = "lblScreen2Brightness"
        Me.lblScreen2Brightness.Size = New System.Drawing.Size(142, 13)
        Me.lblScreen2Brightness.TabIndex = 33
        Me.lblScreen2Brightness.Text = "Screen 2 Current Brightness:"
        '
        'lblScreen1Brightness
        '
        Me.lblScreen1Brightness.AutoSize = True
        Me.lblScreen1Brightness.Location = New System.Drawing.Point(6, 54)
        Me.lblScreen1Brightness.Name = "lblScreen1Brightness"
        Me.lblScreen1Brightness.Size = New System.Drawing.Size(142, 13)
        Me.lblScreen1Brightness.TabIndex = 32
        Me.lblScreen1Brightness.Text = "Screen 1 Current Brightness:"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(654, 440)
        Me.Controls.Add(Me.gBoxInfo)
        Me.Controls.Add(Me.gBoxLocation)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gBoxOptions)
        Me.Controls.Add(Me.gBoxScreen3)
        Me.Controls.Add(Me.gBoxScreen2)
        Me.Controls.Add(Me.gBoxScreen1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AutoBright Settings"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.NotificationTrayContext.ResumeLayout(False)
        Me.gBoxScreen1.ResumeLayout(False)
        Me.gBoxScreen1.PerformLayout()
        CType(Me.tBarScreen1Dimmed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tBarScreen1Normal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxScreen2.ResumeLayout(False)
        Me.gBoxScreen2.PerformLayout()
        CType(Me.tBarScreen2Dimmed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tBarScreen2Normal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxScreen3.ResumeLayout(False)
        Me.gBoxScreen3.PerformLayout()
        CType(Me.tBarScreen3Dimmed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tBarScreen3Normal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gBoxOptions.ResumeLayout(False)
        Me.gBoxOptions.PerformLayout()
        Me.gBoxLocation.ResumeLayout(False)
        Me.gBoxLocation.PerformLayout()
        Me.gBoxInfo.ResumeLayout(False)
        Me.gBoxInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TransitionDownTimer1 As Timer
    Friend WithEvents NotificationTrayIcon As NotifyIcon
    Friend WithEvents gBoxScreen1 As GroupBox
    Friend WithEvents lblScreen1DimmedLabel As Label
    Friend WithEvents lblScreen1NormalLabel As Label
    Friend WithEvents btnScreen1Preview As Button
    Friend WithEvents tBoxScreen1Dimmed As TextBox
    Friend WithEvents tBoxScreen1Normal As TextBox
    Friend WithEvents tBarScreen1Dimmed As TrackBar
    Friend WithEvents tBarScreen1Normal As TrackBar
    Friend WithEvents gBoxScreen2 As GroupBox
    Friend WithEvents lblScreen2DimmedLabel As Label
    Friend WithEvents lblScreen2NormalLabel As Label
    Friend WithEvents btnScreen2Preview As Button
    Friend WithEvents tBoxScreen2Dimmed As TextBox
    Friend WithEvents tBoxScreen2Normal As TextBox
    Friend WithEvents tBarScreen2Dimmed As TrackBar
    Friend WithEvents tBarScreen2Normal As TrackBar
    Friend WithEvents gBoxScreen3 As GroupBox
    Friend WithEvents lblScreen3DimmedLabel As Label
    Friend WithEvents lblScreen3NormalLabel As Label
    Friend WithEvents btnScreen3Preview As Button
    Friend WithEvents tBoxScreen3Dimmed As TextBox
    Friend WithEvents tBoxScreen3Normal As TextBox
    Friend WithEvents tBarScreen3Dimmed As TrackBar
    Friend WithEvents tBarScreen3Normal As TrackBar
    Friend WithEvents gBoxOptions As GroupBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents PreviewBrightness As System.ComponentModel.BackgroundWorker
    Friend WithEvents tBoxTransitionTime As TextBox
    Friend WithEvents lblTransitionTime As Label
    Friend WithEvents NotificationTrayContext As ContextMenuStrip
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DisableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents TitleToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnAbout As Button
    Friend WithEvents gBoxLocation As GroupBox
    Friend WithEvents tBoxLatitude As TextBox
    Friend WithEvents lblLatitude As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents tBoxLongitude As TextBox
    Friend WithEvents lblLongitude As Label
    Friend WithEvents TransitionUpTimer1 As Timer
    Friend WithEvents ScheduleTimer As Timer
    Friend WithEvents TransitionDownTimer2 As Timer
    Friend WithEvents TransitionDownTimer3 As Timer
    Friend WithEvents TransitionUpTimer2 As Timer
    Friend WithEvents TransitionUpTimer3 As Timer
    Friend WithEvents lblEndTime As Label
    Friend WithEvents lblStartTime As Label
    Friend WithEvents gBoxInfo As GroupBox
    Friend WithEvents lblScreen3Brightness As Label
    Friend WithEvents lblScreen2Brightness As Label
    Friend WithEvents lblScreen1Brightness As Label
    Friend WithEvents tBoxOffset As TextBox
    Friend WithEvents lblOffset As Label
    Friend WithEvents ToolTip As ToolTip
    Friend WithEvents btnAdvanced As Button
End Class
