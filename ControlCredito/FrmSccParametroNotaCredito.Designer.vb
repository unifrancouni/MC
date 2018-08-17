<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccParametroNotaCredito
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccParametroNotaCredito))
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
        Me.grpFechaNota = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboFuentes = New C1.Win.C1List.C1Combo
        Me.Label4 = New System.Windows.Forms.Label
        Me.CboEstadoNota = New C1.Win.C1List.C1Combo
        Me.lblPrograma = New System.Windows.Forms.Label
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpFiltro = New System.Windows.Forms.GroupBox
        Me.RdoAnio = New System.Windows.Forms.RadioButton
        Me.RdoFechaNota = New System.Windows.Forms.RadioButton
        Me.grpAnioAfectado = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ndAnio = New System.Windows.Forms.NumericUpDown
        Me.CboMeses = New C1.Win.C1List.C1Combo
        Me.Label5 = New System.Windows.Forms.Label
        Me.grpFechaNota.SuspendLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboFuentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboEstadoNota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFiltro.SuspendLayout()
        Me.grpAnioAfectado.SuspendLayout()
        CType(Me.ndAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboMeses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFechaNota
        '
        Me.grpFechaNota.Controls.Add(Me.Label3)
        Me.grpFechaNota.Controls.Add(Me.CdeFechaFinal)
        Me.grpFechaNota.Controls.Add(Me.cdeFechaInicial)
        Me.grpFechaNota.Controls.Add(Me.Label2)
        Me.grpFechaNota.Location = New System.Drawing.Point(12, 54)
        Me.grpFechaNota.Name = "grpFechaNota"
        Me.grpFechaNota.Size = New System.Drawing.Size(218, 88)
        Me.grpFechaNota.TabIndex = 17
        Me.grpFechaNota.TabStop = False
        Me.grpFechaNota.Text = "Fecha Notas de Debito-Credito"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(16, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Desde:"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(67, 56)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(123, 20)
        Me.CdeFechaFinal.TabIndex = 43
        Me.CdeFechaFinal.Tag = Nothing
        Me.CdeFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(67, 29)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(123, 20)
        Me.cdeFechaInicial.TabIndex = 42
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Hasta:"
        '
        'CboFuentes
        '
        Me.CboFuentes.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboFuentes.AllowSort = False
        Me.CboFuentes.AutoCompletion = True
        Me.CboFuentes.Caption = ""
        Me.CboFuentes.CaptionHeight = 17
        Me.CboFuentes.CaptionStyle = Style1
        Me.CboFuentes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboFuentes.ColumnCaptionHeight = 17
        Me.CboFuentes.ColumnFooterHeight = 17
        Me.CboFuentes.ContentHeight = 15
        Me.CboFuentes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboFuentes.DisplayMember = "sNombre"
        Me.CboFuentes.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboFuentes.DropDownWidth = 268
        Me.CboFuentes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboFuentes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFuentes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboFuentes.EditorHeight = 15
        Me.CboFuentes.EvenRowStyle = Style2
        Me.CboFuentes.ExtendRightColumn = True
        Me.CboFuentes.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboFuentes.FooterStyle = Style3
        Me.CboFuentes.GapHeight = 2
        Me.CboFuentes.HeadingStyle = Style4
        Me.CboFuentes.HighLightRowStyle = Style5
        Me.CboFuentes.Images.Add(CType(resources.GetObject("CboFuentes.Images"), System.Drawing.Image))
        Me.CboFuentes.ItemHeight = 15
        Me.CboFuentes.Location = New System.Drawing.Point(148, 175)
        Me.CboFuentes.MatchEntryTimeout = CType(2000, Long)
        Me.CboFuentes.MaxDropDownItems = CType(5, Short)
        Me.CboFuentes.MaxLength = 32767
        Me.CboFuentes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboFuentes.Name = "CboFuentes"
        Me.CboFuentes.OddRowStyle = Style6
        Me.CboFuentes.PartialRightColumn = False
        Me.CboFuentes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboFuentes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboFuentes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboFuentes.SelectedStyle = Style7
        Me.CboFuentes.Size = New System.Drawing.Size(268, 21)
        Me.CboFuentes.Style = Style8
        Me.CboFuentes.TabIndex = 131
        Me.CboFuentes.PropBag = resources.GetString("CboFuentes.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(25, 183)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Fuente Financiamiento:"
        '
        'CboEstadoNota
        '
        Me.CboEstadoNota.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboEstadoNota.AllowSort = False
        Me.CboEstadoNota.AutoCompletion = True
        Me.CboEstadoNota.Caption = ""
        Me.CboEstadoNota.CaptionHeight = 17
        Me.CboEstadoNota.CaptionStyle = Style9
        Me.CboEstadoNota.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboEstadoNota.ColumnCaptionHeight = 17
        Me.CboEstadoNota.ColumnFooterHeight = 17
        Me.CboEstadoNota.ContentHeight = 15
        Me.CboEstadoNota.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboEstadoNota.DisplayMember = "sDescripcion"
        Me.CboEstadoNota.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboEstadoNota.DropDownWidth = 268
        Me.CboEstadoNota.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboEstadoNota.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEstadoNota.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboEstadoNota.EditorHeight = 15
        Me.CboEstadoNota.EvenRowStyle = Style10
        Me.CboEstadoNota.ExtendRightColumn = True
        Me.CboEstadoNota.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboEstadoNota.FooterStyle = Style11
        Me.CboEstadoNota.GapHeight = 2
        Me.CboEstadoNota.HeadingStyle = Style12
        Me.CboEstadoNota.HighLightRowStyle = Style13
        Me.CboEstadoNota.Images.Add(CType(resources.GetObject("CboEstadoNota.Images"), System.Drawing.Image))
        Me.CboEstadoNota.ItemHeight = 15
        Me.CboEstadoNota.Location = New System.Drawing.Point(148, 148)
        Me.CboEstadoNota.MatchEntryTimeout = CType(2000, Long)
        Me.CboEstadoNota.MaxDropDownItems = CType(5, Short)
        Me.CboEstadoNota.MaxLength = 32767
        Me.CboEstadoNota.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboEstadoNota.Name = "CboEstadoNota"
        Me.CboEstadoNota.OddRowStyle = Style14
        Me.CboEstadoNota.PartialRightColumn = False
        Me.CboEstadoNota.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboEstadoNota.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboEstadoNota.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboEstadoNota.SelectedStyle = Style15
        Me.CboEstadoNota.Size = New System.Drawing.Size(268, 21)
        Me.CboEstadoNota.Style = Style16
        Me.CboEstadoNota.TabIndex = 129
        Me.CboEstadoNota.ValueMember = "nStbValorCatalogoID"
        Me.CboEstadoNota.PropBag = resources.GetString("CboEstadoNota.PropBag")
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrograma.Location = New System.Drawing.Point(24, 156)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(43, 13)
        Me.lblPrograma.TabIndex = 130
        Me.lblPrograma.Text = "Estado:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(281, 213)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 46
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(356, 213)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 47
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'grpFiltro
        '
        Me.grpFiltro.Controls.Add(Me.RdoAnio)
        Me.grpFiltro.Controls.Add(Me.RdoFechaNota)
        Me.grpFiltro.Location = New System.Drawing.Point(12, 12)
        Me.grpFiltro.Name = "grpFiltro"
        Me.grpFiltro.Size = New System.Drawing.Size(416, 36)
        Me.grpFiltro.TabIndex = 133
        Me.grpFiltro.TabStop = False
        '
        'RdoAnio
        '
        Me.RdoAnio.AutoSize = True
        Me.RdoAnio.Location = New System.Drawing.Point(237, 13)
        Me.RdoAnio.Name = "RdoAnio"
        Me.RdoAnio.Size = New System.Drawing.Size(47, 17)
        Me.RdoAnio.TabIndex = 1
        Me.RdoAnio.Text = "Año "
        Me.RdoAnio.UseVisualStyleBackColor = True
        '
        'RdoFechaNota
        '
        Me.RdoFechaNota.AutoSize = True
        Me.RdoFechaNota.Checked = True
        Me.RdoFechaNota.Location = New System.Drawing.Point(62, 13)
        Me.RdoFechaNota.Name = "RdoFechaNota"
        Me.RdoFechaNota.Size = New System.Drawing.Size(96, 17)
        Me.RdoFechaNota.TabIndex = 0
        Me.RdoFechaNota.TabStop = True
        Me.RdoFechaNota.Text = "Fecha de Nota"
        Me.RdoFechaNota.UseVisualStyleBackColor = True
        '
        'grpAnioAfectado
        '
        Me.grpAnioAfectado.Controls.Add(Me.CboMeses)
        Me.grpAnioAfectado.Controls.Add(Me.Label5)
        Me.grpAnioAfectado.Controls.Add(Me.Label1)
        Me.grpAnioAfectado.Controls.Add(Me.ndAnio)
        Me.grpAnioAfectado.Location = New System.Drawing.Point(236, 54)
        Me.grpAnioAfectado.Name = "grpAnioAfectado"
        Me.grpAnioAfectado.Size = New System.Drawing.Size(282, 88)
        Me.grpAnioAfectado.TabIndex = 134
        Me.grpAnioAfectado.TabStop = False
        Me.grpAnioAfectado.Text = "Año que Afecta"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(1, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Año"
        '
        'ndAnio
        '
        Me.ndAnio.Location = New System.Drawing.Point(89, 36)
        Me.ndAnio.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.ndAnio.Minimum = New Decimal(New Integer() {2007, 0, 0, 0})
        Me.ndAnio.Name = "ndAnio"
        Me.ndAnio.Size = New System.Drawing.Size(82, 20)
        Me.ndAnio.TabIndex = 0
        Me.ndAnio.Value = New Decimal(New Integer() {2007, 0, 0, 0})
        '
        'CboMeses
        '
        Me.CboMeses.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMeses.AutoCompletion = True
        Me.CboMeses.Caption = ""
        Me.CboMeses.CaptionHeight = 17
        Me.CboMeses.CaptionStyle = Style17
        Me.CboMeses.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMeses.ColumnCaptionHeight = 17
        Me.CboMeses.ColumnFooterHeight = 17
        Me.CboMeses.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboMeses.ContentHeight = 15
        Me.CboMeses.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.CboMeses.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMeses.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboMeses.DropDownWidth = 188
        Me.CboMeses.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMeses.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMeses.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMeses.EditorHeight = 15
        Me.CboMeses.EvenRowStyle = Style18
        Me.CboMeses.ExtendRightColumn = True
        Me.CboMeses.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboMeses.FooterStyle = Style19
        Me.CboMeses.GapHeight = 2
        Me.CboMeses.HeadingStyle = Style20
        Me.CboMeses.HighLightRowStyle = Style21
        Me.CboMeses.Images.Add(CType(resources.GetObject("CboMeses.Images"), System.Drawing.Image))
        Me.CboMeses.ItemHeight = 15
        Me.CboMeses.LimitToList = True
        Me.CboMeses.Location = New System.Drawing.Point(86, 60)
        Me.CboMeses.MatchEntryTimeout = CType(2000, Long)
        Me.CboMeses.MaxDropDownItems = CType(5, Short)
        Me.CboMeses.MaxLength = 32767
        Me.CboMeses.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMeses.Name = "CboMeses"
        Me.CboMeses.OddRowStyle = Style22
        Me.CboMeses.PartialRightColumn = False
        Me.CboMeses.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMeses.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMeses.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMeses.SelectedStyle = Style23
        Me.CboMeses.Size = New System.Drawing.Size(190, 21)
        Me.CboMeses.Style = Style24
        Me.CboMeses.SuperBack = True
        Me.CboMeses.TabIndex = 49
        Me.CboMeses.ValueMember = "StbValorCatalogoID"
        Me.CboMeses.PropBag = resources.GetString("CboMeses.PropBag")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(1, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Mes:"
        '
        'FrmSccParametroNotaCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(608, 253)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpAnioAfectado)
        Me.Controls.Add(Me.CboFuentes)
        Me.Controls.Add(Me.grpFiltro)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.CboEstadoNota)
        Me.Controls.Add(Me.lblPrograma)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpFechaNota)
        Me.Name = "FrmSccParametroNotaCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Notas de Debito-Credito"
        Me.grpFechaNota.ResumeLayout(False)
        Me.grpFechaNota.PerformLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboFuentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboEstadoNota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFiltro.ResumeLayout(False)
        Me.grpFiltro.PerformLayout()
        Me.grpAnioAfectado.ResumeLayout(False)
        Me.grpAnioAfectado.PerformLayout()
        CType(Me.ndAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboMeses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFechaNota As System.Windows.Forms.GroupBox
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CboEstadoNota As C1.Win.C1List.C1Combo
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
    Friend WithEvents CboFuentes As C1.Win.C1List.C1Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents RdoAnio As System.Windows.Forms.RadioButton
    Friend WithEvents RdoFechaNota As System.Windows.Forms.RadioButton
    Friend WithEvents grpAnioAfectado As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ndAnio As System.Windows.Forms.NumericUpDown
    Friend WithEvents CboMeses As C1.Win.C1List.C1Combo
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
