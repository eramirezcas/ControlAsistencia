Public Class frmFiltros

    Protected Class item
        Dim _campo As String
        Dim _tipo As String

        Public Property campo As String
            Get
                Return _campo
            End Get
            Set(value As String)
                _campo = value
            End Set
        End Property

        Public Property tipo As String
            Get
                Return _tipo
            End Get
            Set(value As String)
                _tipo = value
            End Set
        End Property

        Public Sub New()
            campo = ""
            tipo = ""
        End Sub

        Public Sub New(ByVal pCampo As String, ByVal pTipo As String)
            campo = pCampo
            tipo = pTipo
        End Sub

    End Class
    Dim listItem As New ArrayList()

    Public Sub AddField(ByVal campo As String, ByVal tipo As String)
        If listItem.Count = 0 Then
            listItem.Add(New item())
        End If
        listItem.Add(New item(campo, tipo))
    End Sub

    Private Sub limpiar()
        cboCampo.SelectedIndex = 0
        cboOperador.SelectedIndex = 0

        cboAndOr.SelectedIndex = 0
    End Sub

    Private Sub frmFiltros_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        AddField("ERICK", "STRING")
        AddField("KENNETH", "DATE")
        AddField("ROGER", "INTEGER")
        AddField("OSCAR", "BOOLEAN")

        cboCampo.DataSource = listItem
        cboCampo.DisplayMember = "campo"
        cboCampo.ValueMember = "tipo"
        cboBoolean.SelectedIndex = 0
        dtDateTime.Value = Now
        txtTextBox.Text = ""

    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        limpiar()
    End Sub

    Private Sub cboCampo_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles cboCampo.SelectedValueChanged
        Select Case cboCampo.SelectedValue.ToString.ToUpper.Trim
            Case "STRING", "INTEGER", "DOUBLE", "SHORT", "DECIMAL"
                MuestraControl(True, False, False)

            Case "DATE", "DATETIME"
                MuestraControl(False, True, False)

            Case "BOOLEAN"
                MuestraControl(False, False, True)
        End Select
    End Sub

    Private Sub MuestraControl(ByVal p1 As Boolean, ByVal p2 As Boolean, ByVal p3 As Boolean)
        txtTextBox.Visible = p1
        dtDateTime.Visible = p2
        cboBoolean.Visible = p3
    End Sub

    Private Function retor_uno_tres() As String
        Dim result As String = ""
        If txtTextBox.Visible Then
            Return txtTextBox.Text
        End If
        If dtDateTime.Visible Then
            Return CType(dtDateTime.Value, DateTime).ToString.Trim
        End If
        If cboBoolean.Visible Then
            Return IIf(cboBoolean.SelectedText = "SI", 1, 0)
        End If
    End Function

End Class