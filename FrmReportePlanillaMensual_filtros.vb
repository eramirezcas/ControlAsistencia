Public Class FrmReportePlanillaMensual_filtros
    Public frmParent As Form
    Dim dts As New DataSet
    Dim dtanio As New DataTable()
    Dim dtmes As New DataTable()

    Private Sub FrmReportePlanillaMensual_filtros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            frmParent.Enabled = False
            Dim filesize As Integer = 0

            dtanio.Columns.Add("anio", GetType(String))
            For i As Integer = 1980 To 2050
                dtanio.Rows.Add(i.ToString.Trim())
            Next

            dtmes.Columns.Add("num_mes", GetType(Integer))
            dtmes.Columns.Add("mes", GetType(String))

            cboAnio.DataSource = dtanio
            cboAnio.DisplayMember = "anio"
            cboAnio.ValueMember = "anio"
            cboAnio.DropDownStyle = ComboBoxStyle.DropDownList
            cboAnio.SelectedValue = Now.Year()

            dtmes.Rows.Add(1, "ENERO")
            dtmes.Rows.Add(2, "FEBRERO")
            dtmes.Rows.Add(3, "MARZO")
            dtmes.Rows.Add(4, "ABRIL")
            dtmes.Rows.Add(5, "MAYO")
            dtmes.Rows.Add(6, "JUNIO")
            dtmes.Rows.Add(7, "JULIO")
            dtmes.Rows.Add(8, "AGOSTO")
            dtmes.Rows.Add(9, "SETIEMBRE")
            dtmes.Rows.Add(10, "OCTUBRE")
            dtmes.Rows.Add(11, "NOVIEMBRE")
            dtmes.Rows.Add(12, "DICIEMBRE")

            cboMes.DataSource = dtmes
            cboMes.DisplayMember = "mes"
            cboMes.ValueMember = "num_mes"
            cboMes.DropDownStyle = ComboBoxStyle.DropDownList
            cboMes.SelectedValue = Now.Month()

            If System.IO.File.Exists("C:\APROGRAMAS\RPTPMCONF.XML") Then
                filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTPMCONF.XML").Length
            End If

            If filesize = 0 Then

                Dim dtTipoNomina As New DataTable
                dtTipoNomina.TableName = "dtTipNomina"
                dtTipoNomina.Columns.Add("Nomina", Type.GetType("System.String"))
                dtTipoNomina.Columns.Add("Descripcion", Type.GetType("System.String"))
                dts.Tables.Add(dtTipoNomina)

                Dim dtConceptos As New DataTable
                dtConceptos.TableName = "dtConceptos"
                dtConceptos.Columns.Add("Concepto", Type.GetType("System.String"))
                dtConceptos.Columns.Add("Descripcion", Type.GetType("System.String"))
                dts.Tables.Add(dtConceptos)

                Dim dtFechas As New DataTable
                dtFechas.TableName = "dtFechas"
                dtFechas.Columns.Add("anio", Type.GetType("System.Int32"))
                dtFechas.Columns.Add("num_mes", Type.GetType("System.Int32"))
                dtFechas.Columns.Add("mes", Type.GetType("System.String"))
                dts.Tables.Add(dtFechas)


            Else
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTPMCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()

            End If

            gridFechas.DataSource = dts
            gridFechas.DataMember = "dtFechas"

            gridFechas.Columns(0).HeaderText = "Año"
            gridFechas.Columns(1).HeaderText = "Num.Mes"
            gridFechas.Columns(2).HeaderText = "Mes"

            gridFechas.Columns(0).Width = 60
            gridFechas.Columns(1).Width = 60
            gridFechas.Columns(2).Width = 120

            gridTipoNomina.DataSource = dts
            gridTipoNomina.DataMember = "dtTipNomina"

            gridTipoNomina.Columns(0).HeaderText = "Nomina"
            gridTipoNomina.Columns(1).HeaderText = "Descripcion"

            gridTipoNomina.Columns(0).Width = 100
            gridTipoNomina.Columns(1).Width = 220

            gridListaConceptos.DataSource = dts
            gridListaConceptos.DataMember = "dtConceptos"

            gridListaConceptos.Columns(0).HeaderText = "Concepto"
            gridListaConceptos.Columns(1).HeaderText = "Descripcion"

            gridListaConceptos.Columns(0).Width = 100
            gridListaConceptos.Columns(1).Width = 220


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FrmReportePlanillaMensual_filtros_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        frmParent.Enabled = True
    End Sub

    Private Sub btnAgregarFechas_Click(sender As Object, e As EventArgs) Handles btnAgregarFechas.Click
        Try
            Dim xAnio As Integer = cboAnio.SelectedValue
            Dim xNmes As Integer = cboMes.SelectedValue
            Dim xMes As String = cboMes.Text

            dts.Tables("dtFechas").Rows.Clear()
            dts.Tables("dtFechas").Rows.Add(xAnio, xNmes, xMes)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregarTipoNomina_Click(sender As Object, e As EventArgs) Handles btnAgregarTipoNomina.Click
        Try
            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE TIPOS DE ACCION"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta = "SELECT NOMINA, DESCRIPCION FROM SOFTLAND.CRCC01.NOMINA"

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            For i As Integer = 0 To dts.Tables("dtTipNomina").Rows.Count - 1
                If result(0).ToString() = dts.Tables("dtTipNomina").Rows(i).Item("NOMINA").ToString() Then
                    MessageBox.Show("El item que desea agregar ya esa en la lista", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            dts.Tables("dtTipNomina").Rows.Add(result(0).ToString(), result(1).ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminarTipoNomina_Click(sender As Object, e As EventArgs) Handles btnEliminarTipoNomina.Click
        Try
            If dts.Tables("dtTipNomina").Rows.Count = 0 Then
                Exit Sub
            End If

            Dim pos As Integer = BindingContext(dts, "dtTipNomina").Position
            If MessageBox.Show("Seguro de eliminar el item " & dts.Tables("dtTipNomina").Rows(pos).Item("DESCRIPCION").ToString() & " de la lista ?",
                               "ELIMINAR DATOS !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dts.Tables("dtTipNomina").Rows.RemoveAt(pos)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregarConcepto_Click(sender As Object, e As EventArgs) Handles btnAgregarConcepto.Click
        Try
            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE CONCEPTOS"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta = "SELECT CONCEPTO, DESCRIPCION FROM SOFTLAND.CRCC01.CONCEPTO"

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            For i As Integer = 0 To dts.Tables("dtConceptos").Rows.Count - 1
                If result(0).ToString() = dts.Tables("dtConceptos").Rows(i).Item("CONCEPTO").ToString() Then
                    MessageBox.Show("El item que desea agregar ya esa en la lista", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            dts.Tables("dtConceptos").Rows.Add(result(0).ToString(), result(1).ToString())
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnEliminarConcepto_Click(sender As Object, e As EventArgs) Handles btnEliminarConcepto.Click
        Try
            If dts.Tables("dtTipNomina").Rows.Count = 0 Then
                Exit Sub
            End If

            Dim pos As Integer = BindingContext(dts, "dtConceptos").Position
            If MessageBox.Show("Seguro de eliminar el item " & dts.Tables("dtConceptos").Rows(pos).Item("DESCRIPCION").ToString() & " de la lista ?",
                               "ELIMINAR DATOS !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dts.Tables("dtConceptos").Rows.RemoveAt(pos)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAcepar_Click(sender As Object, e As EventArgs) Handles btnAcepar.Click
        Try
            If dts.Tables("dtFechas").Rows.Count = 0 Then
                MessageBox.Show("Debe seleccionar criterios de fecha para poder realizar el proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtTipNomina").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de nómina para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtConceptos").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener al menos un concepto para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            dts.WriteXml("C:\APROGRAMAS\RPTPMCONF.XML")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
End Class