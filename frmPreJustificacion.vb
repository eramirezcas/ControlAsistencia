Public Class frmPreJustificacion
    Dim dts As New DataSet

    Private Sub cargaGrid()
        Dim strCondicion As String = ""
        strCondicion = IIf(verTodos, "", " AND (codigo IN (SELECT empID FROM " & vbNewLine & _
        " (	SELECT DISTINCT E.empID, E.middleName + ' ' + E.lastName + ' ' + E.firstName AS nombre" & vbNewLine & _
        "    FROM [GUAYABO\GUAYABO].[CRCC].[DBO].[OHEM] AS E INNER JOIN [RRHH].[DBO].[TBL_JEFE_SECCION] AS S ON S.deptID = E.dept" & vbNewLine & _
        "    WHERE(e.U_ESTADO = 1) AND (S.empID = " & pempID & ")" & vbNewLine & _
        " ) AS A WHERE (empID <> " & pempID & ")))")

        Dim strSQL As String = "" & _
        "BEGIN" & vbNewLine & _
        "	use rrhh" & vbNewLine & _
        "	SET LANGUAGE SPANISH" & vbNewLine & _
        "	" & vbNewLine & _
        "	declare @t as table(id Numeric(8,0), fecha datetime)" & vbNewLine & _
        "	declare @th as table(id Numeric(8,0), lunesin varchar(5), martesin varchar(5), miercolesin varchar(5), juevesin varchar(5), viernesin varchar(5), sabadoin varchar(5), domingoin varchar(5))" & vbNewLine & _
        "	declare @dia as datetime" & vbNewLine & _
        "	declare @inicio as datetime" & vbNewLine & _
        "	declare @fin as datetime" & vbNewLine & _
        "	declare @codigo as Char(7)" & vbNewLine & _
        "	" & vbNewLine & _
        "	set @inicio = convert(datetime,'" & dtpInicial.Value.Date & "',103)" & vbNewLine & _
        "	set @fin = convert(datetime,'" & dtpFinal.Value.Date & "' + ' 23:59:59',103)" & vbNewLine & _
        "	set @dia = @inicio" & vbNewLine & _
        "	set @codigo = ''" & vbNewLine & _
        "	" & vbNewLine & _
        "	while (@dia <= @fin)" & vbNewLine & _
        "	begin" & vbNewLine & _
        "		insert into @t(id, fecha)" & vbNewLine & _
        "		select convert(Numeric(8,0),subString(convert(char,@dia,103),7,4) + " & vbNewLine & _
        "				subString(convert(char,@dia,103),4,2) + " & vbNewLine & _
        "				subString(convert(char,@dia,103),1,2)), @dia" & vbNewLine & _
        "		set @dia = @dia + 1 " & vbNewLine & _
        "	end" & vbNewLine & _
        "	" & vbNewLine & _
        "	insert into @th(id, lunesin, martesin, miercolesin, juevesin, viernesin, sabadoin, domingoin)" & vbNewLine & _
        "	SELECT id_horario," & vbNewLine & _
        "		case when (dia_feriado2 is not null or dia_feriado2 <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado2)))>1) AND (RTRIM(LTRIM(dia_feriado2))='LUNES') AND (RTRIM(LTRIM(lunesin))<>'LIBRE') THEN 'LIBRE' ELSE lunesin end as lunesin," & vbNewLine & _
        "		case when (dia_feriado2 is not null or dia_feriado2 <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado2)))>1) AND (RTRIM(LTRIM(dia_feriado2))='MARTES') AND (RTRIM(LTRIM(martesin))<>'LIBRE') THEN 'LIBRE' ELSE martesin end as martesin," & vbNewLine & _
        "		case when (dia_feriado2 is not null or dia_feriado2 <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado2)))>1) AND (RTRIM(LTRIM(dia_feriado2))='MIERCOLES') AND (RTRIM(LTRIM(miercolesin))<>'LIBRE') THEN 'LIBRE' ELSE miercolesin end as miercolesin," & vbNewLine & _
        "		case when (dia_feriado2 is not null or dia_feriado2 <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado2)))>1) AND (RTRIM(LTRIM(dia_feriado2))='JUEVES') AND (RTRIM(LTRIM(juevesin))<>'LIBRE') THEN 'LIBRE' ELSE juevesin end as juevesin," & vbNewLine & _
        "		case when (dia_feriado2 is not null or dia_feriado2 <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado2)))>1) AND (RTRIM(LTRIM(dia_feriado2))='VIERNES') AND (RTRIM(LTRIM(viernesin))<>'LIBRE') THEN 'LIBRE' ELSE viernesin end as viernesin," & vbNewLine & _
        "		case when (dia_feriado2 is not null or dia_feriado2 <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado2)))>1) AND (RTRIM(LTRIM(dia_feriado2))='SABADO') AND (RTRIM(LTRIM(sabadoin))<>'LIBRE') THEN 'LIBRE' ELSE sabadoin end as sabadoin," & vbNewLine & _
        "		case when (dia_feriado2 is not null or dia_feriado2 <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado2)))>1) AND (RTRIM(LTRIM(dia_feriado2))='DOMINGO') AND (RTRIM(LTRIM(domingoin))<>'LIBRE') THEN 'LIBRE' ELSE domingoin end as domingoin" & vbNewLine & _
        "	FROM" & vbNewLine & _
        "	(SELECT id_horario," & vbNewLine & _
        "		case when (dia_feriado is not null or dia_feriado <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado)))>1) AND (RTRIM(LTRIM(dia_feriado))='LUNES') THEN 'LIBRE' ELSE lunesin end as lunesin," & vbNewLine & _
        "		case when (dia_feriado is not null or dia_feriado <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado)))>1) AND (RTRIM(LTRIM(dia_feriado))='MARTES') THEN 'LIBRE' ELSE martesin end as martesin," & vbNewLine & _
        "		case when (dia_feriado is not null or dia_feriado <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado)))>1) AND (RTRIM(LTRIM(dia_feriado))='MIERCOLES') THEN 'LIBRE' ELSE miercolesin end as miercolesin," & vbNewLine & _
        "		case when (dia_feriado is not null or dia_feriado <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado)))>1) AND (RTRIM(LTRIM(dia_feriado))='JUEVES') THEN 'LIBRE' ELSE juevesin end as juevesin," & vbNewLine & _
        "		case when (dia_feriado is not null or dia_feriado <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado)))>1) AND (RTRIM(LTRIM(dia_feriado))='VIERNES') THEN 'LIBRE' ELSE viernesin end as viernesin," & vbNewLine & _
        "		case when (dia_feriado is not null or dia_feriado <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado)))>1) AND (RTRIM(LTRIM(dia_feriado))='SABADO') THEN 'LIBRE' ELSE sabadoin end as sabadoin," & vbNewLine & _
        "		case when (dia_feriado is not null or dia_feriado <> 'NULO' OR LEN(RTRIM(LTRIM(dia_feriado)))>1) AND (RTRIM(LTRIM(dia_feriado))='DOMINGO') THEN 'LIBRE' ELSE domingoin end as domingoin," & vbNewLine & _
        "		dia_feriado2" & vbNewLine & _
        "	FROM tbl_tipo_horario" & vbNewLine & _
        "	) AS A" & vbNewLine & _
        "	" & vbNewLine & _
        "   --SELECT seccion, codigo, nombre, DiaCal, xFECHA, xENTRA, xMARCA, xSALIDA, tarde, justificacion, id_horario" & vbNewLine & _
        "	SELECT seccion AS [SECCIÓN], codigo AS [CÓDIGO], nombre AS [NOMBRE], DiaCal AS [DÍA], xFECHA AS [FECHA], xENTRA AS [ENTRA], xMARCA AS [MARCA], xSALIDA AS [SALIDA], tarde AS [TARDE], justificacion AS [JUSTIFICACIÓN], id_horario AS [ID_HORARIO]" & vbNewLine & _
        "	FROM" & vbNewLine & _
        "	(	select (select name from [guayabo\guayabo].crcc.dbo.oudp" & vbNewLine & _
        "					where code = (select dept from [guayabo\guayabo].crcc.dbo.ohem where empid = convert(int,codigo))) as seccion," & vbNewLine & _
        "			codigo, nombre, DiaCal, convert(char(10),fecha,103) as xFECHA, convert(char(8),ENTRA,108) as xENTRA," & vbNewLine & _
        "			convert(char(8),ENTRADA,108) as xMARCA, convert(char(8),salida,108) as xSALIDA, horastarde as tarde, justificacion, id_horario" & vbNewLine & _
        "		from" & vbNewLine & _
        "		(	select DiaCal, FECHA, ENTRA, ENTRADA, DETALLE1, case when entrada <= entra then 0 else entrada - entra end as tarde," & vbNewLine & _
        "				codFecha, codigo, nombre, HoraEntra, salida, id_horario, id_interno, id_procesado, justificacion, numpago, horastarde" & vbNewLine & _
        "			from" & vbNewLine & _
        "			(select upper(datename(weekday,tc.FECHA)) + case when A3.Dia = 'LIBRE' then ' LIBRE' else '' end as DiaCal," & vbNewLine & _
        "					A3.DIA, tc.FECHA, convert(datetime,A3.HoraEntraDia,103) AS ENTRA, A3.ENTRADA, A3.detalle1, A3.codFecha, A3.codigo, A3.nombre, A3.HoraEntra, A3.salida, A3.id_horario, A3.id_interno, A3.id_procesado," & vbNewLine & _
        "					A3.justificacion, A3.numpago, A3.horastarde" & vbNewLine & _
        "				from" & vbNewLine & _
        "				@t as tc inner join" & vbNewLine & _
        "				(	Select convert(char,entrada,112) as codFecha, codigo, nombre, HoraEntraDia, entrada, detalle1, salida, id_horario, HoraEntra, Dia, id_interno, id_procesado, justificacion, numpago, horastarde" & vbNewLine & _
        "					from" & vbNewLine & _
        "					(	Select codigo, nombre," & vbNewLine & _
        "							case when id_Horario > 0 then" & vbNewLine & _
        "								convert(char(10),entrada,103) + ' ' + case when HoraEntra = 'LIBRE' or HoraEntra is null or rtrim(ltrim(HoraEntra)) = ':' then null else HoraEntra end" & vbNewLine & _
        "							 else" & vbNewLine & _
        "								convert(char(10),entrada,103)" & vbNewLine & _
        "							end as HoraEntraDia," & vbNewLine & _
        "							entrada, detalle1, salida, id_horario, HoraEntra, id_procesado, justificacion, numpago," & vbNewLine & _
        "							case when HoraEntra <> 'LIBRE' then Dia" & vbNewLine & _
        "								when HoraEntra is null then Dia + ' SIN HORARIO'" & vbNewLine & _
        "								else 'LIBRE'" & vbNewLine & _
        "							end as Dia, id_interno, fechacal, horastarde" & vbNewLine & _
        "						from" & vbNewLine & _
        "						(	select TM.codigo, TM.nombre, TM.entrada, TM.detalle1, TM.salida, (select id_horario from tbl_horarioxEmpleado where convert(int,empid) = convert(int,codigo)) as id_horario," & vbNewLine & _
        "								(select" & vbNewLine & _
        "									case" & vbNewLine & _
        "										when datepart(weekDay,fechacal)=1 then lunesin" & vbNewLine & _
        "										when datepart(weekDay,fechacal)=2 then martesin" & vbNewLine & _
        "										when datepart(weekDay,fechacal)=3 then miercolesin" & vbNewLine & _
        "										when datepart(weekDay,fechacal)=4 then juevesin" & vbNewLine & _
        "										when datepart(weekDay,fechacal)=5 then viernesin" & vbNewLine & _
        "										when datepart(weekDay,fechacal)=6 then sabadoin" & vbNewLine & _
        "										when datepart(weekDay,fechacal)=7 then domingoin" & vbNewLine & _
        "									end as hora" & vbNewLine & _
        "								 from @th where convert(int,id) = (select id_horario from tbl_horarioxEmpleado where convert(int,empid) = convert(int,codigo))" & vbNewLine & _
        "								) as HoraEntra, TM.horastarde," & vbNewLine & _
        "								upper(datename(weekDay,fechacal)) as Dia, TM.id_interno, TM.id_procesado, TM.Justificacion, TM.numpago, TM.fechacal as fechacal" & vbNewLine & _
        "							from tbl_marcas_PROCESADAS as TM" & vbNewLine & _
        "							--where (rtrim(ltrim(codigo)) = @Codigo)" & vbNewLine & _
        "						) as A1" & vbNewLine & _
        "					) as A2" & vbNewLine & _
        "				) as A3 on A3.codFecha = tc.id" & vbNewLine & _
        "			) as A4" & vbNewLine & _
        "		) as A5" & vbNewLine & _
        "		union" & vbNewLine & _
        "		select (select name from [guayabo\guayabo].crcc.dbo.oudp" & vbNewLine & _
        "					where code = (select dept from [guayabo\guayabo].crcc.dbo.ohem where empid = convert(int,codigo))) as seccion, codigo as codigo, nombre, DiaCal, convert(char(10),fecha,103) as xFECHA, convert(char(8),ENTRA,108) as xENTRA, convert(char(8),ENTRADA,108) as xMARCA, convert(char(8),salida,108) as xSALIDA," & vbNewLine & _
        "			round(convert(float,subString(convert(char,TARDE,108),1,2)) + convert(float,subString(convert(char,TARDE,108),4,2))/60 + (Convert(float,subString(convert(char,TARDE,108),7,2))/60)/100,2) as Tarde," & vbNewLine & _
        "			justificacion, id_horario" & vbNewLine & _
        "		from" & vbNewLine & _
        "		(	select DiaCal, FECHA, ENTRA, ENTRADA, DETALLE1, case when entrada <= entra then 0 else entrada - entra end as tarde," & vbNewLine & _
        "				codFecha, codigo, nombre, HoraEntra, salida, id_horario, id_interno, id_procesado, justificacion, numpago" & vbNewLine & _
        "			from" & vbNewLine & _
        "			(select upper(datename(weekday,tc.FECHA)) + case when A3.Dia = 'LIBRE' then ' LIBRE' else '' end as DiaCal," & vbNewLine & _
        "					A3.DIA, tc.FECHA, convert(datetime,A3.HoraEntraDia,103) AS ENTRA, A3.ENTRADA, A3.detalle1, A3.codFecha, A3.codigo, A3.nombre, A3.HoraEntra, A3.salida, A3.id_horario, A3.id_interno, A3.id_procesado, A3.justificacion, A3.numpago" & vbNewLine & _
        "				from" & vbNewLine & _
        "				@t as tc left outer join" & vbNewLine & _
        "				(	Select convert(char,entrada,112) as codFecha, codigo, nombre, HoraEntraDia, entrada, detalle1, salida, id_horario, HoraEntra, Dia, id_interno, id_procesado, justificacion, numpago" & vbNewLine & _
        "					from" & vbNewLine & _
        "					(	Select codigo, nombre," & vbNewLine & _
        "							case when id_Horario > 0 then" & vbNewLine & _
        "								convert(char(10),entrada,103) + ' ' + case when HoraEntra = 'LIBRE' or HoraEntra is null or rtrim(ltrim(HoraEntra)) = ':' then null else HoraEntra end" & vbNewLine & _
        "							 else" & vbNewLine & _
        "								convert(char(10),entrada,103)" & vbNewLine & _
        "							end as HoraEntraDia," & vbNewLine & _
        "							entrada, detalle1, salida, id_horario, HoraEntra, id_procesado, justificacion, numpago," & vbNewLine & _
        "							case when HoraEntra <> 'LIBRE' then Dia" & vbNewLine & _
        "								when HoraEntra is null then Dia + ' SIN HORARIO'" & vbNewLine & _
        "								else 'LIBRE'" & vbNewLine & _
        "							end as Dia, id_interno, fechacal" & vbNewLine & _
        "						from" & vbNewLine & _
        "						(	select TM.codigo, TM.nombre, TM.entrada, TM.detalle1, TM.salida, TM.id_horario," & vbNewLine & _
        "								(select" & vbNewLine & _
        "									case" & vbNewLine & _
        "										when datepart(weekDay,timestamp)=1 then lunesin" & vbNewLine & _
        "										when datepart(weekDay,timestamp)=2 then martesin" & vbNewLine & _
        "										when datepart(weekDay,timestamp)=3 then miercolesin" & vbNewLine & _
        "										when datepart(weekDay,timestamp)=4 then juevesin" & vbNewLine & _
        "										when datepart(weekDay,timestamp)=5 then viernesin" & vbNewLine & _
        "										when datepart(weekDay,timestamp)=6 then sabadoin" & vbNewLine & _
        "										when datepart(weekDay,timestamp)=7 then domingoin" & vbNewLine & _
        "									end as hora" & vbNewLine & _
        "								 from @th where id = TM.id_horario" & vbNewLine & _
        "								) as HoraEntra," & vbNewLine & _
        "								upper(datename(weekDay,timestamp)) as Dia, TM.id_interno, TM.id_procesado, TM.Justificacion, TM.numpago, TM.timestamp as fechacal" & vbNewLine & _
        "							from tbl_marcas as TM" & vbNewLine & _
        "							where (TM.timestamp between @inicio and @fin) --and (rtrim(ltrim(codigo)) = @Codigo)" & vbNewLine & _
        "						) as A1" & vbNewLine & _
        "					) as A2" & vbNewLine & _
        "				) as A3 on A3.codFecha = tc.id" & vbNewLine & _
        "			) as A4" & vbNewLine & _
        "		) as A5" & vbNewLine & _
        "		WHERE (convert(numeric(14,0),rtrim(ltrim(@codigo)) + '00' + convert(char(10),fecha,112)) not in (SELECT DISTINCT convert(numeric(14,0),rtrim(ltrim(codigo)) + '00' + convert(char(10),fechacal,112)) FROM tbl_marcas_procesadas WHERE (rtrim(ltrim(codigo))=@codigo) and (fechacal between @inicio and @fin)))" & vbNewLine & _
        "	) as Afinal" & vbNewLine & _
        "   where len(rtrim(ltrim(justificacion)))=0 and tarde > 0" & vbNewLine & strCondicion & vbNewLine & _
        "	order by seccion, convert(datetime, xfecha, 103)" & vbNewLine & _
        "END"

        cnx.consulta(dts, strSQL, "tblResult")

        DataGridView1.DataSource = dts
        DataGridView1.DataMember = "tblResult"
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToOrderColumns = False
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True

    End Sub

    Private Sub desActiva(ByVal plActiva As Boolean)
        btnExcel.Enabled = plActiva
        btnImprimir.Enabled = plActiva
        dtpInicial.Enabled = Not plActiva
        dtpFinal.Enabled = Not plActiva
    End Sub

    Private Sub limpiar()
        dtpInicial.Value = Now
        dtpFinal.Value = Now
        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing
        dts.Tables.Clear()
        desActiva(False)
    End Sub

    Private Sub btnConsultar_Click(sender As System.Object, e As System.EventArgs) Handles btnConsultar.Click
        Dim obj As Button = CType(sender, Button)

        If obj.Text = "&Generar" Then

            If dtpInicial.Value > dtpFinal.Value Then
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            obj.Text = "&Limpiar"
            obj.Image = Global.WindowsApplication1.My.Resources.Deshacer
            desActiva(True)
            cargaGrid()
        Else
            obj.Text = "&Generar"
            obj.Image = Global.WindowsApplication1.My.Resources.refresh
            limpiar()
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub frmPreJustificacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        limpiar()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tblResult"
        pntexcel.titulo = "CONSULTA JUSTIFICACIONES"
        pntexcel.filtro = "MARCAS SIN JUSTIFICAR DEL " & dtpInicial.Value.Date & " AL " & dtpFinal.Value.Date
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub
End Class