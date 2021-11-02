Public Class frmRegistroExtrasBitacoraDoc

    Dim dts As New DataSet
    Public pnt As Form
    Public ndoc As Integer

    Private Sub frmRegistroExtrasBitacoraDoc_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pnt.Enabled = True
    End Sub

    Private Sub frmRegistroExtrasBitacoraDoc_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            pnt.Enabled = False
            Me.MdiParent = pnt.MdiParent
            _titulo1._text = Me.Text

            '-----------------------------------------------------------------------------------------------------------------------------
            'CARGO LOS DATOS DE LA BITACORA DEL DOCUMENTO

            If dts.Tables.Contains("tbl_bitacoraDoc") Then
                dts.Tables.Remove("tbl_bitacoraDoc")
            End If

            Dim strSQL As String = "SELECT nDocumento, nivel_estado, estado, detalle, fecha, username, computername" & vbNewLine & _
                            "FROM tbl_extras_bitacora WHERE nDocumento = " & ndoc & _
                            " ORDER BY FECHA DESC"
            cnx.SQLEXEC(dts, strSQL, "tbl_bitacoraDoc")

            DataGridView1.DataSource = dts
            DataGridView1.DataMember = "tbl_bitacoraDoc"
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.ReadOnly = True
            DataGridView1.RowHeadersVisible = False
            DataGridView1.Font = New Font("Arial", 7, FontStyle.Regular)

            DataGridView1.Columns(0).Visible = False
            DataGridView1.Columns(1).Visible = False


            DataGridView1.Columns(0).HeaderText = "DOC"
            DataGridView1.Columns(1).HeaderText = "NIV."
            DataGridView1.Columns(2).HeaderText = "ESTADO"
            DataGridView1.Columns(3).HeaderText = "DETALLE"
            DataGridView1.Columns(4).HeaderText = "FECHA"
            DataGridView1.Columns(5).HeaderText = "USUARIO"
            DataGridView1.Columns(6).HeaderText = "COMPUTADOR"

            DataGridView1.Columns(0).Width = 30
            DataGridView1.Columns(1).Width = 30
            DataGridView1.Columns(2).Width = 300
            DataGridView1.Columns(3).Width = 650
            DataGridView1.Columns(4).Width = 120
            DataGridView1.Columns(5).Width = 90
            DataGridView1.Columns(6).Width = 90

            DataGridView1.Columns(0).DisplayIndex = 3
            DataGridView1.Columns(1).DisplayIndex = 4
            DataGridView1.Columns(2).DisplayIndex = 1
            DataGridView1.Columns(3).DisplayIndex = 2
            DataGridView1.Columns(4).DisplayIndex = 0
            DataGridView1.Columns(5).DisplayIndex = 5
            DataGridView1.Columns(6).DisplayIndex = 6
            '-----------------------------------------------------------------------------------------------------------------------------
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Close()
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class