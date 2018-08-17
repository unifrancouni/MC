<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccDescargaPorFuente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccDescargaPorFuente))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.GrpBPrincipal = New System.Windows.Forms.GroupBox
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpGenera = New System.Windows.Forms.GroupBox
        Me.CmbEnviar = New System.Windows.Forms.Button
        Me.CmbRefrescarUnidar = New System.Windows.Forms.Button
        Me.lblFecha = New System.Windows.Forms.Label
        Me.cbFuente = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRepresentante = New System.Windows.Forms.Label
        Me.cboUnidad = New System.Windows.Forms.ComboBox
        Me.cmbProcesar = New System.Windows.Forms.Button
        Me.cdeFechaGenera = New C1.Win.C1Input.C1DateEdit
        Me.grpPresentaProceso = New System.Windows.Forms.GroupBox
        Me.PrBarProceso = New System.Windows.Forms.ProgressBar
        Me.LblArchivo = New System.Windows.Forms.Label
        Me.LblConteo = New System.Windows.Forms.Label
        Me.gridGenerados = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ArchivoLocacion = New System.Windows.Forms.OpenFileDialog
        Me.DirUnidadBDLocal = New System.Windows.Forms.FolderBrowserDialog
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.GrpBPrincipal.SuspendLayout()
        Me.grpGenera.SuspendLayout()
        CType(Me.cbFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaGenera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPresentaProceso.SuspendLayout()
        CType(Me.gridGenerados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpBPrincipal
        '
        Me.GrpBPrincipal.Controls.Add(Me.cmdCancelar)
        Me.GrpBPrincipal.Controls.Add(Me.grpGenera)
        Me.GrpBPrincipal.Controls.Add(Me.grpPresentaProceso)
        Me.GrpBPrincipal.Controls.Add(Me.gridGenerados)
        Me.GrpBPrincipal.Location = New System.Drawing.Point(12, 2)
        Me.GrpBPrincipal.Name = "GrpBPrincipal"
        Me.GrpBPrincipal.Size = New System.Drawing.Size(682, 591)
        Me.GrpBPrincipal.TabIndex = 0
        Me.GrpBPrincipal.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(608, 552)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 25)
        Me.cmdCancelar.TabIndex = 59
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpGenera
        '
        Me.grpGenera.Controls.Add(Me.CmbEnviar)
        Me.grpGenera.Controls.Add(Me.CmbRefrescarUnidar)
        Me.grpGenera.Controls.Add(Me.lblFecha)
        Me.grpGenera.Controls.Add(Me.cbFuente)
        Me.grpGenera.Controls.Add(Me.Label1)
        Me.grpGenera.Controls.Add(Me.lblRepresentante)
        Me.grpGenera.Controls.Add(Me.cboUnidad)
        Me.grpGenera.Controls.Add(Me.cmbProcesar)
        Me.grpGenera.Controls.Add(Me.cdeFechaGenera)
        Me.grpGenera.Location = New System.Drawing.Point(3, 0)
        Me.grpGenera.Name = "grpGenera"
        Me.grpGenera.Size = New System.Drawing.Size(679, 116)
        Me.grpGenera.TabIndex = 60
        Me.grpGenera.TabStop = False
        '
        'CmbEnviar
        '
        Me.CmbEnviar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmbEnviar.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.CmbEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbEnviar.Location = New System.Drawing.Point(578, 83)
        Me.CmbEnviar.Name = "CmbEnviar"
        Me.CmbEnviar.Size = New System.Drawing.Size(82, 25)
        Me.CmbEnviar.TabIndex = 120
        Me.CmbEnviar.Text = "Enviar"
        Me.CmbEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbEnviar.UseVisualStyleBackColor = True
        '
        'CmbRefrescarUnidar
        '
        Me.CmbRefrescarUnidar.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.CmbRefrescarUnidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbRefrescarUnidar.Location = New System.Drawing.Point(402, 83)
        Me.CmbRefrescarUnidar.Name = "CmbRefrescarUnidar"
        Me.CmbRefrescarUnidar.Size = New System.Drawing.Size(82, 25)
        Me.CmbRefrescarUnidar.TabIndex = 55
        Me.CmbRefrescarUnidar.Text = "Listar USB"
        Me.CmbRefrescarUnidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbRefrescarUnidar.UseVisualStyleBackColor = True
        Me.CmbRefrescarUnidar.Visible = False
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(17, 20)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(95, 13)
        Me.lblFecha.TabIndex = 41
        Me.lblFecha.Text = "Fecha Generación"
        '
        'cbFuente
        '
        Me.cbFuente.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cbFuente.AutoCompletion = True
        Me.cbFuente.Caption = ""
        Me.cbFuente.CaptionHeight = 17
        Me.cbFuente.CaptionStyle = Style1
        Me.cbFuente.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cbFuente.ColumnCaptionHeight = 17
        Me.cbFuente.ColumnFooterHeight = 17
        Me.cbFuente.ContentHeight = 15
        Me.cbFuente.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cbFuente.DisplayMember = "sNombre"
        Me.cbFuente.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cbFuente.DropDownWidth = 386
        Me.cbFuente.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cbFuente.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbFuente.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cbFuente.EditorHeight = 15
        Me.cbFuente.Enabled = False
        Me.cbFuente.EvenRowStyle = Style2
        Me.cbFuente.ExtendRightColumn = True
        Me.cbFuente.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cbFuente.FooterStyle = Style3
        Me.cbFuente.GapHeight = 2
        Me.cbFuente.HeadingStyle = Style4
        Me.cbFuente.HighLightRowStyle = Style5
        Me.cbFuente.Images.Add(CType(resources.GetObject("cbFuente.Images"), System.Drawing.Image))
        Me.cbFuente.ItemHeight = 15
        Me.cbFuente.LimitToList = True
        Me.cbFuente.Location = New System.Drawing.Point(134, 42)
        Me.cbFuente.MatchEntryTimeout = CType(2000, Long)
        Me.cbFuente.MaxDropDownItems = CType(5, Short)
        Me.cbFuente.MaxLength = 32767
        Me.cbFuente.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cbFuente.Name = "cbFuente"
        Me.cbFuente.OddRowStyle = Style6
        Me.cbFuente.PartialRightColumn = False
        Me.cbFuente.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cbFuente.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cbFuente.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cbFuente.SelectedStyle = Style7
        Me.cbFuente.Size = New System.Drawing.Size(397, 21)
        Me.cbFuente.Style = Style8
        Me.cbFuente.SuperBack = True
        Me.cbFuente.TabIndex = 118
        Me.cbFuente.PropBag = resources.GetString("cbFuente.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(410, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Unidad Destino"
        Me.Label1.Visible = False
        '
        'lblRepresentante
        '
        Me.lblRepresentante.AutoSize = True
        Me.lblRepresentante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblRepresentante.Location = New System.Drawing.Point(17, 50)
        Me.lblRepresentante.Name = "lblRepresentante"
        Me.lblRepresentante.Size = New System.Drawing.Size(43, 13)
        Me.lblRepresentante.TabIndex = 119
        Me.lblRepresentante.Text = "Fuente:"
        '
        'cboUnidad
        '
        Me.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboUnidad.FormattingEnabled = True
        Me.cboUnidad.Location = New System.Drawing.Point(527, 13)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(133, 21)
        Me.cboUnidad.TabIndex = 48
        Me.cboUnidad.Visible = False
        '
        'cmbProcesar
        '
        Me.cmbProcesar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmbProcesar.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.cmbProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmbProcesar.Location = New System.Drawing.Point(490, 83)
        Me.cmbProcesar.Name = "cmbProcesar"
        Me.cmbProcesar.Size = New System.Drawing.Size(82, 25)
        Me.cmbProcesar.TabIndex = 42
        Me.cmbProcesar.Text = "Generar"
        Me.cmbProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbProcesar.UseVisualStyleBackColor = True
        '
        'cdeFechaGenera
        '
        Me.cdeFechaGenera.AcceptsEscape = False
        Me.cdeFechaGenera.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaGenera.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaGenera.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaGenera.Location = New System.Drawing.Point(134, 13)
        Me.cdeFechaGenera.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaGenera.MaskInfo.EmptyAsNull = True
        Me.cdeFechaGenera.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaGenera.Name = "cdeFechaGenera"
        Me.cdeFechaGenera.Size = New System.Drawing.Size(117, 20)
        Me.cdeFechaGenera.TabIndex = 40
        Me.cdeFechaGenera.Tag = Nothing
        Me.cdeFechaGenera.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'grpPresentaProceso
        '
        Me.grpPresentaProceso.Controls.Add(Me.PrBarProceso)
        Me.grpPresentaProceso.Controls.Add(Me.LblArchivo)
        Me.grpPresentaProceso.Controls.Add(Me.LblConteo)
        Me.grpPresentaProceso.Location = New System.Drawing.Point(3, 10)
        Me.grpPresentaProceso.Name = "grpPresentaProceso"
        Me.grpPresentaProceso.Size = New System.Drawing.Size(679, 106)
        Me.grpPresentaProceso.TabIndex = 61
        Me.grpPresentaProceso.TabStop = False
        '
        'PrBarProceso
        '
        Me.PrBarProceso.Location = New System.Drawing.Point(20, 78)
        Me.PrBarProceso.Name = "PrBarProceso"
        Me.PrBarProceso.Size = New System.Drawing.Size(659, 20)
        Me.PrBarProceso.TabIndex = 56
        '
        'LblArchivo
        '
        Me.LblArchivo.AutoSize = True
        Me.LblArchivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblArchivo.Location = New System.Drawing.Point(17, 62)
        Me.LblArchivo.Name = "LblArchivo"
        Me.LblArchivo.Size = New System.Drawing.Size(156, 13)
        Me.LblArchivo.TabIndex = 43
        Me.LblArchivo.Text = "Procesando Archivo _____.Xml"
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(17, 32)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(156, 13)
        Me.LblConteo.TabIndex = 42
        Me.LblConteo.Text = "__ De ___ Archivos Generados"
        '
        'gridGenerados
        '
        Me.gridGenerados.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.gridGenerados.AllowFilter = False
        Me.gridGenerados.AllowSort = False
        Me.gridGenerados.AllowUpdate = False
        Me.gridGenerados.Caption = "Cargas Generadas/Guardadas"
        Me.gridGenerados.GroupByAreaVisible = False
        Me.gridGenerados.GroupByCaption = "z"
        Me.gridGenerados.Images.Add(CType(resources.GetObject("gridGenerados.Images"), System.Drawing.Image))
        Me.gridGenerados.Location = New System.Drawing.Point(3, 122)
        Me.gridGenerados.Name = "gridGenerados"
        Me.gridGenerados.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridGenerados.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridGenerados.PreviewInfo.ZoomFactor = 75
        Me.gridGenerados.PrintInfo.PageSettings = CType(resources.GetObject("gridGenerados.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.gridGenerados.Size = New System.Drawing.Size(676, 424)
        Me.gridGenerados.TabIndex = 58
        Me.gridGenerados.PropBag = resources.GetString("gridGenerados.PropBag")
        '
        'FrmSccDescargaPorFuente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(698, 590)
        Me.Controls.Add(Me.GrpBPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSccDescargaPorFuente"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descarga de la Base de Datos"
        Me.GrpBPrincipal.ResumeLayout(False)
        Me.grpGenera.ResumeLayout(False)
        Me.grpGenera.PerformLayout()
        CType(Me.cbFuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaGenera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPresentaProceso.ResumeLayout(False)
        Me.grpPresentaProceso.PerformLayout()
        CType(Me.gridGenerados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents CmbRefrescarUnidar As System.Windows.Forms.Button
    Friend WithEvents PrBarProceso As System.Windows.Forms.ProgressBar
    Friend WithEvents LblArchivo As System.Windows.Forms.Label
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents cbFuente As C1.Win.C1List.C1Combo
    Friend WithEvents lblRepresentante As System.Windows.Forms.Label
    Friend WithEvents cmbProcesar As System.Windows.Forms.Button
    Friend WithEvents cdeFechaGenera As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridGenerados As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents grpGenera As System.Windows.Forms.GroupBox
    Friend WithEvents grpPresentaProceso As System.Windows.Forms.GroupBox
    Friend WithEvents CmbEnviar As System.Windows.Forms.Button
    Friend WithEvents ArchivoLocacion As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DirUnidadBDLocal As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
