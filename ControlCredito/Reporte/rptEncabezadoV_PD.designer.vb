<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptEncabezadoV_PD
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEncabezadoV_PD))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Encabezado = New DataDynamics.ActiveReports.ReportHeader
        Me.lblMinisterio = New DataDynamics.ActiveReports.Label
        Me.LogoEscudoNicaragua = New DataDynamics.ActiveReports.Picture
        Me.lblPais = New DataDynamics.ActiveReports.Label
        Me.LogoMinsa = New DataDynamics.ActiveReports.Picture
        Me.lblSistema = New DataDynamics.ActiveReports.Label
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        CType(Me.lblMinisterio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoEscudoNicaragua, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPais, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoMinsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Height = 0.0!
        Me.Detail1.Name = "Detail1"
        '
        'Encabezado
        '
        Me.Encabezado.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblMinisterio, Me.LogoEscudoNicaragua, Me.lblPais, Me.LogoMinsa, Me.lblSistema})
        Me.Encabezado.Height = 0.7291667!
        Me.Encabezado.Name = "Encabezado"
        '
        'lblMinisterio
        '
        Me.lblMinisterio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Border.RightColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Border.TopColor = System.Drawing.Color.Black
        Me.lblMinisterio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMinisterio.Height = 0.2083333!
        Me.lblMinisterio.HyperLink = Nothing
        Me.lblMinisterio.Left = 0.0625!
        Me.lblMinisterio.Name = "lblMinisterio"
        Me.lblMinisterio.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; "
        Me.lblMinisterio.Text = "PROGRAMA PDIBA"
        Me.lblMinisterio.Top = 0.29!
        Me.lblMinisterio.Width = 7.375!
        '
        'LogoEscudoNicaragua
        '
        Me.LogoEscudoNicaragua.Border.BottomColor = System.Drawing.Color.Black
        Me.LogoEscudoNicaragua.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoEscudoNicaragua.Border.LeftColor = System.Drawing.Color.Black
        Me.LogoEscudoNicaragua.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoEscudoNicaragua.Border.RightColor = System.Drawing.Color.Black
        Me.LogoEscudoNicaragua.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoEscudoNicaragua.Border.TopColor = System.Drawing.Color.Black
        Me.LogoEscudoNicaragua.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoEscudoNicaragua.Height = 0.625!
        Me.LogoEscudoNicaragua.Image = CType(resources.GetObject("LogoEscudoNicaragua.Image"), System.Drawing.Image)
        Me.LogoEscudoNicaragua.ImageData = CType(resources.GetObject("LogoEscudoNicaragua.ImageData"), System.IO.Stream)
        Me.LogoEscudoNicaragua.Left = 0.0625!
        Me.LogoEscudoNicaragua.LineWeight = 0.0!
        Me.LogoEscudoNicaragua.Name = "LogoEscudoNicaragua"
        Me.LogoEscudoNicaragua.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.LogoEscudoNicaragua.Top = 0.0625!
        Me.LogoEscudoNicaragua.Width = 1.9375!
        '
        'lblPais
        '
        Me.lblPais.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPais.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPais.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPais.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPais.Border.RightColor = System.Drawing.Color.Black
        Me.lblPais.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPais.Border.TopColor = System.Drawing.Color.Black
        Me.lblPais.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPais.Height = 0.2083333!
        Me.lblPais.HyperLink = Nothing
        Me.lblPais.Left = 0.0625!
        Me.lblPais.Name = "lblPais"
        Me.lblPais.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; "
        Me.lblPais.Text = "REPUBLICA DE NICARAGUA"
        Me.lblPais.Top = 0.0625!
        Me.lblPais.Width = 7.375!
        '
        'LogoMinsa
        '
        Me.LogoMinsa.Border.BottomColor = System.Drawing.Color.Black
        Me.LogoMinsa.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoMinsa.Border.LeftColor = System.Drawing.Color.Black
        Me.LogoMinsa.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoMinsa.Border.RightColor = System.Drawing.Color.Black
        Me.LogoMinsa.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoMinsa.Border.TopColor = System.Drawing.Color.Black
        Me.LogoMinsa.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LogoMinsa.Height = 0.6875!
        Me.LogoMinsa.Image = CType(resources.GetObject("LogoMinsa.Image"), System.Drawing.Image)
        Me.LogoMinsa.ImageData = CType(resources.GetObject("LogoMinsa.ImageData"), System.IO.Stream)
        Me.LogoMinsa.Left = 6.6875!
        Me.LogoMinsa.LineWeight = 0.0!
        Me.LogoMinsa.Name = "LogoMinsa"
        Me.LogoMinsa.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.LogoMinsa.Top = 0.0!
        Me.LogoMinsa.Width = 0.75!
        '
        'lblSistema
        '
        Me.lblSistema.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSistema.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSistema.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSistema.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSistema.Border.RightColor = System.Drawing.Color.Black
        Me.lblSistema.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSistema.Border.TopColor = System.Drawing.Color.Black
        Me.lblSistema.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSistema.Height = 0.2083333!
        Me.lblSistema.HyperLink = Nothing
        Me.lblSistema.Left = 0.0!
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; "
        Me.lblSistema.Text = "MINISTERIO DE FOMENTO, INDUSTRIA Y COMERCIO  "
        Me.lblSistema.Top = 0.5!
        Me.lblSistema.Width = 7.458333!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'rptEncabezadoV_PD
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 7.510417!
        Me.Sections.Add(Me.Encabezado)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblMinisterio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoEscudoNicaragua, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPais, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoMinsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Friend WithEvents Encabezado As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents LogoEscudoNicaragua As DataDynamics.ActiveReports.Picture
    Friend WithEvents lblMinisterio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPais As DataDynamics.ActiveReports.Label
    Friend WithEvents lblSistema As DataDynamics.ActiveReports.Label
    Friend WithEvents LogoMinsa As DataDynamics.ActiveReports.Picture
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
End Class
