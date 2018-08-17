' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                12/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclTrasladosLugarDePagos.vb
' Descripción:          Este formulario permite realizar modificaciones 
'                       masivas de Lugar de Pagos para Fichas de Notifi-
'                       cación de Créditos con el Estado APROBADA y que
'                       contengan al menos una Ficha de Inscripción Activa
'                       (diferente de Anulada y Cancelada).
'-------------------------------------------------------------------------
Public Class frmSclTrasladosLugarDePagos

    '- Declaración de Variables 
    Dim XdtFicha As BOSistema.Win.XDataSet.xDataTable
    Dim XdsLugarPagos As BOSistema.Win.XDataSet
    Dim XdsMunicipios As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       frmSclTrasladosLugarDePagos_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclTrasladosLugarDePagos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtFicha.Close()
            XdtFicha = Nothing

            XdsLugarPagos.Close()
            XdsLugarPagos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       frmSclTrasladosLugarDePagos_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Fichas de Notificación en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclTrasladosLugarDePagos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '--combos para cambiar lugar de pagos usando municipio
            Me.LabelMunicipio.Visible = False
            Me.cboMunicipio.Visible = False


            InicializaVariables()
            Seguridad()

            CargarLugarPagosO(0)
            CargarLugarPagosD(0)
            CargarFuente(0)

            CargarMunicipio(0)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       CargarFicha
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de las Fichas de Notificación en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarFicha()
        Try
            Dim Strsql As String = ""
            'Fichas Aprobadas del Lugar de Pagos y que tengan Fichas de Inscripción ACTIVAS (<> Anuladas (4) y Canceladas (7)):
            Strsql = " SELECT a.nSclFichaNotificacionID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
                     " a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  a.Fuente, a.sUsuarioCreacion, a.nStbPersonaLugarPagosID, a.nScnFuenteFinanciamientoID " & _
                     " FROM vwSccTrasladoLugarPagos AS a " & _
                     " WHERE (a.sCodEstado = '2') " & _
                     " And (a.nStbPersonaLugarPagosID = " & cboLugarPagosO.Columns("nStbPersonaID").Value & ") " & _
                     " And (a.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") " & _
                     " Order by a.nCodigo"
            XdtFicha.ExecuteSql(Strsql)

            'Asignando fuente de datos al Grid:
            Me.grdFicha.DataSource = XdtFicha.Source
            Me.grdFicha.Caption = " Listado de Fichas de Notificación de Crédito Aprobadas por Fondo (" + Me.grdFicha.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Public Sub CargarFicha2()
        Try
            Dim Strsql As String = ""
            'Fichas Aprobadas del Lugar de Pagos y que tengan Fichas de Inscripción ACTIVAS (<> Anuladas (4) y Canceladas (7)):
            Strsql = "  SELECT a.nSclFichaNotificacionID, a.nCodigo, a.EstadoFicha, " & _
                    " a.CodigoGS, a.sNombreGS, a.sNumSesion, a.dFechaNotificacion, " & _
                    " a.dFechaHoraEntregaCK, a.sCodEstado, a.Fuente, a.sUsuarioCreacion, " & _
                    " a.nStbPersonaLugarPagosID, a.nScnFuenteFinanciamientoID " & _
                     " FROM vwSccTrasladoLugarPagos AS a INNER JOIN SclGrupoSolidario b ON a.CodigoGS=b.sCodigo " & _
                     " inner join vwStbUbicacionGeografica c ON b.nStbBarrioVerificadoID=c.nStbBarrioID " & _
                     "  WHERE (a.sCodEstado = '2') " & _
                    " and c.Municipio = '" & cboMunicipio.Columns("Municipio").Value & "' " & _
                    " Order by a.nCodigo  "
            '                     " And (a.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") " & _
            XdtFicha.ExecuteSql(Strsql)

            'Asignando fuente de datos al Grid: ////////////////, c.CodMunicipio, c.Municipio
            Me.grdFicha.DataSource = XdtFicha.Source
            Me.grdFicha.Caption = " Listado de Fichas de Notificación de Crédito Aprobadas por Fondo (" + Me.grdFicha.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       FormatoFicha
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre la FNC en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoFicha()
        Try

            'Configuracion del Grid FNC
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("sCodEstado").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbPersonaLugarPagosID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False

            Me.grdFicha.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdFicha.Splits(0).DisplayColumns("EstadoFicha").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("CodigoGS").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGS").Width = 200
            Me.grdFicha.Splits(0).DisplayColumns("sNumSesion").Width = 80
            Me.grdFicha.Splits(0).DisplayColumns("dFechaNotificacion").Width = 130
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraEntregaCK").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("Fuente").Width = 200
            Me.grdFicha.Splits(0).DisplayColumns("sUsuarioCreacion").Width = 100

            Me.grdFicha.Columns("nCodigo").Caption = "Código"
            Me.grdFicha.Columns("CodigoGS").Caption = "Código Grupo"
            Me.grdFicha.Columns("sNombreGS").Caption = "Nombre Grupo Solidario"
            Me.grdFicha.Columns("sNumSesion").Caption = "No. Sesión"
            Me.grdFicha.Columns("dFechaNotificacion").Caption = "Fecha Resolución"
            Me.grdFicha.Columns("dFechaHoraEntregaCK").Caption = "Fecha Entrega CK"
            Me.grdFicha.Columns("EstadoFicha").Caption = "Estado Crédito"
            Me.grdFicha.Columns("Fuente").Caption = "Fuente de Fondos"
            Me.grdFicha.Columns("sUsuarioCreacion").Caption = "Elaborado Por"

            Me.grdFicha.Splits(0).DisplayColumns("CodigoGS").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdFicha.Splits(0).DisplayColumns("dFechaNotificacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraEntregaCK").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("Fuente").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdFicha.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("CodigoGS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumSesion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaNotificacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraEntregaCK").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("EstadoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("Fuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sUsuarioCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdFicha.Columns("dFechaNotificacion").NumberFormat = "dd/MM/yyyy hh:mm tt"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtFicha = New BOSistema.Win.XDataSet.xDataTable
            XdsLugarPagos = New BOSistema.Win.XDataSet
            XdsMunicipios = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdFicha.ClearFields()

            'Lugar de Pagos:
            Me.cboLugarPagosO.ClearFields()
            Me.cboLugarPagosD.ClearFields()
            Me.cboFuente.ClearFields()
            Me.cboMunicipio.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       LlamaTrasladarLugarPagos
    ' Descripción:          Traslada de Lugar de Pagos a Fichas de Notificación
    '                       de Crédito:
    '                       1. Que tengan el Estado Aprobada
    '                       2. Que pertenezcan al Lugar de Pagos Origen
    '                       3. Que tengan al menos una Ficha de Inscripción Activa
    '                          (diferente de Anulada y Cancelada).
    '-------------------------------------------------------------------------
    Private Sub LlamaTrasladarLugarPagos()
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim Strsql As String = ""

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor

            'Actualización Masiva de Lugar de Pagos:
            'Actualiza FNC entre rango de Códigos seleccionado:
            If cbTrasladoMunicipio.Checked = False Then
                If (IsNumeric(Me.mtbCodDesde.Text)) And (IsNumeric(Me.mtbCodHasta.Text)) Then
                    Strsql = " Update SclFichaNotificacionCredito " & _
                             " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nStbPersonaLugarPagosID = " & cboLugarPagosD.Columns("nStbPersonaID").Value & _
                             " WHERE (nStbPersonaLugarPagosID = " & cboLugarPagosO.Columns("nStbPersonaID").Value & ") " & _
                             " AND (nCodigo BETWEEN " & Me.mtbCodDesde.Text & " AND " & Me.mtbCodHasta.Text & ") " & _
                             " AND (nStbEstadoCreditoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoCredito')) " & _
                             " AND (nSclFichaNotificacionID IN (SELECT DFNC.nSclFichaNotificacionID " & _
                                                              " FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SclFichaSocia AS FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN StbValorCatalogo AS C ON FS.nStbEstadoFichaID = C.nStbValorCatalogoID " & _
                                                              " WHERE (C.sCodigoInterno <> '4') AND (C.sCodigoInterno <> '6')  AND (C.sCodigoInterno <> '7'))) " & _
                             " AND (nSclFichaNotificacionID IN (SELECT nSclFichaNotificacionID " & _
                                                              " FROM vwSccTrasladoLugarPagos " & _
                                                              " WHERE (nScnFuenteFinanciamientoID  = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ")))"

                Else 'Actualiza todas las FNC:

                    Strsql = " Update SclFichaNotificacionCredito " & _
                             " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nStbPersonaLugarPagosID = " & cboLugarPagosD.Columns("nStbPersonaID").Value & _
                             " WHERE (nStbPersonaLugarPagosID = " & cboLugarPagosO.Columns("nStbPersonaID").Value & ") " & _
                             " AND (nStbEstadoCreditoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoCredito')) " & _
                             " AND (nSclFichaNotificacionID IN (SELECT DFNC.nSclFichaNotificacionID " & _
                                                              " FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SclFichaSocia AS FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN StbValorCatalogo AS C ON FS.nStbEstadoFichaID = C.nStbValorCatalogoID " & _
                                                              " WHERE (C.sCodigoInterno <> '4') AND (C.sCodigoInterno <> '6') AND (C.sCodigoInterno <> '7'))) " & _
                             " AND (nSclFichaNotificacionID IN (SELECT nSclFichaNotificacionID " & _
                                                              " FROM vwSccTrasladoLugarPagos " & _
                                                              " WHERE (nScnFuenteFinanciamientoID  = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ")))"
                End If
                XcDatos.ExecuteNonQuery(Strsql)

                'Almacenar Auditoría:
                Call GuardarAuditoria(5, 15, "Modificación masiva de Lugar de Pagos de " & cboLugarPagosO.Text & " a " & cboLugarPagosD.Text & ". Fuente de Fondos: " & Me.cboFuente.Text & "")
                MsgBox("Lugar de Pagos fue actualizado Exitosamente.", MsgBoxStyle.Information, NombreSistema)

                'Refrescar Grid:

                CargarFicha()
            Else

                Strsql = " update " & _
                " dbo.SclFichaNotificacionCredito" & _
                " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate()," & _
                " nStbPersonaLugarPagosID = " & cboLugarPagosD.Columns("nStbPersonaID").Value & " " & _
                " WHERE        (nSclFichaNotificacionID IN  " & _
                 " ((SELECT        TOP (100) PERCENT SclFichaNotificacionCredito_1.nSclFichaNotificacionID " & _
                 " FROM            dbo.SclFichaNotificacionCredito AS SclFichaNotificacionCredito_1 INNER JOIN " & _
                                                         " dbo.StbValorCatalogo ON SclFichaNotificacionCredito_1.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                                                          " dbo.SclFichaNotificacionDetalle ON  " & _
                                                          " SclFichaNotificacionCredito_1.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN " & _
                                                         "  dbo.SteCaja ON SclFichaNotificacionCredito_1.nStbPersonaLugarPagosID = dbo.SteCaja.nStbPersonaLugarPagosID INNER JOIN " & _
                                                          " dbo.SclGrupoSolidario ON SclFichaNotificacionCredito_1.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN " & _
                                                         "  dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " & _
                                                         "  dbo.SclGrupoSocia ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID AND  " & _
                                                          " dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                                                          " dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo_1.nStbValorCatalogoID INNER JOIN " & _
                                                          " dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN " & _
                                                          " dbo.SclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID " & _
                                 " WHERE        (dbo.StbValorCatalogo.sCodigoInterno = '2') AND (StbValorCatalogo_1.sCodigoInterno = '5')  " & _
                                 " AND (dbo.SteCaja.nCerrada = 0)  " & _
                                  " AND (dbo.vwStbUbicacionGeografica.Municipio = '" & cboMunicipio.Columns("Municipio").Value & "' )))) "

                XcDatos.ExecuteNonQuery(Strsql)

                'Almacenar Auditoría:
                Call GuardarAuditoria(5, 15, "Modificación masiva de Lugar de Pagos de " & cboMunicipio.Text & " a " & cboLugarPagosD.Text & "")
                MsgBox("Lugar de Pagos fue actualizado Exitosamente.", MsgBoxStyle.Information, NombreSistema)

                'Refrescar Grid:
                CargarFicha2()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar la opción de Traslado.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            ' Trasladar Lugar Pagos:
            If Seg.HasPermission("TrasladarLugarPagosFNC") Then
                Me.CmdTrasladar.Enabled = True
            Else
                Me.CmdTrasladar.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       CargarLugarPagosO
    ' Descripción:          Este procedimiento permite cargar el listado de lugares
    '                       para pagos de cuotas.
    '-------------------------------------------------------------------------
    Private Sub CargarLugarPagosO(ByVal intPersonaID As Integer)
        Try
            Dim Strsql As String

            Me.cboLugarPagosO.ClearFields()

            If intPersonaID = 0 Then
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre " & _
                         " From vwStbPersona a " & _
                         " Where (a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') and (nPersonaActiva = 1) " & _
                         " Order by a.nCodPersona"
            Else
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre " & _
                         " From vwStbPersona a " & _
                         " Where ((a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') and (nPersonaActiva = 1)) " & _
                         " Or (a.nStbPersonaID = " & intPersonaID & ") " & _
                         " Order by a.nCodPersona"
            End If
            'and (nPersonaActiva = 1)
            If XdsLugarPagos.ExistTable("LugarPagos") Then
                XdsLugarPagos("LugarPagos").ExecuteSql(Strsql)
            Else
                XdsLugarPagos.NewTable(Strsql, "LugarPagos")
                XdsLugarPagos("LugarPagos").Retrieve()
            End If

            'Asignando a las fuentes de datos Lugar Pagos Origen:
            Me.cboLugarPagosO.DataSource = XdsLugarPagos("LugarPagos").Source
            Me.cboLugarPagosO.Rebind()
            Me.cboLugarPagosO.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            Me.cboLugarPagosO.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboLugarPagosO.Splits(0).DisplayColumns("nCodPersona").Width = 50
            Me.cboLugarPagosO.Splits(0).DisplayColumns("sNombre").Width = 150
            Me.cboLugarPagosO.Columns("nCodPersona").Caption = "Código"
            Me.cboLugarPagosO.Columns("sNombre").Caption = "Institución"
            Me.cboLugarPagosO.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboLugarPagosO.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/03/2010
    ' Procedure Name:       CargarFuente
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez_______________ Marvin Gomez
    ' Fecha:                12/02/2008      ________________ 26/7/2016
    ' Procedure Name:       CargarLugarPagosO
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intPersonaID As Integer)
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()

            'If intPersonaID = 0 Then
            Strsql = " SELECT StbMunicipio.nStbMunicipioID, " & _
                    " StbMunicipio.sNombre AS Municipio, " & _
                    " StbDepartamento.sNombre AS Departamento " & _
                    " FROM StbMunicipio INNER JOIN StbDepartamento " & _
                    " ON StbDepartamento.nStbDepartamentoID = StbMunicipio.nStbDepartamentoID "
            'Else
            '    Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre " & _
            '             " From vwStbPersona a " & _
            '             " Where ((a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') and (nPersonaActiva = 1)) " & _
            '             " Or (a.nStbPersonaID = " & intPersonaID & ") " & _
            '             " Order by a.nCodPersona"
            'End If
            'and (nPersonaActiva = 1)
            If XdsMunicipios.ExistTable("Municipios") Then
                XdsMunicipios("Municipios").ExecuteSql(Strsql)
            Else
                XdsMunicipios.NewTable(Strsql, "Municipios")
                XdsMunicipios("Municipios").Retrieve()
            End If

            'Asignando a las fuentes de datos Lugar Pagos Origen:
            Me.cboMunicipio.DataSource = XdsMunicipios("Municipios").Source
            Me.cboMunicipio.Rebind()
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            'Me.cboMunicipio.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.cboMunicipio.Splits(0).DisplayColumns("nCodPersona").Width = 50
            Me.cboMunicipio.Splits(0).DisplayColumns("Municipio").Width = 150
            Me.cboMunicipio.Splits(0).DisplayColumns("Departamento").Width = 150
            'Me.cboMunicipio.Columns("nCodPersona").Caption = "Código"
            'Me.cboMunicipio.Columns("sNombre").Caption = "Institución"
            'Me.cboMunicipio.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/03/2010
    ' Procedure Name:       CargarFuente
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarFuente(ByVal intFuenteID As Integer)
        Try
            Dim Strsql As String = ""

            '-- Temporal solo permitir seleccionar nueva Fuente de Fondos: BANDES, VENTANA, FONDOS PROPIOS
            If intFuenteID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) Or (a.nScnFuenteFinanciamientoID = " & intFuenteID & ") " & _
                         " Order by a.sCodigo"
            End If

            If XdsLugarPagos.ExistTable("Fuente") Then
                XdsLugarPagos("Fuente").ExecuteSql(Strsql)
            Else
                XdsLugarPagos.NewTable(Strsql, "Fuente")
                XdsLugarPagos("Fuente").Retrieve()
            End If

            Me.cboFuente.DataSource = XdsLugarPagos("Fuente").Source
            Me.cboFuente.Rebind()

            Me.cboFuente.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Width = 47
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboFuente.Columns("sCodigo").Caption = "Código"
            Me.cboFuente.Columns("sNombre").Caption = "Descripción"
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboFuente.ListCount > 0 Then
                'XdsLugarPagos("Fuente").AddRow()
                'XdsLugarPagos("Fuente").ValueField("sNombre") = "Todas"
                'XdsLugarPagos("Fuente").ValueField("nScnFuenteFinanciamientoID") = -19
                'XdsLugarPagos("Fuente").ValueField("Orden") = 0
                'XdsLugarPagos("Fuente").UpdateLocal()
                'XdsLugarPagos("Fuente").Sort = "Orden, sCodigo asc"
                Me.cboFuente.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       CargarLugarPagosD
    ' Descripción:          Este procedimiento permite cargar el listado de lugares
    '                       para para pagos de cuotas.
    '-------------------------------------------------------------------------
    Private Sub CargarLugarPagosD(ByVal intPersonaID As Integer)
        Try
            Dim Strsql As String
            Me.cboLugarPagosD.ClearFields()

            If intPersonaID = 0 Then
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre " & _
                         " From vwStbPersona a " & _
                         " Where (a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') and (nPersonaActiva = 1) " & _
                         " Order by a.nCodPersona"
            Else
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre " & _
                         " From vwStbPersona a " & _
                         " Where ((a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') and (nPersonaActiva = 1)) " & _
                         " Or (a.nStbPersonaID = " & intPersonaID & ") " & _
                         " Order by a.nCodPersona"
            End If

            If XdsLugarPagos.ExistTable("LugarPagosD") Then
                XdsLugarPagos("LugarPagosD").ExecuteSql(Strsql)
            Else
                XdsLugarPagos.NewTable(Strsql, "LugarPagosD")
                XdsLugarPagos("LugarPagosD").Retrieve()
            End If


            'Asignando a las fuentes de datos Lugar Pagos Destino:
            Me.cboLugarPagosD.DataSource = XdsLugarPagos("LugarPagosD").Source
            Me.cboLugarPagosD.Rebind()
            Me.cboLugarPagosD.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            Me.cboLugarPagosD.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboLugarPagosD.Splits(0).DisplayColumns("nCodPersona").Width = 50
            Me.cboLugarPagosD.Splits(0).DisplayColumns("sNombre").Width = 150
            Me.cboLugarPagosD.Columns("nCodPersona").Caption = "Código"
            Me.cboLugarPagosD.Columns("sNombre").Caption = "Institución"
            Me.cboLugarPagosD.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboLugarPagosD.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       cboLugarPagosO_TextChanged
    ' Descripción:          Este procedimiento permite refrescar el Grid.
    '-------------------------------------------------------------------------
    Private Sub cboLugarPagosO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLugarPagosO.TextChanged
        If Me.cboLugarPagosO.SelectedIndex <> -1 Then
            CargarFicha()
            FormatoFicha()
        End If
    End Sub


    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            CargarFicha2()
            FormatoFicha()
        End If
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/03/2010
    ' Procedure Name:       cboFuente_TextChanged
    ' Descripción:          Este procedimiento permite refrescar el Grid.
    '-------------------------------------------------------------------------
    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        If Me.cboFuente.SelectedIndex <> -1 Then
            CargarFicha()
            FormatoFicha()
        End If
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFicha_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdFicha.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       grdFicha_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdFicha_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFicha.Filter
        Try

            XdtFicha.FilterLocal(e.Condition)
            Me.grdFicha.Caption = " Listado de Fichas de Notificación de Crédito Aprobadas (" + Me.grdFicha.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       CmdTrasladar_Click
    ' Descripción:          Este evento permite validar el traslado de lugar
    '                       de pagos y llamar al procedimiento para efectuar
    '                       la modificación masiva.
    '-------------------------------------------------------------------------
    Private Sub CmdTrasladar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTrasladar.Click
        Try
            'Validaciones:
            Dim StrSql As String
            Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
            Dim xObligarConCajaLocal As Integer
            Dim XcDatos As New BOSistema.Win.XComando
            Dim nSteCajaID As Integer



            'No existen registros:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen Fichas de Notificación Aprobadas" _
                     & Chr(13) & "asociadas al Lugar de Pagos y Fondo seleccionado" _
                     & Chr(13) & "con Fichas de Verificación Activas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Debe indicar Fondo Origen y Destino:
            If cbTrasladoMunicipio.Checked = False Then
                If cboLugarPagosO.Text = "" Or cboLugarPagosD.Text = "" Then
                    MsgBox("Debe indicar lugar de pagos origen y destino.", MsgBoxStyle.Information)
                    cboLugarPagosD.Focus()
                    Exit Sub
                End If
            Else
                If Me.cboMunicipio.Text = "" Or cboLugarPagosD.Text = "" Then
                    MsgBox("Debe indicar lugar de pagos origen y destino.", MsgBoxStyle.Information)
                    cboLugarPagosD.Focus()
                    Exit Sub
                End If
            End If

            'Imposible si se indica el mismo Lugar de Pagos Origen y Destino:
            If cbTrasladoMunicipio.Checked = False Then
                If cboLugarPagosO.Columns("nStbPersonaID").Value = cboLugarPagosD.Columns("nStbPersonaID").Value Then
                    MsgBox("El lugar de Pagos Destino DEBE ser difente al Actual.", MsgBoxStyle.Information)
                    cboLugarPagosD.Focus()
                    Exit Sub
                End If
            End If
            'Si se indicó Código Desde Debe indicar Codigo Hasta:
            If (IsNumeric(Me.mtbCodDesde.Text)) And (Not IsNumeric(Me.mtbCodHasta.Text)) Then
                MsgBox("Debe indicar Código de Corte.", MsgBoxStyle.Information)
                mtbCodHasta.Focus()
                Exit Sub
            End If

            'Si se indicó Código Hasta DEBE indicar Codigo Desde:
            If (Not IsNumeric(Me.mtbCodDesde.Text)) And (IsNumeric(Me.mtbCodHasta.Text)) Then
                MsgBox("Debe indicar Código de Inicio.", MsgBoxStyle.Information)
                mtbCodDesde.Focus()
                Exit Sub
            End If

            'Si se indicó un rango de Códigos:
            If cbTrasladoMunicipio.Checked = False Then
                If (IsNumeric(Me.mtbCodDesde.Text)) And (IsNumeric(Me.mtbCodHasta.Text)) Then
                    '1. Código Hasta no DEBE ser inferior:
                    If CDbl(Me.mtbCodHasta.Text) < CDbl(Me.mtbCodDesde.Text) Then
                        MsgBox("El Código de Corte no debe ser inferior.", MsgBoxStyle.Information)
                        mtbCodHasta.Focus()
                        Exit Sub
                    End If
                    '2. Imposible si el rango de Códigos no esta dentro del Grid:
                    StrSql = " SELECT a.* " & _
                             " FROM vwSccFNCAprobadas AS a " & _
                             " WHERE (a.sCodEstado = '2') AND (a.nCodigo BETWEEN " & Me.mtbCodDesde.Text & " AND " & Me.mtbCodHasta.Text & ") " & _
                             " AND (a.nStbPersonaLugarPagosID = " & cboLugarPagosO.Columns("nStbPersonaID").Value & ")"
                    If RegistrosAsociados(StrSql) = False Then
                        MsgBox("No existen Fichas de Notificación Aprobadas" & Chr(13) & "dentro del rango de Códigos seleccionado.", MsgBoxStyle.Information)
                        mtbCodDesde.Focus()
                        Exit Sub
                    End If
                End If
            End If



            StrSql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 84)"
            xObligarConCajaLocal = XcDatos.ExecuteScalar(StrSql) 'Si es 1 entonces valida que la caja local este recepcionada y aplicada, sin generar el siguiente archivo de envio.


            'strSQL = " SELECT     NoEnvio, nSteCajaId, EstadoEnvio, SsgCuentaID, FechaGenera, AplicadoEnCentral  FROM         dbo.SttProcesarEnvioES WHERE     (nSteCajaId = " & IdSteCaja & ") AND (NoEnvio > 0) AND (AplicadoEnCentral = 0) "
            If xObligarConCajaLocal = 1 Then

                StrSql = "SELECT     nSteCajaID FROM         dbo.SteCaja WHERE     (nCerrada = 0) AND (nStbPersonaLugarPagosID = " & cboLugarPagosO.Columns("nStbPersonaID").Value & ")"
                XdtDatos.ExecuteSql(StrSql)
                If XdtDatos.Count > 0 Then
                    nSteCajaID = XdtDatos.ValueField("nSteCajaID")


                    StrSql = " SELECT     COUNT(nSteCajaIDLocal) AS TotalReg FROM         dbo.SttCentralFichaNotificacionCreditoEnviadas WHERE   (nActiva = 1) AND   (nSteCajaIDLocal = " & nSteCajaID & ") "

                    XdtDatos.ExecuteSql(StrSql)

                    If XdtDatos.Count > 0 Then
                        If XdtDatos.ValueField("TotalReg") > 0 Then
                            MsgBox("Existe un lote de Fichas del origen del Lugar de Pagos que no han sido Recibidas en la Central." & Chr(13) & " Recuerde hacer el traslado una vez aceptada la carga del lugar de pago de origen y antes de generar el siguiente envio.  ", MsgBoxStyle.Critical, "SMUSURA0")
                            Exit Sub
                        End If
                    End If



                End If


            End If




            'Confirmar Acción:
            If MsgBox("¿Desea Trasladar de Lugar de Pagos a" & Chr(13) & "las Ficha de Notificación indicadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                LlamaTrasladarLugarPagos()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub cbTrasladoMunicipio_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles cbTrasladoMunicipio.CheckedChanged
        If cbTrasladoMunicipio.Checked = True Then
            Me.LabelMunicipio.Visible = True
            Me.cboMunicipio.Visible = True

            Me.lblLugarO.Visible = False
            Me.cboLugarPagosO.Visible = False

            Me.lblFuente.Visible = False
            Me.cboFuente.Visible = False

            Me.lblDesde.Visible = False
            Me.mtbCodDesde.Visible = False

            Me.lblCodigoH.Visible = False
            Me.mtbCodHasta.Visible = False


        Else
            Me.LabelMunicipio.Visible = False
            Me.cboMunicipio.Visible = False

            Me.lblLugarO.Visible = True
            Me.cboLugarPagosO.Visible = True

            Me.lblFuente.Visible = True
            Me.cboFuente.Visible = True

            Me.lblDesde.Visible = False
            Me.mtbCodDesde.Visible = True

            Me.lblCodigoH.Visible = True
            Me.mtbCodHasta.Visible = True

        End If

    End Sub
End Class