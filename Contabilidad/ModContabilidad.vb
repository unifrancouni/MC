Module ModContabilidad
    Public gUltimoDiaMes As Integer
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	12/11/2007
    ' Procedure name		   	:	IDEjercicio
    ' Description			   	:	Regresa el Id de Ejercicio dada la fecha. 0 en caso
    '                               de no encontrarse registrado el Año.
    ' -----------------------------------------------------------------------------------------
    Public Function IDEjercicio(ByVal dFecha As Date) As Integer

        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtTmpEjercicio As BOSistema.Win.XDataSet.xDataTable
        XdtTmpEjercicio = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrSql As String
            IDEjercicio = 0

            'Busca el registro en periodos según fecha de transacción:
            StrSql = "SELECT nScnPeriodoContableID FROM ScnPeriodoContable WHERE (nAnio = " & Year(dFecha) & ") AND (nMes = " & Month(dFecha) & " )"
            XdtTmpEjercicio.ExecuteSql(StrSql)
            If XdtTmpEjercicio.Count > 0 Then
                IDEjercicio = XcDatos.ExecuteScalar(StrSql)
            End If

        Catch ex As Exception
            Control_Error(ex)
            IDEjercicio = 0
        Finally
            XdtTmpEjercicio.Close()
            XdtTmpEjercicio = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try

    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     12/11/2007
    ' Procedure name                :     EjercicioAbierto
    ' Description                   :     Indica si el Ejercicios se encuentra Abierto.
    ' -----------------------------------------------------------------------------------------
    Public Function EjercicioAbierto(ByVal nIdEjercicio As Integer) As Boolean

        Dim XdtTmpEjercicios As BOSistema.Win.XDataSet.xDataTable
        XdtTmpEjercicios = New BOSistema.Win.XDataSet.xDataTable

        Try
            EjercicioAbierto = False
            XdtTmpEjercicios.ExecuteSql("SELECT nCerrado FROM  ScnEjercicioContable WHERE (nScnEjercicioContableID = " & nIdEjercicio & ") AND (nCerrado = 0)")
            If XdtTmpEjercicios.Count > 0 Then
                EjercicioAbierto = True
            End If

        Catch ex As Exception
            Control_Error(ex)
            EjercicioAbierto = False
        Finally
            XdtTmpEjercicios.Close()
            XdtTmpEjercicios = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	12/11/2007
    ' Procedure name		   	:	IDPeriodo
    ' Description			   	:	Regresa el Id de Periodo dada la fecha. 0 en caso
    '                               de no encontrarse registrado el período.
    ' -----------------------------------------------------------------------------------------
    Public Function IDPeriodo(ByVal dFecha As Date) As Integer

        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtTmpPeriodo As BOSistema.Win.XDataSet.xDataTable
        XdtTmpPeriodo = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrSql As String
            IDPeriodo = 0

            'Busca el registro en periodos según fecha de transacción:
            StrSql = "SELECT nScnPeriodoContableID FROM ScnPeriodoContable WHERE (nAnio = " & Year(dFecha) & ") AND (nMes = " & Month(dFecha) & " )"
            XdtTmpPeriodo.ExecuteSql(StrSql)
            If XdtTmpPeriodo.Count > 0 Then
                IDPeriodo = XcDatos.ExecuteScalar(StrSql)
            End If

        Catch ex As Exception
            Control_Error(ex)
            IDPeriodo = 0
        Finally
            XdtTmpPeriodo.Close()
            XdtTmpPeriodo = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     12/11/2007
    ' Procedure name                :     PeriodoAbierto
    ' Description                   :     Indica si el Periodo se encuentra Abierto.
    ' -----------------------------------------------------------------------------------------
    Public Function PeriodoAbierto(ByVal nIdPeriodo As Integer) As Boolean

        Dim XdtTmpPeriodoA As BOSistema.Win.XDataSet.xDataTable
        XdtTmpPeriodoA = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrSql As String
            PeriodoAbierto = True

            StrSql = "SELECT Catalogo.sCodigoInterno " & _
                     "FROM  ScnPeriodoContable AS PER INNER JOIN StbValorCatalogo AS Catalogo ON PER.nStbEstadoPeriodoID = Catalogo.nStbValorCatalogoID " & _
                     "WHERE (PER.nScnPeriodoContableID = " & nIdPeriodo & ") AND (Catalogo.sCodigoInterno = '3')"
            XdtTmpPeriodoA.ExecuteSql(StrSql)
            If XdtTmpPeriodoA.Count > 0 Then
                PeriodoAbierto = False
            End If

        Catch ex As Exception
            Control_Error(ex)
            PeriodoAbierto = False
        Finally
            XdtTmpPeriodoA.Close()
            XdtTmpPeriodoA = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     12/11/2007
    ' Procedure name                :     PeriodoAbiertoDadaFecha
    ' Description                   :     Indica si el Periodo se encuentra Abierto. Al haberse
    '                                     dado como parámetro la Fecha de la transacción.
    ' -----------------------------------------------------------------------------------------
    Public Function PeriodoAbiertoDadaFecha(ByVal dFecha As Date) As Boolean

        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtTmpPeriodo As BOSistema.Win.XDataSet.xDataTable
        XdtTmpPeriodo = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrSql As String
            PeriodoAbiertoDadaFecha = True

            'Busca el registro con Cierre Definitivo en periodos según fecha de transacción:
            StrSql = "SELECT  ScnPeriodoContable.nScnPeriodoContableID FROM ScnPeriodoContable INNER JOIN StbValorCatalogo ON ScnPeriodoContable.nStbEstadoPeriodoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (ScnPeriodoContable.nAnio = " & Year(dFecha) & ") AND (ScnPeriodoContable.nMes = " & Month(dFecha) & ") AND (StbValorCatalogo.sCodigoInterno = '3')"
            XdtTmpPeriodo.ExecuteSql(StrSql)
            If XdtTmpPeriodo.Count > 0 Then
                PeriodoAbiertoDadaFecha = False
            End If

        Catch ex As Exception
            Control_Error(ex)
            PeriodoAbiertoDadaFecha = False
        Finally
            XdtTmpPeriodo.Close()
            XdtTmpPeriodo = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    Public Function FechaDadoPeriodoIdSigMes(ByVal IntPeriodoId As Integer) As Date
        Dim XdtTmpPeriodo As BOSistema.Win.XDataSet.xDataTable
        XdtTmpPeriodo = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrSql As String
            'Busca el registro en periodos según ID:
            StrSql = "SELECT * FROM ScnPeriodoContable WHERE (nScnPeriodoContableID = " & IntPeriodoId & ")"
            XdtTmpPeriodo.ExecuteSql(StrSql)
            If XdtTmpPeriodo.Count > 0 Then
                FechaDadoPeriodoIdSigMes = "01/" & Format(XdtTmpPeriodo.ValueField("nMes"), "00") & "/" & XdtTmpPeriodo.ValueField("nAnio")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpPeriodo.Close()
            XdtTmpPeriodo = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     23/11/2007
    ' Procedure name                :     FechaDadoPeriodoId
    ' Description                   :     Devuelve fecha dado Periodo Id.
    ' -----------------------------------------------------------------------------------------
    Public Function FechaDadoPeriodoId(ByVal IntPeriodoId As Integer) As Date
        Dim XdtTmpPeriodo As BOSistema.Win.XDataSet.xDataTable
        XdtTmpPeriodo = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrSql As String
            'Busca el registro en periodos según ID:
            StrSql = "SELECT * FROM ScnPeriodoContable WHERE (nScnPeriodoContableID = " & IntPeriodoId & ")"
            XdtTmpPeriodo.ExecuteSql(StrSql)
            If XdtTmpPeriodo.Count > 0 Then
                FechaDadoPeriodoId = "01/" & Format(XdtTmpPeriodo.ValueField("nMes"), "00") & "/" & XdtTmpPeriodo.ValueField("nAnio")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpPeriodo.Close()
            XdtTmpPeriodo = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     12/11/2007
    ' Procedure name                :     Aplica_AnulaTransaccion
    ' Description                   :     Mayoriza o Revierte los Saldos Contables dado un
    '                                     ID de Transacción Contable.
    ' -----------------------------------------------------------------------------------------
    Public Sub Aplica_Anula_Transaccion(ByVal IdTransaccion As Long, ByVal IntAplicar As Integer)

        Dim IntRegistros As Integer
        Dim IntRegistrosC As Integer

        Dim IntPeriodoId As Integer
        Dim IntCatalogoId As Integer
        Dim IntDigitos As Integer
        Dim StrCodCuentaSumatoria As String
        Dim StrSql As String

        Dim XcDatos As New BOSistema.Win.XComando

        Dim XdtTmpDetallesComprobantes As BOSistema.Win.XDataSet.xDataTable
        XdtTmpDetallesComprobantes = New BOSistema.Win.XDataSet.xDataTable

        Dim XdtTmpCatalogoCble As BOSistema.Win.XDataSet.xDataTable
        XdtTmpCatalogoCble = New BOSistema.Win.XDataSet.xDataTable

        Try
            'Detalles de Comprobantes de Diario:
            StrSql = "SELECT D.nScnTransaccionContableDetalleID, D.nScnTransaccionContableID, D.nScnCatalogoContableID, Catalogo.nScnFuenteFinanciamientoID, Catalogo.nCuentaPadreID, E.dFechaTransaccion, E.dFechaTipoCambio, D.nDebito, D.nMontoC, D.nMontoD, Catalogo.sCodigoCuenta, Estructura.nDigitosNivel, dbo.ScnFuenteFinanciamiento.sCodigo AS CodFuente, Estructura.nNivel " _
                    & "FROM  ScnCatalogoContable AS Catalogo INNER JOIN ScnTransaccionContableDetalle AS D ON Catalogo.nScnCatalogoContableID = D.nScnCatalogoContableID INNER JOIN  ScnTransaccionContable AS E ON D.nScnTransaccionContableID = E.nScnTransaccionContableID " _
                    & "INNER JOIN ScnEstructuraContable AS Estructura ON Catalogo.nScnEstructuraContableID = Estructura.nScnEstructuraContableID INNER JOIN ScnFuenteFinanciamiento ON Catalogo.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " _
                    & "Where (D.nScnTransaccionContableID = " & IdTransaccion & ") ORDER BY D.nScnTransaccionContableDetalleID"
            XdtTmpDetallesComprobantes.ExecuteSql(StrSql)

            IntPeriodoId = IDPeriodo(XdtTmpDetallesComprobantes.ValueField("dFechaTransaccion"))
            IntDigitos = XcDatos.ExecuteScalar("SELECT nDigitosNivel FROM ScnEstructuraContable WHERE (nNivel = 1)")
            IntRegistros = XdtTmpDetallesComprobantes.Count

            'XdtTmpDetallesComprobantes.Source.MoveFirst()
            While IntRegistros > 0

                'Encontrar Cuenta Sumatoria:
                StrCodCuentaSumatoria = Left(XdtTmpDetallesComprobantes.ValueField("sCodigoCuenta"), IntDigitos + Len(XdtTmpDetallesComprobantes.ValueField("CodFuente")) + 1)

                'Encontrar Id desde Cuenta Detalle hasta Cuenta Sumatoria (Ruta Mayorización):
                StrSql = "SELECT  Estructura.nNivel, MAX(Catalogo.sCodigoCuenta) AS Cod " _
                       & "FROM ScnCatalogoContable Catalogo INNER JOIN ScnEstructuraContable Estructura ON Catalogo.nScnEstructuraContableID = Estructura.nScnEstructuraContableID " _
                       & "WHERE (Catalogo.nScnFuenteFinanciamientoID = " & XdtTmpDetallesComprobantes.ValueField("nScnFuenteFinanciamientoID") & ") AND (Catalogo.sCodigoCuenta BETWEEN '" & StrCodCuentaSumatoria & "' AND '" & XdtTmpDetallesComprobantes.ValueField("sCodigoCuenta") & "') " _
                       & "GROUP BY Estructura.nNivel HAVING (Estructura.nNivel <= " & XdtTmpDetallesComprobantes.ValueField("nNivel") & ") ORDER BY Cod DESC"
                XdtTmpCatalogoCble.ExecuteSql(StrSql)
                IntRegistrosC = XdtTmpCatalogoCble.Count
                While IntRegistrosC > 0

                    IntCatalogoId = XcDatos.ExecuteScalar("SELECT ScnCatalogoContable.nScnCatalogoContableID FROM ScnCatalogoContable WHERE (sCodigoCuenta = '" & XdtTmpCatalogoCble.ValueField("Cod") & "') AND (nScnFuenteFinanciamientoID = " & XdtTmpDetallesComprobantes.ValueField("nScnFuenteFinanciamientoID") & ")")
                    'Encuentra registro en Saldos con el Id Cta y Periodo creandolo si no existe:
                    If RegistrosAsociados("SELECT * FROM ScnSaldoContable WHERE (nScnPeriodoContableID = " & IntPeriodoId & ") AND (nScnCatalogoContableID = " & IntCatalogoId & ")") = False Then
                        StrSql = "Insert Into ScnSaldoContable " & _
                                 "(nScnCatalogoContableID, nScnPeriodoContableID, nUsuarioCreacionID, dFechaCreacion) " & _
                                 " Values (" & IntCatalogoId & ", " & IntPeriodoId & ", " & InfoSistema.IDCuenta & "," & "GetDate())"
                        XcDatos.ExecuteNonQuery(StrSql)
                    End If

                    'Actualiza Movimientos:
                    If XdtTmpDetallesComprobantes.ValueField("nDebito") = 1 Then
                        If IntAplicar = 1 Then
                            StrSql = " Update ScnSaldoContable " & _
                                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dFechaModificacion = getdate(),  " & _
                                     " nDebitoPeriodoC = nDebitoPeriodoC + " & XdtTmpDetallesComprobantes.ValueField("nMontoC") & ", nDebitoPeriodoD = nDebitoPeriodoD + " & XdtTmpDetallesComprobantes.ValueField("nMontoD") & _
                                     " WHERE (nScnPeriodoContableID = " & IntPeriodoId & ") AND (nScnCatalogoContableID = " & IntCatalogoId & ")"
                        Else 'Anulación:
                            StrSql = " Update ScnSaldoContable " & _
                                    " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dFechaModificacion = getdate(),  " & _
                                    " nDebitoPeriodoC = nDebitoPeriodoC - " & XdtTmpDetallesComprobantes.ValueField("nMontoC") & ", nDebitoPeriodoD = nDebitoPeriodoD - " & XdtTmpDetallesComprobantes.ValueField("nMontoD") & _
                                    " WHERE (nScnPeriodoContableID = " & IntPeriodoId & ") AND (nScnCatalogoContableID = " & IntCatalogoId & ")"
                        End If
                        XcDatos.ExecuteNonQuery(StrSql)
                    Else 'Movimiento de Crédito:
                        If IntAplicar = 1 Then
                            StrSql = " Update ScnSaldoContable " & _
                                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dFechaModificacion = getdate(),  " & _
                                     " nCreditoPeriodoC = nCreditoPeriodoC + " & XdtTmpDetallesComprobantes.ValueField("nMontoC") & ", nCreditoPeriodoD = nCreditoPeriodoD + " & XdtTmpDetallesComprobantes.ValueField("nMontoD") & _
                                     " WHERE (nScnPeriodoContableID = " & IntPeriodoId & ") AND (nScnCatalogoContableID = " & IntCatalogoId & ")"
                        Else
                            StrSql = " Update ScnSaldoContable " & _
                                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dFechaModificacion = getdate(),  " & _
                                     " nCreditoPeriodoC = nCreditoPeriodoC - " & XdtTmpDetallesComprobantes.ValueField("nMontoC") & ", nCreditoPeriodoD = nCreditoPeriodoD - " & XdtTmpDetallesComprobantes.ValueField("nMontoD") & _
                                     " WHERE (nScnPeriodoContableID = " & IntPeriodoId & ") AND (nScnCatalogoContableID = " & IntCatalogoId & ")"
                        End If
                        XcDatos.ExecuteNonQuery(StrSql)
                    End If

                    XdtTmpCatalogoCble.Source.MoveNext()
                    IntRegistrosC = IntRegistrosC - 1
                    '---------------------------
                End While
                '---------------------------
                XdtTmpDetallesComprobantes.Source.MoveNext()
                IntRegistros = IntRegistros - 1
                '---------------------------
            End While

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtTmpDetallesComprobantes.Close()
            XdtTmpDetallesComprobantes = Nothing

            XdtTmpCatalogoCble.Close()
            XdtTmpCatalogoCble = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     15/11/2007
    ' Procedure name                :     nMontoSaldoRojo
    ' Description                   :     Verifica si un movimiento creará Saldos Rojos (en caso
    '                                     que la Cuenta tenga el Indicador nPermiteSobregiro = 0).
    '                                     Si (nMontoSaldoRojo < 0): El movimiento crearía Saldos 
    '                                     Rojos en la Cuenta Contable.  
    ' -----------------------------------------------------------------------------------------
    Public Function nMontoSaldoRojo(ByVal IdCatalogo As Long, ByVal BlnDebito As Boolean, ByVal nMonto As Double) As Double
        Dim XdtTmpMovimientos As BOSistema.Win.XDataSet.xDataTable
        XdtTmpMovimientos = New BOSistema.Win.XDataSet.xDataTable

        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim nCtaDeudora As Integer 'Naturaleza de la Cuenta Contable (D/H).
            Dim StrSql As String
            nMontoSaldoRojo = 0

            'Si la Cuenta permite Sobregiros salir de la Función:
            StrSql = "SELECT nPermiteSobregiro FROM ScnCatalogoContable WHERE (nScnCatalogoContableID = " & IdCatalogo & ")"
            If XcDatos.ExecuteScalar(StrSql) = 1 Then
                nMontoSaldoRojo = 0
                Exit Function
            End If
            'Determina Naturaleza de la Cuenta Contable:
            StrSql = "SELECT nCuentaDeudora FROM ScnCatalogoContable WHERE (nScnCatalogoContableID = " & IdCatalogo & ")"
            nCtaDeudora = XcDatos.ExecuteScalar(StrSql)

            'Encuentra posibles Movimientos de la Cuenta en Saldos Contables:
            'StrSql = "SELECT ScnCatalogoContable.nSaldoInicialC, a.Debe, a.Haber FROM ScnCatalogoContable INNER JOIN " _
            '       & "(SELECT nScnCatalogoContableID, ISNULL(nDebitoPeriodoC, 0) AS Debe, ISNULL(nCreditoPeriodoC, 0) AS Haber " _
            '       & "FROM ScnSaldoContable WHERE (nScnCatalogoContableID = " & IdCatalogo & ")) AS a ON ScnCatalogoContable.nScnCatalogoContableID = a.nScnCatalogoContableID"
            StrSql = "SELECT  ScnCatalogoContable.nSaldoInicialC, a.Debe, a.Haber " _
                   & "FROM  ScnCatalogoContable INNER JOIN " _
                   & "(SELECT  nScnCatalogoContableID, SUM(nDebitoPeriodoC) AS Debe, SUM(nCreditoPeriodoC) AS Haber " _
                   & "FROM  ScnSaldoContable GROUP BY nScnCatalogoContableID " _
                   & "HAVING  (nScnCatalogoContableID = " & IdCatalogo & ")) AS a ON dbo.ScnCatalogoContable.nScnCatalogoContableID = a.nScnCatalogoContableID"
            XdtTmpMovimientos.ExecuteSql(StrSql)

            'Si la cuenta ha tenido Movimientos:
            If XdtTmpMovimientos.Count > 0 Then    '*****Si la cuenta ha tenido Movimientos:
                If nCtaDeudora = 1 Then     'Naturaleza Deudora de la Cuenta Contable.
                    If BlnDebito Then       'Movimiento fue un Debito
                        nMontoSaldoRojo = (XdtTmpMovimientos.ValueField("nSaldoInicialC") + XdtTmpMovimientos.ValueField("Debe") - XdtTmpMovimientos.ValueField("Haber")) + nMonto
                    Else
                        nMontoSaldoRojo = (XdtTmpMovimientos.ValueField("nSaldoInicialC") + XdtTmpMovimientos.ValueField("Debe") - XdtTmpMovimientos.ValueField("Haber")) - nMonto
                    End If
                Else                        'Naturaleza Acreedora
                    If BlnDebito Then       'Movimiento fue un Débito.
                        nMontoSaldoRojo = (XdtTmpMovimientos.ValueField("nSaldoInicialC") - XdtTmpMovimientos.ValueField("Debe") + XdtTmpMovimientos.ValueField("Haber")) - nMonto
                    Else
                        nMontoSaldoRojo = (XdtTmpMovimientos.ValueField("nSaldoInicialC") - XdtTmpMovimientos.ValueField("Debe") + XdtTmpMovimientos.ValueField("Haber")) + nMonto
                    End If
                End If
            Else   '******Si la cuenta No ha tenido Movimientos:*******
                If nCtaDeudora = 1 Then     'Naturaleza Deudora de la Cuenta Contable.
                    If BlnDebito Then       'Movimiento fue un Debito.
                        nMontoSaldoRojo = nMonto
                    Else
                        nMontoSaldoRojo = nMonto * -1
                    End If
                Else                        'Naturaleza Acreedora
                    If BlnDebito Then       'Movimiento fue un Débito.
                        nMontoSaldoRojo = nMonto * -1
                    Else
                        nMontoSaldoRojo = nMonto
                    End If
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtTmpMovimientos.Close()
            XdtTmpMovimientos = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutierrez
    ' Date			    		:	27/11/2007
    ' Procedure name		   	:	nTasaCambio
    ' Description			   	:	Devuelve Tasa de cambio para una fecha determinada.
    ' -----------------------------------------------------------------------------------------
    Public Function nTasaCambio(ByVal dFechaTasa As DateTime) As Decimal

        'Declaracion de la Variable
        Dim StrSql As String
        Dim XdtTasaCambio As BOSistema.Win.XDataSet.xDataTable

        Try
            XdtTasaCambio = New BOSistema.Win.XDataSet.xDataTable
            'Encuentra Tasa de Cambio:
            StrSql = "SELECT nMontoTCambio " & _
                     "FROM  vwStbTasasDeCambio " & _
                     "WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(dFechaTasa, "yyyy-MM-dd") & "', 102))"
            XdtTasaCambio.ExecuteSql(StrSql)
            If XdtTasaCambio.Count = 1 Then
                Return XdtTasaCambio("nMontoTCambio")
            Else
                Return -1
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTasaCambio = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutierrez
    ' Date			    		:	12/12/2007
    ' Procedure name		   	:	NombreMes
    ' Description			   	:	Devuelve Nombre de un Mes Calendario.
    ' -----------------------------------------------------------------------------------------
    Public Function NombreMes(ByVal IntMes As Integer, ByVal IntAnnio As Integer) As String
        NombreMes = ""
        Try

            If IntMes = 1 Then
                NombreMes = "Enero"
                gUltimoDiaMes = 31
            ElseIf IntMes = 2 Then
                NombreMes = "Febrero"
                If IntAnnio Mod 4 = 0 Then 'El Año es Biciesto (Multiplo de Cuatro).
                    gUltimoDiaMes = 29
                Else
                    gUltimoDiaMes = 28
                End If
            ElseIf IntMes = 3 Then
                NombreMes = "Marzo"
                gUltimoDiaMes = 31
            ElseIf IntMes = 4 Then
                NombreMes = "Abril"
                gUltimoDiaMes = 30
            ElseIf IntMes = 5 Then
                NombreMes = "Mayo"
                gUltimoDiaMes = 31
            ElseIf IntMes = 6 Then
                NombreMes = "Junio"
                gUltimoDiaMes = 30
            ElseIf IntMes = 7 Then
                NombreMes = "Julio"
                gUltimoDiaMes = 31
            ElseIf IntMes = 8 Then
                NombreMes = "Agosto"
                gUltimoDiaMes = 31
            ElseIf IntMes = 9 Then
                NombreMes = "Septiembre"
                gUltimoDiaMes = 30
            ElseIf IntMes = 10 Then
                NombreMes = "Octubre"
                gUltimoDiaMes = 31
            ElseIf IntMes = 11 Then
                NombreMes = "Noviembre"
                gUltimoDiaMes = 30
            Else
                NombreMes = "Diciembre"
                gUltimoDiaMes = 31
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutierrez
    ' Date			    		:	10/01/2008
    ' Procedure name		   	:	IntUltimoDiaMes
    ' Description			   	:	Devuelve Ultimo Dia de un Mes Calendario.
    ' -----------------------------------------------------------------------------------------
    Public Function IntUltimoDiaMes(ByVal IntMes As Integer, ByVal IntAnnio As Integer) As Integer
        IntUltimoDiaMes = 0
        Try

            If (IntMes = 1) Or (IntMes = 3) Or (IntMes = 5) Or (IntMes = 7) Or (IntMes = 8) Or (IntMes = 10) Or (IntMes = 12) Then
                IntUltimoDiaMes = 31
            ElseIf IntMes = 2 Then
                If IntAnnio Mod 4 = 0 Then 'El Año es Biciesto (Multiplo de Cuatro).
                    IntUltimoDiaMes = 29
                Else
                    IntUltimoDiaMes = 28
                End If
            Else '(IntMes = 4), (IntMes = 6), (IntMes = 9), (IntMes = 11)
                IntUltimoDiaMes = 30
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutierrez
    ' Date			    		:	19/12/2007
    ' Procedure name		   	:	CerrarPeriodo
    ' Description			   	:	Cierra un Período Contable en forma Preliminar o Definitiva:
    '                               nCierreD = 0: Cierre Preliminar
    '                               nCierreD = 1 : Cierre(Definitivo)
    ' -----------------------------------------------------------------------------------------
    Public Sub CerrarPeriodo(ByVal IntPeriodoId As Integer, ByVal nCierreD As Integer, ByVal IntSiguientePeriodoId As Integer, ByVal IntUltimoPeriodoCerrado As Integer)

        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtTmpDetallesCierre As BOSistema.Win.XDataSet.xDataTable
        Try

            Dim IntRegistros As Integer
            Dim StrSql As String

            '-- Consulta de Saldos de Corte:
            XdtTmpDetallesCierre = New BOSistema.Win.XDataSet.xDataTable
            StrSql = "SELECT isnull(a.nSaldoInicialPeriodoC,0) AS nSaldoInicialPeriodoC, isnull(a.nSaldoInicialPeriodoD,0) AS nSaldoInicialPeriodoD, a.nScnCatalogoContableID, a.nCuentaDeudora, isnull(b.nDebitoPeriodoC,0) AS nDebitoPeriodoC, isnull(b.nDebitoPeriodoD,0) AS  nDebitoPeriodoD, isnull(b.nCreditoPeriodoC,0) AS nCreditoPeriodoC, isnull(b.nCreditoPeriodoD, 0) AS nCreditoPeriodoD, " _
                   & "(CASE a.nCuentaDeudora WHEN 1 THEN a.nSaldoInicialPeriodoC + b.nDebitoPeriodoC - b.nCreditoPeriodoC ELSE a.nSaldoInicialPeriodoC - b.nDebitoPeriodoC + b.nCreditoPeriodoC END) AS 'SaldoFinalCordobas', (CASE a.nCuentaDeudora WHEN 1 THEN a.nSaldoInicialPeriodoD + b.nDebitoPeriodoD - b.nCreditoPeriodoD ELSE a.nSaldoInicialPeriodoD - b.nDebitoPeriodoD + b.nCreditoPeriodoD END) AS 'SaldoFinalDolares' " _
                   & "FROM   (SELECT b.nSaldoInicialPeriodoC, b.nSaldoInicialPeriodoD, a.nScnCatalogoContableID, a.nScnPeriodoContableID, a.nCuentaDeudora FROM (SELECT b.nScnCatalogoContableID, MIN(b.nScnPeriodoContableID) AS nScnPeriodoContableID, a.nCuentaDeudora FROM ScnCatalogoContable a INNER JOIN ScnSaldoContable b ON  a.nScnCatalogoContableID = b.nScnCatalogoContableID " _
                   & "WHERE (b.nScnPeriodoContableID BETWEEN " & IntUltimoPeriodoCerrado & " AND " & IntPeriodoId & ") GROUP BY b.nScnCatalogoContableID, a.nCuentaDeudora) a INNER JOIN ScnSaldoContable b ON (a.nScnCatalogoContableID = b.nScnCatalogoContableID) AND (a.nScnPeriodoContableID = b.nScnPeriodoContableID)) a INNER JOIN " _
                   & "(SELECT SUM(b.nDebitoPeriodoC) AS nDebitoPeriodoC, SUM(b.nDebitoPeriodoD) AS nDebitoPeriodoD,SUM(b.nCreditoPeriodoC) AS nCreditoPeriodoC, SUM(b.nCreditoPeriodoD) AS nCreditoPeriodoD, b.nScnCatalogoContableID FROM ScnSaldoContable b  " _
                   & "WHERE (b.nScnPeriodoContableID BETWEEN " & IntUltimoPeriodoCerrado & " AND " & IntPeriodoId & ") GROUP BY b.nScnCatalogoContableID) b ON a.nScnCatalogoContableID = b.nScnCatalogoContableID "
            XdtTmpDetallesCierre.ExecuteSql(StrSql)
            '-- Determina Registros de la Transacción:
            IntRegistros = XdtTmpDetallesCierre.Count

            '-- Actualiza Saldo Inicial del Periodo con Saldos Finales calculados al Periodo Anterior:
            While IntRegistros > 0
                StrSql = "SELECT * From ScnSaldoContable  Where (nScnCatalogoContableID = " & XdtTmpDetallesCierre.ValueField("nScnCatalogoContableID") & ") And (nScnPeriodoContableID = " & IntSiguientePeriodoId & ")"
                If RegistrosAsociados(StrSql) = False Then
                    StrSql = "Insert Into ScnSaldoContable " & _
                             "(nScnCatalogoContableID, nScnPeriodoContableID, nDebitoPeriodoC, nDebitoPeriodoD, " & _
                             "nCreditoPeriodoC, nCreditoPeriodoD, nSaldoInicialPeriodoC, nSaldoInicialPeriodoD, nUsuarioCreacionID, dFechaCreacion) " & _
                             "Values (" & XdtTmpDetallesCierre.ValueField("nScnCatalogoContableID") & ", " & IntSiguientePeriodoId & _
                             ", 0, 0, 0, 0, " & XdtTmpDetallesCierre.ValueField("SaldoFinalCordobas") & " , " & XdtTmpDetallesCierre.ValueField("SaldoFinalDolares") & _
                             ", " & InfoSistema.IDCuenta & ", getdate())"
                Else
                    StrSql = "UPDATE ScnSaldoContable " & _
                             "SET nSaldoInicialPeriodoC = " & XdtTmpDetallesCierre.ValueField("SaldoFinalCordobas") & "," & _
                             "    nUsuarioModificacionID = " & InfoSistema.IDCuenta & "," & _
                             "    dFechaModificacion = getdate()" & "," & _
                             "    nSaldoInicialPeriodoD = " & XdtTmpDetallesCierre.ValueField("SaldoFinalDolares") & _
                             " WHERE (nScnPeriodoContableID = " & IntSiguientePeriodoId & ") AND (nScnCatalogoContableID = " & XdtTmpDetallesCierre.ValueField("nScnCatalogoContableID") & ")"
                End If

                XcDatos.ExecuteNonQuery(StrSql)
                '---------------------------
                XdtTmpDetallesCierre.Source.MoveNext()
                IntRegistros = IntRegistros - 1
                '---------------------------
            End While

            '-- Actualiza el Estado de Cierre para el Período Contable a Cerrar (P ó D):
            If nCierreD = 0 Then 'Cierre Preliminar (2)
                StrSql = " Update ScnPeriodoContable " & _
                        "  SET nStbEstadoPeriodoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoPeriodoContable'), " & _
                        "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & "," & _
                        "      dFechaModificacion = getdate()" & _
                        "  WHERE (nScnPeriodoContableID = " & IntPeriodoId & ")"
            Else    'Cierre Definitivo (3)
                StrSql = " Update ScnPeriodoContable " & _
                        "  SET nStbEstadoPeriodoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoPeriodoContable'), " & _
                        "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & "," & _
                        "      dFechaModificacion = getdate()" & _
                        "  WHERE (nScnPeriodoContableID = " & IntPeriodoId & ")"
            End If
            XcDatos.ExecuteNonQuery(StrSql)

            '-- Actualiza en Tabla Parámetros Ultimo Mes con Cierre Definitivo:
            'NOTA: La Tabla debe comerzar con Mes de Apertura Contable Indicado en Parámetros:
            If nCierreD = 1 Then
                StrSql = " UPDATE StbValorParametro SET sValorParametro = '" & IntPeriodoId & _
                         "' WHERE (nStbValorParametroID = 33)"
                XcDatos.ExecuteNonQuery(StrSql)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            'XdtTmpDetallesCierre.Close()
            XdtTmpDetallesCierre = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	20/05/2008
    ' Procedure name		   	:	StrPathFirmaDigital
    ' Description			   	:	Esta función permite encontrar ruta de localización
    '                               de firmas digitales de empleados del Programa.
    ' -----------------------------------------------------------------------------------------
    Public Function StrPathFirmaDigital() As String
        Dim objParametros As BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        objParametros = New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable

        Try
            objParametros.Filter = "nStbParametroId = 38"
            objParametros.Retrieve()
            If objParametros.Count > 0 Then
                StrPathFirmaDigital = objParametros("sValorParametro")
            Else
                StrPathFirmaDigital = ""
            End If

        Catch ex As Exception
            Control_Error(ex)
            StrPathFirmaDigital = ""
        Finally
            objParametros.Close()
            objParametros = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	21/05/2008
    ' Procedure name		   	:	BlnFirmaDigitalExiste
    ' Description			   	:	Verifica si existe la Firma Digial del Empleado
    '                               en el path especificado.
    ' -----------------------------------------------------------------------------------------
    Public Function BlnFirmaDigitalExiste(ByVal StrRutaFirma As String) As Boolean
        Try
            If My.Computer.FileSystem.FileExists(StrRutaFirma) Then
                BlnFirmaDigitalExiste = True
            Else
                BlnFirmaDigitalExiste = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     25/06/2008
    ' Procedure name                :     BlnFechaInferiorParametros
    ' Description                   :     Indica si la Fecha indicada es menor que la 
    '                                     fecha de inicio del Programa indicada en 
    '                                     parámetros (Parámetro ID = 4). 
    ' -----------------------------------------------------------------------------------------
    Public Function BlnFechaInferiorParametros(ByVal dFecha As Date) As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            Dim dFechaInicioPrograma As Date
            Dim sFechaInicioParametro As String
            BlnFechaInferiorParametros = False

            StrSql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 4)"
            sFechaInicioParametro = XcDatos.ExecuteScalar(StrSql)
            dFechaInicioPrograma = Mid(sFechaInicioParametro, 1, 2) + "/" + Mid(sFechaInicioParametro, 3, 2) + "/" + Mid(sFechaInicioParametro, 5, 4)
            'Fecha indicada no debe ser menor que la Fecha de Inicio del 
            'Programa indicada en parámetros:
            If (DateDiff("d", dFechaInicioPrograma, dFecha) < 0) Then
                BlnFechaInferiorParametros = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     25/06/2008
    ' Procedure name                :     BlnFechaSuperiorParametros
    ' Description                   :     Indica si la Fecha indicada es mayor que la 
    '                                     fecha de corte indicada en parámetros
    '                                     (Parámetro ID = 47). 
    ' -----------------------------------------------------------------------------------------
    Public Function BlnFechaSuperiorParametros(ByVal dFecha As Date) As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            Dim dFechaCorte As Date
            Dim sFechaCorteParametro As String
            BlnFechaSuperiorParametros = False

            StrSql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 47)"
            sFechaCorteParametro = XcDatos.ExecuteScalar(StrSql)
            dFechaCorte = Mid(sFechaCorteParametro, 1, 2) + "/" + Mid(sFechaCorteParametro, 3, 2) + "/" + Mid(sFechaCorteParametro, 5, 4)
            'Fecha indicada no debe ser mayor que la Fecha de Corte 
            'indicada en parámetros:
            If (DateDiff("d", dFecha, dFechaCorte) < 0) Then
                BlnFechaSuperiorParametros = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     10/02/2010
    ' Procedure name                :     IntCodigoTalonario
    ' Description                   :     Dada una fecha, compara esta contra ultima fecha de
    '                                     corte indicada en parámetros para reiniciar numeración 
    '                                     de Recibos de Caja Manuales (Parámetro ID = 66). Si
    '                                     Fecha es mayor q Fecha de Corte en Parámetros regresa
    '                                     código de talonario actual de parámetros (67), en caso
    '                                     contrario regresa código de talonario anterior al actual.  
    ' -----------------------------------------------------------------------------------------
    Public Function IntCodigoTalonario(ByVal dFecha As Date) As Integer
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            Dim dFechaCorte As Date
            Dim sFechaCorteParametro As String

            '-- Encuentra Código de Talonario en Parámetros:
            StrSql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 67)"
            IntCodigoTalonario = XcDatos.ExecuteScalar(StrSql)

            '-- Si ya existe una Reiniciación de Talonarios:
            If IntCodigoTalonario > 0 Then
                '-- Encuentra Fecha de Corte de la última reiniciación de Talonarios:
                StrSql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 66)"
                sFechaCorteParametro = XcDatos.ExecuteScalar(StrSql)
                dFechaCorte = Mid(sFechaCorteParametro, 1, 2) + "/" + Mid(sFechaCorteParametro, 3, 2) + "/" + Mid(sFechaCorteParametro, 5, 4)
                '-- Si Fecha indicada es mayor que la Fecha de Corte indicada 
                '   en parámetros => Código de Talonario en Parámetros:
                If (DateDiff("d", dFecha, dFechaCorte) < 0) Then
                    IntCodigoTalonario = IntCodigoTalonario
                Else 'Código de Talonario - 1
                    IntCodigoTalonario = IntCodigoTalonario - 1
                End If
            End If
            
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function
End Module
