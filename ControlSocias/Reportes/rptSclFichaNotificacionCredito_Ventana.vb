'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                02/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSclFichaNotificacionCredito_FCL.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Ficha de Notificación de Crédito.		     
'----------------------------------------------------------------------------
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclFichaNotificacionCredito_Ventana

    Dim StrPath As String
    'Declaracion de Variables
    Dim objEncabeza As rptEncabezadoV
    Dim objEncabezaFCL As rptEncabezadoV_FCL
    Dim objEncabezaPD As rptEncabezadoV_PD

    Dim xdtFormato As BOSistema.Win.XDataSet.xDataTable

    'Datos del Grupo Solidario
    Dim mIdFicha As Long
    Dim mCodigoFicha As String
    Dim mNombreGrupo As String 'Código y Nombre.
    Dim mEstado As String
    Dim intTipoPrograma As Integer

    'Parámetros:
    Dim StrUnidadNotificadora As String
    Dim StrUbicacionDelegacion As String
    Dim StrDireccion As String
    Dim StrPBX As String
    Dim StrPlazo As String
    Dim StrCodigoE As String

    'Descripción del Estado de la FNC.
    Public Property Estado() As String
        Get
            Estado = mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property

    'Descripción del Grupo (Código y Nombre) de la FNC
    Public Property NombreGrupo() As String
        Get
            NombreGrupo = mNombreGrupo
        End Get
        Set(ByVal value As String)
            mNombreGrupo = value
        End Set
    End Property

    'ID de la Ficha de Notificación:
    Public Property IdFicha() As Long
        Get
            IdFicha = mIdFicha
        End Get
        Set(ByVal value As Long)
            mIdFicha = value
        End Set
    End Property

    'Descripción del Grupo Solidario para los Parámetros:
    Public Property CodigoFicha() As String
        Get
            CodigoFicha = mCodigoFicha
        End Get
        Set(ByVal value As String)
            mCodigoFicha = value
        End Set
    End Property

    'Descripción del Grupo Solidario para los Parámetros:
    Public Property TipoPrograma() As Integer
        Get
            TipoPrograma = intTipoPrograma
        End Get
        Set(ByVal value As Integer)
            intTipoPrograma = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/10/2007
    ' Procedure Name:       PageHeader1_Format
    ' Descripción:          Permite asignar Formato del PageHeader.
    '-------------------------------------------------------------------------
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            '-- Indica Parámetros:
            Me.txtparametro1.Text = "Código Ficha: " & Me.mCodigoFicha & ". Estado Ficha: " & Me.mEstado
            Me.txtparametro2.Text = "Grupo Solidario: " & mNombreGrupo

            'Ficha Anulada o Ficha Anulada con Regeneración:
            If (Me.mEstado = "4") Or (Me.mEstado = "5") Then
                Me.lblAnulada.Visible = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/10/2007
    ' Procedure Name:       EncabezadoReporte_Format
    ' Descripción:          Asigna Sub-reporte para Encabezado.
    '-------------------------------------------------------------------------
    Private Sub EncabezadoReporte_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            objEncabeza = New rptEncabezadoV
            Me.SubReporte.Report = objEncabeza

            objEncabezaFCL = New rptEncabezadoV_FCL
            Me.SubReporteFCL.Report = objEncabezaFCL

            objEncabezaPD = New rptEncabezadoV_PD
            Me.SubReport1.Report = objEncabezaPD

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	02/10/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Permite inicializar los objetos. 
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            xdtFormato = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	02/10/2007
    ' Procedure name		   	:	CargarFichaNotificacion
    ' Description			   	:	Cargar los datos del Acta de Compromiso del Grupo Solidario.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarFichaNotificacion()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables: 
            Strsql = ""
            Strsql = " Select row_number() OVER (ORDER BY nCoordinador DESC, nSclFichaSociaId) AS Item, " & _
                     "        nSclFichaNotificacionID, nCoordinador, " & _
                     "        nCodigo, " & _
                     "        NombreGrupo, " & _
                     "        NombreSocia," & _
                     "        CedulaSocia, " & _
                     "        NombreCoordinadora, " & _
                     "        Departamento, " & _
                     "        Municipio, " & _
                     "        Distrito, " & _
                     "        Barrio, " & _
                     "        Mercado, " & _
                     "        FechaEntregaCK, " & _
                     "        HoraEntregaCK, " & _
                     "        CedulaCoordinadora, " & _
                     "        DireccionCoordinadora, " & _
                     "        TelefonoCoordinadora, " & _
                     "        sNumSesion, " & _
                     "        dFechaNotificacion, " & _
                     "        LugarEntregaCK, " & _
                     "        sHorarioEntregaPagos, " & _
                     "        DiaPagos, " & _
                     "        sObservacion, " & _
                     "        nMontoCreditoAprobado, " & _
                     "        nPlazoAprobado, " & _
                     "        TipoPlazo, " & _
                     "        sCodigoInterno, " & _
                     "        LugarPagos, " & _
                     "        nSclFichaSociaId, nTotalPeriodoGracia " & _
                     " From vwSclFichaNotificacionRep " & _
                     " WHERE  (nSclFichaNotificacionID = " & mIdFicha & ") " & _
                     " GROUP BY nSclFichaNotificacionID, nCoordinador, nCodigo, NombreGrupo, NombreSocia, " & _
                     " CedulaSocia, NombreCoordinadora, Departamento, Municipio, Distrito, Barrio, Mercado, " & _
                     " FechaEntregaCK, HoraEntregaCK, CedulaCoordinadora, DireccionCoordinadora, TelefonoCoordinadora, sNumSesion, dFechaNotificacion, " & _
                     " LugarEntregaCK, sHorarioEntregaPagos, DiaPagos, sObservacion, nMontoCreditoAprobado, nPlazoAprobado, TipoPlazo, sCodigoInterno, LugarPagos, nSclFichaSociaId, nTotalPeriodoGracia " & _
                     " Order by nCoordinador DESC, nSclFichaSociaId "
            '(nCreditoRechazado = 0) And
            xdtFormato.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	02/10/2007
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            StrCodigoE = "0"

            '-- Verifica Datos Delegación: Enlace del DepartamentoId entre Grupo Solidario y Delegación:
            Strsql = "SELECT a.sDireccionUbicacion " & _
                     "FROM  SclGrupoSolidario AS GS INNER JOIN SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica AS UG ON GS.nStbBarrioVerificadoID = UG.nStbBarrioID " & _
                     "INNER JOIN (SELECT StbMunicipio.nStbDepartamentoID, StbDelegacionPrograma.sDireccionUbicacion, StbDelegacionPrograma.sNombreUnidadNotificadora, StbDelegacionPrograma.sUbicacionDelegacion, StbDelegacionPrograma.sTelefonoUbicacion " & _
                     "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID) AS a ON UG.nStbDepartamentoID = a.nStbDepartamentoID " & _
                     "WHERE (FNC.nSclFichaNotificacionID = " & mIdFicha & ")"
            If RegistrosAsociados(Strsql) Then
                'Dirección del Programa:
                StrDireccion = XcDatos.ExecuteScalar(Strsql)

                'Unidad Notificadora del Programa: 
                Strsql = "SELECT a.sNombreUnidadNotificadora " & _
                         "FROM  SclGrupoSolidario AS GS INNER JOIN SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica AS UG ON GS.nStbBarrioVerificadoID = UG.nStbBarrioID " & _
                         "INNER JOIN (SELECT StbMunicipio.nStbDepartamentoID, StbDelegacionPrograma.sDireccionUbicacion, StbDelegacionPrograma.sNombreUnidadNotificadora, StbDelegacionPrograma.sUbicacionDelegacion, StbDelegacionPrograma.sTelefonoUbicacion " & _
                         "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID) AS a ON UG.nStbDepartamentoID = a.nStbDepartamentoID " & _
                         "WHERE (FNC.nSclFichaNotificacionID = " & mIdFicha & ")"
                StrUnidadNotificadora = XcDatos.ExecuteScalar(Strsql)

                'Ubicación Delegación: 
                Strsql = "SELECT a.sUbicacionDelegacion " & _
                         "FROM  SclGrupoSolidario AS GS INNER JOIN SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica AS UG ON GS.nStbBarrioVerificadoID = UG.nStbBarrioID " & _
                         "INNER JOIN (SELECT StbMunicipio.nStbDepartamentoID, StbDelegacionPrograma.sDireccionUbicacion, StbDelegacionPrograma.sNombreUnidadNotificadora, StbDelegacionPrograma.sUbicacionDelegacion, StbDelegacionPrograma.sTelefonoUbicacion " & _
                         "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID) AS a ON UG.nStbDepartamentoID = a.nStbDepartamentoID " & _
                         "WHERE (FNC.nSclFichaNotificacionID = " & mIdFicha & ")"
                StrUbicacionDelegacion = XcDatos.ExecuteScalar(Strsql)

                'PBX del Programa:
                'Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 21)"
                Strsql = "SELECT a.sTelefonoUbicacion " & _
                         "FROM  SclGrupoSolidario AS GS INNER JOIN SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica AS UG ON GS.nStbBarrioVerificadoID = UG.nStbBarrioID " & _
                         "INNER JOIN (SELECT StbMunicipio.nStbDepartamentoID, StbDelegacionPrograma.sDireccionUbicacion, StbDelegacionPrograma.sNombreUnidadNotificadora, StbDelegacionPrograma.sUbicacionDelegacion, StbDelegacionPrograma.sTelefonoUbicacion " & _
                         "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID) AS a ON UG.nStbDepartamentoID = a.nStbDepartamentoID " & _
                         "WHERE (FNC.nSclFichaNotificacionID = " & mIdFicha & ")"
                If Len(XcDatos.ExecuteScalar(Strsql)) > 0 Then
                    StrPBX = "PBX: " & XcDatos.ExecuteScalar(Strsql)
                Else
                    StrPBX = " "
                End If

                'Código Empleado: 
                Strsql = "SELECT a.sCodigo " & _
                         "FROM  SclGrupoSolidario AS GS INNER JOIN SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica AS UG ON GS.nStbBarrioVerificadoID = UG.nStbBarrioID INNER JOIN " & _
                         "(SELECT StbMunicipio.nStbDepartamentoID, SrhEmpleado.sCodigo FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                         "INNER JOIN SrhEmpleado ON StbDelegacionPrograma.nSrhEmpleadoNotificaSociasID = SrhEmpleado.nSrhEmpleadoID) AS a ON UG.nStbDepartamentoID = a.nStbDepartamentoID " & _
                         "WHERE (FNC.nSclFichaNotificacionID = " & mIdFicha & ")"
                StrCodigoE = XcDatos.ExecuteScalar(Strsql)
                REM StrCodigoE = "0262"

            End If

            'Plazo predeterminado para Créditos:
            Strsql = "SELECT a.sDescripcion FROM StbValorParametro b INNER JOIN StbValorCatalogo a ON b.sValorParametro = a.nStbValorCatalogoID WHERE  (b.nStbParametroID = 5)"
            StrPlazo = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub rptSclFichaNotificacionCredito_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            xdtFormato.Close()
            xdtFormato = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	02/10/2007
    ' Procedure name		   	:	rptSclActaCompromiso_ReportStart
    ' Description			   	:	Inicialización del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub rptSclFichaNotificacionCredito_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try

            Dim StrEstado As String
            Dim strSQL As String
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            'Establece tamaño de papel legal:
            Me.PageSettings.PaperKind = Printing.PaperKind.Legal

            CargarFichaNotificacion()

            If xdtFormato.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtFormato.Table

            If xdtFormato.ValueField("sCodigoInterno") = "2" Then
                StrEstado = "APROBO"
            Else
                StrEstado = "DENEGO"
            End If

            'Si es Grupo Solidario Usura:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & Me.mIdFicha & ")"
            '-- SI EL CREDITO ES DE USURA CERO:
            If RegistrosAsociados(strSQL) Then
                Me.SubReporteFCL.Visible = False
                lblPrograma.Text = "PROGRAMA USURA CERO"
                'Text Encabezado:
                lblEncabezado.Text = "Por medio de la presente me permito informar que el Comité de Crédito del " & _
                                     "Programa Usura Cero, en sesión No. " & xdtFormato.ValueField("sNumSesion") & " efectuada el " & _
                                     Format(xdtFormato.ValueField("dFechaNotificacion"), "dd' del mes de 'MMMM' del año 'yyyy") & _
                                     " " & StrEstado & " el Crédito solicitado por su Grupo Solidario a continuación detallado:"
                lblPie1.Text = "Les agradecemos a todas la confianza en el Programa Usura Cero y les deseamos éxito en el Plan de Negocios que estarán realizando."
                'Texto Pie:
                strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                         "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                         "WHERE (SclTipodePlandeNegocio.nCodigo = 5) AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & Me.mIdFicha & ")"
                If RegistrosAsociados(strSQL) Then 'Mercados Pago Diario
                    If StrEstado = "APROBO" Then
                        lblPie.Text = "En caso de aprobado, favor presentarse el día " & xdtFormato.ValueField("FechaEntregaCK") & ", a las " & xdtFormato.ValueField("HoraEntregaCK") & ", en el " & xdtFormato.ValueField("LugarEntregaCK") & " con " & _
                                      "todas las integrantes del Grupo Solidario para el retiro del efectivo, firma del pagaré correspondiente y segunda capacitación " & _
                                      "(TODAS DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
                                      "Las cuotas deberán ser canceladas en " & xdtFormato.ValueField("LugarPagos") & " de " & xdtFormato.ValueField("sHorarioEntregaPagos") & " de lunes a viernes de cada semana."
                    Else
                        lblPie.Text = "En caso de aprobado, favor presentarse el día        , a las         , en el          con todas las integrantes del " & _
                                      "Grupo Solidario para el retiro del efectivo, firma del pagaré correspondiente y segunda capacitación " & _
                                      "(TODAS DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
                                      "Las cuotas deberán ser canceladas en          de                 los días          de cada semana."
                    End If
                Else
                    If StrEstado = "APROBO" Then
                        lblPie.Text = "En caso de aprobado, favor presentarse el día " & xdtFormato.ValueField("FechaEntregaCK") & ", a las " & xdtFormato.ValueField("HoraEntregaCK") & ", en el " & xdtFormato.ValueField("LugarEntregaCK") & " con " & _
                                      "todas las integrantes del Grupo Solidario para el retiro de los cheques, firma del pagaré correspondiente y segunda capacitación " & _
                                      "(TODAS DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
                                      "Las cuotas deberán ser canceladas en " & xdtFormato.ValueField("LugarPagos") & " de " & xdtFormato.ValueField("sHorarioEntregaPagos") & " los días " & xdtFormato.ValueField("DiaPagos") & " de cada semana."
                    Else
                        lblPie.Text = "En caso de aprobado, favor presentarse el día        , a las         , en el          con todas las integrantes del " & _
                                      "Grupo Solidario para el retiro de los cheques, firma del pagaré correspondiente y segunda capacitación " & _
                                      "(TODAS DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
                                      "Las cuotas deberán ser canceladas en          de                 los días          de cada semana."
                    End If
                End If

            Else
                Me.SubReporte.Visible = False
                lblPrograma.Text = "PROGRAMA CONJUNTO DE GENERO - INPYME"
                'Text Encabezado: 
                lblEncabezado.Text = "Por medio de la presente me permito informar que el Comité de Crédito del " & _
                                         "Fondo de Crédito Local (FCL-ME), en sesión No. " & xdtFormato.ValueField("sNumSesion") & " efectuada el " & _
                                         Format(xdtFormato.ValueField("dFechaNotificacion"), "dd' del mes de 'MMMM' del año 'yyyy") & _
                                         " " & StrEstado & " el Crédito solicitado por su Grupo Solidario a continuación detallado:"
                lblPie.Text = "En caso de aprobado, favor presentarse el día " & xdtFormato.ValueField("FechaEntregaCK") & ", a las " & xdtFormato.ValueField("HoraEntregaCK") & ", en el " & xdtFormato.ValueField("LugarEntregaCK") & " con " & _
                              "todas las integrantes del Grupo Solidario para el retiro de los cheques y firma del pagaré correspondiente " & _
                              "(TODAS DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
                              "Las cuotas deberán ser canceladas en " & xdtFormato.ValueField("LugarPagos") & " de " & xdtFormato.ValueField("sHorarioEntregaPagos") & " los días " & Microsoft.VisualBasic.DateAndTime.Day(xdtFormato.ValueField("FechaEntregaCK")) & " de cada mes."
                lblPie1.Text = "Les agradecemos a todas la confianza en el Fondo de Crédito Local (FCL-ME) y les deseamos éxito en el Plan de Negocios que estarán realizando."
            End If

            ''Texto Pie:
            'If StrEstado = "APROBO" Then
            '    lblPie.Text = "En caso de aprobado, favor presentarse el día " & xdtFormato.ValueField("FechaEntregaCK") & ", a las " & xdtFormato.ValueField("HoraEntregaCK") & ", en el " & xdtFormato.ValueField("LugarEntregaCK") & " con " & _
            '                  "todas las integrantes del Grupo Solidario para el retiro de los cheques y firma del pagaré correspondiente " & _
            '                  "(TODAS DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
            '                  "Las cuotas deberán ser canceladas en " & xdtFormato.ValueField("LugarPagos") & " de " & xdtFormato.ValueField("sHorarioEntregaPagos") & " los días " & Microsoft.VisualBasic.DateAndTime.Day(xdtFormato.ValueField("FechaEntregaCK")) & " de cada mes."
            'Else
            '    lblPie.Text = "En caso de aprobado, favor presentarse el día        , a las         , en el          con todas las integrantes del " & _
            '                  "Grupo Solidario para el retiro de los cheques y firma del pagaré correspondiente " & _
            '                  "(TODAS DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
            '                  "Las cuotas deberán ser canceladas en          de                 los días          de cada mes."
            'End If

            If TipoPrograma = 3 Then
                SubReport1.Visible = True
                SubReporte.Visible = False
                SubReporteFCL.Visible = False
                lblPrograma.Text = "Programa PDIBA"

                lblEncabezado.Text = "Por medio de la presente me permito informar que el Comité de Crédito del " & _
                                     "Programa PDIBA, en sesión No. " & xdtFormato.ValueField("sNumSesion") & " efectuada el " & _
                                     Format(xdtFormato.ValueField("dFechaNotificacion"), "dd' del mes de 'MMMM' del año 'yyyy") & _
                                     " " & StrEstado & " el Crédito solicitado por su Grupo Solidario a continuación detallado:"
                lblPie1.Text = "Les agradecemos a todas la confianza en el Programa PDIBA y les deseamos éxito en el Plan de Negocios que estarán realizando."
                lblCoordinadora.Text = "Señor(a):"
                lblNombreGS.Text = "Coordinador(a) Grupo Solidario:"

                If StrEstado = "APROBO" Then
                    lblPie.Text = "En caso de aprobado, favor presentarse el día " & xdtFormato.ValueField("FechaEntregaCK") & ", a las " & xdtFormato.ValueField("HoraEntregaCK") & ", en el " & xdtFormato.ValueField("LugarEntregaCK") & " con " & _
                                  "todo(a)s lo(a)s integrantes del Grupo Solidario para el retiro de los cheques y firma del pagaré correspondiente " & _
                                  "(TODO(A)S DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
                                  "Las cuotas deberán ser canceladas en " & xdtFormato.ValueField("LugarPagos") & " de " & xdtFormato.ValueField("sHorarioEntregaPagos") & " los días " & Microsoft.VisualBasic.DateAndTime.Day(xdtFormato.ValueField("FechaEntregaCK")) & " de cada mes."
                Else
                    lblPie.Text = "En caso de aprobado, favor presentarse el día        , a las         , en el          con todo(a)s lo(a)s integrantes del " & _
                                  "Grupo Solidario para el retiro de los cheques y firma del pagaré correspondiente " & _
                                  "(TODO(A)S DEBERAN TRAER CEDULA DE IDENTIDAD). No olvide retirar su Calendario de Pagos. " & _
                                  "Las cuotas deberán ser canceladas en          de                 los días          de cada mes."
                End If

            Else
                SubReport1.Visible = False
                'SubReporte.Visible = False
                'SubReporteFCL.Visible = False
            End If

            '------------------------
            lblNumero.Text = "No. " & xdtFormato.ValueField("nCodigo")
            lblRecibido.Text = "FICHA DE NOTIFICACION DE CREDITO No. " & xdtFormato.ValueField("nCodigo")

            EncuentraParametros()
            lblFirma.Text = StrUnidadNotificadora
            lblMinisterio.Text = StrUbicacionDelegacion
            lblDireccion.Text = StrDireccion
            lblPBX.Text = StrPBX
            lblPlazo.Text = "Plazo (" & StrPlazo & ")"

            '-- Incluir Firma Digital de Notificación:
            StrPath = StrPathFirmaDigital()
            If BlnFirmaDigitalExiste(StrPath & "F" & StrCodigoE & ".jpg") Then
                Me.picFirmaNotificador.Image = System.Drawing.Image.FromFile(StrPath & "F" & StrCodigoE & ".jpg")
            Else
                MsgBox("No se ha capturado Firma Digital de la " & Chr(13) & StrUnidadNotificadora & ".", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txtMonto.Text = Format(Me.txtMonto.Value, "#,##0.00")
    End Sub
End Class