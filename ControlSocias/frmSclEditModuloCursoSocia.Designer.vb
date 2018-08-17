<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditModuloCursoSocia
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditModuloCursoSocia))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboModulos = New C1.Win.C1List.C1Combo()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        CType(Me.cboModulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccionar Módulo de Curso Aprobado: "
        '
        'cboModulos
        '
        Me.cboModulos.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboModulos.AutoCompletion = True
        Me.cboModulos.Caption = ""
        Me.cboModulos.CaptionHeight = 17
        Me.cboModulos.CaptionStyle = Style1
        Me.cboModulos.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModulos.ColumnCaptionHeight = 17
        Me.cboModulos.ColumnFooterHeight = 17
        Me.cboModulos.ContentHeight = 15
        Me.cboModulos.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModulos.DisplayMember = "Descripcion"
        Me.cboModulos.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboModulos.DropDownWidth = 250
        Me.cboModulos.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModulos.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModulos.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModulos.EditorHeight = 15
        Me.cboModulos.EvenRowStyle = Style2
        Me.cboModulos.ExtendRightColumn = True
        Me.cboModulos.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboModulos.FooterStyle = Style3
        Me.cboModulos.GapHeight = 2
        Me.cboModulos.HeadingStyle = Style4
        Me.cboModulos.HighLightRowStyle = Style5
        Me.cboModulos.Images.Add(CType(resources.GetObject("cboModulos.Images"), System.Drawing.Image))
        Me.cboModulos.ItemHeight = 15
        Me.cboModulos.LimitToList = True
        Me.cboModulos.Location = New System.Drawing.Point(12, 25)
        Me.cboModulos.MatchEntryTimeout = CType(2000, Long)
        Me.cboModulos.MaxDropDownItems = CType(5, Short)
        Me.cboModulos.MaxLength = 32767
        Me.cboModulos.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModulos.Name = "cboModulos"
        Me.cboModulos.OddRowStyle = Style6
        Me.cboModulos.PartialRightColumn = False
        Me.cboModulos.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModulos.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModulos.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModulos.SelectedStyle = Style7
        Me.cboModulos.Size = New System.Drawing.Size(280, 21)
        Me.cboModulos.Style = Style8
        Me.cboModulos.SuperBack = True
        Me.cboModulos.TabIndex = 1
        Me.cboModulos.ValueMember = "StbValorCatalogoID"
        Me.cboModulos.PropBag = resources.GetString("cboModulos.PropBag")
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(221, 52)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(149, 52)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 4
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmSclEditModuloCursoSocia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(298, 84)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cboModulos)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditModuloCursoSocia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Módulo de curso de Socia"
        CType(Me.cboModulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboModulos As C1.Win.C1List.C1Combo
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdAceptar As Button
End Class
