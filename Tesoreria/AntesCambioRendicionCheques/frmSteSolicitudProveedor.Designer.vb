<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteSolicitudProveedor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteSolicitudProveedor))
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.grpGenerales = New System.Windows.Forms.GroupBox()
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaH = New System.Windows.Forms.Label()
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaD = New System.Windows.Forms.Label()
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
        Me.toolImprimirborrar = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.toolImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.toolImprimirTE53 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolImprimirTE54 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolImprimirTE55 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolImprimirTE56 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolImprimirTE57 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSolicitud.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdSolicitud)
        Me.C1Sizer1.Controls.Add(Me.tbSolicitud)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(854, 418)
        Me.C1Sizer1.TabIndex = 2
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
        Me.grpGenerales.Size = New System.Drawing.Size(846, 30)
        Me.grpGenerales.TabIndex = 16
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione Fechas de Corte: "
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
        'grdSolicitud
        '
        Me.grdSolicitud.AllowFilter = False
        Me.grdSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdSolicitud.Caption = "Listado de Solicitudes de  desembolso proveedor"
        Me.grdSolicitud.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSolicitud.FilterBar = True
        Me.grdSolicitud.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSolicitud.Images.Add(CType(resources.GetObject("grdSolicitud.Images"), System.Drawing.Image))
        Me.grdSolicitud.Location = New System.Drawing.Point(4, 59)
        Me.grdSolicitud.Name = "grdSolicitud"
        Me.grdSolicitud.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSolicitud.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSolicitud.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSolicitud.PrintInfo.PageSettings = CType(resources.GetObject("grdSolicitud.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSolicitud.Size = New System.Drawing.Size(846, 355)
        Me.grdSolicitud.TabIndex = 13
        Me.grdSolicitud.Text = "grdSolicitud"
        Me.grdSolicitud.PropBag = resources.GetString("grdSolicitud.PropBag")
        '
        'tbSolicitud
        '
        Me.tbSolicitud.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolCheck, Me.toolUnchek, Me.toolBuscar, Me.toolAgregar, Me.toolModificar, Me.toolAnular, Me.ToolStripButton7, Me.toolRevisar, Me.toolGenerarCK, Me.toolGenerarChecked, Me.ToolStripSeparator1, Me.toolRefrescar, Me.toolActualizarConcepto, Me.toolSeparator1, Me.toolImprimirborrar, Me.toolSeparator3, Me.toolAyuda, Me.toolImprimir, Me.toolSalir})
        Me.tbSolicitud.Location = New System.Drawing.Point(0, 0)
        Me.tbSolicitud.Name = "tbSolicitud"
        Me.tbSolicitud.Size = New System.Drawing.Size(854, 25)
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
        Me.toolCheck.Size = New System.Drawing.Size(23, 22)
        Me.toolCheck.Text = "Dar Check a todas las notas listadas para procesar"
        Me.toolCheck.Visible = False
        '
        'toolUnchek
        '
        Me.toolUnchek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolUnchek.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.toolUnchek.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolUnchek.Name = "toolUnchek"
        Me.toolUnchek.Size = New System.Drawing.Size(23, 22)
        Me.toolUnchek.Text = "Quitar Check a todas las notas listadas para procesar"
        Me.toolUnchek.Visible = False
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 22)
        Me.toolBuscar.Text = "Buscar Solicitudes"
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
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 22)
        Me.toolAnular.Text = "Anular"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'toolRevisar
        '
        Me.toolRevisar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRevisar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolRevisar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRevisar.Name = "toolRevisar"
        Me.toolRevisar.Size = New System.Drawing.Size(23, 22)
        Me.toolRevisar.Text = "Revisar Solicitud de Cheque"
        '
        'toolGenerarCK
        '
        Me.toolGenerarCK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerarCK.Enabled = False
        Me.toolGenerarCK.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolGenerarCK.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerarCK.Name = "toolGenerarCK"
        Me.toolGenerarCK.Size = New System.Drawing.Size(23, 22)
        Me.toolGenerarCK.Text = "Generar Comprobante Automático"
        '
        'toolGenerarChecked
        '
        Me.toolGenerarChecked.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerarChecked.Enabled = False
        Me.toolGenerarChecked.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolGenerarChecked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerarChecked.Name = "toolGenerarChecked"
        Me.toolGenerarChecked.Size = New System.Drawing.Size(23, 22)
        Me.toolGenerarChecked.Text = "Genera Comprobante Ctble para registros seleccionados y Autorizados."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'toolActualizarConcepto
        '
        Me.toolActualizarConcepto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolActualizarConcepto.Enabled = False
        Me.toolActualizarConcepto.Image = Global.SMUSURA0.My.Resources.Resources.edit
        Me.toolActualizarConcepto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolActualizarConcepto.Name = "toolActualizarConcepto"
        Me.toolActualizarConcepto.Size = New System.Drawing.Size(23, 22)
        Me.toolActualizarConcepto.Text = "Actualiza Concepto del Cheque"
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(6, 25)
        Me.toolSeparator1.Visible = False
        '
        'toolImprimirborrar
        '
        Me.toolImprimirborrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirborrar.Enabled = False
        Me.toolImprimirborrar.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirborrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirborrar.Name = "toolImprimirborrar"
        Me.toolImprimirborrar.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirborrar.Text = "ToolStripButton1"
        Me.toolImprimirborrar.ToolTipText = "Imprimir Solicitud de Desembolso TE"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'toolSalir
        '
        Me.toolSalir.BackColor = System.Drawing.Color.Transparent
        Me.toolSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSalir.Name = "toolSalir"
        Me.toolSalir.Size = New System.Drawing.Size(23, 22)
        Me.toolSalir.Text = "Cerrar"
        Me.toolSalir.ToolTipText = "Salir"
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimirTE53, Me.toolImprimirTE54, Me.toolImprimirTE55, Me.toolImprimirTE56, Me.toolImprimirTE57})
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(32, 22)
        Me.toolImprimir.Text = "Imprimir Reportes"
        '
        'toolImprimirTE53
        '
        Me.toolImprimirTE53.Name = "toolImprimirTE53"
        Me.toolImprimirTE53.Size = New System.Drawing.Size(233, 22)
        Me.toolImprimirTE53.Text = "Solicitud Desembolso TE53"
        Me.toolImprimirTE53.Visible = False
        '
        'toolImprimirTE54
        '
        Me.toolImprimirTE54.Name = "toolImprimirTE54"
        Me.toolImprimirTE54.Size = New System.Drawing.Size(233, 22)
        Me.toolImprimirTE54.Text = "Constancia de Retencion TE54"
        '
        'toolImprimirTE55
        '
        Me.toolImprimirTE55.Name = "toolImprimirTE55"
        Me.toolImprimirTE55.Size = New System.Drawing.Size(233, 22)
        Me.toolImprimirTE55.Text = "Recibo Proveedore TE55"
        '
        'toolImprimirTE56
        '
        Me.toolImprimirTE56.Name = "toolImprimirTE56"
        Me.toolImprimirTE56.Size = New System.Drawing.Size(233, 22)
        Me.toolImprimirTE56.Text = "Listado Solicitudes TE56"
        '
        'toolImprimirTE57
        '
        Me.toolImprimirTE57.Name = "toolImprimirTE57"
        Me.toolImprimirTE57.Size = New System.Drawing.Size(233, 22)
        Me.toolImprimirTE57.Text = "Constancia de Alcaldia TE57"
        '
        'frmSteSolicitudProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 418)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Name = "frmSteSolicitudProveedor"
        Me.Text = "Solicitudes de desembolso Proveedor"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSolicitud.ResumeLayout(False)
        Me.tbSolicitud.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents tbSolicitud As System.Windows.Forms.ToolStrip
    Friend WithEvents toolCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolUnchek As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRevisar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolGenerarCK As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolGenerarChecked As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolActualizarConcepto As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirborrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdSolicitud As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolImprimirTE53 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirTE54 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirTE55 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirTE56 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirTE57 As System.Windows.Forms.ToolStripMenuItem
End Class
