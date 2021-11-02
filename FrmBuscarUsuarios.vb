Public Class FrmBuscarUsuarios
    Dim dtsForm = FrmMantenimientoUsuarios.dtsForm
    Dim id_linea As Integer
    Dim pntMantUsuarios As FrmMantenimientoUsuarios
    Public idemp As Integer

    Public Sub cargaforma(ByVal pantallas As Object)
        Dim obj As Object = CType(pantallas, Form)
        obj.MdiParent = Me.MdiParent
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            idemp = txtempid.Text

            If Not txtJefe.Text = "" And Not txtContraseña.Text = "" And Not txtUsuario.Text = "" Then
                Dim strSQL As String = ""
                cnx.SQLEXEC(dtsForm, "Select id_linea, empid, nombre, activo, usuario, clave, verTodos, email from tbl_control_asistencia_usuarios", "tbl_control_asistencia_usuarios")
                If FrmMantenimientoUsuarios.Opcion = 1 Then
                    strSQL = "Insert Into tbl_control_asistencia_usuarios(empid, nombre, activo, usuario, clave, verTodos, email)" & vbNewLine & _
                             " values (" & Val(idemp) & _
                             ", '" & txtJefe.Text & _
                             "', " & IIf(chkActivo.Checked, 1, 0) & _
                             ", '" & txtUsuario.Text & _
                             "', '" & txtContraseña.Text & _
                             "', " & IIf(chkVerTodos.Checked, 1, 0) & _
                             ", '" & txtEmail.Text & "')"
                Else
                    id_linea = FrmMantenimientoUsuarios.dgvHorarios.Item(0, FrmMantenimientoUsuarios.dgvHorarios.CurrentRow.Index).Value
                    idemp = FrmMantenimientoUsuarios.dgvHorarios.Item(1, FrmMantenimientoUsuarios.dgvHorarios.CurrentRow.Index).Value
                    strSQL = "UPDATE tbl_control_asistencia_usuarios" & vbNewLine & _
                             "SET empid = " & idemp & _
                             ", nombre = '" & txtJefe.Text & _
                             "', activo = " & IIf(chkActivo.Checked, 1, 0) & _
                             ", usuario = '" & txtUsuario.Text & _
                             "', clave = '" & txtContraseña.Text & _
                             "', verTodos =  " & IIf(chkVerTodos.Checked, 1, 0) & _
                             ", email = '" & txtEmail.Text & "'" & vbNewLine & _
                             "WHERE id_linea = " & id_linea & ""
                End If

                cnx.SQLEXEC(strSQL)
                FrmMantenimientoUsuarios.CargaGrid()
                FrmMantenimientoUsuarios.Enabled = True
                Close()
            Else
                MessageBox.Show("No ha Ingresado a ningun colaborador ni departamento", "IMPORTANTE!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub FrmBuscarUsuarios_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMantenimientoUsuarios.Enabled = True
    End Sub

    Private Sub FrmBuscarUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FrmMantenimientoUsuarios.Enabled = False
    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        FrmMantenimientoUsuarios.Enabled = True
        Me.Close()
    End Sub

    Private Sub lblEmpleado_Click_1(sender As System.Object, e As System.EventArgs) Handles lblEmpleado.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE Colaborador"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = "SELECT empid, Nombre, email FROM view_sl_empleados WHERE (ESTADO_EMPLEADO = 'ACT')"

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtempid.Text = result.Item("empid")
        txtJefe.Text = result.Item("nombre")
        txtEmail.Text = IIf(IsDBNull(result.Item("email")), "", result.Item("email"))
    End Sub

End Class