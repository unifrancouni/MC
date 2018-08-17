<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbTipoMoneda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbTipoMoneda))
        Me.TbMoneda = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.grdMonedas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.TbMoneda.SuspendLayout()
        CType(Me.grdMonedas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbMoneda
        '
        Me.TbMoneda.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.toolAyuda, Me.ToolStripSeparator3, Me.toolCerrar, Me.ToolStripSeparator2})
        Me.TbMoneda.Location = New System.Drawing.Point(0, 0)
        Me.TbMoneda.Name = "TbMoneda"
        Me.TbMoneda.Size = New System.Drawing.Size(434, 25)
        Me.TbMoneda.Stretch = True
        Me.TbMoneda.TabIndex = 4
        Me.TbMoneda.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = CType(resources.GetObject("toolAgregar.Image"), System.Drawing.Image)
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimir.Text = "Imprimir"
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'grdMonedas
        '
        Me.grdMonedas.AllowFilter = False
        Me.grdMonedas.AllowUpdate = False
        Me.grdMonedas.AllowUpdateOnBlur = False
        Me.grdMonedas.Caption = "Listado de Tipos de Moneda"
        Me.grdMonedas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdMonedas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMonedas.FilterBar = True
        Me.grdMonedas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdMonedas.Images.Add(CType(resources.GetObject("grdMonedas.Images"), System.Drawing.Image))
        Me.grdMonedas.Location = New System.Drawing.Point(0, 25)
        Me.grdMonedas.Name = "grdMonedas"
        Me.grdMonedas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdMonedas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdMonedas.PreviewInfo.ZoomFactor = 75
        Me.grdMonedas.PrintInfo.PageSettings = CType(resources.GetObject("grdMonedas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdMonedas.Size = New System.Drawing.Size(434, 287)
        Me.grdMonedas.TabIndex = 5
        Me.grdMonedas.Text = "C1TrueDBGrid1"
        Me.grdMonedas.PropBag = resources.GetString("grdMonedas.PropBag")
        '
        'frmStbTipoMoneda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 312)
        Me.Controls.Add(Me.grdMonedas)
        Me.Controls.Add(Me.TbMoneda)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Monedas")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStbTipoMoneda"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento de Moneda"
        Me.TbMoneda.ResumeLayout(False)
        Me.TbMoneda.PerformLayout()
        CType(Me.grdMonedas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TbMoneda As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grdMonedas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider

End Class
