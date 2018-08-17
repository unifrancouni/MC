<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditCierreCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditCierreCaja))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblFecha = New System.Windows.Forms.Label
        Me.lblFuenteF = New System.Windows.Forms.Label
        Me.cboFuenteF = New C1.Win.C1List.C1Combo
        Me.grpSociaGe = New System.Windows.Forms.GroupBox
        Me.cdeFecha = New C1.Win.C1Input.C1DateEdit
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFuenteF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSociaGe.SuspendLayout()
        CType(Me.cdeFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(498, 120)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(421, 120)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 4
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(20, 34)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(87, 13)
        Me.lblFecha.TabIndex = 39
        Me.lblFecha.Text = "Fecha del Cierre:"
        '
        'lblFuenteF
        '
        Me.lblFuenteF.AutoSize = True
        Me.lblFuenteF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFuenteF.Location = New System.Drawing.Point(20, 68)
        Me.lblFuenteF.Name = "lblFuenteF"
        Me.lblFuenteF.Size = New System.Drawing.Size(132, 13)
        Me.lblFuenteF.TabIndex = 117
        Me.lblFuenteF.Text = "Fuente de Financiamiento:"
        '
        'cboFuenteF
        '
        Me.cboFuenteF.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFuenteF.AutoCompletion = True
        Me.cboFuenteF.Caption = ""
        Me.cboFuenteF.CaptionHeight = 17
        Me.cboFuenteF.CaptionStyle = Style1
        Me.cboFuenteF.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFuenteF.ColumnCaptionHeight = 17
        Me.cboFuenteF.ColumnFooterHeight = 17
        Me.cboFuenteF.ContentHeight = 15
        Me.cboFuenteF.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFuenteF.DisplayMember = "sNombre"
        Me.cboFuenteF.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFuenteF.DropDownWidth = 386
        Me.cboFuenteF.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFuenteF.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFuenteF.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFuenteF.EditorHeight = 15
        Me.cboFuenteF.EvenRowStyle = Style2
        Me.cboFuenteF.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFuenteF.FooterStyle = Style3
        Me.cboFuenteF.GapHeight = 2
        Me.cboFuenteF.HeadingStyle = Style4
        Me.cboFuenteF.HighLightRowStyle = Style5
        Me.cboFuenteF.Images.Add(CType(resources.GetObject("cboFuenteF.Images"), System.Drawing.Image))
        Me.cboFuenteF.ItemHeight = 15
        Me.cboFuenteF.LimitToList = True
        Me.cboFuenteF.Location = New System.Drawing.Point(158, 60)
        Me.cboFuenteF.MatchEntryTimeout = CType(2000, Long)
        Me.cboFuenteF.MaxDropDownItems = CType(5, Short)
        Me.cboFuenteF.MaxLength = 32767
        Me.cboFuenteF.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFuenteF.Name = "cboFuenteF"
        Me.cboFuenteF.OddRowStyle = Style6
        Me.cboFuenteF.PartialRightColumn = False
        Me.cboFuenteF.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFuenteF.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFuenteF.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFuenteF.SelectedStyle = Style7
        Me.cboFuenteF.Size = New System.Drawing.Size(385, 21)
        Me.cboFuenteF.Style = Style8
        Me.cboFuenteF.SuperBack = True
        Me.cboFuenteF.TabIndex = 116
        Me.cboFuenteF.PropBag = resources.GetString("cboFuenteF.PropBag")
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.cboFuenteF)
        Me.grpSociaGe.Controls.Add(Me.lblFuenteF)
        Me.grpSociaGe.Controls.Add(Me.cdeFecha)
        Me.grpSociaGe.Controls.Add(Me.lblFecha)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 12)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(559, 102)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Datos Generales: "
        '
        'cdeFecha
        '
        Me.cdeFecha.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFecha.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.Location = New System.Drawing.Point(158, 27)
        Me.cdeFecha.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFecha.MaskInfo.EmptyAsNull = True
        Me.cdeFecha.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFecha.Name = "cdeFecha"
        Me.cdeFecha.Size = New System.Drawing.Size(105, 20)
        Me.cdeFecha.TabIndex = 1
        Me.cdeFecha.Tag = Nothing
        Me.cdeFecha.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'frmSccEditCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 157)
        Me.Controls.Add(Me.grpSociaGe)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Cierre Diario de Cartera")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditCierreCaja"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierre Diario de Cartera"
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFuenteF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSociaGe.ResumeLayout(False)
        Me.grpSociaGe.PerformLayout()
        CType(Me.cdeFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents cboFuenteF As C1.Win.C1List.C1Combo
    Friend WithEvents lblFuenteF As System.Windows.Forms.Label
    Friend WithEvents cdeFecha As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
