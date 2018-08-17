<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditReferencia
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
        Dim Style41 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style42 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style43 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style44 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style45 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style46 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style47 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style48 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditReferencia))
        Me.errReferencia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblDocSoporte = New System.Windows.Forms.Label
        Me.cboInstitucion = New C1.Win.C1List.C1Combo
        Me.lblMontoObtenido = New System.Windows.Forms.Label
        Me.lblPlazo = New System.Windows.Forms.Label
        Me.txtPlazo = New System.Windows.Forms.TextBox
        Me.cboTipoPlazo = New C1.Win.C1List.C1Combo
        Me.grpOtroCredito = New System.Windows.Forms.GroupBox
        Me.cboTipoMoneda = New C1.Win.C1List.C1Combo
        Me.lblTipoMoneda = New System.Windows.Forms.Label
        Me.cdeFechaCancelacion = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaCancelacion = New System.Windows.Forms.Label
        Me.cdeFechaSolicitud = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaSolicitud = New System.Windows.Forms.Label
        Me.cneMontoSolicitado = New C1.Win.C1Input.C1NumericEdit
        Me.cneMontoObtenido = New C1.Win.C1Input.C1NumericEdit
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtGarantia = New System.Windows.Forms.TextBox
        CType(Me.errReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOtroCredito.SuspendLayout()
        CType(Me.cboTipoMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCancelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneMontoSolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneMontoObtenido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errReferencia
        '
        Me.errReferencia.ContainerControl = Me
        '
        'lblDocSoporte
        '
        Me.lblDocSoporte.AutoSize = True
        Me.lblDocSoporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDocSoporte.Location = New System.Drawing.Point(11, 27)
        Me.lblDocSoporte.Name = "lblDocSoporte"
        Me.lblDocSoporte.Size = New System.Drawing.Size(58, 13)
        Me.lblDocSoporte.TabIndex = 38
        Me.lblDocSoporte.Text = "Institución:"
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
        Me.cboInstitucion.DisplayMember = "sSiglas"
        Me.cboInstitucion.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboInstitucion.DropDownWidth = 310
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
        Me.cboInstitucion.Location = New System.Drawing.Point(156, 19)
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
        Me.cboInstitucion.Size = New System.Drawing.Size(276, 21)
        Me.cboInstitucion.Style = Style48
        Me.cboInstitucion.SuperBack = True
        Me.cboInstitucion.TabIndex = 0
        Me.cboInstitucion.PropBag = resources.GetString("cboInstitucion.PropBag")
        '
        'lblMontoObtenido
        '
        Me.lblMontoObtenido.AutoSize = True
        Me.lblMontoObtenido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMontoObtenido.Location = New System.Drawing.Point(11, 79)
        Me.lblMontoObtenido.Name = "lblMontoObtenido"
        Me.lblMontoObtenido.Size = New System.Drawing.Size(86, 13)
        Me.lblMontoObtenido.TabIndex = 42
        Me.lblMontoObtenido.Text = "Monto Obtenido:"
        '
        'lblPlazo
        '
        Me.lblPlazo.AutoSize = True
        Me.lblPlazo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPlazo.Location = New System.Drawing.Point(11, 103)
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Size = New System.Drawing.Size(36, 13)
        Me.lblPlazo.TabIndex = 112
        Me.lblPlazo.Text = "Plazo:"
        '
        'txtPlazo
        '
        Me.txtPlazo.Location = New System.Drawing.Point(156, 96)
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPlazo.Size = New System.Drawing.Size(38, 20)
        Me.txtPlazo.TabIndex = 3
        Me.txtPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTipoPlazo
        '
        Me.cboTipoPlazo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoPlazo.AutoCompletion = True
        Me.cboTipoPlazo.Caption = ""
        Me.cboTipoPlazo.CaptionHeight = 17
        Me.cboTipoPlazo.CaptionStyle = Style33
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
        Me.cboTipoPlazo.EvenRowStyle = Style34
        Me.cboTipoPlazo.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoPlazo.FooterStyle = Style35
        Me.cboTipoPlazo.GapHeight = 2
        Me.cboTipoPlazo.HeadingStyle = Style36
        Me.cboTipoPlazo.HighLightRowStyle = Style37
        Me.cboTipoPlazo.Images.Add(CType(resources.GetObject("cboTipoPlazo.Images"), System.Drawing.Image))
        Me.cboTipoPlazo.ItemHeight = 15
        Me.cboTipoPlazo.LimitToList = True
        Me.cboTipoPlazo.Location = New System.Drawing.Point(200, 95)
        Me.cboTipoPlazo.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoPlazo.MaxDropDownItems = CType(5, Short)
        Me.cboTipoPlazo.MaxLength = 32767
        Me.cboTipoPlazo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoPlazo.Name = "cboTipoPlazo"
        Me.cboTipoPlazo.OddRowStyle = Style38
        Me.cboTipoPlazo.PartialRightColumn = False
        Me.cboTipoPlazo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoPlazo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoPlazo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoPlazo.SelectedStyle = Style39
        Me.cboTipoPlazo.Size = New System.Drawing.Size(108, 21)
        Me.cboTipoPlazo.Style = Style40
        Me.cboTipoPlazo.SuperBack = True
        Me.cboTipoPlazo.TabIndex = 4
        Me.cboTipoPlazo.ValueMember = "StbValorCatalogoID"
        Me.cboTipoPlazo.PropBag = resources.GetString("cboTipoPlazo.PropBag")
        '
        'grpOtroCredito
        '
        Me.grpOtroCredito.Controls.Add(Me.TxtGarantia)
        Me.grpOtroCredito.Controls.Add(Me.Label1)
        Me.grpOtroCredito.Controls.Add(Me.cboTipoMoneda)
        Me.grpOtroCredito.Controls.Add(Me.lblTipoMoneda)
        Me.grpOtroCredito.Controls.Add(Me.cdeFechaCancelacion)
        Me.grpOtroCredito.Controls.Add(Me.lblFechaCancelacion)
        Me.grpOtroCredito.Controls.Add(Me.cdeFechaSolicitud)
        Me.grpOtroCredito.Controls.Add(Me.lblFechaSolicitud)
        Me.grpOtroCredito.Controls.Add(Me.cneMontoSolicitado)
        Me.grpOtroCredito.Controls.Add(Me.cboTipoPlazo)
        Me.grpOtroCredito.Controls.Add(Me.txtPlazo)
        Me.grpOtroCredito.Controls.Add(Me.lblPlazo)
        Me.grpOtroCredito.Controls.Add(Me.lblMontoObtenido)
        Me.grpOtroCredito.Controls.Add(Me.cboInstitucion)
        Me.grpOtroCredito.Controls.Add(Me.lblDocSoporte)
        Me.grpOtroCredito.Location = New System.Drawing.Point(12, 12)
        Me.grpOtroCredito.Name = "grpOtroCredito"
        Me.grpOtroCredito.Size = New System.Drawing.Size(449, 254)
        Me.grpOtroCredito.TabIndex = 0
        Me.grpOtroCredito.TabStop = False
        Me.grpOtroCredito.Text = "Datos Referencia Crediticia"
        '
        'cboTipoMoneda
        '
        Me.cboTipoMoneda.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoMoneda.AutoCompletion = True
        Me.cboTipoMoneda.Caption = ""
        Me.cboTipoMoneda.CaptionHeight = 17
        Me.cboTipoMoneda.CaptionStyle = Style25
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
        Me.cboTipoMoneda.EvenRowStyle = Style26
        Me.cboTipoMoneda.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoMoneda.FooterStyle = Style27
        Me.cboTipoMoneda.GapHeight = 2
        Me.cboTipoMoneda.HeadingStyle = Style28
        Me.cboTipoMoneda.HighLightRowStyle = Style29
        Me.cboTipoMoneda.Images.Add(CType(resources.GetObject("cboTipoMoneda.Images"), System.Drawing.Image))
        Me.cboTipoMoneda.ItemHeight = 15
        Me.cboTipoMoneda.LimitToList = True
        Me.cboTipoMoneda.Location = New System.Drawing.Point(156, 46)
        Me.cboTipoMoneda.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoMoneda.MaxDropDownItems = CType(5, Short)
        Me.cboTipoMoneda.MaxLength = 32767
        Me.cboTipoMoneda.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoMoneda.Name = "cboTipoMoneda"
        Me.cboTipoMoneda.OddRowStyle = Style30
        Me.cboTipoMoneda.PartialRightColumn = False
        Me.cboTipoMoneda.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoMoneda.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoMoneda.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoMoneda.SelectedStyle = Style31
        Me.cboTipoMoneda.Size = New System.Drawing.Size(152, 21)
        Me.cboTipoMoneda.Style = Style32
        Me.cboTipoMoneda.SuperBack = True
        Me.cboTipoMoneda.TabIndex = 1
        Me.cboTipoMoneda.ValueMember = "StbValorCatalogoID"
        Me.cboTipoMoneda.PropBag = resources.GetString("cboTipoMoneda.PropBag")
        '
        'lblTipoMoneda
        '
        Me.lblTipoMoneda.AutoSize = True
        Me.lblTipoMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoMoneda.Location = New System.Drawing.Point(11, 54)
        Me.lblTipoMoneda.Name = "lblTipoMoneda"
        Me.lblTipoMoneda.Size = New System.Drawing.Size(88, 13)
        Me.lblTipoMoneda.TabIndex = 124
        Me.lblTipoMoneda.Text = "Tipo de Moneda:"
        '
        'cdeFechaCancelacion
        '
        Me.cdeFechaCancelacion.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCancelacion.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaCancelacion.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCancelacion.Location = New System.Drawing.Point(156, 148)
        Me.cdeFechaCancelacion.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaCancelacion.MaskInfo.EmptyAsNull = True
        Me.cdeFechaCancelacion.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaCancelacion.Name = "cdeFechaCancelacion"
        Me.cdeFechaCancelacion.Size = New System.Drawing.Size(96, 20)
        Me.cdeFechaCancelacion.TabIndex = 6
        Me.cdeFechaCancelacion.Tag = Nothing
        Me.cdeFechaCancelacion.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaCancelacion
        '
        Me.lblFechaCancelacion.AutoSize = True
        Me.lblFechaCancelacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaCancelacion.Location = New System.Drawing.Point(11, 155)
        Me.lblFechaCancelacion.Name = "lblFechaCancelacion"
        Me.lblFechaCancelacion.Size = New System.Drawing.Size(117, 13)
        Me.lblFechaCancelacion.TabIndex = 117
        Me.lblFechaCancelacion.Text = "Fecha de Cancelación:"
        '
        'cdeFechaSolicitud
        '
        Me.cdeFechaSolicitud.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaSolicitud.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaSolicitud.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaSolicitud.Location = New System.Drawing.Point(156, 122)
        Me.cdeFechaSolicitud.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaSolicitud.MaskInfo.EmptyAsNull = True
        Me.cdeFechaSolicitud.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaSolicitud.Name = "cdeFechaSolicitud"
        Me.cdeFechaSolicitud.Size = New System.Drawing.Size(96, 20)
        Me.cdeFechaSolicitud.TabIndex = 5
        Me.cdeFechaSolicitud.Tag = Nothing
        Me.cdeFechaSolicitud.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaSolicitud
        '
        Me.lblFechaSolicitud.AutoSize = True
        Me.lblFechaSolicitud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaSolicitud.Location = New System.Drawing.Point(11, 129)
        Me.lblFechaSolicitud.Name = "lblFechaSolicitud"
        Me.lblFechaSolicitud.Size = New System.Drawing.Size(98, 13)
        Me.lblFechaSolicitud.TabIndex = 115
        Me.lblFechaSolicitud.Text = "Fecha de Solicitud:"
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
        Me.cneMontoSolicitado.Location = New System.Drawing.Point(156, 72)
        Me.cneMontoSolicitado.MaskInfo.AutoTabWhenFilled = True
        Me.cneMontoSolicitado.MaxLength = 999999999
        Me.cneMontoSolicitado.Name = "cneMontoSolicitado"
        Me.cneMontoSolicitado.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMontoSolicitado.Size = New System.Drawing.Size(152, 20)
        Me.cneMontoSolicitado.TabIndex = 2
        Me.cneMontoSolicitado.Tag = Nothing
        Me.cneMontoSolicitado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMontoSolicitado.UseColumnStyles = False
        Me.cneMontoSolicitado.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'cneMontoObtenido
        '
        Me.cneMontoObtenido.AcceptsTab = True
        Me.cneMontoObtenido.CustomFormat = "###,###,###,##0.00"
        Me.cneMontoObtenido.DataType = GetType(Double)
        Me.cneMontoObtenido.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.cneMontoObtenido.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoObtenido.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoObtenido.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneMontoObtenido.EditFormat.EmptyAsNull = False
        Me.cneMontoObtenido.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoObtenido.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoObtenido.EmptyAsNull = True
        Me.cneMontoObtenido.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoObtenido.Location = New System.Drawing.Point(156, 38)
        Me.cneMontoObtenido.MaskInfo.AutoTabWhenFilled = True
        Me.cneMontoObtenido.MaxLength = 999999999
        Me.cneMontoObtenido.Name = "cneMontoObtenido"
        Me.cneMontoObtenido.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMontoObtenido.Size = New System.Drawing.Size(143, 20)
        Me.cneMontoObtenido.TabIndex = 3
        Me.cneMontoObtenido.Tag = Nothing
        Me.cneMontoObtenido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMontoObtenido.UseColumnStyles = False
        Me.cneMontoObtenido.Value = 0
        Me.cneMontoObtenido.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(388, 283)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(311, 283)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(11, 180)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Garantía:"
        '
        'TxtGarantia
        '
        Me.TxtGarantia.Location = New System.Drawing.Point(156, 180)
        Me.TxtGarantia.MaxLength = 200
        Me.TxtGarantia.Multiline = True
        Me.TxtGarantia.Name = "TxtGarantia"
        Me.TxtGarantia.Size = New System.Drawing.Size(276, 56)
        Me.TxtGarantia.TabIndex = 126
        '
        'frmSclEditReferencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 320)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpOtroCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Ficha de Inscripción")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditReferencia"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Referencia Crediticia"
        CType(Me.errReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOtroCredito.ResumeLayout(False)
        Me.grpOtroCredito.PerformLayout()
        CType(Me.cboTipoMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCancelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneMontoSolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneMontoObtenido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errReferencia As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpOtroCredito As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoPlazo As C1.Win.C1List.C1Combo
    Friend WithEvents txtPlazo As System.Windows.Forms.TextBox
    Friend WithEvents lblPlazo As System.Windows.Forms.Label
    Friend WithEvents lblMontoObtenido As System.Windows.Forms.Label
    Friend WithEvents cboInstitucion As C1.Win.C1List.C1Combo
    Friend WithEvents lblDocSoporte As System.Windows.Forms.Label
    Friend WithEvents cneMontoObtenido As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cneMontoSolicitado As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cdeFechaSolicitud As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaSolicitud As System.Windows.Forms.Label
    Friend WithEvents cdeFechaCancelacion As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaCancelacion As System.Windows.Forms.Label
    Friend WithEvents cboTipoMoneda As C1.Win.C1List.C1Combo
    Friend WithEvents lblTipoMoneda As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents TxtGarantia As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
