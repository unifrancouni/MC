'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                04/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSclFichaComiteCredito.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Ficha de Comité de Crédito.		     
'----------------------------------------------------------------------------
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclFichaComiteCredito

    'Declaración de Subreporte EXPEDIENTE:
    Dim ObjExpedienteGrupo As srptSclExpedienteSocia

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
    Dim DblTasaInteres As Double
    Dim DblTasaMora As Double
    Dim StrCargoFirma1 As String
    Dim StrCargoFirma2 As String
    Dim StrCargoFirma3 As String

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
    ' Fecha:                04/10/2007
    ' Procedure Name:       PageHeader1_Format
    ' Descripción:          Permite asignar Formato del PageHeader.
    '-------------------------------------------------------------------------
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            '-- Indica Parámetros:
            Me.txtparametro.Text = "Estado Crédito: " & Me.mEstado

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
    ' Fecha:                04/10/2007
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
    ' Date			    		:	04/10/2007
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
    ' Date			    		:	18/08/2009
    ' Procedure name		   	:	EncuentraParametrosFCL
    ' Description			   	:	Encontrar parámetros del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametrosFCL()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Tasa de Interes para colocacion de Préstamos:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 48)"
            DblTasaInteres = XcDatos.ExecuteScalar(Strsql)

            'Tasa de Mora:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 50)"
            DblTasaMora = XcDatos.ExecuteScalar(Strsql)

            'Cargo Primer Firma del Comité de Crédito:
            StrCargoFirma1 = "Oficial de Crédito"

            'Cargo Segunda Firma del Comité de Crédito:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 27)"
            StrCargoFirma2 = XcDatos.ExecuteScalar(Strsql)

            'Cargo Tercer Firma: Director del Programa:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 25)"
            StrCargoFirma3 = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	04/10/2007
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Tasa de Interes para colocacion de Préstamos:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 1)"
            DblTasaInteres = XcDatos.ExecuteScalar(Strsql)

            'Tasa de Mora:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 3)"
            DblTasaMora = XcDatos.ExecuteScalar(Strsql)

            'Cargo Primer Firma del Comité de Crédito:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 25)"
            StrCargoFirma1 = XcDatos.ExecuteScalar(Strsql)

            'Cargo Segunda Firma del Comité de Crédito:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 26)"
            StrCargoFirma2 = XcDatos.ExecuteScalar(Strsql)

            'Cargo Tercer Firma del Comité de Crédito:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 27)"
            StrCargoFirma3 = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	04/10/2007
    ' Procedure name		   	:	CargarFichaComite
    ' Description			   	:	Cargar los datos de la Ficha de Comité de Crédito.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarFichaComite()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables: 
            Strsql = ""
            Strsql = " Select row_number() OVER (ORDER BY nCoordinador DESC, nSclFichaSociaID) AS Item, " &
                     "        nSclFichaNotificacionID, nCoordinador, " &
                     "        nCodigo, " &
                     "        NombreGrupo, " &
                     "        NombreSocia," &
                     "        CedulaSocia, " &
                     "        Departamento, " &
                     "        Municipio, " &
                     "        Distrito, " &
                     "        Barrio, " &
                     "        Mercado, " &
                     "        sNumSesion, " &
                     "        dFechaNotificacion, " &
                     "        sObservacion, " &
                     "        nMontoCreditoSolicitado, " &
                     "        nPlazoSolicitado, " &
                     "        nMontoCreditoAprobado, " &
                     "        nPlazoAprobado, " &
                     "        TipoPlazo, " &
                     "        PrimerFirma, " &
                     "        TituloF1, " &
                     "        CargoF1, " &
                     "        SegundaFirma, " &
                     "        TituloF2, " &
                     "        CargoF2, " &
                     "        TercerFirma, " &
                     "        TituloF3, " &
                     "        CargoF3, " &
                     "        sCodigoInterno, " &
                     "        MontoTotalS, " &
                     "        MontoTotalA, " &
                     "        sCodigoInterno, " &
                     "        nSclFichaSociaID, nTasaInteresAnual, nTasaMoraAnual, nTasaMantValorAnual, " &
                     "        ISNULL(ModuloSocia,0) ModuloSocia " &
                     " From vwSclFichaComiteCreditoRep " &
                     " WHERE  (nSclFichaNotificacionID = " & mIdFicha & ") " &
                     " GROUP BY nSclFichaNotificacionID, nCoordinador, nCodigo, NombreGrupo, NombreSocia,  CedulaSocia, Departamento, Municipio, Distrito, Barrio, Mercado,  sNumSesion, dFechaNotificacion, sObservacion, nMontoCreditoSolicitado, nPlazoSolicitado,  nMontoCreditoAprobado, nPlazoAprobado, TipoPlazo, PrimerFirma, SegundaFirma, TercerFirma, TituloF1, TituloF2, TituloF3, CargoF1, CargoF2, CargoF3,  sCodigoInterno, MontoTotalS, MontoTotalA, sCodigoInterno, nSclFichaSociaID, nTasaInteresAnual, nTasaMoraAnual, nTasaMantValorAnual, ModuloSocia
                       Order by nCoordinador DESC, nSclFichaSociaID "
            '(nCreditoRechazado = 0) And
            '" Order by nCoordinador DESC, CedulaSocia "

            xdtFormato.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSclFichaComiteCredito_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
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
    Private Sub rptSclFichaComiteCredito_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            Dim strSQL As String
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarFichaComite()

            If xdtFormato.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtFormato.Table

            'Ficha de Notificación En Proceso: Ocultar monto y plazo aprobado 
            'y el Check de cumplimiento del Expediente:
            If xdtFormato.ValueField("sCodigoInterno") <> "1" Then
                'Asignar el data field
                Me.txtMonto.DataField = "nMontoCreditoAprobado"
                Me.txtPlazo.DataField = "nPlazoAprobado"
                Me.txtSesion.DataField = "sNumSesion"
                txtFechaResolucion.Text = Format(xdtFormato.ValueField("dFechaNotificacion"), "dd/MM/yyyy")
                txtTotalA.Text = Format(xdtFormato.ValueField("MontoTotalA"), "C$ #,##0.00")
                lblPie.Text = "Dado en la ciudad de " & xdtFormato.ValueField("Departamento") & ", a los  " & Format(xdtFormato.ValueField("dFechaNotificacion"), "dd' días del mes de 'MMMM' del año 'yyyy") & "."
            Else
                lblPie.Text = "Dado en la ciudad de " & xdtFormato.ValueField("Departamento") & ", a los ____ días del mes de _______________ del año 200__."
            End If
            'txtTotalS.Text = Format(xdtFormato.ValueField("MontoTotalS"), "C$ #,##0.00")

            '------------------------
            lblNumero.Text = "No. " & xdtFormato.ValueField("nCodigo")
            lblPlazoA.Text = "Plazo (" & xdtFormato.ValueField("TipoPlazo") & ")"
            lblPlazoS.Text = "Plazo (" & Mid(xdtFormato.ValueField("TipoPlazo"), 1, 3) & ".)"

            'Si es Grupo Solidario Usura / Mercado Pago Diario:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1' OR StbValorCatalogo.sCodigoInterno = '3') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & Me.mIdFicha & ")"
            '-- SI EL CREDITO ES DE USURA CERO:
            If RegistrosAsociados(strSQL) Then
                Me.SubReporteFCL.Visible = False
                lblTitulo.Text = "FICHA DE COMITE DE CREDITO"
                EncuentraParametros()
                '-- Firmas del Comité de Crédito:
                lblFirmaB.Visible = True
                lblCargoSegundaFirma.Visible = True
                lblFirmaA.Text = xdtFormato.ValueField("TituloF1") & ". " & xdtFormato.ValueField("PrimerFirma")
                lblCargoPrimeraFirma.Text = xdtFormato.ValueField("CargoF1") 'StrCargoFirma1
                lblFirmaB.Text = xdtFormato.ValueField("TituloF2") & ". " & xdtFormato.ValueField("SegundaFirma")
                lblCargoSegundaFirma.Text = xdtFormato.ValueField("CargoF2") 'StrCargoFirma2
                lblFirmaC.Text = xdtFormato.ValueField("TituloF3") & ". " & xdtFormato.ValueField("TercerFirma")
                lblCargoTerceraFirma.Text = xdtFormato.ValueField("CargoF3") 'StrCargoFirma3
            Else 'Creditos de Ventana de Genero
                Me.SubReporte.Visible = False
                lblTitulo.Text = "FICHA COMITE TECNICO DE CREDITO"
                EncuentraParametrosFCL()
                '-- Firmas del Comité de Crédito:
                lblFirmaB.Visible = False
                lblCargoSegundaFirma.Visible = False
                lblFirmaA.Text = xdtFormato.ValueField("TituloF2") & ". " & xdtFormato.ValueField("TercerFirma")
                lblCargoPrimeraFirma.Text = xdtFormato.ValueField("CargoF3") 'StrCargoFirma3
                lblFirmaC.Text = xdtFormato.ValueField("TituloF1") & ". " & xdtFormato.ValueField("PrimerFirma")
                lblCargoTerceraFirma.Text = xdtFormato.ValueField("CargoF1") 'StrCargoFirma1
            End If
            '------------------------

            'txtTasaInteres.Text = Format(DblTasaInteres, "#,##0.00") & " %"
            'txtTasaMora.Text = Format(DblTasaMora, "#,##0.00") & " %"

            If TipoPrograma = 3 Then
                SubReport1.Visible = True
                SubReporte.Visible = False
                SubReporteFCL.Visible = False
            Else
                SubReport1.Visible = False
                'SubReporte.Visible = False
                'SubReporteFCL.Visible = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txtMonto.Text = Format(Me.txtMonto.Value, "#,##0.00")
        Me.txtMontoS.Text = Format(Me.txtMontoS.Value, "#,##0.00")
    End Sub

    Private Sub grpGrupo_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpGrupo.Format
        ObjExpedienteGrupo = New srptSclExpedienteSocia
        ObjExpedienteGrupo.IdFichaNotificacion = CInt(mIdFicha)
        ObjExpedienteGrupo.IdEstadoCredito = xdtFormato.ValueField("sCodigoInterno")
        Me.srptExpediente.Report = ObjExpedienteGrupo

        If IsNumeric(txtTasaInteres.Value) Then
            txtTasaInteres.Text = Format(txtTasaInteres.Value, "#,##0.00") & " %"
            txtTasaMora.Text = Format(txtTasaMora.Value, "#,##0.00") & " %"
        End If
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Me.txtTotalS.Text = Format(Me.txtTotalS.Value, "C$ ##,###,###,##0.00")
    End Sub
End Class