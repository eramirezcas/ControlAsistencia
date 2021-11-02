Public Class FrmReporteMarcas
#Region "Variables"
    Public dtsForm As New DataSet
    Public codigo As String
    Public nombre As String
    Dim Tabla As String = "tbl_marcas_tmp"
    Dim encontrado As Boolean = False
    Dim valor = 2
    Dim prueba As String
#End Region

    Public Sub cargaforma(ByRef pantallas As Object)
        Dim obj As Object = CType(pantallas, Form)
        obj.MdiParent = Me.MdiParent
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Public Sub CargaGrid()
        Try
            Dim strSQL As String = "use rrhh" & vbNewLine & _
                                    "SET LANGUAGE SPANISH" & vbNewLine & _
                                    "" & vbNewLine & _
                                    "SELECT codigo as Codigo, nombre as Nombre, entrada as Hora_Entrada, salida as Hora_Salida," & vbNewLine & _
                                    "   detalle1 AS Detalle_Entrada, detalle2 AS Detalle_Salida,ubicacion_entra,ubicacion_salida," & vbNewLine & _
                                    "   CASE WHEN round((convert(float,salida,103) - convert(float,entrada,103))*24,2) IS NULL" & vbNewLine & _
                                    "	    THEN 0" & vbNewLine & _
                                    "	    ELSE round((convert(float,salida,103) - convert(float,entrada,103))*24,2)" & vbNewLine & _
                                    "   END as Horas_Laboradas, tipo_marca_entrda, tipo_marca_salida" & vbNewLine & _
                                    "FROM tbl_marcas" & vbNewLine & _
                                    "WHERE rtrim(ltrim(codigo)) = '" & codigo & "' AND (timeStamp BETWEEN convert(datetime,'" & dtpInicio.Value.Date & "',103) AND convert(datetime,'" & dtpFinal.Value.Date & "' + ' 23:59:59',103))" & vbNewLine & _
                                    "order by timeStamp asc"

            cnx.SQLEXEC(dtsForm, strSQL, "tbl_marcas_tmp")

            dgvHorarios.DataSource = dtsForm
            dgvHorarios.DataMember = "tbl_marcas_tmp"

            dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvHorarios.AllowUserToAddRows = False
            dgvHorarios.AllowUserToResizeColumns = False
            dgvHorarios.AllowUserToDeleteRows = False
            dgvHorarios.AllowUserToResizeRows = False
            dgvHorarios.MultiSelect = False
            dgvHorarios.ReadOnly = True
            dgvHorarios.RowHeadersVisible = False

            dgvHorarios.Columns(0).Visible = False
            dgvHorarios.Columns(1).Visible = False
            dgvHorarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            dgvHorarios.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvHorarios.Columns(8).DefaultCellStyle.Format = "n"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub bloquear(ByVal opbloqueo As Boolean)
        btnImprimir.Enabled = opbloqueo
        btnExcel.Enabled = opbloqueo
        'BtnFiltar.Enabled = opbloqueo
        btnLimpiar.Enabled = opbloqueo
        btnConsultar.Enabled = Not opbloqueo
        lblNombre.Enabled = Not opbloqueo
    End Sub

    Private Sub fechas(ByVal opfecha As Boolean)
        dtpInicio.Enabled = opfecha
        dtpFinal.Enabled = opfecha
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click

        If txtNombre.Text = "" Then
            MessageBox.Show("Faltan Datos en la Forma", "Datos en la Forma", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If dtpInicio.Value > dtpFinal.Value Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la fecha Final", "CONSULTANDO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        nombre = txtNombre.Text
        codigo = txtEpmID.Text
        CargaGrid()
        bloquear(True)
        fechas(False)

    End Sub

    Private Sub lblNombre_Click(sender As System.Object, e As System.EventArgs) Handles lblNombre.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE COLABORADOR"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = _
            "DECLARE @userid AS VARCHAR(5)" & vbNewLine & _
            "SET @userid = '" & pempID.ToString.Trim & "'" & vbNewLine & _
            "" & vbNewLine & _
            "SELECT E.empID, E.nombre FROM view_sl_empleados AS E WHERE (e.activo = 'S')" & IIf(verTodos, "", " AND (JEFE = @userid)")

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtEpmID.Text = result.Item("empid")
        txtNombre.Text = result.Item("nombre")
        fechas(True)
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        Try
            Dim strSQL As String = _
                "DECLARE @userid AS VARCHAR(5)" & vbNewLine & _
                "SET @userid = '" & pempID.ToString.Trim & "'" & vbNewLine & _
                "" & vbNewLine & _
                "SELECT E.empID, E.nombre FROM view_sl_empleados AS E --WHERE(e.estado_empleado = 'ACT')" & IIf(verTodos, "", " WHERE (JEFE = @userid)")

            txtNombre.DataBindings.Clear()
            txtEpmID.DataBindings.Clear()
            dtsForm.Clear()
            bloquear(False)
            fechas(True)
            txtNombre.Text = ""
            dtpInicio.Value = Now()
            dtpFinal.Value = Now()
            dtsForm.Clear()
            cnx.SQLEXEC(dtsForm, strSQL, "OHEM")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub FrmReporteMarcas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnLimpiar.PerformClick()
        bloquear(False)
        fechas(False)
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dtsForm
        pntexcel.tabla = Tabla
        pntexcel.titulo = "CONSULTA DE MARCAS"
        pntexcel.filtro = "MARCAS DEL COLABORADOR: " & txtNombre.Text
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Dim frmPrint As New frmImprmir()
        'Dim rpt As New rptMarcas
        ''rpt.SetDataSource(dtsForm)
        'frmPrint.MdiParent = Me.MdiParent
        'frmPrint.crControl.ReportSource = rpt
        'frmPrint.Show()
    End Sub

End Class