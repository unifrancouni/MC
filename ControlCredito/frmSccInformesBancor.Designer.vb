<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccInformesBancor
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccInformesBancor))
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.cboMes = New C1.Win.C1List.C1Combo()
        Me.cboAño = New C1.Win.C1List.C1Combo()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboAño, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboMes
        '
        Me.cboMes.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboMes.AllowSort = False
        Me.cboMes.AutoCompletion = True
        Me.cboMes.Caption = ""
        Me.cboMes.CaptionHeight = 17
        Me.cboMes.CaptionStyle = Style17
        Me.cboMes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboMes.ColumnCaptionHeight = 17
        Me.cboMes.ColumnFooterHeight = 17
        Me.cboMes.ContentHeight = 15
        Me.cboMes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboMes.DisplayMember = "Descripcion"
        Me.cboMes.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboMes.DropDownWidth = 250
        Me.cboMes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboMes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboMes.EditorHeight = 15
        Me.cboMes.EvenRowStyle = Style18
        Me.cboMes.ExtendRightColumn = True
        Me.cboMes.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboMes.FooterStyle = Style19
        Me.cboMes.GapHeight = 2
        Me.cboMes.HeadingStyle = Style20
        Me.cboMes.HighLightRowStyle = Style21
        Me.cboMes.Images.Add(CType(resources.GetObject("cboMes.Images"), System.Drawing.Image))
        Me.cboMes.ItemHeight = 15
        Me.cboMes.Location = New System.Drawing.Point(65, 30)
        Me.cboMes.MatchEntryTimeout = CType(2000, Long)
        Me.cboMes.MaxDropDownItems = CType(5, Short)
        Me.cboMes.MaxLength = 32767
        Me.cboMes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboMes.Name = "cboMes"
        Me.cboMes.OddRowStyle = Style22
        Me.cboMes.PartialRightColumn = False
        Me.cboMes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboMes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboMes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboMes.SelectedStyle = Style23
        Me.cboMes.Size = New System.Drawing.Size(291, 21)
        Me.cboMes.Style = Style24
        Me.cboMes.TabIndex = 52
        Me.cboMes.PropBag = resources.GetString("cboMes.PropBag")
        '
        'cboAño
        '
        Me.cboAño.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboAño.AllowSort = False
        Me.cboAño.AutoCompletion = True
        Me.cboAño.Caption = ""
        Me.cboAño.CaptionHeight = 17
        Me.cboAño.CaptionStyle = Style25
        Me.cboAño.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboAño.ColumnCaptionHeight = 17
        Me.cboAño.ColumnFooterHeight = 17
        Me.cboAño.ContentHeight = 15
        Me.cboAño.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboAño.DisplayMember = "Descripcion"
        Me.cboAño.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboAño.DropDownWidth = 250
        Me.cboAño.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboAño.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAño.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboAño.EditorHeight = 15
        Me.cboAño.EvenRowStyle = Style26
        Me.cboAño.ExtendRightColumn = True
        Me.cboAño.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboAño.FooterStyle = Style27
        Me.cboAño.GapHeight = 2
        Me.cboAño.HeadingStyle = Style28
        Me.cboAño.HighLightRowStyle = Style29
        Me.cboAño.Images.Add(CType(resources.GetObject("cboAño.Images"), System.Drawing.Image))
        Me.cboAño.ItemHeight = 15
        Me.cboAño.Location = New System.Drawing.Point(65, 57)
        Me.cboAño.MatchEntryTimeout = CType(2000, Long)
        Me.cboAño.MaxDropDownItems = CType(5, Short)
        Me.cboAño.MaxLength = 32767
        Me.cboAño.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboAño.Name = "cboAño"
        Me.cboAño.OddRowStyle = Style30
        Me.cboAño.PartialRightColumn = False
        Me.cboAño.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboAño.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboAño.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboAño.SelectedStyle = Style31
        Me.cboAño.Size = New System.Drawing.Size(291, 21)
        Me.cboAño.Style = Style32
        Me.cboAño.TabIndex = 53
        Me.cboAño.PropBag = resources.GetString("cboAño.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCancelar)
        Me.GroupBox1.Controls.Add(Me.cmdAceptar)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboMes)
        Me.GroupBox1.Controls.Add(Me.cboAño)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 128)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione el Mes y el Año"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "Mes:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Año:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(210, 95)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 55
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(285, 95)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 56
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSccInformesBancor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 131)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccInformesBancor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informes BANCOR"
        CType(Me.cboMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboAño, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cboMes As C1.Win.C1List.C1Combo
    Friend WithEvents cboAño As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdCancelar As Button
End Class
