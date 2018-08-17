<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclFichaNotificacionCredito
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclFichaNotificacionCredito))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblCodigoRpt = New DataDynamics.ActiveReports.Label
        Me.lblEncabezado = New DataDynamics.ActiveReports.Label
        Me.shpEncabezado = New DataDynamics.ActiveReports.Shape
        Me.lblItem = New DataDynamics.ActiveReports.Label
        Me.lblNombres = New DataDynamics.ActiveReports.Label
        Me.lblPlazo = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.lblMonto = New DataDynamics.ActiveReports.Label
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
        Me.Line7 = New DataDynamics.ActiveReports.Line
        Me.Line19 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtparametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro2 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.grpGrupo = New DataDynamics.ActiveReports.GroupHeader
        Me.lblCedulaSocia = New DataDynamics.ActiveReports.Label
        Me.lblNumero = New DataDynamics.ActiveReports.Label
        Me.lblCoordinadora = New DataDynamics.ActiveReports.Label
        Me.lblNombreGS = New DataDynamics.ActiveReports.Label
        Me.lblDptoGS = New DataDynamics.ActiveReports.Label
        Me.lblDistritoGS = New DataDynamics.ActiveReports.Label
        Me.lblDireccionCoordinadora = New DataDynamics.ActiveReports.Label
        Me.lblCedulaCoordinadora = New DataDynamics.ActiveReports.Label
        Me.lblMunicipioGS = New DataDynamics.ActiveReports.Label
        Me.lblBarrioGS = New DataDynamics.ActiveReports.Label
        Me.lblTelefono = New DataDynamics.ActiveReports.Label
        Me.Line9 = New DataDynamics.ActiveReports.Line
        Me.Line10 = New DataDynamics.ActiveReports.Line
        Me.Line11 = New DataDynamics.ActiveReports.Line
        Me.Line12 = New DataDynamics.ActiveReports.Line
        Me.Line13 = New DataDynamics.ActiveReports.Line
        Me.Line14 = New DataDynamics.ActiveReports.Line
        Me.Line15 = New DataDynamics.ActiveReports.Line
        Me.Line16 = New DataDynamics.ActiveReports.Line
        Me.Line17 = New DataDynamics.ActiveReports.Line
        Me.txtCoordinadora = New DataDynamics.ActiveReports.TextBox
        Me.txtGrupo = New DataDynamics.ActiveReports.TextBox
        Me.txtDptoGS = New DataDynamics.ActiveReports.TextBox
        Me.txtMunicipioGS = New DataDynamics.ActiveReports.TextBox
        Me.txtDistritoGS = New DataDynamics.ActiveReports.TextBox
        Me.txtBarrioGS = New DataDynamics.ActiveReports.TextBox
        Me.txtCedulaCoordinadora = New DataDynamics.ActiveReports.TextBox
        Me.txtTelefono = New DataDynamics.ActiveReports.TextBox
        Me.txtDireccion = New DataDynamics.ActiveReports.TextBox
        Me.Line18 = New DataDynamics.ActiveReports.Line
        Me.lblAnulada = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblFirma = New DataDynamics.ActiveReports.Label
        Me.lblPie = New DataDynamics.ActiveReports.Label
        Me.lblPie1 = New DataDynamics.ActiveReports.Label
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.lblObservaciones = New DataDynamics.ActiveReports.Label
        Me.lblPrograma = New DataDynamics.ActiveReports.Label
        Me.lblMinisterio = New DataDynamics.ActiveReports.Label
        Me.lblDireccion = New DataDynamics.ActiveReports.Label
        Me.lblPBX = New DataDynamics.ActiveReports.Label
        Me.lblRecibido = New DataDynamics.ActiveReports.Label
        Me.txtDepartamento = New DataDynamics.ActiveReports.TextBox
        Me.lblMunicipio = New DataDynamics.ActiveReports.Label
        Me.txtMunicipio = New DataDynamics.ActiveReports.TextBox
        Me.lblDistrito = New DataDynamics.ActiveReports.Label
        Me.txtDistrito = New DataDynamics.ActiveReports.TextBox
        Me.lblBarrio = New DataDynamics.ActiveReports.Label
        Me.txtBarrio = New DataDynamics.ActiveReports.TextBox
        Me.lblDepartamento = New DataDynamics.ActiveReports.Label
        Me.lblNombre = New DataDynamics.ActiveReports.Label
        Me.txtNombreCoord = New DataDynamics.ActiveReports.TextBox
        Me.lblGS = New DataDynamics.ActiveReports.Label
        Me.txtGS = New DataDynamics.ActiveReports.TextBox
        Me.lblFirmaCoordinadora = New DataDynamics.ActiveReports.Label
        Me.lblFecha = New DataDynamics.ActiveReports.Label
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.lblRecibo = New DataDynamics.ActiveReports.Label
        Me.picFirmaNotificador = New DataDynamics.ActiveReports.Picture
        Me.SubReporteFCL = New DataDynamics.ActiveReports.SubReport
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEncabezado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedulaSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDptoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistritoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccionCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedulaCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBarrioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDptoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistritoGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarrioGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedulaCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPie1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMinisterio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPBX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRecibido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreCoord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFirmaNotificador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.01041667!
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
        Me.lblTitulo.Height = 0.3125!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.0!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 14.25pt; verti" & _
            "cal-align: middle; "
        Me.lblTitulo.Text = "FICHA DE NOTIFICACION DE CREDITO "
        Me.lblTitulo.Top = 0.8125!
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
        Me.lblCodigoRpt.Left = 5.625!
        Me.lblCodigoRpt.Name = "lblCodigoRpt"
        Me.lblCodigoRpt.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.lblCodigoRpt.Text = "CS4"
        Me.lblCodigoRpt.Top = 0.25!
        Me.lblCodigoRpt.Width = 0.6875!
        '
        'lblEncabezado
        '
        Me.lblEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.lblEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEncabezado.Height = 0.5625!
        Me.lblEncabezado.HyperLink = Nothing
        Me.lblEncabezado.Left = 0.0625!
        Me.lblEncabezado.Name = "lblEncabezado"
        Me.lblEncabezado.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; "
        Me.lblEncabezado.Text = "Por medio de la presente me permito informar que el Comité de Crédito"
        Me.lblEncabezado.Top = 2.75!
        Me.lblEncabezado.Width = 7.3125!
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
        Me.shpEncabezado.Top = 3.375!
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
        Me.lblItem.Left = 0.0625!
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItem.Text = "No."
        Me.lblItem.Top = 3.4375!
        Me.lblItem.Width = 0.4375!
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
        Me.lblNombres.Left = 0.5!
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblNombres.Text = "Nombres y Apellidos"
        Me.lblNombres.Top = 3.4375!
        Me.lblNombres.Width = 3.0!
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
        Me.lblPlazo.Left = 6.35!
        Me.lblPlazo.Name = "lblPlazo"
        Me.lblPlazo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblPlazo.Text = "Plazo (M)"
        Me.lblPlazo.Top = 3.438!
        Me.lblPlazo.Width = 1.0!
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
        Me.Line3.Height = 0.302083!
        Me.Line3.Left = 6.333333!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 3.375!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 6.333333!
        Me.Line3.X2 = 6.333333!
        Me.Line3.Y1 = 3.375!
        Me.Line3.Y2 = 3.677083!
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
        Me.Line4.Height = 0.302083!
        Me.Line4.Left = 5.052083!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 3.375!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 5.052083!
        Me.Line4.X2 = 5.052083!
        Me.Line4.Y1 = 3.375!
        Me.Line4.Y2 = 3.677083!
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
        Me.Line6.Height = 0.302083!
        Me.Line6.Left = 0.4791667!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 3.385417!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 0.4791667!
        Me.Line6.X2 = 0.4791667!
        Me.Line6.Y1 = 3.385417!
        Me.Line6.Y2 = 3.6875!
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
        Me.lblMonto.Left = 5.0625!
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMonto.Text = "Monto Aprobado C$"
        Me.lblMonto.Top = 3.4375!
        Me.lblMonto.Width = 1.25!
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
        Me.lblUsuario.Width = 0.5625!
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
        Me.txtUsuario.Left = 0.625!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.Top = 0.0!
        Me.txtUsuario.Width = 1.0625!
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
        Me.txtHora.Top = 0.0!
        Me.txtHora.Width = 0.875!
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
        Me.txtFecha.Top = 0.0!
        Me.txtFecha.Width = 0.6875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpDetalles, Me.txtNombre, Me.txtItem, Me.txtCedula, Me.Line8, Me.txtMonto, Me.txtPlazo, Me.Line1, Me.Line7, Me.Line19})
        Me.Detail1.Height = 0.1770833!
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
        Me.shpDetalles.Height = 0.1875!
        Me.shpDetalles.Left = 0.0!
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
        Me.txtNombre.Left = 0.5625!
        Me.txtNombre.MultiLine = False
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombre.Text = Nothing
        Me.txtNombre.Top = 0.0!
        Me.txtNombre.Width = 2.875!
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
        Me.txtItem.Left = 0.125!
        Me.txtItem.MultiLine = False
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtItem.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtItem.Text = Nothing
        Me.txtItem.Top = 0.0!
        Me.txtItem.Width = 0.3125!
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
        Me.txtCedula.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCedula.Text = Nothing
        Me.txtCedula.Top = 0.0!
        Me.txtCedula.Width = 1.4375!
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
        Me.Line8.Height = 0.19!
        Me.Line8.Left = 0.4895833!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.0!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 0.4895833!
        Me.Line8.X2 = 0.4895833!
        Me.Line8.Y1 = 0.0!
        Me.Line8.Y2 = 0.19!
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
        Me.txtMonto.Left = 5.125!
        Me.txtMonto.MultiLine = False
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMonto.Text = Nothing
        Me.txtMonto.Top = 0.0!
        Me.txtMonto.Width = 1.125!
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
        Me.txtPlazo.DataField = "nPlazoAprobado"
        Me.txtPlazo.Height = 0.1875!
        Me.txtPlazo.Left = 6.4375!
        Me.txtPlazo.MultiLine = False
        Me.txtPlazo.Name = "txtPlazo"
        Me.txtPlazo.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPlazo.Text = Nothing
        Me.txtPlazo.Top = 0.0!
        Me.txtPlazo.Width = 0.875!
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
        Me.Line1.Height = 0.19!
        Me.Line1.Left = 3.5!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 3.5!
        Me.Line1.X2 = 3.5!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.19!
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
        Me.Line7.Height = 0.19!
        Me.Line7.Left = 5.0625!
        Me.Line7.LineWeight = 1.0!
        Me.Line7.Name = "Line7"
        Me.Line7.Top = 0.0!
        Me.Line7.Width = 0.0!
        Me.Line7.X1 = 5.0625!
        Me.Line7.X2 = 5.0625!
        Me.Line7.Y1 = 0.0!
        Me.Line7.Y2 = 0.19!
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
        Me.Line19.Height = 0.19!
        Me.Line19.Left = 6.34375!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 0.0!
        Me.Line19.Width = 0.0!
        Me.Line19.X1 = 6.34375!
        Me.Line19.X2 = 6.34375!
        Me.Line19.Y1 = 0.0!
        Me.Line19.Y2 = 0.19!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtparametro1, Me.txtparametro2, Me.ReportInfo1, Me.Line5, Me.TextBox1, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.2083333!
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
        Me.txtparametro1.CanGrow = False
        Me.txtparametro1.Height = 0.1875!
        Me.txtparametro1.Left = 0.0!
        Me.txtparametro1.MultiLine = False
        Me.txtparametro1.Name = "txtparametro1"
        Me.txtparametro1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro1.Text = Nothing
        Me.txtparametro1.Top = 0.0!
        Me.txtparametro1.Visible = False
        Me.txtparametro1.Width = 0.25!
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
        Me.txtparametro2.Top = 0.0!
        Me.txtparametro2.Visible = False
        Me.txtparametro2.Width = 0.25!
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
        Me.TextBox1.Width = 0.25!
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
        Me.grpGrupo.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpEncabezado, Me.lblNombres, Me.SubReporte, Me.lblCodigoRpt, Me.lblEncabezado, Me.lblItem, Me.lblCedulaSocia, Me.lblPlazo, Me.Line3, Me.Line4, Me.Line6, Me.lblMonto, Me.lblNumero, Me.lblCoordinadora, Me.lblNombreGS, Me.lblDptoGS, Me.lblDistritoGS, Me.lblDireccionCoordinadora, Me.lblCedulaCoordinadora, Me.lblMunicipioGS, Me.lblBarrioGS, Me.lblTelefono, Me.Line9, Me.Line10, Me.Line11, Me.Line12, Me.Line13, Me.Line14, Me.Line15, Me.Line16, Me.Line17, Me.txtCoordinadora, Me.txtGrupo, Me.txtDptoGS, Me.txtMunicipioGS, Me.txtDistritoGS, Me.txtBarrioGS, Me.txtCedulaCoordinadora, Me.txtTelefono, Me.txtDireccion, Me.lblTitulo, Me.Line18, Me.lblAnulada, Me.SubReporteFCL})
        Me.grpGrupo.DataField = "nSclFichaNotificacionID"
        Me.grpGrupo.Height = 3.6875!
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
        Me.lblCedulaSocia.Top = 3.4375!
        Me.lblCedulaSocia.Width = 1.4375!
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
        Me.lblNumero.Left = 5.6875!
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Style = "color: Navy; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 1" & _
            "4.25pt; vertical-align: middle; "
        Me.lblNumero.Text = "No. 1"
        Me.lblNumero.Top = 0.8125!
        Me.lblNumero.Width = 1.3125!
        '
        'lblCoordinadora
        '
        Me.lblCoordinadora.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCoordinadora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCoordinadora.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCoordinadora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCoordinadora.Border.RightColor = System.Drawing.Color.Black
        Me.lblCoordinadora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCoordinadora.Border.TopColor = System.Drawing.Color.Black
        Me.lblCoordinadora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCoordinadora.Height = 0.1875!
        Me.lblCoordinadora.HyperLink = Nothing
        Me.lblCoordinadora.Left = 0.125!
        Me.lblCoordinadora.Name = "lblCoordinadora"
        Me.lblCoordinadora.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 9pt; vertical-al" & _
            "ign: middle; "
        Me.lblCoordinadora.Text = "Señora:"
        Me.lblCoordinadora.Top = 1.1875!
        Me.lblCoordinadora.Width = 1.875!
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
        Me.lblNombreGS.Text = "Coordinadora Grupo Solidario:"
        Me.lblNombreGS.Top = 1.4375!
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
        Me.lblDptoGS.Text = "Del Departamento de:"
        Me.lblDptoGS.Top = 1.6875!
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
        Me.lblDistritoGS.Text = "Del Distrito de:"
        Me.lblDistritoGS.Top = 1.9375!
        Me.lblDistritoGS.Width = 1.875!
        '
        'lblDireccionCoordinadora
        '
        Me.lblDireccionCoordinadora.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDireccionCoordinadora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionCoordinadora.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDireccionCoordinadora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionCoordinadora.Border.RightColor = System.Drawing.Color.Black
        Me.lblDireccionCoordinadora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionCoordinadora.Border.TopColor = System.Drawing.Color.Black
        Me.lblDireccionCoordinadora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionCoordinadora.Height = 0.1875!
        Me.lblDireccionCoordinadora.HyperLink = Nothing
        Me.lblDireccionCoordinadora.Left = 0.125!
        Me.lblDireccionCoordinadora.Name = "lblDireccionCoordinadora"
        Me.lblDireccionCoordinadora.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblDireccionCoordinadora.Text = "Dirección:"
        Me.lblDireccionCoordinadora.Top = 2.4375!
        Me.lblDireccionCoordinadora.Width = 1.875!
        '
        'lblCedulaCoordinadora
        '
        Me.lblCedulaCoordinadora.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCedulaCoordinadora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaCoordinadora.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCedulaCoordinadora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaCoordinadora.Border.RightColor = System.Drawing.Color.Black
        Me.lblCedulaCoordinadora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaCoordinadora.Border.TopColor = System.Drawing.Color.Black
        Me.lblCedulaCoordinadora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaCoordinadora.Height = 0.1875!
        Me.lblCedulaCoordinadora.HyperLink = Nothing
        Me.lblCedulaCoordinadora.Left = 0.125!
        Me.lblCedulaCoordinadora.Name = "lblCedulaCoordinadora"
        Me.lblCedulaCoordinadora.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblCedulaCoordinadora.Text = "Cédula de Identidad No.:"
        Me.lblCedulaCoordinadora.Top = 2.1875!
        Me.lblCedulaCoordinadora.Width = 1.875!
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
        Me.lblMunicipioGS.Left = 4.125!
        Me.lblMunicipioGS.Name = "lblMunicipioGS"
        Me.lblMunicipioGS.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblMunicipioGS.Text = "Del Municipio:"
        Me.lblMunicipioGS.Top = 1.6875!
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
        Me.lblBarrioGS.Left = 4.125!
        Me.lblBarrioGS.Name = "lblBarrioGS"
        Me.lblBarrioGS.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblBarrioGS.Text = "Del Barrio:"
        Me.lblBarrioGS.Top = 1.9375!
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
        Me.lblTelefono.Left = 4.125!
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 9pt; vertical" & _
            "-align: middle; "
        Me.lblTelefono.Text = "Teléfono:"
        Me.lblTelefono.Top = 2.1875!
        Me.lblTelefono.Width = 1.0!
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
        Me.Line9.Height = 0.0!
        Me.Line9.Left = 2.020833!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 1.395833!
        Me.Line9.Width = 5.16875!
        Me.Line9.X1 = 2.020833!
        Me.Line9.X2 = 7.189583!
        Me.Line9.Y1 = 1.395833!
        Me.Line9.Y2 = 1.395833!
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
        Me.Line10.Height = 0.0!
        Me.Line10.Left = 2.020833!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 1.625!
        Me.Line10.Width = 5.16875!
        Me.Line10.X1 = 2.020833!
        Me.Line10.X2 = 7.189583!
        Me.Line10.Y1 = 1.625!
        Me.Line10.Y2 = 1.625!
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
        Me.Line11.Height = 0.0!
        Me.Line11.Left = 2.020833!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 2.66!
        Me.Line11.Width = 5.16875!
        Me.Line11.X1 = 2.020833!
        Me.Line11.X2 = 7.189583!
        Me.Line11.Y1 = 2.66!
        Me.Line11.Y2 = 2.66!
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
        Me.Line12.Height = 0.0!
        Me.Line12.Left = 2.020833!
        Me.Line12.LineWeight = 1.0!
        Me.Line12.Name = "Line12"
        Me.Line12.Top = 1.875!
        Me.Line12.Width = 2.0375!
        Me.Line12.X1 = 2.020833!
        Me.Line12.X2 = 4.058333!
        Me.Line12.Y1 = 1.875!
        Me.Line12.Y2 = 1.875!
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
        Me.Line13.Height = 0.0!
        Me.Line13.Left = 2.019583!
        Me.Line13.LineWeight = 1.0!
        Me.Line13.Name = "Line13"
        Me.Line13.Top = 2.15!
        Me.Line13.Width = 2.0375!
        Me.Line13.X1 = 2.019583!
        Me.Line13.X2 = 4.057083!
        Me.Line13.Y1 = 2.15!
        Me.Line13.Y2 = 2.15!
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
        Me.Line14.Height = 0.0!
        Me.Line14.Left = 2.020833!
        Me.Line14.LineWeight = 1.0!
        Me.Line14.Name = "Line14"
        Me.Line14.Top = 2.375!
        Me.Line14.Width = 2.0375!
        Me.Line14.X1 = 2.020833!
        Me.Line14.X2 = 4.058333!
        Me.Line14.Y1 = 2.375!
        Me.Line14.Y2 = 2.375!
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
        Me.Line15.Height = 0.0!
        Me.Line15.Left = 5.145833!
        Me.Line15.LineWeight = 1.0!
        Me.Line15.Name = "Line15"
        Me.Line15.Top = 1.875!
        Me.Line15.Width = 2.0375!
        Me.Line15.X1 = 5.145833!
        Me.Line15.X2 = 7.183333!
        Me.Line15.Y1 = 1.875!
        Me.Line15.Y2 = 1.875!
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
        Me.Line16.Height = 0.0!
        Me.Line16.Left = 5.145833!
        Me.Line16.LineWeight = 1.0!
        Me.Line16.Name = "Line16"
        Me.Line16.Top = 2.15!
        Me.Line16.Width = 2.0375!
        Me.Line16.X1 = 5.145833!
        Me.Line16.X2 = 7.183333!
        Me.Line16.Y1 = 2.15!
        Me.Line16.Y2 = 2.15!
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
        Me.Line17.Height = 0.0!
        Me.Line17.Left = 5.145833!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 2.375!
        Me.Line17.Width = 2.0375!
        Me.Line17.X1 = 5.145833!
        Me.Line17.X2 = 7.183333!
        Me.Line17.Y1 = 2.375!
        Me.Line17.Y2 = 2.375!
        '
        'txtCoordinadora
        '
        Me.txtCoordinadora.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCoordinadora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCoordinadora.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCoordinadora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCoordinadora.Border.RightColor = System.Drawing.Color.Black
        Me.txtCoordinadora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCoordinadora.Border.TopColor = System.Drawing.Color.Black
        Me.txtCoordinadora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCoordinadora.DataField = "NombreCoordinadora"
        Me.txtCoordinadora.Height = 0.1875!
        Me.txtCoordinadora.Left = 2.125!
        Me.txtCoordinadora.Name = "txtCoordinadora"
        Me.txtCoordinadora.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtCoordinadora.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtCoordinadora.Text = Nothing
        Me.txtCoordinadora.Top = 1.1875!
        Me.txtCoordinadora.Width = 5.0!
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
        Me.txtGrupo.DataField = "NombreGrupo"
        Me.txtGrupo.Height = 0.1875!
        Me.txtGrupo.Left = 2.125!
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtGrupo.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtGrupo.Text = Nothing
        Me.txtGrupo.Top = 1.4375!
        Me.txtGrupo.Width = 5.0!
        '
        'txtDptoGS
        '
        Me.txtDptoGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDptoGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDptoGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDptoGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtDptoGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDptoGS.DataField = "Departamento"
        Me.txtDptoGS.Height = 0.1875!
        Me.txtDptoGS.Left = 2.125!
        Me.txtDptoGS.Name = "txtDptoGS"
        Me.txtDptoGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDptoGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtDptoGS.Text = Nothing
        Me.txtDptoGS.Top = 1.6875!
        Me.txtDptoGS.Width = 1.9375!
        '
        'txtMunicipioGS
        '
        Me.txtMunicipioGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMunicipioGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
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
        Me.txtMunicipioGS.Top = 1.6875!
        Me.txtMunicipioGS.Width = 1.9375!
        '
        'txtDistritoGS
        '
        Me.txtDistritoGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistritoGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistritoGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistritoGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtDistritoGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistritoGS.DataField = "Distrito"
        Me.txtDistritoGS.Height = 0.1875!
        Me.txtDistritoGS.Left = 2.125!
        Me.txtDistritoGS.Name = "txtDistritoGS"
        Me.txtDistritoGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDistritoGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtDistritoGS.Text = Nothing
        Me.txtDistritoGS.Top = 1.9375!
        Me.txtDistritoGS.Width = 1.9375!
        '
        'txtBarrioGS
        '
        Me.txtBarrioGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtBarrioGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
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
        Me.txtBarrioGS.Top = 1.9375!
        Me.txtBarrioGS.Width = 1.9375!
        '
        'txtCedulaCoordinadora
        '
        Me.txtCedulaCoordinadora.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCedulaCoordinadora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedulaCoordinadora.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCedulaCoordinadora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedulaCoordinadora.Border.RightColor = System.Drawing.Color.Black
        Me.txtCedulaCoordinadora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedulaCoordinadora.Border.TopColor = System.Drawing.Color.Black
        Me.txtCedulaCoordinadora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedulaCoordinadora.DataField = "CedulaCoordinadora"
        Me.txtCedulaCoordinadora.Height = 0.1875!
        Me.txtCedulaCoordinadora.Left = 2.125!
        Me.txtCedulaCoordinadora.Name = "txtCedulaCoordinadora"
        Me.txtCedulaCoordinadora.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtCedulaCoordinadora.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtCedulaCoordinadora.Text = Nothing
        Me.txtCedulaCoordinadora.Top = 2.1875!
        Me.txtCedulaCoordinadora.Width = 1.9375!
        '
        'txtTelefono
        '
        Me.txtTelefono.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Border.RightColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Border.TopColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.DataField = "TelefonoCoordinadora"
        Me.txtTelefono.Height = 0.1875!
        Me.txtTelefono.Left = 5.1875!
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtTelefono.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtTelefono.Text = Nothing
        Me.txtTelefono.Top = 2.1875!
        Me.txtTelefono.Width = 1.9375!
        '
        'txtDireccion
        '
        Me.txtDireccion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccion.Border.RightColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccion.Border.TopColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccion.DataField = "DireccionCoordinadora"
        Me.txtDireccion.Height = 0.1875!
        Me.txtDireccion.Left = 2.125!
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDireccion.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtDireccion.Text = Nothing
        Me.txtDireccion.Top = 2.4375!
        Me.txtDireccion.Width = 5.0!
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
        Me.Line18.Height = 0.302083!
        Me.Line18.Left = 3.489583!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 3.375!
        Me.Line18.Width = 0.0!
        Me.Line18.X1 = 3.489583!
        Me.Line18.X2 = 3.489583!
        Me.Line18.Y1 = 3.375!
        Me.Line18.Y2 = 3.677083!
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
        Me.lblAnulada.Left = 0.125!
        Me.lblAnulada.Name = "lblAnulada"
        Me.lblAnulada.Style = "color: Crimson; ddo-char-set: 1; text-align: justify; font-weight: bold; font-siz" & _
            "e: 15.75pt; font-family: Arial Rounded MT Bold; vertical-align: middle; "
        Me.lblAnulada.Text = "ANULADA"
        Me.lblAnulada.Top = 0.8125!
        Me.lblAnulada.Visible = False
        Me.lblAnulada.Width = 1.5!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblFirma, Me.lblPie, Me.lblPie1, Me.txtObservaciones, Me.lblObservaciones, Me.lblPrograma, Me.lblMinisterio, Me.lblDireccion, Me.lblPBX, Me.lblRecibido, Me.txtDepartamento, Me.lblMunicipio, Me.txtMunicipio, Me.lblDistrito, Me.txtDistrito, Me.lblBarrio, Me.txtBarrio, Me.lblDepartamento, Me.lblNombre, Me.txtNombreCoord, Me.lblGS, Me.txtGS, Me.lblFirmaCoordinadora, Me.lblFecha, Me.Line2, Me.lblRecibo, Me.picFirmaNotificador})
        Me.GroupFooter1.Height = 6.822917!
        Me.GroupFooter1.Name = "GroupFooter1"
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
        Me.Shape1.Height = 0.875!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 1.0!
        Me.Shape1.Width = 7.3125!
        '
        'lblFirma
        '
        Me.lblFirma.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFirma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirma.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFirma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirma.Border.RightColor = System.Drawing.Color.Black
        Me.lblFirma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirma.Border.TopColor = System.Drawing.Color.Black
        Me.lblFirma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirma.Height = 0.1875!
        Me.lblFirma.HyperLink = Nothing
        Me.lblFirma.Left = 0.125!
        Me.lblFirma.Name = "lblFirma"
        Me.lblFirma.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblFirma.Text = "Dirección de Promoción y Capacitación"
        Me.lblFirma.Top = 2.875!
        Me.lblFirma.Width = 7.375!
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
        Me.lblPie.Height = 0.875!
        Me.lblPie.HyperLink = Nothing
        Me.lblPie.Left = 0.0625!
        Me.lblPie.Name = "lblPie"
        Me.lblPie.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; "
        Me.lblPie.Text = "En caso de Aprobado, "
        Me.lblPie.Top = 0.0625!
        Me.lblPie.Width = 7.3125!
        '
        'lblPie1
        '
        Me.lblPie1.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPie1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie1.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPie1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie1.Border.RightColor = System.Drawing.Color.Black
        Me.lblPie1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie1.Border.TopColor = System.Drawing.Color.Black
        Me.lblPie1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPie1.Height = 0.375!
        Me.lblPie1.HyperLink = Nothing
        Me.lblPie1.Left = 0.0625!
        Me.lblPie1.Name = "lblPie1"
        Me.lblPie1.Style = "ddo-char-set: 0; text-align: justify; font-size: 9.75pt; "
        Me.lblPie1.Text = "Les agradecemos a todas la confianza en el Programa Usura Cero y les deseamos éxi" & _
            "to en el Plan de Negocios que estarán realizando."
        Me.lblPie1.Top = 1.9375!
        Me.lblPie1.Width = 7.3125!
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
        Me.txtObservaciones.DataField = "sObservacion"
        Me.txtObservaciones.Height = 0.5!
        Me.txtObservaciones.Left = 0.25!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtObservaciones.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtObservaciones.Text = Nothing
        Me.txtObservaciones.Top = 1.3125!
        Me.txtObservaciones.Width = 7.0625!
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
        Me.lblObservaciones.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblObservaciones.Text = "OBSERVACIONES:"
        Me.lblObservaciones.Top = 1.0625!
        Me.lblObservaciones.Width = 1.5!
        '
        'lblPrograma
        '
        Me.lblPrograma.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPrograma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrograma.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPrograma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrograma.Border.RightColor = System.Drawing.Color.Black
        Me.lblPrograma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrograma.Border.TopColor = System.Drawing.Color.Black
        Me.lblPrograma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrograma.Height = 0.1875!
        Me.lblPrograma.HyperLink = Nothing
        Me.lblPrograma.Left = 0.125!
        Me.lblPrograma.Name = "lblPrograma"
        Me.lblPrograma.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblPrograma.Text = "PROGRAMA ""USURA CERO"""
        Me.lblPrograma.Top = 3.0625!
        Me.lblPrograma.Width = 7.375!
        '
        'lblMinisterio
        '
        Me.lblMinisterio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Border.RightColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Border.TopColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Height = 0.2083333!
        Me.lblMinisterio.HyperLink = Nothing
        Me.lblMinisterio.Left = 0.125!
        Me.lblMinisterio.Name = "lblMinisterio"
        Me.lblMinisterio.Style = "ddo-char-set: 0; text-align: center; font-size: 9.75pt; "
        Me.lblMinisterio.Text = "MINISTERIO DE FOMENTO, INDUSTRIA Y COMERCIO"
        Me.lblMinisterio.Top = 3.25!
        Me.lblMinisterio.Width = 7.375!
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
        Me.lblDireccion.Left = 0.125!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "ddo-char-set: 0; text-align: center; font-size: 9.75pt; "
        Me.lblDireccion.Text = "Carretera Masaya Km. 6. Frente a Camino de Oriente."
        Me.lblDireccion.Top = 3.4375!
        Me.lblDireccion.Width = 7.375!
        '
        'lblPBX
        '
        Me.lblPBX.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPBX.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPBX.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPBX.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPBX.Border.RightColor = System.Drawing.Color.Black
        Me.lblPBX.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPBX.Border.TopColor = System.Drawing.Color.Black
        Me.lblPBX.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPBX.Height = 0.1875!
        Me.lblPBX.HyperLink = Nothing
        Me.lblPBX.Left = 0.125!
        Me.lblPBX.Name = "lblPBX"
        Me.lblPBX.Style = "ddo-char-set: 0; text-align: center; font-size: 9.75pt; "
        Me.lblPBX.Text = "PBX: 267-0161"
        Me.lblPBX.Top = 3.625!
        Me.lblPBX.Width = 7.375!
        '
        'lblRecibido
        '
        Me.lblRecibido.Border.BottomColor = System.Drawing.Color.Black
        Me.lblRecibido.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibido.Border.LeftColor = System.Drawing.Color.Black
        Me.lblRecibido.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibido.Border.RightColor = System.Drawing.Color.Black
        Me.lblRecibido.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibido.Border.TopColor = System.Drawing.Color.Black
        Me.lblRecibido.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibido.Height = 0.1875!
        Me.lblRecibido.HyperLink = Nothing
        Me.lblRecibido.Left = 0.0625!
        Me.lblRecibido.Name = "lblRecibido"
        Me.lblRecibido.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblRecibido.Text = "FICHA DE NOTIFICACION DE CREDITO No. "
        Me.lblRecibido.Top = 5.0625!
        Me.lblRecibido.Width = 7.3125!
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
        Me.txtDepartamento.Left = 1.125!
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDepartamento.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.Top = 5.625!
        Me.txtDepartamento.Width = 2.4375!
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
        Me.lblMunicipio.Left = 3.6875!
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.Top = 5.625!
        Me.lblMunicipio.Width = 1.0625!
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
        Me.txtMunicipio.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtMunicipio.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.Top = 5.625!
        Me.txtMunicipio.Width = 2.5625!
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
        Me.lblDistrito.Left = 0.125!
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblDistrito.Text = "Distrito:"
        Me.lblDistrito.Top = 5.9375!
        Me.lblDistrito.Width = 1.0!
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
        Me.txtDistrito.Left = 1.125!
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtDistrito.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtDistrito.Text = Nothing
        Me.txtDistrito.Top = 5.9375!
        Me.txtDistrito.Width = 2.4375!
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
        Me.lblBarrio.Height = 0.1875!
        Me.lblBarrio.HyperLink = Nothing
        Me.lblBarrio.Left = 3.6875!
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblBarrio.Text = "Barrio:"
        Me.lblBarrio.Top = 5.9375!
        Me.lblBarrio.Width = 1.0625!
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
        Me.txtBarrio.DataField = "Barrio"
        Me.txtBarrio.Height = 0.1875!
        Me.txtBarrio.Left = 4.75!
        Me.txtBarrio.Name = "txtBarrio"
        Me.txtBarrio.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtBarrio.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtBarrio.Text = Nothing
        Me.txtBarrio.Top = 5.9375!
        Me.txtBarrio.Width = 2.5625!
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
        Me.lblDepartamento.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblDepartamento.Text = "Departamento:"
        Me.lblDepartamento.Top = 5.625!
        Me.lblDepartamento.Width = 1.0!
        '
        'lblNombre
        '
        Me.lblNombre.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Height = 0.1875!
        Me.lblNombre.HyperLink = Nothing
        Me.lblNombre.Left = 0.125!
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblNombre.Text = "Nombre:"
        Me.lblNombre.Top = 5.3125!
        Me.lblNombre.Width = 1.0!
        '
        'txtNombreCoord
        '
        Me.txtNombreCoord.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreCoord.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreCoord.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreCoord.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreCoord.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreCoord.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreCoord.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreCoord.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreCoord.DataField = "NombreCoordinadora"
        Me.txtNombreCoord.Height = 0.1875!
        Me.txtNombreCoord.Left = 1.125!
        Me.txtNombreCoord.Name = "txtNombreCoord"
        Me.txtNombreCoord.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtNombreCoord.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtNombreCoord.Text = Nothing
        Me.txtNombreCoord.Top = 5.3125!
        Me.txtNombreCoord.Width = 2.4375!
        '
        'lblGS
        '
        Me.lblGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGS.Height = 0.1875!
        Me.lblGS.HyperLink = Nothing
        Me.lblGS.Left = 3.6875!
        Me.lblGS.Name = "lblGS"
        Me.lblGS.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9pt; vertical-align: middle; "
        Me.lblGS.Text = "Grupo Solidario:"
        Me.lblGS.Top = 5.3125!
        Me.lblGS.Width = 1.0625!
        '
        'txtGS
        '
        Me.txtGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGS.DataField = "NombreGrupo"
        Me.txtGS.Height = 0.1875!
        Me.txtGS.Left = 4.75!
        Me.txtGS.Name = "txtGS"
        Me.txtGS.Style = "ddo-char-set: 0; font-size: 9pt; "
        Me.txtGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtGS.Text = Nothing
        Me.txtGS.Top = 5.3125!
        Me.txtGS.Width = 2.5625!
        '
        'lblFirmaCoordinadora
        '
        Me.lblFirmaCoordinadora.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFirmaCoordinadora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaCoordinadora.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFirmaCoordinadora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaCoordinadora.Border.RightColor = System.Drawing.Color.Black
        Me.lblFirmaCoordinadora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaCoordinadora.Border.TopColor = System.Drawing.Color.Black
        Me.lblFirmaCoordinadora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFirmaCoordinadora.Height = 0.1875!
        Me.lblFirmaCoordinadora.HyperLink = Nothing
        Me.lblFirmaCoordinadora.Left = 1.0!
        Me.lblFirmaCoordinadora.Name = "lblFirmaCoordinadora"
        Me.lblFirmaCoordinadora.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblFirmaCoordinadora.Text = "Firma Coordinadora"
        Me.lblFirmaCoordinadora.Top = 6.625!
        Me.lblFirmaCoordinadora.Width = 2.25!
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
        Me.lblFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblFecha.Height = 0.1875!
        Me.lblFecha.HyperLink = Nothing
        Me.lblFecha.Left = 4.25!
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblFecha.Text = "Fecha Notificación"
        Me.lblFecha.Top = 6.625!
        Me.lblFecha.Width = 2.25!
        '
        'Line2
        '
        Me.Line2.Border.BottomColor = System.Drawing.Color.Black
        Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.ThickDashDot
        Me.Line2.Border.LeftColor = System.Drawing.Color.Black
        Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.RightColor = System.Drawing.Color.Black
        Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Border.TopColor = System.Drawing.Color.Black
        Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.09375004!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 4.802083!
        Me.Line2.Width = 7.3125!
        Me.Line2.X1 = 0.09375004!
        Me.Line2.X2 = 7.40625!
        Me.Line2.Y1 = 4.802083!
        Me.Line2.Y2 = 4.802083!
        '
        'lblRecibo
        '
        Me.lblRecibo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblRecibo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblRecibo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibo.Border.RightColor = System.Drawing.Color.Black
        Me.lblRecibo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibo.Border.TopColor = System.Drawing.Color.Black
        Me.lblRecibo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRecibo.Height = 0.1875!
        Me.lblRecibo.HyperLink = Nothing
        Me.lblRecibo.Left = 0.0625!
        Me.lblRecibo.Name = "lblRecibo"
        Me.lblRecibo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblRecibo.Text = "RECIBIDO"
        Me.lblRecibo.Top = 4.875!
        Me.lblRecibo.Width = 7.3125!
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
        Me.picFirmaNotificador.Left = 2.4375!
        Me.picFirmaNotificador.LineWeight = 0.0!
        Me.picFirmaNotificador.Name = "picFirmaNotificador"
        Me.picFirmaNotificador.Top = 2.25!
        Me.picFirmaNotificador.Width = 2.75!
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
        Me.SubReporteFCL.Left = 0.0!
        Me.SubReporteFCL.Name = "SubReporteFCL"
        Me.SubReporteFCL.Report = Nothing
        Me.SubReporteFCL.ReportName = "SubReport1"
        Me.SubReporteFCL.Top = 0.0625!
        Me.SubReporteFCL.Width = 7.4375!
        '
        'rptSclFichaNotificacionCredito
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
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEncabezado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedulaSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDptoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistritoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccionCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedulaCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBarrioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDptoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistritoGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarrioGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedulaCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPie1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMinisterio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPBX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRecibido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreCoord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFirmaNotificador, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodigoRpt As DataDynamics.ActiveReports.Label
    Friend WithEvents lblEncabezado As DataDynamics.ActiveReports.Label
    Friend WithEvents shpEncabezado As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblItem As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMonto As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPlazo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents shpDetalles As DataDynamics.ActiveReports.Shape
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents grpGrupo As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblDepartamento As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDepartamento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMunicipio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMunicipio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDistrito As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDistrito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblBarrio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtBarrio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFirma As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCoordinadora As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombreGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDptoGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDistritoGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDireccionCoordinadora As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCedulaCoordinadora As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMunicipioGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblBarrioGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line12 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line13 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line14 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line15 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line16 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line17 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtCoordinadora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtGrupo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDptoGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMunicipioGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDistritoGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBarrioGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCedulaCoordinadora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTelefono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDireccion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCedulaSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents Line18 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtMonto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPlazo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line7 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line19 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblPie As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPie1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtObservaciones As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblObservaciones As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPrograma As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMinisterio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPBX As DataDynamics.ActiveReports.Label
    Friend WithEvents lblRecibido As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombre As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNombreCoord As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblGS As DataDynamics.ActiveReports.Label
    Friend WithEvents txtGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFirmaCoordinadora As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFecha As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblRecibo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblAnulada As DataDynamics.ActiveReports.Label
    Friend WithEvents picFirmaNotificador As DataDynamics.ActiveReports.Picture
    Friend WithEvents SubReporteFCL As DataDynamics.ActiveReports.SubReport
End Class
