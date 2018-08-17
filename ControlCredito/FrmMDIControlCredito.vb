Imports System.Windows.Forms
Imports Microsoft.Win32
Public Class FrmMDIControlCredito

    'Private Sub FrmMDIControlCredito_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    Try
    '        Me.Text = "SMUSURA0 - Módulo de Control de Crédito"
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    Private Sub FrmMDIControlCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI

            ObjGUI.AppPath = Application.StartupPath

            ObjGUI.SetFormLayout(Me, "Verde")

            Me.Text = "SMUSURA0 - Módulo de Control de Crédito"
            InicializaBarraEstado()
            Seguridad()

            '---------------------------------------------------------
            'Seleccionar el primer grupo de la toolbar vertical
            Me.UlbControlCredito.Groups(0).Selected = True

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

    Private Sub UlbControlCredito_ItemSelected(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListBar.ItemEventArgs) Handles UlbControlCredito.ItemSelected
        Try
            Select Case e.Item.Key

                Case "Recibo"
                    If Seg.HasPermission("MantRecibo") Then
                        LlamaReciboOficialCaja(2)
                    End If
                Case "ReciboAutomatico"
                    If Seg.HasPermission("MantReciboAutomatico") Then
                        LlamaReciboOficialCajaAutomatico(1)
                    End If
                Case "Cierre"
                    'If Seg.HasPermission("MantCierre") Then
                    '    LlamaCierreDiarioCaja()
                    'End If
                Case "FichaNotificacion"
                    If Seg.HasPermission("MantFichaNotificacion") Then
                        LlamarRegistroFNC()
                    End If
                Case "TrasladoLugarPago"
                    If Seg.HasPermission("MantTrasladoLugarPago") Then
                        LlamaTrasladoLugarPago()
                    End If
                Case "Registrar"
                    If Seg.HasPermission("MantRegistrarSolCheque") Then
                        LlamaSolicitudCheque("ELA")
                    End If
                Case "ReestructuracionCredito"
                    If Seg.HasPermission("MantReestructuracionDeuda") Then
                        LlamaReestructurarDeuda()
                    End If
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

    'Private Sub tmrGeneral_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrGeneral.Tick

    '    Try
    '        Me.staHora.Text = Now.ToLongTimeString

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try


    'End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            If Seg.HasPermission("CierreCarteraMensual") Then
                Me.mnuCierreCarteraMensual.Enabled = True
            Else
                Me.mnuCierreCarteraMensual.Enabled = False
            End If

            ''*********************** Menú Recuperación Cartera *********************

            'Opción Recibo Oficial de Caja Automático
            If Seg.HasPermission("MantReciboAutomatico") Then
                Me.mnuReciboAutomatico.Enabled = True
            Else
                Me.mnuReciboAutomatico.Enabled = False
            End If
            'Opción Recibo Oficial de Caja
            If Seg.HasPermission("MantRecibo") Then
                Me.mnuReciboOficialCaja.Enabled = True
            Else
                Me.mnuReciboOficialCaja.Enabled = False
            End If

            'Opción Préstamos Cancelados
            If Seg.HasPermission("MantPrestamoCancelado") Then
                Me.mnuPrestamosCancelados.Enabled = True
            Else
                Me.mnuPrestamosCancelados.Enabled = False
            End If

            'Opción Cierre Diario de Caja
            If Seg.HasPermission("MantCierre") Then
                Me.mnuCierreDiarioCaja.Enabled = True
            Else
                Me.mnuCierreDiarioCaja.Enabled = False
            End If

            'Opción Ficha de Notificación
            If Seg.HasPermission("MantFichaNotificacion") Then
                Me.mnuFichaNotificacion.Enabled = True
            Else
                Me.mnuFichaNotificacion.Enabled = False
            End If

            'Opción Traslado Lugar de Pago
            If Seg.HasPermission("MantTrasladoLugarPago") Then
                Me.mnuTrasladoLugarPago.Enabled = True
            Else
                Me.mnuTrasladoLugarPago.Enabled = False
            End If

            'Opción Registro de Solicitud de Cheque
            If Seg.HasPermission("MantRegistrarSolCheque") Then
                Me.mnuRegistrarSolCheque.Enabled = True
            Else
                Me.mnuRegistrarSolCheque.Enabled = False
            End If

            'Opción Listado de Recibos CC17,CC17
            If Seg.HasPermission("ImprimirListadoRecibos") Then
                Me.mnuListadoRecibos.Enabled = True
            Else
                Me.mnuListadoRecibos.Enabled = False
            End If

            'Opción Imprimir Socias X Cantidad de Créditos CC25
            If Seg.HasPermission("ImprimirSociasCreditos") Then
                Me.mnuSociasCreditos.Enabled = True
            Else
                Me.mnuSociasCreditos.Enabled = False
            End If

            'Opción Listado Cheques CN16
            If Seg.HasPermission("ImprimirListadoCheques") Then
                Me.mnuListadoCheques.Enabled = True
            Else
                Me.mnuListadoCheques.Enabled = False
            End If

            'Opción Listado Cheques x Fecha de Entrega CN38
            If Seg.HasPermission("ImprimirReporteCN38") Then
                Me.mnuReporteCN38.Enabled = True
            Else
                Me.mnuReporteCN38.Enabled = False
            End If

            'Opción Créditos Aprobados Mercados CS19
            If Seg.HasPermission("ImprimirCreditosMercados") Then
                Me.mnuDetalleMercados.Enabled = True
            Else
                Me.mnuDetalleMercados.Enabled = False
            End If

            'Opción Avance Recuperación Cartera  CC18
            If Seg.HasPermission("ImprimirAvanceRecuperacionCartera") Then
                Me.mnuAvanceRecuperacionCartera.Enabled = True
            Else
                Me.mnuAvanceRecuperacionCartera.Enabled = False
            End If

            'Opción Reporte de Recuperaciones CS20
            If Seg.HasPermission("ImprimirRecuperaciones") Then
                Me.mnuReporteRecuperaciones.Enabled = True
            Else
                Me.mnuReporteRecuperaciones.Enabled = False
            End If

            'Opción Grupos Aprobados CS19
            If Seg.HasPermission("ImprimirGruposAprobados") Then
                Me.mnuGruposAprobados.Enabled = True
            Else
                Me.mnuGruposAprobados.Enabled = False
            End If


            'Opción Resumen Créditos CC2..CC7
            If Seg.HasPermission("RepResumenCredito") Then
                Me.mnuResumenCredito.Enabled = True
            Else
                Me.mnuResumenCredito.Enabled = False
            End If

            'Opción Exportar Recibos Cajero
            'If Seg.HasPermission("MantExportarRecibosCajero") Then
            '    Me.mnuExportarRecibos.Visible = True
            'Else
            '    Me.mnuExportarRecibos.Visible = False
            'End If

            'Opción Importar Información Cajero
            'If Seg.HasPermission("MantImportarInformacionCajero") Then
            '    Me.mnuImportarInformacion.Visible = True
            'Else
            '    Me.mnuImportarInformacion.Visible = False
            'End If

            'Opción Imprimir Préstamos Vencidos CC21
            If Seg.HasPermission("ImprimirPrestamosVencidos") Then
                Me.mnuPrestamosVencidos.Enabled = True
            Else
                Me.mnuPrestamosVencidos.Enabled = False
            End If

            'Opción Imprimir Consolidado Préstamos Vencidos CC22
            If Seg.HasPermission("ImprimirConsolidadoPrestamos") Then
                Me.mnuConsolidadoPrestamosVencidos.Enabled = True
            Else
                Me.mnuConsolidadoPrestamosVencidos.Enabled = False
            End If

            'Opción Reestructurar Deuda
            If Seg.HasPermission("MantReestructuracionDeuda") Then
                Me.mnuReestructuracionDeuda.Enabled = True
            Else
                Me.mnuReestructuracionDeuda.Enabled = False
            End If

            'Opción Indicadores
            If Seg.HasPermission("MantMetasPrograma") Then
                Me.mnuMetasPrograma.Enabled = True
            Else
                Me.mnuMetasPrograma.Enabled = False
            End If

            'Imprimir Formato de Captura de Datos (Indicadores)
            If Seg.HasPermission("ImprimirFormatoCapturaDatos") Then
                Me.mnuFormatoCaptura.Enabled = True
            Else
                Me.mnuFormatoCaptura.Enabled = False
            End If

            'Imprimir Tabla 1 (Indicadores)
            If Seg.HasPermission("ImprimirIndicadoresTabla1") Then
                Me.mnuTabla1.Enabled = True
            Else
                Me.mnuTabla1.Enabled = False
            End If

            'Imprimir Tabla 2 (Indicadores)
            If Seg.HasPermission("ImprimirIndicadoresTabla2") Then
                Me.mnuTabla2.Enabled = True
            Else
                Me.mnuTabla2.Enabled = False
            End If

            'Imprimir Tabla 3 (Indicadores)
            If Seg.HasPermission("ImprimirIndicadoresTabla3") Then
                Me.mnuTabla3.Enabled = True
            Else
                Me.mnuTabla3.Enabled = False
            End If

            'Imprimir Tabla 4 (Indicadores)
            If Seg.HasPermission("ImprimirIndicadoresTabla4") Then
                Me.mnuTabla4.Enabled = True
            Else
                Me.mnuTabla4.Enabled = False
            End If

            'Imprimir Tabla 5 (Indicadores)
            If Seg.HasPermission("ImprimirIndicadoresTabla5") Then
                Me.mnuTabla5.Enabled = True
            Else
                Me.mnuTabla5.Enabled = False
            End If

            'Imprimir Tabla 6 (Indicadores)
            If Seg.HasPermission("ImprimirIndicadoresTabla6") Then
                Me.mnuTabla6.Enabled = True
            Else
                Me.mnuTabla6.Enabled = False
            End If

            'Imprimir Tabla 7 (Indicadores)
            If Seg.HasPermission("ImprimirIndicadoresTabla7") Then
                Me.mnuTabla7.Enabled = True
            Else
                Me.mnuTabla7.Enabled = False
            End If

            'Imprimir Reporte de Control de la Mora CC27
            If Seg.HasPermission("ImprimirControlMora") Then
                Me.mnuControlMora.Enabled = True
            Else
                Me.mnuControlMora.Enabled = False
            End If

            'Imprimir Listado de Socias Aprobadas CC33,CC36
            If Seg.HasPermission("ImprimirListadoSociasAprobadas") Then
                Me.mnuSociasAprobadas.Enabled = True
            Else
                Me.mnuSociasAprobadas.Enabled = False
            End If

            'Imprimir Listado de Socias Morosas CC37
            If Seg.HasPermission("ImprimirListadoSociasMorosas") Then
                Me.mnuListadoSociasMorosas.Enabled = True
            Else
                Me.mnuListadoSociasMorosas.Enabled = False
            End If

            'Mapa Municipios Atendidos
            If Seg.HasPermission("MapaMunicipioAtendido") Then
                Me.mnuMapaMunicipiosAtendidos.Enabled = True
            Else
                Me.mnuMapaMunicipiosAtendidos.Enabled = False
            End If

            'Mapa Departamentos Atendidos
            If Seg.HasPermission("MapaDeptoAtendido") Then
                Me.mnuMapaDeptoAtendidos.Enabled = True
            Else
                Me.mnuMapaDeptoAtendidos.Enabled = False
            End If

            'Reporte CC43
            If Seg.HasPermission("ImprimirReporteCC43") Then
                Me.mnuReporteCC43.Enabled = True
            Else
                Me.mnuReporteCC43.Enabled = False
            End If

            'Reporte CC46
            If Seg.HasPermission("ImprimirReporteCC46") Then
                Me.mnuReporteCC46.Enabled = True
            Else
                Me.mnuReporteCC46.Enabled = False
            End If

            'Reporte CC47
            If Seg.HasPermission("ImprimirReporteCC47") Then
                Me.mnuReporteCC47.Enabled = True
            Else
                Me.mnuReporteCC47.Enabled = False
            End If

            'Reporte CC48
            If Seg.HasPermission("ImprimirReporteCC48") Then
                Me.mnuReporteCC48.Enabled = True
            Else
                Me.mnuReporteCC48.Enabled = False
            End If

            'Reporte CC49
            If Seg.HasPermission("ImprimirReporteCC49") Then
                Me.mnuReporteCC49.Enabled = True
            Else
                Me.mnuReporteCC49.Enabled = False
            End If

            'Reporte CC50
            If Seg.HasPermission("ImprimirReporteCC50") Then
                Me.mnuReporteCC50.Enabled = True
            Else
                Me.mnuReporteCC50.Enabled = False
            End If

            'Reporte CC51
            If Seg.HasPermission("ImprimirReporteCC51") Then
                Me.mnuReporteCC51.Enabled = True
            Else
                Me.mnuReporteCC51.Enabled = False
            End If

            'Estadísticas INIDE
            If Seg.HasPermission("MantRegistroINIDE") Then
                Me.mnuEstadisticasINIDE.Enabled = True
            Else
                Me.mnuEstadisticasINIDE.Enabled = False
            End If

            'Reporte CC54
            If Seg.HasPermission("ImprimirReporteCC54") Then
                Me.mnuReporteCC54.Enabled = True
            Else
                Me.mnuReporteCC54.Enabled = False
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

            'Reporte CC56
            If Seg.HasPermission("ImprimirReporteCC56") Then
                Me.mnuReporteCC56.Enabled = True
            Else
                Me.mnuReporteCC56.Enabled = False
            End If

            'Reporte CC58
            If Seg.HasPermission("ImprimirReporteCC58") Then
                Me.mnuReporteCC58.Enabled = True
            Else
                Me.mnuReporteCC58.Enabled = False
            End If

            'Reporte CC55
            If Seg.HasPermission("ImprimirReporteCC55") Then
                Me.mnuReporteCC55.Enabled = True
            Else
                Me.mnuReporteCC55.Enabled = False
            End If

            'Reporte CC59
            If Seg.HasPermission("ImprimirReporteCC59") Then
                Me.mnuReporteCC59.Enabled = True
            Else
                Me.mnuReporteCC59.Enabled = False
            End If

            'Reporte CC60
            If Seg.HasPermission("ImprimirReporteCC60") Then
                Me.mnuReporteCC60.Enabled = True
            Else
                Me.mnuReporteCC60.Enabled = False
            End If

            'Reporte CC61
            If Seg.HasPermission("ImprimirReporteCC61") Then
                Me.mnuReporteCC61.Enabled = True
            Else
                Me.mnuReporteCC61.Enabled = False
            End If

            'Cancelacion Manual
            If Seg.HasPermission("CancelacionAnticipadaManual") Then
                Me.mnuCancelacionManual.Enabled = True
            Else
                Me.mnuCancelacionManual.Enabled = False
            End If

            'Cancelacion Automatica
            If Seg.HasPermission("CancelacionAnticipadaAutomatica") Then
                Me.mnuCancelacionAutomatica.Enabled = True
            Else
                Me.mnuCancelacionAutomatica.Enabled = False
            End If

            'Reporte CC63
            If Seg.HasPermission("ImprimirReporteCC63") Then
                Me.mnuReporteCC63.Enabled = True
            Else
                Me.mnuReporteCC63.Enabled = False
            End If


            'Reporte CC64
            If Seg.HasPermission("ImprimirListadoPagaresSociasCC64") Then
                Me.mnuReporteCC64.Enabled = True
            Else
                Me.mnuReporteCC64.Enabled = False
            End If

            'Reporte CC65
            If Seg.HasPermission("ImprimirReporteCC65") Then
                Me.mnuReporteCC65.Enabled = True
            Else
                Me.mnuReporteCC65.Enabled = False
            End If


            'Reporte CC66
            If Seg.HasPermission("ImprimirReporteCC66") Then
                Me.mnuReporteCC66.Enabled = True
            Else
                Me.mnuReporteCC66.Enabled = False
            End If

            'Reporte CC68
            If Seg.HasPermission("ImprimirReporteCC68") Then
                Me.mnuReporteCC68.Enabled = True
            Else
                Me.mnuReporteCC68.Enabled = False
            End If


            'Reporte CC69
            If Seg.HasPermission("ImprimirReporteCC69") Then
                Me.mnuReporteCC69.Enabled = True
            Else
                Me.mnuReporteCC69.Enabled = False
            End If

            'Reporte CC70
            If Seg.HasPermission("ImprimirReporteCC70") Then
                Me.mnuReporteCC70.Enabled = True
            Else
                Me.mnuReporteCC70.Enabled = False
            End If

            'Reporte CC71:
            If Seg.HasPermission("ImprimirReporteCC71") Then
                Me.mnuReporteCC71.Enabled = True
            Else
                Me.mnuReporteCC71.Enabled = False
            End If

            'Arreglo de Pago
            If Seg.HasPermission("MantArregloPago") Then
                Me.mnuArregloPago.Enabled = True
            Else
                Me.mnuArregloPago.Enabled = False
            End If


            'Reporte CC72:
            If Seg.HasPermission("ImprimirReporteCC72") Then
                Me.mnuReporteCC72.Enabled = True
            Else
                Me.mnuReporteCC72.Enabled = False
            End If

            'Reporte CC75:
            If Seg.HasPermission("ImprimirReporteCC75") Then
                Me.cmdRepManual.Enabled = True
            Else
                Me.cmdRepManual.Enabled = False
            End If

            'Reporte CC76:
            If Seg.HasPermission("ImprimirReporteCC76") Then
                Me.mnuRecibosFechaIngreso.Enabled = True
            Else
                Me.mnuRecibosFechaIngreso.Enabled = False
            End If

            'Reporte CC77:
            If Seg.HasPermission("ImprimirReporteCC77") Then
                Me.mnuResumenGruposSociasAVencer.Enabled = True
            Else
                Me.mnuResumenGruposSociasAVencer.Enabled = False
            End If


            ''Reporte CC78:
            If Seg.HasPermission("ImprimirReporteCC78") Then
                Me.mnuReporteCC78.Enabled = True
            Else
                Me.mnuReporteCC78.Enabled = False
            End If


            ''Reporte CC79:
            If Seg.HasPermission("ImprimirReporteCC79") Then
                Me.mnuReporteCC79.Enabled = True
            Else
                Me.mnuReporteCC79.Enabled = False
            End If


            ''Reporte CC80:
            If Seg.HasPermission("ImprimirReporteCC80") Then
                Me.mnuReporteCC80.Enabled = True
            Else
                Me.mnuReporteCC80.Enabled = False
            End If


            'Reporte CC81
            If Seg.HasPermission("ImprimirReporteCC81") Then
                Me.mnuReporteCC81.Enabled = True
            Else
                Me.mnuReporteCC81.Enabled = False
            End If



            'Reporte CC84
            If Seg.HasPermission("ImprimirReporteSccCC84") Then
                Me.mnuReporteMoraPorBarrio.Enabled = True
            Else
                Me.mnuReporteMoraPorBarrio.Enabled = False
            End If

            'Reporte CC85
            If Seg.HasPermission("ImprimirReporteRepSccCC85") Then
                Me.MnuReporteCC85.Enabled = True
            Else
                Me.MnuReporteCC85.Enabled = False
            End If


            '*****Opción Registro de Solicitud de Cheque******
            If Seg.HasPermission("MantRegistrarNotasCD") Then
                Me.mnuRegistrarNotaDebitoCredito.Enabled = True
            Else
                Me.mnuRegistrarNotaDebitoCredito.Enabled = False
            End If

            If Seg.HasPermission("ImprimirCC25ArchivoExcel") Then
                Me.mnuCC25File.Enabled = True
            Else
                Me.mnuCC25File.Enabled = False
            End If



            ''***************************************************
            ''SEGURIDAD a las Opciones del Toolbar VERTICAL *****
            ''***************************************************

            '*********Grupo Recuperación Cartera
            'Recibo Oficial de Caja

            If Seg.HasPermission("MantRecibo") Then

                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Recibo").Appearance.Cursor = Cursors.Hand
                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Recibo").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Recibo").Appearance.Cursor = Cursors.Default
                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Recibo").Appearance.ForeColor = Color.DarkGray
            End If

            'Recibo Oficial de Caja Automático
            If Seg.HasPermission("MantReciboAutomatico") Then
                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("ReciboAutomatico").Appearance.Cursor = Cursors.Hand
                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("ReciboAutomatico").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("ReciboAutomatico").Appearance.Cursor = Cursors.Default
                Me.UlbControlCredito.Groups("RecuperacionCartera").Items("ReciboAutomatico").Appearance.ForeColor = Color.DarkGray
            End If

            'Cierre Diario de Caja
            'If Seg.HasPermission("MantCierre") Then
            '    Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Cierre").Appearance.Cursor = Cursors.Hand
            '    Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Cierre").Appearance.ForeColor = Color.Black
            'Else
            '    Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Cierre").Appearance.Cursor = Cursors.Default
            '    Me.UlbControlCredito.Groups("RecuperacionCartera").Items("Cierre").Appearance.ForeColor = Color.DarkGray
            'End If

            'Registrar Solicitud de Cheque
            If Seg.HasPermission("MantRegistrarSolCheque") Then
                Me.UlbControlCredito.Groups("SolicitudCheque").Items("Registrar").Appearance.Cursor = Cursors.Hand
                Me.UlbControlCredito.Groups("SolicitudCheque").Items("Registrar").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlCredito.Groups("SolicitudCheque").Items("Registrar").Appearance.Cursor = Cursors.Default
                Me.UlbControlCredito.Groups("SolicitudCheque").Items("Registrar").Appearance.ForeColor = Color.DarkGray
            End If

            'Reestructuración Deuda
            If Seg.HasPermission("MantReestructuracionDeuda") Then
                Me.UlbControlCredito.Groups("RegistroFicha").Items("ReestructuracionCredito").Appearance.Cursor = Cursors.Hand
                Me.UlbControlCredito.Groups("RegistroFicha").Items("ReestructuracionCredito").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlCredito.Groups("RegistroFicha").Items("ReestructuracionCredito").Appearance.Cursor = Cursors.Default
                Me.UlbControlCredito.Groups("RegistroFicha").Items("ReestructuracionCredito").Appearance.ForeColor = Color.DarkGray
            End If

            'Ficha de Notificación
            If Seg.HasPermission("MantFichaNotificacion") Then
                Me.UlbControlCredito.Groups("RegistroFicha").Items("FichaNotificacion").Appearance.Cursor = Cursors.Hand
                Me.UlbControlCredito.Groups("RegistroFicha").Items("FichaNotificacion").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlCredito.Groups("RegistroFicha").Items("FichaNotificacion").Appearance.Cursor = Cursors.Default
                Me.UlbControlCredito.Groups("RegistroFicha").Items("FichaNotificacion").Appearance.ForeColor = Color.DarkGray
            End If

            'Traslado Lugar de Pago
            If Seg.HasPermission("MantTrasladoLugarPago") Then
                Me.UlbControlCredito.Groups("RegistroFicha").Items("TrasladoLugarPago").Appearance.Cursor = Cursors.Hand
                Me.UlbControlCredito.Groups("RegistroFicha").Items("TrasladoLugarPago").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlCredito.Groups("RegistroFicha").Items("TrasladoLugarPago").Appearance.Cursor = Cursors.Default
                Me.UlbControlCredito.Groups("RegistroFicha").Items("TrasladoLugarPago").Appearance.ForeColor = Color.DarkGray
            End If


            '*****Opción Registro de Solicitud de Cheque******
            If Seg.HasPermission("ReimprimirRecibo") Then
                Me.mnuReimprimirRecibos.Visible = True

            Else
                Me.mnuReimprimirRecibos.Visible = False
            End If


            'Reporte CC85
            If Seg.HasPermission("ImprimirReporteRepSccCC88") Then
                Me.mnuReporteCC88.Enabled = True
            Else
                Me.mnuReporteCC88.Enabled = False
            End If

            'Reporte CC89
            If Seg.HasPermission("ImprimirReporteRepSccCC89") Then
                Me.mnuReporteCC89.Enabled = True
            Else
                Me.mnuReporteCC89.Enabled = False
            End If

            'Reporte CC90
            If Seg.HasPermission("ImprimirReporteRepSccCC90") Then
                Me.mnuReporteCC90.Enabled = True
            Else
                Me.mnuReporteCC90.Enabled = False
            End If

            'Reporte CC90
            If Seg.HasPermission("ImprimirReporteRepSccCC91") Then
                Me.mnuReporteCC91.Enabled = True
            Else
                Me.mnuReporteCC91.Enabled = False
            End If

            'Cierre Cartera
            If Seg.HasPermission("CierreCarteraMensual") Then
                Me.mnuCierreCarteraMensual.Enabled = True
            Else
                Me.mnuCierreCarteraMensual.Enabled = False
            End If

            'Informes Bancor Full
            If Seg.HasPermission("InformesBancorFull") Then
                Me.cmdBancorDetalleCartera.Visible = True
                Me.cmdBancorColocaciones.Visible = True
                Me.cmdBancorRubro.Visible = True
                Me.cmdBancorRubroDelegacion.Visible = True
                Me.cmdBancorPlazos.Visible = True
                Me.cmdBancorEstratos.Visible = True
                Me.cmdBancorFondos.Visible = True
                Me.cmdBancorCreditosClasificacion.Visible = True

                Me.CmdMenuBANCOR.Visible = True
            Else
                If Seg.HasPermission("InformesBancorLite") Then
                    Me.cmdBancorDetalleCartera.Visible = True
                    Me.CmdMenuBANCOR.Visible = True
                Else
                    Me.cmdBancorDetalleCartera.Visible = False
                    Me.CmdMenuBANCOR.Visible = False
                End If
                Me.cmdBancorColocaciones.Visible = False
                Me.cmdBancorRubro.Visible = False
                Me.cmdBancorRubroDelegacion.Visible = False
                Me.cmdBancorPlazos.Visible = False
                Me.cmdBancorEstratos.Visible = False
                Me.cmdBancorFondos.Visible = False
                Me.cmdBancorCreditosClasificacion.Visible = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuFichaNotificacion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFichaNotificacion.Click
        Try
            LlamarRegistroFNC()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamarRegistroFNC()
        Try

            Dim ObjFrmFNC As frmSclFichaNotificacionCredito
            ObjFrmFNC = New frmSclFichaNotificacionCredito

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmFNC.MdiParent = Me

            ObjFrmFNC.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmFNC, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmFNC.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub LlamaReciboOficialCaja(ByVal IdTipoRecibo As Integer)
        Dim ObjFrmSccReciboCaja As New frmSccReciboCaja
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try

            'Dim strSQL As String = ""


            'strSQL = " SELECT EstadoEnvio " & _
            '         " FROM SttProcesarParametroES " & _
            '         " WHERE nSteCajaID <> 0 "

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    If XdtDatos.ValueField("EstadoEnvio") = 1 Then
            '        MsgBox("Debe realizar primero la Importación de datos.", MsgBoxStyle.Critical, "SMUSURA0")
            '        Exit Sub
            '    End If
            'End If

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccReciboCaja.MdiParent = Me
            ObjFrmSccReciboCaja.IdTipoRecibo = IdTipoRecibo
            ObjFrmSccReciboCaja.WindowState = FormWindowState.Maximized
            'ObjFrmSccReciboCaja.Activate()
            'ObjFrmSccReciboCaja.ShowDialog()
            OpenForm(ObjFrmSccReciboCaja, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccReciboCaja.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    Private Sub LlamaReciboOficialCajaAdicional(ByVal IdTipoRecibo As Integer)
        Dim ObjFrmSccReciboCaja As New frmSccReciboCajaCancelado
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""


            strSQL = " SELECT EstadoEnvio " & _
                     " FROM SttProcesarParametroES " & _
                     " WHERE nSteCajaID <> 0 "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                If XdtDatos.ValueField("EstadoEnvio") = 1 Then
                    MsgBox("Debe realizar primero la Importación de datos.", MsgBoxStyle.Critical, "SMUSURA0")
                    Exit Sub
                End If
            End If

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccReciboCaja.MdiParent = Me
            ObjFrmSccReciboCaja.IdTipoRecibo = IdTipoRecibo
            ObjFrmSccReciboCaja.WindowState = FormWindowState.Maximized
            'ObjFrmSccReciboCaja.Activate()
            'ObjFrmSccReciboCaja.ShowDialog()
            OpenForm(ObjFrmSccReciboCaja, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccReciboCaja.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    Private Sub LlamaReciboOficialCajaAutomatico(ByVal IdTipoRecibo As Integer)
        Dim ObjFrmSccReciboCaja As New frmSccReciboCajaAutomatico
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            'Dim strSQL As String = ""


            'strSQL = " SELECT EstadoEnvio " & _
            '         " FROM SttProcesarParametroES " & _
            '         " WHERE nSteCajaID <> 0 "

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    If XdtDatos.ValueField("EstadoEnvio") = 1 Then
            '        MsgBox("Debe realizar primero la Importación de datos.", MsgBoxStyle.Critical, "SMUSURA0")
            '        Exit Sub
            '    End If
            'End If

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccReciboCaja.MdiParent = Me
            ObjFrmSccReciboCaja.IdTipoRecibo = IdTipoRecibo
            ObjFrmSccReciboCaja.WindowState = FormWindowState.Maximized
            'ObjFrmSccReciboCaja.Activate()
            'ObjFrmSccReciboCaja.ShowDialog()
            OpenForm(ObjFrmSccReciboCaja, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccReciboCaja.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    'Private Sub LlamaCierreDiarioCaja()
    '    Dim ObjFrmSccCierreCaja As New frmSccCierreCaja
    '    Try
    '        '-- Poner el cursor en un estado de ocupado
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        ObjFrmSccCierreCaja.MdiParent = Me

    '        ObjFrmSccCierreCaja.WindowState = FormWindowState.Maximized
    '        ObjFrmSccCierreCaja.sColorFrm = "Verde"
    '        'ObjFrmSccCierreCaja.ShowDialog()
    '        OpenForm(ObjFrmSccCierreCaja, Me)

    '        '-- Para enviar el foco al formulario 
    '        '-- que se está llamando.
    '        ObjFrmSccCierreCaja.BringToFront()

    '        '-- Poner el cursor en un estado de desocupado
    '        Me.Cursor = System.Windows.Forms.Cursors.Default

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjFrmSccCierreCaja = Nothing
    '    End Try
    'End Sub
    Private Sub mnuReciboOficialCaja_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReciboOficialCaja.Click
        LlamaReciboOficialCaja(2)
    End Sub


    'Private Sub mnuCierreDiarioCaja_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCierreDiarioCaja.Click
    '    LlamaCierreDiarioCaja()
    'End Sub
    Private Sub mnuRegistrarSolCheque_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRegistrarSolCheque.Click
        LlamaSolicitudCheque("ELA")
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
            ObjFrmSccSolicitudCheque.TipoCheque = 1
            ObjFrmSccSolicitudCheque.sColorFrm = "Verde"
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

    Private Sub mnuResumenCredito_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuResumenCredito.Click
        LlamaResumenCredito()
    End Sub
    Private Sub LlamaResumenCredito()
        Dim ObjFrmFNC As New frmSccParametroResumenCreditos
        Try

            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If
            ObjFrmFNC.NomRep = frmSccParametroResumenCreditos.EnumReportes.ResumenCreditos
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
        'Try

        '    Dim ObjFrmFNC As frmSccParametroResumenCreditos
        '    ObjFrmFNC = New frmSccParametroResumenCreditos

        '    '-- Poner el cursor en un estado de ocupado
        '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        '    ObjFrmFNC.ColorVentana = "Verde"
        '    ObjFrmFNC.MdiParent = Me

        '    'ObjFrmFNC.WindowState = FormWindowState.Maximized
        '    OpenForm(ObjFrmFNC, Me)

        '    '-- Para enviar el foco al formulario 
        '    '-- que se está llamando.
        '    ObjFrmFNC.BringToFront()

        '    '-- Poner el cursor en un estado de desocupado
        '    Me.Cursor = System.Windows.Forms.Cursors.Default

        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub mnuListadoRecibos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoRecibos.Click
        LlamaImprimirListadoRecibo()
    End Sub
    Private Sub LlamaImprimirListadoRecibo()
        Dim ObjFrmFNC As New FrmSccParametrosListadoRecibos
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuListadoCheques_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoCheques.Click
        Dim ObjFrmFNC As New FrmScnParametrosListadoCheques
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmFNC.NomRep = 1
            ObjFrmFNC.ShowDialog()

            'MsgBox("Cantidad de Formas " & My.Application.OpenForms.Count, MsgBoxStyle.Information)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuDetalleMercados_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDetalleMercados.Click
        Dim ObjFrmFNC As New FrmScnParametroListadoCreditosMercados
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmFNC.NomRep = 1
            ObjFrmFNC.sColorFrm = "Verde"
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuAvanceRecuperacionCartera_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAvanceRecuperacionCartera.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 1
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try

    End Sub

    Private Sub mnuGruposAprobados_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuGruposAprobados.Click
        Dim ObjFrmFNC As New frmSccParametroResumenCreditos
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            'frmSccParametroResumenCreditos.NomRep = 1
            ObjFrmFNC.NomRep = frmSccParametroResumenCreditos.EnumReportes.Detalle
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.ShowDialog()

            ''-- Poner el cursor en un estado de ocupado
            'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ''ObjFrmFNC.MdiParent = Me

            ''ObjFrmFNC.WindowState = FormWindowState.Maximized
            'OpenForm(ObjFrmFNC, Me)

            ''-- Para enviar el foco al formulario 
            ''-- que se está llamando.
            'ObjFrmFNC.BringToFront()

            ''-- Poner el cursor en un estado de desocupado
            'Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuTrasladoLugarPago_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTrasladoLugarPago.Click
        LlamaTrasladoLugarPago()
    End Sub
    Private Sub LlamaTrasladoLugarPago()

        Dim ObjFrmSclTrasladoLugarDePagos As New frmSclTrasladosLugarDePagos
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclTrasladoLugarDePagos.MdiParent = Me

            ObjFrmSclTrasladoLugarDePagos.WindowState = FormWindowState.Maximized
            ''ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            'ObjFrmSccSolicitudCheque.ModoAccion = StrAccion
            'ObjFrmSccSolicitudCheque.sColorFrm = "Verde"
            OpenForm(ObjFrmSclTrasladoLugarDePagos, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclTrasladoLugarDePagos.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclTrasladoLugarDePagos = Nothing
        End Try
    End Sub

    Private Sub mnuExportarRecibos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportarRecibos.Click
        LlamaExportar()
    End Sub
    Private Sub LlamaExportar()
        Dim ObjFrmSccDescarga As New FrmSccDescarga
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            'Dim ObjFrmSteConciliacionBancaria As frmSteConciliacionBancaria
            'ObjFrmSteConciliacionBancaria = New frmSteConciliacionBancaria

            '-- Poner el cursor en un estado de ocupado
            'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'ObjFrmSccDescarga.MdiParent = Me

            'ObjFrmSccDescarga.WindowState = FormWindowState.Maximized
            ObjFrmSccDescarga.ColorVentana = "Verde"
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

    Private Sub mnuReporteRecuperaciones_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteRecuperaciones.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 2
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuPrestamosVencidos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrestamosVencidos.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 3
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuConsolidadoPrestamosVencidos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConsolidadoPrestamosVencidos.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 4
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReestructuracionDeuda_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReestructuracionDeuda.Click
        LlamaReestructurarDeuda()
    End Sub
    Private Sub LlamaReestructurarDeuda()

        Dim ObjFrmSccReestructuracionDeuda As New frmSccReestructuracionDeuda
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccReestructuracionDeuda.MdiParent = Me

            ObjFrmSccReestructuracionDeuda.WindowState = FormWindowState.Maximized
            ''ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            'ObjFrmSccSolicitudCheque.ModoAccion = StrAccion
            'ObjFrmSccSolicitudCheque.sColorFrm = "Verde"
            OpenForm(ObjFrmSccReestructuracionDeuda, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccReestructuracionDeuda.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccReestructuracionDeuda = Nothing
        End Try
    End Sub

    Private Sub mnuReciboAutomatico_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReciboAutomatico.Click
        LlamaReciboOficialCajaAutomatico(1)
    End Sub
    Private Sub LlamaImportar()
        Dim ObjFrmSccCarga As New FrmSccCarga
        Try
            If My.Application.OpenForms.Count > 2 Then
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

    Private Sub mnuImportarInformacion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuImportarInformacion.Click
        LlamaImportar()
    End Sub

    Private Sub mnuMetasPrograma_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMetasPrograma.Click
        LlamaMetasPrograma()
    End Sub
    Private Sub LlamaMetasPrograma()

        Dim ObjFrmSccMetasPrograma As New frmSccMetasPrograma
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccMetasPrograma.MdiParent = Me

            ObjFrmSccMetasPrograma.WindowState = FormWindowState.Maximized
            ''ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            'ObjFrmSccSolicitudCheque.ModoAccion = StrAccion
            ObjFrmSccMetasPrograma.strColor = "Verde"
            OpenForm(ObjFrmSccMetasPrograma, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccMetasPrograma.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccMetasPrograma = Nothing
        End Try
    End Sub

    Private Sub mnuSociasCreditos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSociasCreditos.Click
        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 1
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuFormatoCaptura_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFormatoCaptura.Click
        'Dim ObjFrmFNC As New frmSccParametroResumenCreditos
        'Try

        '    If My.Application.OpenForms.Count > 2 Then
        '        Exit Sub
        '    End If
        '    ObjFrmFNC.NomRep = 4
        '    ObjFrmFNC.ColorVentana = "Verde"
        '    ObjFrmFNC.ShowDialog()

        'Catch ex As Exception
        '    Control_Error(ex)
        'Finally
        '    ObjFrmFNC.Close()
        '    ObjFrmFNC = Nothing
        'End Try
        LlamaParametroResumenCreditos(4)
    End Sub
    Private Sub LlamaParametroResumenCreditos(ByVal nNumReporte As Integer)
        Dim ObjFrmFNC As New frmSccParametroResumenCreditos
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmFNC.NomRep = nNumReporte
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub
    Private Sub LlamaImprimirListadosIndicadores(ByVal IDReporte As Integer)
        Dim ObjFrmSccParametroRpt As New frmSccParametrosIndicadores
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametroRpt.NomRep = IDReporte
            ObjFrmSccParametroRpt.ColorVentana = "Verde"
            ObjFrmSccParametroRpt.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametroRpt.Close()
            ObjFrmSccParametroRpt = Nothing
        End Try
    End Sub

    Private Sub mnuTabla3_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTabla3.Click
        LlamaImprimirListadosIndicadores(2)
    End Sub

    Private Sub mnuControlMora_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuControlMora.Click
        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 2
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuTabla2_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTabla2.Click
        LlamaImprimirListadosIndicadores(1)
    End Sub

    Private Sub mnuSociasAprobadas_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSociasAprobadas.Click
        Dim ObjFrmSclParametrosListadoSocias As New frmSclParametrosListadoSocias
        Try
            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclParametrosListadoSocias.NomRep = 4
            ObjFrmSclParametrosListadoSocias.strColor = "Verde"
            ObjFrmSclParametrosListadoSocias.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametrosListadoSocias.Close()
            ObjFrmSclParametrosListadoSocias = Nothing
        End Try
    End Sub

    Private Sub mnuTabla5_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTabla5.Click
        LlamaImprimirListadosIndicadores(3)
    End Sub

    Private Sub mnuTabla6_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTabla6.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 5
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuTabla7_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTabla7.Click
        LlamaImprimirListadosIndicadores(4)
    End Sub

    Private Sub mnuTabla1_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTabla1.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 6
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuPrestamosCancelados_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrestamosCancelados.Click
        'LlamaReciboOficialCaja(3)
        LlamaReciboOficialCajaAdicional(3)
    End Sub

    Private Sub mnuListadoSociasMorosas_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoSociasMorosas.Click
        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 3
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuMapaMunicipiosAtendidos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMapaMunicipiosAtendidos.Click
        Dim cnString As New DSSistema.DSSistema
        Dim frmMapaMunicipios As New FormMaps.FrmMapaMunicipios

        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            frmMapaMunicipios.ConexionDB = cnString.DbConnectionString
            frmMapaMunicipios.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmMapaMunicipios.Close()
            frmMapaMunicipios = Nothing

            cnString.Close()
            cnString = Nothing
        End Try
    End Sub

    Private Sub mnuMapaDeptoAtendidos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMapaDeptoAtendidos.Click
        Dim cnString As New DSSistema.DSSistema
        Dim frmMapaDepartamentos As New FormMaps.FrmMapaDepartamentos
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            frmMapaDepartamentos.ConexionDB = cnString.DbConnectionString
            frmMapaDepartamentos.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmMapaDepartamentos.Dispose()
            frmMapaDepartamentos = Nothing

            cnString.Close()
            cnString = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC43_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC43.Click
        LlamaParametroResumenCreditos(5)
    End Sub

    Private Sub mnuReporteCC46_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC46.Click
        LlamaParametroResumenCreditos(6)
    End Sub

    Private Sub mnuReporteCC47_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC47.Click
        LlamaParametroResumenCreditos(7)
    End Sub

    Private Sub mnuReporteCC48_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC48.Click
        LlamaImprimirReporteCasosEspeciales(5)
    End Sub
    Private Sub LlamaImprimirReporteCasosEspeciales(ByVal IDReportes As Integer)
        Dim ObjFrmScnParametroMinuta As New frmScnParametrosMinutas
        'Valores de IdReportes 
        'SociasVariasFuentes = 5 CC48
        'SociasVariosMunicipios = 6 CC49
        'SociasBarriosYMercados = 7 CC50
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmScnParametroMinuta.NomRep = IDReportes
            ObjFrmScnParametroMinuta.ColorVentana = "Verde"
            ObjFrmScnParametroMinuta.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnParametroMinuta.Close()
            ObjFrmScnParametroMinuta = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC49_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC49.Click
        LlamaImprimirReporteCasosEspeciales(6)
    End Sub

    Private Sub mnuReporteCC50_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC50.Click
        LlamaImprimirReporteCasosEspeciales(7)
    End Sub

    Private Sub mnuReporteCC51_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC51.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 7
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuEstadisticasINIDE_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEstadisticasINIDE.Click
        LlamaEstadisticasINIDE()
    End Sub
    Private Sub LlamaEstadisticasINIDE()

        Dim ObjFrmSccEstadisticasINIDE As New frmSccEstadisticasINIDE
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccEstadisticasINIDE.MdiParent = Me

            ObjFrmSccEstadisticasINIDE.WindowState = FormWindowState.Maximized
            ''ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            'ObjFrmSccSolicitudCheque.ModoAccion = StrAccion
            ObjFrmSccEstadisticasINIDE.sColorFrm = "Verde"
            OpenForm(ObjFrmSccEstadisticasINIDE, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccEstadisticasINIDE.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEstadisticasINIDE = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC54_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC54.Click
        LlamaImprimirListadosIndicadores(5)
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

    Private Sub mnuReporteCC56_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC56.Click
        LlamaAvanceCartera(8)
    End Sub
    Private Sub LlamaAvanceCartera(ByVal IDReportes As Integer)
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = IDReportes
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC58_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC58.Click
        LlamaAvanceCartera(9)

    End Sub

    Private Sub mnuReporteCC59_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC59.Click
        LlamaAvanceCartera(10)
    End Sub

    Private Sub mnuReporteCC60_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC60.Click
        LlamaAvanceCartera(11)
    End Sub

    Private Sub mnuReporteCC61_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC61.Click
        LlamaAvanceCartera(12)
    End Sub

    Private Sub mnuCancelacionManual_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCancelacionManual.Click
        LlamaCancelacionManual(2)
    End Sub
    Private Sub LlamaCancelacionManual(ByVal IdTipoRecibo As Integer)
        Dim ObjFrmSccCancelacionAnticipadaManual As New frmSccCancelacionAnticipadaManual
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            'Dim strSQL As String = ""


            'strSQL = " SELECT EstadoEnvio " & _
            '         " FROM SttProcesarParametroES " & _
            '         " WHERE nSteCajaID <> 0 "

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    If XdtDatos.ValueField("EstadoEnvio") = 1 Then
            '        MsgBox("Debe realizar primero la Importación de datos.", MsgBoxStyle.Critical, "SMUSURA0")
            '        Exit Sub
            '    End If
            'End If

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccCancelacionAnticipadaManual.MdiParent = Me
            ObjFrmSccCancelacionAnticipadaManual.IdTipoRecibo = IdTipoRecibo
            ObjFrmSccCancelacionAnticipadaManual.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSccCancelacionAnticipadaManual, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccCancelacionAnticipadaManual.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccCancelacionAnticipadaManual = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub

    Private Sub mnuCancelacionAutomatica_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCancelacionAutomatica.Click
        LlamaCancelacionAutomatica(1)
    End Sub
    Private Sub LlamaCancelacionAutomatica(ByVal IdTipoRecibo As Integer)
        Dim ObjFrmSccCancelacionAnticipadaAutomatica As New frmSccCancelacionAnticipadaAutomatica
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""


            'strSQL = " SELECT EstadoEnvio " & _
            '         " FROM SttProcesarParametroES " & _
            '         " WHERE nSteCajaID <> 0 "

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    If XdtDatos.ValueField("EstadoEnvio") = 1 Then
            '        MsgBox("Debe realizar primero la Importación de datos.", MsgBoxStyle.Critical, "SMUSURA0")
            '        Exit Sub
            '    End If
            'End If

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccCancelacionAnticipadaAutomatica.MdiParent = Me
            ObjFrmSccCancelacionAnticipadaAutomatica.IdTipoRecibo = IdTipoRecibo
            ObjFrmSccCancelacionAnticipadaAutomatica.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSccCancelacionAnticipadaAutomatica, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccCancelacionAnticipadaAutomatica.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccCancelacionAnticipadaAutomatica = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC63_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC63.Click
        LlamaListadoSocias(6)
    End Sub
    Private Sub LlamaListadoSocias(ByVal intReporte As Integer)
        Dim ObjFrmSclParametrosListadoSocias As New frmSclParametrosListadoSocias
        Try
            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclParametrosListadoSocias.NomRep = intReporte
            ObjFrmSclParametrosListadoSocias.strColor = "Verde"
            ObjFrmSclParametrosListadoSocias.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametrosListadoSocias.Close()
            ObjFrmSclParametrosListadoSocias = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC64_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC64.Click
        LlamaImprimirListadoTesoreria(7)
    End Sub
    Private Sub LlamaImprimirListadoTesoreria(ByVal IDReporte As Integer)
        Dim ObjFrmScnParametroRpt As New frmSteParametrosTesoreria
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmScnParametroRpt.NomRep = IDReporte
            ObjFrmScnParametroRpt.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnParametroRpt.Close()
            ObjFrmScnParametroRpt = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC65_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC65.Click
        LlamaAvanceCartera(13)
    End Sub

    Private Sub mnuReporteCC66_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC66.Click
        LlamaAvanceCartera(14)
    End Sub

    Private Sub mnuReporteCC68_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC68.Click
        LlamaAvanceCartera(15)
    End Sub

    Private Sub mnuReporteCC69_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC69.Click
        LlamaAvanceCartera(16)
    End Sub

    Private Sub mnuReporteCC70_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC70.Click
        LlamaImprimirListadoTesoreria(8)
    End Sub

    Private Sub mnuArregloPago_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuArregloPago.Click
        Dim ObjFrmSccArregloPago As New frmSccArregloPago
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccArregloPago.MdiParent = Me

            ObjFrmSccArregloPago.WindowState = FormWindowState.Maximized
            ''ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            'ObjFrmSccSolicitudCheque.ModoAccion = StrAccion
            OpenForm(ObjFrmSccArregloPago, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccArregloPago.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccArregloPago = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCN38_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCN38.Click
        Dim ObjFrmListadoCheques As New FrmScnParametrosListadoCheques
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmListadoCheques.NomRep = 3
            ObjFrmListadoCheques.ShowDialog()

            'MsgBox("Cantidad de Formas " & My.Application.OpenForms.Count, MsgBoxStyle.Information)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmListadoCheques.Close()
            ObjFrmListadoCheques = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC71_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC71.Click
        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 4
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub


    Private Sub mnuReporteCC72_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC72.Click
        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 5
            ObjFrmSccParametrosCreditosSocia.Label1.Text = "Créditos"
            ObjFrmSccParametrosCreditosSocia.Label2.Text = "Cancelados"

            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuRegistrarNotaDebitoCredito_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRegistrarNotaDebitoCredito.Click
        LlamaNota()
    End Sub

    Private Sub LlamaNota()

        Dim ObjFrmSccNotaDebitoCredito As New FrmSccNotaDebitoCredito
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSccNotaDebitoCredito.MdiParent = Me

            ObjFrmSccNotaDebitoCredito.WindowState = FormWindowState.Maximized
            'ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            'ObjFrmSccNotaDebitoCredito.ModoAccion = StrAccion
            ObjFrmSccNotaDebitoCredito.sColorFrm = "Verde"
            OpenForm(ObjFrmSccNotaDebitoCredito, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSccNotaDebitoCredito.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccNotaDebitoCredito = Nothing
        End Try
    End Sub

    Private Sub cmdRepManual_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles cmdRepManual.Click

        'REPORTE PARA SUPERVISION DE PROCESO DE DIGITACION MANUAL

        Dim ObjFrmFNC As New FrmSccReporteRecibosManual
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 3
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try



    End Sub

    Private Sub mnuRecibosFechaIngreso_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRecibosFechaIngreso.Click
        'FrmSccParametrosListadoRecibos.NomRep = FrmSccParametrosListadoRecibos.EnumReportes.ListadoRecibosFechaIngreso
        'FrmSccParametrosListadoRecibos.GrpListadoPor.Enabled = False
        'FrmSccParametrosListadoRecibos.cboUsuario.Enabled = False
        'FrmSccParametrosListadoRecibos.ShowDialog()

        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = FrmSccParametrosCreditosSocia.EnumReportes.ListadoDeRecibosPorTipoFecha
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuResumenGruposSociasAVencer_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuResumenGruposSociasAVencer.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 17
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC78_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC78.Click
        Dim objFrmFNC As New frmSccParametroFichasPorSesion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            objFrmFNC.strColor = "Verde"
            objFrmFNC.NomRep = 1
            objFrmFNC.grpFechaCondicion.Enabled = False
            objFrmFNC.grpFuente.Enabled = False
            objFrmFNC.grpFondooFuente.Enabled = False
            objFrmFNC.grpPrograma.Enabled = False
            objFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            objFrmFNC.Close()
            objFrmFNC = Nothing
        End Try

    End Sub

    Private Sub mnuReporteCC79_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC79.Click
        Dim ObjFrmFNC As New frmSccParametroFichasPorSesion
        Try

            ObjFrmFNC.strColor = "Verde"
            ObjFrmFNC.NomRep = 2
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try

    End Sub

    Private Sub mnuReporteCC80_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC80.Click
        Dim objFrmFNC As New frmSccParametroFichasPorSesion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            objFrmFNC.strColor = "Verde"
            objFrmFNC.NomRep = 3
            objFrmFNC.grpFechaCondicion.Enabled = False
            objFrmFNC.grpFecha.Text = "Fecha Resolución:"
            objFrmFNC.grpFuente.Enabled = False
            objFrmFNC.grpFondooFuente.Enabled = False
            objFrmFNC.grpPrograma.Enabled = False
            objFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            objFrmFNC.Close()
            objFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC81_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC81.Click
        Dim ObjFrmFNC As New frmSccParametroFichasPorSesion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.strColor = "Verde"
            ObjFrmFNC.NomRep = 4
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReporteMoraPorBarrio_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteMoraPorBarrio.Click
        Dim ObjFrmFNC As New FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = 18
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuComportamientoMora_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuComportamientoMora.Click

    End Sub

    Private Sub MnuReporteCC85_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuReporteCC85.Click
        Dim ObjFrmFNC As New frmSccParametroResumenCreditos
        Try

            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.NomRep = frmSccParametroResumenCreditos.EnumReportes.ComportamientoDeMora
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReimprimirRecibos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReimprimirRecibos.Click
        Dim ObjFrmRIR As New frmSccRempresionReciboOficialAutomatico
        Try

            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If

            ObjFrmRIR.MdiParent = Me

            ObjFrmRIR.WindowState = FormWindowState.Maximized

            OpenForm(ObjFrmRIR, Me)

            ObjFrmRIR.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmRIR = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC88_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC88.Click
        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = FrmSccParametrosCreditosSocia.EnumReportes.ListaSociasMonto
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCC89_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC89.Click
        LlamaSaldoSaneamiento(1)
    End Sub
    Private Sub LlamaSaldoSaneamiento(ByVal IDReportes As Integer)
        Dim ObjFrmFNC As New FrmSccParametrosSaldoSaneamiento ' FrmSccParametrosAvanceCartera
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmFNC.ColorVentana = "Verde"
            ObjFrmFNC.NomRep = IDReportes
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub


    Private Sub mnuReporteCC90_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC90.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociasDenegadasUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 2
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try

        'Dim ObjFrmSccParametrosCreditosSocia As New frmSccParametrosClasificacionCarteraSIBOIF

        'Try
        '    If My.Application.OpenForms.Count > 2 Then
        '        Exit Sub
        '    End If

        '    ObjFrmSccParametrosCreditosSocia.NomRep = 1
        '    ObjFrmSccParametrosCreditosSocia.ColorVentana = "Verde"
        '    ObjFrmSccParametrosCreditosSocia.ShowDialog()

        'Catch ex As Exception
        '    Control_Error(ex)
        'Finally
        '    ObjFrmSccParametrosCreditosSocia.Close()
        '    ObjFrmSccParametrosCreditosSocia = Nothing
        'End Try
    End Sub

    Private Sub mnuReporteCC91_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC91.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociasDenegadasUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 3
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuCierreCarteraMensual_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuCierreCarteraMensual.Click
        Try

            Dim ObjFrmFNC As New frmSccCierreCredito

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = Cursors.WaitCursor
            ObjFrmFNC.MdiParent = Me

            ObjFrmFNC.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmFNC, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmFNC.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuCC25File_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuCC25File.Click
        Dim ObjFrmSccParametrosCreditosSocia As New FrmSccParametrosCreditosSocia
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 8
            ObjFrmSccParametrosCreditosSocia.strColor = "Verde"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub cmdBancorFondos_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorFondos.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 4
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorDetalleCartera_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorDetalleCartera.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 1
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorRubro_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorRubro.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 2
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorRubroDelegacion_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorRubroDelegacion.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 3
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorEstratos_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorEstratos.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 6
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorPlazos_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorPlazos.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 7
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorColocaciones_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorColocaciones.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 5
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorCreditosClasificacion_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorCreditosClasificacion.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 8
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorActividadDetalleCartera_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorActividadDetalleCartera.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 9
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdBancorConsolidadoCreditosActividadClasificacion_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdBancorConsolidadoCreditosActividadClasificacion.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 10
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdCartera_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdCartera.Click
        Dim Obj As New frmSccInformesBancor

        Try
            Obj.intReporte = 11
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub

    Private Sub cmdCC89_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmdCC89.Click
        Dim Obj As New frmSccParametrosReporteCierres

        Try
            Obj.intReporte = 1
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try

    End Sub

    Private Sub cmd89_2_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles cmd89_2.Click
        Dim Obj As New frmSccParametrosReporteCierres

        Try
            Obj.intReporte = 2
            Obj.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Obj.Close()
            Obj = Nothing
        End Try
    End Sub
End Class
