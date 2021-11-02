'Delegate Sub FunctionCall(ByVal param)

Public Class frmRHDRegistroHuellaDigital

    Dim dts As New DataSet()
    Dim encontrado As Boolean = False
    Dim estaVerificada As Boolean = False
    Dim existeHuella As Boolean = False

    '**********************************************************************************************************************************************
    '**********************************************************************************************************************************************

    Private Sub OnTemplate(ByVal template)
        Invoke(New FunctionCall(AddressOf _OnTemplate), template)
    End Sub

    Private Sub _OnTemplate(ByVal template)
        Me.Template = template
        btnVerificar.Enabled = (Not template Is Nothing)
        btnGuardar.Enabled = (Not template Is Nothing)
        If Not template Is Nothing Then
            estaVerificada = True
            'MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment")
        Else
            estaVerificada = False
            'MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment")
        End If
    End Sub

    Private Template As DPFP.Template
    '**********************************************************************************************************************************************
    '**********************************************************************************************************************************************

    Private Sub cargaTemplate()
        Dim byteArr() As Byte = dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("huella")
        Dim memStream As New System.IO.MemoryStream(byteArr)
        Dim tmpTemplate As New DPFP.Template(memStream)
        Template = tmpTemplate
        OnTemplate(Template)
    End Sub

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""
        If pos <= dts.Tables("tbl_empleados_sap").Rows.Count - 1 Then
            For i = 0 To 3
                strLinea += dts.Tables("tbl_empleados_sap").Rows(pos).Item(DataGridView1.Columns(i).DataPropertyName).ToString & vbTab
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
        lblRecActual.Text = "Registro #" & BindingContext(dts, "tbl_empleados_sap").Position + 1 & "/" & BindingContext(dts, "tbl_empleados_sap").Count

        GroupBox1.Enabled = IIf(BindingContext(dts, "tbl_empleados_sap").Count = 0, False, True)
        If Not IsDBNull(dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("huella")) Then
            cargaTemplate()
        End If
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tbl_empleados_sap").Position + 1)
            BindingContext(dts, "tbl_empleados_sap").Position = IIf(localizado = -1, BindingContext(dts, "tbl_empleados_sap").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tbl_empleados_sap").Position = IIf(localizado = -1, BindingContext(dts, "tbl_empleados_sap").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub tsbPrimero_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrimero.Click, tsbSiguiente.Click, tsbAnterior.Click, tsbUltimo.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dts, "tbl_empleados_sap").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tbl_empleados_sap").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tbl_empleados_sap").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tbl_empleados_sap").Position = dts.Tables("tbl_empleados_sap").Rows.Count - 1
        End Select
    End Sub

    Private Sub DataGridView_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        RegActual()
    End Sub

    Private Sub txtLocalizar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            pctLocalizar.PerformClick()
        End If
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub

    Public Sub CargaGrid()
        Try
            'Dim strSQL As String =
            '"SELECT vE.DEPARTAMENTO, vE.SECCION, vE.EMPID, vE.PRIMER_APELLIDO, vE.SEGUNDO_APELLIDO," & vbNewLine &
            '"	vE.NOMBRE_PILA, vE.IDENTIFICACION, vE.FECHA_INGRESO, vE.PAIS, vE.ordenStaf, tE.huella" & vbNewLine &
            '"FROM view_sl_empleados AS vE INNER JOIN tbl_empleados_sap AS tE On tE.empid = convert(int,vE.empid)" & vbNewLine &
            '"WHERE (vE.ACTIVO = 'S')" & vbNewLine &
            '"union all" & vbNewLine &
            '"SELECT '03 - Areas Deportivas' as DEPARTAMENTO, '02 - BOLICHE' as SECCION,  EMPID, " & vbNewLine &
            '"	middleName COLLATE DATABASE_DEFAULT as PRIMER_APELLIDO, lastName COLLATE DATABASE_DEFAULT as SEGUNDO_APELLIDO," & vbNewLine &
            '"	firstName COLLATE DATABASE_DEFAULT as NOMBRE_PILA, cedula COLLATE DATABASE_DEFAULT as IDENTIFICACION," & vbNewLine &
            '"	FECHA_INGRESO, Nacionalidad COLLATE DATABASE_DEFAULT as PAIS, 8 as ordenStaf, huella FROM tbl_empleados_sap" & vbNewLine &
            '"WHERE (ACTIVO = 1)" & vbNewLine &
            '"	AND (empID NOT IN (SELECT empID FROM view_sl_empleados where ACTIVO = 's'))" & vbNewLine &
            '"ORDER BY 1, 2, 10, 4, 5, 6"
            Dim strSQL As String =
            "SELECT vE.DEPARTAMENTO, vE.SECCION, vE.EMPID, vE.PRIMER_APELLIDO, vE.SEGUNDO_APELLIDO," & vbNewLine &
            "	vE.NOMBRE_PILA, vE.IDENTIFICACION, vE.FECHA_INGRESO, vE.PAIS, vE.ordenStaf, tE.huella" & vbNewLine &
            "FROM view_sl_empleados AS vE INNER JOIN tbl_empleados_sap AS tE On tE.empid = convert(int,vE.empid)" & vbNewLine &
            "WHERE (vE.ACTIVO = 'S')" & vbNewLine &
            "ORDER BY vE.DEPARTAMENTO, vE.SECCION, vE.ordenStaf, vE.PRIMER_APELLIDO, vE.SEGUNDO_APELLIDO, vE.NOMBRE_PILA"

            If Not IsNothing(dts.Tables("tbl_empleados_sap")) Then
                dts.Tables("tbl_empleados_sap").Clear()
            End If

            cnx.SQLEXEC(dts, strSQL, "tbl_empleados_sap")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_empleados_sap"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.ReadOnly = True

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).Visible = False
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).HeaderText = "DEPARTAMENTO"
            DataGridView1.Columns(1).HeaderText = "SECCIÓN"
            DataGridView1.Columns(2).HeaderText = "CÓDIGO"
            DataGridView1.Columns(3).HeaderText = "APELLIDO1"
            DataGridView1.Columns(4).HeaderText = "APELLIDO2"
            DataGridView1.Columns(5).HeaderText = "NOMBRE"
            DataGridView1.Columns(6).HeaderText = "IDENTIFICACIÓN"
            DataGridView1.Columns(7).HeaderText = "INGRESO"
            DataGridView1.Columns(8).HeaderText = "NACIONALIDAD"
            DataGridView1.Columns(9).HeaderText = "ORDEN"

            DataGridView1.Columns(0).Visible = True
            DataGridView1.Columns(1).Visible = True
            DataGridView1.Columns(2).Visible = True
            DataGridView1.Columns(3).Visible = True
            DataGridView1.Columns(4).Visible = True
            DataGridView1.Columns(5).Visible = True
            DataGridView1.Columns(6).Visible = True
            DataGridView1.Columns(7).Visible = True
            DataGridView1.Columns(8).Visible = True
            DataGridView1.Columns(9).Visible = False

            'DataGridView1.Columns(0).Width = 100
            'DataGridView1.Columns(1).Width = 100
            'DataGridView1.Columns(2).Width = 50
            'DataGridView1.Columns(3).Width = 130
            'DataGridView1.Columns(4).Width = 130
            'DataGridView1.Columns(5).Width = 130
            'DataGridView1.Columns(6).Width = 20
            'DataGridView1.Columns(7).Width = 158
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub frmRegistroHuellaDigital_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        RegActual()
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnActualizar_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizar.Click
        Try
            Dim strSQL As String = _
                "BEGIN TRY" & vbNewLine & _
                "	BEGIN TRANSACTION" & vbNewLine & _
                "	" & vbNewLine & _
                "	DECLARE @cantNuevos AS INT" & vbNewLine & _
                "	SET @cantNuevos = (SELECT COUNT(*) FROM view_sl_empleados WHERE empid NOT IN (SELECT DISTINCT empid FROM tbl_empleados_sap))" & vbNewLine & _
                "	" & vbNewLine & _
                "	IF @cantNuevos > 0" & vbNewLine & _
                "	BEGIN" & vbNewLine & _
                "		INSERT INTO tbl_empleados_sap(empid, middlename, lastname, firstname, cedula, fecha_nacimiento, activo, marca_reloj, id_seccion, id_puesto)" & vbNewLine & _
                "		SELECT EMPID, PRIMER_APELLIDO, SEGUNDO_APELLIDO, NOMBRE_PILA, IDENTIFICACION, FECHA_NACIMIENTO," & vbNewLine & _
                "			CASE WHEN ACTIVO = 'S' THEN 1 ELSE 0 END AS ACTIVO, CASE WHEN MARCA_RELOJ IS NULL THEN 0 ELSE view_sl_empleados.MARCA_RELOJ END AS MARCA_RELOJ," & vbNewLine & _
                "           convert(int,substring(view_sl_empleados.centro_costo,1,2)), convert(int,view_sl_empleados.puesto)" & vbNewLine & _
                "		FROM view_sl_empleados" & vbNewLine & _
                "		WHERE empid in (SELECT empid FROM view_sl_empleados WHERE empid NOT IN (SELECT DISTINCT empid FROM tbl_empleados_sap))" & vbNewLine & _
                "	END" & vbNewLine & _
                "	" & vbNewLine & _
                "	UPDATE tbl_empleados_sap SET" & vbNewLine & _
                "		 activo = CASE WHEN view_sl_empleados.ACTIVO = 'S' THEN 1 ELSE 0 END" & vbNewLine & _
                "		,marca_reloj = CASE WHEN view_sl_empleados.MARCA_RELOJ IS NULL THEN 0 ELSE view_sl_empleados.MARCA_RELOJ END" & vbNewLine & _
                "       ,id_seccion = convert(int,substring(view_sl_empleados.centro_costo,1,2))" & vbNewLine & _
                "       ,id_puesto = convert(int,view_sl_empleados.puesto)" & vbNewLine & _
                "	FROM view_sl_empleados INNER JOIN tbl_empleados_Sap ON tbl_empleados_Sap.empid = CONVERT(INT,view_sl_empleados.empid)" & vbNewLine & _
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
                "		SET @ErrorState = ERROR_STATE()" & vbNewLine & _
                "		" & vbNewLine & _
                "		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);" & vbNewLine & _
                "END CATCH;" & vbNewLine & _
                "IF @@TRANCOUNT > 0" & vbNewLine & _
                "	COMMIT TRANSACTION;"
            cnx.SQLEXEC(strSQL)

            CargaGrid()
            RegActual()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If
        btnEditar.PerformClick()
    End Sub

    Private Sub btnEditar_Click(sender As System.Object, e As System.EventArgs) Handles btnEditar.Click
        Dim obj As New frmRHCCapturaHuellaDigitalDetalle()
        AddHandler obj.OnTemplate, AddressOf OnTemplate
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.ShowDialog()
    End Sub

    Private Sub VerifyButton_Click(sender As System.Object, e As System.EventArgs) Handles btnVerificar.Click
        Dim obj As New frmRHDVericaHuella()
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Verify(Template)
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim pNombre As String = dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("PRIMER_APELLIDO") & " " & _
                                    dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("SEGUNDO_APELLIDO") & " " & _
                                    dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("NOMBRE_PILA")

            If IsDBNull(dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("huella")) Then
                If MessageBox.Show("Se dispone a almacenar la huella digital de: " & pNombre & "." & vbNewLine & _
                                   "¿ Seguro de proceder ?", "GUARDAR !!!", MessageBoxButtons.YesNo, _
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    Template = Nothing
                    Exit Sub
                End If
            Else
                If MessageBox.Show("Se dispone a reemplazar la huella digital de: " & pNombre & "." & vbNewLine & _
                                   "¿ Seguro de proceder ?", "GUARDAR !!!", MessageBoxButtons.YesNo, _
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    Template = Nothing
                    Exit Sub
                End If
            End If

            Dim pEmpID As Integer = dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("empID")
            Dim byteArr() As Byte = Template.Bytes()

            cnx.ATTACHFILE(byteArr, "tbl_empleados_sap", "huella", "empID = " & pEmpID.ToString.Trim)
            MessageBox.Show("Huella almacenada con éxito.", "GUARDAR !!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub btnBorrar_Click(sender As System.Object, e As System.EventArgs) Handles btnBorrar.Click
        Try
            Dim pNombre As String = dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "bl_empleados_sap").Position).Item("nombre")
            Dim pEmpID As Integer = dts.Tables("tbl_empleados_sap").Rows(BindingContext(dts, "tbl_empleados_sap").Position).Item("empID")

            If MessageBox.Show("Se dispone a borrar la huella correspondiente a: " & pNombre & "." & vbNewLine & _
                               "¿ Seguro de proceder ?", "GUARDAR !!!", MessageBoxButtons.YesNo, _
                                   MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            cnx.SQLEXEC(dts, "UPDATE tbl_empleados_sap SET huella = NULL WHERE empid = " & pEmpID.ToString.Trim, "tbl_empleados_sap")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class