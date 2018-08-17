<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditSociaConyuge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditSociaConyuge))
        Me.grpSociaGe = New System.Windows.Forms.GroupBox
        Me.optNo = New System.Windows.Forms.RadioButton
        Me.optSi = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtFax = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox
        Me.txtApellido1 = New System.Windows.Forms.TextBox
        Me.lblTelefono = New System.Windows.Forms.Label
        Me.txtApellido2 = New System.Windows.Forms.TextBox
        Me.lblCedula = New System.Windows.Forms.Label
        Me.lblApellido2 = New System.Windows.Forms.Label
        Me.lblApellido1 = New System.Windows.Forms.Label
        Me.lblNombre2 = New System.Windows.Forms.Label
        Me.lblNombre1 = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.txtSocia = New System.Windows.Forms.TextBox
        Me.txtNombre1 = New System.Windows.Forms.TextBox
        Me.txtNombre2 = New System.Windows.Forms.TextBox
        Me.errSocia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.optSFemenino = New System.Windows.Forms.RadioButton
        Me.optSMasculino = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grpSociaGe.SuspendLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.GroupBox2)
        Me.grpSociaGe.Controls.Add(Me.GroupBox1)
        Me.grpSociaGe.Controls.Add(Me.Label5)
        Me.grpSociaGe.Controls.Add(Me.Label4)
        Me.grpSociaGe.Controls.Add(Me.txtEmail)
        Me.grpSociaGe.Controls.Add(Me.Label3)
        Me.grpSociaGe.Controls.Add(Me.txtFax)
        Me.grpSociaGe.Controls.Add(Me.Label2)
        Me.grpSociaGe.Controls.Add(Me.txtCelular)
        Me.grpSociaGe.Controls.Add(Me.Label1)
        Me.grpSociaGe.Controls.Add(Me.cmdBuscar)
        Me.grpSociaGe.Controls.Add(Me.txtTelefono)
        Me.grpSociaGe.Controls.Add(Me.mtbNumCedula)
        Me.grpSociaGe.Controls.Add(Me.txtApellido1)
        Me.grpSociaGe.Controls.Add(Me.lblTelefono)
        Me.grpSociaGe.Controls.Add(Me.txtApellido2)
        Me.grpSociaGe.Controls.Add(Me.lblCedula)
        Me.grpSociaGe.Controls.Add(Me.lblApellido2)
        Me.grpSociaGe.Controls.Add(Me.lblApellido1)
        Me.grpSociaGe.Controls.Add(Me.lblNombre2)
        Me.grpSociaGe.Controls.Add(Me.lblNombre1)
        Me.grpSociaGe.Controls.Add(Me.lblCodigo)
        Me.grpSociaGe.Controls.Add(Me.txtSocia)
        Me.grpSociaGe.Controls.Add(Me.txtNombre1)
        Me.grpSociaGe.Controls.Add(Me.txtNombre2)
        Me.grpSociaGe.Location = New System.Drawing.Point(7, 2)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(644, 202)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Datos Generales: "
        '
        'optNo
        '
        Me.optNo.AutoSize = True
        Me.optNo.Location = New System.Drawing.Point(48, 8)
        Me.optNo.Name = "optNo"
        Me.optNo.Size = New System.Drawing.Size(39, 17)
        Me.optNo.TabIndex = 13
        Me.optNo.TabStop = True
        Me.optNo.Text = "No"
        Me.optNo.UseVisualStyleBackColor = True
        '
        'optSi
        '
        Me.optSi.AutoSize = True
        Me.optSi.Location = New System.Drawing.Point(6, 8)
        Me.optSi.Name = "optSi"
        Me.optSi.Size = New System.Drawing.Size(36, 17)
        Me.optSi.TabIndex = 12
        Me.optSi.TabStop = True
        Me.optSi.Text = "Sí"
        Me.optSi.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(16, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "¿Tiene Cédula?"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(408, 171)
        Me.txtEmail.MaxLength = 50
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(219, 20)
        Me.txtEmail.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(307, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "E-Mail:"
        '
        'txtFax
        '
        Me.txtFax.Location = New System.Drawing.Point(101, 172)
        Me.txtFax.MaxLength = 30
        Me.txtFax.Name = "txtFax"
        Me.txtFax.Size = New System.Drawing.Size(123, 20)
        Me.txtFax.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(16, 178)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Fax:"
        '
        'txtCelular
        '
        Me.txtCelular.Location = New System.Drawing.Point(408, 148)
        Me.txtCelular.MaxLength = 30
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.Size = New System.Drawing.Size(126, 20)
        Me.txtCelular.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(307, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Celular:"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(542, 47)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(64, 25)
        Me.cmdBuscar.TabIndex = 1
        Me.cmdBuscar.Text = "Padron"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(101, 149)
        Me.txtTelefono.MaxLength = 30
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(123, 20)
        Me.txtTelefono.TabIndex = 8
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(408, 49)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 0
        '
        'txtApellido1
        '
        Me.txtApellido1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido1.Location = New System.Drawing.Point(101, 98)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(193, 20)
        Me.txtApellido1.TabIndex = 4
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.ForeColor = System.Drawing.Color.Black
        Me.lblTelefono.Location = New System.Drawing.Point(16, 155)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(52, 13)
        Me.lblTelefono.TabIndex = 28
        Me.lblTelefono.Text = "Teléfono:"
        '
        'txtApellido2
        '
        Me.txtApellido2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido2.Location = New System.Drawing.Point(408, 96)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(219, 20)
        Me.txtApellido2.TabIndex = 5
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(307, 55)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 30
        Me.lblCedula.Text = "Número Cédula:"
        '
        'lblApellido2
        '
        Me.lblApellido2.AutoSize = True
        Me.lblApellido2.ForeColor = System.Drawing.Color.Black
        Me.lblApellido2.Location = New System.Drawing.Point(307, 103)
        Me.lblApellido2.Name = "lblApellido2"
        Me.lblApellido2.Size = New System.Drawing.Size(93, 13)
        Me.lblApellido2.TabIndex = 29
        Me.lblApellido2.Text = "Segundo Apellido:"
        '
        'lblApellido1
        '
        Me.lblApellido1.AutoSize = True
        Me.lblApellido1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblApellido1.Location = New System.Drawing.Point(16, 104)
        Me.lblApellido1.Name = "lblApellido1"
        Me.lblApellido1.Size = New System.Drawing.Size(79, 13)
        Me.lblApellido1.TabIndex = 28
        Me.lblApellido1.Text = "Primer Apellido:"
        '
        'lblNombre2
        '
        Me.lblNombre2.AutoSize = True
        Me.lblNombre2.ForeColor = System.Drawing.Color.Black
        Me.lblNombre2.Location = New System.Drawing.Point(307, 80)
        Me.lblNombre2.Name = "lblNombre2"
        Me.lblNombre2.Size = New System.Drawing.Size(93, 13)
        Me.lblNombre2.TabIndex = 27
        Me.lblNombre2.Text = "Segundo Nombre:"
        '
        'lblNombre1
        '
        Me.lblNombre1.AutoSize = True
        Me.lblNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre1.Location = New System.Drawing.Point(16, 80)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(79, 13)
        Me.lblNombre1.TabIndex = 26
        Me.lblNombre1.Text = "Primer Nombre:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(16, 33)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(37, 13)
        Me.lblCodigo.TabIndex = 25
        Me.lblCodigo.Text = "Socia:"
        '
        'txtSocia
        '
        Me.txtSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtSocia.Enabled = False
        Me.txtSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSocia.Location = New System.Drawing.Point(101, 26)
        Me.txtSocia.Name = "txtSocia"
        Me.txtSocia.ReadOnly = True
        Me.txtSocia.Size = New System.Drawing.Size(299, 20)
        Me.txtSocia.TabIndex = 2
        Me.txtSocia.TabStop = False
        Me.txtSocia.Tag = "LAYOUT:FLAT"
        '
        'txtNombre1
        '
        Me.txtNombre1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre1.Location = New System.Drawing.Point(101, 74)
        Me.txtNombre1.Name = "txtNombre1"
        Me.txtNombre1.Size = New System.Drawing.Size(193, 20)
        Me.txtNombre1.TabIndex = 2
        '
        'txtNombre2
        '
        Me.txtNombre2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre2.Location = New System.Drawing.Point(408, 73)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.Size = New System.Drawing.Size(219, 20)
        Me.txtNombre2.TabIndex = 3
        '
        'errSocia
        '
        Me.errSocia.ContainerControl = Me
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(578, 211)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(501, 211)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 12
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'optSFemenino
        '
        Me.optSFemenino.AutoSize = True
        Me.optSFemenino.Enabled = False
        Me.optSFemenino.Location = New System.Drawing.Point(80, 9)
        Me.optSFemenino.Name = "optSFemenino"
        Me.optSFemenino.Size = New System.Drawing.Size(71, 17)
        Me.optSFemenino.TabIndex = 7
        Me.optSFemenino.TabStop = True
        Me.optSFemenino.Text = "Femenino"
        Me.optSFemenino.UseVisualStyleBackColor = True
        '
        'optSMasculino
        '
        Me.optSMasculino.AutoSize = True
        Me.optSMasculino.Enabled = False
        Me.optSMasculino.Location = New System.Drawing.Point(5, 9)
        Me.optSMasculino.Name = "optSMasculino"
        Me.optSMasculino.Size = New System.Drawing.Size(73, 17)
        Me.optSMasculino.TabIndex = 6
        Me.optSMasculino.TabStop = True
        Me.optSMasculino.Text = "Masculino"
        Me.optSMasculino.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(16, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Sexo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optSi)
        Me.GroupBox1.Controls.Add(Me.optNo)
        Me.GroupBox1.Location = New System.Drawing.Point(102, 46)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(97, 27)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.optSMasculino)
        Me.GroupBox2.Controls.Add(Me.optSFemenino)
        Me.GroupBox2.Location = New System.Drawing.Point(101, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 28)
        Me.GroupBox2.TabIndex = 42
        Me.GroupBox2.TabStop = False
        '
        'frmSclEditSociaConyuge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 243)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpSociaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditSociaConyuge"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Registro de Datos de Cónyuge"
        Me.grpSociaGe.ResumeLayout(False)
        Me.grpSociaGe.PerformLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errSocia As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblNombre2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents lblApellido2 As System.Windows.Forms.Label
    Friend WithEvents lblApellido1 As System.Windows.Forms.Label
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtSocia As System.Windows.Forms.TextBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFax As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents optSi As System.Windows.Forms.RadioButton
    Friend WithEvents optNo As System.Windows.Forms.RadioButton
    Friend WithEvents optSFemenino As System.Windows.Forms.RadioButton
    Friend WithEvents optSMasculino As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
