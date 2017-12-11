Public Class FrmCita
    Private Sub FrmCita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        DateTimePicker1.Value = Now()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub BCliente_Click(sender As Object, e As EventArgs) Handles BCliente.Click
        VentanaBusqueda = "Clientes"
        frmBuscarPersonas.ShowDialog()
        Dim AuxConsulta As New MySqlDataAdapter(selectCommandText:=$"SELECT Nombres, Apellidos FROM Clientes WHERE idCliente = '{RegistroActivo.Cliente}'", connection:=Conexion)
        Dim AuxTabletConsulta As New DataTable
        AuxConsulta.Fill(AuxTabletConsulta)

        If RegistroActivo.Cliente <> -1 Then
            BGuardar.Enabled = True
            Label8.Text = AuxTabletConsulta.Rows(0)("Nombres").ToString
            Label9.Text = AuxTabletConsulta.Rows(0)("Apellidos").ToString
            TextBox1.Text = $"{Label8.Text} {Label9.Text}"
        Else
            BGuardar.Enabled = False
        End If
    End Sub

    Private Sub BEmpleado_Click(sender As Object, e As EventArgs) Handles BEmpleado.Click
        VentanaBusqueda = "Empleados"
        frmBuscarPersonas.ShowDialog()
        Dim AuxConsulta As New MySqlDataAdapter(selectCommandText:=$"SELECT Nombres, Apellidos FROM Empleados WHERE idEmpleado = '{RegistroActivo.Empleado}'", connection:=Conexion)
        Dim AuxTabletConsulta As New DataTable
        AuxConsulta.Fill(AuxTabletConsulta)

        If RegistroActivo.Empleado <> -1 Then
            BGuardar.Enabled = True
            Label10.Text = AuxTabletConsulta.Rows(0)("Nombres").ToString
            Label11.Text = AuxTabletConsulta.Rows(0)("Apellidos").ToString
            TextBox2.Text = $"{Label10.Text} {Label11.Text}"
        Else
            BGuardar.Enabled = False
        End If
    End Sub

    Private Sub BServicio_Click(sender As Object, e As EventArgs) Handles BServicio.Click

    End Sub

    Private Sub BGuardar_Click(sender As Object, e As EventArgs) Handles BGuardar.Click
        Dim HoraInicio As DateTime
        Select Case ComboBox1.SelectedIndex
            Case 0
                HoraInicio = CDate("7:00")
            Case 1
                HoraInicio = CDate("8:00")
            Case 2
                HoraInicio = CDate("9:00")
            Case 3
                HoraInicio = CDate("10:00")
            Case 4
                HoraInicio = CDate("11:00")
            Case 5
                HoraInicio = CDate("12:00")
            Case 6
                HoraInicio = CDate("1:00")
            Case 7
                HoraInicio = CDate("2:00")
            Case 8
                HoraInicio = CDate("3:00")
            Case 9
                HoraInicio = CDate("4:00")
            Case 10
                HoraInicio = CDate("5:00")
            Case 11
                HoraInicio = CDate("6:00")
        End Select

        Dim HoraFinal As DateTime = HoraInicio.AddHours(ComboBox2.SelectedIndex + 1)
        Operaciones($"INSERT INTO Citas (idEmpresa, idCliente, idEmpleado, idServicio, Fecha, HoraInicio, HoraFin, Observaciones, Agendada, Asistida, Cancelada, Reprogramada, CreadoPor, CreadoFecha, ModificadoPor, ModificadoFecha) VALUES ('{RegistroActivo.Empresa}', '{RegistroActivo.Cliente}', '{RegistroActivo.Empleado}', '{RegistroActivo.Servicio}', '{Format(DateTimePicker1.Value, "yyyy/MM/dd")}', '{Format(HoraInicio, "hh:mm")}', '{Format(HoraFinal, "hh:mm")}', '{TextBox5.Text}', '{1}', '{0}', '{0}', '{0}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}', '{UsuarioActivo.Nombre}', '{Format(Now(), "yyyy-MM-dd hh:mm:ss")}')")
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Close()
    End Sub
End Class