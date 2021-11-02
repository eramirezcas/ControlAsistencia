Public Class FrmBuscar

    Public pnt As FrmMantenimientoJefesSecciones
    Public dtsForm As DataSet

    Dim opcion As Integer
    Dim idemp As Integer
    Dim iddep As Integer

    Private Sub FrmBuscar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnt.Enabled = False
    End Sub

    Private Sub FrmBuscar_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        pnt.Enabled = True
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            idemp = txtempid.Text
            iddep = txtdepid.Text

            If Not txtJefe.Text = "" And Not txtDepartamento.Text = "" Then
                Dim strSQL As String = "SELECT * FROM tbl_jefe_seccion"

                cnx.SQLEXEC(dtsForm, strSQL, "tbl_jefe_seccion")
                strSQL = "INSERT INTO tbl_jefe_seccion(empid, empname, deptid, deptname)" & vbNewLine & _
                         "VALUES (" & Val(idemp) & ", '" & txtJefe.Text & "', " & Val(iddep) & ", '" & _
                                    txtDepartamento.Text & "')"
                cnx.SQLEXEC(strSQL)
                pnt.CargaGrid()
                pnt.Enabled = True
                Close()
            Else
                MessageBox.Show("Imposible realizar la acción porque no ha ingresado datos aun.", "IMPORTANTE!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub lblJefe_Click_1(sender As System.Object, e As System.EventArgs) Handles lblJefe.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE JEFE DE DEPARTAMENTO"
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
    End Sub

    Private Sub lblDepartamento_Click_1(sender As System.Object, e As System.EventArgs) Handles lblDepartamento.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE DEPARTAMENTO"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = "SELECT substring(ID_CENTRO_COSTO,1,2) as CODE, CENTRO_COSTO as NAME FROM view_sl_secciones WHERE ID_CENTRO_COSTO not in ('00-00-00','ND')"

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtdepid.Text = result.Item("code")
        txtDepartamento.Text = result.Item("name")
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class