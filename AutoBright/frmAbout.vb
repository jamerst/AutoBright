Public Class frmAbout
    Private Sub lnkLblLocation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLblLocation.LinkClicked
        lnkLblLocation.LinkVisited = True
        System.Diagnostics.Process.Start("http://sunrise-sunset.org/")
    End Sub

    Private Sub lnkLblLicense_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkLblLicense.LinkClicked
        lnkLblLicense.LinkVisited = True
        System.Diagnostics.Process.Start("https://github.com/alexhorn/BrightnessControl/blob/master/LICENSE")
    End Sub
End Class