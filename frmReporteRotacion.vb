'--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
'--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
'-- NOTAS
'-- para averiguar el indice de rotacion de personal se ve utilizar la siguiente formula:
'--
'-- variables
'--     I    -> cantidad de ingresos en el periodo
'--     D    -> cantidad de salidas en el periodo
'--     Cin  -> cantidad de personas al inicio del periodo
'--     Cfin -> cantidad de personas al final del periodo
'--
'-- Formula
'--     IP  =  (((I+D)/2)*100)/((Cin+Cfin)/2)

Public Class frmReporteRotacion
    Dim dts As New DataSet
    Dim dt As New DataTable()
    Dim dt1 As New DataTable()
    Dim fileExist As Boolean = False
    Private Sub btnFilterConf_Click(sender As Object, e As EventArgs) Handles btnFilterConf.Click
        Dim pnt As New frmReporteRotacion_filtros()
        pnt.frmParent = Me
        pnt.MdiParent = Me.MdiParent
        pnt.StartPosition = FormStartPosition.CenterScreen
        pnt.Show()

    End Sub
    Private Sub DesActiva(ByVal pbActiva As Boolean)
        btnFilterConf.Enabled = pbActiva
        btnGenerar.Enabled = pbActiva
        btnExcel.Enabled = Not pbActiva
        btnLimpiar.Enabled = Not pbActiva
    End Sub
    Private Sub frmReporteRotacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fileExist = System.IO.File.Exists("C:\APROGRAMAS\RPTROTCONF.XML")

        If fileExist Then
            Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTROTCONF.XML").Length
            If filesize > 0 Then
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTROTCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()
            End If
        End If
        Label2.Visible = False
        DesActiva(True)
    End Sub

    Private Sub frmReporteRotacion_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim filesize As Integer = 0
        If fileExist Then
            filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTROTCONF.XML").Length
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



    Private Function GeneraQuery(ByVal par1 As String, ByVal par2 As String, ByVal par3 As String, ByVal par4 As String, ByVal par5 As String, ByVal par6 As String) As Boolean
        Try

            Dim strSQL As String = "" &
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbNewLine &
                "-- EL SIGUIENTE QUERY RETORNA EL INDICE GENERAL DE ROTACIÓN --------------------------------------------------------------------------------------------------------------" & vbNewLine &
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbNewLine &
                "SET LANGUAGE SPANISH" & vbNewLine &
                "" & vbNewLine &
                "declare @nini as int" & vbNewLine &
                "declare @nfin as int" & vbNewLine &
                "" & vbNewLine &
                "set @nini = " & par5.ToString() & vbNewLine &
                "set @nfin = " & par6.ToString() & vbNewLine &
                "" & vbNewLine &
                "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbNewLine &
                "" & vbNewLine &
                "SELECT R.anio" & vbNewLine &
                "	--, R.mes" & vbNewLine &
                "	, datename(month,convert(datetime,'1/'+CONVERT(varchar(2),r.mes)+'/'+CONVERT(varchar(4),R.anio,103),103)) as nmes" & vbNewLine &
                "	, R.N1" & vbNewLine &
                "	, R.N2" & vbNewLine &
                "	, R.CantIni" & vbNewLine &
                "	, R.CantFin" & vbNewLine &
                "	, R.entra" & vbNewLine &
                "	, R.sali" & vbNewLine &
                "	,(Convert(float,R.sali)/Convert(float,R.CantFin))*100 as IRP" & vbNewLine &
                "FROM(" & vbNewLine &
                "	select A.anio" & vbNewLine &
                "		,A.mes" & vbNewLine &
                "		,A.NUMERO_NOMINA AS N2" & vbNewLine &
                "		,A.pax As CantFin" & vbNewLine &
                "		,B.NUMERO_NOMINA AS N1" & vbNewLine &
                "		,B.pax As CantIni" & vbNewLine &
                "		,(	-- en este query saco la cantidad de salidas del mes " & vbNewLine &
                "			select COUNT(*) AS outs --, year(EAP.fecha_rige) as anio, month(EAP.fecha_rige) as mes" & vbNewLine &
                "			from SOFTLAND.crcc01.EMPLEADO_ACC_PER AS EAP INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON EAP.EMPLEADO = E.EMPLEADO" & vbNewLine &
                "			where EAP.TIPO_ACCION IN (" & par4.ToString() & ") " & vbNewLine &
                "				and EAP.ESTADO_ACCION NOT IN ('H','N') and year(EAP.fecha_rige)=A.anio and month(EAP.fecha_rige)=A.mes" & vbNewLine &
                "				" & IIf(par1 = "AMBOS", "--", "") & "AND (E.U_TEMPORAL='" & IIf(par1 <> "AMBOS", par1.ToString, "") & "')" & vbNewLine &
                "			group by year(EAP.fecha_rige), month(EAP.fecha_rige)" & vbNewLine &
                "		 ) AS sali" & vbNewLine &
                "		,(	-- en este query saco la cantidad de entradas del mes " & vbNewLine &
                "			select COUNT(*) as Ins --, year(EAP.fecha_rige) as anio, month(EAP.fecha_rige) as mes" & vbNewLine &
                "			from SOFTLAND.crcc01.EMPLEADO_ACC_PER AS EAP INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON EAP.EMPLEADO = E.EMPLEADO" & vbNewLine &
                "			where EAP.TIPO_ACCION = '" & par3.ToString & "'" & vbNewLine &
                "				and EAP.ESTADO_ACCION NOT IN ('H','N') and year(EAP.fecha_rige)=A.anio and month(EAP.fecha_rige)=A.mes" & vbNewLine &
                "				" & IIf(par1 = "AMBOS", "--", "") & "AND (E.U_TEMPORAL='" & IIf(par1 <> "AMBOS", par1.ToString, "") & "')" & vbNewLine &
                "			group by year(EAP.fecha_rige), month(EAP.fecha_rige)" & vbNewLine &
                "		) AS entra" & vbNewLine &
                "" & vbNewLine &
                "	From" & vbNewLine &
                "	(	-- en este query saco la cantidad de personas para la primera quicena de cada mas" & vbNewLine &
                "		select " & vbNewLine &
                "			 Nm.NUMERO_NOMINA" & vbNewLine &
                "			,YEAR(Nm.FECHA_INICIO) as anio" & vbNewLine &
                "			,MONTH(Nm.FECHA_INICIO) as mes" & vbNewLine &
                "			,(select COUNT(*) from (SELECT DISTINCT ENE.EMPLEADO FROM SOFTLAND.CRCC01.EMPLEADO_NOMI_NETO AS ENE INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON ENE.EMPLEADO = E.EMPLEADO WHERE " & IIf(par1 = "AMBOS", "/*", "") & "E.U_TEMPORAL = '" & IIf(par1 <> "AMBOS", par1.ToString, "") & "' AND" & IIf(par1 = "AMBOS", "*/", "") & " ENE.NOMINA = '" & par2.ToString & "' AND ENE.NUMERO_NOMINA = Nm.NUMERO_NOMINA) as a) as pax" & vbNewLine &
                "		FROM SOFTLAND.CRCC01.NOMINA_HISTORICO as Nm " & vbNewLine &
                "		where nm.NOMINA = 'QUIN' and NUMERO_NOMINA between @nini and @nfin and ((NUMERO_NOMINA%2)=0)" & vbNewLine &
                "	) AS A INNER JOIN " & vbNewLine &
                "	(	-- en este query saco la cantidad de personas para la segunda quicena de cada mas" & vbNewLine &
                "		select " & vbNewLine &
                "			 Nm.NUMERO_NOMINA" & vbNewLine &
                "			,YEAR(Nm.FECHA_INICIO) as anio" & vbNewLine &
                "			,MONTH(Nm.FECHA_INICIO) as mes" & vbNewLine &
                "			,(select COUNT(*) from (SELECT DISTINCT ENE.EMPLEADO FROM SOFTLAND.CRCC01.EMPLEADO_NOMI_NETO AS ENE INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON ENE.EMPLEADO = E.EMPLEADO WHERE " & IIf(par1 = "AMBOS", "/*", "") & "E.U_TEMPORAL = '" & IIf(par1 <> "AMBOS", par1.ToString, "") & "' AND" & IIf(par1 = "AMBOS", "*/", "") & " ENE.NOMINA = '" & par2.ToString & "' AND ENE.NUMERO_NOMINA = Nm.NUMERO_NOMINA) as a) as pax" & vbNewLine &
                "		FROM SOFTLAND.CRCC01.NOMINA_HISTORICO as Nm " & vbNewLine &
                "		where nm.NOMINA = 'QUIN' and NUMERO_NOMINA between @nini and @nfin and ((NUMERO_NOMINA%2)<>0)" & vbNewLine &
                "	) AS B ON A.anio = B.anio AND A.mes = B.mes" & vbNewLine &
                ") AS R"

            dt.Rows.Clear()
            dt.Columns.Clear()
            cnx.SQLEXEC(dt, strSQL)
            DataGridView1.DataSource = dt

            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                DataGridView1.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next


            strSQL = "" &
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbNewLine &
                "-- EL SIGUIENTE QUERY RETORNA EL INDICE GENERAL DE ROTACIÓN AGRUPADO POR SECCION -----------------------------------------------------------------------------------------" & vbNewLine &
                "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbNewLine &
                "SET LANGUAGE SPANISH" & vbNewLine &
                "" & vbNewLine &
                "declare @nini as int" & vbNewLine &
                "declare @nfin as int" & vbNewLine &
                "" & vbNewLine &
                "set @nini = " & par5.ToString() & vbNewLine &
                "set @nfin = " & par6.ToString() & vbNewLine &
                "" & vbNewLine &
                "-------------------------------------------------------------------------------------------------------------------------------------------------------------------------" & vbNewLine &
                "" & vbNewLine &
                "SELECT" & vbNewLine &
                "	 R.IDDEP" & vbNewLine &
                "	,R.DEPARTAMENTO" & vbNewLine &
                "	,R.IDCEN" & vbNewLine &
                "	,R.CENTRO_COSTO" & vbNewLine &
                "	,R.ANIO" & vbNewLine &
                "	, datename(month,convert(datetime,'1/'+CONVERT(varchar(2),r.mes)+'/'+CONVERT(varchar(4),R.anio,103),103)) as nmes" & vbNewLine &
                "	,R.N1" & vbNewLine &
                "	,R.CantIni" & vbNewLine &
                "	,R.N2" & vbNewLine &
                "	,R.CantFin" & vbNewLine &
                "	,CASE WHEN R.entra IS NULL THEN 0 ELSE R.entra END AS ENTRA" & vbNewLine &
                "	,CASE WHEN R.sali IS NULL THEN 0 ELSE R.sali END AS SALI" & vbNewLine &
                "	,((Convert(float,CASE WHEN R.sali IS NULL THEN 0 ELSE R.sali END)/Convert(float,R.CantFin))*100) as IRP" & vbNewLine &
                "FROM" & vbNewLine &
                "(" & vbNewLine &
                "	SELECT A.IDDEP" & vbNewLine &
                "		,A.DEPARTAMENTO" & vbNewLine &
                "		,A.IDCEN" & vbNewLine &
                "		,A.CENTRO_COSTO" & vbNewLine &
                "		,A.ANIO" & vbNewLine &
                "		,A.MES" & vbNewLine &
                "		,CASE WHEN A.NUMERO_NOMINA IS NULL THEN 0 ELSE A.NUMERO_NOMINA END AS N2" & vbNewLine &
                "		,CASE WHEN A.PAX IS NULL THEN 0 ELSE A.PAX END AS CantFin" & vbNewLine &
                "		,CASE WHEN B.NUMERO_NOMINA IS NULL THEN 0 ELSE B.NUMERO_NOMINA END AS N1" & vbNewLine &
                "		,CASE WHEN B.PAX IS NULL THEN 0 ELSE B.PAX END AS CantIni" & vbNewLine &
                "		,(	-- en este query saco la cantidad de salidas del mes " & vbNewLine &
                "			select COUNT(*) AS outs --, year(EAP.fecha_rige) as anio, month(EAP.fecha_rige) as mes" & vbNewLine &
                "			from SOFTLAND.crcc01.EMPLEADO_ACC_PER AS EAP INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON EAP.EMPLEADO = E.EMPLEADO" & vbNewLine &
                "			where EAP.TIPO_ACCION IN (" & par4.ToString() & ") " & vbNewLine &
                "				and EAP.ESTADO_ACCION NOT IN ('H','N') " & vbNewLine &
                "               " & IIf(par1 = "AMBOS", "--", "") & "AND (E.U_TEMPORAL='" & IIf(par1 <> "AMBOS", par1.ToString, "") & "')" & vbNewLine &
                "				and year(EAP.fecha_rige)=A.anio and month(EAP.fecha_rige)=A.mes" & vbNewLine &
                "				and E.DEPARTAMENTO = A.IDDEP AND E.CENTRO_COSTO = A.IDCEN" & vbNewLine &
                "			group by year(EAP.fecha_rige), month(EAP.fecha_rige)" & vbNewLine &
                "		 ) AS sali" & vbNewLine &
                "		,(	-- en este query saco la cantidad de entradas del mes " & vbNewLine &
                "			select COUNT(*) as Ins --, year(EAP.fecha_rige) as anio, month(EAP.fecha_rige) as mes" & vbNewLine &
                "			from SOFTLAND.crcc01.EMPLEADO_ACC_PER AS EAP INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON EAP.EMPLEADO = E.EMPLEADO" & vbNewLine &
                "			where EAP.TIPO_ACCION = '" & par3.ToString & "'" & vbNewLine &
                "				and EAP.ESTADO_ACCION NOT IN ('H','N')" & vbNewLine &
                "				" & IIf(par1 = "AMBOS", "--", "") & "AND (E.U_TEMPORAL='" & IIf(par1 <> "AMBOS", par1.ToString, "") & "')" & vbNewLine &
                "				and year(EAP.fecha_rige)=A.anio and month(EAP.fecha_rige)=A.mes" & vbNewLine &
                "				and E.DEPARTAMENTO = A.IDDEP AND E.CENTRO_COSTO = A.IDCEN" & vbNewLine &
                "			group by year(EAP.fecha_rige), month(EAP.fecha_rige)" & vbNewLine &
                "		) AS entra" & vbNewLine &
                "" & vbNewLine &
                "	FROM" & vbNewLine &
                "	(" & vbNewLine &
                "		SELECT E.DEPARTAMENTO AS IDDEP" & vbNewLine &
                "			,(SELECT DESCRIPCION FROM SOFTLAND.CRCC01.DEPARTAMENTO WHERE DEPARTAMENTO = E.DEPARTAMENTO) AS DEPARTAMENTO" & vbNewLine &
                "			,E.CENTRO_COSTO AS IDCEN" & vbNewLine &
                "			,(SELECT DESCRIPCION FROM SOFTLAND.CRCC01.CENTRO_COSTO WHERE CENTRO_COSTO = E.CENTRO_COSTO) AS CENTRO_COSTO" & vbNewLine &
                "			,ENN.NUMERO_NOMINA" & vbNewLine &
                "			,(SELECT DISTINCT YEAR(FECHA_INICIO) FROM SOFTLAND.CRCC01.NOMINA_HISTORICO WHERE NOMINA = '" & par2.ToString & "' AND NUMERO_NOMINA = ENN.NUMERO_NOMINA) AS ANIO" & vbNewLine &
                "			,(SELECT MONTH(FECHA_INICIO) FROM SOFTLAND.CRCC01.NOMINA_HISTORICO WHERE NOMINA = '" & par2.ToString & "' AND NUMERO_NOMINA = ENN.NUMERO_NOMINA) AS MES" & vbNewLine &
                "			,COUNT(*) AS PAX" & vbNewLine &
                "		FROM SOFTLAND.CRCC01.EMPLEADO_NOMI_NETO as ENN" & vbNewLine &
                "			INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON ENN.EMPLEADO = E.EMPLEADO" & vbNewLine &
                "		WHERE ENN.NOMINA = 'QUIN'" & vbNewLine &
                "           " & IIf(par1 = "AMBOS", "--", "") & "AND (E.U_TEMPORAL='" & IIf(par1 <> "AMBOS", par1.ToString, "") & "')" & vbNewLine &
                "           And ENN.NUMERO_NOMINA BETWEEN @nini And @nfin And ((NUMERO_NOMINA%2)=0)" & vbNewLine &
                "		GROUP BY NUMERO_NOMINA" & vbNewLine &
                "			,E.DEPARTAMENTO" & vbNewLine &
                "			,E.CENTRO_COSTO" & vbNewLine &
                "	) AS A INNER JOIN" & vbNewLine &
                "	(" & vbNewLine &
                "		SELECT E.DEPARTAMENTO AS IDDEP" & vbNewLine &
                "			,(SELECT DESCRIPCION FROM SOFTLAND.CRCC01.DEPARTAMENTO WHERE DEPARTAMENTO = E.DEPARTAMENTO) AS DEPARTAMENTO" & vbNewLine &
                "			,E.CENTRO_COSTO AS IDCEN" & vbNewLine &
                "			,(SELECT DESCRIPCION FROM SOFTLAND.CRCC01.CENTRO_COSTO WHERE CENTRO_COSTO = E.CENTRO_COSTO) AS CENTRO_COSTO" & vbNewLine &
                "			,ENN.NUMERO_NOMINA" & vbNewLine &
                "			,(SELECT DISTINCT YEAR(FECHA_INICIO) FROM SOFTLAND.CRCC01.NOMINA_HISTORICO WHERE NOMINA = '" & par2.ToString & "' AND NUMERO_NOMINA = ENN.NUMERO_NOMINA) AS ANIO" & vbNewLine &
                "			,(SELECT MONTH(FECHA_INICIO) FROM SOFTLAND.CRCC01.NOMINA_HISTORICO WHERE NOMINA = '" & par2.ToString & "' AND NUMERO_NOMINA = ENN.NUMERO_NOMINA) AS MES" & vbNewLine &
                "			,COUNT(*) AS PAX" & vbNewLine &
                "		FROM SOFTLAND.CRCC01.EMPLEADO_NOMI_NETO as ENN " & vbNewLine &
                "			INNER JOIN SOFTLAND.CRCC01.EMPLEADO AS E ON ENN.EMPLEADO = E.EMPLEADO" & vbNewLine &
                "		WHERE ENN.NOMINA = '" & par2.ToString & "'" & vbNewLine &
                "           " & IIf(par1 = "AMBOS", "--", "") & "AND (E.U_TEMPORAL='" & IIf(par1 <> "AMBOS", par1.ToString, "") & "')" & vbNewLine &
                "           And ENN.NUMERO_NOMINA BETWEEN @nini And @nfin And ((NUMERO_NOMINA%2)<>0)" & vbNewLine &
                "		GROUP BY NUMERO_NOMINA" & vbNewLine &
                "			,E.DEPARTAMENTO" & vbNewLine &
                "			,E.CENTRO_COSTO" & vbNewLine &
                "	) AS B ON A.ANIO = B.ANIO And A.MES = B.MES And A.IDDEP = B.IDDEP And A.IDCEN = B.IDCEN" & vbNewLine &
                ") AS R" & vbNewLine &
                "ORDER BY R.ANIO,R.MES,R.DEPARTAMENTO,R.CENTRO_COSTO"

            dt1.Rows.Clear()
            dt1.Columns.Clear()
            cnx.SQLEXEC(dt1, strSQL)
            DataGridView2.DataSource = dt1

            For i As Integer = 0 To DataGridView2.ColumnCount - 1
                DataGridView2.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next

            Return False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function


    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        DataGridView1.DataMember = Nothing
        DataGridView1.DataSource = Nothing
        DataGridView2.DataMember = Nothing
        DataGridView2.DataSource = Nothing
        DataGridView1.Refresh()
        DataGridView2.Refresh()
        DesActiva(True)
    End Sub

    Private Function xlLetra(ByVal colCnt As Integer) As String
        Dim result As String = ""
        If colCnt <= 25 Then
            result = Chr(65 + colCnt)
        Else
            result = Chr(65 + (Int(colCnt / 26) - 1))
            result += Chr(65 + ((colCnt Mod 26) - 1))
        End If
        Return result
    End Function

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try

            If (dt.Rows.Count() <= 0) Or (dt1.Rows.Count() <= 0) Then
                MessageBox.Show("No hay datos para generar la consulta.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Label2.Visible = True

            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim rango As String = xlLetra(0) & "1:" & xlLetra(dt.Columns.Count() - 1) & "1"
            Dim xlin As Integer = 0
            Dim xcol As Integer = 0

            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "RESUMEN"

            wSheet.Cells(1, 1) = "COSTA RICA COUNTRY CLUB S.A."
            wSheet.Cells.Range(rango).MergeCells = True
            wSheet.Cells.Range(rango).Font.Bold = True
            wSheet.Cells.Range(rango).Font.Size = 12

            rango = xlLetra(0) & "2:" & xlLetra(dt.Columns.Count() - 1) & "2"
            wSheet.Cells(2, 1) = "RESUMEN"
            wSheet.Cells.Range(rango).MergeCells = True
            wSheet.Cells.Range(rango).Font.Bold = True
            wSheet.Cells.Range(rango).Font.Size = 12

            xlin = 4
            xcol = 1

            '-- MONTO LOS ENCABEZADOS DE LA TABLA EN LA HOJA DE EXCEL
            For i As Integer = 0 To dt.Columns.Count - 1
                wSheet.Cells(xlin, xcol + i) = dt.Columns(i).ColumnName.ToUpper.Trim()
            Next

            xlin += 1
            For i As Integer = 0 To dt.Rows.Count - 1
                wSheet.Cells(xlin + i, xcol + 0) = dt.Rows(i).Item("ANIO").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 1) = dt.Rows(i).Item("NMES").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 2) = dt.Rows(i).Item("N1").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 3) = dt.Rows(i).Item("N2").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 4) = dt.Rows(i).Item("CANTINI").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 5) = dt.Rows(i).Item("CANTFIN").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 6) = dt.Rows(i).Item("ENTRA").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 7) = dt.Rows(i).Item("SALI").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 8) = dt.Rows(i).Item("IRP").ToString.Trim()
            Next

            wBook.Sheets.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "DETALLE"

            rango = xlLetra(0) & "1:" & xlLetra(dt1.Columns.Count() - 1) & "1"
            xlin = 0
            xcol = 0

            wSheet.Cells(1, 1) = "COSTA RICA COUNTRY CLUB S.A."
            wSheet.Cells.Range(rango).MergeCells = True
            wSheet.Cells.Range(rango).Font.Bold = True
            wSheet.Cells.Range(rango).Font.Size = 12

            rango = xlLetra(0) & "2:" & xlLetra(dt1.Columns.Count() - 1) & "2"
            wSheet.Cells(2, 1) = "DETALLE"
            wSheet.Cells.Range(rango).MergeCells = True
            wSheet.Cells.Range(rango).Font.Bold = True
            wSheet.Cells.Range(rango).Font.Size = 12

            xlin = 4
            xcol = 1

            '-- MONTO LOS ENCABEZADOS DE LA TABLA EN LA HOJA DE EXCEL
            For i As Integer = 0 To dt1.Columns.Count - 1
                wSheet.Cells(xlin, xcol + i) = dt1.Columns(i).ColumnName.ToUpper.Trim()
            Next

            xlin += 1
            For i As Integer = 0 To dt1.Rows.Count - 1
                wSheet.Cells(xlin + i, xcol + 0) = dt1.Rows(i).Item("IDDEP").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 1) = dt1.Rows(i).Item("DEPARTAMENTO").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 2) = dt1.Rows(i).Item("IDCEN").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 3) = dt1.Rows(i).Item("CENTRO_COSTO").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 4) = dt1.Rows(i).Item("ANIO").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 5) = dt1.Rows(i).Item("NMES").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 6) = dt1.Rows(i).Item("N1").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 7) = dt1.Rows(i).Item("CANTINI").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 8) = dt1.Rows(i).Item("N2").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 9) = dt1.Rows(i).Item("CANTFIN").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 10) = dt1.Rows(i).Item("ENTRA").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 11) = dt1.Rows(i).Item("SALI").ToString.Trim()
                wSheet.Cells(xlin + i, xcol + 12) = dt1.Rows(i).Item("IRP").ToString.Trim()
            Next

            excel.Visible = True
            Label2.Visible = False

        Catch ex As Exception
            MessageBox.Show("there was an issue Exporting to Excel" & ex.ToString)
            Label2.Visible = False
        End Try

    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        Try

            If fileExist Then
                Dim filesize As Integer = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTROTCONF.XML").Length
                If filesize > 0 Then
                    Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTROTCONF.XML")
                    dts.Tables.Clear()
                    dts.ReadXml(stfile)
                    stfile.Close()
                End If
            End If

            Dim param1 As String, param2 As String, param3 As String
            Dim param4 As String, param5 As String, param6 As String

            param1 = dts.Tables("dtTipoColaborador").Rows(0).Item("tipo").ToString()

            param2 = dts.Tables("dtTipoNomina").Rows(0).Item("nomina").ToString()

            For i As Integer = 0 To dts.Tables("dtTipoAccion").Rows.Count - 1
                If CType(dts.Tables("dtTipoAccion").Rows(i).Item("esIngreso"), Boolean) = True Then
                    param3 = dts.Tables("dtTipoAccion").Rows(i).Item("accion").ToString()
                Else
                    param4 += "'" & dts.Tables("dtTipoAccion").Rows(i).Item("accion").ToString() & "',"
                End If
            Next
            param4 = param4.Substring(0, param4.Length - 1)

            param5 = dts.Tables("dtFechas").Rows(0).Item("Numero_nomina").ToString()

            param6 = dts.Tables("dtFechas").Rows(dts.Tables("dtFechas").Rows.Count - 1).Item("Numero_nomina").ToString()

            Label2.Visible = True
            Me.Refresh()
            Label2.Visible = GeneraQuery(param1, param2, param3, param4, param5, param6)
            DesActiva(False)
            Me.Refresh()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class