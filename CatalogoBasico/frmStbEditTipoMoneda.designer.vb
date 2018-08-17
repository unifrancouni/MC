<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbEditTipoMoneda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbEditTipoMoneda))
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.TxtSimbolo = New System.Windows.Forms.TextBox
        Me.TxtDescripcionMoneda = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpMonedas = New System.Windows.Forms.GroupBox
        Me.TxtCodigo = New System.Windows.Forms.TextBox
        Me.LblActivo = New System.Windows.Forms.Label
        Me.CkboxActivo = New System.Windows.Forms.CheckBox
        Me.LblCodigoInterno = New System.Windows.Forms.Label
        Me.LblEsNacional = New System.Windows.Forms.Label
        Me.RbNacionalNo = New System.Windows.Forms.RadioButton
        Me.RbNacionalSi = New System.Windows.Forms.RadioButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.GrpMonedas.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(262, 183)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 25)
        Me.cmdCancelar.TabIndex = 8
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(185, 183)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 7
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'TxtSimbolo
        '
        Me.TxtSimbolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSimbolo.Location = New System.Drawing.Point(115, 75)
        Me.TxtSimbolo.MaxLength = 3
        Me.TxtSimbolo.Name = "TxtSimbolo"
        Me.TxtSimbolo.Size = New System.Drawing.Size(34, 20)
        Me.TxtSimbolo.TabIndex = 3
        '
        'TxtDescripcionMoneda
        '
        Me.TxtDescripcionMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripcionMoneda.Location = New System.Drawing.Point(115, 49)
        Me.TxtDescripcionMoneda.Name = "TxtDescripcionMoneda"
        Me.TxtDescripcionMoneda.Size = New System.Drawing.Size(188, 20)
        Me.TxtDescripcionMoneda.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Símbolo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(16, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre:"
        '
        'GrpMonedas
        '
        Me.GrpMonedas.Controls.Add(Me.TxtCodigo)
        Me.GrpMonedas.Controls.Add(Me.LblActivo)
        Me.GrpMonedas.Controls.Add(Me.CkboxActivo)
        Me.GrpMonedas.Controls.Add(Me.LblCodigoInterno)
        Me.GrpMonedas.Controls.Add(Me.LblEsNacional)
        Me.GrpMonedas.Controls.Add(Me.RbNacionalNo)
        Me.GrpMonedas.Controls.Add(Me.RbNacionalSi)
        Me.GrpMonedas.Controls.Add(Me.Label2)
        Me.GrpMonedas.Controls.Add(Me.Label1)
        Me.GrpMonedas.Controls.Add(Me.TxtSimbolo)
        Me.GrpMonedas.Controls.Add(Me.TxtDescripcionMoneda)
        Me.GrpMonedas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpMonedas.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GrpMonedas.Location = New System.Drawing.Point(15, 13)
        Me.GrpMonedas.Name = "GrpMonedas"
        Me.GrpMonedas.Size = New System.Drawing.Size(318, 164)
        Me.GrpMonedas.TabIndex = 28
        Me.GrpMonedas.TabStop = False
        Me.GrpMonedas.Text = "Datos Generales de Moneda"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Location = New System.Drawing.Point(115, 23)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.Size = New System.Drawing.Size(39, 20)
        Me.TxtCodigo.TabIndex = 1
        '
        'LblActivo
        '
        Me.LblActivo.AutoSize = True
        Me.LblActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblActivo.Location = New System.Drawing.Point(16, 138)
        Me.LblActivo.Name = "LblActivo"
        Me.LblActivo.Size = New System.Drawing.Size(40, 13)
        Me.LblActivo.TabIndex = 9
        Me.LblActivo.Text = "Activo:"
        '
        'CkboxActivo
        '
        Me.CkboxActivo.AutoSize = True
        Me.CkboxActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CkboxActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CkboxActivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CkboxActivo.Location = New System.Drawing.Point(115, 137)
        Me.CkboxActivo.Name = "CkboxActivo"
        Me.CkboxActivo.Size = New System.Drawing.Size(17, 17)
        Me.CkboxActivo.TabIndex = 6
        Me.CkboxActivo.Text = "  "
        Me.CkboxActivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CkboxActivo.UseVisualStyleBackColor = True
        '
        'LblCodigoInterno
        '
        Me.LblCodigoInterno.AutoSize = True
        Me.LblCodigoInterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCodigoInterno.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblCodigoInterno.Location = New System.Drawing.Point(16, 26)
        Me.LblCodigoInterno.Name = "LblCodigoInterno"
        Me.LblCodigoInterno.Size = New System.Drawing.Size(43, 13)
        Me.LblCodigoInterno.TabIndex = 7
        Me.LblCodigoInterno.Text = "Código:"
        '
        'LblEsNacional
        '
        Me.LblEsNacional.AutoSize = True
        Me.LblEsNacional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEsNacional.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblEsNacional.Location = New System.Drawing.Point(16, 116)
        Me.LblEsNacional.Name = "LblEsNacional"
        Me.LblEsNacional.Size = New System.Drawing.Size(73, 13)
        Me.LblEsNacional.TabIndex = 6
        Me.LblEsNacional.Text = "Es Nacional ?"
        '
        'RbNacionalNo
        '
        Me.RbNacionalNo.AutoSize = True
        Me.RbNacionalNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbNacionalNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbNacionalNo.Location = New System.Drawing.Point(115, 114)
        Me.RbNacionalNo.Name = "RbNacionalNo"
        Me.RbNacionalNo.Size = New System.Drawing.Size(39, 17)
        Me.RbNacionalNo.TabIndex = 4
        Me.RbNacionalNo.TabStop = True
        Me.RbNacionalNo.Text = "No"
        Me.RbNacionalNo.UseVisualStyleBackColor = True
        '
        'RbNacionalSi
        '
        Me.RbNacionalSi.AutoSize = True
        Me.RbNacionalSi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbNacionalSi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.RbNacionalSi.Location = New System.Drawing.Point(160, 114)
        Me.RbNacionalSi.Name = "RbNacionalSi"
        Me.RbNacionalSi.Size = New System.Drawing.Size(34, 17)
        Me.RbNacionalSi.TabIndex = 5
        Me.RbNacionalSi.TabStop = True
        Me.RbNacionalSi.Text = "Si"
        Me.RbNacionalSi.UseVisualStyleBackColor = True
        '
        'frmStbEditTipoMoneda
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(349, 219)
        Me.Controls.Add(Me.GrpMonedas)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Monedas")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbEditTipoMoneda"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Moneda"
        Me.GrpMonedas.ResumeLayout(False)
        Me.GrpMonedas.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents TxtSimbolo As System.Windows.Forms.TextBox
    Friend WithEvents TxtDescripcionMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpMonedas As System.Windows.Forms.GroupBox
    Friend WithEvents RbNacionalSi As System.Windows.Forms.RadioButton
    Friend WithEvents RbNacionalNo As System.Windows.Forms.RadioButton
    Friend WithEvents LblEsNacional As System.Windows.Forms.Label
    Friend WithEvents LblCodigoInterno As System.Windows.Forms.Label
    Friend WithEvents CkboxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents LblActivo As System.Windows.Forms.Label
    Friend WithEvents TxtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
