Public Class frmExeleador

#Region "Atributos"
    Dim _dts As DataSet
    Dim _tabla As String
    Dim _titulo As String
    Dim _filtro As String
    Dim _pntOrigen As Form
#End Region
#Region "Propiedades"
    Public Property dts As DataSet
        Get
            Return _dts
        End Get
        Set(value As DataSet)
            _dts = value
        End Set
    End Property
    Public Property tabla As String
        Get
            Return _tabla
        End Get
        Set(value As String)
            _tabla = value
        End Set
    End Property
    Public Property titulo As String
        Get
            Return _titulo
        End Get
        Set(value As String)
            _titulo = value
        End Set
    End Property
    Public Property filtro As String
        Get
            Return _filtro
        End Get
        Set(value As String)
            _filtro = value
        End Set
    End Property
    Public Property pntOrigern As Form
        Get
            Return _pntOrigen
        End Get
        Set(value As Form)
            _pntOrigen = value
        End Set
    End Property
#End Region

    Private Sub frmExeleador_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        pntOrigern.Enabled = True
    End Sub

    Private Sub frmExeleador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        For i = 0 To dts.Tables(tabla).Columns.Count - 1
            listaCampos.Items.Add(dts.Tables(tabla).Columns(i).ColumnName.ToUpper)
        Next
        pntOrigern.Enabled = False
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click, ToolStripButton1.Click
        Dim obj As ToolStripButton = CType(sender, ToolStripButton)

        Select Case obj.Text
            Case "&Generar"

                If camposSeleccion.Items.Count = 0 Then
                    MessageBox.Show("Debe de seleccionar al menos un campo para realizar el proceso.", "EXPORTAR A EXCEL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                    Exit Sub
                End If

                Dim arrCols(camposSeleccion.Items.Count - 1) As String
                For i = 0 To camposSeleccion.Items.Count - 1
                    arrCols(i) = camposSeleccion.Items(i)
                Next

                Dim ddt As New DataTable()
                Dim odt As DataTable = IIf(dts.Tables.Count = 1, dts.Tables(0), dts.Tables(tabla))

                ddt = odt.DefaultView.ToTable("tblResult", False, arrCols)

                Dim oxls As New clsExceleador(ddt, "", "")
                oxls.progreso = ToolStripProgressBar1
                oxls.titulo = titulo
                oxls.filtro = filtro
                oxls.generar()
                DialogResult = Windows.Forms.DialogResult.OK
            Case "&Salir"
                DialogResult = Windows.Forms.DialogResult.OK
                Close()
        End Select
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click, Button3.Click, Button2.Click, Button1.Click
        Dim obj As Button = CType(sender, Button)
        Select Case obj.Text
            Case ">"
                If listaCampos.SelectedIndex > -1 Then
                    camposSeleccion.Items.Add(listaCampos.Items(listaCampos.SelectedIndex))
                    listaCampos.Items.Remove(listaCampos.Items(listaCampos.SelectedIndex))
                End If
            Case ">>"
                If listaCampos.Items.Count > 0 Then
                    For i = 0 To listaCampos.Items.Count - 1
                        camposSeleccion.Items.Add(listaCampos.Items(i))
                    Next
                    listaCampos.Items.Clear()
                End If
            Case "<"
                If camposSeleccion.SelectedIndex > -1 Then
                    listaCampos.Items.Add(camposSeleccion.Items(camposSeleccion.SelectedIndex))
                    camposSeleccion.Items.Remove(camposSeleccion.Items(camposSeleccion.SelectedIndex))
                End If
            Case "<<"
                If camposSeleccion.Items.Count > 0 Then
                    For i = 0 To camposSeleccion.Items.Count - 1
                        listaCampos.Items.Add(camposSeleccion.Items(i))
                    Next
                    camposSeleccion.Items.Clear()
                End If
        End Select
    End Sub

    Private Sub listaCampos_DoubleClick(sender As System.Object, e As System.EventArgs) Handles listaCampos.DoubleClick, camposSeleccion.DoubleClick
        Dim obj As ListBox = CType(sender, ListBox)
        Select Case obj.Name
            Case "listaCampos"
                If listaCampos.Items.Count > 0 Then
                    camposSeleccion.Items.Add(listaCampos.Items(listaCampos.SelectedIndex))
                    listaCampos.Items.Remove(listaCampos.Items(listaCampos.SelectedIndex))
                End If
            Case "camposSeleccion"
                If camposSeleccion.Items.Count > 0 Then
                    listaCampos.Items.Add(camposSeleccion.Items(camposSeleccion.SelectedIndex))
                    camposSeleccion.Items.Remove(camposSeleccion.Items(camposSeleccion.SelectedIndex))
                End If
        End Select
    End Sub

    Private Sub ToolStripProgressBar1_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles ToolStripProgressBar1.Paint
        Dim obj As ToolStripProgressBar = CType(sender, ToolStripProgressBar)
        Select Case obj.Value
            Case 0
                tsl.Text = "0%"
            Case obj.Maximum
                tsl.Text = "100%"
            Case Else
                tsl.Text = obj.Value & "%"
        End Select
    End Sub
End Class
