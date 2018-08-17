<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSclReferenciaSocia
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclReferenciaSocia))
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.tbReferencias = New System.Windows.Forms.ToolStrip()
        Me.toolAgregarR = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarR = New System.Windows.Forms.ToolStripButton()
        Me.toolInactivarR = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyudaR = New System.Windows.Forms.ToolStripButton()
        Me.toolImprimirR = New System.Windows.Forms.ToolStripButton()
        Me.grdReferencias = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdSocias = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbSocias = New System.Windows.Forms.ToolStrip()
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImprimirS = New System.Windows.Forms.ToolStripButton()
        Me.toolImprimirL = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbReferencias.SuspendLayout()
        CType(Me.grdReferencias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSocias.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.tbReferencias)
        Me.C1Sizer1.Controls.Add(Me.grdReferencias)
        Me.C1Sizer1.Controls.Add(Me.grdSocias)
        Me.C1Sizer1.Controls.Add(Me.tbSocias)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(664, 435)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbReferencias
        '
        Me.tbReferencias.AutoSize = False
        Me.tbReferencias.Dock = System.Windows.Forms.DockStyle.None
        Me.tbReferencias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarR, Me.toolModificarR, Me.toolInactivarR, Me.toolSeparator2, Me.toolAyudaR, Me.toolImprimirR})
        Me.tbReferencias.Location = New System.Drawing.Point(4, 235)
        Me.tbReferencias.Name = "tbReferencias"
        Me.tbReferencias.Size = New System.Drawing.Size(164, 23)
        Me.tbReferencias.Stretch = True
        Me.tbReferencias.TabIndex = 15
        Me.tbReferencias.Text = "ToolStrip1"
        '
        'toolAgregarR
        '
        Me.toolAgregarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarR.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarR.Name = "toolAgregarR"
        Me.toolAgregarR.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregarR.Text = "Agregar Referencia"
        Me.toolAgregarR.ToolTipText = "Agregar Referencia"
        '
        'toolModificarR
        '
        Me.toolModificarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarR.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarR.Name = "toolModificarR"
        Me.toolModificarR.Size = New System.Drawing.Size(23, 20)
        Me.toolModificarR.Text = "Modificar Referencia"
        Me.toolModificarR.ToolTipText = "Modificar Referencia"
        '
        'toolInactivarR
        '
        Me.toolInactivarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolInactivarR.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolInactivarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolInactivarR.Name = "toolInactivarR"
        Me.toolInactivarR.Size = New System.Drawing.Size(23, 20)
        Me.toolInactivarR.Text = "Inactivar Referencia"
        Me.toolInactivarR.ToolTipText = "Inactivar Referencia"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolAyudaR
        '
        Me.toolAyudaR.AutoSize = False
        Me.toolAyudaR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaR.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaR.Name = "toolAyudaR"
        Me.toolAyudaR.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaR.Text = "Ayuda"
        Me.toolAyudaR.ToolTipText = "Ayuda"
        '
        'toolImprimirR
        '
        Me.toolImprimirR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirR.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirR.Name = "toolImprimirR"
        Me.toolImprimirR.Size = New System.Drawing.Size(23, 20)
        Me.toolImprimirR.Text = "Imprimir Referencia para Acta"
        '
        'grdReferencias
        '
        Me.grdReferencias.AllowFilter = False
        Me.grdReferencias.AllowUpdate = False
        Me.grdReferencias.Caption = "Listado de Referencias de Socia"
        Me.grdReferencias.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdReferencias.FilterBar = True
        Me.grdReferencias.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdReferencias.Images.Add(CType(resources.GetObject("grdReferencias.Images"), System.Drawing.Image))
        Me.grdReferencias.Location = New System.Drawing.Point(4, 262)
        Me.grdReferencias.Name = "grdReferencias"
        Me.grdReferencias.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdReferencias.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdReferencias.PreviewInfo.ZoomFactor = 75.0R
        Me.grdReferencias.PrintInfo.PageSettings = CType(resources.GetObject("grdReferencias.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdReferencias.Size = New System.Drawing.Size(656, 169)
        Me.grdReferencias.TabIndex = 14
        Me.grdReferencias.Text = "grdModulo"
        Me.grdReferencias.PropBag = resources.GetString("grdReferencias.PropBag")
        '
        'grdSocias
        '
        Me.grdSocias.AllowFilter = False
        Me.grdSocias.AllowUpdate = False
        Me.grdSocias.Caption = "Listado de Socias"
        Me.grdSocias.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSocias.FilterBar = True
        Me.grdSocias.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSocias.Images.Add(CType(resources.GetObject("grdSocias.Images"), System.Drawing.Image))
        Me.grdSocias.Location = New System.Drawing.Point(4, 31)
        Me.grdSocias.Name = "grdSocias"
        Me.grdSocias.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSocias.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSocias.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSocias.PrintInfo.PageSettings = CType(resources.GetObject("grdSocias.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocias.Size = New System.Drawing.Size(656, 200)
        Me.grdSocias.TabIndex = 13
        Me.grdSocias.Text = "grdDocSoporte"
        Me.grdSocias.PropBag = resources.GetString("grdSocias.PropBag")
        '
        'tbSocias
        '
        Me.tbSocias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.ToolStripButton7, Me.toolRefrescar, Me.toolSeparator1, Me.toolImprimirS, Me.toolImprimirL, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbSocias.Location = New System.Drawing.Point(4, 4)
        Me.tbSocias.Name = "tbSocias"
        Me.tbSocias.Size = New System.Drawing.Size(656, 23)
        Me.tbSocias.Stretch = True
        Me.tbSocias.TabIndex = 12
        Me.tbSocias.Text = "ToolStrip1"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 20)
        Me.toolBuscar.Text = "Buscar Socia"
        Me.toolBuscar.ToolTipText = "Buscar Socia"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 23)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 20)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'toolImprimirS
        '
        Me.toolImprimirS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirS.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirS.Name = "toolImprimirS"
        Me.toolImprimirS.Size = New System.Drawing.Size(23, 20)
        Me.toolImprimirS.Text = "Listado de Socias con Referencias"
        Me.toolImprimirS.ToolTipText = "Listado de Socias con Referencias"
        '
        'toolImprimirL
        '
        Me.toolImprimirL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirL.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirL.Name = "toolImprimirL"
        Me.toolImprimirL.Size = New System.Drawing.Size(23, 20)
        Me.toolImprimirL.Text = "Listado de Referencias"
        Me.toolImprimirL.ToolTipText = "Listado de Referencias"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 20)
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
        Me.toolSalir.Size = New System.Drawing.Size(23, 20)
        Me.toolSalir.Text = "Cerrar"
        Me.toolSalir.ToolTipText = "Salir"
        '
        'frmSclReferenciaSocia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 435)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Central de Riesgo")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclReferenciaSocia"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Referencias Socias"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbReferencias.ResumeLayout(False)
        Me.tbReferencias.PerformLayout()
        CType(Me.grdReferencias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSocias.ResumeLayout(False)
        Me.tbSocias.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbReferencias As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolInactivarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaR As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdReferencias As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdSocias As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbSocias As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirL As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirS As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolImprimirR As System.Windows.Forms.ToolStripButton
End Class
