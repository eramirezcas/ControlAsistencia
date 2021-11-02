Imports System.Drawing.Drawing2D

Public Class frmMantenimiento
    Dim encontrado As Boolean = False
    Dim _tabla As String = "TBL_TIPO_HORARIO"
    Dim cnxIrazu As New ConexionDB("IRAZU", "RRHH", "", "", True)
    Dim cnxGuayabo As New ConexionDB("GUAYABO\GUAYABO", "CRCC", "sa", "Sa123456", False)
    Dim dts As New DataSet()

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables(_tabla).Rows.Count - 1 Then
            For i = 0 To 1
                strLinea += dts.Tables(_tabla).Rows(pos).Item(DataGridView1.Columns(i).DataPropertyName).ToString & vbTab
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
        lblRecActual.Text = "Registro #" & BindingContext(dts, _tabla).Position + 1 & "/" & BindingContext(dts, _tabla).Count
    End Sub

    Private Sub cargaGrid()
        DataGridView1.ColumnCount = 2
        DataGridView1.DataSource = dts
        DataGridView1.DataMember = _tabla
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ReadOnly = True

        DataGridView1.Columns(0).HeaderText = "ID"
        DataGridView1.Columns(0).DataPropertyName = "id_horario"
        DataGridView1.Columns(0).Width = 40

        DataGridView1.Columns(1).HeaderText = "HORARIO"
        DataGridView1.Columns(1).DataPropertyName = "detalle"
        DataGridView1.Columns(1).Width = 370

        For i = 2 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns(i).Visible = False
        Next
    End Sub

    Private Sub cargaForm(ByVal strTitulo As String)
        Dim objPnt As New frmNuevoEdicion()
        objPnt.frmPadre = Me
        objPnt.strTilulo = strTitulo
        objPnt.Show()
    End Sub

    Private Sub frmMantenimiento_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles gpColor.Paint
        Dim myGraphics As Graphics = e.Graphics
        Dim x As Int16 = sender.Size.Width
        Dim y As Int16 = sender.Size.Height
        Dim myPantalla As Rectangle = New Rectangle(0, 0, x, y)
        Dim Relleno As LinearGradientBrush = New LinearGradientBrush(myPantalla, Color.Black, Color.White, LinearGradientMode.Vertical)
        myGraphics.FillRectangle(Relleno, myPantalla)
    End Sub

    Private Sub tsbEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click, tsbFiltrar.Click, tsbEditar.Click, ToolStripButton3.Click, ToolStripButton1.Click, tblImprimir.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Text
            Case "&Salir"
                Close()
            Case "&Nuevo"
                cargaForm("NUEVO DATO")
            Case "&Editar"
                cargaForm("EDITAR DATO")
        End Select
    End Sub

    Private Sub tsbPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUltimo.Click, tsbSiguiente.Click, tsbPrimero.Click, tsbAnterior.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dts, _tabla).Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, _tabla).Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, _tabla).Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, _tabla).Position = dts.Tables(_tabla).Rows.Count - 1
        End Select
    End Sub

    Private Sub frmMantenimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cnxIrazu.consulta(dts, "SELECT * FROM " & _tabla, _tabla)
        cargaGrid()
        BindingContext(dts, _tabla).Position = 0
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, _tabla).Position + 1)
            BindingContext(dts, _tabla).Position = IIf(localizado = -1, BindingContext(dts, _tabla).Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, _tabla).Position = IIf(localizado = -1, BindingContext(dts, _tabla).Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub pctLocalizar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctLocalizar.MouseDown
        pctLocalizar.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub pctLocalizar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctLocalizar.MouseUp
        pctLocalizar.BorderStyle = BorderStyle.None
    End Sub

    Private Sub txtLocalizar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.TextLength = 0, Color.White, Color.LightBlue)
        encontrado = False
        mensajes("")
    End Sub

    Private Sub DataGridView1_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentDoubleClick
        Me.Text = BindingContext(dts, _tabla).Position
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        RegActual()
    End Sub

End Class