<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnBusquedaComprobantes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnBusquedaComprobantes))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpBusquedaGe = New System.Windows.Forms.GroupBox
        Me.grpNumero = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpMinuta = New System.Windows.Forms.GroupBox
        Me.txtNumero = New System.Windows.Forms.TextBox
        Me.lblNumero = New System.Windows.Forms.Label
        Me.cboMinuta = New C1.Win.C1List.C1Combo
        Me.lblMinuta = New System.Windows.Forms.Label
        Me.GrpFechasCorte = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaHasta = New System.Windows.Forms.Label
        Me.lblFechaDesde = New System.Windows.Forms.Label
        Me.errBusqueda = New System.Windows.Forms.ErrorProvider(Me.components)
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
        Me.radNumero = New System.Windows.Forms.RadioButton
        Me.radFechas = New System.Windows.Forms.RadioButton
        Me.radMinuta = New System.Windows.Forms.RadioButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.txtNumeroCD = New System.Windows.Forms.TextBox
        Me.grpBusquedaGe.SuspendLayout()
        Me.grpNumero.SuspendLayout()
        Me.GrpMinuta.SuspendLayout()
        CType(Me.cboMinuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFechasCorte.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBotones.SuspendLayout()
        Me.grpTipoRpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpBusquedaGe
        '
        Me.grpBusquedaGe.Controls.Add(Me.grpNumero)
        Me.grpBusquedaGe.Controls.Add(Me.GrpMinuta)
        Me.grpBusquedaGe.Controls.Add(Me.GrpFechasCorte)
        Me.grpBusquedaGe.Location = New System.Drawing.Point(15, 82)
        Me.grpBusquedaGe.Name = "grpBusquedaGe"
        Me.grpBusquedaGe.Size = New System.Drawing.Size(470, 253)
        Me.grpBusquedaGe.TabIndex = 0
        Me.grpBusquedaGe.TabStop = False
        Me.grpBusquedaGe.Text = "Ingrese Datos Búsqueda:"
        '
        'grpNumero
        '
        Me.grpNumero.Controls.Add(Me.txtNumeroCD)
        Me.grpNumero.Controls.Add(Me.Label1)
        Me.grpNumero.Location = New System.Drawing.Point(16, 178)
        Me.grpNumero.Name = "grpNumero"
        Me.grpNumero.Size = New System.Drawing.Size(445, 62)
        Me.grpNumero.TabIndex = 52
        Me.grpNumero.TabStop = False
        Me.grpNumero.Text = "Número Comprobante:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Número Comprobante:"
        '
        'GrpMinuta
        '
        Me.GrpMinuta.Controls.Add(Me.txtNumero)
        Me.GrpMinuta.Controls.Add(Me.lblNumero)
        Me.GrpMinuta.Controls.Add(Me.cboMinuta)
        Me.GrpMinuta.Controls.Add(Me.lblMinuta)
        Me.GrpMinuta.Location = New System.Drawing.Point(16, 19)
        Me.GrpMinuta.Name = "GrpMinuta"
        Me.GrpMinuta.Size = New System.Drawing.Size(445, 88)
        Me.GrpMinuta.TabIndex = 51
        Me.GrpMinuta.TabStop = False
        Me.GrpMinuta.Text = "Minuta Depósito:"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumero.Enabled = False
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = New System.Drawing.Point(127, 52)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(302, 20)
        Me.txtNumero.TabIndex = 35
        Me.txtNumero.Tag = "LAYOUT:FLAT"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumero.Location = New System.Drawing.Point(9, 55)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(113, 13)
        Me.lblNumero.TabIndex = 34
        Me.lblNumero.Text = "Número Comprobante:"
        '
        'cboMinuta
        '
        Me.cboMinuta.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMinuta.AutoCompletion = True
        Me.cboMinuta.Caption = ""
        Me.cboMinuta.CaptionHeight = 17
        Me.cboMinuta.CaptionStyle = Style1
        Me.cboMinuta.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMinuta.ColumnCaptionHeight = 17
        Me.cboMinuta.ColumnFooterHeight = 17
        Me.cboMinuta.ContentHeight = 15
        Me.cboMinuta.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMinuta.DisplayMember = "sNumeroDeposito"
        Me.cboMinuta.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMinuta.DropDownWidth = 302
        Me.cboMinuta.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMinuta.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMinuta.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMinuta.EditorHeight = 15
        Me.cboMinuta.EvenRowStyle = Style2
        Me.cboMinuta.ExtendRightColumn = True
        Me.cboMinuta.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMinuta.FooterStyle = Style3
        Me.cboMinuta.GapHeight = 2
        Me.cboMinuta.HeadingStyle = Style4
        Me.cboMinuta.HighLightRowStyle = Style5
        Me.cboMinuta.Images.Add(CType(resources.GetObject("cboMinuta.Images"), System.Drawing.Image))
        Me.cboMinuta.ItemHeight = 15
        Me.cboMinuta.LimitToList = True
        Me.cboMinuta.Location = New System.Drawing.Point(127, 19)
        Me.cboMinuta.MatchEntryTimeout = CType(2000, Long)
        Me.cboMinuta.MaxDropDownItems = CType(5, Short)
        Me.cboMinuta.MaxLength = 32767
        Me.cboMinuta.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMinuta.Name = "cboMinuta"
        Me.cboMinuta.OddRowStyle = Style6
        Me.cboMinuta.PartialRightColumn = False
        Me.cboMinuta.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMinuta.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMinuta.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMinuta.SelectedStyle = Style7
        Me.cboMinuta.Size = New System.Drawing.Size(302, 21)
        Me.cboMinuta.Style = Style8
        Me.cboMinuta.SuperBack = True
        Me.cboMinuta.TabIndex = 33
        Me.cboMinuta.ValueMember = "nSteMinutaDepositoID"
        Me.cboMinuta.PropBag = resources.GetString("cboMinuta.PropBag")
        '
        'lblMinuta
        '
        Me.lblMinuta.AutoSize = True
        Me.lblMinuta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMinuta.Location = New System.Drawing.Point(9, 22)
        Me.lblMinuta.Name = "lblMinuta"
        Me.lblMinuta.Size = New System.Drawing.Size(87, 13)
        Me.lblMinuta.TabIndex = 32
        Me.lblMinuta.Text = "Minuta Depósito:"
        '
        'GrpFechasCorte
        '
        Me.GrpFechasCorte.Controls.Add(Me.cdeFechaH)
        Me.GrpFechasCorte.Controls.Add(Me.cdeFechaD)
        Me.GrpFechasCorte.Controls.Add(Me.lblFechaHasta)
        Me.GrpFechasCorte.Controls.Add(Me.lblFechaDesde)
        Me.GrpFechasCorte.Location = New System.Drawing.Point(16, 113)
        Me.GrpFechasCorte.Name = "GrpFechasCorte"
        Me.GrpFechasCorte.Size = New System.Drawing.Size(445, 59)
        Me.GrpFechasCorte.TabIndex = 42
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
        Me.cdeFechaH.Location = New System.Drawing.Point(327, 23)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 45
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
        Me.cdeFechaD.Location = New System.Drawing.Point(127, 23)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 44
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaHasta.Location = New System.Drawing.Point(245, 26)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(71, 13)
        Me.lblFechaHasta.TabIndex = 43
        Me.lblFechaHasta.Text = "Fecha Hasta:"
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaDesde.Location = New System.Drawing.Point(7, 30)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaDesde.TabIndex = 41
        Me.lblFechaDesde.Text = "Fecha Desde:"
        '
        'errBusqueda
        '
        Me.errBusqueda.ContainerControl = Me
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(15, 372)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(473, 50)
        Me.grpBotones.TabIndex = 10
        Me.grpBotones.TabStop = False
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(198, 23)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(0, 13)
        Me.LblConteo.TabIndex = 2
        '
        'cmdUltimo
        '
        Me.cmdUltimo.Image = Global.SMUSURA0.My.Resources.Resources.player_end
        Me.cmdUltimo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUltimo.Location = New System.Drawing.Point(391, 17)
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
        Me.cmdSiguiente.Location = New System.Drawing.Point(312, 17)
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
        Me.cmdBuscar.Location = New System.Drawing.Point(261, 341)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(415, 341)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(338, 341)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'grpTipoRpt
        '
        Me.grpTipoRpt.Controls.Add(Me.radNumero)
        Me.grpTipoRpt.Controls.Add(Me.radFechas)
        Me.grpTipoRpt.Controls.Add(Me.radMinuta)
        Me.grpTipoRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoRpt.ForeColor = System.Drawing.Color.Black
        Me.grpTipoRpt.Location = New System.Drawing.Point(117, 8)
        Me.grpTipoRpt.Name = "grpTipoRpt"
        Me.grpTipoRpt.Size = New System.Drawing.Size(283, 68)
        Me.grpTipoRpt.TabIndex = 69
        Me.grpTipoRpt.TabStop = False
        Me.grpTipoRpt.Text = "Seleccione Tipo de Búsqueda:"
        '
        'radNumero
        '
        Me.radNumero.AutoSize = True
        Me.radNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radNumero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radNumero.Location = New System.Drawing.Point(151, 19)
        Me.radNumero.Name = "radNumero"
        Me.radNumero.Size = New System.Drawing.Size(128, 17)
        Me.radNumero.TabIndex = 2
        Me.radNumero.Text = "Número Comprobante"
        Me.radNumero.UseVisualStyleBackColor = True
        '
        'radFechas
        '
        Me.radFechas.AutoSize = True
        Me.radFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radFechas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radFechas.Location = New System.Drawing.Point(23, 45)
        Me.radFechas.Name = "radFechas"
        Me.radFechas.Size = New System.Drawing.Size(103, 17)
        Me.radFechas.TabIndex = 1
        Me.radFechas.Text = "Fechas de Corte"
        Me.radFechas.UseVisualStyleBackColor = True
        '
        'radMinuta
        '
        Me.radMinuta.AutoSize = True
        Me.radMinuta.Checked = True
        Me.radMinuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radMinuta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radMinuta.Location = New System.Drawing.Point(23, 19)
        Me.radMinuta.Name = "radMinuta"
        Me.radMinuta.Size = New System.Drawing.Size(102, 17)
        Me.radMinuta.TabIndex = 0
        Me.radMinuta.TabStop = True
        Me.radMinuta.Text = "Minuta Depósito"
        Me.radMinuta.UseVisualStyleBackColor = True
        '
        'txtNumeroCD
        '
        Me.txtNumeroCD.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroCD.Location = New System.Drawing.Point(127, 25)
        Me.txtNumeroCD.Name = "txtNumeroCD"
        Me.txtNumeroCD.Size = New System.Drawing.Size(193, 20)
        Me.txtNumeroCD.TabIndex = 36
        '
        'frmScnBusquedaComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 434)
        Me.Controls.Add(Me.grpTipoRpt)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpBusquedaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Comprobantes de Diario")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnBusquedaComprobantes"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Datos de Búsqueda de Comprobantes de Diario:"
        Me.grpBusquedaGe.ResumeLayout(False)
        Me.grpNumero.ResumeLayout(False)
        Me.grpNumero.PerformLayout()
        Me.GrpMinuta.ResumeLayout(False)
        Me.GrpMinuta.PerformLayout()
        CType(Me.cboMinuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFechasCorte.ResumeLayout(False)
        Me.GrpFechasCorte.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.grpTipoRpt.ResumeLayout(False)
        Me.grpTipoRpt.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpBusquedaGe As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errBusqueda As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpFechasCorte As System.Windows.Forms.GroupBox
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents grpTipoRpt As System.Windows.Forms.GroupBox
    Friend WithEvents radFechas As System.Windows.Forms.RadioButton
    Friend WithEvents radMinuta As System.Windows.Forms.RadioButton
    Friend WithEvents GrpMinuta As System.Windows.Forms.GroupBox
    Friend WithEvents lblMinuta As System.Windows.Forms.Label
    Friend WithEvents cboMinuta As C1.Win.C1List.C1Combo
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents radNumero As System.Windows.Forms.RadioButton
    Friend WithEvents grpNumero As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNumeroCD As System.Windows.Forms.TextBox
End Class
