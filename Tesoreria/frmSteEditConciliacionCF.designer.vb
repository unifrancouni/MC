<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditConciliacionCF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditConciliacionCF))
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
        Me.errDocumento = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDocumentos = New System.Windows.Forms.GroupBox
        Me.cboDocumentoHasta = New C1.Win.C1List.C1Combo
        Me.lblDocumentoH = New System.Windows.Forms.Label
        Me.cboDocumentoDesde = New C1.Win.C1List.C1Combo
        Me.lblDocumentoD = New System.Windows.Forms.Label
        Me.cboFuenteFondos = New C1.Win.C1List.C1Combo
        Me.lblFuente = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDocumentos.SuspendLayout()
        CType(Me.cboDocumentoHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDocumentoDesde, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFuenteFondos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(392, 147)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(315, 147)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'errDocumento
        '
        Me.errDocumento.ContainerControl = Me
        '
        'grpDocumentos
        '
        Me.grpDocumentos.Controls.Add(Me.cboDocumentoHasta)
        Me.grpDocumentos.Controls.Add(Me.lblDocumentoH)
        Me.grpDocumentos.Controls.Add(Me.cboDocumentoDesde)
        Me.grpDocumentos.Controls.Add(Me.lblDocumentoD)
        Me.grpDocumentos.Controls.Add(Me.cboFuenteFondos)
        Me.grpDocumentos.Controls.Add(Me.lblFuente)
        Me.grpDocumentos.Location = New System.Drawing.Point(12, 12)
        Me.grpDocumentos.Name = "grpDocumentos"
        Me.grpDocumentos.Size = New System.Drawing.Size(453, 129)
        Me.grpDocumentos.TabIndex = 0
        Me.grpDocumentos.TabStop = False
        Me.grpDocumentos.Text = "Documentos Contables:  "
        '
        'cboDocumentoHasta
        '
        Me.cboDocumentoHasta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDocumentoHasta.AutoCompletion = True
        Me.cboDocumentoHasta.Caption = ""
        Me.cboDocumentoHasta.CaptionHeight = 17
        Me.cboDocumentoHasta.CaptionStyle = Style1
        Me.cboDocumentoHasta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDocumentoHasta.ColumnCaptionHeight = 17
        Me.cboDocumentoHasta.ColumnFooterHeight = 17
        Me.cboDocumentoHasta.ContentHeight = 15
        Me.cboDocumentoHasta.DeadAreaBackColor = System.Drawing.SystemColors.HighlightText
        Me.cboDocumentoHasta.DisplayMember = "sNumeroTransaccion"
        Me.cboDocumentoHasta.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDocumentoHasta.DropDownWidth = 300
        Me.cboDocumentoHasta.EditorBackColor = System.Drawing.SystemColors.HighlightText
        Me.cboDocumentoHasta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDocumentoHasta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDocumentoHasta.EditorHeight = 15
        Me.cboDocumentoHasta.EvenRowStyle = Style2
        Me.cboDocumentoHasta.ExtendRightColumn = True
        Me.cboDocumentoHasta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDocumentoHasta.FooterStyle = Style3
        Me.cboDocumentoHasta.GapHeight = 2
        Me.cboDocumentoHasta.HeadingStyle = Style4
        Me.cboDocumentoHasta.HighLightRowStyle = Style5
        Me.cboDocumentoHasta.Images.Add(CType(resources.GetObject("cboDocumentoHasta.Images"), System.Drawing.Image))
        Me.cboDocumentoHasta.ItemHeight = 15
        Me.cboDocumentoHasta.LimitToList = True
        Me.cboDocumentoHasta.Location = New System.Drawing.Point(146, 92)
        Me.cboDocumentoHasta.MatchEntryTimeout = CType(2000, Long)
        Me.cboDocumentoHasta.MaxDropDownItems = CType(5, Short)
        Me.cboDocumentoHasta.MaxLength = 32767
        Me.cboDocumentoHasta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDocumentoHasta.Name = "cboDocumentoHasta"
        Me.cboDocumentoHasta.OddRowStyle = Style6
        Me.cboDocumentoHasta.PartialRightColumn = False
        Me.cboDocumentoHasta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDocumentoHasta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDocumentoHasta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDocumentoHasta.SelectedStyle = Style7
        Me.cboDocumentoHasta.Size = New System.Drawing.Size(290, 21)
        Me.cboDocumentoHasta.Style = Style8
        Me.cboDocumentoHasta.SuperBack = True
        Me.cboDocumentoHasta.TabIndex = 2
        Me.cboDocumentoHasta.ValueMember = "nScnTransaccionContableID"
        Me.cboDocumentoHasta.PropBag = resources.GetString("cboDocumentoHasta.PropBag")
        '
        'lblDocumentoH
        '
        Me.lblDocumentoH.AutoSize = True
        Me.lblDocumentoH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDocumentoH.Location = New System.Drawing.Point(26, 92)
        Me.lblDocumentoH.Name = "lblDocumentoH"
        Me.lblDocumentoH.Size = New System.Drawing.Size(98, 13)
        Me.lblDocumentoH.TabIndex = 126
        Me.lblDocumentoH.Text = "No. Cheque Hasta:"
        '
        'cboDocumentoDesde
        '
        Me.cboDocumentoDesde.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDocumentoDesde.AutoCompletion = True
        Me.cboDocumentoDesde.Caption = ""
        Me.cboDocumentoDesde.CaptionHeight = 17
        Me.cboDocumentoDesde.CaptionStyle = Style9
        Me.cboDocumentoDesde.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDocumentoDesde.ColumnCaptionHeight = 17
        Me.cboDocumentoDesde.ColumnFooterHeight = 17
        Me.cboDocumentoDesde.ContentHeight = 15
        Me.cboDocumentoDesde.DeadAreaBackColor = System.Drawing.SystemColors.HighlightText
        Me.cboDocumentoDesde.DisplayMember = "sNumeroTransaccion"
        Me.cboDocumentoDesde.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDocumentoDesde.DropDownWidth = 300
        Me.cboDocumentoDesde.EditorBackColor = System.Drawing.SystemColors.HighlightText
        Me.cboDocumentoDesde.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDocumentoDesde.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDocumentoDesde.EditorHeight = 15
        Me.cboDocumentoDesde.EvenRowStyle = Style10
        Me.cboDocumentoDesde.ExtendRightColumn = True
        Me.cboDocumentoDesde.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDocumentoDesde.FooterStyle = Style11
        Me.cboDocumentoDesde.GapHeight = 2
        Me.cboDocumentoDesde.HeadingStyle = Style12
        Me.cboDocumentoDesde.HighLightRowStyle = Style13
        Me.cboDocumentoDesde.Images.Add(CType(resources.GetObject("cboDocumentoDesde.Images"), System.Drawing.Image))
        Me.cboDocumentoDesde.ItemHeight = 15
        Me.cboDocumentoDesde.LimitToList = True
        Me.cboDocumentoDesde.Location = New System.Drawing.Point(146, 61)
        Me.cboDocumentoDesde.MatchEntryTimeout = CType(2000, Long)
        Me.cboDocumentoDesde.MaxDropDownItems = CType(5, Short)
        Me.cboDocumentoDesde.MaxLength = 32767
        Me.cboDocumentoDesde.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDocumentoDesde.Name = "cboDocumentoDesde"
        Me.cboDocumentoDesde.OddRowStyle = Style14
        Me.cboDocumentoDesde.PartialRightColumn = False
        Me.cboDocumentoDesde.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDocumentoDesde.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDocumentoDesde.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDocumentoDesde.SelectedStyle = Style15
        Me.cboDocumentoDesde.Size = New System.Drawing.Size(290, 21)
        Me.cboDocumentoDesde.Style = Style16
        Me.cboDocumentoDesde.SuperBack = True
        Me.cboDocumentoDesde.TabIndex = 1
        Me.cboDocumentoDesde.ValueMember = "nScnTransaccionContableID"
        Me.cboDocumentoDesde.PropBag = resources.GetString("cboDocumentoDesde.PropBag")
        '
        'lblDocumentoD
        '
        Me.lblDocumentoD.AutoSize = True
        Me.lblDocumentoD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDocumentoD.Location = New System.Drawing.Point(26, 61)
        Me.lblDocumentoD.Name = "lblDocumentoD"
        Me.lblDocumentoD.Size = New System.Drawing.Size(101, 13)
        Me.lblDocumentoD.TabIndex = 124
        Me.lblDocumentoD.Text = "No. Cheque Desde:"
        '
        'cboFuenteFondos
        '
        Me.cboFuenteFondos.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFuenteFondos.AutoCompletion = True
        Me.cboFuenteFondos.Caption = ""
        Me.cboFuenteFondos.CaptionHeight = 17
        Me.cboFuenteFondos.CaptionStyle = Style17
        Me.cboFuenteFondos.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFuenteFondos.ColumnCaptionHeight = 17
        Me.cboFuenteFondos.ColumnFooterHeight = 17
        Me.cboFuenteFondos.ContentHeight = 15
        Me.cboFuenteFondos.DeadAreaBackColor = System.Drawing.SystemColors.HighlightText
        Me.cboFuenteFondos.DisplayMember = "sNombre"
        Me.cboFuenteFondos.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFuenteFondos.DropDownWidth = 300
        Me.cboFuenteFondos.EditorBackColor = System.Drawing.SystemColors.HighlightText
        Me.cboFuenteFondos.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFuenteFondos.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFuenteFondos.EditorHeight = 15
        Me.cboFuenteFondos.EvenRowStyle = Style18
        Me.cboFuenteFondos.ExtendRightColumn = True
        Me.cboFuenteFondos.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFuenteFondos.FooterStyle = Style19
        Me.cboFuenteFondos.GapHeight = 2
        Me.cboFuenteFondos.HeadingStyle = Style20
        Me.cboFuenteFondos.HighLightRowStyle = Style21
        Me.cboFuenteFondos.Images.Add(CType(resources.GetObject("cboFuenteFondos.Images"), System.Drawing.Image))
        Me.cboFuenteFondos.ItemHeight = 15
        Me.cboFuenteFondos.LimitToList = True
        Me.cboFuenteFondos.Location = New System.Drawing.Point(146, 32)
        Me.cboFuenteFondos.MatchEntryTimeout = CType(2000, Long)
        Me.cboFuenteFondos.MaxDropDownItems = CType(5, Short)
        Me.cboFuenteFondos.MaxLength = 32767
        Me.cboFuenteFondos.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFuenteFondos.Name = "cboFuenteFondos"
        Me.cboFuenteFondos.OddRowStyle = Style22
        Me.cboFuenteFondos.PartialRightColumn = False
        Me.cboFuenteFondos.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFuenteFondos.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFuenteFondos.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFuenteFondos.SelectedStyle = Style23
        Me.cboFuenteFondos.Size = New System.Drawing.Size(290, 21)
        Me.cboFuenteFondos.Style = Style24
        Me.cboFuenteFondos.SuperBack = True
        Me.cboFuenteFondos.TabIndex = 0
        Me.cboFuenteFondos.ValueMember = "nScnFuenteFinanciamientoID"
        Me.cboFuenteFondos.PropBag = resources.GetString("cboFuenteFondos.PropBag")
        '
        'lblFuente
        '
        Me.lblFuente.AutoSize = True
        Me.lblFuente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFuente.Location = New System.Drawing.Point(26, 32)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(96, 13)
        Me.lblFuente.TabIndex = 43
        Me.lblFuente.Text = "Fuente de Fondos:"
        '
        'frmSteEditConciliacionCF
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 184)
        Me.Controls.Add(Me.grpDocumentos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Conciliación Bancaria")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditConciliacionCF"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Registro de Cheques Flotantes"
        CType(Me.errDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDocumentos.ResumeLayout(False)
        Me.grpDocumentos.PerformLayout()
        CType(Me.cboDocumentoHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDocumentoDesde, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFuenteFondos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errDocumento As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpDocumentos As System.Windows.Forms.GroupBox
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents cboFuenteFondos As C1.Win.C1List.C1Combo
    Friend WithEvents cboDocumentoDesde As C1.Win.C1List.C1Combo
    Friend WithEvents lblDocumentoD As System.Windows.Forms.Label
    Friend WithEvents lblDocumentoH As System.Windows.Forms.Label
    Friend WithEvents cboDocumentoHasta As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
