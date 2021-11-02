Imports System.ComponentModel
Public Class frmRegistroExtrasListado_historico_x_periodos_filtros
    Public frmParent As Form
    Dim dts As New DataSet
    Dim TipoNomi As String
    Private Sub frmRegistroExtrasListado_historico_x_periodos_filtros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            frmParent.Enabled = False

            Dim filesize As Integer = 0

            If System.IO.File.Exists("C:\APROGRAMAS\RPTHEXCONF.XML") Then
                filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTHEXCONF.XML").Length
            End If

            If filesize = 0 Then
                Dim dtTipNom As New DataTable
                dtTipNom.TableName = "dtTipNom"
                dtTipNom.Columns.Add("Nomina", Type.GetType("System.String"))
                dtTipNom.Columns.Add("Descripcion", Type.GetType("System.String"))
                dts.Tables.Add(dtTipNom)

                Dim dtConceptos As New DataTable
                dtConceptos.TableName = "dtConceptos"
                dtConceptos.Columns.Add("Concepto", Type.GetType("System.String"))
                dtConceptos.Columns.Add("Descripcion", Type.GetType("System.String"))
                dts.Tables.Add(dtConceptos)

                Dim dtNominas As New DataTable
                dtNominas.TableName = "dtNominas"
                dtNominas.Columns.Add("Nomina", Type.GetType("System.String"))
                dtNominas.Columns.Add("Numero_Nomina", Type.GetType("System.Int32"))
                dtNominas.Columns.Add("Fecha_inicio", Type.GetType("System.DateTime"))
                dtNominas.Columns.Add("Fecha_fin", Type.GetType("System.DateTime"))
                dts.Tables.Add(dtNominas)

                dtFinicio.Value = Now()
                dtFfinal.Value = Now()

            Else
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTHEXCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()

                TipoNomi = dts.Tables("dtTipNom").Rows(0).Item("Nomina")

                dtFinicio.Value = dts.Tables("dtNominas").Rows(0).Item("Fecha_inicio")
                dtFfinal.Value = dts.Tables("dtNominas").Rows(dts.Tables("dtNominas").Rows.Count - 1).Item("Fecha_fin")
            End If

            gridTipoNomina.DataSource = dts
            gridTipoNomina.DataMember = "dtTipNom"
            gridTipoNomina.Columns(0).Width = 83
            gridTipoNomina.Columns(1).Width = 260

            gridConceptos.DataSource = dts
            gridConceptos.DataMember = "dtConceptos"
            gridConceptos.Columns(0).Width = 83
            gridConceptos.Columns(1).Width = 260

            gridNominasInv.DataSource = dts
            gridNominasInv.DataMember = "dtNominas"
            gridNominasInv.Columns(0).Width = 65
            gridNominasInv.Columns(1).Width = 100
            gridNominasInv.Columns(2).Width = 120
            gridNominasInv.Columns(3).Width = 120

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmRegistroExtrasListado_historico_x_periodos_filtros_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmParent.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAgregarTipoNomi.Click
        Try
            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE NÓMINA"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta = "SELECT NOMINA, DESCRIPCION FROM SOFTLAND.CRCC01.NOMINA"

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            For i As Integer = 0 To dts.Tables("dtTipNom").Rows.Count - 1
                If result(0).ToString() = dts.Tables("dtTipNom").Rows(i).Item("nomina").ToString() Then
                    MessageBox.Show("El item que desea agregar ya esa en la lista", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            dts.Tables("dtTipNom").Rows.Add(result(0).ToString(), result(1).ToString())
            TipoNomi = result(0).ToString()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pnt As New frmBuscarx()
            Dim result As DataRowView = Nothing

            pnt.Text = "BUSQUEDA DE CONCEPTO"
            pnt.strTabla = "tbl_Busqueda"
            pnt.strConsulta = "SELECT concepto, DESCRIPCION FROM SOFTLAND.CRCC01.CONCEPTO"

            If pnt.ShowDialog = Windows.Forms.DialogResult.Yes Then
                result = CType(pnt.result, DataRowView)
            End If
            pnt.Close()

            If IsNothing(result) Then
                Exit Sub
            End If

            dts.Tables("dtConceptos").Rows.Add(result(0).ToString(), result(1).ToString())

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnCargarNominas_Click(sender As Object, e As EventArgs) Handles btnCargarNominas.Click
        Try
            If dtFinicio.Value > dtFfinal.Value Then
                MessageBox.Show("La fecha inicial no puede ser mayor que la fcha final.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtTipNom").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de nómina para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtConceptos").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un concepto para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim strSQL As String =
                "SELECT NOMINA, NUMERO_NOMINA, FECHA_INICIO, FECHA_FIN FROM SOFTLAND.CRCC01.NOMINA_HISTORICO" & vbNewLine &
                "WHERE FECHA_INICIO BETWEEN CONVERT(DATETIME,'" & Format(dtFinicio.Value, "dd/MM/yyyy") & "',103) AND CONVERT(DATETIME,'" & Format(dtFfinal.Value, "dd/MM/yyyy") & "',103)" & vbNewLine &
                "    AND NOMINA = '" & TipoNomi & "'" & vbNewLine &
                "ORDER BY FECHA_INICIO "

            Dim dt As New DataTable()
            cnx.SQLEXEC(dts, strSQL, "dtNominas")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminarTipoNomi_Click(sender As Object, e As EventArgs) Handles btnEliminarTipoNomi.Click
        Try
            If dts.Tables("dtTipNom").Rows.Count = 0 Then
                Exit Sub
            End If

            Dim pos As Integer = BindingContext(dts, "dtTipNom").Position
            If MessageBox.Show("Seguro de eliminar el item " & dts.Tables("dtTipNom").Rows(pos).Item("descripcion").ToString() & " de la lista ?",
                               "ELIMINAR DATOS !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dts.Tables("dtTipNom").Rows.RemoveAt(pos)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregaConcepto_Click(sender As Object, e As EventArgs) Handles btnAgregaConcepto.Click
        Try
            If dts.Tables("dtConceptos").Rows.Count = 0 Then
                Exit Sub
            End If

            Dim pos As Integer = BindingContext(dts, "dtTipNom").Position
            If MessageBox.Show("Seguro de eliminar el item " & dts.Tables("dtConceptos").Rows(pos).Item("descripcion").ToString() & " de la lista ?",
                               "ELIMINAR DATOS !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dts.Tables("dtConceptos").Rows.RemoveAt(pos)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLimNi_Click(sender As Object, e As EventArgs) Handles btnLimNi.Click
        Try
            If dts.Tables("dtNominas").Rows.Count = 0 Then
                Exit Sub
            End If

            If MessageBox.Show("se dispone a limpiar la lista de nominas. ¿ Esta seguro de proceder ?",
                           "ELIMINAR DATOS !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dts.Tables("dtNominas").Rows.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAcepar_Click(sender As Object, e As EventArgs) Handles btnAcepar.Click
        Try
            If dts.Tables("dtTipNom").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de nómina para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtConceptos").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un concepto para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            dts.WriteXml("C:\APROGRAMAS\RPTHEXCONF.XML")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class