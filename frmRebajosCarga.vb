Imports CrystalDecisions.Shared

Public Class frmRebajosCarga
    Dim dts As New DataSet()
    Dim numpago As String
    Dim datosCargados As Boolean = False

    Private Function chequeEmpleadosSinHorario() As Boolean
        Try
            Dim dt As New DataTable
            Dim strSQL As String = _
                "SELECT A.* FROM" & vbNewLine & _
                "(" & vbNewLine & _
                "	SELECT E.empid, E.Nombre, case when A.empid is null then 0 else 1 end as existe" & vbNewLine & _
                "	FROM view_sl_empleados AS E LEFT OUTER JOIN tbl_horarioxEmpleado AS A ON A.empid = CONVERT(INT,E.empID)" & vbNewLine & _
                "	WHERE (E.estado_empleado = 'ACT') AND (E.marca_reloj = 1)" & vbNewLine & _
                ") AS A" & vbNewLine & _
                "WHERE EXISTE = 0"

            cnx.SQLEXEC(dt, strSQL)

            If dt.Rows.Count = 0 Then
                Return True
            Else
                Dim txt As String = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    txt += dt.Rows(i).Item("empid") & vbTab & dt.Rows(i).Item("nombre") & vbTab & dt.Rows(i).Item("existe") & vbNewLine
                Next

                Dim objWriter As New System.IO.StreamWriter("C:\APROGRAMAS\cargaMarcasLog.txt")
                objWriter.Write(txt)
                objWriter.Close()

                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [chequeEmpleadosSinHorario]", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    Private Function cargaMarcasProcesadas(ByVal fecha As Date, ByVal codigo As Integer) As DataTable
        Try
            Dim result As New DataTable
            Dim strSQL As String = _
                "SELECT TIPO, DIA, FECHA, HORARIO, MARCA, DIFERENCIA, CIRCUNSTANCIA, JUSTIFICACION, ID_HORARIO, ID_INTERNO, CAST(1 AS BIT) AS PROCESADO, UBICACION FROM tbl_marcas_justificadas_pend" & vbNewLine & _
                "WHERE fecha = CONVERT(DATETIME,'" & fecha & "',103) AND codigo = " & codigo
            cnx.SQLEXEC(result, strSQL)
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [cargaMarcasProcesadas]", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    Private Function esLibre(ByVal codigo As Integer, ByVal dia As String) As Boolean
        Try
            Dim dt As New DataTable

            cnx.SQLEXEC(dt, "SELECT subString(tbl_tipo_horario.dia_feriado,1,3) as Feriado, subString(tbl_tipo_horario.dia_feriado2,1,3) as Feriado2" & vbNewLine & _
                            "FROM tbl_horarioxEmpleado INNER JOIN tbl_tipo_horario ON tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine & _
                            "WHERE (tbl_horarioxEmpleado.activo = 1) AND (tbl_horarioxEmpleado.empID = " & codigo & ")")

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
            MessageBox.Show(ex.Message & vbNewLine & "Method: [esLibre]", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Function

    Private Function esHoraFijo(ByVal codigo As Integer) As Boolean
        Try
            Dim obj As Object = cnx.SQLEXECESCALAR("SELECT CAST(tbl_horarioxEmpleado.horarioFijo as bit) as HorarioFijo" & vbNewLine & _
                                                   "FROM tbl_horarioxEmpleado INNER JOIN tbl_tipo_horario ON" & vbNewLine & _
                                                   "	tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine & _
                                                   "WHERE (tbl_horarioxEmpleado.activo = 1) AND (tbl_horarioxEmpleado.empID = " & codigo & ")")

            If IsNothing(obj) Then
                Return False
            End If

            Dim esfijo As Boolean = CType(obj, Boolean)
            Return esfijo
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [esHoraFijo]", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    '// esta funcion se encarga de guardar los datos en la db 
    Private Sub insertaMarca(ByVal codigo As Integer, ByVal nombre As String, ByVal tipo As String, ByVal dia As String, ByVal fecha As DateTime, _
                             ByVal horario As DateTime, ByVal marca As DateTime, ByVal diferencia As Double, ByVal circunstancia As String, _
                             ByVal justificacion As String, ByVal id_horario As Integer, ByVal id_interno As Long, ByVal departamento As String, _
                             ByVal seccion As String, ByVal ubicacion As String)
        Try
            Dim pmarca As String = IIf(marca = CDate("12:00 AM"), ", NULL", ", CONVERT(DATETIME,'" & Format(marca, "dd/MM/yyyy HH:mm:ss") & "',103)")
            Dim phorario As String = IIf(horario = CDate("12:00 AM"), ", NULL", ", CONVERT(DATETIME,'" & Format(horario, "dd/MM/yyyy HH:mm:ss") & "',103)")
            Dim strSQL As String = _
                "INSERT INTO tbl_marcas_justificadas_act" & vbNewLine & _
                "	(codigo, nombre, tipo, dia, fecha, horario, marca, diferencia, circunstancia," & vbNewLine & _
                "	 justificacion, id_horario, id_interno, departamento, seccion, numpago, ubicacion)" & vbNewLine & _
                "VALUES(" & vbNewLine & _
                codigo & vbNewLine & _
                ", '" & nombre & "'" & vbNewLine & _
                ", '" & tipo & "'" & vbNewLine & _
                ", '" & dia & "'" & vbNewLine & _
                ", CONVERT(DATETIME,'" & fecha & "',103)" & vbNewLine & _
                phorario & vbNewLine & _
                pmarca & vbNewLine & _
                ", " & diferencia & vbNewLine & _
                ", '" & circunstancia & "'" & vbNewLine & _
                ", '" & justificacion & "'" & vbNewLine & _
                ", " & id_horario & vbNewLine & _
                ", " & id_interno & vbNewLine & _
                ", '" & departamento & "'" & vbNewLine & _
                ", '" & seccion & "'" & vbNewLine & _
                ", '" & numpago & "'" & vbNewLine & _
                ", '" & ubicacion & "')"

            cnx.SQLEXEC(strSQL)
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [insertaMarca]", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    '// esta funcion se encarga de realizar la consulta que me dice si la marca ya sea como marca o marca justificada existe o no
    Private Function marca_x_Procesar(ByVal pCodigo As Integer, ByVal pFecha As Date) As DataRow
        Try
            Dim result As New DataTable
            Dim strSQL As String = _
                "DECLARE @fecha as Char(10)" & vbNewLine & _
                "DECLARE @codigo as int" & vbNewLine & _
                "" & vbNewLine & _
                "SET @fecha = '" & pFecha.Date & "'" & vbNewLine & _
                "SET @codigo = " & pCodigo & vbNewLine & _
                "" & vbNewLine & _
                "SELECT" & vbNewLine & _
                "(select COUNT(*) as marcas from tbl_marcas  where RTRIM(ltrim(codigo))=@codigo and" & vbNewLine & _
                "	timeStamp between CONVERT(datetime,@fecha,103) and CONVERT(datetime,@fecha + ' 23:59:59:999',103)" & vbNewLine & _
                ") AS MARCA," & vbNewLine & _
                "(select COUNT(*) as marcas from tbl_marcas  where RTRIM(ltrim(codigo))=@codigo and" & vbNewLine & _
                "	timeStamp between CONVERT(datetime,@fecha,103) and CONVERT(datetime,@fecha + ' 23:59:59:999',103) and" & vbNewLine & _
                "	id_procesado = 0 and numpago is null" & vbNewLine & _
                ") AS PROCESADA," & vbNewLine & _
                "(select COUNT(*) as justificada from tbl_marcas_justificadas_pend where RTRIM(ltrim(codigo))=@codigo and" & vbNewLine & _
                " fecha between CONVERT(datetime,@fecha,103) and CONVERT(datetime,@fecha + ' 23:59:59:999',103)" & vbNewLine & _
                ") AS JUSTIFICADA"

            cnx.SQLEXEC(result, strSQL)
            If result.Rows.Count = 0 Then
                Return Nothing
            Else
                Return result.Rows(0)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [marca_x_Procesar]", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    '// esta funcion se encarga de asignar una circunstancia a una marca osea el texto que dice "LLEGO 0.12 HORAS TARDE".
    Private Function cargaCircunstacia(ByVal diferencia As Decimal, ByVal tipo As String) As String
        If diferencia = 0 Then
            Return ""
        End If
        Return IIf(tipo = "ENTRADA", "LLEGA " & diferencia & " HORAS TARDE", "SALE " & diferencia & " HORAS ANTES")
    End Function

    '// esta funcion se encarga de cargar una marca para ser procesada
    Private Function cargaMarcas(ByVal pCodigo As Integer, ByVal pFecha As Date) As DataTable
        Try
            Dim result As New DataTable
            Dim strSQL As String = _
                "SELECT codigo, timeStamp, entrada, salida, id_horario, id_horario_sale, id_interno, id_procesado," & vbNewLine & _
                "   ubicacion_entra, ubicacion_salida FROM tbl_marcas" & vbNewLine & _
                "WHERE (RTRIM(LTRIM(codigo)) = '" & pCodigo & "') AND (id_procesado = 0) AND (numpago is null) AND" & vbNewLine & _
                "   (timeStamp BETWEEN CONVERT(DATETIME,'" & pFecha & "',103) AND CONVERT(DATETIME,'" & pFecha & " 23:59:59.999',103))" & vbNewLine & _
                "ORDER BY timeStamp DESC"

            cnx.SQLEXEC(result, strSQL)
            If result.Rows.Count = 0 Then
                Return Nothing
            Else
                Return result
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [cargaMarcas]", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    '// esta funcion calclula la cantida de horas ya sea tardes o anticipadas
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

    '// consulta el horario entrada y salida por el id_horario y el dia de la semana tomando como referencia la fecha
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
                "  CASE WHEN @pDia='LUN' THEN lunesin" & vbNewLine & _
                "		WHEN @pDia='MAR' THEN martesin" & vbNewLine & _
                "		WHEN @pDia='MIÉ' THEN miercolesin" & vbNewLine & _
                "		WHEN @pDia='JUE' THEN juevesin" & vbNewLine & _
                "		WHEN @pDia='VIE' THEN viernesin" & vbNewLine & _
                "		WHEN @pDia='SÁB' THEN sabadoin" & vbNewLine & _
                "		WHEN @pDia='DOM' THEN domingoin" & vbNewLine & _
                "	END AS ENTRA," & vbNewLine & _
                "  CASE WHEN @pDia='LUN' THEN lunesout" & vbNewLine & _
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
                    ElseIf dt.Rows(0).Item("ENTRA").ToString.Trim.Length <> 5 Then
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
                    ElseIf dt.Rows(0).Item("SALE").ToString.Trim.Length <> 5 Then
                        strResult += " " + "00:00:01"
                    Else
                        strResult += " " + dt.Rows(0).Item("SALE")
                    End If
                End If
                result = CType(strResult, DateTime)
            End If
            Return result
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [cargaHorarios]", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    '/* carga los datos correspondientes para marcas en el rango de fechas establecido por el usuario
    '   - recorre la lista de todos los empleados
    '   - para cada empleado carga las marcas justificacadas y no justificadas
    '   - para las marcas no justificadas crea un registro indicando que esa marca no se justificó
    '   - para los dos pasos anteriores almacena toda la informacion recopilada en tbl_marcas_justificadas_act
    '   - despues de cargar todo en ´act´ saca todos los id_internos(id de linea en la tabla de marcas) que
    '     estan en ´act´ y se va a la tabla de marca y los actualiza indicando que ya fueron procesados y que
    '     ya fueron cargados para generacion de rebajos colocando el numero de pago en que se hizo a cada linea
    '   - para finalizar muestra los datos al usuario.
    Private Sub cargaDatos()
        Try
            Progress.Minimum = 0
            Progress.Maximum = dts.Tables("tblListEmpleados").Rows.Count + 1

            '// * dif * es la cantidad de dias a analizar para el empleado que le corresponde el item("codigo) del primer for
            Dim dif As Integer = DateDiff(DateInterval.Day, dtpInicio.Value.Date, dtpFinal.Value.Date)

            '// este mae recorre la lista de empleados que estan activos y que marcan entrada/salida
            For ix = 0 To dts.Tables("tblListEmpleados").Rows.Count - 1

                '// este mae recorre el rango de fechas seleccionadas por el usuario para el empleado que esta en el recorrido anterior
                For i = 0 To dif
                    Dim codigo As Integer = dts.Tables("tblListEmpleados").Rows(ix).Item("codigo")
                    Dim nombre As String = dts.Tables("tblListEmpleados").Rows(ix).Item("nombre")
                    Dim departamento As String = dts.Tables("tblListEmpleados").Rows(ix).Item("departamento")
                    Dim seccion As String = dts.Tables("tblListEmpleados").Rows(ix).Item("seccion")
                    Dim dr As DataRow = marca_x_Procesar(dts.Tables("tblListEmpleados").Rows(ix).Item("codigo"), DateAdd(DateInterval.Day, i, dtpInicio.Value.Date))

                    'Esquema de analisis para marca_x_procesar
                    '---------------------------------------------------------
                    '|MARCA|PROCESADA|JUSTIFICADA|ACCION                     |
                    '---------------------------------------------------------
                    '|  0  |    0    |     0     |Ausencia sin justificacion |
                    '|  1  |    0    |     1     |Sin accion                 |
                    '|  1  |    1    |     0     |Analiza marca y crea rebajo|
                    '|  0  |    0    |     1     |Sin accion                 |

                    If dr.Item("marca") = 0 And dr.Item("procesada") = 0 And dr.Item("justificada") = 0 Then
                        If esHoraFijo(codigo) Then
                            If esLibre(codigo, WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper.Substring(0, 3)) Then
                                insertaMarca(codigo, nombre, "ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                             DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 0, "DIA LIBRE", "", 0, 0, departamento, seccion, "")

                                insertaMarca(codigo, nombre, "SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                             DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 0, "DIA LIBRE", "", 0, 0, departamento, seccion, "")
                            Else
                                insertaMarca(codigo, nombre, "ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                             DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, departamento, seccion, "")

                                insertaMarca(codigo, nombre, "SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                             DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, departamento, seccion, "")
                            End If
                        Else
                            insertaMarca(codigo, nombre, "ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                         DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, departamento, seccion, "")

                            insertaMarca(codigo, nombre, "SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                         DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, Nothing, Nothing, 8, "AUSENCIA", "", 0, 0, departamento, seccion, "")
                        End If
                    ElseIf dr.Item("marca") = 1 And dr.Item("procesada") = 1 And dr.Item("justificada") = 0 Then
                        Dim dt As DataTable = cargaMarcas(codigo, DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)

                        For ii = 0 To dt.Rows.Count - 1
                            Dim marcaEntra As DateTime = IIf(IsDBNull(dt.Rows(ii).Item("Entrada")), Nothing, dt.Rows(ii).Item("Entrada"))
                            Dim marcaSale As DateTime = IIf(IsDBNull(dt.Rows(ii).Item("Salida")), Nothing, dt.Rows(ii).Item("Salida"))
                            Dim pidHorario As Integer = IIf(IsDBNull(dt.Rows(ii).Item("id_horario")), 0, dt.Rows(ii).Item("id_horario"))
                            Dim pidHorariosale As Integer = IIf(IsDBNull(dt.Rows(ii).Item("id_horario_sale")), 0, dt.Rows(ii).Item("id_horario_sale"))
                            Dim horarioEntra As DateTime = cargaHorarios(pidHorario, pidHorariosale, DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, True)
                            Dim horarioSale As DateTime = cargaHorarios(pidHorario, pidHorariosale, DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, False)
                            Dim difEntrada As Decimal = calculaHoras(horarioEntra, marcaEntra)
                            Dim difSalida As Decimal = calculaHoras(marcaSale, horarioSale)
                            Dim pidInterno As Integer = IIf(IsDBNull(dt.Rows(ii).Item("id_interno")), Nothing, dt.Rows(ii).Item("id_interno"))
                            Dim ubicacionEntra As String = IIf(IsDBNull(dt.Rows(ii).Item("ubicacion_entra")), Nothing, dt.Rows(ii).Item("ubicacion_entra"))
                            Dim ubicacionSale As String = IIf(IsDBNull(dt.Rows(ii).Item("ubicacion_salida")), Nothing, dt.Rows(ii).Item("ubicacion_salida"))

                            insertaMarca(codigo, nombre, "ENTRADA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                        DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, horarioEntra, marcaEntra, difEntrada, _
                                        cargaCircunstacia(difEntrada, "ENTRADA"), "", pidHorario, pidInterno, departamento, seccion, ubicacionEntra)

                            insertaMarca(codigo, nombre, "SALIDA", WeekdayName(Weekday(DateAdd(DateInterval.Day, i, dtpInicio.Value).Date)).ToUpper, _
                                        DateAdd(DateInterval.Day, i, dtpInicio.Value).Date, horarioSale, marcaSale, difSalida, _
                                        cargaCircunstacia(difEntrada, "AUSENCIA"), "", pidHorariosale, pidInterno, departamento, seccion, ubicacionSale)

                        Next
                    End If
                Next
                Progress.Value = ix
            Next

            Dim finicio As String = Format(dtpInicio.Value, "dd/MM/yyyy")
            Dim ffinal As String = Format(dtpFinal.Value, "dd/MM/yyyy")
            Dim strSQL As String = "INSERT INTO tbl_marcas_justificadas_act (codigo, nombre, tipo, dia," & vbNewLine & _
                                    "	fecha, horario, marca, diferencia, circunstancia, justificacion," & vbNewLine & _
                                    "	id_horario, id_interno, id_linea, departamento, seccion, numpago, ubicacion)" & vbNewLine & _
                                    "SELECT codigo, nombre, tipo, dia, fecha, horario, marca, diferencia," & vbNewLine & _
                                    "	circunstancia, justificacion, id_horario, id_interno, id_linea," & vbNewLine & _
                                    "	departamento, seccion, '" & numpago & "' as numpago, ubicacion" & vbNewLine & _
                                    "FROM tbl_marcas_justificadas_pend" & vbNewLine & _
                                    "WHERE (fecha BETWEEN CONVERT(DATETIME,'" & finicio & "',103) AND CONVERT(DATETIME,'" & ffinal & "',103))" & vbNewLine & _
                                    "" & vbNewLine & _
                                    "DELETE FROM tbl_marcas_justificadas_pend WHERE (fecha BETWEEN CONVERT(DATETIME,'" & finicio & "',103) AND CONVERT(DATETIME,'" & ffinal & "',103))"
            cnx.SQLEXEC(strSQL)

            strSQL = "UPDATE tbl_marcas SET id_procesado = 1, numpago = '" & numpago & "'" & vbNewLine & _
                     "WHERE (timeStamp BETWEEN CONVERT(DATETIME,'" & finicio & "',103) AND CONVERT(DATETIME,'" & ffinal & "',103))"
            cnx.SQLEXEC(strSQL)

            MessageBox.Show("Descarga de marcas generada con éxito." & vbNewLine & _
                            "Para continuar con el proceso de rebajos debe volver a ingresar a la pantalla.", "DESCARGA MARCAS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Close()
            'Progress.Value = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [cargaDatos]", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub cargaGrid()
        Try
            Dim strSQL As String = "SELECT CASE WHEN diferencia > 0 AND (justificacion='' OR justificacion IS NULL)" & vbNewLine & _
                                    "   THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS JUSTIFICADO, codigo, nombre," & vbNewLine & _
                                    "	tipo, dia, fecha, horario, marca, diferencia,circunstancia, justificacion," & vbNewLine & _
                                    "   id_horario, id_interno, id_linea, departamento, seccion, ubicacion" & vbNewLine & _
                                    "FROM tbl_marcas_justificadas_act ORDER BY CODIGO, fecha"
            cnx.SQLEXEC(dts, strSQL, "tbl_marcas_justificadas_act")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_marcas_justificadas_act"
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

            DataGridView1.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(11).Visible = False
            DataGridView1.Columns(12).Visible = False
            DataGridView1.Columns(13).Visible = False


            DataGridView1.Columns(0).HeaderText = "JUST."
            DataGridView1.Columns(1).HeaderText = "CODIGO"
            DataGridView1.Columns(2).HeaderText = "NOMBRE"
            DataGridView1.Columns(3).HeaderText = "TIPO"
            DataGridView1.Columns(4).HeaderText = "DIA"
            DataGridView1.Columns(5).HeaderText = "FECHA"
            DataGridView1.Columns(6).HeaderText = "HORARIO"
            DataGridView1.Columns(7).HeaderText = "MARCA"
            DataGridView1.Columns(8).HeaderText = "DIF."
            DataGridView1.Columns(9).HeaderText = "CIRCUNSTANCIA"
            DataGridView1.Columns(10).HeaderText = "JUSTIFICACION"
            DataGridView1.Columns(11).HeaderText = "ID_HORARIO"
            DataGridView1.Columns(12).HeaderText = "ID_INTERNO"
            DataGridView1.Columns(13).HeaderText = "ID_LINEA"
            DataGridView1.Columns(14).HeaderText = "DEPARTAMENTO"
            DataGridView1.Columns(15).HeaderText = "SECCION"
            DataGridView1.Columns(16).HeaderText = "UBICACION"

            DataGridView1.Columns(0).Width = 60
            DataGridView1.Columns(1).Width = 50
            DataGridView1.Columns(2).Width = 230
            DataGridView1.Columns(3).Width = 60
            DataGridView1.Columns(4).Width = 70
            DataGridView1.Columns(5).Width = 70
            DataGridView1.Columns(6).Width = 120
            DataGridView1.Columns(7).Width = 120
            DataGridView1.Columns(8).Width = 50
            DataGridView1.Columns(9).Width = 160
            DataGridView1.Columns(10).Width = 180
            DataGridView1.Columns(14).Width = 140
            DataGridView1.Columns(15).Width = 140
            DataGridView1.Columns(16).Width = 140

            DataGridView1.Columns(0).DisplayIndex = 0
            DataGridView1.Columns(1).DisplayIndex = 1
            DataGridView1.Columns(2).DisplayIndex = 2
            DataGridView1.Columns(3).DisplayIndex = 3
            DataGridView1.Columns(4).DisplayIndex = 4
            DataGridView1.Columns(16).DisplayIndex = 5
            DataGridView1.Columns(5).DisplayIndex = 6
            DataGridView1.Columns(6).DisplayIndex = 7
            DataGridView1.Columns(7).DisplayIndex = 8
            DataGridView1.Columns(8).DisplayIndex = 9
            DataGridView1.Columns(9).DisplayIndex = 10
            DataGridView1.Columns(10).DisplayIndex = 11
            DataGridView1.Columns(11).DisplayIndex = 12
            DataGridView1.Columns(12).DisplayIndex = 13
            DataGridView1.Columns(13).DisplayIndex = 14
            DataGridView1.Columns(14).DisplayIndex = 15
            DataGridView1.Columns(15).DisplayIndex = 16
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [cargaGrid]", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub DesActiva(ByVal plActiva As Boolean)
        btnImprimir.Enabled = Not plActiva
        btnExcel.Enabled = Not plActiva
        btnRebajos.Enabled = Not plActiva
        dtpInicio.Enabled = plActiva
        dtpFinal.Enabled = plActiva
        btnCargar.Enabled = plActiva
    End Sub

    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click

        'If Not chequeEmpleadosSinHorario() Then
        '    MessageBox.Show("Existen empleados sin horario o con mas de un horario asignado. " & vbNewLine & _
        '                    "Imposible proceder con el proceso. !!!" & vbNewLine & _
        '                    "Vea el archivo ""C:\APROGRAMAS\cargaMarcasLog.txt""", "CARGA DE MARCAS PARA REBAJO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Close()
        '    Exit Sub
        'End If

        If dtpFinal.Value < dtpInicio.Value Then
            MessageBox.Show("La fecha final no puede ser menor a la fecha inicial !!!", "CARGA DE MARCAS PARA REBAJO !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim pnt As New frmNumPago()

        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            numpago = pnt.encPago
        End If
        pnt.Close()

        If numpago = "" Then
            Exit Sub
        End If

        If MessageBox.Show("Se dispone a cargar las marcas del periodo (" & dtpInicio.Value.Date & " al " & dtpFinal.Value.Date & ")." & vbNewLine & _
                           "Éste proceso no es reversible. ¿ Seguro de proceder ?", "CARGA DE MARCAS PARA REBAJO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        cargaDatos()
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts
        pntexcel.tabla = "tbl_marcas_justificadas_act"
        pntexcel.titulo = "CARGA DE MARCAS PARA REBAJO"
        pntexcel.filtro = "DEL " & dtpInicio.Value.Date & " AL " & dtpFinal.Value.Date
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Try
        '    If dts.Tables.Contains("tblDatosMarcasHist") Then
        '        dts.Tables.Remove("tblDatosMarcasHist")
        '    End If

        '    Dim strSQL As String = _
        '        "SELECT CASE WHEN diferencia > 0 AND (justificacion='' OR justificacion IS NULL) THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END AS JUSTIFICADO," & vbNewLine & _
        '        "	codigo, nombre, tipo, dia, fecha, horario, marca, diferencia, circunstancia, justificacion, id_horario, id_interno, id_linea, departamento, seccion, ubicacion" & vbNewLine & _
        '        "FROM tbl_marcas_justificadas_act ORDER BY departamento, seccion, nombre"
        '    cnx.SQLEXEC(dts, strSQL, "tblDatosMarcasHist")

        '    Dim shwrpt As New frmReport()
        '    Dim rpt As New rptMarcasHist_new()
        '    Dim par1 As New ParameterValues
        '    Dim par2 As New ParameterValues

        '    par1.AddValue("LISTADO DE REBAJOS POR MARCAS")
        '    par2.AddValue(dtpInicio.Value.ToShortDateString & " AL " & dtpFinal.Value.ToShortDateString)
        '    rpt.SetDataSource(dts)
        '    rpt.ParameterFields("pTitulo").CurrentValues = par1
        '    rpt.ParameterFields("pFiltro").CurrentValues = par2
        '    shwrpt.CrystalReportViewer1.ReportSource = rpt
        '    shwrpt.MdiParent = Me.MdiParent
        '    shwrpt.Show()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & vbNewLine & "Method: [btnImprimir_Click]", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub frmRebajosCarga_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            '// mae este query cuenta cuantos registros hay en tbl_marcas_justificadas_act
            Dim strSQL As String = "SELECT COUNT(*) AS Cant FROM tbl_marcas_justificadas_act"
            Dim obj As Object = cnx.SQLEXECESCALAR(strSQL)
            Dim mJustif As Integer = CType(obj, Integer)

            If mJustif = 0 Then
                DesActiva(True)
            Else
                DesActiva(False)
            End If

            cargaGrid()

            '// mae este query me carga el rango de fechas de corte para la descarga de marcas
            Dim dtFechas As New DataTable
            strSQL = "SELECT MIN(fecha) AS inicial, MAX(fecha) AS final FROM tbl_marcas_justificadas_act"
            cnx.SQLEXEC(dtFechas, strSQL)

            dtpInicio.Value = IIf(IsDBNull(dtFechas.Rows(0).Item("Inicial")), Now.Date, dtFechas.Rows(0).Item("Inicial"))
            dtpFinal.Value = IIf(IsDBNull(dtFechas.Rows(0).Item("Final")), Now.Date, dtFechas.Rows(0).Item("Final"))

            '// mae este query me carga la lista de colaboradores con los datos de la seccion y el departamento
            '// fchas para todos del 18/06 al 04/07 
            '// 167 - Montes Delgado Angela
            '// 008 - Alfaro Fernandez Anthony
            '// 104 - Flores NoIndicaOtro Roger
            '"AND (tbl_empleados_sap.empid IN (167,104,8))" & vbNewLine & _

            strSQL = _
                "SELECT departamento, seccion, empID as codigo, nombre" & vbNewLine & _
                "FROM view_sl_empleados WHERE (estado_empleado = 'ACT') AND (marca_reloj = 1)" & vbNewLine & _
                "ORDER BY departamento, seccion"

            cnx.SQLEXEC(dts, strSQL, "tblListEmpleados")
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Method: [frmRebajosCarga_Load]", "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Me.Text = DateDiff(DateInterval.Day, dtpInicio.Value.Date, dtpFinal.Value.Date) + 1
    End Sub

    Private Sub btnRebajos_Click(sender As System.Object, e As System.EventArgs) Handles btnRebajos.Click
        Dim obj As New frmRabajos()
        obj.dts = dts
        obj.pnt = Me
        obj.Show()
    End Sub
End Class