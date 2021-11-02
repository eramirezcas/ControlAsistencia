Public Class frmReporteRotacion_filtros
    Public frmParent As Form
    Dim dts As New DataSet
    Private Sub frmReporteRotacion_filtros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            frmParent.Enabled = False

            Dim filesize As Integer = 0

            If System.IO.File.Exists("C:\APROGRAMAS\RPTROTCONF.XML") Then
                filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTROTCONF.XML").Length
            End If

            If filesize = 0 Then

                Dim dtTipoColaborador As New DataTable
                dtTipoColaborador.TableName = "dtTipoColaborador"
                dtTipoColaborador.Columns.Add("tipo", Type.GetType("System.String"))
                dtTipoColaborador.Columns.Add("seleccion", Type.GetType("System.String"))
                dts.Tables.Add(dtTipoColaborador)

                Dim dtTipoNomina As New DataTable
                dtTipoNomina.TableName = "dtTipoNomina"
                dtTipoNomina.Columns.Add("nomina", Type.GetType("System.String"))
                dtTipoNomina.Columns.Add("descripcion", Type.GetType("System.String"))
                dts.Tables.Add(dtTipoNomina)

                Dim dtTipoAccion As New DataTable
                dtTipoAccion.TableName = "dtTipoAccion"
                dtTipoAccion.Columns.Add("accion", Type.GetType("System.String"))
                dtTipoAccion.Columns.Add("descripcion", Type.GetType("System.String"))
                dtTipoAccion.Columns.Add("esIngreso", Type.GetType("System.Boolean"))
                dts.Tables.Add(dtTipoAccion)

                Dim dtFechas As New DataTable
                dtFechas.TableName = "dtFechas"
                dtFechas.Columns.Add("Nomina", Type.GetType("System.String"))
                dtFechas.Columns.Add("Numero_nomina", Type.GetType("System.Int32"))
                dtFechas.Columns.Add("Fecha_inicio", Type.GetType("System.DateTime"))
                dtFechas.Columns.Add("Fecha_fin", Type.GetType("System.DateTime"))
                dts.Tables.Add(dtFechas)

                dtFinicio.Value = Now().AddMonths(-12)
                dtFfinal.Value = Now()

            Else
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTROTCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()

                dtFinicio.Value = dts.Tables("dtFechas").Rows(0).Item("Fecha_inicio")
                dtFfinal.Value = dts.Tables("dtFechas").Rows(dts.Tables("dtFechas").Rows.Count - 1).Item("Fecha_fin")
            End If

            gridTipoCol.DataSource = dts
            gridTipoCol.DataMember = "dtTipoColaborador"

            gridTipoNomina.DataSource = dts
            gridTipoNomina.DataMember = "dtTipoNomina"

            gridTipoAccion.DataSource = dts
            gridTipoAccion.DataMember = "dtTipoAccion"

            gridNominasInv.DataSource = dts
            gridNominasInv.DataMember = "dtFechas"

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnAgregarColaborador_Click(sender As Object, e As EventArgs) Handles btnAgregarColaborador.Click
        Try
            If dts.Tables("dtTipoColaborador").Rows.Count > 0 Then
                dts.Tables("dtTipoColaborador").Rows.Clear()
            End If

            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE TIPOS DE COLABORADOR"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta =
                    "SELECT 'TEMPORAL' AS TIPO, 'SI' AS SELECCION" & vbNewLine &
                    "UNION ALL" & vbNewLine &
                    "SELECT 'TEMPORAL' AS TIPO, 'NO' AS SELECCION" & vbNewLine &
                    "UNION ALL" & vbNewLine &
                    "SELECT 'AMBOS' AS TIPO, '' AS SELECCION"

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            For i As Integer = 0 To dts.Tables("dtTipoColaborador").Rows.Count - 1
                If result(0).ToString() = dts.Tables("dtTipoColaborador").Rows(i).Item("TIPO").ToString() Then
                    MessageBox.Show("El item que desea agregar ya esa en la lista", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            dts.Tables("dtTipoColaborador").Rows.Add(result(0).ToString(), result(1).ToString())

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminarColaborador_Click(sender As Object, e As EventArgs) Handles btnEliminarColaborador.Click
        If MessageBox.Show("Se dispone a eliminar el tipo de colaborador seleccionado." & vbNewLine &
                           "¿ Seguro de proceder ?", "ELIMINAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        dts.Tables("dtTipoColaborador").Rows.Clear()
    End Sub

    Private Sub btnAgregarTipoNomi_Click(sender As Object, e As EventArgs) Handles btnAgregarTipoNomi.Click
        Try
            If dts.Tables("dtTipoNomina").Rows.Count > 0 Then
                dts.Tables("dtTipoNomina").Rows.Clear()
            End If

            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE TIPOS DE NOMINA"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta = "SELECT NOMINA AS TIPO, DESCRIPCION FROM SOFTLAND.CRCC01.NOMINA"

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            For i As Integer = 0 To dts.Tables("dtTipoNomina").Rows.Count - 1
                If result(0).ToString() = dts.Tables("dtTipoNomina").Rows(i).Item("tipo").ToString() Then
                    MessageBox.Show("El item que desea agregar ya esa en la lista", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            dts.Tables("dtTipoNomina").Rows.Add(result(0).ToString(), result(1).ToString())

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminarTipoNomi_Click(sender As Object, e As EventArgs) Handles btnEliminarTipoNomi.Click
        If MessageBox.Show("Se dispone a eliminar el tipo de nomina seleccionado." & vbNewLine &
                           "¿ Seguro de proceder ?", "ELIMINAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        dts.Tables("dtTipoNomina").Rows.Clear()
    End Sub

    Private Sub btnAgregarTipoAccion_Click(sender As Object, e As EventArgs) Handles btnAgregarTipoAccion.Click
        Try
            'If dts.Tables("dtTipoNomina").Rows.Count > 0 Then
            '    dts.Tables("dtTipoNomina").Rows.Clear()
            'End If

            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE TIPOS DE ACCION"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta = "SELECT TIPO_ACCION, DESCRIPCION FROM SOFTLAND.CRCC01.TIPO_ACCION"

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            If chAccionIng.Checked Then
                For i As Integer = 0 To dts.Tables("dtTipoAccion").Rows.Count - 1
                    If dts.Tables("dtTipoAccion").Rows(i).Item("esIngreso") = True Then
                        MessageBox.Show("Ya tienen una acción seleccionada como acción de ingreso. Si desea cambiarla debe borrar la que ya tiene agregada", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        chAccionIng.Checked = False
                        Exit Sub
                    End If
                Next
            End If


            For i As Integer = 0 To dts.Tables("dtTipoAccion").Rows.Count - 1
                If result(0).ToString() = dts.Tables("dtTipoAccion").Rows(i).Item("accion").ToString() Then
                    MessageBox.Show("El item que desea agregar ya esa en la lista", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            dts.Tables("dtTipoAccion").Rows.Add(result(0).ToString(), result(1).ToString(), chAccionIng.Checked)

            chAccionIng.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnEliminarTipoAccion_Click(sender As Object, e As EventArgs) Handles btnEliminarTipoAccion.Click
        If MessageBox.Show("Se dispone a eliminar el tipo de nomina seleccionado." & vbNewLine &
                           "¿ Seguro de proceder ?", "ELIMINAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If

        Dim pos As Integer = BindingContext(dts, "dtTipoAccion").Position
        dts.Tables("dtTipoAccion").Rows(pos).Delete()
    End Sub

    Private Sub btnCargarNominas_Click(sender As Object, e As EventArgs) Handles btnCargarNominas.Click
        Try
            If dts.Tables("dtTipoColaborador").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de colaborador para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtTipoNomina").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de nómina para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtTipoAccion").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de accion para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dtFinicio.Value > dtFfinal.Value Then
                MessageBox.Show("La fecha inicial no puede ser mayor que la fcha final.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim TipoNomi As String = dts.Tables("dtTipoNomina").Rows(0).Item("nomina")

            Dim strSQL As String =
                "SELECT NOMINA, NUMERO_NOMINA, FECHA_INICIO, FECHA_FIN FROM SOFTLAND.CRCC01.NOMINA_HISTORICO" & vbNewLine &
                "WHERE FECHA_INICIO BETWEEN CONVERT(DATETIME,'" & Format(dtFinicio.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATETIME,'" & Format(dtFfinal.Value, "dd/MM/yyyy") & "',103)" & vbNewLine &
                "    AND NOMINA = '" & TipoNomi & "'" & vbNewLine &
                "ORDER BY FECHA_INICIO "

            Dim dt As New DataTable()
            cnx.SQLEXEC(dts, strSQL, "dtFechas")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimpiarNominas_Click(sender As Object, e As EventArgs) Handles btnLimpiarNominas.Click
        If MessageBox.Show("Se dispone a eliminar el tipo de nomina seleccionado." & vbNewLine &
                           "¿ Seguro de proceder ?", "ELIMINAR !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Exit Sub
        End If
        dts.Tables("dtFechas").Rows.Clear()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmReporteRotacion_filtros_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmParent.Enabled = True
    End Sub

    Private Sub btnAcepar_Click(sender As Object, e As EventArgs) Handles btnAcepar.Click
        Try

            If dts.Tables("dtTipoColaborador").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de colaborador para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtTipoNomina").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de nómina para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtTipoAccion").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de accón para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtFechas").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un rango de fechas para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            dts.WriteXml("C:\APROGRAMAS\RPTROTCONF.XML")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class