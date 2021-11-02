Public Class frmReporteIncapacidades_filtros
    Public frmParent As Form
    Dim dts As New DataSet

    Private Sub frmReporteIncapacidades_filtros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            frmParent.Enabled = False

            Dim filesize As Integer = 0

            If System.IO.File.Exists("C:\APROGRAMAS\RPTINCCONF.XML") Then
                filesize = System.IO.File.ReadAllBytes("C:\APROGRAMAS\RPTINCCONF.XML").Length
            End If

            If filesize = 0 Then

                Dim dtTipoAccion As New DataTable
                dtTipoAccion.TableName = "dtTipAccion"
                dtTipoAccion.Columns.Add("tipo_accion", Type.GetType("System.String"))
                dtTipoAccion.Columns.Add("Descripcion", Type.GetType("System.String"))
                dts.Tables.Add(dtTipoAccion)

                Dim dtFechas As New DataTable
                dtFechas.TableName = "dtFechas"
                dtFechas.Columns.Add("Fecha_inicio", Type.GetType("System.DateTime"))
                dtFechas.Columns.Add("Fecha_fin", Type.GetType("System.DateTime"))
                dtFechas.Columns.Add("separa_acciones_30omas", Type.GetType("System.Boolean"))
                dts.Tables.Add(dtFechas)

                dtFinicio.Value = Now()
                dtFfinal.Value = Now()

            Else
                Dim stfile As New System.IO.StreamReader("C:\APROGRAMAS\RPTINCCONF.XML")
                dts.ReadXml(stfile)
                stfile.Close()

                dtFinicio.Value = dts.Tables("dtFechas").Rows(0).Item("Fecha_inicio")
                dtFfinal.Value = dts.Tables("dtFechas").Rows(0).Item("Fecha_fin")
            End If

            gridFechas.DataSource = dts
            gridFechas.DataMember = "dtFechas"

            gridFechas.Columns(0).HeaderText = "Inicio"
            gridFechas.Columns(1).HeaderText = "Final"
            gridFechas.Columns(2).HeaderText = "Separadas"

            gridFechas.Columns(0).Width = 120
            gridFechas.Columns(1).Width = 120
            gridFechas.Columns(2).Width = 100

            gridTipoAccion.DataSource = dts
            gridTipoAccion.DataMember = "dtTipAccion"

            gridTipoAccion.Columns(0).HeaderText = "Codigo"
            gridTipoAccion.Columns(1).HeaderText = "Descripcion"

            gridTipoAccion.Columns(0).Width = 100
            gridTipoAccion.Columns(1).Width = 220


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmReporteIncapacidades_filtros_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        frmParent.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnAgregarTipoAccion.Click
        Try
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

            For i As Integer = 0 To dts.Tables("dtTipAccion").Rows.Count - 1
                If result(0).ToString() = dts.Tables("dtTipAccion").Rows(i).Item("TIPO_ACCION").ToString() Then
                    MessageBox.Show("El item que desea agregar ya esa en la lista", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            dts.Tables("dtTipAccion").Rows.Add(result(0).ToString(), result(1).ToString())

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnEliminarTipoNomi_Click(sender As Object, e As EventArgs) Handles btnEliminarTipoAccion.Click
        Try
            If dts.Tables("dtTipAccion").Rows.Count = 0 Then
                Exit Sub
            End If

            Dim pos As Integer = BindingContext(dts, "dtTipAccion").Position
            If MessageBox.Show("Seguro de eliminar el item " & dts.Tables("dtTipAccion").Rows(pos).Item("DESCRIPCION").ToString() & " de la lista ?",
                               "ELIMINAR DATOS !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dts.Tables("dtTipAccion").Rows.RemoveAt(pos)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAcepar_Click(sender As Object, e As EventArgs) Handles btnAcepar.Click
        Try
            If dts.Tables("dtFechas").Rows.Count = 0 Then
                MessageBox.Show("Debe seleccionar un rango de fechas para poder realizar el proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtTipAccion").Rows.Count = 0 Then
                MessageBox.Show("Debe de tener seleccionado al menos un tipo de acción para poder realizar este proceso.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            dts.WriteXml("C:\APROGRAMAS\RPTINCCONF.XML")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAgregarFechas_Click(sender As Object, e As EventArgs) Handles btnAgregarFechas.Click
        Try
            If dtFinicio.Value >= dtFfinal.Value Then
                MessageBox.Show("La fecha inicial no puede ser mayor que la fecha final.", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If dts.Tables("dtFechas").Rows.Count >= 1 Then
                dts.Tables("dtFechas").Rows.Clear()
            End If

            Dim finicio As DateTime = CType(Format(dtFinicio.Value, "dd/MM/yyyy"), DateTime)
            Dim ffinal As DateTime = CType(Format(dtFfinal.Value, "dd/MM/yyyy"), DateTime)

            dts.Tables("dtFechas").Rows.Add(finicio, ffinal, CheckBox1.Checked)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminarFechas_Click(sender As Object, e As EventArgs) Handles btnEliminarFechas.Click
        Try
            If dts.Tables("dtFechas").Rows.Count() = 0 Then
                Exit Sub
            End If

            If MessageBox.Show("Se dispone a limpiar los datos de fecha", "ELIMINAR DATOS !!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                dts.Tables("dtFechas").Rows.Clear()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class