<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccBusquedaNotasDebitoCredito
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccBusquedaNotasDebitoCredito))
        Me.lblNombreSocia = New System.Windows.Forms.Label()
        Me.LblConteo = New System.Windows.Forms.Label()
        Me.grpTipoRpt = New System.Windows.Forms.GroupBox()
        Me.rdoAño = New System.Windows.Forms.RadioButton()
        Me.RadFechas = New System.Windows.Forms.RadioButton()
        Me.RadCodigoGrupo = New System.Windows.Forms.RadioButton()
        Me.radSesion = New System.Windows.Forms.RadioButton()
        Me.RadCodigoFNC = New System.Windows.Forms.RadioButton()
        Me.RadCodigo = New System.Windows.Forms.RadioButton()
        Me.RadGrupo = New System.Windows.Forms.RadioButton()
        Me.radCedula = New System.Windows.Forms.RadioButton()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.cmdUltimo = New System.Windows.Forms.Button()
        Me.cmdSiguiente = New System.Windows.Forms.Button()
        Me.CmdAnterior = New System.Windows.Forms.Button()
        Me.CmdPrimero = New System.Windows.Forms.Button()
        Me.errSolicitud = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.txtNombreSocia = New System.Windows.Forms.TextBox()
        Me.grpSociaGe = New System.Windows.Forms.GroupBox()
        Me.grpAño = New System.Windows.Forms.GroupBox()
        Me.CboMeses = New C1.Win.C1List.C1Combo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ndAño = New System.Windows.Forms.NumericUpDown()
        Me.GrpFechasCorte = New System.Windows.Forms.GroupBox()
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit()
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaHasta = New System.Windows.Forms.Label()
        Me.lblFechaDesde = New System.Windows.Forms.Label()
        Me.GrpCodigos = New System.Windows.Forms.GroupBox()
        Me.mtbNumeroSesion = New System.Windows.Forms.MaskedTextBox()
        Me.lblSesion = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtCodigoFNC = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblCodigoSolicitud = New System.Windows.Forms.Label()
        Me.GrpGrupoSolidario = New System.Windows.Forms.GroupBox()
        Me.txtGrupoSolidario = New System.Windows.Forms.TextBox()
        Me.lblGrupoSolidario = New System.Windows.Forms.Label()
        Me.TxtNombreGrupo = New System.Windows.Forms.TextBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.GrpCedulaSocia = New System.Windows.Forms.GroupBox()
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.grpTipoRpt.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        CType(Me.errSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSociaGe.SuspendLayout()
        Me.grpAño.SuspendLayout()
        CType(Me.CboMeses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ndAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFechasCorte.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCodigos.SuspendLayout()
        Me.GrpGrupoSolidario.SuspendLayout()
        Me.GrpCedulaSocia.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(7, 48)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(105, 13)
        Me.lblNombreSocia.TabIndex = 50
        Me.lblNombreSocia.Text = "Nombre Beneficiario:"
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
        'grpTipoRpt
        '
        Me.grpTipoRpt.Controls.Add(Me.rdoAño)
        Me.grpTipoRpt.Controls.Add(Me.RadFechas)
        Me.grpTipoRpt.Controls.Add(Me.RadCodigoGrupo)
        Me.grpTipoRpt.Controls.Add(Me.radSesion)
        Me.grpTipoRpt.Controls.Add(Me.RadCodigoFNC)
        Me.grpTipoRpt.Controls.Add(Me.RadCodigo)
        Me.grpTipoRpt.Controls.Add(Me.RadGrupo)
        Me.grpTipoRpt.Controls.Add(Me.radCedula)
        Me.grpTipoRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoRpt.ForeColor = System.Drawing.Color.Black
        Me.grpTipoRpt.Location = New System.Drawing.Point(12, 12)
        Me.grpTipoRpt.Name = "grpTipoRpt"
        Me.grpTipoRpt.Size = New System.Drawing.Size(583, 68)
        Me.grpTipoRpt.TabIndex = 13
        Me.grpTipoRpt.TabStop = False
        Me.grpTipoRpt.Text = "Seleccione Tipo de Búsqueda:"
        '
        'rdoAño
        '
        Me.rdoAño.AutoSize = True
        Me.rdoAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoAño.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.rdoAño.Location = New System.Drawing.Point(460, 42)
        Me.rdoAño.Name = "rdoAño"
        Me.rdoAño.Size = New System.Drawing.Size(44, 17)
        Me.rdoAño.TabIndex = 8
        Me.rdoAño.Text = "Año"
        Me.rdoAño.UseVisualStyleBackColor = True
        '
        'RadFechas
        '
        Me.RadFechas.AutoSize = True
        Me.RadFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadFechas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadFechas.Location = New System.Drawing.Point(460, 19)
        Me.RadFechas.Name = "RadFechas"
        Me.RadFechas.Size = New System.Drawing.Size(86, 17)
        Me.RadFechas.TabIndex = 7
        Me.RadFechas.Text = "Fechas Nota"
        Me.RadFechas.UseVisualStyleBackColor = True
        '
        'RadCodigoGrupo
        '
        Me.RadCodigoGrupo.AutoSize = True
        Me.RadCodigoGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCodigoGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCodigoGrupo.Location = New System.Drawing.Point(294, 22)
        Me.RadCodigoGrupo.Name = "RadCodigoGrupo"
        Me.RadCodigoGrupo.Size = New System.Drawing.Size(133, 17)
        Me.RadCodigoGrupo.TabIndex = 6
        Me.RadCodigoGrupo.Text = "Código Grupo Solidario"
        Me.RadCodigoGrupo.UseVisualStyleBackColor = True
        '
        'radSesion
        '
        Me.radSesion.AutoSize = True
        Me.radSesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSesion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radSesion.Location = New System.Drawing.Point(294, 45)
        Me.radSesion.Name = "radSesion"
        Me.radSesion.Size = New System.Drawing.Size(154, 17)
        Me.radSesion.TabIndex = 5
        Me.radSesion.Text = "Número Resolución Crédito"
        Me.radSesion.UseVisualStyleBackColor = True
        '
        'RadCodigoFNC
        '
        Me.RadCodigoFNC.AutoSize = True
        Me.RadCodigoFNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCodigoFNC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCodigoFNC.Location = New System.Drawing.Point(142, 45)
        Me.RadCodigoFNC.Name = "RadCodigoFNC"
        Me.RadCodigoFNC.Size = New System.Drawing.Size(87, 17)
        Me.RadCodigoFNC.TabIndex = 4
        Me.RadCodigoFNC.Text = "Código Ficha"
        Me.RadCodigoFNC.UseVisualStyleBackColor = True
        '
        'RadCodigo
        '
        Me.RadCodigo.AutoSize = True
        Me.RadCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCodigo.Location = New System.Drawing.Point(30, 45)
        Me.RadCodigo.Name = "RadCodigo"
        Me.RadCodigo.Size = New System.Drawing.Size(84, 17)
        Me.RadCodigo.TabIndex = 3
        Me.RadCodigo.Text = "Código Nota"
        Me.RadCodigo.UseVisualStyleBackColor = True
        '
        'RadGrupo
        '
        Me.RadGrupo.AutoSize = True
        Me.RadGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadGrupo.Location = New System.Drawing.Point(142, 22)
        Me.RadGrupo.Name = "RadGrupo"
        Me.RadGrupo.Size = New System.Drawing.Size(137, 17)
        Me.RadGrupo.TabIndex = 1
        Me.RadGrupo.Text = "Nombre Grupo Solidario"
        Me.RadGrupo.UseVisualStyleBackColor = True
        '
        'radCedula
        '
        Me.radCedula.AutoSize = True
        Me.radCedula.Checked = True
        Me.radCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radCedula.Location = New System.Drawing.Point(30, 22)
        Me.radCedula.Name = "radCedula"
        Me.radCedula.Size = New System.Drawing.Size(88, 17)
        Me.radCedula.TabIndex = 0
        Me.radCedula.TabStop = True
        Me.radCedula.Text = "Cédula Socia"
        Me.radCedula.UseVisualStyleBackColor = True
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(12, 519)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(583, 47)
        Me.grpBotones.TabIndex = 16
        Me.grpBotones.TabStop = False
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
        'errSolicitud
        '
        Me.errSolicitud.ContainerControl = Me
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
        Me.txtNombreSocia.TabIndex = 1
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.grpAño)
        Me.grpSociaGe.Controls.Add(Me.GrpFechasCorte)
        Me.grpSociaGe.Controls.Add(Me.GrpCodigos)
        Me.grpSociaGe.Controls.Add(Me.GrpGrupoSolidario)
        Me.grpSociaGe.Controls.Add(Me.GrpCedulaSocia)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 86)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(583, 396)
        Me.grpSociaGe.TabIndex = 12
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Ingrese Datos Búsqueda:"
        '
        'grpAño
        '
        Me.grpAño.Controls.Add(Me.CboMeses)
        Me.grpAño.Controls.Add(Me.Label2)
        Me.grpAño.Controls.Add(Me.Label1)
        Me.grpAño.Controls.Add(Me.ndAño)
        Me.grpAño.Location = New System.Drawing.Point(299, 315)
        Me.grpAño.Name = "grpAño"
        Me.grpAño.Size = New System.Drawing.Size(271, 75)
        Me.grpAño.TabIndex = 55
        Me.grpAño.TabStop = False
        Me.grpAño.Text = "Año:"
        '
        'CboMeses
        '
        Me.CboMeses.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboMeses.AutoCompletion = True
        Me.CboMeses.Caption = ""
        Me.CboMeses.CaptionHeight = 17
        Me.CboMeses.CaptionStyle = Style1
        Me.CboMeses.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboMeses.ColumnCaptionHeight = 17
        Me.CboMeses.ColumnFooterHeight = 17
        Me.CboMeses.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CboMeses.ContentHeight = 15
        Me.CboMeses.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.CboMeses.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboMeses.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboMeses.DropDownWidth = 188
        Me.CboMeses.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboMeses.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMeses.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboMeses.EditorHeight = 15
        Me.CboMeses.EvenRowStyle = Style2
        Me.CboMeses.ExtendRightColumn = True
        Me.CboMeses.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboMeses.FooterStyle = Style3
        Me.CboMeses.GapHeight = 2
        Me.CboMeses.HeadingStyle = Style4
        Me.CboMeses.HighLightRowStyle = Style5
        Me.CboMeses.Images.Add(CType(resources.GetObject("CboMeses.Images"), System.Drawing.Image))
        Me.CboMeses.ItemHeight = 15
        Me.CboMeses.LimitToList = True
        Me.CboMeses.Location = New System.Drawing.Point(42, 46)
        Me.CboMeses.MatchEntryTimeout = CType(2000, Long)
        Me.CboMeses.MaxDropDownItems = CType(5, Short)
        Me.CboMeses.MaxLength = 32767
        Me.CboMeses.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboMeses.Name = "CboMeses"
        Me.CboMeses.OddRowStyle = Style6
        Me.CboMeses.PartialRightColumn = False
        Me.CboMeses.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboMeses.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboMeses.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboMeses.SelectedStyle = Style7
        Me.CboMeses.Size = New System.Drawing.Size(190, 21)
        Me.CboMeses.Style = Style8
        Me.CboMeses.SuperBack = True
        Me.CboMeses.TabIndex = 47
        Me.CboMeses.ValueMember = "StbValorCatalogoID"
        Me.CboMeses.PropBag = resources.GetString("CboMeses.PropBag")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Mes:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Año de Nota:"
        '
        'ndAño
        '
        Me.ndAño.Location = New System.Drawing.Point(81, 12)
        Me.ndAño.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.ndAño.Minimum = New Decimal(New Integer() {2007, 0, 0, 0})
        Me.ndAño.Name = "ndAño"
        Me.ndAño.Size = New System.Drawing.Size(120, 20)
        Me.ndAño.TabIndex = 0
        Me.ndAño.Value = New Decimal(New Integer() {2007, 0, 0, 0})
        '
        'GrpFechasCorte
        '
        Me.GrpFechasCorte.Controls.Add(Me.cdeFechaH)
        Me.GrpFechasCorte.Controls.Add(Me.cdeFechaD)
        Me.GrpFechasCorte.Controls.Add(Me.lblFechaHasta)
        Me.GrpFechasCorte.Controls.Add(Me.lblFechaDesde)
        Me.GrpFechasCorte.Location = New System.Drawing.Point(16, 314)
        Me.GrpFechasCorte.Name = "GrpFechasCorte"
        Me.GrpFechasCorte.Size = New System.Drawing.Size(276, 78)
        Me.GrpFechasCorte.TabIndex = 54
        Me.GrpFechasCorte.TabStop = False
        Me.GrpFechasCorte.Text = "Fechas de Corte:"
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(126, 48)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(127, 20)
        Me.cdeFechaH.TabIndex = 1
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
        Me.cdeFechaD.Location = New System.Drawing.Point(127, 16)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(126, 20)
        Me.cdeFechaD.TabIndex = 0
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaHasta.Location = New System.Drawing.Point(12, 48)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(69, 13)
        Me.lblFechaHasta.TabIndex = 43
        Me.lblFechaHasta.Text = "Notas Hasta:"
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaDesde.Location = New System.Drawing.Point(12, 20)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(72, 13)
        Me.lblFechaDesde.TabIndex = 41
        Me.lblFechaDesde.Text = "Notas Desde:"
        '
        'GrpCodigos
        '
        Me.GrpCodigos.Controls.Add(Me.mtbNumeroSesion)
        Me.GrpCodigos.Controls.Add(Me.lblSesion)
        Me.GrpCodigos.Controls.Add(Me.txtCodigo)
        Me.GrpCodigos.Controls.Add(Me.txtCodigoFNC)
        Me.GrpCodigos.Controls.Add(Me.lblCodigo)
        Me.GrpCodigos.Controls.Add(Me.lblCodigoSolicitud)
        Me.GrpCodigos.Location = New System.Drawing.Point(16, 191)
        Me.GrpCodigos.Name = "GrpCodigos"
        Me.GrpCodigos.Size = New System.Drawing.Size(554, 117)
        Me.GrpCodigos.TabIndex = 52
        Me.GrpCodigos.TabStop = False
        Me.GrpCodigos.Text = "Códigos:"
        '
        'mtbNumeroSesion
        '
        Me.mtbNumeroSesion.Location = New System.Drawing.Point(126, 86)
        Me.mtbNumeroSesion.Mask = "00-000-0000"
        Me.mtbNumeroSesion.Name = "mtbNumeroSesion"
        Me.mtbNumeroSesion.Size = New System.Drawing.Size(127, 20)
        Me.mtbNumeroSesion.TabIndex = 2
        '
        'lblSesion
        '
        Me.lblSesion.AutoSize = True
        Me.lblSesion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSesion.Location = New System.Drawing.Point(9, 86)
        Me.lblSesion.Name = "lblSesion"
        Me.lblSesion.Size = New System.Drawing.Size(98, 13)
        Me.lblSesion.TabIndex = 36
        Me.lblSesion.Text = "No. de Resolución:"
        '
        'txtCodigo
        '
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(127, 16)
        Me.txtCodigo.MaxLength = 9
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(126, 20)
        Me.txtCodigo.TabIndex = 0
        '
        'txtCodigoFNC
        '
        Me.txtCodigoFNC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoFNC.Location = New System.Drawing.Point(126, 50)
        Me.txtCodigoFNC.MaxLength = 9
        Me.txtCodigoFNC.Name = "txtCodigoFNC"
        Me.txtCodigoFNC.Size = New System.Drawing.Size(127, 20)
        Me.txtCodigoFNC.TabIndex = 1
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(9, 50)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 13)
        Me.lblCodigo.TabIndex = 34
        Me.lblCodigo.Text = "Código de Ficha:"
        '
        'lblCodigoSolicitud
        '
        Me.lblCodigoSolicitud.AutoSize = True
        Me.lblCodigoSolicitud.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoSolicitud.Location = New System.Drawing.Point(9, 20)
        Me.lblCodigoSolicitud.Name = "lblCodigoSolicitud"
        Me.lblCodigoSolicitud.Size = New System.Drawing.Size(69, 13)
        Me.lblCodigoSolicitud.TabIndex = 32
        Me.lblCodigoSolicitud.Text = "Código Nota:"
        '
        'GrpGrupoSolidario
        '
        Me.GrpGrupoSolidario.Controls.Add(Me.txtGrupoSolidario)
        Me.GrpGrupoSolidario.Controls.Add(Me.lblGrupoSolidario)
        Me.GrpGrupoSolidario.Controls.Add(Me.TxtNombreGrupo)
        Me.GrpGrupoSolidario.Controls.Add(Me.lblGrupo)
        Me.GrpGrupoSolidario.Location = New System.Drawing.Point(16, 101)
        Me.GrpGrupoSolidario.Name = "GrpGrupoSolidario"
        Me.GrpGrupoSolidario.Size = New System.Drawing.Size(554, 84)
        Me.GrpGrupoSolidario.TabIndex = 52
        Me.GrpGrupoSolidario.TabStop = False
        Me.GrpGrupoSolidario.Text = "Nombre Grupo Solidario:"
        '
        'txtGrupoSolidario
        '
        Me.txtGrupoSolidario.BackColor = System.Drawing.SystemColors.Window
        Me.txtGrupoSolidario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupoSolidario.Location = New System.Drawing.Point(127, 56)
        Me.txtGrupoSolidario.Name = "txtGrupoSolidario"
        Me.txtGrupoSolidario.Size = New System.Drawing.Size(420, 20)
        Me.txtGrupoSolidario.TabIndex = 1
        Me.txtGrupoSolidario.Tag = "LAYOUT:FLAT"
        '
        'lblGrupoSolidario
        '
        Me.lblGrupoSolidario.AutoSize = True
        Me.lblGrupoSolidario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupoSolidario.Location = New System.Drawing.Point(9, 59)
        Me.lblGrupoSolidario.Name = "lblGrupoSolidario"
        Me.lblGrupoSolidario.Size = New System.Drawing.Size(82, 13)
        Me.lblGrupoSolidario.TabIndex = 49
        Me.lblGrupoSolidario.Text = "Grupo Solidario:"
        '
        'TxtNombreGrupo
        '
        Me.TxtNombreGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreGrupo.Location = New System.Drawing.Point(127, 23)
        Me.TxtNombreGrupo.Name = "TxtNombreGrupo"
        Me.TxtNombreGrupo.Size = New System.Drawing.Size(421, 20)
        Me.TxtNombreGrupo.TabIndex = 0
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupo.Location = New System.Drawing.Point(7, 26)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(122, 13)
        Me.lblGrupo.TabIndex = 41
        Me.lblGrupo.Text = "Nombre Grupo Solidario:"
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
        Me.GrpCedulaSocia.TabIndex = 51
        Me.GrpCedulaSocia.TabStop = False
        Me.GrpCedulaSocia.Text = "Cédula:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(127, 19)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 0
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(9, 22)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 32
        Me.lblCedula.Text = "Número Cédula:"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(362, 488)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 11
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(516, 488)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(439, 488)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 14
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmSccBusquedaNotasDebitoCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 567)
        Me.Controls.Add(Me.grpTipoRpt)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpSociaGe)
        Me.Name = "frmSccBusquedaNotasDebitoCredito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de Busqueda Nota de Debito Credito"
        Me.grpTipoRpt.ResumeLayout(False)
        Me.grpTipoRpt.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        CType(Me.errSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSociaGe.ResumeLayout(False)
        Me.grpAño.ResumeLayout(False)
        Me.grpAño.PerformLayout()
        CType(Me.CboMeses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ndAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFechasCorte.ResumeLayout(False)
        Me.GrpFechasCorte.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCodigos.ResumeLayout(False)
        Me.GrpCodigos.PerformLayout()
        Me.GrpGrupoSolidario.ResumeLayout(False)
        Me.GrpGrupoSolidario.PerformLayout()
        Me.GrpCedulaSocia.ResumeLayout(False)
        Me.GrpCedulaSocia.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents grpTipoRpt As System.Windows.Forms.GroupBox
    Friend WithEvents radSesion As System.Windows.Forms.RadioButton
    Friend WithEvents RadCodigoFNC As System.Windows.Forms.RadioButton
    Friend WithEvents RadCodigo As System.Windows.Forms.RadioButton
    Friend WithEvents RadGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents radCedula As System.Windows.Forms.RadioButton
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents errSolicitud As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents GrpCodigos As System.Windows.Forms.GroupBox
    Friend WithEvents mtbNumeroSesion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblSesion As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoFNC As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblCodigoSolicitud As System.Windows.Forms.Label
    Friend WithEvents GrpGrupoSolidario As System.Windows.Forms.GroupBox
    Friend WithEvents txtGrupoSolidario As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupoSolidario As System.Windows.Forms.Label
    Friend WithEvents TxtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents GrpCedulaSocia As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents RadCodigoGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents RadFechas As System.Windows.Forms.RadioButton
    Friend WithEvents GrpFechasCorte As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents rdoAño As System.Windows.Forms.RadioButton
    Friend WithEvents grpAño As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ndAño As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboMeses As C1.Win.C1List.C1Combo
End Class
