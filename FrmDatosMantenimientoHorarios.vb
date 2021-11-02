Public Class FrmDatosMantenimientoHorarios
    Public dts As DataSet
    Public pos As Integer
    Public nuevo As Boolean
    Public pnt As Form

    Private Function validaCampos() As Boolean
        Dim cant As Integer = _
        IIf(txtDepartamento.Text = "", 1, 0) + _
        IIf(txtLunesIn.Text.Trim = ":", 1, 0) + _
        IIf(txtLunesOut.Text.Trim = ":", 1, 0) + _
        IIf(txtMartesIn.Text.Trim = ":", 1, 0) + _
        IIf(txtMartesOut.Text.Trim = ":", 1, 0) + _
        IIf(txtMiercolesIn.Text.Trim = ":", 1, 0) + _
        IIf(txtMiercolesOut.Text.Trim = ":", 1, 0) + _
        IIf(txtJuevesIn.Text.Trim = ":", 1, 0) + _
        IIf(txtJuevesOut.Text.Trim = ":", 1, 0) + _
        IIf(txtViernesIn.Text.Trim = ":", 1, 0) + _
        IIf(txtViernesOut.Text.Trim = ":", 1, 0) + _
        IIf(txtSabadoIn.Text.Trim = ":", 1, 0) + _
        IIf(txtSabadoOut.Text.Trim = ":", 1, 0) + _
        IIf(txtDomingoIn.Text.Trim = ":", 1, 0) + _
        IIf(txtDomingoOut.Text.Trim = ":", 1, 0) + _
        IIf(cboFeriado1.Text = "NULO", 1, 0) + _
        IIf(cboFeriado2.Text = "NULO", 1, 0)
        Return IIf(cant = 0, True, False)
    End Function

    Private Sub FrmDatosMantenimientoHorarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnt.Enabled = False
        BindingContext(dts, "tbl_Tipo_Horario").Position = pos
        txtIdHorario.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.id_horario")
        txtDepartamento.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.detalle")
        txtLunesIn.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.LunesIn")
        txtLunesOut.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.LunesOut")
        txtMartesIn.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.MartesIn")
        txtMartesOut.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.MartesOut")
        txtMiercolesIn.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.MiercolesIn")
        txtMiercolesOut.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.MiercolesOut")
        txtJuevesIn.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.JuevesIn")
        txtJuevesOut.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.JuevesOut")
        txtViernesIn.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.ViernesIn")
        txtViernesOut.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.ViernesOut")
        txtSabadoIn.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.SabadoIn")
        txtSabadoOut.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.SabadoOut")
        txtDomingoIn.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.DomingoIn")
        txtDomingoOut.DataBindings.Add("Text", dts, "tbl_Tipo_Horario.DomingoOut")

        cboFeriado1.Text = IIf(IsDBNull(dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("dia_feriado").ToString.Trim), _
                                        "NULO", dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("dia_feriado").ToString.Trim)
        cboFeriado2.SelectedValue = IIf(IsDBNull(dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("dia_feriado2").ToString.Trim), _
                                        "NULO", dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("dia_feriado2").ToString.Trim)
        ChkActivo.Checked = IIf(IIf(IsDBNull(dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("activo")), 0, dts.Tables("tbl_Tipo_Horario").Rows(pos).Item("activo")), True, False)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim strSQL As String = ""

            If Not validaCampos() Then
                MessageBox.Show("Faltan datos en la forma !!!", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If nuevo Then
                strSQL = "INSERT INTO tbl_Tipo_Horario(" & _
                                 "detalle, " & _
                                 "lunesin, lunesout, " & _
                                 "martesin, martesout, " & _
                                 "miercolesin, miercolesout, " & _
                                 "juevesin, juevesout, " & _
                                 "viernesin, viernesout, " & _
                                 "sabadoin, sabadoout, " & _
                                 "domingoin, domingoout, " & _
                                 "dia_feriado, dia_feriado2, " & _
                                 "activo)" & _
                         "VALUES (" & _
                                 "'" & txtDepartamento.Text & "', " & _
                                 "'" & txtLunesIn.Text & "', '" & txtLunesOut.Text & "', " & _
                                 "'" & txtMartesIn.Text & "', '" & txtMartesOut.Text & "', " & _
                                 "'" & txtMiercolesIn.Text & "', '" & txtMiercolesOut.Text & "', " & _
                                 "'" & txtJuevesIn.Text & "', '" & txtJuevesOut.Text & "', " & _
                                 "'" & txtViernesIn.Text & "', '" & txtViernesOut.Text & "', " & _
                                 "'" & txtSabadoIn.Text & "', '" & txtSabadoOut.Text & "', " & _
                                 "'" & txtDomingoIn.Text & "', '" & txtDomingoOut.Text & "', " & _
                                 "'" & cboFeriado1.Text & "', '" & cboFeriado2.Text & "', " & _
                                 IIf(ChkActivo.Checked, "1", "0") & _
                         ")"
            Else
                strSQL = "UPDATE tbl_Tipo_Horario SET " & _
                                "detalle = '" & txtDepartamento.Text & "', " & _
                                "lunesin = '" & txtLunesIn.Text & "', lunesout = '" & txtLunesOut.Text & "', " & _
                                "martesin = '" & txtMartesIn.Text & "', martesout = '" & txtMartesOut.Text & "', " & _
                                "miercolesin = '" & txtMiercolesIn.Text & "', miercolesout = '" & txtMiercolesOut.Text & "', " & _
                                "juevesin = '" & txtJuevesIn.Text & "', juevesout = '" & txtJuevesOut.Text & "', " & _
                                "viernesin = '" & txtViernesIn.Text & "', viernesout = '" & txtViernesOut.Text & "', " & _
                                "sabadoin = '" & txtSabadoIn.Text & "', sabadoout = '" & txtSabadoOut.Text & "', " & _
                                "domingoin = '" & txtDomingoIn.Text & "', domingoout = '" & txtDomingoOut.Text & "', " & _
                                "dia_feriado = '" & cboFeriado1.Text & "', dia_feriado2 = '" & cboFeriado2.Text & "', " & _
                                "activo = " & IIf(ChkActivo.Checked, "1 ", "0 ") & _
                        "WHERE id_horario = " & txtIdHorario.Text
            End If

            cnx.SQLEXEC(strSQL) '' ejecutamos la consulta 

            If dts.Tables.Contains("tbl_tipo_horario") Then
                dts.Tables("tbl_tipo_horario").Rows.Clear()
            End If

            strSQL = "SELECT id_horario, detalle, activo, lunesin, lunesout, martesin, martesout," & vbNewLine & _
                     "	miercolesin, miercolesout, juevesin, juevesout, viernesin, viernesout," & vbNewLine & _
                     "	sabadoin, sabadoout, domingoin, domingoout, dia_feriado, dia_feriado2" & vbNewLine & _
                     "FROM tbl_tipo_horario"
            cnx.SQLEXEC(dts, strSQL, "tbl_Tipo_Horario")

            BindingContext(dts, "tbl_Tipo_Horario").Position = IIf(nuevo, BindingContext(dts, "tbl_Tipo_Horario").Count - 1, pos)
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnDeshacer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeshacer.Click
        Me.Close()
    End Sub

    Private Sub FrmDatosMantenimientoHorarios_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
    End Sub

End Class