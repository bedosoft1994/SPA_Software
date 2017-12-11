Public Class FrmEmpleados
    Dim DataTabletTotal As New DataTable
    Dim ListaTotal As Byte

    Dim DataTabletConsulta As New DataTable
    Dim ListaConsulta As Byte

    Dim NuevoRegistro As Boolean

    Private Sub FrmEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DataEdad As DataTable = Consulta(Sql:=$"SELECT idEmpleado, Nombres, Apellidos, FechaNacimiento FROM Empleados WHERE Month(FechaNacimiento)={Today().Month} ORDER BY FechaNacimiento")
        DataGridAños.DataSource = DataEdad
        DataGridAños.Columns(0).Visible = False
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
        DataGridEmpleados.DataSource = DataTabletTotal
        DataGridEmpleados.Columns(0).Visible = False
        DataGridEmpleados.Columns(1).Visible = False
        DataGridEmpleados.Columns(13).Visible = False
        DataGridEmpleados.Columns(14).Visible = False
        DataGridEmpleados.Columns(15).Visible = False
        DataGridEmpleados.Columns(16).Visible = False
        DataGridEmpleados.Columns(17).Visible = False
        DataGridEmpleados.Columns(0).Frozen = True
        DataGridEmpleados.Columns(1).Frozen = True
        DataGridEmpleados.Columns(2).Frozen = True
        EstadoTextBox(False)
        RegistroActivo.Empleado = -1
        NuevoRegistro = False
        ComboBox1.SelectedIndex = Today.Month - 1
    End Sub

    Public Function CargarDatos() As Boolean
        Dim DataEdad As DataTable = Consulta(Sql:=$"SELECT idEmpleado, Nombres, Apellidos, FechaNacimiento FROM Empleados WHERE Month(FechaNacimiento)={Today().Month} ORDER BY FechaNacimiento")
        DataGridAños.DataSource = DataEdad
        Dim AdapterConsulta As New MySqlDataAdapter(Comandos(Cual:="idEmpleado", Busqueda:=CType(RegistroActivo.Empleado, String)), connection:=Conexion)
        Dim DataTabletConsulta As New DataTable
        AdapterConsulta.Fill(dataTable:=DataTabletConsulta)
        ListaConsulta = CByte(DataTabletConsulta.Rows.Count)
        If ListaConsulta <> 0 Then
            Label1.Text = DataTabletConsulta.Rows(0)("idEmpleado").ToString
            Label2.Text = DataTabletConsulta.Rows(0)("idEmpresa").ToString
            TextBox1.Text = DataTabletConsulta.Rows(0)("Identificacion").ToString
            TextBox2.Text = DataTabletConsulta.Rows(0)("Nombres").ToString
            TextBox3.Text = DataTabletConsulta.Rows(0)("Apellidos").ToString
            DateTimePicker1.Value = CType(DataTabletConsulta.Rows(0)("FechaNacimiento"), Date)
            DateTimePicker2.Value = CType(DataTabletConsulta.Rows(0)("FechaIngreso"), Date)
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
            RegistroActivo.Empleado = CInt(Label1.Text)
            Return True
        Else
            LimpiarTextBox()
            RegistroActivo.Empleado = -1
            Return False
        End If
    End Function

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        'Boton nuevo
        Editando = True
        BNuevo.Enabled = False
        BEditar.Enabled = True
        ToolTips.SetToolTip(BEditar, caption:="Guardar Empleado")
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
            ToolTips.SetToolTip(BEditar, caption:="Modificar Empleado")
            BEditar.Image = My.Resources.Editar
            BEditar.Enabled = True
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Empleado")
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
                    DataTabletTotal.AcceptChanges()
                    Operaciones(Comandos(Cual:="Update"))
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            DataTabletTotal = Consulta(Sql:=Comandos("Select"))
            DataGridEmpleados.DataSource = DataTabletTotal
            Dim DataEdad As DataTable = Consulta(Sql:=$"SELECT idEmpleado, Nombres, Apellidos, FechaNacimiento FROM Empleados WHERE Month(FechaNacimiento)={Today().Month} ORDER BY FechaNacimiento")
            DataGridAños.DataSource = DataEdad

        Else 'Boton editar
            Editando = True
            BNuevo.Enabled = False
            BEditar.Enabled = True
            ToolTips.SetToolTip(BEditar, caption:="Guardar Empleado")
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
            ToolTips.SetToolTip(BEditar, caption:="Modificar Empleado")
            ToolTips.SetToolTip(BEliminar, caption:="Elimimar Empleado")
            DataTabletTotal.RejectChanges()
            TextBox1.Select()
            RegistroActivo.Empleado = -1

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
            RegistroActivo.Empleado = -1

            DataTabletTotal.AcceptChanges()
            DataTabletTotal = Consulta(Sql:=Comandos("Select"))
            DataGridEmpleados.DataSource = DataTabletTotal
            Dim DataEdad As DataTable = Consulta(Sql:=$"SELECT Nombres, Apellidos, FechaNacimiento FROM Empleados WHERE Month(FechaNacimiento)={Today().Month} ORDER BY FechaNacimiento")
            DataGridAños.DataSource = DataEdad

        End If
    End Sub

    Private Sub BBuscar_Click(sender As Object, e As EventArgs) Handles BBuscar.Click
        'Boton buscar
        VentanaBusqueda = "Empleados"
        frmBuscarPersonas.ShowDialog()
        CargarDatos()
        TabControl1.SelectedTab = TabPage1
        BEliminar.Enabled = True
        BEditar.Enabled = True
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
            Case "idEmpleado"
                Comando = $"SELECT * FROM Empleados WHERE idEmpleado='{Busqueda}'"
            Case "Cedula"
                Comando = $"SELECT * FROM Empleados WHERE Identificacion='{Busqueda}'"
            Case "Nombre"
                Comando = $"SELECT * FROM Empleados WHERE Nombres='{Busqueda}'"
            Case "Apellido"
                Comando = $"SELECT * FROM Empleados WHERE Apellidos='{Busqueda}'"
            Case "Select"
                Comando = "SELECT * FROM Empleados"
            Case "Insert"
                Comando = $"INSERT INTO Empleados (idEmpresa, Identificacion, Nombres, Apellidos, FechaNacimiento, FechaIngreso, LugarNacimiento, Genero, Direccion, Telefono1, Telefono2, Correo, Observacion, CreadoPor, CreadoFecha, ModificadoPor, ModificadoFecha) VALUES ('{RegistroActivo.Empresa}', '{TextBox1.Text}', '{TextBox2.Text}', '{TextBox3.Text}', '{Format(DateTimePicker1.Value, "yyyy/MM/dd")}', '{Format(DateTimePicker2.Value, "yyyy/MM/dd")}', '{TextBox6.Text}', '{TextBox5.Text}', '{TextBox7.Text}', '{TextBox8.Text}', '{TextBox9.Text}', '{TextBox10.Text}', '{TextBox11.Text}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}')"
            Case "Delete"
                Comando = $"DELETE FROM Empleados WHERE idEmpleado = '{RegistroActivo.Empleado}'"
            Case "Update"
                Comando = $"UPDATE Empleados SET idEmpresa = '{RegistroActivo.Empresa}', Identificacion = '{TextBox1.Text}', Nombres = '{TextBox2.Text}', Apellidos = '{TextBox3.Text}', FechaNacimiento = '{Format(DateTimePicker1.Value, "yyyy/MM/dd")}', FechaIngreso = '{Format(DateTimePicker2.Value, "yyyy/MM/dd")}', LugarNacimiento = '{TextBox6.Text}', Genero = '{TextBox5.Text}', Direccion = '{TextBox7.Text}', Telefono1 = '{TextBox8.Text}', Telefono2 = '{TextBox9.Text}', Correo = '{TextBox10.Text}', Observacion = '{TextBox11.Text}', ModificadoPor = '{UsuarioActivo.Nombre}', ModificadoFecha = '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}' WHERE idEmpleado = '{RegistroActivo.Empleado}'"
        End Select
        Return Comando
    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim Edad = CStr(Int(Number:=DateDiff(Interval:=DateInterval.DayOfYear, Date1:=DateTimePicker1.Value, Date2:=Now()) / 365.25))
        If Edad = "1" Then
            Edad = $"{Edad} AÑO"
        Else
            Edad = $"{Edad} AÑOS"
        End If
        TextBox4.Text = CType(Edad, String)
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Dim Años = Int(Number:=DateDiff(Interval:=DateInterval.DayOfYear, Date1:=DateTimePicker2.Value, Date2:=Now()) / 365.25)
        Dim Meses = DateDiff(Interval:=DateInterval.Month, Date1:=DateTimePicker2.Value, Date2:=Now()) Mod 12
        Dim auxStrig As String = ""
        Select Case Años
            Case < 1
                auxStrig = "VERIFICAR LA FECHA"
            Case 1
                auxStrig = $"{Años} AÑO"
            Case Else
                auxStrig = $"{Años} AÑOS"
        End Select
        If CInt(Años) = 0 Then
            Select Case CInt(Meses)
                Case < 1
                    auxStrig = "VERIFICAR LA FECHA"
                Case 1
                    auxStrig = $"{Meses} MES"
                Case Else
                    auxStrig = $"{Meses} MESES"
            End Select
        Else
            Select Case CInt(Meses)
                Case < 1
