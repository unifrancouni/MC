<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSsgSeguridad
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSsgSeguridad))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grdDetallePadre = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tabSeguridad = New C1.Win.C1Command.C1DockingTab
        Me.tabpSeg = New C1.Win.C1Command.C1DockingTabPage
        Me.treeSeguridad = New System.Windows.Forms.TreeView
        Me.toolSeguridad = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.toolAuditoria = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.grdDetallePadre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabSeguridad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSeguridad.SuspendLayout()
        Me.tabpSeg.SuspendLayout()
        Me.toolSeguridad.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "CdROM.JPG")
        Me.ImageList1.Images.SetKeyName(5, "Folder1.JPG")
        Me.ImageList1.Images.SetKeyName(6, "Pastel.JPG")
        Me.ImageList1.Images.SetKeyName(7, "Usuario1.JPG")
        Me.ImageList1.Images.SetKeyName(8, "Usuario2.JPG")
        Me.ImageList1.Images.SetKeyName(9, "Usuario4.ico")
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdDetallePadre)
        Me.C1Sizer1.Controls.Add(Me.tabSeguridad)
        Me.C1Sizer1.Controls.Add(Me.toolSeguridad)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(581, 376)
        Me.C1Sizer1.TabIndex = 0
        Me.C1Sizer1.TabStop = False
        '
        'grdDetallePadre
        '
        Me.grdDetallePadre.AllowFilter = False
        Me.grdDetallePadre.FilterBar = True
        Me.grdDetallePadre.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdDetallePadre.Images.Add(CType(resources.GetObject("grdDetallePadre.Images"), System.Drawing.Image))
        Me.grdDetallePadre.Location = New System.Drawing.Point(210, 34)
        Me.grdDetallePadre.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.grdDetallePadre.Name = "grdDetallePadre"
        Me.grdDetallePadre.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetallePadre.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetallePadre.PreviewInfo.ZoomFactor = 75
        Me.grdDetallePadre.PrintInfo.PageSettings = CType(resources.GetObject("grdDetallePadre.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetallePadre.Size = New System.Drawing.Size(367, 338)
        Me.grdDetallePadre.TabIndex = 8
        Me.grdDetallePadre.PropBag = resources.GetString("grdDetallePadre.PropBag")
        '
        'tabSeguridad
        '
        Me.tabSeguridad.Controls.Add(Me.tabpSeg)
        Me.tabSeguridad.Location = New System.Drawing.Point(4, 34)
        Me.tabSeguridad.Name = "tabSeguridad"
        Me.tabSeguridad.SelectedIndex = 0
        Me.tabSeguridad.Size = New System.Drawing.Size(202, 338)
        Me.tabSeguridad.TabIndex = 7
        '
        'tabpSeg
        '
        Me.tabpSeg.CaptionText = "Arbol"
        Me.tabpSeg.Controls.Add(Me.treeSeguridad)
        Me.tabpSeg.Location = New System.Drawing.Point(1, 24)
        Me.tabpSeg.Name = "tabpSeg"
        Me.tabpSeg.Size = New System.Drawing.Size(200, 313)
        Me.tabpSeg.TabIndex = 0
        Me.tabpSeg.Text = "Arbol"
        '
        'treeSeguridad
        '
        Me.treeSeguridad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeSeguridad.ImageIndex = 0
        Me.treeSeguridad.ImageList = Me.ImageList1
        Me.treeSeguridad.Location = New System.Drawing.Point(0, 0)
        Me.treeSeguridad.Name = "treeSeguridad"
        Me.treeSeguridad.SelectedImageIndex = 0
        Me.treeSeguridad.Size = New System.Drawing.Size(200, 313)
        Me.treeSeguridad.StateImageList = Me.ImageList1
        Me.treeSeguridad.TabIndex = 1
        '
        'toolSeguridad
        '
        Me.toolSeguridad.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolRefrescar, Me.toolImprimir, Me.ToolStripButton2, Me.toolCerrar, Me.toolAuditoria})
        Me.toolSeguridad.Location = New System.Drawing.Point(0, 0)
        Me.toolSeguridad.Name = "toolSeguridad"
        Me.toolSeguridad.Size = New System.Drawing.Size(581, 25)
        Me.toolSeguridad.Stretch = True
        Me.toolSeguridad.TabIndex = 6
        Me.toolSeguridad.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = CType(resources.GetObject("toolAgregar.Image"), System.Drawing.Image)
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar"
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
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimir.Text = "ToolStripButton1"
        Me.toolImprimir.ToolTipText = "Imprimir Opciones"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(6, 25)
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
        'toolAuditoria
        '
        Me.toolAuditoria.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAuditoria.Image = Global.SMUSURA0.My.Resources.Resources.Beneficiario16
        Me.toolAuditoria.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAuditoria.Name = "toolAuditoria"
        Me.toolAuditoria.Size = New System.Drawing.Size(23, 22)
        Me.toolAuditoria.Text = "Auditoria de Tablas"
        '
        'FrmSsgSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(581, 376)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Introducción Módulo de Seguridad")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmSsgSeguridad"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Módulo de Seguridad"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        CType(Me.grdDetallePadre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabSeguridad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSeguridad.ResumeLayout(False)
        Me.tabpSeg.ResumeLayout(False)
        Me.toolSeguridad.ResumeLayout(False)
        Me.toolSeguridad.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolSeguridad As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabSeguridad As C1.Win.C1Command.C1DockingTab
    Friend WithEvents tabpSeg As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grdDetallePadre As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents treeSeguridad As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolAuditoria As System.Windows.Forms.ToolStripButton
End Class
