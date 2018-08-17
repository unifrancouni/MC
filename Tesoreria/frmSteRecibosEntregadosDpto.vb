' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                22/09/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteRecibosEntregadosDpto.vb
' Descripción:          Este formulario muestra Listado de Talonarios de Recibos 
'                       Entregados a departamentos del Programa.
'-------------------------------------------------------------------------
Public Class frmSteRecibosEntregadosDpto

    '- Declaración de Variables 
    Dim XdsRecibo As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    Dim IntDepartamentoId As Integer

    Dim StrTesorero As String
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez 
    ' Fecha:                22/09/2008 
    ' Procedure Name:       frmSteRecibosEntregadosDpto_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosEntregadosDpto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	22/09/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros de Delegación.
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

            'Encuentra el Departamento de la Delegación del Usuario que Accesa:
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       frmSteRecibosEntregadosDpto_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosEntregadosDpto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
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
            'Cargar Talonarios:
            CargarRecibos()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       CargarRecibos
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       Recibos Entregados en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibos()
        Try
            Dim Strsql As String
            '-- El Control de la Delegación esta dado por el Departamento
            'si no tiene permisos de consulta fuera de su Delegación
            'unicamente se carga el Departamento al cual pertenece la 
            'Cuenta del usuario:
            Strsql = " Select a.nSteReciboEntregadoDptoID, a.nSrhEmpleadoRecibeId, a.nStbDepartamentoID, a.nStbDelegacionProgramaID, " & _
                     "        a.nCerrado, a.dFechaEntrega, a.EmpleadoRecibe, a.nCodigoDesde, a.nCodigoHasta, " & _
                     "        a.IngresadoPor, a.IdTipoPrograma, a.TipoPrograma, a.PlazoPagos, a.sObservaciones, a.nStbTipoPlazoPagosID, a.nCodigoTalonario " & _
                     ", CASE WHEN a.nStbMunicipioID IS NULL THEN 0 ELSE a.nStbMunicipioID END AS nStbMunicipioID" & _
                     " From vwSteRecibosEntregadosDpto a " & _
                     " WHERE (a.nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") and (a.dFechaEntrega BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.dFechaEntrega, a.nCodigoDesde, a.EmpleadoRecibe"

            If XdsRecibo.ExistTable("Recibo") Then
                XdsRecibo("Recibo").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Recibo")
                XdsRecibo("Recibo").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdRecibos.DataSource = XdsRecibo("Recibo").Source
            'Actualizando el caption de los GRIDS:
            Me.grdRecibos.Caption = " Listado de Entregas Departamentales de Recibos Oficiales de Caja (" + Me.grdRecibos.RowCount.ToString + " registros)"
            FormatoRecibo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       FormatoRecibo
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoRecibo()
        Try

            'Configuracion del Grid: 
            Me.grdRecibos.Splits(0).DisplayColumns("nSteReciboEntregadoDptoID").Visible = True
            Me.grdRecibos.Splits(0).DisplayColumns("nSrhEmpleadoRecibeId").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("IdTipoPrograma").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbTipoPlazoPagosID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoTalonario").Visible = False

            Me.grdRecibos.Splits(0).DisplayColumns("nCerrado").Width = 80
            Me.grdRecibos.Splits(0).DisplayColumns("dFechaEntrega").Width = 80
            Me.grdRecibos.Splits(0).DisplayColumns("EmpleadoRecibe").Width = 200
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoDesde").Width = 90
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoHasta").Width = 90
            Me.grdRecibos.Splits(0).DisplayColumns("IngresadoPor").Width = 100
            Me.grdRecibos.Splits(0).DisplayColumns("TipoPrograma").Width = 170
            Me.grdRecibos.Splits(0).DisplayColumns("PlazoPagos").Width = 100
            Me.grdRecibos.Splits(0).DisplayColumns("sObservaciones").Width = 200

            Me.grdRecibos.Columns("nCerrado").Caption = "Cerrado"
            Me.grdRecibos.Columns("dFechaEntrega").Caption = "Fecha Entrega"
            Me.grdRecibos.Columns("EmpleadoRecibe").Caption = "Empleado Recibe"
            Me.grdRecibos.Columns("nCodigoDesde").Caption = "Recibo Desde"
            Me.grdRecibos.Columns("nCodigoHasta").Caption = "Recibo Hasta"
            Me.grdRecibos.Columns("IngresadoPor").Caption = "Ingresado Por"
            Me.grdRecibos.Columns("TipoPrograma").Caption = "Tipo de Programa"
            Me.grdRecibos.Columns("PlazoPagos").Caption = "Periodicidad Pagos"
            Me.grdRecibos.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdRecibos.Splits(0).DisplayColumns("dFechaEntrega").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Columns("dFechaEntrega").NumberFormat = "dd/MM/yyyy"
            Me.grdRecibos.Splits(0).DisplayColumns("nCerrado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Columns("nCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdRecibos.Splits(0).DisplayColumns("nCerrado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("dFechaEntrega").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("EmpleadoRecibe").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros de Delegación.
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       tbRecibo_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
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
            Case "toolAperturaTalonario"
                LlamaAperturaTalonario()
            Case "toolRevertirCierre"
                LlamaRevertirCierre()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolImprimirL"
                LlamaImprimirL()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                'Máximo 12 meses entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Month, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 11 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 12 meses.", MsgBoxStyle.Information)
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
    ' Autor:                Josué Herrera
    ' Fecha:                26/07/2012
    ' Procedure Name:       LlamaAperturaTalonario
    ' Descripción:          Este procedimiento permite aperturar
    '                       una entrega de Talonario a los departamentos
    '                       para editarlas
    '-------------------------------------------------------------------------
    Private Sub LlamaAperturaTalonario()
        Dim XdtApertura As New BOSistema.Win.XComando
        Try

            Dim sqlQuery As String = String.Format(" exec spSteAperturarTalonarioDelegacion {0}", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID"))
            GuardarAuditoriaTablas(21, 2, "Modificar SteReciboEntregadoDpto Aperturar Talonario", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID"), InfoSistema.IDCuenta)
            Dim result As Int32 = XdtApertura.ExecuteScalar(sqlQuery)
            Dim IdRecibo As Int32 = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID")

            InicializaVariables()
            CargarRecibos()
            XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoDptoID", IdRecibo)
            Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position

            If result = 1 Then
                MsgBox("Apertura de Talonario exitosa.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("No se pudo Aperturar el Talonario, intente nuevamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally

            XdtApertura.Close()
            XdtApertura = Nothing

        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       LlamaRevertirCierre
    ' Descripción:          Este procedimiento permite Revertir Cierre de 
    '                       Entregas de Recibos si no estan asociados a un
    '                       Arqueo de Caja.
    '-------------------------------------------------------------------------
    Private Sub LlamaRevertirCierre()
        Dim XdtCerrarR As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String

        Try
            Dim intPosicion As Integer  'Posicion del registro seleccionado, ID de la Socia
            Dim i As Integer
            'Imposible cerrar si no hay registrados:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No existen registros.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Entrega se encuentra Abierta salir del Sub: 
            Strsql = "SELECT nSteReciboEntregadoDptoID FROM SteReciboEntregadoDpto WHERE (nSteReciboEntregadoDptoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID") & ") AND (nCerrado = 0)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Entrega NO se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Cerrar Entregas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible Si los recibos estan asociados a algún Arqueo ACTIVO 
            'y que la caja sea del mismo Tipo de Programa y Periodicidad:
            Strsql = " SELECT AR.nCodigo " & _
                     " FROM SteArqueoCaja AS AC INNER JOIN SteArqueoRecibo AS AR ON AC.nSteArqueoCajaID = AR.nSteArqueoCajaID INNER JOIN StbValorCatalogo AS C ON AC.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
                     " INNER JOIN SteCaja AS CA ON AC.nSteCajaID = CA.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS U ON CA.nStbBarrioID = U.nStbBarrioID " & _
                     " WHERE (C.sCodigoInterno <> '3') AND (U.nStbDepartamentoID = " & XdsRecibo("Recibo").ValueField("nStbDepartamentoID") & ") " & _
                     " AND (AR.nCodigo between " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " and " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ") " & _
                     " AND (C.sCodigoInterno <> '4') AND (CA.nStbTipoProgramaID = " & XdsRecibo("Recibo").ValueField("IdTipoPrograma") & ") " & _
                     " AND (CA.nStbTipoPlazoPagosID = " & XdsRecibo("Recibo").ValueField("nStbTipoPlazoPagosID") & ") " & _
                     " AND (AR.nCodigoTalonario = " & XdsRecibo("Recibo").ValueField("nCodigoTalonario") & ") " & _
                     " AND (AR.nSccReciboOficialCajaID IS NULL)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen recibos en el rango asociados a" & Chr(13) & "un Arqueo de Caja ACTIVO.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si los Recibos estan asociados a algún Talonario asignado a un Cajero
            'Y del mismo Tipo de Programa y Periodicidad de la Entrega Departamental:
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            For i = XdsRecibo("Recibo").ValueField("nCodigoDesde") To XdsRecibo("Recibo").ValueField("nCodigoHasta")
                Strsql = " SELECT * FROM SteReciboEntregado " & _
                         " WHERE (nStbDepartamentoID = " & XdsRecibo("Recibo").ValueField("nStbDepartamentoID") & ") " & _
                         " AND (" & i & " BETWEEN nCodigoDesde AND nCodigoHasta) " & _
                         " AND (nStbTipoProgramaID = " & XdsRecibo("Recibo").ValueField("IdTipoPrograma") & ") " & _
                         " AND (nStbTipoPlazoPagosID = " & XdsRecibo("Recibo").ValueField("nStbTipoPlazoPagosID") & ") " & _
                         " AND (nCodigoTalonario = " & XdsRecibo("Recibo").ValueField("nCodigoTalonario") & ")"
                If RegistrosAsociados(Strsql) Then
                    MsgBox("Existen recibo(s) en el rango asociado(s) a un Cajero.", MsgBoxStyle.Information)
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                End If
            Next
            Me.Cursor = System.Windows.Forms.Cursors.Default

            'Revertir Cierre de Entrega:
            If MsgBox("¿Está seguro de Revertir el Cierre de la Entrega seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'No regresa datos (ExecuteSqlNotTable):

                GuardarAuditoriaTablas(21, 2, "Modificar SteReciboEntregadoDpto Revertir Cierre", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID"), InfoSistema.IDCuenta)
                XdtCerrarR.ExecuteSqlNotTable("Update SteReciboEntregadoDpto SET dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', nCerrado = 0 WHERE nSteReciboEntregadoDptoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID"))
                'Guardar posición actual de la selección
                intPosicion = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID")
                'Refrescar Datos:
                CargarRecibos()
                'Ubicar la selección en la posición original
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoDptoID", intPosicion)
                Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position
                'Almacena pista de auditoria:
                Strsql = "Reversión de Cierre de Entrega Departamental de Recibos Códigos: " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " - " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ". Departamento: " & Me.cboDepartamento.Text & ". Empleado Recibe: " & XdsRecibo("Recibo").ValueField("EmpleadoRecibe") & "."
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       LlamaCerrarEntrega
    ' Descripción:          Este procedimiento permite Cerrar Entrega.
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
            Strsql = "SELECT nSteReciboEntregadoDptoID FROM SteReciboEntregadoDpto WHERE (nSteReciboEntregadoDptoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Cerrar Entregas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Cerrar Entrega:
            If MsgBox("¿Está seguro de Cerrar la Entrega seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                GuardarAuditoriaTablas(21, 2, "Modificar SteReciboEntregadoDpto Cerrar Entrega", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID"), InfoSistema.IDCuenta)
                'No regresa datos (ExecuteSqlNotTable):
                XdtCerrar.ExecuteSqlNotTable("Update SteReciboEntregadoDpto SET dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', nCerrado = 1 WHERE nSteReciboEntregadoDptoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID"))

                'Guardar posición actual de la selección
                intPosicion = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID")

                'Refrescar Datos:
                CargarRecibos()

                'Ubicar la selección en la posición original
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoDptoID", intPosicion)
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
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	08/10/2008
    ' Procedure name		   	:	EncuentraParametrosFirmas
    ' Description			   	:	Encontrar parámetros de Tesorero y Delegada.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametrosFirmas()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            ''Delegada Departamental:
            'Strsql = "SELECT 'Lic. ' + dbo.vwStbEmpleado.sNombre AS Delegada FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
            '         "INNER JOIN vwStbEmpleado ON StbDelegacionPrograma.nSrhEmpleadoNotificaSociasID = vwStbEmpleado.nSrhEmpleadoID WHERE (StbMunicipio.nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
            'StrDelegada = XcDatos.ExecuteScalar(Strsql)
            'Tesorero:
            Strsql = "SELECT vwStbEmpleado.sTitulo + '. ' + vwStbEmpleado.sNombre AS Nombre FROM StbValorParametro INNER JOIN vwStbEmpleado ON StbValorParametro.sValorParametro = vwStbEmpleado.nSrhEmpleadoID WHERE (StbValorParametro.nStbValorParametroID = 34)"
            StrTesorero = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	23/09/2008
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
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(CDate(cdeFechaD.Text), "dd/MM/yyyy") & " Al " & Format(CDate(cdeFechaH.Text), "dd/MM/yyyy") & " '"
            EncuentraParametrosFirmas()
            frmVisor.Formulas("Tesorero") = "'" & StrTesorero & "'"
            frmVisor.NombreReporte = "RepSteTE25.rpt"
            frmVisor.Text = "Listado de Entregas de Recibos Oficiales de Caja a Departamentos"
            frmVisor.SQLQuery = " Select * From vwSteListadoTalonariosEntregadosDpto " & _
                                " Where (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") and (dFechaEntrega BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                " Order by Departamento, EmpleadoRecibe, dFechaEntrega, nCodigo"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	02/10/2008
    ' Procedure name	:	LlamaImprimirL
    ' Description		:	Este procedimiento permite imprimir Listado de Recibos Entregados
    '                       a Delegaciones NO asignados a Cajeros para el rango actualmente
    '                       seleccionado. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimirL()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE26.rpt"
            frmVisor.Text = "Recibos Entregados a Delegaciones No asignados a Cajeros"
            frmVisor.Parametros("@nStbDepartamentoId") = Me.cboDepartamento.Columns("nStbDepartamentoID").Value
            frmVisor.Parametros("@RangoInicial") = XdsRecibo("Recibo").ValueField("nCodigoDesde")
            frmVisor.Parametros("@RangoFinal") = XdsRecibo("Recibo").ValueField("nCodigoHasta")
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboEntregadoDpto.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboEntregadoDpto
        Try
            Dim StrSql As String

            'Imposible si no hay Delegacion creada para el Dpto:
            StrSql = "SELECT StbMunicipio.nStbDepartamentoID " & _
                     "FROM StbMunicipio INNER JOIN StbDelegacionPrograma ON StbMunicipio.nStbMunicipioID = StbDelegacionPrograma.nStbMunicipioID " & _
                     "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No Existe Delegación del Programa creada para el Departamento.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditRecibo.ModoFrm = "ADD"
            ObjFrmSteEditRecibo.IdDepartamento = cboDepartamento.Columns("nStbDepartamentoID").Value
            ObjFrmSteEditRecibo.sNombreDepartamento = cboDepartamento.Text

            ObjFrmSteEditRecibo.ShowDialog()

                If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                    CargarRecibos()
                    XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoDptoID", ObjFrmSteEditRecibo.IdRecibo)
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboEntregadoDpto para Modificar un Recibo.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboEntregadoDpto
        Try

            Dim Strsql As String
            'Imposible si no existen registros:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Entregas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If



            'Si la Entrega NO se encuentra Abierta salir del Sub: 
            Strsql = "SELECT nSteReciboEntregadoDptoID FROM SteReciboEntregadoDpto WHERE (nSteReciboEntregadoDptoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If
        


            ObjFrmSteEditRecibo.ModoFrm = "UPD"
            ObjFrmSteEditRecibo.IdDepartamento = XdsRecibo("Recibo").ValueField("nStbDepartamentoID")
            ObjFrmSteEditRecibo.sNombreDepartamento = cboDepartamento.Text
            ObjFrmSteEditRecibo.IdRecibo = XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID")

            If XdsRecibo("Recibo").ValueField("nStbMunicipioID") > 0 Then
                ObjFrmSteEditRecibo.IdMunicipio = (XdsRecibo("Recibo").ValueField("nStbMunicipioID")).ToString

            End If
            ObjFrmSteEditRecibo.ShowDialog()

            If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                InicializaVariables()
                CargarRecibos()
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboEntregadoDptoID", ObjFrmSteEditRecibo.IdRecibo)
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       LlamaEliminarRecibo
    ' Descripción:          Este procedimiento permite eliminar un registro
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRecibo()
        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing
        Try
            Dim StrSql As String
            Dim StrSqlE As String

            'Imposible si no existen Registros:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Eliminar Entregas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si la Entrega no se encuentra Abierta salir del Sub: 
            StrSql = "SELECT nSteReciboEntregadoDptoID FROM SteReciboEntregadoDpto WHERE (nSteReciboEntregadoDptoID = " & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                GuardarAuditoriaTablas(21, 3, "Eliminar SteReciboEntregadoDpto", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID"), InfoSistema.IDCuenta)
                'Instanciar Trans:
                Trans = New BOSistema.Win.Transact
                'Inicio la Transaccion:
                Trans.BeginTrans()

                StrSql = "Eliminación de Entrega Departamental de Recibos Códigos: " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " - " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ". Departamento: " & Me.cboDepartamento.Text & ". Empleado Recibe: " & XdsRecibo("Recibo").ValueField("EmpleadoRecibe") & "."
                '1. Elimina Detalles de Recibos:
                StrSqlE = "Delete From SteReciboEntregadoDptoDetalle where nSteReciboEntregadoDptoID=" & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID")
                Trans.ExecuteSql(StrSqlE)
                '2. Elimina Encabezado:
                StrSqlE = "Delete From SteReciboEntregadoDpto where nSteReciboEntregadoDptoID=" & XdsRecibo("Recibo").ValueField("nSteReciboEntregadoDptoID")
                Trans.ExecuteSql(StrSqlE)
                'Finaliza Transacción:
                Trans.Commit()

                CargarRecibos()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                'Almacena pista de auditoria:
                Call GuardarAuditoria(3, 25, StrSql)
                Me.grdRecibos.Caption = "Listado de Entregas Departamentales de Recibos Oficiales de Caja (" + Me.grdRecibos.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Trans.RollBack()
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            Trans = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       grdRecibos_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Recibo, al hacer doble click sobre el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibos.DoubleClick
        Try
            If Seg.HasPermission("ModificarEntregaReciboDpto") Then
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       grdRecibos_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdRecibos.Filter
        Try
            XdsRecibo("Recibo").FilterLocal(e.Condition)
            Me.grdRecibos.Caption = " Listado de Entregas Departamentales de Recibos Oficiales de Caja (" + Me.grdRecibos.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Pantalla Principal: MantEntregaDeRecibosDpto - frmMantEntregaDeRecibosDpto
            'Agregar:
            If Seg.HasPermission("AgregarEntregaReciboDpto") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar:
            If Seg.HasPermission("ModificarEntregaReciboDpto") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar: 
            If Seg.HasPermission("EliminarEntregaReciboDpto") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Cerrar Entrega: 
            If Seg.HasPermission("CerrarEntregaReciboDpto") Then
                Me.toolCerrarEntrega.Enabled = True
            Else
                Me.toolCerrarEntrega.Enabled = False
            End If

            'Revertir Cierre: 
            If Seg.HasPermission("RevertirCierreEntregaReciboDpto") Then
                Me.toolRevertirCierre.Enabled = True
            Else
                Me.toolRevertirCierre.Enabled = False
            End If

            'Imprimir Listado de Recibos Entregados a los Departamentos:
            If Seg.HasPermission("ImprimirRecibosEntregadosDptoTE25") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

            'Imprimir Recibos Entregados a Delegaciones NO asignados a Cajeros:
            If Seg.HasPermission("ImprimirRecibosEntregadosDptoNoAsignadosTE26") Then
                Me.toolImprimirL.Enabled = True
            Else
                Me.toolImprimirL.Enabled = False
            End If

            'Aperturar Talonario Delegaciones:
            If Seg.HasPermission("AperturaTalonarioDelegacion") Then
                Me.toolAperturaTalonario.Enabled = True
            Else
                Me.toolAperturaTalonario.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/09/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Try
            Dim Strsql As String

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteConsultar = 1 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                         " Order by a.sCodigo"
            Else 'Solo Carga Departamento de la Delegación del Usuario:
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

            'Ubicarse en el Departamento de su Delegación:
            If XdsUbicacion("Departamento").Count > 0 Then
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", IntDepartamentoId)
            End If

            'Configurar el combo Departamento:
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"
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