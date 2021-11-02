Imports System.Data.SqlClient
Imports System.IO

Public Class ConexionDB

#Region "Atributos"
    Dim _strConexion As String              ' String de conexion
    Dim _servidor As String                 ' Nombre de servidor SQL
    Dim _baseDatos As String                ' Nombre de la base de datos
    Dim _usuario As String                  ' Nombre de usuario registrado en la base de datos
    Dim _clave As String                    ' Clave de usuario registrado en la base de datos
    Dim _windowsAutentication As Boolean    ' Indica si utiliza windows autentication
#End Region

#Region "Propiedades"

    Private Property strConexion() As String                ' Esta propiedad se utiliza unicamente dentro de la misma clase
        Get
            Return _strConexion
        End Get
        Set(ByVal value As String)
            _strConexion = value
        End Set
    End Property

    Public Property servidor() As String                    ' Configura y retorna el nombre del servidor
        Get
            Return _servidor
        End Get
        Set(ByVal value As String)
            _servidor = value
        End Set
    End Property
    Public Property baseDatos() As String                   ' Configura y retorna el nombre de la base de datos
        Get
            Return _baseDatos
        End Get
        Set(ByVal value As String)
            _baseDatos = value
        End Set
    End Property
    Public Property usuario() As String                     ' Configura y retorna el nombre del usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property
    Public Property clave() As String                       ' Configura y retorna el nombre de la clave
        Get
            Return _clave
        End Get
        Set(ByVal value As String)
            _clave = value
        End Set
    End Property
    Public Property windowsAutentication() As Boolean       ' Configura y retorna un true/false para utilizar o no 
        Get                                                 ' windows autentication al conectar con la base de datos
            Return _windowsAutentication
        End Get
        Set(ByVal value As Boolean)
            _windowsAutentication = value
        End Set
    End Property

#End Region

#Region "Constructor"

    Public Sub New()                                        ' Este es el contructor que inicializa las propiedades en vacio
        servidor = ""
        baseDatos = ""
        usuario = ""
        clave = ""
        windowsAutentication = False
        strConexion = ""
    End Sub

    ' Este es el constructor que inicializa las propiedades con valores y ademas carga el string de conexion en la propiedad correspondiente
    Public Sub New(ByVal pServidor As String, ByVal pBaseDatos As String, ByVal pUsuario As String, ByVal pClave As String, _
                   ByVal pWindowsAutentication As Boolean)
        servidor = pServidor
        baseDatos = pBaseDatos
        usuario = pUsuario
        clave = pClave
        windowsAutentication = pWindowsAutentication
    End Sub

#End Region

#Region "Metodos"

    Private Function conexion()
        ' Esta funcion retorna el objeto de conexion ya con un handle estalbecido
        strConexion = "Data Source='" & servidor & "'" & _
                        "; Initial Catalog= '" & baseDatos & "'" & _
                        IIf(windowsAutentication, "; Integrated Security=SSPI", _
                                                    "; User ID = '" & usuario & "'" & _
                                                    "; Password='" & clave & "'")
        Dim objConexion As New SqlClient.SqlConnection(strConexion)
        Return objConexion
    End Function

    Public Sub SQLEXEC(ByRef dtsData As DataSet, ByVal strSQL As String, ByVal tblNombre As String)
        ' Este metodo recibe como parametros un data set, un string con la consulta SQL y un string 
        ' con el nombre que va llevar el resultado de esa consulta (nombre del datatable).
        ' Si se diera el caso de un error este metodo va lanzar la excepcion.
        Try
            Dim cmdComando As New SqlClient.SqlCommand(strSQL, conexion())
            Dim dtaAdaptador As New SqlClient.SqlDataAdapter(cmdComando)
            Dim objCnx As New SqlClient.SqlConnection

            objCnx = conexion()
            objCnx.Open()

            dtaAdaptador.Fill(dtsData, tblNombre)
            dtaAdaptador.Dispose()
            cmdComando.Dispose()
            objCnx.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SQLEXEC(ByRef dt As DataTable, ByVal strSQL As String)
        ' Este metodo recibe como parametros un string con la consulta SQL y un string 
        ' con el nombre que va llevar el resultado de esa consulta (nombre del datatable).
        ' Si se diera el caso de un error este metodo va lanzar la excepcion.
        Try
            Dim cmdComando As New SqlClient.SqlCommand(strSQL, conexion())
            Dim dtaAdaptador As New SqlClient.SqlDataAdapter(cmdComando)
            Dim objCnx As New SqlClient.SqlConnection

            objCnx = conexion()
            objCnx.Open()

            dtaAdaptador.Fill(dt)
            dtaAdaptador.Dispose()
            cmdComando.Dispose()

            objCnx.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub SQLEXEC(ByVal strSQL As String)
        ' Este metodo recibe como parametro la consulta SQL pues se va utilizar unicamente
        ' para ejecutar consultas de accion (insert, update) donde no se va retornar ningun valor o resultado
        ' si la consulta  o el metodo genera un error este va lanzar la excepcion.
        Try
            Dim cmdComando As New SqlClient.SqlCommand()
            Dim objCnx As New SqlClient.SqlConnection

            objCnx = conexion()
            cmdComando.Connection = objCnx
            cmdComando.CommandText = strSQL
            objCnx.Open()
            cmdComando.ExecuteNonQuery()
            cmdComando.Dispose()
            objCnx.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function SQLEXECESCALAR(ByVal strSQL As String) As Object
        ' este metodo recibe una query en texto y retorna un object 
        ' y se va utilizar para obtener solo un dato desde la base de datos
        ' por esta razon es escalar retorna un solo valor.
        Try
            Dim result As Object
            Dim cmdComando As New SqlClient.SqlCommand()
            Dim objCnx As New SqlClient.SqlConnection

            objCnx = conexion()
            cmdComando.Connection = objCnx
            cmdComando.CommandText = strSQL
            objCnx.Open()
            result = cmdComando.ExecuteScalar()
            cmdComando.Dispose()
            objCnx.Close()
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ATTACHFILE(ByVal pAttch As Byte(), ByVal pTabla As String, ByVal pFieldName As String, ByVal pCondition As String)
        Try
            Dim objCnx As New SqlClient.SqlConnection
            Dim strSQL As String
            objCnx = conexion()
            
            If IsNothing(pAttch) Then
                Throw New Exception("No adjunto el archibo que desea almacenar")
            End If

            If pTabla = "" Then
                Throw New Exception("Nombre de tabla requerido para realizar la acción")
            End If

            If pFieldName = "" Then
                Throw New Exception("Nombre de campo requerido para realizar la acción")
            End If

            If pCondition = "" Then
                Throw New Exception("No se puede ejecutar la consulta por que para adjuntar" & vbNewLine & _
                                    "archivos a la base de datos es requerida una condicion.")
            Else
                strSQL = "UPDATE " & pTabla & " SET " & pFieldName & " = @pAttch WHERE " & pCondition
            End If

            Dim cmdComando As New SqlClient.SqlCommand(strSQL, objCnx)
            cmdComando.Parameters.AddWithValue("@pAttch", pAttch)
            objCnx.Open()
            cmdComando.ExecuteNonQuery()
            cmdComando.Dispose()
            objCnx.Close()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class