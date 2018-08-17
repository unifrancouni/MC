<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSccEstadoCuentaResumen
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSccEstadoCuentaResumen))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblCodigoRpt = New DataDynamics.ActiveReports.Label
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.lblAnulada = New DataDynamics.ActiveReports.Label
        Me.lblNumero = New DataDynamics.ActiveReports.Label
        Me.shpEncabezado = New DataDynamics.ActiveReports.Shape
        Me.lblItem = New DataDynamics.ActiveReports.Label
        Me.lblNombres = New DataDynamics.ActiveReports.Label
        Me.lblMontoP = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.lblMontoA = New DataDynamics.ActiveReports.Label
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.shpDetalles = New DataDynamics.ActiveReports.Shape
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox
        Me.txtItem = New DataDynamics.ActiveReports.TextBox
        Me.txtCedula = New DataDynamics.ActiveReports.TextBox
        Me.Line8 = New DataDynamics.ActiveReports.Line
        Me.txtMonto = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoP = New DataDynamics.ActiveReports.TextBox
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line19 = New DataDynamics.ActiveReports.Line
        Me.Line11 = New DataDynamics.ActiveReports.Line
        Me.Line12 = New DataDynamics.ActiveReports.Line
        Me.Line10 = New DataDynamics.ActiveReports.Line
        Me.txtSaldoA = New DataDynamics.ActiveReports.TextBox
        Me.txtEstado = New DataDynamics.ActiveReports.TextBox
        Me.txtNoPrestamo = New DataDynamics.ActiveReports.TextBox
        Me.Line17 = New DataDynamics.ActiveReports.Line
        Me.txtDiasAtraso = New DataDynamics.ActiveReports.TextBox
        Me.dtdUltimaFechaPagoProgramadaCancelada = New DataDynamics.ActiveReports.TextBox
        Me.Line21 = New DataDynamics.ActiveReports.Line
        Me.Line23 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtparametro = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.txtParametros = New DataDynamics.ActiveReports.TextBox
        Me.lblMensajes = New DataDynamics.ActiveReports.Label
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.grpGrupo = New DataDynamics.ActiveReports.GroupHeader
        Me.lblCedulaSocia = New DataDynamics.ActiveReports.Label
        Me.lblNombreGS = New DataDynamics.ActiveReports.Label
        Me.lblDptoGS = New DataDynamics.ActiveReports.Label
        Me.lblDistritoGS = New DataDynamics.ActiveReports.Label
        Me.lblTasaInteres = New DataDynamics.ActiveReports.Label
        Me.lblMunicipioGS = New DataDynamics.ActiveReports.Label
        Me.lblBarrioGS = New DataDynamics.ActiveReports.Label
        Me.lblTelefono = New DataDynamics.ActiveReports.Label
        Me.txtGrupo = New DataDynamics.ActiveReports.TextBox
        Me.txtDptoGS = New DataDynamics.ActiveReports.TextBox
        Me.txtMunicipioGS = New DataDynamics.ActiveReports.TextBox
        Me.txtDistritoGS = New DataDynamics.ActiveReports.TextBox
        Me.txtBarrioGS = New DataDynamics.ActiveReports.TextBox
        Me.txtTasaInteres = New DataDynamics.ActiveReports.TextBox
        Me.txtTasaMora = New DataDynamics.ActiveReports.TextBox
        Me.Line18 = New DataDynamics.ActiveReports.Line
        Me.lblMontoS = New DataDynamics.ActiveReports.Label
        Me.Line9 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.LblSaldo = New DataDynamics.ActiveReports.Label
        Me.lblFechaC = New DataDynamics.ActiveReports.Label
        Me.txtFechaD = New DataDynamics.ActiveReports.TextBox
        Me.lblFechaD = New DataDynamics.ActiveReports.Label
        Me.txtFechaC = New DataDynamics.ActiveReports.TextBox
        Me.lblNoprest = New DataDynamics.ActiveReports.Label
        Me.Line20 = New DataDynamics.ActiveReports.Line
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Line22 = New DataDynamics.ActiveReports.Line
        Me.Line24 = New DataDynamics.ActiveReports.Line
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Line25 = New DataDynamics.ActiveReports.Line
        Me.txtPlazo = New DataDynamics.ActiveReports.TextBox
        Me.txtnPlazoAprobado = New DataDynamics.ActiveReports.TextBox
        Me.lblFormaPago = New DataDynamics.ActiveReports.Label
        Me.Line26 = New DataDynamics.ActiveReports.Line
        Me.txtlFormaPago = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.lblCargoPrimeraFirma = New DataDynamics.ActiveReports.Label
        Me.lblFirmaA = New DataDynamics.ActiveReports.Label
        Me.lblTotal = New DataDynamics.ActiveReports.Label
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.Line14 = New DataDynamics.ActiveReports.Line
        Me.Line15 = New DataDynamics.ActiveReports.Line
        Me.picFirmaNotificador = New DataDynamics.ActiveReports.Picture
        Me.txtTotalA = New DataDynamics.ActiveReports.TextBox
        Me.txtTotalP = New DataDynamics.ActiveReports.TextBox
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblObservaciones = New DataDynamics.ActiveReports.Label
        Me.Line13 = New DataDynamics.ActiveReports.Line
        Me.txtTotalSaldo = New DataDynamics.ActiveReports.TextBox
        Me.Line16 = New DataDynamics.ActiveReports.Line
        CType(Me.lblCodigoRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasAtraso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtdUltimaFechaPagoProgramadaCancelada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMensajes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedulaSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDptoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistritoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTasaInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBarrioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDptoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistritoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarrioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTasaInteres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTasaMora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LblSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoprest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtnPlazoAprobado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtlFormaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoPrimeraFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFirmaNotificador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReporte, Me.lblCodigoRpt, Me.lblTitulo, Me.lblAnulada, Me.lblNumero})
        Me.PageHeader1.Height = 1.697917!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.SubReporte.Top = 0.0!
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
        Me.lblCodigoRpt.Left = 5.5625!
        Me.lblCodigoRpt.Name = "lblCodigoRpt"
        Me.lblCodigoRpt.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.lblCodigoRpt.Text = "CC38"
        Me.lblCodigoRpt.Top = 0.125!
        Me.lblCodigoRpt.Width = 0.8125!
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
        Me.lblTitulo.Height = 0.3125!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.0!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; verti" & _
            "cal-align: middle; "
        Me.lblTitulo.Text = "ESTADO DE CUENTA RESUMEN POR GRUPO SOLIDARIO"
        Me.lblTitulo.Top = 0.9375!
        Me.lblTitulo.Width = 7.4375!
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
        Me.lblAnulada.Left = 6.25!
        Me.lblAnulada.Name = "lblAnulada"
        Me.lblAnulada.Style = "color: Crimson; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 14.25pt; font-family: Arial Rounded MT Bold; vertical-align: middle; "
        Me.lblAnulada.Text = "ANULADO"
        Me.lblAnulada.Top = 1.1875!
        Me.lblAnulada.Visible = False
        Me.lblAnulada.Width = 1.1875!
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
        Me.lblNumero.Height = 0.3125!
        Me.lblNumero.HyperLink = Nothing
        Me.lblNumero.Left = 0.0!
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Style = "color: Navy; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 1" & _
            "2pt; vertical-align: middle; "
        Me.lblNumero.Text = "No. 1"
        Me.lblNumero.Top = 1.1875!
        Me.lblNumero.Width = 7.4375!
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
        Me.shpEncabezado.Height = 0.3125!
        Me.shpEncabezado.Left = 0.0!
        Me.shpEncabezado.Name = "shpEncabezado"
        Me.shpEncabezado.RoundingRadius = 9.999999!
        Me.shpEncabezado.Top = 1.5625!
        Me.shpEncabezado.Width = 7.375!
        '
        'lblItem
        '
        Me.lblItem.Border.BottomColor = System.Drawing.Color.Black
        Me.lblItem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblItem.Border.LeftColor = System.Drawing.Color.Black
        Me.lblItem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblItem.Border.RightColor = System.Drawing.Color.Black
        Me.lblItem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblItem.Border.TopColor = System.Drawing.Color.Black
        Me.lblItem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblItem.Height = 0.1875!
        Me.lblItem.HyperLink = Nothing
        Me.lblItem.Left = 0.0!
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItem.Text = "No."
        Me.lblItem.Top = 1.625!
        Me.lblItem.Width = 0.25!
        '
        'lblNombres
        '
        Me.lblNombres.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombres.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombres.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombres.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombres.Height = 0.1875!
        Me.lblNombres.HyperLink = Nothing
        Me.lblNombres.Left = 0.3125!
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblNombres.Text = "Nombre de la Socia"
        Me.lblNombres.Top = 1.625!
        Me.lblNombres.Width = 1.6875!
        '
        'lblMontoP
        '
        Me.lblMontoP.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoP.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoP.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoP.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoP.Height = 0.3125!
        Me.lblMontoP.HyperLink = Nothing
        Me.lblMontoP.Left = 4.75!
        Me.lblMontoP.Name = "lblMontoP"
        Me.lblMontoP.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoP.Text = "Monto       Pagado"
        Me.lblMontoP.Top = 1.5625!
        Me.lblMontoP.Width = 0.8125!
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
        Me.Line3.Left = 4.75!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.5625!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 4.75!
        Me.Line3.X2 = 4.75!
        Me.Line3.Y1 = 1.5625!
        Me.Line3.Y2 = 1.875!
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
        Me.Line4.Left = 3.125!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.5625!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 3.125!
        Me.Line4.X2 = 3.125!
        Me.Line4.Y1 = 1.5625!
        Me.Line4.Y2 = 1.875!
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
        Me.Line6.Height = 0.3125!
        Me.Line6.Left = 0.25!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 1.5625!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 0.25!
        Me.Line6.X2 = 0.25!
        Me.Line6.Y1 = 1.5625!
        Me.Line6.Y2 = 1.875!
        '
        'lblMontoA
        '
        Me.lblMontoA.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoA.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoA.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoA.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoA.Height = 0.3125!
        Me.lblMontoA.HyperLink = Nothing
        Me.lblMontoA.Left = 4.0!
        Me.lblMontoA.Name = "lblMontoA"
        Me.lblMontoA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoA.Text = "Monto          Aprobado"
        Me.lblMontoA.Top = 1.5625!
        Me.lblMontoA.Width = 0.75!
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
        Me.lblUsuario.Left = 0.0625!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.Top = 0.0!
        Me.lblUsuario.Width = 0.5!
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
        Me.txtUsuario.CanGrow = False
        Me.txtUsuario.Height = 0.1875!
        Me.txtUsuario.Left = 0.5625!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = "DESARROLLO"
        Me.txtUsuario.Top = 0.0!
        Me.txtUsuario.Width = 1.1875!
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
        Me.txtHora.CanGrow = False
        Me.txtHora.Height = 0.15!
        Me.txtHora.Left = 6.375!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
        Me.txtHora.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtHora.Text = Nothing
        Me.txtHora.Top = 0.0!
        Me.txtHora.Width = 1.0!
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
        Me.txtFecha.CanGrow = False
        Me.txtFecha.Height = 0.15!
        Me.txtFecha.Left = 5.6875!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.0!
        Me.txtFecha.Width = 0.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpDetalles, Me.txtNombre, Me.txtItem, Me.txtCedula, Me.Line8, Me.txtMonto, Me.txtMontoP, Me.Line1, Me.Line19, Me.Line11, Me.Line12, Me.Line10, Me.txtSaldoA, Me.txtEstado, Me.txtNoPrestamo, Me.Line17, Me.txtDiasAtraso, Me.dtdUltimaFechaPagoProgramadaCancelada, Me.Line21, Me.Line23})
        Me.Detail1.Height = 0.375!
        Me.Detail1.Name = "Detail1"
        '
        'shpDetalles
        '
        Me.shpDetalles.Border.BottomColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.shpDetalles.Border.LeftColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.shpDetalles.Border.RightColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.shpDetalles.Border.TopColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpDetalles.Height = 0.375!
        Me.shpDetalles.Left = 0.0!
        Me.shpDetalles.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.shpDetalles.Name = "shpDetalles"
        Me.shpDetalles.RoundingRadius = 9.999999!
        Me.shpDetalles.Top = 0.0!
        Me.shpDetalles.Width = 7.375!
        '
        'txtNombre
        '
        Me.txtNombre.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombre.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombre.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombre.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombre.CanGrow = False
        Me.txtNombre.DataField = "NombreSocia"
        Me.txtNombre.Height = 0.375!
        Me.txtNombre.Left = 0.3125!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombre.Text = Nothing
        Me.txtNombre.Top = 0.0!
        Me.txtNombre.Width = 1.6875!
        '
        'txtItem
        '
        Me.txtItem.Border.BottomColor = System.Drawing.Color.Black
        Me.txtItem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtItem.Border.LeftColor = System.Drawing.Color.Black
        Me.txtItem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtItem.Border.RightColor = System.Drawing.Color.Black
        Me.txtItem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtItem.Border.TopColor = System.Drawing.Color.Black
        Me.txtItem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtItem.CanGrow = False
        Me.txtItem.DataField = "Item"
        Me.txtItem.Height = 0.1875!
        Me.txtItem.Left = 0.0!
        Me.txtItem.MultiLine = False
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtItem.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtItem.Text = Nothing
        Me.txtItem.Top = 0.0!
        Me.txtItem.Width = 0.25!
        '
        'txtCedula
        '
        Me.txtCedula.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCedula.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCedula.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Border.RightColor = System.Drawing.Color.Black
        Me.txtCedula.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Border.TopColor = System.Drawing.Color.Black
        Me.txtCedula.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.CanGrow = False
        Me.txtCedula.DataField = "CedulaSocia"
        Me.txtCedula.Height = 0.1875!
        Me.txtCedula.Left = 2.0!
        Me.txtCedula.MultiLine = False
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCedula.Text = Nothing
        Me.txtCedula.Top = 0.0!
        Me.txtCedula.Width = 1.125!
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
        Me.Line8.Height = 0.375!
        Me.Line8.Left = 0.25!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.0!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 0.25!
        Me.Line8.X2 = 0.25!
        Me.Line8.Y1 = 0.0!
        Me.Line8.Y2 = 0.375!
        '
        'txtMonto
        '
        Me.txtMonto.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMonto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMonto.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMonto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMonto.Border.RightColor = System.Drawing.Color.Black
        Me.txtMonto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMonto.Border.TopColor = System.Drawing.Color.Black
        Me.txtMonto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMonto.CanGrow = False
        Me.txtMonto.DataField = "nMontoCreditoAprobado"
        Me.txtMonto.Height = 0.1875!
        Me.txtMonto.Left = 4.0!
        Me.txtMonto.MultiLine = False
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMonto.Text = Nothing
        Me.txtMonto.Top = 0.0!
        Me.txtMonto.Width = 0.75!
        '
        'txtMontoP
        '
        Me.txtMontoP.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoP.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoP.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoP.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoP.CanGrow = False
        Me.txtMontoP.DataField = "MontoPagado"
        Me.txtMontoP.Height = 0.1875!
        Me.txtMontoP.Left = 4.75!
        Me.txtMontoP.MultiLine = False
        Me.txtMontoP.Name = "txtMontoP"
        Me.txtMontoP.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoP.Text = Nothing
        Me.txtMontoP.Top = 0.0!
        Me.txtMontoP.Width = 0.8125!
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
        Me.Line1.Height = 0.375!
        Me.Line1.Left = 2.0!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 2.0!
        Me.Line1.X2 = 2.0!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.375!
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
        Me.Line19.Height = 0.375!
        Me.Line19.Left = 4.75!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 0.0!
        Me.Line19.Width = 0.0!
        Me.Line19.X1 = 4.75!
        Me.Line19.X2 = 4.75!
        Me.Line19.Y1 = 0.0!
        Me.Line19.Y2 = 0.375!
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
        Me.Line11.Height = 0.375!
        Me.Line11.Left = 4.0!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.0!
        Me.Line11.Width = 0.0!
        Me.Line11.X1 = 4.0!
        Me.Line11.X2 = 4.0!
        Me.Line11.Y1 = 0.0!
        Me.Line11.Y2 = 0.375!
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
        Me.Line12.Height = 0.375!
        Me.Line12.Left = 3.125!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 0.0!
        Me.Line12.Width = 0.0!
        Me.Line12.X1 = 3.125!
        Me.Line12.X2 = 3.125!
        Me.Line12.Y1 = 0.0!
        Me.Line12.Y2 = 0.375!
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
        Me.Line10.Height = 0.375!
        Me.Line10.Left = 5.5625!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.0!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 5.5625!
        Me.Line10.X2 = 5.5625!
        Me.Line10.Y1 = 0.0!
        Me.Line10.Y2 = 0.375!
        '
        'txtSaldoA
        '
        Me.txtSaldoA.Border.BottomColor = System.Drawing.Color.Black
        Me.txtSaldoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldoA.Border.LeftColor = System.Drawing.Color.Black
        Me.txtSaldoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldoA.Border.RightColor = System.Drawing.Color.Black
        Me.txtSaldoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldoA.Border.TopColor = System.Drawing.Color.Black
        Me.txtSaldoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldoA.CanGrow = False
        Me.txtSaldoA.DataField = "SaldoActual"
        Me.txtSaldoA.Height = 0.1875!
        Me.txtSaldoA.Left = 5.5625!
        Me.txtSaldoA.MultiLine = False
        Me.txtSaldoA.Name = "txtSaldoA"
        Me.txtSaldoA.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtSaldoA.Text = Nothing
        Me.txtSaldoA.Top = 0.0!
        Me.txtSaldoA.Width = 0.6875!
        '
        'txtEstado
        '
        Me.txtEstado.Border.BottomColor = System.Drawing.Color.Black
        Me.txtEstado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEstado.Border.LeftColor = System.Drawing.Color.Black
        Me.txtEstado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEstado.Border.RightColor = System.Drawing.Color.Black
        Me.txtEstado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEstado.Border.TopColor = System.Drawing.Color.Black
        Me.txtEstado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEstado.CanGrow = False
        Me.txtEstado.DataField = "EstadoCredito"
        Me.txtEstado.Height = 0.1875!
        Me.txtEstado.Left = 3.5625!
        Me.txtEstado.MultiLine = False
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtEstado.Text = Nothing
        Me.txtEstado.Top = 0.0!
        Me.txtEstado.Width = 0.4375!
        '
        'txtNoPrestamo
        '
        Me.txtNoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.txtNoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNoPrestamo.DataField = "NoPrestamo"
        Me.txtNoPrestamo.Height = 0.1875!
        Me.txtNoPrestamo.Left = 3.125!
        Me.txtNoPrestamo.Name = "txtNoPrestamo"
        Me.txtNoPrestamo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNoPrestamo.Text = Nothing
        Me.txtNoPrestamo.Top = 0.0!
        Me.txtNoPrestamo.Width = 0.4375!
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
        Me.Line17.Height = 0.375!
        Me.Line17.Left = 3.5625!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.0!
        Me.Line17.Width = 0.0!
        Me.Line17.X1 = 3.5625!
        Me.Line17.X2 = 3.5625!
        Me.Line17.Y1 = 0.0!
        Me.Line17.Y2 = 0.375!
        '
        'txtDiasAtraso
        '
        Me.txtDiasAtraso.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDiasAtraso.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiasAtraso.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDiasAtraso.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiasAtraso.Border.RightColor = System.Drawing.Color.Black
        Me.txtDiasAtraso.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiasAtraso.Border.TopColor = System.Drawing.Color.Black
        Me.txtDiasAtraso.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDiasAtraso.DataField = "DiasAtraso"
        Me.txtDiasAtraso.Height = 0.1875!
        Me.txtDiasAtraso.Left = 7.0!
        Me.txtDiasAtraso.Name = "txtDiasAtraso"
        Me.txtDiasAtraso.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.txtDiasAtraso.Text = Nothing
        Me.txtDiasAtraso.Top = 0.0625!
        Me.txtDiasAtraso.Width = 0.375!
        '
        'dtdUltimaFechaPagoProgramadaCancelada
        '
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.BottomColor = System.Drawing.Color.Black
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.LeftColor = System.Drawing.Color.Black
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.RightColor = System.Drawing.Color.Black
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.TopColor = System.Drawing.Color.Black
        Me.dtdUltimaFechaPagoProgramadaCancelada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.dtdUltimaFechaPagoProgramadaCancelada.DataField = "dUltimaFechaPagoProgramadaCancelada"
        Me.dtdUltimaFechaPagoProgramadaCancelada.Height = 0.1875!
        Me.dtdUltimaFechaPagoProgramadaCancelada.Left = 6.25!
        Me.dtdUltimaFechaPagoProgramadaCancelada.Name = "dtdUltimaFechaPagoProgramadaCancelada"
        Me.dtdUltimaFechaPagoProgramadaCancelada.OutputFormat = resources.GetString("dtdUltimaFechaPagoProgramadaCancelada.OutputFormat")
        Me.dtdUltimaFechaPagoProgramadaCancelada.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; "
        Me.dtdUltimaFechaPagoProgramadaCancelada.Text = Nothing
        Me.dtdUltimaFechaPagoProgramadaCancelada.Top = 0.0!
        Me.dtdUltimaFechaPagoProgramadaCancelada.Width = 0.625!
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
        Me.Line21.Height = 0.375!
        Me.Line21.Left = 6.25!
        Me.Line21.LineWeight = 1.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 0.0!
        Me.Line21.Width = 0.0!
        Me.Line21.X1 = 6.25!
        Me.Line21.X2 = 6.25!
        Me.Line21.Y1 = 0.0!
        Me.Line21.Y2 = 0.375!
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
        Me.Line23.Height = 0.375!
        Me.Line23.Left = 6.875!
        Me.Line23.LineWeight = 1.0!
        Me.Line23.Name = "Line23"
        Me.Line23.Top = 0.0!
        Me.Line23.Width = 0.0!
        Me.Line23.X1 = 6.875!
        Me.Line23.X2 = 6.875!
        Me.Line23.Y1 = 0.375!
        Me.Line23.Y2 = 0.0!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtparametro, Me.ReportInfo1, Me.Line5, Me.txtParametros, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora, Me.lblMensajes})
        Me.PageFooter1.Height = 0.4166667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtparametro
        '
        Me.txtparametro.Border.BottomColor = System.Drawing.Color.Black
        Me.txtparametro.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro.Border.LeftColor = System.Drawing.Color.Black
        Me.txtparametro.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro.Border.RightColor = System.Drawing.Color.Black
        Me.txtparametro.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro.Border.TopColor = System.Drawing.Color.Black
        Me.txtparametro.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro.CanGrow = False
        Me.txtparametro.Height = 0.1875!
        Me.txtparametro.Left = 0.0625!
        Me.txtparametro.Name = "txtparametro"
        Me.txtparametro.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro.Text = Nothing
        Me.txtparametro.Top = 0.0!
        Me.txtparametro.Visible = False
        Me.txtparametro.Width = 0.125!
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
        Me.ReportInfo1.CanGrow = False
        Me.ReportInfo1.FormatString = "{PageNumber} de {PageCount}"
        Me.ReportInfo1.Height = 0.1875!
        Me.ReportInfo1.Left = 3.0!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Width = 1.9375!
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
        'txtParametros
        '
        Me.txtParametros.Border.BottomColor = System.Drawing.Color.Black
        Me.txtParametros.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros.Border.LeftColor = System.Drawing.Color.Black
        Me.txtParametros.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros.Border.RightColor = System.Drawing.Color.Black
        Me.txtParametros.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros.Border.TopColor = System.Drawing.Color.Black
        Me.txtParametros.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros.Height = 0.1875!
        Me.txtParametros.Left = 0.0625!
        Me.txtParametros.Name = "txtParametros"
        Me.txtParametros.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtParametros.Text = "Parámetros:"
        Me.txtParametros.Top = 0.0!
        Me.txtParametros.Visible = False
        Me.txtParametros.Width = 0.125!
        '
        'lblMensajes
        '
        Me.lblMensajes.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMensajes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMensajes.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMensajes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMensajes.Border.RightColor = System.Drawing.Color.Black
        Me.lblMensajes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMensajes.Border.TopColor = System.Drawing.Color.Black
        Me.lblMensajes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMensajes.Height = 0.1875!
        Me.lblMensajes.HyperLink = Nothing
        Me.lblMensajes.Left = 0.0625!
        Me.lblMensajes.Name = "lblMensajes"
        Me.lblMensajes.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.lblMensajes.Text = "Canc.: Cancelado ; Días Atraso: Sumatoria total de días atrasados acumulados dura" & _
            "nte el crédito"
        Me.lblMensajes.Top = 0.1875!
        Me.lblMensajes.Width = 7.4375!
        '
        'EncabezadoReporte
        '
        Me.EncabezadoReporte.Height = 0.0!
        Me.EncabezadoReporte.Name = "EncabezadoReporte"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'grpGrupo
        '
        Me.grpGrupo.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpEncabezado, Me.lblNombres, Me.lblItem, Me.lblCedulaSocia, Me.lblMontoP, Me.Line6, Me.lblMontoA, Me.lblNombreGS, Me.lblDptoGS, Me.lblDistritoGS, Me.lblTasaInteres, Me.lblMunicipioGS, Me.lblBarrioGS, Me.lblTelefono, Me.txtGrupo, Me.txtDptoGS, Me.txtMunicipioGS, Me.txtDistritoGS, Me.txtBarrioGS, Me.txtTasaInteres, Me.txtTasaMora, Me.Line18, Me.lblMontoS, Me.Line3, Me.Line9, Me.Line4, Me.Line2, Me.LblSaldo, Me.lblFechaC, Me.txtFechaD, Me.lblFechaD, Me.txtFechaC, Me.lblNoprest, Me.Line20, Me.Label1, Me.Label2, Me.Line22, Me.Line24, Me.Label3, Me.Line25, Me.txtPlazo, Me.txtnPlazoAprobado, Me.lblFormaPago, Me.Line26, Me.txtlFormaPago})
        Me.grpGrupo.DataField = "nSclFichaNotificacionID"
        Me.grpGrupo.Height = 1.885417!
        Me.grpGrupo.Name = "grpGrupo"
        '
        'lblCedulaSocia
        '
        Me.lblCedulaSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCedulaSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCedulaSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaSocia.Border.RightColor = System.Drawing.Color.Black
        Me.lblCedulaSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaSocia.Border.TopColor = System.Drawing.Color.Black
        Me.lblCedulaSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaSocia.Height = 0.1875!
        Me.lblCedulaSocia.HyperLink = Nothing
        Me.lblCedulaSocia.Left = 2.0!
        Me.lblCedulaSocia.Name = "lblCedulaSocia"
        Me.lblCedulaSocia.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblCedulaSocia.Text = "Cédula"
        Me.lblCedulaSocia.Top = 1.625!
        Me.lblCedulaSocia.Width = 1.125!
        '
        'lblNombreGS
        '
        Me.lblNombreGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombreGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombreGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombreGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombreGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreGS.Height = 0.1875!
        Me.lblNombreGS.HyperLink = Nothing
        Me.lblNombreGS.Left = 0.125!
        Me.lblNombreGS.Name = "lblNombreGS"
        Me.lblNombreGS.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblNombreGS.Text = "Grupo Solidario:"
        Me.lblNombreGS.Top = 0.0!
        Me.lblNombreGS.Width = 1.875!
        '
        'lblDptoGS
        '
        Me.lblDptoGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDptoGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDptoGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDptoGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDptoGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblDptoGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDptoGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblDptoGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDptoGS.Height = 0.1875!
        Me.lblDptoGS.HyperLink = Nothing
        Me.lblDptoGS.Left = 0.125!
        Me.lblDptoGS.Name = "lblDptoGS"
        Me.lblDptoGS.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblDptoGS.Text = "Departamento:"
        Me.lblDptoGS.Top = 0.25!
        Me.lblDptoGS.Width = 1.875!
        '
        'lblDistritoGS
        '
        Me.lblDistritoGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDistritoGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistritoGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDistritoGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistritoGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblDistritoGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistritoGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblDistritoGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistritoGS.Height = 0.1875!
        Me.lblDistritoGS.HyperLink = Nothing
        Me.lblDistritoGS.Left = 0.125!
        Me.lblDistritoGS.Name = "lblDistritoGS"
        Me.lblDistritoGS.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblDistritoGS.Text = "Distrito:"
        Me.lblDistritoGS.Top = 0.5!
        Me.lblDistritoGS.Width = 1.875!
        '
        'lblTasaInteres
        '
        Me.lblTasaInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTasaInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTasaInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTasaInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTasaInteres.Border.RightColor = System.Drawing.Color.Black
        Me.lblTasaInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTasaInteres.Border.TopColor = System.Drawing.Color.Black
        Me.lblTasaInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTasaInteres.Height = 0.1875!
        Me.lblTasaInteres.HyperLink = Nothing
        Me.lblTasaInteres.Left = 0.125!
        Me.lblTasaInteres.Name = "lblTasaInteres"
        Me.lblTasaInteres.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblTasaInteres.Text = "Tasa Interes Corriente Anual:"
        Me.lblTasaInteres.Top = 0.75!
        Me.lblTasaInteres.Width = 1.875!
        '
        'lblMunicipioGS
        '
        Me.lblMunicipioGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMunicipioGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipioGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMunicipioGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipioGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblMunicipioGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipioGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblMunicipioGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipioGS.Height = 0.1875!
        Me.lblMunicipioGS.HyperLink = Nothing
        Me.lblMunicipioGS.Left = 4.0625!
        Me.lblMunicipioGS.Name = "lblMunicipioGS"
        Me.lblMunicipioGS.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblMunicipioGS.Text = "Municipio:"
        Me.lblMunicipioGS.Top = 0.25!
        Me.lblMunicipioGS.Width = 1.25!
        '
        'lblBarrioGS
        '
        Me.lblBarrioGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblBarrioGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrioGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblBarrioGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrioGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblBarrioGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrioGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblBarrioGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrioGS.Height = 0.1875!
        Me.lblBarrioGS.HyperLink = Nothing
        Me.lblBarrioGS.Left = 4.0625!
        Me.lblBarrioGS.Name = "lblBarrioGS"
        Me.lblBarrioGS.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblBarrioGS.Text = "Barrio:"
        Me.lblBarrioGS.Top = 0.5!
        Me.lblBarrioGS.Width = 1.25!
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
        Me.lblTelefono.Left = 4.0625!
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblTelefono.Text = "Tasa Mora Anual:"
        Me.lblTelefono.Top = 0.75!
        Me.lblTelefono.Width = 1.25!
        '
        'txtGrupo
        '
        Me.txtGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.DataField = "NombreGrupo"
        Me.txtGrupo.Height = 0.1875!
        Me.txtGrupo.Left = 2.0!
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtGrupo.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtGrupo.Text = Nothing
        Me.txtGrupo.Top = 0.0!
        Me.txtGrupo.Width = 5.375!
        '
        'txtDptoGS
        '
        Me.txtDptoGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDptoGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDptoGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDptoGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDptoGS.DataField = "Departamento"
        Me.txtDptoGS.Height = 0.1875!
        Me.txtDptoGS.Left = 2.0!
        Me.txtDptoGS.Name = "txtDptoGS"
        Me.txtDptoGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDptoGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtDptoGS.Text = Nothing
        Me.txtDptoGS.Top = 0.25!
        Me.txtDptoGS.Width = 2.0!
        '
        'txtMunicipioGS
        '
        Me.txtMunicipioGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMunicipioGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMunicipioGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMunicipioGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipioGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtMunicipioGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipioGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtMunicipioGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipioGS.DataField = "Municipio"
        Me.txtMunicipioGS.Height = 0.1875!
        Me.txtMunicipioGS.Left = 5.3125!
        Me.txtMunicipioGS.Name = "txtMunicipioGS"
        Me.txtMunicipioGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtMunicipioGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtMunicipioGS.Text = Nothing
        Me.txtMunicipioGS.Top = 0.25!
        Me.txtMunicipioGS.Width = 2.0625!
        '
        'txtDistritoGS
        '
        Me.txtDistritoGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDistritoGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistritoGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistritoGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistritoGS.DataField = "Distrito"
        Me.txtDistritoGS.Height = 0.1875!
        Me.txtDistritoGS.Left = 2.0!
        Me.txtDistritoGS.Name = "txtDistritoGS"
        Me.txtDistritoGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDistritoGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtDistritoGS.Text = Nothing
        Me.txtDistritoGS.Top = 0.5!
        Me.txtDistritoGS.Width = 2.0!
        '
        'txtBarrioGS
        '
        Me.txtBarrioGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtBarrioGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtBarrioGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtBarrioGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrioGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtBarrioGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrioGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtBarrioGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrioGS.DataField = "Barrio"
        Me.txtBarrioGS.Height = 0.1875!
        Me.txtBarrioGS.Left = 5.3125!
        Me.txtBarrioGS.Name = "txtBarrioGS"
        Me.txtBarrioGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtBarrioGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtBarrioGS.Text = Nothing
        Me.txtBarrioGS.Top = 0.5!
        Me.txtBarrioGS.Width = 2.0625!
        '
        'txtTasaInteres
        '
        Me.txtTasaInteres.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTasaInteres.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaInteres.Border.RightColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaInteres.Border.TopColor = System.Drawing.Color.Black
        Me.txtTasaInteres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaInteres.Height = 0.1875!
        Me.txtTasaInteres.Left = 2.0!
        Me.txtTasaInteres.Name = "txtTasaInteres"
        Me.txtTasaInteres.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTasaInteres.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtTasaInteres.Text = Nothing
        Me.txtTasaInteres.Top = 0.75!
        Me.txtTasaInteres.Width = 2.0!
        '
        'txtTasaMora
        '
        Me.txtTasaMora.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTasaMora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTasaMora.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTasaMora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaMora.Border.RightColor = System.Drawing.Color.Black
        Me.txtTasaMora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaMora.Border.TopColor = System.Drawing.Color.Black
        Me.txtTasaMora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTasaMora.Height = 0.1875!
        Me.txtTasaMora.Left = 5.3125!
        Me.txtTasaMora.Name = "txtTasaMora"
        Me.txtTasaMora.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTasaMora.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtTasaMora.Text = Nothing
        Me.txtTasaMora.Top = 0.75!
        Me.txtTasaMora.Width = 2.0625!
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
        Me.Line18.Height = 0.3125!
        Me.Line18.Left = 2.0!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 1.5625!
        Me.Line18.Width = 0.0!
        Me.Line18.X1 = 2.0!
        Me.Line18.X2 = 2.0!
        Me.Line18.Y1 = 1.5625!
        Me.Line18.Y2 = 1.875!
        '
        'lblMontoS
        '
        Me.lblMontoS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoS.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoS.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoS.Height = 0.3125!
        Me.lblMontoS.HyperLink = Nothing
        Me.lblMontoS.Left = 3.5625!
        Me.lblMontoS.Name = "lblMontoS"
        Me.lblMontoS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoS.Text = "Estado"
        Me.lblMontoS.Top = 1.5625!
        Me.lblMontoS.Width = 0.4375!
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
        Me.Line9.Height = 0.3125!
        Me.Line9.Left = 4.0!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 1.5625!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 4.0!
        Me.Line9.X2 = 4.0!
        Me.Line9.Y1 = 1.5625!
        Me.Line9.Y2 = 1.875!
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
        Me.Line2.Height = 0.3125!
        Me.Line2.Left = 5.5625!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.5625!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 5.5625!
        Me.Line2.X2 = 5.5625!
        Me.Line2.Y1 = 1.5625!
        Me.Line2.Y2 = 1.875!
        '
        'LblSaldo
        '
        Me.LblSaldo.Border.BottomColor = System.Drawing.Color.Black
        Me.LblSaldo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldo.Border.LeftColor = System.Drawing.Color.Black
        Me.LblSaldo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldo.Border.RightColor = System.Drawing.Color.Black
        Me.LblSaldo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldo.Border.TopColor = System.Drawing.Color.Black
        Me.LblSaldo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LblSaldo.Height = 0.3125!
        Me.LblSaldo.HyperLink = Nothing
        Me.LblSaldo.Left = 5.5625!
        Me.LblSaldo.Name = "LblSaldo"
        Me.LblSaldo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.LblSaldo.Text = "Saldo      Actual"
        Me.LblSaldo.Top = 1.5625!
        Me.LblSaldo.Width = 0.6875!
        '
        'lblFechaC
        '
        Me.lblFechaC.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaC.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaC.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaC.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaC.Height = 0.1875!
        Me.lblFechaC.HyperLink = Nothing
        Me.lblFechaC.Left = 4.0625!
        Me.lblFechaC.Name = "lblFechaC"
        Me.lblFechaC.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblFechaC.Text = "Fecha Vencimiento:"
        Me.lblFechaC.Top = 1.0!
        Me.lblFechaC.Width = 1.25!
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
        Me.txtFechaD.Left = 2.0!
        Me.txtFechaD.Name = "txtFechaD"
        Me.txtFechaD.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtFechaD.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtFechaD.Text = Nothing
        Me.txtFechaD.Top = 1.0!
        Me.txtFechaD.Width = 2.0!
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
        Me.lblFechaD.Left = 0.125!
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblFechaD.Text = "Fecha de Desembolso:"
        Me.lblFechaD.Top = 1.0!
        Me.lblFechaD.Width = 1.875!
        '
        'txtFechaC
        '
        Me.txtFechaC.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaC.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaC.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaC.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaC.DataField = "dFechaUltimoPago"
        Me.txtFechaC.Height = 0.1875!
        Me.txtFechaC.Left = 5.3125!
        Me.txtFechaC.Name = "txtFechaC"
        Me.txtFechaC.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtFechaC.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtFechaC.Text = Nothing
        Me.txtFechaC.Top = 1.0!
        Me.txtFechaC.Width = 2.0625!
        '
        'lblNoprest
        '
        Me.lblNoprest.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNoprest.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoprest.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNoprest.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoprest.Border.RightColor = System.Drawing.Color.Black
        Me.lblNoprest.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoprest.Border.TopColor = System.Drawing.Color.Black
        Me.lblNoprest.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoprest.Height = 0.3125!
        Me.lblNoprest.HyperLink = Nothing
        Me.lblNoprest.Left = 3.125!
        Me.lblNoprest.Name = "lblNoprest"
        Me.lblNoprest.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblNoprest.Text = "No                  Prest."
        Me.lblNoprest.Top = 1.5625!
        Me.lblNoprest.Width = 0.4375!
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
        Me.Line20.Height = 0.3125!
        Me.Line20.Left = 3.5625!
        Me.Line20.LineWeight = 1.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 1.5625!
        Me.Line20.Width = 0.0!
        Me.Line20.X1 = 3.5625!
        Me.Line20.X2 = 3.5625!
        Me.Line20.Y1 = 1.5625!
        Me.Line20.Y2 = 1.875!
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
        Me.Label1.Height = 0.3125!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 6.9375!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label1.Text = "Días  Atraso"
        Me.Label1.Top = 1.5625!
        Me.Label1.Width = 0.4375!
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
        Me.Label2.Height = 0.3125!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 6.25!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.Label2.Text = "Ultima Fecha C."
        Me.Label2.Top = 1.5625!
        Me.Label2.Width = 0.625!
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
        Me.Line22.Height = 0.3125!
        Me.Line22.Left = 6.25!
        Me.Line22.LineWeight = 1.0!
        Me.Line22.Name = "Line22"
        Me.Line22.Top = 1.5625!
        Me.Line22.Width = 0.0!
        Me.Line22.X1 = 6.25!
        Me.Line22.X2 = 6.25!
        Me.Line22.Y1 = 1.5625!
        Me.Line22.Y2 = 1.875!
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
        Me.Line24.Height = 0.3125!
        Me.Line24.Left = 6.875!
        Me.Line24.LineWeight = 1.0!
        Me.Line24.Name = "Line24"
        Me.Line24.Top = 1.5625!
        Me.Line24.Width = 0.0!
        Me.Line24.X1 = 6.875!
        Me.Line24.X2 = 6.875!
        Me.Line24.Y1 = 1.5625!
        Me.Line24.Y2 = 1.875!
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
        Me.Label3.Left = 0.125!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "text-align: justify; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.Label3.Text = "Plazo del crédito:"
        Me.Label3.Top = 1.25!
        Me.Label3.Width = 1.875!
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
        Me.Line25.Height = 0.0!
        Me.Line25.Left = 2.0!
        Me.Line25.LineWeight = 1.0!
        Me.Line25.Name = "Line25"
        Me.Line25.Top = 1.4375!
        Me.Line25.Width = 2.0!
        Me.Line25.X1 = 2.0!
        Me.Line25.X2 = 4.0!
        Me.Line25.Y1 = 1.4375!
        Me.Line25.Y2 = 1.4375!
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
        Me.txtPlazo.DataField = "Plazo"
        Me.txtPlazo.Height = 0.1875!
        Me.txtPlazo.Left = 2.25!
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtPlazo.Text = Nothing
        Me.txtPlazo.Top = 1.25!
        Me.txtPlazo.Width = 0.75!
        '
        'txtnPlazoAprobado
        '
        Me.txtnPlazoAprobado.Border.BottomColor = System.Drawing.Color.Black
        Me.txtnPlazoAprobado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtnPlazoAprobado.Border.LeftColor = System.Drawing.Color.Black
        Me.txtnPlazoAprobado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtnPlazoAprobado.Border.RightColor = System.Drawing.Color.Black
        Me.txtnPlazoAprobado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtnPlazoAprobado.Border.TopColor = System.Drawing.Color.Black
        Me.txtnPlazoAprobado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtnPlazoAprobado.DataField = "nPlazoAprobado"
        Me.txtnPlazoAprobado.Height = 0.1875!
        Me.txtnPlazoAprobado.Left = 2.0!
        Me.txtnPlazoAprobado.Name = "txtnPlazoAprobado"
        Me.txtnPlazoAprobado.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtnPlazoAprobado.Text = Nothing
        Me.txtnPlazoAprobado.Top = 1.25!
        Me.txtnPlazoAprobado.Width = 0.25!
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
        Me.lblFormaPago.Left = 4.0625!
        Me.lblFormaPago.Name = "lblFormaPago"
        Me.lblFormaPago.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblFormaPago.Text = "Forma de Pago:"
        Me.lblFormaPago.Top = 1.25!
        Me.lblFormaPago.Width = 1.25!
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
        Me.Line26.Height = 0.0!
        Me.Line26.Left = 5.3125!
        Me.Line26.LineWeight = 1.0!
        Me.Line26.Name = "Line26"
        Me.Line26.Top = 1.4375!
        Me.Line26.Width = 2.0625!
        Me.Line26.X1 = 5.3125!
        Me.Line26.X2 = 7.375!
        Me.Line26.Y1 = 1.4375!
        Me.Line26.Y2 = 1.4375!
        '
        'txtlFormaPago
        '
        Me.txtlFormaPago.Border.BottomColor = System.Drawing.Color.Black
        Me.txtlFormaPago.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtlFormaPago.Border.LeftColor = System.Drawing.Color.Black
        Me.txtlFormaPago.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtlFormaPago.Border.RightColor = System.Drawing.Color.Black
        Me.txtlFormaPago.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtlFormaPago.Border.TopColor = System.Drawing.Color.Black
        Me.txtlFormaPago.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtlFormaPago.DataField = "FormaPago"
        Me.txtlFormaPago.Height = 0.1979167!
        Me.txtlFormaPago.Left = 5.3125!
        Me.txtlFormaPago.Name = "txtlFormaPago"
        Me.txtlFormaPago.Style = ""
        Me.txtlFormaPago.Text = Nothing
        Me.txtlFormaPago.Top = 1.25!
        Me.txtlFormaPago.Width = 1.0!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.lblCargoPrimeraFirma, Me.lblFirmaA, Me.lblTotal, Me.Line7, Me.Line14, Me.Line15, Me.picFirmaNotificador, Me.txtTotalA, Me.txtTotalP, Me.txtObservaciones, Me.Shape1, Me.lblObservaciones, Me.Line13, Me.txtTotalSaldo, Me.Line16})
        Me.GroupFooter1.Height = 2.635417!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Shape2.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape2.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape2.Border.RightColor = System.Drawing.Color.Black
        Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape2.Border.TopColor = System.Drawing.Color.Black
        Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape2.Height = 0.21!
        Me.Shape2.Left = 0.0!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 7.375!
        '
        'lblCargoPrimeraFirma
        '
        Me.lblCargoPrimeraFirma.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCargoPrimeraFirma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoPrimeraFirma.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCargoPrimeraFirma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoPrimeraFirma.Border.RightColor = System.Drawing.Color.Black
        Me.lblCargoPrimeraFirma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoPrimeraFirma.Border.TopColor = System.Drawing.Color.Black
        Me.lblCargoPrimeraFirma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoPrimeraFirma.Height = 0.1875!
        Me.lblCargoPrimeraFirma.HyperLink = Nothing
        Me.lblCargoPrimeraFirma.Left = 1.6875!
        Me.lblCargoPrimeraFirma.Name = "lblCargoPrimeraFirma"
        Me.lblCargoPrimeraFirma.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoPrimeraFirma.Text = "Cargo A"
        Me.lblCargoPrimeraFirma.Top = 2.4375!
        Me.lblCargoPrimeraFirma.Width = 3.5!
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
        Me.lblFirmaA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFirmaA.Height = 0.1875!
        Me.lblFirmaA.HyperLink = Nothing
        Me.lblFirmaA.Left = 1.6875!
        Me.lblFirmaA.Name = "lblFirmaA"
        Me.lblFirmaA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaA.Text = "FirmaA"
        Me.lblFirmaA.Top = 2.25!
        Me.lblFirmaA.Width = 3.5!
        '
        'lblTotal
        '
        Me.lblTotal.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotal.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotal.Border.RightColor = System.Drawing.Color.Black
        Me.lblTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotal.Border.TopColor = System.Drawing.Color.Black
        Me.lblTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotal.Height = 0.125!
        Me.lblTotal.HyperLink = Nothing
        Me.lblTotal.Left = 2.0625!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; vertical" & _
            "-align: middle; "
        Me.lblTotal.Text = "TOTALES C$:"
        Me.lblTotal.Top = 0.0625!
        Me.lblTotal.Width = 1.1875!
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
        Me.Line7.Height = 0.1875!
        Me.Line7.Left = 5.5625!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.0!
        Me.Line7.Width = 0.0!
        Me.Line7.X1 = 5.5625!
        Me.Line7.X2 = 5.5625!
        Me.Line7.Y1 = 0.0!
        Me.Line7.Y2 = 0.1875!
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
        Me.Line14.Height = 0.1875!
        Me.Line14.Left = 4.75!
        Me.Line14.LineWeight = 1.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 0.0!
        Me.Line14.Width = 0.0!
        Me.Line14.X1 = 4.75!
        Me.Line14.X2 = 4.75!
        Me.Line14.Y1 = 0.0!
        Me.Line14.Y2 = 0.1875!
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
        Me.Line15.Height = 0.1875!
        Me.Line15.Left = 3.5625!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 0.0!
        Me.Line15.Width = 0.0!
        Me.Line15.X1 = 3.5625!
        Me.Line15.X2 = 3.5625!
        Me.Line15.Y1 = 0.0!
        Me.Line15.Y2 = 0.1875!
        '
        'picFirmaNotificador
        '
        Me.picFirmaNotificador.Border.BottomColor = System.Drawing.Color.Black
        Me.picFirmaNotificador.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picFirmaNotificador.Border.LeftColor = System.Drawing.Color.Black
        Me.picFirmaNotificador.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picFirmaNotificador.Border.RightColor = System.Drawing.Color.Black
        Me.picFirmaNotificador.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picFirmaNotificador.Border.TopColor = System.Drawing.Color.Black
        Me.picFirmaNotificador.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.picFirmaNotificador.Height = 0.625!
        Me.picFirmaNotificador.Image = Nothing
        Me.picFirmaNotificador.ImageData = Nothing
        Me.picFirmaNotificador.Left = 2.125!
        Me.picFirmaNotificador.LineWeight = 0.0!
        Me.picFirmaNotificador.Name = "picFirmaNotificador"
        Me.picFirmaNotificador.Top = 1.5625!
        Me.picFirmaNotificador.Width = 2.75!
        '
        'txtTotalA
        '
        Me.txtTotalA.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalA.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalA.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalA.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalA.CanGrow = False
        Me.txtTotalA.DataField = "nMontoCreditoAprobado"
        Me.txtTotalA.Height = 0.125!
        Me.txtTotalA.Left = 3.9375!
        Me.txtTotalA.Name = "txtTotalA"
        Me.txtTotalA.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalA.SummaryGroup = "grpGrupo"
        Me.txtTotalA.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalA.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalA.Text = Nothing
        Me.txtTotalA.Top = 0.0625!
        Me.txtTotalA.Width = 0.8125!
        '
        'txtTotalP
        '
        Me.txtTotalP.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalP.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalP.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalP.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalP.CanGrow = False
        Me.txtTotalP.DataField = "MontoPagado"
        Me.txtTotalP.Height = 0.125!
        Me.txtTotalP.Left = 4.75!
        Me.txtTotalP.Name = "txtTotalP"
        Me.txtTotalP.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalP.SummaryGroup = "grpGrupo"
        Me.txtTotalP.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalP.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalP.Text = Nothing
        Me.txtTotalP.Top = 0.0625!
        Me.txtTotalP.Width = 0.8125!
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
        Me.txtObservaciones.DataField = "sObservacionEC"
        Me.txtObservaciones.Height = 0.75!
        Me.txtObservaciones.Left = 0.0625!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "ddo-char-set: 0; text-align: justify; font-size: 8.25pt; "
        Me.txtObservaciones.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtObservaciones.Text = Nothing
        Me.txtObservaciones.Top = 0.5625!
        Me.txtObservaciones.Width = 7.25!
        '
        'Shape1
        '
        Me.Shape1.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape1.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape1.Border.RightColor = System.Drawing.Color.Black
        Me.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape1.Border.TopColor = System.Drawing.Color.Black
        Me.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDouble
        Me.Shape1.Height = 1.0625!
        Me.Shape1.Left = 0.0!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.375!
        Me.Shape1.Width = 7.38!
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
        Me.lblObservaciones.Left = 0.0625!
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblObservaciones.Text = "OBSERVACIONES:"
        Me.lblObservaciones.Top = 0.375!
        Me.lblObservaciones.Width = 1.5!
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
        Me.Line13.Height = 0.1875!
        Me.Line13.Left = 6.25!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 0.0!
        Me.Line13.Width = 0.0!
        Me.Line13.X1 = 6.25!
        Me.Line13.X2 = 6.25!
        Me.Line13.Y1 = 0.0!
        Me.Line13.Y2 = 0.1875!
        '
        'txtTotalSaldo
        '
        Me.txtTotalSaldo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalSaldo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalSaldo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalSaldo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalSaldo.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalSaldo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalSaldo.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalSaldo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalSaldo.CanGrow = False
        Me.txtTotalSaldo.DataField = "SaldoActual"
        Me.txtTotalSaldo.Height = 0.125!
        Me.txtTotalSaldo.Left = 5.625!
        Me.txtTotalSaldo.Name = "txtTotalSaldo"
        Me.txtTotalSaldo.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalSaldo.SummaryGroup = "grpGrupo"
        Me.txtTotalSaldo.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalSaldo.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalSaldo.Text = Nothing
        Me.txtTotalSaldo.Top = 0.0625!
        Me.txtTotalSaldo.Width = 0.625!
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
        Me.Line16.Height = 0.1875!
        Me.Line16.Left = 2.0!
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 0.0!
        Me.Line16.Width = 0.0!
        Me.Line16.X1 = 2.0!
        Me.Line16.X2 = 2.0!
        Me.Line16.Y1 = 0.0!
        Me.Line16.Y2 = 0.1875!
        '
        'rptSccEstadoCuentaResumen
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.5625!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.grpGrupo)
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
        CType(Me.lblCodigoRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasAtraso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtdUltimaFechaPagoProgramadaCancelada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMensajes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedulaSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDptoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistritoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTasaInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBarrioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDptoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistritoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarrioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTasaInteres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTasaMora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LblSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoprest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtnPlazoAprobado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtlFormaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoPrimeraFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFirmaNotificador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalSaldo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtNombre As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtItem As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtParametros As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodigoRpt As DataDynamics.ActiveReports.Label
    Friend WithEvents shpEncabezado As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblItem As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMontoA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMontoP As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents shpDetalles As DataDynamics.ActiveReports.Shape
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents grpGrupo As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblFirmaA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombreGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDptoGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDistritoGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTasaInteres As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMunicipioGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblBarrioGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents txtGrupo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDptoGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMunicipioGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDistritoGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBarrioGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTasaInteres As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTasaMora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCedulaSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents Line18 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtMonto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoP As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line19 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblCargoPrimeraFirma As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblMontoS As DataDynamics.ActiveReports.Label
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line12 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line14 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line15 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblAnulada As DataDynamics.ActiveReports.Label
    Friend WithEvents picFirmaNotificador As DataDynamics.ActiveReports.Picture
    Friend WithEvents txtTotalA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalP As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtObservaciones As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblObservaciones As DataDynamics.ActiveReports.Label
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents LblSaldo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line13 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtSaldoA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalSaldo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line16 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEstado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFechaC As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaD As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFechaD As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaC As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNoPrestamo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNoprest As DataDynamics.ActiveReports.Label
    Friend WithEvents Line17 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line20 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtDiasAtraso As DataDynamics.ActiveReports.TextBox
    Friend WithEvents dtdUltimaFechaPagoProgramadaCancelada As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line21 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line23 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line22 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line24 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblMensajes As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line25 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtnPlazoAprobado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFormaPago As DataDynamics.ActiveReports.Label
    Friend WithEvents Line26 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtlFormaPago As DataDynamics.ActiveReports.TextBox
End Class
