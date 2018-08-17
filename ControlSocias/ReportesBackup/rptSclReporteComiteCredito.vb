'----------------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                19/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSclReporteComiteCredito.vb
' Descripción:          Impresión de Reporte de Comité por Sesión de Crédito.
'----------------------------------------------------------------------------------

Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclReporteComiteCredito

    Dim ObjCreditosDenegado As srptSclCreditosDenegados
    Dim i As Integer
    Dim j As Integer
    Dim StrCodGS As String
    Dim StrGrupo As String

    'Declaracion de Variables:
    Dim objEncabeza As rptEncabezadoH
    Dim xdtFormato As BOSistema.Win.XDataSet.xDataTable

    'Datos de la Resolución de Crédito:
    Dim mCodigoSesion As String

    'Parámetros:
    Dim DblTasaInteres As Double
    Dim DblTasaMora As Double
    Dim StrCargoFirma1 As String
    Dim StrCargoFirma2 As String
    Dim StrCargoFirma3 As String
    Dim StrFormaPago As String

    'Código de la Resolución:
    Public Property CodigoSesion() As String
        Get
            CodigoSesion = mCodigoSesion
        End Get
        Set(ByVal value As String)
            mCodigoSesion = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/10/2007
    ' Procedure Name:       PageHeader1_Format
    ' Descripción:          Permite asignar Formato del PageHeader.
    '-------------------------------------------------------------------------
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            If Mid(rptInfo1.Text, 1, 1) = "1" Then
                lblTituloI.Visible = False
            Else
                lblTituloI.Visible = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/10/2007
    ' Procedure Name:       EncabezadoReporte_Format
    ' Descripción:          Asigna Sub-reporte para Encabezado.
    '-------------------------------------------------------------------------
    Private Sub EncabezadoReporte_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            objEncabeza = New rptEncabezadoH
            Me.SubReporte.Report = objEncabeza

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	10/10/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Permite inicializar los objetos. 
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            xdtFormato = New BOSistema.Win.XDataSet.xDataTable
            'Inicializa Consecutivo de Socias.
            i = 0
            j = 0
            StrCodGS = ""
            StrGrupo = ""

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	10/10/2007
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Tasa de Interes para colocacion de Prestamos:
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

            'Forma de Pago de las socias (Semanal):
            Strsql = "SELECT b.sDescripcion FROM   StbValorParametro a INNER JOIN StbValorCatalogo b ON a.sValorParametro = b.nStbValorCatalogoID WHERE (a.nStbParametroID = 6)"
            StrFormaPago = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	10/10/2007
    ' Procedure name		   	:	CargarActaComite
    ' Description			   	:	Cargar los datos del Acta de Comité de Crédito.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarActaComite()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables: 
            Strsql = " Select vwSclActaComiteCreditoRep.*, '" & StrFormaPago & "' as sFormaPago, '" & Format(DblTasaInteres, "#,##0.0") & "%' as sInteres, '" & Format(DblTasaMora, "#,##0.0") & "%' as sMora " & _
                     " From vwSclActaComiteCreditoRep " & _
                     " WHERE (EstadoCredito = '2') And (nCreditoRechazado = 0) And (sNumSesion = '" & mCodigoSesion & "') " & _
                     " Order by Departamento, Municipio, Grupo, Texto, CodigoGS, nCoordinador DESC, NombreSocia "
            xdtFormato.ExecuteSql(Strsql)

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

            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            EncuentraParametros()
            CargarActaComite()

            If xdtFormato.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte:
            Me.DataSource = xdtFormato.Table

            '------------------------
            txtCodigo.Text = "Resolución No. " + xdtFormato.ValueField("sNumSesion") '+ "/" + Str(Year(xdtFormato.ValueField("dFechaNotificacion")))
            'txtEncabezado.Text = "El día " & Format(xdtFormato.ValueField("dFechaNotificacion"), "dd' de 'MMMM' del año 'yyyy") & " , a las " & Format(xdtFormato.ValueField("dFechaNotificacion"), "hh:mm tt") & " en las Oficinas " & _
            '                     "del Ministerio de Fomento, Industria y Comercio (MIFIC), se reunieron los miembros que conforman el Comité de Crédito del " & _
            '                     "Programa Usura Cero para Evaluar las Solicitudes de Crédito a continuación detalladas."
            'txtPie.Text = "No habiendo otros aspectos que tratar se levanta la sesión a las 5:00 p.m. del mismo día " & Format(xdtFormato.ValueField("dFechaNotificacion"), "dd' de 'MMMM' del año 'yyyy") & "."
            lblPlazoA.Text = "Plazo Aprobado (" & xdtFormato.ValueField("TipoPlazo") & ")"

            '-- Firmas del Comité de Crédito:
            'lblFirmaA.Text = "Lic. " + xdtFormato.ValueField("EmpleadoF1") + ", " + StrCargoFirma1 + "."
            'lblFirmaB.Text = "Lic. " + xdtFormato.ValueField("EmpleadoF2") + ", " + StrCargoFirma2 + "."
            'lblFirmaC.Text = "Lic. " + xdtFormato.ValueField("EmpleadoF3") + ", " + StrCargoFirma3 + "."
            'lblCuota.Text = "Cuota " & StrFormaPago & " (C$)"
            lblCuota.Text = "Cuota " & " (C$)"

            'lblFirmaAI.Text = "Lic. " & xdtFormato.ValueField("EmpleadoF1")
            'lblCargoPrimeraFirma.Text = StrCargoFirma1
            'lblFirmaBI.Text = "Lic. " & xdtFormato.ValueField("EmpleadoF2")
            'lblCargoSegundaFirma.Text = StrCargoFirma2
            'lblFirmaCI.Text = "Lic. " & xdtFormato.ValueField("EmpleadoF3")
            'lblCargoTerceraFirma.Text = StrCargoFirma3

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

        Me.txtMontoS.Text = Format(Me.txtMontoS.Value, "#,##0.00")
        Me.txtMontoA.Text = Format(Me.txtMontoA.Value, "#,##0.00")
        Me.txtCuota.Text = Format(Me.txtCuota.Value, "#,##0.00")
        Me.txtTipoNegocio.Text = UCase(Me.txtTipoNegocio.Value)

        If xdtFormato.Count > 0 Then
            'Socias:
            If txtGrupo.Text <> StrGrupo Then
                i = 0
                j = 0
            End If
            i = i + 1
            Me.txtCodSocia.Text = i
            StrGrupo = txtGrupo.Text

            'Grupos:
            If (txtGSId.Text <> StrCodGS) Then
                j = j + 1
                txtNombreGS.Visible = True
                txtTexto.Visible = True
                txtCodGS.Visible = True
            Else
                txtNombreGS.Visible = False
                txtTexto.Visible = False
                txtCodGS.Visible = False
            End If
            Me.txtCodGS.Text = j
            StrCodGS = txtGSId.Text
            'If txtNombreGS.Text <> StrCodGS Then
            '    j = j + 1
            '    txtNombreGS.Visible = True
            '    txtTexto.Visible = True
            '    txtCodGS.Visible = True
            'Else
            '    txtNombreGS.Visible = False
            '    txtTexto.Visible = False
            '    txtCodGS.Visible = False
            'End If
            'Me.txtCodGS.Text = j
            'StrCodGS = txtNombreGS.Text
        End If
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Me.txtMontoSSt.Text = Format(Me.txtMontoSSt.Value, "#,##0.00")
        Me.txtMontoASt.Text = Format(Me.txtMontoASt.Value, "#,##0.00") '"C$ ##,###,###,##0.00"
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Me.txtMontoST.Text = Format(Me.txtMontoST.Value, "#,##0.00")
        Me.txtMontoAT.Text = Format(Me.txtMontoAT.Value, "#,##0.00")
        lblAprobadasGrupo.Text = "TOTAL SOLICITUDES APROBADAS " + UCase(txtGrupo.Text)
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Dim StrSql As String
        Me.txtMontoSTg.Text = Format(Me.txtMontoSTg.Value, "#,##0.00")
        Me.txtMontoATg.Text = Format(Me.txtMontoATg.Value, "#,##0.00")

        'Subreporte Créditos Denegados (Si existen):
        StrSql = " Select * From vwSclActaDenegadosComiteCreditoRep " & _
                 " WHERE (EstadoCredito = '2' or EstadoCredito = '3') AND (nCreditoRechazado = 1) And (sNumSesion = '" & mCodigoSesion & "')"
        If RegistrosAsociados(StrSql) Then
            ObjCreditosDenegado = New srptSclCreditosDenegados
            ObjCreditosDenegado.StrNoSesion = mCodigoSesion
            Me.srptDenegados.Report = ObjCreditosDenegado
        End If
    End Sub
End Class
