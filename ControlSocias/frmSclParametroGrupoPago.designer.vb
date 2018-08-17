<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclParametroGrupoPago
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
        Me.components = New System.ComponentModel.Container()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclParametroGrupoPago))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpdatos = New System.Windows.Forms.GroupBox()
        Me.dFechaFinal = New C1.Win.C1Input.C1DateEdit()
        Me.dFechaInicial = New C1.Win.C1Input.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit()
        Me.lblIncluirMunicipio = New System.Windows.Forms.Label()
        Me.chkIncluirSocias = New System.Windows.Forms.CheckBox()
        Me.cboLugarPago = New C1.Win.C1List.C1Combo()
        Me.lblPertenece = New System.Windows.Forms.Label()
        Me.cboDistrito = New C1.Win.C1List.C1Combo()
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.cboMunicipio = New C1.Win.C1List.C1Combo()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.cboDepartamento = New C1.Win.C1List.C1Combo()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cboDiaPago = New C1.Win.C1List.C1Combo()
        Me.lblestado = New System.Windows.Forms.Label()
        Me.grpdestino = New System.Windows.Forms.GroupBox()
        Me.RadArchivo = New System.Windows.Forms.RadioButton()
        Me.RadImpresora = New System.Windows.Forms.RadioButton()
        Me.radPantalla = New System.Windows.Forms.RadioButton()
        Me.Exportar = New System.Windows.Forms.SaveFileDialog()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpFuente = New System.Windows.Forms.GroupBox()
        Me.RdExterno = New System.Windows.Forms.RadioButton()
        Me.RdPresupuesto = New System.Windows.Forms.RadioButton()
        Me.RdTodos = New System.Windows.Forms.RadioButton()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.grpPrograma = New System.Windows.Forms.GroupBox()
        Me.RadVentana = New System.Windows.Forms.RadioButton()
        Me.RadUsura0 = New System.Windows.Forms.RadioButton()
        Me.grpCartera = New System.Windows.Forms.GroupBox()
        Me.RdCarteraVencida = New System.Windows.Forms.RadioButton()
        Me.RdCarteraVigente = New System.Windows.Forms.RadioButton()
        Me.RdCarteraTodos = New System.Windows.Forms.RadioButton()
        Me.grpdatos.SuspendLayout()
        CType(Me.dFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLugarPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDiaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdestino.SuspendLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFuente.SuspendLayout()
        Me.grpPrograma.SuspendLayout()
        Me.grpCartera.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.dFechaFinal)
        Me.grpdatos.Controls.Add(Me.dFechaInicial)
        Me.grpdatos.Controls.Add(Me.Label2)
        Me.grpdatos.Controls.Add(Me.Label1)
        Me.grpdatos.Controls.Add(Me.cdeFechaInicial)
        Me.grpdatos.Controls.Add(Me.lblIncluirMunicipio)
        Me.grpdatos.Controls.Add(Me.chkIncluirSocias)
        Me.grpdatos.Controls.Add(Me.cboLugarPago)
        Me.grpdatos.Controls.Add(Me.lblPertenece)
        Me.grpdatos.Controls.Add(Me.cboDistrito)
        Me.grpdatos.Controls.Add(Me.lblDistrito)
        Me.grpdatos.Controls.Add(Me.cboMunicipio)
        Me.grpdatos.Controls.Add(Me.lblMunicipio)
        Me.grpdatos.Controls.Add(Me.cboDepartamento)
        Me.grpdatos.Controls.Add(Me.lblDepartamento)
        Me.grpdatos.Controls.Add(Me.cboDiaPago)
        Me.grpdatos.Controls.Add(Me.lblestado)
        Me.grpdatos.Location = New System.Drawing.Point(10, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(444, 233)
        Me.grpdatos.TabIndex = 0
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'dFechaFinal
        '
        Me.dFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.dFechaFinal.Enabled = False
        Me.dFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dFechaFinal.Location = New System.Drawing.Point(280, 193)
        Me.dFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.dFechaFinal.MaskInfo.EmptyAsNull = True
        Me.dFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.dFechaFinal.Name = "dFechaFinal"
        Me.dFechaFinal.Size = New System.Drawing.Size(150, 20)
        Me.dFechaFinal.TabIndex = 65
        Me.dFechaFinal.Tag = Nothing
        Me.dFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'dFechaInicial
        '
        Me.dFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.dFechaInicial.Enabled = False
        Me.dFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dFechaInicial.Location = New System.Drawing.Point(70, 193)
        Me.dFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.dFechaInicial.MaskInfo.EmptyAsNull = True
        Me.dFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.dFechaInicial.Name = "dFechaInicial"
        Me.dFechaInicial.Size = New System.Drawing.Size(150, 20)
        Me.dFechaInicial.TabIndex = 64
        Me.dFechaInicial.Tag = Nothing
        Me.dFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(239, 196)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(16, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Desde:"
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(151, 160)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(150, 20)
        Me.cdeFechaInicial.TabIndex = 61
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblIncluirMunicipio
        '
        Me.lblIncluirMunicipio.AutoSize = True
        Me.lblIncluirMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblIncluirMunicipio.Location = New System.Drawing.Point(16, 160)
        Me.lblIncluirMunicipio.Name = "lblIncluirMunicipio"
        Me.lblIncluirMunicipio.Size = New System.Drawing.Size(122, 13)
        Me.lblIncluirMunicipio.TabIndex = 39
        Me.lblIncluirMunicipio.Text = "Incluir Todas las Socias:"
        '
        'chkIncluirSocias
        '
        Me.chkIncluirSocias.AutoSize = True
        Me.chkIncluirSocias.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIncluirSocias.Location = New System.Drawing.Point(151, 160)
        Me.chkIncluirSocias.Name = "chkIncluirSocias"
        Me.chkIncluirSocias.Size = New System.Drawing.Size(15, 17)
        Me.chkIncluirSocias.TabIndex = 5
        Me.chkIncluirSocias.Text = " "
        Me.chkIncluirSocias.UseVisualStyleBackColor = True
        '
        'cboLugarPago
        '
        Me.cboLugarPago.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboLugarPago.AllowSort = False
        Me.cboLugarPago.AutoCompletion = True
        Me.cboLugarPago.Caption = ""
        Me.cboLugarPago.CaptionHeight = 17
        Me.cboLugarPago.CaptionStyle = Style1
        Me.cboLugarPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboLugarPago.ColumnCaptionHeight = 17
        Me.cboLugarPago.ColumnFooterHeight = 17
        Me.cboLugarPago.ContentHeight = 15
        Me.cboLugarPago.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboLugarPago.DisplayMember = "sNombre"
        Me.cboLugarPago.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboLugarPago.DropDownWidth = 250
        Me.cboLugarPago.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboLugarPago.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLugarPago.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboLugarPago.EditorHeight = 15
        Me.cboLugarPago.EvenRowStyle = Style2
        Me.cboLugarPago.ExtendRightColumn = True
        Me.cboLugarPago.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboLugarPago.FooterStyle = Style3
        Me.cboLugarPago.GapHeight = 2
        Me.cboLugarPago.HeadingStyle = Style4
        Me.cboLugarPago.HighLightRowStyle = Style5
        Me.cboLugarPago.Images.Add(CType(resources.GetObject("cboLugarPago.Images"), System.Drawing.Image))
        Me.cboLugarPago.ItemHeight = 15
        Me.cboLugarPago.Location = New System.Drawing.Point(151, 100)
        Me.cboLugarPago.MatchEntryTimeout = CType(2000, Long)
        Me.cboLugarPago.MaxDropDownItems = CType(5, Short)
        Me.cboLugarPago.MaxLength = 32767
        Me.cboLugarPago.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboLugarPago.Name = "cboLugarPago"
        Me.cboLugarPago.OddRowStyle = Style6
        Me.cboLugarPago.PartialRightColumn = False
        Me.cboLugarPago.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboLugarPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboLugarPago.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboLugarPago.SelectedStyle = Style7
        Me.cboLugarPago.Size = New System.Drawing.Size(168, 21)
        Me.cboLugarPago.Style = Style8
        Me.cboLugarPago.TabIndex = 3
        Me.cboLugarPago.PropBag = resources.GetString("cboLugarPago.PropBag")
        '
        'lblPertenece
        '
        Me.lblPertenece.AutoSize = True
        Me.lblPertenece.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPertenece.Location = New System.Drawing.Point(16, 106)
        Me.lblPertenece.Name = "lblPertenece"
        Me.lblPertenece.Size = New System.Drawing.Size(80, 13)
        Me.lblPertenece.TabIndex = 37
        Me.lblPertenece.Text = "Lugar de Pago:"
        '
        'cboDistrito
        '
        Me.cboDistrito.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDistrito.AutoCompletion = True
        Me.cboDistrito.Caption = ""
        Me.cboDistrito.CaptionHeight = 17
        Me.cboDistrito.CaptionStyle = Style9
        Me.cboDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDistrito.ColumnCaptionHeight = 17
        Me.cboDistrito.ColumnFooterHeight = 17
        Me.cboDistrito.ContentHeight = 15
        Me.cboDistrito.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDistrito.DisplayMember = "Descripcion"
        Me.cboDistrito.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDistrito.DropDownWidth = 146
        Me.cboDistrito.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDistrito.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrito.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDistrito.EditorHeight = 15
        Me.cboDistrito.EvenRowStyle = Style10
        Me.cboDistrito.ExtendRightColumn = True
        Me.cboDistrito.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDistrito.FooterStyle = Style11
        Me.cboDistrito.GapHeight = 2
        Me.cboDistrito.HeadingStyle = Style12
        Me.cboDistrito.HighLightRowStyle = Style13
        Me.cboDistrito.Images.Add(CType(resources.GetObject("cboDistrito.Images"), System.Drawing.Image))
        Me.cboDistrito.ItemHeight = 15
        Me.cboDistrito.LimitToList = True
        Me.cboDistrito.Location = New System.Drawing.Point(151, 73)
        Me.cboDistrito.MatchEntryTimeout = CType(2000, Long)
        Me.cboDistrito.MaxDropDownItems = CType(5, Short)
        Me.cboDistrito.MaxLength = 32767
        Me.cboDistrito.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.OddRowStyle = Style14
        Me.cboDistrito.PartialRightColumn = False
        Me.cboDistrito.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDistrito.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDistrito.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDistrito.SelectedStyle = Style15
        Me.cboDistrito.Size = New System.Drawing.Size(168, 21)
        Me.cboDistrito.Style = Style16
        Me.cboDistrito.SuperBack = True
        Me.cboDistrito.TabIndex = 2
        Me.cboDistrito.ValueMember = "StbValorCatalogoID"
        Me.cboDistrito.PropBag = resources.GetString("cboDistrito.PropBag")
        '
        'lblDistrito
        '
        Me.lblDistrito.AutoSize = True
        Me.lblDistrito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDistrito.Location = New System.Drawing.Point(16, 81)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(42, 13)
        Me.lblDistrito.TabIndex = 36
        Me.lblDistrito.Text = "Distrito:"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMunicipio.AutoCompletion = True
        Me.cboMunicipio.Caption = ""
        Me.cboMunicipio.CaptionHeight = 17
        Me.cboMunicipio.CaptionStyle = Style17
        Me.cboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMunicipio.ColumnCaptionHeight = 17
        Me.cboMunicipio.ColumnFooterHeight = 17
        Me.cboMunicipio.ContentHeight = 15
        Me.cboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMunicipio.DisplayMember = "Descripcion"
        Me.cboMunicipio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMunicipio.DropDownWidth = 188
        Me.cboMunicipio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMunicipio.EditorHeight = 15
        Me.cboMunicipio.EvenRowStyle = Style18
        Me.cboMunicipio.ExtendRightColumn = True
        Me.cboMunicipio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMunicipio.FooterStyle = Style19
        Me.cboMunicipio.GapHeight = 2
        Me.cboMunicipio.HeadingStyle = Style20
        Me.cboMunicipio.HighLightRowStyle = Style21
        Me.cboMunicipio.Images.Add(CType(resources.GetObject("cboMunicipio.Images"), System.Drawing.Image))
        Me.cboMunicipio.ItemHeight = 15
        Me.cboMunicipio.LimitToList = True
        Me.cboMunicipio.Location = New System.Drawing.Point(151, 46)
        Me.cboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.cboMunicipio.MaxLength = 32767
        Me.cboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.OddRowStyle = Style22
        Me.cboMunicipio.PartialRightColumn = False
        Me.cboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMunicipio.SelectedStyle = Style23
        Me.cboMunicipio.Size = New System.Drawing.Size(168, 21)
        Me.cboMunicipio.Style = Style24
        Me.cboMunicipio.SuperBack = True
        Me.cboMunicipio.TabIndex = 1
        Me.cboMunicipio.ValueMember = "StbValorCatalogoID"
        Me.cboMunicipio.PropBag = resources.GetString("cboMunicipio.PropBag")
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(16, 54)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(55, 13)
        Me.lblMunicipio.TabIndex = 34
        Me.lblMunicipio.Text = "Municipio:"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style25
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "Descripcion"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 153
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.EvenRowStyle = Style26
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style27
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style28
        Me.cboDepartamento.HighLightRowStyle = Style29
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(151, 19)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style30
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style31
        Me.cboDepartamento.Size = New System.Drawing.Size(168, 21)
        Me.cboDepartamento.Style = Style32
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 0
        Me.cboDepartamento.ValueMember = "StbValorCatalogoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(16, 27)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 7
        Me.lblDepartamento.Text = "Departamento:"
        '
        'cboDiaPago
        '
        Me.cboDiaPago.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDiaPago.AllowSort = False
        Me.cboDiaPago.AutoCompletion = True
        Me.cboDiaPago.Caption = ""
        Me.cboDiaPago.CaptionHeight = 17
        Me.cboDiaPago.CaptionStyle = Style33
        Me.cboDiaPago.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDiaPago.ColumnCaptionHeight = 17
        Me.cboDiaPago.ColumnFooterHeight = 17
        Me.cboDiaPago.ContentHeight = 15
        Me.cboDiaPago.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDiaPago.DisplayMember = "sDescripcion"
        Me.cboDiaPago.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDiaPago.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDiaPago.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDiaPago.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDiaPago.EditorHeight = 15
        Me.cboDiaPago.EvenRowStyle = Style34
        Me.cboDiaPago.ExtendRightColumn = True
        Me.cboDiaPago.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDiaPago.FooterStyle = Style35
        Me.cboDiaPago.GapHeight = 2
        Me.cboDiaPago.HeadingStyle = Style36
        Me.cboDiaPago.HighLightRowStyle = Style37
        Me.cboDiaPago.Images.Add(CType(resources.GetObject("cboDiaPago.Images"), System.Drawing.Image))
        Me.cboDiaPago.ItemHeight = 15
        Me.cboDiaPago.Location = New System.Drawing.Point(151, 127)
        Me.cboDiaPago.MatchEntryTimeout = CType(2000, Long)
        Me.cboDiaPago.MaxDropDownItems = CType(5, Short)
        Me.cboDiaPago.MaxLength = 32767
        Me.cboDiaPago.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDiaPago.Name = "cboDiaPago"
        Me.cboDiaPago.OddRowStyle = Style38
        Me.cboDiaPago.PartialRightColumn = False
        Me.cboDiaPago.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDiaPago.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDiaPago.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDiaPago.SelectedStyle = Style39
        Me.cboDiaPago.Size = New System.Drawing.Size(168, 21)
        Me.cboDiaPago.Style = Style40
        Me.cboDiaPago.TabIndex = 4
        Me.cboDiaPago.PropBag = resources.GetString("cboDiaPago.PropBag")
        '
        'lblestado
        '
        Me.lblestado.AutoSize = True
        Me.lblestado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblestado.Location = New System.Drawing.Point(16, 133)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(71, 13)
        Me.lblestado.TabIndex = 0
        Me.lblestado.Text = "Día de Pago:"
        '
        'grpdestino
        '
        Me.grpdestino.Controls.Add(Me.RadArchivo)
        Me.grpdestino.Controls.Add(Me.RadImpresora)
        Me.grpdestino.Controls.Add(Me.radPantalla)
        Me.grpdestino.Location = New System.Drawing.Point(245, 320)
        Me.grpdestino.Name = "grpdestino"
        Me.grpdestino.Size = New System.Drawing.Size(209, 57)
        Me.grpdestino.TabIndex = 1
        Me.grpdestino.TabStop = False
        Me.grpdestino.Text = "Destino del Reporte"
        '
        'RadArchivo
        '
        Me.RadArchivo.AutoSize = True
        Me.RadArchivo.Location = New System.Drawing.Point(7, 34)
        Me.RadArchivo.Name = "RadArchivo"
        Me.RadArchivo.Size = New System.Drawing.Size(61, 17)
        Me.RadArchivo.TabIndex = 2
        Me.RadArchivo.Text = "Archivo"
        Me.RadArchivo.UseVisualStyleBackColor = True
        '
        'RadImpresora
        '
        Me.RadImpresora.AutoSize = True
        Me.RadImpresora.Location = New System.Drawing.Point(83, 15)
        Me.RadImpresora.Name = "RadImpresora"
        Me.RadImpresora.Size = New System.Drawing.Size(71, 17)
        Me.RadImpresora.TabIndex = 1
        Me.RadImpresora.Text = "Impresora"
        Me.RadImpresora.UseVisualStyleBackColor = True
        '
        'radPantalla
        '
        Me.radPantalla.AutoSize = True
        Me.radPantalla.Checked = True
        Me.radPantalla.Location = New System.Drawing.Point(7, 15)
        Me.radPantalla.Name = "radPantalla"
        Me.radPantalla.Size = New System.Drawing.Size(63, 17)
        Me.radPantalla.TabIndex = 0
        Me.radPantalla.TabStop = True
        Me.radPantalla.Text = "Pantalla"
        Me.radPantalla.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(383, 383)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(311, 383)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 2
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'grpFuente
        '
        Me.grpFuente.Controls.Add(Me.RdExterno)
        Me.grpFuente.Controls.Add(Me.RdPresupuesto)
        Me.grpFuente.Controls.Add(Me.RdTodos)
        Me.grpFuente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpFuente.Location = New System.Drawing.Point(12, 265)
        Me.grpFuente.Name = "grpFuente"
        Me.grpFuente.Size = New System.Drawing.Size(227, 49)
        Me.grpFuente.TabIndex = 42
        Me.grpFuente.TabStop = False
        Me.grpFuente.Text = "Fondos"
        '
        'RdExterno
        '
        Me.RdExterno.AutoSize = True
        Me.RdExterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdExterno.Location = New System.Drawing.Point(158, 19)
        Me.RdExterno.Name = "RdExterno"
        Me.RdExterno.Size = New System.Drawing.Size(66, 17)
        Me.RdExterno.TabIndex = 2
        Me.RdExterno.Text = "Externos"
        Me.RdExterno.UseVisualStyleBackColor = True
        '
        'RdPresupuesto
        '
        Me.RdPresupuesto.AutoSize = True
        Me.RdPresupuesto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdPresupuesto.Location = New System.Drawing.Point(68, 19)
        Me.RdPresupuesto.Name = "RdPresupuesto"
        Me.RdPresupuesto.Size = New System.Drawing.Size(84, 17)
        Me.RdPresupuesto.TabIndex = 1
        Me.RdPresupuesto.Text = "Presupuesto"
        Me.RdPresupuesto.UseVisualStyleBackColor = True
        '
        'RdTodos
        '
        Me.RdTodos.AutoSize = True
        Me.RdTodos.Checked = True
        Me.RdTodos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdTodos.Location = New System.Drawing.Point(7, 19)
        Me.RdTodos.Name = "RdTodos"
        Me.RdTodos.Size = New System.Drawing.Size(55, 17)
        Me.RdTodos.TabIndex = 0
        Me.RdTodos.TabStop = True
        Me.RdTodos.Text = "Todos"
        Me.RdTodos.UseVisualStyleBackColor = True
        '
        'grpPrograma
        '
        Me.grpPrograma.Controls.Add(Me.RadVentana)
        Me.grpPrograma.Controls.Add(Me.RadUsura0)
        Me.grpPrograma.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpPrograma.Location = New System.Drawing.Point(245, 265)
        Me.grpPrograma.Name = "grpPrograma"
        Me.grpPrograma.Size = New System.Drawing.Size(211, 49)
        Me.grpPrograma.TabIndex = 43
        Me.grpPrograma.TabStop = False
        Me.grpPrograma.Text = "Programa"
        '
        'RadVentana
        '
        Me.RadVentana.AutoSize = True
        Me.RadVentana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadVentana.Location = New System.Drawing.Point(83, 20)
        Me.RadVentana.Name = "RadVentana"
        Me.RadVentana.Size = New System.Drawing.Size(103, 17)
        Me.RadVentana.TabIndex = 1
        Me.RadVentana.Text = "Ventana Genero"
        Me.RadVentana.UseVisualStyleBackColor = True
        '
        'RadUsura0
        '
        Me.RadUsura0.AutoSize = True
        Me.RadUsura0.Checked = True
        Me.RadUsura0.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadUsura0.Location = New System.Drawing.Point(7, 19)
        Me.RadUsura0.Name = "RadUsura0"
        Me.RadUsura0.Size = New System.Drawing.Size(62, 17)
        Me.RadUsura0.TabIndex = 0
        Me.RadUsura0.TabStop = True
        Me.RadUsura0.Text = "Usura 0"
        Me.RadUsura0.UseVisualStyleBackColor = True
        '
        'grpCartera
        '
        Me.grpCartera.Controls.Add(Me.RdCarteraVencida)
        Me.grpCartera.Controls.Add(Me.RdCarteraVigente)
        Me.grpCartera.Controls.Add(Me.RdCarteraTodos)
        Me.grpCartera.Enabled = False
        Me.grpCartera.Location = New System.Drawing.Point(10, 320)
        Me.grpCartera.Name = "grpCartera"
        Me.grpCartera.Size = New System.Drawing.Size(229, 57)
        Me.grpCartera.TabIndex = 73
        Me.grpCartera.TabStop = False
        Me.grpCartera.Text = "Mora de Crédito"
        '
        'RdCarteraVencida
        '
        Me.RdCarteraVencida.AutoSize = True
        Me.RdCarteraVencida.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdCarteraVencida.Location = New System.Drawing.Point(22, 34)
        Me.RdCarteraVencida.Name = "RdCarteraVencida"
        Me.RdCarteraVencida.Size = New System.Drawing.Size(64, 17)
        Me.RdCarteraVencida.TabIndex = 3
        Me.RdCarteraVencida.Text = "Vencido"
        Me.RdCarteraVencida.UseVisualStyleBackColor = True
        '
        'RdCarteraVigente
        '
        Me.RdCarteraVigente.AutoSize = True
        Me.RdCarteraVigente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdCarteraVigente.Location = New System.Drawing.Point(93, 15)
        Me.RdCarteraVigente.Name = "RdCarteraVigente"
        Me.RdCarteraVigente.Size = New System.Drawing.Size(61, 17)
        Me.RdCarteraVigente.TabIndex = 2
        Me.RdCarteraVigente.Text = "Vigente"
        Me.RdCarteraVigente.UseVisualStyleBackColor = True
        '
        'RdCarteraTodos
        '
        Me.RdCarteraTodos.AutoSize = True
        Me.RdCarteraTodos.Checked = True
        Me.RdCarteraTodos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdCarteraTodos.Location = New System.Drawing.Point(22, 15)
        Me.RdCarteraTodos.Name = "RdCarteraTodos"
        Me.RdCarteraTodos.Size = New System.Drawing.Size(55, 17)
        Me.RdCarteraTodos.TabIndex = 1
        Me.RdCarteraTodos.TabStop = True
        Me.RdCarteraTodos.Text = "Todos"
        Me.RdCarteraTodos.UseVisualStyleBackColor = True
        '
        'frmSclParametroGrupoPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 414)
        Me.Controls.Add(Me.grpCartera)
        Me.Controls.Add(Me.grpPrograma)
        Me.Controls.Add(Me.grpFuente)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdatos)
        Me.Controls.Add(Me.grpdestino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclParametroGrupoPago"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros del Reporte"
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.dFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLugarPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDiaPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdestino.ResumeLayout(False)
        Me.grpdestino.PerformLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFuente.ResumeLayout(False)
        Me.grpFuente.PerformLayout()
        Me.grpPrograma.ResumeLayout(False)
        Me.grpPrograma.PerformLayout()
        Me.grpCartera.ResumeLayout(False)
        Me.grpCartera.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboDiaPago As C1.Win.C1List.C1Combo
    Friend WithEvents grpdestino As System.Windows.Forms.GroupBox
    Friend WithEvents RadArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents radPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboDistrito As C1.Win.C1List.C1Combo
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents cboLugarPago As C1.Win.C1List.C1Combo
    Friend WithEvents lblPertenece As System.Windows.Forms.Label
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblIncluirMunicipio As System.Windows.Forms.Label
    Friend WithEvents chkIncluirSocias As System.Windows.Forms.CheckBox
    Friend WithEvents grpFuente As System.Windows.Forms.GroupBox
    Friend WithEvents RdExterno As System.Windows.Forms.RadioButton
    Friend WithEvents RdPresupuesto As System.Windows.Forms.RadioButton
    Friend WithEvents RdTodos As System.Windows.Forms.RadioButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents grpPrograma As System.Windows.Forms.GroupBox
    Friend WithEvents RadVentana As System.Windows.Forms.RadioButton
    Friend WithEvents RadUsura0 As System.Windows.Forms.RadioButton
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents dFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpCartera As GroupBox
    Friend WithEvents RdCarteraVencida As RadioButton
    Friend WithEvents RdCarteraVigente As RadioButton
    Friend WithEvents RdCarteraTodos As RadioButton
End Class
