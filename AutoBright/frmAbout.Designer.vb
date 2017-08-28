<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.pBoxLogo = New System.Windows.Forms.PictureBox()
        Me.lblChangelog = New System.Windows.Forms.Label()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblSunsetSunrise = New System.Windows.Forms.Label()
        Me.lnkLblLocation = New System.Windows.Forms.LinkLabel()
        Me.lblBrightnessControl = New System.Windows.Forms.Label()
        Me.lnkLblLicense = New System.Windows.Forms.LinkLabel()
        CType(Me.pBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pBoxLogo
        '
        Me.pBoxLogo.Cursor = System.Windows.Forms.Cursors.Default
        Me.pBoxLogo.Image = Global.AutoBright.My.Resources.Resources.AutoBrightIdle1
        Me.pBoxLogo.Location = New System.Drawing.Point(262, 11)
        Me.pBoxLogo.Name = "pBoxLogo"
        Me.pBoxLogo.Size = New System.Drawing.Size(110, 110)
        Me.pBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBoxLogo.TabIndex = 29
        Me.pBoxLogo.TabStop = False
        '
        'lblChangelog
        '
        Me.lblChangelog.AutoSize = True
        Me.lblChangelog.Location = New System.Drawing.Point(12, 56)
        Me.lblChangelog.MaximumSize = New System.Drawing.Size(250, 0)
        Me.lblChangelog.Name = "lblChangelog"
        Me.lblChangelog.Size = New System.Drawing.Size(246, 39)
        Me.lblChangelog.TabIndex = 28
        Me.lblChangelog.Text = "Changelog:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fixed reusing of previous times when time fetching fails"
        '
        'lblVer
        '
        Me.lblVer.AutoSize = True
        Me.lblVer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVer.Location = New System.Drawing.Point(12, 34)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(69, 13)
        Me.lblVer.TabIndex = 27
        Me.lblVer.Text = "Version 2.3.2"
        Me.lblVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(12, 11)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(174, 13)
        Me.lblTitle.TabIndex = 26
        Me.lblTitle.Text = "AutoBright © James Tattersall 2017"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSunsetSunrise
        '
        Me.lblSunsetSunrise.AutoSize = True
        Me.lblSunsetSunrise.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSunsetSunrise.Location = New System.Drawing.Point(12, 177)
        Me.lblSunsetSunrise.Name = "lblSunsetSunrise"
        Me.lblSunsetSunrise.Size = New System.Drawing.Size(317, 26)
        Me.lblSunsetSunrise.TabIndex = 30
        Me.lblSunsetSunrise.Text = "Uses sunrise-sunset.org's free API. Many thanks for providing this." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Visit their " &
    "website at"
        Me.lblSunsetSunrise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lnkLblLocation
        '
        Me.lnkLblLocation.AutoSize = True
        Me.lnkLblLocation.Location = New System.Drawing.Point(108, 190)
        Me.lnkLblLocation.Name = "lnkLblLocation"
        Me.lnkLblLocation.Size = New System.Drawing.Size(128, 13)
        Me.lnkLblLocation.TabIndex = 31
        Me.lnkLblLocation.TabStop = True
        Me.lnkLblLocation.Text = "http://sunrise-sunset.org/"
        '
        'lblBrightnessControl
        '
        Me.lblBrightnessControl.AutoSize = True
        Me.lblBrightnessControl.Location = New System.Drawing.Point(12, 142)
        Me.lblBrightnessControl.Name = "lblBrightnessControl"
        Me.lblBrightnessControl.Size = New System.Drawing.Size(328, 26)
        Me.lblBrightnessControl.TabIndex = 32
        Me.lblBrightnessControl.Text = "Uses BrightnessControl © 2015 Alexander Horn. View License terms" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Kindly modified" &
    " by IronRazer of the DreamInCode forums."
        '
        'lnkLblLicense
        '
        Me.lnkLblLicense.AutoSize = True
        Me.lnkLblLicense.Location = New System.Drawing.Point(336, 142)
        Me.lnkLblLicense.Name = "lnkLblLicense"
        Me.lnkLblLicense.Size = New System.Drawing.Size(28, 13)
        Me.lnkLblLicense.TabIndex = 33
        Me.lnkLblLicense.TabStop = True
        Me.lnkLblLicense.Text = "here"
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 212)
        Me.Controls.Add(Me.lnkLblLicense)
        Me.Controls.Add(Me.lblBrightnessControl)
        Me.Controls.Add(Me.lnkLblLocation)
        Me.Controls.Add(Me.lblSunsetSunrise)
        Me.Controls.Add(Me.pBoxLogo)
        Me.Controls.Add(Me.lblChangelog)
        Me.Controls.Add(Me.lblVer)
        Me.Controls.Add(Me.lblTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.TopMost = True
        CType(Me.pBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pBoxLogo As PictureBox
    Friend WithEvents lblChangelog As Label
    Friend WithEvents lblVer As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSunsetSunrise As Label
    Friend WithEvents lnkLblLocation As LinkLabel
    Friend WithEvents lblBrightnessControl As Label
    Friend WithEvents lnkLblLicense As LinkLabel
End Class
