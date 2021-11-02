Imports System.Drawing.Drawing2D
Public Class FrmConsultaLlegadasTardias
#Region "Variables"
    Public ConexionDb As New ConexionDB("IRAZU", "RRHH", "", "", True)
    Public ConexionDbGuayabo As New ConexionDB("GUAYABO\GUAYABO", "CRCC", "sa", "Sa123456", False)
    Public dtsForm As New DataSet
    Public codigo As String
    Dim Tabla As String = "qtmExtras"
    Dim encontrado As Boolean = False
    'Dim prueba As String
#End Region

#Region "Metodos"

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""

        If pos <= dtsForm.Tables(Tabla).Rows.Count - 1 Then
            For i = 0 To 1
                strLinea += dtsForm.Tables(Tabla).Rows(pos).Item(dgvHorarios.Columns(i).DataPropertyName).ToString & vbTab
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

    Public Sub CargaGrid()
        dtsForm.Clear()
        Dim strSQL As String = ""


        FrmMantenimientoJefesSecciones.ConexionDb.consulta(dtsForm, strSQL, "qtmExtras")

        dgvHorarios.DataSource = dtsForm
        dgvHorarios.DataMember = "qtmExtras"

        dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHorarios.AllowUserToAddRows = False
        dgvHorarios.AllowUserToResizeColumns = False
        dgvHorarios.AllowUserToDeleteRows = False
        dgvHorarios.AllowUserToResizeRows = False
        dgvHorarios.MultiSelect = False
        dgvHorarios.ReadOnly = True

        dgvHorarios.Columns(0).HeaderText = "Codigo"
        dgvHorarios.Columns(0).Width = 50

        dgvHorarios.Columns(1).HeaderText = "Nombre"
        dgvHorarios.Columns(1).Width = 240

        dgvHorarios.Columns(2).HeaderText = "Entrada"
        dgvHorarios.Columns(2).Width = 130

        dgvHorarios.Columns(3).HeaderText = "Salida"
        dgvHorarios.Columns(3).Width = 130

        dgvHorarios.Columns(4).HeaderText = "Detalle Entrada"
        dgvHorarios.Columns(4).Width = 140

        dgvHorarios.Columns(5).HeaderText = "Detalle Saldia"
        dgvHorarios.Columns(5).Width = 140

    End Sub

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dtsForm, Tabla).Position + 1 & "/" & BindingContext(dtsForm, Tabla).Count
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub cargaforma(ByVal pantallas As Object)
        Dim obj As Object = CType(pantallas, Form)
        'obj.MdiParent = Me
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

#End Region

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        '' Crea la degradacion de la pantalla principal en color verde y blanco
        Dim myGraphics As Graphics = e.Graphics '' se crea la variable de tipo graphics 
        Dim x As Int16 = sender.Size.Width '' se crea una variable tipo integer y se le asigna al alcho de la forma
        Dim y As Int16 = sender.Size.Height '' se crea una variable tipo integer y se le asigna al alto de la forma

        Dim myPantalla As Rectangle = New Rectangle(0, 0, x, y) '' se crea una variable de tipo rectangulo y se le asigna valores x,y

        Dim Relleno As LinearGradientBrush = _
                New LinearGradientBrush(myPantalla, _
                                        Color.DarkGreen, _
                                        Color.White, _
                                        LinearGradientMode.Vertical)
        myGraphics.FillRectangle(Relleno, myPantalla)
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtLocalizar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtLocalizar.BackColor = IIf(txtLocalizar.TextLength = 0, Color.White, Color.LightBlue)
            If txtLocalizar.Text.Length = 0 Then
                mensajes("Debe de ingresar un dato para realizar la acción !!!")
                Exit Sub
            End If
            If encontrado Then
                Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dtsForm, Tabla).Position + 1)
                BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
            Else
                Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
                BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
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
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dtsForm, Tabla).Position + 1)
            BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
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

    Private Sub dgvHorarios_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvHorarios.SelectionChanged
        RegActual()
    End Sub

    Private Sub dgvHorarios_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellContentClick
        RegActual()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        'If Not txtNombre.Text = "" Then
        '    If dtpInicio.Value < dtpFinal.Value Or dtpInicio.Value < dtpFinal.Value Then
        '        CargaGrid()
        '    Else
        '        MessageBox.Show("La Inicial no puede ser mayor a la fecha Final", "Fecha final", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If

        'Else
        '    MessageBox.Show("Faltan Datos en la Forma", "Datos en la Forma", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End If

    End Sub

    'Private Sub lblNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNombre.Click
    '    Dim pnt As New FrmGridConsulta
    '    pnt.Tabla = "tbl_empleados"
    '    pnt.StrCon = "Select codigo AS empid, Nombre from tbl_empleados"
    '    pnt.TipoConecion = pnt.ConexionDbPOAS
    '    pnt.pOpcion = 2
    '    pnt.pTipoDgv = 1
    '    pnt.Show()
    'End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dtsForm.Clear()
        dtpInicio.Value = Now
        dtpFinal.Value = Now
    End Sub

    'Private Sub chkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodos.CheckedChanged
    '    If Me.chkTodos.Checked = True Then
    '        CargaGrid()
    '        dtpInicio.Enabled = False
    '        dtpFinal.Enabled = False
    '    Else
    '        dtpInicio.Enabled = True
    '        dtpFinal.Enabled = True

    '    End If

    'End Sub

    Private Sub FrmConsultaLlegadasTardias_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador
        cargaforma(pntexcel)
    End Sub
End Class