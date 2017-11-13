Public Class frmEmpresa
    Private Sub frmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarEmpresa("ID", "1")
    End Sub

    Private Function BuscarEmpresa(ByVal BuscarPor As String, ByVal Busqueda As String) As Boolean
        Dim Consulta As String = ""
        Select Case BuscarPor
            Case "ID"
                Consulta = $"SELECT * FROM Empresa WHERE idEmpresa='{Busqueda}'"
            Case "Nombre"
                Consulta = $"SELECT * FROM Empresa WHERE NIT='{Busqueda}'"
        End Select

        Dim adapter As MySqlDataAdapter
        Dim datos As DataSet
        Dim lista As Byte

        adapter = New MySqlDataAdapter(Consulta, Conexion)
        datos = New DataSet
        adapter.Fill(datos, "Empresa")
        lista = CByte(datos.Tables("Empresa").Rows.Count)

        If lista <> 0 Then
            Label1.Text = CType(datos.Tables("Empresa").Rows(0).Item("idEmpresa"), String)
            Label2.Text = CType(datos.Tables("Empresa").Rows(0).Item("Nombre"), String)
            Label3.Text = CType(datos.Tables("Empresa").Rows(0).Item("Nit"), String)
            Label4.Text = CType(datos.Tables("Empresa").Rows(0).Item("Direccion"), String)
            Label5.Text = CType(datos.Tables("Empresa").Rows(0).Item("Telefono"), String)
            Label6.Text = CType(datos.Tables("Empresa").Rows(0).Item("Correo"), String)
            Label7.Text = CType(datos.Tables("Empresa").Rows(0).Item("Representante"), String)
            Label8.Text = CType(datos.Tables("Empresa").Rows(0).Item("MovilRepresentante"), String)
            Label9.Text = CType(datos.Tables("Empresa").Rows(0).Item("CreadoPor"), String)
            Label10.Text = CType(CType(datos.Tables("Empresa").Rows(0).Item("CreadoFecha"), Date), String)
            Label11.Text = CType(datos.Tables("Empresa").Rows(0).Item("ModificadoPor"), String)
            Label12.Text = CType(CType(datos.Tables("Empresa").Rows(0).Item("ModificadoFecha"), Date), String)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Boton nuevo

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Editando Then 'Boton guardar
            Editando = False
            Button2.Image = SPA.My.Resources.Resources.Editar
            Button3.Image = SPA.My.Resources.Resources.Borrar
            Button1.Enabled = True
            Button4.Enabled = True

        Else 'Boton editar
            Editando = True
            Button2.Image = SPA.My.Resources.Resources.Guradar
            Button3.Image = SPA.My.Resources.Resources.Cancelar
            Button1.Enabled = False
            Button4.Enabled = False

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Editando Then 'Boton cancelar

        Else 'Boton eliminar

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Boton buscar

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If Editando Then 'Boton salir
            If MsgBox("Los datos no se han guardado, ¿Desea perderlos?", CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo, MsgBoxStyle)) = vbYes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub
End Class