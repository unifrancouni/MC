Imports System.Windows.Forms
Imports Microsoft.Win32
Public Class FrmMDICatalogoBasico

    'Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.LayoutMdi(MdiLayout.Cascade)
    'End Sub
    'Private Sub FrmMDICompras_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    '    Try
    '        Me.Text = "SMUSURA0 - Módulo de Catálogos Básicos"
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    Private Sub FrmMDICatalogoBasico_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim ObjGUI As GUI.ClsGUI
            ObjGUI = New GUI.ClsGUI

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            Me.Text = "SMUSURA0 - Módulo de Catálogos Básicos"

            InicializaBarraEstado()
            Seguridad()

            'Seleccionar el primer grupo de la toolbar vertical
            Me.UlbCatalogoBasico.Groups(0).Selected = True

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalir.Click
        Try
            LlamaSalir()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub mnuAyudaCompras_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAyudaCompras.Click
        Try
            LlamaAyuda()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Private Sub mnuCascada_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCascada.Click
    '    Me.LayoutMdi(MdiLayout.Cascade)
    'End Sub

    'Private Sub mnuVertical_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuVertical.Click
    '    Try
    '        Me.LayoutMdi(MdiLayout.TileVertical)
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    'Private Sub mnuHorizontal_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuHorizontal.Click
    '    Try
    '        Me.LayoutMdi(MdiLayout.TileHorizontal)
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    Private Sub mnuCerrarTodas_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCerrarTodas.Click
        Try
            For Each ChildForm As Form In Me.MdiChildren
                ChildForm.Close()
            Next
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub UlbCatalogoBasico_ItemSelected(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinListBar.ItemEventArgs) Handles UlbCatalogoBasico.ItemSelected
        Try
            Select Case e.Item.Key

                '---------------Catálogos ---------------

                Case "Generales"
                    If Seg.HasPermission("MantCatalogoValores") Then
                        LlamarCatalogo()
                    End If

                Case "Cargos"
                    If Seg.HasPermission("MantCargo") Then
                        LlamaCargo()
                    End If

                Case "Profesiones"
                    If Seg.HasPermission("MantProfesion") Then
                        LlamaProfesion()
                    End If

                Case "Delegaciones"
                    If Seg.HasPermission("MantDelegacion") Then
                        LlamaDelegaciones()
                    End If

                    '---------------Moneda---------------

                    'Tipo de Moneda
                Case "TipoMoneda"
                    If Seg.HasPermission("MantMoneda") Then
                        LlamarTipoMoneda()
                    End If

                    'Tasas de Cambio
                Case "TasaCambio"
                    If Seg.HasPermission("MantTasaCambio") Then
                        LlamarTasasCambio()
                    End If

                    '---------------Ubicación Geográfica---------------

                Case "Departamento"
                    If Seg.HasPermission("MantDeptoMunic") Then
                        LlamaDepartamento()
                    End If

                Case "Barrio"
                    If Seg.HasPermission("MantBarrio") Then
                        LlamaBarrio()
                    End If

                Case "Distrito"
                    If Seg.HasPermission("MantDistrito") Then
                        LlamaDistrito()
                    End If

                Case "Mercado"
                    If Seg.HasPermission("MantMercado") Then
                        LlamaMercado()
                    End If

                Case "Cooperativa"
                    If Seg.HasPermission("MantCooperativa") Then
                        LlamaMercado(1)
                    End If

                Case "Ayuda"
                    LlamaAyuda()
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
            Me.staHora.Text = ""   'Date.Now.Hour
            If Trim(InfoSistema.UsrName) <> "" Then
                Me.staLogin.Text = "Usuario: " + InfoSistema.UsrName
            Else
                Me.staLogin.Text = "Usuario: " + InfoSistema.LoginName
            End If
            Me.staUnidadSalud.Text = ""   '"Unidad: " + InfoSistema.CodigoUnidadLocal + "-" + InfoSistema.UnidadSaludLocal
            'Me.staVarios.Text = ""

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Private Sub tmrGeneral_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.staHora.Text = Now.ToLongTimeString
    'End Sub

    Private Sub mnuGenerales_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuGenerales.Click

        Try
            LlamarCatalogo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaTipoPersona(ByVal TipoPersona As String)

        'Declaracion de Variables 
        Dim ObjFrmStbPersona As frmStbPersona

        Try
            ObjFrmStbPersona = New frmStbPersona
            ObjFrmStbPersona.TipoPersona = TipoPersona
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmStbPersona.MdiParent = Me
            ObjFrmStbPersona.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbPersona, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbPersona.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbPersona = Nothing
        End Try
    End Sub
    Private Sub LlamarCatalogo()

        Dim objFrmStbCatalogo As frmStbCatalogo

        Try
            objFrmStbCatalogo = New frmStbCatalogo

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            objFrmStbCatalogo.MdiParent = Me

            objFrmStbCatalogo.WindowState = FormWindowState.Maximized
            OpenForm(objFrmStbCatalogo, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            objFrmStbCatalogo.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            objFrmStbCatalogo = Nothing
        End Try

    End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            '*********************** Menú Catálogos *********************

            'Opción Catálogo - Valores
            If Seg.HasPermission("MantCatalogoValores") Then
                Me.mnuGenerales.Enabled = True
            Else
                Me.mnuGenerales.Enabled = False
            End If

            'Opción Cargos
            If Seg.HasPermission("MantCargo") Then
                Me.mnuCargos.Enabled = True
            Else
                Me.mnuCargos.Enabled = False
            End If

            'Opción Profesiones
            If Seg.HasPermission("MantProfesion") Then
                Me.mnuProfesion.Enabled = True
            Else
                Me.mnuProfesion.Enabled = False
            End If

            'Opción Delegaciones
            If Seg.HasPermission("MantDelegacion") Then
                Me.mnuDelegaciones.Enabled = True
            Else
                Me.mnuDelegaciones.Enabled = False
            End If

            'Opción Persona Natural
            If Seg.HasPermission("MantPersonaNatural") Then
                Me.mnuPersonaNatural.Enabled = True
            Else
                Me.mnuPersonaNatural.Enabled = False
            End If

            'Opción Persona Jurídica
            If Seg.HasPermission("MantPersonaJuridica") Then
                Me.mnuPersonaJuridica.Enabled = True
            Else
                Me.mnuPersonaJuridica.Enabled = False
            End If

            'Opción Empleado
            If Seg.HasPermission("MantEmpleado") Then
                Me.mnuEmpleado.Enabled = True
            Else
                Me.mnuEmpleado.Enabled = False
            End If

            'Opción Proveedor
            If Seg.HasPermission("MantProveedor") Then
                Me.mnuProveedor.Enabled = True
            Else
                Me.mnuProveedor.Enabled = False
            End If


            '*********************** Menú Moneda *********************

            'Opción Tipos de Moneda
            If Seg.HasPermission("MantMoneda") Then
                Me.mnuTipoMoneda.Enabled = True
            Else
                Me.mnuTipoMoneda.Enabled = False
            End If

            'Opción Tasas de Cambio
            If Seg.HasPermission("MantTasaCambio") Then
                Me.mnuTasasCambio.Enabled = True
            Else
                Me.mnuTasasCambio.Enabled = False
            End If


            '*********************** Menú Ubicación Geográfica *********************

            'Opción Barrio
            If Seg.HasPermission("MantBarrio") Then
                Me.mnuBarrio.Enabled = True
            Else
                Me.mnuBarrio.Enabled = False
            End If

            'Opción Distrito
            If Seg.HasPermission("MantDistrito") Then
                Me.mnuDistrito.Enabled = True
            Else
                Me.mnuDistrito.Enabled = False
            End If

            'Opción Mercado
            If Seg.HasPermission("MantMercado") Then
                Me.mnuMercado.Enabled = True
            Else
                Me.mnuMercado.Enabled = False
            End If

            'Opción Mercado
            If Seg.HasPermission("MantCooperativa") Then
                Me.mnuCooperativa.Enabled = True
            Else
                Me.mnuCooperativa.Enabled = False
            End If

            'Opción Departamento/Municipio
            If Seg.HasPermission("MantDeptoMunic") Then
                Me.mnuDepartamento.Enabled = True
            Else
                Me.mnuDepartamento.Enabled = False
            End If

            'Opción Formato Firma Digital CB15
            If Seg.HasPermission("ImprimirFormatoCapturaFirmas") Then
                Me.mnuFormatoFirmaDigital.Enabled = True
            Else
                Me.mnuFormatoFirmaDigital.Enabled = False
            End If

            'Opción Mantenimiento Reportes
            If Seg.HasPermission("MantReporte") Then
                Me.mnuReporte.Enabled = True
            Else
                Me.mnuReporte.Enabled = False
            End If

            'Opción Mantenimiento Parámetros
            If Seg.HasPermission("MantParametro") Then
                Me.mnuParametros.Enabled = True
            Else
                Me.mnuParametros.Enabled = False
            End If

            '***************************************************
            'SEGURIDAD a las Opciones del Toolbar VERTICAL *****
            '***************************************************

            '*********Grupo Catalogos
            'Catálogo - Valores
            If Seg.HasPermission("MantCatalogoValores") Then
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Generales").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Generales").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Generales").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Generales").Appearance.ForeColor = Color.DarkGray
            End If

            'Cargos
            If Seg.HasPermission("MantCargo") Then
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Cargos").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Cargos").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Cargos").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Cargos").Appearance.ForeColor = Color.DarkGray
            End If

            'Profesiones
            If Seg.HasPermission("MantProfesion") Then
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Profesiones").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Profesiones").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Profesiones").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Profesiones").Appearance.ForeColor = Color.DarkGray
            End If

            'Delegaciones
            If Seg.HasPermission("MantDelegacion") Then
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Delegaciones").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Delegaciones").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Delegaciones").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("Catalogos").Items("Delegaciones").Appearance.ForeColor = Color.DarkGray
            End If

            '*********Grupo Moneda
            'Tipos de Moneda
            If Seg.HasPermission("MantMoneda") Then
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TipoMoneda").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TipoMoneda").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TipoMoneda").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TipoMoneda").Appearance.ForeColor = Color.DarkGray
            End If

            'Tasas de Cambio
            If Seg.HasPermission("MantTasaCambio") Then
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TasaCambio").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TasaCambio").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TasaCambio").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("Moneda").Items("TasaCambio").Appearance.ForeColor = Color.DarkGray
            End If

            '*********Grupo Ubicación Geográfica
            'Barrio
            If Seg.HasPermission("MantBarrio") Then
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Barrio").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Barrio").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Barrio").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Barrio").Appearance.ForeColor = Color.DarkGray
            End If

            'Distrito
            If Seg.HasPermission("MantDistrito") Then
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Distrito").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Distrito").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Distrito").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Distrito").Appearance.ForeColor = Color.DarkGray
            End If

            'Departamento
            If Seg.HasPermission("MantDeptoMunic") Then
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Departamento").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Departamento").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Departamento").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Departamento").Appearance.ForeColor = Color.DarkGray
            End If

            'Mercado
            If Seg.HasPermission("MantMercado") Then
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Mercado").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Mercado").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Mercado").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Mercado").Appearance.ForeColor = Color.DarkGray
            End If

            'Mercado
            If Seg.HasPermission("MantCooperativa") Then
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Cooperativa").Appearance.Cursor = Cursors.Hand
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Cooperativa").Appearance.ForeColor = Color.Black
            Else
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Cooperativa").Appearance.Cursor = Cursors.Default
                Me.UlbCatalogoBasico.Groups("UbicacionGeografica").Items("Cooperativa").Appearance.ForeColor = Color.DarkGray
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuTipoMoneda_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTipoMoneda.Click
        Try
            LlamarTipoMoneda()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamarTipoMoneda()
        Try

            Dim ObjFrmStbTipoMoneda As frmStbTipoMoneda
            ObjFrmStbTipoMoneda = New frmStbTipoMoneda

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmStbTipoMoneda.MdiParent = Me

            ObjFrmStbTipoMoneda.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbTipoMoneda, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmStbTipoMoneda.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub mnuTasasCambio_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuTasasCambio.Click
        Try
            LlamarTasasCambio()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamarTasasCambio()
        Try

            Dim ObjFrmStbTasaCambio As frmStbTasaCambio
            ObjFrmStbTasaCambio = New frmStbTasaCambio

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmStbTasaCambio.MdiParent = Me

            ObjFrmStbTasaCambio.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbTasaCambio, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmStbTasaCambio.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuDepartamento_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDepartamento.Click
        Try
            LlamaDepartamento()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaDepartamento()

        'Declaracion de Variables 
        Dim ObjFrmStbDepartamento As frmStbDepartamento

        Try
            ObjFrmStbDepartamento = New frmStbDepartamento
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmStbDepartamento.MdiParent = Me
            ObjFrmStbDepartamento.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbDepartamento, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbDepartamento.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbDepartamento = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaBarrio
    ' Descripción:          Procedimiento para activar la opción de Barrios.
    '-------------------------------------------------------------------------
    Private Sub LlamaBarrio()

        'Declaracion de Variables 
        Dim ObjFrmStbBarrio As frmStbBarrio

        Try
            ObjFrmStbBarrio = New frmStbBarrio

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbBarrio.MdiParent = Me
            ObjFrmStbBarrio.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbBarrio, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbBarrio.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbBarrio = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaDistrito
    ' Descripción:          Procedimiento para activar la opción de Distritos.
    '-------------------------------------------------------------------------
    Private Sub LlamaDistrito()

        'Declaracion de Variables 
        Dim ObjFrmStbDistrito As frmStbDistrito

        Try
            ObjFrmStbDistrito = New frmStbDistrito

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbDistrito.MdiParent = Me
            ObjFrmStbDistrito.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbDistrito, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbDistrito.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbDistrito = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaMercado
    ' Descripción:          Procedimiento para activar la opción de Mercados.
    '-------------------------------------------------------------------------
    Private Sub LlamaMercado(Optional ByVal _tipo As Integer = 0)

        'Declaracion de Variables 
        Dim ObjFrmStbMercado As frmStbMercado

        Try
            ObjFrmStbMercado = New frmStbMercado

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbMercado.Tipo = _tipo

            ObjFrmStbMercado.MdiParent = Me
            ObjFrmStbMercado.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbMercado, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbMercado.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbMercado = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaCargo
    ' Descripción:          Procedimiento para activar la opción de Cargos.
    '-------------------------------------------------------------------------
    Private Sub LlamaCargo()

        'Declaracion de Variables 
        Dim ObjFrmStbCargo As frmStbCargo

        Try
            ObjFrmStbCargo = New frmStbCargo

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbCargo.MdiParent = Me
            ObjFrmStbCargo.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbCargo, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbCargo.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbCargo = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaCargo
    ' Descripción:          Procedimiento para activar la opción de Cargos.
    '-------------------------------------------------------------------------
    Private Sub LlamaProfesion()

        'Declaracion de Variables 
        Dim ObjFrmStbProfesion As frmStbProfesion

        Try
            ObjFrmStbProfesion = New frmStbProfesion

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbProfesion.MdiParent = Me
            ObjFrmStbProfesion.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbProfesion, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbProfesion.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbProfesion = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaDelegaciones
    ' Descripción:          Procedimiento para activar la opción de Delegaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaDelegaciones()

        'Declaracion de Variables 
        Dim ObjFrmStbDelegacion As New frmStbDelegacion

        Try
            'ObjFrmStbDelegacion = New frmStbDelegacion

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbDelegacion.MdiParent = Me
            ObjFrmStbDelegacion.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbDelegacion, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbDelegacion.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmStbDelegacion.Close()
            ObjFrmStbDelegacion = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub
    Private Sub mnuBarrio_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuBarrio.Click
        LlamaBarrio()
    End Sub

    Private Sub mnuDistrito_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDistrito.Click
        LlamaDistrito()
    End Sub

    Private Sub mnuMercado_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuMercado.Click
        LlamaMercado()
    End Sub

    Private Sub mnuPersonaNatural_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPersonaNatural.Click
        Try
            'LlamaTiposInsumo()
            LlamaTipoPersona("N")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuPersonaJuridica_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPersonaJuridica.Click
        Try
            'LlamaTiposInsumo()
            LlamaTipoPersona("J")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuEmpleado_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuEmpleado.Click
        Try
            'LlamaTiposInsumo()
            LlamaTipoPersona("E")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuCargos_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCargos.Click
        LlamaCargo()
    End Sub

    Private Sub mnuProfesion_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuProfesion.Click
        LlamaProfesion()
    End Sub

    Private Sub mnuDelegaciones_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuDelegaciones.Click
        LlamaDelegaciones()
    End Sub

    Private Sub mnuFormatoFirmaDigital_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuFormatoFirmaDigital.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepStbCB15.rpt"
            frmVisor.Text = "Formato de Captura de Firmas Digitales"
            frmVisor.SQLQuery = "Select * From vwStbEmpleado Where (nPersonaActiva = 1) Order by sNombreCargo, sCodigo"
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub mnuReporte_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporte.Click
        LlamaReportes()
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaDelegaciones
    ' Descripción:          Procedimiento para activar la opción de Delegaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaReportes()

        'Declaracion de Variables 
        Dim ObjFrmStbReporte As New frmStbReporte

        Try
            'ObjFrmStbDelegacion = New frmStbDelegacion

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbReporte.MdiParent = Me
            ObjFrmStbReporte.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbReporte, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbReporte.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmStbDelegacion.Close()
            ObjFrmStbReporte = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub mnuParametros_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuParametros.Click
        LlamaParametros()
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaDelegaciones
    ' Descripción:          Procedimiento para activar la opción de Delegaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaParametros()

        'Declaracion de Variables 
        Dim ObjFrmStbParametro As New frmStbParametro

        Try
            'ObjFrmStbDelegacion = New frmStbDelegacion

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            ObjFrmStbParametro.MdiParent = Me
            ObjFrmStbParametro.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmStbParametro, Me)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando ------------
            ObjFrmStbParametro.BringToFront()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmStbDelegacion.Close()
            ObjFrmStbParametro = Nothing

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub mnuCooperativa_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuCooperativa.Click
        LlamaMercado(1)
    End Sub

    Private Sub mnuProveedor_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuProveedor.Click
        Try
            'LlamaTiposInsumo()
            LlamaTipoPersona("P")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class
