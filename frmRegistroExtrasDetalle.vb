Public Class frmRegistroExtrasDetalle

    Public dts As DataSet
    Public tabla As String
    Public nuevo, cancelado As Boolean
    Public pos As Integer
    Public pnt As Form

    Dim horarioEntrada As String
    Dim diferenciaEntrada As Double
    Dim horarioSalida As String
    Dim diferenciaSalida As Double

    Dim estadoMarca As String
    Dim MontoTotalHoras As Double
    Dim idLinea As ULong

    Private Function validaCamposDigitados() As Boolean
        If (dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_sencillas") + _
            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_tmedio") + _
            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_dobles") + _
            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_feriado")) = 0 Then
            Return False
        End If

        If IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("motivo")) Or dts.Tables("tbl_Extras").Rows(pos).Item("motivo") = "" Then
            Return False
        End If

        If IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("fecha")) Then
            Return False
        End If

        Return True
    End Function

    Private Sub DesActivaCantHoras(ByVal pbActiva As Boolean)
        txtHorasSencillas.Enabled = pbActiva
        txtHorasTiempoyMedio.Enabled = pbActiva
        txtHorasDobles.Enabled = pbActiva
        txtHorasFeriado.Enabled = pbActiva
        If nuevo Then
            dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_entrada") = 0
            dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_Salida") = 0

            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_sencillas") = 0
            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_tmedio") = 0
            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_dobles") = 0
            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_feriado") = 0
            dts.Tables("tbl_Extras").Rows(pos).Item("Monto_Total") = 0
            dts.Tables("tbl_Extras").Rows(pos).Item("justificacion_automatica") = ""

            dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()
        End If
    End Sub

    Private Function verificaFecha(ByVal p_empid As Integer, p_fecha As Date) As Boolean
        Try
            Dim dt As New DataTable
            Dim cant As Integer = 0
            Dim strSQL As String = _
                "SELECT COUNT(*) AS cant FROM" & vbNewLine & _
                "(	SELECT empid, fecha FROM tbl_extras" & vbNewLine & _
                "	WHERE (empid = " & p_empid & ") AND (fecha = CONVERT(DATETIME,'" & Format(p_fecha, "dd/MM/yyyy") & "',103))" & vbNewLine & _
                "	UNION ALL" & vbNewLine & _
                "	SELECT empid, fecha FROM tbl_extras_hist" & vbNewLine & _
                "	WHERE (RTRIM(LTRIM(justificacion_automatica))<>'ANULADA') AND" & vbNewLine & _
                "		(empid = " & p_empid & ") AND (fecha = CONVERT(DATETIME,'" & Format(p_fecha, "dd/MM/yyyy") & "',103))" & vbNewLine & _
                ") AS A"
            cnx.SQLEXEC(dt, strSQL)

            cant = dt.Rows(0).Item("cant")
            Return IIf(cant = 0, True, False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return False
        End Try
    End Function

    Private Function evalMarca() As String
        If IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")) And _
            Not IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")) Then
            Return "Marca errónea"
        ElseIf Not IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")) And _
            IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")) Then
            Return "Marca errónea"
        ElseIf IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")) And _
            IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")) Then
            Return "Marca errónea"
        ElseIf Not IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")) And _
            Not IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")) Then
            Return "Marca correcta"
        End If
    End Function

    Private Sub totaliza()
        Dim total As Double = _
                txtMontoCuentaCosto.Tag + _
                txtMontoPresupuesto.Tag + _
                txtMontoPendiente.Tag
        txtTotal.Text = Format(total, "#,##0.00")
    End Sub

    Private Sub cargaMontoPendiendes(ByVal p_empId As Integer)
        Try
            Dim dt As New DataTable
            Dim strSQL As String =
                "SELECT SUM(monto_total) AS pendiente FROM tbl_extras" & vbNewLine &
                "WHERE empid IN (SELECT empid FROM crcc.dbo.ohem" & vbNewLine &
                "				WHERE dept = (SELECT dept FROM crcc.dbo.ohem" & vbNewLine &
                "							  WHERE u_estado = 1 AND empid = " & p_empId & "))"
            cnx.SQLEXEC(dt, strSQL)
            txtMontoPendiente.Tag = IIf(IsDBNull(dts.Tables("QTMP").Rows(0).Item("pendiente")), 0.0, dts.Tables("QTMP").Rows(0).Item("pendiente"))
            txtMontoPendiente.Text = Format(txtMontoPendiente.Tag, "#,##0.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cargaCuentaCuetaCosto(ByVal p_empId As Integer)
        Try
            Dim dt As New DataTable
            Dim strSQL As String =
                    "DECLARE @P1 AS DATETIME" & vbNewLine &
                    "DECLARE @P2 AS DATETIME" & vbNewLine &
                    "DECLARE @P5 AS VARCHAR(15)" & vbNewLine &
                    "DECLARE @p6 AS INT" & vbNewLine &
                    "" & vbNewLine &
                    "SET @P1=CONVERT(DATETIME,'01/09/2014',103)" & vbNewLine &
                    "SET @P2=CONVERT(DATETIME,'01/10/2014',103)" & vbNewLine &
                    "SET @p6 = (SELECT dept FROM CRCC.DBO.OHEM AS OHEM WHERE (u_estado = 1) AND (empid = " & p_empId & "))" & vbNewLine &
                    "SET @p5=(SELECT NUMEROCUENTA COLLATE DATABASE_DEFAULT" & vbNewLine &
                    "		 FROM SCGPLACRCC.dbo.SCGPL_DETALLE_CTS_CONTABLES" & vbNewLine &
                    "		 WHERE CODTIPO = @p6 AND CONFIGURACION_DE = 1 AND CODESPECIFICACION = 2)" & vbNewLine &
                    "" & vbNewLine &
                    "SELECT" & vbNewLine &
                    "	OACT.AcctName as Cuenta," & vbNewLine &
                    "	JDT1.Account as Numero," & vbNewLine &
                    "	SUM(JDT1.Debit) as Debitos," & vbNewLine &
                    "	SUM(JDT1.Credit) as Creditos," & vbNewLine &
                    "	SUM(JDT1.Credit-JDT1.Debit) as Total," & vbNewLine &
                    "	0 as Presupuesto," & vbNewLine &
                    "	0 as Diferencia" & vbNewLine &
                    "FROM CRCC.DBO.JDT1 AS JDT1 INNER JOIN" & vbNewLine &
                    "	CRCC.DBO.OACT AS OACT ON OACT.AcctCode = JDT1.Account" & vbNewLine &
                    "WHERE (JDT1.RefDate BETWEEN @P1 AND @P2) AND" & vbNewLine &
                    "	(JDT1.TransType <> -3) AND" & vbNewLine &
                    "	(JDT1.SourceLine <> 8 OR JDT1.SourceLine IS NULL) AND" & vbNewLine &
                    "	(JDT1.Account = @p5)" & vbNewLine &
                    "GROUP BY OACT.AcctName,JDT1.Account" & vbNewLine &
                    "ORDER BY JDT1.Account"

            cnx.SQLEXEC(dt, strSQL)

            If dt.Rows.Count > 0 Then
                dts.Tables("tbl_Extras").Rows(pos).Item("CuentaContCosto") = dt.Rows(0).Item("numero")
                txtMontoCuentaCosto.Tag = IIf(IsDBNull(dt.Rows(0).Item("total")), 0, dt.Rows(0).Item("total"))
                txtMontoCuentaCosto.Text = Format(txtMontoCuentaCosto.Tag, "#,##0.00")
                txtMontoCuentaCosto.TextAlign = HorizontalAlignment.Right
            Else
                dts.Tables("tbl_Extras").Rows(pos).Item("CuentaContCosto") = ""
                txtMontoCuentaCosto.Tag = 0
                txtMontoCuentaCosto.Text = Format(txtMontoCuentaCosto.Tag, "#,##0.00")
                txtMontoCuentaCosto.TextAlign = HorizontalAlignment.Right
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cargaCuentaCuetaPresu(ByVal p_empId As Integer)
        Try
            Dim dt As New DataTable
            Dim strSQL As String =
                    "DECLARE @p4 AS INT" & vbNewLine &
                    "DECLARE @P5 AS VARCHAR(15)" & vbNewLine &
                    "DECLARE @p6 AS INT" & vbNewLine &
                    "DECLARE @p7 AS INT" & vbNewLine &
                    "" & vbNewLine &
                    "SET @p6 = (SELECT dept FROM CRCC.DBO.OHEM AS OHEM WHERE (u_estado = 1) AND (empid = " & p_empId & "))" & vbNewLine &
                    "SET @p5=(SELECT NUMEROCUENTA COLLATE DATABASE_DEFAULT" & vbNewLine &
                    "		 FROM SCGPLACRCC.dbo.SCGPL_DETALLE_CTS_CONTABLES" & vbNewLine &
                    "		 WHERE CODTIPO = @p6 AND CONFIGURACION_DE = 1 AND CODESPECIFICACION = 2)" & vbNewLine &
                    "SET @p4=(SELECT MAX(AbsId) AS Escenario FROM CRCC.DBO.OBGS)" & vbNewLine &
                    "SET @p7=(SELECT MONTH(GETDATE()))" & vbNewLine &
                    "" & vbNewLine &
                    "SELECT T1.Line_ID as mes, t1.BudgId, T0.Instance, T0.AcctCode, T1.DebLTotal as debitos, T1.CredLTotal as creditos" & vbNewLine &
                    "FROM CRCC.DBO.OBGT AS T0 INNER JOIN" & vbNewLine &
                    "	CRCC.DBO.BGT1 T1 ON T0.AbsId = T1.BudgId INNER JOIN" & vbNewLine &
                    "	CRCC.DBO.OBGS T2 ON T0.Instance = T2.AbsId" & vbNewLine &
                    "WHERE (T0.Instance=@p4) AND (T0.AcctCode=@p5) AND (T1.Line_ID = @p7)"

            cnx.SQLEXEC(dt, strSQL)

            If dt.Rows.Count > 0 Then
                dts.Tables("tbl_Extras").Rows(pos).Item("CuentaContPresu") = dt.Rows(0).Item("acctcode")
                txtMontoPresupuesto.Tag = IIf(IsDBNull(dt.Rows(0).Item("debitos")), 0, dt.Rows(0).Item("debitos"))
                txtMontoPresupuesto.Text = Format(txtMontoPresupuesto.Tag, "#,##0.00")
                txtMontoPresupuesto.TextAlign = HorizontalAlignment.Right
            Else
                dts.Tables("tbl_Extras").Rows(pos).Item("CuentaContPresu") = ""
                txtMontoPresupuesto.Tag = 0
                txtMontoPresupuesto.Text = Format(txtMontoPresupuesto.Tag, "#,##0.00")
                txtMontoPresupuesto.TextAlign = HorizontalAlignment.Right
            End If
            dts.Tables.Remove("QTMP")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub creaBitacora()
        Try
            Dim detalle As String = IIf(nuevo, "DOCUMENTO CREADO CON ÉXITO", "MODIFICACION REALIZADA POR " & pNombreUser)
            Dim strSQL As String = "INSERT INTO tbl_extras_bitacora(nDocumento, nivel_estado, estado, detalle, fecha, computername, username)" & vbNewLine & _
                                    "VALUES (" & vbNewLine & _
                                    "     " & dts.Tables("tbl_Extras").Rows(pos).Item("nDocumento") & vbNewLine & _
                                    "   , " & dts.Tables("tbl_Extras").Rows(pos).Item("estatus_nivel") & vbNewLine & _
                                    "   ,'" & dts.Tables("tbl_Extras").Rows(pos).Item("estatus") & "'" & vbNewLine & _
                                    "   ,'" & detalle & "'" & vbNewLine & _
                                    "   , getDate()" & vbNewLine & _
                                    "   ,'" & Environment.MachineName.ToUpper.Trim & "'" & vbNewLine & _
                                    "   ,'" & Environment.UserName.ToUpper.Trim & "'" & vbNewLine & _
                                    "   )"

            cnx.SQLEXEC(strSQL)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

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
            Dim dt As New DataTable
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

    ' Esta funcion consulta y retorna true / false si la fecha es el dia libre de la persona
    Private Function esLibre(ByVal codigo As Integer, ByVal dia As String) As Boolean
        Try
            Dim dt As New DataTable
            cnx.SQLEXEC(dt, "SELECT subString(tbl_tipo_horario.dia_feriado,1,3) as Feriado, subString(tbl_tipo_horario.dia_feriado2,1,3) as Feriado2" & vbNewLine & _
                            "FROM tbl_horarioxEmpleado INNER JOIN tbl_tipo_horario ON tbl_horarioxEmpleado.id_horario = tbl_tipo_horario.id_horario" & vbNewLine & _
                            "WHERE (tbl_horarioxEmpleado.empID = " & codigo & ")")

            If dt.Rows.Count = 0 Then
                Return False
            End If

            Dim dr As DataRow = dt.Rows(0)
            If dr.Item("Feriado") = dia Then
                Return True
            ElseIf dr.Item("Feriado2") = dia Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Function

    Private Sub muestraJustAuto(ByVal ptexto As String, ByVal perror As Boolean)
        txtJustificacionAutomatica.ForeColor = IIf(perror, Color.Red, Color.Black)
    End Sub

    Private Function cargaMarca(ByVal pEmpID As Integer, ByVal pFecha As DateTime) As DataTable
        Try
            Dim dt As New DataTable()
            Dim strSQL As String = _
                "SELECT entrada, salida, id_horario, id_horario_sale" & vbNewLine & _
                "FROM tbl_marcas" & vbNewLine & _
                "WHERE (RTRIM(LTRIM(codigo)) = '" & pEmpID & "') AND" & vbNewLine & _
                "	(timeStamp BETWEEN CONVERT(datetime, '" & pFecha & "', 103) AND" & vbNewLine & _
                "					   CONVERT(datetime, '" & pFecha & " 23:59:59', 103))" & vbNewLine & _
                "ORDER BY timeStamp"
            cnx.SQLEXEC(dt, strSQL)

            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return Nothing
        End Try
    End Function

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        ' metodo para realizar una busqueda
        ' "pnt" es una instancia el la forma "frmBuscarx"
        ' "result" es una variable de tipo DataRowView que se utiliza para cargar el resultado de la busqueda
        Dim pnt As New frmBuscarx()
        Dim result As DataRowView = Nothing

        ' la forma "frmBuscarx" tiene varias propiedades que se configuran todas las veces que se vaya a utilizar
        ' "Text" -> es el titulo de la pantalla de busqueda
        ' "strTabla" -> un nombre de tabla o consulta para cargar los datos 
        ' "strConsulta" -> es la consulta o el texto en SQL para cargar los datos
        pnt.Text = "BUSQUEDA DE COLABORADOR"
        pnt.strTabla = "tbl_Busqueda"
        pnt.strConsulta = _
                "SELECT E.empID, E.middleName + ' ' + E.lastName + ' ' + E.firstName AS nombre," & vbNewLine & _
                "	E.SalarioHora, D.id_departamento, D.detalle as departamento, S.id_Seccion," & vbNewLine & _
                "	S.detalle AS seccion" & vbNewLine & _
                "FROM tbl_empleados_sap AS E INNER JOIN tbl_secciones AS S ON E.id_seccion = S.id_Seccion" & vbNewLine & _
                "	INNER JOIN tbl_departamentos AS D ON E.id_departamento = D.id_departamento" & vbNewLine & _
                "WHERE (E.activo = 1) " & IIf(verTodos, "", "AND (" & IIf(pEsGerente, "E.empid_gerente", "E.empid_jefe") & " = " & pempID & ")") & vbNewLine & _
                "ORDER BY departamento, seccion, nombre"
        pnt.strCamposMostrar = "empID,nombre,departamento,seccion"

        ' la forma de busqueda se comporta como un messagebox y por esta razon se trabaja con DialogResult
        ' si la forma retorna un "DialogResult.Yes" entonces se carga un resultado en la variable "result"
        ' para despues utilizarlo, sino se sale del metodo.
        If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
            result = CType(pnt.result, DataRowView)
        End If
        pnt.Close()

        If IsNothing(result) Then
            Exit Sub
        End If

        dts.Tables("tbl_Extras").Rows(pos).Item("empid") = result.Item("empid")
        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_empleado") = result.Item("nombre")
        dts.Tables("tbl_Extras").Rows(pos).Item("id_departamento") = result.Item("id_departamento")
        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_departamento") = result.Item("departamento")
        dts.Tables("tbl_Extras").Rows(pos).Item("id_seccion") = result.Item("id_seccion")
        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_seccion") = result.Item("seccion")
        dts.Tables("tbl_Extras").Rows(pos).Item("salario_hora") = result.Item("salariohora")
        cargaCuentaCuetaCosto(dts.Tables("tbl_Extras").Rows(pos).Item("empid"))
        cargaCuentaCuetaPresu(dts.Tables("tbl_Extras").Rows(pos).Item("empid"))
        cargaMontoPendiendes(dts.Tables("tbl_Extras").Rows(pos).Item("empid"))
        totaliza()
    End Sub

    Private Sub cargaJustAuto()

        Dim cantHoras As Double = dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_sencillas") + _
                                    (dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_tmedio") * 1.5) + _
                                    (dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_dobles") * 2) + _
                                     dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_feriado")

        Dim cantHorasEva As Double = dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_sencillas") + _
                                            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_tmedio") + _
                                            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_dobles") + _
                                            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_feriado")

        Dim sumaDif As Double = dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_entrada") + _
                                    dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_Salida")

        dts.Tables("tbl_Extras").Rows(pos).Item("Monto_Total") = cantHoras * dts.Tables("tbl_Extras").Rows(pos).Item("salario_hora")



        If cantHorasEva = 0 Then
            dts.Tables("tbl_Extras").Rows(pos).Item("justificacion_automatica") = ""
        ElseIf cantHorasEva <= sumaDif Then
            dts.Tables("tbl_Extras").Rows(pos).Item("justificacion_automatica") = "Horas extra coinciden con marca"
            muestraJustAuto("Horas extra coinciden con marca", False)
        Else
            dts.Tables("tbl_Extras").Rows(pos).Item("justificacion_automatica") = "-NO- HAY COINCIDENCIA ENTRE MARCAS"
            muestraJustAuto("-NO- HAY COINCIDENCIA ENTRE MARCAS", True)
        End If
        dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()
    End Sub

    Private Function guardar(ByVal pNuevo As Boolean) As Boolean
        Try
            dts.Tables("tbl_Extras").Rows(pos).EndEdit()
            dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()
            Dim strSQL As String
            If pNuevo Then
                strSQL = _
                        "DECLARE @consec As numeric(18,0)" & vbNewLine & _
                        "UPDATE tbl_parametros SET ConsecutivoExtras=ConsecutivoExtras+1" & vbNewLine & _
                        "SET @consec = (SELECT ConsecutivoExtras FROM tbl_parametros)" & vbNewLine & _
                        "" & vbNewLine & _
                        "INSERT INTO tbl_Extras(" & vbNewLine & _
                        "	nDocumento, empID, nombre_empleado, id_Departamento, nombre_departamento, id_Seccion," & vbNewLine & _
                        "	nombre_seccion, Salario_Hora, Fecha, marca_entrada, horario_entrada, diferencia_entrada," & vbNewLine & _
                        "	marca_salida, horario_salida, diferencia_salida, estado_marca, cantidad_horas_sencillas," & vbNewLine & _
                        "	cantidad_horas_tmedio, cantidad_horas_dobles, cantidad_horas_feriado, Monto_Total," & vbNewLine & _
                        "	justificacion_automatica, estatus, estatus_nivel, Motivo, CuentaContCosto, CuentaContPresu," & vbNewLine & _
                        "	empid_jefe, nombre_jefe, fecha_aplica_jefe, Id_Uduario, UserName, ComputerName)" & vbNewLine & _
                        "VALUES(" & vbNewLine & _
                        "	 @consec" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("empid") & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("nombre_empleado") & "'" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("id_departamento") & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("nombre_departamento") & "'" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("id_seccion") & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("nombre_seccion") & "'" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("salario_hora") & vbNewLine & _
                        "" & _
                        "	,CONVERT(DATETIME,'" & Format(dts.Tables("tbl_Extras").Rows(pos).Item("fecha"), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	,CONVERT(DATETIME,'" & Format(IIf(IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	,CONVERT(DATETIME,'" & Format(IIf(IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("horario_Entrada")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("horario_Entrada")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_entrada") & vbNewLine & _
                        "	,CONVERT(DATETIME,'" & Format(IIf(IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	,CONVERT(DATETIME,'" & Format(IIf(IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("horario_salida")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("horario_salida")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_Salida") & vbNewLine & _
                        "" & _
                        "	,'" & estadoMarca & "'" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_sencillas") & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_tmedio") & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_dobles") & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_feriado") & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("Monto_Total") & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("justificacion_automatica") & "'" & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("estatus") & "'" & vbNewLine & _
                        "	," & dts.Tables("tbl_Extras").Rows(pos).Item("estatus_nivel") & vbNewLine & _
                        "	,'" & txtMotivo.Text & "'" & vbNewLine & _
                        "	,'" & txtCuentaCosto.Text & "'" & vbNewLine & _
                        "	,'" & txtCuentaPresupuesto.Text & "'" & vbNewLine & _
                        "	," & pempID & vbNewLine & _
                        "	,'" & pNombreUser & "'" & vbNewLine & _
                        "	,GETDATE()" & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("Id_Uduario") & "'" & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("UserName") & "'" & vbNewLine & _
                        "	,'" & dts.Tables("tbl_Extras").Rows(pos).Item("ComputerName") & "'" & vbNewLine & _
                        ")"
            Else
                strSQL = _
                        "UPDATE tbl_Extras SET" & vbNewLine & _
                        "	  empID = " & dts.Tables("tbl_Extras").Rows(pos).Item("empid") & vbNewLine & _
                        "	, nombre_empleado = '" & dts.Tables("tbl_Extras").Rows(pos).Item("nombre_empleado") & "'" & vbNewLine & _
                        "	, id_Departamento = " & dts.Tables("tbl_Extras").Rows(pos).Item("id_departamento") & vbNewLine & _
                        "	, nombre_departamento = '" & dts.Tables("tbl_Extras").Rows(pos).Item("nombre_departamento") & "'" & vbNewLine & _
                        "	, id_Seccion = " & dts.Tables("tbl_Extras").Rows(pos).Item("id_seccion") & vbNewLine & _
                        "	, nombre_seccion = '" & dts.Tables("tbl_Extras").Rows(pos).Item("nombre_seccion") & "'" & vbNewLine & _
                        "	, Salario_Hora = " & dts.Tables("tbl_Extras").Rows(pos).Item("salario_hora") & vbNewLine & _
                        "" & _
                        "	, Fecha = CONVERT(DATETIME,'" & Format(dts.Tables("tbl_Extras").Rows(pos).Item("fecha"), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	, marca_entrada = CONVERT(DATETIME,'" & Format(IIf(IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	, horario_entrada = CONVERT(DATETIME,'" & Format(IIf(IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("horario_Entrada")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("horario_Entrada")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	, diferencia_entrada = " & dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_entrada") & vbNewLine & _
                        "	, marca_salida = CONVERT(DATETIME,'" & Format(IIf(IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	, horario_salida = CONVERT(DATETIME,'" & Format(IIf(IsNothing(dts.Tables("tbl_Extras").Rows(pos).Item("horario_salida")), Nothing, dts.Tables("tbl_Extras").Rows(pos).Item("horario_salida")), "dd/MM/yyyy HH:mm") & "',103)" & vbNewLine & _
                        "	, diferencia_salida = " & dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_Salida") & vbNewLine & _
                        "" & _
                        "	, estado_marca = '" & estadoMarca & "'" & vbNewLine & _
                        "	, cantidad_horas_sencillas = " & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_sencillas") & vbNewLine & _
                        "	, cantidad_horas_tmedio = " & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_tmedio") & vbNewLine & _
                        "	, cantidad_horas_dobles = " & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_dobles") & vbNewLine & _
                        "	, cantidad_horas_feriado = " & dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_feriado") & vbNewLine & _
                        "	, Monto_Total = " & dts.Tables("tbl_Extras").Rows(pos).Item("Monto_Total") & vbNewLine & _
                        "	, justificacion_automatica = '" & dts.Tables("tbl_Extras").Rows(pos).Item("justificacion_automatica") & "'" & vbNewLine & _
                        "	, estatus = '" & dts.Tables("tbl_Extras").Rows(pos).Item("estatus") & "'" & vbNewLine & _
                        "	, estatus_nivel = " & dts.Tables("tbl_Extras").Rows(pos).Item("estatus_nivel") & vbNewLine & _
                        "	, Motivo = '" & txtMotivo.Text & "'" & vbNewLine & _
                        "   , CuentaContCosto = '" & txtCuentaCosto.Text & "'" & vbNewLine & _
                        "   , CuentaContPresu = '" & txtCuentaPresupuesto.Text & "'" & vbNewLine & _
                        "WHERE (id_linea = " & idLinea & ")"
            End If

            cnx.SQLEXEC(strSQL)

            strSQL = _
                "SELECT id_linea, nDocumento, empID, nombre_empleado, id_Departamento, nombre_departamento," & vbNewLine & _
                "	id_Seccion, nombre_seccion, Salario_Hora, Fecha, marca_entrada, horario_entrada," & vbNewLine & _
                "	marca_salida, horario_salida, diferencia_entrada, diferencia_salida, estado_marca, cantidad_horas_sencillas," & vbNewLine & _
                "	cantidad_horas_tmedio, cantidad_horas_dobles, cantidad_horas_feriado, Monto_Total," & vbNewLine & _
                "	justificacion_automatica, estatus, estatus_nivel, Motivo, CuentaContCosto, CuentaContPresu," & vbNewLine & _
                "	empid_jefe, nombre_jefe, fecha_aplica_jefe, empID_gerente, nombre_gerente, fecha_aplica_gerente," & vbNewLine & _
                "	empID_rh, nombre_rh, fecha_aplica_rh, fecha_aplica_plani, numero_pago, fecha_cierre, Id_Uduario," & vbNewLine & _
                "	ComputerName, UserName, time_stamp" & vbNewLine & _
                "FROM tbl_Extras" & vbNewLine & _
                "WHERE (estatus_nivel = 0)" & IIf(verTodos, "", " AND (empID in (select empid from tbl_empleados_sap as E where " & IIf(pEsGerente, "E.empid_gerente", "E.empid_jefe") & " = " & pempID & "))") & vbNewLine & _
                "ORDER BY nombre_departamento, nombre_seccion, empID"


            dts.Tables("tbl_extras").Rows.Clear()
            cnx.SQLEXEC(dts, strSQL, "tbl_Extras")
            BindingContext(dts, "tbl_extras").Position = pos

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Return False
        End Try
    End Function

    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        If txtEmpid.Text = "" Or IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("empid")) Then
            MessageBox.Show("Debe seleccionar un colaborador para continuar con el proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            DesActivaCantHoras(False)
            Exit Sub
        End If

        If Not verificaFecha(dts.Tables("tbl_Extras").Rows(pos).Item("empid"), dtFecha.Value.Date) And nuevo Then
            MessageBox.Show("Ya existe un registro para el colaborador '" & dts.Tables("tbl_Extras").Rows(pos).Item("nombre_empleado") & "', en la fecha seleccionada." & vbNewLine & _
                            "Verifique los datos y vuelva a intentar de nuevo.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            DesActivaCantHoras(False)
            Exit Sub
        End If

        If dtFecha.Value.Date >= Now.Date Then
            MessageBox.Show("La fecha no puede ser mayor o igual a la fecha de hoy.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            DesActivaCantHoras(False)
            Exit Sub
        End If

        Dim dt As New DataTable()
        dt = cargaMarca(txtEmpid.Text, dtFecha.Value.Date)
        If dt.Rows.Count = 1 Then
            BindingContext(dts, "tbl_extras").Position = pos
            dts.Tables("tbl_Extras").Rows(pos).Item("marca_entrada") = dt.Rows(0).Item("entrada")
            txtMarcaEntrada.Tag = IIf(IsDBNull(dt.Rows(0).Item("id_horario")), 0, dt.Rows(0).Item("id_horario"))
            dts.Tables("tbl_Extras").Rows(pos).Item("marca_salida") = dt.Rows(0).Item("salida")
            txtMarcaSalida.Tag = IIf(IsDBNull(dt.Rows(0).Item("id_horario_sale")), 0, dt.Rows(0).Item("id_horario_sale"))
            dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()

            horarioEntrada = cargaHorarios(txtMarcaEntrada.Tag, txtMarcaSalida.Tag, dtFecha.Value.Date, True)
            dts.Tables("tbl_Extras").Rows(pos).Item("horario_Entrada") = horarioEntrada
            If IsNothing(horarioEntrada) Or IsDBNull(txtMarcaEntrada.Text) Or txtMarcaEntrada.Text = "" Then
                diferenciaEntrada = 0
            Else
                diferenciaEntrada = calculaHoras(CDate(txtMarcaEntrada.Text), CDate(horarioEntrada))
            End If

            dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_entrada") = diferenciaEntrada

            horarioSalida = cargaHorarios(txtMarcaEntrada.Tag, txtMarcaSalida.Tag, dtFecha.Value.Date, False)
            dts.Tables("tbl_Extras").Rows(pos).Item("horario_Salida") = horarioSalida
            If IsNothing(horarioSalida) Or IsDBNull(txtMarcaSalida.Text) Or txtMarcaSalida.Text = "" Then
                diferenciaSalida = 0
            Else
                diferenciaSalida = calculaHoras(CDate(horarioSalida), CDate(txtMarcaSalida.Text))
            End If

            dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_Salida") = diferenciaSalida
            'dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()
            txtHorasSencillas.Focus()
        Else
            dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_entrada") = 0
            dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_Salida") = 0
            dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()

            txtHorasSencillas.Focus()
        End If

        lblEstadoMarca.Text = evalMarca()
        lblEstadoMarca.ForeColor = IIf(lblEstadoMarca.Text.Contains("err"), Color.Red, Color.Black)
        lblEstadoMarca.Visible = True
        DesActivaCantHoras(True)
    End Sub

    Private Sub txtMotivo_GotFocus(sender As Object, e As System.EventArgs) Handles txtMotivo.GotFocus
        cargaJustAuto()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        TabControl1.SelectedIndex = 1
        TabControl1.SelectedIndex = 0
        txtMotivo.Focus()
        dts.Tables("tbl_Extras").Rows(pos).Item("estatus") = "PENDIENTE DE APROBACIÓN JEFATURA"
        dts.Tables("tbl_Extras").Rows(pos).Item("estatus_nivel") = 0
        dts.Tables("tbl_Extras").Rows(pos).Item("Id_Uduario") = pempID
        dts.Tables("tbl_Extras").Rows(pos).Item("UserName") = Environment.UserName.ToUpper.Trim
        dts.Tables("tbl_Extras").Rows(pos).Item("ComputerName") = Environment.MachineName.ToUpper.Trim
        dts.Tables("tbl_Extras").Rows(pos).Item("cuentacontcosto") = txtCuentaCosto.Text
        dts.Tables("tbl_Extras").Rows(pos).Item("cuentacontpresu") = txtCuentaPresupuesto.Text
        dts.Tables("tbl_Extras").Rows(pos).Item("motivo") = txtMotivo.Text
        dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()

        If Not validaCamposDigitados() Then
            MessageBox.Show("Los datos no se guardaron por que fatan campos por llenar.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        If guardar(nuevo) Then
            MessageBox.Show("Datos guadados con éxito", "GUARDAR DATOS !!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            creaBitacora()
            Close()
        End If
    End Sub

    Private Sub btnDescartar_Click(sender As System.Object, e As System.EventArgs) Handles btnDescartar.Click
        Try
            If nuevo Then
                Dim strSQL As String = _
                    "SELECT id_linea, nDocumento, empID, nombre_empleado, id_Departamento, nombre_departamento," & vbNewLine & _
                    "	id_Seccion, nombre_seccion, Salario_Hora, Fecha, marca_entrada, horario_entrada," & vbNewLine & _
                    "	marca_salida, horario_salida, diferencia_entrada, diferencia_salida, estado_marca, cantidad_horas_sencillas," & vbNewLine & _
                    "	cantidad_horas_tmedio, cantidad_horas_dobles, cantidad_horas_feriado, Monto_Total," & vbNewLine & _
                    "	justificacion_automatica, estatus, estatus_nivel, Motivo, CuentaContCosto, CuentaContPresu," & vbNewLine & _
                    "	empid_jefe, nombre_jefe, fecha_aplica_jefe, empID_gerente, nombre_gerente, fecha_aplica_gerente," & vbNewLine & _
                    "	empID_rh, nombre_rh, fecha_aplica_rh, fecha_aplica_plani, numero_pago, fecha_cierre, Id_Uduario," & vbNewLine & _
                    "	ComputerName, UserName, time_stamp" & vbNewLine & _
                    "FROM tbl_Extras" & vbNewLine & _
                    "WHERE (estatus_nivel = 0)" & IIf(verTodos, "", " AND (empID in (select empid from view_sl_empleados as E where " & IIf(pEsGerente, "E.gerente", "E.jefe") & " = " & pempID & "))")


                dts.Tables("tbl_extras").Rows.Clear()
                cnx.SQLEXEC(dts, strSQL, "tbl_Extras")

                BindingContext(dts, "tbl_extras").Position = pos - 1
            End If
            Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub


    Private Sub frmRegistroExtrasDetalle_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If dts.Tables.Contains("tbl_bitacoraDoc") Then
            dts.Tables.Remove("tbl_bitacoraDoc")
        End If
        pnt.Enabled = True
    End Sub

    Private Sub frmRegistroExtrasDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not nuevo Then
            idLinea = dts.Tables("tbl_Extras").Rows(pos).Item("id_linea")
        Else
            BindingContext(dts, "tbl_extras").Position = pos
        End If

        pnt.Enabled = False

        txtNDocumento.DataBindings.Add("text", dts, "tbl_Extras.nDocumento")

        txtEmpid.DataBindings.Add("text", dts, "tbl_Extras.empid")
        txtNombre.DataBindings.Add("text", dts, "tbl_Extras.nombre_empleado")

        dtFecha.DataBindings.Add("text", dts, "tbl_Extras.fecha", True)

        txtDepartamento.DataBindings.Add("text", dts, "tbl_Extras.nombre_departamento")
        txtDepartamento.DataBindings.Add("tag", dts, "tbl_Extras.id_departamento")

        txtSeccion.DataBindings.Add("text", dts, "tbl_Extras.nombre_seccion")
        txtSeccion.DataBindings.Add("tag", dts, "tbl_Extras.id_seccion")

        txtSalarioHora.DataBindings.Add("text", dts, "tbl_Extras.salario_hora")

        txtMarcaEntrada.DataBindings.Add("text", dts, "tbl_Extras.marca_entrada", True)
        txtHorEntra.DataBindings.Add("text", dts, "tbl_Extras.horario_Entrada", True)
        txtDifEntra.DataBindings.Add("text", dts, "tbl_Extras.diferencia_entrada")
        txtMarcaSalida.DataBindings.Add("text", dts, "tbl_Extras.marca_salida", True)
        txtHorSale.DataBindings.Add("text", dts, "tbl_Extras.horario_salida", True)
        txtDifSale.DataBindings.Add("text", dts, "tbl_Extras.diferencia_salida")

        txtHorasSencillas.DataBindings.Add("text", dts, "tbl_Extras.cantidad_horas_sencillas")
        txtHorasTiempoyMedio.DataBindings.Add("text", dts, "tbl_Extras.cantidad_horas_tmedio")
        txtHorasDobles.DataBindings.Add("text", dts, "tbl_Extras.cantidad_horas_dobles")
        txtHorasFeriado.DataBindings.Add("text", dts, "tbl_Extras.cantidad_horas_feriado")
        txtMontoHoras.DataBindings.Add("text", dts, "tbl_Extras.Monto_Total")
        txtJustificacionAutomatica.DataBindings.Add("text", dts, "tbl_Extras.justificacion_automatica")

        txtRechGere.DataBindings.Add("text", dts, "tbl_Extras.motivo_rechazo_gerente")
        txtRechRRHH.DataBindings.Add("text", dts, "tbl_Extras.motivo_rechazo_rh")
        txtRechPlani.DataBindings.Add("text", dts, "tbl_Extras.motivo_rechazo_planilla")

        txtCuentaCosto.DataBindings.Add("text", dts, "tbl_Extras.cuentacontcosto")
        txtCuentaPresupuesto.DataBindings.Add("text", dts, "tbl_Extras.cuentacontpresu")

        txtMotivo.DataBindings.Add("text", dts, "tbl_Extras.motivo")
        txtEstatus.DataBindings.Add("text", dts, "tbl_Extras.estatus")
        DesActivaCantHoras(False)

        btnBuscar.Focus()
    End Sub

    Private Sub lblHistoria_Click(sender As System.Object, e As System.EventArgs) Handles lblHistoria.Click
        Dim obj As New frmRegistroExtrasBitacoraDoc()
        obj.ndoc = dts.Tables("tbl_Extras").Rows(pos).Item("ndocumento")
        obj.pnt = Me
        obj.Text = "BITACORA DE DOCUMENTO [" & obj.ndoc.ToString.Trim & "]"
        obj._titulo1._text = "BITACORA DE DOCUMENTO [" & obj.ndoc.ToString.Trim & "]"
        obj.Show()
    End Sub

End Class