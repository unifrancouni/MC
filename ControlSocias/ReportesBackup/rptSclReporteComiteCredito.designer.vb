<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclReporteComiteCredito
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
    REM Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclReporteComiteCredito))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTituloI = New DataDynamics.ActiveReports.Label
        Me.lblCodRpt = New DataDynamics.ActiveReports.Label
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblTipoNegocio = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtCodSocia = New DataDynamics.ActiveReports.TextBox
        Me.txtNombreGS = New DataDynamics.ActiveReports.TextBox
        Me.txtTipoNegocio = New DataDynamics.ActiveReports.TextBox
        Me.txtCodGS = New DataDynamics.ActiveReports.TextBox
        Me.txtTexto = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoS = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoA = New DataDynamics.ActiveReports.TextBox
        Me.txtPlazoA = New DataDynamics.ActiveReports.TextBox
        Me.txtCuota = New DataDynamics.ActiveReports.TextBox
        Me.txtFormaPago = New DataDynamics.ActiveReports.TextBox
        Me.txtInteres = New DataDynamics.ActiveReports.TextBox
        Me.txtMora = New DataDynamics.ActiveReports.TextBox
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.Line22 = New DataDynamics.ActiveReports.Line
        Me.Line28 = New DataDynamics.ActiveReports.Line
        Me.Line35 = New DataDynamics.ActiveReports.Line
        Me.Line36 = New DataDynamics.ActiveReports.Line
        Me.txtNombreSocia = New DataDynamics.ActiveReports.TextBox
        Me.Line37 = New DataDynamics.ActiveReports.Line
        Me.Line38 = New DataDynamics.ActiveReports.Line
        Me.Line39 = New DataDynamics.ActiveReports.Line
        Me.txtGSId = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.rptInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Shape3 = New DataDynamics.ActiveReports.Shape
        Me.lblTotalG = New DataDynamics.ActiveReports.Label
        Me.Line29 = New DataDynamics.ActiveReports.Line
        Me.Line30 = New DataDynamics.ActiveReports.Line
        Me.Line31 = New DataDynamics.ActiveReports.Line
        Me.Line32 = New DataDynamics.ActiveReports.Line
        Me.Line33 = New DataDynamics.ActiveReports.Line
        Me.Line34 = New DataDynamics.ActiveReports.Line
        Me.txtMontoSTg = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoATg = New DataDynamics.ActiveReports.TextBox
        Me.Line26 = New DataDynamics.ActiveReports.Line
        Me.Line25 = New DataDynamics.ActiveReports.Line
        Me.Line27 = New DataDynamics.ActiveReports.Line
        Me.txtCuentaSociag = New DataDynamics.ActiveReports.TextBox
        Me.txtCuentaGSg = New DataDynamics.ActiveReports.TextBox
        Me.srptDenegados = New DataDynamics.ActiveReports.SubReport
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblDepartamento = New DataDynamics.ActiveReports.Label
        Me.lblMunicipio = New DataDynamics.ActiveReports.Label
        Me.lblItem = New DataDynamics.ActiveReports.Label
        Me.lblTexto = New DataDynamics.ActiveReports.Label
        Me.lblNombres = New DataDynamics.ActiveReports.Label
        Me.lblGrupo = New DataDynamics.ActiveReports.Label
        Me.txtDepartamento = New DataDynamics.ActiveReports.TextBox
        Me.txtMunicipio = New DataDynamics.ActiveReports.TextBox
        Me.txtGrupo = New DataDynamics.ActiveReports.TextBox
        Me.shpEncabezado = New DataDynamics.ActiveReports.Shape
        Me.lblAprobados = New DataDynamics.ActiveReports.Label
        Me.lblCondiciones = New DataDynamics.ActiveReports.Label
        Me.lblItemGS = New DataDynamics.ActiveReports.Label
        Me.lblItemSocia = New DataDynamics.ActiveReports.Label
        Me.lblGS = New DataDynamics.ActiveReports.Label
        Me.lblMontoS = New DataDynamics.ActiveReports.Label
        Me.lblMontoA = New DataDynamics.ActiveReports.Label
        Me.lblPlazoA = New DataDynamics.ActiveReports.Label
        Me.lblCuota = New DataDynamics.ActiveReports.Label
        Me.lblFormaPago = New DataDynamics.ActiveReports.Label
        Me.lblIntereses = New DataDynamics.ActiveReports.Label
        Me.lblInteres = New DataDynamics.ActiveReports.Label
        Me.lblMora = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblAprobadasGrupo = New DataDynamics.ActiveReports.Label
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.Line8 = New DataDynamics.ActiveReports.Line
        Me.Line9 = New DataDynamics.ActiveReports.Line
        Me.Line23 = New DataDynamics.ActiveReports.Line
        Me.Line24 = New DataDynamics.ActiveReports.Line
        Me.txtMontoST = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoAT = New DataDynamics.ActiveReports.TextBox
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.txtCuentaSociat = New DataDynamics.ActiveReports.TextBox
        Me.txtCuentaGSt = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.lblSubtotalGS = New DataDynamics.ActiveReports.Label
        Me.Line13 = New DataDynamics.ActiveReports.Line
        Me.Line14 = New DataDynamics.ActiveReports.Line
        Me.Line15 = New DataDynamics.ActiveReports.Line
        Me.Line16 = New DataDynamics.ActiveReports.Line
        Me.Line17 = New DataDynamics.ActiveReports.Line
        Me.Line18 = New DataDynamics.ActiveReports.Line
        Me.Line19 = New DataDynamics.ActiveReports.Line
        Me.txtMontoASt = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoSSt = New DataDynamics.ActiveReports.TextBox
        Me.Line12 = New DataDynamics.ActiveReports.Line
        Me.Line11 = New DataDynamics.ActiveReports.Line
        Me.Line10 = New DataDynamics.ActiveReports.Line
        Me.txtCuentaSocia = New DataDynamics.ActiveReports.TextBox
        Me.Line20 = New DataDynamics.ActiveReports.Line
        Me.txtCuentaGS = New DataDynamics.ActiveReports.TextBox
        Me.Line21 = New DataDynamics.ActiveReports.Line
        Me.lblFecha = New DataDynamics.ActiveReports.Label
        Me.lblFechaEntrega = New DataDynamics.ActiveReports.Label
        CType(Me.lblTituloI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTexto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGSId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rptInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoSTg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoATg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaSociag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaGSg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTexto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAprobados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCondiciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItemGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItemSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblIntereses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAprobadasGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaSociat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaGSt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubtotalGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoASt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoSSt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuentaGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaEntrega, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTituloI, Me.lblCodRpt, Me.txtCodigo, Me.SubReporte, Me.lblFecha, Me.lblFechaEntrega})
        Me.PageHeader1.Height = 1.583333!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblTituloI
        '
        Me.lblTituloI.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTituloI.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTituloI.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTituloI.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTituloI.Border.RightColor = System.Drawing.Color.Black
        Me.lblTituloI.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTituloI.Border.TopColor = System.Drawing.Color.Black
        Me.lblTituloI.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTituloI.Height = 0.2083333!
        Me.lblTituloI.HyperLink = Nothing
        Me.lblTituloI.Left = 0.0625!
        Me.lblTituloI.Name = "lblTituloI"
        Me.lblTituloI.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 11.25pt; verti" & _
            "cal-align: middle; "
        Me.lblTituloI.Text = "REPORTE DE COMITE DE CREDITO"
        Me.lblTituloI.Top = 0.8125!
        Me.lblTituloI.Width = 9.958333!
        '
        'lblCodRpt
        '
        Me.lblCodRpt.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodRpt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodRpt.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodRpt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodRpt.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodRpt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodRpt.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodRpt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodRpt.Height = 0.5!
        Me.lblCodRpt.HyperLink = Nothing
        Me.lblCodRpt.Left = 7.5625!
        Me.lblCodRpt.Name = "lblCodRpt"
        Me.lblCodRpt.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.lblCodRpt.Text = "CS12"
        Me.lblCodRpt.Top = 0.125!
        Me.lblCodRpt.Width = 0.8125!
        '
        'txtCodigo
        '
        Me.txtCodigo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigo.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigo.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigo.CanGrow = False
        Me.txtCodigo.Height = 0.1875!
        Me.txtCodigo.Left = 0.0625!
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.Top = 1.0625!
        Me.txtCodigo.Width = 9.9375!
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
        Me.SubReporte.Left = 0.0625!
        Me.SubReporte.Name = "SubReporte"
        Me.SubReporte.Report = Nothing
        Me.SubReporte.ReportName = "SubReport1"
        Me.SubReporte.Top = 0.0625!
        Me.SubReporte.Width = 9.958333!
        '
        'lblTipoNegocio
        '
        Me.lblTipoNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Height = 0.4375!
        Me.lblTipoNegocio.HyperLink = Nothing
        Me.lblTipoNegocio.Left = 4.9375!
        Me.lblTipoNegocio.Name = "lblTipoNegocio"
        Me.lblTipoNegocio.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblTipoNegocio.Text = "Plan de Inversión"
        Me.lblTipoNegocio.Top = 0.75!
        Me.lblTipoNegocio.Width = 1.25!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodSocia, Me.txtNombreGS, Me.txtTipoNegocio, Me.txtCodGS, Me.txtTexto, Me.txtMontoS, Me.txtMontoA, Me.txtPlazoA, Me.txtCuota, Me.txtFormaPago, Me.txtInteres, Me.txtMora, Me.Line6, Me.Line22, Me.Line28, Me.Line35, Me.Line36, Me.txtNombreSocia, Me.Line37, Me.Line38, Me.Line39, Me.txtGSId})
        Me.Detail1.Height = 0.4479167!
        Me.Detail1.Name = "Detail1"
        '
        'txtCodSocia
        '
        Me.txtCodSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodSocia.CanGrow = False
        Me.txtCodSocia.Height = 0.4375!
        Me.txtCodSocia.Left = 0.5625!
        Me.txtCodSocia.Name = "txtCodSocia"
        Me.txtCodSocia.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodSocia.Text = Nothing
        Me.txtCodSocia.Top = 0.0!
        Me.txtCodSocia.Width = 0.375!
        '
        'txtNombreGS
        '
        Me.txtNombreGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.CanGrow = False
        Me.txtNombreGS.DataField = "NombreGS"
        Me.txtNombreGS.Height = 0.4375!
        Me.txtNombreGS.Left = 2.1875!
        Me.txtNombreGS.Name = "txtNombreGS"
        Me.txtNombreGS.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombreGS.Text = Nothing
        Me.txtNombreGS.Top = 0.0!
        Me.txtNombreGS.Width = 1.1875!
        '
        'txtTipoNegocio
        '
        Me.txtTipoNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.CanGrow = False
        Me.txtTipoNegocio.DataField = "TipoNegocio"
        Me.txtTipoNegocio.Height = 0.4375!
        Me.txtTipoNegocio.Left = 4.9375!
        Me.txtTipoNegocio.Name = "txtTipoNegocio"
        Me.txtTipoNegocio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTipoNegocio.Text = Nothing
        Me.txtTipoNegocio.Top = 0.0!
        Me.txtTipoNegocio.Width = 1.25!
        '
        'txtCodGS
        '
        Me.txtCodGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodGS.CanGrow = False
        Me.txtCodGS.Height = 0.4375!
        Me.txtCodGS.Left = 0.125!
        Me.txtCodGS.Name = "txtCodGS"
        Me.txtCodGS.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodGS.Text = Nothing
        Me.txtCodGS.Top = 0.0!
        Me.txtCodGS.Width = 0.4375!
        '
        'txtTexto
        '
        Me.txtTexto.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTexto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTexto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.Border.RightColor = System.Drawing.Color.Black
        Me.txtTexto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.Border.TopColor = System.Drawing.Color.Black
        Me.txtTexto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.CanGrow = False
        Me.txtTexto.DataField = "Texto"
        Me.txtTexto.Height = 0.4375!
        Me.txtTexto.Left = 1.0!
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTexto.Text = Nothing
        Me.txtTexto.Top = 0.0!
        Me.txtTexto.Width = 1.1875!
        '
        'txtMontoS
        '
        Me.txtMontoS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.CanGrow = False
        Me.txtMontoS.DataField = "MontoSolicitado"
        Me.txtMontoS.Height = 0.4375!
        Me.txtMontoS.Left = 6.1875!
        Me.txtMontoS.Name = "txtMontoS"
        Me.txtMontoS.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoS.Text = Nothing
        Me.txtMontoS.Top = 0.0!
        Me.txtMontoS.Width = 0.75!
        '
        'txtMontoA
        '
        Me.txtMontoA.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoA.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoA.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoA.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoA.CanGrow = False
        Me.txtMontoA.DataField = "nMontoCreditoAprobado"
        Me.txtMontoA.Height = 0.4375!
        Me.txtMontoA.Left = 6.9375!
        Me.txtMontoA.Name = "txtMontoA"
        Me.txtMontoA.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoA.Text = Nothing
        Me.txtMontoA.Top = 0.0!
        Me.txtMontoA.Width = 0.75!
        '
        'txtPlazoA
        '
        Me.txtPlazoA.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPlazoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPlazoA.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPlazoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPlazoA.Border.RightColor = System.Drawing.Color.Black
        Me.txtPlazoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPlazoA.Border.TopColor = System.Drawing.Color.Black
        Me.txtPlazoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPlazoA.CanGrow = False
        Me.txtPlazoA.DataField = "nPlazoAprobado"
        Me.txtPlazoA.Height = 0.4375!
        Me.txtPlazoA.Left = 7.6875!
        Me.txtPlazoA.Name = "txtPlazoA"
        Me.txtPlazoA.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPlazoA.Text = Nothing
        Me.txtPlazoA.Top = 0.0!
        Me.txtPlazoA.Width = 0.625!
        '
        'txtCuota
        '
        Me.txtCuota.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuota.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuota.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuota.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuota.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuota.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuota.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuota.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuota.CanGrow = False
        Me.txtCuota.DataField = "nMontoCuota"
        Me.txtCuota.Height = 0.4375!
        Me.txtCuota.Left = 8.3125!
        Me.txtCuota.Name = "txtCuota"
        Me.txtCuota.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCuota.Text = Nothing
        Me.txtCuota.Top = 0.0!
        Me.txtCuota.Width = 0.5!
        '
        'txtFormaPago
        '
        Me.txtFormaPago.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFormaPago.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFormaPago.Border.RightColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFormaPago.Border.TopColor = System.Drawing.Color.Black
        Me.txtFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFormaPago.CanGrow = False
        Me.txtFormaPago.DataField = "sFormaPago"
        Me.txtFormaPago.Height = 0.4375!
        Me.txtFormaPago.Left = 8.8125!
        Me.txtFormaPago.Name = "txtFormaPago"
        Me.txtFormaPago.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFormaPago.Text = Nothing
        Me.txtFormaPago.Top = 0.0!
        Me.txtFormaPago.Width = 0.5!
        '
        'txtInteres
        '
        Me.txtInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.txtInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.txtInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtInteres.Border.RightColor = System.Drawing.Color.Black
        Me.txtInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtInteres.Border.TopColor = System.Drawing.Color.Black
        Me.txtInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtInteres.CanGrow = False
        Me.txtInteres.DataField = "sInteres"
        Me.txtInteres.Height = 0.4375!
        Me.txtInteres.Left = 9.3125!
        Me.txtInteres.Name = "txtInteres"
        Me.txtInteres.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtInteres.Text = Nothing
        Me.txtInteres.Top = 0.0!
        Me.txtInteres.Width = 0.375!
        '
        'txtMora
        '
        Me.txtMora.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMora.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMora.Border.RightColor = System.Drawing.Color.Black
        Me.txtMora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMora.Border.TopColor = System.Drawing.Color.Black
        Me.txtMora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMora.CanGrow = False
        Me.txtMora.DataField = "sMora"
        Me.txtMora.Height = 0.4375!
        Me.txtMora.Left = 9.6875!
        Me.txtMora.Name = "txtMora"
        Me.txtMora.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMora.Text = Nothing
        Me.txtMora.Top = 0.0!
        Me.txtMora.Width = 0.375!
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
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 0.0!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.0!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 0.0!
        Me.Line6.X2 = 0.0!
        Me.Line6.Y1 = 0.0!
        Me.Line6.Y2 = 0.0!
        '
        'Line22
        '
        Me.Line22.Border.BottomColor = System.Drawing.Color.Black
        Me.Line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Border.LeftColor = System.Drawing.Color.Black
        Me.Line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Border.RightColor = System.Drawing.Color.Black
        Me.Line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Border.TopColor = System.Drawing.Color.Black
        Me.Line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Height = 0.0!
        Me.Line22.Left = 0.9375!
        Me.Line22.LineWeight = 1.0!
        Me.Line22.Name = "Line22"
        Me.Line22.Top = 0.4375!
        Me.Line22.Width = 2.4375!
        Me.Line22.X1 = 0.9375!
        Me.Line22.X2 = 3.375!
        Me.Line22.Y1 = 0.4375!
        Me.Line22.Y2 = 0.4375!
        '
        'Line28
        '
        Me.Line28.Border.BottomColor = System.Drawing.Color.Black
        Me.Line28.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line28.Border.LeftColor = System.Drawing.Color.Black
        Me.Line28.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line28.Border.RightColor = System.Drawing.Color.Black
        Me.Line28.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line28.Border.TopColor = System.Drawing.Color.Black
        Me.Line28.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line28.Height = 0.0!
        Me.Line28.Left = 0.9375!
        Me.Line28.LineWeight = 1.0!
        Me.Line28.Name = "Line28"
        Me.Line28.Top = 0.0!
        Me.Line28.Width = 2.5625!
        Me.Line28.X1 = 0.9375!
        Me.Line28.X2 = 3.5!
        Me.Line28.Y1 = 0.0!
        Me.Line28.Y2 = 0.0!
        '
        'Line35
        '
        Me.Line35.Border.BottomColor = System.Drawing.Color.Black
        Me.Line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Border.LeftColor = System.Drawing.Color.Black
        Me.Line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Border.RightColor = System.Drawing.Color.Black
        Me.Line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Border.TopColor = System.Drawing.Color.Black
        Me.Line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Height = 0.0!
        Me.Line35.Left = 0.125!
        Me.Line35.LineWeight = 1.0!
        Me.Line35.Name = "Line35"
        Me.Line35.Top = 0.4375!
        Me.Line35.Width = 0.4375!
        Me.Line35.X1 = 0.125!
        Me.Line35.X2 = 0.5625!
        Me.Line35.Y1 = 0.4375!
        Me.Line35.Y2 = 0.4375!
        '
        'Line36
        '
        Me.Line36.Border.BottomColor = System.Drawing.Color.Black
        Me.Line36.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line36.Border.LeftColor = System.Drawing.Color.Black
        Me.Line36.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line36.Border.RightColor = System.Drawing.Color.Black
        Me.Line36.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line36.Border.TopColor = System.Drawing.Color.Black
        Me.Line36.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line36.Height = 0.0!
        Me.Line36.Left = 0.125!
        Me.Line36.LineWeight = 1.0!
        Me.Line36.Name = "Line36"
        Me.Line36.Top = 0.0!
        Me.Line36.Width = 0.4375!
        Me.Line36.X1 = 0.125!
        Me.Line36.X2 = 0.5625!
        Me.Line36.Y1 = 0.0!
        Me.Line36.Y2 = 0.0!
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.CanGrow = False
        Me.txtNombreSocia.DataField = "NombreSocia"
        Me.txtNombreSocia.Height = 0.4375!
        Me.txtNombreSocia.Left = 3.375!
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombreSocia.Text = Nothing
        Me.txtNombreSocia.Top = 0.0!
        Me.txtNombreSocia.Width = 1.5625!
        '
        'Line37
        '
        Me.Line37.Border.BottomColor = System.Drawing.Color.Black
        Me.Line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Border.LeftColor = System.Drawing.Color.Black
        Me.Line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Border.RightColor = System.Drawing.Color.Black
        Me.Line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Border.TopColor = System.Drawing.Color.Black
        Me.Line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Height = 0.4375!
        Me.Line37.Left = 2.1875!
        Me.Line37.LineWeight = 1.0!
        Me.Line37.Name = "Line37"
        Me.Line37.Top = 0.0!
        Me.Line37.Width = 0.0!
        Me.Line37.X1 = 2.1875!
        Me.Line37.X2 = 2.1875!
        Me.Line37.Y1 = 0.0!
        Me.Line37.Y2 = 0.4375!
        '
        'Line38
        '
        Me.Line38.Border.BottomColor = System.Drawing.Color.Black
        Me.Line38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Border.LeftColor = System.Drawing.Color.Black
        Me.Line38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Border.RightColor = System.Drawing.Color.Black
        Me.Line38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Border.TopColor = System.Drawing.Color.Black
        Me.Line38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Height = 0.4375!
        Me.Line38.Left = 0.125!
        Me.Line38.LineWeight = 1.0!
        Me.Line38.Name = "Line38"
        Me.Line38.Top = 0.0!
        Me.Line38.Width = 0.0!
        Me.Line38.X1 = 0.125!
        Me.Line38.X2 = 0.125!
        Me.Line38.Y1 = 0.0!
        Me.Line38.Y2 = 0.4375!
        '
        'Line39
        '
        Me.Line39.Border.BottomColor = System.Drawing.Color.Black
        Me.Line39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Border.LeftColor = System.Drawing.Color.Black
        Me.Line39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Border.RightColor = System.Drawing.Color.Black
        Me.Line39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Border.TopColor = System.Drawing.Color.Black
        Me.Line39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Height = 0.4375!
        Me.Line39.Left = 0.5625!
        Me.Line39.LineWeight = 1.0!
        Me.Line39.Name = "Line39"
        Me.Line39.Top = 0.0!
        Me.Line39.Width = 0.0!
        Me.Line39.X1 = 0.5625!
        Me.Line39.X2 = 0.5625!
        Me.Line39.Y1 = 0.0!
        Me.Line39.Y2 = 0.4375!
        '
        'txtGSId
        '
        Me.txtGSId.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGSId.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGSId.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGSId.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGSId.Border.RightColor = System.Drawing.Color.Black
        Me.txtGSId.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGSId.Border.TopColor = System.Drawing.Color.Black
        Me.txtGSId.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGSId.CanGrow = False
        Me.txtGSId.DataField = "nSclGrupoSolidarioID"
        Me.txtGSId.Height = 0.4375!
        Me.txtGSId.Left = 0.0!
        Me.txtGSId.Name = "txtGSId"
        Me.txtGSId.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtGSId.Text = Nothing
        Me.txtGSId.Top = 0.0!
        Me.txtGSId.Visible = False
        Me.txtGSId.Width = 0.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.rptInfo1, Me.Line3, Me.lblUsuario, Me.txtHora, Me.txtUsuario, Me.txtFecha})
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'rptInfo1
        '
        Me.rptInfo1.Border.BottomColor = System.Drawing.Color.Black
        Me.rptInfo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptInfo1.Border.LeftColor = System.Drawing.Color.Black
        Me.rptInfo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptInfo1.Border.RightColor = System.Drawing.Color.Black
        Me.rptInfo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptInfo1.Border.TopColor = System.Drawing.Color.Black
        Me.rptInfo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rptInfo1.FormatString = "{PageNumber} de {PageCount}"
        Me.rptInfo1.Height = 0.1875!
        Me.rptInfo1.Left = 3.125!
        Me.rptInfo1.Name = "rptInfo1"
        Me.rptInfo1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.rptInfo1.Top = 0.0625!
        Me.rptInfo1.Width = 2.5!
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
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 0.0625!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.01041667!
        Me.Line3.Width = 9.99586!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 10.05836!
        Me.Line3.Y1 = 0.01041667!
        Me.Line3.Y2 = 0.01041667!
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
        Me.lblUsuario.Height = 0.1875!
        Me.lblUsuario.HyperLink = Nothing
        Me.lblUsuario.Left = 0.1875!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.Top = 0.0625!
        Me.lblUsuario.Width = 0.5625!
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
        Me.txtHora.Left = 9.125!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
        Me.txtHora.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtHora.Text = Nothing
        Me.txtHora.Top = 0.0625!
        Me.txtHora.Width = 0.9375!
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
        Me.txtUsuario.Height = 0.1875!
        Me.txtUsuario.Left = 0.75!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.Top = 0.0625!
        Me.txtUsuario.Width = 1.75!
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
        Me.txtFecha.Left = 8.4375!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.0625!
        Me.txtFecha.Width = 0.6875!
        '
        'EncabezadoReporte
        '
        Me.EncabezadoReporte.Height = 0.0!
        Me.EncabezadoReporte.Name = "EncabezadoReporte"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.lblTotalG, Me.Line29, Me.Line30, Me.Line31, Me.Line32, Me.Line33, Me.Line34, Me.txtMontoSTg, Me.txtMontoATg, Me.Line26, Me.Line25, Me.Line27, Me.txtCuentaSociag, Me.txtCuentaGSg, Me.srptDenegados})
        Me.ReportFooter1.Height = 0.78125!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Shape3.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.RightColor = System.Drawing.Color.Black
        Me.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.TopColor = System.Drawing.Color.Black
        Me.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Height = 0.25!
        Me.Shape3.Left = 0.125!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = 9.999999!
        Me.Shape3.Top = 0.0625!
        Me.Shape3.Width = 9.9375!
        '
        'lblTotalG
        '
        Me.lblTotalG.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Border.RightColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Border.TopColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Height = 0.125!
        Me.lblTotalG.HyperLink = Nothing
        Me.lblTotalG.Left = 1.125!
        Me.lblTotalG.Name = "lblTotalG"
        Me.lblTotalG.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; vertical" & _
            "-align: middle; "
        Me.lblTotalG.Text = "TOTAL GENERAL SOLICITUDES APROBADAS"
        Me.lblTotalG.Top = 0.125!
        Me.lblTotalG.Width = 5.0625!
        '
        'Line29
        '
        Me.Line29.Border.BottomColor = System.Drawing.Color.Black
        Me.Line29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Border.LeftColor = System.Drawing.Color.Black
        Me.Line29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Border.RightColor = System.Drawing.Color.Black
        Me.Line29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Border.TopColor = System.Drawing.Color.Black
        Me.Line29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Height = 0.25!
        Me.Line29.Left = 0.9375!
        Me.Line29.LineWeight = 1.0!
        Me.Line29.Name = "Line29"
        Me.Line29.Top = 0.0625!
        Me.Line29.Width = 0.0!
        Me.Line29.X1 = 0.9375!
        Me.Line29.X2 = 0.9375!
        Me.Line29.Y1 = 0.0625!
        Me.Line29.Y2 = 0.3125!
        '
        'Line30
        '
        Me.Line30.Border.BottomColor = System.Drawing.Color.Black
        Me.Line30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Border.LeftColor = System.Drawing.Color.Black
        Me.Line30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Border.RightColor = System.Drawing.Color.Black
        Me.Line30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Border.TopColor = System.Drawing.Color.Black
        Me.Line30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Height = 0.25!
        Me.Line30.Left = 0.5625!
        Me.Line30.LineWeight = 1.0!
        Me.Line30.Name = "Line30"
        Me.Line30.Top = 0.0625!
        Me.Line30.Width = 0.0!
        Me.Line30.X1 = 0.5625!
        Me.Line30.X2 = 0.5625!
        Me.Line30.Y1 = 0.0625!
        Me.Line30.Y2 = 0.3125!
        '
        'Line31
        '
        Me.Line31.Border.BottomColor = System.Drawing.Color.Black
        Me.Line31.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line31.Border.LeftColor = System.Drawing.Color.Black
        Me.Line31.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line31.Border.RightColor = System.Drawing.Color.Black
        Me.Line31.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line31.Border.TopColor = System.Drawing.Color.Black
        Me.Line31.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line31.Height = 0.25!
        Me.Line31.Left = 8.3125!
        Me.Line31.LineWeight = 1.0!
        Me.Line31.Name = "Line31"
        Me.Line31.Top = 0.0625!
        Me.Line31.Width = 0.0!
        Me.Line31.X1 = 8.3125!
        Me.Line31.X2 = 8.3125!
        Me.Line31.Y1 = 0.0625!
        Me.Line31.Y2 = 0.3125!
        '
        'Line32
        '
        Me.Line32.Border.BottomColor = System.Drawing.Color.Black
        Me.Line32.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line32.Border.LeftColor = System.Drawing.Color.Black
        Me.Line32.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line32.Border.RightColor = System.Drawing.Color.Black
        Me.Line32.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line32.Border.TopColor = System.Drawing.Color.Black
        Me.Line32.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line32.Height = 0.25!
        Me.Line32.Left = 8.8125!
        Me.Line32.LineWeight = 1.0!
        Me.Line32.Name = "Line32"
        Me.Line32.Top = 0.0625!
        Me.Line32.Width = 0.0!
        Me.Line32.X1 = 8.8125!
        Me.Line32.X2 = 8.8125!
        Me.Line32.Y1 = 0.0625!
        Me.Line32.Y2 = 0.3125!
        '
        'Line33
        '
        Me.Line33.Border.BottomColor = System.Drawing.Color.Black
        Me.Line33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line33.Border.LeftColor = System.Drawing.Color.Black
        Me.Line33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line33.Border.RightColor = System.Drawing.Color.Black
        Me.Line33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line33.Border.TopColor = System.Drawing.Color.Black
        Me.Line33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line33.Height = 0.25!
        Me.Line33.Left = 9.3125!
        Me.Line33.LineWeight = 1.0!
        Me.Line33.Name = "Line33"
        Me.Line33.Top = 0.0625!
        Me.Line33.Width = 0.0!
        Me.Line33.X1 = 9.3125!
        Me.Line33.X2 = 9.3125!
        Me.Line33.Y1 = 0.0625!
        Me.Line33.Y2 = 0.3125!
        '
        'Line34
        '
        Me.Line34.Border.BottomColor = System.Drawing.Color.Black
        Me.Line34.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line34.Border.LeftColor = System.Drawing.Color.Black
        Me.Line34.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line34.Border.RightColor = System.Drawing.Color.Black
        Me.Line34.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line34.Border.TopColor = System.Drawing.Color.Black
        Me.Line34.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line34.Height = 0.25!
        Me.Line34.Left = 9.6875!
        Me.Line34.LineWeight = 1.0!
        Me.Line34.Name = "Line34"
        Me.Line34.Top = 0.0625!
        Me.Line34.Width = 0.0!
        Me.Line34.X1 = 9.6875!
        Me.Line34.X2 = 9.6875!
        Me.Line34.Y1 = 0.0625!
        Me.Line34.Y2 = 0.3125!
        '
        'txtMontoSTg
        '
        Me.txtMontoSTg.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoSTg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSTg.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoSTg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSTg.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoSTg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSTg.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoSTg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSTg.CanGrow = False
        Me.txtMontoSTg.DataField = "MontoSolicitado"
        Me.txtMontoSTg.Height = 0.25!
        Me.txtMontoSTg.Left = 6.1875!
        Me.txtMontoSTg.Name = "txtMontoSTg"
        Me.txtMontoSTg.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoSTg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtMontoSTg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtMontoSTg.Text = Nothing
        Me.txtMontoSTg.Top = 0.0625!
        Me.txtMontoSTg.Width = 0.75!
        '
        'txtMontoATg
        '
        Me.txtMontoATg.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoATg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoATg.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoATg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoATg.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoATg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoATg.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoATg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoATg.CanGrow = False
        Me.txtMontoATg.DataField = "nMontoCreditoAprobado"
        Me.txtMontoATg.Height = 0.25!
        Me.txtMontoATg.Left = 6.9375!
        Me.txtMontoATg.Name = "txtMontoATg"
        Me.txtMontoATg.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoATg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtMontoATg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtMontoATg.Text = Nothing
        Me.txtMontoATg.Top = 0.0625!
        Me.txtMontoATg.Width = 0.75!
        '
        'Line26
        '
        Me.Line26.Border.BottomColor = System.Drawing.Color.Black
        Me.Line26.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line26.Border.LeftColor = System.Drawing.Color.Black
        Me.Line26.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line26.Border.RightColor = System.Drawing.Color.Black
        Me.Line26.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line26.Border.TopColor = System.Drawing.Color.Black
        Me.Line26.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line26.Height = 0.25!
        Me.Line26.Left = 6.9375!
        Me.Line26.LineWeight = 1.0!
        Me.Line26.Name = "Line26"
        Me.Line26.Top = 0.0625!
        Me.Line26.Width = 0.0!
        Me.Line26.X1 = 6.9375!
        Me.Line26.X2 = 6.9375!
        Me.Line26.Y1 = 0.0625!
        Me.Line26.Y2 = 0.3125!
        '
        'Line25
        '
        Me.Line25.Border.BottomColor = System.Drawing.Color.Black
        Me.Line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Border.LeftColor = System.Drawing.Color.Black
        Me.Line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Border.RightColor = System.Drawing.Color.Black
        Me.Line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Border.TopColor = System.Drawing.Color.Black
        Me.Line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Height = 0.25!
        Me.Line25.Left = 6.1875!
        Me.Line25.LineWeight = 1.0!
        Me.Line25.Name = "Line25"
        Me.Line25.Top = 0.0625!
        Me.Line25.Width = 0.0!
        Me.Line25.X1 = 6.1875!
        Me.Line25.X2 = 6.1875!
        Me.Line25.Y1 = 0.0625!
        Me.Line25.Y2 = 0.3125!
        '
        'Line27
        '
        Me.Line27.Border.BottomColor = System.Drawing.Color.Black
        Me.Line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Border.LeftColor = System.Drawing.Color.Black
        Me.Line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Border.RightColor = System.Drawing.Color.Black
        Me.Line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Border.TopColor = System.Drawing.Color.Black
        Me.Line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Height = 0.25!
        Me.Line27.Left = 7.6875!
        Me.Line27.LineWeight = 1.0!
        Me.Line27.Name = "Line27"
        Me.Line27.Top = 0.0625!
        Me.Line27.Width = 0.0!
        Me.Line27.X1 = 7.6875!
        Me.Line27.X2 = 7.6875!
        Me.Line27.Y1 = 0.0625!
        Me.Line27.Y2 = 0.3125!
        '
        'txtCuentaSociag
        '
        Me.txtCuentaSociag.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuentaSociag.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociag.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuentaSociag.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociag.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuentaSociag.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociag.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuentaSociag.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociag.CanGrow = False
        Me.txtCuentaSociag.DataField = "nSclSociaID"
        Me.txtCuentaSociag.Height = 0.25!
        Me.txtCuentaSociag.Left = 0.5625!
        Me.txtCuentaSociag.Name = "txtCuentaSociag"
        Me.txtCuentaSociag.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtCuentaSociag.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtCuentaSociag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtCuentaSociag.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtCuentaSociag.Text = Nothing
        Me.txtCuentaSociag.Top = 0.0625!
        Me.txtCuentaSociag.Width = 0.375!
        '
        'txtCuentaGSg
        '
        Me.txtCuentaGSg.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuentaGSg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSg.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuentaGSg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSg.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuentaGSg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSg.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuentaGSg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSg.CanGrow = False
        Me.txtCuentaGSg.DataField = "CodigoGS"
        Me.txtCuentaGSg.DistinctField = "CodigoGS"
        Me.txtCuentaGSg.Height = 0.25!
        Me.txtCuentaGSg.Left = 0.125!
        Me.txtCuentaGSg.Name = "txtCuentaGSg"
        Me.txtCuentaGSg.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtCuentaGSg.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DCount
        Me.txtCuentaGSg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtCuentaGSg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtCuentaGSg.Text = Nothing
        Me.txtCuentaGSg.Top = 0.0625!
        Me.txtCuentaGSg.Width = 0.4375!
        '
        'srptDenegados
        '
        Me.srptDenegados.Border.BottomColor = System.Drawing.Color.Black
        Me.srptDenegados.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptDenegados.Border.LeftColor = System.Drawing.Color.Black
        Me.srptDenegados.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptDenegados.Border.RightColor = System.Drawing.Color.Black
        Me.srptDenegados.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptDenegados.Border.TopColor = System.Drawing.Color.Black
        Me.srptDenegados.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptDenegados.CloseBorder = False
        Me.srptDenegados.Height = 0.375!
        Me.srptDenegados.Left = 0.0!
        Me.srptDenegados.Name = "srptDenegados"
        Me.srptDenegados.Report = Nothing
        Me.srptDenegados.ReportName = "srptDenegados"
        Me.srptDenegados.Top = 0.375!
        Me.srptDenegados.Width = 10.0625!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.ColumnGroupKeepTogether = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTipoNegocio, Me.lblDepartamento, Me.lblMunicipio, Me.lblItem, Me.lblTexto, Me.lblNombres, Me.lblGrupo, Me.txtDepartamento, Me.txtMunicipio, Me.txtGrupo, Me.shpEncabezado, Me.lblAprobados, Me.lblCondiciones, Me.lblItemGS, Me.lblItemSocia, Me.lblGS, Me.lblMontoS, Me.lblMontoA, Me.lblPlazoA, Me.lblCuota, Me.lblFormaPago, Me.lblIntereses, Me.lblInteres, Me.lblMora})
        Me.GroupHeader1.DataField = "Grupo"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader1.Height = 1.1875!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
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
        Me.lblDepartamento.Left = 0.125!
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDepartamento.Text = "Departamento:"
        Me.lblDepartamento.Top = 0.0625!
        Me.lblDepartamento.Width = 0.9375!
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
        Me.lblMunicipio.Left = 3.25!
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.Top = 0.0625!
        Me.lblMunicipio.Width = 0.6875!
        '
        'lblItem
        '
        Me.lblItem.Border.BottomColor = System.Drawing.Color.Black
        Me.lblItem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Border.LeftColor = System.Drawing.Color.Black
        Me.lblItem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Border.RightColor = System.Drawing.Color.Black
        Me.lblItem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Border.TopColor = System.Drawing.Color.Black
        Me.lblItem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Height = 0.4375!
        Me.lblItem.HyperLink = Nothing
        Me.lblItem.Left = 0.125!
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItem.Text = "No."
        Me.lblItem.Top = 0.5625!
        Me.lblItem.Width = 0.8125!
        '
        'lblTexto
        '
        Me.lblTexto.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTexto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTexto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.Border.RightColor = System.Drawing.Color.Black
        Me.lblTexto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.Border.TopColor = System.Drawing.Color.Black
        Me.lblTexto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.DataField = "EtiquetaTexto"
        Me.lblTexto.Height = 0.625!
        Me.lblTexto.HyperLink = Nothing
        Me.lblTexto.Left = 0.9375!
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblTexto.Text = "Barrio"
        Me.lblTexto.Top = 0.5625!
        Me.lblTexto.Width = 1.25!
        '
        'lblNombres
        '
        Me.lblNombres.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Height = 0.625!
        Me.lblNombres.HyperLink = Nothing
        Me.lblNombres.Left = 3.375!
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblNombres.Text = "Nombres y Apellidos"
        Me.lblNombres.Top = 0.5625!
        Me.lblNombres.Width = 1.5625!
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
        Me.lblGrupo.DataField = "EtiquetaGrupo"
        Me.lblGrupo.Height = 0.1875!
        Me.lblGrupo.HyperLink = Nothing
        Me.lblGrupo.Left = 6.125!
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblGrupo.Text = "lblGrupo:"
        Me.lblGrupo.Top = 0.0625!
        Me.lblGrupo.Width = 0.6875!
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.RightColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.TopColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.CanGrow = False
        Me.txtDepartamento.DataField = "Departamento"
        Me.txtDepartamento.Height = 0.1875!
        Me.txtDepartamento.Left = 1.125!
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.Top = 0.0625!
        Me.txtDepartamento.Width = 2.0625!
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.RightColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.TopColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.CanGrow = False
        Me.txtMunicipio.DataField = "Municipio"
        Me.txtMunicipio.Height = 0.1875!
        Me.txtMunicipio.Left = 4.0!
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.Top = 0.0625!
        Me.txtMunicipio.Width = 2.0625!
        '
        'txtGrupo
        '
        Me.txtGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.CanGrow = False
        Me.txtGrupo.DataField = "Grupo"
        Me.txtGrupo.Height = 0.1875!
        Me.txtGrupo.Left = 6.875!
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtGrupo.Text = Nothing
        Me.txtGrupo.Top = 0.0625!
        Me.txtGrupo.Width = 3.1875!
        '
        'shpEncabezado
        '
        Me.shpEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.shpEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Height = 0.25!
        Me.shpEncabezado.Left = 0.125!
        Me.shpEncabezado.Name = "shpEncabezado"
        Me.shpEncabezado.RoundingRadius = 9.999999!
        Me.shpEncabezado.Top = 0.3125!
        Me.shpEncabezado.Width = 9.9375!
        '
        'lblAprobados
        '
        Me.lblAprobados.Border.BottomColor = System.Drawing.Color.Black
        Me.lblAprobados.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobados.Border.LeftColor = System.Drawing.Color.Black
        Me.lblAprobados.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobados.Border.RightColor = System.Drawing.Color.Black
        Me.lblAprobados.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobados.Border.TopColor = System.Drawing.Color.Black
        Me.lblAprobados.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobados.Height = 0.125!
        Me.lblAprobados.HyperLink = Nothing
        Me.lblAprobados.Left = 0.1875!
        Me.lblAprobados.Name = "lblAprobados"
        Me.lblAprobados.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblAprobados.Text = "I. PRESTAMOS APROBADOS"
        Me.lblAprobados.Top = 0.375!
        Me.lblAprobados.Width = 9.8125!
        '
        'lblCondiciones
        '
        Me.lblCondiciones.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCondiciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCondiciones.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCondiciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCondiciones.Border.RightColor = System.Drawing.Color.Black
        Me.lblCondiciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCondiciones.Border.TopColor = System.Drawing.Color.Black
        Me.lblCondiciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCondiciones.Height = 0.1875!
        Me.lblCondiciones.HyperLink = Nothing
        Me.lblCondiciones.Left = 4.9375!
        Me.lblCondiciones.Name = "lblCondiciones"
        Me.lblCondiciones.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblCondiciones.Text = "CONDICIONES DE APROBACION DEL CREDITO"
        Me.lblCondiciones.Top = 0.5625!
        Me.lblCondiciones.Width = 5.125!
        '
        'lblItemGS
        '
        Me.lblItemGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Height = 0.1875!
        Me.lblItemGS.HyperLink = Nothing
        Me.lblItemGS.Left = 0.125!
        Me.lblItemGS.Name = "lblItemGS"
        Me.lblItemGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItemGS.Text = "Grupo"
        Me.lblItemGS.Top = 1.0!
        Me.lblItemGS.Width = 0.4375!
        '
        'lblItemSocia
        '
        Me.lblItemSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Border.RightColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Border.TopColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Height = 0.1875!
        Me.lblItemSocia.HyperLink = Nothing
        Me.lblItemSocia.Left = 0.5625!
        Me.lblItemSocia.Name = "lblItemSocia"
        Me.lblItemSocia.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItemSocia.Text = "Socia"
        Me.lblItemSocia.Top = 1.0!
        Me.lblItemSocia.Width = 0.375!
        '
        'lblGS
        '
        Me.lblGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Height = 0.625!
        Me.lblGS.HyperLink = Nothing
        Me.lblGS.Left = 2.1875!
        Me.lblGS.Name = "lblGS"
        Me.lblGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblGS.Text = "Grupo Solidario"
        Me.lblGS.Top = 0.5625!
        Me.lblGS.Width = 1.1875!
        '
        'lblMontoS
        '
        Me.lblMontoS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Height = 0.4375!
        Me.lblMontoS.HyperLink = Nothing
        Me.lblMontoS.Left = 6.1875!
        Me.lblMontoS.Name = "lblMontoS"
        Me.lblMontoS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoS.Text = "Monto Solicitado (C$)"
        Me.lblMontoS.Top = 0.75!
        Me.lblMontoS.Width = 0.75!
        '
        'lblMontoA
        '
        Me.lblMontoA.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoA.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoA.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoA.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoA.Height = 0.4375!
        Me.lblMontoA.HyperLink = Nothing
        Me.lblMontoA.Left = 6.9375!
        Me.lblMontoA.Name = "lblMontoA"
        Me.lblMontoA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoA.Text = "Monto Aprobado (C$)"
        Me.lblMontoA.Top = 0.75!
        Me.lblMontoA.Width = 0.75!
        '
        'lblPlazoA
        '
        Me.lblPlazoA.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazoA.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazoA.Border.RightColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazoA.Border.TopColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblPlazoA.Height = 0.4375!
        Me.lblPlazoA.HyperLink = Nothing
        Me.lblPlazoA.Left = 7.6875!
        Me.lblPlazoA.Name = "lblPlazoA"
        Me.lblPlazoA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblPlazoA.Text = "Plazo Aprobado (Meses)"
        Me.lblPlazoA.Top = 0.75!
        Me.lblPlazoA.Width = 0.625!
        '
        'lblCuota
        '
        Me.lblCuota.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCuota.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuota.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCuota.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuota.Border.RightColor = System.Drawing.Color.Black
        Me.lblCuota.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuota.Border.TopColor = System.Drawing.Color.Black
        Me.lblCuota.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCuota.Height = 0.4375!
        Me.lblCuota.HyperLink = Nothing
        Me.lblCuota.Left = 8.3125!
        Me.lblCuota.Name = "lblCuota"
        Me.lblCuota.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblCuota.Text = "Cuota (C$)"
        Me.lblCuota.Top = 0.75!
        Me.lblCuota.Width = 0.5!
        '
        'lblFormaPago
        '
        Me.lblFormaPago.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Border.RightColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Border.TopColor = System.Drawing.Color.Black
        Me.lblFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFormaPago.Height = 0.4375!
        Me.lblFormaPago.HyperLink = Nothing
        Me.lblFormaPago.Left = 8.8125!
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblFormaPago.Text = "Forma de Pago"
        Me.lblFormaPago.Top = 0.75!
        Me.lblFormaPago.Width = 0.5!
        '
        'lblIntereses
        '
        Me.lblIntereses.Border.BottomColor = System.Drawing.Color.Black
        Me.lblIntereses.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblIntereses.Border.LeftColor = System.Drawing.Color.Black
        Me.lblIntereses.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblIntereses.Border.RightColor = System.Drawing.Color.Black
        Me.lblIntereses.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblIntereses.Border.TopColor = System.Drawing.Color.Black
        Me.lblIntereses.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblIntereses.Height = 0.1875!
        Me.lblIntereses.HyperLink = Nothing
        Me.lblIntereses.Left = 9.3125!
        Me.lblIntereses.Name = "lblIntereses"
        Me.lblIntereses.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblIntereses.Text = "INTERESES"
        Me.lblIntereses.Top = 0.75!
        Me.lblIntereses.Width = 0.75!
        '
        'lblInteres
        '
        Me.lblInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.lblInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.lblInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblInteres.Border.RightColor = System.Drawing.Color.Black
        Me.lblInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblInteres.Border.TopColor = System.Drawing.Color.Black
        Me.lblInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblInteres.Height = 0.25!
        Me.lblInteres.HyperLink = Nothing
        Me.lblInteres.Left = 9.3125!
        Me.lblInteres.Name = "lblInteres"
        Me.lblInteres.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblInteres.Text = "Ctes."
        Me.lblInteres.Top = 0.9375!
        Me.lblInteres.Width = 0.375!
        '
        'lblMora
        '
        Me.lblMora.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMora.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMora.Border.RightColor = System.Drawing.Color.Black
        Me.lblMora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMora.Border.TopColor = System.Drawing.Color.Black
        Me.lblMora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMora.Height = 0.25!
        Me.lblMora.HyperLink = Nothing
        Me.lblMora.Left = 9.6875!
        Me.lblMora.Name = "lblMora"
        Me.lblMora.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMora.Text = "Mor."
        Me.lblMora.Top = 0.9375!
        Me.lblMora.Width = 0.375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblAprobadasGrupo, Me.Line5, Me.Line7, Me.Line8, Me.Line9, Me.Line23, Me.Line24, Me.txtMontoST, Me.txtMontoAT, Me.Line2, Me.Line1, Me.Line4, Me.txtCuentaSociat, Me.txtCuentaGSt})
        Me.GroupFooter1.Height = 0.25!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Shape1.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.RightColor = System.Drawing.Color.Black
        Me.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.TopColor = System.Drawing.Color.Black
        Me.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Height = 0.25!
        Me.Shape1.Left = 0.125!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 9.9375!
        '
        'lblAprobadasGrupo
        '
        Me.lblAprobadasGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblAprobadasGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobadasGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblAprobadasGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobadasGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.lblAprobadasGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobadasGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.lblAprobadasGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAprobadasGrupo.Height = 0.125!
        Me.lblAprobadasGrupo.HyperLink = Nothing
        Me.lblAprobadasGrupo.Left = 1.125!
        Me.lblAprobadasGrupo.Name = "lblAprobadasGrupo"
        Me.lblAprobadasGrupo.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; vertical" & _
            "-align: middle; "
        Me.lblAprobadasGrupo.Text = "TOTAL SOLICITUDES APROBADAS"
        Me.lblAprobadasGrupo.Top = 0.0625!
        Me.lblAprobadasGrupo.Width = 5.0625!
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
        Me.Line5.Height = 0.25!
        Me.Line5.Left = 8.3125!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.0!
        Me.Line5.Width = 0.0!
        Me.Line5.X1 = 8.3125!
        Me.Line5.X2 = 8.3125!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.25!
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
        Me.Line7.Left = 8.8125!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.0!
        Me.Line7.Width = 0.0!
        Me.Line7.X1 = 8.8125!
        Me.Line7.X2 = 8.8125!
        Me.Line7.Y1 = 0.0!
        Me.Line7.Y2 = 0.25!
        '
        'Line8
        '
        Me.Line8.Border.BottomColor = System.Drawing.Color.Black
        Me.Line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Border.LeftColor = System.Drawing.Color.Black
        Me.Line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Border.RightColor = System.Drawing.Color.Black
        Me.Line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Border.TopColor = System.Drawing.Color.Black
        Me.Line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Height = 0.25!
        Me.Line8.Left = 9.3125!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.0!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 9.3125!
        Me.Line8.X2 = 9.3125!
        Me.Line8.Y1 = 0.0!
        Me.Line8.Y2 = 0.25!
        '
        'Line9
        '
        Me.Line9.Border.BottomColor = System.Drawing.Color.Black
        Me.Line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Border.LeftColor = System.Drawing.Color.Black
        Me.Line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Border.RightColor = System.Drawing.Color.Black
        Me.Line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Border.TopColor = System.Drawing.Color.Black
        Me.Line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Height = 0.25!
        Me.Line9.Left = 9.6875!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.0!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 9.6875!
        Me.Line9.X2 = 9.6875!
        Me.Line9.Y1 = 0.0!
        Me.Line9.Y2 = 0.25!
        '
        'Line23
        '
        Me.Line23.Border.BottomColor = System.Drawing.Color.Black
        Me.Line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Border.LeftColor = System.Drawing.Color.Black
        Me.Line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Border.RightColor = System.Drawing.Color.Black
        Me.Line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Border.TopColor = System.Drawing.Color.Black
        Me.Line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Height = 0.25!
        Me.Line23.Left = 0.9375!
        Me.Line23.LineWeight = 1.0!
        Me.Line23.Name = "Line23"
        Me.Line23.Top = 0.0!
        Me.Line23.Width = 0.0!
        Me.Line23.X1 = 0.9375!
        Me.Line23.X2 = 0.9375!
        Me.Line23.Y1 = 0.0!
        Me.Line23.Y2 = 0.25!
        '
        'Line24
        '
        Me.Line24.Border.BottomColor = System.Drawing.Color.Black
        Me.Line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Border.LeftColor = System.Drawing.Color.Black
        Me.Line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Border.RightColor = System.Drawing.Color.Black
        Me.Line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Border.TopColor = System.Drawing.Color.Black
        Me.Line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Height = 0.25!
        Me.Line24.Left = 0.5625!
        Me.Line24.LineWeight = 1.0!
        Me.Line24.Name = "Line24"
        Me.Line24.Top = 0.0!
        Me.Line24.Width = 0.0!
        Me.Line24.X1 = 0.5625!
        Me.Line24.X2 = 0.5625!
        Me.Line24.Y1 = 0.0!
        Me.Line24.Y2 = 0.25!
        '
        'txtMontoST
        '
        Me.txtMontoST.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoST.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoST.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoST.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoST.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoST.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoST.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoST.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoST.CanGrow = False
        Me.txtMontoST.DataField = "MontoSolicitado"
        Me.txtMontoST.Height = 0.25!
        Me.txtMontoST.Left = 6.1875!
        Me.txtMontoST.Name = "txtMontoST"
        Me.txtMontoST.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoST.SummaryGroup = "GroupHeader1"
        Me.txtMontoST.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMontoST.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMontoST.Text = Nothing
        Me.txtMontoST.Top = 0.0!
        Me.txtMontoST.Width = 0.75!
        '
        'txtMontoAT
        '
        Me.txtMontoAT.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoAT.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoAT.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoAT.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoAT.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoAT.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoAT.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoAT.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoAT.CanGrow = False
        Me.txtMontoAT.DataField = "nMontoCreditoAprobado"
        Me.txtMontoAT.Height = 0.25!
        Me.txtMontoAT.Left = 6.9375!
        Me.txtMontoAT.Name = "txtMontoAT"
        Me.txtMontoAT.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoAT.SummaryGroup = "GroupHeader1"
        Me.txtMontoAT.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMontoAT.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMontoAT.Text = Nothing
        Me.txtMontoAT.Top = 0.0!
        Me.txtMontoAT.Width = 0.75!
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
        Me.Line2.Height = 0.25!
        Me.Line2.Left = 6.9375!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 6.9375!
        Me.Line2.X2 = 6.9375!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.25!
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
        Me.Line1.Height = 0.25!
        Me.Line1.Left = 6.1875!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 6.1875!
        Me.Line1.X2 = 6.1875!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.25!
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
        Me.Line4.Height = 0.25!
        Me.Line4.Left = 7.6875!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.0!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 7.6875!
        Me.Line4.X2 = 7.6875!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.25!
        '
        'txtCuentaSociat
        '
        Me.txtCuentaSociat.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuentaSociat.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociat.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuentaSociat.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociat.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuentaSociat.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociat.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuentaSociat.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSociat.CanGrow = False
        Me.txtCuentaSociat.DataField = "nSclSociaID"
        Me.txtCuentaSociat.Height = 0.25!
        Me.txtCuentaSociat.Left = 0.5625!
        Me.txtCuentaSociat.Name = "txtCuentaSociat"
        Me.txtCuentaSociat.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtCuentaSociat.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtCuentaSociat.SummaryGroup = "GroupHeader1"
        Me.txtCuentaSociat.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtCuentaSociat.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtCuentaSociat.Text = Nothing
        Me.txtCuentaSociat.Top = 0.0!
        Me.txtCuentaSociat.Width = 0.375!
        '
        'txtCuentaGSt
        '
        Me.txtCuentaGSt.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuentaGSt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSt.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuentaGSt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSt.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuentaGSt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSt.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuentaGSt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGSt.CanGrow = False
        Me.txtCuentaGSt.DataField = "CodigoGS"
        Me.txtCuentaGSt.DistinctField = "CodigoGS"
        Me.txtCuentaGSt.Height = 0.25!
        Me.txtCuentaGSt.Left = 0.125!
        Me.txtCuentaGSt.Name = "txtCuentaGSt"
        Me.txtCuentaGSt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtCuentaGSt.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DCount
        Me.txtCuentaGSt.SummaryGroup = "GroupHeader1"
        Me.txtCuentaGSt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtCuentaGSt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtCuentaGSt.Text = Nothing
        Me.txtCuentaGSt.Top = 0.0!
        Me.txtCuentaGSt.Width = 0.4375!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.DataField = "CodigoGS"
        Me.GroupHeader2.Height = 0.0!
        Me.GroupHeader2.Name = "GroupHeader2"
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.lblSubtotalGS, Me.Line13, Me.Line14, Me.Line15, Me.Line16, Me.Line17, Me.Line18, Me.Line19, Me.txtMontoASt, Me.txtMontoSSt, Me.Line12, Me.Line11, Me.Line10, Me.txtCuentaSocia, Me.Line20, Me.txtCuentaGS, Me.Line21})
        Me.GroupFooter2.Height = 0.25!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Shape2.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.RightColor = System.Drawing.Color.Black
        Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.TopColor = System.Drawing.Color.Black
        Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Height = 0.25!
        Me.Shape2.Left = 0.125!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 9.9375!
        '
        'lblSubtotalGS
        '
        Me.lblSubtotalGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Height = 0.125!
        Me.lblSubtotalGS.HyperLink = Nothing
        Me.lblSubtotalGS.Left = 4.9375!
        Me.lblSubtotalGS.Name = "lblSubtotalGS"
        Me.lblSubtotalGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblSubtotalGS.Text = "SUB-TOTAL GRUPO"
        Me.lblSubtotalGS.Top = 0.0625!
        Me.lblSubtotalGS.Width = 1.25!
        '
        'Line13
        '
        Me.Line13.Border.BottomColor = System.Drawing.Color.Black
        Me.Line13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line13.Border.LeftColor = System.Drawing.Color.Black
        Me.Line13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line13.Border.RightColor = System.Drawing.Color.Black
        Me.Line13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line13.Border.TopColor = System.Drawing.Color.Black
        Me.Line13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line13.Height = 0.25!
        Me.Line13.Left = 8.3125!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 0.0!
        Me.Line13.Width = 0.0!
        Me.Line13.X1 = 8.3125!
        Me.Line13.X2 = 8.3125!
        Me.Line13.Y1 = 0.0!
        Me.Line13.Y2 = 0.25!
        '
        'Line14
        '
        Me.Line14.Border.BottomColor = System.Drawing.Color.Black
        Me.Line14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line14.Border.LeftColor = System.Drawing.Color.Black
        Me.Line14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line14.Border.RightColor = System.Drawing.Color.Black
        Me.Line14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line14.Border.TopColor = System.Drawing.Color.Black
        Me.Line14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line14.Height = 0.25!
        Me.Line14.Left = 8.8125!
        Me.Line14.LineWeight = 1.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 0.0!
        Me.Line14.Width = 0.0!
        Me.Line14.X1 = 8.8125!
        Me.Line14.X2 = 8.8125!
        Me.Line14.Y1 = 0.0!
        Me.Line14.Y2 = 0.25!
        '
        'Line15
        '
        Me.Line15.Border.BottomColor = System.Drawing.Color.Black
        Me.Line15.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line15.Border.LeftColor = System.Drawing.Color.Black
        Me.Line15.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line15.Border.RightColor = System.Drawing.Color.Black
        Me.Line15.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line15.Border.TopColor = System.Drawing.Color.Black
        Me.Line15.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line15.Height = 0.25!
        Me.Line15.Left = 9.3125!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 0.0!
        Me.Line15.Width = 0.0!
        Me.Line15.X1 = 9.3125!
        Me.Line15.X2 = 9.3125!
        Me.Line15.Y1 = 0.0!
        Me.Line15.Y2 = 0.25!
        '
        'Line16
        '
        Me.Line16.Border.BottomColor = System.Drawing.Color.Black
        Me.Line16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line16.Border.LeftColor = System.Drawing.Color.Black
        Me.Line16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line16.Border.RightColor = System.Drawing.Color.Black
        Me.Line16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line16.Border.TopColor = System.Drawing.Color.Black
        Me.Line16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line16.Height = 0.25!
        Me.Line16.Left = 9.6875!
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 0.0!
        Me.Line16.Width = 0.0!
        Me.Line16.X1 = 9.6875!
        Me.Line16.X2 = 9.6875!
        Me.Line16.Y1 = 0.0!
        Me.Line16.Y2 = 0.25!
        '
        'Line17
        '
        Me.Line17.Border.BottomColor = System.Drawing.Color.Black
        Me.Line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Border.LeftColor = System.Drawing.Color.Black
        Me.Line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Border.RightColor = System.Drawing.Color.Black
        Me.Line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Border.TopColor = System.Drawing.Color.Black
        Me.Line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Height = 0.25!
        Me.Line17.Left = 4.9375!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.0!
        Me.Line17.Width = 0.0!
        Me.Line17.X1 = 4.9375!
        Me.Line17.X2 = 4.9375!
        Me.Line17.Y1 = 0.0!
        Me.Line17.Y2 = 0.25!
        '
        'Line18
        '
        Me.Line18.Border.BottomColor = System.Drawing.Color.Black
        Me.Line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Border.LeftColor = System.Drawing.Color.Black
        Me.Line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Border.RightColor = System.Drawing.Color.Black
        Me.Line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Border.TopColor = System.Drawing.Color.Black
        Me.Line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Height = 0.25!
        Me.Line18.Left = 3.375!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 0.0!
        Me.Line18.Width = 0.0!
        Me.Line18.X1 = 3.375!
        Me.Line18.X2 = 3.375!
        Me.Line18.Y1 = 0.0!
        Me.Line18.Y2 = 0.25!
        '
        'Line19
        '
        Me.Line19.Border.BottomColor = System.Drawing.Color.Black
        Me.Line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Border.LeftColor = System.Drawing.Color.Black
        Me.Line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Border.RightColor = System.Drawing.Color.Black
        Me.Line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Border.TopColor = System.Drawing.Color.Black
        Me.Line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Height = 0.25!
        Me.Line19.Left = 2.1875!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 0.0!
        Me.Line19.Width = 0.0!
        Me.Line19.X1 = 2.1875!
        Me.Line19.X2 = 2.1875!
        Me.Line19.Y1 = 0.0!
        Me.Line19.Y2 = 0.25!
        '
        'txtMontoASt
        '
        Me.txtMontoASt.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoASt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoASt.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoASt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoASt.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoASt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoASt.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoASt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoASt.CanGrow = False
        Me.txtMontoASt.DataField = "nMontoCreditoAprobado"
        Me.txtMontoASt.Height = 0.25!
        Me.txtMontoASt.Left = 6.9375!
        Me.txtMontoASt.Name = "txtMontoASt"
        Me.txtMontoASt.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoASt.SummaryGroup = "GroupHeader2"
        Me.txtMontoASt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMontoASt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMontoASt.Text = Nothing
        Me.txtMontoASt.Top = 0.0!
        Me.txtMontoASt.Width = 0.75!
        '
        'txtMontoSSt
        '
        Me.txtMontoSSt.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoSSt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSSt.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoSSt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSSt.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoSSt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSSt.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoSSt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSSt.CanGrow = False
        Me.txtMontoSSt.DataField = "MontoSolicitado"
        Me.txtMontoSSt.Height = 0.25!
        Me.txtMontoSSt.Left = 6.1875!
        Me.txtMontoSSt.Name = "txtMontoSSt"
        Me.txtMontoSSt.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoSSt.SummaryGroup = "GroupHeader2"
        Me.txtMontoSSt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtMontoSSt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtMontoSSt.Text = Nothing
        Me.txtMontoSSt.Top = 0.0!
        Me.txtMontoSSt.Width = 0.75!
        '
        'Line12
        '
        Me.Line12.Border.BottomColor = System.Drawing.Color.Black
        Me.Line12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line12.Border.LeftColor = System.Drawing.Color.Black
        Me.Line12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line12.Border.RightColor = System.Drawing.Color.Black
        Me.Line12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line12.Border.TopColor = System.Drawing.Color.Black
        Me.Line12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line12.Height = 0.25!
        Me.Line12.Left = 7.6875!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 0.0!
        Me.Line12.Width = 0.0!
        Me.Line12.X1 = 7.6875!
        Me.Line12.X2 = 7.6875!
        Me.Line12.Y1 = 0.0!
        Me.Line12.Y2 = 0.25!
        '
        'Line11
        '
        Me.Line11.Border.BottomColor = System.Drawing.Color.Black
        Me.Line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Border.LeftColor = System.Drawing.Color.Black
        Me.Line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Border.RightColor = System.Drawing.Color.Black
        Me.Line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Border.TopColor = System.Drawing.Color.Black
        Me.Line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Height = 0.25!
        Me.Line11.Left = 6.9375!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.0!
        Me.Line11.Width = 0.0!
        Me.Line11.X1 = 6.9375!
        Me.Line11.X2 = 6.9375!
        Me.Line11.Y1 = 0.0!
        Me.Line11.Y2 = 0.25!
        '
        'Line10
        '
        Me.Line10.Border.BottomColor = System.Drawing.Color.Black
        Me.Line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Border.LeftColor = System.Drawing.Color.Black
        Me.Line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Border.RightColor = System.Drawing.Color.Black
        Me.Line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Border.TopColor = System.Drawing.Color.Black
        Me.Line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Height = 0.25!
        Me.Line10.Left = 6.1875!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.0!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 6.1875!
        Me.Line10.X2 = 6.1875!
        Me.Line10.Y1 = 0.0!
        Me.Line10.Y2 = 0.25!
        '
        'txtCuentaSocia
        '
        Me.txtCuentaSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuentaSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuentaSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuentaSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuentaSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaSocia.CanGrow = False
        Me.txtCuentaSocia.DataField = "nSclSociaID"
        Me.txtCuentaSocia.Height = 0.25!
        Me.txtCuentaSocia.Left = 0.5625!
        Me.txtCuentaSocia.Name = "txtCuentaSocia"
        Me.txtCuentaSocia.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtCuentaSocia.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtCuentaSocia.SummaryGroup = "GroupHeader2"
        Me.txtCuentaSocia.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtCuentaSocia.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtCuentaSocia.Text = Nothing
        Me.txtCuentaSocia.Top = 0.0!
        Me.txtCuentaSocia.Width = 0.375!
        '
        'Line20
        '
        Me.Line20.Border.BottomColor = System.Drawing.Color.Black
        Me.Line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Border.LeftColor = System.Drawing.Color.Black
        Me.Line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Border.RightColor = System.Drawing.Color.Black
        Me.Line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Border.TopColor = System.Drawing.Color.Black
        Me.Line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Height = 0.25!
        Me.Line20.Left = 0.9375!
        Me.Line20.LineWeight = 1.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 0.0!
        Me.Line20.Width = 0.0!
        Me.Line20.X1 = 0.9375!
        Me.Line20.X2 = 0.9375!
        Me.Line20.Y1 = 0.0!
        Me.Line20.Y2 = 0.25!
        '
        'txtCuentaGS
        '
        Me.txtCuentaGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuentaGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuentaGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuentaGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuentaGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuentaGS.CanGrow = False
        Me.txtCuentaGS.DataField = "CodigoGS"
        Me.txtCuentaGS.DistinctField = "CodigoGS"
        Me.txtCuentaGS.Height = 0.25!
        Me.txtCuentaGS.Left = 0.125!
        Me.txtCuentaGS.Name = "txtCuentaGS"
        Me.txtCuentaGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtCuentaGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DCount
        Me.txtCuentaGS.SummaryGroup = "GroupHeader2"
        Me.txtCuentaGS.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtCuentaGS.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtCuentaGS.Text = Nothing
        Me.txtCuentaGS.Top = 0.0!
        Me.txtCuentaGS.Visible = False
        Me.txtCuentaGS.Width = 0.4375!
        '
        'Line21
        '
        Me.Line21.Border.BottomColor = System.Drawing.Color.Black
        Me.Line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Border.LeftColor = System.Drawing.Color.Black
        Me.Line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Border.RightColor = System.Drawing.Color.Black
        Me.Line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Border.TopColor = System.Drawing.Color.Black
        Me.Line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Height = 0.25!
        Me.Line21.Left = 0.5625!
        Me.Line21.LineWeight = 1.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 0.0!
        Me.Line21.Width = 0.0!
        Me.Line21.X1 = 0.5625!
        Me.Line21.X2 = 0.5625!
        Me.Line21.Y1 = 0.0!
        Me.Line21.Y2 = 0.25!
        '
        'lblFecha
        '
        Me.lblFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFecha.Border.RightColor = System.Drawing.Color.Black
        Me.lblFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFecha.Border.TopColor = System.Drawing.Color.Black
        Me.lblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFecha.Height = 0.1875!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 0.125!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblFecha.Text = "Entrega de Cheques:"
        Me.lblFecha.Top = 1.3125!
        Me.lblFecha.Width = 1.3125!
        '
        'lblFechaEntrega
        '
        Me.lblFechaEntrega.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaEntrega.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaEntrega.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaEntrega.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaEntrega.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaEntrega.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaEntrega.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaEntrega.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaEntrega.DataField = "dFechaHoraEntregaCK"
        Me.lblFechaEntrega.Height = 0.1875!
        Me.lblFechaEntrega.HyperLink = Nothing
        Me.lblFechaEntrega.Left = 1.5!
        Me.lblFechaEntrega.Name = "lblFechaEntrega"
        Me.lblFechaEntrega.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 9pt; font-fami" & _
            "ly: Arial; vertical-align: middle; "
        Me.lblFechaEntrega.Text = ""
        Me.lblFechaEntrega.Top = 1.3125!
        Me.lblFechaEntrega.Width = 4.25!
        '
        'rptSclReporteComiteCredito
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.14583!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblTituloI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTexto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGSId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rptInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoSTg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoATg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaSociag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaGSg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTexto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAprobados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCondiciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItemGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItemSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCuota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblIntereses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAprobadasGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaSociat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaGSt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubtotalGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoASt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoSSt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuentaGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaEntrega, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTipoNegocio As DataDynamics.ActiveReports.Label
    Friend WithEvents rptInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblCodRpt As DataDynamics.ActiveReports.Label
    Friend WithEvents lblUsuario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblDepartamento As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMunicipio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblItem As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTexto As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipoNegocio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblGrupo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDepartamento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMunicipio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtGrupo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents shpEncabezado As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblAprobados As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCondiciones As DataDynamics.ActiveReports.Label
    Friend WithEvents lblItemGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblItemSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents lblGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMontoS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMontoA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPlazoA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCuota As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFormaPago As DataDynamics.ActiveReports.Label
    Friend WithEvents lblIntereses As DataDynamics.ActiveReports.Label
    Friend WithEvents lblInteres As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMora As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTexto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPlazoA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuota As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFormaPago As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtInteres As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblAprobadasGrupo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblSubtotalGS As DataDynamics.ActiveReports.Label
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line12 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line13 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line14 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line15 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line16 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line23 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line24 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line17 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line18 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line19 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line20 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line21 As DataDynamics.ActiveReports.Line
    Friend WithEvents Shape3 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblTotalG As DataDynamics.ActiveReports.Label
    Friend WithEvents Line25 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line26 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line27 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line29 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line30 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line31 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line32 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line33 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line34 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtMontoASt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoSSt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoST As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoAT As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoSTg As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoATg As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuentaSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuentaGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuentaSociag As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuentaGSg As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuentaSociat As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCuentaGSt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line22 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line28 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line35 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line36 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line37 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line38 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line39 As DataDynamics.ActiveReports.Line
    Friend WithEvents srptDenegados As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTituloI As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtGSId As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFechaEntrega As DataDynamics.ActiveReports.Label
End Class
