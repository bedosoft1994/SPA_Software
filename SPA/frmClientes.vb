Imports System.ComponentModel

Public Class FrmClientes
    Dim AdapterTotal As MySqlDataAdapter
    Dim DataSetTotal As DataSet
    Dim DataTabletTotal As DataTable
    Dim ListaTotal As Byte

    Dim AdapterConsulta As New MySqlDataAdapter
    Dim DataSetConsulta As New DataSet
    Dim DataTabletConsulta As New DataTable
    Dim ListaConsulta As Byte
    Dim RegistroConsulta As DataRow

    Dim NuevoRegistro As Boolean

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataTabletTotal = Consulta(Comandos("Select"))
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
        DataGridClientes.DataSource = DataTabletTotal
        DataGridClientes.Columns(0).Visible = False
        DataGridClientes.Columns(1).Visible = False
        DataGridClientes.Columns(13).Visible = False
        DataGridClientes.Columns(14).Visible = False
        DataGridClientes.Columns(15).Visible = False
        DataGridClientes.Columns(16).Visible = False
        DataGridClientes.Columns(0).Frozen = True
        DataGridClientes.Columns(1).Frozen = True
        DataGridClientes.Columns(2).Frozen = True
        EstadoTextBox(False)
        RegistroActivo.Empresa = 0
        NuevoRegistro = False
    End Sub

    Public Function CargarDatos() As Boolean
        Dim AdapterConsulta As New MySqlDataAdapter(Comandos(Cual:="idCliente", Busqueda:=CType(RegistroActivo.Cliente, String)), Conexion)
        Dim DataTabletConsulta As New DataTable
        AdapterConsulta.Fill(DataTabletConsulta)
        ListaConsulta = CByte(DataTabletConsulta.Rows.Count)
        If ListaConsulta <> 0 Then
            Label1.Text = DataTabletConsulta.Rows(0)("idCliente").ToString
            Label2.Text = DataTabletConsulta.Rows(0)("idEmpresa").ToString
            TextBox1.Text = DataTabletConsulta.Rows(0)("Identificacion").ToString
            TextBox2.Text = DataTabletConsulta.Rows(0)("Nombres").ToString
            TextBox3.Text = DataTabletConsulta.Rows(0)("Apellidos").ToString
            DateTimePicker1.Value = CType(DataTabletConsulta.Rows(0)("FechaNacimiento"), Date)
            TextBox6.Text = DataTabletConsulta.Rows(0)("LugarNacimiento").ToString
            TextBox5.Text = DataTabletConsulta.Rows(0)("Genero").ToString
            TextBox7.Text = DataTabletConsulta.Rows(0)("Direccion").ToString
            TextBox8.Text = DataTabletConsulta.Rows(0)("Telefono1").ToString
            TextBox9.Text = DataTabletConsulta.Rows(0)("Telefono2").ToString
            TextBox10.Text = DataTabletConsulta.Rows(0)("Correo").ToString
            TextBox11.Text = DataTabletConsulta.Rows(0)("Observacion").ToString
            Label14.Text = DataTabletConsulta.Rows(0)("CreadoPor").ToString
            Label15.Text = CType(DataTabletConsulta.Rows(0)("CreadoFecha"), Date).ToString
            Label16.Text = DataTabletConsulta.Rows(0)("ModificadoPor").ToString
            Label17.Text = CType(DataTabletConsulta.Rows(0)("ModificadoFecha"), Date).ToString
            Return True
        Else
            LimpiarTextBox()
            Return False
        End If
    End Function

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        'Boton nuevo
        Editando = True
        BNuevo.Enabled = False
        BEditar.Enabled = True
        ToolTips.SetToolTip(BEditar, caption:="Guardar Cliente")
        BEditar.Image = My.Resources.Guradar
        BEliminar.Enabled = True
        BEliminar.Image = My.Resources.Cancelar
        ToolTips.SetToolTip(BEliminar, caption:="Cancelar Edición")
        BBuscar.Enabled = False
        EstadoTextBox(True)
        NuevoRegistro = True
        LimpiarTextBox()
        TabControl1.SelectedTab = TabPage1

    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        If Editando Then 'Boton guardar
            Editando = False
            BNuevo.Enabled = True
            ToolTips.SetToolTip(BEditar, caption:="Modificar Cliente")
            BEditar.Image = My.Resources.Editar
            BEditar.Enabled = True
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Cliente")
            BEliminar.Image = My.Resources.Borrar
            BEliminar.Enabled = True
            BBuscar.Enabled = True
            EstadoTextBox(False)
            If NuevoRegistro Then
                Try
                    Operaciones(Comandos("Insert"))
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                NuevoRegistro = False
            Else
                Try
                    Operaciones(Comandos("Update"))
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            DataTabletTotal.AcceptChanges()
            DataTabletTotal = Consulta(Comandos("Select"))
            DataGridClientes.DataSource = DataTabletTotal

        Else 'Boton editar
            Editando = True
            BNuevo.Enabled = False
            BEditar.Enabled = True
            ToolTips.SetToolTip(BEditar, caption:="Guardar Cliente")
            BEditar.Image = My.Resources.Guradar
            BEliminar.Enabled = True
            BEliminar.Image = My.Resources.Cancelar
            ToolTips.SetToolTip(BEliminar, caption:="Cancelar Edición")
            BBuscar.Enabled = False
            EstadoTextBox(True)

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
            ToolTips.SetToolTip(BEditar, caption:="Modificar Cliente")
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Cliente")
            DataTabletTotal.RejectChanges()

        Else 'Boton eliminar
            MsgBox(RegistroActivo.Cliente)
            If MsgBox(Prompt:="¿Seguro desea borrar el siguiente registro?", Buttons:=CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, Global.Microsoft.VisualBasic.MsgBoxStyle)) = vbYes Then
                Operaciones(Comandos("Delete"))
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

            DataTabletTotal.AcceptChanges()
            DataTabletTotal = Consulta(Comandos("Select"))
            DataGridClientes.DataSource = DataTabletTotal

        End If
    End Sub

    Private Sub BBuscar_Click(sender As Object, e As EventArgs) Handles BBuscar.Click
        'Boton buscar
        VentanaBusqueda = "Clientes"
        frmBuscarPersonas.ShowDialog()
        CargarDatos()
        TabControl1.SelectedTab = TabPage1

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        If Editando Then 'Boton salir
            If MsgBox("Los datos no se han guardado, ¿Desea perderlos?", CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo, MsgBoxStyle)) = vbYes Then
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
            Case "idCliente"
                Comando = $"SELECT * FROM Clientes WHERE idCliente='{Busqueda}'"
            Case "Cedula"
                Comando = $"SELECT * FROM Clientes WHERE Identificacion='{Busqueda}'"
            Case "Nombre"
                Comando = $"SELECT * FROM Clientes WHERE Nombres='{Busqueda}'"
            Case "Apellido"
                Comando = $"SELECT * FROM Clientes WHERE Apellidos='{Busqueda}'"
            Case "Select"
                Comando = "SELECT * FROM Clientes"
            Case "Insert"
                Comando = $"INSERT INTO Clientes (idEmpresa, Identificacion, Nombres, Apellidos, FechaNacimiento, LugarNacimiento, Genero, Direccion, Telefono1, Telefono2, Correo, Observacion, CreadoPor, CreadoFecha, ModificadoPor, ModificadoFecha) VALUES ('{RegistroActivo.Empresa}', '{TextBox1.Text}', '{TextBox2.Text}', '{TextBox3.Text}', '{Format(DateTimePicker1.Value, "yyyy/MM/dd")}', '{TextBox6.Text}', '{TextBox5.Text}', '{TextBox7.Text}', '{TextBox8.Text}', '{TextBox9.Text}', '{TextBox10.Text}', '{TextBox11.Text}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}')"
            Case "Delete"
                Comando = $"DELETE FROM Clientes WHERE idCliente = '{RegistroActivo.Cliente}'"
            Case "Update"
                Comando = $"UPDATE Clientes SET idEmpresa = '{RegistroActivo.Empresa}', Identificacion = '{TextBox1.Text}', Nombres = '{TextBox2.Text}', Apellidos = '{TextBox3.Text}', FechaNacimiento = '{Format(DateTimePicker1.Value, "yyyy/MM/dd")}', LugarNacimiento = '{TextBox6.Text}', Genero = '{TextBox5.Text}', Direccion = '{TextBox7.Text}', Telefono1 = '{TextBox8.Text}', Telefono2 = '{TextBox9.Text}', Correo = '{TextBox10.Text}', Observacion = '{TextBox11.Text}', ModificadoPor = '{UsuarioActivo.Nombre}', ModificadoFecha = '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}' WHERE idCliente = '{RegistroActivo.Cliente}'"
        End Select
        Return Comando
    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox4.Text = Str(CInt(Int(DateDiff(DateInterval.DayOfYear, DateTimePicker1.Value, Now()) / 365.25))) & " Años"
    End Sub

    Private Sub EstadoTextBox(ByVal Estado As Boolean)
        Dim F As Integer
        For F = 0 To TabPage1.Controls.Count - 1
            If TypeOf TabPage1.Controls(F) Is TextBox Then
                TabPage1.Controls(F).Enabled = Estado
            End If
        Next F
        If Estado Then
            TextBox4.Enabled = Not Estado
            DateTimePicker1.Enabled = Estado
        Else
            TextBox4.Enabled = Estado
            DateTimePicker1.Enabled = Estado
        End If
    End Sub

    Private Sub LimpiarTextBox()
        Dim F As Integer
        For F = 0 To TabPage1.Controls.Count - 1
            If TypeOf TabPage1.Controls(F) Is TextBox Then
                TabPage1.Controls(F).Text = ""
            End If
        Next F
        DateTimePicker1.Value = Now()
        BEditar.Enabled = False
    End Sub

    Private Sub DataGridClientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridClientes.CellContentClick
        'buscar el registro y mostrarlo en la primera pestaña
        RegistroActivo.Cliente = CInt(DataGridClientes(columnIndex:=0, rowIndex:=DataGridClientes.CurrentCell.RowIndex).Value)
        CargarDatos()
        TabControl1.SelectedTab = TabPage1
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
            RegistroActivo.Cliente = CInt(DataTabletConsulta.Rows(0)("idCliente").ToString)
            NuevoRegistro = True
            CargarDatos()
        Else
            Dim auxCedula = TextBox1.Text
            LimpiarTextBox()
            TextBox1.Text = auxCedula
            NuevoRegistro = False
        End If
    End Sub
End Class