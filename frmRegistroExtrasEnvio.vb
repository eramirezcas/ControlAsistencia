Public Class frmRegistroExtrasEnvio

    Dim dts As New DataSet()
    Dim encontrado As Boolean = False

    Private Function ValidaSeleccion() As Boolean
        For i = 0 To dts.Tables("tbl_extras").Rows.Count - 1
            If dts.Tables("tbl_extras").Rows(i).Item("SelectItem") Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function envioActualiza() As Boolean
        Try
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = dts.Tables("tbl_extras").Rows.Count - 1
            gbProgreso.Visible = True
            For i = 0 To dts.Tables("tbl_extras").Rows.Count - 1
                If dts.Tables("tbl_extras").Rows(i).Item("SelectItem") Then
                    Dim strSQL As String = _
                        "BEGIN TRY" & vbNewLine & _
                        "	BEGIN TRANSACTION" & vbNewLine & _
                        "	SET NOCOUNT ON;" & vbNewLine & _
                        "	" & vbNewLine & _
                        "   UPDATE tbl_Extras SET" & vbNewLine & _
                        "   	  empid_jefe =" & pempID & vbNewLine & _
                        "   	, nombre_jefe ='" & pNombreUser & vbNewLine & "'" & _
                        "   	, fecha_aplica_jefe = GETDATE()" & vbNewLine & _
                        "   	, estatus ='PENDIENTE DE PROBACION DE GERENTE'" & vbNewLine & _
                        "   	, estatus_nivel =1" & vbNewLine & _
                        "   WHERE (id_linea = " & dts.Tables("tbl_extras").Rows(i).Item("ID_LINEA") & ")" & vbNewLine & _
                        "   " & vbNewLine & _
                        "   INSERT INTO tbl_extras_bitacora(nDocumento, nivel_estado, estado, detalle, fecha, computername, username)" & vbNewLine & _
                        "   VALUES (" & vbNewLine & _
                        "        " & dts.Tables("tbl_Extras").Rows(i).Item("nDocumento") & vbNewLine & _
                        "      , " & dts.Tables("tbl_Extras").Rows(i).Item("estatus_nivel") & vbNewLine & _
                        "      ,'PENDIENTE DE APROBACIÓN GERENCIA'" & vbNewLine & _
                        "      ,'ENVIO DE REGISTROS PARA APROBACION EXITOSO'" & vbNewLine & _
                        "      , getDate()" & vbNewLine & _
                        "      ,'" & Environment.MachineName.ToUpper.Trim & "'" & vbNewLine & _
                        "      ,'" & Environment.UserName.ToUpper.Trim & "'" & vbNewLine & _
                        "      )" & vbNewLine & _
                        "	" & vbNewLine & _
                        "END TRY" & vbNewLine & _
                        "BEGIN CATCH" & vbNewLine & _
                        "	IF @@TRANCOUNT > 0" & vbNewLine & _
                        "		ROLLBACK TRANSACTION;" & vbNewLine & _
                        "		DECLARE @ErrorMessage NVARCHAR(4000);" & vbNewLine & _
                        "		DECLARE @ErrorSeverity INT;" & vbNewLine & _
                        "		DECLARE @ErrorState INT;" & vbNewLine & _
                        "		" & vbNewLine & _
                        "		SET @ErrorMessage = ERROR_MESSAGE()" & vbNewLine & _
                        "		SET @ErrorSeverity = ERROR_SEVERITY()" & vbNewLine & _
                        "		SET @ErrorState = ERROR_STATE();" & vbNewLine & _
                        "		" & vbNewLine & _
                        "	    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);" & vbNewLine & _
                        "END CATCH;" & vbNewLine & _
                        "IF @@TRANCOUNT > 0" & vbNewLine & _
                        "	COMMIT TRANSACTION;"

                    cnx.SQLEXEC(dts, strSQL, "tbl_extras")

                End If
                ProgressBar1.Value = i
            Next
            gbProgreso.Visible = False
            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return False
        End Try
    End Function

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_Extras").Rows.Count - 1 Then
            For i = 0 To 3
                strLinea = dts.Tables("tbl_Extras").Rows(pos).Item("nDocumento") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("empID") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_empleado") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_seccion") & vbTab & _
                        dts.Tables("tbl_Extras").Rows(pos).Item("Fecha")
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
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_Extras").Position + 1 & "/" & BindingContext(dts, "tbl_Extras").Count

        DesActiva(IIf(BindingContext(dts, "tbl_Extras").Count = 0, False, True))
        'For i = 0 To DataGridView1.Rows.Count - 1
        '    DataGridView1.Rows(i).DefaultCellStyle.BackColor = IIf(DataGridView1.Rows(i).Cells(24).Value = False, Color.LightGray, Color.White)
        'Next
    End Sub

    Private Sub DesActiva(ByVal pActiva As Boolean)
        GroupBox1.Enabled = pActiva
        DataGridView1.Enabled = pActiva
        btnEnviarGurpo.Enabled = pActiva
        chkSelAllNone.Enabled = pActiva
        Button1.Visible = Not pActiva
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
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_Extras").Position + 1)
            BindingContext(dts, "tbl_Extras").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Extras").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_Extras").Position = IIf(localizado = -1, BindingContext(dts, "tbl_Extras").Position, localizado)
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
                BindingContext(dts, "tbl_Extras").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_Extras").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_Extras").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_Extras").Position = dts.Tables("tbl_Extras").Rows.Count - 1
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
            If dts.Tables.Contains("tbl_extras") Then
                dts.Tables.Remove("tbl_extras")
            End If

            Dim strSQL As String = "SELECT CAST(0 as bit) as selectItem, id_linea, nDocumento, empID, nombre_empleado, id_Departamento, nombre_departamento," & vbNewLine & _
                                   "	id_Seccion, nombre_seccion, Salario_Hora, Fecha," & vbNewLine & _
                                   "	CASE WHEN marca_entrada = CONVERT(DATETIME,'',103) THEN NULL ELSE marca_entrada END AS marca_entrada," & vbNewLine & _
                                   "	CASE WHEN horario_entrada = CONVERT(DATETIME,'',103) THEN NULL ELSE horario_entrada END AS horario_entrada," & vbNewLine & _
                                   "	CASE WHEN marca_salida = CONVERT(DATETIME,'',103) THEN NULL ELSE marca_salida END AS marca_salida," & vbNewLine & _
                                   "	CASE WHEN horario_salida = CONVERT(DATETIME,'',103) THEN NULL ELSE horario_salida END AS horario_salida," & vbNewLine & _
                                   "	diferencia_entrada, diferencia_salida, estado_marca, cantidad_horas_sencillas," & vbNewLine & _
                                   "	cantidad_horas_tmedio, cantidad_horas_dobles, cantidad_horas_feriado, Monto_Total," & vbNewLine & _
                                   "	justificacion_automatica, estatus, estatus_nivel, Motivo, CuentaContCosto, CuentaContPresu," & vbNewLine & _
                                   "	empid_jefe, nombre_jefe, fecha_aplica_jefe, empID_gerente, nombre_gerente, fecha_aplica_gerente," & vbNewLine & _
                                   "	empID_rh, nombre_rh, fecha_aplica_rh, fecha_aplica_plani, numero_pago, fecha_cierre, Id_Uduario," & vbNewLine & _
                                   "	ComputerName, UserName, time_stamp" & vbNewLine & _
                                   "FROM tbl_Extras" & vbNewLine & _
                                   "WHERE (estatus_nivel = 0)" & IIf(verTodos, "", " AND (empID in (select empid from view_sl_empleados as E where " & IIf(pEsGerente, "E.gerente", "E.jefe") & " = " & pempID & "))") & vbNewLine & _
                                   "ORDER BY nombre_departamento, nombre_seccion, empID"

            If Not IsNothing(dts.Tables("tbl_Extras")) Then
                dts.Tables("tbl_Extras").Clear()
            End If

            cnx.SQLEXEC(dts, strSQL, "tbl_Extras")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_Extras"
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

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).ReadOnly = True
                DataGridView1.Columns(i).Visible = False
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).ReadOnly = False

            DataGridView1.Columns(0).HeaderText = ""
            DataGridView1.Columns(2).HeaderText = "#DOC"
            DataGridView1.Columns(3).HeaderText = "Código"
            DataGridView1.Columns(4).HeaderText = "Nombre"
            DataGridView1.Columns(6).HeaderText = "Departamento"
            DataGridView1.Columns(8).HeaderText = "Sección"
            DataGridView1.Columns(10).HeaderText = "Fecha"
            DataGridView1.Columns(23).HeaderText = "Justificación automática"
            DataGridView1.Columns(26).HeaderText = "Motivo"

            DataGridView1.Columns(0).Width = 40
            DataGridView1.Columns(2).Width = 40
            DataGridView1.Columns(3).Width = 50
            DataGridView1.Columns(4).Width = 160
            DataGridView1.Columns(7).Width = 100
            DataGridView1.Columns(8).Width = 100
            DataGridView1.Columns(10).Width = 70
            DataGridView1.Columns(23).Width = 220
            DataGridView1.Columns(26).Width = 190

            DataGridView1.Columns(0).DisplayIndex = 0
            DataGridView1.Columns(2).DisplayIndex = 1
            DataGridView1.Columns(3).DisplayIndex = 2
            DataGridView1.Columns(4).DisplayIndex = 3
            DataGridView1.Columns(10).DisplayIndex = 4
            DataGridView1.Columns(26).DisplayIndex = 5
            DataGridView1.Columns(23).DisplayIndex = 7
            DataGridView1.Columns(6).DisplayIndex = 8
            DataGridView1.Columns(8).DisplayIndex = 9

            DataGridView1.Columns(0).Visible = True
            DataGridView1.Columns(2).Visible = True
            DataGridView1.Columns(3).Visible = True
            DataGridView1.Columns(4).Visible = True
            DataGridView1.Columns(6).Visible = True
            DataGridView1.Columns(8).Visible = True
            DataGridView1.Columns(10).Visible = True
            DataGridView1.Columns(23).Visible = True
            DataGridView1.Columns(26).Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Dim obj As New frmMensage()
        obj.lblMensage.Text = "Se dispone a salir y a seleccionado uno o varios items, " & vbNewLine & _
                              "todos los cambios realizados se perderán." & vbNewLine & _
                              "¿ Seguro de proceder ?."
        obj.Text = "ADVERTENCIA !!!"

        If ValidaSeleccion() Then
            If obj.ShowDialog = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If
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

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub chkSelAllNone_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSelAllNone.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)
        Dim pos As ULong = BindingContext(dts, "tbl_Extras").Position
        For i = 0 To dts.Tables("tbl_Extras").Rows.Count - 1
            dts.Tables("tbl_Extras").Rows(i).Item("SelectItem") = obj.Checked
        Next
        BindingContext(dts, "tbl_Extras").Position = pos
        DataGridView1.Refresh()
    End Sub

    Private Sub btnEnviarGurpo_Click(sender As System.Object, e As System.EventArgs) Handles btnEnviarGurpo.Click
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        If Not ValidaSeleccion() Then
            MessageBox.Show("Debe seleccionar al menos un item para poder realizar el proceso", _
                            "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If MessageBox.Show("Se dispone a realizar el envio de registro de extras a 'Aprobación de gerencia'." & vbNewLine & _
                           "¿ Esta seguro de prodecer ?.", "REALIZAR ENVIO !!!", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If envioActualiza() Then
            MessageBox.Show("Proceso de envío realizado con éxito.", "ENVÍO PARA APROBACIÓN !!!", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Close()
        End If
    End Sub
End Class