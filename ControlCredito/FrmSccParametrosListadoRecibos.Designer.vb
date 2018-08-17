<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccParametrosListadoRecibos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccParametrosListadoRecibos))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.grpPrograma = New System.Windows.Forms.GroupBox
        Me.RdVentanadeGenero = New System.Windows.Forms.RadioButton
        Me.RdUsuraCero = New System.Windows.Forms.RadioButton
        Me.GrpListadoPor = New System.Windows.Forms.GroupBox
        Me.RdDetalle = New System.Windows.Forms.RadioButton
        Me.RdTotales = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboUsuario = New C1.Win.C1List.C1Combo
        Me.lblIngresadoPor = New System.Windows.Forms.Label
        Me.grpAprobadoODenegado = New System.Windows.Forms.GroupBox
        Me.RdIngreso = New System.Windows.Forms.RadioButton
        Me.RdRecibo = New System.Windows.Forms.RadioButton
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        Me.grpPrograma.SuspendLayout()
        Me.GrpListadoPor.SuspendLayout()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpAprobadoODenegado.SuspendLayout()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(283, 309)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(358, 309)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 10
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(264, 88)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(123, 20)
        Me.CdeFechaFinal.TabIndex = 39
        Me.CdeFechaFinal.Tag = Nothing
        Me.CdeFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.grpPrograma)
        Me.grpdatos.Controls.Add(Me.GrpListadoPor)
        Me.grpdatos.Controls.Add(Me.Label3)
        Me.grpdatos.Controls.Add(Me.cboUsuario)
        Me.grpdatos.Controls.Add(Me.lblIngresadoPor)
        Me.grpdatos.Controls.Add(Me.grpAprobadoODenegado)
        Me.grpdatos.Controls.Add(Me.CdeFechaFinal)
        Me.grpdatos.Controls.Add(Me.cdeFechaInicial)
        Me.grpdatos.Controls.Add(Me.Label2)
        Me.grpdatos.Controls.Add(Me.Label1)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(413, 291)
        Me.grpdatos.TabIndex = 8
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por Fecha de"
        '
        'grpPrograma
        '
        Me.grpPrograma.Controls.Add(Me.RdVentanadeGenero)
        Me.grpPrograma.Controls.Add(Me.RdUsuraCero)
        Me.grpPrograma.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grpPrograma.Location = New System.Drawing.Point(12, 243)
        Me.grpPrograma.Name = "grpPrograma"
        Me.grpPrograma.Size = New System.Drawing.Size(375, 42)
        Me.grpPrograma.TabIndex = 78
        Me.grpPrograma.TabStop = False
        Me.grpPrograma.Text = "Programa"
        '
        'RdVentanadeGenero
        '
        Me.RdVentanadeGenero.AutoSize = True
        Me.RdVentanadeGenero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdVentanadeGenero.Location = New System.Drawing.Point(97, 19)
        Me.RdVentanadeGenero.Name = "RdVentanadeGenero"
        Me.RdVentanadeGenero.Size = New System.Drawing.Size(118, 17)
        Me.RdVentanadeGenero.TabIndex = 2
        Me.RdVentanadeGenero.Text = "Ventana de Genero"
        Me.RdVentanadeGenero.UseVisualStyleBackColor = True
        '
        'RdUsuraCero
        '
        Me.RdUsuraCero.AutoSize = True
        Me.RdUsuraCero.Checked = True
        Me.RdUsuraCero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdUsuraCero.Location = New System.Drawing.Point(9, 19)
        Me.RdUsuraCero.Name = "RdUsuraCero"
        Me.RdUsuraCero.Size = New System.Drawing.Size(78, 17)
        Me.RdUsuraCero.TabIndex = 1
        Me.RdUsuraCero.TabStop = True
        Me.RdUsuraCero.Text = "Usura Cero"
        Me.RdUsuraCero.UseVisualStyleBackColor = True
        '
        'GrpListadoPor
        '
        Me.GrpListadoPor.Controls.Add(Me.RdDetalle)
        Me.GrpListadoPor.Controls.Add(Me.RdTotales)
        Me.GrpListadoPor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.GrpListadoPor.Location = New System.Drawing.Point(12, 180)
        Me.GrpListadoPor.Name = "GrpListadoPor"
        Me.GrpListadoPor.Size = New System.Drawing.Size(375, 51)
        Me.GrpListadoPor.TabIndex = 44
        Me.GrpListadoPor.TabStop = False
        Me.GrpListadoPor.Text = "Listado por"
        '
        'RdDetalle
        '
        Me.RdDetalle.AutoSize = True
        Me.RdDetalle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdDetalle.Location = New System.Drawing.Point(91, 19)
        Me.RdDetalle.Name = "RdDetalle"
        Me.RdDetalle.Size = New System.Drawing.Size(58, 17)
        Me.RdDetalle.TabIndex = 1
        Me.RdDetalle.Text = "Detalle"
        Me.RdDetalle.UseVisualStyleBackColor = True
        '
        'RdTotales
        '
        Me.RdTotales.AutoSize = True
        Me.RdTotales.Checked = True
        Me.RdTotales.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdTotales.Location = New System.Drawing.Point(6, 19)
        Me.RdTotales.Name = "RdTotales"
        Me.RdTotales.Size = New System.Drawing.Size(60, 17)
        Me.RdTotales.TabIndex = 0
        Me.RdTotales.TabStop = True
        Me.RdTotales.Text = "Totales"
        Me.RdTotales.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(9, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 43
        Me.Label3.Text = "Tipo de Fecha:"
        '
        'cboUsuario
        '
        Me.cboUsuario.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboUsuario.Caption = ""
        Me.cboUsuario.CaptionHeight = 17
        Me.cboUsuario.CaptionStyle = Style1
        Me.cboUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUsuario.ColumnCaptionHeight = 17
        Me.cboUsuario.ColumnFooterHeight = 17
        Me.cboUsuario.ContentHeight = 15
        Me.cboUsuario.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboUsuario.DisplayMember = "NombreUsuario"
        Me.cboUsuario.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboUsuario.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsuario.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboUsuario.EditorHeight = 15
        Me.cboUsuario.EvenRowStyle = Style2
        Me.cboUsuario.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboUsuario.FooterStyle = Style3
        Me.cboUsuario.GapHeight = 2
        Me.cboUsuario.HeadingStyle = Style4
        Me.cboUsuario.HighLightRowStyle = Style5
        Me.cboUsuario.Images.Add(CType(resources.GetObject("cboUsuario.Images"), System.Drawing.Image))
        Me.cboUsuario.ItemHeight = 15
        Me.cboUsuario.Location = New System.Drawing.Point(96, 143)
        Me.cboUsuario.MatchEntryTimeout = CType(2000, Long)
        Me.cboUsuario.MaxDropDownItems = CType(5, Short)
        Me.cboUsuario.MaxLength = 32767
        Me.cboUsuario.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.OddRowStyle = Style6
        Me.cboUsuario.PartialRightColumn = False
        Me.cboUsuario.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboUsuario.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboUsuario.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboUsuario.SelectedStyle = Style7
        Me.cboUsuario.Size = New System.Drawing.Size(291, 21)
        Me.cboUsuario.Style = Style8
        Me.cboUsuario.TabIndex = 11
        Me.cboUsuario.PropBag = resources.GetString("cboUsuario.PropBag")
        '
        'lblIngresadoPor
        '
        Me.lblIngresadoPor.AutoSize = True
        Me.lblIngresadoPor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblIngresadoPor.Location = New System.Drawing.Point(9, 143)
        Me.lblIngresadoPor.Name = "lblIngresadoPor"
        Me.lblIngresadoPor.Size = New System.Drawing.Size(76, 13)
        Me.lblIngresadoPor.TabIndex = 42
        Me.lblIngresadoPor.Text = "Ingresado Por:"
        '
        'grpAprobadoODenegado
        '
        Me.grpAprobadoODenegado.Controls.Add(Me.RdIngreso)
        Me.grpAprobadoODenegado.Controls.Add(Me.RdRecibo)
        Me.grpAprobadoODenegado.Location = New System.Drawing.Point(96, 19)
        Me.grpAprobadoODenegado.Name = "grpAprobadoODenegado"
        Me.grpAprobadoODenegado.Size = New System.Drawing.Size(179, 43)
        Me.grpAprobadoODenegado.TabIndex = 40
        Me.grpAprobadoODenegado.TabStop = False
        '
        'RdIngreso
        '
        Me.RdIngreso.AutoSize = True
        Me.RdIngreso.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdIngreso.Location = New System.Drawing.Point(90, 19)
        Me.RdIngreso.Name = "RdIngreso"
        Me.RdIngreso.Size = New System.Drawing.Size(60, 17)
        Me.RdIngreso.TabIndex = 1
        Me.RdIngreso.Text = "Ingreso"
        Me.RdIngreso.UseVisualStyleBackColor = True
        '
        'RdRecibo
        '
        Me.RdRecibo.AutoSize = True
        Me.RdRecibo.Checked = True
        Me.RdRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RdRecibo.Location = New System.Drawing.Point(6, 19)
        Me.RdRecibo.Name = "RdRecibo"
        Me.RdRecibo.Size = New System.Drawing.Size(59, 17)
        Me.RdRecibo.TabIndex = 0
        Me.RdRecibo.TabStop = True
        Me.RdRecibo.Text = "Recibo"
        Me.RdRecibo.UseVisualStyleBackColor = True
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(62, 88)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(123, 20)
        Me.cdeFechaInicial.TabIndex = 38
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(208, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Hasta:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Desde:"
        '
        'FrmSccParametrosListadoRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 344)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpdatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSccParametrosListadoRecibos"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros de Consulta de Listados de Recibos"
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        Me.grpPrograma.ResumeLayout(False)
        Me.grpPrograma.PerformLayout()
        Me.GrpListadoPor.ResumeLayout(False)
        Me.GrpListadoPor.PerformLayout()
        CType(Me.cboUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpAprobadoODenegado.ResumeLayout(False)
        Me.grpAprobadoODenegado.PerformLayout()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpAprobadoODenegado As System.Windows.Forms.GroupBox
    Friend WithEvents RdIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents RdRecibo As System.Windows.Forms.RadioButton
    Friend WithEvents lblIngresadoPor As System.Windows.Forms.Label
    Friend WithEvents cboUsuario As C1.Win.C1List.C1Combo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GrpListadoPor As System.Windows.Forms.GroupBox
    Friend WithEvents RdDetalle As System.Windows.Forms.RadioButton
    Friend WithEvents RdTotales As System.Windows.Forms.RadioButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents grpPrograma As System.Windows.Forms.GroupBox
    Friend WithEvents RdVentanadeGenero As System.Windows.Forms.RadioButton
    Friend WithEvents RdUsuraCero As System.Windows.Forms.RadioButton
End Class
