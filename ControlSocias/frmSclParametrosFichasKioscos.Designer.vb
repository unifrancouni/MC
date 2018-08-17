<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclParametrosFichasKioscos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclParametrosFichasKioscos))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpRangoFechas = New System.Windows.Forms.GroupBox()
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit()
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit()
        Me.LblHasta = New System.Windows.Forms.Label()
        Me.LblDesde = New System.Windows.Forms.Label()
        Me.CboDelegacion = New C1.Win.C1List.C1Combo()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.grpNivelDetalle = New System.Windows.Forms.GroupBox()
        Me.ckBarrios = New System.Windows.Forms.CheckBox()
        Me.ckDistritos = New System.Windows.Forms.CheckBox()
        Me.ckMunicipios = New System.Windows.Forms.CheckBox()
        Me.ckDepartamentos = New System.Windows.Forms.CheckBox()
        Me.ckEdecanes = New System.Windows.Forms.CheckBox()
        Me.grpRangoFechas.SuspendLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboDelegacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpNivelDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpRangoFechas
        '
        Me.grpRangoFechas.Controls.Add(Me.CdeFechaFinal)
        Me.grpRangoFechas.Controls.Add(Me.cdeFechaInicial)
        Me.grpRangoFechas.Controls.Add(Me.LblHasta)
        Me.grpRangoFechas.Controls.Add(Me.LblDesde)
        Me.grpRangoFechas.Location = New System.Drawing.Point(13, 45)
        Me.grpRangoFechas.Margin = New System.Windows.Forms.Padding(4)
        Me.grpRangoFechas.Name = "grpRangoFechas"
        Me.grpRangoFechas.Padding = New System.Windows.Forms.Padding(4)
        Me.grpRangoFechas.Size = New System.Drawing.Size(557, 76)
        Me.grpRangoFechas.TabIndex = 63
        Me.grpRangoFechas.TabStop = False
        Me.grpRangoFechas.Text = "Período"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(347, 34)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(183, 22)
        Me.CdeFechaFinal.TabIndex = 2
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
        Me.cdeFechaInicial.Location = New System.Drawing.Point(91, 34)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(164, 22)
        Me.cdeFechaInicial.TabIndex = 1
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'LblHasta
        '
        Me.LblHasta.AutoSize = True
        Me.LblHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblHasta.Location = New System.Drawing.Point(292, 38)
        Me.LblHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblHasta.Name = "LblHasta"
        Me.LblHasta.Size = New System.Drawing.Size(49, 17)
        Me.LblHasta.TabIndex = 63
        Me.LblHasta.Text = "Hasta:"
        '
        'LblDesde
        '
        Me.LblDesde.AutoSize = True
        Me.LblDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblDesde.Location = New System.Drawing.Point(17, 38)
        Me.LblDesde.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LblDesde.Name = "LblDesde"
        Me.LblDesde.Size = New System.Drawing.Size(53, 17)
        Me.LblDesde.TabIndex = 62
        Me.LblDesde.Text = "Desde:"
        '
        'CboDelegacion
        '
        Me.CboDelegacion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboDelegacion.AllowSort = False
        Me.CboDelegacion.AutoCompletion = True
        Me.CboDelegacion.Caption = ""
        Me.CboDelegacion.CaptionHeight = 17
        Me.CboDelegacion.CaptionStyle = Style9
        Me.CboDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboDelegacion.ColumnCaptionHeight = 17
        Me.CboDelegacion.ColumnFooterHeight = 17
        Me.CboDelegacion.ContentHeight = 18
        Me.CboDelegacion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboDelegacion.DisplayMember = "Descripcion"
        Me.CboDelegacion.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboDelegacion.DropDownWidth = 250
        Me.CboDelegacion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboDelegacion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboDelegacion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboDelegacion.EditorHeight = 18
        Me.CboDelegacion.EvenRowStyle = Style10
        Me.CboDelegacion.ExtendRightColumn = True
        Me.CboDelegacion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboDelegacion.FooterStyle = Style11
        Me.CboDelegacion.GapHeight = 2
        Me.CboDelegacion.HeadingStyle = Style12
        Me.CboDelegacion.HighLightRowStyle = Style13
        Me.CboDelegacion.Images.Add(CType(resources.GetObject("CboDelegacion.Images"), System.Drawing.Image))
        Me.CboDelegacion.ItemHeight = 15
        Me.CboDelegacion.Location = New System.Drawing.Point(135, 13)
        Me.CboDelegacion.Margin = New System.Windows.Forms.Padding(4)
        Me.CboDelegacion.MatchEntryTimeout = CType(2000, Long)
        Me.CboDelegacion.MaxDropDownItems = CType(5, Short)
        Me.CboDelegacion.MaxLength = 32767
        Me.CboDelegacion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboDelegacion.Name = "CboDelegacion"
        Me.CboDelegacion.OddRowStyle = Style14
        Me.CboDelegacion.PartialRightColumn = False
        Me.CboDelegacion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboDelegacion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboDelegacion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboDelegacion.SelectedStyle = Style15
        Me.CboDelegacion.Size = New System.Drawing.Size(408, 24)
        Me.CboDelegacion.Style = Style16
        Me.CboDelegacion.TabIndex = 0
        Me.CboDelegacion.PropBag = resources.GetString("CboDelegacion.PropBag")
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDepartamento.Location = New System.Drawing.Point(30, 13)
        Me.lblDepartamento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(83, 17)
        Me.lblDepartamento.TabIndex = 62
        Me.lblDepartamento.Text = "Delegación:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(375, 195)
        Me.cmdAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(92, 33)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(475, 195)
        Me.cmdCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(95, 33)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpNivelDetalle
        '
        Me.grpNivelDetalle.Controls.Add(Me.ckEdecanes)
        Me.grpNivelDetalle.Controls.Add(Me.ckBarrios)
        Me.grpNivelDetalle.Controls.Add(Me.ckDistritos)
        Me.grpNivelDetalle.Controls.Add(Me.ckMunicipios)
        Me.grpNivelDetalle.Controls.Add(Me.ckDepartamentos)
        Me.grpNivelDetalle.Enabled = False
        Me.grpNivelDetalle.Location = New System.Drawing.Point(13, 129)
        Me.grpNivelDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.grpNivelDetalle.Name = "grpNivelDetalle"
        Me.grpNivelDetalle.Padding = New System.Windows.Forms.Padding(4)
        Me.grpNivelDetalle.Size = New System.Drawing.Size(557, 58)
        Me.grpNivelDetalle.TabIndex = 73
        Me.grpNivelDetalle.TabStop = False
        Me.grpNivelDetalle.Text = "Nivel de detalle"
        '
        'ckBarrios
        '
        Me.ckBarrios.AutoSize = True
        Me.ckBarrios.Checked = True
        Me.ckBarrios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBarrios.Location = New System.Drawing.Point(339, 28)
        Me.ckBarrios.Margin = New System.Windows.Forms.Padding(4)
        Me.ckBarrios.Name = "ckBarrios"
        Me.ckBarrios.Size = New System.Drawing.Size(75, 21)
        Me.ckBarrios.TabIndex = 10
        Me.ckBarrios.Text = "Barrios"
        Me.ckBarrios.UseVisualStyleBackColor = True
        '
        'ckDistritos
        '
        Me.ckDistritos.AutoSize = True
        Me.ckDistritos.Checked = True
        Me.ckDistritos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckDistritos.Location = New System.Drawing.Point(250, 28)
        Me.ckDistritos.Margin = New System.Windows.Forms.Padding(4)
        Me.ckDistritos.Name = "ckDistritos"
        Me.ckDistritos.Size = New System.Drawing.Size(81, 21)
        Me.ckDistritos.TabIndex = 9
        Me.ckDistritos.Text = "Distritos"
        Me.ckDistritos.UseVisualStyleBackColor = True
        '
        'ckMunicipios
        '
        Me.ckMunicipios.AutoSize = True
        Me.ckMunicipios.Checked = True
        Me.ckMunicipios.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckMunicipios.Location = New System.Drawing.Point(146, 28)
        Me.ckMunicipios.Margin = New System.Windows.Forms.Padding(4)
        Me.ckMunicipios.Name = "ckMunicipios"
        Me.ckMunicipios.Size = New System.Drawing.Size(96, 21)
        Me.ckMunicipios.TabIndex = 8
        Me.ckMunicipios.Text = "Municipios"
        Me.ckMunicipios.UseVisualStyleBackColor = True
        '
        'ckDepartamentos
        '
        Me.ckDepartamentos.AutoSize = True
        Me.ckDepartamentos.Checked = True
        Me.ckDepartamentos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckDepartamentos.Location = New System.Drawing.Point(11, 28)
        Me.ckDepartamentos.Margin = New System.Windows.Forms.Padding(4)
        Me.ckDepartamentos.Name = "ckDepartamentos"
        Me.ckDepartamentos.Size = New System.Drawing.Size(127, 21)
        Me.ckDepartamentos.TabIndex = 7
        Me.ckDepartamentos.Text = "Departamentos"
        Me.ckDepartamentos.UseVisualStyleBackColor = True
        '
        'ckEdecanes
        '
        Me.ckEdecanes.AutoSize = True
        Me.ckEdecanes.Checked = True
        Me.ckEdecanes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckEdecanes.Location = New System.Drawing.Point(422, 28)
        Me.ckEdecanes.Margin = New System.Windows.Forms.Padding(4)
        Me.ckEdecanes.Name = "ckEdecanes"
        Me.ckEdecanes.Size = New System.Drawing.Size(93, 21)
        Me.ckEdecanes.TabIndex = 11
        Me.ckEdecanes.Text = "Edecanes"
        Me.ckEdecanes.UseVisualStyleBackColor = True
        '
        'frmSclParametrosFichasKioscos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 237)
        Me.Controls.Add(Me.grpNivelDetalle)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpRangoFechas)
        Me.Controls.Add(Me.CboDelegacion)
        Me.Controls.Add(Me.lblDepartamento)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclParametrosFichasKioscos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros Fichas de Inscripción - Kioscos"
        Me.grpRangoFechas.ResumeLayout(False)
        Me.grpRangoFechas.PerformLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboDelegacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpNivelDetalle.ResumeLayout(False)
        Me.grpNivelDetalle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grpRangoFechas As GroupBox
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents LblHasta As Label
    Friend WithEvents LblDesde As Label
    Friend WithEvents CboDelegacion As C1.Win.C1List.C1Combo
    Friend WithEvents lblDepartamento As Label
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents grpNivelDetalle As GroupBox
    Friend WithEvents ckBarrios As CheckBox
    Friend WithEvents ckDistritos As CheckBox
    Friend WithEvents ckMunicipios As CheckBox
    Friend WithEvents ckDepartamentos As CheckBox
    Friend WithEvents ckEdecanes As CheckBox
End Class
