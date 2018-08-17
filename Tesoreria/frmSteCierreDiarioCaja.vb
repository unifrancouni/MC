' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                13/11/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteCierreDiarioCaja.vb
' Descripción:          Este formulario muestra Cierres Diarios de Cajas
'                       del Programa.
'-------------------------------------------------------------------------
Public Class frmSteCierreDiarioCaja

    '- Declaración de Variables 
    Dim XdsCierre As BOSistema.Win.XDataSet
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       frmSteCierreDiarioCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteCierreDiarioCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsCierre.Close()
            XdsCierre = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       frmSteCierreDiarioCaja_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteCierreDiarioCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            CargarCierre()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	13/11/2008
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

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       CargarCierre
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       Cierres Diarios de Caja en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCierre()
        Try
            Dim Strsql As String
            Strsql = " Select a.nSteCierreDiarioCajaID, a.nSteCajaID, a.nCerrada, a.nCodigo, " & _
                     "        a.sDescripcionCaja, a.dFechaCierre, a.Login, a.sObservaciones, a.nStbDelegacionProgramaID " & _
                     " From vwSteCierreDiarioCaja a " & _
                     " WHERE (a.dFechaCierre BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.dFechaCierre, a.nCodigo"
            If XdsCierre.ExistTable("Cierre") Then
                XdsCierre("Cierre").ExecuteSql(Strsql)
            Else
                XdsCierre.NewTable(Strsql, "Cierre")
                XdsCierre("Cierre").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdCierre.DataSource = XdsCierre("Cierre").Source

            'Actualizando el caption de los GRIDS:
            Me.grdCierre.Caption = " Listado de Cierres Diarios de Caja (" + Me.grdCierre.RowCount.ToString + " registros)"
            FormatoCierre()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       FormatoCierre
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Cierres en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCierre()
        Try

            'Configuracion del Grid: 
            Me.grdCierre.Splits(0).DisplayColumns("nSteCierreDiarioCajaID").Visible = False
            Me.grdCierre.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.grdCierre.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdCierre.Splits(0).DisplayColumns("nCerrada").Width = 60
            Me.grdCierre.Splits(0).DisplayColumns("nCodigo").Width = 70
            Me.grdCierre.Splits(0).DisplayColumns("sDescripcionCaja").Width = 200
            Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").Width = 120
            Me.grdCierre.Splits(0).DisplayColumns("Login").Width = 100
            Me.grdCierre.Splits(0).DisplayColumns("sObservaciones").Width = 250

            Me.grdCierre.Columns("nCerrada").Caption = "Cerrada"
            Me.grdCierre.Columns("nCodigo").Caption = "Código Caja"
            Me.grdCierre.Columns("sDescripcionCaja").Caption = "Descripción Caja"
            Me.grdCierre.Columns("dFechaCierre").Caption = "Fecha Cierre"
            Me.grdCierre.Columns("Login").Caption = "Ingresado Por"
            Me.grdCierre.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Columns("dFechaCierre").NumberFormat = "dd/MM/yyyy"

            Me.grdCierre.Columns("nCerrada").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdCierre.Splits(0).DisplayColumns("nCerrada").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCierre.Splits(0).DisplayColumns("nCerrada").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Inicializa DataSet:
            XdsCierre = New BOSistema.Win.XDataSet

            '-- Limpiar Grid, estructura y Datos:
            Me.grdCierre.ClearFields()

            '-- Encuentra parámetros de Delegación.
            EncuentraParametros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       tbCierre_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip.
    '-------------------------------------------------------------------------
    Private Sub tbCierre_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCierre.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCierre()
            Case "toolModificar"
                LlamaModificarCierre()
            Case "toolRevertir"
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
                CargarCierre()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	13/11/2008
    ' Procedure name	:	LlamaImprimir
    ' Description		:	Este procedimiento permite imprimir Listado de Cierres Diarios 
    '                       de Caja para el rango de fechas de corte indicadas por el Usuario. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            'Imposible si no existen registros en Grid:
            If Me.grdCierre.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

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

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(CDate(cdeFechaD.Text), "dd/MM/yyyy") & " Al " & Format(CDate(cdeFechaH.Text), "dd/MM/yyyy") & " '"
            frmVisor.NombreReporte = "RepSteTE28.rpt"
            frmVisor.Text = "Listado de Cierres Diarios de Caja"
            frmVisor.SQLQuery = " Select * From vwSteCierreDiarioCaja " & _
                                " WHERE (dFechaCierre BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                " Order by nCodigo, dFechaCierre"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       LlamaAgregarCierre
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCierreDiarioCaja.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCierre()
        Dim ObjFrmSteEditCierre As New frmSteEditCierreDiarioCaja
        Try
            ObjFrmSteEditCierre.ModoFrm = "ADD"
            ObjFrmSteEditCierre.IntPermiteEditar = Me.IntPermiteEditar
            ObjFrmSteEditCierre.ShowDialog()

            If ObjFrmSteEditCierre.IdCierre <> 0 Then
                CargarCierre()
                XdsCierre("Cierre").SetCurrentByID("nSteCierreDiarioCajaID", ObjFrmSteEditCierre.IdCierre)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCierre.Close()
            ObjFrmSteEditCierre = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       LlamaModificarCierre
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCierreDiarioCaja para Modificar un Cierre
    '                       que haya sido aperturado en la misma fecha del día.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCierre()
        Dim ObjFrmSteEditCierre As New frmSteEditCierreDiarioCaja
        Try
            Dim StrSql As String

            'Imposible si no existen registros:
            If Me.grdCierre.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsCierre("Cierre").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Cierres de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si Cierre Diario esta Cerrado:
            StrSql = "SELECT * FROM SteCierreDiarioCaja WHERE (nCerrada = 1) AND (nSteCierreDiarioCajaID =" & XdsCierre("Cierre").ValueField("nSteCierreDiarioCajaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El cierre se encuentra aplicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditCierre.ModoFrm = "UPD"
            ObjFrmSteEditCierre.IntPermiteEditar = Me.IntPermiteEditar
            ObjFrmSteEditCierre.IdCierre = XdsCierre("Cierre").ValueField("nSteCierreDiarioCajaID")
            ObjFrmSteEditCierre.ShowDialog()

            If ObjFrmSteEditCierre.IdCierre <> 0 Then
                InicializaVariables()
                CargarCierre()
                XdsCierre("Cierre").SetCurrentByID("nSteCierreDiarioCajaID", ObjFrmSteEditCierre.IdCierre)
                Me.grdCierre.Row = XdsCierre("Cierre").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCierre.Close()
            ObjFrmSteEditCierre = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       LlamaRevertirCierre
    ' Descripción:          Este procedimiento permite Revertir Cierre de 
    '                       Caja.
    '-------------------------------------------------------------------------
    Private Sub LlamaRevertirCierre()
        Dim XdtCerrarR As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String

        Try
            Dim intPosicion As Integer  'Posicion del registro seleccionado, ID de la Socia

            'Imposible cerrar si no hay registrados:
            If Me.grdCierre.RowCount = 0 Then
                MsgBox("No existen registros.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsCierre("Cierre").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Cierres de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si Cierre Diario esta Abierto:
            Strsql = "SELECT * FROM SteCierreDiarioCaja WHERE (nCerrada = 0) AND (nSteCierreDiarioCajaID =" & XdsCierre("Cierre").ValueField("nSteCierreDiarioCajaID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El cierre diario no se encuentra aplicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si la fecha del Cierre no corresponde a la Fecha del día:
            If DateDiff(DateInterval.Day, XdsCierre("Cierre").ValueField("dFechaCierre"), FechaServer) <> 0 Then
                MsgBox("No es posible revertir Cierre diferente de la Fecha del día.", MsgBoxStyle.Information, "SMUSURA0")
                Exit Sub
            End If

            'Imposible revertir si existe Arqueo ACTIVO para la Fecha y Caja:
            'Strsql = "SELECT SteArqueoCaja.nSteCajaID " & _
            '         "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') AND (SteArqueoCaja.nSteCajaID = " & XdsCierre("Cierre").ValueField("nSteCajaID") & ") AND (SteArqueoCaja.dFechaArqueo = CONVERT(DATETIME, '" & Format(XdsCierre("Cierre").ValueField("dFechaCierre"), "yyyy-MM-dd") & "', 102))"
            'If RegistrosAsociados(Strsql) Then
            '    MsgBox("Imposible revertir Cierre." & Chr(13) & "Existen Arqueos ACTIVOS para la Caja y Fecha.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Revertir Cierre:
            If MsgBox("¿Está seguro de Revertir el Cierre de la Caja seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Update:
                XdtCerrarR.ExecuteSqlNotTable("Update SteCierreDiarioCaja SET dFechaModificacion = GetDate(), nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", nCerrada = 0 WHERE nSteCierreDiarioCajaID  = " & XdsCierre("Cierre").ValueField("nSteCierreDiarioCajaID"))
                'Refrescar Datos:
                intPosicion = XdsCierre("Cierre").ValueField("nSteCierreDiarioCajaID")
                CargarCierre()
                XdsCierre("Cierre").SetCurrentByID("nSteCierreDiarioCajaID", intPosicion)
                Me.grdCierre.Row = XdsCierre("Cierre").BindingSource.Position
                'Almacena pista de auditoria:
                Strsql = "Reversión de Cierre Diario de Caja Código: " & XdsCierre("Cierre").ValueField("nCodigo") & " - " & XdsCierre("Cierre").ValueField("sDescripcionCaja") & ". Fecha: " & XdsCierre("Cierre").ValueField("dFechaCierre") & "."
                Call GuardarAuditoria(5, 25, Strsql)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtCerrarR.Close()
            XdtCerrarR = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
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
    ' Fecha:                13/11/2008
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
    ' Fecha:                13/11/2008
    ' Procedure Name:       grdCierre_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Cierre, al hacer doble click sobre el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCierre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCierre.DoubleClick
        Try
            If Seg.HasPermission("ModificarCierreDiarioCaja") Then
                LlamaModificarCierre()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdCierre_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCierre.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       grdCierre_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCierre_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCierre.Filter
        Try
            XdsCierre("Cierre").FilterLocal(e.Condition)
            Me.grdCierre.Caption = " Listado de Cierres Diarios de Caja (" + Me.grdCierre.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'MantCierreDiarioCaja -frmMantCierreDiarioCaja:
            'Agregar
            If Seg.HasPermission("AgregarCierreDiarioCaja") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarCierreDiarioCaja") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Revertir
            If Seg.HasPermission("RevertirCierreDiarioCaja") Then
                Me.toolRevertir.Enabled = True
            Else
                Me.toolRevertir.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirListadoCierreDiarioCajasTE28") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class