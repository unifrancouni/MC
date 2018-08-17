<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccBusquedaFichasDetalles
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccBusquedaFichasDetalles))
        Me.grpTipoRpt = New System.Windows.Forms.GroupBox()
        Me.RadCodigoGrupo = New System.Windows.Forms.RadioButton()
        Me.RadCodigoFNC = New System.Windows.Forms.RadioButton()
        Me.RadSesion = New System.Windows.Forms.RadioButton()
        Me.RadGrupo = New System.Windows.Forms.RadioButton()
        Me.RadSocia = New System.Windows.Forms.RadioButton()
        Me.radCedula = New System.Windows.Forms.RadioButton()
        Me.LblConteo = New System.Windows.Forms.Label()
        Me.grpBotones = New System.Windows.Forms.GroupBox()
        Me.cmdUltimo = New System.Windows.Forms.Button()
        Me.cmdSiguiente = New System.Windows.Forms.Button()
        Me.CmdAnterior = New System.Windows.Forms.Button()
        Me.CmdPrimero = New System.Windows.Forms.Button()
        Me.grpMostrar = New System.Windows.Forms.GroupBox()
        Me.RadTodas = New System.Windows.Forms.RadioButton()
        Me.radFichasCanceladas = New System.Windows.Forms.RadioButton()
        Me.errSocia = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.grpSociaGe = New System.Windows.Forms.GroupBox()
        Me.GrpSesion = New System.Windows.Forms.GroupBox()
        Me.txtDelegacion = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFuente = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNoCheque = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtnSclFichaDetalle = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigoGrupo = New System.Windows.Forms.TextBox()
        Me.lblCodigoGrupo = New System.Windows.Forms.Label()
        Me.txtCodigoFNC = New System.Windows.Forms.TextBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.mtbNumeroSesion = New System.Windows.Forms.MaskedTextBox()
        Me.lblSesion = New System.Windows.Forms.Label()
        Me.GrpGrupoSolidario = New System.Windows.Forms.GroupBox()
        Me.txtGrupoSolidario = New System.Windows.Forms.TextBox()
        Me.lblGrupoSolidario = New System.Windows.Forms.Label()
        Me.TxtNombreGrupo = New System.Windows.Forms.TextBox()
        Me.lblGrupo = New System.Windows.Forms.Label()
        Me.GrpCedulaSocia = New System.Windows.Forms.GroupBox()
        Me.txtNombreSocia = New System.Windows.Forms.TextBox()
        Me.lblNombreSocia = New System.Windows.Forms.Label()
        Me.mtbNumCedula = New System.Windows.Forms.MaskedTextBox()
        Me.lblCedula = New System.Windows.Forms.Label()
        Me.GrpNombreCompleto = New System.Windows.Forms.GroupBox()
        Me.TxtSegundoApellido = New System.Windows.Forms.TextBox()
        Me.TxtPrimerApellido = New System.Windows.Forms.TextBox()
        Me.TxtSegundoNombre = New System.Windows.Forms.TextBox()
        Me.TxtPrimerNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNombre1 = New System.Windows.Forms.Label()
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.grpTipoRpt.SuspendLayout()
        Me.grpBotones.SuspendLayout()
        Me.grpMostrar.SuspendLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSociaGe.SuspendLayout()
        Me.GrpSesion.SuspendLayout()
        Me.GrpGrupoSolidario.SuspendLayout()
        Me.GrpCedulaSocia.SuspendLayout()
        Me.GrpNombreCompleto.SuspendLayout()
        Me.SuspendLayout()
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
        Me.grpTipoRpt.Location = New System.Drawing.Point(12, 2)
        Me.grpTipoRpt.Name = "grpTipoRpt"
        Me.grpTipoRpt.Size = New System.Drawing.Size(409, 68)
        Me.grpTipoRpt.TabIndex = 76
        Me.grpTipoRpt.TabStop = False
        Me.grpTipoRpt.Text = "Seleccione Tipo de Búsqueda:"
        '
        'RadCodigoGrupo
        '
        Me.RadCodigoGrupo.AutoSize = True
        Me.RadCodigoGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadCodigoGrupo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCodigoGrupo.Location = New System.Drawing.Point(268, 45)
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
        Me.RadGrupo.Location = New System.Drawing.Point(268, 19)
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
        Me.RadSocia.Size = New System.Drawing.Size(92, 17)
        Me.RadSocia.TabIndex = 1
        Me.RadSocia.Text = "Nombre Socia"
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
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(261, 23)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(0, 13)
        Me.LblConteo.TabIndex = 2
        '
        'grpBotones
        '
        Me.grpBotones.Controls.Add(Me.LblConteo)
        Me.grpBotones.Controls.Add(Me.cmdUltimo)
        Me.grpBotones.Controls.Add(Me.cmdSiguiente)
        Me.grpBotones.Controls.Add(Me.CmdAnterior)
        Me.grpBotones.Controls.Add(Me.CmdPrimero)
        Me.grpBotones.Location = New System.Drawing.Point(12, 524)
        Me.grpBotones.Name = "grpBotones"
        Me.grpBotones.Size = New System.Drawing.Size(583, 50)
        Me.grpBotones.TabIndex = 74
        Me.grpBotones.TabStop = False
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
        'grpMostrar
        '
        Me.grpMostrar.Controls.Add(Me.RadTodas)
        Me.grpMostrar.Controls.Add(Me.radFichasCanceladas)
        Me.grpMostrar.Location = New System.Drawing.Point(427, 2)
        Me.grpMostrar.Name = "grpMostrar"
        Me.grpMostrar.Size = New System.Drawing.Size(168, 68)
        Me.grpMostrar.TabIndex = 75
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
        'radFichasCanceladas
        '
        Me.radFichasCanceladas.AutoSize = True
        Me.radFichasCanceladas.Checked = True
        Me.radFichasCanceladas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radFichasCanceladas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.radFichasCanceladas.Location = New System.Drawing.Point(18, 19)
        Me.radFichasCanceladas.Name = "radFichasCanceladas"
        Me.radFichasCanceladas.Size = New System.Drawing.Size(115, 17)
        Me.radFichasCanceladas.TabIndex = 45
        Me.radFichasCanceladas.TabStop = True
        Me.radFichasCanceladas.Text = "Fichas Canceladas"
        Me.radFichasCanceladas.UseVisualStyleBackColor = True
        '
        'errSocia
        '
        Me.errSocia.ContainerControl = Me
        '
        'grpSociaGe
        '
        Me.grpSociaGe.Controls.Add(Me.GrpSesion)
        Me.grpSociaGe.Controls.Add(Me.GrpGrupoSolidario)
        Me.grpSociaGe.Controls.Add(Me.GrpCedulaSocia)
        Me.grpSociaGe.Controls.Add(Me.GrpNombreCompleto)
        Me.grpSociaGe.Location = New System.Drawing.Point(12, 70)
        Me.grpSociaGe.Name = "grpSociaGe"
        Me.grpSociaGe.Size = New System.Drawing.Size(583, 417)
        Me.grpSociaGe.TabIndex = 71
        Me.grpSociaGe.TabStop = False
        Me.grpSociaGe.Text = "Ingrese Datos Búsqueda:"
        '
        'GrpSesion
        '
        Me.GrpSesion.Controls.Add(Me.txtDelegacion)
        Me.GrpSesion.Controls.Add(Me.Label8)
        Me.GrpSesion.Controls.Add(Me.txtFuente)
        Me.GrpSesion.Controls.Add(Me.Label7)
        Me.GrpSesion.Controls.Add(Me.txtNoCheque)
        Me.GrpSesion.Controls.Add(Me.Label6)
        Me.GrpSesion.Controls.Add(Me.txtEstado)
        Me.GrpSesion.Controls.Add(Me.Label5)
        Me.GrpSesion.Controls.Add(Me.txtnSclFichaDetalle)
        Me.GrpSesion.Controls.Add(Me.Label1)
        Me.GrpSesion.Controls.Add(Me.txtCodigoGrupo)
        Me.GrpSesion.Controls.Add(Me.lblCodigoGrupo)
        Me.GrpSesion.Controls.Add(Me.txtCodigoFNC)
        Me.GrpSesion.Controls.Add(Me.lblCodigo)
        Me.GrpSesion.Controls.Add(Me.mtbNumeroSesion)
        Me.GrpSesion.Controls.Add(Me.lblSesion)
        Me.GrpSesion.Location = New System.Drawing.Point(16, 284)
        Me.GrpSesion.Name = "GrpSesion"
        Me.GrpSesion.Size = New System.Drawing.Size(554, 127)
        Me.GrpSesion.TabIndex = 52
        Me.GrpSesion.TabStop = False
        Me.GrpSesion.Text = "Códigos Ficha, Sesión, Grupo Solidario:"
        '
        'txtDelegacion
        '
        Me.txtDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDelegacion.Enabled = False
        Me.txtDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDelegacion.Location = New System.Drawing.Point(126, 105)
        Me.txtDelegacion.MaxLength = 9
        Me.txtDelegacion.Name = "txtDelegacion"
        Me.txtDelegacion.Size = New System.Drawing.Size(421, 22)
        Me.txtDelegacion.TabIndex = 70
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(12, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 18)
        Me.Label8.TabIndex = 69
        Me.Label8.Text = "Delegacion:"
        '
        'txtFuente
        '
        Me.txtFuente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFuente.Enabled = False
        Me.txtFuente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFuente.Location = New System.Drawing.Point(126, 77)
        Me.txtFuente.MaxLength = 9
        Me.txtFuente.Name = "txtFuente"
        Me.txtFuente.Size = New System.Drawing.Size(421, 22)
        Me.txtFuente.TabIndex = 68
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(12, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 18)
        Me.Label7.TabIndex = 67
        Me.Label7.Text = "Fuente:"
        '
        'txtNoCheque
        '
        Me.txtNoCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoCheque.Enabled = False
        Me.txtNoCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoCheque.Location = New System.Drawing.Point(470, 48)
        Me.txtNoCheque.MaxLength = 9
        Me.txtNoCheque.Name = "txtNoCheque"
        Me.txtNoCheque.Size = New System.Drawing.Size(78, 20)
        Me.txtNoCheque.TabIndex = 65
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(386, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Sol. Chk No."
        '
        'txtEstado
        '
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Enabled = False
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(285, 45)
        Me.txtEstado.MaxLength = 9
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(84, 20)
        Me.txtEstado.TabIndex = 64
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(211, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Estado"
        '
        'txtnSclFichaDetalle
        '
        Me.txtnSclFichaDetalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtnSclFichaDetalle.Enabled = False
        Me.txtnSclFichaDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnSclFichaDetalle.Location = New System.Drawing.Point(127, 45)
        Me.txtnSclFichaDetalle.MaxLength = 9
        Me.txtnSclFichaDetalle.Name = "txtnSclFichaDetalle"
        Me.txtnSclFichaDetalle.Size = New System.Drawing.Size(78, 20)
        Me.txtnSclFichaDetalle.TabIndex = 61
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Id Detalle Ficha"
        '
        'txtCodigoGrupo
        '
        Me.txtCodigoGrupo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoGrupo.Location = New System.Drawing.Point(285, 19)
        Me.txtCodigoGrupo.MaxLength = 9
        Me.txtCodigoGrupo.Name = "txtCodigoGrupo"
        Me.txtCodigoGrupo.Size = New System.Drawing.Size(84, 20)
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
        Me.mtbNumeroSesion.Location = New System.Drawing.Point(470, 19)
        Me.mtbNumeroSesion.Mask = "00-000-0000"
        Me.mtbNumeroSesion.Name = "mtbNumeroSesion"
        Me.mtbNumeroSesion.Size = New System.Drawing.Size(77, 20)
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
        Me.GrpGrupoSolidario.Location = New System.Drawing.Point(16, 194)
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
        Me.GrpNombreCompleto.Controls.Add(Me.TxtSegundoNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.TxtPrimerNombre)
        Me.GrpNombreCompleto.Controls.Add(Me.Label3)
        Me.GrpNombreCompleto.Controls.Add(Me.Label4)
        Me.GrpNombreCompleto.Controls.Add(Me.Label2)
        Me.GrpNombreCompleto.Controls.Add(Me.lblNombre1)
        Me.GrpNombreCompleto.Location = New System.Drawing.Point(16, 101)
        Me.GrpNombreCompleto.Name = "GrpNombreCompleto"
        Me.GrpNombreCompleto.Size = New System.Drawing.Size(554, 87)
        Me.GrpNombreCompleto.TabIndex = 42
        Me.GrpNombreCompleto.TabStop = False
        Me.GrpNombreCompleto.Text = "Nombre Socia:"
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
        'cmdBuscar
        '
        Me.cmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBuscar.Location = New System.Drawing.Point(368, 493)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(71, 25)
        Me.cmdBuscar.TabIndex = 70
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(522, 493)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 73
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(445, 493)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 72
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'frmSccBusquedaFichasDetalles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 586)
        Me.Controls.Add(Me.grpTipoRpt)
        Me.Controls.Add(Me.grpBotones)
        Me.Controls.Add(Me.grpMostrar)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpSociaGe)
        Me.Name = "frmSccBusquedaFichasDetalles"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Datos de Busquedas de Detalle de Fichas de Notificacion"
        Me.grpTipoRpt.ResumeLayout(False)
        Me.grpTipoRpt.PerformLayout()
        Me.grpBotones.ResumeLayout(False)
        Me.grpBotones.PerformLayout()
        Me.grpMostrar.ResumeLayout(False)
        Me.grpMostrar.PerformLayout()
        CType(Me.errSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSociaGe.ResumeLayout(False)
        Me.GrpSesion.ResumeLayout(False)
        Me.GrpSesion.PerformLayout()
        Me.GrpGrupoSolidario.ResumeLayout(False)
        Me.GrpGrupoSolidario.PerformLayout()
        Me.GrpCedulaSocia.ResumeLayout(False)
        Me.GrpCedulaSocia.PerformLayout()
        Me.GrpNombreCompleto.ResumeLayout(False)
        Me.GrpNombreCompleto.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdUltimo As System.Windows.Forms.Button
    Friend WithEvents cmdSiguiente As System.Windows.Forms.Button
    Friend WithEvents grpTipoRpt As System.Windows.Forms.GroupBox
    Friend WithEvents RadCodigoGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents RadCodigoFNC As System.Windows.Forms.RadioButton
    Friend WithEvents RadSesion As System.Windows.Forms.RadioButton
    Friend WithEvents RadGrupo As System.Windows.Forms.RadioButton
    Friend WithEvents RadSocia As System.Windows.Forms.RadioButton
    Friend WithEvents radCedula As System.Windows.Forms.RadioButton
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents CmdAnterior As System.Windows.Forms.Button
    Friend WithEvents CmdPrimero As System.Windows.Forms.Button
    Friend WithEvents grpBotones As System.Windows.Forms.GroupBox
    Friend WithEvents grpMostrar As System.Windows.Forms.GroupBox
    Friend WithEvents RadTodas As System.Windows.Forms.RadioButton
    Friend WithEvents radFichasCanceladas As System.Windows.Forms.RadioButton
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents errSocia As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpSociaGe As System.Windows.Forms.GroupBox
    Friend WithEvents GrpSesion As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigoGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigoGrupo As System.Windows.Forms.Label
    Friend WithEvents txtCodigoFNC As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents mtbNumeroSesion As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblSesion As System.Windows.Forms.Label
    Friend WithEvents GrpGrupoSolidario As System.Windows.Forms.GroupBox
    Friend WithEvents txtGrupoSolidario As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupoSolidario As System.Windows.Forms.Label
    Friend WithEvents TxtNombreGrupo As System.Windows.Forms.TextBox
    Friend WithEvents lblGrupo As System.Windows.Forms.Label
    Friend WithEvents GrpCedulaSocia As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreSocia As System.Windows.Forms.TextBox
    Friend WithEvents lblNombreSocia As System.Windows.Forms.Label
    Friend WithEvents mtbNumCedula As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents GrpNombreCompleto As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSegundoApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerApellido As System.Windows.Forms.TextBox
    Friend WithEvents TxtSegundoNombre As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrimerNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNombre1 As System.Windows.Forms.Label
    Friend WithEvents txtnSclFichaDetalle As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNoCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDelegacion As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFuente As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
