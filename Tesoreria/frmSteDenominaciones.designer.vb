<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteDenominaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteDenominaciones))
        Me.tbDenominaciones = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.grdDenominaciones = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.tbDenominaciones.SuspendLayout()
        CType(Me.grdDenominaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbDenominaciones
        '
        Me.tbDenominaciones.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.ToolStripSeparator2, Me.toolAyuda, Me.toolCerrar})
        Me.tbDenominaciones.Location = New System.Drawing.Point(0, 0)
        Me.tbDenominaciones.Name = "tbDenominaciones"
        Me.tbDenominaciones.Size = New System.Drawing.Size(558, 25)
        Me.tbDenominaciones.Stretch = True
        Me.tbDenominaciones.TabIndex = 7
        Me.tbDenominaciones.Text = "ToolStrip1"
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
        Me.toolEliminar.ToolTipText = "Eliminar"
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
        Me.toolImprimir.Text = "Imprimir"
        Me.toolImprimir.ToolTipText = "Imprimir"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'grdDenominaciones
        '
        Me.grdDenominaciones.AllowFilter = False
        Me.grdDenominaciones.AllowUpdate = False
        Me.grdDenominaciones.Caption = "Listado de Denominaciones"
        Me.grdDenominaciones.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDenominaciones.FilterBar = True
        Me.grdDenominaciones.GroupByCaption = "Arrastre aqu� una columna para agrupar"
        Me.grdDenominaciones.Images.Add(CType(resources.GetObject("grdDenominaciones.Images"), System.Drawing.Image))
        Me.grdDenominaciones.Location = New System.Drawing.Point(0, 25)
        Me.grdDenominaciones.Name = "grdDenominaciones"
        Me.grdDenominaciones.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDenominaciones.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDenominaciones.PreviewInfo.ZoomFactor = 75
        Me.grdDenominaciones.PrintInfo.PageSettings = CType(resources.GetObject("grdDenominaciones.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDenominaciones.Size = New System.Drawing.Size(558, 316)
        Me.grdDenominaciones.TabIndex = 8
        Me.grdDenominaciones.Text = "grdDenominaciones"
        Me.grdDenominaciones.PropBag = resources.GetString("grdDenominaciones.PropBag")
        '
        'frmSteDenominaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 341)
        Me.Controls.Add(Me.grdDenominaciones)
        Me.Controls.Add(Me.tbDenominaciones)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Denominaciones")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSteDenominaciones"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Registro de Denominaciones"
        Me.tbDenominaciones.ResumeLayout(False)
        Me.tbDenominaciones.PerformLayout()
        CType(Me.grdDenominaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdDenominaciones As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbDenominaciones As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
