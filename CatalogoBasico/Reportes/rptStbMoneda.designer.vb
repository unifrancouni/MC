<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptStbMoneda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStbMoneda))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.LblTitulo = New DataDynamics.ActiveReports.Label
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.Label15 = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.SubRptEncabezado = New DataDynamics.ActiveReports.SubReport
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.TxtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.TxtSimbolo = New DataDynamics.ActiveReports.TextBox
        Me.TxtDescripción = New DataDynamics.ActiveReports.TextBox
        Me.ChkNacionalidad = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtParametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtParametro2 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSimbolo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDescripción, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkNacionalidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.LblTitulo, Me.Label13, Me.Label14, Me.Label15, Me.Label16, Me.SubRptEncabezado, Me.Label7})
        Me.PageHeader1.Height = 1.708333!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Shape1
        '
        Me.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Shape1.Location = CType(resources.GetObject("Shape1.Location"), System.Drawing.PointF)
        Me.Shape1.Name = "Shape1"
        Me.Shape1.Size = New System.Drawing.SizeF(7.4375!, 0.25!)
        '
        'LblTitulo
        '
        Me.LblTitulo.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.LblTitulo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitulo.HyperLink = Nothing
        Me.LblTitulo.Location = CType(resources.GetObject("LblTitulo.Location"), System.Drawing.PointF)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.SizeF(7.375!, 0.25!)
        Me.LblTitulo.Text = "Listado de Moneda"
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.HyperLink = Nothing
        Me.Label13.Location = CType(resources.GetObject("Label13.Location"), System.Drawing.PointF)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.SizeF(0.625!, 0.25!)
        Me.Label13.Text = "Código"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.HyperLink = Nothing
        Me.Label14.Location = CType(resources.GetObject("Label14.Location"), System.Drawing.PointF)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.SizeF(0.625!, 0.25!)
        Me.Label14.Text = "Simbolo"
        '
        'Label15
        '
        Me.Label15.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.HyperLink = Nothing
        Me.Label15.Location = CType(resources.GetObject("Label15.Location"), System.Drawing.PointF)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.SizeF(2.125!, 0.25!)
        Me.Label15.Text = "Descripción"
        '
        'Label16
        '
        Me.Label16.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.HyperLink = Nothing
        Me.Label16.Location = CType(resources.GetObject("Label16.Location"), System.Drawing.PointF)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.SizeF(1.9375!, 0.25!)
        Me.Label16.Text = "Nacional"
        '
        'SubRptEncabezado
        '
        Me.SubRptEncabezado.CloseBorder = False
        Me.SubRptEncabezado.Location = CType(resources.GetObject("SubRptEncabezado.Location"), System.Drawing.PointF)
        Me.SubRptEncabezado.Name = "SubRptEncabezado"
        Me.SubRptEncabezado.Report = Nothing
        Me.SubRptEncabezado.ReportName = "SubReport1"
        Me.SubRptEncabezado.Size = New System.Drawing.SizeF(7.375!, 0.6875!)
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TxtCodigo, Me.TxtSimbolo, Me.TxtDescripción, Me.ChkNacionalidad})
        Me.Detail1.Height = 0.1666667!
        Me.Detail1.Name = "Detail1"
        '
        'TxtCodigo
        '
        Me.TxtCodigo.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.TxtCodigo.DataField = "CodigoInterno"
        Me.TxtCodigo.DistinctField = Nothing
        Me.TxtCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodigo.Location = CType(resources.GetObject("TxtCodigo.Location"), System.Drawing.PointF)
        Me.TxtCodigo.Name = "TxtCodigo"
        Me.TxtCodigo.OutputFormat = Nothing
        Me.TxtCodigo.Size = New System.Drawing.SizeF(0.625!, 0.1475!)
        Me.TxtCodigo.Text = Nothing
        '
        'TxtSimbolo
        '
        Me.TxtSimbolo.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.TxtSimbolo.DataField = "Simbolo"
        Me.TxtSimbolo.DistinctField = Nothing
        Me.TxtSimbolo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSimbolo.Location = CType(resources.GetObject("TxtSimbolo.Location"), System.Drawing.PointF)
        Me.TxtSimbolo.Name = "TxtSimbolo"
        Me.TxtSimbolo.OutputFormat = Nothing
        Me.TxtSimbolo.Size = New System.Drawing.SizeF(0.625!, 0.1475!)
        Me.TxtSimbolo.Text = Nothing
        '
        'TxtDescripción
        '
        Me.TxtDescripción.DataField = "Descripcion"
        Me.TxtDescripción.DistinctField = Nothing
        Me.TxtDescripción.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescripción.Location = CType(resources.GetObject("TxtDescripción.Location"), System.Drawing.PointF)
        Me.TxtDescripción.Name = "TxtDescripción"
        Me.TxtDescripción.OutputFormat = Nothing
        Me.TxtDescripción.Size = New System.Drawing.SizeF(2.125!, 0.1475!)
        Me.TxtDescripción.Text = Nothing
        '
        'ChkNacionalidad
        '
        Me.ChkNacionalidad.DataField = "Nacional"
        Me.ChkNacionalidad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkNacionalidad.Location = CType(resources.GetObject("ChkNacionalidad.Location"), System.Drawing.PointF)
        Me.ChkNacionalidad.Name = "ChkNacionalidad"
        Me.ChkNacionalidad.Size = New System.Drawing.SizeF(0.1875!, 0.1875!)
        Me.ChkNacionalidad.Text = ""
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.TextBox1, Me.Label1, Me.txtFecha, Me.txtHora, Me.txtParametro1, Me.txtParametro2, Me.ReportInfo1, Me.txtUsuario})
        Me.PageFooter1.Height = 0.5520833!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Line1
        '
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.04166667!
        Me.Line1.X2 = 7.450417!
        Me.Line1.Y1 = 0.03125!
        Me.Line1.Y2 = 0.03125!
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.HyperLink = Nothing
        Me.Label7.Location = CType(resources.GetObject("Label7.Location"), System.Drawing.PointF)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.SizeF(0.8125!, 0.5!)
        Me.Label7.Text = "CB5"
        Me.Label7.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.HyperLink = Nothing
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.PointF)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.SizeF(0.5416667!, 0.2083333!)
        Me.Label1.Text = "Usuario:"
        Me.Label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        'txtParametro1
        '
        Me.txtParametro1.DistinctField = Nothing
        Me.txtParametro1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParametro1.Location = CType(resources.GetObject("txtParametro1.Location"), System.Drawing.PointF)
        Me.txtParametro1.Name = "txtParametro1"
        Me.txtParametro1.OutputFormat = Nothing
        Me.txtParametro1.Size = New System.Drawing.SizeF(2.75!, 0.1875!)
        Me.txtParametro1.Text = Nothing
        Me.txtParametro1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtParametro2
        '
        Me.txtParametro2.DistinctField = Nothing
        Me.txtParametro2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParametro2.Location = CType(resources.GetObject("txtParametro2.Location"), System.Drawing.PointF)
        Me.txtParametro2.Name = "txtParametro2"
        Me.txtParametro2.OutputFormat = Nothing
        Me.txtParametro2.Size = New System.Drawing.SizeF(5.0!, 0.1875!)
        Me.txtParametro2.Text = Nothing
        Me.txtParametro2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'ReportInfo1
        '
        Me.ReportInfo1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReportInfo1.FormatString = "{PageNumber} de {PageCount}"
        Me.ReportInfo1.Location = CType(resources.GetObject("ReportInfo1.Location"), System.Drawing.PointF)
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Size = New System.Drawing.SizeF(1.0!, 0.1875!)
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
        'rptStbMoneda
        '
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.510417!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.LblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSimbolo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDescripción, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkNacionalidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents LblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label15 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents TxtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtSimbolo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TxtDescripción As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ChkNacionalidad As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents SubRptEncabezado As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtParametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtParametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
End Class
