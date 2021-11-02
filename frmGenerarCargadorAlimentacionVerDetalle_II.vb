Public Class frmGenerarCargadorAlimentacionVerDetalle_II
    Dim dt As New DataTable()

    Private Sub limpiar()
        Try
            txtCodigo.Text = ""
            txtNombre.Text = ""
            dt.Rows.Clear()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub DesActiva(ByVal pActiva As Boolean)
        Try
            btnBuscar.Enabled = Not pActiva
            btnLimpiar.Enabled = pActiva
            btnExportaexcel.Enabled = pActiva
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnBuscaPersona_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            limpiar()
            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.StartPosition = FormStartPosition.CenterScreen
            pnt.Owner = Me.Owner
            pnt.Text = "BUSQUEDA"
            pnt.strConsulta = _
                "SELECT RTRIM(LTRIM(empid)) as codigo,nombre,identificacion,empid" & vbNewLine & _
                "FROM view_sl_empleados WHERE ACTIVO = 'S'"
            pnt.strTabla = "EMP"
            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            txtCodigo.Text = result.Item("CODIGO")
            txtNombre.Text = result.Item("NOMBRE")

            Dim strSQL As String = _
                        "SELECT CODIGO_EMPLEADO AS CODIGO,NOMBRE,PRECIO,FECHA_CREADO AS FECHA, numero_nómina as NOMINA" & vbNewLine & _
                        "FROM tbl_control_alimentacion_ventas_hist" & vbNewLine & _
                        "WHERE CODIGO_EMPLEADO = " & txtCodigo.Text.ToString.Trim() & vbNewLine & _
                        "ORDER BY FECHA_CREADO"
            cnx.SQLEXEC(dt, strSQL)

            DataGridView1.DataSource = dt
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.RowHeadersVisible = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).ReadOnly = True
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).HeaderText = "CÓDIGO"
            DataGridView1.Columns(1).HeaderText = "NOMBRE"
            DataGridView1.Columns(2).HeaderText = "PRECIO"
            DataGridView1.Columns(3).HeaderText = "FECHA"
            DataGridView1.Columns(4).HeaderText = "NOMINA"

            DataGridView1.Columns(0).Width = 60
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 100
            DataGridView1.Columns(4).Width = 100

            DesActiva(True)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            limpiar()
            btnBuscar.Focus()
            DesActiva(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportaexcel_Click(sender As Object, e As EventArgs) Handles btnExportaexcel.Click
        Try
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWkb As Microsoft.Office.Interop.Excel.Workbook
            Dim xlSht As Microsoft.Office.Interop.Excel.Worksheet
            Dim fil As Integer = 1, col As Integer = 1

            xlApp = CreateObject("Excel.Application")
            xlWkb = xlApp.Workbooks.Add()
            xlSht = xlWkb.ActiveSheet

            xlSht.Cells(fil, col) = "COSTA RICA COUNTRY CLUB S.A."
            xlSht.Cells(fil, col).Font.Bold = True
            xlSht.Cells(fil, col).Font.Size = 12

            xlSht.Cells(fil + 1, col) = "ARCHIVO DE CARGA DE REBAJOS"
            xlSht.Cells(fil + 1, col).Font.Bold = True
            xlSht.Cells(fil + 1, col).Font.Size = 12


            xlSht.Cells(fil + 3, col) = "CODIGO"
            xlSht.Cells(fil + 3, col + 1) = "NOMBRE"
            xlSht.Cells(fil + 3, col + 2) = "PRECIO"
            xlSht.Cells(fil + 3, col + 3) = "FECHA"
            xlSht.Cells(fil + 3, col + 4) = "NOMINA"

            For i As Integer = 0 To dt.Rows.Count - 1
                xlSht.Cells((fil + 4) + i, col) = dt.Rows(i).Item("CODIGO")
                xlSht.Cells((fil + 4) + i, col + 1) = dt.Rows(i).Item("NOMBRE")
                xlSht.Cells((fil + 4) + i, col + 2) = dt.Rows(i).Item("PRECIO")
                xlSht.Cells((fil + 4) + i, col + 3) = dt.Rows(i).Item("FECHA")
                xlSht.Cells((fil + 4) + i, col + 4) = dt.Rows(i).Item("NOMINA")
            Next

            'xlSht.Columns.AutoFit()
            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmGenerarCargadorAlimentacionVerDetalle_II_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        limpiar()
        DesActiva(False)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class