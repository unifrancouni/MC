<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnFuenteF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnFuenteF))
        Me.tbFuenteF = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolSeparador = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.grdFuenteF = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.tbFuenteF.SuspendLayout()
        CType(Me.grdFuenteF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbFuenteF
        '
        Me.tbFuenteF.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolSeparador, Me.toolRefrescar, Me.toolImprimir, Me.ToolStripSeparator1, Me.ToolAyuda, Me.toolCerrar})
        Me.tbFuenteF.Location = New System.Drawing.Point(0, 0)
        Me.tbFuenteF.Name = "tbFuenteF"
        Me.tbFuenteF.Size = New System.Drawing.Size(628, 25)
        Me.tbFuenteF.TabIndex = 4
        Me.tbFuenteF.Text = "Agregar"
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
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Agregar"
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
        'ToolSeparador
        '
        Me.ToolSeparador.Name = "ToolSeparador"
        Me.ToolSeparador.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        Me.toolRefrescar.ToolTipText = "Refrescar"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'toolCerrar
        '
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrar.Text = "ToolCerrar"
        Me.toolCerrar.ToolTipText = "Cerrar"
        '
        'grdFuenteF
        '
        Me.grdFuenteF.AllowFilter = False
        Me.grdFuenteF.AllowUpdate = False
        Me.grdFuenteF.Caption = "Fuentes de Financiamiento"
        Me.grdFuenteF.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdFuenteF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFuenteF.FilterBar = True
        Me.grdFuenteF.GroupByCaption = "Arrastre aqui la columna por la que desea agrupar"
        Me.grdFuenteF.Images.Add(CType(resources.GetObject("grdFuenteF.Images"), System.Drawing.Image))
        Me.grdFuenteF.Location = New System.Drawing.Point(0, 25)
        Me.grdFuenteF.Name = "grdFuenteF"
        Me.grdFuenteF.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdFuenteF.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdFuenteF.PreviewInfo.ZoomFactor = 75
        Me.grdFuenteF.PrintInfo.PageSettings = CType(resources.GetObject("grdFuenteF.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdFuenteF.Size = New System.Drawing.Size(628, 286)
        Me.grdFuenteF.TabIndex = 5
        Me.grdFuenteF.PropBag = resources.GetString("grdFuenteF.PropBag")
        '
        'frmScnFuenteF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 311)
        Me.Controls.Add(Me.grdFuenteF)
        Me.Controls.Add(Me.tbFuenteF)
        Me.HelpProvider.SetHelpKeyword(Me, "Fuentes de Financiamiento")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScnFuenteF"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento de Fuentes de Financiamiento"
        Me.tbFuenteF.ResumeLayout(False)
        Me.tbFuenteF.PerformLayout()
        CType(Me.grdFuenteF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbFuenteF As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolSeparador As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdFuenteF As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
