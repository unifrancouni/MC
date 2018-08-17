<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditReciboPagare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditReciboPagare))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpSociaGe = New System.Windows.Forms.GroupBox()
        Me.txtMontoAdeudado = New System.Windows.Forms.TextBox()
        Me.lblMontoAdeudado = New System.Windows.Forms.Label()
        Me.cboMinuta = New C1.Win.C1List.C1Combo()
        Me.lblRepresentante = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.txtCantidadDe = New System.Windows.Forms.TextBox()
        Me.cneValor = New C1.Win.C1Input.C1NumericEdit()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.cdeFecha = New C1.Win.C1Input.C1DateEdit()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.txtNumRecibo = New System.Windows.Forms.TextBox()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.lblCantidadDe = New System.Windows.Forms.Label()
        Me.lblRecibimosDe = New System.Windows.Forms.Label()
        Me.lblNumRecibo = New System.Windows.Forms.Label()
        Me.txtRecibimosDe = New System.Windows.Forms.TextBox()
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ckbPagoNómina = New System.Windows.Forms.CheckBox()
        Me.grpSociaGe.SuspendLayout
        CType(Me.cboMinuta,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cneValor,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.cdeFecha,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.errRecibo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.ckbPagoNómina)
        Me.grpSociaGe.Controls.Add(Me.Label1)
        Me.grpSociaGe.Controls.Add(Me.txtMontoAdeudado)
        Me.grpSociaGe.Controls.Add(Me.lblMontoAdeudado)
        Me.grpSociaGe.Controls.Add(Me.cboMinuta)
        Me.grpSociaGe.Controls.Add(Me.lblRepresentante)
        Me.grpSociaGe.Controls.Add(Me.cmdCancelar)
        Me.grpSociaGe.Controls.Add(Me.cmdAceptar)
        Me.grpSociaGe.Controls.Add(Me.txtCantidadDe)
        Me.grpSociaGe.Controls.Add(Me.cneValor)
        Me.grpSociaGe.Controls.Add(Me.lblValor)
        Me.grpSociaGe.Controls.Add(Me.cdeFecha)
        Me.grpSociaGe.Controls.Add(Me.lblFecha)
        Me.grpSociaGe.Controls.Add(Me.txtNumRecibo)
        Me.grpSociaGe.Controls.Add(Me.lblConcepto)
        Me.grpSociaGe.Controls.Add(Me.txtConcepto)
        Me.grpSociaGe.Controls.Add(Me.lblCantidadDe)
        Me.grpSociaGe.Controls.Add(Me.lblRecibimosDe)
        Me.grpSociaGe.Controls.Add(Me.lblNumRecibo)
        Me.grpSociaGe.Controls.Add(Me.txtRecibimosDe)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 12)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(774, 446)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = false
        Me.grpSociaGe.Text = "Datos Generales: "
        '
        'txtMontoAdeudado
        '
        Me.txtMontoAdeudado.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoAdeudado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMontoAdeudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtMontoAdeudado.Location = New System.Drawing.Point(624, 166)
        Me.txtMontoAdeudado.Name = "txtMontoAdeudado"
        Me.txtMontoAdeudado.Size = New System.Drawing.Size(137, 26)
        Me.txtMontoAdeudado.TabIndex = 120
        Me.txtMontoAdeudado.Tag = "LAYOUT:NONE"
        Me.txtMontoAdeudado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoAdeudado
        '
        Me.lblMontoAdeudado.AutoSize = true
        Me.lblMontoAdeudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblMontoAdeudado.ForeColor = System.Drawing.Color.Black
        Me.lblMontoAdeudado.Location = New System.Drawing.Point(422, 172)
        Me.lblMontoAdeudado.Name = "lblMontoAdeudado"
        Me.lblMontoAdeudado.Size = New System.Drawing.Size(196, 20)
        Me.lblMontoAdeudado.TabIndex = 119
        Me.lblMontoAdeudado.Tag = "LAYOUT:NONE"
        Me.lblMontoAdeudado.Text = "Monto Adeudado Total:"
        '
        'cboMinuta
        '
        Me.cboMinuta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMinuta.AutoCompletion = true
        Me.cboMinuta.Caption = ""
        Me.cboMinuta.CaptionHeight = 17
        Me.cboMinuta.CaptionStyle = Style1
        Me.cboMinuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMinuta.ColumnCaptionHeight = 17
        Me.cboMinuta.ColumnFooterHeight = 17
        Me.cboMinuta.ContentHeight = 21
        Me.cboMinuta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMinuta.DisplayMember = "sNumeroDeposito"
        Me.cboMinuta.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMinuta.DropDownWidth = 386
        Me.cboMinuta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMinuta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cboMinuta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMinuta.EditorHeight = 21
        Me.cboMinuta.EvenRowStyle = Style2
        Me.cboMinuta.ExtendRightColumn = true
        Me.cboMinuta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMinuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cboMinuta.FooterStyle = Style3
        Me.cboMinuta.GapHeight = 2
        Me.cboMinuta.HeadingStyle = Style4
        Me.cboMinuta.HighLightRowStyle = Style5
        Me.cboMinuta.Images.Add(CType(resources.GetObject("cboMinuta.Images"),System.Drawing.Image))
        Me.cboMinuta.ItemHeight = 15
        Me.cboMinuta.LimitToList = true
        Me.cboMinuta.Location = New System.Drawing.Point(155, 364)
        Me.cboMinuta.MatchEntryTimeout = CType(2000,Long)
        Me.cboMinuta.MaxDropDownItems = CType(5,Short)
        Me.cboMinuta.MaxLength = 32767
        Me.cboMinuta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMinuta.Name = "cboMinuta"
        Me.cboMinuta.OddRowStyle = Style6
        Me.cboMinuta.PartialRightColumn = false
        Me.cboMinuta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMinuta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMinuta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMinuta.SelectedStyle = Style7
        Me.cboMinuta.Size = New System.Drawing.Size(385, 27)
        Me.cboMinuta.Style = Style8
        Me.cboMinuta.SuperBack = true
        Me.cboMinuta.TabIndex = 4
        Me.cboMinuta.Tag = "LAYOUT:NONE"
        Me.cboMinuta.PropBag = resources.GetString("cboMinuta.PropBag")
        '
        'lblRepresentante
        '
        Me.lblRepresentante.AutoSize = true
        Me.lblRepresentante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblRepresentante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.lblRepresentante.Location = New System.Drawing.Point(9, 365)
        Me.lblRepresentante.Name = "lblRepresentante"
        Me.lblRepresentante.Size = New System.Drawing.Size(86, 20)
        Me.lblRepresentante.TabIndex = 117
        Me.lblRepresentante.Tag = "LAYOUT:NONE"
        Me.lblRepresentante.Text = "Depósito:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"),System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(688, 410)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = true
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"),System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(611, 410)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 5
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = true
        '
        'txtCantidadDe
        '
        Me.txtCantidadDe.BackColor = System.Drawing.SystemColors.Info
        Me.txtCantidadDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtCantidadDe.Location = New System.Drawing.Point(155, 240)
        Me.txtCantidadDe.Name = "txtCantidadDe"
        Me.txtCantidadDe.Size = New System.Drawing.Size(606, 26)
        Me.txtCantidadDe.TabIndex = 43
        Me.txtCantidadDe.Tag = "LAYOUT:NONE"
        '
        'cneValor
        '
        Me.cneValor.AcceptsTab = true
        Me.cneValor.CustomFormat = "###,###,###,##0.00"
        Me.cneValor.DataType = GetType(Double)
        Me.cneValor.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.cneValor.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)  _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)  _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd),C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneValor.EditFormat.EmptyAsNull = false
        Me.cneValor.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)  _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd),C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EmptyAsNull = true
        Me.cneValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 38.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cneValor.ForeColor = System.Drawing.Color.Red
        Me.cneValor.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.Location = New System.Drawing.Point(155, 156)
        Me.cneValor.MaskInfo.AutoTabWhenFilled = true
        Me.cneValor.MaxLength = 999999999
        Me.cneValor.Name = "cneValor"
        Me.cneValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValor.Size = New System.Drawing.Size(259, 65)
        Me.cneValor.TabIndex = 2
        Me.cneValor.Tag = "LAYOUT:NONE"
        Me.cneValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValor.UseColumnStyles = false
        Me.cneValor.Value = 0R
        Me.cneValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblValor
        '
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.lblValor.Location = New System.Drawing.Point(9, 166)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(93, 19)
        Me.lblValor.TabIndex = 41
        Me.lblValor.Tag = "LAYOUT:NONE"
        Me.lblValor.Text = "Valor C$:"
        '
        'cdeFecha
        '
        Me.cdeFecha.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull)  _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart)  _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd),C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cdeFecha.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.Location = New System.Drawing.Point(155, 104)
        Me.cdeFecha.MaskInfo.AutoTabWhenFilled = true
        Me.cdeFecha.MaskInfo.EmptyAsNull = true
        Me.cdeFecha.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage),C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFecha.Name = "cdeFecha"
        Me.cdeFecha.Size = New System.Drawing.Size(196, 35)
        Me.cdeFecha.TabIndex = 1
        Me.cdeFecha.Tag = "LAYOUT:NONE"
        Me.cdeFecha.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = true
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.lblFecha.Location = New System.Drawing.Point(9, 114)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(64, 20)
        Me.lblFecha.TabIndex = 39
        Me.lblFecha.Tag = "LAYOUT:NONE"
        Me.lblFecha.Text = "Fecha:"
        '
        'txtNumRecibo
        '
        Me.txtNumRecibo.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumRecibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNumRecibo.Location = New System.Drawing.Point(155, 19)
        Me.txtNumRecibo.Name = "txtNumRecibo"
        Me.txtNumRecibo.Size = New System.Drawing.Size(126, 26)
        Me.txtNumRecibo.TabIndex = 0
        Me.txtNumRecibo.Tag = "LAYOUT:NONE"
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = true
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.lblConcepto.Location = New System.Drawing.Point(9, 286)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(140, 20)
        Me.lblConcepto.TabIndex = 35
        Me.lblConcepto.Tag = "LAYOUT:NONE"
        Me.lblConcepto.Text = "En concepto de:"
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtConcepto.Location = New System.Drawing.Point(155, 283)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(606, 26)
        Me.txtConcepto.TabIndex = 3
        Me.txtConcepto.Tag = "LAYOUT:NONE"
        '
        'lblCantidadDe
        '
        Me.lblCantidadDe.AutoSize = true
        Me.lblCantidadDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCantidadDe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.lblCantidadDe.Location = New System.Drawing.Point(9, 244)
        Me.lblCantidadDe.Name = "lblCantidadDe"
        Me.lblCantidadDe.Size = New System.Drawing.Size(136, 20)
        Me.lblCantidadDe.TabIndex = 30
        Me.lblCantidadDe.Tag = "LAYOUT:NONE"
        Me.lblCantidadDe.Text = "La Cantidad de:"
        '
        'lblRecibimosDe
        '
        Me.lblRecibimosDe.AutoSize = true
        Me.lblRecibimosDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblRecibimosDe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.lblRecibimosDe.Location = New System.Drawing.Point(9, 68)
        Me.lblRecibimosDe.Name = "lblRecibimosDe"
        Me.lblRecibimosDe.Size = New System.Drawing.Size(122, 20)
        Me.lblRecibimosDe.TabIndex = 26
        Me.lblRecibimosDe.Tag = "LAYOUT:NONE"
        Me.lblRecibimosDe.Text = "Recibimos de:"
        '
        'lblNumRecibo
        '
        Me.lblNumRecibo.AutoSize = true
        Me.lblNumRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblNumRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.lblNumRecibo.Location = New System.Drawing.Point(9, 25)
        Me.lblNumRecibo.Name = "lblNumRecibo"
        Me.lblNumRecibo.Size = New System.Drawing.Size(127, 20)
        Me.lblNumRecibo.TabIndex = 25
        Me.lblNumRecibo.Tag = "LAYOUT:NONE"
        Me.lblNumRecibo.Text = "No. de Recibo:"
        '
        'txtRecibimosDe
        '
        Me.txtRecibimosDe.BackColor = System.Drawing.SystemColors.Info
        Me.txtRecibimosDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRecibimosDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtRecibimosDe.Location = New System.Drawing.Point(155, 62)
        Me.txtRecibimosDe.Name = "txtRecibimosDe"
        Me.txtRecibimosDe.Size = New System.Drawing.Size(606, 26)
        Me.txtRecibimosDe.TabIndex = 1
        Me.txtRecibimosDe.Tag = "LAYOUT:NONE"
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73,Byte),Integer), CType(CType(35,Byte),Integer), CType(CType(254,Byte),Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 329)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 20)
        Me.Label1.TabIndex = 121
        Me.Label1.Tag = "LAYOUT:NONE"
        Me.Label1.Text = "Pago por Nómina"
        '
        'ckbPagoNómina
        '
        Me.ckbPagoNómina.AutoSize = true
        Me.ckbPagoNómina.Location = New System.Drawing.Point(161, 335)
        Me.ckbPagoNómina.Name = "ckbPagoNómina"
        Me.ckbPagoNómina.Size = New System.Drawing.Size(15, 14)
        Me.ckbPagoNómina.TabIndex = 122
        Me.ckbPagoNómina.UseVisualStyleBackColor = true
        '
        'frmSteEditReciboPagare
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(798, 470)
        Me.ControlBox = false
        Me.Controls.Add(Me.grpSociaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Pagaré Cajeros")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmSteEditReciboPagare"
        Me.HelpProvider.SetShowHelp(Me, true)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro Recibo Pagaré "
        Me.grpSociaGe.ResumeLayout(false)
        Me.grpSociaGe.PerformLayout
        CType(Me.cboMinuta,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cneValor,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.cdeFecha,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.errRecibo,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents txtRecibimosDe As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblRecibimosDe As System.Windows.Forms.Label
    Friend WithEvents lblCantidadDe As System.Windows.Forms.Label
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents lblNumRecibo As System.Windows.Forms.Label
    Friend WithEvents txtNumRecibo As System.Windows.Forms.TextBox
    Friend WithEvents cdeFecha As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cneValor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents txtCantidadDe As System.Windows.Forms.TextBox
    Friend WithEvents cboMinuta As C1.Win.C1List.C1Combo
    Friend WithEvents lblRepresentante As System.Windows.Forms.Label
    Friend WithEvents txtMontoAdeudado As System.Windows.Forms.TextBox
    Friend WithEvents lblMontoAdeudado As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents ckbPagoNómina As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
