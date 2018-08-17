<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclSeguimientoVisitas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclSeguimientoVisitas))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer()
        Me.ckCA1 = New System.Windows.Forms.CheckBox()
        Me.ckCA2 = New System.Windows.Forms.CheckBox()
        Me.tbSalir = New System.Windows.Forms.ToolStrip()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.tbVisitas = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolAgregarDetalle = New System.Windows.Forms.ToolStripSplitButton()
        Me.AgregarPrimeraVisitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegundaVisitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerceraVisitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolInactivar = New System.Windows.Forms.ToolStripSplitButton()
        Me.PrimeraVisitaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegundaVisitaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerceraVisitaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolNoEncontrada = New System.Windows.Forms.ToolStripSplitButton()
        Me.PrimeraVisitaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegundaVisitaToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TerceraVisitaToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboFiltro = New System.Windows.Forms.ToolStripComboBox()
        Me.toolRefrescar2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.toolMnuCS67 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnNext = New System.Windows.Forms.PictureBox()
        Me.btnBack = New System.Windows.Forms.PictureBox()
        Me.grdVisitas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbFicha = New System.Windows.Forms.ToolStrip()
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.grdSocias = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.tbSalir.SuspendLayout()
        Me.tbVisitas.SuspendLayout()
        CType(Me.btnNext, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdVisitas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbFicha.SuspendLayout()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.ckCA1)
        Me.C1Sizer1.Controls.Add(Me.ckCA2)
        Me.C1Sizer1.Controls.Add(Me.tbSalir)
        Me.C1Sizer1.Controls.Add(Me.tbVisitas)
        Me.C1Sizer1.Controls.Add(Me.btnNext)
        Me.C1Sizer1.Controls.Add(Me.btnBack)
        Me.C1Sizer1.Controls.Add(Me.grdVisitas)
        Me.C1Sizer1.Controls.Add(Me.tbFicha)
        Me.C1Sizer1.Controls.Add(Me.grdSocias)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(935, 696)
        Me.C1Sizer1.TabIndex = 5
        Me.C1Sizer1.TabStop = False
        '
        'ckCA1
        '
        Me.ckCA1.Location = New System.Drawing.Point(4, 4)
        Me.ckCA1.Name = "ckCA1"
        Me.ckCA1.Size = New System.Drawing.Size(15, 22)
        Me.ckCA1.TabIndex = 25
        Me.ckCA1.UseVisualStyleBackColor = True
        '
        'ckCA2
        '
        Me.ckCA2.Location = New System.Drawing.Point(513, 4)
        Me.ckCA2.Name = "ckCA2"
        Me.ckCA2.Size = New System.Drawing.Size(13, 26)
        Me.ckCA2.TabIndex = 24
        Me.ckCA2.UseVisualStyleBackColor = True
        '
        'tbSalir
        '
        Me.tbSalir.AutoSize = False
        Me.tbSalir.Dock = System.Windows.Forms.DockStyle.None
        Me.tbSalir.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolSalir})
        Me.tbSalir.Location = New System.Drawing.Point(453, 4)
        Me.tbSalir.Name = "tbSalir"
        Me.tbSalir.Size = New System.Drawing.Size(56, 22)
        Me.tbSalir.Stretch = True
        Me.tbSalir.TabIndex = 23
        Me.tbSalir.Text = "ToolStrip1"
        '
        'toolSalir
        '
        Me.toolSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSalir.Name = "toolSalir"
        Me.toolSalir.Size = New System.Drawing.Size(23, 19)
        Me.toolSalir.Text = "Salir"
        '
        'tbVisitas
        '
        Me.tbVisitas.AutoSize = False
        Me.tbVisitas.Dock = System.Windows.Forms.DockStyle.None
        Me.tbVisitas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.toolAgregarDetalle, Me.toolInactivar, Me.toolNoEncontrada, Me.cboFiltro, Me.toolRefrescar2, Me.ToolStripSeparator1, Me.ToolStripSplitButton1, Me.ToolStripSeparator2})
        Me.tbVisitas.Location = New System.Drawing.Point(530, 4)
        Me.tbVisitas.Name = "tbVisitas"
        Me.tbVisitas.Size = New System.Drawing.Size(401, 22)
        Me.tbVisitas.Stretch = True
        Me.tbVisitas.TabIndex = 22
        Me.tbVisitas.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 22)
        '
        'toolAgregarDetalle
        '
        Me.toolAgregarDetalle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarDetalle.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarPrimeraVisitaToolStripMenuItem, Me.SegundaVisitaToolStripMenuItem, Me.TerceraVisitaToolStripMenuItem})
        Me.toolAgregarDetalle.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.toolAgregarDetalle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregarDetalle.Name = "toolAgregarDetalle"
        Me.toolAgregarDetalle.Size = New System.Drawing.Size(32, 19)
        Me.toolAgregarDetalle.Text = "Editar Visitas"
        '
        'AgregarPrimeraVisitaToolStripMenuItem
        '
        Me.AgregarPrimeraVisitaToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.AgregarPrimeraVisitaToolStripMenuItem.Name = "AgregarPrimeraVisitaToolStripMenuItem"
        Me.AgregarPrimeraVisitaToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.AgregarPrimeraVisitaToolStripMenuItem.Text = "Primera Visita"
        '
        'SegundaVisitaToolStripMenuItem
        '
        Me.SegundaVisitaToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.SegundaVisitaToolStripMenuItem.Name = "SegundaVisitaToolStripMenuItem"
        Me.SegundaVisitaToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.SegundaVisitaToolStripMenuItem.Text = "Segunda Visita"
        '
        'TerceraVisitaToolStripMenuItem
        '
        Me.TerceraVisitaToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.TerceraVisitaToolStripMenuItem.Name = "TerceraVisitaToolStripMenuItem"
        Me.TerceraVisitaToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TerceraVisitaToolStripMenuItem.Text = "Tercera Visita"
        '
        'toolInactivar
        '
        Me.toolInactivar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolInactivar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrimeraVisitaToolStripMenuItem, Me.SegundaVisitaToolStripMenuItem1, Me.TerceraVisitaToolStripMenuItem1})
        Me.toolInactivar.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.toolInactivar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolInactivar.Name = "toolInactivar"
        Me.toolInactivar.Size = New System.Drawing.Size(32, 19)
        Me.toolInactivar.Text = "Negocio Inactivo"
        '
        'PrimeraVisitaToolStripMenuItem
        '
        Me.PrimeraVisitaToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.PrimeraVisitaToolStripMenuItem.Name = "PrimeraVisitaToolStripMenuItem"
        Me.PrimeraVisitaToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.PrimeraVisitaToolStripMenuItem.Text = "Primera Visita"
        '
        'SegundaVisitaToolStripMenuItem1
        '
        Me.SegundaVisitaToolStripMenuItem1.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.SegundaVisitaToolStripMenuItem1.Name = "SegundaVisitaToolStripMenuItem1"
        Me.SegundaVisitaToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.SegundaVisitaToolStripMenuItem1.Text = "Segunda Visita"
        '
        'TerceraVisitaToolStripMenuItem1
        '
        Me.TerceraVisitaToolStripMenuItem1.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.TerceraVisitaToolStripMenuItem1.Name = "TerceraVisitaToolStripMenuItem1"
        Me.TerceraVisitaToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.TerceraVisitaToolStripMenuItem1.Text = "Tercera Visita"
        '
        'toolNoEncontrada
        '
        Me.toolNoEncontrada.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolNoEncontrada.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PrimeraVisitaToolStripMenuItem1, Me.SegundaVisitaToolStripMenuItem2, Me.TerceraVisitaToolStripMenuItem2})
        Me.toolNoEncontrada.Image = Global.SMUSURA0.My.Resources.Resources.error_g
        Me.toolNoEncontrada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolNoEncontrada.Name = "toolNoEncontrada"
        Me.toolNoEncontrada.Size = New System.Drawing.Size(32, 19)
        Me.toolNoEncontrada.Text = "No encontrada"
        '
        'PrimeraVisitaToolStripMenuItem1
        '
        Me.PrimeraVisitaToolStripMenuItem1.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.PrimeraVisitaToolStripMenuItem1.Name = "PrimeraVisitaToolStripMenuItem1"
        Me.PrimeraVisitaToolStripMenuItem1.Size = New System.Drawing.Size(151, 22)
        Me.PrimeraVisitaToolStripMenuItem1.Text = "Primera Visita"
        '
        'SegundaVisitaToolStripMenuItem2
        '
        Me.SegundaVisitaToolStripMenuItem2.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.SegundaVisitaToolStripMenuItem2.Name = "SegundaVisitaToolStripMenuItem2"
        Me.SegundaVisitaToolStripMenuItem2.Size = New System.Drawing.Size(151, 22)
        Me.SegundaVisitaToolStripMenuItem2.Text = "Segunda Visita"
        '
        'TerceraVisitaToolStripMenuItem2
        '
        Me.TerceraVisitaToolStripMenuItem2.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.TerceraVisitaToolStripMenuItem2.Name = "TerceraVisitaToolStripMenuItem2"
        Me.TerceraVisitaToolStripMenuItem2.Size = New System.Drawing.Size(151, 22)
        Me.TerceraVisitaToolStripMenuItem2.Text = "Tercera Visita"
        '
        'cboFiltro
        '
        Me.cboFiltro.Items.AddRange(New Object() {"(Vacío)", "(Sin Filtro)", "Todos Primera Visita", "Todos Segunda Visita", "Todos Tercera Visita", "Pendientes de Grabar Primera Visita", "Pendientes de Grabar Segunda Visita", "Pendientes de Grabar Tercera Visita", "Encontradas Cualquier Visita", "Encontradas Primera Visita", "Encontradas Segunda Visita", "Encontradas Tercera Visita", "Inactivos Cualquier Visita", "Inactivos Primera Visita", "Inactivos Segunda Visita", "Inactivos Tercera Visita", "No Encontradas Cualquier Visita", "No Encontradas Primera Visita", "No Encontradas Segunda Visita", "No Encontradas Tercera Visita"})
        Me.cboFiltro.Name = "cboFiltro"
        Me.cboFiltro.Size = New System.Drawing.Size(200, 22)
        '
        'toolRefrescar2
        '
        Me.toolRefrescar2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar2.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar2.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar2.Name = "toolRefrescar2"
        Me.toolRefrescar2.Size = New System.Drawing.Size(23, 19)
        Me.toolRefrescar2.Text = "Refrescar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 22)
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolMnuCS67})
        Me.ToolStripSplitButton1.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 19)
        Me.ToolStripSplitButton1.Text = "Impresión de Documentos"
        '
        'toolMnuCS67
        '
        Me.toolMnuCS67.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.toolMnuCS67.Name = "toolMnuCS67"
        Me.toolMnuCS67.Size = New System.Drawing.Size(301, 22)
        Me.toolMnuCS67.Text = "Ficha de Seguimiento a Protagonistas CS67"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 22)
        '
        'btnNext
        '
        Me.btnNext.Image = Global.SMUSURA0.My.Resources.Resources.next_1
        Me.btnNext.Location = New System.Drawing.Point(453, 246)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(56, 49)
        Me.btnNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnNext.TabIndex = 21
        Me.btnNext.TabStop = False
        '
        'btnBack
        '
        Me.btnBack.Image = Global.SMUSURA0.My.Resources.Resources.back_1
        Me.btnBack.Location = New System.Drawing.Point(453, 299)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(56, 49)
        Me.btnBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.btnBack.TabIndex = 20
        Me.btnBack.TabStop = False
        '
        'grdVisitas
        '
        Me.grdVisitas.Caption = "Listado de Visitas"
        Me.grdVisitas.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdVisitas.FilterBar = True
        Me.grdVisitas.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdVisitas.Images.Add(CType(resources.GetObject("grdVisitas.Images"), System.Drawing.Image))
        Me.grdVisitas.Location = New System.Drawing.Point(513, 34)
        Me.grdVisitas.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.grdVisitas.Name = "grdVisitas"
        Me.grdVisitas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdVisitas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdVisitas.PreviewInfo.ZoomFactor = 75.0R
        Me.grdVisitas.PrintInfo.PageSettings = CType(resources.GetObject("grdVisitas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdVisitas.Size = New System.Drawing.Size(418, 658)
        Me.grdVisitas.TabIndex = 19
        Me.grdVisitas.Text = "C1TrueDBGrid1"
        Me.grdVisitas.PropBag = resources.GetString("grdVisitas.PropBag")
        '
        'tbFicha
        '
        Me.tbFicha.AutoSize = False
        Me.tbFicha.Dock = System.Windows.Forms.DockStyle.None
        Me.tbFicha.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.ToolStripSeparator7, Me.toolRefrescar})
        Me.tbFicha.Location = New System.Drawing.Point(23, 4)
        Me.tbFicha.Name = "tbFicha"
        Me.tbFicha.Size = New System.Drawing.Size(426, 22)
        Me.tbFicha.Stretch = True
        Me.tbFicha.TabIndex = 18
        Me.tbFicha.Text = "ToolStrip1"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 19)
        Me.toolBuscar.Text = "Filtrar Socias"
        Me.toolBuscar.ToolTipText = "Buscar Ficha"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 22)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 19)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'grdSocias
        '
        Me.grdSocias.AllowColSelect = False
        Me.grdSocias.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdSocias.Caption = "Listado de socias filtradas"
        Me.grdSocias.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSocias.FilterBar = True
        Me.grdSocias.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSocias.Images.Add(CType(resources.GetObject("grdSocias.Images"), System.Drawing.Image))
        Me.grdSocias.Location = New System.Drawing.Point(4, 34)
        Me.grdSocias.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.grdSocias.Name = "grdSocias"
        Me.grdSocias.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSocias.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSocias.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSocias.PrintInfo.PageSettings = CType(resources.GetObject("grdSocias.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocias.Size = New System.Drawing.Size(445, 658)
        Me.grdSocias.TabIndex = 2
        Me.grdSocias.PropBag = resources.GetString("grdSocias.PropBag")
        '
        'frmSclSeguimientoVisitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 696)
        Me.Controls.Add(Me.C1Sizer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "frmSclSeguimientoVisitas"
        Me.Text = "Seguimiento a Visitas"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.tbSalir.ResumeLayout(False)
        Me.tbSalir.PerformLayout()
        Me.tbVisitas.ResumeLayout(False)
        Me.tbVisitas.PerformLayout()
        CType(Me.btnNext, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnBack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdVisitas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbFicha.ResumeLayout(False)
        Me.tbFicha.PerformLayout()
        CType(Me.grdSocias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents grdSocias As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbFicha As ToolStrip
    Friend WithEvents toolBuscar As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents toolRefrescar As ToolStripButton
    Friend WithEvents btnNext As PictureBox
    Friend WithEvents btnBack As PictureBox
    Friend WithEvents grdVisitas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbVisitas As ToolStrip
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSplitButton1 As ToolStripSplitButton
    Friend WithEvents toolMnuCS67 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents toolRefrescar2 As ToolStripButton
    Friend WithEvents tbSalir As ToolStrip
    Friend WithEvents toolSalir As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ckCA2 As CheckBox
    Friend WithEvents ckCA1 As CheckBox
    Friend WithEvents toolAgregarDetalle As ToolStripSplitButton
    Friend WithEvents AgregarPrimeraVisitaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SegundaVisitaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TerceraVisitaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolInactivar As ToolStripSplitButton
    Friend WithEvents toolNoEncontrada As ToolStripSplitButton
    Friend WithEvents PrimeraVisitaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SegundaVisitaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TerceraVisitaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PrimeraVisitaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SegundaVisitaToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents TerceraVisitaToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents cboFiltro As ToolStripComboBox
End Class
