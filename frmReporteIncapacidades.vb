Public Class frmReporteIncapacidades
    Dim dts As New DataSet
    Dim dt As New DataTable()
    Dim fileExist As Boolean = False

    Private Sub frmReporteIncapacidades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fileExist = System.IO.File.Exists("C:\APROGRAMAS\RPTINCCONF.XML")

        If fileExist Then
            Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTINCCONF.XML").Length
            If filesize > 0 Then
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTINCCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()
            End If
        End If
        Label2.Visible = False
        DesActiva(True)

    End Sub

    Private Sub frmReporteIncapacidades_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim filesize As Integer = 0
        If fileExist Then
            filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTINCCONF.XML").Length
        End If

        If filesize = 0 Or Not fileExist Then
            If MessageBox.Show("Debe de cargar el archivo de configuracion para poder continuar." &
                               "¿ Desea realizar el proceso ahora ?",
                               "CARGA DE DATOS",
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) = DialogResult.No Then
                Me.Close()
            Else
                btnFilterConf.PerformClick()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnFilterConf.Click
        Dim pnt As New frmReporteIncapacidades_filtros()
        pnt.frmParent = Me
        pnt.MdiParent = Me.MdiParent
        pnt.StartPosition = FormStartPosition.CenterScreen
        pnt.Show()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try

            If dts.Tables.Contains("dtResult") Then
                dts.Tables.Remove("dtResult")
            End If

            If fileExist Then
                Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTINCCONF.XML").Length
                If filesize > 0 Then
                    Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTINCCONF.XML")
                    dts.Tables.Clear()
                    dts.ReadXml(stfile)
                    stfile.Close()
                End If
            End If

            Dim param1 As String, param2 As String

            If dts.Tables("dtFechas").Rows.Count = 0 Or dts.Tables("dtTipAccion").Rows.Count = 0 Then
                MessageBox.Show("Aun no configura los parametros, para continuar configure los parametros y vuelva a intentar.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            param1 = "CONVERT(DATETIME,'" & Format("dd/MM/yyyy", dts.Tables("dtFechas").Rows(0).Item("Fecha_inicio")) & "',103) And " &
                     "CONVERT(DATETIME,'" & Format("dd/MM/yyyy", dts.Tables("dtFechas").Rows(0).Item("Fecha_fin")) & "',103)"

            For i As Integer = 0 To dts.Tables("dtTipAccion").Rows.Count - 1
                param2 += "'" & dts.Tables("dtTipAccion").Rows(i).Item("tipo_accion").ToString() & "',"
            Next
            param2 = param2.Substring(0, param2.Length - 1)

            Label2.Visible = True
            Me.Refresh()
            Label2.Visible = GeneraQuery(param1, param2)
            DesActiva(False)
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GeneraQuery(ByVal par1 As String, ByVal par2 As String) As Boolean
        Try

            Dim strSQL As String =
                "use rrhh" & vbNewLine &
                "" & vbNewLine &
                "select e.TIPO_ACCION" & vbNewLine &
                "	, e.DEPARTAMENTO" & vbNewLine &
                "	, e.SECCION" & vbNewLine &
                "	, e.PUESTO" & vbNewLine &
                "	, e.EMPLEADO" & vbNewLine &
                "	, e.NOMBRE" & vbNewLine &
                "	, e.HORASMES" & vbNewLine &
                "	, (e.HORASMES/8) as DIASMES" & vbNewLine &
                "	, e.ACTIVO" & vbNewLine &
                "	, e.DESCRIPCION as tipoInca" & vbNewLine &
                "	, e.DIAS_ACCION" & vbNewLine &
                "	, (e.DIAS_ACCION * 8) AS HORAS_ACCION" & vbNewLine &
                "	, e.ANNO" & vbNewLine &
                "	, e.MES" & vbNewLine &
                "	, e.FECHA_RIGE" & vbNewLine &
                "	, e.FECHA_VENCE" & vbNewLine &
                "FROM " & vbNewLine &
                "( " & vbNewLine &
                "	SELECT D.DESCRIPCION AS DEPARTAMENTO" & vbNewLine &
                "		, CC.DESCRIPCION AS SECCION" & vbNewLine &
                "		, P.DESCRIPCION AS PUESTO" & vbNewLine &
                "		, EM.EMPLEADO" & vbNewLine &
                "		, EM.NOMBRE" & vbNewLine &
                "		, EM.RUBRO8 AS HORASMES" & vbNewLine &
                "		, EM.ACTIVO" & vbNewLine &
                "		, EAP.NUMERO_ACCION" & vbNewLine &
                "		, EAP.FECHA_RIGE" & vbNewLine &
                "		, EAP.FECHA_VENCE" & vbNewLine &
                "		, EAP.DIAS_ACCION" & vbNewLine &
                "		, EAP.TIPO_ACCION" & vbNewLine &
                "		, TA.DESCRIPCION" & vbNewLine &
                "		, YEAR(EAP.FECHA_RIGE) AS ANNO" & vbNewLine &
                "		, MONTH(EAP.FECHA_RIGE) AS MES" & vbNewLine &
                "	FROM SOFTLAND.CRCC01.CENTRO_COSTO AS CC" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS EM" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.DEPARTAMENTO AS D ON EM.DEPARTAMENTO = D.DEPARTAMENTO ON CC.CENTRO_COSTO = EM.CENTRO_COSTO" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.EMPLEADO_ACC_PER AS EAP ON EM.EMPLEADO = EAP.EMPLEADO" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.TIPO_ACCION AS TA ON EAP.TIPO_ACCION = TA.TIPO_ACCION" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.PUESTO AS P ON EM.PUESTO = P.PUESTO" & vbNewLine &
                "	WHERE (EAP.TIPO_ACCION IN (" & par2 & ")) " & vbNewLine &
                "		AND (EAP.FECHA_RIGE BETWEEN " & par1 & ")" & vbNewLine &
                ") AS e" & vbNewLine &
                "ORDER BY e.DEPARTAMENTO" & vbNewLine &
                "	, e.SECCION" & vbNewLine &
                "	, e.PUESTO" & vbNewLine &
                "	, e.NOMBRE" & vbNewLine &
                "	, e.ANNO" & vbNewLine &
                "	, e.MES asc"

            dt.Rows.Clear()
            dt.Columns.Clear()
            cnx.SQLEXEC(dt, strSQL)
            DataGridView1.DataSource = dt

            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                DataGridView1.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        DataGridView1.DataMember = Nothing
        DataGridView1.DataSource = Nothing
        dt.Rows.Clear()
        dt.Columns.Clear()
        DataGridView1.Refresh()
        DesActiva(True)
    End Sub

    Private Sub DesActiva(ByVal pbActiva As Boolean)
        btnFilterConf.Enabled = pbActiva
        btnGenerar.Enabled = pbActiva
        btnExcel.Enabled = Not pbActiva
        btnLimpiar.Enabled = Not pbActiva
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()

        dt.TableName = "dtResult"
        dts.Tables.Add(dt)

        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "dtResult"
        pntexcel.titulo = "REPORTE DE HORAS EXTRA"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

End Class