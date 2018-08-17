' --------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                25/03/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccReestructuracionDeuda.vb
' Descripción:          Formulario de Reestructuración de Deuda a Socias de
'                       Grupos Solidario con FNC Aprobadas y con CK Emitido.
'---------------------------------------------------------------------------
Public Class frmSccReestructuracionDeuda
    '- Declaración de Variables 
    Dim XdsReestructuracion As BOSistema.Win.XDataSet

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       frmSclReestructuracionDeuda_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSccReestructuracionDeuda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsReestructuracion.Close()
            XdsReestructuracion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       frmSclReestructuracionDeuda_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Fichas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSccReestructuracionDeuda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaD.Select()

            InicializaVariables()
            CargarReestructuracion()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	25/03/2008
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
    ' Fecha:                25/03/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros de la Delegación:
            EncuentraParametros()

            XdsReestructuracion = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdFichas.ClearFields()
            Me.grdReestructuracion.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ----------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       CargarReestructuracion
    ' Descripción:          Este procedimiento permite cargar los datos de Fichas
    '                       de Notificación Aprobadas y con Cheque emitido.
    '-----------------------------------------------------------------------------
    Private Sub CargarReestructuracion()
        Try
            Dim Strsql As String

            'Maestro (Ficha de Notificación Aprobada y con Cheque emitido):
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
                         " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodTipoPlazoPagos " & _
                         " FROM vwSclFichasAprobadas AS a " & _
                         " WHERE (a.dFechaR BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                         " Order by a.nCodigo"
            Else 'Solo Filtra las Fichas de su Delegación: 
                Strsql = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
                         " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodTipoPlazoPagos " & _
                         " FROM vwSclFichasAprobadas AS a " & _
                         " WHERE (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (a.dFechaR BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                         " Order by a.nCodigo"
            End If

            If XdsReestructuracion.ExistTable("Ficha") Then
                XdsReestructuracion("Ficha").ExecuteSql(Strsql)
            Else
                XdsReestructuracion.NewTable(Strsql, "Ficha")
                XdsReestructuracion("Ficha").Retrieve()
            End If

            'Detalle: Reestructuraciones de Deuda: 
            Strsql = " SELECT a.nSclReestructuracionDeudaID, a.nCodigo, a.Estado, a.dFechaReestructuracion, " & _
                     " a.sObservaciones, a.Login, a.nSclFichaNotificacionID " & _
                     " FROM vwSclReestructuracion AS a  " & _
                     " ORDER BY a.nCodigo"
            If XdsReestructuracion.ExistTable("Reestructuracion") Then
                XdsReestructuracion("Reestructuracion").ExecuteSql(Strsql)
            Else
                XdsReestructuracion.NewTable(Strsql, "Reestructuracion")
                XdsReestructuracion("Reestructuracion").Retrieve()
            End If

            If XdsReestructuracion.ExistRelation("FichaConReestructuracion") = False Then
                'Creando la relación entre el Primer Query y el Segundo
                XdsReestructuracion.NewRelation("FichaConReestructuracion", "Ficha", "Reestructuracion", "nSclFichaNotificacionID", "nSclFichaNotificacionID")
            End If
            XdsReestructuracion.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdFichas.DataSource = XdsReestructuracion("Ficha").Source
            Me.grdReestructuracion.DataSource = XdsReestructuracion("Reestructuracion").Source

            'Actualizando el caption de los GRIDS
            Me.grdFichas.Caption = " Listado de Fichas de Notificación Aprobadas (" + Me.grdFichas.RowCount.ToString + " registros)"
            Me.grdReestructuracion.Caption = " Listado de Reestructuraciones de Deuda (" + Me.grdReestructuracion.RowCount.ToString + " registros)"
            FormatoReestructuracion()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       FormatoReestructuracion
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Grupos Solidarios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoReestructuracion()
        Try

            'Configuracion del Grid FNC: 
            Me.grdFichas.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("sCodEstado").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("dFechaFirmaActaCompromiso").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("nSclFNCOrigenID").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("dFechaR").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("EstadoSDC").Visible = False
            Me.grdFichas.Splits(0).DisplayColumns("CodTipoPlazoPagos").Visible = False

            Me.grdFichas.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdFichas.Splits(0).DisplayColumns("EstadoFicha").Width = 80
            Me.grdFichas.Splits(0).DisplayColumns("CodigoGS").Width = 120
            Me.grdFichas.Splits(0).DisplayColumns("sNombreGS").Width = 200
            Me.grdFichas.Splits(0).DisplayColumns("sNumSesion").Width = 80
            Me.grdFichas.Splits(0).DisplayColumns("dFechaNotificacion").Width = 130
            Me.grdFichas.Splits(0).DisplayColumns("dFechaHoraEntregaCK").Width = 100
            Me.grdFichas.Splits(0).DisplayColumns("sUsuarioCreacion").Width = 100
            Me.grdFichas.Splits(0).DisplayColumns("NombreCoordinadora").Width = 200
            Me.grdFichas.Splits(0).DisplayColumns("TelefonoCoordinadora").Width = 100

            Me.grdFichas.Columns("nCodigo").Caption = "Código"
            Me.grdFichas.Columns("CodigoGS").Caption = "Código Grupo"
            Me.grdFichas.Columns("sNombreGS").Caption = "Nombre Grupo Solidario"
            Me.grdFichas.Columns("sNumSesion").Caption = "No. Sesión"
            Me.grdFichas.Columns("dFechaNotificacion").Caption = "Fecha Resolución"
            Me.grdFichas.Columns("dFechaHoraEntregaCK").Caption = "Fecha Entrega CK"
            Me.grdFichas.Columns("EstadoFicha").Caption = "Estado Crédito"
            Me.grdFichas.Columns("sUsuarioCreacion").Caption = "Elaborado Por"
            Me.grdFichas.Columns("NombreCoordinadora").Caption = "Coordinadora"
            Me.grdFichas.Columns("TelefonoCoordinadora").Caption = "Teléfono"

            Me.grdFichas.Splits(0).DisplayColumns("CodigoGS").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdFichas.Splits(0).DisplayColumns("dFechaNotificacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("dFechaHoraEntregaCK").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdFichas.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("CodigoGS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("sNombreGS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("sNumSesion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("dFechaNotificacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("dFechaHoraEntregaCK").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("EstadoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("sUsuarioCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("NombreCoordinadora").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFichas.Splits(0).DisplayColumns("TelefonoCoordinadora").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdFichas.Columns("dFechaNotificacion").NumberFormat = "dd/MM/yyyy hh:mm tt"

            'Configuracion del Grid Reestructuracion del Deuda:
            Me.grdReestructuracion.Splits(0).DisplayColumns("nSclReestructuracionDeudaID").Visible = False
            Me.grdReestructuracion.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False

            Me.grdReestructuracion.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdReestructuracion.Splits(0).DisplayColumns("Estado").Width = 80
            Me.grdReestructuracion.Splits(0).DisplayColumns("dFechaReestructuracion").Width = 120
            Me.grdReestructuracion.Splits(0).DisplayColumns("sObservaciones").Width = 450
            Me.grdReestructuracion.Splits(0).DisplayColumns("Login").Width = 100

            Me.grdReestructuracion.Columns("Estado").Caption = "Estado"
            Me.grdReestructuracion.Columns("nCodigo").Caption = "Código"
            Me.grdReestructuracion.Columns("dFechaReestructuracion").Caption = "F. Reestructuración"
            Me.grdReestructuracion.Columns("sObservaciones").Caption = "Observaciones"
            Me.grdReestructuracion.Columns("Login").Caption = "Elaborado Por"

            Me.grdReestructuracion.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReestructuracion.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReestructuracion.Splits(0).DisplayColumns("dFechaReestructuracion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReestructuracion.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReestructuracion.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       tbFicha_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbFicha.
    '-------------------------------------------------------------------------
    Private Sub tbFicha_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Select Case e.ClickedItem.Name
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

                InicializaVariables()
                CargarReestructuracion()
                FormatoReestructuracion()

            Case "toolListadoR"
                LlamaImprimirListadoR()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       tbReestructuracion_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbReestructuracion.
    '-------------------------------------------------------------------------
    Private Sub tbReestructuracion_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReestructuracion.ItemClicked
        Dim StrSql As String
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarReestructuracion()
            Case "toolModificar"
                LlamaModificarReestructuracion()
            Case "toolAnular"
                LlamaAnularReestructuracion()
            Case "toolAplicar"
                LlamaAplicarReestructuracion()
            Case "toolTablasAmortizacion"
                'No existen registros de FNC Aprobadas y con Cheque Emitido:
                If Me.grdFichas.RowCount = 0 Then
                    MsgBox("No Existen Fichas Aprobadas.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Imposible si no hay Reestructuraciones para la Ficha:
                If Me.grdReestructuracion.RowCount = 0 Then
                    MsgBox("No Existen Reestructuraciones para la Ficha.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Imposible si la Reestructuración No se encuentra Aplicada:
                StrSql = "SELECT SclReestructuracionDeuda.nSclReestructuracionDeudaID " & _
                         "FROM StbValorCatalogo AS C INNER JOIN SclReestructuracionDeuda ON C.nStbValorCatalogoID = SclReestructuracionDeuda.nStbEstadoReestructuracionID " & _
                         "WHERE (C.sCodigoInterno = '2') AND (SclReestructuracionDeuda.nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ")"
                If (RegistrosAsociados(StrSql) = False) Then
                    MsgBox("Reestructuración no se encuentra Aplicada.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If

                '-- Llama a Impresión del Listado:
                LlamaImprimirTA()

            Case "toolAyudaR"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/03/2008
    ' Procedure Name:       LlamaImprimirListadoR
    ' Descripción:          Permite Imprimir Listado de Reestructuraciones 
    '                       para la Ficha de Notificación indicada.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirListadoR()
        Dim frmVisor As New frmCRVisorReporte
        Try

            Dim strSQL As String = ""
            'No existen registros de FNC Aprobadas y con Cheque Emitido:
            If Me.grdFichas.RowCount = 0 Then
                MsgBox("No Existen Fichas Aprobadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si no hay Reestructuraciones para la Ficha:
            If Me.grdReestructuracion.RowCount = 0 Then
                MsgBox("No Existen Reestructuraciones para la Ficha.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSccCC23.rpt"
            frmVisor.Text = "Listado de Reestructuraciones de Crédito"
            If IntPermiteConsultar = 1 Then
                frmVisor.SQLQuery = "Select * From vwSclReestructuracionRep " & _
                                    "Where (nSclFichaNotificacionID = " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ") " & _
                                    "Order by nSclFichaNotificacionID, CodigoReestructuracion, nSclFichaSociaID, nCoordinador Desc"
            Else
                frmVisor.SQLQuery = "Select * From vwSclReestructuracionRep " & _
                                    "Where (nSclFichaNotificacionID = " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ")  And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                                    "Order By nSclFichaNotificacionID, CodigoReestructuracion, nSclFichaSociaID, nCoordinador Desc"
            End If
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/03/2008
    ' Procedure Name:       LlamaImprimirTA
    ' Descripción:          Este evento permite Imprimir Tabla de Amortización 
    '                       para la Reestructuración indicada.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirTA()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            Dim nTasaIntCorriente As Double
            Dim nTasaMantValor As Double

            Me.Cursor = Cursors.WaitCursor

            'Obtener parámetro de Tasa de Interés Corriente:
            strSQL = " Select sValorParametro " & _
                     " FROM StbValorParametro " & _
                     " WHERE (nStbValorParametroID = 1) "
            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                nTasaIntCorriente = XdtDatos.ValueField("sValorParametro")
            End If

            'Obtener parámetro de Tasa de Mantenimiento al Valor:
            strSQL = " Select sValorParametro " & _
                     " FROM StbValorParametro " & _
                     " WHERE (nStbValorParametroID = 2) "
            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                nTasaMantValor = XdtDatos.ValueField("sValorParametro")
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSclCS10r.rpt"
            frmVisor.Formulas("Interes") = nTasaIntCorriente
            frmVisor.Formulas("Mantenimiento") = nTasaMantValor
            frmVisor.Text = "Listado de Tablas de Amortización"
            frmVisor.SQLQuery = " Select * From vwSclTablaAmortizacionDetalleReporteR " & _
                                " Where (IdReestructuracion = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ") And (nSclFichaNotificacionID= " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ") " & _
                                " Order by nSclFichaNotificacionID, nSclFichaSociaID, nNumCuota "
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'frmVisor.Close()
            frmVisor = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       LlamaAgregarReestructuracion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditReestructuracionDeuda para Agregar una 
    '                       Reestructuracion de Deuda.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarReestructuracion()
        Dim ObjFrmSclEditReestructuracion As New frmSccEditReestructuracionDeuda
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim strSQL As String

            'No existen registros de FNC Aprobadas y con Cheque Emitido:
            If Me.grdFichas.RowCount = 0 Then
                MsgBox("No Existen Fichas Aprobadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si hay Reestructuraciones En Proceso para la Ficha:
            strSQL = "SELECT SclReestructuracionDeuda.nSclReestructuracionDeudaID " & _
                     "FROM SclReestructuracionDeuda INNER JOIN StbValorCatalogo ON SclReestructuracionDeuda.nStbEstadoReestructuracionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE  (SclReestructuracionDeuda.nSclFichaNotificacionID = " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ") AND (StbValorCatalogo.sCodigoInterno = '1')"

            If RegistrosAsociados(strSQL) Then
                MsgBox("Existe Reestructuración En Proceso para la Ficha de Notificación.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsReestructuracion("Ficha").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible agregar Reestructuraciones de Deuda de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Ficha No tiene ninguna Cuota Pendiente de Pago:
            strSQL = "SELECT DFNC.nSclFichaNotificacionID " & _
                     "FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (DFNC.nSclFichaNotificacionID = " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("La Ficha de Notificación no tiene Socias con" & Chr(13) & "Cuotas Pendientes de Pago.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditReestructuracion.ModoFrm = "ADD"
            ObjFrmSclEditReestructuracion.intSclFichaID = XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID")
            ObjFrmSclEditReestructuracion.intSclReestructuracionID = 0
            ObjFrmSclEditReestructuracion.ShowDialog()

            'Si se ingreso el registro correctamente:
            If ObjFrmSclEditReestructuracion.intSclReestructuracionID <> 0 Then
                CargarReestructuracion()
                'Se ubica sobre la Ficha:
                XdsReestructuracion("Ficha").SetCurrentByID("nSclFichaNotificacionID", ObjFrmSclEditReestructuracion.intSclFichaID)
                Me.grdFichas.Row = XdsReestructuracion("Ficha").BindingSource.Position
                'Se ubica sobre la Reestructuración recien ingresada:
                XdsReestructuracion("Reestructuracion").SetCurrentByID("nSclReestructuracionDeudaID", ObjFrmSclEditReestructuracion.intSclReestructuracionID)
                Me.grdReestructuracion.Row = XdsReestructuracion("Reestructuracion").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReestructuracion.Close()
            ObjFrmSclEditReestructuracion = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       LlamaModificarReestructuracion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditReestructuracionDeuda para modificar
    '                       los datos de la misma en caso de encontrarse
    '                       En Proceso.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarReestructuracion()
        Dim ObjFrmSclEditReestructuracion As New frmSccEditReestructuracionDeuda
        Try
            Dim StrSql As String
            ObjFrmSclEditReestructuracion.IntHabilito = 1

            'Si no hay registros ingresados salir del Sub:
            If Me.grdReestructuracion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Reestructuracion No esta En Proceso:
            StrSql = "SELECT SclReestructuracionDeuda.nSclReestructuracionDeudaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SclReestructuracionDeuda ON C.nStbValorCatalogoID = SclReestructuracionDeuda.nStbEstadoReestructuracionID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SclReestructuracionDeuda.nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Reestructuración no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                ObjFrmSclEditReestructuracion.IntHabilito = 0
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsReestructuracion("Ficha").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Reestructuraciones de Deuda de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Indicador de Actualización:
            ObjFrmSclEditReestructuracion.ModoFrm = "UPD"
            ObjFrmSclEditReestructuracion.intSclFichaID = XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID")
            ObjFrmSclEditReestructuracion.intSclReestructuracionID = XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID")
            ObjFrmSclEditReestructuracion.ShowDialog()
            CargarReestructuracion()
            XdsReestructuracion("Reestructuracion").SetCurrentByID("nSclReestructuracionDeudaID", ObjFrmSclEditReestructuracion.intSclReestructuracionID)
            Me.grdReestructuracion.Row = XdsReestructuracion("Reestructuracion").BindingSource.Position
            'Se ubica sobre la Ficha:
            XdsReestructuracion("Ficha").SetCurrentByID("nSclFichaNotificacionID", ObjFrmSclEditReestructuracion.intSclFichaID)
            Me.grdFichas.Row = XdsReestructuracion("Ficha").BindingSource.Position
            'Se ubica sobre la Reestructuración recien ingresada:
            XdsReestructuracion("Reestructuracion").SetCurrentByID("nSclReestructuracionDeudaID", ObjFrmSclEditReestructuracion.intSclReestructuracionID)
            Me.grdReestructuracion.Row = XdsReestructuracion("Reestructuracion").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmSclEditReestructuracion.Close()
            ObjFrmSclEditReestructuracion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       LlamaAnularReestructuracion
    ' Descripción:          Este procedimiento permite Anular Reestructuraciones
    '                       En Proceso.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularReestructuracion()
        Dim XdtAnularR As New BOSistema.Win.XDataSet.xDataTable
        Dim StrSql As String = ""
        Try

            Dim intPosicion As Integer
            Dim intPosicionS As Integer

            'No existen registros:
            If Me.grdReestructuracion.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Reestructuracion No esta En Proceso:
            StrSql = "SELECT SclReestructuracionDeuda.nSclReestructuracionDeudaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SclReestructuracionDeuda ON C.nStbValorCatalogoID = SclReestructuracionDeuda.nStbEstadoReestructuracionID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SclReestructuracionDeuda.nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Reestructuración no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsReestructuracion("Ficha").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Reestructuraciones de Deuda de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Confirmar Cambio:
            If MsgBox("¿Está seguro de Anular la Reestructuración" & Chr(13) & _
                      "de Deuda seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            intPosicion = XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID")
            intPosicionS = XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID")

            'Anular Reestructuración de la Deuda:
            StrSql = " Update SclReestructuracionDeuda " & _
                     " SET nUsuariomodificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nStbEstadoReestructuracionID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReestructuracion')" & _
                     " WHERE nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID")
            XdtAnularR.ExecuteSqlNotTable(StrSql)

            'Refrescar Datos:
            CargarReestructuracion()
            'Refrescar Fichas:
            XdsReestructuracion("Ficha").SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFichas.Row = XdsReestructuracion("Ficha").BindingSource.Position
            'Refrescar Reestructuración:
            XdsReestructuracion("Reestructuracion").SetCurrentByID("nSclReestructuracionDeudaID", intPosicionS)
            Me.grdReestructuracion.Row = XdsReestructuracion("Reestructuracion").BindingSource.Position
            MsgBox("El cambio se efectuó satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Call GuardarAuditoria(4, 23, "Anulación de Reestructuración de Deuda ID: " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ").")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XdtAnularR.Close()
            XdtAnularR = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Gamaliel Mejía
    ' Fecha:                25/03/2008
    ' Procedure Name:       LlamaAplicarReestructuracion
    ' Descripción:          Este procedimiento permite Aplicar 
    '                       Reestructuraciones En Proceso.
    '-------------------------------------------------------------------------
    Private Sub LlamaAplicarReestructuracion()
        Dim StrSql As String = ""
        Dim XdtTmpSocias As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Try

            Dim intPosicion As Integer
            Dim intPosicionS As Integer
            Dim IntTotalSociasR As Integer

            'No existen registros:
            If Me.grdReestructuracion.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Reestructuracion No esta En Proceso:
            StrSql = "SELECT SclReestructuracionDeuda.nSclReestructuracionDeudaID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SclReestructuracionDeuda ON C.nStbValorCatalogoID = SclReestructuracionDeuda.nStbEstadoReestructuracionID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SclReestructuracionDeuda.nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Reestructuración no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsReestructuracion("Ficha").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Aplicar Reestructuraciones de Deuda de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si no se han ingresado a todas las Socias de la FNC que tienen El Credito Aprobado:
            '-- Conteo de Socias en La Reestructuración:
            StrSql = "SELECT COUNT(*) AS Total FROM SclReestructuracionDeudaDetalles WHERE (nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ")"
            IntTotalSociasR = XcDatosSocias.ExecuteScalar(StrSql)
            '-- Conteo de Socias con el Credito Aprobado En la Ficha:
            StrSql = "SELECT COUNT(*) AS Conteo FROM  SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ") AND (nCreditoRechazado = 0)"
            If IntTotalSociasR <> XcDatosSocias.ExecuteScalar(StrSql) Then
                MsgBox("Imposible Aplicar Reestructuraciones." & Chr(13) & Chr(13) & _
                       "Antes Debe registrar a Todas las Socias con el Crédito" & Chr(13) & _
                       "Aprobado para la Ficha de Notificación Seleccionada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si las Socias tienen Plazos diferentes dentro de la Reestructuración:
            XdtTmpSocias = New BOSistema.Win.XDataSet.xDataTable
            StrSql = "SELECT SclReestructuracionDeudaDetalles.nPlazoAprobado FROM  SclReestructuracionDeudaDetalles INNER JOIN SclFichaNotificacionDetalle ON  SclReestructuracionDeudaDetalles.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID " & _
                     "WHERE (nSclFichaNotificacionID = " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ") AND (SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ") GROUP BY SclReestructuracionDeudaDetalles.nPlazoAprobado"
            XdtTmpSocias.ExecuteSql(StrSql)
            If XdtTmpSocias.Count > 1 Then
                MsgBox("Las Socias tienen diferentes PLAZOS Aprobados en la Reestructuración.", MsgBoxStyle.Critical, NombreSistema)
                XdtTmpSocias.Close()
                XdtTmpSocias = Nothing
                Exit Sub
            End If
            XdtTmpSocias.Close()
            XdtTmpSocias = Nothing

            'Imposible si las Socias tienen Fechas de Primer Pago diferentes dentro de la Reestructuración:
            XdtTmpSocias = New BOSistema.Win.XDataSet.xDataTable
            StrSql = "SELECT SclReestructuracionDeudaDetalles.dFechaPrimerCuota FROM  SclReestructuracionDeudaDetalles INNER JOIN SclFichaNotificacionDetalle ON  SclReestructuracionDeudaDetalles.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID " & _
                     "WHERE (nSclFichaNotificacionID = " & XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID") & ") AND (SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaID = " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ") GROUP BY SclReestructuracionDeudaDetalles.dFechaPrimerCuota"
            XdtTmpSocias.ExecuteSql(StrSql)
            If XdtTmpSocias.Count > 1 Then
                MsgBox("Las Socias tienen diferentes Fechas de Primer Pago en la Reestructuración.", MsgBoxStyle.Critical, NombreSistema)
                XdtTmpSocias.Close()
                XdtTmpSocias = Nothing
                Exit Sub
            End If
            XdtTmpSocias.Close()
            XdtTmpSocias = Nothing

            'Confirmar Cambio:
            If MsgBox("¿Está seguro de Aplicar la Reestructuración" & Chr(13) & _
                      "de Deuda seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            intPosicion = XdsReestructuracion("Ficha").ValueField("nSclFichaNotificacionID")
            intPosicionS = XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID")

            '==========================================================================
            'Aplicar Reestructuración de la Deuda:
            '==========================================================================
            StrSql = "EXEC spSccGenerarTablaAmortizacionReestructuracion " & XdsReestructuracion("Reestructuracion").ValueField("nSclReestructuracionDeudaID") & ",'" & InfoSistema.LoginName & "', '" & XdsReestructuracion("Ficha").ValueField("CodTipoPlazoPagos") & "'"
            IntTotalSociasR = -2
            IntTotalSociasR = XcDatosSocias.ExecuteScalar(StrSql)
            Select Case IntTotalSociasR
                Case -1
                    MsgBox(" Fallo interno al generar la tablas de amortizacion para la reestructuración de este grupo", MsgBoxStyle.Information, NombreSistema)
                Case 0
                    MsgBox(" Se aplico la generación de tablas de amortizacion para la reestructuración de este grupo", MsgBoxStyle.Information, NombreSistema)
            End Select

            'Refrescar Datos:
            CargarReestructuracion()
            XdsReestructuracion("Ficha").SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFichas.Row = XdsReestructuracion("Ficha").BindingSource.Position
            XdsReestructuracion("Reestructuracion").SetCurrentByID("nSclReestructuracionDeudaID", intPosicionS)
            Me.grdReestructuracion.Row = XdsReestructuracion("Reestructuracion").BindingSource.Position
            MsgBox("El cambio se efectuó satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatosSocias.Close()
            XcDatosSocias = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite Salir de la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2007
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

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFichas_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdFichas.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       grdFichas_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdFichas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFichas.Filter
        Try
            XdsReestructuracion("Ficha").FilterLocal(e.Condition)
            Me.grdFichas.Caption = " Listado de Fichas de Notificación Aprobadas (" + Me.grdFichas.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Agregar Reestructuración:
            If Seg.HasPermission("AgregarReestructuracion") = False Then
                Me.tbReestructuracion.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbReestructuracion.Items("toolAgregar").Enabled = True
            End If

            'Modificar Reestructuración:
            If Seg.HasPermission("ModificarReestructuracion") = False Then
                Me.tbReestructuracion.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbReestructuracion.Items("toolModificar").Enabled = True
            End If

            'Anular Reestructuración:
            If Seg.HasPermission("AplicarReestructuracion") = False Then
                Me.tbReestructuracion.Items("toolAplicar").Enabled = False
            Else  'Habilita
                Me.tbReestructuracion.Items("toolAplicar").Enabled = True
            End If

            'Aplicar Reestructuración:
            If Seg.HasPermission("AnularReestructuracion") = False Then
                Me.tbReestructuracion.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbReestructuracion.Items("toolAnular").Enabled = True
            End If

            '-- Listados:
            'Listado de Reestructuraciones:
            If Seg.HasPermission("ImprimirListadoReestructuraciones") = False Then
                Me.tbFicha.Items("toolListadoR").Enabled = False
            Else  'Habilita
                Me.tbFicha.Items("toolListadoR").Enabled = True
            End If
            'Tablas de Amortización para una determinada Reestructuración de Deuda:
            If Seg.HasPermission("ImprimirTablasAmortizacionReestructuradas") = False Then
                Me.tbReestructuracion.Items("toolTablasAmortizacion").Enabled = False
            Else  'Habilita
                Me.tbReestructuracion.Items("toolTablasAmortizacion").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       grdFichas_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Reestructuracion con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdFichas_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdFichas.RowColChange
        Me.grdReestructuracion.Caption = " Listado de Reestructuraciones de Deuda (" + Me.grdReestructuracion.RowCount.ToString + " registros)"
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       grdReestructuracion_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Reestructuración, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdReestructuracion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdReestructuracion.DoubleClick
        Try
            If Seg.HasPermission("ModificarReestructuracion") Then
                LlamaModificarReestructuracion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdReestructuracion_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdReestructuracion.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/03/2008
    ' Procedure Name:       grdReestructuracion_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdReestructuracion_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdReestructuracion.Filter
        Try
            XdsReestructuracion("Reestructuracion").FilterLocal(e.Condition)
            Me.grdReestructuracion.Caption = " Listado de Reestructuraciones de Deudas (" + Me.grdReestructuracion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cdeFechaH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaH.TextChanged

    End Sub

    Private Sub C1Sizer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Sizer1.Click

    End Sub

    Private Sub toolAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAplicar.Click

    End Sub
End Class