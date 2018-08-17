<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbDatoComplementoRechazo
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
        Me.components = New System.ComponentModel.Container()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbDatoComplementoRechazo))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpGrupo = New System.Windows.Forms.GroupBox()
        Me.txtDato = New System.Windows.Forms.TextBox()
        Me.lblPrompt = New System.Windows.Forms.Label()
        Me.errDato = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cboCarreraTecnica = New C1.Win.C1List.C1Combo()
        Me.grpGrupo.SuspendLayout()
        CType(Me.errDato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCarreraTecnica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpGrupo
        '
        Me.grpGrupo.Controls.Add(Me.cboCarreraTecnica)
        Me.grpGrupo.Controls.Add(Me.Label1)
        Me.grpGrupo.Controls.Add(Me.txtDato)
        Me.grpGrupo.Controls.Add(Me.lblPrompt)
        Me.grpGrupo.Location = New System.Drawing.Point(12, 12)
        Me.grpGrupo.Name = "grpGrupo"
        Me.grpGrupo.Size = New System.Drawing.Size(498, 88)
        Me.grpGrupo.TabIndex = 0
        Me.grpGrupo.TabStop = False
        '
        'txtDato
        '
        Me.txtDato.AcceptsTab = True
        Me.txtDato.HideSelection = False
        Me.txtDato.Location = New System.Drawing.Point(45, 13)
        Me.txtDato.Name = "txtDato"
        Me.txtDato.Size = New System.Drawing.Size(428, 20)
        Me.txtDato.TabIndex = 1
        Me.txtDato.Visible = False
        '
        'lblPrompt
        '
        Me.lblPrompt.AutoSize = True
        Me.lblPrompt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrompt.Location = New System.Drawing.Point(6, 16)
        Me.lblPrompt.Name = "lblPrompt"
        Me.lblPrompt.Size = New System.Drawing.Size(33, 13)
        Me.lblPrompt.TabIndex = 0
        Me.lblPrompt.Text = "Titulo"
        Me.lblPrompt.Visible = False
        '
        'errDato
        '
        Me.errDato.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Motivo"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(360, 106)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 16
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(437, 106)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 17
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cboCarreraTecnica
        '
        Me.cboCarreraTecnica.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCarreraTecnica.AutoCompletion = True
        Me.cboCarreraTecnica.Caption = ""
        Me.cboCarreraTecnica.CaptionHeight = 17
        Me.cboCarreraTecnica.CaptionStyle = Style1
        Me.cboCarreraTecnica.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCarreraTecnica.ColumnCaptionHeight = 17
        Me.cboCarreraTecnica.ColumnFooterHeight = 17
        Me.cboCarreraTecnica.ContentHeight = 15
        Me.cboCarreraTecnica.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCarreraTecnica.DisplayMember = "sDescripcion"
        Me.cboCarreraTecnica.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCarreraTecnica.DropDownWidth = 194
        Me.cboCarreraTecnica.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCarreraTecnica.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCarreraTecnica.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCarreraTecnica.EditorHeight = 15
        Me.cboCarreraTecnica.EvenRowStyle = Style2
        Me.cboCarreraTecnica.ExtendRightColumn = True
        Me.cboCarreraTecnica.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCarreraTecnica.FooterStyle = Style3
        Me.cboCarreraTecnica.GapHeight = 2
        Me.cboCarreraTecnica.HeadingStyle = Style4
        Me.cboCarreraTecnica.HighLightRowStyle = Style5
        Me.cboCarreraTecnica.Images.Add(CType(resources.GetObject("cboCarreraTecnica.Images"), System.Drawing.Image))
        Me.cboCarreraTecnica.ItemHeight = 15
        Me.cboCarreraTecnica.LimitToList = True
        Me.cboCarreraTecnica.Location = New System.Drawing.Point(9, 56)
        Me.cboCarreraTecnica.MatchEntryTimeout = CType(2000, Long)
        Me.cboCarreraTecnica.MaxDropDownItems = CType(5, Short)
        Me.cboCarreraTecnica.MaxLength = 32767
        Me.cboCarreraTecnica.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCarreraTecnica.Name = "cboCarreraTecnica"
        Me.cboCarreraTecnica.OddRowStyle = Style6
        Me.cboCarreraTecnica.PartialRightColumn = False
        Me.cboCarreraTecnica.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCarreraTecnica.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCarreraTecnica.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCarreraTecnica.SelectedStyle = Style7
        Me.cboCarreraTecnica.Size = New System.Drawing.Size(475, 21)
        Me.cboCarreraTecnica.Style = Style8
        Me.cboCarreraTecnica.SuperBack = True
        Me.cboCarreraTecnica.TabIndex = 3
        Me.cboCarreraTecnica.ValueMember = "nStbValorCatalogoID"
        Me.cboCarreraTecnica.PropBag = resources.GetString("cboCarreraTecnica.PropBag")
        '
        'frmStbDatoComplementoRechazo
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(524, 138)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpGrupo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbDatoComplementoRechazo"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dato Complemento"
        Me.grpGrupo.ResumeLayout(False)
        Me.grpGrupo.PerformLayout()
        CType(Me.errDato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCarreraTecnica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpGrupo As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lblPrompt As System.Windows.Forms.Label
    Friend WithEvents txtDato As System.Windows.Forms.TextBox
    Friend WithEvents errDato As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCarreraTecnica As C1.Win.C1List.C1Combo
End Class
