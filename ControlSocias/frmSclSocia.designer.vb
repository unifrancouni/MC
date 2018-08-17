<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclSocia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclSocia))
        Me.tbSocia = New System.Windows.Forms.ToolStrip
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolInactivar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolConyuge = New System.Windows.Forms.ToolStripButton
        Me.toolCambiarDelegacion = New System.Windows.Forms.ToolStripButton
        Me.toolCreditoIndividual = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripSplitButton
        Me.toolImprimirSocia = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirDatosSocia = New System.Windows.Forms.ToolStripMenuItem
        Me.toolHistorial = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolfichaunica = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grdSocia = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.tbSocia.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.grdSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbSocia
        '
        Me.tbSocia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.ToolStripSeparator4, Me.toolAgregar, Me.toolModificar, Me.toolInactivar, Me.ToolStripButton7, Me.toolConyuge, Me.toolCambiarDelegacion, Me.toolCreditoIndividual, Me.ToolStripSeparator3, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.toolHistorial, Me.ToolStripSeparator2, Me.toolAyuda, Me.toolfichaunica, Me.toolCerrar})
        Me.tbSocia.Location = New System.Drawing.Point(0, 0)
        Me.tbSocia.Name = "tbSocia"
        Me.tbSocia.Size = New System.Drawing.Size(675, 25)
        Me.tbSocia.Stretch = True
        Me.tbSocia.TabIndex = 7
        Me.tbSocia.Text = "ToolStrip1"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 22)
        Me.toolBuscar.Text = "Buscar Socias"
        Me.toolBuscar.ToolTipText = "Buscar Socias"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'toolInactivar
        '
        Me.toolInactivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolInactivar.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolInactivar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolInactivar.Name = "toolInactivar"
        Me.toolInactivar.Size = New System.Drawing.Size(23, 22)
        Me.toolInactivar.Text = "Inactivar"
        Me.toolInactivar.ToolTipText = "Inactivar"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'toolConyuge
        '
        Me.toolConyuge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolConyuge.Image = Global.SMUSURA0.My.Resources.Resources.Beneficiario16
        Me.toolConyuge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolConyuge.Name = "toolConyuge"
        Me.toolConyuge.Size = New System.Drawing.Size(23, 22)
        Me.toolConyuge.Text = "Cónyuge"
        '
        'toolCambiarDelegacion
        '
        Me.toolCambiarDelegacion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCambiarDelegacion.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolCambiarDelegacion.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCambiarDelegacion.Name = "toolCambiarDelegacion"
        Me.toolCambiarDelegacion.Size = New System.Drawing.Size(23, 22)
        Me.toolCambiarDelegacion.Text = "Traslado de Delegación"
        '
        'toolCreditoIndividual
        '
        Me.toolCreditoIndividual.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCreditoIndividual.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.toolCreditoIndividual.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCreditoIndividual.Name = "toolCreditoIndividual"
        Me.toolCreditoIndividual.Size = New System.Drawing.Size(23, 22)
        Me.toolCreditoIndividual.Text = "Crear Grupo Solidario para Crédito Individual"
        Me.toolCreditoIndividual.ToolTipText = "Crear Grupo Solidario para Crédito Individual"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        Me.toolImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimirSocia, Me.toolImprimirDatosSocia})
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(32, 22)
        Me.toolImprimir.Text = "Imprimir"
        Me.toolImprimir.ToolTipText = "Imprimir"
        '
        'toolImprimirSocia
        '
        Me.toolImprimirSocia.Name = "toolImprimirSocia"
        Me.toolImprimirSocia.Size = New System.Drawing.Size(174, 22)
        Me.toolImprimirSocia.Text = "Listado Socias CS8"
        '
        'toolImprimirDatosSocia
        '
        Me.toolImprimirDatosSocia.Name = "toolImprimirDatosSocia"
        Me.toolImprimirDatosSocia.Size = New System.Drawing.Size(174, 22)
        Me.toolImprimirDatosSocia.Text = "Datos Socia CS23"
        '
        'toolHistorial
        '
        Me.toolHistorial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolHistorial.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.toolHistorial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolHistorial.Name = "toolHistorial"
        Me.toolHistorial.Size = New System.Drawing.Size(23, 22)
        Me.toolHistorial.Text = "Historial "
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
        'toolfichaunica
        '
        Me.toolfichaunica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolfichaunica.Image = Global.SMUSURA0.My.Resources.Resources.kate
        Me.toolfichaunica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolfichaunica.Name = "toolfichaunica"
        Me.toolfichaunica.Size = New System.Drawing.Size(23, 22)
        Me.toolfichaunica.Text = "Ficha Unica"
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
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdSocia)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 25)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(675, 470)
        Me.C1Sizer1.TabIndex = 19
        Me.C1Sizer1.TabStop = False
        '
        'grdSocia
        '
        Me.grdSocia.AllowFilter = False
        Me.grdSocia.AllowUpdate = False
        Me.grdSocia.Caption = "Listado de Socias"
        Me.grdSocia.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSocia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdSocia.FilterBar = True
        Me.grdSocia.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSocia.Images.Add(CType(resources.GetObject("grdSocia.Images"), System.Drawing.Image))
        Me.grdSocia.Location = New System.Drawing.Point(0, 0)
        Me.grdSocia.Name = "grdSocia"
        Me.grdSocia.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSocia.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSocia.PreviewInfo.ZoomFactor = 75
        Me.grdSocia.PrintInfo.PageSettings = CType(resources.GetObject("grdSocia.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocia.Size = New System.Drawing.Size(675, 470)
        Me.grdSocia.TabIndex = 8
        Me.grdSocia.Text = "grdClientes"
        Me.grdSocia.PropBag = resources.GetString("grdSocia.PropBag")
        '
        'frmSclSocia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 495)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Controls.Add(Me.tbSocia)
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclSocia"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Registro de Socias"
        Me.tbSocia.ResumeLayout(False)
        Me.tbSocia.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        CType(Me.grdSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdSocia As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbSocia As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolInactivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolImprimirSocia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirDatosSocia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolCambiarDelegacion As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolCreditoIndividual As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolHistorial As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolfichaunica As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolConyuge As System.Windows.Forms.ToolStripButton
End Class
