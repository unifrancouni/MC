<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnEjerciciosContables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnEjerciciosContables))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.tbPeriodo = New System.Windows.Forms.ToolStrip
        Me.toolCerrarP = New System.Windows.Forms.ToolStripButton
        Me.toolCerrarD = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaC = New System.Windows.Forms.ToolStripButton
        Me.grdPeriodo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdEjercicio = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbEjercicio = New System.Windows.Forms.ToolStrip
        Me.toolAgregarE = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarE = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolCerrarE = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimirL = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbPeriodo.SuspendLayout()
        CType(Me.grdPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdEjercicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbEjercicio.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.tbPeriodo)
        Me.C1Sizer1.Controls.Add(Me.grdPeriodo)
        Me.C1Sizer1.Controls.Add(Me.grdEjercicio)
        Me.C1Sizer1.Controls.Add(Me.tbEjercicio)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(664, 435)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbPeriodo
        '
        Me.tbPeriodo.AutoSize = False
        Me.tbPeriodo.Dock = System.Windows.Forms.DockStyle.None
        Me.tbPeriodo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolCerrarP, Me.toolCerrarD, Me.toolSeparator2, Me.toolAyudaC})
        Me.tbPeriodo.Location = New System.Drawing.Point(4, 222)
        Me.tbPeriodo.Name = "tbPeriodo"
        Me.tbPeriodo.Size = New System.Drawing.Size(164, 23)
        Me.tbPeriodo.Stretch = True
        Me.tbPeriodo.TabIndex = 15
        Me.tbPeriodo.Text = "ToolStrip1"
        '
        'toolCerrarP
        '
        Me.toolCerrarP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrarP.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolCerrarP.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolCerrarP.Name = "toolCerrarP"
        Me.toolCerrarP.Size = New System.Drawing.Size(23, 20)
        Me.toolCerrarP.Text = "Cierre Preliminar Período"
        Me.toolCerrarP.ToolTipText = "Cierre Preliminar Período"
        '
        'toolCerrarD
        '
        Me.toolCerrarD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrarD.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolCerrarD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrarD.Name = "toolCerrarD"
        Me.toolCerrarD.Size = New System.Drawing.Size(23, 20)
        Me.toolCerrarD.Text = "Cierre Definitivo Período"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolAyudaC
        '
        Me.toolAyudaC.AutoSize = False
        Me.toolAyudaC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaC.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaC.Name = "toolAyudaC"
        Me.toolAyudaC.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaC.Text = "Ayuda"
        Me.toolAyudaC.ToolTipText = "Ayuda"
        '
        'grdPeriodo
        '
        Me.grdPeriodo.AllowFilter = False
        Me.grdPeriodo.AllowUpdate = False
        Me.grdPeriodo.Caption = "Listado de Períodos Contables"
        Me.grdPeriodo.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdPeriodo.FilterBar = True
        Me.grdPeriodo.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdPeriodo.Images.Add(CType(resources.GetObject("grdPeriodo.Images"), System.Drawing.Image))
        Me.grdPeriodo.Location = New System.Drawing.Point(4, 249)
        Me.grdPeriodo.Name = "grdPeriodo"
        Me.grdPeriodo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPeriodo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPeriodo.PreviewInfo.ZoomFactor = 75
        Me.grdPeriodo.PrintInfo.PageSettings = CType(resources.GetObject("grdPeriodo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdPeriodo.Size = New System.Drawing.Size(656, 182)
        Me.grdPeriodo.TabIndex = 14
        Me.grdPeriodo.Text = "grdModulo"
        Me.grdPeriodo.PropBag = resources.GetString("grdPeriodo.PropBag")
        '
        'grdEjercicio
        '
        Me.grdEjercicio.AllowFilter = False
        Me.grdEjercicio.AllowUpdate = False
        Me.grdEjercicio.Caption = "Listado de Ejercicios Contables"
        Me.grdEjercicio.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdEjercicio.FilterBar = True
        Me.grdEjercicio.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdEjercicio.Images.Add(CType(resources.GetObject("grdEjercicio.Images"), System.Drawing.Image))
        Me.grdEjercicio.Location = New System.Drawing.Point(4, 27)
        Me.grdEjercicio.Name = "grdEjercicio"
        Me.grdEjercicio.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdEjercicio.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdEjercicio.PreviewInfo.ZoomFactor = 75
        Me.grdEjercicio.PrintInfo.PageSettings = CType(resources.GetObject("grdEjercicio.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdEjercicio.Size = New System.Drawing.Size(656, 191)
        Me.grdEjercicio.TabIndex = 13
        Me.grdEjercicio.Text = "grdDocSoporte"
        Me.grdEjercicio.PropBag = resources.GetString("grdEjercicio.PropBag")
        '
        'tbEjercicio
        '
        Me.tbEjercicio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarE, Me.toolEliminarE, Me.ToolStripButton7, Me.toolCerrarE, Me.ToolStripSeparator1, Me.toolRefrescar, Me.toolSeparator1, Me.toolImprimirL, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbEjercicio.Location = New System.Drawing.Point(0, 0)
        Me.tbEjercicio.Name = "tbEjercicio"
        Me.tbEjercicio.Size = New System.Drawing.Size(664, 25)
        Me.tbEjercicio.Stretch = True
        Me.tbEjercicio.TabIndex = 12
        Me.tbEjercicio.Text = "ToolStrip1"
        '
        'toolAgregarE
        '
        Me.toolAgregarE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarE.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarE.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarE.Name = "toolAgregarE"
        Me.toolAgregarE.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarE.Text = "Agregar Ejercicio"
        Me.toolAgregarE.ToolTipText = "Agregar Ejercicio"
        '
        'toolEliminarE
        '
        Me.toolEliminarE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarE.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEliminarE.Name = "toolEliminarE"
        Me.toolEliminarE.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarE.Text = "Eliminar Ejercicio"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'toolCerrarE
        '
        Me.toolCerrarE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrarE.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolCerrarE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrarE.Name = "toolCerrarE"
        Me.toolCerrarE.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrarE.Text = "Cerrar Ejercicio Contable"
        Me.toolCerrarE.ToolTipText = "Cerrar Ejercicio Contable"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'toolImprimirL
        '
        Me.toolImprimirL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirL.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirL.Name = "toolImprimirL"
        Me.toolImprimirL.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirL.Text = "ToolStripButton1"
        Me.toolImprimirL.ToolTipText = "Imprimir Listado"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'frmScnEjerciciosContables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 435)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Ejercicios Contables")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScnEjerciciosContables"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Ejercicios Contables"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbPeriodo.ResumeLayout(False)
        Me.tbPeriodo.PerformLayout()
        CType(Me.grdPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdEjercicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbEjercicio.ResumeLayout(False)
        Me.tbEjercicio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbPeriodo As System.Windows.Forms.ToolStrip
    Friend WithEvents toolCerrarP As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaC As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdPeriodo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdEjercicio As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbEjercicio As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarE As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirL As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrarE As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolCerrarD As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarE As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
