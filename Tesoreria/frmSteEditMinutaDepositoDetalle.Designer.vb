<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSteEditMinutaDepositoDetalle
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditMinutaDepositoDetalle))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.cneMonto = New C1.Win.C1Input.C1NumericEdit()
        Me.txtNoDeposito = New System.Windows.Forms.TextBox()
        Me.lblNumeroDeposito = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboPersonaJuridica = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdMinuta = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.tbMinuta = New System.Windows.Forms.ToolStrip()
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton()
        Me.toolModificar = New System.Windows.Forms.ToolStripButton()
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton()
        Me.errMinuta = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboPersonaJuridica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdMinuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMinuta.SuspendLayout()
        CType(Me.errMinuta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cneMonto
        '
        Me.cneMonto.AcceptsTab = True
        Me.cneMonto.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMonto.DataType = GetType(Double)
        Me.cneMonto.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneMonto.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMonto.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMonto.EditFormat.EmptyAsNull = False
        Me.cneMonto.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMonto.EmptyAsNull = True
        Me.cneMonto.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMonto.Location = New System.Drawing.Point(113, 59)
        Me.cneMonto.MaskInfo.AutoTabWhenFilled = True
        Me.cneMonto.MaxLength = 999999999
        Me.cneMonto.Name = "cneMonto"
        Me.cneMonto.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMonto.Size = New System.Drawing.Size(127, 20)
        Me.cneMonto.TabIndex = 116
        Me.cneMonto.Tag = Nothing
        Me.cneMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMonto.UseColumnStyles = False
        Me.cneMonto.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txtNoDeposito
        '
        Me.txtNoDeposito.Location = New System.Drawing.Point(113, 26)
        Me.txtNoDeposito.Name = "txtNoDeposito"
        Me.txtNoDeposito.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNoDeposito.Size = New System.Drawing.Size(190, 20)
        Me.txtNoDeposito.TabIndex = 115
        Me.txtNoDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNumeroDeposito
        '
        Me.lblNumeroDeposito.AutoSize = True
        Me.lblNumeroDeposito.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumeroDeposito.Location = New System.Drawing.Point(22, 38)
        Me.lblNumeroDeposito.Name = "lblNumeroDeposito"
        Me.lblNumeroDeposito.Size = New System.Drawing.Size(77, 13)
        Me.lblNumeroDeposito.TabIndex = 118
        Me.lblNumeroDeposito.Text = "No. de Minuta:"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMonto.Location = New System.Drawing.Point(9, 62)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(101, 13)
        Me.lblMonto.TabIndex = 117
        Me.lblMonto.Text = "Monto Depósito C$:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboPersonaJuridica)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cneMonto)
        Me.GroupBox1.Controls.Add(Me.lblMonto)
        Me.GroupBox1.Controls.Add(Me.txtNoDeposito)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 148)
        Me.GroupBox1.TabIndex = 119
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Deposito"
        '
        'cboPersonaJuridica
        '
        Me.cboPersonaJuridica.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboPersonaJuridica.AutoCompletion = True
        Me.cboPersonaJuridica.Caption = ""
        Me.cboPersonaJuridica.CaptionHeight = 17
        Me.cboPersonaJuridica.CaptionStyle = Style9
        Me.cboPersonaJuridica.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPersonaJuridica.ColumnCaptionHeight = 17
        Me.cboPersonaJuridica.ColumnFooterHeight = 17
        Me.cboPersonaJuridica.ContentHeight = 15
        Me.cboPersonaJuridica.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPersonaJuridica.DisplayMember = "sNombreInstitucion"
        Me.cboPersonaJuridica.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboPersonaJuridica.DropDownWidth = 191
        Me.cboPersonaJuridica.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPersonaJuridica.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPersonaJuridica.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPersonaJuridica.EditorHeight = 15
        Me.cboPersonaJuridica.EvenRowStyle = Style10
        Me.cboPersonaJuridica.ExtendRightColumn = True
        Me.cboPersonaJuridica.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboPersonaJuridica.FooterStyle = Style11
        Me.cboPersonaJuridica.GapHeight = 2
        Me.cboPersonaJuridica.HeadingStyle = Style12
        Me.cboPersonaJuridica.HighLightRowStyle = Style13
        Me.cboPersonaJuridica.Images.Add(CType(resources.GetObject("cboPersonaJuridica.Images"), System.Drawing.Image))
        Me.cboPersonaJuridica.ItemHeight = 15
        Me.cboPersonaJuridica.LimitToList = True
        Me.cboPersonaJuridica.Location = New System.Drawing.Point(113, 92)
        Me.cboPersonaJuridica.MatchEntryTimeout = CType(2000, Long)
        Me.cboPersonaJuridica.MaxDropDownItems = CType(5, Short)
        Me.cboPersonaJuridica.MaxLength = 32767
        Me.cboPersonaJuridica.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPersonaJuridica.Name = "cboPersonaJuridica"
        Me.cboPersonaJuridica.OddRowStyle = Style14
        Me.cboPersonaJuridica.PartialRightColumn = False
        Me.cboPersonaJuridica.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPersonaJuridica.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPersonaJuridica.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPersonaJuridica.SelectedStyle = Style15
        Me.cboPersonaJuridica.Size = New System.Drawing.Size(190, 21)
        Me.cboPersonaJuridica.Style = Style16
        Me.cboPersonaJuridica.SuperBack = True
        Me.cboPersonaJuridica.TabIndex = 125
        Me.cboPersonaJuridica.ValueMember = "nStbMunicipioID"
        Me.cboPersonaJuridica.PropBag = resources.GetString("cboPersonaJuridica.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 100)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Lugar de Déposito:"
        '
        'grdMinuta
        '
        Me.grdMinuta.AllowFilter = False
        Me.grdMinuta.AllowUpdate = False
        Me.grdMinuta.Caption = "Listado de Minutas de Depósito Detalle"
        Me.grdMinuta.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdMinuta.FilterBar = True
        Me.grdMinuta.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdMinuta.Images.Add(CType(resources.GetObject("grdMinuta.Images"), System.Drawing.Image))
        Me.grdMinuta.Location = New System.Drawing.Point(13, 182)
        Me.grdMinuta.Name = "grdMinuta"
        Me.grdMinuta.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdMinuta.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdMinuta.PreviewInfo.ZoomFactor = 75.0R
        Me.grdMinuta.PrintInfo.PageSettings = CType(resources.GetObject("grdMinuta.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdMinuta.Size = New System.Drawing.Size(450, 180)
        Me.grdMinuta.TabIndex = 120
        Me.grdMinuta.Text = "grdCtaBancaria"
        Me.grdMinuta.PropBag = resources.GetString("grdMinuta.PropBag")
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(404, 364)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 122
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(326, 366)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 121
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'tbMinuta
        '
        Me.tbMinuta.Dock = System.Windows.Forms.DockStyle.None
        Me.tbMinuta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolAgregar, Me.toolModificar, Me.toolEliminar})
        Me.tbMinuta.Location = New System.Drawing.Point(16, 154)
        Me.tbMinuta.Name = "tbMinuta"
        Me.tbMinuta.Size = New System.Drawing.Size(112, 25)
        Me.tbMinuta.Stretch = True
        Me.tbMinuta.TabIndex = 123
        Me.tbMinuta.Text = "ToolStrip1"
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'toolEliminar
        '
        Me.toolEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminar.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminar.Name = "toolEliminar"
        Me.toolEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminar.Text = "Eliminar"
        '
        'errMinuta
        '
        Me.errMinuta.ContainerControl = Me
        '
        'frmSteEditMinutaDepositoDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(488, 398)
        Me.Controls.Add(Me.tbMinuta)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grdMinuta)
        Me.Controls.Add(Me.lblNumeroDeposito)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditMinutaDepositoDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Minuta Deposito Detalle"
        CType(Me.cneMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cboPersonaJuridica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdMinuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMinuta.ResumeLayout(False)
        Me.tbMinuta.PerformLayout()
        CType(Me.errMinuta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cneMonto As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents txtNoDeposito As TextBox
    Friend WithEvents lblNumeroDeposito As Label
    Friend WithEvents lblMonto As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents grdMinuta As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents CmdAceptar As Button
    Friend WithEvents tbMinuta As ToolStrip
    Friend WithEvents toolAgregar As ToolStripButton
    Friend WithEvents toolModificar As ToolStripButton
    Friend WithEvents toolEliminar As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cboPersonaJuridica As C1.Win.C1List.C1Combo
    Friend WithEvents errMinuta As ErrorProvider
End Class
