<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbEditReporte
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbEditReporte))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpBanco = New System.Windows.Forms.GroupBox
        Me.lblNombreTabla = New System.Windows.Forms.Label
        Me.txtNombreTabla = New System.Windows.Forms.TextBox
        Me.txtOrderByAdicional = New System.Windows.Forms.TextBox
        Me.lblOrderByAdicional = New System.Windows.Forms.Label
        Me.txtWhereAdicional = New System.Windows.Forms.TextBox
        Me.lblWhereAdicional = New System.Windows.Forms.Label
        Me.txtNombreArchivo = New System.Windows.Forms.TextBox
        Me.lblNombreArchivoRpt = New System.Windows.Forms.Label
        Me.txtTitulo = New System.Windows.Forms.TextBox
        Me.lblTitulo = New System.Windows.Forms.Label
        Me.lblModulo = New System.Windows.Forms.Label
        Me.cboModulo = New C1.Win.C1List.C1Combo
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.lblSiglas = New System.Windows.Forms.Label
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.errDocSoporte = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpBanco.SuspendLayout()
        CType(Me.cboModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errDocSoporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBanco
        '
        Me.grpBanco.Controls.Add(Me.lblNombreTabla)
        Me.grpBanco.Controls.Add(Me.txtNombreTabla)
        Me.grpBanco.Controls.Add(Me.txtOrderByAdicional)
        Me.grpBanco.Controls.Add(Me.lblOrderByAdicional)
        Me.grpBanco.Controls.Add(Me.txtWhereAdicional)
        Me.grpBanco.Controls.Add(Me.lblWhereAdicional)
        Me.grpBanco.Controls.Add(Me.txtNombreArchivo)
        Me.grpBanco.Controls.Add(Me.lblNombreArchivoRpt)
        Me.grpBanco.Controls.Add(Me.txtTitulo)
        Me.grpBanco.Controls.Add(Me.lblTitulo)
        Me.grpBanco.Controls.Add(Me.lblModulo)
        Me.grpBanco.Controls.Add(Me.cboModulo)
        Me.grpBanco.Controls.Add(Me.txtCodigo)
        Me.grpBanco.Controls.Add(Me.txtDescripcion)
        Me.grpBanco.Controls.Add(Me.lblSiglas)
        Me.grpBanco.Controls.Add(Me.lblDescripcion)
        Me.grpBanco.Location = New System.Drawing.Point(12, 12)
        Me.grpBanco.Name = "grpBanco"
        Me.grpBanco.Size = New System.Drawing.Size(526, 355)
        Me.grpBanco.TabIndex = 21
        Me.grpBanco.TabStop = False
        Me.grpBanco.Text = "Datos del Reporte"
        '
        'lblNombreTabla
        '
        Me.lblNombreTabla.AutoSize = True
        Me.lblNombreTabla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreTabla.Location = New System.Drawing.Point(12, 126)
        Me.lblNombreTabla.Name = "lblNombreTabla"
        Me.lblNombreTabla.Size = New System.Drawing.Size(103, 13)
        Me.lblNombreTabla.TabIndex = 46
        Me.lblNombreTabla.Text = "Nombre de la Tabla:"
        '
        'txtNombreTabla
        '
        Me.txtNombreTabla.Location = New System.Drawing.Point(128, 123)
        Me.txtNombreTabla.Name = "txtNombreTabla"
        Me.txtNombreTabla.Size = New System.Drawing.Size(237, 20)
        Me.txtNombreTabla.TabIndex = 5
        '
        'txtOrderByAdicional
        '
        Me.txtOrderByAdicional.Location = New System.Drawing.Point(128, 293)
        Me.txtOrderByAdicional.MaxLength = 200
        Me.txtOrderByAdicional.Multiline = True
        Me.txtOrderByAdicional.Name = "txtOrderByAdicional"
        Me.txtOrderByAdicional.Size = New System.Drawing.Size(378, 47)
        Me.txtOrderByAdicional.TabIndex = 8
        '
        'lblOrderByAdicional
        '
        Me.lblOrderByAdicional.AutoSize = True
        Me.lblOrderByAdicional.ForeColor = System.Drawing.Color.Black
        Me.lblOrderByAdicional.Location = New System.Drawing.Point(12, 296)
        Me.lblOrderByAdicional.Name = "lblOrderByAdicional"
        Me.lblOrderByAdicional.Size = New System.Drawing.Size(107, 13)
        Me.lblOrderByAdicional.TabIndex = 43
        Me.lblOrderByAdicional.Text = """Order By"" Adicional:"
        '
        'txtWhereAdicional
        '
        Me.txtWhereAdicional.Location = New System.Drawing.Point(128, 215)
        Me.txtWhereAdicional.MaxLength = 400
        Me.txtWhereAdicional.Multiline = True
        Me.txtWhereAdicional.Name = "txtWhereAdicional"
        Me.txtWhereAdicional.Size = New System.Drawing.Size(378, 72)
        Me.txtWhereAdicional.TabIndex = 7
        '
        'lblWhereAdicional
        '
        Me.lblWhereAdicional.AutoSize = True
        Me.lblWhereAdicional.ForeColor = System.Drawing.Color.Black
        Me.lblWhereAdicional.Location = New System.Drawing.Point(14, 218)
        Me.lblWhereAdicional.Name = "lblWhereAdicional"
        Me.lblWhereAdicional.Size = New System.Drawing.Size(101, 13)
        Me.lblWhereAdicional.TabIndex = 41
        Me.lblWhereAdicional.Text = """Where"" Adicional: "
        '
        'txtNombreArchivo
        '
        Me.txtNombreArchivo.Location = New System.Drawing.Point(128, 97)
        Me.txtNombreArchivo.MaxLength = 60
        Me.txtNombreArchivo.Name = "txtNombreArchivo"
        Me.txtNombreArchivo.Size = New System.Drawing.Size(237, 20)
        Me.txtNombreArchivo.TabIndex = 4
        '
        'lblNombreArchivoRpt
        '
        Me.lblNombreArchivoRpt.AutoSize = True
        Me.lblNombreArchivoRpt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreArchivoRpt.Location = New System.Drawing.Point(12, 100)
        Me.lblNombreArchivoRpt.Name = "lblNombreArchivoRpt"
        Me.lblNombreArchivoRpt.Size = New System.Drawing.Size(103, 13)
        Me.lblNombreArchivoRpt.TabIndex = 39
        Me.lblNombreArchivoRpt.Text = "Nombre del Archivo:"
        '
        'txtTitulo
        '
        Me.txtTitulo.Location = New System.Drawing.Point(128, 71)
        Me.txtTitulo.MaxLength = 150
        Me.txtTitulo.Name = "txtTitulo"
        Me.txtTitulo.Size = New System.Drawing.Size(322, 20)
        Me.txtTitulo.TabIndex = 3
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoSize = True
        Me.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTitulo.Location = New System.Drawing.Point(12, 74)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(36, 13)
        Me.lblTitulo.TabIndex = 37
        Me.lblTitulo.Text = "Titulo:"
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblModulo.Location = New System.Drawing.Point(12, 27)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(45, 13)
        Me.lblModulo.TabIndex = 36
        Me.lblModulo.Text = "Modulo:"
        '
        'cboModulo
        '
        Me.cboModulo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboModulo.AutoCompletion = True
        Me.cboModulo.Caption = ""
        Me.cboModulo.CaptionHeight = 17
        Me.cboModulo.CaptionStyle = Style9
        Me.cboModulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModulo.ColumnCaptionHeight = 17
        Me.cboModulo.ColumnFooterHeight = 17
        Me.cboModulo.ContentHeight = 15
        Me.cboModulo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModulo.DisplayMember = "Nombre"
        Me.cboModulo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboModulo.DropDownWidth = 237
        Me.cboModulo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModulo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModulo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModulo.EditorHeight = 15
        Me.cboModulo.EvenRowStyle = Style10
        Me.cboModulo.ExtendRightColumn = True
        Me.cboModulo.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboModulo.FooterStyle = Style11
        Me.cboModulo.GapHeight = 2
        Me.cboModulo.HeadingStyle = Style12
        Me.cboModulo.HighLightRowStyle = Style13
        Me.cboModulo.Images.Add(CType(resources.GetObject("cboModulo.Images"), System.Drawing.Image))
        Me.cboModulo.ItemHeight = 15
        Me.cboModulo.LimitToList = True
        Me.cboModulo.Location = New System.Drawing.Point(128, 18)
        Me.cboModulo.MatchEntryTimeout = CType(2000, Long)
        Me.cboModulo.MaxDropDownItems = CType(5, Short)
        Me.cboModulo.MaxLength = 32767
        Me.cboModulo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModulo.Name = "cboModulo"
        Me.cboModulo.OddRowStyle = Style14
        Me.cboModulo.PartialRightColumn = False
        Me.cboModulo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModulo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModulo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModulo.SelectedStyle = Style15
        Me.cboModulo.Size = New System.Drawing.Size(237, 21)
        Me.cboModulo.Style = Style16
        Me.cboModulo.SuperBack = True
        Me.cboModulo.TabIndex = 1
        Me.cboModulo.ValueMember = "SsgModuloID"
        Me.cboModulo.PropBag = resources.GetString("cboModulo.PropBag")
        '
        'txtCodigo
        '
        Me.txtCodigo.AcceptsTab = True
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(128, 45)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(43, 20)
        Me.txtCodigo.TabIndex = 2
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(128, 151)
        Me.txtDescripcion.MaxLength = 250
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(378, 58)
        Me.txtDescripcion.TabIndex = 6
        '
        'lblSiglas
        '
        Me.lblSiglas.AutoSize = True
        Me.lblSiglas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSiglas.Location = New System.Drawing.Point(12, 48)
        Me.lblSiglas.Name = "lblSiglas"
        Me.lblSiglas.Size = New System.Drawing.Size(43, 13)
        Me.lblSiglas.TabIndex = 1
        Me.lblSiglas.Text = "Código:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDescripcion.Location = New System.Drawing.Point(12, 154)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "Descripción:"
        '
        'errDocSoporte
        '
        Me.errDocSoporte.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(377, 373)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 4
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(465, 373)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmStbEditReporte
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(553, 403)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpBanco)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Reportes")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbEditReporte"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.grpBanco.ResumeLayout(False)
        Me.grpBanco.PerformLayout()
        CType(Me.cboModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errDocSoporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpBanco As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblSiglas As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents errDocSoporte As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboModulo As C1.Win.C1List.C1Combo
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblNombreArchivoRpt As System.Windows.Forms.Label
    Friend WithEvents txtTitulo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents lblWhereAdicional As System.Windows.Forms.Label
    Friend WithEvents txtWhereAdicional As System.Windows.Forms.TextBox
    Friend WithEvents txtOrderByAdicional As System.Windows.Forms.TextBox
    Friend WithEvents lblOrderByAdicional As System.Windows.Forms.Label
    Friend WithEvents txtNombreTabla As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreTabla As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider

End Class
