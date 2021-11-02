Public Class frmConsultaMarcasDia
    Dim dts As New DataSet()
    Dim fecha As DateTime = DateTime.Now
    Dim strSQL As String = ""
    Dim encontrado As Boolean = False
    Dim dv As New DataView()


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

    Private Function esLibre(ByVal codigo As Integer, ByVal dia As String) As Boolean
        'Try
        Dim dt As New DataTable
        strSQL =
            "SELECT subString(tbl_tipo_horario.dia_feriado,1,3) as Feriado, subString(tbl_tipo_horario.dia_feriado2,1,3) as Feriado2" & vbNewLine &
            "FROM tbl_horarioxEmpleado INNER JOIN tbl_tipo_horario ON tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine &
            "WHERE (tbl_horarioxEmpleado.empID = " & codigo & ")"
        cnx.SQLEXEC(dts, strSQL, "QTMP")

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
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try

    End Function

    Private Function Localizar(ByVal dato As String, ByVal pos As Integer) As Integer

        Dim strLinea As String = ""
        If pos <= dts.Tables("tblResult").Rows.Count - 1 Then
            strLinea = dts.Tables("tblResult").Rows(pos).Item("DEPARTAMENTO").ToString & vbTab &
                        dts.Tables("tblResult").Rows(pos).Item("SECCION").ToString & vbTab &
                        dts.Tables("tblResult").Rows(pos).Item("EMPID").ToString & vbTab &
                        dts.Tables("tblResult").Rows(pos).Item("NOMBRE").ToString & vbTab &
                        dts.Tables("tblResult").Rows(pos).Item("CIRCUNSTANCIA").ToString
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

    Private Sub RegActual()
        If dts.Tables.Contains("tblResult") Then
            lblRecActual.Text = "Registro #" & BindingContext(dts, "tblResult").Position + 1 & "/" & BindingContext(dts, "tblResult").Count
            GroupBox1.Enabled = IIf(BindingContext(dts, "tblResult").Count = 0, False, True)
        End If
    End Sub

    Private Sub mensajes(ByVal mensaje As String)
        lblMensage.Text = IIf(mensaje.Length > 0, mensaje.ToUpper(), "")
        lblMensage.ForeColor = IIf(mensaje.Length > 0, Color.White, Color.Transparent)
        lblMensage.BackColor = IIf(mensaje.Length > 0, Color.Red, Color.Transparent)
    End Sub

    Private Sub pctLocalizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pctLocalizar.Click
        If txtLocalizar.Text.Length = 0 Then
            mensajes("Debe de ingresar un dato para realizar la acción !!!")
            Exit Sub
        End If
        If encontrado Then
            Dim localizado As Integer = Localizar(txtLocalizar.Text, BindingContext(dts, "tblResult").Position + 1)
            BindingContext(dts, "tblResult").Position = IIf(localizado = -1, BindingContext(dts, "tblResult").Position, localizado)
        Else
            Dim localizado As Integer = Localizar(txtLocalizar.Text, 0)
            BindingContext(dts, "tblResult").Position = IIf(localizado = -1, BindingContext(dts, "tblResult").Position, localizado)
            encontrado = IIf(localizado = -1, False, True)
            If Not encontrado Then
                mensajes("La búsqueda no produjo resultados #" & txtLocalizar.Text & "#")
            End If
        End If
        RegActual()
    End Sub

    Private Sub desActiva(ByVal pActiva As Boolean)
        btnLimpiar.Enabled = pActiva
        btnImprimir.Enabled = pActiva
        btnExcel.Enabled = pActiva
        GroupBox1.Enabled = pActiva
        btnGenerar.Enabled = Not pActiva
        TabControl1.Enabled = pActiva
    End Sub

    Private Sub tsbPrimero_Click(sender As System.Object, e As System.EventArgs) Handles tsbPrimero.Click, tsbAnterior.Click, tsbUltimo.Click, tsbSiguiente.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Tag
            Case "1" 'Ir al primero
                BindingContext(dts, "tblResult").Position = 0
            Case "2" 'Ir al anterior
                BindingContext(dts, "tblResult").Position -= 1
            Case "3" 'Ir al siguiente
                BindingContext(dts, "tblResult").Position += 1
            Case "4" 'Ir al ultimo
                BindingContext(dts, "tblResult").Position = dts.Tables("tblResult").Rows.Count - 1
        End Select
    End Sub

    Private Sub DataGridView_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        RegActual()
    End Sub

    Private Sub txtLocalizar_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtLocalizar.KeyPress
        If Asc(e.KeyChar) = 13 Then
            pctLocalizar.PerformClick()
        End If
    End Sub

    Private Sub txtLocalizar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLocalizar.TextChanged
        txtLocalizar.BackColor = IIf(txtLocalizar.Text.Length = 0, Color.White, Color.LightSteelBlue)
        mensajes("")
    End Sub

    Private Function cargaSeccion(ByVal empid As Integer) As String
        'Try
        strSQL = "SELECT CASE WHEN seccion IS NULL THEN 'NO ASIGNADO' ELSE seccion END FROM view_sl_empleados WHERE empid = '" & empid & "'"
        Dim obj As Object = cnx.SQLEXECESCALAR(strSQL)
        Dim result As String = CType(obj, String)
        Return result
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try
    End Function

    Private Function cargaDepartamento(ByVal empid As Integer) As String
        'Try
        strSQL = "SELECT CASE WHEN departamento IS NULL THEN 'NO ASIGNADO' ELSE departamento END FROM view_sl_empleados WHERE empid = '" & empid & "'"
        Dim obj As Object = cnx.SQLEXECESCALAR(strSQL)
        Dim result As String = CType(obj, String)
        Return result
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try
    End Function

    Private Function cargaMarca(ByVal empid As Integer, ByVal pFecha As DateTime) As DataTable
        'Try
        Dim result As New DataTable
        strSQL =
            "SELECT entrada, salida FROM tbl_marcas WHERE (RTRIM(LTRIM(codigo)) = '" & empid & "') AND" & vbNewLine &
            "	(timeStamp BETWEEN CONVERT(datetime, '" & Format(pFecha, "dd/MM/yyyy") & " 00:00', 103)" & vbNewLine &
            "				   AND CONVERT(datetime, '" & Format(pFecha, "dd/MM/yyyy") & " 23:59', 103))" & vbNewLine &
            "ORDER BY entrada"

        cnx.SQLEXEC(result, strSQL)

        If result.Rows.Count > 0 Then
            Return result
        Else
            Return Nothing
        End If
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try
    End Function

    Private Function cargaHorario(ByVal empid As Integer, ByVal pFecha As Date) As String
        'Try
        strSQL = "SET LANGUAGE spanish" & vbNewLine &
                "DECLARE @FECHA AS DATETIME" & vbNewLine &
                "SET @FECHA = CONVERT(DATETIME,'" & Format(pFecha, "dd/MM/yyyy") & "',103)" & vbNewLine &
                "select convert(datetime,'" & pFecha & " ' +" & vbNewLine &
                "			case when datepart(weekday,@FECHA) = 1 then (case when rtrim(ltrim(lunesIn))=':' then '00:00' else lunesIn end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 2 then (case when rtrim(ltrim(martesIn))=':' then '00:00' else martesIn end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 3 then (case when rtrim(ltrim(miercolesIn))=':' then '00:00' else miercolesIn end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 4 then (case when rtrim(ltrim(juevesIn))=':' then '00:00' else juevesIn end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 5 then (case when rtrim(ltrim(viernesIn))=':' then '00:00' else viernesIn end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 6 then (case when rtrim(ltrim(sabadoIn))=':' then '00:00' else sabadoIn end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 7 then (case when rtrim(ltrim(domingoIn))=':' then '00:00' else domingoIn end)" & vbNewLine &
                "			end,103" & vbNewLine &
                "		) as HorarioEntrada," & vbNewLine &
                "	convert(datetime,'" & pFecha & " ' +" & vbNewLine &
                "			case when datepart(weekday,@FECHA) = 1 then (case when rtrim(ltrim(lunesOut))=':' then '00:00' else lunesOut end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 2 then (case when rtrim(ltrim(martesOut))=':' then '00:00' else martesOut end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 3 then (case when rtrim(ltrim(miercolesOut))=':' then '00:00' else miercolesOut end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 4 then (case when rtrim(ltrim(juevesOut))=':' then '00:00' else juevesOut end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 5 then (case when rtrim(ltrim(viernesOut))=':' then '00:00' else viernesOut end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 6 then (case when rtrim(ltrim(sabadoOut))=':' then '00:00' else sabadoOut end)" & vbNewLine &
                "				when datepart(weekday,@FECHA) = 7 then (case when rtrim(ltrim(domingoOut))=':' then '00:00' else domingoOut end)" & vbNewLine &
                "			end,103" & vbNewLine &
                "		) as HorarioSalida" & vbNewLine &
                "from tbl_tipo_horario" & vbNewLine &
                "where id_horario in (select id_horario from tbl_horarioxempleado where empid = " & empid & ")"
        Dim dt As New DataTable
        cnx.SQLEXEC(dt, strSQL)

        Dim result As String = ""
        If dt.Rows.Count = 0 Then
            result = "NO ASIGNADO|NO ASIGNADO"
        Else
            result = dt.Rows(0).Item("HorarioEntrada") & "|" & dt.Rows(0).Item("HorarioSalida")
        End If
        Return result

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try
    End Function

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        'Try
        Dim dt As New DataTable("tblResult")
        Dim canDias As Integer = DateDiff(DateInterval.Day, dtpInicio.Value.Date, dtpFinal.Value.Date)

        dt.Columns.Add("DEPARTAMENTO", GetType(String))     ' 1
        dt.Columns.Add("SECCION", GetType(String))          ' 2
        dt.Columns.Add("EMPID", GetType(Integer))           ' 3
        dt.Columns.Add("NOMBRE", GetType(String))           ' 4
        dt.Columns.Add("HORARIO_ENTRADA", GetType(String))  ' 5
        dt.Columns.Add("HORARIO_SALIDA", GetType(String))   ' 6
        dt.Columns.Add("MARCA_ENTRADA", GetType(DateTime))  ' 7 
        dt.Columns.Add("MARCA_SALIDA", GetType(DateTime))   ' 8
        dt.Columns.Add("DIFERENCIA", GetType(Decimal))      ' 9
        dt.Columns.Add("DIFERENCIA2", GetType(Decimal))     '10
        dt.Columns.Add("HORASLABORA", GetType(Decimal))     '11
        dt.Columns.Add("CIRCUNSTANCIA", GetType(String))    '12
        dts.Tables.Add(dt)

        pbProceso.Minimum = 0
        pbProceso.Maximum = dts.Tables("tblEmpleados").Rows.Count - 1
        pbProceso.Visible = True

        For i = 0 To dts.Tables("tblEmpleados").Rows.Count - 1 ''RECORRO LA LISTA DE COLABORADORES 
            For j = 0 To canDias '' CONSULTO LOS COLABORADORES POR DIA
                Dim pfechaEv As Date = DateAdd(DateInterval.Day, j, dtpInicio.Value.Date)
                Dim dr As DataTable = cargaMarca(dts.Tables("tblEmpleados").Rows(i).Item("empid"), pfechaEv)
                Dim strHora As String = cargaHorario(dts.Tables("tblEmpleados").Rows(i).Item("empid"), pfechaEv)
                Dim arr As Array = strHora.Split("|")
                Dim horEntra As String = arr(0)
                Dim horSale As String = arr(1)
                Dim pDia As String = WeekdayName(Weekday(pfechaEv)).ToUpper.Substring(0, 3)
                pDia = IIf(pDia = "MIÉ", "MIE", pDia)
                Dim circunstancia As String = IIf(esLibre(dts.Tables("tblEmpleados").Rows(i).Item("empid"), pDia), "LIBRE", "PRESENTE")
                Dim hoEcalc As DateTime
                Dim hoScalc As DateTime

                If horEntra = "NO ASIGNADO" Then
                    hoEcalc = Nothing
                Else
                    hoEcalc = Date.Parse(horEntra)
                End If

                If horSale = "NO ASIGNADO" Then
                    hoScalc = Nothing
                Else
                    hoScalc = Date.Parse(horSale)
                End If


                If IsNothing(dr) Then
                    dts.Tables("tblResult").Rows.Add(
                        cargaDepartamento(dts.Tables("tblEmpleados").Rows(i).Item("empid")),    ' 1
                        cargaSeccion(dts.Tables("tblEmpleados").Rows(i).Item("empid")),         ' 2
                        dts.Tables("tblEmpleados").Rows(i).Item("empid"),                       ' 3
                        dts.Tables("tblEmpleados").Rows(i).Item("nombre"),                      ' 4
                        horEntra,                                                               ' 5
                        horSale,                                                                ' 6
                        Nothing,                                                                ' 7
                        Nothing,                                                                ' 8
                        IIf(circunstancia = "LIBRE", 0, 8),                                     ' 9
                        IIf(circunstancia = "LIBRE", 0, 8),                                     '10
                        Nothing,                                                                '11
                        IIf(circunstancia = "LIBRE", "LIBRE", "AUSENTE")                        '12
                        )
                Else

                    For ii = 0 To dr.Rows.Count - 1 '' SI UN COLABORADOR REALIZO UNA O MAS DE UNA MARCA(ENTRADA/SALIDA) LAS CARGO TODAS
                        Dim marEntra As DateTime = IIf(IsDBNull(dr.Rows(ii).Item("ENTRADA")), Nothing, dr.Rows(ii).Item("ENTRADA"))
                        Dim marSale As DateTime = IIf(IsDBNull(dr.Rows(ii).Item("SALIDA")), Nothing, dr.Rows(ii).Item("SALIDA"))

                        dts.Tables("tblResult").Rows.Add(
                            cargaDepartamento(dts.Tables("tblEmpleados").Rows(i).Item("empid")), _  ' 1
                            cargaSeccion(dts.Tables("tblEmpleados").Rows(i).Item("empid")), _       ' 2
                            dts.Tables("tblEmpleados").Rows(i).Item("empid"), _                     ' 3
                            dts.Tables("tblEmpleados").Rows(i).Item("nombre"), _                    ' 4
                            horEntra, _                                                             ' 5
                            horSale, _                                                              ' 6
                            marEntra, _                                                             ' 7
                            marSale, _                                                              ' 8
                            calculaHoras(hoEcalc, marEntra), _                                      ' 9
                            calculaHoras(marSale, hoScalc), _                                       '10
                            calculaHoras(marEntra, marSale), _                                      '11
                            circunstancia _                                                         '12
                            )

                    Next
                End If
            Next
            pbProceso.Value = i
        Next

        pbProceso.Visible = False
        dv.Table = dts.Tables("tblResult")

        DataGridView1.DataSource = dv
        'DataGridView1.DataMember = "tblResult"
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToResizeColumns = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.AllowUserToResizeRows = False
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = True
        DataGridView1.RowHeadersVisible = False
        DataGridView1.Font = New Font("Microsoft Sans Serif", 7)
        DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

        For i = 0 To DataGridView1.Columns.Count - 1
            DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        DataGridView1.Columns(2).DisplayIndex = 0
        DataGridView1.Columns(3).DisplayIndex = 1
        DataGridView1.Columns(11).DisplayIndex = 2

        DataGridView1.Columns(0).HeaderText = "DEPARTAMENTO"
        DataGridView1.Columns(1).HeaderText = "SECCION"
        DataGridView1.Columns(2).HeaderText = "EMPID"
        DataGridView1.Columns(3).HeaderText = "NOMBRE"
        DataGridView1.Columns(4).HeaderText = "HORARIO_ENTRADA"
        DataGridView1.Columns(5).HeaderText = "HORARIO_SALIDA"
        DataGridView1.Columns(6).HeaderText = "MARCA_ENTRADA"
        DataGridView1.Columns(7).HeaderText = "MARCA_SALIDA"
        DataGridView1.Columns(8).HeaderText = "DIF.E"
        DataGridView1.Columns(9).HeaderText = "DIF.S"
        DataGridView1.Columns(10).HeaderText = "HOR.LABORADAS"
        DataGridView1.Columns(11).HeaderText = "CIRCUNSTANCIA"

        DataGridView1.Columns(0).Width = 110
        DataGridView1.Columns(1).Width = 110
        DataGridView1.Columns(2).Width = 45
        DataGridView1.Columns(3).Width = 190
        DataGridView1.Columns(4).Width = 130
        DataGridView1.Columns(5).Width = 130
        DataGridView1.Columns(6).Width = 120
        DataGridView1.Columns(7).Width = 120
        DataGridView1.Columns(8).Width = 30
        DataGridView1.Columns(9).Width = 30
        DataGridView1.Columns(10).Width = 50
        DataGridView1.Columns(11).Width = 70

        desActiva(True)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try
    End Sub

    Private Sub frmConsultaMarcasDia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Try
        dtpFinal.Value = Now
        dtpInicio.Value = Now.Date.AddDays(-1)
        pbProceso.Visible = False

        strSQL =
            "SELECT '' AS detalle UNION ALL" & vbNewLine &
            "SELECT departamento AS detalle FROM view_sl_departamentos " & vbNewLine &
            "WHERE id_departamento <> 'ND' ORDER BY 1"
        cnx.SQLEXEC(dts, strSQL, "tbl_departamentos")

        strSQL =
            "SELECT '' as detalle UNION ALL" & vbNewLine &
            "SELECT CENTRO_COSTO AS detalle FROM view_sl_secciones" & vbNewLine &
            "WHERE (id_centro_costo NOT IN ('ND','00-00-00'))" & vbNewLine &
            "ORDER BY 1"
        cnx.SQLEXEC(dts, strSQL, "tbl_secciones")

        strSQL = "DECLARE @userid AS VARCHAR(5)" & vbNewLine &
                 "SET @userid = '" & pempID.ToString.Trim & "'" & vbNewLine &
                 "" & vbNewLine &
                 "SELECT empID, nombre FROM view_sl_empleados" & vbNewLine &
                 "WHERE (estado_empleado = 'ACT')" & IIf(verTodos, "", " AND (JEFE = @userid)") & vbNewLine &
                 "ORDER BY departamento, seccion"
        cnx.SQLEXEC(dts, strSQL, "tblEmpleados")

        cbDepartamento.DataSource = dts
        cbDepartamento.DisplayMember = "tbl_departamentos.detalle"

        cbSeccion.DataSource = dts
        cbSeccion.DisplayMember = "tbl_secciones.detalle"

        RegActual()
        desActiva(False)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Close()
        'End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click
        If dts.Tables.Contains("tblResult") Then
            dts.Tables.Remove("tblResult")
        End If

        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = ""

        desActiva(False)

        cbEstado.Text = ""
        cbDepartamento.Text = ""
        cbSeccion.Text = ""
    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click
        Dim pntexcel As New frmExeleador()
        Dim dtsTMP As New DataSet()
        Dim dt As New DataTable()

        dt = dv.ToTable()
        dtsTMP.Tables.Add(dt)
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.pntOrigern = Me
        pntexcel.dts = dtsTMP
        pntexcel.tabla = "tblResult"
        pntexcel.titulo = "LISTADO DE MARCAS"
        pntexcel.filtro = "DESDE EL " & dtpInicio.Value & " AL " & dtpFinal.Value
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.Show()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        'Dim shwrpt As New frmReport()
        'Dim rpt As New rptConsultaMarcasDia()

        'rpt.SetDataSource(dv)
        'shwrpt.CrystalReportViewer1.ReportSource = rpt
        'shwrpt.MdiParent = Me.MdiParent
        'shwrpt.Show()
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim fFiltro As String = "NOMBRE LIKE '%%' " &
            IIf(cbEstado.Text = "", "", "AND CIRCUNSTANCIA LIKE '%" & cbEstado.Text & "%'") &
            IIf(cbDepartamento.Text = "", "", "AND DEPARTAMENTO LIKE '%" & cbDepartamento.Text & "%'") &
            IIf(cbSeccion.Text = "", "", "AND SECCION LIKE '%" & cbSeccion.Text & "%'")
        dv.RowFilter = fFiltro
    End Sub

End Class