<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditArregloPago
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditArregloPago))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tabArregloPago = New C1.Win.C1Command.C1DockingTab
        Me.tabDatosGrales = New C1.Win.C1Command.C1DockingTabPage
        Me.grpObservaciones = New System.Windows.Forms.GroupBox
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox
        Me.txtMontoEC = New System.Windows.Forms.TextBox
        Me.txtNoCredito = New System.Windows.Forms.TextBox
        Me.cneMonto = New C1.Win.C1Input.C1NumericEdit
        Me.txtNombreGrupo = New System.Windows.Forms.TextBox
        Me.lblGrupo = New System.Windows.Forms.Label
        Me.lblMontoArreglo = New System.Windows.Forms.Label
        Me.txtNombreSocia = New System.Windows.Forms.TextBox
        Me.cboTecnico = New C1.Win.C1List.C1Combo
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.lblTecnico = New System.Windows.Forms.Label
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox
        Me.cdeFechaA = New C1.Win.C1Input.C1DateEdit
        Me.lblCedula = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.lblNombre = New System.Windows.Forms.Label
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.lblSeguimiento = New System.Windows.Forms.Label
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.txtFichaNotificacionDetalleID = New System.Windows.Forms.TextBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.tabCuotas = New C1.Win.C1Command.C1DockingTabPage
        Me.grdCuotas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbCuotas = New System.Windows.Forms.ToolStrip
        Me.toolAgregarC = New System.Windows.Forms.ToolStripButton
        Me.toolModificarC = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarC = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarC = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaC = New System.Windows.Forms.ToolStripButton
        Me.grpDatosGralesC = New System.Windows.Forms.GroupBox
        Me.txtEstadoC = New System.Windows.Forms.TextBox
        Me.txtNumeroC = New System.Windows.Forms.TextBox
        Me.lblEstadoC = New System.Windows.Forms.Label
        Me.lblCodigoC = New System.Windows.Forms.Label
        Me.tabAbonos = New C1.Win.C1Command.C1DockingTabPage
        Me.grpDocumentos = New System.Windows.Forms.GroupBox
        Me.txtEstadoA = New System.Windows.Forms.TextBox
        Me.txtNumeroA = New System.Windows.Forms.TextBox
        Me.lblEstadoA = New System.Windows.Forms.Label
        Me.lblCodigoA = New System.Windows.Forms.Label
        Me.tbAbonos = New System.Windows.Forms.ToolStrip
        Me.toolAgregarA = New System.Windows.Forms.ToolStripButton
        Me.toolModificarA = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarA = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarA = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaA = New System.Windows.Forms.ToolStripButton
        Me.lblSinDisponibilidad = New System.Windows.Forms.Label
        Me.grdAbonos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.errArreglo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.tabArregloPago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabArregloPago.SuspendLayout()
        Me.tabDatosGrales.SuspendLayout()
        Me.grpObservaciones.SuspendLayout()
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCuotas.SuspendLayout()
        CType(Me.grdCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCuotas.SuspendLayout()
        Me.grpDatosGralesC.SuspendLayout()
        Me.tabAbonos.SuspendLayout()
        Me.grpDocumentos.SuspendLayout()
        Me.tbAbonos.SuspendLayout()
        CType(Me.grdAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errArreglo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabArregloPago
        '
        Me.tabArregloPago.BackColor = System.Drawing.SystemColors.Control
        Me.tabArregloPago.Controls.Add(Me.tabDatosGrales)
        Me.tabArregloPago.Controls.Add(Me.tabCuotas)
        Me.tabArregloPago.Controls.Add(Me.tabAbonos)
        Me.tabArregloPago.Location = New System.Drawing.Point(12, 12)
        Me.tabArregloPago.Name = "tabArregloPago"
        Me.tabArregloPago.SelectedIndex = 3
        Me.tabArregloPago.Size = New System.Drawing.Size(766, 587)
        Me.tabArregloPago.TabIndex = 0
        '
        'tabDatosGrales
        '
        Me.tabDatosGrales.Controls.Add(Me.grpObservaciones)
        Me.tabDatosGrales.Controls.Add(Me.grpDatosGenerales)
        Me.tabDatosGrales.Controls.Add(Me.cmdCancelar)
        Me.tabDatosGrales.Controls.Add(Me.CmdAceptar)
        Me.tabDatosGrales.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.tabDatosGrales.Location = New System.Drawing.Point(1, 27)
        Me.tabDatosGrales.Name = "tabDatosGrales"
        Me.tabDatosGrales.Size = New System.Drawing.Size(764, 559)
        Me.tabDatosGrales.TabIndex = 0
        Me.tabDatosGrales.Text = "Datos Generales"
        '
        'grpObservaciones
        '
        Me.grpObservaciones.Controls.Add(Me.txtObservaciones)
        Me.grpObservaciones.Controls.Add(Me.lblObservaciones)
        Me.grpObservaciones.Location = New System.Drawing.Point(21, 320)
        Me.grpObservaciones.Name = "grpObservaciones"
        Me.grpObservaciones.Size = New System.Drawing.Size(726, 183)
        Me.grpObservaciones.TabIndex = 2
        Me.grpObservaciones.TabStop = False
        Me.grpObservaciones.Text = "Observaciones: "
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(127, 19)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(568, 151)
        Me.txtObservaciones.TabIndex = 1
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(40, 19)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 0
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.txtMontoEC)
        Me.grpDatosGenerales.Controls.Add(Me.txtNoCredito)
        Me.grpDatosGenerales.Controls.Add(Me.cneMonto)
        Me.grpDatosGenerales.Controls.Add(Me.txtNombreGrupo)
        Me.grpDatosGenerales.Controls.Add(Me.lblGrupo)
        Me.grpDatosGenerales.Controls.Add(Me.lblMontoArreglo)
        Me.grpDatosGenerales.Controls.Add(Me.txtNombreSocia)
        Me.grpDatosGenerales.Controls.Add(Me.cboTecnico)
        Me.grpDatosGenerales.Controls.Add(Me.cmdBuscar)
        Me.grpDatosGenerales.Controls.Add(Me.lblTecnico)
        Me.grpDatosGenerales.Controls.Add(Me.mtbNumCedula)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaA)
        Me.grpDatosGenerales.Controls.Add(Me.lblCedula)
        Me.grpDatosGenerales.Controls.Add(Me.lblFecha)
        Me.grpDatosGenerales.Controls.Add(Me.lblNombre)
        Me.grpDatosGenerales.Controls.Add(Me.txtEstado)
        Me.grpDatosGenerales.Controls.Add(Me.lblSeguimiento)
        Me.grpDatosGenerales.Controls.Add(Me.txtNumero)
        Me.grpDatosGenerales.Controls.Add(Me.txtFichaNotificacionDetalleID)
        Me.grpDatosGenerales.Controls.Add(Me.lblEstado)
        Me.grpDatosGenerales.Controls.Add(Me.lblCodigo)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(21, 19)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(726, 295)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Arreglo de Pago: "
        '
        'txtMontoEC
        '
        Me.txtMontoEC.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoEC.Enabled = False
        Me.txtMontoEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoEC.Location = New System.Drawing.Point(302, 254)
        Me.txtMontoEC.Name = "txtMontoEC"
        Me.txtMontoEC.ReadOnly = True
        Me.txtMontoEC.Size = New System.Drawing.Size(58, 20)
        Me.txtMontoEC.TabIndex = 20
        Me.txtMontoEC.Tag = "LAYOUT:FLAT"
        Me.txtMontoEC.Visible = False
        '
        'txtNoCredito
        '
        Me.txtNoCredito.BackColor = System.Drawing.SystemColors.Info
        Me.txtNoCredito.Enabled = False
        Me.txtNoCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCredito.Location = New System.Drawing.Point(422, 156)
        Me.txtNoCredito.Name = "txtNoCredito"
        Me.txtNoCredito.ReadOnly = True
        Me.txtNoCredito.Size = New System.Drawing.Size(131, 20)
        Me.txtNoCredito.TabIndex = 12
        Me.txtNoCredito.Tag = "LAYOUT:FLAT"
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
        Me.cneMonto.Location = New System.Drawing.Point(153, 254)
        Me.cneMonto.MaskInfo.AutoTabWhenFilled = True
        Me.cneMonto.MaxLength = 999999999
        Me.cneMonto.Name = "cneMonto"
        Me.cneMonto.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMonto.Size = New System.Drawing.Size(146, 20)
        Me.cneMonto.TabIndex = 19
        Me.cneMonto.Tag = Nothing
        Me.cneMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMonto.UseColumnStyles = False
        Me.cneMonto.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txtNombreGrupo
        '
        Me.txtNombreGrupo.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreGrupo.Enabled = False
        Me.txtNombreGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreGrupo.Location = New System.Drawing.Point(152, 217)
        Me.txtNombreGrupo.Name = "txtNombreGrupo"
        Me.txtNombreGrupo.ReadOnly = True
        Me.txtNombreGrupo.Size = New System.Drawing.Size(401, 20)
        Me.txtNombreGrupo.TabIndex = 17
        Me.txtNombreGrupo.Tag = "LAYOUT:FLAT"
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupo.Location = New System.Drawing.Point(40, 220)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(82, 13)
        Me.lblGrupo.TabIndex = 16
        Me.lblGrupo.Text = "Grupo Solidario:"
        '
        'lblMontoArreglo
        '
        Me.lblMontoArreglo.AutoSize = True
        Me.lblMontoArreglo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMontoArreglo.Location = New System.Drawing.Point(40, 254)
        Me.lblMontoArreglo.Name = "lblMontoArreglo"
        Me.lblMontoArreglo.Size = New System.Drawing.Size(104, 13)
        Me.lblMontoArreglo.TabIndex = 18
        Me.lblMontoArreglo.Text = "Monto Arreglo Pago:"
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(152, 188)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(401, 20)
        Me.txtNombreSocia.TabIndex = 15
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'cboTecnico
        '
        Me.cboTecnico.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTecnico.AutoCompletion = True
        Me.cboTecnico.Caption = ""
        Me.cboTecnico.CaptionHeight = 17
        Me.cboTecnico.CaptionStyle = Style1
        Me.cboTecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTecnico.ColumnCaptionHeight = 17
        Me.cboTecnico.ColumnFooterHeight = 17
        Me.cboTecnico.ContentHeight = 15
        Me.cboTecnico.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTecnico.DisplayMember = "sNombreEmpleado"
        Me.cboTecnico.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTecnico.DropDownWidth = 423
        Me.cboTecnico.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTecnico.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTecnico.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTecnico.EditorHeight = 15
        Me.cboTecnico.EvenRowStyle = Style2
        Me.cboTecnico.ExtendRightColumn = True
        Me.cboTecnico.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTecnico.FooterStyle = Style3
        Me.cboTecnico.GapHeight = 2
        Me.cboTecnico.HeadingStyle = Style4
        Me.cboTecnico.HighLightRowStyle = Style5
        Me.cboTecnico.Images.Add(CType(resources.GetObject("cboTecnico.Images"), System.Drawing.Image))
        Me.cboTecnico.ItemHeight = 15
        Me.cboTecnico.LimitToList = True
        Me.cboTecnico.Location = New System.Drawing.Point(152, 121)
        Me.cboTecnico.MatchEntryTimeout = CType(2000, Long)
        Me.cboTecnico.MaxDropDownItems = CType(5, Short)
        Me.cboTecnico.MaxLength = 32767
        Me.cboTecnico.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTecnico.Name = "cboTecnico"
        Me.cboTecnico.OddRowStyle = Style6
        Me.cboTecnico.PartialRightColumn = False
        Me.cboTecnico.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTecnico.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTecnico.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTecnico.SelectedStyle = Style7
        Me.cboTecnico.Size = New System.Drawing.Size(401, 21)
        Me.cboTecnico.Style = Style8
        Me.cboTecnico.SuperBack = True
        Me.cboTecnico.TabIndex = 7
        Me.cboTecnico.ValueMember = "nSrhEmpleadoID"
        Me.cboTecnico.PropBag = resources.GetString("cboTecnico.PropBag")
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(281, 151)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(64, 25)
        Me.cmdBuscar.TabIndex = 10
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'lblTecnico
        '
        Me.lblTecnico.AutoSize = True
        Me.lblTecnico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTecnico.Location = New System.Drawing.Point(40, 121)
        Me.lblTecnico.Name = "lblTecnico"
        Me.lblTecnico.Size = New System.Drawing.Size(106, 13)
        Me.lblTecnico.TabIndex = 6
        Me.lblTecnico.Text = "Nombre del Técnico:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(152, 152)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 9
        '
        'cdeFechaA
        '
        Me.cdeFechaA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaA.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaA.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaA.Location = New System.Drawing.Point(152, 89)
        Me.cdeFechaA.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaA.MaskInfo.EmptyAsNull = True
        Me.cdeFechaA.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaA.Name = "cdeFechaA"
        Me.cdeFechaA.Size = New System.Drawing.Size(146, 20)
        Me.cdeFechaA.TabIndex = 5
        Me.cdeFechaA.Tag = Nothing
        Me.cdeFechaA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(39, 158)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 8
        Me.lblCedula.Text = "Número Cédula:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(40, 89)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(76, 13)
        Me.lblFecha.TabIndex = 4
        Me.lblFecha.Text = "Fecha Arreglo:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(40, 188)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(77, 13)
        Me.lblNombre.TabIndex = 14
        Me.lblNombre.Text = "Nombre Socia:"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(152, 57)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.ShortcutsEnabled = False
        Me.txtEstado.Size = New System.Drawing.Size(146, 20)
        Me.txtEstado.TabIndex = 3
        Me.txtEstado.Tag = "LAYOUT:FLAT"
        '
        'lblSeguimiento
        '
        Me.lblSeguimiento.AutoSize = True
        Me.lblSeguimiento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSeguimiento.Location = New System.Drawing.Point(355, 159)
        Me.lblSeguimiento.Name = "lblSeguimiento"
        Me.lblSeguimiento.Size = New System.Drawing.Size(63, 13)
        Me.lblSeguimiento.TabIndex = 11
        Me.lblSeguimiento.Text = "Crédito No.:"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumero.Enabled = False
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(152, 31)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.ShortcutsEnabled = False
        Me.txtNumero.Size = New System.Drawing.Size(146, 20)
        Me.txtNumero.TabIndex = 1
        Me.txtNumero.Tag = "LAYOUT:FLAT"
        '
        'txtFichaNotificacionDetalleID
        '
        Me.txtFichaNotificacionDetalleID.BackColor = System.Drawing.SystemColors.Info
        Me.txtFichaNotificacionDetalleID.Enabled = False
        Me.txtFichaNotificacionDetalleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFichaNotificacionDetalleID.Location = New System.Drawing.Point(574, 155)
        Me.txtFichaNotificacionDetalleID.Name = "txtFichaNotificacionDetalleID"
        Me.txtFichaNotificacionDetalleID.ReadOnly = True
        Me.txtFichaNotificacionDetalleID.Size = New System.Drawing.Size(58, 20)
        Me.txtFichaNotificacionDetalleID.TabIndex = 13
        Me.txtFichaNotificacionDetalleID.Tag = "LAYOUT:FLAT"
        Me.txtFichaNotificacionDetalleID.Visible = False
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(40, 60)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(79, 13)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Estado Arreglo:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(40, 31)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(63, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Arreglo No.:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(674, 528)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(595, 528)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 3
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'tabCuotas
        '
        Me.tabCuotas.Controls.Add(Me.grdCuotas)
        Me.tabCuotas.Controls.Add(Me.tbCuotas)
        Me.tabCuotas.Controls.Add(Me.grpDatosGralesC)
        Me.tabCuotas.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.tabCuotas.Location = New System.Drawing.Point(1, 27)
        Me.tabCuotas.Name = "tabCuotas"
        Me.tabCuotas.Size = New System.Drawing.Size(764, 559)
        Me.tabCuotas.TabIndex = 2
        Me.tabCuotas.Text = "Cuotas Arreglo de Pago"
        '
        'grdCuotas
        '
        Me.grdCuotas.AllowFilter = False
        Me.grdCuotas.AllowUpdate = False
        Me.grdCuotas.Caption = "Cuotas Arreglo de Pago"
        Me.grdCuotas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdCuotas.FilterBar = True
        Me.grdCuotas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdCuotas.Images.Add(CType(resources.GetObject("grdCuotas.Images"), System.Drawing.Image))
        Me.grdCuotas.Location = New System.Drawing.Point(21, 96)
        Me.grdCuotas.Name = "grdCuotas"
        Me.grdCuotas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCuotas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCuotas.PreviewInfo.ZoomFactor = 75
        Me.grdCuotas.PrintInfo.PageSettings = CType(resources.GetObject("grdCuotas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCuotas.Size = New System.Drawing.Size(728, 442)
        Me.grdCuotas.TabIndex = 23
        Me.grdCuotas.Text = "grdArqueoEfectivo"
        Me.grdCuotas.PropBag = resources.GetString("grdCuotas.PropBag")
        '
        'tbCuotas
        '
        Me.tbCuotas.AutoSize = False
        Me.tbCuotas.Dock = System.Windows.Forms.DockStyle.None
        Me.tbCuotas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarC, Me.toolModificarC, Me.toolEliminarC, Me.ToolStripSeparator2, Me.toolRefrescarC, Me.ToolStripSeparator3, Me.toolAyudaC})
        Me.tbCuotas.Location = New System.Drawing.Point(21, 68)
        Me.tbCuotas.Name = "tbCuotas"
        Me.tbCuotas.Size = New System.Drawing.Size(728, 25)
        Me.tbCuotas.Stretch = True
        Me.tbCuotas.TabIndex = 22
        Me.tbCuotas.Text = "ToolStrip1"
        Me.tbCuotas.Visible = False
        '
        'toolAgregarC
        '
        Me.toolAgregarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarC.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregarC.Name = "toolAgregarC"
        Me.toolAgregarC.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarC.Text = "Agregar Cuota"
        Me.toolAgregarC.ToolTipText = "Agregar Cuota"
        '
        'toolModificarC
        '
        Me.toolModificarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarC.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarC.Name = "toolModificarC"
        Me.toolModificarC.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarC.Text = "Modificar Cuota"
        Me.toolModificarC.ToolTipText = "Modificar Cuota"
        '
        'toolEliminarC
        '
        Me.toolEliminarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarC.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEliminarC.Name = "toolEliminarC"
        Me.toolEliminarC.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarC.Text = "Eliminar Cuota"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarC
        '
        Me.toolRefrescarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarC.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarC.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarC.Name = "toolRefrescarC"
        Me.toolRefrescarC.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarC.Text = "Refrescar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaC
        '
        Me.toolAyudaC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaC.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaC.Name = "toolAyudaC"
        Me.toolAyudaC.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaC.Text = "Ayuda"
        Me.toolAyudaC.ToolTipText = "Ayuda"
        '
        'grpDatosGralesC
        '
        Me.grpDatosGralesC.Controls.Add(Me.txtEstadoC)
        Me.grpDatosGralesC.Controls.Add(Me.txtNumeroC)
        Me.grpDatosGralesC.Controls.Add(Me.lblEstadoC)
        Me.grpDatosGralesC.Controls.Add(Me.lblCodigoC)
        Me.grpDatosGralesC.Location = New System.Drawing.Point(21, 14)
        Me.grpDatosGralesC.Name = "grpDatosGralesC"
        Me.grpDatosGralesC.Size = New System.Drawing.Size(728, 51)
        Me.grpDatosGralesC.TabIndex = 0
        Me.grpDatosGralesC.TabStop = False
        Me.grpDatosGralesC.Text = "Datos Generales"
        '
        'txtEstadoC
        '
        Me.txtEstadoC.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstadoC.Enabled = False
        Me.txtEstadoC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoC.Location = New System.Drawing.Point(293, 19)
        Me.txtEstadoC.Name = "txtEstadoC"
        Me.txtEstadoC.ReadOnly = True
        Me.txtEstadoC.ShortcutsEnabled = False
        Me.txtEstadoC.Size = New System.Drawing.Size(146, 20)
        Me.txtEstadoC.TabIndex = 35
        Me.txtEstadoC.Tag = "LAYOUT:FLAT"
        '
        'txtNumeroC
        '
        Me.txtNumeroC.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumeroC.Enabled = False
        Me.txtNumeroC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroC.Location = New System.Drawing.Point(95, 19)
        Me.txtNumeroC.Name = "txtNumeroC"
        Me.txtNumeroC.ReadOnly = True
        Me.txtNumeroC.ShortcutsEnabled = False
        Me.txtNumeroC.Size = New System.Drawing.Size(115, 20)
        Me.txtNumeroC.TabIndex = 34
        Me.txtNumeroC.Tag = "LAYOUT:FLAT"
        '
        'lblEstadoC
        '
        Me.lblEstadoC.AutoSize = True
        Me.lblEstadoC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstadoC.Location = New System.Drawing.Point(216, 22)
        Me.lblEstadoC.Name = "lblEstadoC"
        Me.lblEstadoC.Size = New System.Drawing.Size(79, 13)
        Me.lblEstadoC.TabIndex = 33
        Me.lblEstadoC.Text = "Estado Arreglo:"
        '
        'lblCodigoC
        '
        Me.lblCodigoC.AutoSize = True
        Me.lblCodigoC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoC.Location = New System.Drawing.Point(17, 22)
        Me.lblCodigoC.Name = "lblCodigoC"
        Me.lblCodigoC.Size = New System.Drawing.Size(63, 13)
        Me.lblCodigoC.TabIndex = 32
        Me.lblCodigoC.Text = "Arreglo No.:"
        '
        'tabAbonos
        '
        Me.tabAbonos.Controls.Add(Me.grpDocumentos)
        Me.tabAbonos.Controls.Add(Me.tbAbonos)
        Me.tabAbonos.Controls.Add(Me.lblSinDisponibilidad)
        Me.tabAbonos.Controls.Add(Me.grdAbonos)
        Me.tabAbonos.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.tabAbonos.Location = New System.Drawing.Point(1, 27)
        Me.tabAbonos.Name = "tabAbonos"
        Me.tabAbonos.Size = New System.Drawing.Size(764, 559)
        Me.tabAbonos.TabIndex = 1
        Me.tabAbonos.Text = "Abonos Realizados"
        '
        'grpDocumentos
        '
        Me.grpDocumentos.Controls.Add(Me.txtEstadoA)
        Me.grpDocumentos.Controls.Add(Me.txtNumeroA)
        Me.grpDocumentos.Controls.Add(Me.lblEstadoA)
        Me.grpDocumentos.Controls.Add(Me.lblCodigoA)
        Me.grpDocumentos.Location = New System.Drawing.Point(21, 14)
        Me.grpDocumentos.Name = "grpDocumentos"
        Me.grpDocumentos.Size = New System.Drawing.Size(728, 51)
        Me.grpDocumentos.TabIndex = 21
        Me.grpDocumentos.TabStop = False
        Me.grpDocumentos.Text = "Datos Generales"
        '
        'txtEstadoA
        '
        Me.txtEstadoA.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstadoA.Enabled = False
        Me.txtEstadoA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoA.Location = New System.Drawing.Point(293, 19)
        Me.txtEstadoA.Name = "txtEstadoA"
        Me.txtEstadoA.ReadOnly = True
        Me.txtEstadoA.ShortcutsEnabled = False
        Me.txtEstadoA.Size = New System.Drawing.Size(148, 20)
        Me.txtEstadoA.TabIndex = 35
        Me.txtEstadoA.Tag = "LAYOUT:FLAT"
        '
        'txtNumeroA
        '
        Me.txtNumeroA.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumeroA.Enabled = False
        Me.txtNumeroA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroA.Location = New System.Drawing.Point(95, 19)
        Me.txtNumeroA.Name = "txtNumeroA"
        Me.txtNumeroA.ReadOnly = True
        Me.txtNumeroA.ShortcutsEnabled = False
        Me.txtNumeroA.Size = New System.Drawing.Size(115, 20)
        Me.txtNumeroA.TabIndex = 34
        Me.txtNumeroA.Tag = "LAYOUT:FLAT"
        '
        'lblEstadoA
        '
        Me.lblEstadoA.AutoSize = True
        Me.lblEstadoA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstadoA.Location = New System.Drawing.Point(216, 22)
        Me.lblEstadoA.Name = "lblEstadoA"
        Me.lblEstadoA.Size = New System.Drawing.Size(79, 13)
        Me.lblEstadoA.TabIndex = 33
        Me.lblEstadoA.Text = "Estado Arreglo:"
        '
        'lblCodigoA
        '
        Me.lblCodigoA.AutoSize = True
        Me.lblCodigoA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoA.Location = New System.Drawing.Point(17, 22)
        Me.lblCodigoA.Name = "lblCodigoA"
        Me.lblCodigoA.Size = New System.Drawing.Size(63, 13)
        Me.lblCodigoA.TabIndex = 32
        Me.lblCodigoA.Text = "Arreglo No.:"
        '
        'tbAbonos
        '
        Me.tbAbonos.AutoSize = False
        Me.tbAbonos.Dock = System.Windows.Forms.DockStyle.None
        Me.tbAbonos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarA, Me.toolModificarA, Me.toolEliminarA, Me.toolSeparador1, Me.toolRefrescarA, Me.toolSeparador2, Me.toolAyudaA})
        Me.tbAbonos.Location = New System.Drawing.Point(21, 68)
        Me.tbAbonos.Name = "tbAbonos"
        Me.tbAbonos.Size = New System.Drawing.Size(728, 25)
        Me.tbAbonos.Stretch = True
        Me.tbAbonos.TabIndex = 20
        Me.tbAbonos.Text = "ToolStrip1"
        Me.tbAbonos.Visible = False
        '
        'toolAgregarA
        '
        Me.toolAgregarA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarA.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarA.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarA.Name = "toolAgregarA"
        Me.toolAgregarA.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarA.Text = "Agregar Abono"
        Me.toolAgregarA.ToolTipText = "Agregar Abono"
        '
        'toolModificarA
        '
        Me.toolModificarA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarA.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarA.Name = "toolModificarA"
        Me.toolModificarA.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarA.Text = "Modificar Abono"
        Me.toolModificarA.ToolTipText = "Modificar Abono"
        '
        'toolEliminarA
        '
        Me.toolEliminarA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarA.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarA.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarA.Name = "toolEliminarA"
        Me.toolEliminarA.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarA.Text = "Eliminar Abono"
        '
        'toolSeparador1
        '
        Me.toolSeparador1.Name = "toolSeparador1"
        Me.toolSeparador1.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarA
        '
        Me.toolRefrescarA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarA.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarA.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarA.Name = "toolRefrescarA"
        Me.toolRefrescarA.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarA.Text = "Refrescar"
        '
        'toolSeparador2
        '
        Me.toolSeparador2.Name = "toolSeparador2"
        Me.toolSeparador2.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaA
        '
        Me.toolAyudaA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaA.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaA.Name = "toolAyudaA"
        Me.toolAyudaA.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaA.Text = "Ayuda"
        Me.toolAyudaA.ToolTipText = "Ayuda"
        '
        'lblSinDisponibilidad
        '
        Me.lblSinDisponibilidad.AutoSize = True
        Me.lblSinDisponibilidad.Location = New System.Drawing.Point(18, 452)
        Me.lblSinDisponibilidad.Name = "lblSinDisponibilidad"
        Me.lblSinDisponibilidad.Size = New System.Drawing.Size(0, 13)
        Me.lblSinDisponibilidad.TabIndex = 19
        '
        'grdAbonos
        '
        Me.grdAbonos.AllowFilter = False
        Me.grdAbonos.AllowUpdate = False
        Me.grdAbonos.Caption = "Abonos Realizados"
        Me.grdAbonos.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdAbonos.FilterBar = True
        Me.grdAbonos.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdAbonos.Images.Add(CType(resources.GetObject("grdAbonos.Images"), System.Drawing.Image))
        Me.grdAbonos.Location = New System.Drawing.Point(21, 96)
        Me.grdAbonos.Name = "grdAbonos"
        Me.grdAbonos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAbonos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAbonos.PreviewInfo.ZoomFactor = 75
        Me.grdAbonos.PrintInfo.PageSettings = CType(resources.GetObject("grdAbonos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAbonos.Size = New System.Drawing.Size(728, 442)
        Me.grdAbonos.TabIndex = 16
        Me.grdAbonos.Text = "grdArqueoDocumentos"
        Me.grdAbonos.PropBag = resources.GetString("grdAbonos.PropBag")
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'errArreglo
        '
        Me.errArreglo.ContainerControl = Me
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'toolEliminar
        '
        Me.toolEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminar.Name = "toolEliminar"
        Me.toolEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminar.Text = "Eliminar"
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 22)
        Me.toolAyuda.Text = "Ayuda"
        Me.toolAyuda.ToolTipText = "Ayuda"
        '
        'frmSccEditArregloPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 611)
        Me.Controls.Add(Me.tabArregloPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Arqueo de Cajas")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditArregloPago"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Arreglos de Pago"
        CType(Me.tabArregloPago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabArregloPago.ResumeLayout(False)
        Me.tabDatosGrales.ResumeLayout(False)
        Me.grpObservaciones.ResumeLayout(False)
        Me.grpObservaciones.PerformLayout()
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCuotas.ResumeLayout(False)
        CType(Me.grdCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCuotas.ResumeLayout(False)
        Me.tbCuotas.PerformLayout()
        Me.grpDatosGralesC.ResumeLayout(False)
        Me.grpDatosGralesC.PerformLayout()
        Me.tabAbonos.ResumeLayout(False)
        Me.tabAbonos.PerformLayout()
        Me.grpDocumentos.ResumeLayout(False)
        Me.grpDocumentos.PerformLayout()
        Me.tbAbonos.ResumeLayout(False)
        Me.tbAbonos.PerformLayout()
        CType(Me.grdAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errArreglo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabArregloPago As C1.Win.C1Command.C1DockingTab
    Friend WithEvents tabDatosGrales As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents tabAbonos As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grdAbonos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents errArreglo As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblSinDisponibilidad As System.Windows.Forms.Label
    Friend WithEvents tbAbonos As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarA As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarA As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarA As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarA As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaA As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabCuotas As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grpDatosGralesC As System.Windows.Forms.GroupBox
    Friend WithEvents tbCuotas As System.Windows.Forms.ToolStrip
    Friend WithEvents toolModificarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaC As System.Windows.Forms.ToolStripButton
    Friend WithEvents cdeFechaA As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtEstadoC As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroC As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoC As System.Windows.Forms.Label
    Friend WithEvents lblCodigoC As System.Windows.Forms.Label
    Friend WithEvents grpDocumentos As System.Windows.Forms.GroupBox
    Friend WithEvents txtEstadoA As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroA As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoA As System.Windows.Forms.Label
    Friend WithEvents lblCodigoA As System.Windows.Forms.Label
    Friend WithEvents grdCuotas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents toolAgregarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents txtFichaNotificacionDetalleID As System.Windows.Forms.TextBox
    Friend WithEvents cboTecnico As C1.Win.C1List.C1Combo
    Friend WithEvents lblTecnico As System.Windows.Forms.Label
    Friend WithEvents cneMonto As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblMontoArreglo As System.Windows.Forms.Label
    Friend WithEvents txtNoCredito As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblSeguimiento As System.Windows.Forms.Label
    Friend WithEvents toolEliminarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtMontoEC As System.Windows.Forms.TextBox
End Class
