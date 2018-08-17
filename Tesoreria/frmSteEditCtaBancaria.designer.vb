<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditCtaBancaria
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
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style41 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style42 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style43 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style44 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style45 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style46 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style47 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style48 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditCtaBancaria))
        Me.errCtaBancaria = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDatosGrales = New System.Windows.Forms.GroupBox
        Me.txtNumFinalCheque = New System.Windows.Forms.TextBox
        Me.lblNumFinalCheque = New System.Windows.Forms.Label
        Me.txtNumInicialCheque = New System.Windows.Forms.TextBox
        Me.lblNumeroInicialCheque = New System.Windows.Forms.Label
        Me.chkCerrada = New System.Windows.Forms.CheckBox
        Me.cboMoneda = New C1.Win.C1List.C1Combo
        Me.cboTipoCuenta = New C1.Win.C1List.C1Combo
        Me.cdeFechaCierre = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaApertura = New C1.Win.C1Input.C1DateEdit
        Me.cboInstitucion = New C1.Win.C1List.C1Combo
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.lblMoneda = New System.Windows.Forms.Label
        Me.lblTipoCuenta = New System.Windows.Forms.Label
        Me.lblFechaCierre = New System.Windows.Forms.Label
        Me.lblBanco = New System.Windows.Forms.Label
        Me.lblFechaApertura = New System.Windows.Forms.Label
        Me.lblNombre = New System.Windows.Forms.Label
        Me.lblNumero = New System.Windows.Forms.Label
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errCtaBancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosGrales.SuspendLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errCtaBancaria
        '
        Me.errCtaBancaria.ContainerControl = Me
        '
        'grpDatosGrales
        '
        Me.grpDatosGrales.Controls.Add(Me.txtNumFinalCheque)
        Me.grpDatosGrales.Controls.Add(Me.lblNumFinalCheque)
        Me.grpDatosGrales.Controls.Add(Me.txtNumInicialCheque)
        Me.grpDatosGrales.Controls.Add(Me.lblNumeroInicialCheque)
        Me.grpDatosGrales.Controls.Add(Me.chkCerrada)
        Me.grpDatosGrales.Controls.Add(Me.cboMoneda)
        Me.grpDatosGrales.Controls.Add(Me.cboTipoCuenta)
        Me.grpDatosGrales.Controls.Add(Me.cdeFechaCierre)
        Me.grpDatosGrales.Controls.Add(Me.cdeFechaApertura)
        Me.grpDatosGrales.Controls.Add(Me.cboInstitucion)
        Me.grpDatosGrales.Controls.Add(Me.txtNombre)
        Me.grpDatosGrales.Controls.Add(Me.txtNumero)
        Me.grpDatosGrales.Controls.Add(Me.lblEstado)
        Me.grpDatosGrales.Controls.Add(Me.lblMoneda)
        Me.grpDatosGrales.Controls.Add(Me.lblTipoCuenta)
        Me.grpDatosGrales.Controls.Add(Me.lblFechaCierre)
        Me.grpDatosGrales.Controls.Add(Me.lblBanco)
        Me.grpDatosGrales.Controls.Add(Me.lblFechaApertura)
        Me.grpDatosGrales.Controls.Add(Me.lblNombre)
        Me.grpDatosGrales.Controls.Add(Me.lblNumero)
        Me.grpDatosGrales.Location = New System.Drawing.Point(13, 12)
        Me.grpDatosGrales.Name = "grpDatosGrales"
        Me.grpDatosGrales.Size = New System.Drawing.Size(518, 217)
        Me.grpDatosGrales.TabIndex = 0
        Me.grpDatosGrales.TabStop = False
        Me.grpDatosGrales.Text = "Datos de Cuenta Bancaria"
        '
        'txtNumFinalCheque
        '
        Me.txtNumFinalCheque.Location = New System.Drawing.Point(385, 157)
        Me.txtNumFinalCheque.Name = "txtNumFinalCheque"
        Me.txtNumFinalCheque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNumFinalCheque.Size = New System.Drawing.Size(115, 20)
        Me.txtNumFinalCheque.TabIndex = 8
        Me.txtNumFinalCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumFinalCheque
        '
        Me.lblNumFinalCheque.AutoSize = True
        Me.lblNumFinalCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumFinalCheque.Location = New System.Drawing.Point(280, 157)
        Me.lblNumFinalCheque.Name = "lblNumFinalCheque"
        Me.lblNumFinalCheque.Size = New System.Drawing.Size(101, 13)
        Me.lblNumFinalCheque.TabIndex = 116
        Me.lblNumFinalCheque.Text = "No. Final Chequera:"
        '
        'txtNumInicialCheque
        '
        Me.txtNumInicialCheque.Location = New System.Drawing.Point(126, 154)
        Me.txtNumInicialCheque.Name = "txtNumInicialCheque"
        Me.txtNumInicialCheque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNumInicialCheque.Size = New System.Drawing.Size(148, 20)
        Me.txtNumInicialCheque.TabIndex = 7
        Me.txtNumInicialCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumeroInicialCheque
        '
        Me.lblNumeroInicialCheque.AutoSize = True
        Me.lblNumeroInicialCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumeroInicialCheque.Location = New System.Drawing.Point(18, 161)
        Me.lblNumeroInicialCheque.Name = "lblNumeroInicialCheque"
        Me.lblNumeroInicialCheque.Size = New System.Drawing.Size(106, 13)
        Me.lblNumeroInicialCheque.TabIndex = 114
        Me.lblNumeroInicialCheque.Text = "No. Inicial Chequera:"
        '
        'chkCerrada
        '
        Me.chkCerrada.AutoSize = True
        Me.chkCerrada.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkCerrada.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkCerrada.Location = New System.Drawing.Point(126, 184)
        Me.chkCerrada.Name = "chkCerrada"
        Me.chkCerrada.Size = New System.Drawing.Size(17, 17)
        Me.chkCerrada.TabIndex = 9
        Me.chkCerrada.Tag = ""
        Me.chkCerrada.Text = "  "
        Me.chkCerrada.UseVisualStyleBackColor = True
        '
        'cboMoneda
        '
        Me.cboMoneda.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMoneda.AutoCompletion = True
        Me.cboMoneda.Caption = ""
        Me.cboMoneda.CaptionHeight = 17
        Me.cboMoneda.CaptionStyle = Style25
        Me.cboMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMoneda.ColumnCaptionHeight = 17
        Me.cboMoneda.ColumnFooterHeight = 17
        Me.cboMoneda.ContentHeight = 15
        Me.cboMoneda.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMoneda.DisplayMember = "sDescripcion"
        Me.cboMoneda.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMoneda.DropDownWidth = 200
        Me.cboMoneda.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMoneda.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMoneda.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMoneda.EditorHeight = 15
        Me.cboMoneda.EvenRowStyle = Style26
        Me.cboMoneda.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMoneda.FooterStyle = Style27
        Me.cboMoneda.GapHeight = 2
        Me.cboMoneda.HeadingStyle = Style28
        Me.cboMoneda.HighLightRowStyle = Style29
        Me.cboMoneda.Images.Add(CType(resources.GetObject("cboMoneda.Images"), System.Drawing.Image))
        Me.cboMoneda.ItemHeight = 15
        Me.cboMoneda.LimitToList = True
        Me.cboMoneda.Location = New System.Drawing.Point(126, 126)
        Me.cboMoneda.MatchEntryTimeout = CType(2000, Long)
        Me.cboMoneda.MaxDropDownItems = CType(5, Short)
        Me.cboMoneda.MaxLength = 32767
        Me.cboMoneda.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMoneda.Name = "cboMoneda"
        Me.cboMoneda.OddRowStyle = Style30
        Me.cboMoneda.PartialRightColumn = False
        Me.cboMoneda.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMoneda.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMoneda.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMoneda.SelectedStyle = Style31
        Me.cboMoneda.Size = New System.Drawing.Size(148, 21)
        Me.cboMoneda.Style = Style32
        Me.cboMoneda.SuperBack = True
        Me.cboMoneda.TabIndex = 5
        Me.cboMoneda.ValueMember = "StbMonedaID"
        Me.cboMoneda.PropBag = resources.GetString("cboMoneda.PropBag")
        '
        'cboTipoCuenta
        '
        Me.cboTipoCuenta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoCuenta.AutoCompletion = True
        Me.cboTipoCuenta.Caption = ""
        Me.cboTipoCuenta.CaptionHeight = 17
        Me.cboTipoCuenta.CaptionStyle = Style33
        Me.cboTipoCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTipoCuenta.ColumnCaptionHeight = 17
        Me.cboTipoCuenta.ColumnFooterHeight = 17
        Me.cboTipoCuenta.ContentHeight = 15
        Me.cboTipoCuenta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTipoCuenta.DisplayMember = "sDescripcion"
        Me.cboTipoCuenta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTipoCuenta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoCuenta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoCuenta.EditorHeight = 15
        Me.cboTipoCuenta.EvenRowStyle = Style34
        Me.cboTipoCuenta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoCuenta.FooterStyle = Style35
        Me.cboTipoCuenta.GapHeight = 2
        Me.cboTipoCuenta.HeadingStyle = Style36
        Me.cboTipoCuenta.HighLightRowStyle = Style37
        Me.cboTipoCuenta.Images.Add(CType(resources.GetObject("cboTipoCuenta.Images"), System.Drawing.Image))
        Me.cboTipoCuenta.ItemHeight = 15
        Me.cboTipoCuenta.LimitToList = True
        Me.cboTipoCuenta.Location = New System.Drawing.Point(126, 99)
        Me.cboTipoCuenta.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoCuenta.MaxDropDownItems = CType(5, Short)
        Me.cboTipoCuenta.MaxLength = 32767
        Me.cboTipoCuenta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoCuenta.Name = "cboTipoCuenta"
        Me.cboTipoCuenta.OddRowStyle = Style38
        Me.cboTipoCuenta.PartialRightColumn = False
        Me.cboTipoCuenta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoCuenta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoCuenta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoCuenta.SelectedStyle = Style39
        Me.cboTipoCuenta.Size = New System.Drawing.Size(148, 21)
        Me.cboTipoCuenta.Style = Style40
        Me.cboTipoCuenta.SuperBack = True
        Me.cboTipoCuenta.TabIndex = 3
        Me.cboTipoCuenta.ValueMember = "StbValorCatalogoID"
        Me.cboTipoCuenta.PropBag = resources.GetString("cboTipoCuenta.PropBag")
        '
        'cdeFechaCierre
        '
        Me.cdeFechaCierre.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCierre.Location = New System.Drawing.Point(385, 126)
        Me.cdeFechaCierre.Name = "cdeFechaCierre"
        Me.cdeFechaCierre.Size = New System.Drawing.Size(115, 20)
        Me.cdeFechaCierre.TabIndex = 6
        Me.cdeFechaCierre.Tag = Nothing
        Me.cdeFechaCierre.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaApertura
        '
        Me.cdeFechaApertura.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaApertura.Location = New System.Drawing.Point(385, 98)
        Me.cdeFechaApertura.Name = "cdeFechaApertura"
        Me.cdeFechaApertura.Size = New System.Drawing.Size(115, 20)
        Me.cdeFechaApertura.TabIndex = 4
        Me.cdeFechaApertura.Tag = Nothing
        Me.cdeFechaApertura.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cboInstitucion
        '
        Me.cboInstitucion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboInstitucion.AutoCompletion = True
        Me.cboInstitucion.Caption = ""
        Me.cboInstitucion.CaptionHeight = 17
        Me.cboInstitucion.CaptionStyle = Style41
        Me.cboInstitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboInstitucion.ColumnCaptionHeight = 17
        Me.cboInstitucion.ColumnFooterHeight = 17
        Me.cboInstitucion.ContentHeight = 15
        Me.cboInstitucion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboInstitucion.DisplayMember = "sRazonSocial"
        Me.cboInstitucion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboInstitucion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInstitucion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboInstitucion.EditorHeight = 15
        Me.cboInstitucion.EvenRowStyle = Style42
        Me.cboInstitucion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboInstitucion.FooterStyle = Style43
        Me.cboInstitucion.GapHeight = 2
        Me.cboInstitucion.HeadingStyle = Style44
        Me.cboInstitucion.HighLightRowStyle = Style45
        Me.cboInstitucion.Images.Add(CType(resources.GetObject("cboInstitucion.Images"), System.Drawing.Image))
        Me.cboInstitucion.ItemHeight = 15
        Me.cboInstitucion.LimitToList = True
        Me.cboInstitucion.Location = New System.Drawing.Point(126, 70)
        Me.cboInstitucion.MatchEntryTimeout = CType(2000, Long)
        Me.cboInstitucion.MaxDropDownItems = CType(5, Short)
        Me.cboInstitucion.MaxLength = 32767
        Me.cboInstitucion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboInstitucion.Name = "cboInstitucion"
        Me.cboInstitucion.OddRowStyle = Style46
        Me.cboInstitucion.PartialRightColumn = False
        Me.cboInstitucion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboInstitucion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboInstitucion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboInstitucion.SelectedStyle = Style47
        Me.cboInstitucion.Size = New System.Drawing.Size(220, 21)
        Me.cboInstitucion.Style = Style48
        Me.cboInstitucion.SuperBack = True
        Me.cboInstitucion.TabIndex = 2
        Me.cboInstitucion.ValueMember = "SteBancoID"
        Me.cboInstitucion.PropBag = resources.GetString("cboInstitucion.PropBag")
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(126, 44)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(374, 20)
        Me.txtNombre.TabIndex = 1
        '
        'txtNumero
        '
        Me.txtNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumero.Location = New System.Drawing.Point(126, 19)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(220, 20)
        Me.txtNumero.TabIndex = 0
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(18, 188)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(47, 13)
        Me.lblEstado.TabIndex = 11
        Me.lblEstado.Text = "Cerrada:"
        '
        'lblMoneda
        '
        Me.lblMoneda.AutoSize = True
        Me.lblMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMoneda.Location = New System.Drawing.Point(18, 134)
        Me.lblMoneda.Name = "lblMoneda"
        Me.lblMoneda.Size = New System.Drawing.Size(49, 13)
        Me.lblMoneda.TabIndex = 10
        Me.lblMoneda.Text = "Moneda:"
        '
        'lblTipoCuenta
        '
        Me.lblTipoCuenta.AutoSize = True
        Me.lblTipoCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoCuenta.Location = New System.Drawing.Point(18, 107)
        Me.lblTipoCuenta.Name = "lblTipoCuenta"
        Me.lblTipoCuenta.Size = New System.Drawing.Size(83, 13)
        Me.lblTipoCuenta.TabIndex = 6
        Me.lblTipoCuenta.Text = "Tipo de Cuenta:"
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.ForeColor = System.Drawing.Color.Black
        Me.lblFechaCierre.Location = New System.Drawing.Point(280, 129)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(70, 13)
        Me.lblFechaCierre.TabIndex = 5
        Me.lblFechaCierre.Text = "Fecha Cierre:"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblBanco.Location = New System.Drawing.Point(18, 78)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(103, 13)
        Me.lblBanco.TabIndex = 3
        Me.lblBanco.Text = "Institución Bancaria:"
        '
        'lblFechaApertura
        '
        Me.lblFechaApertura.AutoSize = True
        Me.lblFechaApertura.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaApertura.Location = New System.Drawing.Point(280, 105)
        Me.lblFechaApertura.Name = "lblFechaApertura"
        Me.lblFechaApertura.Size = New System.Drawing.Size(83, 13)
        Me.lblFechaApertura.TabIndex = 2
        Me.lblFechaApertura.Text = "Fecha Apertura:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(18, 51)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(84, 13)
        Me.lblNombre.TabIndex = 1
        Me.lblNombre.Text = "Nombre Cuenta:"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumero.Location = New System.Drawing.Point(18, 26)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(84, 13)
        Me.lblNumero.TabIndex = 0
        Me.lblNumero.Text = "Número Cuenta:"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(381, 238)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(458, 238)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSteEditCtaBancaria
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(542, 275)
        Me.Controls.Add(Me.grpDatosGrales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditCtaBancaria"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cuenta Bancaria"
        CType(Me.errCtaBancaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosGrales.ResumeLayout(False)
        Me.grpDatosGrales.PerformLayout()
        CType(Me.cboMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errCtaBancaria As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpDatosGrales As System.Windows.Forms.GroupBox
    Friend WithEvents cboMoneda As C1.Win.C1List.C1Combo
    Friend WithEvents cboTipoCuenta As C1.Win.C1List.C1Combo
    Friend WithEvents cdeFechaCierre As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaApertura As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cboInstitucion As C1.Win.C1List.C1Combo
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblMoneda As System.Windows.Forms.Label
    Friend WithEvents lblTipoCuenta As System.Windows.Forms.Label
    Friend WithEvents lblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents lblFechaApertura As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents chkCerrada As System.Windows.Forms.CheckBox
    Friend WithEvents txtNumInicialCheque As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroInicialCheque As System.Windows.Forms.Label
    Friend WithEvents txtNumFinalCheque As System.Windows.Forms.TextBox
    Friend WithEvents lblNumFinalCheque As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
