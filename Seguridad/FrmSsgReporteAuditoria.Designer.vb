<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSsgReporteAuditoria
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSsgReporteAuditoria))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpOtroCredito = New System.Windows.Forms.GroupBox
        Me.CboPrograma = New C1.Win.C1List.C1Combo
        Me.lblPrograma = New System.Windows.Forms.Label
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cboTabla = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.dtFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.LblHasta = New System.Windows.Forms.Label
        Me.LblDesde = New System.Windows.Forms.Label
        Me.grpOtroCredito.SuspendLayout()
        CType(Me.CboPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpOtroCredito
        '
        Me.grpOtroCredito.Controls.Add(Me.dtFechaFinal)
        Me.grpOtroCredito.Controls.Add(Me.dtFechaInicial)
        Me.grpOtroCredito.Controls.Add(Me.LblHasta)
        Me.grpOtroCredito.Controls.Add(Me.LblDesde)
        Me.grpOtroCredito.Controls.Add(Me.cboTabla)
        Me.grpOtroCredito.Controls.Add(Me.Label1)
        Me.grpOtroCredito.Controls.Add(Me.CboPrograma)
        Me.grpOtroCredito.Controls.Add(Me.lblPrograma)
        Me.grpOtroCredito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpOtroCredito.Location = New System.Drawing.Point(6, 4)
        Me.grpOtroCredito.Name = "grpOtroCredito"
        Me.grpOtroCredito.Size = New System.Drawing.Size(343, 103)
        Me.grpOtroCredito.TabIndex = 3
        Me.grpOtroCredito.TabStop = False
        '
        'CboPrograma
        '
        Me.CboPrograma.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboPrograma.AllowSort = False
        Me.CboPrograma.AutoCompletion = True
        Me.CboPrograma.Caption = ""
        Me.CboPrograma.CaptionHeight = 17
        Me.CboPrograma.CaptionStyle = Style9
        Me.CboPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboPrograma.ColumnCaptionHeight = 17
        Me.CboPrograma.ColumnFooterHeight = 17
        Me.CboPrograma.ContentHeight = 15
        Me.CboPrograma.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboPrograma.DisplayMember = "Nombre"
        Me.CboPrograma.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboPrograma.DropDownWidth = 211
        Me.CboPrograma.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboPrograma.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboPrograma.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboPrograma.EditorHeight = 15
        Me.CboPrograma.EvenRowStyle = Style10
        Me.CboPrograma.ExtendRightColumn = True
        Me.CboPrograma.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboPrograma.FooterStyle = Style11
        Me.CboPrograma.GapHeight = 2
        Me.CboPrograma.HeadingStyle = Style12
        Me.CboPrograma.HighLightRowStyle = Style13
        Me.CboPrograma.Images.Add(CType(resources.GetObject("CboPrograma.Images"), System.Drawing.Image))
        Me.CboPrograma.ItemHeight = 15
        Me.CboPrograma.Location = New System.Drawing.Point(65, 47)
        Me.CboPrograma.MatchEntryTimeout = CType(2000, Long)
        Me.CboPrograma.MaxDropDownItems = CType(5, Short)
        Me.CboPrograma.MaxLength = 32767
        Me.CboPrograma.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboPrograma.Name = "CboPrograma"
        Me.CboPrograma.OddRowStyle = Style14
        Me.CboPrograma.PartialRightColumn = False
        Me.CboPrograma.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboPrograma.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboPrograma.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboPrograma.SelectedStyle = Style15
        Me.CboPrograma.Size = New System.Drawing.Size(264, 21)
        Me.CboPrograma.Style = Style16
        Me.CboPrograma.TabIndex = 2
        Me.CboPrograma.ValueMember = "SarSistemaID"
        Me.CboPrograma.PropBag = resources.GetString("CboPrograma.PropBag")
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrograma.Location = New System.Drawing.Point(11, 53)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(45, 13)
        Me.lblPrograma.TabIndex = 126
        Me.lblPrograma.Text = "M�dulo:"
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(276, 114)
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
        Me.CmdAceptar.Location = New System.Drawing.Point(199, 114)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 4
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cboTabla
        '
        Me.cboTabla.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTabla.AllowSort = False
        Me.cboTabla.AutoCompletion = True
        Me.cboTabla.Caption = ""
        Me.cboTabla.CaptionHeight = 17
        Me.cboTabla.CaptionStyle = Style1
        Me.cboTabla.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTabla.ColumnCaptionHeight = 17
        Me.cboTabla.ColumnFooterHeight = 17
        Me.cboTabla.ContentHeight = 15
        Me.cboTabla.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTabla.DisplayMember = "Nombre"
        Me.cboTabla.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTabla.DropDownWidth = 211
        Me.cboTabla.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTabla.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTabla.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTabla.EditorHeight = 15
        Me.cboTabla.Enabled = False
        Me.cboTabla.EvenRowStyle = Style2
        Me.cboTabla.ExtendRightColumn = True
        Me.cboTabla.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTabla.FooterStyle = Style3
        Me.cboTabla.GapHeight = 2
        Me.cboTabla.HeadingStyle = Style4
        Me.cboTabla.HighLightRowStyle = Style5
        Me.cboTabla.Images.Add(CType(resources.GetObject("cboTabla.Images"), System.Drawing.Image))
        Me.cboTabla.ItemHeight = 15
        Me.cboTabla.Location = New System.Drawing.Point(65, 73)
        Me.cboTabla.MatchEntryTimeout = CType(2000, Long)
        Me.cboTabla.MaxDropDownItems = CType(5, Short)
        Me.cboTabla.MaxLength = 32767
        Me.cboTabla.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTabla.Name = "cboTabla"
        Me.cboTabla.OddRowStyle = Style6
        Me.cboTabla.PartialRightColumn = False
        Me.cboTabla.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTabla.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTabla.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTabla.SelectedStyle = Style7
        Me.cboTabla.Size = New System.Drawing.Size(264, 21)
        Me.cboTabla.Style = Style8
        Me.cboTabla.TabIndex = 3
        Me.cboTabla.ValueMember = "SarTablaID"
        Me.cboTabla.PropBag = resources.GetString("cboTabla.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(11, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Tabla:"
        '
        'dtFechaFinal
        '
        Me.dtFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.dtFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtFechaFinal.Location = New System.Drawing.Point(216, 24)
        Me.dtFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.dtFechaFinal.MaskInfo.EmptyAsNull = True
        Me.dtFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Size = New System.Drawing.Size(113, 20)
        Me.dtFechaFinal.TabIndex = 1
        Me.dtFechaFinal.Tag = Nothing
        Me.dtFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'dtFechaInicial
        '
        Me.dtFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.dtFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtFechaInicial.Location = New System.Drawing.Point(65, 24)
        Me.dtFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.dtFechaInicial.MaskInfo.EmptyAsNull = True
        Me.dtFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.dtFechaInicial.Name = "dtFechaInicial"
        Me.dtFechaInicial.Size = New System.Drawing.Size(104, 20)
        Me.dtFechaInicial.TabIndex = 0
        Me.dtFechaInicial.Tag = Nothing
        Me.dtFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'LblHasta
        '
        Me.LblHasta.AutoSize = True
        Me.LblHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblHasta.Location = New System.Drawing.Point(175, 31)
        Me.LblHasta.Name = "LblHasta"
        Me.LblHasta.Size = New System.Drawing.Size(38, 13)
        Me.LblHasta.TabIndex = 130
        Me.LblHasta.Text = "Hasta:"
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblDesde.Location = New System.Drawing.Point(11, 31)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(41, 13)
        Me.LblDesde.TabIndex = 129
        Me.LblDesde.Text = "Desde:"
        '
        'FrmSsgReporteAuditoria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 145)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpOtroCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSsgReporteAuditoria"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Recibos de Caja "
        Me.grpOtroCredito.ResumeLayout(False)
        Me.grpOtroCredito.PerformLayout()
        CType(Me.CboPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpOtroCredito As System.Windows.Forms.GroupBox
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CboPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
    Friend WithEvents cboTabla As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents dtFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents LblHasta As System.Windows.Forms.Label
    Friend WithEvents LblDesde As System.Windows.Forms.Label
End Class