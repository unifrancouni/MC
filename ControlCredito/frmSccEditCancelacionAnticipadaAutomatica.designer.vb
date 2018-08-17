<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditCancelacionAnticipadaAutomatica
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
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditCancelacionAnticipadaAutomatica))
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpSociaGe = New System.Windows.Forms.GroupBox
        Me.txtMoraCuota = New System.Windows.Forms.TextBox
        Me.lblMoraCuota = New System.Windows.Forms.Label
        Me.txtMontoAdeudadoCuota = New System.Windows.Forms.TextBox
        Me.lblMontoCuota = New System.Windows.Forms.Label
        Me.txtMora = New System.Windows.Forms.TextBox
        Me.lblMoraTotal = New System.Windows.Forms.Label
        Me.txtMontoAdeudado = New System.Windows.Forms.TextBox
        Me.lblMontoAdeudado = New System.Windows.Forms.Label
        Me.txtSerieDelegacion = New System.Windows.Forms.TextBox
        Me.cboRepresentante = New C1.Win.C1List.C1Combo
        Me.lblRepresentante = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.txtCantidadDe = New System.Windows.Forms.TextBox
        Me.cneValor = New C1.Win.C1Input.C1NumericEdit
        Me.lblValor = New System.Windows.Forms.Label
        Me.cdeFecha = New C1.Win.C1Input.C1DateEdit
        Me.lblFecha = New System.Windows.Forms.Label
        Me.txtNumRecibo = New System.Windows.Forms.TextBox
        Me.lblConcepto = New System.Windows.Forms.Label
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.txtPorCuentaDe = New System.Windows.Forms.TextBox
        Me.lblCantidadDe = New System.Windows.Forms.Label
        Me.lblPorCuentaDe = New System.Windows.Forms.Label
        Me.lblRecibimosDe = New System.Windows.Forms.Label
        Me.lblNumRecibo = New System.Windows.Forms.Label
        Me.txtRecibimosDe = New System.Windows.Forms.TextBox
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grdDesglosePago = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpSociaGe.SuspendLayout()
        CType(Me.cboRepresentante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDesglosePago, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.txtMoraCuota)
        Me.grpSociaGe.Controls.Add(Me.lblMoraCuota)
        Me.grpSociaGe.Controls.Add(Me.txtMontoAdeudadoCuota)
        Me.grpSociaGe.Controls.Add(Me.lblMontoCuota)
        Me.grpSociaGe.Controls.Add(Me.txtMora)
        Me.grpSociaGe.Controls.Add(Me.lblMoraTotal)
        Me.grpSociaGe.Controls.Add(Me.txtMontoAdeudado)
        Me.grpSociaGe.Controls.Add(Me.lblMontoAdeudado)
        Me.grpSociaGe.Controls.Add(Me.txtSerieDelegacion)
        Me.grpSociaGe.Controls.Add(Me.cboRepresentante)
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
        Me.grpSociaGe.Controls.Add(Me.txtPorCuentaDe)
        Me.grpSociaGe.Controls.Add(Me.lblCantidadDe)
        Me.grpSociaGe.Controls.Add(Me.lblPorCuentaDe)
        Me.grpSociaGe.Controls.Add(Me.lblRecibimosDe)
        Me.grpSociaGe.Controls.Add(Me.lblNumRecibo)
        Me.grpSociaGe.Controls.Add(Me.txtRecibimosDe)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 12)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(774, 405)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Datos Generales: "
        '
        'txtMoraCuota
        '
        Me.txtMoraCuota.BackColor = System.Drawing.SystemColors.Info
        Me.txtMoraCuota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMoraCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoraCuota.Location = New System.Drawing.Point(624, 165)
        Me.txtMoraCuota.Name = "txtMoraCuota"
        Me.txtMoraCuota.Size = New System.Drawing.Size(137, 26)
        Me.txtMoraCuota.TabIndex = 126
        Me.txtMoraCuota.Tag = "LAYOUT:NONE"
        Me.txtMoraCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMoraCuota
        '
        Me.lblMoraCuota.AutoSize = True
        Me.lblMoraCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoraCuota.ForeColor = System.Drawing.Color.Black
        Me.lblMoraCuota.Location = New System.Drawing.Point(422, 162)
        Me.lblMoraCuota.Name = "lblMoraCuota"
        Me.lblMoraCuota.Size = New System.Drawing.Size(107, 20)
        Me.lblMoraCuota.TabIndex = 125
        Me.lblMoraCuota.Tag = "LAYOUT:NONE"
        Me.lblMoraCuota.Text = "Mora Cuota:"
        '
        'txtMontoAdeudadoCuota
        '
        Me.txtMontoAdeudadoCuota.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoAdeudadoCuota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMontoAdeudadoCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoAdeudadoCuota.Location = New System.Drawing.Point(624, 136)
        Me.txtMontoAdeudadoCuota.Name = "txtMontoAdeudadoCuota"
        Me.txtMontoAdeudadoCuota.Size = New System.Drawing.Size(137, 26)
        Me.txtMontoAdeudadoCuota.TabIndex = 124
        Me.txtMontoAdeudadoCuota.Tag = "LAYOUT:NONE"
        Me.txtMontoAdeudadoCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoCuota
        '
        Me.lblMontoCuota.AutoSize = True
        Me.lblMontoCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoCuota.ForeColor = System.Drawing.Color.Black
        Me.lblMontoCuota.Location = New System.Drawing.Point(422, 142)
        Me.lblMontoCuota.Name = "lblMontoCuota"
        Me.lblMontoCuota.Size = New System.Drawing.Size(204, 20)
        Me.lblMontoCuota.TabIndex = 123
        Me.lblMontoCuota.Tag = "LAYOUT:NONE"
        Me.lblMontoCuota.Text = "Monto Adeudado Cuota:"
        '
        'txtMora
        '
        Me.txtMora.BackColor = System.Drawing.SystemColors.Info
        Me.txtMora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMora.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMora.Location = New System.Drawing.Point(624, 197)
        Me.txtMora.Name = "txtMora"
        Me.txtMora.Size = New System.Drawing.Size(137, 26)
        Me.txtMora.TabIndex = 122
        Me.txtMora.Tag = "LAYOUT:NONE"
        Me.txtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMoraTotal
        '
        Me.lblMoraTotal.AutoSize = True
        Me.lblMoraTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoraTotal.ForeColor = System.Drawing.Color.Black
        Me.lblMoraTotal.Location = New System.Drawing.Point(422, 181)
        Me.lblMoraTotal.Name = "lblMoraTotal"
        Me.lblMoraTotal.Size = New System.Drawing.Size(99, 20)
        Me.lblMoraTotal.TabIndex = 121
        Me.lblMoraTotal.Tag = "LAYOUT:NONE"
        Me.lblMoraTotal.Text = "Mora Total:"
        '
        'txtMontoAdeudado
        '
        Me.txtMontoAdeudado.BackColor = System.Drawing.SystemColors.Info
        Me.txtMontoAdeudado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMontoAdeudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoAdeudado.Location = New System.Drawing.Point(624, 239)
        Me.txtMontoAdeudado.Name = "txtMontoAdeudado"
        Me.txtMontoAdeudado.Size = New System.Drawing.Size(137, 26)
        Me.txtMontoAdeudado.TabIndex = 120
        Me.txtMontoAdeudado.Tag = "LAYOUT:NONE"
        Me.txtMontoAdeudado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMontoAdeudado
        '
        Me.lblMontoAdeudado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoAdeudado.ForeColor = System.Drawing.Color.Black
        Me.lblMontoAdeudado.Location = New System.Drawing.Point(422, 231)
        Me.lblMontoAdeudado.Name = "lblMontoAdeudado"
        Me.lblMontoAdeudado.Size = New System.Drawing.Size(187, 42)
        Me.lblMontoAdeudado.TabIndex = 119
        Me.lblMontoAdeudado.Tag = "LAYOUT:NONE"
        Me.lblMontoAdeudado.Text = "Saldo Cancelación:"
        Me.lblMontoAdeudado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSerieDelegacion
        '
        Me.txtSerieDelegacion.BackColor = System.Drawing.SystemColors.Info
        Me.txtSerieDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSerieDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerieDelegacion.Location = New System.Drawing.Point(155, 19)
        Me.txtSerieDelegacion.Name = "txtSerieDelegacion"
        Me.txtSerieDelegacion.Size = New System.Drawing.Size(39, 26)
        Me.txtSerieDelegacion.TabIndex = 118
        Me.txtSerieDelegacion.Tag = "LAYOUT:NONE"
        '
        'cboRepresentante
        '
        Me.cboRepresentante.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboRepresentante.AutoCompletion = True
        Me.cboRepresentante.Caption = ""
        Me.cboRepresentante.CaptionHeight = 17
        Me.cboRepresentante.CaptionStyle = Style33
        Me.cboRepresentante.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboRepresentante.ColumnCaptionHeight = 17
        Me.cboRepresentante.ColumnFooterHeight = 17
        Me.cboRepresentante.ContentHeight = 21
        Me.cboRepresentante.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboRepresentante.DisplayMember = "sNombreEmpleado"
        Me.cboRepresentante.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboRepresentante.DropDownWidth = 386
        Me.cboRepresentante.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboRepresentante.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRepresentante.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRepresentante.EditorHeight = 21
        Me.cboRepresentante.EvenRowStyle = Style34
        Me.cboRepresentante.ExtendRightColumn = True
        Me.cboRepresentante.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboRepresentante.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRepresentante.FooterStyle = Style35
        Me.cboRepresentante.GapHeight = 2
        Me.cboRepresentante.HeadingStyle = Style36
        Me.cboRepresentante.HighLightRowStyle = Style37
        Me.cboRepresentante.Images.Add(CType(resources.GetObject("cboRepresentante.Images"), System.Drawing.Image))
        Me.cboRepresentante.ItemHeight = 15
        Me.cboRepresentante.LimitToList = True
        Me.cboRepresentante.Location = New System.Drawing.Point(155, 372)
        Me.cboRepresentante.MatchEntryTimeout = CType(2000, Long)
        Me.cboRepresentante.MaxDropDownItems = CType(5, Short)
        Me.cboRepresentante.MaxLength = 32767
        Me.cboRepresentante.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboRepresentante.Name = "cboRepresentante"
        Me.cboRepresentante.OddRowStyle = Style38
        Me.cboRepresentante.PartialRightColumn = False
        Me.cboRepresentante.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboRepresentante.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboRepresentante.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboRepresentante.SelectedStyle = Style39
        Me.cboRepresentante.Size = New System.Drawing.Size(385, 27)
        Me.cboRepresentante.Style = Style40
        Me.cboRepresentante.SuperBack = True
        Me.cboRepresentante.TabIndex = 4
        Me.cboRepresentante.Tag = "LAYOUT:NONE"
        Me.cboRepresentante.PropBag = resources.GetString("cboRepresentante.PropBag")
        '
        'lblRepresentante
        '
        Me.lblRepresentante.AutoSize = True
        Me.lblRepresentante.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRepresentante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblRepresentante.Location = New System.Drawing.Point(9, 373)
        Me.lblRepresentante.Name = "lblRepresentante"
        Me.lblRepresentante.Size = New System.Drawing.Size(93, 20)
        Me.lblRepresentante.TabIndex = 117
        Me.lblRepresentante.Tag = "LAYOUT:NONE"
        Me.lblRepresentante.Text = "Cajero (a):"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(688, 374)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(611, 374)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 5
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'txtCantidadDe
        '
        Me.txtCantidadDe.BackColor = System.Drawing.SystemColors.Info
        Me.txtCantidadDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidadDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidadDe.Location = New System.Drawing.Point(155, 286)
        Me.txtCantidadDe.Name = "txtCantidadDe"
        Me.txtCantidadDe.Size = New System.Drawing.Size(606, 26)
        Me.txtCantidadDe.TabIndex = 43
        Me.txtCantidadDe.Tag = "LAYOUT:NONE"
        '
        'cneValor
        '
        Me.cneValor.AcceptsTab = True
        Me.cneValor.CustomFormat = "###,###,###,##0.00"
        Me.cneValor.DataType = GetType(Double)
        Me.cneValor.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.cneValor.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneValor.EditFormat.EmptyAsNull = False
        Me.cneValor.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EmptyAsNull = True
        Me.cneValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 38.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cneValor.ForeColor = System.Drawing.Color.Red
        Me.cneValor.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.Location = New System.Drawing.Point(155, 200)
        Me.cneValor.MaskInfo.AutoTabWhenFilled = True
        Me.cneValor.MaxLength = 999999999
        Me.cneValor.Name = "cneValor"
        Me.cneValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValor.Size = New System.Drawing.Size(259, 65)
        Me.cneValor.TabIndex = 2
        Me.cneValor.Tag = "LAYOUT:NONE"
        Me.cneValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValor.UseColumnStyles = False
        Me.cneValor.Value = 0
        Me.cneValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblValor
        '
        Me.lblValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(9, 210)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(93, 19)
        Me.lblValor.TabIndex = 41
        Me.lblValor.Tag = "LAYOUT:NONE"
        Me.lblValor.Text = "Valor C$:"
        '
        'cdeFecha
        '
        Me.cdeFecha.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cdeFecha.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.Location = New System.Drawing.Point(155, 148)
        Me.cdeFecha.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFecha.MaskInfo.EmptyAsNull = True
        Me.cdeFecha.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFecha.Name = "cdeFecha"
        Me.cdeFecha.Size = New System.Drawing.Size(196, 35)
        Me.cdeFecha.TabIndex = 1
        Me.cdeFecha.Tag = "LAYOUT:NONE"
        Me.cdeFecha.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(9, 158)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(64, 20)
        Me.lblFecha.TabIndex = 39
        Me.lblFecha.Tag = "LAYOUT:NONE"
        Me.lblFecha.Text = "Fecha:"
        '
        'txtNumRecibo
        '
        Me.txtNumRecibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumRecibo.Location = New System.Drawing.Point(200, 19)
        Me.txtNumRecibo.Name = "txtNumRecibo"
        Me.txtNumRecibo.Size = New System.Drawing.Size(126, 26)
        Me.txtNumRecibo.TabIndex = 0
        Me.txtNumRecibo.Tag = "LAYOUT:NONE"
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblConcepto.Location = New System.Drawing.Point(9, 332)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(140, 20)
        Me.lblConcepto.TabIndex = 35
        Me.lblConcepto.Tag = "LAYOUT:NONE"
        Me.lblConcepto.Text = "En concepto de:"
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConcepto.Location = New System.Drawing.Point(155, 329)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(606, 26)
        Me.txtConcepto.TabIndex = 3
        Me.txtConcepto.Tag = "LAYOUT:NONE"
        '
        'txtPorCuentaDe
        '
        Me.txtPorCuentaDe.BackColor = System.Drawing.SystemColors.Info
        Me.txtPorCuentaDe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPorCuentaDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorCuentaDe.Location = New System.Drawing.Point(155, 104)
        Me.txtPorCuentaDe.Name = "txtPorCuentaDe"
        Me.txtPorCuentaDe.Size = New System.Drawing.Size(606, 26)
        Me.txtPorCuentaDe.TabIndex = 3
        Me.txtPorCuentaDe.Tag = "LAYOUT:NONE"
        '
        'lblCantidadDe
        '
        Me.lblCantidadDe.AutoSize = True
        Me.lblCantidadDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCantidadDe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCantidadDe.Location = New System.Drawing.Point(9, 290)
        Me.lblCantidadDe.Name = "lblCantidadDe"
        Me.lblCantidadDe.Size = New System.Drawing.Size(136, 20)
        Me.lblCantidadDe.TabIndex = 30
        Me.lblCantidadDe.Tag = "LAYOUT:NONE"
        Me.lblCantidadDe.Text = "La Cantidad de:"
        '
        'lblPorCuentaDe
        '
        Me.lblPorCuentaDe.AutoSize = True
        Me.lblPorCuentaDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorCuentaDe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPorCuentaDe.Location = New System.Drawing.Point(9, 110)
        Me.lblPorCuentaDe.Name = "lblPorCuentaDe"
        Me.lblPorCuentaDe.Size = New System.Drawing.Size(126, 20)
        Me.lblPorCuentaDe.TabIndex = 28
        Me.lblPorCuentaDe.Tag = "LAYOUT:NONE"
        Me.lblPorCuentaDe.Text = "Por cuenta de:"
        '
        'lblRecibimosDe
        '
        Me.lblRecibimosDe.AutoSize = True
        Me.lblRecibimosDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecibimosDe.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblRecibimosDe.Location = New System.Drawing.Point(9, 68)
        Me.lblRecibimosDe.Name = "lblRecibimosDe"
        Me.lblRecibimosDe.Size = New System.Drawing.Size(122, 20)
        Me.lblRecibimosDe.TabIndex = 26
        Me.lblRecibimosDe.Tag = "LAYOUT:NONE"
        Me.lblRecibimosDe.Text = "Recibimos de:"
        '
        'lblNumRecibo
        '
        Me.lblNumRecibo.AutoSize = True
        Me.lblNumRecibo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
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
        Me.txtRecibimosDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'grdDesglosePago
        '
        Me.grdDesglosePago.AllowFilter = False
        Me.grdDesglosePago.AllowUpdate = False
        Me.grdDesglosePago.Caption = "Desglose del Pago"
        Me.grdDesglosePago.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdDesglosePago.GroupByAreaVisible = False
        Me.grdDesglosePago.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdDesglosePago.Images.Add(CType(resources.GetObject("grdDesglosePago.Images"), System.Drawing.Image))
        Me.grdDesglosePago.Location = New System.Drawing.Point(12, 433)
        Me.grdDesglosePago.Name = "grdDesglosePago"
        Me.grdDesglosePago.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDesglosePago.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDesglosePago.PreviewInfo.ZoomFactor = 75
        Me.grdDesglosePago.PrintInfo.PageSettings = CType(resources.GetObject("grdDesglosePago.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdDesglosePago.Size = New System.Drawing.Size(774, 182)
        Me.grdDesglosePago.TabIndex = 27
        Me.grdDesglosePago.Text = "C1TrueDBGrid1"
        Me.grdDesglosePago.PropBag = resources.GetString("grdDesglosePago.PropBag")
        '
        'frmSccEditCancelacionAnticipadaAutomatica
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(798, 627)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdDesglosePago)
        Me.Controls.Add(Me.grpSociaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Recibo Oficial de Caja Automático")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditCancelacionAnticipadaAutomatica"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelación Anticipada Recibo Automático"
        Me.grpSociaGe.ResumeLayout(False)
        Me.grpSociaGe.PerformLayout()
        CType(Me.cboRepresentante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDesglosePago, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents txtRecibimosDe As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblRecibimosDe As System.Windows.Forms.Label
    Friend WithEvents lblPorCuentaDe As System.Windows.Forms.Label
    Friend WithEvents lblCantidadDe As System.Windows.Forms.Label
    Friend WithEvents txtPorCuentaDe As System.Windows.Forms.TextBox
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
    Friend WithEvents grdDesglosePago As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cboRepresentante As C1.Win.C1List.C1Combo
    Friend WithEvents lblRepresentante As System.Windows.Forms.Label
    Friend WithEvents txtSerieDelegacion As System.Windows.Forms.TextBox
    Friend WithEvents txtMora As System.Windows.Forms.TextBox
    Friend WithEvents lblMoraTotal As System.Windows.Forms.Label
    Friend WithEvents txtMontoAdeudado As System.Windows.Forms.TextBox
    Friend WithEvents lblMontoAdeudado As System.Windows.Forms.Label
    Friend WithEvents txtMoraCuota As System.Windows.Forms.TextBox
    Friend WithEvents lblMoraCuota As System.Windows.Forms.Label
    Friend WithEvents txtMontoAdeudadoCuota As System.Windows.Forms.TextBox
    Friend WithEvents lblMontoCuota As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
