Public Class frmRegistroExtrasAprobacionRRHHDetalle

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

        If IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("motivo")) Then
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
    End Sub

    Private Function verificaFecha(ByVal p_empid As Integer, p_fecha As Date) As Boolean
        Try
            Dim dt As New DataTable
            Dim cant As Integer = 0
            Dim strSQL As String = _
                "SELECT COUNT(*) AS cant FROM" & vbNewLine & _
                "(	SELECT empid, fecha FROM tbl_extras" & vbNewLine & _
                "	WHERE (empid = " & p_empid & ") AND (fecha = CONVERT(DATETIME,'" & Format(p_fecha, "dd/MM/yyyy") & "',103)))" & vbNewLine & _
                "	UNION ALL" & vbNewLine & _
                "	SELECT empid, fecha FROM tbl_extras_hist" & vbNewLine & _
                "	WHERE (RTRIM(LTRIM(justificacion_automatica))<>'ANULADA') AND" & vbNewLine & _
                "		(empid = " & p_empid & ") AND (fecha = CONVERT(DATETIME,'" & Format(p_fecha, "dd/MM/yyyy") & "',103)))" & vbNewLine & _
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
            txtMontoPendiente.Tag = IIf(IsDBNull(dt.Rows(0).Item("pendiente")), 0.0, dt.Rows(0).Item("pendiente"))
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub muestraJustAuto(ByVal ptexto As String, ByVal perror As Boolean)
        txtJustificacionAutomatica.ForeColor = IIf(perror, Color.Red, Color.Black)
    End Sub

    Private Sub cargaJustAuto()

        Dim cantHorasEva As Double = dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_sencillas") + _
                                            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_tmedio") + _
                                            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_dobles") + _
                                            dts.Tables("tbl_Extras").Rows(pos).Item("cantidad_horas_feriado")

        Dim sumaDif As Double = dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_entrada") + _
                                    dts.Tables("tbl_Extras").Rows(pos).Item("diferencia_Salida")

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
        dts.Tables("tbl_Extras").Rows(pos).EndEdit()
        dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()

        BindingContext(dts, "tbl_extras").Position = pos
        Return True

    End Function

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        txtJustificacionAutomatica.Focus()
        txtMotivoRechazo.Focus()

        dts.Tables("tbl_Extras").Rows(pos).Item("aprobado") = True
        dts.Tables("tbl_Extras").Rows(pos).Item("rechazado") = False
        dts.Tables("tbl_Extras").Rows(pos).Item("estatus") = "PENDIENTE DE APROBACIÓN PLANILLA"
        dts.Tables("tbl_Extras").Rows(pos).Item("estatus_nivel") = 3
        dts.Tables("tbl_Extras").Rows(pos).Item("empid_rh") = pempID
        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_rh") = pNombreUser
        dts.Tables("tbl_Extras").Rows(pos).Item("fecha_aplica_rh") = Now
        dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()
        Close()
    End Sub

    Private Sub btnRechazar_Click(sender As System.Object, e As System.EventArgs) Handles btnRechazar.Click

        txtJustificacionAutomatica.Focus()
        txtMotivoRechazo.Focus()

        If txtMotivoRechazo.Text = "" Or IsDBNull(dts.Tables("tbl_Extras").Rows(pos).Item("fecha_aplica_gerente")) Then
            MessageBox.Show("Debe especificar un motivo para realizar el proceso de rechazo de este movimiento.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        dts.Tables("tbl_Extras").Rows(pos).Item("aprobado") = False
        dts.Tables("tbl_Extras").Rows(pos).Item("rechazado") = True
        dts.Tables("tbl_Extras").Rows(pos).Item("estatus") = "PENDIENTE DE APROBACIÓN GERENCIA"
        dts.Tables("tbl_Extras").Rows(pos).Item("estatus_nivel") = 0
        dts.Tables("tbl_Extras").Rows(pos).Item("empid_rh") = pempID
        dts.Tables("tbl_Extras").Rows(pos).Item("nombre_rh") = pNombreUser
        dts.Tables("tbl_Extras").Rows(pos).Item("fecha_aplica_rh") = Now
        dts.Tables("tbl_Extras").Rows(pos).Item("motivo_rechazo_rh") = txtMotivoRechazo.Text
        dts.Tables("tbl_Extras").Rows(pos).AcceptChanges()


        Close()

    End Sub

    Private Sub btnDescartar_Click(sender As System.Object, e As System.EventArgs) Handles btnDescartar.Click
        Close()
    End Sub

    Private Sub frmRegistroExtrasAprobacionRRHHDetalle_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
    End Sub

    Private Sub frmRegistroExtrasAprobacionRRHHDetalle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If Not nuevo Then
            idLinea = dts.Tables("tbl_Extras").Rows(pos).Item("id_linea")
        Else
            BindingContext(dts, "tbl_extras").Position = pos
        End If

        pnt.Enabled = False

        txtNDocumento.DataBindings.Add("text", dts, "tbl_Extras.nDocumento")

        txtEmpid.DataBindings.Add("text", dts, "tbl_Extras.empid")
        txtNombre.DataBindings.Add("text", dts, "tbl_Extras.nombre_empleado")

        dtFecha.DataBindings.Add("text", dts, "tbl_Extras.fecha")

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

        txtCuentaCosto.DataBindings.Add("text", dts, "tbl_Extras.cuentacontcosto")
        txtCuentaPresupuesto.DataBindings.Add("text", dts, "tbl_Extras.cuentacontpresu")

        txtMotivo.DataBindings.Add("text", dts, "tbl_Extras.motivo")
        txtMotivoRechazo.DataBindings.Add("text", dts, "tbl_Extras.motivo_rechazo_rh")
        txtEstatus.DataBindings.Add("text", dts, "tbl_Extras.estatus")

        txtRechGere.DataBindings.Add("text", dts, "tbl_Extras.motivo_rechazo_gerente")
        txtRechRRHH.DataBindings.Add("text", dts, "tbl_Extras.motivo_rechazo_rh")
        txtRechPlani.DataBindings.Add("text", dts, "tbl_Extras.motivo_rechazo_planilla")

        DesActivaCantHoras(False)
        cargaCuentaCuetaCosto(dts.Tables("tbl_Extras").Rows(pos).Item("empid"))
        cargaCuentaCuetaPresu(dts.Tables("tbl_Extras").Rows(pos).Item("empid"))
        cargaMontoPendiendes(dts.Tables("tbl_Extras").Rows(pos).Item("empid"))
        cargaJustAuto()
        totaliza()
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