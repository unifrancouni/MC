<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditReferenciaComercial
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
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style41 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style42 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style43 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style44 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style45 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style46 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style47 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style48 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditReferenciaComercial))
        Me.errGarantiaFiduciaria = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cneAnioRelacion = New C1.Win.C1Input.C1NumericEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblDireccionDomicilio = New System.Windows.Forms.Label
        Me.txtDireccionDomicilio = New System.Windows.Forms.TextBox
        Me.lblCelular = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.lblTelefono = New System.Windows.Forms.Label
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.lblCedula = New System.Windows.Forms.Label
        Me.txtCedula = New System.Windows.Forms.TextBox
        Me.cboFiador = New C1.Win.C1List.C1Combo
        Me.lblFiador = New System.Windows.Forms.Label
        Me.grpOtroCredito = New System.Windows.Forms.GroupBox
        Me.cdeFechaReferencia = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaSolicitud = New System.Windows.Forms.Label
        Me.cboInstitucion = New C1.Win.C1List.C1Combo
        Me.lblDocSoporte = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        CType(Me.errGarantiaFiduciaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneAnioRelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFiador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOtroCredito.SuspendLayout()
        CType(Me.cdeFechaReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errGarantiaFiduciaria
        '
        Me.errGarantiaFiduciaria.ContainerControl = Me
        '
        'cneAnioRelacion
        '
        Me.cneAnioRelacion.AcceptsTab = True
        Me.cneAnioRelacion.CustomFormat = "###,###,###,##0.00"
        Me.cneAnioRelacion.DataType = GetType(Double)
        Me.cneAnioRelacion.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.cneAnioRelacion.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneAnioRelacion.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneAnioRelacion.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneAnioRelacion.EditFormat.EmptyAsNull = False
        Me.cneAnioRelacion.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneAnioRelacion.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneAnioRelacion.EmptyAsNull = True
        Me.cneAnioRelacion.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneAnioRelacion.Location = New System.Drawing.Point(167, 225)
        Me.cneAnioRelacion.MaskInfo.AutoTabWhenFilled = True
        Me.cneAnioRelacion.MaxLength = 2
        Me.cneAnioRelacion.Name = "cneAnioRelacion"
        Me.cneAnioRelacion.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneAnioRelacion.Size = New System.Drawing.Size(152, 20)
        Me.cneAnioRelacion.TabIndex = 6
        Me.cneAnioRelacion.Tag = Nothing
        Me.cneAnioRelacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneAnioRelacion.UseColumnStyles = False
        Me.cneAnioRelacion.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 142
        Me.Label2.Text = "Años de relación:"
        '
        'lblDireccionDomicilio
        '
        Me.lblDireccionDomicilio.AutoSize = True
        Me.lblDireccionDomicilio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDireccionDomicilio.Location = New System.Drawing.Point(12, 188)
        Me.lblDireccionDomicilio.Name = "lblDireccionDomicilio"
        Me.lblDireccionDomicilio.Size = New System.Drawing.Size(114, 13)
        Me.lblDireccionDomicilio.TabIndex = 140
        Me.lblDireccionDomicilio.Text = "Dirección del Domicilio"
        '
        'txtDireccionDomicilio
        '
        Me.txtDireccionDomicilio.BackColor = System.Drawing.SystemColors.Info
        Me.txtDireccionDomicilio.Enabled = False
        Me.txtDireccionDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccionDomicilio.Location = New System.Drawing.Point(167, 181)
        Me.txtDireccionDomicilio.Name = "txtDireccionDomicilio"
        Me.txtDireccionDomicilio.ReadOnly = True
        Me.txtDireccionDomicilio.ShortcutsEnabled = False
        Me.txtDireccionDomicilio.Size = New System.Drawing.Size(447, 20)
        Me.txtDireccionDomicilio.TabIndex = 139
        Me.txtDireccionDomicilio.Tag = "LAYOUT:FLAT"
        '
        'lblCelular
        '
        Me.lblCelular.AutoSize = True
        Me.lblCelular.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCelular.Location = New System.Drawing.Point(376, 162)
        Me.lblCelular.Name = "lblCelular"
        Me.lblCelular.Size = New System.Drawing.Size(42, 13)
        Me.lblCelular.TabIndex = 138
        Me.lblCelular.Text = "Celular:"
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.SystemColors.Info
        Me.txtCelular.Enabled = False
        Me.txtCelular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(457, 155)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.ReadOnly = True
        Me.txtCelular.ShortcutsEnabled = False
        Me.txtCelular.Size = New System.Drawing.Size(157, 20)
        Me.txtCelular.TabIndex = 137
        Me.txtCelular.Tag = "LAYOUT:FLAT"
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTelefono.Location = New System.Drawing.Point(12, 162)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(52, 13)
        Me.lblTelefono.TabIndex = 136
        Me.lblTelefono.Text = "Teléfono:"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Info
        Me.txtTelefono.Enabled = False
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(167, 155)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.ShortcutsEnabled = False
        Me.txtTelefono.Size = New System.Drawing.Size(157, 20)
        Me.txtTelefono.TabIndex = 135
        Me.txtTelefono.Tag = "LAYOUT:FLAT"
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(12, 136)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(98, 13)
        Me.lblCedula.TabIndex = 134
        Me.lblCedula.Text = "Número de Cédula:"
        '
        'txtCedula
        '
        Me.txtCedula.BackColor = System.Drawing.SystemColors.Info
        Me.txtCedula.Enabled = False
        Me.txtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCedula.Location = New System.Drawing.Point(167, 129)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.ReadOnly = True
        Me.txtCedula.ShortcutsEnabled = False
        Me.txtCedula.Size = New System.Drawing.Size(157, 20)
        Me.txtCedula.TabIndex = 133
        Me.txtCedula.Tag = "LAYOUT:FLAT"
        '
        'cboFiador
        '
        Me.cboFiador.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFiador.AutoCompletion = True
        Me.cboFiador.Caption = ""
        Me.cboFiador.CaptionHeight = 17
        Me.cboFiador.CaptionStyle = Style33
        Me.cboFiador.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFiador.ColumnCaptionHeight = 17
        Me.cboFiador.ColumnFooterHeight = 17
        Me.cboFiador.ContentHeight = 15
        Me.cboFiador.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFiador.DisplayMember = "sFiador"
        Me.cboFiador.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFiador.DropDownWidth = 310
        Me.cboFiador.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFiador.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFiador.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFiador.EditorHeight = 15
        Me.cboFiador.EvenRowStyle = Style34
        Me.cboFiador.ExtendRightColumn = True
        Me.cboFiador.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFiador.FooterStyle = Style35
        Me.cboFiador.GapHeight = 2
        Me.cboFiador.HeadingStyle = Style36
        Me.cboFiador.HighLightRowStyle = Style37
        Me.cboFiador.Images.Add(CType(resources.GetObject("cboFiador.Images"), System.Drawing.Image))
        Me.cboFiador.ItemHeight = 15
        Me.cboFiador.LimitToList = True
        Me.cboFiador.Location = New System.Drawing.Point(167, 93)
        Me.cboFiador.MatchEntryTimeout = CType(2000, Long)
        Me.cboFiador.MaxDropDownItems = CType(5, Short)
        Me.cboFiador.MaxLength = 32767
        Me.cboFiador.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFiador.Name = "cboFiador"
        Me.cboFiador.OddRowStyle = Style38
        Me.cboFiador.PartialRightColumn = False
        Me.cboFiador.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFiador.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFiador.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFiador.SelectedStyle = Style39
        Me.cboFiador.Size = New System.Drawing.Size(276, 21)
        Me.cboFiador.Style = Style40
        Me.cboFiador.SuperBack = True
        Me.cboFiador.TabIndex = 5
        Me.cboFiador.PropBag = resources.GetString("cboFiador.PropBag")
        '
        'lblFiador
        '
        Me.lblFiador.AutoSize = True
        Me.lblFiador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFiador.Location = New System.Drawing.Point(16, 101)
        Me.lblFiador.Name = "lblFiador"
        Me.lblFiador.Size = New System.Drawing.Size(69, 13)
        Me.lblFiador.TabIndex = 132
        Me.lblFiador.Text = "Referente(a):"
        '
        'grpOtroCredito
        '
        Me.grpOtroCredito.Controls.Add(Me.cneAnioRelacion)
        Me.grpOtroCredito.Controls.Add(Me.Label2)
        Me.grpOtroCredito.Controls.Add(Me.lblDireccionDomicilio)
        Me.grpOtroCredito.Controls.Add(Me.txtDireccionDomicilio)
        Me.grpOtroCredito.Controls.Add(Me.lblCelular)
        Me.grpOtroCredito.Controls.Add(Me.txtCelular)
        Me.grpOtroCredito.Controls.Add(Me.lblTelefono)
        Me.grpOtroCredito.Controls.Add(Me.txtTelefono)
        Me.grpOtroCredito.Controls.Add(Me.lblCedula)
        Me.grpOtroCredito.Controls.Add(Me.txtCedula)
        Me.grpOtroCredito.Controls.Add(Me.cboFiador)
        Me.grpOtroCredito.Controls.Add(Me.lblFiador)
        Me.grpOtroCredito.Controls.Add(Me.cdeFechaReferencia)
        Me.grpOtroCredito.Controls.Add(Me.lblFechaSolicitud)
        Me.grpOtroCredito.Controls.Add(Me.cboInstitucion)
        Me.grpOtroCredito.Controls.Add(Me.lblDocSoporte)
        Me.grpOtroCredito.Location = New System.Drawing.Point(12, 12)
        Me.grpOtroCredito.Name = "grpOtroCredito"
        Me.grpOtroCredito.Size = New System.Drawing.Size(631, 265)
        Me.grpOtroCredito.TabIndex = 7
        Me.grpOtroCredito.TabStop = False
        Me.grpOtroCredito.Text = "Datos Referencia Bancaria"
        '
        'cdeFechaReferencia
        '
        Me.cdeFechaReferencia.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaReferencia.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaReferencia.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaReferencia.Location = New System.Drawing.Point(167, 55)
        Me.cdeFechaReferencia.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaReferencia.MaskInfo.EmptyAsNull = True
        Me.cdeFechaReferencia.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaReferencia.Name = "cdeFechaReferencia"
        Me.cdeFechaReferencia.Size = New System.Drawing.Size(96, 20)
        Me.cdeFechaReferencia.TabIndex = 4
        Me.cdeFechaReferencia.Tag = Nothing
        Me.cdeFechaReferencia.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaSolicitud
        '
        Me.lblFechaSolicitud.AutoSize = True
        Me.lblFechaSolicitud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaSolicitud.Location = New System.Drawing.Point(11, 62)
        Me.lblFechaSolicitud.Name = "lblFechaSolicitud"
        Me.lblFechaSolicitud.Size = New System.Drawing.Size(110, 13)
        Me.lblFechaSolicitud.TabIndex = 115
        Me.lblFechaSolicitud.Text = "Fecha de Referencia:"
        '
        'cboInstitucion
        '
        Me.cboInstitucion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboInstitucion.AutoCompletion = True
        Me.cboInstitucion.Caption = ""
        Me.cboInstitucion.CaptionHeight = 17
        Me.cboInstitucion.CaptionStyle = Style41
        Me.cboInstitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboInstitucion.ColumnCaptionHeight = 17
        Me.cboInstitucion.ColumnFooterHeight = 17
        Me.cboInstitucion.ContentHeight = 15
        Me.cboInstitucion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboInstitucion.DisplayMember = "sSiglas"
        Me.cboInstitucion.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboInstitucion.DropDownWidth = 310
        Me.cboInstitucion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboInstitucion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInstitucion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboInstitucion.EditorHeight = 15
        Me.cboInstitucion.EvenRowStyle = Style42
        Me.cboInstitucion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboInstitucion.FooterStyle = Style43
        Me.cboInstitucion.GapHeight = 2
        Me.cboInstitucion.HeadingStyle = Style44
        Me.cboInstitucion.HighLightRowStyle = Style45
        Me.cboInstitucion.Images.Add(CType(resources.GetObject("cboInstitucion.Images"), System.Drawing.Image))
        Me.cboInstitucion.ItemHeight = 15
        Me.cboInstitucion.LimitToList = True
        Me.cboInstitucion.Location = New System.Drawing.Point(167, 19)
        Me.cboInstitucion.MatchEntryTimeout = CType(2000, Long)
        Me.cboInstitucion.MaxDropDownItems = CType(5, Short)
        Me.cboInstitucion.MaxLength = 32767
        Me.cboInstitucion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboInstitucion.Name = "cboInstitucion"
        Me.cboInstitucion.OddRowStyle = Style46
        Me.cboInstitucion.PartialRightColumn = False
        Me.cboInstitucion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboInstitucion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboInstitucion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboInstitucion.SelectedStyle = Style47
        Me.cboInstitucion.Size = New System.Drawing.Size(276, 21)
        Me.cboInstitucion.Style = Style48
        Me.cboInstitucion.SuperBack = True
        Me.cboInstitucion.TabIndex = 0
        Me.cboInstitucion.PropBag = resources.GetString("cboInstitucion.PropBag")
        '
        'lblDocSoporte
        '
        Me.lblDocSoporte.AutoSize = True
        Me.lblDocSoporte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDocSoporte.Location = New System.Drawing.Point(11, 27)
        Me.lblDocSoporte.Name = "lblDocSoporte"
        Me.lblDocSoporte.Size = New System.Drawing.Size(54, 13)
        Me.lblDocSoporte.TabIndex = 38
        Me.lblDocSoporte.Text = "Comercio:"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(483, 297)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 8
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(570, 297)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSclEditReferenciaComercial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(652, 327)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpOtroCredito)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclEditReferenciaComercial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Referencia Comercial"
        CType(Me.errGarantiaFiduciaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneAnioRelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFiador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOtroCredito.ResumeLayout(False)
        Me.grpOtroCredito.PerformLayout()
        CType(Me.cdeFechaReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboInstitucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents errGarantiaFiduciaria As System.Windows.Forms.ErrorProvider
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents grpOtroCredito As System.Windows.Forms.GroupBox
    Friend WithEvents cneAnioRelacion As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDireccionDomicilio As System.Windows.Forms.Label
    Friend WithEvents txtDireccionDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents lblCelular As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents cboFiador As C1.Win.C1List.C1Combo
    Friend WithEvents lblFiador As System.Windows.Forms.Label
    Friend WithEvents cdeFechaReferencia As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaSolicitud As System.Windows.Forms.Label
    Friend WithEvents cboInstitucion As C1.Win.C1List.C1Combo
    Friend WithEvents lblDocSoporte As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
