<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditCierreDiarioCaja
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditCierreDiarioCaja))
        Me.errCierre = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpDatosGenerales = New System.Windows.Forms.GroupBox
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.cdeFechaCierre = New C1.Win.C1Input.C1DateEdit
        Me.cboCaja = New C1.Win.C1List.C1Combo
        Me.lblCaja = New System.Windows.Forms.Label
        Me.lblFechaCierre = New System.Windows.Forms.Label
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosGenerales.SuspendLayout()
        CType(Me.cdeFechaCierre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errCierre
        '
        Me.errCierre.ContainerControl = Me
        '
        'grpDatosGenerales
        '
        Me.grpDatosGenerales.Controls.Add(Me.txtObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.lblObservaciones)
        Me.grpDatosGenerales.Controls.Add(Me.cdeFechaCierre)
        Me.grpDatosGenerales.Controls.Add(Me.cboCaja)
        Me.grpDatosGenerales.Controls.Add(Me.lblCaja)
        Me.grpDatosGenerales.Controls.Add(Me.lblFechaCierre)
        Me.grpDatosGenerales.Location = New System.Drawing.Point(13, 12)
        Me.grpDatosGenerales.Name = "grpDatosGenerales"
        Me.grpDatosGenerales.Size = New System.Drawing.Size(449, 167)
        Me.grpDatosGenerales.TabIndex = 0
        Me.grpDatosGenerales.TabStop = False
        Me.grpDatosGenerales.Text = "Datos del Cierre Diario de Caja: "
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(126, 87)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(300, 65)
        Me.txtObservaciones.TabIndex = 2
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(22, 90)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 116
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'cdeFechaCierre
        '
        Me.cdeFechaCierre.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCierre.Location = New System.Drawing.Point(126, 52)
        Me.cdeFechaCierre.Name = "cdeFechaCierre"
        Me.cdeFechaCierre.Size = New System.Drawing.Size(127, 20)
        Me.cdeFechaCierre.TabIndex = 1
        Me.cdeFechaCierre.Tag = Nothing
        Me.cdeFechaCierre.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cboCaja
        '
        Me.cboCaja.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCaja.AutoCompletion = True
        Me.cboCaja.Caption = ""
        Me.cboCaja.CaptionHeight = 17
        Me.cboCaja.CaptionStyle = Style1
        Me.cboCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCaja.ColumnCaptionHeight = 17
        Me.cboCaja.ColumnFooterHeight = 17
        Me.cboCaja.ContentHeight = 15
        Me.cboCaja.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCaja.DisplayMember = "sDescripcionCaja"
        Me.cboCaja.DropDownWidth = 301
        Me.cboCaja.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCaja.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaja.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCaja.EditorHeight = 15
        Me.cboCaja.EvenRowStyle = Style2
        Me.cboCaja.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCaja.FooterStyle = Style3
        Me.cboCaja.GapHeight = 2
        Me.cboCaja.HeadingStyle = Style4
        Me.cboCaja.HighLightRowStyle = Style5
        Me.cboCaja.Images.Add(CType(resources.GetObject("cboCaja.Images"), System.Drawing.Image))
        Me.cboCaja.ItemHeight = 15
        Me.cboCaja.LimitToList = True
        Me.cboCaja.Location = New System.Drawing.Point(126, 19)
        Me.cboCaja.MatchEntryTimeout = CType(2000, Long)
        Me.cboCaja.MaxDropDownItems = CType(5, Short)
        Me.cboCaja.MaxLength = 32767
        Me.cboCaja.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCaja.Name = "cboCaja"
        Me.cboCaja.OddRowStyle = Style6
        Me.cboCaja.PartialRightColumn = False
        Me.cboCaja.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCaja.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCaja.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCaja.SelectedStyle = Style7
        Me.cboCaja.Size = New System.Drawing.Size(300, 21)
        Me.cboCaja.Style = Style8
        Me.cboCaja.SuperBack = True
        Me.cboCaja.TabIndex = 0
        Me.cboCaja.ValueMember = "nSteCajaID"
        Me.cboCaja.PropBag = resources.GetString("cboCaja.PropBag")
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCaja.Location = New System.Drawing.Point(22, 21)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(90, 13)
        Me.lblCaja.TabIndex = 3
        Me.lblCaja.Text = "Descripción Caja:"
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaCierre.Location = New System.Drawing.Point(22, 52)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(70, 13)
        Me.lblFechaCierre.TabIndex = 2
        Me.lblFechaCierre.Text = "Fecha Cierre:"
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(312, 185)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 0
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(389, 185)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSteEditCierreDiarioCaja
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(473, 218)
        Me.Controls.Add(Me.grpDatosGenerales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Cierre de Caja")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditCierreDiarioCaja"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Cierre Diario de Caja"
        CType(Me.errCierre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosGenerales.ResumeLayout(False)
        Me.grpDatosGenerales.PerformLayout()
        CType(Me.cdeFechaCierre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errCierre As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpDatosGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaCierre As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cboCaja As C1.Win.C1List.C1Combo
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
