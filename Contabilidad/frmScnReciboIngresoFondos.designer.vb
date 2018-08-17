<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnReciboIngresoFondos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnReciboIngresoFondos))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.tbCuenta = New System.Windows.Forms.ToolStrip
        Me.toolAgregarC = New System.Windows.Forms.ToolStripButton
        Me.toolModificarC = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaC = New System.Windows.Forms.ToolStripButton
        Me.grdDetalles = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdRecibo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbRecibo = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolAnular = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCuenta.SuspendLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbRecibo.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.tbCuenta)
        Me.C1Sizer1.Controls.Add(Me.grdDetalles)
        Me.C1Sizer1.Controls.Add(Me.grdRecibo)
        Me.C1Sizer1.Controls.Add(Me.tbRecibo)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(692, 509)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 25)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(684, 41)
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
        Me.cdeFechaH.Location = New System.Drawing.Point(485, 13)
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
        Me.lblFechaH.Location = New System.Drawing.Point(374, 16)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(108, 13)
        Me.lblFechaH.TabIndex = 41
        Me.lblFechaH.Text = "Fecha Recibo Hasta:"
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(269, 13)
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
        Me.lblFechaD.Location = New System.Drawing.Point(155, 16)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(111, 13)
        Me.lblFechaD.TabIndex = 40
        Me.lblFechaD.Text = "Fecha Recibo Desde:"
        '
        'tbCuenta
        '
        Me.tbCuenta.AutoSize = False
        Me.tbCuenta.Dock = System.Windows.Forms.DockStyle.None
        Me.tbCuenta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarC, Me.toolModificarC, Me.toolSeparator2, Me.toolAyudaC})
        Me.tbCuenta.Location = New System.Drawing.Point(4, 281)
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
        Me.grdDetalles.Caption = "Codificación Contable Recibo de Ingreso de Fondos"
        Me.grdDetalles.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDetalles.FilterBar = True
        Me.grdDetalles.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDetalles.Images.Add(CType(resources.GetObject("grdDetalles.Images"), System.Drawing.Image))
        Me.grdDetalles.Location = New System.Drawing.Point(4, 308)
        Me.grdDetalles.Name = "grdDetalles"
        Me.grdDetalles.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetalles.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetalles.PreviewInfo.ZoomFactor = 75
        Me.grdDetalles.PrintInfo.PageSettings = CType(resources.GetObject("grdDetalles.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetalles.Size = New System.Drawing.Size(684, 197)
        Me.grdDetalles.TabIndex = 14
        Me.grdDetalles.Text = "grdDetalles"
        Me.grdDetalles.PropBag = resources.GetString("grdDetalles.PropBag")
        '
        'grdRecibo
        '
        Me.grdRecibo.AllowFilter = False
        Me.grdRecibo.AllowUpdate = False
        Me.grdRecibo.Caption = "Listado de Recibos de Ingreso de Fondos"
        Me.grdRecibo.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdRecibo.FilterBar = True
        Me.grdRecibo.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdRecibo.Images.Add(CType(resources.GetObject("grdRecibo.Images"), System.Drawing.Image))
        Me.grdRecibo.Location = New System.Drawing.Point(4, 70)
        Me.grdRecibo.Name = "grdRecibo"
        Me.grdRecibo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdRecibo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdRecibo.PreviewInfo.ZoomFactor = 75
        Me.grdRecibo.PrintInfo.PageSettings = CType(resources.GetObject("grdRecibo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdRecibo.Size = New System.Drawing.Size(684, 207)
        Me.grdRecibo.TabIndex = 13
        Me.grdRecibo.Text = "grdRecibo"
        Me.grdRecibo.PropBag = resources.GetString("grdRecibo.PropBag")
        '
        'tbRecibo
        '
        Me.tbRecibo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolAnular, Me.ToolStripButton7, Me.toolRefrescar, Me.toolSeparator1, Me.toolImprimir, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbRecibo.Location = New System.Drawing.Point(4, 4)
        Me.tbRecibo.Name = "tbRecibo"
        Me.tbRecibo.Size = New System.Drawing.Size(684, 17)
        Me.tbRecibo.Stretch = True
        Me.tbRecibo.TabIndex = 12
        Me.tbRecibo.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 14)
        Me.toolAgregar.Text = "Agregar Recibo"
        Me.toolAgregar.ToolTipText = "Agregar Recibo"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 14)
        Me.toolModificar.Text = "Modificar Recibo"
        Me.toolModificar.ToolTipText = "Modificar Recibo"
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 14)
        Me.toolAnular.Text = "Anular Recibo"
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
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 14)
        Me.toolImprimir.Text = "Imprimir Recibo de Ingreso CN6"
        Me.toolImprimir.ToolTipText = "Imprimir Recibo de Ingreso CN6"
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
        'frmScnReciboIngresoFondos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 509)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Recibos de Ingreso de Fondos")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScnReciboIngresoFondos"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Recibos de Ingreso de Fondos"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCuenta.ResumeLayout(False)
        Me.tbCuenta.PerformLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbRecibo.ResumeLayout(False)
        Me.tbRecibo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbCuenta As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaC As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdDetalles As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdRecibo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbRecibo As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
