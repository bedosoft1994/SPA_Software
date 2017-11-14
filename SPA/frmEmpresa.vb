Public Class frmEmpresa
    Private Sub FrmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckTab1()
        BuscarEmpresa("ID", "1")
    End Sub

    Private Sub CheckTab1()
        If TabControl1.SelectedTab Is TabPage1 Then
            BNuevo.Enabled = False
            BBuscar.Enabled = False
            BEliminar.Enabled = False
        Else
            BNuevo.Enabled = True
            BBuscar.Enabled = True
            BEliminar.Enabled = True
        End If
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

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        'Boton nuevo

    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        If Editando Then 'Boton guardar
            Editando = False
            BEditar.Image = My.Resources.Editar
            BEliminar.Image = My.Resources.Borrar
            BNuevo.Enabled = True
            BBuscar.Enabled = True

        Else 'Boton editar
            Editando = True
            BEditar.Image = My.Resources.Guradar
            BEliminar.Image = My.Resources.Cancelar
            BNuevo.Enabled = False
            BBuscar.Enabled = False

        End If
        CheckTab1()
    End Sub

    Private Sub BEliminar_Click(sender As Object, e As EventArgs) Handles BEliminar.Click
        If Editando Then 'Boton cancelar

        Else 'Boton eliminar

        End If
        CheckTab1()
    End Sub

    Private Sub BBuscar_Click(sender As Object, e As EventArgs) Handles BBuscar.Click
        'Boton buscar

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        If Editando Then 'Boton salir
            If MsgBox("Los datos no se han guardado, ¿Desea perderlos?", CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo, MsgBoxStyle)) = vbYes Then
                Me.Close()
            Else
                Exit Sub
            End If
        End If
        Me.Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        CheckTab1()
    End Sub
End Class