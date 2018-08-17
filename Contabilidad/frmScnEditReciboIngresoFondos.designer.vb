<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnEditReciboIngresoFondos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnEditReciboIngresoFondos))
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
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox
        Me.txtNoCheque = New System.Windows.Forms.TextBox
        Me.cboBanco = New C1.Win.C1List.C1Combo
        Me.lblBanco = New System.Windows.Forms.Label
        Me.lblNoCheque = New System.Windows.Forms.Label
        Me.grpRecibidoCon = New System.Windows.Forms.GroupBox
        Me.RadTB = New System.Windows.Forms.RadioButton
        Me.RadCheque = New System.Windows.Forms.RadioButton
        Me.radEfectivo = New System.Windows.Forms.RadioButton
        Me.cboPorCuentaDe = New C1.Win.C1List.C1Combo
        Me.lblANombreDe = New System.Windows.Forms.Label
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
        Me.cboRecibidoDe = New C1.Win.C1List.C1Combo
        Me.lblBeneficiario = New System.Windows.Forms.Label
        Me.lblFuente = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cboBanco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRecibidoCon.SuspendLayout()
        CType(Me.cboPorCuentaDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRecibidoDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.txtNoCheque)
        Me.grpDatosGenerales.Controls.Add(Me.cboBanco)
        Me.grpDatosGenerales.Controls.Add(Me.lblBanco)
        Me.grpDatosGenerales.Controls.Add(Me.lblNoCheque)
        Me.grpDatosGenerales.Controls.Add(Me.grpRecibidoCon)
        Me.grpDatosGenerales.Controls.Add(Me.cboPorCuentaDe)
        Me.grpDatosGenerales.Controls.Add(Me.lblANombreDe)
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
        Me.grpDatosGenerales.Controls.Add(Me.cboRecibidoDe)
        Me.grpDatosGenerales.Controls.Add(Me.lblBeneficiario)
        Me.grpDatosGenerales.Controls.Add(Me.lblFuente)
        Me.grpDatosGenerales.Controls.Add(Me.lblCodigo)
        Me.grpDatosGenerales.Controls.Add(Me.txtCodigo)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(12, 12)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(685, 383)
        Me.grpDatosGenerales.TabIndex = 16
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Generales: "
        '
        'txtNoCheque
        '
        Me.txtNoCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoCheque.Location = New System.Drawing.Point(444, 316)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(217, 20)
        Me.txtNoCheque.TabIndex = 12
        '
        'cboBanco
        '
        Me.cboBanco.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboBanco.AutoCompletion = True
        Me.cboBanco.Caption = ""
        Me.cboBanco.CaptionHeight = 17
        Me.cboBanco.CaptionStyle = Style1
        Me.cboBanco.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBanco.ColumnCaptionHeight = 17
        Me.cboBanco.ColumnFooterHeight = 17
        Me.cboBanco.ContentHeight = 15
        Me.cboBanco.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBanco.DisplayMember = "sNombre"
        Me.cboBanco.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboBanco.DropDownWidth = 276
        Me.cboBanco.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBanco.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBanco.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBanco.EditorHeight = 15
        Me.cboBanco.EvenRowStyle = Style2
        Me.cboBanco.ExtendRightColumn = True
        Me.cboBanco.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboBanco.FooterStyle = Style3
        Me.cboBanco.GapHeight = 2
        Me.cboBanco.HeadingStyle = Style4
        Me.cboBanco.HighLightRowStyle = Style5
        Me.cboBanco.Images.Add(CType(resources.GetObject("cboBanco.Images"), System.Drawing.Image))
        Me.cboBanco.ItemHeight = 15
        Me.cboBanco.LimitToList = True
        Me.cboBanco.Location = New System.Drawing.Point(444, 342)
        Me.cboBanco.MatchEntryTimeout = CType(2000, Long)
        Me.cboBanco.MaxDropDownItems = CType(5, Short)
        Me.cboBanco.MaxLength = 32767
        Me.cboBanco.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.OddRowStyle = Style6
        Me.cboBanco.PartialRightColumn = False
        Me.cboBanco.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBanco.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBanco.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBanco.SelectedStyle = Style7
        Me.cboBanco.Size = New System.Drawing.Size(218, 21)
        Me.cboBanco.Style = Style8
        Me.cboBanco.SuperBack = True
        Me.cboBanco.TabIndex = 13
        Me.cboBanco.ValueMember = "nBeneficiarioID"
        Me.cboBanco.PropBag = resources.GetString("cboBanco.PropBag")
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.ForeColor = System.Drawing.Color.Black
        Me.lblBanco.Location = New System.Drawing.Point(348, 347)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(81, 13)
        Me.lblBanco.TabIndex = 43
        Me.lblBanco.Text = "Nombre Banco:"
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.ForeColor = System.Drawing.Color.Black
        Me.lblNoCheque.Location = New System.Drawing.Point(348, 323)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(87, 13)
        Me.lblNoCheque.TabIndex = 42
        Me.lblNoCheque.Text = "Número Cheque:"
        '
        'grpRecibidoCon
        '
        Me.grpRecibidoCon.Controls.Add(Me.RadTB)
        Me.grpRecibidoCon.Controls.Add(Me.RadCheque)
        Me.grpRecibidoCon.Controls.Add(Me.radEfectivo)
        Me.grpRecibidoCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpRecibidoCon.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpRecibidoCon.Location = New System.Drawing.Point(50, 313)
        Me.grpRecibidoCon.Name = "grpRecibidoCon"
        Me.grpRecibidoCon.Size = New System.Drawing.Size(292, 57)
        Me.grpRecibidoCon.TabIndex = 17
        Me.grpRecibidoCon.TabStop = False
        Me.grpRecibidoCon.Text = "Recibido Con: "
        '
        'RadTB
        '
        Me.RadTB.AutoSize = True
        Me.RadTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadTB.Location = New System.Drawing.Point(167, 22)
        Me.RadTB.Name = "RadTB"
        Me.RadTB.Size = New System.Drawing.Size(114, 17)
        Me.RadTB.TabIndex = 11
        Me.RadTB.Text = "Traspaso Bancario"
        Me.RadTB.UseVisualStyleBackColor = True
        '
        'RadCheque
        '
        Me.RadCheque.AutoSize = True
        Me.RadCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCheque.Location = New System.Drawing.Point(99, 22)
        Me.RadCheque.Name = "RadCheque"
        Me.RadCheque.Size = New System.Drawing.Size(62, 17)
        Me.RadCheque.TabIndex = 10
        Me.RadCheque.Text = "Cheque"
        Me.RadCheque.UseVisualStyleBackColor = True
        '
        'radEfectivo
        '
        Me.radEfectivo.AutoSize = True
        Me.radEfectivo.Checked = True
        Me.radEfectivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radEfectivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radEfectivo.Location = New System.Drawing.Point(20, 22)
        Me.radEfectivo.Name = "radEfectivo"
        Me.radEfectivo.Size = New System.Drawing.Size(64, 17)
        Me.radEfectivo.TabIndex = 9
        Me.radEfectivo.TabStop = True
        Me.radEfectivo.Text = "Efectivo"
        Me.radEfectivo.UseVisualStyleBackColor = True
        '
        'cboPorCuentaDe
        '
        Me.cboPorCuentaDe.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboPorCuentaDe.AutoCompletion = True
        Me.cboPorCuentaDe.Caption = ""
        Me.cboPorCuentaDe.CaptionHeight = 17
        Me.cboPorCuentaDe.CaptionStyle = Style9
        Me.cboPorCuentaDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPorCuentaDe.ColumnCaptionHeight = 17
        Me.cboPorCuentaDe.ColumnFooterHeight = 17
        Me.cboPorCuentaDe.ContentHeight = 15
        Me.cboPorCuentaDe.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPorCuentaDe.DisplayMember = "sNombre"
        Me.cboPorCuentaDe.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboPorCuentaDe.DropDownWidth = 276
        Me.cboPorCuentaDe.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPorCuentaDe.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPorCuentaDe.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPorCuentaDe.EditorHeight = 15
        Me.cboPorCuentaDe.EvenRowStyle = Style10
        Me.cboPorCuentaDe.ExtendRightColumn = True
        Me.cboPorCuentaDe.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboPorCuentaDe.FooterStyle = Style11
        Me.cboPorCuentaDe.GapHeight = 2
        Me.cboPorCuentaDe.HeadingStyle = Style12
        Me.cboPorCuentaDe.HighLightRowStyle = Style13
        Me.cboPorCuentaDe.Images.Add(CType(resources.GetObject("cboPorCuentaDe.Images"), System.Drawing.Image))
        Me.cboPorCuentaDe.ItemHeight = 15
        Me.cboPorCuentaDe.LimitToList = True
        Me.cboPorCuentaDe.Location = New System.Drawing.Point(170, 197)
        Me.cboPorCuentaDe.MatchEntryTimeout = CType(2000, Long)
        Me.cboPorCuentaDe.MaxDropDownItems = CType(5, Short)
        Me.cboPorCuentaDe.MaxLength = 32767
        Me.cboPorCuentaDe.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPorCuentaDe.Name = "cboPorCuentaDe"
        Me.cboPorCuentaDe.OddRowStyle = Style14
        Me.cboPorCuentaDe.PartialRightColumn = False
        Me.cboPorCuentaDe.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPorCuentaDe.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPorCuentaDe.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPorCuentaDe.SelectedStyle = Style15
        Me.cboPorCuentaDe.Size = New System.Drawing.Size(275, 21)
        Me.cboPorCuentaDe.Style = Style16
        Me.cboPorCuentaDe.SuperBack = True
        Me.cboPorCuentaDe.TabIndex = 6
        Me.cboPorCuentaDe.ValueMember = "nBeneficiarioID"
        Me.cboPorCuentaDe.PropBag = resources.GetString("cboPorCuentaDe.PropBag")
        '
        'lblANombreDe
        '
        Me.lblANombreDe.AutoSize = True
        Me.lblANombreDe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblANombreDe.Location = New System.Drawing.Point(47, 198)
        Me.lblANombreDe.Name = "lblANombreDe"
        Me.lblANombreDe.Size = New System.Drawing.Size(80, 13)
        Me.lblANombreDe.TabIndex = 40
        Me.lblANombreDe.Text = "Por Cuenta De:"
        '
        'txtCUE
        '
        Me.txtCUE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCUE.Location = New System.Drawing.Point(170, 106)
        Me.txtCUE.Name = "txtCUE"
        Me.txtCUE.Size = New System.Drawing.Size(118, 20)
        Me.txtCUE.TabIndex = 3
        '
        'cboFuente
        '
        Me.cboFuente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFuente.AutoCompletion = True
        Me.cboFuente.Caption = ""
        Me.cboFuente.CaptionHeight = 17
        Me.cboFuente.CaptionStyle = Style17
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
        Me.cboFuente.EvenRowStyle = Style18
        Me.cboFuente.ExtendRightColumn = True
        Me.cboFuente.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFuente.FooterStyle = Style19
        Me.cboFuente.GapHeight = 2
        Me.cboFuente.HeadingStyle = Style20
        Me.cboFuente.HighLightRowStyle = Style21
        Me.cboFuente.Images.Add(CType(resources.GetObject("cboFuente.Images"), System.Drawing.Image))
        Me.cboFuente.ItemHeight = 15
        Me.cboFuente.LimitToList = True
        Me.cboFuente.Location = New System.Drawing.Point(170, 134)
        Me.cboFuente.MatchEntryTimeout = CType(2000, Long)
        Me.cboFuente.MaxDropDownItems = CType(5, Short)
        Me.cboFuente.MaxLength = 32767
        Me.cboFuente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFuente.Name = "cboFuente"
        Me.cboFuente.OddRowStyle = Style22
        Me.cboFuente.PartialRightColumn = False
        Me.cboFuente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFuente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFuente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFuente.SelectedStyle = Style23
        Me.cboFuente.Size = New System.Drawing.Size(275, 21)
        Me.cboFuente.Style = Style24
        Me.cboFuente.SuperBack = True
        Me.cboFuente.TabIndex = 4
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
        Me.cdeFechaTC.TabIndex = 1
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
        Me.lblConcepto.Location = New System.Drawing.Point(47, 227)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(89, 13)
        Me.lblConcepto.TabIndex = 26
        Me.lblConcepto.Text = "En Concepto De:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(47, 268)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 26
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Location = New System.Drawing.Point(170, 224)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConcepto.Size = New System.Drawing.Size(492, 38)
        Me.txtConcepto.TabIndex = 7
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.Color.Black
        Me.lblMonto.Location = New System.Drawing.Point(47, 109)
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
        Me.txtObservaciones.Location = New System.Drawing.Point(170, 268)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(491, 39)
        Me.txtObservaciones.TabIndex = 8
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(47, 18)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(77, 13)
        Me.lblFecha.TabIndex = 35
        Me.lblFecha.Text = "Fecha Recibo:"
        '
        'cboRecibidoDe
        '
        Me.cboRecibidoDe.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboRecibidoDe.AutoCompletion = True
        Me.cboRecibidoDe.Caption = ""
        Me.cboRecibidoDe.CaptionHeight = 17
        Me.cboRecibidoDe.CaptionStyle = Style25
        Me.cboRecibidoDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboRecibidoDe.ColumnCaptionHeight = 17
        Me.cboRecibidoDe.ColumnFooterHeight = 17
        Me.cboRecibidoDe.ContentHeight = 15
        Me.cboRecibidoDe.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboRecibidoDe.DisplayMember = "sNombre"
        Me.cboRecibidoDe.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboRecibidoDe.DropDownWidth = 276
        Me.cboRecibidoDe.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboRecibidoDe.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecibidoDe.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRecibidoDe.EditorHeight = 15
        Me.cboRecibidoDe.EvenRowStyle = Style26
        Me.cboRecibidoDe.ExtendRightColumn = True
        Me.cboRecibidoDe.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboRecibidoDe.FooterStyle = Style27
        Me.cboRecibidoDe.GapHeight = 2
        Me.cboRecibidoDe.HeadingStyle = Style28
        Me.cboRecibidoDe.HighLightRowStyle = Style29
        Me.cboRecibidoDe.Images.Add(CType(resources.GetObject("cboRecibidoDe.Images"), System.Drawing.Image))
        Me.cboRecibidoDe.ItemHeight = 15
        Me.cboRecibidoDe.LimitToList = True
        Me.cboRecibidoDe.Location = New System.Drawing.Point(170, 163)
        Me.cboRecibidoDe.MatchEntryTimeout = CType(2000, Long)
        Me.cboRecibidoDe.MaxDropDownItems = CType(5, Short)
        Me.cboRecibidoDe.MaxLength = 32767
        Me.cboRecibidoDe.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboRecibidoDe.Name = "cboRecibidoDe"
        Me.cboRecibidoDe.OddRowStyle = Style30
        Me.cboRecibidoDe.PartialRightColumn = False
        Me.cboRecibidoDe.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboRecibidoDe.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboRecibidoDe.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboRecibidoDe.SelectedStyle = Style31
        Me.cboRecibidoDe.Size = New System.Drawing.Size(275, 21)
        Me.cboRecibidoDe.Style = Style32
        Me.cboRecibidoDe.SuperBack = True
        Me.cboRecibidoDe.TabIndex = 5
        Me.cboRecibidoDe.ValueMember = "nBeneficiarioID"
        Me.cboRecibidoDe.PropBag = resources.GetString("cboRecibidoDe.PropBag")
        '
        'lblBeneficiario
        '
        Me.lblBeneficiario.AutoSize = True
        Me.lblBeneficiario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblBeneficiario.Location = New System.Drawing.Point(47, 164)
        Me.lblBeneficiario.Name = "lblBeneficiario"
        Me.lblBeneficiario.Size = New System.Drawing.Size(76, 13)
        Me.lblBeneficiario.TabIndex = 30
        Me.lblBeneficiario.Text = "Recibimos De:"
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
        Me.lblCodigo.Size = New System.Drawing.Size(77, 13)
        Me.lblCodigo.TabIndex = 25
        Me.lblCodigo.Text = "Código Recibo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(170, 80)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(118, 20)
        Me.txtCodigo.TabIndex = 2
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(547, 401)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 14
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(624, 401)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'frmScnEditReciboIngresoFondos
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(709, 435)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Recibos de Ingreso de Fondos")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnEditReciboIngresoFondos"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Registro de Recibo de Ingreso de Fondos"
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cboBanco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRecibidoCon.ResumeLayout(False)
        Me.grpRecibidoCon.PerformLayout()
        CType(Me.cboPorCuentaDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRecibidoDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cboRecibidoDe As C1.Win.C1List.C1Combo
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
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
    Friend WithEvents cboPorCuentaDe As C1.Win.C1List.C1Combo
    Friend WithEvents lblANombreDe As System.Windows.Forms.Label
    Friend WithEvents grpRecibidoCon As System.Windows.Forms.GroupBox
    Friend WithEvents RadTB As System.Windows.Forms.RadioButton
    Friend WithEvents RadCheque As System.Windows.Forms.RadioButton
    Friend WithEvents radEfectivo As System.Windows.Forms.RadioButton
    Friend WithEvents txtNoCheque As System.Windows.Forms.TextBox
    Friend WithEvents cboBanco As C1.Win.C1List.C1Combo
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents lblNoCheque As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
