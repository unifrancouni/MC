'----------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                03/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSclPagare.vb
' Descripci�n:          Formulario para impresi�n de Pagar� por Grupo Solidario:
'                                  o Pagar�.		     
'----------------------------------------------------------------------------
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclPagare

    'Declaracion de Variables
    Dim objEncabeza As rptEncabezadoV
    Dim xdtFormato As BOSistema.Win.XDataSet.xDataTable

    'Datos del Grupo Solidario
    Dim mIdFicha As Long
    Dim mCodigoFicha As String
    Dim mNombreGrupo As String 'C�digo y Nombre.
    Dim mEstado As String

    '-- Par�metros:
    Dim DblTasaInteres As Double
    Dim DblTasaMora As Double
    Dim DblTasaMantenimiento As Double

    Dim StrTasaInteres As String
    Dim StrTasaMora As String
    Dim StrTasaMantenimiento As String

    Dim StrPlazoCuotas As String

    'Descripci�n del Estado de la FNC.
    Public Property Estado() As String
        Get
            Estado = mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property

    'Descripci�n del Grupo (C�digo y Nombre) de la FNC
    Public Property NombreGrupo() As String
        Get
            NombreGrupo = mNombreGrupo
        End Get
        Set(ByVal value As String)
            mNombreGrupo = value
        End Set
    End Property

    'ID de la Ficha de Notificaci�n:
    Public Property IdFicha() As Long
        Get
            IdFicha = mIdFicha
        End Get
        Set(ByVal value As Long)
            mIdFicha = value
        End Set
    End Property

    'Descripci�n del Grupo Solidario para los Par�metros:
    Public Property CodigoFicha() As String
        Get
            CodigoFicha = mCodigoFicha
        End Get
        Set(ByVal value As String)
            mCodigoFicha = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                03/10/2007
    ' Procedure Name:       PageHeader1_Format
    ' Descripci�n:          Permite asignar Formato del PageHeader.
    '-------------------------------------------------------------------------
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            'Ficha Anulada o Ficha Anulada con Regeneraci�n:
            If (Me.mEstado = "4") Or (Me.mEstado = "5") Then
                Me.lblAnulada.Visible = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                03/10/2007
    ' Procedure Name:       EncabezadoReporte_Format
    ' Descripci�n:          Asigna Sub-reporte para Encabezado.
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
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	03/10/2007
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
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	03/10/2007
    ' Procedure name		   	:	CargarPagare
    ' Description			   	:	Cargar los datos del Acta de Compromiso del Grupo Solidario.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarPagare()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables: nNumeroPagare = nCodigo
            Strsql = ""
            Strsql = " Select nSclFichaNotificacionID, nCoordinador, " & _
                     "        nCodigo, " & _
                     "        NombreGrupo, " & _
                     "        Socia," & _
                     "        sNumeroCedula, " & _
                     "        sDireccionSocia, " & _
                     "        NombreCoordinadora, " & _
                     "        MunicipioCoordinadora, " & _
                     "        CedulaCoordinadora, " & _
                     "        DireccionCoordinadora, " & _
                     "        dFechaHoraEntregaCK, " & _
                     "        dFechaPrimerCuota, " & _
                     "        dFechaUltimaCuota, " & _
                     "        MontoGS, " & _
                     "        nMontoTCambio, nTasaInteresAnual, nTasaMoraAnual, nTasaMantValorAnual " & _
                     " From vwSclPagareRep " & _
                     " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & mIdFicha & ") " & _
                     " Order by nCoordinador DESC, sNumeroCedula "

            xdtFormato.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	03/10/2007
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar par�metros del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Tasa de Interes para colocacion de Prestamos:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 1)"
            DblTasaInteres = XcDatos.ExecuteScalar(Strsql)
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 22)"
            StrTasaInteres = XcDatos.ExecuteScalar(Strsql)

            'Tasa de Mantenimiento de Valor:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 2)"
            DblTasaMantenimiento = XcDatos.ExecuteScalar(Strsql)
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 23)"
            StrTasaMantenimiento = XcDatos.ExecuteScalar(Strsql)

            'Tasa de Mora:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 3)"
            DblTasaMora = XcDatos.ExecuteScalar(Strsql)
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 24)"
            StrTasaMora = XcDatos.ExecuteScalar(Strsql)

            'Plazo predeterminado para Cr�ditos:
            Strsql = "SELECT b.sDescripcion FROM StbValorParametro a INNER JOIN StbValorCatalogo b ON a.sValorParametro = b.nStbValorCatalogoID WHERE (a.nStbParametroID = 6)"
            StrPlazoCuotas = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	04/10/2007
    ' Procedure name		   	:	IncrementaFirma
    ' Description			   	:	Esta Funcion permite incrementar el n�mero de 
    '                           :   impresi�n de un determinado Pagar�.
    ' -----------------------------------------------------------------------------------------
    Private Sub IncrementaImpresionPagare(ByVal FichaID As Long)
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim StrSql As String
            StrSql = "UPDATE SclFichaNotificacionCredito " & _
                     "SET nNumImpresionPagare = nNumImpresionPagare + 1, dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                     "WHERE (nSclFichaNotificacionID = " & FichaID & ")"
            XcDatos.ExecuteNonQuery(StrSql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub rptSclPagare_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            xdtFormato.Close()
            xdtFormato = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	03/10/2007
    ' Procedure name		   	:	rptSclActaCompromiso_ReportStart
    ' Description			   	:	Inicializaci�n del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub rptSclPagare_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Try

            Dim StrSociasGrupo As String
            Dim StrDepartamento As String
            Dim StrSql As String
            Dim DblMontoDolares As Double = 0
            Dim StrEspacio As String

            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarPagare()

            If xdtFormato.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtFormato.Table

            EncuentraParametros()
            'lblNumero.Text = "No. CS6-" & xdtFormato.ValueField("nNumeroPagare")
            'lblNumero.Text = "No. " & xdtFormato.ValueField("nNumeroPagare")
            lblNumero.Text = "No. " & xdtFormato.ValueField("nCodigo")

            lblCuotas.Text = "PAGO EN CUOTA " & UCase(StrPlazoCuotas)
            If xdtFormato.ValueField("nMontoTCambio") > 0 Then
                DblMontoDolares = xdtFormato.ValueField("MontoGS") / xdtFormato.ValueField("nMontoTCambio")
            End If

            'Encuentra Socias del Grupo:
            StrSql = " EXEC SpSclPagareSocias " & mIdFicha
            StrSociasGrupo = XcDatosSocias.ExecuteScalar(StrSql)

            '------------------------
            'Text Encabezado: 
            'rtbEncabezado.Font = New System.Drawing.Font("Arial", 11, FontStyle.Regular)
            'rtbEncabezado.SelectionAlignment = TextAlignment.Justify
            StrEspacio = "<font face='Arial' color='#FFFFFF' style='text-align: justify'>#<font face='Arial' color='#000000' style='text-align: justify'>"

            rtbEncabezado.Html = "<font face='Arial' color='#000000' style='text-align: justify'> Nosotras," & StrEspacio & "<b>" & StrSociasGrupo & "</b>" & StrEspacio & "y en representaci�n del" & _
                    " Grupo Solidario" & StrEspacio & "<b><u>" & UCase(xdtFormato.ValueField("NombreGrupo")).ToString.Replace(" ", "_") & "</u>, " & UCase(xdtFormato.ValueField("NombreCoordinadora")) & _
                    " </b>" & StrEspacio & "del domicilio de la Ciudad de " & xdtFormato.ValueField("MunicipioCoordinadora") & ", por este Pagar� a la Orden Causal," & _
                    " pagaremos al" & StrEspacio & "<b> PROGRAMA USURA CERO </b>," & _
                    " o a su orden, en sus oficinas de esta ciudad o en cualquier otra oficina que USURA CERO elija, por igual valor recibido a entera" & _
                    " satisfacci�n en calidad de mutuo, la suma de" & StrEspacio & "<b>" & UCase(NroEnLetras(xdtFormato.ValueField("MontoGS"), True, "C�rdoba", "C�rdobas")) & " (" & Format(xdtFormato.ValueField("MontoGS"), "C$ ###,###,###,##0.00") & ")</b>, " & _
                    " monto que pagaremos en c�rdobas con mantenimiento de valor o en" & _
                    " d�lares de los Estados Unidos de Am�rica, a la tasa de cambio oficial estipulada por el Banco Central de Nicaragua en la fecha de cada" & _
                    " abono, pagos que haremos, a partir del" & StrEspacio & "<b>" & Format(xdtFormato.ValueField("dFechaPrimerCuota"), "dd' de 'MMMM' del a�o 'yyyy") & "</b>, hasta el vencimiento final de esta obligaci�n, el d�a" & StrEspacio & "<b>" & Format(xdtFormato.ValueField("dFechaUltimaCuota"), "dd' de 'MMMM' del a�o 'yyyy") & "</b>.-" & _
                    " Con cada cuota de abono al principal nos obligamos a pagar intereses corrientes a la tasa" & _
                    " del " & UCase(NroEnLetras(xdtFormato.ValueField("nTasaInteresAnual"), True, "POR CIENTO", "POR CIENTO")) & " (<b>" & Format(xdtFormato.ValueField("nTasaInteresAnual"), "#,##0.00") & " %</b>) anual sobre saldos, y desde ahora aceptamos.-" & _
                    " En caso de presentarse cualquier causal de mora, pagaremos sobre los saldos de principal, desde esa fecha hasta la" & _
                    " cancelaci�n total de la obligaci�n, adem�s del inter�s corriente establecido, un recargo adicional" & _
                    " del " & UCase(NroEnLetras(xdtFormato.ValueField("nTasaMoraAnual"), True, "POR CIENTO", "POR CIENTO")) & " (<b>" & Format(xdtFormato.ValueField("nTasaMoraAnual"), "#,##0.00") & " %</b>) anual en concepto de intereses penales.-" & _
                    " Trat�ndose de un cr�dito con fondos intermediados, expresamente aceptamos que en caso de mora, la tasa de inter�s" & _
                    " corriente var�e autom�ticamente y, desde esa misma fecha, se aplique y se tenga por incorporada a este Pagar� a la" & _
                    " Orden Causal, la que PROGRAMA USURA CERO cobra en los cr�ditos de igual clase otorgados con fondos propios.-"


            'rtbEncabezado.Html = "<font face='Arial' color='#000000' style='text-align: justify'> Nosotras," & StrEspacio & "<b>" & StrSociasGrupo & "</b>" & StrEspacio & "y en representaci�n del" & _
            '                    " Grupo Solidario" & StrEspacio & "<b><u>" & UCase(xdtFormato.ValueField("NombreGrupo")).ToString.Replace(" ", "_") & "</u>, " & UCase(xdtFormato.ValueField("NombreCoordinadora")) & _
            '                    " </b>" & StrEspacio & "del domicilio de la Ciudad de " & xdtFormato.ValueField("MunicipioCoordinadora") & ", por este Pagar� a la Orden Causal," & _
            '                    " pagaremos al" & StrEspacio & "<b> MINISTERIO DE FOMENTO, INDUSTRIA Y COMERCIO (MIFIC) A TRAVES DEL PROGRAMA USURA CERO </b>," & _
            '                    " o a su orden, en sus oficinas de esta ciudad o en cualquier otra oficina que MIFIC/USURA CERO elija, por igual valor recibido a entera" & _
            '                    " satisfacci�n en calidad de mutuo, la suma de" & StrEspacio & "<b>" & UCase(NroEnLetras(xdtFormato.ValueField("MontoGS"), True, "C�rdoba", "C�rdobas")) & " (" & Format(xdtFormato.ValueField("MontoGS"), "C$ ###,###,###,##0.00") & ")</b>, " & _
            '                    " monto que pagaremos en c�rdobas con mantenimiento de valor o en" & _
            '                    " d�lares de los Estados Unidos de Am�rica, a la tasa de cambio oficial estipulada por el Banco Central de Nicaragua en la fecha de cada" & _
            '                    " abono, pagos que haremos, a partir del" & StrEspacio & "<b>" & Format(xdtFormato.ValueField("dFechaPrimerCuota"), "dd' de 'MMMM' del a�o 'yyyy") & "</b>, hasta el vencimiento final de esta obligaci�n, el d�a" & StrEspacio & "<b>" & Format(xdtFormato.ValueField("dFechaUltimaCuota"), "dd' de 'MMMM' del a�o 'yyyy") & "</b>.-" & _
            '                    " Con cada cuota de abono al principal nos obligamos a pagar intereses corrientes a la tasa" & _
            '                    " del " & StrTasaInteres & " (<b>" & Format(DblTasaInteres, "#,##0.00") & " %</b>) anual sobre saldos, y desde ahora aceptamos.-" & _
            '                    " En caso de presentarse cualquier causal de mora, pagaremos sobre los saldos de principal, desde esa fecha hasta la" & _
            '                    " cancelaci�n total de la obligaci�n, adem�s del inter�s corriente establecido, un recargo adicional" & _
            '                    " del " & StrTasaMora & " (<b>" & Format(DblTasaMora, "#,##0.00") & " %</b>) anual en concepto de intereses penales.-" & _
            '                    " Trat�ndose de un cr�dito con fondos intermediados, expresamente aceptamos que en caso de mora, la tasa de inter�s" & _
            '                    " corriente var�e autom�ticamente y, desde esa misma fecha, se aplique y se tenga por incorporada a este Pagar� a la" & _
            '                    " Orden Causal, la que MIFIC/PROGRAMA USURA CERO cobra en los cr�ditos de igual clase otorgados con fondos propios.-"

            'rtbEncabezado.Html = "<font face='Arial' color='#000000' style='text-align: justify'> Nosotras," & StrEspacio & "<b>" & StrSociasGrupo & "</b>" & StrEspacio & "y en representaci�n del" & _
            '                     " Grupo Solidario" & StrEspacio & "<b><u>" & UCase(xdtFormato.ValueField("NombreGrupo")).ToString.Replace(" ", "_") & "</u>, " & UCase(xdtFormato.ValueField("NombreCoordinadora")) & _
            '                     " </b>" & StrEspacio & "del domicilio de la Ciudad de " & xdtFormato.ValueField("MunicipioCoordinadora") & ", por este Pagar� a la Orden Causal," & _
            '                     " pagaremos al" & StrEspacio & "<b> MINISTERIO DE FOMENTO, INDUSTRIA Y COMERCIO (MIFIC) A TRAVES DEL PROGRAMA USURA CERO </b>," & _
            '                     " o a su orden, en sus oficinas de esta ciudad o en cualquier otra oficina que MIFIC/USURA CERO elija, por igual valor recibido a entera" & _
            '                     " satisfacci�n en calidad de mutuo, la suma de" & StrEspacio & "<b>" & UCase(NroEnLetras(xdtFormato.ValueField("MontoGS"), True, "C�rdoba", "C�rdobas")) & " (" & Format(xdtFormato.ValueField("MontoGS"), "C$ ###,###,###,##0.00") & ")</b>, equivalentes" & _
            '                     " a " & UCase(NroEnLetras(DblMontoDolares, True, "D�lar", "D�lares")) & " (" & Format(DblMontoDolares, "US$ ###,###,###,##0.00") & ") al tipo de cambio oficial de C$ " & xdtFormato.ValueField("nMontoTCambio") & " x US$1.00," & _
            '                     " del d�a " & Format(xdtFormato.ValueField("dFechaHoraEntregaCK"), "dd' de 'MMMM' del a�o 'yyyy") & ", monto que pagaremos en c�rdobas con mantenimiento de valor o en" & _
            '                     " d�lares de los Estados Unidos de Am�rica, a la tasa de cambio oficial estipulada por el Banco Central de Nicaragua en la fecha de cada" & _
            '                     " abono, pagos que haremos, a partir del " & Format(xdtFormato.ValueField("dFechaPrimerCuota"), "dd' de 'MMMM' del a�o 'yyyy") & ", hasta el vencimiento final de esta obligaci�n, el d�a " & Format(xdtFormato.ValueField("dFechaUltimaCuota"), "dd' de 'MMMM' del a�o 'yyyy") & ".-" & _
            '                     " Con cada cuota de abono al principal nos obligamos a pagar intereses corrientes a la tasa" & _
            '                     " del " & StrTasaInteres & " (<b>" & Format(DblTasaInteres, "#,##0.00") & " %</b>) anual sobre saldos, y desde ahora aceptamos.-" & _
            '                     " En caso de presentarse cualquier causal de mora, pagaremos sobre los saldos de principal, desde esa fecha hasta la" & _
            '                     " cancelaci�n total de la obligaci�n, adem�s del inter�s corriente establecido, un recargo adicional" & _
            '                     " del " & StrTasaMora & " (<b>" & Format(DblTasaMora, "#,##0.00") & " %</b>) anual en concepto de intereses penales.-" & _
            '                     " Trat�ndose de un cr�dito con fondos intermediados, expresamente aceptamos que en caso de mora, la tasa de inter�s" & _
            '                     " corriente var�e autom�ticamente y, desde esa misma fecha, se aplique y se tenga por incorporada a este Pagar� a la" & _
            '                     " Orden Causal, la que MIFIC/PROGRAMA USURA CERO cobra en los cr�ditos de igual clase otorgados con fondos propios.-"

            'Text Fianza Solidaria:
            rtbPie.Html = "<font face='Arial'><p style='text-align: justify'> Nosotras, " & StrEspacio & "<b>" & StrSociasGrupo & _
                          "</b>  " & StrEspacio & "nos constituimos Fiadoras Solidarias por el principal, intereses y" & _
                          " obligaciones contenidas en el PAGARE A LA ORDEN CAUSAL que antecede suscrito por" & _
                          " EL GRUPO SOLIDARIO " & StrEspacio & " <b><u>" & UCase(xdtFormato.ValueField("NombreGrupo")).ToString.Replace(" ", "_") & "</b></u>" & StrEspacio & " a favor del" & _
                          " PROGRAMA USURA CERO" & _
                          " en los mismos t�rminos y condiciones. Acepto (aceptamos) que esta solidaridad no se" & _
                          " suspender� por el hecho que PROGRAMA USURA CERO reciba cantidades anticipadas de dinero," & _
                          " del principal o intereses, o despu�s de vencido el plazo estipulado o por pr�rroga de" & _
                          " este, la que de antemano autorizo (autorizamos) a PROGRAMA USURA CERO para concederla," & _
                          " sin que la falta de aviso previo vicie mi (nuestra) solidaridad en todos y cada uno de sus" & _
                          " t�rminos, siendo entendido que esta solidaridad subsistir� hasta que la presente obligaci�n" & _
                          " le sea completamente cancelada.</p>"

            'Encuentra Departamento del Grupo Solidario:
            StrSql = " SELECT UG.Departamento " & _
                     " FROM SclFichaNotificacionCredito AS FNC INNER JOIN SclGrupoSolidario AS GS ON FNC.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica AS UG ON GS.nStbBarrioVerificadoID = UG.nStbBarrioID " & _
                     " WHERE (FNC.nSclFichaNotificacionID = " & mIdFicha & ")"
            StrDepartamento = XcDatosSocias.ExecuteScalar(StrSql)

            lblFirmaPagare.Text = "Firmamos en la ciudad de " & StrDepartamento & ", el " & Format(xdtFormato.ValueField("dFechaHoraEntregaCK"), "dd' de 'MMMM' del a�o 'yyyy") & "."
            IncrementaImpresionPagare(mIdFicha)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosSocias.Close()
            XcDatosSocias = Nothing
        End Try
    End Sub
End Class