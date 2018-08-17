<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptStbMercado
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptStbMercado))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.lblNombre = New DataDynamics.ActiveReports.Label
        Me.lblCodigo = New DataDynamics.ActiveReports.Label
        Me.lblActivo = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.chkactivo = New DataDynamics.ActiveReports.CheckBox
        Me.txtDistrito = New DataDynamics.ActiveReports.TextBox
        Me.chkIncluidoPrograma = New DataDynamics.ActiveReports.CheckBox
        Me.txtBarrio = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtparametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro2 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.grpMunicipio = New DataDynamics.ActiveReports.GroupHeader
        Me.lblMunicipio = New DataDynamics.ActiveReports.Label
        Me.txtMunicipio = New DataDynamics.ActiveReports.TextBox
        Me.lblDistrito = New DataDynamics.ActiveReports.Label
        Me.lblPertenecePrograma = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.grpDepartamento = New DataDynamics.ActiveReports.GroupHeader
        Me.txtDepartamento = New DataDynamics.ActiveReports.TextBox
        Me.lblDepartamento = New DataDynamics.ActiveReports.Label
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkactivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkIncluidoPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPertenecePrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.Label1})
        Me.PageHeader1.Height = 0.9895833!
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
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblTitulo.Text = "Listado de Mercados"
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
        Me.Label1.Left = 5.4375!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.Label1.Text = "CB6"
        Me.Label1.Top = 0.1875!
        Me.Label1.Width = 1.0!
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
        Me.lblNombre.Left = 0.5625!
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblNombre.Text = "Nombre del Mercado"
        Me.lblNombre.Top = 0.375!
        Me.lblNombre.Width = 2.4375!
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
        Me.lblCodigo.Height = 0.1875!
        Me.lblCodigo.HyperLink = Nothing
        Me.lblCodigo.Left = 0.0625!
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.Top = 0.375!
        Me.lblCodigo.Width = 0.4375!
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
        Me.lblActivo.Height = 0.1875!
        Me.lblActivo.HyperLink = Nothing
        Me.lblActivo.Left = 6.875!
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblActivo.Text = "¿Activo?"
        Me.lblActivo.Top = 0.375!
        Me.lblActivo.Width = 0.5625!
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
        Me.Line1.Left = 0.03125!
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.3437501!
        Me.Line1.Width = 7.489583!
        Me.Line1.X1 = 0.03125!
        Me.Line1.X2 = 7.520833!
        Me.Line1.Y1 = 0.3437501!
        Me.Line1.Y2 = 0.3437501!
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
        Me.Line3.Left = 0.03125!
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.5833332!
        Me.Line3.Width = 7.489583!
        Me.Line3.X1 = 0.03125!
        Me.Line3.X2 = 7.520833!
        Me.Line3.Y1 = 0.5833332!
        Me.Line3.Y2 = 0.5833332!
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
        Me.Line4.Left = 0.03125!
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.3437501!
        Me.Line4.Width = 7.489583!
        Me.Line4.X1 = 0.03125!
        Me.Line4.X2 = 7.520833!
        Me.Line4.Y1 = 0.3437501!
        Me.Line4.Y2 = 0.3437501!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNombre, Me.txtCodigo, Me.chkactivo, Me.txtDistrito, Me.chkIncluidoPrograma, Me.txtBarrio})
        Me.Detail1.Height = 0.2291667!
        Me.Detail1.Name = "Detail1"
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
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 0.5625!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombre.Text = Nothing
        Me.txtNombre.Top = 0.0!
        Me.txtNombre.Width = 2.4375!
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
        Me.txtCodigo.Height = 0.1875!
        Me.txtCodigo.Left = 0.0625!
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.Top = 0.0!
        Me.txtCodigo.Width = 0.4375!
        '
        'chkactivo
        '
        Me.chkactivo.Border.BottomColor = System.Drawing.Color.Black
        Me.chkactivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkactivo.Border.LeftColor = System.Drawing.Color.Black
        Me.chkactivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkactivo.Border.RightColor = System.Drawing.Color.Black
        Me.chkactivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkactivo.Border.TopColor = System.Drawing.Color.Black
        Me.chkactivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkactivo.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkactivo.Height = 0.1875!
        Me.chkactivo.Left = 7.0!
        Me.chkactivo.Name = "chkactivo"
        Me.chkactivo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkactivo.Text = ""
        Me.chkactivo.Top = 0.0!
        Me.chkactivo.Width = 0.25!
        '
        'txtDistrito
        '
        Me.txtDistrito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Border.RightColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Border.TopColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Height = 0.1875!
        Me.txtDistrito.Left = 4.875!
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDistrito.Text = Nothing
        Me.txtDistrito.Top = 0.0!
        Me.txtDistrito.Width = 0.5625!
        '
        'chkIncluidoPrograma
        '
        Me.chkIncluidoPrograma.Border.BottomColor = System.Drawing.Color.Black
        Me.chkIncluidoPrograma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkIncluidoPrograma.Border.LeftColor = System.Drawing.Color.Black
        Me.chkIncluidoPrograma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkIncluidoPrograma.Border.RightColor = System.Drawing.Color.Black
        Me.chkIncluidoPrograma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkIncluidoPrograma.Border.TopColor = System.Drawing.Color.Black
        Me.chkIncluidoPrograma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkIncluidoPrograma.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIncluidoPrograma.Height = 0.1875!
        Me.chkIncluidoPrograma.Left = 6.0!
        Me.chkIncluidoPrograma.Name = "chkIncluidoPrograma"
        Me.chkIncluidoPrograma.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkIncluidoPrograma.Text = ""
        Me.chkIncluidoPrograma.Top = 0.0!
        Me.chkIncluidoPrograma.Width = 0.25!
        '
        'txtBarrio
        '
        Me.txtBarrio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Border.RightColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Border.TopColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Height = 0.1875!
        Me.txtBarrio.Left = 3.0625!
        Me.txtBarrio.Name = "txtBarrio"
        Me.txtBarrio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtBarrio.Text = Nothing
        Me.txtBarrio.Top = 0.0!
        Me.txtBarrio.Width = 1.75!
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
        Me.txtparametro1.CanGrow = False
        Me.txtparametro1.Height = 0.1875!
        Me.txtparametro1.Left = 0.75!
        Me.txtparametro1.MultiLine = False
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
        Me.ReportInfo1.Left = 3.552083!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.ReportInfo1.Top = 0.0!
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
        Me.TextBox1.Width = 0.75!
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
        'grpMunicipio
        '
        Me.grpMunicipio.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblNombre, Me.lblCodigo, Me.lblActivo, Me.Line1, Me.Line3, Me.Line4, Me.lblMunicipio, Me.txtMunicipio, Me.lblDistrito, Me.lblPertenecePrograma, Me.Label2})
        Me.grpMunicipio.DataField = "nStbMunicipioID"
        Me.grpMunicipio.Height = 0.6041667!
        Me.grpMunicipio.KeepTogether = True
        Me.grpMunicipio.Name = "grpMunicipio"
        Me.grpMunicipio.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
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
        Me.lblMunicipio.Left = 0.0625!
        Me.lblMunicipio.MultiLine = False
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.Top = 0.0625!
        Me.lblMunicipio.Width = 0.8125!
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
        Me.txtMunicipio.Height = 0.1875!
        Me.txtMunicipio.Left = 1.0!
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.Top = 0.0625!
        Me.txtMunicipio.Width = 4.6875!
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
        Me.lblDistrito.Left = 4.875!
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDistrito.Text = "Distrito"
        Me.lblDistrito.Top = 0.375!
        Me.lblDistrito.Width = 0.5!
        '
        'lblPertenecePrograma
        '
        Me.lblPertenecePrograma.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPertenecePrograma.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPertenecePrograma.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPertenecePrograma.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPertenecePrograma.Border.RightColor = System.Drawing.Color.Black
        Me.lblPertenecePrograma.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPertenecePrograma.Border.TopColor = System.Drawing.Color.Black
        Me.lblPertenecePrograma.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPertenecePrograma.Height = 0.1875!
        Me.lblPertenecePrograma.HyperLink = Nothing
        Me.lblPertenecePrograma.Left = 5.4375!
        Me.lblPertenecePrograma.Name = "lblPertenecePrograma"
        Me.lblPertenecePrograma.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblPertenecePrograma.Text = "¿Incluido en Programa?"
        Me.lblPertenecePrograma.Top = 0.375!
        Me.lblPertenecePrograma.Width = 1.375!
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
        Me.Label2.Left = 3.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label2.Text = "Barrio"
        Me.Label2.Top = 0.375!
        Me.Label2.Width = 1.75!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'grpDepartamento
        '
        Me.grpDepartamento.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDepartamento, Me.lblDepartamento})
        Me.grpDepartamento.DataField = "nStbDepartamentoID"
        Me.grpDepartamento.Height = 0.25!
        Me.grpDepartamento.Name = "grpDepartamento"
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
        Me.txtDepartamento.Height = 0.1875!
        Me.txtDepartamento.Left = 1.0!
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.Top = 0.0!
        Me.txtDepartamento.Width = 4.6875!
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
        Me.lblDepartamento.Left = 0.0625!
        Me.lblDepartamento.MultiLine = False
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDepartamento.Text = "Departamento:"
        Me.lblDepartamento.Top = 0.0!
        Me.lblDepartamento.Width = 0.8125!
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'rptStbMercado
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.479167!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.grpDepartamento)
        Me.Sections.Add(Me.grpMunicipio)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.GroupFooter2)
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
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkactivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkIncluidoPrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPertenecePrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtNombre As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents chkactivo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblActivo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents grpMunicipio As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblMunicipio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMunicipio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents grpDepartamento As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtDepartamento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDepartamento As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtDistrito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDistrito As DataDynamics.ActiveReports.Label
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPertenecePrograma As DataDynamics.ActiveReports.Label
    Friend WithEvents chkIncluidoPrograma As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents txtBarrio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
End Class
