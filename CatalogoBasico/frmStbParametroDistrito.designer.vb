<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbParametroDistrito
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbParametroDistrito))
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
        Me.cboIncluidoPrograma = New C1.Win.C1List.C1Combo
        Me.lblPertenece = New System.Windows.Forms.Label
        Me.cboEstado = New C1.Win.C1List.C1Combo
        Me.lblestado = New System.Windows.Forms.Label
        Me.grpdestino = New System.Windows.Forms.GroupBox
        Me.RadArchivo = New System.Windows.Forms.RadioButton
        Me.RadImpresora = New System.Windows.Forms.RadioButton
        Me.radPantalla = New System.Windows.Forms.RadioButton
        Me.Exportar = New System.Windows.Forms.SaveFileDialog
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpdatos.SuspendLayout()
        CType(Me.cboIncluidoPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdestino.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.cboIncluidoPrograma)
        Me.grpdatos.Controls.Add(Me.lblPertenece)
        Me.grpdatos.Controls.Add(Me.cboEstado)
        Me.grpdatos.Controls.Add(Me.lblestado)
        Me.grpdatos.Location = New System.Drawing.Point(10, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(444, 94)
        Me.grpdatos.TabIndex = 0
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'cboIncluidoPrograma
        '
        Me.cboIncluidoPrograma.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboIncluidoPrograma.AllowSort = False
        Me.cboIncluidoPrograma.AutoCompletion = True
        Me.cboIncluidoPrograma.Caption = ""
        Me.cboIncluidoPrograma.CaptionHeight = 17
        Me.cboIncluidoPrograma.CaptionStyle = Style1
        Me.cboIncluidoPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboIncluidoPrograma.ColumnCaptionHeight = 17
        Me.cboIncluidoPrograma.ColumnFooterHeight = 17
        Me.cboIncluidoPrograma.ContentHeight = 15
        Me.cboIncluidoPrograma.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboIncluidoPrograma.DisplayMember = "Pertenece"
        Me.cboIncluidoPrograma.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboIncluidoPrograma.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboIncluidoPrograma.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboIncluidoPrograma.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboIncluidoPrograma.EditorHeight = 15
        Me.cboIncluidoPrograma.EvenRowStyle = Style2
        Me.cboIncluidoPrograma.ExtendRightColumn = True
        Me.cboIncluidoPrograma.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboIncluidoPrograma.FooterStyle = Style3
        Me.cboIncluidoPrograma.GapHeight = 2
        Me.cboIncluidoPrograma.HeadingStyle = Style4
        Me.cboIncluidoPrograma.HighLightRowStyle = Style5
        Me.cboIncluidoPrograma.Images.Add(CType(resources.GetObject("cboIncluidoPrograma.Images"), System.Drawing.Image))
        Me.cboIncluidoPrograma.ItemHeight = 15
        Me.cboIncluidoPrograma.Location = New System.Drawing.Point(141, 28)
        Me.cboIncluidoPrograma.MatchEntryTimeout = CType(2000, Long)
        Me.cboIncluidoPrograma.MaxDropDownItems = CType(5, Short)
        Me.cboIncluidoPrograma.MaxLength = 32767
        Me.cboIncluidoPrograma.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboIncluidoPrograma.Name = "cboIncluidoPrograma"
        Me.cboIncluidoPrograma.OddRowStyle = Style6
        Me.cboIncluidoPrograma.PartialRightColumn = False
        Me.cboIncluidoPrograma.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboIncluidoPrograma.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboIncluidoPrograma.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboIncluidoPrograma.SelectedStyle = Style7
        Me.cboIncluidoPrograma.Size = New System.Drawing.Size(168, 21)
        Me.cboIncluidoPrograma.Style = Style8
        Me.cboIncluidoPrograma.TabIndex = 0
        Me.cboIncluidoPrograma.PropBag = resources.GetString("cboIncluidoPrograma.PropBag")
        '
        'lblPertenece
        '
        Me.lblPertenece.AutoSize = True
        Me.lblPertenece.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPertenece.Location = New System.Drawing.Point(16, 34)
        Me.lblPertenece.Name = "lblPertenece"
        Me.lblPertenece.Size = New System.Drawing.Size(121, 13)
        Me.lblPertenece.TabIndex = 37
        Me.lblPertenece.Text = "Incluido en el Programa:"
        '
        'cboEstado
        '
        Me.cboEstado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstado.AllowSort = False
        Me.cboEstado.AutoCompletion = True
        Me.cboEstado.Caption = ""
        Me.cboEstado.CaptionHeight = 17
        Me.cboEstado.CaptionStyle = Style9
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
        Me.cboEstado.EvenRowStyle = Style10
        Me.cboEstado.ExtendRightColumn = True
        Me.cboEstado.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEstado.FooterStyle = Style11
        Me.cboEstado.GapHeight = 2
        Me.cboEstado.HeadingStyle = Style12
        Me.cboEstado.HighLightRowStyle = Style13
        Me.cboEstado.Images.Add(CType(resources.GetObject("cboEstado.Images"), System.Drawing.Image))
        Me.cboEstado.ItemHeight = 15
        Me.cboEstado.Location = New System.Drawing.Point(141, 55)
        Me.cboEstado.MatchEntryTimeout = CType(2000, Long)
        Me.cboEstado.MaxDropDownItems = CType(5, Short)
        Me.cboEstado.MaxLength = 32767
        Me.cboEstado.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.OddRowStyle = Style14
        Me.cboEstado.PartialRightColumn = False
        Me.cboEstado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEstado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEstado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEstado.SelectedStyle = Style15
        Me.cboEstado.Size = New System.Drawing.Size(168, 21)
        Me.cboEstado.Style = Style16
        Me.cboEstado.TabIndex = 1
        Me.cboEstado.PropBag = resources.GetString("cboEstado.PropBag")
        '
        'lblestado
        '
        Me.lblestado.AutoSize = True
        Me.lblestado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblestado.Location = New System.Drawing.Point(16, 61)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(43, 13)
        Me.lblestado.TabIndex = 0
        Me.lblestado.Text = "Estado:"
        '
        'grpdestino
        '
        Me.grpdestino.Controls.Add(Me.RadArchivo)
        Me.grpdestino.Controls.Add(Me.RadImpresora)
        Me.grpdestino.Controls.Add(Me.radPantalla)
        Me.grpdestino.Location = New System.Drawing.Point(10, 112)
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
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(383, 175)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(311, 175)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 2
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmStbParametroDistrito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 216)
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
        Me.Name = "frmStbParametroDistrito"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros Barrio"
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.cboIncluidoPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdestino.ResumeLayout(False)
        Me.grpdestino.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboEstado As C1.Win.C1List.C1Combo
    Friend WithEvents grpdestino As System.Windows.Forms.GroupBox
    Friend WithEvents RadArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents radPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboIncluidoPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblPertenece As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
