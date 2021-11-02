Public Class frmEditarMarca
    Public pos As Integer
    Public tabla As String
    Public pnt As Form
    Public dts As DataSet
    Dim estado As String

    Private Sub frmEditarMarca_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
    End Sub

    Private Sub frmEditarMarca_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        BindingContext(dts, tabla).Position = pos
        pnt.Enabled = False
        TextBox1.DataBindings.Add("Text", dts, tabla & ".tipo")
        TextBox2.DataBindings.Add("Text", dts, tabla & ".dia")
        TextBox3.DataBindings.Add("Text", dts, tabla & ".fecha")
        TextBox4.DataBindings.Add("Text", dts, tabla & ".horario")
        TextBox5.DataBindings.Add("Text", dts, tabla & ".marca")
        TextBox6.DataBindings.Add("Text", dts, tabla & ".diferencia")
        TextBox7.DataBindings.Add("Text", dts, tabla & ".circunstancia")
        TextBox8.DataBindings.Add("Text", dts, tabla & ".justificacion")

        estado = IIf(dts.Tables(tabla).Rows(pos).Item("justificacion") = "", "", dts.Tables(tabla).Rows(pos).Item("justificacion"))

    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click

        If estado.Trim <> "" Then
            TextBox8.Text = estado
        End If

        Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Close()
    End Sub
End Class