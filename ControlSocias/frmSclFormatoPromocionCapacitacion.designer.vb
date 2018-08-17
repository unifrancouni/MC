<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclFormatoPromocionCapacitacion
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclFormatoPromocionCapacitacion))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tbFormato = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolInactivar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.lblTecnico = New System.Windows.Forms.Label
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.cboTecnico = New C1.Win.C1List.C1Combo
        Me.grdFormato = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.tbFormato.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbFormato
        '
        Me.tbFormato.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolInactivar, Me.ToolStripSeparator2, Me.toolRefrescar, Me.toolImprimir, Me.ToolStripSeparator5, Me.toolAyuda, Me.toolCerrar})
        Me.tbFormato.Location = New System.Drawing.Point(0, 0)
        Me.tbFormato.Name = "tbFormato"
        Me.tbFormato.Size = New System.Drawing.Size(726, 25)
        Me.tbFormato.Stretch = True
        Me.tbFormato.TabIndex = 1
        Me.tbFormato.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar "
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
        'toolInactivar
        '
        Me.toolInactivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolInactivar.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolInactivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolInactivar.Name = "toolInactivar"
        Me.toolInactivar.Size = New System.Drawing.Size(23, 22)
        Me.toolInactivar.Text = "Inactivar"
        Me.toolInactivar.ToolTipText = "Inactivar"
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
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimir.Text = "Imprimir Formato"
        Me.toolImprimir.ToolTipText = "Imprimir Formato"
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
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdFormato)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(726, 472)
        Me.C1Sizer1.TabIndex = 4
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.lblTecnico)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.cboTecnico)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 28)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(718, 56)
        Me.grpGenerales.TabIndex = 17
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione Criterios de Filtro:  "
        '
        'lblTecnico
        '
        Me.lblTecnico.AutoSize = True
        Me.lblTecnico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTecnico.Location = New System.Drawing.Point(8, 23)
        Me.lblTecnico.Name = "lblTecnico"
        Me.lblTecnico.Size = New System.Drawing.Size(114, 13)
        Me.lblTecnico.TabIndex = 39
        Me.lblTecnico.Text = "Técnico del Programa:"
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(527, 23)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(71, 13)
        Me.lblFechaH.TabIndex = 37
        Me.lblFechaH.Text = "Fecha Hasta:"
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(345, 23)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaD.TabIndex = 36
        Me.lblFechaD.Text = "Fecha Desde:"
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(601, 20)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 42
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(422, 21)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 41
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
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
        Me.cboTecnico.DropDownWidth = 212
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
        Me.cboTecnico.Location = New System.Drawing.Point(128, 20)
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
        Me.cboTecnico.Size = New System.Drawing.Size(211, 21)
        Me.cboTecnico.Style = Style8
        Me.cboTecnico.SuperBack = True
        Me.cboTecnico.TabIndex = 40
        Me.cboTecnico.ValueMember = "nSrhEmpleadoID"
        Me.cboTecnico.PropBag = resources.GetString("cboTecnico.PropBag")
        '
        'grdFormato
        '
        Me.grdFormato.AllowFilter = False
        Me.grdFormato.AllowUpdate = False
        Me.grdFormato.Caption = "Listado de Formatos de Promoción y Capacitación"
        Me.grdFormato.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdFormato.FilterBar = True
        Me.grdFormato.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdFormato.Images.Add(CType(resources.GetObject("grdFormato.Images"), System.Drawing.Image))
        Me.grdFormato.Location = New System.Drawing.Point(4, 88)
        Me.grdFormato.Name = "grdFormato"
        Me.grdFormato.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdFormato.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdFormato.PreviewInfo.ZoomFactor = 75
        Me.grdFormato.PrintInfo.PageSettings = CType(resources.GetObject("grdFormato.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdFormato.Size = New System.Drawing.Size(718, 380)
        Me.grdFormato.TabIndex = 2
        Me.grdFormato.Text = "grdFicha"
        Me.grdFormato.PropBag = resources.GetString("grdFormato.PropBag")
        '
        'frmSclFormatoPromocionCapacitacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 472)
        Me.Controls.Add(Me.tbFormato)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Formato de Promoción y Capacitación")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclFormatoPromocionCapacitacion"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "    Formato de Promoción y Capacitación"
        Me.tbFormato.ResumeLayout(False)
        Me.tbFormato.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFormato, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbFormato As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdFormato As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolInactivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents cboTecnico As C1.Win.C1List.C1Combo
    Friend WithEvents lblTecnico As System.Windows.Forms.Label
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
