Module Datos
    Public Conexion As MySqlConnection

    Public Sub Conectar()
        Try
            Dim ConexionStr As New MySqlConnectionStringBuilder With {
                .Server = My.Settings.d_servidor,
                .Database = My.Settings.d_database,
                .UserID = My.Settings.d_usuario,
                .Password = My.Settings.d_password
            }
            Conexion = New MySqlConnection(ConexionStr.ToString)
            Conexion.Open()
            'Conexion.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Function Consulta(ByVal Sql As String) As DataTable
        Try
            ':::Creamos el objeto DataAdapter y le pasamos los dos parametros (Instruccion, conexión)
            Dim DA As New MySqlDataAdapter(Sql, Conexion)
            ':::Creamos el objeto DataTable que recibe la informacion del DataAdapter
            Dim DT As New DataTable
            ':::Pasamos la informacion del DataAdapter al DataTable mediante la propiedad Fill
            DA.Fill(DT)
            Return DT
        Catch ex As Exception
            MsgBox(Prompt:=$"No se logro realizar la consulta por: {ex.Message}", Buttons:=CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle))
            Dim DT As DataTable = Nothing
            Return DT
        End Try
    End Function

    Public Function Operaciones(ByVal Sql As String) As Boolean
        ':::Instruccion Try para capturar errores
        Try
            ':::Creamos nuestro objeto de tipo Command que almacenara nuestras instrucciones
            ':::Necesita 2 parametros (Instruccion, conexion)
            Dim cmd As New MySqlCommand(Sql, Conexion)
            ':::Ejecutamos la instruccion mediante la propiedad ExecuteNonQuery del command
            cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox(Prompt:=$"No se logro realizar la operación por: {ex.Message}", Buttons:=CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle))
            Return False
        End Try
        ':::Cerramos la conexion
        Conexion.Close()
    End Function

End Module
