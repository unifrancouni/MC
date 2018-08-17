<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditSociaGS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditSociaGS))
        Me.grpSocia = New System.Windows.Forms.GroupBox
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.grpBotones = New System.Windows.Forms.GroupBox
        Me.LblConteo = New System.Windows.Forms.Label
        Me.cmdUltimo = New System.Windows.Forms.Button
        Me.cmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAnterior = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.txtNombreSocia = New System.Windows.Forms.TextBox
        Me.lblNombreSocia = New System.Windows.Forms.Label
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox
        Me.chkCoordinadora = New System.Windows.Forms.CheckBox
        Me.lblCoordinadora = New System.Windows.Forms.Label
        Me.lblSocia = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.errModulo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpSocia.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        CType(Me.errModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSocia
        '
        Me.grpSocia.Controls.Add(Me.cmdBuscar)
        Me.grpSocia.Controls.Add(Me.grpBotones)
        Me.grpSocia.Controls.Add(Me.txtNombreSocia)
        Me.grpSocia.Controls.Add(Me.lblNombreSocia)
        Me.grpSocia.Controls.Add(Me.mtbNumCedula)
        Me.grpSocia.Controls.Add(Me.chkCoordinadora)
        Me.grpSocia.Controls.Add(Me.lblCoordinadora)
        Me.grpSocia.Controls.Add(Me.lblSocia)
        Me.grpSocia.Location = New System.Drawing.Point(12, 12)
        Me.grpSocia.Name = "grpSocia"
        Me.grpSocia.Size = New System.Drawing.Size(619, 202)
        Me.grpSocia.TabIndex = 0
        Me.grpSocia.TabStop = False
        Me.grpSocia.Text = "Datos de la Socia"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(248, 23)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 12
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(19, 130)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(583, 50)
        Me.grpBotones.TabIndex = 105
        Me.grpBotones.TabStop = False
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(261, 23)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(0, 13)
        Me.LblConteo.TabIndex = 14
        '
        'cmdUltimo
        '
        Me.cmdUltimo.Image = Global.SMUSURA0.My.Resources.Resources.player_end
        Me.cmdUltimo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUltimo.Location = New System.Drawing.Point(497, 17)
        Me.cmdUltimo.Name = "cmdUltimo"
        Me.cmdUltimo.Size = New System.Drawing.Size(73, 25)
        Me.cmdUltimo.TabIndex = 13
        Me.cmdUltimo.Text = "Ultimo"
        Me.cmdUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdSiguiente
        '
        Me.cmdSiguiente.Image = Global.SMUSURA0.My.Resources.Resources.rightarrow
        Me.cmdSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSiguiente.Location = New System.Drawing.Point(418, 17)
        Me.cmdSiguiente.Name = "cmdSiguiente"
        Me.cmdSiguiente.Size = New System.Drawing.Size(73, 25)
        Me.cmdSiguiente.TabIndex = 12
        Me.cmdSiguiente.Text = "Siguiente"
        Me.cmdSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAnterior
        '
        Me.CmdAnterior.Image = Global.SMUSURA0.My.Resources.Resources.leftarrow
        Me.CmdAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAnterior.Location = New System.Drawing.Point(102, 17)
        Me.CmdAnterior.Name = "CmdAnterior"
        Me.CmdAnterior.Size = New System.Drawing.Size(73, 25)
        Me.CmdAnterior.TabIndex = 11
        Me.CmdAnterior.Text = "Anterior"
        Me.CmdAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAnterior.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = Global.SMUSURA0.My.Resources.Resources.player_start
        Me.CmdPrimero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrimero.Location = New System.Drawing.Point(22, 17)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(73, 25)
        Me.CmdPrimero.TabIndex = 10
        Me.CmdPrimero.Text = "Primero"
        Me.CmdPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(97, 62)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(416, 20)
        Me.txtNombreSocia.TabIndex = 103
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(16, 65)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(77, 13)
        Me.lblNombreSocia.TabIndex = 104
        Me.lblNombreSocia.Text = "Nombre Socia:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(97, 26)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 102
        '
        'chkCoordinadora
        '
        Me.chkCoordinadora.AutoSize = True
        Me.chkCoordinadora.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCoordinadora.Enabled = False
        Me.chkCoordinadora.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkCoordinadora.Location = New System.Drawing.Point(97, 97)
        Me.chkCoordinadora.Name = "chkCoordinadora"
        Me.chkCoordinadora.Size = New System.Drawing.Size(17, 17)
        Me.chkCoordinadora.TabIndex = 2
        Me.chkCoordinadora.Tag = ""
        Me.chkCoordinadora.Text = "  "
        Me.chkCoordinadora.UseVisualStyleBackColor = True
        '
        'lblCoordinadora
        '
        Me.lblCoordinadora.AutoSize = True
        Me.lblCoordinadora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCoordinadora.Location = New System.Drawing.Point(14, 98)
        Me.lblCoordinadora.Name = "lblCoordinadora"
        Me.lblCoordinadora.Size = New System.Drawing.Size(73, 13)
        Me.lblCoordinadora.TabIndex = 101
        Me.lblCoordinadora.Text = "Coordinadora:"
        '
        'lblSocia
        '
        Me.lblSocia.AutoSize = True
        Me.lblSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSocia.Location = New System.Drawing.Point(18, 29)
        Me.lblSocia.Name = "lblSocia"
        Me.lblSocia.Size = New System.Drawing.Size(73, 13)
        Me.lblSocia.TabIndex = 13
        Me.lblSocia.Text = "Cédula Socia:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(558, 220)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(481, 220)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 3
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'errModulo
        '
        Me.errModulo.ContainerControl = Me
        '
        'frmSclEditSociaGS
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(641, 250)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpSocia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Grupos Solidarios")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditSociaGS"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Registro de Socias"
        Me.grpSocia.ResumeLayout(False)
        Me.grpSocia.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        CType(Me.errModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSocia As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lblSocia As System.Windows.Forms.Label
    Friend WithEvents errModulo As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkCoordinadora As System.Windows.Forms.CheckBox
    Friend WithEvents lblCoordinadora As System.Windows.Forms.Label
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
