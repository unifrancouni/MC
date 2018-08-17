<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnParametroCatalogoContable
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnParametroCatalogoContable))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.cboFuentes = New C1.Win.C1List.C1Combo
        Me.lblFuente = New System.Windows.Forms.Label
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpdatos.SuspendLayout()
        CType(Me.cboFuentes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(212, 90)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 8
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(287, 90)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.cboFuentes)
        Me.grpdatos.Controls.Add(Me.lblFuente)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(346, 72)
        Me.grpdatos.TabIndex = 10
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'cboFuentes
        '
        Me.cboFuentes.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFuentes.Caption = ""
        Me.cboFuentes.CaptionHeight = 17
        Me.cboFuentes.CaptionStyle = Style1
        Me.cboFuentes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFuentes.ColumnCaptionHeight = 17
        Me.cboFuentes.ColumnFooterHeight = 17
        Me.cboFuentes.ContentHeight = 15
        Me.cboFuentes.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFuentes.DisplayMember = "Descripcion"
        Me.cboFuentes.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFuentes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFuentes.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFuentes.EditorHeight = 15
        Me.cboFuentes.EvenRowStyle = Style2
        Me.cboFuentes.ExtendRightColumn = True
        Me.cboFuentes.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFuentes.FooterStyle = Style3
        Me.cboFuentes.GapHeight = 2
        Me.cboFuentes.HeadingStyle = Style4
        Me.cboFuentes.HighLightRowStyle = Style5
        Me.cboFuentes.Images.Add(CType(resources.GetObject("cboFuentes.Images"), System.Drawing.Image))
        Me.cboFuentes.ItemHeight = 15
        Me.cboFuentes.Location = New System.Drawing.Point(86, 28)
        Me.cboFuentes.MatchEntryTimeout = CType(2000, Long)
        Me.cboFuentes.MaxDropDownItems = CType(5, Short)
        Me.cboFuentes.MaxLength = 32767
        Me.cboFuentes.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFuentes.Name = "cboFuentes"
        Me.cboFuentes.OddRowStyle = Style6
        Me.cboFuentes.PartialRightColumn = False
        Me.cboFuentes.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFuentes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFuentes.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFuentes.SelectedStyle = Style7
        Me.cboFuentes.Size = New System.Drawing.Size(245, 21)
        Me.cboFuentes.Style = Style8
        Me.cboFuentes.TabIndex = 9
        Me.cboFuentes.PropBag = resources.GetString("cboFuentes.PropBag")
        '
        'lblFuente
        '
        Me.lblFuente.AutoSize = True
        Me.lblFuente.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFuente.Location = New System.Drawing.Point(18, 36)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(48, 13)
        Me.lblFuente.TabIndex = 7
        Me.lblFuente.Text = "Fuentes:"
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'frmScnParametroCatalogoContable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 126)
        Me.Controls.Add(Me.grpdatos)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Catálogo Contable")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnParametroCatalogoContable"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametros Reporte Catálogo Contable"
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        CType(Me.cboFuentes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents cboFuentes As C1.Win.C1List.C1Combo
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
