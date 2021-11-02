Public Class frmLogin
    Dim dts As New DataSet
    Dim pnt As frmInicio
    Dim intentos As Integer = 0

    Private Function validaUsuario(ByVal pUsuario As String, ByVal pClave As String) As Boolean
        Try
            Dim dt As New DataTable
            Dim strSQL As String = _
                "SELECT a.empID, a.usuario, a.clave, " & vbNewLine & _
                " 	(SELECT nombre FROM view_sl_empleados WHERE empid = a.empid) AS nombre " & vbNewLine & _
                "FROM tbl_control_asistencia_usuarios AS a" & vbNewLine & _
                "WHERE (activo = 1) AND (usuario = '" & pUsuario & "') AND (clave = '" & pClave & "')"

            cnx.SQLEXEC(dt, strSQL)

            Dim result As Boolean = IIf(dt.Rows.Count = 0, False, True)
            If result Then
                pempID = dt.Rows(0).Item("empID")
                pNombreUser = dt.Rows(0).Item("nombre")
                pUser = dt.Rows(0).Item("usuario")

                strSQL = _
                    "DECLARE @empid AS VARCHAR(4), @esJefe AS INT, @esGerente AS INT" & vbNewLine & _
                    "" & vbNewLine & _
                    "SET @empid = '" & pempID & "'" & vbNewLine & _
                    "SET @esJefe = (SELECT CAST(COUNT(*) AS BIT) FROM (SELECT DISTINCT jefe FROM view_sl_empleados WHERE jefe = @empid) AS a)" & vbNewLine & _
                    "SET @esGerente = (SELECT CAST(COUNT(*) AS BIT) FROM (SELECT DISTINCT gerente FROM view_sl_empleados WHERE gerente = @empid) AS a)" & vbNewLine & _
                    "" & vbNewLine & _
                    "SELECT @esJefe AS esJefe, @esGerente AS esGerente"

                cnx.SQLEXEC(dt, strSQL)

                pEsJefe = IIf(IsDBNull(dt.Rows(0).Item("esJefe")), False, dt.Rows(0).Item("esJefe"))
                pEsGerente = IIf(IsDBNull(dt.Rows(0).Item("esGerente")), False, dt.Rows(0).Item("esGerente"))
            Else
                pempID = 0
                pNombreUser = ""
                pUser = ""
            End If
            dts.Tables.Clear()
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click, btnLogin.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Text
            Case "&Login"
                If txtUsuario.Text = "" Or txtClave.Text = "" Then
                    MessageBox.Show("Faltan datos, verifique e intente de nuevo.", "INICIO DE SESIÓN FALLÓ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                intentos += 1
                If validaUsuario(txtUsuario.Text, txtClave.Text) Then
                    pnt.MenuStrip.Visible = True
                    pnt.ToolStripLogin.Visible = False
                    pnt.ToolStripLogin.Enabled = True
                    pnt.cargaPermisos(pempID)
                    Close()
                Else
                    MessageBox.Show("Los datos no son correctos, verifique e intente de nuevo.", "INICIO DE SESIÓN FALLÓ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtClave.Text = ""
                    txtUsuario.Text = ""
                    txtUsuario.Focus()
                End If
                If intentos = 3 Then
                    MessageBox.Show("Llego al máximo de intentos permitido.", "CERRANDO LA APLICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End
                End If
            Case "&Salir"
                pnt.ToolStripLogin.Enabled = True
                Close()
        End Select
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnt = Me.ParentForm
        pnt.ToolStripLogin.Enabled = False
    End Sub

    Private Sub frmLogin_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        pnt.ToolStripLogin.Enabled = True
    End Sub

End Class