Public Class frmImprmir

    Private Sub frmImprmir_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(27) Then
            Close()
        End If
    End Sub
End Class