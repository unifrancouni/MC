<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccReciboCajaAutomatico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccReciboCajaAutomatico))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.tbRecibo = New System.Windows.Forms.ToolStrip
        Me.toolAgregarAutomatico = New System.Windows.Forms.ToolStripButton
        Me.toolModificarAutomatico = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarAutomatico = New System.Windows.Forms.ToolStripButton
        Me.toolSeparadorAutomatico = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarM = New System.Windows.Forms.ToolStripButton
        Me.toolImprimirM = New System.Windows.Forms.ToolStripButton
        Me.grdRecibo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdSocia = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbSocia = New System.Windows.Forms.ToolStrip
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton
        Me.toolCorteTrasladoValores = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimirListado = New System.Windows.Forms.ToolStripDropDownButton
        Me.toolReporteCC45 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolReporteCC44 = New System.Windows.Forms.ToolStripMenuItem
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolArqueo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbRecibo.SuspendLayout()
        CType(Me.grdRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSocia.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.tbRecibo)
        Me.C1Sizer1.Controls.Add(Me.grdRecibo)
        Me.C1Sizer1.Controls.Add(Me.grdSocia)
        Me.C1Sizer1.Controls.Add(Me.tbSocia)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(674, 403)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbRecibo
        '
        Me.tbRecibo.AutoSize = False
        Me.tbRecibo.Dock = System.Windows.Forms.DockStyle.None
        Me.tbRecibo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarAutomatico, Me.toolModificarAutomatico, Me.toolEliminarAutomatico, Me.toolSeparadorAutomatico, Me.toolRefrescarM, Me.toolImprimirM})
        Me.tbRecibo.Location = New System.Drawing.Point(4, 212)
        Me.tbRecibo.Name = "tbRecibo"
        Me.tbRecibo.Size = New System.Drawing.Size(289, 25)
        Me.tbRecibo.Stretch = True
        Me.tbRecibo.TabIndex = 15
        Me.tbRecibo.Text = "ToolStrip1"
        '
        'toolAgregarAutomatico
        '
        Me.toolAgregarAutomatico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarAutomatico.Image = Global.SMUSURA0.My.Resources.Resources.bookmark
        Me.toolAgregarAutomatico.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregarAutomatico.Name = "toolAgregarAutomatico"
        Me.toolAgregarAutomatico.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarAutomatico.Text = "Agregar Recibo Automático"
        '
        'toolModificarAutomatico
        '
        Me.toolModificarAutomatico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarAutomatico.Image = Global.SMUSURA0.My.Resources.Resources.configure
        Me.toolModificarAutomatico.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarAutomatico.Name = "toolModificarAutomatico"
        Me.toolModificarAutomatico.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarAutomatico.Text = "Consultar Recibo Automático"
        '
        'toolEliminarAutomatico
        '
        Me.toolEliminarAutomatico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarAutomatico.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.toolEliminarAutomatico.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEliminarAutomatico.Name = "toolEliminarAutomatico"
        Me.toolEliminarAutomatico.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarAutomatico.Text = "ToolStripButton1"
        Me.toolEliminarAutomatico.ToolTipText = "Anular Recibo Automático"
        '
        'toolSeparadorAutomatico
        '
        Me.toolSeparadorAutomatico.Name = "toolSeparadorAutomatico"
        Me.toolSeparadorAutomatico.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarM
        '
        Me.toolRefrescarM.AutoSize = False
        Me.toolRefrescarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarM.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRefrescarM.Name = "toolRefrescarM"
        Me.toolRefrescarM.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarM.Text = "Refrescar"
        Me.toolRefrescarM.ToolTipText = "Refrescar"
        '
        'toolImprimirM
        '
        Me.toolImprimirM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirM.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirM.Name = "toolImprimirM"
        Me.toolImprimirM.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirM.Text = "ToolStripButton1"
        Me.toolImprimirM.ToolTipText = "Imprimir Recibo"
        '
        'grdRecibo
        '
        Me.grdRecibo.AllowFilter = False
        Me.grdRecibo.AllowUpdate = False
        Me.grdRecibo.Caption = "Listado de Recibos"
        Me.grdRecibo.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdRecibo.FilterBar = True
        Me.grdRecibo.GroupByAreaVisible = False
        Me.grdRecibo.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdRecibo.Images.Add(CType(resources.GetObject("grdRecibo.Images"), System.Drawing.Image))
        Me.grdRecibo.Location = New System.Drawing.Point(4, 241)
        Me.grdRecibo.Name = "grdRecibo"
        Me.grdRecibo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdRecibo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdRecibo.PreviewInfo.ZoomFactor = 75
        Me.grdRecibo.PrintInfo.PageSettings = CType(resources.GetObject("grdRecibo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdRecibo.Size = New System.Drawing.Size(666, 158)
        Me.grdRecibo.TabIndex = 14
        Me.grdRecibo.Text = "grdModulo"
        Me.grdRecibo.PropBag = resources.GetString("grdRecibo.PropBag")
        '
        'grdSocia
        '
        Me.grdSocia.AllowFilter = False
        Me.grdSocia.AllowUpdate = False
        Me.grdSocia.Caption = "Listado de Socias"
        Me.grdSocia.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSocia.FilterBar = True
        Me.grdSocia.GroupByAreaVisible = False
        Me.grdSocia.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSocia.Images.Add(CType(resources.GetObject("grdSocia.Images"), System.Drawing.Image))
        Me.grdSocia.Location = New System.Drawing.Point(4, 30)
        Me.grdSocia.Name = "grdSocia"
        Me.grdSocia.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSocia.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSocia.PreviewInfo.ZoomFactor = 75
        Me.grdSocia.PrintInfo.PageSettings = CType(resources.GetObject("grdSocia.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocia.Size = New System.Drawing.Size(666, 178)
        Me.grdSocia.TabIndex = 13
        Me.grdSocia.Text = "grdSocia"
        Me.grdSocia.PropBag = resources.GetString("grdSocia.PropBag")
        '
        'tbSocia
        '
        Me.tbSocia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.toolCorteTrasladoValores, Me.toolArqueo, Me.toolSeparador1, Me.toolImprimirListado, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolAyuda, Me.toolCerrar})
        Me.tbSocia.Location = New System.Drawing.Point(0, 0)
        Me.tbSocia.Name = "tbSocia"
        Me.tbSocia.Size = New System.Drawing.Size(674, 25)
        Me.tbSocia.Stretch = True
        Me.tbSocia.TabIndex = 12
        Me.tbSocia.Text = "ToolStrip1"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 22)
        Me.toolBuscar.Text = "Buscar"
        Me.toolBuscar.ToolTipText = "Buscar"
        '
        'toolCorteTrasladoValores
        '
        Me.toolCorteTrasladoValores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCorteTrasladoValores.Image = Global.SMUSURA0.My.Resources.Resources.editcut
        Me.toolCorteTrasladoValores.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCorteTrasladoValores.Name = "toolCorteTrasladoValores"
        Me.toolCorteTrasladoValores.Size = New System.Drawing.Size(23, 22)
        Me.toolCorteTrasladoValores.Text = "ToolStripButton1"
        Me.toolCorteTrasladoValores.ToolTipText = "Corte X Traslado de Valores"
        '
        'toolSeparador1
        '
        Me.toolSeparador1.Name = "toolSeparador1"
        Me.toolSeparador1.Size = New System.Drawing.Size(6, 25)
        '
        'toolImprimirListado
        '
        Me.toolImprimirListado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirListado.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolReporteCC45, Me.toolReporteCC44})
        Me.toolImprimirListado.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirListado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirListado.Name = "toolImprimirListado"
        Me.toolImprimirListado.Size = New System.Drawing.Size(29, 22)
        Me.toolImprimirListado.Text = "ToolStripButton1"
        Me.toolImprimirListado.ToolTipText = "Imprimir Listados"
        '
        'toolReporteCC45
        '
        Me.toolReporteCC45.Name = "toolReporteCC45"
        Me.toolReporteCC45.Size = New System.Drawing.Size(272, 22)
        Me.toolReporteCC45.Text = "Arqueo Detalle Documentos CC45"
        '
        'toolReporteCC44
        '
        Me.toolReporteCC44.Name = "toolReporteCC44"
        Me.toolReporteCC44.Size = New System.Drawing.Size(272, 22)
        Me.toolReporteCC44.Text = "Arqueo Consolidado Documentos CC44"
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
        'toolArqueo
        '
        Me.toolArqueo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolArqueo.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.toolArqueo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolArqueo.Name = "toolArqueo"
        Me.toolArqueo.Size = New System.Drawing.Size(23, 22)
        Me.toolArqueo.Text = "Arqueo"
        Me.toolArqueo.ToolTipText = "Arqueo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'frmSccReciboCajaAutomatico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 403)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Recibo Oficial de Caja Automático")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSccReciboCajaAutomatico"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Mantenimiento Recibo Oficial de Caja"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbRecibo.ResumeLayout(False)
        Me.tbRecibo.PerformLayout()
        CType(Me.grdRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSocia.ResumeLayout(False)
        Me.tbSocia.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbRecibo As System.Windows.Forms.ToolStrip
    Friend WithEvents toolRefrescarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdRecibo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdSocia As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbSocia As System.Windows.Forms.ToolStrip
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAgregarAutomatico As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarAutomatico As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparadorAutomatico As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolEliminarAutomatico As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCorteTrasladoValores As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirListado As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents toolReporteCC45 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolReporteCC44 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolArqueo As System.Windows.Forms.ToolStripButton
End Class
