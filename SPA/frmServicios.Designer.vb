<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServicios
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
        Me.BSalir = New System.Windows.Forms.Button()
        Me.BBuscar = New System.Windows.Forms.Button()
        Me.BEliminar = New System.Windows.Forms.Button()
        Me.BEditar = New System.Windows.Forms.Button()
        Me.BNuevo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BSalir
        '
        Me.BSalir.Image = Global.SPA.My.Resources.Resources.Salir1
        Me.BSalir.Location = New System.Drawing.Point(12, 156)
        Me.BSalir.Name = "BSalir"
        Me.BSalir.Size = New System.Drawing.Size(28, 30)
        Me.BSalir.TabIndex = 15
        Me.BSalir.UseVisualStyleBackColor = True
        '
        'BBuscar
        '
        Me.BBuscar.Image = Global.SPA.My.Resources.Resources.Buscar1
        Me.BBuscar.Location = New System.Drawing.Point(12, 120)
        Me.BBuscar.Name = "BBuscar"
        Me.BBuscar.Size = New System.Drawing.Size(28, 30)
        Me.BBuscar.TabIndex = 14
        Me.BBuscar.UseVisualStyleBackColor = True
        '
        'BEliminar
        '
        Me.BEliminar.Image = Global.SPA.My.Resources.Resources.Borrar
        Me.BEliminar.Location = New System.Drawing.Point(12, 84)
        Me.BEliminar.Name = "BEliminar"
        Me.BEliminar.Size = New System.Drawing.Size(28, 30)
        Me.BEliminar.TabIndex = 13
        Me.BEliminar.UseVisualStyleBackColor = True
        '
        'BEditar
        '
        Me.BEditar.Image = Global.SPA.My.Resources.Resources.Editar
        Me.BEditar.Location = New System.Drawing.Point(12, 48)
        Me.BEditar.Name = "BEditar"
        Me.BEditar.Size = New System.Drawing.Size(28, 30)
        Me.BEditar.TabIndex = 12
        Me.BEditar.UseVisualStyleBackColor = True
        '
        'BNuevo
        '
        Me.BNuevo.Enabled = False
        Me.BNuevo.Image = Global.SPA.My.Resources.Resources.Nuevo
        Me.BNuevo.Location = New System.Drawing.Point(12, 12)
        Me.BNuevo.Name = "BNuevo"
        Me.BNuevo.Size = New System.Drawing.Size(28, 30)
        Me.BNuevo.TabIndex = 11
        Me.BNuevo.UseVisualStyleBackColor = True
        '
        'frmServicios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 371)
        Me.ControlBox = False
        Me.Controls.Add(Me.BSalir)
        Me.Controls.Add(Me.BBuscar)
        Me.Controls.Add(Me.BEliminar)
        Me.Controls.Add(Me.BEditar)
        Me.Controls.Add(Me.BNuevo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServicios"
        Me.Text = "Servicios Prestados"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BSalir As Button
    Friend WithEvents BBuscar As Button
    Friend WithEvents BEliminar As Button
    Friend WithEvents BEditar As Button
    Friend WithEvents BNuevo As Button
End Class
