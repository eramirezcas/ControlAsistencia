Public Class FrmMantenimientoEmpleadosHorarios

    Public dts As New DataSet
    Dim Tabla As String = "tbl_horarioxempleado"
    Dim encontrado As Boolean = False
    Dim valor = 2

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""

        If pos <= dts.Tables(Tabla).Rows.Count - 1 Then
            For i = 0 To dgvHorarios.ColumnCount - 1
                strLinea += dts.Tables(Tabla).Rows(pos).Item(dgvHorarios.Columns(i).DataPropertyName).ToString & vbTab
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
            If dts.Tables.Contains(Tabla) Then
                dts.Tables(Tabla).Rows.Clear()
            End If

            Dim strSQL As String = "SELECT DISTINCT S.id_linea, E.empID, E.nombre, S.id_horario, S.horario as Horario, s.horarioFijo " & vbNewLine & _
                                    "FROM view_sl_empleados AS E INNER JOIN TBL_HORARIOXEMPLEADO AS S ON S.empID = convert(int,E.empid) " & vbNewLine & _
                                    "--INNER JOIN TBL_JEFE_SECCION AS F ON F.deptID = Substring(E.CENTRO_COSTO,1,2) " & vbNewLine & _
                                    "WHERE (estado_empleado = 'ACT') " & IIf(verTodos, "", " AND (RTRIM(LTRIM(jefe)) = '" & pempID.ToString.Trim & "')")

            cnx.SQLEXEC(dts, strSQL, Tabla)

            dgvHorarios.DataSource = dts
            dgvHorarios.DataMember = Tabla

            dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvHorarios.AllowUserToAddRows = False
            dgvHorarios.AllowUserToResizeColumns = False
            dgvHorarios.AllowUserToDeleteRows = False
            dgvHorarios.AllowUserToResizeRows = False
            dgvHorarios.MultiSelect = False
            dgvHorarios.ReadOnly = True

            dgvHorarios.Columns(0).HeaderText = "ID LINEA"
            dgvHorarios.Columns(1).HeaderText = "ID EMP"
            dgvHorarios.Columns(2).HeaderText = "NOMBRE"
            dgvHorarios.Columns(3).HeaderText = "ID HORARIO"
            dgvHorarios.Columns(4).HeaderText = "HORARIO"
            dgvHorarios.Columns(5).HeaderText = "H. FIJO"

            dgvHorarios.Columns(0).Width = 70
            dgvHorarios.Columns(1).Width = 55
            dgvHorarios.Columns(2).Width = 245
            dgvHorarios.Columns(3).Width = 75
            dgvHorarios.Columns(4).Width = 245
            dgvHorarios.Columns(5).Width = 45
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dts, Tabla).Position + 1 & "/" & BindingContext(dts, Tabla).Count
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub FrmMantenimentotipohorario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        RegActual()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Close()
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
                BindingContext(dts, Tabla).Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, Tabla).Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, Tabla).Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, Tabla).Position = dts.Tables(Tabla).Rows.Count - 1
        End Select
    End Sub

    Private Sub dgvHorarios_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellEnter
        RegActual()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = Tabla
        pntexcel.titulo = "HORARIOS EMPLEADO"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub dgvHorarios_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellDoubleClick
        btnEditar.PerformClick()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim obj As New FrmBuscaEmpHorario
        obj.MdiParent = Me.MdiParent
        obj.nuevo = False
        obj.dts = dts
        obj.pos = BindingContext(dts, Tabla).Position
        obj.pnt = Me
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub


    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim obj As New FrmBuscaEmpHorario
        obj.MdiParent = Me.MdiParent
        dts.Tables(Tabla).Rows.Add()
        BindingContext(dts, Tabla).Position = dts.Tables(Tabla).Rows.Count - 1
        obj.nuevo = True
        obj.dts = dts
        obj.pos = BindingContext(dts, Tabla).Position
        obj.pnt = Me
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub btnLocalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, Tabla).Position + 1)
            BindingContext(dts, Tabla).Position = IIf(localizado = -1, BindingContext(dts, Tabla).Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, Tabla).Position = IIf(localizado = -1, BindingContext(dts, Tabla).Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub

End Class