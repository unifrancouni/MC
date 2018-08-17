<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditArqueoRecibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditArqueoRecibo))
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.txtNumRecibo = New System.Windows.Forms.TextBox
        Me.cneValor = New C1.Win.C1Input.C1NumericEdit
        Me.lblValor = New System.Windows.Forms.Label
        Me.txtHastaRecibo = New System.Windows.Forms.TextBox
        Me.lblHastaRecibo = New System.Windows.Forms.Label
        Me.lblReciboDesde = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.chkManual = New System.Windows.Forms.CheckBox
        Me.lblManual = New System.Windows.Forms.Label
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(246, 168)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(169, 168)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.lblManual)
        Me.grpGenerales.Controls.Add(Me.chkManual)
        Me.grpGenerales.Controls.Add(Me.txtNumRecibo)
        Me.grpGenerales.Controls.Add(Me.cneValor)
        Me.grpGenerales.Controls.Add(Me.lblValor)
        Me.grpGenerales.Controls.Add(Me.txtHastaRecibo)
        Me.grpGenerales.Controls.Add(Me.lblHastaRecibo)
        Me.grpGenerales.Controls.Add(Me.lblReciboDesde)
        Me.grpGenerales.Location = New System.Drawing.Point(12, 12)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(307, 150)
        Me.grpGenerales.TabIndex = 0
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Datos Generales: "
        '
        'txtNumRecibo
        '
        Me.txtNumRecibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumRecibo.Location = New System.Drawing.Point(145, 29)
        Me.txtNumRecibo.Name = "txtNumRecibo"
        Me.txtNumRecibo.Size = New System.Drawing.Size(126, 20)
        Me.txtNumRecibo.TabIndex = 0
        '
        'cneValor
        '
        Me.cneValor.AcceptsTab = True
        Me.cneValor.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneValor.DataType = GetType(Double)
        Me.cneValor.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneValor.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneValor.EditFormat.EmptyAsNull = False
        Me.cneValor.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EmptyAsNull = True
        Me.cneValor.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.Location = New System.Drawing.Point(145, 96)
        Me.cneValor.MaskInfo.AutoTabWhenFilled = True
        Me.cneValor.MaxLength = 999999999
        Me.cneValor.Name = "cneValor"
        Me.cneValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValor.Size = New System.Drawing.Size(126, 20)
        Me.cneValor.TabIndex = 2
        Me.cneValor.Tag = Nothing
        Me.cneValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValor.UseColumnStyles = False
        Me.cneValor.Value = 0
        Me.cneValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblValor
        '
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(29, 99)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(113, 19)
        Me.lblValor.TabIndex = 121
        Me.lblValor.Text = "Monto de Recibos C$:"
        '
        'txtHastaRecibo
        '
        Me.txtHastaRecibo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHastaRecibo.Location = New System.Drawing.Point(145, 66)
        Me.txtHastaRecibo.Name = "txtHastaRecibo"
        Me.txtHastaRecibo.Size = New System.Drawing.Size(126, 20)
        Me.txtHastaRecibo.TabIndex = 1
        '
        'lblHastaRecibo
        '
        Me.lblHastaRecibo.AutoSize = True
        Me.lblHastaRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblHastaRecibo.Location = New System.Drawing.Point(29, 69)
        Me.lblHastaRecibo.Name = "lblHastaRecibo"
        Me.lblHastaRecibo.Size = New System.Drawing.Size(95, 13)
        Me.lblHastaRecibo.TabIndex = 47
        Me.lblHastaRecibo.Text = "Hasta Recibo No.:"
        '
        'lblReciboDesde
        '
        Me.lblReciboDesde.AutoSize = True
        Me.lblReciboDesde.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblReciboDesde.Location = New System.Drawing.Point(26, 32)
        Me.lblReciboDesde.Name = "lblReciboDesde"
        Me.lblReciboDesde.Size = New System.Drawing.Size(98, 13)
        Me.lblReciboDesde.TabIndex = 43
        Me.lblReciboDesde.Text = "Desde Recibo No.:"
        '
        'chkManual
        '
        Me.chkManual.AutoSize = True
        Me.chkManual.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkManual.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkManual.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkManual.Location = New System.Drawing.Point(145, 127)
        Me.chkManual.Name = "chkManual"
        Me.chkManual.Size = New System.Drawing.Size(15, 17)
        Me.chkManual.TabIndex = 122
        Me.chkManual.Tag = ""
        Me.chkManual.Text = " "
        Me.chkManual.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkManual.UseVisualStyleBackColor = True
        '
        'lblManual
        '
        Me.lblManual.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblManual.Location = New System.Drawing.Point(29, 127)
        Me.lblManual.Name = "lblManual"
        Me.lblManual.Size = New System.Drawing.Size(113, 19)
        Me.lblManual.TabIndex = 123
        Me.lblManual.Text = "Recibo(s) Manual(es)"
        '
        'frmSteEditArqueoRecibo
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 203)
        Me.Controls.Add(Me.grpGenerales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Arqueo de Cajas")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditArqueoRecibo"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Arqueo de Documentos"
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblReciboDesde As System.Windows.Forms.Label
    Friend WithEvents txtHastaRecibo As System.Windows.Forms.TextBox
    Friend WithEvents lblHastaRecibo As System.Windows.Forms.Label
    Friend WithEvents cneValor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents txtNumRecibo As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents lblManual As System.Windows.Forms.Label
    Friend WithEvents chkManual As System.Windows.Forms.CheckBox
End Class
