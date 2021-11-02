Public Class FrmCambioCalve
#Region "Variables"
    Dim dt As New DataTable

#End Region

    Private Sub FrmCambioCalve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cnx.SQLEXEC(dt, "Select * from tbl_control_asistencia_usuarios where empid =" & pempID & "")
            txtClaveAnterior.Text = "**************************"
            txtClaveAnterior.Tag = dt.Rows(0).Item("clave")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If txtClaveAnterior.Text = "" Or txtClaveNueva.Text = "" Or txtConfirmaClaveNueva.Text = "" Then
                MessageBox.Show("Faltan datos en la forma. Verifique e intente de nuevo.", "CAMBIO DE CLAVE !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If txtClaveNueva.Text <> txtConfirmaClaveNueva.Text Then
                MessageBox.Show("La clave nueva y la confirmacion son diferentes.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If txtClaveNueva.Text = txtClaveAnterior.Tag Then
                MessageBox.Show("La clave nueva y la actual deben ser diferentes.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If MessageBox.Show("Se dispone a realizar el cambio de clave. ¿Seguro de proceder?", "CAMBIO DE CLAVE !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            cnx.SQLEXEC("UPDATE tbl_control_asistencia_usuarios SET clave = '" & txtClaveNueva.Text & "' WHERE (empid = " & pempID & ")")

            MessageBox.Show("Proceso realizado con éxito.", "CAMBIO DE CLAVE !!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try

    End Sub

    Private Sub btnDescartar_Click(sender As System.Object, e As System.EventArgs) Handles btnDescartar.Click
        Close()
    End Sub
End Class