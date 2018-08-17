<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbTasaCambio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbTasaCambio))
        Me.TbTasasdeCambio = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.grdParidad10 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.TbTasasdeCambio.SuspendLayout()
        CType(Me.grdParidad10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbTasasdeCambio
        '
        Me.TbTasasdeCambio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolRefrescar, Me.toolImprimir, Me.ToolStripSeparator1, Me.toolAyuda, Me.toolCerrar, Me.ToolStripSeparator2})
        Me.TbTasasdeCambio.Location = New System.Drawing.Point(0, 0)
        Me.TbTasasdeCambio.Name = "TbTasasdeCambio"
        Me.TbTasasdeCambio.Size = New System.Drawing.Size(434, 25)
        Me.TbTasasdeCambio.Stretch = True
        Me.TbTasasdeCambio.TabIndex = 4
        Me.TbTasasdeCambio.Text = "TbTasasdeCambio"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = CType(resources.GetObject("toolAgregar.Image"), System.Drawing.Image)
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar "
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
        Me.toolImprimir.BackColor = System.Drawing.Color.Transparent
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = CType(resources.GetObject("toolImprimir.Image"), System.Drawing.Image)
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimir.Text = "Imprimir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.Image = CType(resources.GetObject("toolAyuda.Image"), System.Drawing.Image)
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 22)
        Me.toolAyuda.Text = "Ayuda"
        '
        'toolCerrar
        '
        Me.toolCerrar.BackColor = System.Drawing.Color.Transparent
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = CType(resources.GetObject("toolCerrar.Image"), System.Drawing.Image)
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrar.Text = "Cerrar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'grdParidad10
        '
        Me.grdParidad10.AllowFilter = False
        Me.grdParidad10.AllowUpdate = False
        Me.grdParidad10.AllowUpdateOnBlur = False
        Me.grdParidad10.Caption = "Listado de Tasas de Cambio"
        Me.grdParidad10.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdParidad10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdParidad10.FilterBar = True
        Me.grdParidad10.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdParidad10.Images.Add(CType(resources.GetObject("grdParidad10.Images"), System.Drawing.Image))
        Me.grdParidad10.Location = New System.Drawing.Point(0, 25)
        Me.grdParidad10.Name = "grdParidad10"
        Me.grdParidad10.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdParidad10.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdParidad10.PreviewInfo.ZoomFactor = 75
        Me.grdParidad10.PrintInfo.PageSettings = CType(resources.GetObject("grdParidad10.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdParidad10.Size = New System.Drawing.Size(434, 287)
        Me.grdParidad10.TabIndex = 5
        Me.grdParidad10.Text = "C1TrueDBGrid1"
        Me.grdParidad10.PropBag = resources.GetString("grdParidad10.PropBag")
        '
        'frmStbTasaCambio
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 312)
        Me.Controls.Add(Me.grdParidad10)
        Me.Controls.Add(Me.TbTasasdeCambio)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Tasas de Cambio")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStbTasaCambio"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento Tasa de Cambio"
        Me.TbTasasdeCambio.ResumeLayout(False)
        Me.TbTasasdeCambio.PerformLayout()
        CType(Me.grdParidad10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TbTasasdeCambio As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grdParidad10 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider

End Class
