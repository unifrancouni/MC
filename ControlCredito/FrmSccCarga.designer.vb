<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccCarga
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccCarga))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.ArchivoLocacion = New System.Windows.Forms.OpenFileDialog
        Me.GrpBPrincipal = New System.Windows.Forms.GroupBox
        Me.GrpReiniciar = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbCancelarReinicio = New System.Windows.Forms.Button
        Me.TxtMotivoReinicio = New System.Windows.Forms.TextBox
        Me.CmbAplicarReinico = New System.Windows.Forms.Button
        Me.CmdReporteDuplicadosCentral = New System.Windows.Forms.Button
        Me.CmdReporteDuplicados = New System.Windows.Forms.Button
        Me.gridGenerados = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpGenera = New System.Windows.Forms.GroupBox
        Me.CmbReiniciarContador = New System.Windows.Forms.Button
        Me.CmbAplicarCarga = New System.Windows.Forms.Button
        Me.grpTipoBase = New System.Windows.Forms.GroupBox
        Me.RadCentral = New System.Windows.Forms.RadioButton
        Me.RadLocal = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCaja = New C1.Win.C1List.C1Combo
        Me.CmbRefrescarUnidar = New System.Windows.Forms.Button
        Me.lblRepresentante = New System.Windows.Forms.Label
        Me.cboUnidad = New System.Windows.Forms.ComboBox
        Me.CmbCargarArchivo = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblArchivoAbierto = New System.Windows.Forms.Label
        Me.CmbCargarBase = New System.Windows.Forms.Button
        Me.TxtArchivoAbierto = New System.Windows.Forms.TextBox
        Me.grpPresentaProceso = New System.Windows.Forms.GroupBox
        Me.lBlProcesoBaseFinal = New System.Windows.Forms.Label
        Me.lBlProcesando = New System.Windows.Forms.Label
        Me.lBlProcesoBaseTmp = New System.Windows.Forms.Label
        Me.lBlProcesoZip = New System.Windows.Forms.Label
        Me.ChkCopiarFinal = New System.Windows.Forms.CheckBox
        Me.PrBarProceso = New System.Windows.Forms.ProgressBar
        Me.ChkCopiarTmp = New System.Windows.Forms.CheckBox
        Me.ChkUnZip = New System.Windows.Forms.CheckBox
        Me.DirUnidadBDLocal = New System.Windows.Forms.FolderBrowserDialog
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.GrpBPrincipal.SuspendLayout()
        Me.GrpReiniciar.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridGenerados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGenera.SuspendLayout()
        Me.grpTipoBase.SuspendLayout()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPresentaProceso.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBPrincipal
        '
        Me.GrpBPrincipal.Controls.Add(Me.GrpReiniciar)
        Me.GrpBPrincipal.Controls.Add(Me.CmdReporteDuplicadosCentral)
        Me.GrpBPrincipal.Controls.Add(Me.CmdReporteDuplicados)
        Me.GrpBPrincipal.Controls.Add(Me.gridGenerados)
        Me.GrpBPrincipal.Controls.Add(Me.cmdCancelar)
        Me.GrpBPrincipal.Controls.Add(Me.grpGenera)
        Me.GrpBPrincipal.Controls.Add(Me.grpPresentaProceso)
        Me.GrpBPrincipal.Location = New System.Drawing.Point(5, 3)
        Me.GrpBPrincipal.Name = "GrpBPrincipal"
        Me.GrpBPrincipal.Size = New System.Drawing.Size(687, 536)
        Me.GrpBPrincipal.TabIndex = 0
        Me.GrpBPrincipal.TabStop = False
        '
        'GrpReiniciar
        '
        Me.GrpReiniciar.Controls.Add(Me.GroupBox1)
        Me.GrpReiniciar.Controls.Add(Me.Label3)
        Me.GrpReiniciar.Controls.Add(Me.CmbCancelarReinicio)
        Me.GrpReiniciar.Controls.Add(Me.TxtMotivoReinicio)
        Me.GrpReiniciar.Controls.Add(Me.CmbAplicarReinico)
        Me.GrpReiniciar.Location = New System.Drawing.Point(31, 217)
        Me.GrpReiniciar.Name = "GrpReiniciar"
        Me.GrpReiniciar.Size = New System.Drawing.Size(623, 247)
        Me.GrpReiniciar.TabIndex = 131
        Me.GrpReiniciar.TabStop = False
        Me.GrpReiniciar.Text = "Reiniciar Contador"
        Me.GrpReiniciar.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(611, 78)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RECORDATORIO"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(8, 16)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(587, 41)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "Este proceso se utiliza para reiniciar el contador de las bases locales. Debido a" & _
            " algun fallo en la maquina local que imposibilita tener acceso a la anterior bas" & _
            "e que se habia instalado localmente"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 13)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Descripción del Motivo:"
        '
        'CmbCancelarReinicio
        '
        Me.CmbCancelarReinicio.Image = CType(resources.GetObject("CmbCancelarReinicio.Image"), System.Drawing.Image)
        Me.CmbCancelarReinicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbCancelarReinicio.Location = New System.Drawing.Point(12, 209)
        Me.CmbCancelarReinicio.Name = "CmbCancelarReinicio"
        Me.CmbCancelarReinicio.Size = New System.Drawing.Size(138, 32)
        Me.CmbCancelarReinicio.TabIndex = 128
        Me.CmbCancelarReinicio.Text = "Cancelar Reinicio"
        Me.CmbCancelarReinicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbCancelarReinicio.UseVisualStyleBackColor = True
        '
        'TxtMotivoReinicio
        '
        Me.TxtMotivoReinicio.Location = New System.Drawing.Point(15, 120)
        Me.TxtMotivoReinicio.MaxLength = 250
        Me.TxtMotivoReinicio.Multiline = True
        Me.TxtMotivoReinicio.Name = "TxtMotivoReinicio"
        Me.TxtMotivoReinicio.Size = New System.Drawing.Size(589, 83)
        Me.TxtMotivoReinicio.TabIndex = 0
        '
        'CmbAplicarReinico
        '
        Me.CmbAplicarReinico.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.CmbAplicarReinico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbAplicarReinico.Location = New System.Drawing.Point(478, 209)
        Me.CmbAplicarReinico.Name = "CmbAplicarReinico"
        Me.CmbAplicarReinico.Size = New System.Drawing.Size(123, 32)
        Me.CmbAplicarReinico.TabIndex = 127
        Me.CmbAplicarReinico.Tag = ""
        Me.CmbAplicarReinico.Text = "Aplicar Reinicio"
        Me.CmbAplicarReinico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbAplicarReinico.UseVisualStyleBackColor = True
        '
        'CmdReporteDuplicadosCentral
        '
        Me.CmdReporteDuplicadosCentral.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdReporteDuplicadosCentral.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.CmdReporteDuplicadosCentral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdReporteDuplicadosCentral.Location = New System.Drawing.Point(106, 492)
        Me.CmdReporteDuplicadosCentral.Name = "CmdReporteDuplicadosCentral"
        Me.CmdReporteDuplicadosCentral.Size = New System.Drawing.Size(82, 24)
        Me.CmdReporteDuplicadosCentral.TabIndex = 63
        Me.CmdReporteDuplicadosCentral.Text = "BD Central"
        Me.CmdReporteDuplicadosCentral.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdReporteDuplicadosCentral.UseVisualStyleBackColor = True
        Me.CmdReporteDuplicadosCentral.Visible = False
        '
        'CmdReporteDuplicados
        '
        Me.CmdReporteDuplicados.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdReporteDuplicados.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.CmdReporteDuplicados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdReporteDuplicados.Location = New System.Drawing.Point(18, 492)
        Me.CmdReporteDuplicados.Name = "CmdReporteDuplicados"
        Me.CmdReporteDuplicados.Size = New System.Drawing.Size(82, 24)
        Me.CmdReporteDuplicados.TabIndex = 62
        Me.CmdReporteDuplicados.Text = "BD Temp."
        Me.CmdReporteDuplicados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdReporteDuplicados.UseVisualStyleBackColor = True
        Me.CmdReporteDuplicados.Visible = False
        '
        'gridGenerados
        '
        Me.gridGenerados.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.gridGenerados.AllowFilter = False
        Me.gridGenerados.AllowSort = False
        Me.gridGenerados.AllowUpdate = False
        Me.gridGenerados.Caption = "Cargas Generadas/Guardadas"
        Me.gridGenerados.GroupByAreaVisible = False
        Me.gridGenerados.GroupByCaption = "z"
        Me.gridGenerados.Images.Add(CType(resources.GetObject("gridGenerados.Images"), System.Drawing.Image))
        Me.gridGenerados.Location = New System.Drawing.Point(7, 146)
        Me.gridGenerados.Name = "gridGenerados"
        Me.gridGenerados.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridGenerados.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridGenerados.PreviewInfo.ZoomFactor = 75
        Me.gridGenerados.PrintInfo.PageSettings = CType(resources.GetObject("gridGenerados.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.gridGenerados.Size = New System.Drawing.Size(671, 340)
        Me.gridGenerados.TabIndex = 61
        Me.gridGenerados.PropBag = resources.GetString("gridGenerados.PropBag")
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(596, 492)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(82, 24)
        Me.cmdCancelar.TabIndex = 60
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpGenera
        '
        Me.grpGenera.Controls.Add(Me.CmbReiniciarContador)
        Me.grpGenera.Controls.Add(Me.CmbAplicarCarga)
        Me.grpGenera.Controls.Add(Me.grpTipoBase)
        Me.grpGenera.Controls.Add(Me.cboCaja)
        Me.grpGenera.Controls.Add(Me.CmbRefrescarUnidar)
        Me.grpGenera.Controls.Add(Me.lblRepresentante)
        Me.grpGenera.Controls.Add(Me.cboUnidad)
        Me.grpGenera.Controls.Add(Me.CmbCargarArchivo)
        Me.grpGenera.Controls.Add(Me.Label1)
        Me.grpGenera.Controls.Add(Me.LblArchivoAbierto)
        Me.grpGenera.Controls.Add(Me.CmbCargarBase)
        Me.grpGenera.Controls.Add(Me.TxtArchivoAbierto)
        Me.grpGenera.Location = New System.Drawing.Point(0, 0)
        Me.grpGenera.Name = "grpGenera"
        Me.grpGenera.Size = New System.Drawing.Size(671, 140)
        Me.grpGenera.TabIndex = 128
        Me.grpGenera.TabStop = False
        '
        'CmbReiniciarContador
        '
        Me.CmbReiniciarContador.Enabled = False
        Me.CmbReiniciarContador.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.CmbReiniciarContador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbReiniciarContador.Location = New System.Drawing.Point(537, 68)
        Me.CmbReiniciarContador.Name = "CmbReiniciarContador"
        Me.CmbReiniciarContador.Size = New System.Drawing.Size(117, 29)
        Me.CmbReiniciarContador.TabIndex = 131
        Me.CmbReiniciarContador.Text = "Reiniciar Contador"
        Me.CmbReiniciarContador.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbReiniciarContador.UseVisualStyleBackColor = True
        '
        'CmbAplicarCarga
        '
        Me.CmbAplicarCarga.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.CmbAplicarCarga.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbAplicarCarga.Location = New System.Drawing.Point(535, 108)
        Me.CmbAplicarCarga.Name = "CmbAplicarCarga"
        Me.CmbAplicarCarga.Size = New System.Drawing.Size(119, 27)
        Me.CmbAplicarCarga.TabIndex = 130
        Me.CmbAplicarCarga.Text = "Revisar y Aplicar"
        Me.CmbAplicarCarga.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbAplicarCarga.UseVisualStyleBackColor = True
        '
        'grpTipoBase
        '
        Me.grpTipoBase.Controls.Add(Me.RadCentral)
        Me.grpTipoBase.Controls.Add(Me.RadLocal)
        Me.grpTipoBase.Controls.Add(Me.Label2)
        Me.grpTipoBase.Enabled = False
        Me.grpTipoBase.Location = New System.Drawing.Point(519, 0)
        Me.grpTipoBase.Name = "grpTipoBase"
        Me.grpTipoBase.Size = New System.Drawing.Size(146, 53)
        Me.grpTipoBase.TabIndex = 130
        Me.grpTipoBase.TabStop = False
        '
        'RadCentral
        '
        Me.RadCentral.AutoSize = True
        Me.RadCentral.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCentral.Location = New System.Drawing.Point(18, 33)
        Me.RadCentral.Name = "RadCentral"
        Me.RadCentral.Size = New System.Drawing.Size(58, 17)
        Me.RadCentral.TabIndex = 125
        Me.RadCentral.TabStop = True
        Me.RadCentral.Text = "Central"
        Me.RadCentral.UseVisualStyleBackColor = True
        '
        'RadLocal
        '
        Me.RadLocal.AutoSize = True
        Me.RadLocal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadLocal.Location = New System.Drawing.Point(93, 33)
        Me.RadLocal.Name = "RadLocal"
        Me.RadLocal.Size = New System.Drawing.Size(51, 17)
        Me.RadLocal.TabIndex = 124
        Me.RadLocal.TabStop = True
        Me.RadLocal.Text = "Local"
        Me.RadLocal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(58, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Base"
        '
        'cboCaja
        '
        Me.cboCaja.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCaja.AutoCompletion = True
        Me.cboCaja.Caption = ""
        Me.cboCaja.CaptionHeight = 17
        Me.cboCaja.CaptionStyle = Style9
        Me.cboCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCaja.ColumnCaptionHeight = 17
        Me.cboCaja.ColumnFooterHeight = 17
        Me.cboCaja.ContentHeight = 15
        Me.cboCaja.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCaja.DisplayMember = "sDescripcionCaja"
        Me.cboCaja.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCaja.DropDownWidth = 386
        Me.cboCaja.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCaja.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaja.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCaja.EditorHeight = 15
        Me.cboCaja.EvenRowStyle = Style10
        Me.cboCaja.ExtendRightColumn = True
        Me.cboCaja.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCaja.FooterStyle = Style11
        Me.cboCaja.GapHeight = 2
        Me.cboCaja.HeadingStyle = Style12
        Me.cboCaja.HighLightRowStyle = Style13
        Me.cboCaja.Images.Add(CType(resources.GetObject("cboCaja.Images"), System.Drawing.Image))
        Me.cboCaja.ItemHeight = 15
        Me.cboCaja.LimitToList = True
        Me.cboCaja.Location = New System.Drawing.Point(126, 30)
        Me.cboCaja.MatchEntryTimeout = CType(2000, Long)
        Me.cboCaja.MaxDropDownItems = CType(5, Short)
        Me.cboCaja.MaxLength = 32767
        Me.cboCaja.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCaja.Name = "cboCaja"
        Me.cboCaja.OddRowStyle = Style14
        Me.cboCaja.PartialRightColumn = False
        Me.cboCaja.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCaja.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCaja.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCaja.SelectedStyle = Style15
        Me.cboCaja.Size = New System.Drawing.Size(392, 21)
        Me.cboCaja.Style = Style16
        Me.cboCaja.SuperBack = True
        Me.cboCaja.TabIndex = 118
        Me.cboCaja.PropBag = resources.GetString("cboCaja.PropBag")
        '
        'CmbRefrescarUnidar
        '
        Me.CmbRefrescarUnidar.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.CmbRefrescarUnidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbRefrescarUnidar.Location = New System.Drawing.Point(243, 109)
        Me.CmbRefrescarUnidar.Name = "CmbRefrescarUnidar"
        Me.CmbRefrescarUnidar.Size = New System.Drawing.Size(83, 25)
        Me.CmbRefrescarUnidar.TabIndex = 126
        Me.CmbRefrescarUnidar.Tag = ""
        Me.CmbRefrescarUnidar.Text = "Listar USB"
        Me.CmbRefrescarUnidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbRefrescarUnidar.UseVisualStyleBackColor = True
        '
        'lblRepresentante
        '
        Me.lblRepresentante.AutoSize = True
        Me.lblRepresentante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblRepresentante.Location = New System.Drawing.Point(6, 38)
        Me.lblRepresentante.Name = "lblRepresentante"
        Me.lblRepresentante.Size = New System.Drawing.Size(31, 13)
        Me.lblRepresentante.TabIndex = 119
        Me.lblRepresentante.Text = "Caja:"
        '
        'cboUnidad
        '
        Me.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidad.FormattingEnabled = True
        Me.cboUnidad.Location = New System.Drawing.Point(126, 89)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(111, 21)
        Me.cboUnidad.TabIndex = 125
        '
        'CmbCargarArchivo
        '
        Me.CmbCargarArchivo.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.CmbCargarArchivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbCargarArchivo.Location = New System.Drawing.Point(329, 110)
        Me.CmbCargarArchivo.Name = "CmbCargarArchivo"
        Me.CmbCargarArchivo.Size = New System.Drawing.Size(82, 24)
        Me.CmbCargarArchivo.TabIndex = 120
        Me.CmbCargarArchivo.Text = "Buscar Archivo"
        Me.CmbCargarArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbCargarArchivo.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 97)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Unidad Destino"
        '
        'LblArchivoAbierto
        '
        Me.LblArchivoAbierto.AutoSize = True
        Me.LblArchivoAbierto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblArchivoAbierto.Location = New System.Drawing.Point(6, 68)
        Me.LblArchivoAbierto.Name = "LblArchivoAbierto"
        Me.LblArchivoAbierto.Size = New System.Drawing.Size(107, 13)
        Me.LblArchivoAbierto.TabIndex = 121
        Me.LblArchivoAbierto.Text = "Archivo a Cargar Zip:"
        '
        'CmbCargarBase
        '
        Me.CmbCargarBase.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.CmbCargarBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbCargarBase.Location = New System.Drawing.Point(426, 111)
        Me.CmbCargarBase.Name = "CmbCargarBase"
        Me.CmbCargarBase.Size = New System.Drawing.Size(92, 23)
        Me.CmbCargarBase.TabIndex = 123
        Me.CmbCargarBase.Text = "Cargar Base"
        Me.CmbCargarBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbCargarBase.UseVisualStyleBackColor = True
        '
        'TxtArchivoAbierto
        '
        Me.TxtArchivoAbierto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtArchivoAbierto.Enabled = False
        Me.TxtArchivoAbierto.Location = New System.Drawing.Point(126, 61)
        Me.TxtArchivoAbierto.Name = "TxtArchivoAbierto"
        Me.TxtArchivoAbierto.Size = New System.Drawing.Size(392, 20)
        Me.TxtArchivoAbierto.TabIndex = 122
        '
        'grpPresentaProceso
        '
        Me.grpPresentaProceso.Controls.Add(Me.lBlProcesoBaseFinal)
        Me.grpPresentaProceso.Controls.Add(Me.lBlProcesando)
        Me.grpPresentaProceso.Controls.Add(Me.lBlProcesoBaseTmp)
        Me.grpPresentaProceso.Controls.Add(Me.lBlProcesoZip)
        Me.grpPresentaProceso.Controls.Add(Me.ChkCopiarFinal)
        Me.grpPresentaProceso.Controls.Add(Me.PrBarProceso)
        Me.grpPresentaProceso.Controls.Add(Me.ChkCopiarTmp)
        Me.grpPresentaProceso.Controls.Add(Me.ChkUnZip)
        Me.grpPresentaProceso.Location = New System.Drawing.Point(1, 9)
        Me.grpPresentaProceso.Name = "grpPresentaProceso"
        Me.grpPresentaProceso.Size = New System.Drawing.Size(672, 131)
        Me.grpPresentaProceso.TabIndex = 129
        Me.grpPresentaProceso.TabStop = False
        '
        'lBlProcesoBaseFinal
        '
        Me.lBlProcesoBaseFinal.AutoSize = True
        Me.lBlProcesoBaseFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lBlProcesoBaseFinal.Location = New System.Drawing.Point(118, 62)
        Me.lBlProcesoBaseFinal.Name = "lBlProcesoBaseFinal"
        Me.lBlProcesoBaseFinal.Size = New System.Drawing.Size(62, 13)
        Me.lBlProcesoBaseFinal.TabIndex = 62
        Me.lBlProcesoBaseFinal.Text = "Copiar Final"
        '
        'lBlProcesando
        '
        Me.lBlProcesando.AutoSize = True
        Me.lBlProcesando.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lBlProcesando.Location = New System.Drawing.Point(325, 78)
        Me.lBlProcesando.Name = "lBlProcesando"
        Me.lBlProcesando.Size = New System.Drawing.Size(85, 13)
        Me.lBlProcesando.TabIndex = 44
        Me.lBlProcesando.Text = "Procesando......."
        '
        'lBlProcesoBaseTmp
        '
        Me.lBlProcesoBaseTmp.AutoSize = True
        Me.lBlProcesoBaseTmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lBlProcesoBaseTmp.Location = New System.Drawing.Point(118, 42)
        Me.lBlProcesoBaseTmp.Name = "lBlProcesoBaseTmp"
        Me.lBlProcesoBaseTmp.Size = New System.Drawing.Size(84, 13)
        Me.lBlProcesoBaseTmp.TabIndex = 61
        Me.lBlProcesoBaseTmp.Text = "Copiar TMP......."
        '
        'lBlProcesoZip
        '
        Me.lBlProcesoZip.AutoSize = True
        Me.lBlProcesoZip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lBlProcesoZip.Location = New System.Drawing.Point(117, 21)
        Me.lBlProcesoZip.Name = "lBlProcesoZip"
        Me.lBlProcesoZip.Size = New System.Drawing.Size(85, 13)
        Me.lBlProcesoZip.TabIndex = 45
        Me.lBlProcesoZip.Text = "Procesando......."
        '
        'ChkCopiarFinal
        '
        Me.ChkCopiarFinal.AutoSize = True
        Me.ChkCopiarFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ChkCopiarFinal.Location = New System.Drawing.Point(15, 61)
        Me.ChkCopiarFinal.Name = "ChkCopiarFinal"
        Me.ChkCopiarFinal.Size = New System.Drawing.Size(79, 17)
        Me.ChkCopiarFinal.TabIndex = 60
        Me.ChkCopiarFinal.Text = "Carga Final"
        Me.ChkCopiarFinal.UseVisualStyleBackColor = True
        '
        'PrBarProceso
        '
        Me.PrBarProceso.Location = New System.Drawing.Point(15, 94)
        Me.PrBarProceso.Name = "PrBarProceso"
        Me.PrBarProceso.Size = New System.Drawing.Size(638, 20)
        Me.PrBarProceso.TabIndex = 57
        '
        'ChkCopiarTmp
        '
        Me.ChkCopiarTmp.AutoSize = True
        Me.ChkCopiarTmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ChkCopiarTmp.Location = New System.Drawing.Point(15, 41)
        Me.ChkCopiarTmp.Name = "ChkCopiarTmp"
        Me.ChkCopiarTmp.Size = New System.Drawing.Size(97, 17)
        Me.ChkCopiarTmp.TabIndex = 59
        Me.ChkCopiarTmp.Text = "Base Temporal"
        Me.ChkCopiarTmp.UseVisualStyleBackColor = True
        '
        'ChkUnZip
        '
        Me.ChkUnZip.AutoSize = True
        Me.ChkUnZip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ChkUnZip.Location = New System.Drawing.Point(15, 21)
        Me.ChkUnZip.Name = "ChkUnZip"
        Me.ChkUnZip.Size = New System.Drawing.Size(80, 17)
        Me.ChkUnZip.TabIndex = 58
        Me.ChkUnZip.Text = "Archivo Zip"
        Me.ChkUnZip.UseVisualStyleBackColor = True
        '
        'DirUnidadBDLocal
        '
        '
        'FrmSccCarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 535)
        Me.Controls.Add(Me.GrpBPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSccCarga"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga de la Base de Datos"
        Me.GrpBPrincipal.ResumeLayout(False)
        Me.GrpReiniciar.ResumeLayout(False)
        Me.GrpReiniciar.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridGenerados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGenera.ResumeLayout(False)
        Me.grpGenera.PerformLayout()
        Me.grpTipoBase.ResumeLayout(False)
        Me.grpTipoBase.PerformLayout()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPresentaProceso.ResumeLayout(False)
        Me.grpPresentaProceso.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ArchivoLocacion As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GrpBPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents lBlProcesoBaseFinal As System.Windows.Forms.Label
    Friend WithEvents lBlProcesoBaseTmp As System.Windows.Forms.Label
    Friend WithEvents ChkCopiarFinal As System.Windows.Forms.CheckBox
    Friend WithEvents ChkCopiarTmp As System.Windows.Forms.CheckBox
    Friend WithEvents ChkUnZip As System.Windows.Forms.CheckBox
    Friend WithEvents PrBarProceso As System.Windows.Forms.ProgressBar
    Friend WithEvents lBlProcesoZip As System.Windows.Forms.Label
    Friend WithEvents lBlProcesando As System.Windows.Forms.Label
    Friend WithEvents CmbRefrescarUnidar As System.Windows.Forms.Button
    Friend WithEvents cboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbCargarBase As System.Windows.Forms.Button
    Friend WithEvents TxtArchivoAbierto As System.Windows.Forms.TextBox
    Friend WithEvents LblArchivoAbierto As System.Windows.Forms.Label
    Friend WithEvents CmbCargarArchivo As System.Windows.Forms.Button
    Friend WithEvents cboCaja As C1.Win.C1List.C1Combo
    Friend WithEvents lblRepresentante As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents gridGenerados As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents RadCentral As System.Windows.Forms.RadioButton
    Friend WithEvents RadLocal As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdReporteDuplicados As System.Windows.Forms.Button
    Friend WithEvents CmdReporteDuplicadosCentral As System.Windows.Forms.Button
    Friend WithEvents grpGenera As System.Windows.Forms.GroupBox
    Friend WithEvents grpPresentaProceso As System.Windows.Forms.GroupBox
    Friend WithEvents grpTipoBase As System.Windows.Forms.GroupBox
    Friend WithEvents DirUnidadBDLocal As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CmbAplicarCarga As System.Windows.Forms.Button
    Friend WithEvents CmbReiniciarContador As System.Windows.Forms.Button
    Friend WithEvents CmbCancelarReinicio As System.Windows.Forms.Button
    Friend WithEvents CmbAplicarReinico As System.Windows.Forms.Button
    Friend WithEvents TxtMotivoReinicio As System.Windows.Forms.TextBox
    Friend WithEvents GrpReiniciar As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
