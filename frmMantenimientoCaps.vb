Public Class frmMantenimientoCaps
    Dim dts As New DataSet
    Dim encontrado As Boolean = False

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_control_alimentacion_caps").Rows.Count - 1 Then
            strLinea = dts.Tables("tbl_control_alimentacion_caps").Rows(pos).Item("id_tipo") & vbTab & _
                        dts.Tables("tbl_control_alimentacion_caps").Rows(pos).Item("detalle")
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
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_control_alimentacion_caps").Position + 1 & "/" & BindingContext(dts, "tbl_control_alimentacion_caps").Count

        DesActiva(IIf(BindingContext(dts, "tbl_control_alimentacion_caps").Count = 0, False, True))
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
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_control_alimentacion_caps").Position + 1)
            BindingContext(dts, "tbl_control_alimentacion_caps").Position = IIf(localizado = -1, BindingContext(dts, "tbl_control_alimentacion_caps").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_control_alimentacion_caps").Position = IIf(localizado = -1, BindingContext(dts, "tbl_control_alimentacion_caps").Position, localizado)
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
                BindingContext(dts, "tbl_control_alimentacion_caps").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_control_alimentacion_caps").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_control_alimentacion_caps").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_control_alimentacion_caps").Position = dts.Tables("tbl_control_alimentacion_caps").Rows.Count - 1
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
            Dim strSQL As String = _
                "SELECT id_cap,nombre,identificacion,huella_digital,fecha_inicio,fecha_fin,motivo,beneficio_alimentacion_rrhh" & vbNewLine & _
                "   ,beneficio_aimentacion_rse,dobla_turno,cantidad_dia,id_linea" & vbNewLine & _
                "FROM tbl_control_alimentacion_caps"
            cnx.SQLEXEC(dts, strSQL, "tbl_control_alimentacion_caps")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_control_alimentacion_caps"
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.RowHeadersVisible = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).Visible = False
                DataGridView1.Columns(i).ReadOnly = True
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "NOMBRE"
            DataGridView1.Columns(2).HeaderText = "IDENTIFICACION"
            DataGridView1.Columns(3).HeaderText = "HUELLA_DIGITAL"
            DataGridView1.Columns(4).HeaderText = "CREADO"
            DataGridView1.Columns(5).HeaderText = "FECHA_FIN"
            DataGridView1.Columns(6).HeaderText = "MOTIVO"
            DataGridView1.Columns(7).HeaderText = "BENEFICIO RRHH"
            DataGridView1.Columns(8).HeaderText = "BENEFICIO RSE"
            DataGridView1.Columns(9).HeaderText = "DOBLA TURNO"
            DataGridView1.Columns(10).HeaderText = "CANTIDAD"
            DataGridView1.Columns(11).HeaderText = "ID_LINEA"

            DataGridView1.Columns(0).Width = 60
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(4).Width = 100
            DataGridView1.Columns(7).Width = 75
            DataGridView1.Columns(8).Width = 75
            DataGridView1.Columns(9).Width = 75

            DataGridView1.Columns(0).Visible = True
            DataGridView1.Columns(1).Visible = True
            DataGridView1.Columns(4).Visible = True
            DataGridView1.Columns(7).Visible = True
            DataGridView1.Columns(8).Visible = True
            DataGridView1.Columns(9).Visible = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.Close()
        End Try
    End Sub

    Private Sub frmMantenimientoCaps_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        RegActual()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim obj As New frmMantenimientoCapsDetalle()
        obj.MdiParent = Me.MdiParent
        obj.Owner = Me.Owner
        obj.frmOrigen = Me
        obj.nuevo = False
        obj.dt = dts.Tables("tbl_control_alimentacion_caps")
        obj.dtService = dts.Tables("tbl_control_alimentacion_tipo_servicio")
        obj.pos = BindingContext(dts, "tbl_control_alimentacion_caps").Position
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim obj As New frmMantenimientoCapsDetalle()
        obj.MdiParent = Me.MdiParent
        obj.Owner = Me.Owner
        obj.frmOrigen = Me
        obj.nuevo = True
        obj.dt = dts.Tables("tbl_control_alimentacion_caps")
        obj.dtService = dts.Tables("tbl_control_alimentacion_tipo_servicio")
        obj.StartPosition = FormStartPosition.CenterScreen
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
            If MessageBox.Show("Se dispone a eliminar el registro #" & _
                                dts.Tables("tbl_control_alimentacion_caps").Rows(BindingContext(dts, "tbl_control_alimentacion_caps").Position).Item("MOTIVO") & "." & vbNewLine & _
                                "¿ Esta seguro de proceder ?", "ANULAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            If dts.Tables("tbl_control_alimentacion_caps").Rows.Count = 0 Then
                Exit Sub
            End If
            Dim pos As Integer = BindingContext(dts, "tbl_control_alimentacion_caps").Position
            Dim strSQL As String = _
                "BEGIN TRY" & vbNewLine & _
                "	BEGIN transaction" & vbNewLine & _
                "	SET NOCOUNT ON;" & vbNewLine & _
                "   DECLARE @nDoc AS NUMERIC(18,0)" & vbNewLine & _
                "   SET @nDoc = " & dts.Tables("tbl_control_alimentacion_caps").Rows(pos).Item("id_cap") & vbNewLine & _
                "   INSERT INTO tbl_control_alimentacion_caps_hist(id_cap,nombre,identificacion,huella_digital,fecha_inicio,fecha_fin,motivo,beneficio_alimentacion_rrhh,beneficio_aimentacion_rse,dobla_turno,cantidad_dia,id_linea)" & vbNewLine & _
                "   SELECT id_cap,nombre,identificacion,huella_digital,fecha_inicio,fecha_fin,motivo,beneficio_alimentacion_rrhh,beneficio_aimentacion_rse,dobla_turno,cantidad_dia,id_linea" & vbNewLine & _
                "   FROM  tbl_control_alimentacion_caps" & vbNewLine & _
                "   WHERE id_cap = @nDoc" & vbNewLine & _
                "   " & vbNewLine & _
                "   DELETE FROM tbl_control_alimentacion_caps WHERE id_cap = @nDoc" & vbNewLine & _
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
            dts.Tables("tbl_control_alimentacion_caps").Rows.Clear()
            CargaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub


End Class