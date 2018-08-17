<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditActividadEconomica
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
        Me.components = New System.ComponentModel.Container()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditActividadEconomica))
        Me.errFormato = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cboClasificacion = New C1.Win.C1List.C1Combo()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblClasificacion = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.ckNVT = New System.Windows.Forms.CheckBox()
        Me.ckVT = New System.Windows.Forms.CheckBox()
        Me.ckT = New System.Windows.Forms.CheckBox()
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
        Me.cboClasificacion.DropDownWidth = 194
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
        Me.cboClasificacion.Location = New System.Drawing.Point(100, 46)
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
        Me.cboClasificacion.Size = New System.Drawing.Size(388, 21)
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
        Me.CmdAceptar.Location = New System.Drawing.Point(366, 190)
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
        Me.cmdCancelar.Location = New System.Drawing.Point(443, 190)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 13
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.ckT)
        Me.grpDatos.Controls.Add(Me.ckVT)
        Me.grpDatos.Controls.Add(Me.ckNVT)
        Me.grpDatos.Controls.Add(Me.txtDescripcion)
        Me.grpDatos.Controls.Add(Me.Label1)
        Me.grpDatos.Controls.Add(Me.lblClasificacion)
        Me.grpDatos.Controls.Add(Me.txtNombre)
        Me.grpDatos.Controls.Add(Me.lblDescripcion)
        Me.grpDatos.Controls.Add(Me.cboClasificacion)
        Me.grpDatos.Controls.Add(Me.lblCodigo)
        Me.grpDatos.Controls.Add(Me.txtCodigo)
        Me.grpDatos.Location = New System.Drawing.Point(11, 10)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(505, 174)
        Me.grpDatos.TabIndex = 24
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Datos Generales: "
        '
        'txtDescripcion
        '
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Location = New System.Drawing.Point(101, 99)
        Me.txtDescripcion.MaxLength = 200
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(387, 43)
        Me.txtDescripcion.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(7, 102)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Descripcion:"
        '
        'lblClasificacion
        '
        Me.lblClasificacion.AutoSize = True
        Me.lblClasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClasificacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblClasificacion.Location = New System.Drawing.Point(4, 46)
        Me.lblClasificacion.Name = "lblClasificacion"
        Me.lblClasificacion.Size = New System.Drawing.Size(69, 13)
        Me.lblClasificacion.TabIndex = 28
        Me.lblClasificacion.Text = "Clasificación:"
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(101, 73)
        Me.txtNombre.MaxLength = 200
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(387, 20)
        Me.txtNombre.TabIndex = 27
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDescripcion.Location = New System.Drawing.Point(26, 76)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(47, 13)
        Me.lblDescripcion.TabIndex = 26
        Me.lblDescripcion.Text = "Nombre:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(30, 20)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 25
        Me.lblCodigo.Text = "Código:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(101, 20)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.Size = New System.Drawing.Size(387, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'ckNVT
        '
        Me.ckNVT.AutoSize = True
        Me.ckNVT.Location = New System.Drawing.Point(110, 151)
        Me.ckNVT.Name = "ckNVT"
        Me.ckNVT.Size = New System.Drawing.Size(48, 17)
        Me.ckNVT.TabIndex = 31
        Me.ckNVT.Text = "NVT"
        Me.ckNVT.UseVisualStyleBackColor = True
        '
        'ckVT
        '
        Me.ckVT.AutoSize = True
        Me.ckVT.Location = New System.Drawing.Point(223, 151)
        Me.ckVT.Name = "ckVT"
        Me.ckVT.Size = New System.Drawing.Size(40, 17)
        Me.ckVT.TabIndex = 32
        Me.ckVT.Text = "VT"
        Me.ckVT.UseVisualStyleBackColor = True
        '
        'ckT
        '
        Me.ckT.AutoSize = True
        Me.ckT.Location = New System.Drawing.Point(334, 151)
        Me.ckT.Name = "ckT"
        Me.ckT.Size = New System.Drawing.Size(33, 17)
        Me.ckT.TabIndex = 33
        Me.ckT.Text = "T"
        Me.ckT.UseVisualStyleBackColor = True
        '
        'frmSclEditActividadEconomica
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(524, 220)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditActividadEconomica"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Actividad Económica"
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
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblClasificacion As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ckT As CheckBox
    Friend WithEvents ckVT As CheckBox
    Friend WithEvents ckNVT As CheckBox
End Class
