Public Class frmMarcasalHist

    Private Sub frmMarcasalHist_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dt As New DataTable

            GroupBox1.Visible = False
            GroupBox2.Visible = False
            GroupBox3.Visible = False

            Dim strSQL As String =
                "SELECT" & vbNewLine &
                    "(SELECT COUNT(*) AS cant FROM tbl_marcas_justificadas_act) as REGISTROS," & vbNewLine &
                    "(SELECT NUMERO_NOMINA FROM SOFTLAND.CRCC01.NOMINA_HISTORICO" & vbNewLine &
                    " WHERE (NUMERO_NOMINA = (SELECT DISTINCT numpago COLLATE DATABASE_DEFAULT FROM tbl_marcas_justificadas_act))" & vbNewLine &
                    ") AS NUMPAGO," & vbNewLine &
                    "(SELECT FECHA_INICIO FROM SOFTLAND.CRCC01.NOMINA_HISTORICO" & vbNewLine &
                    " WHERE (NUMERO_NOMINA = (SELECT DISTINCT numpago COLLATE DATABASE_DEFAULT FROM tbl_marcas_justificadas_act))" & vbNewLine &
                    ") AS FECHAINICIAL," & vbNewLine &
                    "(SELECT FECHA_FIN FROM SOFTLAND.CRCC01.NOMINA_HISTORICO" & vbNewLine &
                    " WHERE (NUMERO_NOMINA = (SELECT DISTINCT numpago COLLATE DATABASE_DEFAULT FROM tbl_marcas_justificadas_act))" & vbNewLine &
                    ") AS FECHAFINAL"
            cnx.SQLEXEC(dt, strSQL)

            If dt.Rows(0).Item("Registros") = 0 Then
                GroupBox2.Visible = True
                btnGuardar.Enabled = False
                Exit Sub
            End If

            txtRegistros.Text = dt.Rows(0).Item("Registros")
            txtNumpago.Text = IIf(IsDBNull(dt.Rows(0).Item("numpago")), "", dt.Rows(0).Item("numpago"))
            txtFechaInicial.Text = IIf(IsDBNull(dt.Rows(0).Item("fechainicial")), "", dt.Rows(0).Item("fechainicial"))
            txtFechaFinal.Text = IIf(IsDBNull(dt.Rows(0).Item("fechafinal")), "", dt.Rows(0).Item("fechafinal"))
            GroupBox1.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnDescartar_Click(sender As System.Object, e As System.EventArgs) Handles btnDescartar.Click
        Close()
    End Sub

    Private Sub btnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles btnGuardar.Click
        Try
            If MessageBox.Show("Se dispone a realizar el cierre de marcas." & vbNewLine & vbNewLine & _
                               "Planilla #" & txtNumpago.Text.Trim & "." & vbNewLine & vbNewLine & _
                               "¿Seguro de proceder?", "CIERRE DE MARCAS", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            Dim strSQL As String = _
                "INSERT INTO tbl_marcas_justificadas_hist (codigo, nombre, tipo, dia," & vbNewLine & _
                "	fecha, horario, marca, diferencia, circunstancia, justificacion," & vbNewLine & _
                "	id_horario, id_interno, id_linea, departamento, seccion, numpago, ubicacion)" & vbNewLine & _
                "SELECT codigo, nombre, tipo, dia, fecha, horario, marca, diferencia," & vbNewLine & _
                "	circunstancia, justificacion, id_horario, id_interno, id_linea," & vbNewLine & _
                "	departamento, seccion, numpago, ubicacion" & vbNewLine & _
                "FROM tbl_marcas_justificadas_act" & vbNewLine & vbNewLine & _
                "DELETE FROM tbl_marcas_justificadas_act"

            cnx.SQLEXEC(strSQL)
            
            GroupBox1.Visible = False
            GroupBox3.Visible = True
            btnGuardar.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub
End Class