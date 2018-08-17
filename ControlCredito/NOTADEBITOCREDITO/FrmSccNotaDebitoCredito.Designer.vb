<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccNotaDebitoCredito
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccNotaDebitoCredito))
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grdNotas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbCuenta = New System.Windows.Forms.ToolStrip
        Me.toolAgregarJ = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarJ = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaS = New System.Windows.Forms.ToolStripButton
        Me.grdDetallesCuentas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdDetalleFichas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbSolicitud = New System.Windows.Forms.ToolStrip
        Me.toolCheck = New System.Windows.Forms.ToolStripButton
        Me.toolUnchek = New System.Windows.Forms.ToolStripButton
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolAnular = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRevisar = New System.Windows.Forms.ToolStripButton
        Me.toolAutorizar = New System.Windows.Forms.ToolStripButton
        Me.toolGenerar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolGenerarChecked = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolSalir = New System.Windows.Forms.ToolStripButton
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.grdNotas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCuenta.SuspendLayout()
        CType(Me.grdDetallesCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetalleFichas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSolicitud.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdNotas)
        Me.C1Sizer1.Controls.Add(Me.tbCuenta)
        Me.C1Sizer1.Controls.Add(Me.grdDetallesCuentas)
        Me.C1Sizer1.Controls.Add(Me.grdDetalleFichas)
        Me.C1Sizer1.Controls.Add(Me.tbSolicitud)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(909, 460)
        Me.C1Sizer1.TabIndex = 2
        Me.C1Sizer1.TabStop = False
        '
        'grdNotas
        '
        Me.grdNotas.AllowFilter = False
        Me.grdNotas.Caption = "Listado de Notas"
        Me.grdNotas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdNotas.FilterBar = True
        Me.grdNotas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdNotas.Images.Add(CType(resources.GetObject("grdNotas.Images"), System.Drawing.Image))
        Me.grdNotas.Location = New System.Drawing.Point(4, 33)
        Me.grdNotas.Name = "grdNotas"
        Me.grdNotas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdNotas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdNotas.PreviewInfo.ZoomFactor = 75
        Me.grdNotas.PrintInfo.PageSettings = CType(resources.GetObject("grdNotas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdNotas.Size = New System.Drawing.Size(901, 162)
        Me.grdNotas.TabIndex = 16
        Me.grdNotas.Text = "grdSolicitud"
        Me.grdNotas.PropBag = resources.GetString("grdNotas.PropBag")
        '
        'tbCuenta
        '
        Me.tbCuenta.AutoSize = False
        Me.tbCuenta.Dock = System.Windows.Forms.DockStyle.None
        Me.tbCuenta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarJ, Me.toolEliminarJ, Me.toolSeparator2, Me.toolAyudaS})
        Me.tbCuenta.Location = New System.Drawing.Point(4, 356)
        Me.tbCuenta.Name = "tbCuenta"
        Me.tbCuenta.Size = New System.Drawing.Size(164, 21)
        Me.tbCuenta.Stretch = True
        Me.tbCuenta.TabIndex = 15
        Me.tbCuenta.Text = "ToolStrip1"
        '
        'toolAgregarJ
        '
        Me.toolAgregarJ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarJ.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarJ.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarJ.Name = "toolAgregarJ"
        Me.toolAgregarJ.Size = New System.Drawing.Size(23, 18)
        Me.toolAgregarJ.Text = "Agregar"
        Me.toolAgregarJ.ToolTipText = "Agregar Codificación Contable"
        '
        'toolEliminarJ
        '
        Me.toolEliminarJ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarJ.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarJ.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEliminarJ.Name = "toolEliminarJ"
        Me.toolEliminarJ.Size = New System.Drawing.Size(23, 18)
        Me.toolEliminarJ.Text = "Eliminar Cuenta"
        Me.toolEliminarJ.ToolTipText = "Eliminar Cuenta"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 21)
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
        'grdDetallesCuentas
        '
        Me.grdDetallesCuentas.AllowFilter = False
        Me.grdDetallesCuentas.AllowUpdate = False
        Me.grdDetallesCuentas.Caption = "Detalles de las Cuentas Contables"
        Me.grdDetallesCuentas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDetallesCuentas.FilterBar = True
        Me.grdDetallesCuentas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDetallesCuentas.Images.Add(CType(resources.GetObject("grdDetallesCuentas.Images"), System.Drawing.Image))
        Me.grdDetallesCuentas.Location = New System.Drawing.Point(4, 381)
        Me.grdDetallesCuentas.Name = "grdDetallesCuentas"
        Me.grdDetallesCuentas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetallesCuentas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetallesCuentas.PreviewInfo.ZoomFactor = 75
        Me.grdDetallesCuentas.PrintInfo.PageSettings = CType(resources.GetObject("grdDetallesCuentas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetallesCuentas.Size = New System.Drawing.Size(901, 75)
        Me.grdDetallesCuentas.TabIndex = 14
        Me.grdDetallesCuentas.Text = "grdDetalles"
        Me.grdDetallesCuentas.PropBag = resources.GetString("grdDetallesCuentas.PropBag")
        '
        'grdDetalleFichas
        '
        Me.grdDetalleFichas.AllowFilter = False
        Me.grdDetalleFichas.Caption = "Detalle de las Fichas"
        Me.grdDetalleFichas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDetalleFichas.FilterBar = True
        Me.grdDetalleFichas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDetalleFichas.Images.Add(CType(resources.GetObject("grdDetalleFichas.Images"), System.Drawing.Image))
        Me.grdDetalleFichas.Location = New System.Drawing.Point(4, 199)
        Me.grdDetalleFichas.Name = "grdDetalleFichas"
        Me.grdDetalleFichas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetalleFichas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetalleFichas.PreviewInfo.ZoomFactor = 75
        Me.grdDetalleFichas.PrintInfo.PageSettings = CType(resources.GetObject("grdDetalleFichas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetalleFichas.Size = New System.Drawing.Size(901, 153)
        Me.grdDetalleFichas.TabIndex = 13
        Me.grdDetalleFichas.Text = "grdSolicitud"
        Me.grdDetalleFichas.PropBag = resources.GetString("grdDetalleFichas.PropBag")
        '
        'tbSolicitud
        '
        Me.tbSolicitud.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolCheck, Me.toolUnchek, Me.toolBuscar, Me.toolAgregar, Me.toolModificar, Me.toolAnular, Me.ToolStripButton7, Me.toolRevisar, Me.toolAutorizar, Me.toolGenerar, Me.ToolStripSeparator1, Me.toolGenerarChecked, Me.toolRefrescar, Me.toolSeparator1, Me.toolImprimir, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbSolicitud.Location = New System.Drawing.Point(4, 4)
        Me.tbSolicitud.Name = "tbSolicitud"
        Me.tbSolicitud.Size = New System.Drawing.Size(901, 21)
        Me.tbSolicitud.Stretch = True
        Me.tbSolicitud.TabIndex = 12
        Me.tbSolicitud.Text = "ToolStrip1"
        '
        'toolCheck
        '
        Me.toolCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCheck.Image = Global.SMUSURA0.My.Resources.Resources.edit
        Me.toolCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCheck.Name = "toolCheck"
        Me.toolCheck.Size = New System.Drawing.Size(23, 18)
        Me.toolCheck.Text = "Dar Check a todas las notas listadas para procesar"
        '
        'toolUnchek
        '
        Me.toolUnchek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolUnchek.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.toolUnchek.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUnchek.Name = "toolUnchek"
        Me.toolUnchek.Size = New System.Drawing.Size(23, 18)
        Me.toolUnchek.Text = "Quitar Check a todas las notas listadas para procesar"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 18)
        Me.toolBuscar.Text = "Buscar Notas"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 18)
        Me.toolAgregar.Text = "Agregar Notas"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 18)
        Me.toolModificar.Text = "Modificar  Notas"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 18)
        Me.toolAnular.Text = "Anular Nota"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 21)
        '
        'toolRevisar
        '
        Me.toolRevisar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRevisar.Image = Global.SMUSURA0.My.Resources.Resources.AprobarPartida16
        Me.toolRevisar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRevisar.Name = "toolRevisar"
        Me.toolRevisar.Size = New System.Drawing.Size(23, 18)
        Me.toolRevisar.Text = "Revisar  Nota"
        '
        'toolAutorizar
        '
        Me.toolAutorizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAutorizar.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
        Me.toolAutorizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAutorizar.Name = "toolAutorizar"
        Me.toolAutorizar.Size = New System.Drawing.Size(23, 18)
        Me.toolAutorizar.Text = "Autorizar Nota"
        '
        'toolGenerar
        '
        Me.toolGenerar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerar.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolGenerar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerar.Name = "toolGenerar"
        Me.toolGenerar.Size = New System.Drawing.Size(23, 18)
        Me.toolGenerar.Text = "Generar Comprobante Contable"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 21)
        '
        'toolGenerarChecked
        '
        Me.toolGenerarChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerarChecked.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolGenerarChecked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerarChecked.Name = "toolGenerarChecked"
        Me.toolGenerarChecked.Size = New System.Drawing.Size(23, 18)
        Me.toolGenerarChecked.Text = "Genera Comprobante Ctble para registros seleccionados y Autorizados."
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 18)
        Me.toolRefrescar.Text = "Refrescar"
        Me.toolRefrescar.Visible = False
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(6, 21)
        Me.toolSeparator1.Visible = False
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 18)
        Me.toolImprimir.Text = "Imprimir Notas de Debito Credito"
        Me.toolImprimir.ToolTipText = "Imprimir Notas de Debito Credito"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(6, 21)
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 18)
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
        Me.toolSalir.Size = New System.Drawing.Size(23, 18)
        Me.toolSalir.Text = "Cerrar"
        Me.toolSalir.ToolTipText = "Salir"
        '
        'FrmSccNotaDebitoCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(909, 460)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Name = "FrmSccNotaDebitoCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notas de Debito-Credito"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        CType(Me.grdNotas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCuenta.ResumeLayout(False)
        Me.tbCuenta.PerformLayout()
        CType(Me.grdDetallesCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetalleFichas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSolicitud.ResumeLayout(False)
        Me.tbSolicitud.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbCuenta As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarJ As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarJ As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaS As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdDetallesCuentas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdDetalleFichas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbSolicitud As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolGenerar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolAutorizar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRevisar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolUnchek As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolGenerarChecked As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdNotas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
