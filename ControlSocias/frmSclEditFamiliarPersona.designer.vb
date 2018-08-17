<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditFamiliarPersona
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
        Me.components = New System.ComponentModel.Container()
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditFamiliarPersona))
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpSociaGe = New System.Windows.Forms.GroupBox()
        Me.cmdEditarCedula = New System.Windows.Forms.Button()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox()
        Me.txtApellido1 = New System.Windows.Forms.TextBox()
        Me.txtApellido2 = New System.Windows.Forms.TextBox()
        Me.cboEstadoCivil = New C1.Win.C1List.C1Combo()
        Me.lblEstadoCivil = New System.Windows.Forms.Label()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.lblApellido2 = New System.Windows.Forms.Label()
        Me.lblApellido1 = New System.Windows.Forms.Label()
        Me.lblNombre2 = New System.Windows.Forms.Label()
        Me.lblNombre1 = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtNombre1 = New System.Windows.Forms.TextBox()
        Me.txtNombre2 = New System.Windows.Forms.TextBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.errSocia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.grpSociaGe.SuspendLayout()
        CType(Me.cboEstadoCivil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.cmdEditarCedula)
        Me.grpSociaGe.Controls.Add(Me.cmdBuscar)
        Me.grpSociaGe.Controls.Add(Me.mtbNumCedula)
        Me.grpSociaGe.Controls.Add(Me.txtApellido1)
        Me.grpSociaGe.Controls.Add(Me.txtApellido2)
        Me.grpSociaGe.Controls.Add(Me.cboEstadoCivil)
        Me.grpSociaGe.Controls.Add(Me.lblEstadoCivil)
        Me.grpSociaGe.Controls.Add(Me.lblCedula)
        Me.grpSociaGe.Controls.Add(Me.lblApellido2)
        Me.grpSociaGe.Controls.Add(Me.lblApellido1)
        Me.grpSociaGe.Controls.Add(Me.lblNombre2)
        Me.grpSociaGe.Controls.Add(Me.lblNombre1)
        Me.grpSociaGe.Controls.Add(Me.lblCodigo)
        Me.grpSociaGe.Controls.Add(Me.txtCodigo)
        Me.grpSociaGe.Controls.Add(Me.txtNombre1)
        Me.grpSociaGe.Controls.Add(Me.txtNombre2)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 12)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(685, 137)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Datos Generales: "
        '
        'cmdEditarCedula
        '
        Me.cmdEditarCedula.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.cmdEditarCedula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEditarCedula.Location = New System.Drawing.Point(575, 18)
        Me.cmdEditarCedula.Name = "cmdEditarCedula"
        Me.cmdEditarCedula.Size = New System.Drawing.Size(93, 25)
        Me.cmdEditarCedula.TabIndex = 44
        Me.cmdEditarCedula.Text = "Editar Cédula"
        Me.cmdEditarCedula.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEditarCedula.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(271, 18)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(64, 25)
        Me.cmdBuscar.TabIndex = 1
        Me.cmdBuscar.Text = "Padron"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(142, 19)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 0
        '
        'txtApellido1
        '
        Me.txtApellido1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido1.Location = New System.Drawing.Point(142, 75)
        Me.txtApellido1.Name = "txtApellido1"
        Me.txtApellido1.Size = New System.Drawing.Size(193, 20)
        Me.txtApellido1.TabIndex = 5
        '
        'txtApellido2
        '
        Me.txtApellido2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido2.Location = New System.Drawing.Point(474, 75)
        Me.txtApellido2.Name = "txtApellido2"
        Me.txtApellido2.Size = New System.Drawing.Size(193, 20)
        Me.txtApellido2.TabIndex = 6
        '
        'cboEstadoCivil
        '
        Me.cboEstadoCivil.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstadoCivil.AutoCompletion = True
        Me.cboEstadoCivil.Caption = ""
        Me.cboEstadoCivil.CaptionHeight = 17
        Me.cboEstadoCivil.CaptionStyle = Style17
        Me.cboEstadoCivil.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEstadoCivil.ColumnCaptionHeight = 17
        Me.cboEstadoCivil.ColumnFooterHeight = 17
        Me.cboEstadoCivil.ContentHeight = 15
        Me.cboEstadoCivil.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboEstadoCivil.DisplayMember = "sDescripcion"
        Me.cboEstadoCivil.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboEstadoCivil.DropDownWidth = 194
        Me.cboEstadoCivil.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboEstadoCivil.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstadoCivil.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEstadoCivil.EditorHeight = 15
        Me.cboEstadoCivil.Enabled = False
        Me.cboEstadoCivil.EvenRowStyle = Style18
        Me.cboEstadoCivil.ExtendRightColumn = True
        Me.cboEstadoCivil.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEstadoCivil.FooterStyle = Style19
        Me.cboEstadoCivil.GapHeight = 2
        Me.cboEstadoCivil.HeadingStyle = Style20
        Me.cboEstadoCivil.HighLightRowStyle = Style21
        Me.cboEstadoCivil.Images.Add(CType(resources.GetObject("cboEstadoCivil.Images"), System.Drawing.Image))
        Me.cboEstadoCivil.ItemHeight = 15
        Me.cboEstadoCivil.LimitToList = True
        Me.cboEstadoCivil.Location = New System.Drawing.Point(142, 101)
        Me.cboEstadoCivil.MatchEntryTimeout = CType(2000, Long)
        Me.cboEstadoCivil.MaxDropDownItems = CType(5, Short)
        Me.cboEstadoCivil.MaxLength = 32767
        Me.cboEstadoCivil.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEstadoCivil.Name = "cboEstadoCivil"
        Me.cboEstadoCivil.OddRowStyle = Style22
        Me.cboEstadoCivil.PartialRightColumn = False
        Me.cboEstadoCivil.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEstadoCivil.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEstadoCivil.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEstadoCivil.SelectedStyle = Style23
        Me.cboEstadoCivil.Size = New System.Drawing.Size(193, 21)
        Me.cboEstadoCivil.Style = Style24
        Me.cboEstadoCivil.SuperBack = True
        Me.cboEstadoCivil.TabIndex = 7
        Me.cboEstadoCivil.ValueMember = "nStbValorCatalogoID"
        Me.cboEstadoCivil.PropBag = resources.GetString("cboEstadoCivil.PropBag")
        '
        'lblEstadoCivil
        '
        Me.lblEstadoCivil.AutoSize = True
        Me.lblEstadoCivil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoCivil.ForeColor = System.Drawing.Color.Black
        Me.lblEstadoCivil.Location = New System.Drawing.Point(16, 101)
        Me.lblEstadoCivil.Name = "lblEstadoCivil"
        Me.lblEstadoCivil.Size = New System.Drawing.Size(64, 13)
        Me.lblEstadoCivil.TabIndex = 23
        Me.lblEstadoCivil.Text = "Parentesco:"
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(16, 22)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 30
        Me.lblCedula.Text = "Número Cédula:"
        '
        'lblApellido2
        '
        Me.lblApellido2.AutoSize = True
        Me.lblApellido2.ForeColor = System.Drawing.Color.Black
        Me.lblApellido2.Location = New System.Drawing.Point(350, 75)
        Me.lblApellido2.Name = "lblApellido2"
        Me.lblApellido2.Size = New System.Drawing.Size(93, 13)
        Me.lblApellido2.TabIndex = 29
        Me.lblApellido2.Text = "Segundo Apellido:"
        '
        'lblApellido1
        '
        Me.lblApellido1.AutoSize = True
        Me.lblApellido1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblApellido1.Location = New System.Drawing.Point(16, 75)
        Me.lblApellido1.Name = "lblApellido1"
        Me.lblApellido1.Size = New System.Drawing.Size(79, 13)
        Me.lblApellido1.TabIndex = 28
        Me.lblApellido1.Text = "Primer Apellido:"
        '
        'lblNombre2
        '
        Me.lblNombre2.AutoSize = True
        Me.lblNombre2.ForeColor = System.Drawing.Color.Black
        Me.lblNombre2.Location = New System.Drawing.Point(350, 49)
        Me.lblNombre2.Name = "lblNombre2"
        Me.lblNombre2.Size = New System.Drawing.Size(93, 13)
        Me.lblNombre2.TabIndex = 27
        Me.lblNombre2.Text = "Segundo Nombre:"
        '
        'lblNombre1
        '
        Me.lblNombre1.AutoSize = True
        Me.lblNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre1.Location = New System.Drawing.Point(16, 49)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(79, 13)
        Me.lblNombre1.TabIndex = 26
        Me.lblNombre1.Text = "Primer Nombre:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(350, 22)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(73, 13)
        Me.lblCodigo.TabIndex = 25
        Me.lblCodigo.Text = "Código Socia:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(474, 20)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(97, 20)
        Me.txtCodigo.TabIndex = 2
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'txtNombre1
        '
        Me.txtNombre1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre1.Location = New System.Drawing.Point(142, 49)
        Me.txtNombre1.Name = "txtNombre1"
        Me.txtNombre1.Size = New System.Drawing.Size(193, 20)
        Me.txtNombre1.TabIndex = 3
        '
        'txtNombre2
        '
        Me.txtNombre2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre2.Location = New System.Drawing.Point(474, 49)
        Me.txtNombre2.Name = "txtNombre2"
        Me.txtNombre2.Size = New System.Drawing.Size(193, 20)
        Me.txtNombre2.TabIndex = 4
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(459, 155)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(624, 155)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errSocia
        '
        Me.errSocia.ContainerControl = Me
        '
        'frmSclEditFamiliarPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 190)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpSociaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditFamiliarPersona"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Registro de Datos de Familiar de Socia"
        Me.grpSociaGe.ResumeLayout(False)
        Me.grpSociaGe.PerformLayout()
        CType(Me.cboEstadoCivil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cboEstadoCivil As C1.Win.C1List.C1Combo
    Friend WithEvents lblEstadoCivil As System.Windows.Forms.Label
    Friend WithEvents errSocia As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblNombre2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents lblApellido2 As System.Windows.Forms.Label
    Friend WithEvents lblApellido1 As System.Windows.Forms.Label
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents txtApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents txtApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents cmdEditarCedula As System.Windows.Forms.Button
End Class
