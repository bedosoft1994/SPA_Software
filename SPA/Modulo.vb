Module Modulo
    Public UsuarioActivo As UserActivo
    Public RegistroActivo As RegActivo
    Public Editando As Boolean = False
    Public VentanaBusqueda As String

    Public Structure UserActivo
        Public Nombre As String
        Public Permiso_Lectura As Integer
        Public Permiso_Escritura As Integer
        Public Permiso_Impresion As Integer
        Public Permiso_Programador As Integer
        Public FechaIngreso As Date
    End Structure

    Public Structure RegActivo
        Public Empresa As Integer
        Public Servicio As Integer
        Public Empleado As Integer
        Public Cliente As Integer
    End Structure

End Module