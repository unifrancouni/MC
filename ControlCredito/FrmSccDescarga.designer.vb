<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSccDescarga
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSccDescarga))
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.GrpBPrincipal = New System.Windows.Forms.GroupBox
        Me.grdCajas = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.CmbNoHanCerrado = New System.Windows.Forms.Button
        Me.CmbNoHanPagado = New System.Windows.Forms.Button
        Me.CmbListaEnOtrosMunicipios = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpGenera = New System.Windows.Forms.GroupBox
        Me.grpTipoBase = New System.Windows.Forms.GroupBox
        Me.RadCentral = New System.Windows.Forms.RadioButton
        Me.RadLocal = New System.Windows.Forms.RadioButton
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ChkFaltanArqueosRecuperacion = New System.Windows.Forms.CheckBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ChkSociasnoAutorizadas = New System.Windows.Forms.CheckBox
        Me.cmbRevisar = New System.Windows.Forms.Button
        Me.ChkRecibosEnArqueoNocredito = New System.Windows.Forms.CheckBox
        Me.ChkRecibosEnProceso = New System.Windows.Forms.CheckBox
        Me.ChkSinUltimaCuota = New System.Windows.Forms.CheckBox
        Me.ChkEnOtroMunicipio = New System.Windows.Forms.CheckBox
        Me.ChkFaltanArqueos = New System.Windows.Forms.CheckBox
        Me.CmbRefrescarUnidar = New System.Windows.Forms.Button
        Me.lblFecha = New System.Windows.Forms.Label
        Me.cboCaja = New C1.Win.C1List.C1Combo
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblRepresentante = New System.Windows.Forms.Label
        Me.cboUnidad = New System.Windows.Forms.ComboBox
        Me.cmbProcesar = New System.Windows.Forms.Button
        Me.cdeFechaGenera = New C1.Win.C1Input.C1DateEdit
        Me.grpPresentaProceso = New System.Windows.Forms.GroupBox
        Me.PrBarProceso = New System.Windows.Forms.ProgressBar
        Me.LblArchivo = New System.Windows.Forms.Label
        Me.LblConteo = New System.Windows.Forms.Label
        Me.gridGenerados = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbReiniciarContador = New System.Windows.Forms.Button
        Me.GrpReiniciar = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbCancelarReinicio = New System.Windows.Forms.Button
        Me.TxtMotivoReinicio = New System.Windows.Forms.TextBox
        Me.CmbAplicarReinico = New System.Windows.Forms.Button
        Me.GrpBPrincipal.SuspendLayout()
        CType(Me.grdCajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpGenera.SuspendLayout()
        Me.grpTipoBase.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaGenera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPresentaProceso.SuspendLayout()
        CType(Me.gridGenerados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GrpReiniciar.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpBPrincipal
        '
        Me.GrpBPrincipal.Controls.Add(Me.grdCajas)
        Me.GrpBPrincipal.Controls.Add(Me.CmbNoHanCerrado)
        Me.GrpBPrincipal.Controls.Add(Me.CmbNoHanPagado)
        Me.GrpBPrincipal.Controls.Add(Me.CmbListaEnOtrosMunicipios)
        Me.GrpBPrincipal.Controls.Add(Me.cmdCancelar)
        Me.GrpBPrincipal.Controls.Add(Me.grpGenera)
        Me.GrpBPrincipal.Controls.Add(Me.grpPresentaProceso)
        Me.GrpBPrincipal.Controls.Add(Me.gridGenerados)
        Me.GrpBPrincipal.Location = New System.Drawing.Point(4, 63)
        Me.GrpBPrincipal.Name = "GrpBPrincipal"
        Me.GrpBPrincipal.Size = New System.Drawing.Size(719, 665)
        Me.GrpBPrincipal.TabIndex = 0
        Me.GrpBPrincipal.TabStop = False
        '
        'grdCajas
        '
        Me.grdCajas.AllowFilter = False
        Me.grdCajas.AllowUpdate = False
        Me.grdCajas.Caption = "Cajeros asignados a la caja"
        Me.grdCajas.FilterBar = True
        Me.grdCajas.GroupByCaption = ""
        Me.grdCajas.Images.Add(CType(resources.GetObject("grdCajas.Images"), System.Drawing.Image))
        Me.grdCajas.Location = New System.Drawing.Point(9, 503)
        Me.grdCajas.Name = "grdCajas"
        Me.grdCajas.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdCajas.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdCajas.PreviewInfo.ZoomFactor = 75
        Me.grdCajas.PrintInfo.PageSettings = CType(resources.GetObject("grdCajas.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdCajas.Size = New System.Drawing.Size(704, 118)
        Me.grdCajas.TabIndex = 123
        Me.grdCajas.Text = "grdCajas"
        Me.grdCajas.PropBag = resources.GetString("grdCajas.PropBag")
        '
        'CmbNoHanCerrado
        '
        Me.CmbNoHanCerrado.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.CmbNoHanCerrado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbNoHanCerrado.Location = New System.Drawing.Point(438, 627)
        Me.CmbNoHanCerrado.Name = "CmbNoHanCerrado"
        Me.CmbNoHanCerrado.Size = New System.Drawing.Size(172, 38)
        Me.CmbNoHanCerrado.TabIndex = 122
        Me.CmbNoHanCerrado.Text = "TT3 Socias con recibos que no han sido dado por cerrados"
        Me.CmbNoHanCerrado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbNoHanCerrado.UseVisualStyleBackColor = True
        '
        'CmbNoHanPagado
        '
        Me.CmbNoHanPagado.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.CmbNoHanPagado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbNoHanPagado.Location = New System.Drawing.Point(208, 627)
        Me.CmbNoHanPagado.Name = "CmbNoHanPagado"
        Me.CmbNoHanPagado.Size = New System.Drawing.Size(204, 38)
        Me.CmbNoHanPagado.TabIndex = 121
        Me.CmbNoHanPagado.Text = "TT2 Socias Que no han pagado a la ultima cuota correspondiente"
        Me.CmbNoHanPagado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbNoHanPagado.UseVisualStyleBackColor = True
        '
        'CmbListaEnOtrosMunicipios
        '
        Me.CmbListaEnOtrosMunicipios.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.CmbListaEnOtrosMunicipios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbListaEnOtrosMunicipios.Location = New System.Drawing.Point(6, 627)
        Me.CmbListaEnOtrosMunicipios.Name = "CmbListaEnOtrosMunicipios"
        Me.CmbListaEnOtrosMunicipios.Size = New System.Drawing.Size(193, 38)
        Me.CmbListaEnOtrosMunicipios.TabIndex = 120
        Me.CmbListaEnOtrosMunicipios.Text = "TT1 Socias en Otros Municipios"
        Me.CmbListaEnOtrosMunicipios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbListaEnOtrosMunicipios.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(642, 634)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 25)
        Me.cmdCancelar.TabIndex = 59
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grpGenera
        '
        Me.grpGenera.Controls.Add(Me.CmbReiniciarContador)
        Me.grpGenera.Controls.Add(Me.grpTipoBase)
        Me.grpGenera.Controls.Add(Me.GroupBox2)
        Me.grpGenera.Controls.Add(Me.CmbRefrescarUnidar)
        Me.grpGenera.Controls.Add(Me.lblFecha)
        Me.grpGenera.Controls.Add(Me.cboCaja)
        Me.grpGenera.Controls.Add(Me.Label1)
        Me.grpGenera.Controls.Add(Me.lblRepresentante)
        Me.grpGenera.Controls.Add(Me.cboUnidad)
        Me.grpGenera.Controls.Add(Me.cmbProcesar)
        Me.grpGenera.Controls.Add(Me.cdeFechaGenera)
        Me.grpGenera.Location = New System.Drawing.Point(3, 6)
        Me.grpGenera.Name = "grpGenera"
        Me.grpGenera.Size = New System.Drawing.Size(710, 192)
        Me.grpGenera.TabIndex = 60
        Me.grpGenera.TabStop = False
        '
        'grpTipoBase
        '
        Me.grpTipoBase.Controls.Add(Me.RadCentral)
        Me.grpTipoBase.Controls.Add(Me.RadLocal)
        Me.grpTipoBase.Controls.Add(Me.Label2)
        Me.grpTipoBase.Enabled = False
        Me.grpTipoBase.Location = New System.Drawing.Point(523, 4)
        Me.grpTipoBase.Name = "grpTipoBase"
        Me.grpTipoBase.Size = New System.Drawing.Size(181, 51)
        Me.grpTipoBase.TabIndex = 62
        Me.grpTipoBase.TabStop = False
        '
        'RadCentral
        '
        Me.RadCentral.AutoSize = True
        Me.RadCentral.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCentral.Location = New System.Drawing.Point(6, 28)
        Me.RadCentral.Name = "RadCentral"
        Me.RadCentral.Size = New System.Drawing.Size(58, 17)
        Me.RadCentral.TabIndex = 125
        Me.RadCentral.TabStop = True
        Me.RadCentral.Text = "Central"
        Me.RadCentral.UseVisualStyleBackColor = True
        '
        'RadLocal
        '
        Me.RadLocal.AutoSize = True
        Me.RadLocal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadLocal.Location = New System.Drawing.Point(89, 31)
        Me.RadLocal.Name = "RadLocal"
        Me.RadLocal.Size = New System.Drawing.Size(51, 17)
        Me.RadLocal.TabIndex = 124
        Me.RadLocal.TabStop = True
        Me.RadLocal.Text = "Local"
        Me.RadLocal.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(53, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Base"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.ChkFaltanArqueosRecuperacion)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.ChkSociasnoAutorizadas)
        Me.GroupBox2.Controls.Add(Me.cmbRevisar)
        Me.GroupBox2.Controls.Add(Me.ChkRecibosEnArqueoNocredito)
        Me.GroupBox2.Controls.Add(Me.ChkRecibosEnProceso)
        Me.GroupBox2.Controls.Add(Me.ChkSinUltimaCuota)
        Me.GroupBox2.Controls.Add(Me.ChkEnOtroMunicipio)
        Me.GroupBox2.Controls.Add(Me.ChkFaltanArqueos)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Red
        Me.GroupBox2.Location = New System.Drawing.Point(6, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 88)
        Me.GroupBox2.TabIndex = 120
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PRECAUCIONES"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(254, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Faltan Arqueos por Recuperación"
        '
        'ChkFaltanArqueosRecuperacion
        '
        Me.ChkFaltanArqueosRecuperacion.AutoSize = True
        Me.ChkFaltanArqueosRecuperacion.Enabled = False
        Me.ChkFaltanArqueosRecuperacion.Location = New System.Drawing.Point(235, 20)
        Me.ChkFaltanArqueosRecuperacion.Name = "ChkFaltanArqueosRecuperacion"
        Me.ChkFaltanArqueosRecuperacion.Size = New System.Drawing.Size(15, 14)
        Me.ChkFaltanArqueosRecuperacion.TabIndex = 53
        Me.ChkFaltanArqueosRecuperacion.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(478, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(220, 13)
        Me.Label11.TabIndex = 52
        Me.Label11.Text = "En Arqueos No En Credito Rev. TE27"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(37, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(92, 13)
        Me.Label10.TabIndex = 51
        Me.Label10.Text = "Faltan Arqueos"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Teal
        Me.Label9.Location = New System.Drawing.Point(37, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(286, 13)
        Me.Label9.TabIndex = 50
        Me.Label9.Text = "Recibos en Procesos.  Sin Cierre en Contabilidad"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Olive
        Me.Label8.Location = New System.Drawing.Point(478, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 13)
        Me.Label8.TabIndex = 49
        Me.Label8.Text = "Sin última cuota "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Olive
        Me.Label7.Location = New System.Drawing.Point(256, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(173, 13)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "En Cajas de Otros Municipios"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Olive
        Me.Label6.Location = New System.Drawing.Point(37, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(196, 13)
        Me.Label6.TabIndex = 47
        Me.Label6.Text = "Socias Revisadas no Autorizadas"
        '
        'ChkSociasnoAutorizadas
        '
        Me.ChkSociasnoAutorizadas.AutoSize = True
        Me.ChkSociasnoAutorizadas.Enabled = False
        Me.ChkSociasnoAutorizadas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSociasnoAutorizadas.ForeColor = System.Drawing.Color.Olive
        Me.ChkSociasnoAutorizadas.Location = New System.Drawing.Point(14, 45)
        Me.ChkSociasnoAutorizadas.Name = "ChkSociasnoAutorizadas"
        Me.ChkSociasnoAutorizadas.Size = New System.Drawing.Size(15, 14)
        Me.ChkSociasnoAutorizadas.TabIndex = 44
        Me.ChkSociasnoAutorizadas.UseVisualStyleBackColor = True
        '
        'cmbRevisar
        '
        Me.cmbRevisar.AllowDrop = True
        Me.cmbRevisar.ForeColor = System.Drawing.Color.Black
        Me.cmbRevisar.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.cmbRevisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmbRevisar.Location = New System.Drawing.Point(582, 44)
        Me.cmbRevisar.Name = "cmbRevisar"
        Me.cmbRevisar.Size = New System.Drawing.Size(110, 41)
        Me.cmbRevisar.TabIndex = 43
        Me.cmbRevisar.Text = "Revisar Condiciones"
        Me.cmbRevisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbRevisar.UseVisualStyleBackColor = True
        '
        'ChkRecibosEnArqueoNocredito
        '
        Me.ChkRecibosEnArqueoNocredito.AutoSize = True
        Me.ChkRecibosEnArqueoNocredito.Enabled = False
        Me.ChkRecibosEnArqueoNocredito.Location = New System.Drawing.Point(457, 20)
        Me.ChkRecibosEnArqueoNocredito.Name = "ChkRecibosEnArqueoNocredito"
        Me.ChkRecibosEnArqueoNocredito.Size = New System.Drawing.Size(15, 14)
        Me.ChkRecibosEnArqueoNocredito.TabIndex = 4
        Me.ChkRecibosEnArqueoNocredito.UseVisualStyleBackColor = True
        '
        'ChkRecibosEnProceso
        '
        Me.ChkRecibosEnProceso.AutoSize = True
        Me.ChkRecibosEnProceso.Enabled = False
        Me.ChkRecibosEnProceso.ForeColor = System.Drawing.Color.Teal
        Me.ChkRecibosEnProceso.Location = New System.Drawing.Point(14, 71)
        Me.ChkRecibosEnProceso.Name = "ChkRecibosEnProceso"
        Me.ChkRecibosEnProceso.Size = New System.Drawing.Size(15, 14)
        Me.ChkRecibosEnProceso.TabIndex = 3
        Me.ChkRecibosEnProceso.UseVisualStyleBackColor = True
        '
        'ChkSinUltimaCuota
        '
        Me.ChkSinUltimaCuota.AutoSize = True
        Me.ChkSinUltimaCuota.Enabled = False
        Me.ChkSinUltimaCuota.ForeColor = System.Drawing.Color.Olive
        Me.ChkSinUltimaCuota.Location = New System.Drawing.Point(457, 44)
        Me.ChkSinUltimaCuota.Name = "ChkSinUltimaCuota"
        Me.ChkSinUltimaCuota.Size = New System.Drawing.Size(15, 14)
        Me.ChkSinUltimaCuota.TabIndex = 2
        Me.ChkSinUltimaCuota.UseVisualStyleBackColor = True
        '
        'ChkEnOtroMunicipio
        '
        Me.ChkEnOtroMunicipio.AutoSize = True
        Me.ChkEnOtroMunicipio.Enabled = False
        Me.ChkEnOtroMunicipio.ForeColor = System.Drawing.Color.Olive
        Me.ChkEnOtroMunicipio.Location = New System.Drawing.Point(235, 45)
        Me.ChkEnOtroMunicipio.Name = "ChkEnOtroMunicipio"
        Me.ChkEnOtroMunicipio.Size = New System.Drawing.Size(15, 14)
        Me.ChkEnOtroMunicipio.TabIndex = 1
        Me.ChkEnOtroMunicipio.UseVisualStyleBackColor = True
        '
        'ChkFaltanArqueos
        '
        Me.ChkFaltanArqueos.AutoSize = True
        Me.ChkFaltanArqueos.Enabled = False
        Me.ChkFaltanArqueos.Location = New System.Drawing.Point(16, 19)
        Me.ChkFaltanArqueos.Name = "ChkFaltanArqueos"
        Me.ChkFaltanArqueos.Size = New System.Drawing.Size(15, 14)
        Me.ChkFaltanArqueos.TabIndex = 0
        Me.ChkFaltanArqueos.UseVisualStyleBackColor = True
        '
        'CmbRefrescarUnidar
        '
        Me.CmbRefrescarUnidar.Image = Global.SMUSURA0.My.Resources.Resources.folder_new
        Me.CmbRefrescarUnidar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbRefrescarUnidar.Location = New System.Drawing.Point(317, 69)
        Me.CmbRefrescarUnidar.Name = "CmbRefrescarUnidar"
        Me.CmbRefrescarUnidar.Size = New System.Drawing.Size(82, 25)
        Me.CmbRefrescarUnidar.TabIndex = 55
        Me.CmbRefrescarUnidar.Text = "Listar USB"
        Me.CmbRefrescarUnidar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbRefrescarUnidar.UseVisualStyleBackColor = True
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFecha.Location = New System.Drawing.Point(17, 20)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(95, 13)
        Me.lblFecha.TabIndex = 41
        Me.lblFecha.Text = "Fecha Generación"
        '
        'cboCaja
        '
        Me.cboCaja.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboCaja.AutoCompletion = True
        Me.cboCaja.Caption = ""
        Me.cboCaja.CaptionHeight = 17
        Me.cboCaja.CaptionStyle = Style33
        Me.cboCaja.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCaja.ColumnCaptionHeight = 17
        Me.cboCaja.ColumnFooterHeight = 17
        Me.cboCaja.ContentHeight = 15
        Me.cboCaja.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCaja.DisplayMember = "sDescripcionCaja"
        Me.cboCaja.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboCaja.DropDownWidth = 386
        Me.cboCaja.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCaja.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCaja.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCaja.EditorHeight = 15
        Me.cboCaja.EvenRowStyle = Style34
        Me.cboCaja.ExtendRightColumn = True
        Me.cboCaja.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboCaja.FooterStyle = Style35
        Me.cboCaja.GapHeight = 2
        Me.cboCaja.HeadingStyle = Style36
        Me.cboCaja.HighLightRowStyle = Style37
        Me.cboCaja.Images.Add(CType(resources.GetObject("cboCaja.Images"), System.Drawing.Image))
        Me.cboCaja.ItemHeight = 15
        Me.cboCaja.LimitToList = True
        Me.cboCaja.Location = New System.Drawing.Point(134, 42)
        Me.cboCaja.MatchEntryTimeout = CType(2000, Long)
        Me.cboCaja.MaxDropDownItems = CType(5, Short)
        Me.cboCaja.MaxLength = 32767
        Me.cboCaja.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCaja.Name = "cboCaja"
        Me.cboCaja.OddRowStyle = Style38
        Me.cboCaja.PartialRightColumn = False
        Me.cboCaja.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCaja.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCaja.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCaja.SelectedStyle = Style39
        Me.cboCaja.Size = New System.Drawing.Size(387, 21)
        Me.cboCaja.Style = Style40
        Me.cboCaja.SuperBack = True
        Me.cboCaja.TabIndex = 118
        Me.cboCaja.PropBag = resources.GetString("cboCaja.PropBag")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(17, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Unidad Destino"
        '
        'lblRepresentante
        '
        Me.lblRepresentante.AutoSize = True
        Me.lblRepresentante.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblRepresentante.Location = New System.Drawing.Point(17, 42)
        Me.lblRepresentante.Name = "lblRepresentante"
        Me.lblRepresentante.Size = New System.Drawing.Size(31, 13)
        Me.lblRepresentante.TabIndex = 119
        Me.lblRepresentante.Text = "Caja:"
        '
        'cboUnidad
        '
        Me.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cboUnidad.FormattingEnabled = True
        Me.cboUnidad.Location = New System.Drawing.Point(134, 66)
        Me.cboUnidad.Name = "cboUnidad"
        Me.cboUnidad.Size = New System.Drawing.Size(133, 21)
        Me.cboUnidad.TabIndex = 48
        '
        'cmbProcesar
        '
        Me.cmbProcesar.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.cmbProcesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmbProcesar.Location = New System.Drawing.Point(435, 69)
        Me.cmbProcesar.Name = "cmbProcesar"
        Me.cmbProcesar.Size = New System.Drawing.Size(82, 25)
        Me.cmbProcesar.TabIndex = 42
        Me.cmbProcesar.Text = "Generar"
        Me.cmbProcesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmbProcesar.UseVisualStyleBackColor = True
        '
        'cdeFechaGenera
        '
        Me.cdeFechaGenera.AcceptsEscape = False
        Me.cdeFechaGenera.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaGenera.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaGenera.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaGenera.Location = New System.Drawing.Point(134, 13)
        Me.cdeFechaGenera.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaGenera.MaskInfo.EmptyAsNull = True
        Me.cdeFechaGenera.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaGenera.Name = "cdeFechaGenera"
        Me.cdeFechaGenera.Size = New System.Drawing.Size(117, 20)
        Me.cdeFechaGenera.TabIndex = 40
        Me.cdeFechaGenera.Tag = Nothing
        Me.cdeFechaGenera.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'grpPresentaProceso
        '
        Me.grpPresentaProceso.Controls.Add(Me.PrBarProceso)
        Me.grpPresentaProceso.Controls.Add(Me.LblArchivo)
        Me.grpPresentaProceso.Controls.Add(Me.LblConteo)
        Me.grpPresentaProceso.Location = New System.Drawing.Point(3, 10)
        Me.grpPresentaProceso.Name = "grpPresentaProceso"
        Me.grpPresentaProceso.Size = New System.Drawing.Size(680, 128)
        Me.grpPresentaProceso.TabIndex = 61
        Me.grpPresentaProceso.TabStop = False
        '
        'PrBarProceso
        '
        Me.PrBarProceso.Location = New System.Drawing.Point(20, 78)
        Me.PrBarProceso.Name = "PrBarProceso"
        Me.PrBarProceso.Size = New System.Drawing.Size(621, 20)
        Me.PrBarProceso.TabIndex = 56
        '
        'LblArchivo
        '
        Me.LblArchivo.AutoSize = True
        Me.LblArchivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblArchivo.Location = New System.Drawing.Point(17, 62)
        Me.LblArchivo.Name = "LblArchivo"
        Me.LblArchivo.Size = New System.Drawing.Size(156, 13)
        Me.LblArchivo.TabIndex = 43
        Me.LblArchivo.Text = "Procesando Archivo _____.Xml"
        '
        'LblConteo
        '
        Me.LblConteo.AutoSize = True
        Me.LblConteo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblConteo.Location = New System.Drawing.Point(17, 32)
        Me.LblConteo.Name = "LblConteo"
        Me.LblConteo.Size = New System.Drawing.Size(156, 13)
        Me.LblConteo.TabIndex = 42
        Me.LblConteo.Text = "__ De ___ Archivos Generados"
        '
        'gridGenerados
        '
        Me.gridGenerados.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.gridGenerados.AllowFilter = False
        Me.gridGenerados.AllowSort = False
        Me.gridGenerados.AllowUpdate = False
        Me.gridGenerados.Caption = "Cargas Generadas/Guardadas"
        Me.gridGenerados.GroupByAreaVisible = False
        Me.gridGenerados.GroupByCaption = "z"
        Me.gridGenerados.Images.Add(CType(resources.GetObject("gridGenerados.Images"), System.Drawing.Image))
        Me.gridGenerados.Location = New System.Drawing.Point(8, 193)
        Me.gridGenerados.Name = "gridGenerados"
        Me.gridGenerados.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.gridGenerados.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.gridGenerados.PreviewInfo.ZoomFactor = 75
        Me.gridGenerados.PrintInfo.PageSettings = CType(resources.GetObject("gridGenerados.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.gridGenerados.Size = New System.Drawing.Size(707, 309)
        Me.gridGenerados.TabIndex = 58
        Me.gridGenerados.PropBag = resources.GetString("gridGenerados.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(693, 78)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "RECORDATORIO"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Red
        Me.TextBox1.Location = New System.Drawing.Point(8, 16)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(679, 56)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 0
        '
        'CmbReiniciarContador
        '
        Me.CmbReiniciarContador.Enabled = False
        Me.CmbReiniciarContador.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.CmbReiniciarContador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbReiniciarContador.Location = New System.Drawing.Point(543, 66)
        Me.CmbReiniciarContador.Name = "CmbReiniciarContador"
        Me.CmbReiniciarContador.Size = New System.Drawing.Size(161, 29)
        Me.CmbReiniciarContador.TabIndex = 132
        Me.CmbReiniciarContador.Text = "Liberar Fichas de Enllavado"
        Me.CmbReiniciarContador.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmbReiniciarContador.UseVisualStyleBackColor = True
        '
        'GrpReiniciar
        '
        Me.GrpReiniciar.Controls.Add(Me.GroupBox3)
        Me.GrpReiniciar.Controls.Add(Me.Label12)
        Me.GrpReiniciar.Controls.Add(Me.CmbCancelarReinicio)
        Me.GrpReiniciar.Controls.Add(Me.TxtMotivoReinicio)
        Me.GrpReiniciar.Controls.Add(Me.CmbAplicarReinico)
        Me.GrpReiniciar.Location = New System.Drawing.Point(65, 241)
        Me.GrpReiniciar.Name = "GrpReiniciar"
        Me.GrpReiniciar.Size = New System.Drawing.Size(623, 247)
        Me.GrpReiniciar.TabIndex = 132
        Me.GrpReiniciar.TabStop = False
        Me.GrpReiniciar.Text = "Reiniciar Contador"
        Me.GrpReiniciar.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(611, 78)
        Me.GroupBox3.TabIndex = 130
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "RECORDATORIO"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Red
        Me.TextBox2.Location = New System.Drawing.Point(8, 16)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(587, 56)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(12, 100)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 13)
        Me.Label12.TabIndex = 129
        Me.Label12.Text = "Descripción del Motivo:"
        '
        'CmbCancelarReinicio
        '
        Me.CmbCancelarReinicio.Image = CType(resources.GetObject("CmbCancelarReinicio.Image"), System.Drawing.Image)
        Me.CmbCancelarReinicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbCancelarReinicio.Location = New System.Drawing.Point(12, 209)
        Me.CmbCancelarReinicio.Name = "CmbCancelarReinicio"
        Me.CmbCancelarReinicio.Size = New System.Drawing.Size(138, 32)
        Me.CmbCancelarReinicio.TabIndex = 128
        Me.CmbCancelarReinicio.Text = "Cancelar Liberacion"
        Me.CmbCancelarReinicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbCancelarReinicio.UseVisualStyleBackColor = True
        '
        'TxtMotivoReinicio
        '
        Me.TxtMotivoReinicio.Location = New System.Drawing.Point(15, 120)
        Me.TxtMotivoReinicio.MaxLength = 250
        Me.TxtMotivoReinicio.Multiline = True
        Me.TxtMotivoReinicio.Name = "TxtMotivoReinicio"
        Me.TxtMotivoReinicio.Size = New System.Drawing.Size(589, 83)
        Me.TxtMotivoReinicio.TabIndex = 0
        '
        'CmbAplicarReinico
        '
        Me.CmbAplicarReinico.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.CmbAplicarReinico.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmbAplicarReinico.Location = New System.Drawing.Point(478, 209)
        Me.CmbAplicarReinico.Name = "CmbAplicarReinico"
        Me.CmbAplicarReinico.Size = New System.Drawing.Size(123, 32)
        Me.CmbAplicarReinico.TabIndex = 127
        Me.CmbAplicarReinico.Tag = ""
        Me.CmbAplicarReinico.Text = "Aplicar Liberacion"
        Me.CmbAplicarReinico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmbAplicarReinico.UseVisualStyleBackColor = True
        '
        'FrmSccDescarga
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 729)
        Me.Controls.Add(Me.GrpReiniciar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpBPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSccDescarga"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Descarga de la Base de Datos"
        Me.GrpBPrincipal.ResumeLayout(False)
        CType(Me.grdCajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpGenera.ResumeLayout(False)
        Me.grpGenera.PerformLayout()
        Me.grpTipoBase.ResumeLayout(False)
        Me.grpTipoBase.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cboCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaGenera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPresentaProceso.ResumeLayout(False)
        Me.grpPresentaProceso.PerformLayout()
        CType(Me.gridGenerados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpReiniciar.ResumeLayout(False)
        Me.GrpReiniciar.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpBPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents CmbRefrescarUnidar As System.Windows.Forms.Button
    Friend WithEvents PrBarProceso As System.Windows.Forms.ProgressBar
    Friend WithEvents LblArchivo As System.Windows.Forms.Label
    Friend WithEvents LblConteo As System.Windows.Forms.Label
    Friend WithEvents cboCaja As C1.Win.C1List.C1Combo
    Friend WithEvents lblRepresentante As System.Windows.Forms.Label
    Friend WithEvents cmbProcesar As System.Windows.Forms.Button
    Friend WithEvents cdeFechaGenera As C1.Win.C1Input.C1DateEdit
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents cboUnidad As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridGenerados As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents RadCentral As System.Windows.Forms.RadioButton
    Friend WithEvents RadLocal As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grpGenera As System.Windows.Forms.GroupBox
    Friend WithEvents grpPresentaProceso As System.Windows.Forms.GroupBox
    Friend WithEvents grpTipoBase As System.Windows.Forms.GroupBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CmbListaEnOtrosMunicipios As System.Windows.Forms.Button
    Friend WithEvents CmbNoHanPagado As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ChkFaltanArqueos As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEnOtroMunicipio As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSinUltimaCuota As System.Windows.Forms.CheckBox
    Friend WithEvents ChkRecibosEnProceso As System.Windows.Forms.CheckBox
    Friend WithEvents CmbNoHanCerrado As System.Windows.Forms.Button
    Friend WithEvents ChkRecibosEnArqueoNocredito As System.Windows.Forms.CheckBox
    Friend WithEvents cmbRevisar As System.Windows.Forms.Button
    Friend WithEvents ChkSociasnoAutorizadas As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ChkFaltanArqueosRecuperacion As System.Windows.Forms.CheckBox
    Friend WithEvents grdCajas As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CmbReiniciarContador As System.Windows.Forms.Button
    Friend WithEvents GrpReiniciar As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbCancelarReinicio As System.Windows.Forms.Button
    Friend WithEvents TxtMotivoReinicio As System.Windows.Forms.TextBox
    Friend WithEvents CmbAplicarReinico As System.Windows.Forms.Button
End Class
