<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccSolicitudCheque
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccSolicitudCheque))
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.grpGenerales = New System.Windows.Forms.GroupBox()
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaH = New System.Windows.Forms.Label()
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaD = New System.Windows.Forms.Label()
        Me.tbCuenta = New System.Windows.Forms.ToolStrip()
        Me.toolAgregarJ = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarJ = New System.Windows.Forms.ToolStripButton()
        Me.toolEliminarJ = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyudaS = New System.Windows.Forms.ToolStripButton()
        Me.grdDetalles = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdSolicitud = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbSolicitud = New System.Windows.Forms.ToolStrip()
        Me.toolCheck = New System.Windows.Forms.ToolStripButton()
        Me.toolUnchek = New System.Windows.Forms.ToolStripButton()
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton()
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolModificar = New System.Windows.Forms.ToolStripButton()
        Me.toolAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRevisar = New System.Windows.Forms.ToolStripButton()
        Me.toolGenerarCK = New System.Windows.Forms.ToolStripButton()
        Me.toolGenerarChecked = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolActualizarConcepto = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.toolActualizarFecha = New System.Windows.Forms.ToolStripButton()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbCuenta.SuspendLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSolicitud.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.tbCuenta)
        Me.C1Sizer1.Controls.Add(Me.grdDetalles)
        Me.C1Sizer1.Controls.Add(Me.grdSolicitud)
        Me.C1Sizer1.Controls.Add(Me.tbSolicitud)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(700, 521)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 25)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(692, 4)
        Me.grpGenerales.TabIndex = 16
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione Fechas de Corte: "
        Me.grpGenerales.Visible = False
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(501, 10)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 34
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(384, 13)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(114, 13)
        Me.lblFechaH.TabIndex = 33
        Me.lblFechaH.Text = "Fecha Solicitud Hasta:"
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(279, 10)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 31
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(159, 13)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(117, 13)
        Me.lblFechaD.TabIndex = 32
        Me.lblFechaD.Text = "Fecha Solicitud Desde:"
        '
        'tbCuenta
        '
        Me.tbCuenta.AutoSize = False
        Me.tbCuenta.Dock = System.Windows.Forms.DockStyle.None
        Me.tbCuenta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarJ, Me.toolModificarJ, Me.toolEliminarJ, Me.toolSeparator2, Me.toolAyudaS})
        Me.tbCuenta.Location = New System.Drawing.Point(4, 309)
        Me.tbCuenta.Name = "tbCuenta"
        Me.tbCuenta.Size = New System.Drawing.Size(164, 23)
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
        Me.toolAgregarJ.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregarJ.Text = "Agregar"
        Me.toolAgregarJ.ToolTipText = "Agregar Codificación Contable"
        '
        'toolModificarJ
        '
        Me.toolModificarJ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarJ.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarJ.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarJ.Name = "toolModificarJ"
        Me.toolModificarJ.Size = New System.Drawing.Size(23, 20)
        Me.toolModificarJ.Text = "Modificar"
        Me.toolModificarJ.ToolTipText = "Modificar Codificación Contable"
        '
        'toolEliminarJ
        '
        Me.toolEliminarJ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarJ.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarJ.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEliminarJ.Name = "toolEliminarJ"
        Me.toolEliminarJ.Size = New System.Drawing.Size(23, 20)
        Me.toolEliminarJ.Text = "Eliminar Cuenta"
        Me.toolEliminarJ.ToolTipText = "Eliminar Cuenta"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
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
        'grdDetalles
        '
        Me.grdDetalles.AllowFilter = False
        Me.grdDetalles.AllowUpdate = False
        Me.grdDetalles.Caption = "Detalles de Solicitud de Cheque"
        Me.grdDetalles.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDetalles.FilterBar = True
        Me.grdDetalles.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDetalles.Images.Add(CType(resources.GetObject("grdDetalles.Images"), System.Drawing.Image))
        Me.grdDetalles.Location = New System.Drawing.Point(4, 336)
        Me.grdDetalles.Name = "grdDetalles"
        Me.grdDetalles.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetalles.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetalles.PreviewInfo.ZoomFactor = 75.0R
        Me.grdDetalles.PrintInfo.PageSettings = CType(resources.GetObject("grdDetalles.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDetalles.Size = New System.Drawing.Size(692, 181)
        Me.grdDetalles.TabIndex = 14
        Me.grdDetalles.Text = "grdDetalles"
        Me.grdDetalles.PropBag = resources.GetString("grdDetalles.PropBag")
        '
        'grdSolicitud
        '
        Me.grdSolicitud.AllowFilter = False
        Me.grdSolicitud.Caption = "Listado de Solicitudes de Cheques"
        Me.grdSolicitud.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSolicitud.FilterBar = True
        Me.grdSolicitud.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSolicitud.Images.Add(CType(resources.GetObject("grdSolicitud.Images"), System.Drawing.Image))
        Me.grdSolicitud.Location = New System.Drawing.Point(4, 33)
        Me.grdSolicitud.Name = "grdSolicitud"
        Me.grdSolicitud.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSolicitud.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSolicitud.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSolicitud.PrintInfo.PageSettings = CType(resources.GetObject("grdSolicitud.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSolicitud.Size = New System.Drawing.Size(692, 272)
        Me.grdSolicitud.TabIndex = 13
        Me.grdSolicitud.Text = "grdSolicitud"
        Me.grdSolicitud.PropBag = resources.GetString("grdSolicitud.PropBag")
        '
        'tbSolicitud
        '
        Me.tbSolicitud.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolCheck, Me.toolUnchek, Me.toolBuscar, Me.toolAgregar, Me.toolModificar, Me.toolAnular, Me.ToolStripButton7, Me.toolRevisar, Me.toolGenerarCK, Me.toolGenerarChecked, Me.ToolStripSeparator1, Me.toolRefrescar, Me.toolActualizarConcepto, Me.toolSeparator1, Me.toolImprimir, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir, Me.toolActualizarFecha})
        Me.tbSolicitud.Location = New System.Drawing.Point(4, 4)
        Me.tbSolicitud.Name = "tbSolicitud"
        Me.tbSolicitud.Size = New System.Drawing.Size(692, 21)
        Me.tbSolicitud.Stretch = True
        Me.tbSolicitud.TabIndex = 12
        Me.tbSolicitud.Text = "ToolStrip1"
        '
        'toolCheck
        '
        Me.toolCheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCheck.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
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
        Me.toolBuscar.Text = "Buscar Solicitudes"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 18)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 18)
        Me.toolModificar.Text = "Modificar"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 18)
        Me.toolAnular.Text = "Anular"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 21)
        '
        'toolRevisar
        '
        Me.toolRevisar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRevisar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolRevisar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRevisar.Name = "toolRevisar"
        Me.toolRevisar.Size = New System.Drawing.Size(23, 18)
        Me.toolRevisar.Text = "Revisar Solicitud de Cheque"
        '
        'toolGenerarCK
        '
        Me.toolGenerarCK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerarCK.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolGenerarCK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerarCK.Name = "toolGenerarCK"
        Me.toolGenerarCK.Size = New System.Drawing.Size(23, 18)
        Me.toolGenerarCK.Text = "Generar Comprobante Automático"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 21)
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
        'toolActualizarConcepto
        '
        Me.toolActualizarConcepto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolActualizarConcepto.Image = Global.SMUSURA0.My.Resources.Resources.edit
        Me.toolActualizarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolActualizarConcepto.Name = "toolActualizarConcepto"
        Me.toolActualizarConcepto.Size = New System.Drawing.Size(23, 18)
        Me.toolActualizarConcepto.Text = "Actualiza Concepto del Cheque"
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
        Me.toolImprimir.Text = "ToolStripButton1"
        Me.toolImprimir.ToolTipText = "Imprimir Solicitud de Cheque"
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
        'toolActualizarFecha
        '
        Me.toolActualizarFecha.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolActualizarFecha.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolActualizarFecha.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolActualizarFecha.Name = "toolActualizarFecha"
        Me.toolActualizarFecha.Size = New System.Drawing.Size(23, 18)
        Me.toolActualizarFecha.Text = "Actualizar Fecha"
        '
        'frmSccSolicitudCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 521)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSccSolicitudCheque"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Solicitudes de Cheques"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbCuenta.ResumeLayout(False)
        Me.tbCuenta.PerformLayout()
        CType(Me.grdDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSolicitud.ResumeLayout(False)
        Me.tbSolicitud.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbCuenta As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarJ As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarJ As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaS As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdDetalles As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdSolicitud As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbSolicitud As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRevisar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolGenerarCK As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolEliminarJ As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolActualizarConcepto As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolGenerarChecked As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolUnchek As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolActualizarFecha As System.Windows.Forms.ToolStripButton
End Class
