<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteCajeros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteCajeros))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.tbCaja = New System.Windows.Forms.ToolStrip
        Me.toolAgregarC = New System.Windows.Forms.ToolStripButton
        Me.toolInactivarC = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaC = New System.Windows.Forms.ToolStripButton
        Me.grdCajas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdCajeros = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbCajero = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolAnular = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.toolImprimirL = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbCaja.SuspendLayout()
        CType(Me.grdCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCajeros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCajero.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.tbCaja)
        Me.C1Sizer1.Controls.Add(Me.grdCajas)
        Me.C1Sizer1.Controls.Add(Me.grdCajeros)
        Me.C1Sizer1.Controls.Add(Me.tbCajero)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(664, 435)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbCaja
        '
        Me.tbCaja.AutoSize = False
        Me.tbCaja.Dock = System.Windows.Forms.DockStyle.None
        Me.tbCaja.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarC, Me.toolInactivarC, Me.toolSeparator2, Me.toolAyudaC})
        Me.tbCaja.Location = New System.Drawing.Point(4, 233)
        Me.tbCaja.Name = "tbCaja"
        Me.tbCaja.Size = New System.Drawing.Size(164, 23)
        Me.tbCaja.Stretch = True
        Me.tbCaja.TabIndex = 15
        Me.tbCaja.Text = "ToolStrip1"
        '
        'toolAgregarC
        '
        Me.toolAgregarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarC.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarC.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarC.Name = "toolAgregarC"
        Me.toolAgregarC.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregarC.Text = "Agregar"
        Me.toolAgregarC.ToolTipText = "Agregar Caja"
        '
        'toolInactivarC
        '
        Me.toolInactivarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolInactivarC.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolInactivarC.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolInactivarC.Name = "toolInactivarC"
        Me.toolInactivarC.Size = New System.Drawing.Size(23, 20)
        Me.toolInactivarC.Text = "Inactivar Caja"
        Me.toolInactivarC.ToolTipText = "Inactivar Caja"
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
        'grdCajas
        '
        Me.grdCajas.AllowFilter = False
        Me.grdCajas.AllowUpdate = False
        Me.grdCajas.Caption = "Listado de Cajas asignadas al Cajero"
        Me.grdCajas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdCajas.FilterBar = True
        Me.grdCajas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdCajas.Images.Add(CType(resources.GetObject("grdCajas.Images"), System.Drawing.Image))
        Me.grdCajas.Location = New System.Drawing.Point(4, 260)
        Me.grdCajas.Name = "grdCajas"
        Me.grdCajas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCajas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCajas.PreviewInfo.ZoomFactor = 75
        Me.grdCajas.PrintInfo.PageSettings = CType(resources.GetObject("grdCajas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCajas.Size = New System.Drawing.Size(656, 171)
        Me.grdCajas.TabIndex = 14
        Me.grdCajas.Text = "grdCajas"
        Me.grdCajas.PropBag = resources.GetString("grdCajas.PropBag")
        '
        'grdCajeros
        '
        Me.grdCajeros.AllowFilter = False
        Me.grdCajeros.AllowUpdate = False
        Me.grdCajeros.Caption = "Listado de Cajeros del Programa"
        Me.grdCajeros.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdCajeros.FilterBar = True
        Me.grdCajeros.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdCajeros.Images.Add(CType(resources.GetObject("grdCajeros.Images"), System.Drawing.Image))
        Me.grdCajeros.Location = New System.Drawing.Point(4, 26)
        Me.grdCajeros.Name = "grdCajeros"
        Me.grdCajeros.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCajeros.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCajeros.PreviewInfo.ZoomFactor = 75
        Me.grdCajeros.PrintInfo.PageSettings = CType(resources.GetObject("grdCajeros.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCajeros.Size = New System.Drawing.Size(656, 203)
        Me.grdCajeros.TabIndex = 13
        Me.grdCajeros.Text = "grdCajeros"
        Me.grdCajeros.PropBag = resources.GetString("grdCajeros.PropBag")
        '
        'tbCajero
        '
        Me.tbCajero.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolAnular, Me.ToolStripButton7, Me.toolRefrescar, Me.toolSeparator1, Me.toolImprimir, Me.toolImprimirL, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbCajero.Location = New System.Drawing.Point(0, 0)
        Me.tbCajero.Name = "tbCajero"
        Me.tbCajero.Size = New System.Drawing.Size(664, 25)
        Me.tbCajero.Stretch = True
        Me.tbCajero.TabIndex = 12
        Me.tbCajero.Text = "ToolStrip1"
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
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 22)
        Me.toolAnular.Text = "Inactivar"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
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
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimir.Text = "Imprimir Listado Cajeros"
        Me.toolImprimir.ToolTipText = "Imprimir Listado Cajeros"
        '
        'toolImprimirL
        '
        Me.toolImprimirL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirL.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirL.Name = "toolImprimirL"
        Me.toolImprimirL.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirL.Text = "Imprimir Listado Cajas asignadas"
        Me.toolImprimirL.ToolTipText = "Imprimir Listado Cajas asignadas"
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
        'frmSteCajeros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 435)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Cajeros")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSteCajeros"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Cajeros del Programa"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbCaja.ResumeLayout(False)
        Me.tbCaja.PerformLayout()
        CType(Me.grdCajas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCajeros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCajero.ResumeLayout(False)
        Me.tbCajero.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbCaja As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolInactivarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaC As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdCajas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdCajeros As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbCajero As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirL As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
