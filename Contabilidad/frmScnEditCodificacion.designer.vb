<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnEditCodificacion
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnEditCodificacion))
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
        Me.cboFuente = New C1.Win.C1List.C1Combo
        Me.cdeFechaTC = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaCD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaTC = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.lblFuente = New System.Windows.Forms.Label
        Me.grpDetalle = New System.Windows.Forms.GroupBox
        Me.cmdEliminarC = New System.Windows.Forms.Button
        Me.cmdAgregarC = New System.Windows.Forms.Button
        Me.cneMonto = New C1.Win.C1Input.C1NumericEdit
        Me.lblMonto = New System.Windows.Forms.Label
        Me.lblNombreCuenta = New System.Windows.Forms.Label
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.chkDebe = New System.Windows.Forms.CheckBox
        Me.lblDebito = New System.Windows.Forms.Label
        Me.cboCuenta = New C1.Win.C1List.C1Combo
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errComprobante = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpCodificacion = New System.Windows.Forms.GroupBox
        Me.cneHaber = New C1.Win.C1Input.C1NumericEdit
        Me.cneDebe = New C1.Win.C1Input.C1NumericEdit
        Me.lvwCuentas = New System.Windows.Forms.ListView
        Me.nScnTransaccionContableDetalleID = New System.Windows.Forms.ColumnHeader
        Me.nScnTransaccionContableID = New System.Windows.Forms.ColumnHeader
        Me.nScnCatalogoContableID = New System.Windows.Forms.ColumnHeader
        Me.sCodigoCuenta = New System.Windows.Forms.ColumnHeader
        Me.sNombreCuenta = New System.Windows.Forms.ColumnHeader
        Me.nDebito = New System.Windows.Forms.ColumnHeader
        Me.nMontoDebeC = New System.Windows.Forms.ColumnHeader
        Me.nMontoHaberC = New System.Windows.Forms.ColumnHeader
        Me.nMontoD = New System.Windows.Forms.ColumnHeader
        Me.nScnFuenteFinanciamientoID = New System.Windows.Forms.ColumnHeader
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetalle.SuspendLayout()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCodificacion.SuspendLayout()
        CType(Me.cneHaber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneDebe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.cboFuente)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaTC)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaCD)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaTC)
        Me.grpDatosGenerales.Controls.Add(Me.lblFecha)
        Me.grpDatosGenerales.Controls.Add(Me.lblFuente)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(14, 12)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(685, 128)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Generales: "
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
        Me.cboFuente.DeadAreaBackColor = System.Drawing.SystemColors.HighlightText
        Me.cboFuente.DisplayMember = "sNombre"
        Me.cboFuente.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFuente.DropDownWidth = 319
        Me.cboFuente.EditorBackColor = System.Drawing.SystemColors.HighlightText
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
        Me.cboFuente.Location = New System.Drawing.Point(158, 87)
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
        Me.cboFuente.Size = New System.Drawing.Size(317, 21)
        Me.cboFuente.Style = Style24
        Me.cboFuente.SuperBack = True
        Me.cboFuente.TabIndex = 4
        Me.cboFuente.ValueMember = "nScnFuenteFinanciamientoID"
        Me.cboFuente.PropBag = resources.GetString("cboFuente.PropBag")
        '
        'cdeFechaTC
        '
        Me.cdeFechaTC.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cdeFechaTC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaTC.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaTC.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaTC.Location = New System.Drawing.Point(158, 57)
        Me.cdeFechaTC.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaTC.MaskInfo.EmptyAsNull = True
        Me.cdeFechaTC.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaTC.Name = "cdeFechaTC"
        Me.cdeFechaTC.Size = New System.Drawing.Size(94, 20)
        Me.cdeFechaTC.TabIndex = 1
        Me.cdeFechaTC.Tag = Nothing
        Me.cdeFechaTC.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaCD
        '
        Me.cdeFechaCD.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.cdeFechaCD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaCD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCD.Location = New System.Drawing.Point(158, 30)
        Me.cdeFechaCD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaCD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaCD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaCD.Name = "cdeFechaCD"
        Me.cdeFechaCD.Size = New System.Drawing.Size(94, 20)
        Me.cdeFechaCD.TabIndex = 0
        Me.cdeFechaCD.Tag = Nothing
        Me.cdeFechaCD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaTC
        '
        Me.lblFechaTC.AutoSize = True
        Me.lblFechaTC.ForeColor = System.Drawing.Color.Black
        Me.lblFechaTC.Location = New System.Drawing.Point(52, 60)
        Me.lblFechaTC.Name = "lblFechaTC"
        Me.lblFechaTC.Size = New System.Drawing.Size(102, 13)
        Me.lblFechaTC.TabIndex = 37
        Me.lblFechaTC.Text = "Fecha Tipo Cambio:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.Black
        Me.lblFecha.Location = New System.Drawing.Point(52, 30)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(106, 13)
        Me.lblFecha.TabIndex = 35
        Me.lblFecha.Text = "Fecha Comprobante:"
        '
        'lblFuente
        '
        Me.lblFuente.AutoSize = True
        Me.lblFuente.ForeColor = System.Drawing.Color.Black
        Me.lblFuente.Location = New System.Drawing.Point(52, 89)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(96, 13)
        Me.lblFuente.TabIndex = 26
        Me.lblFuente.Text = "Fuente de Fondos:"
        '
        'grpDetalle
        '
        Me.grpDetalle.Controls.Add(Me.cmdEliminarC)
        Me.grpDetalle.Controls.Add(Me.cmdAgregarC)
        Me.grpDetalle.Controls.Add(Me.cneMonto)
        Me.grpDetalle.Controls.Add(Me.lblMonto)
        Me.grpDetalle.Controls.Add(Me.lblNombreCuenta)
        Me.grpDetalle.Controls.Add(Me.txtCuenta)
        Me.grpDetalle.Controls.Add(Me.chkDebe)
        Me.grpDetalle.Controls.Add(Me.lblDebito)
        Me.grpDetalle.Controls.Add(Me.cboCuenta)
        Me.grpDetalle.Controls.Add(Me.lblCuenta)
        Me.grpDetalle.Location = New System.Drawing.Point(11, 19)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(668, 127)
        Me.grpDetalle.TabIndex = 42
        Me.grpDetalle.TabStop = False
        '
        'cmdEliminarC
        '
        Me.cmdEliminarC.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.cmdEliminarC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEliminarC.Location = New System.Drawing.Point(558, 78)
        Me.cmdEliminarC.Name = "cmdEliminarC"
        Me.cmdEliminarC.Size = New System.Drawing.Size(104, 25)
        Me.cmdEliminarC.TabIndex = 106
        Me.cmdEliminarC.Text = "Eliminar Cuenta"
        Me.cmdEliminarC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEliminarC.UseVisualStyleBackColor = True
        '
        'cmdAgregarC
        '
        Me.cmdAgregarC.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.cmdAgregarC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAgregarC.Location = New System.Drawing.Point(558, 47)
        Me.cmdAgregarC.Name = "cmdAgregarC"
        Me.cmdAgregarC.Size = New System.Drawing.Size(104, 25)
        Me.cmdAgregarC.TabIndex = 105
        Me.cmdAgregarC.Text = "Agregar Cuenta"
        Me.cmdAgregarC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAgregarC.UseVisualStyleBackColor = True
        '
        'cneMonto
        '
        Me.cneMonto.AcceptsTab = True
        Me.cneMonto.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMonto.DataType = GetType(Double)
        Me.cneMonto.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneMonto.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMonto.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMonto.EditFormat.EmptyAsNull = False
        Me.cneMonto.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMonto.EmptyAsNull = True
        Me.cneMonto.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.Location = New System.Drawing.Point(159, 95)
        Me.cneMonto.MaskInfo.AutoTabWhenFilled = True
        Me.cneMonto.MaxLength = 999999999
        Me.cneMonto.Name = "cneMonto"
        Me.cneMonto.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMonto.Size = New System.Drawing.Size(152, 20)
        Me.cneMonto.TabIndex = 3
        Me.cneMonto.Tag = Nothing
        Me.cneMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMonto.UseColumnStyles = False
        Me.cneMonto.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(52, 99)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(65, 13)
        Me.lblMonto.TabIndex = 104
        Me.lblMonto.Text = "Monto (C$): "
        '
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.AutoSize = True
        Me.lblNombreCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreCuenta.Location = New System.Drawing.Point(52, 59)
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Size = New System.Drawing.Size(84, 13)
        Me.lblNombreCuenta.TabIndex = 103
        Me.lblNombreCuenta.Text = "Nombre Cuenta:"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.SystemColors.Info
        Me.txtCuenta.Enabled = False
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(158, 56)
        Me.txtCuenta.Multiline = True
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(394, 32)
        Me.txtCuenta.TabIndex = 2
        Me.txtCuenta.Tag = "LAYOUT:FLAT"
        '
        'chkDebe
        '
        Me.chkDebe.AutoSize = True
        Me.chkDebe.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDebe.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkDebe.Location = New System.Drawing.Point(371, 98)
        Me.chkDebe.Name = "chkDebe"
        Me.chkDebe.Size = New System.Drawing.Size(17, 17)
        Me.chkDebe.TabIndex = 4
        Me.chkDebe.Tag = ""
        Me.chkDebe.Text = "  "
        Me.chkDebe.UseVisualStyleBackColor = True
        '
        'lblDebito
        '
        Me.lblDebito.AutoSize = True
        Me.lblDebito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDebito.Location = New System.Drawing.Point(328, 100)
        Me.lblDebito.Name = "lblDebito"
        Me.lblDebito.Size = New System.Drawing.Size(41, 13)
        Me.lblDebito.TabIndex = 101
        Me.lblDebito.Text = "Débito:"
        '
        'cboCuenta
        '
        Me.cboCuenta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCuenta.AutoCompletion = True
        Me.cboCuenta.AutoDropDown = True
        Me.cboCuenta.Caption = ""
        Me.cboCuenta.CaptionHeight = 17
        Me.cboCuenta.CaptionStyle = Style25
        Me.cboCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCuenta.ColumnCaptionHeight = 17
        Me.cboCuenta.ColumnFooterHeight = 17
        Me.cboCuenta.ContentHeight = 15
        Me.cboCuenta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCuenta.DisplayMember = "sCodigoCuenta"
        Me.cboCuenta.DropDownWidth = 395
        Me.cboCuenta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCuenta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCuenta.EditorHeight = 15
        Me.cboCuenta.EvenRowStyle = Style26
        Me.cboCuenta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCuenta.FooterStyle = Style27
        Me.cboCuenta.GapHeight = 2
        Me.cboCuenta.HeadingStyle = Style28
        Me.cboCuenta.HighLightRowStyle = Style29
        Me.cboCuenta.Images.Add(CType(resources.GetObject("cboCuenta.Images"), System.Drawing.Image))
        Me.cboCuenta.ItemHeight = 15
        Me.cboCuenta.LimitToList = True
        Me.cboCuenta.Location = New System.Drawing.Point(158, 29)
        Me.cboCuenta.MatchEntryTimeout = CType(2000, Long)
        Me.cboCuenta.MaxDropDownItems = CType(5, Short)
        Me.cboCuenta.MaxLength = 32767
        Me.cboCuenta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.OddRowStyle = Style30
        Me.cboCuenta.PartialRightColumn = False
        Me.cboCuenta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCuenta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCuenta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCuenta.SelectedStyle = Style31
        Me.cboCuenta.Size = New System.Drawing.Size(394, 21)
        Me.cboCuenta.Style = Style32
        Me.cboCuenta.SuperBack = True
        Me.cboCuenta.TabIndex = 1
        Me.cboCuenta.ValueMember = "nScnCatalogoContableID"
        Me.cboCuenta.PropBag = resources.GetString("cboCuenta.PropBag")
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCuenta.Location = New System.Drawing.Point(52, 29)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(89, 13)
        Me.lblCuenta.TabIndex = 13
        Me.lblCuenta.Text = "Cuenta Contable:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(549, 477)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 11
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(626, 477)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 12
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errComprobante
        '
        Me.errComprobante.ContainerControl = Me
        '
        'grpCodificacion
        '
        Me.grpCodificacion.Controls.Add(Me.cneHaber)
        Me.grpCodificacion.Controls.Add(Me.cneDebe)
        Me.grpCodificacion.Controls.Add(Me.grpDetalle)
        Me.grpCodificacion.Controls.Add(Me.lvwCuentas)
        Me.grpCodificacion.Location = New System.Drawing.Point(14, 146)
        Me.grpCodificacion.Name = "grpCodificacion"
        Me.grpCodificacion.Size = New System.Drawing.Size(685, 325)
        Me.grpCodificacion.TabIndex = 13
        Me.grpCodificacion.TabStop = False
        Me.grpCodificacion.Text = "Codificación Contable: "
        '
        'cneHaber
        '
        Me.cneHaber.AcceptsTab = True
        Me.cneHaber.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneHaber.DataType = GetType(Double)
        Me.cneHaber.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneHaber.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneHaber.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneHaber.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneHaber.EditFormat.EmptyAsNull = False
        Me.cneHaber.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneHaber.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneHaber.EmptyAsNull = True
        Me.cneHaber.Enabled = False
        Me.cneHaber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cneHaber.ForeColor = System.Drawing.Color.Black
        Me.cneHaber.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneHaber.Location = New System.Drawing.Point(569, 296)
        Me.cneHaber.MaskInfo.AutoTabWhenFilled = True
        Me.cneHaber.MaxLength = 999999999
        Me.cneHaber.Name = "cneHaber"
        Me.cneHaber.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneHaber.Size = New System.Drawing.Size(104, 20)
        Me.cneHaber.TabIndex = 44
        Me.cneHaber.Tag = Nothing
        Me.cneHaber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneHaber.UseColumnStyles = False
        Me.cneHaber.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'cneDebe
        '
        Me.cneDebe.AcceptsTab = True
        Me.cneDebe.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneDebe.DataType = GetType(Double)
        Me.cneDebe.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneDebe.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneDebe.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneDebe.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneDebe.EditFormat.EmptyAsNull = False
        Me.cneDebe.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneDebe.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneDebe.EmptyAsNull = True
        Me.cneDebe.Enabled = False
        Me.cneDebe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cneDebe.ForeColor = System.Drawing.Color.Black
        Me.cneDebe.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneDebe.Location = New System.Drawing.Point(464, 296)
        Me.cneDebe.MaskInfo.AutoTabWhenFilled = True
        Me.cneDebe.MaxLength = 999999999
        Me.cneDebe.Name = "cneDebe"
        Me.cneDebe.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneDebe.Size = New System.Drawing.Size(104, 20)
        Me.cneDebe.TabIndex = 43
        Me.cneDebe.Tag = Nothing
        Me.cneDebe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneDebe.UseColumnStyles = False
        Me.cneDebe.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lvwCuentas
        '
        Me.lvwCuentas.BackColor = System.Drawing.SystemColors.Info
        Me.lvwCuentas.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.nScnTransaccionContableDetalleID, Me.nScnTransaccionContableID, Me.nScnCatalogoContableID, Me.sCodigoCuenta, Me.sNombreCuenta, Me.nDebito, Me.nMontoDebeC, Me.nMontoHaberC, Me.nMontoD, Me.nScnFuenteFinanciamientoID})
        Me.lvwCuentas.FullRowSelect = True
        Me.lvwCuentas.GridLines = True
        Me.lvwCuentas.Location = New System.Drawing.Point(11, 152)
        Me.lvwCuentas.MultiSelect = False
        Me.lvwCuentas.Name = "lvwCuentas"
        Me.lvwCuentas.Size = New System.Drawing.Size(663, 138)
        Me.lvwCuentas.TabIndex = 39
        Me.lvwCuentas.UseCompatibleStateImageBehavior = False
        '
        'nScnTransaccionContableDetalleID
        '
        Me.nScnTransaccionContableDetalleID.Text = "nScnTransaccionContableDetalleID"
        Me.nScnTransaccionContableDetalleID.Width = 0
        '
        'nScnTransaccionContableID
        '
        Me.nScnTransaccionContableID.Text = "nScnTransaccionContableID"
        Me.nScnTransaccionContableID.Width = 0
        '
        'nScnCatalogoContableID
        '
        Me.nScnCatalogoContableID.Text = "nScnCatalogoContableID"
        Me.nScnCatalogoContableID.Width = 0
        '
        'sCodigoCuenta
        '
        Me.sCodigoCuenta.Text = "Código Cuenta"
        Me.sCodigoCuenta.Width = 180
        '
        'sNombreCuenta
        '
        Me.sNombreCuenta.Text = "Nombre Cuenta"
        Me.sNombreCuenta.Width = 280
        '
        'nDebito
        '
        Me.nDebito.Text = "Débito"
        Me.nDebito.Width = 0
        '
        'nMontoDebeC
        '
        Me.nMontoDebeC.Text = "Debe C$"
        Me.nMontoDebeC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nMontoDebeC.Width = 100
        '
        'nMontoHaberC
        '
        Me.nMontoHaberC.Text = "Haber C$"
        Me.nMontoHaberC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nMontoHaberC.Width = 100
        '
        'nMontoD
        '
        Me.nMontoD.Text = "Monto US$"
        Me.nMontoD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nMontoD.Width = 100
        '
        'nScnFuenteFinanciamientoID
        '
        Me.nScnFuenteFinanciamientoID.Text = "nScnFuenteFinanciamientoID"
        Me.nScnFuenteFinanciamientoID.Width = 0
        '
        'frmScnEditCodificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 511)
        Me.Controls.Add(Me.grpCodificacion)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Comprobantes de Diario")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnEditCodificacion"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Registro de Codificación Contable"
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetalle.ResumeLayout(False)
        Me.grpDetalle.PerformLayout()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCodificacion.ResumeLayout(False)
        CType(Me.cneHaber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneDebe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errComprobante As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblFechaTC As System.Windows.Forms.Label
    Friend WithEvents cdeFechaTC As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaCD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cboFuente As C1.Win.C1List.C1Combo
    Friend WithEvents grpCodificacion As System.Windows.Forms.GroupBox
    Friend WithEvents lvwCuentas As System.Windows.Forms.ListView
    Friend WithEvents grpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents cneMonto As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblNombreCuenta As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents chkDebe As System.Windows.Forms.CheckBox
    Friend WithEvents lblDebito As System.Windows.Forms.Label
    Friend WithEvents cboCuenta As C1.Win.C1List.C1Combo
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents nScnTransaccionContableDetalleID As System.Windows.Forms.ColumnHeader
    Friend WithEvents nScnTransaccionContableID As System.Windows.Forms.ColumnHeader
    Friend WithEvents nScnCatalogoContableID As System.Windows.Forms.ColumnHeader
    Friend WithEvents sCodigoCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents sNombreCuenta As System.Windows.Forms.ColumnHeader
    Friend WithEvents nDebito As System.Windows.Forms.ColumnHeader
    Friend WithEvents nMontoDebeC As System.Windows.Forms.ColumnHeader
    Friend WithEvents nMontoHaberC As System.Windows.Forms.ColumnHeader
    Friend WithEvents nMontoD As System.Windows.Forms.ColumnHeader
    Friend WithEvents nScnFuenteFinanciamientoID As System.Windows.Forms.ColumnHeader
    Friend WithEvents cneHaber As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cneDebe As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cmdAgregarC As System.Windows.Forms.Button
    Friend WithEvents cmdEliminarC As System.Windows.Forms.Button
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
