<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccMetaCumplidaSocia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccMetaCumplidaSocia))
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
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox()
        Me.txtNombreGS = New System.Windows.Forms.TextBox()
        Me.lblNombreGS = New System.Windows.Forms.Label()
        Me.cboGrupo = New C1.Win.C1List.C1Combo()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.cboBarrio = New C1.Win.C1List.C1Combo()
        Me.lblBarrio = New System.Windows.Forms.Label()
        Me.cboDistrito = New C1.Win.C1List.C1Combo()
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.cboMunicipio = New C1.Win.C1List.C1Combo()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.cboDepartamento = New C1.Win.C1List.C1Combo()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.grdFicha = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tbFicha = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolMarcarCumplido = New System.Windows.Forms.ToolStripButton()
        Me.toolMarcarIncumplido = New System.Windows.Forms.ToolStripButton()
        Me.toolMarcarNoEvaluado = New System.Windows.Forms.ToolStripButton()
        Me.toolMarcarCambiado = New System.Windows.Forms.ToolStripButton()
        Me.toolMarcarCasoEspecial = New System.Windows.Forms.ToolStripButton()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.toolMarcarReintegrada = New System.Windows.Forms.ToolStripButton()
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cboGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbFicha.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.txtNombreGS)
        Me.grpDatosGenerales.Controls.Add(Me.lblNombreGS)
        Me.grpDatosGenerales.Controls.Add(Me.cboGrupo)
        Me.grpDatosGenerales.Controls.Add(Me.lblGrupo)
        Me.grpDatosGenerales.Controls.Add(Me.cboBarrio)
        Me.grpDatosGenerales.Controls.Add(Me.lblBarrio)
        Me.grpDatosGenerales.Controls.Add(Me.cboDistrito)
        Me.grpDatosGenerales.Controls.Add(Me.lblDistrito)
        Me.grpDatosGenerales.Controls.Add(Me.cboMunicipio)
        Me.grpDatosGenerales.Controls.Add(Me.lblMunicipio)
        Me.grpDatosGenerales.Controls.Add(Me.txtEstado)
        Me.grpDatosGenerales.Controls.Add(Me.txtCodigo)
        Me.grpDatosGenerales.Controls.Add(Me.lblEstado)
        Me.grpDatosGenerales.Controls.Add(Me.lblCodigo)
        Me.grpDatosGenerales.Controls.Add(Me.cboDepartamento)
        Me.grpDatosGenerales.Controls.Add(Me.lblDepartamento)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(1, 2)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(779, 131)
        Me.grpDatosGenerales.TabIndex = 1
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos Generales"
        '
        'txtNombreGS
        '
        Me.txtNombreGS.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreGS.Enabled = False
        Me.txtNombreGS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreGS.Location = New System.Drawing.Point(550, 103)
        Me.txtNombreGS.Name = "txtNombreGS"
        Me.txtNombreGS.ReadOnly = True
        Me.txtNombreGS.ShortcutsEnabled = False
        Me.txtNombreGS.Size = New System.Drawing.Size(220, 20)
        Me.txtNombreGS.TabIndex = 19
        Me.txtNombreGS.Tag = "LAYOUT:FLAT"
        '
        'lblNombreGS
        '
        Me.lblNombreGS.AutoSize = True
        Me.lblNombreGS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreGS.Location = New System.Drawing.Point(441, 102)
        Me.lblNombreGS.Name = "lblNombreGS"
        Me.lblNombreGS.Size = New System.Drawing.Size(111, 13)
        Me.lblNombreGS.TabIndex = 18
        Me.lblNombreGS.Text = "Nombre Grupo/Socia:"
        '
        'cboGrupo
        '
        Me.cboGrupo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboGrupo.AutoCompletion = True
        Me.cboGrupo.Caption = ""
        Me.cboGrupo.CaptionHeight = 17
        Me.cboGrupo.CaptionStyle = Style1
        Me.cboGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboGrupo.ColumnCaptionHeight = 17
        Me.cboGrupo.ColumnFooterHeight = 17
        Me.cboGrupo.ContentHeight = 15
        Me.cboGrupo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboGrupo.DisplayMember = "sCodigo"
        Me.cboGrupo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboGrupo.DropDownWidth = 300
        Me.cboGrupo.EditorBackColor = System.Drawing.SystemColors.Info
        Me.cboGrupo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboGrupo.EditorHeight = 15
        Me.cboGrupo.Enabled = False
        Me.cboGrupo.EvenRowStyle = Style2
        Me.cboGrupo.ExtendRightColumn = True
        Me.cboGrupo.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboGrupo.FooterStyle = Style3
        Me.cboGrupo.GapHeight = 2
        Me.cboGrupo.HeadingStyle = Style4
        Me.cboGrupo.HighLightRowStyle = Style5
        Me.cboGrupo.Images.Add(CType(resources.GetObject("cboGrupo.Images"), System.Drawing.Image))
        Me.cboGrupo.ItemHeight = 15
        Me.cboGrupo.LimitToList = True
        Me.cboGrupo.Location = New System.Drawing.Point(152, 102)
        Me.cboGrupo.MatchEntryTimeout = CType(2000, Long)
        Me.cboGrupo.MaxDropDownItems = CType(5, Short)
        Me.cboGrupo.MaxLength = 32767
        Me.cboGrupo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.OddRowStyle = Style6
        Me.cboGrupo.PartialRightColumn = False
        Me.cboGrupo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboGrupo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboGrupo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboGrupo.SelectedStyle = Style7
        Me.cboGrupo.Size = New System.Drawing.Size(224, 21)
        Me.cboGrupo.Style = Style8
        Me.cboGrupo.SuperBack = True
        Me.cboGrupo.TabIndex = 17
        Me.cboGrupo.ValueMember = "SclGrupoSolidarioID"
        Me.cboGrupo.PropBag = resources.GetString("cboGrupo.PropBag")
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupo.Location = New System.Drawing.Point(30, 102)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(120, 13)
        Me.lblGrupo.TabIndex = 16
        Me.lblGrupo.Text = "Grupo Solidario / Socia:"
        '
        'cboBarrio
        '
        Me.cboBarrio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboBarrio.AutoCompletion = True
        Me.cboBarrio.Caption = ""
        Me.cboBarrio.CaptionHeight = 17
        Me.cboBarrio.CaptionStyle = Style9
        Me.cboBarrio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBarrio.ColumnCaptionHeight = 17
        Me.cboBarrio.ColumnFooterHeight = 17
        Me.cboBarrio.ContentHeight = 15
        Me.cboBarrio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBarrio.DisplayMember = "sNombre"
        Me.cboBarrio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboBarrio.DropDownWidth = 221
        Me.cboBarrio.EditorBackColor = System.Drawing.SystemColors.Info
        Me.cboBarrio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBarrio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBarrio.EditorHeight = 15
        Me.cboBarrio.Enabled = False
        Me.cboBarrio.EvenRowStyle = Style10
        Me.cboBarrio.ExtendRightColumn = True
        Me.cboBarrio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboBarrio.FooterStyle = Style11
        Me.cboBarrio.GapHeight = 2
        Me.cboBarrio.HeadingStyle = Style12
        Me.cboBarrio.HighLightRowStyle = Style13
        Me.cboBarrio.Images.Add(CType(resources.GetObject("cboBarrio.Images"), System.Drawing.Image))
        Me.cboBarrio.ItemHeight = 15
        Me.cboBarrio.LimitToList = True
        Me.cboBarrio.Location = New System.Drawing.Point(550, 72)
        Me.cboBarrio.MatchEntryTimeout = CType(2000, Long)
        Me.cboBarrio.MaxDropDownItems = CType(5, Short)
        Me.cboBarrio.MaxLength = 32767
        Me.cboBarrio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBarrio.Name = "cboBarrio"
        Me.cboBarrio.OddRowStyle = Style14
        Me.cboBarrio.PartialRightColumn = False
        Me.cboBarrio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBarrio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBarrio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBarrio.SelectedStyle = Style15
        Me.cboBarrio.Size = New System.Drawing.Size(220, 21)
        Me.cboBarrio.Style = Style16
        Me.cboBarrio.SuperBack = True
        Me.cboBarrio.TabIndex = 15
        Me.cboBarrio.ValueMember = "nStbBarrioID"
        Me.cboBarrio.PropBag = resources.GetString("cboBarrio.PropBag")
        '
        'lblBarrio
        '
        Me.lblBarrio.AutoSize = True
        Me.lblBarrio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblBarrio.Location = New System.Drawing.Point(441, 72)
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Size = New System.Drawing.Size(37, 13)
        Me.lblBarrio.TabIndex = 14
        Me.lblBarrio.Text = "Barrio:"
        '
        'cboDistrito
        '
        Me.cboDistrito.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDistrito.AutoCompletion = True
        Me.cboDistrito.Caption = ""
        Me.cboDistrito.CaptionHeight = 17
        Me.cboDistrito.CaptionStyle = Style17
        Me.cboDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDistrito.ColumnCaptionHeight = 17
        Me.cboDistrito.ColumnFooterHeight = 17
        Me.cboDistrito.ContentHeight = 15
        Me.cboDistrito.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDistrito.DisplayMember = "sNombre"
        Me.cboDistrito.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDistrito.DropDownWidth = 225
        Me.cboDistrito.EditorBackColor = System.Drawing.SystemColors.Info
        Me.cboDistrito.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrito.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDistrito.EditorHeight = 15
        Me.cboDistrito.Enabled = False
        Me.cboDistrito.EvenRowStyle = Style18
        Me.cboDistrito.ExtendRightColumn = True
        Me.cboDistrito.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDistrito.FooterStyle = Style19
        Me.cboDistrito.GapHeight = 2
        Me.cboDistrito.HeadingStyle = Style20
        Me.cboDistrito.HighLightRowStyle = Style21
        Me.cboDistrito.Images.Add(CType(resources.GetObject("cboDistrito.Images"), System.Drawing.Image))
        Me.cboDistrito.ItemHeight = 15
        Me.cboDistrito.LimitToList = True
        Me.cboDistrito.Location = New System.Drawing.Point(152, 72)
        Me.cboDistrito.MatchEntryTimeout = CType(2000, Long)
        Me.cboDistrito.MaxDropDownItems = CType(5, Short)
        Me.cboDistrito.MaxLength = 32767
        Me.cboDistrito.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.OddRowStyle = Style22
        Me.cboDistrito.PartialRightColumn = False
        Me.cboDistrito.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDistrito.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDistrito.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDistrito.SelectedStyle = Style23
        Me.cboDistrito.Size = New System.Drawing.Size(224, 21)
        Me.cboDistrito.Style = Style24
        Me.cboDistrito.SuperBack = True
        Me.cboDistrito.TabIndex = 13
        Me.cboDistrito.ValueMember = "nStbDistritoID"
        Me.cboDistrito.PropBag = resources.GetString("cboDistrito.PropBag")
        '
        'lblDistrito
        '
        Me.lblDistrito.AutoSize = True
        Me.lblDistrito.ForeColor = System.Drawing.Color.Black
        Me.lblDistrito.Location = New System.Drawing.Point(30, 72)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(42, 13)
        Me.lblDistrito.TabIndex = 12
        Me.lblDistrito.Text = "Distrito:"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMunicipio.AutoCompletion = True
        Me.cboMunicipio.Caption = ""
        Me.cboMunicipio.CaptionHeight = 17
        Me.cboMunicipio.CaptionStyle = Style25
        Me.cboMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMunicipio.ColumnCaptionHeight = 17
        Me.cboMunicipio.ColumnFooterHeight = 17
        Me.cboMunicipio.ContentHeight = 15
        Me.cboMunicipio.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMunicipio.DisplayMember = "sNombre"
        Me.cboMunicipio.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMunicipio.DropDownWidth = 221
        Me.cboMunicipio.EditorBackColor = System.Drawing.SystemColors.Info
        Me.cboMunicipio.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMunicipio.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMunicipio.EditorHeight = 15
        Me.cboMunicipio.Enabled = False
        Me.cboMunicipio.EvenRowStyle = Style26
        Me.cboMunicipio.ExtendRightColumn = True
        Me.cboMunicipio.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMunicipio.FooterStyle = Style27
        Me.cboMunicipio.GapHeight = 2
        Me.cboMunicipio.HeadingStyle = Style28
        Me.cboMunicipio.HighLightRowStyle = Style29
        Me.cboMunicipio.Images.Add(CType(resources.GetObject("cboMunicipio.Images"), System.Drawing.Image))
        Me.cboMunicipio.ItemHeight = 15
        Me.cboMunicipio.LimitToList = True
        Me.cboMunicipio.Location = New System.Drawing.Point(550, 42)
        Me.cboMunicipio.MatchEntryTimeout = CType(2000, Long)
        Me.cboMunicipio.MaxDropDownItems = CType(5, Short)
        Me.cboMunicipio.MaxLength = 32767
        Me.cboMunicipio.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMunicipio.Name = "cboMunicipio"
        Me.cboMunicipio.OddRowStyle = Style30
        Me.cboMunicipio.PartialRightColumn = False
        Me.cboMunicipio.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMunicipio.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMunicipio.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMunicipio.SelectedStyle = Style31
        Me.cboMunicipio.Size = New System.Drawing.Size(220, 21)
        Me.cboMunicipio.Style = Style32
        Me.cboMunicipio.SuperBack = True
        Me.cboMunicipio.TabIndex = 11
        Me.cboMunicipio.ValueMember = "nStbMunicipioID"
        Me.cboMunicipio.PropBag = resources.GetString("cboMunicipio.PropBag")
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(441, 42)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(55, 13)
        Me.lblMunicipio.TabIndex = 10
        Me.lblMunicipio.Text = "Municipio:"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(550, 16)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.ShortcutsEnabled = False
        Me.txtEstado.Size = New System.Drawing.Size(146, 20)
        Me.txtEstado.TabIndex = 3
        Me.txtEstado.Tag = "LAYOUT:FLAT"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(152, 16)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.ShortcutsEnabled = False
        Me.txtCodigo.Size = New System.Drawing.Size(146, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(441, 16)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(72, 13)
        Me.lblEstado.TabIndex = 2
        Me.lblEstado.Text = "Estado Ficha:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(30, 16)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código de Ficha:"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style33
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "sNombre"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 225
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Info
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.Enabled = False
        Me.cboDepartamento.EvenRowStyle = Style34
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style35
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style36
        Me.cboDepartamento.HighLightRowStyle = Style37
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(152, 42)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style38
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style39
        Me.cboDepartamento.Size = New System.Drawing.Size(224, 21)
        Me.cboDepartamento.Style = Style40
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 9
        Me.cboDepartamento.ValueMember = "nStbDepartamentoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(30, 42)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 8
        Me.lblDepartamento.Text = "Departamento:"
        '
        'grdFicha
        '
        Me.grdFicha.AllowFilter = False
        Me.grdFicha.AllowUpdate = False
        Me.grdFicha.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdFicha.Caption = "Listado de Metas de Prosperidad"
        Me.grdFicha.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdFicha.FilterBar = True
        Me.grdFicha.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdFicha.Images.Add(CType(resources.GetObject("grdFicha.Images"), System.Drawing.Image))
        Me.grdFicha.Location = New System.Drawing.Point(1, 164)
        Me.grdFicha.Name = "grdFicha"
        Me.grdFicha.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdFicha.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdFicha.PreviewInfo.ZoomFactor = 75.0R
        Me.grdFicha.PrintInfo.PageSettings = CType(resources.GetObject("grdFicha.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdFicha.Size = New System.Drawing.Size(779, 283)
        Me.grdFicha.TabIndex = 3
        Me.grdFicha.Text = "grdFicha"
        Me.grdFicha.PropBag = resources.GetString("grdFicha.PropBag")
        '
        'tbFicha
        '
        Me.tbFicha.Dock = System.Windows.Forms.DockStyle.None
        Me.tbFicha.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator4, Me.toolRefrescar, Me.toolMarcarCumplido, Me.toolMarcarIncumplido, Me.toolMarcarNoEvaluado, Me.toolMarcarCambiado, Me.toolMarcarCasoEspecial, Me.toolMarcarReintegrada})
        Me.tbFicha.Location = New System.Drawing.Point(1, 136)
        Me.tbFicha.Name = "tbFicha"
        Me.tbFicha.Size = New System.Drawing.Size(179, 25)
        Me.tbFicha.Stretch = True
        Me.tbFicha.TabIndex = 4
        Me.tbFicha.Text = "ToolStrip1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolMarcarCumplido
        '
        Me.toolMarcarCumplido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMarcarCumplido.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolMarcarCumplido.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMarcarCumplido.Name = "toolMarcarCumplido"
        Me.toolMarcarCumplido.Size = New System.Drawing.Size(23, 22)
        Me.toolMarcarCumplido.Text = "Marcar como cumplido"
        Me.toolMarcarCumplido.ToolTipText = "Marcar como cumplido"
        '
        'toolMarcarIncumplido
        '
        Me.toolMarcarIncumplido.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMarcarIncumplido.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolMarcarIncumplido.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolMarcarIncumplido.Name = "toolMarcarIncumplido"
        Me.toolMarcarIncumplido.Size = New System.Drawing.Size(23, 22)
        Me.toolMarcarIncumplido.Text = "Marcar como NO cumplido"
        Me.toolMarcarIncumplido.ToolTipText = "Marcar como NO cumplido"
        '
        'toolMarcarNoEvaluado
        '
        Me.toolMarcarNoEvaluado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMarcarNoEvaluado.Image = Global.SMUSURA0.My.Resources.Resources.bookmark
        Me.toolMarcarNoEvaluado.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolMarcarNoEvaluado.Name = "toolMarcarNoEvaluado"
        Me.toolMarcarNoEvaluado.Size = New System.Drawing.Size(23, 22)
        Me.toolMarcarNoEvaluado.Text = "Marcar como NO EVALUADA"
        Me.toolMarcarNoEvaluado.ToolTipText = "Marcar como NO EVALUADA"
        '
        'toolMarcarCambiado
        '
        Me.toolMarcarCambiado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMarcarCambiado.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolMarcarCambiado.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMarcarCambiado.Name = "toolMarcarCambiado"
        Me.toolMarcarCambiado.Size = New System.Drawing.Size(23, 22)
        Me.toolMarcarCambiado.Text = "Marcar como CAMBIADA"
        '
        'toolMarcarCasoEspecial
        '
        Me.toolMarcarCasoEspecial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMarcarCasoEspecial.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.toolMarcarCasoEspecial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMarcarCasoEspecial.Name = "toolMarcarCasoEspecial"
        Me.toolMarcarCasoEspecial.Size = New System.Drawing.Size(23, 22)
        Me.toolMarcarCasoEspecial.Text = "Marcar como CASO ESPECIAL"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(707, 453)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 6
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(630, 453)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 5
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'toolMarcarReintegrada
        '
        Me.toolMarcarReintegrada.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolMarcarReintegrada.Image = Global.SMUSURA0.My.Resources.Resources.xedit1
        Me.toolMarcarReintegrada.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolMarcarReintegrada.Name = "toolMarcarReintegrada"
        Me.toolMarcarReintegrada.Size = New System.Drawing.Size(23, 22)
        Me.toolMarcarReintegrada.Text = "Reintegrada"
        '
        'frmSccMetaCumplidaSocia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 482)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.tbFicha)
        Me.Controls.Add(Me.grdFicha)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccMetaCumplidaSocia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar Cumplimiento de Metas"
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cboGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbFicha.ResumeLayout(False)
        Me.tbFicha.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreGS As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreGS As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As C1.Win.C1List.C1Combo
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents cboBarrio As C1.Win.C1List.C1Combo
    Friend WithEvents lblBarrio As System.Windows.Forms.Label
    Friend WithEvents cboDistrito As C1.Win.C1List.C1Combo
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents cboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents grdFicha As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbFicha As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolMarcarCumplido As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolMarcarIncumplido As System.Windows.Forms.ToolStripButton
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolMarcarNoEvaluado As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolMarcarCambiado As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolMarcarCasoEspecial As ToolStripButton
    Friend WithEvents toolMarcarReintegrada As ToolStripButton
End Class
