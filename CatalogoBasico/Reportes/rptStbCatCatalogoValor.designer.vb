<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptStbCatCatalogoValor
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
    ' Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents DetalleCatalogo As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptStbCatCatalogoValor))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.SubReporteEncabezado = New DataDynamics.ActiveReports.SubReport
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.DetalleCatalogo = New DataDynamics.ActiveReports.Detail
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.txtTipoDependencia = New DataDynamics.ActiveReports.TextBox
        Me.txtNombre = New DataDynamics.ActiveReports.TextBox
        Me.chkActivo = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtParametros1 = New DataDynamics.ActiveReports.TextBox
        Me.txtParametros = New DataDynamics.ActiveReports.TextBox
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.grpCatalogo = New DataDynamics.ActiveReports.GroupHeader
        Me.txtCatalogo = New DataDynamics.ActiveReports.TextBox
        Me.txtDescripcionCatalogo = New DataDynamics.ActiveReports.TextBox
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.chkActivoCatalogo = New DataDynamics.ActiveReports.CheckBox
        Me.lblCodigoInternoValorCatalogo = New DataDynamics.ActiveReports.Label
        Me.lblDescripcionValorCatalogo = New DataDynamics.ActiveReports.Label
        Me.lblActivoValorCatalogo = New DataDynamics.ActiveReports.Label
        Me.grpFooterCatalogo = New DataDynamics.ActiveReports.GroupFooter
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.lblCodigoFormato = New DataDynamics.ActiveReports.Label
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoDependencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametros1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDescripcionCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkActivoCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoInternoValorCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDescripcionValorCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblActivoValorCatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.SubReporteEncabezado, Me.Label9, Me.Label12, Me.Label13, Me.lblCodigoFormato})
        Me.PageHeader1.Height = 1.270833!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; "
        Me.Label1.Text = "Catálogos y sus Valores"
        Me.Label1.Top = 0.7291667!
        Me.Label1.Width = 7.5!
        '
        'SubReporteEncabezado
        '
        Me.SubReporteEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReporteEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReporteEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.SubReporteEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.SubReporteEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporteEncabezado.CloseBorder = False
        Me.SubReporteEncabezado.Height = 0.7!
        Me.SubReporteEncabezado.Left = 0.0!
        Me.SubReporteEncabezado.Name = "SubReporteEncabezado"
        Me.SubReporteEncabezado.Report = Nothing
        Me.SubReporteEncabezado.ReportName = "rptSprEncabezadoV"
        Me.SubReporteEncabezado.Top = 0.0!
        Me.SubReporteEncabezado.Width = 7.5!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label9.Height = 0.1875!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 0.0625!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label9.Text = "Nombre"
        Me.Label9.Top = 1.0625!
        Me.Label9.Width = 1.9375!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 6.375!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.Label12.Text = "¿Activo?"
        Me.Label12.Top = 1.0625!
        Me.Label12.Width = 0.6875!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label13.Height = 0.1875!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 2.0!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label13.Text = "Descripción"
        Me.Label13.Top = 1.0625!
        Me.Label13.Width = 4.375!
        '
        'DetalleCatalogo
        '
        Me.DetalleCatalogo.ColumnSpacing = 0.0!
        Me.DetalleCatalogo.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtTipoDependencia, Me.txtNombre, Me.chkActivo})
        Me.DetalleCatalogo.Height = 0.1979167!
        Me.DetalleCatalogo.Name = "DetalleCatalogo"
        '
        'txtCodigo
        '
        Me.txtCodigo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodigo.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigo.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodigo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodigo.DataField = "CodigoValorCatalogo"
        Me.txtCodigo.Height = 0.1875!
        Me.txtCodigo.Left = 0.3125!
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.Top = 0.0!
        Me.txtCodigo.Width = 1.6875!
        '
        'txtTipoDependencia
        '
        Me.txtTipoDependencia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoDependencia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoDependencia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoDependencia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoDependencia.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoDependencia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoDependencia.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoDependencia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoDependencia.DataField = "DescripcionValorCatalogo"
        Me.txtTipoDependencia.Height = 0.1875!
        Me.txtTipoDependencia.Left = 2.0!
        Me.txtTipoDependencia.Name = "txtTipoDependencia"
        Me.txtTipoDependencia.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtTipoDependencia.Text = Nothing
        Me.txtTipoDependencia.Top = 0.0!
        Me.txtTipoDependencia.Width = 4.375!
        '
        'txtNombre
        '
        Me.txtNombre.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombre.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombre.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombre.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombre.Height = 0.1875!
        Me.txtNombre.Left = 6.375!
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtNombre.Text = Nothing
        Me.txtNombre.Top = 0.0!
        Me.txtNombre.Width = 0.6875!
        '
        'chkActivo
        '
        Me.chkActivo.Border.BottomColor = System.Drawing.Color.Black
        Me.chkActivo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivo.Border.LeftColor = System.Drawing.Color.Black
        Me.chkActivo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivo.Border.RightColor = System.Drawing.Color.Black
        Me.chkActivo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivo.Border.TopColor = System.Drawing.Color.Black
        Me.chkActivo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivo.DataField = "ActivoValorCatalogo"
        Me.chkActivo.Height = 0.1458333!
        Me.chkActivo.Left = 6.6875!
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkActivo.Text = "CheckBox1"
        Me.chkActivo.Top = 0.03125!
        Me.chkActivo.Width = 0.1458333!
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtParametros1, Me.txtParametros, Me.Line2, Me.txtUsuario, Me.Label2, Me.txtFecha, Me.txtHora, Me.ReportInfo1})
        Me.PageFooter1.Height = 0.46875!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtParametros1
        '
        Me.txtParametros1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtParametros1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtParametros1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros1.Border.RightColor = System.Drawing.Color.Black
        Me.txtParametros1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros1.Border.TopColor = System.Drawing.Color.Black
        Me.txtParametros1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtParametros1.Height = 0.1875!
        Me.txtParametros1.Left = 0.0625!
        Me.txtParametros1.Name = "txtParametros1"
        Me.txtParametros1.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtParametros1.Text = Nothing
        Me.txtParametros1.Top = 0.25!
        Me.txtParametros1.Width = 3.1875!
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
        Me.txtParametros.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.txtParametros.Text = Nothing
        Me.txtParametros.Top = 0.0625!
        Me.txtParametros.Width = 3.1875!
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
        Me.Line2.Left = 0.08333334!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 7.34375!
        Me.Line2.X1 = 0.08333334!
        Me.Line2.X2 = 7.427083!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.0!
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
        Me.txtUsuario.Top = 0.0625!
        Me.txtUsuario.Width = 1.041667!
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
        Me.Label2.Height = 0.2083333!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 5.75!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.Label2.Text = "Usuario:"
        Me.Label2.Top = 0.0625!
        Me.Label2.Width = 0.5416667!
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
        Me.txtFecha.Top = 0.25!
        Me.txtFecha.Width = 0.6875!
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
        Me.txtHora.Top = 0.25!
        Me.txtHora.Width = 0.9375!
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
        Me.ReportInfo1.Top = 0.06!
        Me.ReportInfo1.Width = 1.0!
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
        'grpCatalogo
        '
        Me.grpCatalogo.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCatalogo, Me.txtDescripcionCatalogo, Me.TextBox1, Me.chkActivoCatalogo, Me.lblCodigoInternoValorCatalogo, Me.lblDescripcionValorCatalogo, Me.lblActivoValorCatalogo})
        Me.grpCatalogo.DataField = "StbCatalogoID"
        Me.grpCatalogo.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.All
        Me.grpCatalogo.Height = 0.5104167!
        Me.grpCatalogo.KeepTogether = True
        Me.grpCatalogo.Name = "grpCatalogo"
        '
        'txtCatalogo
        '
        Me.txtCatalogo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCatalogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCatalogo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCatalogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCatalogo.Border.RightColor = System.Drawing.Color.Black
        Me.txtCatalogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCatalogo.Border.TopColor = System.Drawing.Color.Black
        Me.txtCatalogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCatalogo.DataField = "NombreCatalogo"
        Me.txtCatalogo.Height = 0.1875!
        Me.txtCatalogo.Left = 0.0625!
        Me.txtCatalogo.Name = "txtCatalogo"
        Me.txtCatalogo.Style = "ddo-char-set: 0; background-color: White; font-size: 8.25pt; "
        Me.txtCatalogo.Text = Nothing
        Me.txtCatalogo.Top = 0.0625!
        Me.txtCatalogo.Width = 1.9375!
        '
        'txtDescripcionCatalogo
        '
        Me.txtDescripcionCatalogo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDescripcionCatalogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDescripcionCatalogo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDescripcionCatalogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDescripcionCatalogo.Border.RightColor = System.Drawing.Color.Black
        Me.txtDescripcionCatalogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDescripcionCatalogo.Border.TopColor = System.Drawing.Color.Black
        Me.txtDescripcionCatalogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDescripcionCatalogo.DataField = "DescripcionCatalogo"
        Me.txtDescripcionCatalogo.Height = 0.1875!
        Me.txtDescripcionCatalogo.Left = 2.0!
        Me.txtDescripcionCatalogo.Name = "txtDescripcionCatalogo"
        Me.txtDescripcionCatalogo.Style = "ddo-char-set: 0; background-color: White; font-size: 8.25pt; "
        Me.txtDescripcionCatalogo.Text = Nothing
        Me.txtDescripcionCatalogo.Top = 0.0625!
        Me.txtDescripcionCatalogo.Width = 4.375!
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
        Me.TextBox1.Left = 6.375!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; text-align: center; background-color: White; font-size: 8.25pt; " & _
            ""
        Me.TextBox1.Text = Nothing
        Me.TextBox1.Top = 0.0625!
        Me.TextBox1.Width = 0.6875!
        '
        'chkActivoCatalogo
        '
        Me.chkActivoCatalogo.Border.BottomColor = System.Drawing.Color.Black
        Me.chkActivoCatalogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivoCatalogo.Border.LeftColor = System.Drawing.Color.Black
        Me.chkActivoCatalogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivoCatalogo.Border.RightColor = System.Drawing.Color.Black
        Me.chkActivoCatalogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivoCatalogo.Border.TopColor = System.Drawing.Color.Black
        Me.chkActivoCatalogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkActivoCatalogo.DataField = "ActivoCatalogo"
        Me.chkActivoCatalogo.Height = 0.1875!
        Me.chkActivoCatalogo.Left = 6.6875!
        Me.chkActivoCatalogo.Name = "chkActivoCatalogo"
        Me.chkActivoCatalogo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkActivoCatalogo.Text = ""
        Me.chkActivoCatalogo.Top = 0.0625!
        Me.chkActivoCatalogo.Width = 0.1875!
        '
        'lblCodigoInternoValorCatalogo
        '
        Me.lblCodigoInternoValorCatalogo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigoInternoValorCatalogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoInternoValorCatalogo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigoInternoValorCatalogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigoInternoValorCatalogo.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigoInternoValorCatalogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoInternoValorCatalogo.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigoInternoValorCatalogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCodigoInternoValorCatalogo.Height = 0.1875!
        Me.lblCodigoInternoValorCatalogo.HyperLink = Nothing
        Me.lblCodigoInternoValorCatalogo.Left = 0.3125!
        Me.lblCodigoInternoValorCatalogo.Name = "lblCodigoInternoValorCatalogo"
        Me.lblCodigoInternoValorCatalogo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.lblCodigoInternoValorCatalogo.Text = " Código Interno"
        Me.lblCodigoInternoValorCatalogo.Top = 0.3125!
        Me.lblCodigoInternoValorCatalogo.Width = 1.6875!
        '
        'lblDescripcionValorCatalogo
        '
        Me.lblDescripcionValorCatalogo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDescripcionValorCatalogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDescripcionValorCatalogo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDescripcionValorCatalogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescripcionValorCatalogo.Border.RightColor = System.Drawing.Color.Black
        Me.lblDescripcionValorCatalogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDescripcionValorCatalogo.Border.TopColor = System.Drawing.Color.Black
        Me.lblDescripcionValorCatalogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblDescripcionValorCatalogo.Height = 0.1875!
        Me.lblDescripcionValorCatalogo.HyperLink = Nothing
        Me.lblDescripcionValorCatalogo.Left = 2.0!
        Me.lblDescripcionValorCatalogo.Name = "lblDescripcionValorCatalogo"
        Me.lblDescripcionValorCatalogo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.lblDescripcionValorCatalogo.Text = " Descripción"
        Me.lblDescripcionValorCatalogo.Top = 0.3125!
        Me.lblDescripcionValorCatalogo.Width = 4.375!
        '
        'lblActivoValorCatalogo
        '
        Me.lblActivoValorCatalogo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblActivoValorCatalogo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblActivoValorCatalogo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblActivoValorCatalogo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblActivoValorCatalogo.Border.RightColor = System.Drawing.Color.Black
        Me.lblActivoValorCatalogo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblActivoValorCatalogo.Border.TopColor = System.Drawing.Color.Black
        Me.lblActivoValorCatalogo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblActivoValorCatalogo.Height = 0.1875!
        Me.lblActivoValorCatalogo.HyperLink = Nothing
        Me.lblActivoValorCatalogo.Left = 6.375!
        Me.lblActivoValorCatalogo.Name = "lblActivoValorCatalogo"
        Me.lblActivoValorCatalogo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; "
        Me.lblActivoValorCatalogo.Text = "¿Activo?"
        Me.lblActivoValorCatalogo.Top = 0.3125!
        Me.lblActivoValorCatalogo.Width = 0.6875!
        '
        'grpFooterCatalogo
        '
        Me.grpFooterCatalogo.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1})
        Me.grpFooterCatalogo.Height = 0.01041667!
        Me.grpFooterCatalogo.KeepTogether = True
        Me.grpFooterCatalogo.Name = "grpFooterCatalogo"
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
        Me.Line1.Left = 0.3229167!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 3.104409E-10!
        Me.Line1.Width = 6.729167!
        Me.Line1.X1 = 0.3229167!
        Me.Line1.X2 = 7.052083!
        Me.Line1.Y1 = 3.104409E-10!
        Me.Line1.Y2 = 3.104409E-10!
        '
        'lblCodigoFormato
        '
        Me.lblCodigoFormato.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigoFormato.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFormato.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigoFormato.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFormato.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigoFormato.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFormato.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigoFormato.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFormato.Height = 0.5!
        Me.lblCodigoFormato.HyperLink = Nothing
        Me.lblCodigoFormato.Left = 5.5625!
        Me.lblCodigoFormato.Name = "lblCodigoFormato"
        Me.lblCodigoFormato.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.lblCodigoFormato.Text = "CB14"
        Me.lblCodigoFormato.Top = 0.125!
        Me.lblCodigoFormato.Width = 0.8125!
        '
        'rptStbCatCatalogoValor
        '
        Me.MasterReport = False
        Me.PageSettings.DefaultPaperSize = False
        Me.PageSettings.Margins.Left = 0.5!
        Me.PageSettings.Margins.Right = 0.5!
        Me.PageSettings.Margins.Top = 0.6!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.PageSettings.PaperName = "Letter"
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.489583!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.grpCatalogo)
        Me.Sections.Add(Me.DetalleCatalogo)
        Me.Sections.Add(Me.grpFooterCatalogo)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoDependencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametros1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametros, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDescripcionCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkActivoCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoInternoValorCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDescripcionValorCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblActivoValorCatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoFormato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReporteEncabezado As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents grpCatalogo As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents grpFooterCatalogo As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents txtCatalogo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipoDependencia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombre As DataDynamics.ActiveReports.TextBox
    Friend WithEvents chkActivo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents txtParametros1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtParametros As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDescripcionCatalogo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents chkActivoCatalogo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents lblCodigoInternoValorCatalogo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDescripcionValorCatalogo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblActivoValorCatalogo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lblCodigoFormato As DataDynamics.ActiveReports.Label
End Class
