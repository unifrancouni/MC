' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                17/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclSolicitudDesembolso.vb
' Descripción:          Este formulario permite registrar Solicitudes de
'                       Desembolso para una FNC Aprobada.
'-------------------------------------------------------------------------
Imports System.Text

Public Class frmSclSolicitudDesembolso

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intFichaID As Long
    Dim intSolicitudID As Long
    Dim dFechaEntregaCK As Date

    '-- Clases para procesar la informacion de los combos
    Dim XdsEmpleado As BOSistema.Win.XDataSet
    Dim XdtFuente As BOSistema.Win.XDataSet.xDataTable

    Dim strFechaSolicitud As String
    Dim StrFechaDesembolso As String

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjSolicituddt As BOSistema.Win.SccEntCredito.SccSolicitudDesembolsoCreditoDataTable
    Dim ObjSolicituddr As BOSistema.Win.SccEntCredito.SccSolicitudDesembolsoCreditoRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Ficha de Notificación de Crédito:
    Public Property intSclFichaID() As Long
        Get
            intSclFichaID = intFichaID
        End Get
        Set(ByVal value As Long)
            intFichaID = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de una de las Solicitudes de Desembolso 
    'en caso de Edición:
    Public Property intSccSolicitudID() As Long
        Get
            intSccSolicitudID = intSolicitudID
        End Get
        Set(ByVal value As Long)
            intSolicitudID = value
        End Set
    End Property

    'Propiedad utilizada para obtener Fecha de Entrega del CK:
    'en caso de Adición:
    Public Property dSccFechaCK() As Date
        Get
            dSccFechaCK = dFechaEntregaCK
        End Get
        Set(ByVal value As Date)
            dFechaEntregaCK = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       frmSclSolicitudDesembolso_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclSolicitudDesembolso_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjSolicituddt.Close()
                ObjSolicituddt = Nothing

                ObjSolicituddr.Close()
                ObjSolicituddr = Nothing

                XdsEmpleado.Close()
                XdsEmpleado = Nothing

                XdtFuente.Close()
                XdtFuente = Nothing

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       frmSclSolicitudDesembolso_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Solicitud en caso de estar en el 
    '                       modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclSolicitudDesembolso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFirmas(0, 0, "FirmaElabora")
            CargarFirmas(0, 13, "FirmaTres")
            CargarFuente(0)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm = "UPD" Then
                CargarSolicitud()
                InhabilitarControles()
            End If

            Me.cdeFechaSolicitud.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Si la Solicitud no se encuentra en Proceso:
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoDesembolsoCredito' "
            If ObjSolicituddr.nStbEstadoSolicitudID <> XcDatos.ExecuteScalar(Strsql) Then
                Me.cmdAceptar.Enabled = False
                Me.grpGenerales.Enabled = False
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
    ' Fecha:                17/10/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Generar Solicitudes de Desembolso de Crédito"
            Else
                Me.Text = "Modificar Solicitudes de Desembolso de Crédito"
            End If

            ObjSolicituddt = New BOSistema.Win.SccEntCredito.SccSolicitudDesembolsoCreditoDataTable
            ObjSolicituddr = New BOSistema.Win.SccEntCredito.SccSolicitudDesembolsoCreditoRow

            XdsEmpleado = New BOSistema.Win.XDataSet
            XdtFuente = New BOSistema.Win.XDataSet.xDataTable

            'Limpiar los combos:
            Me.cboFirmaE.ClearFields()
            Me.cboFirmaA.ClearFields()
            Me.cboFuente.ClearFields()

            'Sugiere Fecha de Entrega de Cheque en Fecha de Desembolso:
            cdeFechaDesembolso.Value = dFechaEntregaCK

            If ModoForm = "ADD" Then
                ObjSolicituddr = ObjSolicituddt.NewRow
                'Inicializar los Length de los campos (Strings?)
                Me.txtObservacion.MaxLength = ObjSolicituddr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       CargarSolicitud
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarSolicitud()
        Try

            '-- Buscar la Solicitud correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjSolicituddt.Filter = "nSccSolicitudDesembolsoCreditoID = " & intSccSolicitudID
            ObjSolicituddt.Retrieve()
            If ObjSolicituddt.Count = 0 Then
                Exit Sub
            End If
            ObjSolicituddr = ObjSolicituddt.Current 'Solicitud actual.

            'Fecha Solicitud:
            If Not ObjSolicituddr.IsFieldNull("dFechaSolicitudDesembolso") Then
                Me.cdeFechaSolicitud.Value = ObjSolicituddr.dFechaSolicitudDesembolso
            Else
                Me.cdeFechaSolicitud.Value = Me.cdeFechaSolicitud.ValueIsDbNull
            End If

            'Fecha Desembolso:
            If Not ObjSolicituddr.IsFieldNull("dFechaDesembolso") Then
                Me.cdeFechaDesembolso.Value = ObjSolicituddr.dFechaDesembolso
            Else
                Me.cdeFechaDesembolso.Value = Me.cdeFechaSolicitud.ValueIsDbNull
            End If

            'Fuente de Financiamiento:
            If Not ObjSolicituddr.IsFieldNull("nScnFuenteFinanciamientoID") Then
                CargarFuente(ObjSolicituddr.nScnFuenteFinanciamientoID)
                If cboFuente.ListCount > 0 Then
                    Me.cboFuente.SelectedIndex = 0
                End If
                XdtFuente.SetCurrentByID("nScnFuenteFinanciamientoID", ObjSolicituddr.nScnFuenteFinanciamientoID)
            Else
                Me.cboFuente.Text = ""
                Me.cboFuente.SelectedIndex = -1
            End If

            'Empleado Elabora:
            If Not ObjSolicituddr.IsFieldNull("nSrhEmpleadoElaboraID") Then
                If Me.cboFirmaE.ListCount > 0 Then
                    Me.cboFirmaE.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaElabora").SetCurrentByID("nSrhEmpleadoID", ObjSolicituddr.nSrhEmpleadoElaboraID)
            Else
                Me.cboFirmaE.Text = ""
                Me.cboFirmaE.SelectedIndex = -1
            End If

            'Tercer Firma (Empleado de Comité de Crédito):
            If Not ObjSolicituddr.IsFieldNull("nSrhEmpleadoAutorizaID") Then
                If Me.cboFirmaA.ListCount > 0 Then
                    Me.cboFirmaA.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaTres").SetCurrentByID("nSrhEmpleadoID", ObjSolicituddr.nSrhEmpleadoAutorizaID)
            Else
                Me.cboFirmaA.Text = ""
                Me.cboFirmaA.SelectedIndex = -1
            End If

            'Observaciones:
            If Not ObjSolicituddr.IsFieldNull("sObservaciones") Then
                Me.txtObservacion.Text = ObjSolicituddr.sObservaciones
            Else
                Me.txtObservacion.Text = ""
            End If

            'Inicializar los Length de los campos:
            Me.txtObservacion.MaxLength = ObjSolicituddr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/11/2007
    ' Procedure Name:       CargarFuente
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarFuente(ByVal intFuenteID As Integer)
        Try
            Dim Strsql As String = ""

            '-- Temporal solo permitir seleccionar nueva Fuente de Fondos: BANDES, VENTANA, FONDOS PROPIOS
            If intFuenteID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) And (a.nScnFuenteFinanciamientoID > 5) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1 And a.nScnFuenteFinanciamientoID > 5) Or (a.nScnFuenteFinanciamientoID = " & intFuenteID & ") " & _
                         " Order by a.sCodigo"
            End If

            XdtFuente.ExecuteSql(Strsql)
            Me.cboFuente.DataSource = XdtFuente.Source

            Me.cboFuente.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Width = 47
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboFuente.Columns("sCodigo").Caption = "Código"
            Me.cboFuente.Columns("sNombre").Caption = "Descripción"

            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       CargarFirmas
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Empleados sugiriendo el empleado registrado en 
    '                       parámetros para tercer firma:
    '                       intParametroID = 0  (Elaborado); StrNombre = FirmaElabora (Oficiales Credito)
    '                       intParametroID = 13 (Firma3); StrNombre = FirmaTres (Resp. Credito)
    '-------------------------------------------------------------------------
    Private Sub CargarFirmas(ByVal intEmpleadoID As Integer, ByVal intParametroID As Integer, ByVal StrNombre As String)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Dim XdtDelegacion As New BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaDataTable
        Try

            Dim Strsql As String

            If intParametroID = 0 Then
                Me.cboFirmaE.ClearFields()
            Else
                Me.cboFirmaA.ClearFields()
            End If

            If intParametroID = 0 Then 'Solo oficiales de credito
                If intEmpleadoID = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where (a.scodcargo = '10') and (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " & _
                             " Order by a.nCodPersona"
                Else
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where ((a.scodcargo = '10') and  (a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " & _
                             " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " & _
                             " Order by a.nCodPersona"
                End If
            Else
                If intEmpleadoID = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " & _
                             " Order by a.nCodPersona"
                Else
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where ((a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " & _
                             " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " & _
                             " Order by a.nCodPersona"
                End If
            End If

            

            If XdsEmpleado.ExistTable(StrNombre) Then
                XdsEmpleado(StrNombre).ExecuteSql(Strsql)
            Else
                XdsEmpleado.NewTable(Strsql, StrNombre)
                XdsEmpleado(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos
            If intParametroID = 0 Then
                Me.cboFirmaE.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboFirmaE.Rebind()
            Else
                Me.cboFirmaA.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboFirmaA.Rebind()
            End If

            'Ubicarse en el registro recomendado de parámetros:
            If intParametroID <> 0 Then

                XdtValorParametro.Filter = "nStbParametroID = " & intParametroID
                XdtValorParametro.Retrieve()

                If XdsEmpleado(StrNombre).Count > 0 Then
                    XdsEmpleado(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorParametro.ValueField("sValorParametro"))
                End If

                'Con base en la delegacion:
                XdtDelegacion.Filter = " nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion
                XdtDelegacion.Retrieve()
                XdsEmpleado(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtDelegacion.ValueField("nSrhEmpleadoFirmaCComiteID"))
            End If

            'Confugurar el combo:
            If intParametroID = 0 Then
                Me.cboFirmaE.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaE.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirmaE.Splits(0).DisplayColumns("sNombre").Width = 200
                Me.cboFirmaE.Columns("nCodPersona").Caption = "Código"
                Me.cboFirmaE.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirmaE.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaE.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                Me.cboFirmaA.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirmaA.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaA.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirmaA.Splits(0).DisplayColumns("sNombre").Width = 200
                Me.cboFirmaA.Columns("nCodPersona").Caption = "Código"
                Me.cboFirmaA.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirmaA.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaA.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing

            XdtDelegacion.Close()
            XdtDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarSolicitudes()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatosF As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            Dim StrSesion As String = ""
            ValidaDatosEntrada = True
            Me.errSolicitudes.Clear()

            'Fecha de Solicitud:
            If Me.cdeFechaSolicitud.ValueIsDbNull Then
                MsgBox("La Fecha de Solicitud del Desembolso NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "La Fecha de Solicitud del Desembolso NO DEBE quedar vacía.")
                Me.cdeFechaSolicitud.Focus()
                Exit Function
            End If

            'Fecha de Desembolso del Crédito:
            If Me.cdeFechaDesembolso.ValueIsDbNull Then
                MsgBox("La Fecha de Desembolso del Crédito NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "La Fecha de Desembolso del Crédito NO DEBE NO DEBE quedar vacía.")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If

            'Fechas de Solicitud y Desembolso deben ser de un Mes Contable Abierto:
            If PeriodoAbiertoDadaFecha(Me.cdeFechaSolicitud.Value) = False Then
                MsgBox("La Fecha de Solicitud del Desembolso corresponde" & Chr(13) & "a un mes Contable Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "Fecha de Solicitud de Desembolso Inválida.")
                Me.cdeFechaSolicitud.Focus()
                Exit Function
            End If

            If PeriodoAbiertoDadaFecha(Me.cdeFechaDesembolso.Value) = False Then
                MsgBox("La Fecha del Desembolso corresponde" & Chr(13) & "a un mes Contable Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Fecha de Desembolso Inválida.")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If

            'Fecha de Solicitud no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaSolicitud.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Solicitud NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "La Fecha de Solicitud NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaSolicitud.Focus()
                Exit Function
            End If

            'Fecha de Solicitud no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaSolicitud.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Solicitud NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "La Fecha de Solicitud NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaSolicitud.Focus()
                Exit Function
            End If

            'Fecha de Desembolso del Crédito: no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaDesembolso.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Desembolso del Crédito NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "La Fecha de Desembolso del Crédito NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If

            'Fecha de Desembolso del Crédito: no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaDesembolso.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Desembolso del Crédito NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "La Fecha de Desembolso del Crédito NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If

            '-- Determinar Tipo de Credito.
            strFechaSolicitud = Format(Me.cdeFechaSolicitud.Value, "yyyy-MM-dd")
            StrFechaDesembolso = Format(Me.cdeFechaDesembolso.Value, "yyyy-MM-dd")
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1' or StbValorCatalogo.sCodigoInterno = '3') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & Me.intSclFichaID & ")"
            '-- SI EL CREDITO ES DE USURA CERO / MERCADOS PAGO DIARIO:
            'Fecha de Solicitud < Fecha Desembolso:
            If RegistrosAsociados(strSQL) Then
                If CDate(strFechaSolicitud) >= CDate(StrFechaDesembolso) Then
                    MsgBox("La Fecha de Solicitud debe ser menor a la de Desembolso.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "La Fecha de Solicitud NO DEBE ser mayor a la de Desembolso.")
                    Me.cdeFechaSolicitud.Focus()
                    Exit Function
                End If
                '-- SI EL CREDITO ES DE VENTANA DE GENERO:
                'Fecha de Solicitud = Fecha Desembolso:
                'Esto debido a que los montos en dolares seran convertidos a cordobas con la fecha de entrega del cheque la cual coincidiria con la de TC en Contabilidad (F. Solicitud Desembolso).
            Else
                If CDate(strFechaSolicitud) <> CDate(StrFechaDesembolso) Then
                    MsgBox("La Fecha de Solicitud debe ser igual a la de Desembolso.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "La Fecha de Solicitud debe ser igual a la de Desembolso.")
                    Me.cdeFechaSolicitud.Focus()
                    Exit Function
                End If
            End If





            'Fecha de Desembolso del crédito: No mayor de 7 días a la fecha de la solicitud
            If DateDiff(DateInterval.Day, CDate(StrFechaDesembolso), FechaServer) > 15 Then
                MsgBox("La Fecha de desembolso NO DEBE ser mayor  de 15 días" & Chr(13), MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "La Fecha de desembolso NO DEBE ser mayor  de 15 días")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If




            REM Mes de la Fecha de Solicitud = Mes de la Fecha Desembolso:
            'If Month(Me.cdeFechaSolicitud.Value) <> Month(Me.cdeFechaDesembolso.Value) Then
            '    MsgBox("Las Fechas no corresponden al mismo mes.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "Las Fechas no corresponden al mismo mes.")
            '    Me.cdeFechaSolicitud.Focus()
            '    Exit Function
            'End If

            'Debe existir un Tipo de Cambio para Fecha de Desembolso (Entrega de Cheque):
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaDesembolso.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha de Desembolso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "No existe una Tasa de Cambio para la Fecha de Desembolso.")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If

            'Debe existir un Tipo de Cambio para Fecha de Solicitud (Codificacion Contable):
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaSolicitud.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha de Solicitud de Desembolso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicitud, "No existe una Tasa de Cambio para la Fecha Solicitud de Desembolso.")
                Me.cdeFechaSolicitud.Focus()
                Exit Function
            End If

            'Advertir si Fecha de Desembolso cambio con respecto a la Fecha de Entrega
            'del Cheque de la FNC:
            If Me.ModoForm = "ADD" Then
                If Format(Me.cdeFechaDesembolso.Value, "dd/MM/yyyy") <> Format(dFechaEntregaCK, "dd/MM/yyyy") Then
                    If MsgBox("La modificación de la Fecha de Desembolso con respecto a" & Chr(13) _
                            & "la Fecha de Entrega del Cheque indicada en la Ficha de" & Chr(13) _
                            & "Notificación podría modificar las Tablas de Amortización." & Chr(13) & Chr(13) _
                            & "¿Esta seguro que desea realizar el cambio?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        ValidaDatosEntrada = False
                        Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Fecha de Desembolso difiere de Fecha de Entrega del Cheque.")
                        Me.cdeFechaDesembolso.Focus()
                        Exit Function
                    End If
                End If
            Else
                If Format(Me.cdeFechaDesembolso.Value, "dd/MM/yyyy") <> Format(ObjSolicituddr.dFechaDesembolso, "dd/MM/yyyy") Then
                    If MsgBox("La modificación de la Fecha de Desembolso con respecto a" & Chr(13) _
                            & "la Fecha de Entrega del Cheque indicada en la Ficha de" & Chr(13) _
                            & "Notificación podría modificar las Tablas de Amortización." & Chr(13) & Chr(13) _
                            & "¿Esta seguro que desea realizar el cambio?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        ValidaDatosEntrada = False
                        Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Fecha de Desembolso difiere de Fecha de Entrega del Cheque.")
                        Me.cdeFechaDesembolso.Focus()
                        Exit Function
                    End If
                End If
            End If

            'Si la Hora de Desembolso se dejo en 12:00 a.m.:
            If Mid(Me.cdeFechaDesembolso.Text, 12, 16) = "12:00 a.m." Then
                MsgBox("Debe indicar una Hora de Desembolso valida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Debe indicar una Hora de Desembolso valida.")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If

            'Fuente de Financiamiento:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuente.Focus()
                Exit Function
            End If
            'En caso de que el formulario sea para Añadir
            'If Me.ModoForm = "ADD" Then
            'Preguntamos si la fuente de financiamiento de la solicitud de desembolso de crédito
            ' es la misma con la que se va a desembolsar
            Dim xDt As New BOSistema.Win.XDataSet.xDataTable
            Dim sQuery As New StringBuilder()
            Dim nFuenteFinanciamientoID As Int32

            strSQL = "SELECT sNumSesion, dFechaNotificacion FROM  SclFichaNotificacionCredito WHERE (nSclFichaNotificacionID = " & Me.intFichaID & ")"
            xDt.ExecuteSql(strSQL)

            Dim sNumSesion As String = xDt.ValueField("sNumSesion")
            Dim dFechaNotificacion As Date = xDt.ValueField("dFechaNotificacion")

            sQuery.AppendFormat(" EXEC spSccAyudaMemoriaFondo '{0}', '{1}'", sNumSesion, Format(dFechaNotificacion, "yyyy-MM-dd"))

            xDt.ExecuteSql(sQuery.ToString())

            nFuenteFinanciamientoID = xDt.ValueField("nScnFuenteFinanciamientoID")

            If nFuenteFinanciamientoID <> Convert.ToInt32(Me.cboFuente.Columns("nScnFuenteFinanciamientoID").Value) Then

                If MsgBox("La Fuente de Financiamiento de solicitud de desembolso" & Chr(13) _
                       & "es distinta a la indicada en la sesión." & Chr(13) _
                       & "¿Esta seguro que desea realizar el cambio?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, NombreSistema) = MsgBoxResult.Cancel Then

                    ValidaDatosEntrada = False


                    Me.errSolicitudes.SetError(Me.cboFuente, String.Format("Indique la Fuente de Financiamiento {0}.", xDt.ValueField("sNombre")))

                    Me.cboFuente.Focus()

                    Exit Function

                End If

            End If

            'End If

            REM REM 
            ''Imposible si existen Fichas ACTIVAS de la Sesion con Otra Fuente de Fondos:
            'strSQL = "SELECT sNumSesion FROM  SclFichaNotificacionCredito WHERE (nSclFichaNotificacionID = " & Me.intFichaID & ")"
            'StrSesion = XcDatosF.ExecuteScalar(strSQL)
            'strSQL = "SELECT SclFichaNotificacionCredito.sNumSesion " & _
            '         "FROM SccSolicitudDesembolsoCredito INNER JOIN SclFichaNotificacionDetalle ON SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID " & _
            '         "INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
            '         "WHERE (SccSolicitudDesembolsoCredito.nScnFuenteFinanciamientoID <> " & Me.cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") AND (SclFichaNotificacionCredito.sNumSesion = '" & StrSesion & "') " & _
            '         "AND (StbValorCatalogo.sCodigoInterno <> '4' AND StbValorCatalogo.sCodigoInterno <> '5')" 'AND (SclFichaNotificacionDetalle.nSclFichaNotificacionID <> " & Me.intFichaID & ")
            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("Existen Fichas de la sesión asociadas" & Chr(13) & "a otra Fuente de Fondos.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitudes.SetError(Me.cboFuente, "Fuente de Financiamiento inválida.")
            '    Me.cboFuente.Focus()
            '    Exit Function
            'End If

            'Elaborado:
            If Me.cboFirmaE.SelectedIndex = -1 Then
                MsgBox("Debe indicar Empleado que Elabora la Solicitud.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboFirmaE, "Debe indicar Empleado que Elabora la Solicitud.")
                Me.cboFirmaE.Focus()
                Exit Function
            End If

            'Autorizado:
            If Me.cboFirmaA.SelectedIndex = -1 Then
                MsgBox("Debe indicar Empleado que Autoriza la Solicitud.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboFirmaA, "Debe indicar Empleado que Autoriza la Solicitud.")
                If Me.cboFirmaA.Enabled Then
                    Me.cboFirmaA.Focus()
                End If
                Exit Function
            End If

            'Empleado Elabora debe ser diferente del que Autoriza:
            If Me.cboFirmaE.Columns("nSrhEmpleadoID").Value = Me.cboFirmaA.Columns("nSrhEmpleadoID").Value Then
                MsgBox("Empleado responsable de Autorizar" & Chr(13) & "NO debe ser el mismo que Elabora.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboFirmaA, "Empleado Autoriza NO debe ser el mismo que Elabora.")
                If Me.cboFirmaA.Enabled Then
                    Me.cboFirmaA.Focus()
                End If
                Exit Function
            End If

            'Si es una adición: Imposible si ya se han Generado las Solicitudes: 
            If Me.ModoForm = "ADD" Then
                strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & Me.intSclFichaID & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Las Solicitudes de Desembolso ya han sido generadas.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Las Solicitudes de Desembolso ya han sido generadas.")
                    Me.cdeFechaDesembolso.Focus()
                    Exit Function
                End If
            End If

            'Imposible si ya se Verificaron las Solicitudes:
            strSQL = " Select * From SccSolicitudDesembolsoCredito " & _
                     " Where (nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoDesembolsoCredito' " & _
                     " )) And (nSclFichaNotificacionDetalleID IN (SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & Me.intSclFichaID & ")))"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Las Solicitudes de Desembolso ya han sido Verificadas.", MsgBoxStyle.Information, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Las Solicitudes de Desembolso ya han sido Verificadas.")
                Me.cdeFechaDesembolso.Focus()
                Exit Function
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosF.Close()
            XcDatosF = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarSolicitudes()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String = ""
            Dim intCambioFechaCK As Integer
            Dim intCambioFechaCkTA As Integer

            strFechaSolicitud = Format(Me.cdeFechaSolicitud.Value, "yyyy-MM-dd")
            StrFechaDesembolso = Format(Me.cdeFechaDesembolso.Value, "yyyy-MM-dd HH:mm")

            If Me.ModoForm = "ADD" Then
                If (DateDiff("d", Format(Me.cdeFechaDesembolso.Value, "dd/MM/yyyy"), Format(dFechaEntregaCK, "dd/MM/yyyy")) = 0) Then
                    intCambioFechaCK = 0 'No Hubo cambio en la Fecha de Entrega del CK con respecto a la FNC.
                Else
                    intCambioFechaCK = 1
                End If
                intCambioFechaCkTA = 1 'Siempre en la Adición Generar Tablas de Amortizacion.
            Else
                If (DateDiff("d", Format(Me.cdeFechaDesembolso.Value, "dd/MM/yyyy"), Format(ObjSolicituddr.dFechaDesembolso, "dd/MM/yyyy")) = 0) Then
                    intCambioFechaCK = 0 'NO Hubo cambio en la Fecha de Entrega del CK.
                    intCambioFechaCkTA = 0 'No volver a generar las Tablas de Amortización.
                Else
                    intCambioFechaCK = 1 'Hubo cambio en la Fecha de Entrega del CK.
                    intCambioFechaCkTA = 1  'Volver a generar las Tablas de Amortización.
                End If
            End If

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS UPDATE DE AUDITORIA 

            Dim XdtConsulta As BOSistema.Win.XDataSet.xDataTable
            Dim StrQuery As String
            XdtConsulta = New BOSistema.Win.XDataSet.xDataTable

            Dim IdnSclFichaNotificacionDetalle As Integer
            Dim IdnSccSolicitudDesembolsoCredito As Integer

            ' UPDATE SclFichaNotificacionCredito
            GuardarAuditoriaTablas(4, 2, "Modificar FNC", intFichaID, InfoSistema.IDCuenta)

            ' Esto es para SclFichaNotificacionDetalle
            StrQuery = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & intFichaID
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaNotificacionDetalle = XdtConsulta.ValueField("nSclFichaNotificacionDetalleID")
                GuardarAuditoriaTablas(5, 2, "Modificar SclFichaNotificacionDetalle", IdnSclFichaNotificacionDetalle, InfoSistema.IDCuenta)
            End If

            ' ------------------------------------------------------------------------------------------

            strSQL = " EXEC spSccGrabarSolicitudDesembolso " & Me.intFichaID & ", " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ", '" & strFechaSolicitud & "', '" & _
                    StrFechaDesembolso & "', " & cboFirmaE.Columns("nSrhEmpleadoID").Value & ", " & _
                    cboFirmaA.Columns("nSrhEmpleadoID").Value & ", '" & Trim(RTrim(Me.txtObservacion.Text)) & _
                    "', '" & Me.ModoForm & "', '" & InfoSistema.LoginName & "'" & "," & intCambioFechaCK & "," & intCambioFechaCkTA & "," & InfoSistema.IDCuenta
            Me.intFichaID = XcDatos.ExecuteScalar(strSQL)

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS INSERT DE AUDITORIA 

            ' Esto es para SccSolicitudDesembolsoCredito
            StrQuery = "SELECT nSccSolicitudDesembolsoCreditoID FROM SccSolicitudDesembolsoCredito WHERE nSclFichaNotificacionDetalleID = " & IdnSclFichaNotificacionDetalle
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSccSolicitudDesembolsoCredito = XdtConsulta.ValueField("nSccSolicitudDesembolsoCreditoID")
                GuardarAuditoriaTablas(3, 1, "Agregar SccSolicitudDesembolsoCredito", IdnSccSolicitudDesembolsoCredito, InfoSistema.IDCuenta)
            End If

            ' ------------------------------------------------------------------------------------------

            '-- Buscar la FNC correspondiente al Id especificado
            '-- como parámetro, en caso de edición.
            'ObjSolicituddt.Filter = "nSclFichaNotificacionID = " & Me.intFichaID
            'ObjSolicituddt.Retrieve()
            'If ObjSolicituddt.Count = 0 Then
            '    Exit Sub
            'End If
            'ObjSolicituddr = ObjSolicituddt.Current

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.intFichaID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                If ModoForm = "ADD" Then
                    MsgBox("Las Solicitudes de Desembolso se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Las Solicitudes de Desembolso se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                End If
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
    ' Fecha:                17/10/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarSolicitudes()
                            AccionUsuario = AccionBoton.BotonAceptar
                            Me.Close()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case vbNo
                        AccionUsuario = AccionBoton.BotonCancelar
                        Me.Close()

                    Case vbCancel
                        AccionUsuario = AccionBoton.BotonNinguno
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()) BackSpace y la Barra espaciadora
    Private Sub txtObservacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboFirmaE_Error1(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFirmaE.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboFirmaE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirmaE.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirmaA_Error1(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFirmaA.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboFirmaA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirmaA.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservacion.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaDesembolso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaDesembolso.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaSolicitud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaSolicitud.TextChanged
        vbModifico = True
    End Sub
End Class