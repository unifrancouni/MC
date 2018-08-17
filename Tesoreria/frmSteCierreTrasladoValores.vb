' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                19/11/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteCierreTrasladoValores.vb
' Descripción:          Este formulario muestra Cierres Diarios de Traslados
'                       de Valores del Programa.
'-------------------------------------------------------------------------
Public Class frmSteCierreTrasladoValores

    '- Declaración de Variables 
    Dim XdsCierre As BOSistema.Win.XDataSet
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    Dim nCajaID As Integer
    Dim nCajeroID As Integer

    'Id de Caja:
    Public Property nSteCajaID() As Integer
        Get
            nSteCajaID = nCajaID
        End Get
        Set(ByVal value As Integer)
            nCajaID = value
        End Set
    End Property

    'Id de Empleado asociado al Cajero:
    Public Property nSrhCajeroID() As Integer
        Get
            nSrhCajeroID = nCajeroID
        End Get
        Set(ByVal value As Integer)
            nCajeroID = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/11/2008
    ' Procedure Name:       frmSteCierreTrasladoValores_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteCierreTrasladoValores_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsCierre.Close()
            XdsCierre = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/11/2008
    ' Procedure Name:       frmSteCierreTrasladoValores_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteCierreTrasladoValores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            If Me.nSteCajaID = 0 Then 'Gestión de Recursos:
                ObjGUI.SetFormLayout(Me, "Naranja")
            Else 'Cajeros
                ObjGUI.SetFormLayout(Me, "Verde")
            End If

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
    ' Date			    		:	19/11/2008
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
    ' Fecha:                19/11/2008
    ' Procedure Name:       CargarCierre
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       Cierres de Traslados de Valores en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCierre()
        Try
            Dim Strsql As String
            Strsql = " Select a.nSteCierreTrasladoValorID, a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, " & _
                     "        a.dFechaArqueo, a.Cajero, a.nCodigoReciboHasta, a.Login, a.sObservaciones, a.nStbDelegacionProgramaID, " & _
                     "        a.nSrhEmpleadoCajeroID " & _
                     " From vwSteCierreTrasladoValor a " & _
                     " WHERE (a.dFechaArqueo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.dFechaArqueo, a.nCodigo"
            If XdsCierre.ExistTable("Cierre") Then
                XdsCierre("Cierre").ExecuteSql(Strsql)
            Else
                XdsCierre.NewTable(Strsql, "Cierre")
                XdsCierre("Cierre").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdCierre.DataSource = XdsCierre("Cierre").Source

            'Actualizando el caption de los GRIDS:
            Me.grdCierre.Caption = " Listado de Cortes de Caja por Traslado de Valores (" + Me.grdCierre.RowCount.ToString + " registros)"
            FormatoCierre()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/11/2008
    ' Procedure Name:       FormatoCierre
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Cierres en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCierre()
        Try

            'Configuracion del Grid: 
            Me.grdCierre.Splits(0).DisplayColumns("nSteCierreTrasladoValorID").Visible = False
            Me.grdCierre.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.grdCierre.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdCierre.Splits(0).DisplayColumns("nSrhEmpleadoCajeroID").Visible = False

            Me.grdCierre.Splits(0).DisplayColumns("nCodigo").Width = 70
            Me.grdCierre.Splits(0).DisplayColumns("sDescripcionCaja").Width = 260
            Me.grdCierre.Splits(0).DisplayColumns("dFechaArqueo").Width = 120
            Me.grdCierre.Splits(0).DisplayColumns("Cajero").Width = 200
            Me.grdCierre.Splits(0).DisplayColumns("nCodigoReciboHasta").Width = 90
            Me.grdCierre.Splits(0).DisplayColumns("Login").Width = 100
            Me.grdCierre.Splits(0).DisplayColumns("sObservaciones").Width = 250

            Me.grdCierre.Columns("nCodigo").Caption = "Código Caja"
            Me.grdCierre.Columns("sDescripcionCaja").Caption = "Descripción Caja"
            Me.grdCierre.Columns("dFechaArqueo").Caption = "Fecha Corte"
            Me.grdCierre.Columns("Cajero").Caption = "Cajero"
            Me.grdCierre.Columns("nCodigoReciboHasta").Caption = "Recibo Corte"
            Me.grdCierre.Columns("Login").Caption = "Ingresado Por"
            Me.grdCierre.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdCierre.Splits(0).DisplayColumns("dFechaArqueo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Columns("dFechaArqueo").NumberFormat = "dd/MM/yyyy"

            Me.grdCierre.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("dFechaArqueo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("Cajero").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("nCodigoReciboHasta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/11/2008
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
    ' Fecha:                19/11/2008
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
            Case "toolEliminar"
                LlamaEliminarCierre()
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
    ' Date			    :	19/11/2008
    ' Procedure name	:	LlamaImprimir
    ' Description		:	Este procedimiento permite imprimir Listado de Cierres Diarios 
    '                       de Traslado de Valores para el rango de fechas indicadas. 
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
            frmVisor.NombreReporte = "RepSteTE29.rpt"
            frmVisor.Text = "Listado de Cortes de Traslado de Valores"
            frmVisor.SQLQuery = " Select * From vwSteCierreTrasladoValor " & _
                                " WHERE (dFechaArqueo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                " Order by nCodigo, dFechaArqueo"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/11/2008
    ' Procedure Name:       LlamaAgregarCierre
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCierreTrasladoValores.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCierre()
        Dim ObjFrmSteEditCierre As New frmSteEditCierreTrasladoValores
        Try
            ObjFrmSteEditCierre.ModoFrm = "ADD"
            ObjFrmSteEditCierre.IntPermiteEditar = Me.IntPermiteEditar
            ObjFrmSteEditCierre.IntCajaID = Me.nSteCajaID
            ObjFrmSteEditCierre.IntCajeroID = Me.nSrhCajeroID

            If Me.nSteCajaID = 0 Then 'Accesa Gestión de Recursos desde MDI:
                ObjFrmSteEditCierre.sColorFrm = "Naranja"
            Else 'Accesan Cajeros desde Recibos Automáticos:
                ObjFrmSteEditCierre.sColorFrm = "Verde"
            End If
            ObjFrmSteEditCierre.ShowDialog()

            If ObjFrmSteEditCierre.IdCierre <> 0 Then
                CargarCierre()
                XdsCierre("Cierre").SetCurrentByID("nSteCierreTrasladoValorID", ObjFrmSteEditCierre.IdCierre)
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
    ' Fecha:                19/11/2008
    ' Procedure Name:       LlamaModificarCierre
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCierreTrasladoValores para Modificar un 
    '                       Cierre por Traslado de Valores siempre q no tenga
    '                       Arqueos Activos asociados.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCierre()
        Dim ObjFrmSteEditCierre As New frmSteEditCierreTrasladoValores
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

            'Imposible si existe Arqueo ACTIVO para la Caja, Cajero y Fecha: 
            StrSql = "SELECT SteArqueoCaja.nSteCajaID " & _
                     "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') " & _
                     "AND (SteArqueoCaja.nSteCajaID = " & XdsCierre("Cierre").ValueField("nSteCajaID") & ") AND (SteArqueoCaja.dFechaArqueo = CONVERT(DATETIME, '" & Format(XdsCierre("Cierre").ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) " & _
                     "AND (SteArqueoCaja.nSrhCajeroId = " & XdsCierre("Cierre").ValueField("nSrhEmpleadoCajeroID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Arqueos ACTIVOS para la Caja, Cajero y Fecha.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si la fecha del Cierre no corresponde a la Fecha del día:
            If DateDiff(DateInterval.Day, XdsCierre("Cierre").ValueField("dFechaArqueo"), FechaServer) <> 0 Then
                MsgBox("No es posible modificar Cierre diferente de la Fecha del día.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSteEditCierre.ModoFrm = "UPD"
            ObjFrmSteEditCierre.IntCajaID = Me.nSteCajaID
            ObjFrmSteEditCierre.IntCajeroID = Me.nSrhCajeroID
            ObjFrmSteEditCierre.IntPermiteEditar = Me.IntPermiteEditar
            ObjFrmSteEditCierre.IdCierre = XdsCierre("Cierre").ValueField("nSteCierreTrasladoValorID")
            If Me.nSteCajaID = 0 Then 'Gestión de Recursos:
                ObjFrmSteEditCierre.sColorFrm = "Naranja"
            Else 'Cajeros
                ObjFrmSteEditCierre.sColorFrm = "Verde"
            End If
            ObjFrmSteEditCierre.ShowDialog()

            If ObjFrmSteEditCierre.IdCierre <> 0 Then
                InicializaVariables()
                CargarCierre()
                XdsCierre("Cierre").SetCurrentByID("nSteCierreTrasladoValorID", ObjFrmSteEditCierre.IdCierre)
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
    ' Fecha:                12/02/2009
    ' Procedure Name:       LlamaEliminarCierre
    ' Descripción:          Este procedimiento permite eliminar Cierres por
    '                       Traslado de Valores siempre q no tenga Arqueos
    '                       Activos asociados.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarCierre()
        Dim XcEliminarCierre As New BOSistema.Win.XComando
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

            'Imposible si existe Arqueo ACTIVO para la Caja, Cajero y Fecha: 
            StrSql = "SELECT SteArqueoCaja.nSteCajaID " & _
                     "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') " & _
                     "AND (SteArqueoCaja.nSteCajaID = " & XdsCierre("Cierre").ValueField("nSteCajaID") & ") AND (SteArqueoCaja.dFechaArqueo = CONVERT(DATETIME, '" & Format(XdsCierre("Cierre").ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) " & _
                     "AND (SteArqueoCaja.nSrhCajeroId = " & XdsCierre("Cierre").ValueField("nSrhEmpleadoCajeroID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Arqueos ACTIVOS para la Caja, Cajero y Fecha.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el Cierre seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XcEliminarCierre.ExecuteNonQuery("Delete From SteCierreTrasladoValor where nSteCierreTrasladoValorID =" & XdsCierre("Cierre").ValueField("nSteCierreTrasladoValorID"))
                CargarCierre()
                FormatoCierre()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdCierre.Caption = " Listado de Cortes de Caja por Traslado de Valores (" + Me.grdCierre.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcEliminarCierre.Close()
            XcEliminarCierre = Nothing

        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/11/2008
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
    ' Fecha:                19/11/2008
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
    ' Fecha:                19/11/2008
    ' Procedure Name:       grdCierre_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Cierre, al hacer doble click sobre el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCierre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCierre.DoubleClick
        Try
            If Seg.HasPermission("ModificarCierreTrasladoValor") Then
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
    ' Fecha:                19/11/2008
    ' Procedure Name:       grdCierre_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCierre_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCierre.Filter
        Try
            XdsCierre("Cierre").FilterLocal(e.Condition)
            Me.grdCierre.Caption = " Listado de Cortes de Caja por Traslado de Valores (" + Me.grdCierre.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/11/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'MantCierreTrasladoValor - frmMantTrasladoValor:
            'Agregar:
            If Seg.HasPermission("AgregarCierreTrasladoValor") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar:
            If Seg.HasPermission("ModificarCierreTrasladoValor") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar:
            If Seg.HasPermission("EliminarCierreTrasladoValor") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir:
            If Seg.HasPermission("ImprimirListadoCierreTrasladoValorTE29") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class