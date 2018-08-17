<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptStbBarrio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStbBarrio))
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
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPertenecePrograma, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.Label1})
        Me.PageHeader1.Height = 0.9895833!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Location = CType(resources.GetObject("lblTitulo.Location"), System.Drawing.PointF)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.SizeF(7.4375!, 0.1875!)
        Me.lblTitulo.Text = "Listado de Barrios"
        Me.lblTitulo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'SubReporte
        '
        Me.SubReporte.CloseBorder = False
        Me.SubReporte.Location = CType(resources.GetObject("SubReporte.Location"), System.Drawing.PointF)
        Me.SubReporte.Name = "SubReporte"
        Me.SubReporte.Report = Nothing
        Me.SubReporte.ReportName = "SubReport1"
        Me.SubReporte.Size = New System.Drawing.SizeF(7.4375!, 0.7!)
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.HyperLink = Nothing
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.PointF)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.SizeF(0.8125!, 0.5!)
        Me.Label1.Text = "CB1"
        Me.Label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.HyperLink = Nothing
        Me.lblUsuario.Location = CType(resources.GetObject("lblUsuario.Location"), System.Drawing.PointF)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.SizeF(0.5416667!, 0.2083333!)
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtUsuario
        '
        Me.txtUsuario.DistinctField = Nothing
        Me.txtUsuario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = CType(resources.GetObject("txtUsuario.Location"), System.Drawing.PointF)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.OutputFormat = Nothing
        Me.txtUsuario.Size = New System.Drawing.SizeF(1.041667!, 0.2083333!)
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtHora
        '
        Me.txtHora.DistinctField = Nothing
        Me.txtHora.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHora.Location = CType(resources.GetObject("txtHora.Location"), System.Drawing.PointF)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.OutputFormat = "h:mm:ss tt"
        Me.txtHora.Size = New System.Drawing.SizeF(0.9375!, 0.1875!)
        Me.txtHora.Text = Nothing
        Me.txtHora.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtFecha
        '
        Me.txtFecha.DistinctField = Nothing
        Me.txtFecha.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.Location = CType(resources.GetObject("txtFecha.Location"), System.Drawing.PointF)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = "MM/dd/yy"
        Me.txtFecha.Size = New System.Drawing.SizeF(0.6875!, 0.1875!)
        Me.txtFecha.Text = Nothing
        Me.txtFecha.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblNombre
        '
        Me.lblNombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.HyperLink = Nothing
        Me.lblNombre.Location = CType(resources.GetObject("lblNombre.Location"), System.Drawing.PointF)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.SizeF(3.75!, 0.1875!)
        Me.lblNombre.Text = "Nombre del Barrio"
        Me.lblNombre.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblCodigo
        '
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.HyperLink = Nothing
        Me.lblCodigo.Location = CType(resources.GetObject("lblCodigo.Location"), System.Drawing.PointF)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.SizeF(0.75!, 0.1875!)
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblActivo
        '
        Me.lblActivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.HyperLink = Nothing
        Me.lblActivo.Location = CType(resources.GetObject("lblActivo.Location"), System.Drawing.PointF)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.SizeF(0.5625!, 0.1875!)
        Me.lblActivo.Text = "¿Activo?"
        Me.lblActivo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Line1
        '
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.03125!
        Me.Line1.X2 = 7.520833!
        Me.Line1.Y1 = 0.3437501!
        Me.Line1.Y2 = 0.3437501!
        '
        'Line3
        '
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 0.03125!
        Me.Line3.X2 = 7.520833!
        Me.Line3.Y1 = 0.5833332!
        Me.Line3.Y2 = 0.5833332!
        '
        'Line4
        '
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 0.03125!
        Me.Line4.X2 = 7.520833!
        Me.Line4.Y1 = 0.3437501!
        Me.Line4.Y2 = 0.3437501!
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtNombre, Me.txtCodigo, Me.chkactivo, Me.txtDistrito, Me.chkIncluidoPrograma})
        Me.Detail1.Height = 0.2291667!
        Me.Detail1.Name = "Detail1"
        '
        'txtNombre
        '
        Me.txtNombre.DistinctField = Nothing
        Me.txtNombre.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = CType(resources.GetObject("txtNombre.Location"), System.Drawing.PointF)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.OutputFormat = Nothing
        Me.txtNombre.Size = New System.Drawing.SizeF(3.625!, 0.1875!)
        Me.txtNombre.Text = Nothing
        Me.txtNombre.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtCodigo
        '
        Me.txtCodigo.DistinctField = Nothing
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = CType(resources.GetObject("txtCodigo.Location"), System.Drawing.PointF)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.OutputFormat = Nothing
        Me.txtCodigo.Size = New System.Drawing.SizeF(0.8125!, 0.1875!)
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'chkactivo
        '
        Me.chkactivo.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkactivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkactivo.Location = CType(resources.GetObject("chkactivo.Location"), System.Drawing.PointF)
        Me.chkactivo.Name = "chkactivo"
        Me.chkactivo.Size = New System.Drawing.SizeF(0.25!, 0.1875!)
        Me.chkactivo.Text = ""
        '
        'txtDistrito
        '
        Me.txtDistrito.DistinctField = Nothing
        Me.txtDistrito.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrito.Location = CType(resources.GetObject("txtDistrito.Location"), System.Drawing.PointF)
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.OutputFormat = Nothing
        Me.txtDistrito.Size = New System.Drawing.SizeF(0.8125!, 0.1875!)
        Me.txtDistrito.Text = Nothing
        Me.txtDistrito.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'chkIncluidoPrograma
        '
        Me.chkIncluidoPrograma.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkIncluidoPrograma.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIncluidoPrograma.Location = CType(resources.GetObject("chkIncluidoPrograma.Location"), System.Drawing.PointF)
        Me.chkIncluidoPrograma.Name = "chkIncluidoPrograma"
        Me.chkIncluidoPrograma.Size = New System.Drawing.SizeF(0.25!, 0.1875!)
        Me.chkIncluidoPrograma.Text = ""
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtparametro1, Me.txtparametro2, Me.ReportInfo1, Me.Line5, Me.TextBox1, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.4166667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtparametro1
        '
        Me.txtparametro1.CanGrow = False
        Me.txtparametro1.DistinctField = Nothing
        Me.txtparametro1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtparametro1.Location = CType(resources.GetObject("txtparametro1.Location"), System.Drawing.PointF)
        Me.txtparametro1.MultiLine = False
        Me.txtparametro1.Name = "txtparametro1"
        Me.txtparametro1.OutputFormat = Nothing
        Me.txtparametro1.Size = New System.Drawing.SizeF(2.75!, 0.1875!)
        Me.txtparametro1.Text = Nothing
        Me.txtparametro1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtparametro2
        '
        Me.txtparametro2.DistinctField = Nothing
        Me.txtparametro2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtparametro2.Location = CType(resources.GetObject("txtparametro2.Location"), System.Drawing.PointF)
        Me.txtparametro2.Name = "txtparametro2"
        Me.txtparametro2.OutputFormat = Nothing
        Me.txtparametro2.Size = New System.Drawing.SizeF(3.5!, 0.1875!)
        Me.txtparametro2.Text = Nothing
        Me.txtparametro2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'ReportInfo1
        '
        Me.ReportInfo1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportInfo1.FormatString = "{PageNumber} de {PageCount}"
        Me.ReportInfo1.Location = CType(resources.GetObject("ReportInfo1.Location"), System.Drawing.PointF)
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Size = New System.Drawing.SizeF(1.0!, 0.3125!)
        Me.ReportInfo1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Line5
        '
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.X1 = 0.0!
        Me.Line5.X2 = 7.5!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.0!
        '
        'TextBox1
        '
        Me.TextBox1.DistinctField = Nothing
        Me.TextBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = CType(resources.GetObject("TextBox1.Location"), System.Drawing.PointF)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.OutputFormat = Nothing
        Me.TextBox1.Size = New System.Drawing.SizeF(0.75!, 0.1875!)
        Me.TextBox1.Text = "Parámetros:"
        Me.TextBox1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'EncabezadoReporte
        '
        Me.EncabezadoReporte.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
        Me.EncabezadoReporte.Height = 0.02083333!
        Me.EncabezadoReporte.Name = "EncabezadoReporte"
        '
        'Line2
        '
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.5625!
        Me.Line2.Y1 = 2.166667!
        Me.Line2.Y2 = 2.166667!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = -0.01041667!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'grpMunicipio
        '
        Me.grpMunicipio.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblNombre, Me.lblCodigo, Me.lblActivo, Me.Line1, Me.Line3, Me.Line4, Me.lblMunicipio, Me.txtMunicipio, Me.lblDistrito, Me.lblPertenecePrograma})
        Me.grpMunicipio.DataField = "nStbMunicipioID"
        Me.grpMunicipio.Height = 0.6041667!
        Me.grpMunicipio.KeepTogether = True
        Me.grpMunicipio.Name = "grpMunicipio"
        Me.grpMunicipio.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'lblMunicipio
        '
        Me.lblMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMunicipio.HyperLink = Nothing
        Me.lblMunicipio.Location = CType(resources.GetObject("lblMunicipio.Location"), System.Drawing.PointF)
        Me.lblMunicipio.MultiLine = False
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Size = New System.Drawing.SizeF(0.8125!, 0.1875!)
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtMunicipio
        '
        Me.txtMunicipio.DistinctField = Nothing
        Me.txtMunicipio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMunicipio.Location = CType(resources.GetObject("txtMunicipio.Location"), System.Drawing.PointF)
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.OutputFormat = Nothing
        Me.txtMunicipio.Size = New System.Drawing.SizeF(4.6875!, 0.1875!)
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblDistrito
        '
        Me.lblDistrito.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistrito.HyperLink = Nothing
        Me.lblDistrito.Location = CType(resources.GetObject("lblDistrito.Location"), System.Drawing.PointF)
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Size = New System.Drawing.SizeF(0.75!, 0.1875!)
        Me.lblDistrito.Text = "Distrito"
        Me.lblDistrito.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblPertenecePrograma
        '
        Me.lblPertenecePrograma.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPertenecePrograma.HyperLink = Nothing
        Me.lblPertenecePrograma.Location = CType(resources.GetObject("lblPertenecePrograma.Location"), System.Drawing.PointF)
        Me.lblPertenecePrograma.Name = "lblPertenecePrograma"
        Me.lblPertenecePrograma.Size = New System.Drawing.SizeF(1.375!, 0.1875!)
        Me.lblPertenecePrograma.Text = "¿Incluido en Programa?"
        Me.lblPertenecePrograma.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = -0.01041667!
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
        Me.txtDepartamento.DistinctField = Nothing
        Me.txtDepartamento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartamento.Location = CType(resources.GetObject("txtDepartamento.Location"), System.Drawing.PointF)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.OutputFormat = Nothing
        Me.txtDepartamento.Size = New System.Drawing.SizeF(4.6875!, 0.1875!)
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblDepartamento
        '
        Me.lblDepartamento.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepartamento.HyperLink = Nothing
        Me.lblDepartamento.Location = CType(resources.GetObject("lblDepartamento.Location"), System.Drawing.PointF)
        Me.lblDepartamento.MultiLine = False
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Size = New System.Drawing.SizeF(0.8125!, 0.1875!)
        Me.lblDepartamento.Text = "Departamento:"
        Me.lblDepartamento.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = -0.03125!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'rptStbBarrio
        '
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
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPertenecePrograma, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()

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
End Class
