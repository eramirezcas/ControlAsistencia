Imports CrystalDecisions.Shared

Public Class frmConsultaMarcasHist_new
    ' "dts" es el dataset de la forma; todas las formas principales tienen uno(objeto instanciado)
    Dim dts As New DataSet()


    Private Function filtro() As String
        ' esta funcion retirna un valor string que se concatena en el query para crear filtros al mismo
        Dim fini As String = Format(dtFInicial.Value, "dd/MM/yyyy")
        Dim ffin As String = Format(dtFFinal.Value, "dd/MM/yyyy") & " 23:59:59.999"

        ' subquery que me retorna la lista de colaboradores asignados a una seccion
        Dim misCol As String = ""

        If ckTodos.Checked() Then
            misCol = " AND (codigo in (SELECT E.empID FROM view_sl_empleados AS E WHERE(e.ESTADO_EMPLEADO = 'ACT') And (E.jefe = " & pempID & "))) "
        Else
            misCol = " AND (codigo = " & txtNombre.Tag & ") "
        End If

        ' en este caso la variable "verTodos" se crea al inicio del programa y se utiliza en cualquier
        ' parte del programa donde sea nesesario; mas especificamente hablando se utiliza para saber si
        ' el usuario tiene permiso de ver a todos los colaboradores o solo a una o varias secciones segun
        ' este configurado en el programa
        Dim sFiltro As String = "WHERE (fecha BETWEEN CONVERT(DATETIME,'" & fini & "',103) AND CONVERT(DATETIME,'" & ffin & "',103))" & IIf(ckTodos.Checked(), "", misCol)

        Return sFiltro
    End Function

    Private Sub cargaDatos()
        Try
            ' pregunto si el datable existe dentro del dataset y si existe lo elimino por que cada vez se
            ' consulta se crea un datatable nuevo para el refrescamiento
            If dts.Tables.Contains("tblDatosMarcasHistHist") Then
                dts.Tables.Remove("tblDatosMarcasHist")
            End If

            ' cargo esta variable con el query que basicamente es texto
            Dim strSQL As String = _
                "SELECT departamento, seccion, nombre, tipo, dia, fecha, ubicacion, horario, marca, diferencia, circunstancia, justificacion, numpago" & vbNewLine & _
                "FROM tbl_marcas_justificadas_act" & vbNewLine & _
                filtro() & vbNewLine & _
                "UNION ALL" & vbNewLine & _
                "SELECT departamento, seccion, nombre, tipo, dia, fecha, ubicacion, horario, marca, diferencia, circunstancia, justificacion, numpago" & vbNewLine & _
                "FROM tbl_marcas_justificadas_hist" & vbNewLine & _
                filtro() & vbNewLine & _
                "ORDER BY fecha, departamento, seccion, nombre"

            ' la variable "EXEC" es un string que se utiliza para cargar un mensaje de error retirnado por
            ' la base de datos donde si el contenido de esta variable es vacio continua si no muestra el 
            ' error en un messagebox y cierra la forma
            cnx.SQLEXEC(dts, strSQL, "tblDatosMarcasHist")

            ' configuro el datagridview; propiedades "DataSource y DataMember" se configuran de primero
            ' porque de lo contrario al hacerlo despues el datagridview se configura estandar
            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tblDatosMarcasHist"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.MultiSelect = False
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.AllowUserToResizeColumns = False
            DataGridView1.AllowUserToOrderColumns = False
            DataGridView1.AllowUserToAddRows = False

            DataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            DataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            DataGridView1.Columns(0).Width = 120
            DataGridView1.Columns(1).Width = 120
            DataGridView1.Columns(2).Width = 150
            DataGridView1.Columns(3).Width = 70
            DataGridView1.Columns(4).Width = 70
            DataGridView1.Columns(5).Width = 70
            DataGridView1.Columns(6).Width = 120
            DataGridView1.Columns(7).Width = 120
            DataGridView1.Columns(8).Width = 120
            DataGridView1.Columns(9).Width = 50
            DataGridView1.Columns(10).Width = 160
            DataGridView1.Columns(11).Width = 160
            DataGridView1.Columns(12).Width = 60

            DataGridView1.Columns(0).HeaderText = "DEPARTAMENTO"
            DataGridView1.Columns(1).HeaderText = "SECCION"
            DataGridView1.Columns(2).HeaderText = "NOMBRE"
            DataGridView1.Columns(3).HeaderText = "TIPO"
            DataGridView1.Columns(4).HeaderText = "DIA"
            DataGridView1.Columns(5).HeaderText = "FECHA"
            DataGridView1.Columns(6).HeaderText = "UBICACION"
            DataGridView1.Columns(7).HeaderText = "HORARIO"
            DataGridView1.Columns(8).HeaderText = "MARCA"
            DataGridView1.Columns(9).HeaderText = "DIF."
            DataGridView1.Columns(10).HeaderText = "CIRCUNSTANCIA"
            DataGridView1.Columns(11).HeaderText = "JUSTIFICACION"
            DataGridView1.Columns(12).HeaderText = "NUMPAGO"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnNombre_Click(sender As System.Object, e As System.EventArgs) Handles btnNombre.Click
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
        pnt.strConsulta =
            "DECLARE @userid AS INT" & vbNewLine & _
            "SET @userid = " & pempID.ToString.Trim & vbNewLine & _
            "" & vbNewLine & _
            "SELECT E.empID, E.nombre FROM view_sl_empleados AS E WHERE(e.estado_empleado = 'ACT')" & IIf(verTodos, "", " And (E.jefe = @userid)")

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

        txtNombre.Tag = result.Item("empid")
        txtNombre.Text = result.Item("nombre")

    End Sub

    Private Sub frmConsultaMarcasHist_new_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnLimpiar.PerformClick()
    End Sub

    Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
        '' metodo para mostrar reporte.
        '' son necesarios varios elemetos:
        ''   - forma con el control CrystalReportViewer donde se va mostrar el reporte
        ''   - el archivo de reporte o el reporte dibujado y configurado desde crystal
        ''   - dataset de proyecto
        ''   - datatable del reporte(en este caso puede ser uno o varios dependiendo de la necesidad)
        ''   - Importar la libreria "CrystalDecisions.Shared"
        'Dim shwrpt As New frmReport()
        'Dim rpt As New rptMarcasHist_new()

        '' para este caso en particular en el titulo del reporte se parametriza el rango de fechas
        '' y se pasan al reporte por parametro para realizar este proceso hay que crear variables
        '' de parametro tanto en el reporte como en la pantalla desde donde se instancia el reporte

        '' definicion de parametros para el reporte
        'Dim par1 As New ParameterValues
        'Dim par2 As New ParameterValues

        '' carga de datos en los parametros del reporte
        'par1.AddValue("CONSULTA DE MARCAS HISTORICAS")
        'par2.AddValue(dtFInicial.Value.ToShortDateString & " AL " & dtFFinal.Value.ToShortDateString)

        '' redefinicion del origen de datos del reporte
        'rpt.SetDataSource(dts)

        '' asignacion de parametros del reporte(deben de existir los parametros dentro del reporte)
        'rpt.ParameterFields("pTitulo").CurrentValues = par1
        'rpt.ParameterFields("pFiltro").CurrentValues = par2

        '' carga del reporte en le control "CrystalReportViewer"
        'shwrpt.CrystalReportViewer1.ReportSource = rpt

        '' esta linea se utiliza para que la pantalla donde se muestra el reporte quede contrenida
        '' dentro de la pantalla de inicio del programa
        'shwrpt.MdiParent = Me.MdiParent
        'shwrpt.Show()
    End Sub

    Private Sub tsbExcel_Click(sender As System.Object, e As System.EventArgs) Handles tsbExcel.Click
        ' metodo para utilizar el Exeleador
        '   - forma frmExceleador
        '   - clase clsExceleador

        ' intancia de la forma frmExceleador
        Dim pntexcel As New frmExeleador()

        ' variable de referencia para el dataset 
        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts

        ' nombre de la tabla a consultar
        pntexcel.tabla = "tblDatosMarcasHist"

        ' titulo de la forma
        pntexcel.titulo = "CONSULTA DE MARCAS / " & StrDup(5 - txtNombre.Tag.ToString.Length, "0") & txtNombre.Tag.ToString.Trim & " - " & txtNombre.Text

        ' se puede utilizar para mostrar el filtro ex: Filtro: 01/01/2013 al 15/01/2013
        pntexcel.filtro = ""

        ' asigna un contenedor
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub

    Private Sub tsbSalir_Click(sender As System.Object, e As System.EventArgs) Handles tsbSalir.Click
        Close()
    End Sub

    Private Sub ckTodos_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ckTodos.CheckedChanged
        Dim obj As CheckBox = CType(sender, CheckBox)

        If obj.Checked Then
            txtNombre.Text = ""
            txtNombre.Tag = Nothing
            dtFInicial.Value = Now
            dtFFinal.Value = Now
        End If

        btnNombre.Enabled = IIf(obj.Checked, False, True)
        dtFInicial.Enabled = IIf(obj.Checked, False, True)
        dtFFinal.Enabled = IIf(obj.Checked, False, True)
    End Sub

    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click

        btnGenerar.Visible = False
        btnLimpiar.Visible = True

        If dtFFinal.Value < dtFInicial.Value Then
            MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        cargaDatos()
    End Sub

    Private Sub btnLimpiar_Click(sender As System.Object, e As System.EventArgs) Handles btnLimpiar.Click

        ckTodos.Checked = True

        If ckTodos.Checked Then
            txtNombre.Text = ""
            txtNombre.Tag = Nothing
            dtFInicial.Value = Now
            dtFFinal.Value = Now
        End If

        btnNombre.Enabled = IIf(ckTodos.Checked, False, True)
        dtFInicial.Enabled = IIf(ckTodos.Checked, False, True)
        dtFFinal.Enabled = IIf(ckTodos.Checked, False, True)

        btnGenerar.Visible = True
        btnLimpiar.Visible = False
        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = ""

    End Sub
End Class