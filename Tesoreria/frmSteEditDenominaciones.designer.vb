<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditDenominaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditDenominaciones))
        Me.grpDenominacion = New System.Windows.Forms.GroupBox
        Me.cneValor = New C1.Win.C1Input.C1NumericEdit
        Me.LblBillete = New System.Windows.Forms.Label
        Me.lblValor = New System.Windows.Forms.Label
        Me.chkBillete = New System.Windows.Forms.CheckBox
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.errDenominacion = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDenominacion.SuspendLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errDenominacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDenominacion
        '
        Me.grpDenominacion.Controls.Add(Me.cneValor)
        Me.grpDenominacion.Controls.Add(Me.LblBillete)
        Me.grpDenominacion.Controls.Add(Me.lblValor)
        Me.grpDenominacion.Controls.Add(Me.chkBillete)
        Me.grpDenominacion.Location = New System.Drawing.Point(12, 12)
        Me.grpDenominacion.Name = "grpDenominacion"
        Me.grpDenominacion.Size = New System.Drawing.Size(358, 87)
        Me.grpDenominacion.TabIndex = 0
        Me.grpDenominacion.TabStop = False
        Me.grpDenominacion.Text = "Datos Generales: "
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
        Me.cneValor.Location = New System.Drawing.Point(149, 33)
        Me.cneValor.MaskInfo.AutoTabWhenFilled = True
        Me.cneValor.MaxLength = 999999999
        Me.cneValor.Name = "cneValor"
        Me.cneValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValor.Size = New System.Drawing.Size(88, 20)
        Me.cneValor.TabIndex = 38
        Me.cneValor.Tag = Nothing
        Me.cneValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValor.UseColumnStyles = False
        Me.cneValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'LblBillete
        '
        Me.LblBillete.AutoSize = True
        Me.LblBillete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBillete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblBillete.Location = New System.Drawing.Point(19, 60)
        Me.LblBillete.Name = "LblBillete"
        Me.LblBillete.Size = New System.Drawing.Size(124, 13)
        Me.LblBillete.TabIndex = 34
        Me.LblBillete.Text = "Denominación de Billete:"
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(19, 33)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(105, 13)
        Me.lblValor.TabIndex = 26
        Me.lblValor.Text = "Valor Denominación:"
        '
        'chkBillete
        '
        Me.chkBillete.AutoSize = True
        Me.chkBillete.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkBillete.Checked = True
        Me.chkBillete.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBillete.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkBillete.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkBillete.Location = New System.Drawing.Point(149, 60)
        Me.chkBillete.Name = "chkBillete"
        Me.chkBillete.Size = New System.Drawing.Size(15, 17)
        Me.chkBillete.TabIndex = 10
        Me.chkBillete.Tag = ""
        Me.chkBillete.Text = " "
        Me.chkBillete.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkBillete.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(220, 105)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(297, 105)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 4
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'errDenominacion
        '
        Me.errDenominacion.ContainerControl = Me
        '
        'frmSteEditDenominaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(381, 141)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpDenominacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Denominaciones")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditDenominaciones"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Registro de Datos de Denominación"
        Me.grpDenominacion.ResumeLayout(False)
        Me.grpDenominacion.PerformLayout()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errDenominacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDenominacion As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errDenominacion As System.Windows.Forms.ErrorProvider
    Friend WithEvents chkBillete As System.Windows.Forms.CheckBox
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents LblBillete As System.Windows.Forms.Label
    Friend WithEvents cneValor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
