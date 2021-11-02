Imports System.IO

Module mdConfing
    Public pNombreUser As String
    Public pUser As String
    Public pempID As Integer
    Public pEsJefe As Boolean
    Public pEsGerente As Boolean
    Public verTodos As Boolean

    'Private Function leerDatosConexion() As String
    '    Dim Contents As String = ""
    '    Dim bAns As Boolean = False
    '    Dim objReader As StreamReader
    '    Try
    '        'objReader = New StreamReader("\\SIXAOLA\POAS_EXES\CNX.TXT", True)
    '        'Contents = objReader.ReadToEnd()
    '        'objReader.Close()
    '        bAns = True
    '    Catch Ex As Exception
    '        MessageBox.Show(Ex.Message & vbNewLine & vbNewLine & "El sistema se va cerrar verifique e intente mas tarde", "ERROR !!!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End
    '    End Try
    '    Return Contents
    'End Function

    'Dim cnxDatos As String = leerDatosConexion()
    'Dim arrDatos As Array = cnxDatos.Split(",")

    'Public cnx As New ConexionDB(arrDatos(0).ToString.Trim, _
    '                             arrDatos(1).ToString.Trim, _
    '                             arrDatos(2).ToString.Trim, _
    '                             arrDatos(3).ToString.Trim, _
    '                             CType(arrDatos(4), Boolean))

    Public cnx As New ConexionDB("savegre\savegre", "rrhh", "sa", "Sa123456", False)

End Module
