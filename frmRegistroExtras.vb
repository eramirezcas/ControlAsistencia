Public Class frmRegistroExtras

    Dim dts As New DataSet()
    Dim encontrado As Boolean = False

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_Extras").Rows.Count - 1 Then
            strLinea = dts.Tables("tbl_Extras").Rows(pos).Item("nDocumento") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("empID") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_empleado") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_seccion") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("Fecha")
        Else
            encontrado = False
            Return -1
        End If
        If (InStr(strLinea.ToUpper, dato.ToUpper) = 0) Then
            Return Localizar(dato, pos + 1)
        Else
            Return pos
        End If

    End Function

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_Extras").Position + 1 & "/" & BindingContext(dts, "tbl_Extras").Count

        DesActiva(IIf(BindingContext(dts, "tbl_Extras").Count = 0, False, True))
        'For i = 0 To DataGridView1.Rows.Count - 1
        '    DataGridView1.Rows(i).DefaultCellStyle.BackColor = IIf(DataGridView1.Rows(i).Cells(24).Value = False, Color.LightGray, Color.White)
        'Next
    End Sub

    Private Sub DesActiva(ByVal pActiva As Boolean)
        GroupBox1.Enabled = pActiva
        DataGridView1.Enabled = pActiva
        btnEditar.Enabled = pActiva
        btnImprimir.Enabled = pActiva
        btnExcel.Enabled = pActiva
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_Extras").Position + 1)
            BindingContext(dts, "tbl_Extras").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Extras").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_Extras").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Extras").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub tsbPrimero_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrimero.Click, tsbAnterior.Click, tsbUltimo.Click, tsbSiguiente.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dts, "tbl_Extras").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_Extras").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_Extras").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_Extras").Position = dts.Tables("tbl_Extras").Rows.Count - 1
        End Select
    End Sub

    Private Sub DataGridView_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        RegActual()
    End Sub

    Private Sub txtLocalizar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLocalizar.PerformClick()
        End If
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub

    Public Sub CargaGrid()
        Try
            Dim strSQL As String = "SELECT id_linea, nDocumento, empID, nombre_empleado, id_Departamento, nombre_departamento," & vbNewLine & _
                                   "	id_Seccion, nombre_seccion, Salario_Hora, Fecha," & vbNewLine & _
                                   "	CASE WHEN marca_entrada = CONVERT(DATETIME,'',103) THEN NULL ELSE marca_entrada END AS marca_entrada," & vbNewLine & _
                                   "	CASE WHEN horario_entrada = CONVERT(DATETIME,'',103) THEN NULL ELSE horario_entrada END AS horario_entrada," & vbNewLine & _
                                   "	CASE WHEN marca_salida = CONVERT(DATETIME,'',103) THEN NULL ELSE marca_salida END AS marca_salida," & vbNewLine & _
                                   "	CASE WHEN horario_salida = CONVERT(DATETIME,'',103) THEN NULL ELSE horario_salida END AS horario_salida," & vbNewLine & _
                                   "	diferencia_entrada, diferencia_salida, estado_marca, cantidad_horas_sencillas," & vbNewLine & _
                                   "	cantidad_horas_tmedio, cantidad_horas_dobles, cantidad_horas_feriado, Monto_Total," & vbNewLine & _
                                   "	justificacion_automatica, estatus, estatus_nivel, Motivo, CuentaContCosto, CuentaContPresu," & vbNewLine & _
                                   "	empid_jefe, nombre_jefe, fecha_aplica_jefe, empID_gerente, nombre_gerente, fecha_aplica_gerente, motivo_rechazo_gerente," & vbNewLine & _
                                   "	empID_rh, nombre_rh, fecha_aplica_rh, motivo_rechazo_rh, fecha_aplica_plani, motivo_rechazo_planilla, numero_pago, fecha_cierre, Id_Uduario," & vbNewLine & _
                                   "	ComputerName, UserName, time_stamp" & vbNewLine & _
                                   "FROM tbl_Extras" & vbNewLine & _
                                   "WHERE (estatus_nivel = 0)" & IIf(verTodos, "", " AND (empID in (select empid from tbl_empleados_sap as E where " & IIf(pEsGerente, "E.empid_gerente", "E.empid_jefe") & " = " & pempID & "))") & vbNewLine & _
                                   "ORDER BY nombre_departamento, nombre_seccion, empID"

            If Not IsNothing(dts.Tables("tbl_Extras")) Then
                dts.Tables("tbl_Extras").Clear()
            End If
            cnx.SQLEXEC(dts, strSQL, "tbl_Extras")

            dts.Tables("tbl_Extras").Columns("salario_hora").DefaultValue = 0
            dts.Tables("tbl_Extras").Columns("diferencia_entrada").DefaultValue = 0
            dts.Tables("tbl_Extras").Columns("diferencia_Salida").DefaultValue = 0
            dts.Tables("tbl_Extras").Columns("cantidad_horas_sencillas").DefaultValue = 0
            dts.Tables("tbl_Extras").Columns("cantidad_horas_tmedio").DefaultValue = 0
            dts.Tables("tbl_Extras").Columns("cantidad_horas_dobles").DefaultValue = 0
            dts.Tables("tbl_Extras").Columns("cantidad_horas_feriado").DefaultValue = 0

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_Extras"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.ReadOnly = True
            DataGridView1.RowHeadersVisible = False
            DataGridView1.Font = New Font("Arial", 7, FontStyle.Regular)

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).Visible = False
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(1).HeaderText = "#DOC"
            DataGridView1.Columns(2).HeaderText = "Código"
            DataGridView1.Columns(3).HeaderText = "Nombre"
            DataGridView1.Columns(5).HeaderText = "Departamento"
            DataGridView1.Columns(7).HeaderText = "Sección"
            DataGridView1.Columns(9).HeaderText = "Fecha"
            DataGridView1.Columns(17).HeaderText = "Sencillas"
            DataGridView1.Columns(18).HeaderText = "Estras"
            DataGridView1.Columns(19).HeaderText = "Dobles"
            DataGridView1.Columns(20).HeaderText = "Feriado"
            DataGridView1.Columns(22).HeaderText = "Justificación automática"
            DataGridView1.Columns(25).HeaderText = "Motivo"

            DataGridView1.Columns(1).Width = 40
            DataGridView1.Columns(2).Width = 50
            DataGridView1.Columns(3).Width = 160
            DataGridView1.Columns(5).Width = 100
            DataGridView1.Columns(7).Width = 100
            DataGridView1.Columns(9).Width = 70
            DataGridView1.Columns(17).Width = 50
            DataGridView1.Columns(18).Width = 50
            DataGridView1.Columns(19).Width = 50
            DataGridView1.Columns(20).Width = 50
            DataGridView1.Columns(22).Width = 220
            DataGridView1.Columns(25).Width = 190

            DataGridView1.Columns(1).DisplayIndex = 0
            DataGridView1.Columns(2).DisplayIndex = 1
            DataGridView1.Columns(3).DisplayIndex = 2
            DataGridView1.Columns(9).DisplayIndex = 3
            DataGridView1.Columns(25).DisplayIndex = 4
            DataGridView1.Columns(22).DisplayIndex = 5
            DataGridView1.Columns(17).DisplayIndex = 6
            DataGridView1.Columns(18).DisplayIndex = 7
            DataGridView1.Columns(19).DisplayIndex = 8
            DataGridView1.Columns(20).DisplayIndex = 9
            DataGridView1.Columns(5).DisplayIndex = 10
            DataGridView1.Columns(7).DisplayIndex = 11

            DataGridView1.Columns(1).Visible = True
            DataGridView1.Columns(2).Visible = True
            DataGridView1.Columns(3).Visible = True
            DataGridView1.Columns(5).Visible = True
            DataGridView1.Columns(7).Visible = True
            DataGridView1.Columns(9).Visible = True
            DataGridView1.Columns(17).Visible = True
            DataGridView1.Columns(18).Visible = True
            DataGridView1.Columns(19).Visible = True
            DataGridView1.Columns(20).Visible = True
            DataGridView1.Columns(22).Visible = True
            DataGridView1.Columns(25).Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub frmRegistroExtras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        RegActual()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim obj As New frmRegistroExtrasDetalle()
        obj.pnt = Me
        obj.MdiParent = Me.MdiParent
        obj.nuevo = False
        obj.dts = dts
        obj.tabla = "tbl_Extras"
        obj.pos = BindingContext(dts, "tbl_Extras").Position
        obj.Show()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim obj As New frmRegistroExtrasDetalle()
        obj.pnt = Me
        obj.MdiParent = Me.MdiParent
        obj.nuevo = True
        dts.Tables("tbl_Extras").Rows.Add()
        BindingContext(dts, "tbl_Extras").Position = dts.Tables("tbl_Extras").Rows.Count - 1
        dts.Tables("tbl_Extras").Rows(BindingContext(dts, "tbl_Extras").Position).BeginEdit()
        obj.pos = BindingContext(dts, "tbl_Extras").Position
        obj.dts = dts
        obj.tabla = "tbl_Extras"
        obj.Show()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        btnEditar.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        btnSalir.PerformClick()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        'Dim pntexcel As New frmExeleador()
        'Dim strSQL As String = _
        '    "SELECT" & vbNewLine & _
        '    "	(SELECT detalle from tbl_departamentos where id_departamento = a.id_departamento) as departamento," & vbNewLine & _
        '    "	(SELECT detalle from tbl_secciones where id_seccion = a.id_seccion) as seccion, a.id_puesto," & vbNewLine & _
        '    "	a.empID, a.middleName, a.lastName, a.firstName, a.cedula, a.Nacionalidad, a.fecha_nacimiento," & vbNewLine & _
        '    "	a.telefono1, a.telefono2, a.email, a.marca_reloj, a.centrobeneficio, a.seccion_sap, a.puesto_sap," & vbNewLine & _
        '    "	a.id_departamento, a.id_seccion, a.id_puesto, a.fecha_ingreso, a.jefe_departamento, a.jefe_seccion," & vbNewLine & _
        '    "	a.saldo_vacaciones, a.saldo_vacaciones_anterior, a.dias_mes, a.bonificacion, a.activo, a.SalarioHora," & vbNewLine & _
        '    "	a.SalarioMes, a.FormaPago, a.gerente, a.fecha_renuncia, a.fecha_actualizacion, a.usuario_actualizacion," & vbNewLine & _
        '    "	a.cantDiasBon, a.id_banco, a.id_tipo_cuenta, a.numero_cuenta, a.numero_cuenta_cliente, a.id_tipo_pago," & vbNewLine & _
        '    "	a.SalarioMesReal, a.horasMesReal, a.comentarios, a.evalua," & vbNewLine & _
        '    "   CASE WHEN MONTH(a.fecha_ingreso) <= MONTH(GETDATE()) THEN YEAR(GETDATE()) - YEAR(a.fecha_ingreso)" & vbNewLine & _
        '    "	    ELSE (YEAR(GETDATE())-1) - YEAR(a.fecha_ingreso) END AS anos_laborados, a.direccion" & vbNewLine & _
        '    "FROM tbl_empleados_sap AS a WHERE activo = " & IIf(cboDesActivo.Text = "ACTIVOS", 1, 0) & " ORDER BY 1,2"
        'Dim EXEC As String = cnx.SQLEXEC(dts, strSQL, "QTMP_XLS")
        'pntexcel.dts = dts
        'pntexcel.tabla = "QTMP_XLS"
        'pntexcel.titulo = "LISTADO DE COLABORADORES " & cboDesActivo.Text
        'pntexcel.filtro = ""
        ''pntexcel.MdiParent = Me.MdiParent
        'pntexcel.frmAnterior = Me
        'Dim xtmp As DialogResult = pntexcel.ShowDialog()
        'dts.Tables.Remove("QTMP_XLS")
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Try
            If MessageBox.Show("Se dispone a anular el documento #" & _
                                dts.Tables("tbl_extras").Rows(BindingContext(dts, "tbl_Extras").Position).Item("nDocumento") & "." & vbNewLine & _
                                "¿ Esta seguro de proceder ?", "ANULAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim strSQL As String = _
                "BEGIN TRY" & vbNewLine & _
                "	BEGIN transaction" & vbNewLine & _
                "	SET NOCOUNT ON;" & vbNewLine & _
                "   DECLARE @nDoc AS NUMERIC(18,0)" & vbNewLine & _
                "   SET @nDoc = " & dts.Tables("tbl_extras").Rows(BindingContext(dts, "tbl_Extras").Position).Item("id_linea") & vbNewLine & _
                "   INSERT INTO tbl_extras_hist(id_linea, nDocumento, empID, nombre_empleado, id_Departamento," & vbNewLine & _
                "	    nombre_departamento, id_Seccion, nombre_seccion, Salario_Hora, Fecha, marca_entrada," & vbNewLine & _
                "	    horario_entrada, marca_salida, horario_salida, diferencia_entrada, diferencia_salida," & vbNewLine & _
                "	    estado_marca, cantidad_horas_sencillas, cantidad_horas_tmedio, cantidad_horas_dobles," & vbNewLine & _
                "	    cantidad_horas_feriado, Monto_Total, justificacion_automatica, estatus, estatus_nivel," & vbNewLine & _
                "	    Motivo, CuentaContCosto, CuentaContPresu, empid_jefe, nombre_jefe, fecha_aplica_jefe," & vbNewLine & _
                "	    empID_gerente, nombre_gerente, fecha_aplica_gerente, empID_rh, nombre_rh, fecha_aplica_rh," & vbNewLine & _
                "	    fecha_aplica_plani, numero_pago, fecha_cierre, Id_Uduario, ComputerName, UserName, time_stamp)" & vbNewLine & _
                "   SELECT id_linea, nDocumento, empID, nombre_empleado, id_Departamento, nombre_departamento," & vbNewLine & _
                "       id_Seccion, nombre_seccion, Salario_Hora, Fecha, marca_entrada, horario_entrada," & vbNewLine & _
                "   	marca_salida, horario_salida, diferencia_entrada, diferencia_salida, estado_marca," & vbNewLine & _
                "   	cantidad_horas_sencillas, cantidad_horas_tmedio, cantidad_horas_dobles, cantidad_horas_feriado," & vbNewLine & _
                "   	Monto_Total, 'ANULADA' AS justificacion_automatica, estatus, estatus_nivel, Motivo, CuentaContCosto," & vbNewLine & _
                "   	CuentaContPresu, empid_jefe, nombre_jefe, fecha_aplica_jefe, empID_gerente, nombre_gerente," & vbNewLine & _
                "   	fecha_aplica_gerente, empID_rh, nombre_rh, fecha_aplica_rh, fecha_aplica_plani, numero_pago," & vbNewLine & _
                "   	fecha_cierre, Id_Uduario, ComputerName, UserName, time_stamp" & vbNewLine & _
                "   FROM tbl_Extras WHERE (id_linea = @nDoc)" & vbNewLine & _
                "   INSERT INTO tbl_extras_bitacora(nDocumento, nivel_estado, estado, detalle, fecha, computername, username)" & vbNewLine & _
                "   VALUES (" & vbNewLine & _
                "         " & dts.Tables("tbl_Extras").Rows(BindingContext(dts, "tbl_Extras").Position).Item("nDocumento") & vbNewLine & _
                "       , " & dts.Tables("tbl_Extras").Rows(BindingContext(dts, "tbl_Extras").Position).Item("estatus_nivel") & vbNewLine & _
                "       ,'" & dts.Tables("tbl_Extras").Rows(BindingContext(dts, "tbl_Extras").Position).Item("estatus") & "'" & vbNewLine & _
                "       ,'DOCUMENTO ELIMINADO POR " & pNombreUser & "'" & vbNewLine & _
                "       , getDate()" & vbNewLine & _
                "       ,'" & Environment.MachineName.ToUpper.Trim & "'" & vbNewLine & _
                "       ,'" & Environment.UserName.ToUpper.Trim & "'" & vbNewLine & _
                "   )" & vbNewLine & _
                "   INSERT INTO tbl_extras_bitacora_hist(id_linea, nDocumento, nivel_estado, estado, detalle, fecha, computername, username)" & vbNewLine & _
                "   SELECT id_linea, nDocumento, nivel_estado, estado, detalle, fecha, computername, username" & vbNewLine & _
                "   FROM tbl_extras_bitacora WHERE (nDocumento = " & dts.Tables("tbl_extras").Rows(BindingContext(dts, "tbl_Extras").Position).Item("nDocumento") & ")" & vbNewLine & _
                "   DELETE FROM tbl_Extras WHERE (id_linea = @nDoc)" & vbNewLine & _
                "   DELETE FROM tbl_extras_bitacora WHERE (nDocumento = " & dts.Tables("tbl_extras").Rows(BindingContext(dts, "tbl_Extras").Position).Item("nDocumento") & ")" & vbNewLine & _
                "END TRY" & vbNewLine & _
                "BEGIN CATCH" & vbNewLine & _
                "	IF @@TRANCOUNT > 0" & vbNewLine & _
                "		ROLLBACK TRANSACTION;" & vbNewLine & _
                "		DECLARE @ErrorMessage NVARCHAR(4000);" & vbNewLine & _
                "		DECLARE @ErrorSeverity INT;" & vbNewLine & _
                "		DECLARE @ErrorState INT;" & vbNewLine & _
                "" & vbNewLine & _
                "		SET @ErrorMessage = ERROR_MESSAGE()" & vbNewLine & _
                "		SET @ErrorSeverity = ERROR_SEVERITY()" & vbNewLine & _
                "		SET @ErrorState = ERROR_STATE();" & vbNewLine & _
                "" & vbNewLine & _
                "	    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);" & vbNewLine & _
                "END CATCH;" & vbNewLine & _
                "IF @@TRANCOUNT > 0" & vbNewLine & _
                "	COMMIT TRANSACTION;"

            cnx.SQLEXEC(strSQL)

            CargaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

End Class