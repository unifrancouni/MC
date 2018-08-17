<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class rptSclFichaVerificacion
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(rptSclFichaVerificacion))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.lblTitulo = New DataDynamics.ActiveReports.Label
        Me.SubReporte = New DataDynamics.ActiveReports.SubReport
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblUsuario = New DataDynamics.ActiveReports.Label
        Me.txtUsuario = New DataDynamics.ActiveReports.TextBox
        Me.txtHora = New DataDynamics.ActiveReports.TextBox
        Me.txtFecha = New DataDynamics.ActiveReports.TextBox
        Me.lblNombre = New DataDynamics.ActiveReports.Label
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
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
        Me.lblDatosGenerales = New DataDynamics.ActiveReports.Label
        Me.txtNombreApellidos = New DataDynamics.ActiveReports.TextBox
        Me.txtEdad = New DataDynamics.ActiveReports.TextBox
        Me.lblEdad = New DataDynamics.ActiveReports.Label
        Me.txtCedula = New DataDynamics.ActiveReports.TextBox
        Me.lblCedula = New DataDynamics.ActiveReports.Label
        Me.txtTelefono = New DataDynamics.ActiveReports.TextBox
        Me.txtDireccion = New DataDynamics.ActiveReports.TextBox
        Me.lblTelefono = New DataDynamics.ActiveReports.Label
        Me.lblDireccion = New DataDynamics.ActiveReports.Label
        Me.txtBarrio = New DataDynamics.ActiveReports.TextBox
        Me.lblBarrio = New DataDynamics.ActiveReports.Label
        Me.txtDistrito = New DataDynamics.ActiveReports.TextBox
        Me.lblDistrito = New DataDynamics.ActiveReports.Label
        Me.txtMunicipio = New DataDynamics.ActiveReports.TextBox
        Me.lblMunicipio = New DataDynamics.ActiveReports.Label
        Me.txtDepartamento = New DataDynamics.ActiveReports.TextBox
        Me.lblDepartamento = New DataDynamics.ActiveReports.Label
        Me.lblDatosNegocio = New DataDynamics.ActiveReports.Label
        Me.lblTieneNegocio = New DataDynamics.ActiveReports.Label
        Me.chkSiNegocioActual = New DataDynamics.ActiveReports.CheckBox
        Me.chkNoNegocioActual = New DataDynamics.ActiveReports.CheckBox
        Me.lblNoTieneNegocio = New DataDynamics.ActiveReports.Label
        Me.lblTipoNegocioActual = New DataDynamics.ActiveReports.Label
        Me.txtTipoNegocioActual = New DataDynamics.ActiveReports.TextBox
        Me.txtTipoNegocioPropuesto = New DataDynamics.ActiveReports.TextBox
        Me.lblTipoNegocioPropuesto = New DataDynamics.ActiveReports.Label
        Me.lblDireccionNegocio = New DataDynamics.ActiveReports.Label
        Me.txtDireccionNegocio = New DataDynamics.ActiveReports.TextBox
        Me.lblFechaApertura = New DataDynamics.ActiveReports.Label
        Me.txtFechaApertura = New DataDynamics.ActiveReports.TextBox
        Me.txtTipoPlazoVentas = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoVentas = New DataDynamics.ActiveReports.TextBox
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.chkOtroCreditoNo = New DataDynamics.ActiveReports.CheckBox
        Me.chkOtroCreditoSi = New DataDynamics.ActiveReports.CheckBox
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.txtInstitucionOtroCredito = New DataDynamics.ActiveReports.TextBox
        Me.Label7 = New DataDynamics.ActiveReports.Label
        Me.txtCuotaOtroCredito = New DataDynamics.ActiveReports.TextBox
        Me.txtMontoSolOtroCredito = New DataDynamics.ActiveReports.TextBox
        Me.Label8 = New DataDynamics.ActiveReports.Label
        Me.txtPeriodicidadOtroCredito = New DataDynamics.ActiveReports.TextBox
        Me.Label9 = New DataDynamics.ActiveReports.Label
        Me.Label10 = New DataDynamics.ActiveReports.Label
        Me.txtPlazoOtroCredito = New DataDynamics.ActiveReports.TextBox
        Me.Label11 = New DataDynamics.ActiveReports.Label
        Me.txtTipoPlazoOtroCredito = New DataDynamics.ActiveReports.TextBox
        Me.Label12 = New DataDynamics.ActiveReports.Label
        Me.txtSaldoOtroCredito = New DataDynamics.ActiveReports.TextBox
        Me.Label13 = New DataDynamics.ActiveReports.Label
        Me.lblInteresPrestamo = New DataDynamics.ActiveReports.Label
        Me.txtMontoPrestamo = New DataDynamics.ActiveReports.TextBox
        Me.lblMontoPrestamo = New DataDynamics.ActiveReports.Label
        Me.txtTipoPlazoPrestamo = New DataDynamics.ActiveReports.TextBox
        Me.txtPlazoPrestamo = New DataDynamics.ActiveReports.TextBox
        Me.lblPlazoPrestamo = New DataDynamics.ActiveReports.Label
        Me.txtSclGrupoSolidarioID = New DataDynamics.ActiveReports.TextBox
        Me.txtFechaVerificacion = New DataDynamics.ActiveReports.TextBox
        Me.txtCodigoFicha = New DataDynamics.ActiveReports.TextBox
        Me.lblFechaInscripcion = New DataDynamics.ActiveReports.Label
        Me.lblCodigoFicha = New DataDynamics.ActiveReports.Label
        Me.lblObservaciones = New DataDynamics.ActiveReports.Label
        Me.txtObservaciones = New DataDynamics.ActiveReports.TextBox
        Me.txtNombreRepresentante = New DataDynamics.ActiveReports.TextBox
        Me.lblNombreRepresentante = New DataDynamics.ActiveReports.Label
        Me.lblDispuestaGS = New DataDynamics.ActiveReports.Label
        Me.chkDispuestaSi = New DataDynamics.ActiveReports.CheckBox
        Me.chkDispuestaNo = New DataDynamics.ActiveReports.CheckBox
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.txtGrupoSolidario = New DataDynamics.ActiveReports.TextBox
        Me.lblGrupoSolidario = New DataDynamics.ActiveReports.Label
        Me.txtConoceSocias = New DataDynamics.ActiveReports.TextBox
        Me.Label14 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDatosGenerales, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreApellidos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblEdad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDatosNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTieneNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkSiNegocioActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkNoNegocioActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNoTieneNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoNegocioActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoNegocioActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoNegocioPropuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblTipoNegocioPropuesto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDireccionNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDireccionNegocio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaApertura, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoPlazoVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoVentas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOtroCreditoNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOtroCreditoSi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInstitucionOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCuotaOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoSolOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPeriodicidadOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazoOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoPlazoOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoOtroCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblInteresPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblMontoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoPlazoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlazoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPlazoPrestamo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSclGrupoSolidarioID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVerificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCodigoFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFechaInscripcion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblCodigoFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNombreRepresentante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNombreRepresentante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblDispuestaGS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDispuestaSi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkDispuestaNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrupoSolidario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblGrupoSolidario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConoceSocias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblTitulo, Me.SubReporte, Me.Label1})
        Me.PageHeader1.Height = 0.9791667!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'lblTitulo
        '
        Me.lblTitulo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Border.RightColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Border.TopColor = System.Drawing.Color.Black
        Me.lblTitulo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTitulo.Height = 0.1875!
        Me.lblTitulo.HyperLink = Nothing
        Me.lblTitulo.Left = 0.0!
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblTitulo.Text = "Hoja de Verificación de Ficha"
        Me.lblTitulo.Top = 0.75!
        Me.lblTitulo.Width = 7.4375!
        '
        'SubReporte
        '
        Me.SubReporte.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReporte.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReporte.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.Border.RightColor = System.Drawing.Color.Black
        Me.SubReporte.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.Border.TopColor = System.Drawing.Color.Black
        Me.SubReporte.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReporte.CloseBorder = False
        Me.SubReporte.Height = 0.7!
        Me.SubReporte.Left = 0.0!
        Me.SubReporte.Name = "SubReporte"
        Me.SubReporte.Report = Nothing
        Me.SubReporte.ReportName = "SubReport1"
        Me.SubReporte.Top = 0.0625!
        Me.SubReporte.Width = 7.4375!
        '
        'Label1
        '
        Me.Label1.Border.BottomColor = System.Drawing.Color.Black
        Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.LeftColor = System.Drawing.Color.Black
        Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.RightColor = System.Drawing.Color.Black
        Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Border.TopColor = System.Drawing.Color.Black
        Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label1.Height = 0.5!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 5.625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-weight: bold; font-size: 21.75pt; vertical-align: middle; "
        Me.Label1.Text = "CS2"
        Me.Label1.Top = 0.1875!
        Me.Label1.Width = 0.8125!
        '
        'lblUsuario
        '
        Me.lblUsuario.Border.BottomColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Border.LeftColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Border.RightColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Border.TopColor = System.Drawing.Color.Black
        Me.lblUsuario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblUsuario.Height = 0.2083333!
        Me.lblUsuario.HyperLink = Nothing
        Me.lblUsuario.Left = 5.75!
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.Top = 0.0!
        Me.lblUsuario.Width = 0.5416667!
        '
        'txtUsuario
        '
        Me.txtUsuario.Border.BottomColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Border.LeftColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Border.RightColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Border.TopColor = System.Drawing.Color.Black
        Me.txtUsuario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtUsuario.Height = 0.2083333!
        Me.txtUsuario.Left = 6.3125!
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtUsuario.Text = Nothing
        Me.txtUsuario.Top = 0.0!
        Me.txtUsuario.Width = 1.041667!
        '
        'txtHora
        '
        Me.txtHora.Border.BottomColor = System.Drawing.Color.Black
        Me.txtHora.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Border.LeftColor = System.Drawing.Color.Black
        Me.txtHora.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Border.RightColor = System.Drawing.Color.Black
        Me.txtHora.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Border.TopColor = System.Drawing.Color.Black
        Me.txtHora.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtHora.Height = 0.1875!
        Me.txtHora.Left = 6.5!
        Me.txtHora.Name = "txtHora"
        Me.txtHora.OutputFormat = resources.GetString("txtHora.OutputFormat")
        Me.txtHora.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtHora.Text = Nothing
        Me.txtHora.Top = 0.1875!
        Me.txtHora.Width = 0.9375!
        '
        'txtFecha
        '
        Me.txtFecha.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFecha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFecha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Border.RightColor = System.Drawing.Color.Black
        Me.txtFecha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Border.TopColor = System.Drawing.Color.Black
        Me.txtFecha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFecha.Height = 0.1875!
        Me.txtFecha.Left = 5.75!
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.OutputFormat = resources.GetString("txtFecha.OutputFormat")
        Me.txtFecha.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFecha.Text = Nothing
        Me.txtFecha.Top = 0.1875!
        Me.txtFecha.Width = 0.6875!
        '
        'lblNombre
        '
        Me.lblNombre.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombre.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombre.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombre.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombre.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombre.Height = 0.1875!
        Me.lblNombre.HyperLink = Nothing
        Me.lblNombre.Left = 0.0625!
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblNombre.Text = "Nombre y Apellidos:"
        Me.lblNombre.Top = 0.625!
        Me.lblNombre.Width = 1.1875!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Height = 0.0!
        Me.Detail1.KeepTogether = True
        Me.Detail1.Name = "Detail1"
        '
        'PageFooter1
        '
        Me.PageFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtparametro1, Me.txtparametro2, Me.ReportInfo1, Me.Line5, Me.TextBox1, Me.txtUsuario, Me.lblUsuario, Me.txtFecha, Me.txtHora})
        Me.PageFooter1.Height = 0.4166667!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'txtparametro1
        '
        Me.txtparametro1.Border.BottomColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Border.LeftColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Border.RightColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Border.TopColor = System.Drawing.Color.Black
        Me.txtparametro1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro1.Height = 0.1875!
        Me.txtparametro1.Left = 0.75!
        Me.txtparametro1.Name = "txtparametro1"
        Me.txtparametro1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro1.Text = Nothing
        Me.txtparametro1.Top = 0.0!
        Me.txtparametro1.Width = 2.75!
        '
        'txtparametro2
        '
        Me.txtparametro2.Border.BottomColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Border.LeftColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Border.RightColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Border.TopColor = System.Drawing.Color.Black
        Me.txtparametro2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtparametro2.Height = 0.1875!
        Me.txtparametro2.Left = 0.0!
        Me.txtparametro2.Name = "txtparametro2"
        Me.txtparametro2.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtparametro2.Text = Nothing
        Me.txtparametro2.Top = 0.1875!
        Me.txtparametro2.Visible = False
        Me.txtparametro2.Width = 3.5!
        '
        'ReportInfo1
        '
        Me.ReportInfo1.Border.BottomColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.LeftColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.RightColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.Border.TopColor = System.Drawing.Color.Black
        Me.ReportInfo1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReportInfo1.FormatString = "{PageNumber} de {PageCount}"
        Me.ReportInfo1.Height = 0.3125!
        Me.ReportInfo1.Left = 3.5!
        Me.ReportInfo1.Name = "ReportInfo1"
        Me.ReportInfo1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.ReportInfo1.Top = 0.0!
        Me.ReportInfo1.Width = 1.0!
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
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.0!
        Me.Line5.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line5.LineWeight = 1.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 0.0!
        Me.Line5.Width = 7.5!
        Me.Line5.X1 = 0.0!
        Me.Line5.X2 = 7.5!
        Me.Line5.Y1 = 0.0!
        Me.Line5.Y2 = 0.0!
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.0!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.TextBox1.Text = "Parámetros:"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Visible = False
        Me.TextBox1.Width = 0.75!
        '
        'EncabezadoReporte
        '
        Me.EncabezadoReporte.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2})
        Me.EncabezadoReporte.Height = 0.02083333!
        Me.EncabezadoReporte.Name = "EncabezadoReporte"
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
        Me.Line2.Height = 0.0!
        Me.Line2.Left = 0.0625!
        Me.Line2.LineColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Line2.LineWeight = 1.0!
        Me.Line2.Name = "Line2"
        Me.Line2.Top = 2.166667!
        Me.Line2.Width = 7.5!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 7.5625!
        Me.Line2.Y1 = 2.166667!
        Me.Line2.Y2 = 2.166667!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.lblNombre, Me.lblDatosGenerales, Me.txtNombreApellidos, Me.txtEdad, Me.lblEdad, Me.txtCedula, Me.lblCedula, Me.txtTelefono, Me.txtDireccion, Me.lblTelefono, Me.lblDireccion, Me.txtBarrio, Me.lblBarrio, Me.txtDistrito, Me.lblDistrito, Me.txtMunicipio, Me.lblMunicipio, Me.txtDepartamento, Me.lblDepartamento, Me.lblDatosNegocio, Me.lblTieneNegocio, Me.chkSiNegocioActual, Me.chkNoNegocioActual, Me.lblNoTieneNegocio, Me.lblTipoNegocioActual, Me.txtTipoNegocioActual, Me.txtTipoNegocioPropuesto, Me.lblTipoNegocioPropuesto, Me.lblDireccionNegocio, Me.txtDireccionNegocio, Me.lblFechaApertura, Me.txtFechaApertura, Me.txtTipoPlazoVentas, Me.txtMontoVentas, Me.Label2, Me.Label3, Me.chkOtroCreditoNo, Me.chkOtroCreditoSi, Me.Label4, Me.Label5, Me.Label6, Me.txtInstitucionOtroCredito, Me.Label7, Me.txtCuotaOtroCredito, Me.txtMontoSolOtroCredito, Me.Label8, Me.txtPeriodicidadOtroCredito, Me.Label9, Me.Label10, Me.txtPlazoOtroCredito, Me.Label11, Me.txtTipoPlazoOtroCredito, Me.Label12, Me.txtSaldoOtroCredito, Me.Label13, Me.lblInteresPrestamo, Me.txtMontoPrestamo, Me.lblMontoPrestamo, Me.txtTipoPlazoPrestamo, Me.txtPlazoPrestamo, Me.lblPlazoPrestamo, Me.txtSclGrupoSolidarioID, Me.txtFechaVerificacion, Me.txtCodigoFicha, Me.lblFechaInscripcion, Me.lblCodigoFicha, Me.lblObservaciones, Me.txtObservaciones, Me.txtNombreRepresentante, Me.lblNombreRepresentante, Me.lblDispuestaGS, Me.chkDispuestaSi, Me.chkDispuestaNo, Me.Label21, Me.txtGrupoSolidario, Me.lblGrupoSolidario, Me.txtConoceSocias, Me.Label14})
        Me.GroupHeader1.DataField = "nStbMunicipioID"
        Me.GroupHeader1.Height = 8.71875!
        Me.GroupHeader1.Name = "GroupHeader1"
        Me.GroupHeader1.NewPage = DataDynamics.ActiveReports.NewPage.After
        '
        'lblDatosGenerales
        '
        Me.lblDatosGenerales.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDatosGenerales.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosGenerales.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDatosGenerales.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosGenerales.Border.RightColor = System.Drawing.Color.Black
        Me.lblDatosGenerales.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosGenerales.Border.TopColor = System.Drawing.Color.Black
        Me.lblDatosGenerales.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosGenerales.Height = 0.1875!
        Me.lblDatosGenerales.HyperLink = Nothing
        Me.lblDatosGenerales.Left = 0.0625!
        Me.lblDatosGenerales.MultiLine = False
        Me.lblDatosGenerales.Name = "lblDatosGenerales"
        Me.lblDatosGenerales.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.lblDatosGenerales.Text = "Datos Generales"
        Me.lblDatosGenerales.Top = 0.0625!
        Me.lblDatosGenerales.Width = 1.4375!
        '
        'txtNombreApellidos
        '
        Me.txtNombreApellidos.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreApellidos.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreApellidos.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreApellidos.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreApellidos.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreApellidos.Height = 0.1875!
        Me.txtNombreApellidos.Left = 1.3125!
        Me.txtNombreApellidos.Name = "txtNombreApellidos"
        Me.txtNombreApellidos.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombreApellidos.Text = Nothing
        Me.txtNombreApellidos.Top = 0.625!
        Me.txtNombreApellidos.Width = 6.0625!
        '
        'txtEdad
        '
        Me.txtEdad.Border.BottomColor = System.Drawing.Color.Black
        Me.txtEdad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtEdad.Border.LeftColor = System.Drawing.Color.Black
        Me.txtEdad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEdad.Border.RightColor = System.Drawing.Color.Black
        Me.txtEdad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEdad.Border.TopColor = System.Drawing.Color.Black
        Me.txtEdad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtEdad.Height = 0.1875!
        Me.txtEdad.Left = 0.5104167!
        Me.txtEdad.Name = "txtEdad"
        Me.txtEdad.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtEdad.Text = Nothing
        Me.txtEdad.Top = 0.8958333!
        Me.txtEdad.Width = 0.5!
        '
        'lblEdad
        '
        Me.lblEdad.Border.BottomColor = System.Drawing.Color.Black
        Me.lblEdad.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEdad.Border.LeftColor = System.Drawing.Color.Black
        Me.lblEdad.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEdad.Border.RightColor = System.Drawing.Color.Black
        Me.lblEdad.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEdad.Border.TopColor = System.Drawing.Color.Black
        Me.lblEdad.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblEdad.Height = 0.1875!
        Me.lblEdad.HyperLink = Nothing
        Me.lblEdad.Left = 0.0625!
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblEdad.Text = "Edad:"
        Me.lblEdad.Top = 0.8958333!
        Me.lblEdad.Width = 0.375!
        '
        'txtCedula
        '
        Me.txtCedula.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCedula.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCedula.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCedula.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Border.RightColor = System.Drawing.Color.Black
        Me.txtCedula.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Border.TopColor = System.Drawing.Color.Black
        Me.txtCedula.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCedula.Height = 0.1875!
        Me.txtCedula.Left = 2.947917!
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCedula.Text = Nothing
        Me.txtCedula.Top = 0.8958333!
        Me.txtCedula.Width = 2.1875!
        '
        'lblCedula
        '
        Me.lblCedula.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCedula.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCedula.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Border.RightColor = System.Drawing.Color.Black
        Me.lblCedula.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Border.TopColor = System.Drawing.Color.Black
        Me.lblCedula.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCedula.Height = 0.25!
        Me.lblCedula.HyperLink = Nothing
        Me.lblCedula.Left = 2.197917!
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCedula.Text = "Cédula No."
        Me.lblCedula.Top = 0.875!
        Me.lblCedula.Width = 0.6875!
        '
        'txtTelefono
        '
        Me.txtTelefono.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTelefono.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Border.RightColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Border.TopColor = System.Drawing.Color.Black
        Me.txtTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTelefono.Height = 0.1875!
        Me.txtTelefono.Left = 6.0!
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTelefono.Text = Nothing
        Me.txtTelefono.Top = 0.8958333!
        Me.txtTelefono.Width = 1.375!
        '
        'txtDireccion
        '
        Me.txtDireccion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDireccion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccion.Border.RightColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccion.Border.TopColor = System.Drawing.Color.Black
        Me.txtDireccion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccion.Height = 0.1875!
        Me.txtDireccion.Left = 0.75!
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDireccion.Text = Nothing
        Me.txtDireccion.Top = 1.1875!
        Me.txtDireccion.Width = 6.625!
        '
        'lblTelefono
        '
        Me.lblTelefono.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Border.RightColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Border.TopColor = System.Drawing.Color.Black
        Me.lblTelefono.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTelefono.Height = 0.1875!
        Me.lblTelefono.HyperLink = Nothing
        Me.lblTelefono.Left = 5.3125!
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblTelefono.Text = "Teléfono:"
        Me.lblTelefono.Top = 0.8958333!
        Me.lblTelefono.Width = 0.625!
        '
        'lblDireccion
        '
        Me.lblDireccion.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Border.RightColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Border.TopColor = System.Drawing.Color.Black
        Me.lblDireccion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccion.Height = 0.1875!
        Me.lblDireccion.HyperLink = Nothing
        Me.lblDireccion.Left = 0.0625!
        Me.lblDireccion.Name = "lblDireccion"
        Me.lblDireccion.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDireccion.Text = "Dirección:"
        Me.lblDireccion.Top = 1.1875!
        Me.lblDireccion.Width = 0.625!
        '
        'txtBarrio
        '
        Me.txtBarrio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtBarrio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Border.RightColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Border.TopColor = System.Drawing.Color.Black
        Me.txtBarrio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarrio.Height = 0.1875!
        Me.txtBarrio.Left = 0.63!
        Me.txtBarrio.Name = "txtBarrio"
        Me.txtBarrio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtBarrio.Text = Nothing
        Me.txtBarrio.Top = 1.44!
        Me.txtBarrio.Width = 1.4375!
        '
        'lblBarrio
        '
        Me.lblBarrio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.Border.RightColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.Border.TopColor = System.Drawing.Color.Black
        Me.lblBarrio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblBarrio.Height = 0.1875!
        Me.lblBarrio.HyperLink = Nothing
        Me.lblBarrio.Left = 0.0625!
        Me.lblBarrio.Name = "lblBarrio"
        Me.lblBarrio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblBarrio.Text = "Barrio:"
        Me.lblBarrio.Top = 1.427083!
        Me.lblBarrio.Width = 0.4375!
        '
        'txtDistrito
        '
        Me.txtDistrito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDistrito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Border.RightColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Border.TopColor = System.Drawing.Color.Black
        Me.txtDistrito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDistrito.Height = 0.1875!
        Me.txtDistrito.Left = 2.6875!
        Me.txtDistrito.Name = "txtDistrito"
        Me.txtDistrito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDistrito.Text = Nothing
        Me.txtDistrito.Top = 1.4375!
        Me.txtDistrito.Width = 0.6875!
        '
        'lblDistrito
        '
        Me.lblDistrito.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Border.RightColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Border.TopColor = System.Drawing.Color.Black
        Me.lblDistrito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDistrito.Height = 0.1875!
        Me.lblDistrito.HyperLink = Nothing
        Me.lblDistrito.Left = 2.1875!
        Me.lblDistrito.Name = "lblDistrito"
        Me.lblDistrito.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDistrito.Text = "Distrito:"
        Me.lblDistrito.Top = 1.4375!
        Me.lblDistrito.Width = 0.5!
        '
        'txtMunicipio
        '
        Me.txtMunicipio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMunicipio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.RightColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Border.TopColor = System.Drawing.Color.Black
        Me.txtMunicipio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMunicipio.Height = 0.1875!
        Me.txtMunicipio.Left = 4.239583!
        Me.txtMunicipio.Name = "txtMunicipio"
        Me.txtMunicipio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMunicipio.Text = Nothing
        Me.txtMunicipio.Top = 1.427083!
        Me.txtMunicipio.Width = 1.375!
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
        Me.lblMunicipio.Left = 3.5625!
        Me.lblMunicipio.Name = "lblMunicipio"
        Me.lblMunicipio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblMunicipio.Text = "Municipio:"
        Me.lblMunicipio.Top = 1.4375!
        Me.lblMunicipio.Width = 0.625!
        '
        'txtDepartamento
        '
        Me.txtDepartamento.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDepartamento.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.RightColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Border.TopColor = System.Drawing.Color.Black
        Me.txtDepartamento.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDepartamento.Height = 0.1875!
        Me.txtDepartamento.Left = 6.1875!
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDepartamento.Text = Nothing
        Me.txtDepartamento.Top = 1.4375!
        Me.txtDepartamento.Width = 1.1875!
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
        Me.lblDepartamento.Left = 5.75!
        Me.lblDepartamento.Name = "lblDepartamento"
        Me.lblDepartamento.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDepartamento.Text = "Depto:"
        Me.lblDepartamento.Top = 1.4375!
        Me.lblDepartamento.Width = 0.4375!
        '
        'lblDatosNegocio
        '
        Me.lblDatosNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDatosNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDatosNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.lblDatosNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.lblDatosNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDatosNegocio.Height = 0.1875!
        Me.lblDatosNegocio.HyperLink = Nothing
        Me.lblDatosNegocio.Left = 0.0625!
        Me.lblDatosNegocio.MultiLine = False
        Me.lblDatosNegocio.Name = "lblDatosNegocio"
        Me.lblDatosNegocio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.lblDatosNegocio.Text = "Datos del Negocio"
        Me.lblDatosNegocio.Top = 1.96875!
        Me.lblDatosNegocio.Width = 1.5625!
        '
        'lblTieneNegocio
        '
        Me.lblTieneNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTieneNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTieneNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTieneNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTieneNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.lblTieneNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTieneNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.lblTieneNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTieneNegocio.Height = 0.19!
        Me.lblTieneNegocio.HyperLink = Nothing
        Me.lblTieneNegocio.Left = 0.0625!
        Me.lblTieneNegocio.Name = "lblTieneNegocio"
        Me.lblTieneNegocio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblTieneNegocio.Text = "Tiene algún negocio actualmente: Si "
        Me.lblTieneNegocio.Top = 2.260417!
        Me.lblTieneNegocio.Width = 2.06!
        '
        'chkSiNegocioActual
        '
        Me.chkSiNegocioActual.Border.BottomColor = System.Drawing.Color.Black
        Me.chkSiNegocioActual.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkSiNegocioActual.Border.LeftColor = System.Drawing.Color.Black
        Me.chkSiNegocioActual.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkSiNegocioActual.Border.RightColor = System.Drawing.Color.Black
        Me.chkSiNegocioActual.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkSiNegocioActual.Border.TopColor = System.Drawing.Color.Black
        Me.chkSiNegocioActual.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkSiNegocioActual.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkSiNegocioActual.Height = 0.1875!
        Me.chkSiNegocioActual.Left = 2.104167!
        Me.chkSiNegocioActual.Name = "chkSiNegocioActual"
        Me.chkSiNegocioActual.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkSiNegocioActual.Text = ""
        Me.chkSiNegocioActual.Top = 2.28125!
        Me.chkSiNegocioActual.Width = 0.25!
        '
        'chkNoNegocioActual
        '
        Me.chkNoNegocioActual.Border.BottomColor = System.Drawing.Color.Black
        Me.chkNoNegocioActual.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkNoNegocioActual.Border.LeftColor = System.Drawing.Color.Black
        Me.chkNoNegocioActual.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkNoNegocioActual.Border.RightColor = System.Drawing.Color.Black
        Me.chkNoNegocioActual.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkNoNegocioActual.Border.TopColor = System.Drawing.Color.Black
        Me.chkNoNegocioActual.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkNoNegocioActual.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkNoNegocioActual.Height = 0.1875!
        Me.chkNoNegocioActual.Left = 2.645833!
        Me.chkNoNegocioActual.Name = "chkNoNegocioActual"
        Me.chkNoNegocioActual.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkNoNegocioActual.Text = ""
        Me.chkNoNegocioActual.Top = 2.28125!
        Me.chkNoNegocioActual.Width = 0.25!
        '
        'lblNoTieneNegocio
        '
        Me.lblNoTieneNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNoTieneNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoTieneNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNoTieneNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoTieneNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.lblNoTieneNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoTieneNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.lblNoTieneNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNoTieneNegocio.Height = 0.1875!
        Me.lblNoTieneNegocio.HyperLink = Nothing
        Me.lblNoTieneNegocio.Left = 2.46875!
        Me.lblNoTieneNegocio.Name = "lblNoTieneNegocio"
        Me.lblNoTieneNegocio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblNoTieneNegocio.Text = "No"
        Me.lblNoTieneNegocio.Top = 2.28125!
        Me.lblNoTieneNegocio.Width = 0.1875!
        '
        'lblTipoNegocioActual
        '
        Me.lblTipoNegocioActual.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTipoNegocioActual.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioActual.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTipoNegocioActual.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioActual.Border.RightColor = System.Drawing.Color.Black
        Me.lblTipoNegocioActual.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioActual.Border.TopColor = System.Drawing.Color.Black
        Me.lblTipoNegocioActual.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioActual.Height = 0.19!
        Me.lblTipoNegocioActual.HyperLink = Nothing
        Me.lblTipoNegocioActual.Left = 0.0625!
        Me.lblTipoNegocioActual.Name = "lblTipoNegocioActual"
        Me.lblTipoNegocioActual.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblTipoNegocioActual.Text = "Si es ""Si"", qué tipo de negocio tiene:"
        Me.lblTipoNegocioActual.Top = 2.510417!
        Me.lblTipoNegocioActual.Width = 2.06!
        '
        'txtTipoNegocioActual
        '
        Me.txtTipoNegocioActual.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoNegocioActual.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocioActual.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoNegocioActual.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocioActual.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoNegocioActual.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocioActual.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoNegocioActual.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocioActual.Height = 0.19!
        Me.txtTipoNegocioActual.Left = 2.1875!
        Me.txtTipoNegocioActual.Name = "txtTipoNegocioActual"
        Me.txtTipoNegocioActual.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTipoNegocioActual.Text = Nothing
        Me.txtTipoNegocioActual.Top = 2.510417!
        Me.txtTipoNegocioActual.Width = 5.19!
        '
        'txtTipoNegocioPropuesto
        '
        Me.txtTipoNegocioPropuesto.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoNegocioPropuesto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoNegocioPropuesto.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoNegocioPropuesto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocioPropuesto.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoNegocioPropuesto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocioPropuesto.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoNegocioPropuesto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoNegocioPropuesto.Height = 0.19!
        Me.txtTipoNegocioPropuesto.Left = 2.875!
        Me.txtTipoNegocioPropuesto.Name = "txtTipoNegocioPropuesto"
        Me.txtTipoNegocioPropuesto.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTipoNegocioPropuesto.Text = " "
        Me.txtTipoNegocioPropuesto.Top = 3.322917!
        Me.txtTipoNegocioPropuesto.Width = 4.5!
        '
        'lblTipoNegocioPropuesto
        '
        Me.lblTipoNegocioPropuesto.Border.BottomColor = System.Drawing.Color.Black
        Me.lblTipoNegocioPropuesto.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioPropuesto.Border.LeftColor = System.Drawing.Color.Black
        Me.lblTipoNegocioPropuesto.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioPropuesto.Border.RightColor = System.Drawing.Color.Black
        Me.lblTipoNegocioPropuesto.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioPropuesto.Border.TopColor = System.Drawing.Color.Black
        Me.lblTipoNegocioPropuesto.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblTipoNegocioPropuesto.Height = 0.19!
        Me.lblTipoNegocioPropuesto.HyperLink = Nothing
        Me.lblTipoNegocioPropuesto.Left = 0.0625!
        Me.lblTipoNegocioPropuesto.Name = "lblTipoNegocioPropuesto"
        Me.lblTipoNegocioPropuesto.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblTipoNegocioPropuesto.Text = "Si es ""No"", qué tipo de negocio quiere organizar:"
        Me.lblTipoNegocioPropuesto.Top = 3.322917!
        Me.lblTipoNegocioPropuesto.Width = 2.75!
        '
        'lblDireccionNegocio
        '
        Me.lblDireccionNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDireccionNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDireccionNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.lblDireccionNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.lblDireccionNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDireccionNegocio.Height = 0.19!
        Me.lblDireccionNegocio.HyperLink = Nothing
        Me.lblDireccionNegocio.Left = 0.0625!
        Me.lblDireccionNegocio.Name = "lblDireccionNegocio"
        Me.lblDireccionNegocio.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDireccionNegocio.Text = "Dirección del Negocio:"
        Me.lblDireccionNegocio.Top = 2.78125!
        Me.lblDireccionNegocio.Width = 1.31!
        '
        'txtDireccionNegocio
        '
        Me.txtDireccionNegocio.Border.BottomColor = System.Drawing.Color.Black
        Me.txtDireccionNegocio.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtDireccionNegocio.Border.LeftColor = System.Drawing.Color.Black
        Me.txtDireccionNegocio.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccionNegocio.Border.RightColor = System.Drawing.Color.Black
        Me.txtDireccionNegocio.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccionNegocio.Border.TopColor = System.Drawing.Color.Black
        Me.txtDireccionNegocio.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtDireccionNegocio.Height = 0.19!
        Me.txtDireccionNegocio.Left = 1.4375!
        Me.txtDireccionNegocio.Name = "txtDireccionNegocio"
        Me.txtDireccionNegocio.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtDireccionNegocio.Text = Nothing
        Me.txtDireccionNegocio.Top = 2.78125!
        Me.txtDireccionNegocio.Width = 3.56!
        '
        'lblFechaApertura
        '
        Me.lblFechaApertura.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaApertura.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaApertura.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaApertura.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaApertura.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaApertura.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaApertura.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaApertura.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaApertura.Height = 0.1875!
        Me.lblFechaApertura.HyperLink = Nothing
        Me.lblFechaApertura.Left = 5.0625!
        Me.lblFechaApertura.Name = "lblFechaApertura"
        Me.lblFechaApertura.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblFechaApertura.Text = "Fecha de Apertura:"
        Me.lblFechaApertura.Top = 2.791667!
        Me.lblFechaApertura.Width = 1.125!
        '
        'txtFechaApertura
        '
        Me.txtFechaApertura.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaApertura.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaApertura.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaApertura.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaApertura.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaApertura.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaApertura.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaApertura.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaApertura.Height = 0.1875!
        Me.txtFechaApertura.Left = 6.25!
        Me.txtFechaApertura.Name = "txtFechaApertura"
        Me.txtFechaApertura.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFechaApertura.Text = Nothing
        Me.txtFechaApertura.Top = 2.791667!
        Me.txtFechaApertura.Width = 1.125!
        '
        'txtTipoPlazoVentas
        '
        Me.txtTipoPlazoVentas.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoPlazoVentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoPlazoVentas.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoPlazoVentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoVentas.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoPlazoVentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoVentas.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoPlazoVentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoVentas.Height = 0.19!
        Me.txtTipoPlazoVentas.Left = 6.0625!
        Me.txtTipoPlazoVentas.Name = "txtTipoPlazoVentas"
        Me.txtTipoPlazoVentas.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTipoPlazoVentas.Text = Nothing
        Me.txtTipoPlazoVentas.Top = 3.052083!
        Me.txtTipoPlazoVentas.Width = 1.31!
        '
        'txtMontoVentas
        '
        Me.txtMontoVentas.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoVentas.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoVentas.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoVentas.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoVentas.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoVentas.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoVentas.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoVentas.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoVentas.Height = 0.1875!
        Me.txtMontoVentas.Left = 2.072917!
        Me.txtMontoVentas.Name = "txtMontoVentas"
        Me.txtMontoVentas.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoVentas.Text = Nothing
        Me.txtMontoVentas.Top = 3.0625!
        Me.txtMontoVentas.Width = 1.375!
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
        Me.Label2.Height = 0.19!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 3.625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label2.Text = "Tipo de Plazo del Promedio de las Ventas:"
        Me.Label2.Top = 3.052083!
        Me.Label2.Width = 2.44!
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0625!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label3.Text = "Monto Promedio de las Ventas: C$"
        Me.Label3.Top = 3.0625!
        Me.Label3.Width = 1.9375!
        '
        'chkOtroCreditoNo
        '
        Me.chkOtroCreditoNo.Border.BottomColor = System.Drawing.Color.Black
        Me.chkOtroCreditoNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoNo.Border.LeftColor = System.Drawing.Color.Black
        Me.chkOtroCreditoNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoNo.Border.RightColor = System.Drawing.Color.Black
        Me.chkOtroCreditoNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoNo.Border.TopColor = System.Drawing.Color.Black
        Me.chkOtroCreditoNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoNo.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOtroCreditoNo.Height = 0.1875!
        Me.chkOtroCreditoNo.Left = 5.489583!
        Me.chkOtroCreditoNo.Name = "chkOtroCreditoNo"
        Me.chkOtroCreditoNo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkOtroCreditoNo.Text = ""
        Me.chkOtroCreditoNo.Top = 4.135417!
        Me.chkOtroCreditoNo.Width = 0.25!
        '
        'chkOtroCreditoSi
        '
        Me.chkOtroCreditoSi.Border.BottomColor = System.Drawing.Color.Black
        Me.chkOtroCreditoSi.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoSi.Border.LeftColor = System.Drawing.Color.Black
        Me.chkOtroCreditoSi.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoSi.Border.RightColor = System.Drawing.Color.Black
        Me.chkOtroCreditoSi.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoSi.Border.TopColor = System.Drawing.Color.Black
        Me.chkOtroCreditoSi.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkOtroCreditoSi.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkOtroCreditoSi.Height = 0.1875!
        Me.chkOtroCreditoSi.Left = 4.927083!
        Me.chkOtroCreditoSi.Name = "chkOtroCreditoSi"
        Me.chkOtroCreditoSi.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkOtroCreditoSi.Text = ""
        Me.chkOtroCreditoSi.Top = 4.135417!
        Me.chkOtroCreditoSi.Width = 0.25!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 5.302083!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label4.Text = "No"
        Me.Label4.Top = 4.135417!
        Me.Label4.Width = 0.1875!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.19!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 0.0625!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label5.Text = "Ha solicitado crédito en el transcurso de este año a alguna Institución o persona" & _
            ": Si"
        Me.Label5.Top = 4.135417!
        Me.Label5.Width = 4.81!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Height = 0.25!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 0.0625!
        Me.Label6.MultiLine = False
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.Label6.Text = "Datos Otro Crédito"
        Me.Label6.Top = 3.78125!
        Me.Label6.Width = 1.6875!
        '
        'txtInstitucionOtroCredito
        '
        Me.txtInstitucionOtroCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtInstitucionOtroCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtInstitucionOtroCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtInstitucionOtroCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInstitucionOtroCredito.Border.RightColor = System.Drawing.Color.Black
        Me.txtInstitucionOtroCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInstitucionOtroCredito.Border.TopColor = System.Drawing.Color.Black
        Me.txtInstitucionOtroCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtInstitucionOtroCredito.Height = 0.19!
        Me.txtInstitucionOtroCredito.Left = 3.3125!
        Me.txtInstitucionOtroCredito.Name = "txtInstitucionOtroCredito"
        Me.txtInstitucionOtroCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtInstitucionOtroCredito.Text = Nothing
        Me.txtInstitucionOtroCredito.Top = 4.40625!
        Me.txtInstitucionOtroCredito.Width = 4.06!
        '
        'Label7
        '
        Me.Label7.Border.BottomColor = System.Drawing.Color.Black
        Me.Label7.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.LeftColor = System.Drawing.Color.Black
        Me.Label7.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.RightColor = System.Drawing.Color.Black
        Me.Label7.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Border.TopColor = System.Drawing.Color.Black
        Me.Label7.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label7.Height = 0.19!
        Me.Label7.HyperLink = Nothing
        Me.Label7.Left = 0.0625!
        Me.Label7.Name = "Label7"
        Me.Label7.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label7.Text = "Si es ""Si"", indique el Nombre de la Institución o Persona:"
        Me.Label7.Top = 4.40625!
        Me.Label7.Width = 3.25!
        '
        'txtCuotaOtroCredito
        '
        Me.txtCuotaOtroCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCuotaOtroCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCuotaOtroCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCuotaOtroCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotaOtroCredito.Border.RightColor = System.Drawing.Color.Black
        Me.txtCuotaOtroCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotaOtroCredito.Border.TopColor = System.Drawing.Color.Black
        Me.txtCuotaOtroCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCuotaOtroCredito.Height = 0.1875!
        Me.txtCuotaOtroCredito.Left = 3.75!
        Me.txtCuotaOtroCredito.Name = "txtCuotaOtroCredito"
        Me.txtCuotaOtroCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCuotaOtroCredito.Text = Nothing
        Me.txtCuotaOtroCredito.Top = 4.90625!
        Me.txtCuotaOtroCredito.Width = 1.125!
        '
        'txtMontoSolOtroCredito
        '
        Me.txtMontoSolOtroCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoSolOtroCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoSolOtroCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoSolOtroCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSolOtroCredito.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoSolOtroCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSolOtroCredito.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoSolOtroCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoSolOtroCredito.Height = 0.19!
        Me.txtMontoSolOtroCredito.Left = 1.1875!
        Me.txtMontoSolOtroCredito.Name = "txtMontoSolOtroCredito"
        Me.txtMontoSolOtroCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoSolOtroCredito.Text = Nothing
        Me.txtMontoSolOtroCredito.Top = 4.65625!
        Me.txtMontoSolOtroCredito.Width = 1.5!
        '
        'Label8
        '
        Me.Label8.Border.BottomColor = System.Drawing.Color.Black
        Me.Label8.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.LeftColor = System.Drawing.Color.Black
        Me.Label8.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.RightColor = System.Drawing.Color.Black
        Me.Label8.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Border.TopColor = System.Drawing.Color.Black
        Me.Label8.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label8.Height = 0.19!
        Me.Label8.HyperLink = Nothing
        Me.Label8.Left = 0.0625!
        Me.Label8.Name = "Label8"
        Me.Label8.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label8.Text = "Periodicidad con que paga:"
        Me.Label8.Top = 4.90625!
        Me.Label8.Width = 1.56!
        '
        'txtPeriodicidadOtroCredito
        '
        Me.txtPeriodicidadOtroCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPeriodicidadOtroCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPeriodicidadOtroCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPeriodicidadOtroCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPeriodicidadOtroCredito.Border.RightColor = System.Drawing.Color.Black
        Me.txtPeriodicidadOtroCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPeriodicidadOtroCredito.Border.TopColor = System.Drawing.Color.Black
        Me.txtPeriodicidadOtroCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPeriodicidadOtroCredito.Height = 0.19!
        Me.txtPeriodicidadOtroCredito.Left = 1.6875!
        Me.txtPeriodicidadOtroCredito.Name = "txtPeriodicidadOtroCredito"
        Me.txtPeriodicidadOtroCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPeriodicidadOtroCredito.Text = Nothing
        Me.txtPeriodicidadOtroCredito.Top = 4.90625!
        Me.txtPeriodicidadOtroCredito.Width = 0.69!
        '
        'Label9
        '
        Me.Label9.Border.BottomColor = System.Drawing.Color.Black
        Me.Label9.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.LeftColor = System.Drawing.Color.Black
        Me.Label9.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.RightColor = System.Drawing.Color.Black
        Me.Label9.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Border.TopColor = System.Drawing.Color.Black
        Me.Label9.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label9.Height = 0.19!
        Me.Label9.HyperLink = Nothing
        Me.Label9.Left = 2.5625!
        Me.Label9.Name = "Label9"
        Me.Label9.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label9.Text = "Cuota que entrega:"
        Me.Label9.Top = 4.90625!
        Me.Label9.Width = 1.19!
        '
        'Label10
        '
        Me.Label10.Border.BottomColor = System.Drawing.Color.Black
        Me.Label10.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.LeftColor = System.Drawing.Color.Black
        Me.Label10.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.RightColor = System.Drawing.Color.Black
        Me.Label10.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Border.TopColor = System.Drawing.Color.Black
        Me.Label10.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label10.Height = 0.19!
        Me.Label10.HyperLink = Nothing
        Me.Label10.Left = 0.0625!
        Me.Label10.Name = "Label10"
        Me.Label10.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label10.Text = "Monto Solicitado:"
        Me.Label10.Top = 4.65625!
        Me.Label10.Width = 1.06!
        '
        'txtPlazoOtroCredito
        '
        Me.txtPlazoOtroCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPlazoOtroCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPlazoOtroCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPlazoOtroCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoOtroCredito.Border.RightColor = System.Drawing.Color.Black
        Me.txtPlazoOtroCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoOtroCredito.Border.TopColor = System.Drawing.Color.Black
        Me.txtPlazoOtroCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoOtroCredito.Height = 0.1875!
        Me.txtPlazoOtroCredito.Left = 4.083333!
        Me.txtPlazoOtroCredito.Name = "txtPlazoOtroCredito"
        Me.txtPlazoOtroCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPlazoOtroCredito.Text = Nothing
        Me.txtPlazoOtroCredito.Top = 4.666667!
        Me.txtPlazoOtroCredito.Width = 0.8125!
        '
        'Label11
        '
        Me.Label11.Border.BottomColor = System.Drawing.Color.Black
        Me.Label11.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.LeftColor = System.Drawing.Color.Black
        Me.Label11.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.RightColor = System.Drawing.Color.Black
        Me.Label11.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Border.TopColor = System.Drawing.Color.Black
        Me.Label11.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label11.Height = 0.19!
        Me.Label11.HyperLink = Nothing
        Me.Label11.Left = 2.9375!
        Me.Label11.Name = "Label11"
        Me.Label11.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label11.Text = "Plazo del Crédito:"
        Me.Label11.Top = 4.65625!
        Me.Label11.Width = 1.06!
        '
        'txtTipoPlazoOtroCredito
        '
        Me.txtTipoPlazoOtroCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoPlazoOtroCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoPlazoOtroCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoPlazoOtroCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoOtroCredito.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoPlazoOtroCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoOtroCredito.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoPlazoOtroCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoOtroCredito.Height = 0.1875!
        Me.txtTipoPlazoOtroCredito.Left = 6.25!
        Me.txtTipoPlazoOtroCredito.Name = "txtTipoPlazoOtroCredito"
        Me.txtTipoPlazoOtroCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTipoPlazoOtroCredito.Text = Nothing
        Me.txtTipoPlazoOtroCredito.Top = 4.666667!
        Me.txtTipoPlazoOtroCredito.Width = 1.125!
        '
        'Label12
        '
        Me.Label12.Border.BottomColor = System.Drawing.Color.Black
        Me.Label12.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.LeftColor = System.Drawing.Color.Black
        Me.Label12.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.RightColor = System.Drawing.Color.Black
        Me.Label12.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Border.TopColor = System.Drawing.Color.Black
        Me.Label12.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label12.Height = 0.1875!
        Me.Label12.HyperLink = Nothing
        Me.Label12.Left = 5.40625!
        Me.Label12.Name = "Label12"
        Me.Label12.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label12.Text = "Tipo de Plazo:"
        Me.Label12.Top = 4.666667!
        Me.Label12.Width = 0.8125!
        '
        'txtSaldoOtroCredito
        '
        Me.txtSaldoOtroCredito.Border.BottomColor = System.Drawing.Color.Black
        Me.txtSaldoOtroCredito.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtSaldoOtroCredito.Border.LeftColor = System.Drawing.Color.Black
        Me.txtSaldoOtroCredito.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldoOtroCredito.Border.RightColor = System.Drawing.Color.Black
        Me.txtSaldoOtroCredito.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldoOtroCredito.Border.TopColor = System.Drawing.Color.Black
        Me.txtSaldoOtroCredito.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSaldoOtroCredito.Height = 0.19!
        Me.txtSaldoOtroCredito.Left = 5.875!
        Me.txtSaldoOtroCredito.Name = "txtSaldoOtroCredito"
        Me.txtSaldoOtroCredito.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtSaldoOtroCredito.Text = Nothing
        Me.txtSaldoOtroCredito.Top = 4.90625!
        Me.txtSaldoOtroCredito.Width = 1.5!
        '
        'Label13
        '
        Me.Label13.Border.BottomColor = System.Drawing.Color.Black
        Me.Label13.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.LeftColor = System.Drawing.Color.Black
        Me.Label13.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.RightColor = System.Drawing.Color.Black
        Me.Label13.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Border.TopColor = System.Drawing.Color.Black
        Me.Label13.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label13.Height = 0.19!
        Me.Label13.HyperLink = Nothing
        Me.Label13.Left = 5.375!
        Me.Label13.Name = "Label13"
        Me.Label13.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label13.Text = "Saldo:"
        Me.Label13.Top = 4.90625!
        Me.Label13.Width = 0.44!
        '
        'lblInteresPrestamo
        '
        Me.lblInteresPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblInteresPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteresPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblInteresPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteresPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.lblInteresPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteresPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.lblInteresPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblInteresPrestamo.Height = 0.1875!
        Me.lblInteresPrestamo.HyperLink = Nothing
        Me.lblInteresPrestamo.Left = 0.0625!
        Me.lblInteresPrestamo.MultiLine = False
        Me.lblInteresPrestamo.Name = "lblInteresPrestamo"
        Me.lblInteresPrestamo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 9.75pt; vertical-align: middle; "
        Me.lblInteresPrestamo.Text = "Datos del Préstamo"
        Me.lblInteresPrestamo.Top = 5.4375!
        Me.lblInteresPrestamo.Width = 1.8125!
        '
        'txtMontoPrestamo
        '
        Me.txtMontoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtMontoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtMontoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtMontoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.txtMontoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.txtMontoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtMontoPrestamo.Height = 0.1875!
        Me.txtMontoPrestamo.Left = 3.010417!
        Me.txtMontoPrestamo.Name = "txtMontoPrestamo"
        Me.txtMontoPrestamo.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtMontoPrestamo.Text = Nothing
        Me.txtMontoPrestamo.Top = 5.729167!
        Me.txtMontoPrestamo.Width = 1.25!
        '
        'lblMontoPrestamo
        '
        Me.lblMontoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblMontoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblMontoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.lblMontoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.lblMontoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblMontoPrestamo.Height = 0.1875!
        Me.lblMontoPrestamo.HyperLink = Nothing
        Me.lblMontoPrestamo.Left = 0.0625!
        Me.lblMontoPrestamo.Name = "lblMontoPrestamo"
        Me.lblMontoPrestamo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblMontoPrestamo.Text = "Cuánto solicitaría de préstamo para su negocio: C$"
        Me.lblMontoPrestamo.Top = 5.729167!
        Me.lblMontoPrestamo.Width = 2.875!
        '
        'txtTipoPlazoPrestamo
        '
        Me.txtTipoPlazoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtTipoPlazoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtTipoPlazoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtTipoPlazoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.txtTipoPlazoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.txtTipoPlazoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtTipoPlazoPrestamo.Height = 0.1875!
        Me.txtTipoPlazoPrestamo.Left = 6.4375!
        Me.txtTipoPlazoPrestamo.Name = "txtTipoPlazoPrestamo"
        Me.txtTipoPlazoPrestamo.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtTipoPlazoPrestamo.Text = Nothing
        Me.txtTipoPlazoPrestamo.Top = 5.729167!
        Me.txtTipoPlazoPrestamo.Width = 0.9375!
        '
        'txtPlazoPrestamo
        '
        Me.txtPlazoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.txtPlazoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtPlazoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.txtPlazoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.txtPlazoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.txtPlazoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtPlazoPrestamo.Height = 0.1875!
        Me.txtPlazoPrestamo.Left = 6.0!
        Me.txtPlazoPrestamo.Name = "txtPlazoPrestamo"
        Me.txtPlazoPrestamo.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtPlazoPrestamo.Text = Nothing
        Me.txtPlazoPrestamo.Top = 5.729167!
        Me.txtPlazoPrestamo.Width = 0.375!
        '
        'lblPlazoPrestamo
        '
        Me.lblPlazoPrestamo.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPlazoPrestamo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoPrestamo.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPlazoPrestamo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoPrestamo.Border.RightColor = System.Drawing.Color.Black
        Me.lblPlazoPrestamo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoPrestamo.Border.TopColor = System.Drawing.Color.Black
        Me.lblPlazoPrestamo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPlazoPrestamo.Height = 0.1875!
        Me.lblPlazoPrestamo.HyperLink = Nothing
        Me.lblPlazoPrestamo.Left = 5.0625!
        Me.lblPlazoPrestamo.Name = "lblPlazoPrestamo"
        Me.lblPlazoPrestamo.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblPlazoPrestamo.Text = "A qué plazo:"
        Me.lblPlazoPrestamo.Top = 5.729167!
        Me.lblPlazoPrestamo.Width = 0.875!
        '
        'txtSclGrupoSolidarioID
        '
        Me.txtSclGrupoSolidarioID.Border.BottomColor = System.Drawing.Color.Black
        Me.txtSclGrupoSolidarioID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSclGrupoSolidarioID.Border.LeftColor = System.Drawing.Color.Black
        Me.txtSclGrupoSolidarioID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSclGrupoSolidarioID.Border.RightColor = System.Drawing.Color.Black
        Me.txtSclGrupoSolidarioID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSclGrupoSolidarioID.Border.TopColor = System.Drawing.Color.Black
        Me.txtSclGrupoSolidarioID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtSclGrupoSolidarioID.Height = 0.1875!
        Me.txtSclGrupoSolidarioID.Left = 7.0!
        Me.txtSclGrupoSolidarioID.Name = "txtSclGrupoSolidarioID"
        Me.txtSclGrupoSolidarioID.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtSclGrupoSolidarioID.Text = Nothing
        Me.txtSclGrupoSolidarioID.Top = 0.0625!
        Me.txtSclGrupoSolidarioID.Visible = False
        Me.txtSclGrupoSolidarioID.Width = 0.375!
        '
        'txtFechaVerificacion
        '
        Me.txtFechaVerificacion.Border.BottomColor = System.Drawing.Color.Black
        Me.txtFechaVerificacion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtFechaVerificacion.Border.LeftColor = System.Drawing.Color.Black
        Me.txtFechaVerificacion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaVerificacion.Border.RightColor = System.Drawing.Color.Black
        Me.txtFechaVerificacion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaVerificacion.Border.TopColor = System.Drawing.Color.Black
        Me.txtFechaVerificacion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtFechaVerificacion.Height = 0.1875!
        Me.txtFechaVerificacion.Left = 6.125!
        Me.txtFechaVerificacion.Name = "txtFechaVerificacion"
        Me.txtFechaVerificacion.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtFechaVerificacion.Text = Nothing
        Me.txtFechaVerificacion.Top = 0.375!
        Me.txtFechaVerificacion.Width = 1.25!
        '
        'txtCodigoFicha
        '
        Me.txtCodigoFicha.Border.BottomColor = System.Drawing.Color.Black
        Me.txtCodigoFicha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtCodigoFicha.Border.LeftColor = System.Drawing.Color.Black
        Me.txtCodigoFicha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigoFicha.Border.RightColor = System.Drawing.Color.Black
        Me.txtCodigoFicha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigoFicha.Border.TopColor = System.Drawing.Color.Black
        Me.txtCodigoFicha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtCodigoFicha.Height = 0.1875!
        Me.txtCodigoFicha.Left = 0.625!
        Me.txtCodigoFicha.Name = "txtCodigoFicha"
        Me.txtCodigoFicha.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtCodigoFicha.Text = Nothing
        Me.txtCodigoFicha.Top = 0.375!
        Me.txtCodigoFicha.Width = 3.625!
        '
        'lblFechaInscripcion
        '
        Me.lblFechaInscripcion.Border.BottomColor = System.Drawing.Color.Black
        Me.lblFechaInscripcion.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaInscripcion.Border.LeftColor = System.Drawing.Color.Black
        Me.lblFechaInscripcion.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaInscripcion.Border.RightColor = System.Drawing.Color.Black
        Me.lblFechaInscripcion.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaInscripcion.Border.TopColor = System.Drawing.Color.Black
        Me.lblFechaInscripcion.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblFechaInscripcion.Height = 0.1875!
        Me.lblFechaInscripcion.HyperLink = Nothing
        Me.lblFechaInscripcion.Left = 4.791667!
        Me.lblFechaInscripcion.Name = "lblFechaInscripcion"
        Me.lblFechaInscripcion.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblFechaInscripcion.Text = "Fecha de Verificación:"
        Me.lblFechaInscripcion.Top = 0.375!
        Me.lblFechaInscripcion.Width = 1.3125!
        '
        'lblCodigoFicha
        '
        Me.lblCodigoFicha.Border.BottomColor = System.Drawing.Color.Black
        Me.lblCodigoFicha.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFicha.Border.LeftColor = System.Drawing.Color.Black
        Me.lblCodigoFicha.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFicha.Border.RightColor = System.Drawing.Color.Black
        Me.lblCodigoFicha.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFicha.Border.TopColor = System.Drawing.Color.Black
        Me.lblCodigoFicha.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblCodigoFicha.Height = 0.1875!
        Me.lblCodigoFicha.HyperLink = Nothing
        Me.lblCodigoFicha.Left = 0.0625!
        Me.lblCodigoFicha.Name = "lblCodigoFicha"
        Me.lblCodigoFicha.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblCodigoFicha.Text = "Código:"
        Me.lblCodigoFicha.Top = 0.375!
        Me.lblCodigoFicha.Width = 0.5625!
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.lblObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblObservaciones.Height = 0.1875!
        Me.lblObservaciones.HyperLink = Nothing
        Me.lblObservaciones.Left = 0.0625!
        Me.lblObservaciones.MultiLine = False
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 9.75pt; vertic" & _
            "al-align: middle; "
        Me.lblObservaciones.Text = "Observaciones del negocio actual y/o propuesto"
        Me.lblObservaciones.Top = 6.9375!
        Me.lblObservaciones.Width = 7.3125!
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Border.BottomColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtObservaciones.Border.LeftColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtObservaciones.Border.RightColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtObservaciones.Border.TopColor = System.Drawing.Color.Black
        Me.txtObservaciones.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtObservaciones.Height = 0.8125!
        Me.txtObservaciones.Left = 0.0625!
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Style = "ddo-char-set: 0; text-align: justify; font-size: 8.25pt; "
        Me.txtObservaciones.Text = Nothing
        Me.txtObservaciones.Top = 7.239583!
        Me.txtObservaciones.Width = 7.3125!
        '
        'txtNombreRepresentante
        '
        Me.txtNombreRepresentante.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNombreRepresentante.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtNombreRepresentante.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNombreRepresentante.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreRepresentante.Border.RightColor = System.Drawing.Color.Black
        Me.txtNombreRepresentante.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreRepresentante.Border.TopColor = System.Drawing.Color.Black
        Me.txtNombreRepresentante.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNombreRepresentante.Height = 0.1875!
        Me.txtNombreRepresentante.Left = 2.0625!
        Me.txtNombreRepresentante.Name = "txtNombreRepresentante"
        Me.txtNombreRepresentante.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNombreRepresentante.Text = Nothing
        Me.txtNombreRepresentante.Top = 8.208333!
        Me.txtNombreRepresentante.Width = 3.625!
        '
        'lblNombreRepresentante
        '
        Me.lblNombreRepresentante.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNombreRepresentante.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreRepresentante.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNombreRepresentante.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreRepresentante.Border.RightColor = System.Drawing.Color.Black
        Me.lblNombreRepresentante.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreRepresentante.Border.TopColor = System.Drawing.Color.Black
        Me.lblNombreRepresentante.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNombreRepresentante.Height = 0.1875!
        Me.lblNombreRepresentante.HyperLink = Nothing
        Me.lblNombreRepresentante.Left = 2.0625!
        Me.lblNombreRepresentante.Name = "lblNombreRepresentante"
        Me.lblNombreRepresentante.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; vertic" & _
            "al-align: middle; "
        Me.lblNombreRepresentante.Text = "Nombre del Representante Programa Usura Cero"
        Me.lblNombreRepresentante.Top = 8.458333!
        Me.lblNombreRepresentante.Width = 3.625!
        '
        'lblDispuestaGS
        '
        Me.lblDispuestaGS.Border.BottomColor = System.Drawing.Color.Black
        Me.lblDispuestaGS.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDispuestaGS.Border.LeftColor = System.Drawing.Color.Black
        Me.lblDispuestaGS.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDispuestaGS.Border.RightColor = System.Drawing.Color.Black
        Me.lblDispuestaGS.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDispuestaGS.Border.TopColor = System.Drawing.Color.Black
        Me.lblDispuestaGS.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblDispuestaGS.Height = 0.25!
        Me.lblDispuestaGS.HyperLink = Nothing
        Me.lblDispuestaGS.Left = 0.07291666!
        Me.lblDispuestaGS.Name = "lblDispuestaGS"
        Me.lblDispuestaGS.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblDispuestaGS.Text = "Está dispuesta a conformar su grupo solidario: Si"
        Me.lblDispuestaGS.Top = 5.989583!
        Me.lblDispuestaGS.Width = 2.75!
        '
        'chkDispuestaSi
        '
        Me.chkDispuestaSi.Border.BottomColor = System.Drawing.Color.Black
        Me.chkDispuestaSi.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaSi.Border.LeftColor = System.Drawing.Color.Black
        Me.chkDispuestaSi.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaSi.Border.RightColor = System.Drawing.Color.Black
        Me.chkDispuestaSi.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaSi.Border.TopColor = System.Drawing.Color.Black
        Me.chkDispuestaSi.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaSi.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDispuestaSi.Height = 0.1875!
        Me.chkDispuestaSi.Left = 2.885417!
        Me.chkDispuestaSi.Name = "chkDispuestaSi"
        Me.chkDispuestaSi.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkDispuestaSi.Text = ""
        Me.chkDispuestaSi.Top = 5.989583!
        Me.chkDispuestaSi.Width = 0.25!
        '
        'chkDispuestaNo
        '
        Me.chkDispuestaNo.Border.BottomColor = System.Drawing.Color.Black
        Me.chkDispuestaNo.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaNo.Border.LeftColor = System.Drawing.Color.Black
        Me.chkDispuestaNo.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaNo.Border.RightColor = System.Drawing.Color.Black
        Me.chkDispuestaNo.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaNo.Border.TopColor = System.Drawing.Color.Black
        Me.chkDispuestaNo.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.chkDispuestaNo.CheckAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDispuestaNo.Height = 0.1875!
        Me.chkDispuestaNo.Left = 3.447917!
        Me.chkDispuestaNo.Name = "chkDispuestaNo"
        Me.chkDispuestaNo.Style = "ddo-char-set: 0; font-size: 8.25pt; "
        Me.chkDispuestaNo.Text = ""
        Me.chkDispuestaNo.Top = 5.989583!
        Me.chkDispuestaNo.Width = 0.25!
        '
        'Label21
        '
        Me.Label21.Border.BottomColor = System.Drawing.Color.Black
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.LeftColor = System.Drawing.Color.Black
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.RightColor = System.Drawing.Color.Black
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.TopColor = System.Drawing.Color.Black
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 3.260417!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label21.Text = "No"
        Me.Label21.Top = 5.989583!
        Me.Label21.Width = 0.1875!
        '
        'txtGrupoSolidario
        '
        Me.txtGrupoSolidario.Border.BottomColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtGrupoSolidario.Border.LeftColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoSolidario.Border.RightColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoSolidario.Border.TopColor = System.Drawing.Color.Black
        Me.txtGrupoSolidario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtGrupoSolidario.Height = 0.1875!
        Me.txtGrupoSolidario.Left = 2.260417!
        Me.txtGrupoSolidario.Name = "txtGrupoSolidario"
        Me.txtGrupoSolidario.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtGrupoSolidario.Text = Nothing
        Me.txtGrupoSolidario.Top = 6.302083!
        Me.txtGrupoSolidario.Width = 5.125!
        '
        'lblGrupoSolidario
        '
        Me.lblGrupoSolidario.Border.BottomColor = System.Drawing.Color.Black
        Me.lblGrupoSolidario.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupoSolidario.Border.LeftColor = System.Drawing.Color.Black
        Me.lblGrupoSolidario.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupoSolidario.Border.RightColor = System.Drawing.Color.Black
        Me.lblGrupoSolidario.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupoSolidario.Border.TopColor = System.Drawing.Color.Black
        Me.lblGrupoSolidario.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblGrupoSolidario.Height = 0.1875!
        Me.lblGrupoSolidario.HyperLink = Nothing
        Me.lblGrupoSolidario.Left = 0.07291666!
        Me.lblGrupoSolidario.Name = "lblGrupoSolidario"
        Me.lblGrupoSolidario.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.lblGrupoSolidario.Text = "Cómo se llamará su Grupo Solidario:"
        Me.lblGrupoSolidario.Top = 6.302083!
        Me.lblGrupoSolidario.Width = 2.125!
        '
        'txtConoceSocias
        '
        Me.txtConoceSocias.Border.BottomColor = System.Drawing.Color.Black
        Me.txtConoceSocias.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.Solid
        Me.txtConoceSocias.Border.LeftColor = System.Drawing.Color.Black
        Me.txtConoceSocias.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtConoceSocias.Border.RightColor = System.Drawing.Color.Black
        Me.txtConoceSocias.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtConoceSocias.Border.TopColor = System.Drawing.Color.Black
        Me.txtConoceSocias.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtConoceSocias.Height = 0.1875!
        Me.txtConoceSocias.Left = 2.25!
        Me.txtConoceSocias.Name = "txtConoceSocias"
        Me.txtConoceSocias.Style = "ddo-char-set: 0; font-size: 8.25pt; vertical-align: middle; "
        Me.txtConoceSocias.Text = Nothing
        Me.txtConoceSocias.Top = 6.5625!
        Me.txtConoceSocias.Width = 1.75!
        '
        'Label14
        '
        Me.Label14.Border.BottomColor = System.Drawing.Color.Black
        Me.Label14.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.LeftColor = System.Drawing.Color.Black
        Me.Label14.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.RightColor = System.Drawing.Color.Black
        Me.Label14.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Border.TopColor = System.Drawing.Color.Black
        Me.Label14.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label14.Height = 0.1875!
        Me.Label14.HyperLink = Nothing
        Me.Label14.Left = 0.0625!
        Me.Label14.Name = "Label14"
        Me.Label14.Style = "ddo-char-set: 0; font-weight: bold; font-size: 8.25pt; vertical-align: middle; "
        Me.Label14.Text = "Conoce a todas sus socias:"
        Me.Label14.Top = 6.5625!
        Me.Label14.Width = 1.625!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'rptSclFichaVerificacion
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.69!
        Me.PageSettings.PaperWidth = 8.27!
        Me.PrintWidth = 7.625!
        Me.Sections.Add(Me.EncabezadoReporte)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.lblTitulo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtparametro2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReportInfo1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDatosGenerales, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreApellidos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblEdad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCedula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTelefono, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblBarrio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDistrito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMunicipio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDatosNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTieneNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkSiNegocioActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkNoNegocioActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNoTieneNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoNegocioActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoNegocioActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoNegocioPropuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblTipoNegocioPropuesto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDireccionNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDireccionNegocio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaApertura, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoPlazoVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoVentas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOtroCreditoNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOtroCreditoSi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInstitucionOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCuotaOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoSolOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPeriodicidadOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazoOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoPlazoOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoOtroCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblInteresPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblMontoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoPlazoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlazoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPlazoPrestamo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSclGrupoSolidarioID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVerificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCodigoFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFechaInscripcion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblCodigoFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtObservaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNombreRepresentante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNombreRepresentante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblDispuestaGS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDispuestaSi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkDispuestaNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrupoSolidario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblGrupoSolidario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConoceSocias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents EncabezadoReporte As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents SubReporte As DataDynamics.ActiveReports.SubReport
    Friend WithEvents lblTitulo As DataDynamics.ActiveReports.Label
    Friend WithEvents lblUsuario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtUsuario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtHora As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtFecha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNombre As DataDynamics.ActiveReports.Label
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtparametro1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtparametro2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportInfo1 As DataDynamics.ActiveReports.ReportInfo
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents lblDatosGenerales As DataDynamics.ActiveReports.Label
    Friend WithEvents txtNombreApellidos As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtEdad As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblEdad As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCedula As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCedula As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTelefono As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtDireccion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTelefono As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDireccion As DataDynamics.ActiveReports.Label
    Friend WithEvents txtBarrio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblBarrio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDistrito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDistrito As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMunicipio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMunicipio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDepartamento As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblDepartamento As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDatosNegocio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTieneNegocio As DataDynamics.ActiveReports.Label
    Friend WithEvents chkSiNegocioActual As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents chkNoNegocioActual As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents lblNoTieneNegocio As DataDynamics.ActiveReports.Label
    Friend WithEvents lblTipoNegocioActual As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTipoNegocioActual As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipoNegocioPropuesto As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblTipoNegocioPropuesto As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDireccionNegocio As DataDynamics.ActiveReports.Label
    Friend WithEvents txtDireccionNegocio As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFechaApertura As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaApertura As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipoPlazoVentas As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoVentas As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents chkOtroCreditoNo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents chkOtroCreditoSi As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtInstitucionOtroCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label7 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtCuotaOtroCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtMontoSolOtroCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label8 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPeriodicidadOtroCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label9 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label10 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtPlazoOtroCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label11 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTipoPlazoOtroCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label12 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSaldoOtroCredito As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label13 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblInteresPrestamo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtMontoPrestamo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblMontoPrestamo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtTipoPlazoPrestamo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPlazoPrestamo As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblPlazoPrestamo As DataDynamics.ActiveReports.Label
    Friend WithEvents txtSclGrupoSolidarioID As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtCodigoFicha As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblCodigoFicha As DataDynamics.ActiveReports.Label
    Friend WithEvents txtFechaVerificacion As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblFechaInscripcion As DataDynamics.ActiveReports.Label
    Friend WithEvents lblObservaciones As DataDynamics.ActiveReports.Label
    Friend WithEvents txtObservaciones As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNombreRepresentante As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblNombreRepresentante As DataDynamics.ActiveReports.Label
    Friend WithEvents lblDispuestaGS As DataDynamics.ActiveReports.Label
    Friend WithEvents chkDispuestaSi As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents chkDispuestaNo As DataDynamics.ActiveReports.CheckBox
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents txtGrupoSolidario As DataDynamics.ActiveReports.TextBox
    Friend WithEvents lblGrupoSolidario As DataDynamics.ActiveReports.Label
    Friend WithEvents txtConoceSocias As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label14 As DataDynamics.ActiveReports.Label
End Class
