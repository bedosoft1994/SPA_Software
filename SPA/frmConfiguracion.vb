Public Class frmConfiguracion
    Private Sub FrmConfiguracion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If UsuarioActivo.Permiso_Programador = 1 And TabControl1.SelectedTab Is TabPage2 Then
            TabControl1.SelectedTab = TabPage2
        ElseIf UsuarioActivo.Permiso_Programador = 0 And TabControl1.SelectedTab Is TabPage2 Then
            MsgBox("Solo puede entrar en modo programador", MsgBoxStyle.OkOnly)
            TabControl1.SelectedTab = TabPage1
        End If
    End Sub
End Class