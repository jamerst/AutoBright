<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdvanced
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdvanced))
        Me.cBoxExternalProgram = New System.Windows.Forms.CheckBox()
        Me.gBoxExternalProgram = New System.Windows.Forms.GroupBox()
        Me.tBoxPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.lblArg = New System.Windows.Forms.Label()
        Me.tBoxArg = New System.Windows.Forms.TextBox()
        Me.btnTest = New System.Windows.Forms.Button()
        Me.dlgOpenProgram = New System.Windows.Forms.OpenFileDialog()
        Me.gBoxExternalProgram.SuspendLayout()
        Me.SuspendLayout()
        '
        'cBoxExternalProgram
        '
        Me.cBoxExternalProgram.AutoSize = True
        Me.cBoxExternalProgram.Location = New System.Drawing.Point(12, 12)
        Me.cBoxExternalProgram.Name = "cBoxExternalProgram"
        Me.cBoxExternalProgram.Size = New System.Drawing.Size(197, 17)
        Me.cBoxExternalProgram.TabIndex = 0
        Me.cBoxExternalProgram.Text = "Run external program whilst dimming" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.cBoxExternalProgram.UseVisualStyleBackColor = True
        '
        'gBoxExternalProgram
        '
        Me.gBoxExternalProgram.Controls.Add(Me.btnTest)
        Me.gBoxExternalProgram.Controls.Add(Me.tBoxArg)
        Me.gBoxExternalProgram.Controls.Add(Me.lblArg)
        Me.gBoxExternalProgram.Controls.Add(Me.lblPath)
        Me.gBoxExternalProgram.Controls.Add(Me.btnBrowse)
        Me.gBoxExternalProgram.Controls.Add(Me.tBoxPath)
        Me.gBoxExternalProgram.Enabled = False
        Me.gBoxExternalProgram.Location = New System.Drawing.Point(12, 35)
        Me.gBoxExternalProgram.Name = "gBoxExternalProgram"
        Me.gBoxExternalProgram.Size = New System.Drawing.Size(360, 126)
        Me.gBoxExternalProgram.TabIndex = 1
        Me.gBoxExternalProgram.TabStop = False
        Me.gBoxExternalProgram.Text = "External Program"
        '
        'tBoxPath
        '
        Me.tBoxPath.Location = New System.Drawing.Point(6, 32)
        Me.tBoxPath.Name = "tBoxPath"
        Me.tBoxPath.Size = New System.Drawing.Size(267, 20)
        Me.tBoxPath.TabIndex = 0
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(279, 32)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(6, 16)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(71, 13)
        Me.lblPath.TabIndex = 3
        Me.lblPath.Text = "Program Path"
        '
        'lblArg
        '
        Me.lblArg.AutoSize = True
        Me.lblArg.Location = New System.Drawing.Point(6, 55)
        Me.lblArg.Name = "lblArg"
        Me.lblArg.Size = New System.Drawing.Size(57, 13)
        Me.lblArg.TabIndex = 2
        Me.lblArg.Text = "Arguments"
        '
        'tBoxArg
        '
        Me.tBoxArg.Location = New System.Drawing.Point(6, 71)
        Me.tBoxArg.Name = "tBoxArg"
        Me.tBoxArg.Size = New System.Drawing.Size(348, 20)
        Me.tBoxArg.TabIndex = 4
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(6, 97)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(75, 23)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Test"
        Me.btnTest.UseVisualStyleBackColor = True
        '
        'dlgOpenProgram
        '
        Me.dlgOpenProgram.DefaultExt = "exe"
        Me.dlgOpenProgram.Filter = """Executable Files""|*.exe"
        '
        'frmAdvanced
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 172)
        Me.Controls.Add(Me.gBoxExternalProgram)
        Me.Controls.Add(Me.cBoxExternalProgram)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAdvanced"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Advanced Options"
        Me.gBoxExternalProgram.ResumeLayout(False)
        Me.gBoxExternalProgram.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cBoxExternalProgram As CheckBox
    Friend WithEvents gBoxExternalProgram As GroupBox
    Friend WithEvents lblPath As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents tBoxPath As TextBox
    Friend WithEvents btnTest As Button
    Friend WithEvents tBoxArg As TextBox
    Friend WithEvents lblArg As Label
    Friend WithEvents dlgOpenProgram As OpenFileDialog
End Class
