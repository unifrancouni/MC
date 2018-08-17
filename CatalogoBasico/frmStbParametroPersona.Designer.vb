<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbParametroPersona
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbParametroPersona))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.grpdestino = New System.Windows.Forms.GroupBox
        Me.RadArchivo = New System.Windows.Forms.RadioButton
        Me.RadImpresora = New System.Windows.Forms.RadioButton
        Me.radPantalla = New System.Windows.Forms.RadioButton
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.cboOrdenadoPor = New C1.Win.C1List.C1Combo
        Me.lblOrdenadoPor = New System.Windows.Forms.Label
        Me.cboTipoPersona = New C1.Win.C1List.C1Combo
        Me.lblTipoPersona = New System.Windows.Forms.Label
        Me.cboEstado = New C1.Win.C1List.C1Combo
        Me.lblEstado = New System.Windows.Forms.Label
        Me.Exportar = New System.Windows.Forms.SaveFileDialog
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpdestino.SuspendLayout()
        Me.grpdatos.SuspendLayout()
        CType(Me.cboOrdenadoPor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoPersona, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(385, 190)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(313, 190)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 2
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'grpdestino
        '
        Me.grpdestino.Controls.Add(Me.RadArchivo)
        Me.grpdestino.Controls.Add(Me.RadImpresora)
        Me.grpdestino.Controls.Add(Me.radPantalla)
        Me.grpdestino.Location = New System.Drawing.Point(12, 127)
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
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.cboOrdenadoPor)
        Me.grpdatos.Controls.Add(Me.lblOrdenadoPor)
        Me.grpdatos.Controls.Add(Me.cboTipoPersona)
        Me.grpdatos.Controls.Add(Me.lblTipoPersona)
        Me.grpdatos.Controls.Add(Me.cboEstado)
        Me.grpdatos.Controls.Add(Me.lblEstado)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(444, 109)
        Me.grpdatos.TabIndex = 0
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'cboOrdenadoPor
        '
        Me.cboOrdenadoPor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboOrdenadoPor.AllowSort = False
        Me.cboOrdenadoPor.AutoCompletion = True
        Me.cboOrdenadoPor.Caption = ""
        Me.cboOrdenadoPor.CaptionHeight = 17
        Me.cboOrdenadoPor.CaptionStyle = Style1
        Me.cboOrdenadoPor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboOrdenadoPor.ColumnCaptionHeight = 17
        Me.cboOrdenadoPor.ColumnFooterHeight = 17
        Me.cboOrdenadoPor.ContentHeight = 15
        Me.cboOrdenadoPor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboOrdenadoPor.DisplayMember = "Ordenar"
        Me.cboOrdenadoPor.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboOrdenadoPor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboOrdenadoPor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrdenadoPor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboOrdenadoPor.EditorHeight = 15
        Me.cboOrdenadoPor.EvenRowStyle = Style2
        Me.cboOrdenadoPor.ExtendRightColumn = True
        Me.cboOrdenadoPor.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboOrdenadoPor.FooterStyle = Style3
        Me.cboOrdenadoPor.GapHeight = 2
        Me.cboOrdenadoPor.HeadingStyle = Style4
        Me.cboOrdenadoPor.HighLightRowStyle = Style5
        Me.cboOrdenadoPor.Images.Add(CType(resources.GetObject("cboOrdenadoPor.Images"), System.Drawing.Image))
        Me.cboOrdenadoPor.ItemHeight = 15
        Me.cboOrdenadoPor.Location = New System.Drawing.Point(141, 74)
        Me.cboOrdenadoPor.MatchEntryTimeout = CType(2000, Long)
        Me.cboOrdenadoPor.MaxDropDownItems = CType(5, Short)
        Me.cboOrdenadoPor.MaxLength = 32767
        Me.cboOrdenadoPor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboOrdenadoPor.Name = "cboOrdenadoPor"
        Me.cboOrdenadoPor.OddRowStyle = Style6
        Me.cboOrdenadoPor.PartialRightColumn = False
        Me.cboOrdenadoPor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboOrdenadoPor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboOrdenadoPor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboOrdenadoPor.SelectedStyle = Style7
        Me.cboOrdenadoPor.Size = New System.Drawing.Size(168, 21)
        Me.cboOrdenadoPor.Style = Style8
        Me.cboOrdenadoPor.TabIndex = 3
        Me.cboOrdenadoPor.PropBag = resources.GetString("cboOrdenadoPor.PropBag")
        '
        'lblOrdenadoPor
        '
        Me.lblOrdenadoPor.AutoSize = True
        Me.lblOrdenadoPor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblOrdenadoPor.Location = New System.Drawing.Point(16, 82)
        Me.lblOrdenadoPor.Name = "lblOrdenadoPor"
        Me.lblOrdenadoPor.Size = New System.Drawing.Size(78, 13)
        Me.lblOrdenadoPor.TabIndex = 37
        Me.lblOrdenadoPor.Text = "Ordernado por:"
        '
        'cboTipoPersona
        '
        Me.cboTipoPersona.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoPersona.AutoCompletion = True
        Me.cboTipoPersona.Caption = ""
        Me.cboTipoPersona.CaptionHeight = 17
        Me.cboTipoPersona.CaptionStyle = Style9
        Me.cboTipoPersona.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTipoPersona.ColumnCaptionHeight = 17
        Me.cboTipoPersona.ColumnFooterHeight = 17
        Me.cboTipoPersona.ContentHeight = 15
        Me.cboTipoPersona.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTipoPersona.DisplayMember = "sDescripcion"
        Me.cboTipoPersona.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTipoPersona.DropDownWidth = 188
        Me.cboTipoPersona.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTipoPersona.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoPersona.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoPersona.EditorHeight = 15
        Me.cboTipoPersona.EvenRowStyle = Style10
        Me.cboTipoPersona.ExtendRightColumn = True
        Me.cboTipoPersona.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoPersona.FooterStyle = Style11
        Me.cboTipoPersona.GapHeight = 2
        Me.cboTipoPersona.HeadingStyle = Style12
        Me.cboTipoPersona.HighLightRowStyle = Style13
        Me.cboTipoPersona.Images.Add(CType(resources.GetObject("cboTipoPersona.Images"), System.Drawing.Image))
        Me.cboTipoPersona.ItemHeight = 15
        Me.cboTipoPersona.LimitToList = True
        Me.cboTipoPersona.Location = New System.Drawing.Point(141, 20)
        Me.cboTipoPersona.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoPersona.MaxDropDownItems = CType(5, Short)
        Me.cboTipoPersona.MaxLength = 32767
        Me.cboTipoPersona.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoPersona.Name = "cboTipoPersona"
        Me.cboTipoPersona.OddRowStyle = Style14
        Me.cboTipoPersona.PartialRightColumn = False
        Me.cboTipoPersona.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoPersona.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoPersona.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoPersona.SelectedStyle = Style15
        Me.cboTipoPersona.Size = New System.Drawing.Size(168, 21)
        Me.cboTipoPersona.Style = Style16
        Me.cboTipoPersona.SuperBack = True
        Me.cboTipoPersona.TabIndex = 1
        Me.cboTipoPersona.ValueMember = "StbValorCatalogoID"
        Me.cboTipoPersona.PropBag = resources.GetString("cboTipoPersona.PropBag")
        '
        'lblTipoPersona
        '
        Me.lblTipoPersona.AutoSize = True
        Me.lblTipoPersona.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoPersona.Location = New System.Drawing.Point(16, 28)
        Me.lblTipoPersona.Name = "lblTipoPersona"
        Me.lblTipoPersona.Size = New System.Drawing.Size(88, 13)
        Me.lblTipoPersona.TabIndex = 34
        Me.lblTipoPersona.Text = "Tipo de Persona:"
        '
        'cboEstado
        '
        Me.cboEstado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstado.AllowSort = False
        Me.cboEstado.AutoCompletion = True
        Me.cboEstado.Caption = ""
        Me.cboEstado.CaptionHeight = 17
        Me.cboEstado.CaptionStyle = Style17
        Me.cboEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEstado.ColumnCaptionHeight = 17
        Me.cboEstado.ColumnFooterHeight = 17
        Me.cboEstado.ContentHeight = 15
        Me.cboEstado.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboEstado.DisplayMember = "Estado"
        Me.cboEstado.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboEstado.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboEstado.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEstado.EditorHeight = 15
        Me.cboEstado.EvenRowStyle = Style18
        Me.cboEstado.ExtendRightColumn = True
        Me.cboEstado.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEstado.FooterStyle = Style19
        Me.cboEstado.GapHeight = 2
        Me.cboEstado.HeadingStyle = Style20
        Me.cboEstado.HighLightRowStyle = Style21
        Me.cboEstado.Images.Add(CType(resources.GetObject("cboEstado.Images"), System.Drawing.Image))
        Me.cboEstado.ItemHeight = 15
        Me.cboEstado.Location = New System.Drawing.Point(141, 47)
        Me.cboEstado.MatchEntryTimeout = CType(2000, Long)
        Me.cboEstado.MaxDropDownItems = CType(5, Short)
        Me.cboEstado.MaxLength = 32767
        Me.cboEstado.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.OddRowStyle = Style22
        Me.cboEstado.PartialRightColumn = False
        Me.cboEstado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEstado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEstado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEstado.SelectedStyle = Style23
        Me.cboEstado.Size = New System.Drawing.Size(168, 21)
        Me.cboEstado.Style = Style24
        Me.cboEstado.TabIndex = 2
        Me.cboEstado.PropBag = resources.GetString("cboEstado.PropBag")
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(16, 55)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(43, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Estado:"
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'frmStbParametroPersona
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 227)
        Me.Controls.Add(Me.grpdatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdestino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes  Módulo de Catálogos Básicos")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbParametroPersona"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros Persona"
        Me.grpdestino.ResumeLayout(False)
        Me.grpdestino.PerformLayout()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.cboOrdenadoPor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoPersona, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdestino As System.Windows.Forms.GroupBox
    Friend WithEvents RadArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents radPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboOrdenadoPor As C1.Win.C1List.C1Combo
    Friend WithEvents lblOrdenadoPor As System.Windows.Forms.Label
    Friend WithEvents cboTipoPersona As C1.Win.C1List.C1Combo
    Friend WithEvents lblTipoPersona As System.Windows.Forms.Label
    Friend WithEvents cboEstado As C1.Win.C1List.C1Combo
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
