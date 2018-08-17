<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptStbPersonaNatural
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptStbPersonaNatural))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.lblCodigo = New DataDynamics.ActiveReports.Label
        Me.lblNombreA = New DataDynamics.ActiveReports.Label
        Me.lblCedula = New DataDynamics.ActiveReports.Label
        Me.lblSexo = New DataDynamics.ActiveReports.Label
        Me.lblFechaN = New DataDynamics.ActiveReports.Label
        Me.lblDomicilio = New DataDynamics.ActiveReports.Label
        Me.lblTelefono = New DataDynamics.ActiveReports.Label
        Me.lblFax = New DataDynamics.ActiveReports.Label
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.lblActivo = New DataDynamics.ActiveReports.Label
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtCodigo = New DataDynamics.ActiveReports.TextBox
        Me.txtNombreyA = New DataDynamics.ActiveReports.TextBox
        Me.txtCedula = New DataDynamics.ActiveReports.TextBox
        Me.txtSexo = New DataDynamics.ActiveReports.TextBox
        Me.txtDomicilio = New DataDynamics.ActiveReports.TextBox
        Me.txtTelefono = New DataDynamics.ActiveReports.TextBox
        Me.txtFx = New DataDynamics.ActiveReports.TextBox
        Me.ChkActivo = New DataDynamics.ActiveReports.CheckBox
        Me.txtFechaN = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.txtParametro2 = New DataDynamics.ActiveReports.TextBox
        Me.txtParametro1 = New DataDynamics.ActiveReports.TextBox
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.lblCodigoFormato = New DataDynamics.ActiveReports.Label
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSexo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreyA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSexo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkActivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoFormato, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReporte, Me.lblCodigo, Me.lblNombreA, Me.lblCedula, Me.lblSexo, Me.lblFechaN, Me.lblDomicilio, Me.lblTelefono, Me.lblFax, Me.Line3, Me.Line4, Me.lblActivo, Me.lblTitulo, Me.lblCodigoFormato})
        Me.PageHeader1.Height = 1.875!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'SubReporte
        '
        Me.SubReporte.CloseBorder = False
        Me.SubReporte.Location = CType(resources.GetObject("SubReporte.Location"), System.Drawing.PointF)
        Me.SubReporte.Name = "SubReporte"
        Me.SubReporte.Report = Nothing
        Me.SubReporte.ReportName = "SubReport1"
        Me.SubReporte.Size = New System.Drawing.SizeF(9.916667!, 0.7!)
        '
        'lblCodigo
        '
        Me.lblCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigo.HyperLink = Nothing
        Me.lblCodigo.Location = CType(resources.GetObject("lblCodigo.Location"), System.Drawing.PointF)
        Me.lblCodigo.Name = "lblCodigo"
        Me.lblCodigo.Size = New System.Drawing.SizeF(0.4375!, 0.3333333!)
        Me.lblCodigo.Text = "Código"
        Me.lblCodigo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblNombreA
        '
        Me.lblNombreA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreA.HyperLink = Nothing
        Me.lblNombreA.Location = CType(resources.GetObject("lblNombreA.Location"), System.Drawing.PointF)
        Me.lblNombreA.Name = "lblNombreA"
        Me.lblNombreA.Size = New System.Drawing.SizeF(3.4375!, 0.3125!)
        Me.lblNombreA.Text = "Apellidos y Nombres"
        Me.lblNombreA.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblCedula
        '
        Me.lblCedula.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCedula.HyperLink = Nothing
        Me.lblCedula.Location = CType(resources.GetObject("lblCedula.Location"), System.Drawing.PointF)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.SizeF(1.0625!, 0.3333333!)
        Me.lblCedula.Text = "Cédula"
        Me.lblCedula.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblSexo
        '
        Me.lblSexo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSexo.HyperLink = Nothing
        Me.lblSexo.Location = CType(resources.GetObject("lblSexo.Location"), System.Drawing.PointF)
        Me.lblSexo.Name = "lblSexo"
        Me.lblSexo.Size = New System.Drawing.SizeF(0.3125!, 0.34375!)
        Me.lblSexo.Text = "Sexo"
        Me.lblSexo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblFechaN
        '
        Me.lblFechaN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaN.HyperLink = Nothing
        Me.lblFechaN.Location = CType(resources.GetObject("lblFechaN.Location"), System.Drawing.PointF)
        Me.lblFechaN.Name = "lblFechaN"
        Me.lblFechaN.Size = New System.Drawing.SizeF(0.84375!, 0.3333333!)
        Me.lblFechaN.Text = "Fecha Nacimiento"
        Me.lblFechaN.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblDomicilio
        '
        Me.lblDomicilio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDomicilio.HyperLink = Nothing
        Me.lblDomicilio.Location = CType(resources.GetObject("lblDomicilio.Location"), System.Drawing.PointF)
        Me.lblDomicilio.Name = "lblDomicilio"
        Me.lblDomicilio.Size = New System.Drawing.SizeF(1.291667!, 0.3333333!)
        Me.lblDomicilio.Text = "Domicilio"
        Me.lblDomicilio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblTelefono
        '
        Me.lblTelefono.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelefono.HyperLink = Nothing
        Me.lblTelefono.Location = CType(resources.GetObject("lblTelefono.Location"), System.Drawing.PointF)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.SizeF(0.59375!, 0.3333333!)
        Me.lblTelefono.Text = "Teléfono"
        Me.lblTelefono.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblFax
        '
        Me.lblFax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFax.HyperLink = Nothing
        Me.lblFax.Location = CType(resources.GetObject("lblFax.Location"), System.Drawing.PointF)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.SizeF(0.65625!, 0.3333333!)
        Me.lblFax.Text = "Fax"
        Me.lblFax.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Line3
        '
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 0.0!
        Me.Line3.X2 = 10.0!
        Me.Line3.Y1 = 1.781249!
        Me.Line3.Y2 = 1.781249!
        '
        'Line4
        '
        Me.Line4.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.X1 = 0.02083334!
        Me.Line4.X2 = 10.3125!
        Me.Line4.Y1 = 1.397919!
        Me.Line4.Y2 = 1.397919!
        '
        'lblActivo
        '
        Me.lblActivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivo.HyperLink = Nothing
        Me.lblActivo.Location = CType(resources.GetObject("lblActivo.Location"), System.Drawing.PointF)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.SizeF(0.5625!, 0.3125!)
        Me.lblActivo.Text = "¿Activo?"
        Me.lblActivo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblTitulo
        '
        Me.lblTitulo.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.lblTitulo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Location = CType(resources.GetObject("lblTitulo.Location"), System.Drawing.PointF)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.SizeF(9.916667!, 0.2083333!)
        Me.lblTitulo.Text = "Persona Natural"
        Me.lblTitulo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtCodigo, Me.txtNombreyA, Me.txtCedula, Me.txtSexo, Me.txtDomicilio, Me.txtTelefono, Me.txtFx, Me.ChkActivo, Me.txtFechaN})
        Me.Detail1.Height = 0.3020833!
        Me.Detail1.Name = "Detail1"
        '
        'txtCodigo
        '
        Me.txtCodigo.DistinctField = Nothing
        Me.txtCodigo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = CType(resources.GetObject("txtCodigo.Location"), System.Drawing.PointF)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.OutputFormat = Nothing
        Me.txtCodigo.Size = New System.Drawing.SizeF(0.40625!, 0.28125!)
        Me.txtCodigo.Text = Nothing
        Me.txtCodigo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtNombreyA
        '
        Me.txtNombreyA.DistinctField = Nothing
        Me.txtNombreyA.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreyA.Location = CType(resources.GetObject("txtNombreyA.Location"), System.Drawing.PointF)
        Me.txtNombreyA.Name = "txtNombreyA"
        Me.txtNombreyA.OutputFormat = Nothing
        Me.txtNombreyA.Size = New System.Drawing.SizeF(3.4375!, 0.3125!)
        Me.txtNombreyA.Text = Nothing
        Me.txtNombreyA.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtCedula
        '
        Me.txtCedula.DistinctField = Nothing
        Me.txtCedula.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCedula.Location = CType(resources.GetObject("txtCedula.Location"), System.Drawing.PointF)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.OutputFormat = Nothing
        Me.txtCedula.Size = New System.Drawing.SizeF(1.0625!, 0.3125!)
        Me.txtCedula.Text = Nothing
        Me.txtCedula.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtSexo
        '
        Me.txtSexo.DistinctField = Nothing
        Me.txtSexo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSexo.Location = CType(resources.GetObject("txtSexo.Location"), System.Drawing.PointF)
        Me.txtSexo.Name = "txtSexo"
        Me.txtSexo.OutputFormat = Nothing
        Me.txtSexo.Size = New System.Drawing.SizeF(0.3125!, 0.3125!)
        Me.txtSexo.Text = Nothing
        Me.txtSexo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtDomicilio
        '
        Me.txtDomicilio.DistinctField = Nothing
        Me.txtDomicilio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDomicilio.Location = CType(resources.GetObject("txtDomicilio.Location"), System.Drawing.PointF)
        Me.txtDomicilio.Name = "txtDomicilio"
        Me.txtDomicilio.OutputFormat = Nothing
        Me.txtDomicilio.Size = New System.Drawing.SizeF(1.3125!, 0.3125!)
        Me.txtDomicilio.Text = Nothing
        Me.txtDomicilio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtTelefono
        '
        Me.txtTelefono.DistinctField = Nothing
        Me.txtTelefono.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = CType(resources.GetObject("txtTelefono.Location"), System.Drawing.PointF)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.OutputFormat = Nothing
        Me.txtTelefono.Size = New System.Drawing.SizeF(0.625!, 0.3125!)
        Me.txtTelefono.Text = Nothing
        Me.txtTelefono.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtFx
        '
        Me.txtFx.DistinctField = Nothing
        Me.txtFx.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFx.Location = CType(resources.GetObject("txtFx.Location"), System.Drawing.PointF)
        Me.txtFx.Name = "txtFx"
        Me.txtFx.OutputFormat = Nothing
        Me.txtFx.Size = New System.Drawing.SizeF(0.7083333!, 0.2916667!)
        Me.txtFx.Text = Nothing
        Me.txtFx.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'ChkActivo
        '
        Me.ChkActivo.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.ChkActivo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkActivo.Location = CType(resources.GetObject("ChkActivo.Location"), System.Drawing.PointF)
        Me.ChkActivo.Name = "ChkActivo"
        Me.ChkActivo.Size = New System.Drawing.SizeF(0.21875!, 0.21875!)
        Me.ChkActivo.Text = ""
        '
        'txtFechaN
        '
        Me.txtFechaN.DistinctField = Nothing
        Me.txtFechaN.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaN.Location = CType(resources.GetObject("txtFechaN.Location"), System.Drawing.PointF)
        Me.txtFechaN.Name = "txtFechaN"
        Me.txtFechaN.OutputFormat = "MM/dd/yyyy"
        Me.txtFechaN.Size = New System.Drawing.SizeF(0.875!, 0.2916667!)
        Me.txtFechaN.Text = Nothing
        Me.txtFechaN.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line1, Me.txtParametro2, Me.txtParametro1, Me.TextBox3, Me.ReportInfo1, Me.txtHora, Me.Label1, Me.txtFecha, Me.txtUsuario})
        Me.PageFooter1.Height = 0.4583333!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Line1
        '
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.0!
        Me.Line1.X2 = 10.20833!
        Me.Line1.Y1 = 0.01458367!
        Me.Line1.Y2 = 0.01458367!
        '
        'EncabezadoReporte
        '
        Me.EncabezadoReporte.Height = -0.02083333!
        Me.EncabezadoReporte.Name = "EncabezadoReporte"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
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
        'TextBox3
        '
        Me.TextBox3.DistinctField = Nothing
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = CType(resources.GetObject("TextBox3.Location"), System.Drawing.PointF)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = Nothing
        Me.TextBox3.Size = New System.Drawing.SizeF(0.75!, 0.1875!)
        Me.TextBox3.Text = "Parámetros:"
        Me.TextBox3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        'lblCodigoFormato
        '
        Me.lblCodigoFormato.Font = New System.Drawing.Font("Arial", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodigoFormato.HyperLink = Nothing
        Me.lblCodigoFormato.Location = CType(resources.GetObject("lblCodigoFormato.Location"), System.Drawing.PointF)
        Me.lblCodigoFormato.Name = "lblCodigoFormato"
        Me.lblCodigoFormato.Size = New System.Drawing.SizeF(0.8125!, 0.5!)
        Me.lblCodigoFormato.Text = "CB9"
        Me.lblCodigoFormato.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'rptStbPersonaNatural
        '
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.01042!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        CType(Me.lblCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSexo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreyA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSexo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDomicilio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkActivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoFormato, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblCodigo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombreA As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCedula As DataDynamics.ActiveReports.Label
    Friend WithEvents lblSexo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFechaN As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDomicilio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents lblFax As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFechaN As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFx As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblActivo As DataDynamics.ActiveReports.Label
    Friend WithEvents ChkActivo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCodigo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtSexo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDomicilio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTelefono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreyA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtParametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtParametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodigoFormato As DataDynamics.ActiveReports.Label
End Class
