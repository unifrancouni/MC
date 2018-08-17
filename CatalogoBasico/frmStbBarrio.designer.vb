<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbBarrio
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbBarrio))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tbBarrio = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolMoverBarrio = New System.Windows.Forms.ToolStripButton
        Me.toolDeshacerMoverBarrio = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripSplitButton
        Me.toolImprimirBarrios = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirBarriosM = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirBarriosUniones = New System.Windows.Forms.ToolStripMenuItem
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboDepartamento = New C1.Win.C1List.C1Combo
        Me.lblDepartamento = New System.Windows.Forms.Label
        Me.grdBarrio = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.tbBarrio.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbBarrio
        '
        Me.tbBarrio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripSeparator2, Me.toolRefrescar, Me.toolMoverBarrio, Me.toolDeshacerMoverBarrio, Me.ToolStripSeparator1, Me.toolImprimir, Me.toolAyuda, Me.toolCerrar})
        Me.tbBarrio.Location = New System.Drawing.Point(0, 0)
        Me.tbBarrio.Name = "tbBarrio"
        Me.tbBarrio.Size = New System.Drawing.Size(658, 25)
        Me.tbBarrio.Stretch = True
        Me.tbBarrio.TabIndex = 1
        Me.tbBarrio.Text = "ToolStrip1"
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
        Me.toolEliminar.Text = "Eliminar"
        Me.toolEliminar.ToolTipText = "Eliminar"
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
        'toolMoverBarrio
        '
        Me.toolMoverBarrio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMoverBarrio.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolMoverBarrio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMoverBarrio.Name = "toolMoverBarrio"
        Me.toolMoverBarrio.Size = New System.Drawing.Size(23, 22)
        Me.toolMoverBarrio.Text = "Trasladar Barrios con sus fichas y creditos"
        '
        'toolDeshacerMoverBarrio
        '
        Me.toolDeshacerMoverBarrio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolDeshacerMoverBarrio.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.toolDeshacerMoverBarrio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDeshacerMoverBarrio.Name = "toolDeshacerMoverBarrio"
        Me.toolDeshacerMoverBarrio.Size = New System.Drawing.Size(23, 22)
        Me.toolDeshacerMoverBarrio.Text = "Revertir el Traslado de Barrios con sus fichas y creditos"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimirBarrios, Me.toolImprimirBarriosM, Me.toolImprimirBarriosUniones})
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(32, 22)
        Me.toolImprimir.Text = "ar"
        '
        'toolImprimirBarrios
        '
        Me.toolImprimirBarrios.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.toolImprimirBarrios.Name = "toolImprimirBarrios"
        Me.toolImprimirBarrios.Size = New System.Drawing.Size(252, 22)
        Me.toolImprimirBarrios.Text = "Listado de Barrios"
        '
        'toolImprimirBarriosM
        '
        Me.toolImprimirBarriosM.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.toolImprimirBarriosM.Name = "toolImprimirBarriosM"
        Me.toolImprimirBarriosM.Size = New System.Drawing.Size(252, 22)
        Me.toolImprimirBarriosM.Text = "Listado de Barrios con Movimientos"
        '
        'toolImprimirBarriosUniones
        '
        Me.toolImprimirBarriosUniones.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolImprimirBarriosUniones.Name = "toolImprimirBarriosUniones"
        Me.toolImprimirBarriosUniones.Size = New System.Drawing.Size(252, 22)
        Me.toolImprimirBarriosUniones.Text = "Listado de Barrios con Uniones"
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
        Me.C1Sizer1.Controls.Add(Me.GroupBox1)
        Me.C1Sizer1.Controls.Add(Me.grdBarrio)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(658, 328)
        Me.C1Sizer1.TabIndex = 4
        Me.C1Sizer1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblDepartamento)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 28)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(650, 32)
        Me.GroupBox1.TabIndex = 21
        Me.GroupBox1.TabStop = False
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style9
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "Descripcion"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 153
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.EvenRowStyle = Style10
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style11
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style12
        Me.cboDepartamento.HighLightRowStyle = Style13
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(305, 6)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style14
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style15
        Me.cboDepartamento.Size = New System.Drawing.Size(153, 21)
        Me.cboDepartamento.Style = Style16
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 10
        Me.cboDepartamento.ValueMember = "StbValorCatalogoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(219, 10)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 9
        Me.lblDepartamento.Text = "Departamento:"
        '
        'grdBarrio
        '
        Me.grdBarrio.AllowFilter = False
        Me.grdBarrio.AllowUpdate = False
        Me.grdBarrio.Caption = "Listado de Barrios"
        Me.grdBarrio.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdBarrio.FilterBar = True
        Me.grdBarrio.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdBarrio.Images.Add(CType(resources.GetObject("grdBarrio.Images"), System.Drawing.Image))
        Me.grdBarrio.Location = New System.Drawing.Point(4, 60)
        Me.grdBarrio.Name = "grdBarrio"
        Me.grdBarrio.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdBarrio.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdBarrio.PreviewInfo.ZoomFactor = 75
        Me.grdBarrio.PrintInfo.PageSettings = CType(resources.GetObject("grdBarrio.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdBarrio.Size = New System.Drawing.Size(650, 264)
        Me.grdBarrio.TabIndex = 2
        Me.grdBarrio.Text = "grdFicha"
        Me.grdBarrio.PropBag = resources.GetString("grdBarrio.PropBag")
        '
        'frmStbBarrio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 328)
        Me.Controls.Add(Me.tbBarrio)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Barrios")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStbBarrio"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "                                                                                 " & _
            "                                                                                " & _
            "                     "
        Me.tbBarrio.ResumeLayout(False)
        Me.tbBarrio.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbBarrio As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdBarrio As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolImprimirBarrios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirBarriosM As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolMoverBarrio As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirBarriosUniones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolDeshacerMoverBarrio As System.Windows.Forms.ToolStripButton
End Class
