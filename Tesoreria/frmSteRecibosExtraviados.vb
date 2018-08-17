Public Class frmSteRecibosExtraviados
    '- Declaración de Variables 
    Dim XdsRecibo As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    Dim IntDepartamentoId As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       frmSteRecibosExtraviados_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosExtraviados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            XdsRecibo.Close()
            XdsRecibo = Nothing

            XdsUbicacion.Close()
            XdsUbicacion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       frmSteRecibosEntregados_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosExtraviados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            CargarRecibos()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
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
            'Cuenta del usuario
            Strsql = " Select a.nSteReciboExtraviadoID, a.nSrhCajeroId, a.nStbDepartamentoID, a.nStbDelegacionProgramaID, " &
                     "   a.nCerrado, a.dFechaArqueo, a.Cajero, a.nCodigoDesde, a.nCodigoHasta, " &
                     "        a.IngresadoPor, a.IdTipoPrograma, a.TipoPrograma, a.PlazoPagos, a.nStbTipoPlazoPagosID, a.sObservaciones, a.nCodigoTalonario " &
                     ", CASE WHEN a.nStbMunicipioID IS NULL THEN 0 ELSE a.nStbMunicipioID END AS nStbMunicipioID" &
                     " From vwSteRecibosExtraviados a " &
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       FormatoRecibo
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoRecibo()
        Try

            'Configuracion del Grid: 
            Me.grdRecibos.Splits(0).DisplayColumns("nSteReciboExtraviadoID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nSrhCajeroId").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("IdTipoPrograma").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbTipoPlazoPagosID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nCodigoTalonario").Visible = False

            Me.grdRecibos.Splits(0).DisplayColumns("ncerrado").Width = 80
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
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
    Private Sub tbRecibo_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbRecibo.ItemClicked
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

                'Máximo 31 días entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
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
            frmVisor.NombreReporte = "RepSteTE21B.rpt"
            frmVisor.Text = "Listado de Entregas de Recibos Extraviados"
            frmVisor.SQLQuery = " Select * From vwSteRecibosExtraviados " &
                                " Where (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") and (dFechaArqueo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " &
                                " Order by Departamento, Cajero, dFechaArqueo, nCodigoDesde"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboEntregado.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboExtraviado
        Try
            ObjFrmSteEditRecibo.ModoFrm = "ADD"
            ObjFrmSteEditRecibo.IdDepartamento = cboDepartamento.Columns("nStbDepartamentoID").Value
            ObjFrmSteEditRecibo.sNombreDepartamento = cboDepartamento.Text
            ObjFrmSteEditRecibo.ShowDialog()

            If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                CargarRecibos()
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboExtraviadoID", ObjFrmSteEditRecibo.IdRecibo)
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboEntregado para Modificar un Recibo.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboExtraviado
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

            'Si la Entrega no se encuentra Abierta salir del Sub: 
            Strsql = "SELECT nSteReciboExtraviadoID FROM SteReciboExtraviado WHERE (nSteReciboExtraviadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditRecibo.ModoFrm = "UPD"
            ObjFrmSteEditRecibo.IdDepartamento = XdsRecibo("Recibo").ValueField("nStbDepartamentoID")
            ObjFrmSteEditRecibo.sNombreDepartamento = cboDepartamento.Text
            ObjFrmSteEditRecibo.IdRecibo = XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID")
            ObjFrmSteEditRecibo.ShowDialog()

            If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                InicializaVariables()
                CargarRecibos()
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboExtraviadoID", ObjFrmSteEditRecibo.IdRecibo)
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       LlamaEliminarRecibo
    ' Descripción:          Este procedimiento permite eliminar un registro
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

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Eliminar Entregas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si la Entrega no se encuentra Abierta salir del Sub: 
            StrSql = "SELECT nSteReciboExtraviadoID FROM SteReciboExtraviado WHERE (nSteReciboExtraviadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID") & ") AND (nCerrado = 1)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Entrega se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                StrSql = "Eliminación de Entrega de Recibos Códigos: " & XdsRecibo("Recibo").ValueField("nCodigoDesde") & " - " & XdsRecibo("Recibo").ValueField("nCodigoHasta") & ". Departamento: " & Me.cboDepartamento.Text & ". Cajero: " & XdsRecibo("Recibo").ValueField("Cajero") & "."
                XdtRecibo.ExecuteSqlNotTable("Delete From SteReciboExtraviado where nSteReciboExtraviadoID=" & XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID"))
                CargarRecibos()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
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
            Strsql = "SELECT nSteReciboExtraviadoID FROM SteReciboExtraviado WHERE (nSteReciboExtraviadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID") & ") AND (nCerrado = 1)"
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
                'No regresa datos (ExecuteSqlNotTable):
                'GuardarAuditoriaTablas(20, 2, "Modificar SteReciboEntregado Cerrar Entrega", XdsRecibo("Recibo").ValueField("nSteReciboEntregadoID"), InfoSistema.IDCuenta)

                XdtCerrar.ExecuteSqlNotTable("Update SteReciboExtraviado SET dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', nCerrado = 1 WHERE nSteReciboExtraviadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID"))

                'Guardar posición actual de la selección
                intPosicion = XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID")

                'Refrescar Datos:
                CargarRecibos()

                'Ubicar la selección en la posición original
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboExtraviadoID", intPosicion)
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

    ' ------------------------------------------------------------------------
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Descripción:          Este procedimiento permite revertir el cierre.

    ' ------------------------------------------------------------------------
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
            Strsql = "SELECT nSteReciboExtraviadoID FROM SteReciboExtraviado WHERE (nSteReciboExtraviadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID") & ") AND (nCerrado = 0)"
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


            'Revertir Cierre de Entrega:
            If MsgBox("¿Está seguro de Revertir el Cierre de la Entrega seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                XdtCerrarR.ExecuteSqlNotTable("Update SteReciboExtraviado SET dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', nCerrado = 0 WHERE nSteReciboextraviadoID = " & XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID"))
                'Guardar posición actual de la selección
                intPosicion = XdsRecibo("Recibo").ValueField("nSteReciboExtraviadoID")
                'Refrescar Datos:
                CargarRecibos()
                'Ubicar la selección en la posición original
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboExtraviadoID", intPosicion)
                Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position


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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       grdRecibos_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Recibo, al hacer doble click sobre el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Seg.HasPermission("ModificarEntregaRecibo") Then
                LlamaModificarRecibo()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdRecibos_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs)
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       grdRecibos_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs)
        Try
            XdsRecibo("Recibo").FilterLocal(e.Condition)
            Me.grdRecibos.Caption = " Listado de Entregas de Recibos Oficiales de Caja (" + Me.grdRecibos.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Agregar:
            If Seg.HasPermission("AgregarRegistroRecibosExtraviados") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar:
            If Seg.HasPermission("ModificarRegistroDeRecibosExtraviados") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar:
            If Seg.HasPermission("EliminarRegistroDeRecibosExtraviados") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Cerrar Entrega
            If Seg.HasPermission("CerrarRegistroRecibosExtraviados") Then
                Me.toolCerrarEntrega.Enabled = True
            Else
                Me.toolCerrarEntrega.Enabled = False
            End If

            'Revertir Cierre
            If Seg.HasPermission("RevertirCierreDeRegistroDeRecibosExtraviados") Then
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
    ' Autor:                Liesel Cruz Contreras
    ' Fecha:                03/01/2018
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Try
            Dim Strsql As String

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteConsultar = 1 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " &
                         " From StbDepartamento a " &
                         " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " &
                         " Order by a.sCodigo"
            Else 'Solo Carga Departamento de la Delegación del Usuario:
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " &
                         " FROM (SELECT D.nStbDepartamentoID, D.sCodigo, D.sNombre FROM StbDepartamento AS D INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID INNER JOIN StbDelegacionPrograma AS DP ON M.nStbMunicipioID = DP.nStbMunicipioID " &
                         " WHERE (DP.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") AND (D.nActivo = 1) AND (D.nPertenecePrograma = 1)) AS a " &
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

    Private Sub cboDepartamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        InicializaVariables()
        CargarRecibos()
    End Sub


End Class