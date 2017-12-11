Public Class frmCalendario
    Private Sub FrmCalendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarDatos()

    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Close()
    End Sub

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        FrmCita.ShowDialog()
        CargarDatos()
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        CargarDatos()
    End Sub

    Private Sub CargarDatos()
        LFecha.Text = MonthCalendar1.SelectionStart.ToShortDateString
        Label14.Text = $"Citas para el mes de: {CDate(LFecha.Text).ToString("MMMM")}"

        Dim DataCitas As DataTable = Consulta(Sql:=$"SELECT Citas.idCliente, Clientes.idCliente, Citas.Fecha, Clientes.Nombres, Clientes.Apellidos FROM Clientes, Citas WHERE Month(Citas.Fecha)={CDate(LFecha.Text).Month} AND Year(Citas.Fecha)={CDate(LFecha.Text).Year} AND Clientes.idCliente=Citas.idCliente ORDER BY Citas.Fecha")
        DataGridCitas.DataSource = DataCitas
        DataGridCitas.Columns(0).Visible = False
        DataGridCitas.Columns(1).Visible = False

        Dim Registros = 0
        For Each fila As DataGridViewRow In DataGridCitas.Rows
            MonthCalendar1.AddBoldedDate(CDate(fila.Cells(2).Value.ToString))
        Next

        'Resaltar Fechas
        MonthCalendar1.UpdateBoldedDates()

    End Sub
End Class