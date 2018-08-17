<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSsgAcciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptSsgAcciones))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblOpcionesMenu = New DataDynamics.ActiveReports.Label
        Me.lblPermiso = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.lblAccion = New DataDynamics.ActiveReports.Label
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtAccion = New DataDynamics.ActiveReports.TextBox
        Me.txtServicioUsuario = New DataDynamics.ActiveReports.TextBox
        Me.chkPermiso = New DataDynamics.ActiveReports.CheckBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.txtparametro1 = New DataDynamics.ActiveReports.TextBox
        Me.txtparametro2 = New DataDynamics.ActiveReports.TextBox
        Me.ReportInfo1 = New DataDynamics.ActiveReports.ReportInfo
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.EncabezadoReporte = New DataDynamics.ActiveReports.ReportHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblModulo = New DataDynamics.ActiveReports.Label
        Me.txtModulo = New DataDynamics.ActiveReports.TextBox
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
        Me.Label3 = New DataDynamics.ActiveReports.Label
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblOpcionesMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPermiso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblAccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServicioUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkPermiso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.Label1, Me.TextBox2, Me.Label2, Me.TextBox3, Me.Label3})
        Me.PageHeader1.Height = 1.802083!
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
        Me.lblTitulo.Text = "Listado de Acciones del Sistema"
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
        Me.Label1.Text = "SG1"
        Me.Label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblOpcionesMenu
        '
        Me.lblOpcionesMenu.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOpcionesMenu.HyperLink = Nothing
        Me.lblOpcionesMenu.Location = CType(resources.GetObject("lblOpcionesMenu.Location"), System.Drawing.PointF)
        Me.lblOpcionesMenu.Name = "lblOpcionesMenu"
        Me.lblOpcionesMenu.Size = New System.Drawing.SizeF(2.9375!, 0.1875!)
        Me.lblOpcionesMenu.Text = "Opción del Menú"
        Me.lblOpcionesMenu.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'lblPermiso
        '
        Me.lblPermiso.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPermiso.HyperLink = Nothing
        Me.lblPermiso.Location = CType(resources.GetObject("lblPermiso.Location"), System.Drawing.PointF)
        Me.lblPermiso.Name = "lblPermiso"
        Me.lblPermiso.Size = New System.Drawing.SizeF(0.6875!, 0.1875!)
        Me.lblPermiso.Text = "¿Permiso?"
        Me.lblPermiso.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Line1
        '
        Me.Line1.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.02083333!
        Me.Line1.X2 = 7.468749!
        Me.Line1.Y1 = 0.4479167!
        Me.Line1.Y2 = 0.4479167!
        '
        'Line3
        '
        Me.Line3.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.X1 = 0.01041667!
        Me.Line3.X2 = 7.458333!
        Me.Line3.Y1 = 0.6979167!
        Me.Line3.Y2 = 0.6979167!
        '
        'lblAccion
        '
        Me.lblAccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccion.HyperLink = Nothing
        Me.lblAccion.Location = CType(resources.GetObject("lblAccion.Location"), System.Drawing.PointF)
        Me.lblAccion.Name = "lblAccion"
        Me.lblAccion.Size = New System.Drawing.SizeF(3.5625!, 0.25!)
        Me.lblAccion.Text = "Acción"
        Me.lblAccion.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
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
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtAccion, Me.txtServicioUsuario, Me.chkPermiso})
        Me.Detail1.Height = 0.2291667!
        Me.Detail1.Name = "Detail1"
        '
        'txtAccion
        '
        Me.txtAccion.DistinctField = Nothing
        Me.txtAccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccion.Location = CType(resources.GetObject("txtAccion.Location"), System.Drawing.PointF)
        Me.txtAccion.Name = "txtAccion"
        Me.txtAccion.OutputFormat = Nothing
        Me.txtAccion.Size = New System.Drawing.SizeF(3.5625!, 0.1875!)
        Me.txtAccion.Text = Nothing
        Me.txtAccion.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtServicioUsuario
        '
        Me.txtServicioUsuario.DistinctField = Nothing
        Me.txtServicioUsuario.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicioUsuario.Location = CType(resources.GetObject("txtServicioUsuario.Location"), System.Drawing.PointF)
        Me.txtServicioUsuario.Name = "txtServicioUsuario"
        Me.txtServicioUsuario.OutputFormat = Nothing
        Me.txtServicioUsuario.Size = New System.Drawing.SizeF(2.9375!, 0.1875!)
        Me.txtServicioUsuario.Text = Nothing
        Me.txtServicioUsuario.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'chkPermiso
        '
        Me.chkPermiso.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkPermiso.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPermiso.Location = CType(resources.GetObject("chkPermiso.Location"), System.Drawing.PointF)
        Me.chkPermiso.Name = "chkPermiso"
        Me.chkPermiso.Size = New System.Drawing.SizeF(0.25!, 0.1875!)
        Me.chkPermiso.Text = ""
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
        Me.TextBox1.Size = New System.Drawing.SizeF(0.6875!, 0.1875!)
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
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblOpcionesMenu, Me.lblPermiso, Me.Line1, Me.Line3, Me.lblAccion, Me.lblModulo, Me.txtModulo})
        Me.GroupHeader1.DataField = "SsgModuloID"
        Me.GroupHeader1.Height = 0.75!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPage
        '
        'lblModulo
        '
        Me.lblModulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModulo.HyperLink = Nothing
        Me.lblModulo.Location = CType(resources.GetObject("lblModulo.Location"), System.Drawing.PointF)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.SizeF(0.625!, 0.1875!)
        Me.lblModulo.Text = "Módulo:"
        Me.lblModulo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtModulo
        '
        Me.txtModulo.DistinctField = Nothing
        Me.txtModulo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtModulo.Location = CType(resources.GetObject("txtModulo.Location"), System.Drawing.PointF)
        Me.txtModulo.Name = "txtModulo"
        Me.txtModulo.OutputFormat = Nothing
        Me.txtModulo.Size = New System.Drawing.SizeF(4.4375!, 0.1875!)
        Me.txtModulo.Text = Nothing
        Me.txtModulo.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'TextBox2
        '
        Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox2.DistinctField = Nothing
        Me.TextBox2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = CType(resources.GetObject("TextBox2.Location"), System.Drawing.PointF)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.OutputFormat = Nothing
        Me.TextBox2.Size = New System.Drawing.SizeF(4.4375!, 0.1875!)
        Me.TextBox2.Text = Nothing
        Me.TextBox2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.HyperLink = Nothing
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.PointF)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.SizeF(0.6875!, 0.1875!)
        Me.Label2.Text = "Perfil:"
        Me.Label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'TextBox3
        '
        Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.TextBox3.DistinctField = Nothing
        Me.TextBox3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = CType(resources.GetObject("TextBox3.Location"), System.Drawing.PointF)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.OutputFormat = Nothing
        Me.TextBox3.Size = New System.Drawing.SizeF(4.4375!, 0.1875!)
        Me.TextBox3.Text = Nothing
        Me.TextBox3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.HyperLink = Nothing
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.PointF)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.SizeF(1.0!, 0.1875!)
        Me.Label3.Text = "Autorizado por:"
        Me.Label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'rptSsgAcciones
        '
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.489583!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblOpcionesMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPermiso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblAccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServicioUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkPermiso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblUsuario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblAccion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblOpcionesMenu As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtAccion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtServicioUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents chkPermiso As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents lblPermiso As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblModulo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtModulo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
End Class
