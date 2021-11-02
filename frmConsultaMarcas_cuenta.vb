Public Class frmConsultaMarcas_cuenta
    Dim dt As New DataTable

    Private Function cant_in() As Integer
        Dim strSQL As String =
            "DECLARE @fecha AS DATETIME" & vbNewLine &
            "SET @fecha = CONVERT(datetime,CONVERT(varchar(10),getdate(),103),103)" & vbNewLine &
            "" & vbNewLine &
            "SELECT COUNT(*) AS Cant " & vbNewLine &
            "FROM tbl_marcas" & vbNewLine &
            "WHERE (tbl_marcas.timeStamp >= @fecha)"

        Dim result As Integer = CType(cnx.SQLEXECESCALAR(strSQL), Integer)
        Return result
    End Function
    Private Sub Listado_x_dia()
        Dim dt_temp As New DataTable
        Dim strSQl As String =
            "DECLARE @fecha AS DATETIME" & vbNewLine &
            "SET @fecha = CONVERT(datetime,CONVERT(varchar(10),getdate(),103),103)" & vbNewLine &
            "" & vbNewLine &
            "SELECT view_sl_empleados.DEPARTAMENTO" & vbNewLine &
            "	, view_sl_empleados.SECCION" & vbNewLine &
            "	, tbl_marcas.codigo" & vbNewLine &
            "	, tbl_marcas.nombre" & vbNewLine &
            "	, tbl_marcas.entrada" & vbNewLine &
            "	, tbl_marcas.salida" & vbNewLine &
            "	, tbl_marcas.timeStamp" & vbNewLine &
            "FROM tbl_marcas" & vbNewLine &
            "	INNER JOIN view_sl_empleados ON tbl_marcas.codigo COLLATE SQL_Latin1_General_CP1_CI_AS = view_sl_empleados.EMPID" & vbNewLine &
            "WHERE (tbl_marcas.timeStamp >= @fecha)" & vbNewLine &
            "ORDER BY tbl_marcas.timeStamp"

        cnx.SQLEXEC(dt_temp, strSQl)
        dt = dt_temp

        txtrealizado.Text = Format(Now, "dd/mm/yyyy hh:mm:ss")
        txtCantidad.Text = cant_in()
    End Sub

    Private Sub listado_calendario_area()
        Dim dt_temp As New DataTable
        Dim strSQl As String =
            "Select *" & vbNewLine &
            "From" & vbNewLine &
            "(" & vbNewLine &
            "	SELECT YEAR(tbl_marcas.timeStamp) as anio" & vbNewLine &
            "		, MONTH(tbl_marcas.timeStamp) as mes" & vbNewLine &
            "		, DAY(tbl_marcas.timeStamp) as dia" & vbNewLine &
            "		, view_sl_empleados.DEPARTAMENTO" & vbNewLine &
            "		, view_sl_empleados.SECCION" & vbNewLine &
            "		, COUNT(*) as Cant" & vbNewLine &
            "	FROM tbl_marcas" & vbNewLine &
            "		INNER JOIN view_sl_empleados ON tbl_marcas.codigo = view_sl_empleados.EMPID COLLATE Modern_Spanish_CI_AS" & vbNewLine &
            "	WHERE (YEAR(tbl_marcas.timeStamp) = 2020) AND (MONTH(tbl_marcas.timeStamp) IN (1,2,3,4,5,6,7,8,9,10,11,12))" & vbNewLine &
            "	GROUP BY view_sl_empleados.DEPARTAMENTO" & vbNewLine &
            "		, view_sl_empleados.SECCION" & vbNewLine &
            "		, YEAR(tbl_marcas.timeStamp)" & vbNewLine &
            "		, MONTH(tbl_marcas.timeStamp)" & vbNewLine &
            "		, DAY(tbl_marcas.timeStamp)" & vbNewLine &
            ") AS A" & vbNewLine &
            "PIVOT ( sum(A.cant) FOR A.dia in ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12],[13],[14],[15],[16],[17],[18],[19],[20],[21],[22],[23],[24],[25],[26],[27],[28],[29],[30],[31])) as pvt" & vbNewLine &
            "order by 1,2,3,4"

        cnx.SQLEXEC(dt_temp, strSQl)
        dt = dt_temp

        txtrealizado.Text = Format(Now, "dd/mm/yyyy hh:mm:ss")
        txtCantidad.Text = cant_in()
    End Sub

    Private Sub ingresos_mes()
        Dim dt_temp As New DataTable
        Dim strSQl As String =
            "SELECT * FROM" & vbNewLine &
            "(" & vbNewLine &
            "	SELECT A.anio" & vbNewLine &
            "		, A.mes" & vbNewLine &
            "		, A.DEPARTAMENTO" & vbNewLine &
            "		, A.SECCION" & vbNewLine &
            "		, COUNT(*) AS Cant" & vbNewLine &
            "	FROM" & vbNewLine &
            "	(" & vbNewLine &
            "		SELECT DISTINCT" & vbNewLine &
            "				YEAR(tbl_marcas.timeStamp) as anio" & vbNewLine &
            "			, MONTH(tbl_marcas.timeStamp) as mes" & vbNewLine &
            "			, view_sl_empleados.DEPARTAMENTO" & vbNewLine &
            "			, view_sl_empleados.SECCION" & vbNewLine &
            "			, tbl_marcas.codigo" & vbNewLine &
            "		FROM  tbl_marcas" & vbNewLine &
            "			INNER JOIN view_sl_empleados ON tbl_marcas.codigo = view_sl_empleados.EMPID COLLATE Modern_Spanish_CI_AS" & vbNewLine &
            "		WHERE (YEAR(tbl_marcas.timeStamp) = 2020)" & vbNewLine &
            "			AND (MONTH(tbl_marcas.timeStamp) IN (1,2,3,4,5,6,7,8,9,10,11,12))" & vbNewLine &
            ") AS A" & vbNewLine &
            "GROUP BY A.anio" & vbNewLine &
            "	, A.mes" & vbNewLine &
            "	, A.DEPARTAMENTO" & vbNewLine &
            "	, A.SECCION" & vbNewLine &
            ") AS A1" & vbNewLine &
            "PIVOT( sum(A1.cant) for A1.mes in ([1],[2],[3],[4],[5],[6],[7],[8],[9],[10],[11],[12])) as pvt"


        cnx.SQLEXEC(dt_temp, strSQl)
        dt = dt_temp

        txtrealizado.Text = Format(Now, "dd/mm/yyyy hh:mm:ss")
        txtCantidad.Text = cant_in()
    End Sub
    Private Sub cargaGrid()

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        DataGridView1.DataSource = dt

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnIngDia.Click
        Listado_x_dia()
        cargaGrid()
    End Sub

    Private Sub btnIngMesArea_Click(sender As Object, e As EventArgs) Handles btnIngMesArea.Click
        listado_calendario_area()
        cargaGrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ingresos_mes()
        cargaGrid()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pntexcel As New frmExeleador()
        Dim dts_temp As New DataSet

        dts_temp.Tables.Add(dt)
        dts_temp.Tables(0).TableName = "tbl_result"

        pntexcel.MdiParent = Me.MdiParent
        pntexcel.dts = dts_temp
        pntexcel.tabla = "tbl_result"
        pntexcel.titulo = "CONSULTA DE MARCAS"
        pntexcel.filtro = "MARCAS DEL : " & txtrealizado.Text.ToString() & " - Cantidad: " & txtCantidad.Text.ToString()
        pntexcel.pntOrigern = Me
        pntexcel.Show()
    End Sub
End Class