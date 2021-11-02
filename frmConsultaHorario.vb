Public Class frmConsultaHorario
    Public pnt As Form
    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub frmConsultaHorario_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
    End Sub

    Private Sub frmConsultaHorario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = pnt.MdiParent
        pnt.Enabled = False
    End Sub
End Class