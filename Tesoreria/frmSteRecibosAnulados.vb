' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                24/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteRecibosAnulados.vb
' Descripción:          Este formulario muestra Listado de Recibos Anulados
'                       y no registrados dentro de los Arqueos de Caja.
'-------------------------------------------------------------------------
Public Class frmSteRecibosAnulados

    '- Declaración de Variables 
    Dim XdsRecibo As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
    ' Procedure Name:       frmSteRecibosAnulados_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosAnulados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
    ' Procedure Name:       frmSteRecibosAnulados_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteRecibosAnulados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
    ' Procedure Name:       CargarRecibos
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibos()
        Try
            Dim Strsql As String
            Strsql = " Select a.nSteReciboAnuladoID, a.nSrhCajeroId, a.nStbDepartamentoID, " & _
                     "        a.nCodigo, a.dFechaRecibo, a.Departamento, a.Cajero, a.nStbTipoProgramaID, " & _
                     "        a.CodTipoPrograma, a.TipoPrograma, a.PlazoPagos, a.IngresadoPor, a.sObservaciones" & _
                     ", CASE WHEN a.nStbMunicipioID IS NULL THEN 0 ELSE a.nStbMunicipioID END AS nStbMunicipioID" & _
                     " From vwSteRecibosAnulados a " & _
                     " WHERE (a.nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") and (a.dFechaRecibo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.Departamento, a.nCodigo"
            If XdsRecibo.ExistTable("Recibo") Then
                XdsRecibo("Recibo").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Recibo")
                XdsRecibo("Recibo").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdRecibos.DataSource = XdsRecibo("Recibo").Source

            'Actualizando el caption de los GRIDS:
            Me.grdRecibos.Caption = " Listado de Recibos de Caja Anulados (" + Me.grdRecibos.RowCount.ToString + " registros)"
            FormatoRecibo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
    ' Procedure Name:       FormatoRecibo
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoRecibo()
        Try

            'Configuracion del Grid: 
            Me.grdRecibos.Splits(0).DisplayColumns("nSteReciboAnuladoID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nSrhCajeroId").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("nStbTipoProgramaID").Visible = False
            Me.grdRecibos.Splits(0).DisplayColumns("CodTipoPrograma").Visible = False

            Me.grdRecibos.Splits(0).DisplayColumns("nCodigo").Width = 80
            Me.grdRecibos.Splits(0).DisplayColumns("dFechaRecibo").Width = 80
            Me.grdRecibos.Splits(0).DisplayColumns("Departamento").Width = 120
            Me.grdRecibos.Splits(0).DisplayColumns("Cajero").Width = 180
            Me.grdRecibos.Splits(0).DisplayColumns("TipoPrograma").Width = 180
            Me.grdRecibos.Splits(0).DisplayColumns("PlazoPagos").Width = 100
            Me.grdRecibos.Splits(0).DisplayColumns("IngresadoPor").Width = 100
            Me.grdRecibos.Splits(0).DisplayColumns("sObservaciones").Width = 200

            Me.grdRecibos.Columns("nCodigo").Caption = "Número Recibo"
            Me.grdRecibos.Columns("dFechaRecibo").Caption = "Fecha Recibo"
            Me.grdRecibos.Columns("Departamento").Caption = "Departamento"
            Me.grdRecibos.Columns("Cajero").Caption = "Nombre Del Cajero"
            Me.grdRecibos.Columns("TipoPrograma").Caption = "Nombre Del Programa"
            Me.grdRecibos.Columns("PlazoPagos").Caption = "Periodicidad Pagos"
            Me.grdRecibos.Columns("IngresadoPor").Caption = "Ingresado Por"
            Me.grdRecibos.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdRecibos.Splits(0).DisplayColumns("dFechaRecibo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Columns("dFechaRecibo").NumberFormat = "dd/MM/yyyy"

            Me.grdRecibos.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("dFechaRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("Departamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("Cajero").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("TipoPrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("PlazoPagos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("IngresadoPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibos.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
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
    ' Fecha:                24/07/2008
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
            Case "toolEliminarRango"
                LlamaEliminarRangos()
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

                InicializaVariables()
                CargarRecibos()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	28/07/2008
    ' Procedure name	:	LlamaImprimir
    ' Description		:	Este procedimiento permite imprimir Listado de Recibos Anulados
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
            frmVisor.NombreReporte = "RepSteTE20.rpt"
            frmVisor.Text = "Listado de Recibos de Caja Anulados"
            frmVisor.SQLQuery = " Select * From vwSteRecibosAnulados " & _
                                " Where (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") and (dFechaRecibo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                " Order by Departamento, nCodigo, dFechaRecibo"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboAnulado.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboAnulado
        Try
            ObjFrmSteEditRecibo.ModoFrm = "ADD"
            ObjFrmSteEditRecibo.IdDepartamento = cboDepartamento.Columns("nStbDepartamentoID").Value

            ObjFrmSteEditRecibo.ShowDialog()

            If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                CargarRecibos()
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboAnuladoID", ObjFrmSteEditRecibo.IdRecibo)
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
    ' Fecha:                24/07/2008
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditReciboAnulado para Modificar un Recibo.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRecibo()
        Dim ObjFrmSteEditRecibo As New frmSteEditReciboAnulado
        Try
            Dim StrSql As String
            Dim StrSql1 As String
            'Imposible si no existen registros:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditRecibo.ModoFrm = "UPD"
            ObjFrmSteEditRecibo.IdDepartamento = XdsRecibo("Recibo").ValueField("nStbDepartamentoID")
            ObjFrmSteEditRecibo.IdRecibo = XdsRecibo("Recibo").ValueField("nSteReciboAnuladoID")
            ObjFrmSteEditRecibo.ShowDialog()

            If ObjFrmSteEditRecibo.IdRecibo <> 0 Then
                StrSql = "Modificación Recibo Anulado. Código: " & XdsRecibo("Recibo").ValueField("nCodigo") & ". Departamento: " & XdsRecibo("Recibo").ValueField("Departamento") & ". Fecha: " & XdsRecibo("Recibo").ValueField("dFechaRecibo") & ". Cajero: " & XdsRecibo("Recibo").ValueField("Cajero") & ". Por: "
                InicializaVariables()
                CargarRecibos()
                XdsRecibo("Recibo").SetCurrentByID("nSteReciboAnuladoID", ObjFrmSteEditRecibo.IdRecibo)
                Me.grdRecibos.Row = XdsRecibo("Recibo").BindingSource.Position
                'Almacena pista de auditoria: 
                StrSql1 = "Modificación Recibo Anulado. Código: " & XdsRecibo("Recibo").ValueField("nCodigo") & ". Departamento: " & XdsRecibo("Recibo").ValueField("Departamento") & ". Fecha: " & XdsRecibo("Recibo").ValueField("dFechaRecibo") & ". Cajero: " & XdsRecibo("Recibo").ValueField("Cajero") & ". Por: "
                If StrSql <> StrSql1 Then
                    StrSql = StrSql & " Código: " & XdsRecibo("Recibo").ValueField("nCodigo") & ". Departamento: " & XdsRecibo("Recibo").ValueField("Departamento") & ". Fecha: " & XdsRecibo("Recibo").ValueField("dFechaRecibo") & ". Cajero: " & XdsRecibo("Recibo").ValueField("Cajero") & "."
                    Call GuardarAuditoria(2, 25, StrSql)
                End If
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
    ' Fecha:                29/09/2008
    ' Procedure Name:       LlamaEliminarRangos
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Recibo existente dentro de un Rango.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRangos()
        Dim ObjFrmSteEditRecibos As New frmSteEditReciboAnulado
        Try

            'Si no existen registros:
            If Me.grdRecibos.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditRecibos.ModoFrm = "DEL"
            ObjFrmSteEditRecibos.IdDepartamento = XdsRecibo("Recibo").ValueField("nStbDepartamentoID")
            ObjFrmSteEditRecibos.IdRecibo = XdsRecibo("Recibo").ValueField("nSteReciboAnuladoID")
            ObjFrmSteEditRecibos.ShowDialog()

            'Refrescar:
            'InicializaVariables()
            CargarRecibos()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditRecibos.Close()
            ObjFrmSteEditRecibos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
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

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                GuardarAuditoriaTablas(19, 3, "Eliminar SteReciboAnulado", XdsRecibo("Recibo").ValueField("nSteReciboAnuladoID"), InfoSistema.IDCuenta)
                StrSql = "Eliminación de Recibo Anulado Código: " & XdsRecibo("Recibo").ValueField("nCodigo") & ". Departamento: " & XdsRecibo("Recibo").ValueField("Departamento") & "."
                XdtRecibo.ExecuteSqlNotTable("Delete From SteReciboAnulado where nSteReciboAnuladoID=" & XdsRecibo("Recibo").ValueField("nSteReciboAnuladoID"))
                CargarRecibos()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                'Almacena pista de auditoria:
                Call GuardarAuditoria(3, 25, StrSql)
                Me.grdRecibos.Caption = "Listado de Recibos de Caja Anulados (" + Me.grdRecibos.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtRecibo.Close()
            XdtRecibo = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
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
    ' Fecha:                24/07/2008
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
    ' Fecha:                24/07/2008
    ' Procedure Name:       grdRecibos_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Recibo, al hacer doble click sobre el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibos.DoubleClick
        Try
            If Seg.HasPermission("ModificarReciboAnulado") Then
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
    ' Fecha:                24/07/2008
    ' Procedure Name:       grdRecibos_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdRecibos_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdRecibos.Filter
        Try
            XdsRecibo("Recibo").FilterLocal(e.Condition)
            Me.grdRecibos.Caption = " Listado de Recibos de Caja Anulados (" + Me.grdRecibos.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/07/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'MantRecibosAnulados -frmMantRecibosAnulados:
            'Agregar
            If Seg.HasPermission("AgregarReciboAnulado") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarReciboAnulado") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarReciboAnulado") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarRangoRecibosAnulados") Then
                Me.toolEliminarRango.Enabled = True
            Else
                Me.toolEliminarRango.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirListadoRecibosAnulados") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/07/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                     " From StbDepartamento a " & _
                     " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                     " Order by a.sCodigo"

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            'Ubicarse en el primer registro
            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()
            If XdsUbicacion("Departamento").Count > 0 Then
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
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
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub cboDepartamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        InicializaVariables()
        CargarRecibos()
    End Sub
End Class