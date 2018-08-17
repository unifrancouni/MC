<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditReestructuracionDeuda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditReestructuracionDeuda))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tabFicha = New C1.Win.C1Command.C1DockingTab
        Me.tabPDatosGrales = New C1.Win.C1Command.C1DockingTabPage
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.cdeFechaReestructuracion = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaReestructuracion = New System.Windows.Forms.Label
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.tabPResolucion = New C1.Win.C1Command.C1DockingTabPage
        Me.grpReestructuracionSocia = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNombreS = New System.Windows.Forms.TextBox
        Me.cboSocia = New C1.Win.C1List.C1Combo
        Me.lblSocia = New System.Windows.Forms.Label
        Me.cdeFechaPrimerPago = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaPrimerPago = New System.Windows.Forms.Label
        Me.cneUltimaCuota = New C1.Win.C1Input.C1NumericEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmdCancelActualizacion = New System.Windows.Forms.Button
        Me.CmdActualizar = New System.Windows.Forms.Button
        Me.cnePlazoAprobado = New C1.Win.C1Input.C1NumericEdit
        Me.cneMontoAprobado = New C1.Win.C1Input.C1NumericEdit
        Me.lblPlazoAprobado = New System.Windows.Forms.Label
        Me.lblMontoAprobado = New System.Windows.Forms.Label
        Me.grpReestructuracion = New System.Windows.Forms.GroupBox
        Me.txtEstadoR = New System.Windows.Forms.TextBox
        Me.txtCodigoR = New System.Windows.Forms.TextBox
        Me.lblEstadoR = New System.Windows.Forms.Label
        Me.lblCodigoR = New System.Windows.Forms.Label
        Me.tbResolucion = New System.Windows.Forms.ToolStrip
        Me.toolAgregarR = New System.Windows.Forms.ToolStripButton
        Me.toolModificarR = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarR = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarR = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaR = New System.Windows.Forms.ToolStripButton
        Me.grdResolucion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.errReestructuracion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.tabFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFicha.SuspendLayout()
        Me.tabPDatosGrales.SuspendLayout()
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cdeFechaReestructuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPResolucion.SuspendLayout()
        Me.grpReestructuracionSocia.SuspendLayout()
        CType(Me.cboSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaPrimerPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneUltimaCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cnePlazoAprobado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneMontoAprobado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpReestructuracion.SuspendLayout()
        Me.tbResolucion.SuspendLayout()
        CType(Me.grdResolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errReestructuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabFicha
        '
        Me.tabFicha.BackColor = System.Drawing.SystemColors.Control
        Me.tabFicha.Controls.Add(Me.tabPDatosGrales)
        Me.tabFicha.Controls.Add(Me.tabPResolucion)
        Me.tabFicha.Location = New System.Drawing.Point(12, 12)
        Me.tabFicha.Name = "tabFicha"
        Me.tabFicha.SelectedIndex = 3
        Me.tabFicha.Size = New System.Drawing.Size(766, 420)
        Me.tabFicha.TabIndex = 0
        '
        'tabPDatosGrales
        '
        Me.tabPDatosGrales.Controls.Add(Me.grpDatosGenerales)
        Me.tabPDatosGrales.Controls.Add(Me.cmdCancelar)
        Me.tabPDatosGrales.Controls.Add(Me.CmdAceptar)
        Me.tabPDatosGrales.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.tabPDatosGrales.Location = New System.Drawing.Point(1, 27)
        Me.tabPDatosGrales.Name = "tabPDatosGrales"
        Me.tabPDatosGrales.Size = New System.Drawing.Size(764, 392)
        Me.tabPDatosGrales.TabIndex = 0
        Me.tabPDatosGrales.Text = "Datos Generales Reestructuración"
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.lblObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.txtObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaReestructuracion)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaReestructuracion)
        Me.grpDatosGenerales.Controls.Add(Me.txtEstado)
        Me.grpDatosGenerales.Controls.Add(Me.txtCodigo)
        Me.grpDatosGenerales.Controls.Add(Me.lblEstado)
        Me.grpDatosGenerales.Controls.Add(Me.lblCodigo)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(21, 19)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(726, 188)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Generales Reestructuración:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(40, 124)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 25
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(167, 121)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(536, 43)
        Me.txtObservaciones.TabIndex = 3
        '
        'cdeFechaReestructuracion
        '
        Me.cdeFechaReestructuracion.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaReestructuracion.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaReestructuracion.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaReestructuracion.Location = New System.Drawing.Point(167, 91)
        Me.cdeFechaReestructuracion.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaReestructuracion.MaskInfo.EmptyAsNull = True
        Me.cdeFechaReestructuracion.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaReestructuracion.Name = "cdeFechaReestructuracion"
        Me.cdeFechaReestructuracion.Size = New System.Drawing.Size(146, 20)
        Me.cdeFechaReestructuracion.TabIndex = 2
        Me.cdeFechaReestructuracion.Tag = Nothing
        Me.cdeFechaReestructuracion.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaReestructuracion
        '
        Me.lblFechaReestructuracion.AutoSize = True
        Me.lblFechaReestructuracion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaReestructuracion.Location = New System.Drawing.Point(40, 94)
        Me.lblFechaReestructuracion.Name = "lblFechaReestructuracion"
        Me.lblFechaReestructuracion.Size = New System.Drawing.Size(124, 13)
        Me.lblFechaReestructuracion.TabIndex = 6
        Me.lblFechaReestructuracion.Text = "Fecha Reestructuración:"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(167, 61)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.ShortcutsEnabled = False
        Me.txtEstado.Size = New System.Drawing.Size(146, 20)
        Me.txtEstado.TabIndex = 1
        Me.txtEstado.Tag = "LAYOUT:FLAT"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(167, 31)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.ShortcutsEnabled = False
        Me.txtCodigo.Size = New System.Drawing.Size(146, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(40, 64)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(127, 13)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Estado Reestructuración:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(40, 31)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(127, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código Reestructuración:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(674, 347)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(595, 347)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 0
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'tabPResolucion
        '
        Me.tabPResolucion.Controls.Add(Me.grpReestructuracionSocia)
        Me.tabPResolucion.Controls.Add(Me.grpReestructuracion)
        Me.tabPResolucion.Controls.Add(Me.tbResolucion)
        Me.tabPResolucion.Controls.Add(Me.grdResolucion)
        Me.tabPResolucion.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.tabPResolucion.Location = New System.Drawing.Point(1, 27)
        Me.tabPResolucion.Name = "tabPResolucion"
        Me.tabPResolucion.Size = New System.Drawing.Size(764, 392)
        Me.tabPResolucion.TabIndex = 1
        Me.tabPResolucion.Text = "Reestructuración Crédito Socias"
        '
        'grpReestructuracionSocia
        '
        Me.grpReestructuracionSocia.Controls.Add(Me.Label3)
        Me.grpReestructuracionSocia.Controls.Add(Me.txtNombreS)
        Me.grpReestructuracionSocia.Controls.Add(Me.cboSocia)
        Me.grpReestructuracionSocia.Controls.Add(Me.lblSocia)
        Me.grpReestructuracionSocia.Controls.Add(Me.cdeFechaPrimerPago)
        Me.grpReestructuracionSocia.Controls.Add(Me.lblFechaPrimerPago)
        Me.grpReestructuracionSocia.Controls.Add(Me.cneUltimaCuota)
        Me.grpReestructuracionSocia.Controls.Add(Me.Label2)
        Me.grpReestructuracionSocia.Controls.Add(Me.CmdCancelActualizacion)
        Me.grpReestructuracionSocia.Controls.Add(Me.CmdActualizar)
        Me.grpReestructuracionSocia.Controls.Add(Me.cnePlazoAprobado)
        Me.grpReestructuracionSocia.Controls.Add(Me.cneMontoAprobado)
        Me.grpReestructuracionSocia.Controls.Add(Me.lblPlazoAprobado)
        Me.grpReestructuracionSocia.Controls.Add(Me.lblMontoAprobado)
        Me.grpReestructuracionSocia.Location = New System.Drawing.Point(21, 96)
        Me.grpReestructuracionSocia.Name = "grpReestructuracionSocia"
        Me.grpReestructuracionSocia.Size = New System.Drawing.Size(728, 285)
        Me.grpReestructuracionSocia.TabIndex = 22
        Me.grpReestructuracionSocia.TabStop = False
        Me.grpReestructuracionSocia.Text = "Datos Reestructuración de Crédito a Socia: "
        Me.grpReestructuracionSocia.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(87, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Nombre Socia:"
        '
        'txtNombreS
        '
        Me.txtNombreS.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreS.Enabled = False
        Me.txtNombreS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreS.Location = New System.Drawing.Point(222, 80)
        Me.txtNombreS.Name = "txtNombreS"
        Me.txtNombreS.ReadOnly = True
        Me.txtNombreS.Size = New System.Drawing.Size(392, 20)
        Me.txtNombreS.TabIndex = 1
        Me.txtNombreS.Tag = "LAYOUT:FLAT"
        '
        'cboSocia
        '
        Me.cboSocia.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboSocia.AutoCompletion = True
        Me.cboSocia.AutoDropDown = True
        Me.cboSocia.Caption = ""
        Me.cboSocia.CaptionHeight = 17
        Me.cboSocia.CaptionStyle = Style1
        Me.cboSocia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSocia.ColumnCaptionHeight = 17
        Me.cboSocia.ColumnFooterHeight = 17
        Me.cboSocia.ContentHeight = 15
        Me.cboSocia.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboSocia.DisplayMember = "sNumeroCedula"
        Me.cboSocia.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboSocia.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSocia.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSocia.EditorHeight = 15
        Me.cboSocia.EvenRowStyle = Style2
        Me.cboSocia.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboSocia.FooterStyle = Style3
        Me.cboSocia.GapHeight = 2
        Me.cboSocia.HeadingStyle = Style4
        Me.cboSocia.HighLightRowStyle = Style5
        Me.cboSocia.Images.Add(CType(resources.GetObject("cboSocia.Images"), System.Drawing.Image))
        Me.cboSocia.ItemHeight = 15
        Me.cboSocia.LimitToList = True
        Me.cboSocia.Location = New System.Drawing.Point(222, 52)
        Me.cboSocia.MatchEntryTimeout = CType(2000, Long)
        Me.cboSocia.MaxDropDownItems = CType(5, Short)
        Me.cboSocia.MaxLength = 32767
        Me.cboSocia.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboSocia.Name = "cboSocia"
        Me.cboSocia.OddRowStyle = Style6
        Me.cboSocia.PartialRightColumn = False
        Me.cboSocia.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboSocia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboSocia.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboSocia.SelectedStyle = Style7
        Me.cboSocia.Size = New System.Drawing.Size(392, 21)
        Me.cboSocia.Style = Style8
        Me.cboSocia.SuperBack = True
        Me.cboSocia.TabIndex = 0
        Me.cboSocia.ValueMember = "nSclFichaNotificacionDetalleID"
        Me.cboSocia.PropBag = resources.GetString("cboSocia.PropBag")
        '
        'lblSocia
        '
        Me.lblSocia.AutoSize = True
        Me.lblSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSocia.Location = New System.Drawing.Point(87, 52)
        Me.lblSocia.Name = "lblSocia"
        Me.lblSocia.Size = New System.Drawing.Size(73, 13)
        Me.lblSocia.TabIndex = 105
        Me.lblSocia.Text = "Cédula Socia:"
        '
        'cdeFechaPrimerPago
        '
        Me.cdeFechaPrimerPago.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaPrimerPago.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaPrimerPago.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaPrimerPago.Location = New System.Drawing.Point(222, 142)
        Me.cdeFechaPrimerPago.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaPrimerPago.MaskInfo.EmptyAsNull = True
        Me.cdeFechaPrimerPago.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaPrimerPago.Name = "cdeFechaPrimerPago"
        Me.cdeFechaPrimerPago.Size = New System.Drawing.Size(111, 20)
        Me.cdeFechaPrimerPago.TabIndex = 3
        Me.cdeFechaPrimerPago.Tag = Nothing
        Me.cdeFechaPrimerPago.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaPrimerPago
        '
        Me.lblFechaPrimerPago.AutoSize = True
        Me.lblFechaPrimerPago.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaPrimerPago.Location = New System.Drawing.Point(87, 142)
        Me.lblFechaPrimerPago.Name = "lblFechaPrimerPago"
        Me.lblFechaPrimerPago.Size = New System.Drawing.Size(128, 13)
        Me.lblFechaPrimerPago.TabIndex = 45
        Me.lblFechaPrimerPago.Text = "F. Primer Pago Reestruc.:"
        '
        'cneUltimaCuota
        '
        Me.cneUltimaCuota.AcceptsTab = True
        Me.cneUltimaCuota.CustomFormat = "00"
        Me.cneUltimaCuota.DataType = GetType(Double)
        Me.cneUltimaCuota.DisplayFormat.CustomFormat = "00"
        Me.cneUltimaCuota.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneUltimaCuota.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneUltimaCuota.EditFormat.CustomFormat = "00"
        Me.cneUltimaCuota.EditFormat.EmptyAsNull = False
        Me.cneUltimaCuota.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneUltimaCuota.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneUltimaCuota.EmptyAsNull = True
        Me.cneUltimaCuota.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneUltimaCuota.Location = New System.Drawing.Point(222, 110)
        Me.cneUltimaCuota.MaskInfo.AutoTabWhenFilled = True
        Me.cneUltimaCuota.MaxLength = 99
        Me.cneUltimaCuota.Name = "cneUltimaCuota"
        Me.cneUltimaCuota.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneUltimaCuota.Size = New System.Drawing.Size(111, 20)
        Me.cneUltimaCuota.TabIndex = 2
        Me.cneUltimaCuota.Tag = Nothing
        Me.cneUltimaCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneUltimaCuota.UseColumnStyles = False
        Me.cneUltimaCuota.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(87, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Ultima Cuota Cancelada:"
        '
        'CmdCancelActualizacion
        '
        Me.CmdCancelActualizacion.Image = CType(resources.GetObject("CmdCancelActualizacion.Image"), System.Drawing.Image)
        Me.CmdCancelActualizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdCancelActualizacion.Location = New System.Drawing.Point(622, 244)
        Me.CmdCancelActualizacion.Name = "CmdCancelActualizacion"
        Me.CmdCancelActualizacion.Size = New System.Drawing.Size(82, 25)
        Me.CmdCancelActualizacion.TabIndex = 7
        Me.CmdCancelActualizacion.Text = "Cancelar"
        Me.CmdCancelActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdCancelActualizacion.UseVisualStyleBackColor = True
        '
        'CmdActualizar
        '
        Me.CmdActualizar.Image = CType(resources.GetObject("CmdActualizar.Image"), System.Drawing.Image)
        Me.CmdActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdActualizar.Location = New System.Drawing.Point(534, 244)
        Me.CmdActualizar.Name = "CmdActualizar"
        Me.CmdActualizar.Size = New System.Drawing.Size(82, 25)
        Me.CmdActualizar.TabIndex = 6
        Me.CmdActualizar.Text = "Actualizar"
        Me.CmdActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdActualizar.UseVisualStyleBackColor = True
        '
        'cnePlazoAprobado
        '
        Me.cnePlazoAprobado.AcceptsTab = True
        Me.cnePlazoAprobado.CustomFormat = "00"
        Me.cnePlazoAprobado.DataType = GetType(Double)
        Me.cnePlazoAprobado.DisplayFormat.CustomFormat = "00"
        Me.cnePlazoAprobado.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cnePlazoAprobado.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cnePlazoAprobado.EditFormat.CustomFormat = "00"
        Me.cnePlazoAprobado.EditFormat.EmptyAsNull = False
        Me.cnePlazoAprobado.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cnePlazoAprobado.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cnePlazoAprobado.EmptyAsNull = True
        Me.cnePlazoAprobado.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cnePlazoAprobado.Location = New System.Drawing.Point(222, 176)
        Me.cnePlazoAprobado.MaskInfo.AutoTabWhenFilled = True
        Me.cnePlazoAprobado.MaxLength = 99
        Me.cnePlazoAprobado.Name = "cnePlazoAprobado"
        Me.cnePlazoAprobado.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cnePlazoAprobado.Size = New System.Drawing.Size(111, 20)
        Me.cnePlazoAprobado.TabIndex = 4
        Me.cnePlazoAprobado.Tag = Nothing
        Me.cnePlazoAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cnePlazoAprobado.UseColumnStyles = False
        Me.cnePlazoAprobado.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'cneMontoAprobado
        '
        Me.cneMontoAprobado.AcceptsTab = True
        Me.cneMontoAprobado.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMontoAprobado.DataType = GetType(Double)
        Me.cneMontoAprobado.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneMontoAprobado.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoAprobado.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoAprobado.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMontoAprobado.EditFormat.EmptyAsNull = False
        Me.cneMontoAprobado.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoAprobado.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMontoAprobado.EmptyAsNull = True
        Me.cneMontoAprobado.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMontoAprobado.Location = New System.Drawing.Point(222, 210)
        Me.cneMontoAprobado.MaskInfo.AutoTabWhenFilled = True
        Me.cneMontoAprobado.MaxLength = 999999999
        Me.cneMontoAprobado.Name = "cneMontoAprobado"
        Me.cneMontoAprobado.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMontoAprobado.Size = New System.Drawing.Size(111, 20)
        Me.cneMontoAprobado.TabIndex = 5
        Me.cneMontoAprobado.Tag = Nothing
        Me.cneMontoAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMontoAprobado.UseColumnStyles = False
        Me.cneMontoAprobado.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblPlazoAprobado
        '
        Me.lblPlazoAprobado.AutoSize = True
        Me.lblPlazoAprobado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPlazoAprobado.Location = New System.Drawing.Point(87, 176)
        Me.lblPlazoAprobado.Name = "lblPlazoAprobado"
        Me.lblPlazoAprobado.Size = New System.Drawing.Size(112, 13)
        Me.lblPlazoAprobado.TabIndex = 33
        Me.lblPlazoAprobado.Text = "Plazo Reestructurado:"
        '
        'lblMontoAprobado
        '
        Me.lblMontoAprobado.AutoSize = True
        Me.lblMontoAprobado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMontoAprobado.Location = New System.Drawing.Point(87, 210)
        Me.lblMontoAprobado.Name = "lblMontoAprobado"
        Me.lblMontoAprobado.Size = New System.Drawing.Size(116, 13)
        Me.lblMontoAprobado.TabIndex = 32
        Me.lblMontoAprobado.Text = "Monto Reestructurado:"
        '
        'grpReestructuracion
        '
        Me.grpReestructuracion.Controls.Add(Me.txtEstadoR)
        Me.grpReestructuracion.Controls.Add(Me.txtCodigoR)
        Me.grpReestructuracion.Controls.Add(Me.lblEstadoR)
        Me.grpReestructuracion.Controls.Add(Me.lblCodigoR)
        Me.grpReestructuracion.Location = New System.Drawing.Point(21, 14)
        Me.grpReestructuracion.Name = "grpReestructuracion"
        Me.grpReestructuracion.Size = New System.Drawing.Size(728, 51)
        Me.grpReestructuracion.TabIndex = 21
        Me.grpReestructuracion.TabStop = False
        Me.grpReestructuracion.Text = "Datos Generales Reestructuración:"
        '
        'txtEstadoR
        '
        Me.txtEstadoR.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstadoR.Enabled = False
        Me.txtEstadoR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoR.Location = New System.Drawing.Point(285, 19)
        Me.txtEstadoR.Name = "txtEstadoR"
        Me.txtEstadoR.ReadOnly = True
        Me.txtEstadoR.ShortcutsEnabled = False
        Me.txtEstadoR.Size = New System.Drawing.Size(199, 20)
        Me.txtEstadoR.TabIndex = 1
        Me.txtEstadoR.Tag = "LAYOUT:FLAT"
        '
        'txtCodigoR
        '
        Me.txtCodigoR.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoR.Enabled = False
        Me.txtCodigoR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoR.Location = New System.Drawing.Point(95, 19)
        Me.txtCodigoR.Name = "txtCodigoR"
        Me.txtCodigoR.ReadOnly = True
        Me.txtCodigoR.ShortcutsEnabled = False
        Me.txtCodigoR.Size = New System.Drawing.Size(115, 20)
        Me.txtCodigoR.TabIndex = 0
        Me.txtCodigoR.Tag = "LAYOUT:FLAT"
        '
        'lblEstadoR
        '
        Me.lblEstadoR.AutoSize = True
        Me.lblEstadoR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstadoR.Location = New System.Drawing.Point(216, 22)
        Me.lblEstadoR.Name = "lblEstadoR"
        Me.lblEstadoR.Size = New System.Drawing.Size(43, 13)
        Me.lblEstadoR.TabIndex = 33
        Me.lblEstadoR.Text = "Estado:"
        '
        'lblCodigoR
        '
        Me.lblCodigoR.AutoSize = True
        Me.lblCodigoR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoR.Location = New System.Drawing.Point(17, 22)
        Me.lblCodigoR.Name = "lblCodigoR"
        Me.lblCodigoR.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoR.TabIndex = 32
        Me.lblCodigoR.Text = "Código:"
        '
        'tbResolucion
        '
        Me.tbResolucion.AutoSize = False
        Me.tbResolucion.Dock = System.Windows.Forms.DockStyle.None
        Me.tbResolucion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarR, Me.toolModificarR, Me.toolEliminarR, Me.toolSeparador1, Me.toolRefrescarR, Me.toolSeparador2, Me.toolAyudaR})
        Me.tbResolucion.Location = New System.Drawing.Point(21, 68)
        Me.tbResolucion.Name = "tbResolucion"
        Me.tbResolucion.Size = New System.Drawing.Size(728, 25)
        Me.tbResolucion.Stretch = True
        Me.tbResolucion.TabIndex = 20
        Me.tbResolucion.Text = "ToolStrip1"
        '
        'toolAgregarR
        '
        Me.toolAgregarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarR.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarR.Name = "toolAgregarR"
        Me.toolAgregarR.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarR.Text = "Agregar Socia"
        Me.toolAgregarR.ToolTipText = "Agregar Socia"
        '
        'toolModificarR
        '
        Me.toolModificarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarR.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarR.Name = "toolModificarR"
        Me.toolModificarR.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarR.Text = "Modificar Reestructuración Socia"
        Me.toolModificarR.ToolTipText = "Modificar Reestructuración Socia"
        '
        'toolEliminarR
        '
        Me.toolEliminarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarR.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarR.Name = "toolEliminarR"
        Me.toolEliminarR.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarR.Text = "Eliminar"
        '
        'toolSeparador1
        '
        Me.toolSeparador1.Name = "toolSeparador1"
        Me.toolSeparador1.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarR
        '
        Me.toolRefrescarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarR.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarR.Name = "toolRefrescarR"
        Me.toolRefrescarR.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarR.Text = "Refrescar"
        '
        'toolSeparador2
        '
        Me.toolSeparador2.Name = "toolSeparador2"
        Me.toolSeparador2.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaR
        '
        Me.toolAyudaR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaR.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaR.Name = "toolAyudaR"
        Me.toolAyudaR.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaR.Text = "Ayuda"
        Me.toolAyudaR.ToolTipText = "Ayuda"
        '
        'grdResolucion
        '
        Me.grdResolucion.AllowFilter = False
        Me.grdResolucion.AllowUpdate = False
        Me.grdResolucion.Caption = "Resolución de Reestructuración de Créditos a Socias"
        Me.grdResolucion.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdResolucion.FilterBar = True
        Me.grdResolucion.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdResolucion.Images.Add(CType(resources.GetObject("grdResolucion.Images"), System.Drawing.Image))
        Me.grdResolucion.Location = New System.Drawing.Point(21, 96)
        Me.grdResolucion.Name = "grdResolucion"
        Me.grdResolucion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdResolucion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdResolucion.PreviewInfo.ZoomFactor = 75
        Me.grdResolucion.PrintInfo.PageSettings = CType(resources.GetObject("grdResolucion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdResolucion.Size = New System.Drawing.Size(728, 285)
        Me.grdResolucion.TabIndex = 16
        Me.grdResolucion.Text = "grdResolucion"
        Me.grdResolucion.PropBag = resources.GetString("grdResolucion.PropBag")
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
        'errReestructuracion
        '
        Me.errReestructuracion.ContainerControl = Me
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
        'frmSccEditReestructuracionDeuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 444)
        Me.Controls.Add(Me.tabFicha)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reestructuración de Deuda")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditReestructuracionDeuda"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Reestructuración Deuda"
        CType(Me.tabFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFicha.ResumeLayout(False)
        Me.tabPDatosGrales.ResumeLayout(False)
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cdeFechaReestructuracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPResolucion.ResumeLayout(False)
        Me.grpReestructuracionSocia.ResumeLayout(False)
        Me.grpReestructuracionSocia.PerformLayout()
        CType(Me.cboSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaPrimerPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneUltimaCuota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cnePlazoAprobado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneMontoAprobado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpReestructuracion.ResumeLayout(False)
        Me.grpReestructuracion.PerformLayout()
        Me.tbResolucion.ResumeLayout(False)
        Me.tbResolucion.PerformLayout()
        CType(Me.grdResolucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errReestructuracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabFicha As C1.Win.C1Command.C1DockingTab
    Friend WithEvents tabPDatosGrales As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents tabPResolucion As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grdResolucion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents errReestructuracion As System.Windows.Forms.ErrorProvider
    Friend WithEvents tbResolucion As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaR As System.Windows.Forms.ToolStripButton
    Friend WithEvents cdeFechaReestructuracion As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaReestructuracion As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents grpReestructuracion As System.Windows.Forms.GroupBox
    Friend WithEvents txtEstadoR As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoR As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoR As System.Windows.Forms.Label
    Friend WithEvents lblCodigoR As System.Windows.Forms.Label
    Friend WithEvents grpReestructuracionSocia As System.Windows.Forms.GroupBox
    Friend WithEvents lblPlazoAprobado As System.Windows.Forms.Label
    Friend WithEvents lblMontoAprobado As System.Windows.Forms.Label
    Friend WithEvents cneMontoAprobado As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cnePlazoAprobado As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents CmdActualizar As System.Windows.Forms.Button
    Friend WithEvents CmdCancelActualizacion As System.Windows.Forms.Button
    Friend WithEvents cneUltimaCuota As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cdeFechaPrimerPago As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaPrimerPago As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreS As System.Windows.Forms.TextBox
    Friend WithEvents cboSocia As C1.Win.C1List.C1Combo
    Friend WithEvents lblSocia As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
