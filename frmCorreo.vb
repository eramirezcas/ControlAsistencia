Public Class frmCorreo
    Public dts As DataSet
    Public pnt As Form

    Private Function cargaHTML(ByVal datos As String) As String
        Dim txt As String = "" & _
            "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" & vbNewLine & _
            "<html xmlns=""http://www.w3.org/1999/xhtml"">" & vbNewLine & _
            "<head>" & vbNewLine & _
            "<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />" & vbNewLine & _
            "<title>Untitled Document</title>" & vbNewLine & _
            "<style type=""text/css"">" & vbNewLine & _
            "<!--" & vbNewLine & _
            ".style1 {color: #006600}" & vbNewLine & _
            ".style4 {color: #FFFFFF}" & vbNewLine & _
            ".style6 {font-size: 24px}" & vbNewLine & _
            "-->" & vbNewLine & _
            "</style>" & vbNewLine & _
            "</head>" & vbNewLine & _
            "" & vbNewLine & _
            "<body>" & vbNewLine & _
            "<h4 class=""style1""><span class=""style6"">Costa Rica Country Club S.A</span><br />" & vbNewLine & _
            "REPORTE DE REBAJOS DE MARCAS<br />" & vbNewLine & _
            "</h4>" & vbNewLine & _
            "<pre class=""style1""></pre>" & vbNewLine & _
            "<table width=""608"" border=""0"">" & vbNewLine & _
            "  <tr>" & vbNewLine & _
            "    <th width=""55"" bordercolor=""#000000"" bgcolor=""#000000""><span class=""style4"">COD.</span></th>" & vbNewLine & _
            "    <th width=""322"" bordercolor=""#000000"" bgcolor=""#000000""><span class=""style4"">NOMBRE</span></th>" & vbNewLine & _
            "    <th width=""99"" bordercolor=""#000000"" bgcolor=""#000000""><div align=""right""><span class=""style4"">HORAS</span></div></th>" & vbNewLine & _
            "    <th width=""114"" bordercolor=""#000000"" bgcolor=""#000000""><div align=""right""><span class=""style4"">MONTO</span></div></th>" & vbNewLine & _
            "  </tr>" & vbNewLine & _
            "<!--  A partir de aqui -->" & vbNewLine & _
            datos & vbNewLine & _
            "<!--  Y hasta aqui -->" & vbNewLine & _
            "  <tr bgcolor=""#000000"">" & vbNewLine & _
            "    <td colspan=""4"">&nbsp;</td>" & vbNewLine & _
            "  </tr>" & vbNewLine & _
            "</table>" & vbNewLine & _
            "<h2 class=""style1"">&nbsp;</h2>" & vbNewLine & _
            "</body>" & vbNewLine & _
            "</html>"
        Return txt
    End Function

    Private Function preparaDatos(ByVal dept As String, ByVal sec As String) As String
        Try
            Dim dt As New DataTable
            Dim result As String = Nothing
            Dim strSQL As String = _
                "SELECT  M.departamento, M.seccion, M.codigo, M.nombre, SUM(M.diferencia) AS horasRebajar, round(SUM(M.diferencia)* O.emplCost,2) as montoRebajar" & vbNewLine & _
                "FROM tbl_marcas_justificadas_act AS M INNER JOIN view_sl_empleados AS O ON O.empID = M.codigo" & vbNewLine & _
                "WHERE (M.departamento='" & dept & "') AND (m.seccion = '" & sec & "')" & vbNewLine & _
                "GROUP BY M.departamento, M.seccion, M.codigo, M.nombre, O.emplCost ORDER BY M.departamento, M.seccion, M.nombre"

            cnx.SQLEXEC(dt, strSQL)

            For i = 0 To dt.Rows.Count - 1
                Dim x As String = _
                        "  <tr>" & vbNewLine & _
                        "    <td>" & dt.Rows(i).Item("codigo") & "</td>" & vbNewLine & _
                        "    <td>" & dt.Rows(i).Item("nombre") & "</td>" & vbNewLine & _
                        "    <td><div align=""right"">" & Format(dt.Rows(i).Item("horasRebajar"), "##,##0.00") & "</div></td>" & vbNewLine & _
                        "    <td><div align=""right"">" & Format(dt.Rows(i).Item("montoRebajar"), "##,##0.00") & "</div></td>" & vbNewLine & _
                        "  </tr>" & vbNewLine
                result += x
            Next

            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    Private Sub enviaCorreo(ByVal email As String, ByVal departamento As String, ByVal seccion As String)
        Try
            '* Creamos un Objeto tipo Mail
            Dim objMail As Microsoft.Office.Interop.Outlook.MailItem

            '* Inicializamos nuestra apliación OutLook
            Dim m_OutLook = New Microsoft.Office.Interop.Outlook.Application

            '* Creamos una instancia de un objeto tipo MailItem
            objMail = m_OutLook.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem)

            '* Asignamos las propiedades a nuestra Instancial del objeto
            '* MailItem
            objMail.To = email
            objMail.Subject = "Marcas por rebajar para esta quincena"
            objMail.HTMLBody = cargaHTML(preparaDatos(departamento, seccion))
            '* Enviamos nuestro Mail y listo!
            objMail.Send()

            '* Desplegamos un mensaje indicando que todo fue exitoso
            '* MessageBox.Show("Mail Enviado", "ENVIO DE REBAJOS !!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        Catch ex As Exception
            '* Si se produce algun Error Notificar al usuario
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub frmCorreo_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        dts.Tables.Remove("QTMP")
        pnt.Enabled = True
    End Sub

    Private Sub frmCorreo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            pnt.Enabled = False
            Dim strSQL As String =
                "SELECT DISTINCT CAST(0 as BIT) AS SelectItem, MJ.departamento, MJ.seccion, tbl_control_asistencia_usuarios.email" & vbNewLine &
                "FROM tbl_control_asistencia_usuarios INNER JOIN tbl_jefe_seccion ON" & vbNewLine &
                "	tbl_control_asistencia_usuarios.empid = tbl_jefe_seccion.empid INNER JOIN" & vbNewLine &
                "	tbl_marcas_justificadas_act AS MJ INNER JOIN crcc.dbo.ohem AS OH" & vbNewLine &
                "	ON OH.empID = MJ.codigo ON tbl_jefe_seccion.deptid = OH.dept" & vbNewLine &
                "ORDER BY MJ.departamento, MJ.seccion"

            cnx.SQLEXEC(dts, strSQL, "QTMP")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "QTMP"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.MultiSelect = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToAddRows = False

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            DataGridView1.Columns(0).HeaderText = ""
            DataGridView1.Columns(1).HeaderText = "DEPARTAMENTO"
            DataGridView1.Columns(2).HeaderText = "SECCIÓN"
            DataGridView1.Columns(3).HeaderText = "EMAIL"

            DataGridView1.Columns(0).Width = 20
            DataGridView1.Columns(1).Width = 150
            DataGridView1.Columns(2).Width = 150

            DataGridView1.Columns(0).ReadOnly = False
            DataGridView1.Columns(1).ReadOnly = True
            DataGridView1.Columns(2).ReadOnly = True

            DataGridView1.Columns(3).Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub ckTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckTodos.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)

        For i = 0 To dts.Tables("QTMP").Rows.Count - 1
            dts.Tables("QTMP").Rows(i).Item("SelectItem") = obj.Checked
        Next

    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click
        Progress.Minimum = 0
        Progress.Maximum = dts.Tables("QTMP").Rows.Count + 1
        For I As Integer = 0 To dts.Tables("QTMP").Rows.Count - 1
            If dts.Tables("QTMP").Rows(I).Item("SelectItem") Then
                If dts.Tables("QTMP").Rows(I).Item("email") <> "" Then
                    enviaCorreo(dts.Tables("QTMP").Rows(I).Item("email"), dts.Tables("QTMP").Rows(I).Item("departamento"), dts.Tables("QTMP").Rows(I).Item("seccion"))
                End If
            End If
            Progress.Value = I
        Next
        Progress.Value = 0
        MessageBox.Show("Envío completado con éxito.", "ENVíO DE CORREO !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Close()
    End Sub
End Class