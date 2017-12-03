Public Class frmServicios
    Dim DataTabletTotal As New DataTable
    Dim ListaTotal As Byte

    Dim DataTabletConsulta As New DataTable
    Dim ListaConsulta As Byte

    Dim NuevoRegistro As Boolean

    Private Sub FrmServicios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataTabletTotal = Consulta(Sql:=Comandos(Cual:="Select"))
        ListaTotal = CByte(DataTabletTotal.Rows.Count)
        If ListaTotal = 0 Then
            BNuevo.Enabled = True
            BEditar.Enabled = False
            BEliminar.Enabled = False
            BBuscar.Enabled = False
        Else
            BNuevo.Enabled = True
            BEditar.Enabled = False
            BEliminar.Enabled = False
            BBuscar.Enabled = True
        End If
        EstadoTextBox(False)
        RegistroActivo.Servicio = -1
        NuevoRegistro = False
    End Sub

    Public Function CargarDatos() As Boolean
        Dim AdapterConsulta As New MySqlDataAdapter(Comandos(Cual:="idServicio", Busqueda:=CType(RegistroActivo.Servicio, String)), connection:=Conexion)
        Dim DataTabletConsulta As New DataTable
        AdapterConsulta.Fill(dataTable:=DataTabletConsulta)
        ListaConsulta = CByte(DataTabletConsulta.Rows.Count)
        If ListaConsulta <> 0 Then
            Label1.Text = DataTabletConsulta.Rows(0)("idServicio").ToString
            Label2.Text = DataTabletConsulta.Rows(0)("idEmpresa").ToString
            Label3.Text = DataTabletConsulta.Rows(0)("idCategoria").ToString
            TextBox1.Text = DataTabletConsulta.Rows(0)("Nombre").ToString
            TextBox2.Text = DataTabletConsulta.Rows(0)("Color").ToString
            TextBox3.Text = DataTabletConsulta.Rows(0)("Descrpcion").ToString
            TextBox4.Text = DataTabletConsulta.Rows(0)("LugarNacimiento").ToString
            Label14.Text = DataTabletConsulta.Rows(0)("CreadoPor").ToString
            Label15.Text = CType(DataTabletConsulta.Rows(0)("CreadoFecha"), Date).ToString
            Label16.Text = DataTabletConsulta.Rows(0)("ModificadoPor").ToString
            Label17.Text = CType(DataTabletConsulta.Rows(0)("ModificadoFecha"), Date).ToString
            RegistroActivo.Servicio = CInt(Label1.Text)
            Return True
        Else
            LimpiarTextBox()
            RegistroActivo.Servicio = -1
            Return False
        End If
    End Function

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        'Boton nuevo
        Editando = True
        BNuevo.Enabled = False
        BEditar.Enabled = True
        ToolTips.SetToolTip(BEditar, caption:="Guardar Servicio")
        BEditar.Image = My.Resources.Guradar
        BEliminar.Enabled = True
        BEliminar.Image = My.Resources.Cancelar
        ToolTips.SetToolTip(BEliminar, caption:="Cancelar Edición")
        BBuscar.Enabled = False
        EstadoTextBox(True)
        NuevoRegistro = True
        LimpiarTextBox()
        TabControl1.SelectedTab = TabPage1
        TextBox1.Select()

    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        If Editando Then 'Boton guardar
            Editando = False
            BNuevo.Enabled = True
            ToolTips.SetToolTip(BEditar, caption:="Modificar Servicio")
            BEditar.Image = My.Resources.Editar
            BEditar.Enabled = True
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Servicio")
            BEliminar.Image = My.Resources.Borrar
            BEliminar.Enabled = True
            BBuscar.Enabled = True
            EstadoTextBox(False)
            If NuevoRegistro Then
                Try
                    Operaciones(Comandos(Cual:="Insert"))
                Catch ex As Exception
                    MsgBox(Prompt:=ex.Message)
                End Try
                NuevoRegistro = False
            Else
                Try
                    Operaciones(Comandos(Cual:="Update"))
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            DataTabletTotal = Consulta(Sql:=Comandos("Select"))

        Else 'Boton editar
            Editando = True
            BNuevo.Enabled = False
            BEditar.Enabled = True
            ToolTips.SetToolTip(BEditar, caption:="Guardar Servicio")
            BEditar.Image = My.Resources.Guradar
            BEliminar.Enabled = True
            BEliminar.Image = My.Resources.Cancelar
            ToolTips.SetToolTip(BEliminar, caption:="Cancelar Edición")
            BBuscar.Enabled = False
            EstadoTextBox(True)
            TextBox1.Select()

        End If
    End Sub

    Private Sub BEliminar_Click(sender As Object, e As EventArgs) Handles BEliminar.Click
        If Editando Then 'Boton cancelar
            If ListaTotal = 0 Then
                BNuevo.Enabled = True
                BEditar.Enabled = False
                BEliminar.Enabled = False
                BBuscar.Enabled = False
            Else
                BNuevo.Enabled = True
                BEditar.Enabled = True
                BEliminar.Enabled = True
                BBuscar.Enabled = True
            End If
            EstadoTextBox(False)
            LimpiarTextBox()
            Editando = False
            BEditar.Image = My.Resources.Editar
            BEliminar.Image = My.Resources.Borrar
            ToolTips.SetToolTip(BEditar, caption:="Modificar Servicio")
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Servicio")
            DataTabletTotal.RejectChanges()
            TextBox1.Select()
            RegistroActivo.Servicio = -1

        Else 'Boton eliminar
            If MsgBox(Prompt:="¿Seguro desea borrar el siguiente registro?", Buttons:=CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, Global.Microsoft.VisualBasic.MsgBoxStyle)) = vbYes Then
                Operaciones(Sql:=Comandos("Delete"))
            End If
            If ListaTotal = 0 Then
                BNuevo.Enabled = True
                BEditar.Enabled = False
                BEliminar.Enabled = False
                BBuscar.Enabled = False
            Else
                BNuevo.Enabled = True
                BEditar.Enabled = True
                BEliminar.Enabled = True
                BBuscar.Enabled = True
            End If
            EstadoTextBox(False)
            Editando = False
            LimpiarTextBox()
            RegistroActivo.Servicio = -1

            DataTabletTotal.AcceptChanges()
            DataTabletTotal = Consulta(Sql:=Comandos("Select"))

        End If
    End Sub

    Private Sub BBuscar_Click(sender As Object, e As EventArgs) Handles BBuscar.Click
        'Boton buscar
        VentanaBusqueda = "Servicios"
        frmBuscarPersonas.ShowDialog()
        CargarDatos()
        TabControl1.SelectedTab = TabPage1

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        If Editando Then 'Boton salir
            If MsgBox("Los datos no se han guardado, ¿Desea perderlos?", CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo, MsgBoxStyle)) = vbYes Then
                Editando = False
                Close()
            Else
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Public Function Comandos(ByVal Cual As String, Optional Busqueda As String = "") As String
        Dim Comando As String = ""
        Select Case Cual
            Case "idServicio"
                Comando = $"SELECT * FROM Servicios WHERE idServicio='{Busqueda}'"
            Case "Select"
                Comando = "SELECT * FROM Servicios"
            Case "Insert"
                Comando = $"INSERT INTO Servicios (idEmpresa, idCategoria, Nombre, Descripcion, Color, CreadoPor, CreadoFecha, ModificadoPor, ModificadoFecha) VALUES ('{Label2.Text}', '{Label6.Text}', '{TextBox1.Text}', '{TextBox3.Text}', '{TextBox2.Text}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}')"
            Case "Delete"
                Comando = $"DELETE FROM Servicios WHERE idServicio = '{RegistroActivo.Servicio}'"
            Case "Update"
                Comando = $"UPDATE Servicios SET idServicio = '{RegistroActivo.Servicio}', idCategoria = '{Label2.Text}', idCategoria = '{Label6.Text}', Nombre = '{TextBox1.Text}', Color = '{TextBox2.Text}', Descripcion = '{TextBox3.Text}',  ModificadoPor = '{UsuarioActivo.Nombre}', ModificadoFecha = '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}' WHERE idServicio = '{RegistroActivo.Servicio}'"
        End Select
        Return Comando
    End Function

    Private Sub EstadoTextBox(ByVal Estado As Boolean)
        Dim F As Integer
        For F = 0 To TabPage1.Controls.Count - 1
            If TypeOf TabPage1.Controls(F) Is TextBox Then
                TabPage1.Controls(F).Enabled = Estado
            End If
        Next F
    End Sub

    Private Sub LimpiarTextBox()
        Dim F As Integer
        For F = 0 To TabPage1.Controls.Count - 1
            If TypeOf TabPage1.Controls(F) Is TextBox Then
                TabPage1.Controls(F).Text = ""
            End If
        Next F
        BEditar.Enabled = False
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            BEditar.Enabled = False
        Else
            BEditar.Enabled = True
        End If
    End Sub

    Private Sub TextBox1_Validating(sender As Object, e As CancelEventArgs) Handles TextBox1.Validating
        Dim AdapterConsulta As New MySqlDataAdapter(Comandos(Cual:="Cedula", Busqueda:=TextBox1.Text), Conexion)
        Dim DataTabletConsulta As New DataTable
        AdapterConsulta.Fill(DataTabletConsulta)
        ListaConsulta = CByte(DataTabletConsulta.Rows.Count)
        If ListaConsulta <> 0 Then
            RegistroActivo.Servicio = CInt(DataTabletConsulta.Rows(0)("idServicio").ToString)
            NuevoRegistro = False
            CargarDatos()
        Else
            Dim auxCedula = TextBox1.Text
            LimpiarTextBox()
            TextBox1.Text = auxCedula
            NuevoRegistro = True
        End If
    End Sub

    Private Sub Label2_TextChanged(sender As Object, e As EventArgs) Handles Label2.TextChanged
        Dim AuxConsulta As New MySqlDataAdapter(selectCommandText:=$"SELECT * FROM Empresa WHERE idEmpresa='{Label2.Text}'", connection:=Conexion)
        Dim AuxTabletConsulta As New DataTable
        AuxConsulta.Fill(dataTable:=AuxTabletConsulta)
        ListaConsulta = CByte(AuxTabletConsulta.Rows.Count)
        If ListaConsulta <> 0 Then
            Label6.Text = AuxTabletConsulta.Rows(0)("idEmpresa").ToString
            TextBox4.Text = AuxTabletConsulta.Rows(0)("Nombre").ToString
        Else
            'RegistroActivo.Servicio = -1
        End If
    End Sub
End Class