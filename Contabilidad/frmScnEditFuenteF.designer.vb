<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnEditFuenteF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnEditFuenteF))
        Me.grpDatosAplicacion = New System.Windows.Forms.GroupBox
        Me.txtSiglas = New System.Windows.Forms.TextBox
        Me.lblSiglas = New System.Windows.Forms.Label
        Me.lblFondoPresupuestario = New System.Windows.Forms.Label
        Me.chkFondoPresupuestario = New System.Windows.Forms.CheckBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.txtCodigo = New System.Windows.Forms.TextBox
        Me.lblActivo = New System.Windows.Forms.Label
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.lblNombre = New System.Windows.Forms.Label
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDatosAplicacion.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatosAplicacion
        '
        Me.grpDatosAplicacion.Controls.Add(Me.txtSiglas)
        Me.grpDatosAplicacion.Controls.Add(Me.lblSiglas)
        Me.grpDatosAplicacion.Controls.Add(Me.lblFondoPresupuestario)
        Me.grpDatosAplicacion.Controls.Add(Me.chkFondoPresupuestario)
        Me.grpDatosAplicacion.Controls.Add(Me.txtNombre)
        Me.grpDatosAplicacion.Controls.Add(Me.txtCodigo)
        Me.grpDatosAplicacion.Controls.Add(Me.lblActivo)
        Me.grpDatosAplicacion.Controls.Add(Me.chkActivo)
        Me.grpDatosAplicacion.Controls.Add(Me.lblNombre)
        Me.grpDatosAplicacion.Controls.Add(Me.lblCodigo)
        Me.grpDatosAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosAplicacion.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpDatosAplicacion.Location = New System.Drawing.Point(12, 12)
        Me.grpDatosAplicacion.Name = "grpDatosAplicacion"
        Me.grpDatosAplicacion.Size = New System.Drawing.Size(485, 172)
        Me.grpDatosAplicacion.TabIndex = 0
        Me.grpDatosAplicacion.TabStop = False
        Me.grpDatosAplicacion.Text = "Datos de Fuente de Financiamiento"
        '
        'txtSiglas
        '
        Me.txtSiglas.Location = New System.Drawing.Point(64, 101)
        Me.txtSiglas.Name = "txtSiglas"
        Me.txtSiglas.Size = New System.Drawing.Size(115, 20)
        Me.txtSiglas.TabIndex = 3
        '
        'lblSiglas
        '
        Me.lblSiglas.AutoSize = True
        Me.lblSiglas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSiglas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSiglas.Location = New System.Drawing.Point(15, 104)
        Me.lblSiglas.Name = "lblSiglas"
        Me.lblSiglas.Size = New System.Drawing.Size(38, 13)
        Me.lblSiglas.TabIndex = 12
        Me.lblSiglas.Text = "Siglas:"
        '
        'lblFondoPresupuestario
        '
        Me.lblFondoPresupuestario.AutoSize = True
        Me.lblFondoPresupuestario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFondoPresupuestario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFondoPresupuestario.Location = New System.Drawing.Point(99, 142)
        Me.lblFondoPresupuestario.Name = "lblFondoPresupuestario"
        Me.lblFondoPresupuestario.Size = New System.Drawing.Size(113, 13)
        Me.lblFondoPresupuestario.TabIndex = 10
        Me.lblFondoPresupuestario.Text = "Fondo Presupuestario:"
        '
        'chkFondoPresupuestario
        '
        Me.chkFondoPresupuestario.AutoSize = True
        Me.chkFondoPresupuestario.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFondoPresupuestario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFondoPresupuestario.Location = New System.Drawing.Point(218, 142)
        Me.chkFondoPresupuestario.Name = "chkFondoPresupuestario"
        Me.chkFondoPresupuestario.Size = New System.Drawing.Size(15, 14)
        Me.chkFondoPresupuestario.TabIndex = 5
        Me.chkFondoPresupuestario.UseVisualStyleBackColor = True
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(64, 50)
        Me.txtNombre.Multiline = True
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(404, 45)
        Me.txtNombre.TabIndex = 2
        '
        'txtCodigo
        '
        Me.txtCodigo.Location = New System.Drawing.Point(64, 24)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(115, 20)
        Me.txtCodigo.TabIndex = 1
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblActivo.Location = New System.Drawing.Point(15, 142)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(40, 13)
        Me.lblActivo.TabIndex = 8
        Me.lblActivo.Text = "Activo:"
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(66, 142)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(15, 14)
        Me.chkActivo.TabIndex = 4
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(15, 57)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 2
        Me.lblNombre.Text = "Nombre:"
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(15, 27)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lblCodigo.TabIndex = 0
        Me.lblCodigo.Text = "Código:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(424, 190)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(347, 190)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmScnEditFuenteF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 227)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpDatosAplicacion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Fuentes de Financiamiento")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnEditFuenteF"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fuentes de Financiamiento"
        Me.grpDatosAplicacion.ResumeLayout(False)
        Me.grpDatosAplicacion.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpDatosAplicacion As System.Windows.Forms.GroupBox
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblActivo As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblFondoPresupuestario As System.Windows.Forms.Label
    Friend WithEvents chkFondoPresupuestario As System.Windows.Forms.CheckBox
    Friend WithEvents txtSiglas As System.Windows.Forms.TextBox
    Friend WithEvents lblSiglas As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
