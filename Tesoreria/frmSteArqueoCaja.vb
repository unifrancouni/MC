' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                10/01/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteArqueoCaja.vb
' Descripción:          Este formulario carga los principales datos de
'                       Arqueos de Caja.
'-------------------------------------------------------------------------
Public Class frmSteArqueoCaja

    '- Declaración de Variables 
    Dim XdtArqueo As BOSistema.Win.XDataSet.xDataTable
    Dim intArqueoID As Integer

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       frmSteArqueoCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteArqueoCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtArqueo.Close()
            XdtArqueo = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       frmSteArqueoCaja_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Arqueos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteArqueoCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            'cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            cdeFechaD.Value = FechaServer()
            cdeFechaH.Value = FechaServer()

            InicializaVariables()
            CargarArqueo()
            FormatoArqueo()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	13/03/2008
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
    ' Fecha:                10/01/2008
    ' Procedure Name:       CargarArqueo
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de Arqueos de Caja en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarArqueo()
        Try
            Dim Strsql As String = ""

            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT a.nSteArqueoCajaID, a.nSteCajaID, a.nCodigo, a.nTrasladoValores, a.Estado, a.dFechaArqueo, " & _
                         " a.Cajero, a.CodigoCaja, a.sDescripcionCaja, a.LugarPagos, a.sCodEstado, " & _
                         " a.TotalEfectivo, a.TotalRecibos, a.Diferencia, a.sNumeroDeposito, a.EmpleadoElaboro, a.nSteMinutaDepositoID, a.nStbDelegacionProgramaID, a.nStbTipoProgramaID, a.nStbTipoPlazoPagosID " & _
                         " FROM vwSteArqueo AS a " & _
                         " WHERE (dFechaArqueo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                         " Order by a.nCodigo OPTION (FORCE ORDER)"
            Else 'Solo Filtra Arqueos de su Delegación:
                Strsql = " SELECT a.nSteArqueoCajaID, a.nSteCajaID, a.nCodigo, a.nTrasladoValores, a.Estado, a.dFechaArqueo, " & _
                         " a.Cajero, a.CodigoCaja, a.sDescripcionCaja, a.LugarPagos, a.sCodEstado, " & _
                         " a.TotalEfectivo, a.TotalRecibos, a.Diferencia, a.sNumeroDeposito, a.EmpleadoElaboro, a.nSteMinutaDepositoID, a.nStbDelegacionProgramaID, a.nStbTipoProgramaID, a.nStbTipoPlazoPagosID " & _
                         " FROM vwSteArqueo AS a " & _
                         " WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And (dFechaArqueo BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                         " Order by a.nCodigo OPTION (FORCE ORDER)"
            End If
            XdtArqueo.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdArqueo.DataSource = XdtArqueo.Source
            Me.grdArqueo.Caption = " Listado de Arqueos de Caja (" + Me.grdArqueo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       FormatoArqueo
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre el Arqueo en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoArqueo()
        Try

            'Configuración del Grid: 
            Me.grdArqueo.Splits(0).DisplayColumns("nSteArqueoCajaID").Visible = False
            Me.grdArqueo.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.grdArqueo.Splits(0).DisplayColumns("sCodEstado").Visible = False
            Me.grdArqueo.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.grdArqueo.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdArqueo.Splits(0).DisplayColumns("nStbTipoProgramaID").Visible = False
            Me.grdArqueo.Splits(0).DisplayColumns("nStbTipoPlazoPagosID").Visible = False

            Me.grdArqueo.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdArqueo.Splits(0).DisplayColumns("Estado").Width = 100
            Me.grdArqueo.Splits(0).DisplayColumns("nTrasladoValores").Width = 90
            Me.grdArqueo.Splits(0).DisplayColumns("dFechaArqueo").Width = 80
            Me.grdArqueo.Splits(0).DisplayColumns("CodigoCaja").Width = 70
            Me.grdArqueo.Splits(0).DisplayColumns("sDescripcionCaja").Width = 250
            Me.grdArqueo.Splits(0).DisplayColumns("Cajero").Width = 180
            Me.grdArqueo.Splits(0).DisplayColumns("LugarPagos").Width = 180
            Me.grdArqueo.Splits(0).DisplayColumns("TotalEfectivo").Width = 120
            Me.grdArqueo.Splits(0).DisplayColumns("TotalRecibos").Width = 120
            Me.grdArqueo.Splits(0).DisplayColumns("Diferencia").Width = 80
            Me.grdArqueo.Splits(0).DisplayColumns("sNumeroDeposito").Width = 90
            Me.grdArqueo.Splits(0).DisplayColumns("EmpleadoElaboro").Width = 150

            Me.grdArqueo.Columns("nCodigo").Caption = "Código"
            Me.grdArqueo.Columns("Estado").Caption = "Estado Arqueo"
            Me.grdArqueo.Columns("nTrasladoValores").Caption = "Traslado Valores"
            Me.grdArqueo.Columns("dFechaArqueo").Caption = "Fecha Arqueo"
            Me.grdArqueo.Columns("CodigoCaja").Caption = "Código Caja"
            Me.grdArqueo.Columns("sDescripcionCaja").Caption = "Descripción Caja"
            Me.grdArqueo.Columns("Cajero").Caption = "Nombre del Cajero"
            Me.grdArqueo.Columns("LugarPagos").Caption = "Ubicación Caja"
            Me.grdArqueo.Columns("TotalEfectivo").Caption = "Total Efectivo C$"
            Me.grdArqueo.Columns("TotalRecibos").Caption = "Total Documentos C$"
            Me.grdArqueo.Columns("Diferencia").Caption = "Diferencia C$"
            Me.grdArqueo.Columns("sNumeroDeposito").Caption = "Número Minuta"
            Me.grdArqueo.Columns("EmpleadoElaboro").Caption = "Arqueado Por"

            Me.grdArqueo.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdArqueo.Splits(0).DisplayColumns("dFechaArqueo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdArqueo.Columns("nTrasladoValores").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdArqueo.Splits(0).DisplayColumns("nTrasladoValores").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdArqueo.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("nTrasladoValores").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("dFechaArqueo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("CodigoCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("Cajero").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("LugarPagos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("TotalEfectivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("TotalRecibos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("Diferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueo.Splits(0).DisplayColumns("EmpleadoElaboro").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdArqueo.Columns("dFechaArqueo").NumberFormat = "dd/MM/yyyy"
            Me.grdArqueo.Columns("TotalEfectivo").NumberFormat = "#,##0.00"
            Me.grdArqueo.Columns("TotalRecibos").NumberFormat = "#,##0.00"
            Me.grdArqueo.Columns("Diferencia").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            '-- Encuentra parámetros de Delegación.
            EncuentraParametros()

            XdtArqueo = New BOSistema.Win.XDataSet.xDataTable
            Me.Text = "Arqueo de Caja"
            'Limpiar los Grids, estructura y Datos
            Me.grdArqueo.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       tbArqueo_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbArqueo.
    '-------------------------------------------------------------------------
    Private Sub tbArqueo_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbArqueo.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarArqueo()
            Case "toolModificar"
                LlamaModificarArqueo()
            Case "toolCerrar"
                LlamaCerrarArqueo()
            Case "toolAnular"
                LlamaAnularArqueo()
            Case "toolAnularR"
                LlamaAnularArqueoR()
            Case "toolPagare"
                LlamaGenerarPagare()
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
                CargarArqueo()
                FormatoArqueo()
            Case "toolSalir"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       LlamaAgregarArqueo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditArqueoCaja para Agregar un nuevo Arqueo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarArqueo()
        Dim ObjFrmSteEditArqueo As New frmSteEditArqueoCaja
        Try

            ObjFrmSteEditArqueo.IntHabilito = 1
            ObjFrmSteEditArqueo.ModoFrm = "ADD"
            ObjFrmSteEditArqueo.intStePermiteEditar = IntPermiteEditar
            'Quitar
            'MsgBox("Antes de  ObjFrmSteEditArqueo.ShowDialog() .", MsgBoxStyle.Information)
            ObjFrmSteEditArqueo.ShowDialog()

            'Si se ingreso un nuevo Arqueo:
            If ObjFrmSteEditArqueo.intSteArqueoID <> 0 Then
                CargarArqueo()
                XdtArqueo.SetCurrentByID("nSteArqueoCajaID", ObjFrmSteEditArqueo.intSteArqueoID)
                Me.grdArqueo.Row = XdtArqueo.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditArqueo.Close()
            ObjFrmSteEditArqueo = Nothing
        End Try
    End Sub
    
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       LlamaCerrarArqueo
    ' Descripción:          Este procedimiento permite Cerrar un Arqueo de Caja
    '                       impidiendo con ello posteriores Modificaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrarArqueo()
        Dim XcCierre As New BOSistema.Win.XComando
        Try
            Dim intPosicion As Integer
            Dim StrSql As String
            Dim nintArqueoID As Integer

            'No existen registros:
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArqueo.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Cerrar Arqueos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no tiene el estado "En Proceso":
            StrSql = "SELECT SteArqueoCaja.nSteArqueoCajaID " & _
                    "FROM StbValorCatalogo AS C INNER JOIN SteArqueoCaja ON C.nStbValorCatalogoID = SteArqueoCaja.nStbEstadoArqueoID " & _
                    "WHERE (C.sCodigoInterno = '1') AND (SteArqueoCaja.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If (XdtArqueo.ValueField("sCodEstado") <> 1) Or (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Arqueo no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Cerrar Arqueo si no tiene Documentos asociados:
            StrSql = "SELECT * FROM SteArqueoRecibo WHERE (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("Antes debe registrar los Recibos asociados al Arqueo.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Cerrar Arqueo si Suma de Efectivo es Cero:
            StrSql = "SELECT SUM(nCantidad) AS MontoR FROM SteArqueoDenominacion WHERE  (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ") HAVING   (SUM(nCantidad) = 0)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible Cerrar Arqueo. La suma de Efectivo es Cero.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Cerrar Arqueo si suma de Documentos es Cero:
            StrSql = "SELECT  SUM(nValor) AS MontoR FROM SteArqueoRecibo WHERE  (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ") HAVING  (SUM(nValor) = 0)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible Cerrar Arqueo. La suma de Recibos es Cero.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Cerrar Arqueo si no se ha asignado una Minuta de Depósito:
            StrSql = "SELECT * FROM SteArqueoCaja WHERE (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ") AND (nSteMinutaDepositoID IS NULL)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible Cerrar Arqueo. Antes debe indicar la Minuta de Depósito.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Cerrar si la Minuta asignada esta Enviada a MHCP:
            If IsNumeric(XdtArqueo.ValueField("nSteMinutaDepositoID")) Then
                StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                         "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdtArqueo.ValueField("nSteMinutaDepositoID") & ")"
                If RegistrosAsociados(StrSql) = True Then
                    MsgBox("La Minuta asociada no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            End If

            StrSql = "SELECT * FROM SteArqueoCaja " & _
                     "WHERE (dFechaArqueo < CONVERT(DATETIME, '2008-01-31 00:00:00', 102)) AND (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Los Recibos asociados ya han sido enviados al MHCP.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If



            ''Para obligar a las cajas desconectadas a ingresar los recibos manuales antes 
            'StrSql = "SELECT * FROM SteArqueoCaja " & _
            '         "WHERE (dFechaArqueo < CONVERT(DATETIME, '2008-01-31 00:00:00', 102)) AND (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            'If RegistrosAsociados(StrSql) = True Then
            '    MsgBox("Los Recibos asociados ya han sido enviados al MHCP.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If

            'Cerrar Arqueo de Caja:
            If MsgBox("¿Está seguro de Cerrar el Arqueo de Caja?" & Chr(13) & "No podrá modificar ninguno de sus datos.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Cambiar cursor:
                Me.Cursor = Cursors.WaitCursor

                'Ejecuta Procedimiento Almacenado:
                GuardarAuditoriaTablas(29, 2, "Actualizar SteArqueoCaja Cerrar Arqueo", XdtArqueo.ValueField("nSteArqueoCajaID"), InfoSistema.IDCuenta)
                StrSql = " EXEC spSteCerrarArqueoCaja " & XdtArqueo.ValueField("nSteArqueoCajaID") & ", " & XdtArqueo.ValueField("nSteMinutaDepositoID") & ", " & InfoSistema.IDCuenta
                nintArqueoID = XcCierre.ExecuteScalar(StrSql)

                'Refrescar Datos: 
                intPosicion = XdtArqueo.ValueField("nSteArqueoCajaID")
                CargarArqueo()
                XdtArqueo.SetCurrentByID("nSteArqueoCajaID", intPosicion)
                Me.grdArqueo.Row = XdtArqueo.BindingSource.Position

                'Envía mensaje de cierre:
                If nintArqueoID = 0 Then
                    MsgBox("El Arqueo no pudo Cerrarse.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("El Arqueo se cerró satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                    Call GuardarAuditoria(5, 25, "Cierre de Arqueo ID: " & XdtArqueo.ValueField("nSteArqueoCajaID") & ").")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XcCierre.Close()
            XcCierre = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/01/2008
    ' Procedure Name:       LlamaAnularArqueoR
    ' Descripción:          Este procedimiento permite Anular un Arqueo de Caja
    '                       generando un nuevo Arqueo con los mismos registros.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularArqueoR()
        Dim XdtArqueoTmp As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim Strsql As String
            Dim intPosicion As Long

            'No existen registros: 
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArqueo.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Arqueos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si ya esta Anulado: 
            Strsql = "SELECT SteArqueoCaja.nSteArqueoCajaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteArqueoCaja ON C.nStbValorCatalogoID = SteArqueoCaja.nStbEstadoArqueoID " & _
                     "WHERE (C.sCodigoInterno = '3' or C.sCodigoInterno = '4') AND (SteArqueoCaja.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If (XdtArqueo.ValueField("sCodEstado") = 3) Or (RegistrosAsociados(Strsql)) Then
                MsgBox("Arqueo se encuentra Anulado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si existen recibos asociados a un Cierre Contable Cerrado:
            Strsql = " SELECT SccCierreDiarioCaja.dFechaCierre " & _
                     " FROM SccCierreDiarioCaja INNER JOIN StbValorCatalogo ON SccCierreDiarioCaja.nStbEstadoCierreID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SccCierreDiarioCaja.dFechaCierre = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Cierres de Cartera generados y" & Chr(13) & "cerrados en la fecha del arqueo.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Anular si la Minuta esta Enviada a MHCP:
            If IsNumeric(XdtArqueo.ValueField("nSteMinutaDepositoID")) Then
                Strsql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                         "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdtArqueo.ValueField("nSteMinutaDepositoID") & ")"
                If RegistrosAsociados(Strsql) = True Then
                    MsgBox("La Minuta asociada no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            End If

            'Imposible Anular si Fecha del Arqueo es de Enero 2008:
            Strsql = "SELECT * FROM SteArqueoCaja " & _
                     "WHERE (dFechaArqueo < CONVERT(DATETIME, '2008-01-31 00:00:00', 102)) AND (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If RegistrosAsociados(Strsql) = True Then
                MsgBox("Los Recibos asociados ya han sido enviados al MHCP.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si no tiene Documentos asociados:
            Strsql = "SELECT * FROM SteArqueoRecibo WHERE (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("Imposible Anular con regeneración, el Arqueo" & Chr(13) & "no tiene Documentos asociados.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si Suma de Efectivo es Cero:
            Strsql = "SELECT SUM(nCantidad) AS MontoR FROM SteArqueoDenominacion WHERE  (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ") HAVING   (SUM(nCantidad) = 0)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Imposible Anular con regeneración." & Chr(13) & "La suma de Efectivo es Cero.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si suma de Documentos es Cero:
            Strsql = "SELECT  SUM(nValor) AS MontoR FROM SteArqueoRecibo WHERE  (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ") HAVING  (SUM(nValor) = 0)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Imposible Anular con regeneración." & Chr(13) & "La suma de Recibos es Cero.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Verifica si existe Pagaré <> Anulado para el Arqueo seleccionado
            'Strsql = " SELECT a.nStePagareID " & _
            '         " FROM    StePagare a " & _
            '         " Where a.nStbEstadoPagareID <> (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'PagareTesoreria') " & _
            '         " AND  a.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID")
            'If RegistrosAsociados(Strsql) = True Then
            '    MsgBox("Existe Pagaré Activo para este Arqueo.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If

            If MsgBox("¿Está seguro de Anular El Arqueo seleccionado?" & Chr(13) & "Se creará un nuevo Arqueo En Proceso.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Cambiar cursor:
                Me.Cursor = Cursors.WaitCursor
                'Cargar XdtArqueoTmp:

                GuardarAuditoriaTablas(29, 2, "Actualizar SteArqueoCaja Anular con Regeneracion Anulado", XdtArqueo.ValueField("nSteArqueoCajaID"), InfoSistema.IDCuenta)
                Strsql = " Select * " & _
                         " From SteArqueoCaja " & _
                         " Where nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID")
                XdtArqueoTmp.ExecuteSql(Strsql)
                'Ejecuta Procedimiento Almacenado:
                Strsql = " EXEC spSteAnularArqueo " & XdtArqueoTmp.ValueField("nSteArqueoCajaID") & ", " & InfoSistema.IDCuenta
                Me.intArqueoID = XcDatos.ExecuteScalar(Strsql)


                GuardarAuditoriaTablas(29, 2, "Actualizar SteArqueoCaja Anular con Regeneracion Regenerado", Me.intArqueoID, InfoSistema.IDCuenta)

                '-- Guardar posición actual de la selección:
                intPosicion = Me.intArqueoID
                CargarArqueo()
                '-- Ubicar la selección en la posición original:
                XdtArqueo.SetCurrentByID("nSteArqueoCajaID", intPosicion)
                Me.grdArqueo.Row = XdtArqueo.BindingSource.Position
                '-- Indica Estado de Ejecución del Procedimiento:
                If Me.intArqueoID = 0 Then
                    MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
                Else
                    Call GuardarAuditoria(5, 25, "Anulación con Regeneración de Arqueo No. " & XdtArqueoTmp.ValueField("nCodigo") & ". Regeneración de Arqueo En Proceso (No. " & XdtArqueo.ValueField("nCodigo") & ").")
                    MsgBox("El Arqueo se ha Anulado de forma satisfactoria." & Chr(10) & Chr(13) & _
                           "Se generó nuevo Arqueo En Proceso.", MsgBoxStyle.Information)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing

            XdtArqueoTmp.Close()
            XdtArqueoTmp = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       LlamaAnularArqueo
    ' Descripción:          Este procedimiento permite Anular un Arqueo de Caja.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularArqueo()
        Dim XdtArqueoAnular As New BOSistema.Win.SteEntArqueo.SteArqueoCajaDataTable
        Dim XdrArqueoAnular As New BOSistema.Win.SteEntArqueo.SteArqueoCajaRow

        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Try

            Dim Strsql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.
            Dim strCausaAnulacion As String

            'No existen registros: 
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArqueo.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Arqueos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si ya esta Anulado: 
            Strsql = "SELECT SteArqueoCaja.nSteArqueoCajaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteArqueoCaja ON C.nStbValorCatalogoID = SteArqueoCaja.nStbEstadoArqueoID " & _
                     "WHERE (C.sCodigoInterno = '3' or C.sCodigoInterno = '4') AND (SteArqueoCaja.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If (XdtArqueo.ValueField("sCodEstado") = 3) Or (RegistrosAsociados(Strsql)) Then
                MsgBox("Arqueo se encuentra Anulado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si existen recibos asociados a un Cierre Contable Cerrado:
            Strsql = " SELECT SccCierreDiarioCaja.dFechaCierre " & _
                     " FROM SccCierreDiarioCaja INNER JOIN StbValorCatalogo ON SccCierreDiarioCaja.nStbEstadoCierreID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SccCierreDiarioCaja.dFechaCierre = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Cierres de Cartera generados y" & Chr(13) & "cerrados en la fecha del arqueo.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Anular si la Minuta esta Enviada a MHCP:
            If IsNumeric(XdtArqueo.ValueField("nSteMinutaDepositoID")) Then
                Strsql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                         "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdtArqueo.ValueField("nSteMinutaDepositoID") & ")"
                If RegistrosAsociados(Strsql) = True Then
                    MsgBox("La Minuta asociada no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            End If
            Strsql = "SELECT * FROM SteArqueoCaja " & _
                     "WHERE (dFechaArqueo < CONVERT(DATETIME, '2008-01-31 00:00:00', 102)) AND (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If RegistrosAsociados(Strsql) = True Then
                MsgBox("Los Recibos asociados ya han sido enviados al MHCP.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Existen Recibos Activos y MANUALES (19/06/2009) asociados:
            Strsql = " SELECT a.nCodigo FROM " & _
                                        "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario " & _
                                        "FROM vwSccReciboSerie WHERE (nManual = 1) AND (sCodigoInterno <> '3') " & _
                                        "And (nStbTipoPlazoPagosID = " & XdtArqueo.ValueField("nStbTipoPlazoPagosID") & ") AND (nStbTipoProgramaID = " & XdtArqueo.ValueField("nStbTipoProgramaID") & ") " & _
                                        ")AS a INNER JOIN " & _
                                        " (SELECT AR.nCodigo, D.sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario " & _
                                        "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                                        "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                                        "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                                        " WHERE (AR.nSccReciboOficialCajaID IS NULL) AND (AR.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")) " & _
                                        "AS b " & _
                    "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " & _
                    "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " & _
                    "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " & _
                    "AND a.nCodigoTalonario = b.nCodigoTalonario"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Recibos Oficiales de Caja (MANUALES) Activos asociados.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Verifica si existe Pagaré <> Anulado para el Arqueo seleccionado
            Strsql = " SELECT a.nStePagareID " & _
                     " FROM    StePagare a " & _
                     " Where a.nStbEstadoPagareID <> (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'PagareTesoreria') " & _
                     " AND  a.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID")
            If RegistrosAsociados(Strsql) = True Then
                MsgBox("Existe Pagaré Activo para este Arqueo.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Anular El Arqueo seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                'Solicita al Usuario la Causa de la Anulación:
                XdtArqueoAnular.Filter = " nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID")
                XdtArqueoAnular.Retrieve()
                XdrArqueoAnular = XdtArqueoAnular.Current

                ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                ObjFrmStbDatoComplemento.strTitulo = "Anulación del Arqueo"
                ObjFrmStbDatoComplemento.intAncho = XdrArqueoAnular.GetColumnLenght("sMotivoAnulacion")
                ObjFrmStbDatoComplemento.strDato = ""
                ObjFrmStbDatoComplemento.strColor = "Naranja"
                ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                ObjFrmStbDatoComplemento.ShowDialog()

                strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                'Valida que se ingrese la Causa de la Anulación:
                If strCausaAnulacion = "" Then
                    MsgBox("El registro NO PUEDE ser Anulado.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If

                'Actualizar el EstadoArqueo a Anulado:

                GuardarAuditoriaTablas(29, 2, "Actualizar SteArqueoCaja Anular", XdtArqueo.ValueField("nSteArqueoCajaID"), InfoSistema.IDCuenta)

                Strsql = " Update SteArqueoCaja " & _
                         " SET nStbEstadoArqueoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '4' And b.sNombre = 'EstadoArqueoCaja')," & _
                         "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate(), sMotivoAnulacion = '" & strCausaAnulacion & "'" & _
                         " WHERE nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID")
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                       "de forma satisfactoria.", MsgBoxStyle.Information)
                'Guardar posición actual de la selección:
                intPosicion = XdtArqueo.ValueField("nSteArqueoCajaID")
                Call GuardarAuditoria(5, 25, "Anulación de Arqueo ID: " & XdtArqueo.ValueField("nSteArqueoCajaID") & ").")
                CargarArqueo()

                'Ubicar la selección en la posición original:
                XdtArqueo.SetCurrentByID("nSteArqueoCajaID", intPosicion)
                Me.grdArqueo.Row = XdtArqueo.BindingSource.Position

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtArqueoAnular.Close()
            XdtArqueoAnular = Nothing

            XdrArqueoAnular.Close()
            XdrArqueoAnular = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       LlamaModificarArqueo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditArqueoCaja para Modificar un arqueo.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarArqueo()
        Dim ObjFrmSteEditArqueo As New frmSteEditArqueoCaja
        Try
            Dim StrSql As String
            'Si no existen registros:
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArqueo.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Arqueos de otra Delegación.", MsgBoxStyle.Information)
                    ObjFrmSteEditArqueo.IntHabilito = 0
                    'Exit Sub
                End If
            End If

            ObjFrmSteEditArqueo.IntHabilito = 1
            'Valida si no tiene el estado "En Proceso"
            StrSql = "SELECT SteArqueoCaja.nSteArqueoCajaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteArqueoCaja ON C.nStbValorCatalogoID = SteArqueoCaja.nStbEstadoArqueoID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteArqueoCaja.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If (XdtArqueo.ValueField("sCodEstado") <> 1) Or (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Arqueo no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                ObjFrmSteEditArqueo.IntHabilito = 0
                'Exit Sub
            End If

            'Imposible modificar si la Minuta esta Enviada a MHCP:
            If IsNumeric(XdtArqueo.ValueField("nSteMinutaDepositoID")) Then
                StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                         "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdtArqueo.ValueField("nSteMinutaDepositoID") & ")"
                If RegistrosAsociados(StrSql) = True Then
                    MsgBox("La Minuta asociada no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                    ObjFrmSteEditArqueo.IntHabilito = 0
                    'Exit Sub
                End If
            End If

            StrSql = "SELECT * FROM SteArqueoCaja " & _
                     "WHERE (dFechaArqueo < CONVERT(DATETIME, '2008-01-31 00:00:00', 102)) AND (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Los Recibos asociados ya han sido enviados al MHCP.", MsgBoxStyle.Information, NombreSistema)
                ObjFrmSteEditArqueo.IntHabilito = 0
                'Exit Sub
            End If

            ObjFrmSteEditArqueo.ModoFrm = "UPD"
            ObjFrmSteEditArqueo.intStePermiteEditar = IntPermiteEditar
            ObjFrmSteEditArqueo.intSteArqueoID = XdtArqueo.ValueField("nSteArqueoCajaID")
            ObjFrmSteEditArqueo.ShowDialog()

            CargarArqueo()
            XdtArqueo.SetCurrentByID("nSteArqueoCajaID", ObjFrmSteEditArqueo.intSteArqueoID)
            Me.grdArqueo.Row = XdtArqueo.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditArqueo.Close()
            ObjFrmSteEditArqueo = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       LlamaModificarArqueo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditArqueoCaja para Modificar un arqueo.
    '-------------------------------------------------------------------------
    Private Sub LlamaGenerarPagare()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            Dim intPagareID As Integer

            'No existen registros: 
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArqueo.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Generar Pagaré de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si ya esta Anulado: 
            Strsql = "SELECT SteArqueoCaja.nSteArqueoCajaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteArqueoCaja ON C.nStbValorCatalogoID = SteArqueoCaja.nStbEstadoArqueoID " & _
                     "WHERE (C.sCodigoInterno <> '2') AND (SteArqueoCaja.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ")"
            If (XdtArqueo.ValueField("sCodEstado") <> 2) Or (RegistrosAsociados(Strsql)) Then
                MsgBox("Arqueo DEBE estar Cerrado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Verifica si la diferencia es menor que 0
            Strsql = " SELECT  a.TotalEfectivo - a.nTotalDocumentos as Diferencia " & _
                     " FROM    vwSteArqueoConsolidadoCajerosxDepartamento a " & _
                     " Where  a.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & _
                     " AND (a.TotalEfectivo - a.nTotalDocumentos) < 0 "

            If RegistrosAsociados(Strsql) = False Then
                MsgBox("No existe faltante de Caja en este Arqueo.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Verifica si existe Pagaré <> Anulado para el Arqueo seleccionado



            Strsql = " SELECT a.nStePagareID " & _
                     " FROM    StePagare a " & _
                     " Where a.nStbEstadoPagareID <> (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'PagareTesoreria') " & _
                     " AND  a.nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID")

            If RegistrosAsociados(Strsql) = True Then
                MsgBox("Ya existe Pagaré para este Arqueo.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            Strsql = " EXEC spSteGrabarPagare " & XdtArqueo.ValueField("nSteArqueoCajaID") & ", " & InfoSistema.IDCuenta & ", " & XdtArqueo.ValueField("nStbDelegacionProgramaID")
            intPagareID = XcDatos.ExecuteScalar(Strsql)

            '-- Indica Estado de Ejecución del Procedimiento:
            If intPagareID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                GuardarAuditoriaTablas(18, 1, "Agregar Pagaré", intPagareID, InfoSistema.IDCuenta)
                MsgBox("El Pagaré se generó de forma satisfactoria.", MsgBoxStyle.Information)

                '''''

                Dim XdtConsulta As BOSistema.Win.XDataSet.xDataTable
                Dim StrQuery As String
                Dim IdPagaré As Integer

                StrQuery = "SELECT MAX(nStePagareID) as Cant FROM StePagare"
                XdtConsulta = New BOSistema.Win.XDataSet.xDataTable
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdPagaré = XdtConsulta.ValueField("Cant")
                End If

                '''''


            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de FNC.
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
    ' Fecha:                10/01/2008
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
    ' Fecha:                10/01/2008
    ' Procedure Name:       grdArqueo_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdArqueo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdArqueo.Filter
        Try
            XdtArqueo.FilterLocal(e.Condition)
            Me.grdArqueo.Caption = " Listado de Arqueos de Caja (" + Me.grdArqueo.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar:
            If Seg.HasPermission("AgregarArqueo") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If
            'Modificar:
            If Seg.HasPermission("ModificarArqueo") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If
            'Cerrar Arqueo:
            If Seg.HasPermission("CerrarArqueo") Then
                Me.toolCerrar.Enabled = True
            Else
                Me.toolCerrar.Enabled = False
            End If
            'Anular Arqueo:
            If Seg.HasPermission("AnularArqueo") Then
                Me.toolAnular.Enabled = True
            Else
                Me.toolAnular.Enabled = False
            End If
            'Anular Arqueo con Regeneración:
            If Seg.HasPermission("AnularArqueoConRegeneracion") Then
                Me.toolAnularR.Enabled = True
            Else
                Me.toolAnularR.Enabled = False
            End If
            'Generar Pagaré
            If Seg.HasPermission("GenerarPagare") Then
                Me.toolPagare.Enabled = True
            Else
                Me.toolPagare.Enabled = False
            End If

            '-- Imprimir:
            'Arqueo de Caja:
            If Seg.HasPermission("ImprimirFormatoArqueo") Then
                Me.toolImprimirA.Enabled = True
            Else
                Me.toolImprimirA.Enabled = False
            End If
            'Listado de Recibos por Cajero:
            If Seg.HasPermission("ImprimirRecibosPorArqueo") Then
                Me.toolImprimirC.Enabled = True
            Else
                Me.toolImprimirC.Enabled = False
            End If
            'Listado de Recibos por Fecha de Arqueo:
            If Seg.HasPermission("ImprimirRecibosPorFechaDeArqueo") Then
                Me.toolImprimirF.Enabled = True
            Else
                Me.toolImprimirF.Enabled = False
            End If
            If Seg.HasPermission("ImprimirRecibosPorFechaDeArqueo") Then
                Me.toolImprimirF1.Enabled = True
            Else
                Me.toolImprimirF1.Enabled = False
            End If

            'Conciliación de Efectivo vs Arqueo de Documentos
            If Seg.HasPermission("ImprimirConciliacionEfectivoArqueo") Then
                Me.toolImprimirCO.Enabled = True
            Else
                Me.toolImprimirCO.Enabled = False
            End If
            If Seg.HasPermission("ImprimirConciliacionEfectivoArqueo") Then
                Me.toolImprimirCO1.Enabled = True
            Else
                Me.toolImprimirCO1.Enabled = False
            End If

            'Conciliación de Efectivo vs Arqueo de Documentos y Minutas por Cajero:
            If Seg.HasPermission("ImprimirConciliacionEfectivoArqueoMinutaTE35") Then
                Me.toolImprimirCO2.Enabled = True
            Else
                Me.toolImprimirCO2.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/01/2008
    ' Procedure Name:       grdArqueo_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Arqueo existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdArqueo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdArqueo.DoubleClick
        Try
            If Me.grdArqueo.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarArqueo") Then
                LlamaModificarArqueo()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdArqueo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdArqueo.Error
        Control_Error(e.Exception)
    End Sub

    'Imprimir Formato de Arqueo:
    Private Sub toolImprimirA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirA.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario1") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("Usuario2") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE3.rpt"
            frmVisor.Text = "Arqueo de Caja"
            strSQL = " Select * " & _
                     " From vwSteArqueoRep " & _
                     " WHERE (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ") " & _
                     " Order by nSteArqueoCajaID, nBillete desc, nValor desc "
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    'Listado de Entrega de Recibos por Arqueo:
    Private Sub toolImprimirC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirC.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("CodRpt") = "'TE4'"
            frmVisor.NombreReporte = "RepSteTE4_TE5.rpt"
            frmVisor.Text = "Listado de Recibos por Arqueo"
            strSQL = " Select * " & _
                     " From vwSteArqueoRecibosRep " & _
                     " WHERE (nSteArqueoCajaID = " & XdtArqueo.ValueField("nSteArqueoCajaID") & ") " & _
                     " Order by nSteArqueoCajaID, NoRecibo  "

            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    'Listado de Entrega de Recibos por Fecha de Arqueo (Arqueo de Efectivo):
    Private Sub toolImprimirF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirF.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("CodRpt") = "'TE5'"
            frmVisor.NombreReporte = "RepSteTE4_TE5.rpt"
            frmVisor.Text = "Listado de Recibos por Fecha Arqueo"
            'Arqueos para la Fecha Actual que NO esten Anulados:
            If IntPermiteConsultar = 1 Then
                strSQL = " Select * " & _
                         " From vwSteArqueoRecibosRep " & _
                         " WHERE (nTrasladoValores = 0) And (dFechaArqueo = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) AND (sCodEstado <> '3') " & _
                         " Order by nSteArqueoCajaID, NoRecibo  "
            Else
                strSQL = " Select * " & _
                         " From vwSteArqueoRecibosRep " & _
                         " Where (nTrasladoValores = 0) And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And (dFechaArqueo = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) AND (sCodEstado <> '3') " & _
                         " Order by nSteArqueoCajaID, NoRecibo  "
            End If
            

            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    'Listado de Entrega de Recibos por Fecha de Arqueo (Traslado de Valores):
    Private Sub toolImprimirF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirF1.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("CodRpt") = "'TE5'"
            frmVisor.NombreReporte = "RepSteTE4_TE5.rpt"
            frmVisor.Text = "Listado de Recibos por Fecha Arqueo"
            'Arqueos para la Fecha Actual que NO esten Anulados:
            If IntPermiteConsultar = 1 Then
                strSQL = " Select * " & _
                         " From vwSteArqueoRecibosRep " & _
                         " WHERE (nTrasladoValores = 1) And (dFechaArqueo = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) AND (sCodEstado <> '3') " & _
                         " Order by nSteArqueoCajaID, NoRecibo  "
            Else
                strSQL = " Select * " & _
                         " From vwSteArqueoRecibosRep " & _
                         " Where (nTrasladoValores = 1) And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And (dFechaArqueo = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) AND (sCodEstado <> '3') " & _
                         " Order by nSteArqueoCajaID, NoRecibo  "
            End If


            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    'Informe Consolidado Centralizado unicamente para Managua en vista que muestra todos los 
    'Arqueos de un Dia.
    Private Sub toolImprimirCO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCO.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario1") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("Usuario2") = "'" & InfoSistema.LoginName & "'"

            frmVisor.NombreReporte = "RepSteTE6.rpt"
            frmVisor.Text = "Conciliación de Efectivo vs Arqueo de Documentos"
            'Arqueos Activos para la Fecha Actual: 
            strSQL = " Select * " & _
                     " From vwSteArqueoConsolidado " & _
                     " WHERE (nTrasladoValores = 0) And (dFechaArqueo = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by dFechaArqueo, nBillete desc, nValor desc"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    'Informe Consolidado para Traslado de Valores.
    Private Sub toolImprimirCO1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCO1.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdArqueo.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario1") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("Usuario2") = "'" & InfoSistema.LoginName & "'"

            frmVisor.NombreReporte = "RepSteTE6.rpt"
            frmVisor.Text = "Conciliación de Efectivo vs Arqueo de Documentos"
            'Arqueos Activos para la Fecha Actual: 
            strSQL = " Select * " &
                     " From vwSteArqueoConsolidado " &
                     " WHERE (nTrasladoValores = 1) And (dFechaArqueo = CONVERT(DATETIME, '" & Format(XdtArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) " &
           " Order by dFechaArqueo, nBillete desc, nValor desc"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    'Informe Consolidado de Efectivo vs Arqueo de Documentos y Minutas por Cajeros:
    Private Sub toolImprimirCO2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCO2.Click
        Try
            LlamaImprimirListadoTesoreria(6)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaImprimirListadoTesoreria(ByVal IDReporte As Integer)
        Dim ObjFrmScnParametroRpt As New frmSteParametrosTesoreria
        Try

            ObjFrmScnParametroRpt.NomRep = IDReporte
            ObjFrmScnParametroRpt.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnParametroRpt.Close()
            ObjFrmScnParametroRpt = Nothing
        End Try
    End Sub

    Private Sub toolRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRefrescar.Click

    End Sub

    Private Sub frmSteArqueoCaja_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub toolAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregar.Click

    End Sub
End Class