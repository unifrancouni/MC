<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbEditDistrito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbEditDistrito))
        Me.grpDepartamento = New System.Windows.Forms.GroupBox
        Me.chkIncluidoPrograma = New System.Windows.Forms.CheckBox
        Me.lblIncluidoPrograma = New System.Windows.Forms.Label
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.lblActivo = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.lblNombre = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.errDistrito = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDepartamento.SuspendLayout()
        CType(Me.errDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDepartamento
        '
        Me.grpDepartamento.Controls.Add(Me.chkIncluidoPrograma)
        Me.grpDepartamento.Controls.Add(Me.lblIncluidoPrograma)
        Me.grpDepartamento.Controls.Add(Me.chkActivo)
        Me.grpDepartamento.Controls.Add(Me.lblActivo)
        Me.grpDepartamento.Controls.Add(Me.txtCodigo)
        Me.grpDepartamento.Controls.Add(Me.txtNombre)
        Me.grpDepartamento.Controls.Add(Me.lblNombre)
        Me.grpDepartamento.Controls.Add(Me.lblCodigo)
        Me.grpDepartamento.Location = New System.Drawing.Point(12, 12)
        Me.grpDepartamento.Name = "grpDepartamento"
        Me.grpDepartamento.Size = New System.Drawing.Size(490, 145)
        Me.grpDepartamento.TabIndex = 0
        Me.grpDepartamento.TabStop = False
        Me.grpDepartamento.Text = "Datos del Distrito"
        '
        'chkIncluidoPrograma
        '
        Me.chkIncluidoPrograma.AutoSize = True
        Me.chkIncluidoPrograma.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIncluidoPrograma.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkIncluidoPrograma.Location = New System.Drawing.Point(237, 88)
        Me.chkIncluidoPrograma.Name = "chkIncluidoPrograma"
        Me.chkIncluidoPrograma.Size = New System.Drawing.Size(17, 17)
        Me.chkIncluidoPrograma.TabIndex = 2
        Me.chkIncluidoPrograma.Tag = ""
        Me.chkIncluidoPrograma.Text = "  "
        Me.chkIncluidoPrograma.UseVisualStyleBackColor = True
        '
        'lblIncluidoPrograma
        '
        Me.lblIncluidoPrograma.AutoSize = True
        Me.lblIncluidoPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblIncluidoPrograma.Location = New System.Drawing.Point(19, 89)
        Me.lblIncluidoPrograma.Name = "lblIncluidoPrograma"
        Me.lblIncluidoPrograma.Size = New System.Drawing.Size(201, 13)
        Me.lblIncluidoPrograma.TabIndex = 117
        Me.lblIncluidoPrograma.Text = "Incluido en el Programa de Micro Crédito:"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkActivo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkActivo.Location = New System.Drawing.Point(91, 116)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(17, 17)
        Me.chkActivo.TabIndex = 3
        Me.chkActivo.Tag = ""
        Me.chkActivo.Text = "  "
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblActivo.Location = New System.Drawing.Point(19, 117)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(40, 13)
        Me.lblActivo.TabIndex = 99
        Me.lblActivo.Text = "Activo:"
        '
        'txtCodigo
        '
        Me.txtCodigo.AcceptsTab = True
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(91, 27)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(43, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(91, 53)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(378, 20)
        Me.txtNombre.TabIndex = 1
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(19, 60)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(19, 34)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 23
        Me.lblCodigo.Text = "Código:"
        '
        'errDistrito
        '
        Me.errDistrito.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(352, 163)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(429, 163)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmStbEditDistrito
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(514, 200)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpDepartamento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Distritos")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbEditDistrito"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Distrito"
        Me.grpDepartamento.ResumeLayout(False)
        Me.grpDepartamento.PerformLayout()
        CType(Me.errDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpDepartamento As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents errDistrito As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents chkIncluidoPrograma As System.Windows.Forms.CheckBox
    Friend WithEvents lblIncluidoPrograma As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
