<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclGrupoSolidario
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclGrupoSolidario))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.tbSocia = New System.Windows.Forms.ToolStrip()
        Me.toolAgregarS = New System.Windows.Forms.ToolStripButton()
        Me.toolModificarS = New System.Windows.Forms.ToolStripButton()
        Me.toolEliminarS = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolCambiarCoordinador = New System.Windows.Forms.ToolStripButton()
        Me.toolDenegarCredito = New System.Windows.Forms.ToolStripButton()
        Me.toolAyudaS = New System.Windows.Forms.ToolStripButton()
        Me.grpGenerales = New System.Windows.Forms.GroupBox()
        Me.cboDepartamento = New C1.Win.C1List.C1Combo()
        Me.lblFechaD = New System.Windows.Forms.Label()
        Me.grdSocias = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdGS = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbGrupoSolidario = New System.Windows.Forms.ToolStrip()
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolModificar = New System.Windows.Forms.ToolStripButton()
        Me.toolAnular = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolImprimirL = New System.Windows.Forms.ToolStripButton()
        Me.toolImprimirA = New System.Windows.Forms.ToolStripButton()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbSocia.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdGS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbGrupoSolidario.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.tbSocia)
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdSocias)
        Me.C1Sizer1.Controls.Add(Me.grdGS)
        Me.C1Sizer1.Controls.Add(Me.tbGrupoSolidario)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(664, 435)
        Me.C1Sizer1.TabIndex = 1
        Me.C1Sizer1.TabStop = False
        '
        'tbSocia
        '
        Me.tbSocia.AutoSize = False
        Me.tbSocia.Dock = System.Windows.Forms.DockStyle.None
        Me.tbSocia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarS, Me.toolModificarS, Me.toolEliminarS, Me.toolSeparator2, Me.toolCambiarCoordinador, Me.toolDenegarCredito, Me.toolAyudaS})
        Me.tbSocia.Location = New System.Drawing.Point(4, 244)
        Me.tbSocia.Name = "tbSocia"
        Me.tbSocia.Size = New System.Drawing.Size(409, 23)
        Me.tbSocia.Stretch = True
        Me.tbSocia.TabIndex = 20
        Me.tbSocia.Text = "ToolStrip1"
        '
        'toolAgregarS
        '
        Me.toolAgregarS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarS.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarS.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarS.Name = "toolAgregarS"
        Me.toolAgregarS.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregarS.Text = "Agregar"
        Me.toolAgregarS.ToolTipText = "Agregar Socia"
        '
        'toolModificarS
        '
        Me.toolModificarS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarS.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarS.Name = "toolModificarS"
        Me.toolModificarS.Size = New System.Drawing.Size(23, 20)
        Me.toolModificarS.Text = "Modificar"
        Me.toolModificarS.ToolTipText = "Modificar Socia"
        '
        'toolEliminarS
        '
        Me.toolEliminarS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarS.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarS.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarS.Name = "toolEliminarS"
        Me.toolEliminarS.Size = New System.Drawing.Size(23, 20)
        Me.toolEliminarS.Text = "Eliminar"
        Me.toolEliminarS.ToolTipText = "Eliminar Socia"
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolCambiarCoordinador
        '
        Me.toolCambiarCoordinador.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCambiarCoordinador.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolCambiarCoordinador.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCambiarCoordinador.Name = "toolCambiarCoordinador"
        Me.toolCambiarCoordinador.Size = New System.Drawing.Size(23, 20)
        Me.toolCambiarCoordinador.Text = "Cambiar Coordinadora"
        '
        'toolDenegarCredito
        '
        Me.toolDenegarCredito.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolDenegarCredito.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolDenegarCredito.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolDenegarCredito.Name = "toolDenegarCredito"
        Me.toolDenegarCredito.Size = New System.Drawing.Size(23, 20)
        Me.toolDenegarCredito.Text = "Denegar Crédito a Socia"
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
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cboDepartamento)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 31)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(656, 40)
        Me.grpGenerales.TabIndex = 19
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione el Departamento:  "
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style1
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "sNombre"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 170
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.EvenRowStyle = Style2
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style3
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style4
        Me.cboDepartamento.HighLightRowStyle = Style5
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(330, 13)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style6
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style7
        Me.cboDepartamento.Size = New System.Drawing.Size(160, 21)
        Me.cboDepartamento.Style = Style8
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 33
        Me.cboDepartamento.ValueMember = "nStbDepartamentoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(183, 16)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(152, 13)
        Me.lblFechaD.TabIndex = 32
        Me.lblFechaD.Text = "Departamento Grupo Solidario:"
        '
        'grdSocias
        '
        Me.grdSocias.AllowFilter = False
        Me.grdSocias.AllowUpdate = False
        Me.grdSocias.Caption = "Listado de Socias del Grupo Solidario"
        Me.grdSocias.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSocias.FilterBar = True
        Me.grdSocias.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSocias.Images.Add(CType(resources.GetObject("grdSocias.Images"), System.Drawing.Image))
        Me.grdSocias.Location = New System.Drawing.Point(4, 271)
        Me.grdSocias.Name = "grdSocias"
        Me.grdSocias.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSocias.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSocias.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSocias.PrintInfo.PageSettings = CType(resources.GetObject("grdSocias.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocias.Size = New System.Drawing.Size(656, 160)
        Me.grdSocias.TabIndex = 14
        Me.grdSocias.Text = "grdModulo"
        Me.grdSocias.PropBag = resources.GetString("grdSocias.PropBag")
        '
        'grdGS
        '
        Me.grdGS.AllowFilter = False
        Me.grdGS.AllowUpdate = False
        Me.grdGS.Caption = "Listado de Grupos Solidarios"
        Me.grdGS.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdGS.FilterBar = True
        Me.grdGS.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdGS.Images.Add(CType(resources.GetObject("grdGS.Images"), System.Drawing.Image))
        Me.grdGS.Location = New System.Drawing.Point(4, 75)
        Me.grdGS.Name = "grdGS"
        Me.grdGS.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdGS.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdGS.PreviewInfo.ZoomFactor = 75.0R
        Me.grdGS.PrintInfo.PageSettings = CType(resources.GetObject("grdGS.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdGS.Size = New System.Drawing.Size(656, 165)
        Me.grdGS.TabIndex = 13
        Me.grdGS.Text = "grdDocSoporte"
        Me.grdGS.PropBag = resources.GetString("grdGS.PropBag")
        '
        'tbGrupoSolidario
        '
        Me.tbGrupoSolidario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.ToolStripSeparator1, Me.toolAgregar, Me.toolModificar, Me.toolAnular, Me.ToolStripButton7, Me.toolRefrescar, Me.toolImprimirL, Me.toolImprimirA, Me.toolSeparator3, Me.toolAyuda, Me.toolSalir})
        Me.tbGrupoSolidario.Location = New System.Drawing.Point(0, 0)
        Me.tbGrupoSolidario.Name = "tbGrupoSolidario"
        Me.tbGrupoSolidario.Size = New System.Drawing.Size(664, 25)
        Me.tbGrupoSolidario.Stretch = True
        Me.tbGrupoSolidario.TabIndex = 12
        Me.tbGrupoSolidario.Text = "ToolStrip1"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 22)
        Me.toolBuscar.Text = "Buscar Grupos Solidarios"
        Me.toolBuscar.ToolTipText = "Buscar Grupo Solidario"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        Me.toolRefrescar.Visible = False
        '
        'toolImprimirL
        '
        Me.toolImprimirL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirL.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirL.Name = "toolImprimirL"
        Me.toolImprimirL.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirL.Text = "ToolStripButton1"
        Me.toolImprimirL.ToolTipText = "Imprimir Listado"
        '
        'toolImprimirA
        '
        Me.toolImprimirA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirA.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirA.Name = "toolImprimirA"
        Me.toolImprimirA.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirA.Text = "ToolStripButton1"
        Me.toolImprimirA.ToolTipText = "Imprimir Acta Compromiso"
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
        'frmSclGrupoSolidario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 435)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Grupos Solidarios")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclGrupoSolidario"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "  Mantenimiento Grupo Solidario"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.tbSocia.ResumeLayout(False)
        Me.tbSocia.PerformLayout()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdGS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbGrupoSolidario.ResumeLayout(False)
        Me.tbGrupoSolidario.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents grdSocias As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdGS As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbGrupoSolidario As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSalir As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirA As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirL As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents tbSocia As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregarS As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarS As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarS As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolCambiarCoordinador As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolDenegarCredito As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAyudaS As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
