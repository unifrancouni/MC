'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                09/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSccSolicitudCheque.vb
' Descripción:          Formulario para impresión de Solicitudes de Cheques.
'----------------------------------------------------------------------------

Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSccSolicitudCheque
    'Declaracion de Variables

    Dim objEncabeza As rptEncabezadoV
    Dim objEncabezaFCL As rptEncabezadoV_FCL
    Dim objEncabezaPD As rptEncabezadoV_PD

    Dim xdtSolicitudCheque As BOSistema.Win.XDataSet.xDataTable

    Dim StrCargoC As String
    Dim StrEAutoriza As String

    'Id de la FNC ó Solicitud de Cheque.
    Dim mIdFormato As Integer
    Dim mIdTipo As Integer
    Dim mEstado As String
    Dim intTipoPrograma As Integer

    'ID de la FNC en caso de Solicitudes de Cheque a Socias e Id de la 
    'Solicitud de Cheque en caso de Otras Solicitudes (manuales).
    Public Property IdFormato() As Integer
        Get
            IdFormato = mIdFormato
        End Get
        Set(ByVal value As Integer)
            mIdFormato = value
        End Set
    End Property

    'ID: 1 = Solicitudes de Cheque a Socias.
    Public Property IdTipo() As Integer
        Get
            IdTipo = mIdTipo
        End Get
        Set(ByVal value As Integer)
            mIdTipo = value
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

            'Solicitud de Cheque Anulada:
            If (Me.mEstado = "5") Then
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
    ' Date			    		:	09/11/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar variables.
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            xdtSolicitudCheque = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	09/11/2007
    ' Procedure name		   	:	CargarSolicitudCheque
    ' Description			   	:	Cargar los datos de Solicitudes de cada Socia de la FNC.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarSolicitudCheque()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 
            Strsql = ""
            '------------------------

            'Solicitud de Cheque a Socias (Imprime todas las Socias del Grupo):
            If mIdTipo = 1 Then
                Strsql = " Select * " & _
                         " From vwSccSolicitudChequeARep a " & _
                         " WHERE (a.nIdFormato = " & Me.IdFormato & ") " & _
                         " Order by a.nCoordinador Desc, a.nSclFichaSociaID, a.nDebito desc, a.sCodigoCuenta"
                'Imprime Solicitud de Cheque actual
            Else
                Strsql = " Select * " & _
                         " From vwSccSolicitudChequeRep a " & _
                         " WHERE (a.nIdFormato = " & Me.IdFormato & ") " & _
                         " Order by a.nIdFormato, a.nDebito desc, a.sCodigoCuenta"
                Me.lblPrestamo.Visible = False
                Me.lblIdFichaSocia.Visible = False
            End If
            xdtSolicitudCheque.ExecuteSql(Strsql)

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

            'Empleado Autoriza Solicitudes de Cheques:
            Strsql = "SELECT vwStbEmpleado.sTitulo + ' ' + vwStbEmpleado.sNombre AS sNombre FROM StbValorParametro INNER JOIN vwStbEmpleado ON StbValorParametro.sValorParametro = vwStbEmpleado.nSrhEmpleadoID WHERE (StbValorParametro.nStbParametroID = 28)"
            StrEAutoriza = XcDatos.ExecuteScalar(Strsql)

            'Cargo Autorización:
            Strsql = "SELECT vwStbEmpleado.sNombreCargo FROM StbValorParametro INNER JOIN vwStbEmpleado ON StbValorParametro.sValorParametro = vwStbEmpleado.nSrhEmpleadoID WHERE  (StbValorParametro.nStbParametroID = 28)"
            StrCargoC = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub rptSccSolicitudCheque_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            xdtSolicitudCheque.Close()
            xdtSolicitudCheque = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSccSolicitudCheque_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            Dim strSQL As String
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarSolicitudCheque()
            EncuentraParametros()

            If xdtSolicitudCheque.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtSolicitudCheque.Table

            '-- Firmas:
            If xdtSolicitudCheque.ValueField("EAutoriza") = " " Then
                lblFirmaC.Text = StrEAutoriza
                lblCargoC.Text = StrCargoC
            Else
                Me.lblFirmaC.DataField = "EAutoriza"
                Me.lblCargoC.DataField = "CargoA"
            End If

            'Si es Solicitud de Cheque a Socias:
            If mIdTipo = 1 Then
                strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                         "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & Me.mIdFormato & ")"
                '-- SI EL CREDITO ES DE USURA CERO:
                If RegistrosAsociados(strSQL) Then
                    Me.SubReporteFCL.Visible = False
                    Me.txtInstancia.Text = "Programa Usura Cero"
                Else
                    Me.SubReporte.Visible = False
                    Me.txtInstancia.Text = "Fondo de Crédito Local FCL-ME"
                End If
            Else 'Otras Solicitudes de Cheque
                Me.SubReporteFCL.Visible = False
                Me.txtInstancia.Text = "Programa Usura Cero"
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

        'Fechas:
        Me.txtFechaS.Text = Format(Me.txtFechaS.Value, "dd/MM/yyyy")
        
        'Montos:
        Me.txtMonto.Text = Format(Me.txtMonto.Value, "#,##0.00")
        '-- Monto en Letras:
        txtMontoLetras.Text = UCase(NroEnLetras(txtMonto.Text, True, "Córdoba", "Córdobas"))

        'Mayúsculas:
        Me.txtNombreS.Text = UCase(Me.txtNombreS.Value)

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'Montos:
        Me.txtDebe.Text = Format(Me.txtDebe.Value, "#,##0.00")
        Me.txtHaber.Text = Format(Me.txtHaber.Value, "#,##0.00")
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        'Montos:
        Me.txtMontoDT.Text = Format(Me.txtMontoDT.Value, "C$ #,##0.00")
        Me.txtMontoHT.Text = Format(Me.txtMontoHT.Value, "C$ #,##0.00")
    End Sub
End Class
