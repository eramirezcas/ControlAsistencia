Public Class frmJustificacionesAnte
    Dim dts As New DataSet()
    Dim npago As String
    Dim empID As String
    Dim xSQL As String

    Public VienCargada As Boolean

    Private Sub limpiar()
        txtNombre.Text = ""
        chkTodos.Checked = True
        dtpFInicial.Value = Now.Date
        dtpFFinal.Value = Now.Date
        cboNumPago.SelectedIndex = cboNumPago.Items.Count - 1
        Try
            dts.Tables("tblResult").Clear()
        Catch
        End Try
        DataGridView1.DataSource = Nothing
        lblRecActual.Text = "Registro #0/0"
    End Sub

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tblResult").Position + 1 & "/" & BindingContext(dts, "tblResult").Count
    End Sub

    Private Sub initForm()
        '' frmInicio.pempID = "75"
        '' ***************** CARGO DATOS EN EL COMBO NUMERO DE PAGO *****************
        Dim strSQL As String = "" & _
            "SET LANGUAGE SPANISH" & vbNewLine & _
            "SELECT '000000' AS NUMPAGO, 'NINGUNO' AS DETALLE" & vbNewLine & _
            "UNION" & vbNewLine & _
            "SELECT RTRIM(LTRIM(numpago)) as numpago, RTRIM(LTRIM('QUINCENA #' + UPPER(convert(char,fecha,106)))) as detalle" & vbNewLine & _
            "FROM(" & vbNewLine & _
            "	SELECT DISTINCT numpago, Convert(datetime,SUBSTRING(numpago, 1, 2) + '/' + " & vbNewLine & _
            "						  SUBSTRING(numpago, 3, 2) + '/' + " & vbNewLine & _
            "						  CONVERT(char(4), 2000 + CONVERT(int, SUBSTRING(numpago, 5, 2))), 103) as fecha" & vbNewLine & _
            "	FROM tbl_marcas_procesadas_hist" & vbNewLine & _
            "	WHERE (RTRIM(LTRIM(codigo)) IN (SELECT DISTINCT CONVERT(char(4), E.empID)" & vbNewLine & _
            "					FROM [GUAYABO\GUAYABO].CRCC.DBO.OHEM AS E INNER JOIN" & vbNewLine & _
            "						tbl_jefe_seccion AS S ON S.deptid = E.dept" & vbNewLine & _
            "					WHERE (E.U_ESTADO = 1) AND (E.U_MARCAREL = 1) AND (S.empid = '" & pempID & "')))" & vbNewLine & _
            ") AS A" & vbNewLine & _
            "ORDER BY numpago DESC"

        cnx.consulta(dts, strSQL, "tbl_pagos")
        cboNumPago.DataSource = dts
        cboNumPago.ValueMember = "tbl_pagos.numpago"
        cboNumPago.DisplayMember = "tbl_pagos.detalle"
        cboNumPago.SelectedIndex = cboNumPago.Items.Count - 1

        '' ***************** INICIALIZO OTROS CONTROLES EN EL FORM ******************
        txtNombre.Text = ""
        chkTodos.Checked = True
    End Sub

    Private Sub cargaDatos(ByVal empid As String, ByVal finicial As Date, ByVal ffinal As Date, ByVal npago As String, ByVal todos As Boolean)
        xSQL = "" & _
            "SET LANGUAGE SPANISH" & vbNewLine & _
            "" & vbNewLine & _
            "SELECT (SELECT (SELECT Name FROM [GUAYABO\GUAYABO].CRCC.dbo.oudp WHERE (Code = T0.dept)) AS Seccion" & vbNewLine & _
            "		FROM [GUAYABO\GUAYABO].CRCC.dbo.ohem AS T0 WHERE (empID = rtrim(ltrim(codigo)))" & vbNewLine & _
            "	) As Seccion," & vbNewLine & _
            "	rtrim(ltrim(codigo)) as codigo, nombre, aplicada, justificada, justificacion," & vbNewLine & _
            "	UPPER(SUBSTRING(DATENAME(WEEKDAY,fechacal),1,3)) + ' ' + CONVERT(CHAR(10),fechacal,103) AS fechacal," & vbNewLine & _
            "	CONVERT(CHAR(8),entrada,108) as entrada," & vbNewLine & _
            "	CONVERT(CHAR(8),horaentra,108) as horaentra, horasrebajar, salida, detalle1," & vbNewLine & _
            "	detalle2, id_interno, id_procesado, numpago, id_linea " & vbNewLine & _
            "FROM(	" & vbNewLine & _
            "	SELECT codigo, nombre, aplicada, justificada, justificacion, fechacal, entrada, horaentra," & vbNewLine & _
            "		horasrebajar, salida, detalle1,	detalle2, id_interno, id_procesado, numpago, id_linea" & vbNewLine & _
            "	FROM  tbl_marcas_procesadas_hist" & vbNewLine & _
            "	UNION" & vbNewLine & _
            "	SELECT codigo, nombre, aplicada, justificada, justificacion, fechacal, entrada, horaentra," & vbNewLine & _
            "		horasrebajar, salida, detalle1,	detalle2, id_interno, id_procesado, numpago, id_linea" & vbNewLine & _
            "	FROM  tbl_marcas_procesadas_act" & vbNewLine & _
            "	UNION" & vbNewLine & _
            "	SELECT codigo, nombre, aplicada, justificada, justificacion, fechacal, entrada, " & vbNewLine & _
            "		CONVERT(DATETIME," & vbNewLine & _
            "			CONVERT(CHAR(10),fechacal,103) + CASE WHEN RTRIM(LTRIM(horaentra))=':' THEN ' 00:00'" & vbNewLine & _
            "													WHEN RTRIM(LTRIM(horaentra)) IS NULL THEN ' 00:00' " & vbNewLine & _
            "													ELSE ' ' + RTRIM(LTRIM(horaentra)) " & vbNewLine & _
            "												END" & vbNewLine & _
            "		,103) AS horaentra, " & vbNewLine & _
            "		horasrebajar, salida, detalle1, detalle2, Id_Interno, id_procesado, numpago, id_linea" & vbNewLine & _
            "	FROM" & vbNewLine & _
            "		(" & vbNewLine & _
            "			SELECT 'tbl_marcas_procesadas' as tabla, codigo, nombre, 0 as aplicada, " & vbNewLine & _
            "				case when justificacion is null or len(justificacion)=0 then 'NO JUSTIFICADA' else 'JUSTIFICADA' end as justificada," & vbNewLine & _
            "				justificacion, fechacal, entrada, " & vbNewLine & _
            "				(SELECT case " & vbNewLine & _
            "						when datepart(weekday,convert(datetime,convert(char(10),tbl_marcas_procesadas.fechacal,103),103)) = 1 then tbl_tipo_horario.lunesin" & vbNewLine & _
            "						when datepart(weekday,convert(datetime,convert(char(10),tbl_marcas_procesadas.fechacal,103),103)) = 2 then tbl_tipo_horario.martesin" & vbNewLine & _
            "						when datepart(weekday,convert(datetime,convert(char(10),tbl_marcas_procesadas.fechacal,103),103)) = 3 then tbl_tipo_horario.miercolesin" & vbNewLine & _
            "						when datepart(weekday,convert(datetime,convert(char(10),tbl_marcas_procesadas.fechacal,103),103)) = 4 then tbl_tipo_horario.juevesin" & vbNewLine & _
            "						when datepart(weekday,convert(datetime,convert(char(10),tbl_marcas_procesadas.fechacal,103),103)) = 5 then tbl_tipo_horario.viernesin" & vbNewLine & _
            "						when datepart(weekday,convert(datetime,convert(char(10),tbl_marcas_procesadas.fechacal,103),103)) = 6 then tbl_tipo_horario.sabadoin " & vbNewLine & _
            "						when datepart(weekday,convert(datetime,convert(char(10),tbl_marcas_procesadas.fechacal,103),103)) = 7 then tbl_tipo_horario.domingoin" & vbNewLine & _
            "					end as HoraEntra" & vbNewLine & _
            "				 FROM tbl_horarioxEmpleado INNER JOIN tbl_tipo_horario ON tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine & _
            "				 WHERE (tbl_horarioxEmpleado.empid = rtrim(ltrim(tbl_marcas_procesadas.codigo)))" & vbNewLine & _
            "				) as horaentra, 0 as horasrebajar, salida, detalle1, detalle2, id_interno, id_procesado, numpago, id_linea" & vbNewLine & _
            "			FROM tbl_marcas_procesadas" & vbNewLine & _
            "		) AS A" & vbNewLine & _
            "	) AS A1" & vbNewLine & _
            "WHERE  (RTRIM(LTRIM(codigo)) IN (SELECT DISTINCT CONVERT(char(4), E.empID)" & vbNewLine & _
            "								 FROM [GUAYABO\GUAYABO].CRCC.DBO.OHEM AS E INNER JOIN tbl_jefe_seccion AS S ON S.deptid = E.dept" & vbNewLine & _
            "								 WHERE (E.U_ESTADO = 1) AND (E.U_MARCAREL = 1) " & IIf(verTodos, "", "AND (S.empid = " & pempID & ")") & "))" & vbNewLine & _
            IIf(npago <> "000000", "AND (numpago = '" & npago.Trim & "')", "AND (fechacal between CONVERT(DATETIME,'" & finicial.Date & "',103) AND CONVERT(DATETIME,'" & ffinal.Date & "',103))") & vbNewLine & _
            IIf(Not todos, "AND (rtrim(ltrim(codigo)) = '" & empid & "')", "") & vbNewLine & _
            "ORDER BY Seccion, nombre, fechacal"

        Try
            dts.Tables("tblResult").Clear()
        Catch
        End Try

        cnx.consulta(dts, xSQL, "tblResult")

        DataGridView1.DataSource = dts
        DataGridView1.DataMember = "tblResult"

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True

        DataGridView1.Columns(0).HeaderText = "Sección"
        DataGridView1.Columns(1).HeaderText = "Código"
        DataGridView1.Columns(2).HeaderText = "Nombre"
        DataGridView1.Columns(3).HeaderText = "Aplicad."
        DataGridView1.Columns(4).HeaderText = "Justificada"
        DataGridView1.Columns(5).HeaderText = "Justificación"
        DataGridView1.Columns(6).HeaderText = "Fecha Calendario"
        DataGridView1.Columns(7).HeaderText = "Entrada"
        DataGridView1.Columns(8).HeaderText = "Hora Entra"
        DataGridView1.Columns(9).HeaderText = "Horas Rebajo"
        DataGridView1.Columns(10).HeaderText = "Salida"
        DataGridView1.Columns(11).HeaderText = "Detalle Entrada"
        DataGridView1.Columns(12).HeaderText = "Detalle salida"
        DataGridView1.Columns(13).HeaderText = "Id Interno"
        DataGridView1.Columns(14).HeaderText = "Id Procesado"
        DataGridView1.Columns(15).HeaderText = "Número Pago"
        DataGridView1.Columns(16).HeaderText = "Id Linea"

        DataGridView1.Columns(0).Visible = True
        DataGridView1.Columns(1).Visible = True
        DataGridView1.Columns(2).Visible = True
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = True
        DataGridView1.Columns(6).Visible = True
        DataGridView1.Columns(7).Visible = True
        DataGridView1.Columns(8).Visible = True
        DataGridView1.Columns(9).Visible = True
        DataGridView1.Columns(10).Visible = True
        DataGridView1.Columns(11).Visible = True
        DataGridView1.Columns(12).Visible = True
        DataGridView1.Columns(13).Visible = False
        DataGridView1.Columns(14).Visible = False
        DataGridView1.Columns(15).Visible = True
        DataGridView1.Columns(16).Visible = False

        DataGridView1.Columns(0).Width = 150
        DataGridView1.Columns(1).Width = 50
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 150
        DataGridView1.Columns(6).Width = 100
        DataGridView1.Columns(7).Width = 60
        DataGridView1.Columns(8).Width = 60
        DataGridView1.Columns(9).Width = 50
        DataGridView1.Columns(10).Width = 150
        DataGridView1.Columns(11).Width = 150
        DataGridView1.Columns(12).Width = 120
        DataGridView1.Columns(13).Width = 100
        DataGridView1.Columns(14).Width = 100
        DataGridView1.Columns(15).Width = 50
        DataGridView1.Columns(16).Width = 100

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTodos.CheckedChanged
        If cboNumPago.IsHandleCreated Then
            lblNombre.Enabled = IIf(chkTodos.Checked, False, True)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub frmJustificacionesAnte_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        initForm()
        If VienCargada Then
            btnConsulta.PerformClick()
        End If
    End Sub

    Private Sub lblNombre_Click(sender As System.Object, e As System.EventArgs) Handles lblNombre.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE COLABORADOR"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = _
            "DECLARE @userid AS INT" & vbNewLine & _
            "SET @userid = " & pempID.ToString.Trim & vbNewLine & _
            "" & vbNewLine & _
            "SELECT E.empID, E.middleName + ' ' + E.lastName + ' ' + E.firstName AS nombre" & vbNewLine & _
            "FROM [GUAYABO\GUAYABO].[CRCC].[DBO].[OHEM] AS E" & vbNewLine & _
            "WHERE(e.U_ESTADO = 1)" & vbNewLine & _
            IIf(verTodos, "", "And (E.dept IN (SELECT S.deptid FROM [RRHH].[DBO].[TBL_JEFE_SECCION] AS S WHERE S.empid = @userid)) AND (E.empid <> @userid)")

        '"SELECT DISTINCT E.empID, E.middleName + ' ' + E.lastName + ' ' + E.firstName AS nombre " & vbNewLine & _
        '"FROM [GUAYABO\GUAYABO].[CRCC].[DBO].[OHEM] AS E " & IIf(verTodos, "", "INNER JOIN [RRHH].[DBO].[TBL_JEFE_SECCION] AS S ON S.deptID = E.dept ") & vbNewLine & _
        '"WHERE(e.U_ESTADO = 1) " & IIf(verTodos, "", "And (S.empID = " & pempID & ")")

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        empID = result.Item("empid")
        txtNombre.Text = result.Item("nombre")
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnConsulta.Click
        Dim obj As Button = CType(sender, Button)
        If obj.Text = "Consultar" Then
            cargaDatos(empID, dtpFInicial.Value, dtpFFinal.Value, cboNumPago.SelectedValue, chkTodos.Checked)
            obj.Text = "Limpiar"
        Else
            limpiar()
            obj.Text = "Consultar"
        End If

    End Sub

    Private Sub cboNumPago_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboNumPago.SelectedValueChanged
        Dim obj As ComboBox = CType(sender, ComboBox)
        If obj.ValueMember = "" Then
            Exit Sub
        End If
        dtpFInicial.Enabled = IIf(obj.SelectedValue = "000000", True, False)
        dtpFFinal.Enabled = IIf(obj.SelectedValue = "000000", True, False)
    End Sub

    Private Sub tsbPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUltimo.Click, tsbSiguiente.Click, tsbPrimero.Click, tsbAnterior.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dts, "tblResult").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tblResult").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tblResult").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tblResult").Position = dts.Tables("tblResult").Rows.Count - 1
        End Select
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        RegActual()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tblResult"
        pntexcel.titulo = "CONSULTA DE JUSTIFICACIONES HISTORICAS"
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Dim pnt As New frmImprmir
        'Dim rpt As New rptJustifcacionesHist

        'cnx.consulta(dts, xSQL, "JustifHist")
        'rpt.SetDataSource(dts)

        'pnt.MdiParent = Me.MdiParent
        'pnt.crControl.ReportSource = rpt
        'pnt.Show()
    End Sub
End Class