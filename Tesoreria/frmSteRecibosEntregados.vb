' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                31/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteRecibosEntregados.vb
' Descripci�n:          Este formulario muestra Listado de Talonarios de Recibos 
'                       Entregados a Cajeros o Personal del Programa.
'-------------------------------------------------------------------------
Public Class frmSteRecibosEntregados

    '- Declaraci�n de Variables 
    Dim XdsRecibo As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    Dim IntDepartamentoId As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       frmSteRecibosEntregados_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosEntregados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsRecibo.Close()
            XdsRecibo = Nothing

            XdsUbicacion.Close()
            XdsUbicacion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	31/07/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar par�metros de Delegaci�n.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

            'Encuentra el Departamento de la Delegaci�n del Usuario que Accesa:
            Strsql = "SELECT StbMunicipio.nStbDepartamentoID FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID WHERE  (StbDelegacionPrograma.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntDepartamentoId = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       frmSteRecibosEntregados_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosEntregados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicaci�n.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))

            InicializaVariables()

            'Cargar Departamentos:
            XdsUbicacion = New BOSistema.Win.XDataSet
            Me.cboDepartamento.ClearFields()
            CargarDepartamento()

            CargarRecibos()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       CargarRecibos
    ' Descripci�n:          Este procedimiento permite cargar los datos de
    '                       Recibos Entregados en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibos()
        Try
            Dim Strsql As String
            '-- El Control de la Delegaci�n esta dado por el Departamento
            'si no tiene permisos de consulta fuera de su Delegaci�n
            'unicamente se carga el Departamento al cual pertenece la 
            'Cuenta del usuario
            Strsql = " Select a.nSteReciboEntregadoID, a.nSrhCajeroId, a.nStbDepartamentoID, a.nStbDelegacionProgramaID, " &
                     "        a.nCerrado, a.dFechaArqueo, a.Cajero, a.nCodigoDesde, a.nCodigoHasta, " &
                     "        a.IngresadoPor, a.IdTipoPrograma, a.TipoPrograma, a.PlazoPagos, a.nStbTipoPlazoPagosID, a.sObservaciones, a.nCodigoTalonario " &
                     ", CASE WHEN a.nStbMunicipioID IS NULL THEN 0 ELSE a.nStbMunicipioID END AS nStbMunicipioID" &
                     " From vwSteRecibosEntregados a " &
                     " WHERE (a.nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") and (a.dFechaArqueo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " &
                     " Order by a.dFechaArqueo, a.Cajero, a.nCodigoDesde"

            If XdsRecibo.ExistTable("Recibo") Then
                XdsRecibo("Recibo").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Recibo")
                XdsRecibo("Recibo").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdRecibos.DataSource = XdsRecibo("Recibo").Source
            'Actualizando el caption de los GRIDS:
            Me.grdRecibos.Caption = " Listado de Entregas de Recibos Oficiales de Caja (" + Me.grdRecibos.RowCount.ToString + " registros)"
            FormatoRecibo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       FormatoRecibo
    ' Descripci�n:          Este procedimiento permite configurar los datos
    '                       sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoRecibo()
        Try

            'Configuracion del Grid: 
            Me.grdRecibos.Splits(0).DisplayColumns("nSteReciboEntregadoID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nSrhCajeroId").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("IdTipoPrograma").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbTipoPlazoPagosID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoTalonario").Visible = False

            Me.grdRecibos.Splits(0).DisplayColumns("nCerrado").Width = 80
            Me.grdRecibos.Splits(0).DisplayColumns("dFechaArqueo").Width = 80
            Me.grdRecibos.Splits(0).DisplayColumns("Cajero").Width = 200
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoDesde").Width = 90
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoHasta").Width = 90
            Me.grdRecibos.Splits(0).DisplayColumns("IngresadoPor").Width = 100
            Me.grdRecibos.Splits(0).DisplayColumns("TipoPrograma").Width = 180
            Me.grdRecibos.Splits(0).DisplayColumns("PlazoPagos").Width = 100
            Me.grdRecibos.Splits(0).DisplayColumns("sObservaciones").Width = 200

            Me.grdRecibos.Columns("nCerrado").Caption = "Cerrado"
            Me.grdRecibos.Columns("dFechaArqueo").Caption = "Fecha Arqueo"
            Me.grdRecibos.Columns("Cajero").Caption = "Nombre Del Cajero"
            Me.grdRecibos.Columns("nCodigoDesde").Caption = "Recibo Desde"
            Me.grdRecibos.Columns("nCodigoHasta").Caption = "Recibo Hasta"
            Me.grdRecibos.Columns("IngresadoPor").Caption = "Ingresado Por"
            Me.grdRecibos.Columns("TipoPrograma").Caption = "Tipo de Programa"
            Me.grdRecibos.Columns("PlazoPagos").Caption = "Periodicidad Pagos"
            Me.grdRecibos.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdRecibos.Splits(0).DisplayColumns("dFechaArqueo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Columns("dFechaArqueo").NumberFormat = "dd/MM/yyyy"
            Me.grdRecibos.Splits(0).DisplayColumns("nCerrado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Columns("nCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdRecibos.Splits(0).DisplayColumns("nCerrado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("dFechaArqueo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("Cajero").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoDesde").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoHasta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("IngresadoPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("TipoPrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("PlazoPagos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       InicializaVariables
    ' Descripci�n:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra par�metros de Delegaci�n.
            EncuentraParametros()

            '-- Inicializa DataSet:
            XdsRecibo = New BOSistema.Win.XDataSet
            '-- Limpiar Grid, estructura y Datos:
            Me.grdRecibos.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       tbRecibo_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip.
    '-------------------------------------------------------------------------
    Private Sub tbRecibo_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbRecibo.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarRecibo()
            Case "toolModificar"
                LlamaModificarRecibo()
            Case "toolEliminar"
                LlamaEliminarRecibo()
            Case "toolCerrarEntrega"
                LlamaCerrarEntrega()
            Case "toolRevertirCierre"
                LlamaRevertirCierre()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte V�lidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte V�lidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                'M�ximo 31 d�as entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 d�as.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                InicializaVariables()
                CargarRecibos()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                13/08/2008
    ' Procedure Name:       LlamaRevertirCierre
    ' Descripci�n:          Este procedimiento permite Revertir Cierre de 
    '                       Entregas de Recibos si no estan asociados a un
    '                       Arqueo de Caja.
    '-------------------------------------------------------------------------
    Private Sub LlamaRevertirCierre()
        Dim XdtCerrarR As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String

        Try
            Dim intPosicion As Integer  'Posicion del registro seleccionado, ID de la Socia

            'Imposible cerrar si no hay registrados:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No existen registros.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Entrega se encuentra Abierta salir del Sub: 
            Strsql = "SELECT nSteReciboEntregadoID FROM SteReciboEntregado WHERE (nSteReciboEntregadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID") & ") AND (nCerrado = 0)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Entrega NO se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edici�n fuera de su Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Cerrar Entregas de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If


            If XdsRecibo("Recibo").ValueField("nStbMunicipioID") > 0 Then

                Strsql = " SELECT AR.nCodigo " &
                            " FROM SteArqueoCaja AS AC INNER JOIN SteArqueoRecibo AS AR ON AC.nSteArqueoCajaID = AR.nSteArqueoCajaID INNER JOIN StbValorCatalogo AS C ON AC.nStbEstadoArqueoID = C.nStbValorCatalogoID " &
                            " INNER JOIN SteCaja AS CA ON AC.nSteCajaID = CA.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS U ON CA.nStbBarrioID = U.nStbBarrioID " &
                         "WHERE (c.sCodigoInterno <> '3') AND  (AR.nCodigo between " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " and " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ") " &
                         " and (ca.nStbTipoProgramaID = " & XdsRecibo("Recibo").ValueField("IdTipoPrograma") & ") " & "And (ca.nStbTipoPlazoPagosID = " & XdsRecibo("Recibo").ValueField("nStbTipoPlazoPagosID") & ") " & " And (ar.nCodigoTalonario = " & XdsRecibo("Recibo").ValueField("nCodigoTalonario") & ") " &
                         "And (ar.nSccReciboOficialCajaID Is NULL) AND (U.nStbMunicipioID = " & XdsRecibo("Recibo").ValueField("nStbMunicipioID") & ")"

            Else


                'Imposible Si los recibos MANUALES estan asociados a algun arqueo para el Programa y Periodicidad de Pagos:
                Strsql = " SELECT AR.nCodigo " &
                     " FROM SteArqueoCaja AS AC INNER JOIN SteArqueoRecibo AS AR ON AC.nSteArqueoCajaID = AR.nSteArqueoCajaID INNER JOIN StbValorCatalogo AS C ON AC.nStbEstadoArqueoID = C.nStbValorCatalogoID " &
                     " INNER JOIN SteCaja AS CA ON AC.nSteCajaID = CA.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS U ON CA.nStbBarrioID = U.nStbBarrioID " &
                     " WHERE (C.sCodigoInterno <> '3') AND (U.nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") " &
                     " AND (AR.nCodigo between " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " and " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ") " &
                     " AND (C.sCodigoInterno <> '4') AND (CA.nStbTipoProgramaID = " & XdsRecibo("Recibo").ValueField("IdTipoPrograma") & ") " &
                     " AND (CA.nStbTipoPlazoPagosID = " & XdsRecibo("Recibo").ValueField("nStbTipoPlazoPagosID") & ") " &
                     " AND (AR.nCodigoTalonario = " & XdsRecibo("Recibo").ValueField("nCodigoTalonario") & ") " &
                     " AND (AR.nSccReciboOficialCajaID IS NULL)"

            End If
            If RegistrosAsociados(Strsql) Then
                    MsgBox("Existen recibos en el rango asociados a" & Chr(13) & "un Arqueo de Caja ACTIVO.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Revertir Cierre de Entrega:
                If MsgBox("�Est� seguro de Revertir el Cierre de la Entrega seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'No regresa datos (ExecuteSqlNotTable):
                GuardarAuditoriaTablas(20, 2, "Modificar SteReciboEntregado Revertir Cierre", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID"), InfoSistema.IDCuenta)
                XdtCerrarR.ExecuteSqlNotTable("Update SteReciboEntregado SET dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', nCerrado = 0 WHERE nSteReciboEntregadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID"))
                'Guardar posici�n actual de la selecci�n
                intPosicion = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID")
                'Refrescar Datos:
                CargarRecibos()
                'Ubicar la selecci�n en la posici�n original
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoID", intPosicion)
                Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position
                'Almacena pista de auditoria:
                Strsql = "Reversi�n de Cierre de Entrega de Recibos C�digos: " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " - " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ". Departamento: " & Me.cboDepartamento.Text & ". Cajero: " & XdsRecibo("Recibo").ValueField("Cajero") & "."
                Call GuardarAuditoria(5, 25, Strsql)
            End If

        Catch ex As Exception
            Control_Error(ex)
            'MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtCerrarR.Close()
            XdtCerrarR = Nothing
        End Try
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       LlamaCerrarEntrega
    ' Descripci�n:          Este procedimiento permite Cerrar Entrega.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrarEntrega()
        Dim XdtCerrar As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String

        Try
            Dim intPosicion As Integer  'Posicion del registro seleccionado, ID de la Socia

            'Imposible cerrar si no hay registrados:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No existen registros.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Entrega no se encuentra Abierta salir del Sub: 
            Strsql = "SELECT nSteReciboEntregadoID FROM SteReciboEntregado WHERE (nSteReciboEntregadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edici�n fuera de su Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Cerrar Entregas de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Cerrar Entrega:
            If MsgBox("�Est� seguro de Cerrar la Entrega seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'No regresa datos (ExecuteSqlNotTable):
                GuardarAuditoriaTablas(20, 2, "Modificar SteReciboEntregado Cerrar Entrega", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID"), InfoSistema.IDCuenta)

                XdtCerrar.ExecuteSqlNotTable("Update SteReciboEntregado SET dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', nCerrado = 1 WHERE nSteReciboEntregadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID"))

                'Guardar posici�n actual de la selecci�n
                intPosicion = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID")

                'Refrescar Datos:
                CargarRecibos()

                'Ubicar la selecci�n en la posici�n original
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoID", intPosicion)
                Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
            'MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtCerrar.Close()
            XdtCerrar = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Guti�rrez
    ' Date			    :	04/08/2008
    ' Procedure name	:	LlamaImprimir
    ' Description		:	Este procedimiento permite imprimir Listado de Recibos Entregados
    '                       para el Departamento seleccionado y para el rango de fechas de
    '                       corte indicadas por el Usuario. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaD.Value, "dd/MM/yyyy") & " Al " & Format(cdeFechaH.Value, "dd/MM/yyyy") & " '"
            frmVisor.NombreReporte = "RepSteTE21.rpt"
            frmVisor.Text = "Listado de Entregas de Recibos Oficiales de Caja"
            frmVisor.SQLQuery = " Select * From vwSteRecibosEntregados " & _
                                " Where (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") and (dFechaArqueo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                " Order by Departamento, Cajero, dFechaArqueo, nCodigoDesde"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboEntregado.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboEntregado
        Try
            ObjFrmSteEditRecibo.ModoFrm = "ADD"
            ObjFrmSteEditRecibo.IdDepartamento = cboDepartamento.Columns("nStbDepartamentoID").Value
            ObjFrmSteEditRecibo.sNombreDepartamento = cboDepartamento.Text
            ObjFrmSteEditRecibo.ShowDialog()

            If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                CargarRecibos()
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoID", ObjFrmSteEditRecibo.IdRecibo)
                Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditRecibo.Close()
            ObjFrmSteEditRecibo = Nothing
        End Try
    End Sub

    '''''' ------------------------------------------------------------------------
    '''''' Autor:                Liesel Cruz Contreras
    '''''' Fecha:                02/01/2018
    '''''' Procedure Name:       LlamaAgregarReciboExtraviado
    '''''' Descripci�n:          Este procedimiento permite llamar al formulario
    ''''''                       frmSteEditReciboExtraviado.
    ''''''-------------------------------------------------------------------------
    '''''Private Sub LlamaAgregarReciboExtraviado()
    '''''    Dim ObjFrmSteEditReciboExtraviado As New frmSteEditReciboExtraviado
    '''''    Try
    '''''        ObjFrmSteEditReciboExtraviado.ModoFrm = "ADD"
    '''''        ObjFrmSteEditReciboExtraviado.IdRecibo = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID")
    '''''        ObjFrmSteEditReciboExtraviado.ReciboDesde = XdsRecibo("Recibo").ValueField("nCodigoDesde")
    '''''        ObjFrmSteEditReciboExtraviado.ReciboHasta = XdsRecibo("Recibo").ValueField("nCodigoHasta")
    '''''        ObjFrmSteEditReciboExtraviado.IdDepartamento = XdsRecibo("Recibo").ValueField("nStbDepartamentoID")
    '''''        ObjFrmSteEditReciboExtraviado.IdMunicipio = XdsRecibo("Recibo").ValueField("nStbMunicipioID")
    '''''        ObjFrmSteEditReciboExtraviado.IdTipoPrograma = XdsRecibo("Recibo").ValueField("IdTipoPrograma")
    '''''        ObjFrmSteEditReciboExtraviado.IdTipoPlazo = XdsRecibo("Recibo").ValueField("nStbTipoPlazoPagosID")
    '''''        ObjFrmSteEditReciboExtraviado.IdCodTalonario = XdsRecibo("Recibo").ValueField("nCodigoTalonario")

    '''''        ObjFrmSteEditReciboExtraviado.ShowDialog()

    '''''        If ObjFrmSteEditReciboExtraviado.IdRecibo <> 0 Then
    '''''            CargarRecibos()
    '''''            XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoID", ObjFrmSteEditReciboExtraviado.IdRecibo)
    '''''            Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position
    '''''        End If

    '''''    Catch ex As Exception
    '''''        Control_Error(ex)
    '''''    Finally
    '''''        ObjFrmSteEditReciboExtraviado.Close()
    '''''        ObjFrmSteEditReciboExtraviado = Nothing
    '''''    End Try
    '''''End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboEntregado para Modificar un Recibo.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboEntregado
        Try

            Dim Strsql As String
            'Imposible si no existen registros:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edici�n fuera de su Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Entregas de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si la Entrega no se encuentra Abierta salir del Sub: 
            Strsql = "SELECT nSteReciboEntregadoID FROM SteReciboEntregado WHERE (nSteReciboEntregadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditRecibo.ModoFrm = "UPD"
            ObjFrmSteEditRecibo.IdDepartamento = XdsRecibo("Recibo").ValueField("nStbDepartamentoID")
            ObjFrmSteEditRecibo.sNombreDepartamento = cboDepartamento.Text
            ObjFrmSteEditRecibo.IdRecibo = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID")
            ObjFrmSteEditRecibo.ShowDialog()

            If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                InicializaVariables()
                CargarRecibos()
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoID", ObjFrmSteEditRecibo.IdRecibo)
                Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditRecibo.Close()
            ObjFrmSteEditRecibo = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       LlamaEliminarRecibo
    ' Descripci�n:          Este procedimiento permite eliminar un registro
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRecibo()
        Dim XdtRecibo As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String

            'Imposible si no existen Registros:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edici�n fuera de su Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Eliminar Entregas de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si la Entrega no se encuentra Abierta salir del Sub: 
            StrSql = "SELECT nSteReciboEntregadoID FROM SteReciboEntregado WHERE (nSteReciboEntregadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Eliminaci�n:
            If MsgBox("�Est� seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                GuardarAuditoriaTablas(20, 3, "Eliminar SteReciboEntregado", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID"), InfoSistema.IDCuenta)
                StrSql = "Eliminaci�n de Entrega de Recibos C�digos: " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " - " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ". Departamento: " & Me.cboDepartamento.Text & ". Cajero: " & XdsRecibo("Recibo").ValueField("Cajero") & "."
                XdtRecibo.ExecuteSqlNotTable("Delete From SteReciboEntregado where nSteReciboEntregadoID=" & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID"))
                CargarRecibos()
                MsgBox("El registro se elimin� satisfactoriamente.", MsgBoxStyle.Information)
                'Almacena pista de auditoria:
                Call GuardarAuditoria(3, 25, StrSql)
                Me.grdRecibos.Caption = "Listado de Entregas de Recibos Oficiales de Caja (" + Me.grdRecibos.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtRecibo.Close()
            XdtRecibo = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       LlamaCerrar
    ' Descripci�n:          Este procedimiento permite cerrar la opci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       LlamaAyuda
    ' Descripci�n:          Este procedimiento permite presentar la Ayuda en
    '                       L�nea al usuario. Actualmente en Construcci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       grdRecibos_DoubleClick
    ' Descripci�n:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Recibo, al hacer doble click sobre el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibos.DoubleClick
        Try
            If Seg.HasPermission("ModificarEntregaRecibo") Then
                LlamaModificarRecibo()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdRecibos_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdRecibos.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       grdRecibos_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdRecibos.Filter
        Try
            XdsRecibo("Recibo").FilterLocal(e.Condition)
            Me.grdRecibos.Caption = " Listado de Entregas de Recibos Oficiales de Caja (" + Me.grdRecibos.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       Seguridad
    ' Descripci�n:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Agregar:
            If Seg.HasPermission("AgregarEntregaRecibo") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar:
            If Seg.HasPermission("ModificarEntregaRecibo") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar:
            If Seg.HasPermission("EliminarEntregaRecibo") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Cerrar Entrega:
            If Seg.HasPermission("CerrarEntregaRecibo") Then
                Me.toolCerrarEntrega.Enabled = True
            Else
                Me.toolCerrarEntrega.Enabled = False
            End If

            'Revertir Cierre: 
            If Seg.HasPermission("RevertirCierreEntregaRecibo") Then
                Me.toolRevertirCierre.Enabled = True
            Else
                Me.toolRevertirCierre.Enabled = False
            End If

            'Imprimir:
            If Seg.HasPermission("ImprimirListadoRecibosEntregados") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                31/07/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripci�n:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selecci�n.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Try
            Dim Strsql As String

            'Si no tiene permisos de Edici�n fuera de su Delegaci�n:
            If IntPermiteConsultar = 1 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                         " Order by a.sCodigo"
            Else 'Solo Carga Departamento de la Delegaci�n del Usuario:
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " FROM (SELECT D.nStbDepartamentoID, D.sCodigo, D.sNombre FROM StbDepartamento AS D INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID INNER JOIN StbDelegacionPrograma AS DP ON M.nStbMunicipioID = DP.nStbMunicipioID " & _
                         " WHERE (DP.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") AND (D.nActivo = 1) AND (D.nPertenecePrograma = 1)) AS a " & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            'Ubicarse en el Departamento de su Delegaci�n:
            If XdsUbicacion("Departamento").Count > 0 Then
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", IntDepartamentoId)
            End If

            'Configurar el combo Departamento:
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDepartamento.Columns("sCodigo").Caption = "C�digo"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripci�n"
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboDepartamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        InicializaVariables()
        CargarRecibos()
    End Sub
End Class