<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccCierreCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccCierreCaja))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cdeFechaFin = New C1.Win.C1Input.C1DateEdit
        Me.lblFin = New System.Windows.Forms.Label
        Me.cdeFechaInicio = New C1.Win.C1Input.C1DateEdit
        Me.lblFecha = New System.Windows.Forms.Label
        Me.tbDetalleCierre = New System.Windows.Forms.ToolStrip
        Me.toolAgregarM = New System.Windows.Forms.ToolStripButton
        Me.toolModificarM = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarM = New System.Windows.Forms.ToolStripButton
        Me.toolSeparadorM = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarM = New System.Windows.Forms.ToolStripButton
        Me.toolImprimirM = New System.Windows.Forms.ToolStripButton
        Me.grdDetalleCierre = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdCierre = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbCierreMaestro = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAplicar = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolImprimir = New System.Windows.Forms.ToolStripDropDownButton
        Me.toolImprimirCN8 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirCN23 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirCN8f = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirCN5f = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.toolImprimirCN5m = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cdeFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDetalleCierre.SuspendLayout()
        CType(Me.grdDetalleCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCierreMaestro.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.GroupBox1)
        Me.C1Sizer1.Controls.Add(Me.tbDetalleCierre)
        Me.C1Sizer1.Controls.Add(Me.grdDetalleCierre)
        Me.C1Sizer1.Controls.Add(Me.grdCierre)
        Me.C1Sizer1.Controls.Add(Me.tbCierreMaestro)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(674, 403)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cdeFechaFin)
        Me.GroupBox1.Controls.Add(Me.lblFin)
        Me.GroupBox1.Controls.Add(Me.cdeFechaInicio)
        Me.GroupBox1.Controls.Add(Me.lblFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(666, 46)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Filtro por Fecha de Cierre"
        '
        'cdeFechaFin
        '
        Me.cdeFechaFin.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaFin.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaFin.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaFin.Location = New System.Drawing.Point(363, 16)
        Me.cdeFechaFin.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaFin.MaskInfo.EmptyAsNull = True
        Me.cdeFechaFin.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaFin.Name = "cdeFechaFin"
        Me.cdeFechaFin.Size = New System.Drawing.Size(105, 20)
        Me.cdeFechaFin.TabIndex = 42
        Me.cdeFechaFin.Tag = Nothing
        Me.cdeFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFin
        '
        Me.lblFin.AutoSize = True
        Me.lblFin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFin.Location = New System.Drawing.Point(325, 23)
        Me.lblFin.Name = "lblFin"
        Me.lblFin.Size = New System.Drawing.Size(24, 13)
        Me.lblFin.TabIndex = 43
        Me.lblFin.Text = "Fin:"
        '
        'cdeFechaInicio
        '
        Me.cdeFechaInicio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicio.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicio.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicio.Location = New System.Drawing.Point(144, 16)
        Me.cdeFechaInicio.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicio.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicio.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicio.Name = "cdeFechaInicio"
        Me.cdeFechaInicio.Size = New System.Drawing.Size(105, 20)
        Me.cdeFechaInicio.TabIndex = 40
        Me.cdeFechaInicio.Tag = Nothing
        Me.cdeFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(106, 23)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(35, 13)
        Me.lblFecha.TabIndex = 41
        Me.lblFecha.Text = "Inicio:"
        '
        'tbDetalleCierre
        '
        Me.tbDetalleCierre.AutoSize = False
        Me.tbDetalleCierre.Dock = System.Windows.Forms.DockStyle.None
        Me.tbDetalleCierre.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarM, Me.toolModificarM, Me.toolEliminarM, Me.toolSeparadorM, Me.toolRefrescarM, Me.toolImprimirM})
        Me.tbDetalleCierre.Location = New System.Drawing.Point(4, 226)
        Me.tbDetalleCierre.Name = "tbDetalleCierre"
        Me.tbDetalleCierre.Size = New System.Drawing.Size(164, 26)
        Me.tbDetalleCierre.Stretch = True
        Me.tbDetalleCierre.TabIndex = 15
        Me.tbDetalleCierre.Text = "ToolStrip1"
        '
        'toolAgregarM
        '
        Me.toolAgregarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarM.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarM.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarM.Name = "toolAgregarM"
        Me.toolAgregarM.Size = New System.Drawing.Size(23, 23)
        Me.toolAgregarM.Text = "Agregar"
        Me.toolAgregarM.ToolTipText = "Agregar"
        '
        'toolModificarM
        '
        Me.toolModificarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarM.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarM.Name = "toolModificarM"
        Me.toolModificarM.Size = New System.Drawing.Size(23, 23)
        Me.toolModificarM.Text = "Modificar"
        Me.toolModificarM.ToolTipText = "Modificar"
        '
        'toolEliminarM
        '
        Me.toolEliminarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarM.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarM.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarM.Name = "toolEliminarM"
        Me.toolEliminarM.Size = New System.Drawing.Size(23, 23)
        Me.toolEliminarM.Text = "Anular"
        Me.toolEliminarM.ToolTipText = "Anular"
        '
        'toolSeparadorM
        '
        Me.toolSeparadorM.Name = "toolSeparadorM"
        Me.toolSeparadorM.Size = New System.Drawing.Size(6, 26)
        '
        'toolRefrescarM
        '
        Me.toolRefrescarM.AutoSize = False
        Me.toolRefrescarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarM.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRefrescarM.Name = "toolRefrescarM"
        Me.toolRefrescarM.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarM.Text = "Ayuda"
        Me.toolRefrescarM.ToolTipText = "Ayuda"
        '
        'toolImprimirM
        '
        Me.toolImprimirM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirM.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirM.Name = "toolImprimirM"
        Me.toolImprimirM.Size = New System.Drawing.Size(23, 23)
        Me.toolImprimirM.Text = "ToolStripButton1"
        Me.toolImprimirM.ToolTipText = "Imprimir Minuta CN17"
        '
        'grdDetalleCierre
        '
        Me.grdDetalleCierre.AllowFilter = False
        Me.grdDetalleCierre.AllowUpdate = False
        Me.grdDetalleCierre.Caption = "Listado Detalle del Cierre"
        Me.grdDetalleCierre.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDetalleCierre.FilterBar = True
        Me.grdDetalleCierre.GroupByAreaVisible = False
        Me.grdDetalleCierre.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDetalleCierre.Images.Add(CType(resources.GetObject("grdDetalleCierre.Images"), System.Drawing.Image))
        Me.grdDetalleCierre.Location = New System.Drawing.Point(4, 256)
        Me.grdDetalleCierre.Name = "grdDetalleCierre"
        Me.grdDetalleCierre.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetalleCierre.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetalleCierre.PreviewInfo.ZoomFactor = 75
        Me.grdDetalleCierre.PrintInfo.PageSettings = CType(resources.GetObject("grdDetalleCierre.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetalleCierre.Size = New System.Drawing.Size(666, 143)
        Me.grdDetalleCierre.TabIndex = 14
        Me.grdDetalleCierre.Text = "grdModulo"
        Me.grdDetalleCierre.PropBag = resources.GetString("grdDetalleCierre.PropBag")
        '
        'grdCierre
        '
        Me.grdCierre.AllowFilter = False
        Me.grdCierre.AllowUpdate = False
        Me.grdCierre.Caption = "Listado de Cierres"
        Me.grdCierre.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdCierre.GroupByAreaVisible = False
        Me.grdCierre.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdCierre.Images.Add(CType(resources.GetObject("grdCierre.Images"), System.Drawing.Image))
        Me.grdCierre.Location = New System.Drawing.Point(4, 77)
        Me.grdCierre.Name = "grdCierre"
        Me.grdCierre.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCierre.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCierre.PreviewInfo.ZoomFactor = 75
        Me.grdCierre.PrintInfo.PageSettings = CType(resources.GetObject("grdCierre.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCierre.Size = New System.Drawing.Size(666, 145)
        Me.grdCierre.TabIndex = 13
        Me.grdCierre.Text = "grdSocia"
        Me.grdCierre.PropBag = resources.GetString("grdCierre.PropBag")
        '
        'tbCierreMaestro
        '
        Me.tbCierreMaestro.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripSeparator4, Me.toolAplicar, Me.toolSeparador1, Me.toolRefrescar, Me.toolImprimir, Me.ToolStripSeparator3, Me.toolAyuda, Me.toolCerrar})
        Me.tbCierreMaestro.Location = New System.Drawing.Point(0, 0)
        Me.tbCierreMaestro.Name = "tbCierreMaestro"
        Me.tbCierreMaestro.Size = New System.Drawing.Size(674, 25)
        Me.tbCierreMaestro.Stretch = True
        Me.tbCierreMaestro.TabIndex = 12
        Me.tbCierreMaestro.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'toolEliminar
        '
        Me.toolEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminar.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminar.Name = "toolEliminar"
        Me.toolEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminar.Text = "Anular"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolAplicar
        '
        Me.toolAplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAplicar.Image = Global.SMUSURA0.My.Resources.Resources.AprobarPartida16
        Me.toolAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAplicar.Name = "toolAplicar"
        Me.toolAplicar.Size = New System.Drawing.Size(23, 22)
        Me.toolAplicar.Text = "ToolStripButton1"
        Me.toolAplicar.ToolTipText = "Generar Comprobante de Diario"
        '
        'toolSeparador1
        '
        Me.toolSeparador1.Name = "toolSeparador1"
        Me.toolSeparador1.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimirCN8, Me.toolImprimirCN23, Me.toolImprimirCN8f, Me.toolImprimirCN5f, Me.toolImprimirCN5m})
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(29, 22)
        Me.toolImprimir.Text = "ToolStripButton1"
        Me.toolImprimir.ToolTipText = "Imprimir"
        '
        'toolImprimirCN8
        '
        Me.toolImprimirCN8.Name = "toolImprimirCN8"
        Me.toolImprimirCN8.Size = New System.Drawing.Size(279, 22)
        Me.toolImprimirCN8.Text = "Cierre Diario por Fuente CN8"
        '
        'toolImprimirCN23
        '
        Me.toolImprimirCN23.Name = "toolImprimirCN23"
        Me.toolImprimirCN23.Size = New System.Drawing.Size(279, 22)
        Me.toolImprimirCN23.Text = "Cierre Diario por Minuta CN23"
        '
        'toolImprimirCN8f
        '
        Me.toolImprimirCN8f.Name = "toolImprimirCN8f"
        Me.toolImprimirCN8f.Size = New System.Drawing.Size(279, 22)
        Me.toolImprimirCN8f.Text = "Cierre Diario Todas las Fuentes CN8"
        Me.toolImprimirCN8f.ToolTipText = "Cierre Diario todas las Fuentes CN8"
        '
        'toolImprimirCN5f
        '
        Me.toolImprimirCN5f.Name = "toolImprimirCN5f"
        Me.toolImprimirCN5f.Size = New System.Drawing.Size(279, 22)
        Me.toolImprimirCN5f.Text = "Comprobantes de Recuperación CN5"
        Me.toolImprimirCN5f.ToolTipText = "Comprobantes del Cierre Diario CN5"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'toolCerrar
        '
        Me.toolCerrar.BackColor = System.Drawing.Color.Transparent
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrar.Text = "Cerrar"
        Me.toolCerrar.ToolTipText = "Salir"
        '
        'toolImprimirCN5m
        '
        Me.toolImprimirCN5m.Name = "toolImprimirCN5m"
        Me.toolImprimirCN5m.Size = New System.Drawing.Size(279, 22)
        Me.toolImprimirCN5m.Text = "Comprobantes de Diario (manuales) CN5"
        Me.toolImprimirCN5m.ToolTipText = "Comprobantes de Diario CN5"
        '
        'frmSccCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 403)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Cierre Diario de Cartera")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSccCierreCaja"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento Cierre Diario de Caja"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cdeFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDetalleCierre.ResumeLayout(False)
        Me.tbDetalleCierre.PerformLayout()
        CType(Me.grdDetalleCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCierreMaestro.ResumeLayout(False)
        Me.tbCierreMaestro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbDetalleCierre As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparadorM As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdDetalleCierre As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdCierre As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbCierreMaestro As System.Windows.Forms.ToolStrip
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirM As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaInicio As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cdeFechaFin As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFin As System.Windows.Forms.Label
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolImprimirCN8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirCN23 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolImprimirCN8f As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirCN5f As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirCN5m As System.Windows.Forms.ToolStripMenuItem
End Class
