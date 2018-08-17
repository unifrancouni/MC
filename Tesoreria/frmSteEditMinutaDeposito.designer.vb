<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditMinutaDeposito
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
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditMinutaDeposito))
        Me.errMinuta = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.CmdAgregarDetalle = New System.Windows.Forms.Button()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cboMunicipio = New C1.Win.C1List.C1Combo()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.cneMonto = New C1.Win.C1Input.C1NumericEdit()
        Me.txtNoDeposito = New System.Windows.Forms.TextBox()
        Me.lblNumeroDeposito = New System.Windows.Forms.Label()
        Me.cdeFechaDeposito = New C1.Win.C1Input.C1DateEdit()
        Me.cboCuenta = New C1.Win.C1List.C1Combo()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.lblFechaDeposito = New System.Windows.Forms.Label()
        Me.gpboxTipoMinuta = New System.Windows.Forms.GroupBox()
        Me.ckbVirtual = New System.Windows.Forms.CheckBox()
        Me.ckbTransferencia = New System.Windows.Forms.CheckBox()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        CType(Me.errMinuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpboxTipoMinuta.SuspendLayout()
        Me.SuspendLayout()
        '
        'errMinuta
        '
        Me.errMinuta.ContainerControl = Me
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.CmdAgregarDetalle)
        Me.grpDatosGenerales.Controls.Add(Me.txtObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.lblObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.cboMunicipio)
        Me.grpDatosGenerales.Controls.Add(Me.lblMunicipio)
        Me.grpDatosGenerales.Controls.Add(Me.cneMonto)
        Me.grpDatosGenerales.Controls.Add(Me.txtNoDeposito)
        Me.grpDatosGenerales.Controls.Add(Me.lblNumeroDeposito)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaDeposito)
        Me.grpDatosGenerales.Controls.Add(Me.cboCuenta)
        Me.grpDatosGenerales.Controls.Add(Me.lblMonto)
        Me.grpDatosGenerales.Controls.Add(Me.lblBanco)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaDeposito)
        Me.grpDatosGenerales.Controls.Add(Me.gpboxTipoMinuta)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(13, 12)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(507, 311)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos del Depósito:  "
        '
        'CmdAgregarDetalle
        '
        Me.CmdAgregarDetalle.Image = Global.SMUSURA0.My.Resources.Resources.AgregarPartidaPresup
        Me.CmdAgregarDetalle.Location = New System.Drawing.Point(307, 259)
        Me.CmdAgregarDetalle.Name = "CmdAgregarDetalle"
        Me.CmdAgregarDetalle.Size = New System.Drawing.Size(32, 23)
        Me.CmdAgregarDetalle.TabIndex = 120
        Me.CmdAgregarDetalle.UseVisualStyleBackColor = True
        Me.CmdAgregarDetalle.Visible = False
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(126, 174)
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
        Me.lblObservaciones.Location = New System.Drawing.Point(22, 177)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 116
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMunicipio.AutoCompletion = True
        Me.cboMunicipio.Caption = ""
        Me.cboMunicipio.CaptionHeight = 17
        Me.cboMunicipio.CaptionStyle = Style1
        Me.cboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMunicipio.ColumnCaptionHeight = 17
        Me.cboMunicipio.ColumnFooterHeight = 17
        Me.cboMunicipio.ContentHeight = 15
        Me.cboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMunicipio.DisplayMember = "sNombre"
        Me.cboMunicipio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMunicipio.DropDownWidth = 191
        Me.cboMunicipio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMunicipio.EditorHeight = 15
        Me.cboMunicipio.EvenRowStyle = Style2
        Me.cboMunicipio.ExtendRightColumn = True
        Me.cboMunicipio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMunicipio.FooterStyle = Style3
        Me.cboMunicipio.GapHeight = 2
        Me.cboMunicipio.HeadingStyle = Style4
        Me.cboMunicipio.HighLightRowStyle = Style5
        Me.cboMunicipio.Images.Add(CType(resources.GetObject("cboMunicipio.Images"), System.Drawing.Image))
        Me.cboMunicipio.ItemHeight = 15
        Me.cboMunicipio.LimitToList = True
        Me.cboMunicipio.Location = New System.Drawing.Point(126, 80)
        Me.cboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.cboMunicipio.MaxLength = 32767
        Me.cboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.OddRowStyle = Style6
        Me.cboMunicipio.PartialRightColumn = False
        Me.cboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMunicipio.SelectedStyle = Style7
        Me.cboMunicipio.Size = New System.Drawing.Size(190, 21)
        Me.cboMunicipio.Style = Style8
        Me.cboMunicipio.SuperBack = True
        Me.cboMunicipio.TabIndex = 2
        Me.cboMunicipio.ValueMember = "nStbMunicipioID"
        Me.cboMunicipio.PropBag = resources.GetString("cboMunicipio.PropBag")
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(22, 81)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(100, 13)
        Me.lblMunicipio.TabIndex = 115
        Me.lblMunicipio.Text = "Municipio Depósito:"
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
        Me.cneMonto.Location = New System.Drawing.Point(126, 141)
        Me.cneMonto.MaskInfo.AutoTabWhenFilled = True
        Me.cneMonto.MaxLength = 999999999
        Me.cneMonto.Name = "cneMonto"
        Me.cneMonto.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMonto.Size = New System.Drawing.Size(127, 20)
        Me.cneMonto.TabIndex = 4
        Me.cneMonto.Tag = Nothing
        Me.cneMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMonto.UseColumnStyles = False
        Me.cneMonto.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txtNoDeposito
        '
        Me.txtNoDeposito.Location = New System.Drawing.Point(126, 50)
        Me.txtNoDeposito.Name = "txtNoDeposito"
        Me.txtNoDeposito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNoDeposito.Size = New System.Drawing.Size(190, 20)
        Me.txtNoDeposito.TabIndex = 1
        Me.txtNoDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumeroDeposito
        '
        Me.lblNumeroDeposito.AutoSize = True
        Me.lblNumeroDeposito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumeroDeposito.Location = New System.Drawing.Point(22, 51)
        Me.lblNumeroDeposito.Name = "lblNumeroDeposito"
        Me.lblNumeroDeposito.Size = New System.Drawing.Size(77, 13)
        Me.lblNumeroDeposito.TabIndex = 114
        Me.lblNumeroDeposito.Text = "No. de Minuta:"
        '
        'cdeFechaDeposito
        '
        Me.cdeFechaDeposito.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaDeposito.Location = New System.Drawing.Point(126, 111)
        Me.cdeFechaDeposito.Name = "cdeFechaDeposito"
        Me.cdeFechaDeposito.Size = New System.Drawing.Size(127, 20)
        Me.cdeFechaDeposito.TabIndex = 3
        Me.cdeFechaDeposito.Tag = Nothing
        Me.cdeFechaDeposito.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
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
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(22, 141)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(101, 13)
        Me.lblMonto.TabIndex = 6
        Me.lblMonto.Text = "Monto Depósito C$:"
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblBanco.Location = New System.Drawing.Point(22, 21)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(89, 13)
        Me.lblBanco.TabIndex = 3
        Me.lblBanco.Text = "Cuenta Bancaria:"
        '
        'lblFechaDeposito
        '
        Me.lblFechaDeposito.AutoSize = True
        Me.lblFechaDeposito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaDeposito.Location = New System.Drawing.Point(22, 111)
        Me.lblFechaDeposito.Name = "lblFechaDeposito"
        Me.lblFechaDeposito.Size = New System.Drawing.Size(85, 13)
        Me.lblFechaDeposito.TabIndex = 2
        Me.lblFechaDeposito.Text = "Fecha Depósito:"
        '
        'gpboxTipoMinuta
        '
        Me.gpboxTipoMinuta.Controls.Add(Me.ckbVirtual)
        Me.gpboxTipoMinuta.Controls.Add(Me.ckbTransferencia)
        Me.gpboxTipoMinuta.Location = New System.Drawing.Point(25, 244)
        Me.gpboxTipoMinuta.Name = "gpboxTipoMinuta"
        Me.gpboxTipoMinuta.Size = New System.Drawing.Size(266, 49)
        Me.gpboxTipoMinuta.TabIndex = 119
        Me.gpboxTipoMinuta.TabStop = False
        Me.gpboxTipoMinuta.Text = "Tipo Minuta"
        Me.gpboxTipoMinuta.Visible = False
        '
        'ckbVirtual
        '
        Me.ckbVirtual.AutoSize = True
        Me.ckbVirtual.Location = New System.Drawing.Point(135, 19)
        Me.ckbVirtual.Name = "ckbVirtual"
        Me.ckbVirtual.Size = New System.Drawing.Size(55, 17)
        Me.ckbVirtual.TabIndex = 118
        Me.ckbVirtual.Text = "Virtual"
        Me.ckbVirtual.UseVisualStyleBackColor = True
        '
        'ckbTransferencia
        '
        Me.ckbTransferencia.AutoSize = True
        Me.ckbTransferencia.Location = New System.Drawing.Point(17, 19)
        Me.ckbTransferencia.Name = "ckbTransferencia"
        Me.ckbTransferencia.Size = New System.Drawing.Size(91, 17)
        Me.ckbTransferencia.TabIndex = 117
        Me.ckbTransferencia.Text = "Transferencia"
        Me.ckbTransferencia.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(369, 331)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(447, 329)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSteEditMinutaDeposito
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(542, 362)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditMinutaDeposito"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Minuta de Depósito"
        CType(Me.errMinuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpboxTipoMinuta.ResumeLayout(False)
        Me.gpboxTipoMinuta.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errMinuta As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaDeposito As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cboCuenta As C1.Win.C1List.C1Combo
    Friend WithEvents lblMonto As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents lblFechaDeposito As System.Windows.Forms.Label
    Friend WithEvents txtNoDeposito As System.Windows.Forms.TextBox
    Friend WithEvents lblNumeroDeposito As System.Windows.Forms.Label
    Friend WithEvents cneMonto As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents ckbTransferencia As System.Windows.Forms.CheckBox
    Friend WithEvents ckbVirtual As CheckBox
    Friend WithEvents gpboxTipoMinuta As GroupBox
    Friend WithEvents CmdAgregarDetalle As Button
End Class