'                    auxStrig = "VERIFICAR LA FECHA"
                Case 1
                    auxStrig = $"{auxStrig} y {Meses} MES"
                Case Else
                    auxStrig = $"{auxStrig} y {Meses} MESES"
            End Select
        End If
        TextBox13.Text = auxStrig
    End Sub

    Private Sub EstadoTextBox(ByVal Estado As Boolean)
        Dim F As Integer
        For F = 0 To TabPage1.Controls.Count - 1
            If TypeOf TabPage1.Controls(F) Is TextBox Then
                TabPage1.Controls(F).Enabled = Estado
            End If
        Next F
        DateTimePicker1.Enabled = Estado
        DateTimePicker2.Enabled = Estado
        If Estado Then
            TextBox4.Enabled = Not Estado
            TextBox13.Enabled = Not Estado
        Else
            TextBox4.Enabled = Estado
            TextBox13.Enabled = Estado
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
        DateTimePicker2.Value = Now()
        BEditar.Enabled = False
    End Sub

    Private Sub DataGridEmpleados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridEmpleados.CellContentDoubleClick
        'buscar el registro y mostrarlo en la primera pestaña
        RegistroActivo.Empleado = CInt(DataGridEmpleados(columnIndex:=0, rowIndex:=DataGridEmpleados.CurrentCell.RowIndex).Value)
        CargarDatos()
        TabControl1.SelectedTab = TabPage1
    End Sub

    Private Sub DataGridAños_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridAños.CellContentDoubleClick
        RegistroActivo.Empleado = CInt(DataGridAños(columnIndex:=0, rowIndex:=DataGridAños.CurrentCell.RowIndex).Value)
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
            RegistroActivo.Empleado = CInt(DataTabletConsulta.Rows(0)("idEmpleado").ToString)
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
            TextBox12.Text = AuxTabletConsulta.Rows(0)("Nombre").ToString
        Else
            'RegistroActivo.Empleado = -1
        End If
    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim DataEdad As DataTable = Consulta(Sql:=$"SELECT idEmpleado, Nombres, Apellidos, FechaNacimiento FROM Empleados WHERE Month(FechaNacimiento)={ComboBox1.SelectedIndex + 1} ORDER BY FechaNacimiento")
        DataGridAños.DataSource = DataEdad
    End Sub
End Class