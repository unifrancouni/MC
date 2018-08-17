<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclBusquedaFichas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclBusquedaFichas))
        Me.grpSociaGe = New System.Windows.Forms.GroupBox
        Me.GrpSesion = New System.Windows.Forms.GroupBox
        Me.txtCodigoGrupo = New System.Windows.Forms.TextBox
        Me.lblCodigoGrupo = New System.Windows.Forms.Label
        Me.txtCodigoFNC = New System.Windows.Forms.TextBox
        Me.lblCodigo = New System.Windows.Forms.Label
        Me.mtbNumeroSesion = New System.Windows.Forms.MaskedTextBox
        Me.lblSesion = New System.Windows.Forms.Label
        Me.GrpGrupoSolidario = New System.Windows.Forms.GroupBox
        Me.txtGrupoSolidario = New System.Windows.Forms.TextBox
        Me.lblGrupoSolidario = New System.Windows.Forms.Label
        Me.TxtNombreGrupo = New System.Windows.Forms.TextBox
        Me.lblGrupo = New System.Windows.Forms.Label
        Me.GrpCedulaSocia = New System.Windows.Forms.GroupBox
        Me.txtNombreSocia = New System.Windows.Forms.TextBox
        Me.lblNombreSocia = New System.Windows.Forms.Label
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox
        Me.lblCedula = New System.Windows.Forms.Label
        Me.GrpNombreCompleto = New System.Windows.Forms.GroupBox
        Me.TxtSegundoApellido = New System.Windows.Forms.TextBox
        Me.TxtPrimerApellido = New System.Windows.Forms.TextBox
        Me.txtNombreCoordinadora = New System.Windows.Forms.TextBox
        Me.lblNombreCoordinadora = New System.Windows.Forms.Label
        Me.TxtSegundoNombre = New System.Windows.Forms.TextBox
        Me.TxtPrimerNombre = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblNombre1 = New System.Windows.Forms.Label
        Me.errSocia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpBotones = New System.Windows.Forms.GroupBox
        Me.LblConteo = New System.Windows.Forms.Label
        Me.cmdUltimo = New System.Windows.Forms.Button
        Me.cmdSiguiente = New System.Windows.Forms.Button
        Me.CmdAnterior = New System.Windows.Forms.Button
        Me.CmdPrimero = New System.Windows.Forms.Button
        Me.cmdBuscar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.grpTipoRpt = New System.Windows.Forms.GroupBox
        Me.RadCodigoGrupo = New System.Windows.Forms.RadioButton
        Me.RadCodigoFNC = New System.Windows.Forms.RadioButton
        Me.RadSesion = New System.Windows.Forms.RadioButton
        Me.RadGrupo = New System.Windows.Forms.RadioButton
        Me.RadSocia = New System.Windows.Forms.RadioButton
        Me.radCedula = New System.Windows.Forms.RadioButton
        Me.grpMostrar = New System.Windows.Forms.GroupBox
        Me.RadTodas = New System.Windows.Forms.RadioButton
        Me.radFichasActivas = New System.Windows.Forms.RadioButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpSociaGe.SuspendLayout()
        Me.GrpSesion.SuspendLayout()
        Me.GrpGrupoSolidario.SuspendLayout()
        Me.GrpCedulaSocia.SuspendLayout()
        Me.GrpNombreCompleto.SuspendLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBotones.SuspendLayout()
        Me.grpTipoRpt.SuspendLayout()
        Me.grpMostrar.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.GrpSesion)
        Me.grpSociaGe.Controls.Add(Me.GrpGrupoSolidario)
        Me.grpSociaGe.Controls.Add(Me.GrpCedulaSocia)
        Me.grpSociaGe.Controls.Add(Me.GrpNombreCompleto)
        Me.grpSociaGe.Location = New System.Drawing.Point(15, 82)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(583, 376)
        Me.grpSociaGe.TabIndex = 0
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Ingrese Datos Búsqueda:"
        '
        'GrpSesion
        '
        Me.GrpSesion.Controls.Add(Me.txtCodigoGrupo)
        Me.GrpSesion.Controls.Add(Me.lblCodigoGrupo)
        Me.GrpSesion.Controls.Add(Me.txtCodigoFNC)
        Me.GrpSesion.Controls.Add(Me.lblCodigo)
        Me.GrpSesion.Controls.Add(Me.mtbNumeroSesion)
        Me.GrpSesion.Controls.Add(Me.lblSesion)
        Me.GrpSesion.Location = New System.Drawing.Point(16, 318)
        Me.GrpSesion.Name = "GrpSesion"
        Me.GrpSesion.Size = New System.Drawing.Size(554, 49)
        Me.GrpSesion.TabIndex = 52
        Me.GrpSesion.TabStop = False
        Me.GrpSesion.Text = "Códigos Ficha, Sesión, Grupo Solidario:"
        '
        'txtCodigoGrupo
        '
        Me.txtCodigoGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoGrupo.Location = New System.Drawing.Point(291, 19)
        Me.txtCodigoGrupo.MaxLength = 9
        Me.txtCodigoGrupo.Name = "txtCodigoGrupo"
        Me.txtCodigoGrupo.Size = New System.Drawing.Size(78, 20)
        Me.txtCodigoGrupo.TabIndex = 36
        '
        'lblCodigoGrupo
        '
        Me.lblCodigoGrupo.AutoSize = True
        Me.lblCodigoGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigoGrupo.Location = New System.Drawing.Point(210, 22)
        Me.lblCodigoGrupo.Name = "lblCodigoGrupo"
        Me.lblCodigoGrupo.Size = New System.Drawing.Size(75, 13)
        Me.lblCodigoGrupo.TabIndex = 35
        Me.lblCodigoGrupo.Text = "Código Grupo:"
        '
        'txtCodigoFNC
        '
        Me.txtCodigoFNC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoFNC.Location = New System.Drawing.Point(126, 19)
        Me.txtCodigoFNC.MaxLength = 9
        Me.txtCodigoFNC.Name = "txtCodigoFNC"
        Me.txtCodigoFNC.Size = New System.Drawing.Size(78, 20)
        Me.txtCodigoFNC.TabIndex = 0
        '
        'lblCodigo
        '
        Me.lblCodigo.AutoSize = True
        Me.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCodigo.Location = New System.Drawing.Point(9, 22)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.Size(87, 13)
        Me.lblCodigo.TabIndex = 34
        Me.lblCodigo.Text = "Código de Ficha:"
        '
        'mtbNumeroSesion
        '
        Me.mtbNumeroSesion.Location = New System.Drawing.Point(467, 19)
        Me.mtbNumeroSesion.Mask = "00-000-0000"
        Me.mtbNumeroSesion.Name = "mtbNumeroSesion"
        Me.mtbNumeroSesion.Size = New System.Drawing.Size(80, 20)
        Me.mtbNumeroSesion.TabIndex = 1
        '
        'lblSesion
        '
        Me.lblSesion.AutoSize = True
        Me.lblSesion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblSesion.Location = New System.Drawing.Point(378, 22)
        Me.lblSesion.Name = "lblSesion"
        Me.lblSesion.Size = New System.Drawing.Size(83, 13)
        Me.lblSesion.TabIndex = 32
        Me.lblSesion.Text = "No. Resolución:"
        '
        'GrpGrupoSolidario
        '
        Me.GrpGrupoSolidario.Controls.Add(Me.txtGrupoSolidario)
        Me.GrpGrupoSolidario.Controls.Add(Me.lblGrupoSolidario)
        Me.GrpGrupoSolidario.Controls.Add(Me.TxtNombreGrupo)
        Me.GrpGrupoSolidario.Controls.Add(Me.lblGrupo)
        Me.GrpGrupoSolidario.Location = New System.Drawing.Point(16, 228)
        Me.GrpGrupoSolidario.Name = "GrpGrupoSolidario"
        Me.GrpGrupoSolidario.Size = New System.Drawing.Size(554, 84)
        Me.GrpGrupoSolidario.TabIndex = 52
        Me.GrpGrupoSolidario.TabStop = False
        Me.GrpGrupoSolidario.Text = "Nombre Grupo Solidario:"
        '
        'txtGrupoSolidario
        '
        Me.txtGrupoSolidario.BackColor = System.Drawing.SystemColors.Info
        Me.txtGrupoSolidario.Enabled = False
        Me.txtGrupoSolidario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrupoSolidario.Location = New System.Drawing.Point(127, 56)
        Me.txtGrupoSolidario.Name = "txtGrupoSolidario"
        Me.txtGrupoSolidario.ReadOnly = True
        Me.txtGrupoSolidario.Size = New System.Drawing.Size(420, 20)
        Me.txtGrupoSolidario.TabIndex = 1
        Me.txtGrupoSolidario.Tag = "LAYOUT:FLAT"
        '
        'lblGrupoSolidario
        '
        Me.lblGrupoSolidario.AutoSize = True
        Me.lblGrupoSolidario.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupoSolidario.Location = New System.Drawing.Point(9, 59)
        Me.lblGrupoSolidario.Name = "lblGrupoSolidario"
        Me.lblGrupoSolidario.Size = New System.Drawing.Size(82, 13)
        Me.lblGrupoSolidario.TabIndex = 49
        Me.lblGrupoSolidario.Text = "Grupo Solidario:"
        '
        'TxtNombreGrupo
        '
        Me.TxtNombreGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNombreGrupo.Location = New System.Drawing.Point(127, 23)
        Me.TxtNombreGrupo.Name = "TxtNombreGrupo"
        Me.TxtNombreGrupo.Size = New System.Drawing.Size(421, 20)
        Me.TxtNombreGrupo.TabIndex = 0
        '
        'lblGrupo
        '
        Me.lblGrupo.AutoSize = True
        Me.lblGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblGrupo.Location = New System.Drawing.Point(7, 26)
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Size = New System.Drawing.Size(122, 13)
        Me.lblGrupo.TabIndex = 41
        Me.lblGrupo.Text = "Nombre Grupo Solidario:"
        '
        'GrpCedulaSocia
        '
        Me.GrpCedulaSocia.Controls.Add(Me.txtNombreSocia)
        Me.GrpCedulaSocia.Controls.Add(Me.lblNombreSocia)
        Me.GrpCedulaSocia.Controls.Add(Me.mtbNumCedula)
        Me.GrpCedulaSocia.Controls.Add(Me.lblCedula)
        Me.GrpCedulaSocia.Location = New System.Drawing.Point(16, 19)
        Me.GrpCedulaSocia.Name = "GrpCedulaSocia"
        Me.GrpCedulaSocia.Size = New System.Drawing.Size(554, 76)
        Me.GrpCedulaSocia.TabIndex = 51
        Me.GrpCedulaSocia.TabStop = False
        Me.GrpCedulaSocia.Text = "Cédula Socia:"
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreSocia.Enabled = False
        Me.txtNombreSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreSocia.Location = New System.Drawing.Point(126, 45)
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.ReadOnly = True
        Me.txtNombreSocia.Size = New System.Drawing.Size(421, 20)
        Me.txtNombreSocia.TabIndex = 1
        Me.txtNombreSocia.Tag = "LAYOUT:FLAT"
        '
        'lblNombreSocia
        '
        Me.lblNombreSocia.AutoSize = True
        Me.lblNombreSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreSocia.Location = New System.Drawing.Point(6, 48)
        Me.lblNombreSocia.Name = "lblNombreSocia"
        Me.lblNombreSocia.Size = New System.Drawing.Size(103, 13)
        Me.lblNombreSocia.TabIndex = 50
        Me.lblNombreSocia.Text = "Nombre de la Socia:"
        '
        'mtbNumCedula
        '
        Me.mtbNumCedula.Location = New System.Drawing.Point(127, 19)
        Me.mtbNumCedula.Mask = "000-000000-0000>L"
        Me.mtbNumCedula.Name = "mtbNumCedula"
        Me.mtbNumCedula.Size = New System.Drawing.Size(126, 20)
        Me.mtbNumCedula.TabIndex = 0
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(9, 22)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(83, 13)
        Me.lblCedula.TabIndex = 32
        Me.lblCedula.Text = "Número Cédula:"
        '
        'GrpNombreCompleto
        '
        Me.GrpNombreCompleto.Controls.Add(Me.TxtSegundoApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtPrimerApellido)
        Me.GrpNombreCompleto.Controls.Add(Me.txtNombreCoordinadora)
        Me.GrpNombreCompleto.Controls.Add(Me.lblNombreCoordinadora)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtSegundoNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtPrimerNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.Label3)
        Me.GrpNombreCompleto.Controls.Add(Me.Label4)
        Me.GrpNombreCompleto.Controls.Add(Me.Label2)
        Me.GrpNombreCompleto.Controls.Add(Me.lblNombre1)
        Me.GrpNombreCompleto.Location = New System.Drawing.Point(16, 101)
        Me.GrpNombreCompleto.Name = "GrpNombreCompleto"
        Me.GrpNombreCompleto.Size = New System.Drawing.Size(554, 121)
        Me.GrpNombreCompleto.TabIndex = 42
        Me.GrpNombreCompleto.TabStop = False
        Me.GrpNombreCompleto.Text = "Nombres Coordinadora:"
        '
        'TxtSegundoApellido
        '
        Me.TxtSegundoApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSegundoApellido.Location = New System.Drawing.Point(389, 60)
        Me.TxtSegundoApellido.Name = "TxtSegundoApellido"
        Me.TxtSegundoApellido.Size = New System.Drawing.Size(158, 20)
        Me.TxtSegundoApellido.TabIndex = 3
        '
        'TxtPrimerApellido
        '
        Me.TxtPrimerApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrimerApellido.Location = New System.Drawing.Point(127, 60)
        Me.TxtPrimerApellido.Name = "TxtPrimerApellido"
        Me.TxtPrimerApellido.Size = New System.Drawing.Size(158, 20)
        Me.TxtPrimerApellido.TabIndex = 2
        '
        'txtNombreCoordinadora
        '
        Me.txtNombreCoordinadora.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreCoordinadora.Enabled = False
        Me.txtNombreCoordinadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCoordinadora.Location = New System.Drawing.Point(127, 89)
        Me.txtNombreCoordinadora.Name = "txtNombreCoordinadora"
        Me.txtNombreCoordinadora.ReadOnly = True
        Me.txtNombreCoordinadora.Size = New System.Drawing.Size(421, 20)
        Me.txtNombreCoordinadora.TabIndex = 4
        Me.txtNombreCoordinadora.Tag = "LAYOUT:FLAT"
        '
        'lblNombreCoordinadora
        '
        Me.lblNombreCoordinadora.AutoSize = True
        Me.lblNombreCoordinadora.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombreCoordinadora.Location = New System.Drawing.Point(6, 89)
        Me.lblNombreCoordinadora.Name = "lblNombreCoordinadora"
        Me.lblNombreCoordinadora.Size = New System.Drawing.Size(113, 13)
        Me.lblNombreCoordinadora.TabIndex = 48
        Me.lblNombreCoordinadora.Text = "Nombre Coordinadora:"
        '
        'TxtSegundoNombre
        '
        Me.TxtSegundoNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSegundoNombre.Location = New System.Drawing.Point(389, 30)
        Me.TxtSegundoNombre.Name = "TxtSegundoNombre"
        Me.TxtSegundoNombre.Size = New System.Drawing.Size(158, 20)
        Me.TxtSegundoNombre.TabIndex = 1
        '
        'TxtPrimerNombre
        '
        Me.TxtPrimerNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtPrimerNombre.Location = New System.Drawing.Point(127, 27)
        Me.TxtPrimerNombre.Name = "TxtPrimerNombre"
        Me.TxtPrimerNombre.Size = New System.Drawing.Size(158, 20)
        Me.TxtPrimerNombre.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(290, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Segundo Apellido:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(7, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Primer Apellido:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(290, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Segundo Nombre:"
        '
        'lblNombre1
        '
        Me.lblNombre1.AutoSize = True
        Me.lblNombre1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre1.Location = New System.Drawing.Point(7, 30)
        Me.lblNombre1.Name = "lblNombre1"
        Me.lblNombre1.Size = New System.Drawing.Size(79, 13)
        Me.lblNombre1.TabIndex = 41
        Me.lblNombre1.Text = "Primer Nombre:"
        '
        'errSocia
        '
        Me.errSocia.ContainerControl = Me
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(15, 495)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(583, 50)
        Me.grpBotones.TabIndex = 10
        Me.grpBotones.TabStop = False
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(261, 23)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(0, 13)
        Me.LblConteo.TabIndex = 2
        '
        'cmdUltimo
        '
        Me.cmdUltimo.Image = Global.SMUSURA0.My.Resources.Resources.player_end
        Me.cmdUltimo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdUltimo.Location = New System.Drawing.Point(497, 17)
        Me.cmdUltimo.Name = "cmdUltimo"
        Me.cmdUltimo.Size = New System.Drawing.Size(73, 25)
        Me.cmdUltimo.TabIndex = 4
        Me.cmdUltimo.Text = "Ultimo"
        Me.cmdUltimo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdUltimo.UseVisualStyleBackColor = True
        '
        'cmdSiguiente
        '
        Me.cmdSiguiente.Image = Global.SMUSURA0.My.Resources.Resources.rightarrow
        Me.cmdSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSiguiente.Location = New System.Drawing.Point(418, 17)
        Me.cmdSiguiente.Name = "cmdSiguiente"
        Me.cmdSiguiente.Size = New System.Drawing.Size(73, 25)
        Me.cmdSiguiente.TabIndex = 3
        Me.cmdSiguiente.Text = "Siguiente"
        Me.cmdSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSiguiente.UseVisualStyleBackColor = True
        '
        'CmdAnterior
        '
        Me.CmdAnterior.Image = Global.SMUSURA0.My.Resources.Resources.leftarrow
        Me.CmdAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAnterior.Location = New System.Drawing.Point(102, 17)
        Me.CmdAnterior.Name = "CmdAnterior"
        Me.CmdAnterior.Size = New System.Drawing.Size(73, 25)
        Me.CmdAnterior.TabIndex = 1
        Me.CmdAnterior.Text = "Anterior"
        Me.CmdAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAnterior.UseVisualStyleBackColor = True
        '
        'CmdPrimero
        '
        Me.CmdPrimero.Image = Global.SMUSURA0.My.Resources.Resources.player_start
        Me.CmdPrimero.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrimero.Location = New System.Drawing.Point(23, 17)
        Me.CmdPrimero.Name = "CmdPrimero"
        Me.CmdPrimero.Size = New System.Drawing.Size(73, 25)
        Me.CmdPrimero.TabIndex = 0
        Me.CmdPrimero.Text = "Primero"
        Me.CmdPrimero.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrimero.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(371, 464)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 0
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(525, 464)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(448, 464)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'grpTipoRpt
        '
        Me.grpTipoRpt.Controls.Add(Me.RadCodigoGrupo)
        Me.grpTipoRpt.Controls.Add(Me.RadCodigoFNC)
        Me.grpTipoRpt.Controls.Add(Me.RadSesion)
        Me.grpTipoRpt.Controls.Add(Me.RadGrupo)
        Me.grpTipoRpt.Controls.Add(Me.RadSocia)
        Me.grpTipoRpt.Controls.Add(Me.radCedula)
        Me.grpTipoRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpTipoRpt.ForeColor = System.Drawing.Color.Black
        Me.grpTipoRpt.Location = New System.Drawing.Point(15, 8)
        Me.grpTipoRpt.Name = "grpTipoRpt"
        Me.grpTipoRpt.Size = New System.Drawing.Size(459, 68)
        Me.grpTipoRpt.TabIndex = 69
        Me.grpTipoRpt.TabStop = False
        Me.grpTipoRpt.Text = "Seleccione Tipo de Búsqueda:"
        '
        'RadCodigoGrupo
        '
        Me.RadCodigoGrupo.AutoSize = True
        Me.RadCodigoGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCodigoGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCodigoGrupo.Location = New System.Drawing.Point(291, 41)
        Me.RadCodigoGrupo.Name = "RadCodigoGrupo"
        Me.RadCodigoGrupo.Size = New System.Drawing.Size(133, 17)
        Me.RadCodigoGrupo.TabIndex = 5
        Me.RadCodigoGrupo.Text = "Código Grupo Solidario"
        Me.RadCodigoGrupo.UseVisualStyleBackColor = True
        '
        'RadCodigoFNC
        '
        Me.RadCodigoFNC.AutoSize = True
        Me.RadCodigoFNC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCodigoFNC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCodigoFNC.Location = New System.Drawing.Point(30, 45)
        Me.RadCodigoFNC.Name = "RadCodigoFNC"
        Me.RadCodigoFNC.Size = New System.Drawing.Size(87, 17)
        Me.RadCodigoFNC.TabIndex = 3
        Me.RadCodigoFNC.Text = "Código Ficha"
        Me.RadCodigoFNC.UseVisualStyleBackColor = True
        '
        'RadSesion
        '
        Me.RadSesion.AutoSize = True
        Me.RadSesion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSesion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadSesion.Location = New System.Drawing.Point(142, 45)
        Me.RadSesion.Name = "RadSesion"
        Me.RadSesion.Size = New System.Drawing.Size(118, 17)
        Me.RadSesion.TabIndex = 4
        Me.RadSesion.Text = "Número Resolución"
        Me.RadSesion.UseVisualStyleBackColor = True
        '
        'RadGrupo
        '
        Me.RadGrupo.AutoSize = True
        Me.RadGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadGrupo.Location = New System.Drawing.Point(291, 22)
        Me.RadGrupo.Name = "RadGrupo"
        Me.RadGrupo.Size = New System.Drawing.Size(137, 17)
        Me.RadGrupo.TabIndex = 2
        Me.RadGrupo.Text = "Nombre Grupo Solidario"
        Me.RadGrupo.UseVisualStyleBackColor = True
        '
        'RadSocia
        '
        Me.RadSocia.AutoSize = True
        Me.RadSocia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadSocia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadSocia.Location = New System.Drawing.Point(142, 22)
        Me.RadSocia.Name = "RadSocia"
        Me.RadSocia.Size = New System.Drawing.Size(133, 17)
        Me.RadSocia.TabIndex = 1
        Me.RadSocia.Text = "Nombres Coordinadora"
        Me.RadSocia.UseVisualStyleBackColor = True
        '
        'radCedula
        '
        Me.radCedula.AutoSize = True
        Me.radCedula.Checked = True
        Me.radCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radCedula.Location = New System.Drawing.Point(30, 22)
        Me.radCedula.Name = "radCedula"
        Me.radCedula.Size = New System.Drawing.Size(88, 17)
        Me.radCedula.TabIndex = 0
        Me.radCedula.TabStop = True
        Me.radCedula.Text = "Cédula Socia"
        Me.radCedula.UseVisualStyleBackColor = True
        '
        'grpMostrar
        '
        Me.grpMostrar.Controls.Add(Me.RadTodas)
        Me.grpMostrar.Controls.Add(Me.radFichasActivas)
        Me.grpMostrar.Location = New System.Drawing.Point(480, 8)
        Me.grpMostrar.Name = "grpMostrar"
        Me.grpMostrar.Size = New System.Drawing.Size(118, 68)
        Me.grpMostrar.TabIndex = 53
        Me.grpMostrar.TabStop = False
        Me.grpMostrar.Text = "Mostrar: "
        '
        'RadTodas
        '
        Me.RadTodas.AutoSize = True
        Me.RadTodas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadTodas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadTodas.Location = New System.Drawing.Point(18, 41)
        Me.RadTodas.Name = "RadTodas"
        Me.RadTodas.Size = New System.Drawing.Size(55, 17)
        Me.RadTodas.TabIndex = 46
        Me.RadTodas.Text = "Todas"
        Me.RadTodas.UseVisualStyleBackColor = True
        '
        'radFichasActivas
        '
        Me.radFichasActivas.AutoSize = True
        Me.radFichasActivas.Checked = True
        Me.radFichasActivas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radFichasActivas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radFichasActivas.Location = New System.Drawing.Point(18, 19)
        Me.radFichasActivas.Name = "radFichasActivas"
        Me.radFichasActivas.Size = New System.Drawing.Size(94, 17)
        Me.radFichasActivas.TabIndex = 45
        Me.radFichasActivas.TabStop = True
        Me.radFichasActivas.Text = "Fichas Activas"
        Me.radFichasActivas.UseVisualStyleBackColor = True
        '
        'frmSclBusquedaFichas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 549)
        Me.Controls.Add(Me.grpMostrar)
        Me.Controls.Add(Me.grpTipoRpt)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpSociaGe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Ficha de Notificación de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSclBusquedaFichas"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  Datos de Búsqueda de Fichas de Notificación:"
        Me.grpSociaGe.ResumeLayout(False)
        Me.GrpSesion.ResumeLayout(False)
        Me.GrpSesion.PerformLayout()
        Me.GrpGrupoSolidario.ResumeLayout(False)
        Me.GrpGrupoSolidario.PerformLayout()
        Me.GrpCedulaSocia.ResumeLayout(False)
        Me.GrpCedulaSocia.PerformLayout()
        Me.GrpNombreCompleto.ResumeLayout(False)
        Me.GrpNombreCompleto.PerformLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.grpTipoRpt.ResumeLayout(False)
        Me.grpTipoRpt.PerformLayout()
        Me.grpMostrar.ResumeLayout(False)
        Me.grpMostrar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errSocia As System.Windows.Forms.ErrorProvider
    Friend WithEvents GrpNombreCompleto As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtSegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents grpTipoRpt As System.Windows.Forms.GroupBox
    Friend WithEvents RadSocia As System.Windows.Forms.RadioButton
    Friend WithEvents radCedula As System.Windows.Forms.RadioButton
    Friend WithEvents RadGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents RadSesion As System.Windows.Forms.RadioButton
    Friend WithEvents GrpCedulaSocia As System.Windows.Forms.GroupBox
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents GrpGrupoSolidario As System.Windows.Forms.GroupBox
    Friend WithEvents TxtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents txtGrupoSolidario As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupoSolidario As System.Windows.Forms.Label
    Friend WithEvents txtNombreCoordinadora As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreCoordinadora As System.Windows.Forms.Label
    Friend WithEvents GrpSesion As System.Windows.Forms.GroupBox
    Friend WithEvents lblSesion As System.Windows.Forms.Label
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents mtbNumeroSesion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents RadCodigoFNC As System.Windows.Forms.RadioButton
    Friend WithEvents txtCodigoFNC As System.Windows.Forms.TextBox
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents grpMostrar As System.Windows.Forms.GroupBox
    Friend WithEvents RadTodas As System.Windows.Forms.RadioButton
    Friend WithEvents radFichasActivas As System.Windows.Forms.RadioButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents txtCodigoGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoGrupo As System.Windows.Forms.Label
    Friend WithEvents RadCodigoGrupo As System.Windows.Forms.RadioButton
End Class
