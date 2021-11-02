Public Class FrmConsultaVacaciones
    Dim dts As New DataSet()
    Dim encontrado As Boolean = False

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_Vacaciones").Rows.Count - 1 Then
            For i = 0 To 1
                strLinea += dts.Tables("tbl_Vacaciones").Rows(pos).Item(DataGridView1.Columns(i).DataPropertyName).ToString & vbTab
            Next
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
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_Vacaciones").Position + 1 & "/" & BindingContext(dts, "tbl_Vacaciones").Count
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub cargaGrid()
        Try
            If dts.Tables.Contains("tbl_Vacaciones") Then
                dts.Tables("tbl_Vacaciones").Rows.Clear()
            End If

            Dim strSQL As String = _
                "SELECT empID, nombre, VACS_PENDIENTES FROM view_sl_empleados" & vbNewLine & _
                "WHERE (ESTADO_EMPLEADO = 'ACT')" & IIf(verTodos, "", " AND (Jefe = " & pempID & ")")

            cnx.SQLEXEC(dts, strSQL, "tbl_Vacaciones")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_Vacaciones"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.MultiSelect = False
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToOrderColumns = False

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).Width = 55
            DataGridView1.Columns(1).Width = 290
            DataGridView1.Columns(2).Width = 65

            DataGridView1.Columns(0).HeaderText = "CODIGO"
            DataGridView1.Columns(1).HeaderText = "NOMBRE"
            DataGridView1.Columns(2).HeaderText = "SALDO"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub tsbPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUltimo.Click, tsbSiguiente.Click, tsbPrimero.Click, tsbAnterior.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dts, "tbl_Vacaciones").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_Vacaciones").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_Vacaciones").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_Vacaciones").Position = dts.Tables("tbl_Vacaciones").Rows.Count - 1
        End Select
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tbl_Vacaciones"
        pntexcel.titulo = "CONSULTA DE VACACIONES"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        cargaGrid()
    End Sub

    Private Sub FrmConsultaVacaciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cargaGrid()
        RegActual()
    End Sub

    Private Sub btnLocalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_Vacaciones").Position + 1)
            BindingContext(dts, "tbl_Vacaciones").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Vacaciones").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_Vacaciones").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Vacaciones").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub txtLocalizar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLocalizar.PerformClick()
        End If
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        RegActual()
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub
End Class