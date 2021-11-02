Public Class FrmConsultaMarcas

    Public dtsForm As New DataSet
    Public codigo As String
    Public nombre As String
    Dim Tabla As String = "tbl_marcas_tmp"
    Dim encontrado As Boolean = False
    Dim valor = 2
    Dim prueba As String

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
        Dim strSQL As String = _
        "BEGIN" & vbNewLine & _
        "	use rrhh" & vbNewLine & _
        "	SET LANGUAGE SPANISH" & vbNewLine & _
        "   " & vbNewLine & _
        "	declare @t as table(id Numeric(8,0), fecha datetime)" & vbNewLine & _
        "	declare @th as table(id Numeric(8,0), lunesin varchar(5), martesin varchar(5), miercolesin varchar(5), juevesin varchar(5), viernesin varchar(5), sabadoin varchar(5), domingoin varchar(5))" & vbNewLine & _
        "	declare @dia as datetime" & vbNewLine & _
        "	declare @inicio as datetime" & vbNewLine & _
        "	declare @fin as datetime" & vbNewLine & _
        "	declare @codigo as Char(7)" & vbNewLine & _
        "   " & vbNewLine & _
        "	set @codigo = '" & codigo & "'" & vbNewLine & _
        "	set @inicio = convert(datetime,'" & dtpInicio.Value.Date & "',103)" & vbNewLine & _
        "	set @fin = convert(datetime,'" & dtpFinal.Value.Date & "' + ' 23:59:59',103)" & vbNewLine & _
        "	set @dia = @inicio" & vbNewLine & _
        "   " & vbNewLine & _
        "	while (@dia <= @fin)" & vbNewLine & _
        "	begin" & vbNewLine & _
        "		insert into @t(id, fecha)" & vbNewLine & _
        "		select convert(Numeric(8,0),subString(convert(char,@dia,103),7,4) + " & vbNewLine & _
        "				subString(convert(char,@dia,103),4,2) + " & vbNewLine & _
        "				subString(convert(char,@dia,103),1,2)), @dia" & vbNewLine & _
        "		set @dia = @dia + 1" & vbNewLine & _
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
        "	) AS A " & vbNewLine & _
        "	" & vbNewLine & _
        "	select DiaCal, convert(char(10),fecha,103) as xFECHA, convert(char(8),ENTRA,108) as xENTRA, convert(char(8),ENTRADA,108) as xENTRADA, DETALLE1 as DETALLE_ENTRADA," & vbNewLine & _
        "		convert(char(8),salida,108) as xSALIDA, round(convert(float,subString(convert(char,TARDE,108),1,2)) +" & vbNewLine & _
        "			convert(float,subString(convert(char,TARDE,108),4,2))/60 + (Convert(float,subString(convert(char,TARDE,108),7,2))/60)/100,2) as Tarde," & vbNewLine & _
        "		justificacion, id_interno, FECHA, ENTRA, ENTRADA as MARCA_ENTRADA, salida as MARCA_SALIDA, id_procesado, codigo, id_horario--, numpago, codFecha, nombre, HoraEntra" & vbNewLine & _
        "	from" & vbNewLine & _
        "	(	select DiaCal, FECHA, ENTRA, ENTRADA, DETALLE1, case when entrada <= entra then 0 else entrada - entra end as tarde, " & vbNewLine & _
        "			codFecha, codigo, nombre, HoraEntra, salida, id_horario, id_interno, id_procesado, justificacion, numpago" & vbNewLine & _
        "		from" & vbNewLine & _
        "		(	select upper(datename(weekday,tc.FECHA)) + case when A3.Dia = 'LIBRE' then ' LIBRE' else '' end as DiaCal, " & vbNewLine & _
        "				A3.DIA, tc.FECHA, convert(datetime,A3.HoraEntraDia,103) AS ENTRA, A3.ENTRADA, A3.detalle1, A3.codFecha, A3.codigo, A3.nombre, A3.HoraEntra, A3.salida, A3.id_horario, A3.id_interno, A3.id_procesado, A3.justificacion, A3.numpago" & vbNewLine & _
        "			from" & vbNewLine & _
        "			@t as tc left outer join" & vbNewLine & _
        "			(	Select convert(char,entrada,112) as codFecha, codigo, nombre, HoraEntraDia, entrada, detalle1, salida, id_horario, HoraEntra, Dia, id_interno, id_procesado, justificacion, numpago" & vbNewLine & _
        "				from" & vbNewLine & _
        "				(	Select codigo, nombre, " & vbNewLine & _
        "						case when id_Horario > 0 then" & vbNewLine & _
        "							convert(char(10),entrada,103) + ' ' + case when HoraEntra = 'LIBRE' or HoraEntra is null or rtrim(ltrim(HoraEntra)) = ':' then null else HoraEntra end " & vbNewLine & _
        "						 else" & vbNewLine & _
        "							convert(char(10),entrada,103)" & vbNewLine & _
        "						end as HoraEntraDia, " & vbNewLine & _
        "						entrada, detalle1, salida, id_horario, HoraEntra, id_procesado, justificacion, numpago," & vbNewLine & _
        "						case when HoraEntra <> 'LIBRE' then Dia " & vbNewLine & _
        "							when HoraEntra is null then Dia + ' SIN HORARIO'" & vbNewLine & _
        "							else 'LIBRE' " & vbNewLine & _
        "						end as Dia, id_interno, fechacal" & vbNewLine & _
        "					from" & vbNewLine & _
        "					(	select TM.codigo, TM.nombre, TM.entrada, TM.detalle1, TM.salida, TM.id_horario," & vbNewLine & _
        "							(select" & vbNewLine & _
        "								case" & vbNewLine & _
        "									when datepart(weekDay,entrada)=1 then lunesin" & vbNewLine & _
        "									when datepart(weekDay,entrada)=2 then martesin" & vbNewLine & _
        "									when datepart(weekDay,entrada)=3 then miercolesin" & vbNewLine & _
        "									when datepart(weekDay,entrada)=4 then juevesin" & vbNewLine & _
        "									when datepart(weekDay,entrada)=5 then viernesin" & vbNewLine & _
        "									when datepart(weekDay,entrada)=6 then sabadoin" & vbNewLine & _
        "									when datepart(weekDay,entrada)=7 then domingoin" & vbNewLine & _
        "								end as hora" & vbNewLine & _
        "							 from @th where id = TM.id_horario" & vbNewLine & _
        "							) as HoraEntra, " & vbNewLine & _
        "							upper(datename(weekDay,entrada)) as Dia, TM.id_interno, TM.id_procesado, TM.Justificacion, TM.numpago, TM.timestamp as fechacal" & vbNewLine & _
        "						from tbl_marcas as TM" & vbNewLine & _
        "						where (TM.entrada between @inicio and @fin) and (TM.codigo = @codigo) and" & vbNewLine & _
        "							--(id_interno not in (SELECT DISTINCT Id_Interno FROM tbl_marcas_procesadas WHERE (Id_Interno > 0)))" & vbNewLine & _
        "							((rtrim(ltrim(codigo)) + ' ' + convert(char(10),timestamp,103)) not in (SELECT DISTINCT rtrim(ltrim(codigo)) + ' ' + convert(char(10),fechacal,103) FROM tbl_marcas_procesadas WHERE (Id_Interno > 0)))" & vbNewLine & _
        "					) as A1" & vbNewLine & _
        "				) as A2" & vbNewLine & _
        "			) as A3 on A3.codFecha = tc.id" & vbNewLine & _
        "		) as A4" & vbNewLine & _
        "	) as A5" & vbNewLine & _
        "	WHERE (numpago IS NULL) AND (FECHA NOT IN (select fechacal from tbl_marcas_procesadas where (rtrim(ltrim(codigo))=@codigo) and (fechacal between @inicio and @fin) UNION" & vbNewLine & _
        "                                               select fechacal from tbl_marcas_procesadas_act where (rtrim(ltrim(codigo))=@codigo) and (fechacal between @inicio and @fin) UNION" & vbNewLine & _
        "                                               select fechacal from tbl_marcas_procesadas_hist where (rtrim(ltrim(codigo))=@codigo) and (fechacal between @inicio and @fin)" & vbNewLine & _
        "                                           )" & vbNewLine & _
        "                                 )" & vbNewLine & _
        "END"

        cnx.consulta(dtsForm, strSQL, "tbl_marcas_tmp")

        dgvHorarios.DataSource = dtsForm
        dgvHorarios.DataMember = "tbl_marcas_tmp"

        dgvHorarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvHorarios.AllowUserToOrderColumns = False
        dgvHorarios.AllowUserToAddRows = False
        dgvHorarios.AllowUserToResizeColumns = False
        dgvHorarios.AllowUserToDeleteRows = False
        dgvHorarios.AllowUserToResizeRows = False
        dgvHorarios.MultiSelect = False
        dgvHorarios.ReadOnly = True

        For i = 0 To dgvHorarios.Columns.Count - 1
            dgvHorarios.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        dgvHorarios.Columns(0).HeaderText = "DÍA"
        dgvHorarios.Columns(1).HeaderText = "FECHA"
        dgvHorarios.Columns(2).HeaderText = "ENTRA"
        dgvHorarios.Columns(3).HeaderText = "MARCA ENTRADA"
        dgvHorarios.Columns(4).HeaderText = "DETALLE ENTRADA"
        dgvHorarios.Columns(5).HeaderText = "MARCA SALIDA"
        dgvHorarios.Columns(6).HeaderText = "HORAS TARDE"
        dgvHorarios.Columns(7).HeaderText = "JUSTIFICACIÓN"
        dgvHorarios.Columns(8).HeaderText = "ID"

        dgvHorarios.Columns(9).Visible = False
        dgvHorarios.Columns(10).Visible = False
        dgvHorarios.Columns(11).Visible = False
        dgvHorarios.Columns(12).Visible = False
        dgvHorarios.Columns(13).Visible = False
        dgvHorarios.Columns(14).Visible = False
        dgvHorarios.Columns(15).Visible = False

        dgvHorarios.Columns(0).Width = 130
        dgvHorarios.Columns(1).Width = 70
        dgvHorarios.Columns(2).Width = 60
        dgvHorarios.Columns(3).Width = 66
        dgvHorarios.Columns(4).Width = 160
        dgvHorarios.Columns(5).Width = 65
        dgvHorarios.Columns(6).Width = 50
        dgvHorarios.Columns(7).Width = 170
        dgvHorarios.Columns(8).Width = 50


    End Sub

    Private Sub RegActual()
        lblRecActual.Text = "Registro #" & BindingContext(dtsForm, Tabla).Position + 1 & "/" & BindingContext(dtsForm, Tabla).Count
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub bloquear(ByVal opbloqueo As Boolean)
        btnImprimir.Enabled = opbloqueo
        btnExcel.Enabled = opbloqueo
        BtnFiltar.Enabled = opbloqueo
        btnAplicar.Enabled = opbloqueo
        btnJustificar.Enabled = opbloqueo
        btnLimpiar.Enabled = opbloqueo
        GroupBox1.Enabled = opbloqueo
        btnConsultar.Enabled = Not opbloqueo
        lblNombre.Enabled = Not opbloqueo
    End Sub

    Private Sub fechas(ByVal opfecha As Boolean)
        dtpInicio.Enabled = opfecha
        dtpFinal.Enabled = opfecha
    End Sub

    Public Sub cargaforma(ByRef pantallas As Object)
        Dim obj As Object = CType(pantallas, Form)
        obj.MdiParent = Me.MdiParent
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub txtLocalizar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtLocalizar.BackColor = IIf(txtLocalizar.TextLength = 0, Color.White, Color.LightBlue)
            If txtLocalizar.Text.Length = 0 Then
                mensajes("Debe de ingresar un dato para realizar la acción !!!")
                Exit Sub
            End If
            If encontrado Then
                Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dtsForm, Tabla).Position + 1)
                BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
            Else
                Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
                BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
                encontrado = IIf(localizado = -1, False, True)
                If Not encontrado Then
                    mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
                End If
            End If
            RegActual()
        End If
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dtsForm, Tabla).Position + 1)
            BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dtsForm, Tabla).Position = IIf(localizado = -1, BindingContext(dtsForm, Tabla).Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub pctLocalizar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctLocalizar.MouseDown
        pctLocalizar.BorderStyle = BorderStyle.Fixed3D
    End Sub

    Private Sub pctLocalizar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pctLocalizar.MouseUp
        pctLocalizar.BorderStyle = BorderStyle.None
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub tsbPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbUltimo.Click, tsbSiguiente.Click, tsbPrimero.Click, tsbAnterior.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dtsForm, Tabla).Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dtsForm, Tabla).Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dtsForm, Tabla).Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dtsForm, Tabla).Position = dtsForm.Tables(Tabla).Rows.Count - 1
        End Select
    End Sub

    Private Sub dgvHorarios_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellClick
        RegActual()
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Faltan Datos en la Forma", "Datos en la Forma", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If dtpInicio.Value > dtpFinal.Value Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la fecha Final", "CONSULTANDO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        nombre = txtNombre.Text
        codigo = txtEpmID.Text
        CargaGrid()
        bloquear(True)
        fechas(False)
    End Sub

    Private Sub lblNombre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNombre.Click
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        pnt.Text = "BUSQUEDA DE COLABORADOR"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = _
            "DECLARE @userid AS INT" & vbNewLine & _
            "SET @userid = " & pempID.ToString.Trim & vbNewLine & _
            "" & vbNewLine & _
            "SELECT E.empID, E.middleName + ' ' + E.lastName + ' ' + E.firstName AS nombre" & vbNewLine & _
            "FROM [GUAYABO\GUAYABO].[CRCC].[DBO].[OHEM] AS E" & vbNewLine & _
            "WHERE(e.U_ESTADO = 1)" & vbNewLine & _
            IIf(verTodos, "", "And (E.dept IN (SELECT S.deptid FROM [RRHH].[DBO].[TBL_JEFE_SECCION] AS S WHERE S.empid = @userid)) AND (E.empid <> @userid)")


        '"SELECT DISTINCT E.empID, E.middleName + ' ' + E.lastName + ' ' + E.firstName AS nombre " & vbNewLine & _
        '"FROM [GUAYABO\GUAYABO].[CRCC].[DBO].[OHEM] AS E " & IIf(verTodos, "", "INNER JOIN [RRHH].[DBO].[TBL_JEFE_SECCION] AS S ON S.deptID = E.dept ") & vbNewLine & _
        '"WHERE(e.U_ESTADO = 1) " & IIf(verTodos, "", "And (S.empID = " & pempID & ")")

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        txtEpmID.Text = result.Item("empid")
        txtNombre.Text = result.Item("nombre")
        fechas(True)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        txtNombre.Text = ""
        txtEpmID.Text = ""
        dtsForm.Clear()
        bloquear(False)
        fechas(False)
        txtNombre.Text = ""
        dtpInicio.Value = Now()
        dtpFinal.Value = Now()
        dtsForm.Clear()
        lblRecActual.Text = "Registro #0/0"
    End Sub

    Private Sub FrmConsultaMarcas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strSQL As String = "" & _
            "SELECT top(1) convert(char,timestamp, 106) as ULTIMA, timestamp FROM tbl_marcas" & vbNewLine & _
            "WHERE RTRIM(LTRIM(codigo)) in (SELECT DISTINCT convert(char(4),E.empID) FROM [GUAYABO\GUAYABO].[CRCC].[DBO].[OHEM] AS E INNER JOIN [RRHH].[DBO].[TBL_JEFE_SECCION] AS S ON S.deptID = E.dept" & vbNewLine & _
            "														WHERE(e.U_ESTADO = 1) AND (S.empID = " & pempID & ")) AND" & vbNewLine & _
            "	(id_procesado = 1)" & vbNewLine & _
            "order by timestamp desc"

        cnx.consulta(dtsForm, strSQL, "tbl_TMP")
        If dtsForm.Tables("tbl_TMP").Rows.Count = 0 Then
            lblUltimaJustificacion.Text = "NO HA REGISTRADO JUSTIFICACIONES"
            lblUltimaJustificacion.Tag = Nothing
        Else
            lblUltimaJustificacion.Text = dtsForm.Tables("tbl_TMP").Rows(0).Item("ULTIMA")
            lblUltimaJustificacion.Tag = dtsForm.Tables("tbl_TMP").Rows(0).Item("timestamp")
        End If
        btnLimpiar.PerformClick()
        bloquear(False)
        fechas(False)
    End Sub

    Private Sub btnJustificar_Click(sender As System.Object, e As System.EventArgs) Handles btnJustificar.Click
        If IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("id_procesado")), 0, _
                                            dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("id_procesado")) = 0 Then
            Dim pnt As New frmJustificacionMarcas()
            pnt.dts = dtsForm
            pnt.formaAnterior = Me
            pnt.nombre = txtNombre.Text
            pnt.codigo = codigo
            pnt.txtMarca.Text = IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("MARCA_ENTRADA")), "", dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("MARCA_ENTRADA"))
            pnt.txtEntra.Text = IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("ENTRA")), "", dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("ENTRA"))
            pnt.txtTarde.Text = IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("TARDE")), "", dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("TARDE"))
            pnt.txtJustificacion.Text = IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("JUSTIFICACION")), "", dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("JUSTIFICACION"))
            pnt.id_linea = IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("ID_INTERNO")), 0, dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("ID_INTERNO"))
            cargaforma(pnt)
        End If
    End Sub

    Private Sub dgvHorarios_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellEnter
        btnJustificar.Enabled = IIf( _
                                    IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("id_procesado")), 0, _
                                            dtsForm.Tables(Tabla).Rows(BindingContext(dtsForm, Tabla).Position).Item("id_procesado")) = 1, False, True)
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dtsForm
        pntexcel.tabla = Tabla
        pntexcel.titulo = "CONSULTA DE MARCAS"
        pntexcel.filtro = "MARCAS DEL COLABORADOR: " & txtNombre.Text
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim obj As CheckBox = CType(sender, CheckBox)
        lblNombre.Enabled = IIf(obj.Checked, False, True)
        fechas(IIf(obj.Checked, True, False))
        txtNombre.Text = ""
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        txtNombre.Text = ""
    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles btnAplicar.Click
        If MessageBox.Show("Se dispone a aplicar todas las marcas de la consulta." & vbNewLine & _
                           "Este es un proceso irreversible." & vbNewLine & _
                           "¿Seguro de proceder?", _
                           "APLICAR JUSTIFICACIÓN", _
                           MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        For i = 0 To dtsForm.Tables(Tabla).Rows.Count - 1
            Dim strSQL As String = ""

            If IsDBNull(dtsForm.Tables(Tabla).Rows(i).Item("id_interno")) Then
                strSQL = "INSERT INTO TBL_MARCAS_PROCESADAS(codigo, nombre, justificacion, Id_Interno, id_procesado, fechacal) " & _
                         "VALUES('" & codigo.Trim & "', '" & nombre & "', '" & dtsForm.Tables(Tabla).Rows(i).Item("justificacion") & "', 0, 1, " & _
                                "CONVERT(DATETIME,'" & dtsForm.Tables(Tabla).Rows(i).Item("fecha") & "',103))"

            Else

                strSQL = "UPDATE Tbl_marcas SET " & _
                            "id_procesado = 1, " & _
                            "justificacion = '" & dtsForm.Tables(Tabla).Rows(i).Item("justificacion") & "' " & _
                         "WHERE id_interno  = " & dtsForm.Tables(Tabla).Rows(i).Item("id_interno") & vbNewLine & _
                         vbNewLine & _
                         "INSERT INTO TBL_MARCAS_PROCESADAS(codigo, nombre, entrada, salida, detalle1, detalle2, Id_Interno, id_procesado, justificacion, horastarde, fechacal, id_horario, id_horario_sale) " & _
                         "SELECT rtrim(ltrim(codigo)) as codigo, nombre, entrada, salida, detalle1, detalle2, Id_Interno, id_procesado, justificacion, " & _
                            IIf(IsDBNull(dtsForm.Tables(Tabla).Rows(i).Item("tarde")), 0, dtsForm.Tables(Tabla).Rows(i).Item("tarde")) & " as horastarde, convert(datetime,'" & dtsForm.Tables(Tabla).Rows(i).Item("fecha") & "',103) AS fechacal, " & _
                         "id_horario, id_horario_sale" & _
                         "FROM TBL_MARCAS WHERE id_interno  = " & dtsForm.Tables(Tabla).Rows(i).Item("id_interno")
            End If

            cnx.consulta(dtsForm, strSQL, "tbl_marcas")
            dtsForm.Tables(Tabla).Rows(i).Item("id_procesado") = 1

        Next
        BindingContext(dtsForm, Tabla).Position = 0
        MessageBox.Show("Actualizacion realizada con exito", "APLICAR JUSTIFICACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information)
        btnLimpiar.PerformClick()
    End Sub

    Private Sub dgvHorarios_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHorarios.CellDoubleClick
        btnJustificar.PerformClick()
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub

    Private Sub lblUltimaJustificacion_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lblUltimaJustificacion.MouseMove
        lblUltimaJustificacion.Cursor = IIf(lblUltimaJustificacion.Text = "NO HA REGISTRADO JUSTIFICACIONES", Cursors.AppStarting, Cursors.Hand)
    End Sub

    Private Sub lblUltimaJustificacion_Click(sender As System.Object, e As System.EventArgs) Handles lblUltimaJustificacion.Click
        Dim pnt As New frmJustificacionesAnte()
        Dim fecha As Date = CType(lblUltimaJustificacion.Tag, Date)
        pnt.MdiParent = Me.MdiParent
        pnt.dtpFInicial.Value = "01/" & fecha.Month & "/" & fecha.Year
        pnt.dtpFFinal.Value = DateAdd(DateInterval.Day, 1, fecha)
        pnt.VienCargada = True
        pnt.Show()
    End Sub

End Class