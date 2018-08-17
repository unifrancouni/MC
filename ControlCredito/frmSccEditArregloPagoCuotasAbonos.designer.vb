<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditArregloPagoCuotasAbonos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditArregloPagoCuotasAbonos))
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.errError = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.lblObservaciones = New System.Windows.Forms.Label
        Me.cdeFechaA = New C1.Win.C1Input.C1DateEdit
        Me.lblFecha = New System.Windows.Forms.Label
        Me.cneValor = New C1.Win.C1Input.C1NumericEdit
        Me.lblValor = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errError, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(371, 188)
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
        Me.cmdAceptar.Location = New System.Drawing.Point(294, 188)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 3
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'errError
        '
        Me.errError.ContainerControl = Me
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.txtObservaciones)
        Me.grpGenerales.Controls.Add(Me.lblObservaciones)
        Me.grpGenerales.Controls.Add(Me.cdeFechaA)
        Me.grpGenerales.Controls.Add(Me.lblFecha)
        Me.grpGenerales.Controls.Add(Me.cneValor)
        Me.grpGenerales.Controls.Add(Me.lblValor)
        Me.grpGenerales.Location = New System.Drawing.Point(12, 12)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(432, 170)
        Me.grpGenerales.TabIndex = 0
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Datos Generales: "
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(93, 93)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(327, 64)
        Me.txtObservaciones.TabIndex = 2
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
        Me.lblObservaciones.Location = New System.Drawing.Point(15, 96)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 124
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'cdeFechaA
        '
        Me.cdeFechaA.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaA.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaA.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaA.Location = New System.Drawing.Point(93, 26)
        Me.cdeFechaA.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaA.MaskInfo.EmptyAsNull = True
        Me.cdeFechaA.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaA.Name = "cdeFechaA"
        Me.cdeFechaA.Size = New System.Drawing.Size(109, 20)
        Me.cdeFechaA.TabIndex = 0
        Me.cdeFechaA.Tag = Nothing
        Me.cdeFechaA.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(15, 26)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 122
        Me.lblFecha.Text = "Fecha:"
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
        Me.cneValor.Location = New System.Drawing.Point(93, 58)
        Me.cneValor.MaskInfo.AutoTabWhenFilled = True
        Me.cneValor.MaxLength = 999999999
        Me.cneValor.Name = "cneValor"
        Me.cneValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneValor.Size = New System.Drawing.Size(109, 20)
        Me.cneValor.TabIndex = 1
        Me.cneValor.Tag = Nothing
        Me.cneValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneValor.UseColumnStyles = False
        Me.cneValor.Value = 0
        Me.cneValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblValor
        '
        Me.lblValor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblValor.Location = New System.Drawing.Point(15, 59)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(64, 19)
        Me.lblValor.TabIndex = 121
        Me.lblValor.Text = "Monto C$:"
        '
        'frmSccEditArregloPagoCuotasAbonos
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(455, 220)
        Me.Controls.Add(Me.grpGenerales)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Arqueo de Cajas")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditArregloPagoCuotasAbonos"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Ingreso de Cuotas/Abonos"
        CType(Me.errError, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errError As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cneValor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents cdeFechaA As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
End Class
