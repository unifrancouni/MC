<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditCajeros
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditCajeros))
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
        Me.grpCajero = New System.Windows.Forms.GroupBox
        Me.cboCajero = New C1.Win.C1List.C1Combo
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblNombre = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.errCajeroCajas = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpCajas = New System.Windows.Forms.GroupBox
        Me.cboCaja = New C1.Win.C1List.C1Combo
        Me.txtCodigoCaja = New System.Windows.Forms.TextBox
        Me.lblCaja = New System.Windows.Forms.Label
        Me.lblCodCaja = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpCajero.SuspendLayout()
        CType(Me.cboCajero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errCajeroCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpCajas.SuspendLayout()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpCajero
        '
        Me.grpCajero.Controls.Add(Me.cboCajero)
        Me.grpCajero.Controls.Add(Me.txtCodigo)
        Me.grpCajero.Controls.Add(Me.lblNombre)
        Me.grpCajero.Controls.Add(Me.lblCodigo)
        Me.grpCajero.Location = New System.Drawing.Point(12, 12)
        Me.grpCajero.Name = "grpCajero"
        Me.grpCajero.Size = New System.Drawing.Size(512, 87)
        Me.grpCajero.TabIndex = 21
        Me.grpCajero.TabStop = False
        Me.grpCajero.Text = "Datos del Cajero:"
        '
        'cboCajero
        '
        Me.cboCajero.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCajero.AutoCompletion = True
        Me.cboCajero.Caption = ""
        Me.cboCajero.CaptionHeight = 17
        Me.cboCajero.CaptionStyle = Style1
        Me.cboCajero.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCajero.ColumnCaptionHeight = 17
        Me.cboCajero.ColumnFooterHeight = 17
        Me.cboCajero.ContentHeight = 15
        Me.cboCajero.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCajero.DisplayMember = "sNombreEmpleado"
        Me.cboCajero.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCajero.DropDownWidth = 384
        Me.cboCajero.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCajero.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCajero.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCajero.EditorHeight = 15
        Me.cboCajero.EvenRowStyle = Style2
        Me.cboCajero.ExtendRightColumn = True
        Me.cboCajero.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCajero.FooterStyle = Style3
        Me.cboCajero.GapHeight = 2
        Me.cboCajero.HeadingStyle = Style4
        Me.cboCajero.HighLightRowStyle = Style5
        Me.cboCajero.Images.Add(CType(resources.GetObject("cboCajero.Images"), System.Drawing.Image))
        Me.cboCajero.ItemHeight = 15
        Me.cboCajero.LimitToList = True
        Me.cboCajero.Location = New System.Drawing.Point(101, 53)
        Me.cboCajero.MatchEntryTimeout = CType(2000, Long)
        Me.cboCajero.MaxDropDownItems = CType(5, Short)
        Me.cboCajero.MaxLength = 32767
        Me.cboCajero.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCajero.Name = "cboCajero"
        Me.cboCajero.OddRowStyle = Style6
        Me.cboCajero.PartialRightColumn = False
        Me.cboCajero.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCajero.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCajero.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCajero.SelectedStyle = Style7
        Me.cboCajero.Size = New System.Drawing.Size(399, 21)
        Me.cboCajero.Style = Style8
        Me.cboCajero.SuperBack = True
        Me.cboCajero.TabIndex = 24
        Me.cboCajero.ValueMember = "nSrhEmpleadoID"
        Me.cboCajero.PropBag = resources.GetString("cboCajero.PropBag")
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(101, 27)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(113, 20)
        Me.txtCodigo.TabIndex = 1
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(21, 56)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(80, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre Cajero:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(21, 27)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 23
        Me.lblCodigo.Text = "Código:"
        '
        'errCajeroCajas
        '
        Me.errCajeroCajas.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(374, 105)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 12
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(451, 105)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpCajas
        '
        Me.grpCajas.Controls.Add(Me.cboCaja)
        Me.grpCajas.Controls.Add(Me.txtCodigoCaja)
        Me.grpCajas.Controls.Add(Me.lblCaja)
        Me.grpCajas.Controls.Add(Me.lblCodCaja)
        Me.grpCajas.Location = New System.Drawing.Point(12, 12)
        Me.grpCajas.Name = "grpCajas"
        Me.grpCajas.Size = New System.Drawing.Size(512, 87)
        Me.grpCajas.TabIndex = 22
        Me.grpCajas.TabStop = False
        Me.grpCajas.Text = "Datos de la Caja:"
        '
        'cboCaja
        '
        Me.cboCaja.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCaja.AutoCompletion = True
        Me.cboCaja.Caption = ""
        Me.cboCaja.CaptionHeight = 17
        Me.cboCaja.CaptionStyle = Style9
        Me.cboCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCaja.ColumnCaptionHeight = 17
        Me.cboCaja.ColumnFooterHeight = 17
        Me.cboCaja.ContentHeight = 15
        Me.cboCaja.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCaja.DisplayMember = "sDescripcionCaja"
        Me.cboCaja.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCaja.DropDownWidth = 384
        Me.cboCaja.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCaja.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaja.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCaja.EditorHeight = 15
        Me.cboCaja.EvenRowStyle = Style10
        Me.cboCaja.ExtendRightColumn = True
        Me.cboCaja.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCaja.FooterStyle = Style11
        Me.cboCaja.GapHeight = 2
        Me.cboCaja.HeadingStyle = Style12
        Me.cboCaja.HighLightRowStyle = Style13
        Me.cboCaja.Images.Add(CType(resources.GetObject("cboCaja.Images"), System.Drawing.Image))
        Me.cboCaja.ItemHeight = 15
        Me.cboCaja.LimitToList = True
        Me.cboCaja.Location = New System.Drawing.Point(101, 53)
        Me.cboCaja.MatchEntryTimeout = CType(2000, Long)
        Me.cboCaja.MaxDropDownItems = CType(5, Short)
        Me.cboCaja.MaxLength = 32767
        Me.cboCaja.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCaja.Name = "cboCaja"
        Me.cboCaja.OddRowStyle = Style14
        Me.cboCaja.PartialRightColumn = False
        Me.cboCaja.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCaja.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCaja.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCaja.SelectedStyle = Style15
        Me.cboCaja.Size = New System.Drawing.Size(383, 21)
        Me.cboCaja.Style = Style16
        Me.cboCaja.SuperBack = True
        Me.cboCaja.TabIndex = 24
        Me.cboCaja.ValueMember = "nSteCajaID"
        Me.cboCaja.PropBag = resources.GetString("cboCaja.PropBag")
        '
        'txtCodigoCaja
        '
        Me.txtCodigoCaja.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoCaja.Enabled = False
        Me.txtCodigoCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoCaja.Location = New System.Drawing.Point(101, 27)
        Me.txtCodigoCaja.Name = "txtCodigoCaja"
        Me.txtCodigoCaja.ReadOnly = True
        Me.txtCodigoCaja.Size = New System.Drawing.Size(113, 20)
        Me.txtCodigoCaja.TabIndex = 1
        Me.txtCodigoCaja.Tag = "LAYOUT:FLAT"
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCaja.Location = New System.Drawing.Point(21, 56)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(71, 13)
        Me.lblCaja.TabIndex = 3
        Me.lblCaja.Text = "Nombre Caja:"
        '
        'lblCodCaja
        '
        Me.lblCodCaja.AutoSize = True
        Me.lblCodCaja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodCaja.Location = New System.Drawing.Point(21, 27)
        Me.lblCodCaja.Name = "lblCodCaja"
        Me.lblCodCaja.Size = New System.Drawing.Size(67, 13)
        Me.lblCodCaja.TabIndex = 23
        Me.lblCodCaja.Text = "Código Caja:"
        '
        'frmSteEditCajeros
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(533, 141)
        Me.Controls.Add(Me.grpCajas)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpCajero)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Cajeros")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditCajeros"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Cajeros/Cajas del Programa"
        Me.grpCajero.ResumeLayout(False)
        Me.grpCajero.PerformLayout()
        CType(Me.cboCajero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errCajeroCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpCajas.ResumeLayout(False)
        Me.grpCajas.PerformLayout()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpCajero As System.Windows.Forms.GroupBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents errCajeroCajas As System.Windows.Forms.ErrorProvider
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cboCajero As C1.Win.C1List.C1Combo
    Friend WithEvents grpCajas As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoCaja As System.Windows.Forms.TextBox
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblCodCaja As System.Windows.Forms.Label
    Friend WithEvents cboCaja As C1.Win.C1List.C1Combo
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
