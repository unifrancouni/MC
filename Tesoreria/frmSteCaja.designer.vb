<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteCaja))
        Me.tbCaja = New System.Windows.Forms.ToolStrip()
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolModificar = New System.Windows.Forms.ToolStripButton()
        Me.toolInactivar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolCajaDesconectadaAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolCajaDesconectadaEliminar = New System.Windows.Forms.ToolStripButton()
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton()
        Me.grdCaja = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.toolReabrirTodas = New System.Windows.Forms.ToolStripButton()
        Me.toolReabrir = New System.Windows.Forms.ToolStripButton()
        Me.tbCaja.SuspendLayout()
        CType(Me.grdCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbCaja
        '
        Me.tbCaja.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolInactivar, Me.ToolStripButton7, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.ToolStripSeparator2, Me.toolAyuda, Me.toolCajaDesconectadaAgregar, Me.toolCajaDesconectadaEliminar, Me.toolCerrar, Me.toolReabrir, Me.toolReabrirTodas})
        Me.tbCaja.Location = New System.Drawing.Point(0, 0)
        Me.tbCaja.Name = "tbCaja"
        Me.tbCaja.Size = New System.Drawing.Size(558, 25)
        Me.tbCaja.Stretch = True
        Me.tbCaja.TabIndex = 7
        Me.tbCaja.Text = "ToolStrip1"
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
        Me.toolInactivar.Text = "Cerrar"
        Me.toolInactivar.ToolTipText = "Cerrar"
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
        'toolCajaDesconectadaAgregar
        '
        Me.toolCajaDesconectadaAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCajaDesconectadaAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolCajaDesconectadaAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCajaDesconectadaAgregar.Name = "toolCajaDesconectadaAgregar"
        Me.toolCajaDesconectadaAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolCajaDesconectadaAgregar.Text = "Establecer como caja desconectada"
        '
        'toolCajaDesconectadaEliminar
        '
        Me.toolCajaDesconectadaEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCajaDesconectadaEliminar.Image = Global.SMUSURA0.My.Resources.Resources.Cerrar16
        Me.toolCajaDesconectadaEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCajaDesconectadaEliminar.Name = "toolCajaDesconectadaEliminar"
        Me.toolCajaDesconectadaEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolCajaDesconectadaEliminar.Text = "Quitar Caja desconectada"
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
        'grdCaja
        '
        Me.grdCaja.AllowFilter = False
        Me.grdCaja.AllowUpdate = False
        Me.grdCaja.Caption = "Listado de Cajas"
        Me.grdCaja.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdCaja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCaja.FilterBar = True
        Me.grdCaja.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdCaja.Images.Add(CType(resources.GetObject("grdCaja.Images"), System.Drawing.Image))
        Me.grdCaja.Location = New System.Drawing.Point(0, 25)
        Me.grdCaja.Name = "grdCaja"
        Me.grdCaja.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCaja.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCaja.PreviewInfo.ZoomFactor = 75.0R
        Me.grdCaja.PrintInfo.PageSettings = CType(resources.GetObject("grdCaja.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCaja.Size = New System.Drawing.Size(558, 316)
        Me.grdCaja.TabIndex = 8
        Me.grdCaja.Text = "grdCaja"
        Me.grdCaja.PropBag = resources.GetString("grdCaja.PropBag")
        '
        'toolReabrirTodas
        '
        Me.toolReabrirTodas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolReabrirTodas.Image = Global.SMUSURA0.My.Resources.Resources.bookmark_folder
        Me.toolReabrirTodas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolReabrirTodas.Name = "toolReabrirTodas"
        Me.toolReabrirTodas.Size = New System.Drawing.Size(23, 22)
        Me.toolReabrirTodas.Text = "Reabrir todas las cajas automáticas."
        '
        'toolReabrir
        '
        Me.toolReabrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolReabrir.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolReabrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolReabrir.Name = "toolReabrir"
        Me.toolReabrir.Size = New System.Drawing.Size(23, 22)
        Me.toolReabrir.Text = "Reabrir Caja"
        '
        'frmSteCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(558, 341)
        Me.Controls.Add(Me.grdCaja)
        Me.Controls.Add(Me.tbCaja)
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Cajas")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSteCaja"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Registro de Cajas del Programa"
        Me.tbCaja.ResumeLayout(False)
        Me.tbCaja.PerformLayout()
        CType(Me.grdCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdCaja As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbCaja As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolInactivar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolCajaDesconectadaAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCajaDesconectadaEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolReabrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolReabrirTodas As System.Windows.Forms.ToolStripButton
End Class
