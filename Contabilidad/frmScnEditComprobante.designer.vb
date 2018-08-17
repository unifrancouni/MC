<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnEditComprobante
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnEditComprobante))
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox
        Me.cboMinuta = New C1.Win.C1List.C1Combo
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.txtCUE = New System.Windows.Forms.TextBox
        Me.cboFuente = New C1.Win.C1List.C1Combo
        Me.cdeFechaTC = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaCD = New C1.Win.C1Input.C1DateEdit
        Me.lblConcepto = New System.Windows.Forms.Label
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.lblMonto = New System.Windows.Forms.Label
        Me.lblFechaTC = New System.Windows.Forms.Label
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.lblFecha = New System.Windows.Forms.Label
        Me.cboBeneficiario = New C1.Win.C1List.C1Combo
        Me.lblBeneficiario = New System.Windows.Forms.Label
        Me.lblFuente = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errComprobante = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cboMinuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBeneficiario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.cboMinuta)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaD)
        Me.grpDatosGenerales.Controls.Add(Me.txtCUE)
        Me.grpDatosGenerales.Controls.Add(Me.cboFuente)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaTC)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaCD)
        Me.grpDatosGenerales.Controls.Add(Me.lblConcepto)
        Me.grpDatosGenerales.Controls.Add(Me.lblObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.txtConcepto)
        Me.grpDatosGenerales.Controls.Add(Me.lblMonto)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaTC)
        Me.grpDatosGenerales.Controls.Add(Me.txtObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.lblFecha)
        Me.grpDatosGenerales.Controls.Add(Me.cboBeneficiario)
        Me.grpDatosGenerales.Controls.Add(Me.lblBeneficiario)
        Me.grpDatosGenerales.Controls.Add(Me.lblFuente)
        Me.grpDatosGenerales.Controls.Add(Me.lblCodigo)
        Me.grpDatosGenerales.Controls.Add(Me.txtCodigo)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(12, 12)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(685, 299)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Generales: "
        '
        'cboMinuta
        '
        Me.cboMinuta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMinuta.AutoCompletion = True
        Me.cboMinuta.Caption = ""
        Me.cboMinuta.CaptionHeight = 17
        Me.cboMinuta.CaptionStyle = Style1
        Me.cboMinuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMinuta.ColumnCaptionHeight = 17
        Me.cboMinuta.ColumnFooterHeight = 17
        Me.cboMinuta.ContentHeight = 15
        Me.cboMinuta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMinuta.DisplayMember = "sNumeroDeposito"
        Me.cboMinuta.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMinuta.DropDownWidth = 276
        Me.cboMinuta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMinuta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMinuta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMinuta.EditorHeight = 15
        Me.cboMinuta.EvenRowStyle = Style2
        Me.cboMinuta.ExtendRightColumn = True
        Me.cboMinuta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMinuta.FooterStyle = Style3
        Me.cboMinuta.GapHeight = 2
        Me.cboMinuta.HeadingStyle = Style4
        Me.cboMinuta.HighLightRowStyle = Style5
        Me.cboMinuta.Images.Add(CType(resources.GetObject("cboMinuta.Images"), System.Drawing.Image))
        Me.cboMinuta.ItemHeight = 15
        Me.cboMinuta.LimitToList = True
        Me.cboMinuta.Location = New System.Drawing.Point(388, 21)
        Me.cboMinuta.MatchEntryTimeout = CType(2000, Long)
        Me.cboMinuta.MaxDropDownItems = CType(5, Short)
        Me.cboMinuta.MaxLength = 32767
        Me.cboMinuta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMinuta.Name = "cboMinuta"
        Me.cboMinuta.OddRowStyle = Style6
        Me.cboMinuta.PartialRightColumn = False
        Me.cboMinuta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMinuta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMinuta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMinuta.SelectedStyle = Style7
        Me.cboMinuta.Size = New System.Drawing.Size(275, 21)
        Me.cboMinuta.Style = Style8
        Me.cboMinuta.SuperBack = True
        Me.cboMinuta.TabIndex = 1
        Me.cboMinuta.ValueMember = "nSteMinutaDepositoID"
        Me.cboMinuta.PropBag = resources.GetString("cboMinuta.PropBag")
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(291, 21)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(87, 13)
        Me.lblFechaD.TabIndex = 41
        Me.lblFechaD.Text = "Minuta Depósito:"
        '
        'txtCUE
        '
        Me.txtCUE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCUE.Location = New System.Drawing.Point(170, 104)
        Me.txtCUE.Name = "txtCUE"
        Me.txtCUE.Size = New System.Drawing.Size(193, 20)
        Me.txtCUE.TabIndex = 5
        '
        'cboFuente
        '
        Me.cboFuente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFuente.AutoCompletion = True
        Me.cboFuente.Caption = ""
        Me.cboFuente.CaptionHeight = 17
        Me.cboFuente.CaptionStyle = Style9
        Me.cboFuente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFuente.ColumnCaptionHeight = 17
        Me.cboFuente.ColumnFooterHeight = 17
        Me.cboFuente.ContentHeight = 15
        Me.cboFuente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFuente.DisplayMember = "sNombre"
        Me.cboFuente.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFuente.DropDownWidth = 276
        Me.cboFuente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFuente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFuente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFuente.EditorHeight = 15
        Me.cboFuente.EvenRowStyle = Style10
        Me.cboFuente.ExtendRightColumn = True
        Me.cboFuente.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFuente.FooterStyle = Style11
        Me.cboFuente.GapHeight = 2
        Me.cboFuente.HeadingStyle = Style12
        Me.cboFuente.HighLightRowStyle = Style13
        Me.cboFuente.Images.Add(CType(resources.GetObject("cboFuente.Images"), System.Drawing.Image))
        Me.cboFuente.ItemHeight = 15
        Me.cboFuente.LimitToList = True
        Me.cboFuente.Location = New System.Drawing.Point(170, 135)
        Me.cboFuente.MatchEntryTimeout = CType(2000, Long)
        Me.cboFuente.MaxDropDownItems = CType(5, Short)
        Me.cboFuente.MaxLength = 32767
        Me.cboFuente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFuente.Name = "cboFuente"
        Me.cboFuente.OddRowStyle = Style14
        Me.cboFuente.PartialRightColumn = False
        Me.cboFuente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFuente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFuente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFuente.SelectedStyle = Style15
        Me.cboFuente.Size = New System.Drawing.Size(275, 21)
        Me.cboFuente.Style = Style16
        Me.cboFuente.SuperBack = True
        Me.cboFuente.TabIndex = 6
        Me.cboFuente.ValueMember = "nScnFuenteFinanciamientoID"
        Me.cboFuente.PropBag = resources.GetString("cboFuente.PropBag")
        '
        'cdeFechaTC
        '
        Me.cdeFechaTC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaTC.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaTC.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaTC.Location = New System.Drawing.Point(170, 47)
        Me.cdeFechaTC.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaTC.MaskInfo.EmptyAsNull = True
        Me.cdeFechaTC.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaTC.Name = "cdeFechaTC"
        Me.cdeFechaTC.Size = New System.Drawing.Size(118, 20)
        Me.cdeFechaTC.TabIndex = 2
        Me.cdeFechaTC.Tag = Nothing
        Me.cdeFechaTC.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaCD
        '
        Me.cdeFechaCD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaCD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCD.Location = New System.Drawing.Point(170, 18)
        Me.cdeFechaCD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaCD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaCD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaCD.Name = "cdeFechaCD"
        Me.cdeFechaCD.Size = New System.Drawing.Size(118, 20)
        Me.cdeFechaCD.TabIndex = 0
        Me.cdeFechaCD.Tag = Nothing
        Me.cdeFechaCD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblConcepto.Location = New System.Drawing.Point(47, 196)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(66, 13)
        Me.lblConcepto.TabIndex = 26
        Me.lblConcepto.Text = "Descripción:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(47, 237)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 26
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Location = New System.Drawing.Point(170, 193)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConcepto.Size = New System.Drawing.Size(493, 38)
        Me.txtConcepto.TabIndex = 8
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Location = New System.Drawing.Point(47, 111)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(72, 13)
        Me.lblMonto.TabIndex = 38
        Me.lblMonto.Text = "Número CUE:"
        '
        'lblFechaTC
        '
        Me.lblFechaTC.AutoSize = True
        Me.lblFechaTC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaTC.Location = New System.Drawing.Point(47, 47)
        Me.lblFechaTC.Name = "lblFechaTC"
        Me.lblFechaTC.Size = New System.Drawing.Size(102, 13)
        Me.lblFechaTC.TabIndex = 37
        Me.lblFechaTC.Text = "Fecha Tipo Cambio:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(170, 237)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(492, 48)
        Me.txtObservaciones.TabIndex = 9
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(47, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(106, 13)
        Me.lblFecha.TabIndex = 35
        Me.lblFecha.Text = "Fecha Comprobante:"
        '
        'cboBeneficiario
        '
        Me.cboBeneficiario.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboBeneficiario.AutoCompletion = True
        Me.cboBeneficiario.Caption = ""
        Me.cboBeneficiario.CaptionHeight = 17
        Me.cboBeneficiario.CaptionStyle = Style17
        Me.cboBeneficiario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBeneficiario.ColumnCaptionHeight = 17
        Me.cboBeneficiario.ColumnFooterHeight = 17
        Me.cboBeneficiario.ContentHeight = 15
        Me.cboBeneficiario.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBeneficiario.DisplayMember = "sNombre"
        Me.cboBeneficiario.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboBeneficiario.DropDownWidth = 276
        Me.cboBeneficiario.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBeneficiario.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBeneficiario.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBeneficiario.EditorHeight = 15
        Me.cboBeneficiario.EvenRowStyle = Style18
        Me.cboBeneficiario.ExtendRightColumn = True
        Me.cboBeneficiario.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboBeneficiario.FooterStyle = Style19
        Me.cboBeneficiario.GapHeight = 2
        Me.cboBeneficiario.HeadingStyle = Style20
        Me.cboBeneficiario.HighLightRowStyle = Style21
        Me.cboBeneficiario.Images.Add(CType(resources.GetObject("cboBeneficiario.Images"), System.Drawing.Image))
        Me.cboBeneficiario.ItemHeight = 15
        Me.cboBeneficiario.LimitToList = True
        Me.cboBeneficiario.Location = New System.Drawing.Point(170, 163)
        Me.cboBeneficiario.MatchEntryTimeout = CType(2000, Long)
        Me.cboBeneficiario.MaxDropDownItems = CType(5, Short)
        Me.cboBeneficiario.MaxLength = 32767
        Me.cboBeneficiario.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBeneficiario.Name = "cboBeneficiario"
        Me.cboBeneficiario.OddRowStyle = Style22
        Me.cboBeneficiario.PartialRightColumn = False
        Me.cboBeneficiario.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBeneficiario.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBeneficiario.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBeneficiario.SelectedStyle = Style23
        Me.cboBeneficiario.Size = New System.Drawing.Size(275, 21)
        Me.cboBeneficiario.Style = Style24
        Me.cboBeneficiario.SuperBack = True
        Me.cboBeneficiario.TabIndex = 7
        Me.cboBeneficiario.ValueMember = "nBeneficiarioID"
        Me.cboBeneficiario.PropBag = resources.GetString("cboBeneficiario.PropBag")
        '
        'lblBeneficiario
        '
        Me.lblBeneficiario.AutoSize = True
        Me.lblBeneficiario.ForeColor = System.Drawing.Color.Black
        Me.lblBeneficiario.Location = New System.Drawing.Point(47, 164)
        Me.lblBeneficiario.Name = "lblBeneficiario"
        Me.lblBeneficiario.Size = New System.Drawing.Size(125, 13)
        Me.lblBeneficiario.TabIndex = 30
        Me.lblBeneficiario.Text = "Beneficiario / Proveedor:"
        '
        'lblFuente
        '
        Me.lblFuente.AutoSize = True
        Me.lblFuente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFuente.Location = New System.Drawing.Point(47, 135)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(96, 13)
        Me.lblFuente.TabIndex = 26
        Me.lblFuente.Text = "Fuente de Fondos:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(47, 80)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(109, 13)
        Me.lblCodigo.TabIndex = 25
        Me.lblCodigo.Text = "Código Comprobante:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(170, 80)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(193, 20)
        Me.txtCodigo.TabIndex = 4
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(542, 317)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(619, 317)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errComprobante
        '
        Me.errComprobante.ContainerControl = Me
        '
        'frmScnEditComprobante
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(704, 350)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnEditComprobante"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Registro de Comprobantes de Diario."
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cboMinuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBeneficiario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cboBeneficiario As C1.Win.C1List.C1Combo
    Friend WithEvents errComprobante As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents lblBeneficiario As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblFechaTC As System.Windows.Forms.Label
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents cdeFechaTC As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaCD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cboFuente As C1.Win.C1List.C1Combo
    Friend WithEvents txtCUE As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents cboMinuta As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
