<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnEditEstructuraContable
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnEditEstructuraContable))
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.grpBanco = New System.Windows.Forms.GroupBox
        Me.txtDigitos = New System.Windows.Forms.TextBox
        Me.txtNivel = New System.Windows.Forms.TextBox
        Me.lblDigitos = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.lblNivel = New System.Windows.Forms.Label
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.errEstructura = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpBanco.SuspendLayout()
        CType(Me.errEstructura, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(429, 170)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(352, 170)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 4
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'grpBanco
        '
        Me.grpBanco.Controls.Add(Me.txtDigitos)
        Me.grpBanco.Controls.Add(Me.txtNivel)
        Me.grpBanco.Controls.Add(Me.lblDigitos)
        Me.grpBanco.Controls.Add(Me.txtDescripcion)
        Me.grpBanco.Controls.Add(Me.lblNivel)
        Me.grpBanco.Controls.Add(Me.lblDescripcion)
        Me.grpBanco.Location = New System.Drawing.Point(12, 12)
        Me.grpBanco.Name = "grpBanco"
        Me.grpBanco.Size = New System.Drawing.Size(490, 152)
        Me.grpBanco.TabIndex = 21
        Me.grpBanco.TabStop = False
        Me.grpBanco.Text = "Datos de la Estructura"
        '
        'txtDigitos
        '
        Me.txtDigitos.Location = New System.Drawing.Point(91, 118)
        Me.txtDigitos.Name = "txtDigitos"
        Me.txtDigitos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDigitos.Size = New System.Drawing.Size(44, 20)
        Me.txtDigitos.TabIndex = 101
        Me.txtDigitos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNivel
        '
        Me.txtNivel.BackColor = System.Drawing.SystemColors.Info
        Me.txtNivel.Enabled = False
        Me.txtNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNivel.Location = New System.Drawing.Point(91, 26)
        Me.txtNivel.Name = "txtNivel"
        Me.txtNivel.ReadOnly = True
        Me.txtNivel.ShortcutsEnabled = False
        Me.txtNivel.Size = New System.Drawing.Size(44, 20)
        Me.txtNivel.TabIndex = 100
        Me.txtNivel.Tag = "LAYOUT:FLAT"
        '
        'lblDigitos
        '
        Me.lblDigitos.AutoSize = True
        Me.lblDigitos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDigitos.Location = New System.Drawing.Point(19, 123)
        Me.lblDigitos.Name = "lblDigitos"
        Me.lblDigitos.Size = New System.Drawing.Size(71, 13)
        Me.lblDigitos.TabIndex = 99
        Me.lblDigitos.Text = "Dígitos Nivel:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(91, 52)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(378, 60)
        Me.txtDescripcion.TabIndex = 2
        '
        'lblNivel
        '
        Me.lblNivel.AutoSize = True
        Me.lblNivel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNivel.Location = New System.Drawing.Point(19, 33)
        Me.lblNivel.Name = "lblNivel"
        Me.lblNivel.Size = New System.Drawing.Size(34, 13)
        Me.lblNivel.TabIndex = 1
        Me.lblNivel.Text = "Nivel:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDescripcion.Location = New System.Drawing.Point(19, 59)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "Descripción:"
        '
        'errEstructura
        '
        Me.errEstructura.ContainerControl = Me
        '
        'frmScnEditEstructuraContable
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(514, 207)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpBanco)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Estructura de Cuentas")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnEditEstructuraContable"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Estructura de Cuentas"
        Me.grpBanco.ResumeLayout(False)
        Me.grpBanco.PerformLayout()
        CType(Me.errEstructura, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpBanco As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblNivel As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents errEstructura As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDigitos As System.Windows.Forms.Label
    Friend WithEvents txtNivel As System.Windows.Forms.TextBox
    Friend WithEvents txtDigitos As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
