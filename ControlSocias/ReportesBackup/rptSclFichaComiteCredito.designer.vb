<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclFichaComiteCredito
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclFichaComiteCredito))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblCodigoRpt = New DataDynamics.ActiveReports.Label
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.lblNumero = New DataDynamics.ActiveReports.Label
        Me.lblAnulada = New DataDynamics.ActiveReports.Label
        Me.SubReporteFCL = New DataDynamics.ActiveReports.SubReport
        Me.shpEncabezado = New DataDynamics.ActiveReports.Shape
        Me.lblItem = New DataDynamics.ActiveReports.Label
        Me.lblNombres = New DataDynamics.ActiveReports.Label
        Me.lblPlazoA = New DataDynamics.ActiveReports.Label
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
        Me.txtPlazo = New DataDynamics.ActiveReports.TextBox
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line19 = New DataDynamics.ActiveReports.Line
        Me.txtPlazoS = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoS = New DataDynamics.ActiveReports.TextBox
        Me.Line10 = New DataDynamics.ActiveReports.Line
        Me.Line11 = New DataDynamics.ActiveReports.Line
        Me.Line12 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtparametro = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.txtParametros = New DataDynamics.ActiveReports.TextBox
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
        Me.lblRevisionE = New DataDynamics.ActiveReports.Label
        Me.lblNoSesion = New DataDynamics.ActiveReports.Label
        Me.lblFechaSesion = New DataDynamics.ActiveReports.Label
        Me.lblMontoS = New DataDynamics.ActiveReports.Label
        Me.lblPlazoS = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Line9 = New DataDynamics.ActiveReports.Line
        Me.txtFechaResolucion = New DataDynamics.ActiveReports.TextBox
        Me.txtSesion = New DataDynamics.ActiveReports.TextBox
        Me.srptExpediente = New DataDynamics.ActiveReports.SubReport
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblPie = New DataDynamics.ActiveReports.Label
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.lblObservaciones = New DataDynamics.ActiveReports.Label
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.lblCargoPrimeraFirma = New DataDynamics.ActiveReports.Label
        Me.lblFirmaA = New DataDynamics.ActiveReports.Label
        Me.lblCargoSegundaFirma = New DataDynamics.ActiveReports.Label
        Me.lblFirmaB = New DataDynamics.ActiveReports.Label
        Me.lblFirmaC = New DataDynamics.ActiveReports.Label
        Me.lblCargoTerceraFirma = New DataDynamics.ActiveReports.Label
        Me.lblTotal = New DataDynamics.ActiveReports.Label
        Me.txtTotalS = New DataDynamics.ActiveReports.TextBox
        Me.txtTotalA = New DataDynamics.ActiveReports.TextBox
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.Line14 = New DataDynamics.ActiveReports.Line
        Me.Line15 = New DataDynamics.ActiveReports.Line
        Me.Line13 = New DataDynamics.ActiveReports.Line
        CType(Me.lblCodigoRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametros, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.lblRevisionE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaResolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSesion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoPrimeraFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoSegundaFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCargoTerceraFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReporte, Me.lblCodigoRpt, Me.lblTitulo, Me.lblNumero, Me.lblAnulada, Me.SubReporteFCL})
        Me.PageHeader1.Height = 0.9895833!
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
        Me.lblCodigoRpt.Text = "CS5"
        Me.lblCodigoRpt.Top = 0.1875!
        Me.lblCodigoRpt.Width = 0.6875!
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
        Me.lblTitulo.Text = "FICHA DE COMITE DE CREDITO "
        Me.lblTitulo.Top = 0.75!
        Me.lblTitulo.Width = 7.4375!
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
        Me.lblNumero.Left = 6.0!
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Style = "color: Navy; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 1" & _
            "4.25pt; vertical-align: middle; "
        Me.lblNumero.Text = "No. 1"
        Me.lblNumero.Top = 0.625!
        Me.lblNumero.Width = 1.0!
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
        Me.lblAnulada.Height = 0.25!
        Me.lblAnulada.HyperLink = Nothing
        Me.lblAnulada.Left = 0.125!
        Me.lblAnulada.Name = "lblAnulada"
        Me.lblAnulada.Style = "color: Crimson; ddo-char-set: 0; text-align: justify; font-weight: bold; font-siz" & _
            "e: 15.75pt; font-family: Arial Rounded MT Bold; vertical-align: middle; "
        Me.lblAnulada.Text = "ANULADA"
        Me.lblAnulada.Top = 0.6875!
        Me.lblAnulada.Visible = False
        Me.lblAnulada.Width = 1.375!
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
        Me.SubReporteFCL.Height = 0.75!
        Me.SubReporteFCL.Left = 0.0625!
        Me.SubReporteFCL.Name = "SubReporteFCL"
        Me.SubReporteFCL.Report = Nothing
        Me.SubReporteFCL.ReportName = "SubReport1"
        Me.SubReporteFCL.Top = 0.0!
        Me.SubReporteFCL.Width = 7.375!
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
        Me.shpEncabezado.Top = 1.625!
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
        Me.lblItem.Top = 1.6875!
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
        Me.lblNombres.Top = 1.6875!
        Me.lblNombres.Width = 3.25!
        '
        'lblPlazoA
        '
        Me.lblPlazoA.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoA.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoA.Border.RightColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoA.Border.TopColor = System.Drawing.Color.Black
        Me.lblPlazoA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoA.Height = 0.3125!
        Me.lblPlazoA.HyperLink = Nothing
        Me.lblPlazoA.Left = 6.75!
        Me.lblPlazoA.Name = "lblPlazoA"
        Me.lblPlazoA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblPlazoA.Text = "Plazo (M)"
        Me.lblPlazoA.Top = 1.625!
        Me.lblPlazoA.Width = 0.625!
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
        Me.Line3.Left = 6.75!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 1.625!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 6.75!
        Me.Line3.X2 = 6.75!
        Me.Line3.Y1 = 1.625!
        Me.Line3.Y2 = 1.9375!
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
        Me.Line4.Left = 4.6875!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 1.625!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 4.6875!
        Me.Line4.X2 = 4.6875!
        Me.Line4.Y1 = 1.625!
        Me.Line4.Y2 = 1.9375!
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
        Me.Line6.Top = 1.625!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 0.25!
        Me.Line6.X2 = 0.25!
        Me.Line6.Y1 = 1.625!
        Me.Line6.Y2 = 1.9375!
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
        Me.lblMontoA.Left = 6.0!
        Me.lblMontoA.Name = "lblMontoA"
        Me.lblMontoA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoA.Text = "Monto Aprobado C$"
        Me.lblMontoA.Top = 1.625!
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpDetalles, Me.txtNombre, Me.txtItem, Me.txtCedula, Me.Line8, Me.txtMonto, Me.txtPlazo, Me.Line1, Me.Line19, Me.txtPlazoS, Me.txtMontoS, Me.Line10, Me.Line11, Me.Line12})
        Me.Detail1.Height = 0.1979167!
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
        Me.shpDetalles.Height = 0.2!
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
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 0.3125!
        Me.txtNombre.MultiLine = False
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombre.Text = Nothing
        Me.txtNombre.Top = 0.0!
        Me.txtNombre.Width = 3.25!
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
        Me.txtCedula.Left = 3.5625!
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
        Me.Line8.Height = 0.1875!
        Me.Line8.Left = 0.25!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.0!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 0.25!
        Me.Line8.X2 = 0.25!
        Me.Line8.Y1 = 0.0!
        Me.Line8.Y2 = 0.1875!
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
        Me.txtMonto.Height = 0.1875!
        Me.txtMonto.Left = 6.0!
        Me.txtMonto.MultiLine = False
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMonto.Text = Nothing
        Me.txtMonto.Top = 0.0!
        Me.txtMonto.Width = 0.6875!
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
        Me.txtPlazo.CanGrow = False
        Me.txtPlazo.Height = 0.1875!
        Me.txtPlazo.Left = 6.75!
        Me.txtPlazo.MultiLine = False
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPlazo.Text = Nothing
        Me.txtPlazo.Top = 0.0!
        Me.txtPlazo.Width = 0.625!
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
        Me.Line1.Height = 0.1875!
        Me.Line1.Left = 3.5625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 3.5625!
        Me.Line1.X2 = 3.5625!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.1875!
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
        Me.Line19.Height = 0.1875!
        Me.Line19.Left = 6.75!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 0.0!
        Me.Line19.Width = 0.0!
        Me.Line19.X1 = 6.75!
        Me.Line19.X2 = 6.75!
        Me.Line19.Y1 = 0.0!
        Me.Line19.Y2 = 0.1875!
        '
        'txtPlazoS
        '
        Me.txtPlazoS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPlazoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPlazoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoS.Border.RightColor = System.Drawing.Color.Black
        Me.txtPlazoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoS.Border.TopColor = System.Drawing.Color.Black
        Me.txtPlazoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoS.CanGrow = False
        Me.txtPlazoS.DataField = "nPlazoSolicitado"
        Me.txtPlazoS.Height = 0.1875!
        Me.txtPlazoS.Left = 5.5!
        Me.txtPlazoS.MultiLine = False
        Me.txtPlazoS.Name = "txtPlazoS"
        Me.txtPlazoS.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPlazoS.Text = Nothing
        Me.txtPlazoS.Top = 0.0!
        Me.txtPlazoS.Width = 0.5!
        '
        'txtMontoS
        '
        Me.txtMontoS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoS.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoS.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoS.CanGrow = False
        Me.txtMontoS.DataField = "nMontoCreditoSolicitado"
        Me.txtMontoS.Height = 0.1875!
        Me.txtMontoS.Left = 4.6875!
        Me.txtMontoS.MultiLine = False
        Me.txtMontoS.Name = "txtMontoS"
        Me.txtMontoS.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoS.Text = Nothing
        Me.txtMontoS.Top = 0.0!
        Me.txtMontoS.Width = 0.75!
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
        Me.Line10.Height = 0.1875!
        Me.Line10.Left = 6.0!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.0!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 6.0!
        Me.Line10.X2 = 6.0!
        Me.Line10.Y1 = 0.0!
        Me.Line10.Y2 = 0.1875!
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
        Me.Line11.Height = 0.1875!
        Me.Line11.Left = 5.5!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.0!
        Me.Line11.Width = 0.0!
        Me.Line11.X1 = 5.5!
        Me.Line11.X2 = 5.5!
        Me.Line11.Y1 = 0.0!
        Me.Line11.Y2 = 0.1875!
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
        Me.Line12.Height = 0.1875!
        Me.Line12.Left = 4.6875!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 0.0!
        Me.Line12.Width = 0.0!
        Me.Line12.X1 = 4.6875!
        Me.Line12.X2 = 4.6875!
        Me.Line12.Y1 = 0.0!
        Me.Line12.Y2 = 0.1875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtparametro, Me.ReportInfo1, Me.Line5, Me.txtParametros, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.1666667!
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
        Me.grpGrupo.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpEncabezado, Me.lblNombres, Me.lblItem, Me.lblCedulaSocia, Me.lblPlazoA, Me.Line6, Me.lblMontoA, Me.lblNombreGS, Me.lblDptoGS, Me.lblDistritoGS, Me.lblTasaInteres, Me.lblMunicipioGS, Me.lblBarrioGS, Me.lblTelefono, Me.txtGrupo, Me.txtDptoGS, Me.txtMunicipioGS, Me.txtDistritoGS, Me.txtBarrioGS, Me.txtTasaInteres, Me.txtTasaMora, Me.Line18, Me.lblRevisionE, Me.lblNoSesion, Me.lblFechaSesion, Me.lblMontoS, Me.lblPlazoS, Me.Line2, Me.Line3, Me.Line9, Me.Line4, Me.txtFechaResolucion, Me.txtSesion, Me.srptExpediente})
        Me.grpGrupo.DataField = "nSclFichaNotificacionID"
        Me.grpGrupo.Height = 1.927083!
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
        Me.lblCedulaSocia.Left = 3.5625!
        Me.lblCedulaSocia.Name = "lblCedulaSocia"
        Me.lblCedulaSocia.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblCedulaSocia.Text = "Cédula"
        Me.lblCedulaSocia.Top = 1.6875!
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
        Me.lblMunicipioGS.Width = 1.0!
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
        Me.lblBarrioGS.Width = 1.0!
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
        Me.lblTelefono.Width = 1.125!
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
        Me.txtMunicipioGS.Left = 5.1875!
        Me.txtMunicipioGS.Name = "txtMunicipioGS"
        Me.txtMunicipioGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtMunicipioGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtMunicipioGS.Text = Nothing
        Me.txtMunicipioGS.Top = 0.25!
        Me.txtMunicipioGS.Width = 2.1875!
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
        Me.txtBarrioGS.Left = 5.1875!
        Me.txtBarrioGS.Name = "txtBarrioGS"
        Me.txtBarrioGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtBarrioGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtBarrioGS.Text = Nothing
        Me.txtBarrioGS.Top = 0.5!
        Me.txtBarrioGS.Width = 2.1875!
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
        Me.txtTasaInteres.DataField = "nTasaInteresAnual"
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
        Me.txtTasaMora.DataField = "nTasaMoraAnual"
        Me.txtTasaMora.Height = 0.1875!
        Me.txtTasaMora.Left = 5.1875!
        Me.txtTasaMora.Name = "txtTasaMora"
        Me.txtTasaMora.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTasaMora.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtTasaMora.Text = Nothing
        Me.txtTasaMora.Top = 0.75!
        Me.txtTasaMora.Width = 2.1875!
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
        Me.Line18.Left = 3.5625!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 1.625!
        Me.Line18.Width = 0.0!
        Me.Line18.X1 = 3.5625!
        Me.Line18.X2 = 3.5625!
        Me.Line18.Y1 = 1.625!
        Me.Line18.Y2 = 1.9375!
        '
        'lblRevisionE
        '
        Me.lblRevisionE.Border.BottomColor = System.Drawing.Color.Black
        Me.lblRevisionE.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRevisionE.Border.LeftColor = System.Drawing.Color.Black
        Me.lblRevisionE.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRevisionE.Border.RightColor = System.Drawing.Color.Black
        Me.lblRevisionE.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRevisionE.Border.TopColor = System.Drawing.Color.Black
        Me.lblRevisionE.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRevisionE.Height = 0.25!
        Me.lblRevisionE.HyperLink = Nothing
        Me.lblRevisionE.Left = 0.0!
        Me.lblRevisionE.Name = "lblRevisionE"
        Me.lblRevisionE.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblRevisionE.Text = "REVISION DE EXPEDIENTE"
        Me.lblRevisionE.Top = 0.9375!
        Me.lblRevisionE.Width = 7.4375!
        '
        'lblNoSesion
        '
        Me.lblNoSesion.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNoSesion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoSesion.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNoSesion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoSesion.Border.RightColor = System.Drawing.Color.Black
        Me.lblNoSesion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoSesion.Border.TopColor = System.Drawing.Color.Black
        Me.lblNoSesion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoSesion.Height = 0.25!
        Me.lblNoSesion.HyperLink = Nothing
        Me.lblNoSesion.Left = 0.25!
        Me.lblNoSesion.Name = "lblNoSesion"
        Me.lblNoSesion.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9.75pt; verti" & _
            "cal-align: middle; "
        Me.lblNoSesion.Text = "RESOLUCION DEL COMITE DE CREDITO No:"
        Me.lblNoSesion.Top = 1.375!
        Me.lblNoSesion.Width = 3.0!
        '
        'lblFechaSesion
        '
        Me.lblFechaSesion.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaSesion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaSesion.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaSesion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaSesion.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaSesion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaSesion.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaSesion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaSesion.Height = 0.25!
        Me.lblFechaSesion.HyperLink = Nothing
        Me.lblFechaSesion.Left = 5.0!
        Me.lblFechaSesion.Name = "lblFechaSesion"
        Me.lblFechaSesion.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9.75pt; verti" & _
            "cal-align: middle; "
        Me.lblFechaSesion.Text = "DE FECHA:"
        Me.lblFechaSesion.Top = 1.375!
        Me.lblFechaSesion.Width = 0.8125!
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
        Me.lblMontoS.Left = 4.6875!
        Me.lblMontoS.Name = "lblMontoS"
        Me.lblMontoS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoS.Text = "Monto Solicitado C$"
        Me.lblMontoS.Top = 1.625!
        Me.lblMontoS.Width = 0.8125!
        '
        'lblPlazoS
        '
        Me.lblPlazoS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPlazoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPlazoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoS.Border.RightColor = System.Drawing.Color.Black
        Me.lblPlazoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoS.Border.TopColor = System.Drawing.Color.Black
        Me.lblPlazoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoS.Height = 0.3125!
        Me.lblPlazoS.HyperLink = Nothing
        Me.lblPlazoS.Left = 5.5!
        Me.lblPlazoS.Name = "lblPlazoS"
        Me.lblPlazoS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblPlazoS.Text = "Plazo (Men.)"
        Me.lblPlazoS.Top = 1.625!
        Me.lblPlazoS.Width = 0.5!
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
        Me.Line2.Left = 6.0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.625!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 6.0!
        Me.Line2.X2 = 6.0!
        Me.Line2.Y1 = 1.625!
        Me.Line2.Y2 = 1.9375!
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
        Me.Line9.Left = 5.5!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 1.625!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 5.5!
        Me.Line9.X2 = 5.5!
        Me.Line9.Y1 = 1.625!
        Me.Line9.Y2 = 1.9375!
        '
        'txtFechaResolucion
        '
        Me.txtFechaResolucion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaResolucion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaResolucion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaResolucion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaResolucion.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaResolucion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaResolucion.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaResolucion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaResolucion.Height = 0.25!
        Me.txtFechaResolucion.Left = 5.8125!
        Me.txtFechaResolucion.Name = "txtFechaResolucion"
        Me.txtFechaResolucion.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFechaResolucion.Text = Nothing
        Me.txtFechaResolucion.Top = 1.375!
        Me.txtFechaResolucion.Width = 0.9375!
        '
        'txtSesion
        '
        Me.txtSesion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtSesion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSesion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtSesion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSesion.Border.RightColor = System.Drawing.Color.Black
        Me.txtSesion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSesion.Border.TopColor = System.Drawing.Color.Black
        Me.txtSesion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSesion.Height = 0.25!
        Me.txtSesion.Left = 3.3125!
        Me.txtSesion.Name = "txtSesion"
        Me.txtSesion.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtSesion.Text = Nothing
        Me.txtSesion.Top = 1.375!
        Me.txtSesion.Width = 1.375!
        '
        'srptExpediente
        '
        Me.srptExpediente.Border.BottomColor = System.Drawing.Color.Black
        Me.srptExpediente.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptExpediente.Border.LeftColor = System.Drawing.Color.Black
        Me.srptExpediente.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptExpediente.Border.RightColor = System.Drawing.Color.Black
        Me.srptExpediente.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptExpediente.Border.TopColor = System.Drawing.Color.Black
        Me.srptExpediente.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.srptExpediente.CloseBorder = False
        Me.srptExpediente.Height = 0.1875!
        Me.srptExpediente.Left = 0.0!
        Me.srptExpediente.Name = "srptExpediente"
        Me.srptExpediente.Report = Nothing
        Me.srptExpediente.ReportName = "srptExpediente"
        Me.srptExpediente.Top = 1.1875!
        Me.srptExpediente.Width = 7.375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblPie, Me.txtObservaciones, Me.lblObservaciones, Me.Shape2, Me.lblCargoPrimeraFirma, Me.lblFirmaA, Me.lblCargoSegundaFirma, Me.lblFirmaB, Me.lblFirmaC, Me.lblCargoTerceraFirma, Me.lblTotal, Me.txtTotalS, Me.txtTotalA, Me.Line7, Me.Line14, Me.Line15, Me.Line13})
        Me.GroupFooter1.Height = 1.958333!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.Shape1.Height = 0.8125!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.3125!
        Me.Shape1.Width = 7.25!
        '
        'lblPie
        '
        Me.lblPie.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPie.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPie.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie.Border.RightColor = System.Drawing.Color.Black
        Me.lblPie.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie.Border.TopColor = System.Drawing.Color.Black
        Me.lblPie.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie.Height = 0.1875!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.063!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "ddo-char-set: 0; text-align: center; font-size: 9.75pt; "
        Me.lblPie.Text = "Dado en la Ciudad de..."
        Me.lblPie.Top = 1.16!
        Me.lblPie.Width = 7.25!
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
        Me.txtObservaciones.DataField = "sObservacion"
        Me.txtObservaciones.Height = 0.625!
        Me.txtObservaciones.Left = 0.125!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "ddo-char-set: 0; text-align: justify; font-size: 8.25pt; "
        Me.txtObservaciones.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtObservaciones.Text = Nothing
        Me.txtObservaciones.Top = 0.5!
        Me.txtObservaciones.Width = 7.125!
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
        Me.lblObservaciones.Left = 0.125!
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblObservaciones.Text = "OBSERVACIONES:"
        Me.lblObservaciones.Top = 0.3125!
        Me.lblObservaciones.Width = 1.5!
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
        Me.lblCargoPrimeraFirma.Height = 0.125!
        Me.lblCargoPrimeraFirma.HyperLink = Nothing
        Me.lblCargoPrimeraFirma.Left = 0.125!
        Me.lblCargoPrimeraFirma.Name = "lblCargoPrimeraFirma"
        Me.lblCargoPrimeraFirma.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoPrimeraFirma.Text = "Cargo A"
        Me.lblCargoPrimeraFirma.Top = 1.8125!
        Me.lblCargoPrimeraFirma.Width = 2.5!
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
        Me.lblFirmaA.Left = 0.125!
        Me.lblFirmaA.Name = "lblFirmaA"
        Me.lblFirmaA.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaA.Text = "FirmaA"
        Me.lblFirmaA.Top = 1.625!
        Me.lblFirmaA.Width = 2.5!
        '
        'lblCargoSegundaFirma
        '
        Me.lblCargoSegundaFirma.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCargoSegundaFirma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoSegundaFirma.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCargoSegundaFirma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoSegundaFirma.Border.RightColor = System.Drawing.Color.Black
        Me.lblCargoSegundaFirma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoSegundaFirma.Border.TopColor = System.Drawing.Color.Black
        Me.lblCargoSegundaFirma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoSegundaFirma.Height = 0.15!
        Me.lblCargoSegundaFirma.HyperLink = Nothing
        Me.lblCargoSegundaFirma.Left = 2.75!
        Me.lblCargoSegundaFirma.Name = "lblCargoSegundaFirma"
        Me.lblCargoSegundaFirma.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoSegundaFirma.Text = "Cargo B"
        Me.lblCargoSegundaFirma.Top = 1.8!
        Me.lblCargoSegundaFirma.Width = 2.25!
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
        Me.lblFirmaB.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFirmaB.Height = 0.17!
        Me.lblFirmaB.HyperLink = Nothing
        Me.lblFirmaB.Left = 2.75!
        Me.lblFirmaB.Name = "lblFirmaB"
        Me.lblFirmaB.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaB.Text = "FirmaB"
        Me.lblFirmaB.Top = 1.63!
        Me.lblFirmaB.Width = 2.25!
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
        Me.lblFirmaC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFirmaC.Height = 0.17!
        Me.lblFirmaC.HyperLink = Nothing
        Me.lblFirmaC.Left = 5.125!
        Me.lblFirmaC.Name = "lblFirmaC"
        Me.lblFirmaC.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Arial; vertical-align: middle; "
        Me.lblFirmaC.Text = "FirmaC"
        Me.lblFirmaC.Top = 1.625!
        Me.lblFirmaC.Width = 2.25!
        '
        'lblCargoTerceraFirma
        '
        Me.lblCargoTerceraFirma.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCargoTerceraFirma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoTerceraFirma.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCargoTerceraFirma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoTerceraFirma.Border.RightColor = System.Drawing.Color.Black
        Me.lblCargoTerceraFirma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoTerceraFirma.Border.TopColor = System.Drawing.Color.Black
        Me.lblCargoTerceraFirma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCargoTerceraFirma.Height = 0.15!
        Me.lblCargoTerceraFirma.HyperLink = Nothing
        Me.lblCargoTerceraFirma.Left = 5.125!
        Me.lblCargoTerceraFirma.Name = "lblCargoTerceraFirma"
        Me.lblCargoTerceraFirma.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
        Me.lblCargoTerceraFirma.Text = "Cargo C"
        Me.lblCargoTerceraFirma.Top = 1.8!
        Me.lblCargoTerceraFirma.Width = 2.25!
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
        Me.lblTotal.Left = 0.25!
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblTotal.Text = "TOTAL APROBADO"
        Me.lblTotal.Top = 0.0625!
        Me.lblTotal.Width = 4.1875!
        '
        'txtTotalS
        '
        Me.txtTotalS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTotalS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTotalS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalS.Border.RightColor = System.Drawing.Color.Black
        Me.txtTotalS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalS.Border.TopColor = System.Drawing.Color.Black
        Me.txtTotalS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTotalS.CanGrow = False
        Me.txtTotalS.DataField = "nMontoCreditoSolicitado"
        Me.txtTotalS.Height = 0.125!
        Me.txtTotalS.Left = 4.6875!
        Me.txtTotalS.Name = "txtTotalS"
        Me.txtTotalS.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalS.SummaryGroup = "grpGrupo"
        Me.txtTotalS.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtTotalS.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtTotalS.Text = Nothing
        Me.txtTotalS.Top = 0.0625!
        Me.txtTotalS.Width = 0.75!
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
        Me.txtTotalA.Height = 0.13!
        Me.txtTotalA.Left = 6.0!
        Me.txtTotalA.Name = "txtTotalA"
        Me.txtTotalA.Style = "ddo-char-set: 0; text-align: right; font-weight: bold; font-size: 8.25pt; vertica" & _
            "l-align: middle; "
        Me.txtTotalA.Text = Nothing
        Me.txtTotalA.Top = 0.0625!
        Me.txtTotalA.Width = 0.75!
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
        Me.Line7.Height = 0.21!
        Me.Line7.Left = 6.75!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.0!
        Me.Line7.Width = 0.0!
        Me.Line7.X1 = 6.75!
        Me.Line7.X2 = 6.75!
        Me.Line7.Y1 = 0.0!
        Me.Line7.Y2 = 0.21!
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
        Me.Line14.Left = 5.5!
        Me.Line14.LineWeight = 1.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 0.0!
        Me.Line14.Width = 0.0!
        Me.Line14.X1 = 5.5!
        Me.Line14.X2 = 5.5!
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
        Me.Line15.Left = 4.6875!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 0.0!
        Me.Line15.Width = 0.0!
        Me.Line15.X1 = 4.6875!
        Me.Line15.X2 = 4.6875!
        Me.Line15.Y1 = 0.0!
        Me.Line15.Y2 = 0.1875!
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
        Me.Line13.Height = 0.21!
        Me.Line13.Left = 6.0!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 0.0!
        Me.Line13.Width = 0.0!
        Me.Line13.X1 = 6.0!
        Me.Line13.X2 = 6.0!
        Me.Line13.Y1 = 0.0!
        Me.Line13.Y2 = 0.21!
        '
        'rptSclFichaComiteCredito
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.479167!
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
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametros, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.lblRevisionE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoSesion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaSesion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaResolucion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSesion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoPrimeraFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoSegundaFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCargoTerceraFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalA, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblPlazoA As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents shpDetalles As DataDynamics.ActiveReports.Shape
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents grpGrupo As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblFirmaA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNumero As DataDynamics.ActiveReports.Label
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
    Friend WithEvents txtPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line19 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPie As DataDynamics.ActiveReports.Label
    Friend WithEvents txtObservaciones As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblObservaciones As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCargoPrimeraFirma As DataDynamics.ActiveReports.Label
    Friend WithEvents lblRevisionE As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNoSesion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFechaSesion As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblMontoS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPlazoS As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtFechaResolucion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtSesion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPlazoS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line12 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblCargoSegundaFirma As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaB As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaC As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCargoTerceraFirma As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line14 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line15 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtTotalS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTotalA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents srptExpediente As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Line13 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblAnulada As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReporteFCL As DataDynamics.ActiveReports.SubReport
End Class
