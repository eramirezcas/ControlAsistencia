Public Class FrmBuscaGrid
    Dim dtsForm = FrmMantenimientoJefesSecciones.dtsForm
    Dim encontrado As Boolean = False
    Dim tabla As String

    Private Sub FrmBuscaGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FrmBuscar.Enabled = True

        txtLocalizar.Text = ""

        Dim opcion = FrmBuscar.opcion
        Select Case opcion
            Case 1
                tabla = FrmBuscar.tablajefe
            Case 2
                tabla = FrmBuscar.tabladep
        End Select
    End Sub

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dtsForm.Tables(tabla).Rows.Count - 1 Then
            For i = 0 To 1
                strLinea += dtsForm.Tables(tabla).Rows(pos).Item(dgvBusqueda.Columns(i).DataPropertyName).ToString & vbTab
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

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dtsForm, Tabla).Position + 1 & "/" & BindingContext(dtsForm, Tabla).Count
    End Sub

    Private Sub tsbPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUltimo.Click, tsbSiguiente.Click, tsbPrimero.Click, tsbAnterior.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dtsForm, Tabla).Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dtsForm, Tabla).Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dtsForm, Tabla).Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dtsForm, Tabla).Position = dtsForm.Tables(Tabla).Rows.Count - 1
        End Select
    End Sub

    Private Sub txtLocalizar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress

        If Asc(e.KeyChar) = 13 Then
            txtLocalizar.BackColor = IIf(txtLocalizar.TextLength = 0, Color.White, Color.LightBlue)
            If txtLocalizar.Text.Length = 0 Then
                mensajes("Debe de ingresar un dato para realizar la acción !!!")
                Exit Sub
            End If
            If encontrado Then
                Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dtsForm, tabla).Position + 1)
                BindingContext(dtsForm, tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, tabla).Position, localizado)
            Else
                Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
                BindingContext(dtsForm, tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, tabla).Position, localizado)
                encontrado = IIf(localizado = -1, False, True)
                If Not encontrado Then
                    mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
                End If
            End If
            RegActual()
        End If
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dtsForm, tabla).Position + 1)
            BindingContext(dtsForm, tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, tabla).Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dtsForm, tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, tabla).Position, localizado)
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

    Private Sub dgvBusqueda_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBusqueda.CellDoubleClick
        Me.Text = BindingContext(dtsForm, tabla).Position
        Dim opcion = FrmBuscar.opcion
        Select Case opcion
            Case 1
                FrmBuscar.idemp = dgvBusqueda.Item(0, dgvBusqueda.CurrentRow.Index).Value
                FrmBuscar.txtJefe.Text = dgvBusqueda.Item(1, dgvBusqueda.CurrentRow.Index).Value
            Case 2
                FrmBuscar.iddep = dgvBusqueda.Item(0, dgvBusqueda.CurrentRow.Index).Value
                FrmBuscar.txtDepartamento.Text = dgvBusqueda.Item(1, dgvBusqueda.CurrentRow.Index).Value
        End Select

        FrmBuscar.Enabled = True
        Me.Close()

    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FrmBuscar.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Me.Text = BindingContext(dtsForm, tabla).Position
        Dim opcion = FrmBuscar.opcion
        Select Case opcion
            Case 1
                FrmBuscar.idemp = dgvBusqueda.Item(0, dgvBusqueda.CurrentRow.Index).Value
                FrmBuscar.txtJefe.Text = dgvBusqueda.Item(1, dgvBusqueda.CurrentRow.Index).Value
            Case 2
                FrmBuscar.iddep = dgvBusqueda.Item(0, dgvBusqueda.CurrentRow.Index).Value
                FrmBuscar.txtDepartamento.Text = dgvBusqueda.Item(1, dgvBusqueda.CurrentRow.Index).Value
        End Select

        FrmBuscar.Enabled = True
        Me.Close()
    End Sub
End Class