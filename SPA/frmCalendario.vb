Public Class frmCalendario
    Private Sub FrmCalendario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MonthCalendar1.AddBoldedDate(New Date(2017, 11, 4))
        MonthCalendar1.AddBoldedDate(New Date(2017, 11, 16))
        MonthCalendar1.AddBoldedDate(New Date(2017, 11, 20))
        MonthCalendar1.UpdateBoldedDates()


    End Sub

    Private Sub BSalir_Click(sender As Object, e As EventArgs) Handles BSalir.Click
        Close()
    End Sub

    Private Sub BNuevo_Click(sender As Object, e As EventArgs) Handles BNuevo.Click
        frmCita.ShowDialog()
    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        LFecha.Text = MonthCalendar1.SelectionStart.ToShortDateString
    End Sub
End Class