
Imports System.Windows.Forms
Imports Microsoft.Win32
Public Class FrmMDITesoreria

    'Private Sub FrmMDIContabilidad_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    Try
    '        Me.Text = "SMUSURA0 - Módulo de Contabilidad"
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    Private Sub FrmMDITesoreria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            ObjGUI = New GUI.ClsGUI

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            Me.Text = "SMUSURA0 - Módulo de Tesorería"
            InicializaBarraEstado()
            Seguridad()

            '---------------------------------------------------------
            'Seleccionar el primer grupo de la toolbar vertical
            Me.UlbTesoreria.Groups(0).Selected = True

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

    Private Sub UlbTesoreria_ItemSelected(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListBar.ItemEventArgs) Handles UlbTesoreria.ItemSelected
        Try
            Select Case e.Item.Key

                Case "Cajas"
                    If Seg.HasPermission("MantCaja") Then
                        LlamaRegistroCajas()
                    End If
                Case "Denominaciones"
                    If Seg.HasPermission("MantDenominaciones") Then
                        LlamaRegistroDenominaciones()
                    End If
                Case "ConciliacionBancaria"
                    If Seg.HasPermission("MantConciliacionBancaria") Then
                        LlamaConciliacion()
                    End If
                Case "ArqueoCaja"
                    If Seg.HasPermission("MantArqueo") Then
                        LlamaArqueoCaja()
                    End If
                Case "MinutasDeposito"
                    If Seg.HasPermission("MantMinutaDeposito") Then
                        LlamaRegistroMinutas()
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

            'Opción Caja
            If Seg.HasPermission("MantCaja") Then
                Me.mnuCaja.Enabled = True
            Else
                Me.mnuCaja.Enabled = False
            End If

            'Opción Cajero
            If Seg.HasPermission("MantCajero") Then
                Me.mnuCajero.Enabled = True
            Else
                Me.mnuCajero.Enabled = False
            End If

            'Opción Arqueo
            If Seg.HasPermission("MantArqueo") Then
                Me.mnuArqueoCaja.Enabled = True
            Else
                Me.mnuArqueoCaja.Enabled = False
            End If

            'Opción Pagare
            If Seg.HasPermission("MantPagare") Then
                Me.mnuPagare.Enabled = True
            Else
                Me.mnuPagare.Enabled = False
            End If

            'Opción Pagaré
            If Seg.HasPermission("MantPagare") Then
                Me.mnuPagare.Enabled = True
            Else
                Me.mnuPagare.Enabled = False
            End If

            'Opción Recibos Anulados
            If Seg.HasPermission("MantRecibosAnulados") Then
                Me.mnuReciboAnulado.Enabled = True
            Else
                Me.mnuReciboAnulado.Enabled = False
            End If

            'Opción Recibos Entregados Delegaciones
            If Seg.HasPermission("MantEntregaDeRecibosDpto") Then
                Me.mnuEntregaTalonariosDelegaciones.Enabled = True
            Else
                Me.mnuEntregaTalonariosDelegaciones.Enabled = False
            End If

            'Opción Recibos Entregados
            If Seg.HasPermission("MantEntregaDeRecibos") Then
                Me.mnuEntregaTalonario.Enabled = True
            Else
                Me.mnuEntregaTalonario.Enabled = False
            End If


            'Opción Recibos Extraviados
            If Seg.HasPermission("MantRegistroDeReciboExtraviado") Then
                Me.mnuRecibosExtraviados.Enabled = True
            Else
                Me.mnuRecibosExtraviados.Enabled = False
            End If

            'Opción Conciliación Bancaria
            If Seg.HasPermission("MantConciliacionBancaria") Then
                Me.mnuConciliacionBancaria.Enabled = True
            Else
                Me.mnuConciliacionBancaria.Enabled = False
            End If

            'Opción Conciliación Banca en Línea
            If Seg.HasPermission("MantMinutasBancoEnLinea") Then
                Me.mnuConciliacionesBancaLinea.Enabled = True
            Else
                Me.mnuConciliacionesBancaLinea.Enabled = False
            End If


            'Agregado para el control de pago a proveedor

            'Opción Impresión Cheques
            If Seg.HasPermission("MantAgregarChequeProveedor") Then
                Me.mnuAgregarRegistroDesembolsoProveedores.Enabled = True
            Else
                Me.mnuAgregarRegistroDesembolsoProveedores.Enabled = False
            End If


            'Opción Impresión Cheques
            If Seg.HasPermission("MantControlChequeraProveedor") Then
                Me.mnuControlChequeraProveedor.Enabled = True
            Else
                Me.mnuControlChequeraProveedor.Enabled = False
            End If


            'Fin Agregado para el control de pago a proveedor
            'Opción Impresión Cheques
            If Seg.HasPermission("MantImpresionCheques") Then
                Me.mnuImpresionCheque.Enabled = True
            Else
                Me.mnuImpresionCheque.Enabled = False
            End If


            'Opción Impresión Cheques Personalizados
            If Seg.HasPermission("MantImpresionChequesPersonalizado") Then
                Me.mnuImpresionChequePersonzalizado.Enabled = True
            Else
                Me.mnuImpresionChequePersonzalizado.Enabled = False
            End If


            'Opción Cheques Anulados
            If Seg.HasPermission("MantChequeAnulado ") Then
                Me.mnuChequesAnulados.Enabled = True
            Else
                Me.mnuChequesAnulados.Enabled = False
            End If

            'Opción Imprimir Listado de Recibos TE12
            If Seg.HasPermission("ImprimirListadoRecibo") Then
                Me.mnuListadoRecibos.Enabled = True
            Else
                Me.mnuListadoRecibos.Enabled = False
            End If

            'Opción Imprimir Listado de Recibos Sin Monto TE15
            If Seg.HasPermission("ImprimirListadoReciboSinMontos") Then
                Me.mnuListadoRecibosSinMonto.Enabled = True
            Else
                Me.mnuListadoRecibosSinMonto.Enabled = False
            End If

            'Opción Denominaciones
            If Seg.HasPermission("MantDenominaciones") Then
                Me.mnuDenominaciones.Enabled = True
            Else
                Me.mnuDenominaciones.Enabled = False
            End If

            'Opción Minuta de Depósito
            If Seg.HasPermission("MantMinutaDeposito") Then
                Me.mnuMinutaDeposito.Enabled = True
            Else
                Me.mnuMinutaDeposito.Enabled = False
            End If

            'Opción Exportar Información Central
            If Seg.HasPermission("MantExportarInformacionCentral") Then
                Me.mnuExportarInformacion.Enabled = True
            Else
                Me.mnuExportarInformacion.Enabled = False
            End If

            'Opción Importar Recibos Central
            If Seg.HasPermission("MantImportarRecibosCentral") Then
                Me.mnuImportarRecibos.Enabled = True
            Else
                Me.mnuImportarRecibos.Enabled = False
            End If



            'Opción Imprimir Consulta de Recibos Arqueados TE16
            If Seg.HasPermission("ImprimirReciboArqueo") Then
                Me.mnuConsultaReciboArqueo.Enabled = True
            Else
                Me.mnuConsultaReciboArqueo.Enabled = False
            End If

            'Opción Imprimir Listado de Minutas por Fecha de Depósito TE17
            If Seg.HasPermission("ImprimirListadoMinutasFechaDeposito") Then
                Me.mnuListadoMinutaFechaDeposito.Enabled = True
            Else
                Me.mnuListadoMinutaFechaDeposito.Enabled = False
            End If

            'Opción Imprimir Listado de Consecutivo de Recibos según Arqueo TE18
            If Seg.HasPermission("ImprimirConsecutivoRecibos") Then
                Me.mnuConsecutivoRecibos.Enabled = True
            Else
                Me.mnuConsecutivoRecibos.Enabled = False
            End If

            'Opción Imprimir Listado de Consecutivo de Recibos según Crédito TE19
            If Seg.HasPermission("ImprimirConsecutivoRecibosOficiales") Then
                Me.mnuConsecutivoRecibosCredito.Enabled = True
            Else
                Me.mnuConsecutivoRecibosCredito.Enabled = False
            End If

            'Opción Imprimir Listado de Entrega de Recibos TE22
            If Seg.HasPermission("ImprimirRecibosEntregadosNoArqueados") Then
                Me.mnuListadoEntregaRecibos.Enabled = True
            Else
                Me.mnuListadoEntregaRecibos.Enabled = False
            End If

            'Opción Imprimir Consulta Talonario de Recibos TE23
            If Seg.HasPermission("ImprimirTalonariosDeRecibosEntregados") Then
                Me.mnuConsultaTalonarios.Enabled = True
            Else
                Me.mnuConsultaTalonarios.Enabled = False
            End If

            'Opción Imprimir Consolidado Minuta TE24
            If Seg.HasPermission("ImprimirListadoConsolidadoMinutasTE24") Then
                Me.mnuConsolidadoMinutaTE24.Enabled = True
            Else
                Me.mnuConsolidadoMinutaTE24.Enabled = False
            End If

            'Opción Imprimir LISTADO DE RECIBOS ARQUEADOS AUN NO INGRESADOS EN CREDITO TE278
            If Seg.HasPermission("ImprimirRecibosArqueadosNoIngresadosTE27") Then
                Me.mnuReporteTE27.Enabled = True
            Else
                Me.mnuReporteTE27.Enabled = False
            End If

            'Opción Corte Traslado de Valores
            If Seg.HasPermission("MantCierreTrasladoValor") Then
                Me.mnuCorteTrasladoValores.Enabled = True
            Else
                Me.mnuCorteTrasladoValores.Enabled = False
            End If

            'Opción Cierre Diario Caja Automática
            If Seg.HasPermission("MantCierreDiarioCaja") Then
                Me.mnuCierreCajaTesoreria.Enabled = True
            Else
                Me.mnuCierreCajaTesoreria.Enabled = False
            End If

            'Opción Reporte TE30
            If Seg.HasPermission("ImprimirRecibosAnuladosTE30") Then
                Me.mnuReporteTE30.Enabled = True
            Else
                Me.mnuReporteTE30.Enabled = False
            End If

            'Opción Reporte TE31
            If Seg.HasPermission("ImprimirListadoRecibosCajeroTE31") Then
                Me.mnuReporteTE31.Enabled = True
            Else
                Me.mnuReporteTE31.Enabled = False
            End If

            'Opción Reporte TE33
            If Seg.HasPermission("ImprimirConsecutivoRecibosRangoTE33") Then
                Me.mnuReporteTE33.Enabled = True
            Else
                Me.mnuReporteTE33.Enabled = False
            End If

            'Imprimir Reporte CC44
            If Seg.HasPermission("ImprimirReporteCC44") Then
                Me.mnuReporteCC44.Enabled = True
            Else
                Me.mnuReporteCC44.Enabled = False
            End If

            'Imprimir Reporte CC45
            If Seg.HasPermission("ImprimirReporteCC45") Then
                Me.mnuReporteCC45.Enabled = True
            Else
                Me.mnuReporteCC45.Enabled = False
            End If

            'Imprimir Reporte TE34
            If Seg.HasPermission("ImprimirRecibosFaltantesRangoTE34") Then
                Me.mnuReporteTE34.Enabled = True
            Else
                Me.mnuReporteTE34.Enabled = False
            End If

            'Imprimir Reporte TE36
            If Seg.HasPermission("ImprimirConsecutivoRecibosRangoEnTesoreriaTE36") Then
                Me.mnuReporteTE36.Enabled = True
            Else
                Me.mnuReporteTE36.Enabled = False
            End If

            'Imprimir Reporte TE37
            If Seg.HasPermission("ImprimirRecibosFaltantesRangoEnTesoreriaTE37") Then
                Me.mnuReporteTE37.Enabled = True
            Else
                Me.mnuReporteTE37.Enabled = False
            End If

            'Imprimir Reporte TE39
            If Seg.HasPermission("ImprimirReporteTE39") Then
                Me.mnuPagareCajero.Enabled = True
            Else
                Me.mnuPagareCajero.Enabled = False
            End If

            'Imprimir Reporte TE40
            If Seg.HasPermission("ImprimirReporteTE40") Then
                Me.mnuReporteTE40.Enabled = True
            Else
                Me.mnuReporteTE40.Enabled = False
            End If

            'Imprimir Reporte TE41
            If Seg.HasPermission("ImprimirReporteTE41") Then
                Me.mnuReporteTE41.Enabled = True
            Else
                Me.mnuReporteTE41.Enabled = False
            End If

            'Imprimir Reporte TE42
            If Seg.HasPermission("ImprimirReporteTE42") Then
                Me.mnuReporteTE42.Enabled = True
            Else
                Me.mnuReporteTE42.Enabled = False
            End If

            'Imprimir Reporte TE44 
            If Seg.HasPermission("ImprimirReporteTE44") Then
                Me.mnuReporteTE44.Enabled = True
            Else
                Me.mnuReporteTE44.Enabled = False
            End If

            If Seg.HasPermission("ImprimirReporteTE48") Then
                cmdReporteTE48.Enabled = True
            Else
                cmdReporteTE48.Enabled = False
            End If



            If Seg.HasPermission("ImprimirReporteCC86") Then
                MnuReporteCC86.Enabled = True
            Else
                MnuReporteCC86.Enabled = False
            End If




            If Seg.HasPermission("ImprimirReporteCS44") Then
                CS44.Enabled = True

            Else
                CS44.Enabled = False
            End If

            If Seg.HasPermission("ImprimirReporteCS45") Then
                MnuReporteCS45.Enabled = True

            Else
                MnuReporteCS45.Enabled = False
            End If




            '***************************************************
            'SEGURIDAD a las Opciones del Toolbar VERTICAL *****
            '***************************************************

            '*********Catálogos
            'Caja
            If Seg.HasPermission("MantCaja") Then
                Me.UlbTesoreria.Groups("Catalogos").Items("Cajas").Appearance.Cursor = Cursors.Hand
                Me.UlbTesoreria.Groups("Catalogos").Items("Cajas").Appearance.ForeColor = Color.Black
            Else
                Me.UlbTesoreria.Groups("Catalogos").Items("Cajas").Appearance.Cursor = Cursors.Default
                Me.UlbTesoreria.Groups("Catalogos").Items("Cajas").Appearance.ForeColor = Color.DarkGray
            End If

            'Arqueo
            If Seg.HasPermission("MantArqueo") Then
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ArqueoCaja").Appearance.Cursor = Cursors.Hand
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ArqueoCaja").Appearance.ForeColor = Color.Black
            Else
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ArqueoCaja").Appearance.Cursor = Cursors.Default
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ArqueoCaja").Appearance.ForeColor = Color.DarkGray
            End If

            'Conciliación Bancaria
            If Seg.HasPermission("MantConciliacionBancaria") Then
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ConciliacionBancaria").Appearance.Cursor = Cursors.Hand
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ConciliacionBancaria").Appearance.ForeColor = Color.Black
            Else
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ConciliacionBancaria").Appearance.Cursor = Cursors.Default
                Me.UlbTesoreria.Groups("ArqueoConciliacion").Items("ConciliacionBancaria").Appearance.ForeColor = Color.DarkGray
            End If

            'Denominaciones
            If Seg.HasPermission("MantDenominaciones") Then
                Me.UlbTesoreria.Groups("Catalogos").Items("Denominaciones").Appearance.Cursor = Cursors.Hand
                Me.UlbTesoreria.Groups("Catalogos").Items("Denominaciones").Appearance.ForeColor = Color.Black
            Else
                Me.UlbTesoreria.Groups("Catalogos").Items("Denominaciones").Appearance.Cursor = Cursors.Default
                Me.UlbTesoreria.Groups("Catalogos").Items("Denominaciones").Appearance.ForeColor = Color.DarkGray
            End If

            'Minuta Depósito
            If Seg.HasPermission("MantMinutaDeposito") Then
                Me.UlbTesoreria.Groups("Catalogos").Items("MinutasDeposito").Appearance.Cursor = Cursors.Hand
                Me.UlbTesoreria.Groups("Catalogos").Items("MinutasDeposito").Appearance.ForeColor = Color.Black
            Else
                Me.UlbTesoreria.Groups("Catalogos").Items("MinutasDeposito").Appearance.Cursor = Cursors.Default
                Me.UlbTesoreria.Groups("Catalogos").Items("MinutasDeposito").Appearance.ForeColor = Color.DarkGray
            End If

            'Imprimir Reporte TE44 
            If Seg.HasPermission("MantGenerarEstadoMinutaBanco") Then
                Me.mnuGenerarEstadoMinutaBanco.Enabled = True
            Else
                Me.mnuGenerarEstadoMinutaBanco.Enabled = False
            End If

            If Seg.HasPermission("MantControlProveedor") Then
                Me.mnuControlProveedor.Enabled = True
            Else
                Me.mnuControlProveedor.Enabled = False
            End If

            If Seg.HasPermission("MantControlCajaChica") Then
                Me.mnuControlCajaChica.Enabled = True
            Else
                Me.mnuControlCajaChica.Enabled = False
            End If



        Catch ex As Exception
            Control_Error(ex)
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

    Private Sub mnuCtaBancaria_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCtaBancaria.Click
        'LlamaCtaBancaria()
    End Sub

    'Private Sub mnuMinuta_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMinuta.Click
    '    'LlamaRegistroMinutas()
    'End Sub
    Private Sub LlamaRegistroMinutas()
        Try

            Dim ObjFrmMinuta As frmSteMinutaDeposito
            ObjFrmMinuta = New frmSteMinutaDeposito

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmMinuta.MdiParent = Me

            ObjFrmMinuta.WindowState = FormWindowState.Maximized
            ObjFrmMinuta.sColorFrm = "Naranja"
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

    Private Sub mnuArqueoCaja_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuArqueoCaja.Click
        LlamaArqueoCaja()
    End Sub
    Private Sub LlamaArqueoCaja()
        Try

            Dim ObjFrmArqueo As frmSteArqueoCaja
            ObjFrmArqueo = New frmSteArqueoCaja

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmArqueo.MdiParent = Me

            ObjFrmArqueo.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmArqueo, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmArqueo.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub LlamaPagare()
        Try

            Dim ObjFrmPagare As frmStePagare
            ObjFrmPagare = New frmStePagare

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmPagare.MdiParent = Me

            ObjFrmPagare.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmPagare, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmPagare.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    Private Sub mnuCaja_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCaja.Click
        LlamaRegistroCajas()
    End Sub

    Private Sub LlamaRegistroCajas()
        Try

            Dim ObjFrmCaja As frmSteCaja
            ObjFrmCaja = New frmSteCaja

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmCaja.MdiParent = Me

            ObjFrmCaja.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmCaja, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmCaja.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuDenominaciones_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDenominaciones.Click
        LlamaRegistroDenominaciones()
    End Sub
    Private Sub LlamaRegistroDenominaciones()
        Try

            Dim ObjFrmDenominaciones As frmSteDenominaciones
            ObjFrmDenominaciones = New frmSteDenominaciones

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmDenominaciones.MdiParent = Me

            ObjFrmDenominaciones.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmDenominaciones, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmDenominaciones.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuMinutaDeposito_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMinutaDeposito.Click
        LlamaRegistroMinutas()
    End Sub

    Private Sub mnuConciliacionBancaria_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConciliacionBancaria.Click
        LlamaConciliacion()
    End Sub
    Private Sub LlamaCajero()
        Dim ObjFrmSteCajeros As New frmSteCajeros
        Try

            'Dim ObjFrmSteConciliacionBancaria As frmSteConciliacionBancaria
            'ObjFrmSteConciliacionBancaria = New frmSteConciliacionBancaria

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteCajeros.MdiParent = Me

            ObjFrmSteCajeros.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteCajeros, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteCajeros.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteCajeros = Nothing
        End Try
    End Sub
    Private Sub LlamaConciliacion()
        Try

            Dim ObjFrmSteConciliacionBancaria As frmSteConciliacionBancaria
            ObjFrmSteConciliacionBancaria = New frmSteConciliacionBancaria

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteConciliacionBancaria.MdiParent = Me

            ObjFrmSteConciliacionBancaria.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteConciliacionBancaria, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteConciliacionBancaria.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuListadoRecibos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoRecibos.Click
        LlamaImprimirListadoTesoreria(1)
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

    Private Sub mnuCajero_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCajero.Click
        LlamaCajero()
    End Sub

    Private Sub mnuExportarInformacion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuExportarInformacion.Click
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
            ObjFrmSccDescarga.ColorVentana = "Naranja"
            ObjFrmSccDescarga.ShowDialog()

            'OpenForm(ObjFrmSccDescarga, Me)

            ''-- Para enviar el foco al formulario 
            ''-- que se está llamando.
            'ObjFrmSccDescarga.BringToFront()

            ''-- Poner el cursor en un estado de desocupado
            'Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccDescarga.Close()
            ObjFrmSccDescarga = Nothing
        End Try
    End Sub

    Private Sub mnuImportarRecibos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuImportarRecibos.Click
        LlamaImportar()
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
            ObjFrmSccCarga.ColorVentana = "Naranja"
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

    Private Sub mnuListadoRecibosSinMonto_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoRecibosSinMonto.Click
        LlamaImprimirListadoTesoreria(2)
    End Sub

    Private Sub mnuConsultaReciboArqueo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConsultaReciboArqueo.Click
        LlamaParametrosRecibosPorNumero(2)
    End Sub
    Private Sub LlamaParametrosRecibosPorNumero(ByVal IdReporte As Integer)
        Dim ObjFrmFNC As New FrmSccParametrosRecibosPorNumero
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmFNC.NomRep = IdReporte
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuListadoMinutaFechaDeposito_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoMinutaFechaDeposito.Click
        LlamaImprimirListadoTesoreria(3)
    End Sub

    Private Sub mnuConsecutivoRecibos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConsecutivoRecibos.Click
        LlamaConsecutivoRecibos(2)
    End Sub
    Private Sub LlamaConsecutivoRecibos(ByVal IdNomRep As Integer)
        Dim ObjFrmFNC As New FrmScnParametroListadoCreditosMercados
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmFNC.NomRep = IdNomRep
            ObjFrmFNC.sColorFrm = "Naranja"
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuReciboAnulado_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReciboAnulado.Click
        LlamaReciboAnulado()
    End Sub
    Private Sub LlamaReciboAnulado()
        Try

            Dim ObjFrmSteRecibosAnulados As frmSteRecibosAnulados
            ObjFrmSteRecibosAnulados = New frmSteRecibosAnulados

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteRecibosAnulados.MdiParent = Me

            ObjFrmSteRecibosAnulados.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteRecibosAnulados, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteRecibosAnulados.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuConsecutivoRecibosCredito_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConsecutivoRecibosCredito.Click
        LlamaConsecutivoRecibos(3)
    End Sub

    Private Sub mnuEntregaTalonario_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEntregaTalonario.Click
        LlamaEntregaTalonario()
    End Sub
    Private Sub LlamaEntregaTalonario()
        Try

            Dim ObjFrmSteRecibosEntregados As frmSteRecibosEntregados
            ObjFrmSteRecibosEntregados = New frmSteRecibosEntregados

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteRecibosEntregados.MdiParent = Me

            ObjFrmSteRecibosEntregados.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteRecibosEntregados, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteRecibosEntregados.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuListadoEntregaRecibos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoEntregaRecibos.Click
        LlamaConsecutivoRecibos(4)
    End Sub

    Private Sub mnuConsultaTalonarios_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConsultaTalonarios.Click
        LlamaConsecutivoRecibos(5)
    End Sub

    Private Sub mnuConsolidadoMinutaTE24_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConsolidadoMinutaTE24.Click
        LlamaImprimirListadoTesoreria(4)
    End Sub

    Private Sub mnuEntregaTalonariosDelegaciones_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEntregaTalonariosDelegaciones.Click
        LlamaEntregaTalonarioDelegaciones()
    End Sub
    Private Sub LlamaEntregaTalonarioDelegaciones()
        Try

            Dim ObjFrmSteRecibosEntregados As frmSteRecibosEntregadosDpto
            ObjFrmSteRecibosEntregados = New frmSteRecibosEntregadosDpto

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteRecibosEntregados.MdiParent = Me

            ObjFrmSteRecibosEntregados.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteRecibosEntregados, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteRecibosEntregados.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaCorteTrasladoValores()
        Try

            Dim ObjFrmSteCierreTrasladoValores As frmSteCierreTrasladoValores
            ObjFrmSteCierreTrasladoValores = New frmSteCierreTrasladoValores

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteCierreTrasladoValores.MdiParent = Me
            ObjFrmSteCierreTrasladoValores.nSteCajaID = 0

            ObjFrmSteCierreTrasladoValores.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteCierreTrasladoValores, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteCierreTrasladoValores.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaCierreCajaAutomatica()
        Try

            Dim ObjFrmSteCierreDiarioCaja As frmSteCierreDiarioCaja
            ObjFrmSteCierreDiarioCaja = New frmSteCierreDiarioCaja

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteCierreDiarioCaja.MdiParent = Me

            ObjFrmSteCierreDiarioCaja.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteCierreDiarioCaja, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteCierreDiarioCaja.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuReporteTE27_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE27.Click
        LlamaImprimirListadoTesoreria(5)
    End Sub

    Private Sub mnuCorteTrasladoValores_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCorteTrasladoValores.Click
        LlamaCorteTrasladoValores()
    End Sub

    Private Sub mnuCierreCajaTesoreria_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCierreCajaTesoreria.Click
        LlamaCierreCajaAutomatica()
    End Sub

    Private Sub mnuReporteTE30_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE30.Click
        LlamaParametrosRecibosPorNumero(3)
    End Sub

    Private Sub mnuReporteTE31_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE31.Click
        LlamaParametrosCajeros(1)
    End Sub

    Private Sub LlamaParametrosCajeros(ByVal IdReporte As Integer)
        Dim ObjFrmFNC As New frmSteParametrosCajeros
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmFNC.PresentarCajeros = 0
            ObjFrmFNC.NomRep = IdReporte
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuImpresionCheque_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuImpresionCheque.Click
        LlamaImpresionCheque()
    End Sub

    Private Sub LlamaImpresionCheque()
        Try

            Dim ObjFrmSteImpresionCheques As frmSteImpresionCheques
            ObjFrmSteImpresionCheques = New frmSteImpresionCheques

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteImpresionCheques.MdiParent = Me
            '1 Es Cheque de Gastos Solicitud de Cheque (Pagos Proveedores)
            '0 Es Cheque de Pago a Delegadas Solicitud de Cheque (Otros Cheques)
            ObjFrmSteImpresionCheques.TipoCheque = 0
            ObjFrmSteImpresionCheques.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteImpresionCheques, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteImpresionCheques.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    Private Sub LlamaImpresionChequePersonalizado()
        Try

            Dim ObjFrmSteImpresionCheques As frmSteImpresionChequesPersonalizados
            ObjFrmSteImpresionCheques = New frmSteImpresionChequesPersonalizados

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteImpresionCheques.MdiParent = Me
            ObjFrmSteImpresionCheques.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteImpresionCheques, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteImpresionCheques.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaImpresionChequeProveedor()
        Try

            Dim ObjFrmSteImpresionCheques As frmSteImpresionCheques
            ObjFrmSteImpresionCheques = New frmSteImpresionCheques

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteImpresionCheques.MdiParent = Me
            '1 Es Cheque de Gastos Solicitud de Cheque (Pagos Proveedores)
            '0 Es Cheque de Pago a Delegadas Solicitud de Cheque (Otros Cheques)
            ObjFrmSteImpresionCheques.TipoCheque = 1
            ObjFrmSteImpresionCheques.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteImpresionCheques, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteImpresionCheques.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuReporteTE33_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE33.Click
        LlamaConsecutivoRecibos(9)
    End Sub

    Private Sub mnuReporteCC44_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC44.Click
        LlamaImprimir(2)
    End Sub

    Private Sub LlamaImprimir(ByVal IntReporte As Integer)
        Dim ObjFrmSteParametrosCajeros As New frmSteParametrosCajeros
        Try
            Dim strSQL As String = ""

            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSteParametrosCajeros.NomRep = IntReporte
            ObjFrmSteParametrosCajeros.PresentarCajeros = 0
            ObjFrmSteParametrosCajeros.ColorVentana = "Naranja"
            ObjFrmSteParametrosCajeros.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteParametrosCajeros.Close()
            ObjFrmSteParametrosCajeros = Nothing
        End Try

    End Sub

    Private Sub mnuReporteCC45_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCC45.Click
        LlamaImprimir(3)
    End Sub

    Private Sub mnuReporteTE34_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE34.Click
        LlamaConsecutivoRecibos(10)
    End Sub

    Private Sub mnuReporteTE36_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE36.Click
        LlamaConsecutivoRecibos(11)
    End Sub

    Private Sub mnuReporteTE37_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE37.Click
        LlamaConsecutivoRecibos(12)
    End Sub

    Private Sub mnuPagare_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPagare.Click
        LlamaPagare()
    End Sub

    Private Sub mnuPagareCajero_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPagareCajero.Click
        LlamaPagareCajero(1)
    End Sub

    Private Sub LlamaPagareCajero(ByVal IdReporte As Short)
        Dim ObjFrmSteParametrosPagare As New frmSteParametrosPagare
        Try
            Dim strSQL As String = ""

            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmSteParametrosPagare.NomRep = IdReporte
            ObjFrmSteParametrosPagare.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteParametrosPagare.Close()
            ObjFrmSteParametrosPagare = Nothing
        End Try

    End Sub

    Private Sub mnuReporteTE40_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE40.Click
        LlamaPagareCajero(2)
    End Sub

    Private Sub mnuReporteTE41_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE41.Click
        LlamaConsecutivoRecibos(13)
    End Sub

    Private Sub mnuReporteTE42_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE42.Click
        LlamaConsecutivoRecibos(14)
    End Sub

    Private Sub mnuChequesAnulados_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuChequesAnulados.Click
        LlamaChequeAnulado()
    End Sub

    Private Sub LlamaChequeAnulado()
        Try

            Dim ObjFrmSteChequesAnulados As frmSteChequesAnulados
            ObjFrmSteChequesAnulados = New frmSteChequesAnulados

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteChequesAnulados.MdiParent = Me

            ObjFrmSteChequesAnulados.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSteChequesAnulados, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteChequesAnulados.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuReporteTE44_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTE44.Click
        LlamaParametrosCajeros(4)
    End Sub

    Private Sub mnuConciliacionesBancaLinea_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConciliacionesBancaLinea.Click
        LlamaConciliacionBancoLinea()
    End Sub

    Private Sub LlamaConciliacionBancoLinea()
        Try

            Dim ObjFrmSteConciliacionBancoLinea As frmSteMinutaBancoEnLinea
            ObjFrmSteConciliacionBancoLinea = New frmSteMinutaBancoEnLinea

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteConciliacionBancoLinea.MdiParent = Me

            ObjFrmSteConciliacionBancoLinea.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteConciliacionBancoLinea, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteConciliacionBancoLinea.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuReportes_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReportes.Click

    End Sub

    Private Sub mnuGenerarEstadoMinutaBanco_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuGenerarEstadoMinutaBanco.Click
        Try
            Dim ObjEstadoCuentaDiario As New frmSteEstadoCuentaDiario
            OpenForm(ObjEstadoCuentaDiario, Me)
            ObjEstadoCuentaDiario.BringToFront()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdReporteTE48_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles cmdReporteTE48.Click
        Try
            Dim ObjParametrosRecibosAnulados As New frmSteParametrosRecibosAnulados
            ObjParametrosRecibosAnulados.PresentarCajeros = 0
            ObjParametrosRecibosAnulados.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub MnuReporteCC86_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuReporteCC86.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.NombreReporte = "RepSccCC86.rpt"
            frmVisor.Text = "Reporte de Cajas Automáticas sin Arqueo"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub

    Private Sub mnuReporteTe50_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTe50.Click
        Dim ObjFrmSteParametrosCajeros As New frmSteParametrosCajeros
        Try

            Dim strSQL As String = ""
            ObjFrmSteParametrosCajeros.PresentarCajeros = 0
            ObjFrmSteParametrosCajeros.NomRep = 6
            ObjFrmSteParametrosCajeros.ColorVentana = "Naranja"
            ObjFrmSteParametrosCajeros.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteParametrosCajeros.Close()
            ObjFrmSteParametrosCajeros = Nothing
        End Try
    End Sub

    Private Sub mnuReporteTe49_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteTe49.Click
        Dim ObjFrmSteParametrosCajeros As New frmSteParametrosCajeros
        Try
            Dim strSQL As String = ""
            ObjFrmSteParametrosCajeros.PresentarCajeros = 0
            ObjFrmSteParametrosCajeros.NomRep = 5
            ObjFrmSteParametrosCajeros.ColorVentana = "Naranja"
            ObjFrmSteParametrosCajeros.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteParametrosCajeros.Close()
            ObjFrmSteParametrosCajeros = Nothing
        End Try
    End Sub

    Private Sub MnuReporteTe52_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuReporteTe52.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.NombreReporte = "RepSteTE52.rpt"
            frmVisor.Text = "Reporte de Socias con Créditos con saldos menores que 1 C$"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub
    Private Sub LlamaImprimirLstGrupoPago(ByVal IdReporte As Integer)
        Dim ObjFrmSclParametroGrupoPago As New frmSclParametroGrupoPago
        Try
            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclParametroGrupoPago.NomRep = IdReporte
            ObjFrmSclParametroGrupoPago.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametroGrupoPago.Close()
            ObjFrmSclParametroGrupoPago = Nothing
        End Try
    End Sub
    Private Sub CS44_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles CS44.Click
        Try
            LlamaImprimirLstGrupoPago(5)
        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub

    Private Sub MnuReporteCS45_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles MnuReporteCS45.Click
        Try
            LlamaImprimirLstGrupoPago(6)
        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
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
            ObjFrmSccSolicitudCheque.TipoCheque = 0 'proveedor. ver todos.
            ObjFrmSccSolicitudCheque.TipoChequeAgregar = 1 'Cheque proveedor.

            'ObjFrmSccSolicitudCheque.sColorFrm = "Verde"
            ObjFrmSccSolicitudCheque.sColorFrm = "Naranja"
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


    Private Sub mnuControlChequeraProveedor_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuControlChequeraProveedor.Click
        LlamaImpresionChequeProveedor()
    End Sub

    Private Sub mnuAgregarChequeProveedores_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAgregarRegistroDesembolsoProveedores.Click
        LlamaImpresionChequeProveedor()
    End Sub

    Private Sub mnuAgregarChequeProv_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAgregarChequeProv.Click
        LlamaSolicitudCheque("ELA")
    End Sub

    Private Sub mnuAgregarSolicitudDesembolsoProveedor_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAgregarSolicitudDesembolsoProveedor.Click
        LlamaSolicitudProveedor()
    End Sub
    Private Sub LlamaSolicitudCajaChica()

        Dim ObjfrmSteSolicitudProveedor As New frmSteSolicitudCajaChicaDetalle
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjfrmSteSolicitudProveedor.MdiParent = Me

            ObjfrmSteSolicitudProveedor.WindowState = FormWindowState.Maximized
            'ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            ObjfrmSteSolicitudProveedor.ModoAccion = "ELA" ' StrAccion


            ObjfrmSteSolicitudProveedor.sColorFrm = "Naranja"
            OpenForm(ObjfrmSteSolicitudProveedor, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjfrmSteSolicitudProveedor.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSteSolicitudProveedor = Nothing
        End Try
    End Sub
    Private Sub LlamaSolicitudProveedor()

        Dim ObjfrmSteSolicitudProveedor As New frmSteSolicitudProveedor
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjfrmSteSolicitudProveedor.MdiParent = Me

            ObjfrmSteSolicitudProveedor.WindowState = FormWindowState.Maximized
            'ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            ObjfrmSteSolicitudProveedor.ModoAccion = "ELA" ' StrAccion
            ObjfrmSteSolicitudProveedor.TipoCheque = 0 'proveedor. ver todos.
            ObjfrmSteSolicitudProveedor.TipoChequeAgregar = 1 'Cheque proveedor.

            ObjfrmSteSolicitudProveedor.sColorFrm = "Naranja"
            OpenForm(ObjfrmSteSolicitudProveedor, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjfrmSteSolicitudProveedor.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSteSolicitudProveedor = Nothing
        End Try
    End Sub
    Private Sub LlamaAutorizarSolicitudProveedor()

        Dim ObjfrmSteSolicitudProveedor As New frmSteSolicitudProveedor
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjfrmSteSolicitudProveedor.MdiParent = Me

            ObjfrmSteSolicitudProveedor.WindowState = FormWindowState.Maximized
            'ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            ObjfrmSteSolicitudProveedor.ModoAccion = "AUT" ' StrAccion
            ObjfrmSteSolicitudProveedor.TipoCheque = 0 'proveedor. ver todos.
            ObjfrmSteSolicitudProveedor.TipoChequeAgregar = 1 'Cheque proveedor.

            ObjfrmSteSolicitudProveedor.sColorFrm = "Naranja"
            OpenForm(ObjfrmSteSolicitudProveedor, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjfrmSteSolicitudProveedor.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSteSolicitudProveedor = Nothing
        End Try
    End Sub

    Private Sub LlamaAutorizarSolicitudCajaChica()

        Dim ObjfrmSteSolicitudProveedor As New frmSteSolicitudCajaChicaDetalle
        Try
            '-- Ubicar cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjfrmSteSolicitudProveedor.MdiParent = Me

            ObjfrmSteSolicitudProveedor.WindowState = FormWindowState.Maximized
            'ACCION: ELA: Elaborar. REV: Revisar. AUT: Autorizar
            ObjfrmSteSolicitudProveedor.ModoAccion = "AUT" ' StrAccion


            ObjfrmSteSolicitudProveedor.sColorFrm = "Naranja"
            OpenForm(ObjfrmSteSolicitudProveedor, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjfrmSteSolicitudProveedor.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSteSolicitudProveedor = Nothing
        End Try
    End Sub

    Private Sub mnuAutorizarSolicitudDesembolsoProveedor_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAutorizarSolicitudDesembolsoProveedor.Click
        LlamaAutorizarSolicitudProveedor()
    End Sub

    Private Sub mnuAgregarSolicitudCajajChica_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAgregarSolicitudCajajChica.Click
        LlamaSolicitudCajaChica()
    End Sub

    Private Sub mnuAutorizarSolicitudCajaChica_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAutorizarSolicitudCajaChica.Click
        LlamaAutorizarSolicitudCajaChica()
    End Sub


    Private Sub mnuRecibosExtraviados_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuRecibosExtraviados.Click
        LlamaRecibosExtraviados()
    End Sub

    Private Sub LlamaRecibosExtraviados()
        Try

            Dim ObjFrmSteRecibosExtraviados As frmSteRecibosExtraviados
            ObjFrmSteRecibosExtraviados = New frmSteRecibosExtraviados

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSteRecibosExtraviados.MdiParent = Me

            ObjFrmSteRecibosExtraviados.WindowState = FormWindowState.Maximized
            'ObjFrmSteConciliacionBancaria.sColorFrm = "Naranja"
            OpenForm(ObjFrmSteRecibosExtraviados, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSteRecibosExtraviados.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuImpresionChequePersonzalizado_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles mnuImpresionChequePersonzalizado.Click
        LlamaImpresionChequePersonalizado()
    End Sub
End Class
