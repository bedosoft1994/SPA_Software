﻿Imports MySql.Data.MySqlClient

Public Class frmPrincipal
    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsuarioActivo.Nombre = "Sin usuario"
        tssUsuario.BackColor = Color.Pink
        tssUsuario.Text = $"Usuario: {UsuarioActivo.Nombre}"
        UsuarioActivo.Permiso_Escritura = 0
        UsuarioActivo.Permiso_Lectura = 0
        UsuarioActivo.Permiso_Impresion = 0
        UsuarioActivo.Permiso_Programador = 0

        Cronometro.Enabled = True
        tssEstado.Text = $"Versión del sistema: {String.Format("{0}", My.Application.Info.Version.ToString)}"

        ConectarDatos()

    End Sub

    Private Sub EstadoBotones(Estado As Boolean)
        btnEmpresa.Enabled = Estado
        btnServicios.Enabled = Estado
        btnEmpleados.Enabled = Estado
        btnClientes.Enabled = Estado
        btnCitas.Enabled = Estado
        btnInformes.Enabled = Estado
        btnEstadisticas.Enabled = Estado
        btnConfiguracion.Enabled = Estado
    End Sub

    Private Sub btnSesion_Click(sender As Object, e As EventArgs) Handles btnSesion.Click
        If btnSesion.Text = "Abrir Sesión" And UsuarioActivo.Nombre = "Sin usuario" Then
            frmAcceso.ShowDialog()
            If frmAcceso.tbUsuario.Text = "" Then Exit Sub
            btnSesion.Text = "Cerrar Sesión"
            btnSesion.Image = SPA.My.Resources.Resources.desbloquear
            tssUsuario.BackColor = Color.LightGreen
            tssUsuario.Text = "Usuario: " & UsuarioActivo.Nombre
            EstadoBotones(True)
        Else
            If Editando Then
                If MsgBox("Tiene datos no guardados, ¿Desea perderlos?", CType(MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, MsgBoxStyle)) = vbCancel Then
                    Exit Sub
                End If
            End If
            Editando = False
            For Each frm As Form In Me.MdiChildren
                frm.Close()
            Next
            btnSesion.Text = "Abrir Sesión"
            btnSesion.Image = SPA.My.Resources.Resources.candado
            tssUsuario.BackColor = Color.Pink
            UsuarioActivo.Nombre = "Sin usuario"
            UsuarioActivo.Permiso_Escritura = 0
            UsuarioActivo.Permiso_Lectura = 0
            UsuarioActivo.Permiso_Impresion = 0
            UsuarioActivo.Permiso_Programador = 0
            UsuarioActivo.FechaIngreso = Today()
            tssUsuario.Text = "Usuario: " & UsuarioActivo.Nombre
            EstadoBotones(False)
        End If
    End Sub

    Private Sub btnEmpresa_Click(sender As Object, e As EventArgs) Handles btnEmpresa.Click
        frmEmpresa.MdiParent = Me
        frmEmpresa.Show()
    End Sub

    Private Sub Cronometro_Tick(sender As System.Object, e As System.EventArgs) Handles Cronometro.Tick
        If EstadoConexion Then
            tssEstadoMySql.BackColor = Color.LightGreen
            tssEstadoMySql.Text = "Conectado"
        Else
            tssEstadoMySql.BackColor = Color.Pink
            tssEstadoMySql.Text = "Sin conecxión"
        End If
        If UsuarioActivo.Nombre = "Sin usuario" Then
            tssUsuario.BackColor = Color.Pink
            tssUsuario.Text = "Usuario: " & UsuarioActivo.Nombre
        Else
            tssUsuario.BackColor = Color.LightGreen
            tssUsuario.Text = "Usuario: " & UsuarioActivo.Nombre
        End If

        tssFecha.Text = Format(Now(), "Long Date")
        tssHora.Text = Format(Now(), "Long Time")
    End Sub

    Private Sub btnServicios_Click(sender As Object, e As EventArgs) Handles btnServicios.Click

    End Sub

    Private Sub btnEmpleados_Click(sender As Object, e As EventArgs) Handles btnEmpleados.Click

    End Sub

    Private Sub btnClientes_Click(sender As Object, e As EventArgs) Handles btnClientes.Click

    End Sub

    Private Sub btnCitas_Click(sender As Object, e As EventArgs) Handles btnCitas.Click

    End Sub

    Private Sub btnInformes_Click(sender As Object, e As EventArgs) Handles btnInformes.Click

    End Sub

    Private Sub btnEstadisticas_Click(sender As Object, e As EventArgs) Handles btnEstadisticas.Click

    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click

    End Sub

    Private Sub btnAyuda_Click(sender As Object, e As EventArgs) Handles btnAyuda.Click

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If MsgBox("¿Desea salir de la aplicación?", CType(vbYesNo + vbExclamation + vbDefaultButton2, MsgBoxStyle)) = vbYes Then
            If Editando Then
                If MsgBox("Tiene datos no guardados, ¿Desea perderlos?", CType(MsgBoxStyle.Critical + MsgBoxStyle.OkCancel, MsgBoxStyle)) = vbCancel Then
                    Exit Sub
                End If
            End If
            Application.Exit()
        End If
    End Sub

End Class
