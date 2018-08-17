Public Class frmSccEstadisticasINIDE


    Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
    Dim XdsEstadistica As BOSistema.Win.XDataSet
    Dim XdsConsulta As BOSistema.Win.XDataSet

    Dim sColor As String

    'Dim IntPermiteConsultar As Integer
    'Dim IntPermiteEditar As Integer

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property
    Private Sub tbEstadistica_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbEstadistica.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarEstadistica()
            Case "toolModificar"
                LlamaModificarEstadistica()
            Case "toolEliminar"
                LlamaEliminarEstadistica()
            Case "toolEnviarINIDE"
                LlamaEnviarEstadistica()
            Case "toolRevertirEnvioINIDE"
                LlamaRevertirEnvioEstadistica()
                'Case "toolAplicar"
                '    LlamaAplicarEnvioMinutaMHCP()
                'Case "toolRevertirErrorEnvio"
                '    LlamaRevertirErrorEnvioMinutaMHCP()
            Case "toolImprimirDesembolsos"
                LlamaImprimirEstadisticaDesembolsos()
            Case "toolImprimirRecuperaciones"
                LlamaImprimirEstadisticaRecuperaciones()

            Case "toolRefrescar"

                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
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
                'If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                '    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
                '    Me.cdeFechaD.Focus()
                '    Exit Sub
                'End If


                CargarEstadisticas()

            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
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

    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros de Delegación:


            '-- Inicializa DataSet:
            XdsEstadistica = New BOSistema.Win.XDataSet

            '-- Limpiar Grid, estructura y Datos:
            Me.grdEstadistica.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
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

    Private Sub LlamaImprimirEstadisticaDesembolsos()
        Dim frmVisor As New frmCRVisorReporte
        Dim StrSql As String
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            If Me.grdEstadistica.RowCount = 0 Then
                MsgBox("No Existen Registros Generados en la consulta.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            StrSql = "SELECT     dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
            "dbo.SttEstadisticasINIDE.nstbEstadoID, dbo.SttEstadisticasINIDE.nPreliminar, dbo.SttEstadisticasINIDE.nUsuarioCreacionID, " & _
                      "dbo.SttEstadisticasINIDE.dFechaCreacion, dbo.SttEstadisticasINIDE.nUsuarioModificacionID, dbo.SttEstadisticasINIDE.dFechaModificacion, " & _
                      "dbo.StbValorCatalogo.sDescripcion AS Estado, [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso,  " & _
                      "CASE WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso IS NULL  " & _
                      "THEN 'No puesto para enviar INIDE .Generando Informacion' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 1 THEN 'Listo para Enviar' " & _
                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 2 THEN 'En proceso de Envio' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       "= 3 THEN 'Envio completado' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 4 THEN 'Error Envio por Web' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       "= 5 THEN 'Error General' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 6 THEN 'Espera de respuesta INIDE por si error o aplicacion correcta' " & _
                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 7 THEN 'Anulado' END AS EstadoWebService,[SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
    "FROM         [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado RIGHT OUTER JOIN " & _
                      "dbo.SttEstadisticasINIDE INNER JOIN " & _
                      "dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID ON  " & _
                      "[SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nSttEstadisticasINIDEID = dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID " & _
    " WHERE  (dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID = " & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID") & ") "
            XdtDatos.ExecuteSql(StrSql)

            If XdtDatos.Count > 0 Then ''No se ha enviado a Web Service
                If (IsDBNull(XdtDatos.ValueField("nEstadoProceso"))) Then
                    frmVisor.Formulas("Parametros") = "' Estado(" & XdtDatos.ValueField("Estado") & ")'"
                    frmVisor.NombreReporte = "RepSccCC52A.rpt"
                    frmVisor.CRVReportes.SelectionFormula = " {vwSccEstadisticasINIDEDetalle.nSttEstadisticasINIDEID}=" & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                Else ''Ya esta en el Web Service
                    frmVisor.Formulas("Parametros") = "' Estado(" & XdtDatos.ValueField("EstadoWebService") & ")'"
                    frmVisor.NombreReporte = "RepSccCC53A.rpt"
                    frmVisor.CRVReportes.SelectionFormula = " {vwSccEstadisticasINIDEDetalleWebService.nSttEstadisticasINIDEID}=" & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                End If
            End If

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Text = "Reporte de desembolsos"

            frmVisor.Show()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaRevertirEnvioEstadistica()
        Dim StrSql As String
        Dim XdtEstadistica As New BOSistema.Win.XDataSet.xDataTable
        Dim XdsComando As New BOSistema.Win.XComando

        'Dim Trans As BOSistema.Win.Transact

        Try
            'Trans = Nothing
            If Me.grdEstadistica.RowCount = 0 Then
                MsgBox("No Existen Registros Generados en la consulta.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si no tiene el estado "En Proceso": 

            StrSql = "SELECT     dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
            "dbo.SttEstadisticasINIDE.nstbEstadoID, dbo.SttEstadisticasINIDE.nPreliminar, dbo.SttEstadisticasINIDE.nUsuarioCreacionID, " & _
                      "dbo.SttEstadisticasINIDE.dFechaCreacion, dbo.SttEstadisticasINIDE.nUsuarioModificacionID, dbo.SttEstadisticasINIDE.dFechaModificacion, " & _
                      "dbo.StbValorCatalogo.sDescripcion AS Estado, [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso,  " & _
                      "CASE WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso IS NULL  " & _
                      "THEN 'No puesto para enviar INIDE .Generando Informacion' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 1 THEN 'Listo para Enviar' " & _
                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 2 THEN 'En proceso de Envio' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       "= 3 THEN 'Envio completado' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 4 THEN 'Error Envio por Web' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       "= 5 THEN 'Error General' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 6 THEN 'Espera de respuesta INIDE por si error o aplicacion correcta' " & _
                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 7 THEN 'Anulado' END AS EstadoWebService " & _
"FROM         [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado RIGHT OUTER JOIN " & _
                      "dbo.SttEstadisticasINIDE INNER JOIN " & _
                      "dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID ON  " & _
                      "[SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nSttEstadisticasINIDEID = dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID " & _
" WHERE (CONVERT(Varchar(10), dbo.SttEstadisticasINIDE.dFechaInicio, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dbo.SttEstadisticasINIDE.dFechaInicio, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) " & _
" AND [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 1 AND (dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID = " & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID") & ") "



            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Estadistica en el Web Service no  no se encuentra En Estado Listo Para Enviar , no la puede dar por cancelada", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de dar por cancelado el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Trans = New BOSistema.Win.Transact
                'Trans.BeginTrans()
                'Eliminar del Detalle del Consolidado de Credito
                StrSql = " Update [SMCU0-WebService]..WscINIDEEnvioEncabezado Set nEstadoProceso=7 Where nsttEstadisticasINIDEID=" & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                XdsComando.Execute(StrSql)
                CargarEstadisticas()

                MsgBox("El registro se dio por cancelado satisfactoriamente.", MsgBoxStyle.Information)
                ''Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            XdsComando.Close()
            XdtEstadistica.Close()
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XdsComando.Close()
            XdtEstadistica.Close()
            'Trans = Nothing

        End Try

    End Sub
    Private Sub LlamaEnviarEstadistica()
        Dim StrSql As String
        Dim XdtEstadistica As New BOSistema.Win.XDataSet.xDataTable
        Dim XdsComando As New BOSistema.Win.XComando

        'Dim Trans As BOSistema.Win.Transact

        Try
            'Trans = Nothing
            If Me.grdEstadistica.RowCount = 0 Then
                MsgBox("No Existen Registros Generados en la consulta.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si no tiene el estado "En Proceso": 
            StrSql = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
                     " dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID FROM         dbo.SttEstadisticasINIDE INNER JOIN " & _
                     "     dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '1') AND (dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID = " & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID") & ") "

            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Estadistica Generada no se encuentra En Proceso, no la puede Enviar", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de poner para ser enviada a INIDE el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Trans = New BOSistema.Win.Transact
                'Trans.BeginTrans()
                'Eliminar del Detalle del Consolidado de Credito
                StrSql = " EXEC spSccGeneraEstadisticaINIDEPorPeriodoPasarWebService " & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                XdsComando.Execute(StrSql)
                CargarEstadisticas()

                MsgBox("Se pusieron listas para enviar a INIDE el registro de estadisticas seleccionado.", MsgBoxStyle.Information)
                ''Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            XdsComando.Close()
            XdtEstadistica.Close()
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XdsComando.Close()
            XdtEstadistica.Close()
            'Trans = Nothing

        End Try

    End Sub
    Private Sub LlamaEliminarEstadistica()
        Dim StrSql As String
        Dim XdtEstadistica As New BOSistema.Win.XDataSet.xDataTable
        Dim XdsComando As New BOSistema.Win.XComando

        'Dim Trans As BOSistema.Win.Transact

        Try
            'Trans = Nothing
            If Me.grdEstadistica.RowCount = 0 Then
                MsgBox("No Existen Registros Generados en la consulta.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si no tiene el estado "En Proceso": 
            StrSql = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
                     " dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID FROM         dbo.SttEstadisticasINIDE INNER JOIN " & _
                     "     dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '1') AND (dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID = " & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID") & ") "

            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Estadistica Generada no se encuentra En Proceso, no la puede eliminar", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Trans = New BOSistema.Win.Transact
                'Trans.BeginTrans()
                'Eliminar del Detalle del Consolidado de Credito
                StrSql = " Delete From SttEstadisticasINIDEDetalleSocias Where nsttEstadisticasINIDEID=" & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                XdsComando.Execute(StrSql)
                'Eliminar del Maestro del Consolidado de Credito
                StrSql = " Delete From SttEstadisticasINIDE Where nsttEstadisticasINIDEID=" & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                XdsComando.Execute(StrSql)

                CargarEstadisticas()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                ''Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            XdsComando.Close()
            XdtEstadistica.Close()
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XdsComando.Close()
            XdtEstadistica.Close()
            'Trans = Nothing

        End Try

    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       CargarMinuta
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       Minutas de Depósito en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarEstadisticas()
        Try
            Dim Strsql As String

            'Strsql = " SELECT     dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
            '         " dbo.SttEstadisticasINIDE.nstbEstadoID, dbo.SttEstadisticasINIDE.nPreliminar, dbo.SttEstadisticasINIDE.nUsuarioCreacionID, " & _
            '         " dbo.SttEstadisticasINIDE.dFechaCreacion, dbo.SttEstadisticasINIDE.nUsuarioModificacionID, dbo.SttEstadisticasINIDE.dFechaModificacion, " & _
            '         "  dbo.StbValorCatalogo.sDescripcion  As Estado FROM         dbo.SttEstadisticasINIDE INNER JOIN " & _
            '         " dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
            '         " WHERE (CONVERT(Varchar(10), dFechaInicio, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dFechaInicio, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) "


            Strsql = "SELECT     dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
                     "  dbo.SttEstadisticasINIDE.nstbEstadoID, dbo.SttEstadisticasINIDE.nPreliminar, dbo.SttEstadisticasINIDE.nUsuarioCreacionID, " & _
                     "  dbo.SttEstadisticasINIDE.dFechaCreacion, dbo.SttEstadisticasINIDE.nUsuarioModificacionID, dbo.SttEstadisticasINIDE.dFechaModificacion, " & _
                     " dbo.StbValorCatalogo.sDescripcion AS Estado, [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso, dbo.SsgCuenta.Login, " & _
                      " CASE WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso IS NULL " & _
                      " THEN 'No puesto para enviar INIDE .Generando Informacion' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 1 THEN 'Listo para Enviar' " & _
                       " WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 2 THEN 'En proceso de Envio' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       " = 3 THEN 'Envio completado' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 4 THEN 'Error Envio por Web' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       " = 5 THEN 'Error General' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 6 THEN 'Espera de respuesta INIDE por si error o aplicacion correcta' " & _
                       " WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 7 THEN 'Anulado' END AS EstadoWebService  " & _
            " FROM         dbo.SttEstadisticasINIDE INNER JOIN " & _
  "                    dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID LEFT OUTER JOIN " & _
   "                   dbo.SsgCuenta ON dbo.SttEstadisticasINIDE.nUsuarioCreacionID = dbo.SsgCuenta.SsgCuentaID LEFT OUTER JOIN " & _
    "                  [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado ON  " & _
     "                 dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID = [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nSttEstadisticasINIDEID " & _
" WHERE (CONVERT(Varchar(10), dbo.SttEstadisticasINIDE.dFechaInicio, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dbo.SttEstadisticasINIDE.dFechaInicio, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) "

            '            Strsql = "SELECT     dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
            '            "dbo.SttEstadisticasINIDE.nstbEstadoID, dbo.SttEstadisticasINIDE.nPreliminar, dbo.SttEstadisticasINIDE.nUsuarioCreacionID, " & _
            '                      "dbo.SttEstadisticasINIDE.dFechaCreacion, dbo.SttEstadisticasINIDE.nUsuarioModificacionID, dbo.SttEstadisticasINIDE.dFechaModificacion, " & _
            '                      "dbo.StbValorCatalogo.sDescripcion AS Estado, [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso,  " & _
            '                      "CASE WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso IS NULL  " & _
            '                      "THEN 'No puesto para enviar INIDE .Generando Informacion' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 1 THEN 'Listo para Enviar' " & _
            '                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 2 THEN 'En proceso de Envio' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
            '                       "= 3 THEN 'Envio completado' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 4 THEN 'Error Envio por Web' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
            '                       "= 5 THEN 'Error General' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 6 THEN 'Espera de respuesta INIDE por si error o aplicacion correcta' " & _
            '                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 7 THEN 'Anulado' END AS EstadoWebService " & _
            '"FROM         [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado RIGHT OUTER JOIN " & _
            '                      "dbo.SttEstadisticasINIDE INNER JOIN " & _
            '                      "dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID ON  " & _
            '                      "[SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nSttEstadisticasINIDEID = dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID " & _
            If XdsEstadistica.ExistTable("Estadisticas") Then
                XdsEstadistica("Estadisticas").ExecuteSql(Strsql)
            Else
                XdsEstadistica.NewTable(Strsql, "Estadisticas")
                XdsEstadistica("Estadisticas").Retrieve()
            End If


            'Asignando a las fuentes de datos: 
            Me.grdEstadistica.DataSource = XdsEstadistica("Estadisticas").Source

            'Actualizando el caption de los GRIDS:
            Me.grdEstadistica.Caption = " Listado de Estadisticas Para Envio al INIDE (" + Me.grdEstadistica.RowCount.ToString + " registros)"
            FormatoEstadisticas()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       FormatoMinuta
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Minutas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoEstadisticas()
        Try
            'Configuracion del Grid: 
            ''Me.grdEstadistica.Splits(0).DisplayColumns("nsttEstadisticasINIDEID").Visible = False
            Me.grdEstadistica.Splits(0).DisplayColumns("nstbEstadoID").Visible = False
            Me.grdEstadistica.Splits(0).DisplayColumns("nPreliminar").Visible = False
            Me.grdEstadistica.Splits(0).DisplayColumns("nUsuarioCreacionID").Visible = False
            Me.grdEstadistica.Splits(0).DisplayColumns("nUsuarioModificacionID").Visible = False
            Me.grdEstadistica.Splits(0).DisplayColumns("nEstadoProceso").Visible = False
            Me.grdEstadistica.Splits(0).DisplayColumns("nsttEstadisticasINIDEID").Visible = False
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaModificacion").Visible = False







            Me.grdEstadistica.Splits(0).DisplayColumns("Login").Width = 80
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaInicio").Width = 80
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaFin").Width = 80
            Me.grdEstadistica.Splits(0).DisplayColumns("Estado").Width = 120
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaCreacion").Width = 100
            'Me.grdEstadistica.Splits(0).DisplayColumns("dFechaModificacion").Width = 100
            Me.grdEstadistica.Splits(0).DisplayColumns("EstadoWebService").Width = 300

            
            Me.grdEstadistica.Columns("Login").Caption = "Creado Por"
            Me.grdEstadistica.Columns("nsttEstadisticasINIDEID").Caption = "Id "
            Me.grdEstadistica.Columns("dFechaInicio").Caption = "Fecha Inicial"
            Me.grdEstadistica.Columns("dFechaFin").Caption = "Fecha Final"
            Me.grdEstadistica.Columns("Estado").Caption = "Estado"
            Me.grdEstadistica.Columns("dFechaCreacion").Caption = "Fecha de Creación"
            Me.grdEstadistica.Columns("dFechaModificacion").Caption = "Fecha de Modificación"
            Me.grdEstadistica.Columns("EstadoWebService").Caption = "Estado del Servicio Web"

         

            
            Me.grdEstadistica.Splits(0).DisplayColumns("nsttEstadisticasINIDEID").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaInicio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaFin").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstadistica.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstadistica.Splits(0).DisplayColumns("dFechaModificacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstadistica.Splits(0).DisplayColumns("EstadoWebService").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaAgregarEstadistica()
        Dim ObjfrmSccEditEstadisticasINIDE As New frmSccEditEstadisticasINIDE
        Try
            ObjfrmSccEditEstadisticasINIDE.ModoFrm = "ADD"
            ObjfrmSccEditEstadisticasINIDE.sColorFrm = Me.sColor
            ObjfrmSccEditEstadisticasINIDE.ShowDialog()

            If ObjfrmSccEditEstadisticasINIDE.INIDEID <> 0 Then
                CargarEstadisticas()
                XdsEstadistica("Estadisticas").SetCurrentByID("nsttEstadisticasINIDEID", ObjfrmSccEditEstadisticasINIDE.INIDEID)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSccEditEstadisticasINIDE.Close()
            ObjfrmSccEditEstadisticasINIDE = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarEstadistica()
        Dim ObjfrmSccEditEstadisticasINIDE As New frmSccEditEstadisticasINIDE
        Try
            If Me.grdEstadistica.RowCount = 0 Then
                MsgBox("No Existen Registros Generados en la consulta.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjfrmSccEditEstadisticasINIDE.ModoFrm = "UPD"
            ObjfrmSccEditEstadisticasINIDE.sColorFrm = Me.sColor
            ObjfrmSccEditEstadisticasINIDE.INIDEID = XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
            ObjfrmSccEditEstadisticasINIDE.ShowDialog()

            If ObjfrmSccEditEstadisticasINIDE.INIDEID <> 0 Then
                CargarEstadisticas()
                XdsEstadistica("Estadisticas").SetCurrentByID("nsttEstadisticasINIDEID", ObjfrmSccEditEstadisticasINIDE.INIDEID)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSccEditEstadisticasINIDE.Close()
            ObjfrmSccEditEstadisticasINIDE = Nothing
        End Try
    End Sub

    Private Sub frmSccEstadisticasINIDE_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtTmpConsulta.Close()
            XdtTmpConsulta = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub frmSccEstadisticasINIDE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim ObjGUI As New GUI.ClsGUI
        Try
            
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            InicializaVariables()
            CargarEstadisticas()
            Seguridad()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try

    End Sub
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarRegistroINIDE") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarRegistroINIDE") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarRegistroINIDE") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Enviar Minuta a Hacienda:
            If Seg.HasPermission("EnviarRegistroINIDE") Then
                Me.toolEnviarINIDE.Enabled = True
            Else
                Me.toolEnviarINIDE.Enabled = False
            End If

            'Revertir Envio de Minuta a Hacienda:
            If Seg.HasPermission("RevertirEnvioRegistroINIDE") Then
                Me.toolRevertirEnvioINIDE.Enabled = True
            Else
                Me.toolRevertirEnvioINIDE.Enabled = False
            End If

            If Seg.HasPermission("ImprimirRegistroINIDE") Then
                Me.toolImprimirRecuperaciones.Enabled = True
                Me.toolImprimirDesembolsos.Enabled = True
            Else
                Me.toolImprimirRecuperaciones.Enabled = False
                Me.toolImprimirDesembolsos.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub grdEstadistica_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdEstadistica.Filter
        Try
            XdsEstadistica("Estadisticas").FilterLocal(e.Condition)
            Me.grdEstadistica.Caption = " Listado de Estadisticas Para Envio al INIDE (" + Me.grdEstadistica.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    

   


    
    Private Sub LlamaImprimirEstadisticaRecuperaciones()
        Dim frmVisor As New frmCRVisorReporte
        Dim StrSql As String
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            If Me.grdEstadistica.RowCount = 0 Then
                MsgBox("No Existen Registros Generados en la consulta.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            StrSql = "SELECT     dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID, dbo.SttEstadisticasINIDE.dFechaInicio, dbo.SttEstadisticasINIDE.dFechaFin, " & _
            "dbo.SttEstadisticasINIDE.nstbEstadoID, dbo.SttEstadisticasINIDE.nPreliminar, dbo.SttEstadisticasINIDE.nUsuarioCreacionID, " & _
                      "dbo.SttEstadisticasINIDE.dFechaCreacion, dbo.SttEstadisticasINIDE.nUsuarioModificacionID, dbo.SttEstadisticasINIDE.dFechaModificacion, " & _
                      "dbo.StbValorCatalogo.sDescripcion AS Estado, [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso,  " & _
                      "CASE WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso IS NULL  " & _
                      "THEN 'No puesto para enviar INIDE .Generando Informacion' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 1 THEN 'Listo para Enviar' " & _
                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 2 THEN 'En proceso de Envio' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       "= 3 THEN 'Envio completado' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 4 THEN 'Error Envio por Web' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
                       "= 5 THEN 'Error General' WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 6 THEN 'Espera de respuesta INIDE por si error o aplicacion correcta' " & _
                       "WHEN [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso = 7 THEN 'Anulado' END AS EstadoWebService,[SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nEstadoProceso " & _
    "FROM         [SMCU0-WebService].dbo.WScINIDEEnvioEncabezado RIGHT OUTER JOIN " & _
                      "dbo.SttEstadisticasINIDE INNER JOIN " & _
                      "dbo.StbValorCatalogo ON dbo.SttEstadisticasINIDE.nstbEstadoID = dbo.StbValorCatalogo.nStbValorCatalogoID ON  " & _
                      "[SMCU0-WebService].dbo.WScINIDEEnvioEncabezado.nSttEstadisticasINIDEID = dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID " & _
    " WHERE  (dbo.SttEstadisticasINIDE.nsttEstadisticasINIDEID = " & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID") & ") "
            XdtDatos.ExecuteSql(StrSql)

            If XdtDatos.Count > 0 Then ''No se ha enviado a Web Service
                If (IsDBNull(XdtDatos.ValueField("nEstadoProceso"))) Then
                    frmVisor.Formulas("Parametros") = "' Estado(" & XdtDatos.ValueField("Estado") & ")'"
                    frmVisor.NombreReporte = "RepSccCC52B.rpt"
                    frmVisor.CRVReportes.SelectionFormula = " {vwSccEstadisticasINIDEDetalle.nSttEstadisticasINIDEID}=" & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                Else ''Ya esta en el Web Service
                    frmVisor.Formulas("Parametros") = "' Estado(" & XdtDatos.ValueField("EstadoWebService") & ")'"
                    frmVisor.NombreReporte = "RepSccCC53B.rpt"
                    frmVisor.CRVReportes.SelectionFormula = " {vwSccEstadisticasINIDEDetalleWebService.nSttEstadisticasINIDEID}=" & XdsEstadistica("Estadisticas").ValueField("nsttEstadisticasINIDEID")
                End If
            End If

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.Text = "Reporte de Recuperaciones"
            frmVisor.Show()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub
End Class