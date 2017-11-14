Public Class FrmClientes
    Dim Consulta As String = ""
    Dim adapter As MySqlDataAdapter
    Dim datos As DataSet
    Dim lista As Byte
    Dim Fila As Data.DataRow

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuscarCliente("Cedula", "12")
    End Sub

    Public Function BuscarCliente(ByVal BuscarPor As String, ByVal Busqueda As String) As Boolean
        Select Case BuscarPor
            Case "Cedula"
                Consulta = $"SELECT * FROM Clientes WHERE idCliente='{Busqueda}'"
            Case "Nombre"
                Consulta = $"SELECT * FROM Clientes WHERE Nombres='{Busqueda}'"
            Case "Apellido"
                Consulta = $"SELECT * FROM Clientes WHERE Apellidos='{Busqueda}'"
        End Select

        adapter = New MySqlDataAdapter(Consulta, Conexion)
        datos = New DataSet
        adapter.Fill(datos, "Clientes")
        lista = CByte(datos.Tables("Clientes").Rows.Count)

        If lista <> 0 Then
            Label1.Text = CType(datos.Tables("Clientes").Rows(0).Item("idCliente"), String)
            Label2.Text = CType(datos.Tables("Clientes").Rows(0).Item("idEmpresa"), String)
            Label3.Text = CType(datos.Tables("Clientes").Rows(0).Item("Identificacion"), String)
            Label4.Text = CType(datos.Tables("Clientes").Rows(0).Item("Nombres"), String)
            Label5.Text = CType(datos.Tables("Clientes").Rows(0).Item("Apellidos"), String)
            Label6.Text = CType(CType(datos.Tables("Clientes").Rows(0).Item("FechaNacimiento"), Date), String)
            Label7.Text = CType(datos.Tables("Clientes").Rows(0).Item("LugarNacimiento"), String)
            Label8.Text = CType(datos.Tables("Clientes").Rows(0).Item("Genero"), String)
            Label9.Text = CType(datos.Tables("Clientes").Rows(0).Item("Direccion"), String)
            Label10.Text = CType(datos.Tables("Clientes").Rows(0).Item("Telefono1"), String)
            Label11.Text = CType(datos.Tables("Clientes").Rows(0).Item("Telefono2"), String)
            Label12.Text = CType(datos.Tables("Clientes").Rows(0).Item("Correo"), String)
            Label13.Text = CType(datos.Tables("Clientes").Rows(0).Item("Observacion"), String)
            Label14.Text = CType(datos.Tables("Clientes").Rows(0).Item("CreadoPor"), String)
            Label15.Text = CType(CType(datos.Tables("Clientes").Rows(0).Item("CreadoFecha"), Date), String)
            Label16.Text = CType(datos.Tables("Clientes").Rows(0).Item("ModificadoPor"), String)
            Label17.Text = CType(CType(datos.Tables("Clientes").Rows(0).Item("ModificadoFecha"), Date), String)
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        'Boton nuevo
        Dim adapter1 = CrearAdapterCliente(Conexion)
        MsgBox(adapter1.SelectCommand.CommandText)
        MsgBox(adapter1.UpdateCommand.CommandText)
        MsgBox(adapter1.InsertCommand.CommandText)
        MsgBox(adapter1.DeleteCommand.CommandText)

    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click

        Fila = datos.Tables("Clientes").NewRow

        Fila("Nombres") = TextBox2.Text

        datos.Tables("Clientes").Rows.Add(Fila)

        adapter.Update(datos.Tables(name:="Clientes"))
        Conexion.Ping()

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
    End Sub

    Private Sub BEliminar_Click(sender As Object, e As EventArgs) Handles BEliminar.Click
        If Editando Then 'Boton cancelar

        Else 'Boton eliminar

        End If
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

    Public Function CrearAdapterCliente(ByVal connection As MySqlConnection) As MySqlDataAdapter

        Dim Adaptador As MySqlDataAdapter = New MySqlDataAdapter()
        Dim Comando As MySqlCommand

        ' Crear el SelectCommand
        Comando = New MySqlCommand("SELECT * FROM Clientes", connection)
        Adaptador.SelectCommand = Comando

        ' Crear el InsertCommand
        Comando = New MySqlCommand()
        Adaptador.InsertCommand = Comando

        ' Crear el DeleteCommand
        Comando = New MySqlCommand()
        Adaptador.DeleteCommand = Comando

        ' Crear el UpdateCommand
        Comando = New MySqlCommand()
        Adaptador.UpdateCommand = Comando

        Return Adaptador
    End Function

End Class