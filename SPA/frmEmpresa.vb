Public Class frmEmpresa
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Editando Then
            Editando = False
            Button1.Text = "Sin editar"
        Else
            Editando = True
            Button1.Text = "Editando"
        End If
    End Sub
End Class