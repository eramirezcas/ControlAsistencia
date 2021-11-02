Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Reflection.Assembly

Public Class _titulo

#Region "Atributo"
    Dim _textVal As String
    Dim _foreColorVal As Color
#End Region

#Region "Propiedades"
    Public Property _text As String
        Get
            Return _textVal
        End Get
        Set(ByVal value As String)
            _textVal = value
        End Set
    End Property

    Public Property _foreColor As Color
        Get
            Return _foreColorVal
        End Get
        Set(ByVal value As Color)
            _foreColorVal = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Private Sub GroupBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles GroupBox1.Paint
        Dim myGraphics As Graphics = e.Graphics
        Dim x As Int16 = sender.Size.Width
        Dim y As Int16 = sender.Size.Height
        Dim myPantalla As Rectangle = New Rectangle(0, 0, x, y)
        Dim Relleno As LinearGradientBrush = New LinearGradientBrush(myPantalla, Color.Black, Color.White, LinearGradientMode.Vertical)
        myGraphics.FillRectangle(Relleno, myPantalla)
    End Sub

    Private Sub _titulo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbltext.Text = _text
        lbltext.ForeColor = _foreColor
    End Sub

#End Region

End Class
