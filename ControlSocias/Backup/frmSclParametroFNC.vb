'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                26/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclParametroFNC.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Acta de Compromiso		     
'                                  o Ficha de Notificación de Crédito
'                                  o Ficha de Comité de Crédito
'                                  o Pagaré 	
'                                  o Acta de Comité de Crédito
'                                  o Tablas de Amortización
'                                  o Solicitudes de Desembolso
'                                  o Reporte de Comité de Crédito
'----------------------------------------------------------------------------
Public Class frmSclParametroFNC

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    public intFormatoID As Integer
    Dim intTipoID As Integer
    Dim StrCodigo As String
    Dim StrEstado As String
    Dim StrCodEstado As String
    Dim StrNombre As String
    Dim sColor As String

    Dim xdtOrden As BOSistema.Win.XDataSet.xDataTable
    Dim xdtGS As BOSistema.Win.XDataSet.xDataTable
    Dim xdtEstados As BOSistema.Win.XDataSet.xDataTable

    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes
    Public Enum EnumReportes
        rptSclActaDeCompromiso = 1
        rptSclFichaNotificacionCredito = 2
        rptSclFichaComiteCredito = 3
        rptSclPagare = 4
        rptSclListadoGrupos = 5
        rptSclListadoSocias = 6
        rptSclActaComiteCredito = 7
        rptSclTablaAmortizacion = 8
        rptSclSolicitudesDesembolso = 9
        rptSclReporteComite = 10
        rptSccSolicitudCheque = 11
        'Agregado Gamaliel 
        rptSclCreditosAprobados = 12
        'fin agregado 
        rptSclReporteDeCancelacionCredito = 13
        rptSclReporteDeVigenciaCredito = 14
        rptSclReporteHistoriaCreditoSocia = 15
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    Public Property intSclFormatoID() As Integer
        Get
            intSclFormatoID = intFormatoID
        End Get
        Set(ByVal value As Integer)
            intFormatoID = value
        End Set
    End Property

    Public Property intSccTipoID() As Integer
        Get
            intSccTipoID = intTipoID
        End Get
        Set(ByVal value As Integer)
            intTipoID = value
        End Set
    End Property

    Public Property NombreGrupo() As String
        Get
            Return Me.StrNombre
        End Get
        Set(ByVal value As String)
            Me.StrNombre = value
        End Set
    End Property

    Public Property CodigoFicha() As String
        Get
            Return Me.StrCodigo
        End Get
        Set(ByVal value As String)
            Me.StrCodigo = value
        End Set
    End Property

    Public Property CodigoEstadoFicha() As String
        Get
            Return Me.StrCodEstado
        End Get
        Set(ByVal value As String)
            Me.StrCodEstado = value
        End Set
    End Property

    Public Property Reporte() As DataDynamics.ActiveReports.ActiveReport3
        Get
            Return Me.ObjReporte
        End Get
        Set(ByVal value As DataDynamics.ActiveReports.ActiveReport3)
            ObjReporte = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/09/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Permite Inicializar variables y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            xdtOrden = New BOSistema.Win.XDataSet.xDataTable
            xdtGS = New BOSistema.Win.XDataSet.xDataTable
            xdtEstados = New BOSistema.Win.XDataSet.xDataTable

            'Cargar datos:
            CargarDatos()

            'Si impresión es un Formato desde una Interfaz:
            Me.txtCodigo.Text = StrCodigo
            Me.txtEstado.Text = StrEstado
            Me.mtbNumCedula.Select()
            sColor = "RojoLight"

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Titúlo de Reporte:
            Select Case mNomRep
                Case EnumReportes.rptSclActaDeCompromiso
                    Me.Text = "Parámetros Formato Acta de Compromiso"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Código del Grupo:"
                    lblEstado.Text = "Estado del Grupo:"
                    'sColor = "Verde"

                Case EnumReportes.rptSclListadoGrupos
                    Me.Text = "Parámetros Listado de Grupos Solidarios"
                    Me.lblCodRpt.Text = "Código Grupo:"
                    Me.lblEstadoRpt.Text = "Estado Grupo:"
                    Me.lblOrdenRpt.Text = "Ordenado Por:"
                    grpdatosFormatos.Visible = False
                    grpDatosListados.Visible = True
                    REM Sustitución Codigo Socias por Digitar Cedula
                    Me.mtbNumCedula.Visible = False
                    Me.cboGS.Visible = True

                Case EnumReportes.rptSclFichaComiteCredito
                    Me.Text = "Parámetros Formato Ficha de Comité de Crédito"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Código de Ficha:"
                    lblEstado.Text = "Estado del Crédito:"
                    sColor = "Verde"

                Case EnumReportes.rptSclFichaNotificacionCredito
                    Me.Text = "Parámetros Formato Ficha de Notificación de Crédito"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Código de Ficha:"
                    lblEstado.Text = "Estado del Crédito:"
                    sColor = "Verde"

                Case EnumReportes.rptSclPagare
                    Me.Text = "Parámetros Pagaré Grupo Solidario"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Código de Ficha:"
                    lblEstado.Text = "Estado del Crédito:"
                    sColor = "Verde"

                Case EnumReportes.rptSclListadoSocias
                    Me.Text = "Parámetros Listado de Socias"
                    Me.lblCodRpt.Text = "Código Socia:"
                    Me.lblEstadoRpt.Text = "Estado Socia:"
                    Me.lblOrdenRpt.Text = "Ordenado Por:"
                    grpdatosFormatos.Visible = False
                    grpDatosListados.Visible = True
                    REM Sustitución Codigo Socias por Digitar Cedula
                    Me.mtbNumCedula.Visible = True
                    Me.cboGS.Visible = False

                Case EnumReportes.rptSclActaComiteCredito
                    Me.Text = "Parámetros Acta de Comité de Crédito"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Número de Sesión:"
                    lblEstado.Text = "Fecha de Resolución:"
                    sColor = "Verde"

                Case EnumReportes.rptSclReporteComite
                    Me.Text = "Parámetros Reporte de Comité de Crédito"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Número de Sesión:"
                    lblEstado.Text = "Fecha de Resolución:"
                    sColor = "Verde"



                Case EnumReportes.rptSclTablaAmortizacion
                    Me.Text = "Parámetros Tabla de Amortización"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Código de Ficha:"
                    lblEstado.Text = "Estado del Crédito:"
                    sColor = "Verde"

                Case EnumReportes.rptSclSolicitudesDesembolso
                    Me.Text = "Solicitudes de Desembolso"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    lblCodigo.Text = "Código de Ficha:"
                    lblEstado.Text = "Estado del Crédito:"
                    sColor = "Verde"

                Case EnumReportes.rptSccSolicitudCheque
                    Me.Text = "Solicitudes de Cheque"
                    grpdatosFormatos.Visible = True
                    grpDatosListados.Visible = False
                    sColor = "Verde"
                    'Solicitudes de Cheque a Socias (Basadas en una FNC)
                    If Me.intSccTipoID = 1 Then
                        lblCodigo.Text = "Código Ficha:"
                        lblEstado.Text = "Estado Ficha:"
                    Else
                        lblCodigo.Text = "Código Solicitud:"
                        lblEstado.Text = "Estado Solicitud:"
                    End If

                    'Agregado Gamaliel
                Case EnumReportes.rptSclCreditosAprobados, EnumReportes.rptSclReporteHistoriaCreditoSocia
                    Me.Text = "Historial de Créditos"
                    Me.lblCodRpt.Text = "Socia:"
                    Me.lblEstadoRpt.Text = "Estado Socia:"
                    Me.lblOrdenRpt.Text = "Ordenado Por:"
                    grpdatosFormatos.Visible = False
                    grpDatosListados.Visible = True
                    REM Sustitución Codigo Socias por Digitar Cedula
                    Me.mtbNumCedula.Visible = True
                    Me.cboGS.Visible = False
                    'sColor = "Verde"
                    ''Fin agregado Gamaliel 



            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/10/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Permite Inicializar variables y controles.
    '-------------------------------------------------------------------------
    Private Sub CargarDatos()
        Dim xdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            xdtDatos = New BOSistema.Win.XDataSet.xDataTable

            'Según el Reporte: 
            If mNomRep = EnumReportes.rptSclListadoSocias Then
                StrSql = "SELECT sNumeroCedula as Cedula, nCodigo AS Codigo, sNombre1 + ' ' + sNombre2 + ' ' + sApellido1 + ' ' + sApellido2 AS Nombre,  CASE nSociaActiva WHEN 1 THEN 'Activa' ELSE 'Inactiva' END AS Estado " & _
                         "FROM  SclSocia " & _
                         "WHERE (nSclSociaID = " & intSclFormatoID & ")"
            ElseIf (mNomRep = EnumReportes.rptSclActaDeCompromiso) Or (mNomRep = EnumReportes.rptSclListadoGrupos) Then
                StrSql = "SELECT  a.sCodigo AS Codigo, a.sDescripcion AS Nombre, b.sDescripcion AS Estado " & _
                         "FROM  SclGrupoSolidario a INNER JOIN StbValorCatalogo b ON a.nStbEstadoGrupoID = b.nStbValorCatalogoID " & _
                         "WHERE (a.nSclGrupoSolidarioID = " & intSclFormatoID & ")"
                'Solicitudes de Cheque por StbPersona (Código , Estado de la Solicitud de Cheque Actual)
            ElseIf (mNomRep = EnumReportes.rptSccSolicitudCheque) And (Me.intSccTipoID = 0) Then
                StrSql = "SELECT SccSolicitudCheque.nCodigo AS Codigo, StbValorCatalogo.sDescripcion AS Estado, StbValorCatalogo.sCodigoInterno AS CodEstado,  ' ' AS Nombre " & _
                         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SccSolicitudCheque.nSccSolicitudChequeID = " & intSclFormatoID & ")"

            Else '-- Reportes Asociados con Ficha de Notificación del Crédito.
                StrSql = "SELECT  c.nCodigo AS Codigo, a.sCodigo + ' - ' + a.sDescripcion AS Nombre, b.sDescripcion AS Estado, b.sCodigoInterno AS CodEstado, c.sNumSesion, c.dFechaNotificacion " & _
                         "FROM  SclGrupoSolidario AS a INNER JOIN SclFichaNotificacionCredito AS c ON a.nSclGrupoSolidarioID = c.nSclGrupoSolidarioID INNER JOIN StbValorCatalogo AS b ON c.nStbEstadoCreditoID = b.nStbValorCatalogoID " & _
                         "WHERE (c.nSclFichaNotificacionID = " & intSclFormatoID & ")"
            End If

            ''Agregado Gamaliel 
            If mNomRep = EnumReportes.rptSclCreditosAprobados Then
                StrSql = "SELECT sNumeroCedula as Cedula, nCodigo AS Codigo, sNombre1 + ' ' + sNombre2 + ' ' + sApellido1 + ' ' + sApellido2 AS Nombre,  CASE nSociaActiva WHEN 1 THEN 'Activa' ELSE 'Inactiva' END AS Estado " & _
                         "FROM  SclSocia " & _
                         "WHERE (nSclSociaID = " & intSclFormatoID & ")"
            End If
            ''Fin agregado Gamaliel 

            xdtDatos.ExecuteSql(StrSql)
            If xdtDatos.Count > 0 Then
                If (mNomRep = EnumReportes.rptSclActaComiteCredito) Or (mNomRep = EnumReportes.rptSclReporteComite) Then
                    StrCodigo = xdtDatos.ValueField("sNumSesion")
                    StrEstado = xdtDatos.ValueField("dFechaNotificacion")
                Else
                    StrCodigo = xdtDatos.ValueField("Codigo")
                    StrNombre = xdtDatos.ValueField("Nombre")
                    StrEstado = xdtDatos.ValueField("Estado")
                    StrCodEstado = xdtDatos.ValueField("CodEstado")
                End If
                If mNomRep = EnumReportes.rptSclListadoSocias Or mNomRep = EnumReportes.rptSclCreditosAprobados Then
                    If Me.mtbNumCedula.Visible Then
                        Me.mtbNumCedula.Text = xdtDatos.ValueField("Cedula")
                        If Me.mtbNumCedula.Text = "999-999999-9999Z" Then Me.mtbNumCedula.Enabled = False
                    End If
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            xdtDatos.Close()
            xdtDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/09/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim XcDatosS As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            'Si el reporte es un Listado validar parámetros:
            If (mNomRep = EnumReportes.rptSclListadoGrupos) Or (mNomRep = EnumReportes.rptSclListadoSocias) Or (mNomRep = EnumReportes.rptSclCreditosAprobados) Then
                If ValidarParametros() = False Then
                    Exit Sub
                End If
            End If

            Me.Cursor = Cursors.WaitCursor
            Select Case mNomRep

                Case EnumReportes.rptSclActaDeCompromiso
                    ObjReporte = CargarRepActaCompromiso()

                Case EnumReportes.rptSclListadoGrupos
                    ObjReporte = CargarRepListadoGrupos()

                Case EnumReportes.rptSclFichaComiteCredito
                    ObjReporte = CargarRepFichaComiteCredito()

                Case EnumReportes.rptSclFichaNotificacionCredito
                    'Si es Grupo Solidario Usura / Mercados:
                    RptFichaNotificacionCredito(Me.intSclFormatoID, 1, False, "")

                Case EnumReportes.rptSclPagare
                    ObjReporte = CargarRepPagare()

                Case EnumReportes.rptSclListadoSocias
                    ObjReporte = CargarRepListadoSocias()

                    'Case EnumReportes.rptSclActaComiteCredito
                    '    ObjReporte = CargarRepActaComiteCredito()

                    'Case EnumReportes.rptSclReporteComite
                    '    ObjReporte = CargarReporteComiteCredito()

                Case EnumReportes.rptSclTablaAmortizacion
                    ObjReporte = CargarRepTablaAmortizacion()

                Case EnumReportes.rptSclSolicitudesDesembolso
                    ObjReporte = CargarRepSolicitudDesembolso()

                Case EnumReportes.rptSccSolicitudCheque
                    ObjReporte = CargarRepSolicitudCheque()

                    'Agregado Gamaliel 12/03/2008
                Case EnumReportes.rptSclCreditosAprobados
                    RptCreditosAprobados(Me.intSclFormatoID, Me.mtbNumCedula.Text, XcDatosS, "", 1, False)
                    'Fin Agregado       

                Case EnumReportes.rptSclReporteDeCancelacionCredito, EnumReportes.rptSclReporteDeVigenciaCredito

                    RptCancelacionYVigencia(Me.txtCodigo.Text, IIf(Me.NomRep = EnumReportes.rptSclReporteDeCancelacionCredito, True, False), "", 1, False)

            End Select
            ''Agregado Gamaliel 
            If mNomRep <> EnumReportes.rptSclCreditosAprobados And _
               mNomRep <> EnumReportes.rptSclReporteDeCancelacionCredito And _
               mNomRep <> EnumReportes.rptSclReporteDeVigenciaCredito And _
               mNomRep <> EnumReportes.rptSclReporteHistoriaCreditoSocia Then ' Ese reporte se saca con Crystal Report
                '' Fin Agregado    
                If ObjReporte Is Nothing Then
                    MsgBox("No hay datos para mostrar el reporte.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If
                'Si el destino del reporte es Pantalla
                If Me.radPantalla.Checked Then
                    ImprimirEnPantalla(ObjReporte)

                    'Si el destino del reporte es Impresora
                ElseIf Me.RadImpresora.Checked Then
                    ImprimirEnImpresora(ObjReporte, 1, False, "")

                    'Si el destino del reporte es Archivo
                ElseIf Me.RadArchivo.Checked Then
                    ImprimirEnArchivo(ObjReporte)
                End If
                ''Agregado Gamaliel 
            End If
            ''Fin Agregado 

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Reestablezco el cursor
            Me.Cursor = Cursors.Default

            XcDatosS.Close()
            XcDatosS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrea
    ' Fecha:                13/04/2012
    ' Procedure Name:       RptFichaNotificacionCredito
    ' Descripción:          Muestra o imprimi directo a impresora el reporte 
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Public Sub RptFichaNotificacionCredito(ByVal nSclFichaNotificacionID As Int32, ByVal Copias As Integer, ByVal intervalo As Boolean, ByVal simpresora As String, Optional ByVal toprint As Boolean = False)
        Dim strSQL As String
        'Si es Grupo Solidario Usura / Mercados:
        strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                 "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                 "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                 "WHERE (StbValorCatalogo.sCodigoInterno = '1' or StbValorCatalogo.sCodigoInterno = '3') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & nSclFichaNotificacionID & ")"
        '-- SI EL CREDITO ES DE USURA CERO:
        If RegistrosAsociados(strSQL) Then
            ObjReporte = CargarRepFichaNotificacionCredito()
        Else
            ObjReporte = CargarRepFichaNotificacionCredito_FCL()
        End If

        If toprint Then
            ImprimirEnImpresora(ObjReporte, Copias, intervalo, simpresora, Not toprint)
        End If

    End Sub

    Public Sub LlamarRepFichaComiteCredito(ByVal Copias As Integer, ByVal intervalo As Boolean, ByVal simpresora As String)
        ObjReporte = CargarRepFichaComiteCredito()
        ImprimirEnImpresora(ObjReporte, Copias, intervalo, simpresora, False)
    End Sub

    Public Sub RptCreditosAprobados(ByVal nSclSociaID As Int32, ByVal cedula As String, ByRef XcDatosS As BOSistema.Win.XComando, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte
        frmVisor.WindowState = FormWindowState.Maximized
        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
        frmVisor.NombreReporte = "RepSclCS23.rpt"
        frmVisor.Text = "Listado de historial de creditos por socias"
        If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
            frmVisor.SQLQuery = " Select * From vwSclListadoSociasHistorico Where nSclSociaID = " & nSclSociaID
        Else
            frmVisor.SQLQuery = " Select * From vwSclListadoSociasHistorico Where nSclSociaID = " & XcDatosS.ExecuteScalar("SELECT nSclSociaID FROM SclSocia WHERE (sNumeroCedula = '" & cedula & "')")
        End If
        If Not toprint Then
            frmVisor.Show()
        Else
            frmVisor.Imprimir(simpresora, copias, intercalar)
        End If
        'Fin Agregado  
    End Sub

    Public Sub RptCancelacionYVigencia(ByVal codigoFicha As String, ByVal ReporteDeCancelacionCredito As Boolean, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte

        Dim nEstadoCredito As String = IIf(Me.NomRep = EnumReportes.rptSclReporteDeCancelacionCredito, "CANCELADO", "VIGENTE")

        frmVisor.WindowState = FormWindowState.Maximized
        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
        frmVisor.Formulas("Parametros") = "'Parametros: (Código Ficha Crédito = " & codigoFicha & ")'"
        frmVisor.Parametros("@nSclFichaNotificacionCodigo") = Convert.ToInt32(codigoFicha)
        frmVisor.Parametros("@sEstadoCredito") = IIf(ReporteDeCancelacionCredito, "7", "5")
        ''frmVisor.CRVReportes.SelectionFormula = Filtro
        Dim mostrar As Boolean = True
        If ReporteDeCancelacionCredito Then
            Dim xDatos As New BOSistema.Win.XDataSet.xDataTable
            Try
                xDatos.ExecuteSql(String.Format("spScCCConstanciaValida {0}", Convert.ToInt32(codigoFicha)))
                mostrar = Convert.ToBoolean(xDatos.ValueField("Valida"))
            Catch ex As Exception
                Control_Error(ex)
            Finally
                xDatos.Close()
                xDatos = Nothing
            End Try

        End If
        frmVisor.NombreReporte = IIf(ReporteDeCancelacionCredito, "RepSccCC82.rpt", "RepSccCC83.rpt")
        frmVisor.Text = IIf(ReporteDeCancelacionCredito, "Constancia de Cancelación de Crédito", "Constancia de Vigencia de Crédito")
        If mostrar Then
            If Not toprint Then
                frmVisor.Show()
            Else
                frmVisor.Imprimir(simpresora, copias, intercalar)
            End If
        Else
            MsgBox("El Crédito no se encuentra en un estado cancelado." & Chr(13) _
                   + "No se puede imprimir constancia de cancelación.", MsgBoxStyle.Information)
        End If
        
        'frmVisor.Imprimir()

    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/09/2007
    ' Procedure name		   	:	ImprimirEnPantalla
    ' Description			   	:	Permite imprimir en pantalla un reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnPantalla(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        'Declaración de Variables
        Dim ObjVisorReporte As frmVisorReporte

        Try

            ObjVisorReporte = New frmVisorReporte

            'Seteo el text del reporte
            Select Case mNomRep
                Case EnumReportes.rptSclActaDeCompromiso
                    ObjVisorReporte.Text = "Acta de Compromiso de Grupo Solidario"
                Case EnumReportes.rptSclFichaComiteCredito
                    ObjVisorReporte.Text = "Ficha de Comité de Crédito"
                Case EnumReportes.rptSclFichaNotificacionCredito
                    ObjVisorReporte.Text = "Ficha de Notificación de Crédito"
                Case EnumReportes.rptSclPagare
                    ObjVisorReporte.Text = "Pagaré de Grupo Solidario"
                Case EnumReportes.rptSclListadoGrupos
                    ObjVisorReporte.Text = "Listado de Grupos Solidarios"
                Case EnumReportes.rptSclListadoSocias
                    ObjVisorReporte.Text = "Listado de Socias"
                Case EnumReportes.rptSclActaComiteCredito
                    ObjVisorReporte.Text = "Acta de Comité de Crédito"
                Case EnumReportes.rptSclSolicitudesDesembolso
                    ObjVisorReporte.Text = "Solicitudes de Desembolso de Crédito"
                Case EnumReportes.rptSclTablaAmortizacion
                    ObjVisorReporte.Text = "Tablas de Amortización"
                Case EnumReportes.rptSclReporteComite
                    ObjVisorReporte.Text = "Reporte de Comité de Crédito"
                Case EnumReportes.rptSccSolicitudCheque
                    ObjVisorReporte.Text = "Reporte de Solicitud de Cheque"
            End Select

            ObjReporte.Run()
            ObjVisorReporte.VisorReportes.Document = ObjReporte.Document
            ObjVisorReporte.WindowState = FormWindowState.Maximized
            ObjVisorReporte.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/09/2007
    ' Procedure name		   	:	ImprimirEnImpresora
    ' Description			   	:	Permite imprimir en la impresora un reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnImpresora(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3, ByVal Copias As Integer, ByVal intervalo As Boolean, Optional ByVal simpresora As String = "", Optional ByVal searchPrint As Boolean = True)
        Try
            ObjReporte.Run()
            If ObjReporte.Document.Pages.Count > 0 Then
                ' En prueba
                If Not String.IsNullOrEmpty(simpresora) Then
                    ObjReporte.Document.Printer.PrinterName = simpresora
                    ObjReporte.Document.Printer.PrinterSettings.Copies = Copias
                    ObjReporte.Document.Printer.PrinterSettings.Collate = intervalo
                End If
                ' Fin En Prueba
                ObjReporte.Document.Print(searchPrint, True)
                'ObjReporte.Document.Print(True, True)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/09/2007
    ' Procedure name		   	:	ImprimirEnArchivo
    ' Description			   	:	Permite imprimir en archivo un reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnArchivo(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)

        Try
            With Exportar
                .FilterIndex = 1
                .Filter = "PDF|*.pdf|XLS|*.xls|RTF|*.rtf"
                .Title = "Exportar Reporte"
                .InitialDirectory = MyCurrentDocs
                .OverwritePrompt = True
            End With

            If Exportar.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                ObjReporte.Run()
                If ObjReporte.Document.Pages.Count = 0 Then
                    Exit Sub
                End If
            End If

            Select Case Exportar.FilterIndex
                Case 1 'pdf
                    Dim ObjExportPDF As DataDynamics.ActiveReports.Export.Pdf.PdfExport
                    ObjExportPDF = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
                    ObjExportPDF.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato PDF con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 2 'excel
                    Dim ObjExportXLS As DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS = New DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato Excel con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 4 'rtf
                    Dim ObjExportRTF As DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF = New DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato rtf con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 5 'HTML
                    Dim ObjExportHTML As DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML = New DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato HTML con éxito !!!", MsgBoxStyle.Information, NombreSistema)
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    '--------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/09/2007
    ' Procedure Name:       frmSclParametroFNC_FormClosin
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '--------------------------------------------------------------------------
    Private Sub frmSclParametroFNC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing

            xdtEstados.Close()
            xdtEstados = Nothing

            xdtGS.Close()
            xdtGS = Nothing

            xdtOrden.Close()
            xdtOrden = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/09/2007
    ' Procedure Name:       frmSclParametroFNC_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables.
    '-------------------------------------------------------------------------
    Private Sub frmSclParametroFNC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath

            'If mNomRep = EnumReportes.rptSccSolicitudCheque Then
            '    ObjGUI.SetFormLayout(Me, "Verde")
            'Else
            'ObjGUI.SetFormLayout(Me, sColor)
            'End If

            InicializarVariables()
            ObjGUI.SetFormLayout(Me, sColor)

            'En caso de Listados:
            If (mNomRep = EnumReportes.rptSclListadoGrupos) Or (mNomRep = EnumReportes.rptSclListadoSocias) Then
                Select Case mNomRep
                    Case EnumReportes.rptSclListadoGrupos
                        CargarOrdenPor(0)
                        CargarGS(0)
                        CargarEstados()
                    Case EnumReportes.rptSclListadoSocias
                        CargarOrdenPor(1)
                        'CargarGS(1)
                        CargarEstadosSocias()
                        cboOrdenado.Enabled = False
                        cboEstado.Enabled = False
                End Select

                'Si el llamado del Listado es desde una Interfaz
                If eLlamado.Interfaz Then
                    'Se ubica sobre el registro de la interfaz:
                    If cboGS.Visible Then
                        If cboGS.ListCount > 0 Then
                            Me.cboGS.SelectedIndex = 0
                        End If
                        xdtGS.SetCurrentByID("ID", intFormatoID)
                    End If
                End If

            End If

            ''Agregado Gamaliel  
            If mNomRep = EnumReportes.rptSclCreditosAprobados Then
                CargarOrdenPor(1)
                'CargarListaClientes(0)
                cboOrdenado.Enabled = False
                cboEstado.Enabled = False
                grpdestino.Visible = False
                CargarEstadosSocias()
                'Si el llamado del Listado es desde una Interfaz
                If eLlamado.Interfaz Then
                    'Se ubica sobre el registro de la interfaz:
                    If cboGS.Visible Then
                        If cboGS.ListCount > 0 Then
                            Me.cboGS.SelectedIndex = 0
                        End If
                        xdtGS.SetCurrentByID("ID", intFormatoID)
                    End If
                End If
            Else
                cboOrdenado.Enabled = False
                cboEstado.Enabled = False
                grpdestino.Visible = False

            End If
            ''Fin agregado

            If Me.NomRep = 13 Then
                Me.grpdestino.Visible = True
                Me.grpdestino.Enabled = True
            End If

            ''Si 
            ''Ficha de Notificacion de crédito CS4 y Ficha de comite de crédito CS5
            '' habilitar el grupo destino
            If Me.NomRep = 2 Or Me.NomRep = 3 Or Me.NomRep = 9 Then
                Me.grpdestino.Visible = True
                Me.grpdestino.Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub



    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	28/09/2007
    ' Procedure name		   	:	CargarOrdenPor
    ' Description			   	:	Cargar criterios de orden de impresión.
    '                               IntTipo: 0 = Grupos Solidarios; 1 = Socias
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarOrdenPor(ByVal IntTipo As Integer)
        Dim StrSql As String
        Try

            'Limpiar Combo:
            Me.cboOrdenado.ClearFields()
            ''Agregado Gamaliel 
            If mNomRep <> EnumReportes.rptSclCreditosAprobados Then
                ''Fin agregado
                StrSql = " Select 1 As IdOrden ," & _
                         " 'Código' As Orden "
                xdtOrden.ExecuteSql(StrSql)
                'Agregado Gamaliel
            Else
                StrSql = " Select 1 As IdOrden ," & _
                         " 'Cedula' As Orden "
                xdtOrden.ExecuteSql(StrSql)
            End If
            ''Fin de agregado 



            xdtOrden.AddRow()
            xdtOrden("IdOrden") = 2
            xdtOrden("Orden") = "Nombre"
            xdtOrden.UpdateLocal()
            ''Agregado Gamaliel   
            If mNomRep <> EnumReportes.rptSclCreditosAprobados Then
                ''Fin agregado
                If IntTipo = 1 Then
                    xdtOrden.AddRow()
                    xdtOrden("IdOrden") = 3
                    xdtOrden("Orden") = "Cédula"
                    xdtOrden.UpdateLocal()
                End If
                ''Agregado Gamaliel
            End If
            '' Fin agregado 

            Me.cboOrdenado.DataSource = xdtOrden.Source
            Me.cboOrdenado.SelectedIndex = 0

            'Formato del combo de orden
            Me.cboOrdenado.Columns("Orden").Caption = ""
            Me.cboOrdenado.Splits(0).DisplayColumns("IdOrden").Visible = False
            Me.cboOrdenado.Splits(0).DisplayColumns("Orden").Width = 100

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Anexado Gamaliel    
    '-----------------------------------------------------------------------------------------------
    'Autor:                 Gamaliel Mejia
    'Fecha:                 13/03/2008 
    '-----------------------------------------------------------------------------------------------
    'Private Sub CargarListaClientes(ByVal IntTipo As Integer)

    '    Try

    '        'Limpiar Combo:
    '        Me.cboGS.ClearFields()
    '        Dim Strsql As String
    '        If IntTipo = 0 Then
    '            Strsql = " Select a.nSclSociaID as ID, a.sNumeroCedula as sCodigo, a.sNombre1 + ' ' + a.SNombre2 + ' ' + a.sApellido1 + ' ' + a.sApellido2 as sNombre,1 as Orden " & _
    '                     " From SclSocia a " & _
    '                     " Order by a.sNumeroCedula"
    '        Else
    '            Strsql = "Select b.ID ,b.sCodigo AS sCodigo, b.sNombre as sNombre ,b.Orden as Orden From  (Select a.nSclSociaID as ID, a.sNumeroCedula as sCodigo, a.sNombre1 + ' ' + a.SNombre2 + ' ' + a.sApellido1 + ' ' + a.sApellido2 as sNombre,1 as Orden " & _
    '                     " From SclSocia  a ) b " & _
    '                     " Order by b.sNombre "
    '        End If
    '        'Cargar Fuentes de Datos
    '        xdtGS.ExecuteSql(Strsql)
    '        xdtGS.Retrieve()

    '        'Asignando a las fuentes de datos
    '        Me.cboGS.DataSource = Nothing
    '        Me.cboGS.DataSource = xdtGS.Source
    '        'Me.cboGS.DisplayMember = "sNombre"
    '        Me.cboGS.Splits(0).DisplayColumns("ID").Visible = False
    '        Me.cboGS.Splits(0).DisplayColumns("Orden").Visible = False
    '        Me.cboGS.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        'Configurar el combo
    '        Me.cboGS.Splits(0).DisplayColumns("sCodigo").Width = 100
    '        Me.cboGS.Splits(0).DisplayColumns("sNombre").Width = 130

    '        Me.cboGS.Columns("sCodigo").Caption = "Código"
    '        Me.cboGS.Columns("sNombre").Caption = "Nombre"

    '        Me.cboGS.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboGS.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboGS.SelectedIndex = 0
    '        'End If
    '        '' Fin agregado gamaliel
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try



    'End Sub
    ''-Fin anexado Gamaliel

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/09/2007
    ' Procedure Name:       CargarGS
    ' Descripción:          Cargar el listado de Grupos Solidarios (0) o Socias
    '                       del Programa (1) según IntTipo.
    '-------------------------------------------------------------------------
    Private Sub CargarGS(ByVal IntTipo As Integer)
        Try

            'Limpiar Combo:
            Me.cboGS.ClearFields()

            Dim Strsql As String
            If IntTipo = 0 Then
                Strsql = " Select a.nSclGrupoSolidarioID as ID, a.sCodigo, a.sDescripcion as sNombre, 1 as Orden " & _
                         " From SclGrupoSolidario a " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nSclSociaID as ID, a.nCodigo as sCodigo, a.sNombre1 + ' ' + a.SNombre2 + ' ' + a.sApellido1 + ' ' + a.sApellido2 as sNombre,1 as Orden " & _
                         " From SclSocia a " & _
                         " Where a.nSclSociaID = 0  " & _
                         " Order by a.nCodigo"
            End If


            'Cargar Fuentes de Datos
            xdtGS.ExecuteSql(Strsql)
            xdtGS.Retrieve()

            'Asignando a las fuentes de datos
            Me.cboGS.DataSource = xdtGS.Source

            Me.cboGS.Splits(0).DisplayColumns("ID").Visible = False
            Me.cboGS.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboGS.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Configurar el combo
            Me.cboGS.Splits(0).DisplayColumns("sCodigo").Width = 100
            Me.cboGS.Splits(0).DisplayColumns("sNombre").Width = 130

            Me.cboGS.Columns("sCodigo").Caption = "Código"
            Me.cboGS.Columns("sNombre").Caption = "Nombre"

            Me.cboGS.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGS.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'If Me.cboGS.ListCount > 0 Then
            '    xdtGS.AddRow()
            '    If IntTipo = 0 Then
            '        xdtGS.ValueField("sNombre") = "Todos"
            '    Else
            '        xdtGS.ValueField("sNombre") = "Todas"
            '    End If
            '    xdtGS.ValueField("ID") = -19
            '    xdtGS.ValueField("Orden") = 0
            '    xdtGS.UpdateLocal()
            '    xdtGS.Sort = "Orden,sCodigo asc"
            '    Me.cboGS.SelectedIndex = 0
            'End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/09/2007
    ' Procedure Name:       CargarEstados
    ' Descripción:          Cargar el listado de posibles estados de Grupos 
    '                       Solidarios.
    '-------------------------------------------------------------------------
    Private Sub CargarEstados()
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboEstado.ClearFields()

            Strsql = " SELECT  a.nStbValorCatalogoID, a.sDescripcion As Estado, 1 as Orden " & _
                     " FROM  StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'EstadoGrupo') ORDER BY a.nStbValorCatalogoID"

            'Cargar Fuentes de Datos
            xdtEstados.ExecuteSql(Strsql)
            xdtEstados.Retrieve()

            'Asignando a las fuentes de datos
            Me.cboEstado.DataSource = xdtEstados.Source

            Me.cboEstado.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Orden").Visible = False

            'Configurar el combo
            Me.cboEstado.Splits(0).DisplayColumns("Estado").Width = 130
            Me.cboEstado.Columns("Estado").Caption = "Estado"
            Me.cboEstado.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboEstado.ListCount > 0 Then
                xdtEstados.AddRow()
                xdtEstados.ValueField("Estado") = "Todos"
                xdtEstados.ValueField("nStbValorCatalogoID") = -19
                xdtEstados.ValueField("Orden") = 0
                xdtEstados.UpdateLocal()
                xdtEstados.Sort = "Orden,nStbValorCatalogoID asc"
                Me.cboEstado.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/09/2007
    ' Procedure name		   	:	CargarEstadosSocias
    ' Description			   	:	Cargar los estados de Socias.
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarEstadosSocias()

        'Declaracion de Variables
        Dim Strsql As String
        Try

            'Limpiar Combo:
            Me.cboEstado.ClearFields()

            'Inserta el Registro Todas:
            Strsql = ""
            Strsql = "Select -19        As IdEstado, " & _
                     "      'Todas'     As Estado, " & _
                     "        0         As Orden "

            xdtEstados.ExecuteSql(Strsql)
            xdtEstados.AddRow()
            xdtEstados("IdEstado") = 1
            xdtEstados("Estado") = "Activa"
            xdtEstados("Orden") = 1
            xdtEstados.UpdateLocal()
            '--------------------------------

            xdtEstados.AddRow()
            xdtEstados("IdEstado") = 0
            xdtEstados("Estado") = "Inactiva"
            xdtEstados("Orden") = 2
            xdtEstados.UpdateLocal()
            '--------------------------------

            'Asignando la fuente de datos
            Me.cboEstado.DataSource = xdtEstados.Source

            'Formateando el Combo
            Me.cboEstado.Splits(0).DisplayColumns("IdEstado").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboEstado.Columns("Estado").Caption = ""

            'Inicializar el combo en el primer elemento (TODAS):
            If xdtEstados.Count > 0 Then
                Me.cboEstado.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	28/09/2007
    ' Procedure name		   	:	ValidarParametros
    ' Description			   	:	Esta Funcion permite validar parámetros de Listados.
    ' -----------------------------------------------------------------------------------------
    Private Function ValidarParametros() As Boolean
        Try

            ValidarParametros = True
            Me.errParametro.Clear()
            Dim StrSql As String

            'Grupo:
            If mNomRep = EnumReportes.rptSclListadoGrupos Then
                If Me.cboGS.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Código válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboGS, "Debe seleccionar un Código válido.")
                    Me.cboGS.Focus()
                    ValidarParametros = False
                    Exit Function
                End If
            Else 'Socias y Datos Socias
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                    Me.mtbNumCedula.Focus()
                    ValidarParametros = False
                    Exit Function
                End If
                'Cedula Socia debe existir:
                StrSql = "SELECT nSclSociaID FROM  SclSocia WHERE (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("No existe socia con este Número de Cédula.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.mtbNumCedula, "No existe socia con este Número de Cédula.")
                    Me.mtbNumCedula.Focus()
                    ValidarParametros = False
                    Exit Function
                End If
                'Si la Cedula esta activa y se indico codigo: "999-999999-9999Z"
                If Me.mtbNumCedula.Enabled = True Then
                    If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
                        MsgBox("Cédula Inválida.", MsgBoxStyle.Critical, NombreSistema)
                        Me.errParametro.SetError(Me.mtbNumCedula, "Cédula Inválida.")
                        Me.mtbNumCedula.Focus()
                        ValidarParametros = False
                        Exit Function
                    End If
                End If

            End If

            'Estado:
            If Me.cboEstado.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Estado válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboEstado, "Debe seleccionar un Estado válido.")
                Me.cboEstado.Focus()
                ValidarParametros = False
                Exit Function
            End If

            'Criterio Orden:
            If Me.cboOrdenado.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Criterio de Ordenamiento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboOrdenado, "Debe seleccionar un Criterio de Ordenamiento.")
                Me.cboOrdenado.Focus()
                ValidarParametros = False
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/09/2007
    ' Procedure name		   	:	CargarRepActaCompromiso
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Acta de Compromiso de un Grupo Solidario.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepActaCompromiso() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclActaCompromiso As rptSclActaCompromiso
        Try

            ObjRptSclActaCompromiso = New rptSclActaCompromiso
            'Datos del Grupo Solidario:
            ObjRptSclActaCompromiso.IdGrupo = Me.intFormatoID
            ObjRptSclActaCompromiso.CodigoGrupo = Me.StrCodigo
            ObjRptSclActaCompromiso.NombreGrupo = Me.StrNombre
            ObjRptSclActaCompromiso.Estado = Me.StrEstado

            Return ObjRptSclActaCompromiso

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	28/09/2007
    ' Procedure name		   	:	CargarRepListadoGrupos
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Listado de Grupos Solidarios.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepListadoGrupos() As DataDynamics.ActiveReports.ActiveReport3
        'Declaracion de Variables
        Dim ObjRptSclListadoGrupos As rptSclLstGrupoSolidario
        Try

            ObjRptSclListadoGrupos = New rptSclLstGrupoSolidario
            'Datos de la Socia:
            If Me.cboGS.Text = "Todos" Then
                ObjRptSclListadoGrupos.IdGrupo = 0
                ObjRptSclListadoGrupos.NombreGrupo = ""
            Else
                ObjRptSclListadoGrupos.IdGrupo = cboGS.Columns("ID").Value   'Me.intFormatoID
                ObjRptSclListadoGrupos.NombreGrupo = cboGS.Columns("sNombre").Value  'Me.StrNombre
            End If
            ObjRptSclListadoGrupos.IdOrdenamiento = Me.cboOrdenado.Columns("IdOrden").Value
            ObjRptSclListadoGrupos.IdEstado = Me.cboEstado.Columns("nStbValorCatalogoID").Value
            ObjRptSclListadoGrupos.Estado = Me.cboEstado.Columns("Estado").Value
            ''Gamaliel Temporalmente modificado
            ObjRptSclListadoGrupos.IdDelegacion = intSccTipoID
            '' Fin 

            Return ObjRptSclListadoGrupos

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	01/10/2007
    ' Procedure name		   	:	CargarRepListadoSocias
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Listado de Socias.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepListadoSocias() As DataDynamics.ActiveReports.ActiveReport3
        'Declaracion de Variables
        Dim ObjRptSclListadoSocias As rptSclLstSocias
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            ObjRptSclListadoSocias = New rptSclLstSocias
            'Datos de la Socia:
            'If Me.cboGS.Text = "Todas" Then
            '    ObjRptSclListadoSocias.IdSocia = 0
            '    ObjRptSclListadoSocias.NombreSocia = ""
            'Else
            If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
                ObjRptSclListadoSocias.IdSocia = intSclFormatoID
            Else
                ObjRptSclListadoSocias.IdSocia = XcDatos.ExecuteScalar("SELECT nSclSociaID FROM SclSocia WHERE (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')")
            End If
            REM ObjRptSclListadoSocias.NombreSocia = cboGS.Columns("sNombre").Value  'Me.StrNombre
            'End If
            ObjRptSclListadoSocias.IdOrdenamiento = Me.cboOrdenado.Columns("IdOrden").Value
            ObjRptSclListadoSocias.IdEstado = Me.cboEstado.Columns("IdEstado").Value
            ObjRptSclListadoSocias.Estado = Me.cboEstado.Columns("Estado").Value
            ''Gamaliel Temporalmente Modificado
            ObjRptSclListadoSocias.IdDelegacion = intSccTipoID
            ''Fin Modificacion
            Return ObjRptSclListadoSocias

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	11/10/2007
    ' Procedure name		   	:	CargarRepActaComiteCredito
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Acta de Comité de Crédito.
    ' -----------------------------------------------------------------------------------------
    'Private Function CargarRepActaComiteCredito() As DataDynamics.ActiveReports.ActiveReport3
    'Declaracion de Variables
    'Dim ObjRptSclActaComite As rptSclActaComiteCredito
    'Try

    '    ObjRptSclActaComite = New rptSclActaComiteCredito
    '    'Datos de la Ficha de Comité de Crédito:
    '    ObjRptSclActaComite.CodigoSesion = Me.StrCodigo 'No. Sesión de la FNC actual.
    '    Return ObjRptSclActaComite

    'Catch ex As Exception
    '    Control_Error(ex)
    '    Return Nothing
    'End Try
    'End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	19/10/2007
    ' Procedure name		   	:	CargarReporteComiteCredito
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Comité de Crédito por No. Sesión.
    ' -----------------------------------------------------------------------------------------
    'Private Function CargarReporteComiteCredito() As DataDynamics.ActiveReports.ActiveReport3
    '    'Declaracion de Variables
    '    Dim ObjRptSclReporteComite As rptSclReporteComiteCredito
    '    Try

    '        ObjRptSclReporteComite = New rptSclReporteComiteCredito
    '        'Datos de la Ficha de Comité de Crédito:
    '        ObjRptSclReporteComite.CodigoSesion = Me.StrCodigo
    '        Return ObjRptSclReporteComite

    '    Catch ex As Exception
    '        Control_Error(ex)
    '        Return Nothing
    '    End Try
    'End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	11/10/2007
    ' Procedure name		   	:	CargarRepTablaAmortizacion
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Acta de Comité de Crédito.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepTablaAmortizacion() As DataDynamics.ActiveReports.ActiveReport3
        'Declaracion de Variables
        Dim ObjRptSclTablaAmortizacion As rptSclTablaAmortizacion
        Try

            ObjRptSclTablaAmortizacion = New rptSclTablaAmortizacion
            'Datos de la Ficha de Comité de Crédito:
            ObjRptSclTablaAmortizacion.IdFichaNotificacion = Me.intSclFormatoID 'No. Sesión de la FNC actual.
            Return ObjRptSclTablaAmortizacion

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	04/09/2007
    ' Procedure name		   	:	CargarRepFichaComiteCredito
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Ficha de Comité de Crédito.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepFichaComiteCredito() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclFichaComite As rptSclFichaComiteCredito
        Try

            ObjRptSclFichaComite = New rptSclFichaComiteCredito
            'Datos de la Ficha de Comité de Crédito:
            ObjRptSclFichaComite.IdFicha = Me.intFormatoID
            ObjRptSclFichaComite.CodigoFicha = Me.StrCodigo
            ObjRptSclFichaComite.NombreGrupo = Me.StrNombre 'Código y Nombre del GS
            'ObjRptSclFichaComite.Estado = Me.StrEstado
            ObjRptSclFichaComite.Estado = Me.StrCodEstado

            Return ObjRptSclFichaComite

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	19/10/2007
    ' Procedure name		   	:	CargarRepSolicitudDesembolso
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Solicitudes de Desembolso de Crédito.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepSolicitudDesembolso() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclSolicitudDesembolso As rptSclSolicitudDesembolso
        Try

            ObjRptSclSolicitudDesembolso = New rptSclSolicitudDesembolso
            'Datos de la Ficha de Comité de Crédito:
            ObjRptSclSolicitudDesembolso.IdFichaNotificacion = Me.intSclFormatoID
            ObjRptSclSolicitudDesembolso.Estado = Me.StrCodEstado

            Return ObjRptSclSolicitudDesembolso

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    Public Sub RepCargarRepSolicitudDesembolso(ByVal Copias As Integer, ByVal intercalar As Boolean, ByVal simpresora As String)
        Me.ObjReporte = CargarRepSolicitudDesembolso()
        Me.ImprimirEnImpresora(ObjReporte, Copias, intercalar, simpresora, False)
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	19/10/2007
    ' Procedure name		   	:	CargarRepSolicitudCheque
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Solicitudes de Cheques.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepSolicitudCheque() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSccSolicitudCheque As rptSccSolicitudCheque
        Try

            ObjRptSccSolicitudCheque = New rptSccSolicitudCheque
            'Datos de la Ficha de Comité de Crédito:
            ObjRptSccSolicitudCheque.IdFormato = Me.intSclFormatoID
            ObjRptSccSolicitudCheque.Estado = Me.StrCodEstado
            ObjRptSccSolicitudCheque.IdTipo = Me.intSccTipoID

            Return ObjRptSccSolicitudCheque

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	02/10/2007
    ' Procedure name		   	:	CargarRepFichaNotificacionCredito
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Ficha de Notificación de Crédito.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepFichaNotificacionCredito() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclFichaNotificacion As rptSclFichaNotificacionCredito
        Try

            ObjRptSclFichaNotificacion = New rptSclFichaNotificacionCredito
            'Datos de la Ficha de Notificación de Crédito:
            ObjRptSclFichaNotificacion.IdFicha = Me.intFormatoID
            ObjRptSclFichaNotificacion.CodigoFicha = Me.StrCodigo
            ObjRptSclFichaNotificacion.NombreGrupo = Me.StrNombre 'Código y Nombre del GS
            'ObjRptSclFichaNotificacion.Estado = Me.StrEstado
            ObjRptSclFichaNotificacion.Estado = Me.StrCodEstado

            Return ObjRptSclFichaNotificacion

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	09/11/2009
    ' Procedure name		   	:	CargarRepFichaNotificacionCredito_FCL
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Ficha de Notificación de Crédito.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepFichaNotificacionCredito_FCL() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclFichaNotificacion As rptSclFichaNotificacionCredito_FCL
        Try

            ObjRptSclFichaNotificacion = New rptSclFichaNotificacionCredito_FCL
            'Datos de la Ficha de Notificación de Crédito:
            ObjRptSclFichaNotificacion.IdFicha = Me.intFormatoID
            ObjRptSclFichaNotificacion.CodigoFicha = Me.StrCodigo
            ObjRptSclFichaNotificacion.NombreGrupo = Me.StrNombre 'Código y Nombre del GS
            'ObjRptSclFichaNotificacion.Estado = Me.StrEstado
            ObjRptSclFichaNotificacion.Estado = Me.StrCodEstado

            Return ObjRptSclFichaNotificacion

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	03/10/2007
    ' Procedure name		   	:	CargarRepPagare
    ' Description			   	:	Esta Funcion permite generar el Pagaré de un 
    '                           :   Grupo Solidario.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepPagare() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclPagare As rptSclPagare
        Try

            ObjRptSclPagare = New rptSclPagare
            'Datos de la Ficha de Notificación de Crédito:
            ObjRptSclPagare.IdFicha = Me.intFormatoID
            ObjRptSclPagare.CodigoFicha = Me.StrCodigo
            ObjRptSclPagare.NombreGrupo = Me.StrNombre 'Código y Nombre del GS
            'ObjRptSclPagare.Estado = Me.StrEstado
            ObjRptSclPagare.Estado = Me.StrCodEstado

            Return ObjRptSclPagare

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    Private Sub cboGS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGS.TextChanged
        'Agregado Gamaliel  'No existe Todas o Todos en esta opcion
        If mNomRep = EnumReportes.rptSclCreditosAprobados Then Exit Sub
        ''Fin agregado   
        If Me.cboGS.Text = "Todas" Or Me.cboGS.Text = "Todos" Then
            cboOrdenado.Enabled = True
            cboEstado.Enabled = True
        Else
            cboOrdenado.Enabled = False
            cboEstado.Enabled = False
        End If
    End Sub

    'Private Sub cboOrdenado_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOrdenado.TextChanged
    '    'Anexada Gamaliel para la busqueda por Nombre o por Cedula
    '    If mNomRep = EnumReportes.rptSclCreditosAprobados Then
    '        Select Case cboOrdenado.SelectedIndex
    '            Case 0
    '                CargarListaClientes(0)
    '                Me.cboGS.DisplayMember = "sCodigo"
    '                Me.cboGS.Text = Me.cboGS.Columns("sCodigo").Value
    '                lblCodRpt.Text = "Cedula Socia:"

    '            Case 1
    '                CargarListaClientes(1)
    '                Me.cboGS.DisplayMember = "sNombre"
    '                Me.cboGS.Text = Me.cboGS.Columns("sNombre").Value
    '                lblCodRpt.Text = "Nombre Socia:"
    '        End Select
    '    End If
    '    ''Fin Anexado
    'End Sub
End Class