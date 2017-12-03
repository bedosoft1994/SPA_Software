Public Class frmEmpresa
    Dim DataTabletTotal As New DataTable
    Dim ListaTotal As Byte

    Dim DataTabletConsulta As New DataTable
    Dim ListaConsulta As Byte

    Dim NuevoRegistro As Boolean

    Private Sub FrmEmpresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.TabPages.Remove(TabPage2)
        CheckTab1()
        DataTabletTotal = Consulta(Sql:=Comandos(Cual:="Select"))
        ListaTotal = CByte(DataTabletTotal.Rows.Count)
        'If ListaTotal = 0 Then
        '    BNuevo.Enabled = True
        '    BEditar.Enabled = False
        '    BEliminar.Enabled = False
        '    BBuscar.Enabled = False
        'Else
        '    BNuevo.Enabled = True
        '    BEditar.Enabled = False
        '    BEliminar.Enabled = False
        '    BBuscar.Enabled = True
        'End If
        EstadoTextBox(False)
        NuevoRegistro = False
        CargarDatos()
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

    Public Function CargarDatos() As Boolean
        Dim AdapterConsulta As New MySqlDataAdapter(Comandos(Cual:="idEmpresa", Busqueda:=CType(RegistroActivo.Empresa, String)), Conexion)
        Dim DataTabletConsulta As New DataTable
        AdapterConsulta.Fill(DataTabletConsulta)
        ListaConsulta = CByte(DataTabletConsulta.Rows.Count)
        If ListaConsulta <> 0 Then
            Label1.Text = DataTabletConsulta.Rows(0)("idEmpresa").ToString
            TextBox1.Text = DataTabletConsulta.Rows(0)("Nombre").ToString
            TextBox2.Text = DataTabletConsulta.Rows(0)("NIT").ToString
            TextBox3.Text = DataTabletConsulta.Rows(0)("Direccion").ToString
            TextBox4.Text = DataTabletConsulta.Rows(0)("Telefono").ToString
            TextBox5.Text = DataTabletConsulta.Rows(0)("Correo").ToString
            TextBox6.Text = DataTabletConsulta.Rows(0)("Representante").ToString
            TextBox7.Text = DataTabletConsulta.Rows(0)("MovilRepresentante").ToString
            Label2.Text = DataTabletConsulta.Rows(0)("CreadoPor").ToString
            Label3.Text = CType(DataTabletConsulta.Rows(0)("CreadoFecha"), Date).ToString
            Label4.Text = DataTabletConsulta.Rows(0)("ModificadoPor").ToString
            Label5.Text = CType(DataTabletConsulta.Rows(0)("ModificadoFecha"), Date).ToString
            RegistroActivo.Empresa = CInt(Label1.Text)
            Return True
        Else
            LimpiarTextBox()
            'RegistroActivo.Empresa = -1
            Return False
        End If
    End Function

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        'Boton nuevo
        'Editando = True
        'BNuevo.Enabled = False
        'BEditar.Enabled = True
        'ToolTips.SetToolTip(BEditar, caption:="Guardar Empresa")
        'BEditar.Image = My.Resources.Guradar
        'BEliminar.Enabled = True
        'BEliminar.Image = My.Resources.Cancelar
        'ToolTips.SetToolTip(BEliminar, caption:="Cancelar Edición")
        'BBuscar.Enabled = False
        'EstadoTextBox(True)
        'NuevoRegistro = True
        'LimpiarTextBox()
        'TabControl1.SelectedTab = TabPage1
        'TextBox1.Select()

    End Sub

    Private Sub BEditar_Click(sender As Object, e As EventArgs) Handles BEditar.Click
        If Editando Then 'Boton guardar
            Editando = False
            BEditar.Image = My.Resources.Editar
            BEliminar.Image = My.Resources.Borrar
            BNuevo.Enabled = True
            BBuscar.Enabled = True
            ToolTips.SetToolTip(BEditar, caption:="Modificar Empresa")
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Empresa")
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
            DataTabletTotal = Consulta(Comandos("Select"))

        Else 'Boton editar
            Editando = True
            BEditar.Image = My.Resources.Guradar
            BEliminar.Image = My.Resources.Cancelar
            BNuevo.Enabled = False
            BBuscar.Enabled = False
            ToolTips.SetToolTip(BEditar, caption:="Guardar Empresa")
            ToolTips.SetToolTip(BEliminar, caption:="Cancelar Edición")
            EstadoTextBox(True)
            TextBox1.Select()

        End If
        CheckTab1()
    End Sub

    Private Sub BEliminar_Click(sender As Object, e As EventArgs) Handles BEliminar.Click
        If Editando Then 'Boton cancelar
            'If ListaTotal = 0 Then
            '    BNuevo.Enabled = True
            '    BEditar.Enabled = False
            '    BEliminar.Enabled = False
            '    BBuscar.Enabled = False
            'Else
            '    BNuevo.Enabled = True
            '    BEditar.Enabled = True
            '    BEliminar.Enabled = True
            '    BBuscar.Enabled = True
            'End If
            EstadoTextBox(False)
            LimpiarTextBox()
            Editando = False
            BEditar.Image = My.Resources.Editar
            BEliminar.Image = My.Resources.Borrar
            ToolTips.SetToolTip(BEditar, caption:="Modificar Empresa")
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Empresa")
            DataTabletTotal.RejectChanges()
            TextBox1.Select()
            'RegistroActivo.Empresa= -1

        Else 'Boton eliminar
            If MsgBox(Prompt:="¿Seguro desea borrar el siguiente registro?", Buttons:=CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, Global.Microsoft.VisualBasic.MsgBoxStyle)) = vbYes Then
                Operaciones(Comandos("Delete"))
            End If
            'If ListaTotal = 0 Then
            '    BNuevo.Enabled = True
            '    BEditar.Enabled = False
            '    BEliminar.Enabled = False
            '    BBuscar.Enabled = False
            'Else
            '    BNuevo.Enabled = True
            '    BEditar.Enabled = True
            '    BEliminar.Enabled = True
            '    BBuscar.Enabled = True
            'End If
            EstadoTextBox(False)
            Editando = False
            LimpiarTextBox()
            'RegistroActivo.Empresa = -1
            DataTabletTotal = Consulta(Comandos("Select"))

        End If
        CheckTab1()
    End Sub

    Private Sub BBuscar_Click(sender As Object, e As EventArgs) Handles BBuscar.Click
        'Boton buscar

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        If Editando Then 'Boton salir
            If MsgBox(Prompt:="Los datos no se han guardado, ¿Desea perderlos?", Buttons:=CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo, MsgBoxStyle)) = vbYes Then
                Editando = False
                Close()
            Else
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        CheckTab1()
    End Sub

    Public Function Comandos(ByVal Cual As String, Optional Busqueda As String = "") As String
        Dim Comando As String = ""
        Select Case Cual
            Case "idEmpresa"
                Comando = $"SELECT * FROM Empresa WHERE idEmpresa='{Busqueda}'"
            Case "Nombre"
                Comando = $"SELECT * FROM Empresa WHERE Nombre='{Busqueda}'"
            Case "Select"
                Comando = "SELECT * FROM Empresa"
            Case "Insert"
                Comando = $"INSERT INTO Empresa (Nombre, NIT, Direccion, Telefono, Correo, Representante, MovilRepresentante, CreadoPor, CreadoFecha, ModificadoPor, ModificadoFecha) VALUES ('{TextBox1.Text}', '{TextBox2.Text}', '{TextBox3.Text}', '{TextBox4.Text}', '{TextBox5.Text}', '{TextBox6.Text}', '{TextBox7.Text}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}')"
            Case "Delete"
                Comando = $"DELETE FROM Empresa WHERE idEmpresa = '{RegistroActivo.Empresa}'"
            Case "Update"
                Comando = $"UPDATE Empresa SET Nombre= '{TextBox1.Text}', NIT = '{TextBox2.Text}', Direccion = '{TextBox3.Text}', Telefono = '{TextBox4.Text}', Correo = '{TextBox5.Text}', Representante = '{TextBox6.Text}', MovilRepresentante = '{TextBox7.Text}', ModificadoPor = '{UsuarioActivo.Nombre}', ModificadoFecha = '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}' WHERE idEmpresa = '{RegistroActivo.Empresa}'"
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

End Class