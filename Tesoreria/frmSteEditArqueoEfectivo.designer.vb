<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditArqueoEfectivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditArqueoEfectivo))
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tabArqueo = New C1.Win.C1Command.C1DockingTab
        Me.tabEfectivo = New C1.Win.C1Command.C1DockingTabPage
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.grdArqueoEfectivo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbArqueoEfectivo = New System.Windows.Forms.ToolStrip
        Me.toolAgregarC = New System.Windows.Forms.ToolStripButton
        Me.toolModificarC = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarE = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaE = New System.Windows.Forms.ToolStripButton
        Me.grpDatosGralesDS = New System.Windows.Forms.GroupBox
        Me.lblCajero = New System.Windows.Forms.Label
        Me.cboCajero = New C1.Win.C1List.C1Combo
        Me.cdeFecha = New C1.Win.C1Input.C1DateEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtEstadoAE = New System.Windows.Forms.TextBox
        Me.txtCodigoAE = New System.Windows.Forms.TextBox
        Me.lblEstadoAE = New System.Windows.Forms.Label
        Me.lblCodigoAE = New System.Windows.Forms.Label
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.errArqueo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.tabArqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabArqueo.SuspendLayout()
        Me.tabEfectivo.SuspendLayout()
        CType(Me.grdArqueoEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbArqueoEfectivo.SuspendLayout()
        Me.grpDatosGralesDS.SuspendLayout()
        CType(Me.cboCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errArqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabArqueo
        '
        Me.tabArqueo.BackColor = System.Drawing.SystemColors.Control
        Me.tabArqueo.Controls.Add(Me.tabEfectivo)
        Me.tabArqueo.Location = New System.Drawing.Point(12, 12)
        Me.tabArqueo.Name = "tabArqueo"
        Me.tabArqueo.SelectedIndex = 3
        Me.tabArqueo.Size = New System.Drawing.Size(753, 555)
        Me.tabArqueo.TabIndex = 0
        '
        'tabEfectivo
        '
        Me.tabEfectivo.Controls.Add(Me.cmdCancelar)
        Me.tabEfectivo.Controls.Add(Me.CmdAceptar)
        Me.tabEfectivo.Controls.Add(Me.grdArqueoEfectivo)
        Me.tabEfectivo.Controls.Add(Me.tbArqueoEfectivo)
        Me.tabEfectivo.Controls.Add(Me.grpDatosGralesDS)
        Me.tabEfectivo.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.tabEfectivo.Location = New System.Drawing.Point(1, 25)
        Me.tabEfectivo.Name = "tabEfectivo"
        Me.tabEfectivo.Size = New System.Drawing.Size(751, 529)
        Me.tabEfectivo.TabIndex = 2
        Me.tabEfectivo.Text = "Arqueo de Efectivo"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(665, 497)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 25
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(586, 497)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 24
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'grdArqueoEfectivo
        '
        Me.grdArqueoEfectivo.AllowFilter = False
        Me.grdArqueoEfectivo.AllowUpdate = False
        Me.grdArqueoEfectivo.Caption = "Arqueo de Efectivo"
        Me.grdArqueoEfectivo.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdArqueoEfectivo.FilterBar = True
        Me.grdArqueoEfectivo.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdArqueoEfectivo.Images.Add(CType(resources.GetObject("grdArqueoEfectivo.Images"), System.Drawing.Image))
        Me.grdArqueoEfectivo.Location = New System.Drawing.Point(12, 111)
        Me.grdArqueoEfectivo.Name = "grdArqueoEfectivo"
        Me.grdArqueoEfectivo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdArqueoEfectivo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdArqueoEfectivo.PreviewInfo.ZoomFactor = 75
        Me.grdArqueoEfectivo.PrintInfo.PageSettings = CType(resources.GetObject("grdArqueoEfectivo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdArqueoEfectivo.Size = New System.Drawing.Size(728, 378)
        Me.grdArqueoEfectivo.TabIndex = 23
        Me.grdArqueoEfectivo.Text = "grdArqueoEfectivo"
        Me.grdArqueoEfectivo.PropBag = resources.GetString("grdArqueoEfectivo.PropBag")
        '
        'tbArqueoEfectivo
        '
        Me.tbArqueoEfectivo.AutoSize = False
        Me.tbArqueoEfectivo.Dock = System.Windows.Forms.DockStyle.None
        Me.tbArqueoEfectivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregarC, Me.toolModificarC, Me.ToolStripSeparator2, Me.toolRefrescarE, Me.ToolStripSeparator3, Me.toolAyudaE})
        Me.tbArqueoEfectivo.Location = New System.Drawing.Point(12, 83)
        Me.tbArqueoEfectivo.Name = "tbArqueoEfectivo"
        Me.tbArqueoEfectivo.Size = New System.Drawing.Size(728, 25)
        Me.tbArqueoEfectivo.Stretch = True
        Me.tbArqueoEfectivo.TabIndex = 22
        Me.tbArqueoEfectivo.Text = "ToolStrip1"
        '
        'toolAgregarC
        '
        Me.toolAgregarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarC.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAgregarC.Name = "toolAgregarC"
        Me.toolAgregarC.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarC.Text = "ToolStripButton1"
        Me.toolAgregarC.ToolTipText = "Agregar Denominaciones No Incorporadas"
        '
        'toolModificarC
        '
        Me.toolModificarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarC.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarC.Name = "toolModificarC"
        Me.toolModificarC.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarC.Text = "Modificar Cantidad Denominación"
        Me.toolModificarC.ToolTipText = "Modificar Cantidad Denominación"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescarE
        '
        Me.toolRefrescarE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarE.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarE.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarE.Name = "toolRefrescarE"
        Me.toolRefrescarE.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarE.Text = "Refrescar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaE
        '
        Me.toolAyudaE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaE.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaE.Name = "toolAyudaE"
        Me.toolAyudaE.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaE.Text = "Ayuda"
        Me.toolAyudaE.ToolTipText = "Ayuda"
        '
        'grpDatosGralesDS
        '
        Me.grpDatosGralesDS.Controls.Add(Me.lblCajero)
        Me.grpDatosGralesDS.Controls.Add(Me.cboCajero)
        Me.grpDatosGralesDS.Controls.Add(Me.cdeFecha)
        Me.grpDatosGralesDS.Controls.Add(Me.Label1)
        Me.grpDatosGralesDS.Controls.Add(Me.txtEstadoAE)
        Me.grpDatosGralesDS.Controls.Add(Me.txtCodigoAE)
        Me.grpDatosGralesDS.Controls.Add(Me.lblEstadoAE)
        Me.grpDatosGralesDS.Controls.Add(Me.lblCodigoAE)
        Me.grpDatosGralesDS.Location = New System.Drawing.Point(10, 3)
        Me.grpDatosGralesDS.Name = "grpDatosGralesDS"
        Me.grpDatosGralesDS.Size = New System.Drawing.Size(728, 77)
        Me.grpDatosGralesDS.TabIndex = 0
        Me.grpDatosGralesDS.TabStop = False
        Me.grpDatosGralesDS.Text = "Datos Generales"
        '
        'lblCajero
        '
        Me.lblCajero.AutoSize = True
        Me.lblCajero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCajero.Location = New System.Drawing.Point(54, 51)
        Me.lblCajero.Name = "lblCajero"
        Me.lblCajero.Size = New System.Drawing.Size(97, 13)
        Me.lblCajero.TabIndex = 40
        Me.lblCajero.Text = "Nombre del Cajero:"
        '
        'cboCajero
        '
        Me.cboCajero.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCajero.AutoCompletion = True
        Me.cboCajero.Caption = ""
        Me.cboCajero.CaptionHeight = 17
        Me.cboCajero.CaptionStyle = Style17
        Me.cboCajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCajero.ColumnCaptionHeight = 17
        Me.cboCajero.ColumnFooterHeight = 17
        Me.cboCajero.ContentHeight = 15
        Me.cboCajero.DeadAreaBackColor = System.Drawing.SystemColors.Info
        Me.cboCajero.DisplayMember = "sNombreEmpleado"
        Me.cboCajero.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCajero.DropDownWidth = 384
        Me.cboCajero.EditorBackColor = System.Drawing.SystemColors.Info
        Me.cboCajero.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCajero.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCajero.EditorHeight = 15
        Me.cboCajero.EvenRowStyle = Style18
        Me.cboCajero.ExtendRightColumn = True
        Me.cboCajero.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCajero.FooterStyle = Style19
        Me.cboCajero.GapHeight = 2
        Me.cboCajero.HeadingStyle = Style20
        Me.cboCajero.HighLightRowStyle = Style21
        Me.cboCajero.Images.Add(CType(resources.GetObject("cboCajero.Images"), System.Drawing.Image))
        Me.cboCajero.ItemHeight = 15
        Me.cboCajero.LimitToList = True
        Me.cboCajero.Location = New System.Drawing.Point(153, 45)
        Me.cboCajero.MatchEntryTimeout = CType(2000, Long)
        Me.cboCajero.MaxDropDownItems = CType(5, Short)
        Me.cboCajero.MaxLength = 32767
        Me.cboCajero.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCajero.Name = "cboCajero"
        Me.cboCajero.OddRowStyle = Style22
        Me.cboCajero.PartialRightColumn = False
        Me.cboCajero.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCajero.SelectedStyle = Style23
        Me.cboCajero.Size = New System.Drawing.Size(383, 21)
        Me.cboCajero.Style = Style24
        Me.cboCajero.SuperBack = True
        Me.cboCajero.TabIndex = 39
        Me.cboCajero.ValueMember = "nSrhEmpleadoID"
        Me.cboCajero.PropBag = resources.GetString("cboCajero.PropBag")
        '
        'cdeFecha
        '
        Me.cdeFecha.BackColor = System.Drawing.SystemColors.Info
        Me.cdeFecha.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFecha.Enabled = False
        Me.cdeFecha.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFecha.Location = New System.Drawing.Point(247, 19)
        Me.cdeFecha.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFecha.MaskInfo.EmptyAsNull = True
        Me.cdeFecha.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFecha.Name = "cdeFecha"
        Me.cdeFecha.Size = New System.Drawing.Size(93, 20)
        Me.cdeFecha.TabIndex = 38
        Me.cdeFecha.Tag = Nothing
        Me.cdeFecha.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(200, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Fecha:"
        '
        'txtEstadoAE
        '
        Me.txtEstadoAE.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstadoAE.Enabled = False
        Me.txtEstadoAE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstadoAE.Location = New System.Drawing.Point(415, 18)
        Me.txtEstadoAE.Name = "txtEstadoAE"
        Me.txtEstadoAE.ReadOnly = True
        Me.txtEstadoAE.ShortcutsEnabled = False
        Me.txtEstadoAE.Size = New System.Drawing.Size(119, 20)
        Me.txtEstadoAE.TabIndex = 35
        Me.txtEstadoAE.Tag = "LAYOUT:FLAT"
        '
        'txtCodigoAE
        '
        Me.txtCodigoAE.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoAE.Enabled = False
        Me.txtCodigoAE.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoAE.Location = New System.Drawing.Point(99, 21)
        Me.txtCodigoAE.Name = "txtCodigoAE"
        Me.txtCodigoAE.ReadOnly = True
        Me.txtCodigoAE.ShortcutsEnabled = False
        Me.txtCodigoAE.Size = New System.Drawing.Size(86, 20)
        Me.txtCodigoAE.TabIndex = 34
        Me.txtCodigoAE.Tag = "LAYOUT:FLAT"
        '
        'lblEstadoAE
        '
        Me.lblEstadoAE.AutoSize = True
        Me.lblEstadoAE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstadoAE.Location = New System.Drawing.Point(363, 24)
        Me.lblEstadoAE.Name = "lblEstadoAE"
        Me.lblEstadoAE.Size = New System.Drawing.Size(43, 13)
        Me.lblEstadoAE.TabIndex = 33
        Me.lblEstadoAE.Text = "Estado:"
        '
        'lblCodigoAE
        '
        Me.lblCodigoAE.AutoSize = True
        Me.lblCodigoAE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoAE.Location = New System.Drawing.Point(54, 26)
        Me.lblCodigoAE.Name = "lblCodigoAE"
        Me.lblCodigoAE.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigoAE.TabIndex = 32
        Me.lblCodigoAE.Text = "Código:"
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
        'errArqueo
        '
        Me.errArqueo.ContainerControl = Me
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
        'frmSteEditArqueoEfectivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(773, 576)
        Me.Controls.Add(Me.tabArqueo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Arqueo de Efectivo")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditArqueoEfectivo"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Arqueo de Efectivo"
        CType(Me.tabArqueo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabArqueo.ResumeLayout(False)
        Me.tabEfectivo.ResumeLayout(False)
        CType(Me.grdArqueoEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbArqueoEfectivo.ResumeLayout(False)
        Me.tbArqueoEfectivo.PerformLayout()
        Me.grpDatosGralesDS.ResumeLayout(False)
        Me.grpDatosGralesDS.PerformLayout()
        CType(Me.cboCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errArqueo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabArqueo As C1.Win.C1Command.C1DockingTab
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents errArqueo As System.Windows.Forms.ErrorProvider
    Friend WithEvents tabEfectivo As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grpDatosGralesDS As System.Windows.Forms.GroupBox
    Friend WithEvents tbArqueoEfectivo As System.Windows.Forms.ToolStrip
    Friend WithEvents toolModificarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarE As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaE As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtEstadoAE As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigoAE As System.Windows.Forms.TextBox
    Friend WithEvents lblEstadoAE As System.Windows.Forms.Label
    Friend WithEvents lblCodigoAE As System.Windows.Forms.Label
    Friend WithEvents grdArqueoEfectivo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents toolAgregarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cdeFecha As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents lblCajero As System.Windows.Forms.Label
    Friend WithEvents cboCajero As C1.Win.C1List.C1Combo
End Class
