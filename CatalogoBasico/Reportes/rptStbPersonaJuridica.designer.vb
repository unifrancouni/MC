<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptStbPersonaJuridica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStbPersonaJuridica))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.lblRuc = New DataDynamics.ActiveReports.Label
        Me.lblRazonSocial = New DataDynamics.ActiveReports.Label
        Me.lblCodigo = New DataDynamics.ActiveReports.Label
        Me.lblReprese = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.lblDomicilio = New DataDynamics.ActiveReports.Label
        Me.lblTelefono = New DataDynamics.ActiveReports.Label
        Me.lblFax = New DataDynamics.ActiveReports.Label
        Me.lblActivo = New DataDynamics.ActiveReports.Label
        Me.lblFechaC = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.txtRuc = New DataDynamics.ActiveReports.TextBox
        Me.txtRepresentante = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaC = New DataDynamics.ActiveReports.TextBox
        Me.txtDomicilio = New DataDynamics.ActiveReports.TextBox
        Me.txtFax = New DataDynamics.ActiveReports.TextBox
        Me.ChkActivo = New DataDynamics.ActiveReports.CheckBox
        Me.txtRazon = New DataDynamics.ActiveReports.TextBox
        Me.txtTelefono = New DataDynamics.ActiveReports.TextBox
        Me.chkOtorgaCredito = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.txtParametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtParametro2 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.Label1 = New DataDynamics.ActiveReports.Label
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRazonSocial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblReprese, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRepresentante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRazon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOtorgaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReporte, Me.lblTitulo, Me.lblRuc, Me.lblRazonSocial, Me.lblCodigo, Me.lblReprese, Me.Line1, Me.Line2, Me.lblDomicilio, Me.lblTelefono, Me.lblFax, Me.lblActivo, Me.lblFechaC, Me.Label3, Me.Label1})
        Me.PageHeader1.Height = 1.75!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'SubReporte
        '
        Me.SubReporte.CloseBorder = False
        Me.SubReporte.Location = CType(resources.GetObject("SubReporte.Location"), System.Drawing.PointF)
        Me.SubReporte.Name = "SubReporte"
        Me.SubReporte.Report = Nothing
        Me.SubReporte.ReportName = "SubReport1"
        Me.SubReporte.Size = New System.Drawing.SizeF(9.958333!, 0.7!)
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Location = CType(resources.GetObject("lblTitulo.Location"), System.Drawing.PointF)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.SizeF(9.958333!, 0.2083333!)
        Me.lblTitulo.Text = "Persona Jurídica"
        Me.lblTitulo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblRuc
        '
        Me.lblRuc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuc.HyperLink = Nothing
        Me.lblRuc.Location = CType(resources.GetObject("lblRuc.Location"), System.Drawing.PointF)
        Me.lblRuc.Name = "lblRuc"
        Me.lblRuc.Size = New System.Drawing.SizeF(0.9166667!, 0.25!)
        Me.lblRuc.Text = "RUC"
        Me.lblRuc.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblRazonSocial
        '
        Me.lblRazonSocial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRazonSocial.HyperLink = Nothing
        Me.lblRazonSocial.Location = CType(resources.GetObject("lblRazonSocial.Location"), System.Drawing.PointF)
        Me.lblRazonSocial.Name = "lblRazonSocial"
        Me.lblRazonSocial.Size = New System.Drawing.SizeF(1.75!, 0.25!)
        Me.lblRazonSocial.Text = "Razón Social"
        Me.lblRazonSocial.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblCodigo
        '
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.HyperLink = Nothing
        Me.lblCodigo.Location = CType(resources.GetObject("lblCodigo.Location"), System.Drawing.PointF)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.SizeF(0.4583333!, 0.25!)
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblReprese
        '
        Me.lblReprese.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblReprese.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReprese.HyperLink = Nothing
        Me.lblReprese.Location = CType(resources.GetObject("lblReprese.Location"), System.Drawing.PointF)
        Me.lblReprese.Name = "lblReprese"
        Me.lblReprese.Size = New System.Drawing.SizeF(1.291667!, 0.25!)
        Me.lblReprese.Text = "Representante Legal"
        Me.lblReprese.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Line1
        '
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 2.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 10.1!
        Me.Line1.Y1 = 1.395836!
        Me.Line1.Y2 = 1.395836!
        '
        'Line2
        '
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.LineWeight = 2.0!
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 0.02085498!
        Me.Line2.X2 = 10.12086!
        Me.Line2.Y1 = 1.687501!
        Me.Line2.Y2 = 1.687501!
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDomicilio.HyperLink = Nothing
        Me.lblDomicilio.Location = CType(resources.GetObject("lblDomicilio.Location"), System.Drawing.PointF)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.SizeF(1.625!, 0.25!)
        Me.lblDomicilio.Text = "Domicilio"
        Me.lblDomicilio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblTelefono
        '
        Me.lblTelefono.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.HyperLink = Nothing
        Me.lblTelefono.Location = CType(resources.GetObject("lblTelefono.Location"), System.Drawing.PointF)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.SizeF(0.5833333!, 0.25!)
        Me.lblTelefono.Text = "Teléfono"
        Me.lblTelefono.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblFax
        '
        Me.lblFax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFax.HyperLink = Nothing
        Me.lblFax.Location = CType(resources.GetObject("lblFax.Location"), System.Drawing.PointF)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.SizeF(0.6666667!, 0.25!)
        Me.lblFax.Text = "Fax"
        Me.lblFax.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblActivo
        '
        Me.lblActivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.HyperLink = Nothing
        Me.lblActivo.Location = CType(resources.GetObject("lblActivo.Location"), System.Drawing.PointF)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.SizeF(0.5416667!, 0.25!)
        Me.lblActivo.Text = "¿Activo?"
        Me.lblActivo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblFechaC
        '
        Me.lblFechaC.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblFechaC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaC.HyperLink = Nothing
        Me.lblFechaC.Location = CType(resources.GetObject("lblFechaC.Location"), System.Drawing.PointF)
        Me.lblFechaC.Name = "lblFechaC"
        Me.lblFechaC.Size = New System.Drawing.SizeF(0.75!, 0.25!)
        Me.lblFechaC.Text = "Fecha Constitución"
        Me.lblFechaC.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.HyperLink = Nothing
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.PointF)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.SizeF(1.0!, 0.25!)
        Me.Label3.Text = "¿Otorga Crédito?"
        Me.Label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtRuc, Me.txtRepresentante, Me.txtFechaC, Me.txtDomicilio, Me.txtFax, Me.ChkActivo, Me.txtRazon, Me.txtTelefono, Me.chkOtorgaCredito})
        Me.Detail1.Height = 0.2604167!
        Me.Detail1.Name = "Detail1"
        '
        'txtCodigo
        '
        Me.txtCodigo.DataField = "nCodigo"
        Me.txtCodigo.DistinctField = Nothing
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = CType(resources.GetObject("txtCodigo.Location"), System.Drawing.PointF)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.OutputFormat = Nothing
        Me.txtCodigo.Size = New System.Drawing.SizeF(0.4583333!, 0.2083333!)
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtRuc
        '
        Me.txtRuc.DataField = "sNumRUC"
        Me.txtRuc.DistinctField = Nothing
        Me.txtRuc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuc.Location = CType(resources.GetObject("txtRuc.Location"), System.Drawing.PointF)
        Me.txtRuc.Name = "txtRuc"
        Me.txtRuc.OutputFormat = Nothing
        Me.txtRuc.Size = New System.Drawing.SizeF(0.9583333!, 0.2083333!)
        Me.txtRuc.Text = Nothing
        Me.txtRuc.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtRepresentante
        '
        Me.txtRepresentante.DataField = "sRepresentanteLegal"
        Me.txtRepresentante.DistinctField = Nothing
        Me.txtRepresentante.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRepresentante.Location = CType(resources.GetObject("txtRepresentante.Location"), System.Drawing.PointF)
        Me.txtRepresentante.Name = "txtRepresentante"
        Me.txtRepresentante.OutputFormat = Nothing
        Me.txtRepresentante.Size = New System.Drawing.SizeF(1.25!, 0.2083333!)
        Me.txtRepresentante.Text = Nothing
        Me.txtRepresentante.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtFechaC
        '
        Me.txtFechaC.DataField = "dFechaNacApertura"
        Me.txtFechaC.DistinctField = Nothing
        Me.txtFechaC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaC.Location = CType(resources.GetObject("txtFechaC.Location"), System.Drawing.PointF)
        Me.txtFechaC.Name = "txtFechaC"
        Me.txtFechaC.OutputFormat = "MM/dd/yyyy"
        Me.txtFechaC.Size = New System.Drawing.SizeF(0.7916667!, 0.2083333!)
        Me.txtFechaC.Text = Nothing
        Me.txtFechaC.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtDomicilio
        '
        Me.txtDomicilio.DataField = "sDireccion"
        Me.txtDomicilio.DistinctField = Nothing
        Me.txtDomicilio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDomicilio.Location = CType(resources.GetObject("txtDomicilio.Location"), System.Drawing.PointF)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.OutputFormat = Nothing
        Me.txtDomicilio.Size = New System.Drawing.SizeF(1.6875!, 0.1875!)
        Me.txtDomicilio.Text = Nothing
        Me.txtDomicilio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtFax
        '
        Me.txtFax.DataField = "sFax"
        Me.txtFax.DistinctField = Nothing
        Me.txtFax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFax.Location = CType(resources.GetObject("txtFax.Location"), System.Drawing.PointF)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.OutputFormat = Nothing
        Me.txtFax.Size = New System.Drawing.SizeF(0.6666667!, 0.2083333!)
        Me.txtFax.Text = Nothing
        Me.txtFax.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'ChkActivo
        '
        Me.ChkActivo.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkActivo.DataField = "nPersonaActiva"
        Me.ChkActivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkActivo.Location = CType(resources.GetObject("ChkActivo.Location"), System.Drawing.PointF)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.SizeF(0.2083333!, 0.2083333!)
        Me.ChkActivo.Text = ""
        '
        'txtRazon
        '
        Me.txtRazon.DataField = "sApellido1RS"
        Me.txtRazon.DistinctField = Nothing
        Me.txtRazon.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRazon.Location = CType(resources.GetObject("txtRazon.Location"), System.Drawing.PointF)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.OutputFormat = Nothing
        Me.txtRazon.Size = New System.Drawing.SizeF(1.75!, 0.2083333!)
        Me.txtRazon.Text = Nothing
        Me.txtRazon.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtTelefono
        '
        Me.txtTelefono.DataField = "sTelefono"
        Me.txtTelefono.DistinctField = Nothing
        Me.txtTelefono.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = CType(resources.GetObject("txtTelefono.Location"), System.Drawing.PointF)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.OutputFormat = Nothing
        Me.txtTelefono.Size = New System.Drawing.SizeF(0.625!, 0.2083333!)
        Me.txtTelefono.Text = Nothing
        Me.txtTelefono.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'chkOtorgaCredito
        '
        Me.chkOtorgaCredito.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.chkOtorgaCredito.DataField = "nOtorgaCredito"
        Me.chkOtorgaCredito.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOtorgaCredito.Location = CType(resources.GetObject("chkOtorgaCredito.Location"), System.Drawing.PointF)
        Me.chkOtorgaCredito.Name = "chkOtorgaCredito"
        Me.chkOtorgaCredito.Size = New System.Drawing.SizeF(0.2083333!, 0.2083333!)
        Me.chkOtorgaCredito.Text = ""
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3, Me.TextBox1, Me.txtParametro1, Me.txtParametro2, Me.ReportInfo1, Me.Line4, Me.txtUsuario, Me.Label4, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.46875!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Line3
        '
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 2.0!
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 0.00002164518!
        Me.Line3.X2 = 10.50001!
        Me.Line3.Y1 = 0.0!
        Me.Line3.Y2 = 0.0!
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
        'txtParametro1
        '
        Me.txtParametro1.CanGrow = False
        Me.txtParametro1.DistinctField = Nothing
        Me.txtParametro1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtParametro1.Location = CType(resources.GetObject("txtParametro1.Location"), System.Drawing.PointF)
        Me.txtParametro1.MultiLine = False
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
        Me.txtParametro2.Size = New System.Drawing.SizeF(3.5!, 0.1875!)
        Me.txtParametro2.Text = Nothing
        Me.txtParametro2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        'Line4
        '
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 0.0!
        Me.Line4.X2 = 7.5!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.0!
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
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.HyperLink = Nothing
        Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.PointF)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.SizeF(0.5416667!, 0.2083333!)
        Me.Label4.Text = "Usuario:"
        Me.Label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        'EncabezadoReporte
        '
        Me.EncabezadoReporte.Height = -0.03125!
        Me.EncabezadoReporte.Name = "EncabezadoReporte"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.HyperLink = Nothing
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.PointF)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.SizeF(0.8125!, 0.5!)
        Me.Label1.Text = "CB8"
        Me.Label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'rptStbPersonaJuridica
        '
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.04168!
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
        CType(Me.lblRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRazonSocial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblReprese, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRuc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRepresentante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRazon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOtorgaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblRuc As DataDynamics.ActiveReports.Label
    Friend WithEvents lblRazonSocial As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCodigo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblReprese As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblFechaC As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDomicilio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFax As DataDynamics.ActiveReports.Label
    Friend WithEvents lblActivo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRazon As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRuc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtRepresentante As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaC As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDomicilio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTelefono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ChkActivo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtFax As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents chkOtorgaCredito As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtParametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtParametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
End Class
