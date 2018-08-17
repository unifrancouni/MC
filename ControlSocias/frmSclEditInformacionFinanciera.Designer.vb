<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditInformacionFinanciera
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
        Dim Style233 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style234 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style235 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style236 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style237 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditInformacionFinanciera))
        Dim Style238 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style239 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style240 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpFechas = New System.Windows.Forms.GroupBox
        Me.cboTipoMoneda = New C1.Win.C1List.C1Combo
        Me.lblTipoMoneda = New System.Windows.Forms.Label
        Me.cdeFechaCorte = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaSolicitud = New System.Windows.Forms.Label
        Me.GrpFinanciero = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CnePasivoMasCapital = New C1.Win.C1Input.C1NumericEdit
        Me.nPatrimonio = New C1.Win.C1Input.C1NumericEdit
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.nOtrosPasivosLargoPlazo = New C1.Win.C1Input.C1NumericEdit
        Me.nPtmosPorPagarLargoPlazo = New C1.Win.C1Input.C1NumericEdit
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.CnePasivoFijo = New C1.Win.C1Input.C1NumericEdit
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.nOtrasCuentasCortoPlazo = New C1.Win.C1Input.C1NumericEdit
        Me.nImpuestosPorPagar = New C1.Win.C1Input.C1NumericEdit
        Me.nPrestamosPorPagarCortoPlazo = New C1.Win.C1Input.C1NumericEdit
        Me.nCuentasPorPagarCortoPlazo = New C1.Win.C1Input.C1NumericEdit
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.nProveedores = New C1.Win.C1Input.C1NumericEdit
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.nOtrosFijos = New C1.Win.C1Input.C1NumericEdit
        Me.CneTotalActivo = New C1.Win.C1Input.C1NumericEdit
        Me.nBienesMuebles = New C1.Win.C1Input.C1NumericEdit
        Me.nMaqEquipoRodante = New C1.Win.C1Input.C1NumericEdit
        Me.nBienesInmuebles = New C1.Win.C1Input.C1NumericEdit
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.nOtrosActivos = New C1.Win.C1Input.C1NumericEdit
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cneActivoFijo = New C1.Win.C1Input.C1NumericEdit
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.nOtrosCirculantes = New C1.Win.C1Input.C1NumericEdit
        Me.nInventarios = New C1.Win.C1Input.C1NumericEdit
        Me.nCuentasPorCobrar = New C1.Win.C1Input.C1NumericEdit
        Me.nBancos = New C1.Win.C1Input.C1NumericEdit
        Me.nEfectivo = New C1.Win.C1Input.C1NumericEdit
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpFlujo = New System.Windows.Forms.GroupBox
        Me.CneResultado = New C1.Win.C1Input.C1NumericEdit
        Me.Label45 = New System.Windows.Forms.Label
        Me.nOtrosGastos = New C1.Win.C1Input.C1NumericEdit
        Me.nGastosFamiliares = New C1.Win.C1Input.C1NumericEdit
        Me.nImpuestosSeguros = New C1.Win.C1Input.C1NumericEdit
        Me.nAlquileresRentas = New C1.Win.C1Input.C1NumericEdit
        Me.nProvisionMantenimientoReinversion = New C1.Win.C1Input.C1NumericEdit
        Me.nAmortizacionDeuda = New C1.Win.C1Input.C1NumericEdit
        Me.nGastosOperativos = New C1.Win.C1Input.C1NumericEdit
        Me.nCostosProduccionComercio = New C1.Win.C1Input.C1NumericEdit
        Me.nOtrosIngresos = New C1.Win.C1Input.C1NumericEdit
        Me.nAlquiler = New C1.Win.C1Input.C1NumericEdit
        Me.nIngresosActividadEconomica = New C1.Win.C1Input.C1NumericEdit
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.errGarantiaFiduciaria = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.CneActivoCirculante = New C1.Win.C1Input.C1NumericEdit
        Me.CnePasivoCirculante = New C1.Win.C1Input.C1NumericEdit
        Me.CneTotalPasivo = New C1.Win.C1Input.C1NumericEdit
        Me.CneIngresos = New C1.Win.C1Input.C1NumericEdit
        Me.CneEgresos = New C1.Win.C1Input.C1NumericEdit
        Me.grpFechas.SuspendLayout()
        CType(Me.cboTipoMoneda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCorte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFinanciero.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CnePasivoMasCapital, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nPatrimonio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nOtrosPasivosLargoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nPtmosPorPagarLargoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CnePasivoFijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nOtrasCuentasCortoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nImpuestosPorPagar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nPrestamosPorPagarCortoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nCuentasPorPagarCortoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nProveedores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nOtrosFijos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CneTotalActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nBienesMuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nMaqEquipoRodante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nBienesInmuebles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nOtrosActivos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneActivoFijo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nOtrosCirculantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nInventarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nCuentasPorCobrar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFlujo.SuspendLayout()
        CType(Me.CneResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nOtrosGastos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nGastosFamiliares, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nImpuestosSeguros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nAlquileresRentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nProvisionMantenimientoReinversion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nAmortizacionDeuda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nGastosOperativos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nCostosProduccionComercio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nOtrosIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nAlquiler, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nIngresosActividadEconomica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errGarantiaFiduciaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CneActivoCirculante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CnePasivoCirculante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CneTotalPasivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CneIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CneEgresos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFechas
        '
        Me.grpFechas.Controls.Add(Me.cboTipoMoneda)
        Me.grpFechas.Controls.Add(Me.lblTipoMoneda)
        Me.grpFechas.Controls.Add(Me.cdeFechaCorte)
        Me.grpFechas.Controls.Add(Me.lblFechaSolicitud)
        Me.grpFechas.Location = New System.Drawing.Point(12, 13)
        Me.grpFechas.Name = "grpFechas"
        Me.grpFechas.Size = New System.Drawing.Size(925, 62)
        Me.grpFechas.TabIndex = 0
        Me.grpFechas.TabStop = False
        Me.grpFechas.Text = "Información Financiera Anual"
        '
        'cboTipoMoneda
        '
        Me.cboTipoMoneda.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoMoneda.AutoCompletion = True
        Me.cboTipoMoneda.Caption = ""
        Me.cboTipoMoneda.CaptionHeight = 17
        Me.cboTipoMoneda.CaptionStyle = Style233
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
        Me.cboTipoMoneda.EvenRowStyle = Style234
        Me.cboTipoMoneda.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoMoneda.FooterStyle = Style235
        Me.cboTipoMoneda.GapHeight = 2
        Me.cboTipoMoneda.HeadingStyle = Style236
        Me.cboTipoMoneda.HighLightRowStyle = Style237
        Me.cboTipoMoneda.Images.Add(CType(resources.GetObject("cboTipoMoneda.Images"), System.Drawing.Image))
        Me.cboTipoMoneda.ItemHeight = 15
        Me.cboTipoMoneda.LimitToList = True
        Me.cboTipoMoneda.Location = New System.Drawing.Point(574, 17)
        Me.cboTipoMoneda.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoMoneda.MaxDropDownItems = CType(5, Short)
        Me.cboTipoMoneda.MaxLength = 32767
        Me.cboTipoMoneda.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoMoneda.Name = "cboTipoMoneda"
        Me.cboTipoMoneda.OddRowStyle = Style238
        Me.cboTipoMoneda.PartialRightColumn = False
        Me.cboTipoMoneda.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoMoneda.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoMoneda.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoMoneda.SelectedStyle = Style239
        Me.cboTipoMoneda.Size = New System.Drawing.Size(152, 21)
        Me.cboTipoMoneda.Style = Style240
        Me.cboTipoMoneda.SuperBack = True
        Me.cboTipoMoneda.TabIndex = 2
        Me.cboTipoMoneda.ValueMember = "StbValorCatalogoID"
        Me.cboTipoMoneda.PropBag = resources.GetString("cboTipoMoneda.PropBag")
        '
        'lblTipoMoneda
        '
        Me.lblTipoMoneda.AutoSize = True
        Me.lblTipoMoneda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoMoneda.Location = New System.Drawing.Point(519, 17)
        Me.lblTipoMoneda.Name = "lblTipoMoneda"
        Me.lblTipoMoneda.Size = New System.Drawing.Size(49, 13)
        Me.lblTipoMoneda.TabIndex = 128
        Me.lblTipoMoneda.Text = "Moneda:"
        '
        'cdeFechaCorte
        '
        Me.cdeFechaCorte.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCorte.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaCorte.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCorte.Location = New System.Drawing.Point(131, 22)
        Me.cdeFechaCorte.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaCorte.MaskInfo.EmptyAsNull = True
        Me.cdeFechaCorte.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaCorte.Name = "cdeFechaCorte"
        Me.cdeFechaCorte.Size = New System.Drawing.Size(125, 20)
        Me.cdeFechaCorte.TabIndex = 1
        Me.cdeFechaCorte.Tag = Nothing
        Me.cdeFechaCorte.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaSolicitud
        '
        Me.lblFechaSolicitud.AutoSize = True
        Me.lblFechaSolicitud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaSolicitud.Location = New System.Drawing.Point(15, 25)
        Me.lblFechaSolicitud.Name = "lblFechaSolicitud"
        Me.lblFechaSolicitud.Size = New System.Drawing.Size(83, 13)
        Me.lblFechaSolicitud.TabIndex = 127
        Me.lblFechaSolicitud.Text = "Fecha de Corte:"
        '
        'GrpFinanciero
        '
        Me.GrpFinanciero.Controls.Add(Me.GroupBox3)
        Me.GrpFinanciero.Controls.Add(Me.GroupBox2)
        Me.GrpFinanciero.Location = New System.Drawing.Point(12, 99)
        Me.GrpFinanciero.Name = "GrpFinanciero"
        Me.GrpFinanciero.Size = New System.Drawing.Size(663, 540)
        Me.GrpFinanciero.TabIndex = 1
        Me.GrpFinanciero.TabStop = False
        Me.GrpFinanciero.Text = "Estados Financieros"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CneTotalPasivo)
        Me.GroupBox3.Controls.Add(Me.CnePasivoCirculante)
        Me.GroupBox3.Controls.Add(Me.CnePasivoMasCapital)
        Me.GroupBox3.Controls.Add(Me.nPatrimonio)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.nOtrosPasivosLargoPlazo)
        Me.GroupBox3.Controls.Add(Me.nPtmosPorPagarLargoPlazo)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.CnePasivoFijo)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.nOtrasCuentasCortoPlazo)
        Me.GroupBox3.Controls.Add(Me.nImpuestosPorPagar)
        Me.GroupBox3.Controls.Add(Me.nPrestamosPorPagarCortoPlazo)
        Me.GroupBox3.Controls.Add(Me.nCuentasPorPagarCortoPlazo)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.nProveedores)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(329, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(328, 514)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'CnePasivoMasCapital
        '
        Me.CnePasivoMasCapital.AcceptsTab = True
        Me.CnePasivoMasCapital.BackColor = System.Drawing.Color.LightCyan
        Me.CnePasivoMasCapital.CustomFormat = "###,###,###,##0.00"
        Me.CnePasivoMasCapital.DataType = GetType(Double)
        Me.CnePasivoMasCapital.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CnePasivoMasCapital.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoMasCapital.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CnePasivoMasCapital.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CnePasivoMasCapital.EditFormat.EmptyAsNull = False
        Me.CnePasivoMasCapital.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoMasCapital.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CnePasivoMasCapital.EmptyAsNull = True
        Me.CnePasivoMasCapital.Enabled = False
        Me.CnePasivoMasCapital.ForeColor = System.Drawing.Color.Blue
        Me.CnePasivoMasCapital.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoMasCapital.Location = New System.Drawing.Point(163, 485)
        Me.CnePasivoMasCapital.MaskInfo.AutoTabWhenFilled = True
        Me.CnePasivoMasCapital.MaxLength = 999999999
        Me.CnePasivoMasCapital.Name = "CnePasivoMasCapital"
        Me.CnePasivoMasCapital.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CnePasivoMasCapital.Size = New System.Drawing.Size(133, 20)
        Me.CnePasivoMasCapital.TabIndex = 199
        Me.CnePasivoMasCapital.Tag = Nothing
        Me.CnePasivoMasCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CnePasivoMasCapital.UseColumnStyles = False
        Me.CnePasivoMasCapital.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nPatrimonio
        '
        Me.nPatrimonio.AcceptsTab = True
        Me.nPatrimonio.CustomFormat = "###,###,###,##0.00"
        Me.nPatrimonio.DataType = GetType(Double)
        Me.nPatrimonio.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nPatrimonio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPatrimonio.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nPatrimonio.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nPatrimonio.EditFormat.EmptyAsNull = False
        Me.nPatrimonio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPatrimonio.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nPatrimonio.EmptyAsNull = True
        Me.nPatrimonio.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPatrimonio.Location = New System.Drawing.Point(163, 446)
        Me.nPatrimonio.MaskInfo.AutoTabWhenFilled = True
        Me.nPatrimonio.MaxLength = 12
        Me.nPatrimonio.Name = "nPatrimonio"
        Me.nPatrimonio.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nPatrimonio.Size = New System.Drawing.Size(133, 20)
        Me.nPatrimonio.TabIndex = 20
        Me.nPatrimonio.Tag = Nothing
        Me.nPatrimonio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nPatrimonio.UseColumnStyles = False
        Me.nPatrimonio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Red
        Me.Label31.Location = New System.Drawing.Point(6, 488)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(99, 13)
        Me.Label31.TabIndex = 197
        Me.Label31.Text = "Pasivo + Capital"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(20, 449)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(85, 13)
        Me.Label30.TabIndex = 196
        Me.Label30.Text = "Patrimonio(A - P)"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.Red
        Me.Label29.Location = New System.Drawing.Point(242, 428)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(52, 13)
        Me.Label29.TabIndex = 195
        Me.Label29.Text = "MONTO"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Red
        Me.Label28.Location = New System.Drawing.Point(77, 428)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(58, 13)
        Me.Label28.TabIndex = 194
        Me.Label28.Text = "CAPITAL"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.Red
        Me.Label27.Location = New System.Drawing.Point(6, 398)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(78, 13)
        Me.Label27.TabIndex = 193
        Me.Label27.Text = "Total Pasivo"
        '
        'nOtrosPasivosLargoPlazo
        '
        Me.nOtrosPasivosLargoPlazo.AcceptsTab = True
        Me.nOtrosPasivosLargoPlazo.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosPasivosLargoPlazo.DataType = GetType(Double)
        Me.nOtrosPasivosLargoPlazo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nOtrosPasivosLargoPlazo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosPasivosLargoPlazo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosPasivosLargoPlazo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosPasivosLargoPlazo.EditFormat.EmptyAsNull = False
        Me.nOtrosPasivosLargoPlazo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosPasivosLargoPlazo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosPasivosLargoPlazo.EmptyAsNull = True
        Me.nOtrosPasivosLargoPlazo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosPasivosLargoPlazo.Location = New System.Drawing.Point(163, 355)
        Me.nOtrosPasivosLargoPlazo.MaskInfo.AutoTabWhenFilled = True
        Me.nOtrosPasivosLargoPlazo.MaxLength = 12
        Me.nOtrosPasivosLargoPlazo.Name = "nOtrosPasivosLargoPlazo"
        Me.nOtrosPasivosLargoPlazo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nOtrosPasivosLargoPlazo.Size = New System.Drawing.Size(133, 20)
        Me.nOtrosPasivosLargoPlazo.TabIndex = 19
        Me.nOtrosPasivosLargoPlazo.Tag = Nothing
        Me.nOtrosPasivosLargoPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nOtrosPasivosLargoPlazo.UseColumnStyles = False
        Me.nOtrosPasivosLargoPlazo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nPtmosPorPagarLargoPlazo
        '
        Me.nPtmosPorPagarLargoPlazo.AcceptsTab = True
        Me.nPtmosPorPagarLargoPlazo.CustomFormat = "###,###,###,##0.00"
        Me.nPtmosPorPagarLargoPlazo.DataType = GetType(Double)
        Me.nPtmosPorPagarLargoPlazo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nPtmosPorPagarLargoPlazo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPtmosPorPagarLargoPlazo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nPtmosPorPagarLargoPlazo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nPtmosPorPagarLargoPlazo.EditFormat.EmptyAsNull = False
        Me.nPtmosPorPagarLargoPlazo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPtmosPorPagarLargoPlazo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nPtmosPorPagarLargoPlazo.EmptyAsNull = True
        Me.nPtmosPorPagarLargoPlazo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPtmosPorPagarLargoPlazo.Location = New System.Drawing.Point(163, 314)
        Me.nPtmosPorPagarLargoPlazo.MaskInfo.AutoTabWhenFilled = True
        Me.nPtmosPorPagarLargoPlazo.MaxLength = 12
        Me.nPtmosPorPagarLargoPlazo.Name = "nPtmosPorPagarLargoPlazo"
        Me.nPtmosPorPagarLargoPlazo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nPtmosPorPagarLargoPlazo.Size = New System.Drawing.Size(133, 20)
        Me.nPtmosPorPagarLargoPlazo.TabIndex = 18
        Me.nPtmosPorPagarLargoPlazo.Tag = Nothing
        Me.nPtmosPorPagarLargoPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nPtmosPorPagarLargoPlazo.UseColumnStyles = False
        Me.nPtmosPorPagarLargoPlazo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(20, 355)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(88, 13)
        Me.Label26.TabIndex = 190
        Me.Label26.Text = "Otros Pasivos LP"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(20, 318)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(115, 13)
        Me.Label25.TabIndex = 189
        Me.Label25.Text = "Ptmos. x pagar L Plazo"
        '
        'CnePasivoFijo
        '
        Me.CnePasivoFijo.AcceptsTab = True
        Me.CnePasivoFijo.BackColor = System.Drawing.Color.LightCyan
        Me.CnePasivoFijo.CustomFormat = "###,###,###,##0.00"
        Me.CnePasivoFijo.DataType = GetType(Double)
        Me.CnePasivoFijo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CnePasivoFijo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoFijo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CnePasivoFijo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CnePasivoFijo.EditFormat.EmptyAsNull = False
        Me.CnePasivoFijo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoFijo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CnePasivoFijo.EmptyAsNull = True
        Me.CnePasivoFijo.Enabled = False
        Me.CnePasivoFijo.ForeColor = System.Drawing.Color.Blue
        Me.CnePasivoFijo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoFijo.Location = New System.Drawing.Point(163, 248)
        Me.CnePasivoFijo.MaskInfo.AutoTabWhenFilled = True
        Me.CnePasivoFijo.MaxLength = 999999999
        Me.CnePasivoFijo.Name = "CnePasivoFijo"
        Me.CnePasivoFijo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CnePasivoFijo.Size = New System.Drawing.Size(133, 20)
        Me.CnePasivoFijo.TabIndex = 188
        Me.CnePasivoFijo.Tag = Nothing
        Me.CnePasivoFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CnePasivoFijo.UseColumnStyles = False
        Me.CnePasivoFijo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(14, 210)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(116, 13)
        Me.Label24.TabIndex = 187
        Me.Label24.Text = "Otras Ctas. Corto Plazo"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(14, 171)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(104, 13)
        Me.Label23.TabIndex = 186
        Me.Label23.Text = "Impuestos por Pagar"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(14, 136)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 13)
        Me.Label22.TabIndex = 185
        Me.Label22.Text = "Ptmos. x pagar C. Plazo:"
        '
        'nOtrasCuentasCortoPlazo
        '
        Me.nOtrasCuentasCortoPlazo.AcceptsTab = True
        Me.nOtrasCuentasCortoPlazo.CustomFormat = "###,###,###,##0.00"
        Me.nOtrasCuentasCortoPlazo.DataType = GetType(Double)
        Me.nOtrasCuentasCortoPlazo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nOtrasCuentasCortoPlazo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrasCuentasCortoPlazo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrasCuentasCortoPlazo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nOtrasCuentasCortoPlazo.EditFormat.EmptyAsNull = False
        Me.nOtrasCuentasCortoPlazo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrasCuentasCortoPlazo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrasCuentasCortoPlazo.EmptyAsNull = True
        Me.nOtrasCuentasCortoPlazo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrasCuentasCortoPlazo.Location = New System.Drawing.Point(163, 207)
        Me.nOtrasCuentasCortoPlazo.MaskInfo.AutoTabWhenFilled = True
        Me.nOtrasCuentasCortoPlazo.MaxLength = 12
        Me.nOtrasCuentasCortoPlazo.Name = "nOtrasCuentasCortoPlazo"
        Me.nOtrasCuentasCortoPlazo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nOtrasCuentasCortoPlazo.Size = New System.Drawing.Size(133, 20)
        Me.nOtrasCuentasCortoPlazo.TabIndex = 17
        Me.nOtrasCuentasCortoPlazo.Tag = Nothing
        Me.nOtrasCuentasCortoPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nOtrasCuentasCortoPlazo.UseColumnStyles = False
        Me.nOtrasCuentasCortoPlazo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nImpuestosPorPagar
        '
        Me.nImpuestosPorPagar.AcceptsTab = True
        Me.nImpuestosPorPagar.CustomFormat = "###,###,###,##0.00"
        Me.nImpuestosPorPagar.DataType = GetType(Double)
        Me.nImpuestosPorPagar.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nImpuestosPorPagar.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nImpuestosPorPagar.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nImpuestosPorPagar.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nImpuestosPorPagar.EditFormat.EmptyAsNull = False
        Me.nImpuestosPorPagar.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nImpuestosPorPagar.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nImpuestosPorPagar.EmptyAsNull = True
        Me.nImpuestosPorPagar.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nImpuestosPorPagar.Location = New System.Drawing.Point(163, 168)
        Me.nImpuestosPorPagar.MaskInfo.AutoTabWhenFilled = True
        Me.nImpuestosPorPagar.MaxLength = 12
        Me.nImpuestosPorPagar.Name = "nImpuestosPorPagar"
        Me.nImpuestosPorPagar.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nImpuestosPorPagar.Size = New System.Drawing.Size(133, 20)
        Me.nImpuestosPorPagar.TabIndex = 16
        Me.nImpuestosPorPagar.Tag = Nothing
        Me.nImpuestosPorPagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nImpuestosPorPagar.UseColumnStyles = False
        Me.nImpuestosPorPagar.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nPrestamosPorPagarCortoPlazo
        '
        Me.nPrestamosPorPagarCortoPlazo.AcceptsTab = True
        Me.nPrestamosPorPagarCortoPlazo.CustomFormat = "###,###,###,##0.00"
        Me.nPrestamosPorPagarCortoPlazo.DataType = GetType(Double)
        Me.nPrestamosPorPagarCortoPlazo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nPrestamosPorPagarCortoPlazo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPrestamosPorPagarCortoPlazo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nPrestamosPorPagarCortoPlazo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nPrestamosPorPagarCortoPlazo.EditFormat.EmptyAsNull = False
        Me.nPrestamosPorPagarCortoPlazo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPrestamosPorPagarCortoPlazo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nPrestamosPorPagarCortoPlazo.EmptyAsNull = True
        Me.nPrestamosPorPagarCortoPlazo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nPrestamosPorPagarCortoPlazo.Location = New System.Drawing.Point(163, 133)
        Me.nPrestamosPorPagarCortoPlazo.MaskInfo.AutoTabWhenFilled = True
        Me.nPrestamosPorPagarCortoPlazo.MaxLength = 12
        Me.nPrestamosPorPagarCortoPlazo.Name = "nPrestamosPorPagarCortoPlazo"
        Me.nPrestamosPorPagarCortoPlazo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nPrestamosPorPagarCortoPlazo.Size = New System.Drawing.Size(133, 20)
        Me.nPrestamosPorPagarCortoPlazo.TabIndex = 15
        Me.nPrestamosPorPagarCortoPlazo.Tag = Nothing
        Me.nPrestamosPorPagarCortoPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nPrestamosPorPagarCortoPlazo.UseColumnStyles = False
        Me.nPrestamosPorPagarCortoPlazo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nCuentasPorPagarCortoPlazo
        '
        Me.nCuentasPorPagarCortoPlazo.AcceptsTab = True
        Me.nCuentasPorPagarCortoPlazo.CustomFormat = "###,###,###,##0.00"
        Me.nCuentasPorPagarCortoPlazo.DataType = GetType(Double)
        Me.nCuentasPorPagarCortoPlazo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nCuentasPorPagarCortoPlazo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCuentasPorPagarCortoPlazo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nCuentasPorPagarCortoPlazo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nCuentasPorPagarCortoPlazo.EditFormat.EmptyAsNull = False
        Me.nCuentasPorPagarCortoPlazo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCuentasPorPagarCortoPlazo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nCuentasPorPagarCortoPlazo.EmptyAsNull = True
        Me.nCuentasPorPagarCortoPlazo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCuentasPorPagarCortoPlazo.Location = New System.Drawing.Point(163, 100)
        Me.nCuentasPorPagarCortoPlazo.MaskInfo.AutoTabWhenFilled = True
        Me.nCuentasPorPagarCortoPlazo.MaxLength = 12
        Me.nCuentasPorPagarCortoPlazo.Name = "nCuentasPorPagarCortoPlazo"
        Me.nCuentasPorPagarCortoPlazo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nCuentasPorPagarCortoPlazo.Size = New System.Drawing.Size(133, 20)
        Me.nCuentasPorPagarCortoPlazo.TabIndex = 14
        Me.nCuentasPorPagarCortoPlazo.Tag = Nothing
        Me.nCuentasPorPagarCortoPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nCuentasPorPagarCortoPlazo.UseColumnStyles = False
        Me.nCuentasPorPagarCortoPlazo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(13, 103)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(114, 13)
        Me.Label21.TabIndex = 180
        Me.Label21.Text = "Ctas. x pagar C. Plazo:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(14, 67)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(70, 13)
        Me.Label20.TabIndex = 179
        Me.Label20.Text = "Proveedores:"
        '
        'nProveedores
        '
        Me.nProveedores.AcceptsTab = True
        Me.nProveedores.CustomFormat = "###,###,###,##0.00"
        Me.nProveedores.DataType = GetType(Double)
        Me.nProveedores.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nProveedores.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nProveedores.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nProveedores.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nProveedores.EditFormat.EmptyAsNull = False
        Me.nProveedores.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nProveedores.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nProveedores.EmptyAsNull = True
        Me.nProveedores.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nProveedores.Location = New System.Drawing.Point(163, 60)
        Me.nProveedores.MaskInfo.AutoTabWhenFilled = True
        Me.nProveedores.MaxLength = 12
        Me.nProveedores.Name = "nProveedores"
        Me.nProveedores.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nProveedores.Size = New System.Drawing.Size(133, 20)
        Me.nProveedores.TabIndex = 13
        Me.nProveedores.Tag = Nothing
        Me.nProveedores.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nProveedores.UseColumnStyles = False
        Me.nProveedores.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(6, 260)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 13)
        Me.Label19.TabIndex = 167
        Me.Label19.Text = "Pasivo Fijo"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Red
        Me.Label18.Location = New System.Drawing.Point(6, 39)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(106, 13)
        Me.Label18.TabIndex = 157
        Me.Label18.Text = "Pasivo Circulante"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(242, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 156
        Me.Label16.Text = "MONTO"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(77, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 155
        Me.Label17.Text = "PASIVOS"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.CneActivoCirculante)
        Me.GroupBox2.Controls.Add(Me.nOtrosFijos)
        Me.GroupBox2.Controls.Add(Me.CneTotalActivo)
        Me.GroupBox2.Controls.Add(Me.nBienesMuebles)
        Me.GroupBox2.Controls.Add(Me.nMaqEquipoRodante)
        Me.GroupBox2.Controls.Add(Me.nBienesInmuebles)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.nOtrosActivos)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cneActivoFijo)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.nOtrosCirculantes)
        Me.GroupBox2.Controls.Add(Me.nInventarios)
        Me.GroupBox2.Controls.Add(Me.nCuentasPorCobrar)
        Me.GroupBox2.Controls.Add(Me.nBancos)
        Me.GroupBox2.Controls.Add(Me.nEfectivo)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(316, 510)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'nOtrosFijos
        '
        Me.nOtrosFijos.AcceptsTab = True
        Me.nOtrosFijos.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosFijos.DataType = GetType(Double)
        Me.nOtrosFijos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nOtrosFijos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosFijos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosFijos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosFijos.EditFormat.EmptyAsNull = False
        Me.nOtrosFijos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosFijos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosFijos.EmptyAsNull = True
        Me.nOtrosFijos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosFijos.Location = New System.Drawing.Point(153, 429)
        Me.nOtrosFijos.MaskInfo.AutoTabWhenFilled = True
        Me.nOtrosFijos.MaxLength = 12
        Me.nOtrosFijos.Name = "nOtrosFijos"
        Me.nOtrosFijos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nOtrosFijos.Size = New System.Drawing.Size(133, 20)
        Me.nOtrosFijos.TabIndex = 11
        Me.nOtrosFijos.Tag = Nothing
        Me.nOtrosFijos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nOtrosFijos.UseColumnStyles = False
        Me.nOtrosFijos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'CneTotalActivo
        '
        Me.CneTotalActivo.AcceptsTab = True
        Me.CneTotalActivo.BackColor = System.Drawing.Color.LightCyan
        Me.CneTotalActivo.CustomFormat = "###,###,###,##0.00"
        Me.CneTotalActivo.DataType = GetType(Double)
        Me.CneTotalActivo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CneTotalActivo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneTotalActivo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneTotalActivo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CneTotalActivo.EditFormat.EmptyAsNull = False
        Me.CneTotalActivo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneTotalActivo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneTotalActivo.EmptyAsNull = True
        Me.CneTotalActivo.Enabled = False
        Me.CneTotalActivo.ForeColor = System.Drawing.Color.Blue
        Me.CneTotalActivo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneTotalActivo.Location = New System.Drawing.Point(153, 482)
        Me.CneTotalActivo.MaskInfo.AutoTabWhenFilled = True
        Me.CneTotalActivo.MaxLength = 999999999
        Me.CneTotalActivo.Name = "CneTotalActivo"
        Me.CneTotalActivo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CneTotalActivo.Size = New System.Drawing.Size(133, 20)
        Me.CneTotalActivo.TabIndex = 178
        Me.CneTotalActivo.Tag = Nothing
        Me.CneTotalActivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CneTotalActivo.UseColumnStyles = False
        Me.CneTotalActivo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nBienesMuebles
        '
        Me.nBienesMuebles.AcceptsTab = True
        Me.nBienesMuebles.CustomFormat = "###,###,###,##0.00"
        Me.nBienesMuebles.DataType = GetType(Double)
        Me.nBienesMuebles.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nBienesMuebles.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBienesMuebles.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nBienesMuebles.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nBienesMuebles.EditFormat.EmptyAsNull = False
        Me.nBienesMuebles.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBienesMuebles.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nBienesMuebles.EmptyAsNull = True
        Me.nBienesMuebles.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBienesMuebles.Location = New System.Drawing.Point(153, 392)
        Me.nBienesMuebles.MaskInfo.AutoTabWhenFilled = True
        Me.nBienesMuebles.MaxLength = 12
        Me.nBienesMuebles.Name = "nBienesMuebles"
        Me.nBienesMuebles.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nBienesMuebles.Size = New System.Drawing.Size(133, 20)
        Me.nBienesMuebles.TabIndex = 10
        Me.nBienesMuebles.Tag = Nothing
        Me.nBienesMuebles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nBienesMuebles.UseColumnStyles = False
        Me.nBienesMuebles.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nMaqEquipoRodante
        '
        Me.nMaqEquipoRodante.AcceptsTab = True
        Me.nMaqEquipoRodante.CustomFormat = "###,###,###,##0.00"
        Me.nMaqEquipoRodante.DataType = GetType(Double)
        Me.nMaqEquipoRodante.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nMaqEquipoRodante.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nMaqEquipoRodante.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nMaqEquipoRodante.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nMaqEquipoRodante.EditFormat.EmptyAsNull = False
        Me.nMaqEquipoRodante.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nMaqEquipoRodante.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nMaqEquipoRodante.EmptyAsNull = True
        Me.nMaqEquipoRodante.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nMaqEquipoRodante.Location = New System.Drawing.Point(153, 356)
        Me.nMaqEquipoRodante.MaskInfo.AutoTabWhenFilled = True
        Me.nMaqEquipoRodante.MaxLength = 12
        Me.nMaqEquipoRodante.Name = "nMaqEquipoRodante"
        Me.nMaqEquipoRodante.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nMaqEquipoRodante.Size = New System.Drawing.Size(133, 20)
        Me.nMaqEquipoRodante.TabIndex = 9
        Me.nMaqEquipoRodante.Tag = Nothing
        Me.nMaqEquipoRodante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nMaqEquipoRodante.UseColumnStyles = False
        Me.nMaqEquipoRodante.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nBienesInmuebles
        '
        Me.nBienesInmuebles.AcceptsTab = True
        Me.nBienesInmuebles.CustomFormat = "###,###,###,##0.00"
        Me.nBienesInmuebles.DataType = GetType(Double)
        Me.nBienesInmuebles.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nBienesInmuebles.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBienesInmuebles.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nBienesInmuebles.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nBienesInmuebles.EditFormat.EmptyAsNull = False
        Me.nBienesInmuebles.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBienesInmuebles.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nBienesInmuebles.EmptyAsNull = True
        Me.nBienesInmuebles.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBienesInmuebles.Location = New System.Drawing.Point(153, 319)
        Me.nBienesInmuebles.MaskInfo.AutoTabWhenFilled = True
        Me.nBienesInmuebles.MaxLength = 12
        Me.nBienesInmuebles.Name = "nBienesInmuebles"
        Me.nBienesInmuebles.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nBienesInmuebles.Size = New System.Drawing.Size(133, 20)
        Me.nBienesInmuebles.TabIndex = 8
        Me.nBienesInmuebles.Tag = Nothing
        Me.nBienesInmuebles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nBienesInmuebles.UseColumnStyles = False
        Me.nBienesInmuebles.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(9, 486)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 13)
        Me.Label15.TabIndex = 174
        Me.Label15.Text = "Total Activo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(9, 454)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 173
        Me.Label14.Text = "Otros Activos"
        '
        'nOtrosActivos
        '
        Me.nOtrosActivos.AcceptsTab = True
        Me.nOtrosActivos.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosActivos.DataType = GetType(Double)
        Me.nOtrosActivos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nOtrosActivos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosActivos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosActivos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosActivos.EditFormat.EmptyAsNull = False
        Me.nOtrosActivos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosActivos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosActivos.EmptyAsNull = True
        Me.nOtrosActivos.ForeColor = System.Drawing.Color.Black
        Me.nOtrosActivos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosActivos.Location = New System.Drawing.Point(153, 454)
        Me.nOtrosActivos.MaskInfo.AutoTabWhenFilled = True
        Me.nOtrosActivos.MaxLength = 12
        Me.nOtrosActivos.Name = "nOtrosActivos"
        Me.nOtrosActivos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nOtrosActivos.Size = New System.Drawing.Size(133, 20)
        Me.nOtrosActivos.TabIndex = 12
        Me.nOtrosActivos.Tag = Nothing
        Me.nOtrosActivos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nOtrosActivos.UseColumnStyles = False
        Me.nOtrosActivos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(22, 429)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 13)
        Me.Label13.TabIndex = 171
        Me.Label13.Text = "Otros Fijos:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(22, 392)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(85, 13)
        Me.Label12.TabIndex = 170
        Me.Label12.Text = "Bienes Muebles:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(22, 356)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(121, 13)
        Me.Label11.TabIndex = 169
        Me.Label11.Text = "Maqy./Equipo Rodante:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(20, 322)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 13)
        Me.Label10.TabIndex = 168
        Me.Label10.Text = "Bienes Inmuebles:"
        '
        'cneActivoFijo
        '
        Me.cneActivoFijo.AcceptsTab = True
        Me.cneActivoFijo.BackColor = System.Drawing.Color.LightCyan
        Me.cneActivoFijo.CustomFormat = "###,###,###,##0.00"
        Me.cneActivoFijo.DataType = GetType(Double)
        Me.cneActivoFijo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.cneActivoFijo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneActivoFijo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneActivoFijo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneActivoFijo.EditFormat.EmptyAsNull = False
        Me.cneActivoFijo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneActivoFijo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneActivoFijo.EmptyAsNull = True
        Me.cneActivoFijo.Enabled = False
        Me.cneActivoFijo.ForeColor = System.Drawing.Color.Blue
        Me.cneActivoFijo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneActivoFijo.Location = New System.Drawing.Point(146, 258)
        Me.cneActivoFijo.MaskInfo.AutoTabWhenFilled = True
        Me.cneActivoFijo.MaxLength = 999999999
        Me.cneActivoFijo.Name = "cneActivoFijo"
        Me.cneActivoFijo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneActivoFijo.Size = New System.Drawing.Size(133, 20)
        Me.cneActivoFijo.TabIndex = 167
        Me.cneActivoFijo.Tag = Nothing
        Me.cneActivoFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneActivoFijo.UseColumnStyles = False
        Me.cneActivoFijo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Red
        Me.Label9.Location = New System.Drawing.Point(15, 265)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 166
        Me.Label9.Text = "Activo Fijo"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(15, 215)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 13)
        Me.Label8.TabIndex = 165
        Me.Label8.Text = "Otros Circulantes:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(13, 183)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 164
        Me.Label7.Text = "Inventarios:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(15, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Cuentas por Cobrar:"
        '
        'nOtrosCirculantes
        '
        Me.nOtrosCirculantes.AcceptsTab = True
        Me.nOtrosCirculantes.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosCirculantes.DataType = GetType(Double)
        Me.nOtrosCirculantes.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nOtrosCirculantes.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosCirculantes.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosCirculantes.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosCirculantes.EditFormat.EmptyAsNull = False
        Me.nOtrosCirculantes.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosCirculantes.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosCirculantes.EmptyAsNull = True
        Me.nOtrosCirculantes.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosCirculantes.Location = New System.Drawing.Point(146, 215)
        Me.nOtrosCirculantes.MaskInfo.AutoTabWhenFilled = True
        Me.nOtrosCirculantes.MaxLength = 12
        Me.nOtrosCirculantes.Name = "nOtrosCirculantes"
        Me.nOtrosCirculantes.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nOtrosCirculantes.Size = New System.Drawing.Size(133, 20)
        Me.nOtrosCirculantes.TabIndex = 7
        Me.nOtrosCirculantes.Tag = Nothing
        Me.nOtrosCirculantes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nOtrosCirculantes.UseColumnStyles = False
        Me.nOtrosCirculantes.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nInventarios
        '
        Me.nInventarios.AcceptsTab = True
        Me.nInventarios.CustomFormat = "###,###,###,##0.00"
        Me.nInventarios.DataType = GetType(Double)
        Me.nInventarios.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nInventarios.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nInventarios.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nInventarios.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nInventarios.EditFormat.EmptyAsNull = False
        Me.nInventarios.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nInventarios.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nInventarios.EmptyAsNull = True
        Me.nInventarios.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nInventarios.Location = New System.Drawing.Point(146, 176)
        Me.nInventarios.MaskInfo.AutoTabWhenFilled = True
        Me.nInventarios.MaxLength = 12
        Me.nInventarios.Name = "nInventarios"
        Me.nInventarios.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nInventarios.Size = New System.Drawing.Size(133, 20)
        Me.nInventarios.TabIndex = 6
        Me.nInventarios.Tag = Nothing
        Me.nInventarios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nInventarios.UseColumnStyles = False
        Me.nInventarios.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nCuentasPorCobrar
        '
        Me.nCuentasPorCobrar.AcceptsTab = True
        Me.nCuentasPorCobrar.CustomFormat = "###,###,###,##0.00"
        Me.nCuentasPorCobrar.DataType = GetType(Double)
        Me.nCuentasPorCobrar.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nCuentasPorCobrar.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCuentasPorCobrar.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nCuentasPorCobrar.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nCuentasPorCobrar.EditFormat.EmptyAsNull = False
        Me.nCuentasPorCobrar.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCuentasPorCobrar.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nCuentasPorCobrar.EmptyAsNull = True
        Me.nCuentasPorCobrar.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCuentasPorCobrar.Location = New System.Drawing.Point(146, 141)
        Me.nCuentasPorCobrar.MaskInfo.AutoTabWhenFilled = True
        Me.nCuentasPorCobrar.MaxLength = 12
        Me.nCuentasPorCobrar.Name = "nCuentasPorCobrar"
        Me.nCuentasPorCobrar.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nCuentasPorCobrar.Size = New System.Drawing.Size(133, 20)
        Me.nCuentasPorCobrar.TabIndex = 5
        Me.nCuentasPorCobrar.Tag = Nothing
        Me.nCuentasPorCobrar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nCuentasPorCobrar.UseColumnStyles = False
        Me.nCuentasPorCobrar.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nBancos
        '
        Me.nBancos.AcceptsTab = True
        Me.nBancos.CustomFormat = "###,###,###,##0.00"
        Me.nBancos.DataType = GetType(Double)
        Me.nBancos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nBancos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBancos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nBancos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nBancos.EditFormat.EmptyAsNull = False
        Me.nBancos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBancos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nBancos.EmptyAsNull = True
        Me.nBancos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nBancos.Location = New System.Drawing.Point(146, 104)
        Me.nBancos.MaskInfo.AutoTabWhenFilled = True
        Me.nBancos.MaxLength = 12
        Me.nBancos.Name = "nBancos"
        Me.nBancos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nBancos.Size = New System.Drawing.Size(133, 20)
        Me.nBancos.TabIndex = 4
        Me.nBancos.Tag = Nothing
        Me.nBancos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nBancos.UseColumnStyles = False
        Me.nBancos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nEfectivo
        '
        Me.nEfectivo.AcceptsTab = True
        Me.nEfectivo.CustomFormat = "###,###,###,##0.00"
        Me.nEfectivo.DataType = GetType(Double)
        Me.nEfectivo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nEfectivo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nEfectivo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nEfectivo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nEfectivo.EditFormat.EmptyAsNull = False
        Me.nEfectivo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nEfectivo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nEfectivo.EmptyAsNull = True
        Me.nEfectivo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nEfectivo.Location = New System.Drawing.Point(146, 68)
        Me.nEfectivo.MaskInfo.AutoTabWhenFilled = True
        Me.nEfectivo.MaxLength = 12
        Me.nEfectivo.Name = "nEfectivo"
        Me.nEfectivo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nEfectivo.Size = New System.Drawing.Size(133, 20)
        Me.nEfectivo.TabIndex = 3
        Me.nEfectivo.Tag = Nothing
        Me.nEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nEfectivo.UseColumnStyles = False
        Me.nEfectivo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(15, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 157
        Me.Label5.Text = "Banco:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Efectivo:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(9, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 13)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "Activo Circulante"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(217, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 154
        Me.Label2.Text = "MONTO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(82, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 153
        Me.Label1.Text = "ACTIVOS"
        '
        'GrpFlujo
        '
        Me.GrpFlujo.Controls.Add(Me.CneEgresos)
        Me.GrpFlujo.Controls.Add(Me.CneIngresos)
        Me.GrpFlujo.Controls.Add(Me.CneResultado)
        Me.GrpFlujo.Controls.Add(Me.Label45)
        Me.GrpFlujo.Controls.Add(Me.nOtrosGastos)
        Me.GrpFlujo.Controls.Add(Me.nGastosFamiliares)
        Me.GrpFlujo.Controls.Add(Me.nImpuestosSeguros)
        Me.GrpFlujo.Controls.Add(Me.nAlquileresRentas)
        Me.GrpFlujo.Controls.Add(Me.nProvisionMantenimientoReinversion)
        Me.GrpFlujo.Controls.Add(Me.nAmortizacionDeuda)
        Me.GrpFlujo.Controls.Add(Me.nGastosOperativos)
        Me.GrpFlujo.Controls.Add(Me.nCostosProduccionComercio)
        Me.GrpFlujo.Controls.Add(Me.nOtrosIngresos)
        Me.GrpFlujo.Controls.Add(Me.nAlquiler)
        Me.GrpFlujo.Controls.Add(Me.nIngresosActividadEconomica)
        Me.GrpFlujo.Controls.Add(Me.Label44)
        Me.GrpFlujo.Controls.Add(Me.Label43)
        Me.GrpFlujo.Controls.Add(Me.Label42)
        Me.GrpFlujo.Controls.Add(Me.Label41)
        Me.GrpFlujo.Controls.Add(Me.Label40)
        Me.GrpFlujo.Controls.Add(Me.Label39)
        Me.GrpFlujo.Controls.Add(Me.Label38)
        Me.GrpFlujo.Controls.Add(Me.Label37)
        Me.GrpFlujo.Controls.Add(Me.Label36)
        Me.GrpFlujo.Controls.Add(Me.Label35)
        Me.GrpFlujo.Controls.Add(Me.Label34)
        Me.GrpFlujo.Controls.Add(Me.Label33)
        Me.GrpFlujo.Controls.Add(Me.Label32)
        Me.GrpFlujo.Location = New System.Drawing.Point(682, 99)
        Me.GrpFlujo.Name = "GrpFlujo"
        Me.GrpFlujo.Size = New System.Drawing.Size(325, 540)
        Me.GrpFlujo.TabIndex = 2
        Me.GrpFlujo.TabStop = False
        Me.GrpFlujo.Text = "Flujo de Ingresos y Egresos"
        '
        'CneResultado
        '
        Me.CneResultado.AcceptsTab = True
        Me.CneResultado.BackColor = System.Drawing.Color.LightCyan
        Me.CneResultado.CustomFormat = "###,###,###,##0.00"
        Me.CneResultado.DataType = GetType(Double)
        Me.CneResultado.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CneResultado.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneResultado.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneResultado.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CneResultado.EditFormat.EmptyAsNull = False
        Me.CneResultado.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneResultado.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneResultado.EmptyAsNull = True
        Me.CneResultado.Enabled = False
        Me.CneResultado.ForeColor = System.Drawing.Color.Blue
        Me.CneResultado.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneResultado.Location = New System.Drawing.Point(184, 508)
        Me.CneResultado.MaskInfo.AutoTabWhenFilled = True
        Me.CneResultado.MaxLength = 999999999
        Me.CneResultado.Name = "CneResultado"
        Me.CneResultado.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CneResultado.Size = New System.Drawing.Size(133, 20)
        Me.CneResultado.TabIndex = 204
        Me.CneResultado.Tag = Nothing
        Me.CneResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CneResultado.UseColumnStyles = False
        Me.CneResultado.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.Red
        Me.Label45.Location = New System.Drawing.Point(6, 512)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(136, 13)
        Me.Label45.TabIndex = 203
        Me.Label45.Text = "Resultado( Ing - Egre )"
        '
        'nOtrosGastos
        '
        Me.nOtrosGastos.AcceptsTab = True
        Me.nOtrosGastos.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosGastos.DataType = GetType(Double)
        Me.nOtrosGastos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nOtrosGastos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosGastos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosGastos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosGastos.EditFormat.EmptyAsNull = False
        Me.nOtrosGastos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosGastos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosGastos.EmptyAsNull = True
        Me.nOtrosGastos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosGastos.Location = New System.Drawing.Point(184, 480)
        Me.nOtrosGastos.MaskInfo.AutoTabWhenFilled = True
        Me.nOtrosGastos.MaxLength = 12
        Me.nOtrosGastos.Name = "nOtrosGastos"
        Me.nOtrosGastos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nOtrosGastos.Size = New System.Drawing.Size(133, 20)
        Me.nOtrosGastos.TabIndex = 31
        Me.nOtrosGastos.Tag = Nothing
        Me.nOtrosGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nOtrosGastos.UseColumnStyles = False
        Me.nOtrosGastos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nGastosFamiliares
        '
        Me.nGastosFamiliares.AcceptsTab = True
        Me.nGastosFamiliares.CustomFormat = "###,###,###,##0.00"
        Me.nGastosFamiliares.DataType = GetType(Double)
        Me.nGastosFamiliares.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nGastosFamiliares.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nGastosFamiliares.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nGastosFamiliares.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nGastosFamiliares.EditFormat.EmptyAsNull = False
        Me.nGastosFamiliares.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nGastosFamiliares.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nGastosFamiliares.EmptyAsNull = True
        Me.nGastosFamiliares.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nGastosFamiliares.Location = New System.Drawing.Point(184, 444)
        Me.nGastosFamiliares.MaskInfo.AutoTabWhenFilled = True
        Me.nGastosFamiliares.MaxLength = 12
        Me.nGastosFamiliares.Name = "nGastosFamiliares"
        Me.nGastosFamiliares.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nGastosFamiliares.Size = New System.Drawing.Size(133, 20)
        Me.nGastosFamiliares.TabIndex = 30
        Me.nGastosFamiliares.Tag = Nothing
        Me.nGastosFamiliares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nGastosFamiliares.UseColumnStyles = False
        Me.nGastosFamiliares.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nImpuestosSeguros
        '
        Me.nImpuestosSeguros.AcceptsTab = True
        Me.nImpuestosSeguros.CustomFormat = "###,###,###,##0.00"
        Me.nImpuestosSeguros.DataType = GetType(Double)
        Me.nImpuestosSeguros.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nImpuestosSeguros.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nImpuestosSeguros.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nImpuestosSeguros.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nImpuestosSeguros.EditFormat.EmptyAsNull = False
        Me.nImpuestosSeguros.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nImpuestosSeguros.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nImpuestosSeguros.EmptyAsNull = True
        Me.nImpuestosSeguros.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nImpuestosSeguros.Location = New System.Drawing.Point(184, 408)
        Me.nImpuestosSeguros.MaskInfo.AutoTabWhenFilled = True
        Me.nImpuestosSeguros.MaxLength = 12
        Me.nImpuestosSeguros.Name = "nImpuestosSeguros"
        Me.nImpuestosSeguros.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nImpuestosSeguros.Size = New System.Drawing.Size(133, 20)
        Me.nImpuestosSeguros.TabIndex = 29
        Me.nImpuestosSeguros.Tag = Nothing
        Me.nImpuestosSeguros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nImpuestosSeguros.UseColumnStyles = False
        Me.nImpuestosSeguros.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nAlquileresRentas
        '
        Me.nAlquileresRentas.AcceptsTab = True
        Me.nAlquileresRentas.CustomFormat = "###,###,###,##0.00"
        Me.nAlquileresRentas.DataType = GetType(Double)
        Me.nAlquileresRentas.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nAlquileresRentas.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAlquileresRentas.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nAlquileresRentas.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nAlquileresRentas.EditFormat.EmptyAsNull = False
        Me.nAlquileresRentas.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAlquileresRentas.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nAlquileresRentas.EmptyAsNull = True
        Me.nAlquileresRentas.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAlquileresRentas.Location = New System.Drawing.Point(184, 375)
        Me.nAlquileresRentas.MaskInfo.AutoTabWhenFilled = True
        Me.nAlquileresRentas.MaxLength = 12
        Me.nAlquileresRentas.Name = "nAlquileresRentas"
        Me.nAlquileresRentas.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nAlquileresRentas.Size = New System.Drawing.Size(133, 20)
        Me.nAlquileresRentas.TabIndex = 28
        Me.nAlquileresRentas.Tag = Nothing
        Me.nAlquileresRentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nAlquileresRentas.UseColumnStyles = False
        Me.nAlquileresRentas.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nProvisionMantenimientoReinversion
        '
        Me.nProvisionMantenimientoReinversion.AcceptsTab = True
        Me.nProvisionMantenimientoReinversion.CustomFormat = "###,###,###,##0.00"
        Me.nProvisionMantenimientoReinversion.DataType = GetType(Double)
        Me.nProvisionMantenimientoReinversion.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nProvisionMantenimientoReinversion.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nProvisionMantenimientoReinversion.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nProvisionMantenimientoReinversion.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nProvisionMantenimientoReinversion.EditFormat.EmptyAsNull = False
        Me.nProvisionMantenimientoReinversion.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nProvisionMantenimientoReinversion.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nProvisionMantenimientoReinversion.EmptyAsNull = True
        Me.nProvisionMantenimientoReinversion.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nProvisionMantenimientoReinversion.Location = New System.Drawing.Point(184, 331)
        Me.nProvisionMantenimientoReinversion.MaskInfo.AutoTabWhenFilled = True
        Me.nProvisionMantenimientoReinversion.MaxLength = 12
        Me.nProvisionMantenimientoReinversion.Name = "nProvisionMantenimientoReinversion"
        Me.nProvisionMantenimientoReinversion.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nProvisionMantenimientoReinversion.Size = New System.Drawing.Size(133, 20)
        Me.nProvisionMantenimientoReinversion.TabIndex = 27
        Me.nProvisionMantenimientoReinversion.Tag = Nothing
        Me.nProvisionMantenimientoReinversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nProvisionMantenimientoReinversion.UseColumnStyles = False
        Me.nProvisionMantenimientoReinversion.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nAmortizacionDeuda
        '
        Me.nAmortizacionDeuda.AcceptsTab = True
        Me.nAmortizacionDeuda.CustomFormat = "###,###,###,##0.00"
        Me.nAmortizacionDeuda.DataType = GetType(Double)
        Me.nAmortizacionDeuda.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nAmortizacionDeuda.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAmortizacionDeuda.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nAmortizacionDeuda.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nAmortizacionDeuda.EditFormat.EmptyAsNull = False
        Me.nAmortizacionDeuda.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAmortizacionDeuda.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nAmortizacionDeuda.EmptyAsNull = True
        Me.nAmortizacionDeuda.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAmortizacionDeuda.Location = New System.Drawing.Point(184, 265)
        Me.nAmortizacionDeuda.MaskInfo.AutoTabWhenFilled = True
        Me.nAmortizacionDeuda.MaxLength = 12
        Me.nAmortizacionDeuda.Name = "nAmortizacionDeuda"
        Me.nAmortizacionDeuda.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nAmortizacionDeuda.Size = New System.Drawing.Size(133, 20)
        Me.nAmortizacionDeuda.TabIndex = 26
        Me.nAmortizacionDeuda.Tag = Nothing
        Me.nAmortizacionDeuda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nAmortizacionDeuda.UseColumnStyles = False
        Me.nAmortizacionDeuda.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nGastosOperativos
        '
        Me.nGastosOperativos.AcceptsTab = True
        Me.nGastosOperativos.CustomFormat = "###,###,###,##0.00"
        Me.nGastosOperativos.DataType = GetType(Double)
        Me.nGastosOperativos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nGastosOperativos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nGastosOperativos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nGastosOperativos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nGastosOperativos.EditFormat.EmptyAsNull = False
        Me.nGastosOperativos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nGastosOperativos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nGastosOperativos.EmptyAsNull = True
        Me.nGastosOperativos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nGastosOperativos.Location = New System.Drawing.Point(184, 224)
        Me.nGastosOperativos.MaskInfo.AutoTabWhenFilled = True
        Me.nGastosOperativos.MaxLength = 12
        Me.nGastosOperativos.Name = "nGastosOperativos"
        Me.nGastosOperativos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nGastosOperativos.Size = New System.Drawing.Size(133, 20)
        Me.nGastosOperativos.TabIndex = 25
        Me.nGastosOperativos.Tag = Nothing
        Me.nGastosOperativos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nGastosOperativos.UseColumnStyles = False
        Me.nGastosOperativos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nCostosProduccionComercio
        '
        Me.nCostosProduccionComercio.AcceptsTab = True
        Me.nCostosProduccionComercio.CustomFormat = "###,###,###,##0.00"
        Me.nCostosProduccionComercio.DataType = GetType(Double)
        Me.nCostosProduccionComercio.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nCostosProduccionComercio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCostosProduccionComercio.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nCostosProduccionComercio.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nCostosProduccionComercio.EditFormat.EmptyAsNull = False
        Me.nCostosProduccionComercio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCostosProduccionComercio.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nCostosProduccionComercio.EmptyAsNull = True
        Me.nCostosProduccionComercio.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nCostosProduccionComercio.Location = New System.Drawing.Point(184, 192)
        Me.nCostosProduccionComercio.MaskInfo.AutoTabWhenFilled = True
        Me.nCostosProduccionComercio.MaxLength = 12
        Me.nCostosProduccionComercio.Name = "nCostosProduccionComercio"
        Me.nCostosProduccionComercio.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nCostosProduccionComercio.Size = New System.Drawing.Size(133, 20)
        Me.nCostosProduccionComercio.TabIndex = 24
        Me.nCostosProduccionComercio.Tag = Nothing
        Me.nCostosProduccionComercio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nCostosProduccionComercio.UseColumnStyles = False
        Me.nCostosProduccionComercio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nOtrosIngresos
        '
        Me.nOtrosIngresos.AcceptsTab = True
        Me.nOtrosIngresos.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosIngresos.DataType = GetType(Double)
        Me.nOtrosIngresos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nOtrosIngresos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosIngresos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosIngresos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nOtrosIngresos.EditFormat.EmptyAsNull = False
        Me.nOtrosIngresos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosIngresos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nOtrosIngresos.EmptyAsNull = True
        Me.nOtrosIngresos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nOtrosIngresos.Location = New System.Drawing.Point(181, 123)
        Me.nOtrosIngresos.MaskInfo.AutoTabWhenFilled = True
        Me.nOtrosIngresos.MaxLength = 12
        Me.nOtrosIngresos.Name = "nOtrosIngresos"
        Me.nOtrosIngresos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nOtrosIngresos.Size = New System.Drawing.Size(133, 20)
        Me.nOtrosIngresos.TabIndex = 23
        Me.nOtrosIngresos.Tag = Nothing
        Me.nOtrosIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nOtrosIngresos.UseColumnStyles = False
        Me.nOtrosIngresos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nAlquiler
        '
        Me.nAlquiler.AcceptsTab = True
        Me.nAlquiler.CustomFormat = "###,###,###,##0.00"
        Me.nAlquiler.DataType = GetType(Double)
        Me.nAlquiler.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nAlquiler.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAlquiler.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nAlquiler.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nAlquiler.EditFormat.EmptyAsNull = False
        Me.nAlquiler.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAlquiler.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nAlquiler.EmptyAsNull = True
        Me.nAlquiler.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nAlquiler.Location = New System.Drawing.Point(181, 91)
        Me.nAlquiler.MaskInfo.AutoTabWhenFilled = True
        Me.nAlquiler.MaxLength = 12
        Me.nAlquiler.Name = "nAlquiler"
        Me.nAlquiler.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nAlquiler.Size = New System.Drawing.Size(133, 20)
        Me.nAlquiler.TabIndex = 22
        Me.nAlquiler.Tag = Nothing
        Me.nAlquiler.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nAlquiler.UseColumnStyles = False
        Me.nAlquiler.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'nIngresosActividadEconomica
        '
        Me.nIngresosActividadEconomica.AcceptsTab = True
        Me.nIngresosActividadEconomica.CustomFormat = "###,###,###,##0.00"
        Me.nIngresosActividadEconomica.DataType = GetType(Double)
        Me.nIngresosActividadEconomica.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.nIngresosActividadEconomica.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nIngresosActividadEconomica.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nIngresosActividadEconomica.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.nIngresosActividadEconomica.EditFormat.EmptyAsNull = False
        Me.nIngresosActividadEconomica.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nIngresosActividadEconomica.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.nIngresosActividadEconomica.EmptyAsNull = True
        Me.nIngresosActividadEconomica.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.nIngresosActividadEconomica.Location = New System.Drawing.Point(181, 56)
        Me.nIngresosActividadEconomica.MaskInfo.AutoTabWhenFilled = True
        Me.nIngresosActividadEconomica.MaxLength = 12
        Me.nIngresosActividadEconomica.Name = "nIngresosActividadEconomica"
        Me.nIngresosActividadEconomica.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.nIngresosActividadEconomica.Size = New System.Drawing.Size(133, 20)
        Me.nIngresosActividadEconomica.TabIndex = 21
        Me.nIngresosActividadEconomica.Tag = Nothing
        Me.nIngresosActividadEconomica.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nIngresosActividadEconomica.UseColumnStyles = False
        Me.nIngresosActividadEconomica.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(26, 480)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(71, 13)
        Me.Label44.TabIndex = 191
        Me.Label44.Text = "Otros Gastos:"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(18, 451)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(92, 13)
        Me.Label43.TabIndex = 190
        Me.Label43.Text = "Gastos Familiares:"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(18, 418)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(102, 13)
        Me.Label42.TabIndex = 189
        Me.Label42.Text = "Impuestos/Seguros:"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(18, 375)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(94, 13)
        Me.Label41.TabIndex = 188
        Me.Label41.Text = "Alquileres/Rentas:"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(18, 334)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(123, 13)
        Me.Label40.TabIndex = 187
        Me.Label40.Text = "Prov. Mant./Reinversión"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label39.Location = New System.Drawing.Point(18, 268)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(110, 13)
        Me.Label39.TabIndex = 186
        Me.Label39.Text = "Amortización Deudas:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(18, 227)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(97, 13)
        Me.Label38.TabIndex = 185
        Me.Label38.Text = "Gastos Operativos:"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(18, 195)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(126, 13)
        Me.Label37.TabIndex = 184
        Me.Label37.Text = "Costos de Prod/Comerc.:"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(6, 163)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(52, 13)
        Me.Label36.TabIndex = 183
        Me.Label36.Text = "Egresos"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(19, 126)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(78, 13)
        Me.Label35.TabIndex = 182
        Me.Label35.Text = "Otros Ingresos:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(18, 94)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(44, 13)
        Me.Label34.TabIndex = 181
        Me.Label34.Text = "Alquiler:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(18, 59)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(136, 13)
        Me.Label33.TabIndex = 180
        Me.Label33.Text = "Ingresos Activ. Económica:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.Red
        Me.Label32.Location = New System.Drawing.Point(6, 36)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(55, 13)
        Me.Label32.TabIndex = 158
        Me.Label32.Text = "Ingresos"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(934, 654)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 33
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(847, 654)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 32
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'errGarantiaFiduciaria
        '
        Me.errGarantiaFiduciaria.ContainerControl = Me
        '
        'CneActivoCirculante
        '
        Me.CneActivoCirculante.AcceptsTab = True
        Me.CneActivoCirculante.BackColor = System.Drawing.Color.LightCyan
        Me.CneActivoCirculante.CustomFormat = "###,###,###,##0.00"
        Me.CneActivoCirculante.DataType = GetType(Double)
        Me.CneActivoCirculante.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CneActivoCirculante.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneActivoCirculante.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneActivoCirculante.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CneActivoCirculante.EditFormat.EmptyAsNull = False
        Me.CneActivoCirculante.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneActivoCirculante.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneActivoCirculante.EmptyAsNull = True
        Me.CneActivoCirculante.Enabled = False
        Me.CneActivoCirculante.ForeColor = System.Drawing.Color.Blue
        Me.CneActivoCirculante.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneActivoCirculante.Location = New System.Drawing.Point(146, 33)
        Me.CneActivoCirculante.MaskInfo.AutoTabWhenFilled = True
        Me.CneActivoCirculante.MaxLength = 999999999
        Me.CneActivoCirculante.Name = "CneActivoCirculante"
        Me.CneActivoCirculante.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CneActivoCirculante.Size = New System.Drawing.Size(133, 20)
        Me.CneActivoCirculante.TabIndex = 179
        Me.CneActivoCirculante.Tag = Nothing
        Me.CneActivoCirculante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CneActivoCirculante.UseColumnStyles = False
        Me.CneActivoCirculante.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'CnePasivoCirculante
        '
        Me.CnePasivoCirculante.AcceptsTab = True
        Me.CnePasivoCirculante.BackColor = System.Drawing.Color.LightCyan
        Me.CnePasivoCirculante.CustomFormat = "###,###,###,##0.00"
        Me.CnePasivoCirculante.DataType = GetType(Double)
        Me.CnePasivoCirculante.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CnePasivoCirculante.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoCirculante.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CnePasivoCirculante.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CnePasivoCirculante.EditFormat.EmptyAsNull = False
        Me.CnePasivoCirculante.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoCirculante.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CnePasivoCirculante.EmptyAsNull = True
        Me.CnePasivoCirculante.Enabled = False
        Me.CnePasivoCirculante.ForeColor = System.Drawing.Color.Blue
        Me.CnePasivoCirculante.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CnePasivoCirculante.Location = New System.Drawing.Point(163, 36)
        Me.CnePasivoCirculante.MaskInfo.AutoTabWhenFilled = True
        Me.CnePasivoCirculante.MaxLength = 999999999
        Me.CnePasivoCirculante.Name = "CnePasivoCirculante"
        Me.CnePasivoCirculante.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CnePasivoCirculante.Size = New System.Drawing.Size(133, 20)
        Me.CnePasivoCirculante.TabIndex = 200
        Me.CnePasivoCirculante.Tag = Nothing
        Me.CnePasivoCirculante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CnePasivoCirculante.UseColumnStyles = False
        Me.CnePasivoCirculante.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'CneTotalPasivo
        '
        Me.CneTotalPasivo.AcceptsTab = True
        Me.CneTotalPasivo.BackColor = System.Drawing.Color.LightCyan
        Me.CneTotalPasivo.CustomFormat = "###,###,###,##0.00"
        Me.CneTotalPasivo.DataType = GetType(Double)
        Me.CneTotalPasivo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CneTotalPasivo.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneTotalPasivo.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneTotalPasivo.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CneTotalPasivo.EditFormat.EmptyAsNull = False
        Me.CneTotalPasivo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneTotalPasivo.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneTotalPasivo.EmptyAsNull = True
        Me.CneTotalPasivo.Enabled = False
        Me.CneTotalPasivo.ForeColor = System.Drawing.Color.Blue
        Me.CneTotalPasivo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneTotalPasivo.Location = New System.Drawing.Point(163, 395)
        Me.CneTotalPasivo.MaskInfo.AutoTabWhenFilled = True
        Me.CneTotalPasivo.MaxLength = 999999999
        Me.CneTotalPasivo.Name = "CneTotalPasivo"
        Me.CneTotalPasivo.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CneTotalPasivo.Size = New System.Drawing.Size(133, 20)
        Me.CneTotalPasivo.TabIndex = 201
        Me.CneTotalPasivo.Tag = Nothing
        Me.CneTotalPasivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CneTotalPasivo.UseColumnStyles = False
        Me.CneTotalPasivo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'CneIngresos
        '
        Me.CneIngresos.AcceptsTab = True
        Me.CneIngresos.BackColor = System.Drawing.Color.LightCyan
        Me.CneIngresos.CustomFormat = "###,###,###,##0.00"
        Me.CneIngresos.DataType = GetType(Double)
        Me.CneIngresos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CneIngresos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneIngresos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneIngresos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CneIngresos.EditFormat.EmptyAsNull = False
        Me.CneIngresos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneIngresos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneIngresos.EmptyAsNull = True
        Me.CneIngresos.Enabled = False
        Me.CneIngresos.ForeColor = System.Drawing.Color.Blue
        Me.CneIngresos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneIngresos.Location = New System.Drawing.Point(181, 29)
        Me.CneIngresos.MaskInfo.AutoTabWhenFilled = True
        Me.CneIngresos.MaxLength = 999999999
        Me.CneIngresos.Name = "CneIngresos"
        Me.CneIngresos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CneIngresos.Size = New System.Drawing.Size(133, 20)
        Me.CneIngresos.TabIndex = 205
        Me.CneIngresos.Tag = Nothing
        Me.CneIngresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CneIngresos.UseColumnStyles = False
        Me.CneIngresos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'CneEgresos
        '
        Me.CneEgresos.AcceptsTab = True
        Me.CneEgresos.BackColor = System.Drawing.Color.LightCyan
        Me.CneEgresos.CustomFormat = "###,###,###,##0.00"
        Me.CneEgresos.DataType = GetType(Double)
        Me.CneEgresos.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.CneEgresos.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneEgresos.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneEgresos.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.CneEgresos.EditFormat.EmptyAsNull = False
        Me.CneEgresos.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneEgresos.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CneEgresos.EmptyAsNull = True
        Me.CneEgresos.Enabled = False
        Me.CneEgresos.ForeColor = System.Drawing.Color.Blue
        Me.CneEgresos.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.CneEgresos.Location = New System.Drawing.Point(181, 160)
        Me.CneEgresos.MaskInfo.AutoTabWhenFilled = True
        Me.CneEgresos.MaxLength = 999999999
        Me.CneEgresos.Name = "CneEgresos"
        Me.CneEgresos.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.CneEgresos.Size = New System.Drawing.Size(133, 20)
        Me.CneEgresos.TabIndex = 206
        Me.CneEgresos.Tag = Nothing
        Me.CneEgresos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.CneEgresos.UseColumnStyles = False
        Me.CneEgresos.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'frmSclEditInformacionFinanciera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1036, 693)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.GrpFlujo)
        Me.Controls.Add(Me.GrpFinanciero)
        Me.Controls.Add(Me.grpFechas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclEditInformacionFinanciera"
        Me.Text = "Información Financiera Anual"
        Me.grpFechas.ResumeLayout(False)
        Me.grpFechas.PerformLayout()
        CType(Me.cboTipoMoneda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCorte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFinanciero.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.CnePasivoMasCapital, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nPatrimonio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nOtrosPasivosLargoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nPtmosPorPagarLargoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CnePasivoFijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nOtrasCuentasCortoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nImpuestosPorPagar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nPrestamosPorPagarCortoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nCuentasPorPagarCortoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nProveedores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nOtrosFijos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CneTotalActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nBienesMuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nMaqEquipoRodante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nBienesInmuebles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nOtrosActivos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneActivoFijo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nOtrosCirculantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nInventarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nCuentasPorCobrar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nBancos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFlujo.ResumeLayout(False)
        Me.GrpFlujo.PerformLayout()
        CType(Me.CneResultado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nOtrosGastos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nGastosFamiliares, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nImpuestosSeguros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nAlquileresRentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nProvisionMantenimientoReinversion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nAmortizacionDeuda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nGastosOperativos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nCostosProduccionComercio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nOtrosIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nAlquiler, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nIngresosActividadEconomica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errGarantiaFiduciaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CneActivoCirculante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CnePasivoCirculante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CneTotalPasivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CneIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CneEgresos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpFechas As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoMoneda As C1.Win.C1List.C1Combo
    Friend WithEvents lblTipoMoneda As System.Windows.Forms.Label
    Friend WithEvents cdeFechaCorte As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaSolicitud As System.Windows.Forms.Label
    Friend WithEvents GrpFinanciero As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CneTotalActivo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nBienesMuebles As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nMaqEquipoRodante As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nBienesInmuebles As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents nOtrosActivos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cneActivoFijo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents nOtrosCirculantes As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nInventarios As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nCuentasPorCobrar As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nBancos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nEfectivo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CnePasivoFijo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents nOtrasCuentasCortoPlazo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nImpuestosPorPagar As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nPrestamosPorPagarCortoPlazo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nCuentasPorPagarCortoPlazo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents nProveedores As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents nOtrosPasivosLargoPlazo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nPtmosPorPagarLargoPlazo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents CnePasivoMasCapital As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nPatrimonio As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents GrpFlujo As System.Windows.Forms.GroupBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents nOtrosFijos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents CneResultado As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents nOtrosGastos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nGastosFamiliares As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nImpuestosSeguros As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nAlquileresRentas As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nProvisionMantenimientoReinversion As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nAmortizacionDeuda As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nGastosOperativos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nCostosProduccionComercio As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nOtrosIngresos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nAlquiler As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents nIngresosActividadEconomica As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errGarantiaFiduciaria As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CneActivoCirculante As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents CnePasivoCirculante As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents CneTotalPasivo As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents CneEgresos As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents CneIngresos As C1.Win.C1Input.C1NumericEdit
End Class
