<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptEncabezadoH
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptEncabezadoH))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Encabezado = New DataDynamics.ActiveReports.ReportHeader
        Me.logoMinsa = New DataDynamics.ActiveReports.Picture
        Me.logoEscudoNicaragua = New DataDynamics.ActiveReports.Picture
        Me.lblRepublica = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.lblSistema = New DataDynamics.ActiveReports.Label
        Me.Picture1 = New DataDynamics.ActiveReports.Picture
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        CType(Me.logoMinsa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.logoEscudoNicaragua, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRepublica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSistema, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Encabezado.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.logoMinsa, Me.logoEscudoNicaragua, Me.lblRepublica, Me.Label2, Me.lblSistema, Me.Picture1})
        Me.Encabezado.Height = 0.6354167!
        Me.Encabezado.Name = "Encabezado"
        '
        'logoMinsa
        '
        Me.logoMinsa.Border.BottomColor = System.Drawing.Color.Black
        Me.logoMinsa.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoMinsa.Border.LeftColor = System.Drawing.Color.Black
        Me.logoMinsa.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoMinsa.Border.RightColor = System.Drawing.Color.Black
        Me.logoMinsa.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoMinsa.Border.TopColor = System.Drawing.Color.Black
        Me.logoMinsa.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoMinsa.Height = 0.625!
        Me.logoMinsa.Image = Nothing
        Me.logoMinsa.ImageData = Nothing
        Me.logoMinsa.Left = 0.0625!
        Me.logoMinsa.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.logoMinsa.LineWeight = 0.0!
        Me.logoMinsa.Name = "logoMinsa"
        Me.logoMinsa.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.logoMinsa.Top = 0.0625!
        Me.logoMinsa.Width = 0.75!
        '
        'logoEscudoNicaragua
        '
        Me.logoEscudoNicaragua.Border.BottomColor = System.Drawing.Color.Black
        Me.logoEscudoNicaragua.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoEscudoNicaragua.Border.LeftColor = System.Drawing.Color.Black
        Me.logoEscudoNicaragua.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoEscudoNicaragua.Border.RightColor = System.Drawing.Color.Black
        Me.logoEscudoNicaragua.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoEscudoNicaragua.Border.TopColor = System.Drawing.Color.Black
        Me.logoEscudoNicaragua.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.logoEscudoNicaragua.Height = 0.625!
        Me.logoEscudoNicaragua.Image = CType(resources.GetObject("logoEscudoNicaragua.Image"), System.Drawing.Image)
        Me.logoEscudoNicaragua.ImageData = CType(resources.GetObject("logoEscudoNicaragua.ImageData"), System.IO.Stream)
        Me.logoEscudoNicaragua.Left = 9.25!
        Me.logoEscudoNicaragua.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.logoEscudoNicaragua.LineWeight = 0.0!
        Me.logoEscudoNicaragua.Name = "logoEscudoNicaragua"
        Me.logoEscudoNicaragua.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.logoEscudoNicaragua.Top = 0.0!
        Me.logoEscudoNicaragua.Width = 0.6666667!
        '
        'lblRepublica
        '
        Me.lblRepublica.Border.BottomColor = System.Drawing.Color.Black
        Me.lblRepublica.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepublica.Border.LeftColor = System.Drawing.Color.Black
        Me.lblRepublica.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepublica.Border.RightColor = System.Drawing.Color.Black
        Me.lblRepublica.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepublica.Border.TopColor = System.Drawing.Color.Black
        Me.lblRepublica.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRepublica.Height = 0.1875!
        Me.lblRepublica.HyperLink = Nothing
        Me.lblRepublica.Left = 0.0!
        Me.lblRepublica.Name = "lblRepublica"
        Me.lblRepublica.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblRepublica.Text = "REPUBLICA DE NICARAGUA"
        Me.lblRepublica.Top = 0.0625!
        Me.lblRepublica.Width = 9.9375!
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
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.Label2.Text = "PROGRAMA USURA CERO"
        Me.Label2.Top = 0.25!
        Me.Label2.Width = 9.9375!
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
        Me.lblSistema.Height = 0.1875!
        Me.lblSistema.HyperLink = Nothing
        Me.lblSistema.Left = 0.0!
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblSistema.Text = "MINISTERIO DE FOMENTO, INDUSTRIA Y COMERCIO"
        Me.lblSistema.Top = 0.4375!
        Me.lblSistema.Visible = False
        Me.lblSistema.Width = 9.9375!
        '
        'Picture1
        '
        Me.Picture1.Border.BottomColor = System.Drawing.Color.Black
        Me.Picture1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.LeftColor = System.Drawing.Color.Black
        Me.Picture1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.RightColor = System.Drawing.Color.Black
        Me.Picture1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Border.TopColor = System.Drawing.Color.Black
        Me.Picture1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Picture1.Height = 0.625!
        Me.Picture1.Image = CType(resources.GetObject("Picture1.Image"), System.Drawing.Image)
        Me.Picture1.ImageData = CType(resources.GetObject("Picture1.ImageData"), System.IO.Stream)
        Me.Picture1.Left = 0.0625!
        Me.Picture1.LineColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Picture1.LineWeight = 0.0!
        Me.Picture1.Name = "Picture1"
        Me.Picture1.SizeMode = DataDynamics.ActiveReports.SizeModes.Stretch
        Me.Picture1.Top = 0.0!
        Me.Picture1.Width = 1.9375!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'rptEncabezadoH
        '
        Me.MasterReport = False
        Me.PageSettings.Margins.Left = 0.4!
        Me.PageSettings.Margins.Right = 0.4!
        Me.PageSettings.Margins.Top = 0.4!
        Me.PageSettings.Orientation = DataDynamics.ActiveReports.Document.PageOrientation.Landscape
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 10.0!
        Me.Sections.Add(Me.Encabezado)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.logoMinsa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.logoEscudoNicaragua, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRepublica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSistema, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Encabezado As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents logoMinsa As DataDynamics.ActiveReports.Picture
    Friend WithEvents logoEscudoNicaragua As DataDynamics.ActiveReports.Picture
    Friend WithEvents lblRepublica As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblSistema As DataDynamics.ActiveReports.Label
    Friend WithEvents Picture1 As DataDynamics.ActiveReports.Picture
End Class
