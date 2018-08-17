<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSclPromocion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclPromocion))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.grpBuscar = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.cdeFechaInicio = New C1.Win.C1Input.C1DateEdit()
        Me.cdeFechaFin = New C1.Win.C1Input.C1DateEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.chkSeleccion = New System.Windows.Forms.CheckBox()
        Me.grdPromocion = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbPromocion = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton()
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolEditar = New System.Windows.Forms.ToolStripButton()
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.cboDepartamento = New C1.Win.C1List.C1Combo()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.grpBuscar.SuspendLayout()
        CType(Me.cdeFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPromocion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbPromocion.SuspendLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.Location = New System.Drawing.Point(197, 2)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(830, 23)
        Me.miniToolStrip.Stretch = True
        Me.miniToolStrip.TabIndex = 23
        '
        'grpBuscar
        '
        Me.grpBuscar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpBuscar.Controls.Add(Me.btnBuscar)
        Me.grpBuscar.Controls.Add(Me.cdeFechaInicio)
        Me.grpBuscar.Controls.Add(Me.cdeFechaFin)
        Me.grpBuscar.Controls.Add(Me.Label1)
        Me.grpBuscar.Controls.Add(Me.Label20)
        Me.grpBuscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpBuscar.Location = New System.Drawing.Point(249, 101)
        Me.grpBuscar.Name = "grpBuscar"
        Me.grpBuscar.Size = New System.Drawing.Size(461, 80)
        Me.grpBuscar.TabIndex = 29
        Me.grpBuscar.TabStop = False
        Me.grpBuscar.Text = "Buscar por rango de fechas"
        Me.grpBuscar.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(372, 37)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(65, 25)
        Me.btnBuscar.TabIndex = 131
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'cdeFechaInicio
        '
        Me.cdeFechaInicio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicio.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicio.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicio.Location = New System.Drawing.Point(26, 40)
        Me.cdeFechaInicio.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicio.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicio.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicio.Name = "cdeFechaInicio"
        Me.cdeFechaInicio.Size = New System.Drawing.Size(146, 20)
        Me.cdeFechaInicio.TabIndex = 9
        Me.cdeFechaInicio.Tag = Nothing
        Me.cdeFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaFin
        '
        Me.cdeFechaFin.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaFin.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaFin.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaFin.Location = New System.Drawing.Point(212, 40)
        Me.cdeFechaFin.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaFin.MaskInfo.EmptyAsNull = True
        Me.cdeFechaFin.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaFin.Name = "cdeFechaFin"
        Me.cdeFechaFin.Size = New System.Drawing.Size(146, 20)
        Me.cdeFechaFin.TabIndex = 10
        Me.cdeFechaFin.Tag = Nothing
        Me.cdeFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(209, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Fecha de Fin:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(23, 27)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(83, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Fecha de Inicio:"
        '
        'chkSeleccion
        '
        Me.chkSeleccion.AutoSize = True
        Me.chkSeleccion.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSeleccion.Location = New System.Drawing.Point(20, 100)
        Me.chkSeleccion.Name = "chkSeleccion"
        Me.chkSeleccion.Size = New System.Drawing.Size(15, 17)
        Me.chkSeleccion.TabIndex = 28
        Me.chkSeleccion.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkSeleccion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSeleccion.UseVisualStyleBackColor = True
        '
        'grdPromocion
        '
        Me.grdPromocion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPromocion.Caption = "Listado de Visitas Promoción"
        Me.grdPromocion.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdPromocion.FilterBar = True
        Me.grdPromocion.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdPromocion.Images.Add(CType(resources.GetObject("grdPromocion.Images"), System.Drawing.Image))
        Me.grdPromocion.Location = New System.Drawing.Point(0, 53)
        Me.grdPromocion.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.grdPromocion.Name = "grdPromocion"
        Me.grdPromocion.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPromocion.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPromocion.PreviewInfo.ZoomFactor = 75.0R
        Me.grdPromocion.PrintInfo.PageSettings = CType(resources.GetObject("grdPromocion.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdPromocion.Size = New System.Drawing.Size(936, 517)
        Me.grdPromocion.TabIndex = 26
        Me.grdPromocion.Text = "C1TrueDBGrid1"
        Me.grdPromocion.PropBag = resources.GetString("grdPromocion.PropBag")
        '
        'tbPromocion
        '
        Me.tbPromocion.AutoSize = False
        Me.tbPromocion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.toolBuscar, Me.toolAgregar, Me.toolEditar, Me.toolCerrar, Me.ToolStripSeparator1, Me.toolRefrescar, Me.toolImprimir, Me.ToolStripSeparator2, Me.toolSalir})
        Me.tbPromocion.Location = New System.Drawing.Point(0, 0)
        Me.tbPromocion.Name = "tbPromocion"
        Me.tbPromocion.Size = New System.Drawing.Size(936, 23)
        Me.tbPromocion.Stretch = True
        Me.tbPromocion.TabIndex = 27
        Me.tbPromocion.Text = "ToolStrip1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 20)
        Me.toolBuscar.Text = "Editar Visitas"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 20)
        Me.toolAgregar.Text = "Agregar Informe Promoción"
        '
        'toolEditar
        '
        Me.toolEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEditar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEditar.Name = "toolEditar"
        Me.toolEditar.Size = New System.Drawing.Size(23, 20)
        Me.toolEditar.Text = "Editar Informe Promoción"
        '
        'toolCerrar
        '
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Cerrar16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 20)
        Me.toolCerrar.Text = "Cerrar Informe Promoción"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Enabled = False
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 20)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolImprimir
        '
        Me.toolImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(32, 20)
        Me.toolImprimir.Text = "Impresión de Documentos"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'toolSalir
        '
        Me.toolSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSalir.Name = "toolSalir"
        Me.toolSalir.Size = New System.Drawing.Size(23, 20)
        Me.toolSalir.Text = "ToolStripButton1"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AllowSort = False
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style1
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "Descripcion"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 250
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
        Me.cboDepartamento.Location = New System.Drawing.Point(119, 27)
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
        Me.cboDepartamento.Size = New System.Drawing.Size(201, 21)
        Me.cboDepartamento.Style = Style8
        Me.cboDepartamento.TabIndex = 31
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(36, 27)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 32
        Me.lblDepartamento.Text = "Departamento:"
        '
        'frmSclPromocion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(936, 572)
        Me.Controls.Add(Me.lblDepartamento)
        Me.Controls.Add(Me.cboDepartamento)
        Me.Controls.Add(Me.grpBuscar)
        Me.Controls.Add(Me.chkSeleccion)
        Me.Controls.Add(Me.grdPromocion)
        Me.Controls.Add(Me.tbPromocion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclPromocion"
        Me.Text = "Promoción"
        Me.grpBuscar.ResumeLayout(False)
        Me.grpBuscar.PerformLayout()
        CType(Me.cdeFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPromocion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbPromocion.ResumeLayout(False)
        Me.tbPromocion.PerformLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents miniToolStrip As ToolStrip
    Friend WithEvents grpBuscar As GroupBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents cdeFechaFin As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicio As C1.Win.C1Input.C1DateEdit
    Friend WithEvents chkSeleccion As CheckBox
    Friend WithEvents grdPromocion As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbPromocion As ToolStrip
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents toolBuscar As ToolStripButton
    Friend WithEvents toolAgregar As ToolStripButton
    Friend WithEvents toolEditar As ToolStripButton
    Friend WithEvents toolCerrar As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents toolRefrescar As ToolStripButton
    Friend WithEvents toolImprimir As ToolStripSplitButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents toolSalir As ToolStripButton
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As Label
End Class
