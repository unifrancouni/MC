<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbParametroTasaCambio
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbParametroTasaCambio))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.cdeFechaHasta = New C1.Win.C1Input.C1DateEdit
        Me.lblHasta = New System.Windows.Forms.Label
        Me.cdeFechaDesde = New C1.Win.C1Input.C1DateEdit
        Me.lblDesde = New System.Windows.Forms.Label
        Me.cboMonedaCambio = New C1.Win.C1List.C1Combo
        Me.lblMonedaCambio = New System.Windows.Forms.Label
        Me.cboMonedaBase = New C1.Win.C1List.C1Combo
        Me.lblMonedaBase = New System.Windows.Forms.Label
        Me.grpdestino = New System.Windows.Forms.GroupBox
        Me.RadArchivo = New System.Windows.Forms.RadioButton
        Me.RadImpresora = New System.Windows.Forms.RadioButton
        Me.radPantalla = New System.Windows.Forms.RadioButton
        Me.Exportar = New System.Windows.Forms.SaveFileDialog
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpdatos.SuspendLayout()
        CType(Me.cdeFechaHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMonedaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMonedaBase, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdestino.SuspendLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.cdeFechaHasta)
        Me.grpdatos.Controls.Add(Me.lblHasta)
        Me.grpdatos.Controls.Add(Me.cdeFechaDesde)
        Me.grpdatos.Controls.Add(Me.lblDesde)
        Me.grpdatos.Controls.Add(Me.cboMonedaCambio)
        Me.grpdatos.Controls.Add(Me.lblMonedaCambio)
        Me.grpdatos.Controls.Add(Me.cboMonedaBase)
        Me.grpdatos.Controls.Add(Me.lblMonedaBase)
        Me.grpdatos.Location = New System.Drawing.Point(10, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(444, 135)
        Me.grpdatos.TabIndex = 0
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'cdeFechaHasta
        '
        Me.cdeFechaHasta.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaHasta.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaHasta.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaHasta.Location = New System.Drawing.Point(141, 99)
        Me.cdeFechaHasta.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaHasta.MaskInfo.EmptyAsNull = True
        Me.cdeFechaHasta.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaHasta.Name = "cdeFechaHasta"
        Me.cdeFechaHasta.Size = New System.Drawing.Size(96, 20)
        Me.cdeFechaHasta.TabIndex = 3
        Me.cdeFechaHasta.Tag = Nothing
        Me.cdeFechaHasta.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblHasta
        '
        Me.lblHasta.AutoSize = True
        Me.lblHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblHasta.Location = New System.Drawing.Point(16, 106)
        Me.lblHasta.Name = "lblHasta"
        Me.lblHasta.Size = New System.Drawing.Size(38, 13)
        Me.lblHasta.TabIndex = 121
        Me.lblHasta.Text = "Hasta:"
        '
        'cdeFechaDesde
        '
        Me.cdeFechaDesde.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaDesde.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaDesde.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaDesde.Location = New System.Drawing.Point(141, 73)
        Me.cdeFechaDesde.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaDesde.MaskInfo.EmptyAsNull = True
        Me.cdeFechaDesde.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaDesde.Name = "cdeFechaDesde"
        Me.cdeFechaDesde.Size = New System.Drawing.Size(96, 20)
        Me.cdeFechaDesde.TabIndex = 2
        Me.cdeFechaDesde.Tag = Nothing
        Me.cdeFechaDesde.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblDesde
        '
        Me.lblDesde.AutoSize = True
        Me.lblDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDesde.Location = New System.Drawing.Point(16, 80)
        Me.lblDesde.Name = "lblDesde"
        Me.lblDesde.Size = New System.Drawing.Size(41, 13)
        Me.lblDesde.TabIndex = 120
        Me.lblDesde.Text = "Desde:"
        '
        'cboMonedaCambio
        '
        Me.cboMonedaCambio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMonedaCambio.AutoCompletion = True
        Me.cboMonedaCambio.Caption = ""
        Me.cboMonedaCambio.CaptionHeight = 17
        Me.cboMonedaCambio.CaptionStyle = Style1
        Me.cboMonedaCambio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMonedaCambio.ColumnCaptionHeight = 17
        Me.cboMonedaCambio.ColumnFooterHeight = 17
        Me.cboMonedaCambio.ContentHeight = 15
        Me.cboMonedaCambio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMonedaCambio.DisplayMember = "sDescripcion"
        Me.cboMonedaCambio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMonedaCambio.DropDownWidth = 188
        Me.cboMonedaCambio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMonedaCambio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonedaCambio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMonedaCambio.EditorHeight = 15
        Me.cboMonedaCambio.EvenRowStyle = Style2
        Me.cboMonedaCambio.ExtendRightColumn = True
        Me.cboMonedaCambio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMonedaCambio.FooterStyle = Style3
        Me.cboMonedaCambio.GapHeight = 2
        Me.cboMonedaCambio.HeadingStyle = Style4
        Me.cboMonedaCambio.HighLightRowStyle = Style5
        Me.cboMonedaCambio.Images.Add(CType(resources.GetObject("cboMonedaCambio.Images"), System.Drawing.Image))
        Me.cboMonedaCambio.ItemHeight = 15
        Me.cboMonedaCambio.LimitToList = True
        Me.cboMonedaCambio.Location = New System.Drawing.Point(141, 46)
        Me.cboMonedaCambio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMonedaCambio.MaxDropDownItems = CType(5, Short)
        Me.cboMonedaCambio.MaxLength = 32767
        Me.cboMonedaCambio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMonedaCambio.Name = "cboMonedaCambio"
        Me.cboMonedaCambio.OddRowStyle = Style6
        Me.cboMonedaCambio.PartialRightColumn = False
        Me.cboMonedaCambio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMonedaCambio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMonedaCambio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMonedaCambio.SelectedStyle = Style7
        Me.cboMonedaCambio.Size = New System.Drawing.Size(168, 21)
        Me.cboMonedaCambio.Style = Style8
        Me.cboMonedaCambio.SuperBack = True
        Me.cboMonedaCambio.TabIndex = 1
        Me.cboMonedaCambio.ValueMember = "StbValorCatalogoID"
        Me.cboMonedaCambio.PropBag = resources.GetString("cboMonedaCambio.PropBag")
        '
        'lblMonedaCambio
        '
        Me.lblMonedaCambio.AutoSize = True
        Me.lblMonedaCambio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonedaCambio.Location = New System.Drawing.Point(16, 54)
        Me.lblMonedaCambio.Name = "lblMonedaCambio"
        Me.lblMonedaCambio.Size = New System.Drawing.Size(87, 13)
        Me.lblMonedaCambio.TabIndex = 34
        Me.lblMonedaCambio.Text = "Moneda Cambio:"
        '
        'cboMonedaBase
        '
        Me.cboMonedaBase.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMonedaBase.AutoCompletion = True
        Me.cboMonedaBase.Caption = ""
        Me.cboMonedaBase.CaptionHeight = 17
        Me.cboMonedaBase.CaptionStyle = Style9
        Me.cboMonedaBase.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMonedaBase.ColumnCaptionHeight = 17
        Me.cboMonedaBase.ColumnFooterHeight = 17
        Me.cboMonedaBase.ContentHeight = 15
        Me.cboMonedaBase.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMonedaBase.DisplayMember = "sDescripcion"
        Me.cboMonedaBase.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMonedaBase.DropDownWidth = 153
        Me.cboMonedaBase.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMonedaBase.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMonedaBase.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMonedaBase.EditorHeight = 15
        Me.cboMonedaBase.EvenRowStyle = Style10
        Me.cboMonedaBase.ExtendRightColumn = True
        Me.cboMonedaBase.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMonedaBase.FooterStyle = Style11
        Me.cboMonedaBase.GapHeight = 2
        Me.cboMonedaBase.HeadingStyle = Style12
        Me.cboMonedaBase.HighLightRowStyle = Style13
        Me.cboMonedaBase.Images.Add(CType(resources.GetObject("cboMonedaBase.Images"), System.Drawing.Image))
        Me.cboMonedaBase.ItemHeight = 15
        Me.cboMonedaBase.LimitToList = True
        Me.cboMonedaBase.Location = New System.Drawing.Point(141, 19)
        Me.cboMonedaBase.MatchEntryTimeout = CType(2000, Long)
        Me.cboMonedaBase.MaxDropDownItems = CType(5, Short)
        Me.cboMonedaBase.MaxLength = 32767
        Me.cboMonedaBase.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMonedaBase.Name = "cboMonedaBase"
        Me.cboMonedaBase.OddRowStyle = Style14
        Me.cboMonedaBase.PartialRightColumn = False
        Me.cboMonedaBase.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMonedaBase.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMonedaBase.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMonedaBase.SelectedStyle = Style15
        Me.cboMonedaBase.Size = New System.Drawing.Size(168, 21)
        Me.cboMonedaBase.Style = Style16
        Me.cboMonedaBase.SuperBack = True
        Me.cboMonedaBase.TabIndex = 0
        Me.cboMonedaBase.ValueMember = "StbValorCatalogoID"
        Me.cboMonedaBase.PropBag = resources.GetString("cboMonedaBase.PropBag")
        '
        'lblMonedaBase
        '
        Me.lblMonedaBase.AutoSize = True
        Me.lblMonedaBase.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonedaBase.Location = New System.Drawing.Point(16, 27)
        Me.lblMonedaBase.Name = "lblMonedaBase"
        Me.lblMonedaBase.Size = New System.Drawing.Size(76, 13)
        Me.lblMonedaBase.TabIndex = 7
        Me.lblMonedaBase.Text = "Moneda Base:"
        '
        'grpdestino
        '
        Me.grpdestino.Controls.Add(Me.RadArchivo)
        Me.grpdestino.Controls.Add(Me.RadImpresora)
        Me.grpdestino.Controls.Add(Me.radPantalla)
        Me.grpdestino.Location = New System.Drawing.Point(10, 153)
        Me.grpdestino.Name = "grpdestino"
        Me.grpdestino.Size = New System.Drawing.Size(444, 57)
        Me.grpdestino.TabIndex = 1
        Me.grpdestino.TabStop = False
        Me.grpdestino.Text = "Destino del Reporte"
        '
        'RadArchivo
        '
        Me.RadArchivo.AutoSize = True
        Me.RadArchivo.Location = New System.Drawing.Point(185, 22)
        Me.RadArchivo.Name = "RadArchivo"
        Me.RadArchivo.Size = New System.Drawing.Size(61, 17)
        Me.RadArchivo.TabIndex = 2
        Me.RadArchivo.Text = "Archivo"
        Me.RadArchivo.UseVisualStyleBackColor = True
        '
        'RadImpresora
        '
        Me.RadImpresora.AutoSize = True
        Me.RadImpresora.Location = New System.Drawing.Point(97, 22)
        Me.RadImpresora.Name = "RadImpresora"
        Me.RadImpresora.Size = New System.Drawing.Size(71, 17)
        Me.RadImpresora.TabIndex = 1
        Me.RadImpresora.Text = "Impresora"
        Me.RadImpresora.UseVisualStyleBackColor = True
        '
        'radPantalla
        '
        Me.radPantalla.AutoSize = True
        Me.radPantalla.Checked = True
        Me.radPantalla.Location = New System.Drawing.Point(9, 22)
        Me.radPantalla.Name = "radPantalla"
        Me.radPantalla.Size = New System.Drawing.Size(63, 17)
        Me.radPantalla.TabIndex = 0
        Me.radPantalla.TabStop = True
        Me.radPantalla.Text = "Pantalla"
        Me.radPantalla.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(383, 216)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(311, 216)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 2
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmStbParametroTasaCambio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 257)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdatos)
        Me.Controls.Add(Me.grpdestino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes  Módulo de Catálogos Básicos")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbParametroTasaCambio"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros Tasa de Cambio"
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.cdeFechaHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMonedaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMonedaBase, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdestino.ResumeLayout(False)
        Me.grpdestino.PerformLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents grpdestino As System.Windows.Forms.GroupBox
    Friend WithEvents RadArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents radPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboMonedaBase As C1.Win.C1List.C1Combo
    Friend WithEvents lblMonedaBase As System.Windows.Forms.Label
    Friend WithEvents cboMonedaCambio As C1.Win.C1List.C1Combo
    Friend WithEvents lblMonedaCambio As System.Windows.Forms.Label
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents cdeFechaHasta As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblHasta As System.Windows.Forms.Label
    Friend WithEvents cdeFechaDesde As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblDesde As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
