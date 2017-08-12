Public Class frmAdvanced
    Private Sub frmAdvanced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gBoxExternalProgram.Enabled = cBoxExternalProgram.CheckState
    End Sub

    Private Sub cBoxExternalProgram_CheckedChanged(sender As Object, e As EventArgs) Handles cBoxExternalProgram.CheckedChanged
        gBoxExternalProgram.Enabled = cBoxExternalProgram.CheckState
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If dlgOpenProgram.ShowDialog() = MsgBoxResult.Ok Then
            tBoxPath.Text = dlgOpenProgram.FileName
        End If
    End Sub

    Private Sub btnTest_Click(sender As Object, e As EventArgs) Handles btnTest.Click
        Dim testProcess = New Process
        testProcess.StartInfo = New ProcessStartInfo() With {
        .WorkingDirectory = IO.Path.GetDirectoryName(tBoxPath.Text),
        .FileName = tBoxPath.Text,
        .Arguments = tBoxArg.Text}

        testProcess.Start() 'Run process to kill downloader process and any child processes
    End Sub
End Class