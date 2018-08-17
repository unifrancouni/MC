<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclCambioGrupoSolidario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclCambioGrupoSolidario))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.tbSocia = New System.Windows.Forms.ToolStrip
        Me.toolCambiarGS = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaS = New System.Windows.Forms.ToolStripButton
        Me.grdSocias = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdGS = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbGrupoSolidario = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbSocia.SuspendLayout()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbGrupoSolidario.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.tbSocia)
        Me.C1Sizer1.Controls.Add(Me.grdSocias)
        Me.C1Sizer1.Controls.Add(Me.grdGS)
        Me.C1Sizer1.Controls.Add(Me.tbGrupoSolidario)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(664, 435)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbSocia
        '
        Me.tbSocia.AutoSize = False
        Me.tbSocia.Dock = System.Windows.Forms.DockStyle.None
        Me.tbSocia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolCambiarGS, Me.toolSeparator2, Me.toolAyudaS})
        Me.tbSocia.Location = New System.Drawing.Point(4, 222)
        Me.tbSocia.Name = "tbSocia"
        Me.tbSocia.Size = New System.Drawing.Size(164, 23)
        Me.tbSocia.Stretch = True
        Me.tbSocia.TabIndex = 15
        Me.tbSocia.Text = "ToolStrip1"
        '
        'toolCambiarGS
        '
        Me.toolCambiarGS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCambiarGS.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolCambiarGS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCambiarGS.Name = "toolCambiarGS"
        Me.toolCambiarGS.Size = New System.Drawing.Size(23, 20)
        Me.toolCambiarGS.Text = "Cambiar Grupo Solidario"
        Me.toolCambiarGS.ToolTipText = "Cambiar Grupo Solidario"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolAyudaS
        '
        Me.toolAyudaS.AutoSize = False
        Me.toolAyudaS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaS.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaS.Name = "toolAyudaS"
        Me.toolAyudaS.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaS.Text = "Ayuda"
        Me.toolAyudaS.ToolTipText = "Ayuda"
        '
        'grdSocias
        '
        Me.grdSocias.AllowFilter = False
        Me.grdSocias.AllowUpdate = False
        Me.grdSocias.Caption = "Listado de Socias del Grupo con Fichas de Inscripción"
        Me.grdSocias.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSocias.FilterBar = True
        Me.grdSocias.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSocias.Images.Add(CType(resources.GetObject("grdSocias.Images"), System.Drawing.Image))
        Me.grdSocias.Location = New System.Drawing.Point(4, 249)
        Me.grdSocias.Name = "grdSocias"
        Me.grdSocias.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSocias.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSocias.PreviewInfo.ZoomFactor = 75
        Me.grdSocias.PrintInfo.PageSettings = CType(resources.GetObject("grdSocias.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocias.Size = New System.Drawing.Size(656, 182)
        Me.grdSocias.TabIndex = 14
        Me.grdSocias.Text = "grdModulo"
        Me.grdSocias.PropBag = resources.GetString("grdSocias.PropBag")
        '
        'grdGS
        '
        Me.grdGS.AllowFilter = False
        Me.grdGS.AllowUpdate = False
        Me.grdGS.Caption = "Listado de Grupos Solidarios En Proceso"
        Me.grdGS.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdGS.FilterBar = True
        Me.grdGS.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdGS.Images.Add(CType(resources.GetObject("grdGS.Images"), System.Drawing.Image))
        Me.grdGS.Location = New System.Drawing.Point(4, 27)
        Me.grdGS.Name = "grdGS"
        Me.grdGS.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdGS.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdGS.PreviewInfo.ZoomFactor = 75
        Me.grdGS.PrintInfo.PageSettings = CType(resources.GetObject("grdGS.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdGS.Size = New System.Drawing.Size(656, 191)
        Me.grdGS.TabIndex = 13
        Me.grdGS.Text = "grdDocSoporte"
        Me.grdGS.PropBag = resources.GetString("grdGS.PropBag")
        '
        'tbGrupoSolidario
        '
        Me.tbGrupoSolidario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton7, Me.toolRefrescar, Me.toolSeparator1, Me.toolAyuda, Me.toolSalir})
        Me.tbGrupoSolidario.Location = New System.Drawing.Point(0, 0)
        Me.tbGrupoSolidario.Name = "tbGrupoSolidario"
        Me.tbGrupoSolidario.Size = New System.Drawing.Size(664, 25)
        Me.tbGrupoSolidario.Stretch = True
        Me.tbGrupoSolidario.TabIndex = 12
        Me.tbGrupoSolidario.Text = "ToolStrip1"
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
        'frmSclCambioGrupoSolidario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 435)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Cambio de Grupo Solidario")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclCambioGrupoSolidario"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Cambio de Grupo Solidario a Socia"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbSocia.ResumeLayout(False)
        Me.tbSocia.PerformLayout()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbGrupoSolidario.ResumeLayout(False)
        Me.tbGrupoSolidario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbSocia As System.Windows.Forms.ToolStrip
    Friend WithEvents toolCambiarGS As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaS As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdSocias As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdGS As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbGrupoSolidario As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
