<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccReestructuracionDeuda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccReestructuracionDeuda))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.tbReestructuracion = New System.Windows.Forms.ToolStrip
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolAnular = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAplicar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolTablasAmortizacion = New System.Windows.Forms.ToolStripButton
        Me.toolAyudaR = New System.Windows.Forms.ToolStripButton
        Me.grdReestructuracion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdFichas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbFicha = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolListadoR = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbReestructuracion.SuspendLayout()
        CType(Me.grdReestructuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFichas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbFicha.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.tbReestructuracion)
        Me.C1Sizer1.Controls.Add(Me.grdReestructuracion)
        Me.C1Sizer1.Controls.Add(Me.grdFichas)
        Me.C1Sizer1.Controls.Add(Me.tbFicha)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(664, 435)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 27)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(656, 40)
        Me.grpGenerales.TabIndex = 18
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
        Me.cdeFechaH.Location = New System.Drawing.Point(505, 13)
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
        Me.lblFechaH.Location = New System.Drawing.Point(375, 16)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(127, 13)
        Me.lblFechaH.TabIndex = 37
        Me.lblFechaH.Text = "Fecha Resolución Hasta:"
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(270, 13)
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
        Me.lblFechaD.Location = New System.Drawing.Point(137, 16)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(130, 13)
        Me.lblFechaD.TabIndex = 36
        Me.lblFechaD.Text = "Fecha Resolución Desde:"
        '
        'tbReestructuracion
        '
        Me.tbReestructuracion.AutoSize = False
        Me.tbReestructuracion.Dock = System.Windows.Forms.DockStyle.None
        Me.tbReestructuracion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolSeparator2, Me.toolAgregar, Me.toolModificar, Me.toolAnular, Me.ToolStripSeparator1, Me.toolAplicar, Me.ToolStripSeparator2, Me.toolTablasAmortizacion, Me.toolAyudaR})
        Me.tbReestructuracion.Location = New System.Drawing.Point(4, 255)
        Me.tbReestructuracion.Name = "tbReestructuracion"
        Me.tbReestructuracion.Size = New System.Drawing.Size(168, 23)
        Me.tbReestructuracion.Stretch = True
        Me.tbReestructuracion.TabIndex = 15
        Me.tbReestructuracion.Text = "ToolStrip1"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregar.Text = "Agregar Reestructuración"
        Me.toolAgregar.ToolTipText = "Agregar Reestructuración"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 20)
        Me.toolModificar.Text = "Modificar Reestructuración"
        Me.toolModificar.ToolTipText = "Modificar Reestructuración"
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 20)
        Me.toolAnular.Text = "Anular Reestructuración"
        Me.toolAnular.ToolTipText = "Anular Reestructuración"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'toolAplicar
        '
        Me.toolAplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAplicar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAplicar.Name = "toolAplicar"
        Me.toolAplicar.Size = New System.Drawing.Size(23, 20)
        Me.toolAplicar.Text = "Aplicar Reestructuración"
        Me.toolAplicar.ToolTipText = "Aplicar Reestructuración"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolTablasAmortizacion
        '
        Me.toolTablasAmortizacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolTablasAmortizacion.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolTablasAmortizacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolTablasAmortizacion.Name = "toolTablasAmortizacion"
        Me.toolTablasAmortizacion.Size = New System.Drawing.Size(23, 20)
        Me.toolTablasAmortizacion.Text = "Imprimir Tablas de Amortización"
        Me.toolTablasAmortizacion.ToolTipText = "Imprimir Tablas de Amortización"
        '
        'toolAyudaR
        '
        Me.toolAyudaR.AutoSize = False
        Me.toolAyudaR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaR.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaR.Name = "toolAyudaR"
        Me.toolAyudaR.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaR.Text = "Ayuda"
        Me.toolAyudaR.ToolTipText = "Ayuda"
        '
        'grdReestructuracion
        '
        Me.grdReestructuracion.AllowFilter = False
        Me.grdReestructuracion.AllowUpdate = False
        Me.grdReestructuracion.Caption = "Listado de Reestructuraciones de Deuda"
        Me.grdReestructuracion.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdReestructuracion.FilterBar = True
        Me.grdReestructuracion.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdReestructuracion.Images.Add(CType(resources.GetObject("grdReestructuracion.Images"), System.Drawing.Image))
        Me.grdReestructuracion.Location = New System.Drawing.Point(4, 282)
        Me.grdReestructuracion.Name = "grdReestructuracion"
        Me.grdReestructuracion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdReestructuracion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdReestructuracion.PreviewInfo.ZoomFactor = 75
        Me.grdReestructuracion.PrintInfo.PageSettings = CType(resources.GetObject("grdReestructuracion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdReestructuracion.Size = New System.Drawing.Size(656, 149)
        Me.grdReestructuracion.TabIndex = 14
        Me.grdReestructuracion.Text = "grdReestructuracion"
        Me.grdReestructuracion.PropBag = resources.GetString("grdReestructuracion.PropBag")
        '
        'grdFichas
        '
        Me.grdFichas.AllowFilter = False
        Me.grdFichas.AllowUpdate = False
        Me.grdFichas.Caption = "Listado de Fichas de Notificación Aprobadas"
        Me.grdFichas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdFichas.FilterBar = True
        Me.grdFichas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdFichas.Images.Add(CType(resources.GetObject("grdFichas.Images"), System.Drawing.Image))
        Me.grdFichas.Location = New System.Drawing.Point(4, 71)
        Me.grdFichas.Name = "grdFichas"
        Me.grdFichas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdFichas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdFichas.PreviewInfo.ZoomFactor = 75
        Me.grdFichas.PrintInfo.PageSettings = CType(resources.GetObject("grdFichas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdFichas.Size = New System.Drawing.Size(656, 180)
        Me.grdFichas.TabIndex = 13
        Me.grdFichas.Text = "grdFichas"
        Me.grdFichas.PropBag = resources.GetString("grdFichas.PropBag")
        '
        'tbFicha
        '
        Me.tbFicha.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.toolRefrescar, Me.toolSeparator1, Me.toolListadoR, Me.toolAyuda, Me.ToolStripSeparator4, Me.toolSalir, Me.ToolStripSeparator3})
        Me.tbFicha.Location = New System.Drawing.Point(0, 0)
        Me.tbFicha.Name = "tbFicha"
        Me.tbFicha.Size = New System.Drawing.Size(664, 25)
        Me.tbFicha.Stretch = True
        Me.tbFicha.TabIndex = 12
        Me.tbFicha.Text = "ToolStrip1"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
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
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolListadoR
        '
        Me.toolListadoR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolListadoR.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolListadoR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolListadoR.Name = "toolListadoR"
        Me.toolListadoR.Size = New System.Drawing.Size(23, 22)
        Me.toolListadoR.Text = "Listado de Reestructuraciones"
        Me.toolListadoR.ToolTipText = "Listado de Reestructuraciones"
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'frmSccReestructuracionDeuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 435)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Reestructuración de Deuda")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSccReestructuracionDeuda"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = " Reestructuración de Deuda a Socias"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbReestructuracion.ResumeLayout(False)
        Me.tbReestructuracion.PerformLayout()
        CType(Me.grdReestructuracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFichas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbFicha.ResumeLayout(False)
        Me.tbFicha.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbReestructuracion As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaR As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdReestructuracion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdFichas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbFicha As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents toolTablasAmortizacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolListadoR As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
