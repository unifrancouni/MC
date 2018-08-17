<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbDepartamento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbDepartamento))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.tbMunicipio = New System.Windows.Forms.ToolStrip
        Me.toolAgregarM = New System.Windows.Forms.ToolStripButton
        Me.toolModificarM = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarM = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaM = New System.Windows.Forms.ToolStripButton
        Me.grdMunicipio = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdDepartamento = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbDepartamento = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbMunicipio.SuspendLayout()
        CType(Me.grdMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDepartamento.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.tbMunicipio)
        Me.C1Sizer1.Controls.Add(Me.grdMunicipio)
        Me.C1Sizer1.Controls.Add(Me.grdDepartamento)
        Me.C1Sizer1.Controls.Add(Me.tbDepartamento)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(674, 403)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbMunicipio
        '
        Me.tbMunicipio.AutoSize = False
        Me.tbMunicipio.Dock = System.Windows.Forms.DockStyle.None
        Me.tbMunicipio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarM, Me.toolModificarM, Me.toolEliminarM, Me.ToolStripSeparator2, Me.toolAyudaM})
        Me.tbMunicipio.Location = New System.Drawing.Point(4, 206)
        Me.tbMunicipio.Name = "tbMunicipio"
        Me.tbMunicipio.Size = New System.Drawing.Size(164, 23)
        Me.tbMunicipio.Stretch = True
        Me.tbMunicipio.TabIndex = 15
        Me.tbMunicipio.Text = "ToolStrip1"
        '
        'toolAgregarM
        '
        Me.toolAgregarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarM.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarM.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarM.Name = "toolAgregarM"
        Me.toolAgregarM.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregarM.Text = "Agregar"
        Me.toolAgregarM.ToolTipText = "Agregar"
        '
        'toolModificarM
        '
        Me.toolModificarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarM.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarM.Name = "toolModificarM"
        Me.toolModificarM.Size = New System.Drawing.Size(23, 20)
        Me.toolModificarM.Text = "Modificar"
        Me.toolModificarM.ToolTipText = "Modificar"
        '
        'toolEliminarM
        '
        Me.toolEliminarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarM.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarM.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarM.Name = "toolEliminarM"
        Me.toolEliminarM.Size = New System.Drawing.Size(23, 20)
        Me.toolEliminarM.Text = "Eliminar"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolAyudaM
        '
        Me.toolAyudaM.AutoSize = False
        Me.toolAyudaM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaM.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolAyudaM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaM.Name = "toolAyudaM"
        Me.toolAyudaM.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaM.Text = "Ayuda"
        Me.toolAyudaM.ToolTipText = "Ayuda"
        '
        'grdMunicipio
        '
        Me.grdMunicipio.AllowFilter = False
        Me.grdMunicipio.AllowUpdate = False
        Me.grdMunicipio.Caption = "Listado de Municipios"
        Me.grdMunicipio.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdMunicipio.FilterBar = True
        Me.grdMunicipio.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdMunicipio.Images.Add(CType(resources.GetObject("grdMunicipio.Images"), System.Drawing.Image))
        Me.grdMunicipio.Location = New System.Drawing.Point(4, 233)
        Me.grdMunicipio.Name = "grdMunicipio"
        Me.grdMunicipio.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdMunicipio.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdMunicipio.PreviewInfo.ZoomFactor = 75
        Me.grdMunicipio.PrintInfo.PageSettings = CType(resources.GetObject("grdMunicipio.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdMunicipio.Size = New System.Drawing.Size(666, 166)
        Me.grdMunicipio.TabIndex = 14
        Me.grdMunicipio.Text = "grdModulo"
        Me.grdMunicipio.PropBag = resources.GetString("grdMunicipio.PropBag")
        '
        'grdDepartamento
        '
        Me.grdDepartamento.AllowFilter = False
        Me.grdDepartamento.AllowUpdate = False
        Me.grdDepartamento.Caption = "Listado de Departamentos"
        Me.grdDepartamento.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDepartamento.FilterBar = True
        Me.grdDepartamento.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDepartamento.Images.Add(CType(resources.GetObject("grdDepartamento.Images"), System.Drawing.Image))
        Me.grdDepartamento.Location = New System.Drawing.Point(4, 27)
        Me.grdDepartamento.Name = "grdDepartamento"
        Me.grdDepartamento.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDepartamento.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDepartamento.PreviewInfo.ZoomFactor = 75
        Me.grdDepartamento.PrintInfo.PageSettings = CType(resources.GetObject("grdDepartamento.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDepartamento.Size = New System.Drawing.Size(666, 175)
        Me.grdDepartamento.TabIndex = 13
        Me.grdDepartamento.Text = "grdDocSoporte"
        Me.grdDepartamento.PropBag = resources.GetString("grdDepartamento.PropBag")
        '
        'tbDepartamento
        '
        Me.tbDepartamento.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.ToolStripSeparator3, Me.toolAyuda, Me.toolCerrar})
        Me.tbDepartamento.Location = New System.Drawing.Point(0, 0)
        Me.tbDepartamento.Name = "tbDepartamento"
        Me.tbDepartamento.Size = New System.Drawing.Size(674, 25)
        Me.tbDepartamento.Stretch = True
        Me.tbDepartamento.TabIndex = 12
        Me.tbDepartamento.Text = "ToolStrip1"
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
        Me.toolImprimir.Text = "ToolStripButton1"
        Me.toolImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'frmStbDepartamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 403)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Departamento/Municipio")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStbDepartamento"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento Departamento - Municipio"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbMunicipio.ResumeLayout(False)
        Me.tbMunicipio.PerformLayout()
        CType(Me.grdMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDepartamento.ResumeLayout(False)
        Me.tbDepartamento.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbMunicipio As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaM As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdMunicipio As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdDepartamento As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbDepartamento As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
