<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditGarantiaPrendaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditGarantiaPrendaria))
        Me.grpGarantiaPrendaria = New System.Windows.Forms.GroupBox
        Me.txtGarantia = New System.Windows.Forms.TextBox
        Me.lblGarantia = New System.Windows.Forms.Label
        Me.cneValorGarantia = New C1.Win.C1Input.C1NumericEdit
        Me.lblValorGarantia = New System.Windows.Forms.Label
        Me.errGarantiaPrendaria = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpGarantiaPrendaria.SuspendLayout()
        CType(Me.cneValorGarantia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errGarantiaPrendaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpGarantiaPrendaria
        '
        Me.grpGarantiaPrendaria.Controls.Add(Me.txtGarantia)
        Me.grpGarantiaPrendaria.Controls.Add(Me.lblGarantia)
        Me.grpGarantiaPrendaria.Controls.Add(Me.cneValorGarantia)
        Me.grpGarantiaPrendaria.Controls.Add(Me.lblValorGarantia)
        Me.grpGarantiaPrendaria.Location = New System.Drawing.Point(12, 12)
        Me.grpGarantiaPrendaria.Name = "grpGarantiaPrendaria"
        Me.grpGarantiaPrendaria.Size = New System.Drawing.Size(620, 213)
        Me.grpGarantiaPrendaria.TabIndex = 0
        Me.grpGarantiaPrendaria.TabStop = False
        Me.grpGarantiaPrendaria.Text = "Datos Garantía Prendaria"
        '
        'txtGarantia
        '
        Me.txtGarantia.Location = New System.Drawing.Point(15, 51)
        Me.txtGarantia.Multiline = True
        Me.txtGarantia.Name = "txtGarantia"
        Me.txtGarantia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGarantia.Size = New System.Drawing.Size(590, 103)
        Me.txtGarantia.TabIndex = 0
        '
        'lblGarantia
        '
        Me.lblGarantia.AutoSize = True
        Me.lblGarantia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGarantia.Location = New System.Drawing.Point(12, 26)
        Me.lblGarantia.Name = "lblGarantia"
        Me.lblGarantia.Size = New System.Drawing.Size(220, 13)
        Me.lblGarantia.TabIndex = 55
        Me.lblGarantia.Text = "Describa cada uno de los bienes en garantía"
        '
        'cneValorGarantia
        '
        Me.cneValorGarantia.AcceptsTab = True
        Me.cneValorGarantia.CustomFormat = "###,###,###,##0.00"
        Me.cneValorGarantia.DataType = GetType(Double)
        Me.cneValorGarantia.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
        Me.cneValorGarantia.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValorGarantia.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValorGarantia.EditFormat.CustomFormat = "###,###,###,##0.00"
        Me.cneValorGarantia.EditFormat.EmptyAsNull = False
        Me.cneValorGarantia.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValorGarantia.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneValorGarantia.EmptyAsNull = True
        Me.cneValorGarantia.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneValorGarantia.Location = New System.Drawing.Point(138, 169)
        Me.cneValorGarantia.MaskInfo.AutoTabWhenFilled = True
        Me.cneValorGarantia.MaxLength = 999999999
        Me.cneValorGarantia.Name = "cneValorGarantia"
        Me.cneValorGarantia.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValorGarantia.Size = New System.Drawing.Size(156, 20)
        Me.cneValorGarantia.TabIndex = 1
        Me.cneValorGarantia.Tag = Nothing
        Me.cneValorGarantia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValorGarantia.UseColumnStyles = False
        Me.cneValorGarantia.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblValorGarantia
        '
        Me.lblValorGarantia.AutoSize = True
        Me.lblValorGarantia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValorGarantia.Location = New System.Drawing.Point(14, 176)
        Me.lblValorGarantia.Name = "lblValorGarantia"
        Me.lblValorGarantia.Size = New System.Drawing.Size(121, 13)
        Me.lblValorGarantia.TabIndex = 42
        Me.lblValorGarantia.Text = "Valor de la Garantía C$:"
        '
        'errGarantiaPrendaria
        '
        Me.errGarantiaPrendaria.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(482, 231)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(559, 231)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSclEditGarantiaPrendaria
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(644, 271)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpGarantiaPrendaria)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Ficha de Inscripción")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditGarantiaPrendaria"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Garantía Prendaria"
        Me.grpGarantiaPrendaria.ResumeLayout(False)
        Me.grpGarantiaPrendaria.PerformLayout()
        CType(Me.cneValorGarantia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errGarantiaPrendaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpGarantiaPrendaria As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errGarantiaPrendaria As System.Windows.Forms.ErrorProvider
    Friend WithEvents cneValorGarantia As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblValorGarantia As System.Windows.Forms.Label
    Friend WithEvents txtGarantia As System.Windows.Forms.TextBox
    Friend WithEvents lblGarantia As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
