Public Class frmGenerarCargadorAlimentacion
    Dim numNomi As Integer
    Dim fecha_ini As DateTime
    Dim dt As New DataTable
    Dim encontrado As Boolean = False

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dt.Rows.Count - 1 Then
            strLinea = dt.Rows(pos).Item("codigo") & vbTab & _
                        dt.Rows(pos).Item("nombre")
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

        desActiva(IIf(BindingContext(dt).Count = 0, False, True))
        'For i = 0 To DataGridView1.Rows.Count - 1
        '    DataGridView1.Rows(i).DefaultCellStyle.BackColor = IIf(DataGridView1.Rows(i).Cells(24).Value = False, Color.LightGray, Color.White)
        'Next
    End Sub
    Private Sub desActiva(ByVal pActiva As Boolean)
        Try
            btnCargar.Enabled = Not pActiva
            btnImportar.Enabled = pActiva
            If numNomi = 0 Then
                btnImportar.Enabled = False
                btnExportaexcel.Enabled = False
            Else
                btnImportar.Enabled = pActiva
                btnExportaexcel.Enabled = pActiva
            End If
            btnRefresh.Enabled = Not pActiva
            btnLimpiar.Enabled = pActiva
        Catch ex As Exception
            Throw ex
        End Try
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

    Private Sub refrescar()
        Try
            Dim tmp As New DataTable
            Dim strSQL As String =
                "SELECT NUMERO_NOMINA, FECHA_INICIO, FECHA_FIN, FECHA_APLICACION" & vbNewLine &
                "FROM SOFTLAND.CRCC01.NOMINA_HISTORICO" & vbNewLine &
                "WHERE NUMERO_NOMINA = (SELECT MAX(NUMERO_NOMINA) FROM SOFTLAND.CRCC01.NOMINA_HISTORICO)"
            cnx.SQLEXEC(tmp, strSQL)

            If IsDBNull(tmp.Rows(0).Item("FECHA_APLICACION")) Then
                numNomi = tmp.Rows(0).Item("NUMERO_NOMINA")
                fecha_ini = tmp.Rows(0).Item("FECHA_INICIO")
                numNomi = tmp.Rows(0).Item("NUMERO_NOMINA")
            Else
                numNomi = 0
            End If

            If numNomi = 0 Then
                Label1.Text = "Nómina no inicializada"
            Else
                Label1.Text = "Nómina #:" & numNomi.ToString.Trim() & " del " & Format(tmp.Rows(0).Item("FECHA_INICIO"), "dd/MM/yyyy") & _
                                                                    " al " & Format(tmp.Rows(0).Item("FECHA_FIN"), "dd/MM/yyyy")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub CargaGrid()
        Try

            DataGridView1.DataSource = dt
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.RowHeadersVisible = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).ReadOnly = True
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).HeaderText = "CÓDIGO"
            DataGridView1.Columns(1).HeaderText = "NOMBRE"
            DataGridView1.Columns(2).HeaderText = "MONTO"
            DataGridView1.Columns(3).HeaderText = "CANT."

            DataGridView1.Columns(0).Width = 60
            DataGridView1.Columns(1).Width = 200
            DataGridView1.Columns(2).Width = 100
            DataGridView1.Columns(3).Width = 100


        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmGenerarCargadorAlimentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            refrescar()
            desActiva(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Try
            Dim strsql As String

            If numNomi = 0 Then
                If MessageBox.Show("Nómina no inicializada. No podrá importar datos a menos de que la nómina este inicializada." & _
                                    vbNewLine & "Desea continuar en modo de consulta ? ", "IMPORTAR DATOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
                strsql = _
                    "SELECT CODIGO_EMPLEADO AS CODIGO,NOMBRE,SUM(precio) AS MONTO,COUNT(*) AS CANTIDAD" & vbNewLine & _
                    "FROM tbl_control_alimentacion_ventas_hist" & vbNewLine & _
                    "WHERE numero_nómina IS NULL AND esAutimatico = 1 and utilizado =1" & vbNewLine & _
                    "GROUP BY codigo_empleado,nombre,id_tipo_servicio,detalle"
            Else
                strsql = _
                    "SELECT CODIGO_EMPLEADO AS CODIGO,NOMBRE,SUM(precio) AS MONTO,COUNT(*) AS CANTIDAD" & vbNewLine & _
                    "FROM tbl_control_alimentacion_ventas_hist" & vbNewLine & _
                    "WHERE numero_nómina IS NULL AND esAutimatico = 1 AND utilizado =1 AND fecha_creado < CONVERT(DATETIME, '" & Format(fecha_ini, "dd/MM/yyyy") & "',103)" & vbNewLine & _
                    "GROUP BY codigo_empleado,nombre,id_tipo_servicio,detalle"
            End If
            desActiva(True)



            cnx.SQLEXEC(dt, strsql)
            CargaGrid()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Try
            dt.Rows.Clear()
            desActiva(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            refrescar()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            If MessageBox.Show("Este proceso se puede generar solo una vez por lo que despues de haber importado ya no podra hacerlo de nuevo." & _
                                vbNewLine & "¿ Seguro de proceder ? ", "IMPORTAR DATOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            btnExportaexcel.PerformClick()

            Dim strSQL As String = _
                        "BEGIN TRY" & vbNewLine & _
                        "BEGIN TRANSACTION" & vbNewLine & _
                        "----------------------------------------------------------------------------------------------------------------------------" & vbNewLine & _
                        "   UPDATE tbl_control_alimentacion_ventas_hist" & vbNewLine & _
                        "   SET" & vbNewLine & _
                        "       numero_nómina =" & numNomi.ToString.Trim() & vbNewLine & _
                        "   WHERE numero_nómina IS NULL AND esAutimatico = 1 AND fecha_creado < CONVERT(DATETIME, '" & Format(fecha_ini, "dd/MM/yyyy") & "',103)" & vbNewLine & _
                        "----------------------------------------------------------------------------------------------------------------------------" & vbNewLine & _
                        "END TRY" & vbNewLine & _
                        "BEGIN CATCH" & vbNewLine & _
                        "	IF @@TRANCOUNT > 0" & vbNewLine & _
                        "		ROLLBACK TRANSACTION;" & vbNewLine & _
                        "" & vbNewLine & _
                        "		DECLARE @ErrorMessage NVARCHAR(4000);" & vbNewLine & _
                        "		DECLARE @ErrorSeverity INT;" & vbNewLine & _
                        "		DECLARE @ErrorState INT;" & vbNewLine & _
                        "" & vbNewLine & _
                        "		SET @ErrorMessage = ERROR_MESSAGE()" & vbNewLine & _
                        "		SET @ErrorSeverity = ERROR_SEVERITY()" & vbNewLine & _
                        "		SET @ErrorState = ERROR_STATE()" & vbNewLine & _
                        "" & vbNewLine & _
                        "		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);" & vbNewLine & _
                        "END CATCH;" & vbNewLine & _
                        "IF @@TRANCOUNT > 0" & vbNewLine & _
                        "	COMMIT TRANSACTION;"
            cnx.SQLEXEC(strSQL)
            refrescar()
            desActiva(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExportaexcel_Click(sender As Object, e As EventArgs) Handles btnExportaexcel.Click
        Try
            Dim xlApp As Microsoft.Office.Interop.Excel.Application
            Dim xlWkb As Microsoft.Office.Interop.Excel.Workbook
            Dim xlSht As Microsoft.Office.Interop.Excel.Worksheet
            Dim fil As Integer = 1, col As Integer = 1

            xlApp = CreateObject("Excel.Application")
            xlWkb = xlApp.Workbooks.Add()
            xlSht = xlWkb.ActiveSheet

            xlSht.Cells(fil, col) = "COSTA RICA COUNTRY CLUB S.A."
            xlSht.Cells(fil, col).Font.Bold = True
            xlSht.Cells(fil, col).Font.Size = 12

            xlSht.Cells(fil + 1, col) = "ARCHIVO DE CARGA DE REBAJOS"
            xlSht.Cells(fil + 1, col).Font.Bold = True
            xlSht.Cells(fil + 1, col).Font.Size = 12


            xlSht.Cells(fil + 3, col) = "CODIGO"
            xlSht.Cells(fil + 3, col + 1) = "NOMBRE"
            xlSht.Cells(fil + 3, col + 2) = "MONTO"
            xlSht.Cells(fil + 3, col + 3) = "CANTIDAD"

            For i As Integer = 0 To dt.Rows.Count - 1
                xlSht.Cells((fil + 4) + i, col) = dt.Rows(i).Item("CODIGO")
                xlSht.Cells((fil + 4) + i, col + 1) = dt.Rows(i).Item("NOMBRE")
                xlSht.Cells((fil + 4) + i, col + 2) = dt.Rows(i).Item("MONTO")
                xlSht.Cells((fil + 4) + i, col + 3) = dt.Rows(i).Item("CANTIDAD")
            Next

            'xlSht.Columns.AutoFit()
            xlApp.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnVerDetalle_Click(sender As Object, e As EventArgs) Handles btnVerDetalle.Click
        Dim frm As New frmGenerarCargadorAlimentacionVerDetalle()
        Dim pos As Integer = BindingContext(dt).Position
        frm.pCodigo = dt.Rows(pos).Item("codigo")
        frm.MdiParent = Me.MdiParent
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub btnCancelar_Click_1(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class