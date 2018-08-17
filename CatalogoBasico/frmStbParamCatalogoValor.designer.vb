<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbParamCatalogoValor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbParamCatalogoValor))
        Me.Exportar = New System.Windows.Forms.SaveFileDialog
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboEstado = New C1.Win.C1List.C1Combo
        Me.cboCatalogo = New C1.Win.C1List.C1Combo
        Me.cmdCerrar = New System.Windows.Forms.Button
        Me.radArchivo = New System.Windows.Forms.RadioButton
        Me.grpDestinoReporte = New System.Windows.Forms.GroupBox
        Me.radImpresora = New System.Windows.Forms.RadioButton
        Me.RadioPant = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.lblEstado = New System.Windows.Forms.Label
        Me.grpFiltroDatos = New System.Windows.Forms.GroupBox
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDestinoReporte.SuspendLayout()
        Me.grpFiltroDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Exportar
        '
        Me.Exportar.Filter = "PDF|*.pdf"
        Me.Exportar.Title = "Exportar Reporte"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cboEstado
        '
        Me.cboEstado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstado.AllowSort = False
        Me.cboEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboEstado.Caption = ""
        Me.cboEstado.CaptionHeight = 17
        Me.cboEstado.CaptionStyle = Style9
        Me.cboEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEstado.ColumnCaptionHeight = 17
        Me.cboEstado.ColumnFooterHeight = 17
        Me.cboEstado.ContentHeight = 15
        Me.cboEstado.DeadAreaBackColor = System.Drawing.Color.Empty
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
        Me.cboEstado.Location = New System.Drawing.Point(72, 18)
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
        Me.cboEstado.Size = New System.Drawing.Size(84, 19)
        Me.cboEstado.Style = Style16
        Me.cboEstado.TabIndex = 1
        Me.cboEstado.PropBag = resources.GetString("cboEstado.PropBag")
        '
        'cboCatalogo
        '
        Me.cboCatalogo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCatalogo.AutoCompletion = True
        Me.cboCatalogo.AutoDropDown = True
        Me.cboCatalogo.Caption = ""
        Me.cboCatalogo.CaptionHeight = 17
        Me.cboCatalogo.CaptionStyle = Style1
        Me.cboCatalogo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCatalogo.ColumnCaptionHeight = 17
        Me.cboCatalogo.ColumnFooterHeight = 17
        Me.cboCatalogo.ContentHeight = 15
        Me.cboCatalogo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCatalogo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCatalogo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCatalogo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCatalogo.EditorHeight = 15
        Me.cboCatalogo.EvenRowStyle = Style2
        Me.cboCatalogo.ExtendRightColumn = True
        Me.cboCatalogo.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCatalogo.FooterStyle = Style3
        Me.cboCatalogo.GapHeight = 2
        Me.cboCatalogo.HeadingStyle = Style4
        Me.cboCatalogo.HighLightRowStyle = Style5
        Me.cboCatalogo.Images.Add(CType(resources.GetObject("cboCatalogo.Images"), System.Drawing.Image))
        Me.cboCatalogo.ItemHeight = 15
        Me.cboCatalogo.LimitToList = True
        Me.cboCatalogo.Location = New System.Drawing.Point(72, 42)
        Me.cboCatalogo.MatchEntryTimeout = CType(2000, Long)
        Me.cboCatalogo.MaxDropDownItems = CType(5, Short)
        Me.cboCatalogo.MaxLength = 32767
        Me.cboCatalogo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCatalogo.Name = "cboCatalogo"
        Me.cboCatalogo.OddRowStyle = Style6
        Me.cboCatalogo.PartialRightColumn = False
        Me.cboCatalogo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCatalogo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCatalogo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCatalogo.SelectedStyle = Style7
        Me.cboCatalogo.Size = New System.Drawing.Size(222, 21)
        Me.cboCatalogo.Style = Style8
        Me.cboCatalogo.SuperBack = True
        Me.cboCatalogo.TabIndex = 3
        Me.cboCatalogo.PropBag = resources.GetString("cboCatalogo.PropBag")
        '
        'cmdCerrar
        '
        Me.cmdCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(313, 146)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(75, 27)
        Me.cmdCerrar.TabIndex = 4
        Me.cmdCerrar.Text = "&Cancelar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'radArchivo
        '
        Me.radArchivo.AutoSize = True
        Me.radArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radArchivo.ForeColor = System.Drawing.Color.Black
        Me.radArchivo.Location = New System.Drawing.Point(186, 18)
        Me.radArchivo.Name = "radArchivo"
        Me.radArchivo.Size = New System.Drawing.Size(61, 17)
        Me.radArchivo.TabIndex = 2
        Me.radArchivo.Text = "Archivo"
        Me.radArchivo.UseVisualStyleBackColor = True
        '
        'grpDestinoReporte
        '
        Me.grpDestinoReporte.Controls.Add(Me.radArchivo)
        Me.grpDestinoReporte.Controls.Add(Me.radImpresora)
        Me.grpDestinoReporte.Controls.Add(Me.RadioPant)
        Me.grpDestinoReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDestinoReporte.Location = New System.Drawing.Point(12, 89)
        Me.grpDestinoReporte.Name = "grpDestinoReporte"
        Me.grpDestinoReporte.Size = New System.Drawing.Size(376, 51)
        Me.grpDestinoReporte.TabIndex = 2
        Me.grpDestinoReporte.TabStop = False
        Me.grpDestinoReporte.Text = "Destino del Reporte"
        '
        'radImpresora
        '
        Me.radImpresora.AutoSize = True
        Me.radImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radImpresora.ForeColor = System.Drawing.Color.Black
        Me.radImpresora.Location = New System.Drawing.Point(98, 18)
        Me.radImpresora.Name = "radImpresora"
        Me.radImpresora.Size = New System.Drawing.Size(71, 17)
        Me.radImpresora.TabIndex = 1
        Me.radImpresora.Text = "Impresora"
        Me.radImpresora.UseVisualStyleBackColor = True
        '
        'RadioPant
        '
        Me.RadioPant.AutoSize = True
        Me.RadioPant.Checked = True
        Me.RadioPant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioPant.ForeColor = System.Drawing.Color.Black
        Me.RadioPant.Location = New System.Drawing.Point(15, 18)
        Me.RadioPant.Name = "RadioPant"
        Me.RadioPant.Size = New System.Drawing.Size(63, 17)
        Me.RadioPant.TabIndex = 0
        Me.RadioPant.TabStop = True
        Me.RadioPant.Text = "Pantalla"
        Me.RadioPant.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(10, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Catálogo:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(235, 146)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(77, 27)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "&Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Black
        Me.lblEstado.Location = New System.Drawing.Point(10, 18)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(43, 13)
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "Estado:"
        '
        'grpFiltroDatos
        '
        Me.grpFiltroDatos.Controls.Add(Me.cboCatalogo)
        Me.grpFiltroDatos.Controls.Add(Me.Label1)
        Me.grpFiltroDatos.Controls.Add(Me.lblEstado)
        Me.grpFiltroDatos.Controls.Add(Me.cboEstado)
        Me.grpFiltroDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpFiltroDatos.Location = New System.Drawing.Point(12, 12)
        Me.grpFiltroDatos.Name = "grpFiltroDatos"
        Me.grpFiltroDatos.Size = New System.Drawing.Size(376, 71)
        Me.grpFiltroDatos.TabIndex = 1
        Me.grpFiltroDatos.TabStop = False
        Me.grpFiltroDatos.Text = "Filtro de Datos Por"
        '
        'frmStbParamCatalogoValor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 186)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.grpDestinoReporte)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpFiltroDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de  Catálogos Generales")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbParamCatalogoValor"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStbParamCatalogoValor"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDestinoReporte.ResumeLayout(False)
        Me.grpDestinoReporte.PerformLayout()
        Me.grpFiltroDatos.ResumeLayout(False)
        Me.grpFiltroDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents grpDestinoReporte As System.Windows.Forms.GroupBox
    Friend WithEvents radArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents radImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents RadioPant As System.Windows.Forms.RadioButton
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpFiltroDatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboCatalogo As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents cboEstado As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
