<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnEditCatalogoContable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnEditCatalogoContable))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.grpDatosGrales = New System.Windows.Forms.GroupBox
        Me.lblFteFinanciamiento = New System.Windows.Forms.Label
        Me.cboFteFinanciamiento = New C1.Win.C1List.C1Combo
        Me.txtDigitosNivel = New System.Windows.Forms.TextBox
        Me.lblDigitosNivel = New System.Windows.Forms.Label
        Me.txtNivelCuenta = New System.Windows.Forms.TextBox
        Me.lblNivelCuenta = New System.Windows.Forms.Label
        Me.txtCodigoCuenta = New System.Windows.Forms.TextBox
        Me.txtCodCuentaPadre = New System.Windows.Forms.TextBox
        Me.txtNombreCuenta = New System.Windows.Forms.TextBox
        Me.lblCodigoCuenta = New System.Windows.Forms.Label
        Me.lblNombreCuenta = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.errCatContable = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpClaseCuenta = New System.Windows.Forms.GroupBox
        Me.radEgresos = New System.Windows.Forms.RadioButton
        Me.radIngresos = New System.Windows.Forms.RadioButton
        Me.radBalance = New System.Windows.Forms.RadioButton
        Me.radDebe = New System.Windows.Forms.RadioButton
        Me.grpTipoCuenta = New System.Windows.Forms.GroupBox
        Me.radHaber = New System.Windows.Forms.RadioButton
        Me.grpCuentaDetalle = New System.Windows.Forms.GroupBox
        Me.chkDetalle = New System.Windows.Forms.CheckBox
        Me.cboCtaBancaria = New C1.Win.C1List.C1Combo
        Me.lblCtaBancaria = New System.Windows.Forms.Label
        Me.lblDetalle = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.radOrden = New System.Windows.Forms.RadioButton
        Me.grpDatosGrales.SuspendLayout()
        CType(Me.cboFteFinanciamiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errCatContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpClaseCuenta.SuspendLayout()
        Me.grpTipoCuenta.SuspendLayout()
        Me.grpCuentaDetalle.SuspendLayout()
        CType(Me.cboCtaBancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(520, 319)
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
        Me.CmdAceptar.Location = New System.Drawing.Point(443, 319)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 4
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'grpDatosGrales
        '
        Me.grpDatosGrales.Controls.Add(Me.lblFteFinanciamiento)
        Me.grpDatosGrales.Controls.Add(Me.cboFteFinanciamiento)
        Me.grpDatosGrales.Controls.Add(Me.txtDigitosNivel)
        Me.grpDatosGrales.Controls.Add(Me.lblDigitosNivel)
        Me.grpDatosGrales.Controls.Add(Me.txtNivelCuenta)
        Me.grpDatosGrales.Controls.Add(Me.lblNivelCuenta)
        Me.grpDatosGrales.Controls.Add(Me.txtCodigoCuenta)
        Me.grpDatosGrales.Controls.Add(Me.txtCodCuentaPadre)
        Me.grpDatosGrales.Controls.Add(Me.txtNombreCuenta)
        Me.grpDatosGrales.Controls.Add(Me.lblCodigoCuenta)
        Me.grpDatosGrales.Controls.Add(Me.lblNombreCuenta)
        Me.grpDatosGrales.Controls.Add(Me.Label1)
        Me.grpDatosGrales.Location = New System.Drawing.Point(12, 12)
        Me.grpDatosGrales.Name = "grpDatosGrales"
        Me.grpDatosGrales.Size = New System.Drawing.Size(581, 150)
        Me.grpDatosGrales.TabIndex = 0
        Me.grpDatosGrales.TabStop = False
        Me.grpDatosGrales.Text = "Datos Generales"
        '
        'lblFteFinanciamiento
        '
        Me.lblFteFinanciamiento.AutoSize = True
        Me.lblFteFinanciamiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFteFinanciamiento.Location = New System.Drawing.Point(19, 86)
        Me.lblFteFinanciamiento.Name = "lblFteFinanciamiento"
        Me.lblFteFinanciamiento.Size = New System.Drawing.Size(99, 13)
        Me.lblFteFinanciamiento.TabIndex = 105
        Me.lblFteFinanciamiento.Text = "Fte.Financiamiento:"
        '
        'cboFteFinanciamiento
        '
        Me.cboFteFinanciamiento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFteFinanciamiento.AutoCompletion = True
        Me.cboFteFinanciamiento.Caption = ""
        Me.cboFteFinanciamiento.CaptionHeight = 17
        Me.cboFteFinanciamiento.CaptionStyle = Style1
        Me.cboFteFinanciamiento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFteFinanciamiento.ColumnCaptionHeight = 17
        Me.cboFteFinanciamiento.ColumnFooterHeight = 17
        Me.cboFteFinanciamiento.ContentHeight = 15
        Me.cboFteFinanciamiento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFteFinanciamiento.DisplayMember = "sDescripcion"
        Me.cboFteFinanciamiento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFteFinanciamiento.DropDownWidth = 273
        Me.cboFteFinanciamiento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFteFinanciamiento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFteFinanciamiento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFteFinanciamiento.EditorHeight = 15
        Me.cboFteFinanciamiento.EvenRowStyle = Style2
        Me.cboFteFinanciamiento.ExtendRightColumn = True
        Me.cboFteFinanciamiento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFteFinanciamiento.FooterStyle = Style3
        Me.cboFteFinanciamiento.GapHeight = 2
        Me.cboFteFinanciamiento.HeadingStyle = Style4
        Me.cboFteFinanciamiento.HighLightRowStyle = Style5
        Me.cboFteFinanciamiento.Images.Add(CType(resources.GetObject("cboFteFinanciamiento.Images"), System.Drawing.Image))
        Me.cboFteFinanciamiento.ItemHeight = 15
        Me.cboFteFinanciamiento.LimitToList = True
        Me.cboFteFinanciamiento.Location = New System.Drawing.Point(124, 78)
        Me.cboFteFinanciamiento.MatchEntryTimeout = CType(2000, Long)
        Me.cboFteFinanciamiento.MaxDropDownItems = CType(5, Short)
        Me.cboFteFinanciamiento.MaxLength = 32767
        Me.cboFteFinanciamiento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFteFinanciamiento.Name = "cboFteFinanciamiento"
        Me.cboFteFinanciamiento.OddRowStyle = Style6
        Me.cboFteFinanciamiento.PartialRightColumn = False
        Me.cboFteFinanciamiento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFteFinanciamiento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFteFinanciamiento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFteFinanciamiento.SelectedStyle = Style7
        Me.cboFteFinanciamiento.Size = New System.Drawing.Size(272, 21)
        Me.cboFteFinanciamiento.Style = Style8
        Me.cboFteFinanciamiento.SuperBack = True
        Me.cboFteFinanciamiento.TabIndex = 2
        Me.cboFteFinanciamiento.ValueMember = "StbValorCatalogoID"
        Me.cboFteFinanciamiento.PropBag = resources.GetString("cboFteFinanciamiento.PropBag")
        '
        'txtDigitosNivel
        '
        Me.txtDigitosNivel.BackColor = System.Drawing.SystemColors.Info
        Me.txtDigitosNivel.Enabled = False
        Me.txtDigitosNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDigitosNivel.Location = New System.Drawing.Point(305, 110)
        Me.txtDigitosNivel.Name = "txtDigitosNivel"
        Me.txtDigitosNivel.ReadOnly = True
        Me.txtDigitosNivel.ShortcutsEnabled = False
        Me.txtDigitosNivel.Size = New System.Drawing.Size(44, 20)
        Me.txtDigitosNivel.TabIndex = 102
        Me.txtDigitosNivel.Tag = "LAYOUT:FLAT"
        '
        'lblDigitosNivel
        '
        Me.lblDigitosNivel.AutoSize = True
        Me.lblDigitosNivel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDigitosNivel.Location = New System.Drawing.Point(211, 117)
        Me.lblDigitosNivel.Name = "lblDigitosNivel"
        Me.lblDigitosNivel.Size = New System.Drawing.Size(71, 13)
        Me.lblDigitosNivel.TabIndex = 101
        Me.lblDigitosNivel.Text = "Dígitos Nivel:"
        '
        'txtNivelCuenta
        '
        Me.txtNivelCuenta.BackColor = System.Drawing.SystemColors.Info
        Me.txtNivelCuenta.Enabled = False
        Me.txtNivelCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNivelCuenta.Location = New System.Drawing.Point(124, 110)
        Me.txtNivelCuenta.Name = "txtNivelCuenta"
        Me.txtNivelCuenta.ReadOnly = True
        Me.txtNivelCuenta.ShortcutsEnabled = False
        Me.txtNivelCuenta.Size = New System.Drawing.Size(44, 20)
        Me.txtNivelCuenta.TabIndex = 102
        Me.txtNivelCuenta.Tag = "LAYOUT:FLAT"
        '
        'lblNivelCuenta
        '
        Me.lblNivelCuenta.AutoSize = True
        Me.lblNivelCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNivelCuenta.Location = New System.Drawing.Point(19, 117)
        Me.lblNivelCuenta.Name = "lblNivelCuenta"
        Me.lblNivelCuenta.Size = New System.Drawing.Size(71, 13)
        Me.lblNivelCuenta.TabIndex = 101
        Me.lblNivelCuenta.Text = "Nivel Cuenta:"
        '
        'txtCodigoCuenta
        '
        Me.txtCodigoCuenta.Location = New System.Drawing.Point(305, 26)
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCodigoCuenta.Size = New System.Drawing.Size(165, 20)
        Me.txtCodigoCuenta.TabIndex = 0
        Me.txtCodigoCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCodCuentaPadre
        '
        Me.txtCodCuentaPadre.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodCuentaPadre.Enabled = False
        Me.txtCodCuentaPadre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodCuentaPadre.Location = New System.Drawing.Point(124, 26)
        Me.txtCodCuentaPadre.Name = "txtCodCuentaPadre"
        Me.txtCodCuentaPadre.ReadOnly = True
        Me.txtCodCuentaPadre.ShortcutsEnabled = False
        Me.txtCodCuentaPadre.Size = New System.Drawing.Size(165, 20)
        Me.txtCodCuentaPadre.TabIndex = 100
        Me.txtCodCuentaPadre.Tag = "LAYOUT:FLAT"
        Me.txtCodCuentaPadre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNombreCuenta
        '
        Me.txtNombreCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombreCuenta.Location = New System.Drawing.Point(124, 52)
        Me.txtNombreCuenta.Multiline = True
        Me.txtNombreCuenta.Name = "txtNombreCuenta"
        Me.txtNombreCuenta.Size = New System.Drawing.Size(443, 20)
        Me.txtNombreCuenta.TabIndex = 1
        '
        'lblCodigoCuenta
        '
        Me.lblCodigoCuenta.AutoSize = True
        Me.lblCodigoCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoCuenta.Location = New System.Drawing.Point(19, 33)
        Me.lblCodigoCuenta.Name = "lblCodigoCuenta"
        Me.lblCodigoCuenta.Size = New System.Drawing.Size(80, 13)
        Me.lblCodigoCuenta.TabIndex = 1
        Me.lblCodigoCuenta.Text = "Código Cuenta:"
        '
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.AutoSize = True
        Me.lblNombreCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreCuenta.Location = New System.Drawing.Point(19, 59)
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Size = New System.Drawing.Size(84, 13)
        Me.lblNombreCuenta.TabIndex = 3
        Me.lblNombreCuenta.Text = "Nombre Cuenta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(290, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 20)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "-"
        '
        'errCatContable
        '
        Me.errCatContable.ContainerControl = Me
        '
        'grpClaseCuenta
        '
        Me.grpClaseCuenta.Controls.Add(Me.radOrden)
        Me.grpClaseCuenta.Controls.Add(Me.radEgresos)
        Me.grpClaseCuenta.Controls.Add(Me.radIngresos)
        Me.grpClaseCuenta.Controls.Add(Me.radBalance)
        Me.grpClaseCuenta.Location = New System.Drawing.Point(209, 168)
        Me.grpClaseCuenta.Name = "grpClaseCuenta"
        Me.grpClaseCuenta.Size = New System.Drawing.Size(384, 68)
        Me.grpClaseCuenta.TabIndex = 2
        Me.grpClaseCuenta.TabStop = False
        Me.grpClaseCuenta.Text = "Clase de Cuenta"
        '
        'radEgresos
        '
        Me.radEgresos.AutoSize = True
        Me.radEgresos.Checked = True
        Me.radEgresos.Location = New System.Drawing.Point(215, 28)
        Me.radEgresos.Name = "radEgresos"
        Me.radEgresos.Size = New System.Drawing.Size(79, 17)
        Me.radEgresos.TabIndex = 2
        Me.radEgresos.Text = "Egresos (E)"
        Me.radEgresos.UseVisualStyleBackColor = True
        '
        'radIngresos
        '
        Me.radIngresos.AutoSize = True
        Me.radIngresos.Location = New System.Drawing.Point(122, 28)
        Me.radIngresos.Name = "radIngresos"
        Me.radIngresos.Size = New System.Drawing.Size(77, 17)
        Me.radIngresos.TabIndex = 1
        Me.radIngresos.Text = "Ingresos (I)"
        Me.radIngresos.UseVisualStyleBackColor = True
        '
        'radBalance
        '
        Me.radBalance.AutoSize = True
        Me.radBalance.Location = New System.Drawing.Point(17, 28)
        Me.radBalance.Name = "radBalance"
        Me.radBalance.Size = New System.Drawing.Size(80, 17)
        Me.radBalance.TabIndex = 0
        Me.radBalance.Text = "Balance (B)"
        Me.radBalance.UseVisualStyleBackColor = True
        '
        'radDebe
        '
        Me.radDebe.AutoSize = True
        Me.radDebe.Checked = True
        Me.radDebe.Location = New System.Drawing.Point(20, 28)
        Me.radDebe.Name = "radDebe"
        Me.radDebe.Size = New System.Drawing.Size(68, 17)
        Me.radDebe.TabIndex = 0
        Me.radDebe.TabStop = True
        Me.radDebe.Text = "Debe (D)"
        Me.radDebe.UseVisualStyleBackColor = True
        '
        'grpTipoCuenta
        '
        Me.grpTipoCuenta.Controls.Add(Me.radHaber)
        Me.grpTipoCuenta.Controls.Add(Me.radDebe)
        Me.grpTipoCuenta.Location = New System.Drawing.Point(12, 168)
        Me.grpTipoCuenta.Name = "grpTipoCuenta"
        Me.grpTipoCuenta.Size = New System.Drawing.Size(191, 68)
        Me.grpTipoCuenta.TabIndex = 1
        Me.grpTipoCuenta.TabStop = False
        Me.grpTipoCuenta.Text = "Tipo de Cuenta"
        '
        'radHaber
        '
        Me.radHaber.AutoSize = True
        Me.radHaber.Location = New System.Drawing.Point(103, 28)
        Me.radHaber.Name = "radHaber"
        Me.radHaber.Size = New System.Drawing.Size(71, 17)
        Me.radHaber.TabIndex = 1
        Me.radHaber.Text = "Haber (H)"
        Me.radHaber.UseVisualStyleBackColor = True
        '
        'grpCuentaDetalle
        '
        Me.grpCuentaDetalle.Controls.Add(Me.chkDetalle)
        Me.grpCuentaDetalle.Controls.Add(Me.cboCtaBancaria)
        Me.grpCuentaDetalle.Controls.Add(Me.lblCtaBancaria)
        Me.grpCuentaDetalle.Controls.Add(Me.lblDetalle)
        Me.grpCuentaDetalle.Location = New System.Drawing.Point(12, 242)
        Me.grpCuentaDetalle.Name = "grpCuentaDetalle"
        Me.grpCuentaDetalle.Size = New System.Drawing.Size(581, 71)
        Me.grpCuentaDetalle.TabIndex = 3
        Me.grpCuentaDetalle.TabStop = False
        Me.grpCuentaDetalle.Text = "Datos Cuenta Detalle"
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        Me.chkDetalle.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDetalle.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkDetalle.Location = New System.Drawing.Point(71, 31)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(17, 17)
        Me.chkDetalle.TabIndex = 0
        Me.chkDetalle.Tag = ""
        Me.chkDetalle.Text = "  "
        Me.chkDetalle.UseVisualStyleBackColor = True
        '
        'cboCtaBancaria
        '
        Me.cboCtaBancaria.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCtaBancaria.AutoCompletion = True
        Me.cboCtaBancaria.Caption = ""
        Me.cboCtaBancaria.CaptionHeight = 17
        Me.cboCtaBancaria.CaptionStyle = Style9
        Me.cboCtaBancaria.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCtaBancaria.ColumnCaptionHeight = 17
        Me.cboCtaBancaria.ColumnFooterHeight = 17
        Me.cboCtaBancaria.ContentHeight = 15
        Me.cboCtaBancaria.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCtaBancaria.DisplayMember = "sDescripcion"
        Me.cboCtaBancaria.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCtaBancaria.DropDownWidth = 350
        Me.cboCtaBancaria.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCtaBancaria.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCtaBancaria.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCtaBancaria.EditorHeight = 15
        Me.cboCtaBancaria.EvenRowStyle = Style10
        Me.cboCtaBancaria.ExtendRightColumn = True
        Me.cboCtaBancaria.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCtaBancaria.FooterStyle = Style11
        Me.cboCtaBancaria.GapHeight = 2
        Me.cboCtaBancaria.HeadingStyle = Style12
        Me.cboCtaBancaria.HighLightRowStyle = Style13
        Me.cboCtaBancaria.Images.Add(CType(resources.GetObject("cboCtaBancaria.Images"), System.Drawing.Image))
        Me.cboCtaBancaria.ItemHeight = 15
        Me.cboCtaBancaria.LimitToList = True
        Me.cboCtaBancaria.Location = New System.Drawing.Point(239, 25)
        Me.cboCtaBancaria.MatchEntryTimeout = CType(2000, Long)
        Me.cboCtaBancaria.MaxDropDownItems = CType(5, Short)
        Me.cboCtaBancaria.MaxLength = 32767
        Me.cboCtaBancaria.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCtaBancaria.Name = "cboCtaBancaria"
        Me.cboCtaBancaria.OddRowStyle = Style14
        Me.cboCtaBancaria.PartialRightColumn = False
        Me.cboCtaBancaria.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCtaBancaria.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCtaBancaria.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCtaBancaria.SelectedStyle = Style15
        Me.cboCtaBancaria.Size = New System.Drawing.Size(328, 21)
        Me.cboCtaBancaria.Style = Style16
        Me.cboCtaBancaria.SuperBack = True
        Me.cboCtaBancaria.TabIndex = 1
        Me.cboCtaBancaria.ValueMember = "StbValorCatalogoID"
        Me.cboCtaBancaria.PropBag = resources.GetString("cboCtaBancaria.PropBag")
        '
        'lblCtaBancaria
        '
        Me.lblCtaBancaria.AutoSize = True
        Me.lblCtaBancaria.ForeColor = System.Drawing.Color.Black
        Me.lblCtaBancaria.Location = New System.Drawing.Point(144, 32)
        Me.lblCtaBancaria.Name = "lblCtaBancaria"
        Me.lblCtaBancaria.Size = New System.Drawing.Size(89, 13)
        Me.lblCtaBancaria.TabIndex = 2
        Me.lblCtaBancaria.Text = "Cuenta Bancaria:"
        '
        'lblDetalle
        '
        Me.lblDetalle.AutoSize = True
        Me.lblDetalle.Location = New System.Drawing.Point(19, 33)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(43, 13)
        Me.lblDetalle.TabIndex = 1
        Me.lblDetalle.Text = "Detalle:"
        '
        'radOrden
        '
        Me.radOrden.AutoSize = True
        Me.radOrden.Location = New System.Drawing.Point(300, 28)
        Me.radOrden.Name = "radOrden"
        Me.radOrden.Size = New System.Drawing.Size(71, 17)
        Me.radOrden.TabIndex = 3
        Me.radOrden.Text = "Orden (O)"
        Me.radOrden.UseVisualStyleBackColor = True
        '
        'frmScnEditCatalogoContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(676, 356)
        Me.Controls.Add(Me.grpCuentaDetalle)
        Me.Controls.Add(Me.grpClaseCuenta)
        Me.Controls.Add(Me.grpTipoCuenta)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpDatosGrales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Catálogo Contable")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnEditCatalogoContable"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo Contable"
        Me.grpDatosGrales.ResumeLayout(False)
        Me.grpDatosGrales.PerformLayout()
        CType(Me.cboFteFinanciamiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errCatContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpClaseCuenta.ResumeLayout(False)
        Me.grpClaseCuenta.PerformLayout()
        Me.grpTipoCuenta.ResumeLayout(False)
        Me.grpTipoCuenta.PerformLayout()
        Me.grpCuentaDetalle.ResumeLayout(False)
        Me.grpCuentaDetalle.PerformLayout()
        CType(Me.cboCtaBancaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpDatosGrales As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoCuenta As System.Windows.Forms.Label
    Friend WithEvents lblNombreCuenta As System.Windows.Forms.Label
    Friend WithEvents errCatContable As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtCodCuentaPadre As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDigitosNivel As System.Windows.Forms.TextBox
    Friend WithEvents lblDigitosNivel As System.Windows.Forms.Label
    Friend WithEvents txtNivelCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblNivelCuenta As System.Windows.Forms.Label
    Friend WithEvents grpClaseCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents radIngresos As System.Windows.Forms.RadioButton
    Friend WithEvents radBalance As System.Windows.Forms.RadioButton
    Friend WithEvents grpTipoCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents radHaber As System.Windows.Forms.RadioButton
    Friend WithEvents radDebe As System.Windows.Forms.RadioButton
    Friend WithEvents grpCuentaDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents lblDetalle As System.Windows.Forms.Label
    Friend WithEvents radEgresos As System.Windows.Forms.RadioButton
    Friend WithEvents lblFteFinanciamiento As System.Windows.Forms.Label
    Friend WithEvents cboFteFinanciamiento As C1.Win.C1List.C1Combo
    Friend WithEvents cboCtaBancaria As C1.Win.C1List.C1Combo
    Friend WithEvents lblCtaBancaria As System.Windows.Forms.Label
    Friend WithEvents chkDetalle As System.Windows.Forms.CheckBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents radOrden As System.Windows.Forms.RadioButton
End Class
