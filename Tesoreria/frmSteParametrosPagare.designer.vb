<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteParametrosPagare
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
        Dim lblEstado As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteParametrosPagare))
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.lblDepartamento = New System.Windows.Forms.Label
        Me.cboDepartamento = New C1.Win.C1List.C1Combo
        Me.cboEstadoPagare = New C1.Win.C1List.C1Combo
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaHasta = New System.Windows.Forms.Label
        Me.lblFechaDesde = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.CboPrograma = New C1.Win.C1List.C1Combo
        Me.lblPrograma = New System.Windows.Forms.Label
        lblEstado = New System.Windows.Forms.Label
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstadoPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblEstado
        '
        lblEstado.AutoSize = True
        lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        lblEstado.Location = New System.Drawing.Point(18, 71)
        lblEstado.Name = "lblEstado"
        lblEstado.Size = New System.Drawing.Size(97, 13)
        lblEstado.TabIndex = 67
        lblEstado.Text = "Estado del Pagare:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(235, 218)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 0
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(310, 218)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.CboPrograma)
        Me.grpdatos.Controls.Add(Me.lblPrograma)
        Me.grpdatos.Controls.Add(Me.lblDepartamento)
        Me.grpdatos.Controls.Add(Me.cboDepartamento)
        Me.grpdatos.Controls.Add(Me.cboEstadoPagare)
        Me.grpdatos.Controls.Add(lblEstado)
        Me.grpdatos.Controls.Add(Me.CdeFechaFinal)
        Me.grpdatos.Controls.Add(Me.cdeFechaInicial)
        Me.grpdatos.Controls.Add(Me.lblFechaHasta)
        Me.grpdatos.Controls.Add(Me.lblFechaDesde)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(369, 200)
        Me.grpdatos.TabIndex = 13
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por:  "
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(18, 37)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 69
        Me.lblDepartamento.Text = "Departamento:"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style9
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "Descripcion"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 242
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.EvenRowStyle = Style10
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style11
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style12
        Me.cboDepartamento.HighLightRowStyle = Style13
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(113, 29)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style14
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style15
        Me.cboDepartamento.Size = New System.Drawing.Size(241, 21)
        Me.cboDepartamento.Style = Style16
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 0
        Me.cboDepartamento.ValueMember = "StbValorCatalogoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'cboEstadoPagare
        '
        Me.cboEstadoPagare.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstadoPagare.AutoCompletion = True
        Me.cboEstadoPagare.Caption = ""
        Me.cboEstadoPagare.CaptionHeight = 17
        Me.cboEstadoPagare.CaptionStyle = Style17
        Me.cboEstadoPagare.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEstadoPagare.ColumnCaptionHeight = 17
        Me.cboEstadoPagare.ColumnFooterHeight = 17
        Me.cboEstadoPagare.ContentHeight = 15
        Me.cboEstadoPagare.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboEstadoPagare.DisplayMember = "sDescripcion"
        Me.cboEstadoPagare.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboEstadoPagare.DropDownWidth = 242
        Me.cboEstadoPagare.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboEstadoPagare.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstadoPagare.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEstadoPagare.EditorHeight = 15
        Me.cboEstadoPagare.EvenRowStyle = Style18
        Me.cboEstadoPagare.ExtendRightColumn = True
        Me.cboEstadoPagare.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEstadoPagare.FooterStyle = Style19
        Me.cboEstadoPagare.GapHeight = 2
        Me.cboEstadoPagare.HeadingStyle = Style20
        Me.cboEstadoPagare.HighLightRowStyle = Style21
        Me.cboEstadoPagare.Images.Add(CType(resources.GetObject("cboEstadoPagare.Images"), System.Drawing.Image))
        Me.cboEstadoPagare.ItemHeight = 15
        Me.cboEstadoPagare.LimitToList = True
        Me.cboEstadoPagare.Location = New System.Drawing.Point(113, 63)
        Me.cboEstadoPagare.MatchEntryTimeout = CType(2000, Long)
        Me.cboEstadoPagare.MaxDropDownItems = CType(5, Short)
        Me.cboEstadoPagare.MaxLength = 32767
        Me.cboEstadoPagare.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEstadoPagare.Name = "cboEstadoPagare"
        Me.cboEstadoPagare.OddRowStyle = Style22
        Me.cboEstadoPagare.PartialRightColumn = False
        Me.cboEstadoPagare.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEstadoPagare.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEstadoPagare.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEstadoPagare.SelectedStyle = Style23
        Me.cboEstadoPagare.Size = New System.Drawing.Size(241, 21)
        Me.cboEstadoPagare.Style = Style24
        Me.cboEstadoPagare.SuperBack = True
        Me.cboEstadoPagare.TabIndex = 1
        Me.cboEstadoPagare.ValueMember = "nStbValorCatalogoID"
        Me.cboEstadoPagare.PropBag = resources.GetString("cboEstadoPagare.PropBag")
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(113, 168)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(92, 20)
        Me.CdeFechaFinal.TabIndex = 4
        Me.CdeFechaFinal.Tag = Nothing
        Me.CdeFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(113, 134)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(92, 20)
        Me.cdeFechaInicial.TabIndex = 3
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaHasta.Location = New System.Drawing.Point(18, 171)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(75, 13)
        Me.lblFechaHasta.TabIndex = 55
        Me.lblFechaHasta.Text = "Pagare Hasta:"
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaDesde.Location = New System.Drawing.Point(18, 137)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(78, 13)
        Me.lblFechaDesde.TabIndex = 54
        Me.lblFechaDesde.Text = "Pagare Desde:"
        '
        'CboPrograma
        '
        Me.CboPrograma.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboPrograma.AllowSort = False
        Me.CboPrograma.AutoCompletion = True
        Me.CboPrograma.Caption = ""
        Me.CboPrograma.CaptionHeight = 17
        Me.CboPrograma.CaptionStyle = Style1
        Me.CboPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboPrograma.ColumnCaptionHeight = 17
        Me.CboPrograma.ColumnFooterHeight = 17
        Me.CboPrograma.ContentHeight = 15
        Me.CboPrograma.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboPrograma.DisplayMember = "sDescripcion"
        Me.CboPrograma.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboPrograma.DropDownWidth = 242
        Me.CboPrograma.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboPrograma.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPrograma.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboPrograma.EditorHeight = 15
        Me.CboPrograma.EvenRowStyle = Style2
        Me.CboPrograma.ExtendRightColumn = True
        Me.CboPrograma.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboPrograma.FooterStyle = Style3
        Me.CboPrograma.GapHeight = 2
        Me.CboPrograma.HeadingStyle = Style4
        Me.CboPrograma.HighLightRowStyle = Style5
        Me.CboPrograma.Images.Add(CType(resources.GetObject("CboPrograma.Images"), System.Drawing.Image))
        Me.CboPrograma.ItemHeight = 15
        Me.CboPrograma.Location = New System.Drawing.Point(113, 101)
        Me.CboPrograma.MatchEntryTimeout = CType(2000, Long)
        Me.CboPrograma.MaxDropDownItems = CType(5, Short)
        Me.CboPrograma.MaxLength = 32767
        Me.CboPrograma.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboPrograma.Name = "CboPrograma"
        Me.CboPrograma.OddRowStyle = Style6
        Me.CboPrograma.PartialRightColumn = False
        Me.CboPrograma.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboPrograma.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboPrograma.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboPrograma.SelectedStyle = Style7
        Me.CboPrograma.Size = New System.Drawing.Size(241, 21)
        Me.CboPrograma.Style = Style8
        Me.CboPrograma.TabIndex = 2
        Me.CboPrograma.ValueMember = "nStbValorCatalogoID"
        Me.CboPrograma.PropBag = resources.GetString("CboPrograma.PropBag")
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrograma.Location = New System.Drawing.Point(18, 101)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(55, 13)
        Me.lblPrograma.TabIndex = 77
        Me.lblPrograma.Text = "Programa:"
        '
        'frmSteParametrosPagare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 257)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpdatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteParametrosPagare"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Parámetros Pagare"
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstadoPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents cboEstadoPagare As C1.Win.C1List.C1Combo
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CboPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
End Class
