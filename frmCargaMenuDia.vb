Public Class frmCargaMenuDia

    Dim dt As New DataTable
    Dim encontrado As Boolean = False

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dt.Rows.Count - 1 Then
            strLinea = dt.Rows(pos).Item("id_linea") & vbTab & _
                        dt.Rows(pos).Item("nom_archivo")
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
        lblRecActual.Text = "Registro #" & BindingContext(dt).Position + 1 & "/" & BindingContext(dt).Count

        DesActiva(IIf(BindingContext(dt).Count = 0, False, True))
        'For i = 0 To DataGridView1.Rows.Count - 1
        '    DataGridView1.Rows(i).DefaultCellStyle.BackColor = IIf(DataGridView1.Rows(i).Cells(24).Value = False, Color.LightGray, Color.White)
        'Next
    End Sub

    Private Sub DesActiva(ByVal pActiva As Boolean)
        GroupBox1.Enabled = pActiva
        DataGridView1.Enabled = pActiva
        btnEditar.Enabled = pActiva
        btnImprimir.Enabled = pActiva
        btnExcel.Enabled = pActiva
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
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dt).Position + 1)
            BindingContext(dt).Position = IIf(localizado = -1, BindingContext(dt).Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dt).Position = IIf(localizado = -1, BindingContext(dt).Position, localizado)
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
                BindingContext(dt).Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dt).Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dt).Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dt).Position = dt.Rows.Count - 1
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
            Dim strSQL As String = "SELECT id_linea,imagen,nom_archivo,cast(activa as bit) as activa,fecha FROM tbl_control_alimentacion_imagenes"
            cnx.SQLEXEC(dt, strSQL)

            DataGridView1.DataSource = dt
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).ReadOnly = True
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).HeaderText = "ID"
            DataGridView1.Columns(1).HeaderText = "IMAGEN"
            DataGridView1.Columns(2).HeaderText = "ARCHIVO"
            DataGridView1.Columns(3).HeaderText = "ACTIVA"
            DataGridView1.Columns(4).HeaderText = "CREADO"

            DataGridView1.Columns(0).Width = 50
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 150
            DataGridView1.Columns(3).Width = 50
            DataGridView1.Columns(4).Width = 120

            DataGridView1.Columns(1).Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.Close()
        End Try
    End Sub

    Private Sub frmCargaMenuDia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        RegActual()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim obj As New frmCargaMenuDia_Detalle()
        obj.MdiParent = Me.MdiParent
        obj.Owner = Me.Owner
        obj.frmOrigen = Me
        obj.nuevo = False
        obj.dt = dt
        obj.pos = BindingContext(dt).Position
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub btnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles btnNuevo.Click
        Dim obj As New frmCargaMenuDia_Detalle()
        obj.MdiParent = Me.MdiParent
        obj.Owner = Me.Owner
        obj.frmOrigen = Me
        obj.nuevo = True
        obj.dt = dt
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        btnEditar.PerformClick()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        btnSalir.PerformClick()
    End Sub

    Private Sub btnAnular_Click(sender As System.Object, e As System.EventArgs) Handles btnAnular.Click
        Try
            If MessageBox.Show("Se dispone a eliminar el registro #" & _
                                dt.Rows(BindingContext(dt).Position).Item("nom_archivo") & "." & vbNewLine & _
                                "¿ Esta seguro de proceder ?", "ANULAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            If dt.Rows.Count = 0 Then
                Exit Sub
            End If
            Dim pos As Integer = BindingContext(dt).Position
            Dim strSQL As String = _
                "BEGIN TRY" & vbNewLine & _
                "	BEGIN transaction" & vbNewLine & _
                "	SET NOCOUNT ON;" & vbNewLine & _
                "   DECLARE @nDoc AS NUMERIC(18,0)" & vbNewLine & _
                "   SET @nDoc = " & dt.Rows(pos).Item("id_linea") & vbNewLine & _
                "   " & vbNewLine & _
                "   DELETE FROM tbl_control_alimentacion_imagenes WHERE id_linea = @nDoc" & vbNewLine & _
                "END TRY" & vbNewLine & _
                "BEGIN CATCH" & vbNewLine & _
                "	IF @@TRANCOUNT > 0" & vbNewLine & _
                "		ROLLBACK TRANSACTION;" & vbNewLine & _
                "		DECLARE @ErrorMessage NVARCHAR(4000);" & vbNewLine & _
                "		DECLARE @ErrorSeverity INT;" & vbNewLine & _
                "		DECLARE @ErrorState INT;" & vbNewLine & _
                "" & vbNewLine & _
                "		SET @ErrorMessage = ERROR_MESSAGE()" & vbNewLine & _
                "		SET @ErrorSeverity = ERROR_SEVERITY()" & vbNewLine & _
                "		SET @ErrorState = ERROR_STATE();" & vbNewLine & _
                "" & vbNewLine & _
                "	    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);" & vbNewLine & _
                "END CATCH;" & vbNewLine & _
                "IF @@TRANCOUNT > 0" & vbNewLine & _
                "	COMMIT TRANSACTION;"
            cnx.SQLEXEC(strSQL)
            dt.Rows.Clear()
            CargaGrid()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

End Class