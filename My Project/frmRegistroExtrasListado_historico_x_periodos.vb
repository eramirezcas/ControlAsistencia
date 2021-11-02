Public Class frmRegistroExtrasListado_historico_x_periodos666
    Dim param As New DataTable
    Dim autoclose As Boolean
    Dim vacio As Boolean

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnFiltro.Click
        Dim frm As New frmRegistroExtrasListado_historico_x_periodos_filtros()
        frm.Owner = Me
        frm.frmParent = Me
        frm.MdiParent = Me.MdiParent
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.Show()
    End Sub

    Private Sub frmRegistroExtrasListado_historico_x_periodos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not System.IO.File.Exists("C:\APROGRAMAS\RPTHEXCONF.XML") Then
            Xml.XmlWriter.Create("C:\APROGRAMAS\RPTHEXCONF.XML")
            vacio = True
        End If

        Dim reader As New System.Xml.XmlTextReader("C:\APROGRAMAS\RPTHEXCONF.XML")
        vacio = IIf(Not reader.HasValue(), True, False)

        If vacio Then
            If MessageBox.Show("Para que esta consulta funcione correctamente debe de especificar parámetros." & vbNewLine &
                               "¿ Desea realizar este proceso ?" _
                               , "DEFINIR PARÁMETROS !!!" _
                               , MessageBoxButtons.YesNo _
                               , MessageBoxIcon.Question) = DialogResult.Yes Then
                autoclose = False
            Else
                autoclose = True
            End If
        End If

    End Sub

    Private Sub frmRegistroExtrasListado_historico_x_periodos_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If Not autoclose And vacio Then
            btnFiltro.PerformClick()
        End If

        If autoclose Then
            Me.Close()
        End If
    End Sub
End Class