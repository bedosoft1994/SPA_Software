Imports MySql.Data.MySqlClient

Module Modulo
    Public EstadoConexion As Boolean = False
    Public UsuarioActivo As UserActivo
    Public Conexion As MySqlConnection
    Public Editando As Boolean = False

    Public Sub ConectarDatos()
        Try
            Dim ConexionStr As New MySqlConnectionStringBuilder With {
                .Server = My.Settings.d_servidor,
                .Database = My.Settings.d_database,
                .UserID = My.Settings.d_usuario,
                .Password = My.Settings.d_password
            }
            Conexion = New MySqlConnection(ConexionStr.ToString)
            Conexion.Open()
            EstadoConexion = True ' cambiar por conexion.ping()
        Catch ex As Exception
            EstadoConexion = False
        End Try
    End Sub

    Public Structure UserActivo
        Public Nombre As String
        Public Permiso_Lectura As Integer
        Public Permiso_Escritura As Integer
        Public Permiso_Impresion As Integer
        Public Permiso_Programador As Integer
        Public FechaIngreso As Date
    End Structure

End Module