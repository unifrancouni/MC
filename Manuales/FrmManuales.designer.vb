<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmManuales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmManuales))
        Me.toolManuales = New System.Windows.Forms.ToolStrip
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grdManHijos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdManuales = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.toolManuales.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.grdManHijos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdManuales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolManuales
        '
        Me.toolManuales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolRefrescar, Me.ToolStripButton2, Me.toolCerrar})
        Me.toolManuales.Location = New System.Drawing.Point(0, 0)
        Me.toolManuales.Name = "toolManuales"
        Me.toolManuales.Size = New System.Drawing.Size(525, 25)
        Me.toolManuales.Stretch = True
        Me.toolManuales.TabIndex = 19
        Me.toolManuales.Text = "ToolStrip1"
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(6, 25)
        '
        'toolCerrar
        '
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrar.Text = "Salir"
        Me.toolCerrar.ToolTipText = "Salir"
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdManHijos)
        Me.C1Sizer1.Controls.Add(Me.grdManuales)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = "97.9381443298969:False:False;" & Global.Microsoft.VisualBasic.ChrW(9) & "28.5714285714286:False:False;69.1428571428571:False" & _
            ":False;"
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 25)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(525, 388)
        Me.C1Sizer1.TabIndex = 20
        Me.C1Sizer1.TabStop = False
        '
        'grdManHijos
        '
        Me.grdManHijos.AllowArrows = False
        Me.grdManHijos.AllowColMove = False
        Me.grdManHijos.AllowUpdate = False
        Me.grdManHijos.AllowUpdateOnBlur = False
        Me.grdManHijos.Caption = "Listado de Archivos del Manual Actual"
        Me.grdManHijos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdManHijos.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdManHijos.Images.Add(CType(resources.GetObject("grdManHijos.Images"), System.Drawing.Image))
        Me.grdManHijos.Location = New System.Drawing.Point(158, 4)
        Me.grdManHijos.Name = "grdManHijos"
        Me.grdManHijos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdManHijos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdManHijos.PreviewInfo.ZoomFactor = 75
        Me.grdManHijos.PrintInfo.PageSettings = CType(resources.GetObject("grdManHijos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdManHijos.Size = New System.Drawing.Size(363, 380)
        Me.grdManHijos.TabIndex = 20
        Me.grdManHijos.PropBag = resources.GetString("grdManHijos.PropBag")
        '
        'grdManuales
        '
        Me.grdManuales.AllowArrows = False
        Me.grdManuales.AllowColMove = False
        Me.grdManuales.AllowUpdate = False
        Me.grdManuales.AllowUpdateOnBlur = False
        Me.grdManuales.Caption = "Listado de Manuales"
        Me.grdManuales.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdManuales.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdManuales.Images.Add(CType(resources.GetObject("grdManuales.Images"), System.Drawing.Image))
        Me.grdManuales.Location = New System.Drawing.Point(4, 4)
        Me.grdManuales.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.grdManuales.Name = "grdManuales"
        Me.grdManuales.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdManuales.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdManuales.PreviewInfo.ZoomFactor = 75
        Me.grdManuales.PrintInfo.PageSettings = CType(resources.GetObject("grdManuales.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdManuales.Size = New System.Drawing.Size(150, 380)
        Me.grdManuales.TabIndex = 19
        Me.grdManuales.Text = "C1TrueDBGrid1"
        Me.grdManuales.PropBag = resources.GetString("grdManuales.PropBag")
        '
        'FrmManuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 413)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Controls.Add(Me.toolManuales)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmManuales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Manuales SMUSURA0"
        Me.toolManuales.ResumeLayout(False)
        Me.toolManuales.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        CType(Me.grdManHijos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdManuales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolManuales As System.Windows.Forms.ToolStrip
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents grdManHijos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdManuales As C1.Win.C1TrueDBGrid.C1TrueDBGrid

End Class
