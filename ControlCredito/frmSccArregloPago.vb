' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                06/10/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccArregloPago.vb
' Descripción:          Este formulario carga arreglos de pagos por socias.
'-------------------------------------------------------------------------
Public Class frmSccArregloPago

    '- Declaración de Variables 
    Dim XdtArregloPago As BOSistema.Win.XDataSet.xDataTable
    Dim StrCadena As String
    Dim intArregloPagoID As Integer

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/10/2009
    ' Procedure Name:       frmSccArregloPago_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSccArregloPago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtArregloPago.Close()
            XdtArregloPago = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/10/2009
    ' Procedure Name:       frmSccArregloPago_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Arqueos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSccArregloPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            StrCadena = " WHERE (a.nSccArregloPagoID = 0) " 'Al cargar Grid en Blanco
            InicializaVariables()
            CargarArregloPago(StrCadena)
            FormatoArregloPago()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	06/10/2009
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
    ' Fecha:                06/10/2009
    ' Procedure Name:       CargarArregloPago
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de Arreglos de Pago en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarArregloPago(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nSccArregloPagoID, a.nSrhTecnicoID, a.nStbDelegacionProgramaID, a.nSclFichaNotificacionDetalleID, a.nSclSociaID, a.sCodigoInterno,  " & _
                     " a.EstadoArreglo, a.nNumeroArregloPago, a.dFechaArregloPago, a.GrupoSolidario, a.Socia, a.sNumeroCedula, a.nMontoArregloPago, a.NombreTecnico " & _
                     " FROM vwSccArregloPago AS a " & sCadenaFiltro & _
                     " Order by a.dFechaArregloPago"
            XdtArregloPago.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdArregloPago.DataSource = XdtArregloPago.Source
            Me.grdArregloPago.Caption = " Listado de Arreglos de Pago (" + Me.grdArregloPago.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/10/2009
    ' Procedure Name:       FormatoArregloPago
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre el Arqueo en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoArregloPago()
        Try

            'Configuración del Grid: 
            Me.grdArregloPago.Splits(0).DisplayColumns("nSccArregloPagoID").Visible = False
            Me.grdArregloPago.Splits(0).DisplayColumns("nSrhTecnicoID").Visible = False
            Me.grdArregloPago.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdArregloPago.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdArregloPago.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdArregloPago.Splits(0).DisplayColumns("sCodigoInterno").Visible = False

            Me.grdArregloPago.Splits(0).DisplayColumns("EstadoArreglo").Width = 80
            Me.grdArregloPago.Splits(0).DisplayColumns("dFechaArregloPago").Width = 80
            Me.grdArregloPago.Splits(0).DisplayColumns("GrupoSolidario").Width = 200
            Me.grdArregloPago.Splits(0).DisplayColumns("Socia").Width = 250
            Me.grdArregloPago.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdArregloPago.Splits(0).DisplayColumns("nNumeroArregloPago").Width = 60
            Me.grdArregloPago.Splits(0).DisplayColumns("nMontoArregloPago").Width = 80
            Me.grdArregloPago.Splits(0).DisplayColumns("NombreTecnico").Width = 200

            Me.grdArregloPago.Columns("EstadoArreglo").Caption = "Estado"
            Me.grdArregloPago.Columns("dFechaArregloPago").Caption = "Fecha Arreglo"
            Me.grdArregloPago.Columns("GrupoSolidario").Caption = "Grupo Solidario"
            Me.grdArregloPago.Columns("Socia").Caption = "Socia"
            Me.grdArregloPago.Columns("sNumeroCedula").Caption = "Cédula Socia"
            Me.grdArregloPago.Columns("nNumeroArregloPago").Caption = "No. Arreglo"
            Me.grdArregloPago.Columns("nMontoArregloPago").Caption = "Monto C$"
            Me.grdArregloPago.Columns("NombreTecnico").Caption = "Nombre del Técnico"

            Me.grdArregloPago.Splits(0).DisplayColumns("nNumeroArregloPago").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdArregloPago.Splits(0).DisplayColumns("dFechaArregloPago").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdArregloPago.Splits(0).DisplayColumns("EstadoArreglo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArregloPago.Splits(0).DisplayColumns("dFechaArregloPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArregloPago.Splits(0).DisplayColumns("GrupoSolidario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArregloPago.Splits(0).DisplayColumns("Socia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArregloPago.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArregloPago.Splits(0).DisplayColumns("nNumeroArregloPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArregloPago.Splits(0).DisplayColumns("nMontoArregloPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArregloPago.Splits(0).DisplayColumns("NombreTecnico").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formato de Fecha/Hora:
            Me.grdArregloPago.Columns("dFechaArregloPago").NumberFormat = "dd/MM/yyyy"
            Me.grdArregloPago.Columns("nMontoArregloPago").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/10/2009
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            '-- Encuentra parámetros de Delegación.
            EncuentraParametros()

            XdtArregloPago = New BOSistema.Win.XDataSet.xDataTable
            Me.Text = "Arreglos de Pago"
            'Limpiar los Grids, estructura y Datos
            Me.grdArregloPago.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/10/2009
    ' Procedure Name:       LlamaBuscarArregloPago
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccBusquedaArreglosPago para buscar con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarArregloPago()
        Dim ObjFrmSccBusquedaArreglosPago As New frmSclBusquedaFichasSeguimiento
        Try

            ObjFrmSccBusquedaArreglosPago.StrCriterioFicha = "0" 'Sin Criterio de Busqueda
            ObjFrmSccBusquedaArreglosPago.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSccBusquedaArreglosPago.IdTipoBusqueda = 2 'Busqueda para Arreglos de Pago.
            ObjFrmSccBusquedaArreglosPago.ShowDialog()
            If ObjFrmSccBusquedaArreglosPago.StrCriterioFicha <> "0" Then
                StrCadena = ObjFrmSccBusquedaArreglosPago.StrCriterioFicha
                CargarArregloPago(StrCadena)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccBusquedaArreglosPago.Close()
            ObjFrmSccBusquedaArreglosPago = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/10/2009
    ' Procedure Name:       tbArregloPago_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbArqueo.
    '-------------------------------------------------------------------------
    Private Sub tbArregloPago_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbArregloPago.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscarArregloPago()
            Case "toolAgregar"
                LlamaAgregarArregloPago()
            Case "toolModificar"
                LlamaModificarArregloPago()
            Case "toolAplicar"
                LlamaAplicarArregloPago()
            Case "toolAnular"
                LlamaAnularArregloPago()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolSalir"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/10/2009
    ' Procedure Name:       LlamaAgregarArregloPago
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditArregloPago.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarArregloPago()
        Dim ObjFrmSclEditArreglo As New frmSccEditArregloPago
        Try

            ObjFrmSclEditArreglo.ModoFrm = "ADD"
            ObjFrmSclEditArreglo.intStePermiteEditar = IntPermiteEditar
            ObjFrmSclEditArreglo.ShowDialog()

            'Si se ingreso un nuevo registro (Carga el Grid solo con este registro):
            If ObjFrmSclEditArreglo.intArregloID <> 0 Then
                StrCadena = "Where (a.nSccArregloPagoID = " & ObjFrmSclEditArreglo.intArregloID & ")"
                CargarArregloPago(StrCadena)
                XdtArregloPago.SetCurrentByID("nSccArregloPagoID", ObjFrmSclEditArreglo.intArregloID)
                Me.grdArregloPago.Row = XdtArregloPago.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditArreglo.Close()
            ObjFrmSclEditArreglo = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/10/2009
    ' Procedure Name:       LlamaAplicarArregloPago
    ' Descripción:          Este procedimiento permite Aplicar un Arreglo 
    '                       de Pago en Proceso impidiendo con ello posteriores 
    '                       Modificaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaAplicarArregloPago()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim Strsql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.

            'No existen registros: 
            If Me.grdArregloPago.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArregloPago.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Aplicar Arreglos de Pagos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no se encuentra En Proceso: 
            Strsql = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SccArregloPago ON C.nStbValorCatalogoID = SccArregloPago.nStbEstadoArregloPagoID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SccArregloPago.nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID") & ")"
            If (RegistrosAsociados(Strsql) = False) Then
                MsgBox("Arreglo de Pago NO se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Aplicar si existen Arreglos de Pago inferiores En Proceso para la Socia
            '(antes debe de aplicar los arreglos de pago anteriores de la Socia):
            Strsql = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM SccArregloPago INNER JOIN SclFichaNotificacionDetalle ON SccArregloPago.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID " & _
                     "INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID INNER JOIN SclSocia ON SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SclSocia.sNumeroCedula = '" & XdtArregloPago.ValueField("sNumeroCedula") & "') AND  (SccArregloPago.dFechaArregloPago < CONVERT(DATETIME, '" & Format(XdtArregloPago.ValueField("dFechaArregloPago"), "yyyy-MM-dd") & "', 102))"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Existen Arreglos de Pago Activos" & Chr(13) & "con fecha inferior que aún se encuentran En Proceso." _
                       & Chr(13) & "Antes Aplique los Arreglos de Pago anteriores para la Socia.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible aplicar si la suma de las cuotas es diferente al monto
            'total del arreglo de pago:
            Strsql = "SELECT ISNULL(SUM(nMontoCuota), 0) AS Cuotas FROM SccArregloPagoDetalle " & _
                     "WHERE (nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID") & ")"
            If CDbl(XcDatos.ExecuteScalar(Strsql)) <> CDbl(XdtArregloPago.ValueField("nMontoArregloPago")) Then
                MsgBox("Suma de cuotas no corresponden al monto del arreglo de pago.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Aplicar Arreglo de Pago seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                'Actualizar el Estado a Aplicado:
                Strsql = " Update SccArregloPago " & _
                         " SET nStbEstadoArregloPagoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoArregloPago')," & _
                         "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate()" & _
                         " WHERE nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID")
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("El registro seleccionado se ha Aplicado " & Chr(10) & _
                       "de forma satisfactoria.", MsgBoxStyle.Information)
                'Guardar posición actual de la selección:
                intPosicion = XdtArregloPago.ValueField("nSccArregloPagoID")
                Call GuardarAuditoria(5, 23, "Aplicación Arreglo de Pago ID: " & XdtArregloPago.ValueField("nSccArregloPagoID") & ".")
                CargarArregloPago(StrCadena)

                'Ubicar la selección en la posición original:
                XdtArregloPago.SetCurrentByID("nSccArregloPagoID", intPosicion)
                Me.grdArregloPago.Row = XdtArregloPago.BindingSource.Position

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
    ' Fecha:                08/10/2009
    ' Procedure Name:       LlamaAnularArregloPago
    ' Descripción:          Este procedimiento permite Anular un Arreglo de 
    '                       Pago.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularArregloPago()
        Dim XdtAnular As New BOSistema.Win.SccEntCartera.SccArregloPagoDataTable
        Dim XdrAnular As New BOSistema.Win.SccEntCartera.SccArregloPagoRow

        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Try

            Dim Strsql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.
            Dim strCausaAnulacion As String

            'No existen registros: 
            If Me.grdArregloPago.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArregloPago.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Arreglos de Pago de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no se encuentra En Proceso: 
            Strsql = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SccArregloPago ON C.nStbValorCatalogoID = SccArregloPago.nStbEstadoArregloPagoID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SccArregloPago.nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID") & ")"
            If (RegistrosAsociados(Strsql) = False) Then
                MsgBox("Arreglo de Pago NO se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Valida si ya esta Anulado: 
            Strsql = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SccArregloPago ON C.nStbValorCatalogoID = SccArregloPago.nStbEstadoArregloPagoID " & _
                     "WHERE (C.sCodigoInterno = '3') AND (SccArregloPago.nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Arreglo de Pago se encuentra Anulado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Anular si existen Arreglos de Pago superiores y ACTIVOS para la Socia:
            Strsql = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM SccArregloPago INNER JOIN SclFichaNotificacionDetalle ON SccArregloPago.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID " & _
                     "INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID INNER JOIN SclSocia ON SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (SclSocia.sNumeroCedula = '" & XdtArregloPago.ValueField("sNumeroCedula") & "') AND  (SccArregloPago.dFechaArregloPago > CONVERT(DATETIME, '" & Format(XdtArregloPago.ValueField("dFechaArregloPago"), "yyyy-MM-dd") & "', 102))"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Existen Arreglos de Pago Activos con fecha superior.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Anular el Arreglo de Pago seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                'Solicita al Usuario la Causa de la Anulación:
                XdtAnular.Filter = " nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID")
                XdtAnular.Retrieve()
                XdrAnular = XdtAnular.Current

                ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                ObjFrmStbDatoComplemento.strTitulo = "Anulación de Arreglo de Pago"
                ObjFrmStbDatoComplemento.intAncho = XdrAnular.GetColumnLenght("sMotivoAnulacion")
                ObjFrmStbDatoComplemento.strDato = ""
                ObjFrmStbDatoComplemento.strColor = "Verde"
                ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                ObjFrmStbDatoComplemento.ShowDialog()

                strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                'Valida que se ingrese la Causa de la Anulación:
                If strCausaAnulacion = "" Then
                    MsgBox("El registro NO PUEDE ser Anulado.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If

                'Actualizar el Estado a Anulado:
                Strsql = " Update SccArregloPago " & _
                         " SET nStbEstadoArregloPagoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoArregloPago')," & _
                         "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate(), sMotivoAnulacion = '" & strCausaAnulacion & "'" & _
                         " WHERE nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID")
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                       "de forma satisfactoria.", MsgBoxStyle.Information)
                'Guardar posición actual de la selección:
                intPosicion = XdtArregloPago.ValueField("nSccArregloPagoID")
                Call GuardarAuditoria(5, 23, "Anulación Arreglo de Pago ID: " & XdtArregloPago.ValueField("nSccArregloPagoID") & ".")
                CargarArregloPago(StrCadena)

                'Ubicar la selección en la posición original:
                XdtArregloPago.SetCurrentByID("nSccArregloPagoID", intPosicion)
                Me.grdArregloPago.Row = XdtArregloPago.BindingSource.Position

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
    ' Fecha:                08/10/2009
    ' Procedure Name:       LlamaModificarArregloPago
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditArregloPago para Modificar un registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarArregloPago()
        Dim ObjFrmSccEditA As New frmSccEditArregloPago
        Try

            'Si no existen registros:
            If Me.grdArregloPago.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtArregloPago.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Arreglos de Pago de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            ObjFrmSccEditA.ModoFrm = "UPD"
            ObjFrmSccEditA.intStePermiteEditar = IntPermiteEditar
            ObjFrmSccEditA.intArregloID = XdtArregloPago.ValueField("nSccArregloPagoID")
            ObjFrmSccEditA.ShowDialog()

            CargarArregloPago(StrCadena)
            XdtArregloPago.SetCurrentByID("nSccArregloPagoID", ObjFrmSccEditA.intArregloID)
            Me.grdArregloPago.Row = XdtArregloPago.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditA.Close()
            ObjFrmSccEditA = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/10/2009
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
    ' Fecha:                07/10/2009
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. 
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
    ' Fecha:                07/10/2009
    ' Procedure Name:       grdArregloPago_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdArregloPago_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdArregloPago.Filter
        Try
            XdtArregloPago.FilterLocal(e.Condition)
            Me.grdArregloPago.Caption = " Listado de Arreglos de Pago (" + Me.grdArregloPago.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/10/2009
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar Arreglos de Pago:
            If Seg.HasPermission("BuscarArregloPago") Then
                Me.toolBuscar.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
            End If
            'Agregar:
            If Seg.HasPermission("AgregarArregloPago") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If
            'Modificar: 
            If Seg.HasPermission("ModificarArregloPago") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If
            'Aplicar:
            If Seg.HasPermission("AplicarArregloPago") Then
                Me.toolAplicar.Enabled = True
            Else
                Me.toolAplicar.Enabled = False
            End If
            'Anular:
            If Seg.HasPermission("AnularArregloPago") Then
                Me.toolAnular.Enabled = True
            Else
                Me.toolAnular.Enabled = False
            End If
            
            '-- Imprimir:
            'Formato de Arreglo de Pago:
            If Seg.HasPermission("ImprimirArregloPagoCC67") Then
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
    ' Fecha:                07/10/2009
    ' Procedure Name:       grdArqueo_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Arreglo existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdArregloPago_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdArregloPago.DoubleClick
        Try
            If Me.grdArregloPago.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarArregloPago") Then
                LlamaModificarArregloPago()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdArregloPago_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdArregloPago.Error
        Control_Error(e.Exception)
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	12/10/2009
    ' Procedure name	:	LlamaImprimir
    ' Description		:	Este procedimiento se encarga de imprimir Arreglo de Pago. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdArregloPago.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSccCC67.rpt"
            frmVisor.Text = "Arreglo de Pago"
            frmVisor.SQLQuery = " Select * From vwSccArregloPagoRep " & _
                                " WHERE (nSccArregloPagoID = " & XdtArregloPago.ValueField("nSccArregloPagoID") & ") " & _
                                " Order by nSccArregloPagoID, dFechaCuota"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

End Class