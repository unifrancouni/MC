<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class srptSclCreditosDenegados
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
    REM Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(srptSclCreditosDenegados))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtsCodSocia = New DataDynamics.ActiveReports.TextBox
        Me.txtNombreGS = New DataDynamics.ActiveReports.TextBox
        Me.txtTipoNegocio = New DataDynamics.ActiveReports.TextBox
        Me.txtsCodGS = New DataDynamics.ActiveReports.TextBox
        Me.txtTexto = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoS = New DataDynamics.ActiveReports.TextBox
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.Line22 = New DataDynamics.ActiveReports.Line
        Me.Line35 = New DataDynamics.ActiveReports.Line
        Me.txtNombreSocia = New DataDynamics.ActiveReports.TextBox
        Me.Line37 = New DataDynamics.ActiveReports.Line
        Me.Line39 = New DataDynamics.ActiveReports.Line
        Me.Line38 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.Shape3 = New DataDynamics.ActiveReports.Shape
        Me.lblTotalG = New DataDynamics.ActiveReports.Label
        Me.Line29 = New DataDynamics.ActiveReports.Line
        Me.Line30 = New DataDynamics.ActiveReports.Line
        Me.txtsMontoSTg = New DataDynamics.ActiveReports.TextBox
        Me.Line25 = New DataDynamics.ActiveReports.Line
        Me.Line27 = New DataDynamics.ActiveReports.Line
        Me.txtsCuentaSociag = New DataDynamics.ActiveReports.TextBox
        Me.txtsCuentaGSg = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.lblDepartamento = New DataDynamics.ActiveReports.Label
        Me.txtDepartamento = New DataDynamics.ActiveReports.TextBox
        Me.lblMunicipio = New DataDynamics.ActiveReports.Label
        Me.txtMunicipio = New DataDynamics.ActiveReports.TextBox
        Me.lblGrupo = New DataDynamics.ActiveReports.Label
        Me.txtGrupo = New DataDynamics.ActiveReports.TextBox
        Me.lblTipoNegocio = New DataDynamics.ActiveReports.Label
        Me.lblItem = New DataDynamics.ActiveReports.Label
        Me.lblTexto = New DataDynamics.ActiveReports.Label
        Me.lblNombres = New DataDynamics.ActiveReports.Label
        Me.shpEncabezado = New DataDynamics.ActiveReports.Shape
        Me.lblRechazados = New DataDynamics.ActiveReports.Label
        Me.lblItemGS = New DataDynamics.ActiveReports.Label
        Me.lblItemSocia = New DataDynamics.ActiveReports.Label
        Me.lblGS = New DataDynamics.ActiveReports.Label
        Me.lblMontoS = New DataDynamics.ActiveReports.Label
        Me.lblCausas = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape1 = New DataDynamics.ActiveReports.Shape
        Me.lblDenegadasGrupo = New DataDynamics.ActiveReports.Label
        Me.Line23 = New DataDynamics.ActiveReports.Line
        Me.Line24 = New DataDynamics.ActiveReports.Line
        Me.txtsMontoST = New DataDynamics.ActiveReports.TextBox
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.txtsCuentaSociat = New DataDynamics.ActiveReports.TextBox
        Me.txtsCuentaGSt = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader2 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter2 = New DataDynamics.ActiveReports.GroupFooter
        Me.Shape2 = New DataDynamics.ActiveReports.Shape
        Me.lblSubtotalGS = New DataDynamics.ActiveReports.Label
        Me.Line17 = New DataDynamics.ActiveReports.Line
        Me.Line18 = New DataDynamics.ActiveReports.Line
        Me.Line19 = New DataDynamics.ActiveReports.Line
        Me.txtsMontoSSt = New DataDynamics.ActiveReports.TextBox
        Me.Line11 = New DataDynamics.ActiveReports.Line
        Me.Line10 = New DataDynamics.ActiveReports.Line
        Me.txtsCuentaSocia = New DataDynamics.ActiveReports.TextBox
        Me.Line20 = New DataDynamics.ActiveReports.Line
        Me.txtsCuentaGS = New DataDynamics.ActiveReports.TextBox
        Me.Line21 = New DataDynamics.ActiveReports.Line
        Me.GroupHeader3 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter3 = New DataDynamics.ActiveReports.GroupFooter
        Me.txtPie = New DataDynamics.ActiveReports.TextBox
        CType(Me.txtsCodSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsCodGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTexto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTotalG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsMontoSTg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsCuentaSociag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsCuentaGSg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTexto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRechazados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItemGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblItemSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCausas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDenegadasGrupo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsMontoST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsCuentaSociat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsCuentaGSt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblSubtotalGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsMontoSSt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsCuentaSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtsCuentaGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPie, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.CanGrow = False
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtsCodSocia, Me.txtNombreGS, Me.txtTipoNegocio, Me.txtsCodGS, Me.txtTexto, Me.txtMontoS, Me.txtObservaciones, Me.Line22, Me.Line35, Me.txtNombreSocia, Me.Line37, Me.Line39, Me.Line38, Me.Line3, Me.Line4})
        Me.Detail1.Height = 0.6979167!
        Me.Detail1.Name = "Detail1"
        '
        'txtsCodSocia
        '
        Me.txtsCodSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCodSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtsCodSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCodSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtsCodSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCodSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtsCodSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCodSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtsCodSocia.CanGrow = False
        Me.txtsCodSocia.Height = 0.6875!
        Me.txtsCodSocia.Left = 0.5!
        Me.txtsCodSocia.Name = "txtsCodSocia"
        Me.txtsCodSocia.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtsCodSocia.Text = Nothing
        Me.txtsCodSocia.Top = 0.0!
        Me.txtsCodSocia.Width = 0.375!
        '
        'txtNombreGS
        '
        Me.txtNombreGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreGS.CanGrow = False
        Me.txtNombreGS.DataField = "NombreGS"
        Me.txtNombreGS.Height = 0.6875!
        Me.txtNombreGS.Left = 2.375!
        Me.txtNombreGS.Name = "txtNombreGS"
        Me.txtNombreGS.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombreGS.Text = Nothing
        Me.txtNombreGS.Top = 0.0!
        Me.txtNombreGS.Width = 1.125!
        '
        'txtTipoNegocio
        '
        Me.txtTipoNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocio.CanGrow = False
        Me.txtTipoNegocio.DataField = "TipoNegocio"
        Me.txtTipoNegocio.Height = 0.6875!
        Me.txtTipoNegocio.Left = 5.0625!
        Me.txtTipoNegocio.Name = "txtTipoNegocio"
        Me.txtTipoNegocio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTipoNegocio.Text = Nothing
        Me.txtTipoNegocio.Top = 0.0!
        Me.txtTipoNegocio.Width = 1.375!
        '
        'txtsCodGS
        '
        Me.txtsCodGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCodGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCodGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCodGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCodGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCodGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCodGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCodGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCodGS.CanGrow = False
        Me.txtsCodGS.Height = 0.6875!
        Me.txtsCodGS.Left = 0.0625!
        Me.txtsCodGS.Name = "txtsCodGS"
        Me.txtsCodGS.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtsCodGS.Text = Nothing
        Me.txtsCodGS.Top = 0.0!
        Me.txtsCodGS.Width = 0.4375!
        '
        'txtTexto
        '
        Me.txtTexto.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTexto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTexto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.Border.RightColor = System.Drawing.Color.Black
        Me.txtTexto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.Border.TopColor = System.Drawing.Color.Black
        Me.txtTexto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTexto.CanGrow = False
        Me.txtTexto.DataField = "Texto"
        Me.txtTexto.Height = 0.6875!
        Me.txtTexto.Left = 0.9375!
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTexto.Text = Nothing
        Me.txtTexto.Top = 0.0!
        Me.txtTexto.Width = 1.375!
        '
        'txtMontoS
        '
        Me.txtMontoS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoS.CanGrow = False
        Me.txtMontoS.DataField = "MontoSolicitado"
        Me.txtMontoS.Height = 0.6875!
        Me.txtMontoS.Left = 6.4375!
        Me.txtMontoS.Name = "txtMontoS"
        Me.txtMontoS.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoS.Text = Nothing
        Me.txtMontoS.Top = 0.0!
        Me.txtMontoS.Width = 0.8125!
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObservaciones.CanGrow = False
        Me.txtObservaciones.DataField = "sObservacion"
        Me.txtObservaciones.Height = 0.6875!
        Me.txtObservaciones.Left = 7.3125!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "ddo-char-set: 0; text-align: justify; font-size: 8.25pt; vertical-align: top; "
        Me.txtObservaciones.Text = Nothing
        Me.txtObservaciones.Top = 0.0!
        Me.txtObservaciones.Width = 2.6875!
        '
        'Line22
        '
        Me.Line22.Border.BottomColor = System.Drawing.Color.Black
        Me.Line22.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Border.LeftColor = System.Drawing.Color.Black
        Me.Line22.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Border.RightColor = System.Drawing.Color.Black
        Me.Line22.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Border.TopColor = System.Drawing.Color.Black
        Me.Line22.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line22.Height = 0.0!
        Me.Line22.Left = 0.875!
        Me.Line22.LineWeight = 1.0!
        Me.Line22.Name = "Line22"
        Me.Line22.Top = 0.6875!
        Me.Line22.Width = 2.625!
        Me.Line22.X1 = 0.875!
        Me.Line22.X2 = 3.5!
        Me.Line22.Y1 = 0.6875!
        Me.Line22.Y2 = 0.6875!
        '
        'Line35
        '
        Me.Line35.Border.BottomColor = System.Drawing.Color.Black
        Me.Line35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Border.LeftColor = System.Drawing.Color.Black
        Me.Line35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Border.RightColor = System.Drawing.Color.Black
        Me.Line35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Border.TopColor = System.Drawing.Color.Black
        Me.Line35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line35.Height = 0.0!
        Me.Line35.Left = 0.0625!
        Me.Line35.LineWeight = 1.0!
        Me.Line35.Name = "Line35"
        Me.Line35.Top = 0.6875!
        Me.Line35.Width = 0.4375!
        Me.Line35.X1 = 0.0625!
        Me.Line35.X2 = 0.5!
        Me.Line35.Y1 = 0.6875!
        Me.Line35.Y2 = 0.6875!
        '
        'txtNombreSocia
        '
        Me.txtNombreSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreSocia.CanGrow = False
        Me.txtNombreSocia.DataField = "NombreSocia"
        Me.txtNombreSocia.Height = 0.6875!
        Me.txtNombreSocia.Left = 3.5!
        Me.txtNombreSocia.Name = "txtNombreSocia"
        Me.txtNombreSocia.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombreSocia.Text = Nothing
        Me.txtNombreSocia.Top = 0.0!
        Me.txtNombreSocia.Width = 1.5625!
        '
        'Line37
        '
        Me.Line37.Border.BottomColor = System.Drawing.Color.Black
        Me.Line37.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Border.LeftColor = System.Drawing.Color.Black
        Me.Line37.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Border.RightColor = System.Drawing.Color.Black
        Me.Line37.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Border.TopColor = System.Drawing.Color.Black
        Me.Line37.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line37.Height = 0.6875!
        Me.Line37.Left = 2.3125!
        Me.Line37.LineWeight = 1.0!
        Me.Line37.Name = "Line37"
        Me.Line37.Top = 0.0!
        Me.Line37.Width = 0.0!
        Me.Line37.X1 = 2.3125!
        Me.Line37.X2 = 2.3125!
        Me.Line37.Y1 = 0.0!
        Me.Line37.Y2 = 0.6875!
        '
        'Line39
        '
        Me.Line39.Border.BottomColor = System.Drawing.Color.Black
        Me.Line39.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Border.LeftColor = System.Drawing.Color.Black
        Me.Line39.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Border.RightColor = System.Drawing.Color.Black
        Me.Line39.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Border.TopColor = System.Drawing.Color.Black
        Me.Line39.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line39.Height = 0.6875!
        Me.Line39.Left = 0.5!
        Me.Line39.LineWeight = 1.0!
        Me.Line39.Name = "Line39"
        Me.Line39.Top = 0.0!
        Me.Line39.Width = 0.0!
        Me.Line39.X1 = 0.5!
        Me.Line39.X2 = 0.5!
        Me.Line39.Y1 = 0.0!
        Me.Line39.Y2 = 0.6875!
        '
        'Line38
        '
        Me.Line38.Border.BottomColor = System.Drawing.Color.Black
        Me.Line38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Border.LeftColor = System.Drawing.Color.Black
        Me.Line38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Border.RightColor = System.Drawing.Color.Black
        Me.Line38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Border.TopColor = System.Drawing.Color.Black
        Me.Line38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line38.Height = 0.6875!
        Me.Line38.Left = 0.0625!
        Me.Line38.LineWeight = 1.0!
        Me.Line38.Name = "Line38"
        Me.Line38.Top = 0.0!
        Me.Line38.Width = 0.0!
        Me.Line38.X1 = 0.0625!
        Me.Line38.X2 = 0.0625!
        Me.Line38.Y1 = 0.0!
        Me.Line38.Y2 = 0.6875!
        '
        'Line3
        '
        Me.Line3.Border.BottomColor = System.Drawing.Color.Black
        Me.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.LeftColor = System.Drawing.Color.Black
        Me.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.RightColor = System.Drawing.Color.Black
        Me.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Border.TopColor = System.Drawing.Color.Black
        Me.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line3.Height = 0.0!
        Me.Line3.Left = 7.25!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.6875!
        Me.Line3.Width = 2.75!
        Me.Line3.X1 = 7.25!
        Me.Line3.X2 = 10.0!
        Me.Line3.Y1 = 0.6875!
        Me.Line3.Y2 = 0.6875!
        '
        'Line4
        '
        Me.Line4.Border.BottomColor = System.Drawing.Color.Black
        Me.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.LeftColor = System.Drawing.Color.Black
        Me.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.RightColor = System.Drawing.Color.Black
        Me.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Border.TopColor = System.Drawing.Color.Black
        Me.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line4.Height = 0.6875!
        Me.Line4.Left = 10.0!
        Me.Line4.LineWeight = 1.0!
        Me.Line4.Name = "Line4"
        Me.Line4.Top = 0.0!
        Me.Line4.Width = 0.0!
        Me.Line4.X1 = 10.0!
        Me.Line4.X2 = 10.0!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.6875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Shape3
        '
        Me.Shape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Shape3.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.RightColor = System.Drawing.Color.Black
        Me.Shape3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Border.TopColor = System.Drawing.Color.Black
        Me.Shape3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape3.Height = 0.25!
        Me.Shape3.Left = 0.0625!
        Me.Shape3.Name = "Shape3"
        Me.Shape3.RoundingRadius = 9.999999!
        Me.Shape3.Top = 0.0!
        Me.Shape3.Width = 9.9375!
        '
        'lblTotalG
        '
        Me.lblTotalG.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Border.RightColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Border.TopColor = System.Drawing.Color.Black
        Me.lblTotalG.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTotalG.Height = 0.125!
        Me.lblTotalG.HyperLink = Nothing
        Me.lblTotalG.Left = 1.0625!
        Me.lblTotalG.Name = "lblTotalG"
        Me.lblTotalG.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; vertical" & _
            "-align: middle; "
        Me.lblTotalG.Text = "TOTAL GENERAL SOLICITUDES DENEGADAS"
        Me.lblTotalG.Top = 0.0625!
        Me.lblTotalG.Width = 5.0625!
        '
        'Line29
        '
        Me.Line29.Border.BottomColor = System.Drawing.Color.Black
        Me.Line29.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Border.LeftColor = System.Drawing.Color.Black
        Me.Line29.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Border.RightColor = System.Drawing.Color.Black
        Me.Line29.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Border.TopColor = System.Drawing.Color.Black
        Me.Line29.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line29.Height = 0.25!
        Me.Line29.Left = 0.875!
        Me.Line29.LineWeight = 1.0!
        Me.Line29.Name = "Line29"
        Me.Line29.Top = 0.0!
        Me.Line29.Width = 0.0!
        Me.Line29.X1 = 0.875!
        Me.Line29.X2 = 0.875!
        Me.Line29.Y1 = 0.0!
        Me.Line29.Y2 = 0.25!
        '
        'Line30
        '
        Me.Line30.Border.BottomColor = System.Drawing.Color.Black
        Me.Line30.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Border.LeftColor = System.Drawing.Color.Black
        Me.Line30.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Border.RightColor = System.Drawing.Color.Black
        Me.Line30.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Border.TopColor = System.Drawing.Color.Black
        Me.Line30.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line30.Height = 0.25!
        Me.Line30.Left = 0.5!
        Me.Line30.LineWeight = 1.0!
        Me.Line30.Name = "Line30"
        Me.Line30.Top = 0.0!
        Me.Line30.Width = 0.0!
        Me.Line30.X1 = 0.5!
        Me.Line30.X2 = 0.5!
        Me.Line30.Y1 = 0.0!
        Me.Line30.Y2 = 0.25!
        '
        'txtsMontoSTg
        '
        Me.txtsMontoSTg.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsMontoSTg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSTg.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsMontoSTg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSTg.Border.RightColor = System.Drawing.Color.Black
        Me.txtsMontoSTg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSTg.Border.TopColor = System.Drawing.Color.Black
        Me.txtsMontoSTg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSTg.CanGrow = False
        Me.txtsMontoSTg.DataField = "MontoSolicitado"
        Me.txtsMontoSTg.Height = 0.25!
        Me.txtsMontoSTg.Left = 6.4375!
        Me.txtsMontoSTg.Name = "txtsMontoSTg"
        Me.txtsMontoSTg.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtsMontoSTg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtsMontoSTg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtsMontoSTg.Text = Nothing
        Me.txtsMontoSTg.Top = 0.0!
        Me.txtsMontoSTg.Width = 0.8125!
        '
        'Line25
        '
        Me.Line25.Border.BottomColor = System.Drawing.Color.Black
        Me.Line25.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Border.LeftColor = System.Drawing.Color.Black
        Me.Line25.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Border.RightColor = System.Drawing.Color.Black
        Me.Line25.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Border.TopColor = System.Drawing.Color.Black
        Me.Line25.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line25.Height = 0.25!
        Me.Line25.Left = 6.4375!
        Me.Line25.LineWeight = 1.0!
        Me.Line25.Name = "Line25"
        Me.Line25.Top = 0.0!
        Me.Line25.Width = 0.0!
        Me.Line25.X1 = 6.4375!
        Me.Line25.X2 = 6.4375!
        Me.Line25.Y1 = 0.0!
        Me.Line25.Y2 = 0.25!
        '
        'Line27
        '
        Me.Line27.Border.BottomColor = System.Drawing.Color.Black
        Me.Line27.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Border.LeftColor = System.Drawing.Color.Black
        Me.Line27.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Border.RightColor = System.Drawing.Color.Black
        Me.Line27.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Border.TopColor = System.Drawing.Color.Black
        Me.Line27.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line27.Height = 0.25!
        Me.Line27.Left = 7.25!
        Me.Line27.LineWeight = 1.0!
        Me.Line27.Name = "Line27"
        Me.Line27.Top = 0.0!
        Me.Line27.Width = 0.0!
        Me.Line27.X1 = 7.25!
        Me.Line27.X2 = 7.25!
        Me.Line27.Y1 = 0.0!
        Me.Line27.Y2 = 0.25!
        '
        'txtsCuentaSociag
        '
        Me.txtsCuentaSociag.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCuentaSociag.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociag.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCuentaSociag.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociag.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCuentaSociag.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociag.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCuentaSociag.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociag.CanGrow = False
        Me.txtsCuentaSociag.DataField = "nSclSociaID"
        Me.txtsCuentaSociag.Height = 0.25!
        Me.txtsCuentaSociag.Left = 0.5!
        Me.txtsCuentaSociag.Name = "txtsCuentaSociag"
        Me.txtsCuentaSociag.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtsCuentaSociag.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtsCuentaSociag.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtsCuentaSociag.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtsCuentaSociag.Text = Nothing
        Me.txtsCuentaSociag.Top = 0.0!
        Me.txtsCuentaSociag.Width = 0.375!
        '
        'txtsCuentaGSg
        '
        Me.txtsCuentaGSg.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCuentaGSg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSg.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCuentaGSg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSg.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCuentaGSg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSg.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCuentaGSg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSg.CanGrow = False
        Me.txtsCuentaGSg.DataField = "CodigoGS"
        Me.txtsCuentaGSg.DistinctField = "CodigoGS"
        Me.txtsCuentaGSg.Height = 0.25!
        Me.txtsCuentaGSg.Left = 0.0625!
        Me.txtsCuentaGSg.Name = "txtsCuentaGSg"
        Me.txtsCuentaGSg.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtsCuentaGSg.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DCount
        Me.txtsCuentaGSg.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.All
        Me.txtsCuentaGSg.SummaryType = DataDynamics.ActiveReports.SummaryType.GrandTotal
        Me.txtsCuentaGSg.Text = Nothing
        Me.txtsCuentaGSg.Top = 0.0!
        Me.txtsCuentaGSg.Width = 0.4375!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.DataField = "Item"
        Me.GroupHeader1.Height = 0.0!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'lblDepartamento
        '
        Me.lblDepartamento.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Border.RightColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Border.TopColor = System.Drawing.Color.Black
        Me.lblDepartamento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDepartamento.Height = 0.1875!
        Me.lblDepartamento.HyperLink = Nothing
        Me.lblDepartamento.Left = 0.0625!
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDepartamento.Text = "Departamento:"
        Me.lblDepartamento.Top = 0.0625!
        Me.lblDepartamento.Width = 0.9375!
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.RightColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.TopColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.CanGrow = False
        Me.txtDepartamento.DataField = "Departamento"
        Me.txtDepartamento.Height = 0.1875!
        Me.txtDepartamento.Left = 1.0625!
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.Top = 0.0625!
        Me.txtDepartamento.Width = 2.0625!
        '
        'lblMunicipio
        '
        Me.lblMunicipio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Border.RightColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Border.TopColor = System.Drawing.Color.Black
        Me.lblMunicipio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMunicipio.Height = 0.1875!
        Me.lblMunicipio.HyperLink = Nothing
        Me.lblMunicipio.Left = 3.1875!
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.Top = 0.0625!
        Me.lblMunicipio.Width = 0.6875!
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.RightColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.TopColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.CanGrow = False
        Me.txtMunicipio.DataField = "Municipio"
        Me.txtMunicipio.Height = 0.1875!
        Me.txtMunicipio.Left = 3.9375!
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.Top = 0.0625!
        Me.txtMunicipio.Width = 2.0625!
        '
        'lblGrupo
        '
        Me.lblGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.lblGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupo.DataField = "EtiquetaGrupo"
        Me.lblGrupo.Height = 0.1875!
        Me.lblGrupo.HyperLink = Nothing
        Me.lblGrupo.Left = 6.0625!
        Me.lblGrupo.Name = "lblGrupo"
        Me.lblGrupo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblGrupo.Text = "lblGrupo:"
        Me.lblGrupo.Top = 0.0625!
        Me.lblGrupo.Width = 0.6875!
        '
        'txtGrupo
        '
        Me.txtGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.txtGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupo.CanGrow = False
        Me.txtGrupo.DataField = "Grupo"
        Me.txtGrupo.Height = 0.1875!
        Me.txtGrupo.Left = 6.8125!
        Me.txtGrupo.Name = "txtGrupo"
        Me.txtGrupo.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtGrupo.Text = Nothing
        Me.txtGrupo.Top = 0.0625!
        Me.txtGrupo.Width = 3.1875!
        '
        'lblTipoNegocio
        '
        Me.lblTipoNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.lblTipoNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTipoNegocio.Height = 0.4375!
        Me.lblTipoNegocio.HyperLink = Nothing
        Me.lblTipoNegocio.Left = 5.0625!
        Me.lblTipoNegocio.Name = "lblTipoNegocio"
        Me.lblTipoNegocio.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblTipoNegocio.Text = "Plan de Inversión"
        Me.lblTipoNegocio.Top = 0.5625!
        Me.lblTipoNegocio.Width = 1.375!
        '
        'lblItem
        '
        Me.lblItem.Border.BottomColor = System.Drawing.Color.Black
        Me.lblItem.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Border.LeftColor = System.Drawing.Color.Black
        Me.lblItem.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Border.RightColor = System.Drawing.Color.Black
        Me.lblItem.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Border.TopColor = System.Drawing.Color.Black
        Me.lblItem.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItem.Height = 0.25!
        Me.lblItem.HyperLink = Nothing
        Me.lblItem.Left = 0.0625!
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItem.Text = "No."
        Me.lblItem.Top = 0.5625!
        Me.lblItem.Width = 0.8125!
        '
        'lblTexto
        '
        Me.lblTexto.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTexto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTexto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.Border.RightColor = System.Drawing.Color.Black
        Me.lblTexto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.Border.TopColor = System.Drawing.Color.Black
        Me.lblTexto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblTexto.DataField = "EtiquetaTexto"
        Me.lblTexto.Height = 0.4375!
        Me.lblTexto.HyperLink = Nothing
        Me.lblTexto.Left = 0.875!
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblTexto.Text = "Barrio"
        Me.lblTexto.Top = 0.5625!
        Me.lblTexto.Width = 1.4375!
        '
        'lblNombres
        '
        Me.lblNombres.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombres.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombres.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombres.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombres.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblNombres.Height = 0.4375!
        Me.lblNombres.HyperLink = Nothing
        Me.lblNombres.Left = 3.5!
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblNombres.Text = "Nombres y Apellidos"
        Me.lblNombres.Top = 0.5625!
        Me.lblNombres.Width = 1.5625!
        '
        'shpEncabezado
        '
        Me.shpEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.shpEncabezado.Border.BottomColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Border.LeftColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Border.RightColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Border.TopColor = System.Drawing.Color.Black
        Me.shpEncabezado.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.shpEncabezado.Height = 0.25!
        Me.shpEncabezado.Left = 0.0625!
        Me.shpEncabezado.Name = "shpEncabezado"
        Me.shpEncabezado.RoundingRadius = 9.999999!
        Me.shpEncabezado.Top = 0.3125!
        Me.shpEncabezado.Width = 9.9375!
        '
        'lblRechazados
        '
        Me.lblRechazados.Border.BottomColor = System.Drawing.Color.Black
        Me.lblRechazados.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRechazados.Border.LeftColor = System.Drawing.Color.Black
        Me.lblRechazados.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRechazados.Border.RightColor = System.Drawing.Color.Black
        Me.lblRechazados.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRechazados.Border.TopColor = System.Drawing.Color.Black
        Me.lblRechazados.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblRechazados.Height = 0.125!
        Me.lblRechazados.HyperLink = Nothing
        Me.lblRechazados.Left = 0.125!
        Me.lblRechazados.Name = "lblRechazados"
        Me.lblRechazados.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
            "align: middle; "
        Me.lblRechazados.Text = "II. PRESTAMOS RECHAZADOS"
        Me.lblRechazados.Top = 0.375!
        Me.lblRechazados.Width = 9.8125!
        '
        'lblItemGS
        '
        Me.lblItemGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblItemGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemGS.Height = 0.1875!
        Me.lblItemGS.HyperLink = Nothing
        Me.lblItemGS.Left = 0.0625!
        Me.lblItemGS.Name = "lblItemGS"
        Me.lblItemGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItemGS.Text = "Grupo"
        Me.lblItemGS.Top = 0.8125!
        Me.lblItemGS.Width = 0.4375!
        '
        'lblItemSocia
        '
        Me.lblItemSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Border.RightColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Border.TopColor = System.Drawing.Color.Black
        Me.lblItemSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblItemSocia.Height = 0.1875!
        Me.lblItemSocia.HyperLink = Nothing
        Me.lblItemSocia.Left = 0.5!
        Me.lblItemSocia.Name = "lblItemSocia"
        Me.lblItemSocia.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblItemSocia.Text = "Socia"
        Me.lblItemSocia.Top = 0.8125!
        Me.lblItemSocia.Width = 0.375!
        '
        'lblGS
        '
        Me.lblGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblGS.Height = 0.4375!
        Me.lblGS.HyperLink = Nothing
        Me.lblGS.Left = 2.3125!
        Me.lblGS.Name = "lblGS"
        Me.lblGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblGS.Text = "Grupo Solidario"
        Me.lblGS.Top = 0.5625!
        Me.lblGS.Width = 1.1875!
        '
        'lblMontoS
        '
        Me.lblMontoS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblMontoS.Height = 0.4375!
        Me.lblMontoS.HyperLink = Nothing
        Me.lblMontoS.Left = 6.4375!
        Me.lblMontoS.Name = "lblMontoS"
        Me.lblMontoS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblMontoS.Text = "Monto Solicitado (C$)"
        Me.lblMontoS.Top = 0.5625!
        Me.lblMontoS.Width = 0.8125!
        '
        'lblCausas
        '
        Me.lblCausas.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCausas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCausas.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCausas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCausas.Border.RightColor = System.Drawing.Color.Black
        Me.lblCausas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCausas.Border.TopColor = System.Drawing.Color.Black
        Me.lblCausas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.lblCausas.Height = 0.4375!
        Me.lblCausas.HyperLink = Nothing
        Me.lblCausas.Left = 7.25!
        Me.lblCausas.Name = "lblCausas"
        Me.lblCausas.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblCausas.Text = "Causas del Rechazo"
        Me.lblCausas.Top = 0.5625!
        Me.lblCausas.Width = 2.75!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape3, Me.lblTotalG, Me.Line29, Me.Line30, Me.txtsMontoSTg, Me.Line25, Me.Line27, Me.txtsCuentaSociag, Me.txtsCuentaGSg, Me.txtPie})
        Me.GroupFooter1.Height = 0.6145833!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Shape1
        '
        Me.Shape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Shape1.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.RightColor = System.Drawing.Color.Black
        Me.Shape1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Border.TopColor = System.Drawing.Color.Black
        Me.Shape1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape1.Height = 0.25!
        Me.Shape1.Left = 0.0625!
        Me.Shape1.Name = "Shape1"
        Me.Shape1.RoundingRadius = 9.999999!
        Me.Shape1.Top = 0.0!
        Me.Shape1.Width = 9.9375!
        '
        'lblDenegadasGrupo
        '
        Me.lblDenegadasGrupo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDenegadasGrupo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDenegadasGrupo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDenegadasGrupo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDenegadasGrupo.Border.RightColor = System.Drawing.Color.Black
        Me.lblDenegadasGrupo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDenegadasGrupo.Border.TopColor = System.Drawing.Color.Black
        Me.lblDenegadasGrupo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDenegadasGrupo.Height = 0.125!
        Me.lblDenegadasGrupo.HyperLink = Nothing
        Me.lblDenegadasGrupo.Left = 1.0625!
        Me.lblDenegadasGrupo.Name = "lblDenegadasGrupo"
        Me.lblDenegadasGrupo.Style = "ddo-char-set: 0; text-align: left; font-weight: bold; font-size: 8.25pt; vertical" & _
            "-align: middle; "
        Me.lblDenegadasGrupo.Text = "TOTAL SOLICITUDES DENEGADAS"
        Me.lblDenegadasGrupo.Top = 0.0625!
        Me.lblDenegadasGrupo.Width = 5.0625!
        '
        'Line23
        '
        Me.Line23.Border.BottomColor = System.Drawing.Color.Black
        Me.Line23.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Border.LeftColor = System.Drawing.Color.Black
        Me.Line23.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Border.RightColor = System.Drawing.Color.Black
        Me.Line23.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Border.TopColor = System.Drawing.Color.Black
        Me.Line23.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line23.Height = 0.25!
        Me.Line23.Left = 0.875!
        Me.Line23.LineWeight = 1.0!
        Me.Line23.Name = "Line23"
        Me.Line23.Top = 0.0!
        Me.Line23.Width = 0.0!
        Me.Line23.X1 = 0.875!
        Me.Line23.X2 = 0.875!
        Me.Line23.Y1 = 0.0!
        Me.Line23.Y2 = 0.25!
        '
        'Line24
        '
        Me.Line24.Border.BottomColor = System.Drawing.Color.Black
        Me.Line24.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Border.LeftColor = System.Drawing.Color.Black
        Me.Line24.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Border.RightColor = System.Drawing.Color.Black
        Me.Line24.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Border.TopColor = System.Drawing.Color.Black
        Me.Line24.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line24.Height = 0.25!
        Me.Line24.Left = 0.5!
        Me.Line24.LineWeight = 1.0!
        Me.Line24.Name = "Line24"
        Me.Line24.Top = 0.0!
        Me.Line24.Width = 0.0!
        Me.Line24.X1 = 0.5!
        Me.Line24.X2 = 0.5!
        Me.Line24.Y1 = 0.0!
        Me.Line24.Y2 = 0.25!
        '
        'txtsMontoST
        '
        Me.txtsMontoST.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsMontoST.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoST.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsMontoST.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoST.Border.RightColor = System.Drawing.Color.Black
        Me.txtsMontoST.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoST.Border.TopColor = System.Drawing.Color.Black
        Me.txtsMontoST.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoST.CanGrow = False
        Me.txtsMontoST.DataField = "MontoSolicitado"
        Me.txtsMontoST.Height = 0.25!
        Me.txtsMontoST.Left = 6.4375!
        Me.txtsMontoST.Name = "txtsMontoST"
        Me.txtsMontoST.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtsMontoST.SummaryGroup = "GroupHeader2"
        Me.txtsMontoST.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsMontoST.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsMontoST.Text = Nothing
        Me.txtsMontoST.Top = 0.0!
        Me.txtsMontoST.Width = 0.8125!
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
        Me.Line2.Height = 0.25!
        Me.Line2.Left = 7.25!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 7.25!
        Me.Line2.X2 = 7.25!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.25!
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
        Me.Line1.Height = 0.25!
        Me.Line1.Left = 6.4375!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 6.4375!
        Me.Line1.X2 = 6.4375!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.25!
        '
        'txtsCuentaSociat
        '
        Me.txtsCuentaSociat.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCuentaSociat.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociat.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCuentaSociat.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociat.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCuentaSociat.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociat.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCuentaSociat.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSociat.CanGrow = False
        Me.txtsCuentaSociat.DataField = "nSclSociaID"
        Me.txtsCuentaSociat.Height = 0.25!
        Me.txtsCuentaSociat.Left = 0.5!
        Me.txtsCuentaSociat.Name = "txtsCuentaSociat"
        Me.txtsCuentaSociat.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtsCuentaSociat.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtsCuentaSociat.SummaryGroup = "GroupHeader1"
        Me.txtsCuentaSociat.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsCuentaSociat.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsCuentaSociat.Text = Nothing
        Me.txtsCuentaSociat.Top = 0.0!
        Me.txtsCuentaSociat.Width = 0.375!
        '
        'txtsCuentaGSt
        '
        Me.txtsCuentaGSt.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCuentaGSt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSt.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCuentaGSt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSt.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCuentaGSt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSt.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCuentaGSt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGSt.CanGrow = False
        Me.txtsCuentaGSt.DataField = "CodigoGS"
        Me.txtsCuentaGSt.DistinctField = "CodigoGS"
        Me.txtsCuentaGSt.Height = 0.25!
        Me.txtsCuentaGSt.Left = 0.0625!
        Me.txtsCuentaGSt.Name = "txtsCuentaGSt"
        Me.txtsCuentaGSt.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtsCuentaGSt.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DCount
        Me.txtsCuentaGSt.SummaryGroup = "GroupHeader1"
        Me.txtsCuentaGSt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsCuentaGSt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsCuentaGSt.Text = Nothing
        Me.txtsCuentaGSt.Top = 0.0!
        Me.txtsCuentaGSt.Width = 0.4375!
        '
        'GroupHeader2
        '
        Me.GroupHeader2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpEncabezado, Me.txtDepartamento, Me.lblMunicipio, Me.txtMunicipio, Me.lblGrupo, Me.txtGrupo, Me.lblTipoNegocio, Me.lblItem, Me.lblTexto, Me.lblNombres, Me.lblDepartamento, Me.lblRechazados, Me.lblItemGS, Me.lblItemSocia, Me.lblGS, Me.lblMontoS, Me.lblCausas})
        Me.GroupHeader2.DataField = "Grupo"
        Me.GroupHeader2.GroupKeepTogether = DataDynamics.ActiveReports.GroupKeepTogether.FirstDetail
        Me.GroupHeader2.Height = 1.0!
        Me.GroupHeader2.KeepTogether = True
        Me.GroupHeader2.Name = "GroupHeader2"
        Me.GroupHeader2.RepeatStyle = DataDynamics.ActiveReports.RepeatStyle.OnPageIncludeNoDetail
        '
        'GroupFooter2
        '
        Me.GroupFooter2.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape1, Me.lblDenegadasGrupo, Me.Line23, Me.Line24, Me.txtsMontoST, Me.Line2, Me.Line1, Me.txtsCuentaSociat, Me.txtsCuentaGSt})
        Me.GroupFooter2.Height = 0.2708333!
        Me.GroupFooter2.Name = "GroupFooter2"
        '
        'Shape2
        '
        Me.Shape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Shape2.Border.BottomColor = System.Drawing.Color.Black
        Me.Shape2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.LeftColor = System.Drawing.Color.Black
        Me.Shape2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.RightColor = System.Drawing.Color.Black
        Me.Shape2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Border.TopColor = System.Drawing.Color.Black
        Me.Shape2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Shape2.Height = 0.25!
        Me.Shape2.Left = 0.0625!
        Me.Shape2.Name = "Shape2"
        Me.Shape2.RoundingRadius = 9.999999!
        Me.Shape2.Top = 0.0!
        Me.Shape2.Width = 9.9375!
        '
        'lblSubtotalGS
        '
        Me.lblSubtotalGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblSubtotalGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblSubtotalGS.Height = 0.125!
        Me.lblSubtotalGS.HyperLink = Nothing
        Me.lblSubtotalGS.Left = 5.125!
        Me.lblSubtotalGS.Name = "lblSubtotalGS"
        Me.lblSubtotalGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblSubtotalGS.Text = "SUB-TOTAL GRUPO"
        Me.lblSubtotalGS.Top = 0.0625!
        Me.lblSubtotalGS.Width = 1.25!
        '
        'Line17
        '
        Me.Line17.Border.BottomColor = System.Drawing.Color.Black
        Me.Line17.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Border.LeftColor = System.Drawing.Color.Black
        Me.Line17.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Border.RightColor = System.Drawing.Color.Black
        Me.Line17.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Border.TopColor = System.Drawing.Color.Black
        Me.Line17.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line17.Height = 0.25!
        Me.Line17.Left = 5.0625!
        Me.Line17.LineWeight = 1.0!
        Me.Line17.Name = "Line17"
        Me.Line17.Top = 0.0!
        Me.Line17.Width = 0.0!
        Me.Line17.X1 = 5.0625!
        Me.Line17.X2 = 5.0625!
        Me.Line17.Y1 = 0.0!
        Me.Line17.Y2 = 0.25!
        '
        'Line18
        '
        Me.Line18.Border.BottomColor = System.Drawing.Color.Black
        Me.Line18.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Border.LeftColor = System.Drawing.Color.Black
        Me.Line18.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Border.RightColor = System.Drawing.Color.Black
        Me.Line18.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Border.TopColor = System.Drawing.Color.Black
        Me.Line18.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line18.Height = 0.25!
        Me.Line18.Left = 3.5!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 0.0!
        Me.Line18.Width = 0.0!
        Me.Line18.X1 = 3.5!
        Me.Line18.X2 = 3.5!
        Me.Line18.Y1 = 0.0!
        Me.Line18.Y2 = 0.25!
        '
        'Line19
        '
        Me.Line19.Border.BottomColor = System.Drawing.Color.Black
        Me.Line19.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Border.LeftColor = System.Drawing.Color.Black
        Me.Line19.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Border.RightColor = System.Drawing.Color.Black
        Me.Line19.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Border.TopColor = System.Drawing.Color.Black
        Me.Line19.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line19.Height = 0.25!
        Me.Line19.Left = 2.3125!
        Me.Line19.LineWeight = 1.0!
        Me.Line19.Name = "Line19"
        Me.Line19.Top = 0.0!
        Me.Line19.Width = 0.0!
        Me.Line19.X1 = 2.3125!
        Me.Line19.X2 = 2.3125!
        Me.Line19.Y1 = 0.0!
        Me.Line19.Y2 = 0.25!
        '
        'txtsMontoSSt
        '
        Me.txtsMontoSSt.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsMontoSSt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSSt.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsMontoSSt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSSt.Border.RightColor = System.Drawing.Color.Black
        Me.txtsMontoSSt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSSt.Border.TopColor = System.Drawing.Color.Black
        Me.txtsMontoSSt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsMontoSSt.CanGrow = False
        Me.txtsMontoSSt.DataField = "MontoSolicitado"
        Me.txtsMontoSSt.Height = 0.25!
        Me.txtsMontoSSt.Left = 6.4375!
        Me.txtsMontoSSt.Name = "txtsMontoSSt"
        Me.txtsMontoSSt.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtsMontoSSt.SummaryGroup = "GroupHeader3"
        Me.txtsMontoSSt.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsMontoSSt.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsMontoSSt.Text = Nothing
        Me.txtsMontoSSt.Top = 0.0!
        Me.txtsMontoSSt.Width = 0.8125!
        '
        'Line11
        '
        Me.Line11.Border.BottomColor = System.Drawing.Color.Black
        Me.Line11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Border.LeftColor = System.Drawing.Color.Black
        Me.Line11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Border.RightColor = System.Drawing.Color.Black
        Me.Line11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Border.TopColor = System.Drawing.Color.Black
        Me.Line11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line11.Height = 0.25!
        Me.Line11.Left = 7.25!
        Me.Line11.LineWeight = 1.0!
        Me.Line11.Name = "Line11"
        Me.Line11.Top = 0.0!
        Me.Line11.Width = 0.0!
        Me.Line11.X1 = 7.25!
        Me.Line11.X2 = 7.25!
        Me.Line11.Y1 = 0.0!
        Me.Line11.Y2 = 0.25!
        '
        'Line10
        '
        Me.Line10.Border.BottomColor = System.Drawing.Color.Black
        Me.Line10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Border.LeftColor = System.Drawing.Color.Black
        Me.Line10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Border.RightColor = System.Drawing.Color.Black
        Me.Line10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Border.TopColor = System.Drawing.Color.Black
        Me.Line10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line10.Height = 0.25!
        Me.Line10.Left = 6.4375!
        Me.Line10.LineWeight = 1.0!
        Me.Line10.Name = "Line10"
        Me.Line10.Top = 0.0!
        Me.Line10.Width = 0.0!
        Me.Line10.X1 = 6.4375!
        Me.Line10.X2 = 6.4375!
        Me.Line10.Y1 = 0.0!
        Me.Line10.Y2 = 0.25!
        '
        'txtsCuentaSocia
        '
        Me.txtsCuentaSocia.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCuentaSocia.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSocia.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCuentaSocia.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSocia.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCuentaSocia.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSocia.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCuentaSocia.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaSocia.CanGrow = False
        Me.txtsCuentaSocia.DataField = "nSclSociaID"
        Me.txtsCuentaSocia.Height = 0.25!
        Me.txtsCuentaSocia.Left = 0.5!
        Me.txtsCuentaSocia.Name = "txtsCuentaSocia"
        Me.txtsCuentaSocia.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtsCuentaSocia.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.Count
        Me.txtsCuentaSocia.SummaryGroup = "GroupHeader2"
        Me.txtsCuentaSocia.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsCuentaSocia.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsCuentaSocia.Text = Nothing
        Me.txtsCuentaSocia.Top = 0.0!
        Me.txtsCuentaSocia.Width = 0.375!
        '
        'Line20
        '
        Me.Line20.Border.BottomColor = System.Drawing.Color.Black
        Me.Line20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Border.LeftColor = System.Drawing.Color.Black
        Me.Line20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Border.RightColor = System.Drawing.Color.Black
        Me.Line20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Border.TopColor = System.Drawing.Color.Black
        Me.Line20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line20.Height = 0.25!
        Me.Line20.Left = 0.875!
        Me.Line20.LineWeight = 1.0!
        Me.Line20.Name = "Line20"
        Me.Line20.Top = 0.0!
        Me.Line20.Width = 0.0!
        Me.Line20.X1 = 0.875!
        Me.Line20.X2 = 0.875!
        Me.Line20.Y1 = 0.0!
        Me.Line20.Y2 = 0.25!
        '
        'txtsCuentaGS
        '
        Me.txtsCuentaGS.Border.BottomColor = System.Drawing.Color.Black
        Me.txtsCuentaGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGS.Border.LeftColor = System.Drawing.Color.Black
        Me.txtsCuentaGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGS.Border.RightColor = System.Drawing.Color.Black
        Me.txtsCuentaGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGS.Border.TopColor = System.Drawing.Color.Black
        Me.txtsCuentaGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtsCuentaGS.CanGrow = False
        Me.txtsCuentaGS.DataField = "CodigoGS"
        Me.txtsCuentaGS.DistinctField = "CodigoGS"
        Me.txtsCuentaGS.Height = 0.25!
        Me.txtsCuentaGS.Left = 0.0625!
        Me.txtsCuentaGS.Name = "txtsCuentaGS"
        Me.txtsCuentaGS.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.txtsCuentaGS.SummaryFunc = DataDynamics.ActiveReports.SummaryFunc.DCount
        Me.txtsCuentaGS.SummaryGroup = "GroupHeader2"
        Me.txtsCuentaGS.SummaryRunning = DataDynamics.ActiveReports.SummaryRunning.Group
        Me.txtsCuentaGS.SummaryType = DataDynamics.ActiveReports.SummaryType.SubTotal
        Me.txtsCuentaGS.Text = Nothing
        Me.txtsCuentaGS.Top = 0.0!
        Me.txtsCuentaGS.Visible = False
        Me.txtsCuentaGS.Width = 0.4375!
        '
        'Line21
        '
        Me.Line21.Border.BottomColor = System.Drawing.Color.Black
        Me.Line21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Border.LeftColor = System.Drawing.Color.Black
        Me.Line21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Border.RightColor = System.Drawing.Color.Black
        Me.Line21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Border.TopColor = System.Drawing.Color.Black
        Me.Line21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line21.Height = 0.25!
        Me.Line21.Left = 0.5!
        Me.Line21.LineWeight = 1.0!
        Me.Line21.Name = "Line21"
        Me.Line21.Top = 0.0!
        Me.Line21.Width = 0.0!
        Me.Line21.X1 = 0.5!
        Me.Line21.X2 = 0.5!
        Me.Line21.Y1 = 0.0!
        Me.Line21.Y2 = 0.25!
        '
        'GroupHeader3
        '
        Me.GroupHeader3.DataField = "CodigoGS"
        Me.GroupHeader3.Height = 0.0!
        Me.GroupHeader3.Name = "GroupHeader3"
        '
        'GroupFooter3
        '
        Me.GroupFooter3.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Shape2, Me.lblSubtotalGS, Me.Line17, Me.Line18, Me.Line19, Me.txtsMontoSSt, Me.Line11, Me.Line10, Me.txtsCuentaSocia, Me.Line20, Me.txtsCuentaGS, Me.Line21})
        Me.GroupFooter3.Height = 0.21875!
        Me.GroupFooter3.Name = "GroupFooter3"
        '
        'txtPie
        '
        Me.txtPie.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPie.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPie.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPie.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPie.Border.RightColor = System.Drawing.Color.Black
        Me.txtPie.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPie.Border.TopColor = System.Drawing.Color.Black
        Me.txtPie.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPie.CanGrow = False
        Me.txtPie.Height = 0.1875!
        Me.txtPie.Left = 0.125!
        Me.txtPie.Name = "txtPie"
        Me.txtPie.Style = "ddo-char-set: 0; text-align: justify; font-size: 9pt; vertical-align: top; "
        Me.txtPie.Text = Nothing
        Me.txtPie.Top = 0.375!
        Me.txtPie.Width = 9.875!
        '
        'srptSclCreditosDenegados
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 10.07291!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.GroupHeader2)
        Me.Sections.Add(Me.GroupHeader3)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter3)
        Me.Sections.Add(Me.GroupFooter2)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.txtsCodSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsCodGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTexto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTotalG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsMontoSTg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsCuentaSociag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsCuentaGSg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTexto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombres, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRechazados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItemGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblItemSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCausas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDenegadasGrupo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsMontoST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsCuentaSociat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsCuentaGSt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblSubtotalGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsMontoSSt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsCuentaSocia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtsCuentaGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPie, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblDepartamento As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDepartamento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMunicipio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMunicipio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblGrupo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtGrupo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTipoNegocio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblItem As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTexto As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNombres As DataDynamics.ActiveReports.Label
    Friend WithEvents shpEncabezado As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblRechazados As DataDynamics.ActiveReports.Label
    Friend WithEvents lblItemGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblItemSocia As DataDynamics.ActiveReports.Label
    Friend WithEvents lblGS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblMontoS As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCausas As DataDynamics.ActiveReports.Label
    Friend WithEvents txtsCodSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipoNegocio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtsCodGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTexto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtObservaciones As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line22 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line35 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtNombreSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line37 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line39 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader2 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter2 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Shape2 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblSubtotalGS As DataDynamics.ActiveReports.Label
    Friend WithEvents Line17 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line18 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line19 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtsMontoSSt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line11 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line10 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtsCuentaSocia As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line20 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtsCuentaGS As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line21 As DataDynamics.ActiveReports.Line
    Friend WithEvents Shape1 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblDenegadasGrupo As DataDynamics.ActiveReports.Label
    Friend WithEvents Line23 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line24 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtsMontoST As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtsCuentaSociat As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtsCuentaGSt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Shape3 As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblTotalG As DataDynamics.ActiveReports.Label
    Friend WithEvents Line29 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line30 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtsMontoSTg As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line25 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line27 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtsCuentaSociag As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtsCuentaGSg As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line38 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader3 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter3 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtPie As DataDynamics.ActiveReports.TextBox
End Class
