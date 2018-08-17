<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccReciboCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccReciboCaja))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.tbRecibo = New System.Windows.Forms.ToolStrip()
        Me.toolAgregarM = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarM = New System.Windows.Forms.ToolStripButton()
        Me.toolEliminarM = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparadorManual = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAgregarAutomatico = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarAutomatico = New System.Windows.Forms.ToolStripButton()
        Me.toolEliminarAutomatico = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparadorAutomatico = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAgregarReciboSobrante = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarReciboSobrante = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescarM = New System.Windows.Forms.ToolStripButton()
        Me.toolImprimirM = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.grdRecibo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdSocia = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbSocia = New System.Windows.Forms.ToolStrip()
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton()
        Me.toolModificar = New System.Windows.Forms.ToolStripButton()
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparador1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImprimir = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuConsultaDeRecibosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEstadoDeCuentaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolImprimirEC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
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
        Me.tbRecibo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarM, Me.toolModificarM, Me.toolEliminarM, Me.toolSeparadorManual, Me.toolAgregarAutomatico, Me.toolModificarAutomatico, Me.toolEliminarAutomatico, Me.toolSeparadorAutomatico, Me.toolAgregarReciboSobrante, Me.toolModificarReciboSobrante, Me.ToolStripSeparator5, Me.toolRefrescarM, Me.toolImprimirM, Me.ToolStripButton1})
        Me.tbRecibo.Location = New System.Drawing.Point(4, 212)
        Me.tbRecibo.Name = "tbRecibo"
        Me.tbRecibo.Size = New System.Drawing.Size(289, 25)
        Me.tbRecibo.Stretch = True
        Me.tbRecibo.TabIndex = 15
        Me.tbRecibo.Text = "ToolStrip1"
        '
        'toolAgregarM
        '
        Me.toolAgregarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarM.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarM.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarM.Name = "toolAgregarM"
        Me.toolAgregarM.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarM.Text = "Agregar"
        Me.toolAgregarM.ToolTipText = "Agregar"
        '
        'toolModificarM
        '
        Me.toolModificarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarM.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarM.Name = "toolModificarM"
        Me.toolModificarM.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarM.Text = "Modificar"
        Me.toolModificarM.ToolTipText = "Modificar"
        '
        'toolEliminarM
        '
        Me.toolEliminarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarM.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarM.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarM.Name = "toolEliminarM"
        Me.toolEliminarM.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarM.Text = "Anular"
        Me.toolEliminarM.ToolTipText = "Anular Recibo Sin Regeneración"
        '
        'toolSeparadorManual
        '
        Me.toolSeparadorManual.Name = "toolSeparadorManual"
        Me.toolSeparadorManual.Size = New System.Drawing.Size(6, 25)
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
        'toolAgregarReciboSobrante
        '
        Me.toolAgregarReciboSobrante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarReciboSobrante.Image = Global.SMUSURA0.My.Resources.Resources.bookmark_folder
        Me.toolAgregarReciboSobrante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregarReciboSobrante.Name = "toolAgregarReciboSobrante"
        Me.toolAgregarReciboSobrante.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarReciboSobrante.Text = "ToolStripButton1"
        Me.toolAgregarReciboSobrante.ToolTipText = "Agregar Recibo Con Sobrante"
        '
        'toolModificarReciboSobrante
        '
        Me.toolModificarReciboSobrante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarReciboSobrante.Image = Global.SMUSURA0.My.Resources.Resources.xedit1
        Me.toolModificarReciboSobrante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarReciboSobrante.Name = "toolModificarReciboSobrante"
        Me.toolModificarReciboSobrante.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarReciboSobrante.Text = "ToolStripButton2"
        Me.toolModificarReciboSobrante.ToolTipText = "Modificar Recibo Con Sobrante"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        Me.toolImprimirM.Visible = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        Me.ToolStripButton1.Visible = False
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
        Me.grdRecibo.PreviewInfo.ZoomFactor = 75.0R
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
        Me.grdSocia.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSocia.PrintInfo.PageSettings = CType(resources.GetObject("grdSocia.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocia.Size = New System.Drawing.Size(666, 178)
        Me.grdSocia.TabIndex = 13
        Me.grdSocia.Text = "grdSocia"
        Me.grdSocia.PropBag = resources.GetString("grdSocia.PropBag")
        '
        'tbSocia
        '
        Me.tbSocia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.toolModificar, Me.toolEliminar, Me.toolSeparador1, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.ToolStripSeparator3, Me.toolAyuda, Me.toolCerrar})
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
        'toolSeparador1
        '
        Me.toolSeparador1.Name = "toolSeparador1"
        Me.toolSeparador1.Size = New System.Drawing.Size(6, 25)
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
        Me.toolImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuConsultaDeRecibosToolStripMenuItem, Me.mnuEstadoDeCuentaToolStripMenuItem, Me.toolImprimirEC})
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(29, 22)
        Me.toolImprimir.Text = "ToolStripButton1"
        Me.toolImprimir.ToolTipText = "Imprimir Listado"
        '
        'mnuConsultaDeRecibosToolStripMenuItem
        '
        Me.mnuConsultaDeRecibosToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.mnuConsultaDeRecibosToolStripMenuItem.Name = "mnuConsultaDeRecibosToolStripMenuItem"
        Me.mnuConsultaDeRecibosToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.mnuConsultaDeRecibosToolStripMenuItem.Text = "Consulta de Recibos CC20"
        '
        'mnuEstadoDeCuentaToolStripMenuItem
        '
        Me.mnuEstadoDeCuentaToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.mnuEstadoDeCuentaToolStripMenuItem.Name = "mnuEstadoDeCuentaToolStripMenuItem"
        Me.mnuEstadoDeCuentaToolStripMenuItem.Size = New System.Drawing.Size(249, 22)
        Me.mnuEstadoDeCuentaToolStripMenuItem.Text = "Estado de Cuenta CC16"
        '
        'toolImprimirEC
        '
        Me.toolImprimirEC.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolImprimirEC.Name = "toolImprimirEC"
        Me.toolImprimirEC.Size = New System.Drawing.Size(249, 22)
        Me.toolImprimirEC.Text = "Estado de Cuenta Resumen CC38"
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
        'frmSccReciboCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 403)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Recibo Oficial de Caja Manual")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSccReciboCaja"
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
    Friend WithEvents toolAgregarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdRecibo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdSocia As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbSocia As System.Windows.Forms.ToolStrip
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuConsultaDeRecibosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEstadoDeCuentaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolAgregarReciboSobrante As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarReciboSobrante As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAgregarAutomatico As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparadorManual As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolModificarAutomatico As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparadorAutomatico As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolEliminarAutomatico As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirEC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
End Class
