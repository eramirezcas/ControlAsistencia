Public Class FrmBuscaEmpHorario

    Public nuevo As Boolean ' se utiliza para saber si se esta agregando o editando un regisptro
    Public pos As Integer
    Public dts As DataSet '' se declara una variable que hereda todas las propiedades de la variable dtsForm de la forma FrmMantenimientoJefesSecciones
    Public pnt As Form
    Dim idLinea As Integer

    Private Function validaCampos() As Integer
        Dim result As Integer = _
            IIf(txtEmpleado.Text = "", 1, 0) + _
            IIf(IsDBNull(txtEmpleado.Tag), 1, 0) + _
            IIf(txtHorario.Text = "", 1, 0) + _
            IIf(IsDBNull(txtHorario.Tag), 1, 0)
        Return result
    End Function

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            If validaCampos() > 0 Then
                MessageBox.Show("Faltan datos en la forma veirfique e intente de nuevo !!!!", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim strSQL As String = ""

            If Not nuevo Then
                strSQL = "UPDATE tbl_horarioxempleado SET " & _
                                " id_Horario = " & txtHorario.Tag & _
                                ",horario = '" & txtHorario.Text & "'" & _
                                ",horarioFijo = " & IIf(chkHorFijo.Checked, "1", "0") & _
                                ",modificado = getdate()" & _
                                ",usuario_modifica = '" & pUser.Trim & "'" & _
                                "where id_linea = " & idLinea
            Else
                strSQL = "INSERT INTO tbl_horarioxempleado(empid, nombre, id_Horario, horario, computername, username, horarioFijo, Activo, modificado, usuario_modifica) " & _
                         "VALUES (" & txtEmpleado.Tag & ", '" & txtEmpleado.Text & "', " & txtHorario.Tag & ", '" & txtHorario.Text & "', " & _
                         "'" & Environment.MachineName & "', '" & Environment.UserName & "', " & IIf(chkHorFijo.Checked, "1", "0") & ", 1, GETDATE(),'" & pUser.Trim & "')"
            End If

            cnx.SQLEXEC(strSQL)

            If nuevo Then
                If dts.Tables.Contains("tbl_horarioxempleado") Then
                    dts.Tables("tbl_horarioxempleado").Rows.Clear()
                End If

                strSQL = "SELECT DISTINCT S.id_linea, E.empID, E.nombre, S.id_horario, S.horario as Horario, s.horarioFijo " & vbNewLine & _
                         "FROM view_sl_empleados AS E INNER JOIN TBL_HORARIOXEMPLEADO AS S ON S.empID = convert(int,E.empid) " & vbNewLine & _
                         "INNER JOIN TBL_JEFE_SECCION AS F ON F.deptID = Substring(E.CENTRO_COSTO,1,2) " & vbNewLine & _
                         "WHERE (estado_empleado = 'ACT') " & IIf(verTodos, "", " AND (jefe = '" & pempID.ToString.Trim() & "')")

                cnx.SQLEXEC(dts, strSQL, "tbl_horarioxempleado")
            End If
            BindingContext(dts, "tbl_horarioxempleado").Position = pos
            MessageBox.Show("Proceso concluido con éxito.", "GUARDAR DATOS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        If nuevo Then
            dts.Tables("tbl_horarioxempleado").Rows(pos).Delete()
        End If
        Me.Close()
    End Sub

    Private Sub FrmBuscaEmpHorario_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
    End Sub

    Private Sub FrmBuscaEmpHorario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnt.Enabled = False

        BindingContext(dts, "tbl_horarioxempleado").Position = pos

        txtEmpleado.DataBindings.Add("text", dts, "tbl_horarioxempleado.nombre")
        txtEmpleado.DataBindings.Add("tag", dts, "tbl_horarioxempleado.empid")

        txtHorario.DataBindings.Add("text", dts, "tbl_horarioxempleado.horario")
        txtHorario.DataBindings.Add("tag", dts, "tbl_horarioxempleado.id_horario")

        idLinea = IIf(nuevo, 0, dts.Tables("tbl_horarioxempleado").Rows(pos).Item("id_linea"))
        chkHorFijo.DataBindings.Add("checked", dts, "tbl_horarioxempleado.horarioFijo", True)

    End Sub

    Private Sub lblEmpleado_Click_1(sender As System.Object, e As System.EventArgs) Handles lblEmpleado.Click
        Dim pntEmp As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pntEmp.Text = "BUSQUEDA DE COLABORADOR"
        pntEmp.strTabla = "tbl_Busqueda"
        pntEmp.strConsulta = _
            "DECLARE @userid AS VARCHAR(5)" & vbNewLine & _
            "SET @userid = '" & pempID.ToString.Trim & "'" & vbNewLine & _
            "" & vbNewLine & _
            "SELECT E.empID, E.nombre FROM view_sl_empleados AS E WHERE(e.estado_empleado = 'ACT')" & IIf(verTodos, "", " AND (RTRIM(LTRIM(E.JEFE)) = @userid)")

        If pntEmp.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pntEmp.result, DataRowView)
        End If
        pntEmp.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtEmpleado.Tag = result.Item("empid")
        txtEmpleado.Text = result.Item("nombre")
    End Sub

    Private Sub lblHorario_Click_1(sender As System.Object, e As System.EventArgs) Handles lblHorario.Click
        Dim pntHor As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pntHor.Text = "BUSQUEDA DE HORARIO"
        pntHor.strTabla = "tbl_Busqueda"
        pntHor.strConsulta = "SELECT id_horario as id , detalle as Nombre FROM TBL_TIPO_HORARIO"

        If pntHor.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pntHor.result, DataRowView)
        End If
        pntHor.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtHorario.Tag = result.Item("id")
        txtHorario.Text = result.Item("Nombre")
    End Sub

End Class