<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccParametroEC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccParametroEC))
        Me.grpdatosFormatos = New System.Windows.Forms.GroupBox
        Me.txtEstado = New System.Windows.Forms.TextBox
        Me.lblEstado = New System.Windows.Forms.Label
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.grpdestino = New System.Windows.Forms.GroupBox
        Me.RadArchivo = New System.Windows.Forms.RadioButton
        Me.RadImpresora = New System.Windows.Forms.RadioButton
        Me.radPantalla = New System.Windows.Forms.RadioButton
        Me.Exportar = New System.Windows.Forms.SaveFileDialog
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpObservaciones = New System.Windows.Forms.GroupBox
        Me.txtObservaciones = New System.Windows.Forms.TextBox
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpdatosFormatos.SuspendLayout()
        Me.grpdestino.SuspendLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpObservaciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpdatosFormatos
        '
        Me.grpdatosFormatos.Controls.Add(Me.txtEstado)
        Me.grpdatosFormatos.Controls.Add(Me.lblEstado)
        Me.grpdatosFormatos.Controls.Add(Me.txtCodigo)
        Me.grpdatosFormatos.Controls.Add(Me.lblCodigo)
        Me.grpdatosFormatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpdatosFormatos.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpdatosFormatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatosFormatos.Name = "grpdatosFormatos"
        Me.grpdatosFormatos.Size = New System.Drawing.Size(444, 84)
        Me.grpdatosFormatos.TabIndex = 1
        Me.grpdatosFormatos.TabStop = False
        Me.grpdatosFormatos.Text = "Datos Generales"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(125, 49)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.ShortcutsEnabled = False
        Me.txtEstado.Size = New System.Drawing.Size(216, 20)
        Me.txtEstado.TabIndex = 1
        Me.txtEstado.Tag = "LAYOUT:FLAT"
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEstado.Location = New System.Drawing.Point(12, 52)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(92, 13)
        Me.lblEstado.TabIndex = 37
        Me.lblEstado.Text = "Estado del Grupo:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(125, 23)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.ReadOnly = True
        Me.txtCodigo.ShortcutsEnabled = False
        Me.txtCodigo.Size = New System.Drawing.Size(216, 20)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Tag = "LAYOUT:FLAT"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(10, 25)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(92, 13)
        Me.lblCodigo.TabIndex = 35
        Me.lblCodigo.Text = "Código del Grupo:"
        '
        'grpdestino
        '
        Me.grpdestino.Controls.Add(Me.RadArchivo)
        Me.grpdestino.Controls.Add(Me.RadImpresora)
        Me.grpdestino.Controls.Add(Me.radPantalla)
        Me.grpdestino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpdestino.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpdestino.Location = New System.Drawing.Point(10, 196)
        Me.grpdestino.Name = "grpdestino"
        Me.grpdestino.Size = New System.Drawing.Size(444, 57)
        Me.grpdestino.TabIndex = 2
        Me.grpdestino.TabStop = False
        Me.grpdestino.Text = "Destino del Reporte"
        '
        'RadArchivo
        '
        Me.RadArchivo.AutoSize = True
        Me.RadArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadArchivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadArchivo.Location = New System.Drawing.Point(314, 22)
        Me.RadArchivo.Name = "RadArchivo"
        Me.RadArchivo.Size = New System.Drawing.Size(61, 17)
        Me.RadArchivo.TabIndex = 2
        Me.RadArchivo.Text = "Archivo"
        Me.RadArchivo.UseVisualStyleBackColor = True
        '
        'RadImpresora
        '
        Me.RadImpresora.AutoSize = True
        Me.RadImpresora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadImpresora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadImpresora.Location = New System.Drawing.Point(193, 22)
        Me.RadImpresora.Name = "RadImpresora"
        Me.RadImpresora.Size = New System.Drawing.Size(71, 17)
        Me.RadImpresora.TabIndex = 1
        Me.RadImpresora.Text = "Impresora"
        Me.RadImpresora.UseVisualStyleBackColor = True
        '
        'radPantalla
        '
        Me.radPantalla.AutoSize = True
        Me.radPantalla.Checked = True
        Me.radPantalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radPantalla.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radPantalla.Location = New System.Drawing.Point(89, 22)
        Me.radPantalla.Name = "radPantalla"
        Me.radPantalla.Size = New System.Drawing.Size(63, 17)
        Me.radPantalla.TabIndex = 0
        Me.radPantalla.TabStop = True
        Me.radPantalla.Text = "Pantalla"
        Me.radPantalla.UseVisualStyleBackColor = True
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'grpObservaciones
        '
        Me.grpObservaciones.Controls.Add(Me.txtObservaciones)
        Me.grpObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpObservaciones.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpObservaciones.Location = New System.Drawing.Point(10, 102)
        Me.grpObservaciones.Name = "grpObservaciones"
        Me.grpObservaciones.Size = New System.Drawing.Size(444, 88)
        Me.grpObservaciones.TabIndex = 11
        Me.grpObservaciones.TabStop = False
        Me.grpObservaciones.Text = "Observaciones: "
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(13, 19)
        Me.txtObservaciones.MaxLength = 400
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(415, 59)
        Me.txtObservaciones.TabIndex = 0
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(385, 259)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 10
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(313, 259)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmSccParametroEC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 296)
        Me.Controls.Add(Me.grpObservaciones)
        Me.Controls.Add(Me.grpdatosFormatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdestino)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccParametroEC"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Parámetros Estado de Cuenta Resumen"
        Me.grpdatosFormatos.ResumeLayout(False)
        Me.grpdatosFormatos.PerformLayout()
        Me.grpdestino.ResumeLayout(False)
        Me.grpdestino.PerformLayout()
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpObservaciones.ResumeLayout(False)
        Me.grpObservaciones.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdatosFormatos As System.Windows.Forms.GroupBox
    Friend WithEvents grpdestino As System.Windows.Forms.GroupBox
    Friend WithEvents RadArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents RadImpresora As System.Windows.Forms.RadioButton
    Friend WithEvents radPantalla As System.Windows.Forms.RadioButton
    Friend WithEvents Exportar As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents grpObservaciones As System.Windows.Forms.GroupBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
