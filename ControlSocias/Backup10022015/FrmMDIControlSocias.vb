Imports System.Windows.Forms
Imports Microsoft.Win32
Public Class FrmMDIControlSocias

    Private Sub FrmMDIControlSocias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            Me.Text = "SMUSURA0 - Módulo de Control de Socias"

            InicializaBarraEstado()

            Seguridad()
            '---------------------------------------------------------
            'Seleccionar el primer grupo de la toolbar vertical
            Me.UlbControlSocias.Groups(0).Selected = True

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

    Private Sub UlbControlSocias_ItemSelected(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListBar.ItemEventArgs) Handles UlbControlSocias.ItemSelected
        Try
            Select Case e.Item.Key

                Case "FichaInscripcion"
                    If Seg.HasPermission("MantFichaInscripcion") Then
                        LlamarFichaInscripcion()
                    End If
                Case "HojaVerificacion"
                    If Seg.HasPermission("MantFichaVerificacion") Then
                        LlamarFichaVerificacion()
                    End If
                Case "CatalogoSocias"
                    If Seg.HasPermission("MantRegistroSocia") Then
                        LlamarRegistroSocia()
                    End If
                Case "RegistroGrupoSolidario"
                    If Seg.HasPermission("MantGrupoSolidario") Then
                        LlamarGrupoSolidario()
                    End If

                Case "CambioGrupoSolidario"
                    If Seg.HasPermission("MantCambioGS") Then
                        LlamarCambioGS()
                    End If

                Case "Salir"
                    LlamaSalir()
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '—Impresión del Listado de Socias:
    Private Sub mnuRepSclListadoSocias_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRepSclListadoSocias.Click
        LlamaImprimirLstSocias()
    End Sub

    Private Sub LlamaImprimirLstSocias()
        Dim ObjFrmSclParametroFNC As New frmSclParametroFNC
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"

            ObjFrmSclParametroFNC.NomRep = 6
            ObjFrmSclParametroFNC.LlamadoDesde = frmSclParametroFNC.eLlamado.MenuReportes
            ObjFrmSclParametroFNC.intSclFormatoID = 0
            ObjFrmSclParametroFNC.intSccTipoID = IIf(XcDatosD.ExecuteScalar(Strsql) = 1, 0, InfoSistema.IDDelegacion)
            ObjFrmSclParametroFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametroFNC.Close()
            ObjFrmSclParametroFNC = Nothing

            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    Private Sub LlamaImprimirLstGrupos()
        Dim ObjFrmSclParametroFNC As New frmSclParametroFNC
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"

            ObjFrmSclParametroFNC.NomRep = 5
            ObjFrmSclParametroFNC.LlamadoDesde = frmSclParametroFNC.eLlamado.MenuReportes
            ObjFrmSclParametroFNC.intSclFormatoID = 0
            ObjFrmSclParametroFNC.intSccTipoID = IIf(XcDatosD.ExecuteScalar(Strsql) = 1, 0, InfoSistema.IDDelegacion)
            ObjFrmSclParametroFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametroFNC.Close()
            ObjFrmSclParametroFNC = Nothing

            XcDatosD.Close()
            XcDatosD = Nothing
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
    Private Sub mnuCatValores_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCatValores.Click

        Try
            LlamarCatalogos()
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    Private Sub LlamarCatalogos()

        Dim ObjFrmCatalogos As frmStbCatalogo

        Try
            ObjFrmCatalogos = New frmStbCatalogo

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmCatalogos.MdiParent = Me

            ObjFrmCatalogos.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmCatalogos, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmCatalogos.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmCatalogos = Nothing
        End Try

    End Sub

    Private Sub InicializaBarraEstado()
        Try

            Me.staFecha.Text = Format(Now.Date, "dd-MM-yyyy")
            Me.staBaseDatos.Text = "Base de Datos: " + InfoSistema.DBName
            Me.staServidor.Text = "Servidor: " + InfoSistema.ServerName
            Me.staHora.Text = "" 'Date.Now.Hour
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
    Private Sub mnuCambioGrupo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCambioGrupo.Click
        Try
            LlamarCambioGS()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub LlamarCambioGS()
        Try

            Dim ObjFrmSclCambioGS As frmSclCambioGrupoSolidario
            ObjFrmSclCambioGS = New frmSclCambioGrupoSolidario

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclCambioGS.MdiParent = Me

            ObjFrmSclCambioGS.WindowState = FormWindowState.Maximized

            '  frmSclCambioGrupoSolidario.ShowDialog() 
            OpenForm(ObjFrmSclCambioGS, Me)



            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclCambioGS.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub


    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ''*********************** Menú Fichas *********************
            'Opción Ficha de Inscripción
            If Seg.HasPermission("MantFichaInscripcion") Then
                Me.mnuFichaInscripcion.Enabled = True
            Else
                Me.mnuFichaInscripcion.Enabled = False
            End If

            'Opción Ficha de Verificación
            If Seg.HasPermission("MantFichaVerificacion") Then
                Me.mnuFichaVerificacion.Enabled = True
            Else
                Me.mnuFichaVerificacion.Enabled = False
            End If

            'Opción Registro de Socias
            If Seg.HasPermission("MantRegistroSocia") Then
                Me.mnuCatalogoSocias.Enabled = True
            Else
                Me.mnuCatalogoSocias.Enabled = False
            End If

            'Opción Registro de Grupo Solidario
            If Seg.HasPermission("MantGrupoSolidario") Then
                Me.mnuRegistroGrupo.Enabled = True
            Else
                Me.mnuRegistroGrupo.Enabled = False
            End If

            'Opción Central de Riesgo
            If Seg.HasPermission("MantCentralRiesgo") Then
                Me.mnuCentralRiesgo.Enabled = True
            Else
                Me.mnuCentralRiesgo.Enabled = False
            End If

            'Opción Fomato de Promoción
            If Seg.HasPermission("MantFormatoPromocionCapacitacion") Then
                Me.mnuFormatoPromocion.Enabled = True
            Else
                Me.mnuFormatoPromocion.Enabled = False
            End If

            'Opción Actividad Económica
            If Seg.HasPermission("MantActividadesEconomicas") Then
                Me.mnuActividadEconomica.Enabled = True
            Else
                Me.mnuActividadEconomica.Enabled = False
            End If

            'Opción Ficha Seguimiento
            If Seg.HasPermission("MantFichaSeguimientoCreditos") Then
                Me.mnuFichaSeguimiento.Enabled = True
            Else
                Me.mnuFichaSeguimiento.Enabled = False
            End If

            'Opción Cambio de Grupo Solidario
            If Seg.HasPermission("MantCambioGS") Then
                Me.mnuCambioGrupo.Enabled = True
            Else
                Me.mnuCambioGrupo.Enabled = False
            End If

            'Opción Imprimir Listado de Grupos Solidarios 
            If Seg.HasPermission("ImprimirGrupoSolidario") Then
                Me.mnuRepSclListadoGrupos.Enabled = True
            Else
                Me.mnuRepSclListadoGrupos.Enabled = False
            End If

            'Opción Imprimir Inf. Grupos por Día y Lugar de Pago CS13
            If Seg.HasPermission("ImprimirGrupoXDiaYLugarPago") Then
                Me.mnuGrupoPago.Enabled = True
            Else
                Me.mnuGrupoPago.Enabled = False
            End If

            'Opción Imprimir Barrios Crédito Aprobado CS14
            If Seg.HasPermission("ImprimirBarriosCreditoAprobado") Then
                Me.mnuBarrioCreditoAprobado.Enabled = True
            Else
                Me.mnuBarrioCreditoAprobado.Enabled = False
            End If

            'Opción Imprimir Créditos Aprobados por Tipo de Negocio CS15,CS17
            If Seg.HasPermission("ImprimirCreditoAprobadoTipoNegocio") Then
                Me.mnuCreditoAprobadoTipoNegocio.Enabled = True
            Else
                Me.mnuCreditoAprobadoTipoNegocio.Enabled = False
            End If

            'Opción Imprimir Resumen Grupos X Día y Lugar de Pago CS18
            If Seg.HasPermission("ImprimirResumenGruposDiaLugarPago") Then
                Me.mnuListadoLugarDiaPago.Enabled = True
            Else
                Me.mnuListadoLugarDiaPago.Enabled = False
            End If

            'Opción Imprimir Consolidado Nivel Académico CS21
            If Seg.HasPermission("ImprimirConsolidadoNivelAcademico") Then
                Me.mnuConsolidadoNivelAcademico.Enabled = True
            Else
                Me.mnuConsolidadoNivelAcademico.Enabled = False
            End If

            'Opción Imprimir Socias Aprobadas CS22,CS24
            If Seg.HasPermission("ImprimirSociasAprobadas") Then
                Me.mnuSociasAprobadas.Enabled = True
            Else
                Me.mnuSociasAprobadas.Enabled = False
            End If

            'Opción Imprimir Barrios X Lugar de Pago CS25
            If Seg.HasPermission("ImprimirBarrioXLugarPago") Then
                Me.mnuBarrioLugarPago.Enabled = True
            Else
                Me.mnuBarrioLugarPago.Enabled = False
            End If

            'Opción Imprimir CS33
            If Seg.HasPermission("ImprimirReporteCS33") Then
                Me.mnuReporteCS33.Enabled = True
            Else
                Me.mnuReporteCS33.Enabled = False
            End If

            'Opción Imprimir CS34
            If Seg.HasPermission("ImprimirReporteCS34") Then
                Me.mnuReporteCS34.Enabled = True
            Else
                Me.mnuReporteCS34.Enabled = False
            End If

            'Opción Imprimir CS35
            If Seg.HasPermission("ImprimirReporteCS35") Then
                Me.mnuReporteCS35.Enabled = True
            Else
                Me.mnuReporteCS35.Enabled = False
            End If

            'Opción Imprimir CS36
            If Seg.HasPermission("ImprimirReporteCS36") Then
                Me.mnuReporteCS36.Enabled = True
            Else
                Me.mnuReporteCS36.Enabled = False
            End If

            'Opción Imprimir CS37
            If Seg.HasPermission("ImprimirReporteCS37") Then
                Me.mnuReporteCS37.Enabled = True
            Else
                Me.mnuReporteCS37.Enabled = False
            End If

            'Opción Imprimir CS39
            If Seg.HasPermission("ImprimirReporteCS39") Then
                Me.mnuReporteCS39.Enabled = True
            Else
                Me.mnuReporteCS39.Enabled = False
            End If

            'Opción Imprimir CS46
            If Seg.HasPermission("ImprimirReporteCS46") Then
                Me.mnuReporteCS46.Enabled = True
            Else
                Me.mnuReporteCS46.Enabled = False
            End If
            'Opción Imprimir CS47
            If Seg.HasPermission("ImprimirReporteCS47") Then
                Me.mnuReporteCS47.Enabled = True
            Else
                Me.mnuReporteCS47.Enabled = False
            End If
            'Opción Imprimir CS48
            If Seg.HasPermission("ImprimirReporteCS48") Then
                Me.mnuReporteCS48.Enabled = True
            Else
                Me.mnuReporteCS48.Enabled = False
            End If
            'Opción Imprimir CS49
            If Seg.HasPermission("ImprimirReporteCS49") Then
                Me.mnuReporteCS49.Enabled = True
            Else
                Me.mnuReporteCS49.Enabled = False
            End If
            'Opción Imprimir CS50
            If Seg.HasPermission("ImprimirReporteCS50") Then
                Me.mnuReporteCS50.Enabled = True
            Else
                Me.mnuReporteCS50.Enabled = False
            End If
            'Opción Imprimir CS51
            If Seg.HasPermission("ImprimirReporteCS51") Then
                Me.mnuReporteCS51.Enabled = True
            Else
                Me.mnuReporteCS51.Enabled = False
            End If
            'Opción Imprimir CS52
            If Seg.HasPermission("ImprimirReporteCS52") Then
                Me.mnuReporteCS52.Enabled = True
            Else
                Me.mnuReporteCS52.Enabled = False
            End If
            'Opción Imprimir CS53
            If Seg.HasPermission("ImprimirReporteCS53") Then
                Me.mnuReporteCS53.Enabled = True
            Else
                Me.mnuReporteCS53.Enabled = False
            End If
            'Opción Imprimir CS54
            If Seg.HasPermission("ImprimirReporteCS54") Then
                Me.mnuReporteCS54.Enabled = True
            Else
                Me.mnuReporteCS54.Enabled = False
            End If
            'Opción Imprimir CS55
            If Seg.HasPermission("ImprimirReporteCS55") Then
                Me.mnuReporteCS55.Enabled = True
            Else
                Me.mnuReporteCS55.Enabled = False
            End If
            'Opción Imprimir CS56
            If Seg.HasPermission("ImprimirReporteCS56") Then
                Me.mnuReporteCS56.Enabled = True
            Else
                Me.mnuReporteCS56.Enabled = False
            End If
            'Opción Imprimir CS57
            If Seg.HasPermission("ImprimirReporteCS57") Then
                Me.mnuReporteCS57.Enabled = True
            Else
                Me.mnuReporteCS57.Enabled = False
            End If
            'Opción Imprimir CS58
            If Seg.HasPermission("ImprimirReporteCS58") Then
                Me.mnuReporteCS58.Enabled = True
            Else
                Me.mnuReporteCS58.Enabled = False
            End If




            '***************************************************
            'SEGURIDAD a las Opciones del Toolbar VERTICAL *****
            '***************************************************

            '*********Grupo Fichas
            'Ficha de Inscripción
            If Seg.HasPermission("MantFichaInscripcion") Then
                Me.UlbControlSocias.Groups("RegistroFichas").Items("FichaInscripcion").Appearance.Cursor = Cursors.Hand
                Me.UlbControlSocias.Groups("RegistroFichas").Items("FichaInscripcion").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlSocias.Groups("RegistroFichas").Items("FichaInscripcion").Appearance.Cursor = Cursors.Default
                Me.UlbControlSocias.Groups("RegistroFichas").Items("FichaInscripcion").Appearance.ForeColor = Color.DarkGray
            End If

            'Ficha de Verificación
            If Seg.HasPermission("MantFichaVerificacion") Then
                Me.UlbControlSocias.Groups("RegistroFichas").Items("HojaVerificacion").Appearance.Cursor = Cursors.Hand
                Me.UlbControlSocias.Groups("RegistroFichas").Items("HojaVerificacion").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlSocias.Groups("RegistroFichas").Items("HojaVerificacion").Appearance.Cursor = Cursors.Default
                Me.UlbControlSocias.Groups("RegistroFichas").Items("HojaVerificacion").Appearance.ForeColor = Color.DarkGray
            End If

            'Registro de Socias
            If Seg.HasPermission("MantRegistroSocia") Then
                Me.UlbControlSocias.Groups("ControlSocias").Items("CatalogoSocias").Appearance.Cursor = Cursors.Hand
                Me.UlbControlSocias.Groups("ControlSocias").Items("CatalogoSocias").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlSocias.Groups("ControlSocias").Items("CatalogoSocias").Appearance.Cursor = Cursors.Default
                Me.UlbControlSocias.Groups("ControlSocias").Items("CatalogoSocias").Appearance.ForeColor = Color.DarkGray
            End If

            'Registro de Grupo Solidario
            If Seg.HasPermission("MantGrupoSolidario") Then
                Me.UlbControlSocias.Groups("ControlSocias").Items("RegistroGrupoSolidario").Appearance.Cursor = Cursors.Hand
                Me.UlbControlSocias.Groups("ControlSocias").Items("RegistroGrupoSolidario").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlSocias.Groups("ControlSocias").Items("RegistroGrupoSolidario").Appearance.Cursor = Cursors.Default
                Me.UlbControlSocias.Groups("ControlSocias").Items("RegistroGrupoSolidario").Appearance.ForeColor = Color.DarkGray
            End If

            'Cambio de Grupo Solidario
            If Seg.HasPermission("MantCambioGS") Then
                Me.UlbControlSocias.Groups("ControlSocias").Items("CambioGrupoSolidario").Appearance.Cursor = Cursors.Hand
                Me.UlbControlSocias.Groups("ControlSocias").Items("CambioGrupoSolidario").Appearance.ForeColor = Color.Black
            Else
                Me.UlbControlSocias.Groups("ControlSocias").Items("CambioGrupoSolidario").Appearance.Cursor = Cursors.Default
                Me.UlbControlSocias.Groups("ControlSocias").Items("CambioGrupoSolidario").Appearance.ForeColor = Color.DarkGray
            End If


            'Opción Imprimir CS41
            If Seg.HasPermission("ImprimirReporteCS41") Then
                Me.mnuListadoLugarDiaPagoSemanal.Enabled = True
            Else
                Me.mnuListadoLugarDiaPagoSemanal.Enabled = False
            End If



            'Imprimir totalizados de socias y montos por tipo de negocio
            If Seg.HasPermission("ImprimirReporteCS43") = False Then
                Me.mnuTotalDistribucionGeografica.Enabled = False
            Else  'Habilita
                Me.mnuTotalDistribucionGeografica.Enabled = True
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub mnuFichaInscripcion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFichaInscripcion.Click
        Try
            LlamarFichaInscripcion()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamarFichaInscripcion()

        Dim ObjFrmSclFichaInscripcion As frmSclFichaInscripcion

        Try

            ObjFrmSclFichaInscripcion = New frmSclFichaInscripcion

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclFichaInscripcion.MdiParent = Me

            ObjFrmSclFichaInscripcion.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclFichaInscripcion, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclFichaInscripcion.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclFichaInscripcion = Nothing
        End Try

    End Sub

    Private Sub mnuFichaVerificacion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFichaVerificacion.Click
        Try
            LlamarFichaVerificacion()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamarFichaVerificacion()

        Dim ObjFrmSclFichaVerificacion As frmSclFichaVerificacion

        Try
            ObjFrmSclFichaVerificacion = New frmSclFichaVerificacion

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclFichaVerificacion.MdiParent = Me

            ObjFrmSclFichaVerificacion.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclFichaVerificacion, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclFichaVerificacion.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclFichaVerificacion = Nothing
        End Try

    End Sub

    Private Sub mnuCatalogoSocias_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCatalogoSocias.Click
        Try
            LlamarRegistroSocia()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamarGrupoSolidario()
        Try

            Dim ObjFrmSclGrupoSolidario As frmSclGrupoSolidario
            ObjFrmSclGrupoSolidario = New frmSclGrupoSolidario

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclGrupoSolidario.MdiParent = Me

            ObjFrmSclGrupoSolidario.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclGrupoSolidario, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclGrupoSolidario.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    Private Sub LlamarRegistroSocia()
        Try

            Dim ObjFrmSclSocia As frmSclSocia
            ObjFrmSclSocia = New frmSclSocia

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclSocia.MdiParent = Me

            ObjFrmSclSocia.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclSocia, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclSocia.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuRegistroGrupo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuRegistroGrupo.Click
        Try
            LlamarGrupoSolidario()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuGrupoPago_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuGrupoPago.Click
        LlamaImprimirLstGrupoPago(1)
    End Sub

    Private Sub mnuBarrioCreditoAprobado_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuBarrioCreditoAprobado.Click
        LlamaImprimirListado(1)
    End Sub

    Private Sub mnuCreditoAprobadoTipoNegocio_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCreditoAprobadoTipoNegocio.Click
        LlamaImprimirListado(2)
    End Sub

    Private Sub mnuListadoLugarDiaPago_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoLugarDiaPago.Click
        LlamaImprimirLstGrupoPago(2)
    End Sub

    Private Sub mnuConsolidadoNivelAcademico_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuConsolidadoNivelAcademico.Click
        Dim ObjFrmFNC As New frmSccParametroResumenCreditos
        Try
            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'frmSccParametroResumenCreditos.NomRep = 1
            ObjFrmFNC.ColorVentana = "RojoLight"
            ObjFrmFNC.NomRep = frmSccParametroResumenCreditos.EnumReportes.NivelAcademico
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub mnuSociasAprobadas_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSociasAprobadas.Click
        LlamaImprimirListado(3)
    End Sub

    Private Sub mnuBarrioLugarPago_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuBarrioLugarPago.Click

        LlamaImprimirLstGrupoPago(3)
    End Sub

    Private Sub mnuCentralRiesgo_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCentralRiesgo.Click
        LlamarCentralRiesgo()
    End Sub
    Private Sub LlamarCentralRiesgo()
        Try

            Dim ObjFrmSclReferenciaSocia As frmSclReferenciaSocia
            ObjFrmSclReferenciaSocia = New frmSclReferenciaSocia

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclReferenciaSocia.MdiParent = Me

            ObjFrmSclReferenciaSocia.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclReferenciaSocia, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclReferenciaSocia.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuFormatoPromocion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFormatoPromocion.Click
        LlamarFormatoPromocion()
    End Sub
    Private Sub LlamarFormatoPromocion()
        Try

            Dim ObjFrmSclFormatoPromocionCapacitacion As frmSclFormatoPromocionCapacitacion
            ObjFrmSclFormatoPromocionCapacitacion = New frmSclFormatoPromocionCapacitacion

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclFormatoPromocionCapacitacion.MdiParent = Me

            ObjFrmSclFormatoPromocionCapacitacion.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclFormatoPromocionCapacitacion, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclFormatoPromocionCapacitacion.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuActividadEconomica_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuActividadEconomica.Click
        LlamarActividadEconomica()
    End Sub
    Private Sub LlamarActividadEconomica()
        Try

            Dim ObjFrmSclActividadEconomica As frmSclActividadEconomica
            ObjFrmSclActividadEconomica = New frmSclActividadEconomica

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclActividadEconomica.MdiParent = Me

            ObjFrmSclActividadEconomica.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclActividadEconomica, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclActividadEconomica.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuFichaSeguimiento_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFichaSeguimiento.Click
        LlamarFichaSeguimiento()
    End Sub
    Private Sub LlamarFichaSeguimiento()
        Try

            Dim ObjFrmSclFichaSeguimiento As frmSclFichaSeguimiento
            ObjFrmSclFichaSeguimiento = New frmSclFichaSeguimiento

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSclFichaSeguimiento.MdiParent = Me

            ObjFrmSclFichaSeguimiento.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSclFichaSeguimiento, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSclFichaSeguimiento.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuReporteCS33_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS33.Click
        'LlamaReporteCS33(4)
        LlamaReporteCS(3) 'para el CS33

    End Sub
    Private Sub LlamaReporteCS33(ByVal IdReporte As Integer)
        Dim ObjFrmSclParametrosPromocion As New frmSclParametrosPromocion
        Try
            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclParametrosPromocion.NomRep = IdReporte
            ObjFrmSclParametrosPromocion.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametrosPromocion.Close()
            ObjFrmSclParametrosPromocion = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS34_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS34.Click
        'LlamaReporteCS33(5)
        LlamaReporteCS(4) 'para el CS34
    End Sub

    Private Sub mnuReporteCS35_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS35.Click
        'LlamaImprimirListado(5)
        LlamaImprimirListado(5) 'para el CS35
    End Sub

    Private Sub mnuReporteCS36_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS36.Click
        Dim ObjFrmReporteCS36 As New FrmSclParametrosSociasFCL
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmReporteCS36.ColorVentana = "RojoLight"
            ObjFrmReporteCS36.NomRep = 1
            ObjFrmReporteCS36.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmReporteCS36.Close()
            ObjFrmReporteCS36 = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS37_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS37.Click
        Dim ObjFrmReporteCS37 As New FrmSclParametrosSociasFCL
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrmReporteCS37.ColorVentana = "RojoLight"
            ObjFrmReporteCS37.NomRep = 2
            ObjFrmReporteCS37.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmReporteCS37.Close()
            ObjFrmReporteCS37 = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS39_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS39.Click
        LlamarCreditosVentanaUsura()
    End Sub

    Private Sub LlamarCreditosVentanaUsura()
        Dim ObjFrmVentanaUsura As New frmSccParametrosMetasPrograma
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            'frmSccParametroResumenCreditos.NomRep = 1
            ObjFrmVentanaUsura.strColor = "RojoLight"
            ObjFrmVentanaUsura.NomRep = frmSccParametrosMetasPrograma.EnumReportes.SociasVentanaUsura
            ObjFrmVentanaUsura.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmVentanaUsura.Close()
            ObjFrmVentanaUsura = Nothing
        End Try
    End Sub
    Private Sub LlamaReporteCS(ByVal IdReporte As Integer)
        Dim ObjFrmSclParametrosPromocion As New FrmSclParametrosSociasFCL 'frmSclParametrosPromocion
        Try
            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclParametrosPromocion.NomRep = IdReporte
            ObjFrmSclParametrosPromocion.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametrosPromocion.Close()
            ObjFrmSclParametrosPromocion = Nothing
        End Try
    End Sub

    Private Sub LlamaImprimirListado(ByVal IDReporte As Integer)
        Dim ObjFrmSclParametrosListadoSocias As New frmSclParametrosListadoSocias
        Try
            If My.Application.OpenForms.Count > 2 Then
                'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclParametrosListadoSocias.NomRep = IDReporte
            ObjFrmSclParametrosListadoSocias.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametrosListadoSocias.Close()
            ObjFrmSclParametrosListadoSocias = Nothing
        End Try
    End Sub


    Private Sub mnuListadoLugarDiaPagoSemanal_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuListadoLugarDiaPagoSemanal.Click
        LlamaImprimirLstGrupoPago(4)
    End Sub

    Private Sub mnuTotalDistribucionGeografica_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTotalDistribucionGeografica.Click
        Me.LlamaImprimirListado(7)
    End Sub

    Private Sub mnuReporteCS46_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS46.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 1
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS47_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS47.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 2
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS48_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS48.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 3
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS49_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS49.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 4
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS50_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS50.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 5
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS51_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS51.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 6
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS52_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS52.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 7
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS53_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS53.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 8
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS54_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS54.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 9
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS55_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS55.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 10
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS56_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS56.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 11
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS57_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS57.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 12
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub

    Private Sub mnuReporteCS58_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteCS58.Click
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If

            ObjFrmSccParametrosCreditosSocia.NomRep = 13
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try
    End Sub
End Class
