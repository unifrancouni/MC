<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditOtroCredito
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
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditOtroCredito))
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
        Dim Style49 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style50 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style51 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style52 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style53 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style54 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style55 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style56 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style57 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style58 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style59 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style60 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style61 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style62 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style63 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style64 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpOtroCredito = New System.Windows.Forms.GroupBox
        Me.cboTipoMoneda = New C1.Win.C1List.C1Combo
        Me.lblTipoMoneda = New System.Windows.Forms.Label
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.lblActivo = New System.Windows.Forms.Label
        Me.cboPeriodicidad = New C1.Win.C1List.C1Combo
        Me.lblPeriodicidad = New System.Windows.Forms.Label
        Me.cneCuota = New C1.Win.C1Input.C1NumericEdit
        Me.lblCuota = New System.Windows.Forms.Label
        Me.cneSaldo = New C1.Win.C1Input.C1NumericEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboTipoPlazo = New C1.Win.C1List.C1Combo
        Me.txtPlazo = New System.Windows.Forms.TextBox
        Me.lblPlazo = New System.Windows.Forms.Label
        Me.txtOtroPrestamista = New System.Windows.Forms.TextBox
        Me.lblOtros = New System.Windows.Forms.Label
        Me.cneMontoSolicitado = New C1.Win.C1Input.C1NumericEdit
        Me.lblMontoSolicitado = New System.Windows.Forms.Label
        Me.cboInstitucion = New C1.Win.C1List.C1Combo
        Me.lblDocSoporte = New System.Windows.Forms.Label
        Me.errOtroCredito = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpOtroCredito.SuspendLayout()
        CType(Me.cboTipoMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPeriodicidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneMontoSolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpOtroCredito
        '
        Me.grpOtroCredito.Controls.Add(Me.cboTipoMoneda)
        Me.grpOtroCredito.Controls.Add(Me.lblTipoMoneda)
        Me.grpOtroCredito.Controls.Add(Me.chkActivo)
        Me.grpOtroCredito.Controls.Add(Me.lblActivo)
        Me.grpOtroCredito.Controls.Add(Me.cboPeriodicidad)
        Me.grpOtroCredito.Controls.Add(Me.lblPeriodicidad)
        Me.grpOtroCredito.Controls.Add(Me.cneCuota)
        Me.grpOtroCredito.Controls.Add(Me.lblCuota)
        Me.grpOtroCredito.Controls.Add(Me.cneSaldo)
        Me.grpOtroCredito.Controls.Add(Me.Label1)
        Me.grpOtroCredito.Controls.Add(Me.cboTipoPlazo)
        Me.grpOtroCredito.Controls.Add(Me.txtPlazo)
        Me.grpOtroCredito.Controls.Add(Me.lblPlazo)
        Me.grpOtroCredito.Controls.Add(Me.txtOtroPrestamista)
        Me.grpOtroCredito.Controls.Add(Me.lblOtros)
        Me.grpOtroCredito.Controls.Add(Me.cneMontoSolicitado)
        Me.grpOtroCredito.Controls.Add(Me.lblMontoSolicitado)
        Me.grpOtroCredito.Controls.Add(Me.cboInstitucion)
        Me.grpOtroCredito.Controls.Add(Me.lblDocSoporte)
        Me.grpOtroCredito.Location = New System.Drawing.Point(12, 12)
        Me.grpOtroCredito.Name = "grpOtroCredito"
        Me.grpOtroCredito.Size = New System.Drawing.Size(449, 270)
        Me.grpOtroCredito.TabIndex = 0
        Me.grpOtroCredito.TabStop = False
        Me.grpOtroCredito.Text = "Datos Otro Crédito"
        '
        'cboTipoMoneda
        '
        Me.cboTipoMoneda.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoMoneda.AutoCompletion = True
        Me.cboTipoMoneda.Caption = ""
        Me.cboTipoMoneda.CaptionHeight = 17
        Me.cboTipoMoneda.CaptionStyle = Style33
        Me.cboTipoMoneda.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTipoMoneda.ColumnCaptionHeight = 17
        Me.cboTipoMoneda.ColumnFooterHeight = 17
        Me.cboTipoMoneda.ContentHeight = 15
        Me.cboTipoMoneda.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTipoMoneda.DisplayMember = "sDescripcion"
        Me.cboTipoMoneda.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTipoMoneda.DropDownWidth = 164
        Me.cboTipoMoneda.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTipoMoneda.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoMoneda.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoMoneda.EditorHeight = 15
        Me.cboTipoMoneda.EvenRowStyle = Style34
        Me.cboTipoMoneda.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoMoneda.FooterStyle = Style35
        Me.cboTipoMoneda.GapHeight = 2
        Me.cboTipoMoneda.HeadingStyle = Style36
        Me.cboTipoMoneda.HighLightRowStyle = Style37
        Me.cboTipoMoneda.Images.Add(CType(resources.GetObject("cboTipoMoneda.Images"), System.Drawing.Image))
        Me.cboTipoMoneda.ItemHeight = 15
        Me.cboTipoMoneda.LimitToList = True
        Me.cboTipoMoneda.Location = New System.Drawing.Point(156, 72)
        Me.cboTipoMoneda.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoMoneda.MaxDropDownItems = CType(5, Short)
        Me.cboTipoMoneda.MaxLength = 32767
        Me.cboTipoMoneda.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoMoneda.Name = "cboTipoMoneda"
        Me.cboTipoMoneda.OddRowStyle = Style38
        Me.cboTipoMoneda.PartialRightColumn = False
        Me.cboTipoMoneda.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoMoneda.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoMoneda.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoMoneda.SelectedStyle = Style39
        Me.cboTipoMoneda.Size = New System.Drawing.Size(156, 21)
        Me.cboTipoMoneda.Style = Style40
        Me.cboTipoMoneda.SuperBack = True
        Me.cboTipoMoneda.TabIndex = 2
        Me.cboTipoMoneda.ValueMember = "StbValorCatalogoID"
        Me.cboTipoMoneda.PropBag = resources.GetString("cboTipoMoneda.PropBag")
        '
        'lblTipoMoneda
        '
        Me.lblTipoMoneda.AutoSize = True
        Me.lblTipoMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoMoneda.Location = New System.Drawing.Point(11, 80)
        Me.lblTipoMoneda.Name = "lblTipoMoneda"
        Me.lblTipoMoneda.Size = New System.Drawing.Size(88, 13)
        Me.lblTipoMoneda.TabIndex = 122
        Me.lblTipoMoneda.Text = "Tipo de Moneda:"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkActivo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkActivo.Location = New System.Drawing.Point(156, 239)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(17, 17)
        Me.chkActivo.TabIndex = 9
        Me.chkActivo.Tag = ""
        Me.chkActivo.Text = "  "
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblActivo.Location = New System.Drawing.Point(13, 243)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(40, 13)
        Me.lblActivo.TabIndex = 120
        Me.lblActivo.Text = "Activo:"
        '
        'cboPeriodicidad
        '
        Me.cboPeriodicidad.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboPeriodicidad.AutoCompletion = True
        Me.cboPeriodicidad.Caption = ""
        Me.cboPeriodicidad.CaptionHeight = 17
        Me.cboPeriodicidad.CaptionStyle = Style41
        Me.cboPeriodicidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPeriodicidad.ColumnCaptionHeight = 17
        Me.cboPeriodicidad.ColumnFooterHeight = 17
        Me.cboPeriodicidad.ContentHeight = 15
        Me.cboPeriodicidad.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPeriodicidad.DisplayMember = "sDescripcion"
        Me.cboPeriodicidad.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboPeriodicidad.DropDownWidth = 164
        Me.cboPeriodicidad.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPeriodicidad.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriodicidad.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPeriodicidad.EditorHeight = 15
        Me.cboPeriodicidad.EvenRowStyle = Style42
        Me.cboPeriodicidad.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboPeriodicidad.FooterStyle = Style43
        Me.cboPeriodicidad.GapHeight = 2
        Me.cboPeriodicidad.HeadingStyle = Style44
        Me.cboPeriodicidad.HighLightRowStyle = Style45
        Me.cboPeriodicidad.Images.Add(CType(resources.GetObject("cboPeriodicidad.Images"), System.Drawing.Image))
        Me.cboPeriodicidad.ItemHeight = 15
        Me.cboPeriodicidad.LimitToList = True
        Me.cboPeriodicidad.Location = New System.Drawing.Point(156, 208)
        Me.cboPeriodicidad.MatchEntryTimeout = CType(2000, Long)
        Me.cboPeriodicidad.MaxDropDownItems = CType(5, Short)
        Me.cboPeriodicidad.MaxLength = 32767
        Me.cboPeriodicidad.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPeriodicidad.Name = "cboPeriodicidad"
        Me.cboPeriodicidad.OddRowStyle = Style46
        Me.cboPeriodicidad.PartialRightColumn = False
        Me.cboPeriodicidad.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPeriodicidad.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPeriodicidad.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPeriodicidad.SelectedStyle = Style47
        Me.cboPeriodicidad.Size = New System.Drawing.Size(156, 21)
        Me.cboPeriodicidad.Style = Style48
        Me.cboPeriodicidad.SuperBack = True
        Me.cboPeriodicidad.TabIndex = 8
        Me.cboPeriodicidad.ValueMember = "StbValorCatalogoID"
        Me.cboPeriodicidad.PropBag = resources.GetString("cboPeriodicidad.PropBag")
        '
        'lblPeriodicidad
        '
        Me.lblPeriodicidad.AutoSize = True
        Me.lblPeriodicidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPeriodicidad.Location = New System.Drawing.Point(13, 216)
        Me.lblPeriodicidad.Name = "lblPeriodicidad"
        Me.lblPeriodicidad.Size = New System.Drawing.Size(137, 13)
        Me.lblPeriodicidad.TabIndex = 118
        Me.lblPeriodicidad.Text = "Periodicidad con que paga:"
        '
        'cneCuota
        '
        Me.cneCuota.AcceptsTab = True
        Me.cneCuota.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneCuota.DataType = GetType(Double)
        Me.cneCuota.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneCuota.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneCuota.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneCuota.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneCuota.EditFormat.EmptyAsNull = False
        Me.cneCuota.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneCuota.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneCuota.EmptyAsNull = True
        Me.cneCuota.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneCuota.Location = New System.Drawing.Point(156, 182)
        Me.cneCuota.MaskInfo.AutoTabWhenFilled = True
        Me.cneCuota.MaxLength = 999999999
        Me.cneCuota.Name = "cneCuota"
        Me.cneCuota.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneCuota.Size = New System.Drawing.Size(156, 20)
        Me.cneCuota.TabIndex = 7
        Me.cneCuota.Tag = Nothing
        Me.cneCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneCuota.UseColumnStyles = False
        Me.cneCuota.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblCuota
        '
        Me.lblCuota.AutoSize = True
        Me.lblCuota.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCuota.Location = New System.Drawing.Point(11, 189)
        Me.lblCuota.Name = "lblCuota"
        Me.lblCuota.Size = New System.Drawing.Size(98, 13)
        Me.lblCuota.TabIndex = 116
        Me.lblCuota.Text = "Cuota que entrega:"
        '
        'cneSaldo
        '
        Me.cneSaldo.AcceptsTab = True
        Me.cneSaldo.CustomFormat = "###,###,###,##0.00"
        Me.cneSaldo.DataType = GetType(Double)
        Me.cneSaldo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.cneSaldo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneSaldo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneSaldo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneSaldo.EditFormat.EmptyAsNull = False
        Me.cneSaldo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneSaldo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneSaldo.EmptyAsNull = True
        Me.cneSaldo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneSaldo.Location = New System.Drawing.Point(156, 153)
        Me.cneSaldo.MaskInfo.AutoTabWhenFilled = True
        Me.cneSaldo.MaxLength = 999999999
        Me.cneSaldo.Name = "cneSaldo"
        Me.cneSaldo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneSaldo.Size = New System.Drawing.Size(156, 20)
        Me.cneSaldo.TabIndex = 6
        Me.cneSaldo.Tag = Nothing
        Me.cneSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneSaldo.UseColumnStyles = False
        Me.cneSaldo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Saldo:"
        '
        'cboTipoPlazo
        '
        Me.cboTipoPlazo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoPlazo.AutoCompletion = True
        Me.cboTipoPlazo.Caption = ""
        Me.cboTipoPlazo.CaptionHeight = 17
        Me.cboTipoPlazo.CaptionStyle = Style49
        Me.cboTipoPlazo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTipoPlazo.ColumnCaptionHeight = 17
        Me.cboTipoPlazo.ColumnFooterHeight = 17
        Me.cboTipoPlazo.ContentHeight = 15
        Me.cboTipoPlazo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTipoPlazo.DisplayMember = "sDescripcion"
        Me.cboTipoPlazo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTipoPlazo.DropDownWidth = 164
        Me.cboTipoPlazo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTipoPlazo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoPlazo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoPlazo.EditorHeight = 15
        Me.cboTipoPlazo.EvenRowStyle = Style50
        Me.cboTipoPlazo.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoPlazo.FooterStyle = Style51
        Me.cboTipoPlazo.GapHeight = 2
        Me.cboTipoPlazo.HeadingStyle = Style52
        Me.cboTipoPlazo.HighLightRowStyle = Style53
        Me.cboTipoPlazo.Images.Add(CType(resources.GetObject("cboTipoPlazo.Images"), System.Drawing.Image))
        Me.cboTipoPlazo.ItemHeight = 15
        Me.cboTipoPlazo.LimitToList = True
        Me.cboTipoPlazo.Location = New System.Drawing.Point(196, 125)
        Me.cboTipoPlazo.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoPlazo.MaxDropDownItems = CType(5, Short)
        Me.cboTipoPlazo.MaxLength = 32767
        Me.cboTipoPlazo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoPlazo.Name = "cboTipoPlazo"
        Me.cboTipoPlazo.OddRowStyle = Style54
        Me.cboTipoPlazo.PartialRightColumn = False
        Me.cboTipoPlazo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoPlazo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoPlazo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoPlazo.SelectedStyle = Style55
        Me.cboTipoPlazo.Size = New System.Drawing.Size(116, 21)
        Me.cboTipoPlazo.Style = Style56
        Me.cboTipoPlazo.SuperBack = True
        Me.cboTipoPlazo.TabIndex = 5
        Me.cboTipoPlazo.ValueMember = "StbValorCatalogoID"
        Me.cboTipoPlazo.PropBag = resources.GetString("cboTipoPlazo.PropBag")
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(156, 125)
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPlazo.Size = New System.Drawing.Size(38, 20)
        Me.txtPlazo.TabIndex = 4
        Me.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblPlazo
        '
        Me.lblPlazo.AutoSize = True
        Me.lblPlazo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPlazo.Location = New System.Drawing.Point(11, 133)
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Size = New System.Drawing.Size(36, 13)
        Me.lblPlazo.TabIndex = 112
        Me.lblPlazo.Text = "Plazo:"
        '
        'txtOtroPrestamista
        '
        Me.txtOtroPrestamista.Location = New System.Drawing.Point(156, 46)
        Me.txtOtroPrestamista.Name = "txtOtroPrestamista"
        Me.txtOtroPrestamista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOtroPrestamista.Size = New System.Drawing.Size(276, 20)
        Me.txtOtroPrestamista.TabIndex = 1
        '
        'lblOtros
        '
        Me.lblOtros.AutoSize = True
        Me.lblOtros.ForeColor = System.Drawing.Color.Black
        Me.lblOtros.Location = New System.Drawing.Point(11, 53)
        Me.lblOtros.Name = "lblOtros"
        Me.lblOtros.Size = New System.Drawing.Size(87, 13)
        Me.lblOtros.TabIndex = 55
        Me.lblOtros.Text = "Otro Prestamista:"
        '
        'cneMontoSolicitado
        '
        Me.cneMontoSolicitado.AcceptsTab = True
        Me.cneMontoSolicitado.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMontoSolicitado.DataType = GetType(Double)
        Me.cneMontoSolicitado.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneMontoSolicitado.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoSolicitado.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoSolicitado.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMontoSolicitado.EditFormat.EmptyAsNull = False
        Me.cneMontoSolicitado.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoSolicitado.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoSolicitado.EmptyAsNull = True
        Me.cneMontoSolicitado.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoSolicitado.Location = New System.Drawing.Point(156, 99)
        Me.cneMontoSolicitado.MaskInfo.AutoTabWhenFilled = True
        Me.cneMontoSolicitado.MaxLength = 999999999
        Me.cneMontoSolicitado.Name = "cneMontoSolicitado"
        Me.cneMontoSolicitado.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMontoSolicitado.Size = New System.Drawing.Size(156, 20)
        Me.cneMontoSolicitado.TabIndex = 3
        Me.cneMontoSolicitado.Tag = Nothing
        Me.cneMontoSolicitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMontoSolicitado.UseColumnStyles = False
        Me.cneMontoSolicitado.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblMontoSolicitado
        '
        Me.lblMontoSolicitado.AutoSize = True
        Me.lblMontoSolicitado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMontoSolicitado.Location = New System.Drawing.Point(11, 106)
        Me.lblMontoSolicitado.Name = "lblMontoSolicitado"
        Me.lblMontoSolicitado.Size = New System.Drawing.Size(89, 13)
        Me.lblMontoSolicitado.TabIndex = 42
        Me.lblMontoSolicitado.Text = "Monto Solicitado:"
        '
        'cboInstitucion
        '
        Me.cboInstitucion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboInstitucion.AutoCompletion = True
        Me.cboInstitucion.Caption = ""
        Me.cboInstitucion.CaptionHeight = 17
        Me.cboInstitucion.CaptionStyle = Style57
        Me.cboInstitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboInstitucion.ColumnCaptionHeight = 17
        Me.cboInstitucion.ColumnFooterHeight = 17
        Me.cboInstitucion.ContentHeight = 15
        Me.cboInstitucion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboInstitucion.DisplayMember = "sSiglas"
        Me.cboInstitucion.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboInstitucion.DropDownWidth = 310
        Me.cboInstitucion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboInstitucion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInstitucion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboInstitucion.EditorHeight = 15
        Me.cboInstitucion.EvenRowStyle = Style58
        Me.cboInstitucion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboInstitucion.FooterStyle = Style59
        Me.cboInstitucion.GapHeight = 2
        Me.cboInstitucion.HeadingStyle = Style60
        Me.cboInstitucion.HighLightRowStyle = Style61
        Me.cboInstitucion.Images.Add(CType(resources.GetObject("cboInstitucion.Images"), System.Drawing.Image))
        Me.cboInstitucion.ItemHeight = 15
        Me.cboInstitucion.LimitToList = True
        Me.cboInstitucion.Location = New System.Drawing.Point(156, 19)
        Me.cboInstitucion.MatchEntryTimeout = CType(2000, Long)
        Me.cboInstitucion.MaxDropDownItems = CType(5, Short)
        Me.cboInstitucion.MaxLength = 32767
        Me.cboInstitucion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboInstitucion.Name = "cboInstitucion"
        Me.cboInstitucion.OddRowStyle = Style62
        Me.cboInstitucion.PartialRightColumn = False
        Me.cboInstitucion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboInstitucion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboInstitucion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboInstitucion.SelectedStyle = Style63
        Me.cboInstitucion.Size = New System.Drawing.Size(276, 21)
        Me.cboInstitucion.Style = Style64
        Me.cboInstitucion.SuperBack = True
        Me.cboInstitucion.TabIndex = 0
        Me.cboInstitucion.PropBag = resources.GetString("cboInstitucion.PropBag")
        '
        'lblDocSoporte
        '
        Me.lblDocSoporte.AutoSize = True
        Me.lblDocSoporte.ForeColor = System.Drawing.Color.Black
        Me.lblDocSoporte.Location = New System.Drawing.Point(11, 27)
        Me.lblDocSoporte.Name = "lblDocSoporte"
        Me.lblDocSoporte.Size = New System.Drawing.Size(58, 13)
        Me.lblDocSoporte.TabIndex = 38
        Me.lblDocSoporte.Text = "Institución:"
        '
        'errOtroCredito
        '
        Me.errOtroCredito.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(311, 288)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(388, 288)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSclEditOtroCredito
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(475, 325)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpOtroCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Ficha de Inscripción")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditOtroCredito"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Otro Crédito"
        Me.grpOtroCredito.ResumeLayout(False)
        Me.grpOtroCredito.PerformLayout()
        CType(Me.cboTipoMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPeriodicidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneCuota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneMontoSolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpOtroCredito As System.Windows.Forms.GroupBox
    Friend WithEvents cboInstitucion As C1.Win.C1List.C1Combo
    Friend WithEvents lblDocSoporte As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errOtroCredito As System.Windows.Forms.ErrorProvider
    Friend WithEvents cneMontoSolicitado As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblMontoSolicitado As System.Windows.Forms.Label
    Friend WithEvents txtOtroPrestamista As System.Windows.Forms.TextBox
    Friend WithEvents lblOtros As System.Windows.Forms.Label
    Friend WithEvents cneSaldo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoPlazo As C1.Win.C1List.C1Combo
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents lblPlazo As System.Windows.Forms.Label
    Friend WithEvents cboPeriodicidad As C1.Win.C1List.C1Combo
    Friend WithEvents lblPeriodicidad As System.Windows.Forms.Label
    Friend WithEvents cneCuota As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblCuota As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents cboTipoMoneda As C1.Win.C1List.C1Combo
    Friend WithEvents lblTipoMoneda As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
