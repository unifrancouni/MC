<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccCargaAplicar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccCargaAplicar))
        Me.GrpEncabezado = New System.Windows.Forms.GroupBox
        Me.txtEnvioNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNombreCaja = New System.Windows.Forms.TextBox
        Me.txtSteCajaId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabArqueo = New C1.Win.C1Command.C1DockingTab
        Me.TabTotalesCajeros = New C1.Win.C1Command.C1DockingTabPage
        Me.GrdTotalesCajeros = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tabMarcadosError = New C1.Win.C1Command.C1DockingTabPage
        Me.tbMarcadosError = New System.Windows.Forms.ToolStrip
        Me.toolModificarQ = New System.Windows.Forms.ToolStripButton
        Me.toolModificarC = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolRefrescarE = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaE = New System.Windows.Forms.ToolStripButton
        Me.grdAnuladosConfirmar = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tabConflictosCentral = New C1.Win.C1Command.C1DockingTabPage
        Me.tbArqueoDocumentos = New System.Windows.Forms.ToolStrip
        Me.toolIncorporarR = New System.Windows.Forms.ToolStripButton
        Me.toolAgregarR = New System.Windows.Forms.ToolStripButton
        Me.toolIncorporarRecibo = New System.Windows.Forms.ToolStripButton
        Me.toolModificarR = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarR = New System.Windows.Forms.ToolStripButton
        Me.toolEliminarRS = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAnularR = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescarR = New System.Windows.Forms.ToolStripButton
        Me.toolSeparador2 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyudaR = New System.Windows.Forms.ToolStripButton
        Me.lblSinDisponibilidad = New System.Windows.Forms.Label
        Me.grdConflictos = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tabArqueosRecuperacion = New C1.Win.C1Command.C1DockingTabPage
        Me.grdArqueosActivar = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbArqueoRecuperacion = New System.Windows.Forms.ToolStrip
        Me.ToolDesActivarArqueo = New System.Windows.Forms.ToolStripButton
        Me.ToolActivarArqueo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.GrpEncabezado.SuspendLayout()
        CType(Me.tabArqueo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabArqueo.SuspendLayout()
        Me.TabTotalesCajeros.SuspendLayout()
        CType(Me.GrdTotalesCajeros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMarcadosError.SuspendLayout()
        Me.tbMarcadosError.SuspendLayout()
        CType(Me.grdAnuladosConfirmar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabConflictosCentral.SuspendLayout()
        Me.tbArqueoDocumentos.SuspendLayout()
        CType(Me.grdConflictos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabArqueosRecuperacion.SuspendLayout()
        CType(Me.grdArqueosActivar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbArqueoRecuperacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpEncabezado
        '
        Me.GrpEncabezado.Controls.Add(Me.txtEnvioNo)
        Me.GrpEncabezado.Controls.Add(Me.Label2)
        Me.GrpEncabezado.Controls.Add(Me.txtNombreCaja)
        Me.GrpEncabezado.Controls.Add(Me.txtSteCajaId)
        Me.GrpEncabezado.Controls.Add(Me.Label1)
        Me.GrpEncabezado.Location = New System.Drawing.Point(12, 12)
        Me.GrpEncabezado.Name = "GrpEncabezado"
        Me.GrpEncabezado.Size = New System.Drawing.Size(822, 54)
        Me.GrpEncabezado.TabIndex = 0
        Me.GrpEncabezado.TabStop = False
        Me.GrpEncabezado.Text = "Datos de la Carga de Recibos a Central"
        '
        'txtEnvioNo
        '
        Me.txtEnvioNo.BackColor = System.Drawing.SystemColors.Info
        Me.txtEnvioNo.Enabled = False
        Me.txtEnvioNo.Location = New System.Drawing.Point(704, 22)
        Me.txtEnvioNo.Name = "txtEnvioNo"
        Me.txtEnvioNo.Size = New System.Drawing.Size(55, 20)
        Me.txtEnvioNo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(631, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Envio No:"
        '
        'txtNombreCaja
        '
        Me.txtNombreCaja.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreCaja.Enabled = False
        Me.txtNombreCaja.Location = New System.Drawing.Point(104, 22)
        Me.txtNombreCaja.Name = "txtNombreCaja"
        Me.txtNombreCaja.Size = New System.Drawing.Size(521, 20)
        Me.txtNombreCaja.TabIndex = 2
        '
        'txtSteCajaId
        '
        Me.txtSteCajaId.BackColor = System.Drawing.SystemColors.Info
        Me.txtSteCajaId.Enabled = False
        Me.txtSteCajaId.Location = New System.Drawing.Point(43, 22)
        Me.txtSteCajaId.Name = "txtSteCajaId"
        Me.txtSteCajaId.Size = New System.Drawing.Size(55, 20)
        Me.txtSteCajaId.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Caja:"
        '
        'tabArqueo
        '
        Me.tabArqueo.BackColor = System.Drawing.SystemColors.Control
        Me.tabArqueo.Controls.Add(Me.TabTotalesCajeros)
        Me.tabArqueo.Controls.Add(Me.tabMarcadosError)
        Me.tabArqueo.Controls.Add(Me.tabConflictosCentral)
        Me.tabArqueo.Controls.Add(Me.tabArqueosRecuperacion)
        Me.tabArqueo.Location = New System.Drawing.Point(21, 72)
        Me.tabArqueo.Name = "tabArqueo"
        Me.tabArqueo.SelectedIndex = 3
        Me.tabArqueo.Size = New System.Drawing.Size(813, 456)
        Me.tabArqueo.TabIndex = 1
        '
        'TabTotalesCajeros
        '
        Me.TabTotalesCajeros.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.TabTotalesCajeros.Controls.Add(Me.GrdTotalesCajeros)
        Me.TabTotalesCajeros.Image = Global.SMUSURA0.My.Resources.Resources.DatosGrales16
        Me.TabTotalesCajeros.Location = New System.Drawing.Point(1, 27)
        Me.TabTotalesCajeros.Name = "TabTotalesCajeros"
        Me.TabTotalesCajeros.Size = New System.Drawing.Size(811, 428)
        Me.TabTotalesCajeros.TabIndex = 0
        Me.TabTotalesCajeros.Text = "Totales por Cajero"
        '
        'GrdTotalesCajeros
        '
        Me.GrdTotalesCajeros.AllowFilter = False
        Me.GrdTotalesCajeros.AllowUpdate = False
        Me.GrdTotalesCajeros.Caption = "Totales por cajeros"
        Me.GrdTotalesCajeros.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.GrdTotalesCajeros.FilterBar = True
        Me.GrdTotalesCajeros.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.GrdTotalesCajeros.Images.Add(CType(resources.GetObject("GrdTotalesCajeros.Images"), System.Drawing.Image))
        Me.GrdTotalesCajeros.Location = New System.Drawing.Point(21, 37)
        Me.GrdTotalesCajeros.Name = "GrdTotalesCajeros"
        Me.GrdTotalesCajeros.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.GrdTotalesCajeros.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.GrdTotalesCajeros.PreviewInfo.ZoomFactor = 75
        Me.GrdTotalesCajeros.PrintInfo.PageSettings = CType(resources.GetObject("GrdTotalesCajeros.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.GrdTotalesCajeros.Size = New System.Drawing.Size(774, 368)
        Me.GrdTotalesCajeros.TabIndex = 24
        Me.GrdTotalesCajeros.Text = "Marcados como error Localmente"
        Me.GrdTotalesCajeros.PropBag = resources.GetString("GrdTotalesCajeros.PropBag")
        '
        'tabMarcadosError
        '
        Me.tabMarcadosError.Controls.Add(Me.tbMarcadosError)
        Me.tabMarcadosError.Controls.Add(Me.grdAnuladosConfirmar)
        Me.tabMarcadosError.Image = Global.SMUSURA0.My.Resources.Resources.bundle_016
        Me.tabMarcadosError.Location = New System.Drawing.Point(1, 27)
        Me.tabMarcadosError.Name = "tabMarcadosError"
        Me.tabMarcadosError.Size = New System.Drawing.Size(811, 428)
        Me.tabMarcadosError.TabIndex = 2
        Me.tabMarcadosError.Text = "Marcados como error Localmente"
        '
        'tbMarcadosError
        '
        Me.tbMarcadosError.AutoSize = False
        Me.tbMarcadosError.Dock = System.Windows.Forms.DockStyle.None
        Me.tbMarcadosError.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolModificarQ, Me.toolModificarC, Me.ToolStripSeparator2, Me.toolRefrescarE, Me.ToolStripSeparator3, Me.toolAyudaE})
        Me.tbMarcadosError.Location = New System.Drawing.Point(3, 0)
        Me.tbMarcadosError.Name = "tbMarcadosError"
        Me.tbMarcadosError.Size = New System.Drawing.Size(791, 34)
        Me.tbMarcadosError.Stretch = True
        Me.tbMarcadosError.TabIndex = 25
        Me.tbMarcadosError.Text = "ToolStrip1"
        '
        'toolModificarQ
        '
        Me.toolModificarQ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarQ.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolModificarQ.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarQ.Name = "toolModificarQ"
        Me.toolModificarQ.Size = New System.Drawing.Size(23, 31)
        Me.toolModificarQ.Text = "ToolStripButton1"
        Me.toolModificarQ.ToolTipText = "Volver a poner en Marcado como Error"
        '
        'toolModificarC
        '
        Me.toolModificarC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarC.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
        Me.toolModificarC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarC.Name = "toolModificarC"
        Me.toolModificarC.Size = New System.Drawing.Size(23, 31)
        Me.toolModificarC.Text = "Modificar Cantidad Denominación"
        Me.toolModificarC.ToolTipText = "Aceptar como Anulado el Marcado como Error"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 34)
        '
        'toolRefrescarE
        '
        Me.toolRefrescarE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarE.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarE.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarE.Name = "toolRefrescarE"
        Me.toolRefrescarE.Size = New System.Drawing.Size(23, 31)
        Me.toolRefrescarE.Text = "Refrescar"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 34)
        '
        'toolAyudaE
        '
        Me.toolAyudaE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaE.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaE.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaE.Name = "toolAyudaE"
        Me.toolAyudaE.Size = New System.Drawing.Size(23, 31)
        Me.toolAyudaE.Text = "Ayuda"
        Me.toolAyudaE.ToolTipText = "Ayuda"
        '
        'grdAnuladosConfirmar
        '
        Me.grdAnuladosConfirmar.AllowFilter = False
        Me.grdAnuladosConfirmar.AllowUpdate = False
        Me.grdAnuladosConfirmar.Caption = "En proceso de Anulación"
        Me.grdAnuladosConfirmar.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdAnuladosConfirmar.FilterBar = True
        Me.grdAnuladosConfirmar.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdAnuladosConfirmar.Images.Add(CType(resources.GetObject("grdAnuladosConfirmar.Images"), System.Drawing.Image))
        Me.grdAnuladosConfirmar.Location = New System.Drawing.Point(3, 37)
        Me.grdAnuladosConfirmar.Name = "grdAnuladosConfirmar"
        Me.grdAnuladosConfirmar.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAnuladosConfirmar.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAnuladosConfirmar.PreviewInfo.ZoomFactor = 75
        Me.grdAnuladosConfirmar.PrintInfo.PageSettings = CType(resources.GetObject("grdAnuladosConfirmar.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAnuladosConfirmar.Size = New System.Drawing.Size(770, 358)
        Me.grdAnuladosConfirmar.TabIndex = 23
        Me.grdAnuladosConfirmar.Text = "Marcados como error Localmente"
        Me.grdAnuladosConfirmar.PropBag = resources.GetString("grdAnuladosConfirmar.PropBag")
        '
        'tabConflictosCentral
        '
        Me.tabConflictosCentral.Controls.Add(Me.tbArqueoDocumentos)
        Me.tabConflictosCentral.Controls.Add(Me.lblSinDisponibilidad)
        Me.tabConflictosCentral.Controls.Add(Me.grdConflictos)
        Me.tabConflictosCentral.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.tabConflictosCentral.Location = New System.Drawing.Point(1, 27)
        Me.tabConflictosCentral.Name = "tabConflictosCentral"
        Me.tabConflictosCentral.Size = New System.Drawing.Size(811, 428)
        Me.tabConflictosCentral.TabIndex = 1
        Me.tabConflictosCentral.Text = "Socias Conflictos en Central y en Local"
        '
        'tbArqueoDocumentos
        '
        Me.tbArqueoDocumentos.AutoSize = False
        Me.tbArqueoDocumentos.Dock = System.Windows.Forms.DockStyle.None
        Me.tbArqueoDocumentos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolIncorporarR, Me.toolAgregarR, Me.toolIncorporarRecibo, Me.toolModificarR, Me.toolEliminarR, Me.toolEliminarRS, Me.toolSeparador1, Me.toolAnularR, Me.toolRefrescarR, Me.toolSeparador2, Me.toolAyudaR})
        Me.tbArqueoDocumentos.Location = New System.Drawing.Point(21, 9)
        Me.tbArqueoDocumentos.Name = "tbArqueoDocumentos"
        Me.tbArqueoDocumentos.Size = New System.Drawing.Size(728, 25)
        Me.tbArqueoDocumentos.Stretch = True
        Me.tbArqueoDocumentos.TabIndex = 20
        Me.tbArqueoDocumentos.Text = "ToolStrip1"
        Me.tbArqueoDocumentos.Visible = False
        '
        'toolIncorporarR
        '
        Me.toolIncorporarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolIncorporarR.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolIncorporarR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolIncorporarR.Name = "toolIncorporarR"
        Me.toolIncorporarR.Size = New System.Drawing.Size(23, 22)
        Me.toolIncorporarR.Text = "Ingreso Automático de Recibos"
        Me.toolIncorporarR.ToolTipText = "Ingreso Automático de Recibos "
        '
        'toolAgregarR
        '
        Me.toolAgregarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregarR.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.toolAgregarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregarR.Name = "toolAgregarR"
        Me.toolAgregarR.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregarR.Text = "Agregar Recibo(s)"
        Me.toolAgregarR.ToolTipText = "Agregar Recibo(s)"
        '
        'toolIncorporarRecibo
        '
        Me.toolIncorporarRecibo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolIncorporarRecibo.Image = Global.SMUSURA0.My.Resources.Resources.AgregarPartidaPresup
        Me.toolIncorporarRecibo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolIncorporarRecibo.Name = "toolIncorporarRecibo"
        Me.toolIncorporarRecibo.Size = New System.Drawing.Size(23, 22)
        Me.toolIncorporarRecibo.Text = "Incorporar recibo único"
        '
        'toolModificarR
        '
        Me.toolModificarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificarR.Image = Global.SMUSURA0.My.Resources.Resources.Edit16
        Me.toolModificarR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificarR.Name = "toolModificarR"
        Me.toolModificarR.Size = New System.Drawing.Size(23, 22)
        Me.toolModificarR.Text = "Modificar Recibo(s)"
        Me.toolModificarR.ToolTipText = "Modificar Recibo(s)"
        '
        'toolEliminarR
        '
        Me.toolEliminarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarR.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.toolEliminarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminarR.Name = "toolEliminarR"
        Me.toolEliminarR.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarR.Text = "Eliminar Recibo"
        '
        'toolEliminarRS
        '
        Me.toolEliminarRS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminarRS.Image = Global.SMUSURA0.My.Resources.Resources.Rechazado16
        Me.toolEliminarRS.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolEliminarRS.Name = "toolEliminarRS"
        Me.toolEliminarRS.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminarRS.Text = "Eliminar Recibos de un Rango"
        Me.toolEliminarRS.ToolTipText = "Eliminar Recibos de un Rango"
        '
        'toolSeparador1
        '
        Me.toolSeparador1.Name = "toolSeparador1"
        Me.toolSeparador1.Size = New System.Drawing.Size(6, 25)
        '
        'toolAnularR
        '
        Me.toolAnularR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAnularR.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.toolAnularR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAnularR.Name = "toolAnularR"
        Me.toolAnularR.Size = New System.Drawing.Size(23, 22)
        Me.toolAnularR.Text = "Anular un Recibo"
        '
        'toolRefrescarR
        '
        Me.toolRefrescarR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarR.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarR.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescarR.Name = "toolRefrescarR"
        Me.toolRefrescarR.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarR.Text = "Refrescar"
        '
        'toolSeparador2
        '
        Me.toolSeparador2.Name = "toolSeparador2"
        Me.toolSeparador2.Size = New System.Drawing.Size(6, 25)
        '
        'toolAyudaR
        '
        Me.toolAyudaR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyudaR.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyudaR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyudaR.Name = "toolAyudaR"
        Me.toolAyudaR.Size = New System.Drawing.Size(23, 22)
        Me.toolAyudaR.Text = "Ayuda"
        Me.toolAyudaR.ToolTipText = "Ayuda"
        '
        'lblSinDisponibilidad
        '
        Me.lblSinDisponibilidad.AutoSize = True
        Me.lblSinDisponibilidad.Location = New System.Drawing.Point(18, 452)
        Me.lblSinDisponibilidad.Name = "lblSinDisponibilidad"
        Me.lblSinDisponibilidad.Size = New System.Drawing.Size(0, 13)
        Me.lblSinDisponibilidad.TabIndex = 19
        '
        'grdConflictos
        '
        Me.grdConflictos.AllowFilter = False
        Me.grdConflictos.AllowUpdate = False
        Me.grdConflictos.Caption = "Arqueo de Documentos"
        Me.grdConflictos.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdConflictos.FilterBar = True
        Me.grdConflictos.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdConflictos.Images.Add(CType(resources.GetObject("grdConflictos.Images"), System.Drawing.Image))
        Me.grdConflictos.Location = New System.Drawing.Point(21, 37)
        Me.grdConflictos.Name = "grdConflictos"
        Me.grdConflictos.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdConflictos.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdConflictos.PreviewInfo.ZoomFactor = 75
        Me.grdConflictos.PrintInfo.PageSettings = CType(resources.GetObject("grdConflictos.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdConflictos.Size = New System.Drawing.Size(777, 372)
        Me.grdConflictos.TabIndex = 16
        Me.grdConflictos.Text = "grdArqueoDocumentos"
        Me.grdConflictos.PropBag = resources.GetString("grdConflictos.PropBag")
        '
        'tabArqueosRecuperacion
        '
        Me.tabArqueosRecuperacion.Controls.Add(Me.grdArqueosActivar)
        Me.tabArqueosRecuperacion.Controls.Add(Me.tbArqueoRecuperacion)
        Me.tabArqueosRecuperacion.Location = New System.Drawing.Point(1, 27)
        Me.tabArqueosRecuperacion.Name = "tabArqueosRecuperacion"
        Me.tabArqueosRecuperacion.Size = New System.Drawing.Size(811, 428)
        Me.tabArqueosRecuperacion.TabIndex = 3
        Me.tabArqueosRecuperacion.Text = "Fechas Arqueos por Recuperación"
        '
        'grdArqueosActivar
        '
        Me.grdArqueosActivar.AllowFilter = False
        Me.grdArqueosActivar.AllowUpdate = False
        Me.grdArqueosActivar.Caption = "Obligar ingresar arqueos por recuperación"
        Me.grdArqueosActivar.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdArqueosActivar.FilterBar = True
        Me.grdArqueosActivar.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdArqueosActivar.Images.Add(CType(resources.GetObject("grdArqueosActivar.Images"), System.Drawing.Image))
        Me.grdArqueosActivar.Location = New System.Drawing.Point(10, 48)
        Me.grdArqueosActivar.Name = "grdArqueosActivar"
        Me.grdArqueosActivar.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdArqueosActivar.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdArqueosActivar.PreviewInfo.ZoomFactor = 75
        Me.grdArqueosActivar.PrintInfo.PageSettings = CType(resources.GetObject("grdArqueosActivar.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdArqueosActivar.Size = New System.Drawing.Size(770, 358)
        Me.grdArqueosActivar.TabIndex = 27
        Me.grdArqueosActivar.Text = "Marcados como error Localmente"
        Me.grdArqueosActivar.PropBag = resources.GetString("grdArqueosActivar.PropBag")
        '
        'tbArqueoRecuperacion
        '
        Me.tbArqueoRecuperacion.AutoSize = False
        Me.tbArqueoRecuperacion.Dock = System.Windows.Forms.DockStyle.None
        Me.tbArqueoRecuperacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolDesActivarArqueo, Me.ToolActivarArqueo, Me.ToolStripSeparator1, Me.ToolStripButton3, Me.ToolStripSeparator4, Me.ToolStripButton4})
        Me.tbArqueoRecuperacion.Location = New System.Drawing.Point(10, 0)
        Me.tbArqueoRecuperacion.Name = "tbArqueoRecuperacion"
        Me.tbArqueoRecuperacion.Size = New System.Drawing.Size(791, 34)
        Me.tbArqueoRecuperacion.Stretch = True
        Me.tbArqueoRecuperacion.TabIndex = 26
        Me.tbArqueoRecuperacion.Text = "ToolStrip1"
        '
        'ToolDesActivarArqueo
        '
        Me.ToolDesActivarArqueo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolDesActivarArqueo.Image = Global.SMUSURA0.My.Resources.Resources.Eliminar16
        Me.ToolDesActivarArqueo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolDesActivarArqueo.Name = "ToolDesActivarArqueo"
        Me.ToolDesActivarArqueo.Size = New System.Drawing.Size(23, 31)
        Me.ToolDesActivarArqueo.Text = "ToolStripButton1"
        Me.ToolDesActivarArqueo.ToolTipText = "No Obligar Arqueo por recuperación"
        '
        'ToolActivarArqueo
        '
        Me.ToolActivarArqueo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolActivarArqueo.Image = Global.SMUSURA0.My.Resources.Resources.Confirmacion16v2
        Me.ToolActivarArqueo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolActivarArqueo.Name = "ToolActivarArqueo"
        Me.ToolActivarArqueo.Size = New System.Drawing.Size(23, 31)
        Me.ToolActivarArqueo.Text = "Modificar Cantidad Denominación"
        Me.ToolActivarArqueo.ToolTipText = "Obligar Arqueo por recuperación"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 31)
        Me.ToolStripButton3.Text = "Refrescar"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 34)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 31)
        Me.ToolStripButton4.Text = "Ayuda"
        Me.ToolStripButton4.ToolTipText = "Ayuda"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(116, 582)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 26
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(15, 582)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 25
        Me.CmdAceptar.Text = "Aplicar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'FrmSccCargaAplicar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 758)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.tabArqueo)
        Me.Controls.Add(Me.GrpEncabezado)
        Me.Name = "FrmSccCargaAplicar"
        Me.Text = "Proceso de Aplicar Carga de Recibos"
        Me.GrpEncabezado.ResumeLayout(False)
        Me.GrpEncabezado.PerformLayout()
        CType(Me.tabArqueo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabArqueo.ResumeLayout(False)
        Me.TabTotalesCajeros.ResumeLayout(False)
        CType(Me.GrdTotalesCajeros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMarcadosError.ResumeLayout(False)
        Me.tbMarcadosError.ResumeLayout(False)
        Me.tbMarcadosError.PerformLayout()
        CType(Me.grdAnuladosConfirmar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabConflictosCentral.ResumeLayout(False)
        Me.tabConflictosCentral.PerformLayout()
        Me.tbArqueoDocumentos.ResumeLayout(False)
        Me.tbArqueoDocumentos.PerformLayout()
        CType(Me.grdConflictos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabArqueosRecuperacion.ResumeLayout(False)
        CType(Me.grdArqueosActivar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbArqueoRecuperacion.ResumeLayout(False)
        Me.tbArqueoRecuperacion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpEncabezado As System.Windows.Forms.GroupBox
    Friend WithEvents txtNombreCaja As System.Windows.Forms.TextBox
    Friend WithEvents txtSteCajaId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtEnvioNo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabArqueo As C1.Win.C1Command.C1DockingTab
    Friend WithEvents TabTotalesCajeros As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tabMarcadosError As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grdAnuladosConfirmar As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tabConflictosCentral As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tbArqueoDocumentos As System.Windows.Forms.ToolStrip
    Friend WithEvents toolIncorporarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolAgregarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolIncorporarRecibo As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminarRS As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAnularR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescarR As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolSeparador2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaR As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSinDisponibilidad As System.Windows.Forms.Label
    Friend WithEvents grdConflictos As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GrdTotalesCajeros As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents tabArqueosRecuperacion As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents tbMarcadosError As System.Windows.Forms.ToolStrip
    Friend WithEvents toolModificarQ As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificarC As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescarE As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyudaE As System.Windows.Forms.ToolStripButton
    Friend WithEvents tbArqueoRecuperacion As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolDesActivarArqueo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolActivarArqueo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdArqueosActivar As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
