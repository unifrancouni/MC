'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                19/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSclSolicitudDesembolso.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Solicitud de Desembolso de Crédito.		     
'----------------------------------------------------------------------------
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document

Public Class rptSclSolicitudDesembolso

    Dim StrPath As String
    'Declaracion de Variables
    Dim objEncabeza As rptEncabezadoV
    Dim objEncabezaFCL As rptEncabezadoV_FCL
    Dim objEncabezaPD As rptEncabezadoV_PD

    Dim xdtSolicitudDesembolso As BOSistema.Win.XDataSet.xDataTable

    Dim StrCargoB As String
    Dim mEstado As String
    Dim intTipoPrograma As Integer

    'Id de la FNC.
    Dim mIdFichaNotificacion As Integer

    'ID del Estado(Activo, Inactivo, Todos) del Barrio
    Public Property IdFichaNotificacion() As Integer
        Get
            IdFichaNotificacion = mIdFichaNotificacion
        End Get
        Set(ByVal value As Integer)
            mIdFichaNotificacion = value
        End Set
    End Property

    'Descripción del Estado de la FNC.
    Public Property Estado() As String
        Get
            Estado = mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
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

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            'Ficha Anulada o Ficha Anulada con Regeneración:
            If (Me.mEstado = "4") Or (Me.mEstado = "5") Then
                Me.lblAnulada.Visible = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

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
    ' Date			    		:	19/10/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar variables.
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            xdtSolicitudDesembolso = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	19/10/2007
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Cargo Tercer Firma del Comité de Crédito:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 27)"
            StrCargoB = XcDatos.ExecuteScalar(Strsql)

            'Forma de Pago de las socias (Semanal):
            'Strsql = "SELECT b.sDescripcion FROM   StbValorParametro a INNER JOIN StbValorCatalogo b ON a.sValorParametro = b.nStbValorCatalogoID WHERE (a.nStbParametroID = 6)"
            'StrFormaPago = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	19/10/2007
    ' Procedure name		   	:	CargarSolicitudDesembolso
    ' Description			   	:	Cargar los datos de Solicitudes de cada Socia de la FNC.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarSolicitudDesembolso()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 
            Strsql = ""
            '------------------------
            Strsql = " Select * " & _
                     " From vwSclSolicitudDesembolsoRep a " & _
                     " WHERE (a.nSclFichaNotificacionID = " & Me.IdFichaNotificacion & ") AND (a.nCreditoRechazado = 0) " & _
                     " Order by a.nCoordinador Desc, a.nSclFichaSociaID"
            xdtSolicitudDesembolso.ExecuteSql(Strsql)

            'Encuentra Parámetros:
            '-- Tasa de Interes:
            'XdtValorParametro.Filter = " nStbValorParametroID = 1"
            'XdtValorParametro.Retrieve()
            'If XdtValorParametro.Count > 0 Then
            '    Me.txtInteres.Text = XdtValorParametro.ValueField("sValorParametro") & " %"
            'End If

            '-- Tasa de Mora:
            'XdtValorParametro.Filter = " nStbValorParametroID = 3"
            'XdtValorParametro.Retrieve()
            'If XdtValorParametro.Count > 0 Then
            '    Me.txtMora.Text = XdtValorParametro.ValueField("sValorParametro") & " %"
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub rptSclSolicitudDesembolso_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            xdtSolicitudDesembolso.Close()
            xdtSolicitudDesembolso = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptStbDistrito_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            Dim strSQL As String
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarSolicitudDesembolso()
            EncuentraParametros()

            If xdtSolicitudDesembolso.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtSolicitudDesembolso.Table

            '-------------------------------
            'txtFormaPago.Text = StrFormaPago
            txtTipoPlazo.Text = "(" + xdtSolicitudDesembolso.ValueField("TipoPlazo") + ")"
            '-------------------------------

            'Si es Grupo Solidario Usura:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & Me.mIdFichaNotificacion & ")"
            '-- SI EL CREDITO ES DE USURA CERO:
            If RegistrosAsociados(strSQL) Then
                Me.SubReporteFCL.Visible = False
                Me.txtInstancia.Text = "Programa Usura Cero"
            Else
                Me.SubReporte.Visible = False
                Me.txtInstancia.Text = "Fondo Local FCL-ME"
            End If

            '-- Firmas: 
            lblFirmaA.Text = "Lic. " & xdtSolicitudDesembolso.ValueField("EmpleadoE")
            lblFirmaB.Text = xdtSolicitudDesembolso.ValueField("TituloA") & ". " & xdtSolicitudDesembolso.ValueField("EmpleadoA")
            lblCargoB.Text = xdtSolicitudDesembolso.ValueField("CargoA")

            '-- Incluir Firmas Digitales de Elaboración/Autorización:
            StrPath = StrPathFirmaDigital()
            '1. Empleado que Autoriza Solicitud de Desembolso de Crédito:
            If BlnFirmaDigitalExiste(StrPath & "F" & xdtSolicitudDesembolso.ValueField("CodigoA") & ".jpg") Then
                Me.picAutorizado.Image = System.Drawing.Image.FromFile(StrPath & "F" & xdtSolicitudDesembolso.ValueField("CodigoA") & ".jpg")
            Else
                MsgBox("No se ha capturado Firma Digital del" & Chr(13) & lblCargoB.Text & ".", MsgBoxStyle.Information, NombreSistema)
            End If
            '2. Empleado que Elabora la Solicitud de Desembolso de Crédito:
            If BlnFirmaDigitalExiste(StrPath & "F" & xdtSolicitudDesembolso.ValueField("CodigoE") & ".jpg") Then
                Me.picElaborado.Image = System.Drawing.Image.FromFile(StrPath & "F" & xdtSolicitudDesembolso.ValueField("CodigoE") & ".jpg")
            Else
                MsgBox("No se ha capturado Firma Digital de Oficial de Crédito.", MsgBoxStyle.Information, NombreSistema)
            End If

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

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Dim DblMontoDolares As Double = 0

        'Fechas:
        If IsDate(Me.txtFechaS.Value) Then
            Me.txtFechaS.Text = Format(Me.txtFechaS.Value, "dd/MM/yyyy")
        End If
        If IsDate(Me.txtFechaSesion.Value) Then
            Me.txtFechaSesion.Text = Format(Me.txtFechaSesion.Value, "dd/MM/yyyy")
        End If
        If IsDate(Me.txtFechaF.Value) Then
            Me.txtFechaF.Text = Format(Me.txtFechaF.Value, "dd/MM/yyyy")
        End If
        If IsDate(Me.txtFechaI.Value) Then
            Me.txtFechaI.Text = Format(Me.txtFechaI.Value, "dd/MM/yyyy")
        End If
        If IsDate(Me.txtFechaD.Value) Then
            Me.txtFechaD.Text = Format(Me.txtFechaD.Value, "dd/MM/yyyy")
        End If
        'Montos:
        Me.txtMontoA.Text = Format(Me.txtMontoA.Value, "C$ #,##0.00")
        Me.txtMontoSem.Text = Format(Me.txtMontoSem.Value, "C$ #,##0.00")
        Me.txtMontoD.Text = Format(Me.txtMontoD.Value, "C$ #,##0.00")

        'Porcentajes:
        Me.txtInteres.Text = Format(Me.txtInteres.Value, "#,##0.00") & " %"
        Me.txtMora.Text = Format(Me.txtMora.Value, "#,##0.00") & " %"

        'Monto en Dólares:
        DblMontoDolares = Me.txtMontoD.Value / Me.txtTipoCambio.Value
        Me.txtMontoDUS.Text = Format(DblMontoDolares, "US$ #,##0.00")

        Me.txtNombreS.Text = UCase(Me.txtNombreS.Value)
        Me.txtGrupoS.Text = UCase(Me.txtGrupoS.Value)
    End Sub
End Class
