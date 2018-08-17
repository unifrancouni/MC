<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclFichaNotificacionCredito
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclFichaNotificacionCredito))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tbFicha = New System.Windows.Forms.ToolStrip
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAnular = New System.Windows.Forms.ToolStripButton
        Me.toolAnularR = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAprobar = New System.Windows.Forms.ToolStripButton
        Me.toolRechazar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolGenerarSD = New System.Windows.Forms.ToolStripButton
        Me.toolModificarSD = New System.Windows.Forms.ToolStripButton
        Me.toolVerificarSD = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolEnviosCARUNA = New System.Windows.Forms.ToolStripSplitButton
        Me.toolEnviarCARUNA = New System.Windows.Forms.ToolStripMenuItem
        Me.toolFichaEnviada = New System.Windows.Forms.ToolStripMenuItem
        Me.toolCancelarFichasI = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.toolImpresiones = New System.Windows.Forms.ToolStripSplitButton
        Me.toolImprimir = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirP = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirE = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirA = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirSD = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirTA = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirReporteA = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirContrato = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirEC = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirDenominaciones = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirPlanillaEfectivo = New System.Windows.Forms.ToolStripMenuItem
        Me.toolImprimirSolicitudCK = New System.Windows.Forms.ToolStripMenuItem
        Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpGenerales = New System.Windows.Forms.GroupBox
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboDepartamento = New C1.Win.C1List.C1Combo
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.grdFicha = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.ConstanciaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tbFicha.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbFicha
        '
        Me.tbFicha.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.ToolStripSeparator7, Me.toolAgregar, Me.toolModificar, Me.ToolStripSeparator4, Me.toolAnular, Me.toolAnularR, Me.ToolStripSeparator2, Me.toolAprobar, Me.toolRechazar, Me.ToolStripSeparator1, Me.toolGenerarSD, Me.toolModificarSD, Me.toolVerificarSD, Me.ToolStripSeparator3, Me.toolEnviosCARUNA, Me.ToolStripSeparator6, Me.toolImpresiones, Me.ToolStripSeparator5, Me.toolRefrescar, Me.toolAyuda, Me.toolCerrar})
        Me.tbFicha.Location = New System.Drawing.Point(0, 0)
        Me.tbFicha.Name = "tbFicha"
        Me.tbFicha.Size = New System.Drawing.Size(726, 25)
        Me.tbFicha.Stretch = True
        Me.tbFicha.TabIndex = 1
        Me.tbFicha.Text = "ToolStrip1"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 22)
        Me.toolBuscar.Text = "Buscar Ficha"
        Me.toolBuscar.ToolTipText = "Buscar Ficha"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar Ficha de Notificación"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar Ficha de Notificación"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'toolAnular
        '
        Me.toolAnular.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnular.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAnular.Name = "toolAnular"
        Me.toolAnular.Size = New System.Drawing.Size(23, 22)
        Me.toolAnular.Text = "Anular Ficha SIN Regeneración"
        Me.toolAnular.ToolTipText = "Anular Ficha SIN Regeneración"
        '
        'toolAnularR
        '
        Me.toolAnularR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnularR.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolAnularR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAnularR.Name = "toolAnularR"
        Me.toolAnularR.Size = New System.Drawing.Size(23, 22)
        Me.toolAnularR.Text = "Anular Ficha CON Regeneración"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'toolAprobar
        '
        Me.toolAprobar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAprobar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.toolAprobar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAprobar.Name = "toolAprobar"
        Me.toolAprobar.Size = New System.Drawing.Size(23, 22)
        Me.toolAprobar.Text = "Aprobar Ficha de Notificación"
        Me.toolAprobar.ToolTipText = "Aprobar Ficha de Notificación"
        '
        'toolRechazar
        '
        Me.toolRechazar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRechazar.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolRechazar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRechazar.Name = "toolRechazar"
        Me.toolRechazar.Size = New System.Drawing.Size(23, 22)
        Me.toolRechazar.Text = "Rechazar Ficha de Notificación"
        Me.toolRechazar.ToolTipText = "Rechazar Ficha de Notificación"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolGenerarSD
        '
        Me.toolGenerarSD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerarSD.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolGenerarSD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerarSD.Name = "toolGenerarSD"
        Me.toolGenerarSD.Size = New System.Drawing.Size(23, 22)
        Me.toolGenerarSD.Text = "Generar Solicitudes Desembolso"
        '
        'toolModificarSD
        '
        Me.toolModificarSD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarSD.Image = Global.SMUSURA0.My.Resources.Resources.edit
        Me.toolModificarSD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarSD.Name = "toolModificarSD"
        Me.toolModificarSD.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarSD.Text = "Modificar Solicitudes de Desembolso"
        '
        'toolVerificarSD
        '
        Me.toolVerificarSD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolVerificarSD.Image = Global.SMUSURA0.My.Resources.Resources.AprobarPartida16
        Me.toolVerificarSD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolVerificarSD.Name = "toolVerificarSD"
        Me.toolVerificarSD.Size = New System.Drawing.Size(23, 22)
        Me.toolVerificarSD.Text = "Verificar Solicitudes de Desembolso"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'toolEnviosCARUNA
        '
        Me.toolEnviosCARUNA.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEnviosCARUNA.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolEnviarCARUNA, Me.toolFichaEnviada, Me.toolCancelarFichasI})
        Me.toolEnviosCARUNA.Image = Global.SMUSURA0.My.Resources.Resources.Beneficiario16
        Me.toolEnviosCARUNA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEnviosCARUNA.Name = "toolEnviosCARUNA"
        Me.toolEnviosCARUNA.Size = New System.Drawing.Size(32, 22)
        Me.toolEnviosCARUNA.Text = "Envios a CARUNA"
        Me.toolEnviosCARUNA.ToolTipText = "Envios a CARUNA"
        '
        'toolEnviarCARUNA
        '
        Me.toolEnviarCARUNA.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolEnviarCARUNA.Name = "toolEnviarCARUNA"
        Me.toolEnviarCARUNA.Size = New System.Drawing.Size(215, 22)
        Me.toolEnviarCARUNA.Text = "Enviar ACTA a CARUNA"
        '
        'toolFichaEnviada
        '
        Me.toolFichaEnviada.Image = Global.SMUSURA0.My.Resources.Resources.bookmark_folder
        Me.toolFichaEnviada.Name = "toolFichaEnviada"
        Me.toolFichaEnviada.Size = New System.Drawing.Size(215, 22)
        Me.toolFichaEnviada.Text = "Marcar Ficha como Enviada"
        Me.toolFichaEnviada.ToolTipText = "Marcar Ficha como Enviada"
        '
        'toolCancelarFichasI
        '
        Me.toolCancelarFichasI.Image = Global.SMUSURA0.My.Resources.Resources.Cerrar16
        Me.toolCancelarFichasI.Name = "toolCancelarFichasI"
        Me.toolCancelarFichasI.Size = New System.Drawing.Size(215, 22)
        Me.toolCancelarFichasI.Text = "Cancelar Fichas Inscripción"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'toolImpresiones
        '
        Me.toolImpresiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImpresiones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolImprimir, Me.toolImprimirP, Me.toolImprimirE, Me.toolImprimirA, Me.toolImprimirSD, Me.toolImprimirTA, Me.toolImprimirReporteA, Me.toolImprimirContrato, Me.toolImprimirEC, Me.toolImprimirDenominaciones, Me.toolImprimirPlanillaEfectivo, Me.toolImprimirSolicitudCK, Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem, Me.ConstanciaDeToolStripMenuItem})
        Me.toolImpresiones.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImpresiones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImpresiones.Name = "toolImpresiones"
        Me.toolImpresiones.Size = New System.Drawing.Size(32, 22)
        Me.toolImpresiones.Text = "Impresión de Documentos"
        '
        'toolImprimir
        '
        Me.toolImprimir.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.toolImprimir.Name = "toolImprimir"
        Me.toolImprimir.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimir.Text = "Ficha de Notificación de Crédito CS4"
        '
        'toolImprimirP
        '
        Me.toolImprimirP.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.toolImprimirP.Name = "toolImprimirP"
        Me.toolImprimirP.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirP.Text = "Pagaré Grupo Solidario CS6"
        '
        'toolImprimirE
        '
        Me.toolImprimirE.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
        Me.toolImprimirE.Name = "toolImprimirE"
        Me.toolImprimirE.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirE.Text = "Ficha de Comité de Crédito CS5"
        '
        'toolImprimirA
        '
        Me.toolImprimirA.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolImprimirA.Name = "toolImprimirA"
        Me.toolImprimirA.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirA.Text = "Acta de Comité de Crédito CS9"
        '
        'toolImprimirSD
        '
        Me.toolImprimirSD.Image = Global.SMUSURA0.My.Resources.Resources.DocSoporte16
        Me.toolImprimirSD.Name = "toolImprimirSD"
        Me.toolImprimirSD.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirSD.Text = "Solicitudes de Desembolso CS11"
        '
        'toolImprimirTA
        '
        Me.toolImprimirTA.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.toolImprimirTA.Name = "toolImprimirTA"
        Me.toolImprimirTA.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirTA.Text = "Tablas de Amortización CS10"
        '
        'toolImprimirReporteA
        '
        Me.toolImprimirReporteA.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirReporteA.Name = "toolImprimirReporteA"
        Me.toolImprimirReporteA.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirReporteA.Text = "Reporte de Comité de Crédito CS12"
        '
        'toolImprimirContrato
        '
        Me.toolImprimirContrato.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.toolImprimirContrato.Name = "toolImprimirContrato"
        Me.toolImprimirContrato.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirContrato.Text = "Contrato de Crédito CS26"
        Me.toolImprimirContrato.ToolTipText = "Contrato de Crédito CS26"
        '
        'toolImprimirEC
        '
        Me.toolImprimirEC.Image = Global.SMUSURA0.My.Resources.Resources.appointment
        Me.toolImprimirEC.Name = "toolImprimirEC"
        Me.toolImprimirEC.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirEC.Text = "Estado de Cuenta Resumen CC38"
        Me.toolImprimirEC.ToolTipText = "Imprimir Estado Cuenta Resumen"
        Me.toolImprimirEC.Visible = False
        '
        'toolImprimirDenominaciones
        '
        Me.toolImprimirDenominaciones.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.toolImprimirDenominaciones.Name = "toolImprimirDenominaciones"
        Me.toolImprimirDenominaciones.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirDenominaciones.Text = "Desglose Billetes y Monedas CC39"
        Me.toolImprimirDenominaciones.ToolTipText = "Desglose Billetes y Monedas CC39"
        '
        'toolImprimirPlanillaEfectivo
        '
        Me.toolImprimirPlanillaEfectivo.Image = Global.SMUSURA0.My.Resources.Resources.Beneficiario16
        Me.toolImprimirPlanillaEfectivo.Name = "toolImprimirPlanillaEfectivo"
        Me.toolImprimirPlanillaEfectivo.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirPlanillaEfectivo.Text = "Entrega de Crédito por Grupo Solidario CC40"
        Me.toolImprimirPlanillaEfectivo.ToolTipText = "Entrega de Crédito por Grupo Solidario CC40"
        '
        'toolImprimirSolicitudCK
        '
        Me.toolImprimirSolicitudCK.Image = Global.SMUSURA0.My.Resources.Resources.bookmark_folder
        Me.toolImprimirSolicitudCK.Name = "toolImprimirSolicitudCK"
        Me.toolImprimirSolicitudCK.Size = New System.Drawing.Size(299, 22)
        Me.toolImprimirSolicitudCK.Text = "Solicitudes de Cheque CC1"
        '
        'ConstanciaDeCancelaciónCréditoToolStripMenuItem
        '
        Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem.Name = "ConstanciaDeCancelaciónCréditoToolStripMenuItem"
        Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem.Text = "Constancia de Cancelación Crédito"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 22)
        Me.toolAyuda.Text = "Ayuda"
        Me.toolAyuda.ToolTipText = "Ayuda"
        '
        'toolCerrar
        '
        Me.toolCerrar.BackColor = System.Drawing.Color.Transparent
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 22)
        Me.toolCerrar.Text = "Cerrar"
        Me.toolCerrar.ToolTipText = "Salir"
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpGenerales)
        Me.C1Sizer1.Controls.Add(Me.grdFicha)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(726, 472)
        Me.C1Sizer1.TabIndex = 4
        Me.C1Sizer1.TabStop = False
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.cdeFechaH)
        Me.grpGenerales.Controls.Add(Me.Label1)
        Me.grpGenerales.Controls.Add(Me.cboDepartamento)
        Me.grpGenerales.Controls.Add(Me.lblFechaH)
        Me.grpGenerales.Controls.Add(Me.cdeFechaD)
        Me.grpGenerales.Controls.Add(Me.lblFechaD)
        Me.grpGenerales.Location = New System.Drawing.Point(4, 28)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(718, 56)
        Me.grpGenerales.TabIndex = 17
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Seleccione Criterios de Filtro:  "
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(5, 21)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 38
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.Visible = False
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(205, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Departamento:"
        '
        'cboDepartamento
        '
        Me.cboDepartamento.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDepartamento.AutoCompletion = True
        Me.cboDepartamento.Caption = ""
        Me.cboDepartamento.CaptionHeight = 17
        Me.cboDepartamento.CaptionStyle = Style9
        Me.cboDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDepartamento.ColumnCaptionHeight = 17
        Me.cboDepartamento.ColumnFooterHeight = 17
        Me.cboDepartamento.ContentHeight = 15
        Me.cboDepartamento.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDepartamento.DisplayMember = "sNombre"
        Me.cboDepartamento.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboDepartamento.DropDownWidth = 254
        Me.cboDepartamento.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDepartamento.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDepartamento.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDepartamento.EditorHeight = 15
        Me.cboDepartamento.EvenRowStyle = Style10
        Me.cboDepartamento.ExtendRightColumn = True
        Me.cboDepartamento.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDepartamento.FooterStyle = Style11
        Me.cboDepartamento.GapHeight = 2
        Me.cboDepartamento.HeadingStyle = Style12
        Me.cboDepartamento.HighLightRowStyle = Style13
        Me.cboDepartamento.Images.Add(CType(resources.GetObject("cboDepartamento.Images"), System.Drawing.Image))
        Me.cboDepartamento.ItemHeight = 15
        Me.cboDepartamento.LimitToList = True
        Me.cboDepartamento.Location = New System.Drawing.Point(288, 20)
        Me.cboDepartamento.MatchEntryTimeout = CType(2000, Long)
        Me.cboDepartamento.MaxDropDownItems = CType(5, Short)
        Me.cboDepartamento.MaxLength = 32767
        Me.cboDepartamento.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDepartamento.Name = "cboDepartamento"
        Me.cboDepartamento.OddRowStyle = Style14
        Me.cboDepartamento.PartialRightColumn = False
        Me.cboDepartamento.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDepartamento.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDepartamento.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDepartamento.SelectedStyle = Style15
        Me.cboDepartamento.Size = New System.Drawing.Size(253, 21)
        Me.cboDepartamento.Style = Style16
        Me.cboDepartamento.SuperBack = True
        Me.cboDepartamento.TabIndex = 40
        Me.cboDepartamento.ValueMember = "nStbDepartamentoID"
        Me.cboDepartamento.PropBag = resources.GetString("cboDepartamento.PropBag")
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(42, 21)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(38, 13)
        Me.lblFechaH.TabIndex = 37
        Me.lblFechaH.Text = "Hasta:"
        Me.lblFechaH.Visible = False
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(5, 20)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 35
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.Visible = False
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(8, 21)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(97, 13)
        Me.lblFechaD.TabIndex = 36
        Me.lblFechaD.Text = "Resolución Desde:"
        Me.lblFechaD.Visible = False
        '
        'grdFicha
        '
        Me.grdFicha.AllowFilter = False
        Me.grdFicha.AllowUpdate = False
        Me.grdFicha.Caption = "Listado de Fichas de Notificación de Crédito"
        Me.grdFicha.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdFicha.FilterBar = True
        Me.grdFicha.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdFicha.Images.Add(CType(resources.GetObject("grdFicha.Images"), System.Drawing.Image))
        Me.grdFicha.Location = New System.Drawing.Point(4, 88)
        Me.grdFicha.Name = "grdFicha"
        Me.grdFicha.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdFicha.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdFicha.PreviewInfo.ZoomFactor = 75
        Me.grdFicha.PrintInfo.PageSettings = CType(resources.GetObject("grdFicha.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdFicha.Size = New System.Drawing.Size(718, 380)
        Me.grdFicha.TabIndex = 2
        Me.grdFicha.Text = "grdFicha"
        Me.grdFicha.PropBag = resources.GetString("grdFicha.PropBag")
        '
        'ConstanciaDeToolStripMenuItem
        '
        Me.ConstanciaDeToolStripMenuItem.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.ConstanciaDeToolStripMenuItem.Name = "ConstanciaDeToolStripMenuItem"
        Me.ConstanciaDeToolStripMenuItem.Size = New System.Drawing.Size(299, 22)
        Me.ConstanciaDeToolStripMenuItem.Text = "Constancia de Vigencia de Crédito "
        '
        'frmSclFichaNotificacionCredito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 472)
        Me.Controls.Add(Me.tbFicha)
        Me.Controls.Add(Me.C1Sizer1)
        Me.HelpProvider.SetHelpKeyword(Me, "Ficha de Notificación de Crédito")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclFichaNotificacionCredito"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.Text = "    Ficha de Notificación de Crédito"
        Me.tbFicha.ResumeLayout(False)
        Me.tbFicha.PerformLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbFicha As System.Windows.Forms.ToolStrip
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRechazar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdFicha As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents toolAprobar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents toolAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImpresiones As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolGenerarSD As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirSD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirTA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolModificarSD As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolVerificarSD As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirReporteA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAnularR As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents toolImprimirContrato As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboDepartamento As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents toolImprimirEC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirDenominaciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolImprimirPlanillaEfectivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolEnviosCARUNA As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents toolEnviarCARUNA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolFichaEnviada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolImprimirSolicitudCK As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolCancelarFichasI As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents ConstanciaDeCancelaciónCréditoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ConstanciaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
