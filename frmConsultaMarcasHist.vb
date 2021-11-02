Public Class frmConsultaMarcasHist
    Dim dts As New DataSet()

    Private Sub desActiva(ByVal pbActiva As Boolean)
        tsbExcel.Enabled = pbActiva
        btnImprimir.Enabled = pbActiva
        dtpInicial.Enabled = Not pbActiva
        dtpFinal.Enabled = Not pbActiva
        cboJustificado.Enabled = Not pbActiva
        lblNombre.Enabled = Not pbActiva
        lblSeccion.Enabled = Not pbActiva
    End Sub

    Private Sub limpiar()
        dtpInicial.Value = Now
        dtpFinal.Value = Now
        txtNombre.Text = ""
        txtNombre.Tag = Nothing
        txtSeccion.Text = ""
        txtSeccion.Tag = Nothing
        cboJustificado.SelectedIndex = 0
        dts.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing
        desActiva(False)
    End Sub

    Private Sub cargaGrid()
        Dim strSeccion As String = "AND (codigo in (SELECT empID AS Codigo FROM [GUAYABO\GUAYABO].CRCC.DBO.OHEM WHERE (u_estado = 1) AND (dept IN (SELECT deptid FROM tbl_jefe_seccion WHERE (empid = " & pempID & ")))))"
        Dim strSql As String
        strSql = _
            "SELECT A.SECCION, A.EMPID AS CODIGO, A.NOMBRE, B.JUSTIFICADA, B.fechacal AS CALENDARIO, B.ENTRADA, B.horaentra AS HORARIO," & vbNewLine & _
            "	B.horasrebajar AS REBAJO_HORA, B.SALIDA, B.detalle1 AS DET_ENTRA, B.detalle2 AS DET_SALE, B.JUSTIFICACION, B.NUMPAGO" & vbNewLine & _
            "FROM" & vbNewLine & _
            "(	SELECT DISTINCT E.empID, E.middleName + ' ' + E.lastName + ' ' + E.firstName AS nombre, s.name as Seccion" & vbNewLine & _
            "	FROM [GUAYABO\GUAYABO].[CRCC].[DBO].[OHEM] AS E inner join [GUAYABO\GUAYABO].[CRCC].[DBO].[OUDP] as S on S.code = e.dept" & vbNewLine & _
            "	WHERE (e.U_MARCAREL = 1)" & vbNewLine & _
            ") AS A INNER JOIN" & vbNewLine & _
            "(	SELECT justificada, codigo, entrada, horaentra, horasrebajar, salida, detalle1, detalle2, justificacion, fechacal, numpago" & vbNewLine & _
            "	FROM tbl_marcas_procesadas_act" & vbNewLine & _
            "	UNION" & vbNewLine & _
            "	SELECT justificada, codigo, entrada, horaentra, horasrebajar, salida, detalle1, detalle2, justificacion, fechacal, numpago" & vbNewLine & _
            "	FROM tbl_marcas_procesadas_hist" & vbNewLine & _
            ") AS B ON RTRIM(LTRIM(B.Codigo)) = RTRIM(LTRIM(A.empID))" & vbNewLine & _
            "WHERE (1=1) " & _
            IIf(cboJustificado.SelectedItem = "TODO", "", "AND (RTRIM(LTRIM(JUSTIFICADA)) = '" & cboJustificado.SelectedItem & "') ") & _
            IIf(dtpInicial.Value.Date = dtpFinal.Value.Date, "", _
                "AND (FECHACAL BETWEEN CONVERT(DATETIME,'" & dtpInicial.Value.Date & "',103) AND " & _
                                     "CONVERT(DATETIME,'" & dtpFinal.Value.Date & "',103)) ") & _
            IIf(txtNombre.Text = "", "", "AND (RTRIM(LTRIM(A.EMPID)) = '" & Val(txtNombre.Tag) & "') ") & _
            IIf(txtSeccion.Text = "", IIf(verTodos, "", strSeccion), "AND (RTRIM(LTRIM(A.SECCION)) = '" & txtSeccion.Tag & "') ")
        strSql += ""

        cnx.consulta(dts, strSql, "tblResult")
        cnx.consulta(dts, strSql, "TB1")

        DataGridView1.DataSource = dts
        DataGridView1.DataMember = "tblResult"
        DataGridView1.Refresh()

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToOrderColumns = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True

        For i = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        DataGridView1.Columns(0).Width = 150
        DataGridView1.Columns(1).Width = 50
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 120
        DataGridView1.Columns(4).Width = 80
        DataGridView1.Columns(5).Width = 120
        DataGridView1.Columns(6).Width = 120
        DataGridView1.Columns(7).Width = 90
        DataGridView1.Columns(8).Width = 120
        DataGridView1.Columns(9).Width = 150
        DataGridView1.Columns(10).Width = 120
        DataGridView1.Columns(11).Width = 190
        DataGridView1.Columns(12).Width = 60

    End Sub

    Private Sub Label3_Click(sender As System.Object, e As System.EventArgs) Handles lblNombre.Click
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
        '"WHERE(e.U_ESTADO = 1) AND (e.U_MARCAREL = 1) " & IIf(verTodos, "", "And (S.empID = " & pempID & ")")

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtNombre.Tag = StrDup(4 - result.Item("empid").ToString.Trim.Length, "0") & result.Item("empid")
        txtNombre.Text = txtNombre.Tag & " | " & result.Item("nombre")
    End Sub

    Private Sub Label5_Click(sender As System.Object, e As System.EventArgs) Handles lblSeccion.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE SECCIÓN"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = "SELECT Code AS Codigo, Name AS Seccion FROM [GUAYABO\GUAYABO].CRCC.DBO.OUDP" & vbNewLine & _
                            "WHERE (Code > 0) " & IIf(verTodos = False, " AND (code in (SELECT deptid FROM tbl_jefe_seccion WHERE (empid = " & pempID & ")))", "")

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtSeccion.Tag = result.Item("Seccion")
        txtSeccion.Text = StrDup(3 - result.Item("Codigo").ToString.Trim.Length, "0") & result.Item("Codigo") & " | " & result.Item("Seccion")
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        Dim obj As Button = CType(sender, Button)

        If obj.Text = "&Generar" Then

            If dtpInicial.Value > dtpFinal.Value Then
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            obj.Text = "&Limpiar"
            obj.Image = Global.WindowsApplication1.My.Resources.Deshacer
            desActiva(True)
            cargaGrid()
        Else
            obj.Text = "&Generar"
            obj.Image = Global.WindowsApplication1.My.Resources.refresh
            limpiar()
        End If
    End Sub

    Private Sub frmConsultaMarcasHist_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        limpiar()
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsbExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tblResult"
        pntexcel.titulo = "CONSULTA JUSTIFICACIONES"
        pntexcel.filtro = "MARCAS DE: " & txtSeccion.Text
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Dim pnt As New frmImprmir
        'Dim rpt As New rptJustifcacionesHist

        'rpt.SetDataSource(dts)

        'pnt.MdiParent = Me.MdiParent
        'pnt.crControl.ReportSource = rpt
        'pnt.Show()
    End Sub
End Class