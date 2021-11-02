Public Class frmListadoHorarios

    Dim dts As New DataSet()
    Dim encontrado As Boolean = False

    Private Function ValidaSeleccion() As Boolean
        For i = 0 To dts.Tables("tbl_colabSeccion").Rows.Count - 1
            If dts.Tables("tbl_colabSeccion").Rows(i).Item("SelectItem") Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_colabSeccion").Rows.Count - 1 Then
            For i = 0 To 3
                strLinea = dts.Tables("tbl_colabSeccion").Rows(pos).Item("empID") & vbTab & _
                        dts.Tables("tbl_colabSeccion").Rows(pos).Item("Nombre")
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
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_colabSeccion").Position + 1 & "/" & BindingContext(dts, "tbl_colabSeccion").Count

        DesActiva(IIf(BindingContext(dts, "tbl_colabSeccion").Count = 0, False, True))
    End Sub

    Private Sub DesActiva(ByVal pActiva As Boolean)
        GroupBox1.Enabled = pActiva
        DataGridView1.Enabled = pActiva
        chkSelAllNone.Enabled = pActiva
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_colabSeccion").Position + 1)
            BindingContext(dts, "tbl_colabSeccion").Position = IIf(localizado = -1, BindingContext(dts, "tbl_colabSeccion").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_colabSeccion").Position = IIf(localizado = -1, BindingContext(dts, "tbl_colabSeccion").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub tsbPrimero_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrimero.Click, tsbAnterior.Click, tsbUltimo.Click, tsbSiguiente.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dts, "tbl_colabSeccion").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_colabSeccion").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_colabSeccion").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_colabSeccion").Position = dts.Tables("tbl_colabSeccion").Rows.Count - 1
        End Select
    End Sub

    Private Sub DataGridView_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        RegActual()
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

    Public Sub CargaGrid()
        Try
            If dts.Tables.Contains("tbl_colabSeccion") Then
                dts.Tables.Remove("tbl_colabSeccion")
            End If

            Dim strSQL As String = _
                "DECLARE @userid AS INT" & vbNewLine & _
                "SET @userid = " & pempID.ToString.Trim & vbNewLine & _
                "" & vbNewLine & _
                "SELECT CAST(0 AS BIT) AS selectItem" & vbNewLine & _
                "   ,E.empID, E.nombre FROM view_sl_empleados AS E WHERE(e.estado_empleado = 'ACT')" & IIf(verTodos, "", " And (E.jefe = @userid)")

            If Not IsNothing(dts.Tables("tbl_colabSeccion")) Then
                dts.Tables("tbl_colabSeccion").Clear()
            End If

            cnx.SQLEXEC(dts, strSQL, "tbl_colabSeccion")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_colabSeccion"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.RowHeadersVisible = False
            DataGridView1.Font = New Font("Arial", 7, FontStyle.Regular)

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable

            DataGridView1.Columns(0).ReadOnly = False
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.Columns(2).ReadOnly = True

            DataGridView1.Columns(0).HeaderText = ""
            DataGridView1.Columns(1).HeaderText = "Código"
            DataGridView1.Columns(2).HeaderText = "Nombre"

            DataGridView1.Columns(0).Width = 40
            DataGridView1.Columns(1).Width = 50
            DataGridView1.Columns(2).Width = 360

            DataGridView1.Columns(0).DisplayIndex = 0
            DataGridView1.Columns(1).DisplayIndex = 1
            DataGridView1.Columns(2).DisplayIndex = 2

            DataGridView1.Columns(0).Visible = True
            DataGridView1.Columns(1).Visible = True
            DataGridView1.Columns(2).Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
    End Sub

    Private Sub frmRegistroExtrasEnvio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        RegActual()
    End Sub

    Private Sub chkSelAllNone_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSelAllNone.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)
        Dim pos As ULong = BindingContext(dts, "tbl_colabSeccion").Position
        For i = 0 To dts.Tables("tbl_colabSeccion").Rows.Count - 1
            dts.Tables("tbl_colabSeccion").Rows(i).Item("SelectItem") = obj.Checked
        Next
        BindingContext(dts, "tbl_colabSeccion").Position = pos
        DataGridView1.Refresh()
    End Sub


    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim strSelec As String = ""

        If Not ValidaSeleccion() Then
            MessageBox.Show("Debe seleccionar al menos un item para generar el reporte.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        For i = 0 To dts.Tables("tbl_colabSeccion").Rows.Count - 1
            If dts.Tables("tbl_colabSeccion").Rows(i).Item("selectItem") = True Then
                strSelec += dts.Tables("tbl_colabSeccion").Rows(i).Item("empid") & ","
            End If
        Next

        strSelec = strSelec.Substring(0, strSelec.Length - 1)

        If dts.Tables.Contains("result") Then
            dts.Tables.Remove("result")
        End If

        Dim strSQL As String = _
            "SELECT view_sl_empleados.DEPARTAMENTO" & vbNewLine & _
            "	,view_sl_empleados.SECCION" & vbNewLine & _
            "	,tbl_horarioxEmpleado.empid" & vbNewLine & _
            "	,tbl_horarioxEmpleado.nombre" & vbNewLine & _
            "	,case when tbl_horarioxEmpleado.horarioFijo=1 then 'SI' else 'NO' end as Fijo" & vbNewLine & _
            "	,tbl_tipo_horario.detalle" & vbNewLine & _
            "	,tbl_tipo_horario.lunesin" & vbNewLine & _
            "	,tbl_tipo_horario.lunesout" & vbNewLine & _
            "	,tbl_tipo_horario.martesin" & vbNewLine & _
            "	,tbl_tipo_horario.martesout" & vbNewLine & _
            "	,tbl_tipo_horario.miercolesin" & vbNewLine & _
            "	,tbl_tipo_horario.miercolesout" & vbNewLine & _
            "	,tbl_tipo_horario.juevesin" & vbNewLine & _
            "	,tbl_tipo_horario.juevesout" & vbNewLine & _
            "	,tbl_tipo_horario.viernesin" & vbNewLine & _
            "	,tbl_tipo_horario.viernesout" & vbNewLine & _
            "	,tbl_tipo_horario.sabadoin" & vbNewLine & _
            "	,tbl_tipo_horario.sabadoout" & vbNewLine & _
            "	,tbl_tipo_horario.domingoin" & vbNewLine & _
            "	,tbl_tipo_horario.domingoout" & vbNewLine & _
            "	,tbl_tipo_horario.dia_feriado" & vbNewLine & _
            "	,tbl_tipo_horario.dia_feriado2" & vbNewLine & _
            "FROM tbl_horarioxEmpleado " & vbNewLine & _
            "	INNER JOIN tbl_tipo_horario ON tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine & _
            "	INNER JOIN view_sl_empleados ON tbl_horarioxEmpleado.empid = view_sl_empleados.EMPID" & vbNewLine & _
            "WHERE (tbl_horarioxEmpleado.empid IN (" & strSelec & "))" & vbNewLine & _
            "ORDER BY view_sl_empleados.DEPARTAMENTO" & vbNewLine & _
            "	,view_sl_empleados.SECCION"

        If Not IsNothing(dts.Tables("result")) Then
            dts.Tables("result").Clear()
        End If

        cnx.SQLEXEC(dts, strSQL, "result")

        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "result"
        pntexcel.titulo = "DETALLE DE HORARIOS"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub
End Class