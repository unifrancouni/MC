<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditSupervision
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditSupervision))
        Me.grpDatosBarrio = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cdeFechaSupervision = New C1.Win.C1Input.C1DateEdit()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.txtNombreSocia = New System.Windows.Forms.TextBox()
        Me.lblNombreSocia = New System.Windows.Forms.Label()
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox()
        Me.lblSocia = New System.Windows.Forms.Label()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.CmdAceptar = New System.Windows.Forms.Button()
        Me.grpDatosBarrio.SuspendLayout()
        CType(Me.cdeFechaSupervision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatosBarrio
        '
        Me.grpDatosBarrio.Controls.Add(Me.Label1)
        Me.grpDatosBarrio.Controls.Add(Me.cdeFechaSupervision)
        Me.grpDatosBarrio.Controls.Add(Me.txtObservaciones)
        Me.grpDatosBarrio.Controls.Add(Me.lblObservaciones)
        Me.grpDatosBarrio.Controls.Add(Me.cmdBuscar)
        Me.grpDatosBarrio.Controls.Add(Me.txtNombreSocia)
        Me.grpDatosBarrio.Controls.Add(Me.lblNombreSocia)
        Me.grpDatosBarrio.Controls.Add(Me.mtbNumCedula)
        Me.grpDatosBarrio.Controls.Add(Me.lblSocia)
        Me.grpDatosBarrio.Location = New System.Drawing.Point(9, 2)
        Me.grpDatosBarrio.Name = "grpDatosBarrio"
        Me.grpDatosBarrio.Size = New System.Drawing.Size(466, 237)
        Me.grpDatosBarrio.TabIndex = 1
        Me.grpDatosBarrio.TabStop = False
        Me.grpDatosBarrio.Text = "Datos Socia"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(4, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Fecha de Supervision:"
        '
        'cdeFechaSupervision
        '
        Me.cdeFechaSupervision.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaSupervision.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaSupervision.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaSupervision.Location = New System.Drawing.Point(133, 86)
        Me.cdeFechaSupervision.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaSupervision.MaskInfo.EmptyAsNull = True
        Me.cdeFechaSupervision.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaSupervision.Name = "cdeFechaSupervision"
        Me.cdeFechaSupervision.Size = New System.Drawing.Size(324, 20)
        Me.cdeFechaSupervision.TabIndex = 118
        Me.cdeFechaSupervision.Tag = Nothing
        Me.cdeFechaSupervision.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(133, 114)
        Me.txtObservaciones.MaxLength = 1000
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(324, 117)
        Me.txtObservaciones.TabIndex = 113
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblObservaciones.Location = New System.Drawing.Point(4, 127)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(81, 13)
        Me.lblObservaciones.TabIndex = 117
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(386, 16)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 114
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(133, 55)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(324, 20)
        Me.txtNombreSocia.TabIndex = 112
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(4, 58)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(77, 13)
        Me.lblNombreSocia.TabIndex = 116
        Me.lblNombreSocia.Text = "Nombre Socia:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(133, 19)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(247, 20)
        Me.mtbNumCedula.TabIndex = 111
        '
        'lblSocia
        '
        Me.lblSocia.AutoSize = True
        Me.lblSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSocia.Location = New System.Drawing.Point(4, 22)
        Me.lblSocia.Name = "lblSocia"
        Me.lblSocia.Size = New System.Drawing.Size(73, 13)
        Me.lblSocia.TabIndex = 115
        Me.lblSocia.Text = "Cédula Socia:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(402, 245)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 12
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(325, 245)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 11
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'frmSclEditSupervision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 273)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpDatosBarrio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclEditSupervision"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Supervisión"
        Me.grpDatosBarrio.ResumeLayout(False)
        Me.grpDatosBarrio.PerformLayout()
        CType(Me.cdeFechaSupervision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpDatosBarrio As GroupBox
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents CmdAceptar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cdeFechaSupervision As C1.Win.C1Input.C1DateEdit
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents lblObservaciones As Label
    Friend WithEvents cmdBuscar As Button
    Friend WithEvents txtNombreSocia As TextBox
    Friend WithEvents lblNombreSocia As Label
    Friend WithEvents mtbNumCedula As MaskedTextBox
    Friend WithEvents lblSocia As Label
End Class
