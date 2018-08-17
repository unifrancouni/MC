'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                18/08/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSccEstadoCuentaResumen.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Estado de Cuenta Resumen por Grupo Solidario.		     
'----------------------------------------------------------------------------

Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSccEstadoCuentaResumen

    Dim StrPath As String
    Dim StrFirma As String
    Dim StrCargo As String
    Dim StrCodigoE As String

    'Declaracion de Variables
    Dim objEncabeza As rptEncabezadoV
    Dim xdtFormato As BOSistema.Win.XDataSet.xDataTable

    'Datos del Grupo Solidario
    Dim mIdFicha As Long
    Dim mCodigoFicha As String
    Dim mNombreGrupo As String 'Código y Nombre.
    Dim mEstado As String

    'Parámetros:
    Dim DblTasaInteres As Double
    Dim DblTasaMora As Double

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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/08/2008
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
    ' Fecha:                18/08/2008
    ' Procedure Name:       EncabezadoReporte_Format
    ' Descripción:          Asigna Sub-reporte para Encabezado.
    '-------------------------------------------------------------------------
    Private Sub EncabezadoReporte_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            objEncabeza = New rptEncabezadoV
            Me.SubReporte.Report = objEncabeza
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/08/2008
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
    ' Date			    		:	18/08/2008
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

            'Datos de Empleado que Imprime el Reporte:
            Strsql = "SELECT vwStbEmpleado.sNombre " & _
                     "FROM SsgCuenta INNER JOIN SrhEmpleado ON SsgCuenta.objEmpleadoID = SrhEmpleado.nSrhEmpleadoID INNER JOIN vwStbEmpleado ON SrhEmpleado.nSrhEmpleadoID = vwStbEmpleado.nSrhEmpleadoID " & _
                     "WHERE (SsgCuenta.SsgCuentaID = " & InfoSistema.IDCuenta & ")"
            If RegistrosAsociados(Strsql) Then
                StrFirma = XcDatos.ExecuteScalar(Strsql)
                Strsql = "SELECT vwStbEmpleado.sNombreCargo " & _
                         "FROM SsgCuenta INNER JOIN SrhEmpleado ON SsgCuenta.objEmpleadoID = SrhEmpleado.nSrhEmpleadoID INNER JOIN vwStbEmpleado ON SrhEmpleado.nSrhEmpleadoID = vwStbEmpleado.nSrhEmpleadoID " & _
                         "WHERE (SsgCuenta.SsgCuentaID = " & InfoSistema.IDCuenta & ")"
                StrCargo = XcDatos.ExecuteScalar(Strsql)
                Strsql = "SELECT vwStbEmpleado.sCodigo " & _
                         "FROM SsgCuenta INNER JOIN SrhEmpleado ON SsgCuenta.objEmpleadoID = SrhEmpleado.nSrhEmpleadoID INNER JOIN vwStbEmpleado ON SrhEmpleado.nSrhEmpleadoID = vwStbEmpleado.nSrhEmpleadoID " & _
                         "WHERE (SsgCuenta.SsgCuentaID = " & InfoSistema.IDCuenta & ")"
                StrCodigoE = XcDatos.ExecuteScalar(Strsql)
            Else
                StrFirma = "Impreso Por"
                StrCargo = ""
                StrCodigoE = "0000"
            End If
            

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/08/2008
    ' Procedure name		   	:	CargarEstadoCuentaResumen
    ' Description			   	:	Cargar los datos del Estado de Cuenta Resumen.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarEstadoCuentaResumen()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables: Es necesario agrupar para la secuencia de row_number():
            Strsql = String.Format("exec spSccEstadoCuentaResumenGrupo {0}", mIdFicha)
            'Strsql = " Select row_number() OVER (ORDER BY nCoordinador DESC, nSclFichaSociaID) AS Item, " & _
            '         "        nSclFichaNotificacionID, nCoordinador, " & _
            '         "        nCodigo, " & _
            '         "        NombreGrupo, " & _
            '         "        NombreSocia," & _
            '         "        CedulaSocia, " & _
            '         "        Departamento, " & _
            '         "        Municipio, " & _
            '         "        Distrito, " & _
            '         "        Barrio, " & _
            '         "        Mercado, sObservacionEC, " & _
            '         "        nMontoCreditoSolicitado, " & _
            '         "        nMontoCreditoAprobado, " & _
            '         "        MontoPagado, SaldoActual, " & _
            '         "        sCodigoInterno, " & _
            '         "        EstadoCredito, dFechaDesembolso, dFechaUltimoPago, " & _
            '         "        nSclFichaSociaID " & _
            '         " From vwSccEstadoCuentaResumenGrupo " & _
            '         " WHERE  (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & mIdFicha & ") " & _
            '         " GROUP BY nSclFichaNotificacionID, nCoordinador, nCodigo, NombreGrupo, NombreSocia, " & _
            '         " CedulaSocia, Departamento, Municipio, Distrito, Barrio, Mercado, " & _
            '         " nMontoCreditoSolicitado, sObservacionEC, " & _
            '         " nMontoCreditoAprobado, EstadoCredito, dFechaDesembolso, dFechaUltimoPago, " & _
            '         " MontoPagado, SaldoActual, sCodigoInterno, nSclFichaSociaID " & _
            '         " Order by nCoordinador DESC, nSclFichaSociaID "
            xdtFormato.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSccEstadoCuentaResumen_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            xdtFormato.Close()
            xdtFormato = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/08/2008
    ' Procedure name		   	:	rptSccEstadoCuentaResumen_ReportStart
    ' Description			   	:	Inicialización del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub rptSccEstadoCuentaResumen_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try

            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarEstadoCuentaResumen()

            If xdtFormato.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtFormato.Table
            '------------------------
            EncuentraParametros()
            txtTasaInteres.Text = Format(DblTasaInteres, "#,##0.00") & " %"
            txtTasaMora.Text = Format(DblTasaMora, "#,##0.00") & " %"

            '-- Firmas de Persona que Imprime:
            lblFirmaA.Text = StrFirma
            lblCargoPrimeraFirma.Text = StrCargo
            lblNumero.Text = "Ficha de Comité de Crédito No. " & xdtFormato.ValueField("nCodigo")

            '-- Incluir Firmas Digitales de Elaboración/Autorización:
            StrPath = StrPathFirmaDigital()
            'Empleado que Imprime Estado de Cuenta:
            If BlnFirmaDigitalExiste(StrPath & "F" & StrCodigoE & ".jpg") Then
                Me.picFirmaNotificador.Image = System.Drawing.Image.FromFile(StrPath & "F" & StrCodigoE & ".jpg")
            Else
                MsgBox("No se ha capturado Firma Digital de responsable de Impresión.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txtMonto.Text = Format(Me.txtMonto.Value, "#,##0.00")
        'Me.txtMontoS.Text = Format(Me.txtMontoS.Value, "#,##0.00")
        Me.txtMontoP.Text = Format(Me.txtMontoP.Value, "#,##0.00")
        Me.txtSaldoA.Text = Format(Me.txtSaldoA.Value, "#,##0.00")
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        'Me.txtTotalS.Text = Format(Me.txtTotalS.Value, "C$ ##,###,###,##0.00")
        Me.txtTotalA.Text = Format(Me.txtTotalA.Value, "C$ ##,###,###,##0.00")
        Me.txtTotalP.Text = Format(Me.txtTotalP.Value, "C$ ##,###,###,##0.00")
        Me.txtTotalSaldo.Text = Format(Me.txtTotalSaldo.Value, "C$ ##,###,###,##0.00")
    End Sub

    Private Sub grpGrupo_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpGrupo.Format
        Me.txtFechaD.Text = Format(Me.txtFechaD.Value, "dd/MM/yyyy")
        Me.txtFechaC.Text = Format(Me.txtFechaC.Value, "dd/MM/yyyy")
    End Sub
End Class