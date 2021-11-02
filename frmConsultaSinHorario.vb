Public Class frmConsultaSinHorario
    Dim dts As New DataSet()

    Private Sub cargaGrid()
        Try
            If dts.Tables.Contains("tblConsulta") Then
                dts.Tables("tblConsulta").Rows.Clear()
            End If

            Dim strSQL As String = _
            "SELECT departamento, Seccion, empID, nombre FROM view_sl_empleados" & vbNewLine & _
            "WHERE (estado_empleado = 'ACT') AND (jefe = '" & pempID & "')" & vbNewLine & _
            "ORDER BY departamento, Seccion, nombre"

            cnx.SQLEXEC(dts, strSQL, "tblEmpleadosSinHorario")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tblEmpleadosSinHorario"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.MultiSelect = False
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToAddRows = False

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).HeaderText = "DEPARMENTO"
            DataGridView1.Columns(1).HeaderText = "SECCIÓN"
            DataGridView1.Columns(2).HeaderText = "EMPID"
            DataGridView1.Columns(3).HeaderText = "NOMBRE"

            DataGridView1.Columns(0).Width = 100
            DataGridView1.Columns(1).Width = 140
            DataGridView1.Columns(2).Width = 40
            DataGridView1.Columns(3).Width = 220
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Private Sub frmConsultaSinHorario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargaGrid()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        cargaGrid()
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsbExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tblEmpleadosSinHorario"
        pntexcel.titulo = "CONSULTA DE EMPLEADOS SIN HORARIO ASIGNADO"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Dim shwrpt As New frmReport()
        'Dim rpt As New rptConsultaEmpleadosSinHorario()
        'rpt.SetDataSource(dts)
        'shwrpt.CrystalReportViewer1.ReportSource = rpt
        'shwrpt.MdiParent = Me.MdiParent
        'shwrpt.Show()
    End Sub
End Class