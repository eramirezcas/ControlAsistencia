Imports System.Drawing.Drawing2D

Public Class FrmMantenimentotipohorario
    Dim encontrado As Boolean = False
    Dim dts As New DataSet
    Dim valor = 2
    Public Opcion As Integer = 1

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_Tipo_Horario").Rows.Count - 1 Then
            For i = 0 To dataGridView1.Columns.Count - 1
                strLinea += dts.Tables("tbl_Tipo_Horario").Rows(pos).Item(dataGridView1.Columns(i).DataPropertyName).ToString & vbTab
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
            If dts.Tables.Contains("tbl_tipo_horario") Then
                dts.Tables("tbl_tipo_horario").Rows.Clear()
            End If

            cnx.SQLEXEC(dts, "Select * from tbl_tipo_horario", "tbl_Tipo_Horario")
            dataGridView1.DataSource = dts
            dataGridView1.DataMember = "tbl_Tipo_Horario"

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dataGridView1.AllowUserToAddRows = False
            dataGridView1.AllowUserToResizeColumns = False
            dataGridView1.AllowUserToDeleteRows = False
            dataGridView1.AllowUserToResizeRows = False
            dataGridView1.MultiSelect = False
            dataGridView1.ReadOnly = True

            For i = 0 To dataGridView1.Columns.Count - 1
                dataGridView1.Columns(i).Visible = False
            Next

            dataGridView1.Columns(0).Visible = True
            dataGridView1.Columns(0).HeaderText = "ID"
            dataGridView1.Columns(0).DataPropertyName = "id_horario"
            dataGridView1.Columns(0).Width = 40
            dataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable

            dataGridView1.Columns(1).Visible = True
            dataGridView1.Columns(1).HeaderText = "HORARIO"
            dataGridView1.Columns(1).DataPropertyName = "detalle"
            dataGridView1.Columns(1).Width = 200
            dataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

            dataGridView1.Columns(18).Visible = True
            dataGridView1.Columns(18).HeaderText = "ACTIVO"
            dataGridView1.Columns(18).DataPropertyName = "activo"
            dataGridView1.Columns(18).Width = 90
            dataGridView1.Columns(18).SortMode = DataGridViewColumnSortMode.NotSortable
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Display)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_Tipo_Horario").Position + 1 & "/" & BindingContext(dts, "tbl_Tipo_Horario").Count
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub FrmMantenimentotipohorario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        BindingContext(dts, "tbl_Tipo_Horario").Position = 0
        RegActual()
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Dim pnt As New FrmDatosMantenimientoHorarios()
        pnt.dts = dts
        pnt.MdiParent = Me.MdiParent
        pnt.nuevo = True
        dts.Tables("tbl_Tipo_Horario").Rows.Add()
        BindingContext(dts, "tbl_Tipo_Horario").Position = dts.Tables("tbl_Tipo_Horario").Rows.Count - 1
        pnt.pos = BindingContext(dts, "tbl_Tipo_Horario").Position
        pnt.pnt = Me
        pnt.Show()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub txtLocalizar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_Tipo_Horario").Position + 1)
            BindingContext(dts, "tbl_Tipo_Horario").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Tipo_Horario").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_Tipo_Horario").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Tipo_Horario").Position, localizado)
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
                BindingContext(dts, "tbl_Tipo_Horario").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_Tipo_Horario").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_Tipo_Horario").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_Tipo_Horario").Position = dts.Tables("tbl_Tipo_Horario").Rows.Count - 1
        End Select
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tbl_Tipo_Horario"
        pntexcel.titulo = "HORARIOS"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub dataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellDoubleClick

    End Sub

    Private Sub dataGridView1_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellEnter
        RegActual()
    End Sub

    Private Sub btnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles btnEliminar.Click
        Try
            Dim pos As Integer = BindingContext(dts, "tbl_Tipo_Horario").Position
            If MessageBox.Show("Se dispone a eliminar el horario: """ & _
                               dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("id_horario") & "|" & _
                               dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("detalle") & """." & vbNewLine & _
                               "Seguro de Procede?", "ELIMINAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            cnx.SQLEXEC(dts, "SELECT empId, Nombre FROM tbl_horarioxempleado WHERE id_horario = " & dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("id_horario"), "QTMP")

            If dts.Tables("QTMP").Rows.Count = 0 Then
                Dim strSQL As String = "DELETE FROM tbl_Tipo_Horario WHERE id_horario = " & dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("id_horario")
                cnx.SQLEXEC(strSQL)

                dts.Tables.Remove("QTMP")
                CargaGrid()

            Else
                Dim mensaje As String = "No se puede eliminar el horario por que esta siendo utilizado:" & vbNewLine & vbNewLine
                For i As Integer = 1 To dts.Tables("QTMP").Rows.Count - 1
                    mensaje += dts.Tables("QTMP").Rows(i).Item("empID") & vbTab & "| " & dts.Tables("QTMP").Rows(i).Item("nombre") & vbNewLine
                Next
                mensaje += vbNewLine & "Verifique e intente de nuevo."
                MessageBox.Show(mensaje, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)

                dts.Tables.Remove("QTMP")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Dim pnt As New FrmDatosMantenimientoHorarios()
        pnt.dts = dts
        pnt.MdiParent = Me.MdiParent
        pnt.nuevo = False
        pnt.pos = BindingContext(dts, "tbl_Tipo_Horario").Position
        pnt.pnt = Me
        pnt.Show()
    End Sub
End Class
