Public Class frmConfiguracion
    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UsuarioActivo.Permiso_Programador = 1 Then
            TextBox1.Text = My.Settings.d_servidor
            TextBox2.Text = My.Settings.d_usuario
            TextBox3.Text = My.Settings.d_password
            TextBox4.Text = My.Settings.d_database
            TextBox1.Tag = My.Settings.d_servidor
            TextBox2.Tag = My.Settings.d_usuario
            TextBox3.Tag = My.Settings.d_password
            TextBox4.Tag = My.Settings.d_database
            If Conexion.Ping Then
                Label7.Text = "Conexión Establecida"
                Label7.BackColor = Color.LightGreen
            Else
                Label7.Text = "Sin Conexión"
                Label7.BackColor = Color.Pink
            End If
        Else
            TabControl1.TabPages.Remove(TabPage3)
        End If
        If UsuarioActivo.Permiso_Admin = 1 Then

        Else
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
        End If
    End Sub

    Private Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        If UsuarioActivo.Permiso_Programador = 1 Then
            Guardar()
            Conexion.Close()
            Conectar()
        End If
        Close()
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        If UsuarioActivo.Permiso_Programador = 1 Then
            My.Settings.d_servidor = CType(TextBox1.Tag, String)
            My.Settings.d_usuario = CType(TextBox2.Tag, String)
            My.Settings.d_password = CType(TextBox3.Tag, String)
            My.Settings.d_database = CType(TextBox4.Tag, String)
            My.Settings.Save()
            Conexion.Close()
            Conectar()
        End If
        Close()
    End Sub

    Private Sub BProbar_Click(sender As Object, e As EventArgs) Handles BProbar.Click
        Label7.Text = "Probando Conexión..."
        Label7.BackColor = Color.LightGray

        Conexion.Close()
        Guardar()
        Conectar()
        If Conexion.Ping Then
            Label7.Text = "Conexión Establecida"
            Label7.BackColor = Color.LightGreen
        Else
            Label7.Text = "Sin Conexión"
            Label7.BackColor = Color.Pink
        End If
    End Sub

    Private Sub Guardar()
        If UsuarioActivo.Permiso_Programador = 1 Then
            My.Settings.d_servidor = TextBox1.Text
            My.Settings.d_usuario = TextBox2.Text
            My.Settings.d_password = TextBox3.Text
            My.Settings.d_database = TextBox4.Text
            My.Settings.Save()
        End If
    End Sub
End Class