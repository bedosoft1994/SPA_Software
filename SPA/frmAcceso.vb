Public Class frmAcceso
    Private Sub frmAcceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbUsuario.Text = ""
        tbPassword.Text = ""
        tbUsuario.Select()
    End Sub

    Private Function BuscarUsuario() As Boolean
        Dim Consulta As String = "SELECT * FROM Usuario WHERE Alias='" & tbUsuario.Text & "'"
        Dim adapter As MySqlDataAdapter
        Dim datos As DataSet
        Dim lista As Byte

        adapter = New MySqlDataAdapter(Consulta, Conexion)
        datos = New DataSet
        adapter.Fill(datos, "Usuario")
        lista = CByte(datos.Tables("Usuario").Rows.Count)

        If lista <> 0 Then
            Label3.Text = CType(datos.Tables("Usuario").Rows(0).Item("Alias"), String)
            Label4.Text = CType(datos.Tables("Usuario").Rows(0).Item("Clave"), String)
            Label5.Text = CType(datos.Tables("Usuario").Rows(0).Item("Lectura"), String)
            Label6.Text = CType(datos.Tables("Usuario").Rows(0).Item("Escritura"), String)
            Label7.Text = CType(datos.Tables("Usuario").Rows(0).Item("Impresion"), String)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If tbUsuario.Text = My.Settings.u_usuario And tbPassword.Text = My.Settings.u_password Then
            UsuarioActivo.Nombre = My.Settings.u_usuario
            UsuarioActivo.Permiso_Escritura = 1
            UsuarioActivo.Permiso_Lectura = 1
            UsuarioActivo.Permiso_Impresion = 1
            UsuarioActivo.Permiso_Programador = 1
            UsuarioActivo.FechaIngreso = Today()
            Exit Sub
        End If

        If BuscarUsuario() And tbPassword.Text = Label4.Text Then
            UsuarioActivo.Nombre = Label3.Text
            UsuarioActivo.Permiso_Escritura = CInt(Label5.Text)
            UsuarioActivo.Permiso_Lectura = CInt(Label6.Text)
            UsuarioActivo.Permiso_Impresion = CInt(Label7.Text)
            UsuarioActivo.Permiso_Programador = 0
            UsuarioActivo.FechaIngreso = Today()
            Exit Sub
        Else
            MsgBox("Usuario o clave inválida", vbExclamation, "Error")
            tbUsuario.Text = ""
            tbPassword.Text = ""
            tbUsuario.Select()
            Exit Sub
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        tbUsuario.Text = ""
        tbPassword.Text = ""
        UsuarioActivo.Nombre = "Sin usuario"
        UsuarioActivo.Permiso_Escritura = 0
        UsuarioActivo.Permiso_Lectura = 0
        UsuarioActivo.Permiso_Impresion = 0
        UsuarioActivo.Permiso_Programador = 0
        UsuarioActivo.FechaIngreso = Today()
        Me.Close()
    End Sub

    Private Sub tbUsuario_TextChanged(sender As Object, e As EventArgs) Handles tbUsuario.TextChanged
        If tbUsuario.Text = "" Then btnAceptar.Enabled = False Else btnAceptar.Enabled = True
    End Sub

End Class