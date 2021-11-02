
Imports System.Windows.Forms

Delegate Sub FunctionCall(ByVal param)
Public Class frmInicio
    Dim dts As New DataSet()

    Private Function aplicaPermiso(ByRef item As String) As Boolean
        If dts.Tables("Tbl_permisos").Rows.Count = 0 Then
            Return False
        Else
            Dim strItem As String = Replace(item, "&", "", 1, item.Length)
            Dim dr As DataRow()
            dr = dts.Tables("Tbl_permisos").Select("item = '" & strItem.Trim & "'")

            If IsNothing(dr) Then
                Return False
            End If

            If dr.Length = 0 Then
                Return False
            End If

            If dr.Length > 0 Then
                Return True
            End If
        End If
    End Function

    '*********************************************************************************************************************
    Private Sub RecorrerEstructuraMenu(ByRef oMenu As MenuStrip)
        For Each oOpcionMenu As ToolStripMenuItem In oMenu.Items
            oOpcionMenu.Visible = aplicaPermiso(oOpcionMenu.Text)
            If oOpcionMenu.DropDownItems.Count > 0 Then
                RecorrerSubmenu(oOpcionMenu.DropDownItems)
            End If
        Next
    End Sub

    Private Sub RecorrerSubmenu(ByRef oSubmenuItems As ToolStripItemCollection)
        For Each oSubitem As ToolStripItem In oSubmenuItems
            If oSubitem.GetType Is GetType(ToolStripMenuItem) Then
                oSubitem.Visible = aplicaPermiso(oSubitem.Text)
                If CType(oSubitem, ToolStripMenuItem).DropDownItems.Count > 0 Then
                    RecorrerSubmenu(CType(oSubitem, ToolStripMenuItem).DropDownItems)
                End If
            End If
        Next
    End Sub
    '*********************************************************************************************************************

    Public Sub cargaPermisos(ByRef empID As Integer)
        Try
            cnx.SQLEXEC(dts, "SELECT * FROM tbl_control_asistencia_usuarios WHERE (empID = " & empID & ")", "tbl_control_asistencia_usuarios")

            cnx.SQLEXEC(dts, "SELECT tbl_control_asistencia_permisos.id_item, tbl_control_asistencia_lista_permisos.Item" & vbNewLine & _
                              "FROM tbl_control_asistencia_permisos INNER JOIN tbl_control_asistencia_lista_permisos ON" & vbNewLine & _
                              "     tbl_control_asistencia_lista_permisos.id_Item = tbl_control_asistencia_permisos.id_item" & vbNewLine & _
                              "WHERE (tbl_control_asistencia_permisos.empid =  " & empID & ")", "tbl_permisos")

            ToolStripStatusUsuario.Text = " " & dts.Tables("tbl_control_asistencia_usuarios").Rows(0).Item("Nombre") & _
                                            Space(10) & "USUARIO: " & dts.Tables("tbl_control_asistencia_usuarios").Rows(0).Item("usuario") & _
                                            Space(10) & "SESION INICIADA: " & Now.ToString
            verTodos = dts.Tables("tbl_control_asistencia_usuarios").Rows(0).Item("verTodos")
            RecorrerEstructuraMenu(MenuStrip)
            'cargaItemPadre()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Public Sub cargaforma(ByVal pantallas As Object)
        Dim obj As Object = CType(pantallas, Form)
        obj.MdiParent = Me
        obj.StartPosition = FormStartPosition.CenterScreen
        obj.Show()
    End Sub

    Private Sub CerrarSesionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                                                    SalirToolStripMenuItem.Click, _
                                                    CerrarSesionToolStripMenuItem.Click, _
                                                    CabioClaveToolStripMenuItem.Click, _
                                                    MantenimientoDeUsuariosToolStripMenuItem.Click, _
                                                    DefinicionDePermisosToolStripMenuItem.Click, _
                                                    MantenimientoDeJefesDeSecciónToolStripMenuItem.Click, _
                                                    AsinaciónDeHorariosToolStripMenuItem.Click, _
                                                    MantenimientoDeTiposHorarioToolStripMenuItem.Click, _
                                                    CierreToolStripMenuItem1.Click, _
                                                    JustificaciónDeMarcasToolStripMenuItem.Click, _
                                                    JustificacionesHistóricasToolStripMenuItem1.Click, _
                                                    PreJustificacionesToolStripMenuItem1.Click, _
                                                    ReporteDeMarcasToolStripMenuItem1.Click, _
                                                    MarcasDelDíaToolStripMenuItem1.Click, _
                                                    PreJustificacionesToolStripMenuItem1.Click, _
                                                    ConsultaDePersonalSinHorarioToolStripMenuItem.Click, _
                                                    GenerarCargadorToolStripMenuItem1.Click, _
                                                    RegistroDeExtrasToolStripMenuItem.Click, _
                                                    EnviarExtrasAAprobaciónDeGerenteToolStripMenuItem.Click, _
                                                    EnviarExtrasAlHistóricoToolStripMenuItem.Click


        Dim obj As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        Select Case obj.Text
            Case "&Salir"
                End
            Case "Cerrar sesión"
                MenuStrip.Visible = False
                ToolStripLogin.Visible = True
                ToolStripStatusUsuario.Text = ""
                dts.Tables.Clear()
            Case "Registro de extras"
                cargaforma(frmRegistroExtras)
            Case "Justificación de Marcas"
                cargaforma(frmConsultaMarcas_new)
            Case "Justificaciones históricas"
                cargaforma(frmConsultaMarcasHist_new)
                'Case "Pre-Justificaciones"
                ' no utilizar ***** la forma esta en la carpeta del proyecto pero esta excluida
                'cargaforma(frmPreJustificacion)
            Case "Vacaciones"
                cargaforma(FrmConsultaVacaciones)
            Case "Cambio de clave"
                cargaforma(FrmCambioCalve)
            Case "Mantenimiento de usuarios"
                cargaforma(FrmMantenimientoUsuarios)
            Case "Definición de permisos"
                cargaforma(frmPermisos)
            Case "Mantenimiento de jefes de sección"
                cargaforma(FrmMantenimientoJefesSecciones)
            Case "Mantenimiento de tipos horario"
                cargaforma(FrmMantenimentotipohorario)
            Case "Asignación de horarios"
                cargaforma(FrmMantenimientoEmpleadosHorarios)
            Case "Generar cargador"
                cargaforma(frmRebajosCarga)
            Case "Reporte de marcas"
                cargaforma(FrmReporteMarcas)
            Case "Enviar marcas al histórico"
                cargaforma(frmMarcasalHist)
            Case "Consulta de personal sin horario"
                cargaforma(frmConsultaSinHorario)
            Case "Marcas del día"
                cargaforma(frmConsultaMarcasDia)
            Case "Enviar extras a aprobación de gerente"
                cargaforma(frmRegistroExtrasEnvio)
            Case "Enviar extras al histórico"
                cargaforma(frmRegistroExtras_al_hist)
        End Select

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabelFecha.Text = Now().ToLongDateString & " - " & Now().ToLongTimeString
    End Sub

    Private Sub frmInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ToolStripStatusLabelEquipo.Text = "Equipo: " & Environment.MachineName
        MenuStrip.Visible = False
        Timer1.Start()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click, btnSalir.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Select Case obj.Text
            Case "&Login"
                cargaforma(frmLogin)
            Case "&Salir"
                End
        End Select
    End Sub

    Private Sub AprobacionRechazoDeExtrasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AprobacionRechazoDeExtrasToolStripMenuItem.Click
        cargaforma(frmRegistroExtrasAprobacionGerente)
    End Sub

    Private Sub AprobaciónRechazoDeExtrasToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AprobaciónRechazoDeExtrasToolStripMenuItem.Click
        cargaforma(frmRegistroExtrasAprobacionRRHH)
    End Sub

    Private Sub BloqueoDeRegistroToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BloqueoDeRegistroToolStripMenuItem.Click
        cargaforma(frmRegistroExtrasAprobacionPlanilla)
    End Sub

    Private Sub ImportarRegistrosAprobadosPorRRHHToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ImportarRegistrosAprobadosPorRRHHToolStripMenuItem.Click
        Try
            Dim obj As New frmRegistroExtrasImportar()
            obj.MdiParent = Me
            obj.pcant = cnx.SQLEXECESCALAR("SELECT COUNT(*) AS cant FROM tbl_Extras WHERE estatus_nivel = 3")
            obj.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ReporteDeMarcasCaféAlmuerzoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReporteDeMarcasCaféAlmuerzoToolStripMenuItem.Click
        cargaforma(frmConsultaMarcasBreacks)
    End Sub

    Private Sub RegistrarHuellaDigitalToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RegistrarHuellaDigitalToolStripMenuItem.Click
        cargaforma(frmRHDRegistroHuellaDigital)
    End Sub

    Private Sub ConsultaDeHorariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaDeHorariosToolStripMenuItem.Click
        cargaforma(frmListadoHorarios)
    End Sub

    Private Sub IngresosDelDíaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IngresosDelDíaToolStripMenuItem.Click
        cargaforma(frmIngresosDelDia)
    End Sub

    Private Sub ReporteDeMarcasRevisiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeMarcasRevisiónToolStripMenuItem.Click
        cargaforma(FrmReporteMarcasRevisaExtras)
    End Sub

    Private Sub MantenimientoDeBeneficioATercerosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoDeBeneficioATercerosToolStripMenuItem.Click
        cargaforma(frmMantenimientoCaps)
    End Sub

    Private Sub GenerarReporteDePersonasQueTienenElBeneficioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarReporteDePersonasQueTienenElBeneficioToolStripMenuItem.Click
        cargaforma(frmGenerarCargadorAlimentacion)
    End Sub

    Private Sub ListadoDePersonasConElBenficioPermanenteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ListadoDePersonasConElBenficioPermanenteToolStripMenuItem1.Click
        cargaforma(frmListadoBenAlim)
    End Sub

    Private Sub ListadoDePersonasConElServicioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ListadoDePersonasConElServicioToolStripMenuItem1.Click
        cargaforma(frmListadoServAlim)
    End Sub

    Private Sub MantenimientoImagenesParaMenuDelDiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MantenimientoImagenesParaMenuDelDiaToolStripMenuItem.Click
        cargaforma(frmCargaMenuDia)
    End Sub

    Private Sub ConsultaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultaToolStripMenuItem.Click
        cargaforma(frmGenerarCargadorAlimentacionVerDetalle_II)
    End Sub

    Private Sub ExtrasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtrasToolStripMenuItem.Click
        cargaforma(frmRegistroExtrasListado_historico_reporte)
    End Sub

    Private Sub IncapacidadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncapacidadesToolStripMenuItem.Click
        cargaforma(frmReporteIncapacidades)
    End Sub

    Private Sub ColaboradoresEnElClubToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColaboradoresEnElClubToolStripMenuItem.Click
        cargaforma(frmConsultaMarcas_cuenta)
    End Sub

    Private Sub RotaciónDePersonalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RotaciónDePersonalToolStripMenuItem.Click
        cargaforma(frmReporteRotacion)
    End Sub

    Private Sub PlanillaMensualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanillaMensualToolStripMenuItem.Click
        cargaforma(FrmReportePlanillaMensual)
    End Sub
End Class