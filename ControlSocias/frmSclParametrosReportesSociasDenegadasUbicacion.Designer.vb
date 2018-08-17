<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclParametrosReportesSociasDenegadasUbicacion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclParametrosReportesSociasDenegadasUbicacion))
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpdatos = New System.Windows.Forms.GroupBox()
        Me.grpFondooFuente = New System.Windows.Forms.GroupBox()
        Me.CboFuentes = New C1.Win.C1List.C1Combo()
        Me.radFuentes = New System.Windows.Forms.RadioButton()
        Me.radFondos = New System.Windows.Forms.RadioButton()
        Me.grpFuente = New System.Windows.Forms.GroupBox()
        Me.RdSinFuente = New System.Windows.Forms.RadioButton()
        Me.RdExterno = New System.Windows.Forms.RadioButton()
        Me.RdPresupuesto = New System.Windows.Forms.RadioButton()
        Me.RdTodos = New System.Windows.Forms.RadioButton()
        Me.grpNivelDetalle = New System.Windows.Forms.GroupBox()
        Me.rdMotivos = New System.Windows.Forms.RadioButton()
        Me.rdoDept = New System.Windows.Forms.RadioButton()
        Me.rdoMuni = New System.Windows.Forms.RadioButton()
        Me.grpRangoFechas = New System.Windows.Forms.GroupBox()
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit()
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit()
        Me.LblHasta = New System.Windows.Forms.Label()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.cboMunicipio = New C1.Win.C1List.C1Combo()
        Me.CboDepartamento = New C1.Win.C1List.C1Combo()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.grpPrograma = New System.Windows.Forms.GroupBox()
        Me.RdPDIBA = New System.Windows.Forms.RadioButton()
        Me.RdVentanadeGenero = New System.Windows.Forms.RadioButton()
        Me.RdUsuraCero = New System.Windows.Forms.RadioButton()
        Me.grpdatos.SuspendLayout()
        Me.grpFondooFuente.SuspendLayout()
        CType(Me.CboFuentes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFuente.SuspendLayout()
        Me.grpNivelDetalle.SuspendLayout()
        Me.grpRangoFechas.SuspendLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPrograma.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.grpPrograma)
        Me.grpdatos.Controls.Add(Me.grpFondooFuente)
        Me.grpdatos.Controls.Add(Me.grpFuente)
        Me.grpdatos.Controls.Add(Me.grpNivelDetalle)
        Me.grpdatos.Controls.Add(Me.grpRangoFechas)
        Me.grpdatos.Controls.Add(Me.cboMunicipio)
        Me.grpdatos.Controls.Add(Me.CboDepartamento)
        Me.grpdatos.Controls.Add(Me.lblMunicipio)
        Me.grpdatos.Controls.Add(Me.lblDepartamento)
        Me.grpdatos.Location = New System.Drawing.Point(2, 3)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(446, 348)
        Me.grpdatos.TabIndex = 13
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'grpFondooFuente
        '
        Me.grpFondooFuente.Controls.Add(Me.CboFuentes)
        Me.grpFondooFuente.Controls.Add(Me.radFuentes)
        Me.grpFondooFuente.Controls.Add(Me.radFondos)
        Me.grpFondooFuente.Location = New System.Drawing.Point(16, 209)
        Me.grpFondooFuente.Name = "grpFondooFuente"
        Me.grpFondooFuente.Size = New System.Drawing.Size(418, 37)
        Me.grpFondooFuente.TabIndex = 68
        Me.grpFondooFuente.TabStop = False
        '
        'CboFuentes
        '
        Me.CboFuentes.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboFuentes.Caption = ""
        Me.CboFuentes.CaptionHeight = 17
        Me.CboFuentes.CaptionStyle = Style1
        Me.CboFuentes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboFuentes.ColumnCaptionHeight = 17
        Me.CboFuentes.ColumnFooterHeight = 17
        Me.CboFuentes.ContentHeight = 15
        Me.CboFuentes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboFuentes.DisplayMember = "sNombre"
        Me.CboFuentes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboFuentes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboFuentes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboFuentes.EditorHeight = 15
        Me.CboFuentes.EvenRowStyle = Style2
        Me.CboFuentes.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboFuentes.FooterStyle = Style3
        Me.CboFuentes.GapHeight = 2
        Me.CboFuentes.HeadingStyle = Style4
        Me.CboFuentes.HighLightRowStyle = Style5
        Me.CboFuentes.Images.Add(CType(resources.GetObject("CboFuentes.Images"), System.Drawing.Image))
        Me.CboFuentes.ItemHeight = 15
        Me.CboFuentes.Location = New System.Drawing.Point(165, 10)
        Me.CboFuentes.MatchEntryTimeout = CType(2000, Long)
        Me.CboFuentes.MaxDropDownItems = CType(5, Short)
        Me.CboFuentes.MaxLength = 32767
        Me.CboFuentes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboFuentes.Name = "CboFuentes"
        Me.CboFuentes.OddRowStyle = Style6
        Me.CboFuentes.PartialRightColumn = False
        Me.CboFuentes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboFuentes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboFuentes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboFuentes.SelectedStyle = Style7
        Me.CboFuentes.Size = New System.Drawing.Size(234, 21)
        Me.CboFuentes.Style = Style8
        Me.CboFuentes.TabIndex = 3
        Me.CboFuentes.Text = "C1Combo1"
        Me.CboFuentes.PropBag = resources.GetString("CboFuentes.PropBag")
        '
        'radFuentes
        '
        Me.radFuentes.AutoSize = True
        Me.radFuentes.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radFuentes.Location = New System.Drawing.Point(97, 14)
        Me.radFuentes.Name = "radFuentes"
        Me.radFuentes.Size = New System.Drawing.Size(63, 17)
        Me.radFuentes.TabIndex = 2
        Me.radFuentes.Text = "Fuentes"
        Me.radFuentes.UseVisualStyleBackColor = True
        '
        'radFondos
        '
        Me.radFondos.AutoSize = True
        Me.radFondos.Checked = True
        Me.radFondos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radFondos.Location = New System.Drawing.Point(14, 14)
        Me.radFondos.Name = "radFondos"
        Me.radFondos.Size = New System.Drawing.Size(60, 17)
        Me.radFondos.TabIndex = 1
        Me.radFondos.TabStop = True
        Me.radFondos.Text = "Fondos"
        Me.radFondos.UseVisualStyleBackColor = True
        '
        'grpFuente
        '
        Me.grpFuente.Controls.Add(Me.RdSinFuente)
        Me.grpFuente.Controls.Add(Me.RdExterno)
        Me.grpFuente.Controls.Add(Me.RdPresupuesto)
        Me.grpFuente.Controls.Add(Me.RdTodos)
        Me.grpFuente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpFuente.Location = New System.Drawing.Point(16, 252)
        Me.grpFuente.Name = "grpFuente"
        Me.grpFuente.Size = New System.Drawing.Size(418, 40)
        Me.grpFuente.TabIndex = 67
        Me.grpFuente.TabStop = False
        Me.grpFuente.Text = "Fondos"
        '
        'RdSinFuente
        '
        Me.RdSinFuente.AutoSize = True
        Me.RdSinFuente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdSinFuente.Location = New System.Drawing.Point(274, 15)
        Me.RdSinFuente.Name = "RdSinFuente"
        Me.RdSinFuente.Size = New System.Drawing.Size(123, 17)
        Me.RdSinFuente.TabIndex = 3
        Me.RdSinFuente.Text = "Sin Fuente Asignada"
        Me.RdSinFuente.UseVisualStyleBackColor = True
        '
        'RdExterno
        '
        Me.RdExterno.AutoSize = True
        Me.RdExterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdExterno.Location = New System.Drawing.Point(191, 15)
        Me.RdExterno.Name = "RdExterno"
        Me.RdExterno.Size = New System.Drawing.Size(66, 17)
        Me.RdExterno.TabIndex = 2
        Me.RdExterno.Text = "Externos"
        Me.RdExterno.UseVisualStyleBackColor = True
        '
        'RdPresupuesto
        '
        Me.RdPresupuesto.AutoSize = True
        Me.RdPresupuesto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdPresupuesto.Location = New System.Drawing.Point(97, 15)
        Me.RdPresupuesto.Name = "RdPresupuesto"
        Me.RdPresupuesto.Size = New System.Drawing.Size(84, 17)
        Me.RdPresupuesto.TabIndex = 1
        Me.RdPresupuesto.Text = "Presupuesto"
        Me.RdPresupuesto.UseVisualStyleBackColor = True
        '
        'RdTodos
        '
        Me.RdTodos.AutoSize = True
        Me.RdTodos.Checked = True
        Me.RdTodos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdTodos.Location = New System.Drawing.Point(14, 15)
        Me.RdTodos.Name = "RdTodos"
        Me.RdTodos.Size = New System.Drawing.Size(55, 17)
        Me.RdTodos.TabIndex = 0
        Me.RdTodos.TabStop = True
        Me.RdTodos.Text = "Todos"
        Me.RdTodos.UseVisualStyleBackColor = True
        '
        'grpNivelDetalle
        '
        Me.grpNivelDetalle.Controls.Add(Me.rdMotivos)
        Me.grpNivelDetalle.Controls.Add(Me.rdoDept)
        Me.grpNivelDetalle.Controls.Add(Me.rdoMuni)
        Me.grpNivelDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpNivelDetalle.Location = New System.Drawing.Point(16, 90)
        Me.grpNivelDetalle.Name = "grpNivelDetalle"
        Me.grpNivelDetalle.Size = New System.Drawing.Size(418, 45)
        Me.grpNivelDetalle.TabIndex = 65
        Me.grpNivelDetalle.TabStop = False
        Me.grpNivelDetalle.Text = "Nivel de detalle (TOTALES)"
        '
        'rdMotivos
        '
        Me.rdMotivos.AutoSize = True
        Me.rdMotivos.Checked = True
        Me.rdMotivos.Location = New System.Drawing.Point(14, 19)
        Me.rdMotivos.Name = "rdMotivos"
        Me.rdMotivos.Size = New System.Drawing.Size(117, 17)
        Me.rdMotivos.TabIndex = 11
        Me.rdMotivos.TabStop = True
        Me.rdMotivos.Text = "Motivos en General"
        Me.rdMotivos.UseVisualStyleBackColor = True
        '
        'rdoDept
        '
        Me.rdoDept.AutoSize = True
        Me.rdoDept.Location = New System.Drawing.Point(165, 19)
        Me.rdoDept.Name = "rdoDept"
        Me.rdoDept.Size = New System.Drawing.Size(97, 17)
        Me.rdoDept.TabIndex = 9
        Me.rdoDept.Text = "Departamentos"
        Me.rdoDept.UseVisualStyleBackColor = True
        '
        'rdoMuni
        '
        Me.rdoMuni.AutoSize = True
        Me.rdoMuni.Location = New System.Drawing.Point(294, 19)
        Me.rdoMuni.Name = "rdoMuni"
        Me.rdoMuni.Size = New System.Drawing.Size(75, 17)
        Me.rdoMuni.TabIndex = 10
        Me.rdoMuni.Text = "Municipios"
        Me.rdoMuni.UseVisualStyleBackColor = True
        '
        'grpRangoFechas
        '
        Me.grpRangoFechas.Controls.Add(Me.CdeFechaFinal)
        Me.grpRangoFechas.Controls.Add(Me.cdeFechaInicial)
        Me.grpRangoFechas.Controls.Add(Me.LblHasta)
        Me.grpRangoFechas.Controls.Add(Me.LblDesde)
        Me.grpRangoFechas.Location = New System.Drawing.Point(16, 141)
        Me.grpRangoFechas.Name = "grpRangoFechas"
        Me.grpRangoFechas.Size = New System.Drawing.Size(418, 62)
        Me.grpRangoFechas.TabIndex = 60
        Me.grpRangoFechas.TabStop = False
        Me.grpRangoFechas.Text = "Período"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(260, 28)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(137, 20)
        Me.CdeFechaFinal.TabIndex = 6
        Me.CdeFechaFinal.Tag = Nothing
        Me.CdeFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(68, 28)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(123, 20)
        Me.cdeFechaInicial.TabIndex = 5
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'LblHasta
        '
        Me.LblHasta.AutoSize = True
        Me.LblHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblHasta.Location = New System.Drawing.Point(219, 31)
        Me.LblHasta.Name = "LblHasta"
        Me.LblHasta.Size = New System.Drawing.Size(38, 13)
        Me.LblHasta.TabIndex = 63
        Me.LblHasta.Text = "Hasta:"
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblDesde.Location = New System.Drawing.Point(13, 31)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(41, 13)
        Me.LblDesde.TabIndex = 62
        Me.LblDesde.Text = "Desde:"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMunicipio.AllowSort = False
        Me.cboMunicipio.AutoCompletion = True
        Me.cboMunicipio.Caption = ""
        Me.cboMunicipio.CaptionHeight = 17
        Me.cboMunicipio.CaptionStyle = Style9
        Me.cboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMunicipio.ColumnCaptionHeight = 17
        Me.cboMunicipio.ColumnFooterHeight = 17
        Me.cboMunicipio.ContentHeight = 15
        Me.cboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMunicipio.DisplayMember = "Descripcion"
        Me.cboMunicipio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMunicipio.DropDownWidth = 250
        Me.cboMunicipio.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMunicipio.EditorHeight = 15
        Me.cboMunicipio.EvenRowStyle = Style10
        Me.cboMunicipio.ExtendRightColumn = True
        Me.cboMunicipio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMunicipio.FooterStyle = Style11
        Me.cboMunicipio.GapHeight = 2
        Me.cboMunicipio.HeadingStyle = Style12
        Me.cboMunicipio.HighLightRowStyle = Style13
        Me.cboMunicipio.Images.Add(CType(resources.GetObject("cboMunicipio.Images"), System.Drawing.Image))
        Me.cboMunicipio.ItemHeight = 15
        Me.cboMunicipio.Location = New System.Drawing.Point(111, 63)
        Me.cboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.cboMunicipio.MaxLength = 32767
        Me.cboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.OddRowStyle = Style14
        Me.cboMunicipio.PartialRightColumn = False
        Me.cboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMunicipio.SelectedStyle = Style15
        Me.cboMunicipio.Size = New System.Drawing.Size(242, 21)
        Me.cboMunicipio.Style = Style16
        Me.cboMunicipio.TabIndex = 2
        Me.cboMunicipio.PropBag = resources.GetString("cboMunicipio.PropBag")
        '
        'CboDepartamento
        '
        Me.CboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDepartamento.AllowSort = False
        Me.CboDepartamento.AutoCompletion = True
        Me.CboDepartamento.Caption = ""
        Me.CboDepartamento.CaptionHeight = 17
        Me.CboDepartamento.CaptionStyle = Style17
        Me.CboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDepartamento.ColumnCaptionHeight = 17
        Me.CboDepartamento.ColumnFooterHeight = 17
        Me.CboDepartamento.ContentHeight = 15
        Me.CboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDepartamento.DisplayMember = "Descripcion"
        Me.CboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboDepartamento.DropDownWidth = 250
        Me.CboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDepartamento.EditorHeight = 15
        Me.CboDepartamento.EvenRowStyle = Style18
        Me.CboDepartamento.ExtendRightColumn = True
        Me.CboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboDepartamento.FooterStyle = Style19
        Me.CboDepartamento.GapHeight = 2
        Me.CboDepartamento.HeadingStyle = Style20
        Me.CboDepartamento.HighLightRowStyle = Style21
        Me.CboDepartamento.Images.Add(CType(resources.GetObject("CboDepartamento.Images"), System.Drawing.Image))
        Me.CboDepartamento.ItemHeight = 15
        Me.CboDepartamento.Location = New System.Drawing.Point(111, 30)
        Me.CboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.CboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.CboDepartamento.MaxLength = 32767
        Me.CboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDepartamento.Name = "CboDepartamento"
        Me.CboDepartamento.OddRowStyle = Style22
        Me.CboDepartamento.PartialRightColumn = False
        Me.CboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDepartamento.SelectedStyle = Style23
        Me.CboDepartamento.Size = New System.Drawing.Size(242, 21)
        Me.CboDepartamento.Style = Style24
        Me.CboDepartamento.TabIndex = 1
        Me.CboDepartamento.PropBag = resources.GetString("CboDepartamento.PropBag")
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(16, 63)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(55, 13)
        Me.lblMunicipio.TabIndex = 34
        Me.lblMunicipio.Text = "Municipio:"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(16, 30)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 7
        Me.lblDepartamento.Text = "Departamento:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(302, 357)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 13
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(377, 357)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 14
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpPrograma
        '
        Me.grpPrograma.Controls.Add(Me.RdPDIBA)
        Me.grpPrograma.Controls.Add(Me.RdVentanadeGenero)
        Me.grpPrograma.Controls.Add(Me.RdUsuraCero)
        Me.grpPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpPrograma.Location = New System.Drawing.Point(16, 298)
        Me.grpPrograma.Name = "grpPrograma"
        Me.grpPrograma.Size = New System.Drawing.Size(418, 42)
        Me.grpPrograma.TabIndex = 78
        Me.grpPrograma.TabStop = False
        Me.grpPrograma.Text = "Programa"
        '
        'RdPDIBA
        '
        Me.RdPDIBA.AutoSize = True
        Me.RdPDIBA.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdPDIBA.Location = New System.Drawing.Point(221, 19)
        Me.RdPDIBA.Name = "RdPDIBA"
        Me.RdPDIBA.Size = New System.Drawing.Size(57, 17)
        Me.RdPDIBA.TabIndex = 5
        Me.RdPDIBA.Text = "PDIBA"
        Me.RdPDIBA.UseVisualStyleBackColor = True
        '
        'RdVentanadeGenero
        '
        Me.RdVentanadeGenero.AutoSize = True
        Me.RdVentanadeGenero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdVentanadeGenero.Location = New System.Drawing.Point(97, 19)
        Me.RdVentanadeGenero.Name = "RdVentanadeGenero"
        Me.RdVentanadeGenero.Size = New System.Drawing.Size(118, 17)
        Me.RdVentanadeGenero.TabIndex = 2
        Me.RdVentanadeGenero.Text = "Ventana de Genero"
        Me.RdVentanadeGenero.UseVisualStyleBackColor = True
        '
        'RdUsuraCero
        '
        Me.RdUsuraCero.AutoSize = True
        Me.RdUsuraCero.Checked = True
        Me.RdUsuraCero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdUsuraCero.Location = New System.Drawing.Point(9, 19)
        Me.RdUsuraCero.Name = "RdUsuraCero"
        Me.RdUsuraCero.Size = New System.Drawing.Size(78, 17)
        Me.RdUsuraCero.TabIndex = 1
        Me.RdUsuraCero.TabStop = True
        Me.RdUsuraCero.Text = "Usura Cero"
        Me.RdUsuraCero.UseVisualStyleBackColor = True
        '
        'frmSclParametrosReportesSociasDenegadasUbicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(448, 386)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpdatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclParametrosReportesSociasDenegadasUbicacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros Socia Ubicación"
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        Me.grpFondooFuente.ResumeLayout(False)
        Me.grpFondooFuente.PerformLayout()
        CType(Me.CboFuentes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFuente.ResumeLayout(False)
        Me.grpFuente.PerformLayout()
        Me.grpNivelDetalle.ResumeLayout(False)
        Me.grpNivelDetalle.PerformLayout()
        Me.grpRangoFechas.ResumeLayout(False)
        Me.grpRangoFechas.PerformLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPrograma.ResumeLayout(False)
        Me.grpPrograma.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents cboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents CboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents grpRangoFechas As System.Windows.Forms.GroupBox
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents LblHasta As System.Windows.Forms.Label
    Friend WithEvents LblDesde As System.Windows.Forms.Label
    Friend WithEvents grpNivelDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMuni As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDept As System.Windows.Forms.RadioButton
    Friend WithEvents grpFondooFuente As System.Windows.Forms.GroupBox
    Friend WithEvents CboFuentes As C1.Win.C1List.C1Combo
    Friend WithEvents radFuentes As System.Windows.Forms.RadioButton
    Friend WithEvents radFondos As System.Windows.Forms.RadioButton
    Friend WithEvents grpFuente As System.Windows.Forms.GroupBox
    Friend WithEvents RdSinFuente As System.Windows.Forms.RadioButton
    Friend WithEvents RdExterno As System.Windows.Forms.RadioButton
    Friend WithEvents RdPresupuesto As System.Windows.Forms.RadioButton
    Friend WithEvents RdTodos As System.Windows.Forms.RadioButton
    Friend WithEvents rdMotivos As System.Windows.Forms.RadioButton
    Friend WithEvents grpPrograma As System.Windows.Forms.GroupBox
    Friend WithEvents RdPDIBA As System.Windows.Forms.RadioButton
    Friend WithEvents RdVentanadeGenero As System.Windows.Forms.RadioButton
    Friend WithEvents RdUsuraCero As System.Windows.Forms.RadioButton
End Class
