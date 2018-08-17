<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteParametrosCajeros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteParametrosCajeros))
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
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
        Me.cboCajero = New C1.Win.C1List.C1Combo
        Me.lblCajero = New System.Windows.Forms.Label
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaHasta = New System.Windows.Forms.Label
        Me.lblFechaDesde = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.CboPrograma = New C1.Win.C1List.C1Combo
        Me.lblPrograma = New System.Windows.Forms.Label
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        CType(Me.cboCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(260, 173)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(335, 173)
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
        Me.grpdatos.Controls.Add(Me.cboCajero)
        Me.grpdatos.Controls.Add(Me.lblCajero)
        Me.grpdatos.Controls.Add(Me.CdeFechaFinal)
        Me.grpdatos.Controls.Add(Me.cdeFechaInicial)
        Me.grpdatos.Controls.Add(Me.lblFechaHasta)
        Me.grpdatos.Controls.Add(Me.lblFechaDesde)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(394, 155)
        Me.grpdatos.TabIndex = 13
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por:  "
        '
        'cboCajero
        '
        Me.cboCajero.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCajero.AutoCompletion = True
        Me.cboCajero.Caption = ""
        Me.cboCajero.CaptionHeight = 17
        Me.cboCajero.CaptionStyle = Style9
        Me.cboCajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCajero.ColumnCaptionHeight = 17
        Me.cboCajero.ColumnFooterHeight = 17
        Me.cboCajero.ContentHeight = 15
        Me.cboCajero.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCajero.DisplayMember = "sNombreEmpleado"
        Me.cboCajero.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCajero.DropDownWidth = 268
        Me.cboCajero.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCajero.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCajero.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCajero.EditorHeight = 15
        Me.cboCajero.EvenRowStyle = Style10
        Me.cboCajero.ExtendRightColumn = True
        Me.cboCajero.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCajero.FooterStyle = Style11
        Me.cboCajero.GapHeight = 2
        Me.cboCajero.HeadingStyle = Style12
        Me.cboCajero.HighLightRowStyle = Style13
        Me.cboCajero.Images.Add(CType(resources.GetObject("cboCajero.Images"), System.Drawing.Image))
        Me.cboCajero.ItemHeight = 15
        Me.cboCajero.LimitToList = True
        Me.cboCajero.Location = New System.Drawing.Point(111, 29)
        Me.cboCajero.MatchEntryTimeout = CType(2000, Long)
        Me.cboCajero.MaxDropDownItems = CType(5, Short)
        Me.cboCajero.MaxLength = 32767
        Me.cboCajero.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCajero.Name = "cboCajero"
        Me.cboCajero.OddRowStyle = Style14
        Me.cboCajero.PartialRightColumn = False
        Me.cboCajero.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCajero.SelectedStyle = Style15
        Me.cboCajero.Size = New System.Drawing.Size(267, 21)
        Me.cboCajero.Style = Style16
        Me.cboCajero.SuperBack = True
        Me.cboCajero.TabIndex = 0
        Me.cboCajero.ValueMember = "nSrhEmpleadoID"
        Me.cboCajero.PropBag = resources.GetString("cboCajero.PropBag")
        '
        'lblCajero
        '
        Me.lblCajero.AutoSize = True
        Me.lblCajero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCajero.Location = New System.Drawing.Point(19, 29)
        Me.lblCajero.Name = "lblCajero"
        Me.lblCajero.Size = New System.Drawing.Size(88, 13)
        Me.lblCajero.TabIndex = 67
        Me.lblCajero.Text = "Cajero Programa:"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(111, 120)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(92, 20)
        Me.CdeFechaFinal.TabIndex = 3
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
        Me.cdeFechaInicial.Location = New System.Drawing.Point(111, 86)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(92, 20)
        Me.cdeFechaInicial.TabIndex = 2
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaHasta.Location = New System.Drawing.Point(19, 123)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(75, 13)
        Me.lblFechaHasta.TabIndex = 55
        Me.lblFechaHasta.Text = "Arqueo Hasta:"
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaDesde.Location = New System.Drawing.Point(19, 89)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(78, 13)
        Me.lblFechaDesde.TabIndex = 54
        Me.lblFechaDesde.Text = "Arqueo Desde:"
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
        Me.CboPrograma.DropDownWidth = 268
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
        Me.CboPrograma.Location = New System.Drawing.Point(111, 56)
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
        Me.CboPrograma.Size = New System.Drawing.Size(267, 21)
        Me.CboPrograma.Style = Style8
        Me.CboPrograma.TabIndex = 1
        Me.CboPrograma.ValueMember = "nStbValorCatalogoID"
        Me.CboPrograma.PropBag = resources.GetString("CboPrograma.PropBag")
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrograma.Location = New System.Drawing.Point(19, 56)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(55, 13)
        Me.lblPrograma.TabIndex = 128
        Me.lblPrograma.Text = "Programa:"
        '
        'frmSteParametrosCajeros
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(414, 212)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpdatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteParametrosCajeros"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Parámetros Listado"
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.cboCajero, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblCajero As System.Windows.Forms.Label
    Friend WithEvents cboCajero As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CboPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
End Class
