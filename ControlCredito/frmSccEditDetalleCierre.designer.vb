<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditDetalleCierre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditDetalleCierre))
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
        Me.grpSociaGe = New System.Windows.Forms.GroupBox
        Me.cneValor = New C1.Win.C1Input.C1NumericEdit
        Me.lblValor = New System.Windows.Forms.Label
        Me.cboMinuta = New C1.Win.C1List.C1Combo
        Me.lblRepresentante = New System.Windows.Forms.Label
        Me.txtHastaRecibo = New System.Windows.Forms.TextBox
        Me.lblHastaRecibo = New System.Windows.Forms.Label
        Me.cdeFechaRecibo = New C1.Win.C1Input.C1DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumRecibo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cdeFechaDeposito = New C1.Win.C1Input.C1DateEdit
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSociaGe.SuspendLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMinuta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(498, 172)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(421, 172)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 1
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
        Me.lblFecha.Location = New System.Drawing.Point(12, 122)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(102, 13)
        Me.lblFecha.TabIndex = 39
        Me.lblFecha.Text = "Fecha del Depósito:"
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.cneValor)
        Me.grpSociaGe.Controls.Add(Me.lblValor)
        Me.grpSociaGe.Controls.Add(Me.cboMinuta)
        Me.grpSociaGe.Controls.Add(Me.lblRepresentante)
        Me.grpSociaGe.Controls.Add(Me.txtHastaRecibo)
        Me.grpSociaGe.Controls.Add(Me.lblHastaRecibo)
        Me.grpSociaGe.Controls.Add(Me.cdeFechaRecibo)
        Me.grpSociaGe.Controls.Add(Me.Label2)
        Me.grpSociaGe.Controls.Add(Me.txtNumRecibo)
        Me.grpSociaGe.Controls.Add(Me.Label1)
        Me.grpSociaGe.Controls.Add(Me.cdeFechaDeposito)
        Me.grpSociaGe.Controls.Add(Me.lblFecha)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 12)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(559, 154)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Datos Generales: "
        '
        'cneValor
        '
        Me.cneValor.AcceptsTab = True
        Me.cneValor.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneValor.DataType = GetType(Double)
        Me.cneValor.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneValor.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneValor.EditFormat.EmptyAsNull = False
        Me.cneValor.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EmptyAsNull = True
        Me.cneValor.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.Location = New System.Drawing.Point(395, 115)
        Me.cneValor.MaskInfo.AutoTabWhenFilled = True
        Me.cneValor.MaxLength = 999999999
        Me.cneValor.Name = "cneValor"
        Me.cneValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValor.Size = New System.Drawing.Size(122, 20)
        Me.cneValor.TabIndex = 120
        Me.cneValor.Tag = Nothing
        Me.cneValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValor.UseColumnStyles = False
        Me.cneValor.Value = 0
        Me.cneValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblValor
        '
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(279, 122)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(113, 19)
        Me.lblValor.TabIndex = 121
        Me.lblValor.Text = "Monto del Depósito:"
        '
        'cboMinuta
        '
        Me.cboMinuta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMinuta.AutoCompletion = True
        Me.cboMinuta.Caption = ""
        Me.cboMinuta.CaptionHeight = 17
        Me.cboMinuta.CaptionStyle = Style1
        Me.cboMinuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMinuta.ColumnCaptionHeight = 17
        Me.cboMinuta.ColumnFooterHeight = 17
        Me.cboMinuta.ContentHeight = 15
        Me.cboMinuta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMinuta.DisplayMember = "sNumeroDeposito"
        Me.cboMinuta.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMinuta.DropDownWidth = 386
        Me.cboMinuta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMinuta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMinuta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMinuta.EditorHeight = 15
        Me.cboMinuta.EvenRowStyle = Style2
        Me.cboMinuta.ExtendRightColumn = True
        Me.cboMinuta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMinuta.FooterStyle = Style3
        Me.cboMinuta.GapHeight = 2
        Me.cboMinuta.HeadingStyle = Style4
        Me.cboMinuta.HighLightRowStyle = Style5
        Me.cboMinuta.Images.Add(CType(resources.GetObject("cboMinuta.Images"), System.Drawing.Image))
        Me.cboMinuta.ItemHeight = 15
        Me.cboMinuta.LimitToList = True
        Me.cboMinuta.Location = New System.Drawing.Point(135, 79)
        Me.cboMinuta.MatchEntryTimeout = CType(2000, Long)
        Me.cboMinuta.MaxDropDownItems = CType(5, Short)
        Me.cboMinuta.MaxLength = 32767
        Me.cboMinuta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMinuta.Name = "cboMinuta"
        Me.cboMinuta.OddRowStyle = Style6
        Me.cboMinuta.PartialRightColumn = False
        Me.cboMinuta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMinuta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMinuta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMinuta.SelectedStyle = Style7
        Me.cboMinuta.Size = New System.Drawing.Size(385, 21)
        Me.cboMinuta.Style = Style8
        Me.cboMinuta.SuperBack = True
        Me.cboMinuta.TabIndex = 118
        Me.cboMinuta.PropBag = resources.GetString("cboMinuta.PropBag")
        '
        'lblRepresentante
        '
        Me.lblRepresentante.AutoSize = True
        Me.lblRepresentante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblRepresentante.Location = New System.Drawing.Point(12, 87)
        Me.lblRepresentante.Name = "lblRepresentante"
        Me.lblRepresentante.Size = New System.Drawing.Size(102, 13)
        Me.lblRepresentante.TabIndex = 119
        Me.lblRepresentante.Text = "Minuta de Depósito:"
        '
        'txtHastaRecibo
        '
        Me.txtHastaRecibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHastaRecibo.Location = New System.Drawing.Point(412, 47)
        Me.txtHastaRecibo.Name = "txtHastaRecibo"
        Me.txtHastaRecibo.Size = New System.Drawing.Size(105, 20)
        Me.txtHastaRecibo.TabIndex = 2
        '
        'lblHastaRecibo
        '
        Me.lblHastaRecibo.AutoSize = True
        Me.lblHastaRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblHastaRecibo.Location = New System.Drawing.Point(279, 54)
        Me.lblHastaRecibo.Name = "lblHastaRecibo"
        Me.lblHastaRecibo.Size = New System.Drawing.Size(95, 13)
        Me.lblHastaRecibo.TabIndex = 47
        Me.lblHastaRecibo.Text = "Hasta Recibo No.:"
        '
        'cdeFechaRecibo
        '
        Me.cdeFechaRecibo.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaRecibo.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaRecibo.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaRecibo.Location = New System.Drawing.Point(135, 16)
        Me.cdeFechaRecibo.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaRecibo.MaskInfo.EmptyAsNull = True
        Me.cdeFechaRecibo.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaRecibo.Name = "cdeFechaRecibo"
        Me.cdeFechaRecibo.Size = New System.Drawing.Size(105, 20)
        Me.cdeFechaRecibo.TabIndex = 0
        Me.cdeFechaRecibo.Tag = Nothing
        Me.cdeFechaRecibo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Fecha del Recibo:"
        '
        'txtNumRecibo
        '
        Me.txtNumRecibo.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumRecibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumRecibo.Location = New System.Drawing.Point(135, 47)
        Me.txtNumRecibo.Name = "txtNumRecibo"
        Me.txtNumRecibo.Size = New System.Drawing.Size(126, 20)
        Me.txtNumRecibo.TabIndex = 1
        Me.txtNumRecibo.Tag = "LAYOUT:FLAT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Número de Recibo:"
        '
        'cdeFechaDeposito
        '
        Me.cdeFechaDeposito.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaDeposito.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaDeposito.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaDeposito.Location = New System.Drawing.Point(135, 115)
        Me.cdeFechaDeposito.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaDeposito.MaskInfo.EmptyAsNull = True
        Me.cdeFechaDeposito.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaDeposito.Name = "cdeFechaDeposito"
        Me.cdeFechaDeposito.Size = New System.Drawing.Size(105, 20)
        Me.cdeFechaDeposito.TabIndex = 4
        Me.cdeFechaDeposito.Tag = Nothing
        Me.cdeFechaDeposito.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'frmSccEditDetalleCierre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 212)
        Me.Controls.Add(Me.grpSociaGe)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Cierre Diario de Cartera")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditDetalleCierre"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Cierre Diario de Caja"
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSociaGe.ResumeLayout(False)
        Me.grpSociaGe.PerformLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMinuta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaDeposito As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtNumRecibo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cdeFechaRecibo As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtHastaRecibo As System.Windows.Forms.TextBox
    Friend WithEvents lblHastaRecibo As System.Windows.Forms.Label
    Friend WithEvents cboMinuta As C1.Win.C1List.C1Combo
    Friend WithEvents lblRepresentante As System.Windows.Forms.Label
    Friend WithEvents cneValor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
