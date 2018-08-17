<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSclSupervision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclSupervision))
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton()
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolEditar = New System.Windows.Forms.ToolStripButton()
        Me.toolAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.grdSupervisiones = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.tbSocias = New System.Windows.Forms.ToolStrip()
        CType(Me.grdSupervisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbSocias.SuspendLayout()
        Me.SuspendLayout()
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.Location = New System.Drawing.Point(211, 2)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(745, 25)
        Me.miniToolStrip.Stretch = True
        Me.miniToolStrip.TabIndex = 12
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
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregar.Text = "Agregar"
        '
        'toolEditar
        '
        Me.toolEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEditar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEditar.Name = "toolEditar"
        Me.toolEditar.Size = New System.Drawing.Size(23, 20)
        Me.toolEditar.Text = "Editar"
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 20)
        Me.toolAnular.Text = "Anular"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 23)
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 20)
        Me.toolImprimir.Text = "Listado de Socias con Referencias"
        Me.toolImprimir.ToolTipText = "Listado de Socias con Referencias"
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
        'grdSupervisiones
        '
        Me.grdSupervisiones.AllowFilter = False
        Me.grdSupervisiones.AllowUpdate = False
        Me.grdSupervisiones.Caption = "Listado de Socias"
        Me.grdSupervisiones.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSupervisiones.FilterBar = True
        Me.grdSupervisiones.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSupervisiones.Images.Add(CType(resources.GetObject("grdSupervisiones.Images"), System.Drawing.Image))
        Me.grdSupervisiones.Location = New System.Drawing.Point(4, 31)
        Me.grdSupervisiones.Name = "grdSupervisiones"
        Me.grdSupervisiones.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSupervisiones.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSupervisiones.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSupervisiones.PrintInfo.PageSettings = CType(resources.GetObject("grdSupervisiones.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSupervisiones.Size = New System.Drawing.Size(737, 397)
        Me.grdSupervisiones.TabIndex = 13
        Me.grdSupervisiones.Text = "grdDocSoporte"
        Me.grdSupervisiones.PropBag = resources.GetString("grdSupervisiones.PropBag")
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdSupervisiones)
        Me.C1Sizer1.Controls.Add(Me.tbSocias)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(745, 440)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbSocias
        '
        Me.tbSocias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.toolAgregar, Me.toolEditar, Me.toolAnular, Me.ToolStripButton7, Me.toolImprimir, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbSocias.Location = New System.Drawing.Point(4, 4)
        Me.tbSocias.Name = "tbSocias"
        Me.tbSocias.Size = New System.Drawing.Size(737, 23)
        Me.tbSocias.Stretch = True
        Me.tbSocias.TabIndex = 12
        Me.tbSocias.Text = "ToolStrip1"
        '
        'frmSclSupervision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 440)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Central de Riesgo")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclSupervision"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento de Supervisiones"
        CType(Me.grdSupervisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbSocias.ResumeLayout(False)
        Me.tbSocias.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents miniToolStrip As ToolStrip
    Friend WithEvents toolBuscar As ToolStripButton
    Friend WithEvents toolAgregar As ToolStripButton
    Friend WithEvents toolEditar As ToolStripButton
    Friend WithEvents toolAnular As ToolStripButton
    Friend WithEvents ToolStripButton7 As ToolStripSeparator
    Friend WithEvents toolImprimir As ToolStripButton
    Friend WithEvents toolSeparator3 As ToolStripSeparator
    Friend WithEvents toolAyuda As ToolStripButton
    Friend WithEvents toolSalir As ToolStripButton
    Friend WithEvents grdSupervisiones As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbSocias As ToolStrip
End Class
