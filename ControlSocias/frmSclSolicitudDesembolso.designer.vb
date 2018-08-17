<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclSolicitudDesembolso
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclSolicitudDesembolso))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpGenerales = New System.Windows.Forms.GroupBox()
        Me.lblFuente = New System.Windows.Forms.Label()
        Me.cboFuente = New C1.Win.C1List.C1Combo()
        Me.cdeFechaSolicitud = New C1.Win.C1Input.C1DateEdit()
        Me.cdeFechaDesembolso = New C1.Win.C1Input.C1DateEdit()
        Me.lblFirma1 = New System.Windows.Forms.Label()
        Me.lblFirma2 = New System.Windows.Forms.Label()
        Me.cboFirmaE = New C1.Win.C1List.C1Combo()
        Me.cboFirmaA = New C1.Win.C1List.C1Combo()
        Me.lblApellido1 = New System.Windows.Forms.Label()
        Me.lblNombre1 = New System.Windows.Forms.Label()
        Me.lblDireccion = New System.Windows.Forms.Label()
        Me.txtObservacion = New System.Windows.Forms.TextBox()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.errSolicitudes = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.cboSegundaFuente = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaDesembolso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFirmaE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboFirmaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboSegundaFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.Label1)
        Me.grpGenerales.Controls.Add(Me.cboSegundaFuente)
        Me.grpGenerales.Controls.Add(Me.lblFuente)
        Me.grpGenerales.Controls.Add(Me.cboFuente)
        Me.grpGenerales.Controls.Add(Me.cdeFechaSolicitud)
        Me.grpGenerales.Controls.Add(Me.cdeFechaDesembolso)
        Me.grpGenerales.Controls.Add(Me.lblFirma1)
        Me.grpGenerales.Controls.Add(Me.lblFirma2)
        Me.grpGenerales.Controls.Add(Me.cboFirmaE)
        Me.grpGenerales.Controls.Add(Me.cboFirmaA)
        Me.grpGenerales.Controls.Add(Me.lblApellido1)
        Me.grpGenerales.Controls.Add(Me.lblNombre1)
        Me.grpGenerales.Controls.Add(Me.lblDireccion)
        Me.grpGenerales.Controls.Add(Me.txtObservacion)
        Me.grpGenerales.Location = New System.Drawing.Point(12, 12)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(673, 254)
        Me.grpGenerales.TabIndex = 0
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Datos Generales: "
        '
        'lblFuente
        '
        Me.lblFuente.AutoSize = True
        Me.lblFuente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFuente.Location = New System.Drawing.Point(19, 136)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(117, 13)
        Me.lblFuente.TabIndex = 44
        Me.lblFuente.Text = "Fuente Financiamiento:"
        '
        'cboFuente
        '
        Me.cboFuente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFuente.AutoCompletion = True
        Me.cboFuente.Caption = ""
        Me.cboFuente.CaptionHeight = 17
        Me.cboFuente.CaptionStyle = Style9
        Me.cboFuente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFuente.ColumnCaptionHeight = 17
        Me.cboFuente.ColumnFooterHeight = 17
        Me.cboFuente.ContentHeight = 15
        Me.cboFuente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFuente.DisplayMember = "sNombre"
        Me.cboFuente.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFuente.DropDownWidth = 303
        Me.cboFuente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFuente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFuente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFuente.EditorHeight = 15
        Me.cboFuente.EvenRowStyle = Style10
        Me.cboFuente.ExtendRightColumn = True
        Me.cboFuente.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFuente.FooterStyle = Style11
        Me.cboFuente.GapHeight = 2
        Me.cboFuente.HeadingStyle = Style12
        Me.cboFuente.HighLightRowStyle = Style13
        Me.cboFuente.Images.Add(CType(resources.GetObject("cboFuente.Images"), System.Drawing.Image))
        Me.cboFuente.ItemHeight = 15
        Me.cboFuente.LimitToList = True
        Me.cboFuente.Location = New System.Drawing.Point(148, 136)
        Me.cboFuente.MatchEntryTimeout = CType(2000, Long)
        Me.cboFuente.MaxDropDownItems = CType(5, Short)
        Me.cboFuente.MaxLength = 32767
        Me.cboFuente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFuente.Name = "cboFuente"
        Me.cboFuente.OddRowStyle = Style14
        Me.cboFuente.PartialRightColumn = False
        Me.cboFuente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFuente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFuente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFuente.SelectedStyle = Style15
        Me.cboFuente.Size = New System.Drawing.Size(302, 21)
        Me.cboFuente.Style = Style16
        Me.cboFuente.SuperBack = True
        Me.cboFuente.TabIndex = 4
        Me.cboFuente.ValueMember = "nScnFuenteFinanciamientoID"
        Me.cboFuente.PropBag = resources.GetString("cboFuente.PropBag")
        '
        'cdeFechaSolicitud
        '
        Me.cdeFechaSolicitud.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaSolicitud.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaSolicitud.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaSolicitud.Location = New System.Drawing.Point(148, 31)
        Me.cdeFechaSolicitud.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaSolicitud.MaskInfo.EmptyAsNull = True
        Me.cdeFechaSolicitud.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaSolicitud.Name = "cdeFechaSolicitud"
        Me.cdeFechaSolicitud.Size = New System.Drawing.Size(139, 20)
        Me.cdeFechaSolicitud.TabIndex = 0
        Me.cdeFechaSolicitud.Tag = Nothing
        Me.cdeFechaSolicitud.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaDesembolso
        '
        Me.cdeFechaDesembolso.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.cdeFechaDesembolso.EditFormat.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.cdeFechaDesembolso.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cdeFechaDesembolso.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaDesembolso.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cdeFechaDesembolso.Location = New System.Drawing.Point(148, 57)
        Me.cdeFechaDesembolso.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaDesembolso.MaskInfo.EmptyAsNull = True
        Me.cdeFechaDesembolso.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaDesembolso.Name = "cdeFechaDesembolso"
        Me.cdeFechaDesembolso.Size = New System.Drawing.Size(139, 20)
        Me.cdeFechaDesembolso.TabIndex = 1
        Me.cdeFechaDesembolso.Tag = Nothing
        Me.cdeFechaDesembolso.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFirma1
        '
        Me.lblFirma1.AutoSize = True
        Me.lblFirma1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFirma1.Location = New System.Drawing.Point(19, 80)
        Me.lblFirma1.Name = "lblFirma1"
        Me.lblFirma1.Size = New System.Drawing.Size(108, 13)
        Me.lblFirma1.TabIndex = 40
        Me.lblFirma1.Text = "Empleado Elaborada:"
        '
        'lblFirma2
        '
        Me.lblFirma2.AutoSize = True
        Me.lblFirma2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFirma2.Location = New System.Drawing.Point(19, 107)
        Me.lblFirma2.Name = "lblFirma2"
        Me.lblFirma2.Size = New System.Drawing.Size(98, 13)
        Me.lblFirma2.TabIndex = 38
        Me.lblFirma2.Text = "Empleado Autoriza:"
        '
        'cboFirmaE
        '
        Me.cboFirmaE.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFirmaE.AutoCompletion = True
        Me.cboFirmaE.Caption = ""
        Me.cboFirmaE.CaptionHeight = 17
        Me.cboFirmaE.CaptionStyle = Style17
        Me.cboFirmaE.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFirmaE.ColumnCaptionHeight = 17
        Me.cboFirmaE.ColumnFooterHeight = 17
        Me.cboFirmaE.ContentHeight = 15
        Me.cboFirmaE.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFirmaE.DisplayMember = "sNombre"
        Me.cboFirmaE.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFirmaE.DropDownWidth = 303
        Me.cboFirmaE.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFirmaE.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFirmaE.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFirmaE.EditorHeight = 15
        Me.cboFirmaE.EvenRowStyle = Style18
        Me.cboFirmaE.ExtendRightColumn = True
        Me.cboFirmaE.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFirmaE.FooterStyle = Style19
        Me.cboFirmaE.GapHeight = 2
        Me.cboFirmaE.HeadingStyle = Style20
        Me.cboFirmaE.HighLightRowStyle = Style21
        Me.cboFirmaE.Images.Add(CType(resources.GetObject("cboFirmaE.Images"), System.Drawing.Image))
        Me.cboFirmaE.ItemHeight = 15
        Me.cboFirmaE.LimitToList = True
        Me.cboFirmaE.Location = New System.Drawing.Point(148, 80)
        Me.cboFirmaE.MatchEntryTimeout = CType(2000, Long)
        Me.cboFirmaE.MaxDropDownItems = CType(5, Short)
        Me.cboFirmaE.MaxLength = 32767
        Me.cboFirmaE.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFirmaE.Name = "cboFirmaE"
        Me.cboFirmaE.OddRowStyle = Style22
        Me.cboFirmaE.PartialRightColumn = False
        Me.cboFirmaE.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFirmaE.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFirmaE.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFirmaE.SelectedStyle = Style23
        Me.cboFirmaE.Size = New System.Drawing.Size(302, 21)
        Me.cboFirmaE.Style = Style24
        Me.cboFirmaE.SuperBack = True
        Me.cboFirmaE.TabIndex = 2
        Me.cboFirmaE.ValueMember = "nSrhEmpleadoID"
        Me.cboFirmaE.PropBag = resources.GetString("cboFirmaE.PropBag")
        '
        'cboFirmaA
        '
        Me.cboFirmaA.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFirmaA.AutoCompletion = True
        Me.cboFirmaA.Caption = ""
        Me.cboFirmaA.CaptionHeight = 17
        Me.cboFirmaA.CaptionStyle = Style25
        Me.cboFirmaA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFirmaA.ColumnCaptionHeight = 17
        Me.cboFirmaA.ColumnFooterHeight = 17
        Me.cboFirmaA.ContentHeight = 15
        Me.cboFirmaA.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFirmaA.DisplayMember = "sNombre"
        Me.cboFirmaA.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFirmaA.DropDownWidth = 303
        Me.cboFirmaA.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFirmaA.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFirmaA.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFirmaA.EditorHeight = 15
        Me.cboFirmaA.Enabled = False
        Me.cboFirmaA.EvenRowStyle = Style26
        Me.cboFirmaA.ExtendRightColumn = True
        Me.cboFirmaA.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFirmaA.FooterStyle = Style27
        Me.cboFirmaA.GapHeight = 2
        Me.cboFirmaA.HeadingStyle = Style28
        Me.cboFirmaA.HighLightRowStyle = Style29
        Me.cboFirmaA.Images.Add(CType(resources.GetObject("cboFirmaA.Images"), System.Drawing.Image))
        Me.cboFirmaA.ItemHeight = 15
        Me.cboFirmaA.LimitToList = True
        Me.cboFirmaA.Location = New System.Drawing.Point(148, 107)
        Me.cboFirmaA.MatchEntryTimeout = CType(2000, Long)
        Me.cboFirmaA.MaxDropDownItems = CType(5, Short)
        Me.cboFirmaA.MaxLength = 32767
        Me.cboFirmaA.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFirmaA.Name = "cboFirmaA"
        Me.cboFirmaA.OddRowStyle = Style30
        Me.cboFirmaA.PartialRightColumn = False
        Me.cboFirmaA.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFirmaA.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFirmaA.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFirmaA.SelectedStyle = Style31
        Me.cboFirmaA.Size = New System.Drawing.Size(302, 21)
        Me.cboFirmaA.Style = Style32
        Me.cboFirmaA.SuperBack = True
        Me.cboFirmaA.TabIndex = 3
        Me.cboFirmaA.ValueMember = "nSrhEmpleadoID"
        Me.cboFirmaA.PropBag = resources.GetString("cboFirmaA.PropBag")
        '
        'lblApellido1
        '
        Me.lblApellido1.AutoSize = True
        Me.lblApellido1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblApellido1.Location = New System.Drawing.Point(19, 57)
        Me.lblApellido1.Name = "lblApellido1"
        Me.lblApellido1.Size = New System.Drawing.Size(129, 13)
        Me.lblApellido1.TabIndex = 28
        Me.lblApellido1.Text = "Fecha/Hora Desembolso:"
        '
        'lblNombre1
        '
        Me.lblNombre1.AutoSize = True
        Me.lblNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre1.Location = New System.Drawing.Point(19, 31)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(83, 13)
        Me.lblNombre1.TabIndex = 26
        Me.lblNombre1.Text = "Fecha Solicitud:"
        '
        'lblDireccion
        '
        Me.lblDireccion.AutoSize = True
        Me.lblDireccion.ForeColor = System.Drawing.Color.Black
        Me.lblDireccion.Location = New System.Drawing.Point(19, 203)
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Size = New System.Drawing.Size(81, 13)
        Me.lblDireccion.TabIndex = 26
        Me.lblDireccion.Text = "Observaciones:"
        '
        'txtObservacion
        '
        Me.txtObservacion.Location = New System.Drawing.Point(148, 201)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacion.Size = New System.Drawing.Size(486, 37)
        Me.txtObservacion.TabIndex = 5
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(505, 272)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 6
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(582, 272)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 7
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errSolicitudes
        '
        Me.errSolicitudes.ContainerControl = Me
        '
        'cboSegundaFuente
        '
        Me.cboSegundaFuente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboSegundaFuente.AutoCompletion = True
        Me.cboSegundaFuente.Caption = ""
        Me.cboSegundaFuente.CaptionHeight = 17
        Me.cboSegundaFuente.CaptionStyle = Style1
        Me.cboSegundaFuente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboSegundaFuente.ColumnCaptionHeight = 17
        Me.cboSegundaFuente.ColumnFooterHeight = 17
        Me.cboSegundaFuente.ContentHeight = 15
        Me.cboSegundaFuente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboSegundaFuente.DisplayMember = "sNombre"
        Me.cboSegundaFuente.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboSegundaFuente.DropDownWidth = 303
        Me.cboSegundaFuente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboSegundaFuente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSegundaFuente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboSegundaFuente.EditorHeight = 15
        Me.cboSegundaFuente.EvenRowStyle = Style2
        Me.cboSegundaFuente.ExtendRightColumn = True
        Me.cboSegundaFuente.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboSegundaFuente.FooterStyle = Style3
        Me.cboSegundaFuente.GapHeight = 2
        Me.cboSegundaFuente.HeadingStyle = Style4
        Me.cboSegundaFuente.HighLightRowStyle = Style5
        Me.cboSegundaFuente.Images.Add(CType(resources.GetObject("cboSegundaFuente.Images"), System.Drawing.Image))
        Me.cboSegundaFuente.ItemHeight = 15
        Me.cboSegundaFuente.LimitToList = True
        Me.cboSegundaFuente.Location = New System.Drawing.Point(148, 174)
        Me.cboSegundaFuente.MatchEntryTimeout = CType(2000, Long)
        Me.cboSegundaFuente.MaxDropDownItems = CType(5, Short)
        Me.cboSegundaFuente.MaxLength = 32767
        Me.cboSegundaFuente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboSegundaFuente.Name = "cboSegundaFuente"
        Me.cboSegundaFuente.OddRowStyle = Style6
        Me.cboSegundaFuente.PartialRightColumn = False
        Me.cboSegundaFuente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboSegundaFuente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboSegundaFuente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboSegundaFuente.SelectedStyle = Style7
        Me.cboSegundaFuente.Size = New System.Drawing.Size(302, 21)
        Me.cboSegundaFuente.Style = Style8
        Me.cboSegundaFuente.SuperBack = True
        Me.cboSegundaFuente.TabIndex = 45
        Me.cboSegundaFuente.ValueMember = "nScnFuenteFinanciamientoID"
        Me.cboSegundaFuente.PropBag = resources.GetString("cboSegundaFuente.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 174)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Fuente Financiamiento:"
        '
        'frmSclSolicitudDesembolso
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(696, 304)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpGenerales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Ficha de Notificación de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclSolicitudDesembolso"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Datos de Solicitudes de Desembolso de Crédito:"
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cboFuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaDesembolso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFirmaE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboFirmaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboSegundaFuente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errSolicitudes As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents lblApellido1 As System.Windows.Forms.Label
    Friend WithEvents lblDireccion As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents lblFirma1 As System.Windows.Forms.Label
    Friend WithEvents lblFirma2 As System.Windows.Forms.Label
    Friend WithEvents cboFirmaE As C1.Win.C1List.C1Combo
    Friend WithEvents cboFirmaA As C1.Win.C1List.C1Combo
    Friend WithEvents cdeFechaDesembolso As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaSolicitud As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents cboFuente As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSegundaFuente As C1.Win.C1List.C1Combo
End Class
