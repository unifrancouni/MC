<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditReciboEntregadoDpto
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
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style41 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style42 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style43 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style44 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style45 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style46 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style47 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style48 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditReciboEntregadoDpto))
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.cbAplicaMunicipioAlterno = New System.Windows.Forms.CheckBox()
        Me.cboTipoPlazoPagos = New C1.Win.C1List.C1Combo()
        Me.lblPeriodicidad = New System.Windows.Forms.Label()
        Me.cboTipoPrograma = New C1.Win.C1List.C1Combo()
        Me.lblTipoPrograma = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.txtNoReciboH = New System.Windows.Forms.TextBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.txtNoReciboD = New System.Windows.Forms.TextBox()
        Me.lblNoReciboD = New System.Windows.Forms.Label()
        Me.cdeFechaEntrega = New C1.Win.C1Input.C1DateEdit()
        Me.cboRecibidoPor = New C1.Win.C1List.C1Combo()
        Me.lblNoReciboH = New System.Windows.Forms.Label()
        Me.lblCajero = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cboTipoPlazoPagos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTipoPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboRecibidoPor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.cbAplicaMunicipioAlterno)
        Me.grpDatosGenerales.Controls.Add(Me.cboTipoPlazoPagos)
        Me.grpDatosGenerales.Controls.Add(Me.lblPeriodicidad)
        Me.grpDatosGenerales.Controls.Add(Me.cboTipoPrograma)
        Me.grpDatosGenerales.Controls.Add(Me.lblTipoPrograma)
        Me.grpDatosGenerales.Controls.Add(Me.txtDepartamento)
        Me.grpDatosGenerales.Controls.Add(Me.txtNoReciboH)
        Me.grpDatosGenerales.Controls.Add(Me.txtObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.lblObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.lblDepartamento)
        Me.grpDatosGenerales.Controls.Add(Me.txtNoReciboD)
        Me.grpDatosGenerales.Controls.Add(Me.lblNoReciboD)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaEntrega)
        Me.grpDatosGenerales.Controls.Add(Me.cboRecibidoPor)
        Me.grpDatosGenerales.Controls.Add(Me.lblNoReciboH)
        Me.grpDatosGenerales.Controls.Add(Me.lblCajero)
        Me.grpDatosGenerales.Controls.Add(Me.lblFecha)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(13, 12)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(485, 312)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos del Depósito:  "
        '
        'cbAplicaMunicipioAlterno
        '
        Me.cbAplicaMunicipioAlterno.AutoSize = True
        Me.cbAplicaMunicipioAlterno.Location = New System.Drawing.Point(284, 176)
        Me.cbAplicaMunicipioAlterno.Name = "cbAplicaMunicipioAlterno"
        Me.cbAplicaMunicipioAlterno.Size = New System.Drawing.Size(120, 17)
        Me.cbAplicaMunicipioAlterno.TabIndex = 127
        Me.cbAplicaMunicipioAlterno.Text = "Entrega a Bluefields"
        Me.cbAplicaMunicipioAlterno.UseVisualStyleBackColor = True
        Me.cbAplicaMunicipioAlterno.Visible = False
        '
        'cboTipoPlazoPagos
        '
        Me.cboTipoPlazoPagos.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoPlazoPagos.AutoCompletion = True
        Me.cboTipoPlazoPagos.Caption = ""
        Me.cboTipoPlazoPagos.CaptionHeight = 17
        Me.cboTipoPlazoPagos.CaptionStyle = Style25
        Me.cboTipoPlazoPagos.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTipoPlazoPagos.ColumnCaptionHeight = 17
        Me.cboTipoPlazoPagos.ColumnFooterHeight = 17
        Me.cboTipoPlazoPagos.ContentHeight = 15
        Me.cboTipoPlazoPagos.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTipoPlazoPagos.DisplayMember = "sDescripcion"
        Me.cboTipoPlazoPagos.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTipoPlazoPagos.DropDownWidth = 145
        Me.cboTipoPlazoPagos.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTipoPlazoPagos.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoPlazoPagos.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoPlazoPagos.EditorHeight = 15
        Me.cboTipoPlazoPagos.EvenRowStyle = Style26
        Me.cboTipoPlazoPagos.ExtendRightColumn = True
        Me.cboTipoPlazoPagos.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoPlazoPagos.FooterStyle = Style27
        Me.cboTipoPlazoPagos.GapHeight = 2
        Me.cboTipoPlazoPagos.HeadingStyle = Style28
        Me.cboTipoPlazoPagos.HighLightRowStyle = Style29
        Me.cboTipoPlazoPagos.Images.Add(CType(resources.GetObject("cboTipoPlazoPagos.Images"), System.Drawing.Image))
        Me.cboTipoPlazoPagos.ItemHeight = 15
        Me.cboTipoPlazoPagos.LimitToList = True
        Me.cboTipoPlazoPagos.Location = New System.Drawing.Point(126, 109)
        Me.cboTipoPlazoPagos.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoPlazoPagos.MaxDropDownItems = CType(5, Short)
        Me.cboTipoPlazoPagos.MaxLength = 32767
        Me.cboTipoPlazoPagos.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoPlazoPagos.Name = "cboTipoPlazoPagos"
        Me.cboTipoPlazoPagos.OddRowStyle = Style30
        Me.cboTipoPlazoPagos.PartialRightColumn = False
        Me.cboTipoPlazoPagos.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoPlazoPagos.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoPlazoPagos.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoPlazoPagos.SelectedStyle = Style31
        Me.cboTipoPlazoPagos.Size = New System.Drawing.Size(126, 21)
        Me.cboTipoPlazoPagos.Style = Style32
        Me.cboTipoPlazoPagos.SuperBack = True
        Me.cboTipoPlazoPagos.TabIndex = 3
        Me.cboTipoPlazoPagos.ValueMember = "StbValorCatalogoID"
        Me.cboTipoPlazoPagos.PropBag = resources.GetString("cboTipoPlazoPagos.PropBag")
        '
        'lblPeriodicidad
        '
        Me.lblPeriodicidad.AutoSize = True
        Me.lblPeriodicidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPeriodicidad.Location = New System.Drawing.Point(22, 109)
        Me.lblPeriodicidad.Name = "lblPeriodicidad"
        Me.lblPeriodicidad.Size = New System.Drawing.Size(101, 13)
        Me.lblPeriodicidad.TabIndex = 126
        Me.lblPeriodicidad.Text = "Periodicidad Pagos:"
        '
        'cboTipoPrograma
        '
        Me.cboTipoPrograma.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTipoPrograma.AutoCompletion = True
        Me.cboTipoPrograma.Caption = ""
        Me.cboTipoPrograma.CaptionHeight = 17
        Me.cboTipoPrograma.CaptionStyle = Style33
        Me.cboTipoPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTipoPrograma.ColumnCaptionHeight = 17
        Me.cboTipoPrograma.ColumnFooterHeight = 17
        Me.cboTipoPrograma.ContentHeight = 15
        Me.cboTipoPrograma.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTipoPrograma.DisplayMember = "sDescripcion"
        Me.cboTipoPrograma.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTipoPrograma.DropDownWidth = 348
        Me.cboTipoPrograma.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTipoPrograma.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipoPrograma.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTipoPrograma.EditorHeight = 15
        Me.cboTipoPrograma.EvenRowStyle = Style34
        Me.cboTipoPrograma.ExtendRightColumn = True
        Me.cboTipoPrograma.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTipoPrograma.FooterStyle = Style35
        Me.cboTipoPrograma.GapHeight = 2
        Me.cboTipoPrograma.HeadingStyle = Style36
        Me.cboTipoPrograma.HighLightRowStyle = Style37
        Me.cboTipoPrograma.Images.Add(CType(resources.GetObject("cboTipoPrograma.Images"), System.Drawing.Image))
        Me.cboTipoPrograma.ItemHeight = 15
        Me.cboTipoPrograma.LimitToList = True
        Me.cboTipoPrograma.Location = New System.Drawing.Point(126, 82)
        Me.cboTipoPrograma.MatchEntryTimeout = CType(2000, Long)
        Me.cboTipoPrograma.MaxDropDownItems = CType(5, Short)
        Me.cboTipoPrograma.MaxLength = 32767
        Me.cboTipoPrograma.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTipoPrograma.Name = "cboTipoPrograma"
        Me.cboTipoPrograma.OddRowStyle = Style38
        Me.cboTipoPrograma.PartialRightColumn = False
        Me.cboTipoPrograma.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTipoPrograma.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTipoPrograma.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTipoPrograma.SelectedStyle = Style39
        Me.cboTipoPrograma.Size = New System.Drawing.Size(341, 21)
        Me.cboTipoPrograma.Style = Style40
        Me.cboTipoPrograma.SuperBack = True
        Me.cboTipoPrograma.TabIndex = 2
        Me.cboTipoPrograma.ValueMember = "nStbValorCatalogoID"
        Me.cboTipoPrograma.PropBag = resources.GetString("cboTipoPrograma.PropBag")
        '
        'lblTipoPrograma
        '
        Me.lblTipoPrograma.AutoSize = True
        Me.lblTipoPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoPrograma.Location = New System.Drawing.Point(22, 82)
        Me.lblTipoPrograma.Name = "lblTipoPrograma"
        Me.lblTipoPrograma.Size = New System.Drawing.Size(94, 13)
        Me.lblTipoPrograma.TabIndex = 118
        Me.lblTipoPrograma.Text = "Tipo de Programa:"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.BackColor = System.Drawing.SystemColors.Info
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartamento.Location = New System.Drawing.Point(126, 53)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(341, 20)
        Me.txtDepartamento.TabIndex = 1
        Me.txtDepartamento.Tag = "LAYOUT:FLAT"
        '
        'txtNoReciboH
        '
        Me.txtNoReciboH.Location = New System.Drawing.Point(126, 204)
        Me.txtNoReciboH.Name = "txtNoReciboH"
        Me.txtNoReciboH.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNoReciboH.Size = New System.Drawing.Size(127, 20)
        Me.txtNoReciboH.TabIndex = 6
        Me.txtNoReciboH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(126, 230)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(341, 65)
        Me.txtObservaciones.TabIndex = 7
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(22, 233)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 116
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(22, 56)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 115
        Me.lblDepartamento.Text = "Departamento:"
        '
        'txtNoReciboD
        '
        Me.txtNoReciboD.Location = New System.Drawing.Point(126, 173)
        Me.txtNoReciboD.Name = "txtNoReciboD"
        Me.txtNoReciboD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNoReciboD.Size = New System.Drawing.Size(127, 20)
        Me.txtNoReciboD.TabIndex = 5
        Me.txtNoReciboD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNoReciboD
        '
        Me.lblNoReciboD.AutoSize = True
        Me.lblNoReciboD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNoReciboD.Location = New System.Drawing.Point(22, 173)
        Me.lblNoReciboD.Name = "lblNoReciboD"
        Me.lblNoReciboD.Size = New System.Drawing.Size(98, 13)
        Me.lblNoReciboD.TabIndex = 114
        Me.lblNoReciboD.Text = "No. Recibo Desde:"
        '
        'cdeFechaEntrega
        '
        Me.cdeFechaEntrega.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaEntrega.Location = New System.Drawing.Point(126, 141)
        Me.cdeFechaEntrega.Name = "cdeFechaEntrega"
        Me.cdeFechaEntrega.Size = New System.Drawing.Size(127, 20)
        Me.cdeFechaEntrega.TabIndex = 4
        Me.cdeFechaEntrega.Tag = Nothing
        Me.cdeFechaEntrega.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cboRecibidoPor
        '
        Me.cboRecibidoPor.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboRecibidoPor.AutoCompletion = True
        Me.cboRecibidoPor.Caption = ""
        Me.cboRecibidoPor.CaptionHeight = 17
        Me.cboRecibidoPor.CaptionStyle = Style41
        Me.cboRecibidoPor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboRecibidoPor.ColumnCaptionHeight = 17
        Me.cboRecibidoPor.ColumnFooterHeight = 17
        Me.cboRecibidoPor.ContentHeight = 15
        Me.cboRecibidoPor.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboRecibidoPor.DisplayMember = "sNombreEmpleado"
        Me.cboRecibidoPor.DropDownWidth = 342
        Me.cboRecibidoPor.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboRecibidoPor.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRecibidoPor.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboRecibidoPor.EditorHeight = 15
        Me.cboRecibidoPor.EvenRowStyle = Style42
        Me.cboRecibidoPor.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboRecibidoPor.FooterStyle = Style43
        Me.cboRecibidoPor.GapHeight = 2
        Me.cboRecibidoPor.HeadingStyle = Style44
        Me.cboRecibidoPor.HighLightRowStyle = Style45
        Me.cboRecibidoPor.Images.Add(CType(resources.GetObject("cboRecibidoPor.Images"), System.Drawing.Image))
        Me.cboRecibidoPor.ItemHeight = 15
        Me.cboRecibidoPor.LimitToList = True
        Me.cboRecibidoPor.Location = New System.Drawing.Point(126, 19)
        Me.cboRecibidoPor.MatchEntryTimeout = CType(2000, Long)
        Me.cboRecibidoPor.MaxDropDownItems = CType(5, Short)
        Me.cboRecibidoPor.MaxLength = 32767
        Me.cboRecibidoPor.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboRecibidoPor.Name = "cboRecibidoPor"
        Me.cboRecibidoPor.OddRowStyle = Style46
        Me.cboRecibidoPor.PartialRightColumn = False
        Me.cboRecibidoPor.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboRecibidoPor.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboRecibidoPor.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboRecibidoPor.SelectedStyle = Style47
        Me.cboRecibidoPor.Size = New System.Drawing.Size(341, 21)
        Me.cboRecibidoPor.Style = Style48
        Me.cboRecibidoPor.SuperBack = True
        Me.cboRecibidoPor.TabIndex = 0
        Me.cboRecibidoPor.ValueMember = "nSrhEmpleadoID"
        Me.cboRecibidoPor.PropBag = resources.GetString("cboRecibidoPor.PropBag")
        '
        'lblNoReciboH
        '
        Me.lblNoReciboH.AutoSize = True
        Me.lblNoReciboH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNoReciboH.Location = New System.Drawing.Point(22, 207)
        Me.lblNoReciboH.Name = "lblNoReciboH"
        Me.lblNoReciboH.Size = New System.Drawing.Size(95, 13)
        Me.lblNoReciboH.TabIndex = 6
        Me.lblNoReciboH.Text = "No. Recibo Hasta:"
        '
        'lblCajero
        '
        Me.lblCajero.AutoSize = True
        Me.lblCajero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCajero.Location = New System.Drawing.Point(22, 21)
        Me.lblCajero.Name = "lblCajero"
        Me.lblCajero.Size = New System.Drawing.Size(71, 13)
        Me.lblCajero.TabIndex = 3
        Me.lblCajero.Text = "Recibido Por:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(22, 141)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(80, 13)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "Fecha Entrega:"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(346, 330)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(423, 330)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSteEditReciboEntregadoDpto
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(508, 367)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Entrega de Talonarios (Delegaciones)")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditReciboEntregadoDpto"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Entrega de Talonarios a Delegaciones"
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cboTipoPlazoPagos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTipoPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboRecibidoPor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaEntrega As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cboRecibidoPor As C1.Win.C1List.C1Combo
    Friend WithEvents lblNoReciboH As System.Windows.Forms.Label
    Friend WithEvents lblCajero As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtNoReciboD As System.Windows.Forms.TextBox
    Friend WithEvents lblNoReciboD As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtNoReciboH As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents cboTipoPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblTipoPrograma As System.Windows.Forms.Label
    Friend WithEvents cboTipoPlazoPagos As C1.Win.C1List.C1Combo
    Friend WithEvents lblPeriodicidad As System.Windows.Forms.Label
    Friend WithEvents cbAplicaMunicipioAlterno As System.Windows.Forms.CheckBox
End Class
