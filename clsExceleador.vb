Imports Microsoft.Office.Interop

Public Class clsExceleador

#Region "Atributos"

    ' Estos atributos son de uso interno de la clase
    Dim _xlApp As Microsoft.Office.Interop.Excel.Application
    Dim _xlWkb As Microsoft.Office.Interop.Excel.Workbook
    Dim _xlSht As Microsoft.Office.Interop.Excel.Worksheet
    Dim _fil As Integer = 1
    Dim _col As Integer = 1

    ' Estos atributos son para parametrizar los datos de encabezado del archivo
    Dim _tabla As New DataTable()
    Dim _titulo As String
    Dim _Filtro As String
    Dim _progreso As ToolStripProgressBar

#End Region
#Region "Propiedades"

    Public Property tabla As DataTable
        Get
            Return _tabla
        End Get
        Set(value As DataTable)
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
            Return _Filtro
        End Get
        Set(value As String)
            _Filtro = value
        End Set
    End Property
    Public Property progreso As ToolStripProgressBar
        Get
            Return _progreso
        End Get
        Set(value As ToolStripProgressBar)
            _progreso = value
        End Set
    End Property

#End Region
#Region "Constructor"
    Public Sub New(ByVal pTabla As DataTable, ByVal pTitulo As String, ByVal pFiltro As String)
        tabla = pTabla
        titulo = pTitulo
        filtro = pFiltro
    End Sub
#End Region
#Region "Metodos"

    Private Function xlLetra(ByVal colCnt As Integer) As String
        Dim result As String = ""
        If colCnt <= 25 Then
            result = Chr(65 + colCnt)
        Else
            result = Chr(65 + colCnt - 1)
        End If
        Return result
    End Function
    Private Function xlCol(ByVal colCnt As Integer, ByVal nfila As Integer) As String
        Dim result As String = ""
        Dim count As Integer = colCnt - 1

        If colCnt <= 26 Then
            Return xlLetra(colCnt - 1) & nfila
        End If

        Dim cnt26 As Integer = Int(colCnt / 26)
        Dim rest As Integer = count - (cnt26 * 26)

        result += xlLetra(cnt26 - 1) & xlLetra(rest)

        Return result & nfila
    End Function
    Public Sub generar()
        Dim rango As String = ""

        Dim objApp As Excel.Application
        Dim objBook As Excel._Workbook
        Dim _xlWkb As Excel.Workbooks
        Dim objSheets As Excel.Sheets
        Dim objSheet As Excel._Worksheet
        Dim range As Excel.Range

        ' Create a new instance of Excel and start a new workbook.
        _xlApp = New Excel.Application()
        _xlWkb = _xlApp.Workbooks
        '_xlWkb = _xlApp.Workbooks.Add()
        objBook = _xlWkb.Add
        objSheets = objBook.Worksheets
        _xlSht = objSheets(1)

        'Dim _xlApp = CreateObject("Excel.Application")
        '_xlSht = _xlWkb.ActiveSheet

        rango = xlCol(1, 1) & ":" & xlCol(tabla.Columns.Count, 1)
        _xlSht.Cells(_fil, _col) = "COSTA RICA COUNTRY CLUB S.A."
        _xlSht.Cells.Range(rango).MergeCells = True
        _xlSht.Cells.Range(rango).Font.Bold = True
        _xlSht.Cells.Range(rango).Font.Size = 12

        rango = xlCol(1, 2) & ":" & xlCol(tabla.Columns.Count, 2)
        _xlSht.Cells(_fil + 1, _col) = titulo
        _xlSht.Cells.Range(rango).MergeCells = True
        _xlSht.Cells.Range(rango).Font.Bold = True
        _xlSht.Cells.Range(rango).Font.Size = 12

        rango = xlCol(1, 3) & ":" & xlCol(tabla.Columns.Count, 3)
        _xlSht.Cells(_fil + 2, _col) = filtro
        _xlSht.Cells.Range(rango).MergeCells = True
        _xlSht.Cells.Range(rango).Font.Bold = True
        _xlSht.Cells.Range(rango).Font.Size = 12

        For c = 0 To tabla.Columns.Count - 1
            _xlSht.Cells(_fil + 4, c + 1) = tabla.Columns(c).ColumnName.ToUpper
            _xlSht.Cells(_fil + 4, c + 1).font.bold = True
        Next

        For f = 0 To tabla.Rows.Count - 1
            For c = 0 To tabla.Columns.Count - 1
                Dim xc As String = IIf(TypeName(tabla.Rows(f).Item(c)) = "Date" Or TypeName(tabla.Rows(f).Item(c)) = "DateTime", "'", "")
                _xlSht.Cells(f + 6, c + 1) = xc.Trim() & tabla.Rows(f).Item(c).ToString
            Next
            If Not IsNothing(progreso) Then
                progreso.Value = Int(((f / (tabla.Rows.Count)) * 100))
            End If
        Next
        _xlSht.Columns.AutoFit()
        _xlApp.Visible = True
    End Sub


#End Region

End Class
