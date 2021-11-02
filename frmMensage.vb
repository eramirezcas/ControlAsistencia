Public Class frmMensage

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click, Button2.Click
        Dim obj As Button = CType(sender, Button)
        Select Case obj.Text
            Case "Si"
                DialogResult = Windows.Forms.DialogResult.Yes
            Case "No"
                DialogResult = Windows.Forms.DialogResult.No
        End Select
    End Sub
End Class