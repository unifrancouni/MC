<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteImpresionCheques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteImpresionCheques))
        Me.tbImpresionCheques = New System.Windows.Forms.ToolStrip()
        Me.toolModificar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolLimpiarChequeACTUAL = New System.Windows.Forms.ToolStripButton()
        Me.toolLimpiarCheque = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolCerrarDia = New System.Windows.Forms.ToolStripButton()
        Me.toolReabrirDia = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolMarcar = New System.Windows.Forms.ToolStripButton()
        Me.toolDesmarcar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolImprimir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.grpGenerales = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadCuatro = New System.Windows.Forms.RadioButton()
        Me.RadTres = New System.Windows.Forms.RadioButton()
        Me.PorGrupo = New System.Windows.Forms.CheckBox()
        Me.grpRango = New System.Windows.Forms.GroupBox()
        Me.txtCkHasta = New System.Windows.Forms.TextBox()
        Me.txtCkDesde = New System.Windows.Forms.TextBox()
        Me.grpMostrar = New System.Windows.Forms.GroupBox()
        Me.RadTodos = New System.Windows.Forms.RadioButton()
        Me.radChequesPendientes = New System.Windows.Forms.RadioButton()
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaH = New System.Windows.Forms.Label()
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaD = New System.Windows.Forms.Label()
        Me.grdSolicitudes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbImpresionCheques.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpRango.SuspendLayout()
        Me.grpMostrar.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbImpresionCheques
        '
        Me.tbImpresionCheques.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolModificar, Me.ToolStripSeparator1, Me.toolLimpiarChequeACTUAL, Me.toolLimpiarCheque, Me.ToolStripSeparator3, Me.toolCerrarDia, Me.toolReabrirDia, Me.ToolStripSeparator6, Me.toolMarcar, Me.toolDesmarcar, Me.ToolStripSeparator7, Me.toolImprimir, Me.ToolStripSeparator4, Me.toolRefrescar, Me.ToolStripSeparator5, Me.toolAyuda, Me.toolSalir, Me.ToolStripSeparator2})
        Me.tbImpresionCheques.Location = New System.Drawing.Point(0, 0)
        Me.tbImpresionCheques.Name = "tbImpresionCheques"
        Me.tbImpresionCheques.Size = New System.Drawing.Size(923, 25)
        Me.tbImpresionCheques.Stretch = True
        Me.tbImpresionCheques.TabIndex = 1
        Me.tbImpresionCheques.Text = "ToolStrip1"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Asignar Chequera"
        Me.toolModificar.ToolTipText = "Asignar Chequera"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolLimpiarChequeACTUAL
        '
        Me.toolLimpiarChequeACTUAL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolLimpiarChequeACTUAL.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.toolLimpiarChequeACTUAL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolLimpiarChequeACTUAL.Name = "toolLimpiarChequeACTUAL"
        Me.toolLimpiarChequeACTUAL.Size = New System.Drawing.Size(23, 22)
        Me.toolLimpiarChequeACTUAL.Text = "Limpiar Número Cheque Seleccionado"
        '
        'toolLimpiarCheque
        '
        Me.toolLimpiarCheque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolLimpiarCheque.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.toolLimpiarCheque.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolLimpiarCheque.Name = "toolLimpiarCheque"
        Me.toolLimpiarCheque.Size = New System.Drawing.Size(23, 22)
        Me.toolLimpiarCheque.Text = "Limpiar Número(s) Cheque(s)"
        Me.toolLimpiarCheque.ToolTipText = "Limpiar Número(s) Cheque(s)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolCerrarDia
        '
        Me.toolCerrarDia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrarDia.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolCerrarDia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrarDia.Name = "toolCerrarDia"
        Me.toolCerrarDia.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrarDia.Text = "Aplicar Cheques Cta. Bancaria"
        Me.toolCerrarDia.ToolTipText = "Aplicar Cheques Cta. Bancaria"
        '
        'toolReabrirDia
        '
        Me.toolReabrirDia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolReabrirDia.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.toolReabrirDia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolReabrirDia.Name = "toolReabrirDia"
        Me.toolReabrirDia.Size = New System.Drawing.Size(23, 22)
        Me.toolReabrirDia.Text = "Revertir Aplicación Cheque(s)"
        Me.toolReabrirDia.ToolTipText = "Revertir Aplicación Cheque(s)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'toolMarcar
        '
        Me.toolMarcar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMarcar.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolMarcar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMarcar.Name = "toolMarcar"
        Me.toolMarcar.Size = New System.Drawing.Size(23, 22)
        Me.toolMarcar.Text = "Marcar para Impresión"
        Me.toolMarcar.ToolTipText = "Marcar para Impresión"
        '
        'toolDesmarcar
        '
        Me.toolDesmarcar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolDesmarcar.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolDesmarcar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDesmarcar.Name = "toolDesmarcar"
        Me.toolDesmarcar.Size = New System.Drawing.Size(23, 22)
        Me.toolDesmarcar.Text = "Desmarcar para Impresión"
        Me.toolDesmarcar.ToolTipText = "Desmarcar para Impresión"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimir.Text = "Imprimir Cheques Seleccionados"
        Me.toolImprimir.ToolTipText = "Imprimir Cheques"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdSolicitudes)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(923, 573)
        Me.C1Sizer1.TabIndex = 4
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.GroupBox1)
        Me.grpGenerales.Controls.Add(Me.PorGrupo)
        Me.grpGenerales.Controls.Add(Me.grpRango)
        Me.grpGenerales.Controls.Add(Me.grpMostrar)
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 28)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(915, 64)
        Me.grpGenerales.TabIndex = 5
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione Fechas de Corte: "
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadCuatro)
        Me.GroupBox1.Controls.Add(Me.RadTres)
        Me.GroupBox1.Location = New System.Drawing.Point(332, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 42)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Imprimir por página"
        '
        'RadCuatro
        '
        Me.RadCuatro.AutoSize = True
        Me.RadCuatro.Checked = True
        Me.RadCuatro.Location = New System.Drawing.Point(112, 22)
        Me.RadCuatro.Name = "RadCuatro"
        Me.RadCuatro.Size = New System.Drawing.Size(56, 17)
        Me.RadCuatro.TabIndex = 58
        Me.RadCuatro.TabStop = True
        Me.RadCuatro.Text = "Cuatro"
        Me.RadCuatro.UseVisualStyleBackColor = True
        '
        'RadTres
        '
        Me.RadTres.AutoSize = True
        Me.RadTres.Location = New System.Drawing.Point(42, 21)
        Me.RadTres.Name = "RadTres"
        Me.RadTres.Size = New System.Drawing.Size(49, 17)
        Me.RadTres.TabIndex = 57
        Me.RadTres.Text = "Tres "
        Me.RadTres.UseVisualStyleBackColor = True
        '
        'PorGrupo
        '
        Me.PorGrupo.AutoSize = True
        Me.PorGrupo.Location = New System.Drawing.Point(4, 44)
        Me.PorGrupo.Name = "PorGrupo"
        Me.PorGrupo.Size = New System.Drawing.Size(109, 17)
        Me.PorGrupo.TabIndex = 56
        Me.PorGrupo.Text = "Asignar por grupo"
        Me.PorGrupo.UseVisualStyleBackColor = True
        '
        'grpRango
        '
        Me.grpRango.Controls.Add(Me.txtCkHasta)
        Me.grpRango.Controls.Add(Me.txtCkDesde)
        Me.grpRango.Location = New System.Drawing.Point(700, 22)
        Me.grpRango.Name = "grpRango"
        Me.grpRango.Size = New System.Drawing.Size(204, 40)
        Me.grpRango.TabIndex = 55
        Me.grpRango.TabStop = False
        Me.grpRango.Text = "Revertir Cheque(s) Cta. Bancaria: "
        '
        'txtCkHasta
        '
        Me.txtCkHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCkHasta.Location = New System.Drawing.Point(93, 14)
        Me.txtCkHasta.Name = "txtCkHasta"
        Me.txtCkHasta.Size = New System.Drawing.Size(81, 20)
        Me.txtCkHasta.TabIndex = 131
        '
        'txtCkDesde
        '
        Me.txtCkDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCkDesde.Location = New System.Drawing.Point(6, 14)
        Me.txtCkDesde.Name = "txtCkDesde"
        Me.txtCkDesde.Size = New System.Drawing.Size(81, 20)
        Me.txtCkDesde.TabIndex = 130
        '
        'grpMostrar
        '
        Me.grpMostrar.Controls.Add(Me.RadTodos)
        Me.grpMostrar.Controls.Add(Me.radChequesPendientes)
        Me.grpMostrar.Location = New System.Drawing.Point(506, 18)
        Me.grpMostrar.Name = "grpMostrar"
        Me.grpMostrar.Size = New System.Drawing.Size(204, 39)
        Me.grpMostrar.TabIndex = 54
        Me.grpMostrar.TabStop = False
        Me.grpMostrar.Text = "Mostrar Cheques: "
        '
        'RadTodos
        '
        Me.RadTodos.AutoSize = True
        Me.RadTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTodos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadTodos.Location = New System.Drawing.Point(143, 19)
        Me.RadTodos.Name = "RadTodos"
        Me.RadTodos.Size = New System.Drawing.Size(55, 17)
        Me.RadTodos.TabIndex = 1
        Me.RadTodos.Text = "Todos"
        Me.RadTodos.UseVisualStyleBackColor = True
        '
        'radChequesPendientes
        '
        Me.radChequesPendientes.AutoSize = True
        Me.radChequesPendientes.Checked = True
        Me.radChequesPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radChequesPendientes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radChequesPendientes.Location = New System.Drawing.Point(6, 19)
        Me.radChequesPendientes.Name = "radChequesPendientes"
        Me.radChequesPendientes.Size = New System.Drawing.Size(131, 17)
        Me.radChequesPendientes.TabIndex = 0
        Me.radChequesPendientes.TabStop = True
        Me.radChequesPendientes.Text = "Pendientes de Imprimir"
        Me.radChequesPendientes.UseVisualStyleBackColor = True
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(222, 16)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(90, 20)
        Me.cdeFechaH.TabIndex = 1
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(181, 19)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaH.TabIndex = 29
        Me.lblFechaH.Text = "Hasta:"
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(88, 16)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(90, 20)
        Me.cdeFechaD.TabIndex = 0
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(1, 19)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(84, 13)
        Me.lblFechaD.TabIndex = 28
        Me.lblFechaD.Text = "Solicitud Desde:"
        '
        'grdSolicitudes
        '
        Me.grdSolicitudes.AllowFilter = False
        Me.grdSolicitudes.AllowUpdate = False
        Me.grdSolicitudes.Caption = "Listado de Solicitudes de Cheque Autorizadas"
        Me.grdSolicitudes.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSolicitudes.FilterBar = True
        Me.grdSolicitudes.GroupByAreaVisible = False
        Me.grdSolicitudes.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSolicitudes.Images.Add(CType(resources.GetObject("grdSolicitudes.Images"), System.Drawing.Image))
        Me.grdSolicitudes.Location = New System.Drawing.Point(4, 96)
        Me.grdSolicitudes.Name = "grdSolicitudes"
        Me.grdSolicitudes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSolicitudes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSolicitudes.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSolicitudes.PrintInfo.PageSettings = CType(resources.GetObject("grdSolicitudes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSolicitudes.Size = New System.Drawing.Size(915, 473)
        Me.grdSolicitudes.TabIndex = 2
        Me.grdSolicitudes.Text = "grdArqueo"
        Me.grdSolicitudes.PropBag = resources.GetString("grdSolicitudes.PropBag")
        '
        'frmSteImpresionCheques
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 573)
        Me.Controls.Add(Me.tbImpresionCheques)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Impresión de Cheques")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSteImpresionCheques"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "Impresión de Cheques"
        Me.tbImpresionCheques.ResumeLayout(False)
        Me.tbImpresionCheques.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grpRango.ResumeLayout(False)
        Me.grpRango.PerformLayout()
        Me.grpMostrar.ResumeLayout(False)
        Me.grpMostrar.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbImpresionCheques As System.Windows.Forms.ToolStrip
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdSolicitudes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents grpMostrar As System.Windows.Forms.GroupBox
    Friend WithEvents RadTodos As System.Windows.Forms.RadioButton
    Friend WithEvents radChequesPendientes As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolMarcar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolLimpiarCheque As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolDesmarcar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolLimpiarChequeACTUAL As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrarDia As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolReabrirDia As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents grpRango As System.Windows.Forms.GroupBox
    Friend WithEvents txtCkHasta As System.Windows.Forms.TextBox
    Friend WithEvents txtCkDesde As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PorGrupo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadCuatro As System.Windows.Forms.RadioButton
    Friend WithEvents RadTres As System.Windows.Forms.RadioButton
End Class
