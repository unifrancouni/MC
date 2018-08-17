Public Class frmScnParametrosMinutas
    'Importante llamado ColorVentana = "Celestelight"  Contabilidad
    'NomRep 
    Dim mNomRep As EnumReportes
    Dim mColor As String
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes
    Public Enum EnumReportes
        MinutasFechas = 1
        MinutasSegunServicioWeb = 2
        MinutasErroresSegunServicioWeb = 3
        DetalleCierre = 4
        SociasVariasFuentes = 5
        SociasVariosMunicipios = 6
        SociasBarriosYMercados = 7
        ComparativoCierreCajaCN24TE12 = 8
        ComparativoCierreCajaCN24CN25 = 9
        ComparativoCierreCajaCN24CN28 = 10
        SolicitudesChequeAutorizadasCN40 = 11
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    Public Property ColorVentana() As String
        Get
            Return mColor
        End Get
        Set(ByVal value As String)
            mColor = value
        End Set
    End Property

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    '----------------------------------------------------------------------
    'Llama  a las opciones de los  reportes
    '----------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Try

            If ValidarParametros() = False Then Exit Sub
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            Select Case mNomRep
                Case EnumReportes.MinutasFechas
                    frmVisor.Text = "Estado de las Minutas"
                    frmVisor.NombreReporte = "RepScnCN20M.Rpt"
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@TipoSalida") = IIf(RadTodas.Checked, 0, IIf(RadCuadradas.Checked, 1, 2))

                Case EnumReportes.MinutasSegunServicioWeb
                    frmVisor.Text = "Estado de las Minutas segun envio a MHCP"
                    frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"
                    Filtro = " Where dFechaDeposito>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaDeposito<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                    frmVisor.SQLQuery = "Select * From vwScnMinutasEstadoWebService " & Filtro
                    frmVisor.NombreReporte = "RepScnCN21.Rpt"

                Case EnumReportes.MinutasErroresSegunServicioWeb
                    frmVisor.Text = "Errores en las Minutas segun envio a MHCP"
                    frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"
                    Filtro = " Where dFechaDeposito>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaDeposito<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                    frmVisor.SQLQuery = "Select * From vwScnMinutasErroresWebService " & Filtro
                    frmVisor.NombreReporte = "RepScnCN22.Rpt"

                Case EnumReportes.DetalleCierre
                    frmVisor.Text = "Detalle del Cierre"
                    frmVisor.NombreReporte = "RepScnCN28.Rpt"
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                Case EnumReportes.SociasVariasFuentes

                    frmVisor.Text = "Socias con créditos  en más de una fuente"
                    frmVisor.NombreReporte = "RepSccCC48.Rpt"
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                Case EnumReportes.SociasVariosMunicipios
                    frmVisor.Text = "Socias con créditos en más de un municipio"
                    frmVisor.NombreReporte = "RepSccCC49.Rpt"
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                Case EnumReportes.SociasBarriosYMercados
                    frmVisor.Text = "Socias con créditos en barrio y mercado"
                    frmVisor.NombreReporte = "RepSccCC50.Rpt"
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                    '***********************************************************
                    '********** COMPARATIVOS DE CIERRES DE CARTERA *************
                    '***********************************************************
                Case EnumReportes.ComparativoCierreCajaCN24TE12
                    frmVisor.Text = "Minutas y Recibos vs. Recibos Arqueados"
                    frmVisor.NombreReporte = "RepScnCN33.Rpt"
                    frmVisor.Formulas("RangoFechas") = "' DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                    frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                Case EnumReportes.ComparativoCierreCajaCN24CN25
                    frmVisor.Text = "Minutas y Recibos vs. Ingresos Recuperados"
                    frmVisor.NombreReporte = "RepScnCN34.Rpt"
                    frmVisor.Formulas("RangoFechas") = "' DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                    frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                Case EnumReportes.ComparativoCierreCajaCN24CN28
                    frmVisor.Text = "Minutas y Recibos vs. Detalle Cierres Cartera"
                    frmVisor.NombreReporte = "RepScnCN35.Rpt"
                    frmVisor.Formulas("RangoFechas") = "' DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                    frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                Case EnumReportes.SolicitudesChequeAutorizadasCN40
                    frmVisor.Text = "Listado de Solicitudes de Cheque Autorizadas"
                    frmVisor.Formulas("Fecha") = "' FECHA ENTREGA DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                    Filtro = " Where dFechaEntrega >= CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaEntrega <= CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                    frmVisor.SQLQuery = "Select * From vwSccSolicitudesChequeAutorizadas " & Filtro
                    frmVisor.NombreReporte = "RepScnCN40.Rpt"


            End Select
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False
            Me.errParametro.Clear()

            'Fecha Inicial Valida:
            If IsDBNull(cdeFechaInicial.Value) Then
                MsgBox("Debe seleccionar una fecha de inicio válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válido.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            'Fecha Final Valida:
            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If

            'Fecha inicial <= fecha final:
            If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            'Maximo un mes de corte:
            If DateDiff(DateInterval.Day, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 31 And mNomRep <> EnumReportes.SociasBarriosYMercados And mNomRep <> EnumReportes.SociasVariasFuentes And mNomRep <> EnumReportes.SociasVariosMunicipios Then
                MsgBox("Imposible seleccionar cortes de fecha superiores a 30 días.", MsgBoxStyle.Information)
                Me.cdeFechaInicial.Focus()
                Exit Function
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    
    Private Sub frmScnParametrosMinutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.ColorVentana)

            If Me.ColorVentana = "CelesteLight" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Contabilidad")
            Else '"Verde"
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            Select Case mNomRep
                Case EnumReportes.DetalleCierre
                    Me.Text = "Reporte Detalle de Cierre Diario"
                Case EnumReportes.SociasBarriosYMercados
                    Me.Text = "Reporte Socias con Creditos en barrios y mercados"
                Case EnumReportes.SociasVariasFuentes
                    Me.Text = "Reporte Socias con Creditos de varias fuentes"
                Case EnumReportes.SociasVariosMunicipios
                    Me.Text = "Reporte Socias con Creditos en varios municipios"
                Case EnumReportes.ComparativoCierreCajaCN24TE12
                    Me.Text = "Reporte Minutas y Recibos vs. Recibos Arqueados"
                Case EnumReportes.ComparativoCierreCajaCN24CN25
                    Me.Text = "Reporte Minutas y Recibos vs. Ingresos Recuperados"
                Case EnumReportes.ComparativoCierreCajaCN24CN28
                    Me.Text = "Reporte Minutas y Recibos vs. Detalle Cierres Cartera"
                Case EnumReportes.SolicitudesChequeAutorizadasCN40
                    Me.Text = "Listado Solicitudes Cheque Autorizadas"
            End Select
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub frmScnParametrosMinutas_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Select Case mNomRep
            Case EnumReportes.MinutasErroresSegunServicioWeb, EnumReportes.MinutasSegunServicioWeb, EnumReportes.DetalleCierre, EnumReportes.SociasBarriosYMercados, EnumReportes.SociasVariasFuentes, EnumReportes.SociasVariosMunicipios, EnumReportes.ComparativoCierreCajaCN24CN25, EnumReportes.ComparativoCierreCajaCN24CN28, EnumReportes.ComparativoCierreCajaCN24TE12, EnumReportes.SolicitudesChequeAutorizadasCN40
                grpTipoCuadre.Enabled = False
        End Select
    End Sub
End Class