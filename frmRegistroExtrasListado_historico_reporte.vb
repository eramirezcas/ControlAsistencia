Public Class frmRegistroExtrasListado_historico_reporte
    Dim dts As New DataSet
    Dim dt As New DataTable()
    Dim fileExist As Boolean = False

    Private Sub frmRegistroExtrasListado_historico_reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fileExist = System.IO.File.Exists("C:\APROGRAMAS\RPTHEXCONF.XML")

        If fileExist Then
            Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTHEXCONF.XML").Length
            If filesize > 0 Then
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTHEXCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()
            End If
        End If
        Label2.Visible = False
        DesActiva(True)

    End Sub

    Private Sub frmRegistroExtrasListado_historico_reporte_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmRegistroExtrasListado_historico_reporte_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim filesize As Integer = 0
        If fileExist Then
            filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTHEXCONF.XML").Length
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
        Dim pnt As New frmRegistroExtrasListado_historico_x_periodos_filtros()
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
                Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTHEXCONF.XML").Length
                If filesize > 0 Then
                    Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTHEXCONF.XML")
                    dts.Tables.Clear()
                    dts.ReadXml(stfile)
                    stfile.Close()
                End If
            End If

            Dim param1 As String, param2 As String, param3 As String
            Dim param4 As String, param5 As String, param6 As String
            Dim tmpDate As DateTime

            For i As Integer = 0 To dts.Tables("dtNominas").Rows.Count - 1
                tmpDate = dts.Tables("dtNominas").Rows(i).Item("Fecha_inicio")
                param1 += "[" & tmpDate.Year.ToString() & tmpDate.Month.ToString() & "],"
                i += 1
            Next
            param1 = param1.Substring(0, param1.Length - 1)

            Dim arr() As String = param1.Split(",")
            For i As Integer = 0 To arr.Length - 1
                param2 += ",CASE WHEN Hor." & arr(i) & " IS NULL THEN 0 ELSE Hor." & arr(i) & " END AS " & arr(i).Substring(0, 1) & "H" & arr(i).Substring(1, arr(i).Length() - 1) & vbNewLine &
                          ",CASE WHEN MON." & arr(i) & " IS NULL THEN 0 ELSE MON." & arr(i) & " END AS " & arr(i).Substring(0, 1) & "M" & arr(i).Substring(1, arr(i).Length() - 1) & vbNewLine
            Next

            For i As Integer = 0 To dts.Tables("dtConceptos").Rows.Count - 1
                param3 += "'" & dts.Tables("dtConceptos").Rows(i).Item("Concepto").ToString() & "',"
            Next
            param3 = param3.Substring(0, param3.Length - 1)

            param4 = dts.Tables("dtTipNom").Rows(0).Item("Nomina").ToString()

            param5 = dts.Tables("dtNominas").Rows(0).Item("Numero_Nomina").ToString()

            param6 = dts.Tables("dtNominas").Rows(dts.Tables("dtNominas").Rows.Count - 1).Item("Numero_Nomina").ToString()

            Label2.Visible = True
            Me.Refresh()
            Label2.Visible = GeneraQuery(param1, param2, param3, param4, param5, param6)
            DesActiva(False)
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GeneraQuery(ByVal par1 As String, ByVal par2 As String, ByVal par3 As String, ByVal par4 As String, ByVal par5 As String, ByVal par6 As String) As Boolean
        Try

            Dim strSQL As String =
            "SELECT " & vbNewLine &
            "	 Hor.DEPARTAMENTO" & vbNewLine &
            "	,Hor.SECCION" & vbNewLine &
            "	,Hor.PUESTO" & vbNewLine &
            "	,Hor.EMPLEADO" & vbNewLine &
            "	,Hor.NOMBRE" & vbNewLine &
            "	,Hor.IDENTIFICACION" & vbNewLine &
            "	,Hor.SALARIO_REFERENCIA" & vbNewLine &
            par2 &
            "FROM " & vbNewLine &
            "(" & vbNewLine &
            "	Select pvt.* " & vbNewLine &
            "	from" & vbNewLine &
            "	(	" & vbNewLine &
            "		select a.*" & vbNewLine &
            "			,b.mes" & vbNewLine &
            "			,b.horasmes" & vbNewLine &
            "		from" & vbNewLine &
            "		(	" & vbNewLine &
            "			SELECT DISTINCT DEPARTAMENTO.DESCRIPCION AS DEPARTAMENTO" & vbNewLine &
            "				,CENTRO_COSTO.DESCRIPCION AS SECCION" & vbNewLine &
            "				,UPPER(PUESTO.DESCRIPCION) AS PUESTO" & vbNewLine &
            "				,EMPLEADO_CONC_NOMI.EMPLEADO" & vbNewLine &
            "				,EMPLEADO.NOMBRE" & vbNewLine &
            "				,EMPLEADO.IDENTIFICACION" & vbNewLine &
            "				,EMPLEADO.SALARIO_REFERENCIA" & vbNewLine &
            "			FROM SOFTLAND.CRCC01.EMPLEADO_CONC_NOMI" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.EMPLEADO ON EMPLEADO_CONC_NOMI.EMPLEADO = EMPLEADO.EMPLEADO" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.CENTRO_COSTO ON EMPLEADO.CENTRO_COSTO = CENTRO_COSTO.CENTRO_COSTO" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.DEPARTAMENTO ON EMPLEADO.DEPARTAMENTO = DEPARTAMENTO.DEPARTAMENTO" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.PUESTO ON EMPLEADO.PUESTO = PUESTO.PUESTO" & vbNewLine &
            "			WHERE (EMPLEADO_CONC_NOMI.NOMINA = '" & par4 & "')" & vbNewLine &
            "				AND (EMPLEADO_CONC_NOMI.CONCEPTO in (" & par3 & "))" & vbNewLine &
            "		) as A inner join" & vbNewLine &
            "		(" & vbNewLine &
            "			SELECT ecn.EMPLEADO" & vbNewLine &
            "				,CONVERT(CHAR(4),YEAR(nh.FECHA_INICIO)) + CONVERT(CHAR(2),MONTH(nh.FECHA_INICIO)) AS MES" & vbNewLine &
            "				,SUM(ecn.TOTAL) / SUM(ecn.CANTIDAD) AS hora" & vbNewLine &
            "				,SUM(ecn.TOTAL) AS MONTO_EXT" & vbNewLine &
            "				,SUM(ecn.CANTIDAD) AS horasmes" & vbNewLine &
            "			FROM SOFTLAND.CRCC01.empleado_conc_nomi AS ecn" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.nomina_historico AS nh ON ecn.NUMERO_NOMINA = nh.NUMERO_NOMINA" & vbNewLine &
            "					AND ecn.NOMINA = nh.NOMINA" & vbNewLine &
            "			WHERE ecn.nomina = '" & par4 & "'" & vbNewLine &
            "				AND ecn.CONCEPTO in (" & par3 & ")" & vbNewLine &
            "				AND ecn.numero_nomina BETWEEN " & par5 & " AND " & par6 & " " & vbNewLine &
            "				AND ecn.EMPLEADO IN (" & vbNewLine &
            "					SELECT DISTINCT EMPLEADO FROM SOFTLAND.CRCC01.empleado_conc_nomi" & vbNewLine &
            "					WHERE nomina = '" & par4 & "' AND concepto in (" & par3 & ")" & vbNewLine &
            "					)" & vbNewLine &
            "			GROUP BY ecn.EMPLEADO" & vbNewLine &
            "				,CONVERT(CHAR(4),YEAR(nh.FECHA_INICIO)) + CONVERT(CHAR(2),MONTH(nh.FECHA_INICIO))" & vbNewLine &
            "		) as b on a.EMPLEADO = b.EMPLEADO" & vbNewLine &
            "	) as C" & vbNewLine &
            "	pivot" & vbNewLine &
            "	(sum(horasmes) for mes in (" & par1 & ")) as pvt" & vbNewLine &
            ") as Hor" & vbNewLine &
            "	inner join" & vbNewLine &
            "(" & vbNewLine &
            "	Select pvt.*" & vbNewLine &
            "	from" & vbNewLine &
            "	(" & vbNewLine &
            "		select a.*" & vbNewLine &
            "			,b.mes" & vbNewLine &
            "			,b.MONTO_EXT" & vbNewLine &
            "		from" & vbNewLine &
            "		(" & vbNewLine &
            "			SELECT DISTINCT DEPARTAMENTO.DESCRIPCION AS DEPARTAMENTO" & vbNewLine &
            "				,CENTRO_COSTO.DESCRIPCION AS SECCION" & vbNewLine &
            "				,UPPER(PUESTO.DESCRIPCION) AS PUESTO" & vbNewLine &
            "				,EMPLEADO_CONC_NOMI.EMPLEADO" & vbNewLine &
            "				,EMPLEADO.NOMBRE" & vbNewLine &
            "				,EMPLEADO.IDENTIFICACION" & vbNewLine &
            "				,EMPLEADO.SALARIO_REFERENCIA" & vbNewLine &
            "			FROM SOFTLAND.CRCC01.EMPLEADO_CONC_NOMI" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.EMPLEADO ON EMPLEADO_CONC_NOMI.EMPLEADO = EMPLEADO.EMPLEADO" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.CENTRO_COSTO ON EMPLEADO.CENTRO_COSTO = CENTRO_COSTO.CENTRO_COSTO" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.DEPARTAMENTO ON EMPLEADO.DEPARTAMENTO = DEPARTAMENTO.DEPARTAMENTO" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.PUESTO ON EMPLEADO.PUESTO = PUESTO.PUESTO" & vbNewLine &
            "			WHERE (EMPLEADO_CONC_NOMI.NOMINA = '" & par4 & "')" & vbNewLine &
            "				AND (EMPLEADO_CONC_NOMI.CONCEPTO in (" & par3 & "))" & vbNewLine &
            "		) as A inner join" & vbNewLine &
            "		(" & vbNewLine &
            "			SELECT ecn.EMPLEADO" & vbNewLine &
            "				,CONVERT(CHAR(4),YEAR(nh.FECHA_INICIO)) + CONVERT(CHAR(2),MONTH(nh.FECHA_INICIO)) AS MES" & vbNewLine &
            "				,SUM(ecn.TOTAL) / SUM(ecn.CANTIDAD) AS hora" & vbNewLine &
            "				,SUM(ecn.TOTAL) AS MONTO_EXT" & vbNewLine &
            "				,SUM(ecn.CANTIDAD) AS horasmes" & vbNewLine &
            "			FROM SOFTLAND.CRCC01.empleado_conc_nomi AS ecn" & vbNewLine &
            "				INNER JOIN SOFTLAND.CRCC01.nomina_historico AS nh ON ecn.NUMERO_NOMINA = nh.NUMERO_NOMINA" & vbNewLine &
            "					AND ecn.NOMINA = nh.NOMINA" & vbNewLine &
            "			WHERE ecn.nomina = '" & par4 & "'" & vbNewLine &
            "				AND ecn.CONCEPTO in (" & par3 & ")" & vbNewLine &
            "				AND ecn.numero_nomina BETWEEN " & par5 & " AND " & par6 & " " & vbNewLine &
            "				AND ecn.EMPLEADO IN (" & vbNewLine &
            "					SELECT DISTINCT EMPLEADO FROM SOFTLAND.CRCC01.empleado_conc_nomi" & vbNewLine &
            "					WHERE nomina = '" & par4 & "' AND concepto in (" & par3 & ")" & vbNewLine &
            "					)" & vbNewLine &
            "			GROUP BY ecn.EMPLEADO" & vbNewLine &
            "				,CONVERT(CHAR(4),YEAR(nh.FECHA_INICIO)) + CONVERT(CHAR(2),MONTH(nh.FECHA_INICIO))" & vbNewLine &
            "		) as b on a.EMPLEADO = b.EMPLEADO" & vbNewLine &
            "	) as C" & vbNewLine &
            "	pivot" & vbNewLine &
            "	(sum(MONTO_EXT) for mes in (" & par1 & ")) as pvt" & vbNewLine &
            ") as MON on HOR.DEPARTAMENTO = MON.DEPARTAMENTO" & vbNewLine &
            "			AND	HOR.SECCION = MON.SECCION" & vbNewLine &
            "			AND	HOR.PUESTO = MON.PUESTO" & vbNewLine &
            "			AND	HOR.EMPLEADO = MON.EMPLEADO" & vbNewLine &
            ""

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