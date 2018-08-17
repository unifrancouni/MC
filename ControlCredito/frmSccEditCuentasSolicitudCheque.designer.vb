<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditCuentasSolicitudCheque
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditCuentasSolicitudCheque))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpDetalle = New System.Windows.Forms.GroupBox
        Me.cneMonto = New C1.Win.C1Input.C1NumericEdit
        Me.lblMonto = New System.Windows.Forms.Label
        Me.lblNombreCuenta = New System.Windows.Forms.Label
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.chkDebe = New System.Windows.Forms.CheckBox
        Me.lblDebito = New System.Windows.Forms.Label
        Me.cboCuenta = New C1.Win.C1List.C1Combo
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.errDetalle = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDetalle.SuspendLayout()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDetalle
        '
        Me.grpDetalle.Controls.Add(Me.cneMonto)
        Me.grpDetalle.Controls.Add(Me.lblMonto)
        Me.grpDetalle.Controls.Add(Me.lblNombreCuenta)
        Me.grpDetalle.Controls.Add(Me.txtCuenta)
        Me.grpDetalle.Controls.Add(Me.chkDebe)
        Me.grpDetalle.Controls.Add(Me.lblDebito)
        Me.grpDetalle.Controls.Add(Me.cboCuenta)
        Me.grpDetalle.Controls.Add(Me.lblCuenta)
        Me.grpDetalle.Location = New System.Drawing.Point(12, 12)
        Me.grpDetalle.Name = "grpDetalle"
        Me.grpDetalle.Size = New System.Drawing.Size(449, 122)
        Me.grpDetalle.TabIndex = 0
        Me.grpDetalle.TabStop = False
        Me.grpDetalle.Text = "Datos de la Cuenta"
        '
        'cneMonto
        '
        Me.cneMonto.AcceptsTab = True
        Me.cneMonto.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMonto.DataType = GetType(Double)
        Me.cneMonto.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneMonto.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMonto.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMonto.EditFormat.EmptyAsNull = False
        Me.cneMonto.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMonto.EmptyAsNull = True
        Me.cneMonto.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.Location = New System.Drawing.Point(113, 86)
        Me.cneMonto.MaskInfo.AutoTabWhenFilled = True
        Me.cneMonto.MaxLength = 999999999
        Me.cneMonto.Name = "cneMonto"
        Me.cneMonto.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMonto.Size = New System.Drawing.Size(146, 20)
        Me.cneMonto.TabIndex = 3
        Me.cneMonto.Tag = Nothing
        Me.cneMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMonto.UseColumnStyles = False
        Me.cneMonto.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(23, 86)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(65, 13)
        Me.lblMonto.TabIndex = 104
        Me.lblMonto.Text = "Monto (C$): "
        '
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.AutoSize = True
        Me.lblNombreCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreCuenta.Location = New System.Drawing.Point(23, 59)
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Size = New System.Drawing.Size(84, 13)
        Me.lblNombreCuenta.TabIndex = 103
        Me.lblNombreCuenta.Text = "Nombre Cuenta:"
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.SystemColors.Info
        Me.txtCuenta.Enabled = False
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(113, 56)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(319, 20)
        Me.txtCuenta.TabIndex = 2
        Me.txtCuenta.Tag = "LAYOUT:FLAT"
        '
        'chkDebe
        '
        Me.chkDebe.AutoSize = True
        Me.chkDebe.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDebe.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkDebe.Location = New System.Drawing.Point(318, 89)
        Me.chkDebe.Name = "chkDebe"
        Me.chkDebe.Size = New System.Drawing.Size(17, 17)
        Me.chkDebe.TabIndex = 4
        Me.chkDebe.Tag = ""
        Me.chkDebe.Text = "  "
        Me.chkDebe.UseVisualStyleBackColor = True
        '
        'lblDebito
        '
        Me.lblDebito.AutoSize = True
        Me.lblDebito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDebito.Location = New System.Drawing.Point(271, 89)
        Me.lblDebito.Name = "lblDebito"
        Me.lblDebito.Size = New System.Drawing.Size(41, 13)
        Me.lblDebito.TabIndex = 101
        Me.lblDebito.Text = "Débito:"
        '
        'cboCuenta
        '
        Me.cboCuenta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCuenta.AutoCompletion = True
        Me.cboCuenta.AutoDropDown = True
        Me.cboCuenta.Caption = ""
        Me.cboCuenta.CaptionHeight = 17
        Me.cboCuenta.CaptionStyle = Style1
        Me.cboCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCuenta.ColumnCaptionHeight = 17
        Me.cboCuenta.ColumnFooterHeight = 17
        Me.cboCuenta.ContentHeight = 15
        Me.cboCuenta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCuenta.DisplayMember = "sCodigoCuenta"
        Me.cboCuenta.DropDownWidth = 320
        Me.cboCuenta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCuenta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCuenta.EditorHeight = 15
        Me.cboCuenta.EvenRowStyle = Style2
        Me.cboCuenta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCuenta.FooterStyle = Style3
        Me.cboCuenta.GapHeight = 2
        Me.cboCuenta.HeadingStyle = Style4
        Me.cboCuenta.HighLightRowStyle = Style5
        Me.cboCuenta.Images.Add(CType(resources.GetObject("cboCuenta.Images"), System.Drawing.Image))
        Me.cboCuenta.ItemHeight = 15
        Me.cboCuenta.LimitToList = True
        Me.cboCuenta.Location = New System.Drawing.Point(113, 29)
        Me.cboCuenta.MatchEntryTimeout = CType(2000, Long)
        Me.cboCuenta.MaxDropDownItems = CType(5, Short)
        Me.cboCuenta.MaxLength = 32767
        Me.cboCuenta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.OddRowStyle = Style6
        Me.cboCuenta.PartialRightColumn = False
        Me.cboCuenta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCuenta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCuenta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCuenta.SelectedStyle = Style7
        Me.cboCuenta.Size = New System.Drawing.Size(319, 21)
        Me.cboCuenta.Style = Style8
        Me.cboCuenta.SuperBack = True
        Me.cboCuenta.TabIndex = 1
        Me.cboCuenta.ValueMember = "nScnCatalogoContableID"
        Me.cboCuenta.PropBag = resources.GetString("cboCuenta.PropBag")
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCuenta.Location = New System.Drawing.Point(23, 29)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(89, 13)
        Me.lblCuenta.TabIndex = 13
        Me.lblCuenta.Text = "Cuenta Contable:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(388, 140)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(311, 140)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 5
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'errDetalle
        '
        Me.errDetalle.ContainerControl = Me
        '
        'frmSccEditCuentasSolicitudCheque
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(473, 177)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpDetalle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Revisión de Solicitudes de Cheque")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditCuentasSolicitudCheque"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de Solicitud de Cheque"
        Me.grpDetalle.ResumeLayout(False)
        Me.grpDetalle.PerformLayout()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cboCuenta As C1.Win.C1List.C1Combo
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents errDetalle As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkDebe As System.Windows.Forms.CheckBox
    Friend WithEvents lblDebito As System.Windows.Forms.Label
    Friend WithEvents lblNombreCuenta As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents cneMonto As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
