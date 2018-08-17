<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbCatalogo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbCatalogo))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.toolCatalogos = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolAyuda = New System.Windows.Forms.ToolStripButton
        Me.ToolImprimir = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.GrdValoresCatalogos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.LstCatalogos = New C1.Win.C1List.C1List
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.toolCatalogos.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.GrdValoresCatalogos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LstCatalogos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolCatalogos
        '
        Me.toolCatalogos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolRefrescar, Me.ToolAyuda, Me.ToolImprimir, Me.toolCerrar, Me.ToolStripButton2})
        Me.toolCatalogos.Location = New System.Drawing.Point(0, 0)
        Me.toolCatalogos.Name = "toolCatalogos"
        Me.toolCatalogos.Size = New System.Drawing.Size(675, 25)
        Me.toolCatalogos.Stretch = True
        Me.toolCatalogos.TabIndex = 0
        Me.toolCatalogos.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar Catálogo"
        Me.toolAgregar.ToolTipText = "&Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = CType(resources.GetObject("toolModificar.Image"), System.Drawing.Image)
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar"
        '
        'toolEliminar
        '
        Me.toolEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminar.Image = CType(resources.GetObject("toolEliminar.Image"), System.Drawing.Image)
        Me.toolEliminar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminar.Name = "toolEliminar"
        Me.toolEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminar.Text = "Eliminar"
        Me.toolEliminar.ToolTipText = "Eliminar"
        Me.toolEliminar.Visible = False
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = CType(resources.GetObject("toolRefrescar.Image"), System.Drawing.Image)
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'ToolAyuda
        '
        Me.ToolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolAyuda.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.ToolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolAyuda.Name = "ToolAyuda"
        Me.ToolAyuda.Size = New System.Drawing.Size(23, 22)
        Me.ToolAyuda.Text = "ToolStripButton1"
        Me.ToolAyuda.ToolTipText = "Ayuda"
        '
        'ToolImprimir
        '
        Me.ToolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.ToolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolImprimir.Name = "ToolImprimir"
        Me.ToolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.ToolImprimir.Text = "Imprimir Catálogos"
        Me.ToolImprimir.ToolTipText = "Imprimir"
        '
        'toolCerrar
        '
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrar.Text = "Salir"
        Me.toolCerrar.ToolTipText = "Salir"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(6, 25)
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.GrdValoresCatalogos)
        Me.C1Sizer1.Controls.Add(Me.LstCatalogos)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 25)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(675, 499)
        Me.C1Sizer1.TabIndex = 8
        Me.C1Sizer1.TabStop = False
        '
        'GrdValoresCatalogos
        '
        Me.GrdValoresCatalogos.AllowFilter = False
        Me.GrdValoresCatalogos.AllowUpdate = False
        Me.GrdValoresCatalogos.AllowUpdateOnBlur = False
        Me.GrdValoresCatalogos.Caption = "Valores de Catálogos Básicos"
        Me.GrdValoresCatalogos.FilterBar = True
        Me.GrdValoresCatalogos.GroupByCaption = "Drag a column header here to group by that column"
        Me.GrdValoresCatalogos.Images.Add(CType(resources.GetObject("GrdValoresCatalogos.Images"), System.Drawing.Image))
        Me.GrdValoresCatalogos.Location = New System.Drawing.Point(320, 4)
        Me.GrdValoresCatalogos.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.GrdValoresCatalogos.Name = "GrdValoresCatalogos"
        Me.GrdValoresCatalogos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.GrdValoresCatalogos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.GrdValoresCatalogos.PreviewInfo.ZoomFactor = 75
        Me.GrdValoresCatalogos.PrintInfo.PageSettings = CType(resources.GetObject("GrdValoresCatalogos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.GrdValoresCatalogos.Size = New System.Drawing.Size(351, 491)
        Me.GrdValoresCatalogos.TabIndex = 7
        Me.GrdValoresCatalogos.PropBag = resources.GetString("GrdValoresCatalogos.PropBag")
        '
        'LstCatalogos
        '
        Me.LstCatalogos.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.LstCatalogos.Caption = "Catálogos Básicos"
        Me.LstCatalogos.CaptionHeight = 17
        Me.LstCatalogos.CaptionStyle = Style1
        Me.LstCatalogos.ColumnCaptionHeight = 17
        Me.LstCatalogos.ColumnFooterHeight = 17
        Me.LstCatalogos.DeadAreaBackColor = System.Drawing.SystemColors.ControlDark
        Me.LstCatalogos.EvenRowStyle = Style2
        Me.LstCatalogos.FooterStyle = Style3
        Me.LstCatalogos.HeadingStyle = Style4
        Me.LstCatalogos.HighLightRowStyle = Style5
        Me.LstCatalogos.Images.Add(CType(resources.GetObject("LstCatalogos.Images"), System.Drawing.Image))
        Me.LstCatalogos.ItemHeight = 15
        Me.LstCatalogos.Location = New System.Drawing.Point(4, 4)
        Me.LstCatalogos.MatchEntryTimeout = CType(2000, Long)
        Me.LstCatalogos.Name = "LstCatalogos"
        Me.LstCatalogos.OddRowStyle = Style6
        Me.LstCatalogos.PartialRightColumn = False
        Me.LstCatalogos.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.LstCatalogos.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.LstCatalogos.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.LstCatalogos.SelectedStyle = Style7
        Me.LstCatalogos.Size = New System.Drawing.Size(312, 491)
        Me.LstCatalogos.Style = Style8
        Me.LstCatalogos.TabIndex = 0
        Me.LstCatalogos.Text = "C1List1"
        Me.LstCatalogos.PropBag = resources.GetString("LstCatalogos.PropBag")
        '
        'frmStbCatalogo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 524)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Controls.Add(Me.toolCatalogos)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de  Catálogos Generales")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStbCatalogo"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento de Catálogos Básicos"
        Me.toolCatalogos.ResumeLayout(False)
        Me.toolCatalogos.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        CType(Me.GrdValoresCatalogos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LstCatalogos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolCatalogos As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents LstCatalogos As C1.Win.C1List.C1List
    Friend WithEvents GrdValoresCatalogos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ToolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
