Module ModSMUSURA0
    Public Declare Function Inp Lib "inpout32.dll" Alias "Inp32" (ByVal PortAddress As Short) As Short

    Public Declare Sub Out Lib "inpout32.dll" Alias "Out32" (ByVal PortAddress As Short, ByVal Value As Short)

    Public NombreSistema As String = "SMUSURA0"

    Public MyCurrentDocs As String = ""

    Public MyHelpNameSpace As String = ""

    Public KillConnReports As Boolean = False
    Private Const WINDOWS_OPEN As Int16 = 10
    Public Enum Cedula
        Valida = 1
        Invalida = 2
        LongitudIncorrecta = 3
    End Enum
    Public BGuardarAuditoria As Boolean = False

    'La constante DebugMode: Si es TRUE no se pide el LOGIN y se 
    'asume DESARROLLO. Si es false siempre se pide login: para release.
    Public Const DebugMode As Boolean = False

    'Variable que mantiene el contexto de la seguridad del sistema
    Public Seg As SEA.seaPI

    '-- Estructura de Datos que permitirá almacenar 
    '-- la información general de la sesión de trabajo ----
    Public Structure EstructuraSeguridad

        'Nombre BD
        Public DBName As String

        'Nombre SERVER
        Public ServerName As String

        'User Name 
        Public UsrName As String

        'Login Name 
        Public LoginName As String

        ''Id Moneda Nacional
        'Public IDMonedaNac As Long

        ''Simbolo Moneda Nacional
        'Public SimboloMonedaNac As String

        ''Nombre Moneda Nacional
        'Public NombreMonedaNac As String

        'Id de la Cuenta de Usuario
        Public IDCuenta As Integer

        'Id de la Delegación
        Public IDDelegacion As Integer



    End Structure
    Public GSalvadoNuevoPassword As Boolean 'Para ver si cambio el password.
    Public InfoSistema As EstructuraSeguridad
    '-----------------------------------------------------------------------------------------
    '-- Implementado Por:           Investigador.
    '-- Fecha de Implementación:    25 de Julio del 2006
    '-- Descripción:                Convierte una cadena normal a un valor Hexadecimal.
    '-----------------------------------------------------------------------------------------
    Public Function EncriptaToHex(ByVal myStr As String) As String

        'Declaración de Variables 
        Dim i As Integer
        Dim Result As String

        Result = ""
        Try
            Randomize()
            For i = 1 To Len(myStr)
                If i Mod 2 = 0 Then
                    Result = Result & Right("00" & Hex(Asc(Mid(myStr, i, 1))), 2)
                Else
                    Result = Result & Right("00" & Hex(Asc(Mid(myStr, i, 1))), 2) & Chr(CInt(26 * Rnd() + 65))
                End If
            Next i

        Catch ex As Exception
            Control_Error(ex)
        End Try

        Return Result
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     13/09/2007
    ' Procedure name               :     RegistrosAsociados
    ' Description                  :     Indica si una determinada Consulta regresa registros tras 
    '                               su ejecución.
    ' -----------------------------------------------------------------------------------------
    Public Function RegistrosAsociados(ByVal StrConsulta As String) As Boolean

        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable

        Try
            RegistrosAsociados = False
            XdtTmpConsulta.ExecuteSql(StrConsulta)
            If XdtTmpConsulta.Count > 0 Then
                RegistrosAsociados = True
            End If
        Catch ex As Exception
            Control_Error(ex)
            RegistrosAsociados = False
        Finally
            XdtTmpConsulta.Close()
            XdtTmpConsulta = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     
    ' Date                          :     13/10/2013
    ' Procedure name                :     GuardarAuditoria
    ' Description                   :     Almacena el registro antes de cambio en las tablas de auditoria en la Base de Datos.
    ' -----------------------------------------------------------------------------------------
    Sub GuardarAuditoriaTablas(ByVal intTabla As Integer, ByVal TipoOperacion As Integer, ByVal descripcion_audit As String, ByVal id As Long, ByVal UserID As Integer)
        Dim ObjAuditoria As New BOSistema.Win.XDataSet.xDataTable
        Dim XcUsuario As New BOSistema.Win.XComando
        'Dim IdUsuario As Integer
        Dim strSQL As String = ""
        Dim sNombreProcedimiento = ""
        Dim sTipoOperacion = ""

        Try
            If BGuardarAuditoria Then 'Si guarda auditoria en tablas'

                Select Case TipoOperacion
                    Case 1
                        sTipoOperacion = "Insert"
                    Case 2
                        sTipoOperacion = "Update"
                    Case 3
                        sTipoOperacion = "Delete"
                End Select

                Select Case intTabla
                    Case 1
                        sNombreProcedimiento = "SpAUDITSccSolicitudCheque"
                    Case 2
                        sNombreProcedimiento = "SpAUDITSccSolicitudChequeDetalle"
                    Case 3
                        sNombreProcedimiento = "SpAUDITSccSolicitudDesembolsoCredito"
                    Case 4
                        sNombreProcedimiento = "SpAUDITSclFichaNotificacionCredito"
                    Case 5
                        sNombreProcedimiento = "SpAUDITSclFichaNotificacionDetalle"
                    Case 6
                        sNombreProcedimiento = "SpAUDITSclFichaSeguimiento"
                    Case 7
                        sNombreProcedimiento = "SpAUDITSclFichaSocia"
                    Case 101
                        sNombreProcedimiento = "SpAUDITSccSolicitudChequeDetallePorIdSolicitud"
                        ' -------------------------------------------------------------------------------------------------------
                    Case 8
                        sNombreProcedimiento = "SpAUDITSclGrupoSocia"
                    Case 9
                        sNombreProcedimiento = "SpAUDITSclGrupoSolidario"
                    Case 10
                        sNombreProcedimiento = "SpAUDITSteCaja"
                    Case 11
                        sNombreProcedimiento = "SpAUDITSteCajero"
                    Case 12
                        sNombreProcedimiento = "SpAUDITSteCajeroCajas"
                        ' -------------------------------------------------------------------------------------------------------
                    Case 13
                        sNombreProcedimiento = "SpAUDITSclGarantiaFiduciaria"
                    Case 14
                        sNombreProcedimiento = "SpAUDITSclGarantiaPrendaria"
                    Case 15
                        sNombreProcedimiento = "SpAUDITSclOtroCreditoVigente"
                    Case 16
                        sNombreProcedimiento = "SpAUDITSclSociaCedula"
                    Case 17
                        sNombreProcedimiento = "SpAUDITSclSociaConyuge"
                    Case 18
                        sNombreProcedimiento = "SpAUDITStePagare"
                        ' -------------------------------------------------------------------------------------------------------
                    Case 19
                        sNombreProcedimiento = "SpAUDITSteReciboAnulado"
                    Case 20
                        sNombreProcedimiento = "SpAUDITSteReciboEntregado"
                    Case 21
                        sNombreProcedimiento = "SpAUDITSteReciboEntregadoDpto"
                    Case 22
                        sNombreProcedimiento = "SpAUDITSteReciboPagare"
                        ' -------------------------------------------------------------------------------------------------------
                    Case 23
                        sNombreProcedimiento = "SpAUDITSclDetalleDocExpediente"
                    Case 24
                        sNombreProcedimiento = "SpAUDITScnTransaccionContable "
                    Case 25
                        sNombreProcedimiento = "SpAUDITSclSocia"
                    Case 26
                        sNombreProcedimiento = "SpAUDITSclFichaSeguimiento"
                    Case 27
                        sNombreProcedimiento = "SpAUDITSteArqueoDenominacion"
                    Case 28
                        sNombreProcedimiento = "SpAUDITSteArqueoRecibo"
                    Case 29
                        sNombreProcedimiento = "SpAUDITSteArqueoCaja"
                    Case 30
                        sNombreProcedimiento = "SpAUDITSteMinutaDeposito"

                    Case 31
                        sNombreProcedimiento = "SpAUDITSteConciliacionBancaria"
                    Case 32
                        sNombreProcedimiento = "SpAUDITSteConciliacionTransacciones"
                    Case 33
                        sNombreProcedimiento = "SpAUDITSteConciliacionOtrasOperaciones"

                End Select

                strSQL = "Exec " & sNombreProcedimiento & "  '" & sTipoOperacion & "','" & descripcion_audit & "'," & id & "," & UserID & ",1"
                ObjAuditoria.ExecuteSql(strSQL)

            End If

            ''Localiza ID de Usuario:
            'strSQL = "SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')"
            'IdUsuario = XcUsuario.ExecuteScalar(strSQL)
            ''Ingresa Pista de Auditoria:
            'strSQL = " Insert Into SsgAuditoria (nSsgCuentaID, nSsgOperacionAuditoriaID, nSsgModuloID, " & _
            '         " sDescripcionEvento, sUsuarioCreacion, dFechaCreacion)" & _
            '         " Values (" & IdUsuario & ", " & intOperacion & ", " & intModulo & ", '" & strEvento & _
            '         "', '" & InfoSistema.LoginName & "', getdate())"
            'ObjAuditoria.ExecuteSql(strSQL)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjAuditoria.Close()
            ObjAuditoria = Nothing

            XcUsuario.Close()
            XcUsuario = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     11/09/2007
    ' Procedure name                :     GuardarAuditoria
    ' Description                   :     Almacena pistas de auditoria en la Base de Datos.
    ' -----------------------------------------------------------------------------------------
    Sub GuardarAuditoria(ByVal intOperacion As Integer, ByVal intModulo As Integer, ByVal strEvento As String)

        Dim ObjAuditoria As New BOSistema.Win.XDataSet.xDataTable
        Dim XcUsuario As New BOSistema.Win.XComando
        Dim IdUsuario As Integer
        Dim strSQL As String = ""

        Try
            'Localiza ID de Usuario:
            strSQL = "SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')"
            IdUsuario = XcUsuario.ExecuteScalar(strSQL)
            'Ingresa Pista de Auditoria:
            strSQL = " Insert Into SsgAuditoria (nSsgCuentaID, nSsgOperacionAuditoriaID, nSsgModuloID, " & _
                     " sDescripcionEvento, sUsuarioCreacion, dFechaCreacion)" & _
                     " Values (" & IdUsuario & ", " & intOperacion & ", " & intModulo & ", '" & strEvento & _
                     "', '" & InfoSistema.LoginName & "', getdate())"
            ObjAuditoria.ExecuteSql(strSQL)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjAuditoria.Close()
            ObjAuditoria = Nothing

            XcUsuario.Close()
            XcUsuario = Nothing
        End Try
    End Sub

    '----------------------------------------------------------------------------------------------------------------------------------------------------
    ' Author		    		:	Gamaliel Mejia 
    ' Date			    		:	08/05/2008
    ' Procedure name		   	:	LlamaImprimirTicket
    ' Description			   	:	LLama al dll para imprimir un ticket en base al id del recibo de caja
    ' XnSccReciboOficialCajaID es el id del recibo a imprimir NImpresiones es el numero de impresiones,XCajaEspera=True manda un mensaje en cada impresion
    ' ----------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function LlamaImprimirTicket(ByVal XnSccReciboOficialCajaID As Long, ByVal XNImpresiones As Integer, ByVal XCajaEspera As Boolean) As Boolean

        'Ticket ticket = new TicketControls.Ticket(); 
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim XLineasRecibo As New ArrayList
        Dim ContadorConsulta, ContadorTicket As Integer
        Dim XPrincipal, XMantenimiento, XInteresesCorrientes, XInteresesMoratorios, XSaldo, XDetalleTotal As Double
        Dim XNombre, XReciboNum, XCadenaVacia As String
        Dim CadenaRecibo, CadenaReciboUltimo As String
        Dim XEstadoRecibo As Integer

        Dim ticket As New TicketControls.Ticket
        Dim Value1 As String 'String named Value1
        Dim XnSclFichaNotificacionDetalleID As Long
        Dim XCuotaPagadaCompletaUltima As Integer
        Dim XdtTmpConsulta2 As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable
        Dim nCodigoTalonario As Integer

        Try

            If Not ticket.PrinterExists("Ticket Printer") Then
                MsgBox("La Impresora Ticket Printer no está configurada", MsgBoxStyle.Information)
                Exit Function
            End If
            Value1 = Inp(&H379S) 'Now Value1 has the values in 'data port'
            If CInt(Value1) = 127 Or CInt(Value1) = 120 Then
                MsgBox("Conecte y/o encienda la impresora", MsgBoxStyle.Information)
                Exit Function
            End If


            nCodigoTalonario = IntCodigoTalonario(Now())
            XdtTmpConsulta.ExecuteSql("Select * From vwSccReciboOficialCajaTicketDetalle Where nSccReciboOficialCajaID = " & XnSccReciboOficialCajaID & " Order by nSccReciboOficialCajaID,nNumeroCuota ")

            XPrincipal = 0
            XMantenimiento = 0
            XInteresesCorrientes = 0
            XInteresesMoratorios = 0
            XCadenaVacia = "                                 "
            XEstadoRecibo = 0
            XnSclFichaNotificacionDetalleID = 0
            'XdtTmpConsulta.Source.Item(0)("nMantenimientoValor")   
            For ContadorConsulta = 0 To XdtTmpConsulta.Source.Count - 1
                XEstadoRecibo = XdtTmpConsulta.Source.Item(0)("EstadoRecibo")
                XPrincipal = XPrincipal + XdtTmpConsulta.Source.Item(ContadorConsulta)("nPrincipal")
                XMantenimiento = XMantenimiento + XdtTmpConsulta.Source.Item(ContadorConsulta)("nMantenimientoValor")
                XInteresesCorrientes = XInteresesCorrientes + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesCorrientes")
                XInteresesMoratorios = XInteresesMoratorios + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesMoratorios")
                XnSclFichaNotificacionDetalleID = XdtTmpConsulta.Source.Item(ContadorConsulta)("nSclFichaNotificacionDetalleID")
            Next
            XDetalleTotal = XPrincipal + XMantenimiento + XInteresesCorrientes + XInteresesMoratorios
            'If XDetalleTotal < XdtTmpConsulta.Source.Item(0)("nValor") Then
            '    XPrincipal = XPrincipal + (XdtTmpConsulta.Source.Item(0)("nValor") - XDetalleTotal)

            'End If

            XdtTmpConsulta2.ExecuteSql("SELECT   * From vwSccTablaAmortizacionUltimaCuotaCompleta Where nSclFichaNotificacionDetalleID=  " & XnSclFichaNotificacionDetalleID & " Order By nSclReestructuracionDeudaDetalleID Desc ")
            XCuotaPagadaCompletaUltima = 0
            If XdtTmpConsulta2.Source.Count > 0 Then
                XCuotaPagadaCompletaUltima = XdtTmpConsulta2.Source.Item(0)("UltimaCuotaPagadaCompleta")

            End If
            XSaldo = XdtTmpConsulta.Source.Item(ContadorConsulta - 1)("nSaldoActual")
            XNombre = Trim(XdtTmpConsulta.Source.Item(0)("sNombre1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sNombre2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sNombre2"))) + " " + Trim(XdtTmpConsulta.Source.Item(0)("sApellido1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")))
            XNombre = ConvertirATextoDOS(XNombre)
            XReciboNum = "RECIBO NO. " & Trim(XdtTmpConsulta.Source.Item(0)("sSerieDelegacion")) & Trim(XdtTmpConsulta.Source.Item(0)("nCodigoCaja")) & "-" & Format(XdtTmpConsulta.Source.Item(0)("nCodigo"), "########0")
            CadenaRecibo = Chr(27) + "@" + Chr(27) + "r0"  '"'Inicializar la impresora en fuente negra 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            If nCodigoTalonario = 0 Then

                'CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "MINISTERIO DE FOMENTO" + Chr(10) + Chr(13) + "INDUSTRIA Y COMERCIO" + Chr(10) + Chr(13)
                '***CAMBIO REALIZADO EL 04 DE NOVIEMBRE DEL 2010*****
                CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "BANCO DE FOMENTO A LA PRODUCCION" + Chr(10) + Chr(13) + "B.F.P" + Chr(10) + Chr(13)


            End If


            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "PROGRAMA USURA CERO" + Chr(10) + Chr(13)
            If nCodigoTalonario > 0 Then
                'CadenaRecibo = CadenaRecibo + " RUC: 100798-9500" + Chr(10) + Chr(13)
                '***CAMBIO REALIZADO EL 04 DE NOVIEMBRE DEL 2010*****
                'CadenaRecibo = CadenaRecibo + " RUC: 061107-9397" + Chr(10) + Chr(13)
                'Cambio realizado para el 01 septiembre del 2014 la funcion ahora devuelve el numero ruc actual de la tabla parametros.
                CadenaRecibo = CadenaRecibo + " RUC: " + GetNORUC() + Chr(10) + Chr(13)

            End If
            CadenaRecibo = CadenaRecibo + XReciboNum + Chr(10) + Chr(13)


            If XEstadoRecibo = 3 Then
                CadenaRecibo = CadenaRecibo + "A N U L A D O " + Chr(10) + Chr(13)
            End If

            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

            'CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + "Cuota:" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

            'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "!" + Chr(17) + Chr(27) + "Cuota: " + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13) + Chr(27) + "!" + Chr(0)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

            CadenaRecibo = CadenaRecibo + "Socia: " + CStr(XdtTmpConsulta.Source.Item(0)("nCodigoCliente")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Fecha: " + Trim(XdtTmpConsulta.Source.Item(0)("dFechaRecibo")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Nombre de la Socia:" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + XNombre + Chr(10) + Chr(13)


            CadenaRecibo = CadenaRecibo + "Grupo Solidario:" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Trim(ConvertirATextoDOS(XdtTmpConsulta.Source.Item(0)("Sdescripcion"))) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Sucursal: " + Trim(XdtTmpConsulta.Source.Item(0)("sNombreDelegacion")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Caja: " + Trim(XdtTmpConsulta.Source.Item(0)("sDescripcionCaja")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Municipio: " + Trim(XdtTmpConsulta.Source.Item(0)("Municipio")) + Chr(10) + Chr(13)
            ''Anexada
            If XdtTmpConsulta.Source.Item(0)("CodDistrito") <> 0 Then
                CadenaRecibo = CadenaRecibo + "Distrito: " + Trim(XdtTmpConsulta.Source.Item(0)("CodDistrito")) + Chr(10) + Chr(13)
            End If
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + " DETALLE DE PAGO" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)

            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 


            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Principal" + Chr(13) + Chr(27) + "a2" + Format(XPrincipal, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Corriente" + Chr(13) + Chr(27) + "a2" + Format(XInteresesCorrientes, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Moratorio" + Chr(13) + Chr(27) + "a2" + Format(XInteresesMoratorios, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Mantenimiento de Valor" + Chr(13) + Chr(27) + "a2" + Format(XMantenimiento, "##,##0.00") + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(40, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota No.: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Total Pagado C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XdtTmpConsulta.Source.Item(0)("nValor"), "##,##0.00") + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode




            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual:" + "!" + Chr(17) + Chr(27) + "a2" + Chr(13) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(4)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "-----------------------------" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "Firma y Sello del Cajero" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(33, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "%1" + Chr(27) + "M1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Usuario: " + Trim(InfoSistema.LoginName) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Format(XdtTmpConsulta.Source.Item(0)("dFechaCreacion"), "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(XdtTmpConsulta.Source.Item(0)("dFechaCreacion"), "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "M0"
            CadenaReciboUltimo = CadenaRecibo
            CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "d" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel
            CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "i" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel

            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(9) 'Salta dos lineas para corte entre varias impresiones
            ' CadenaRecibo = CadenaRecibo + Chr(27) + "m" + Chr(9) 'Salta dos lineas para corte entre varias impresiones

            'CadTaste = ConvertirATextoDOS(CadenaRecibo)
            For ContadorTicket = 1 To XNImpresiones
                If XCajaEspera = True And ContadorTicket > 1 Then
                    System.Threading.Thread.Sleep(10000)

                    MsgBox("Corte el Papel Luego de Ok para Continuar Imprimiendo", MsgBoxStyle.OkOnly, NombreSistema)
                End If
                If ContadorTicket = XNImpresiones Then

                    ticket.ImprimirCadena(CadenaReciboUltimo, "Ticket Printer")
                Else

                    ticket.ImprimirCadena(CadenaRecibo, "Ticket Printer")

                End If
                System.Windows.Forms.Application.DoEvents()

            Next ContadorTicket
            Return True



        Catch ex As Exception
            Control_Error(ex)
            Return False
        Finally
            'frmVisor = Nothing

        End Try
    End Function

    Public Function LlamaImprimirTicket(ByVal XnSccReciboOficialCajaID As Long, ByVal XNImpresiones As Integer, ByVal XCajaEspera As Boolean, ByVal xBuscaNoRecibo As Boolean, ByVal login As String, ByVal dFechaCreacion As DateTime) As Boolean

        'Ticket ticket = new TicketControls.Ticket(); 
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim XLineasRecibo As New ArrayList
        Dim ContadorConsulta, ContadorTicket As Integer
        Dim XPrincipal, XMantenimiento, XInteresesCorrientes, XInteresesMoratorios, XSaldo, XDetalleTotal As Double
        Dim XNombre, XReciboNum, XCadenaVacia As String
        Dim CadenaRecibo, CadenaReciboUltimo As String
        Dim XEstadoRecibo As Integer

        Dim ticket As New TicketControls.Ticket
        Dim Value1 As String 'String named Value1
        Dim XnSclFichaNotificacionDetalleID As Long
        Dim XCuotaPagadaCompletaUltima As Integer
        Dim XdtTmpConsulta2 As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable
        Dim nCodigoTalonario As Integer

        Try

            If Not ticket.PrinterExists("Ticket Printer") Then
                MsgBox("La Impresora Ticket Printer no está configurada", MsgBoxStyle.Information)
                Exit Function
            End If
            Value1 = Inp(&H379S) 'Now Value1 has the values in 'data port'
            If CInt(Value1) = 127 Or CInt(Value1) = 120 Then
                MsgBox("Conecte y/o encienda la impresora", MsgBoxStyle.Information)
                Exit Function
            End If


            nCodigoTalonario = IntCodigoTalonario(Now())
            XdtTmpConsulta.ExecuteSql("Select * From vwSccReciboOficialCajaTicketDetalle Where nSccReciboOficialCajaID = " & XnSccReciboOficialCajaID & " Order by nSccReciboOficialCajaID,nNumeroCuota ")

            XPrincipal = 0
            XMantenimiento = 0
            XInteresesCorrientes = 0
            XInteresesMoratorios = 0
            XCadenaVacia = "                                 "
            XEstadoRecibo = 0
            XnSclFichaNotificacionDetalleID = 0
            'XdtTmpConsulta.Source.Item(0)("nMantenimientoValor")   
            For ContadorConsulta = 0 To XdtTmpConsulta.Source.Count - 1
                XEstadoRecibo = XdtTmpConsulta.Source.Item(0)("EstadoRecibo")
                XPrincipal = XPrincipal + XdtTmpConsulta.Source.Item(ContadorConsulta)("nPrincipal")
                XMantenimiento = XMantenimiento + XdtTmpConsulta.Source.Item(ContadorConsulta)("nMantenimientoValor")
                XInteresesCorrientes = XInteresesCorrientes + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesCorrientes")
                XInteresesMoratorios = XInteresesMoratorios + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesMoratorios")
                XnSclFichaNotificacionDetalleID = XdtTmpConsulta.Source.Item(ContadorConsulta)("nSclFichaNotificacionDetalleID")
            Next
            XDetalleTotal = XPrincipal + XMantenimiento + XInteresesCorrientes + XInteresesMoratorios
            'If XDetalleTotal < XdtTmpConsulta.Source.Item(0)("nValor") Then
            '    XPrincipal = XPrincipal + (XdtTmpConsulta.Source.Item(0)("nValor") - XDetalleTotal)

            'End If

            If xBuscaNoRecibo = True Then
                XdtTmpConsulta2.ExecuteSql(String.Format("SELECT   dbo.fn_ObtenerNoCuotaDeRecibo({0},{1},{2}) AS UltimaCuotaPagadaCompleta", XnSclFichaNotificacionDetalleID, XnSccReciboOficialCajaID, XEstadoRecibo))
            Else
                XdtTmpConsulta2.ExecuteSql("SELECT   * From vwSccTablaAmortizacionUltimaCuotaCompleta Where nSclFichaNotificacionDetalleID=  " & XnSclFichaNotificacionDetalleID & " Order By nSclReestructuracionDeudaDetalleID Desc ")
            End If

            XCuotaPagadaCompletaUltima = 0
            If XdtTmpConsulta2.Source.Count > 0 Then
                XCuotaPagadaCompletaUltima = XdtTmpConsulta2.Source.Item(0)("UltimaCuotaPagadaCompleta")
            End If

            XSaldo = XdtTmpConsulta.Source.Item(ContadorConsulta - 1)("nSaldoActual")
            XNombre = Trim(XdtTmpConsulta.Source.Item(0)("sNombre1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sNombre2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sNombre2"))) + " " + Trim(XdtTmpConsulta.Source.Item(0)("sApellido1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")))
            XNombre = ConvertirATextoDOS(XNombre)
            XReciboNum = "RECIBO NO. " & Trim(XdtTmpConsulta.Source.Item(0)("sSerieDelegacion")) & Trim(XdtTmpConsulta.Source.Item(0)("nCodigoCaja")) & "-" & Format(XdtTmpConsulta.Source.Item(0)("nCodigo"), "########0")
            CadenaRecibo = Chr(27) + "@" + Chr(27) + "r0"  '"'Inicializar la impresora en fuente negra 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            If nCodigoTalonario = 0 Then

                'CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "MINISTERIO DE FOMENTO" + Chr(10) + Chr(13) + "INDUSTRIA Y COMERCIO" + Chr(10) + Chr(13)
                '***CAMBIO REALIZADO EL 04 DE NOVIEMBRE DEL 2010*****
                CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "BANCO DE FOMENTO A LA PRODUCCION" + Chr(10) + Chr(13) + "B.F.P" + Chr(10) + Chr(13)


            End If


            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "PROGRAMA USURA CERO" + Chr(10) + Chr(13)
            If nCodigoTalonario > 0 Then
                'CadenaRecibo = CadenaRecibo + " RUC: 100798-9500" + Chr(10) + Chr(13)
                '***CAMBIO REALIZADO EL 04 DE NOVIEMBRE DEL 2010*****
                'CadenaRecibo = CadenaRecibo + " RUC: 061107-9397" + Chr(10) + Chr(13)

                'Cambio realizado para el 01 septiembre del 2014 la funcion ahora devuelve el numero ruc actual de la tabla parametros.
                CadenaRecibo = CadenaRecibo + " RUC: " + GetNORUC() + Chr(10) + Chr(13)
            End If
            CadenaRecibo = CadenaRecibo + XReciboNum + Chr(10) + Chr(13)


            If XEstadoRecibo = 3 Then
                CadenaRecibo = CadenaRecibo + "A N U L A D O " + Chr(10) + Chr(13)
            End If

            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

            'CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + "Cuota:" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

            'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "!" + Chr(17) + Chr(27) + "Cuota: " + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13) + Chr(27) + "!" + Chr(0)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

            CadenaRecibo = CadenaRecibo + "Socia: " + CStr(XdtTmpConsulta.Source.Item(0)("nCodigoCliente")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Fecha: " + Trim(XdtTmpConsulta.Source.Item(0)("dFechaRecibo")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Nombre de la Socia:" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + XNombre + Chr(10) + Chr(13)


            CadenaRecibo = CadenaRecibo + "Grupo Solidario:" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Trim(ConvertirATextoDOS(XdtTmpConsulta.Source.Item(0)("Sdescripcion"))) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Sucursal: " + Trim(XdtTmpConsulta.Source.Item(0)("sNombreDelegacion")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Caja: " + Trim(XdtTmpConsulta.Source.Item(0)("sDescripcionCaja")) + Chr(10) + Chr(13)
            ''Anexada
            If XdtTmpConsulta.Source.Item(0)("CodDistrito") <> 0 Then
                CadenaRecibo = CadenaRecibo + "Distrito: " + Trim(XdtTmpConsulta.Source.Item(0)("CodDistrito")) + Chr(10) + Chr(13)
            End If
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + " DETALLE DE PAGO" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)

            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 


            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Principal" + Chr(13) + Chr(27) + "a2" + Format(XPrincipal, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Corriente" + Chr(13) + Chr(27) + "a2" + Format(XInteresesCorrientes, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Moratorio" + Chr(13) + Chr(27) + "a2" + Format(XInteresesMoratorios, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Mantenimiento de Valor" + Chr(13) + Chr(27) + "a2" + Format(XMantenimiento, "##,##0.00") + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(40, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota No.: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Total Pagado C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XdtTmpConsulta.Source.Item(0)("nValor"), "##,##0.00") + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode




            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual:" + "!" + Chr(17) + Chr(27) + "a2" + Chr(13) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(4)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "-----------------------------" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "Firma y Sello del Cajero" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(33, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "%1" + Chr(27) + "M1"
            ' Modificacion a login 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Usuario: " + IIf(xBuscaNoRecibo = True, login, Trim(InfoSistema.LoginName)) + Chr(10) + Chr(13)
            If xBuscaNoRecibo Then
                CadenaRecibo = CadenaRecibo + Format(dFechaCreacion, "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(dFechaCreacion, "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
            Else
                CadenaRecibo = CadenaRecibo + Format(dFechaCreacion, "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(dFechaCreacion, "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
            End If

            CadenaRecibo = CadenaRecibo + Chr(27) + "!0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "M0"
            CadenaReciboUltimo = CadenaRecibo
            CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "d" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel
            CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "i" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel

            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(9) 'Salta dos lineas para corte entre varias impresiones
            '  CadenaRecibo = CadenaRecibo + Chr(27) + "m" + Chr(9) 'Salta dos lineas para corte entre varias impresiones

            'CadTaste = ConvertirATextoDOS(CadenaRecibo)
            For ContadorTicket = 1 To XNImpresiones
                If XCajaEspera = True And ContadorTicket > 1 Then
                    System.Threading.Thread.Sleep(10000)

                    MsgBox("Corte el Papel Luego de Ok para Continuar Imprimiendo", MsgBoxStyle.OkOnly, NombreSistema)
                End If
                If ContadorTicket = XNImpresiones Then

                    ticket.ImprimirCadena(CadenaReciboUltimo, "Ticket Printer")
                Else

                    ticket.ImprimirCadena(CadenaRecibo, "Ticket Printer")

                End If
                System.Windows.Forms.Application.DoEvents()

            Next ContadorTicket
            Return True



        Catch ex As Exception
            Control_Error(ex)
            Return False
        Finally
            'frmVisor = Nothing

        End Try
    End Function
    Public Function LlamaImprimirTicketImpresoraSeleccionada(ByVal XnSccReciboOficialCajaID As Long, ByVal XNImpresiones As Integer, ByVal XCajaEspera As Boolean, ByVal xBuscaNoRecibo As Boolean, ByVal login As String, ByVal dFechaCreacion As DateTime, ByVal NombreImpresora As String) As Boolean

        'Ticket ticket = new TicketControls.Ticket(); 
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim XLineasRecibo As New ArrayList
        Dim ContadorConsulta, ContadorTicket As Integer
        Dim XPrincipal, XMantenimiento, XInteresesCorrientes, XInteresesMoratorios, XSaldo, XDetalleTotal As Double
        Dim XNombre, XReciboNum, XCadenaVacia As String
        Dim CadenaRecibo, CadenaReciboUltimo As String
        Dim XEstadoRecibo As Integer

        Dim ticket As New TicketControls.Ticket
        Dim Value1 As String 'String named Value1
        Dim XnSclFichaNotificacionDetalleID As Long
        Dim XCuotaPagadaCompletaUltima As Integer
        Dim XdtTmpConsulta2 As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable
        Dim nCodigoTalonario As Integer

        Try

            If Not ticket.PrinterExists(NombreImpresora) Then
                MsgBox("La Impresora Ticket Printer no está configurada", MsgBoxStyle.Information)
                Exit Function
            End If
            Value1 = Inp(&H379S) 'Now Value1 has the values in 'data port'
            If CInt(Value1) = 127 Or CInt(Value1) = 120 Then
                MsgBox("Conecte y/o encienda la impresora", MsgBoxStyle.Information)
                Exit Function
            End If


            nCodigoTalonario = IntCodigoTalonario(Now())
            XdtTmpConsulta.ExecuteSql("Select * From vwSccReciboOficialCajaTicketDetalle Where nSccReciboOficialCajaID = " & XnSccReciboOficialCajaID & " Order by nSccReciboOficialCajaID,nNumeroCuota ")

            XPrincipal = 0
            XMantenimiento = 0
            XInteresesCorrientes = 0
            XInteresesMoratorios = 0
            XCadenaVacia = "                                 "
            XEstadoRecibo = 0
            XnSclFichaNotificacionDetalleID = 0
            'XdtTmpConsulta.Source.Item(0)("nMantenimientoValor")   
            For ContadorConsulta = 0 To XdtTmpConsulta.Source.Count - 1
                XEstadoRecibo = XdtTmpConsulta.Source.Item(0)("EstadoRecibo")
                XPrincipal = XPrincipal + XdtTmpConsulta.Source.Item(ContadorConsulta)("nPrincipal")
                XMantenimiento = XMantenimiento + XdtTmpConsulta.Source.Item(ContadorConsulta)("nMantenimientoValor")
                XInteresesCorrientes = XInteresesCorrientes + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesCorrientes")
                XInteresesMoratorios = XInteresesMoratorios + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesMoratorios")
                XnSclFichaNotificacionDetalleID = XdtTmpConsulta.Source.Item(ContadorConsulta)("nSclFichaNotificacionDetalleID")
            Next
            XDetalleTotal = XPrincipal + XMantenimiento + XInteresesCorrientes + XInteresesMoratorios
            'If XDetalleTotal < XdtTmpConsulta.Source.Item(0)("nValor") Then
            '    XPrincipal = XPrincipal + (XdtTmpConsulta.Source.Item(0)("nValor") - XDetalleTotal)

            'End If

            If xBuscaNoRecibo = True Then
                XdtTmpConsulta2.ExecuteSql(String.Format("SELECT   dbo.fn_ObtenerNoCuotaDeRecibo({0},{1},{2}) AS UltimaCuotaPagadaCompleta", XnSclFichaNotificacionDetalleID, XnSccReciboOficialCajaID, XEstadoRecibo))
            Else
                XdtTmpConsulta2.ExecuteSql("SELECT   * From vwSccTablaAmortizacionUltimaCuotaCompleta Where nSclFichaNotificacionDetalleID=  " & XnSclFichaNotificacionDetalleID & " Order By nSclReestructuracionDeudaDetalleID Desc ")
            End If

            XCuotaPagadaCompletaUltima = 0
            If XdtTmpConsulta2.Source.Count > 0 Then
                XCuotaPagadaCompletaUltima = XdtTmpConsulta2.Source.Item(0)("UltimaCuotaPagadaCompleta")
            End If

            XSaldo = XdtTmpConsulta.Source.Item(ContadorConsulta - 1)("nSaldoActual")
            XNombre = Trim(XdtTmpConsulta.Source.Item(0)("sNombre1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sNombre2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sNombre2"))) + " " + Trim(XdtTmpConsulta.Source.Item(0)("sApellido1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")))
            XNombre = ConvertirATextoDOS(XNombre)
            XReciboNum = "RECIBO NO. " & Trim(XdtTmpConsulta.Source.Item(0)("sSerieDelegacion")) & Trim(XdtTmpConsulta.Source.Item(0)("nCodigoCaja")) & "-" & Format(XdtTmpConsulta.Source.Item(0)("nCodigo"), "########0")
            CadenaRecibo = Chr(27) + "@" + Chr(27) + "r0"  '"'Inicializar la impresora en fuente negra 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            If nCodigoTalonario = 0 Then

                'CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "MINISTERIO DE FOMENTO" + Chr(10) + Chr(13) + "INDUSTRIA Y COMERCIO" + Chr(10) + Chr(13)
                '***CAMBIO REALIZADO EL 04 DE NOVIEMBRE DEL 2010*****
                CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "BANCO DE FOMENTO A LA PRODUCCION" + Chr(10) + Chr(13) + "B.F.P" + Chr(10) + Chr(13)


            End If


            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "PROGRAMA USURA CERO" + Chr(10) + Chr(13)
            If nCodigoTalonario > 0 Then
                'CadenaRecibo = CadenaRecibo + " RUC: 100798-9500" + Chr(10) + Chr(13)
                '***CAMBIO REALIZADO EL 04 DE NOVIEMBRE DEL 2010*****
                'CadenaRecibo = CadenaRecibo + " RUC: 061107-9397" + Chr(10) + Chr(13)


                'Cambio realizado para el 01 septiembre del 2014 la funcion ahora devuelve el numero ruc actual de la tabla parametros.
                CadenaRecibo = CadenaRecibo + " RUC: " + GetNORUC() + Chr(10) + Chr(13)
            End If
            CadenaRecibo = CadenaRecibo + XReciboNum + Chr(10) + Chr(13)


            If XEstadoRecibo = 3 Then
                CadenaRecibo = CadenaRecibo + "A N U L A D O " + Chr(10) + Chr(13)
            End If

            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

            'CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + "Cuota:" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

            'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "!" + Chr(17) + Chr(27) + "Cuota: " + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13) + Chr(27) + "!" + Chr(0)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

            CadenaRecibo = CadenaRecibo + "Socia: " + CStr(XdtTmpConsulta.Source.Item(0)("nCodigoCliente")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Fecha: " + Trim(XdtTmpConsulta.Source.Item(0)("dFechaRecibo")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Nombre de la Socia:" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + XNombre + Chr(10) + Chr(13)


            CadenaRecibo = CadenaRecibo + "Grupo Solidario:" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Trim(ConvertirATextoDOS(XdtTmpConsulta.Source.Item(0)("Sdescripcion"))) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Sucursal: " + Trim(XdtTmpConsulta.Source.Item(0)("sNombreDelegacion")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "Caja: " + Trim(XdtTmpConsulta.Source.Item(0)("sDescripcionCaja")) + Chr(10) + Chr(13)
            ''Anexada
            If XdtTmpConsulta.Source.Item(0)("CodDistrito") <> 0 Then
                CadenaRecibo = CadenaRecibo + "Distrito: " + Trim(XdtTmpConsulta.Source.Item(0)("CodDistrito")) + Chr(10) + Chr(13)
            End If
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + " DETALLE DE PAGO" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)

            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 


            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Principal" + Chr(13) + Chr(27) + "a2" + Format(XPrincipal, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Corriente" + Chr(13) + Chr(27) + "a2" + Format(XInteresesCorrientes, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Moratorio" + Chr(13) + Chr(27) + "a2" + Format(XInteresesMoratorios, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Mantenimiento de Valor" + Chr(13) + Chr(27) + "a2" + Format(XMantenimiento, "##,##0.00") + Chr(10) + Chr(13)

            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(40, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota No.: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Total Pagado C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XdtTmpConsulta.Source.Item(0)("nValor"), "##,##0.00") + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode




            'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual:" + "!" + Chr(17) + Chr(27) + "a2" + Chr(13) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(4)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "-----------------------------" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "Firma y Sello del Cajero" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(33, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "%1" + Chr(27) + "M1"
            ' Modificacion a login 
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Usuario: " + IIf(xBuscaNoRecibo = True, login, Trim(InfoSistema.LoginName)) + Chr(10) + Chr(13)
            If xBuscaNoRecibo Then
                CadenaRecibo = CadenaRecibo + Format(dFechaCreacion, "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(dFechaCreacion, "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
            Else
                CadenaRecibo = CadenaRecibo + Format(dFechaCreacion, "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(dFechaCreacion, "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
            End If

            CadenaRecibo = CadenaRecibo + Chr(27) + "!0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "M0"
            CadenaReciboUltimo = CadenaRecibo
            CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "d" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel
            CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "i" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel

            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(9) 'Salta dos lineas para corte entre varias impresiones
            ' CadenaRecibo = CadenaRecibo + Chr(27) + "i" + Chr(9) 'Salta dos lineas para corte entre varias impresiones

            'CadTaste = ConvertirATextoDOS(CadenaRecibo)
            For ContadorTicket = 1 To XNImpresiones
                If XCajaEspera = True And ContadorTicket > 1 Then
                    System.Threading.Thread.Sleep(10000)

                    MsgBox("Corte el Papel Luego de Ok para Continuar Imprimiendo", MsgBoxStyle.OkOnly, NombreSistema)
                End If
                If ContadorTicket = XNImpresiones Then

                    ticket.ImprimirCadena(CadenaReciboUltimo, NombreImpresora)
                Else

                    ticket.ImprimirCadena(CadenaRecibo, NombreImpresora)

                End If
                System.Windows.Forms.Application.DoEvents()

            Next ContadorTicket
            Return True



        Catch ex As Exception
            Control_Error(ex)
            Return False
        Finally
            'frmVisor = Nothing

        End Try
    End Function
    ''----------------------------------------------------------------------------------------------------------------------------------------------------
    '' Author		    		:	Gamaliel Mejia 
    '' Date			    		:	08/05/2008
    '' Procedure name		   	:	LlamaImprimirTicket
    '' Description			   	:	LLama al dll para imprimir un ticket en base al id del recibo de caja
    '' XnSccReciboOficialCajaID es el id del recibo a imprimir NImpresiones es el numero de impresiones,XCajaEspera=True manda un mensaje en cada impresion
    '' ----------------------------------------------------------------------------------------------------------------------------------------------------
    'Public Function LlamaImprimirTicket(ByVal XnSccReciboOficialCajaID As Long, ByVal XNImpresiones As Integer, ByVal XCajaEspera As Boolean) As Boolean

    '    'Ticket ticket = new TicketControls.Ticket(); 
    '    Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
    '    Dim XLineasRecibo As New ArrayList
    '    Dim ContadorConsulta, ContadorTicket As Integer
    '    Dim XPrincipal, XMantenimiento, XInteresesCorrientes, XInteresesMoratorios, XSaldo, XDetalleTotal As Double
    '    Dim XNombre, XReciboNum, XCadenaVacia As String
    '    Dim CadenaRecibo, CadenaReciboUltimo As String
    '    Dim XEstadoRecibo As Integer

    '    Dim ticket As New TicketControls.Ticket
    '    Dim Value1 As String 'String named Value1
    '    Dim XnSclFichaNotificacionDetalleID As Long
    '    Dim XCuotaPagadaCompletaUltima As Integer
    '    Dim XdtTmpConsulta2 As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable

    '    Try

    '        If Not ticket.PrinterExists("Ticket Printer") Then
    '            MsgBox("La Impresora Ticket Printer no está configurada", MsgBoxStyle.Information)
    '            Exit Function
    '        End If
    '        Value1 = Inp(&H379S) 'Now Value1 has the values in 'data port'
    '        If CInt(Value1) = 127 Or CInt(Value1) = 120 Then
    '            MsgBox("Conecte y/o encienda la impresora", MsgBoxStyle.Information)
    '            Exit Function
    '        End If


    '        XdtTmpConsulta.ExecuteSql("Select * From vwSccReciboOficialCajaTicketDetalle Where nSccReciboOficialCajaID = " & XnSccReciboOficialCajaID & " Order by nSccReciboOficialCajaID,nNumeroCuota ")

    '        XPrincipal = 0
    '        XMantenimiento = 0
    '        XInteresesCorrientes = 0
    '        XInteresesMoratorios = 0
    '        XCadenaVacia = "                                 "
    '        XEstadoRecibo = 0
    '        XnSclFichaNotificacionDetalleID = 0
    '        'XdtTmpConsulta.Source.Item(0)("nMantenimientoValor")   
    '        For ContadorConsulta = 0 To XdtTmpConsulta.Source.Count - 1
    '            XEstadoRecibo = XdtTmpConsulta.Source.Item(0)("EstadoRecibo")
    '            XPrincipal = XPrincipal + XdtTmpConsulta.Source.Item(ContadorConsulta)("nPrincipal")
    '            XMantenimiento = XMantenimiento + XdtTmpConsulta.Source.Item(ContadorConsulta)("nMantenimientoValor")
    '            XInteresesCorrientes = XInteresesCorrientes + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesCorrientes")
    '            XInteresesMoratorios = XInteresesMoratorios + XdtTmpConsulta.Source.Item(ContadorConsulta)("nInteresesMoratorios")
    '            XnSclFichaNotificacionDetalleID = XdtTmpConsulta.Source.Item(ContadorConsulta)("nSclFichaNotificacionDetalleID")
    '        Next
    '        XDetalleTotal = XPrincipal + XMantenimiento + XInteresesCorrientes + XInteresesMoratorios
    '        'If XDetalleTotal < XdtTmpConsulta.Source.Item(0)("nValor") Then
    '        '    XPrincipal = XPrincipal + (XdtTmpConsulta.Source.Item(0)("nValor") - XDetalleTotal)

    '        'End If

    '        XdtTmpConsulta2.ExecuteSql("SELECT   * From vwSccTablaAmortizacionUltimaCuotaCompleta Where nSclFichaNotificacionDetalleID=  " & XnSclFichaNotificacionDetalleID & " Order By nSclReestructuracionDeudaDetalleID Desc ")
    '        XCuotaPagadaCompletaUltima = 0
    '        If XdtTmpConsulta2.Source.Count > 0 Then
    '            XCuotaPagadaCompletaUltima = XdtTmpConsulta2.Source.Item(0)("UltimaCuotaPagadaCompleta")
    '        End If
    '        XSaldo = XdtTmpConsulta.Source.Item(ContadorConsulta - 1)("nSaldoActual")
    '        XNombre = Trim(XdtTmpConsulta.Source.Item(0)("sNombre1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sNombre2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sNombre2"))) + " " + Trim(XdtTmpConsulta.Source.Item(0)("sApellido1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")))
    '        XNombre = ConvertirATextoDOS(XNombre)
    '        XReciboNum = "RECIBO NO. " & Trim(XdtTmpConsulta.Source.Item(0)("sSerieDelegacion")) & Trim(XdtTmpConsulta.Source.Item(0)("nCodigoCaja")) & "-" & Format(XdtTmpConsulta.Source.Item(0)("nCodigo"), "########0")
    '        CadenaRecibo = Chr(27) + "@" + Chr(27) + "r0"  '"'Inicializar la impresora en fuente negra 
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "MINISTERIO DE FOMENTO" + Chr(10) + Chr(13) + "INDUSTRIA Y COMERCIO" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "PROGRAMA USURA CERO" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + XReciboNum + Chr(10) + Chr(13)

    '        If XEstadoRecibo = 3 Then
    '            CadenaRecibo = CadenaRecibo + "A N U L A D O " + Chr(10) + Chr(13)
    '        End If

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
    '        CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

    '        'CadenaRecibo = CadenaRecibo + "Cuota:" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)

    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + XCuotaPagadaCompletaUltima.ToString() + Chr(10) + Chr(13)
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "!" + Chr(17) + Chr(27) + "Cuota: " + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13) + Chr(27) + "!" + Chr(0)
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

    '        CadenaRecibo = CadenaRecibo + "Socia: " + CStr(XdtTmpConsulta.Source.Item(0)("nCodigoCliente")) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "Fecha: " + Trim(XdtTmpConsulta.Source.Item(0)("dFechaRecibo")) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "Nombre de la Socia:" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + XNombre + Chr(10) + Chr(13)


    '        CadenaRecibo = CadenaRecibo + "Grupo Solidario:" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Trim(ConvertirATextoDOS(XdtTmpConsulta.Source.Item(0)("Sdescripcion"))) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "Sucursal: " + Trim(XdtTmpConsulta.Source.Item(0)("sNombreDelegacion")) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "Caja: " + Trim(XdtTmpConsulta.Source.Item(0)("sDescripcionCaja")) + Chr(10) + Chr(13)
    '        ''Anexada
    '        If XdtTmpConsulta.Source.Item(0)("CodDistrito") <> 0 Then
    '            CadenaRecibo = CadenaRecibo + "Distrito: " + Trim(XdtTmpConsulta.Source.Item(0)("CodDistrito")) + Chr(10) + Chr(13)
    '        End If
    '        CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + " DETALLE DE PAGO" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1) 'Salta una linea 


    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Principal" + Chr(13) + Chr(27) + "a2" + Format(XPrincipal, "##,##0.00") + Chr(10) + Chr(13)
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Corriente" + Chr(13) + Chr(27) + "a2" + Format(XInteresesCorrientes, "##,##0.00") + Chr(10) + Chr(13)
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Inter" + Chr(130) + "s Moratorio" + Chr(13) + Chr(27) + "a2" + Format(XInteresesMoratorios, "##,##0.00") + Chr(10) + Chr(13)
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Mantenimiento de Valor" + Chr(13) + Chr(27) + "a2" + Format(XMantenimiento, "##,##0.00") + Chr(10) + Chr(13)

    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(40, Chr(196)) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Cuota No.: " + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + CStr(XCuotaPagadaCompletaUltima) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Total Pagado C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XdtTmpConsulta.Source.Item(0)("nValor"), "##,##0.00") + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode




    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Saldo Actual:" + "!" + Chr(17) + Chr(27) + "a2" + Chr(13) + Chr(27) + "a2" + Format(XSaldo, "##,##0.00") + Chr(10) + Chr(13)
    '        'CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode


    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(4)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "-----------------------------" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a1" + "Firma y Sello del Cajero" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(33, Chr(196)) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "%1" + Chr(27) + "M1"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Usuario: " + Trim(InfoSistema.LoginName) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Format(Now(), "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(Now(), "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "M0"
    '        CadenaReciboUltimo = CadenaRecibo
    '        CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "d" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(9) 'Salta dos lineas para corte entre varias impresiones
    '        'CadTaste = ConvertirATextoDOS(CadenaRecibo)
    '        For ContadorTicket = 1 To XNImpresiones
    '            If XCajaEspera = True And ContadorTicket > 1 Then
    '                System.Threading.Thread.Sleep(10000)

    '                MsgBox("Corte el Papel Luego de Ok para Continuar Imprimiendo", MsgBoxStyle.OkOnly, NombreSistema)
    '            End If
    '            If ContadorTicket = XNImpresiones Then

    '                ticket.ImprimirCadena(CadenaReciboUltimo, "Ticket Printer")
    '            Else

    '                ticket.ImprimirCadena(CadenaRecibo, "Ticket Printer")

    '            End If
    '            System.Windows.Forms.Application.DoEvents()

    '        Next ContadorTicket
    '        Return True



    '    Catch ex As Exception
    '        Control_Error(ex)
    '        Return False
    '    Finally
    '        'frmVisor = Nothing

    '    End Try
    'End Function

    '----------------------------------------------------------------------------------------------------------------------------------------------------
    ' Procedure name		   	:	LlamaImprimirTicketPagare
    ' Description			   	:	LLama al dll para imprimir un ticket en base al id del recibo de pagare
    ' XnSteReciboPagareID es el id del pagare a imprimir NImpresiones es el numero de impresiones,XCajaEspera=True manda un mensaje en cada impresion
    ' ----------------------------------------------------------------------------------------------------------------------------------------------------
    Public Function LlamaImprimirTicketPagare(ByVal XnSteReciboPagareID As Long, ByVal XNImpresiones As Integer, ByVal XCajaEspera As Boolean) As Boolean

        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim XLineasRecibo As New ArrayList
        Dim ContadorTicket As Integer
        Dim XNombre, XReciboNum As String
        Dim CadenaRecibo, CadenaReciboUltimo As String

        Dim ticket As New TicketControls.Ticket
        Dim Value1 As String
        Dim XdtTmpConsulta2, XdtTmpConsulta3 As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta3 = New BOSistema.Win.XDataSet.xDataTable
        Dim nCodigoTalonario As Integer

        Try

            If Not ticket.PrinterExists("Ticket Printer") Then
                MsgBox("La Impresora Ticket Printer no está configurada", MsgBoxStyle.Information)
                Exit Function
            End If
            Value1 = Inp(&H379S) 'Now Value1 has the values in 'data port'
            If CInt(Value1) = 127 Or CInt(Value1) = 120 Then
                MsgBox("Conecte y/o encienda la impresora", MsgBoxStyle.Information)
                Exit Function
            End If
            nCodigoTalonario = IntCodigoTalonario(Now())
            XdtTmpConsulta.ExecuteSql("Select * From vwSteReciboPagareImpresion  Where nSteReciboPagareID= " & XnSteReciboPagareID)
            XNombre = Trim(XdtTmpConsulta.Source.Item(0)("sNombre1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sNombre2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sNombre2"))) + " " + Trim(XdtTmpConsulta.Source.Item(0)("sApellido1RS")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")))
            XNombre = ConvertirATextoDOS(XNombre)
            XReciboNum = "RECIBO NO. " & Format(XdtTmpConsulta.Source.Item(0)("nNumRecibo"), "########0")
            CadenaRecibo = Chr(27) + "@" + Chr(27) + "r0"  '"'Inicializar la impresora en fuente negra 

            ''Poner los numeros de la parte de arriba de seguridad
            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1)

            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)



            'CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "MINISTERIO DE FOMENTO" + Chr(10) + Chr(13) + "INDUSTRIA Y COMERCIO" + Chr(10) + Chr(13)
            'CadenaRecibo = CadenaRecibo + "PROGRAMA USURA CERO" + Chr(10) + Chr(13)





            If nCodigoTalonario = 0 Then
                CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "MINISTERIO DE FOMENTO" + Chr(10) + Chr(13) + "INDUSTRIA Y COMERCIO" + Chr(10) + Chr(13)

            End If


            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "PROGRAMA USURA CERO" + Chr(10) + Chr(13)
            'If nCodigoTalonario > 0 Then
            '    CadenaRecibo = CadenaRecibo + " RUC: 100798-9500" + Chr(10) + Chr(13)
            'End If






            CadenaRecibo = CadenaRecibo + XReciboNum + Chr(10) + Chr(13)

            If XdtTmpConsulta.Source.Item(0)("CodigoEstado") = "2" Then
                CadenaRecibo = CadenaRecibo + "A N U L A D O " + Chr(10) + Chr(13)
            End If

            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)


            CadenaRecibo = CadenaRecibo + "NO. PAGARE A CANCELAR: " + CStr(XdtTmpConsulta.Source.Item(0)("nNumPagare")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "FECHA: " + Trim(XdtTmpConsulta.Source.Item(0)("dFechaRecibo")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "NOMBRE DEL CAJERO:" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + XNombre + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "DELEGACION: " + Trim(XdtTmpConsulta.Source.Item(0)("sNombreDelegacion")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + "CAJA: " + Trim(XdtTmpConsulta.Source.Item(0)("sDescripcionCaja")) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + " CONCEPTO" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) + Trim(XdtTmpConsulta.Source.Item(0)("sConceptoPago")) + Chr(10) + Chr(13)

            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado


            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
            CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "TOTAL PAGADO C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XdtTmpConsulta.Source.Item(0)("nValor"), "##,##0.00") + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

            CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
            CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(3)
            CadenaRecibo = CadenaRecibo + StrDup(32, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "FIRMA Y SELLO DEL" + Chr(10) + Chr(13) + "RESPONSABLE DE TESORERIA" + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1)
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(33, Chr(196)) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Chr(27) + "%1" + Chr(27) + "M1"
            CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Usuario: " + Trim(InfoSistema.LoginName) + Chr(10) + Chr(13)
            CadenaRecibo = CadenaRecibo + Format(Now(), "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(Now(), "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1)
            CadenaRecibo = CadenaRecibo + Chr(27) + "!0"
            CadenaRecibo = CadenaRecibo + Chr(27) + "M0"
            CadenaReciboUltimo = CadenaRecibo
            CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "d" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel

            CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(9) 'Salta dos lineas para corte entre varias impresiones
            CadenaRecibo = CadenaRecibo + Chr(27) + "m" + Chr(9) 'Salta dos lineas para corte entre varias impresiones

            For ContadorTicket = 1 To XNImpresiones
                If XCajaEspera = True And ContadorTicket > 1 Then
                    System.Threading.Thread.Sleep(10000)

                    MsgBox("Corte el Papel Luego de Ok para Continuar Imprimiendo", MsgBoxStyle.OkOnly, NombreSistema)
                End If
                If ContadorTicket = XNImpresiones Then

                    ticket.ImprimirCadena(CadenaReciboUltimo, "Ticket Printer")
                Else

                    ticket.ImprimirCadena(CadenaRecibo, "Ticket Printer")

                End If
                System.Windows.Forms.Application.DoEvents()

            Next ContadorTicket
            Return True



        Catch ex As Exception
            Control_Error(ex)
            Return False
        Finally


        End Try
    End Function
    ''----------------------------------------------------------------------------------------------------------------------------------------------------
    '' Procedure name		   	:	LlamaImprimirTicketPagare
    '' Description			   	:	LLama al dll para imprimir un ticket en base al id del recibo de pagare
    '' XnSteReciboPagareID es el id del pagare a imprimir NImpresiones es el numero de impresiones,XCajaEspera=True manda un mensaje en cada impresion
    '' ----------------------------------------------------------------------------------------------------------------------------------------------------
    'Public Function LlamaImprimirTicketPagare(ByVal XnSteReciboPagareID As Long, ByVal XNImpresiones As Integer, ByVal XCajaEspera As Boolean) As Boolean

    '    Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
    '    Dim XLineasRecibo As New ArrayList
    '    Dim ContadorTicket As Integer
    '    Dim XNombre, XReciboNum As String
    '    Dim CadenaRecibo, CadenaReciboUltimo As String

    '    Dim ticket As New TicketControls.Ticket
    '    Dim Value1 As String
    '    Dim XdtTmpConsulta2, XdtTmpConsulta3 As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpConsulta3 = New BOSistema.Win.XDataSet.xDataTable


    '    Try

    '        If Not ticket.PrinterExists("Ticket Printer") Then
    '            MsgBox("La Impresora Ticket Printer no está configurada", MsgBoxStyle.Information)
    '            Exit Function
    '        End If
    '        Value1 = Inp(&H379S) 'Now Value1 has the values in 'data port'
    '        If CInt(Value1) = 127 Or CInt(Value1) = 120 Then
    '            MsgBox("Conecte y/o encienda la impresora", MsgBoxStyle.Information)
    '            Exit Function
    '        End If

    '        XdtTmpConsulta.ExecuteSql("Select * From vwSteReciboPagareImpresion  Where nSteReciboPagareID= " & XnSteReciboPagareID)
    '        XNombre = Trim(XdtTmpConsulta.Source.Item(0)("sNombre1")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sNombre2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sNombre2"))) + " " + Trim(XdtTmpConsulta.Source.Item(0)("sApellido1RS")) + " " + IIf(Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")) = "", "", Trim(XdtTmpConsulta.Source.Item(0)("sApellido2")))
    '        XNombre = ConvertirATextoDOS(XNombre)
    '        XReciboNum = "RECIBO NO. " & Format(XdtTmpConsulta.Source.Item(0)("nNumRecibo"), "########0")
    '        CadenaRecibo = Chr(27) + "@" + Chr(27) + "r0"  '"'Inicializar la impresora en fuente negra 

    '        ''Poner los numeros de la parte de arriba de seguridad
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1)

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "MINISTERIO DE FOMENTO" + Chr(10) + Chr(13) + "INDUSTRIA Y COMERCIO" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "PROGRAMA USURA CERO" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + XReciboNum + Chr(10) + Chr(13)

    '        If XdtTmpConsulta.Source.Item(0)("CodigoEstado") = "2" Then
    '            CadenaRecibo = CadenaRecibo + "A N U L A D O " + Chr(10) + Chr(13)
    '        End If

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
    '        CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)


    '        CadenaRecibo = CadenaRecibo + "NO. PAGARE A CANCELAR: " + CStr(XdtTmpConsulta.Source.Item(0)("nNumPagare")) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "FECHA: " + Trim(XdtTmpConsulta.Source.Item(0)("dFechaRecibo")) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "NOMBRE DEL CAJERO:" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + XNombre + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "DELEGACION: " + Trim(XdtTmpConsulta.Source.Item(0)("sNombreDelegacion")) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + "CAJA: " + Trim(XdtTmpConsulta.Source.Item(0)("sDescripcionCaja")) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + " CONCEPTO" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) + Trim(XdtTmpConsulta.Source.Item(0)("sConceptoPago")) + Chr(10) + Chr(13)

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(0) 'Quita el centrado


    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(1)
    '        CadenaRecibo = CadenaRecibo + StrDup(40, Chr(196)) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "TOTAL PAGADO C$:" + Chr(13) + Chr(27) + "!" + Chr(17) + Chr(27) + "a2" + Format(XdtTmpConsulta.Source.Item(0)("nValor"), "##,##0.00") + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0) 'Cancel double-height mode

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a" + Chr(1) 'Pone el centrado
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!" + Chr(0)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(3)
    '        CadenaRecibo = CadenaRecibo + StrDup(32, Chr(196)) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "G1" + "FIRMA Y SELLO DEL" + Chr(10) + Chr(13) + "RESPONSABLE DE TESORERIA" + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + StrDup(33, Chr(196)) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "%1" + Chr(27) + "M1"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "a0" + "Usuario: " + Trim(InfoSistema.LoginName) + Chr(10) + Chr(13)
    '        CadenaRecibo = CadenaRecibo + Format(Now(), "dd/MM/yyyy") + Chr(13) + Chr(27) + "a2" + Format(Now(), "hh:mm:ss tt") + Chr(10) + Chr(13) + Chr(13) + Chr(27) + "a0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(1)
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "!0"
    '        CadenaRecibo = CadenaRecibo + Chr(27) + "M0"
    '        CadenaReciboUltimo = CadenaRecibo
    '        CadenaReciboUltimo = CadenaReciboUltimo + Chr(27) + "d" + Chr(9) 'Antes del Ultimo solo salta dos lineas al final salta siete para el corte manual del papel

    '        CadenaRecibo = CadenaRecibo + Chr(27) + "d" + Chr(9) 'Salta dos lineas para corte entre varias impresiones
    '        For ContadorTicket = 1 To XNImpresiones
    '            If XCajaEspera = True And ContadorTicket > 1 Then
    '                System.Threading.Thread.Sleep(10000)

    '                MsgBox("Corte el Papel Luego de Ok para Continuar Imprimiendo", MsgBoxStyle.OkOnly, NombreSistema)
    '            End If
    '            If ContadorTicket = XNImpresiones Then

    '                ticket.ImprimirCadena(CadenaReciboUltimo, "Ticket Printer")
    '            Else

    '                ticket.ImprimirCadena(CadenaRecibo, "Ticket Printer")

    '            End If
    '            System.Windows.Forms.Application.DoEvents()

    '        Next ContadorTicket
    '        Return True



    '    Catch ex As Exception
    '        Control_Error(ex)
    '        Return False
    '    Finally


    '    End Try
    'End Function

    Public Function ConvertirATextoDOS(ByVal Cadena As String) As String

        '************************************************************************
        ' ConvertirATextoDOS(Texto) --> Texto
        ' Función desarrollada por Eduardo Olaz
        ' Primera versión 26/12/1999
        ' Última revisión 22/10/2000

        '************************************************************************
        ' parámetros: Texto (por valor, string) Texto en formato Windows
        ' Valor devuelto (String) Texto convertido a formato MSDOS

        Dim strSubCadena As String
        Dim lngCadena As Long
        Dim lngContador As Long
        'Dim strCaracter As String * 1
        Dim strCaracter As String

        lngCadena = Len(Cadena)
        strSubCadena = ""
        If lngCadena > 0 Then
            For lngContador = 1 To lngCadena
                strCaracter = Mid$(Cadena, lngContador, 1)
                Select Case Asc(strCaracter)
                    Case 170 ' ª
                        strCaracter = Chr(166)
                    Case 186 ' º
                        strCaracter = Chr(167)
                    Case 161 ' ¡
                        strCaracter = Chr(173)
                    Case 191 ' ¿
                        strCaracter = Chr(168)
                    Case 225 ' á
                        strCaracter = Chr(160)
                    Case 193 ' Á
                        strCaracter = Chr(181)
                    Case 233 ' é
                        strCaracter = Chr(130)
                    Case 201 ' É
                        strCaracter = Chr(144)
                    Case 237 ' í
                        strCaracter = Chr(161)
                    Case 205 ' Í
                        strCaracter = Chr(214)
                    Case 243 ' ó
                        strCaracter = Chr(162)
                    Case 211 ' Ó
                        strCaracter = Chr(224)
                    Case 250 ' ú
                        strCaracter = Chr(163)
                    Case 218 ' Ú
                        strCaracter = Chr(233)
                    Case 252 ' ü
                        strCaracter = Chr(129)
                    Case 220 ' Ü
                        strCaracter = Chr(154)
                    Case 241 ' ñ
                        strCaracter = Chr(164)
                    Case 209 ' Ñ
                        strCaracter = Chr(165)
                    Case 231 ' ç
                        strCaracter = Chr(135)
                    Case 199 ' Ç
                        strCaracter = Chr(128)
                End Select
                strSubCadena = strSubCadena & strCaracter
            Next lngContador
        End If
        ConvertirATextoDOS = strSubCadena
    End Function
    Public Function ValidEmail(ByVal strCheck As String, ByVal IgnoreInvalidChar As String) As Boolean
        '*********************************************************************
        '** This function validate an Email address.                        **
        '**                                                                 **
        '** To be valid, a Email shoul have :                               **
        '** 1- character @ must be present in email                         **
        '** 2- character . must be present after the @                      **
        '** 3- at least 2 char should be present before the @               **
        '** 4- at least 2 char should be present after the .                **
        '**                                                                 **
        '** Parameters:                                                     **
        '** SearchString        :  String to search                         **
        '** IgnoreInvalidChar   :  Indicate which characters to ignore      **
        '**                        in the InvalidChar                       **
        '*********************************************************************
        Dim bCK As Boolean
        Dim strDomainType As String
        Dim strDomainName As String
        Dim sInvalidChars As String = "!#$%^&*()=+{}[]|\;:'/?>,< "
        Dim i As Integer

        ' Ignore certains Invalid characters
        For i = 0 To IgnoreInvalidChar.Length - 1
            sInvalidChars = sInvalidChars.Replace(IgnoreInvalidChar.Substring(i, 1), "")
        Next

        'Check to see if there is a double quote
        bCK = Not InStr(1, strCheck, Chr(34)) > 0
        If Not bCK Then GoTo ExitFunction

        'Check to see if there are consecutive dots
        bCK = Not InStr(1, strCheck, "..") > 0
        If Not bCK Then GoTo ExitFunction


        ' Check for invalid characters.
        For i = 1 To sInvalidChars.Length
            If InStr(strCheck, Mid(sInvalidChars, i, 1)) > 0 Then
                bCK = False
                GoTo ExitFunction
            End If
        Next

        ' Check for a . after the @ character
        strDomainType = strCheck.Substring(InStr(1, strCheck, "@"))
        bCK = strDomainType.Length > 0 And InStr(1, strDomainType, ".") > 0
        If Not bCK Then GoTo ExitFunction

        ' at least 2 characters after the .
        If strDomainType.IndexOf(".") >= strDomainType.Length - 2 Then
            bCK = False
            GoTo ExitFunction
        End If

        ' Check if the string before the @ is at least 2 characters long
        strDomainName = strCheck.Substring(0, InStr(1, strCheck, "@") - 1)
        If strDomainName.Length <= 2 Then
            bCK = False
            GoTo ExitFunction
        End If


ExitFunction:
        ValidEmail = bCK
    End Function

    Public Function ValidarCedula(ByVal CedulaCompleta As String) As Cedula
        CedulaCompleta = (CedulaCompleta.Replace("-", "")).Replace(" ", "")
        If CedulaCompleta.Length = 14 Then
            ValidarCedula = IIf(Strings.Mid("ABCDEFGHJKLMNPQRSTUVWXY", (CLng(Strings.Mid(CedulaCompleta, 1, 13)) Mod 23) + 1, 1) = Strings.Mid(CedulaCompleta, 14, 1), Cedula.Valida, Cedula.Invalida)
        Else
            ValidarCedula = Cedula.LongitudIncorrecta
        End If
    End Function
    '-----------------------------------------------------------------------------------------
    '-- Implementado Por: 
    '-- Fecha de Implementación:    25 de Julio del 2006
    '-- Descripción:                Lee una cadena con formato hexadecimal y la convierte a formato ASCII
    '-----------------------------------------------------------------------------------------
    Public Function DesencriptaOfHex(ByVal myHex As String) As String

        'Declaración de Variables 
        Dim i As Integer, j As Integer
        Dim Result As String
        '------------------------
        Result = ""
        Try
            j = 1
            Randomize()
            For i = 1 To Int(Len(myHex) / 2.5)
                Result = Result & Chr(Val("&H" & Mid(myHex, j, 2)))
                j = j + IIf(i Mod 2 = 0, 2, 3)
            Next i

        Catch ex As Exception
            Control_Error(ex)
        End Try
        Return Result
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	03 de Agosto del 2006
    ' Procedure name		   	:	InicializaDatosRegedit
    ' Description			   	:	Inicializa los datos del Regedit: Base de Datos y Servidor
    ' -----------------------------------------------------------------------------------------
    Public Sub InicializaDatosRegedit()

        'Declaracion de la Variable
        Dim ObjDsSMUSURA0 As DSSistema.DSSistema

        Try
            ObjDsSMUSURA0 = New DSSistema.DSSistema
            InfoSistema.DBName = ObjDsSMUSURA0.DbName
            InfoSistema.ServerName = ObjDsSMUSURA0.ServerName

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjDsSMUSURA0 = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    	:	
    ' Date			    	:	08/08/2006
    ' Procedure name		:	OpenFormMDI
    ' Description		   	:	Como comentarios finales la Función OpenFormMDI tiene 2 parámetros:
    '					        1. El nombre del formulario que se pretende ABRIR
    '                           2. El nombre del Formulario MDI padre. En caso que el formulario
    '                              no sea un MDI obviar el parametro.
    ' -----------------------------------------------------------------------------------------
    Public Sub OpenForm(ByVal NombreFormulario As Form, Optional ByVal MDI As Form = Nothing)

        'Declaracion de Variables
        Dim EncontroFormulario As Boolean = False
        Dim i As Integer

        'If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
        '    'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
        '    Exit Sub
        'End If

        If Not MDI Is Nothing Then
            For i = 0 To My.Application.OpenForms.Count - 1
                If My.Application.OpenForms(i).Name = NombreFormulario.Name Then
                    'Si el formulario que abrí ya está cargado en memoria
                    My.Application.OpenForms(i).WindowState = FormWindowState.Maximized
                    My.Application.OpenForms(i).Activate()
                    My.Application.OpenForms(i).BringToFront()
                    EncontroFormulario = True
                    Exit Sub
                End If
            Next
            If Not EncontroFormulario Then
                'Formulario MDI Principal
                NombreFormulario.MdiParent = MDI
                NombreFormulario.Show()
            End If
        Else
            'Recorro la lista de formularios abiertos
            For i = 0 To My.Application.OpenForms.Count - 1
                If My.Application.OpenForms(i).Name = NombreFormulario.Name Then

                    'Si el formulario que abrí ya está cargado en memoria
                    My.Application.OpenForms(i).WindowState = FormWindowState.Maximized
                    My.Application.OpenForms(i).Activate()
                    My.Application.OpenForms(i).BringToFront()
                    EncontroFormulario = True
                    Exit Sub
                End If
            Next

            If Not EncontroFormulario Then
                NombreFormulario.Show()
            End If
        End If
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    	:	
    ' Date			    	:	08/08/2006
    ' Procedure name		:	OpenFormMDI
    ' Description		   	:	Como comentarios finales la Función OpenFormMDI tiene 2 parámetros:
    '					        1. El nombre del formulario que se pretende ABRIR
    '                           2. El nombre del Formulario MDI padre. En caso que el formulario
    '                              no sea un MDI obviar el parametro.
    ' -----------------------------------------------------------------------------------------
    'Public Sub OpenForm2(ByVal NombreFormulario As Form, Optional ByVal MDI As Form = Nothing)

    '    'Declaracion de Variables
    '    Dim EncontroFormulario As Boolean = False
    '    Dim i As Integer

    '    If My.Application.OpenForms.Count > 2 Then
    '        'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
    '        Exit Sub
    '    End If

    '    If Not MDI Is Nothing Then
    '        For i = 0 To My.Application.OpenForms.Count - 1
    '            If My.Application.OpenForms(i).Name = NombreFormulario.Name Then
    '                'Si el formulario que abrí ya está cargado en memoria
    '                'My.Application.OpenForms(i).WindowState = FormWindowState.Maximized
    '                My.Application.OpenForms(i).Activate()
    '                My.Application.OpenForms(i).BringToFront()
    '                EncontroFormulario = True
    '                Exit Sub
    '            End If
    '        Next
    '        If Not EncontroFormulario Then
    '            'Formulario MDI Principal
    '            NombreFormulario.MdiParent = MDI
    '            NombreFormulario.Show()
    '        End If
    '    Else
    '        'Recorro la lista de formularios abiertos
    '        For i = 0 To My.Application.OpenForms.Count - 1
    '            If My.Application.OpenForms(i).Name = NombreFormulario.Name Then

    '                'Si el formulario que abrí ya está cargado en memoria
    '                'My.Application.OpenForms(i).WindowState = FormWindowState.Maximized
    '                My.Application.OpenForms(i).Activate()
    '                My.Application.OpenForms(i).BringToFront()
    '                EncontroFormulario = True
    '                Exit Sub
    '            End If
    '        Next

    '        If Not EncontroFormulario Then
    '            NombreFormulario.Show()
    '        End If
    '    End If
    'End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	11 de Agosto del 2006
    ' Procedure name		   	:	CloseForm
    ' Description			   	:	Cerrar todos los formularios abiertos menos el que tiene el foco.  
    ' -----------------------------------------------------------------------------------------
    Public Sub CloseForm(ByVal FormNameActual As String)
        Try
            'Declaracion de Variables --------
            Dim EncontroFrm As Boolean = False
            Dim i As Integer
            '---------------------------------

            'Recorrer la lista de Formularios abiertos.
            Do While My.Application.OpenForms.Count > 1
                i = My.Application.OpenForms.Count - 1
                If My.Application.OpenForms(i).Name <> FormNameActual Then
                    My.Application.OpenForms(i).Close()
                End If
            Loop

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	15 de Agosto del 2006
    ' Procedure name		   	:	FechaServer
    ' Description			   	:	Esta funcion permite obtener la fecha actual del servidor, 
    '                               se utiliza una función debido a que la fecha de la aplicacion 
    '                               cliente puede cambiar mientras que la fecha del servidor solo 
    '                               cambia a medianoche.
    ' Function Return Type Name	:   Retornara un tipo de datos fecha     
    ' -----------------------------------------------------------------------------------------
    Public Function FechaServer() As DateTime

        'Declaracion de Variables 
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable

        Try
            ObjComando = New BOSistema.Win.XDataSet.xDataTable

            'Retorno la fecha del servidor
            ObjComando.ExecuteSql("Select Getdate() as Fecha")

            If ObjComando.Count > 0 Then
                Return ObjComando("Fecha")
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjComando = Nothing
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09/12/2006
    ' Procedure name		   	:	CaracterValido
    ' Description			   	:	Esta funcion me indica si los caracteres son letras y numeros.
    ' Se utiliza para validar el codigo interno y los nombres de los Catalogos
    ' -----------------------------------------------------------------------------------------
    Public Function CaracterValidoTexto(ByVal Caracter As Char, Optional ByVal ValEspace As Boolean = False) As Boolean
        Try
            'Si ValEspace= true no se permite el espacio
            If ValEspace = True Then
                If Caracter = " " Then
                    Return False
                End If
            Else
                If Caracter = " " Then
                    Return True
                End If
            End If

            'Si el codigo ascii del caracter no es 
            If (Asc(Caracter) >= 48 And Asc(Caracter) <= 57) Or (Asc(Caracter) >= 65 And Asc(Caracter) <= 90) _
            Or (Asc(Caracter) >= 97 And Asc(Caracter) <= 122) Or (Asc(Caracter) = 241 Or Asc(Caracter) = 209) _
            Or (Asc(Caracter) = 13 Or Asc(Caracter) = 8 Or Asc(Caracter) = 225 _
            Or Asc(Caracter) = 233 Or Asc(Caracter) = 243 Or Asc(Caracter) = 250 Or Asc(Caracter) = 237) Then
                Return True
            End If

            Return False

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	13/12/2006
    ' Procedure name		   	:	CaracterEspecial
    ' Description			   	:	Evita que se introduzcan caracteres especiales como el *, %, #, $, y '
    ' -----------------------------------------------------------------------------------------
    Public Function CaracterEspecial(ByVal caracter As Char) As Boolean
        Try
            Select Case caracter
                Case "*", "%", "#", "$", "'"
                    Return True
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09/12/2006
    ' Procedure name		   	:	CaracterValido
    ' Description			   	:	Esta funcion me indica si los caracteres son letras y numeros.
    ' Se utiliza para validar el codigo interno y los nombres de los Catalogos
    ' -----------------------------------------------------------------------------------------
    Public Function CaracterValidoCodigo(ByVal Caracter As Char) As Boolean
        Try
            'Valido primero el espacio vacion
            If Caracter = " " Then
                Return False
            End If

            'Si el codigo ascii del caracter no es 
            If (Asc(Caracter) >= 48 And Asc(Caracter) <= 57) Or (Asc(Caracter) >= 65 And Asc(Caracter) <= 90) _
            Or (Asc(Caracter) >= 97 And Asc(Caracter) <= 122) Or (Asc(Caracter) = 241 Or Asc(Caracter) = 209) _
            Or ((Caracter) = ".") Or (Asc(Caracter) = 13 Or Asc(Caracter)) = 8 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09/12/2006
    ' Procedure name		   	:	TextoValido
    ' Description			   	:	Esta funcion me indica si los caracteres son letras y numeros.
    ' Se utiliza para validar el codigo interno y los nombres de los Catalogos
    ' -----------------------------------------------------------------------------------------
    Public Function TextoValido(ByVal Caracter As Char) As Boolean
        Try
            ''Valido primero el espacio vacion
            'If Caracter = " " Then
            '    Return False 
            'End If
            'Si el codigo ascii del caracter no es 
            If (Asc(Caracter) >= 48 And Asc(Caracter) <= 57) Or (Asc(Caracter) >= 65 And Asc(Caracter) <= 90) _
            Or (Asc(Caracter) >= 97 And Asc(Caracter) <= 122) _
            Or (UCase(Caracter) = UCase("á")) Or (UCase(Caracter) = UCase("é")) Or (UCase(Caracter) = UCase("í")) Or (UCase(Caracter) = UCase("ó")) Or (UCase(Caracter) = UCase("ú")) Or (UCase(Caracter) = UCase("ñ")) _
            Or (UCase(Caracter) = UCase("ü")) _
            Or ((Caracter) = "+") Or ((Caracter) = "-") Or ((Caracter) = "$") Or ((Caracter) = ":") Or ((Caracter) = "/") Or ((Caracter) = "(") Or ((Caracter) = ")") Or (Asc(Caracter)) = 8 Or (Asc(Caracter)) = 44 Or (Asc(Caracter)) = 46 Or (Asc(Caracter)) = 32 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	02 de Enero del 2007
    ' Procedure name		   	:	EstableceMargenesRptVertical
    ' Description			   	:	Define los margenes de las plantillas de Reporte que son carta.  
    ' -----------------------------------------------------------------------------------------
    Public Sub EstableceMargenesRptLetter(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)

        Try
            ObjReporte.PageSettings.Margins.Top = 0.4
            ObjReporte.PageSettings.Margins.Bottom = 0.4
            ObjReporte.PageSettings.Margins.Left = 0.4
            ObjReporte.PageSettings.Margins.Right = 0.4

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09/12/2006
    ' Procedure name		   	:	CaracterValido2
    ' Description			   	:	Esta funcion me indica si los caracteres son letras y numeros y espacios.
    ' Se utiliza para validar el codigo interno y los nombres de los Catalogos
    ' -----------------------------------------------------------------------------------------------------------
    Public Function CaracterValidoCodigo2(ByVal Caracter As Char) As Boolean
        Try
            ''Valido primero el espacio vacio
            If Caracter = " " Then
                Return True
            End If

            'Si el codigo ascii del caracter no es 
            If (Asc(Caracter) >= 48 And Asc(Caracter) <= 57) Or (Asc(Caracter) >= 65 And Asc(Caracter) <= 90) _
            Or (Asc(Caracter) >= 97 And Asc(Caracter) <= 122) Or (Asc(Caracter) = 241 Or Asc(Caracter) = 209) _
            Or (Asc(Caracter) = 13 Or Asc(Caracter) = 32 Or Asc(Caracter)) = 8 Or Asc(Caracter) = 225 Or Asc(Caracter) = 237 Or Asc(Caracter) = 233 Or Asc(Caracter) = 243 Or Asc(Caracter) = 250 Or Asc(Caracter) = 45 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	12/01/2007
    ' Procedure name		   	:	Numeros
    ' Description			   	:	Esta funcion me indica si los caracteres son numeros.
    ' Se utiliza para validar el codigo interno 
    ' -----------------------------------------------------------------------------------------
    Public Function Numeros(ByVal Caracter As Char) As Boolean
        Try
            'Si el codigo ascii del caracter no es 
            If (Asc(Caracter) >= 48 And Asc(Caracter) <= 57) Or Asc(Caracter) = 8 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	12/01/2007
    ' Procedure name		   	:	Letras
    ' Description			   	:	Esta funcion me indica si los caracteres son Letras.
    ' Se utiliza para validar el codigo interno 
    ' -----------------------------------------------------------------------------------------
    Public Function Letras(ByVal Caracter As Char) As Boolean
        Try
            If Caracter = " " Then
                Return True
            End If

            'Si el codigo ascii del caracter no es 
            If (Asc(Caracter) >= 65 And Asc(Caracter) <= 90) Or (Asc(Caracter) >= 97 And Asc(Caracter) <= 122) Or (Asc(Caracter) = 241 Or Asc(Caracter) = 209) _
            Or (Asc(Caracter) = 13 Or Asc(Caracter) = 32 Or Asc(Caracter)) = 8 Or Asc(Caracter) = 225 Or Asc(Caracter) = 237 Or Asc(Caracter) = 233 Or Asc(Caracter) = 243 Or Asc(Caracter) = 250 Then
                Return True
            End If

            Return False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    Public Function NroEnLetras(ByVal curNumero As Double, Optional ByVal blnO_Final As Boolean = True, Optional ByVal Unidad As String = "", Optional ByVal Unidades As String = "") As String
        NroEnLetras = ""
        Try
            Dim dblCentavos As Double
            Dim lngCont(6) As Long
            Dim DouGrupo(6) As Double
            Dim IntGrupo As Integer
            Dim StrGrupo(6, 2)
            Dim blnNegativo As Boolean
            Dim blnPlural As Boolean
            Dim strNumLetras As String = ""
            Dim strNumero(21) As String
            Dim strDecenas(11) As String
            Dim strCentenas(10) As String
            strNumero(0) = vbNullString : strNumero(1) = "un" : strNumero(2) = "dos" : strNumero(3) = "tres"
            strNumero(4) = "cuatro" : strNumero(5) = "cinco" : strNumero(6) = "seis" : strNumero(7) = "siete"
            strNumero(8) = "ocho" : strNumero(9) = "nueve" : strNumero(10) = "diez" : strNumero(11) = "once"
            strNumero(12) = "doce" : strNumero(13) = "trece" : strNumero(14) = "catorce" : strNumero(15) = "quince"
            strNumero(16) = "dieciseis" : strNumero(17) = "diecisiete" : strNumero(18) = "dieciocho"
            strNumero(19) = "diecinueve" : strNumero(20) = "veinte"
            strDecenas(0) = vbNullString : strDecenas(1) = vbNullString : strDecenas(2) = "veinti"
            strDecenas(3) = "treinta" : strDecenas(4) = "cuarenta" : strDecenas(5) = "cincuenta"
            strDecenas(6) = "sesenta" : strDecenas(7) = "setenta" : strDecenas(8) = "ochenta"
            strDecenas(9) = "noventa" : strDecenas(10) = "cien"
            strCentenas(0) = vbNullString : strCentenas(1) = "ciento" : strCentenas(2) = "doscientos"
            strCentenas(3) = "trecientos" : strCentenas(4) = "cuatrocientos" : strCentenas(5) = "quinientos"
            strCentenas(6) = "seiscientos" : strCentenas(7) = "setecientos" : strCentenas(8) = "ochocientos"
            strCentenas(9) = "novecientos"
            DouGrupo(0) = 10.0# : DouGrupo(1) = 100.0# : DouGrupo(2) = 1000.0# : DouGrupo(3) = 1000000.0#
            DouGrupo(4) = 1000000000000.0# : DouGrupo(5) = 1.0E+18#
            StrGrupo(0, 0) = "" : StrGrupo(1, 0) = "" : StrGrupo(2, 0) = " mil " : StrGrupo(3, 0) = " millones "
            StrGrupo(4, 0) = " billones " : StrGrupo(5, 0) = " trillones "
            StrGrupo(0, 1) = "" : StrGrupo(1, 1) = "" : StrGrupo(2, 1) = " mil " : StrGrupo(3, 1) = " millón "
            StrGrupo(4, 1) = " billón " : StrGrupo(5, 1) = " trillón "
            If Int(curNumero) = 0.0# Then strNumLetras = "cero"
            If curNumero < 0.0# Then
                blnNegativo = True
                curNumero = (curNumero) * -1
            End If
            If Int(curNumero) <> curNumero Then
                dblCentavos = (curNumero - Int(curNumero))
                curNumero = Int(curNumero)
            End If
            For IntGrupo = 5 To 1 Step -1
                lngCont(IntGrupo) = Int(curNumero / DouGrupo(IntGrupo))
                curNumero = curNumero - (lngCont(IntGrupo) * DouGrupo(IntGrupo))
            Next IntGrupo
            If Not (curNumero > 10.0# And curNumero <= 20.0#) Then
                lngCont(0) = Int(curNumero / DouGrupo(0))
                curNumero = curNumero - (lngCont(0) * DouGrupo(0))
            End If
            For IntGrupo = 5 To 2 Step -1
                If lngCont(IntGrupo) > 0 Then
                    strNumLetras = strNumLetras & NroEnLetras(lngCont(IntGrupo), False)
                    If Not blnPlural Then blnPlural = (lngCont(IntGrupo) > 1)
                    lngCont(IntGrupo) = 0
                    strNumLetras = Trim(strNumLetras) & strNumero(lngCont(IntGrupo)) & IIf(blnPlural, StrGrupo(IntGrupo, 0), StrGrupo(IntGrupo, 1))
                End If
            Next IntGrupo
            If lngCont(1) > 0 Then
                If lngCont(1) = 1 And lngCont(0) = 0 And curNumero = 0.0# Then
                    strNumLetras = strNumLetras & "cien"
                Else
                    strNumLetras = strNumLetras & strCentenas(lngCont(1)) & " "
                End If
            End If
            If lngCont(0) >= 1 Then
                If lngCont(0) = 1 Then
                    strNumLetras = strNumLetras & strNumero(10)
                Else
                    strNumLetras = strNumLetras & strDecenas(lngCont(0))
                End If
                If lngCont(0) >= 3 And curNumero > 0.0# Then strNumLetras = strNumLetras & " y "
            Else
                If curNumero >= 0.0# And curNumero <= 20.0# Then
                    strNumLetras = strNumLetras & strNumero(curNumero)
                    If curNumero = 1.0# And blnO_Final Then strNumLetras = strNumLetras & "o"
                    If dblCentavos > 0.0# Then strNumLetras = Trim(strNumLetras) & " con " & Format$(CInt(dblCentavos * 100.0#), "00") & "/100"
                    If (Microsoft.VisualBasic.Left(strNumLetras, 3) = "Un" Or Microsoft.VisualBasic.Left(strNumLetras, 3) = "uno") And blnO_Final = True Then
                        strNumLetras = strNumLetras & " " & Unidad
                    ElseIf (Microsoft.VisualBasic.Left(strNumLetras, 3) <> "Un" Or Microsoft.VisualBasic.Left(strNumLetras, 3) <> "uno") And blnO_Final = True Then
                        strNumLetras = strNumLetras & " " & Unidades
                    End If
                    NroEnLetras = strNumLetras
                    Exit Function
                End If
            End If

            If curNumero > 0.0# Then
                strNumLetras = strNumLetras & strNumero(curNumero)
                If curNumero = 1.0# And blnO_Final Then strNumLetras = strNumLetras & "o"
            End If
            If dblCentavos > 0.0# Then strNumLetras = strNumLetras & " con " + Format$(CInt(dblCentavos * 100.0#), "00") & "/100"
            If (Microsoft.VisualBasic.Left(strNumLetras, 3) = "un" Or Microsoft.VisualBasic.Left(strNumLetras, 3) = "uno") And blnO_Final = True Then
                strNumLetras = strNumLetras & " " & Unidad
            ElseIf (Microsoft.VisualBasic.Left(strNumLetras, 3) <> "un" Or Microsoft.VisualBasic.Left(strNumLetras, 3) <> "uno") And blnO_Final = True Then
                strNumLetras = strNumLetras & " " & Unidades
            End If
            NroEnLetras = IIf(blnNegativo, "(" & strNumLetras & ")", strNumLetras)
        Catch Excepción As Exception
            MsgBox("Error: " & Excepción.Message)
        End Try
        Return NroEnLetras
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	30 de Abril del 2006
    ' Procedure name		   	:	CargarMonedaNacional
    ' Description			   	:	Buscar la Moneda Nacional
    ' -----------------------------------------------------------------------------------------
    'Public Sub CargarMonedaNacional()

    '    'Declaracion de la Variables -----
    '    Dim xdtMoneda As BOSistema.Win.XDataSet.xDataTable
    '    Dim StrSql As String
    '    Try
    '        xdtMoneda = New BOSistema.Win.XDataSet.xDataTable

    '        StrSql = "Select nStbMonedaID, " & _
    '                " sSimbolo, " & _
    '                " sDescripcion From StbMoneda " & _
    '                " Where nActivo=1 And nNacional=1"

    '        xdtMoneda.ExecuteSql(StrSql)

    '        If xdtMoneda.Count > 0 Then
    '            InfoSistema.IDMonedaNac = xdtMoneda("nStbMonedaID")
    '            InfoSistema.SimboloMonedaNac = xdtMoneda("sSimbolo")
    '            InfoSistema.NombreMonedaNac = xdtMoneda("sDescripcion")
    '        Else
    '            InfoSistema.IDMonedaNac = -1
    '            InfoSistema.SimboloMonedaNac = ""
    '            InfoSistema.NombreMonedaNac = ""
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        xdtMoneda = Nothing
    '    End Try
    'End Sub

    Public Function GetNORUC() As String

        'Declaracion de la Variable
        Dim StrSql As String
        Dim sRuc As String = ""
        Dim XdtRuc As BOSistema.Win.XDataSet.xDataTable

        Try
            XdtRuc = New BOSistema.Win.XDataSet.xDataTable

            StrSql = "SELECT     sValorParametro  FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 105)"



            XdtRuc.ExecuteSql(StrSql)

            If XdtRuc.Count = 1 Then
                sRuc = XdtRuc("sValorParametro")
                Return sRuc
            Else
                sRuc = "No hay RUC"
                Return sRuc
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtRuc = Nothing
        End Try
        Return ""
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	25/04/2007
    ' Procedure name		   	:	GetTasaCambio
    ' Description			   	:	Lee la Tasa de cambio para una fecha determinada
    ' -----------------------------------------------------------------------------------------
    Public Function GetTasaCambio(ByVal FechaTasa As DateTime, ByVal IDMonedaOrigen As Long, ByRef IDTasaCambio As Long, Optional ByVal Nacional As Boolean = False) As Decimal

        'Declaracion de la Variable
        Dim StrSql As String
        Dim XdtTasaCambio As BOSistema.Win.XDataSet.xDataTable

        Try
            XdtTasaCambio = New BOSistema.Win.XDataSet.xDataTable

            'Si la moneda de origen no es Nacional se busca su equivalencia en la Moneda Nacional
            If Nacional = False Then
                StrSql = "Select nStbParidadCambiariaID,nMontoTCambio From stbparidadcambiaria " & _
                        " Where nActivo=1 And " & _
                        " dFechaTCambio='" & Format(FechaTasa, "dd/MM/yyyy") & "' And " & _
                        " nStbMonedaBaseID=" & IDMonedaOrigen.ToString
            Else
                'En caso contrario se busca el id de la equivalencia unitaria de la moneda Nacional
                StrSql = "Select nStbParidadCambiariaID,nMontoTCambio From stbparidadcambiaria " & _
                        " Where nActivo=1 And " & _
                        " nStbMonedaBaseID=" & IDMonedaOrigen.ToString & " And " & _
                        " nStbMonedaCambioID=" & IDMonedaOrigen.ToString
            End If

            XdtTasaCambio.ExecuteSql(StrSql)

            If XdtTasaCambio.Count = 1 Then
                IDTasaCambio = XdtTasaCambio("nStbParidadCambiariaID")
                Return XdtTasaCambio("nMontoTCambio")
            Else
                IDTasaCambio = -1
                Return -1
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTasaCambio = Nothing
        End Try
    End Function
End Module
