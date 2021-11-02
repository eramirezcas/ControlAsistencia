Imports System.Drawing

'Delegate Sub FunctionCall(ByVal param)

Public Class frmMantenimientoCapsDetalle

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
        btnVerifica.Enabled = Not (Not template Is Nothing)
        btnCaptura.Enabled = (Not template Is Nothing)
        If Not template Is Nothing Then
            estaVerificada = True
            'MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment")
        Else
            estaVerificada = False
            'MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment")
        End If

        btnVerifica.Enabled = estaVerificada
        btnCaptura.Enabled = IIf(Not nuevo And Not estaVerificada, True, False)
    End Sub

    Private Template As DPFP.Template
    Public dt As New DataTable
    Public dtService As New DataTable
    Public frmOrigen As Form
    Public nuevo As Boolean, cancelado As Boolean
    Public pos As Integer

    '**********************************************************************************************************************************************
    '**********************************************************************************************************************************************
    Private Sub cargaTemplate(ByVal dt As DataTable)
        Try
            If IsDBNull(dt.Rows(0).Item("huella")) Then
                Label13.Text = "Sin huella registrada"
                Exit Sub
            End If

            Dim byteArr() As Byte = dt.Rows(0).Item("huella")
            Dim memStream As New System.IO.MemoryStream(byteArr)
            Dim tmpTemplate As New DPFP.Template(memStream)
            Template = tmpTemplate
            OnTemplate(Template)
            Label13.Text = "Huella registrada"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cargaHuella(ByVal pid As String)
        Try
            Dim strSQL As String = _
                "SELECT RTRIM(LTRIM(CONVERT(CHAR(6),EMPID))) AS CODIGO" & vbNewLine & _
                "	,MIDDLENAME + ' ' + LASTNAME + ' ' + FIRSTNAME AS NOMBRE" & vbNewLine & _
                "	,cedula" & vbNewLine & _
                "	,huella" & vbNewLine & _
                "FROM TBL_EMPLEADOS_SAP WHERE activo=1 and RTRIM(LTRIM(cedula))='" & pid.ToString.Trim & "'" & vbNewLine & _
                "UNION ALL" & vbNewLine & _
                "SELECT RTRIM(LTRIM(CONVERT(CHAR(6),id_cap)))" & vbNewLine & _
                "	,nombre" & vbNewLine & _
                "	,identificacion" & vbNewLine & _
                "	,huella_digital" & vbNewLine & _
                "FROM tbl_control_alimentacion_caps_hist" & vbNewLine & _
                "WHERE RTRIM(LTRIM(identificacion))='" & pid.ToString.Trim & "'" & vbNewLine & _
                "UNION ALL" & vbNewLine & _
                "SELECT codigo_empleado" & vbNewLine & _
                "	,nombre" & vbNewLine & _
                "	,RTRIM(LTRIM(CONVERT(CHAR(6),num_tiquete)))" & vbNewLine & _
                "	,huella_digital" & vbNewLine & _
                "FROM tbl_control_alimentacion_ventas_hist" & vbNewLine & _
                "WHERE RTRIM(LTRIM(codigo_empleado))='" & pid.ToString.Trim & "'"

            Dim TMP As New DataTable
            cnx.SQLEXEC(TMP, strSQL)
            cargaTemplate(TMP)
            If Not IsNothing(Template) Then
                dt.Rows(pos).Item("huella_digital") = TMP.Rows(0).Item("huella")
            Else
                dt.Rows(pos).Item("huella_digital") = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function validaDatos() As Object

        If txtIdentificacion.Text = "" Then
            Return txtIdentificacion
        End If
        If txtNombre.Text = "" Then
            Return txtNombre
        End If
        If txtCantDias.Text = "" Then
            Return txtCantDias
        End If

        Return Nothing
    End Function

    Private Sub frmManteVentasDetalle_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If nuevo And cancelado And pos >= 0 Then
            dt.Rows.RemoveAt(dt.Rows.Count - 1)
        ElseIf nuevo And Not cancelado And pos >= 0 Then
            BindingContext(dt).Position = dt.Rows.Count - 1
        ElseIf Not nuevo And Not cancelado And pos >= 0 Then
            BindingContext(dt).Position = pos
        End If
        frmOrigen.Enabled = True
    End Sub

    Private Sub frmMantenimientoCapsDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If nuevo Then
                dt.Rows.Add()
                pos = dt.Rows.Count - 1
                dt.Rows(pos).Item("id_cap") = 0
                txtFecha.Enabled = True
                txtFecha.Text = Format(Now, "dd/MM/yyyy")
                txtMotivo.Enabled = True
            End If

            BindingContext(dt).Position = pos
            frmOrigen.Enabled = False

            txtId_Cap.DataBindings.Add("text", dt, "id_cap")
            txtIdentificacion.DataBindings.Add("text", dt, "identificacion")
            txtNombre.DataBindings.Add("text", dt, "nombre")
            txtMotivo.DataBindings.Add("text", dt, "motivo")
            txtFecha.DataBindings.Add("text", dt, "fecha_inicio")
            dtpVence.DataBindings.Add("text", dt, "fecha_fin")
            txtCantDias.DataBindings.Add("text", dt, "cantidad_dia")

            chkRRHH.Checked = IIf(IsDBNull(dt.Rows(pos).Item("beneficio_alimentacion_rrhh")), False, dt.Rows(pos).Item("beneficio_alimentacion_rrhh"))
            chkRSE.Checked = IIf(IsDBNull(dt.Rows(pos).Item("beneficio_aimentacion_rse")), False, dt.Rows(pos).Item("beneficio_aimentacion_rse"))
            chkDBTUR.Checked = IIf(IsDBNull(dt.Rows(pos).Item("dobla_turno")), False, dt.Rows(pos).Item("dobla_turno"))

            If Not nuevo Then
                Dim TMP As New DataTable
                Dim strSQL As String = _
                    "SELECT id_cap,nombre,identificacion,huella_digital" & vbNewLine & _
                    "   ,fecha_inicio,fecha_fin,motivo" & vbNewLine & _
                    "   ,beneficio_alimentacion_rrhh" & vbNewLine & _
                    "   ,beneficio_aimentacion_rse" & vbNewLine & _
                    "   ,dobla_turno,cantidad_dia,id_linea" & vbNewLine & _
                    "FROM tbl_control_alimentacion_caps" & vbNewLine & _
                    "WHERE id_cap = " & dt.Rows(pos).Item("id_cap")
                cnx.SQLEXEC(TMP, strSQL)
                cargaTemplate(TMP)
            End If

            If IsNothing(Template) Then
                btnVerifica.Enabled = estaVerificada
                btnCaptura.Enabled = Not estaVerificada
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCaptura_Click(sender As Object, e As EventArgs) Handles btnCaptura.Click
        Dim obj As New frmRHCCapturaHuellaDigitalDetalle
        AddHandler obj.OnTemplate, AddressOf OnTemplate
        obj.Owner = Me.Owner
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.ShowDialog()
    End Sub

    Private Sub btnVerifica_Click_1(sender As Object, e As EventArgs) Handles btnVerifica.Click
        Dim obj As New frmRHDVericaHuella
        obj.Owner = Me.Owner
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Verify(Template)
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        cancelado = True
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            cancelado = False
            Dim obj As Object = validaDatos()
            If Not IsNothing(obj) Then
                Dim txt As TextBox = CType(obj, TextBox)
                txt.BackColor = Color.Yellow
                Throw New Exception("Faltan datos, verifique e intente de nuevo.")
            End If

            Dim strSQL As String = ""
            If nuevo Then
                strSQL = "DECLARE @num_tiquete AS NUMERIC(10,0)" & vbNewLine & _
                         "SET @num_tiquete = (SELECT consecutivo_caps FROM tbl_control_alimentacion_parametros)" & vbNewLine & _
                         "" & vbNewLine & _
                         "INSERT INTO tbl_control_alimentacion_caps(id_cap,nombre,identificacion" & vbNewLine & _
                         "              ,fecha_inicio,fecha_fin,motivo,beneficio_alimentacion_rrhh" & vbNewLine & _
                         "              ,beneficio_aimentacion_rse,dobla_turno,cantidad_dia)" & vbNewLine & _
                         "VALUES(" & vbNewLine & _
                         "   @num_tiquete" & vbNewLine & _
                         "  ,'" & txtNombre.Text & "'" & vbNewLine & _
                         "  ,'" & txtIdentificacion.Text & "'" & vbNewLine & _
                         "  ,GETDATE()" & vbNewLine & _
                         "  ,CONVERT(DATETIME,'" & Format(dtpVence.Value, "dd/MM/yyyy") & "',103)" & vbNewLine & _
                         "  ,'" & txtMotivo.Text & "'" & vbNewLine & _
                         "  ," & IIf(chkRRHH.Checked, "1", "0") & vbNewLine & _
                         "  ," & IIf(chkRSE.Checked, "1", "0") & vbNewLine & _
                         "  ," & IIf(chkDBTUR.Checked, "1", "0") & vbNewLine & _
                         "  ," & txtCantDias.Text & vbNewLine & _
                         ")" & vbNewLine & _
                         "" & vbNewLine & _
                         "UPDATE tbl_control_alimentacion_parametros SET consecutivo_caps = consecutivo_caps  + 1" & vbNewLine & _
                         "" & vbNewLine & _
                         "SELECT @num_tiquete"

                Dim newRec As Object = cnx.SQLEXECESCALAR(strSQL)
                Dim nnuev As Integer = CType(newRec, Integer)
                If Not IsNothing(Template) Then
                    Dim byteArr() As Byte = Template.Bytes()
                    cnx.ATTACHFILE(byteArr, "tbl_control_alimentacion_caps", "huella_digital", "id_cap = " & nnuev)
                End If
            Else

                strSQL = _
                    "UPDATE tbl_control_alimentacion_caps" & vbNewLine & _
                    "SET" & vbNewLine & _
                    "    nombre = '" & txtNombre.Text & "'" & vbNewLine & _
                    "   ,identificacion = '" & txtIdentificacion.Text & "'" & vbNewLine & _
                    "   ,fecha_fin = CONVERT(DATETIME,'" & Format(dtpVence.Value, "dd/MM/yyyy") & "',103)" & vbNewLine & _
                    "   ,motivo = '" & txtMotivo.Text & "'" & vbNewLine & _
                    "   ,beneficio_alimentacion_rrhh = " & IIf(chkRRHH.Checked, "1", "0") & vbNewLine & _
                    "   ,beneficio_aimentacion_rse = " & IIf(chkRSE.Checked, "1", "0") & vbNewLine & _
                    "   ,dobla_turno = " & IIf(chkDBTUR.Checked, "1", "0") & vbNewLine & _
                    "   ,cantidad_dia = " & txtCantDias.Text & vbNewLine & _
                    "WHERE id_cap = " & txtId_Cap.Text
                cnx.SQLEXEC(strSQL)

                Dim byteArr() As Byte = Template.Bytes()
                cnx.ATTACHFILE(byteArr, "tbl_control_alimentacion_caps", "huella_digital", "id_cap = " & txtId_Cap.Text)
            End If

            dt.Rows.Clear()
            cnx.SQLEXEC(dt, "SELECT id_cap,nombre,identificacion,huella_digital,fecha_inicio" & vbNewLine & _
                            "   ,fecha_fin,motivo,beneficio_alimentacion_rrhh" & vbNewLine & _
                            "   ,beneficio_aimentacion_rse,dobla_turno,cantidad_dia,id_linea" & vbNewLine & _
                            "FROM tbl_control_alimentacion_caps")
            dt.TableName = "tbl_control_alimentacion_caps"

            MessageBox.Show("Proceso realizado con éxito", "GUARDAR DATOS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnBuscaPersona_Click(sender As Object, e As EventArgs) Handles btnBuscaPersona.Click
        Try
            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.StartPosition = FormStartPosition.CenterScreen
            pnt.Owner = Me.Owner
            pnt.Text = "BUSQUEDA"
            pnt.strConsulta = _
                "SELECT RTRIM(LTRIM(empid)) as codigo,nombre,identificacion,empid" & vbNewLine & _
                "FROM view_sl_empleados WHERE ACTIVO = 'S'"
            pnt.strTabla = "EMP"
            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            dt.Rows(pos).Item("identificacion") = result.Item("identificacion")
            dt.Rows(pos).Item("nombre") = result.Item("nombre")
            cargaHuella(txtIdentificacion.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtIdentificacion_GotFocus(sender As Object, e As EventArgs) _
        Handles txtIdentificacion.GotFocus, txtNombre.GotFocus, txtCantDias.GotFocus
        Dim txt As TextBox = CType(sender, TextBox)
        txt.BackColor = Color.White
    End Sub

    Private Sub chkRSE_CheckedChanged(sender As Object, e As EventArgs) Handles chkRSE.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)
        If obj.Checked Then
            chkRRHH.Checked = False
            chkDBTUR.Checked = False
        End If
    End Sub

    Private Sub chkRRHH_CheckedChanged(sender As Object, e As EventArgs) Handles chkRRHH.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)
        If obj.Checked Then
            chkRSE.Checked = False
            chkDBTUR.Checked = False
        End If
    End Sub

    Private Sub chkDBTUR_CheckedChanged(sender As Object, e As EventArgs) Handles chkDBTUR.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)
        If obj.Checked Then
            chkRRHH.Checked = False
            chkRSE.Checked = False
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class