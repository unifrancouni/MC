<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclTablaAmortizacion
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclTablaAmortizacion))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblCodigo = New DataDynamics.ActiveReports.Label
        Me.lblNombre = New DataDynamics.ActiveReports.Label
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtNumCuota = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaPago = New DataDynamics.ActiveReports.TextBox
        Me.txtAmortizacion = New DataDynamics.ActiveReports.TextBox
        Me.txtMantValor = New DataDynamics.ActiveReports.TextBox
        Me.txtIntereses = New DataDynamics.ActiveReports.TextBox
        Me.txtCuotaSemanal = New DataDynamics.ActiveReports.TextBox
        Me.txtSaldo = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtparametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro2 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.txtNombreApellidos = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaDesembolso = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaPrimerPago = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaVencimiento = New DataDynamics.ActiveReports.TextBox
        Me.txtPlazo = New DataDynamics.ActiveReports.TextBox
        Me.txtCuotas = New DataDynamics.ActiveReports.TextBox
        Me.txtTasaInteres = New DataDynamics.ActiveReports.TextBox
        Me.txtTasaMantValor = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoCor = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoDol = New DataDynamics.ActiveReports.TextBox
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.txtGrupoSolidario = New DataDynamics.ActiveReports.TextBox
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.txtTotalAmortizacion = New DataDynamics.ActiveReports.TextBox
        Me.txtTotalMantValor = New DataDynamics.ActiveReports.TextBox
        Me.txtTotalIntereses = New DataDynamics.ActiveReports.TextBox
        Me.txtTotalCuotaSemanal = New DataDynamics.ActiveReports.TextBox
        Me.txtColTotalIzq = New DataDynamics.ActiveReports.TextBox
        Me.txtColTotalDer = New DataDynamics.ActiveReports.TextBox
        Me.txtColTotalIzq2 = New DataDynamics.ActiveReports.TextBox
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAmortizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMantValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIntereses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuotaSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDesembolso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaPrimerPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTasaInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTasaMantValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoCor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoDol, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrupoSolidario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalAmortizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalMantValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIntereses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalCuotaSemanal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColTotalIzq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColTotalDer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtColTotalIzq2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.Label1})
        Me.PageHeader1.Height = 1.03125!
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
        Me.lblTitulo.Height = 0.1875!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.0!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; verti" & _
            "cal-align: middle; "
        Me.lblTitulo.Text = "TABLA DE AMORTIZACION"
        Me.lblTitulo.Top = 0.75!
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
        Me.Label1.Text = "CS10"
        Me.Label1.Top = 0.1875!
        Me.Label1.Width = 0.8125!
        '
        'lblCodigo
        '
        Me.lblCodigo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigo.Height = 0.3125!
        Me.lblCodigo.HyperLink = Nothing
        Me.lblCodigo.Left = 0.0!
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblCodigo.Text = "NUMERO DE CUOTA"
        Me.lblCodigo.Top = 2.041667!
        Me.lblCodigo.Width = 0.75!
        '
        'lblNombre
        '
        Me.lblNombre.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombre.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombre.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombre.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombre.Height = 0.3125!
        Me.lblNombre.HyperLink = Nothing
        Me.lblNombre.Left = 0.75!
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblNombre.Text = "FECHA DE PAGO"
        Me.lblNombre.Top = 2.041667!
        Me.lblNombre.Width = 0.9375!
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
        Me.lblUsuario.Left = 5.75!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.Top = 0.0!
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
        Me.txtUsuario.Left = 6.3125!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.Top = 0.0!
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
        Me.txtHora.Top = 0.1875!
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
        Me.txtFecha.Left = 5.75!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.1875!
        Me.txtFecha.Width = 0.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNumCuota, Me.txtFechaPago, Me.txtAmortizacion, Me.txtMantValor, Me.txtIntereses, Me.txtCuotaSemanal, Me.txtSaldo})
        Me.Detail1.Height = 0.1666667!
        Me.Detail1.Name = "Detail1"
        '
        'txtNumCuota
        '
        Me.txtNumCuota.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNumCuota.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNumCuota.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNumCuota.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNumCuota.Border.RightColor = System.Drawing.Color.Black
        Me.txtNumCuota.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNumCuota.Border.TopColor = System.Drawing.Color.Black
        Me.txtNumCuota.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNumCuota.Height = 0.1875!
        Me.txtNumCuota.Left = 0.0!
        Me.txtNumCuota.Name = "txtNumCuota"
        Me.txtNumCuota.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNumCuota.Text = Nothing
        Me.txtNumCuota.Top = 0.0!
        Me.txtNumCuota.Width = 0.75!
        '
        'txtFechaPago
        '
        Me.txtFechaPago.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaPago.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaPago.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaPago.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaPago.Height = 0.1875!
        Me.txtFechaPago.Left = 0.75!
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFechaPago.Text = Nothing
        Me.txtFechaPago.Top = 0.0!
        Me.txtFechaPago.Width = 0.9375!
        '
        'txtAmortizacion
        '
        Me.txtAmortizacion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtAmortizacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAmortizacion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtAmortizacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtAmortizacion.Border.RightColor = System.Drawing.Color.Black
        Me.txtAmortizacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtAmortizacion.Border.TopColor = System.Drawing.Color.Black
        Me.txtAmortizacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtAmortizacion.Height = 0.1875!
        Me.txtAmortizacion.Left = 1.6875!
        Me.txtAmortizacion.Name = "txtAmortizacion"
        Me.txtAmortizacion.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtAmortizacion.Text = Nothing
        Me.txtAmortizacion.Top = 0.0!
        Me.txtAmortizacion.Width = 1.3125!
        '
        'txtMantValor
        '
        Me.txtMantValor.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMantValor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMantValor.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMantValor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMantValor.Border.RightColor = System.Drawing.Color.Black
        Me.txtMantValor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMantValor.Border.TopColor = System.Drawing.Color.Black
        Me.txtMantValor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMantValor.Height = 0.1875!
        Me.txtMantValor.Left = 3.0!
        Me.txtMantValor.Name = "txtMantValor"
        Me.txtMantValor.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMantValor.Text = Nothing
        Me.txtMantValor.Top = 0.0!
        Me.txtMantValor.Width = 1.0625!
        '
        'txtIntereses
        '
        Me.txtIntereses.Border.BottomColor = System.Drawing.Color.Black
        Me.txtIntereses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtIntereses.Border.LeftColor = System.Drawing.Color.Black
        Me.txtIntereses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtIntereses.Border.RightColor = System.Drawing.Color.Black
        Me.txtIntereses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtIntereses.Border.TopColor = System.Drawing.Color.Black
        Me.txtIntereses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtIntereses.Height = 0.1875!
        Me.txtIntereses.Left = 4.0625!
        Me.txtIntereses.Name = "txtIntereses"
        Me.txtIntereses.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtIntereses.Text = Nothing
        Me.txtIntereses.Top = 0.0!
        Me.txtIntereses.Width = 0.9375!
        '
        'txtCuotaSemanal
        '
        Me.txtCuotaSemanal.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuotaSemanal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotaSemanal.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuotaSemanal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuotaSemanal.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuotaSemanal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuotaSemanal.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuotaSemanal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotaSemanal.Height = 0.1875!
        Me.txtCuotaSemanal.Left = 5.0!
        Me.txtCuotaSemanal.Name = "txtCuotaSemanal"
        Me.txtCuotaSemanal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCuotaSemanal.Text = Nothing
        Me.txtCuotaSemanal.Top = 0.0!
        Me.txtCuotaSemanal.Width = 1.125!
        '
        'txtSaldo
        '
        Me.txtSaldo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtSaldo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtSaldo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSaldo.Border.RightColor = System.Drawing.Color.Black
        Me.txtSaldo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSaldo.Border.TopColor = System.Drawing.Color.Black
        Me.txtSaldo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldo.Height = 0.1875!
        Me.txtSaldo.Left = 6.125!
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtSaldo.Text = Nothing
        Me.txtSaldo.Top = 0.0!
        Me.txtSaldo.Width = 1.3125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtparametro1, Me.txtparametro2, Me.ReportInfo1, Me.Line5, Me.TextBox1, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.4166667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtparametro1
        '
        Me.txtparametro1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Border.RightColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Border.TopColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Height = 0.1875!
        Me.txtparametro1.Left = 0.7291667!
        Me.txtparametro1.Name = "txtparametro1"
        Me.txtparametro1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro1.Text = Nothing
        Me.txtparametro1.Top = 0.0!
        Me.txtparametro1.Width = 2.75!
        '
        'txtparametro2
        '
        Me.txtparametro2.Border.BottomColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Border.LeftColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Border.RightColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Border.TopColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Height = 0.1875!
        Me.txtparametro2.Left = 0.0!
        Me.txtparametro2.Name = "txtparametro2"
        Me.txtparametro2.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro2.Text = Nothing
        Me.txtparametro2.Top = 0.1875!
        Me.txtparametro2.Width = 3.5!
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
        Me.ReportInfo1.Height = 0.3125!
        Me.ReportInfo1.Left = 3.5!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Visible = False
        Me.ReportInfo1.Width = 1.0!
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
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.TextBox1.Text = "Parámetros:"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Visible = False
        Me.TextBox1.Width = 0.6875!
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
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label2.Text = "NOMBRE Y APELLIDOS:"
        Me.Label2.Top = 0.03125!
        Me.Label2.Width = 1.6875!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label3.Text = "FECHA DESEMBOLSO:"
        Me.Label3.Top = 0.40625!
        Me.Label3.Width = 1.6875!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label4.Text = "FECHA 1ER. PAGO:"
        Me.Label4.Top = 0.59375!
        Me.Label4.Width = 1.6875!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.0!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label5.Text = "FECHA VENCIMIENTO:"
        Me.Label5.Top = 0.78125!
        Me.Label5.Width = 1.6875!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label6.Text = "PLAZO EN MESES:"
        Me.Label6.Top = 0.96875!
        Me.Label6.Width = 1.6875!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Height = 0.1875!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.0!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label7.Text = "CUOTAS:"
        Me.Label7.Top = 1.15625!
        Me.Label7.Width = 1.6875!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Height = 0.1875!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.0!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label8.Text = "TASA DE INTERES:"
        Me.Label8.Top = 1.34375!
        Me.Label8.Width = 1.6875!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label9.Text = "TASA DE MANTENIM. VALOR:"
        Me.Label9.Top = 1.53125!
        Me.Label9.Width = 2.1875!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Height = 0.1875!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.0!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label10.Text = "MONTO:"
        Me.Label10.Top = 1.71875!
        Me.Label10.Width = 1.6875!
        '
        'txtNombreApellidos
        '
        Me.txtNombreApellidos.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreApellidos.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreApellidos.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreApellidos.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreApellidos.Height = 0.1875!
        Me.txtNombreApellidos.Left = 2.375!
        Me.txtNombreApellidos.Name = "txtNombreApellidos"
        Me.txtNombreApellidos.Style = "ddo-char-set: 0; font-size: 9.75pt; vertical-align: middle; "
        Me.txtNombreApellidos.Text = Nothing
        Me.txtNombreApellidos.Top = 0.0625!
        Me.txtNombreApellidos.Width = 4.625!
        '
        'txtFechaDesembolso
        '
        Me.txtFechaDesembolso.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaDesembolso.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaDesembolso.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaDesembolso.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaDesembolso.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaDesembolso.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaDesembolso.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaDesembolso.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaDesembolso.Height = 0.1875!
        Me.txtFechaDesembolso.Left = 2.375!
        Me.txtFechaDesembolso.Name = "txtFechaDesembolso"
        Me.txtFechaDesembolso.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtFechaDesembolso.Text = Nothing
        Me.txtFechaDesembolso.Top = 0.4375!
        Me.txtFechaDesembolso.Width = 1.375!
        '
        'txtFechaPrimerPago
        '
        Me.txtFechaPrimerPago.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaPrimerPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaPrimerPago.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaPrimerPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaPrimerPago.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaPrimerPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaPrimerPago.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaPrimerPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaPrimerPago.Height = 0.1875!
        Me.txtFechaPrimerPago.Left = 2.375!
        Me.txtFechaPrimerPago.Name = "txtFechaPrimerPago"
        Me.txtFechaPrimerPago.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtFechaPrimerPago.Text = Nothing
        Me.txtFechaPrimerPago.Top = 0.625!
        Me.txtFechaPrimerPago.Width = 1.375!
        '
        'txtFechaVencimiento
        '
        Me.txtFechaVencimiento.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaVencimiento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaVencimiento.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaVencimiento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaVencimiento.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaVencimiento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaVencimiento.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaVencimiento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaVencimiento.Height = 0.1875!
        Me.txtFechaVencimiento.Left = 2.375!
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtFechaVencimiento.Text = Nothing
        Me.txtFechaVencimiento.Top = 0.8125!
        Me.txtFechaVencimiento.Width = 1.375!
        '
        'txtPlazo
        '
        Me.txtPlazo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazo.Border.RightColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazo.Border.TopColor = System.Drawing.Color.Black
        Me.txtPlazo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazo.Height = 0.1875!
        Me.txtPlazo.Left = 2.375!
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtPlazo.Text = Nothing
        Me.txtPlazo.Top = 1.0!
        Me.txtPlazo.Width = 1.375!
        '
        'txtCuotas
        '
        Me.txtCuotas.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuotas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotas.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuotas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotas.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuotas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotas.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuotas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotas.Height = 0.1875!
        Me.txtCuotas.Left = 2.375!
        Me.txtCuotas.Name = "txtCuotas"
        Me.txtCuotas.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtCuotas.Text = Nothing
        Me.txtCuotas.Top = 1.1875!
        Me.txtCuotas.Width = 1.375!
        '
        'txtTasaInteres
        '
        Me.txtTasaInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaInteres.Border.RightColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaInteres.Border.TopColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaInteres.Height = 0.1875!
        Me.txtTasaInteres.Left = 2.375!
        Me.txtTasaInteres.Name = "txtTasaInteres"
        Me.txtTasaInteres.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtTasaInteres.Text = Nothing
        Me.txtTasaInteres.Top = 1.375!
        Me.txtTasaInteres.Width = 1.375!
        '
        'txtTasaMantValor
        '
        Me.txtTasaMantValor.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTasaMantValor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaMantValor.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTasaMantValor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaMantValor.Border.RightColor = System.Drawing.Color.Black
        Me.txtTasaMantValor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaMantValor.Border.TopColor = System.Drawing.Color.Black
        Me.txtTasaMantValor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaMantValor.Height = 0.1875!
        Me.txtTasaMantValor.Left = 2.375!
        Me.txtTasaMantValor.Name = "txtTasaMantValor"
        Me.txtTasaMantValor.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtTasaMantValor.Text = Nothing
        Me.txtTasaMantValor.Top = 1.5625!
        Me.txtTasaMantValor.Width = 1.375!
        '
        'txtMontoCor
        '
        Me.txtMontoCor.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoCor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoCor.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoCor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoCor.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoCor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoCor.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoCor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoCor.Height = 0.1875!
        Me.txtMontoCor.Left = 2.375!
        Me.txtMontoCor.Name = "txtMontoCor"
        Me.txtMontoCor.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtMontoCor.Text = Nothing
        Me.txtMontoCor.Top = 1.71875!
        Me.txtMontoCor.Width = 1.375!
        '
        'txtMontoDol
        '
        Me.txtMontoDol.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoDol.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDol.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoDol.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDol.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoDol.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDol.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoDol.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoDol.Height = 0.1875!
        Me.txtMontoDol.Left = 4.0!
        Me.txtMontoDol.Name = "txtMontoDol"
        Me.txtMontoDol.Style = "ddo-char-set: 0; text-align: right; font-size: 9.75pt; vertical-align: middle; "
        Me.txtMontoDol.Text = Nothing
        Me.txtMontoDol.Top = 1.71875!
        Me.txtMontoDol.Width = 1.375!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label11.Height = 0.3125!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 1.6875!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.Label11.Text = "AMORTIZACION"
        Me.Label11.Top = 2.041667!
        Me.Label11.Width = 1.3125!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.3125!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 3.0!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.Label12.Text = "MANT. VALOR"
        Me.Label12.Top = 2.041667!
        Me.Label12.Width = 1.0625!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.3125!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 4.0625!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.Label13.Text = "INTERESES"
        Me.Label13.Top = 2.041667!
        Me.Label13.Width = 0.9375!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label14.Height = 0.3125!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 5.0!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.Label14.Text = "CUOTA SEMANAL"
        Me.Label14.Top = 2.041667!
        Me.Label14.Width = 1.125!
        '
        'Label15
        '
        Me.Label15.Border.BottomColor = System.Drawing.Color.Black
        Me.Label15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.LeftColor = System.Drawing.Color.Black
        Me.Label15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.RightColor = System.Drawing.Color.Black
        Me.Label15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Border.TopColor = System.Drawing.Color.Black
        Me.Label15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label15.Height = 0.3125!
        Me.Label15.HyperLink = Nothing
        Me.Label15.Left = 6.125!
        Me.Label15.Name = "Label15"
        Me.Label15.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.Label15.Text = "SALDO"
        Me.Label15.Top = 2.041667!
        Me.Label15.Width = 1.3125!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label2, Me.lblNombre, Me.lblCodigo, Me.Label3, Me.Label4, Me.Label5, Me.Label6, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.txtNombreApellidos, Me.txtFechaDesembolso, Me.txtFechaPrimerPago, Me.txtFechaVencimiento, Me.txtPlazo, Me.txtCuotas, Me.txtTasaInteres, Me.txtTasaMantValor, Me.txtMontoCor, Me.txtMontoDol, Me.Label11, Me.Label12, Me.Label13, Me.Label14, Me.Label15, Me.txtGrupoSolidario, Me.Label16})
        Me.GroupHeader1.DataField = "nSclFichaSociaID"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 2.364583!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'txtGrupoSolidario
        '
        Me.txtGrupoSolidario.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoSolidario.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoSolidario.Border.RightColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoSolidario.Border.TopColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoSolidario.Height = 0.1875!
        Me.txtGrupoSolidario.Left = 2.375!
        Me.txtGrupoSolidario.Name = "txtGrupoSolidario"
        Me.txtGrupoSolidario.Style = "ddo-char-set: 0; font-size: 9.75pt; vertical-align: middle; "
        Me.txtGrupoSolidario.Text = Nothing
        Me.txtGrupoSolidario.Top = 0.25!
        Me.txtGrupoSolidario.Width = 4.625!
        '
        'Label16
        '
        Me.Label16.Border.BottomColor = System.Drawing.Color.Black
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.LeftColor = System.Drawing.Color.Black
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.RightColor = System.Drawing.Color.Black
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.TopColor = System.Drawing.Color.Black
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.0!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label16.Text = "GRUPO SOLIDARIO:"
        Me.Label16.Top = 0.21875!
        Me.Label16.Width = 1.6875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtTotalAmortizacion, Me.txtTotalMantValor, Me.txtTotalIntereses, Me.txtTotalCuotaSemanal, Me.txtColTotalIzq, Me.txtColTotalDer, Me.txtColTotalIzq2})
        Me.GroupFooter1.Height = 0.2083333!
        Me.GroupFooter1.Name = "GroupFooter1"
        Me.GroupFooter1.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'txtTotalAmortizacion
        '
        Me.txtTotalAmortizacion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalAmortizacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalAmortizacion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalAmortizacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalAmortizacion.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalAmortizacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalAmortizacion.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalAmortizacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalAmortizacion.DataField = "nMontoCreditoAprobado"
        Me.txtTotalAmortizacion.Height = 0.1875!
        Me.txtTotalAmortizacion.Left = 1.6875!
        Me.txtTotalAmortizacion.Name = "txtTotalAmortizacion"
        Me.txtTotalAmortizacion.OutputFormat = resources.GetString("txtTotalAmortizacion.OutputFormat")
        Me.txtTotalAmortizacion.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalAmortizacion.Text = Nothing
        Me.txtTotalAmortizacion.Top = 0.0!
        Me.txtTotalAmortizacion.Width = 1.3125!
        '
        'txtTotalMantValor
        '
        Me.txtTotalMantValor.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalMantValor.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalMantValor.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalMantValor.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalMantValor.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalMantValor.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalMantValor.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalMantValor.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalMantValor.DataField = "nMantValor"
        Me.txtTotalMantValor.Height = 0.1875!
        Me.txtTotalMantValor.Left = 3.0!
        Me.txtTotalMantValor.Name = "txtTotalMantValor"
        Me.txtTotalMantValor.OutputFormat = resources.GetString("txtTotalMantValor.OutputFormat")
        Me.txtTotalMantValor.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalMantValor.SummaryGroup = "GroupHeader1"
        Me.txtTotalMantValor.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalMantValor.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTotalMantValor.Text = Nothing
        Me.txtTotalMantValor.Top = 0.0!
        Me.txtTotalMantValor.Width = 1.0625!
        '
        'txtTotalIntereses
        '
        Me.txtTotalIntereses.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalIntereses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalIntereses.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalIntereses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalIntereses.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalIntereses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalIntereses.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalIntereses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalIntereses.DataField = "nIntereses"
        Me.txtTotalIntereses.Height = 0.1875!
        Me.txtTotalIntereses.Left = 4.0625!
        Me.txtTotalIntereses.Name = "txtTotalIntereses"
        Me.txtTotalIntereses.OutputFormat = resources.GetString("txtTotalIntereses.OutputFormat")
        Me.txtTotalIntereses.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalIntereses.SummaryGroup = "GroupHeader1"
        Me.txtTotalIntereses.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalIntereses.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTotalIntereses.Text = Nothing
        Me.txtTotalIntereses.Top = 0.0!
        Me.txtTotalIntereses.Width = 0.9375!
        '
        'txtTotalCuotaSemanal
        '
        Me.txtTotalCuotaSemanal.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalCuotaSemanal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalCuotaSemanal.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalCuotaSemanal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalCuotaSemanal.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalCuotaSemanal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalCuotaSemanal.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalCuotaSemanal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTotalCuotaSemanal.DataField = "nCuota"
        Me.txtTotalCuotaSemanal.Height = 0.1875!
        Me.txtTotalCuotaSemanal.Left = 5.0!
        Me.txtTotalCuotaSemanal.Name = "txtTotalCuotaSemanal"
        Me.txtTotalCuotaSemanal.OutputFormat = resources.GetString("txtTotalCuotaSemanal.OutputFormat")
        Me.txtTotalCuotaSemanal.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalCuotaSemanal.SummaryGroup = "GroupHeader1"
        Me.txtTotalCuotaSemanal.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalCuotaSemanal.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtTotalCuotaSemanal.Text = Nothing
        Me.txtTotalCuotaSemanal.Top = 0.0!
        Me.txtTotalCuotaSemanal.Width = 1.125!
        '
        'txtColTotalIzq
        '
        Me.txtColTotalIzq.Border.BottomColor = System.Drawing.Color.Black
        Me.txtColTotalIzq.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq.Border.LeftColor = System.Drawing.Color.Black
        Me.txtColTotalIzq.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq.Border.RightColor = System.Drawing.Color.Black
        Me.txtColTotalIzq.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq.Border.TopColor = System.Drawing.Color.Black
        Me.txtColTotalIzq.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq.Height = 0.1875!
        Me.txtColTotalIzq.Left = 0.0!
        Me.txtColTotalIzq.Name = "txtColTotalIzq"
        Me.txtColTotalIzq.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtColTotalIzq.Text = Nothing
        Me.txtColTotalIzq.Top = 0.0!
        Me.txtColTotalIzq.Width = 0.75!
        '
        'txtColTotalDer
        '
        Me.txtColTotalDer.Border.BottomColor = System.Drawing.Color.Black
        Me.txtColTotalDer.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalDer.Border.LeftColor = System.Drawing.Color.Black
        Me.txtColTotalDer.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalDer.Border.RightColor = System.Drawing.Color.Black
        Me.txtColTotalDer.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalDer.Border.TopColor = System.Drawing.Color.Black
        Me.txtColTotalDer.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalDer.Height = 0.1875!
        Me.txtColTotalDer.Left = 6.125!
        Me.txtColTotalDer.Name = "txtColTotalDer"
        Me.txtColTotalDer.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtColTotalDer.Text = Nothing
        Me.txtColTotalDer.Top = 0.0!
        Me.txtColTotalDer.Width = 1.3125!
        '
        'txtColTotalIzq2
        '
        Me.txtColTotalIzq2.Border.BottomColor = System.Drawing.Color.Black
        Me.txtColTotalIzq2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq2.Border.LeftColor = System.Drawing.Color.Black
        Me.txtColTotalIzq2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq2.Border.RightColor = System.Drawing.Color.Black
        Me.txtColTotalIzq2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq2.Border.TopColor = System.Drawing.Color.Black
        Me.txtColTotalIzq2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtColTotalIzq2.Height = 0.1875!
        Me.txtColTotalIzq2.Left = 0.75!
        Me.txtColTotalIzq2.Name = "txtColTotalIzq2"
        Me.txtColTotalIzq2.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtColTotalIzq2.Text = Nothing
        Me.txtColTotalIzq2.Top = 0.0!
        Me.txtColTotalIzq2.Width = 0.9375!
        '
        'rptSclTablaAmortizacion
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
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumCuota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAmortizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMantValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIntereses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuotaSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDesembolso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaPrimerPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTasaInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTasaMantValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoCor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoDol, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrupoSolidario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalAmortizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalMantValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIntereses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalCuotaSemanal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColTotalIzq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColTotalDer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtColTotalIzq2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblNombre As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCodigo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtFechaPago As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNumCuota As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNombreApellidos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaDesembolso As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaPrimerPago As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaVencimiento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuotas As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTasaInteres As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTasaMantValor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoCor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoDol As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtAmortizacion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMantValor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtIntereses As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuotaSemanal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSaldo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalAmortizacion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalMantValor As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalIntereses As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalCuotaSemanal As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtColTotalIzq As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtColTotalDer As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtColTotalIzq2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtGrupoSolidario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
End Class
