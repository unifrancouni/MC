<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnComprobantesCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnComprobantesCheque))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadGrande = New System.Windows.Forms.RadioButton()
        Me.RadPequeno = New System.Windows.Forms.RadioButton()
        Me.grpGenerales = New System.Windows.Forms.GroupBox()
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaH = New System.Windows.Forms.Label()
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaD = New System.Windows.Forms.Label()
        Me.tbCuenta = New System.Windows.Forms.ToolStrip()
        Me.toolAgregarC = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarC = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyudaC = New System.Windows.Forms.ToolStripButton()
        Me.grdDetalles = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdComprobante = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbComprobante = New System.Windows.Forms.ToolStrip()
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolModificar = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarChequera = New System.Windows.Forms.ToolStripButton()
        Me.toolAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImpresiones = New System.Windows.Forms.ToolStripSplitButton()
        Me.toolImprimir = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolImprimirf = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolImprimirN = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCuenta.SuspendLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbComprobante.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.GroupBox1)
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.tbCuenta)
        Me.C1Sizer1.Controls.Add(Me.grdDetalles)
        Me.C1Sizer1.Controls.Add(Me.grdComprobante)
        Me.C1Sizer1.Controls.Add(Me.tbComprobante)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(810, 488)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadGrande)
        Me.GroupBox1.Controls.Add(Me.RadPequeno)
        Me.GroupBox1.Location = New System.Drawing.Point(331, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(211, 41)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Formato cheque"
        '
        'RadGrande
        '
        Me.RadGrande.AutoSize = True
        Me.RadGrande.Location = New System.Drawing.Point(107, 15)
        Me.RadGrande.Name = "RadGrande"
        Me.RadGrande.Size = New System.Drawing.Size(60, 17)
        Me.RadGrande.TabIndex = 1
        Me.RadGrande.Text = "Grande"
        Me.RadGrande.UseVisualStyleBackColor = True
        '
        'RadPequeno
        '
        Me.RadPequeno.AutoSize = True
        Me.RadPequeno.Checked = True
        Me.RadPequeno.Location = New System.Drawing.Point(17, 15)
        Me.RadPequeno.Name = "RadPequeno"
        Me.RadPequeno.Size = New System.Drawing.Size(68, 17)
        Me.RadPequeno.TabIndex = 0
        Me.RadPequeno.TabStop = True
        Me.RadPequeno.Text = "Pequeño"
        Me.RadPequeno.UseVisualStyleBackColor = True
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 25)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(323, 41)
        Me.grpGenerales.TabIndex = 16
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione Fechas de Corte: "
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(210, 16)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 42
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(169, 21)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaH.TabIndex = 41
        Me.lblFechaH.Text = "Hasta:"
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(52, 18)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 39
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(6, 21)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(41, 13)
        Me.lblFechaD.TabIndex = 40
        Me.lblFechaD.Text = "Desde:"
        '
        'tbCuenta
        '
        Me.tbCuenta.AutoSize = False
        Me.tbCuenta.Dock = System.Windows.Forms.DockStyle.None
        Me.tbCuenta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarC, Me.toolModificarC, Me.toolSeparator2, Me.toolAyudaC})
        Me.tbCuenta.Location = New System.Drawing.Point(4, 270)
        Me.tbCuenta.Name = "tbCuenta"
        Me.tbCuenta.Size = New System.Drawing.Size(164, 23)
        Me.tbCuenta.Stretch = True
        Me.tbCuenta.TabIndex = 15
        Me.tbCuenta.Text = "ToolStrip1"
        '
        'toolAgregarC
        '
        Me.toolAgregarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarC.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarC.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarC.Name = "toolAgregarC"
        Me.toolAgregarC.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregarC.Text = "Agregar Codificación"
        Me.toolAgregarC.ToolTipText = "Agregar Codificación"
        '
        'toolModificarC
        '
        Me.toolModificarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarC.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarC.Name = "toolModificarC"
        Me.toolModificarC.Size = New System.Drawing.Size(23, 20)
        Me.toolModificarC.Text = "Modificar Codificación"
        Me.toolModificarC.ToolTipText = "Modificar Codificación"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolAyudaC
        '
        Me.toolAyudaC.AutoSize = False
        Me.toolAyudaC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaC.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaC.Name = "toolAyudaC"
        Me.toolAyudaC.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaC.Text = "Ayuda"
        Me.toolAyudaC.ToolTipText = "Ayuda"
        '
        'grdDetalles
        '
        Me.grdDetalles.AllowFilter = False
        Me.grdDetalles.AllowUpdate = False
        Me.grdDetalles.Caption = "Codificación Contable Comprobante de Diario"
        Me.grdDetalles.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDetalles.FilterBar = True
        Me.grdDetalles.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDetalles.Images.Add(CType(resources.GetObject("grdDetalles.Images"), System.Drawing.Image))
        Me.grdDetalles.Location = New System.Drawing.Point(4, 297)
        Me.grdDetalles.Name = "grdDetalles"
        Me.grdDetalles.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetalles.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetalles.PreviewInfo.ZoomFactor = 75.0R
        Me.grdDetalles.PrintInfo.PageSettings = CType(resources.GetObject("grdDetalles.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetalles.Size = New System.Drawing.Size(802, 187)
        Me.grdDetalles.TabIndex = 14
        Me.grdDetalles.Text = "grdModulo"
        Me.grdDetalles.PropBag = resources.GetString("grdDetalles.PropBag")
        '
        'grdComprobante
        '
        Me.grdComprobante.AllowFilter = False
        Me.grdComprobante.AllowUpdate = False
        Me.grdComprobante.Caption = "Listado de Comprobantes de Diario"
        Me.grdComprobante.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdComprobante.FilterBar = True
        Me.grdComprobante.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdComprobante.Images.Add(CType(resources.GetObject("grdComprobante.Images"), System.Drawing.Image))
        Me.grdComprobante.Location = New System.Drawing.Point(4, 70)
        Me.grdComprobante.Name = "grdComprobante"
        Me.grdComprobante.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdComprobante.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdComprobante.PreviewInfo.ZoomFactor = 75.0R
        Me.grdComprobante.PrintInfo.PageSettings = CType(resources.GetObject("grdComprobante.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdComprobante.Size = New System.Drawing.Size(802, 196)
        Me.grdComprobante.TabIndex = 13
        Me.grdComprobante.Text = "grdDocSoporte"
        Me.grdComprobante.PropBag = resources.GetString("grdComprobante.PropBag")
        '
        'tbComprobante
        '
        Me.tbComprobante.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolModificarChequera, Me.toolAnular, Me.ToolStripButton7, Me.toolRefrescar, Me.toolSeparator1, Me.toolImpresiones, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbComprobante.Location = New System.Drawing.Point(4, 4)
        Me.tbComprobante.Name = "tbComprobante"
        Me.tbComprobante.Size = New System.Drawing.Size(802, 17)
        Me.tbComprobante.Stretch = True
        Me.tbComprobante.TabIndex = 12
        Me.tbComprobante.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 14)
        Me.toolAgregar.Text = "Agregar Comprobante"
        Me.toolAgregar.ToolTipText = "Agregar Comprobante"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 14)
        Me.toolModificar.Text = "Modificar Comprobante"
        Me.toolModificar.ToolTipText = "Modificar Comprobante"
        '
        'toolModificarChequera
        '
        Me.toolModificarChequera.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarChequera.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolModificarChequera.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarChequera.Name = "toolModificarChequera"
        Me.toolModificarChequera.Size = New System.Drawing.Size(23, 14)
        Me.toolModificarChequera.Text = "Modificar Número de Cheque"
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 14)
        Me.toolAnular.Text = "Anular Comprobante"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 17)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 14)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(6, 17)
        '
        'toolImpresiones
        '
        Me.toolImpresiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImpresiones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimir, Me.toolImprimirf, Me.toolImprimirN})
        Me.toolImpresiones.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImpresiones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImpresiones.Name = "toolImpresiones"
        Me.toolImpresiones.Size = New System.Drawing.Size(32, 14)
        Me.toolImpresiones.Text = "Impresión Cheques"
        '
        'toolImprimir
        '
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(264, 22)
        Me.toolImprimir.Text = "Imprimir Comprobante de Cheque"
        Me.toolImprimir.ToolTipText = "Imprimir Cheque Actual"
        '
        'toolImprimirf
        '
        Me.toolImprimirf.Image = Global.SMUSURA0.My.Resources.Resources.bookmark_folder
        Me.toolImprimirf.Name = "toolImprimirf"
        Me.toolImprimirf.Size = New System.Drawing.Size(264, 22)
        Me.toolImprimirf.Text = "Imprimir Cheques x Fechas de Corte"
        Me.toolImprimirf.ToolTipText = "Imprimir Cheques x Fechas de Corte"
        '
        'toolImprimirN
        '
        Me.toolImprimirN.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.toolImprimirN.Name = "toolImprimirN"
        Me.toolImprimirN.Size = New System.Drawing.Size(264, 22)
        Me.toolImprimirN.Text = "Imprimir Cheques x Rangos"
        Me.toolImprimirN.ToolTipText = "Imprimir Cheques x Rangos"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(6, 17)
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 14)
        Me.toolAyuda.Text = "Ayuda"
        Me.toolAyuda.ToolTipText = "Ayuda"
        '
        'toolSalir
        '
        Me.toolSalir.BackColor = System.Drawing.Color.Transparent
        Me.toolSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSalir.Name = "toolSalir"
        Me.toolSalir.Size = New System.Drawing.Size(23, 14)
        Me.toolSalir.Text = "Cerrar"
        Me.toolSalir.ToolTipText = "Salir"
        '
        'frmScnComprobantesCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 488)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Comprobantes de Cheque")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScnComprobantesCheque"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Comprobantes de Cheque"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCuenta.ResumeLayout(False)
        Me.tbCuenta.PerformLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbComprobante.ResumeLayout(False)
        Me.tbComprobante.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbCuenta As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaC As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdDetalles As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdComprobante As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbComprobante As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents toolModificarChequera As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolImpresiones As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirf As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadGrande As System.Windows.Forms.RadioButton
    Friend WithEvents RadPequeno As System.Windows.Forms.RadioButton
End Class
