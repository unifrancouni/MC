<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptStbTasaCambio
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStbTasaCambio))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.lblMontoCambio = New DataDynamics.ActiveReports.Label
        Me.lblFechaCambio = New DataDynamics.ActiveReports.Label
        Me.lblActivo = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtMontoCambio = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaCambio = New DataDynamics.ActiveReports.TextBox
        Me.chkactivo = New DataDynamics.ActiveReports.CheckBox
        Me.chkOcupado = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtparametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro2 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.lblOcupado = New DataDynamics.ActiveReports.Label
        Me.grpMoneda = New DataDynamics.ActiveReports.GroupHeader
        Me.txtMonedaBase = New DataDynamics.ActiveReports.TextBox
        Me.lblMonedaBase = New DataDynamics.ActiveReports.Label
        Me.txtMonedaCambio = New DataDynamics.ActiveReports.TextBox
        Me.lblMonedaCambio = New DataDynamics.ActiveReports.Label
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkactivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOcupado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOcupado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonedaBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMonedaBase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMonedaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMonedaCambio, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.Label1})
        Me.PageHeader1.Height = 1.177083!
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
        Me.lblTitulo.Text = "Listado de Tasas de Cambio"
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
        Me.Label1.Text = "CB7"
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
        'lblMontoCambio
        '
        Me.lblMontoCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoCambio.HyperLink = Nothing
        Me.lblMontoCambio.Location = CType(resources.GetObject("lblMontoCambio.Location"), System.Drawing.PointF)
        Me.lblMontoCambio.Name = "lblMontoCambio"
        Me.lblMontoCambio.Size = New System.Drawing.SizeF(1.125!, 0.1875!)
        Me.lblMontoCambio.Text = "Monto"
        Me.lblMontoCambio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblFechaCambio
        '
        Me.lblFechaCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaCambio.HyperLink = Nothing
        Me.lblFechaCambio.Location = CType(resources.GetObject("lblFechaCambio.Location"), System.Drawing.PointF)
        Me.lblFechaCambio.Name = "lblFechaCambio"
        Me.lblFechaCambio.Size = New System.Drawing.SizeF(0.9375!, 0.1875!)
        Me.lblFechaCambio.Text = "Fecha"
        Me.lblFechaCambio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        Me.Line1.Y1 = 0.3125001!
        Me.Line1.Y2 = 0.3125001!
        '
        'Line3
        '
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 0.03125!
        Me.Line3.X2 = 7.520833!
        Me.Line3.Y1 = 0.5520833!
        Me.Line3.Y2 = 0.5520833!
        '
        'Line4
        '
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 0.03125!
        Me.Line4.X2 = 7.520833!
        Me.Line4.Y1 = 0.3125001!
        Me.Line4.Y2 = 0.3125001!
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtMontoCambio, Me.txtFechaCambio, Me.chkactivo, Me.chkOcupado})
        Me.Detail1.Height = 0.2291667!
        Me.Detail1.Name = "Detail1"
        '
        'txtMontoCambio
        '
        Me.txtMontoCambio.DistinctField = Nothing
        Me.txtMontoCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMontoCambio.Location = CType(resources.GetObject("txtMontoCambio.Location"), System.Drawing.PointF)
        Me.txtMontoCambio.Name = "txtMontoCambio"
        Me.txtMontoCambio.OutputFormat = Nothing
        Me.txtMontoCambio.Size = New System.Drawing.SizeF(1.125!, 0.1875!)
        Me.txtMontoCambio.Text = Nothing
        Me.txtMontoCambio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtFechaCambio
        '
        Me.txtFechaCambio.DistinctField = Nothing
        Me.txtFechaCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCambio.Location = CType(resources.GetObject("txtFechaCambio.Location"), System.Drawing.PointF)
        Me.txtFechaCambio.Name = "txtFechaCambio"
        Me.txtFechaCambio.OutputFormat = Nothing
        Me.txtFechaCambio.Size = New System.Drawing.SizeF(0.9375!, 0.1875!)
        Me.txtFechaCambio.Text = Nothing
        Me.txtFechaCambio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        'chkOcupado
        '
        Me.chkOcupado.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOcupado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOcupado.Location = CType(resources.GetObject("chkOcupado.Location"), System.Drawing.PointF)
        Me.chkOcupado.Name = "chkOcupado"
        Me.chkOcupado.Size = New System.Drawing.SizeF(0.25!, 0.1875!)
        Me.chkOcupado.Text = ""
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtparametro1, Me.txtparametro2, Me.ReportInfo1, Me.Line5, Me.TextBox1, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.4166667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtparametro1
        '
        Me.txtparametro1.DistinctField = Nothing
        Me.txtparametro1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtparametro1.Location = CType(resources.GetObject("txtparametro1.Location"), System.Drawing.PointF)
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
        Me.txtparametro2.Size = New System.Drawing.SizeF(5.0!, 0.1875!)
        Me.txtparametro2.Text = Nothing
        Me.txtparametro2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'ReportInfo1
        '
        Me.ReportInfo1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportInfo1.FormatString = "{PageNumber} de {PageCount}"
        Me.ReportInfo1.Location = CType(resources.GetObject("ReportInfo1.Location"), System.Drawing.PointF)
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Size = New System.Drawing.SizeF(1.0!, 0.1875!)
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
        Me.EncabezadoReporte.Height = 0.01041667!
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
        'lblOcupado
        '
        Me.lblOcupado.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOcupado.HyperLink = Nothing
        Me.lblOcupado.Location = CType(resources.GetObject("lblOcupado.Location"), System.Drawing.PointF)
        Me.lblOcupado.Name = "lblOcupado"
        Me.lblOcupado.Size = New System.Drawing.SizeF(0.6875!, 0.1875!)
        Me.lblOcupado.Text = "¿Ocupado?"
        Me.lblOcupado.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'grpMoneda
        '
        Me.grpMoneda.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtMonedaBase, Me.lblMonedaBase, Me.Line4, Me.lblFechaCambio, Me.lblActivo, Me.Line1, Me.Line3, Me.lblMontoCambio, Me.lblOcupado, Me.txtMonedaCambio, Me.lblMonedaCambio})
        Me.grpMoneda.DataField = "nStbMonedaBaseID"
        Me.grpMoneda.Height = 0.6145833!
        Me.grpMoneda.Name = "grpMoneda"
        '
        'txtMonedaBase
        '
        Me.txtMonedaBase.DistinctField = Nothing
        Me.txtMonedaBase.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonedaBase.Location = CType(resources.GetObject("txtMonedaBase.Location"), System.Drawing.PointF)
        Me.txtMonedaBase.Name = "txtMonedaBase"
        Me.txtMonedaBase.OutputFormat = Nothing
        Me.txtMonedaBase.Size = New System.Drawing.SizeF(1.375!, 0.1875!)
        Me.txtMonedaBase.Text = Nothing
        Me.txtMonedaBase.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblMonedaBase
        '
        Me.lblMonedaBase.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaBase.HyperLink = Nothing
        Me.lblMonedaBase.Location = CType(resources.GetObject("lblMonedaBase.Location"), System.Drawing.PointF)
        Me.lblMonedaBase.MultiLine = False
        Me.lblMonedaBase.Name = "lblMonedaBase"
        Me.lblMonedaBase.Size = New System.Drawing.SizeF(0.8125!, 0.1875!)
        Me.lblMonedaBase.Text = "Moneda Base:"
        Me.lblMonedaBase.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtMonedaCambio
        '
        Me.txtMonedaCambio.DistinctField = Nothing
        Me.txtMonedaCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonedaCambio.Location = CType(resources.GetObject("txtMonedaCambio.Location"), System.Drawing.PointF)
        Me.txtMonedaCambio.Name = "txtMonedaCambio"
        Me.txtMonedaCambio.OutputFormat = Nothing
        Me.txtMonedaCambio.Size = New System.Drawing.SizeF(1.375!, 0.1875!)
        Me.txtMonedaCambio.Text = Nothing
        Me.txtMonedaCambio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblMonedaCambio
        '
        Me.lblMonedaCambio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMonedaCambio.HyperLink = Nothing
        Me.lblMonedaCambio.Location = CType(resources.GetObject("lblMonedaCambio.Location"), System.Drawing.PointF)
        Me.lblMonedaCambio.MultiLine = False
        Me.lblMonedaCambio.Name = "lblMonedaCambio"
        Me.lblMonedaCambio.Size = New System.Drawing.SizeF(1.0!, 0.1875!)
        Me.lblMonedaCambio.Text = "Moneda Cambio:"
        Me.lblMonedaCambio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Height = 0.0!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'rptStbTasaCambio
        '
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.520833!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.grpMoneda)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkactivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOcupado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOcupado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonedaBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMonedaBase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMonedaCambio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMonedaCambio, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblUsuario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMontoCambio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFechaCambio As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtMontoCambio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaCambio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents chkactivo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblActivo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents grpMoneda As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents txtMonedaBase As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMonedaBase As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblOcupado As DataDynamics.ActiveReports.Label
    Friend WithEvents chkOcupado As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents txtMonedaCambio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMonedaCambio As DataDynamics.ActiveReports.Label
End Class
