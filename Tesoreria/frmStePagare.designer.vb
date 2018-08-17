<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStePagare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStePagare))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.tbReciboPagare = New System.Windows.Forms.ToolStrip
        Me.toolAgregarRecibo = New System.Windows.Forms.ToolStripButton
        Me.toolAnularRecibo = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimirRecibo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaC = New System.Windows.Forms.ToolStripButton
        Me.grdReciboPagare = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdPagare = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbPagare = New System.Windows.Forms.ToolStrip
        Me.toolAnularPagare = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarPagare = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimirPagare = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbReciboPagare.SuspendLayout()
        CType(Me.grdReciboPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPagare.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.tbReciboPagare)
        Me.C1Sizer1.Controls.Add(Me.grdReciboPagare)
        Me.C1Sizer1.Controls.Add(Me.grdPagare)
        Me.C1Sizer1.Controls.Add(Me.tbPagare)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(687, 459)
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
        Me.grpGenerales.Size = New System.Drawing.Size(679, 44)
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
        Me.cdeFechaH.Location = New System.Drawing.Point(476, 13)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 38
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(365, 16)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(108, 13)
        Me.lblFechaH.TabIndex = 37
        Me.lblFechaH.Text = "Fecha Pagare Hasta:"
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(231, 13)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 35
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(117, 16)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(111, 13)
        Me.lblFechaD.TabIndex = 36
        Me.lblFechaD.Text = "Fecha Pagare Desde:"
        '
        'tbReciboPagare
        '
        Me.tbReciboPagare.AutoSize = False
        Me.tbReciboPagare.Dock = System.Windows.Forms.DockStyle.None
        Me.tbReciboPagare.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarRecibo, Me.toolAnularRecibo, Me.toolSeparator2, Me.toolImprimirRecibo, Me.ToolStripSeparator1, Me.toolAyudaC})
        Me.tbReciboPagare.Location = New System.Drawing.Point(4, 247)
        Me.tbReciboPagare.Name = "tbReciboPagare"
        Me.tbReciboPagare.Size = New System.Drawing.Size(164, 23)
        Me.tbReciboPagare.Stretch = True
        Me.tbReciboPagare.TabIndex = 15
        Me.tbReciboPagare.Text = "ToolStrip1"
        '
        'toolAgregarRecibo
        '
        Me.toolAgregarRecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarRecibo.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarRecibo.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarRecibo.Name = "toolAgregarRecibo"
        Me.toolAgregarRecibo.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregarRecibo.Text = "Agregar Recibo Pagare"
        Me.toolAgregarRecibo.ToolTipText = "Agregar Recibo"
        '
        'toolAnularRecibo
        '
        Me.toolAnularRecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnularRecibo.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnularRecibo.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnularRecibo.Name = "toolAnularRecibo"
        Me.toolAnularRecibo.Size = New System.Drawing.Size(23, 20)
        Me.toolAnularRecibo.Text = "Anular Recibo"
        Me.toolAnularRecibo.ToolTipText = "Anular Recibo"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolImprimirRecibo
        '
        Me.toolImprimirRecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirRecibo.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirRecibo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirRecibo.Name = "toolImprimirRecibo"
        Me.toolImprimirRecibo.Size = New System.Drawing.Size(23, 20)
        Me.toolImprimirRecibo.Text = "Imprimir Recibo"
        Me.toolImprimirRecibo.ToolTipText = "Imprimir Recibo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
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
        'grdReciboPagare
        '
        Me.grdReciboPagare.AllowFilter = False
        Me.grdReciboPagare.AllowUpdate = False
        Me.grdReciboPagare.Caption = "Listado de Recibos de Pagare"
        Me.grdReciboPagare.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdReciboPagare.FilterBar = True
        Me.grdReciboPagare.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdReciboPagare.Images.Add(CType(resources.GetObject("grdReciboPagare.Images"), System.Drawing.Image))
        Me.grdReciboPagare.Location = New System.Drawing.Point(4, 274)
        Me.grdReciboPagare.Name = "grdReciboPagare"
        Me.grdReciboPagare.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdReciboPagare.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdReciboPagare.PreviewInfo.ZoomFactor = 75
        Me.grdReciboPagare.PrintInfo.PageSettings = CType(resources.GetObject("grdReciboPagare.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdReciboPagare.Size = New System.Drawing.Size(679, 181)
        Me.grdReciboPagare.TabIndex = 14
        Me.grdReciboPagare.Text = "grdModulo"
        Me.grdReciboPagare.PropBag = resources.GetString("grdReciboPagare.PropBag")
        '
        'grdPagare
        '
        Me.grdPagare.AllowFilter = False
        Me.grdPagare.AllowUpdate = False
        Me.grdPagare.Caption = "Listado de Pagares"
        Me.grdPagare.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdPagare.FilterBar = True
        Me.grdPagare.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdPagare.Images.Add(CType(resources.GetObject("grdPagare.Images"), System.Drawing.Image))
        Me.grdPagare.Location = New System.Drawing.Point(4, 73)
        Me.grdPagare.Name = "grdPagare"
        Me.grdPagare.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPagare.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPagare.PreviewInfo.ZoomFactor = 75
        Me.grdPagare.PrintInfo.PageSettings = CType(resources.GetObject("grdPagare.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdPagare.Size = New System.Drawing.Size(679, 170)
        Me.grdPagare.TabIndex = 13
        Me.grdPagare.Text = "grdDocSoporte"
        Me.grdPagare.PropBag = resources.GetString("grdPagare.PropBag")
        '
        'tbPagare
        '
        Me.tbPagare.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAnularPagare, Me.ToolStripButton7, Me.toolRefrescarPagare, Me.toolSeparator1, Me.toolImprimirPagare, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbPagare.Location = New System.Drawing.Point(0, 0)
        Me.tbPagare.Name = "tbPagare"
        Me.tbPagare.Size = New System.Drawing.Size(687, 25)
        Me.tbPagare.Stretch = True
        Me.tbPagare.TabIndex = 12
        Me.tbPagare.Text = "ToolStrip1"
        '
        'toolAnularPagare
        '
        Me.toolAnularPagare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnularPagare.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnularPagare.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnularPagare.Name = "toolAnularPagare"
        Me.toolAnularPagare.Size = New System.Drawing.Size(23, 22)
        Me.toolAnularPagare.Text = "Anular Pagare"
        Me.toolAnularPagare.ToolTipText = "Anular Pagare"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarPagare
        '
        Me.toolRefrescarPagare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarPagare.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarPagare.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarPagare.Name = "toolRefrescarPagare"
        Me.toolRefrescarPagare.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarPagare.Text = "Refrescar"
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.toolSeparator1.Visible = False
        '
        'toolImprimirPagare
        '
        Me.toolImprimirPagare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirPagare.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirPagare.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirPagare.Name = "toolImprimirPagare"
        Me.toolImprimirPagare.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirPagare.Text = "Imprimir Pagare"
        Me.toolImprimirPagare.ToolTipText = "Imprimir Pagare"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 22)
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
        Me.toolSalir.Size = New System.Drawing.Size(23, 22)
        Me.toolSalir.Text = "Cerrar"
        Me.toolSalir.ToolTipText = "Salir"
        '
        'frmStePagare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(687, 459)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Pagaré Cajeros")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStePagare"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento de Pagare"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbReciboPagare.ResumeLayout(False)
        Me.tbReciboPagare.PerformLayout()
        CType(Me.grdReciboPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPagare, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPagare.ResumeLayout(False)
        Me.tbPagare.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbReciboPagare As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarRecibo As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaC As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdReciboPagare As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdPagare As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbPagare As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAnularPagare As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarPagare As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirPagare As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents toolAnularRecibo As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirRecibo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
