<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditCambioGS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditCambioGS))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpGrupoDestino = New System.Windows.Forms.GroupBox
        Me.txtNombreGS = New System.Windows.Forms.TextBox
        Me.lblNombreGS = New System.Windows.Forms.Label
        Me.cboGrupoDestino = New C1.Win.C1List.C1Combo
        Me.lblGrupoDestino = New System.Windows.Forms.Label
        Me.errModulo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpGrupoActual = New System.Windows.Forms.GroupBox
        Me.txtCedulaSocia = New System.Windows.Forms.TextBox
        Me.lblCedulaSocia = New System.Windows.Forms.Label
        Me.txtNombreSocia = New System.Windows.Forms.TextBox
        Me.lblNombreSocia = New System.Windows.Forms.Label
        Me.txtCodigoFicha = New System.Windows.Forms.TextBox
        Me.lblCodigoFicha = New System.Windows.Forms.Label
        Me.txtNombreGrupo = New System.Windows.Forms.TextBox
        Me.lblNombreGrupo = New System.Windows.Forms.Label
        Me.lblCodigoGrupo = New System.Windows.Forms.Label
        Me.txtCodigoGrupo = New System.Windows.Forms.TextBox
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpGrupoDestino.SuspendLayout()
        CType(Me.cboGrupoDestino, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGrupoActual.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpGrupoDestino
        '
        Me.grpGrupoDestino.Controls.Add(Me.txtNombreGS)
        Me.grpGrupoDestino.Controls.Add(Me.lblNombreGS)
        Me.grpGrupoDestino.Controls.Add(Me.cboGrupoDestino)
        Me.grpGrupoDestino.Controls.Add(Me.lblGrupoDestino)
        Me.grpGrupoDestino.Location = New System.Drawing.Point(12, 188)
        Me.grpGrupoDestino.Name = "grpGrupoDestino"
        Me.grpGrupoDestino.Size = New System.Drawing.Size(449, 84)
        Me.grpGrupoDestino.TabIndex = 0
        Me.grpGrupoDestino.TabStop = False
        Me.grpGrupoDestino.Text = "Datos del Nuevo Grupo Solidario: "
        '
        'txtNombreGS
        '
        Me.txtNombreGS.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreGS.Enabled = False
        Me.txtNombreGS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreGS.Location = New System.Drawing.Point(101, 56)
        Me.txtNombreGS.Name = "txtNombreGS"
        Me.txtNombreGS.ReadOnly = True
        Me.txtNombreGS.Size = New System.Drawing.Size(331, 20)
        Me.txtNombreGS.TabIndex = 107
        Me.txtNombreGS.Tag = "LAYOUT:FLAT"
        '
        'lblNombreGS
        '
        Me.lblNombreGS.AutoSize = True
        Me.lblNombreGS.ForeColor = System.Drawing.Color.Black
        Me.lblNombreGS.Location = New System.Drawing.Point(18, 59)
        Me.lblNombreGS.Name = "lblNombreGS"
        Me.lblNombreGS.Size = New System.Drawing.Size(79, 13)
        Me.lblNombreGS.TabIndex = 106
        Me.lblNombreGS.Text = "Nombre Grupo:"
        '
        'cboGrupoDestino
        '
        Me.cboGrupoDestino.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboGrupoDestino.AutoCompletion = True
        Me.cboGrupoDestino.AutoDropDown = True
        Me.cboGrupoDestino.Caption = ""
        Me.cboGrupoDestino.CaptionHeight = 17
        Me.cboGrupoDestino.CaptionStyle = Style1
        Me.cboGrupoDestino.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboGrupoDestino.ColumnCaptionHeight = 17
        Me.cboGrupoDestino.ColumnFooterHeight = 17
        Me.cboGrupoDestino.ContentHeight = 15
        Me.cboGrupoDestino.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboGrupoDestino.DisplayMember = "sCodigo"
        Me.cboGrupoDestino.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboGrupoDestino.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupoDestino.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboGrupoDestino.EditorHeight = 15
        Me.cboGrupoDestino.EvenRowStyle = Style2
        Me.cboGrupoDestino.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboGrupoDestino.FooterStyle = Style3
        Me.cboGrupoDestino.GapHeight = 2
        Me.cboGrupoDestino.HeadingStyle = Style4
        Me.cboGrupoDestino.HighLightRowStyle = Style5
        Me.cboGrupoDestino.Images.Add(CType(resources.GetObject("cboGrupoDestino.Images"), System.Drawing.Image))
        Me.cboGrupoDestino.ItemHeight = 15
        Me.cboGrupoDestino.LimitToList = True
        Me.cboGrupoDestino.Location = New System.Drawing.Point(101, 29)
        Me.cboGrupoDestino.MatchEntryTimeout = CType(2000, Long)
        Me.cboGrupoDestino.MaxDropDownItems = CType(5, Short)
        Me.cboGrupoDestino.MaxLength = 32767
        Me.cboGrupoDestino.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboGrupoDestino.Name = "cboGrupoDestino"
        Me.cboGrupoDestino.OddRowStyle = Style6
        Me.cboGrupoDestino.PartialRightColumn = False
        Me.cboGrupoDestino.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboGrupoDestino.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboGrupoDestino.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboGrupoDestino.SelectedStyle = Style7
        Me.cboGrupoDestino.Size = New System.Drawing.Size(331, 21)
        Me.cboGrupoDestino.Style = Style8
        Me.cboGrupoDestino.SuperBack = True
        Me.cboGrupoDestino.TabIndex = 1
        Me.cboGrupoDestino.ValueMember = "nSclGrupoSolidarioID"
        Me.cboGrupoDestino.PropBag = resources.GetString("cboGrupoDestino.PropBag")
        '
        'lblGrupoDestino
        '
        Me.lblGrupoDestino.AutoSize = True
        Me.lblGrupoDestino.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupoDestino.Location = New System.Drawing.Point(18, 29)
        Me.lblGrupoDestino.Name = "lblGrupoDestino"
        Me.lblGrupoDestino.Size = New System.Drawing.Size(78, 13)
        Me.lblGrupoDestino.TabIndex = 13
        Me.lblGrupoDestino.Text = "Grupo Destino:"
        '
        'errModulo
        '
        Me.errModulo.ContainerControl = Me
        '
        'grpGrupoActual
        '
        Me.grpGrupoActual.Controls.Add(Me.txtCedulaSocia)
        Me.grpGrupoActual.Controls.Add(Me.lblCedulaSocia)
        Me.grpGrupoActual.Controls.Add(Me.txtNombreSocia)
        Me.grpGrupoActual.Controls.Add(Me.lblNombreSocia)
        Me.grpGrupoActual.Controls.Add(Me.txtCodigoFicha)
        Me.grpGrupoActual.Controls.Add(Me.lblCodigoFicha)
        Me.grpGrupoActual.Controls.Add(Me.txtNombreGrupo)
        Me.grpGrupoActual.Controls.Add(Me.lblNombreGrupo)
        Me.grpGrupoActual.Controls.Add(Me.lblCodigoGrupo)
        Me.grpGrupoActual.Controls.Add(Me.txtCodigoGrupo)
        Me.grpGrupoActual.Location = New System.Drawing.Point(12, 12)
        Me.grpGrupoActual.Name = "grpGrupoActual"
        Me.grpGrupoActual.Size = New System.Drawing.Size(449, 161)
        Me.grpGrupoActual.TabIndex = 5
        Me.grpGrupoActual.TabStop = False
        Me.grpGrupoActual.Text = "Datos del Grupo Solidario Actual: "
        '
        'txtCedulaSocia
        '
        Me.txtCedulaSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtCedulaSocia.Enabled = False
        Me.txtCedulaSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCedulaSocia.Location = New System.Drawing.Point(101, 129)
        Me.txtCedulaSocia.Name = "txtCedulaSocia"
        Me.txtCedulaSocia.ReadOnly = True
        Me.txtCedulaSocia.Size = New System.Drawing.Size(331, 20)
        Me.txtCedulaSocia.TabIndex = 111
        Me.txtCedulaSocia.Tag = "LAYOUT:FLAT"
        '
        'lblCedulaSocia
        '
        Me.lblCedulaSocia.AutoSize = True
        Me.lblCedulaSocia.ForeColor = System.Drawing.Color.Black
        Me.lblCedulaSocia.Location = New System.Drawing.Point(18, 132)
        Me.lblCedulaSocia.Name = "lblCedulaSocia"
        Me.lblCedulaSocia.Size = New System.Drawing.Size(73, 13)
        Me.lblCedulaSocia.TabIndex = 110
        Me.lblCedulaSocia.Text = "Cédula Socia:"
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(101, 103)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(331, 20)
        Me.txtNombreSocia.TabIndex = 109
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.Black
        Me.lblNombreSocia.Location = New System.Drawing.Point(18, 106)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(77, 13)
        Me.lblNombreSocia.TabIndex = 108
        Me.lblNombreSocia.Text = "Nombre Socia:"
        '
        'txtCodigoFicha
        '
        Me.txtCodigoFicha.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoFicha.Enabled = False
        Me.txtCodigoFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoFicha.Location = New System.Drawing.Point(101, 77)
        Me.txtCodigoFicha.Name = "txtCodigoFicha"
        Me.txtCodigoFicha.ReadOnly = True
        Me.txtCodigoFicha.Size = New System.Drawing.Size(331, 20)
        Me.txtCodigoFicha.TabIndex = 107
        Me.txtCodigoFicha.Tag = "LAYOUT:FLAT"
        '
        'lblCodigoFicha
        '
        Me.lblCodigoFicha.AutoSize = True
        Me.lblCodigoFicha.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoFicha.Location = New System.Drawing.Point(18, 80)
        Me.lblCodigoFicha.Name = "lblCodigoFicha"
        Me.lblCodigoFicha.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoFicha.TabIndex = 106
        Me.lblCodigoFicha.Text = "Código Ficha:"
        '
        'txtNombreGrupo
        '
        Me.txtNombreGrupo.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreGrupo.Enabled = False
        Me.txtNombreGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreGrupo.Location = New System.Drawing.Point(101, 51)
        Me.txtNombreGrupo.Name = "txtNombreGrupo"
        Me.txtNombreGrupo.ReadOnly = True
        Me.txtNombreGrupo.Size = New System.Drawing.Size(331, 20)
        Me.txtNombreGrupo.TabIndex = 105
        Me.txtNombreGrupo.Tag = "LAYOUT:FLAT"
        '
        'lblNombreGrupo
        '
        Me.lblNombreGrupo.AutoSize = True
        Me.lblNombreGrupo.ForeColor = System.Drawing.Color.Black
        Me.lblNombreGrupo.Location = New System.Drawing.Point(18, 54)
        Me.lblNombreGrupo.Name = "lblNombreGrupo"
        Me.lblNombreGrupo.Size = New System.Drawing.Size(79, 13)
        Me.lblNombreGrupo.TabIndex = 104
        Me.lblNombreGrupo.Text = "Nombre Grupo:"
        '
        'lblCodigoGrupo
        '
        Me.lblCodigoGrupo.AutoSize = True
        Me.lblCodigoGrupo.ForeColor = System.Drawing.Color.Black
        Me.lblCodigoGrupo.Location = New System.Drawing.Point(18, 31)
        Me.lblCodigoGrupo.Name = "lblCodigoGrupo"
        Me.lblCodigoGrupo.Size = New System.Drawing.Size(75, 13)
        Me.lblCodigoGrupo.TabIndex = 103
        Me.lblCodigoGrupo.Text = "Código Grupo:"
        '
        'txtCodigoGrupo
        '
        Me.txtCodigoGrupo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoGrupo.Enabled = False
        Me.txtCodigoGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoGrupo.Location = New System.Drawing.Point(101, 28)
        Me.txtCodigoGrupo.Name = "txtCodigoGrupo"
        Me.txtCodigoGrupo.ReadOnly = True
        Me.txtCodigoGrupo.Size = New System.Drawing.Size(331, 20)
        Me.txtCodigoGrupo.TabIndex = 102
        Me.txtCodigoGrupo.Tag = "LAYOUT:FLAT"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(311, 278)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 3
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(388, 278)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSclEditCambioGS
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(473, 315)
        Me.Controls.Add(Me.grpGrupoActual)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpGrupoDestino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Cambio de Grupo Solidario")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditCambioGS"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Cambio de Socia de Grupo Solidario"
        Me.grpGrupoDestino.ResumeLayout(False)
        Me.grpGrupoDestino.PerformLayout()
        CType(Me.cboGrupoDestino, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGrupoActual.ResumeLayout(False)
        Me.grpGrupoActual.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpGrupoDestino As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cboGrupoDestino As C1.Win.C1List.C1Combo
    Friend WithEvents lblGrupoDestino As System.Windows.Forms.Label
    Friend WithEvents errModulo As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpGrupoActual As System.Windows.Forms.GroupBox
    Friend WithEvents lblCodigoGrupo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoGrupo As System.Windows.Forms.TextBox
    Friend WithEvents txtCedulaSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblCedulaSocia As System.Windows.Forms.Label
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents txtCodigoFicha As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoFicha As System.Windows.Forms.Label
    Friend WithEvents txtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreGrupo As System.Windows.Forms.Label
    Friend WithEvents txtNombreGS As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreGS As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
