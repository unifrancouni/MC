<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCodigoFicha = New System.Windows.Forms.TextBox()
        Me.lblCodigoRC = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboParentesco = New C1.Win.C1List.C1Combo()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSegundoApellido = New System.Windows.Forms.TextBox()
        Me.txtPrimerApellido = New System.Windows.Forms.TextBox()
        Me.txtSegundoNombre = New System.Windows.Forms.TextBox()
        Me.txtPrimerNombre = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cboParentesco, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCodigoFicha)
        Me.GroupBox1.Controls.Add(Me.lblCodigoRC)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 47)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Actuales"
        '
        'txtCodigoFicha
        '
        Me.txtCodigoFicha.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigoFicha.Enabled = False
        Me.txtCodigoFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoFicha.Location = New System.Drawing.Point(173, 18)
        Me.txtCodigoFicha.Name = "txtCodigoFicha"
        Me.txtCodigoFicha.ReadOnly = True
        Me.txtCodigoFicha.ShortcutsEnabled = False
        Me.txtCodigoFicha.Size = New System.Drawing.Size(194, 20)
        Me.txtCodigoFicha.TabIndex = 36
        Me.txtCodigoFicha.Tag = "LAYOUT:FLAT"
        '
        'lblCodigoRC
        '
        Me.lblCodigoRC.AutoSize = True
        Me.lblCodigoRC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoRC.Location = New System.Drawing.Point(95, 21)
        Me.lblCodigoRC.Name = "lblCodigoRC"
        Me.lblCodigoRC.Size = New System.Drawing.Size(72, 13)
        Me.lblCodigoRC.TabIndex = 35
        Me.lblCodigoRC.Text = "Código Ficha:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(376, 221)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 65
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(299, 221)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 64
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboParentesco)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.mtbNumCedula)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtSegundoApellido)
        Me.GroupBox2.Controls.Add(Me.txtPrimerApellido)
        Me.GroupBox2.Controls.Add(Me.txtSegundoNombre)
        Me.GroupBox2.Controls.Add(Me.txtPrimerNombre)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(446, 159)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos:"
        '
        'cboParentesco
        '
        Me.cboParentesco.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboParentesco.AutoCompletion = True
        Me.cboParentesco.Caption = ""
        Me.cboParentesco.CaptionHeight = 17
        Me.cboParentesco.CaptionStyle = Style1
        Me.cboParentesco.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboParentesco.ColumnCaptionHeight = 17
        Me.cboParentesco.ColumnFooterHeight = 17
        Me.cboParentesco.ContentHeight = 15
        Me.cboParentesco.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboParentesco.DisplayMember = "Descripcion"
        Me.cboParentesco.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboParentesco.DropDownWidth = 146
        Me.cboParentesco.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboParentesco.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboParentesco.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboParentesco.EditorHeight = 15
        Me.cboParentesco.EvenRowStyle = Style2
        Me.cboParentesco.ExtendRightColumn = True
        Me.cboParentesco.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboParentesco.FooterStyle = Style3
        Me.cboParentesco.GapHeight = 2
        Me.cboParentesco.HeadingStyle = Style4
        Me.cboParentesco.HighLightRowStyle = Style5
        Me.cboParentesco.Images.Add(CType(resources.GetObject("cboParentesco.Images"), System.Drawing.Image))
        Me.cboParentesco.ItemHeight = 15
        Me.cboParentesco.LimitToList = True
        Me.cboParentesco.Location = New System.Drawing.Point(311, 123)
        Me.cboParentesco.MatchEntryTimeout = CType(2000, Long)
        Me.cboParentesco.MaxDropDownItems = CType(5, Short)
        Me.cboParentesco.MaxLength = 32767
        Me.cboParentesco.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboParentesco.Name = "cboParentesco"
        Me.cboParentesco.OddRowStyle = Style6
        Me.cboParentesco.PartialRightColumn = False
        Me.cboParentesco.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboParentesco.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboParentesco.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboParentesco.SelectedStyle = Style7
        Me.cboParentesco.Size = New System.Drawing.Size(125, 21)
        Me.cboParentesco.Style = Style8
        Me.cboParentesco.SuperBack = True
        Me.cboParentesco.TabIndex = 59
        Me.cboParentesco.ValueMember = "StbValorCatalogoID"
        Me.cboParentesco.PropBag = resources.GetString("cboParentesco.PropBag")
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(213, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Parentesco:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(99, 124)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(108, 20)
        Me.mtbNumCedula.TabIndex = 57
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(4, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Número de cédula:"
        '
        'txtSegundoApellido
        '
        Me.txtSegundoApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSegundoApellido.Location = New System.Drawing.Point(311, 72)
        Me.txtSegundoApellido.Name = "txtSegundoApellido"
        Me.txtSegundoApellido.Size = New System.Drawing.Size(125, 20)
        Me.txtSegundoApellido.TabIndex = 55
        '
        'txtPrimerApellido
        '
        Me.txtPrimerApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrimerApellido.Location = New System.Drawing.Point(99, 72)
        Me.txtPrimerApellido.Name = "txtPrimerApellido"
        Me.txtPrimerApellido.Size = New System.Drawing.Size(108, 20)
        Me.txtPrimerApellido.TabIndex = 54
        '
        'txtSegundoNombre
        '
        Me.txtSegundoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSegundoNombre.Location = New System.Drawing.Point(310, 19)
        Me.txtSegundoNombre.Name = "txtSegundoNombre"
        Me.txtSegundoNombre.Size = New System.Drawing.Size(126, 20)
        Me.txtSegundoNombre.TabIndex = 53
        '
        'txtPrimerNombre
        '
        Me.txtPrimerNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrimerNombre.Location = New System.Drawing.Point(99, 19)
        Me.txtPrimerNombre.Name = "txtPrimerNombre"
        Me.txtPrimerNombre.Size = New System.Drawing.Size(108, 20)
        Me.txtPrimerNombre.TabIndex = 52
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(213, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Segundo apellido:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(9, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Primer apellido:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(213, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Segundo nombre:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Primer nombre:"
        '
        'frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 252)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cboParentesco, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoFicha As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoRC As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboParentesco As C1.Win.C1List.C1Combo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents txtPrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents txtSegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtPrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
