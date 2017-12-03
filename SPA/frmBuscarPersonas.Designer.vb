<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarPersonas
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
        Me.BAceptar = New System.Windows.Forms.Button()
        Me.BCancelar = New System.Windows.Forms.Button()
        Me.DGVBusqueda = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RbApellidos = New System.Windows.Forms.RadioButton()
        Me.RbNombres = New System.Windows.Forms.RadioButton()
        Me.RbCedula = New System.Windows.Forms.RadioButton()
        Me.TbxBusqueda = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DGVBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BAceptar
        '
        Me.BAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.BAceptar.Location = New System.Drawing.Point(250, 75)
        Me.BAceptar.Name = "BAceptar"
        Me.BAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BAceptar.TabIndex = 3
        Me.BAceptar.Text = "Aceptar"
        Me.BAceptar.UseVisualStyleBackColor = True
        '
        'BCancelar
        '
        Me.BCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BCancelar.Location = New System.Drawing.Point(341, 75)
        Me.BCancelar.Name = "BCancelar"
        Me.BCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BCancelar.TabIndex = 4
        Me.BCancelar.Text = "Cancelar"
        Me.BCancelar.UseVisualStyleBackColor = True
        '
        'DGVBusqueda
        '
        Me.DGVBusqueda.AllowUserToAddRows = False
        Me.DGVBusqueda.AllowUserToDeleteRows = False
        Me.DGVBusqueda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DGVBusqueda.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DGVBusqueda.Location = New System.Drawing.Point(12, 119)
        Me.DGVBusqueda.MultiSelect = False
        Me.DGVBusqueda.Name = "DGVBusqueda"
        Me.DGVBusqueda.ReadOnly = True
        Me.DGVBusqueda.Size = New System.Drawing.Size(419, 167)
        Me.DGVBusqueda.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RbApellidos)
        Me.GroupBox1.Controls.Add(Me.RbNombres)
        Me.GroupBox1.Controls.Add(Me.RbCedula)
        Me.GroupBox1.Location = New System.Drawing.Point(127, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(108, 100)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Buscar por... "
        '
        'RbApellidos
        '
        Me.RbApellidos.AutoSize = True
        Me.RbApellidos.Location = New System.Drawing.Point(7, 68)
        Me.RbApellidos.Name = "RbApellidos"
        Me.RbApellidos.Size = New System.Drawing.Size(67, 17)
        Me.RbApellidos.TabIndex = 2
        Me.RbApellidos.Text = "Apellidos"
        Me.RbApellidos.UseVisualStyleBackColor = True
        '
        'RbNombres
        '
        Me.RbNombres.AutoSize = True
        Me.RbNombres.Location = New System.Drawing.Point(7, 44)
        Me.RbNombres.Name = "RbNombres"
        Me.RbNombres.Size = New System.Drawing.Size(67, 17)
        Me.RbNombres.TabIndex = 1
        Me.RbNombres.Text = "Nombres"
        Me.RbNombres.UseVisualStyleBackColor = True
        '
        'RbCedula
        '
        Me.RbCedula.AutoSize = True
        Me.RbCedula.Checked = True
        Me.RbCedula.Location = New System.Drawing.Point(7, 20)
        Me.RbCedula.Name = "RbCedula"
        Me.RbCedula.Size = New System.Drawing.Size(88, 17)
        Me.RbCedula.TabIndex = 0
        Me.RbCedula.TabStop = True
        Me.RbCedula.Text = "Identificación"
        Me.RbCedula.UseVisualStyleBackColor = True
        '
        'TbxBusqueda
        '
        Me.TbxBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TbxBusqueda.Location = New System.Drawing.Point(250, 32)
        Me.TbxBusqueda.Name = "TbxBusqueda"
        Me.TbxBusqueda.Size = New System.Drawing.Size(166, 20)
        Me.TbxBusqueda.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.SPA.My.Resources.Resources.buscarcliente
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(109, 101)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'frmBuscarPersonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(443, 295)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TbxBusqueda)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DGVBusqueda)
        Me.Controls.Add(Me.BCancelar)
        Me.Controls.Add(Me.BAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarPersonas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmBuscarPersonas"
        CType(Me.DGVBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BAceptar As Button
    Friend WithEvents BCancelar As Button
    Friend WithEvents DGVBusqueda As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RbApellidos As RadioButton
    Friend WithEvents RbNombres As RadioButton
    Friend WithEvents RbCedula As RadioButton
    Friend WithEvents TbxBusqueda As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
