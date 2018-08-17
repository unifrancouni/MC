<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditChequeAnulado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditChequeAnulado))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.errCheque = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox
        Me.cboCuenta = New C1.Win.C1List.C1Combo
        Me.lblChequeH = New System.Windows.Forms.Label
        Me.txtHastaCheque = New System.Windows.Forms.TextBox
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.txtNoCheque = New System.Windows.Forms.TextBox
        Me.lblNumeroCheque = New System.Windows.Forms.Label
        Me.cdeFechaCheque = New C1.Win.C1Input.C1DateEdit
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.lblFechaCheque = New System.Windows.Forms.Label
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.cboTipoPrograma = New C1.Win.C1List.C1Combo
        Me.lblTipoPrograma = New System.Windows.Forms.Label
        CType(Me.errCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errCheque
        '
        Me.errCheque.ContainerControl = Me
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.cboTipoPrograma)
        Me.grpDatosGenerales.Controls.Add(Me.lblTipoPrograma)
        Me.grpDatosGenerales.Controls.Add(Me.cboCuenta)
        Me.grpDatosGenerales.Controls.Add(Me.lblChequeH)
        Me.grpDatosGenerales.Controls.Add(Me.txtHastaCheque)
        Me.grpDatosGenerales.Controls.Add(Me.txtObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.lblObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.txtNoCheque)
        Me.grpDatosGenerales.Controls.Add(Me.lblNumeroCheque)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaCheque)
        Me.grpDatosGenerales.Controls.Add(Me.lblCuenta)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaCheque)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(13, 12)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(473, 254)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos del(os) Cheque(s) Anulado(s): "
        '
        'cboCuenta
        '
        Me.cboCuenta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCuenta.AutoCompletion = True
        Me.cboCuenta.Caption = ""
        Me.cboCuenta.CaptionHeight = 17
        Me.cboCuenta.CaptionStyle = Style9
        Me.cboCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCuenta.ColumnCaptionHeight = 17
        Me.cboCuenta.ColumnFooterHeight = 17
        Me.cboCuenta.ContentHeight = 15
        Me.cboCuenta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCuenta.DisplayMember = "sNumeroCuenta"
        Me.cboCuenta.DropDownWidth = 342
        Me.cboCuenta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCuenta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCuenta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCuenta.EditorHeight = 15
        Me.cboCuenta.EvenRowStyle = Style10
        Me.cboCuenta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCuenta.FooterStyle = Style11
        Me.cboCuenta.GapHeight = 2
        Me.cboCuenta.HeadingStyle = Style12
        Me.cboCuenta.HighLightRowStyle = Style13
        Me.cboCuenta.Images.Add(CType(resources.GetObject("cboCuenta.Images"), System.Drawing.Image))
        Me.cboCuenta.ItemHeight = 15
        Me.cboCuenta.LimitToList = True
        Me.cboCuenta.Location = New System.Drawing.Point(126, 19)
        Me.cboCuenta.MatchEntryTimeout = CType(2000, Long)
        Me.cboCuenta.MaxDropDownItems = CType(5, Short)
        Me.cboCuenta.MaxLength = 32767
        Me.cboCuenta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.OddRowStyle = Style14
        Me.cboCuenta.PartialRightColumn = False
        Me.cboCuenta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCuenta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCuenta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCuenta.SelectedStyle = Style15
        Me.cboCuenta.Size = New System.Drawing.Size(341, 21)
        Me.cboCuenta.Style = Style16
        Me.cboCuenta.SuperBack = True
        Me.cboCuenta.TabIndex = 0
        Me.cboCuenta.ValueMember = "nSteCuentaBancariaID"
        Me.cboCuenta.PropBag = resources.GetString("cboCuenta.PropBag")
        '
        'lblChequeH
        '
        Me.lblChequeH.AutoSize = True
        Me.lblChequeH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblChequeH.Location = New System.Drawing.Point(22, 143)
        Me.lblChequeH.Name = "lblChequeH"
        Me.lblChequeH.Size = New System.Drawing.Size(98, 13)
        Me.lblChequeH.TabIndex = 118
        Me.lblChequeH.Text = "Hasta Cheque No.:"
        '
        'txtHastaCheque
        '
        Me.txtHastaCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHastaCheque.Location = New System.Drawing.Point(126, 143)
        Me.txtHastaCheque.Name = "txtHastaCheque"
        Me.txtHastaCheque.Size = New System.Drawing.Size(126, 20)
        Me.txtHastaCheque.TabIndex = 4
        Me.txtHastaCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(126, 176)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(341, 65)
        Me.txtObservaciones.TabIndex = 5
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(22, 179)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 116
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'txtNoCheque
        '
        Me.txtNoCheque.Location = New System.Drawing.Point(126, 111)
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNoCheque.Size = New System.Drawing.Size(127, 20)
        Me.txtNoCheque.TabIndex = 3
        Me.txtNoCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumeroCheque
        '
        Me.lblNumeroCheque.AutoSize = True
        Me.lblNumeroCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumeroCheque.Location = New System.Drawing.Point(22, 111)
        Me.lblNumeroCheque.Name = "lblNumeroCheque"
        Me.lblNumeroCheque.Size = New System.Drawing.Size(101, 13)
        Me.lblNumeroCheque.TabIndex = 114
        Me.lblNumeroCheque.Text = "Desde Cheque No.:"
        '
        'cdeFechaCheque
        '
        Me.cdeFechaCheque.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCheque.Location = New System.Drawing.Point(126, 74)
        Me.cdeFechaCheque.Name = "cdeFechaCheque"
        Me.cdeFechaCheque.Size = New System.Drawing.Size(127, 20)
        Me.cdeFechaCheque.TabIndex = 2
        Me.cdeFechaCheque.Tag = Nothing
        Me.cdeFechaCheque.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCuenta.Location = New System.Drawing.Point(22, 21)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(89, 13)
        Me.lblCuenta.TabIndex = 3
        Me.lblCuenta.Text = "Cuenta Bancaria:"
        '
        'lblFechaCheque
        '
        Me.lblFechaCheque.AutoSize = True
        Me.lblFechaCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaCheque.Location = New System.Drawing.Point(22, 77)
        Me.lblFechaCheque.Name = "lblFechaCheque"
        Me.lblFechaCheque.Size = New System.Drawing.Size(80, 13)
        Me.lblFechaCheque.TabIndex = 2
        Me.lblFechaCheque.Text = "Fecha Cheque:"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(336, 272)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 0
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(413, 272)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cboTipoPrograma
        '
        Me.cboTipoPrograma.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoPrograma.AutoCompletion = True
        Me.cboTipoPrograma.Caption = ""
        Me.cboTipoPrograma.CaptionHeight = 17
        Me.cboTipoPrograma.CaptionStyle = Style1
        Me.cboTipoPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTipoPrograma.ColumnCaptionHeight = 17
        Me.cboTipoPrograma.ColumnFooterHeight = 17
        Me.cboTipoPrograma.ContentHeight = 15
        Me.cboTipoPrograma.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTipoPrograma.DisplayMember = "sDescripcion"
        Me.cboTipoPrograma.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTipoPrograma.DropDownWidth = 301
        Me.cboTipoPrograma.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTipoPrograma.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoPrograma.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoPrograma.EditorHeight = 15
        Me.cboTipoPrograma.EvenRowStyle = Style2
        Me.cboTipoPrograma.ExtendRightColumn = True
        Me.cboTipoPrograma.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoPrograma.FooterStyle = Style3
        Me.cboTipoPrograma.GapHeight = 2
        Me.cboTipoPrograma.HeadingStyle = Style4
        Me.cboTipoPrograma.HighLightRowStyle = Style5
        Me.cboTipoPrograma.Images.Add(CType(resources.GetObject("cboTipoPrograma.Images"), System.Drawing.Image))
        Me.cboTipoPrograma.ItemHeight = 15
        Me.cboTipoPrograma.LimitToList = True
        Me.cboTipoPrograma.Location = New System.Drawing.Point(126, 46)
        Me.cboTipoPrograma.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoPrograma.MaxDropDownItems = CType(5, Short)
        Me.cboTipoPrograma.MaxLength = 32767
        Me.cboTipoPrograma.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoPrograma.Name = "cboTipoPrograma"
        Me.cboTipoPrograma.OddRowStyle = Style6
        Me.cboTipoPrograma.PartialRightColumn = False
        Me.cboTipoPrograma.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoPrograma.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoPrograma.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoPrograma.SelectedStyle = Style7
        Me.cboTipoPrograma.Size = New System.Drawing.Size(341, 21)
        Me.cboTipoPrograma.Style = Style8
        Me.cboTipoPrograma.SuperBack = True
        Me.cboTipoPrograma.TabIndex = 1
        Me.cboTipoPrograma.ValueMember = "nStbValorCatalogoID"
        Me.cboTipoPrograma.PropBag = resources.GetString("cboTipoPrograma.PropBag")
        '
        'lblTipoPrograma
        '
        Me.lblTipoPrograma.AutoSize = True
        Me.lblTipoPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoPrograma.Location = New System.Drawing.Point(22, 46)
        Me.lblTipoPrograma.Name = "lblTipoPrograma"
        Me.lblTipoPrograma.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoPrograma.TabIndex = 124
        Me.lblTipoPrograma.Text = "Tipo de Programa:"
        '
        'frmSteEditChequeAnulado
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(495, 302)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Recibos Anulados")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditChequeAnulado"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Cheque Anulado"
        CType(Me.errCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCheque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errCheque As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaCheque As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents lblFechaCheque As System.Windows.Forms.Label
    Friend WithEvents txtNoCheque As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroCheque As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblChequeH As System.Windows.Forms.Label
    Friend WithEvents txtHastaCheque As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents cboCuenta As C1.Win.C1List.C1Combo
    Friend WithEvents cboTipoPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblTipoPrograma As System.Windows.Forms.Label
End Class
