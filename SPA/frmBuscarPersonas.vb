Public Class frmBuscarPersonas
    Dim DataTabletBusqueda As New DataTable
    Dim Busqueda As String = ""
    Dim ListaBusqueda As Byte

    Private Sub FrmBuscarPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case VentanaBusqueda
            Case "Clientes"
                Busqueda = "SELECT idCliente, Identificacion, Nombres, Apellidos FROM Clientes"
                Text = "Búsqueda de Clientes"
            Case "Empleados"
                Busqueda = "SELECT idEmpleado, Identificacion, Nombres, Apellidos FROM Empleados"
                Text = "Búsqueda de Empleados"
            Case Else
                Exit Select
        End Select

        DataTabletBusqueda = Consulta(Busqueda)
        DGVBusqueda.DataSource = DataTabletBusqueda
        DGVBusqueda.Columns(0).Visible = False
        ListaBusqueda = CByte(DataTabletBusqueda.Rows.Count)
        TbxBusqueda.Clear()
        TbxBusqueda.Select()
    End Sub

    Private Sub TbxBusqueda_TextChanged(sender As Object, e As EventArgs) Handles TbxBusqueda.TextChanged
        If RbCedula.Checked Then
            DataTabletBusqueda = Consulta(Sql:=$"{Busqueda} WHERE Identificacion LIKE '%{TbxBusqueda.Text}%'")
        End If
        If RbNombres.Checked Then
            DataTabletBusqueda = Consulta(Sql:=$"{Busqueda} WHERE Nombres LIKE '%{TbxBusqueda.Text}%'")
        End If
        If RbApellidos.Checked Then
            DataTabletBusqueda = Consulta(Sql:=$"{Busqueda} WHERE Apellidos LIKE '%{TbxBusqueda.Text}%'")
        End If
        DGVBusqueda.DataSource = DataTabletBusqueda
    End Sub

    Private Sub BAceptar_Click(sender As Object, e As EventArgs) Handles BAceptar.Click
        ListaBusqueda = CByte(DataTabletBusqueda.Rows.Count)
        Select Case VentanaBusqueda
            Case "Clientes"
                If ListaBusqueda = 0 Then
                    RegistroActivo.Cliente = -1
                Else
                    RegistroActivo.Cliente = CInt(DGVBusqueda(columnIndex:=0, rowIndex:=DGVBusqueda.CurrentCell.RowIndex).Value)
                End If
            Case "Empleados"
                If ListaBusqueda = 0 Then
                    RegistroActivo.Empleado = -1
                Else
                    RegistroActivo.Empleado = CInt(DGVBusqueda(columnIndex:=0, rowIndex:=DGVBusqueda.CurrentCell.RowIndex).Value)
                End If
        End Select
    End Sub

    Private Sub BCancelar_Click(sender As Object, e As EventArgs) Handles BCancelar.Click
        Select Case VentanaBusqueda
            Case "Clientes"
                RegistroActivo.Cliente = -1
            Case "Empleados"
                RegistroActivo.Empleado = -1
        End Select
    End Sub

    Private Sub RbCedula_CheckedChanged(sender As Object, e As EventArgs) Handles RbCedula.CheckedChanged, RbNombres.CheckedChanged, RbApellidos.CheckedChanged
        TbxBusqueda.Select()
        TbxBusqueda.SelectAll()
        If Busqueda <> "" Then
            TbxBusqueda_TextChanged(sender, e)
        End If
    End Sub
End Class