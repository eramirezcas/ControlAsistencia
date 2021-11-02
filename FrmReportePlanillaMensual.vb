Public Class FrmReportePlanillaMensual
    Dim dts As New DataSet
    Dim dt As New DataTable()
    Dim fileExist As Boolean = False

    Private Sub FrmReportePlanillaMensual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fileExist = System.IO.File.Exists("C:\APROGRAMAS\RPTPMCONF.XML")

        If fileExist Then
            Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTPMCONF.XML").Length
            If filesize > 0 Then
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTPMCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()
            End If
        End If
        Label2.Visible = False
        DesActiva(True)
    End Sub

    Private Sub FrmReportePlanillaMensual_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim filesize As Integer = 0
        If fileExist Then
            filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTPMCONF.XML").Length
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

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()

        dt.TableName = "dtResult"
        dts.Tables.Add(dt)

        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "dtResult"
        pntexcel.titulo = "REPORTE DE PLANILLA MENSUAL"
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        DataGridView1.DataMember = Nothing
        DataGridView1.DataSource = Nothing
        dt.Rows.Clear()
        dt.Columns.Clear()
        DataGridView1.Refresh()
        DesActiva(True)
    End Sub

    Private Sub btnFilterConf_Click(sender As Object, e As EventArgs) Handles btnFilterConf.Click
        Dim pnt As New FrmReportePlanillaMensual_filtros()
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
                Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTPMCONF.XML").Length
                If filesize > 0 Then
                    Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTPMCONF.XML")
                    dts.Tables.Clear()
                    dts.ReadXml(stfile)
                    stfile.Close()
                End If
            End If

            Dim param1 As String, param2 As String, param3 As String, param4 As String, param5 As String

            If dts.Tables("dtFechas").Rows.Count = 0 Or dts.Tables("dtTipNomina").Rows.Count = 0 Or dts.Tables("dtConceptos").Rows.Count = 0 Then
                MessageBox.Show("Aun no configura los parametros, para continuar configure los parametros y vuelva a intentar.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            param1 = dts.Tables("dtFechas").Rows(0).Item("anio").ToString().Trim()
            param2 = dts.Tables("dtFechas").Rows(0).Item("num_mes").ToString().Trim()

            For i As Integer = 0 To dts.Tables("dtTipNomina").Rows.Count - 1
                param3 += "'" & dts.Tables("dtTipNomina").Rows(i).Item("nomina").ToString() & "',"
            Next
            param3 = param3.Substring(0, param3.Length - 1)

            For i As Integer = 0 To dts.Tables("dtConceptos").Rows.Count - 1
                param4 += "'" & dts.Tables("dtConceptos").Rows(i).Item("descripcion").ToString() & "',"
                param5 += "[" & dts.Tables("dtConceptos").Rows(i).Item("descripcion").ToString() & "],"
            Next
            param4 = param4.Substring(0, param4.Length - 1)
            param5 = param5.Substring(0, param5.Length - 1)

            Label2.Visible = True
            Me.Refresh()
            Label2.Visible = GeneraQuery(param1, param2, param3, param4, param5)
            DesActiva(False)
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DesActiva(ByVal pbActiva As Boolean)
        btnFilterConf.Enabled = pbActiva
        btnGenerar.Enabled = pbActiva
        btnExcel.Enabled = Not pbActiva
        btnLimpiar.Enabled = Not pbActiva
    End Sub
    Private Function GeneraQuery(ByVal par1 As String, ByVal par2 As String, ByVal par3 As String, ByVal par4 As String, ByVal par5 As String) As Boolean
        Try

            Dim strSQL As String =
                "use SOFTLAND" & vbNewLine &
                "" & vbNewLine &
                "DECLARE @anio as int" & vbNewLine &
                "declare @mes as int" & vbNewLine &
                "" & vbNewLine &
                "set @anio = " & par1.Trim() & vbNewLine &
                "set @mes = " & par2.Trim() & vbNewLine &
                "" & vbNewLine &
                "SELECT * " & vbNewLine &
                "FROM" & vbNewLine &
                "(" & vbNewLine &
                "	SELECT D.DESCRIPCION AS DEPARTAMENTO" & vbNewLine &
                "		, CC.DESCRIPCION AS CENTRO_COSTO" & vbNewLine &
                "       , P.DESCRIPCION AS PUESTO" & vbNewLine &
                "		, CN.EMPLEADO" & vbNewLine &
                "		, E.NOMBRE" & vbNewLine &
                "		, E.SALARIO_REFERENCIA" & vbNewLine &
                "		--, CN.NUMERO_NOMINA" & vbNewLine &
                "		, CO.DESCRIPCION AS CONCEPTO" & vbNewLine &
                "		, SUM(CN.TOTAL) AS TOTAL" & vbNewLine &
                "	FROM SOFTLAND.CRCC01.EMPLEADO_CONC_NOMI AS CN" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.NOMINA_HISTORICO AS NH ON CN.NOMINA = NH.NOMINA AND CN.NUMERO_NOMINA = NH.NUMERO_NOMINA" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON CN.EMPLEADO = E.EMPLEADO" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.CENTRO_COSTO AS CC ON CN.CENTRO_COSTO = CC.CENTRO_COSTO" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.CONCEPTO AS CO ON CN.CONCEPTO = CO.CONCEPTO" & vbNewLine &
                "		INNER JOIN SOFTLAND.CRCC01.DEPARTAMENTO AS D ON D.DEPARTAMENTO = E.DEPARTAMENTO" & vbNewLine &
                "       INNER JOIN SOFTLAND.CRCC01.PUESTO AS P ON P.PUESTO = E.PUESTO" & vbNewLine &
                "	WHERE CN.NOMINA in (" & par3.Trim() & ")" & vbNewLine &
                "		AND CN.NUMERO_NOMINA in (SELECT NUMERO_NOMINA FROM SOFTLAND.CRCC01.NOMINA_HISTORICO " & vbNewLine &
                "									WHERE YEAR(FECHA_INICIO)=@anio AND MONTH(FECHA_INICIO)=@mes" & vbNewLine &
                "								)" & vbNewLine &
                "		AND CO.DESCRIPCION IN (" & par4.Trim() & ")" & vbNewLine &
                "	GROUP BY D.DESCRIPCION" & vbNewLine &
                "		, CC.DESCRIPCION" & vbNewLine &
                "       , P.DESCRIPCION" & vbNewLine &
                "		, CN.EMPLEADO" & vbNewLine &
                "		, E.NOMBRE" & vbNewLine &
                "		, E.SALARIO_REFERENCIA" & vbNewLine &
                "		, CO.DESCRIPCION" & vbNewLine &
                ") AS X" & vbNewLine &
                "PIVOT(SUM(X.TOTAL) FOR X.CONCEPTO IN (" & par5.Trim() & ")" & vbNewLine &
                "	) AS XPVT" & vbNewLine &
                "order by 1,2"

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
End Class