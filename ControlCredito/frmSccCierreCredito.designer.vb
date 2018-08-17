<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccCierreCredito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccCierreCredito))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.grdCierres = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbEjercicio = New System.Windows.Forms.ToolStrip()
        Me.toolAgregarCierre = New System.Windows.Forms.ToolStripButton()
        Me.toolGenerarCierre = New System.Windows.Forms.ToolStripButton()
        Me.toolConfirmarCierre = New System.Windows.Forms.ToolStripButton()
        Me.toolAnularCierre = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.grdCierres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbEjercicio.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdCierres)
        Me.C1Sizer1.Controls.Add(Me.tbEjercicio)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(885, 535)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'grdCierres
        '
        Me.grdCierres.AllowFilter = False
        Me.grdCierres.AllowUpdate = False
        Me.grdCierres.Caption = "Listado de cierres de cartera"
        Me.grdCierres.FilterBar = True
        Me.grdCierres.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.grdCierres.GroupByAreaVisible = False
        Me.grdCierres.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdCierres.Images.Add(CType(resources.GetObject("grdCierres.Images"), System.Drawing.Image))
        Me.grdCierres.Location = New System.Drawing.Point(4, 27)
        Me.grdCierres.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grdCierres.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.grdCierres.Name = "grdCierres"
        Me.grdCierres.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCierres.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCierres.PreviewInfo.ZoomFactor = 75.0R
        Me.grdCierres.PrintInfo.PageSettings = CType(resources.GetObject("grdCierres.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCierres.Size = New System.Drawing.Size(877, 504)
        Me.grdCierres.TabIndex = 13
        Me.grdCierres.Text = "grdDocSoporte"
        Me.grdCierres.PropBag = resources.GetString("grdCierres.PropBag")
        '
        'tbEjercicio
        '
        Me.tbEjercicio.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tbEjercicio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarCierre, Me.toolGenerarCierre, Me.toolConfirmarCierre, Me.toolAnularCierre, Me.ToolStripButton7, Me.toolRefrescar, Me.toolSeparator1, Me.toolImprimir, Me.toolSeparator3, Me.toolSalir})
        Me.tbEjercicio.Location = New System.Drawing.Point(4, 4)
        Me.tbEjercicio.Name = "tbEjercicio"
        Me.tbEjercicio.Size = New System.Drawing.Size(877, 19)
        Me.tbEjercicio.Stretch = True
        Me.tbEjercicio.TabIndex = 12
        Me.tbEjercicio.Text = "ToolStrip1"
        '
        'toolAgregarCierre
        '
        Me.toolAgregarCierre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarCierre.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarCierre.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarCierre.Name = "toolAgregarCierre"
        Me.toolAgregarCierre.Size = New System.Drawing.Size(24, 16)
        Me.toolAgregarCierre.Text = "Agregar Cierre"
        Me.toolAgregarCierre.ToolTipText = "Agregar Cierre"
        '
        'toolGenerarCierre
        '
        Me.toolGenerarCierre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerarCierre.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolGenerarCierre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerarCierre.Name = "toolGenerarCierre"
        Me.toolGenerarCierre.Size = New System.Drawing.Size(24, 16)
        Me.toolGenerarCierre.Text = "Generar Cierre"
        Me.toolGenerarCierre.ToolTipText = "Generar Cierre"
        '
        'toolConfirmarCierre
        '
        Me.toolConfirmarCierre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolConfirmarCierre.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolConfirmarCierre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolConfirmarCierre.Name = "toolConfirmarCierre"
        Me.toolConfirmarCierre.Size = New System.Drawing.Size(24, 16)
        Me.toolConfirmarCierre.Text = "Confirmar Cierre"
        '
        'toolAnularCierre
        '
        Me.toolAnularCierre.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnularCierre.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnularCierre.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAnularCierre.Name = "toolAnularCierre"
        Me.toolAnularCierre.Size = New System.Drawing.Size(24, 16)
        Me.toolAnularCierre.Text = "Anular cierre"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 19)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(24, 16)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(6, 19)
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(24, 16)
        Me.toolImprimir.Text = "Imprimir"
        Me.toolImprimir.ToolTipText = "Imprimir"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(6, 19)
        '
        'toolSalir
        '
        Me.toolSalir.BackColor = System.Drawing.Color.Transparent
        Me.toolSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSalir.Name = "toolSalir"
        Me.toolSalir.Size = New System.Drawing.Size(24, 16)
        Me.toolSalir.Text = "Salir"
        Me.toolSalir.ToolTipText = "Salir"
        '
        'frmSccCierreCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 535)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmSccCierreCredito"
        Me.Text = "Generar períodos crédito"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        CType(Me.grdCierres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbEjercicio.ResumeLayout(False)
        Me.tbEjercicio.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents grdCierres As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbEjercicio As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarCierre As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolGenerarCierre As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnularCierre As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As ToolStripSeparator
    Friend WithEvents toolConfirmarCierre As ToolStripButton
End Class
