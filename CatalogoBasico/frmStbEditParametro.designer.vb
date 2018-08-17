<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbEditParametro
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbEditParametro))
        Me.grpBanco = New System.Windows.Forms.GroupBox
        Me.dtpFechaFin = New C1.Win.C1Input.C1DateEdit
        Me.dtpFechaInicio = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaFin = New System.Windows.Forms.Label
        Me.lblFechaInicio = New System.Windows.Forms.Label
        Me.lstTipoDato = New System.Windows.Forms.ListBox
        Me.lblTipoDato = New System.Windows.Forms.Label
        Me.txtValorParametro = New System.Windows.Forms.TextBox
        Me.lblValor = New System.Windows.Forms.Label
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.lblActivo = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.lblSiglas = New System.Windows.Forms.Label
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.errDocSoporte = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpBanco.SuspendLayout()
        CType(Me.dtpFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errDocSoporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBanco
        '
        Me.grpBanco.Controls.Add(Me.dtpFechaFin)
        Me.grpBanco.Controls.Add(Me.dtpFechaInicio)
        Me.grpBanco.Controls.Add(Me.lblFechaFin)
        Me.grpBanco.Controls.Add(Me.lblFechaInicio)
        Me.grpBanco.Controls.Add(Me.lstTipoDato)
        Me.grpBanco.Controls.Add(Me.lblTipoDato)
        Me.grpBanco.Controls.Add(Me.txtValorParametro)
        Me.grpBanco.Controls.Add(Me.lblValor)
        Me.grpBanco.Controls.Add(Me.chkActivo)
        Me.grpBanco.Controls.Add(Me.lblActivo)
        Me.grpBanco.Controls.Add(Me.txtCodigo)
        Me.grpBanco.Controls.Add(Me.txtDescripcion)
        Me.grpBanco.Controls.Add(Me.lblSiglas)
        Me.grpBanco.Controls.Add(Me.lblDescripcion)
        Me.grpBanco.Location = New System.Drawing.Point(12, 12)
        Me.grpBanco.Name = "grpBanco"
        Me.grpBanco.Size = New System.Drawing.Size(490, 214)
        Me.grpBanco.TabIndex = 21
        Me.grpBanco.TabStop = False
        Me.grpBanco.Text = "Datos del Parámetro"
        '
        'dtpFechaFin
        '
        Me.dtpFechaFin.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtpFechaFin.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.dtpFechaFin.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtpFechaFin.Location = New System.Drawing.Point(91, 163)
        Me.dtpFechaFin.MaskInfo.AutoTabWhenFilled = True
        Me.dtpFechaFin.MaskInfo.EmptyAsNull = True
        Me.dtpFechaFin.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.dtpFechaFin.Name = "dtpFechaFin"
        Me.dtpFechaFin.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaFin.TabIndex = 6
        Me.dtpFechaFin.Tag = Nothing
        Me.dtpFechaFin.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtpFechaInicio.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.dtpFechaInicio.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.dtpFechaInicio.Location = New System.Drawing.Point(91, 136)
        Me.dtpFechaInicio.MaskInfo.AutoTabWhenFilled = True
        Me.dtpFechaInicio.MaskInfo.EmptyAsNull = True
        Me.dtpFechaInicio.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(109, 20)
        Me.dtpFechaInicio.TabIndex = 5
        Me.dtpFechaInicio.Tag = Nothing
        Me.dtpFechaInicio.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaFin
        '
        Me.lblFechaFin.AutoSize = True
        Me.lblFechaFin.Location = New System.Drawing.Point(19, 166)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(57, 13)
        Me.lblFechaFin.TabIndex = 106
        Me.lblFechaFin.Tag = "NONE"
        Me.lblFechaFin.Text = "Fecha Fin:"
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.AutoSize = True
        Me.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaInicio.Location = New System.Drawing.Point(19, 139)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(68, 13)
        Me.lblFechaInicio.TabIndex = 104
        Me.lblFechaInicio.Text = "Fehca Inicio:"
        '
        'lstTipoDato
        '
        Me.lstTipoDato.FormattingEnabled = True
        Me.lstTipoDato.Location = New System.Drawing.Point(91, 109)
        Me.lstTipoDato.Name = "lstTipoDato"
        Me.lstTipoDato.Size = New System.Drawing.Size(109, 17)
        Me.lstTipoDato.TabIndex = 4
        '
        'lblTipoDato
        '
        Me.lblTipoDato.AutoSize = True
        Me.lblTipoDato.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTipoDato.Location = New System.Drawing.Point(19, 113)
        Me.lblTipoDato.Name = "lblTipoDato"
        Me.lblTipoDato.Size = New System.Drawing.Size(72, 13)
        Me.lblTipoDato.TabIndex = 102
        Me.lblTipoDato.Text = "Tipo de Dato:"
        '
        'txtValorParametro
        '
        Me.txtValorParametro.Location = New System.Drawing.Point(91, 54)
        Me.txtValorParametro.Name = "txtValorParametro"
        Me.txtValorParametro.Size = New System.Drawing.Size(268, 20)
        Me.txtValorParametro.TabIndex = 2
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(19, 57)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(34, 13)
        Me.lblValor.TabIndex = 100
        Me.lblValor.Text = "Valor:"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkActivo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkActivo.Location = New System.Drawing.Point(91, 192)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(17, 17)
        Me.chkActivo.TabIndex = 7
        Me.chkActivo.Tag = ""
        Me.chkActivo.Text = "  "
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblActivo.Location = New System.Drawing.Point(19, 192)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(40, 13)
        Me.lblActivo.TabIndex = 99
        Me.lblActivo.Text = "Activo:"
        '
        'txtCodigo
        '
        Me.txtCodigo.AcceptsTab = True
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Location = New System.Drawing.Point(91, 26)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(43, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(91, 81)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(378, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'lblSiglas
        '
        Me.lblSiglas.AutoSize = True
        Me.lblSiglas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSiglas.Location = New System.Drawing.Point(19, 29)
        Me.lblSiglas.Name = "lblSiglas"
        Me.lblSiglas.Size = New System.Drawing.Size(43, 13)
        Me.lblSiglas.TabIndex = 1
        Me.lblSiglas.Text = "Código:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDescripcion.Location = New System.Drawing.Point(19, 84)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "Descripción:"
        '
        'errDocSoporte
        '
        Me.errDocSoporte.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(352, 232)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 8
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(429, 232)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 9
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmStbEditParametro
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(514, 266)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpBanco)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Parámetros")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbEditParametro"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetro"
        Me.grpBanco.ResumeLayout(False)
        Me.grpBanco.PerformLayout()
        CType(Me.dtpFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errDocSoporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpBanco As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblSiglas As System.Windows.Forms.Label
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents errDocSoporte As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblTipoDato As System.Windows.Forms.Label
    Friend WithEvents txtValorParametro As System.Windows.Forms.TextBox
    Friend WithEvents lstTipoDato As System.Windows.Forms.ListBox
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblFechaFin As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As C1.Win.C1Input.C1DateEdit
    Friend WithEvents dtpFechaInicio As C1.Win.C1Input.C1DateEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
