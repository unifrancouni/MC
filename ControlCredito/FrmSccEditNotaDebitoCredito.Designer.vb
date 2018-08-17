<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccEditNotaDebitoCredito
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
        Me.components = New System.ComponentModel.Container()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccEditNotaDebitoCredito))
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
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TxtAnio = New System.Windows.Forms.TextBox()
        Me.grpGrupoInicial = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cdeFechaCS = New C1.Win.C1Input.C1DateEdit()
        Me.txtGrupoCodigoS = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtGrupoNombreS = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtGrupoIdS = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboGrupoS = New C1.Win.C1List.C1Combo()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkEsDebito = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cboDelegacion = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.cboFuente = New C1.Win.C1List.C1Combo()
        Me.lblFuente = New System.Windows.Forms.Label()
        Me.cneMonto = New C1.Win.C1Input.C1NumericEdit()
        Me.cdeFechaTC = New C1.Win.C1Input.C1DateEdit()
        Me.cdeFechaS = New C1.Win.C1Input.C1DateEdit()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblFechaTC = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.errSolicitud = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.grpDatosFicha = New System.Windows.Forms.GroupBox()
        Me.cmdBuscarG = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.GrpCedulaSocia = New System.Windows.Forms.GroupBox()
        Me.cneMontoFicha = New C1.Win.C1Input.C1NumericEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnSclFichaDetalle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNombreGrupo = New System.Windows.Forms.TextBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.txtCodigoGrupo = New System.Windows.Forms.TextBox()
        Me.lblCodigoGrupo = New System.Windows.Forms.Label()
        Me.txtCodigoFNC = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.mtbNumeroSesion = New System.Windows.Forms.MaskedTextBox()
        Me.lblSesion = New System.Windows.Forms.Label()
        Me.txtNombreSocia = New System.Windows.Forms.TextBox()
        Me.lblNombreSocia = New System.Windows.Forms.Label()
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.grpGrupoSeleccion = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtNombreFuenteFinanciamiento = New System.Windows.Forms.TextBox()
        Me.grdSeleccion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmdRegresarDetalle = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cdeFechaC = New C1.Win.C1Input.C1DateEdit()
        Me.cmdListar = New System.Windows.Forms.Button()
        Me.cboGrupo = New C1.Win.C1List.C1Combo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdCancelarG = New System.Windows.Forms.Button()
        Me.cmdAceptarG = New System.Windows.Forms.Button()
        Me.txtGrupoCodigo = New System.Windows.Forms.TextBox()
        Me.txtGrupoNombre = New System.Windows.Forms.TextBox()
        Me.txtGrupoId = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.grdDetalles = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.grpDatosGenerales.SuspendLayout()
        Me.grpGrupoInicial.SuspendLayout()
        CType(Me.cdeFechaCS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGrupoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDelegacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosFicha.SuspendLayout()
        Me.GrpCedulaSocia.SuspendLayout()
        CType(Me.cneMontoFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGrupoSeleccion.SuspendLayout()
        CType(Me.grdSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.Label17)
        Me.grpDatosGenerales.Controls.Add(Me.TxtAnio)
        Me.grpDatosGenerales.Controls.Add(Me.grpGrupoInicial)
        Me.grpDatosGenerales.Controls.Add(Me.chkEsDebito)
        Me.grpDatosGenerales.Controls.Add(Me.Label4)
        Me.grpDatosGenerales.Controls.Add(Me.cmdCancelar)
        Me.grpDatosGenerales.Controls.Add(Me.cmdAceptar)
        Me.grpDatosGenerales.Controls.Add(Me.cboDelegacion)
        Me.grpDatosGenerales.Controls.Add(Me.Label1)
        Me.grpDatosGenerales.Controls.Add(Me.lblConcepto)
        Me.grpDatosGenerales.Controls.Add(Me.txtConcepto)
        Me.grpDatosGenerales.Controls.Add(Me.cboFuente)
        Me.grpDatosGenerales.Controls.Add(Me.lblFuente)
        Me.grpDatosGenerales.Controls.Add(Me.cneMonto)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaTC)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaS)
        Me.grpDatosGenerales.Controls.Add(Me.lblMonto)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaTC)
        Me.grpDatosGenerales.Controls.Add(Me.lblFecha)
        Me.grpDatosGenerales.Controls.Add(Me.Label2)
        Me.grpDatosGenerales.Controls.Add(Me.txtCodigo)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(17, 39)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(808, 283)
        Me.grpDatosGenerales.TabIndex = 2
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Generales: "
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(474, 153)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 13)
        Me.Label17.TabIndex = 52
        Me.Label17.Text = "Año:"
        '
        'TxtAnio
        '
        Me.TxtAnio.Location = New System.Drawing.Point(513, 150)
        Me.TxtAnio.Name = "TxtAnio"
        Me.TxtAnio.ReadOnly = True
        Me.TxtAnio.Size = New System.Drawing.Size(100, 20)
        Me.TxtAnio.TabIndex = 51
        '
        'grpGrupoInicial
        '
        Me.grpGrupoInicial.Controls.Add(Me.Label15)
        Me.grpGrupoInicial.Controls.Add(Me.cdeFechaCS)
        Me.grpGrupoInicial.Controls.Add(Me.txtGrupoCodigoS)
        Me.grpGrupoInicial.Controls.Add(Me.Label14)
        Me.grpGrupoInicial.Controls.Add(Me.txtGrupoNombreS)
        Me.grpGrupoInicial.Controls.Add(Me.Label13)
        Me.grpGrupoInicial.Controls.Add(Me.txtGrupoIdS)
        Me.grpGrupoInicial.Controls.Add(Me.Label12)
        Me.grpGrupoInicial.Controls.Add(Me.cboGrupoS)
        Me.grpGrupoInicial.Controls.Add(Me.Label11)
        Me.grpGrupoInicial.Location = New System.Drawing.Point(11, 173)
        Me.grpGrupoInicial.Name = "grpGrupoInicial"
        Me.grpGrupoInicial.Size = New System.Drawing.Size(796, 70)
        Me.grpGrupoInicial.TabIndex = 50
        Me.grpGrupoInicial.TabStop = False
        Me.grpGrupoInicial.Text = "Seleccione grupo de la nota"
        Me.grpGrupoInicial.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(630, 45)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(43, 13)
        Me.Label15.TabIndex = 71
        Me.Label15.Text = "Fecha :"
        '
        'cdeFechaCS
        '
        Me.cdeFechaCS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCS.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaCS.Enabled = False
        Me.cdeFechaCS.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCS.Location = New System.Drawing.Point(676, 45)
        Me.cdeFechaCS.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaCS.MaskInfo.EmptyAsNull = True
        Me.cdeFechaCS.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaCS.Name = "cdeFechaCS"
        Me.cdeFechaCS.Size = New System.Drawing.Size(118, 20)
        Me.cdeFechaCS.TabIndex = 70
        Me.cdeFechaCS.Tag = Nothing
        Me.cdeFechaCS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txtGrupoCodigoS
        '
        Me.txtGrupoCodigoS.AcceptsReturn = True
        Me.txtGrupoCodigoS.Enabled = False
        Me.txtGrupoCodigoS.Location = New System.Drawing.Point(502, 44)
        Me.txtGrupoCodigoS.Name = "txtGrupoCodigoS"
        Me.txtGrupoCodigoS.Size = New System.Drawing.Size(121, 20)
        Me.txtGrupoCodigoS.TabIndex = 69
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(450, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 68
        Me.Label14.Text = "Codigo :"
        '
        'txtGrupoNombreS
        '
        Me.txtGrupoNombreS.AcceptsReturn = True
        Me.txtGrupoNombreS.Enabled = False
        Me.txtGrupoNombreS.Location = New System.Drawing.Point(171, 45)
        Me.txtGrupoNombreS.Name = "txtGrupoNombreS"
        Me.txtGrupoNombreS.Size = New System.Drawing.Size(268, 20)
        Me.txtGrupoNombreS.TabIndex = 67
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(120, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 66
        Me.Label13.Text = "Nombre :"
        '
        'txtGrupoIdS
        '
        Me.txtGrupoIdS.AcceptsReturn = True
        Me.txtGrupoIdS.Enabled = False
        Me.txtGrupoIdS.Location = New System.Drawing.Point(56, 44)
        Me.txtGrupoIdS.Name = "txtGrupoIdS"
        Me.txtGrupoIdS.Size = New System.Drawing.Size(61, 20)
        Me.txtGrupoIdS.TabIndex = 65
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(8, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 64
        Me.Label12.Text = "Id :"
        '
        'cboGrupoS
        '
        Me.cboGrupoS.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboGrupoS.AutoCompletion = True
        Me.cboGrupoS.Caption = ""
        Me.cboGrupoS.CaptionHeight = 17
        Me.cboGrupoS.CaptionStyle = Style1
        Me.cboGrupoS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboGrupoS.ColumnCaptionHeight = 17
        Me.cboGrupoS.ColumnFooterHeight = 17
        Me.cboGrupoS.ContentHeight = 15
        Me.cboGrupoS.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboGrupoS.DisplayMember = "nSclGrupoSolidarioID"
        Me.cboGrupoS.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboGrupoS.DropDownWidth = 500
        Me.cboGrupoS.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboGrupoS.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupoS.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboGrupoS.EditorHeight = 15
        Me.cboGrupoS.EvenRowStyle = Style2
        Me.cboGrupoS.ExtendRightColumn = True
        Me.cboGrupoS.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboGrupoS.FooterStyle = Style3
        Me.cboGrupoS.GapHeight = 2
        Me.cboGrupoS.HeadingStyle = Style4
        Me.cboGrupoS.HighLightRowStyle = Style5
        Me.cboGrupoS.Images.Add(CType(resources.GetObject("cboGrupoS.Images"), System.Drawing.Image))
        Me.cboGrupoS.ItemHeight = 15
        Me.cboGrupoS.LimitToList = True
        Me.cboGrupoS.Location = New System.Drawing.Point(56, 19)
        Me.cboGrupoS.MatchEntryTimeout = CType(2000, Long)
        Me.cboGrupoS.MaxDropDownItems = CType(5, Short)
        Me.cboGrupoS.MaxLength = 32767
        Me.cboGrupoS.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboGrupoS.Name = "cboGrupoS"
        Me.cboGrupoS.OddRowStyle = Style6
        Me.cboGrupoS.PartialRightColumn = False
        Me.cboGrupoS.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboGrupoS.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboGrupoS.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboGrupoS.SelectedStyle = Style7
        Me.cboGrupoS.Size = New System.Drawing.Size(698, 21)
        Me.cboGrupoS.Style = Style8
        Me.cboGrupoS.SuperBack = True
        Me.cboGrupoS.TabIndex = 62
        Me.cboGrupoS.ValueMember = "nSclGrupoSolidarioID"
        Me.cboGrupoS.PropBag = resources.GetString("cboGrupoS.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(11, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "Grupo:"
        '
        'chkEsDebito
        '
        Me.chkEsDebito.AutoSize = True
        Me.chkEsDebito.Enabled = False
        Me.chkEsDebito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.chkEsDebito.Location = New System.Drawing.Point(580, 54)
        Me.chkEsDebito.Name = "chkEsDebito"
        Me.chkEsDebito.Size = New System.Drawing.Size(57, 17)
        Me.chkEsDebito.TabIndex = 48
        Me.chkEsDebito.Text = "Debito"
        Me.chkEsDebito.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(465, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Tipo de Nota:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(709, 249)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 14
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(632, 249)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 13
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cboDelegacion
        '
        Me.cboDelegacion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDelegacion.AutoCompletion = True
        Me.cboDelegacion.Caption = ""
        Me.cboDelegacion.CaptionHeight = 17
        Me.cboDelegacion.CaptionStyle = Style9
        Me.cboDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDelegacion.ColumnCaptionHeight = 17
        Me.cboDelegacion.ColumnFooterHeight = 17
        Me.cboDelegacion.ContentHeight = 15
        Me.cboDelegacion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDelegacion.DisplayMember = "sNombreDelegacion"
        Me.cboDelegacion.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDelegacion.DropDownWidth = 276
        Me.cboDelegacion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDelegacion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDelegacion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDelegacion.EditorHeight = 15
        Me.cboDelegacion.Enabled = False
        Me.cboDelegacion.EvenRowStyle = Style10
        Me.cboDelegacion.ExtendRightColumn = True
        Me.cboDelegacion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDelegacion.FooterStyle = Style11
        Me.cboDelegacion.GapHeight = 2
        Me.cboDelegacion.HeadingStyle = Style12
        Me.cboDelegacion.HighLightRowStyle = Style13
        Me.cboDelegacion.Images.Add(CType(resources.GetObject("cboDelegacion.Images"), System.Drawing.Image))
        Me.cboDelegacion.ItemHeight = 15
        Me.cboDelegacion.LimitToList = True
        Me.cboDelegacion.Location = New System.Drawing.Point(133, 146)
        Me.cboDelegacion.MatchEntryTimeout = CType(2000, Long)
        Me.cboDelegacion.MaxDropDownItems = CType(5, Short)
        Me.cboDelegacion.MaxLength = 32767
        Me.cboDelegacion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDelegacion.Name = "cboDelegacion"
        Me.cboDelegacion.OddRowStyle = Style14
        Me.cboDelegacion.PartialRightColumn = False
        Me.cboDelegacion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDelegacion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDelegacion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDelegacion.SelectedStyle = Style15
        Me.cboDelegacion.Size = New System.Drawing.Size(289, 21)
        Me.cboDelegacion.Style = Style16
        Me.cboDelegacion.SuperBack = True
        Me.cboDelegacion.TabIndex = 43
        Me.cboDelegacion.ValueMember = "nStbDelegacionProgramaID"
        Me.cboDelegacion.PropBag = resources.GetString("cboDelegacion.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Delegacion:"
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblConcepto.Location = New System.Drawing.Point(10, 88)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(82, 13)
        Me.lblConcepto.TabIndex = 42
        Me.lblConcepto.Text = "Concepto Nota:"
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Enabled = False
        Me.txtConcepto.Location = New System.Drawing.Point(133, 77)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConcepto.Size = New System.Drawing.Size(662, 63)
        Me.txtConcepto.TabIndex = 41
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
        Me.cboFuente.Enabled = False
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
        Me.cboFuente.Location = New System.Drawing.Point(532, 27)
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
        Me.cboFuente.Size = New System.Drawing.Size(270, 21)
        Me.cboFuente.Style = Style24
        Me.cboFuente.SuperBack = True
        Me.cboFuente.TabIndex = 39
        Me.cboFuente.ValueMember = "nScnFuenteFinanciamientoID"
        Me.cboFuente.PropBag = resources.GetString("cboFuente.PropBag")
        '
        'lblFuente
        '
        Me.lblFuente.AutoSize = True
        Me.lblFuente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFuente.Location = New System.Drawing.Point(461, 29)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(46, 13)
        Me.lblFuente.TabIndex = 40
        Me.lblFuente.Text = "Fuente :"
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
        Me.cneMonto.Enabled = False
        Me.cneMonto.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.Location = New System.Drawing.Point(332, 27)
        Me.cneMonto.MaskInfo.AutoTabWhenFilled = True
        Me.cneMonto.MaxLength = 999999999
        Me.cneMonto.Name = "cneMonto"
        Me.cneMonto.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMonto.Size = New System.Drawing.Size(118, 20)
        Me.cneMonto.TabIndex = 4
        Me.cneMonto.Tag = Nothing
        Me.cneMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMonto.UseColumnStyles = False
        Me.cneMonto.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'cdeFechaTC
        '
        Me.cdeFechaTC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaTC.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaTC.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaTC.Location = New System.Drawing.Point(332, 53)
        Me.cdeFechaTC.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaTC.MaskInfo.EmptyAsNull = True
        Me.cdeFechaTC.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaTC.Name = "cdeFechaTC"
        Me.cdeFechaTC.Size = New System.Drawing.Size(118, 20)
        Me.cdeFechaTC.TabIndex = 3
        Me.cdeFechaTC.Tag = Nothing
        Me.cdeFechaTC.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaS
        '
        Me.cdeFechaS.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaS.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaS.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaS.Location = New System.Drawing.Point(133, 53)
        Me.cdeFechaS.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaS.MaskInfo.EmptyAsNull = True
        Me.cdeFechaS.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaS.Name = "cdeFechaS"
        Me.cdeFechaS.Size = New System.Drawing.Size(108, 20)
        Me.cdeFechaS.TabIndex = 2
        Me.cdeFechaS.Tag = Nothing
        Me.cdeFechaS.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(257, 27)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(62, 13)
        Me.lblMonto.TabIndex = 38
        Me.lblMonto.Text = "Monto (C$):"
        '
        'lblFechaTC
        '
        Me.lblFechaTC.AutoSize = True
        Me.lblFechaTC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaTC.Location = New System.Drawing.Point(262, 53)
        Me.lblFechaTC.Name = "lblFechaTC"
        Me.lblFechaTC.Size = New System.Drawing.Size(57, 13)
        Me.lblFechaTC.TabIndex = 37
        Me.lblFechaTC.Text = "Fecha TC:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(10, 53)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(78, 13)
        Me.lblFecha.TabIndex = 35
        Me.lblFecha.Text = "Fecha de Nota"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(10, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Código Nota:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(133, 24)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(108, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'errSolicitud
        '
        Me.errSolicitud.ContainerControl = Me
        '
        'grpDatosFicha
        '
        Me.grpDatosFicha.Controls.Add(Me.cmdBuscarG)
        Me.grpDatosFicha.Controls.Add(Me.cmdEliminar)
        Me.grpDatosFicha.Controls.Add(Me.cmdAgregar)
        Me.grpDatosFicha.Controls.Add(Me.cmdBuscar)
        Me.grpDatosFicha.Controls.Add(Me.GrpCedulaSocia)
        Me.grpDatosFicha.Location = New System.Drawing.Point(17, 328)
        Me.grpDatosFicha.Name = "grpDatosFicha"
        Me.grpDatosFicha.Size = New System.Drawing.Size(808, 202)
        Me.grpDatosFicha.TabIndex = 4
        Me.grpDatosFicha.TabStop = False
        Me.grpDatosFicha.Text = "Detalle Fichas"
        '
        'cmdBuscarG
        '
        Me.cmdBuscarG.Image = Global.SMUSURA0.My.Resources.Resources.viewmag
        Me.cmdBuscarG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscarG.Location = New System.Drawing.Point(11, 19)
        Me.cmdBuscarG.Name = "cmdBuscarG"
        Me.cmdBuscarG.Size = New System.Drawing.Size(67, 35)
        Me.cmdBuscarG.TabIndex = 59
        Me.cmdBuscarG.Text = "Buscar"
        Me.cmdBuscarG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscarG.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.cmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEliminar.Location = New System.Drawing.Point(704, 19)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(71, 24)
        Me.cmdEliminar.TabIndex = 56
        Me.cmdEliminar.Text = "Eliminar "
        Me.cmdEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAgregar.Location = New System.Drawing.Point(627, 19)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(71, 24)
        Me.cmdAgregar.TabIndex = 55
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAgregar.UseVisualStyleBackColor = True
        Me.cmdAgregar.Visible = False
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(541, 19)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(67, 24)
        Me.cmdBuscar.TabIndex = 53
        Me.cmdBuscar.Text = "Buscar Ficha"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        Me.cmdBuscar.Visible = False
        '
        'GrpCedulaSocia
        '
        Me.GrpCedulaSocia.Controls.Add(Me.cneMontoFicha)
        Me.GrpCedulaSocia.Controls.Add(Me.Label5)
        Me.GrpCedulaSocia.Controls.Add(Me.txtnSclFichaDetalle)
        Me.GrpCedulaSocia.Controls.Add(Me.Label3)
        Me.GrpCedulaSocia.Controls.Add(Me.TxtNombreGrupo)
        Me.GrpCedulaSocia.Controls.Add(Me.lblGrupo)
        Me.GrpCedulaSocia.Controls.Add(Me.txtCodigoGrupo)
        Me.GrpCedulaSocia.Controls.Add(Me.lblCodigoGrupo)
        Me.GrpCedulaSocia.Controls.Add(Me.txtCodigoFNC)
        Me.GrpCedulaSocia.Controls.Add(Me.lblCodigo)
        Me.GrpCedulaSocia.Controls.Add(Me.mtbNumeroSesion)
        Me.GrpCedulaSocia.Controls.Add(Me.lblSesion)
        Me.GrpCedulaSocia.Controls.Add(Me.txtNombreSocia)
        Me.GrpCedulaSocia.Controls.Add(Me.lblNombreSocia)
        Me.GrpCedulaSocia.Controls.Add(Me.mtbNumCedula)
        Me.GrpCedulaSocia.Controls.Add(Me.lblCedula)
        Me.GrpCedulaSocia.Enabled = False
        Me.GrpCedulaSocia.Location = New System.Drawing.Point(6, 60)
        Me.GrpCedulaSocia.Name = "GrpCedulaSocia"
        Me.GrpCedulaSocia.Size = New System.Drawing.Size(761, 128)
        Me.GrpCedulaSocia.TabIndex = 52
        Me.GrpCedulaSocia.TabStop = False
        Me.GrpCedulaSocia.Text = "Debito"
        '
        'cneMontoFicha
        '
        Me.cneMontoFicha.AcceptsTab = True
        Me.cneMontoFicha.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMontoFicha.DataType = GetType(Double)
        Me.cneMontoFicha.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneMontoFicha.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoFicha.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoFicha.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMontoFicha.EditFormat.EmptyAsNull = False
        Me.cneMontoFicha.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoFicha.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoFicha.EmptyAsNull = True
        Me.cneMontoFicha.Enabled = False
        Me.cneMontoFicha.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoFicha.Location = New System.Drawing.Point(286, 97)
        Me.cneMontoFicha.MaskInfo.AutoTabWhenFilled = True
        Me.cneMontoFicha.MaxLength = 999999999
        Me.cneMontoFicha.Name = "cneMontoFicha"
        Me.cneMontoFicha.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMontoFicha.Size = New System.Drawing.Size(118, 20)
        Me.cneMontoFicha.TabIndex = 69
        Me.cneMontoFicha.Tag = Nothing
        Me.cneMontoFicha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMontoFicha.UseColumnStyles = False
        Me.cneMontoFicha.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(221, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Monto (C$):"
        '
        'txtnSclFichaDetalle
        '
        Me.txtnSclFichaDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnSclFichaDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnSclFichaDetalle.Location = New System.Drawing.Point(124, 94)
        Me.txtnSclFichaDetalle.MaxLength = 9
        Me.txtnSclFichaDetalle.Name = "txtnSclFichaDetalle"
        Me.txtnSclFichaDetalle.Size = New System.Drawing.Size(91, 20)
        Me.txtnSclFichaDetalle.TabIndex = 59
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Id Detalle Ficha"
        '
        'TxtNombreGrupo
        '
        Me.TxtNombreGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreGrupo.Location = New System.Drawing.Point(124, 68)
        Me.TxtNombreGrupo.Name = "TxtNombreGrupo"
        Me.TxtNombreGrupo.Size = New System.Drawing.Size(488, 20)
        Me.TxtNombreGrupo.TabIndex = 57
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupo.Location = New System.Drawing.Point(4, 71)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(122, 13)
        Me.lblGrupo.TabIndex = 58
        Me.lblGrupo.Text = "Nombre Grupo Solidario:"
        '
        'txtCodigoGrupo
        '
        Me.txtCodigoGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoGrupo.Location = New System.Drawing.Point(356, 42)
        Me.txtCodigoGrupo.MaxLength = 9
        Me.txtCodigoGrupo.Name = "txtCodigoGrupo"
        Me.txtCodigoGrupo.Size = New System.Drawing.Size(95, 20)
        Me.txtCodigoGrupo.TabIndex = 56
        '
        'lblCodigoGrupo
        '
        Me.lblCodigoGrupo.AutoSize = True
        Me.lblCodigoGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoGrupo.Location = New System.Drawing.Point(268, 42)
        Me.lblCodigoGrupo.Name = "lblCodigoGrupo"
        Me.lblCodigoGrupo.Size = New System.Drawing.Size(75, 13)
        Me.lblCodigoGrupo.TabIndex = 55
        Me.lblCodigoGrupo.Text = "Código Grupo:"
        '
        'txtCodigoFNC
        '
        Me.txtCodigoFNC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoFNC.Location = New System.Drawing.Point(123, 42)
        Me.txtCodigoFNC.MaxLength = 9
        Me.txtCodigoFNC.Name = "txtCodigoFNC"
        Me.txtCodigoFNC.Size = New System.Drawing.Size(102, 20)
        Me.txtCodigoFNC.TabIndex = 51
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(9, 45)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 13)
        Me.lblCodigo.TabIndex = 54
        Me.lblCodigo.Text = "Código de Ficha:"
        '
        'mtbNumeroSesion
        '
        Me.mtbNumeroSesion.Location = New System.Drawing.Point(554, 42)
        Me.mtbNumeroSesion.Mask = "00-000-0000"
        Me.mtbNumeroSesion.Name = "mtbNumeroSesion"
        Me.mtbNumeroSesion.Size = New System.Drawing.Size(110, 20)
        Me.mtbNumeroSesion.TabIndex = 52
        '
        'lblSesion
        '
        Me.lblSesion.AutoSize = True
        Me.lblSesion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSesion.Location = New System.Drawing.Point(456, 48)
        Me.lblSesion.Name = "lblSesion"
        Me.lblSesion.Size = New System.Drawing.Size(83, 13)
        Me.lblSesion.TabIndex = 53
        Me.lblSesion.Text = "No. Resolución:"
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(356, 19)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(388, 20)
        Me.txtNombreSocia.TabIndex = 1
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(255, 19)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(103, 13)
        Me.lblNombreSocia.TabIndex = 50
        Me.lblNombreSocia.Text = "Nombre de la Socia:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(123, 16)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 0
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(5, 19)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 32
        Me.lblCedula.Text = "Número Cédula:"
        '
        'grpGrupoSeleccion
        '
        Me.grpGrupoSeleccion.Controls.Add(Me.Label16)
        Me.grpGrupoSeleccion.Controls.Add(Me.txtNombreFuenteFinanciamiento)
        Me.grpGrupoSeleccion.Controls.Add(Me.grdSeleccion)
        Me.grpGrupoSeleccion.Controls.Add(Me.cmdRegresarDetalle)
        Me.grpGrupoSeleccion.Controls.Add(Me.Label10)
        Me.grpGrupoSeleccion.Controls.Add(Me.cdeFechaC)
        Me.grpGrupoSeleccion.Controls.Add(Me.cmdListar)
        Me.grpGrupoSeleccion.Controls.Add(Me.cboGrupo)
        Me.grpGrupoSeleccion.Controls.Add(Me.Label6)
        Me.grpGrupoSeleccion.Controls.Add(Me.cmdCancelarG)
        Me.grpGrupoSeleccion.Controls.Add(Me.cmdAceptarG)
        Me.grpGrupoSeleccion.Controls.Add(Me.txtGrupoCodigo)
        Me.grpGrupoSeleccion.Controls.Add(Me.txtGrupoNombre)
        Me.grpGrupoSeleccion.Controls.Add(Me.txtGrupoId)
        Me.grpGrupoSeleccion.Controls.Add(Me.Label9)
        Me.grpGrupoSeleccion.Controls.Add(Me.Label8)
        Me.grpGrupoSeleccion.Controls.Add(Me.Label7)
        Me.grpGrupoSeleccion.Location = New System.Drawing.Point(12, 39)
        Me.grpGrupoSeleccion.Name = "grpGrupoSeleccion"
        Me.grpGrupoSeleccion.Size = New System.Drawing.Size(813, 689)
        Me.grpGrupoSeleccion.TabIndex = 49
        Me.grpGrupoSeleccion.TabStop = False
        Me.grpGrupoSeleccion.Text = "Seleccione los Creditos de las Socias del Grupo para hacer Notas"
        Me.grpGrupoSeleccion.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(146, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 68
        Me.Label16.Text = "Fuente :"
        '
        'txtNombreFuenteFinanciamiento
        '
        Me.txtNombreFuenteFinanciamiento.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreFuenteFinanciamiento.Enabled = False
        Me.txtNombreFuenteFinanciamiento.Location = New System.Drawing.Point(202, 86)
        Me.txtNombreFuenteFinanciamiento.Name = "txtNombreFuenteFinanciamiento"
        Me.txtNombreFuenteFinanciamiento.Size = New System.Drawing.Size(340, 20)
        Me.txtNombreFuenteFinanciamiento.TabIndex = 67
        '
        'grdSeleccion
        '
        Me.grdSeleccion.AllowFilter = False
        Me.grdSeleccion.Caption = "Listado de Socias en el Grupo para esta fuente y delegacion"
        Me.grdSeleccion.ColumnFooters = True
        Me.grdSeleccion.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSeleccion.FilterBar = True
        Me.grdSeleccion.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSeleccion.Images.Add(CType(resources.GetObject("grdSeleccion.Images"), System.Drawing.Image))
        Me.grdSeleccion.Location = New System.Drawing.Point(11, 130)
        Me.grdSeleccion.Name = "grdSeleccion"
        Me.grdSeleccion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSeleccion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSeleccion.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSeleccion.PrintInfo.PageSettings = CType(resources.GetObject("grdSeleccion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSeleccion.Size = New System.Drawing.Size(787, 288)
        Me.grdSeleccion.TabIndex = 66
        Me.grdSeleccion.Text = "grdSolicitud"
        Me.grdSeleccion.PropBag = resources.GetString("grdSeleccion.PropBag")
        '
        'cmdRegresarDetalle
        '
        Me.cmdRegresarDetalle.Image = Global.SMUSURA0.My.Resources.Resources.leftarrow
        Me.cmdRegresarDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdRegresarDetalle.Location = New System.Drawing.Point(6, 552)
        Me.cmdRegresarDetalle.Name = "cmdRegresarDetalle"
        Me.cmdRegresarDetalle.Size = New System.Drawing.Size(100, 47)
        Me.cmdRegresarDetalle.TabIndex = 65
        Me.cmdRegresarDetalle.Text = "Regresar al Detalle"
        Me.cmdRegresarDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdRegresarDetalle.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(553, 93)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 64
        Me.Label10.Text = "Fecha :"
        '
        'cdeFechaC
        '
        Me.cdeFechaC.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaC.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaC.Enabled = False
        Me.cdeFechaC.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaC.Location = New System.Drawing.Point(599, 89)
        Me.cdeFechaC.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaC.MaskInfo.EmptyAsNull = True
        Me.cdeFechaC.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaC.Name = "cdeFechaC"
        Me.cdeFechaC.Size = New System.Drawing.Size(121, 20)
        Me.cdeFechaC.TabIndex = 63
        Me.cdeFechaC.Tag = Nothing
        Me.cdeFechaC.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cmdListar
        '
        Me.cmdListar.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.cmdListar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdListar.Location = New System.Drawing.Point(489, 19)
        Me.cmdListar.Name = "cmdListar"
        Me.cmdListar.Size = New System.Drawing.Size(106, 25)
        Me.cmdListar.TabIndex = 62
        Me.cmdListar.Text = "Listar Creditos"
        Me.cmdListar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdListar.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboGrupo.AutoCompletion = True
        Me.cboGrupo.Caption = ""
        Me.cboGrupo.CaptionHeight = 17
        Me.cboGrupo.CaptionStyle = Style25
        Me.cboGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboGrupo.ColumnCaptionHeight = 17
        Me.cboGrupo.ColumnFooterHeight = 17
        Me.cboGrupo.ContentHeight = 15
        Me.cboGrupo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboGrupo.DisplayMember = "nSclGrupoSolidarioID"
        Me.cboGrupo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboGrupo.DropDownWidth = 500
        Me.cboGrupo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboGrupo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboGrupo.EditorHeight = 15
        Me.cboGrupo.EvenRowStyle = Style26
        Me.cboGrupo.ExtendRightColumn = True
        Me.cboGrupo.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboGrupo.FooterStyle = Style27
        Me.cboGrupo.GapHeight = 2
        Me.cboGrupo.HeadingStyle = Style28
        Me.cboGrupo.HighLightRowStyle = Style29
        Me.cboGrupo.Images.Add(CType(resources.GetObject("cboGrupo.Images"), System.Drawing.Image))
        Me.cboGrupo.ItemHeight = 15
        Me.cboGrupo.LimitToList = True
        Me.cboGrupo.Location = New System.Drawing.Point(61, 19)
        Me.cboGrupo.MatchEntryTimeout = CType(2000, Long)
        Me.cboGrupo.MaxDropDownItems = CType(5, Short)
        Me.cboGrupo.MaxLength = 32767
        Me.cboGrupo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.OddRowStyle = Style30
        Me.cboGrupo.PartialRightColumn = False
        Me.cboGrupo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboGrupo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboGrupo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboGrupo.SelectedStyle = Style31
        Me.cboGrupo.Size = New System.Drawing.Size(402, 21)
        Me.cboGrupo.Style = Style32
        Me.cboGrupo.SuperBack = True
        Me.cboGrupo.TabIndex = 60
        Me.cboGrupo.ValueMember = "nSclGrupoSolidarioID"
        Me.cboGrupo.PropBag = resources.GetString("cboGrupo.PropBag")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(13, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 61
        Me.Label6.Text = "Grupo:"
        '
        'cmdCancelarG
        '
        Me.cmdCancelarG.Enabled = False
        Me.cmdCancelarG.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.cmdCancelarG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelarG.Location = New System.Drawing.Point(693, 552)
        Me.cmdCancelarG.Name = "cmdCancelarG"
        Me.cmdCancelarG.Size = New System.Drawing.Size(89, 47)
        Me.cmdCancelarG.TabIndex = 58
        Me.cmdCancelarG.Text = "Regresar a Grupos"
        Me.cmdCancelarG.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelarG.UseVisualStyleBackColor = True
        '
        'cmdAceptarG
        '
        Me.cmdAceptarG.Enabled = False
        Me.cmdAceptarG.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
        Me.cmdAceptarG.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdAceptarG.Location = New System.Drawing.Point(569, 552)
        Me.cmdAceptarG.Name = "cmdAceptarG"
        Me.cmdAceptarG.Size = New System.Drawing.Size(100, 47)
        Me.cmdAceptarG.TabIndex = 57
        Me.cmdAceptarG.Text = "Ingresar Seleccionadas"
        Me.cmdAceptarG.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAceptarG.UseVisualStyleBackColor = True
        '
        'txtGrupoCodigo
        '
        Me.txtGrupoCodigo.AcceptsReturn = True
        Me.txtGrupoCodigo.Enabled = False
        Me.txtGrupoCodigo.Location = New System.Drawing.Point(599, 60)
        Me.txtGrupoCodigo.Name = "txtGrupoCodigo"
        Me.txtGrupoCodigo.Size = New System.Drawing.Size(121, 20)
        Me.txtGrupoCodigo.TabIndex = 54
        '
        'txtGrupoNombre
        '
        Me.txtGrupoNombre.AcceptsReturn = True
        Me.txtGrupoNombre.Enabled = False
        Me.txtGrupoNombre.Location = New System.Drawing.Point(202, 56)
        Me.txtGrupoNombre.Name = "txtGrupoNombre"
        Me.txtGrupoNombre.Size = New System.Drawing.Size(341, 20)
        Me.txtGrupoNombre.TabIndex = 53
        '
        'txtGrupoId
        '
        Me.txtGrupoId.AcceptsReturn = True
        Me.txtGrupoId.Enabled = False
        Me.txtGrupoId.Location = New System.Drawing.Point(61, 56)
        Me.txtGrupoId.Name = "txtGrupoId"
        Me.txtGrupoId.Size = New System.Drawing.Size(61, 20)
        Me.txtGrupoId.TabIndex = 52
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(556, 62)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Codigo :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(146, 60)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 50
        Me.Label8.Text = "Nombre :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(13, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 13)
        Me.Label7.TabIndex = 49
        Me.Label7.Text = "Id :"
        '
        'cmdSalir
        '
        Me.cmdSalir.Image = Global.SMUSURA0.My.Resources.Resources.Salir
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(753, 1)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(71, 32)
        Me.cmdSalir.TabIndex = 56
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'grdDetalles
        '
        Me.grdDetalles.AllowFilter = False
        Me.grdDetalles.AllowUpdate = False
        Me.grdDetalles.Caption = "Detalles de Fichas de la Nota"
        Me.grdDetalles.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDetalles.FilterBar = True
        Me.grdDetalles.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDetalles.Images.Add(CType(resources.GetObject("grdDetalles.Images"), System.Drawing.Image))
        Me.grdDetalles.Location = New System.Drawing.Point(18, 536)
        Me.grdDetalles.Name = "grdDetalles"
        Me.grdDetalles.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetalles.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetalles.PreviewInfo.ZoomFactor = 75.0R
        Me.grdDetalles.PrintInfo.PageSettings = CType(resources.GetObject("grdDetalles.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetalles.Size = New System.Drawing.Size(807, 192)
        Me.grdDetalles.TabIndex = 55
        Me.grdDetalles.Text = "grdDetalles"
        Me.grdDetalles.PropBag = resources.GetString("grdDetalles.PropBag")
        '
        'cmdModificar
        '
        Me.cmdModificar.Image = Global.SMUSURA0.My.Resources.Resources.edit
        Me.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdModificar.Location = New System.Drawing.Point(17, 1)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(71, 31)
        Me.cmdModificar.TabIndex = 14
        Me.cmdModificar.Text = "Modificar "
        Me.cmdModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'FrmSccEditNotaDebitoCredito
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(836, 736)
        Me.ControlBox = False
        Me.Controls.Add(Me.grpGrupoSeleccion)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.grdDetalles)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.grpDatosFicha)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.Name = "FrmSccEditNotaDebitoCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nota de Debito Credito"
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        Me.grpGrupoInicial.ResumeLayout(False)
        Me.grpGrupoInicial.PerformLayout()
        CType(Me.cdeFechaCS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboGrupoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDelegacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosFicha.ResumeLayout(False)
        Me.GrpCedulaSocia.ResumeLayout(False)
        Me.GrpCedulaSocia.PerformLayout()
        CType(Me.cneMontoFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGrupoSeleccion.ResumeLayout(False)
        Me.grpGrupoSeleccion.PerformLayout()
        CType(Me.grdSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cneMonto As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cdeFechaTC As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaS As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblFechaTC As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errSolicitud As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents cboFuente As C1.Win.C1List.C1Combo
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents cboDelegacion As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpDatosFicha As System.Windows.Forms.GroupBox
    Friend WithEvents GrpCedulaSocia As System.Windows.Forms.GroupBox
    Friend WithEvents txtnSclFichaDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoGrupo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoFNC As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents mtbNumeroSesion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblSesion As System.Windows.Forms.Label
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents cmdAgregar As System.Windows.Forms.Button
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkEsDebito As System.Windows.Forms.CheckBox
    Friend WithEvents cmdModificar As System.Windows.Forms.Button
    Friend WithEvents cneMontoFicha As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents grdDetalles As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents cmdBuscarG As System.Windows.Forms.Button
    Friend WithEvents grpGrupoSeleccion As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGrupoCodigo As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelarG As System.Windows.Forms.Button
    Friend WithEvents cmdAceptarG As System.Windows.Forms.Button
    Friend WithEvents cboGrupo As C1.Win.C1List.C1Combo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGrupoNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtGrupoId As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdListar As System.Windows.Forms.Button
    Friend WithEvents cdeFechaC As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdRegresarDetalle As System.Windows.Forms.Button
    Friend WithEvents grpGrupoInicial As System.Windows.Forms.GroupBox
    Friend WithEvents cboGrupoS As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtGrupoCodigoS As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtGrupoNombreS As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtGrupoIdS As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cdeFechaCS As C1.Win.C1Input.C1DateEdit
    Friend WithEvents grdSeleccion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtNombreFuenteFinanciamiento As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtAnio As System.Windows.Forms.TextBox
End Class
