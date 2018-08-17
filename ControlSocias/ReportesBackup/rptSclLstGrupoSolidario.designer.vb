<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclLstGrupoSolidario
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclLstGrupoSolidario))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.lblCodRpt = New DataDynamics.ActiveReports.Label
        Me.lblNombreGS = New DataDynamics.ActiveReports.Label
        Me.lblCodigo = New DataDynamics.ActiveReports.Label
        Me.lblEstado = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.lblMunicipio = New DataDynamics.ActiveReports.Label
        Me.lblCoordinadora = New DataDynamics.ActiveReports.Label
        Me.lblDepartamento = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.ChkCoordinadora = New DataDynamics.ActiveReports.CheckBox
        Me.txtCodigoSocia = New DataDynamics.ActiveReports.TextBox
        Me.txtNombreSocia = New DataDynamics.ActiveReports.TextBox
        Me.txtCedula = New DataDynamics.ActiveReports.TextBox
        Me.txtDomicilio = New DataDynamics.ActiveReports.TextBox
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.txtEstado = New DataDynamics.ActiveReports.TextBox
        Me.txtDepartamento = New DataDynamics.ActiveReports.TextBox
        Me.txtMunicipio = New DataDynamics.ActiveReports.TextBox
        Me.txtDistrito = New DataDynamics.ActiveReports.TextBox
        Me.txtMercado = New DataDynamics.ActiveReports.TextBox
        Me.txtNombreGS = New DataDynamics.ActiveReports.TextBox
        Me.txtBarrio = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.rptInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.lblParametro = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro2 = New DataDynamics.ActiveReports.TextBox
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro1 = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblDistrito = New DataDynamics.ActiveReports.Label
        Me.lblBarrio = New DataDynamics.ActiveReports.Label
        Me.lblMercado = New DataDynamics.ActiveReports.Label
        Me.lblCodigoSocia = New DataDynamics.ActiveReports.Label
        Me.lblSocia = New DataDynamics.ActiveReports.Label
        Me.lblCedula = New DataDynamics.ActiveReports.Label
        Me.lblDomicilio = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkCoordinadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEstado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMercado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rptInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMercado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReporte, Me.lblTitulo, Me.lblCodRpt})
        Me.PageHeader1.Height = 0.9791667!
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
        Me.lblTitulo.Text = "Listado de Grupos Solidarios"
        Me.lblTitulo.Top = 0.75!
        Me.lblTitulo.Width = 9.958333!
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
        Me.lblCodRpt.Text = "CS7"
        Me.lblCodRpt.Top = 0.375!
        Me.lblCodRpt.Width = 0.6875!
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
        Me.lblNombreGS.Left = 0.1875!
        Me.lblNombreGS.Name = "lblNombreGS"
        Me.lblNombreGS.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblNombreGS.Text = "Nombre Grupo:"
        Me.lblNombreGS.Top = 0.3125!
        Me.lblNombreGS.Width = 1.0!
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
        Me.lblCodigo.Left = 0.1875!
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCodigo.Text = "Código Grupo:"
        Me.lblCodigo.Top = 0.125!
        Me.lblCodigo.Width = 1.0!
        '
        'lblEstado
        '
        Me.lblEstado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblEstado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEstado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblEstado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEstado.Border.RightColor = System.Drawing.Color.Black
        Me.lblEstado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEstado.Border.TopColor = System.Drawing.Color.Black
        Me.lblEstado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEstado.Height = 0.1875!
        Me.lblEstado.HyperLink = Nothing
        Me.lblEstado.Left = 0.1875!
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblEstado.Text = "Estado Grupo:"
        Me.lblEstado.Top = 0.5!
        Me.lblEstado.Width = 1.0!
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
        Me.Line1.Left = 0.0625!
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.7916681!
        Me.Line1.Width = 9.975!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 10.0375!
        Me.Line1.Y1 = 0.7916681!
        Me.Line1.Y2 = 0.7916681!
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
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 1.083333!
        Me.Line2.Width = 9.99586!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 10.05836!
        Me.Line2.Y1 = 1.083333!
        Me.Line2.Y2 = 1.083333!
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
        Me.lblMunicipio.Left = 4.0625!
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.Top = 0.3125!
        Me.lblMunicipio.Width = 0.9375!
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
        Me.lblCoordinadora.Height = 0.25!
        Me.lblCoordinadora.HyperLink = Nothing
        Me.lblCoordinadora.Left = 8.9375!
        Me.lblCoordinadora.Name = "lblCoordinadora"
        Me.lblCoordinadora.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblCoordinadora.Text = "¿Coordinadora?"
        Me.lblCoordinadora.Top = 0.8125!
        Me.lblCoordinadora.Width = 1.0625!
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
        Me.lblDepartamento.Left = 4.0625!
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Style = "ddo-char-set: 0; text-align: justify; font-weight: bold; font-size: 8.25pt; verti" & _
            "cal-align: middle; "
        Me.lblDepartamento.Text = "Departamento:"
        Me.lblDepartamento.Top = 0.125!
        Me.lblDepartamento.Width = 0.9375!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ChkCoordinadora, Me.txtCodigoSocia, Me.txtNombreSocia, Me.txtCedula, Me.txtDomicilio})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'ChkCoordinadora
        '
        Me.ChkCoordinadora.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkCoordinadora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCoordinadora.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkCoordinadora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCoordinadora.Border.RightColor = System.Drawing.Color.Black
        Me.ChkCoordinadora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCoordinadora.Border.TopColor = System.Drawing.Color.Black
        Me.ChkCoordinadora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCoordinadora.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkCoordinadora.DataField = "nCoordinador"
        Me.ChkCoordinadora.Height = 0.2083333!
        Me.ChkCoordinadora.Left = 9.375!
        Me.ChkCoordinadora.Name = "ChkCoordinadora"
        Me.ChkCoordinadora.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.ChkCoordinadora.Text = ""
        Me.ChkCoordinadora.Top = 0.0!
        Me.ChkCoordinadora.Width = 0.2083333!
        '
        'txtCodigoSocia
        '
        Me.txtCodigoSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodigoSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigoSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodigoSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigoSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodigoSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigoSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodigoSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigoSocia.CanGrow = False
        Me.txtCodigoSocia.DataField = "CodigoSocia"
        Me.txtCodigoSocia.Height = 0.1875!
        Me.txtCodigoSocia.Left = 0.1875!
        Me.txtCodigoSocia.Name = "txtCodigoSocia"
        Me.txtCodigoSocia.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodigoSocia.Text = Nothing
        Me.txtCodigoSocia.Top = 0.0!
        Me.txtCodigoSocia.Width = 0.5!
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreSocia.CanGrow = False
        Me.txtNombreSocia.DataField = "NombreSocia"
        Me.txtNombreSocia.Height = 0.1875!
        Me.txtNombreSocia.Left = 0.75!
        Me.txtNombreSocia.MultiLine = False
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.Style = "ddo-char-set: 0; font-size: 8.25pt; white-space: nowrap; vertical-align: middle; " & _
            ""
        Me.txtNombreSocia.Text = Nothing
        Me.txtNombreSocia.Top = 0.0!
        Me.txtNombreSocia.Width = 3.0625!
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
        Me.txtCedula.Height = 0.1875!
        Me.txtCedula.Left = 3.875!
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCedula.Text = Nothing
        Me.txtCedula.Top = 0.0!
        Me.txtCedula.Width = 1.3125!
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
        Me.txtDomicilio.Height = 0.1875!
        Me.txtDomicilio.Left = 5.1875!
        Me.txtDomicilio.MultiLine = False
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.Style = "ddo-char-set: 0; font-size: 8.25pt; white-space: nowrap; vertical-align: middle; " & _
            ""
        Me.txtDomicilio.Text = Nothing
        Me.txtDomicilio.Top = 0.0!
        Me.txtDomicilio.Width = 3.75!
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
        Me.txtCodigo.DataField = "sCodigo"
        Me.txtCodigo.Height = 0.1875!
        Me.txtCodigo.Left = 1.1875!
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.Top = 0.125!
        Me.txtCodigo.Width = 2.8125!
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
        Me.txtEstado.DataField = "Estado"
        Me.txtEstado.Height = 0.1875!
        Me.txtEstado.Left = 1.1875!
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtEstado.Text = Nothing
        Me.txtEstado.Top = 0.5!
        Me.txtEstado.Width = 2.8125!
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
        Me.txtDepartamento.Left = 5.0!
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.Top = 0.125!
        Me.txtDepartamento.Width = 2.0!
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
        Me.txtMunicipio.Left = 5.0!
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.OutputFormat = resources.GetString("txtMunicipio.OutputFormat")
        Me.txtMunicipio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.Top = 0.3125!
        Me.txtMunicipio.Width = 2.0!
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
        Me.txtDistrito.CanGrow = False
        Me.txtDistrito.DataField = "Distrito"
        Me.txtDistrito.Height = 0.1875!
        Me.txtDistrito.Left = 5.0!
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDistrito.Text = Nothing
        Me.txtDistrito.Top = 0.5!
        Me.txtDistrito.Width = 2.0!
        '
        'txtMercado
        '
        Me.txtMercado.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMercado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMercado.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMercado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMercado.Border.RightColor = System.Drawing.Color.Black
        Me.txtMercado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMercado.Border.TopColor = System.Drawing.Color.Black
        Me.txtMercado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMercado.CanGrow = False
        Me.txtMercado.DataField = "Mercado"
        Me.txtMercado.Height = 0.1875!
        Me.txtMercado.Left = 7.8125!
        Me.txtMercado.Name = "txtMercado"
        Me.txtMercado.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMercado.Text = Nothing
        Me.txtMercado.Top = 0.3125!
        Me.txtMercado.Width = 2.125!
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
        Me.txtNombreGS.DataField = "sDescripcion"
        Me.txtNombreGS.Height = 0.1875!
        Me.txtNombreGS.Left = 1.1875!
        Me.txtNombreGS.Name = "txtNombreGS"
        Me.txtNombreGS.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombreGS.Text = Nothing
        Me.txtNombreGS.Top = 0.3125!
        Me.txtNombreGS.Width = 2.8125!
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
        Me.txtBarrio.CanGrow = False
        Me.txtBarrio.DataField = "Barrio"
        Me.txtBarrio.Height = 0.1875!
        Me.txtBarrio.Left = 7.8125!
        Me.txtBarrio.Name = "txtBarrio"
        Me.txtBarrio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtBarrio.Text = Nothing
        Me.txtBarrio.Top = 0.125!
        Me.txtBarrio.Width = 2.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.rptInfo1, Me.Line3, Me.lblParametro, Me.txtparametro2, Me.lblUsuario, Me.txtHora, Me.txtUsuario, Me.txtFecha, Me.txtparametro1})
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
        Me.lblParametro.Left = 0.125!
        Me.lblParametro.Name = "lblParametro"
        Me.lblParametro.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblParametro.Text = "Parámetros:"
        Me.lblParametro.Top = 0.0!
        Me.lblParametro.Width = 0.6875!
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
        Me.txtparametro2.Left = 0.8125!
        Me.txtparametro2.Name = "txtparametro2"
        Me.txtparametro2.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro2.Text = Nothing
        Me.txtparametro2.Top = 0.1875!
        Me.txtparametro2.Width = 2.8125!
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
        Me.lblUsuario.Left = 7.25!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.Top = 0.0!
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
        Me.txtHora.Left = 8.9375!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
        Me.txtHora.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtHora.Text = Nothing
        Me.txtHora.Top = 0.1875!
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
        Me.txtUsuario.Left = 7.8125!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.Top = 0.0!
        Me.txtUsuario.Width = 2.1875!
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
        Me.txtparametro1.Left = 0.8125!
        Me.txtparametro1.MultiLine = False
        Me.txtparametro1.Name = "txtparametro1"
        Me.txtparametro1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro1.Text = Nothing
        Me.txtparametro1.Top = 0.0!
        Me.txtparametro1.Width = 2.8125!
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
        'GroupHeader1
        '
        Me.GroupHeader1.ColumnGroupKeepTogether = True
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblCoordinadora, Me.txtNombreGS, Me.txtCodigo, Me.txtMunicipio, Me.txtDepartamento, Me.txtEstado, Me.txtDistrito, Me.txtMercado, Me.txtBarrio, Me.lblDistrito, Me.lblCodigo, Me.lblEstado, Me.Line1, Me.Line2, Me.lblMunicipio, Me.lblDepartamento, Me.lblNombreGS, Me.lblBarrio, Me.lblMercado, Me.lblCodigoSocia, Me.lblSocia, Me.lblCedula, Me.lblDomicilio})
        Me.GroupHeader1.DataField = "nSclGrupoSolidarioID"
        Me.GroupHeader1.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.GroupHeader1.Height = 1.09375!
        Me.GroupHeader1.KeepTogether = True
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.Shape1.Height = 0.6875!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0625!
        Me.Shape1.Width = 10.0!
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
        Me.lblDistrito.Left = 4.0625!
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDistrito.Text = "Distrito:"
        Me.lblDistrito.Top = 0.5!
        Me.lblDistrito.Width = 0.9375!
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
        Me.lblBarrio.Left = 7.0625!
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblBarrio.Text = "Barrio:"
        Me.lblBarrio.Top = 0.125!
        Me.lblBarrio.Width = 0.6875!
        '
        'lblMercado
        '
        Me.lblMercado.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMercado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMercado.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMercado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMercado.Border.RightColor = System.Drawing.Color.Black
        Me.lblMercado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMercado.Border.TopColor = System.Drawing.Color.Black
        Me.lblMercado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMercado.Height = 0.1875!
        Me.lblMercado.HyperLink = Nothing
        Me.lblMercado.Left = 7.0625!
        Me.lblMercado.Name = "lblMercado"
        Me.lblMercado.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblMercado.Text = "Mercado:"
        Me.lblMercado.Top = 0.3125!
        Me.lblMercado.Width = 0.6875!
        '
        'lblCodigoSocia
        '
        Me.lblCodigoSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigoSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigoSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoSocia.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigoSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoSocia.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigoSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoSocia.Height = 0.25!
        Me.lblCodigoSocia.HyperLink = Nothing
        Me.lblCodigoSocia.Left = 0.125!
        Me.lblCodigoSocia.Name = "lblCodigoSocia"
        Me.lblCodigoSocia.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCodigoSocia.Text = "Código"
        Me.lblCodigoSocia.Top = 0.8125!
        Me.lblCodigoSocia.Width = 0.5625!
        '
        'lblSocia
        '
        Me.lblSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSocia.Border.RightColor = System.Drawing.Color.Black
        Me.lblSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSocia.Border.TopColor = System.Drawing.Color.Black
        Me.lblSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSocia.Height = 0.25!
        Me.lblSocia.HyperLink = Nothing
        Me.lblSocia.Left = 0.75!
        Me.lblSocia.Name = "lblSocia"
        Me.lblSocia.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblSocia.Text = "Nombre Socia"
        Me.lblSocia.Top = 0.8125!
        Me.lblSocia.Width = 3.0625!
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
        Me.lblCedula.Left = 3.8125!
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCedula.Text = "Cédula Socia"
        Me.lblCedula.Top = 0.8125!
        Me.lblCedula.Width = 1.375!
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
        Me.lblDomicilio.Left = 5.1875!
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDomicilio.Text = "Domicilio"
        Me.lblDomicilio.Top = 0.8125!
        Me.lblDomicilio.Width = 3.75!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptSclLstGrupoSolidario
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.09375!
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
        CType(Me.lblCodRpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkCoordinadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEstado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMercado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rptInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblParametro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMercado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombreGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCodigo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblEstado As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblDepartamento As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMunicipio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCoordinadora As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtEstado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDepartamento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMunicipio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDistrito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtBarrio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ChkCoordinadora As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents rptInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtMercado As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblParametro As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodRpt As DataDynamics.ActiveReports.Label
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblUsuario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblDistrito As DataDynamics.ActiveReports.Label
    Friend WithEvents lblBarrio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMercado As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblCodigoSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents lblSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCedula As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDomicilio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodigoSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDomicilio As DataDynamics.ActiveReports.TextBox
End Class
