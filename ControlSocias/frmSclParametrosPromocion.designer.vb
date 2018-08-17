<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclParametrosPromocion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclParametrosPromocion))
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
        Me.cboMunicipio = New C1.Win.C1List.C1Combo
        Me.CboDepartamento = New C1.Win.C1List.C1Combo
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cboDistrito = New C1.Win.C1List.C1Combo
        Me.lblDistrito = New System.Windows.Forms.Label
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblMunicipio = New System.Windows.Forms.Label
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.grpTipoRpt = New System.Windows.Forms.GroupBox
        Me.RadConsolidadoDpto = New System.Windows.Forms.RadioButton
        Me.RadConsolidado = New System.Windows.Forms.RadioButton
        Me.radDetalle = New System.Windows.Forms.RadioButton
        Me.cboTecnico = New C1.Win.C1List.C1Combo
        Me.lblTecnico = New System.Windows.Forms.Label
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaHasta = New System.Windows.Forms.Label
        Me.lblFechaDesde = New System.Windows.Forms.Label
        Me.lblDepartamento = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        Me.grpTipoRpt.SuspendLayout()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboMunicipio
        '
        Me.cboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMunicipio.AllowSort = False
        Me.cboMunicipio.AutoCompletion = True
        Me.cboMunicipio.Caption = ""
        Me.cboMunicipio.CaptionHeight = 17
        Me.cboMunicipio.CaptionStyle = Style1
        Me.cboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMunicipio.ColumnCaptionHeight = 17
        Me.cboMunicipio.ColumnFooterHeight = 17
        Me.cboMunicipio.ContentHeight = 15
        Me.cboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMunicipio.DisplayMember = "Descripcion"
        Me.cboMunicipio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMunicipio.DropDownWidth = 250
        Me.cboMunicipio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMunicipio.EditorHeight = 15
        Me.cboMunicipio.EvenRowStyle = Style2
        Me.cboMunicipio.ExtendRightColumn = True
        Me.cboMunicipio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMunicipio.FooterStyle = Style3
        Me.cboMunicipio.GapHeight = 2
        Me.cboMunicipio.HeadingStyle = Style4
        Me.cboMunicipio.HighLightRowStyle = Style5
        Me.cboMunicipio.Images.Add(CType(resources.GetObject("cboMunicipio.Images"), System.Drawing.Image))
        Me.cboMunicipio.ItemHeight = 15
        Me.cboMunicipio.Location = New System.Drawing.Point(111, 63)
        Me.cboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.cboMunicipio.MaxLength = 32767
        Me.cboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.OddRowStyle = Style6
        Me.cboMunicipio.PartialRightColumn = False
        Me.cboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMunicipio.SelectedStyle = Style7
        Me.cboMunicipio.Size = New System.Drawing.Size(241, 21)
        Me.cboMunicipio.Style = Style8
        Me.cboMunicipio.TabIndex = 1
        Me.cboMunicipio.PropBag = resources.GetString("cboMunicipio.PropBag")
        '
        'CboDepartamento
        '
        Me.CboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamento.AllowSort = False
        Me.CboDepartamento.AutoCompletion = True
        Me.CboDepartamento.Caption = ""
        Me.CboDepartamento.CaptionHeight = 17
        Me.CboDepartamento.CaptionStyle = Style9
        Me.CboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamento.ColumnCaptionHeight = 17
        Me.CboDepartamento.ColumnFooterHeight = 17
        Me.CboDepartamento.ContentHeight = 15
        Me.CboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamento.DisplayMember = "Descripcion"
        Me.CboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboDepartamento.DropDownWidth = 250
        Me.CboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamento.EditorHeight = 15
        Me.CboDepartamento.EvenRowStyle = Style10
        Me.CboDepartamento.ExtendRightColumn = True
        Me.CboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboDepartamento.FooterStyle = Style11
        Me.CboDepartamento.GapHeight = 2
        Me.CboDepartamento.HeadingStyle = Style12
        Me.CboDepartamento.HighLightRowStyle = Style13
        Me.CboDepartamento.Images.Add(CType(resources.GetObject("CboDepartamento.Images"), System.Drawing.Image))
        Me.CboDepartamento.ItemHeight = 15
        Me.CboDepartamento.Location = New System.Drawing.Point(111, 30)
        Me.CboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamento.MaxLength = 32767
        Me.CboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.OddRowStyle = Style14
        Me.CboDepartamento.PartialRightColumn = False
        Me.CboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamento.SelectedStyle = Style15
        Me.CboDepartamento.Size = New System.Drawing.Size(241, 21)
        Me.CboDepartamento.Style = Style16
        Me.CboDepartamento.TabIndex = 0
        Me.CboDepartamento.PropBag = resources.GetString("CboDepartamento.PropBag")
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(250, 244)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 0
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(325, 244)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cboDistrito
        '
        Me.cboDistrito.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDistrito.AllowSort = False
        Me.cboDistrito.AutoCompletion = True
        Me.cboDistrito.Caption = ""
        Me.cboDistrito.CaptionHeight = 17
        Me.cboDistrito.CaptionStyle = Style17
        Me.cboDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDistrito.ColumnCaptionHeight = 17
        Me.cboDistrito.ColumnFooterHeight = 17
        Me.cboDistrito.ContentHeight = 15
        Me.cboDistrito.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDistrito.DisplayMember = "Descripcion"
        Me.cboDistrito.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDistrito.DropDownWidth = 250
        Me.cboDistrito.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDistrito.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrito.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDistrito.EditorHeight = 15
        Me.cboDistrito.EvenRowStyle = Style18
        Me.cboDistrito.ExtendRightColumn = True
        Me.cboDistrito.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDistrito.FooterStyle = Style19
        Me.cboDistrito.GapHeight = 2
        Me.cboDistrito.HeadingStyle = Style20
        Me.cboDistrito.HighLightRowStyle = Style21
        Me.cboDistrito.Images.Add(CType(resources.GetObject("cboDistrito.Images"), System.Drawing.Image))
        Me.cboDistrito.ItemHeight = 15
        Me.cboDistrito.Location = New System.Drawing.Point(111, 92)
        Me.cboDistrito.MatchEntryTimeout = CType(2000, Long)
        Me.cboDistrito.MaxDropDownItems = CType(5, Short)
        Me.cboDistrito.MaxLength = 32767
        Me.cboDistrito.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.OddRowStyle = Style22
        Me.cboDistrito.PartialRightColumn = False
        Me.cboDistrito.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDistrito.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDistrito.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDistrito.SelectedStyle = Style23
        Me.cboDistrito.Size = New System.Drawing.Size(241, 21)
        Me.cboDistrito.Style = Style24
        Me.cboDistrito.TabIndex = 2
        Me.cboDistrito.PropBag = resources.GetString("cboDistrito.PropBag")
        '
        'lblDistrito
        '
        Me.lblDistrito.AutoSize = True
        Me.lblDistrito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDistrito.Location = New System.Drawing.Point(16, 100)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(42, 13)
        Me.lblDistrito.TabIndex = 36
        Me.lblDistrito.Text = "Distrito:"
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(16, 63)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(55, 13)
        Me.lblMunicipio.TabIndex = 34
        Me.lblMunicipio.Text = "Municipio:"
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.grpTipoRpt)
        Me.grpdatos.Controls.Add(Me.cboTecnico)
        Me.grpdatos.Controls.Add(Me.lblTecnico)
        Me.grpdatos.Controls.Add(Me.CdeFechaFinal)
        Me.grpdatos.Controls.Add(Me.cdeFechaInicial)
        Me.grpdatos.Controls.Add(Me.lblFechaHasta)
        Me.grpdatos.Controls.Add(Me.lblFechaDesde)
        Me.grpdatos.Controls.Add(Me.cboDistrito)
        Me.grpdatos.Controls.Add(Me.cboMunicipio)
        Me.grpdatos.Controls.Add(Me.CboDepartamento)
        Me.grpdatos.Controls.Add(Me.lblDistrito)
        Me.grpdatos.Controls.Add(Me.lblMunicipio)
        Me.grpdatos.Controls.Add(Me.lblDepartamento)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(384, 226)
        Me.grpdatos.TabIndex = 13
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por:  "
        '
        'grpTipoRpt
        '
        Me.grpTipoRpt.Controls.Add(Me.RadConsolidadoDpto)
        Me.grpTipoRpt.Controls.Add(Me.RadConsolidado)
        Me.grpTipoRpt.Controls.Add(Me.radDetalle)
        Me.grpTipoRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoRpt.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpTipoRpt.Location = New System.Drawing.Point(206, 156)
        Me.grpTipoRpt.Name = "grpTipoRpt"
        Me.grpTipoRpt.Size = New System.Drawing.Size(172, 64)
        Me.grpTipoRpt.TabIndex = 68
        Me.grpTipoRpt.TabStop = False
        Me.grpTipoRpt.Text = "Tipo de Reporte: "
        '
        'RadConsolidadoDpto
        '
        Me.RadConsolidadoDpto.AutoSize = True
        Me.RadConsolidadoDpto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadConsolidadoDpto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadConsolidadoDpto.Location = New System.Drawing.Point(9, 39)
        Me.RadConsolidadoDpto.Name = "RadConsolidadoDpto"
        Me.RadConsolidadoDpto.Size = New System.Drawing.Size(158, 17)
        Me.RadConsolidadoDpto.TabIndex = 6
        Me.RadConsolidadoDpto.Text = "Consolidado Departamentos"
        Me.RadConsolidadoDpto.UseVisualStyleBackColor = True
        '
        'RadConsolidado
        '
        Me.RadConsolidado.AutoSize = True
        Me.RadConsolidado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadConsolidado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadConsolidado.Location = New System.Drawing.Point(73, 19)
        Me.RadConsolidado.Name = "RadConsolidado"
        Me.RadConsolidado.Size = New System.Drawing.Size(83, 17)
        Me.RadConsolidado.TabIndex = 5
        Me.RadConsolidado.Text = "Consolidado"
        Me.RadConsolidado.UseVisualStyleBackColor = True
        '
        'radDetalle
        '
        Me.radDetalle.AutoSize = True
        Me.radDetalle.Checked = True
        Me.radDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radDetalle.Location = New System.Drawing.Point(9, 19)
        Me.radDetalle.Name = "radDetalle"
        Me.radDetalle.Size = New System.Drawing.Size(58, 17)
        Me.radDetalle.TabIndex = 4
        Me.radDetalle.TabStop = True
        Me.radDetalle.Text = "Detalle"
        Me.radDetalle.UseVisualStyleBackColor = True
        '
        'cboTecnico
        '
        Me.cboTecnico.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTecnico.AutoCompletion = True
        Me.cboTecnico.Caption = ""
        Me.cboTecnico.CaptionHeight = 17
        Me.cboTecnico.CaptionStyle = Style25
        Me.cboTecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTecnico.ColumnCaptionHeight = 17
        Me.cboTecnico.ColumnFooterHeight = 17
        Me.cboTecnico.ContentHeight = 15
        Me.cboTecnico.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTecnico.DisplayMember = "sNombreEmpleado"
        Me.cboTecnico.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTecnico.DropDownWidth = 250
        Me.cboTecnico.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTecnico.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTecnico.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTecnico.EditorHeight = 15
        Me.cboTecnico.EvenRowStyle = Style26
        Me.cboTecnico.ExtendRightColumn = True
        Me.cboTecnico.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTecnico.FooterStyle = Style27
        Me.cboTecnico.GapHeight = 2
        Me.cboTecnico.HeadingStyle = Style28
        Me.cboTecnico.HighLightRowStyle = Style29
        Me.cboTecnico.Images.Add(CType(resources.GetObject("cboTecnico.Images"), System.Drawing.Image))
        Me.cboTecnico.ItemHeight = 15
        Me.cboTecnico.LimitToList = True
        Me.cboTecnico.Location = New System.Drawing.Point(111, 129)
        Me.cboTecnico.MatchEntryTimeout = CType(2000, Long)
        Me.cboTecnico.MaxDropDownItems = CType(5, Short)
        Me.cboTecnico.MaxLength = 32767
        Me.cboTecnico.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTecnico.Name = "cboTecnico"
        Me.cboTecnico.OddRowStyle = Style30
        Me.cboTecnico.PartialRightColumn = False
        Me.cboTecnico.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTecnico.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTecnico.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTecnico.SelectedStyle = Style31
        Me.cboTecnico.Size = New System.Drawing.Size(241, 21)
        Me.cboTecnico.Style = Style32
        Me.cboTecnico.SuperBack = True
        Me.cboTecnico.TabIndex = 3
        Me.cboTecnico.ValueMember = "nSrhEmpleadoID"
        Me.cboTecnico.PropBag = resources.GetString("cboTecnico.PropBag")
        '
        'lblTecnico
        '
        Me.lblTecnico.AutoSize = True
        Me.lblTecnico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTecnico.Location = New System.Drawing.Point(16, 129)
        Me.lblTecnico.Name = "lblTecnico"
        Me.lblTecnico.Size = New System.Drawing.Size(97, 13)
        Me.lblTecnico.TabIndex = 67
        Me.lblTecnico.Text = "Técnico Programa:"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(111, 194)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(92, 20)
        Me.CdeFechaFinal.TabIndex = 5
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
        Me.cdeFechaInicial.Location = New System.Drawing.Point(111, 160)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(92, 20)
        Me.cdeFechaInicial.TabIndex = 4
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaHasta.Location = New System.Drawing.Point(19, 197)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(71, 13)
        Me.lblFechaHasta.TabIndex = 55
        Me.lblFechaHasta.Text = "Fecha Hasta:"
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaDesde.Location = New System.Drawing.Point(16, 163)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaDesde.TabIndex = 54
        Me.lblFechaDesde.Text = "Fecha Desde:"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(16, 30)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 7
        Me.lblDepartamento.Text = "Departamento:"
        '
        'frmSclParametrosPromocion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 278)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpdatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclParametrosPromocion"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Parámetros Listado"
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        Me.grpTipoRpt.ResumeLayout(False)
        Me.grpTipoRpt.PerformLayout()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents CboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cboDistrito As C1.Win.C1List.C1Combo
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents lblTecnico As System.Windows.Forms.Label
    Friend WithEvents cboTecnico As C1.Win.C1List.C1Combo
    Friend WithEvents grpTipoRpt As System.Windows.Forms.GroupBox
    Friend WithEvents RadConsolidado As System.Windows.Forms.RadioButton
    Friend WithEvents radDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents RadConsolidadoDpto As System.Windows.Forms.RadioButton
End Class
