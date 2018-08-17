<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclBusquedaFichasSeguimiento
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
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclBusquedaFichasSeguimiento))
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpSociaGe = New System.Windows.Forms.GroupBox
        Me.GrpFechas = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaInicio = New System.Windows.Forms.Label
        Me.lblFechaCorte = New System.Windows.Forms.Label
        Me.GrpTecnico = New System.Windows.Forms.GroupBox
        Me.cboTecnico = New C1.Win.C1List.C1Combo
        Me.lblTecnico = New System.Windows.Forms.Label
        Me.GrpCedulaSocia = New System.Windows.Forms.GroupBox
        Me.txtNombreSocia = New System.Windows.Forms.TextBox
        Me.lblNombreSocia = New System.Windows.Forms.Label
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox
        Me.lblCedula = New System.Windows.Forms.Label
        Me.GrpNombreCompleto = New System.Windows.Forms.GroupBox
        Me.TxtSegundoApellido = New System.Windows.Forms.TextBox
        Me.TxtPrimerApellido = New System.Windows.Forms.TextBox
        Me.TxtSegundoNombre = New System.Windows.Forms.TextBox
        Me.TxtPrimerNombre = New System.Windows.Forms.TextBox
        Me.lblSegundoApellido = New System.Windows.Forms.Label
        Me.lblPrimerApellido = New System.Windows.Forms.Label
        Me.lblSegundoNombre = New System.Windows.Forms.Label
        Me.lblNombre1 = New System.Windows.Forms.Label
        Me.errSocia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpBotones = New System.Windows.Forms.GroupBox
        Me.LblConteo = New System.Windows.Forms.Label
        Me.cmdUltimo = New System.Windows.Forms.Button
        Me.cmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAnterior = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.grpTipoRpt = New System.Windows.Forms.GroupBox
        Me.RadFechas = New System.Windows.Forms.RadioButton
        Me.RadTecnico = New System.Windows.Forms.RadioButton
        Me.RadSocia = New System.Windows.Forms.RadioButton
        Me.radCedula = New System.Windows.Forms.RadioButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpSociaGe.SuspendLayout()
        Me.GrpFechas.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpTecnico.SuspendLayout()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCedulaSocia.SuspendLayout()
        Me.GrpNombreCompleto.SuspendLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBotones.SuspendLayout()
        Me.grpTipoRpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.GrpFechas)
        Me.grpSociaGe.Controls.Add(Me.GrpTecnico)
        Me.grpSociaGe.Controls.Add(Me.GrpCedulaSocia)
        Me.grpSociaGe.Controls.Add(Me.GrpNombreCompleto)
        Me.grpSociaGe.Location = New System.Drawing.Point(15, 82)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(583, 321)
        Me.grpSociaGe.TabIndex = 1
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Ingrese Datos Búsqueda:"
        '
        'GrpFechas
        '
        Me.GrpFechas.Controls.Add(Me.cdeFechaH)
        Me.GrpFechas.Controls.Add(Me.cdeFechaD)
        Me.GrpFechas.Controls.Add(Me.lblFechaInicio)
        Me.GrpFechas.Controls.Add(Me.lblFechaCorte)
        Me.GrpFechas.Location = New System.Drawing.Point(16, 262)
        Me.GrpFechas.Name = "GrpFechas"
        Me.GrpFechas.Size = New System.Drawing.Size(554, 49)
        Me.GrpFechas.TabIndex = 3
        Me.GrpFechas.TabStop = False
        Me.GrpFechas.Text = "Fechas de Corte:"
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(389, 11)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 3
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(127, 15)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 1
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaInicio.Location = New System.Drawing.Point(9, 22)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaInicio.TabIndex = 0
        Me.lblFechaInicio.Text = "Fecha Desde:"
        '
        'lblFechaCorte
        '
        Me.lblFechaCorte.AutoSize = True
        Me.lblFechaCorte.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaCorte.Location = New System.Drawing.Point(290, 18)
        Me.lblFechaCorte.Name = "lblFechaCorte"
        Me.lblFechaCorte.Size = New System.Drawing.Size(71, 13)
        Me.lblFechaCorte.TabIndex = 2
        Me.lblFechaCorte.Text = "Fecha Hasta:"
        '
        'GrpTecnico
        '
        Me.GrpTecnico.Controls.Add(Me.cboTecnico)
        Me.GrpTecnico.Controls.Add(Me.lblTecnico)
        Me.GrpTecnico.Location = New System.Drawing.Point(16, 200)
        Me.GrpTecnico.Name = "GrpTecnico"
        Me.GrpTecnico.Size = New System.Drawing.Size(554, 56)
        Me.GrpTecnico.TabIndex = 2
        Me.GrpTecnico.TabStop = False
        Me.GrpTecnico.Text = "Nombre Técnico:"
        '
        'cboTecnico
        '
        Me.cboTecnico.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTecnico.AutoCompletion = True
        Me.cboTecnico.Caption = ""
        Me.cboTecnico.CaptionHeight = 17
        Me.cboTecnico.CaptionStyle = Style25
        Me.cboTecnico.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTecnico.ColumnCaptionHeight = 17
        Me.cboTecnico.ColumnFooterHeight = 17
        Me.cboTecnico.ContentHeight = 15
        Me.cboTecnico.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTecnico.DisplayMember = "sNombreEmpleado"
        Me.cboTecnico.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTecnico.DropDownWidth = 423
        Me.cboTecnico.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTecnico.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTecnico.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTecnico.EditorHeight = 15
        Me.cboTecnico.EvenRowStyle = Style26
        Me.cboTecnico.ExtendRightColumn = True
        Me.cboTecnico.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTecnico.FooterStyle = Style27
        Me.cboTecnico.GapHeight = 2
        Me.cboTecnico.HeadingStyle = Style28
        Me.cboTecnico.HighLightRowStyle = Style29
        Me.cboTecnico.Images.Add(CType(resources.GetObject("cboTecnico.Images"), System.Drawing.Image))
        Me.cboTecnico.ItemHeight = 15
        Me.cboTecnico.LimitToList = True
        Me.cboTecnico.Location = New System.Drawing.Point(127, 18)
        Me.cboTecnico.MatchEntryTimeout = CType(2000, Long)
        Me.cboTecnico.MaxDropDownItems = CType(5, Short)
        Me.cboTecnico.MaxLength = 32767
        Me.cboTecnico.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTecnico.Name = "cboTecnico"
        Me.cboTecnico.OddRowStyle = Style30
        Me.cboTecnico.PartialRightColumn = False
        Me.cboTecnico.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTecnico.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTecnico.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTecnico.SelectedStyle = Style31
        Me.cboTecnico.Size = New System.Drawing.Size(420, 21)
        Me.cboTecnico.Style = Style32
        Me.cboTecnico.SuperBack = True
        Me.cboTecnico.TabIndex = 1
        Me.cboTecnico.ValueMember = "nSrhEmpleadoID"
        Me.cboTecnico.PropBag = resources.GetString("cboTecnico.PropBag")
        '
        'lblTecnico
        '
        Me.lblTecnico.AutoSize = True
        Me.lblTecnico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTecnico.Location = New System.Drawing.Point(7, 26)
        Me.lblTecnico.Name = "lblTecnico"
        Me.lblTecnico.Size = New System.Drawing.Size(86, 13)
        Me.lblTecnico.TabIndex = 0
        Me.lblTecnico.Text = "Nombre Técnico"
        '
        'GrpCedulaSocia
        '
        Me.GrpCedulaSocia.Controls.Add(Me.txtNombreSocia)
        Me.GrpCedulaSocia.Controls.Add(Me.lblNombreSocia)
        Me.GrpCedulaSocia.Controls.Add(Me.mtbNumCedula)
        Me.GrpCedulaSocia.Controls.Add(Me.lblCedula)
        Me.GrpCedulaSocia.Location = New System.Drawing.Point(16, 19)
        Me.GrpCedulaSocia.Name = "GrpCedulaSocia"
        Me.GrpCedulaSocia.Size = New System.Drawing.Size(554, 76)
        Me.GrpCedulaSocia.TabIndex = 0
        Me.GrpCedulaSocia.TabStop = False
        Me.GrpCedulaSocia.Text = "Cédula Socia:"
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(126, 45)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(421, 20)
        Me.txtNombreSocia.TabIndex = 3
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(6, 48)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(103, 13)
        Me.lblNombreSocia.TabIndex = 2
        Me.lblNombreSocia.Text = "Nombre de la Socia:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(127, 19)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 1
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(9, 22)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 0
        Me.lblCedula.Text = "Número Cédula:"
        '
        'GrpNombreCompleto
        '
        Me.GrpNombreCompleto.Controls.Add(Me.TxtSegundoApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtPrimerApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtSegundoNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtPrimerNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.lblSegundoApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.lblPrimerApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.lblSegundoNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.lblNombre1)
        Me.GrpNombreCompleto.Location = New System.Drawing.Point(16, 101)
        Me.GrpNombreCompleto.Name = "GrpNombreCompleto"
        Me.GrpNombreCompleto.Size = New System.Drawing.Size(554, 93)
        Me.GrpNombreCompleto.TabIndex = 1
        Me.GrpNombreCompleto.TabStop = False
        Me.GrpNombreCompleto.Text = "Nombres Socia:"
        '
        'TxtSegundoApellido
        '
        Me.TxtSegundoApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSegundoApellido.Location = New System.Drawing.Point(389, 60)
        Me.TxtSegundoApellido.Name = "TxtSegundoApellido"
        Me.TxtSegundoApellido.Size = New System.Drawing.Size(158, 20)
        Me.TxtSegundoApellido.TabIndex = 7
        '
        'TxtPrimerApellido
        '
        Me.TxtPrimerApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrimerApellido.Location = New System.Drawing.Point(127, 60)
        Me.TxtPrimerApellido.Name = "TxtPrimerApellido"
        Me.TxtPrimerApellido.Size = New System.Drawing.Size(158, 20)
        Me.TxtPrimerApellido.TabIndex = 5
        '
        'TxtSegundoNombre
        '
        Me.TxtSegundoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSegundoNombre.Location = New System.Drawing.Point(389, 30)
        Me.TxtSegundoNombre.Name = "TxtSegundoNombre"
        Me.TxtSegundoNombre.Size = New System.Drawing.Size(158, 20)
        Me.TxtSegundoNombre.TabIndex = 3
        '
        'TxtPrimerNombre
        '
        Me.TxtPrimerNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrimerNombre.Location = New System.Drawing.Point(127, 27)
        Me.TxtPrimerNombre.Name = "TxtPrimerNombre"
        Me.TxtPrimerNombre.Size = New System.Drawing.Size(158, 20)
        Me.TxtPrimerNombre.TabIndex = 1
        '
        'lblSegundoApellido
        '
        Me.lblSegundoApellido.AutoSize = True
        Me.lblSegundoApellido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSegundoApellido.Location = New System.Drawing.Point(290, 63)
        Me.lblSegundoApellido.Name = "lblSegundoApellido"
        Me.lblSegundoApellido.Size = New System.Drawing.Size(93, 13)
        Me.lblSegundoApellido.TabIndex = 6
        Me.lblSegundoApellido.Text = "Segundo Apellido:"
        '
        'lblPrimerApellido
        '
        Me.lblPrimerApellido.AutoSize = True
        Me.lblPrimerApellido.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrimerApellido.Location = New System.Drawing.Point(7, 63)
        Me.lblPrimerApellido.Name = "lblPrimerApellido"
        Me.lblPrimerApellido.Size = New System.Drawing.Size(79, 13)
        Me.lblPrimerApellido.TabIndex = 4
        Me.lblPrimerApellido.Text = "Primer Apellido:"
        '
        'lblSegundoNombre
        '
        Me.lblSegundoNombre.AutoSize = True
        Me.lblSegundoNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSegundoNombre.Location = New System.Drawing.Point(290, 30)
        Me.lblSegundoNombre.Name = "lblSegundoNombre"
        Me.lblSegundoNombre.Size = New System.Drawing.Size(93, 13)
        Me.lblSegundoNombre.TabIndex = 2
        Me.lblSegundoNombre.Text = "Segundo Nombre:"
        '
        'lblNombre1
        '
        Me.lblNombre1.AutoSize = True
        Me.lblNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre1.Location = New System.Drawing.Point(7, 30)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(79, 13)
        Me.lblNombre1.TabIndex = 0
        Me.lblNombre1.Text = "Primer Nombre:"
        '
        'errSocia
        '
        Me.errSocia.ContainerControl = Me
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(15, 440)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(583, 50)
        Me.grpBotones.TabIndex = 10
        Me.grpBotones.TabStop = False
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(261, 23)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(0, 13)
        Me.LblConteo.TabIndex = 2
        '
        'cmdUltimo
        '
        Me.cmdUltimo.Image = Global.SMUSURA0.My.Resources.Resources.player_end
        Me.cmdUltimo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUltimo.Location = New System.Drawing.Point(497, 17)
        Me.cmdUltimo.Name = "cmdUltimo"
        Me.cmdUltimo.Size = New System.Drawing.Size(73, 25)
        Me.cmdUltimo.TabIndex = 4
        Me.cmdUltimo.Text = "Ultimo"
        Me.cmdUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdSiguiente
        '
        Me.cmdSiguiente.Image = Global.SMUSURA0.My.Resources.Resources.rightarrow
        Me.cmdSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSiguiente.Location = New System.Drawing.Point(418, 17)
        Me.cmdSiguiente.Name = "cmdSiguiente"
        Me.cmdSiguiente.Size = New System.Drawing.Size(73, 25)
        Me.cmdSiguiente.TabIndex = 3
        Me.cmdSiguiente.Text = "Siguiente"
        Me.cmdSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAnterior
        '
        Me.CmdAnterior.Image = Global.SMUSURA0.My.Resources.Resources.leftarrow
        Me.CmdAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAnterior.Location = New System.Drawing.Point(102, 17)
        Me.CmdAnterior.Name = "CmdAnterior"
        Me.CmdAnterior.Size = New System.Drawing.Size(73, 25)
        Me.CmdAnterior.TabIndex = 1
        Me.CmdAnterior.Text = "Anterior"
        Me.CmdAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAnterior.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = Global.SMUSURA0.My.Resources.Resources.player_start
        Me.CmdPrimero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrimero.Location = New System.Drawing.Point(23, 17)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(73, 25)
        Me.CmdPrimero.TabIndex = 0
        Me.CmdPrimero.Text = "Primero"
        Me.CmdPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(371, 409)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 0
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(525, 409)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(448, 409)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'grpTipoRpt
        '
        Me.grpTipoRpt.Controls.Add(Me.RadFechas)
        Me.grpTipoRpt.Controls.Add(Me.RadTecnico)
        Me.grpTipoRpt.Controls.Add(Me.RadSocia)
        Me.grpTipoRpt.Controls.Add(Me.radCedula)
        Me.grpTipoRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoRpt.ForeColor = System.Drawing.Color.Black
        Me.grpTipoRpt.Location = New System.Drawing.Point(173, 12)
        Me.grpTipoRpt.Name = "grpTipoRpt"
        Me.grpTipoRpt.Size = New System.Drawing.Size(269, 68)
        Me.grpTipoRpt.TabIndex = 0
        Me.grpTipoRpt.TabStop = False
        Me.grpTipoRpt.Text = "Seleccione Tipo de Búsqueda:"
        '
        'RadFechas
        '
        Me.RadFechas.AutoSize = True
        Me.RadFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFechas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadFechas.Location = New System.Drawing.Point(142, 45)
        Me.RadFechas.Name = "RadFechas"
        Me.RadFechas.Size = New System.Drawing.Size(88, 17)
        Me.RadFechas.TabIndex = 3
        Me.RadFechas.Text = "Fechas Corte"
        Me.RadFechas.UseVisualStyleBackColor = True
        '
        'RadTecnico
        '
        Me.RadTecnico.AutoSize = True
        Me.RadTecnico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTecnico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadTecnico.Location = New System.Drawing.Point(23, 45)
        Me.RadTecnico.Name = "RadTecnico"
        Me.RadTecnico.Size = New System.Drawing.Size(104, 17)
        Me.RadTecnico.TabIndex = 2
        Me.RadTecnico.Text = "Nombre Técnico"
        Me.RadTecnico.UseVisualStyleBackColor = True
        '
        'RadSocia
        '
        Me.RadSocia.AutoSize = True
        Me.RadSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadSocia.Location = New System.Drawing.Point(142, 22)
        Me.RadSocia.Name = "RadSocia"
        Me.RadSocia.Size = New System.Drawing.Size(97, 17)
        Me.RadSocia.TabIndex = 1
        Me.RadSocia.Text = "Nombres Socia"
        Me.RadSocia.UseVisualStyleBackColor = True
        '
        'radCedula
        '
        Me.radCedula.AutoSize = True
        Me.radCedula.Checked = True
        Me.radCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radCedula.Location = New System.Drawing.Point(23, 22)
        Me.radCedula.Name = "radCedula"
        Me.radCedula.Size = New System.Drawing.Size(88, 17)
        Me.radCedula.TabIndex = 0
        Me.radCedula.TabStop = True
        Me.radCedula.Text = "Cédula Socia"
        Me.radCedula.UseVisualStyleBackColor = True
        '
        'frmSclBusquedaFichasSeguimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 497)
        Me.Controls.Add(Me.grpTipoRpt)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpSociaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclBusquedaFichasSeguimiento"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Datos de Búsqueda de Fichas de Seguimiento:"
        Me.grpSociaGe.ResumeLayout(False)
        Me.GrpFechas.ResumeLayout(False)
        Me.GrpFechas.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpTecnico.ResumeLayout(False)
        Me.GrpTecnico.PerformLayout()
        CType(Me.cboTecnico, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCedulaSocia.ResumeLayout(False)
        Me.GrpCedulaSocia.PerformLayout()
        Me.GrpNombreCompleto.ResumeLayout(False)
        Me.GrpNombreCompleto.PerformLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.grpTipoRpt.ResumeLayout(False)
        Me.grpTipoRpt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errSocia As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpNombreCompleto As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtSegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblSegundoApellido As System.Windows.Forms.Label
    Friend WithEvents lblPrimerApellido As System.Windows.Forms.Label
    Friend WithEvents lblSegundoNombre As System.Windows.Forms.Label
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents grpTipoRpt As System.Windows.Forms.GroupBox
    Friend WithEvents RadSocia As System.Windows.Forms.RadioButton
    Friend WithEvents radCedula As System.Windows.Forms.RadioButton
    Friend WithEvents RadTecnico As System.Windows.Forms.RadioButton
    Friend WithEvents RadFechas As System.Windows.Forms.RadioButton
    Friend WithEvents GrpCedulaSocia As System.Windows.Forms.GroupBox
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents GrpTecnico As System.Windows.Forms.GroupBox
    Friend WithEvents lblTecnico As System.Windows.Forms.Label
    Friend WithEvents GrpFechas As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaCorte As System.Windows.Forms.Label
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents cboTecnico As C1.Win.C1List.C1Combo
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
