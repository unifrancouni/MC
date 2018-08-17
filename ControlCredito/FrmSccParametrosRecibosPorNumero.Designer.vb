<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccParametrosRecibosPorNumero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccParametrosRecibosPorNumero))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.grpOtroCredito = New System.Windows.Forms.GroupBox
        Me.CboPrograma = New C1.Win.C1List.C1Combo
        Me.lblPrograma = New System.Windows.Forms.Label
        Me.txtReciboFin = New System.Windows.Forms.TextBox
        Me.txtReciboIni = New System.Windows.Forms.TextBox
        Me.lblNumRecibo = New System.Windows.Forms.Label
        Me.lblMontoSolicitado = New System.Windows.Forms.Label
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpOtroCredito.SuspendLayout()
        CType(Me.CboPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(227, 92)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(150, 92)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 4
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'grpOtroCredito
        '
        Me.grpOtroCredito.Controls.Add(Me.CboPrograma)
        Me.grpOtroCredito.Controls.Add(Me.lblPrograma)
        Me.grpOtroCredito.Controls.Add(Me.txtReciboFin)
        Me.grpOtroCredito.Controls.Add(Me.txtReciboIni)
        Me.grpOtroCredito.Controls.Add(Me.lblNumRecibo)
        Me.grpOtroCredito.Controls.Add(Me.lblMontoSolicitado)
        Me.grpOtroCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpOtroCredito.Location = New System.Drawing.Point(12, 12)
        Me.grpOtroCredito.Name = "grpOtroCredito"
        Me.grpOtroCredito.Size = New System.Drawing.Size(288, 74)
        Me.grpOtroCredito.TabIndex = 3
        Me.grpOtroCredito.TabStop = False
        Me.grpOtroCredito.Text = "Rango de los Recibos a listar"
        '
        'CboPrograma
        '
        Me.CboPrograma.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboPrograma.AllowSort = False
        Me.CboPrograma.AutoCompletion = True
        Me.CboPrograma.Caption = ""
        Me.CboPrograma.CaptionHeight = 17
        Me.CboPrograma.CaptionStyle = Style1
        Me.CboPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboPrograma.ColumnCaptionHeight = 17
        Me.CboPrograma.ColumnFooterHeight = 17
        Me.CboPrograma.ContentHeight = 15
        Me.CboPrograma.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboPrograma.DisplayMember = "sDescripcion"
        Me.CboPrograma.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboPrograma.DropDownWidth = 211
        Me.CboPrograma.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboPrograma.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPrograma.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboPrograma.EditorHeight = 15
        Me.CboPrograma.EvenRowStyle = Style2
        Me.CboPrograma.ExtendRightColumn = True
        Me.CboPrograma.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboPrograma.FooterStyle = Style3
        Me.CboPrograma.GapHeight = 2
        Me.CboPrograma.HeadingStyle = Style4
        Me.CboPrograma.HighLightRowStyle = Style5
        Me.CboPrograma.Images.Add(CType(resources.GetObject("CboPrograma.Images"), System.Drawing.Image))
        Me.CboPrograma.ItemHeight = 15
        Me.CboPrograma.Location = New System.Drawing.Point(65, 47)
        Me.CboPrograma.MatchEntryTimeout = CType(2000, Long)
        Me.CboPrograma.MaxDropDownItems = CType(5, Short)
        Me.CboPrograma.MaxLength = 32767
        Me.CboPrograma.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboPrograma.Name = "CboPrograma"
        Me.CboPrograma.OddRowStyle = Style6
        Me.CboPrograma.PartialRightColumn = False
        Me.CboPrograma.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboPrograma.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboPrograma.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboPrograma.SelectedStyle = Style7
        Me.CboPrograma.Size = New System.Drawing.Size(210, 21)
        Me.CboPrograma.Style = Style8
        Me.CboPrograma.TabIndex = 2
        Me.CboPrograma.ValueMember = "nStbValorCatalogoID"
        Me.CboPrograma.PropBag = resources.GetString("CboPrograma.PropBag")
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrograma.Location = New System.Drawing.Point(11, 49)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(55, 13)
        Me.lblPrograma.TabIndex = 126
        Me.lblPrograma.Text = "Programa:"
        '
        'txtReciboFin
        '
        Me.txtReciboFin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReciboFin.Location = New System.Drawing.Point(184, 21)
        Me.txtReciboFin.Name = "txtReciboFin"
        Me.txtReciboFin.Size = New System.Drawing.Size(91, 20)
        Me.txtReciboFin.TabIndex = 1
        '
        'txtReciboIni
        '
        Me.txtReciboIni.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReciboIni.Location = New System.Drawing.Point(65, 23)
        Me.txtReciboIni.Name = "txtReciboIni"
        Me.txtReciboIni.Size = New System.Drawing.Size(84, 20)
        Me.txtReciboIni.TabIndex = 0
        '
        'lblNumRecibo
        '
        Me.lblNumRecibo.AutoSize = True
        Me.lblNumRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumRecibo.Location = New System.Drawing.Point(11, 26)
        Me.lblNumRecibo.Name = "lblNumRecibo"
        Me.lblNumRecibo.Size = New System.Drawing.Size(29, 13)
        Me.lblNumRecibo.TabIndex = 118
        Me.lblNumRecibo.Text = "Del :"
        '
        'lblMontoSolicitado
        '
        Me.lblMontoSolicitado.AutoSize = True
        Me.lblMontoSolicitado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMontoSolicitado.Location = New System.Drawing.Point(159, 26)
        Me.lblMontoSolicitado.Name = "lblMontoSolicitado"
        Me.lblMontoSolicitado.Size = New System.Drawing.Size(19, 13)
        Me.lblMontoSolicitado.TabIndex = 42
        Me.lblMontoSolicitado.Text = "Al:"
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'FrmSccParametrosRecibosPorNumero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 129)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpOtroCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSccParametrosRecibosPorNumero"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Recibos Por Rango de Números"
        Me.grpOtroCredito.ResumeLayout(False)
        Me.grpOtroCredito.PerformLayout()
        CType(Me.CboPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpOtroCredito As System.Windows.Forms.GroupBox
    Friend WithEvents txtReciboFin As System.Windows.Forms.TextBox
    Friend WithEvents txtReciboIni As System.Windows.Forms.TextBox
    Friend WithEvents lblNumRecibo As System.Windows.Forms.Label
    Friend WithEvents lblMontoSolicitado As System.Windows.Forms.Label
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CboPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
End Class
