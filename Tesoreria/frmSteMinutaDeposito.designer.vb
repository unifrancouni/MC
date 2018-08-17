<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteMinutaDeposito
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteMinutaDeposito))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.grdMinuta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbMinuta = New System.Windows.Forms.ToolStrip
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolEnviarMHCP = New System.Windows.Forms.ToolStripButton
        Me.toolRevertirEnvioMHCP = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAplicar = New System.Windows.Forms.ToolStripButton
        Me.toolRevertirErrorEnvio = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.toolImprimirP = New System.Windows.Forms.ToolStripButton
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMinuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMinuta.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdMinuta)
        Me.C1Sizer1.Controls.Add(Me.tbMinuta)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(677, 438)
        Me.C1Sizer1.TabIndex = 0
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 30)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(669, 33)
        Me.grpGenerales.TabIndex = 17
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
        Me.lblFechaH.Size = New System.Drawing.Size(116, 13)
        Me.lblFechaH.TabIndex = 33
        Me.lblFechaH.Text = "Fecha Depósito Hasta:"
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
        Me.lblFechaD.Size = New System.Drawing.Size(119, 13)
        Me.lblFechaD.TabIndex = 32
        Me.lblFechaD.Text = "Fecha Depósito Desde:"
        '
        'grdMinuta
        '
        Me.grdMinuta.AllowFilter = False
        Me.grdMinuta.AllowUpdate = False
        Me.grdMinuta.Caption = "Listado de Minutas de Depósito"
        Me.grdMinuta.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdMinuta.FilterBar = True
        Me.grdMinuta.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdMinuta.Images.Add(CType(resources.GetObject("grdMinuta.Images"), System.Drawing.Image))
        Me.grdMinuta.Location = New System.Drawing.Point(4, 67)
        Me.grdMinuta.Name = "grdMinuta"
        Me.grdMinuta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdMinuta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdMinuta.PreviewInfo.ZoomFactor = 75
        Me.grdMinuta.PrintInfo.PageSettings = CType(resources.GetObject("grdMinuta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdMinuta.Size = New System.Drawing.Size(669, 367)
        Me.grdMinuta.TabIndex = 13
        Me.grdMinuta.Text = "grdCtaBancaria"
        Me.grdMinuta.PropBag = resources.GetString("grdMinuta.PropBag")
        '
        'tbMinuta
        '
        Me.tbMinuta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar, Me.ToolStripButton7, Me.toolEnviarMHCP, Me.toolRevertirEnvioMHCP, Me.ToolStripSeparator2, Me.toolAplicar, Me.toolRevertirErrorEnvio, Me.ToolStripSeparator5, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolImprimir, Me.toolImprimirP, Me.ToolStripSeparator3, Me.toolAyuda, Me.toolCerrar, Me.ToolStripSeparator4})
        Me.tbMinuta.Location = New System.Drawing.Point(0, 0)
        Me.tbMinuta.Name = "tbMinuta"
        Me.tbMinuta.Size = New System.Drawing.Size(677, 25)
        Me.tbMinuta.Stretch = True
        Me.tbMinuta.TabIndex = 12
        Me.tbMinuta.Text = "ToolStrip1"
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
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'toolEnviarMHCP
        '
        Me.toolEnviarMHCP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEnviarMHCP.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolEnviarMHCP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEnviarMHCP.Name = "toolEnviarMHCP"
        Me.toolEnviarMHCP.Size = New System.Drawing.Size(23, 22)
        Me.toolEnviarMHCP.Text = "Enviar Minuta a MHCP"
        Me.toolEnviarMHCP.ToolTipText = "Enviar Minuta a MHCP"
        '
        'toolRevertirEnvioMHCP
        '
        Me.toolRevertirEnvioMHCP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRevertirEnvioMHCP.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolRevertirEnvioMHCP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRevertirEnvioMHCP.Name = "toolRevertirEnvioMHCP"
        Me.toolRevertirEnvioMHCP.Size = New System.Drawing.Size(23, 22)
        Me.toolRevertirEnvioMHCP.Text = "Revertir Envío MHCP"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolAplicar
        '
        Me.toolAplicar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAplicar.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolAplicar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAplicar.Name = "toolAplicar"
        Me.toolAplicar.Size = New System.Drawing.Size(23, 22)
        Me.toolAplicar.Text = "Aplicar Envío al MHCP"
        Me.toolAplicar.ToolTipText = "Aplicar Envío al MHCP"
        '
        'toolRevertirErrorEnvio
        '
        Me.toolRevertirErrorEnvio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRevertirErrorEnvio.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolRevertirErrorEnvio.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRevertirErrorEnvio.Name = "toolRevertirErrorEnvio"
        Me.toolRevertirErrorEnvio.Size = New System.Drawing.Size(23, 22)
        Me.toolRevertirErrorEnvio.Text = "Reenviar (Revertir Error de Envío)"
        Me.toolRevertirErrorEnvio.ToolTipText = "Revertir Error de Envío"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        Me.toolImprimir.Text = "Imprimir Listado Minutas"
        Me.toolImprimir.ToolTipText = "Imprimir Listado Minutas"
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolImprimirP
        '
        Me.toolImprimirP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirP.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirP.Name = "toolImprimirP"
        Me.toolImprimirP.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirP.Text = "Listado Minutas No Enviadas MHCP"
        Me.toolImprimirP.ToolTipText = "Listado Minutas No Enviadas MHCP"
        '
        'frmSteMinutaDeposito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 438)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSteMinutaDeposito"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Minutas de Depósitos"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMinuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMinuta.ResumeLayout(False)
        Me.tbMinuta.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbMinuta As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdMinuta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolEnviarMHCP As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAplicar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRevertirErrorEnvio As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRevertirEnvioMHCP As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolImprimirP As System.Windows.Forms.ToolStripButton
End Class
