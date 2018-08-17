<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditImpresionCheques
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditImpresionCheques))
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.errSolicitud = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cdeFechaCheque = New C1.Win.C1Input.C1DateEdit
        Me.txtNumCheque = New System.Windows.Forms.TextBox
        Me.lblFechaCheque = New System.Windows.Forms.Label
        Me.lblNumeroCheque = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errSolicitud, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(246, 132)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 1
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(169, 132)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 0
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'errSolicitud
        '
        Me.errSolicitud.ContainerControl = Me
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaCheque)
        Me.grpGenerales.Controls.Add(Me.txtNumCheque)
        Me.grpGenerales.Controls.Add(Me.lblFechaCheque)
        Me.grpGenerales.Controls.Add(Me.lblNumeroCheque)
        Me.grpGenerales.Location = New System.Drawing.Point(12, 12)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(307, 114)
        Me.grpGenerales.TabIndex = 0
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Datos Generales: "
        '
        'cdeFechaCheque
        '
        Me.cdeFechaCheque.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCheque.Location = New System.Drawing.Point(145, 63)
        Me.cdeFechaCheque.Name = "cdeFechaCheque"
        Me.cdeFechaCheque.Size = New System.Drawing.Size(127, 20)
        Me.cdeFechaCheque.TabIndex = 1
        Me.cdeFechaCheque.Tag = Nothing
        Me.cdeFechaCheque.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txtNumCheque
        '
        Me.txtNumCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumCheque.Location = New System.Drawing.Point(145, 29)
        Me.txtNumCheque.Name = "txtNumCheque"
        Me.txtNumCheque.Size = New System.Drawing.Size(126, 20)
        Me.txtNumCheque.TabIndex = 0
        '
        'lblFechaCheque
        '
        Me.lblFechaCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaCheque.Location = New System.Drawing.Point(26, 64)
        Me.lblFechaCheque.Name = "lblFechaCheque"
        Me.lblFechaCheque.Size = New System.Drawing.Size(113, 19)
        Me.lblFechaCheque.TabIndex = 121
        Me.lblFechaCheque.Text = "Fecha del Cheque:"
        '
        'lblNumeroCheque
        '
        Me.lblNumeroCheque.AutoSize = True
        Me.lblNumeroCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumeroCheque.Location = New System.Drawing.Point(26, 32)
        Me.lblNumeroCheque.Name = "lblNumeroCheque"
        Me.lblNumeroCheque.Size = New System.Drawing.Size(102, 13)
        Me.lblNumeroCheque.TabIndex = 43
        Me.lblNumeroCheque.Text = "Número de Cheque:"
        '
        'frmSteEditImpresionCheques
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 170)
        Me.Controls.Add(Me.grpGenerales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Impresión de Cheques")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditImpresionCheques"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Asignación de Chequera"
        CType(Me.errSolicitud, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errSolicitud As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblNumeroCheque As System.Windows.Forms.Label
    Friend WithEvents lblFechaCheque As System.Windows.Forms.Label
    Friend WithEvents txtNumCheque As System.Windows.Forms.TextBox
    Friend WithEvents cdeFechaCheque As C1.Win.C1Input.C1DateEdit
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
