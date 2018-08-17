<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclParametroFNC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclParametroFNC))
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
        Me.grpdatosFormatos = New System.Windows.Forms.GroupBox
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.grpdestino = New System.Windows.Forms.GroupBox
        Me.RadArchivo = New System.Windows.Forms.RadioButton
        Me.RadImpresora = New System.Windows.Forms.RadioButton
        Me.radPantalla = New System.Windows.Forms.RadioButton
        Me.Exportar = New System.Windows.Forms.SaveFileDialog
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.grpDatosListados = New System.Windows.Forms.GroupBox
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox
        Me.cboGS = New C1.Win.C1List.C1Combo
        Me.cboEstado = New C1.Win.C1List.C1Combo
        Me.cboOrdenado = New C1.Win.C1List.C1Combo
        Me.lblOrdenRpt = New System.Windows.Forms.Label
        Me.lblEstadoRpt = New System.Windows.Forms.Label
        Me.lblCodRpt = New System.Windows.Forms.Label
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpdatosFormatos.SuspendLayout()
        Me.grpdestino.SuspendLayout()
        Me.grpDatosListados.SuspendLayout()
        CType(Me.cboGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOrdenado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.grpdatosFormatos.Size = New System.Drawing.Size(444, 84)
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
        Me.txtEstado.TabIndex = 38
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
        Me.txtCodigo.TabIndex = 36
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
        Me.grpdestino.Location = New System.Drawing.Point(10, 102)
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
        Me.RadArchivo.TabIndex = 6
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
        Me.RadImpresora.TabIndex = 5
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
        Me.radPantalla.TabIndex = 4
        Me.radPantalla.TabStop = True
        Me.radPantalla.Text = "Pantalla"
        Me.radPantalla.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(383, 165)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(311, 165)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'grpDatosListados
        '
        Me.grpDatosListados.Controls.Add(Me.mtbNumCedula)
        Me.grpDatosListados.Controls.Add(Me.cboGS)
        Me.grpDatosListados.Controls.Add(Me.cboEstado)
        Me.grpDatosListados.Controls.Add(Me.cboOrdenado)
        Me.grpDatosListados.Controls.Add(Me.lblOrdenRpt)
        Me.grpDatosListados.Controls.Add(Me.lblEstadoRpt)
        Me.grpDatosListados.Controls.Add(Me.lblCodRpt)
        Me.grpDatosListados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosListados.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpDatosListados.Location = New System.Drawing.Point(10, 12)
        Me.grpDatosListados.Name = "grpDatosListados"
        Me.grpDatosListados.Size = New System.Drawing.Size(444, 84)
        Me.grpDatosListados.TabIndex = 39
        Me.grpDatosListados.TabStop = False
        Me.grpDatosListados.Text = "Datos Generales"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(91, 22)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(140, 20)
        Me.mtbNumCedula.TabIndex = 39
        '
        'cboGS
        '
        Me.cboGS.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboGS.AutoCompletion = True
        Me.cboGS.AutoDropDown = True
        Me.cboGS.Caption = ""
        Me.cboGS.CaptionHeight = 17
        Me.cboGS.CaptionStyle = Style1
        Me.cboGS.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboGS.ColumnCaptionHeight = 17
        Me.cboGS.ColumnFooterHeight = 17
        Me.cboGS.ContentHeight = 15
        Me.cboGS.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboGS.DisplayMember = "sNombre"
        Me.cboGS.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboGS.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGS.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboGS.EditorHeight = 15
        Me.cboGS.EvenRowStyle = Style2
        Me.cboGS.ExtendRightColumn = True
        Me.cboGS.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboGS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGS.FooterStyle = Style3
        Me.cboGS.GapHeight = 2
        Me.cboGS.HeadingStyle = Style4
        Me.cboGS.HighLightRowStyle = Style5
        Me.cboGS.Images.Add(CType(resources.GetObject("cboGS.Images"), System.Drawing.Image))
        Me.cboGS.ItemHeight = 15
        Me.cboGS.LimitToList = True
        Me.cboGS.Location = New System.Drawing.Point(89, 22)
        Me.cboGS.MatchEntryTimeout = CType(2000, Long)
        Me.cboGS.MaxDropDownItems = CType(5, Short)
        Me.cboGS.MaxLength = 32767
        Me.cboGS.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboGS.Name = "cboGS"
        Me.cboGS.OddRowStyle = Style6
        Me.cboGS.PartialRightColumn = False
        Me.cboGS.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboGS.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboGS.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboGS.SelectedStyle = Style7
        Me.cboGS.Size = New System.Drawing.Size(338, 21)
        Me.cboGS.Style = Style8
        Me.cboGS.SuperBack = True
        Me.cboGS.TabIndex = 1
        Me.cboGS.ValueMember = "ID"
        Me.cboGS.PropBag = resources.GetString("cboGS.PropBag")
        '
        'cboEstado
        '
        Me.cboEstado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstado.AutoCompletion = True
        Me.cboEstado.AutoDropDown = True
        Me.cboEstado.Caption = ""
        Me.cboEstado.CaptionHeight = 17
        Me.cboEstado.CaptionStyle = Style9
        Me.cboEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEstado.ColumnCaptionHeight = 17
        Me.cboEstado.ColumnFooterHeight = 17
        Me.cboEstado.ContentHeight = 15
        Me.cboEstado.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboEstado.DisplayMember = "Estado"
        Me.cboEstado.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboEstado.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEstado.EditorHeight = 15
        Me.cboEstado.EvenRowStyle = Style10
        Me.cboEstado.ExtendRightColumn = True
        Me.cboEstado.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.FooterStyle = Style11
        Me.cboEstado.GapHeight = 2
        Me.cboEstado.HeadingStyle = Style12
        Me.cboEstado.HighLightRowStyle = Style13
        Me.cboEstado.Images.Add(CType(resources.GetObject("cboEstado.Images"), System.Drawing.Image))
        Me.cboEstado.ItemHeight = 15
        Me.cboEstado.LimitToList = True
        Me.cboEstado.Location = New System.Drawing.Point(89, 49)
        Me.cboEstado.MatchEntryTimeout = CType(2000, Long)
        Me.cboEstado.MaxDropDownItems = CType(5, Short)
        Me.cboEstado.MaxLength = 32767
        Me.cboEstado.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.OddRowStyle = Style14
        Me.cboEstado.PartialRightColumn = False
        Me.cboEstado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEstado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEstado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEstado.SelectedStyle = Style15
        Me.cboEstado.Size = New System.Drawing.Size(142, 21)
        Me.cboEstado.Style = Style16
        Me.cboEstado.SuperBack = True
        Me.cboEstado.TabIndex = 2
        Me.cboEstado.ValueMember = "IDEstado"
        Me.cboEstado.PropBag = resources.GetString("cboEstado.PropBag")
        '
        'cboOrdenado
        '
        Me.cboOrdenado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboOrdenado.AutoCompletion = True
        Me.cboOrdenado.AutoDropDown = True
        Me.cboOrdenado.Caption = ""
        Me.cboOrdenado.CaptionHeight = 17
        Me.cboOrdenado.CaptionStyle = Style17
        Me.cboOrdenado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboOrdenado.ColumnCaptionHeight = 17
        Me.cboOrdenado.ColumnFooterHeight = 17
        Me.cboOrdenado.ContentHeight = 15
        Me.cboOrdenado.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboOrdenado.DisplayMember = "Orden"
        Me.cboOrdenado.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboOrdenado.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrdenado.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboOrdenado.EditorHeight = 15
        Me.cboOrdenado.EvenRowStyle = Style18
        Me.cboOrdenado.ExtendRightColumn = True
        Me.cboOrdenado.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboOrdenado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOrdenado.FooterStyle = Style19
        Me.cboOrdenado.GapHeight = 2
        Me.cboOrdenado.HeadingStyle = Style20
        Me.cboOrdenado.HighLightRowStyle = Style21
        Me.cboOrdenado.Images.Add(CType(resources.GetObject("cboOrdenado.Images"), System.Drawing.Image))
        Me.cboOrdenado.ItemHeight = 15
        Me.cboOrdenado.LimitToList = True
        Me.cboOrdenado.Location = New System.Drawing.Point(314, 52)
        Me.cboOrdenado.MatchEntryTimeout = CType(2000, Long)
        Me.cboOrdenado.MaxDropDownItems = CType(5, Short)
        Me.cboOrdenado.MaxLength = 32767
        Me.cboOrdenado.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboOrdenado.Name = "cboOrdenado"
        Me.cboOrdenado.OddRowStyle = Style22
        Me.cboOrdenado.PartialRightColumn = False
        Me.cboOrdenado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboOrdenado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboOrdenado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboOrdenado.SelectedStyle = Style23
        Me.cboOrdenado.Size = New System.Drawing.Size(113, 21)
        Me.cboOrdenado.Style = Style24
        Me.cboOrdenado.SuperBack = True
        Me.cboOrdenado.TabIndex = 3
        Me.cboOrdenado.ValueMember = "IDOrden"
        Me.cboOrdenado.PropBag = resources.GetString("cboOrdenado.PropBag")
        '
        'lblOrdenRpt
        '
        Me.lblOrdenRpt.AutoSize = True
        Me.lblOrdenRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdenRpt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblOrdenRpt.Location = New System.Drawing.Point(237, 56)
        Me.lblOrdenRpt.Name = "lblOrdenRpt"
        Me.lblOrdenRpt.Size = New System.Drawing.Size(76, 13)
        Me.lblOrdenRpt.TabIndex = 38
        Me.lblOrdenRpt.Text = "Ordenado Por:"
        '
        'lblEstadoRpt
        '
        Me.lblEstadoRpt.AutoSize = True
        Me.lblEstadoRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstadoRpt.ForeColor = System.Drawing.Color.Black
        Me.lblEstadoRpt.Location = New System.Drawing.Point(12, 52)
        Me.lblEstadoRpt.Name = "lblEstadoRpt"
        Me.lblEstadoRpt.Size = New System.Drawing.Size(75, 13)
        Me.lblEstadoRpt.TabIndex = 37
        Me.lblEstadoRpt.Text = "Estado Grupo:"
        '
        'lblCodRpt
        '
        Me.lblCodRpt.AutoSize = True
        Me.lblCodRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodRpt.ForeColor = System.Drawing.Color.Black
        Me.lblCodRpt.Location = New System.Drawing.Point(10, 26)
        Me.lblCodRpt.Name = "lblCodRpt"
        Me.lblCodRpt.Size = New System.Drawing.Size(75, 13)
        Me.lblCodRpt.TabIndex = 35
        Me.lblCodRpt.Text = "Código Grupo:"
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'frmSclParametroFNC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 204)
        Me.Controls.Add(Me.grpdatosFormatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdestino)
        Me.Controls.Add(Me.grpDatosListados)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Ficha de Notificación de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclParametroFNC"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros Ficha de Notificación de Crédito"
        Me.grpdatosFormatos.ResumeLayout(False)
        Me.grpdatosFormatos.PerformLayout()
        Me.grpdestino.ResumeLayout(False)
        Me.grpdestino.PerformLayout()
        Me.grpDatosListados.ResumeLayout(False)
        Me.grpDatosListados.PerformLayout()
        CType(Me.cboGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOrdenado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents grpDatosListados As System.Windows.Forms.GroupBox
    Friend WithEvents lblOrdenRpt As System.Windows.Forms.Label
    Friend WithEvents lblEstadoRpt As System.Windows.Forms.Label
    Friend WithEvents lblCodRpt As System.Windows.Forms.Label
    Friend WithEvents cboEstado As C1.Win.C1List.C1Combo
    Friend WithEvents cboOrdenado As C1.Win.C1List.C1Combo
    Friend WithEvents cboGS As C1.Win.C1List.C1Combo
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
