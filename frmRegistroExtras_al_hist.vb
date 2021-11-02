Public Class frmRegistroExtras_al_hist

    Dim dts As New DataSet()

    Private Sub frmRegistroExtras_al_hist_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            GroupBox1.Visible = False
            GroupBox2.Visible = False
            GroupBox3.Visible = False

            Dim strSQL As String =
                "SELECT" & vbNewLine &
                    "(SELECT COUNT(*) AS cant FROM tbl_extras) as REGISTROS," & vbNewLine &
                    "(SELECT NUMPAGO FROM SCGPLACRCC.DBO.SCGPL_ENCABEZADO_PAGO" & vbNewLine &
                    " WHERE (NUMPAGO = (SELECT DISTINCT numpago COLLATE DATABASE_DEFAULT FROM tbl_marcas_justificadas_act))" & vbNewLine &
                    ") AS NUMPAGO," & vbNewLine &
                    "(SELECT FECHADESDE FROM SCGPLACRCC.DBO.SCGPL_ENCABEZADO_PAGO" & vbNewLine &
                    " WHERE (NUMPAGO = (SELECT DISTINCT numpago COLLATE DATABASE_DEFAULT FROM tbl_marcas_justificadas_act))" & vbNewLine &
                    ") AS FECHAINICIAL," & vbNewLine &
                    "(SELECT FECHAHASTA FROM SCGPLACRCC.DBO.SCGPL_ENCABEZADO_PAGO" & vbNewLine &
                    " WHERE (NUMPAGO = (SELECT DISTINCT numpago COLLATE DATABASE_DEFAULT FROM tbl_marcas_justificadas_act))" & vbNewLine &
                    ") AS FECHAFINAL"
            cnx.SQLEXEC(dts, strSQL, "tblResult")

            If dts.Tables("tblResult").Rows(0).Item("Registros") = 0 Then
                GroupBox2.Visible = True
                btnGuardar.Enabled = False
                Exit Sub
            End If

            txtRegistros.Text = dts.Tables("tblResult").Rows(0).Item("Registros")
            txtNumpago.Text = IIf(IsDBNull(dts.Tables("tblResult").Rows(0).Item("numpago")), "", dts.Tables("tblResult").Rows(0).Item("numpago"))
            txtFechaInicial.Text = IIf(IsDBNull(dts.Tables("tblResult").Rows(0).Item("fechainicial")), "", dts.Tables("tblResult").Rows(0).Item("fechainicial"))
            txtFechaFinal.Text = IIf(IsDBNull(dts.Tables("tblResult").Rows(0).Item("fechafinal")), "", dts.Tables("tblResult").Rows(0).Item("fechafinal"))
            GroupBox1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub btnDescartar_Click(sender As System.Object, e As System.EventArgs) Handles btnDescartar.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MessageBox.Show("Se dispone a realizar el cierre de extras." & vbNewLine & vbNewLine & _
                               "Planilla #" & dts.Tables("tblResult").Rows(0).Item("numpago") & "." & vbNewLine & vbNewLine & _
                               "¿Seguro de proceder?", "CIERRE DE EXTRAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim strSQL As String = _
                "BEGIN TRY" & vbNewLine & _
                "	BEGIN TRANSACTION" & vbNewLine & _
                "	SET NOCOUNT ON" & vbNewLine & _
                "	" & vbNewLine & _
                "	INSERT INTO tbl_Extras_hist" & vbNewLine & _
                "	SELECT id_linea, nDocumento, empID, nombre_empleado, id_Departamento, nombre_departamento, id_Seccion," & vbNewLine & _
                "		nombre_seccion, Salario_Hora, Fecha, marca_entrada, horario_entrada, marca_salida, horario_salida," & vbNewLine & _
                "		diferencia_entrada, diferencia_salida, estado_marca, cantidad_horas_sencillas, cantidad_horas_tmedio," & vbNewLine & _
                "		cantidad_horas_dobles, cantidad_horas_feriado, Monto_Total, justificacion_automatica, estatus," & vbNewLine & _
                "		estatus_nivel, Motivo, CuentaContCosto, CuentaContPresu, empid_jefe, nombre_jefe, fecha_aplica_jefe," & vbNewLine & _
                "		empID_gerente, nombre_gerente, fecha_aplica_gerente, motivo_rechazo_gerente, empID_rh, nombre_rh," & vbNewLine & _
                "		fecha_aplica_rh, motivo_rechazo_rh, fecha_aplica_plani, motivo_rechazo_planilla, numero_pago," & vbNewLine & _
                "		fecha_cierre, Id_Uduario, ComputerName, UserName, time_stamp" & vbNewLine & _
                "	FROM tbl_Extras" & vbNewLine & _
                "	" & vbNewLine & _
                "	INSERT INTO tbl_extras_bitacora_hist" & vbNewLine & _
                "	SELECT id_linea, nDocumento, nivel_estado, estado, detalle, fecha, computername, username" & vbNewLine & _
                "	FROM tbl_extras_bitacora" & vbNewLine & _
                "	" & vbNewLine & _
                "	DELETE FROM TBL_EXTRAS" & vbNewLine & _
                "	DELETE FROM tbl_extras_bitacora" & vbNewLine & _
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

            '"INSERT INTO tbl_marcas_procesadas_hist(aplicada, justificada, codigo, nombre, entrada, horaentra, horasrebajar, salida, detalle1, detalle2, id_interno, id_procesado, justificacion, fechacal, numpago, id_linea, id_horario, id_horario_sale)" & vbNewLine & _
            '"SELECT aplicada, justificada, codigo, nombre, entrada, horaentra, horasrebajar, salida, detalle1, detalle2, id_interno, id_procesado, justificacion, fechacal, numpago, id_linea, id_horario, id_horario_sale" & vbNewLine & _
            '"FROM tbl_marcas_procesadas_act" & vbNewLine & vbNewLine & _
            '"DELETE FROM tbl_marcas_procesadas_act"

            cnx.SQLEXEC(strSQL)
            GroupBox1.Visible = False
            GroupBox3.Visible = True
            btnGuardar.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

End Class