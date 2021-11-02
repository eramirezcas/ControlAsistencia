Public Class frmListadoBenAlim
    Dim dt As New DataTable

    Public Sub CargaGrid()
        Try

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

            DataGridView1.Columns(0).HeaderText = "DEPARTAMENTO"
            DataGridView1.Columns(1).HeaderText = "SECCIÓN"
            DataGridView1.Columns(2).HeaderText = "CÓDIGO"
            DataGridView1.Columns(3).HeaderText = "NOMBRE"

            DataGridView1.Columns(0).Width = 150
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 50
            DataGridView1.Columns(3).Width = 200


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnExportaexcel_Click(sender As Object, e As EventArgs) Handles btnExportaexcel.Click
        Try

            If dt.Rows.Count() = 0 Then
                btnCargar.PerformClick()
            End If

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

            xlSht.Cells(fil + 1, col) = "LISTADO DE BENEFICIO DE ALIMENTACIÓN"
            xlSht.Cells(fil + 1, col).Font.Bold = True
            xlSht.Cells(fil + 1, col).Font.Size = 12


            xlSht.Cells(fil + 3, col) = "DEPARTAMENTO"
            xlSht.Cells(fil + 3, col + 1) = "SECCION"
            xlSht.Cells(fil + 3, col + 2) = "CODIGO"
            xlSht.Cells(fil + 3, col + 3) = "NOMBRE"

            For i As Integer = 0 To dt.Rows.Count - 1
                xlSht.Cells((fil + 4) + i, col) = dt.Rows(i).Item("DEPARTAMENTO")
                xlSht.Cells((fil + 4) + i, col + 1) = dt.Rows(i).Item("SECCION")
                xlSht.Cells((fil + 4) + i, col + 2) = dt.Rows(i).Item("CÓDIGO")
                xlSht.Cells((fil + 4) + i, col + 3) = dt.Rows(i).Item("NOMBRE")
            Next

            'xlSht.Columns.AutoFit()
            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dt.Rows.Clear()
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Try

            Dim strsql As String = _
                "SELECT DEPARTAMENTO,SECCION,EMPID AS [CÓDIGO],NOMBRE" & vbNewLine & _
                "FROM view_sl_empleados" & vbNewLine & _
                "WHERE ACTIVO='S' AND BENEF_ALIMENTACION = 1" & vbNewLine & _
                "ORDER BY DEPARTAMENTO,SECCION, OrdenStaf"
            cnx.SQLEXEC(dt, strsql)
            CargaGrid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class