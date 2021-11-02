Imports System.Drawing.Drawing2D
Public Class FrmListaPermisos

    Public dtsForm As DataSet
    Public Opcion As Integer = 1

    Dim Tabla As String = "Qpermisos"
    Dim encontrado As Boolean = False
    Dim valor = 2
    Dim strSQL As String
    Dim strSQL2 As String

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer
        Dim strLinea As String = ""

        If pos <= dtsForm.Tables(Tabla).Rows.Count - 1 Then
            For i = 0 To 1
                strLinea += dtsForm.Tables(Tabla).Rows(pos).Item(dgvHorarios.Columns(i).DataPropertyName).ToString & vbTab
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

    Public Sub CargaGrid()
        Try
            If dtsForm.Tables.Contains(Tabla) Then
                dtsForm.Tables.Remove(Tabla)
            End If

            strSQL = "SELECT case when p.Id_item is null then CAST(0 AS BIT) else CAST(1 AS BIT) end as permitido, pl.id_item, pl.Item " & vbNewLine & _
                    "FROM tbl_control_asistencia_lista_permisos AS pl LEFT OUTER JOIN " & vbNewLine & _
                    "(SELECT * FROM tbl_control_asistencia_permisos " & vbNewLine & _
                    "WHERE (empid = " & dtsForm.Tables("tbl_control_asistencia_usuarios").Rows(Me.Tag).Item("empid") & ")) AS p ON p.id_Item = pl.id_Item " & vbNewLine & _
                    "ORDER BY id_item"

            cnx.SQLEXEC(dtsForm, strSQL, Tabla)
            dgvHorarios.DataSource = dtsForm
            dgvHorarios.DataMember = Tabla

            dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvHorarios.AllowUserToAddRows = False
            dgvHorarios.AllowUserToResizeColumns = False
            dgvHorarios.AllowUserToDeleteRows = False
            dgvHorarios.AllowUserToResizeRows = False
            dgvHorarios.MultiSelect = False

            'dgvHorarios.Columns(0).Visible = False
            'dgvHorarios.Columns(0).HeaderText = "ID Item"
            dgvHorarios.Columns(0).Width = 73

            dgvHorarios.Columns(1).Width = 73

            dgvHorarios.Columns(2).HeaderText = "Nombre"
            dgvHorarios.Columns(2).Width = 250
            dgvHorarios.Columns(2).ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub FrmListaPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim codigo As Integer = dtsForm.Tables("tbl_control_asistencia_usuarios").Rows(Me.Tag).Item("empid")

            strSQL2 = ""

            cnx.SQLEXEC(dtsForm, "Select * from tbl_control_asistencia_permisos where empid = " & codigo & "", "consulta_usuarios")

            If dtsForm.Tables("consulta_usuarios").Rows.Count = 0 Then
                BindingContext(dtsForm, Tabla).Position = 0
                For i = 0 To dtsForm.Tables(Tabla).Rows.Count - 1
                    If dtsForm.Tables(Tabla).Rows(i).Item("permitido") = True Then
                        strSQL2 = "Insert Into tbl_control_asistencia_permisos(empid, id_item)" _
                       & " values (" & codigo & ", " _
                       & "" & dtsForm.Tables("Qpermisos").Rows(i).Item("id_item") & ")"
                        cnx.SQLEXEC(strSQL2)
                    End If
                    BindingContext(dtsForm, Tabla).Position += 1
                Next
            Else
                cnx.SQLEXEC("DELETE from tbl_control_asistencia_permisos where empid = " & codigo)
                BindingContext(dtsForm, Tabla).Position = 0
                For i = 0 To dtsForm.Tables(Tabla).Rows.Count - 1
                    If dtsForm.Tables(Tabla).Rows(i).Item("permitido") = True Then
                        strSQL2 = "Insert Into tbl_control_asistencia_permisos(empid, id_item)" _
                       & " values (" & codigo & ", " _
                       & "" & dtsForm.Tables("Qpermisos").Rows(i).Item("id_item") & ")"
                        cnx.SQLEXEC(strSQL2)
                    End If
                    BindingContext(dtsForm, Tabla).Position += 1
                Next
            End If
            frmPermisos.Enabled = True
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.Close()
        End Try
    End Sub

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        frmPermisos.Enabled = True
        Me.Close()
    End Sub

    Private Sub dgvHorarios_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellContentClick
        dgvHorarios.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub
End Class