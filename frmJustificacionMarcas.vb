Public Class frmJustificacionMarcas

#Region "Atributos"
    Dim _id_linea As Integer
    Dim _dts As DataSet
    Dim _codigo As String
    Dim _nombre As String
    Dim _entrada As String
    Dim _formaAnterior As Form
#End Region
#Region "Propiedades"
    Public Property id_linea As Integer
        Get
            Return _id_linea
        End Get
        Set(value As Integer)
            _id_linea = value
        End Set
    End Property
    Public Property dts As DataSet
        Get
            Return _dts
        End Get
        Set(value As DataSet)
            _dts = value
        End Set
    End Property
    Public Property codigo As String
        Get
            Return _codigo
        End Get
        Set(value As String)
            _codigo = value
        End Set
    End Property
    Public Property nombre As String
        Get
            Return _nombre
        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property
    Public Property entrada As String
        Get
            Return _entrada
        End Get
        Set(value As String)
            _entrada = value
        End Set
    End Property
    Public Property formaAnterior As Form
        Get
            Return _formaAnterior
        End Get
        Set(value As Form)
            _formaAnterior = value
        End Set
    End Property
#End Region

    Private Sub btnDescartar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartar.Click
        Close()
    End Sub
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Close()
    End Sub

    Private Sub frmJustificacionMarcas_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        formaAnterior.Enabled = True
    End Sub

    Private Sub frmJustificacionMarcas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        formaAnterior.Enabled = False
        txtJustificacion.DataBindings.Add("text", dts, "tbl_marcas_tmp.justificacion")

    End Sub
End Class