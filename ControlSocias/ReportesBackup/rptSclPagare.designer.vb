<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclPagare
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSclPagare))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox
        Me.txtCedula = New DataDynamics.ActiveReports.TextBox
        Me.txtDireccion = New DataDynamics.ActiveReports.TextBox
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.grpGrupo = New DataDynamics.ActiveReports.GroupHeader
        Me.lblFianza = New DataDynamics.ActiveReports.Label
        Me.lblFirmaPagare = New DataDynamics.ActiveReports.Label
        Me.shpEncabezado = New DataDynamics.ActiveReports.Shape
        Me.lblCuotas = New DataDynamics.ActiveReports.Label
        Me.lblNumero = New DataDynamics.ActiveReports.Label
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblNombreFiador = New DataDynamics.ActiveReports.Label
        Me.lblFirmaFiador = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.lblCedulaFiador = New DataDynamics.ActiveReports.Label
        Me.lblDireccionFiador = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.rtbEncabezado = New DataDynamics.ActiveReports.RichTextBox
        Me.rtbPie = New DataDynamics.ActiveReports.RichTextBox
        Me.PageBreak1 = New DataDynamics.ActiveReports.PageBreak
        Me.lblAnulada = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFianza, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaPagare, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCuotas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreFiador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFirmaFiador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedulaFiador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccionFiador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReporte})
        Me.PageHeader1.Height = 0.6979167!
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
        Me.SubReporte.Left = 0.0625!
        Me.SubReporte.Name = "SubReporte"
        Me.SubReporte.Report = Nothing
        Me.SubReporte.ReportName = "SubReport1"
        Me.SubReporte.Top = 0.0!
        Me.SubReporte.Width = 7.4375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.txtNombre, Me.txtCedula, Me.txtDireccion, Me.Line4, Me.Line5, Me.Line6})
        Me.Detail1.Height = 0.5520833!
        Me.Detail1.Name = "Detail1"
        '
        'Shape2
        '
        Me.Shape2.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape2.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape2.Border.RightColor = System.Drawing.Color.Black
        Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape2.Border.TopColor = System.Drawing.Color.Black
        Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Height = 0.5625!
        Me.Shape2.Left = 0.0625!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 7.375!
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
        Me.txtNombre.DataField = "Socia"
        Me.txtNombre.Height = 0.5!
        Me.txtNombre.Left = 0.125!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombre.Text = Nothing
        Me.txtNombre.Top = 0.0!
        Me.txtNombre.Width = 1.6875!
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
        Me.txtCedula.DataField = "sDireccionSocia"
        Me.txtCedula.Height = 0.5!
        Me.txtCedula.Left = 1.875!
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Style = "ddo-char-set: 0; text-align: justify; font-size: 8.25pt; vertical-align: middle; " & _
            ""
        Me.txtCedula.Text = Nothing
        Me.txtCedula.Top = 0.0!
        Me.txtCedula.Width = 2.375!
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
        Me.txtDireccion.CanGrow = False
        Me.txtDireccion.DataField = "sNumeroCedula"
        Me.txtDireccion.Height = 0.375!
        Me.txtDireccion.Left = 4.375!
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDireccion.Text = Nothing
        Me.txtDireccion.Top = 0.0!
        Me.txtDireccion.Width = 1.1875!
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
        Me.Line4.Height = 0.55!
        Me.Line4.Left = 5.625!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.01041635!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 5.625!
        Me.Line4.X2 = 5.625!
        Me.Line4.Y1 = 0.01041635!
        Me.Line4.Y2 = 0.5604163!
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
        Me.Line5.Height = 0.55!
        Me.Line5.Left = 1.8125!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.01041635!
        Me.Line5.Width = 0.0!
        Me.Line5.X1 = 1.8125!
        Me.Line5.X2 = 1.8125!
        Me.Line5.Y1 = 0.01041635!
        Me.Line5.Y2 = 0.5604163!
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
        Me.Line6.Height = 0.55!
        Me.Line6.Left = 4.3125!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.01041635!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 4.3125!
        Me.Line6.X2 = 4.3125!
        Me.Line6.Y1 = 0.01041635!
        Me.Line6.Y2 = 0.5604163!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
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
        Me.grpGrupo.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblFianza, Me.lblFirmaPagare, Me.shpEncabezado, Me.lblCuotas, Me.lblNumero, Me.lblTitulo, Me.Shape1, Me.lblNombreFiador, Me.lblFirmaFiador, Me.Line1, Me.Line2, Me.lblCedulaFiador, Me.lblDireccionFiador, Me.Line3, Me.rtbEncabezado, Me.rtbPie, Me.PageBreak1, Me.lblAnulada})
        Me.grpGrupo.DataField = "nSclFichaNotificacionID"
        Me.grpGrupo.Height = 10.47917!
        Me.grpGrupo.Name = "grpGrupo"
        '
        'lblFianza
        '
        Me.lblFianza.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFianza.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFianza.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFianza.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFianza.Border.RightColor = System.Drawing.Color.Black
        Me.lblFianza.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFianza.Border.TopColor = System.Drawing.Color.Black
        Me.lblFianza.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFianza.Height = 0.25!
        Me.lblFianza.HyperLink = Nothing
        Me.lblFianza.Left = 0.0625!
        Me.lblFianza.Name = "lblFianza"
        Me.lblFianza.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 15.75pt; verti" & _
            "cal-align: middle; "
        Me.lblFianza.Text = "FIANZA SOLIDARIA"
        Me.lblFianza.Top = 7.625!
        Me.lblFianza.Width = 7.3125!
        '
        'lblFirmaPagare
        '
        Me.lblFirmaPagare.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFirmaPagare.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaPagare.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFirmaPagare.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaPagare.Border.RightColor = System.Drawing.Color.Black
        Me.lblFirmaPagare.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaPagare.Border.TopColor = System.Drawing.Color.Black
        Me.lblFirmaPagare.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaPagare.Height = 0.25!
        Me.lblFirmaPagare.HyperLink = Nothing
        Me.lblFirmaPagare.Left = 0.125!
        Me.lblFirmaPagare.Name = "lblFirmaPagare"
        Me.lblFirmaPagare.Style = "ddo-char-set: 0; text-align: justify; font-size: 12pt; "
        Me.lblFirmaPagare.Text = "Firmamos en la Ciudad de..."
        Me.lblFirmaPagare.Top = 9.875!
        Me.lblFirmaPagare.Width = 7.3125!
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
        Me.shpEncabezado.Left = 5.375!
        Me.shpEncabezado.Name = "shpEncabezado"
        Me.shpEncabezado.RoundingRadius = 9.999999!
        Me.shpEncabezado.Top = 0.25!
        Me.shpEncabezado.Width = 2.125!
        '
        'lblCuotas
        '
        Me.lblCuotas.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCuotas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCuotas.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCuotas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCuotas.Border.RightColor = System.Drawing.Color.Black
        Me.lblCuotas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCuotas.Border.TopColor = System.Drawing.Color.Black
        Me.lblCuotas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCuotas.Height = 0.1875!
        Me.lblCuotas.HyperLink = Nothing
        Me.lblCuotas.Left = 5.4375!
        Me.lblCuotas.Name = "lblCuotas"
        Me.lblCuotas.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblCuotas.Text = "PAGO EN CUOTAS"
        Me.lblCuotas.Top = 0.3125!
        Me.lblCuotas.Width = 2.0!
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
        Me.lblNumero.Left = 0.0625!
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Style = "color: Navy; ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 1" & _
            "5.75pt; vertical-align: middle; "
        Me.lblNumero.Text = "No. 1"
        Me.lblNumero.Top = 1.25!
        Me.lblNumero.Width = 7.4375!
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
        Me.lblTitulo.Left = 0.0625!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 15.75pt; verti" & _
            "cal-align: middle; "
        Me.lblTitulo.Text = "PAGARE A LA ORDEN CAUSAL"
        Me.lblTitulo.Top = 0.9375!
        Me.lblTitulo.Width = 7.4375!
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
        Me.Shape1.Height = 0.28!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 10.1875!
        Me.Shape1.Width = 7.375!
        '
        'lblNombreFiador
        '
        Me.lblNombreFiador.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombreFiador.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreFiador.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombreFiador.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreFiador.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombreFiador.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreFiador.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombreFiador.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreFiador.Height = 0.1875!
        Me.lblNombreFiador.HyperLink = Nothing
        Me.lblNombreFiador.Left = 0.125!
        Me.lblNombreFiador.Name = "lblNombreFiador"
        Me.lblNombreFiador.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblNombreFiador.Text = "Nombre Fiador"
        Me.lblNombreFiador.Top = 10.25!
        Me.lblNombreFiador.Width = 1.6875!
        '
        'lblFirmaFiador
        '
        Me.lblFirmaFiador.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFirmaFiador.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaFiador.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFirmaFiador.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaFiador.Border.RightColor = System.Drawing.Color.Black
        Me.lblFirmaFiador.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaFiador.Border.TopColor = System.Drawing.Color.Black
        Me.lblFirmaFiador.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFirmaFiador.Height = 0.1875!
        Me.lblFirmaFiador.HyperLink = Nothing
        Me.lblFirmaFiador.Left = 5.625!
        Me.lblFirmaFiador.Name = "lblFirmaFiador"
        Me.lblFirmaFiador.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblFirmaFiador.Text = "Firma"
        Me.lblFirmaFiador.Top = 10.25!
        Me.lblFirmaFiador.Width = 1.75!
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
        Me.Line1.Height = 0.2725!
        Me.Line1.Left = 5.625!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 10.1875!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 5.625!
        Me.Line1.X2 = 5.625!
        Me.Line1.Y1 = 10.1875!
        Me.Line1.Y2 = 10.46!
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
        Me.Line2.Height = 0.2725!
        Me.Line2.Left = 1.8125!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 10.1875!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 1.8125!
        Me.Line2.X2 = 1.8125!
        Me.Line2.Y1 = 10.1875!
        Me.Line2.Y2 = 10.46!
        '
        'lblCedulaFiador
        '
        Me.lblCedulaFiador.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCedulaFiador.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaFiador.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCedulaFiador.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaFiador.Border.RightColor = System.Drawing.Color.Black
        Me.lblCedulaFiador.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaFiador.Border.TopColor = System.Drawing.Color.Black
        Me.lblCedulaFiador.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedulaFiador.Height = 0.1875!
        Me.lblCedulaFiador.HyperLink = Nothing
        Me.lblCedulaFiador.Left = 4.375!
        Me.lblCedulaFiador.Name = "lblCedulaFiador"
        Me.lblCedulaFiador.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblCedulaFiador.Text = "Cédula"
        Me.lblCedulaFiador.Top = 10.25!
        Me.lblCedulaFiador.Width = 1.1875!
        '
        'lblDireccionFiador
        '
        Me.lblDireccionFiador.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDireccionFiador.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionFiador.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDireccionFiador.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionFiador.Border.RightColor = System.Drawing.Color.Black
        Me.lblDireccionFiador.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionFiador.Border.TopColor = System.Drawing.Color.Black
        Me.lblDireccionFiador.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionFiador.Height = 0.1875!
        Me.lblDireccionFiador.HyperLink = Nothing
        Me.lblDireccionFiador.Left = 1.875!
        Me.lblDireccionFiador.Name = "lblDireccionFiador"
        Me.lblDireccionFiador.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblDireccionFiador.Text = "Dirección"
        Me.lblDireccionFiador.Top = 10.25!
        Me.lblDireccionFiador.Width = 2.375!
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
        Me.Line3.Height = 0.2725!
        Me.Line3.Left = 4.3125!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 10.1875!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 4.3125!
        Me.Line3.X2 = 4.3125!
        Me.Line3.Y1 = 10.1875!
        Me.Line3.Y2 = 10.46!
        '
        'rtbEncabezado
        '
        Me.rtbEncabezado.AutoReplaceFields = True
        Me.rtbEncabezado.BackColor = System.Drawing.Color.Transparent
        Me.rtbEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.rtbEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.rtbEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.rtbEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.rtbEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbEncabezado.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.rtbEncabezado.ForeColor = System.Drawing.Color.Black
        Me.rtbEncabezado.Height = 5.9375!
        Me.rtbEncabezado.Left = 0.0625!
        Me.rtbEncabezado.Name = "rtbEncabezado"
        Me.rtbEncabezado.RTF = resources.GetString("rtbEncabezado.RTF")
        Me.rtbEncabezado.Top = 1.625!
        Me.rtbEncabezado.Width = 7.3125!
        '
        'rtbPie
        '
        Me.rtbPie.AutoReplaceFields = True
        Me.rtbPie.BackColor = System.Drawing.Color.Transparent
        Me.rtbPie.Border.BottomColor = System.Drawing.Color.Black
        Me.rtbPie.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbPie.Border.LeftColor = System.Drawing.Color.Black
        Me.rtbPie.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbPie.Border.RightColor = System.Drawing.Color.Black
        Me.rtbPie.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbPie.Border.TopColor = System.Drawing.Color.Black
        Me.rtbPie.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.rtbPie.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.rtbPie.ForeColor = System.Drawing.Color.Black
        Me.rtbPie.Height = 2.1875!
        Me.rtbPie.Left = 0.0625!
        Me.rtbPie.Name = "rtbPie"
        Me.rtbPie.RTF = resources.GetString("rtbPie.RTF")
        Me.rtbPie.Top = 7.625!
        Me.rtbPie.Width = 7.3125!
        '
        'PageBreak1
        '
        Me.PageBreak1.Border.BottomColor = System.Drawing.Color.Black
        Me.PageBreak1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PageBreak1.Border.LeftColor = System.Drawing.Color.Black
        Me.PageBreak1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PageBreak1.Border.RightColor = System.Drawing.Color.Black
        Me.PageBreak1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PageBreak1.Border.TopColor = System.Drawing.Color.Black
        Me.PageBreak1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PageBreak1.Height = 0.125!
        Me.PageBreak1.Left = 0.0!
        Me.PageBreak1.Name = "PageBreak1"
        Me.PageBreak1.Size = New System.Drawing.SizeF(6.5!, 0.125!)
        Me.PageBreak1.Top = 7.5625!
        Me.PageBreak1.Width = 6.5!
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
        Me.lblAnulada.Style = "color: Crimson; ddo-char-set: 0; text-align: center; font-weight: bold; font-size" & _
            ": 20.25pt; vertical-align: middle; "
        Me.lblAnulada.Text = "ANULADO"
        Me.lblAnulada.Top = 0.25!
        Me.lblAnulada.Visible = False
        Me.lblAnulada.Width = 7.4375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptSclPagare
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
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFianza, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaPagare, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCuotas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreFiador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFirmaFiador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedulaFiador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccionFiador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAnulada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents txtNombre As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents grpGrupo As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtDireccion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFianza As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaPagare As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents shpEncabezado As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblCuotas As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblNombreFiador As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFirmaFiador As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblCedulaFiador As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDireccionFiador As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents rtbEncabezado As DataDynamics.ActiveReports.RichTextBox
    Friend WithEvents rtbPie As DataDynamics.ActiveReports.RichTextBox
    Friend WithEvents PageBreak1 As DataDynamics.ActiveReports.PageBreak
    Friend WithEvents lblAnulada As DataDynamics.ActiveReports.Label
End Class
