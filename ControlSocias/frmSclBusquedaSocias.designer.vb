<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclBusquedaSocias
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclBusquedaSocias))
        Me.grpSociaGe = New System.Windows.Forms.GroupBox
        Me.GrpNombreCompleto = New System.Windows.Forms.GroupBox
        Me.TxtSegundoApellido = New System.Windows.Forms.TextBox
        Me.TxtPrimerApellido = New System.Windows.Forms.TextBox
        Me.TxtSegundoNombre = New System.Windows.Forms.TextBox
        Me.TxtPrimerNombre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkTipoBusqueda = New System.Windows.Forms.CheckBox
        Me.txtNombreSocia = New System.Windows.Forms.TextBox
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox
        Me.lblCedula = New System.Windows.Forms.Label
        Me.lblNombreSocia = New System.Windows.Forms.Label
        Me.errSocia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpBotones = New System.Windows.Forms.GroupBox
        Me.LblConteo = New System.Windows.Forms.Label
        Me.cmdUltimo = New System.Windows.Forms.Button
        Me.cmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAnterior = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpSociaGe.SuspendLayout()
        Me.GrpNombreCompleto.SuspendLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.GrpNombreCompleto)
        Me.grpSociaGe.Controls.Add(Me.ChkTipoBusqueda)
        Me.grpSociaGe.Controls.Add(Me.txtNombreSocia)
        Me.grpSociaGe.Controls.Add(Me.mtbNumCedula)
        Me.grpSociaGe.Controls.Add(Me.lblCedula)
        Me.grpSociaGe.Controls.Add(Me.lblNombreSocia)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 12)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(583, 197)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Datos Generales: "
        '
        'GrpNombreCompleto
        '
        Me.GrpNombreCompleto.Controls.Add(Me.TxtSegundoApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtPrimerApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtSegundoNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtPrimerNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.Label3)
        Me.GrpNombreCompleto.Controls.Add(Me.Label4)
        Me.GrpNombreCompleto.Controls.Add(Me.Label2)
        Me.GrpNombreCompleto.Controls.Add(Me.Label1)
        Me.GrpNombreCompleto.Location = New System.Drawing.Point(16, 44)
        Me.GrpNombreCompleto.Name = "GrpNombreCompleto"
        Me.GrpNombreCompleto.Size = New System.Drawing.Size(554, 107)
        Me.GrpNombreCompleto.TabIndex = 42
        Me.GrpNombreCompleto.TabStop = False
        '
        'TxtSegundoApellido
        '
        Me.TxtSegundoApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSegundoApellido.Location = New System.Drawing.Point(389, 60)
        Me.TxtSegundoApellido.Name = "TxtSegundoApellido"
        Me.TxtSegundoApellido.Size = New System.Drawing.Size(158, 20)
        Me.TxtSegundoApellido.TabIndex = 48
        '
        'TxtPrimerApellido
        '
        Me.TxtPrimerApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrimerApellido.Location = New System.Drawing.Point(127, 60)
        Me.TxtPrimerApellido.Name = "TxtPrimerApellido"
        Me.TxtPrimerApellido.Size = New System.Drawing.Size(158, 20)
        Me.TxtPrimerApellido.TabIndex = 47
        '
        'TxtSegundoNombre
        '
        Me.TxtSegundoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSegundoNombre.Location = New System.Drawing.Point(389, 30)
        Me.TxtSegundoNombre.Name = "TxtSegundoNombre"
        Me.TxtSegundoNombre.Size = New System.Drawing.Size(158, 20)
        Me.TxtSegundoNombre.TabIndex = 46
        '
        'TxtPrimerNombre
        '
        Me.TxtPrimerNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrimerNombre.Location = New System.Drawing.Point(127, 27)
        Me.TxtPrimerNombre.Name = "TxtPrimerNombre"
        Me.TxtPrimerNombre.Size = New System.Drawing.Size(158, 20)
        Me.TxtPrimerNombre.TabIndex = 45
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(290, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Segundo Apellido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(7, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Primer Apellido:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(290, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Segundo Nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Primer Nombre:"
        '
        'ChkTipoBusqueda
        '
        Me.ChkTipoBusqueda.AutoSize = True
        Me.ChkTipoBusqueda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ChkTipoBusqueda.Location = New System.Drawing.Point(309, 18)
        Me.ChkTipoBusqueda.Name = "ChkTipoBusqueda"
        Me.ChkTipoBusqueda.Size = New System.Drawing.Size(129, 17)
        Me.ChkTipoBusqueda.TabIndex = 41
        Me.ChkTipoBusqueda.Text = "Búsqueda Por Cédula"
        Me.ChkTipoBusqueda.UseVisualStyleBackColor = True
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(143, 164)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(427, 20)
        Me.txtNombreSocia.TabIndex = 2
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(143, 18)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 1
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(20, 25)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 30
        Me.lblCedula.Text = "Número Cédula:"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(23, 167)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(103, 13)
        Me.lblNombreSocia.TabIndex = 26
        Me.lblNombreSocia.Text = "Nombre de la Socia:"
        '
        'errSocia
        '
        Me.errSocia.ContainerControl = Me
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(15, 246)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(583, 50)
        Me.grpBotones.TabIndex = 10
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
        Me.CmdPrimero.Location = New System.Drawing.Point(23, 17)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(73, 25)
        Me.CmdPrimero.TabIndex = 10
        Me.CmdPrimero.Text = "Primero"
        Me.CmdPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(355, 215)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 11
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(509, 215)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(432, 215)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 4
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmSclBusquedaSocias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 308)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpSociaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclBusquedaSocias"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Datos Socia"
        Me.grpSociaGe.ResumeLayout(False)
        Me.grpSociaGe.PerformLayout()
        Me.GrpNombreCompleto.ResumeLayout(False)
        Me.GrpNombreCompleto.PerformLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errSocia As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents ChkTipoBusqueda As System.Windows.Forms.CheckBox
    Friend WithEvents GrpNombreCompleto As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtSegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
