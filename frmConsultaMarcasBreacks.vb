Public Class frmConsultaMarcasBreacks

    Dim dts As New DataSet()
    Dim pCodigo As Integer = 0

    Private Sub DesActiva(ByVal pActiva As Boolean)
        btnImprimir.Enabled = pActiva
        btnExcel.Enabled = pActiva
        btnBuscar.Enabled = Not pActiva
        dtpInicio.Enabled = Not pActiva
        dtpFinal.Enabled = Not pActiva
        btnCargar.Text = IIf(pActiva, "Limpiar", "Cargar")
        txtNombre.Text = IIf(Not pActiva, "", txtNombre.Text)
        pCodigo = IIf(Not pActiva, 0, pCodigo)

        If Not pActiva Then
            If dts.Tables.Contains("tbl_marcas_breaks") Then
                dts.Tables("tbl_marcas_breaks").Rows.Clear()
                dts.Tables.Remove("tbl_marcas_breaks")
                DataGridView1.Columns.Clear()
            End If
        End If
    End Sub

    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        Try
            Dim obj As Button = CType(sender, Button)

            If obj.Text.Trim = "Cargar" Then

                If pCodigo = 0 Then
                    MessageBox.Show("Debe seleccionar un colaborador para poder realizar el proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If dtpInicio.Value.Date >= dtpFinal.Value.Date Then
                    MessageBox.Show("Las fecha inicial debe ser menor a la fecha final y no pueden ser iguales.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If dts.Tables.Contains("tbl_marcas_breaks") Then
                    dts.Tables("tbl_marcas_breaks").Rows.Clear()
                End If

                Dim strSQL As String = _
                    "DECLARE @codigo as VARCHAR(7)" & vbNewLine & _
                    "DECLARE @fechainicial as datetime" & vbNewLine & _
                    "DECLARE @fechafinal as datetime" & vbNewLine & _
                    "" & vbNewLine & _
                    "SET @codigo = '" & pCodigo & "'" & vbNewLine & _
                    "SET @fechainicial = CONVERT(DATETIME,'" & Format(dtpInicio.Value, "dd/MM/yyyy") & "',103)" & vbNewLine & _
                    "SET @fechafinal = CONVERT(DATETIME,'" & Format(dtpFinal.Value, "dd/MM/yyyy") & " 23:59:59.999',103)" & vbNewLine & _
                    "" & vbNewLine & _
                    "SELECT empid, nombre, marca, detalle, tipo_marca, ubicacion FROM tbl_marcas_breaks" & vbNewLine & _
                    "WHERE (RTRIM(LTRIM(empid)) = RTRIM(LTRIM(@codigo))) AND (marca between @fechainicial and @fechafinal)" & vbNewLine & _
                    "ORDER BY marca"

                cnx.SQLEXEC(dts, strSQL, "tbl_marcas_breaks")

                If dts.Tables("tbl_marcas_breaks").Rows.Count = 0 Then
                    MessageBox.Show("La consulta no generó resultados", "ADVERTENCIA !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    dts.Tables("tbl_marcas_breaks").Rows.Clear()
                    DesActiva(False)
                    Exit Sub
                End If

                DataGridView1.DataSource = dts
                DataGridView1.DataMember = "tbl_marcas_breaks"

                DesActiva(True)
            Else
                DesActiva(False)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE COLABORADOR"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = _
            "DECLARE @userid AS VARCHAR(5)" & vbNewLine & _
            "SET @userid = '" & pempID.ToString.Trim & "'" & vbNewLine & _
            "" & vbNewLine & _
            "SELECT E.empID, E.nombre FROM view_sl_empleados AS E WHERE(e.estado_empleado = 'ACT')" & IIf(verTodos, "", " AND (JEFE = @userid)")

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            pCodigo = 0
            Exit Sub
        End If

        pCodigo = result.Item("empid")
        txtNombre.Text = result.Item("nombre")


    End Sub

    Private Sub frmConsultaMarcasBreacks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DesActiva(False)
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tbl_marcas_breaks"
        pntexcel.titulo = "CONSULTA DE MARCAS"
        pntexcel.filtro = "MARCAS DEL COLABORADOR: " & txtNombre.Text
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

End Class