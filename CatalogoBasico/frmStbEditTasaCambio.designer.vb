<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbEditTasaCambio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbEditTasaCambio))
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
        Me.GrboxDatosGenerales = New System.Windows.Forms.GroupBox
        Me.CboMonedaBase = New C1.Win.C1List.C1Combo
        Me.cboMonedaCambio = New C1.Win.C1List.C1Combo
        Me.LblMonedaBase = New System.Windows.Forms.Label
        Me.lblMonedaCambio = New System.Windows.Forms.Label
        Me.LblFechaFin = New System.Windows.Forms.Label
        Me.cdeFechaFin = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicio = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaInicio = New System.Windows.Forms.Label
        Me.GrpDatosaGrabar = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cneMontoTasaCambio = New C1.Win.C1Input.C1NumericEdit
        Me.ChKActivo = New System.Windows.Forms.CheckBox
        Me.CdeFechaGrabar = New C1.Win.C1Input.C1DateEdit
        Me.LblOcupada = New System.Windows.Forms.Label
        Me.ChKOcupado = New System.Windows.Forms.CheckBox
        Me.LblMonto = New System.Windows.Forms.Label
        Me.LblFechaGrabar = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.errTasaCambio = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.GrboxDatosGenerales.SuspendLayout()
        CType(Me.CboMonedaBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMonedaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDatosaGrabar.SuspendLayout()
        CType(Me.cneMontoTasaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CdeFechaGrabar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.errTasaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrboxDatosGenerales
        '
        Me.GrboxDatosGenerales.Controls.Add(Me.CboMonedaBase)
        Me.GrboxDatosGenerales.Controls.Add(Me.cboMonedaCambio)
        Me.GrboxDatosGenerales.Controls.Add(Me.LblMonedaBase)
        Me.GrboxDatosGenerales.Controls.Add(Me.lblMonedaCambio)
        Me.GrboxDatosGenerales.Location = New System.Drawing.Point(12, 12)
        Me.GrboxDatosGenerales.Name = "GrboxDatosGenerales"
        Me.GrboxDatosGenerales.Size = New System.Drawing.Size(224, 86)
        Me.GrboxDatosGenerales.TabIndex = 6
        Me.GrboxDatosGenerales.TabStop = False
        Me.GrboxDatosGenerales.Text = "Moneda:"
        '
        'CboMonedaBase
        '
        Me.CboMonedaBase.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMonedaBase.AutoCompletion = True
        Me.CboMonedaBase.Caption = ""
        Me.CboMonedaBase.CaptionHeight = 17
        Me.CboMonedaBase.CaptionStyle = Style17
        Me.CboMonedaBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMonedaBase.ColumnCaptionHeight = 17
        Me.CboMonedaBase.ColumnFooterHeight = 17
        Me.CboMonedaBase.ContentHeight = 15
        Me.CboMonedaBase.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMonedaBase.DisplayMember = "sDescripcion"
        Me.CboMonedaBase.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboMonedaBase.DropDownWidth = 200
        Me.CboMonedaBase.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMonedaBase.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMonedaBase.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMonedaBase.EditorHeight = 15
        Me.CboMonedaBase.EvenRowStyle = Style18
        Me.CboMonedaBase.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboMonedaBase.FooterStyle = Style19
        Me.CboMonedaBase.GapHeight = 2
        Me.CboMonedaBase.HeadingStyle = Style20
        Me.CboMonedaBase.HighLightRowStyle = Style21
        Me.CboMonedaBase.Images.Add(CType(resources.GetObject("CboMonedaBase.Images"), System.Drawing.Image))
        Me.CboMonedaBase.ItemHeight = 15
        Me.CboMonedaBase.LimitToList = True
        Me.CboMonedaBase.Location = New System.Drawing.Point(88, 19)
        Me.CboMonedaBase.MatchEntryTimeout = CType(2000, Long)
        Me.CboMonedaBase.MaxDropDownItems = CType(5, Short)
        Me.CboMonedaBase.MaxLength = 32767
        Me.CboMonedaBase.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMonedaBase.Name = "CboMonedaBase"
        Me.CboMonedaBase.OddRowStyle = Style22
        Me.CboMonedaBase.PartialRightColumn = False
        Me.CboMonedaBase.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMonedaBase.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMonedaBase.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMonedaBase.SelectedStyle = Style23
        Me.CboMonedaBase.Size = New System.Drawing.Size(122, 21)
        Me.CboMonedaBase.Style = Style24
        Me.CboMonedaBase.SuperBack = True
        Me.CboMonedaBase.TabIndex = 1
        Me.CboMonedaBase.ValueMember = "nStbMonedaID"
        Me.CboMonedaBase.PropBag = resources.GetString("CboMonedaBase.PropBag")
        '
        'cboMonedaCambio
        '
        Me.cboMonedaCambio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMonedaCambio.AutoCompletion = True
        Me.cboMonedaCambio.Caption = ""
        Me.cboMonedaCambio.CaptionHeight = 17
        Me.cboMonedaCambio.CaptionStyle = Style25
        Me.cboMonedaCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMonedaCambio.ColumnCaptionHeight = 17
        Me.cboMonedaCambio.ColumnFooterHeight = 17
        Me.cboMonedaCambio.ContentHeight = 15
        Me.cboMonedaCambio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMonedaCambio.DisplayMember = "sDescripcion"
        Me.cboMonedaCambio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMonedaCambio.DropDownWidth = 200
        Me.cboMonedaCambio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMonedaCambio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonedaCambio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMonedaCambio.EditorHeight = 15
        Me.cboMonedaCambio.EvenRowStyle = Style26
        Me.cboMonedaCambio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMonedaCambio.FooterStyle = Style27
        Me.cboMonedaCambio.GapHeight = 2
        Me.cboMonedaCambio.HeadingStyle = Style28
        Me.cboMonedaCambio.HighLightRowStyle = Style29
        Me.cboMonedaCambio.Images.Add(CType(resources.GetObject("cboMonedaCambio.Images"), System.Drawing.Image))
        Me.cboMonedaCambio.ItemHeight = 15
        Me.cboMonedaCambio.LimitToList = True
        Me.cboMonedaCambio.Location = New System.Drawing.Point(88, 54)
        Me.cboMonedaCambio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMonedaCambio.MaxDropDownItems = CType(5, Short)
        Me.cboMonedaCambio.MaxLength = 32767
        Me.cboMonedaCambio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMonedaCambio.Name = "cboMonedaCambio"
        Me.cboMonedaCambio.OddRowStyle = Style30
        Me.cboMonedaCambio.PartialRightColumn = False
        Me.cboMonedaCambio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMonedaCambio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMonedaCambio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMonedaCambio.SelectedStyle = Style31
        Me.cboMonedaCambio.Size = New System.Drawing.Size(122, 21)
        Me.cboMonedaCambio.Style = Style32
        Me.cboMonedaCambio.SuperBack = True
        Me.cboMonedaCambio.TabIndex = 2
        Me.cboMonedaCambio.ValueMember = "nStbMonedaID"
        Me.cboMonedaCambio.PropBag = resources.GetString("cboMonedaCambio.PropBag")
        '
        'LblMonedaBase
        '
        Me.LblMonedaBase.AutoSize = True
        Me.LblMonedaBase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblMonedaBase.Location = New System.Drawing.Point(6, 20)
        Me.LblMonedaBase.Name = "LblMonedaBase"
        Me.LblMonedaBase.Size = New System.Drawing.Size(34, 13)
        Me.LblMonedaBase.TabIndex = 13
        Me.LblMonedaBase.Text = "Base:"
        '
        'lblMonedaCambio
        '
        Me.lblMonedaCambio.AutoSize = True
        Me.lblMonedaCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonedaCambio.Location = New System.Drawing.Point(6, 54)
        Me.lblMonedaCambio.Name = "lblMonedaCambio"
        Me.lblMonedaCambio.Size = New System.Drawing.Size(45, 13)
        Me.lblMonedaCambio.TabIndex = 12
        Me.lblMonedaCambio.Text = "Cambio:"
        '
        'LblFechaFin
        '
        Me.LblFechaFin.AutoSize = True
        Me.LblFechaFin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblFechaFin.Location = New System.Drawing.Point(5, 54)
        Me.LblFechaFin.Name = "LblFechaFin"
        Me.LblFechaFin.Size = New System.Drawing.Size(57, 13)
        Me.LblFechaFin.TabIndex = 11
        Me.LblFechaFin.Text = "Fecha Fin:"
        '
        'cdeFechaFin
        '
        Me.cdeFechaFin.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaFin.Location = New System.Drawing.Point(75, 54)
        Me.cdeFechaFin.Name = "cdeFechaFin"
        Me.cdeFechaFin.Size = New System.Drawing.Size(122, 20)
        Me.cdeFechaFin.TabIndex = 4
        Me.cdeFechaFin.Tag = Nothing
        Me.cdeFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaInicio
        '
        Me.cdeFechaInicio.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicio.Location = New System.Drawing.Point(75, 20)
        Me.cdeFechaInicio.Name = "cdeFechaInicio"
        Me.cdeFechaInicio.Size = New System.Drawing.Size(122, 20)
        Me.cdeFechaInicio.TabIndex = 3
        Me.cdeFechaInicio.Tag = Nothing
        Me.cdeFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaInicio.Location = New System.Drawing.Point(6, 23)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaInicio.TabIndex = 7
        Me.lblFechaInicio.Text = "Fecha Inicio:"
        '
        'GrpDatosaGrabar
        '
        Me.GrpDatosaGrabar.Controls.Add(Me.Label1)
        Me.GrpDatosaGrabar.Controls.Add(Me.cneMontoTasaCambio)
        Me.GrpDatosaGrabar.Controls.Add(Me.ChKActivo)
        Me.GrpDatosaGrabar.Controls.Add(Me.CdeFechaGrabar)
        Me.GrpDatosaGrabar.Controls.Add(Me.LblOcupada)
        Me.GrpDatosaGrabar.Controls.Add(Me.ChKOcupado)
        Me.GrpDatosaGrabar.Controls.Add(Me.LblMonto)
        Me.GrpDatosaGrabar.Controls.Add(Me.LblFechaGrabar)
        Me.GrpDatosaGrabar.Location = New System.Drawing.Point(12, 104)
        Me.GrpDatosaGrabar.Name = "GrpDatosaGrabar"
        Me.GrpDatosaGrabar.Size = New System.Drawing.Size(451, 86)
        Me.GrpDatosaGrabar.TabIndex = 8
        Me.GrpDatosaGrabar.TabStop = False
        Me.GrpDatosaGrabar.Text = "Tasa de Cambio:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(242, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Activo :"
        '
        'cneMontoTasaCambio
        '
        Me.cneMontoTasaCambio.DisplayFormat.CustomFormat = "#,##0.0000"
        Me.cneMontoTasaCambio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoTasaCambio.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoTasaCambio.EditFormat.CustomFormat = "#,##0.0000"
        Me.cneMontoTasaCambio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoTasaCambio.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoTasaCambio.Location = New System.Drawing.Point(311, 25)
        Me.cneMontoTasaCambio.Name = "cneMontoTasaCambio"
        Me.cneMontoTasaCambio.Size = New System.Drawing.Size(116, 20)
        Me.cneMontoTasaCambio.TabIndex = 9
        Me.cneMontoTasaCambio.Tag = Nothing
        Me.cneMontoTasaCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMontoTasaCambio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'ChKActivo
        '
        Me.ChKActivo.AutoSize = True
        Me.ChKActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChKActivo.Location = New System.Drawing.Point(311, 60)
        Me.ChKActivo.Name = "ChKActivo"
        Me.ChKActivo.Size = New System.Drawing.Size(17, 17)
        Me.ChKActivo.TabIndex = 11
        Me.ChKActivo.Text = "  "
        Me.ChKActivo.UseVisualStyleBackColor = True
        '
        'CdeFechaGrabar
        '
        Me.CdeFechaGrabar.BackColor = System.Drawing.SystemColors.Info
        Me.CdeFechaGrabar.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaGrabar.Location = New System.Drawing.Point(87, 29)
        Me.CdeFechaGrabar.Name = "CdeFechaGrabar"
        Me.CdeFechaGrabar.Size = New System.Drawing.Size(122, 20)
        Me.CdeFechaGrabar.TabIndex = 5
        Me.CdeFechaGrabar.Tag = Nothing
        Me.CdeFechaGrabar.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'LblOcupada
        '
        Me.LblOcupada.AutoSize = True
        Me.LblOcupada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblOcupada.Location = New System.Drawing.Point(6, 60)
        Me.LblOcupada.Name = "LblOcupada"
        Me.LblOcupada.Size = New System.Drawing.Size(57, 13)
        Me.LblOcupada.TabIndex = 17
        Me.LblOcupada.Text = "Ocupado :"
        '
        'ChKOcupado
        '
        Me.ChKOcupado.AutoSize = True
        Me.ChKOcupado.Location = New System.Drawing.Point(87, 60)
        Me.ChKOcupado.Name = "ChKOcupado"
        Me.ChKOcupado.Size = New System.Drawing.Size(15, 14)
        Me.ChKOcupado.TabIndex = 10
        Me.ChKOcupado.UseVisualStyleBackColor = True
        '
        'LblMonto
        '
        Me.LblMonto.AutoSize = True
        Me.LblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblMonto.Location = New System.Drawing.Point(240, 28)
        Me.LblMonto.Name = "LblMonto"
        Me.LblMonto.Size = New System.Drawing.Size(43, 13)
        Me.LblMonto.TabIndex = 16
        Me.LblMonto.Text = "Monto :"
        '
        'LblFechaGrabar
        '
        Me.LblFechaGrabar.AutoSize = True
        Me.LblFechaGrabar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblFechaGrabar.Location = New System.Drawing.Point(8, 29)
        Me.LblFechaGrabar.Name = "LblFechaGrabar"
        Me.LblFechaGrabar.Size = New System.Drawing.Size(43, 13)
        Me.LblFechaGrabar.TabIndex = 16
        Me.LblFechaGrabar.Text = "Fecha :"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(392, 196)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 25)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "&Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(315, 196)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 12
        Me.CmdAceptar.Text = "&Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cdeFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFechaInicio)
        Me.GroupBox1.Controls.Add(Me.LblFechaFin)
        Me.GroupBox1.Controls.Add(Me.cdeFechaFin)
        Me.GroupBox1.Location = New System.Drawing.Point(248, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(215, 86)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Período"
        '
        'errTasaCambio
        '
        Me.errTasaCambio.ContainerControl = Me
        '
        'frmStbEditTasaCambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 234)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.GrpDatosaGrabar)
        Me.Controls.Add(Me.GrboxDatosGenerales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Tasas de Cambio")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStbEditTasaCambio"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.GrboxDatosGenerales.ResumeLayout(False)
        Me.GrboxDatosGenerales.PerformLayout()
        CType(Me.CboMonedaBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMonedaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDatosaGrabar.ResumeLayout(False)
        Me.GrpDatosaGrabar.PerformLayout()
        CType(Me.cneMontoTasaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CdeFechaGrabar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.errTasaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrboxDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaFin As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicio As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents LblFechaFin As System.Windows.Forms.Label
    Friend WithEvents LblMonedaBase As System.Windows.Forms.Label
    Friend WithEvents lblMonedaCambio As System.Windows.Forms.Label
    Friend WithEvents CboMonedaBase As C1.Win.C1List.C1Combo
    Friend WithEvents cboMonedaCambio As C1.Win.C1List.C1Combo
    Friend WithEvents GrpDatosaGrabar As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents LblFechaGrabar As System.Windows.Forms.Label
    Friend WithEvents LblMonto As System.Windows.Forms.Label
    Friend WithEvents CdeFechaGrabar As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cneMontoTasaCambio As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ChKOcupado As System.Windows.Forms.CheckBox
    Friend WithEvents LblOcupada As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChKActivo As System.Windows.Forms.CheckBox
    Friend WithEvents errTasaCambio As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider

End Class
