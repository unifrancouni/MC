<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteConciliacionBancaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteConciliacionBancaria))
        Me.tbConciliacion = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAnular = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolImpresiones = New System.Windows.Forms.ToolStripSplitButton
        Me.toolImprimirC = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirA1 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirA2 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirA3 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirA4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.grdConciliacion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.tbConciliacion.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdConciliacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbConciliacion
        '
        Me.tbConciliacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolCerrar, Me.ToolStripSeparator4, Me.toolAnular, Me.ToolStripSeparator2, Me.toolRefrescar, Me.toolImpresiones, Me.ToolStripSeparator5, Me.toolAyuda, Me.toolSalir})
        Me.tbConciliacion.Location = New System.Drawing.Point(0, 0)
        Me.tbConciliacion.Name = "tbConciliacion"
        Me.tbConciliacion.Size = New System.Drawing.Size(699, 25)
        Me.tbConciliacion.Stretch = True
        Me.tbConciliacion.TabIndex = 1
        Me.tbConciliacion.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar Conciliación"
        Me.toolAgregar.ToolTipText = "Agregar Conciliación"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar Conciliación"
        Me.toolModificar.ToolTipText = "Modificar Conciliación"
        '
        'toolCerrar
        '
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Cerrar16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrar.Text = "Cerrar Conciliación"
        Me.toolCerrar.ToolTipText = "Cerrar Conciliación"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 22)
        Me.toolAnular.Text = "Anular Conciliación"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'toolImpresiones
        '
        Me.toolImpresiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImpresiones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimirC, Me.toolImprimirA1, Me.toolImprimirA2, Me.toolImprimirA3, Me.toolImprimirA4})
        Me.toolImpresiones.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImpresiones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImpresiones.Name = "toolImpresiones"
        Me.toolImpresiones.Size = New System.Drawing.Size(32, 22)
        Me.toolImpresiones.Text = "Impresión de Documentos"
        '
        'toolImprimirC
        '
        Me.toolImprimirC.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.toolImprimirC.Name = "toolImprimirC"
        Me.toolImprimirC.Size = New System.Drawing.Size(257, 22)
        Me.toolImprimirC.Text = "Conciliación Bancaria TE7"
        '
        'toolImprimirA1
        '
        Me.toolImprimirA1.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.toolImprimirA1.Name = "toolImprimirA1"
        Me.toolImprimirA1.Size = New System.Drawing.Size(257, 22)
        Me.toolImprimirA1.Text = "Anexo 1: Depósitos en Tránsito TE8"
        '
        'toolImprimirA2
        '
        Me.toolImprimirA2.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolImprimirA2.Name = "toolImprimirA2"
        Me.toolImprimirA2.Size = New System.Drawing.Size(257, 22)
        Me.toolImprimirA2.Text = "Anexo 2: Cheques Flotantes TE9"
        '
        'toolImprimirA3
        '
        Me.toolImprimirA3.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolImprimirA3.Name = "toolImprimirA3"
        Me.toolImprimirA3.Size = New System.Drawing.Size(257, 22)
        Me.toolImprimirA3.Text = "Anexo 3: Notas de Crédito TE10"
        '
        'toolImprimirA4
        '
        Me.toolImprimirA4.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
        Me.toolImprimirA4.Name = "toolImprimirA4"
        Me.toolImprimirA4.Size = New System.Drawing.Size(257, 22)
        Me.toolImprimirA4.Text = "Anexo 4: Notas de Débito TE11"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdConciliacion)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(699, 451)
        Me.C1Sizer1.TabIndex = 4
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 28)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(691, 45)
        Me.grpGenerales.TabIndex = 5
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
        Me.cdeFechaH.Location = New System.Drawing.Point(512, 16)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 30
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(378, 19)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(126, 13)
        Me.lblFechaH.TabIndex = 29
        Me.lblFechaH.Text = "Inicio Conciliación Hasta:"
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(269, 16)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 1
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(137, 19)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(129, 13)
        Me.lblFechaD.TabIndex = 28
        Me.lblFechaD.Text = "Inicio Conciliación Desde:"
        '
        'grdConciliacion
        '
        Me.grdConciliacion.AllowFilter = False
        Me.grdConciliacion.AllowUpdate = False
        Me.grdConciliacion.Caption = "Listado de Conciliaciones Bancarias"
        Me.grdConciliacion.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdConciliacion.FilterBar = True
        Me.grdConciliacion.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdConciliacion.Images.Add(CType(resources.GetObject("grdConciliacion.Images"), System.Drawing.Image))
        Me.grdConciliacion.Location = New System.Drawing.Point(4, 77)
        Me.grdConciliacion.Name = "grdConciliacion"
        Me.grdConciliacion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdConciliacion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdConciliacion.PreviewInfo.ZoomFactor = 75
        Me.grdConciliacion.PrintInfo.PageSettings = CType(resources.GetObject("grdConciliacion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdConciliacion.Size = New System.Drawing.Size(691, 370)
        Me.grdConciliacion.TabIndex = 2
        Me.grdConciliacion.Text = "grdArqueo"
        Me.grdConciliacion.PropBag = resources.GetString("grdConciliacion.PropBag")
        '
        'frmSteConciliacionBancaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 451)
        Me.Controls.Add(Me.tbConciliacion)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Conciliación Bancaria")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSteConciliacionBancaria"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "    Conciliaciones de Cuentas Bancarias"
        Me.tbConciliacion.ResumeLayout(False)
        Me.tbConciliacion.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdConciliacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbConciliacion As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdConciliacion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImpresiones As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolImprimirA1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirA2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents toolImprimirA3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirA4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
