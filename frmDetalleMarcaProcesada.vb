Public Class frmDetalleMarcaProcesada
    Public pnt As Form
    Public dts As DataSet
    Public idLinea As Integer
    Public pos As Integer

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub frmDetalleMarcaProcesada_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        pnt.Enabled = True
    End Sub

    Private Sub frmDetalleMarcaProcesada_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        pnt.Enabled = False
        Try
            pcbFoto.Image = Image.FromFile("\\SIXAOLA\PLANILLA\PCDATOS\FOTOS\" & txtCodigo.Text.Trim & ".jpg")
        Catch
            pcbFoto.Image = Image.FromFile("\\sixaola\sistemas\sistemas_vb\Iconos\personal2.png")
        End Try
    End Sub

    Private Sub tsbGuardar_Click(sender As System.Object, e As System.EventArgs) Handles tsbGuardar.Click

        If MessageBox.Show("Se dispone a modificar datos de marca del colaborador: " & _
                            txtNombre.Text & "." & vbNewLine & "¿Esta seguro de proceder?", _
                            "GUARDAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        Dim strSQL As String = "UPDATE tbl_marcas_procesadas_act " & vbNewLine & _
                                "SET aplicada = " & IIf(chkAplicado.Checked, 1, 0) & ", " & vbNewLine & _
                                "horasrebajar = " & txtHorasRebajar.Text & ", " & vbNewLine & _
                                "justificacion = '" & txtJustificacion.Text & "' " & vbNewLine & _
                               "WHERE (id_linea = " & idLinea & ")"
        Try
            'dts.Tables("tbl_marcas_procesadas_act").Rows(pos).Item("aplicada") = IIf(chkAplicado.Checked, 1, 0)
            'dts.Tables("tbl_marcas_procesadas_act").Rows(pos).Item("horasrebajar") = txtHorasRebajar.Text
            'dts.Tables("tbl_marcas_procesadas_act").Rows(pos).Item("justificacion") = txtJustificacion.Text
            cnx.SQLEXEC(dts, strSQL, "tbl_marcas_procesadas_act")
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub
End Class