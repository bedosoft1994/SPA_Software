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

    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click

    End Sub
End Class