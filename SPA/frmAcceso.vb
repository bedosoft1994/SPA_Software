Public Class FrmAcceso
    Private Sub FrmAcceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbUsuario.Clear()
        tbPassword.Clear()
        tbUsuario.Select()
    End Sub

    Private Function BuscarUsuario() As Boolean
        Dim Consulta As String = "SELECT * FROM Usuarios WHERE Alias='" & tbUsuario.Text & "'"
        Dim adapter As MySqlDataAdapter
        Dim datos As DataSet
        Dim lista As Byte

        adapter = New MySqlDataAdapter(Consulta, Conexion)
        datos = New DataSet
        adapter.Fill(datos, "Usuarios")
        lista = CByte(datos.Tables("Usuarios").Rows.Count)

        If lista <> 0 Then
            Label3.Text = CType(datos.Tables("Usuarios").Rows(0).Item("Alias"), String)
            Label4.Text = CType(datos.Tables("Usuarios").Rows(0).Item("Clave"), String)
            Label5.Text = CType(datos.Tables("Usuarios").Rows(0).Item("Lectura"), String)
            Label6.Text = CType(datos.Tables("Usuarios").Rows(0).Item("Escritura"), String)
            Label7.Text = CType(datos.Tables("Usuarios").Rows(0).Item("Impresion"), String)
            Label8.Text = CType(datos.Tables("Usuarios").Rows(0).Item("Administrador"), String)
            Label9.Text = CType(datos.Tables("Usuarios").Rows(0).Item("idEmpresa"), String)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If tbUsuario.Text = My.Settings.u_usuario And tbPassword.Text = My.Settings.u_password Then
            UsuarioActivo.Nombre = My.Settings.u_usuario
            UsuarioActivo.Permiso_Escritura = 1
            UsuarioActivo.Permiso_Lectura = 1
            UsuarioActivo.Permiso_Impresion = 1
            UsuarioActivo.Permiso_Admin = 1
            UsuarioActivo.Permiso_Programador = 1
            RegistroActivo.Empresa = -1
            UsuarioActivo.FechaIngreso = Today()
            Exit Sub
        End If
        If Not Conexion.Ping Then
            Conectar()
        End If
        If Conexion.Ping Then
            If BuscarUsuario() And tbPassword.Text = Label4.Text Then
                UsuarioActivo.Nombre = Label3.Text
                UsuarioActivo.Permiso_Escritura = CInt(Label5.Text)
                UsuarioActivo.Permiso_Lectura = CInt(Label6.Text)
                UsuarioActivo.Permiso_Impresion = CInt(Label7.Text)
                UsuarioActivo.Permiso_Admin = CInt(Label8.Text)
                UsuarioActivo.Permiso_Programador = 0
                UsuarioActivo.FechaIngreso = Today()
                RegistroActivo.Empresa = CInt(Label9.Text)
                Exit Sub
            Else
                MsgBox("Usuario o clave inválida", vbExclamation, "Error")
                tbUsuario.Clear()
                tbPassword.Clear()
                tbUsuario.Select()
            End If
        Else
            MsgBox(Prompt:="No hay conexión a la Base de Datos", Buttons:=CType(MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, MsgBoxStyle))
            BtnCancelar_Click(sender, e)
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        tbUsuario.Text = ""
        tbPassword.Text = ""
        UsuarioActivo.Nombre = "Sin usuario"
        UsuarioActivo.Permiso_Escritura = 0
        UsuarioActivo.Permiso_Lectura = 0
        UsuarioActivo.Permiso_Impresion = 0
        UsuarioActivo.Permiso_Admin = 0
        UsuarioActivo.Permiso_Programador = 0
        UsuarioActivo.FechaIngreso = Today()
        RegistroActivo.Empresa = -1
        Me.Close()
    End Sub

    Private Sub TbUsuario_TextChanged(sender As Object, e As EventArgs) Handles tbUsuario.TextChanged
        If tbUsuario.Text = "" Then btnAceptar.Enabled = False Else btnAceptar.Enabled = True
    End Sub

End Class