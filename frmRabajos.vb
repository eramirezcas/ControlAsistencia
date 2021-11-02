Public Class frmRabajos
    Public dts As DataSet
    Public pnt As Form
    Dim encontrado As Boolean

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_Rebajos").Rows.Count - 1 Then
            For i = 1 To DataGridView1.Columns.Count - 1
                strLinea += IIf(DataGridView1.Columns(i).Visible, dts.Tables("tbl_Rebajos").Rows(pos).Item(DataGridView1.Columns(i).DataPropertyName).ToString & vbTab, "")
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

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
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

    Private Sub tsbAnterior_Click(sender As System.Object, e As System.EventArgs) Handles tsbUltimo.Click, tsbSiguiente.Click, tsbPrimero.Click, tsbAnterior.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Name
            Case "tsbPrimero"
                BindingContext(dts, "tbl_Rebajos").Position = 0
            Case "tsbAnterior"
                BindingContext(dts, "tbl_Rebajos").Position -= 1
            Case "tsbSiguiente"
                BindingContext(dts, "tbl_Rebajos").Position += 1
            Case "tsbUltimo"
                BindingContext(dts, "tbl_Rebajos").Position = dts.Tables("tbl_Rebajos").Rows.Count - 1
        End Select
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsbExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.dts = dts
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.tabla = "tbl_Rebajos"
        pntexcel.titulo = "CONTROL DE MARCAS"
        pntexcel.filtro = "MARCAS DEL POR REBAJAR"
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub frmRabajos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
        dts.Tables("tbl_Rebajos").Clear()
    End Sub

    Private Sub frmRabajos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Dim strSQL As String = _
                "SELECT  M.departamento, M.seccion, M.codigo, M.nombre, SUM(M.diferencia) AS horasRebajar," & vbNewLine & _
                "	round(SUM(M.diferencia)* O.salario_hora,2) as montoRebajar" & vbNewLine & _
                "FROM tbl_marcas_justificadas_act AS M INNER JOIN view_sl_empleados AS O ON O.empID = M.codigo" & vbNewLine & _
                "WHERE (diferencia > 0) AND (LEN(RTRIM(LTRIM(Justificacion))) = 0)" & vbNewLine & _
                "GROUP BY M.departamento, M.seccion, M.codigo, M.nombre, O.salario_hora" & vbNewLine & _
                "ORDER BY M.departamento, M.seccion, M.nombre"

            cnx.SQLEXEC(dts, strSQL, "tbl_Rebajos")
            
            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_Rebajos"
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

            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(4).DefaultCellStyle.Format = "n"
            DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(5).DefaultCellStyle.Format = "n"
            Me.MdiParent = pnt.MdiParent

            pnt.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnLocalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_Rebajos").Position + 1)
            BindingContext(dts, "tbl_Rebajos").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Rebajos").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_Rebajos").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Rebajos").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_Rebajos").Position + 1 & "/" & dts.Tables("tbl_Rebajos").Rows.Count
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim obj As New frmCorreo()
        obj.dts = dts
        obj.pnt = Me
        obj.MdiParent = Me.MdiParent
        obj.Show()
    End Sub
End Class