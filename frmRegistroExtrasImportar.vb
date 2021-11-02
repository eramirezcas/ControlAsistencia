Public Class frmRegistroExtrasImportar
    Public pcant As Integer
    Public dts As New DataSet
    Dim numpago As String = "011114"

    Private Sub frmRegistroExtrasImportar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnImportar.Enabled = IIf(pcant = 0, False, True)
        pctConReg.Visible = IIf(pcant = 0, False, True)
        pctSinReg.Visible = IIf(pcant = 0, True, False)
        Label1.Text = IIf(pcant = 0, "RRHH no a aprobado, no hay registros para importar.", _
                                    "Se van a importar " & pcant.ToString.Trim & " registros de horas extra.")

    End Sub

    Private Sub btnImportar_Click(sender As System.Object, e As System.EventArgs) Handles btnImportar.Click
        Try
            'Dim pnt As New frmNumPago()
            'pnt.btnCargar.Text = "&Importar"
            'If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            '    numpago = pnt.encPago
            'Else
            '    pnt.Close()
            '    Exit Sub
            'End If
            'pnt.Close()

            If MessageBox.Show("Se dispone a importar registros de horas extra." & vbNewLine & _
                               "¿ Seguro de proceder ?", "IMPORTAR DATOS !!!", MessageBoxButtons.YesNo, _
                               MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim strSQL As String = "SELECT * FROM tbl_Extras WHERE estatus_nivel = 3"
            cnx.SQLEXEC(dts, strSQL, "tbl_extras")

            gbProgreso.Minimum = 0
            gbProgreso.Maximum = dts.Tables("tbl_extras").Rows.Count - 1
            gbProgreso.Visible = True
            For i = 0 To dts.Tables("tbl_extras").Rows.Count - 1

                Dim pDetalleBitacora As String = "APROBACIÓN DE PLANILLA REALIZADA CON ÉXITO POR " & pNombreUser
                Dim motivoRechazo As String = "NULL"
                Dim estatusNivel As Integer = 4
                Dim estatus As String = "'APROBACION DE PLANILLA REALIZADA'"

                strSQL = _
                    "BEGIN TRY" & vbNewLine & _
                    "	BEGIN TRANSACTION" & vbNewLine & _
                    "	SET NOCOUNT ON;" & vbNewLine & _
                    "	" & vbNewLine & _
                    "   UPDATE tbl_Extras SET" & vbNewLine & _
                    "   	  fecha_aplica_plani = GETDATE()" & vbNewLine & _
                    "       , motivo_rechazo_planilla = " & motivoRechazo & vbNewLine & _
                    "   	, estatus = " & estatus & vbNewLine & _
                    "   	, estatus_nivel = " & estatusNivel & vbNewLine & _
                    "       , numero_pago = '" & numpago & "'" & vbNewLine & _
                    "   WHERE (id_linea = " & dts.Tables("tbl_extras").Rows(i).Item("ID_LINEA") & ")" & vbNewLine & _
                    "   " & vbNewLine & _
                    "   INSERT INTO tbl_extras_bitacora(nDocumento, nivel_estado, estado, detalle, fecha, computername, username)" & vbNewLine & _
                    "   VALUES (" & vbNewLine & _
                    "        " & dts.Tables("tbl_Extras").Rows(i).Item("nDocumento") & vbNewLine & _
                    "      , " & estatusNivel & vbNewLine & _
                    "      ," & estatus & vbNewLine & _
                    "      ,'" & pDetalleBitacora & " [" & motivoRechazo & "]'" & vbNewLine & _
                    "      , getDate()" & vbNewLine & _
                    "      ,'" & Environment.MachineName.ToUpper.Trim & "'" & vbNewLine & _
                    "      ,'" & Environment.UserName.ToUpper.Trim & "'" & vbNewLine & _
                    "      )" & vbNewLine & _
                    "	" & vbNewLine & _
                    "END TRY" & vbNewLine & _
                    "BEGIN CATCH" & vbNewLine & _
                    "	IF @@TRANCOUNT > 0" & vbNewLine & _
                    "		ROLLBACK TRANSACTION;" & vbNewLine & _
                    "		DECLARE @ErrorMessage NVARCHAR(4000);" & vbNewLine & _
                    "		DECLARE @ErrorSeverity INT;" & vbNewLine & _
                    "		DECLARE @ErrorState INT;" & vbNewLine & _
                    "		" & vbNewLine & _
                    "		SET @ErrorMessage = ERROR_MESSAGE()" & vbNewLine & _
                    "		SET @ErrorSeverity = ERROR_SEVERITY()" & vbNewLine & _
                    "		SET @ErrorState = ERROR_STATE();" & vbNewLine & _
                    "		" & vbNewLine & _
                    "	    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);" & vbNewLine & _
                    "END CATCH;" & vbNewLine & _
                    "IF @@TRANCOUNT > 0" & vbNewLine & _
                    "	COMMIT TRANSACTION;"

                cnx.SQLEXEC(dts, strSQL, "tbl_extras")

                gbProgreso.Value = i
            Next
            gbProgreso.Visible = False
            MessageBox.Show("Proceso realizado con éxito", "IMPORTAR DATOS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class