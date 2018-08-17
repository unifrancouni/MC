<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteMinutaBancoEnLinea
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteMinutaBancoEnLinea))
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tbMinuta = New System.Windows.Forms.ToolStrip
        Me.toolImportar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolLimpiar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolImpresiones = New System.Windows.Forms.ToolStripSplitButton
        Me.toolImprimirBancoLinea = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirArqueosU0 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirConciliacionDiferencias = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cboCuenta = New C1.Win.C1List.C1Combo
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.grdMinutas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimirListadoCheques = New System.Windows.Forms.ToolStripMenuItem
        Me.toolConciliacionCheques = New System.Windows.Forms.ToolStripMenuItem
        Me.tbMinuta.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMinutas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbMinuta
        '
        Me.tbMinuta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImportar, Me.ToolStripSeparator1, Me.toolEliminar, Me.toolLimpiar, Me.ToolStripSeparator2, Me.toolRefrescar, Me.toolImpresiones, Me.ToolStripSeparator5, Me.toolCerrar})
        Me.tbMinuta.Location = New System.Drawing.Point(0, 0)
        Me.tbMinuta.Name = "tbMinuta"
        Me.tbMinuta.Size = New System.Drawing.Size(726, 25)
        Me.tbMinuta.Stretch = True
        Me.tbMinuta.TabIndex = 1
        Me.tbMinuta.Text = "ToolStrip1"
        '
        'toolImportar
        '
        Me.toolImportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImportar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolImportar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolImportar.Name = "toolImportar"
        Me.toolImportar.Size = New System.Drawing.Size(23, 22)
        Me.toolImportar.Text = "Importar Archivo Excell"
        Me.toolImportar.ToolTipText = "Importar Archivo Excell"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolEliminar
        '
        Me.toolEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminar.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEliminar.Name = "toolEliminar"
        Me.toolEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminar.Text = "Eliminar Registro Actual"
        Me.toolEliminar.ToolTipText = "Eliminar Registro Actual"
        '
        'toolLimpiar
        '
        Me.toolLimpiar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolLimpiar.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolLimpiar.Name = "toolLimpiar"
        Me.toolLimpiar.Size = New System.Drawing.Size(23, 22)
        Me.toolLimpiar.Text = "Eliminar registros importados"
        Me.toolLimpiar.ToolTipText = "Eliminar registros importados"
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
        Me.toolImpresiones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimirBancoLinea, Me.ToolStripSeparator3, Me.toolImprimirArqueosU0, Me.toolImprimirConciliacionDiferencias, Me.ToolStripSeparator4, Me.toolImprimirListadoCheques, Me.toolConciliacionCheques})
        Me.toolImpresiones.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImpresiones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImpresiones.Name = "toolImpresiones"
        Me.toolImpresiones.Size = New System.Drawing.Size(32, 22)
        '
        'toolImprimirBancoLinea
        '
        Me.toolImprimirBancoLinea.Image = Global.SMUSURA0.My.Resources.Resources.bookmark_folder
        Me.toolImprimirBancoLinea.Name = "toolImprimirBancoLinea"
        Me.toolImprimirBancoLinea.Size = New System.Drawing.Size(402, 22)
        Me.toolImprimirBancoLinea.Text = "Detalle de Importación Banca en Línea TE45"
        '
        'toolImprimirArqueosU0
        '
        Me.toolImprimirArqueosU0.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
        Me.toolImprimirArqueosU0.Name = "toolImprimirArqueosU0"
        Me.toolImprimirArqueosU0.Size = New System.Drawing.Size(402, 22)
        Me.toolImprimirArqueosU0.Text = "Conciliación Efectivo vs. Arqueos Programa Usura Cero TE35x"
        '
        'toolImprimirConciliacionDiferencias
        '
        Me.toolImprimirConciliacionDiferencias.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.toolImprimirConciliacionDiferencias.Name = "toolImprimirConciliacionDiferencias"
        Me.toolImprimirConciliacionDiferencias.Size = New System.Drawing.Size(402, 22)
        Me.toolImprimirConciliacionDiferencias.Text = "Conciliación de Depósitos Banca en Línea vs. Arqueos TE46"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdMinutas)
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
        Me.grpGenerales.Controls.Add(Me.cboCuenta)
        Me.grpGenerales.Controls.Add(Me.lblCuenta)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 28)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(718, 56)
        Me.grpGenerales.TabIndex = 17
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione Criterios de Filtro:  "
        '
        'cboCuenta
        '
        Me.cboCuenta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCuenta.AutoCompletion = True
        Me.cboCuenta.Caption = ""
        Me.cboCuenta.CaptionHeight = 17
        Me.cboCuenta.CaptionStyle = Style17
        Me.cboCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCuenta.ColumnCaptionHeight = 17
        Me.cboCuenta.ColumnFooterHeight = 17
        Me.cboCuenta.ContentHeight = 15
        Me.cboCuenta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCuenta.DisplayMember = "sNumeroCuenta"
        Me.cboCuenta.DropDownWidth = 278
        Me.cboCuenta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCuenta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCuenta.EditorHeight = 15
        Me.cboCuenta.EvenRowStyle = Style18
        Me.cboCuenta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCuenta.FooterStyle = Style19
        Me.cboCuenta.GapHeight = 2
        Me.cboCuenta.HeadingStyle = Style20
        Me.cboCuenta.HighLightRowStyle = Style21
        Me.cboCuenta.Images.Add(CType(resources.GetObject("cboCuenta.Images"), System.Drawing.Image))
        Me.cboCuenta.ItemHeight = 15
        Me.cboCuenta.LimitToList = True
        Me.cboCuenta.Location = New System.Drawing.Point(128, 19)
        Me.cboCuenta.MatchEntryTimeout = CType(2000, Long)
        Me.cboCuenta.MaxDropDownItems = CType(5, Short)
        Me.cboCuenta.MaxLength = 32767
        Me.cboCuenta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.OddRowStyle = Style22
        Me.cboCuenta.PartialRightColumn = False
        Me.cboCuenta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCuenta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCuenta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCuenta.SelectedStyle = Style23
        Me.cboCuenta.Size = New System.Drawing.Size(277, 21)
        Me.cboCuenta.Style = Style24
        Me.cboCuenta.SuperBack = True
        Me.cboCuenta.TabIndex = 49
        Me.cboCuenta.ValueMember = "nSteCuentaBancariaID"
        Me.cboCuenta.PropBag = resources.GetString("cboCuenta.PropBag")
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCuenta.Location = New System.Drawing.Point(33, 23)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(89, 13)
        Me.lblCuenta.TabIndex = 39
        Me.lblCuenta.Text = "Cuenta Bancaria:"
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(560, 24)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaH.TabIndex = 37
        Me.lblFechaH.Text = "Hasta:"
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(411, 24)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(41, 13)
        Me.lblFechaD.TabIndex = 36
        Me.lblFechaD.Text = "Desde:"
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
        Me.cdeFechaD.Location = New System.Drawing.Point(455, 23)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 41
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'grdMinutas
        '
        Me.grdMinutas.AllowFilter = False
        Me.grdMinutas.AllowUpdate = False
        Me.grdMinutas.Caption = "Listado de Depósitos Banco En Línea"
        Me.grdMinutas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdMinutas.FilterBar = True
        Me.grdMinutas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdMinutas.Images.Add(CType(resources.GetObject("grdMinutas.Images"), System.Drawing.Image))
        Me.grdMinutas.Location = New System.Drawing.Point(4, 88)
        Me.grdMinutas.Name = "grdMinutas"
        Me.grdMinutas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdMinutas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdMinutas.PreviewInfo.ZoomFactor = 75
        Me.grdMinutas.PrintInfo.PageSettings = CType(resources.GetObject("grdMinutas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdMinutas.Size = New System.Drawing.Size(718, 380)
        Me.grdMinutas.TabIndex = 2
        Me.grdMinutas.Text = "grdFicha"
        Me.grdMinutas.PropBag = resources.GetString("grdMinutas.PropBag")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(399, 6)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(399, 6)
        '
        'toolImprimirListadoCheques
        '
        Me.toolImprimirListadoCheques.Image = Global.SMUSURA0.My.Resources.Resources.kate
        Me.toolImprimirListadoCheques.Name = "toolImprimirListadoCheques"
        Me.toolImprimirListadoCheques.Size = New System.Drawing.Size(402, 22)
        Me.toolImprimirListadoCheques.Text = "Listado de Cheques Emitidos CN39"
        '
        'toolConciliacionCheques
        '
        Me.toolConciliacionCheques.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.toolConciliacionCheques.Name = "toolConciliacionCheques"
        Me.toolConciliacionCheques.Size = New System.Drawing.Size(402, 22)
        Me.toolConciliacionCheques.Text = "Conciliación de Cheques Banca en Línea vs. Listado Cheques TE47"
        '
        'frmSteMinutaBancoEnLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 472)
        Me.Controls.Add(Me.tbMinuta)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Formato de Promoción y Capacitación")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSteMinutaBancoEnLinea"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "    Conciliaciones Banca En Línea"
        Me.tbMinuta.ResumeLayout(False)
        Me.tbMinuta.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMinutas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbMinuta As System.Windows.Forms.ToolStrip
    Friend WithEvents toolImportar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdMinutas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolLimpiar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents cboCuenta As C1.Win.C1List.C1Combo
    Friend WithEvents toolImpresiones As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolImprimirBancoLinea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirArqueosU0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirConciliacionDiferencias As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirListadoCheques As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolConciliacionCheques As System.Windows.Forms.ToolStripMenuItem
End Class
