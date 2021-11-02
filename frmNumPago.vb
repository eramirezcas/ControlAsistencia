Public Class frmNumPago
    Dim fechaAplica As Date
    Public encPago As String

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click, btnSalir.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)
        Dim numpago As Integer = CType(txtNominaNumero.Text, Integer) + 1
        Select Case obj.Text
            Case "&Aceptar"
                encPago = numpago
                DialogResult = Windows.Forms.DialogResult.Yes

            Case "Car&gar", "&Importar"

                If CType(txtHoy.Text, Date) > CType(txtFechaFinal.Text, Date) Then
                    MessageBox.Show("El encabezado de pago #" & numpago & " no ha sido creado aun." & vbNewLine & _
                                    "Verifique los datos e intente de nuevo.", "ENCABEZADO DE PAGO !!!!", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If IsNothing(fechaAplica) Then
                    MessageBox.Show("Imposible continuar con el proceso. " & _
                                    "Porque la planilla correspondientea al pago #" & numpago & " ya fue aplicada o cerrada." & vbNewLine & _
                                    "---------------------------------------------------------------" & vbNewLine & _
                                    "Número: " & txtNominaNumero.Text & vbNewLine & _
                                    "Fecha inicial: " & txtFechaInicio.Text & vbNewLine & _
                                    "Fecha final: " & txtFechaFinal.Text & vbNewLine & _
                                    "---------------------------------------------------------------" & vbNewLine & _
                                    "Verifique los datos e intente de nuevo.", "ENCABEZADO DE PAGO !!!", _
                                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                obj.Text = "&Aceptar"

            Case "&Cancelar"
                Close()

        End Select
    End Sub

    Private Sub frmNumPago_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strSQL As String
            Dim dt As New DataTable

            strSQL =
                "SELECT NUMERO_NOMINA, FECHA_INICIO, FECHA_FIN, FECHA_APLICACION" & vbNewLine &
                "FROM SOFTLAND.CRCC01.NOMINA_HISTORICO" & vbNewLine &
                "WHERE NUMERO_NOMINA = (SELECT MAX(NUMERO_NOMINA) FROM SOFTLAND.CRCC01.NOMINA_HISTORICO)"
            cnx.SQLEXEC(dt, strSQL)

            fechaAplica = IIf(IsDBNull(dt.Rows(0).Item("FECHA_INICIO")), Nothing, CType(dt.Rows(0).Item("FECHA_INICIO"), Date))
            txtFechaInicio.Text = dt.Rows(0).Item("FECHA_INICIO")
            txtFechaFinal.Text = dt.Rows(0).Item("FECHA_FIN")
            txtNominaNumero.Text = dt.Rows(0).Item("NUMERO_NOMINA")
            txtHoy.Text = Format(Now, "dd/MM/yyyy")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

End Class