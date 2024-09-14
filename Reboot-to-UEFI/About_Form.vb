Public Class About_Form
    Private Sub About_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Allow form to handle key presses
        Me.KeyPreview = True
        ' Set form text
        Me.Text = "About " + Application.ProductName
        ' Display app title and version
        Label_AppTitle.Text = Application.ProductName + "  " + Application.ProductVersion.ToString()
    End Sub

    Private Sub LinkLabel_Dev_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_Dev.LinkClicked
        Process.Start("https://" + LinkLabel_Dev.Text)
    End Sub

    Private Sub LinkLabel_Homepage_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel_Homepage.LinkClicked
        Process.Start("https://" + LinkLabel_Homepage.Text)
    End Sub

    Private Sub PictureBox_gustech_Click(sender As Object, e As EventArgs) Handles PictureBox_gustech.Click
        Process.Start("https://" + LinkLabel_Dev.Text)
    End Sub

    Private Sub About_Form_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        'MessageBox.Show(AscW(e.KeyChar))
        ' Close form if escape pressed
        If e.KeyChar = Chr(27) Then
            Me.Close()
        End If
    End Sub

End Class