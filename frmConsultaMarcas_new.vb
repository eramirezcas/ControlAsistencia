Imports CrystalDecisions.Shared

'** REGLAS DE NEGOCIO **
'- si no hay marca de salida rebaja 8 horas
'- si no hay marca de entrada rebaja 8 horas
'- no se pude justificar el dia actual
'- si el empleado repite entradas o salidas para la misma fecha el sistema rebaja

Public Class frmConsultaMarcas_new
    Dim dts As New DataSet()
    Dim datosCargados As Boolean = False

    ' Esta funcion me retorna true si la persona seleccionada tiene horario asignado
    Private Function chequeHorarios(ByRef pCodigo As Integer) As Boolean
        Try
            Dim obj As Object = cnx.SQLEXECESCALAR("select count(*) as existe from tbl_horarioxempleado where empid = " & pCodigo)
            Dim cant As Integer = CType(obj, Integer)
            Dim result As Boolean = IIf(cant = 0, False, True)
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Function

    ' Esta funcion consulta y retorna una datatable con la info de marcas ya procesadas para un colaborador en una fecha especificos
    Private Function cargaMarcasProcesadas(ByVal fecha As Date, ByVal codigo As Integer) As DataTable
        Try
            Dim dt As New DataTable()
            Dim strSQL As String = _
                "SELECT TIPO, DIA, FECHA, HORARIO, MARCA, DIFERENCIA, CIRCUNSTANCIA, JUSTIFICACION, ID_HORARIO, ID_INTERNO, CAST(1 AS BIT) AS PROCESADO, UBICACION FROM tbl_marcas_justificadas_pend" & vbNewLine & _
                "WHERE fecha = CONVERT(DATETIME,'" & fecha & "',103) AND codigo = " & codigo
            Dim result As New DataTable
            cnx.SQLEXEC(result, strSQL)
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Function

    ' Esta funcion consulta y retorna true / false si la fecha es el dia libre de la persona
    Private Function esLibre(ByVal codigo As Integer, ByVal dia As String) As Boolean
        Try
            Dim dt As New DataTable()

            cnx.SQLEXEC(dt, "SELECT subString(tbl_tipo_horario.dia_feriado,1,3) as Feriado, subString(tbl_tipo_horario.dia_feriado2,1,3) as Feriado2" & vbNewLine & _
                                                "FROM tbl_horarioxEmpleado INNER JOIN tbl_tipo_horario ON tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine & _
                                                "WHERE (tbl_horarioxEmpleado.empID = " & codigo & ")")

            If dt.Rows.Count = 0 Then
                Return False
            End If

            If dt.Rows(0).Item("Feriado") = dia Then
                Return True
            ElseIf dt.Rows(0).Item("Feriado2") = dia Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    ' Esta funcion consulta y retorna true / false si la persona tienen asignado un horario fijo
    Private Function esHoraFijo(ByVal codigo As Integer) As Boolean
        Try
            Dim dt As New DataTable

            cnx.SQLEXEC(dt, "SELECT CAST(tbl_horarioxEmpleado.horarioFijo as bit) as HorarioFijo" & vbNewLine & _
                             "FROM tbl_horarioxEmpleado INNER JOIN tbl_tipo_horario ON" & vbNewLine & _
                             "	tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine & _
                             "WHERE (tbl_horarioxEmpleado.empID = " & codigo & ")")

            If dt.Rows.Count = 0 Then
                Return False
            End If

            If dt.Rows(0).Item("HorarioFijo") Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Function

    ' Esta funcion consulta y retorna 1/0 si la marca ya fue procesada
    Private Function marcaProcesada(ByVal fecha As Date, ByVal codigo As Integer) As Boolean
        Try
            Dim strSQL As String = "SELECT " & vbNewLine & _
                                    "(SELECT COUNT(*) AS Esta FROM tbl_marcas_justificadas_hist" & vbNewLine & _
                                     "WHERE fecha = CONVERT(DATETIME,'" & fecha & "',103) AND codigo = " & codigo & ") + " & vbNewLine & _
                                    "(SELECT COUNT(*) AS Esta FROM tbl_marcas_justificadas_act" & vbNewLine & _
                                     "WHERE fecha = CONVERT(DATETIME,'" & fecha & "',103) AND codigo = " & codigo & ") + " & vbNewLine & _
                                    "(SELECT COUNT(*) AS Esta FROM tbl_marcas_justificadas_pend" & vbNewLine & _
                                     "WHERE fecha = CONVERT(DATETIME,'" & fecha & "',103) AND codigo = " & codigo & ") AS Esta"
            Dim dt As New DataTable
            cnx.SQLEXEC(dt, strSQL)

            If dt.Rows(0).Item("Esta") = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    ' activa/desactiva controles
    Private Sub desActiva(ByVal plActiva As Boolean)
        btnCargar.Enabled = Not plActiva
        btnNombre.Enabled = Not plActiva
        btnExcel.Enabled = plActiva
        btnImprimir.Enabled = plActiva
        btnGuardar.Enabled = plActiva
        dtpFinal.Enabled = Not plActiva
        dtpInicio.Enabled = Not plActiva
    End Sub

    ' inicializa los controles dependiendo de la accion sin datos cargados con datos cargados(comportamiento)
    Private Sub limpiar()
        dtpInicio.Value = Now
        dtpFinal.Value = Now
        txtNombre.Text = Nothing
        txtNombre.Tag = Nothing
        DataGridView1.DataMember = Nothing
        DataGridView1.DataSource = Nothing
        DataGridView1.Columns.Clear()
        Try
            dts.Tables.Remove("tblDatosMarcas")
        Catch ex As Exception
            ex.Data.Clear()
        End Try
    End Sub

    ' consulta la ultima justificacion para un empleado especifico
    Private Function consultaUltimaJustif() As Date
        Try
            Dim strSQL As String = "SELECT max(fecha) as Fecha from(" & vbNewLine & _
                                    "SELECT fecha FROM tbl_marcas_justificadas_pend WHERE (codigo = " & txtNombre.Tag & ") UNION" & vbNewLine & _
                                    "SELECT fecha FROM tbl_marcas_justificadas_act WHERE (codigo = " & txtNombre.Tag & ") UNION" & vbNewLine & _
                                    "SELECT fecha FROM tbl_marcas_justificadas_hist WHERE (codigo = " & txtNombre.Tag & ")) as a"
            Dim dt As New DataTable
            cnx.SQLEXEC(dt, strSQL)
            Dim result As Date

            If IsDBNull(dt.Rows(0).Item("Fecha")) Then
                result = CType(dtpInicio.Value, Date)
            Else
                result = CType(dt.Rows(0).Item("Fecha"), Date)
            End If

            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    ' carga datos en la forma para editarlos
    Private Sub consultaMarca(ByVal nlinea As Integer)
        Dim pnt As New frmEditarMarca()

        pnt.dts = dts
        pnt.tabla = "tblDatosMarcas"
        pnt.pos = BindingContext(dts, "tblDatosMarcas").Position
        pnt.MdiParent = Me.MdiParent
        pnt.pnt = Me
        pnt.StartPosition = FormStartPosition.CenterScreen
        pnt.Show()
    End Sub

    ' carga los datos del horario (solo lectura)
    Private Sub consultaHorario(ByVal idHorario As Integer)
        Try
            Dim pnt As New frmConsultaHorario()
            Dim strSQL As String = _
                "SELECT id_horario, CASE WHEN detalle IS NULL THEN '' ELSE detalle END AS detalle," & vbNewLine & _
                "	CASE WHEN lunesin IS NULL THEN '' ELSE lunesin END AS lunesin, CASE WHEN lunesout IS NULL THEN '' ELSE lunesout END AS lunesout," & vbNewLine & _
                "	CASE WHEN martesin IS NULL THEN '' ELSE martesin END AS martesin, CASE WHEN martesout IS NULL THEN '' ELSE martesout END AS martesout," & vbNewLine & _
                "	CASE WHEN miercolesin IS NULL THEN '' ELSE miercolesin END AS miercolesin, CASE WHEN miercolesout IS NULL THEN '' ELSE miercolesout END AS miercolesout," & vbNewLine & _
                "	CASE WHEN juevesin IS NULL THEN '' ELSE juevesin END AS juevesin, CASE WHEN juevesout IS NULL THEN '' ELSE juevesout END AS juevesout," & vbNewLine & _
                "	CASE WHEN viernesin IS NULL THEN '' ELSE viernesin END AS viernesin, CASE WHEN viernesout IS NULL THEN '' ELSE viernesout END AS viernesout," & vbNewLine & _
                "	CASE WHEN sabadoin IS NULL THEN '' ELSE sabadoin END AS sabadoin, CASE WHEN sabadoout IS NULL THEN '' ELSE sabadoout END AS sabadoout," & vbNewLine & _
                "	CASE WHEN domingoin IS NULL THEN '' ELSE domingoin END AS domingoin, CASE WHEN domingoout IS NULL THEN '' ELSE domingoout END AS domingoout," & vbNewLine & _
                "	CASE WHEN dia_feriado IS NULL THEN '' ELSE dia_feriado END AS dia_feriado, CASE WHEN dia_feriado2 IS NULL THEN '' ELSE dia_feriado2 END AS dia_feriado2" & vbNewLine & _
                "FROM tbl_tipo_horario WHERE (id_horario = " & idHorario & ")"

            Dim dt As New DataTable
            cnx.SQLEXEC(dt, strSQL)

            If dt.Rows.Count <= 0 Then
                MessageBox.Show("No se ha definido un horario", "CONSULTANDO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            pnt.StartPosition = FormStartPosition.CenterScreen
            pnt.MdiParent = Me.MdiParent
            pnt.pnt = Me

            pnt.GroupBox1.Text = IIf(dt.Rows(0).Item("id_horario").ToString.Length < 2, "0", "") & dt.Rows(0).Item("id_horario").ToString.Trim & " - " & dt.Rows(0).Item("detalle")
            pnt.TextBox1.Text = dt.Rows(0).Item("lunesIn")
            pnt.TextBox9.Text = dt.Rows(0).Item("lunesOut")
            pnt.TextBox2.Text = dt.Rows(0).Item("martesIn")
            pnt.TextBox10.Text = dt.Rows(0).Item("martesOut")
            pnt.TextBox3.Text = dt.Rows(0).Item("miercolesIn")
            pnt.TextBox11.Text = dt.Rows(0).Item("miercolesOut")
            pnt.TextBox4.Text = dt.Rows(0).Item("juevesIn")
            pnt.TextBox12.Text = dt.Rows(0).Item("juevesOut")
            pnt.TextBox5.Text = dt.Rows(0).Item("viernesIn")
            pnt.TextBox13.Text = dt.Rows(0).Item("viernesOut")
            pnt.TextBox6.Text = dt.Rows(0).Item("sabadoIn")
            pnt.TextBox14.Text = dt.Rows(0).Item("sabadoOut")
            pnt.TextBox7.Text = dt.Rows(0).Item("domingoIn")
            pnt.TextBox15.Text = dt.Rows(0).Item("domingoOut")
            pnt.TextBox8.Text = dt.Rows(0).Item("dia_Feriado")
            pnt.TextBox16.Text = dt.Rows(0).Item("dia_Feriado2")

            pnt.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    ' carga una circunstancia dependiendo de la diferencia para una tardia o una salida anticipada
    Private Function cargaCircunstacia(ByVal diferencia As Decimal, ByVal tipo As String) As String
        If diferencia = 0 Then
            Return ""
        End If
        Return IIf(tipo = "ENTRADA", "LLEGA " & diferencia & " HORAS TARDE", "SALE " & diferencia & " HORAS ANTES")
    End Function

    Private Function cargaMarcas(ByVal pCodigo As Integer, ByVal pFecha As Date) As DataTable
        Try
            Dim result As New DataTable
            Dim strSQL As String = _
                "SELECT codigo, timeStamp, entrada, salida, id_horario, id_horario_sale, id_interno, id_procesado, ubicacion_entra, ubicacion_salida FROM tbl_marcas" & vbNewLine & _
                "WHERE (RTRIM(LTRIM(codigo)) = '" & pCodigo & "') AND" & vbNewLine & _
                "   (timeStamp BETWEEN CONVERT(DATETIME,'" & pFecha & "',103) AND CONVERT(DATETIME,'" & pFecha & " 23:59:59.999',103))" & vbNewLine & _
                "ORDER BY timeStamp DESC"
            cnx.SQLEXEC(result, strSQL)
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    Private Function calculaHoras(ByVal pFechaI As DateTime, pFechaII As DateTime) As Decimal
        Dim datetimeNull As DateTime = CType("00:00", DateTime)
        If pFechaI = datetimeNull Or pFechaII = datetimeNull Then
            Return 8
        End If

        Dim result As Decimal
        Dim minutos As Integer
        minutos = DateDiff(DateInterval.Minute, pFechaI, pFechaII)
        If minutos < 0 Then
            Return 0
        End If
        result = Math.Round(minutos / 60, 2)
        Return result
    End Function

    Private Function cargaHorarios(ByVal pIdHorario As Integer, ByVal pIdHorarioSale As Integer, ByVal pFecha As Date, ByVal entrada As Boolean) As DateTime
        Try
            Dim IdHorario As Integer

            If pIdHorario = 0 And pIdHorarioSale = 0 Then
                Return Nothing
            Else
                If entrada Then
                    IdHorario = IIf(pIdHorario = 0, pIdHorarioSale, pIdHorario)
                Else
                    IdHorario = IIf(pIdHorarioSale = 0, pIdHorario, pIdHorarioSale)
                End If
            End If

            Dim result As DateTime
            Dim strSQL As String = _
                "SET LANGUAGE spanish" & vbNewLine & _
                "" & vbNewLine & _
                "DECLARE @pDia AS CHAR(3)" & vbNewLine & _
                "SET @pDia = substring(upper(datename(weekday,convert(datetime,'" & pFecha & "',103))),1,3)" & vbNewLine & _
                "" & vbNewLine & _
                "SELECT id_horario," & vbNewLine & _
                "	CASE WHEN @pDia='LUN' THEN lunesin" & vbNewLine & _
                "		WHEN @pDia='MAR' THEN martesin" & vbNewLine & _
                "		WHEN @pDia='MIÉ' THEN miercolesin" & vbNewLine & _
                "		WHEN @pDia='JUE' THEN juevesin" & vbNewLine & _
                "		WHEN @pDia='VIE' THEN viernesin" & vbNewLine & _
                "		WHEN @pDia='SÁB' THEN sabadoin" & vbNewLine & _
                "		WHEN @pDia='DOM' THEN domingoin" & vbNewLine & _
                "	END AS ENTRA," & vbNewLine & _
                "	CASE WHEN @pDia='LUN' THEN lunesout" & vbNewLine & _
                "		WHEN @pDia='MAR' THEN martesout" & vbNewLine & _
                "		WHEN @pDia='MIÉ' THEN miercolesout" & vbNewLine & _
                "		WHEN @pDia='JUE' THEN juevesout" & vbNewLine & _
                "		WHEN @pDia='VIE' THEN viernesout" & vbNewLine & _
                "		WHEN @pDia='SÁB' THEN sabadoout" & vbNewLine & _
                "		WHEN @pDia='DOM' THEN domingoout" & vbNewLine & _
                "	END AS SALE" & vbNewLine & _
                "FROM tbl_tipo_horario where id_horario = " & IdHorario

            Dim dt As New DataTable
            cnx.SQLEXEC(dt, strSQL)

            If dt.Rows.Count <= 0 Then
                result = Nothing
            Else
                Dim strResult As String = pFecha
                If entrada Then
                    If IsDBNull(dt.Rows(0).Item("ENTRA")) Then
                        strResult += " " + "00:00:01"
                    ElseIf dt.Rows(0).Item("ENTRA") = "" Then
                        strResult += " " + "00:00:01"
                    ElseIf dt.Rows(0).Item("ENTRA").ToString.Trim = ":" Then
                        strResult += " " + "00:00:01"
                    Else
                        strResult += " " + dt.Rows(0).Item("ENTRA")
                    End If
                Else
                    If IsDBNull(dt.Rows(0).Item("SALE")) Then
                        strResult += " " + "00:00:01"
                    ElseIf dt.Rows(0).Item("SALE") = "" Then
                        strResult += " " + "00:00:01"
                    ElseIf dt.Rows(0).Item("SALE").ToString.Trim = ":" Then
                        strResult += " " + "00:00:01"
                    Else
                        strResult += " " + dt.Rows(0).Item("SALE")
                    End If
                End If
                result = CType(strResult, DateTime)
            End If
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    Private Sub cargaDatos()
        Dim dt As New DataTable("tblDatosMarcas")

        dt.Columns.Add("TIPO", GetType(String))
        dt.Columns.Add("DIA", GetType(String))
        dt.Columns.Add("FECHA", GetType(Date))
        dt.Columns.Add("HORARIO", GetType(DateTime))
        dt.Columns.Add("MARCA", GetType(DateTime))
        dt.Columns.Add("DIFERENCIA", GetType(Decimal))
        dt.Columns.Add("CIRCUNSTANCIA", GetType(String))
        dt.Columns.Add("JUSTIFICACION", GetType(String))
        dt.Columns.Add("ID_HORARIO", GetType(Integer))
        dt.Columns.Add("ID_INTERNO", GetType(Integer))
        dt.Columns.Add("PROCESADO", GetType(Boolean))
        dt.Columns.Add("UBICACION", GetType(String))

        dts.Tables.Add(dt)

        DataGridView1.DataSource = dts
        DataGridView1.DataMember = "tblDatosMarcas"
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToOrderColumns = False

        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        For i = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 70
        DataGridView1.Columns(2).Width = 70
        DataGridView1.Columns(3).Width = 115
        DataGridView1.Columns(4).Width = 115
        DataGridView1.Columns(5).Width = 48
        DataGridView1.Columns(6).Width = 160
        DataGridView1.Columns(7).Width = 180
        DataGridView1.Columns(8).Width = 60
        DataGridView1.Columns(9).Width = 60
        DataGridView1.Columns(10).Width = 60

        DataGridView1.Columns(0).HeaderText = "TIPO"
        DataGridView1.Columns(1).HeaderText = "DIA"
        DataGridView1.Columns(2).HeaderText = "FECHA"
        DataGridView1.Columns(3).HeaderText = "HORARIO"
        DataGridView1.Columns(4).HeaderText = "MARCA"
        DataGridView1.Columns(5).HeaderText = "HORAS REBAJO"
        DataGridView1.Columns(6).HeaderText = "CIRCUNSTANCIA"
        DataGridView1.Columns(7).HeaderText = "JUSTIFICACION"
        DataGridView1.Columns(8).HeaderText = "ID_HORARIO"
        DataGridView1.Columns(9).HeaderText = "ID_INTERNO"
        DataGridView1.Columns(10).HeaderText = "PROCESADO"
        DataGridView1.Columns(11).HeaderText = "UBICACION"

        DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(8).Visible = False
        DataGridView1.Columns(9).Visible = False
        DataGridView1.Columns(10).Visible = False

        Dim lineColor As Color
        ''Dim finicio As DateTime = CType(IIf(consultaUltimaJustif() >= CType(dtpInicio.Value, Date), consultaUltimaJustif(), dtpInicio.Value), DateTime)
        Dim finicio As DateTime = dtpInicio.Value.Date
        Dim dif As Integer = DateDiff(DateInterval.Day, finicio, dtpFinal.Value)

        If dif < 0 Then
            MessageBox.Show("No hay marcas para procesar !!!", "JUSTIFICAR MARCAS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            desActiva(False)
            Exit Sub
        End If

        Progress.Minimum = 0
        Progress.Maximum = dif + 1
        lblProgress.Text = "CARGANDO RESULTADOS...."
        For i = 0 To dif
            lineColor = IIf((i Mod 2) = 0, Color.White, Color.PeachPuff)
            dt = cargaMarcas(txtNombre.Tag, DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)

            If dt.Rows.Count <= 0 Then
                If Not marcaProcesada(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, txtNombre.Tag) Then
                    If esHoraFijo(txtNombre.Tag) Then
                        If esLibre(txtNombre.Tag, WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper.Substring(0, 3)) Then
                            dts.Tables("tblDatosMarcas").Rows.Add("ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                      DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 0, "DIA LIBRE", "", 0, 0, False, "")
                            dts.Tables("tblDatosMarcas").Rows.Add("SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                                                  DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 0, "DIA LIBRE", "", 0, 0, False, "")
                        Else
                            dts.Tables("tblDatosMarcas").Rows.Add("ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                      DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, False, "")
                            dts.Tables("tblDatosMarcas").Rows.Add("SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                                                  DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, False, "")
                        End If
                    Else
                        dts.Tables("tblDatosMarcas").Rows.Add("ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                                              DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, False, "")
                        dts.Tables("tblDatosMarcas").Rows.Add("SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                                              DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, False, "")
                    End If
                Else
                    Dim dtTMP As DataTable = cargaMarcasProcesadas(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, txtNombre.Tag)
                    For ix = 0 To dtTMP.Rows.Count - 1
                        dts.Tables("tblDatosMarcas").Rows.Add(dtTMP.Rows(ix).Item("TIPO"), _
                                                              dtTMP.Rows(ix).Item("DIA"), _
                                                              dtTMP.Rows(ix).Item("FECHA"), _
                                                              dtTMP.Rows(ix).Item("HORARIO"), _
                                                              dtTMP.Rows(ix).Item("MARCA"), _
                                                              dtTMP.Rows(ix).Item("DIFERENCIA"), _
                                                              dtTMP.Rows(ix).Item("CIRCUNSTANCIA"), _
                                                              dtTMP.Rows(ix).Item("JUSTIFICACION"), _
                                                              dtTMP.Rows(ix).Item("ID_HORARIO"), _
                                                              dtTMP.Rows(ix).Item("ID_INTERNO"), _
                                                              dtTMP.Rows(ix).Item("PROCESADO"), _
                                                              dtTMP.Rows(ix).Item("UBICACION"))
                    Next
                End If
            Else
                For j = 0 To dt.Rows.Count - 1

                    Dim marcaEntra As DateTime = IIf(IsDBNull(dt.Rows(j).Item("Entrada")), Nothing, dt.Rows(j).Item("Entrada"))
                    Dim marcaSale As DateTime = IIf(IsDBNull(dt.Rows(j).Item("Salida")), Nothing, dt.Rows(j).Item("Salida"))
                    Dim pidHorario As Integer = IIf(IsDBNull(dt.Rows(j).Item("id_horario")), 0, dt.Rows(j).Item("id_horario"))
                    Dim pidHorariosale As Integer = IIf(IsDBNull(dt.Rows(j).Item("id_horario_sale")), 0, dt.Rows(j).Item("id_horario_sale"))
                    Dim horarioEntra As DateTime = cargaHorarios(pidHorario, pidHorariosale, DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, True)
                    Dim horarioSale As DateTime = cargaHorarios(pidHorario, pidHorariosale, DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, False)
                    Dim difEntrada As Decimal = calculaHoras(horarioEntra, marcaEntra)
                    Dim difSalida As Decimal = calculaHoras(marcaSale, horarioSale)
                    Dim pidInterno As Integer = IIf(IsDBNull(dt.Rows(j).Item("id_interno")), Nothing, dt.Rows(j).Item("id_interno"))
                    Dim ubicEntra As String = IIf(IsDBNull(dt.Rows(j).Item("ubicacion_entra")), Nothing, dt.Rows(j).Item("ubicacion_entra"))
                    Dim ubicSale As String = IIf(IsDBNull(dt.Rows(j).Item("ubicacion_salida")), Nothing, dt.Rows(j).Item("ubicacion_salida"))

                    If dt.Rows(j).Item("id_procesado") = 0 Then
                        dts.Tables("tblDatosMarcas").Rows.Add("ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                                        DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, horarioEntra, dt.Rows(j).Item("Entrada"), _
                                                        difEntrada, cargaCircunstacia(difEntrada, "ENTRADA"), "", pidHorario, pidInterno, False, ubicEntra)

                        dts.Tables("tblDatosMarcas").Rows.Add("SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                                        DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, horarioSale, dt.Rows(j).Item("Salida"), _
                                                        difSalida, cargaCircunstacia(difSalida, "SALIDA"), "", pidHorariosale, pidInterno, False, ubicSale)
                    Else
                        Dim dtTMP As DataTable = cargaMarcasProcesadas(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, txtNombre.Tag)

                        For ix = 0 To dtTMP.Rows.Count - 1
                            dts.Tables("tblDatosMarcas").Rows.Add(dtTMP.Rows(ix).Item("TIPO"), _
                                                                  dtTMP.Rows(ix).Item("DIA"), _
                                                                  dtTMP.Rows(ix).Item("FECHA"), _
                                                                  dtTMP.Rows(ix).Item("HORARIO"), _
                                                                  dtTMP.Rows(ix).Item("MARCA"), _
                                                                  dtTMP.Rows(ix).Item("DIFERENCIA"), _
                                                                  dtTMP.Rows(ix).Item("CIRCUNSTANCIA"), _
                                                                  dtTMP.Rows(ix).Item("JUSTIFICACION"), _
                                                                  dtTMP.Rows(ix).Item("ID_HORARIO"), _
                                                                  dtTMP.Rows(ix).Item("ID_INTERNO"), _
                                                                  dtTMP.Rows(ix).Item("PROCESADO"), _
                                                                  dtTMP.Rows(ix).Item("UBICACION"))

                        Next
                        Exit For
                    End If
                Next
            End If
            If DataGridView1.RowCount > 0 Then
                For l = 0 To DataGridView1.ColumnCount - 1
                    If DataGridView1.ColumnCount < 2 Then
                        DataGridView1.Item(l, DataGridView1.RowCount - 2).Style.BackColor = lineColor
                    End If
                    DataGridView1.Item(l, DataGridView1.RowCount - 1).Style.BackColor = lineColor
                Next
            End If
                Progress.Value += 1
        Next

        For fil As Integer = 0 To DataGridView1.Rows.Count - 1
            For col As Integer = 0 To DataGridView1.ColumnCount - 1
                If DataGridView1.Item(10, fil).Value Then
                    DataGridView1.Item(col, fil).Style.BackColor = Color.DarkGray
                End If
            Next
        Next
        Dim dc As New DataGridViewButtonColumn
        dc.Name = "cbtVerHora"
        dc.Text = "Horario"
        dc.UseColumnTextForButtonValue = True
        dc.HeaderText = ""
        dc.DisplayIndex = 0
        dc.DefaultCellStyle.BackColor = Color.Gray
        dc.Frozen = True
        dc.Width = 50
        DataGridView1.Columns.AddRange(dc)

        Dim dc1 As New DataGridViewButtonColumn
        dc1.Name = "cbtJustificar"
        dc1.Text = "Editar"
        dc1.UseColumnTextForButtonValue = True
        dc1.HeaderText = ""
        dc1.DisplayIndex = 8
        dc1.DefaultCellStyle.BackColor = Color.Gray
        dc1.Width = 50
        DataGridView1.Columns.AddRange(dc1)

        DataGridView1.Columns(12).DisplayIndex = 0
        DataGridView1.Columns(0).DisplayIndex = 1
        DataGridView1.Columns(1).DisplayIndex = 2
        DataGridView1.Columns(11).DisplayIndex = 3
        DataGridView1.Columns(2).DisplayIndex = 4
        DataGridView1.Columns(3).DisplayIndex = 5
        DataGridView1.Columns(4).DisplayIndex = 6
        DataGridView1.Columns(5).DisplayIndex = 7
        DataGridView1.Columns(6).DisplayIndex = 8
        DataGridView1.Columns(13).DisplayIndex = 9
        DataGridView1.Columns(7).DisplayIndex = 10

        Dim xfont As New Font(DataGridView1.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
        DataGridView1.RowHeadersDefaultCellStyle.Font = New Font(DataGridView1.RowHeadersDefaultCellStyle.Font.FontFamily, 7, FontStyle.Regular)
        For iv = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(iv).DefaultCellStyle.Font = xfont
        Next

        Progress.Value = 0
        lblProgress.Text = ""

    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs)
        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing
        dts.Tables.Remove("tblDatosMarcas")
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs)
        Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        If CType(dtpInicio.Value.ToShortDateString, Date) > CType(dtpFinal.Value.ToShortDateString, Date) Then
            MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", "CARGAR MARCAS !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If CType(dtpInicio.Value.ToShortDateString, Date) >= CType(Now.ToShortDateString, Date) Or CType(dtpFinal.Value.ToShortDateString, Date) >= CType(Now.ToShortDateString, Date) Then
            MessageBox.Show("El rango de fechas seleccionado no puede ser evaluado !!!", "CARGAR MARCAS !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtNombre.Text.Trim = "" Then
            MessageBox.Show("Debe de seleccionar un nombre para realizar el procceso.", "CARGAR MARCAS !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        cargaDatos()
        desActiva(True)
        If dts.Tables("tblDatosMarcas").Rows.Count > 0 Then
            datosCargados = True
        End If
    End Sub

    Private Sub lblNombre_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim obj As Label = CType(sender, Label)
        obj.BackColor = Color.Black
        obj.ForeColor = Color.White
    End Sub

    Private Sub lblNombre_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        Dim obj As Label = CType(sender, Label)
        obj.BackColor = Color.Transparent
        obj.ForeColor = Color.Blue
    End Sub

    Private Sub btnNombre_Click(sender As System.Object, e As System.EventArgs) Handles btnNombre.Click
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
            Exit Sub
        End If

        If Not chequeHorarios(result.Item("empid")) Then
            MessageBox.Show("El empleado: " & result.Item("nombre") & " no tiene horario asignado." & vbNewLine & _
                            "Verifique e intente de nuevo.", "JUSTIFICACIÓN DE MARCAS !!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        txtNombre.Tag = result.Item("empid")
        txtNombre.Text = result.Item("nombre")

        Dim ulFecha As DateTime = consultaUltimaJustif()

        lblUltimaJustificacion.Text = IIf(ulFecha = dtpInicio.Value, ">>> Última Justificación DESCONOCIDA <<<", ">>> Última Justificación: " & Format(ulFecha, "dddd, MMM d yyyy").ToUpper.Trim & " <<<")
        lblUltimaJustificacion.Visible = True

    End Sub

    Private Sub btnSalir_Click_1(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Select Case e.ColumnIndex
            Case 12
                Dim idhorario As Integer = dts.Tables("tblDatosMarcas").Rows(BindingContext(dts, "tblDatosMarcas").Position).Item("id_horario")
                consultaHorario(idhorario)

            Case 13
                If CType(dts.Tables("tblDatosMarcas").Rows(BindingContext(dts, "tblDatosMarcas").Position).Item("FECHA"), Date) >= Now.Date Then
                    lblProgress.Text = "ERROR: La marcas del día actual no pueden ser justificadas."
                    lblProgress.TextAlign = ContentAlignment.MiddleCenter
                    lblProgress.BackColor = Color.Red
                    lblProgress.ForeColor = Color.White
                    Exit Sub
                End If


                If dts.Tables("tblDatosMarcas").Rows(BindingContext(dts, "tblDatosMarcas").Position).Item("PROCESADO") = False Then
                    consultaMarca(BindingContext(dts, "tblDatosMarcas").Position)
                Else
                    lblProgress.Text = "ERROR: La marca que seleccionó o intenta editar ya fue procesada."
                    lblProgress.TextAlign = ContentAlignment.MiddleCenter
                    lblProgress.BackColor = Color.Red
                    lblProgress.ForeColor = Color.White
                    Exit Sub
                End If
        End Select
    End Sub

    Private Sub frmConsultaMarcas_new_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If datosCargados Then
            If MessageBox.Show("Cargó datos que no ha guardado." & vbNewLine & "Se dispone a salir. ¿Seguro de proceder?", "SALIR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmConsultaMarcas_new_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblUltimaJustificacion.Visible = False
        desActiva(False)
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tblDatosMarcas"
        pntexcel.titulo = "CONSULTA DE MARCAS / " & StrDup(5 - txtNombre.Tag.ToString.Length, "0") & txtNombre.Tag.ToString.Trim & " - " & txtNombre.Text
        pntexcel.filtro = ""
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Dim shwrpt As New frmReport()
        'Dim rpt As New rptConsultaMarcas_new()
        'Dim par As New ParameterValues
        'par.AddValue(StrDup(5 - txtNombre.Tag.ToString.Length, "0") & txtNombre.Tag.ToString.Trim & " - " & txtNombre.Text)
        'rpt.SetDataSource(dts)
        'rpt.ParameterFields("pNombre").CurrentValues = par
        'shwrpt.CrystalReportViewer1.ReportSource = rpt
        'shwrpt.MdiParent = Me.MdiParent
        'shwrpt.Show()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            Dim cantJust As Integer = 0

            For i = 0 To dts.Tables("tblDatosMarcas").Rows.Count - 1
                cantJust = cantJust + IIf(dts.Tables("tblDatosMarcas").Rows(i).Item("JUSTIFICACION").ToString.Trim = "", 0, 1)
            Next

            If cantJust = 0 Then
                If MessageBox.Show("Recuerde que despues de guardar no podrá editar la información" & vbNewLine & _
                           "Se dispone a guardar marcas sin justificar." & vbNewLine & "¿Seguro de prodecer?", "GUARDAR DATOS", _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            ElseIf MessageBox.Show("Recuerde que despues de guardar no podrá editar la información" & vbNewLine & _
                           "Se dispone a guardar." & vbNewLine & "¿Seguro de prodecer?", "GUARDAR DATOS", _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Progress.Maximum = dts.Tables("tblDatosMarcas").Rows.Count + 1
            For i = 0 To dts.Tables("tblDatosMarcas").Rows.Count - 1

                Dim pHorario As String
                Dim pMarca As String

                If dts.Tables("tblDatosMarcas").Rows(i).Item("HORARIO").ToString = "" Then
                    pHorario = ", NULL"
                ElseIf IsDBNull(dts.Tables("tblDatosMarcas").Rows(i).Item("HORARIO")) Then
                    pHorario = ", NULL"
                ElseIf Format(dts.Tables("tblDatosMarcas").Rows(i).Item("HORARIO"), "dd/MM/yyyy") = "01/01/0001" Then
                    pHorario = ", NULL"
                Else
                    Dim pHorario1 As String = Format(dts.Tables("tblDatosMarcas").Rows(i).Item("HORARIO"), "dd/MM/yyyy HH:mm:ss")
                    pHorario = ", CONVERT(DATETIME,'" & pHorario1 & "',103)"
                End If

                If dts.Tables("tblDatosMarcas").Rows(i).Item("MARCA").ToString = "" Then
                    pMarca = ", NULL"
                ElseIf IsDBNull(dts.Tables("tblDatosMarcas").Rows(i).Item("MARCA")) Then
                    pMarca = ", NULL"
                ElseIf Format(dts.Tables("tblDatosMarcas").Rows(i).Item("MARCA"), "dd/MM/yyyy") = "01/01/0001" Then
                    pHorario = ", NULL"
                Else
                    Dim pMarca1 As String = Format(dts.Tables("tblDatosMarcas").Rows(i).Item("MARCA"), "dd/MM/yyyy HH:mm:ss")
                    pMarca = ", CONVERT(DATETIME,'" & pMarca1 & "',103)"
                End If

                Dim strUPS As String = "UPDATE Tbl_marcas SET id_procesado = 1 WHERE ID_INTERNO = " & dts.Tables("tblDatosMarcas").Rows(i).Item("ID_INTERNO")
                Dim strSQL As String = _
                    "BEGIN TRY" & vbNewLine & _
                    "	BEGIN transaction" & vbNewLine & _
                    "	SET NOCOUNT ON;" & vbNewLine & _
                    "	" & vbNewLine & _
                    "	DECLARE @SECCION AS VARCHAR(50)" & vbNewLine & _
                    "	DECLARE @DEPARTAMENTO AS VARCHAR(50)" & vbNewLine & _
                    "	" & vbNewLine & _
                    "	SET @DEPARTAMENTO = (SELECT Departamento FROM view_sl_empleados WHERE empid = '" & txtNombre.Tag & "')" & vbNewLine & _
                    "	SET @SECCION = (SELECT Seccion FROM view_sl_empleados WHERE empid = '" & txtNombre.Tag & "')" & vbNewLine & _
                    "	" & vbNewLine & _
                    "	INSERT INTO tbl_marcas_justificadas_pend(codigo, nombre, tipo, dia, fecha, horario," & vbNewLine & _
                    "		     marca, diferencia, circunstancia, justificacion, id_horario, id_interno," & vbNewLine & _
                    "			 departamento, seccion, ubicacion)" & vbNewLine & _
                    "	VALUES(" & vbNewLine & _
                    "			" & txtNombre.Tag & "" & vbNewLine & _
                    "		 , '" & txtNombre.Text & "'" & vbNewLine & _
                    "		 , '" & dts.Tables("tblDatosMarcas").Rows(i).Item("TIPO") & "'" & vbNewLine & _
                    "		 , '" & dts.Tables("tblDatosMarcas").Rows(i).Item("DIA") & "'" & vbNewLine & _
                    "		 , CONVERT(DATETIME,'" & CType(dts.Tables("tblDatosMarcas").Rows(i).Item("FECHA"), String) & "',103)" & vbNewLine & _
                    "		" & pHorario & vbNewLine & _
                    "		" & pMarca & vbNewLine & _
                    "		 , " & dts.Tables("tblDatosMarcas").Rows(i).Item("DIFERENCIA") & vbNewLine & _
                    "		 , '" & dts.Tables("tblDatosMarcas").Rows(i).Item("CIRCUNSTANCIA") & "'" & vbNewLine & _
                    "		 , '" & dts.Tables("tblDatosMarcas").Rows(i).Item("JUSTIFICACION") & "'" & vbNewLine & _
                    "		 , " & dts.Tables("tblDatosMarcas").Rows(i).Item("ID_HORARIO") & vbNewLine & _
                    "		 , " & dts.Tables("tblDatosMarcas").Rows(i).Item("ID_INTERNO") & vbNewLine & _
                    "		 , @DEPARTAMENTO" & vbNewLine & _
                    "		 , @SECCION" & vbNewLine & _
                    "		 , '" & dts.Tables("tblDatosMarcas").Rows(i).Item("UBICACION") & "'" & vbNewLine & _
                    "		)" & vbNewLine & vbNewLine & _
                    "		" & IIf(IsDBNull(dts.Tables("tblDatosMarcas").Rows(i).Item("ID_INTERNO")) Or dts.Tables("tblDatosMarcas").Rows(i).Item("ID_INTERNO") = 0, "", strUPS) & vbNewLine & _
                    "		" & vbNewLine & _
                    "END TRY" & vbNewLine & _
                    "BEGIN CATCH" & vbNewLine & _
                    "	IF @@TRANCOUNT > 0" & vbNewLine & _
                    "		ROLLBACK TRANSACTION;" & vbNewLine & _
                    "		DECLARE @ErrorMessage NVARCHAR(4000);" & vbNewLine & _
                    "		DECLARE @ErrorSeverity INT;" & vbNewLine & _
                    "		DECLARE @ErrorState INT;" & vbNewLine & _
                    "		" & vbNewLine & _
                    "		SET @ErrorMessage = ERROR_MESSAGE()" & vbNewLine & _
                    "		SET @ErrorSeverity = ERROR_SEVERITY()" & vbNewLine & _
                    "		SET @ErrorState = ERROR_STATE();" & vbNewLine & _
                    "		" & vbNewLine & _
                    "	    RAISERROR (@ErrorMessage,@ErrorSeverity,@ErrorState);" & vbNewLine & _
                    "END CATCH;" & vbNewLine & _
                    "IF @@TRANCOUNT > 0" & vbNewLine & _
                    "	COMMIT TRANSACTION;"

                If Not dts.Tables("tblDatosMarcas").Rows(i).Item("PROCESADO") Then
                    If CType(dts.Tables("tblDatosMarcas").Rows(i).Item("FECHA"), Date) <> Now.Date Then
                        cnx.SQLEXEC(strSQL)
                    End If
                End If
                Progress.Value = i
            Next
            Progress.Value = 0

            MessageBox.Show("Datos guardados con éxito.", "GUARDAR DATOS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            datosCargados = False
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        lblProgress.Text = ""
        lblProgress.TextAlign = ContentAlignment.MiddleCenter
        lblProgress.BackColor = Color.White
        lblProgress.ForeColor = Color.Black
    End Sub

End Class