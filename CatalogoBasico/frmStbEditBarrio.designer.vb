<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbEditBarrio
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbEditBarrio))
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.errBarrio = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.grpDatosBarrio = New System.Windows.Forms.GroupBox
        Me.chkIncluidoPrograma = New System.Windows.Forms.CheckBox
        Me.lblIncluidoPrograma = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.lblActivo = New System.Windows.Forms.Label
        Me.cboDistrito = New C1.Win.C1List.C1Combo
        Me.lblDistrito = New System.Windows.Forms.Label
        Me.cboMunicipio = New C1.Win.C1List.C1Combo
        Me.lblMunicipio = New System.Windows.Forms.Label
        Me.cboDepartamento = New C1.Win.C1List.C1Combo
        Me.lblDepartamento = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosBarrio.SuspendLayout()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'errBarrio
        '
        Me.errBarrio.ContainerControl = Me
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'toolEliminar
        '
        Me.toolEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminar.Name = "toolEliminar"
        Me.toolEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminar.Text = "Eliminar"
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 22)
        Me.toolAyuda.Text = "Ayuda"
        Me.toolAyuda.ToolTipText = "Ayuda"
        '
        'grpDatosBarrio
        '
        Me.grpDatosBarrio.Controls.Add(Me.chkIncluidoPrograma)
        Me.grpDatosBarrio.Controls.Add(Me.lblIncluidoPrograma)
        Me.grpDatosBarrio.Controls.Add(Me.txtDescripcion)
        Me.grpDatosBarrio.Controls.Add(Me.lblDescripcion)
        Me.grpDatosBarrio.Controls.Add(Me.txtCodigo)
        Me.grpDatosBarrio.Controls.Add(Me.lblCodigo)
        Me.grpDatosBarrio.Controls.Add(Me.chkActivo)
        Me.grpDatosBarrio.Controls.Add(Me.lblActivo)
        Me.grpDatosBarrio.Controls.Add(Me.cboDistrito)
        Me.grpDatosBarrio.Controls.Add(Me.lblDistrito)
        Me.grpDatosBarrio.Controls.Add(Me.cboMunicipio)
        Me.grpDatosBarrio.Controls.Add(Me.lblMunicipio)
        Me.grpDatosBarrio.Controls.Add(Me.cboDepartamento)
        Me.grpDatosBarrio.Controls.Add(Me.lblDepartamento)
        Me.grpDatosBarrio.Location = New System.Drawing.Point(12, 12)
        Me.grpDatosBarrio.Name = "grpDatosBarrio"
        Me.grpDatosBarrio.Size = New System.Drawing.Size(465, 224)
        Me.grpDatosBarrio.TabIndex = 0
        Me.grpDatosBarrio.TabStop = False
        Me.grpDatosBarrio.Text = "Datos Barrio"
        '
        'chkIncluidoPrograma
        '
        Me.chkIncluidoPrograma.AutoSize = True
        Me.chkIncluidoPrograma.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIncluidoPrograma.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkIncluidoPrograma.Location = New System.Drawing.Point(235, 169)
        Me.chkIncluidoPrograma.Name = "chkIncluidoPrograma"
        Me.chkIncluidoPrograma.Size = New System.Drawing.Size(17, 17)
        Me.chkIncluidoPrograma.TabIndex = 5
        Me.chkIncluidoPrograma.Tag = ""
        Me.chkIncluidoPrograma.Text = "  "
        Me.chkIncluidoPrograma.UseVisualStyleBackColor = True
        '
        'lblIncluidoPrograma
        '
        Me.lblIncluidoPrograma.AutoSize = True
        Me.lblIncluidoPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblIncluidoPrograma.Location = New System.Drawing.Point(6, 169)
        Me.lblIncluidoPrograma.Name = "lblIncluidoPrograma"
        Me.lblIncluidoPrograma.Size = New System.Drawing.Size(201, 13)
        Me.lblIncluidoPrograma.TabIndex = 113
        Me.lblIncluidoPrograma.Text = "Incluido en el Programa de Micro Crédito:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(106, 136)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(343, 20)
        Me.txtDescripcion.TabIndex = 4
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDescripcion.Location = New System.Drawing.Point(6, 143)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(94, 13)
        Me.lblDescripcion.TabIndex = 111
        Me.lblDescripcion.Text = "Nombre del Barrio:"
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(106, 29)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtCodigo.Size = New System.Drawing.Size(38, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(7, 36)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 105
        Me.lblCodigo.Text = "Código:"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkActivo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkActivo.Location = New System.Drawing.Point(106, 194)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(17, 17)
        Me.chkActivo.TabIndex = 6
        Me.chkActivo.Tag = ""
        Me.chkActivo.Text = "  "
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblActivo.Location = New System.Drawing.Point(6, 195)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(40, 13)
        Me.lblActivo.TabIndex = 103
        Me.lblActivo.Text = "Activo:"
        '
        'cboDistrito
        '
        Me.cboDistrito.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDistrito.AutoCompletion = True
        Me.cboDistrito.Caption = ""
        Me.cboDistrito.CaptionHeight = 17
        Me.cboDistrito.CaptionStyle = Style1
        Me.cboDistrito.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDistrito.ColumnCaptionHeight = 17
        Me.cboDistrito.ColumnFooterHeight = 17
        Me.cboDistrito.ContentHeight = 15
        Me.cboDistrito.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDistrito.DisplayMember = "Descripcion"
        Me.cboDistrito.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDistrito.DropDownWidth = 146
        Me.cboDistrito.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDistrito.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDistrito.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDistrito.EditorHeight = 15
        Me.cboDistrito.EvenRowStyle = Style2
        Me.cboDistrito.ExtendRightColumn = True
        Me.cboDistrito.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDistrito.FooterStyle = Style3
        Me.cboDistrito.GapHeight = 2
        Me.cboDistrito.HeadingStyle = Style4
        Me.cboDistrito.HighLightRowStyle = Style5
        Me.cboDistrito.Images.Add(CType(resources.GetObject("cboDistrito.Images"), System.Drawing.Image))
        Me.cboDistrito.ItemHeight = 15
        Me.cboDistrito.LimitToList = True
        Me.cboDistrito.Location = New System.Drawing.Point(106, 109)
        Me.cboDistrito.MatchEntryTimeout = CType(2000, Long)
        Me.cboDistrito.MaxDropDownItems = CType(5, Short)
        Me.cboDistrito.MaxLength = 32767
        Me.cboDistrito.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDistrito.Name = "cboDistrito"
        Me.cboDistrito.OddRowStyle = Style6
        Me.cboDistrito.PartialRightColumn = False
        Me.cboDistrito.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDistrito.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDistrito.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDistrito.SelectedStyle = Style7
        Me.cboDistrito.Size = New System.Drawing.Size(146, 21)
        Me.cboDistrito.Style = Style8
        Me.cboDistrito.SuperBack = True
        Me.cboDistrito.TabIndex = 3
        Me.cboDistrito.ValueMember = "StbValorCatalogoID"
        Me.cboDistrito.PropBag = resources.GetString("cboDistrito.PropBag")
        '
        'lblDistrito
        '
        Me.lblDistrito.AutoSize = True
        Me.lblDistrito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDistrito.Location = New System.Drawing.Point(6, 117)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(42, 13)
        Me.lblDistrito.TabIndex = 34
        Me.lblDistrito.Text = "Distrito:"
        '
        'cboMunicipio
        '
        Me.cboMunicipio.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
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
        Me.cboMunicipio.DropDownWidth = 188
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
        Me.cboMunicipio.LimitToList = True
        Me.cboMunicipio.Location = New System.Drawing.Point(106, 82)
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
        Me.cboMunicipio.Size = New System.Drawing.Size(168, 21)
        Me.cboMunicipio.Style = Style16
        Me.cboMunicipio.SuperBack = True
        Me.cboMunicipio.TabIndex = 2
        Me.cboMunicipio.ValueMember = "StbValorCatalogoID"
        Me.cboMunicipio.PropBag = resources.GetString("cboMunicipio.PropBag")
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(7, 90)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(55, 13)
        Me.lblMunicipio.TabIndex = 32
        Me.lblMunicipio.Text = "Municipio:"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style17
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "Descripcion"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 153
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.EvenRowStyle = Style18
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style19
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style20
        Me.cboDepartamento.HighLightRowStyle = Style21
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(106, 55)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style22
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style23
        Me.cboDepartamento.Size = New System.Drawing.Size(153, 21)
        Me.cboDepartamento.Style = Style24
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 1
        Me.cboDepartamento.ValueMember = "StbValorCatalogoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(6, 63)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(77, 13)
        Me.lblDepartamento.TabIndex = 5
        Me.lblDepartamento.Text = "Departamento:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(404, 242)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(327, 242)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'frmStbEditBarrio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 279)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpDatosBarrio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Barrios")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbEditBarrio"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barrio"
        CType(Me.errBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosBarrio.ResumeLayout(False)
        Me.grpDatosBarrio.PerformLayout()
        CType(Me.cboDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents errBarrio As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpDatosBarrio As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents cboDistrito As C1.Win.C1List.C1Combo
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents cboMunicipio As C1.Win.C1List.C1Combo
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents chkIncluidoPrograma As System.Windows.Forms.CheckBox
    Friend WithEvents lblIncluidoPrograma As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
