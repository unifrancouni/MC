<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditSociaCreacionGS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditSociaCreacionGS))
        Me.errFormato = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboClasificacion = New C1.Win.C1List.C1Combo
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpDatos = New System.Windows.Forms.GroupBox
        Me.lblClasificacion = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboClasificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'errFormato
        '
        Me.errFormato.ContainerControl = Me
        '
        'cboClasificacion
        '
        Me.cboClasificacion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboClasificacion.AutoCompletion = True
        Me.cboClasificacion.Caption = ""
        Me.cboClasificacion.CaptionHeight = 17
        Me.cboClasificacion.CaptionStyle = Style1
        Me.cboClasificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboClasificacion.ColumnCaptionHeight = 17
        Me.cboClasificacion.ColumnFooterHeight = 17
        Me.cboClasificacion.ContentHeight = 15
        Me.cboClasificacion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboClasificacion.DisplayMember = "sDescripcion"
        Me.cboClasificacion.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboClasificacion.DropDownWidth = 345
        Me.cboClasificacion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboClasificacion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboClasificacion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboClasificacion.EditorHeight = 15
        Me.cboClasificacion.EvenRowStyle = Style2
        Me.cboClasificacion.ExtendRightColumn = True
        Me.cboClasificacion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboClasificacion.FooterStyle = Style3
        Me.cboClasificacion.GapHeight = 2
        Me.cboClasificacion.HeadingStyle = Style4
        Me.cboClasificacion.HighLightRowStyle = Style5
        Me.cboClasificacion.Images.Add(CType(resources.GetObject("cboClasificacion.Images"), System.Drawing.Image))
        Me.cboClasificacion.ItemHeight = 15
        Me.cboClasificacion.LimitToList = True
        Me.cboClasificacion.Location = New System.Drawing.Point(155, 29)
        Me.cboClasificacion.MatchEntryTimeout = CType(2000, Long)
        Me.cboClasificacion.MaxDropDownItems = CType(5, Short)
        Me.cboClasificacion.MaxLength = 32767
        Me.cboClasificacion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboClasificacion.Name = "cboClasificacion"
        Me.cboClasificacion.OddRowStyle = Style6
        Me.cboClasificacion.PartialRightColumn = False
        Me.cboClasificacion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboClasificacion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboClasificacion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboClasificacion.SelectedStyle = Style7
        Me.cboClasificacion.Size = New System.Drawing.Size(344, 21)
        Me.cboClasificacion.Style = Style8
        Me.cboClasificacion.SuperBack = True
        Me.cboClasificacion.TabIndex = 0
        Me.cboClasificacion.ValueMember = "nStbValorCatalogoID"
        Me.cboClasificacion.PropBag = resources.GetString("cboClasificacion.PropBag")
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(367, 94)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(444, 94)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.lblClasificacion)
        Me.grpDatos.Controls.Add(Me.cboClasificacion)
        Me.grpDatos.Location = New System.Drawing.Point(12, 10)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(505, 78)
        Me.grpDatos.TabIndex = 24
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Seleccione Tipo de Plan de Negocio:"
        '
        'lblClasificacion
        '
        Me.lblClasificacion.AutoSize = True
        Me.lblClasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClasificacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblClasificacion.Location = New System.Drawing.Point(21, 29)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.Size = New System.Drawing.Size(128, 13)
        Me.lblClasificacion.TabIndex = 28
        Me.lblClasificacion.Text = "Tipo de Plan de Negocio:"
        '
        'frmSclEditSociaCreacionGS
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(528, 132)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditSociaCreacionGS"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Creación de Crédito Individual"
        CType(Me.errFormato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboClasificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errFormato As System.Windows.Forms.ErrorProvider
    Friend WithEvents cboClasificacion As C1.Win.C1List.C1Combo
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblClasificacion As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
