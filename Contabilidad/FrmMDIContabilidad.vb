Imports System.Windows.Forms
Imports Microsoft.Win32
Public Class FrmMDIContabilidad

    'Private Sub FrmMDIContabilidad_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    Try
    '        Me.Text = "SMUSURA0 - Módulo de Contabilidad"
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    Private Sub FrmMDIControlCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            Me.Text = "SMUSURA0 - Módulo de Contabilidad"
            InicializaBarraEstado()
            Seguridad()

            '---------------------------------------------------------
            'Seleccionar el primer grupo de la toolbar vertical
            Me.UlbContabilidad.Groups(0).Selected = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalir.Click
        Try
            LlamaSalir()
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuAyuda_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAyuda.Click
        Try
            LlamaAyuda()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub UlbContabilidad_ItemSelected(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListBar.ItemEventArgs) Handles UlbContabilidad.ItemSelected
        Try
            Select Case e.Item.Key

                Case "EstructuraCuentas"
                    If Seg.HasPermission("MantEstructuraContable") Then
                        LlamaEstructuraCuentas()
                    End If
                Case "FuenteFinanciamiento"
                    If Seg.HasPermission("MantFuenteFinanciamiento") Then
                        LlamaFuenteFinanciamiento()
                    End If
                Case "CuentaBancaria"
                    If Seg.HasPermission("MantCtaBancaria") Then
                        LlamaCtaBancaria()
                    End If
                Case "CatalogoContable"
                    If Seg.HasPermission("MantCatalogoContable") Then
                        LlamaCatalogoContable()
                    End If
                Case "Revisar"
                    If Seg.HasPermission("MantRevisarSolCheque") Then
                        LlamaSolicitudCheque("REV")
                    End If
                Case "Autorizar"
                    If Seg.HasPermission("MantAutorizarSolCheque") Then
                        LlamaSolicitudCheque("AUT")
                    End If
                Case "ParametrosContables"
                    If Seg.HasPermission("MantParametrosContables") Then
                        LlamaParametrosContables()
                    End If
                Case "ChequeSocia"
                    If Seg.HasPermission("MantChequeSocia") Then
                        LlamaRegistroCheques()
                    End If
                Case "ComprobanteDiario"
                    If Seg.HasPermission("MantComprobanteDiario") Then
                        LlamaRegistroComprobante("CD")
                    End If
                Case "ComprobanteRecuperacion"
                    If Seg.HasPermission("MantComprobanteRecuperacion") Then
                        LlamaRegistroComprobante("CR")
                    End If
                Case "IngresoFondo"
                    If Seg.HasPermission("MantReciboIngreso") Then
                        LlamaRegistroIngresoFondos()
                    End If
                Case "EjercicioContable"
                    If Seg.HasPermission("MantEjerciciosContables") Then
                        LlamaEjerciciosContables()
                    End If


                    '        '****************** VARIOS ************************
                    '    Case "Ayuda"
                    '        LlamaAyuda()
                Case "Salir"
                    LlamaSalir()
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub InicializaBarraEstado()
        Try

            'Me.tmrGeneral.Start()
            Me.staFecha.Text = Format(Now.Date, "dd-MM-yyyy")
            Me.staBaseDatos.Text = "Base de Datos: " + InfoSistema.DBName
            Me.staServidor.Text = "Servidor: " + InfoSistema.ServerName
            Me.staHora.Text = "@" & IO.File.GetLastWriteTime(Application.ExecutablePath)
            If Trim(InfoSistema.UsrName) <> "" Then
                Me.staLogin.Text = "Usuario: " + InfoSistema.UsrName
            Else
                Me.staLogin.Text = "Usuario: " + InfoSistema.LoginName
            End If
            Me.staUnidadSalud.Text = ""

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Private Sub tmrGeneral_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Try
    '        Me.staHora.Text = Now.ToLongTimeString

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try


    'End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ''*********************** Menú Catálogos *********************

            'Opción Estructura Contable
            If Seg.HasPermission("MantEstructuraContable") Then
                Me.mnuEstructuraCta.Enabled = True
            Else
                Me.mnuEstructuraCta.Enabled = False
            End If

            'Opción Fuente de Financiamiento
            If Seg.HasPermission("MantFuenteFinanciamiento") Then
                Me.mnuFuentesFinan.Enabled = True
            Else
                Me.mnuFuentesFinan.Enabled = False
            End If

            'Opción Cuenta Bancaria
            If Seg.HasPermission("MantCtaBancaria") Then
                Me.mnuCtaBancaria.Enabled = True
            Else
                Me.mnuCtaBancaria.Enabled = False
            End If

            'Opción Catálogo Contable
            If Seg.HasPermission("MantCatalogoContable") Then
                Me.mnuCatContable.Enabled = True
            Else
                Me.mnuCatContable.Enabled = False
            End If

            'Opción Revisar Solicitud de Cheque
            If Seg.HasPermission("MantRevisarSolCheque") Then
                Me.mnuRevisarSolCheque.Enabled = True
            Else
                Me.mnuRevisarSolCheque.Enabled = False
            End If

            'Opción Autorizar Solicitud de Cheque
            If Seg.HasPermission("MantAutorizarSolCheque") Then
                Me.mnuAutorizarSolCheque.Enabled = True
            Else
                Me.mnuAutorizarSolCheque.Enabled = False
            End If

            'Opción Parámetros Contables
            If Seg.HasPermission("MantParametrosContables") Then
                Me.mnuParametrosContables.Enabled = True
            Else
                Me.mnuParametrosContables.Enabled = False
            End If

            'Opción Parámetros Contables Proveedores anexado 21/08/2014
            If Seg.HasPermission("MantParametrosContablesProveedores") Then
                Me.mnuParametrosContablesProveedores.Enabled = True
            Else
                Me.mnuParametrosContablesProveedores.Enabled = False
            End If


            'Opción Registro Cheque Socias
            If Seg.HasPermission("MantChequeSocia") Then
                Me.mnuChequeSocia.Enabled = True
            Else
                Me.mnuChequeSocia.Enabled = False
            End If

            'Opción Comprobante de Diario
            If Seg.HasPermission("MantComprobanteDiario") Then
                Me.mnuComprobanteDiario.Enabled = True
            Else
                Me.mnuComprobanteDiario.Enabled = False
            End If

            'Opción Comprobante de Recuperación
            If Seg.HasPermission("MantComprobanteRecuperacion") Then
                Me.mnuRecuperacionAjuste.Enabled = True
            Else
                Me.mnuRecuperacionAjuste.Enabled = False
            End If

            'Opción Recibo de Ingreso de Fondos
            If Seg.HasPermission("MantReciboIngreso") Then
                Me.mnuIngresoFondo.Enabled = True
            Else
                Me.mnuIngresoFondo.Enabled = False
            End If

            'Opción Minuta de Depósito
            If Seg.HasPermission("MantMinutaDeposito") Then
                Me.mnuMinuta.Enabled = True
            Else
                Me.mnuMinuta.Enabled = False
            End If

            'Opción Ejercicios Contables
            If Seg.HasPermission("MantEjerciciosContables") Then
                Me.mnuEjercicioContable.Enabled = True
            Else
                Me.mnuEjercicioContable.Enabled = False
            End If

            'Opción Imprimir Balanza de Comprobación CN12
            If Seg.HasPermission("ImprimirBalanzaComprobacionCN12") Then
                Me.mnuBalanzaComprobacion.Enabled = True
            Else
                Me.mnuBalanzaComprobacion.Enabled = False
            End If

            'Opción Imprimir Tarjeta Auxiliar CN11
            If Seg.HasPermission("ImprimirTarjetaAuxiliarCN11") Then
                Me.mnuTarjetaAuxiliar.Enabled = True
            Else
                Me.mnuTarjetaAuxiliar.Enabled = False
            End If

            'Opción Imprimir Resumen de Transacciones CN14
            If Seg.HasPermission("ImprimirResumenTransaccionesCN14") Then
                Me.mnuResumenTransaccionesContables.Enabled = True
            Else
                Me.mnuResumenTransaccionesContables.Enabled = False
            End If

            'Opción Imprimir Detalle de Transacciones CN13
            If Seg.HasPermission("ImprimirDetalleTransaccionesCN13") Then
                Me.mnuDetalleTransaccionesContables.Enabled = True
            Else
                Me.mnuDetalleTransaccionesContables.Enabled = False
            End If

            'Opción Imprimir Estado de Resultados CN18
            If Seg.HasPermission("ImprimirEstadoResultados") Then
                Me.mnuEstadoResultado.Enabled = True
            Else
                Me.mnuEstadoResultado.Enabled = False
            End If

            'Opción Imprimir Balance General CN19
            If Seg.HasPermission("ImprimirBalanceGeneral") Then
                Me.mnuBalanceGeneral.Enabled = True
            Else
                Me.mnuBalanceGeneral.Enabled = False
            End If

            'Opción Imprimir Cuadratura de Minutas CN20M
            If Seg.HasPermission("ImprimirCuadraturaMinutasCN20M") Then
                Me.mnuEstadoMinuta.Enabled = True
            Else
                Me.mnuEstadoMinuta.Enabled = False
            End If

            'Opción Imprimir Minutas Enviadas CN21
            If Seg.HasPermission("ImprimirMinutasEnviadas") Then
                Me.mnuMinutasEnviadas.Enabled = True
            Else
                Me.mnuMinutasEnviadas.Enabled = False
            End If

            'Opción Imprimir Errores Minutas Enviadas CN22
            If Seg.HasPermission("ImprimirErroresMinutas") Then
                Me.mnuErroresMinutas.Enabled = True
            Else
                Me.mnuErroresMinutas.Enabled = False
            End If

            'Opción Imprimir Listado de Minutas y Recibos CN24
            If Seg.HasPermission("ImprimirListadoMinutasRecibos") Then
                Me.mnuMinutasRecibosCN24.Enabled = True
            Else
                Me.mnuMinutasRecibosCN24.Enabled = False
            End If

            'Opción Imprimir Detalle Ingresos X Recuperaciónes CN25
            If Seg.HasPermission("ImprimirDetalleIngresosRecuperadosCN25") Then
                Me.mnuReporteCN25.Enabled = True
            Else
                Me.mnuReporteCN25.Enabled = False
            End If

            'Opción Enviar Inf. Créditos CARUNA
            If Seg.HasPermission("EnviarInfCreditosCARUNA") Then
                Me.mnuCreditosCARUNA.Enabled = True
            Else
                Me.mnuCreditosCARUNA.Enabled = False
            End If

            'Opción Recepción Recuperaciones CARUNA
            If Seg.HasPermission("RecepcionRecuperacionesCARUNA") Then
                Me.mnuRecuperacionesCARUNA.Enabled = True
            Else
                Me.mnuRecuperacionesCARUNA.Enabled = False
            End If

            'Opción Cierre Diario de Caja

            If Seg.HasPermission("MantCierre") Then
                Me.mnuCierreConDeposito.Enabled = True
            Else
                Me.mnuCierreConDeposito.Enabled = False
            End If

            'Opción Reporte CN26
            If Seg.HasPermission("ImprimirListadoMinutasSinComprobantesCN26") Then
                Me.mnuReporteCN26.Enabled = True
            Else
                Me.mnuReporteCN26.Enabled = False
            End If

            'Opción Reporte CN28
            If Seg.HasPermission("ImprimirReporteCN28") Then
                Me.mnuReporteCN28.Enabled = True
            Else
                Me.mnuReporteCN28.Enabled = False
            End If

            'Opción Reporte CN30
            If Seg.HasPermission("ImprimirListadoComprobantesRecuperacionAjustesCN30") Then
                Me.mnuReporteCN30.Enabled = True
            Else
                Me.mnuReporteCN30.Enabled = False
            End If

            'Reporte CC54
            If Seg.HasPermission("ImprimirReporteCC54") Then
                Me.mnuReporteCC54.Enabled = True
            Else
                Me.mnuReporteCC54.Enabled = False
            End If

            'Reporte CN31
            If Seg.HasPermission("ImprimirReporteCN31") Then
                Me.mnuReporteCN31.Enabled = True
            Else
                Me.mnuReporteCN31.Enabled = False
            End If

            'Reporte CC51
            If Seg.HasPermission("ImprimirReporteCC51") Then
                Me.mnuReporteCC51.Enabled = True
            Else
                Me.mnuReporteCC51.Enabled = False
            End If

            'Reporte CC55
            If Seg.HasPermission("ImprimirReporteCC55") Then
                Me.mnuReporteCC55.Enabled = True
            Else
                Me.mnuReporteCC55.Enabled = False
            End If

            'Reporte CN32
            If Seg.HasPermission("ImprimirReporteCN32") Then
                Me.mnuReporteCN32.Enabled = True
            Else
                Me.mnuReporteCN32.Enabled = False
            End If

            'Reporte CC57
            If Seg.HasPermission("ImprimirReporteCC57") Then
                Me.mnuReporteCC57.Enabled = True
            Else
                Me.mnuReporteCC57.Enabled = False
            End If

            'Reporte CC59
            If Seg.HasPermission("ImprimirReporteCC59") Then
                Me.mnuReporteCC59.Enabled = True
            Else
                Me.mnuReporteCC59.Enabled = False
            End If

            'Reporte CN33
            If Seg.HasPermission("ImprimirReporteCN33") Then
                Me.mnuReporteCN33.Enabled = True
            Else
                Me.mnuReporteCN33.Enabled = False
            End If

            'Reporte CN34
            If Seg.HasPermission("ImprimirReporteCN34") Then
                Me.mnuReporteCN34.Enabled = True
            Else
                Me.mnuReporteCN34.Enabled = False
            End If

            'Reporte CN35
            If Seg.HasPermission("ImprimirReporteCN35") Then
                Me.mnuReporteCN35.Enabled = True
            Else
                Me.mnuReporteCN35.Enabled = False
            End If

            'Reporte CN37
            If Seg.HasPermission("ImprimirReporteCN37") Then
                Me.mnuReporteCN37.Enabled = True
            Else
                Me.mnuReporteCN37.Enabled = False
            End If

            'Reporte CN39
            If Seg.HasPermission("ImprimirReporteCN39") Then
                Me.mnuReporteCN39.Enabled = True
            Else
                Me.mnuReporteCN39.Enabled = False
            End If

            'Reporte CN40
            If Seg.HasPermission("ImprimirReporteCN40") Then
                Me.mnuReporteCN40.Enabled = True
            Else
                Me.mnuReporteCN40.Enabled = False
            End If

            '***************************************************
            'SEGURIDAD a las Opciones del Toolbar VERTICAL *****
            '***************************************************

            '*********Catálogos
            'Estructura Contable
            If Seg.HasPermission("MantEstructuraContable") Then
                Me.UlbContabilidad.Groups("Catalogos").Items("EstructuraCuentas").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("Catalogos").Items("EstructuraCuentas").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("Catalogos").Items("EstructuraCuentas").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("Catalogos").Items("EstructuraCuentas").Appearance.ForeColor = Color.DarkGray
            End If

            'Fuentes de Financiamiento
            If Seg.HasPermission("MantFuenteFinanciamiento") Then
                Me.UlbContabilidad.Groups("Catalogos").Items("FuenteFinanciamiento").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("Catalogos").Items("FuenteFinanciamiento").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("Catalogos").Items("FuenteFinanciamiento").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("Catalogos").Items("FuenteFinanciamiento").Appearance.ForeColor = Color.DarkGray
            End If

            'Registro de Cuenta Bancaria
            If Seg.HasPermission("MantCtaBancaria") Then
                Me.UlbContabilidad.Groups("Catalogos").Items("CuentaBancaria").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("Catalogos").Items("CuentaBancaria").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("Catalogos").Items("CuentaBancaria").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("Catalogos").Items("CuentaBancaria").Appearance.ForeColor = Color.DarkGray
            End If

            'Catálogo Contable
            If Seg.HasPermission("MantCatalogoContable") Then
                Me.UlbContabilidad.Groups("Catalogos").Items("CatalogoContable").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("Catalogos").Items("CatalogoContable").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("Catalogos").Items("CatalogoContable").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("Catalogos").Items("CatalogoContable").Appearance.ForeColor = Color.DarkGray
            End If

            'Revisar Solicitud de Cheque
            If Seg.HasPermission("MantRevisarSolCheque") Then
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Revisar").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Revisar").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Revisar").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Revisar").Appearance.ForeColor = Color.DarkGray
            End If

            'Autorizar Solicitud de Cheque
            If Seg.HasPermission("MantAutorizarSolCheque") Then
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Autorizar").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Autorizar").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Autorizar").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("Autorizar").Appearance.ForeColor = Color.DarkGray
            End If

            'Parámetros Contables
            If Seg.HasPermission("MantParametrosContables") Then
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("ParametrosContables").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("ParametrosContables").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("ParametrosContables").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("ParametrosContables").Appearance.ForeColor = Color.DarkGray
            End If

            'Registro Cheque Socia
            If Seg.HasPermission("MantChequeSocia") Then
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ChequeSocia").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ChequeSocia").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ChequeSocia").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ChequeSocia").Appearance.ForeColor = Color.DarkGray
            End If

            'Comprobante de Diario
            If Seg.HasPermission("MantComprobanteDiario") Then
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteDiario").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteDiario").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteDiario").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteDiario").Appearance.ForeColor = Color.DarkGray
            End If

            'Comprobante de Recuperación
            If Seg.HasPermission("MantComprobanteRecuperacion") Then
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteRecuperacion").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteRecuperacion").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteRecuperacion").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("TransaccionContable").Items("ComprobanteRecuperacion").Appearance.ForeColor = Color.DarkGray
            End If

            'Recibo de Ingreso de Fondos
            If Seg.HasPermission("MantReciboIngreso") Then
                Me.UlbContabilidad.Groups("TransaccionContable").Items("IngresoFondo").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("TransaccionContable").Items("IngresoFondo").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("TransaccionContable").Items("IngresoFondo").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("TransaccionContable").Items("IngresoFondo").Appearance.ForeColor = Color.DarkGray
            End If

            'Ejercicios Contables
            If Seg.HasPermission("MantEjerciciosContables") Then
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("EjercicioContable").Appearance.Cursor = Cursors.Hand
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("EjercicioContable").Appearance.ForeColor = Color.Black
            Else
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("EjercicioContable").Appearance.Cursor = Cursors.Default
                Me.UlbContabilidad.Groups("SolicitudCheque").Items("EjercicioContable").Appearance.ForeColor = Color.DarkGray
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaEstructuraCuentas()

        Dim ObjFrmScnEstructuraContable As New frmScnEstructuraContable
        Try
            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmScnEstructuraContable.MdiParent = Me

            ObjFrmScnEstructuraContable.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmScnEstructuraContable, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmScnEstructuraContable.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEstructuraContable = Nothing
        End Try
    End Sub

    Private Sub LlamaFuenteFinanciamiento()
        Dim ObjFrmScnFuenteF As New frmScnFuenteF
        Try
            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmScnFuenteF.MdiParent = Me

            ObjFrmScnFuenteF.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmScnFuenteF, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmScnFuenteF.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnFuenteF = Nothing
        End Try
    End Sub
    Private Sub LlamaCtaBancaria()
        Dim ObjFrmSteCtaBancaria As New frmSteCtaBancaria
        Try
            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteCtaBancaria.MdiParent = Me

            ObjFrmSteCtaBancaria.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSteCtaBancaria, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteCtaBancaria.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteCtaBancaria = Nothing
        End Try
    End Sub
    Private Sub LlamaCatalogoContable()
        Dim ObjFrmScnCatalogoContable As New frmScnCatalogoContable
        Try
            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmScnCatalogoContable.MdiParent = Me

            ObjFrmScnCatalogoContable.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmScnCatalogoContable, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmScnCatalogoContable.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnCatalogoContable = Nothing
        End Try
    End Sub
    Private Sub mnuEstructuraCta_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEstructuraCta.Click
        LlamaEstructuraCuentas()
    End Sub

    Private Sub mnuFuentesFinan_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFuentesFinan.Click
        LlamaFuenteFinanciamiento()
    End Sub

    Private Sub mnuCtaBancaria_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCtaBancaria.Click
        LlamaCtaBancaria()
    End Sub

    Private Sub mnuCatContable_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCatContable.Click
        LlamaCatalogoContable()
    End Sub

    Private Sub mnuCierreConDeposito_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCierreConDeposito.Click
        LlamaCierreDiarioCaja()
    End Sub
    Private Sub LlamaCierreDiarioCaja()
        Dim ObjFrmSccCierreCaja As New frmSccCierreCaja
        Try
            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccCierreCaja.MdiParent = Me

            ObjFrmSccCierreCaja.WindowState = FormWindowState.Maximized
            ObjFrmSccCierreCaja.sColorFrm = "Celeste"
            OpenForm(ObjFrmSccCierreCaja, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccCierreCaja.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccCierreCaja = Nothing
        End Try
    End Sub

    Private Sub mnuRevisarSolCheque_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRevisarSolCheque.Click
        LlamaSolicitudCheque("REV")
    End Sub

    Private Sub mnuAutorizarSolCheque_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAutorizarSolCheque.Click
        LlamaSolicitudCheque("AUT")
    End Sub
    Private Sub LlamaSolicitudCheque(ByVal StrAccion As String)

        Dim ObjFrmSccSolicitudCheque As New frmSccSolicitudCheque
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccSolicitudCheque.MdiParent = Me

            ObjFrmSccSolicitudCheque.WindowState = FormWindowState.Maximized
            'ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            ObjFrmSccSolicitudCheque.ModoAccion = StrAccion
            ObjFrmSccSolicitudCheque.TipoCheque = 0
            ObjFrmSccSolicitudCheque.sColorFrm = "Celeste"
            OpenForm(ObjFrmSccSolicitudCheque, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccSolicitudCheque.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccSolicitudCheque = Nothing
        End Try
    End Sub

    Private Sub mnuRecuperacionAjuste_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRecuperacionAjuste.Click
        LlamaRegistroComprobante("CR")
    End Sub
    Private Sub LlamaRegistroComprobante(ByVal StrTipoCD As String)
        Dim ObjFrmComprobante As New frmScnComprobantesDiario
        Try

            'Dim ObjFrmComprobante As New frmScnComprobantesDiario
            'ObjFrmComprobante = New frmScnComprobantesDiario

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmComprobante.MdiParent = Me

            ObjFrmComprobante.WindowState = FormWindowState.Maximized
            ObjFrmComprobante.sTipoCD = StrTipoCD
            OpenForm(ObjFrmComprobante, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmComprobante.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmComprobante = Nothing
        End Try
    End Sub

    Private Sub mnuComprobanteDiario_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuComprobanteDiario.Click
        LlamaRegistroComprobante("CD")
    End Sub

    Private Sub mnuChequeSocia_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuChequeSocia.Click
        LlamaRegistroCheques()
    End Sub
    Private Sub LlamaRegistroCheques()
        Dim ObjFrmComprobante As New frmScnComprobantesCheque
        Try

            'Dim ObjFrmComprobante As New frmScnComprobantesCheque
            'ObjFrmComprobante = New frmScnComprobantesCheque

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmComprobante.MdiParent = Me

            ObjFrmComprobante.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmComprobante, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmComprobante.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmComprobante = Nothing
        End Try
    End Sub

    Private Sub mnuIngresoFondo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuIngresoFondo.Click
        LlamaRegistroIngresoFondos()
    End Sub
    Private Sub LlamaRegistroIngresoFondos()
        Dim ObjFrmComprobante As New frmScnReciboIngresoFondos
        Try

            'Dim ObjFrmComprobante As New frmScnReciboIngresoFondos
            'ObjFrmComprobante = New frmScnReciboIngresoFondos

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmComprobante.MdiParent = Me

            ObjFrmComprobante.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmComprobante, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmComprobante.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmComprobante = Nothing
        End Try

    End Sub

    Private Sub LlamaParametrosContablesProveedores()
        Try
            Dim ObjFrmParametro As frmSrhProveedorTransaccionParametro
            ObjFrmParametro = New frmSrhProveedorTransaccionParametro

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmParametro.MdiParent = Me

            ObjFrmParametro.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmParametro, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmParametro.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub mnuParametrosContables_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuParametrosContables.Click
        LlamaParametrosContables()
    End Sub
    Private Sub LlamaParametrosContables()
        Dim ObjFrmComprobante As New frmScnParametrosContables
        Try

            'Dim ObjFrmComprobante As New frmScnParametrosContables
            ''ObjFrmComprobante = New frmScnReciboIngresoFondos

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmComprobante.MdiParent = Me

            ObjFrmComprobante.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmComprobante, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmComprobante.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmComprobante = Nothing
        End Try

    End Sub

    REM Anterior Reporte CN39: Auxiliar de Banco Sin Afectación a Caja.
    REM  LlamaImprimirListado(7)

    Private Sub LlamaImprimirListado(ByVal IDReporte As Integer)
        Dim ObjFrmScnParametroMovimientoContable As New frmScnParametroMovimientoContable
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmScnParametroMovimientoContable.NomRep = IDReporte
            ObjFrmScnParametroMovimientoContable.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnParametroMovimientoContable.Close()
            ObjFrmScnParametroMovimientoContable = Nothing
        End Try
    End Sub

    Private Sub mnuBalanzaComprobacion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuBalanzaComprobacion.Click
        LlamaImprimirListado(4)
    End Sub

    Private Sub mnuTarjetaAuxiliar_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTarjetaAuxiliar.Click
        LlamaImprimirListado(3)
    End Sub

    Private Sub mnuResumenTransaccionesContables_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuResumenTransaccionesContables.Click
        LlamaImprimirListado(2)
    End Sub

    Private Sub mnuDetalleTransaccionesContables_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDetalleTransaccionesContables.Click
        LlamaImprimirListado(1)
    End Sub

    Private Sub mnuMinuta_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMinuta.Click
        LlamaRegistroMinutas()
    End Sub
    Private Sub LlamaRegistroMinutas()
        Try

            Dim ObjFrmMinuta As frmSteMinutaDeposito
            ObjFrmMinuta = New frmSteMinutaDeposito

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmMinuta.MdiParent = Me
            ObjFrmMinuta.sColorFrm = "Celeste"

            ObjFrmMinuta.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmMinuta, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmMinuta.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuEjercicioContable_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEjercicioContable.Click
        LlamaEjerciciosContables()
    End Sub
    Private Sub LlamaEjerciciosContables()
        Try

            Dim ObjFrmScnEjerciciosContables As frmScnEjerciciosContables
            ObjFrmScnEjerciciosContables = New frmScnEjerciciosContables

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmScnEjerciciosContables.MdiParent = Me

            ObjFrmScnEjerciciosContables.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmScnEjerciciosContables, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmScnEjerciciosContables.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    'Private Sub mnuER_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuER.Click
    '    LlamaImprimirEstadoFinanciero(1)
    'End Sub

    'Private Sub mnuBG_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuBG.Click
    '    LlamaImprimirEstadoFinanciero(2)
    'End Sub

    Private Sub LlamaImprimirEstadoFinanciero(ByVal IDReporte As Integer)
        Dim ObjFrmScnParametroEstadoFinanciero As New frmScnParametroEstadosFinancieros
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            ObjFrmScnParametroEstadoFinanciero.NomRep = IDReporte
            ObjFrmScnParametroEstadoFinanciero.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnParametroEstadoFinanciero.Close()
            ObjFrmScnParametroEstadoFinanciero = Nothing
        End Try
    End Sub
    Private Sub LlamaImprimirEstadoMinuta(ByVal IDReportes As Integer)
        Dim ObjFrmScnParametroMinuta As New frmScnParametrosMinutas
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            ObjFrmScnParametroMinuta.NomRep = IDReportes
            ObjFrmScnParametroMinuta.ColorVentana = "CelesteLight"
            ObjFrmScnParametroMinuta.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnParametroMinuta.Close()
            ObjFrmScnParametroMinuta = Nothing
        End Try
    End Sub


    Private Sub mnuEstadoResultado_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEstadoResultado.Click
        LlamaImprimirEstadoFinanciero(1)
    End Sub

    Private Sub mnuBalanceGeneral_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuBalanceGeneral.Click
        LlamaImprimirEstadoFinanciero(2)
    End Sub

    Private Sub mnuEstadoMinuta_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEstadoMinuta.Click
        LlamaImprimirEstadoMinuta(1)
    End Sub

    Private Sub mnuMinutasEnviadas_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMinutasEnviadas.Click
        LlamaImprimirEstadoMinuta(2)
    End Sub

    Private Sub mnuErroresMinutas_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuErroresMinutas.Click
        LlamaImprimirEstadoMinuta(3)
    End Sub

    Private Sub mnuMinutasRecibosCN24_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMinutasRecibosCN24.Click
        LlamaParametrosMercado(6)
    End Sub
    Private Sub LlamaParametrosMercado(ByVal IDNomRep As Integer)
        Dim ObjFrmFNC As New FrmScnParametroListadoCreditosMercados
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            ObjFrmFNC.NomRep = IDNomRep
            ObjFrmFNC.sColorFrm = "CelesteLight"
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuCreditosCARUNA_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCreditosCARUNA.Click
        LlamaExportar()
    End Sub
    Private Sub LlamaExportar()
        Dim ObjFrmSccDescarga As New FrmSccDescargaPorFuente
        Try

            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            'Dim ObjFrmSteConciliacionBancaria As frmSteConciliacionBancaria
            'ObjFrmSteConciliacionBancaria = New frmSteConciliacionBancaria

            '-- Poner el cursor en un estado de ocupado
            'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'ObjFrmSccDescarga.MdiParent = Me

            'ObjFrmSccDescarga.WindowState = FormWindowState.Maximized
            ObjFrmSccDescarga.ColorVentana = "CelesteLight"
            ObjFrmSccDescarga.ShowDialog()

            'OpenForm(ObjFrmSccDescarga, Me)

            ''-- Para enviar el foco al formulario 
            ''-- que se está llamando.
            'ObjFrmSccDescarga.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            'Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccDescarga.Close()
            ObjFrmSccDescarga = Nothing
        End Try
    End Sub

    Private Sub mnuRecuperacionesCARUNA_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRecuperacionesCARUNA.Click
        LlamaImportar()
    End Sub
    Private Sub LlamaImportar()
        Dim ObjFrmSccCarga As New FrmSccCarga
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            'Dim ObjFrmSteConciliacionBancaria As frmSteConciliacionBancaria
            'ObjFrmSteConciliacionBancaria = New frmSteConciliacionBancaria

            '-- Poner el cursor en un estado de ocupado
            'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'ObjFrmSccCarga.MdiParent = Me

            'ObjFrmSccCarga.WindowState = FormWindowState.Maximized
            ObjFrmSccCarga.ColorVentana = "Verde"
            ObjFrmSccCarga.ShowDialog()
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            'OpenForm(ObjFrmSccCarga, Me)

            ''-- Para enviar el foco al formulario 
            ''-- que se está llamando.
            'ObjFrmSccCarga.BringToFront()

            ''-- Poner el cursor en un estado de desocupado
            'Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccCarga.Close()
            ObjFrmSccCarga = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCN25_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN25.Click
        LlamaParametrosMercado(7)
    End Sub

    Private Sub mnuReporteCN26_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN26.Click
        LlamaParametrosMercado(8)
    End Sub

    Private Sub mnuReporteCN28_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN28.Click
        LlamaImprimirEstadoMinuta(4)
    End Sub

    Private Sub mnuReporteCN30_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN30.Click
        LlamaImprimirListado(5)
    End Sub

    Private Sub mnuReporteCC54_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC54.Click
        LlamaImprimirListadosIndicadores(5)
    End Sub
    Private Sub LlamaImprimirListadosIndicadores(ByVal IDReporte As Integer)
        Dim ObjFrmSccParametroRpt As New frmSccParametrosIndicadores
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            ObjFrmSccParametroRpt.NomRep = IDReporte
            ObjFrmSccParametroRpt.ColorVentana = "CelesteLight"
            ObjFrmSccParametroRpt.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametroRpt.Close()
            ObjFrmSccParametroRpt = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCN31_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN31.Click
        LlamaImprimirListadosIndicadores(6)
    End Sub

    Private Sub mnuReporteCC51_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC51.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "CelesteLight"
            ObjFrmFNC.NomRep = 7
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC55_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC55.Click
        LlamaImprimirListadosIndicadores(7)
    End Sub

    Private Sub mnuReporteCN32_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN32.Click
        LlamaImprimirListadosIndicadores(8)
    End Sub

    Private Sub mnuReporteCC57_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC57.Click
        LlamaImprimirListadosIndicadores(9)
    End Sub

    Private Sub mnuReporteCC59_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC59.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "CelesteLight"
            ObjFrmFNC.NomRep = 10
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCN33_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN33.Click
        LlamaImprimirEstadoMinuta(8)
    End Sub

    Private Sub mnuReporteCN34_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN34.Click
        LlamaImprimirEstadoMinuta(9)
    End Sub

    Private Sub mnuReporteCN35_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN35.Click
        LlamaImprimirEstadoMinuta(10)
    End Sub

    Private Sub mnuReporteCN37_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN37.Click
        LlamaImprimirListado(6)
    End Sub

    Private Sub mnuReporteCN39_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN39.Click
        REM LlamaImprimirListado(7)
        Dim ObjFrmChequesEmitidos As New FrmScnParametrosListadoCheques
        Try

            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If
            ObjFrmChequesEmitidos.NomRep = 4
            ObjFrmChequesEmitidos.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmChequesEmitidos.Close()
            ObjFrmChequesEmitidos = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCN40_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN40.Click
        REM LlamaImprimirListado(8)
        LlamaImprimirEstadoMinuta(11)
    End Sub

    Private Sub mnuParametrosContablesProveedores_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuParametrosContablesProveedores.Click
        LlamaParametrosContablesProveedores()
    End Sub

End Class
