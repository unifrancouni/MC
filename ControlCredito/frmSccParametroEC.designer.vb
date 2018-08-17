<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccParametroEC
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
        Me.components = New System.ComponentModel.Container()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccParametroEC))
        Me.grpdatosFormatos = New System.Windows.Forms.GroupBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.grpdestino = New System.Windows.Forms.GroupBox()
        Me.RadArchivo = New System.Windows.Forms.RadioButton()
        Me.RadImpresora = New System.Windows.Forms.RadioButton()
        Me.radPantalla = New System.Windows.Forms.RadioButton()
        Me.Exportar = New System.Windows.Forms.SaveFileDialog()
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpObservaciones = New System.Windows.Forms.GroupBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.grpEstadoSocia = New System.Windows.Forms.GroupBox()
        Me.cboEstado = New C1.Win.C1List.C1Combo()
        Me.cboOficial = New C1.Win.C1List.C1Combo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cdeFechaEstado = New C1.Win.C1Input.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservacionesEstado = New System.Windows.Forms.TextBox()
        Me.txtOtroMotivo = New System.Windows.Forms.TextBox()
        Me.rdOtro = New System.Windows.Forms.RadioButton()
        Me.rdActaDefuncion = New System.Windows.Forms.RadioButton()
        Me.rdCarta = New System.Windows.Forms.RadioButton()
        Me.rdFormatoVisita = New System.Windows.Forms.RadioButton()
        Me.lblEstadoSocia = New System.Windows.Forms.Label()
        Me.btnActualizaEstado = New System.Windows.Forms.Button()
        Me.txtAñadir = New System.Windows.Forms.TextBox()
        Me.btnAñadir = New System.Windows.Forms.Button()
        Me.grpdatosFormatos.SuspendLayout()
        Me.grpdestino.SuspendLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpObservaciones.SuspendLayout()
        Me.grpEstadoSocia.SuspendLayout()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOficial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpdatosFormatos
        '
        Me.grpdatosFormatos.Controls.Add(Me.txtEstado)
        Me.grpdatosFormatos.Controls.Add(Me.lblEstado)
        Me.grpdatosFormatos.Controls.Add(Me.txtCodigo)
        Me.grpdatosFormatos.Controls.Add(Me.lblCodigo)
        Me.grpdatosFormatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpdatosFormatos.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpdatosFormatos.Location = New System.Drawing.Point(10, 12)
        Me.grpdatosFormatos.Name = "grpdatosFormatos"
        Me.grpdatosFormatos.Size = New System.Drawing.Size(446, 84)
        Me.grpdatosFormatos.TabIndex = 1
        Me.grpdatosFormatos.TabStop = False
        Me.grpdatosFormatos.Text = "Datos Generales"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(125, 49)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.ShortcutsEnabled = False
        Me.txtEstado.Size = New System.Drawing.Size(216, 20)
        Me.txtEstado.TabIndex = 1
        Me.txtEstado.Tag = "LAYOUT:FLAT"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(12, 52)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(92, 13)
        Me.lblEstado.TabIndex = 37
        Me.lblEstado.Text = "Estado del Grupo:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(125, 23)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.ShortcutsEnabled = False
        Me.txtCodigo.Size = New System.Drawing.Size(216, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(10, 25)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(92, 13)
        Me.lblCodigo.TabIndex = 35
        Me.lblCodigo.Text = "Código del Grupo:"
        '
        'grpdestino
        '
        Me.grpdestino.Controls.Add(Me.RadArchivo)
        Me.grpdestino.Controls.Add(Me.RadImpresora)
        Me.grpdestino.Controls.Add(Me.radPantalla)
        Me.grpdestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpdestino.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpdestino.Location = New System.Drawing.Point(8, 472)
        Me.grpdestino.Name = "grpdestino"
        Me.grpdestino.Size = New System.Drawing.Size(444, 57)
        Me.grpdestino.TabIndex = 2
        Me.grpdestino.TabStop = False
        Me.grpdestino.Text = "Destino del Reporte"
        '
        'RadArchivo
        '
        Me.RadArchivo.AutoSize = True
        Me.RadArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadArchivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadArchivo.Location = New System.Drawing.Point(314, 22)
        Me.RadArchivo.Name = "RadArchivo"
        Me.RadArchivo.Size = New System.Drawing.Size(61, 17)
        Me.RadArchivo.TabIndex = 2
        Me.RadArchivo.Text = "Archivo"
        Me.RadArchivo.UseVisualStyleBackColor = True
        '
        'RadImpresora
        '
        Me.RadImpresora.AutoSize = True
        Me.RadImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadImpresora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadImpresora.Location = New System.Drawing.Point(193, 22)
        Me.RadImpresora.Name = "RadImpresora"
        Me.RadImpresora.Size = New System.Drawing.Size(71, 17)
        Me.RadImpresora.TabIndex = 1
        Me.RadImpresora.Text = "Impresora"
        Me.RadImpresora.UseVisualStyleBackColor = True
        '
        'radPantalla
        '
        Me.radPantalla.AutoSize = True
        Me.radPantalla.Checked = True
        Me.radPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPantalla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radPantalla.Location = New System.Drawing.Point(89, 22)
        Me.radPantalla.Name = "radPantalla"
        Me.radPantalla.Size = New System.Drawing.Size(63, 17)
        Me.radPantalla.TabIndex = 0
        Me.radPantalla.TabStop = True
        Me.radPantalla.Text = "Pantalla"
        Me.radPantalla.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'grpObservaciones
        '
        Me.grpObservaciones.Controls.Add(Me.btnAñadir)
        Me.grpObservaciones.Controls.Add(Me.txtAñadir)
        Me.grpObservaciones.Controls.Add(Me.txtObservaciones)
        Me.grpObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpObservaciones.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpObservaciones.Location = New System.Drawing.Point(12, 324)
        Me.grpObservaciones.Name = "grpObservaciones"
        Me.grpObservaciones.Size = New System.Drawing.Size(444, 142)
        Me.grpObservaciones.TabIndex = 11
        Me.grpObservaciones.TabStop = False
        Me.grpObservaciones.Text = "Observaciones (Añadir información): "
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(14, 77)
        Me.txtObservaciones.MaxLength = 1000
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ReadOnly = True
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(415, 59)
        Me.txtObservaciones.TabIndex = 0
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(383, 535)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 10
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(311, 535)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'grpEstadoSocia
        '
        Me.grpEstadoSocia.Controls.Add(Me.cboEstado)
        Me.grpEstadoSocia.Controls.Add(Me.cboOficial)
        Me.grpEstadoSocia.Controls.Add(Me.Label3)
        Me.grpEstadoSocia.Controls.Add(Me.cdeFechaEstado)
        Me.grpEstadoSocia.Controls.Add(Me.Label2)
        Me.grpEstadoSocia.Controls.Add(Me.RadioButton1)
        Me.grpEstadoSocia.Controls.Add(Me.Label1)
        Me.grpEstadoSocia.Controls.Add(Me.txtObservacionesEstado)
        Me.grpEstadoSocia.Controls.Add(Me.txtOtroMotivo)
        Me.grpEstadoSocia.Controls.Add(Me.rdOtro)
        Me.grpEstadoSocia.Controls.Add(Me.rdActaDefuncion)
        Me.grpEstadoSocia.Controls.Add(Me.rdCarta)
        Me.grpEstadoSocia.Controls.Add(Me.rdFormatoVisita)
        Me.grpEstadoSocia.Controls.Add(Me.lblEstadoSocia)
        Me.grpEstadoSocia.Controls.Add(Me.btnActualizaEstado)
        Me.grpEstadoSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpEstadoSocia.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpEstadoSocia.Location = New System.Drawing.Point(10, 99)
        Me.grpEstadoSocia.Name = "grpEstadoSocia"
        Me.grpEstadoSocia.Size = New System.Drawing.Size(446, 219)
        Me.grpEstadoSocia.TabIndex = 3
        Me.grpEstadoSocia.TabStop = False
        Me.grpEstadoSocia.Text = "Estado de la socia"
        '
        'cboEstado
        '
        Me.cboEstado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstado.AutoCompletion = True
        Me.cboEstado.Caption = ""
        Me.cboEstado.CaptionHeight = 17
        Me.cboEstado.CaptionStyle = Style17
        Me.cboEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEstado.ColumnCaptionHeight = 17
        Me.cboEstado.ColumnFooterHeight = 17
        Me.cboEstado.ContentHeight = 15
        Me.cboEstado.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboEstado.DisplayMember = "sNombreEmpleado"
        Me.cboEstado.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboEstado.DropDownWidth = 423
        Me.cboEstado.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboEstado.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEstado.EditorHeight = 15
        Me.cboEstado.EvenRowStyle = Style18
        Me.cboEstado.ExtendRightColumn = True
        Me.cboEstado.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEstado.FooterStyle = Style19
        Me.cboEstado.GapHeight = 2
        Me.cboEstado.HeadingStyle = Style20
        Me.cboEstado.HighLightRowStyle = Style21
        Me.cboEstado.Images.Add(CType(resources.GetObject("cboEstado.Images"), System.Drawing.Image))
        Me.cboEstado.ItemHeight = 15
        Me.cboEstado.LimitToList = True
        Me.cboEstado.Location = New System.Drawing.Point(89, 17)
        Me.cboEstado.MatchEntryTimeout = CType(2000, Long)
        Me.cboEstado.MaxDropDownItems = CType(5, Short)
        Me.cboEstado.MaxLength = 32767
        Me.cboEstado.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.OddRowStyle = Style22
        Me.cboEstado.PartialRightColumn = False
        Me.cboEstado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEstado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEstado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEstado.SelectedStyle = Style23
        Me.cboEstado.Size = New System.Drawing.Size(266, 21)
        Me.cboEstado.Style = Style24
        Me.cboEstado.SuperBack = True
        Me.cboEstado.TabIndex = 49
        Me.cboEstado.ValueMember = "nSrhEmpleadoID"
        Me.cboEstado.PropBag = resources.GetString("cboEstado.PropBag")
        '
        'cboOficial
        '
        Me.cboOficial.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboOficial.AutoCompletion = True
        Me.cboOficial.Caption = ""
        Me.cboOficial.CaptionHeight = 17
        Me.cboOficial.CaptionStyle = Style25
        Me.cboOficial.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboOficial.ColumnCaptionHeight = 17
        Me.cboOficial.ColumnFooterHeight = 17
        Me.cboOficial.ContentHeight = 15
        Me.cboOficial.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboOficial.DisplayMember = "sNombreEmpleado"
        Me.cboOficial.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboOficial.DropDownWidth = 423
        Me.cboOficial.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboOficial.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOficial.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboOficial.EditorHeight = 15
        Me.cboOficial.EvenRowStyle = Style26
        Me.cboOficial.ExtendRightColumn = True
        Me.cboOficial.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboOficial.FooterStyle = Style27
        Me.cboOficial.GapHeight = 2
        Me.cboOficial.HeadingStyle = Style28
        Me.cboOficial.HighLightRowStyle = Style29
        Me.cboOficial.Images.Add(CType(resources.GetObject("cboOficial.Images"), System.Drawing.Image))
        Me.cboOficial.ItemHeight = 15
        Me.cboOficial.LimitToList = True
        Me.cboOficial.Location = New System.Drawing.Point(55, 128)
        Me.cboOficial.MatchEntryTimeout = CType(2000, Long)
        Me.cboOficial.MaxDropDownItems = CType(5, Short)
        Me.cboOficial.MaxLength = 32767
        Me.cboOficial.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboOficial.Name = "cboOficial"
        Me.cboOficial.OddRowStyle = Style30
        Me.cboOficial.PartialRightColumn = False
        Me.cboOficial.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboOficial.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboOficial.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboOficial.SelectedStyle = Style31
        Me.cboOficial.Size = New System.Drawing.Size(376, 21)
        Me.cboOficial.Style = Style32
        Me.cboOficial.SuperBack = True
        Me.cboOficial.TabIndex = 48
        Me.cboOficial.ValueMember = "nSrhEmpleadoID"
        Me.cboOficial.PropBag = resources.GetString("cboOficial.PropBag")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Oficial:"
        '
        'cdeFechaEstado
        '
        Me.cdeFechaEstado.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaEstado.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaEstado.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaEstado.Location = New System.Drawing.Point(55, 96)
        Me.cdeFechaEstado.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaEstado.MaskInfo.EmptyAsNull = True
        Me.cdeFechaEstado.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaEstado.Name = "cdeFechaEstado"
        Me.cdeFechaEstado.Size = New System.Drawing.Size(183, 20)
        Me.cdeFechaEstado.TabIndex = 46
        Me.cdeFechaEstado.Tag = Nothing
        Me.cdeFechaEstado.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Fecha:"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadioButton1.Location = New System.Drawing.Point(274, 46)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(157, 17)
        Me.RadioButton1.TabIndex = 44
        Me.RadioButton1.Text = "Formato de Arreglo de Pago"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "Observaciones:"
        '
        'txtObservacionesEstado
        '
        Me.txtObservacionesEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservacionesEstado.Location = New System.Drawing.Point(6, 172)
        Me.txtObservacionesEstado.MaxLength = 400
        Me.txtObservacionesEstado.Multiline = True
        Me.txtObservacionesEstado.Name = "txtObservacionesEstado"
        Me.txtObservacionesEstado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservacionesEstado.Size = New System.Drawing.Size(424, 41)
        Me.txtObservacionesEstado.TabIndex = 1
        '
        'txtOtroMotivo
        '
        Me.txtOtroMotivo.BackColor = System.Drawing.SystemColors.Window
        Me.txtOtroMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOtroMotivo.Location = New System.Drawing.Point(259, 69)
        Me.txtOtroMotivo.Multiline = True
        Me.txtOtroMotivo.Name = "txtOtroMotivo"
        Me.txtOtroMotivo.ShortcutsEnabled = False
        Me.txtOtroMotivo.Size = New System.Drawing.Size(171, 47)
        Me.txtOtroMotivo.TabIndex = 38
        Me.txtOtroMotivo.Tag = "LAYOUT:FLAT"
        '
        'rdOtro
        '
        Me.rdOtro.AutoSize = True
        Me.rdOtro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdOtro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.rdOtro.Location = New System.Drawing.Point(156, 69)
        Me.rdOtro.Name = "rdOtro"
        Me.rdOtro.Size = New System.Drawing.Size(97, 17)
        Me.rdOtro.TabIndex = 42
        Me.rdOtro.Text = "Otro (Explique):"
        Me.rdOtro.UseVisualStyleBackColor = True
        '
        'rdActaDefuncion
        '
        Me.rdActaDefuncion.AutoSize = True
        Me.rdActaDefuncion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdActaDefuncion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.rdActaDefuncion.Location = New System.Drawing.Point(156, 46)
        Me.rdActaDefuncion.Name = "rdActaDefuncion"
        Me.rdActaDefuncion.Size = New System.Drawing.Size(112, 17)
        Me.rdActaDefuncion.TabIndex = 41
        Me.rdActaDefuncion.Text = "Acta de defunción"
        Me.rdActaDefuncion.UseVisualStyleBackColor = True
        '
        'rdCarta
        '
        Me.rdCarta.AutoSize = True
        Me.rdCarta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCarta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.rdCarta.Location = New System.Drawing.Point(15, 70)
        Me.rdCarta.Name = "rdCarta"
        Me.rdCarta.Size = New System.Drawing.Size(50, 17)
        Me.rdCarta.TabIndex = 40
        Me.rdCarta.Text = "Carta"
        Me.rdCarta.UseVisualStyleBackColor = True
        '
        'rdFormatoVisita
        '
        Me.rdFormatoVisita.AutoSize = True
        Me.rdFormatoVisita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdFormatoVisita.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.rdFormatoVisita.Location = New System.Drawing.Point(15, 47)
        Me.rdFormatoVisita.Name = "rdFormatoVisita"
        Me.rdFormatoVisita.Size = New System.Drawing.Size(135, 17)
        Me.rdFormatoVisita.TabIndex = 39
        Me.rdFormatoVisita.Text = "Formato de Visita CC91"
        Me.rdFormatoVisita.UseVisualStyleBackColor = True
        '
        'lblEstadoSocia
        '
        Me.lblEstadoSocia.AutoSize = True
        Me.lblEstadoSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstadoSocia.Location = New System.Drawing.Point(12, 21)
        Me.lblEstadoSocia.Name = "lblEstadoSocia"
        Me.lblEstadoSocia.Size = New System.Drawing.Size(72, 13)
        Me.lblEstadoSocia.TabIndex = 38
        Me.lblEstadoSocia.Text = "Elegir Estado:"
        '
        'btnActualizaEstado
        '
        Me.btnActualizaEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizaEstado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnActualizaEstado.Image = CType(resources.GetObject("btnActualizaEstado.Image"), System.Drawing.Image)
        Me.btnActualizaEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnActualizaEstado.Location = New System.Drawing.Point(362, 16)
        Me.btnActualizaEstado.Name = "btnActualizaEstado"
        Me.btnActualizaEstado.Size = New System.Drawing.Size(76, 24)
        Me.btnActualizaEstado.TabIndex = 12
        Me.btnActualizaEstado.Text = "Actualizar"
        Me.btnActualizaEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnActualizaEstado.UseVisualStyleBackColor = True
        '
        'txtAñadir
        '
        Me.txtAñadir.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAñadir.Location = New System.Drawing.Point(15, 19)
        Me.txtAñadir.MaxLength = 100
        Me.txtAñadir.Multiline = True
        Me.txtAñadir.Name = "txtAñadir"
        Me.txtAñadir.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAñadir.Size = New System.Drawing.Size(356, 52)
        Me.txtAñadir.TabIndex = 1
        '
        'btnAñadir
        '
        Me.btnAñadir.Image = Global.SMUSURA0.My.Resources.Resources.AgregarPartidaPresup
        Me.btnAñadir.Location = New System.Drawing.Point(386, 28)
        Me.btnAñadir.Name = "btnAñadir"
        Me.btnAñadir.Size = New System.Drawing.Size(32, 33)
        Me.btnAñadir.TabIndex = 10
        Me.btnAñadir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAñadir.UseVisualStyleBackColor = True
        '
        'frmSccParametroEC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 567)
        Me.Controls.Add(Me.grpEstadoSocia)
        Me.Controls.Add(Me.grpObservaciones)
        Me.Controls.Add(Me.grpdatosFormatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdestino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccParametroEC"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Parámetros Estado de Cuenta Resumen"
        Me.grpdatosFormatos.ResumeLayout(False)
        Me.grpdatosFormatos.PerformLayout()
        Me.grpdestino.ResumeLayout(False)
        Me.grpdestino.PerformLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpObservaciones.ResumeLayout(False)
        Me.grpObservaciones.PerformLayout()
        Me.grpEstadoSocia.ResumeLayout(False)
        Me.grpEstadoSocia.PerformLayout()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOficial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdatosFormatos As System.Windows.Forms.GroupBox
    Friend WithEvents grpdestino As System.Windows.Forms.GroupBox
    Friend WithEvents RadArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents radPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents grpEstadoSocia As GroupBox
    Friend WithEvents lblEstadoSocia As Label
    Friend WithEvents btnActualizaEstado As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtObservacionesEstado As TextBox
    Friend WithEvents txtOtroMotivo As TextBox
    Friend WithEvents rdOtro As RadioButton
    Friend WithEvents rdActaDefuncion As RadioButton
    Friend WithEvents rdCarta As RadioButton
    Friend WithEvents rdFormatoVisita As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents cdeFechaEstado As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cboOficial As C1.Win.C1List.C1Combo
    Friend WithEvents Label3 As Label
    Friend WithEvents cboEstado As C1.Win.C1List.C1Combo
    Friend WithEvents btnAñadir As Button
    Friend WithEvents txtAñadir As TextBox
End Class
