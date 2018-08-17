<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbPersona
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbPersona))
        Me.tbPersona = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolConvertirEmpleado = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.grdPersonas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.toolFirma = New System.Windows.Forms.ToolStripButton
        Me.tbPersona.SuspendLayout()
        CType(Me.grdPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbPersona
        '
        Me.tbPersona.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolFirma, Me.toolEliminar, Me.toolConvertirEmpleado, Me.ToolStripButton7, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.ToolStripSeparator2, Me.toolAyuda, Me.toolCerrar})
        Me.tbPersona.Location = New System.Drawing.Point(0, 0)
        Me.tbPersona.Name = "tbPersona"
        Me.tbPersona.Size = New System.Drawing.Size(558, 25)
        Me.tbPersona.Stretch = True
        Me.tbPersona.TabIndex = 7
        Me.tbPersona.Text = "ToolStrip1"
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
        Me.toolEliminar.Text = "Inactivar"
        Me.toolEliminar.ToolTipText = "Eliminar"
        '
        'toolConvertirEmpleado
        '
        Me.toolConvertirEmpleado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolConvertirEmpleado.Image = Global.SMUSURA0.My.Resources.Resources.AprobarPartida16
        Me.toolConvertirEmpleado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolConvertirEmpleado.Name = "toolConvertirEmpleado"
        Me.toolConvertirEmpleado.Size = New System.Drawing.Size(23, 22)
        Me.toolConvertirEmpleado.Text = "Convertir a Empleado"
        Me.toolConvertirEmpleado.ToolTipText = "Convertir a Empleado"
        Me.toolConvertirEmpleado.Visible = False
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
        'grdPersonas
        '
        Me.grdPersonas.AllowFilter = False
        Me.grdPersonas.AllowUpdate = False
        Me.grdPersonas.Caption = "Listado de Personas"
        Me.grdPersonas.CaptionHeight = 18
        Me.grdPersonas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdPersonas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPersonas.FilterBar = True
        Me.grdPersonas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdPersonas.Images.Add(CType(resources.GetObject("grdPersonas.Images"), System.Drawing.Image))
        Me.grdPersonas.Location = New System.Drawing.Point(0, 25)
        Me.grdPersonas.Name = "grdPersonas"
        Me.grdPersonas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPersonas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPersonas.PreviewInfo.ZoomFactor = 75
        Me.grdPersonas.PrintInfo.PageSettings = CType(resources.GetObject("grdPersonas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdPersonas.Size = New System.Drawing.Size(558, 316)
        Me.grdPersonas.TabIndex = 8
        Me.grdPersonas.Text = "grdClientes"
        Me.grdPersonas.PropBag = resources.GetString("grdPersonas.PropBag")
        '
        'toolFirma
        '
        Me.toolFirma.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolFirma.Image = Global.SMUSURA0.My.Resources.Resources.xedit
        Me.toolFirma.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolFirma.Name = "toolFirma"
        Me.toolFirma.Size = New System.Drawing.Size(23, 22)
        Me.toolFirma.Text = "Firma"
        '
        'frmStbPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 341)
        Me.Controls.Add(Me.grdPersonas)
        Me.Controls.Add(Me.tbPersona)
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStbPersona"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Registro Personas"
        Me.tbPersona.ResumeLayout(False)
        Me.tbPersona.PerformLayout()
        CType(Me.grdPersonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdPersonas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbPersona As System.Windows.Forms.ToolStrip
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
    Friend WithEvents toolConvertirEmpleado As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolFirma As System.Windows.Forms.ToolStripButton
End Class
