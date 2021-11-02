Public Class frmBuscarx

    Dim _dts As New DataSet()
    Dim _dv As New DataView()

    Public strCamposMostrar As String
    Public strConsulta As String
    Public strTabla As String
    Public ReturnVal As String
    Public result As Object

    Private Sub RecNO()
        lblRegistro.Text = "Registro #" & BindingContext(_dv).Position + 1 & "/" & BindingContext(_dv).Count
    End Sub

    Private Sub frmBuscarx_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim arr As String()
            If strCamposMostrar <> "" Then
                arr = strCamposMostrar.ToUpper.Trim.Split(",")
            End If
            cnx.SQLEXEC(_dts, strConsulta, strTabla)
            _dv.Table = _dts.Tables(strTabla)

            ' cargo el combo con los nombres de columnas
            For i = 0 To _dv.Table.Columns.Count - 1
                If IsNothing(arr) Then
                    cboCriterios.Items.Add(_dv.Table.Columns(i).ColumnName.ToUpper.Trim)
                Else
                    If arr.Contains(_dv.Table.Columns(i).ColumnName.ToUpper.Trim) Then
                        cboCriterios.Items.Add(_dv.Table.Columns(i).ColumnName.ToUpper.Trim)
                    End If
                End If
            Next
            cboCriterios.SelectedIndex = 1

            ' cofiguro el datagridview 
            DataGridView1.DataSource = _dv
            DataGridView1.ReadOnly = True
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.AllowUserToDeleteRows = False
            DataGridView1.AllowUserToResizeRows = False
            DataGridView1.AllowUserToAddRows = False
            DataGridView1.MultiSelect = False
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

            For i = 0 To DataGridView1.Columns.Count - 1
                DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
                DataGridView1.Columns(i).Visible = False
                If IsNothing(arr) Then
                    DataGridView1.Columns(i).Visible = True
                Else
                    If arr.Contains(DataGridView1.Columns(i).HeaderText.ToUpper.Trim) Then
                        DataGridView1.Columns(i).Visible = True
                    End If
                End If
            Next

            ' le paso el foco al textbox
            txtDato.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkAutoAjust_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAutoAjust.CheckedChanged
        DataGridView1.AutoSizeColumnsMode = IIf(chkAutoAjust.Checked, DataGridViewAutoSizeColumnsMode.AllCells, DataGridViewAutoSizeColumnsMode.None)
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        btnAcepar.PerformClick()
    End Sub

    Private Sub DataGridView1_CellEnter(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        RecNO()
    End Sub

    Private Sub txtDato_GotFocus(sender As Object, e As System.EventArgs) Handles txtDato.GotFocus
        Dim obj As TextBox = CType(sender, TextBox)
        obj.SelectionStart = 0
        obj.SelectionLength = obj.Text.Length
    End Sub

    Private Sub txtDato_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDato.KeyPress
        Select Case e.KeyChar
            Case ChrW(27)
                btnCancelar.PerformClick()
            Case ChrW(13)
                btnBuscar.PerformClick()
        End Select
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim strFiltro As String = ""

        If txtDato.Text = "" Then
            _dv.RowFilter = ""
            Exit Sub
        End If

        Select Case _dv.Table.Rows(0).Item(cboCriterios.SelectedItem).GetType.ToString.ToUpper
            Case "SYSTEM.STRING"
                Dim arr As Array = txtDato.Text.Split(" ")
                For i = 0 To arr.Length - 1
                    strFiltro += cboCriterios.SelectedItem & " Like '%" & arr(i) & "%' AND "
                Next
                strFiltro = strFiltro.Substring(0, strFiltro.Length - 5)
            Case "SYSTEM.INT32", "SYSTEM.INT64", "SYSTEM.DOUBLE", "SYSTEM.DECIMAL"
                strFiltro = cboCriterios.SelectedItem & " = " & txtDato.Text
            Case "SYSTEM.DATETIME"
                strFiltro = cboCriterios.SelectedItem & " = '" & CType(txtDato.Text, DateTime) & "'"
            Case Else
        End Select

        Try
            _dv.RowFilter = strFiltro
            If DataGridView1.RowCount = 0 Then
                MessageBox.Show("La búsqueda no produjo resultados. Verifique los datos e intente de nuevo.", "BÚSQUEDA", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                txtDato.Text = ""
                _dv.RowFilter = ""
                txtDato.Focus()
            End If
        Catch
            MessageBox.Show("El tipo de datos del criterio seleccionado no coincide con los datos digitados.", "BÚSQUEDA", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtDato.Text = ""
            _dv.RowFilter = ""
            txtDato.Focus()
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAcepar.Click, btnCancelar.Click
        Dim obj As Button = CType(sender, Button)
        Select Case obj.Text
            Case "Aceptar"
                result = CType(DataGridView1.CurrentRow.DataBoundItem, DataRowView)
                DialogResult = Windows.Forms.DialogResult.Yes
            Case "Cancelar"
                result = Nothing
                DialogResult = Windows.Forms.DialogResult.No
        End Select
        Close()
    End Sub

    Private Sub cboCriterios_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCriterios.SelectedIndexChanged
        txtDato.Text = ""
        txtDato.Focus()
    End Sub

End Class