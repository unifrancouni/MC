<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSclEditReferenciaSocia
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditReferenciaSocia))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.errModulo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cboReferencia = New C1.Win.C1List.C1Combo()
        Me.lblReferencia = New System.Windows.Forms.Label()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.LblConteo = New System.Windows.Forms.Label()
        Me.cmdUltimo = New System.Windows.Forms.Button()
        Me.cmdSiguiente = New System.Windows.Forms.Button()
        Me.CmdAnterior = New System.Windows.Forms.Button()
        Me.CmdPrimero = New System.Windows.Forms.Button()
        Me.txtNombreSocia = New System.Windows.Forms.TextBox()
        Me.lblNombreSocia = New System.Windows.Forms.Label()
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox()
        Me.lblSocia = New System.Windows.Forms.Label()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        CType(Me.errModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboReferencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(558, 260)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(481, 260)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 3
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'errModulo
        '
        Me.errModulo.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtObservaciones)
        Me.GroupBox1.Controls.Add(Me.lblObservaciones)
        Me.GroupBox1.Controls.Add(Me.cboReferencia)
        Me.GroupBox1.Controls.Add(Me.lblReferencia)
        Me.GroupBox1.Controls.Add(Me.cmdBuscar)
        Me.GroupBox1.Controls.Add(Me.grpBotones)
        Me.GroupBox1.Controls.Add(Me.txtNombreSocia)
        Me.GroupBox1.Controls.Add(Me.lblNombreSocia)
        Me.GroupBox1.Controls.Add(Me.mtbNumCedula)
        Me.GroupBox1.Controls.Add(Me.lblSocia)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 248)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de la Socia"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(97, 134)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(507, 43)
        Me.txtObservaciones.TabIndex = 3
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(18, 137)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 108
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'cboReferencia
        '
        Me.cboReferencia.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboReferencia.AutoCompletion = True
        Me.cboReferencia.AutoDropDown = True
        Me.cboReferencia.Caption = ""
        Me.cboReferencia.CaptionHeight = 17
        Me.cboReferencia.CaptionStyle = Style1
        Me.cboReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboReferencia.ColumnCaptionHeight = 17
        Me.cboReferencia.ColumnFooterHeight = 17
        Me.cboReferencia.ContentHeight = 15
        Me.cboReferencia.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboReferencia.DisplayMember = "sDescripcion"
        Me.cboReferencia.DropDownWidth = 315
        Me.cboReferencia.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboReferencia.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReferencia.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboReferencia.EditorHeight = 15
        Me.cboReferencia.EvenRowStyle = Style2
        Me.cboReferencia.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboReferencia.FooterStyle = Style3
        Me.cboReferencia.GapHeight = 2
        Me.cboReferencia.HeadingStyle = Style4
        Me.cboReferencia.HighLightRowStyle = Style5
        Me.cboReferencia.Images.Add(CType(resources.GetObject("cboReferencia.Images"), System.Drawing.Image))
        Me.cboReferencia.ItemHeight = 15
        Me.cboReferencia.LimitToList = True
        Me.cboReferencia.Location = New System.Drawing.Point(97, 96)
        Me.cboReferencia.MatchEntryTimeout = CType(2000, Long)
        Me.cboReferencia.MaxDropDownItems = CType(5, Short)
        Me.cboReferencia.MaxLength = 32767
        Me.cboReferencia.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboReferencia.Name = "cboReferencia"
        Me.cboReferencia.OddRowStyle = Style6
        Me.cboReferencia.PartialRightColumn = False
        Me.cboReferencia.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboReferencia.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboReferencia.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboReferencia.SelectedStyle = Style7
        Me.cboReferencia.Size = New System.Drawing.Size(222, 21)
        Me.cboReferencia.Style = Style8
        Me.cboReferencia.SuperBack = True
        Me.cboReferencia.TabIndex = 2
        Me.cboReferencia.ValueMember = "nStbValorCatalogoID"
        Me.cboReferencia.PropBag = resources.GetString("cboReferencia.PropBag")
        '
        'lblReferencia
        '
        Me.lblReferencia.AutoSize = True
        Me.lblReferencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblReferencia.Location = New System.Drawing.Point(18, 100)
        Me.lblReferencia.Name = "lblReferencia"
        Me.lblReferencia.Size = New System.Drawing.Size(62, 13)
        Me.lblReferencia.TabIndex = 107
        Me.lblReferencia.Text = "Referencia:"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(248, 23)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 12
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(21, 183)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(583, 50)
        Me.grpBotones.TabIndex = 105
        Me.grpBotones.TabStop = False
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(261, 23)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(0, 13)
        Me.LblConteo.TabIndex = 14
        '
        'cmdUltimo
        '
        Me.cmdUltimo.Image = Global.SMUSURA0.My.Resources.Resources.player_end
        Me.cmdUltimo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUltimo.Location = New System.Drawing.Point(497, 17)
        Me.cmdUltimo.Name = "cmdUltimo"
        Me.cmdUltimo.Size = New System.Drawing.Size(73, 25)
        Me.cmdUltimo.TabIndex = 3
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
        Me.cmdSiguiente.TabIndex = 2
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
        Me.CmdPrimero.Location = New System.Drawing.Point(22, 17)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(73, 25)
        Me.CmdPrimero.TabIndex = 0
        Me.CmdPrimero.Text = "Primero"
        Me.CmdPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(97, 62)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(222, 20)
        Me.txtNombreSocia.TabIndex = 1
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(18, 65)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(77, 13)
        Me.lblNombreSocia.TabIndex = 104
        Me.lblNombreSocia.Text = "Nombre Socia:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(97, 26)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 0
        '
        'lblSocia
        '
        Me.lblSocia.AutoSize = True
        Me.lblSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSocia.Location = New System.Drawing.Point(18, 29)
        Me.lblSocia.Name = "lblSocia"
        Me.lblSocia.Size = New System.Drawing.Size(73, 13)
        Me.lblSocia.TabIndex = 13
        Me.lblSocia.Text = "Cédula Socia:"
        '
        'frmSclEditReferenciaSocia
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(645, 292)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Central de Riesgo")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditReferenciaSocia"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Registro de Referencia a Socia"
        CType(Me.errModulo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboReferencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errModulo As System.Windows.Forms.ErrorProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblSocia As System.Windows.Forms.Label
    Friend WithEvents cboReferencia As C1.Win.C1List.C1Combo
    Friend WithEvents lblReferencia As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
