<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclReptFichaVerificacion
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtFechaVerificacion = New System.Windows.Forms.DateTimePicker()
        Me.dtFechaInscripcion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblFechaInscripcion = New System.Windows.Forms.Label()
        Me.txtBarrio = New System.Windows.Forms.TextBox()
        Me.lblbarrio = New System.Windows.Forms.Label()
        Me.txtDistrito = New System.Windows.Forms.TextBox()
        Me.lblDistrito = New System.Windows.Forms.Label()
        Me.txtMunicipio = New System.Windows.Forms.TextBox()
        Me.lblMunicipio = New System.Windows.Forms.Label()
        Me.txtDepartamento = New System.Windows.Forms.TextBox()
        Me.lblDepartamento = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.lblTelefono = New System.Windows.Forms.Label()
        Me.txtNombreGrupo = New System.Windows.Forms.TextBox()
        Me.lblNombreGrupo = New System.Windows.Forms.Label()
        Me.txtNombreSocia = New System.Windows.Forms.TextBox()
        Me.lblNombreSocia = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.mscCedula = New System.Windows.Forms.MaskedTextBox()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.errSocia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtFechaVerificacion)
        Me.GroupBox1.Controls.Add(Me.dtFechaInscripcion)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblFechaInscripcion)
        Me.GroupBox1.Controls.Add(Me.txtBarrio)
        Me.GroupBox1.Controls.Add(Me.lblbarrio)
        Me.GroupBox1.Controls.Add(Me.txtDistrito)
        Me.GroupBox1.Controls.Add(Me.lblDistrito)
        Me.GroupBox1.Controls.Add(Me.txtMunicipio)
        Me.GroupBox1.Controls.Add(Me.lblMunicipio)
        Me.GroupBox1.Controls.Add(Me.txtDepartamento)
        Me.GroupBox1.Controls.Add(Me.lblDepartamento)
        Me.GroupBox1.Controls.Add(Me.txtEstado)
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.txtTelefono)
        Me.GroupBox1.Controls.Add(Me.lblTelefono)
        Me.GroupBox1.Controls.Add(Me.txtNombreGrupo)
        Me.GroupBox1.Controls.Add(Me.lblNombreGrupo)
        Me.GroupBox1.Controls.Add(Me.txtNombreSocia)
        Me.GroupBox1.Controls.Add(Me.lblNombreSocia)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.lblCodigo)
        Me.GroupBox1.Controls.Add(Me.mscCedula)
        Me.GroupBox1.Controls.Add(Me.lblCedula)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 216)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Generales"
        '
        'dtFechaVerificacion
        '
        Me.dtFechaVerificacion.CustomFormat = "dd/MM/yyyy"
        Me.dtFechaVerificacion.Enabled = False
        Me.dtFechaVerificacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaVerificacion.Location = New System.Drawing.Point(359, 179)
        Me.dtFechaVerificacion.Name = "dtFechaVerificacion"
        Me.dtFechaVerificacion.Size = New System.Drawing.Size(126, 20)
        Me.dtFechaVerificacion.TabIndex = 22
        '
        'dtFechaInscripcion
        '
        Me.dtFechaInscripcion.CustomFormat = "dd/MM/yyyy"
        Me.dtFechaInscripcion.Enabled = False
        Me.dtFechaInscripcion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaInscripcion.Location = New System.Drawing.Point(129, 178)
        Me.dtFechaInscripcion.Name = "dtFechaInscripcion"
        Me.dtFechaInscripcion.Size = New System.Drawing.Size(126, 20)
        Me.dtFechaInscripcion.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(264, 186)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "F. Verificación"
        '
        'lblFechaInscripcion
        '
        Me.lblFechaInscripcion.AutoSize = True
        Me.lblFechaInscripcion.Location = New System.Drawing.Point(17, 186)
        Me.lblFechaInscripcion.Name = "lblFechaInscripcion"
        Me.lblFechaInscripcion.Size = New System.Drawing.Size(84, 13)
        Me.lblFechaInscripcion.TabIndex = 18
        Me.lblFechaInscripcion.Text = "F. Inscripción"
        '
        'txtBarrio
        '
        Me.txtBarrio.BackColor = System.Drawing.SystemColors.Info
        Me.txtBarrio.Enabled = False
        Me.txtBarrio.Location = New System.Drawing.Point(359, 153)
        Me.txtBarrio.Name = "txtBarrio"
        Me.txtBarrio.Size = New System.Drawing.Size(126, 20)
        Me.txtBarrio.TabIndex = 17
        '
        'lblbarrio
        '
        Me.lblbarrio.AutoSize = True
        Me.lblbarrio.Location = New System.Drawing.Point(264, 160)
        Me.lblbarrio.Name = "lblbarrio"
        Me.lblbarrio.Size = New System.Drawing.Size(40, 13)
        Me.lblbarrio.TabIndex = 16
        Me.lblbarrio.Text = "Barrio"
        '
        'txtDistrito
        '
        Me.txtDistrito.BackColor = System.Drawing.SystemColors.Info
        Me.txtDistrito.Enabled = False
        Me.txtDistrito.Location = New System.Drawing.Point(129, 153)
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Size = New System.Drawing.Size(126, 20)
        Me.txtDistrito.TabIndex = 15
        '
        'lblDistrito
        '
        Me.lblDistrito.AutoSize = True
        Me.lblDistrito.Location = New System.Drawing.Point(17, 160)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.Size(47, 13)
        Me.lblDistrito.TabIndex = 14
        Me.lblDistrito.Text = "Distrito"
        '
        'txtMunicipio
        '
        Me.txtMunicipio.BackColor = System.Drawing.SystemColors.Info
        Me.txtMunicipio.Enabled = False
        Me.txtMunicipio.Location = New System.Drawing.Point(359, 127)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Size = New System.Drawing.Size(126, 20)
        Me.txtMunicipio.TabIndex = 13
        '
        'lblMunicipio
        '
        Me.lblMunicipio.AutoSize = True
        Me.lblMunicipio.Location = New System.Drawing.Point(264, 134)
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.Size(61, 13)
        Me.lblMunicipio.TabIndex = 12
        Me.lblMunicipio.Text = "Municipio"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.BackColor = System.Drawing.SystemColors.Info
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Location = New System.Drawing.Point(129, 127)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Size = New System.Drawing.Size(126, 20)
        Me.txtDepartamento.TabIndex = 11
        '
        'lblDepartamento
        '
        Me.lblDepartamento.AutoSize = True
        Me.lblDepartamento.Location = New System.Drawing.Point(17, 134)
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.Size(90, 13)
        Me.lblDepartamento.TabIndex = 10
        Me.lblDepartamento.Text = "Derpartamento"
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.SystemColors.Info
        Me.txtEstado.Enabled = False
        Me.txtEstado.Location = New System.Drawing.Point(359, 74)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(126, 20)
        Me.txtEstado.TabIndex = 11
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(264, 81)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(82, 13)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Estado Socia"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Info
        Me.txtTelefono.Enabled = False
        Me.txtTelefono.Location = New System.Drawing.Point(129, 75)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(126, 20)
        Me.txtTelefono.TabIndex = 9
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.Location = New System.Drawing.Point(17, 82)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(93, 13)
        Me.lblTelefono.TabIndex = 8
        Me.lblTelefono.Text = "Teléfono Socia"
        '
        'txtNombreGrupo
        '
        Me.txtNombreGrupo.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreGrupo.Enabled = False
        Me.txtNombreGrupo.Location = New System.Drawing.Point(129, 101)
        Me.txtNombreGrupo.Name = "txtNombreGrupo"
        Me.txtNombreGrupo.Size = New System.Drawing.Size(356, 20)
        Me.txtNombreGrupo.TabIndex = 7
        '
        'lblNombreGrupo
        '
        Me.lblNombreGrupo.AutoSize = True
        Me.lblNombreGrupo.Location = New System.Drawing.Point(17, 108)
        Me.lblNombreGrupo.Name = "lblNombreGrupo"
        Me.lblNombreGrupo.Size = New System.Drawing.Size(88, 13)
        Me.lblNombreGrupo.TabIndex = 6
        Me.lblNombreGrupo.Text = "Nombre Grupo"
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Location = New System.Drawing.Point(129, 48)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.Size = New System.Drawing.Size(356, 20)
        Me.txtNombreSocia.TabIndex = 5
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.Location = New System.Drawing.Point(17, 55)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(106, 13)
        Me.lblNombreSocia.TabIndex = 4
        Me.lblNombreSocia.Text = "Nombre Completo"
        '
        'txtCodigo
        '
        Me.txtCodigo.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(359, 19)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(126, 20)
        Me.txtCodigo.TabIndex = 3
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.Location = New System.Drawing.Point(264, 26)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(82, 13)
        Me.lblCodigo.TabIndex = 2
        Me.lblCodigo.Text = "Código Socia"
        '
        'mscCedula
        '
        Me.mscCedula.Location = New System.Drawing.Point(129, 19)
        Me.mscCedula.Mask = "999-999999-9999L"
        Me.mscCedula.Name = "mscCedula"
        Me.mscCedula.Size = New System.Drawing.Size(126, 20)
        Me.mscCedula.TabIndex = 1
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.Location = New System.Drawing.Point(17, 26)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(82, 13)
        Me.lblCedula.TabIndex = 0
        Me.lblCedula.Text = "Cédula Socia"
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(444, 234)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(72, 27)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(372, 235)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(69, 27)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Acpetar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(297, 235)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 27)
        Me.btnBuscar.TabIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'errSocia
        '
        Me.errSocia.ContainerControl = Me
        '
        'frmSclReptFichaVerificacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 273)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclReptFichaVerificacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSclReptFichaVerificacion"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents mscCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreGrupo As System.Windows.Forms.Label
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents txtBarrio As System.Windows.Forms.TextBox
    Friend WithEvents lblbarrio As System.Windows.Forms.Label
    Friend WithEvents txtDistrito As System.Windows.Forms.TextBox
    Friend WithEvents lblDistrito As System.Windows.Forms.Label
    Friend WithEvents txtMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents lblMunicipio As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents lblDepartamento As System.Windows.Forms.Label
    Friend WithEvents dtFechaVerificacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFechaInscripcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFechaInscripcion As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents errSocia As System.Windows.Forms.ErrorProvider
End Class
