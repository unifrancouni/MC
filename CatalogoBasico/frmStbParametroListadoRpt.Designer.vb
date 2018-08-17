<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbParametroListadoRpt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbParametroListadoRpt))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.cboModulo = New C1.Win.C1List.C1Combo
        Me.lblFuente = New System.Windows.Forms.Label
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpdatos.SuspendLayout()
        CType(Me.cboModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.cboModulo)
        Me.grpdatos.Controls.Add(Me.lblFuente)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(351, 59)
        Me.grpdatos.TabIndex = 0
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'cboModulo
        '
        Me.cboModulo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboModulo.AutoCompletion = True
        Me.cboModulo.Caption = ""
        Me.cboModulo.CaptionHeight = 17
        Me.cboModulo.CaptionStyle = Style1
        Me.cboModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModulo.ColumnCaptionHeight = 17
        Me.cboModulo.ColumnFooterHeight = 17
        Me.cboModulo.ContentHeight = 15
        Me.cboModulo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModulo.DisplayMember = "Nombre"
        Me.cboModulo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboModulo.DropDownWidth = 237
        Me.cboModulo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModulo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModulo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModulo.EditorHeight = 15
        Me.cboModulo.EvenRowStyle = Style2
        Me.cboModulo.ExtendRightColumn = True
        Me.cboModulo.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboModulo.FooterStyle = Style3
        Me.cboModulo.GapHeight = 2
        Me.cboModulo.HeadingStyle = Style4
        Me.cboModulo.HighLightRowStyle = Style5
        Me.cboModulo.Images.Add(CType(resources.GetObject("cboModulo.Images"), System.Drawing.Image))
        Me.cboModulo.ItemHeight = 15
        Me.cboModulo.LimitToList = True
        Me.cboModulo.Location = New System.Drawing.Point(95, 19)
        Me.cboModulo.MatchEntryTimeout = CType(2000, Long)
        Me.cboModulo.MaxDropDownItems = CType(5, Short)
        Me.cboModulo.MaxLength = 32767
        Me.cboModulo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModulo.Name = "cboModulo"
        Me.cboModulo.OddRowStyle = Style6
        Me.cboModulo.PartialRightColumn = False
        Me.cboModulo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModulo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModulo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModulo.SelectedStyle = Style7
        Me.cboModulo.Size = New System.Drawing.Size(237, 21)
        Me.cboModulo.Style = Style8
        Me.cboModulo.SuperBack = True
        Me.cboModulo.TabIndex = 8
        Me.cboModulo.ValueMember = "SsgModuloID"
        Me.cboModulo.PropBag = resources.GetString("cboModulo.PropBag")
        '
        'lblFuente
        '
        Me.lblFuente.AutoSize = True
        Me.lblFuente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFuente.Location = New System.Drawing.Point(6, 22)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(45, 13)
        Me.lblFuente.TabIndex = 7
        Me.lblFuente.Text = "Modulo:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(220, 77)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 11
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(295, 77)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 12
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'frmStbParametroListadoRpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 117)
        Me.Controls.Add(Me.grpdatos)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes  Módulo de Catálogos Básicos")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbParametroListadoRpt"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros de Listado de Reportes"
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.cboModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboModulo As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
