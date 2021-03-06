﻿Public Class frmPrincipal
    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsuarioActivo.Nombre = "Sin usuario"
        tssUsuario.BackColor = Color.Pink
        tssUsuario.Text = $"Usuario: {UsuarioActivo.Nombre}"
        UsuarioActivo.Permiso_Escritura = 0
        UsuarioActivo.Permiso_Lectura = 0
        UsuarioActivo.Permiso_Impresion = 0
        UsuarioActivo.Permiso_Admin = 0
        UsuarioActivo.Permiso_Programador = 0

        RegistroActivo.Empresa = 0

        Cronometro.Enabled = True
        Me.Text = My.Application.Info.Title.ToString
        tssEstado.Text = $"Versión del sistema: {String.Format("{0}", My.Application.Info.Version.ToString)}"

        Conectar()

    End Sub

    Private Sub EstadoBotones(Estado As Boolean)
        btnEmpresa.Enabled = Estado
        btnServicios.Enabled = Estado
        btnEmpleados.Enabled = Estado
        btnClientes.Enabled = Estado
        btnCitas.Enabled = Estado
        'btnInformes.Enabled = Estado
        'btnEstadisticas.Enabled = Estado
        btnConfiguracion.Enabled = Estado
    End Sub

    Private Sub BtnSesion_Click(sender As Object, e As EventArgs) Handles btnSesion.Click
        If btnSesion.Text = "Abrir Sesión" And UsuarioActivo.Nombre = "Sin usuario" Then
            FrmAcceso.ShowDialog()
            If FrmAcceso.tbUsuario.Text = "" Then Exit Sub
            btnSesion.Text = "Cerrar Sesión"
            btnSesion.Image = My.Resources.desbloquear
            tssUsuario.BackColor = Color.LightGreen
            tssUsuario.Text = $"Usuario: {UsuarioActivo.Nombre}"
            EstadoBotones(True)
        Else
            If Editando Then
                If MsgBox(Prompt:="Tiene datos no guardados, ¿Desea perderlos?", Buttons:=CType(MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, MsgBoxStyle)) = vbCancel Then
                    Exit Sub
                End If
            End If
            Editando = False
            For Each frm As Form In Me.MdiChildren
                frm.Close()
            Next
            btnSesion.Text = "Abrir Sesión"
            btnSesion.Image = My.Resources.candado
            tssUsuario.BackColor = Color.Pink
            UsuarioActivo.Nombre = "Sin usuario"
            UsuarioActivo.Permiso_Escritura = 0
            UsuarioActivo.Permiso_Lectura = 0
            UsuarioActivo.Permiso_Impresion = 0
            UsuarioActivo.Permiso_Admin = 0
            UsuarioActivo.Permiso_Programador = 0
            UsuarioActivo.FechaIngreso = Today()
            RegistroActivo.Empresa = 0
            tssUsuario.Text = $"Usuario: {UsuarioActivo.Nombre}"
            EstadoBotones(False)
        End If
    End Sub

    Private Sub BtnEmpresa_Click(sender As Object, e As EventArgs) Handles btnEmpresa.Click
        frmEmpresa.MdiParent = Me
        frmEmpresa.Show()
    End Sub

    Private Sub Cronometro_Tick(sender As System.Object, e As System.EventArgs) Handles Cronometro.Tick
        If Conexion.Ping() Then
            tssEstadoMySql.BackColor = Color.LightGreen
            tssEstadoMySql.Text = "Conectado"
        Else
            tssEstadoMySql.BackColor = Color.Pink
            tssEstadoMySql.Text = "Sin conexión"
        End If
        If UsuarioActivo.Nombre = "Sin usuario" Then
            tssUsuario.BackColor = Color.Pink
            tssUsuario.Text = $"Usuario: {UsuarioActivo.Nombre}"
        Else
            tssUsuario.BackColor = Color.LightGreen
            tssUsuario.Text = $"Usuario: {UsuarioActivo.Nombre}"
        End If

        tssFecha.Text = Format(Now(), Style:="Long Date")
        tssHora.Text = Format(Now(), Style:="Long Time")
    End Sub

    Private Sub BtnServicios_Click(sender As Object, e As EventArgs) Handles btnServicios.Click
        frmServicios.MdiParent = Me
        frmServicios.Show()
    End Sub

    Private Sub BtnEmpleados_Click(sender As Object, e As EventArgs) Handles btnEmpleados.Click
        FrmEmpleados.MdiParent = Me
        FrmEmpleados.Show()
    End Sub

    Private Sub BtnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click
        FrmClientes.MdiParent = Me
        FrmClientes.Show()
    End Sub

    Private Sub BtnCitas_Click(sender As Object, e As EventArgs) Handles btnCitas.Click
        frmCalendario.MdiParent = Me
        frmCalendario.Dock = DockStyle.Fill
        frmCalendario.Show()
    End Sub

    Private Sub BtnInformes_Click(sender As Object, e As EventArgs) Handles btnInformes.Click
        frmInformes.MdiParent = Me
        frmInformes.Show()
    End Sub

    Private Sub BtnEstadisticas_Click(sender As Object, e As EventArgs) Handles btnEstadisticas.Click
        frmEstadística.MdiParent = Me
        frmEstadística.Show()
    End Sub

    Private Sub BtnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click
        frmConfiguracion.MdiParent = Me
        frmConfiguracion.Show()
    End Sub

    Private Sub BtnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click
        frmAcercade.ShowDialog()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Application.Exit()
    End Sub

    Private Sub FrmPrincipal_Closing(sender As Object, e As CancelEventArgs) Handles Me.FormClosing
        If MsgBox(Prompt:="¿Desea salir de la aplicación?", Buttons:=CType(vbYesNo + vbExclamation + vbDefaultButton2, MsgBoxStyle)) = vbYes Then
            If Editando Then
                If MsgBox(Prompt:="No se han  guardado los datos, ¿Desea perderlos?", Buttons:=CType(MsgBoxStyle.Critical + MsgBoxStyle.YesNo, MsgBoxStyle)) = vbNo Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Else
            e.Cancel = True
        End If
    End Sub
End Class
