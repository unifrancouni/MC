<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSccSolicitudCheque
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSccSolicitudCheque))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblCodigoRpt = New DataDynamics.ActiveReports.Label
        Me.SubReporteFCL = New DataDynamics.ActiveReports.SubReport
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtCodigoCuenta = New DataDynamics.ActiveReports.TextBox
        Me.txtCuenta = New DataDynamics.ActiveReports.TextBox
        Me.txtDebe = New DataDynamics.ActiveReports.TextBox
        Me.txtHaber = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.lblNombreS = New DataDynamics.ActiveReports.Label
        Me.txtNombreS = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblEncabezado = New DataDynamics.ActiveReports.Label
        Me.lblMontoLetras = New DataDynamics.ActiveReports.Label
        Me.lblConcepto = New DataDynamics.ActiveReports.Label
        Me.txtConcepto = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoLetras = New DataDynamics.ActiveReports.TextBox
        Me.lblCuentas = New DataDynamics.ActiveReports.Label
        Me.lblFuente = New DataDynamics.ActiveReports.Label
        Me.lblFechaS = New DataDynamics.ActiveReports.Label
        Me.lblNumero = New DataDynamics.ActiveReports.Label
        Me.txtFechaS = New DataDynamics.ActiveReports.TextBox
        Me.txtFuenteFondos = New DataDynamics.ActiveReports.TextBox
        Me.lblInstancia = New DataDynamics.ActiveReports.Label
        Me.txtInstancia = New DataDynamics.ActiveReports.TextBox
        Me.lblCodigoCuenta = New DataDynamics.ActiveReports.Label
        Me.lblValor = New DataDynamics.ActiveReports.Label
        Me.txtMonto = New DataDynamics.ActiveReports.TextBox
        Me.lblTC = New DataDynamics.ActiveReports.Label
        Me.txtTipoCambio = New DataDynamics.ActiveReports.TextBox
        Me.lblNumeroSC = New DataDynamics.ActiveReports.Label
        Me.lblAnulada = New DataDynamics.ActiveReports.Label
        Me.lblNombreCuenta = New DataDynamics.ActiveReports.Label
        Me.lblDebe = New DataDynamics.ActiveReports.Label
        Me.lblCredito = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.lblPrestamo = New DataDynamics.ActiveReports.Label
        Me.lblIdFichaSocia = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.lblCargoA = New DataDynamics.ActiveReports.Label
        Me.lblFirmaA = New DataDynamics.ActiveReports.Label
        Me.lblSolicitado = New DataDynamics.ActiveReports.Label
        Me.lblCargoB = New DataDynamics.ActiveReports.Label
        Me.lblFirmaB = New DataDynamics.ActiveReports.Label
        Me.lblRevisado = New DataDynamics.ActiveReports.Label
        Me.lblCargoC = New DataDynamics.ActiveReports.Label
        Me.lblFirmaC = New DataDynamics.ActiveReports.Label
        Me.lblAutorizado = New DataDynamics.ActiveReports.Label
        Me.LblTotales = New DataDynamics.ActiveReports.Label
        Me.LblTotal = New DataDynamics.ActiveReports.Label
        Me.txtMontoDT = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoHT = New DataDynamics.ActiveReports.TextBox
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDebe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHaber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoLetras, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFuente, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFuenteFondos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInstancia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstancia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumeroSC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDebe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblIdFichaSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSolicitado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRevisado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAutorizado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoDT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoHT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.lblCodigoRpt, Me.SubReporteFCL, Me.SubReport1})
        Me.PageHeader1.Height = 1.291667!
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
        Me.lblTitulo.Text = "SOLICITUD DE CHEQUE"
        Me.lblTitulo.Top = 1.0!
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
        'lblCodigoRpt
        '
        Me.lblCodigoRpt.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigoRpt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoRpt.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigoRpt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoRpt.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigoRpt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoRpt.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigoRpt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoRpt.Height = 0.5!
        Me.lblCodigoRpt.HyperLink = Nothing
        Me.lblCodigoRpt.Left = 5.75!
        Me.lblCodigoRpt.Name = "lblCodigoRpt"
        Me.lblCodigoRpt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 21.75pt; verti" & _
            "cal-align: middle; "
        Me.lblCodigoRpt.Text = "CC1"
        Me.lblCodigoRpt.Top = 0.1875!
        Me.lblCodigoRpt.Width = 0.7875!
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
        Me.SubReporteFCL.Height = 0.9375!
        Me.SubReporteFCL.Left = 0.0!
        Me.SubReporteFCL.Name = "SubReporteFCL"
        Me.SubReporteFCL.Report = Nothing
        Me.SubReporteFCL.ReportName = "SubReport1"
        Me.SubReporteFCL.Top = 0.0625!
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigoCuenta, Me.txtCuenta, Me.txtDebe, Me.txtHaber})
        Me.Detail1.Height = 0.1979167!
        Me.Detail1.Name = "Detail1"
        '
        'txtCodigoCuenta
        '
        Me.txtCodigoCuenta.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodigoCuenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodigoCuenta.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodigoCuenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodigoCuenta.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodigoCuenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodigoCuenta.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodigoCuenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodigoCuenta.CanGrow = False
        Me.txtCodigoCuenta.DataField = "sCodigoCuenta"
        Me.txtCodigoCuenta.Height = 0.1875!
        Me.txtCodigoCuenta.Left = 0.25!
        Me.txtCodigoCuenta.MultiLine = False
        Me.txtCodigoCuenta.Name = "txtCodigoCuenta"
        Me.txtCodigoCuenta.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodigoCuenta.Text = Nothing
        Me.txtCodigoCuenta.Top = 0.0!
        Me.txtCodigoCuenta.Width = 2.25!
        '
        'txtCuenta
        '
        Me.txtCuenta.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuenta.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuenta.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuenta.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuenta.CanGrow = False
        Me.txtCuenta.DataField = "sNombreCuenta"
        Me.txtCuenta.Height = 0.1875!
        Me.txtCuenta.Left = 2.5!
        Me.txtCuenta.MultiLine = False
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCuenta.Text = Nothing
        Me.txtCuenta.Top = 0.0!
        Me.txtCuenta.Width = 2.5!
        '
        'txtDebe
        '
        Me.txtDebe.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDebe.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDebe.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDebe.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDebe.Border.RightColor = System.Drawing.Color.Black
        Me.txtDebe.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDebe.Border.TopColor = System.Drawing.Color.Black
        Me.txtDebe.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDebe.CanGrow = False
        Me.txtDebe.DataField = "nMontoDebe"
        Me.txtDebe.Height = 0.1875!
        Me.txtDebe.Left = 5.0!
        Me.txtDebe.MultiLine = False
        Me.txtDebe.Name = "txtDebe"
        Me.txtDebe.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDebe.Text = Nothing
        Me.txtDebe.Top = 0.0!
        Me.txtDebe.Width = 1.125!
        '
        'txtHaber
        '
        Me.txtHaber.Border.BottomColor = System.Drawing.Color.Black
        Me.txtHaber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtHaber.Border.LeftColor = System.Drawing.Color.Black
        Me.txtHaber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtHaber.Border.RightColor = System.Drawing.Color.Black
        Me.txtHaber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtHaber.Border.TopColor = System.Drawing.Color.Black
        Me.txtHaber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtHaber.CanGrow = False
        Me.txtHaber.DataField = "nMontoHaber"
        Me.txtHaber.Height = 0.1875!
        Me.txtHaber.Left = 6.125!
        Me.txtHaber.MultiLine = False
        Me.txtHaber.Name = "txtHaber"
        Me.txtHaber.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtHaber.Text = Nothing
        Me.txtHaber.Top = 0.0!
        Me.txtHaber.Width = 1.1875!
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
        Me.lblNombreS.Text = "Cheque a Nombre De:"
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
        Me.txtNombreS.DataField = "Beneficiario"
        Me.txtNombreS.Height = 0.1875!
        Me.txtNombreS.Left = 1.625!
        Me.txtNombreS.Name = "txtNombreS"
        Me.txtNombreS.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtNombreS.Text = Nothing
        Me.txtNombreS.Top = 0.9375!
        Me.txtNombreS.Width = 3.6875!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblEncabezado, Me.lblNombreS, Me.txtNombreS, Me.lblMontoLetras, Me.lblConcepto, Me.txtConcepto, Me.txtMontoLetras, Me.lblCuentas, Me.lblFuente, Me.lblFechaS, Me.lblNumero, Me.txtFechaS, Me.txtFuenteFondos, Me.lblInstancia, Me.txtInstancia, Me.lblCodigoCuenta, Me.lblValor, Me.txtMonto, Me.lblTC, Me.txtTipoCambio, Me.lblNumeroSC, Me.lblAnulada, Me.lblNombreCuenta, Me.lblDebe, Me.lblCredito, Me.Line1, Me.Line3, Me.Line4, Me.lblPrestamo, Me.lblIdFichaSocia})
        Me.GroupHeader1.DataField = "nCodigo"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 3.135417!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'lblEncabezado
        '
        Me.lblEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblEncabezado.Height = 0.3125!
        Me.lblEncabezado.HyperLink = Nothing
        Me.lblEncabezado.Left = 0.25!
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: #E0E0E0; font-size: 9.75pt; vertical-align: middle; "
        Me.lblEncabezado.Text = ""
        Me.lblEncabezado.Top = 2.8125!
        Me.lblEncabezado.Width = 7.0625!
        '
        'lblMontoLetras
        '
        Me.lblMontoLetras.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoLetras.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoLetras.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoLetras.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoLetras.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoLetras.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoLetras.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoLetras.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoLetras.Height = 0.1875!
        Me.lblMontoLetras.HyperLink = Nothing
        Me.lblMontoLetras.Left = 0.25!
        Me.lblMontoLetras.Name = "lblMontoLetras"
        Me.lblMontoLetras.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblMontoLetras.Text = "Cantidad en Letras:"
        Me.lblMontoLetras.Top = 1.25!
        Me.lblMontoLetras.Width = 1.375!
        '
        'lblConcepto
        '
        Me.lblConcepto.Border.BottomColor = System.Drawing.Color.Black
        Me.lblConcepto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblConcepto.Border.LeftColor = System.Drawing.Color.Black
        Me.lblConcepto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblConcepto.Border.RightColor = System.Drawing.Color.Black
        Me.lblConcepto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblConcepto.Border.TopColor = System.Drawing.Color.Black
        Me.lblConcepto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblConcepto.Height = 0.1875!
        Me.lblConcepto.HyperLink = Nothing
        Me.lblConcepto.Left = 0.25!
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblConcepto.Text = "Concepto del Pago:"
        Me.lblConcepto.Top = 1.5625!
        Me.lblConcepto.Width = 1.375!
        '
        'txtConcepto
        '
        Me.txtConcepto.Border.BottomColor = System.Drawing.Color.Black
        Me.txtConcepto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtConcepto.Border.LeftColor = System.Drawing.Color.Black
        Me.txtConcepto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtConcepto.Border.RightColor = System.Drawing.Color.Black
        Me.txtConcepto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtConcepto.Border.TopColor = System.Drawing.Color.Black
        Me.txtConcepto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtConcepto.CanGrow = False
        Me.txtConcepto.DataField = "sConceptoPago"
        Me.txtConcepto.Height = 0.625!
        Me.txtConcepto.Left = 1.625!
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; white-space: inherit; verti" & _
            "cal-align: top; "
        Me.txtConcepto.Text = Nothing
        Me.txtConcepto.Top = 1.5625!
        Me.txtConcepto.Width = 5.6875!
        '
        'txtMontoLetras
        '
        Me.txtMontoLetras.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoLetras.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoLetras.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoLetras.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoLetras.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoLetras.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoLetras.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoLetras.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoLetras.CanGrow = False
        Me.txtMontoLetras.DataField = "sNumeroCedula"
        Me.txtMontoLetras.Height = 0.3!
        Me.txtMontoLetras.Left = 1.625!
        Me.txtMontoLetras.Name = "txtMontoLetras"
        Me.txtMontoLetras.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMontoLetras.Text = Nothing
        Me.txtMontoLetras.Top = 1.25!
        Me.txtMontoLetras.Width = 5.625!
        '
        'lblCuentas
        '
        Me.lblCuentas.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCuentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuentas.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCuentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuentas.Border.RightColor = System.Drawing.Color.Black
        Me.lblCuentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuentas.Border.TopColor = System.Drawing.Color.Black
        Me.lblCuentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuentas.Height = 0.1875!
        Me.lblCuentas.HyperLink = Nothing
        Me.lblCuentas.Left = 0.25!
        Me.lblCuentas.Name = "lblCuentas"
        Me.lblCuentas.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: #E0E0E0; font-size: 9.75pt; vertical-align: middle; "
        Me.lblCuentas.Text = "CODIFICACION CONTABLE"
        Me.lblCuentas.Top = 2.625!
        Me.lblCuentas.Width = 7.0625!
        '
        'lblFuente
        '
        Me.lblFuente.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFuente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFuente.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFuente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFuente.Border.RightColor = System.Drawing.Color.Black
        Me.lblFuente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFuente.Border.TopColor = System.Drawing.Color.Black
        Me.lblFuente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFuente.Height = 0.1875!
        Me.lblFuente.HyperLink = Nothing
        Me.lblFuente.Left = 0.25!
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFuente.Text = "Fuente de Fondos:"
        Me.lblFuente.Top = 2.25!
        Me.lblFuente.Width = 1.375!
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
        Me.lblFechaS.Left = 5.375!
        Me.lblFechaS.Name = "lblFechaS"
        Me.lblFechaS.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFechaS.Text = "Fecha Solicitud:"
        Me.lblFechaS.Top = 0.625!
        Me.lblFechaS.Width = 1.0!
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
        Me.lblNumero.Left = 5.375!
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblNumero.Text = "No.  Solicitud:"
        Me.lblNumero.Top = 0.0625!
        Me.lblNumero.Width = 1.0!
        '
        'txtFechaS
        '
        Me.txtFechaS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaS.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaS.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaS.DataField = "dFechaSolicitudCheque"
        Me.txtFechaS.Height = 0.1875!
        Me.txtFechaS.Left = 6.375!
        Me.txtFechaS.Name = "txtFechaS"
        Me.txtFechaS.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; vertical-align: middle; " & _
            ""
        Me.txtFechaS.Text = Nothing
        Me.txtFechaS.Top = 0.625!
        Me.txtFechaS.Width = 0.875!
        '
        'txtFuenteFondos
        '
        Me.txtFuenteFondos.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFuenteFondos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFuenteFondos.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFuenteFondos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFuenteFondos.Border.RightColor = System.Drawing.Color.Black
        Me.txtFuenteFondos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFuenteFondos.Border.TopColor = System.Drawing.Color.Black
        Me.txtFuenteFondos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFuenteFondos.DataField = "Fuente"
        Me.txtFuenteFondos.Height = 0.1875!
        Me.txtFuenteFondos.Left = 1.625!
        Me.txtFuenteFondos.Name = "txtFuenteFondos"
        Me.txtFuenteFondos.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtFuenteFondos.Text = Nothing
        Me.txtFuenteFondos.Top = 2.25!
        Me.txtFuenteFondos.Width = 3.6875!
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
        Me.lblInstancia.Text = "Proyecto o Programa:"
        Me.lblInstancia.Top = 0.625!
        Me.lblInstancia.Width = 1.375!
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
        Me.txtInstancia.Top = 0.625!
        Me.txtInstancia.Width = 3.6875!
        '
        'lblCodigoCuenta
        '
        Me.lblCodigoCuenta.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigoCuenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoCuenta.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigoCuenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoCuenta.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigoCuenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoCuenta.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigoCuenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoCuenta.Height = 0.1875!
        Me.lblCodigoCuenta.HyperLink = Nothing
        Me.lblCodigoCuenta.Left = 0.3125!
        Me.lblCodigoCuenta.Name = "lblCodigoCuenta"
        Me.lblCodigoCuenta.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblCodigoCuenta.Text = "Código Cuenta"
        Me.lblCodigoCuenta.Top = 2.875!
        Me.lblCodigoCuenta.Width = 2.1875!
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
        Me.lblValor.Left = 5.375!
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblValor.Text = "Valor C$:"
        Me.lblValor.Top = 0.9375!
        Me.lblValor.Width = 1.0!
        '
        'txtMonto
        '
        Me.txtMonto.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMonto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMonto.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMonto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMonto.Border.RightColor = System.Drawing.Color.Black
        Me.txtMonto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMonto.Border.TopColor = System.Drawing.Color.Black
        Me.txtMonto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMonto.DataField = "nMonto"
        Me.txtMonto.Height = 0.1875!
        Me.txtMonto.Left = 6.375!
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtMonto.Text = Nothing
        Me.txtMonto.Top = 0.9375!
        Me.txtMonto.Width = 0.875!
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
        Me.lblTC.Left = 5.375!
        Me.lblTC.Name = "lblTC"
        Me.lblTC.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblTC.Text = "Tasa Cambio:"
        Me.lblTC.Top = 2.25!
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
        Me.txtTipoCambio.Left = 6.375!
        Me.txtTipoCambio.Name = "txtTipoCambio"
        Me.txtTipoCambio.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: middle; "
        Me.txtTipoCambio.Text = Nothing
        Me.txtTipoCambio.Top = 2.25!
        Me.txtTipoCambio.Width = 0.9375!
        '
        'lblNumeroSC
        '
        Me.lblNumeroSC.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNumeroSC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSC.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNumeroSC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSC.Border.RightColor = System.Drawing.Color.Black
        Me.lblNumeroSC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSC.Border.TopColor = System.Drawing.Color.Black
        Me.lblNumeroSC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumeroSC.DataField = "nCodigo"
        Me.lblNumeroSC.Height = 0.25!
        Me.lblNumeroSC.HyperLink = Nothing
        Me.lblNumeroSC.Left = 6.375!
        Me.lblNumeroSC.Name = "lblNumeroSC"
        Me.lblNumeroSC.Style = "color: Navy; ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: " & _
            "11.25pt; vertical-align: middle; "
        Me.lblNumeroSC.Text = ""
        Me.lblNumeroSC.Top = 0.0625!
        Me.lblNumeroSC.Width = 0.875!
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
        'lblNombreCuenta
        '
        Me.lblNombreCuenta.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombreCuenta.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreCuenta.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombreCuenta.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreCuenta.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombreCuenta.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreCuenta.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombreCuenta.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreCuenta.Height = 0.1875!
        Me.lblNombreCuenta.HyperLink = Nothing
        Me.lblNombreCuenta.Left = 2.5!
        Me.lblNombreCuenta.Name = "lblNombreCuenta"
        Me.lblNombreCuenta.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblNombreCuenta.Text = "Nombre Cuenta"
        Me.lblNombreCuenta.Top = 2.875!
        Me.lblNombreCuenta.Width = 2.5!
        '
        'lblDebe
        '
        Me.lblDebe.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDebe.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDebe.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDebe.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDebe.Border.RightColor = System.Drawing.Color.Black
        Me.lblDebe.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDebe.Border.TopColor = System.Drawing.Color.Black
        Me.lblDebe.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDebe.Height = 0.1875!
        Me.lblDebe.HyperLink = Nothing
        Me.lblDebe.Left = 5.0!
        Me.lblDebe.Name = "lblDebe"
        Me.lblDebe.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblDebe.Text = "Débito"
        Me.lblDebe.Top = 2.875!
        Me.lblDebe.Width = 1.125!
        '
        'lblCredito
        '
        Me.lblCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCredito.Border.RightColor = System.Drawing.Color.Black
        Me.lblCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCredito.Border.TopColor = System.Drawing.Color.Black
        Me.lblCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCredito.Height = 0.1875!
        Me.lblCredito.HyperLink = Nothing
        Me.lblCredito.Left = 6.125!
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblCredito.Text = "Crédito"
        Me.lblCredito.Top = 2.875!
        Me.lblCredito.Width = 1.125!
        '
        'Line1
        '
        Me.Line1.Border.BottomColor = System.Drawing.Color.Black
        Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.LeftColor = System.Drawing.Color.Black
        Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.RightColor = System.Drawing.Color.Black
        Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Border.TopColor = System.Drawing.Color.Black
        Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line1.Height = 0.3125!
        Me.Line1.Left = 2.5!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 2.8125!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 2.5!
        Me.Line1.X2 = 2.5!
        Me.Line1.Y1 = 2.8125!
        Me.Line1.Y2 = 3.125!
        '
        'Line3
        '
        Me.Line3.Border.BottomColor = System.Drawing.Color.Black
        Me.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.LeftColor = System.Drawing.Color.Black
        Me.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.RightColor = System.Drawing.Color.Black
        Me.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.TopColor = System.Drawing.Color.Black
        Me.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Height = 0.3125!
        Me.Line3.Left = 5.0!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 2.8125!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 5.0!
        Me.Line3.X2 = 5.0!
        Me.Line3.Y1 = 2.8125!
        Me.Line3.Y2 = 3.125!
        '
        'Line4
        '
        Me.Line4.Border.BottomColor = System.Drawing.Color.Black
        Me.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.LeftColor = System.Drawing.Color.Black
        Me.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.RightColor = System.Drawing.Color.Black
        Me.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.TopColor = System.Drawing.Color.Black
        Me.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Height = 0.3125!
        Me.Line4.Left = 6.125!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 2.8125!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 6.125!
        Me.Line4.X2 = 6.125!
        Me.Line4.Y1 = 2.8125!
        Me.Line4.Y2 = 3.125!
        '
        'lblPrestamo
        '
        Me.lblPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.lblPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.lblPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrestamo.Height = 0.25!
        Me.lblPrestamo.HyperLink = Nothing
        Me.lblPrestamo.Left = 5.375!
        Me.lblPrestamo.Name = "lblPrestamo"
        Me.lblPrestamo.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblPrestamo.Text = "Préstamo ID:"
        Me.lblPrestamo.Top = 0.3125!
        Me.lblPrestamo.Width = 1.0!
        '
        'lblIdFichaSocia
        '
        Me.lblIdFichaSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblIdFichaSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblIdFichaSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblIdFichaSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblIdFichaSocia.Border.RightColor = System.Drawing.Color.Black
        Me.lblIdFichaSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblIdFichaSocia.Border.TopColor = System.Drawing.Color.Black
        Me.lblIdFichaSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblIdFichaSocia.DataField = "nSclFichaSociaID"
        Me.lblIdFichaSocia.Height = 0.25!
        Me.lblIdFichaSocia.HyperLink = Nothing
        Me.lblIdFichaSocia.Left = 6.375!
        Me.lblIdFichaSocia.Name = "lblIdFichaSocia"
        Me.lblIdFichaSocia.Style = "color: Navy; ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: " & _
            "11.25pt; vertical-align: middle; "
        Me.lblIdFichaSocia.Text = ""
        Me.lblIdFichaSocia.Top = 0.3125!
        Me.lblIdFichaSocia.Width = 0.875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblCargoA, Me.lblFirmaA, Me.lblSolicitado, Me.lblCargoB, Me.lblFirmaB, Me.lblRevisado, Me.lblCargoC, Me.lblFirmaC, Me.lblAutorizado, Me.LblTotales, Me.LblTotal, Me.txtMontoDT, Me.txtMontoHT, Me.Line6, Me.Line7})
        Me.GroupFooter1.Height = 2.25!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After
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
        Me.lblCargoA.DataField = "CargoE"
        Me.lblCargoA.Height = 0.3125!
        Me.lblCargoA.HyperLink = Nothing
        Me.lblCargoA.Left = 0.125!
        Me.lblCargoA.Name = "lblCargoA"
        Me.lblCargoA.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoA.Text = "CargoA"
        Me.lblCargoA.Top = 1.9375!
        Me.lblCargoA.Width = 2.25!
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
        Me.lblFirmaA.DataField = "ESolicita"
        Me.lblFirmaA.Height = 0.1875!
        Me.lblFirmaA.HyperLink = Nothing
        Me.lblFirmaA.Left = 0.125!
        Me.lblFirmaA.Name = "lblFirmaA"
        Me.lblFirmaA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaA.Text = "FirmaA"
        Me.lblFirmaA.Top = 1.75!
        Me.lblFirmaA.Width = 2.25!
        '
        'lblSolicitado
        '
        Me.lblSolicitado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSolicitado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSolicitado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSolicitado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSolicitado.Border.RightColor = System.Drawing.Color.Black
        Me.lblSolicitado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSolicitado.Border.TopColor = System.Drawing.Color.Black
        Me.lblSolicitado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblSolicitado.Height = 0.1875!
        Me.lblSolicitado.HyperLink = Nothing
        Me.lblSolicitado.Left = 0.125!
        Me.lblSolicitado.Name = "lblSolicitado"
        Me.lblSolicitado.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblSolicitado.Text = "Solicitado por:"
        Me.lblSolicitado.Top = 1.5625!
        Me.lblSolicitado.Width = 2.25!
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
        Me.lblCargoB.DataField = "CargoR"
        Me.lblCargoB.Height = 0.3125!
        Me.lblCargoB.HyperLink = Nothing
        Me.lblCargoB.Left = 2.625!
        Me.lblCargoB.Name = "lblCargoB"
        Me.lblCargoB.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoB.Text = "CargoB"
        Me.lblCargoB.Top = 1.9375!
        Me.lblCargoB.Width = 2.25!
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
        Me.lblFirmaB.DataField = "ERevisa"
        Me.lblFirmaB.Height = 0.1875!
        Me.lblFirmaB.HyperLink = Nothing
        Me.lblFirmaB.Left = 2.625!
        Me.lblFirmaB.Name = "lblFirmaB"
        Me.lblFirmaB.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaB.Text = "FirmaB"
        Me.lblFirmaB.Top = 1.75!
        Me.lblFirmaB.Width = 2.25!
        '
        'lblRevisado
        '
        Me.lblRevisado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblRevisado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRevisado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblRevisado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRevisado.Border.RightColor = System.Drawing.Color.Black
        Me.lblRevisado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRevisado.Border.TopColor = System.Drawing.Color.Black
        Me.lblRevisado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblRevisado.Height = 0.1875!
        Me.lblRevisado.HyperLink = Nothing
        Me.lblRevisado.Left = 2.625!
        Me.lblRevisado.Name = "lblRevisado"
        Me.lblRevisado.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblRevisado.Text = "Revisado por:"
        Me.lblRevisado.Top = 1.5625!
        Me.lblRevisado.Width = 2.25!
        '
        'lblCargoC
        '
        Me.lblCargoC.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCargoC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoC.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCargoC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoC.Border.RightColor = System.Drawing.Color.Black
        Me.lblCargoC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoC.Border.TopColor = System.Drawing.Color.Black
        Me.lblCargoC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoC.Height = 0.3125!
        Me.lblCargoC.HyperLink = Nothing
        Me.lblCargoC.Left = 5.0!
        Me.lblCargoC.Name = "lblCargoC"
        Me.lblCargoC.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoC.Text = "CargoC"
        Me.lblCargoC.Top = 1.9375!
        Me.lblCargoC.Width = 2.4375!
        '
        'lblFirmaC
        '
        Me.lblFirmaC.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFirmaC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaC.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFirmaC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaC.Border.RightColor = System.Drawing.Color.Black
        Me.lblFirmaC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaC.Border.TopColor = System.Drawing.Color.Black
        Me.lblFirmaC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaC.Height = 0.1875!
        Me.lblFirmaC.HyperLink = Nothing
        Me.lblFirmaC.Left = 5.125!
        Me.lblFirmaC.Name = "lblFirmaC"
        Me.lblFirmaC.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaC.Text = "FirmaC"
        Me.lblFirmaC.Top = 1.75!
        Me.lblFirmaC.Width = 2.1875!
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
        Me.lblAutorizado.Left = 5.125!
        Me.lblAutorizado.Name = "lblAutorizado"
        Me.lblAutorizado.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblAutorizado.Text = "Autorizado por:"
        Me.lblAutorizado.Top = 1.5625!
        Me.lblAutorizado.Width = 2.1875!
        '
        'LblTotales
        '
        Me.LblTotales.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotales.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotales.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotales.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.LblTotales.Height = 0.25!
        Me.LblTotales.HyperLink = Nothing
        Me.LblTotales.Left = 0.25!
        Me.LblTotales.Name = "LblTotales"
        Me.LblTotales.Style = "color: Black; ddo-char-set: 0; text-align: center; font-weight: bold; background-" & _
            "color: #E0E0E0; font-size: 9.75pt; vertical-align: middle; "
        Me.LblTotales.Text = ""
        Me.LblTotales.Top = 0.0!
        Me.LblTotales.Width = 7.0625!
        '
        'LblTotal
        '
        Me.LblTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.LblTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.LblTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.RightColor = System.Drawing.Color.Black
        Me.LblTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Border.TopColor = System.Drawing.Color.Black
        Me.LblTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblTotal.Height = 0.1875!
        Me.LblTotal.HyperLink = Nothing
        Me.LblTotal.Left = 0.3125!
        Me.LblTotal.Name = "LblTotal"
        Me.LblTotal.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.LblTotal.Text = "TOTALES"
        Me.LblTotal.Top = 0.05!
        Me.LblTotal.Width = 4.5625!
        '
        'txtMontoDT
        '
        Me.txtMontoDT.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoDT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDT.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoDT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDT.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoDT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDT.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoDT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDT.CanGrow = False
        Me.txtMontoDT.DataField = "nMontoDebe"
        Me.txtMontoDT.Height = 0.1875!
        Me.txtMontoDT.Left = 5.0!
        Me.txtMontoDT.Name = "txtMontoDT"
        Me.txtMontoDT.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoDT.SummaryGroup = "GroupHeader1"
        Me.txtMontoDT.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMontoDT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMontoDT.Text = Nothing
        Me.txtMontoDT.Top = 0.05!
        Me.txtMontoDT.Width = 1.125!
        '
        'txtMontoHT
        '
        Me.txtMontoHT.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoHT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoHT.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoHT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoHT.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoHT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoHT.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoHT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoHT.CanGrow = False
        Me.txtMontoHT.DataField = "nMontoHaber"
        Me.txtMontoHT.Height = 0.1875!
        Me.txtMontoHT.Left = 6.125!
        Me.txtMontoHT.Name = "txtMontoHT"
        Me.txtMontoHT.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoHT.SummaryGroup = "GroupHeader1"
        Me.txtMontoHT.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMontoHT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMontoHT.Text = Nothing
        Me.txtMontoHT.Top = 0.05!
        Me.txtMontoHT.Width = 1.1875!
        '
        'Line6
        '
        Me.Line6.Border.BottomColor = System.Drawing.Color.Black
        Me.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.LeftColor = System.Drawing.Color.Black
        Me.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.RightColor = System.Drawing.Color.Black
        Me.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.TopColor = System.Drawing.Color.Black
        Me.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Height = 0.25!
        Me.Line6.Left = 5.0!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.0!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 5.0!
        Me.Line6.X2 = 5.0!
        Me.Line6.Y1 = 0.0!
        Me.Line6.Y2 = 0.25!
        '
        'Line7
        '
        Me.Line7.Border.BottomColor = System.Drawing.Color.Black
        Me.Line7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line7.Border.LeftColor = System.Drawing.Color.Black
        Me.Line7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line7.Border.RightColor = System.Drawing.Color.Black
        Me.Line7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line7.Border.TopColor = System.Drawing.Color.Black
        Me.Line7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line7.Height = 0.25!
        Me.Line7.Left = 6.125!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.0!
        Me.Line7.Width = 0.0!
        Me.Line7.X1 = 6.125!
        Me.Line7.X2 = 6.125!
        Me.Line7.Y1 = 0.0!
        Me.Line7.Y2 = 0.25!
        '
        'SubReport1
        '
        Me.SubReport1.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.RightColor = System.Drawing.Color.Black
        Me.SubReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.Border.TopColor = System.Drawing.Color.Black
        Me.SubReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 1.0!
        Me.SubReport1.Left = 0.0625!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 0.0!
        Me.SubReport1.Width = 7.375!
        '
        'rptSccSolicitudCheque
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.510417!
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
        CType(Me.lblCodigoRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDebe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHaber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoLetras, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFuente, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFuenteFondos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInstancia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstancia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumeroSC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDebe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblIdFichaSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSolicitado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRevisado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAutorizado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoDT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoHT, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblCodigoRpt As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombreS As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNombreS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblMontoLetras As DataDynamics.ActiveReports.Label
    Friend WithEvents lblConcepto As DataDynamics.ActiveReports.Label
    Friend WithEvents txtConcepto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoLetras As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCuentas As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFuente As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFechaS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFuenteFondos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblInstancia As DataDynamics.ActiveReports.Label
    Friend WithEvents txtInstancia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodigoCuenta As DataDynamics.ActiveReports.Label
    Friend WithEvents lblValor As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMonto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTC As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTipoCambio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNumeroSC As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCargoA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblSolicitado As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCargoB As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaB As DataDynamics.ActiveReports.Label
    Friend WithEvents lblRevisado As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAnulada As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCargoC As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaC As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAutorizado As DataDynamics.ActiveReports.Label
    Friend WithEvents lblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombreCuenta As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDebe As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCredito As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtCodigoCuenta As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuenta As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDebe As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHaber As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LblTotales As DataDynamics.ActiveReports.Label
    Friend WithEvents LblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMontoDT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoHT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPrestamo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblIdFichaSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReporteFCL As DataDynamics.ActiveReports.SubReport
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
End Class
