<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ListaImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Cronometro = New System.Windows.Forms.Timer(Me.components)
        Me.sBarraEstado = New System.Windows.Forms.StatusStrip()
        Me.tssEstado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssEstadoMySql = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssFecha = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssHora = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSesion = New System.Windows.Forms.Button()
        Me.btnAyuda = New System.Windows.Forms.Button()
        Me.btnConfiguracion = New System.Windows.Forms.Button()
        Me.btnEstadisticas = New System.Windows.Forms.Button()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnInformes = New System.Windows.Forms.Button()
        Me.btnCitas = New System.Windows.Forms.Button()
        Me.btnClientes = New System.Windows.Forms.Button()
        Me.btnEmpleados = New System.Windows.Forms.Button()
        Me.btnServicios = New System.Windows.Forms.Button()
        Me.btnEmpresa = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.sBarraEstado.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSesion)
        Me.Panel1.Controls.Add(Me.btnAyuda)
        Me.Panel1.Controls.Add(Me.btnConfiguracion)
        Me.Panel1.Controls.Add(Me.btnEstadisticas)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btnInformes)
        Me.Panel1.Controls.Add(Me.btnCitas)
        Me.Panel1.Controls.Add(Me.btnClientes)
        Me.Panel1.Controls.Add(Me.btnEmpleados)
        Me.Panel1.Controls.Add(Me.btnServicios)
        Me.Panel1.Controls.Add(Me.btnEmpresa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 106)
        Me.Panel1.TabIndex = 0
        '
        'ListaImagenes
        '
        Me.ListaImagenes.ImageStream = CType(resources.GetObject("ListaImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ListaImagenes.TransparentColor = System.Drawing.Color.Transparent
        Me.ListaImagenes.Images.SetKeyName(0, "candado.png")
        Me.ListaImagenes.Images.SetKeyName(1, "cerrado.png")
        Me.ListaImagenes.Images.SetKeyName(2, "desbloquear.png")
        '
        'Cronometro
        '
        '
        'sBarraEstado
        '
        Me.sBarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssEstado, Me.tssEstadoMySql, Me.tssUsuario, Me.tssFecha, Me.tssHora})
        Me.sBarraEstado.Location = New System.Drawing.Point(0, 637)
        Me.sBarraEstado.Name = "sBarraEstado"
        Me.sBarraEstado.Size = New System.Drawing.Size(1019, 24)
        Me.sBarraEstado.TabIndex = 4
        Me.sBarraEstado.Text = "StatusStrip1"
        '
        'tssEstado
        '
        Me.tssEstado.Name = "tssEstado"
        Me.tssEstado.Size = New System.Drawing.Size(796, 19)
        Me.tssEstado.Spring = True
        Me.tssEstado.Text = "Estado"
        Me.tssEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tssEstadoMySql
        '
        Me.tssEstadoMySql.BackColor = System.Drawing.Color.Red
        Me.tssEstadoMySql.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssEstadoMySql.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tssEstadoMySql.Name = "tssEstadoMySql"
        Me.tssEstadoMySql.Size = New System.Drawing.Size(78, 19)
        Me.tssEstadoMySql.Text = "Sin conexión"
        '
        'tssUsuario
        '
        Me.tssUsuario.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssUsuario.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tssUsuario.Name = "tssUsuario"
        Me.tssUsuario.Size = New System.Drawing.Size(51, 19)
        Me.tssUsuario.Text = "Usuario"
        '
        'tssFecha
        '
        Me.tssFecha.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssFecha.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tssFecha.Name = "tssFecha"
        Me.tssFecha.Size = New System.Drawing.Size(42, 19)
        Me.tssFecha.Text = "Fecha"
        '
        'tssHora
        '
        Me.tssHora.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tssHora.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
        Me.tssHora.Name = "tssHora"
        Me.tssHora.Size = New System.Drawing.Size(37, 19)
        Me.tssHora.Text = "Hora"
        '
        'btnSesion
        '
        Me.btnSesion.Image = Global.SPA.My.Resources.Resources.candado
        Me.btnSesion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSesion.Location = New System.Drawing.Point(12, 12)
        Me.btnSesion.Name = "btnSesion"
        Me.btnSesion.Size = New System.Drawing.Size(85, 84)
        Me.btnSesion.TabIndex = 1
        Me.btnSesion.Text = "Abrir Sesión"
        Me.btnSesion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSesion.UseVisualStyleBackColor = True
        '
        'btnAyuda
        '
        Me.btnAyuda.Image = Global.SPA.My.Resources.Resources.ayuda
        Me.btnAyuda.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAyuda.Location = New System.Drawing.Point(831, 12)
        Me.btnAyuda.Name = "btnAyuda"
        Me.btnAyuda.Size = New System.Drawing.Size(85, 84)
        Me.btnAyuda.TabIndex = 10
        Me.btnAyuda.Text = "Ayuda"
        Me.btnAyuda.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAyuda.UseVisualStyleBackColor = True
        '
        'btnConfiguracion
        '
        Me.btnConfiguracion.Enabled = False
        Me.btnConfiguracion.Image = Global.SPA.My.Resources.Resources.opciones
        Me.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnConfiguracion.Location = New System.Drawing.Point(740, 12)
        Me.btnConfiguracion.Name = "btnConfiguracion"
        Me.btnConfiguracion.Size = New System.Drawing.Size(85, 84)
        Me.btnConfiguracion.TabIndex = 9
        Me.btnConfiguracion.Text = "Configuracion"
        Me.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConfiguracion.UseVisualStyleBackColor = True
        '
        'btnEstadisticas
        '
        Me.btnEstadisticas.Enabled = False
        Me.btnEstadisticas.Image = Global.SPA.My.Resources.Resources.estadistica
        Me.btnEstadisticas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEstadisticas.Location = New System.Drawing.Point(649, 12)
        Me.btnEstadisticas.Name = "btnEstadisticas"
        Me.btnEstadisticas.Size = New System.Drawing.Size(85, 84)
        Me.btnEstadisticas.TabIndex = 8
        Me.btnEstadisticas.Text = "Estadísticas"
        Me.btnEstadisticas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEstadisticas.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Image = Global.SPA.My.Resources.Resources.salir
        Me.btnSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSalir.Location = New System.Drawing.Point(922, 12)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(85, 84)
        Me.btnSalir.TabIndex = 11
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnInformes
        '
        Me.btnInformes.Enabled = False
        Me.btnInformes.Image = Global.SPA.My.Resources.Resources.informe
        Me.btnInformes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnInformes.Location = New System.Drawing.Point(558, 12)
        Me.btnInformes.Name = "btnInformes"
        Me.btnInformes.Size = New System.Drawing.Size(85, 84)
        Me.btnInformes.TabIndex = 7
        Me.btnInformes.Text = "Informes"
        Me.btnInformes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInformes.UseVisualStyleBackColor = True
        '
        'btnCitas
        '
        Me.btnCitas.Enabled = False
        Me.btnCitas.Image = Global.SPA.My.Resources.Resources.calendario
        Me.btnCitas.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCitas.Location = New System.Drawing.Point(467, 12)
        Me.btnCitas.Name = "btnCitas"
        Me.btnCitas.Size = New System.Drawing.Size(85, 84)
        Me.btnCitas.TabIndex = 6
        Me.btnCitas.Text = "Citas"
        Me.btnCitas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCitas.UseVisualStyleBackColor = True
        '
        'btnClientes
        '
        Me.btnClientes.Enabled = False
        Me.btnClientes.Image = Global.SPA.My.Resources.Resources.clienta
        Me.btnClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnClientes.Location = New System.Drawing.Point(376, 12)
        Me.btnClientes.Name = "btnClientes"
        Me.btnClientes.Size = New System.Drawing.Size(85, 84)
        Me.btnClientes.TabIndex = 5
        Me.btnClientes.Text = "Clientes"
        Me.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnClientes.UseVisualStyleBackColor = True
        '
        'btnEmpleados
        '
        Me.btnEmpleados.Enabled = False
        Me.btnEmpleados.Image = Global.SPA.My.Resources.Resources.empleado
        Me.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEmpleados.Location = New System.Drawing.Point(285, 12)
        Me.btnEmpleados.Name = "btnEmpleados"
        Me.btnEmpleados.Size = New System.Drawing.Size(85, 84)
        Me.btnEmpleados.TabIndex = 4
        Me.btnEmpleados.Text = "Empleados"
        Me.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEmpleados.UseVisualStyleBackColor = True
        '
        'btnServicios
        '
        Me.btnServicios.Enabled = False
        Me.btnServicios.Image = Global.SPA.My.Resources.Resources.masaje
        Me.btnServicios.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnServicios.Location = New System.Drawing.Point(194, 12)
        Me.btnServicios.Name = "btnServicios"
        Me.btnServicios.Size = New System.Drawing.Size(85, 84)
        Me.btnServicios.TabIndex = 3
        Me.btnServicios.Text = "Servicios"
        Me.btnServicios.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnServicios.UseVisualStyleBackColor = True
        '
        'btnEmpresa
        '
        Me.btnEmpresa.Enabled = False
        Me.btnEmpresa.Image = Global.SPA.My.Resources.Resources.empresa
        Me.btnEmpresa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEmpresa.Location = New System.Drawing.Point(103, 12)
        Me.btnEmpresa.Name = "btnEmpresa"
        Me.btnEmpresa.Size = New System.Drawing.Size(85, 84)
        Me.btnEmpresa.TabIndex = 2
        Me.btnEmpresa.Text = "Empresa"
        Me.btnEmpresa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEmpresa.UseVisualStyleBackColor = True
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 661)
        Me.Controls.Add(Me.sBarraEstado)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MinimumSize = New System.Drawing.Size(1035, 700)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SPA Soluciones"
        Me.Panel1.ResumeLayout(False)
        Me.sBarraEstado.ResumeLayout(False)
        Me.sBarraEstado.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnEmpresa As Button
    Friend WithEvents btnEstadisticas As Button
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnInformes As Button
    Friend WithEvents btnCitas As Button
    Friend WithEvents btnClientes As Button
    Friend WithEvents btnEmpleados As Button
    Friend WithEvents btnServicios As Button
    Friend WithEvents btnConfiguracion As Button
    Friend WithEvents btnSesion As Button
    Friend WithEvents btnAyuda As Button
    Friend WithEvents ListaImagenes As ImageList
    Friend WithEvents Cronometro As Timer
    Friend WithEvents sBarraEstado As StatusStrip
    Friend WithEvents tssEstado As ToolStripStatusLabel
    Friend WithEvents tssEstadoMySql As ToolStripStatusLabel
    Friend WithEvents tssUsuario As ToolStripStatusLabel
    Friend WithEvents tssFecha As ToolStripStatusLabel
    Friend WithEvents tssHora As ToolStripStatusLabel
End Class
