<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclSolicitudDesembolso
    Inherits DataDynamics.ActiveReports.ActiveReport3

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the ActiveReports Designer
    'Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclSolicitudDesembolso))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.SubReporteFCL = New DataDynamics.ActiveReports.SubReport
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.lblDatosSocia = New DataDynamics.ActiveReports.Label
        Me.lblNombreS = New DataDynamics.ActiveReports.Label
        Me.txtNombreS = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblCedula = New DataDynamics.ActiveReports.Label
        Me.lblDireccion = New DataDynamics.ActiveReports.Label
        Me.txtDirecion = New DataDynamics.ActiveReports.TextBox
        Me.txtCedula = New DataDynamics.ActiveReports.TextBox
        Me.lblDatosPrestamo = New DataDynamics.ActiveReports.Label
        Me.lblTelefono = New DataDynamics.ActiveReports.Label
        Me.txtTelefono = New DataDynamics.ActiveReports.TextBox
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.lblDepartamento = New DataDynamics.ActiveReports.Label
        Me.lblFechaS = New DataDynamics.ActiveReports.Label
        Me.lblNumero = New DataDynamics.ActiveReports.Label
        Me.txtFechaS = New DataDynamics.ActiveReports.TextBox
        Me.lblMunicipio = New DataDynamics.ActiveReports.Label
        Me.lblDistrito = New DataDynamics.ActiveReports.Label
        Me.lblBarrio = New DataDynamics.ActiveReports.Label
        Me.txtDepartamento = New DataDynamics.ActiveReports.TextBox
        Me.txtMunicipio = New DataDynamics.ActiveReports.TextBox
        Me.txtDistrito = New DataDynamics.ActiveReports.TextBox
        Me.txtBarrio = New DataDynamics.ActiveReports.TextBox
        Me.lblGrupo = New DataDynamics.ActiveReports.Label
        Me.txtGrupoS = New DataDynamics.ActiveReports.TextBox
        Me.lblCodigoGS = New DataDynamics.ActiveReports.Label
        Me.txtCodGS = New DataDynamics.ActiveReports.TextBox
        Me.lblNuevo = New DataDynamics.ActiveReports.Label
        Me.ChkNuevo = New DataDynamics.ActiveReports.CheckBox
        Me.ChkRepeticion = New DataDynamics.ActiveReports.CheckBox
        Me.lblRepeticion = New DataDynamics.ActiveReports.Label
        Me.lblNoPrestamo = New DataDynamics.ActiveReports.Label
        Me.txtNoPrestamo = New DataDynamics.ActiveReports.TextBox
        Me.Shape3 = New DataDynamics.ActiveReports.Shape
        Me.lblMonto = New DataDynamics.ActiveReports.Label
        Me.lblInstancia = New DataDynamics.ActiveReports.Label
        Me.lblPlazo = New DataDynamics.ActiveReports.Label
        Me.txtMontoA = New DataDynamics.ActiveReports.TextBox
        Me.txtInstancia = New DataDynamics.ActiveReports.TextBox
        Me.txtPlazo = New DataDynamics.ActiveReports.TextBox
        Me.lblTipoNegocio = New DataDynamics.ActiveReports.Label
        Me.txtTipoNegocio = New DataDynamics.ActiveReports.TextBox
        Me.lblFormaPago = New DataDynamics.ActiveReports.Label
        Me.lblValor = New DataDynamics.ActiveReports.Label
        Me.txtMontoD = New DataDynamics.ActiveReports.TextBox
        Me.lblSesion = New DataDynamics.ActiveReports.Label
        Me.lblFecha = New DataDynamics.ActiveReports.Label
        Me.txtFechaSesion = New DataDynamics.ActiveReports.TextBox
        Me.txtSesionNo = New DataDynamics.ActiveReports.TextBox
        Me.lblFechaF = New DataDynamics.ActiveReports.Label
        Me.lblFechaI = New DataDynamics.ActiveReports.Label
        Me.txtFechaF = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaI = New DataDynamics.ActiveReports.TextBox
        Me.lblMontoSem = New DataDynamics.ActiveReports.Label
        Me.txtMontoSem = New DataDynamics.ActiveReports.TextBox
        Me.lblInteres = New DataDynamics.ActiveReports.Label
        Me.txtMora = New DataDynamics.ActiveReports.TextBox
        Me.txtInteres = New DataDynamics.ActiveReports.TextBox
        Me.lblFechaD = New DataDynamics.ActiveReports.Label
        Me.txtFechaD = New DataDynamics.ActiveReports.TextBox
        Me.lblTC = New DataDynamics.ActiveReports.Label
        Me.txtTipoCambio = New DataDynamics.ActiveReports.TextBox
        Me.lblMora = New DataDynamics.ActiveReports.Label
        Me.lblNumeroSD = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.txtMontoDUS = New DataDynamics.ActiveReports.TextBox
        Me.txtTipoPlazo = New DataDynamics.ActiveReports.TextBox
        Me.lblAnulada = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape4 = New DataDynamics.ActiveReports.Shape
        Me.lblObservaciones = New DataDynamics.ActiveReports.Label
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.lblCargoA = New DataDynamics.ActiveReports.Label
        Me.lblFirmaA = New DataDynamics.ActiveReports.Label
        Me.lblElaborado = New DataDynamics.ActiveReports.Label
        Me.lblCargoB = New DataDynamics.ActiveReports.Label
        Me.lblFirmaB = New DataDynamics.ActiveReports.Label
        Me.lblAutorizado = New DataDynamics.ActiveReports.Label
        Me.picAutorizado = New DataDynamics.ActiveReports.Picture
        Me.picElaborado = New DataDynamics.ActiveReports.Picture
        Me.txtFormaPago = New DataDynamics.ActiveReports.TextBox
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDatosSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDirecion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDatosPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrupoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkRepeticion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRepeticion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInstancia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstancia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSesionNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoSem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoSem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumeroSD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoDUS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblElaborado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAutorizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAutorizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picElaborado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.Label1, Me.SubReporteFCL})
        Me.PageHeader1.Height = 1.125!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblTitulo
        '
        Me.lblTitulo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Border.RightColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Border.TopColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Height = 0.25!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.0!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; verti" & _
            "cal-align: middle; "
        Me.lblTitulo.Text = "SOLICITUD DE DESEMBOLSO DE CREDITO"
        Me.lblTitulo.Top = 0.875!
        Me.lblTitulo.Width = 7.4375!
        '
        'SubReporte
        '
        Me.SubReporte.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.Border.RightColor = System.Drawing.Color.Black
        Me.SubReporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.Border.TopColor = System.Drawing.Color.Black
        Me.SubReporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.CloseBorder = False
        Me.SubReporte.Height = 0.7!
        Me.SubReporte.Left = 0.0!
        Me.SubReporte.Name = "SubReporte"
        Me.SubReporte.Report = Nothing
        Me.SubReporte.ReportName = "SubReport1"
        Me.SubReporte.Top = 0.0625!
        Me.SubReporte.Width = 7.4375!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Height = 0.5!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 5.625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.Label1.Text = "CS11"
        Me.Label1.Top = 0.1875!
        Me.Label1.Width = 0.8125!
        '
        'SubReporteFCL
        '
        Me.SubReporteFCL.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReporteFCL.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteFCL.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReporteFCL.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteFCL.Border.RightColor = System.Drawing.Color.Black
        Me.SubReporteFCL.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteFCL.Border.TopColor = System.Drawing.Color.Black
        Me.SubReporteFCL.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteFCL.CloseBorder = False
        Me.SubReporteFCL.Height = 0.875!
        Me.SubReporteFCL.Left = 0.0!
        Me.SubReporteFCL.Name = "SubReporteFCL"
        Me.SubReporteFCL.Report = Nothing
        Me.SubReporteFCL.ReportName = "SubReport1"
        Me.SubReporteFCL.Top = 0.0!
        Me.SubReporteFCL.Width = 7.4375!
        '
        'lblUsuario
        '
        Me.lblUsuario.Border.BottomColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Border.LeftColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Border.RightColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Border.TopColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Height = 0.2083333!
        Me.lblUsuario.HyperLink = Nothing
        Me.lblUsuario.Left = 0.125!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.Top = 0.0625!
        Me.lblUsuario.Width = 0.5416667!
        '
        'txtUsuario
        '
        Me.txtUsuario.Border.BottomColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Border.LeftColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Border.RightColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Border.TopColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Height = 0.2083333!
        Me.txtUsuario.Left = 0.6875!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.Top = 0.0625!
        Me.txtUsuario.Width = 1.041667!
        '
        'txtHora
        '
        Me.txtHora.Border.BottomColor = System.Drawing.Color.Black
        Me.txtHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Border.LeftColor = System.Drawing.Color.Black
        Me.txtHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Border.RightColor = System.Drawing.Color.Black
        Me.txtHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Border.TopColor = System.Drawing.Color.Black
        Me.txtHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Height = 0.1875!
        Me.txtHora.Left = 6.5!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
        Me.txtHora.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtHora.Text = Nothing
        Me.txtHora.Top = 0.0625!
        Me.txtHora.Width = 0.9375!
        '
        'txtFecha
        '
        Me.txtFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Border.RightColor = System.Drawing.Color.Black
        Me.txtFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Border.TopColor = System.Drawing.Color.Black
        Me.txtFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 5.8125!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.0625!
        Me.txtFecha.Width = 0.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Height = 0.01041667!
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReportInfo1, Me.Line5, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.28125!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportInfo1
        '
        Me.ReportInfo1.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.RightColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.TopColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.FormatString = "{PageNumber} de {PageCount}"
        Me.ReportInfo1.Height = 0.1875!
        Me.ReportInfo1.Left = 2.875!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.ReportInfo1.Top = 0.0625!
        Me.ReportInfo1.Width = 1.8125!
        '
        'Line5
        '
        Me.Line5.Border.BottomColor = System.Drawing.Color.Black
        Me.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.LeftColor = System.Drawing.Color.Black
        Me.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.RightColor = System.Drawing.Color.Black
        Me.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.TopColor = System.Drawing.Color.Black
        Me.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.0!
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.0!
        Me.Line5.Width = 7.5!
        Me.Line5.X1 = 0.0!
        Me.Line5.X2 = 7.5!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.0!
        '
        'EncabezadoReporte
        '
        Me.EncabezadoReporte.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
        Me.EncabezadoReporte.Height = 0.02083333!
        Me.EncabezadoReporte.Name = "EncabezadoReporte"
        '
        'Line2
        '
        Me.Line2.Border.BottomColor = System.Drawing.Color.Black
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.LeftColor = System.Drawing.Color.Black
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.RightColor = System.Drawing.Color.Black
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.TopColor = System.Drawing.Color.Black
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 2.166667!
        Me.Line2.Width = 7.5!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.5625!
        Me.Line2.Y1 = 2.166667!
        Me.Line2.Y2 = 2.166667!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'lblDatosSocia
        '
        Me.lblDatosSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDatosSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDatosSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosSocia.Border.RightColor = System.Drawing.Color.Black
        Me.lblDatosSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosSocia.Border.TopColor = System.Drawing.Color.Black
        Me.lblDatosSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosSocia.Height = 0.1875!
        Me.lblDatosSocia.HyperLink = Nothing
        Me.lblDatosSocia.Left = 0.0625!
        Me.lblDatosSocia.Name = "lblDatosSocia"
        Me.lblDatosSocia.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: #E0E0E0; font-size: 9.75pt; vertical-align: middle; "
        Me.lblDatosSocia.Text = "DATOS DE LA DEUDORA"
        Me.lblDatosSocia.Top = 0.5625!
        Me.lblDatosSocia.Width = 7.375!
        '
        'lblNombreS
        '
        Me.lblNombreS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombreS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombreS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreS.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombreS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreS.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombreS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreS.Height = 0.1875!
        Me.lblNombreS.HyperLink = Nothing
        Me.lblNombreS.Left = 0.25!
        Me.lblNombreS.Name = "lblNombreS"
        Me.lblNombreS.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblNombreS.Text = "Nombre de Deudora:"
        Me.lblNombreS.Top = 0.9375!
        Me.lblNombreS.Width = 1.375!
        '
        'txtNombreS
        '
        Me.txtNombreS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreS.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreS.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreS.CanGrow = False
        Me.txtNombreS.DataField = "NombreSocia"
        Me.txtNombreS.Height = 0.1875!
        Me.txtNombreS.Left = 1.625!
        Me.txtNombreS.Name = "txtNombreS"
        Me.txtNombreS.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtNombreS.Text = Nothing
        Me.txtNombreS.Top = 0.9375!
        Me.txtNombreS.Width = 5.6875!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblDatosSocia, Me.lblNombreS, Me.txtNombreS, Me.lblCedula, Me.lblDireccion, Me.txtDirecion, Me.txtCedula, Me.lblDatosPrestamo, Me.lblTelefono, Me.txtTelefono, Me.Shape2, Me.lblDepartamento, Me.lblFechaS, Me.lblNumero, Me.txtFechaS, Me.lblMunicipio, Me.lblDistrito, Me.lblBarrio, Me.txtDepartamento, Me.txtMunicipio, Me.txtDistrito, Me.txtBarrio, Me.lblGrupo, Me.txtGrupoS, Me.lblCodigoGS, Me.txtCodGS, Me.lblNuevo, Me.ChkNuevo, Me.ChkRepeticion, Me.lblRepeticion, Me.lblNoPrestamo, Me.txtNoPrestamo, Me.Shape3, Me.lblMonto, Me.lblInstancia, Me.lblPlazo, Me.txtMontoA, Me.txtInstancia, Me.txtPlazo, Me.lblTipoNegocio, Me.txtTipoNegocio, Me.lblFormaPago, Me.lblValor, Me.txtMontoD, Me.lblSesion, Me.lblFecha, Me.txtFechaSesion, Me.txtSesionNo, Me.lblFechaF, Me.lblFechaI, Me.txtFechaF, Me.txtFechaI, Me.lblMontoSem, Me.txtMontoSem, Me.lblInteres, Me.txtMora, Me.txtInteres, Me.lblFechaD, Me.txtFechaD, Me.lblTC, Me.txtTipoCambio, Me.lblMora, Me.lblNumeroSD, Me.Label2, Me.txtMontoDUS, Me.txtTipoPlazo, Me.lblAnulada, Me.txtFormaPago})
        Me.GroupHeader1.DataField = "nSclFichaSociaID"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 5.416667!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'Shape1
        '
        Me.Shape1.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.RightColor = System.Drawing.Color.Black
        Me.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.TopColor = System.Drawing.Color.Black
        Me.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Height = 1.0625!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.8125!
        Me.Shape1.Width = 7.375!
        '
        'lblCedula
        '
        Me.lblCedula.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCedula.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCedula.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Border.RightColor = System.Drawing.Color.Black
        Me.lblCedula.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Border.TopColor = System.Drawing.Color.Black
        Me.lblCedula.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Height = 0.1875!
        Me.lblCedula.HyperLink = Nothing
        Me.lblCedula.Left = 0.25!
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblCedula.Text = "Número de Cédula:"
        Me.lblCedula.Top = 1.25!
        Me.lblCedula.Width = 1.375!
        '
        'lblDireccion
        '
        Me.lblDireccion.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Border.RightColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Border.TopColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Height = 0.1875!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 0.25!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblDireccion.Text = "Dirección:"
        Me.lblDireccion.Top = 1.5625!
        Me.lblDireccion.Width = 1.375!
        '
        'txtDirecion
        '
        Me.txtDirecion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDirecion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDirecion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDirecion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDirecion.Border.RightColor = System.Drawing.Color.Black
        Me.txtDirecion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDirecion.Border.TopColor = System.Drawing.Color.Black
        Me.txtDirecion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDirecion.CanGrow = False
        Me.txtDirecion.DataField = "sDireccionSocia"
        Me.txtDirecion.Height = 0.1875!
        Me.txtDirecion.Left = 1.625!
        Me.txtDirecion.MultiLine = False
        Me.txtDirecion.Name = "txtDirecion"
        Me.txtDirecion.Style = "ddo-char-set: 0; text-align: left; font-size: 9.75pt; white-space: nowrap; vertic" & _
            "al-align: middle; "
        Me.txtDirecion.Text = Nothing
        Me.txtDirecion.Top = 1.5625!
        Me.txtDirecion.Width = 5.6875!
        '
        'txtCedula
        '
        Me.txtCedula.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCedula.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCedula.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCedula.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Border.RightColor = System.Drawing.Color.Black
        Me.txtCedula.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Border.TopColor = System.Drawing.Color.Black
        Me.txtCedula.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.CanGrow = False
        Me.txtCedula.DataField = "sNumeroCedula"
        Me.txtCedula.Height = 0.1875!
        Me.txtCedula.Left = 1.625!
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtCedula.Text = Nothing
        Me.txtCedula.Top = 1.25!
        Me.txtCedula.Width = 2.3125!
        '
        'lblDatosPrestamo
        '
        Me.lblDatosPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDatosPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDatosPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.lblDatosPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.lblDatosPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDatosPrestamo.Height = 0.1875!
        Me.lblDatosPrestamo.HyperLink = Nothing
        Me.lblDatosPrestamo.Left = 0.0625!
        Me.lblDatosPrestamo.Name = "lblDatosPrestamo"
        Me.lblDatosPrestamo.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: #E0E0E0; font-size: 9.75pt; vertical-align: middle; "
        Me.lblDatosPrestamo.Text = "CONDICIONES DEL PRESTAMO"
        Me.lblDatosPrestamo.Top = 3.1875!
        Me.lblDatosPrestamo.Width = 7.375!
        '
        'lblTelefono
        '
        Me.lblTelefono.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Border.RightColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Border.TopColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Height = 0.1875!
        Me.lblTelefono.HyperLink = Nothing
        Me.lblTelefono.Left = 4.0!
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblTelefono.Text = "Teléfono:"
        Me.lblTelefono.Top = 1.25!
        Me.lblTelefono.Width = 0.6875!
        '
        'txtTelefono
        '
        Me.txtTelefono.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTelefono.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Border.RightColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Border.TopColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.CanGrow = False
        Me.txtTelefono.DataField = "sTelefonoSocia"
        Me.txtTelefono.Height = 0.1875!
        Me.txtTelefono.Left = 4.75!
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtTelefono.Text = Nothing
        Me.txtTelefono.Top = 1.25!
        Me.txtTelefono.Width = 2.5625!
        '
        'Shape2
        '
        Me.Shape2.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.RightColor = System.Drawing.Color.Black
        Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.TopColor = System.Drawing.Color.Black
        Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Height = 1.1875!
        Me.Shape2.Left = 0.0625!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 1.9375!
        Me.Shape2.Width = 7.375!
        '
        'lblDepartamento
        '
        Me.lblDepartamento.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Border.RightColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Border.TopColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Height = 0.1875!
        Me.lblDepartamento.HyperLink = Nothing
        Me.lblDepartamento.Left = 0.25!
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblDepartamento.Text = "Departamento:"
        Me.lblDepartamento.Top = 2.0!
        Me.lblDepartamento.Width = 1.125!
        '
        'lblFechaS
        '
        Me.lblFechaS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaS.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaS.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaS.Height = 0.1875!
        Me.lblFechaS.HyperLink = Nothing
        Me.lblFechaS.Left = 4.875!
        Me.lblFechaS.Name = "lblFechaS"
        Me.lblFechaS.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFechaS.Text = "Fecha de Solicitud:"
        Me.lblFechaS.Top = 0.0625!
        Me.lblFechaS.Width = 1.1875!
        '
        'lblNumero
        '
        Me.lblNumero.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNumero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNumero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Border.RightColor = System.Drawing.Color.Black
        Me.lblNumero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Border.TopColor = System.Drawing.Color.Black
        Me.lblNumero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Height = 0.25!
        Me.lblNumero.HyperLink = Nothing
        Me.lblNumero.Left = 4.875!
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblNumero.Text = "Número Solicitud:"
        Me.lblNumero.Top = 0.25!
        Me.lblNumero.Width = 1.1875!
        '
        'txtFechaS
        '
        Me.txtFechaS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaS.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaS.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaS.DataField = "dFechaSolicitudDesembolso"
        Me.txtFechaS.Height = 0.1875!
        Me.txtFechaS.Left = 6.0625!
        Me.txtFechaS.Name = "txtFechaS"
        Me.txtFechaS.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; vertical-align: middle; " & _
            ""
        Me.txtFechaS.Text = Nothing
        Me.txtFechaS.Top = 0.0625!
        Me.txtFechaS.Width = 1.0!
        '
        'lblMunicipio
        '
        Me.lblMunicipio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Border.RightColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Border.TopColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Height = 0.1875!
        Me.lblMunicipio.HyperLink = Nothing
        Me.lblMunicipio.Left = 4.0!
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.Top = 2.0!
        Me.lblMunicipio.Width = 0.75!
        '
        'lblDistrito
        '
        Me.lblDistrito.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Border.RightColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Border.TopColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Height = 0.1875!
        Me.lblDistrito.HyperLink = Nothing
        Me.lblDistrito.Left = 0.25!
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblDistrito.Text = "Distrito:"
        Me.lblDistrito.Top = 2.25!
        Me.lblDistrito.Width = 1.125!
        '
        'lblBarrio
        '
        Me.lblBarrio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.Border.RightColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.Border.TopColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.DataField = "EtiquetaBM"
        Me.lblBarrio.Height = 0.1875!
        Me.lblBarrio.HyperLink = Nothing
        Me.lblBarrio.Left = 4.0!
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblBarrio.Text = "BM"
        Me.lblBarrio.Top = 2.25!
        Me.lblBarrio.Width = 0.75!
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDepartamento.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.RightColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.TopColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.DataField = "Departamento"
        Me.txtDepartamento.Height = 0.1875!
        Me.txtDepartamento.Left = 1.625!
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.Top = 2.0!
        Me.txtDepartamento.Width = 2.3125!
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMunicipio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.RightColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.TopColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.DataField = "Municipio"
        Me.txtMunicipio.Height = 0.1875!
        Me.txtMunicipio.Left = 4.75!
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.Top = 2.0!
        Me.txtMunicipio.Width = 2.5625!
        '
        'txtDistrito
        '
        Me.txtDistrito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDistrito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Border.RightColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Border.TopColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.DataField = "Distrito"
        Me.txtDistrito.Height = 0.1875!
        Me.txtDistrito.Left = 1.625!
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtDistrito.Text = Nothing
        Me.txtDistrito.Top = 2.25!
        Me.txtDistrito.Width = 2.3125!
        '
        'txtBarrio
        '
        Me.txtBarrio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtBarrio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Border.RightColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Border.TopColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.DataField = "BarrioMercado"
        Me.txtBarrio.Height = 0.1875!
        Me.txtBarrio.Left = 4.75!
        Me.txtBarrio.Name = "txtBarrio"
        Me.txtBarrio.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtBarrio.Text = Nothing
        Me.txtBarrio.Top = 2.25!
        Me.txtBarrio.Width = 2.5625!
        '
        'lblGrupo
        '
        Me.lblGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.Height = 0.1875!
        Me.lblGrupo.HyperLink = Nothing
        Me.lblGrupo.Left = 0.25!
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblGrupo.Text = "Nombre Grupo:"
        Me.lblGrupo.Top = 2.5!
        Me.lblGrupo.Width = 1.125!
        '
        'txtGrupoS
        '
        Me.txtGrupoS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGrupoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtGrupoS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGrupoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoS.Border.RightColor = System.Drawing.Color.Black
        Me.txtGrupoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoS.Border.TopColor = System.Drawing.Color.Black
        Me.txtGrupoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoS.DataField = "NombreGrupo"
        Me.txtGrupoS.Height = 0.1875!
        Me.txtGrupoS.Left = 1.625!
        Me.txtGrupoS.Name = "txtGrupoS"
        Me.txtGrupoS.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; vertical-align: middle; " & _
            ""
        Me.txtGrupoS.Text = Nothing
        Me.txtGrupoS.Top = 2.5!
        Me.txtGrupoS.Width = 5.6875!
        '
        'lblCodigoGS
        '
        Me.lblCodigoGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigoGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigoGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigoGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigoGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoGS.Height = 0.1875!
        Me.lblCodigoGS.HyperLink = Nothing
        Me.lblCodigoGS.Left = 0.25!
        Me.lblCodigoGS.Name = "lblCodigoGS"
        Me.lblCodigoGS.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblCodigoGS.Text = "Código Grupo:"
        Me.lblCodigoGS.Top = 2.8125!
        Me.lblCodigoGS.Width = 1.125!
        '
        'txtCodGS
        '
        Me.txtCodGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodGS.DataField = "CodGrupo"
        Me.txtCodGS.Height = 0.1875!
        Me.txtCodGS.Left = 1.625!
        Me.txtCodGS.Name = "txtCodGS"
        Me.txtCodGS.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; vertical-align: middle; " & _
            ""
        Me.txtCodGS.Text = Nothing
        Me.txtCodGS.Top = 2.8125!
        Me.txtCodGS.Width = 2.3125!
        '
        'lblNuevo
        '
        Me.lblNuevo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNuevo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNuevo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNuevo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNuevo.Border.RightColor = System.Drawing.Color.Black
        Me.lblNuevo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNuevo.Border.TopColor = System.Drawing.Color.Black
        Me.lblNuevo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNuevo.Height = 0.1875!
        Me.lblNuevo.HyperLink = Nothing
        Me.lblNuevo.Left = 4.0!
        Me.lblNuevo.Name = "lblNuevo"
        Me.lblNuevo.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblNuevo.Text = "Nuevo:"
        Me.lblNuevo.Top = 2.8125!
        Me.lblNuevo.Width = 0.5625!
        '
        'ChkNuevo
        '
        Me.ChkNuevo.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkNuevo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNuevo.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkNuevo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNuevo.Border.RightColor = System.Drawing.Color.Black
        Me.ChkNuevo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNuevo.Border.TopColor = System.Drawing.Color.Black
        Me.ChkNuevo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNuevo.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkNuevo.DataField = "Nuevo"
        Me.ChkNuevo.Height = 0.2083333!
        Me.ChkNuevo.Left = 4.625!
        Me.ChkNuevo.Name = "ChkNuevo"
        Me.ChkNuevo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.ChkNuevo.Text = ""
        Me.ChkNuevo.Top = 2.8125!
        Me.ChkNuevo.Width = 0.2083333!
        '
        'ChkRepeticion
        '
        Me.ChkRepeticion.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkRepeticion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRepeticion.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkRepeticion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRepeticion.Border.RightColor = System.Drawing.Color.Black
        Me.ChkRepeticion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRepeticion.Border.TopColor = System.Drawing.Color.Black
        Me.ChkRepeticion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkRepeticion.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkRepeticion.DataField = "Repeticion"
        Me.ChkRepeticion.Height = 0.2083333!
        Me.ChkRepeticion.Left = 5.75!
        Me.ChkRepeticion.Name = "ChkRepeticion"
        Me.ChkRepeticion.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.ChkRepeticion.Text = ""
        Me.ChkRepeticion.Top = 2.8125!
        Me.ChkRepeticion.Width = 0.2083333!
        '
        'lblRepeticion
        '
        Me.lblRepeticion.Border.BottomColor = System.Drawing.Color.Black
        Me.lblRepeticion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepeticion.Border.LeftColor = System.Drawing.Color.Black
        Me.lblRepeticion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepeticion.Border.RightColor = System.Drawing.Color.Black
        Me.lblRepeticion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepeticion.Border.TopColor = System.Drawing.Color.Black
        Me.lblRepeticion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepeticion.Height = 0.1875!
        Me.lblRepeticion.HyperLink = Nothing
        Me.lblRepeticion.Left = 4.9375!
        Me.lblRepeticion.Name = "lblRepeticion"
        Me.lblRepeticion.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblRepeticion.Text = "Repetición:"
        Me.lblRepeticion.Top = 2.8125!
        Me.lblRepeticion.Width = 0.75!
        '
        'lblNoPrestamo
        '
        Me.lblNoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.lblNoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.lblNoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoPrestamo.Height = 0.1875!
        Me.lblNoPrestamo.HyperLink = Nothing
        Me.lblNoPrestamo.Left = 6.0625!
        Me.lblNoPrestamo.Name = "lblNoPrestamo"
        Me.lblNoPrestamo.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblNoPrestamo.Text = "No. Préstamo:"
        Me.lblNoPrestamo.Top = 2.8125!
        Me.lblNoPrestamo.Width = 0.9375!
        '
        'txtNoPrestamo
        '
        Me.txtNoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNoPrestamo.DataField = "NoPrestamo"
        Me.txtNoPrestamo.Height = 0.1875!
        Me.txtNoPrestamo.Left = 7.0!
        Me.txtNoPrestamo.Name = "txtNoPrestamo"
        Me.txtNoPrestamo.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtNoPrestamo.Text = Nothing
        Me.txtNoPrestamo.Top = 2.8125!
        Me.txtNoPrestamo.Width = 0.3125!
        '
        'Shape3
        '
        Me.Shape3.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.RightColor = System.Drawing.Color.Black
        Me.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.TopColor = System.Drawing.Color.Black
        Me.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Height = 1.9375!
        Me.Shape3.Left = 0.0625!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = 9.999999!
        Me.Shape3.Top = 3.4375!
        Me.Shape3.Width = 7.375!
        '
        'lblMonto
        '
        Me.lblMonto.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMonto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMonto.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMonto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMonto.Border.RightColor = System.Drawing.Color.Black
        Me.lblMonto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMonto.Border.TopColor = System.Drawing.Color.Black
        Me.lblMonto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMonto.Height = 0.1875!
        Me.lblMonto.HyperLink = Nothing
        Me.lblMonto.Left = 0.25!
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblMonto.Text = "Monto Autorizado C$:"
        Me.lblMonto.Top = 3.5625!
        Me.lblMonto.Width = 1.375!
        '
        'lblInstancia
        '
        Me.lblInstancia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblInstancia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInstancia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblInstancia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInstancia.Border.RightColor = System.Drawing.Color.Black
        Me.lblInstancia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInstancia.Border.TopColor = System.Drawing.Color.Black
        Me.lblInstancia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInstancia.Height = 0.1875!
        Me.lblInstancia.HyperLink = Nothing
        Me.lblInstancia.Left = 0.25!
        Me.lblInstancia.Name = "lblInstancia"
        Me.lblInstancia.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblInstancia.Text = "Instancia Resolutiva:"
        Me.lblInstancia.Top = 3.875!
        Me.lblInstancia.Width = 1.375!
        '
        'lblPlazo
        '
        Me.lblPlazo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPlazo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPlazo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazo.Border.RightColor = System.Drawing.Color.Black
        Me.lblPlazo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazo.Border.TopColor = System.Drawing.Color.Black
        Me.lblPlazo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazo.Height = 0.1875!
        Me.lblPlazo.HyperLink = Nothing
        Me.lblPlazo.Left = 0.25!
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblPlazo.Text = "Plazo del Crédito:"
        Me.lblPlazo.Top = 4.1875!
        Me.lblPlazo.Width = 1.375!
        '
        'txtMontoA
        '
        Me.txtMontoA.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoA.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoA.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoA.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoA.DataField = "nMontoCreditoAprobado"
        Me.txtMontoA.Height = 0.1875!
        Me.txtMontoA.Left = 1.625!
        Me.txtMontoA.Name = "txtMontoA"
        Me.txtMontoA.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMontoA.Text = Nothing
        Me.txtMontoA.Top = 3.5625!
        Me.txtMontoA.Width = 1.5625!
        '
        'txtInstancia
        '
        Me.txtInstancia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtInstancia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtInstancia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtInstancia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInstancia.Border.RightColor = System.Drawing.Color.Black
        Me.txtInstancia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInstancia.Border.TopColor = System.Drawing.Color.Black
        Me.txtInstancia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInstancia.Height = 0.1875!
        Me.txtInstancia.Left = 1.625!
        Me.txtInstancia.Name = "txtInstancia"
        Me.txtInstancia.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtInstancia.Text = "Programa Usura Cero"
        Me.txtInstancia.Top = 3.875!
        Me.txtInstancia.Width = 1.5625!
        '
        'txtPlazo
        '
        Me.txtPlazo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPlazo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazo.Border.RightColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazo.Border.TopColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazo.DataField = "nPlazoAprobado"
        Me.txtPlazo.Height = 0.1875!
        Me.txtPlazo.Left = 1.625!
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; vertical-align: middle; " & _
            ""
        Me.txtPlazo.Text = Nothing
        Me.txtPlazo.Top = 4.1875!
        Me.txtPlazo.Width = 0.25!
        '
        'lblTipoNegocio
        '
        Me.lblTipoNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocio.Height = 0.1875!
        Me.lblTipoNegocio.HyperLink = Nothing
        Me.lblTipoNegocio.Left = 3.25!
        Me.lblTipoNegocio.Name = "lblTipoNegocio"
        Me.lblTipoNegocio.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblTipoNegocio.Text = "Actividad:"
        Me.lblTipoNegocio.Top = 3.5625!
        Me.lblTipoNegocio.Width = 1.0!
        '
        'txtTipoNegocio
        '
        Me.txtTipoNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocio.DataField = "TipoNegocio"
        Me.txtTipoNegocio.Height = 0.1875!
        Me.txtTipoNegocio.Left = 4.25!
        Me.txtTipoNegocio.Name = "txtTipoNegocio"
        Me.txtTipoNegocio.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtTipoNegocio.Text = Nothing
        Me.txtTipoNegocio.Top = 3.5625!
        Me.txtTipoNegocio.Width = 3.0625!
        '
        'lblFormaPago
        '
        Me.lblFormaPago.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFormaPago.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFormaPago.Border.RightColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFormaPago.Border.TopColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFormaPago.Height = 0.1875!
        Me.lblFormaPago.HyperLink = Nothing
        Me.lblFormaPago.Left = 0.25!
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFormaPago.Text = "Forma de Pago:"
        Me.lblFormaPago.Top = 4.4375!
        Me.lblFormaPago.Width = 1.375!
        '
        'lblValor
        '
        Me.lblValor.Border.BottomColor = System.Drawing.Color.Black
        Me.lblValor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblValor.Border.LeftColor = System.Drawing.Color.Black
        Me.lblValor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblValor.Border.RightColor = System.Drawing.Color.Black
        Me.lblValor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblValor.Border.TopColor = System.Drawing.Color.Black
        Me.lblValor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblValor.Height = 0.1875!
        Me.lblValor.HyperLink = Nothing
        Me.lblValor.Left = 0.25!
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblValor.Text = "Valor Desembolso C$:"
        Me.lblValor.Top = 4.75!
        Me.lblValor.Width = 1.375!
        '
        'txtMontoD
        '
        Me.txtMontoD.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoD.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoD.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoD.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoD.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoD.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoD.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoD.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoD.DataField = "nMontoCreditoAprobado"
        Me.txtMontoD.Height = 0.1875!
        Me.txtMontoD.Left = 1.625!
        Me.txtMontoD.Name = "txtMontoD"
        Me.txtMontoD.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMontoD.Text = Nothing
        Me.txtMontoD.Top = 4.75!
        Me.txtMontoD.Width = 1.5625!
        '
        'lblSesion
        '
        Me.lblSesion.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSesion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSesion.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSesion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSesion.Border.RightColor = System.Drawing.Color.Black
        Me.lblSesion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSesion.Border.TopColor = System.Drawing.Color.Black
        Me.lblSesion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSesion.Height = 0.1875!
        Me.lblSesion.HyperLink = Nothing
        Me.lblSesion.Left = 3.25!
        Me.lblSesion.Name = "lblSesion"
        Me.lblSesion.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblSesion.Text = "No. de Sesión:"
        Me.lblSesion.Top = 3.875!
        Me.lblSesion.Width = 1.0!
        '
        'lblFecha
        '
        Me.lblFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFecha.Border.RightColor = System.Drawing.Color.Black
        Me.lblFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFecha.Border.TopColor = System.Drawing.Color.Black
        Me.lblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFecha.Height = 0.1875!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 5.25!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFecha.Text = "Fecha Sesión:"
        Me.lblFecha.Top = 3.875!
        Me.lblFecha.Width = 1.0!
        '
        'txtFechaSesion
        '
        Me.txtFechaSesion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaSesion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaSesion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaSesion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaSesion.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaSesion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaSesion.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaSesion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaSesion.DataField = "dFechaNotificacion"
        Me.txtFechaSesion.Height = 0.1875!
        Me.txtFechaSesion.Left = 6.25!
        Me.txtFechaSesion.Name = "txtFechaSesion"
        Me.txtFechaSesion.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtFechaSesion.Text = Nothing
        Me.txtFechaSesion.Top = 3.875!
        Me.txtFechaSesion.Width = 1.0625!
        '
        'txtSesionNo
        '
        Me.txtSesionNo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtSesionNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSesionNo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtSesionNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSesionNo.Border.RightColor = System.Drawing.Color.Black
        Me.txtSesionNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSesionNo.Border.TopColor = System.Drawing.Color.Black
        Me.txtSesionNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSesionNo.DataField = "sNumSesion"
        Me.txtSesionNo.Height = 0.1875!
        Me.txtSesionNo.Left = 4.25!
        Me.txtSesionNo.Name = "txtSesionNo"
        Me.txtSesionNo.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtSesionNo.Text = Nothing
        Me.txtSesionNo.Top = 3.875!
        Me.txtSesionNo.Width = 0.9375!
        '
        'lblFechaF
        '
        Me.lblFechaF.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaF.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaF.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaF.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaF.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaF.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaF.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaF.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaF.Height = 0.1875!
        Me.lblFechaF.HyperLink = Nothing
        Me.lblFechaF.Left = 3.25!
        Me.lblFechaF.Name = "lblFechaF"
        Me.lblFechaF.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFechaF.Text = "F. Vencimiento:"
        Me.lblFechaF.Top = 4.1875!
        Me.lblFechaF.Width = 1.0!
        '
        'lblFechaI
        '
        Me.lblFechaI.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaI.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaI.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaI.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaI.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaI.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaI.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaI.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaI.Height = 0.1875!
        Me.lblFechaI.HyperLink = Nothing
        Me.lblFechaI.Left = 5.25!
        Me.lblFechaI.Name = "lblFechaI"
        Me.lblFechaI.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFechaI.Text = "F. Primer Pago:"
        Me.lblFechaI.Top = 4.1875!
        Me.lblFechaI.Width = 1.0!
        '
        'txtFechaF
        '
        Me.txtFechaF.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaF.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaF.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaF.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaF.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaF.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaF.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaF.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaF.DataField = "dFechaUltimaCuota"
        Me.txtFechaF.Height = 0.1875!
        Me.txtFechaF.Left = 4.25!
        Me.txtFechaF.Name = "txtFechaF"
        Me.txtFechaF.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtFechaF.Text = Nothing
        Me.txtFechaF.Top = 4.1875!
        Me.txtFechaF.Width = 0.9375!
        '
        'txtFechaI
        '
        Me.txtFechaI.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaI.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaI.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaI.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaI.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaI.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaI.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaI.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaI.DataField = "dFechaPrimerCuota"
        Me.txtFechaI.Height = 0.1875!
        Me.txtFechaI.Left = 6.25!
        Me.txtFechaI.Name = "txtFechaI"
        Me.txtFechaI.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtFechaI.Text = Nothing
        Me.txtFechaI.Top = 4.1875!
        Me.txtFechaI.Width = 1.0625!
        '
        'lblMontoSem
        '
        Me.lblMontoSem.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoSem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoSem.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoSem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoSem.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoSem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoSem.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoSem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoSem.Height = 0.1875!
        Me.lblMontoSem.HyperLink = Nothing
        Me.lblMontoSem.Left = 3.25!
        Me.lblMontoSem.Name = "lblMontoSem"
        Me.lblMontoSem.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblMontoSem.Text = "M. Cuota C$:"
        Me.lblMontoSem.Top = 4.4375!
        Me.lblMontoSem.Width = 1.0!
        '
        'txtMontoSem
        '
        Me.txtMontoSem.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoSem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoSem.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoSem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSem.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoSem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSem.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoSem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSem.DataField = "nMontoCuota"
        Me.txtMontoSem.Height = 0.1875!
        Me.txtMontoSem.Left = 4.25!
        Me.txtMontoSem.Name = "txtMontoSem"
        Me.txtMontoSem.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMontoSem.Text = Nothing
        Me.txtMontoSem.Top = 4.4375!
        Me.txtMontoSem.Width = 0.9375!
        '
        'lblInteres
        '
        Me.lblInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.lblInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.lblInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteres.Border.RightColor = System.Drawing.Color.Black
        Me.lblInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteres.Border.TopColor = System.Drawing.Color.Black
        Me.lblInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteres.Height = 0.1875!
        Me.lblInteres.HyperLink = Nothing
        Me.lblInteres.Left = 5.25!
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblInteres.Text = "Int. Ctes. Anual:"
        Me.lblInteres.Top = 4.4375!
        Me.lblInteres.Width = 1.0!
        '
        'txtMora
        '
        Me.txtMora.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMora.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMora.Border.RightColor = System.Drawing.Color.Black
        Me.txtMora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMora.Border.TopColor = System.Drawing.Color.Black
        Me.txtMora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMora.DataField = "nTasaMoraAnual"
        Me.txtMora.Height = 0.1875!
        Me.txtMora.Left = 6.25!
        Me.txtMora.Name = "txtMora"
        Me.txtMora.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMora.Text = Nothing
        Me.txtMora.Top = 4.75!
        Me.txtMora.Width = 1.0625!
        '
        'txtInteres
        '
        Me.txtInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.txtInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.txtInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInteres.Border.RightColor = System.Drawing.Color.Black
        Me.txtInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInteres.Border.TopColor = System.Drawing.Color.Black
        Me.txtInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInteres.DataField = "nTasaInteresAnual"
        Me.txtInteres.Height = 0.1875!
        Me.txtInteres.Left = 6.25!
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtInteres.Text = Nothing
        Me.txtInteres.Top = 4.4375!
        Me.txtInteres.Width = 1.0625!
        '
        'lblFechaD
        '
        Me.lblFechaD.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaD.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaD.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaD.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaD.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaD.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaD.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaD.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaD.Height = 0.1875!
        Me.lblFechaD.HyperLink = Nothing
        Me.lblFechaD.Left = 3.25!
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFechaD.Text = "F. Desembolso:"
        Me.lblFechaD.Top = 4.75!
        Me.lblFechaD.Width = 1.0!
        '
        'txtFechaD
        '
        Me.txtFechaD.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaD.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaD.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaD.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaD.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaD.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaD.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaD.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaD.DataField = "dFechaDesembolso"
        Me.txtFechaD.Height = 0.1875!
        Me.txtFechaD.Left = 4.25!
        Me.txtFechaD.Name = "txtFechaD"
        Me.txtFechaD.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtFechaD.Text = Nothing
        Me.txtFechaD.Top = 4.75!
        Me.txtFechaD.Width = 0.9375!
        '
        'lblTC
        '
        Me.lblTC.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTC.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTC.Border.RightColor = System.Drawing.Color.Black
        Me.lblTC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTC.Border.TopColor = System.Drawing.Color.Black
        Me.lblTC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTC.Height = 0.1875!
        Me.lblTC.HyperLink = Nothing
        Me.lblTC.Left = 3.25!
        Me.lblTC.Name = "lblTC"
        Me.lblTC.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblTC.Text = "Tasa Cambio:"
        Me.lblTC.Top = 5.0625!
        Me.lblTC.Width = 1.0!
        '
        'txtTipoCambio
        '
        Me.txtTipoCambio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoCambio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoCambio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoCambio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoCambio.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoCambio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoCambio.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoCambio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoCambio.DataField = "nMontoTCambio"
        Me.txtTipoCambio.Height = 0.1875!
        Me.txtTipoCambio.Left = 4.25!
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtTipoCambio.Text = Nothing
        Me.txtTipoCambio.Top = 5.0625!
        Me.txtTipoCambio.Width = 1.0625!
        '
        'lblMora
        '
        Me.lblMora.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMora.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMora.Border.RightColor = System.Drawing.Color.Black
        Me.lblMora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMora.Border.TopColor = System.Drawing.Color.Black
        Me.lblMora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMora.Height = 0.1875!
        Me.lblMora.HyperLink = Nothing
        Me.lblMora.Left = 5.25!
        Me.lblMora.Name = "lblMora"
        Me.lblMora.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblMora.Text = "Int. Mora Anual:"
        Me.lblMora.Top = 4.75!
        Me.lblMora.Width = 1.0!
        '
        'lblNumeroSD
        '
        Me.lblNumeroSD.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNumeroSD.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSD.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNumeroSD.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSD.Border.RightColor = System.Drawing.Color.Black
        Me.lblNumeroSD.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSD.Border.TopColor = System.Drawing.Color.Black
        Me.lblNumeroSD.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSD.DataField = "CodSolicitud"
        Me.lblNumeroSD.Height = 0.25!
        Me.lblNumeroSD.HyperLink = Nothing
        Me.lblNumeroSD.Left = 6.0625!
        Me.lblNumeroSD.Name = "lblNumeroSD"
        Me.lblNumeroSD.Style = "color: Navy; ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: " & _
            "12pt; vertical-align: middle; "
        Me.lblNumeroSD.Text = ""
        Me.lblNumeroSD.Top = 0.25!
        Me.lblNumeroSD.Width = 1.0!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.25!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.Label2.Text = "Valor Desembol. US$:"
        Me.Label2.Top = 5.0625!
        Me.Label2.Width = 1.375!
        '
        'txtMontoDUS
        '
        Me.txtMontoDUS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoDUS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoDUS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoDUS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDUS.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoDUS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDUS.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoDUS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDUS.Height = 0.1875!
        Me.txtMontoDUS.Left = 1.625!
        Me.txtMontoDUS.Name = "txtMontoDUS"
        Me.txtMontoDUS.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMontoDUS.Text = Nothing
        Me.txtMontoDUS.Top = 5.0625!
        Me.txtMontoDUS.Width = 1.5625!
        '
        'txtTipoPlazo
        '
        Me.txtTipoPlazo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoPlazo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoPlazo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoPlazo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazo.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoPlazo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazo.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoPlazo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazo.Height = 0.1875!
        Me.txtTipoPlazo.Left = 1.875!
        Me.txtTipoPlazo.Name = "txtTipoPlazo"
        Me.txtTipoPlazo.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; vertical-align: middle; " & _
            ""
        Me.txtTipoPlazo.Text = Nothing
        Me.txtTipoPlazo.Top = 4.1875!
        Me.txtTipoPlazo.Width = 1.3125!
        '
        'lblAnulada
        '
        Me.lblAnulada.Border.BottomColor = System.Drawing.Color.Black
        Me.lblAnulada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAnulada.Border.LeftColor = System.Drawing.Color.Black
        Me.lblAnulada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAnulada.Border.RightColor = System.Drawing.Color.Black
        Me.lblAnulada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAnulada.Border.TopColor = System.Drawing.Color.Black
        Me.lblAnulada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAnulada.Height = 0.3125!
        Me.lblAnulada.HyperLink = Nothing
        Me.lblAnulada.Left = 0.0625!
        Me.lblAnulada.Name = "lblAnulada"
        Me.lblAnulada.Style = "color: Crimson; ddo-char-set: 1; text-align: justify; font-weight: bold; font-siz" & _
            "e: 15.75pt; font-family: Arial Rounded MT Bold; vertical-align: middle; "
        Me.lblAnulada.Text = "ANULADA"
        Me.lblAnulada.Top = 0.125!
        Me.lblAnulada.Visible = False
        Me.lblAnulada.Width = 1.5!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape4, Me.lblObservaciones, Me.txtObservaciones, Me.lblCargoA, Me.lblFirmaA, Me.lblElaborado, Me.lblCargoB, Me.lblFirmaB, Me.lblAutorizado, Me.picAutorizado, Me.picElaborado})
        Me.GroupFooter1.Height = 2.197917!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'Shape4
        '
        Me.Shape4.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape4.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape4.Border.RightColor = System.Drawing.Color.Black
        Me.Shape4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape4.Border.TopColor = System.Drawing.Color.Black
        Me.Shape4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape4.Height = 0.688!
        Me.Shape4.Left = 0.125!
        Me.Shape4.Name = "Shape4"
        Me.Shape4.RoundingRadius = 9.999999!
        Me.Shape4.Top = 0.125!
        Me.Shape4.Width = 7.27!
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Height = 0.1875!
        Me.lblObservaciones.HyperLink = Nothing
        Me.lblObservaciones.Left = 0.1875!
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblObservaciones.Text = "OBSERVACIONES:"
        Me.lblObservaciones.Top = 0.1875!
        Me.lblObservaciones.Width = 1.5!
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.CanGrow = False
        Me.txtObservaciones.DataField = "sObservaciones"
        Me.txtObservaciones.Height = 0.42!
        Me.txtObservaciones.Left = 0.1875!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtObservaciones.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtObservaciones.Text = Nothing
        Me.txtObservaciones.Top = 0.375!
        Me.txtObservaciones.Width = 7.125!
        '
        'lblCargoA
        '
        Me.lblCargoA.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCargoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoA.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCargoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoA.Border.RightColor = System.Drawing.Color.Black
        Me.lblCargoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoA.Border.TopColor = System.Drawing.Color.Black
        Me.lblCargoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoA.Height = 0.1875!
        Me.lblCargoA.HyperLink = Nothing
        Me.lblCargoA.Left = 0.4375!
        Me.lblCargoA.Name = "lblCargoA"
        Me.lblCargoA.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoA.Text = "Oficial de Crédito"
        Me.lblCargoA.Top = 2.0!
        Me.lblCargoA.Width = 3.25!
        '
        'lblFirmaA
        '
        Me.lblFirmaA.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFirmaA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaA.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFirmaA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaA.Border.RightColor = System.Drawing.Color.Black
        Me.lblFirmaA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaA.Border.TopColor = System.Drawing.Color.Black
        Me.lblFirmaA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaA.Height = 0.1875!
        Me.lblFirmaA.HyperLink = Nothing
        Me.lblFirmaA.Left = 0.4375!
        Me.lblFirmaA.Name = "lblFirmaA"
        Me.lblFirmaA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaA.Text = "FirmaA"
        Me.lblFirmaA.Top = 1.8125!
        Me.lblFirmaA.Width = 3.25!
        '
        'lblElaborado
        '
        Me.lblElaborado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblElaborado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblElaborado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblElaborado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblElaborado.Border.RightColor = System.Drawing.Color.Black
        Me.lblElaborado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblElaborado.Border.TopColor = System.Drawing.Color.Black
        Me.lblElaborado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblElaborado.Height = 0.1875!
        Me.lblElaborado.HyperLink = Nothing
        Me.lblElaborado.Left = 0.4375!
        Me.lblElaborado.Name = "lblElaborado"
        Me.lblElaborado.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblElaborado.Text = "Elaborado por:"
        Me.lblElaborado.Top = 1.625!
        Me.lblElaborado.Width = 3.25!
        '
        'lblCargoB
        '
        Me.lblCargoB.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCargoB.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoB.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCargoB.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoB.Border.RightColor = System.Drawing.Color.Black
        Me.lblCargoB.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoB.Border.TopColor = System.Drawing.Color.Black
        Me.lblCargoB.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoB.Height = 0.1875!
        Me.lblCargoB.HyperLink = Nothing
        Me.lblCargoB.Left = 4.0625!
        Me.lblCargoB.Name = "lblCargoB"
        Me.lblCargoB.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoB.Text = "CargoB"
        Me.lblCargoB.Top = 2.0!
        Me.lblCargoB.Width = 3.0625!
        '
        'lblFirmaB
        '
        Me.lblFirmaB.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFirmaB.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaB.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFirmaB.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaB.Border.RightColor = System.Drawing.Color.Black
        Me.lblFirmaB.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaB.Border.TopColor = System.Drawing.Color.Black
        Me.lblFirmaB.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaB.Height = 0.1875!
        Me.lblFirmaB.HyperLink = Nothing
        Me.lblFirmaB.Left = 4.0625!
        Me.lblFirmaB.Name = "lblFirmaB"
        Me.lblFirmaB.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaB.Text = "FirmaB"
        Me.lblFirmaB.Top = 1.8125!
        Me.lblFirmaB.Width = 3.0625!
        '
        'lblAutorizado
        '
        Me.lblAutorizado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblAutorizado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAutorizado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblAutorizado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAutorizado.Border.RightColor = System.Drawing.Color.Black
        Me.lblAutorizado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAutorizado.Border.TopColor = System.Drawing.Color.Black
        Me.lblAutorizado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblAutorizado.Height = 0.1875!
        Me.lblAutorizado.HyperLink = Nothing
        Me.lblAutorizado.Left = 4.0625!
        Me.lblAutorizado.Name = "lblAutorizado"
        Me.lblAutorizado.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblAutorizado.Text = "Autorizado por:"
        Me.lblAutorizado.Top = 1.625!
        Me.lblAutorizado.Width = 3.0625!
        '
        'picAutorizado
        '
        Me.picAutorizado.Border.BottomColor = System.Drawing.Color.Black
        Me.picAutorizado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picAutorizado.Border.LeftColor = System.Drawing.Color.Black
        Me.picAutorizado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picAutorizado.Border.RightColor = System.Drawing.Color.Black
        Me.picAutorizado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picAutorizado.Border.TopColor = System.Drawing.Color.Black
        Me.picAutorizado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picAutorizado.Height = 0.625!
        Me.picAutorizado.Image = Nothing
        Me.picAutorizado.ImageData = Nothing
        Me.picAutorizado.Left = 4.25!
        Me.picAutorizado.LineWeight = 0.0!
        Me.picAutorizado.Name = "picAutorizado"
        Me.picAutorizado.Top = 0.9375!
        Me.picAutorizado.Width = 2.75!
        '
        'picElaborado
        '
        Me.picElaborado.Border.BottomColor = System.Drawing.Color.Black
        Me.picElaborado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picElaborado.Border.LeftColor = System.Drawing.Color.Black
        Me.picElaborado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picElaborado.Border.RightColor = System.Drawing.Color.Black
        Me.picElaborado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picElaborado.Border.TopColor = System.Drawing.Color.Black
        Me.picElaborado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picElaborado.Height = 0.625!
        Me.picElaborado.Image = Nothing
        Me.picElaborado.ImageData = Nothing
        Me.picElaborado.Left = 0.6875!
        Me.picElaborado.LineWeight = 0.0!
        Me.picElaborado.Name = "picElaborado"
        Me.picElaborado.Top = 0.9375!
        Me.picElaborado.Width = 2.75!
        '
        'txtFormaPago
        '
        Me.txtFormaPago.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFormaPago.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFormaPago.Border.RightColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFormaPago.Border.TopColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFormaPago.DataField = "FormaPago"
        Me.txtFormaPago.Height = 0.1875!
        Me.txtFormaPago.Left = 1.625!
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtFormaPago.Text = Nothing
        Me.txtFormaPago.Top = 4.4375!
        Me.txtFormaPago.Width = 1.5625!
        '
        'rptSclSolicitudDesembolso
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.5!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDatosSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDirecion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDatosPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrupoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkNuevo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkRepeticion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRepeticion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInstancia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstancia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSesion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaSesion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSesionNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoSem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoSem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumeroSD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoDUS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblElaborado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAutorizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAutorizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picElaborado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblUsuario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDatosSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombreS As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNombreS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblCedula As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDirecion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDatosPrestamo As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTelefono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblDepartamento As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFechaS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMunicipio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDistrito As DataDynamics.ActiveReports.Label
    Friend WithEvents lblBarrio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDepartamento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMunicipio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDistrito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBarrio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblGrupo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtGrupoS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodigoGS As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNuevo As DataDynamics.ActiveReports.Label
    Friend WithEvents ChkNuevo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents ChkRepeticion As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents lblRepeticion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNoPrestamo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNoPrestamo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Shape3 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblMonto As DataDynamics.ActiveReports.Label
    Friend WithEvents lblInstancia As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPlazo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMontoA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtInstancia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTipoNegocio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTipoNegocio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFormaPago As DataDynamics.ActiveReports.Label
    Friend WithEvents lblValor As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMontoD As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblSesion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaSesion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSesionNo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFechaF As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFechaI As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaF As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaI As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMontoSem As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMontoSem As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTC As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTipoCambio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblInteres As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtInteres As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFechaD As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaD As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMora As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNumeroSD As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape4 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblObservaciones As DataDynamics.ActiveReports.Label
    Friend WithEvents txtObservaciones As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCargoA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblElaborado As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCargoB As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaB As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAutorizado As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMontoDUS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipoPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAnulada As DataDynamics.ActiveReports.Label
    Friend WithEvents picAutorizado As DataDynamics.ActiveReports.Picture
    Friend WithEvents picElaborado As DataDynamics.ActiveReports.Picture
    Friend WithEvents SubReporteFCL As DataDynamics.ActiveReports.SubReport
    Friend WithEvents txtFormaPago As DataDynamics.ActiveReports.TextBox
End Class
