<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnSeleccionPeriodoContable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnSeleccionPeriodoContable))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.grpPeriodo = New System.Windows.Forms.GroupBox()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.cboPeriodoContable = New C1.Win.C1List.C1Combo()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.grpPeriodo.SuspendLayout()
        CType(Me.cboPeriodoContable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpPeriodo
        '
        Me.grpPeriodo.Controls.Add(Me.lblPeriodo)
        Me.grpPeriodo.Controls.Add(Me.cboPeriodoContable)
        Me.grpPeriodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.grpPeriodo.Location = New System.Drawing.Point(1, 0)
        Me.grpPeriodo.Name = "grpPeriodo"
        Me.grpPeriodo.Size = New System.Drawing.Size(436, 65)
        Me.grpPeriodo.TabIndex = 0
        Me.grpPeriodo.TabStop = False
        Me.grpPeriodo.Text = "Seleccionar Período"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPeriodo.Location = New System.Drawing.Point(65, 26)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(92, 13)
        Me.lblPeriodo.TabIndex = 53
        Me.lblPeriodo.Text = "Período contable:"
        '
        'cboPeriodoContable
        '
        Me.cboPeriodoContable.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboPeriodoContable.AllowSort = False
        Me.cboPeriodoContable.AutoCompletion = True
        Me.cboPeriodoContable.Caption = ""
        Me.cboPeriodoContable.CaptionHeight = 17
        Me.cboPeriodoContable.CaptionStyle = Style1
        Me.cboPeriodoContable.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPeriodoContable.ColumnCaptionHeight = 17
        Me.cboPeriodoContable.ColumnFooterHeight = 17
        Me.cboPeriodoContable.ContentHeight = 15
        Me.cboPeriodoContable.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPeriodoContable.DisplayMember = "Descripcion"
        Me.cboPeriodoContable.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboPeriodoContable.DropDownWidth = 250
        Me.cboPeriodoContable.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPeriodoContable.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPeriodoContable.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPeriodoContable.EditorHeight = 15
        Me.cboPeriodoContable.EvenRowStyle = Style2
        Me.cboPeriodoContable.ExtendRightColumn = True
        Me.cboPeriodoContable.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboPeriodoContable.FooterStyle = Style3
        Me.cboPeriodoContable.GapHeight = 2
        Me.cboPeriodoContable.HeadingStyle = Style4
        Me.cboPeriodoContable.HighLightRowStyle = Style5
        Me.cboPeriodoContable.Images.Add(CType(resources.GetObject("cboPeriodoContable.Images"), System.Drawing.Image))
        Me.cboPeriodoContable.ItemHeight = 15
        Me.cboPeriodoContable.Location = New System.Drawing.Point(158, 24)
        Me.cboPeriodoContable.MatchEntryTimeout = CType(2000, Long)
        Me.cboPeriodoContable.MaxDropDownItems = CType(5, Short)
        Me.cboPeriodoContable.MaxLength = 32767
        Me.cboPeriodoContable.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPeriodoContable.Name = "cboPeriodoContable"
        Me.cboPeriodoContable.OddRowStyle = Style6
        Me.cboPeriodoContable.PartialRightColumn = False
        Me.cboPeriodoContable.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPeriodoContable.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPeriodoContable.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPeriodoContable.SelectedStyle = Style7
        Me.cboPeriodoContable.Size = New System.Drawing.Size(264, 21)
        Me.cboPeriodoContable.Style = Style8
        Me.cboPeriodoContable.TabIndex = 52
        Me.cboPeriodoContable.PropBag = resources.GetString("cboPeriodoContable.PropBag")
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(291, 71)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 54
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(366, 71)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 55
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmScnSeleccionPeriodoContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 102)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpPeriodo)
        Me.Controls.Add(Me.cmdCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnSeleccionPeriodoContable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de Período Contable"
        Me.grpPeriodo.ResumeLayout(False)
        Me.grpPeriodo.PerformLayout()
        CType(Me.cboPeriodoContable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpPeriodo As GroupBox
    Friend WithEvents cboPeriodoContable As C1.Win.C1List.C1Combo
    Friend WithEvents lblPeriodo As Label
    Friend WithEvents cmdAceptar As Button
    Friend WithEvents cmdCancelar As Button
End Class
