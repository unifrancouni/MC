<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclLstSocias
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclLstSocias))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.lblCedula = New DataDynamics.ActiveReports.Label
        Me.lblNombre = New DataDynamics.ActiveReports.Label
        Me.lblCodigo = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.lblDomicilio = New DataDynamics.ActiveReports.Label
        Me.lblTelefono = New DataDynamics.ActiveReports.Label
        Me.lblPrimaria = New DataDynamics.ActiveReports.Label
        Me.lblActivo = New DataDynamics.ActiveReports.Label
        Me.lblCodRpt = New DataDynamics.ActiveReports.Label
        Me.lblAlfabetizada = New DataDynamics.ActiveReports.Label
        Me.lblSecundaria = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.txtCedula = New DataDynamics.ActiveReports.TextBox
        Me.txtDomicilio = New DataDynamics.ActiveReports.TextBox
        Me.txtPrimaria = New DataDynamics.ActiveReports.TextBox
        Me.ChkActivo = New DataDynamics.ActiveReports.CheckBox
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox
        Me.txtTelefono = New DataDynamics.ActiveReports.TextBox
        Me.ChkAlfabetizada = New DataDynamics.ActiveReports.CheckBox
        Me.txtSecundaria = New DataDynamics.ActiveReports.TextBox
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.rptInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.lblParametro = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro2 = New DataDynamics.ActiveReports.TextBox
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPrimaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAlfabetizada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSecundaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPrimaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkAlfabetizada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSecundaria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rptInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReporte, Me.lblTitulo, Me.lblCedula, Me.lblNombre, Me.lblCodigo, Me.Line1, Me.Line2, Me.lblDomicilio, Me.lblTelefono, Me.lblPrimaria, Me.lblActivo, Me.lblCodRpt, Me.lblAlfabetizada, Me.lblSecundaria})
        Me.PageHeader1.Height = 1.416667!
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
        Me.SubReporte.Top = 0.04166667!
        Me.SubReporte.Width = 9.958333!
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
        Me.lblTitulo.Height = 0.2083333!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.0!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblTitulo.Text = "Listado de Socias del Programa"
        Me.lblTitulo.Top = 0.75!
        Me.lblTitulo.Width = 9.958333!
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
        Me.lblCedula.Height = 0.25!
        Me.lblCedula.HyperLink = Nothing
        Me.lblCedula.Left = 2.4375!
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCedula.Text = "Cédula"
        Me.lblCedula.Top = 1.125!
        Me.lblCedula.Width = 1.125!
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
        Me.lblNombre.Height = 0.25!
        Me.lblNombre.HyperLink = Nothing
        Me.lblNombre.Left = 0.5!
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblNombre.Text = "Nombre"
        Me.lblNombre.Top = 1.125!
        Me.lblNombre.Width = 1.9375!
        '
        'lblCodigo
        '
        Me.lblCodigo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigo.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigo.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigo.Height = 0.25!
        Me.lblCodigo.HyperLink = Nothing
        Me.lblCodigo.Left = 0.0625!
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCodigo.Text = "Cód."
        Me.lblCodigo.Top = 1.125!
        Me.lblCodigo.Width = 0.4375!
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
        Me.Line1.Height = 0.0!
        Me.Line1.Left = 0.0!
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 1.104168!
        Me.Line1.Width = 10.1!
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 10.1!
        Me.Line1.Y1 = 1.104168!
        Me.Line1.Y2 = 1.104168!
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
        Me.Line2.Left = 0.02085498!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.395833!
        Me.Line2.Width = 10.10001!
        Me.Line2.X1 = 0.02085498!
        Me.Line2.X2 = 10.12086!
        Me.Line2.Y1 = 1.395833!
        Me.Line2.Y2 = 1.395833!
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDomicilio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDomicilio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDomicilio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDomicilio.Border.RightColor = System.Drawing.Color.Black
        Me.lblDomicilio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDomicilio.Border.TopColor = System.Drawing.Color.Black
        Me.lblDomicilio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDomicilio.Height = 0.25!
        Me.lblDomicilio.HyperLink = Nothing
        Me.lblDomicilio.Left = 3.5625!
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDomicilio.Text = "Domicilio"
        Me.lblDomicilio.Top = 1.125!
        Me.lblDomicilio.Width = 2.375!
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
        Me.lblTelefono.Height = 0.25!
        Me.lblTelefono.HyperLink = Nothing
        Me.lblTelefono.Left = 5.9375!
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblTelefono.Text = "Teléfono"
        Me.lblTelefono.Top = 1.125!
        Me.lblTelefono.Width = 0.8125!
        '
        'lblPrimaria
        '
        Me.lblPrimaria.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPrimaria.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrimaria.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPrimaria.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrimaria.Border.RightColor = System.Drawing.Color.Black
        Me.lblPrimaria.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrimaria.Border.TopColor = System.Drawing.Color.Black
        Me.lblPrimaria.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPrimaria.Height = 0.25!
        Me.lblPrimaria.HyperLink = Nothing
        Me.lblPrimaria.Left = 6.75!
        Me.lblPrimaria.Name = "lblPrimaria"
        Me.lblPrimaria.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblPrimaria.Text = "Primaria"
        Me.lblPrimaria.Top = 1.125!
        Me.lblPrimaria.Width = 0.9375!
        '
        'lblActivo
        '
        Me.lblActivo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblActivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblActivo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblActivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblActivo.Border.RightColor = System.Drawing.Color.Black
        Me.lblActivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblActivo.Border.TopColor = System.Drawing.Color.Black
        Me.lblActivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblActivo.Height = 0.25!
        Me.lblActivo.HyperLink = Nothing
        Me.lblActivo.Left = 9.5!
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblActivo.Text = "¿Activa?"
        Me.lblActivo.Top = 1.125!
        Me.lblActivo.Width = 0.5416667!
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
        Me.lblCodRpt.Left = 7.875!
        Me.lblCodRpt.Name = "lblCodRpt"
        Me.lblCodRpt.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.lblCodRpt.Text = "CS8"
        Me.lblCodRpt.Top = 0.375!
        Me.lblCodRpt.Width = 0.6875!
        '
        'lblAlfabetizada
        '
        Me.lblAlfabetizada.Border.BottomColor = System.Drawing.Color.Black
        Me.lblAlfabetizada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAlfabetizada.Border.LeftColor = System.Drawing.Color.Black
        Me.lblAlfabetizada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAlfabetizada.Border.RightColor = System.Drawing.Color.Black
        Me.lblAlfabetizada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAlfabetizada.Border.TopColor = System.Drawing.Color.Black
        Me.lblAlfabetizada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblAlfabetizada.Height = 0.25!
        Me.lblAlfabetizada.HyperLink = Nothing
        Me.lblAlfabetizada.Left = 8.625!
        Me.lblAlfabetizada.Name = "lblAlfabetizada"
        Me.lblAlfabetizada.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblAlfabetizada.Text = "¿Alfabetizada?"
        Me.lblAlfabetizada.Top = 1.125!
        Me.lblAlfabetizada.Width = 0.875!
        '
        'lblSecundaria
        '
        Me.lblSecundaria.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSecundaria.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSecundaria.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSecundaria.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSecundaria.Border.RightColor = System.Drawing.Color.Black
        Me.lblSecundaria.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSecundaria.Border.TopColor = System.Drawing.Color.Black
        Me.lblSecundaria.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSecundaria.Height = 0.25!
        Me.lblSecundaria.HyperLink = Nothing
        Me.lblSecundaria.Left = 7.6875!
        Me.lblSecundaria.Name = "lblSecundaria"
        Me.lblSecundaria.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblSecundaria.Text = "Secundaria"
        Me.lblSecundaria.Top = 1.125!
        Me.lblSecundaria.Width = 0.9375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtCedula, Me.txtDomicilio, Me.txtPrimaria, Me.ChkActivo, Me.txtNombre, Me.txtTelefono, Me.ChkAlfabetizada, Me.txtSecundaria, Me.Line4})
        Me.Detail1.Height = 0.3229167!
        Me.Detail1.Name = "Detail1"
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
        Me.txtCodigo.DataField = "nCodigo"
        Me.txtCodigo.Height = 0.3125!
        Me.txtCodigo.Left = 0.0625!
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.Top = 0.0!
        Me.txtCodigo.Width = 0.4375!
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
        Me.txtCedula.DataField = "sNumeroCedula"
        Me.txtCedula.Height = 0.3125!
        Me.txtCedula.Left = 2.4375!
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCedula.Text = Nothing
        Me.txtCedula.Top = 0.0!
        Me.txtCedula.Width = 1.125!
        '
        'txtDomicilio
        '
        Me.txtDomicilio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDomicilio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDomicilio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDomicilio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDomicilio.Border.RightColor = System.Drawing.Color.Black
        Me.txtDomicilio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDomicilio.Border.TopColor = System.Drawing.Color.Black
        Me.txtDomicilio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDomicilio.CanGrow = False
        Me.txtDomicilio.DataField = "sDireccionSocia"
        Me.txtDomicilio.Height = 0.3125!
        Me.txtDomicilio.Left = 3.5625!
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDomicilio.Text = Nothing
        Me.txtDomicilio.Top = 0.0!
        Me.txtDomicilio.Width = 2.375!
        '
        'txtPrimaria
        '
        Me.txtPrimaria.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPrimaria.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPrimaria.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPrimaria.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPrimaria.Border.RightColor = System.Drawing.Color.Black
        Me.txtPrimaria.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPrimaria.Border.TopColor = System.Drawing.Color.Black
        Me.txtPrimaria.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPrimaria.CanGrow = False
        Me.txtPrimaria.DataField = "Primaria"
        Me.txtPrimaria.Height = 0.3125!
        Me.txtPrimaria.Left = 6.75!
        Me.txtPrimaria.Name = "txtPrimaria"
        Me.txtPrimaria.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPrimaria.Text = Nothing
        Me.txtPrimaria.Top = 0.0!
        Me.txtPrimaria.Width = 0.9375!
        '
        'ChkActivo
        '
        Me.ChkActivo.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkActivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkActivo.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkActivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkActivo.Border.RightColor = System.Drawing.Color.Black
        Me.ChkActivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkActivo.Border.TopColor = System.Drawing.Color.Black
        Me.ChkActivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkActivo.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkActivo.DataField = "nSociaActiva"
        Me.ChkActivo.Height = 0.2083333!
        Me.ChkActivo.Left = 9.625!
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ChkActivo.Text = ""
        Me.ChkActivo.Top = 0.0!
        Me.ChkActivo.Width = 0.2083333!
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
        Me.txtNombre.DataField = "Nombre"
        Me.txtNombre.Height = 0.3125!
        Me.txtNombre.Left = 0.5!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombre.Text = Nothing
        Me.txtNombre.Top = 0.0!
        Me.txtNombre.Width = 1.9375!
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
        Me.txtTelefono.CanGrow = False
        Me.txtTelefono.DataField = "sTelefonoSocia"
        Me.txtTelefono.Height = 0.3125!
        Me.txtTelefono.Left = 5.9375!
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTelefono.Text = Nothing
        Me.txtTelefono.Top = 0.0!
        Me.txtTelefono.Width = 0.8125!
        '
        'ChkAlfabetizada
        '
        Me.ChkAlfabetizada.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkAlfabetizada.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkAlfabetizada.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkAlfabetizada.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkAlfabetizada.Border.RightColor = System.Drawing.Color.Black
        Me.ChkAlfabetizada.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkAlfabetizada.Border.TopColor = System.Drawing.Color.Black
        Me.ChkAlfabetizada.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkAlfabetizada.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkAlfabetizada.DataField = "nAlfabetizada"
        Me.ChkAlfabetizada.Height = 0.2083333!
        Me.ChkAlfabetizada.Left = 8.9375!
        Me.ChkAlfabetizada.Name = "ChkAlfabetizada"
        Me.ChkAlfabetizada.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ChkAlfabetizada.Text = ""
        Me.ChkAlfabetizada.Top = 0.0!
        Me.ChkAlfabetizada.Width = 0.2083333!
        '
        'txtSecundaria
        '
        Me.txtSecundaria.Border.BottomColor = System.Drawing.Color.Black
        Me.txtSecundaria.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSecundaria.Border.LeftColor = System.Drawing.Color.Black
        Me.txtSecundaria.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSecundaria.Border.RightColor = System.Drawing.Color.Black
        Me.txtSecundaria.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSecundaria.Border.TopColor = System.Drawing.Color.Black
        Me.txtSecundaria.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSecundaria.CanGrow = False
        Me.txtSecundaria.DataField = "Secundaria"
        Me.txtSecundaria.Height = 0.3125!
        Me.txtSecundaria.Left = 7.6875!
        Me.txtSecundaria.Name = "txtSecundaria"
        Me.txtSecundaria.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtSecundaria.Text = Nothing
        Me.txtSecundaria.Top = 0.0!
        Me.txtSecundaria.Width = 0.9375!
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
        Me.Line4.Height = 0.0!
        Me.Line4.Left = 0.0!
        Me.Line4.LineColor = System.Drawing.Color.DarkGray
        Me.Line4.LineWeight = 0.5!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.3125!
        Me.Line4.Width = 10.125!
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 10.125!
        Me.Line4.Y1 = 0.3125!
        Me.Line4.Y2 = 0.3125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.rptInfo1, Me.Line3, Me.lblParametro, Me.txtparametro1, Me.txtparametro2, Me.lblUsuario, Me.txtHora, Me.txtUsuario, Me.txtFecha})
        Me.PageFooter1.Height = 0.3854167!
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
        Me.rptInfo1.Height = 0.3125!
        Me.rptInfo1.Left = 4.625!
        Me.rptInfo1.Name = "rptInfo1"
        Me.rptInfo1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.rptInfo1.Top = 0.0625!
        Me.rptInfo1.Width = 1.0!
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
        Me.Line3.Height = 0.01041667!
        Me.Line3.Left = 0.00002164518!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.0!
        Me.Line3.Width = 10.06249!
        Me.Line3.X1 = 0.00002164518!
        Me.Line3.X2 = 10.06251!
        Me.Line3.Y1 = 0.0!
        Me.Line3.Y2 = 0.01041667!
        '
        'lblParametro
        '
        Me.lblParametro.Border.BottomColor = System.Drawing.Color.Black
        Me.lblParametro.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblParametro.Border.LeftColor = System.Drawing.Color.Black
        Me.lblParametro.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblParametro.Border.RightColor = System.Drawing.Color.Black
        Me.lblParametro.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblParametro.Border.TopColor = System.Drawing.Color.Black
        Me.lblParametro.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblParametro.Height = 0.1875!
        Me.lblParametro.Left = 0.0!
        Me.lblParametro.Name = "lblParametro"
        Me.lblParametro.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblParametro.Text = "Parámetros:"
        Me.lblParametro.Top = 0.0!
        Me.lblParametro.Width = 0.6875!
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
        Me.txtparametro1.Left = 0.6875!
        Me.txtparametro1.MultiLine = False
        Me.txtparametro1.Name = "txtparametro1"
        Me.txtparametro1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro1.Text = Nothing
        Me.txtparametro1.Top = 0.0!
        Me.txtparametro1.Width = 2.875!
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
        Me.txtparametro2.Left = 0.6875!
        Me.txtparametro2.Name = "txtparametro2"
        Me.txtparametro2.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro2.Text = Nothing
        Me.txtparametro2.Top = 0.1875!
        Me.txtparametro2.Width = 2.875!
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
        Me.lblUsuario.Left = 7.5625!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.Top = 0.0!
        Me.lblUsuario.Width = 0.5416667!
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
        Me.txtHora.Left = 8.989583!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
        Me.txtHora.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtHora.Text = Nothing
        Me.txtHora.Top = 0.1875!
        Me.txtHora.Width = 1.0!
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
        Me.txtUsuario.Left = 8.125!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.Top = 0.0!
        Me.txtUsuario.Width = 1.875!
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
        Me.txtFecha.Left = 8.25!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.1875!
        Me.txtFecha.Width = 0.6875!
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
        'rptSclLstSocias
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.13128!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPrimaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAlfabetizada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSecundaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPrimaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkAlfabetizada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSecundaria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rptInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblParametro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCedula As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombre As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCodigo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblDomicilio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPrimaria As DataDynamics.ActiveReports.Label
    Friend WithEvents lblActivo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombre As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDomicilio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTelefono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ChkActivo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents rptInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtPrimaria As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblParametro As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodRpt As DataDynamics.ActiveReports.Label
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblUsuario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAlfabetizada As DataDynamics.ActiveReports.Label
    Friend WithEvents ChkAlfabetizada As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents lblSecundaria As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSecundaria As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
End Class
