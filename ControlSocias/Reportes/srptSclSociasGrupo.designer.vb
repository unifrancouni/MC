<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class srptSclSociasGrupo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(srptSclSociasGrupo))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtDireccion = New DataDynamics.ActiveReports.TextBox
        Me.txtNombreApellido = New DataDynamics.ActiveReports.TextBox
        Me.txtTipoNegocio = New DataDynamics.ActiveReports.TextBox
        Me.txtNumero = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Line2 = New DataDynamics.ActiveReports.Line
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreApellido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.CanGrow = False
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtDireccion, Me.txtNombreApellido, Me.txtTipoNegocio, Me.txtNumero})
        Me.Detail1.Height = 0.2083333!
        Me.Detail1.Name = "Detail1"
        '
        'txtDireccion
        '
        Me.txtDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDireccion.DistinctField = Nothing
        Me.txtDireccion.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = CType(resources.GetObject("txtDireccion.Location"), System.Drawing.PointF)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.OutputFormat = Nothing
        Me.txtDireccion.Size = New System.Drawing.SizeF(2.38!, 0.19!)
        Me.txtDireccion.Text = Nothing
        Me.txtDireccion.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtNombreApellido
        '
        Me.txtNombreApellido.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreApellido.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreApellido.DistinctField = Nothing
        Me.txtNombreApellido.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreApellido.Location = CType(resources.GetObject("txtNombreApellido.Location"), System.Drawing.PointF)
        Me.txtNombreApellido.Name = "txtNombreApellido"
        Me.txtNombreApellido.OutputFormat = Nothing
        Me.txtNombreApellido.Size = New System.Drawing.SizeF(2.63!, 0.19!)
        Me.txtNombreApellido.Text = Nothing
        Me.txtNombreApellido.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtTipoNegocio
        '
        Me.txtTipoNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.DistinctField = Nothing
        Me.txtTipoNegocio.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoNegocio.Location = CType(resources.GetObject("txtTipoNegocio.Location"), System.Drawing.PointF)
        Me.txtTipoNegocio.Name = "txtTipoNegocio"
        Me.txtTipoNegocio.OutputFormat = Nothing
        Me.txtTipoNegocio.Size = New System.Drawing.SizeF(1.88!, 0.19!)
        Me.txtTipoNegocio.Text = Nothing
        Me.txtTipoNegocio.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'txtNumero
        '
        Me.txtNumero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNumero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNumero.DistinctField = Nothing
        Me.txtNumero.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.Location = CType(resources.GetObject("txtNumero.Location"), System.Drawing.PointF)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.OutputFormat = Nothing
        Me.txtNumero.Size = New System.Drawing.SizeF(0.5!, 0.1875!)
        Me.txtNumero.Text = Nothing
        Me.txtNumero.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Label1
        '
        Me.Label1.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.HyperLink = Nothing
        Me.Label1.Location = CType(resources.GetObject("Label1.Location"), System.Drawing.PointF)
        Me.Label1.MultiLine = False
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.SizeF(7.3125!, 0.1875!)
        Me.Label1.Text = "Quiénes lo conforman?"
        Me.Label1.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label2
        '
        Me.Label2.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.HyperLink = Nothing
        Me.Label2.Location = CType(resources.GetObject("Label2.Location"), System.Drawing.PointF)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.SizeF(2.625!, 0.1875!)
        Me.Label2.Text = "Nombre y Apellidos"
        Me.Label2.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label3
        '
        Me.Label3.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.HyperLink = Nothing
        Me.Label3.Location = CType(resources.GetObject("Label3.Location"), System.Drawing.PointF)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.SizeF(1.875!, 0.1875!)
        Me.Label3.Text = "Tipo de Negocio"
        Me.Label3.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Label4
        '
        Me.Label4.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.HyperLink = Nothing
        Me.Label4.Location = CType(resources.GetObject("Label4.Location"), System.Drawing.PointF)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.SizeF(2.375!, 0.1875!)
        Me.Label4.Text = "Dirección"
        Me.Label4.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'Line1
        '
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.X1 = 0.01041667!
        Me.Line1.X2 = 7.375!
        Me.Line1.Y1 = 0.3645973!
        Me.Line1.Y2 = 0.3645973!
        '
        'Label5
        '
        Me.Label5.Alignment = DataDynamics.ActiveReports.TextAlignment.Center
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.HyperLink = Nothing
        Me.Label5.Location = CType(resources.GetObject("Label5.Location"), System.Drawing.PointF)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.SizeF(0.4375!, 0.1875!)
        Me.Label5.Text = "No."
        Me.Label5.VerticalAlignment = DataDynamics.ActiveReports.VerticalTextAlignment.Middle
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label5, Me.Label1, Me.Label2, Me.Label3, Me.Label4, Me.Line1, Me.Line2})
        Me.GroupHeader1.Height = 0.5833333!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Line2
        '
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.X1 = 0.01041667!
        Me.Line2.X2 = 7.375!
        Me.Line2.Y1 = 0.5729167!
        Me.Line2.Y2 = 0.5729167!
        '
        'srptSclSociasGrupo
        '
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.40625!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreApellido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtDireccion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreApellido As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipoNegocio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNumero As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
End Class
