<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclTrasladosDelegacionSocia
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclTrasladosDelegacionSocia))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.grpLugarPagos = New System.Windows.Forms.GroupBox
        Me.txtSocia = New System.Windows.Forms.TextBox
        Me.lblSocia = New System.Windows.Forms.Label
        Me.txtDelegacion = New System.Windows.Forms.TextBox
        Me.cboDelegacionD = New C1.Win.C1List.C1Combo
        Me.lblDelegacionD = New System.Windows.Forms.Label
        Me.lblDelegacionO = New System.Windows.Forms.Label
        Me.CmdTrasladar = New System.Windows.Forms.Button
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpLugarPagos.SuspendLayout()
        CType(Me.cboDelegacionD, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'grpLugarPagos
        '
        Me.grpLugarPagos.Controls.Add(Me.txtSocia)
        Me.grpLugarPagos.Controls.Add(Me.lblSocia)
        Me.grpLugarPagos.Controls.Add(Me.txtDelegacion)
        Me.grpLugarPagos.Controls.Add(Me.cboDelegacionD)
        Me.grpLugarPagos.Controls.Add(Me.lblDelegacionD)
        Me.grpLugarPagos.Controls.Add(Me.lblDelegacionO)
        Me.grpLugarPagos.Location = New System.Drawing.Point(12, 12)
        Me.grpLugarPagos.Name = "grpLugarPagos"
        Me.grpLugarPagos.Size = New System.Drawing.Size(474, 119)
        Me.grpLugarPagos.TabIndex = 18
        Me.grpLugarPagos.TabStop = False
        Me.grpLugarPagos.Text = "Seleccione Delegación "
        '
        'txtSocia
        '
        Me.txtSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtSocia.Enabled = False
        Me.txtSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSocia.Location = New System.Drawing.Point(123, 28)
        Me.txtSocia.Name = "txtSocia"
        Me.txtSocia.ReadOnly = True
        Me.txtSocia.Size = New System.Drawing.Size(329, 20)
        Me.txtSocia.TabIndex = 0
        Me.txtSocia.Tag = "LAYOUT:FLAT"
        '
        'lblSocia
        '
        Me.lblSocia.AutoSize = True
        Me.lblSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSocia.Location = New System.Drawing.Point(20, 28)
        Me.lblSocia.Name = "lblSocia"
        Me.lblSocia.Size = New System.Drawing.Size(77, 13)
        Me.lblSocia.TabIndex = 39
        Me.lblSocia.Text = "Nombre Socia:"
        '
        'txtDelegacion
        '
        Me.txtDelegacion.BackColor = System.Drawing.SystemColors.Info
        Me.txtDelegacion.Enabled = False
        Me.txtDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelegacion.Location = New System.Drawing.Point(123, 54)
        Me.txtDelegacion.Name = "txtDelegacion"
        Me.txtDelegacion.ReadOnly = True
        Me.txtDelegacion.Size = New System.Drawing.Size(329, 20)
        Me.txtDelegacion.TabIndex = 1
        Me.txtDelegacion.Tag = "LAYOUT:FLAT"
        '
        'cboDelegacionD
        '
        Me.cboDelegacionD.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDelegacionD.AutoCompletion = True
        Me.cboDelegacionD.Caption = ""
        Me.cboDelegacionD.CaptionHeight = 17
        Me.cboDelegacionD.CaptionStyle = Style1
        Me.cboDelegacionD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDelegacionD.ColumnCaptionHeight = 17
        Me.cboDelegacionD.ColumnFooterHeight = 17
        Me.cboDelegacionD.ContentHeight = 15
        Me.cboDelegacionD.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDelegacionD.DisplayMember = "sNombreDelegacion"
        Me.cboDelegacionD.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDelegacionD.DropDownWidth = 330
        Me.cboDelegacionD.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDelegacionD.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDelegacionD.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDelegacionD.EditorHeight = 15
        Me.cboDelegacionD.EvenRowStyle = Style2
        Me.cboDelegacionD.ExtendRightColumn = True
        Me.cboDelegacionD.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDelegacionD.FooterStyle = Style3
        Me.cboDelegacionD.GapHeight = 2
        Me.cboDelegacionD.HeadingStyle = Style4
        Me.cboDelegacionD.HighLightRowStyle = Style5
        Me.cboDelegacionD.Images.Add(CType(resources.GetObject("cboDelegacionD.Images"), System.Drawing.Image))
        Me.cboDelegacionD.ItemHeight = 15
        Me.cboDelegacionD.LimitToList = True
        Me.cboDelegacionD.Location = New System.Drawing.Point(123, 80)
        Me.cboDelegacionD.MatchEntryTimeout = CType(2000, Long)
        Me.cboDelegacionD.MaxDropDownItems = CType(5, Short)
        Me.cboDelegacionD.MaxLength = 32767
        Me.cboDelegacionD.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDelegacionD.Name = "cboDelegacionD"
        Me.cboDelegacionD.OddRowStyle = Style6
        Me.cboDelegacionD.PartialRightColumn = False
        Me.cboDelegacionD.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDelegacionD.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDelegacionD.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDelegacionD.SelectedStyle = Style7
        Me.cboDelegacionD.Size = New System.Drawing.Size(329, 21)
        Me.cboDelegacionD.Style = Style8
        Me.cboDelegacionD.SuperBack = True
        Me.cboDelegacionD.TabIndex = 2
        Me.cboDelegacionD.ValueMember = "nStbDelegacionProgramaID"
        Me.cboDelegacionD.PropBag = resources.GetString("cboDelegacionD.PropBag")
        '
        'lblDelegacionD
        '
        Me.lblDelegacionD.AutoSize = True
        Me.lblDelegacionD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDelegacionD.Location = New System.Drawing.Point(20, 80)
        Me.lblDelegacionD.Name = "lblDelegacionD"
        Me.lblDelegacionD.Size = New System.Drawing.Size(99, 13)
        Me.lblDelegacionD.TabIndex = 37
        Me.lblDelegacionD.Text = "Nueva Delegación:"
        '
        'lblDelegacionO
        '
        Me.lblDelegacionO.AutoSize = True
        Me.lblDelegacionO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDelegacionO.Location = New System.Drawing.Point(20, 54)
        Me.lblDelegacionO.Name = "lblDelegacionO"
        Me.lblDelegacionO.Size = New System.Drawing.Size(97, 13)
        Me.lblDelegacionO.TabIndex = 36
        Me.lblDelegacionO.Text = "Delegación Actual:"
        '
        'CmdTrasladar
        '
        Me.CmdTrasladar.Image = CType(resources.GetObject("CmdTrasladar.Image"), System.Drawing.Image)
        Me.CmdTrasladar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdTrasladar.Location = New System.Drawing.Point(328, 137)
        Me.CmdTrasladar.Name = "CmdTrasladar"
        Me.CmdTrasladar.Size = New System.Drawing.Size(76, 25)
        Me.CmdTrasladar.TabIndex = 3
        Me.CmdTrasladar.Text = "Trasladar"
        Me.CmdTrasladar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdTrasladar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta161
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(410, 137)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(76, 25)
        Me.cmdSalir.TabIndex = 4
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'frmSclTrasladosDelegacionSocia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 180)
        Me.Controls.Add(Me.grpLugarPagos)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.CmdTrasladar)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclTrasladosDelegacionSocia"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Traslado de Delegación"
        Me.grpLugarPagos.ResumeLayout(False)
        Me.grpLugarPagos.PerformLayout()
        CType(Me.cboDelegacionD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpLugarPagos As System.Windows.Forms.GroupBox
    Friend WithEvents txtSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblSocia As System.Windows.Forms.Label
    Friend WithEvents txtDelegacion As System.Windows.Forms.TextBox
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdTrasladar As System.Windows.Forms.Button
    Friend WithEvents cboDelegacionD As C1.Win.C1List.C1Combo
    Friend WithEvents lblDelegacionD As System.Windows.Forms.Label
    Friend WithEvents lblDelegacionO As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
