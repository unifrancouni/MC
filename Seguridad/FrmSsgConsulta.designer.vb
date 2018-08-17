<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSsgConsulta
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
        Dim grpFechaCreditos As System.Windows.Forms.GroupBox
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSsgConsulta))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboTabla = New C1.Win.C1List.C1Combo
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.lblMunicipio = New System.Windows.Forms.Label
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.lblDepartamento = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.cboTipoOperación = New System.Windows.Forms.ComboBox
        grpFechaCreditos = New System.Windows.Forms.GroupBox
        grpFechaCreditos.SuspendLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpFechaCreditos
        '
        grpFechaCreditos.Controls.Add(Me.CdeFechaFinal)
        grpFechaCreditos.Controls.Add(Me.cdeFechaInicial)
        grpFechaCreditos.Controls.Add(Me.Label2)
        grpFechaCreditos.Controls.Add(Me.Label1)
        grpFechaCreditos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        grpFechaCreditos.Location = New System.Drawing.Point(9, 82)
        grpFechaCreditos.Name = "grpFechaCreditos"
        grpFechaCreditos.Size = New System.Drawing.Size(351, 46)
        grpFechaCreditos.TabIndex = 74
        grpFechaCreditos.TabStop = False
        grpFechaCreditos.Text = "Fecha"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(219, 16)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(123, 20)
        Me.CdeFechaFinal.TabIndex = 3
        Me.CdeFechaFinal.Tag = Nothing
        Me.CdeFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(50, 16)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(123, 20)
        Me.cdeFechaInicial.TabIndex = 2
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(176, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Desde:"
        '
        'cboTabla
        '
        Me.cboTabla.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboTabla.AllowSort = False
        Me.cboTabla.AutoCompletion = True
        Me.cboTabla.Caption = ""
        Me.cboTabla.CaptionHeight = 17
        Me.cboTabla.CaptionStyle = Style9
        Me.cboTabla.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboTabla.ColumnCaptionHeight = 17
        Me.cboTabla.ColumnFooterHeight = 17
        Me.cboTabla.ContentHeight = 15
        Me.cboTabla.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboTabla.DisplayMember = "Nombre"
        Me.cboTabla.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboTabla.DropDownWidth = 250
        Me.cboTabla.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboTabla.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTabla.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTabla.EditorHeight = 15
        Me.cboTabla.EvenRowStyle = Style10
        Me.cboTabla.ExtendRightColumn = True
        Me.cboTabla.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboTabla.FooterStyle = Style11
        Me.cboTabla.GapHeight = 2
        Me.cboTabla.HeadingStyle = Style12
        Me.cboTabla.HighLightRowStyle = Style13
        Me.cboTabla.Images.Add(CType(resources.GetObject("cboTabla.Images"), System.Drawing.Image))
        Me.cboTabla.ItemHeight = 15
        Me.cboTabla.Location = New System.Drawing.Point(111, 19)
        Me.cboTabla.MatchEntryTimeout = CType(2000, Long)
        Me.cboTabla.MaxDropDownItems = CType(5, Short)
        Me.cboTabla.MaxLength = 32767
        Me.cboTabla.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboTabla.Name = "cboTabla"
        Me.cboTabla.OddRowStyle = Style14
        Me.cboTabla.PartialRightColumn = False
        Me.cboTabla.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboTabla.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboTabla.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboTabla.SelectedStyle = Style15
        Me.cboTabla.Size = New System.Drawing.Size(241, 21)
        Me.cboTabla.Style = Style16
        Me.cboTabla.TabIndex = 0
        Me.cboTabla.PropBag = resources.GetString("cboTabla.PropBag")
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(227, 148)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 4
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(304, 148)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMunicipio.Location = New System.Drawing.Point(16, 56)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(83, 13)
        Me.lblMunicipio.TabIndex = 34
        Me.lblMunicipio.Text = "Tipo Operación:"
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.cboTipoOperación)
        Me.grpdatos.Controls.Add(grpFechaCreditos)
        Me.grpdatos.Controls.Add(Me.cboTabla)
        Me.grpdatos.Controls.Add(Me.lblMunicipio)
        Me.grpdatos.Controls.Add(Me.lblDepartamento)
        Me.grpdatos.Location = New System.Drawing.Point(8, 4)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(367, 137)
        Me.grpdatos.TabIndex = 13
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(16, 24)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(37, 13)
        Me.lblDepartamento.TabIndex = 7
        Me.lblDepartamento.Text = "Tabla:"
        '
        'cboTipoOperación
        '
        Me.cboTipoOperación.FormattingEnabled = True
        Me.cboTipoOperación.Location = New System.Drawing.Point(111, 48)
        Me.cboTipoOperación.Name = "cboTipoOperación"
        Me.cboTipoOperación.Size = New System.Drawing.Size(240, 21)
        Me.cboTipoOperación.TabIndex = 1
        '
        'FrmSsgConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(382, 181)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpdatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSsgConsulta"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros de Consulta Auditoría"
        grpFechaCreditos.ResumeLayout(False)
        grpFechaCreditos.PerformLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cboTabla As C1.Win.C1List.C1Combo
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboTipoOperación As System.Windows.Forms.ComboBox
End Class
