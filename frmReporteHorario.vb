Public Class frmReporteHorario

    Private Function Consulta(ByVal pCodigo As String) As DataTable
        Try
            Dim cnx As New ConexionDB("SAVEGRE\SAVEGRE", "rrhh", "", "", 1)
            Dim dt As New DataTable

            Dim strSQL As String = _
                "SELECT view_sl_empleados.EMPID,view_sl_empleados.NOMBRE" & vbNewLine & _
                "	,tbl_tipo_horario.lunesin,tbl_tipo_horario.lunesout" & vbNewLine & _
                "	,tbl_tipo_horario.martesin,tbl_tipo_horario.martesout" & vbNewLine & _
                "	,tbl_tipo_horario.miercolesin,tbl_tipo_horario.miercolesout" & vbNewLine & _
                "	,tbl_tipo_horario.juevesin,tbl_tipo_horario.juevesout" & vbNewLine & _
                "	,tbl_tipo_horario.viernesin,tbl_tipo_horario.viernesout" & vbNewLine & _
                "	,tbl_tipo_horario.sabadoin,tbl_tipo_horario.sabadoout" & vbNewLine & _
                "	,tbl_tipo_horario.domingoin,tbl_tipo_horario.domingoout" & vbNewLine & _
                "	,tbl_tipo_horario.dia_feriado,tbl_tipo_horario.dia_feriado2" & vbNewLine & _
                "FROM tbl_tipo_horario" & vbNewLine & _
                "	INNER JOIN tbl_horarioxEmpleado ON tbl_tipo_horario.id_horario = tbl_horarioxEmpleado.id_horario" & vbNewLine & _
                "	INNER JOIN view_sl_empleados ON tbl_horarioxEmpleado.empid = view_sl_empleados.EMPID" & vbNewLine & _
                "WHERE (view_sl_empleados.ACTIVO = 'S') AND (view_sl_empleados.EMPID = '" & pCodigo & "')"
            cnx.SQLEXEC(dt, strSQL)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub carga_datos(dt As DataTable)
        Try

            If dt.Rows.Count = 0 Then
                Throw New System.Exception("Error: empleado sin horario asignado.")
            End If

            Dim dtResut As New DataTable

            dtResut.TableName = "result"
            dtResut.Columns.Add("DIA", Type.GetType("System.String"))
            dtResut.Columns.Add("ENTRADA", Type.GetType("System.String"))
            dtResut.Columns.Add("SALIDA", Type.GetType("System.String"))
            dtResut.Columns(0).AllowDBNull = True
            dtResut.Columns(1).AllowDBNull = True
            dtResut.Columns(2).AllowDBNull = True

            dtResut.Rows.Add("LUNES", dt.Rows(0).Item("lunesin"), dt.Rows(0).Item("lunesout"))
            dtResut.Rows.Add("MARTES", dt.Rows(0).Item("martesin"), dt.Rows(0).Item("martesout"))
            dtResut.Rows.Add("MIERCOLES", dt.Rows(0).Item("miercolesin"), dt.Rows(0).Item("miercolesout"))
            dtResut.Rows.Add("JUEVES", dt.Rows(0).Item("juevesin"), dt.Rows(0).Item("juevesout"))
            dtResut.Rows.Add("VIERNES", dt.Rows(0).Item("viernesin"), dt.Rows(0).Item("viernesout"))
            dtResut.Rows.Add("SABADO", dt.Rows(0).Item("sabadoin"), dt.Rows(0).Item("sabadoout"))
            dtResut.Rows.Add("DOMINGO", dt.Rows(0).Item("domingoin"), dt.Rows(0).Item("domingoout"))
            dtResut.Rows.Add("LIBRE", dt.Rows(0).Item("dia_feriado"), dt.Rows(0).Item("dia_feriado2"))

            DataGridView1.DataSource = dtResut

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ' Esta funcion me retorna true si la persona seleccionada tiene horario asignado
    Private Function chequeHorarios(ByRef pCodigo As Integer) As Boolean
        Try
            Dim obj As Object = cnx.SQLEXECESCALAR("select count(*) as existe from tbl_horarioxempleado where empid = " & pCodigo)
            Dim cant As Integer = CType(obj, Integer)
            Dim result As Boolean = IIf(cant = 0, False, True)
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub btnNombre_Click(sender As Object, e As EventArgs) Handles btnNombre.Click
        Try
            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE COLABORADOR"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta = _
                "DECLARE @userid AS VARCHAR(5)" & vbNewLine & _
                "SET @userid = '" & pempID.ToString.Trim & "'" & vbNewLine & _
                "" & vbNewLine & _
                "SELECT E.empID, E.nombre FROM view_sl_empleados AS E WHERE(e.estado_empleado = 'ACT')" & IIf(verTodos, "", " AND (JEFE = @userid)")

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            If Not chequeHorarios(result.Item("empid")) Then
                MessageBox.Show("El empleado: " & result.Item("nombre") & " no tiene horario asignado." & vbNewLine & _
                                "Verifique e intente de nuevo.", "JUSTIFICACIÓN DE MARCAS !!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


            txtNombre.Tag = result.Item("empid")
            txtNombre.Text = result.Item("nombre")

            carga_datos(Consulta(txtNombre.Tag))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class