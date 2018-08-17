<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteParametrosRecibosAnulados
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
        Me.components = New System.ComponentModel.Container
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteParametrosRecibosAnulados))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpFiltro = New System.Windows.Forms.GroupBox
        Me.cboPrograma = New C1.Win.C1List.C1Combo
        Me.lblPrograma = New System.Windows.Forms.Label
        Me.cboDelegacion = New C1.Win.C1List.C1Combo
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboCajero = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaHasta = New System.Windows.Forms.Label
        Me.lblFechaDesde = New System.Windows.Forms.Label
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpFiltro.SuspendLayout()
        CType(Me.cboPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDelegacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFiltro
        '
        Me.grpFiltro.Controls.Add(Me.cboPrograma)
        Me.grpFiltro.Controls.Add(Me.lblPrograma)
        Me.grpFiltro.Controls.Add(Me.cboDelegacion)
        Me.grpFiltro.Controls.Add(Me.Label2)
        Me.grpFiltro.Controls.Add(Me.CboCajero)
        Me.grpFiltro.Controls.Add(Me.Label1)
        Me.grpFiltro.Controls.Add(Me.CdeFechaFinal)
        Me.grpFiltro.Controls.Add(Me.cdeFechaInicial)
        Me.grpFiltro.Controls.Add(Me.lblFechaHasta)
        Me.grpFiltro.Controls.Add(Me.lblFechaDesde)
        Me.grpFiltro.Location = New System.Drawing.Point(13, 13)
        Me.grpFiltro.Name = "grpFiltro"
        Me.grpFiltro.Size = New System.Drawing.Size(356, 156)
        Me.grpFiltro.TabIndex = 4
        Me.grpFiltro.TabStop = False
        Me.grpFiltro.Text = "Filtro de Datos por:"
        '
        'cboPrograma
        '
        Me.cboPrograma.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboPrograma.AllowSort = False
        Me.cboPrograma.AutoCompletion = True
        Me.cboPrograma.Caption = ""
        Me.cboPrograma.CaptionHeight = 17
        Me.cboPrograma.CaptionStyle = Style1
        Me.cboPrograma.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPrograma.ColumnCaptionHeight = 17
        Me.cboPrograma.ColumnFooterHeight = 17
        Me.cboPrograma.ContentHeight = 15
        Me.cboPrograma.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPrograma.DisplayMember = "sDescripcion"
        Me.cboPrograma.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboPrograma.DropDownWidth = 242
        Me.cboPrograma.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPrograma.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPrograma.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPrograma.EditorHeight = 15
        Me.cboPrograma.EvenRowStyle = Style2
        Me.cboPrograma.ExtendRightColumn = True
        Me.cboPrograma.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboPrograma.FooterStyle = Style3
        Me.cboPrograma.GapHeight = 2
        Me.cboPrograma.HeadingStyle = Style4
        Me.cboPrograma.HighLightRowStyle = Style5
        Me.cboPrograma.Images.Add(CType(resources.GetObject("cboPrograma.Images"), System.Drawing.Image))
        Me.cboPrograma.ItemHeight = 15
        Me.cboPrograma.Location = New System.Drawing.Point(92, 109)
        Me.cboPrograma.MatchEntryTimeout = CType(2000, Long)
        Me.cboPrograma.MaxDropDownItems = CType(5, Short)
        Me.cboPrograma.MaxLength = 32767
        Me.cboPrograma.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPrograma.Name = "cboPrograma"
        Me.cboPrograma.OddRowStyle = Style6
        Me.cboPrograma.PartialRightColumn = False
        Me.cboPrograma.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPrograma.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPrograma.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPrograma.SelectedStyle = Style7
        Me.cboPrograma.Size = New System.Drawing.Size(249, 21)
        Me.cboPrograma.Style = Style8
        Me.cboPrograma.TabIndex = 78
        Me.cboPrograma.ValueMember = "nStbValorCatalogoID"
        Me.cboPrograma.PropBag = resources.GetString("cboPrograma.PropBag")
        '
        'lblPrograma
        '
        Me.lblPrograma.AutoSize = True
        Me.lblPrograma.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPrograma.Location = New System.Drawing.Point(15, 117)
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Size = New System.Drawing.Size(55, 13)
        Me.lblPrograma.TabIndex = 79
        Me.lblPrograma.Text = "Programa:"
        '
        'cboDelegacion
        '
        Me.cboDelegacion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDelegacion.AllowSort = False
        Me.cboDelegacion.AutoCompletion = True
        Me.cboDelegacion.Caption = ""
        Me.cboDelegacion.CaptionHeight = 17
        Me.cboDelegacion.CaptionStyle = Style9
        Me.cboDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDelegacion.ColumnCaptionHeight = 17
        Me.cboDelegacion.ColumnFooterHeight = 17
        Me.cboDelegacion.ContentHeight = 15
        Me.cboDelegacion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDelegacion.DisplayMember = "sNombreDelegacion"
        Me.cboDelegacion.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDelegacion.DropDownWidth = 242
        Me.cboDelegacion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDelegacion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDelegacion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDelegacion.EditorHeight = 15
        Me.cboDelegacion.EvenRowStyle = Style10
        Me.cboDelegacion.ExtendRightColumn = True
        Me.cboDelegacion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDelegacion.FooterStyle = Style11
        Me.cboDelegacion.GapHeight = 2
        Me.cboDelegacion.HeadingStyle = Style12
        Me.cboDelegacion.HighLightRowStyle = Style13
        Me.cboDelegacion.Images.Add(CType(resources.GetObject("cboDelegacion.Images"), System.Drawing.Image))
        Me.cboDelegacion.ItemHeight = 15
        Me.cboDelegacion.Location = New System.Drawing.Point(92, 55)
        Me.cboDelegacion.MatchEntryTimeout = CType(2000, Long)
        Me.cboDelegacion.MaxDropDownItems = CType(5, Short)
        Me.cboDelegacion.MaxLength = 32767
        Me.cboDelegacion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDelegacion.Name = "cboDelegacion"
        Me.cboDelegacion.OddRowStyle = Style14
        Me.cboDelegacion.PartialRightColumn = False
        Me.cboDelegacion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDelegacion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDelegacion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDelegacion.SelectedStyle = Style15
        Me.cboDelegacion.Size = New System.Drawing.Size(249, 21)
        Me.cboDelegacion.Style = Style16
        Me.cboDelegacion.TabIndex = 63
        Me.cboDelegacion.ValueMember = "nStbDelegacionProgramaID"
        Me.cboDelegacion.PropBag = resources.GetString("cboDelegacion.PropBag")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(15, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Delegación:"
        '
        'CboCajero
        '
        Me.CboCajero.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CboCajero.AllowSort = False
        Me.CboCajero.AutoCompletion = True
        Me.CboCajero.Caption = ""
        Me.CboCajero.CaptionHeight = 17
        Me.CboCajero.CaptionStyle = Style17
        Me.CboCajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CboCajero.ColumnCaptionHeight = 17
        Me.CboCajero.ColumnFooterHeight = 17
        Me.CboCajero.ContentHeight = 15
        Me.CboCajero.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CboCajero.DisplayMember = "sNombreEmpleado"
        Me.CboCajero.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.CboCajero.DropDownWidth = 242
        Me.CboCajero.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CboCajero.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboCajero.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CboCajero.EditorHeight = 15
        Me.CboCajero.EvenRowStyle = Style18
        Me.CboCajero.ExtendRightColumn = True
        Me.CboCajero.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.CboCajero.FooterStyle = Style19
        Me.CboCajero.GapHeight = 2
        Me.CboCajero.HeadingStyle = Style20
        Me.CboCajero.HighLightRowStyle = Style21
        Me.CboCajero.Images.Add(CType(resources.GetObject("CboCajero.Images"), System.Drawing.Image))
        Me.CboCajero.ItemHeight = 15
        Me.CboCajero.Location = New System.Drawing.Point(92, 82)
        Me.CboCajero.MatchEntryTimeout = CType(2000, Long)
        Me.CboCajero.MaxDropDownItems = CType(5, Short)
        Me.CboCajero.MaxLength = 32767
        Me.CboCajero.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CboCajero.Name = "CboCajero"
        Me.CboCajero.OddRowStyle = Style22
        Me.CboCajero.PartialRightColumn = False
        Me.CboCajero.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CboCajero.SelectedStyle = Style23
        Me.CboCajero.Size = New System.Drawing.Size(249, 21)
        Me.CboCajero.Style = Style24
        Me.CboCajero.TabIndex = 61
        Me.CboCajero.ValueMember = "nSrhEmpleadoID"
        Me.CboCajero.PropBag = resources.GetString("CboCajero.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Cajero:"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(241, 26)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(100, 20)
        Me.CdeFechaFinal.TabIndex = 57
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
        Me.cdeFechaInicial.Location = New System.Drawing.Point(92, 26)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(105, 20)
        Me.cdeFechaInicial.TabIndex = 56
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaHasta
        '
        Me.lblFechaHasta.AutoSize = True
        Me.lblFechaHasta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaHasta.Location = New System.Drawing.Point(200, 33)
        Me.lblFechaHasta.Name = "lblFechaHasta"
        Me.lblFechaHasta.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaHasta.TabIndex = 59
        Me.lblFechaHasta.Text = "Hasta:"
        '
        'lblFechaDesde
        '
        Me.lblFechaDesde.AutoSize = True
        Me.lblFechaDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaDesde.Location = New System.Drawing.Point(15, 33)
        Me.lblFechaDesde.Name = "lblFechaDesde"
        Me.lblFechaDesde.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaDesde.TabIndex = 58
        Me.lblFechaDesde.Text = "Fecha Desde:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(225, 175)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 2
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(298, 175)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'frmSteParametrosRecibosAnulados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 214)
        Me.Controls.Add(Me.grpFiltro)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Name = "frmSteParametrosRecibosAnulados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSteParametrosRecibosAnulados"
        Me.grpFiltro.ResumeLayout(False)
        Me.grpFiltro.PerformLayout()
        CType(Me.cboPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDelegacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CboCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents grpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaHasta As System.Windows.Forms.Label
    Friend WithEvents lblFechaDesde As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDelegacion As C1.Win.C1List.C1Combo
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPrograma As C1.Win.C1List.C1Combo
    Friend WithEvents lblPrograma As System.Windows.Forms.Label
    Friend WithEvents CboCajero As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
End Class
