<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccParametrosMetasPrograma
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
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccParametrosMetasPrograma))
        Dim Style41 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style42 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style43 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style44 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style45 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style46 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style47 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style48 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cneAnio = New C1.Win.C1Input.C1NumericEdit
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.lblMunicipio = New System.Windows.Forms.Label
        Me.cboDepartamento = New C1.Win.C1List.C1Combo
        Me.cboDistrito = New C1.Win.C1List.C1Combo
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.lblDistrito = New System.Windows.Forms.Label
        Me.cboMunicipio = New C1.Win.C1List.C1Combo
        Me.lblDepartamento = New System.Windows.Forms.Label
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'errParametro
        '
        Me.errParametro.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink
        Me.errParametro.ContainerControl = Me
        '
        'cneAnio
        '
        Me.cneAnio.AcceptsTab = True
        Me.cneAnio.CustomFormat = "###0"
        Me.cneAnio.DataType = GetType(Integer)
        Me.cneAnio.DisplayFormat.CustomFormat = "###0"
        Me.cneAnio.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneAnio.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneAnio.EditFormat.CustomFormat = "###,###,###,##0"
        Me.cneAnio.EditFormat.EmptyAsNull = False
        Me.cneAnio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneAnio.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneAnio.EmptyAsNull = True
        Me.cneAnio.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneAnio.Location = New System.Drawing.Point(141, 107)
        Me.cneAnio.MaskInfo.AutoTabWhenFilled = True
        Me.cneAnio.MaxLength = 9999
        Me.cneAnio.Name = "cneAnio"
        Me.cneAnio.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneAnio.Size = New System.Drawing.Size(74, 20)
        Me.cneAnio.TabIndex = 119
        Me.cneAnio.Tag = Nothing
        Me.cneAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneAnio.UseColumnStyles = False
        Me.cneAnio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(262, 156)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 123
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(16, 54)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(55, 13)
        Me.lblMunicipio.TabIndex = 34
        Me.lblMunicipio.Text = "Municipio:"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style25
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "Descripcion"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 153
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.EvenRowStyle = Style26
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style27
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style28
        Me.cboDepartamento.HighLightRowStyle = Style29
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(141, 19)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style30
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style31
        Me.cboDepartamento.Size = New System.Drawing.Size(168, 21)
        Me.cboDepartamento.Style = Style32
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 0
        Me.cboDepartamento.ValueMember = "StbValorCatalogoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'cboDistrito
        '
        Me.cboDistrito.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDistrito.AutoCompletion = True
        Me.cboDistrito.Caption = ""
        Me.cboDistrito.CaptionHeight = 17
        Me.cboDistrito.CaptionStyle = Style33
        Me.cboDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDistrito.ColumnCaptionHeight = 17
        Me.cboDistrito.ColumnFooterHeight = 17
        Me.cboDistrito.ContentHeight = 15
        Me.cboDistrito.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDistrito.DisplayMember = "Descripcion"
        Me.cboDistrito.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDistrito.DropDownWidth = 146
        Me.cboDistrito.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDistrito.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrito.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDistrito.EditorHeight = 15
        Me.cboDistrito.EvenRowStyle = Style34
        Me.cboDistrito.ExtendRightColumn = True
        Me.cboDistrito.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDistrito.FooterStyle = Style35
        Me.cboDistrito.GapHeight = 2
        Me.cboDistrito.HeadingStyle = Style36
        Me.cboDistrito.HighLightRowStyle = Style37
        Me.cboDistrito.Images.Add(CType(resources.GetObject("cboDistrito.Images"), System.Drawing.Image))
        Me.cboDistrito.ItemHeight = 15
        Me.cboDistrito.LimitToList = True
        Me.cboDistrito.Location = New System.Drawing.Point(141, 73)
        Me.cboDistrito.MatchEntryTimeout = CType(2000, Long)
        Me.cboDistrito.MaxDropDownItems = CType(5, Short)
        Me.cboDistrito.MaxLength = 32767
        Me.cboDistrito.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.OddRowStyle = Style38
        Me.cboDistrito.PartialRightColumn = False
        Me.cboDistrito.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDistrito.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDistrito.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDistrito.SelectedStyle = Style39
        Me.cboDistrito.Size = New System.Drawing.Size(168, 21)
        Me.cboDistrito.Style = Style40
        Me.cboDistrito.SuperBack = True
        Me.cboDistrito.TabIndex = 2
        Me.cboDistrito.ValueMember = "StbValorCatalogoID"
        Me.cboDistrito.PropBag = resources.GetString("cboDistrito.PropBag")
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(187, 156)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 122
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'lblDistrito
        '
        Me.lblDistrito.AutoSize = True
        Me.lblDistrito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDistrito.Location = New System.Drawing.Point(16, 81)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(42, 13)
        Me.lblDistrito.TabIndex = 36
        Me.lblDistrito.Text = "Distrito:"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMunicipio.AutoCompletion = True
        Me.cboMunicipio.Caption = ""
        Me.cboMunicipio.CaptionHeight = 17
        Me.cboMunicipio.CaptionStyle = Style41
        Me.cboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMunicipio.ColumnCaptionHeight = 17
        Me.cboMunicipio.ColumnFooterHeight = 17
        Me.cboMunicipio.ContentHeight = 15
        Me.cboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMunicipio.DisplayMember = "Descripcion"
        Me.cboMunicipio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMunicipio.DropDownWidth = 188
        Me.cboMunicipio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMunicipio.EditorHeight = 15
        Me.cboMunicipio.EvenRowStyle = Style42
        Me.cboMunicipio.ExtendRightColumn = True
        Me.cboMunicipio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMunicipio.FooterStyle = Style43
        Me.cboMunicipio.GapHeight = 2
        Me.cboMunicipio.HeadingStyle = Style44
        Me.cboMunicipio.HighLightRowStyle = Style45
        Me.cboMunicipio.Images.Add(CType(resources.GetObject("cboMunicipio.Images"), System.Drawing.Image))
        Me.cboMunicipio.ItemHeight = 15
        Me.cboMunicipio.LimitToList = True
        Me.cboMunicipio.Location = New System.Drawing.Point(141, 46)
        Me.cboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.cboMunicipio.MaxLength = 32767
        Me.cboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.OddRowStyle = Style46
        Me.cboMunicipio.PartialRightColumn = False
        Me.cboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMunicipio.SelectedStyle = Style47
        Me.cboMunicipio.Size = New System.Drawing.Size(168, 21)
        Me.cboMunicipio.Style = Style48
        Me.cboMunicipio.SuperBack = True
        Me.cboMunicipio.TabIndex = 1
        Me.cboMunicipio.ValueMember = "StbValorCatalogoID"
        Me.cboMunicipio.PropBag = resources.GetString("cboMunicipio.PropBag")
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(16, 27)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 7
        Me.lblDepartamento.Text = "Departamento:"
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.Label1)
        Me.grpdatos.Controls.Add(Me.cboDistrito)
        Me.grpdatos.Controls.Add(Me.lblDistrito)
        Me.grpdatos.Controls.Add(Me.cboMunicipio)
        Me.grpdatos.Controls.Add(Me.lblMunicipio)
        Me.grpdatos.Controls.Add(Me.cneAnio)
        Me.grpdatos.Controls.Add(Me.cboDepartamento)
        Me.grpdatos.Controls.Add(Me.lblDepartamento)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(321, 138)
        Me.grpdatos.TabIndex = 120
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(16, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Año:"
        '
        'frmSccParametrosMetasPrograma
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(348, 196)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccParametrosMetasPrograma"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros para Reporte de las Metas"
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents cneAnio As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboDistrito As C1.Win.C1List.C1Combo
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents cboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
