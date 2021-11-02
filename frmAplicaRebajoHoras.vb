Public Class frmAplicaRebajoHoras

    Dim dts As New DataSet()
    Dim encontrado As Boolean

    Private Sub cargar(ByVal NPAGO As String)
        Dim strSQL As String = ""

        dts.Tables.Clear()

        strSQL = "DECLARE @x1 AS DATETIME" & vbNewLine & _
                 "DECLARE @x2 AS DATETIME" & vbNewLine & _
                 "SET @x1 = CONVERT(DATETIME,'" & dtpInicial.Value.ToShortDateString & "',103)" & vbNewLine & _
                 "SET @x2 = CONVERT(DATETIME,'" & dtpFinal.Value.ToShortDateString & " 23:59:59',103)" & vbNewLine & _
                 "EXEC sp_cargaMarcas @x1, @x2, '" & NPAGO & "'"

        If Not IsNothing(dts.Tables("tbl_marcas_procesadas")) Then
            dts.Tables("tbl_marcas_procesadas").Clear()
        End If
        cnx.consulta(dts, strSQL, "tbl_marcas_procesadas")

        DataGridView1.DataSource = dts
        DataGridView1.DataMember = "tbl_marcas_procesadas"
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.MultiSelect = False
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(6).DefaultCellStyle.Format = "n"

        DataGridView1.Columns(0).HeaderText = ""
        DataGridView1.Columns(1).HeaderText = "JUSTIFICADA"
        DataGridView1.Columns(2).HeaderText = "CÓDIGO"
        DataGridView1.Columns(3).HeaderText = "NOMBRE"
        DataGridView1.Columns(4).HeaderText = "ENTRADA"
        DataGridView1.Columns(5).HeaderText = "HORA ENTRA"
        DataGridView1.Columns(6).HeaderText = "HORAS REBAJAR"
        DataGridView1.Columns(7).HeaderText = "SALIDA"
        DataGridView1.Columns(8).HeaderText = "DETALLE1"
        DataGridView1.Columns(9).HeaderText = "DETALLE2"
        DataGridView1.Columns(10).HeaderText = "ID_INTERNO"
        DataGridView1.Columns(11).HeaderText = "ID_PROCESADO"
        DataGridView1.Columns(12).HeaderText = "JUSTIFICACIÓN"
        DataGridView1.Columns(13).HeaderText = "FECHA CALENDARIO"
        DataGridView1.Columns(14).HeaderText = "NUMERO PAGO"

        DataGridView1.Columns(7).Visible = False
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False
        DataGridView1.Columns(10).Visible = False
        DataGridView1.Columns(11).Visible = False
        DataGridView1.Columns(15).Visible = False

        DataGridView1.Columns(0).ReadOnly = False
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(4).ReadOnly = True
        DataGridView1.Columns(5).ReadOnly = True
        DataGridView1.Columns(6).ReadOnly = True
        DataGridView1.Columns(7).ReadOnly = True
        DataGridView1.Columns(8).ReadOnly = True
        DataGridView1.Columns(9).ReadOnly = True
        DataGridView1.Columns(10).ReadOnly = True
        DataGridView1.Columns(11).ReadOnly = True
        DataGridView1.Columns(12).ReadOnly = True
        DataGridView1.Columns(13).ReadOnly = True
        DataGridView1.Columns(14).ReadOnly = True

        DataGridView1.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(9).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(10).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(11).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(12).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(13).SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns(14).SortMode = DataGridViewColumnSortMode.NotSortable
        desActiva(True)

    End Sub

    Private Sub desActiva(ByVal activa As Boolean)
        tsbVerDetalle.Enabled = activa
        btnEditar.Enabled = activa
        btnRebajos.Enabled = activa
        tsbExcel.Enabled = activa
        chkAllNone.Visible = activa
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_marcas_procesadas").Rows.Count - 1 Then
            For i = 1 To DataGridView1.Columns.Count - 1
                strLinea += IIf(DataGridView1.Columns(i).Visible, dts.Tables("tbl_marcas_procesadas").Rows(pos).Item(DataGridView1.Columns(i).DataPropertyName).ToString & vbTab, "")
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

    Private Sub limpiar()

        If Not IsNothing(dts.Tables("tbl_marcas_procesadas")) Then
            dts.Tables("tbl_marcas_procesadas").Clear()
        End If

        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing

        desActiva(False)
        dtpInicial.Value = CType(IIf(Now.Day <= 15, "1/", "16/") & Now.Month & "/" & Now.Year, Date)
        dtpFinal.Value = IIf(Now.Day >= 16, _
                CType("1/" & IIf(Now.Month = 12, 1, Now.Month + 1) & "/" & IIf(Now.Month = 12, Now.Year + 1, Now.Year), Date).AddDays(-1), _
                CType("15/" & Now.Month & "/" & Now.Year, Date))
    End Sub

    Private Sub cargaGuardado()
        Dim fecha As Date
        Dim strnpago As String

        cnx.consulta(dts, "SELECT (SELECT DISTINCT numpago FROM tbl_marcas_procesadas_act) AS numpago," & _
                            "(SELECT MIN(entrada) AS minFecha FROM tbl_marcas_procesadas_act) AS inicial," & _
                            "(SELECT MAX(entrada) AS maxFecha FROM tbl_marcas_procesadas_act) AS final", "temp")

        strnpago = dts.Tables("temp").Rows(0).Item("numpago")
        fecha = dts.Tables("temp").Rows(0).Item("inicial")

        dts.Tables.Clear()

        dtpInicial.Value = CType(IIf(fecha.Day <= 15, "1/", "16/") & fecha.Month & "/" & fecha.Year, Date)
        dtpFinal.Value = IIf(Now.Day >= 16, _
                CType("1/" & IIf(fecha.Month = 12, 1, fecha.Month + 1) & "/" & IIf(fecha.Month = 12, fecha.Year + 1, fecha.Year), Date).AddDays(-1), _
                CType("15/" & fecha.Month & "/" & fecha.Year, Date))
        cargar(strnpago)
    End Sub

    Private Sub frmAplicaRebajoHoras_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim cargados As Boolean

        cnx.consulta(dts, "SELECT CAST(Existe AS bit) AS Existe FROM (SELECT COUNT(*) AS Existe FROM tbl_marcas_procesadas_act) AS A", "temp")
        cargados = dts.Tables("temp").Rows(0).Item("Existe")
        dts.Tables.Clear()

        If cargados Then
            cargaGuardado()
        Else
            desActiva(False)
            dtpInicial.Value = CType(IIf(Now.Day <= 15, "1/", "16/") & Now.Month & "/" & Now.Year, Date)
            dtpFinal.Value = IIf(Now.Day >= 16, _
                    CType("1/" & IIf(Now.Month = 12, 1, Now.Month + 1) & "/" & IIf(Now.Month = 12, Now.Year + 1, Now.Year), Date).AddDays(-1), _
                    CType("15/" & Now.Month & "/" & Now.Year, Date))
        End If

        desActiva(IIf(DataGridView1.RowCount = 0, False, True))

    End Sub

    Private Sub tsbVerDetalle_Click(sender As System.Object, e As System.EventArgs) Handles tsbVerDetalle.Click
        Dim obj As New frmDetalleMarcaProcesada()

        obj.MdiParent = Me.MdiParent
        obj.pnt = Me

        obj.txtCodigo.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("codigo")), "", _
                                 dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("codigo"))
        obj.txtNombre.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("nombre")), "", _
                                dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("nombre"))
        obj.txtMarcaEntrada.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("entrada")), "", _
                                       dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("entrada"))
        obj.txtDetalle1.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle1")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle1"))
        obj.txtHoraEntra.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horaentra")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horaentra"))
        obj.txtHorasRebajar.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horasrebajar")), "", _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horasrebajar"))
        obj.txtSalida.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("salida")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("salida"))
        obj.txtDetalle2.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle2")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle2"))
        obj.txtFechaCal.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("fechacal")), "", _
                                   dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("fechacal"))
        obj.txtJustificacion.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("justificacion")), "", _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("justificacion"))
        obj.chkAplicado.Checked = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("aplicada")), False, _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("aplicada"))
        obj.tsbGuardar.Visible = False
        obj.Show()
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Dim numpago As String = ""
        Dim pnt As New frmNumPago()

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            numpago = pnt.encPago
        End If
        pnt.Close()

        If numpago = "" Then
            Exit Sub
        End If

        If dtpInicial.Value > dtpFinal.Value Then
            mensajes("La fecha inicial no puede ser mayor a la fecha final")
            Exit Sub
        End If
        cargar(numpago)

    End Sub

    Private Sub chkAllNone_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAllNone.CheckedChanged
        Dim pos As Integer = BindingContext(dts, "tbl_marcas_procesadas").Position
        For i = 0 To dts.Tables("tbl_marcas_procesadas").Rows.Count - 1
            dts.Tables("tbl_marcas_procesadas").Rows(i).Item("SelectItem") = chkAllNone.Checked
        Next
        BindingContext(dts, "tbl_marcas_procesadas").Position = pos
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
                BindingContext(dts, "tbl_marcas_procesadas").Position = 0
            Case "tsbAnterior"
                BindingContext(dts, "tbl_marcas_procesadas").Position -= 1
            Case "tsbSiguiente"
                BindingContext(dts, "tbl_marcas_procesadas").Position += 1
            Case "tsbUltimo"
                BindingContext(dts, "tbl_marcas_procesadas").Position = dts.Tables("tbl_marcas_procesadas").Rows.Count - 1
        End Select
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_marcas_procesadas").Position + 1 & "/" & dts.Tables("tbl_marcas_procesadas").Rows.Count
    End Sub

    Private Sub btnLocalizar_Click(sender As System.Object, e As System.EventArgs) Handles btnLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_marcas_procesadas").Position + 1)
            BindingContext(dts, "tbl_marcas_procesadas").Position = IIf(localizado = -1, BindingContext(dts, "tbl_marcas_procesadas").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_marcas_procesadas").Position = IIf(localizado = -1, BindingContext(dts, "tbl_marcas_procesadas").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub tsbExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsbExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tbl_marcas_procesadas"
        pntexcel.titulo = "CONTROL DE MARCAS"
        pntexcel.filtro = "MARCAS DEL POR REBAJAR"
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim obj As New frmDetalleMarcaProcesada()

        obj.MdiParent = Me.MdiParent
        obj.pnt = Me
        obj.dts = dts
        obj.Text = "DATOS DE MARCAS PROCESADAS"
        obj._titulo1._text = "DATOS DE MARCAS PROCESADAS"

        obj.txtCodigo.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("codigo")), "", _
                                 dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("codigo"))
        obj.txtNombre.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("nombre")), "", _
                                dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("nombre"))
        obj.txtMarcaEntrada.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("entrada")), "", _
                                       dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("entrada"))
        obj.txtDetalle1.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle1")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle1"))
        obj.txtHoraEntra.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horaentra")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horaentra"))
        obj.txtHorasRebajar.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horasrebajar")), "", _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("horasrebajar"))
        obj.txtSalida.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("salida")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("salida"))
        obj.txtDetalle2.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle2")), "", _
                                    dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("detalle2"))
        obj.txtFechaCal.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("fechacal")), "", _
                                   dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("fechacal"))
        obj.txtJustificacion.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("justificacion")), "", _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("justificacion"))
        obj.chkAplicado.Checked = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("aplicada")), False, _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("aplicada"))

        obj.txtJustificacion.Text = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("justificacion")), "", _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("justificacion"))
        obj.chkAplicado.Checked = IIf(IsDBNull(dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("aplicada")), False, _
                                        dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("aplicada"))
        obj.idLinea = dts.Tables("tbl_marcas_procesadas").Rows(BindingContext(dts, "tbl_marcas_procesadas").Position).Item("id_Linea")
        obj.pos = BindingContext(dts, "tbl_marcas_procesadas").Position
        obj.txtHorasRebajar.Enabled = True
        obj.txtJustificacion.Enabled = True
        obj.chkAplicado.Enabled = True
        obj.tsbGuardar.Visible = True
        obj.Show()
    End Sub

    Private Sub btnRebajos_Click(sender As System.Object, e As System.EventArgs) Handles btnRebajos.Click
        Dim obj As New frmRabajos()
        obj.dts = dts
        obj.pnt = Me
        obj.Show()
    End Sub
End Class