<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditMantenimientoFiador
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditMantenimientoFiador))
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.errFicha = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDatosGrales = New System.Windows.Forms.GroupBox
        Me.txtNombreFiador = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEstadoRC = New System.Windows.Forms.TextBox
        Me.txtCodigoRC = New System.Windows.Forms.TextBox
        Me.lblEstadoRC = New System.Windows.Forms.Label
        Me.lblCodigoRC = New System.Windows.Forms.Label
        Me.tabFicha = New C1.Win.C1Command.C1DockingTab
        Me.tabPReferencia = New C1.Win.C1Command.C1DockingTabPage
        Me.lblSinDisponibilidad = New System.Windows.Forms.Label
        Me.tbReferencia = New System.Windows.Forms.ToolStrip
        Me.toolAgregarRC = New System.Windows.Forms.ToolStripButton
        Me.toolModificarRC = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarRC = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarRC = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaRC = New System.Windows.Forms.ToolStripButton
        Me.grdReferencia = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tabPReferenciasPersonales = New C1.Win.C1Command.C1DockingTabPage
        Me.btnDatosFinanciero = New System.Windows.Forms.Button
        Me.tbReferenciasPersonales = New System.Windows.Forms.ToolStrip
        Me.toolAgregarRP = New System.Windows.Forms.ToolStripButton
        Me.toolModificarRP = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarRP = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarRP = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaRP = New System.Windows.Forms.ToolStripButton
        Me.grdReferenciaComerciales = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdReferenciaBancaria = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdReferenciaPersonal = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbReferenciasComerciales = New System.Windows.Forms.ToolStrip
        Me.toolAgregarRCO = New System.Windows.Forms.ToolStripButton
        Me.toolModificarRCO = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarRCO = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarRCO = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaRCOM = New System.Windows.Forms.ToolStripButton
        Me.tbReferenciasBancarias = New System.Windows.Forms.ToolStrip
        Me.toolAgregarRB = New System.Windows.Forms.ToolStripButton
        Me.toolModificarRB = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarRB = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarRB = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaRB = New System.Windows.Forms.ToolStripButton
        CType(Me.errFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosGrales.SuspendLayout()
        CType(Me.tabFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabFicha.SuspendLayout()
        Me.tabPReferencia.SuspendLayout()
        Me.tbReferencia.SuspendLayout()
        CType(Me.grdReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPReferenciasPersonales.SuspendLayout()
        Me.tbReferenciasPersonales.SuspendLayout()
        CType(Me.grdReferenciaComerciales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdReferenciaBancaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdReferenciaPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbReferenciasComerciales.SuspendLayout()
        Me.tbReferenciasBancarias.SuspendLayout()
        Me.SuspendLayout()
        '
        'errFicha
        '
        Me.errFicha.ContainerControl = Me
        '
        'grpDatosGrales
        '
        Me.grpDatosGrales.Controls.Add(Me.txtNombreFiador)
        Me.grpDatosGrales.Controls.Add(Me.Label1)
        Me.grpDatosGrales.Controls.Add(Me.txtEstadoRC)
        Me.grpDatosGrales.Controls.Add(Me.txtCodigoRC)
        Me.grpDatosGrales.Controls.Add(Me.lblEstadoRC)
        Me.grpDatosGrales.Controls.Add(Me.lblCodigoRC)
        Me.grpDatosGrales.Location = New System.Drawing.Point(2, 12)
        Me.grpDatosGrales.Name = "grpDatosGrales"
        Me.grpDatosGrales.Size = New System.Drawing.Size(728, 78)
        Me.grpDatosGrales.TabIndex = 18
        Me.grpDatosGrales.TabStop = False
        Me.grpDatosGrales.Text = "Datos Generales"
        '
        'txtNombreFiador
        '
        Me.txtNombreFiador.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreFiador.Enabled = False
        Me.txtNombreFiador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreFiador.Location = New System.Drawing.Point(86, 52)
        Me.txtNombreFiador.Name = "txtNombreFiador"
        Me.txtNombreFiador.ReadOnly = True
        Me.txtNombreFiador.ShortcutsEnabled = False
        Me.txtNombreFiador.Size = New System.Drawing.Size(510, 20)
        Me.txtNombreFiador.TabIndex = 37
        Me.txtNombreFiador.Tag = "LAYOUT:FLAT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Fiador:"
        '
        'txtEstadoRC
        '
        Me.txtEstadoRC.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstadoRC.Enabled = False
        Me.txtEstadoRC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoRC.Location = New System.Drawing.Point(238, 19)
        Me.txtEstadoRC.Name = "txtEstadoRC"
        Me.txtEstadoRC.ReadOnly = True
        Me.txtEstadoRC.ShortcutsEnabled = False
        Me.txtEstadoRC.Size = New System.Drawing.Size(205, 20)
        Me.txtEstadoRC.TabIndex = 35
        Me.txtEstadoRC.Tag = "LAYOUT:FLAT"
        '
        'txtCodigoRC
        '
        Me.txtCodigoRC.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoRC.Enabled = False
        Me.txtCodigoRC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoRC.Location = New System.Drawing.Point(86, 20)
        Me.txtCodigoRC.Name = "txtCodigoRC"
        Me.txtCodigoRC.ReadOnly = True
        Me.txtCodigoRC.ShortcutsEnabled = False
        Me.txtCodigoRC.Size = New System.Drawing.Size(83, 20)
        Me.txtCodigoRC.TabIndex = 34
        Me.txtCodigoRC.Tag = "LAYOUT:FLAT"
        '
        'lblEstadoRC
        '
        Me.lblEstadoRC.AutoSize = True
        Me.lblEstadoRC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstadoRC.Location = New System.Drawing.Point(189, 22)
        Me.lblEstadoRC.Name = "lblEstadoRC"
        Me.lblEstadoRC.Size = New System.Drawing.Size(43, 13)
        Me.lblEstadoRC.TabIndex = 33
        Me.lblEstadoRC.Text = "Estado:"
        '
        'lblCodigoRC
        '
        Me.lblCodigoRC.AutoSize = True
        Me.lblCodigoRC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoRC.Location = New System.Drawing.Point(13, 22)
        Me.lblCodigoRC.Name = "lblCodigoRC"
        Me.lblCodigoRC.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoRC.TabIndex = 32
        Me.lblCodigoRC.Text = "Código Ficha:"
        '
        'tabFicha
        '
        Me.tabFicha.BackColor = System.Drawing.SystemColors.Control
        Me.tabFicha.Controls.Add(Me.tabPReferencia)
        Me.tabFicha.Controls.Add(Me.tabPReferenciasPersonales)
        Me.tabFicha.Location = New System.Drawing.Point(2, 96)
        Me.tabFicha.Name = "tabFicha"
        Me.tabFicha.SelectedIndex = 6
        Me.tabFicha.Size = New System.Drawing.Size(807, 605)
        Me.tabFicha.TabIndex = 1
        '
        'tabPReferencia
        '
        Me.tabPReferencia.CaptionText = "Afectacion Presupuestaria"
        Me.tabPReferencia.Controls.Add(Me.lblSinDisponibilidad)
        Me.tabPReferencia.Controls.Add(Me.tbReferencia)
        Me.tabPReferencia.Controls.Add(Me.grdReferencia)
        Me.tabPReferencia.Image = Global.SMUSURA0.My.Resources.Resources.DocSoporte16
        Me.tabPReferencia.Location = New System.Drawing.Point(1, 25)
        Me.tabPReferencia.Name = "tabPReferencia"
        Me.tabPReferencia.Size = New System.Drawing.Size(805, 579)
        Me.tabPReferencia.TabIndex = 1
        Me.tabPReferencia.Text = "Referencia Crediticia"
        '
        'lblSinDisponibilidad
        '
        Me.lblSinDisponibilidad.AutoSize = True
        Me.lblSinDisponibilidad.Location = New System.Drawing.Point(18, 452)
        Me.lblSinDisponibilidad.Name = "lblSinDisponibilidad"
        Me.lblSinDisponibilidad.Size = New System.Drawing.Size(0, 13)
        Me.lblSinDisponibilidad.TabIndex = 19
        '
        'tbReferencia
        '
        Me.tbReferencia.AutoSize = False
        Me.tbReferencia.Dock = System.Windows.Forms.DockStyle.None
        Me.tbReferencia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarRC, Me.toolModificarRC, Me.toolEliminarRC, Me.toolSeparador1, Me.toolRefrescarRC, Me.toolSeparador2, Me.toolAyudaRC})
        Me.tbReferencia.Location = New System.Drawing.Point(21, 68)
        Me.tbReferencia.Name = "tbReferencia"
        Me.tbReferencia.Size = New System.Drawing.Size(728, 25)
        Me.tbReferencia.Stretch = True
        Me.tbReferencia.TabIndex = 20
        Me.tbReferencia.Text = "ToolStrip1"
        '
        'toolAgregarRC
        '
        Me.toolAgregarRC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarRC.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarRC.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarRC.Name = "toolAgregarRC"
        Me.toolAgregarRC.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarRC.Text = "Agregar"
        Me.toolAgregarRC.ToolTipText = "Agregar"
        '
        'toolModificarRC
        '
        Me.toolModificarRC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarRC.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarRC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarRC.Name = "toolModificarRC"
        Me.toolModificarRC.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarRC.Text = "Modificar"
        Me.toolModificarRC.ToolTipText = "Modificar"
        '
        'toolEliminarRC
        '
        Me.toolEliminarRC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarRC.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarRC.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarRC.Name = "toolEliminarRC"
        Me.toolEliminarRC.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarRC.Text = "Eliminar"
        '
        'toolSeparador1
        '
        Me.toolSeparador1.Name = "toolSeparador1"
        Me.toolSeparador1.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarRC
        '
        Me.toolRefrescarRC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarRC.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarRC.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarRC.Name = "toolRefrescarRC"
        Me.toolRefrescarRC.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarRC.Text = "Refrescar"
        '
        'toolSeparador2
        '
        Me.toolSeparador2.Name = "toolSeparador2"
        Me.toolSeparador2.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaRC
        '
        Me.toolAyudaRC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaRC.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaRC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaRC.Name = "toolAyudaRC"
        Me.toolAyudaRC.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaRC.Text = "Ayuda"
        Me.toolAyudaRC.ToolTipText = "Ayuda"
        '
        'grdReferencia
        '
        Me.grdReferencia.AllowFilter = False
        Me.grdReferencia.AllowUpdate = False
        Me.grdReferencia.Caption = "Listado de Referencias Crediticias"
        Me.grdReferencia.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdReferencia.FilterBar = True
        Me.grdReferencia.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdReferencia.Images.Add(CType(resources.GetObject("grdReferencia.Images"), System.Drawing.Image))
        Me.grdReferencia.Location = New System.Drawing.Point(21, 96)
        Me.grdReferencia.Name = "grdReferencia"
        Me.grdReferencia.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdReferencia.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdReferencia.PreviewInfo.ZoomFactor = 75
        Me.grdReferencia.PrintInfo.PageSettings = CType(resources.GetObject("grdReferencia.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdReferencia.Size = New System.Drawing.Size(728, 422)
        Me.grdReferencia.TabIndex = 16
        Me.grdReferencia.Text = "grdReferencia"
        Me.grdReferencia.PropBag = resources.GetString("grdReferencia.PropBag")
        '
        'tabPReferenciasPersonales
        '
        Me.tabPReferenciasPersonales.Controls.Add(Me.btnDatosFinanciero)
        Me.tabPReferenciasPersonales.Controls.Add(Me.tbReferenciasPersonales)
        Me.tabPReferenciasPersonales.Controls.Add(Me.grdReferenciaComerciales)
        Me.tabPReferenciasPersonales.Controls.Add(Me.grdReferenciaBancaria)
        Me.tabPReferenciasPersonales.Controls.Add(Me.grdReferenciaPersonal)
        Me.tabPReferenciasPersonales.Controls.Add(Me.tbReferenciasComerciales)
        Me.tabPReferenciasPersonales.Controls.Add(Me.tbReferenciasBancarias)
        Me.tabPReferenciasPersonales.Image = Global.SMUSURA0.My.Resources.Resources.Beneficiario16
        Me.tabPReferenciasPersonales.Location = New System.Drawing.Point(1, 25)
        Me.tabPReferenciasPersonales.Name = "tabPReferenciasPersonales"
        Me.tabPReferenciasPersonales.Size = New System.Drawing.Size(805, 579)
        Me.tabPReferenciasPersonales.TabIndex = 4
        Me.tabPReferenciasPersonales.Text = "Otras Referencias"
        '
        'btnDatosFinanciero
        '
        Me.btnDatosFinanciero.Image = Global.SMUSURA0.My.Resources.Resources.bookmark_folder
        Me.btnDatosFinanciero.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDatosFinanciero.Location = New System.Drawing.Point(534, 0)
        Me.btnDatosFinanciero.Name = "btnDatosFinanciero"
        Me.btnDatosFinanciero.Size = New System.Drawing.Size(96, 42)
        Me.btnDatosFinanciero.TabIndex = 33
        Me.btnDatosFinanciero.Text = "Datos Financiero"
        Me.btnDatosFinanciero.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDatosFinanciero.UseVisualStyleBackColor = True
        '
        'tbReferenciasPersonales
        '
        Me.tbReferenciasPersonales.AutoSize = False
        Me.tbReferenciasPersonales.Dock = System.Windows.Forms.DockStyle.None
        Me.tbReferenciasPersonales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarRP, Me.toolModificarRP, Me.toolEliminarRP, Me.ToolStripSeparator8, Me.toolRefrescarRP, Me.ToolStripSeparator9, Me.toolAyudaRP})
        Me.tbReferenciasPersonales.Location = New System.Drawing.Point(15, 0)
        Me.tbReferenciasPersonales.Name = "tbReferenciasPersonales"
        Me.tbReferenciasPersonales.Size = New System.Drawing.Size(371, 29)
        Me.tbReferenciasPersonales.Stretch = True
        Me.tbReferenciasPersonales.TabIndex = 31
        Me.tbReferenciasPersonales.Text = "ToolStrip1"
        '
        'toolAgregarRP
        '
        Me.toolAgregarRP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarRP.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarRP.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarRP.Name = "toolAgregarRP"
        Me.toolAgregarRP.Size = New System.Drawing.Size(23, 26)
        Me.toolAgregarRP.Text = "Agregar"
        Me.toolAgregarRP.ToolTipText = "Agregar"
        '
        'toolModificarRP
        '
        Me.toolModificarRP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarRP.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarRP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarRP.Name = "toolModificarRP"
        Me.toolModificarRP.Size = New System.Drawing.Size(23, 26)
        Me.toolModificarRP.Text = "Modificar"
        Me.toolModificarRP.ToolTipText = "Modificar"
        '
        'toolEliminarRP
        '
        Me.toolEliminarRP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarRP.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarRP.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarRP.Name = "toolEliminarRP"
        Me.toolEliminarRP.Size = New System.Drawing.Size(23, 26)
        Me.toolEliminarRP.Text = "Eliminar"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 29)
        '
        'toolRefrescarRP
        '
        Me.toolRefrescarRP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarRP.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarRP.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarRP.Name = "toolRefrescarRP"
        Me.toolRefrescarRP.Size = New System.Drawing.Size(23, 26)
        Me.toolRefrescarRP.Text = "Refrescar"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 29)
        '
        'toolAyudaRP
        '
        Me.toolAyudaRP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaRP.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaRP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaRP.Name = "toolAyudaRP"
        Me.toolAyudaRP.Size = New System.Drawing.Size(23, 26)
        Me.toolAyudaRP.Text = "Ayuda"
        Me.toolAyudaRP.ToolTipText = "Ayuda"
        '
        'grdReferenciaComerciales
        '
        Me.grdReferenciaComerciales.AllowFilter = False
        Me.grdReferenciaComerciales.AllowUpdate = False
        Me.grdReferenciaComerciales.Caption = "Referencias Comerciales"
        Me.grdReferenciaComerciales.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdReferenciaComerciales.FilterBar = True
        Me.grdReferenciaComerciales.GroupByAreaVisible = False
        Me.grdReferenciaComerciales.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdReferenciaComerciales.Images.Add(CType(resources.GetObject("grdReferenciaComerciales.Images"), System.Drawing.Image))
        Me.grdReferenciaComerciales.Location = New System.Drawing.Point(17, 426)
        Me.grdReferenciaComerciales.Name = "grdReferenciaComerciales"
        Me.grdReferenciaComerciales.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdReferenciaComerciales.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdReferenciaComerciales.PreviewInfo.ZoomFactor = 75
        Me.grdReferenciaComerciales.PrintInfo.PageSettings = CType(resources.GetObject("grdReferenciaComerciales.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdReferenciaComerciales.Size = New System.Drawing.Size(728, 150)
        Me.grdReferenciaComerciales.TabIndex = 29
        Me.grdReferenciaComerciales.Text = "C1TrueDBGrid1"
        Me.grdReferenciaComerciales.PropBag = resources.GetString("grdReferenciaComerciales.PropBag")
        '
        'grdReferenciaBancaria
        '
        Me.grdReferenciaBancaria.AllowFilter = False
        Me.grdReferenciaBancaria.AllowUpdate = False
        Me.grdReferenciaBancaria.Caption = "Referencias Bancarias"
        Me.grdReferenciaBancaria.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdReferenciaBancaria.FilterBar = True
        Me.grdReferenciaBancaria.GroupByAreaVisible = False
        Me.grdReferenciaBancaria.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdReferenciaBancaria.Images.Add(CType(resources.GetObject("grdReferenciaBancaria.Images"), System.Drawing.Image))
        Me.grdReferenciaBancaria.Location = New System.Drawing.Point(17, 229)
        Me.grdReferenciaBancaria.Name = "grdReferenciaBancaria"
        Me.grdReferenciaBancaria.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdReferenciaBancaria.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdReferenciaBancaria.PreviewInfo.ZoomFactor = 75
        Me.grdReferenciaBancaria.PrintInfo.PageSettings = CType(resources.GetObject("grdReferenciaBancaria.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdReferenciaBancaria.Size = New System.Drawing.Size(728, 153)
        Me.grdReferenciaBancaria.TabIndex = 27
        Me.grdReferenciaBancaria.Text = "C1TrueDBGrid1"
        Me.grdReferenciaBancaria.PropBag = resources.GetString("grdReferenciaBancaria.PropBag")
        '
        'grdReferenciaPersonal
        '
        Me.grdReferenciaPersonal.AllowFilter = False
        Me.grdReferenciaPersonal.AllowUpdate = False
        Me.grdReferenciaPersonal.Caption = "Referencias Personales"
        Me.grdReferenciaPersonal.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdReferenciaPersonal.FilterBar = True
        Me.grdReferenciaPersonal.GroupByAreaVisible = False
        Me.grdReferenciaPersonal.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdReferenciaPersonal.Images.Add(CType(resources.GetObject("grdReferenciaPersonal.Images"), System.Drawing.Image))
        Me.grdReferenciaPersonal.Location = New System.Drawing.Point(15, 43)
        Me.grdReferenciaPersonal.Name = "grdReferenciaPersonal"
        Me.grdReferenciaPersonal.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdReferenciaPersonal.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdReferenciaPersonal.PreviewInfo.ZoomFactor = 75
        Me.grdReferenciaPersonal.PrintInfo.PageSettings = CType(resources.GetObject("grdReferenciaPersonal.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdReferenciaPersonal.Size = New System.Drawing.Size(728, 155)
        Me.grdReferenciaPersonal.TabIndex = 25
        Me.grdReferenciaPersonal.Text = "C1TrueDBGrid1"
        Me.grdReferenciaPersonal.PropBag = resources.GetString("grdReferenciaPersonal.PropBag")
        '
        'tbReferenciasComerciales
        '
        Me.tbReferenciasComerciales.AutoSize = False
        Me.tbReferenciasComerciales.Dock = System.Windows.Forms.DockStyle.None
        Me.tbReferenciasComerciales.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarRCO, Me.toolModificarRCO, Me.toolEliminarRCO, Me.ToolStripSeparator12, Me.toolRefrescarRCO, Me.ToolStripSeparator13, Me.toolAyudaRCOM})
        Me.tbReferenciasComerciales.Location = New System.Drawing.Point(17, 398)
        Me.tbReferenciasComerciales.Name = "tbReferenciasComerciales"
        Me.tbReferenciasComerciales.Size = New System.Drawing.Size(728, 25)
        Me.tbReferenciasComerciales.Stretch = True
        Me.tbReferenciasComerciales.TabIndex = 28
        Me.tbReferenciasComerciales.Text = "ToolStrip1"
        '
        'toolAgregarRCO
        '
        Me.toolAgregarRCO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarRCO.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarRCO.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarRCO.Name = "toolAgregarRCO"
        Me.toolAgregarRCO.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarRCO.Text = "Agregar"
        Me.toolAgregarRCO.ToolTipText = "Agregar"
        '
        'toolModificarRCO
        '
        Me.toolModificarRCO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarRCO.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarRCO.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarRCO.Name = "toolModificarRCO"
        Me.toolModificarRCO.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarRCO.Text = "Modificar"
        Me.toolModificarRCO.ToolTipText = "Modificar"
        '
        'toolEliminarRCO
        '
        Me.toolEliminarRCO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarRCO.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarRCO.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarRCO.Name = "toolEliminarRCO"
        Me.toolEliminarRCO.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarRCO.Text = "Eliminar"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarRCO
        '
        Me.toolRefrescarRCO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarRCO.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarRCO.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarRCO.Name = "toolRefrescarRCO"
        Me.toolRefrescarRCO.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarRCO.Text = "Refrescar"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaRCOM
        '
        Me.toolAyudaRCOM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaRCOM.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaRCOM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaRCOM.Name = "toolAyudaRCOM"
        Me.toolAyudaRCOM.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaRCOM.Text = "Ayuda"
        Me.toolAyudaRCOM.ToolTipText = "Ayuda"
        '
        'tbReferenciasBancarias
        '
        Me.tbReferenciasBancarias.AutoSize = False
        Me.tbReferenciasBancarias.Dock = System.Windows.Forms.DockStyle.None
        Me.tbReferenciasBancarias.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarRB, Me.toolModificarRB, Me.toolEliminarRB, Me.ToolStripSeparator10, Me.toolRefrescarRB, Me.ToolStripSeparator11, Me.toolAyudaRB})
        Me.tbReferenciasBancarias.Location = New System.Drawing.Point(17, 201)
        Me.tbReferenciasBancarias.Name = "tbReferenciasBancarias"
        Me.tbReferenciasBancarias.Size = New System.Drawing.Size(728, 25)
        Me.tbReferenciasBancarias.Stretch = True
        Me.tbReferenciasBancarias.TabIndex = 26
        Me.tbReferenciasBancarias.Text = "ToolStrip1"
        '
        'toolAgregarRB
        '
        Me.toolAgregarRB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarRB.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarRB.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarRB.Name = "toolAgregarRB"
        Me.toolAgregarRB.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarRB.Text = "Agregar"
        Me.toolAgregarRB.ToolTipText = "Agregar"
        '
        'toolModificarRB
        '
        Me.toolModificarRB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarRB.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarRB.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarRB.Name = "toolModificarRB"
        Me.toolModificarRB.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarRB.Text = "Modificar"
        Me.toolModificarRB.ToolTipText = "Modificar"
        '
        'toolEliminarRB
        '
        Me.toolEliminarRB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarRB.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarRB.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarRB.Name = "toolEliminarRB"
        Me.toolEliminarRB.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarRB.Text = "Eliminar"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarRB
        '
        Me.toolRefrescarRB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarRB.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarRB.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarRB.Name = "toolRefrescarRB"
        Me.toolRefrescarRB.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarRB.Text = "Refrescar"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaRB
        '
        Me.toolAyudaRB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaRB.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaRB.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaRB.Name = "toolAyudaRB"
        Me.toolAyudaRB.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaRB.Text = "Ayuda"
        Me.toolAyudaRB.ToolTipText = "Ayuda"
        '
        'frmSclEditMantenimientoFiador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(844, 738)
        Me.Controls.Add(Me.tabFicha)
        Me.Controls.Add(Me.grpDatosGrales)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclEditMantenimientoFiador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento Datos del Fiador"
        CType(Me.errFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosGrales.ResumeLayout(False)
        Me.grpDatosGrales.PerformLayout()
        CType(Me.tabFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabFicha.ResumeLayout(False)
        Me.tabPReferencia.ResumeLayout(False)
        Me.tabPReferencia.PerformLayout()
        Me.tbReferencia.ResumeLayout(False)
        Me.tbReferencia.PerformLayout()
        CType(Me.grdReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPReferenciasPersonales.ResumeLayout(False)
        Me.tbReferenciasPersonales.ResumeLayout(False)
        Me.tbReferenciasPersonales.PerformLayout()
        CType(Me.grdReferenciaComerciales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdReferenciaBancaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdReferenciaPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbReferenciasComerciales.ResumeLayout(False)
        Me.tbReferenciasComerciales.PerformLayout()
        Me.tbReferenciasBancarias.ResumeLayout(False)
        Me.tbReferenciasBancarias.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents errFicha As System.Windows.Forms.ErrorProvider
    Friend WithEvents tabFicha As C1.Win.C1Command.C1DockingTab
    Friend WithEvents tabPReferencia As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents lblSinDisponibilidad As System.Windows.Forms.Label
    Friend WithEvents grpDatosGrales As System.Windows.Forms.GroupBox
    Friend WithEvents txtEstadoRC As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoRC As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoRC As System.Windows.Forms.Label
    Friend WithEvents lblCodigoRC As System.Windows.Forms.Label
    Friend WithEvents tbReferencia As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarRC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarRC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarRC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarRC As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaRC As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdReferencia As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tabPReferenciasPersonales As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tbReferenciasPersonales As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarRP As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarRP As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarRP As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarRP As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaRP As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdReferenciaComerciales As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdReferenciaBancaria As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdReferenciaPersonal As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbReferenciasComerciales As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarRCO As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarRCO As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarRCO As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarRCO As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaRCOM As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbReferenciasBancarias As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarRB As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarRB As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarRB As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarRB As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaRB As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtNombreFiador As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDatosFinanciero As System.Windows.Forms.Button
End Class
