<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbParametroMoneda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbParametroMoneda))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.grbDestino = New System.Windows.Forms.GroupBox
        Me.radArchivo = New System.Windows.Forms.RadioButton
        Me.radImpresora = New System.Windows.Forms.RadioButton
        Me.RadioPant = New System.Windows.Forms.RadioButton
        Me.grbParametros = New System.Windows.Forms.GroupBox
        Me.cboEstado = New C1.Win.C1List.C1Combo
        Me.lblestado = New System.Windows.Forms.Label
        Me.Exportar = New System.Windows.Forms.SaveFileDialog
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grbDestino.SuspendLayout()
        Me.grbParametros.SuspendLayout()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(383, 134)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 10
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(306, 134)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 9
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'grbDestino
        '
        Me.grbDestino.Controls.Add(Me.radArchivo)
        Me.grbDestino.Controls.Add(Me.radImpresora)
        Me.grbDestino.Controls.Add(Me.RadioPant)
        Me.grbDestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDestino.Location = New System.Drawing.Point(12, 77)
        Me.grbDestino.Name = "grbDestino"
        Me.grbDestino.Size = New System.Drawing.Size(444, 51)
        Me.grbDestino.TabIndex = 12
        Me.grbDestino.TabStop = False
        Me.grbDestino.Text = "Destino del Reporte"
        '
        'radArchivo
        '
        Me.radArchivo.AutoSize = True
        Me.radArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radArchivo.Location = New System.Drawing.Point(191, 19)
        Me.radArchivo.Name = "radArchivo"
        Me.radArchivo.Size = New System.Drawing.Size(61, 17)
        Me.radArchivo.TabIndex = 2
        Me.radArchivo.Text = "Archivo"
        Me.radArchivo.UseVisualStyleBackColor = True
        '
        'radImpresora
        '
        Me.radImpresora.AutoSize = True
        Me.radImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radImpresora.Location = New System.Drawing.Point(95, 19)
        Me.radImpresora.Name = "radImpresora"
        Me.radImpresora.Size = New System.Drawing.Size(71, 17)
        Me.radImpresora.TabIndex = 1
        Me.radImpresora.Text = "Impresora"
        Me.radImpresora.UseVisualStyleBackColor = True
        '
        'RadioPant
        '
        Me.RadioPant.AutoSize = True
        Me.RadioPant.Checked = True
        Me.RadioPant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioPant.Location = New System.Drawing.Point(6, 18)
        Me.RadioPant.Name = "RadioPant"
        Me.RadioPant.Size = New System.Drawing.Size(63, 17)
        Me.RadioPant.TabIndex = 0
        Me.RadioPant.TabStop = True
        Me.RadioPant.Text = "Pantalla"
        Me.RadioPant.UseVisualStyleBackColor = True
        '
        'grbParametros
        '
        Me.grbParametros.Controls.Add(Me.cboEstado)
        Me.grbParametros.Controls.Add(Me.lblestado)
        Me.grbParametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbParametros.Location = New System.Drawing.Point(12, 12)
        Me.grbParametros.Name = "grbParametros"
        Me.grbParametros.Size = New System.Drawing.Size(444, 59)
        Me.grbParametros.TabIndex = 13
        Me.grbParametros.TabStop = False
        Me.grbParametros.Text = "Filtro de Datos Por"
        '
        'cboEstado
        '
        Me.cboEstado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEstado.AllowSort = False
        Me.cboEstado.AutoCompletion = True
        Me.cboEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.cboEstado.Caption = ""
        Me.cboEstado.CaptionHeight = 17
        Me.cboEstado.CaptionStyle = Style1
        Me.cboEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEstado.ColumnCaptionHeight = 17
        Me.cboEstado.ColumnFooterHeight = 17
        Me.cboEstado.ContentHeight = 15
        Me.cboEstado.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboEstado.DisplayMember = "Estado"
        Me.cboEstado.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboEstado.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboEstado.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEstado.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEstado.EditorHeight = 15
        Me.cboEstado.EvenRowStyle = Style2
        Me.cboEstado.ExtendRightColumn = True
        Me.cboEstado.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEstado.FooterStyle = Style3
        Me.cboEstado.GapHeight = 2
        Me.cboEstado.HeadingStyle = Style4
        Me.cboEstado.HighLightRowStyle = Style5
        Me.cboEstado.Images.Add(CType(resources.GetObject("cboEstado.Images"), System.Drawing.Image))
        Me.cboEstado.ItemHeight = 15
        Me.cboEstado.Location = New System.Drawing.Point(84, 19)
        Me.cboEstado.MatchEntryTimeout = CType(2000, Long)
        Me.cboEstado.MaxDropDownItems = CType(5, Short)
        Me.cboEstado.MaxLength = 32767
        Me.cboEstado.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEstado.Name = "cboEstado"
        Me.cboEstado.OddRowStyle = Style6
        Me.cboEstado.PartialRightColumn = False
        Me.cboEstado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEstado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEstado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEstado.SelectedStyle = Style7
        Me.cboEstado.Size = New System.Drawing.Size(168, 19)
        Me.cboEstado.Style = Style8
        Me.cboEstado.TabIndex = 3
        Me.cboEstado.ValueMember = "IdEstadoC"
        Me.cboEstado.PropBag = resources.GetString("cboEstado.PropBag")
        '
        'lblestado
        '
        Me.lblestado.AutoSize = True
        Me.lblestado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblestado.Location = New System.Drawing.Point(11, 25)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(43, 13)
        Me.lblestado.TabIndex = 2
        Me.lblestado.Text = "Estado:"
        '
        'frmStbParametroMoneda
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(468, 173)
        Me.Controls.Add(Me.grbDestino)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grbParametros)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes  Módulo de Catálogos Básicos")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbParametroMoneda"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSteParametroReporte"
        Me.grbDestino.ResumeLayout(False)
        Me.grbDestino.PerformLayout()
        Me.grbParametros.ResumeLayout(False)
        Me.grbParametros.PerformLayout()
        CType(Me.cboEstado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grbDestino As System.Windows.Forms.GroupBox
    Friend WithEvents radArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents radImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents RadioPant As System.Windows.Forms.RadioButton
    Friend WithEvents grbParametros As System.Windows.Forms.GroupBox
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents cboEstado As C1.Win.C1List.C1Combo
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
