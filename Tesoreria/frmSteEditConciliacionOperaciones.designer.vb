<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditConciliacionOperaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditConciliacionOperaciones))
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.errOperacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpOperaciones = New System.Windows.Forms.GroupBox
        Me.cneValor = New C1.Win.C1Input.C1NumericEdit
        Me.txtConcepto = New System.Windows.Forms.TextBox
        Me.cdeFechaO = New C1.Win.C1Input.C1DateEdit
        Me.lblValor = New System.Windows.Forms.Label
        Me.lblConcepto = New System.Windows.Forms.Label
        Me.lblFecha = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOperaciones.SuspendLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(491, 175)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(414, 175)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'errOperacion
        '
        Me.errOperacion.ContainerControl = Me
        '
        'grpOperaciones
        '
        Me.grpOperaciones.Controls.Add(Me.cneValor)
        Me.grpOperaciones.Controls.Add(Me.txtConcepto)
        Me.grpOperaciones.Controls.Add(Me.cdeFechaO)
        Me.grpOperaciones.Controls.Add(Me.lblValor)
        Me.grpOperaciones.Controls.Add(Me.lblConcepto)
        Me.grpOperaciones.Controls.Add(Me.lblFecha)
        Me.grpOperaciones.Location = New System.Drawing.Point(12, 12)
        Me.grpOperaciones.Name = "grpOperaciones"
        Me.grpOperaciones.Size = New System.Drawing.Size(552, 157)
        Me.grpOperaciones.TabIndex = 0
        Me.grpOperaciones.TabStop = False
        Me.grpOperaciones.Text = "Datos Operación Bancaria:"
        '
        'cneValor
        '
        Me.cneValor.AcceptsTab = True
        Me.cneValor.CustomFormat = "###,###,###,##0.00"
        Me.cneValor.DataType = GetType(Double)
        Me.cneValor.DisplayFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneValor.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneValor.EditFormat.EmptyAsNull = False
        Me.cneValor.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValor.EmptyAsNull = True
        Me.cneValor.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValor.Location = New System.Drawing.Point(91, 55)
        Me.cneValor.MaskInfo.AutoTabWhenFilled = True
        Me.cneValor.MaxLength = 999999999
        Me.cneValor.Name = "cneValor"
        Me.cneValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValor.ParseInfo.NumberStyle = CType((((((((C1.Win.C1Input.NumberStyleFlags.AllowLeadingWhite Or C1.Win.C1Input.NumberStyleFlags.AllowTrailingWhite) _
                    Or C1.Win.C1Input.NumberStyleFlags.AllowLeadingSign) _
                    Or C1.Win.C1Input.NumberStyleFlags.AllowTrailingSign) _
                    Or C1.Win.C1Input.NumberStyleFlags.AllowParentheses) _
                    Or C1.Win.C1Input.NumberStyleFlags.AllowDecimalPoint) _
                    Or C1.Win.C1Input.NumberStyleFlags.AllowThousands) _
                    Or C1.Win.C1Input.NumberStyleFlags.AllowExponent), C1.Win.C1Input.NumberStyleFlags)
        Me.cneValor.Size = New System.Drawing.Size(126, 20)
        Me.cneValor.TabIndex = 1
        Me.cneValor.Tag = Nothing
        Me.cneValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValor.UseColumnStyles = False
        Me.cneValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'txtConcepto
        '
        Me.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtConcepto.Location = New System.Drawing.Point(91, 88)
        Me.txtConcepto.Multiline = True
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConcepto.Size = New System.Drawing.Size(444, 50)
        Me.txtConcepto.TabIndex = 2
        '
        'cdeFechaO
        '
        Me.cdeFechaO.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaO.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaO.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaO.Location = New System.Drawing.Point(91, 25)
        Me.cdeFechaO.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaO.MaskInfo.EmptyAsNull = True
        Me.cdeFechaO.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaO.Name = "cdeFechaO"
        Me.cdeFechaO.Size = New System.Drawing.Size(126, 20)
        Me.cdeFechaO.TabIndex = 0
        Me.cdeFechaO.Tag = Nothing
        Me.cdeFechaO.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblValor
        '
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(29, 56)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(50, 19)
        Me.lblValor.TabIndex = 121
        Me.lblValor.Text = "Monto:"
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblConcepto.Location = New System.Drawing.Point(29, 91)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(56, 13)
        Me.lblConcepto.TabIndex = 47
        Me.lblConcepto.Text = "Concepto:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(29, 28)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 43
        Me.lblFecha.Text = "Fecha:"
        '
        'frmSteEditConciliacionOperaciones
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(576, 209)
        Me.Controls.Add(Me.grpOperaciones)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Conciliación Bancaria")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditConciliacionOperaciones"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Notas de Débito"
        CType(Me.errOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOperaciones.ResumeLayout(False)
        Me.grpOperaciones.PerformLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errOperacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpOperaciones As System.Windows.Forms.GroupBox
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblConcepto As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents cdeFechaO As C1.Win.C1Input.C1DateEdit
    Friend WithEvents txtConcepto As System.Windows.Forms.TextBox
    Friend WithEvents cneValor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
