' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                01/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteConciliacionBancaria.vb
' Descripción:          Este formulario carga los principales datos de
'                       Conciliaciones Bancarias.
'-------------------------------------------------------------------------
Public Class frmSteConciliacionBancaria

    '- Declaración de Variables: 
    Dim XdtConciliacion As BOSistema.Win.XDataSet.xDataTable
    Dim intConciliacionID As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       frmSteConciliacionBancaria_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteConciliacionBancaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtConciliacion.Close()
            XdtConciliacion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       frmSteConciliacionBancaria_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Conciliaciones en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteConciliacionBancaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            CargarConciliacion()
            FormatoConciliacion()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       CargarConciliacion
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de Conciliaciones Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarConciliacion()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nSteConciliacionBancariaID, a.nCodigo, a.Estado, " & _
                     " a.sNumeroCuenta, a.sNombreCuenta, a.dFechaInicio, a.dFechaCorte, a.Login " & _
                     " FROM vwSteConciliacion AS a " & _
                     " WHERE (dFechaInicio BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.nCodigo"
            XdtConciliacion.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdConciliacion.DataSource = XdtConciliacion.Source
            Me.grdConciliacion.Caption = " Listado de Conciliaciones Bancarias (" + Me.grdConciliacion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       FormatoConciliacion
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoConciliacion()
        Try

            'Configuración del Grid: 
            Me.grdConciliacion.Splits(0).DisplayColumns("nSteConciliacionBancariaID").Visible = False

            Me.grdConciliacion.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdConciliacion.Splits(0).DisplayColumns("Estado").Width = 80
            Me.grdConciliacion.Splits(0).DisplayColumns("sNumeroCuenta").Width = 120
            Me.grdConciliacion.Splits(0).DisplayColumns("sNombreCuenta").Width = 300
            Me.grdConciliacion.Splits(0).DisplayColumns("dFechaInicio").Width = 80
            Me.grdConciliacion.Splits(0).DisplayColumns("dFechaCorte").Width = 80
            Me.grdConciliacion.Splits(0).DisplayColumns("Login").Width = 150

            Me.grdConciliacion.Columns("nCodigo").Caption = "Código"
            Me.grdConciliacion.Columns("Estado").Caption = "Estado"
            Me.grdConciliacion.Columns("sNumeroCuenta").Caption = "No. Cuenta Bancaria"
            Me.grdConciliacion.Columns("sNombreCuenta").Caption = "Nombre Cuenta"
            Me.grdConciliacion.Columns("dFechaInicio").Caption = "Fecha Inicio"
            Me.grdConciliacion.Columns("dFechaCorte").Caption = "Fecha Corte"
            Me.grdConciliacion.Columns("Login").Caption = "Conciliado Por"
            
            Me.grdConciliacion.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdConciliacion.Splits(0).DisplayColumns("dFechaInicio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdConciliacion.Splits(0).DisplayColumns("dFechaCorte").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdConciliacion.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdConciliacion.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdConciliacion.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdConciliacion.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdConciliacion.Splits(0).DisplayColumns("dFechaInicio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdConciliacion.Splits(0).DisplayColumns("dFechaCorte").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdConciliacion.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdConciliacion.Columns("dFechaInicio").NumberFormat = "dd/MM/yyyy"
            Me.grdConciliacion.Columns("dFechaCorte").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtConciliacion = New BOSistema.Win.XDataSet.xDataTable
            Me.grdConciliacion.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       tbConciliacion_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbConciliacion.
    '-------------------------------------------------------------------------
    Private Sub tbConciliacion_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbConciliacion.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarConciliacion()
            Case "toolModificar"
                LlamaModificarConciliacion()
            Case "toolCerrar"
                LlamaCerrarConciliacion()
            Case "toolAnular"
                LlamaAnularConciliacion()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Not IsDate(cdeFechaD.Value)) Or (Not IsDate(cdeFechaH.Value)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Fecha de Corte no mayor a la de Inicio:
                If cdeFechaD.Value > cdeFechaH.Value Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If
                InicializaVariables()
                CargarConciliacion()
                FormatoConciliacion()
            Case "toolSalir"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       LlamaAgregarConciliacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditConciliacion para Agregar un nuevo Registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarConciliacion()
        Dim ObjFrmSteEditConciliacion As New frmSteEditConciliacion
        Try

            ObjFrmSteEditConciliacion.IntHabilito = 1
            ObjFrmSteEditConciliacion.ModoFrm = "ADD"
            ObjFrmSteEditConciliacion.ShowDialog()

            'Si se ingreso una nueva Conciliación:
            If ObjFrmSteEditConciliacion.intSteConciliacionID <> 0 Then
                CargarConciliacion()
                XdtConciliacion.SetCurrentByID("nSteConciliacionBancariaID", ObjFrmSteEditConciliacion.intSteConciliacionID)
                Me.grdConciliacion.Row = XdtConciliacion.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditConciliacion.Close()
            ObjFrmSteEditConciliacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       LlamaCerrarConciliacion
    ' Descripción:          Este procedimiento permite Cerrar una Conciliación
    '                       Bancaria impidiendo con ello posteriores Modificaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrarConciliacion()
        Dim XdtInactivar As New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim intPosicion As Integer
            Dim StrSql As String

            'No existen registros:
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si no tiene el estado "En Proceso":
            StrSql = "SELECT SteConciliacionBancaria.nSteConciliacionBancariaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteConciliacionBancaria ON C.nStbValorCatalogoID = SteConciliacionBancaria.nStbEstadoConciliacionID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteConciliacionBancaria.nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Conciliación no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            REM Conciliaciones pueden unicamente tener Saldo Inicial sin movimientos:
            'Imposible si no tiene Detalles de transacciones:
            'StrSql = "SELECT * FROM  SteConciliacionTransacciones WHERE (nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ")"
            'If (RegistrosAsociados(StrSql) = False) Then
            '    MsgBox("Aún no ha indicado las transacciones contables asociadas.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If

            'Confirmar Cierre de Conciliación Bancaria:
            If MsgBox("¿Está seguro de Cerrar la Conciliación Bancaria?" & Chr(13) & "No podrá modificar ninguno de sus datos.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Cerrar Conciliación:

                GuardarAuditoriaTablas(31, 2, "Actualizar SteConciliacionBancaria Cerrar", XdtConciliacion.ValueField("nSteConciliacionBancariaID"), InfoSistema.IDCuenta)

                StrSql = " Update SteConciliacionBancaria " & _
                         " SET nStbEstadoConciliacionID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoConciliacionBancaria')," & _
                         "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
                         " WHERE nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID")
                XdtInactivar.ExecuteSqlNotTable(StrSql)

                'Guardar posición actual de la selección: 
                intPosicion = XdtConciliacion.ValueField("nSteConciliacionBancariaID")
                'Refrescar Datos: 
                CargarConciliacion()
                XdtConciliacion.SetCurrentByID("nSteConciliacionBancariaID", intPosicion)
                Me.grdConciliacion.Row = XdtConciliacion.BindingSource.Position
                MsgBox("La Conciliación se cerró satisfactoriamente.", MsgBoxStyle.Information)
                Call GuardarAuditoria(5, 25, "Cierre de Conciliación Bancaria ID: " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtInactivar.Close()
            XdtInactivar = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       LlamaAnularConciliacion
    ' Descripción:          Este procedimiento permite Anular una Conciliación.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularConciliacion()
        Dim XdtAnular As New BOSistema.Win.SteEntTesoreria.SteConciliacionBancariaDataTable
        Dim XdrAnular As New BOSistema.Win.SteEntTesoreria.SteConciliacionBancariaRow

        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Try

            Dim Strsql As String
            Dim intPosicion As Long
            Dim strCausaAnulacion As String

            'No existen registros: 
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si ya esta Anulada: 
            Strsql = "SELECT SteConciliacionBancaria.nSteConciliacionBancariaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteConciliacionBancaria ON C.nStbValorCatalogoID = SteConciliacionBancaria.nStbEstadoConciliacionID " & _
                     "WHERE (C.sCodigoInterno = '3') AND (SteConciliacionBancaria.nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Conciliación se encuentra Anulada.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Valida si no esta En Proceso: 
            Strsql = "SELECT SteConciliacionBancaria.nSteConciliacionBancariaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteConciliacionBancaria ON C.nStbValorCatalogoID = SteConciliacionBancaria.nStbEstadoConciliacionID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteConciliacionBancaria.nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ")"
            If (RegistrosAsociados(Strsql) = False) Then
                MsgBox("Conciliación No se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Anular la Conciliación seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                'Solicita al Usuario la Causa de la Anulación:
                XdtAnular.Filter = " nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID")
                XdtAnular.Retrieve()
                XdrAnular = XdtAnular.Current

                ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                ObjFrmStbDatoComplemento.strTitulo = "Anulación de Conciliación"
                ObjFrmStbDatoComplemento.intAncho = XdrAnular.GetColumnLenght("sMotivoAnulacion")
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

                'Actualiza el Estado de la Conciliación a Anulada:

                GuardarAuditoriaTablas(31, 2, "Actualizar SteConciliacionBancaria Anular", XdtConciliacion.ValueField("nSteConciliacionBancariaID"), InfoSistema.IDCuenta)
                Strsql = " Update SteConciliacionBancaria " & _
                         " SET nStbEstadoConciliacionID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoConciliacionBancaria')," & _
                         "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate(), sMotivoAnulacion = '" & strCausaAnulacion & "'" & _
                         " WHERE nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID")
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                       "de forma satisfactoria.", MsgBoxStyle.Information)
                Call GuardarAuditoria(4, 25, "Anulación de Conciliación Bancaria ID: " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ").")
                'Guardar posición actual de la selección:
                intPosicion = XdtConciliacion.ValueField("nSteConciliacionBancariaID")
                CargarConciliacion()

                'Ubicar la selección en la posición original:
                XdtConciliacion.SetCurrentByID("nSteConciliacionBancariaID", intPosicion)
                Me.grdConciliacion.Row = XdtConciliacion.BindingSource.Position

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtAnular.Close()
            XdtAnular = Nothing

            XdrAnular.Close()
            XdrAnular = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       LlamaModificarConciliacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditConciliacion para Modificar una Conciliación.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarConciliacion()
        Dim ObjFrmSteEditConciliacion As New frmSteEditConciliacion
        Try
            Dim StrSql As String
            ObjFrmSteEditConciliacion.IntHabilito = 1

            'Si no existen registros: 
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si no tiene el estado "En Proceso": 
            StrSql = "SELECT SteConciliacionBancaria.nSteConciliacionBancariaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteConciliacionBancaria ON C.nStbValorCatalogoID = SteConciliacionBancaria.nStbEstadoConciliacionID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteConciliacionBancaria.nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Conciliación no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                ObjFrmSteEditConciliacion.IntHabilito = 0
            End If

            ObjFrmSteEditConciliacion.ModoFrm = "UPD"
            ObjFrmSteEditConciliacion.intSteConciliacionID = XdtConciliacion.ValueField("nSteConciliacionBancariaID")
            ObjFrmSteEditConciliacion.ShowDialog()

            CargarConciliacion()
            XdtConciliacion.SetCurrentByID("nSteConciliacionBancariaID", ObjFrmSteEditConciliacion.intSteConciliacionID)
            Me.grdConciliacion.Row = XdtConciliacion.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditConciliacion.Close()
            ObjFrmSteEditConciliacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
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
    ' Fecha:                01/02/2008
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
    ' Fecha:                01/02/2008
    ' Procedure Name:       grdConciliacion_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdConciliacion_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdConciliacion.Filter
        Try
            XdtConciliacion.FilterLocal(e.Condition)
            Me.grdConciliacion.Caption = " Listado de Conciliaciones Bancarias (" + Me.grdConciliacion.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Agregar:
            If Seg.HasPermission("AgregarConciliacion") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If
            'Modificar:
            If Seg.HasPermission("ModificarConciliacion") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If
            'Cerrar:
            If Seg.HasPermission("AplicarConciliacion") Then
                Me.toolCerrar.Enabled = True
            Else
                Me.toolCerrar.Enabled = False
            End If
            'Anular:
            If Seg.HasPermission("AnularConciliacion") Then
                Me.toolAnular.Enabled = True
            Else
                Me.toolAnular.Enabled = False
            End If

            '-- Imprimir:
            'Conciliacion Bancaria:
            If Seg.HasPermission("ImprimirConciliacionBancaria") Then
                Me.toolImprimirC.Enabled = True
            Else
                Me.toolImprimirC.Enabled = False
            End If
            'Anexo 1: Detalle de Depósitos en Tránsito:
            If Seg.HasPermission("ImprimirDetalleDepositosTransito") Then
                Me.toolImprimirA1.Enabled = True
            Else
                Me.toolImprimirA1.Enabled = False
            End If
            'Anexo 2: Detalle de Cheques Flotantes:
            If Seg.HasPermission("ImprimirDetalleChequesFlotantes") Then
                Me.toolImprimirA2.Enabled = True
            Else
                Me.toolImprimirA2.Enabled = False
            End If
            'Anexo 3: Detalle de Notas de Crédito:
            If Seg.HasPermission("ImprimirDetalleNotasCredito") Then
                Me.toolImprimirA3.Enabled = True
            Else
                Me.toolImprimirA3.Enabled = False
            End If
            'Anexo 4: Detalle de Notas de Débito:
            If Seg.HasPermission("ImprimirDetalleNotasDebito") Then
                Me.toolImprimirA4.Enabled = True
            Else
                Me.toolImprimirA4.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/02/2008
    ' Procedure Name:       grdConciliacion_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Conciliación al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdConciliacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdConciliacion.DoubleClick
        Try
            If Me.grdConciliacion.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarConciliacion") Then
                LlamaModificarConciliacion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdConciliacion_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdConciliacion.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2008
    ' Procedure Name:       toolImprimirC_Click
    ' Descripción:          Este evento permite Imprimir Formato de Conciliación 
    '                       Bancaria.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirC.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE7.rpt"
            frmVisor.Text = "Conciliación Bancaria"
            strSQL = " Select * " & _
                     " From vwSteConciliacionBancariaRep " & _
                     " WHERE (nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ") " & _
                     " Order by nSteConciliacionBancariaID"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/02/2008
    ' Procedure Name:       toolImprimirA1_Click
    ' Descripción:          Este evento permite Imprimir Detalle de Depósitos 
    '                       en Tránsito (Anexo 1) de Conciliaciones Bancarias.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirA1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirA1.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE8.rpt"
            frmVisor.Text = "Detalle de Depósitos en Tránsito (Anexo 1)"
            strSQL = " Select * " & _
                     " From vwSteConciliacionDocumentosRep " & _
                     " Where (TipoOperacion = 'DT') And (nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ") " & _
                     " Order by dFechaTransaccion"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/02/2008
    ' Procedure Name:       toolImprimirA2_Click
    ' Descripción:          Este evento permite Imprimir Detalle de Cheques 
    '                       Flotantes (Anexo 2) de Conciliaciones Bancarias.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirA2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirA2.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE9.rpt"
            frmVisor.Text = "Detalle de Cheques Flotantes (Anexo 2)"
            strSQL = " Select * " & _
                     " From vwSteConciliacionDocumentosRep " & _
                     " Where (TipoOperacion = 'CF') And (nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ") " & _
                     " Order by dFechaTransaccion"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/02/2008
    ' Procedure Name:       toolImprimirA3_Click
    ' Descripción:          Este evento permite Imprimir Detalle de Notas de
    '                       Crédito (Anexo 3) de Conciliaciones Bancarias.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirA3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirA3.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE10.rpt"
            frmVisor.Text = "Detalle de Notas de Crédito (Anexo 3)"
            strSQL = " Select * " & _
                     " From vwSteConciliacionDocumentosRep " & _
                     " WHERE (TipoOperacion = 'NC') And (nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ") " & _
                     " Order by dFechaTransaccion"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/02/2008
    ' Procedure Name:       toolImprimirA4_Click
    ' Descripción:          Este evento permite Imprimir Detalle de Notas de
    '                       Débito (Anexo 4) de Conciliaciones Bancarias.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirA4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirA4.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdConciliacion.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE11.rpt"
            frmVisor.Text = "Detalle de Notas de Débito (Anexo 4)"
            strSQL = " Select * " & _
                     " From vwSteConciliacionOperacionesRep " & _
                     " WHERE (nNotaDebito = 1) And (nSteConciliacionBancariaID = " & XdtConciliacion.ValueField("nSteConciliacionBancariaID") & ") " & _
                     " Order by dFechaRegistro"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub
End Class