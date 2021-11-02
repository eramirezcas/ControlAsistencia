Public Class frmIngresosDelDia

    Dim dts As New DataSet()
    Dim encontrado As Boolean = False

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_ingresos").Rows.Count - 1 Then
            For i = 0 To 4
                strLinea = dts.Tables("tbl_ingresos").Rows(pos).Item("DEPARTAMENTO") & vbTab & _
                        dts.Tables("tbl_ingresos").Rows(pos).Item("SECCION") & vbTab & _
                        dts.Tables("tbl_ingresos").Rows(pos).Item("codigo") & vbTab & _
                        dts.Tables("tbl_ingresos").Rows(pos).Item("nombre")

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
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_ingresos").Position + 1 & "/" & BindingContext(dts, "tbl_ingresos").Count

        DesActiva(IIf(BindingContext(dts, "tbl_ingresos").Count = 0, False, True))
    End Sub

    Private Sub DesActiva(ByVal pActiva As Boolean)
        GroupBox1.Enabled = pActiva
        DataGridView1.Enabled = pActiva
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
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_ingresos").Position + 1)
            BindingContext(dts, "tbl_ingresos").Position = IIf(localizado = -1, BindingContext(dts, "tbl_ingresos").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_ingresos").Position = IIf(localizado = -1, BindingContext(dts, "tbl_ingresos").Position, localizado)
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
                BindingContext(dts, "tbl_ingresos").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_ingresos").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_ingresos").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_ingresos").Position = dts.Tables("tbl_ingresos").Rows.Count - 1
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
            If dts.Tables.Contains("tbl_ingresos") Then
                dts.Tables.Remove("tbl_ingresos")
            End If

            Dim strSQL As String = _
                "SELECT view_sl_empleados.DEPARTAMENTO" & vbNewLine & _
                "	,view_sl_empleados.SECCION" & vbNewLine & _
                "	,tbl_marcas.codigo" & vbNewLine & _
                "	,tbl_marcas.nombre" & vbNewLine & _
                "	,tbl_marcas.entrada" & vbNewLine & _
                "	,tbl_marcas.salida" & vbNewLine & _
                "	,tbl_marcas.detalle1" & vbNewLine & _
                "	,tbl_marcas.detalle2" & vbNewLine & _
                "--	,tbl_marcas.Id_Interno" & vbNewLine & _
                "--	,tbl_marcas.id_procesado" & vbNewLine & _
                "--	,tbl_marcas.justificacion" & vbNewLine & _
                "	,tbl_marcas.timeStamp" & vbNewLine & _
                "--	,tbl_marcas.numpago" & vbNewLine & _
                "	,tbl_marcas.id_horario" & vbNewLine & _
                "	,tbl_marcas.id_horario_sale" & vbNewLine & _
                "--	,tbl_marcas.proc_extras" & vbNewLine & _
                "	,tbl_marcas.Tipo_Marca_entrda" & vbNewLine & _
                "	,tbl_marcas.Tipo_Marca_salida" & vbNewLine & _
                "	,tbl_marcas.ubicacion_entra" & vbNewLine & _
                "	,tbl_marcas.ubicacion_salida" & vbNewLine & _
                "FROM tbl_marcas INNER JOIN view_sl_empleados ON tbl_marcas.codigo COLLATE SQL_Latin1_General_CP1_CI_AS = view_sl_empleados.EMPID" & vbNewLine & _
                "WHERE (tbl_marcas.timeStamp >= CONVERT(datetime, '18/09/2017', 103))" & vbNewLine & _
                "ORDER BY 1,2"

            If Not IsNothing(dts.Tables("tbl_ingresos")) Then
                dts.Tables("tbl_ingresos").Clear()
            End If

            cnx.SQLEXEC(dts, strSQL, "tbl_ingresos")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_ingresos"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToResizeColumns = True
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.RowHeadersVisible = False
            DataGridView1.Font = New Font("Arial", 7, FontStyle.Regular)
            DataGridView1.ReadOnly = True

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            For i = 0 To DataGridView1.ColumnCount - 1
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

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
        Label1.Text = FormatDateTime(Now.Date(), DateFormat.LongDate)
        CargaGrid()
        RegActual()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tbl_ingresos"
        pntexcel.titulo = "DETALLE INGRESOS DEL DIA"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub
End Class