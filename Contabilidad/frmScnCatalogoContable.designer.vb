<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnCatalogoContable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnCatalogoContable))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grdCatContable = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbCatContable = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolAgregarNiveln = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.grdCatContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCatContable.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdCatContable)
        Me.C1Sizer1.Controls.Add(Me.tbCatContable)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(677, 438)
        Me.C1Sizer1.TabIndex = 0
        Me.C1Sizer1.TabStop = False
        '
        'grdCatContable
        '
        Me.grdCatContable.AllowFilter = False
        Me.grdCatContable.AllowUpdate = False
        Me.grdCatContable.Caption = "Listado de Cuentas del Catálogo Contable"
        Me.grdCatContable.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdCatContable.FilterBar = True
        Me.grdCatContable.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdCatContable.Images.Add(CType(resources.GetObject("grdCatContable.Images"), System.Drawing.Image))
        Me.grdCatContable.Location = New System.Drawing.Point(4, 28)
        Me.grdCatContable.Name = "grdCatContable"
        Me.grdCatContable.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCatContable.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCatContable.PreviewInfo.ZoomFactor = 75
        Me.grdCatContable.PrintInfo.PageSettings = CType(resources.GetObject("grdCatContable.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCatContable.Size = New System.Drawing.Size(669, 406)
        Me.grdCatContable.TabIndex = 13
        Me.grdCatContable.Text = "grdCatContable"
        Me.grdCatContable.PropBag = resources.GetString("grdCatContable.PropBag")
        '
        'tbCatContable
        '
        Me.tbCatContable.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolAgregarNiveln, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolRefrescar, Me.ToolStripSeparator1, Me.ToolImprimir, Me.ToolStripSeparator3, Me.toolAyuda, Me.toolCerrar})
        Me.tbCatContable.Location = New System.Drawing.Point(0, 0)
        Me.tbCatContable.Name = "tbCatContable"
        Me.tbCatContable.Size = New System.Drawing.Size(677, 25)
        Me.tbCatContable.Stretch = True
        Me.tbCatContable.TabIndex = 12
        Me.tbCatContable.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar Cuenta Primer Nivel"
        '
        'toolAgregarNiveln
        '
        Me.toolAgregarNiveln.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarNiveln.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.toolAgregarNiveln.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregarNiveln.Name = "toolAgregarNiveln"
        Me.toolAgregarNiveln.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarNiveln.Text = "ToolStripButton1"
        Me.toolAgregarNiveln.ToolTipText = "Agregar Cuenta Nivel n"
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
        'ToolImprimir
        '
        Me.ToolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.ToolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolImprimir.Name = "ToolImprimir"
        Me.ToolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.ToolImprimir.Text = "ToolStripButton1"
        Me.ToolImprimir.ToolTipText = "Imprimir"
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
        'frmScnCatalogoContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 438)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Catálogo Contable")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmScnCatalogoContable"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento Catálogo Contable"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        CType(Me.grdCatContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCatContable.ResumeLayout(False)
        Me.tbCatContable.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbCatContable As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdCatContable As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ToolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAgregarNiveln As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
