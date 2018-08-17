<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class srptSclExpedienteSocia
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(srptSclExpedienteSocia))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader()
        Me.Detail1 = New DataDynamics.ActiveReports.Detail()
        Me.txtObserva = New DataDynamics.ActiveReports.TextBox()
        Me.txtDocumento = New DataDynamics.ActiveReports.TextBox()
        Me.txtNo = New DataDynamics.ActiveReports.TextBox()
        Me.Line8 = New DataDynamics.ActiveReports.Line()
        Me.Line1 = New DataDynamics.ActiveReports.Line()
        Me.Line2 = New DataDynamics.ActiveReports.Line()
        Me.Line3 = New DataDynamics.ActiveReports.Line()
        Me.ChkCumple = New DataDynamics.ActiveReports.CheckBox()
        Me.ChkNoCumple = New DataDynamics.ActiveReports.CheckBox()
        Me.shpDetalles = New DataDynamics.ActiveReports.Shape()
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter()
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader()
        Me.shpEncabezado = New DataDynamics.ActiveReports.Shape()
        Me.lblDocumento = New DataDynamics.ActiveReports.Label()
        Me.lblNumero = New DataDynamics.ActiveReports.Label()
        Me.lblCumple = New DataDynamics.ActiveReports.Label()
        Me.lblObserva = New DataDynamics.ActiveReports.Label()
        Me.Line6 = New DataDynamics.ActiveReports.Line()
        Me.Line18 = New DataDynamics.ActiveReports.Line()
        Me.lblNOCumple = New DataDynamics.ActiveReports.Label()
        Me.Line5 = New DataDynamics.ActiveReports.Line()
        Me.Line9 = New DataDynamics.ActiveReports.Line()
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter()
        CType(Me.txtObserva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkCumple, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChkNoCumple, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCumple, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblObserva, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNOCumple, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtObserva, Me.txtDocumento, Me.txtNo, Me.Line8, Me.Line1, Me.Line2, Me.Line3, Me.ChkCumple, Me.ChkNoCumple, Me.shpDetalles})
        Me.Detail1.Height = 0.25!
        Me.Detail1.Name = "Detail1"
        '
        'txtObserva
        '
        Me.txtObserva.Border.BottomColor = System.Drawing.Color.Black
        Me.txtObserva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObserva.Border.LeftColor = System.Drawing.Color.Black
        Me.txtObserva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObserva.Border.RightColor = System.Drawing.Color.Black
        Me.txtObserva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObserva.Border.TopColor = System.Drawing.Color.Black
        Me.txtObserva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtObserva.CanGrow = False
        Me.txtObserva.Height = 0.25!
        Me.txtObserva.Left = 4.625!
        Me.txtObserva.Name = "txtObserva"
        Me.txtObserva.Style = "ddo-char-set: 0; text-align: justify; font-size: 7pt; vertical-align: middle; "
        Me.txtObserva.Text = Nothing
        Me.txtObserva.Top = 0.0!
        Me.txtObserva.Width = 2.75!
        '
        'txtDocumento
        '
        Me.txtDocumento.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDocumento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDocumento.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDocumento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDocumento.Border.RightColor = System.Drawing.Color.Black
        Me.txtDocumento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDocumento.Border.TopColor = System.Drawing.Color.Black
        Me.txtDocumento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDocumento.CanGrow = False
        Me.txtDocumento.DataField = "sDescripcion"
        Me.txtDocumento.Height = 0.25!
        Me.txtDocumento.Left = 0.4375!
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Style = "ddo-char-set: 0; text-align: justify; font-size: 7pt; vertical-align: middle; "
        Me.txtDocumento.Text = Nothing
        Me.txtDocumento.Top = 0.0!
        Me.txtDocumento.Width = 3.0!
        '
        'txtNo
        '
        Me.txtNo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNo.Border.RightColor = System.Drawing.Color.Black
        Me.txtNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNo.Border.TopColor = System.Drawing.Color.Black
        Me.txtNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNo.CanGrow = False
        Me.txtNo.DataField = "sCodigoInterno"
        Me.txtNo.Height = 0.1875!
        Me.txtNo.Left = 0.0!
        Me.txtNo.Name = "txtNo"
        Me.txtNo.Style = "ddo-char-set: 0; text-align: center; font-size: 7pt; vertical-align: middle; "
        Me.txtNo.Text = Nothing
        Me.txtNo.Top = 0.0625!
        Me.txtNo.Width = 0.375!
        '
        'Line8
        '
        Me.Line8.Border.BottomColor = System.Drawing.Color.Black
        Me.Line8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Border.LeftColor = System.Drawing.Color.Black
        Me.Line8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Border.RightColor = System.Drawing.Color.Black
        Me.Line8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Border.TopColor = System.Drawing.Color.Black
        Me.Line8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line8.Height = 0.25!
        Me.Line8.Left = 0.375!
        Me.Line8.LineWeight = 1.0!
        Me.Line8.Name = "Line8"
        Me.Line8.Top = 0.0!
        Me.Line8.Width = 0.0!
        Me.Line8.X1 = 0.375!
        Me.Line8.X2 = 0.375!
        Me.Line8.Y1 = 0.0!
        Me.Line8.Y2 = 0.25!
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
        Me.Line1.Left = 3.4375!
        Me.Line1.LineWeight = 1.0!
        Me.Line1.Name = "Line1"
        Me.Line1.Top = 0.0!
        Me.Line1.Width = 0.0!
        Me.Line1.X1 = 3.4375!
        Me.Line1.X2 = 3.4375!
        Me.Line1.Y1 = 0.0!
        Me.Line1.Y2 = 0.25!
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
        Me.Line2.Left = 4.0!
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 0.0!
        Me.Line2.Width = 0.0!
        Me.Line2.X1 = 4.0!
        Me.Line2.X2 = 4.0!
        Me.Line2.Y1 = 0.0!
        Me.Line2.Y2 = 0.25!
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
        Me.Line3.Height = 0.25!
        Me.Line3.Left = 4.5625!
        Me.Line3.LineWeight = 1.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.0!
        Me.Line3.Width = 0.0!
        Me.Line3.X1 = 4.5625!
        Me.Line3.X2 = 4.5625!
        Me.Line3.Y1 = 0.0!
        Me.Line3.Y2 = 0.25!
        '
        'ChkCumple
        '
        Me.ChkCumple.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkCumple.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCumple.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkCumple.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCumple.Border.RightColor = System.Drawing.Color.Black
        Me.ChkCumple.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCumple.Border.TopColor = System.Drawing.Color.Black
        Me.ChkCumple.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkCumple.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkCumple.Height = 0.2083333!
        Me.ChkCumple.Left = 3.625!
        Me.ChkCumple.Name = "ChkCumple"
        Me.ChkCumple.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.ChkCumple.Text = ""
        Me.ChkCumple.Top = 0.0625!
        Me.ChkCumple.Width = 0.2083333!
        '
        'ChkNoCumple
        '
        Me.ChkNoCumple.Border.BottomColor = System.Drawing.Color.Black
        Me.ChkNoCumple.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNoCumple.Border.LeftColor = System.Drawing.Color.Black
        Me.ChkNoCumple.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNoCumple.Border.RightColor = System.Drawing.Color.Black
        Me.ChkNoCumple.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNoCumple.Border.TopColor = System.Drawing.Color.Black
        Me.ChkNoCumple.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ChkNoCumple.CheckAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.ChkNoCumple.Height = 0.2083333!
        Me.ChkNoCumple.Left = 4.1875!
        Me.ChkNoCumple.Name = "ChkNoCumple"
        Me.ChkNoCumple.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; "
        Me.ChkNoCumple.Text = ""
        Me.ChkNoCumple.Top = 0.0625!
        Me.ChkNoCumple.Width = 0.2083333!
        '
        'shpDetalles
        '
        Me.shpDetalles.Border.BottomColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.shpDetalles.Border.LeftColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.shpDetalles.Border.RightColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.shpDetalles.Border.TopColor = System.Drawing.Color.Black
        Me.shpDetalles.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.shpDetalles.Height = 0.25!
        Me.shpDetalles.Left = 0.0!
        Me.shpDetalles.LineColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.shpDetalles.Name = "shpDetalles"
        Me.shpDetalles.RoundingRadius = 9.999999!
        Me.shpDetalles.Top = 0.0!
        Me.shpDetalles.Width = 7.375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.shpEncabezado, Me.lblDocumento, Me.lblNumero, Me.lblCumple, Me.lblObserva, Me.Line6, Me.Line18, Me.lblNOCumple, Me.Line5, Me.Line9})
        Me.GroupHeader1.Height = 0.28125!
        Me.GroupHeader1.Name = "GroupHeader1"
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
        Me.shpEncabezado.Height = 0.3125!
        Me.shpEncabezado.Left = 0.0!
        Me.shpEncabezado.Name = "shpEncabezado"
        Me.shpEncabezado.RoundingRadius = 9.999999!
        Me.shpEncabezado.Top = 0.0!
        Me.shpEncabezado.Width = 7.375!
        '
        'lblDocumento
        '
        Me.lblDocumento.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDocumento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDocumento.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDocumento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDocumento.Border.RightColor = System.Drawing.Color.Black
        Me.lblDocumento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDocumento.Border.TopColor = System.Drawing.Color.Black
        Me.lblDocumento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDocumento.Height = 0.1875!
        Me.lblDocumento.HyperLink = Nothing
        Me.lblDocumento.Left = 0.4375!
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
    "align: middle; "
        Me.lblDocumento.Text = "Nombre del Documento"
        Me.lblDocumento.Top = 0.0625!
        Me.lblDocumento.Width = 3.0!
        '
        'lblNumero
        '
        Me.lblNumero.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNumero.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNumero.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Border.RightColor = System.Drawing.Color.Black
        Me.lblNumero.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Border.TopColor = System.Drawing.Color.Black
        Me.lblNumero.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNumero.Height = 0.1875!
        Me.lblNumero.HyperLink = Nothing
        Me.lblNumero.Left = 0.0625!
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
    "align: middle; "
        Me.lblNumero.Text = "No."
        Me.lblNumero.Top = 0.0625!
        Me.lblNumero.Width = 0.3125!
        '
        'lblCumple
        '
        Me.lblCumple.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCumple.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCumple.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCumple.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCumple.Border.RightColor = System.Drawing.Color.Black
        Me.lblCumple.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCumple.Border.TopColor = System.Drawing.Color.Black
        Me.lblCumple.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCumple.Height = 0.1875!
        Me.lblCumple.HyperLink = Nothing
        Me.lblCumple.Left = 3.4375!
        Me.lblCumple.Name = "lblCumple"
        Me.lblCumple.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
    "align: middle; "
        Me.lblCumple.Text = "SI"
        Me.lblCumple.Top = 0.0625!
        Me.lblCumple.Width = 0.5625!
        '
        'lblObserva
        '
        Me.lblObserva.Border.BottomColor = System.Drawing.Color.Black
        Me.lblObserva.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObserva.Border.LeftColor = System.Drawing.Color.Black
        Me.lblObserva.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObserva.Border.RightColor = System.Drawing.Color.Black
        Me.lblObserva.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObserva.Border.TopColor = System.Drawing.Color.Black
        Me.lblObserva.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObserva.Height = 0.1875!
        Me.lblObserva.HyperLink = Nothing
        Me.lblObserva.Left = 4.5625!
        Me.lblObserva.Name = "lblObserva"
        Me.lblObserva.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
    "align: middle; "
        Me.lblObserva.Text = "Observaciones"
        Me.lblObserva.Top = 0.0625!
        Me.lblObserva.Width = 2.75!
        '
        'Line6
        '
        Me.Line6.Border.BottomColor = System.Drawing.Color.Black
        Me.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.LeftColor = System.Drawing.Color.Black
        Me.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.RightColor = System.Drawing.Color.Black
        Me.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.TopColor = System.Drawing.Color.Black
        Me.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Height = 0.3125!
        Me.Line6.Left = 0.375!
        Me.Line6.LineWeight = 1.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 0.0!
        Me.Line6.Width = 0.0!
        Me.Line6.X1 = 0.375!
        Me.Line6.X2 = 0.375!
        Me.Line6.Y1 = 0.0!
        Me.Line6.Y2 = 0.3125!
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
        Me.Line18.Height = 0.3125!
        Me.Line18.Left = 3.4375!
        Me.Line18.LineWeight = 1.0!
        Me.Line18.Name = "Line18"
        Me.Line18.Top = 0.0!
        Me.Line18.Width = 0.0!
        Me.Line18.X1 = 3.4375!
        Me.Line18.X2 = 3.4375!
        Me.Line18.Y1 = 0.0!
        Me.Line18.Y2 = 0.3125!
        '
        'lblNOCumple
        '
        Me.lblNOCumple.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNOCumple.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNOCumple.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNOCumple.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNOCumple.Border.RightColor = System.Drawing.Color.Black
        Me.lblNOCumple.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNOCumple.Border.TopColor = System.Drawing.Color.Black
        Me.lblNOCumple.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNOCumple.Height = 0.1875!
        Me.lblNOCumple.HyperLink = Nothing
        Me.lblNOCumple.Left = 4.0!
        Me.lblNOCumple.Name = "lblNOCumple"
        Me.lblNOCumple.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9pt; vertical-" & _
    "align: middle; "
        Me.lblNOCumple.Text = "NO"
        Me.lblNOCumple.Top = 0.0625!
        Me.lblNOCumple.Width = 0.5625!
        '
        'Line5
        '
        Me.Line5.Border.BottomColor = System.Drawing.Color.Black
        Me.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.LeftColor = System.Drawing.Color.Black
        Me.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.RightColor = System.Drawing.Color.Black
        Me.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.TopColor = System.Drawing.Color.Black
        Me.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Height = 0.3125!
        Me.Line5.Left = 4.0!
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.0!
        Me.Line5.Width = 0.0!
        Me.Line5.X1 = 4.0!
        Me.Line5.X2 = 4.0!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.3125!
        '
        'Line9
        '
        Me.Line9.Border.BottomColor = System.Drawing.Color.Black
        Me.Line9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Border.LeftColor = System.Drawing.Color.Black
        Me.Line9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Border.RightColor = System.Drawing.Color.Black
        Me.Line9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Border.TopColor = System.Drawing.Color.Black
        Me.Line9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line9.Height = 0.3125!
        Me.Line9.Left = 4.5625!
        Me.Line9.LineWeight = 1.0!
        Me.Line9.Name = "Line9"
        Me.Line9.Top = 0.0!
        Me.Line9.Width = 0.0!
        Me.Line9.X1 = 4.5625!
        Me.Line9.X2 = 4.5625!
        Me.Line9.Y1 = 0.0!
        Me.Line9.Y2 = 0.3125!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'srptSclExpedienteSocia
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.40625!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
            "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
            "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.txtObserva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkCumple, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChkNoCumple, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNumero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCumple, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblObserva, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNOCumple, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtObserva As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDocumento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents shpEncabezado As DataDynamics.ActiveReports.Shape
    Friend WithEvents lblDocumento As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNumero As DataDynamics.ActiveReports.Label
    Friend WithEvents lblCumple As DataDynamics.ActiveReports.Label
    Friend WithEvents lblObserva As DataDynamics.ActiveReports.Label
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line18 As DataDynamics.ActiveReports.Line
    Friend WithEvents lblNOCumple As DataDynamics.ActiveReports.Label
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line9 As DataDynamics.ActiveReports.Line
    Friend WithEvents shpDetalles As DataDynamics.ActiveReports.Shape
    Friend WithEvents Line8 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents ChkCumple As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents ChkNoCumple As DataDynamics.ActiveReports.CheckBox
End Class
