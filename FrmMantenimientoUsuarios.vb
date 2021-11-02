Public Class FrmMantenimientoUsuarios

    Public Opcion As Integer = 2
    Public dtsForm As New DataSet

    Dim Tabla As String = "tbl_control_asistencia_usuarios"
    Dim encontrado As Boolean = False
    Dim valor = 2


    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""

        If pos <= dtsForm.Tables(Tabla).Rows.Count - 1 Then
            For i = 0 To dgvHorarios.Columns.Count - 1
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
        Try
            dtsForm.Clear()
            cnx.SQLEXEC(dtsForm, "Select id_linea, empid, nombre, activo, usuario, clave, verTodos, email from " & Tabla & "", Tabla)

            dgvHorarios.DataSource = dtsForm
            dgvHorarios.DataMember = Tabla

            dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvHorarios.AllowUserToAddRows = False
            dgvHorarios.AllowUserToResizeColumns = False
            dgvHorarios.AllowUserToDeleteRows = False
            dgvHorarios.AllowUserToResizeRows = False
            dgvHorarios.RowHeadersVisible = False
            dgvHorarios.MultiSelect = False
            dgvHorarios.ReadOnly = True

            dgvHorarios.Columns(0).HeaderText = "ID Linea"
            dgvHorarios.Columns(0).Visible = False

            dgvHorarios.Columns(1).HeaderText = "ID Emp"
            dgvHorarios.Columns(1).Width = 50

            dgvHorarios.Columns(2).HeaderText = "Nombre"
            dgvHorarios.Columns(2).Width = 250

            dgvHorarios.Columns(3).HeaderText = "Activo"
            dgvHorarios.Columns(3).Width = 83

            dgvHorarios.Columns(4).HeaderText = "Usuario"
            dgvHorarios.Columns(4).Width = 150

            dgvHorarios.Columns(5).HeaderText = "clave"
            dgvHorarios.Columns(5).Visible = False

            dgvHorarios.Columns(6).HeaderText = "verTodos"
            dgvHorarios.Columns(6).Visible = False

            dgvHorarios.Columns(7).HeaderText = "email"
            dgvHorarios.Columns(7).Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try

    End Sub

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dtsForm, Tabla).Position + 1 & "/" & BindingContext(dtsForm, Tabla).Count
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Public Sub cargaforma(ByVal pantallas As Object)
        Dim obj As Object = CType(pantallas, Form)
        obj.MdiParent = Me.MdiParent
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub FrmMantenimientoUsuariosControlAsistencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        BindingContext(dtsForm, Tabla).Position = 0
        RegActual()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        cargaforma(FrmBuscarUsuarios)
        Opcion = 1
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtLocalizar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnLocalizar.PerformClick()
        End If
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

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dtsForm
        pntexcel.tabla = Tabla
        pntexcel.titulo = "CONSULTA DE MARCAS"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub dgvHorarios_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellDoubleClick
        btnEditar.PerformClick()
    End Sub

    Private Sub btnLocalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dtsForm, "tbl_control_asistencia_usuarios").Position + 1)
            BindingContext(dtsForm, "tbl_control_asistencia_usuarios").Position = IIf(localizado = -1, BindingContext(dtsForm, "tbl_control_asistencia_usuarios").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dtsForm, "tbl_control_asistencia_usuarios").Position = IIf(localizado = -1, BindingContext(dtsForm, "tbl_control_asistencia_usuarios").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim pnt As New FrmBuscarUsuarios()

        pnt.txtempid.Text = dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("empid")
        pnt.txtJefe.Text = dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("nombre")
        pnt.txtJefe.Enabled = False
        pnt.txtContraseña.Text = dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("clave")
        pnt.txtUsuario.Text = dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("usuario")
        pnt.txtUsuario.Enabled = False
        pnt.chkActivo.Checked = dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("activo")
        pnt.chkVerTodos.Checked = dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("VerTodos")
        pnt.txtEmail.Text = dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("email")
        Opcion = 2
        cargaforma(pnt)
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub

End Class