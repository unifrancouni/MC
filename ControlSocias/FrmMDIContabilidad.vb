' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                18/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditFichaNotificacion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de una Ficha de Notificación de Crédito.
'-------------------------------------------------------------------------
Public Class frmSclEditFichaNotificacion

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intFichaID As Long
    Dim blnModificar As Boolean = True
    Dim intNoMinimoSocias As Integer
    Dim IntTipoCambioID As Long
    Dim IntPermiteEditarFNC As Integer

    Dim IntAprobada As Integer = 0
    Dim StrNoSesion As String
    Dim StrLugarPagos As String

    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjFichadt As BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoDataTable
    Dim ObjFichadr As BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Ficha.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Comprobante que corresponde al campo
    'SclFichaSociaID de la tabla SclFichaSocia.
    Public Property intSclFichaID() As Long
        Get
            intSclFichaID = intFichaID
        End Get
        Set(ByVal value As Long)
            intFichaID = value
        End Set
    End Property

    'Propiedad utilizada para obtener Permisos de edición fuera de la Delegación.
    Public Property intSclPermiteEditarFNC() As Long
        Get
            intSclPermiteEditarFNC = IntPermiteEditarFNC
        End Get
        Set(ByVal value As Long)
            IntPermiteEditarFNC = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                16/10/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario tiene
    '                       permiso sobre los Tabs de Resolución y Expediente.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Expediente:
            If Seg.HasPermission("DatosExpediente") Then
                Me.toolAgregarE.Enabled = True
            Else
                Me.toolAgregarE.Enabled = False
            End If
            If Seg.HasPermission("DatosExpediente") Then
                Me.toolModificarE.Enabled = True
            Else
                Me.toolModificarE.Enabled = False
            End If
            If Seg.HasPermission("DatosExpediente") Then
                Me.toolActivoInactivo.Enabled = True
            Else
                Me.toolActivoInactivo.Enabled = False
            End If
            If Seg.HasPermission("DatosExpediente") Then
                Me.toolEliminarE.Enabled = True
            Else
                Me.toolEliminarE.Enabled = False
            End If
            'Resolucion:
            If Seg.HasPermission("AgregarDatosResolucion") Then
                Me.toolAgregarRC.Enabled = True
            Else
                Me.toolAgregarRC.Enabled = False
            End If

            If Seg.HasPermission("DatosResolucion") Then
                Me.toolModificarRC.Enabled = True
            Else
                Me.toolModificarRC.Enabled = False
            End If
            If Seg.HasPermission("EliminarDatosResolucion") Then
                Me.toolEliminarRC.Enabled = True
            Else
                Me.toolEliminarRC.Enabled = False
            End If
            If Seg.HasPermission("DenegarDatosResolucion") Then
                Me.toolDenegarC.Enabled = True
            Else
                Me.toolDenegarC.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       frmSclEditFichaNotificacion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFichaNotificacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsFicha.Close()
                XdsFicha = Nothing

                ObjFichadt.Close()
                ObjFichadt = Nothing

                ObjFichadr.Close()
                ObjFichadr = Nothing

                XdsDetalle.Close()
                XdsDetalle = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       frmSclEditFichaNotificacion_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Ficha en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFichaNotificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()

            'Día de la semana para efectuar pagos:
            CargarDiaPagos()

            'Lugar de entrega de cheques y lugar de pagos (Persona Jurídica):
            CargarLugarEntregaCKPagos(0, "LugarEntregaCheque")
            CargarLugarEntregaCKPagos(0, "LugarPagos")
            CargarTipoPlazo()

            'Llama Seguridad:
            Seguridad()

            'Si el formulario está en modo edición
            'cargar los datos de la ficha.
            Me.cnePlazoPeriodoGracia.Value = 0
            If ModoForm = "UPD" Then
                CargarFicha()
                ObtenerSiModifica()
                PresentacionControles()
                'Cargar segunda y tercer pestaña:
                CargarExpediente()
                FormatoExpediente()
                CargarResolucionCredito()
                FormatoResolucionCredito()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            If cdeFechaNotificacion.Enabled Then
                Me.cdeFechaNotificacion.Select()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub ObtenerSiModifica()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Valida que el Estado actual sea "En Proceso"
            'de lo contrario se sale del procedimiento
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoCredito' "

            If ObjFichadr.nStbEstadoCreditoID <> XcDatos.ExecuteScalar(Strsql) Then
                blnModificar = False
                Exit Sub
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
    ' Fecha:                18/09/2007
    ' Procedure Name:       PresentacionControles
    ' Descripción:          Este procedimiento permite habilitar o inhabilitar
    '                       controles dependiendo del estado de la ficha.
    '-------------------------------------------------------------------------
    Private Sub PresentacionControles()
        Try

            Me.CmdAceptar.Enabled = True
            If blnModificar = False Then
                InhabilitarControles()
                Exit Sub
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            Me.tbResolucion.Enabled = False
            Me.tbExpediente.Enabled = False

            Me.grpComiteCredito.Enabled = False
            Me.grpMontoAprobado.Enabled = False

            'Si el Estado es APROBADO permitir modificar Lugar de Entrega CK:
            strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoCredito' "
            If (ObjFichadr.nStbEstadoCreditoID = XcDatos.ExecuteScalar(strSQL)) Then
                'Actualiza Bandera APROBADO:
                IntAprobada = 1

                If cdeFechaNotificacion.Enabled Then
                    cdeFechaNotificacion.Select()
                End If
                '-- Datos Generales:
                cdeFechaActaC.Enabled = False
                cboDepartamento.Enabled = False
                cboMunicipio.Enabled = False
                cboDistrito.Enabled = False
                cboBarrio.Enabled = False
                cboGrupo.Enabled = False
                txtObservaciones.Enabled = False

                '-- Datos de Aprobación:
                cdeFechaEntregaCK.Enabled = False
                'cboLugarPagos.Enabled = False
                'cboDiaPagos.Enabled = False
                txtHorarioPagos.Enabled = False
                Me.cnePlazoPeriodoGracia.Enabled = False
                Me.cboTipoPlazo.Enabled = False
                Me.cboTipoPlazoPagos.Enabled = False

                'En caso Contrario:
            Else
                'Si el Estado es RECHAZADO permitir modificar Fecha Resolución y No. Sesión:
                strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoCredito' "
                If (ObjFichadr.nStbEstadoCreditoID = XcDatos.ExecuteScalar(strSQL)) Then
                    If cdeFechaNotificacion.Enabled Then
                        cdeFechaNotificacion.Select()
                    End If
                    '-- Datos Generales:
                    Me.cdeFechaActaC.Enabled = False
                    Me.cboDepartamento.Enabled = False
                    Me.cboMunicipio.Enabled = False
                    Me.cboDistrito.Enabled = False
                    Me.cboBarrio.Enabled = False
                    Me.cboGrupo.Enabled = False
                    Me.txtObservaciones.Enabled = False
                    Me.cdeFechaEntregaCK.Enabled = False
                    Me.cboLugarPagos.Enabled = False
                    Me.cboDiaPagos.Enabled = False
                    Me.txtHorarioPagos.Enabled = False
                    'Inhabilitar Frames:
                    Me.grpDatosCredito.Enabled = False
                    Me.grpComiteCredito.Enabled = False

                Else 'En caso de Fichas diferentes de Anuladas y Rechazadas:
                    Me.grpDatosGenerales.Enabled = False
                    Me.grpDatosCredito.Enabled = False

                    Me.grpComiteCredito.Enabled = False
                    Me.CmdAceptar.Enabled = False
                End If
            End If

            'Bloquear No. de Sesion:
            'Si existe al menos una Socia Enviada a CARUNA para la Resolución:
            strSQL = "SELECT SclFichaNotificacionCredito.nCodigo " & _
                     "FROM SclFichaNotificacionDetalle INNER JOIN StbValorCatalogo ON SclFichaNotificacionDetalle.nStbEstadoEnvioID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID  " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (SclFichaNotificacionCredito.sNumSesion = '" & ObjFichadr.sNumSesion & "')"
            If RegistrosAsociados(strSQL) Then
                Me.mtbNumeroSesion.Enabled = False
                'Me.cdeFechaNotificacion.Enabled = False Si ya habian modificado una fecha y esta es diferente no permitiria continuar aprobando fichas en la sesion
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
    ' Fecha:                18/09/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Ficha de Notificación de Crédito"
                'Obligar ingresar el Encabezado de la FNC:
                Me.tabPResolucion.Enabled = False
                Me.tabPExpediente.Enabled = False
            Else
                Me.Text = "Modificar Ficha de Notificación de Crédito"
                Me.tabPExpediente.Enabled = True
                Me.tabPResolucion.Enabled = True
            End If

            Me.tbExpediente.Visible = True
            Me.tbResolucion.Visible = True

            IntAprobada = 0
            StrNoSesion = ""
            StrLugarPagos = ""

            txtHorarioPagos.Text = "DE 8:00 a.m. A 3:00 p.m."

            ObjFichadt = New BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoDataTable
            ObjFichadr = New BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoRow

            XdsDetalle = New BOSistema.Win.XDataSet
            XdsFicha = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos:
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboBarrio.ClearFields()
            Me.cboGrupo.ClearFields()

            Me.cboLugarEntregaCK.ClearFields()
            Me.cboLugarPagos.ClearFields()
            Me.cboDiaPagos.ClearFields()
            Me.cboTipoPlazo.ClearFields()
            Me.cboTipoPlazoPagos.ClearFields()

            Me.cboFirma1.ClearFields()
            Me.cboFirma2.ClearFields()
            Me.cboFirma3.ClearFields()

            'Limpiar los Grids:
            Me.grdResolucion.ClearFields()
            Me.grdExpediente.ClearFields()

            'Por defecto se abre en Datos Generales:
            Me.tabFicha.SelectedIndex = 0

            'Inicializar Fechas y Montos:
            Me.cdeFechaNotificacion.Value = ModSMUSURA0.FechaServer
            Me.cneMontoAprobado.Value = 0
            Me.cnePlazoAprobado.Value = 0

            If ModoFrm = "ADD" Then
                ObjFichadr = ObjFichadt.NewRow
                'Inicializar los Length de los campos
                'Me.txtNoSesion.MaxLength = ObjFichadr.GetColumnLenght("sNumSesion")
                Me.txtObservaciones.MaxLength = ObjFichadr.GetColumnLenght("sObservacion")
                Me.txtHorarioPagos.MaxLength = ObjFichadr.GetColumnLenght("sHorarioEntregaPagos")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       CargarFicha
    ' Descripción:          Este procedimiento permite cargar los datos de la Ficha
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarFicha()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Dim ObjUbicacionDT As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar la Ficha correspondiente al Id especificado como
            '-- parámetro, en los casos que se esté editando una.
            ObjFichadt.Filter = "nSclFichaNotificacionID = " & Me.intFichaID
            ObjFichadt.Retrieve()
            If ObjFichadt.Count = 0 Then
                Exit Sub
            End If
            ObjFichadr = ObjFichadt.Current

            'Código de la FNC:
            If Not ObjFichadr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjFichadr.nCodigo
                Me.txtCodigoE.Text = ObjFichadr.nCodigo
                Me.txtCodigoRC.Text = ObjFichadr.nCodigo
            Else
                Me.txtCodigo.Text = ""
                Me.txtCodigoE.Text = ""
                Me.txtCodigoRC.Text = ""
            End If

            'Estado FNC:
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjFichadr.nStbEstadoCreditoID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoE.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoRC.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            'Fecha de Resolución del Crédito:
            If Not ObjFichadr.IsFieldNull("dFechaNotificacion") Then
                Me.cdeFechaNotificacion.Value = ObjFichadr.dFechaNotificacion
            Else
                Me.cdeFechaNotificacion.Value = Me.cdeFechaNotificacion.ValueIsDbNull
            End If

            'Fecha de Firma del Acta de Compromiso:
            If Not ObjFichadr.IsFieldNull("dFechaFirmaActaCompromiso") Then
                Me.cdeFechaActaC.Value = ObjFichadr.dFechaFirmaActaCompromiso
            Else
                Me.cdeFechaActaC.Value = Me.cdeFechaActaC.ValueIsDbNull
            End If

            '-- Ubicación y Grupo Solidario:
            strSQL = " Select a.nSclGrupoSolidarioID, a.nStbBarrioVerificadoID, a.nStbMunicipioID," & _
                     " a.nStbDepartamentoID, a.nStbDistritoID, a.Mercado, a.NombreGS " & _
                     " From vwSclFichaNotificacionCreditoGS a " & _
                     " Where a.nSclGrupoSolidarioID = " & ObjFichadr.nSclGrupoSolidarioID
            ObjUbicacionDT.ExecuteSql(strSQL)
            If ObjUbicacionDT.Count > 0 Then
                'Departamento:                
                XdsFicha("Departamento").SetCurrentByID("nStbDepartamentoID", ObjUbicacionDT.ValueField("nStbDepartamentoID"))
                'Municipio:
                CargarMunicipio(0, ObjUbicacionDT.ValueField("nStbMunicipioID"))
                If Me.cboMunicipio.ListCount > 0 Then
                    Me.cboMunicipio.SelectedIndex = 0
                    XdsFicha("Municipio").SetCurrentByID("nStbMunicipioID", ObjUbicacionDT.ValueField("nStbMunicipioID"))
                End If
                'Distrito: 
                CargarDistrito(0, ObjUbicacionDT.ValueField("nStbDistritoID"))
                If Me.cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                    XdsFicha("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))
                End If
                'Barrio:  
                CargarBarrio(0, ObjUbicacionDT.ValueField("nStbBarrioVerificadoID"))
                If Me.cboBarrio.ListCount > 0 Then
                    Me.cboBarrio.SelectedIndex = 0
                    XdsFicha("Barrio").SetCurrentByID("nStbBarrioID", ObjUbicacionDT.ValueField("nStbBarrioVerificadoID"))
                End If
                'Grupo Solidario:
                CargarGrupo(0, ObjUbicacionDT.ValueField("nSclGrupoSolidarioID"))
                If Me.cboGrupo.ListCount > 0 Then
                    Me.cboGrupo.SelectedIndex = 0
                    XdsFicha("Grupo").SetCurrentByID("nSclGrupoSolidarioID", ObjUbicacionDT.ValueField("nSclGrupoSolidarioID"))
                End If
                'Nombre GS:
                txtNombreGS.Text = ObjUbicacionDT.ValueField("NombreGS")
                txtGrupoE.Text = ObjUbicacionDT.ValueField("NombreGS")
                txtGrupoRC.Text = ObjUbicacionDT.ValueField("NombreGS")
                'Mercado:
                txtMercado.Text = ObjUbicacionDT.ValueField("Mercado")
            End If

            'Observaciones;
            If Not ObjFichadr.IsFieldNull("sObservacion") Then
                Me.txtObservaciones.Text = ObjFichadr.sObservacion
            Else
                Me.txtObservaciones.Text = ""
            End If

            'No. de Sesión:
            If Not ObjFichadr.IsFieldNull("sNumSesion") Then
                Me.mtbNumeroSesion.Text = Mid(ObjFichadr.sNumSesion, 4, 8)
                Me.txtDepto.Text = Mid(ObjFichadr.sNumSesion, 1, 3)
            Else
                Me.mtbNumeroSesion.Text = ""
                Me.txtDepto.Text = ""
            End If
            StrNoSesion = Trim(RTrim(Me.txtDepto.Text)) & Me.mtbNumeroSesion.Text

            'Primer Firma (Empleado de Comité de Crédito):
            If Not ObjFichadr.IsFieldNull("nSrhEmpleadoComite1ID") Then
                If Me.cboFirma1.ListCount > 0 Then
                    Me.cboFirma1.SelectedIndex = 0
                End If
                XdsFicha("FirmaUno").SetCurrentByID("nSrhEmpleadoID", ObjFichadr.nSrhEmpleadoComite1ID)
            Else
                Me.cboFirma1.Text = ""
                Me.cboFirma1.SelectedIndex = -1
            End If

            'Segunda Firma (Empleado de Comité de Crédito):
            If Not ObjFichadr.IsFieldNull("nSrhEmpleadoComite2ID") Then
                If Me.cboFirma2.ListCount > 0 Then
                    Me.cboFirma2.SelectedIndex = 0
                End If
                XdsFicha("FirmaDos").SetCurrentByID("nSrhEmpleadoID", ObjFichadr.nSrhEmpleadoComite2ID)
            Else
                Me.cboFirma2.Text = ""
                Me.cboFirma2.SelectedIndex = -1
            End If

            'Tercer Firma (Empleado de Comité de Crédito):
            If Not ObjFichadr.IsFieldNull("nSrhEmpleadoComite3ID") Then
                If Me.cboFirma3.ListCount > 0 Then
                    Me.cboFirma3.SelectedIndex = 0
                End If
                XdsFicha("FirmaTres").SetCurrentByID("nSrhEmpleadoID", ObjFichadr.nSrhEmpleadoComite3ID)
            Else
                Me.cboFirma3.Text = ""
                Me.cboFirma3.SelectedIndex = -1
            End If

            'Lugar de Entrega CK:
            If Not ObjFichadr.IsFieldNull("nStbPersonaEntregaCKID") Then
                If Me.cboLugarEntregaCK.ListCount > 0 Then
                    Me.cboLugarEntregaCK.SelectedIndex = 0
                End If
                XdsFicha("LugarEntregaCheque").SetCurrentByID("nStbPersonaID", ObjFichadr.nStbPersonaEntregaCKID)
            Else
                Me.cboLugarEntregaCK.Text = ""
                Me.cboLugarEntregaCK.SelectedIndex = -1
            End If

            'Lugar de Pagos:
            If Not ObjFichadr.IsFieldNull("nStbPersonaLugarPagosID") Then
                If Me.cboLugarPagos.ListCount > 0 Then
                    Me.cboLugarPagos.SelectedIndex = 0
                End If
                XdsFicha("LugarPagos").SetCurrentByID("nStbPersonaID", ObjFichadr.nStbPersonaLugarPagosID)
            Else
                Me.cboLugarPagos.Text = ""
                Me.cboLugarPagos.SelectedIndex = -1
            End If
            StrLugarPagos = cboLugarPagos.Text

            'Día Pagos:
            If Not ObjFichadr.IsFieldNull("nStbDiaSemanaPagosID") Then
                If Me.cboDiaPagos.ListCount > 0 Then
                    Me.cboDiaPagos.SelectedIndex = 0
                End If
                XdsFicha("DiaPagos").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbDiaSemanaPagosID)
            Else
                Me.cboDiaPagos.Text = ""
                Me.cboDiaPagos.SelectedIndex = -1
            End If

            'Horario Entrega Pagos:
            If Not ObjFichadr.IsFieldNull("sHorarioEntregaPagos") Then
                Me.txtHorarioPagos.Text = ObjFichadr.sHorarioEntregaPagos
            Else
                Me.txtHorarioPagos.Text = ""
            End If

            'Fecha Primer Cuota:
            If Not ObjFichadr.IsFieldNull("dFechaPrimerCuota") Then
                Me.cdeFechaPrimerCuota.Value = ObjFichadr.dFechaPrimerCuota
            Else
                Me.cdeFechaPrimerCuota.Value = Me.cdeFechaPrimerCuota.ValueIsDbNull
            End If

            'Fecha Ultima Cuota:
            If Not ObjFichadr.IsFieldNull("dFechaUltimaCuota") Then
                Me.cdeFechaUltimaCuota.Value = ObjFichadr.dFechaUltimaCuota
            Else
                Me.cdeFechaUltimaCuota.Value = Me.cdeFechaUltimaCuota.ValueIsDbNull
            End If

            'Fecha / Hora Entrega de Cheque:
            If Not ObjFichadr.IsFieldNull("dFechaHoraEntregaCK") Then
                Me.cdeFechaEntregaCK.Value = ObjFichadr.dFechaHoraEntregaCK
            Else
                Me.cdeFechaEntregaCK.Value = Me.cdeFechaEntregaCK.ValueIsDbNull
            End If

            'Tipo Plazo
            If Not ObjFichadr.IsFieldNull("nStbTipoPlazoPeriodoGraciaID") Then
                XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoPlazoPeriodoGraciaID)
            Else
                Me.cboTipoPlazo.Text = ""
                Me.cboTipoPlazo.SelectedIndex = -1
            End If

            'Plazo del Periodo de Gracia:
            If Not ObjFichadr.IsFieldNull("nTotalPeriodoGracia") Then
                Me.cnePlazoPeriodoGracia.Value = ObjFichadr.nTotalPeriodoGracia
            Else
                Me.cnePlazoPeriodoGracia.Value = 0
            End If

            'Tipo Plazo Pagos Socias:
            If Not ObjFichadr.IsFieldNull("nStbTipoPlazoPagosID") Then
                XdsFicha("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoPlazoPagosID)
            Else
                Me.cboTipoPlazoPagos.Text = ""
                Me.cboTipoPlazoPagos.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos
            'Me.txtNoSesion.MaxLength = ObjFichadr.GetColumnLenght("sNumSesion")
            Me.txtObservaciones.MaxLength = ObjFichadr.GetColumnLenght("sObservacion")
            Me.txtHorarioPagos.MaxLength = ObjFichadr.GetColumnLenght("sHorarioEntregaPagos")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing

            ObjUbicacionDT.Close()
            ObjUbicacionDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/09/2007
    ' Procedure Name:       CmdCancelActualizacion_Click
    ' Descripción:          Este evento permite ocultar datos de actualización
    '                       de monto y plazo y rehabilitar tbResolucion sin
    '                       haberse efectuado ningún cambio en monto y plazo.
    '-------------------------------------------------------------------------
    Private Sub CmdCancelActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelActualizacion.Click
        'Reestablecer ambiente:
        grpMontoAprobado.Visible = False
        tbResolucion.Enabled = True
        Me.tabPDatosGrales.Enabled = True
        Me.tabPExpediente.Enabled = True
        MsgBox("No se realizó ningún cambio.", MsgBoxStyle.Information)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/09/2007
    ' Procedure Name:       CmdActualizar_Click
    ' Descripción:          Este evento permite actualizar el monto y plazo
    '                       autorizado del crédito a una socia determinada
    '                       en la tabla: SclFichaNotificacionDetalle
    '-------------------------------------------------------------------------
    Private Sub CmdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdActualizar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable

        Try
            Dim strSQL As String
            Dim intPosicion As Integer
            Dim nCreditoUsuraCero As Integer
            Dim nCreditoUCMercado As Integer
            Dim nCreditoPDIBA As Integer

            nCreditoUCMercado = 0
            nCreditoPDIBA = 0





            '-- Si es Credito del Programa Usura Cero.
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '3')"


            If RegistrosAsociados(strSQL) Then 'Grupo Solidario usura cero
                nCreditoPDIBA = 1
            End If


            '-- Si es Credito del Programa Usura Cero.
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
            If RegistrosAsociados(strSQL) Then 'Grupo Solidario usura cero
                nCreditoUsuraCero = 1


                'Determinar si es de Mercados:
                strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (SclTipodePlandeNegocio.nCodigo = 5)"
                If RegistrosAsociados(strSQL) Then
                    nCreditoUCMercado = 1
                End If
            Else 'Grupo Solidario Ventana de Genero


                nCreditoUsuraCero = 0
            End If

            'Imposible si no se indicó un Monto Válido:
            If Not IsNumeric(cneMontoAprobado.Value) Then
                MsgBox("Monto Aprobado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                Me.cneMontoAprobado.Focus()
                Exit Sub
            End If
            If CDbl(cneMontoAprobado.Value) = 0 Then
                MsgBox("Monto Aprobado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                Me.cneMontoAprobado.Focus()
                Exit Sub
            End If

            'Imposible si no se indicó un plazo válido:
            If Not IsNumeric(cnePlazoAprobado.Value) Then
                MsgBox("Plazo Aprobado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errFicha.SetError(Me.cnePlazoAprobado, "Plazo Aprobado Inválido.")
                Me.cnePlazoAprobado.Focus()
                Exit Sub
            End If
            If CDbl(cnePlazoAprobado.Value) = 0 Then
                MsgBox("Plazo Aprobado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errFicha.SetError(Me.cnePlazoAprobado, "Plazo Aprobado Inválido.")
                Me.cnePlazoAprobado.Focus()
                Exit Sub
            End If






            



            'Validar Monto Mínimo/Máximo:
            If nCreditoUsuraCero = 1 Then
                XdtValorParametro.Filter = "nStbParametroID = 7"
            Else


                ''-- Si es Credito del Programa Usura Cero PDIBA.
                'strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                '         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                '         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                '         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '3')"
                'If RegistrosAsociados(strSQL) Then 'Grupo Solidario usura cero PDIBA
                If nCreditoPDIBA = 1 Then
                    XdtValorParametro.Filter = "nStbParametroID = 91"
                Else 'Grupo Solo USURA CERO
                    XdtValorParametro.Filter = "nStbParametroID = 54"
                End If




            End If
            XdtValorParametro.Retrieve()
            'Monto Mínimo:
            ' Si es TURISMO es 10,000
            Dim cmd As New BOSistema.Win.XComando

            Dim intFichaDetalleID As Integer = 0
            intFichaDetalleID = XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")

            Dim creditoNO As Integer = 0
            strSQL = "select dbo.fnNumerodelCreditoFND_Turismo(" & intFichaDetalleID & ")"
            creditoNO = IIf(IsDBNull(cmd.ExecuteScalar(strSQL)), 0, cmd.ExecuteScalar(strSQL))

            strSQL = "select dbo.fnSclFichaSoloTurismo(" & intFichaID & ")"
            Dim ficha As Integer = cmd.ExecuteScalar(strSQL)

            Dim MontoPremitido As Integer = 0
            MontoPremitido = IIf(IsDBNull(cmd.ExecuteScalar("Select 10000*[dbo].[fnNumerodelCreditoFND_Turismo](" & intFichaDetalleID & ")")), 0, cmd.ExecuteScalar("Select 10000*[dbo].[fnNumerodelCreditoFND_Turismo](" & intFichaDetalleID & ")"))

            If ficha = 1 Then
                'If Me.cneMontoAprobado.Value < 10000 Then
                If Me.cneMontoAprobado.Value < MontoPremitido Then
                    MsgBox("El Monto Aprobado NO DEBE ser menor a C$ " & Format(MontoPremitido, "#,##0.00") & "," & Chr(10) &
                            "establecido como mínimo por el programa para esta" & Chr(13) & "modalidad de crédito (TURISMO).", MsgBoxStyle.Critical, NombreSistema)
                    Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                    Me.cneMontoAprobado.Focus()
                    Exit Sub
                End If
            Else
                If Me.cneMontoAprobado.Value < CDbl(XdtValorParametro.ValueField("sValorParametro")) Then
                    MsgBox("El Monto Aprobado NO DEBE ser menor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) &
                           "establecido como mínimo por el programa.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                    Me.cneMontoAprobado.Focus()
                    Exit Sub
                End If
            End If


            If nCreditoUsuraCero = 1 Then
                If nCreditoUCMercado = 0 Then
                    XdtValorParametro.Filter = "nStbParametroID = 8"
                Else 'Mercados Pago Diario
                    XdtValorParametro.Filter = "nStbParametroID = 65"
                End If
            Else
                '-- Si es Credito del Programa Usura Cero PDIBA.
                'strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                '         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                '         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                '         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '3')"
                'If RegistrosAsociados(strSQL) Then 'Grupo Solidario usura cero PDIBA

                If nCreditoPDIBA = 1 Then
                    XdtValorParametro.Filter = "nStbParametroID = 92" ''
                Else
                    XdtValorParametro.Filter = "nStbParametroID = 55" ''Es Ventana de Genero
                End If







            End If
            XdtValorParametro.Retrieve()
            'Monto Máximo:
            ' Si es TURISMO es 10,000
            strSQL = "select dbo.fnSclFichaSoloTurismo(" & intFichaID & ")"
            ficha = cmd.ExecuteScalar(strSQL)

            If ficha = 1 Then
                If Me.cneMontoAprobado.Value > MontoPremitido Then
                    MsgBox("El Monto Aprobado NO DEBE ser mayor a C$ " & Format(MontoPremitido, "#,##0.00") & "," & Chr(10) &
                            "establecido como máximo por el programa para esta" & Chr(13) & "modalidad de crédito (TURISMO).", MsgBoxStyle.Critical, NombreSistema)
                    Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                    Me.cneMontoAprobado.Focus()
                    Exit Sub
                End If
            Else
                If Me.cneMontoAprobado.Value > CDbl(XdtValorParametro.ValueField("sValorParametro")) Then
                    MsgBox("El Monto Aprobado NO DEBE ser mayor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) &
                            "establecido como máximo por el programa para esta" & Chr(13) & "modalidad de crédito.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                    Me.cneMontoAprobado.Focus()
                    Exit Sub
                End If
            End If
            'Validar Plazo Mínimo/Máximo:
            If nCreditoUsuraCero = 1 Then
                XdtValorParametro.Filter = "nStbParametroID = 9"
            Else
                If nCreditoPDIBA = 1 Then
                    XdtValorParametro.Filter = "nStbParametroID = 88"
                Else
                    XdtValorParametro.Filter = "nStbParametroID = 56"
                End If

            End If
            XdtValorParametro.Retrieve()
            'Plazo Mínimo:
            If CInt(Me.cnePlazoAprobado.Value) < CInt(XdtValorParametro.ValueField("sValorParametro")) Then
                MsgBox("El Plazo NO DEBE ser menor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
                    "establecido como mínimo por el Programa.", MsgBoxStyle.Critical, NombreSistema)
                Me.errFicha.SetError(Me.cnePlazoAprobado, "Plazo Aprobado Inválido.")
                Me.cnePlazoAprobado.Focus()
                Exit Sub
            End If

            If nCreditoUsuraCero = 1 Then
                If nCreditoUCMercado = 0 Then
                    XdtValorParametro.Filter = "nStbParametroID = 10"
                Else 'Mercados Pago Diario
                    XdtValorParametro.Filter = "nStbParametroID = 64"
                End If
            Else
                If nCreditoPDIBA = 1 Then
                    XdtValorParametro.Filter = "nStbParametroID = 89"
                Else
                    XdtValorParametro.Filter = "nStbParametroID = 57"
                End If

            End If
            XdtValorParametro.Retrieve()
            'Plazo Máximo:
            Dim a As Integer = CInt(XdtValorParametro.ValueField("sValorParametro"))

            If CInt(Me.cnePlazoAprobado.Value) > CInt(XdtValorParametro.ValueField("sValorParametro")) Then
                MsgBox("El Plazo NO DEBE ser mayor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
                    "establecido como máximo por el Programa.", MsgBoxStyle.Critical, NombreSistema)
                Me.errFicha.SetError(Me.cnePlazoAprobado, "Plazo Aprobado Inválido.")
                Me.cnePlazoAprobado.Focus()
                Exit Sub
            End If

            '-- Para Créditos Grupales Usura Cero:
            If (nCreditoUsuraCero = 1 Or nCreditoPDIBA = 1) And ficha <> 1 Then

                'Monto debe estar contenido en la Tabla de Amortización:
                'CadTmp = if  nCreditoUsuraCero = 1 then  CadenaAnexa=' nAplicaUsuraCero=1' else if   nCreditoPDIBA  = 1 then   CadenaAnexa=' nAplicaPdiba=1'
                strSQL = "SELECT * FROM  StbTablaAmortizacion WHERE  (nMonto = " & Me.cneMontoAprobado.Value & ")  "  '+ CadenaAnexa

                If nCreditoUsuraCero = 1 Then
                    strSQL &= " and nAplicaUsuraCero=1"
                ElseIf nCreditoPDIBA = 1
                    strSQL &= " and nAplicaPdiba=1"
                End If

                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Monto NO esta contenido dentro de las Tablas de Amortización" & Chr(10) &
                           "establecidas por el Programa.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                    Me.cneMontoAprobado.Focus()
                    Exit Sub
                End If
                'Plazo debe estar contenido en la Tabla de Amortización:
                strSQL = "SELECT * FROM  StbTablaAmortizacion WHERE  (nPlazo = " & Me.cnePlazoAprobado.Value & ") "

                If nCreditoUsuraCero = 1 Then
                    strSQL &= " and nAplicaUsuraCero=1"
                ElseIf nCreditoPDIBA = 1
                    strSQL &= " and nAplicaPdiba=1"
                End If

                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Plazo NO esta contenido dentro de las Tablas de Amortización" & Chr(10) &
                           "establecidas por el Programa.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errFicha.SetError(Me.cnePlazoAprobado, "Plazo Aprobado Inválido.")
                    Me.cnePlazoAprobado.Focus()
                    Exit Sub
                End If

            End If


            'Agregado 20 de Agosto 2013 Para que solo se permita aprobar montos de 10 mil 
            'al recibir su quinto credito en programa USURA CERO.




            Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
            Dim CreditosCanceladosMinimo As Integer
            Dim SociaID As Integer


            If (nCreditoUsuraCero = 1 And CDbl(cneMontoAprobado.Value) >= 10000 And CDbl(cneMontoAprobado.Value) < 20000) And ficha <> 1 Then


                strSQL = "SELECT     dbo.SclGrupoSocia.nSclSociaID FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN                      dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON  dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID  " &
                "WHERE(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID") & ")"
                XdtDatos.ExecuteSql(strSQL)
                SociaID = XdtDatos.ValueField("nSclSociaID")

                strSQL = " SELECT     sValorParametro FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 99) "


                XdtDatos.ExecuteSql(strSQL)
                If XdtDatos.Count > 0 Then

                    CreditosCanceladosMinimo = XdtDatos.ValueField("sValorParametro")

                    strSQL = "SELECT     COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID) AS TotalCancelados " &
                             "   FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN " &
                             " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  " &
                             " dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN " &
                             " dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  " &
                             " dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " &
                             " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID  " &
                             " WHERE     (dbo.SclGrupoSocia.nSclSociaID = " & SociaID & "  ) AND (dbo.StbValorCatalogo.sCodigoInterno = '7') AND (StbValorCatalogo_1.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)"


                    XdtDatos.ExecuteSql(strSQL)


                    'If Seg.HasPermission("AprobarFichaMontoDiezMil") = False Then
                    If XdtDatos.ValueField("TotalCancelados") < CreditosCanceladosMinimo And ficha <> 1 Then
                        MsgBox("Monto de 10 mil cordobas a más para programa usura cero. Necesita tener al menos " & CreditosCanceladosMinimo & " Créditos Cancelados. ", MsgBoxStyle.Information)
                        Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                        Me.cneMontoAprobado.Focus()
                        Exit Sub
                    End If


                    'End If


                End If




                strSQL = "SELECT * FROM  StbTablaAmortizacion WHERE  (nPlazo = " & Me.cnePlazoAprobado.Value & ")"
                If nCreditoUsuraCero = 1 Then
                    strSQL &= " and nAplicaUsuraCero=1"
                ElseIf nCreditoPDIBA = 1
                    strSQL &= " and nAplicaPdiba=1"
                End If
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Plazo NO esta contenido dentro de las Tablas de Amortización." & Chr(10) &
                               "establecidas por el Programa.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errFicha.SetError(Me.cnePlazoAprobado, "Plazo Aprobado Inválido.")
                    Me.cnePlazoAprobado.Focus()
                    Exit Sub
                End If

            End If



            'VALIDACION TURISMO 4 CREDITOS MAXIMO

            'strSQL = "SELECT     dbo.SclGrupoSocia.nSclSociaID FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN                      dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON  dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID  " &
            '    "WHERE(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID") & ")"
            'XdtDatos.ExecuteSql(strSQL)
            'SociaID = XdtDatos.ValueField("nSclSociaID")

            'strSQL = " SELECT sValorParametro FROM dbo.StbValorParametro WHERE (nStbParametroID = 114) "
            'Dim MaximoCreditosTurismo As Object
            'XdtDatos.ExecuteSql(strSQL)
            'MaximoCreditosTurismo = XdtDatos.ValueField("sValorParametro")

            'If Not IsDBNull(MaximoCreditosTurismo) Then
            '    If ficha = 1 Then
            '        strSQL = "SELECT     COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID) AS TotalCancelados " &
            '                 "   FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN " &
            '                 " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  " &
            '                 " dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN " &
            '                 " dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  " &
            '                 " dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " &
            '                 " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID  " &
            '                 " WHERE     (dbo.SclGrupoSocia.nSclSociaID = " & SociaID & "  ) AND (dbo.StbValorCatalogo.sCodigoInterno = '7') AND (StbValorCatalogo_1.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)"
            '        XdtDatos.ExecuteSql(strSQL)
            '        Dim tot As Integer = XdtDatos.ValueField("TotalCancelados")
            '        If XdtDatos.ValueField("TotalCancelados") >= MaximoCreditosTurismo Then
            '            MsgBox("Monto de 10 mil cordobas a más para programa usura cero. Necesita tener al menos " & CreditosCanceladosMinimo & " Créditos Cancelados. ", MsgBoxStyle.Information)
            '            Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
            '            Me.cneMontoAprobado.Focus()
            '            Exit Sub
            '        End If
            '    End If
            'End If



            '' Cambios Diciembre 9 2015  





            If (nCreditoUsuraCero = 1 And CDbl(cneMontoAprobado.Value) >= 20000) And ficha<>1 Then




                Dim XdtDatosTmp As New BOSistema.Win.XDataSet.xDataTable
                Dim CreditosCanceladosMinimoTmp As Integer
                Dim SociaIDTmp As Integer



                strSQL = "SELECT     dbo.SclGrupoSocia.nSclSociaID FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN                      dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON  dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID  " & _
                "WHERE(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID") & ")"
                XdtDatosTmp.ExecuteSql(strSQL)
                SociaIDTmp = XdtDatosTmp.ValueField("nSclSociaID")

                strSQL = " SELECT     sValorParametro FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 110) "


                XdtDatosTmp.ExecuteSql(strSQL)
                If XdtDatosTmp.Count > 0 Then

                    CreditosCanceladosMinimoTmp = XdtDatosTmp.ValueField("sValorParametro")

                    strSQL = "SELECT     COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID) AS TotalCancelados " & _
                             "   FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN " & _
                             " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  " & _
                             " dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN " & _
                             " dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  " & _
                             " dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " & _
                             " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID  " & _
                             " WHERE     (dbo.SclGrupoSocia.nSclSociaID = " & SociaIDTmp & "  ) AND (dbo.StbValorCatalogo.sCodigoInterno = '7') AND (StbValorCatalogo_1.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)"


                    XdtDatosTmp.ExecuteSql(strSQL)


                    If Seg.HasPermission("AprobarFichaMontoDiezMil") = False Then
                        If XdtDatosTmp.ValueField("TotalCancelados") < CreditosCanceladosMinimoTmp Then
                            MsgBox("Monto de 20 mil cordobas a más para programa usura cero. Necesita tener al menos " & CreditosCanceladosMinimoTmp & " Créditos Cancelados. ", MsgBoxStyle.Information)
                            Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                            Me.cneMontoAprobado.Focus()
                            Exit Sub
                        End If


                    End If


                End If


            End If













            'Agregado Noviembre 2014, para evitar que puedan ingresar socias con mas de n creditos cancelados.
            Dim XdtDatosSocia As New BOSistema.Win.XDataSet.xDataTable
            Dim CreditosCanceladosMaximoSocia As Integer



            Dim SociaIDBusca As Integer



            strSQL = "SELECT     dbo.SclGrupoSocia.nSclSociaID FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN                      dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON  dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN  dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID  " & _
            "WHERE(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID") & ")"
            XdtDatosSocia.ExecuteSql(strSQL)
            SociaIDBusca = XdtDatosSocia.ValueField("nSclSociaID")







            strSQL = " SELECT     sValorParametro FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 106) "


            XdtDatosSocia.ExecuteSql(strSQL)
            If XdtDatosSocia.Count > 0 Then

                CreditosCanceladosMaximoSocia = XdtDatosSocia.ValueField("sValorParametro")


                strSQL = "SELECT     COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID) AS TotalCancelados " & _
                               "   FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN " & _
                               " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  " & _
                               " dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN " & _
                               " dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  " & _
                               " dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " & _
                               " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID  " & _
                               " WHERE     (dbo.SclGrupoSocia.nSclSociaID = " & SociaIDBusca & "  ) AND (dbo.StbValorCatalogo.sCodigoInterno = '7') AND (StbValorCatalogo_1.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)"


                XdtDatosSocia.ExecuteSql(strSQL)



                If XdtDatosSocia.ValueField("TotalCancelados") >= CreditosCanceladosMaximoSocia Then
                    MsgBox("Recordatorio. Solamente se permite hasta un máximo de " & CreditosCanceladosMaximoSocia & " Créditos Cancelados.", MsgBoxStyle.Information)
                    'Me.errFicha.SetError(Me.cneMontoAprobado, "Monto Aprobado Inválido.")
                    'Me.cneMontoAprobado.Focus()
                    'Exit Sub
                End If





            End If

            'Fin de Agregado Noviembre 2014



            'Agregado en Agosto 2018
            'CREDITOS DE SEGUNDA ETAPA
            strSQL = "SELECT        nSclFichaNotificacionID, nSclFichaNotificacionDetalleID, nSclSociaID, CreditoNO AS TotalCreditos, CreditoSE_NO AS TotalCreditosSE, CreditoSE_NO + 1 AS ActualCreditosSE, 
            CASE WHEN CreditoSE_NO <= 2 THEN 10000 + CreditoSE_NO * 5000 ELSE CreditoSE_NO * 10000 END AS MontoMaximo, nMontoCreditoAprobado, 
            CASE WHEN CASE WHEN CreditoSE_NO <= 2 THEN 10000 + CreditoSE_NO * 5000 ELSE CreditoSE_NO * 10000 END >= nMontoCreditoAprobado THEN 1 ELSE 0 END AS Permisible
            FROM            (SELECT        SclFichaNotificacionCredito_1.nSclFichaNotificacionID, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, dbo.SclGrupoSocia.nSclSociaID, 
            dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS CreditoNO, 
            COUNT(CASE WHEN dbo.StbValorCatalogo.sCodigoInterno = '7' THEN dbo.SclFichaSegundaEtapa.nSclFichaSegundaEtapaID ELSE NULL END) AS CreditoSE_NO, 
            dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado
            FROM            dbo.SclFichaNotificacionDetalle AS SclFichaNotificacionDetalle_1 LEFT OUTER JOIN
            dbo.SclFichaSocia LEFT OUTER JOIN
            dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID ON 
            SclFichaNotificacionDetalle_1.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID LEFT OUTER JOIN
            dbo.StbValorCatalogo AS StbValorCatalogo_1 RIGHT OUTER JOIN
            dbo.SclFichaNotificacionCredito ON StbValorCatalogo_1.nStbValorCatalogoID = dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID ON 
            SclFichaNotificacionDetalle_1.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID RIGHT OUTER JOIN
            dbo.SclFichaSegundaEtapa ON SclFichaNotificacionDetalle_1.nSclFichaNotificacionDetalleID = dbo.SclFichaSegundaEtapa.nSclFichaNotificacionDetalleID RIGHT OUTER JOIN
            dbo.SclFichaNotificacionCredito AS SclFichaNotificacionCredito_1 LEFT OUTER JOIN
            dbo.SclFichaNotificacionDetalle ON SclFichaNotificacionCredito_1.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID LEFT OUTER JOIN
            dbo.SclFichaSocia AS SclFichaSocia_1 ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia_1.nSclFichaSociaID LEFT OUTER JOIN
            dbo.SclGrupoSocia ON SclFichaSocia_1.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID ON dbo.SclFichaSegundaEtapa.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID
            WHERE        (dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = {{0}}) AND (SclFichaNotificacionDetalle_1.nCreditoRechazado = 0 OR
            SclFichaNotificacionDetalle_1.nCreditoRechazado IS NULL) AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)
            GROUP BY SclFichaNotificacionCredito_1.nSclFichaNotificacionID, dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, 
            dbo.SclGrupoSocia.nSclSociaID, dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado) AS I
            WHERE        (CASE WHEN CASE WHEN CreditoSE_NO <= 2 THEN 10000 + CreditoSE_NO * 5000 ELSE CreditoSE_NO * 10000 END >= {{1}} THEN 1 ELSE 0 END = 0)" _
            .Replace("{{0}}", XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")) _
            .Replace("{{1}}", cneMontoAprobado.Value)

            If RegistrosAsociados(strSQL) Then
                MsgBox("Este monto NO es permisible para esta socia de SEGUNDA ETAPA, verifique según el número de créditos que tenga.", vbExclamation)
                Me.cneMontoAprobado.Focus()
                Exit Sub
            End If


            'Confirmar Cambio:
            If MsgBox("¿Está seguro de modificar Monto y Plazo aprobado" & Chr(13) & "del Crédito para la socia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
                'Actualizar montos en SclFichaNotificacionDetalle:
                strSQL = " Update SclFichaNotificacionDetalle " & _
                         " SET sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), nMontoCreditoAprobado = " & cneMontoAprobado.Value & ", nPlazoAprobado = " & cnePlazoAprobado.Value & " Where " & _
                         " nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")

                XcDatos.ExecuteNonQuery(strSQL)

                strSQL = "Exec SpAUDITSclFichaNotificacionDetalleMontoPlazo  'Update','Actualizar  Ficha Monto Plazo'," & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID") & "," & cneMontoAprobado.Value & "," & cnePlazoAprobado.Value & "," & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "',1"

                XcDatos.ExecuteNonQuery(strSQL)
                'Guardar posición actual de la selección
                intPosicion = XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")
                'Refrescar Cambios:
                CargarResolucionCredito()
                FormatoResolucionCredito()
                'Ubicar la selección en la posición original
                XdsDetalle("Resolucion").SetCurrentByID("nSclFichaNotificacionDetalleID", intPosicion)
                Me.grdResolucion.Row = XdsDetalle("Resolucion").BindingSource.Position
                MsgBox("Montos actualizados Exitosamente.", MsgBoxStyle.Information, NombreSistema)
            End If

            'Reestablecer ambiente:
            grpMontoAprobado.Visible = False
            tbResolucion.Enabled = True
            Me.tabPDatosGrales.Enabled = True
            Me.tabPExpediente.Enabled = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then

                'Guarda Encabezado de la FNC:
                SalvarFicha()

                'Habilita las siguientes Pestañas:
                Me.tabPExpediente.Enabled = True
                Me.tabPResolucion.Enabled = True

                'Actualiza Etiqueta del Código de la FNC:
                Me.txtCodigo.Text = ObjFichadr.nCodigo
                Me.txtCodigoE.Text = ObjFichadr.nCodigo
                Me.txtCodigoRC.Text = ObjFichadr.nCodigo

                'Actualiza Estado:
                ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjFichadr.nStbEstadoCreditoID
                ObjEstadoDT.Retrieve()
                If ObjEstadoDT.Count > 0 Then
                    Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoE.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoRC.Text = ObjEstadoDT.ValueField("sDescripcion")
                End If

                'Actualiza GS:
                txtGrupoE.Text = txtNombreGS.Text
                txtGrupoRC.Text = txtNombreGS.Text

                If Me.intFichaID <> 0 Then
                    If MsgBox("¿Desea Continuar Ingresando Datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    Else
                        ModoFrm = "UPD"
                        CargarExpediente()
                        FormatoExpediente()
                        CargarResolucionCredito()
                        FormatoResolucionCredito()
                        Me.tabPExpediente.Show()
                    End If
                Else
                    AccionUsuario = AccionBoton.BotonAceptar
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable

        Dim xObligarConCajaLocal As Integer
        Try

            Dim strSQL As String = ""
            Dim strSQLA As String = ""

            ValidaDatosEntrada = True
            IntTipoCambioID = 0
            Me.errFicha.Clear()

            'Fecha de Resolución del Crédito:
            If Me.cdeFechaNotificacion.ValueIsDbNull Then
                MsgBox("La Fecha de Resolución del Crédito NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaNotificacion, "La Fecha de Resolución del Crédit NO DEBE quedar vacía.")
                Me.cdeFechaNotificacion.Focus()
                Exit Function
            End If

            'Si la Hora de Resolución se dejo en 12:00 a.m.:
            If Mid(Me.cdeFechaNotificacion.Text, 12, 16) = "12:00 a.m." Then
                MsgBox("Debe indicar una Hora de Resolución del Crédito valida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaNotificacion, "Debe indicar una Hora de Resolución del Crédito valida.")
                Me.cdeFechaNotificacion.Focus()
                Exit Function
            End If

            'Fecha de Resolución no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaNotificacion.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Resolución NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaNotificacion, "La Fecha de Resolución NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaNotificacion.Focus()
                Exit Function
            End If

            'Fecha de Resolución no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaNotificacion.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Resolución NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaNotificacion, "La Fecha de Resolución NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaNotificacion.Focus()
                Exit Function
            End If

            'Fecha de Resolución de un mes Contable Cerrado:
            If PeriodoAbiertoDadaFecha(Format(Me.cdeFechaNotificacion.Value, "yyyy-MM-dd")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaNotificacion, "El mes se encuentra Cerrado.")
                Me.cdeFechaNotificacion.Focus()
                Exit Function
            End If

            'Fecha de Firma del Acta de Compromiso:
            If Me.cdeFechaActaC.ValueIsDbNull Then
                MsgBox("La Fecha de Firma del Acta de Compromiso del" & Chr(13) & "Grupo Solidario NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaActaC, "La Fecha de Firma del Acta de Compromiso del Grupo Solidario NO DEBE quedar vacía.")
                Me.cdeFechaActaC.Focus()
                Exit Function
            End If

            'Fecha de Firma del Acta no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaActaC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Firma del Acta NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaActaC, "La Fecha de Firma del Acta NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaActaC.Focus()
                Exit Function
            End If

            'Fecha de Firma del Acta no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaActaC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Firma del Acta NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaActaC, "La Fecha de Firma del Acta NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaActaC.Focus()
                Exit Function
            End If

            'Fecha de Resolución del Crédito DEBE ser superior a la de Firma del Acta de Compromiso:
            If Me.cdeFechaNotificacion.Value < cdeFechaActaC.Value Then
                MsgBox("Fecha de Resolución del Crédito DEBE ser superior" & Chr(13) & "a la de Firma del Acta de Compromiso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaNotificacion, "Fecha de Resolución del Crédito DEBE ser superior a la de Firma del Acta de Compromiso.")
                Me.cdeFechaNotificacion.Focus()
                Exit Function
            End If

            'Si se indica Fecha de entrega de Cheque:
            If Not (Me.cdeFechaEntregaCK.ValueIsDbNull) Then
                'Si la Hora de Entrega se dejo en 12:00 a.m.:
                If Mid(Me.cdeFechaEntregaCK.Text, 12, 16) = "12:00 a.m." Then
                    MsgBox("Debe indicar una Hora de Entrega del Cheque valida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cdeFechaEntregaCK, "Debe indicar una Hora de Entrega del Cheque valida.")
                    Me.cdeFechaEntregaCK.Focus()
                    Exit Function
                End If
                'Fecha no menor que la fecha de inicio del Programa:
                If BlnFechaInferiorParametros(Format(Me.cdeFechaEntregaCK.Value, "yyyy-MM-dd")) Then
                    MsgBox("La Fecha de Entrega del Cheque NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cdeFechaEntregaCK, "La Fecha de Entrega del Cheque NO DEBE ser menor a la de inicio del Programa.")
                    Me.cdeFechaEntregaCK.Focus()
                    Exit Function
                End If
                'Fecha no mayor que la fecha de corte en parámetros:
                If BlnFechaSuperiorParametros(Format(Me.cdeFechaEntregaCK.Value, "yyyy-MM-dd")) Then
                    MsgBox("La Fecha de Entrega del Cheque NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cdeFechaEntregaCK, "La Fecha de Entrega del Cheque NO DEBE ser mayor a la de corte en parámetros.")
                    Me.cdeFechaEntregaCK.Focus()
                    Exit Function
                End If
                'Debe existir un Tipo de Cambio para Fecha de Entrega de Cheque:
                strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaEntregaCK.Value, "yyyy-MM-dd") & "', 102))"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("No existe una Tasa de Cambio para la Fecha de Entrega del Cheque.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cdeFechaEntregaCK, "No existe una Tasa de Cambio para la Fecha de Entrega del Cheque.")
                    Me.cdeFechaEntregaCK.Focus()
                    Exit Function
                Else
                    'ID de TC para marcarlo como Ocupado:
                    IntTipoCambioID = XcDatos.ExecuteScalar(strSQL)
                End If
                'Fecha de última cuota debe de ser mayor que la fecha primer cuota:
                If Not (Me.cdeFechaUltimaCuota.ValueIsDbNull) Then
                    If Me.cdeFechaUltimaCuota.Value <= cdeFechaPrimerCuota.Value Then
                        MsgBox("La Fecha de Ultimo Pago de Cuota del Grupo Solidario" & Chr(13) & "DEBE ser superior a la de Primer Pago.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errFicha.SetError(Me.cdeFechaUltimaCuota, "La Fecha de Ultimo Pago de Cuota del Grupo Solidario debe ser superior a la de Primer Pago.")
                        Me.cdeFechaUltimaCuota.Focus()
                        Exit Function
                    End If
                End If
                'Fecha de pago de primer cuota debe ser superior a la de Firma de Acta de Compromiso:
                If Not (Me.cdeFechaPrimerCuota.ValueIsDbNull) Then
                    If Me.cdeFechaPrimerCuota.Value <= cdeFechaActaC.Value Then
                        MsgBox("La Fecha de Primer Pago de Cuota del Grupo Solidario" & Chr(13) & "DEBE ser superior a la de Firma del Acta de Compromiso.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errFicha.SetError(Me.cdeFechaPrimerCuota, "La Fecha de Primer Pago de Cuota del Grupo Solidario DEBE ser superior a la de Firma del Acta de Compromiso.")
                        Me.cdeFechaPrimerCuota.Focus()
                        Exit Function
                    End If
                End If
                'Fecha de Entrega del CK debe ser superior a Firma de Acta de Compromiso:
                If Me.cdeFechaEntregaCK.Value < cdeFechaActaC.Value Then
                    MsgBox("La Fecha de Entrega del Cheque del Grupo Solidario DEBE" & Chr(13) & "ser superior a la de Firma del Acta de Compromiso.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cdeFechaEntregaCK, "La Fecha de Entrega del Cheque del Grupo Solidario DEBE ser superior a la de Firma del Acta de Compromiso.")
                    Me.cdeFechaEntregaCK.Focus()
                    Exit Function
                End If
                'Día de pagos Debe corresponder con Día de Entrega del Ck:
                If DateAndTime.Weekday(Me.cdeFechaEntregaCK.Value) <> XdsFicha("DiaPagos").ValueField("sCodigoInterno") Then
                    MsgBox("Día de pagos no corresponde con" & Chr(13) & "Fecha de Entrega del Cheque.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboDiaPagos, "Día de pagos no corresponde con fecha de Entrega del Cheque.")
                    Me.cboDiaPagos.Focus()
                    Exit Function
                End If
                'Fecha de Cheque de un mes Contable Cerrado:
                If PeriodoAbiertoDadaFecha(Format(Me.cdeFechaEntregaCK.Value, "yyyy-MM-dd")) = False Then
                    MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cdeFechaEntregaCK, "El mes se encuentra Cerrado.")
                    Me.cdeFechaEntregaCK.Focus()
                    Exit Function
                End If
            End If

            'Departamento:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            'El Municipio seleccionado Debe corresponder con el de la Delegación del usuario:
            If IntPermiteEditarFNC = 0 Then
                strSQL = "SELECT b.nStbDepartamentoID FROM StbDelegacionPrograma a INNER JOIN StbMunicipio b ON a.nStbMunicipioID = b.nStbMunicipioID WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                If Me.cboDepartamento.Columns("nStbDepartamentoId").Value <> XcDatos.ExecuteScalar(strSQL) Then
                    MsgBox("Departamento no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboDepartamento, "Departamento no corresponde a su Delegación.")
                    Me.cboDepartamento.Focus()
                    Exit Function
                End If
            End If

            'Distrito:
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            'Barrio:
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Barrio válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboBarrio, "Debe seleccionar un Barrio válido.")
                Me.cboBarrio.Focus()
                Exit Function
            End If

            'Grupo:
            If Me.cboGrupo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Grupo Solidario válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboGrupo, "Debe seleccionar un Grupo Solidario válido.")
                Me.cboGrupo.Focus()
                Exit Function
            End If

            'Grupo Solidario seleccionado NO debe de contener 
            'Fichas de Inscripción En Proceso o Pendientes de Verificar:
            strSQL = " SELECT a.nSclGrupoSolidarioID " & _
                     " FROM  dbo.SclGrupoSolidario AS a INNER JOIN dbo.SclGrupoSocia AS b " & _
                     " ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID INNER JOIN dbo.SclFichaSocia AS c " & _
                     " ON b.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN dbo.StbValorCatalogo AS d ON c.nStbEstadoFichaID = d.nStbValorCatalogoID " & _
                     " WHERE  (d.sCodigoInterno IN ('1', '2')) AND (a.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("El Grupo seleccionado contiene Fichas" & Chr(13) & "de Inscripción aún NO Verificadas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboGrupo, "El Grupo seleccionado contiene Fichas de Inscripción aún NO Verificadas.")
                Me.cboGrupo.Focus()
                Exit Function
            End If

            'Si es una ADD imposible si existe otra FNC con el
            'estado En Proceso para el GS seleccionado:
            If ModoForm = "ADD" Then
                strSQL = "SELECT a.nSclFichaNotificacionID FROM SclFichaNotificacionCredito a INNER JOIN StbValorCatalogo b ON a.nStbEstadoCreditoID = b.nStbValorCatalogoID WHERE (a.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (b.sCodigoInterno = '1')"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existe una Ficha de Notificación En Proceso" & Chr(13) & "para El Grupo seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboGrupo, "Existe una Ficha de Notificación En Proceso para El Grupo seleccionado.")
                    Me.cboGrupo.Focus()
                    Exit Function
                End If
            End If

            '-- Si es Credito Individual Numero Minimo = 1, Else = Parametro.
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (SclTipodePlandeNegocio.nCreditoIndividual = 1)"
            If RegistrosAsociados(strSQL) Then 'Credito Individual
                intNoMinimoSocias = 1
            Else 'Grupo Solidario
                strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
                If RegistrosAsociados(strSQL) Then 'Si es Grupo Solidario Usura Cero /Mercados:
                    strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 16)"
                Else 'Grupo Solidario Ventana de Genero:
                    strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2')"

                    If RegistrosAsociados(strSQL) Then 'Si es Grupo Solidario Ventana Genero:
                        strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 58)"

                    End If

                    'PDIBA
                    strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 93)"
                End If
                'Asigna Numero Minimo de Socias:
                intNoMinimoSocias = XcDatos.ExecuteScalar(strSQL)
            End If

            'Grupo Solidario seleccionado DEBE de contener 
            'al menos X Fichas de Inscripción Verificadas si es ADD o en Detalles FNC si es UPD:
            If ModoForm = "ADD" Then
                strSQL = " SELECT  COUNT(a.nSclGrupoSolidarioID) AS FichasVerificadas " & _
                         " FROM   dbo.SclGrupoSolidario AS a INNER JOIN dbo.SclGrupoSocia AS b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID INNER JOIN dbo.SclFichaSocia AS c " & _
                         " ON b.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN dbo.StbValorCatalogo AS d ON c.nStbEstadoFichaID = d.nStbValorCatalogoID " & _
                         " WHERE  (d.sCodigoInterno = '3') AND (a.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ")"
            Else
                strSQL = " SELECT COUNT(nSclFichaNotificacionDetalleID) AS NumSocias " & _
                         " FROM SclFichaNotificacionDetalle " & _
                         " WHERE  (nSclFichaNotificacionID = " & Me.intFichaID & ") AND (nCreditoRechazado = 0)"
            End If



            If ModoForm = "ADD" Then
                If CInt(XcDatos.ExecuteScalar(strSQL)) < intNoMinimoSocias And CInt(XcDatos.ExecuteScalar(strSQL)) > 0 Then
                    MsgBox("El Grupo seleccionado DEBE contener al menos" & Chr(13) & intNoMinimoSocias & " Fichas de Inscripción asociadas.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboGrupo, "El Grupo seleccionado DEBE contener al menos " & intNoMinimoSocias & " Fichas de Inscripción asociadas.")
                    Me.cboGrupo.Focus()
                    Exit Function
                End If
            Else 'Si es una Edición y el Crédito es diferente de Rechazado:
                strSQLA = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoCredito' "
                If (ObjFichadr.nStbEstadoCreditoID <> XcDatos.ExecuteScalar(strSQLA)) Then
                    If CInt(XcDatos.ExecuteScalar(strSQL)) < intNoMinimoSocias And CInt(XcDatos.ExecuteScalar(strSQL)) > 0 Then
                        MsgBox("El Grupo seleccionado DEBE contener al menos" & Chr(13) & intNoMinimoSocias & " Fichas de Inscripción asociadas.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errFicha.SetError(Me.cboGrupo, "El Grupo seleccionado DEBE contener al menos " & intNoMinimoSocias & " Fichas de Inscripción asociadas.")
                        Me.cboGrupo.Focus()
                        Exit Function
                    End If
                End If
            End If

            'No. de Sesión:
            If Me.mtbNumeroSesion.Text = "" Then
                MsgBox("Debe indicar un No. de Sesión del Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.mtbNumeroSesion, "Debe indicar un No. de Sesión del Crédito.")
                Me.mtbNumeroSesion.Focus()
                Exit Function
            End If
            If Me.txtDepto.Text = "" Then
                MsgBox("Departamento inválido para el No. de Sesión del Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.mtbNumeroSesion, "Departamento inválido para el No. de Sesión del Crédito.")
                Exit Function
            End If

            'Longitud válida para el Número de Sesión:
            If Len(Me.mtbNumeroSesion.Text) <> 8 Then
                MsgBox("Debe indicar un No. de Sesión del Crédito válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.mtbNumeroSesion, "Debe indicar un No. de Sesión del Crédito Válido.")
                Me.mtbNumeroSesion.Focus()
                Exit Function
            End If

            'Año Valido en los ultimos cuatro digitos del numero de sesión:
            If CInt(Microsoft.VisualBasic.Right(Me.mtbNumeroSesion.Text, 4)) < 2007 Then
                MsgBox("Año inválido en el Número de Sesión.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.mtbNumeroSesion, "Debe indicar un No. de Sesión del Crédito Válido.")
                Me.mtbNumeroSesion.Focus()
                Exit Function
            End If

            'Año del Numero de Sesion debe corresponder con el año de la Fecha de Resolucion:
            If CInt(Microsoft.VisualBasic.Right(Me.mtbNumeroSesion.Text, 4)) <> Year(Me.cdeFechaNotificacion.Value) Then
                MsgBox("Año inválido en el Número de Sesión.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.mtbNumeroSesion, "Año inválido en el Número de Sesión.")
                Me.mtbNumeroSesion.Focus()
                Exit Function
            End If

            'Si es una Adición imposible asignar una Sesion con al menos una socia enviada a CARUNA:
            If Me.ModoForm = "ADD" Then
                strSQL = "SELECT SclFichaNotificacionCredito.nCodigo " & _
                         "FROM SclFichaNotificacionDetalle INNER JOIN StbValorCatalogo ON SclFichaNotificacionDetalle.nStbEstadoEnvioID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID  " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (SclFichaNotificacionCredito.sNumSesion = '" & Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) & "')"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Imposible asignar este número de sesión." & Chr(13) & "Existen socias ya enviadas a CARUNA para esta.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.mtbNumeroSesion, "Número de Sesión inválido.")
                    Me.mtbNumeroSesion.Focus()
                    Exit Function
                End If
            End If

            'Imposible si existen otras Fichas ACTIVAS con el numero de sesion en otro Municipio:
            If Mid(Me.mtbNumeroSesion.Text, 1, 3) <> "000" Then
                strSQL = "SELECT vwStbUbicacionGeografica.nStbMunicipioID " & _
                         "FROM SclFichaNotificacionCredito INNER JOIN SclGrupoSolidario ON SclFichaNotificacionCredito.nSclGrupoSolidarioID = SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica ON SclGrupoSolidario.nStbBarrioVerificadoID = vwStbUbicacionGeografica.nStbBarrioID INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclFichaNotificacionCredito.nSclFichaNotificacionID <> " & Me.intFichaID & ") AND (SclFichaNotificacionCredito.sNumSesion = '" & Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) & "') AND (vwStbUbicacionGeografica.nStbMunicipioID <> " & Me.cboMunicipio.Columns("nStbMunicipioID").Value & ") " & _
                         "AND (StbValorCatalogo.sCodigoInterno <> '4' AND StbValorCatalogo.sCodigoInterno <> '5')"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Este número de sesión esta asignado en otro Municipio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.mtbNumeroSesion, "Número de Sesión inválido.")
                    Me.mtbNumeroSesion.Focus()
                    Exit Function
                End If
            End If

            'Si ya se registro ese número de sesión: 
            'strSQL = "SELECT sNumSesion FROM SclFichaNotificacionCredito WHERE  (nSclFichaNotificacionID <> " & Me.intFichaID & ") AND (sNumSesion = '" & Trim(RTrim(Me.txtNoSesion.Text)) & "')"
            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("El número de Sesión del Crédito ya fue registrado" & Chr(13) & "en otra Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.txtNoSesion, "El número de Sesión del Crédito ya fue registrado en otra Ficha de Notificación.")
            '    Me.txtNoSesion.Focus()
            '    Exit Function
            'End If

            ''Si ya se registro ese número de sesión con otra fecha de notificación:
            'strSQL = "SELECT sNumSesion FROM SclFichaNotificacionCredito WHERE (nSclFichaNotificacionID <> " & Me.intFichaID & ") AND (dFechaNotificacion <> CONVERT(DATETIME, '" & Format(Me.cdeFechaNotificacion.Value, "yyyy-MM-dd HH:mm") & "', 102)) AND (sNumSesion = '" & Trim(RTrim(Me.txtNoSesion.Text)) & "')"
            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("El número de Sesión del Crédito ya fue registrado" & Chr(13) & "con otra fecha de resolución.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cdeFechaNotificacion, "El número de Sesión del Crédito ya fue registrado con otra fecha de resolución.")
            '    Me.cdeFechaNotificacion.Focus()
            '    Exit Function
            'End If

            'Primer Firma Comité de Crédito:
            If Me.cboFirma1.SelectedIndex = -1 Then
                MsgBox("Debe indicar la primer firma del Comité de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboFirma1, "Debe indicar la primer firma del Comité de Crédito.")
                Me.cboFirma1.Focus()
                Exit Function
            End If

            'Segunda Firma Comité de Crédito:
            If Me.cboFirma2.SelectedIndex = -1 Then
                MsgBox("Debe indicar la segunda firma del Comité de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboFirma2, "Debe indicar la segunda firma del Comité de Crédito.")
                Me.cboFirma2.Focus()
                Exit Function
            End If

            'Tercer Firma Comité de Crédito: 
            If Me.cboFirma3.SelectedIndex = -1 Then
                MsgBox("Debe indicar la tercer firma del Comité de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboFirma3, "Debe indicar la tercer firma del Comité de Crédito.")
                Me.cboFirma3.Focus()
                Exit Function
            End If

            'Plazo del Periodo de Gracia (puede ser cero):
            If Not IsNumeric(cnePlazoPeriodoGracia.Value) Then
                MsgBox("Período de Gracia Inválido." & Chr(13) & "Debe indicar el valor o cero en caso de no aplicarse.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cnePlazoPeriodoGracia, "Plazo de Período de Gracia Inválido.")
                Me.cnePlazoPeriodoGracia.Focus()
                Exit Function
            End If

            'Si se indico periodo de Gracia debe haber un Tipo de Plazo:
            If CDbl(Me.cnePlazoPeriodoGracia.Value) > 0 Then
                'Debe haber un plazo:
                If Me.cboTipoPlazo.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Tipo de Plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoPlazo, "Debe seleccionar un Tipo de Plazo válido.")
                    Me.cboTipoPlazo.Focus()
                    Exit Function
                End If
                'plazo de periodo de gracia solo puede ser mensual:
                If Me.cboTipoPlazo.Columns("sCodigoInterno").Value <> "M" Then
                    MsgBox("Tipo de Plazo para Período de Gracia inválido.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoPlazo, "Tipo de Plazo para Período de Gracia inválido.")
                    Me.cboTipoPlazo.Focus()
                    Exit Function
                End If
            End If

            'Si se indico periodo de Gracia no mayor a 2 meses:
            If CDbl(Me.cnePlazoPeriodoGracia.Value) > 2 Then
                MsgBox("Período de Gracia no debe exceder los 2 meses.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cnePlazoPeriodoGracia, "Período de Gracia Inválido.")
                Me.cnePlazoPeriodoGracia.Focus()
                Exit Function
            End If

            'Si el Credito es Usura Cero no hay Periodo de Gracia:
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
            If RegistrosAsociados(strSQL) Then 'Si es Grupo Solidario Usura Cero:
                If CDbl(cnePlazoPeriodoGracia.Value) > 0 Then
                    MsgBox("El Grupo Solidario no admite período de gracia.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cnePlazoPeriodoGracia, "Período de Gracia inválido.")
                    Me.cnePlazoPeriodoGracia.Focus()
                    Exit Function
                End If
            End If

            'Anexado Febrero 28 2013 Validar Cajas Desconectadas
            'Si modifico el lugar de pago entonces si esta en uno de los envios a base local
            'No permitirlo



            If cboLugarPagos.SelectedIndex > -1 Then








                strSQL = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 84)"
                xObligarConCajaLocal = XcDatos.ExecuteScalar(strSQL) 'Si es 1 entonces valida que la caja local este recepcionada y aplicada, sin generar el siguiente archivo de envio.


                'strSQL = " SELECT     NoEnvio, nSteCajaId, EstadoEnvio, SsgCuentaID, FechaGenera, AplicadoEnCentral  FROM         dbo.SttProcesarEnvioES WHERE     (nSteCajaId = " & IdSteCaja & ") AND (NoEnvio > 0) AND (AplicadoEnCentral = 0) "
                If xObligarConCajaLocal = 1 Then

                    strSQL = " SELECT     dbo.SteCaja.nSteCajaID, dbo.SteCaja.sDescripcionCaja, dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID, dbo.SteCaja.nStbPersonaLugarPagosID FROM         dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SttCentralFichaNotificacionCreditoEnviadas ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SttCentralFichaNotificacionCreditoEnviadas.nSclFichaNotificacionID INNER JOIN dbo.SteCaja ON dbo.SttCentralFichaNotificacionCreditoEnviadas.nSteCajaIDLocal = dbo.SteCaja.nCodigo " & _
                    " WHERE(dbo.SteCaja.nCerrada = 0) And  (dbo.SttCentralFichaNotificacionCreditoEnviadas.nActiva = 1) And (dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = " & Me.intFichaID & ")"


                    XdtDatos.ExecuteSql(strSQL)
                    If XdtDatos.Count > 0 Then
                        If XdtDatos.ValueField("nStbPersonaLugarPagosID") <> XdsFicha("LugarPagos").ValueField("nStbPersonaID") Then
                            MsgBox("No puede Modificar el Lugar de Pagos. Por que Esa Ficha se encuentra en una base local enviada ." & Chr(13) & " Recuerde Actualizar el Lugar de Pago una vez aceptada la carga y antes de generar el siguiente envio.  ", MsgBoxStyle.Information)
                            ValidaDatosEntrada = False
                            Me.errFicha.SetError(Me.cboLugarPagos, "No puede Modificar el Lugar de Pagos. Por que Esa Ficha se encuentra en una base local enviada .")
                            Me.cboLugarPagos.Focus()

                            Exit Function
                        End If

                    End If
                End If
            End If

            'Plazo de periodicidad de pagos:
            If Me.cboTipoPlazoPagos.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo para Pagos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                Me.cboTipoPlazoPagos.Focus()
                Exit Function
            End If

            'Si es Grupo Solidario de Mercados con Pago Diario:
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (SclTipodePlandeNegocio.nCodigo = 5 OR SclTipodePlandeNegocio.nCodigo = 6 )"
            If RegistrosAsociados(strSQL) Then
                If Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Value <> "Q" Then
                    MsgBox("Tipo de Plazo para Pagos inválido.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                    Me.cboTipoPlazoPagos.Focus()
                    Exit Function
                End If
            Else 'Usura Cero / Ventana de Genero /PDIBA
                strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
                If RegistrosAsociados(strSQL) Then 'Si es Grupo Solidario Usura Cero: Semanal
                    If Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Value <> "S" Then
                        MsgBox("Tipo de Plazo para Pagos inválido.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errFicha.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                        Me.cboTipoPlazoPagos.Focus()
                        Exit Function
                    End If
                Else 'PDIBA Mensual para ventana de genero
                    strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2')"
                    If RegistrosAsociados(strSQL) Then 'Si es Ventana de Genero: Quincenal Mensual
                        If Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Value <> "M" And Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Value <> "Q" Then
                            MsgBox("Tipo de Plazo para Pagos inválido.", MsgBoxStyle.Critical, NombreSistema)
                            ValidaDatosEntrada = False
                            Me.errFicha.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                            Me.cboTipoPlazoPagos.Focus()
                            Exit Function
                        End If
                    Else
                        If Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Value <> "Q" Then
                            MsgBox("Tipo de Plazo para Pagos inválido.", MsgBoxStyle.Critical, NombreSistema)
                            ValidaDatosEntrada = False
                            Me.errFicha.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                            Me.cboTipoPlazoPagos.Focus()
                            Exit Function
                        End If
                    End If
                    
                End If
            End If


            REM 
            'Numero de sesion no debe de existir en otra ficha con otro plan de negocio:
            'If Mid(Me.mtbNumeroSesion.Text, 1, 3) <> "000" Then
            '    strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
            '             "FROM  SclFichaNotificacionCredito INNER JOIN SclGrupoSolidario ON SclFichaNotificacionCredito.nSclGrupoSolidarioID = SclGrupoSolidario.nSclGrupoSolidarioID " & _
            '             "WHERE (SclFichaNotificacionCredito.nSclFichaNotificacionID <> " & Me.intFichaID & ") AND (SclFichaNotificacionCredito.sNumSesion = '" & Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) & "') AND (SclGrupoSolidario.nSclTipodePlandeNegocioID <> " & Me.cboGrupo.Columns("nSclTipodePlandeNegocioID").Value & ")"
            '    If RegistrosAsociados(strSQL) Then
            '        MsgBox("Número de sesión existe para Grupo Solidario" & Chr(13) & "con otro Plan de Negocio.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errFicha.SetError(Me.mtbNumeroSesion, "Número de sesión inválido.")
            '        Me.mtbNumeroSesion.Focus()
            '        Exit Function
            '    End If
            'End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       SalvarFicha
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Ficha en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarFicha()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            Dim intDiaPagosID As Integer
            Dim intLugarEntregaCKID As Integer
            Dim intLugarPagosID As Integer
            Dim intLugarPagosOrigen As Integer
            Dim intCambioFechaCK As Integer
            Dim intPlazoPeriodoGracia As Integer

            Dim StrFechaFirma As String
            Dim StrFechaNotificacion As String

            Dim strFechaCK As String
            Dim strFechaPrimerCuota As String
            Dim strFechaUltimaCuota As String

            StrFechaFirma = Format(Me.cdeFechaActaC.Value, "yyyy-MM-dd")
            StrFechaNotificacion = Format(Me.cdeFechaNotificacion.Value, "yyyy-MM-dd HH:mm")

            'Si no se indicó Fecha/Hora Entrega CK:
            If Me.cdeFechaEntregaCK.ValueIsDbNull Then
                strFechaCK = "Null"
            Else
                'Fecha/Hora de entrega del Cheque:
                strFechaCK = Format(Me.cdeFechaEntregaCK.Value, "yyyy-MM-dd HH:mm")
            End If

            'Si ya estan generadas las Tablas de Amortización entonces estan registradas
            'las fechas de primer y última cuota:
            If Me.cdeFechaPrimerCuota.ValueIsDbNull Then
                strFechaPrimerCuota = "Null"
                strFechaUltimaCuota = "Null"
            Else
                strFechaPrimerCuota = Format(Me.cdeFechaPrimerCuota.Value, "yyyy-MM-dd")
                strFechaUltimaCuota = Format(Me.cdeFechaUltimaCuota.Value, "yyyy-MM-dd")
            End If

            'Día Pagos:
            If Me.cboDiaPagos.SelectedIndex <> -1 Then
                intDiaPagosID = XdsFicha("DiaPagos").ValueField("nStbValorCatalogoID")
            Else
                intDiaPagosID = -1
            End If

            'Lugar Entrega CK:
            If Me.cboLugarEntregaCK.SelectedIndex <> -1 Then
                intLugarEntregaCKID = XdsFicha("LugarEntregaCheque").ValueField("nStbPersonaID")
            Else
                intLugarEntregaCKID = -1
            End If

            'Plazo del Periodo de Gracia:
            If CDbl(Me.cnePlazoPeriodoGracia.Value) = 0 Then
                intPlazoPeriodoGracia = -1
            Else
                If Me.cboTipoPlazo.SelectedIndex <> -1 Then
                    intPlazoPeriodoGracia = XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID")
                Else
                    intPlazoPeriodoGracia = -1
                End If
            End If

            'Lugar Pagos:
            If Me.cboLugarPagos.SelectedIndex <> -1 Then
                intLugarPagosID = XdsFicha("LugarPagos").ValueField("nStbPersonaID")
            Else
                intLugarPagosID = -1
            End If
            If (ModoForm = "UPD") And (intLugarPagosID <> -1) Then
                strSQL = "SELECT ISNULL(nStbPersonaLugarPagosID, 0) AS nStbPersonaLugarPagosID FROM SclFichaNotificacionCredito WHERE  (nSclFichaNotificacionID = " & Me.intFichaID & ")"
                intLugarPagosOrigen = XcDatos.ExecuteScalar(strSQL)
            End If

            If Me.ModoForm = "ADD" Then
                intCambioFechaCK = 0
            Else
                If (Me.cdeFechaEntregaCK.ValueIsDbNull) Or (Not IsDate(ObjFichadr.dFechaHoraEntregaCK)) Then
                    intCambioFechaCK = 0
                Else
                    If (DateDiff("d", Format(Me.cdeFechaEntregaCK.Value, "dd/MM/yyyy"), Format(ObjFichadr.dFechaHoraEntregaCK, "dd/MM/yyyy")) = 0) Then
                        intCambioFechaCK = 0 'No Hubo cambio en la Fecha de Entrega del CK.
                    Else
                        intCambioFechaCK = 1
                    End If
                End If
            End If

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS UPDATE DE AUDITORIA 

            Dim XdtConsulta As BOSistema.Win.XDataSet.xDataTable
            Dim XdtDDE As BOSistema.Win.XDataSet.xDataTable
            Dim StrQuery As String
            XdtConsulta = New BOSistema.Win.XDataSet.xDataTable
            XdtDDE = New BOSistema.Win.XDataSet.xDataTable

            Dim IdnSclFichaNotificacionDetalle As Integer
            Dim IdnSccSolicitudDesembolsoCredito As Integer
            Dim IdnSccSolicitudCheque As Integer
            Dim IdnScnTransaccionContableID As Integer

            If ModoForm <> "ADD" Then

                ' Esto es para SclFichaNotificacionDetalle
                StrQuery = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & intFichaID
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdnSclFichaNotificacionDetalle = XdtConsulta.ValueField("nSclFichaNotificacionDetalleID")
                    GuardarAuditoriaTablas(5, 2, "Modificar SclFichaNotificacionDetalle", IdnSclFichaNotificacionDetalle, InfoSistema.IDCuenta)
                End If

                ' UPDATE SclFichaSocia
                Dim IdnSclFichaSocia As Integer
                StrQuery = "SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & intFichaID
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdnSclFichaSocia = XdtConsulta.ValueField("nSclFichaSociaID")
                    GuardarAuditoriaTablas(7, 2, "Modificar SclFichaSocia", IdnSclFichaSocia, InfoSistema.IDCuenta)
                End If

                ' UPDATE SccSolicitudDesembolsoCredito
                ' halar el último registro de SclFichaNotificacionDetalle y mandar a actualizar a SccSolicitudDesembolsoCredito
                StrQuery = "SELECT nSccSolicitudDesembolsoCreditoID FROM SccSolicitudDesembolsoCredito WHERE nSclFichaNotificacionDetalleID = " & IdnSclFichaNotificacionDetalle
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdnSccSolicitudDesembolsoCredito = XdtConsulta.ValueField("nSccSolicitudDesembolsoCreditoID")
                    GuardarAuditoriaTablas(3, 2, "Modificar SccSolicitudDesembolsoCredito", IdnSccSolicitudDesembolsoCredito, InfoSistema.IDCuenta)
                End If

                ' UPDATE SclGrupoSolidario
                Dim IdnSclGrupoSolidario As Integer
                StrQuery = "SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito WHERE nSclFichaNotificacionID = " & intFichaID
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdnSclGrupoSolidario = XdtConsulta.ValueField("nSclGrupoSolidarioID")
                    GuardarAuditoriaTablas(9, 2, "Modificar SclGrupoSolidario", IdnSclGrupoSolidario, InfoSistema.IDCuenta)
                End If

                ' UPDATE SccSolicitudCheque
                ' halar el último registro de SccSolicitudDesembolsoCredito para el SclFichaNotificacionDetalle y mandar a actualizar a SccSolicitudCheque
                StrQuery = "SELECT nSccSolicitudChequeID FROM SccSolicitudCheque WHERE nSccSolicitudDesembolsoCreditoID = " & IdnSccSolicitudDesembolsoCredito
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdnSccSolicitudCheque = XdtConsulta.ValueField("nSccSolicitudChequeID")
                    GuardarAuditoriaTablas(1, 2, "Modificar SccSolicitudCheque", IdnSccSolicitudCheque, InfoSistema.IDCuenta)
                End If

                ' UPDATE ScnTransaccionContable
                ' halar el último registro de SccSolicitudCheque para la SccSolicitudDesembolsoCredito del SclFichaNotificacionDetalle y mandar a actualizar a ScnTransaccionContable
                StrQuery = "SELECT nScnTransaccionContableID FROM ScnTransaccionContable WHERE nSccSolicitudChequeID = " & IdnSccSolicitudCheque
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdnScnTransaccionContableID = XdtConsulta.ValueField("nScnTransaccionContableID")
                    GuardarAuditoriaTablas(24, 2, "Modificar ScnTransaccionContable ", IdnScnTransaccionContableID, InfoSistema.IDCuenta)
                End If

                ' UPDATE SclFichaNotificacionCredito
                GuardarAuditoriaTablas(4, 2, "Modificar FNC", intFichaID, InfoSistema.IDCuenta)

            End If

            ' ------------------------------------------------------------------------------------------

            If strFechaCK = "Null" Then
                strSQL = " EXEC spSclGrabarFNC " & Me.intFichaID & "," & Me.cboGrupo.Columns("nSclGrupoSolidarioID").Value & ",'" _
                        & Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) & "','" & StrFechaFirma & "','" & StrFechaNotificacion & "','" _
                        & Trim(RTrim(Me.txtObservaciones.Text)) & "'," & Me.cboFirma1.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma2.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma3.Columns("nSrhEmpleadoID").Value & ",Null " _
                        & "," & intLugarEntregaCKID & ",Null,Null," _
                        & intDiaPagosID & ",'" & Trim(RTrim(Me.txtHorarioPagos.Text)) & "'," & intLugarPagosID & ",'" & Me.ModoForm & "','" & InfoSistema.LoginName & "', " & IntTipoCambioID & "," & InfoSistema.IDCuenta & ", " & InfoSistema.IDDelegacion & "," & intCambioFechaCK & ", " & intPlazoPeriodoGracia & "," & Me.cnePlazoPeriodoGracia.Value & "," & XdsFicha("TipoPlazoPagos").ValueField("nStbValorCatalogoID")
            ElseIf strFechaPrimerCuota = "Null" Then
                strSQL = " EXEC spSclGrabarFNC " & Me.intFichaID & "," & Me.cboGrupo.Columns("nSclGrupoSolidarioID").Value & ",'" _
                        & Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) & "','" & StrFechaFirma & "','" & StrFechaNotificacion & "','" _
                        & Trim(RTrim(Me.txtObservaciones.Text)) & "'," & Me.cboFirma1.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma2.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma3.Columns("nSrhEmpleadoID").Value & ",'" _
                        & strFechaCK & "'," & intLugarEntregaCKID & ",Null,Null," _
                        & intDiaPagosID & ",'" & Trim(RTrim(Me.txtHorarioPagos.Text)) & "'," & intLugarPagosID & ",'" & Me.ModoForm & "','" & InfoSistema.LoginName & "', " & IntTipoCambioID & "," & InfoSistema.IDCuenta & ", " & InfoSistema.IDDelegacion & "," & intCambioFechaCK & ", " & intPlazoPeriodoGracia & "," & Me.cnePlazoPeriodoGracia.Value & "," & XdsFicha("TipoPlazoPagos").ValueField("nStbValorCatalogoID")
            Else
                strSQL = " EXEC spSclGrabarFNC " & Me.intFichaID & "," & Me.cboGrupo.Columns("nSclGrupoSolidarioID").Value & ",'" _
                        & Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) & "','" & StrFechaFirma & "','" & StrFechaNotificacion & "','" _
                        & Trim(RTrim(Me.txtObservaciones.Text)) & "'," & Me.cboFirma1.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma2.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma3.Columns("nSrhEmpleadoID").Value & ",'" _
                        & strFechaCK & "'," & intLugarEntregaCKID & ",'" & strFechaPrimerCuota & "','" & strFechaUltimaCuota & "'," _
                        & intDiaPagosID & ",'" & Trim(RTrim(Me.txtHorarioPagos.Text)) & "'," & intLugarPagosID & ",'" & Me.ModoForm & "','" & InfoSistema.LoginName & "', " & IntTipoCambioID & "," & InfoSistema.IDCuenta & ", " & InfoSistema.IDDelegacion & "," & intCambioFechaCK & ", " & intPlazoPeriodoGracia & "," & Me.cnePlazoPeriodoGracia.Value & "," & XdsFicha("TipoPlazoPagos").ValueField("nStbValorCatalogoID")
            End If

            Me.intFichaID = XcDatos.ExecuteScalar(strSQL)

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS INSERT DE AUDITORIA 

            If ModoForm = "ADD" Then
                ' Esto es para SclFichaNotificacionCredito
                GuardarAuditoriaTablas(4, 1, "Agregar FNC", intFichaID, InfoSistema.IDCuenta)

                ' Esto es para SclDetalleDocExpediente 
                Dim sqlQuery As String
                Dim IntRegistros As Integer

                sqlQuery = "SELECT DDE.nSclDetalleDocExpedienteID " & _
                         "FROM   dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " & _
                         "       dbo.SclDetalleDocExpediente AS DDE ON FNC.nSclFichaNotificacionID = DDE.nSclFichaNotificacionID " & _
                         "WHERE  FNC.nSclFichaNotificacionID = " & intFichaID
                XdtDDE.ExecuteSql(sqlQuery)
                IntRegistros = XdtDDE.Count

                While IntRegistros > 0
                    GuardarAuditoriaTablas(23, 1, "Agregar SclDetalleDocExpediente", XdtDDE.ValueField("nSclDetalleDocExpedienteID"), InfoSistema.IDCuenta)
                    XdtDDE.Source.MoveNext()
                    IntRegistros = IntRegistros - 1
                End While

                ' Esto es para SclFichaNotificacionDetalle
                StrQuery = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID=" & intFichaID
                XdtConsulta.ExecuteSql(StrQuery)

                If XdtConsulta.Count > 0 Then
                    IdnSclFichaNotificacionDetalle = XdtConsulta.ValueField("nSclFichaNotificacionDetalleID")
                    GuardarAuditoriaTablas(5, 1, "Agregar SclFichaNotificacionDetalle", IdnSclFichaNotificacionDetalle, InfoSistema.IDCuenta)
                End If
            End If

            ' ------------------------------------------------------------------------------------------

            '-- Buscar la ficha correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjFichadt.Filter = "nSclFichaNotificacionID = " & Me.intFichaID
            ObjFichadt.Retrieve()
            If ObjFichadt.Count = 0 Then
                Exit Sub
            End If
            ObjFichadr = ObjFichadt.Current

            'Si FNC se encuentra Aprobada generar Pista de Auditoría por cada cambio de 
            'Número de Sesión:
            If IntAprobada = 1 Then
                If Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) <> StrNoSesion Then
                    Call GuardarAuditoria(5, 15, "Modificación en Número de Sesión de: " & StrNoSesion & " a: " & Trim(RTrim(Me.txtDepto.Text)) & Trim(RTrim(Me.mtbNumeroSesion.Text)) & ". (Código FNC: " & txtCodigo.Text & ")")
                Else
                    Call GuardarAuditoria(5, 15, "Modificación de datos de Ficha de Notificación Aprobada (Código FNC: " & txtCodigo.Text & ")")
                End If
                'Si cambio el Lugar de pagos:
                If (intLugarPagosID <> -1) And (intLugarPagosOrigen <> 0) Then
                    If XdsFicha("LugarPagos").ValueField("nStbPersonaID") <> intLugarPagosOrigen Then
                        Call GuardarAuditoria(5, 15, "Modificación de Lugar de Pagos Ficha de Notificación (Código FNC: " & txtCodigo.Text & ") de: " & StrLugarPagos & " por: " & XdsFicha("LugarPagos").ValueField("sNombre") & ".")
                    End If
                End If
            End If

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.intFichaID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
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
    ' Fecha:                18/09/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Declaracion de Variables 
            Dim res As Object
            Dim strSQL As String

            strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoCredito' "

            If (vbModifico = True) And (ObjFichadr.nStbEstadoCreditoID = XcDatos.ExecuteScalar(strSQL)) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarFicha()
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
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    'Se indica que hubo modificación en la Observación:
    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cdeFechaNotificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaNotificacion.TextChanged
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
            txtDepto.Text = cboDepartamento.Columns("sCodigo").Value & "-"
        Else
            CargarMunicipio(1, 0)
            txtDepto.Text = ""
        End If
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0, 0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0, 0)
                If Me.cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                End If
                Me.cboDistrito.Enabled = False
            End If

            'Tres Firmas del Comité de Crédito para el Municipio seleccionado:
            '(Persona Empleado del Programa):
            CargarFirmas(0, 0, "FirmaUno")
            CargarFirmas(0, 0, "FirmaDos")
            CargarFirmas(0, 0, "FirmaTres")

        Else
            CargarDistrito(1, 0)
            CargarBarrio(1, 0)

            'Tres Firmas del Comité de Crédito para el Municipio seleccionado:
            '(Persona Empleado del Programa):
            CargarFirmas(1, 0, "FirmaUno")
            CargarFirmas(1, 0, "FirmaDos")
            CargarFirmas(1, 0, "FirmaTres")

        End If
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio:
    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex <> -1 Then
            CargarBarrio(0, 0)
        Else
            CargarBarrio(1, 0)
        End If
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio:
    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrio.TextChanged
        If Me.cboBarrio.SelectedIndex <> -1 Then
            CargarGrupo(0, 0)
        Else
            CargarGrupo(1, 0)
        End If
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio:
    Private Sub cboGrupo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupo.TextChanged
        vbModifico = True
        If Me.cboGrupo.SelectedIndex <> -1 Then
            Me.txtNombreGS.Text = XdsFicha("Grupo").ValueField("Descripcion")
            Me.txtMercado.Text = XdsFicha("Grupo").ValueField("Mercado")
            Me.txtNombrePlan.Text = XdsFicha("Grupo").ValueField("DesPlanNegocio")
            'Ubicar el Tipo de Plazo:
            CargarTipoPlazoPagos()
        Else
            Me.txtNombreGS.Text = ""
            Me.txtMercado.Text = ""
        End If
    End Sub

    'En caso que haya habido algún cambio
    Private Sub mtbNumeroSesion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumeroSesion.TextChanged
        vbModifico = True
    End Sub

    'Private Sub txtNumHijosVivos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If Numeros(e.KeyChar) = False Then
    '        e.Handled = True
    '        e.KeyChar = Microsoft.VisualBasic.ChrW(0)
    '    End If
    'End Sub

    Private Sub txtHorarioPagos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHorarioPagos.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    'En caso que haya habido algún cambio
    Private Sub txtHorarioPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHorarioPagos.TextChanged
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboLugarEntregaCK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLugarEntregaCK.TextChanged
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboLugarPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLugarPagos.TextChanged
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cdeFechaActaC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaActaC.TextChanged
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboDiaPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDiaPagos.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazoPagos.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cnePlazoPeriodoGracia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cnePlazoPeriodoGracia.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirma1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboFirma2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma2.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirma3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma3.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaEntregaCK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaEntregaCK.TextChanged
        vbModifico = True
    End Sub


    Private Sub cdeFechaPrimerCuota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaPrimerCuota.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaUltimaCuota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaUltimaCuota.TextChanged
        vbModifico = True
    End Sub

#Region "Combos"

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       CargarFirmas
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Empleados sugiriendo el empleado registrado en 
    '                       parámetros para primer, segunda y tercer firma:
    '                       intParametroID = 11 (Firma1); StrNombre = FirmaUno
    '                       intParametroID = 12 (Firma2); StrNombre = FirmaDos
    '                       intParametroID = 13 (Firma3); StrNombre = FirmaTres
    '-------------------------------------------------------------------------
    Private Sub CargarFirmas(ByVal intLimpiarID As Integer, ByVal intEmpleadoID As Integer, ByVal StrNombre As String)
        'Dim XdtValorDelegacion As New BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaDataTable
        Dim XdtValorDelegacion As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim Strsql As String

            If StrNombre = "FirmaUno" Then
                Me.cboFirma1.ClearFields()
            ElseIf StrNombre = "FirmaDos" Then
                Me.cboFirma2.ClearFields()
            Else
                Me.cboFirma3.ClearFields()
            End If


            If intLimpiarID = 0 Then
                If intEmpleadoID = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " & _
                             " Order by a.nCodPersona desc "
                Else
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where ((a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " & _
                             " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " & _
                             " Order by a.nCodPersona desc"
                End If
            Else 'Limpiar Firmas.
                Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                         " From vwStbEmpleado a " & _
                         " Where (a.nSrhEmpleadoID = 0) " & _
                         " Order by a.nCodPersona  desc"
            End If

            If XdsFicha.ExistTable(StrNombre) Then
                XdsFicha(StrNombre).ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, StrNombre)
                XdsFicha(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos
            If StrNombre = "FirmaUno" Then
                Me.cboFirma1.DataSource = XdsFicha(StrNombre).Source
                Me.cboFirma1.Rebind()
            ElseIf StrNombre = "FirmaDos" Then
                Me.cboFirma2.DataSource = XdsFicha(StrNombre).Source
                Me.cboFirma2.Rebind()
            Else
                Me.cboFirma3.DataSource = XdsFicha(StrNombre).Source
                Me.cboFirma3.Rebind()
            End If

            If intLimpiarID = 0 Then
                'Ubicarse en el registro de acuerdo con el Ingreso de la Delegación:
                Strsql = "SELECT  StbDelegacionPrograma.nSrhEmpleadoFirmaAComiteID, StbDelegacionPrograma.nSrhEmpleadoFirmaBComiteID, StbDelegacionPrograma.nSrhEmpleadoFirmaCComiteID " & _
                         "FROM StbMunicipio INNER JOIN StbDelegacionPrograma ON StbMunicipio.nStbMunicipioID = StbDelegacionPrograma.nStbMunicipioID " & _
                         "WHERE (StbMunicipio.nStbDepartamentoID = " & XdsFicha("Departamento").ValueField("nStbDepartamentoID") & ")"
                XdtValorDelegacion.ExecuteSql(Strsql)
                'XdtValorDelegacion.Filter = "nStbMunicipioID = " & XdsFicha("Municipio").ValueField("nStbMunicipioID")
                'XdtValorDelegacion.Retrieve()
                'Ubicarse en el registro recomendado de Delegaciones:

                If (XdsFicha(StrNombre).Count > 0) And (XdtValorDelegacion.Count > 0) Then
                    If StrNombre = "FirmaUno" Then
                        ' XdsFicha(StrNombre).BindingSource.IndexOf(XdtValorDelegacion.ValueField("nSrhEmpleadoFirmaAComiteID"))
                        ' XdsFicha(StrNombre).BindingSource.Item("nSrhEmpleadoID")
                        If XdsFicha(StrNombre).BindingSource.Item(0)("nSrhEmpleadoID") = XdtValorDelegacion.ValueField("nSrhEmpleadoFirmaAComiteID") Then
                            Me.cboFirma1.SelectedIndex = 0
                        Else
                            XdsFicha(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorDelegacion.ValueField("nSrhEmpleadoFirmaAComiteID"))
                        End If

                        'XdsFicha(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorDelegacion.ValueField("nSrhEmpleadoFirmaAComiteID"))



                        'Temporal
                        'XdsFicha(StrNombre).SetCurrentByID("nSrhEmpleadoID", 4)
                        'Me.cboFirma1.SelectedIndex = 0
                    ElseIf StrNombre = "FirmaDos" Then
                        XdsFicha(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorDelegacion.ValueField("nSrhEmpleadoFirmaBComiteID"))
                        'Me.cboFirma2.SelectedIndex = 0
                    Else
                        XdsFicha(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorDelegacion.ValueField("nSrhEmpleadoFirmaCComiteID"))
                    End If
                End If
            End If

            'Confugurar el combo:
            If StrNombre = "FirmaUno" Then
                Me.cboFirma1.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma1.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma1.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma1.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma1.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ElseIf StrNombre = "FirmaDos" Then
                Me.cboFirma2.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma2.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma2.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma2.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma2.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                Me.cboFirma3.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma3.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma3.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorDelegacion.Close()
            XdtValorDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/08/2009
    ' Procedure Name:       CargarTipoPlazo
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPlazo()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("TipoPlazo") Then
                XdsFicha("TipoPlazo").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoPlazo")
                XdsFicha("TipoPlazo").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPlazo.DataSource = XdsFicha("TipoPlazo").Source

            XdtValorParametro.Filter = "nStbParametroID = 5"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("TipoPlazo").Count > 0 Then
                XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboTipoPlazo.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sDescripcion").Width = 70

            Me.cboTipoPlazo.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazo.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/08/2009
    ' Procedure Name:       CargarTipoPlazoPagos
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección de periodicidad
    '                       de pagos de las socias.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPlazoPagos()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""
            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("TipoPlazoPagos") Then
                XdsFicha("TipoPlazoPagos").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoPlazoPagos")
                XdsFicha("TipoPlazoPagos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPlazoPagos.DataSource = XdsFicha("TipoPlazoPagos").Source

            'XdtValorParametro.Filter = "nStbParametroID = 5"
            'XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("TipoPlazoPagos").Count > 0 Then
                'Si es Grupo Usura Cero / PDIBA:
                Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (SclTipodePlandeNegocio.nCodigo = 5 or SclTipodePlandeNegocio.nCodigo = 6)"
                If RegistrosAsociados(Strsql) Then
                    XdsFicha("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", 47) 'Quincenal PDIBA
                Else 'Usura Cero / Ventana de Genero
                    Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                             "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                             "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                             "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
                    If RegistrosAsociados(Strsql) Then 'Si es Grupo Solidario Usura Cero: Semanal
                        XdsFicha("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", 46) 'Semanal
                    Else 'Mensual para ventana de genero
                        XdsFicha("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", 48) ' Mensual
                    End If
                End If
                'Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                '         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                '         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (SclTipodePlandeNegocio.nCodigo < 3)"
                'If RegistrosAsociados(Strsql) Then 'Si es Grupo Solidario Usura Cero:
                '    XdsFicha("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", 46) 'Semanal
                'Else
                '    XdsFicha("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", 48) ' Mensual
                'End If
            End If

            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sDescripcion").Width = 70

            Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazoPagos.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       CargarDiaPagos
    ' Descripción:          Este procedimiento permite cargar el listado de días
    '                       de la semana para efectuar pagos.
    '-------------------------------------------------------------------------
    Private Sub CargarDiaPagos()
        Try
            Dim Strsql As String = ""


            Strsql = " Select a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " &
                     " From StbValorCatalogo a INNER JOIN " &
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'DiasSemana') b " &
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " &
                     " WHERE (a.nActivo = 1) Order by a.sCodigoInterno "

            If cdeFechaEntregaCK.Text <> "" Then
                If IsDate(cdeFechaEntregaCK.Value) Then
                    Strsql = " Select a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " &
                    " From StbValorCatalogo a INNER JOIN " &
                    " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'DiasSemana') b " &
                    " ON a.nStbCatalogoID = b.nStbCatalogoID " &
                    " WHERE (a.nActivo = 1) and a.sDescripcion=dbo.[diaSemana](DATEPART(dw, convert(datetime,'" & Format(cdeFechaEntregaCK.Value, "yyyy-M-dd").ToString() & "',102)))" _
                    & " Order by a.sCodigoInterno "
                End If
            End If

            If XdsFicha.ExistTable("DiaPagos") Then
                        XdsFicha("DiaPagos").ExecuteSql(Strsql)
                    Else
                        XdsFicha.NewTable(Strsql, "DiaPagos")
                        XdsFicha("DiaPagos").Retrieve()
                    End If

                    'Asignando a las fuentes de datos
                    Me.cboDiaPagos.DataSource = XdsFicha("DiaPagos").Source

                    Me.cboDiaPagos.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
                    Me.cboDiaPagos.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    'Configurar el combo
                    Me.cboDiaPagos.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
                    Me.cboDiaPagos.Splits(0).DisplayColumns("sDescripcion").Width = 70

                    Me.cboDiaPagos.Columns("sCodigoInterno").Caption = "Código"
                    Me.cboDiaPagos.Columns("sDescripcion").Caption = "Descripción"

                    Me.cboDiaPagos.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Me.cboDiaPagos.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    Me.cboDiaPagos.SelectedIndex = 0

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarLugarEntregaCKPagos
    ' Descripción:          Este procedimiento permite cargar el listado de lugares
    '                       para entrega de cheques y para pagos de cuotas de un GS.
    '-------------------------------------------------------------------------
    Private Sub CargarLugarEntregaCKPagos(ByVal intPersonaID As Integer, ByVal StrNombreXds As String)
        Try
            Dim Strsql As String

            If StrNombreXds = "LugarEntregaCheque" Then
                Me.cboLugarEntregaCK.ClearFields()
            Else
                Me.cboLugarPagos.ClearFields()
            End If

            If intPersonaID = 0 Then
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre " & _
                         " From vwStbPersona a " & _
                         " Where (a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') and (nPersonaActiva = 1) " & _
                         " Order by a.nCodPersona"
            Else
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre " & _
                         " From vwStbPersona a " & _
                         " Where ((a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') and (nPersonaActiva = 1)) " & _
                         " Or (a.nStbPersonaID = " & intPersonaID & ") " & _
                         " Order by a.nCodPersona"
            End If

            If XdsFicha.ExistTable(StrNombreXds) Then
                XdsFicha(StrNombreXds).ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, StrNombreXds)
                XdsFicha(StrNombreXds).Retrieve()
            End If

            If StrNombreXds = "LugarEntregaCheque" Then
                'Asignando a las fuentes de datos
                Me.cboLugarEntregaCK.DataSource = XdsFicha(StrNombreXds).Source
                Me.cboLugarEntregaCK.Rebind()
                'Configurar el combo:
                Me.cboLugarEntregaCK.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
                Me.cboLugarEntregaCK.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboLugarEntregaCK.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboLugarEntregaCK.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboLugarEntregaCK.Columns("nCodPersona").Caption = "Código"
                Me.cboLugarEntregaCK.Columns("sNombre").Caption = "Institución"
                Me.cboLugarEntregaCK.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboLugarEntregaCK.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                'Asignando a las fuentes de datos
                Me.cboLugarPagos.DataSource = XdsFicha(StrNombreXds).Source
                Me.cboLugarPagos.Rebind()
                'Configurar el combo:
                Me.cboLugarPagos.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
                Me.cboLugarPagos.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboLugarPagos.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboLugarPagos.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboLugarPagos.Columns("nCodPersona").Caption = "Código"
                Me.cboLugarPagos.Columns("sNombre").Caption = "Institución"
                Me.cboLugarPagos.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboLugarPagos.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                     " From StbDepartamento a " & _
                     " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                     " Order by a.sCodigo"

            If XdsFicha.ExistTable("Departamento") Then
                XdsFicha("Departamento").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Departamento")
                XdsFicha("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsFicha("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("Departamento").Count > 0 Then
                XdsFicha("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 100

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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsFicha("Departamento").ValueField("nStbDepartamentoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where ((a.nActivo = 1) And (a.nPertenecePrograma = 1) And  (a.nStbDepartamentoID = " & XdsFicha("Departamento").ValueField("nStbDepartamentoID") & "))" & _
                             " Or (a.nStbMunicipioID = " & intMunicipioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsFicha.ExistTable("Municipio") Then
                XdsFicha("Municipio").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Municipio")
                XdsFicha("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsFicha("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("Municipio").Count > 0 Then
                XdsFicha("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("sNombre").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarBarrio(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
        Try
            Dim Strsql As String

            Me.cboBarrio.ClearFields()
            If intLimpiarID = 0 Then
                If intBarrioID = 0 Then
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsFicha("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsFicha("Distrito").ValueField("nStbDistritoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsFicha("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsFicha("Distrito").ValueField("nStbDistritoID") & ")) " & _
                             " Or (a.nStbBarrioID = " & intBarrioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbBarrio a " & _
                         " Where a.nStbBarrioID = 0"
            End If

            If XdsFicha.ExistTable("Barrio") Then
                XdsFicha("Barrio").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Barrio")
                XdsFicha("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsFicha("Barrio").Source
            Me.cboBarrio.Rebind()

            Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("sNombre").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where (a.nPertenecePrograma = 1) And  (a.nActivo = 1) " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1)) " & _
                             " OR (a.nStbDistritoID = " & intDistritoID & ") " & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsFicha.ExistTable("Distrito") Then
                XdsFicha("Distrito").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Distrito")
                XdsFicha("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsFicha("Distrito").Source
            Me.cboDistrito.Rebind()

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").Width = 150

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("sNombre").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarGrupo
    ' Descripción:          Este procedimiento permite cargar el listado de Grupos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarGrupo(ByVal intLimpiarID As Integer, ByVal intGrupoID As Integer)
        Try
            Dim Strsql As String

            Me.cboGrupo.ClearFields()
            If intLimpiarID = 0 Then
                'Grupos En Proceso o Cerrados (NO permitir Anulados)
                'GS NO deberá formar parte de otra FNC ingresada con Estado: En Proceso. 
                If intGrupoID = 0 Then
                    Strsql = " Select b.sNombre AS Mercado, a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion, a.nSclTipodePlandeNegocioID , dbo.SclTipodePlandeNegocio.sDescripcion As DesPlanNegocio " & _
                             " FROM SclGrupoSolidario AS a INNER JOIN StbMercado AS b ON a.nStbMercadoVerificadoID = b.nStbMercadoID " & _
                             " INNER JOIN dbo.SclTipodePlandeNegocio ON a.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                             " WHERE (a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1','3')) And (b.sNombre = 'EstadoGrupo'))) " & _
                             " And (a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & ")" & _
                             " And (a.nSclGrupoSolidarioID NOT IN (Select nSclGrupoSolidarioID From SclFichaNotificacionCredito Where (nSclFichaNotificacionId <> " & Me.intFichaID & ") " & _
                             " And (nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1')) And (b.sNombre = 'EstadoCredito'))))) " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select b.sNombre AS Mercado, a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion, a.nSclTipodePlandeNegocioID , dbo.SclTipodePlandeNegocio.sDescripcion As DesPlanNegocio " & _
                             " FROM SclGrupoSolidario AS a INNER JOIN StbMercado AS b ON a.nStbMercadoVerificadoID = b.nStbMercadoID " & _
                             " INNER JOIN dbo.SclTipodePlandeNegocio ON a.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                             " WHERE (a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1','3')) And (b.sNombre = 'EstadoGrupo'))) " & _
                             " And (a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & ")" & _
                             " And (a.nSclGrupoSolidarioID NOT IN (Select nSclGrupoSolidarioID From SclFichaNotificacionCredito Where (nSclFichaNotificacionId <> " & Me.intFichaID & ") " & _
                             " And (nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1')) And (b.sNombre = 'EstadoCredito'))))) " & _
                             " Or (a.nSclGrupoSolidarioID = " & intGrupoID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion, a.nSclTipodePlandeNegocioID " & _
                         " From SclGrupoSolidario a " & _
                         " WHERE a.nSclGrupoSolidarioID = 0"
            End If

            If XdsFicha.ExistTable("Grupo") Then
                XdsFicha("Grupo").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Grupo")
                XdsFicha("Grupo").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboGrupo.DataSource = XdsFicha("Grupo").Source
            Me.cboGrupo.Rebind()

            Me.cboGrupo.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nStbBarrioVerificadoID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("Mercado").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nSclTipodePlandeNegocioID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("DesPlanNegocio").Visible = False

            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").Width = 90
            Me.cboGrupo.Splits(0).DisplayColumns("Descripcion").Width = 150

            Me.cboGrupo.Columns("sCodigo").Caption = "Código"
            Me.cboGrupo.Columns("Descripcion").Caption = "Descripción"

            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupo.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region
#Region "Detalle Expediente"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarExpediente
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       de Expediente del GS en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarExpediente()
        Try
            Dim Strsql As String

            REM Limpiar Grid.
            Me.grdExpediente.ClearFields()
            Strsql = " Select a.nSclDetalleDocExpedienteID, a.nSclFichaNotificacionID, a.sCodigoInterno, " & _
                     " a.sDescripcion, a.nCumpleRequisito, a.sObservacion " & _
                     " From vwSclDetallesExpedienteFNC a " & _
                     " Where (a.nSclFichaNotificacionID = " & Me.intFichaID & ") " & _
                     " Order by cast( a.sCodigoInterno as int)"

            If XdsDetalle.ExistTable("Expediente") Then
                XdsDetalle("Expediente").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Expediente")
                XdsDetalle("Expediente").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdExpediente.DataSource = XdsDetalle("Expediente").Source
            REM Refresh Grid.
            Me.grdExpediente.Rebind(False)
            Me.grdExpediente.FetchRowStyles = True

            'Actualizando el caption de los GRIDS
            Me.grdExpediente.Caption = " Detalles de Expediente de Crédito (" + Me.grdExpediente.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       FormatoExpediente
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Expedientes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoExpediente()
        Try

            'Configuracion del Grid 
            Me.grdExpediente.Splits(0).DisplayColumns("nSclDetalleDocExpedienteID").Visible = False
            Me.grdExpediente.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False

            Me.grdExpediente.Splits(0).DisplayColumns("sCodigoInterno").Width = 50
            Me.grdExpediente.Splits(0).DisplayColumns("sDescripcion").Width = 300
            Me.grdExpediente.Splits(0).DisplayColumns("nCumpleRequisito").Width = 95
            Me.grdExpediente.Splits(0).DisplayColumns("sObservacion").Width = 400

            Me.grdExpediente.Columns("sCodigoInterno").Caption = "Item"
            Me.grdExpediente.Columns("sDescripcion").Caption = "Nombre del Requisito"
            Me.grdExpediente.Columns("nCumpleRequisito").Caption = "Cumple Requisito"
            Me.grdExpediente.Columns("nCumpleRequisito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdExpediente.Columns("sObservacion").Caption = "Observaciones"

            Me.grdExpediente.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdExpediente.Splits(0).DisplayColumns("nCumpleRequisito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdExpediente.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdExpediente.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdExpediente.Splits(0).DisplayColumns("nCumpleRequisito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdExpediente.Splits(0).DisplayColumns("sObservacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       tbExpediente_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbExpediente.
    '-------------------------------------------------------------------------
    Private Sub tbExpediente_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbExpediente.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarE"
                LlamaAgregarExpediente()
            Case "toolModificarE"
                LlamaModificarExpediente()
            Case "toolEliminarE"
                LlamaEliminarExpediente()
            Case "toolActivoInactivo"
                LlamaActivarInactivarExpediente()
            Case "toolRefrescarE"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdExpediente.ClearFields()
                CargarExpediente()
                FormatoExpediente()
            Case "toolAyudaE"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaAgregarExpediente
    ' Descripción:          Este procedimiento permite Incorporar Requisitos que
    '                       no estan contenidos dentro de SclDetalleDocExpediente.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarExpediente()
        Dim XdtExpediente As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            Dim StrSqlV As String
            'Imposible si NO existen requisitos en Catálogos Básicos aún
            'no contenidos dentro de SclDetalleDocExpediente para la FNC 
            'actual:
            StrSqlV = " SELECT StbValorCatalogo.nStbValorCatalogoID " & _
                     " FROM  StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID " & _
                     " WHERE (StbCatalogo.sNombre = 'ExpedienteCredito') AND (NOT (StbValorCatalogo.nStbValorCatalogoID IN " & _
                     " (SELECT nStbDocumentoID FROM  SclDetalleDocExpediente WHERE  (nSclFichaNotificacionID = " & Me.intFichaID & "))))"
            If RegistrosAsociados(StrSqlV) = False Then
                MsgBox("No existen requisitos por incorporar del Catálogo General.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de incorporar requisitos aún" & Chr(13) & "no asignados en el expediente?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                StrSql = " INSERT INTO SclDetalleDocExpediente (nSclFichaNotificacionID, nStbDocumentoID, nCumpleRequisito, sUsuarioCreacion, dFechaCreacion)" & _
                         " SELECT " & Me.intFichaID & ", a.nStbValorCatalogoID, 1, '" & InfoSistema.LoginName & "',getdate()" & _
                         " FROM (" & StrSqlV & ") a "
                XdtExpediente.ExecuteSqlNotTable(StrSql)
                CargarExpediente()
                FormatoExpediente()
                MsgBox("Los requisitos se incorporaron satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdExpediente.Caption = " Detalles de Expediente de Crédito (" + Me.grdExpediente.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtExpediente.Close()
            XdtExpediente = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaModificarExpediente
    ' Descripción:          Este procedimiento permite incluir la Observación
    '                       para un determinado requisito de expediente que
    '                       fue incorporado de forma automática.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarExpediente()

        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtDE As New BOSistema.Win.SclEntFicha.SclDetalleDocExpedienteDataTable
        Dim XdrDE As New BOSistema.Win.SclEntFicha.SclDetalleDocExpedienteRow

        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Try

            Dim intPosicion As Integer
            Dim strObservacion As String = ""

            'Imposible si no existen requisitos grabados:
            If Me.grdExpediente.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            XdtDE.Filter = " nSclDetalleDocExpedienteID = " & XdsDetalle("Expediente").ValueField("nSclDetalleDocExpedienteID")
            XdtDE.Retrieve()
            XdrDE = XdtDE.Current

            If Not XdrDE.IsFieldNull("sObservacion") Then
                ObjFrmStbDatoComplemento.txtDato.Text = XdrDE.sObservacion
            End If
            ObjFrmStbDatoComplemento.strPrompt = "Observaciones Requisito:  "
            ObjFrmStbDatoComplemento.strTitulo = "Observaciones Requisito "
            ObjFrmStbDatoComplemento.intAncho = XdrDE.GetColumnLenght("sObservacion")
            ObjFrmStbDatoComplemento.strDato = ""
            ObjFrmStbDatoComplemento.strColor = "Verde"
            ObjFrmStbDatoComplemento.strMensaje = "No se indicó ninguna Observación."
            ObjFrmStbDatoComplemento.ShowDialog()

            strObservacion = ObjFrmStbDatoComplemento.strDato

            If strObservacion = "" Then
                If MsgBox("¿Desea eliminar la Observación actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                    'Ingresa la Observación en NULL:
                    Strsql = " Update SclDetalleDocExpediente " & _
                             " SET  nCumpleRequisito=  Case when nCumpleRequisito=0 then 1 else 0 End , sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), sObservacion = NULL" & _
                             " WHERE nSclDetalleDocExpedienteID = " & XdsDetalle("Expediente").ValueField("nSclDetalleDocExpedienteID")
                Else
                    Exit Sub
                End If
            Else
                'Ingresa la Observación:
                Strsql = " Update SclDetalleDocExpediente " & _
                         " SET nCumpleRequisito=  Case when nCumpleRequisito=0 then 1 else 0 End , sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), sObservacion = '" & strObservacion & "'" & _
                         " WHERE nSclDetalleDocExpedienteID = " & XdsDetalle("Expediente").ValueField("nSclDetalleDocExpedienteID")
            End If
            XcDatos.ExecuteNonQuery(Strsql)

            MsgBox("Observación del requisito actualizada Exitosamente.", MsgBoxStyle.Information, NombreSistema)
            'Guardar posición actual de la selección
            intPosicion = XdsDetalle("Expediente").ValueField("nSclDetalleDocExpedienteID")
            CargarExpediente()
            FormatoExpediente()
            'Ubicar la selección en la posición original
            XdsDetalle("Expediente").SetCurrentByID("nSclDetalleDocExpedienteID", intPosicion)
            Me.grdExpediente.Row = XdsDetalle("Expediente").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing

            XdtDE.Close()
            XdtDE = Nothing

            XdrDE.Close()
            XdrDE = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaActivarInactivarExpediente
    ' Descripción:          Este procedimiento permite activar o inactivar
    '                       indicador de cumplimiento de requisitos en un
    '                       determinado detalles de expediente.
    '-------------------------------------------------------------------------
    Private Sub LlamaActivarInactivarExpediente()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim StrSql As String = ""
        Try
            Dim intPosicion As Integer
            Dim intRequisito As Integer
            'No existen registros:
            If Me.grdExpediente.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Confirmar Cambio:
            If MsgBox("¿Está seguro de cambiar el estado del requisito?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            If XdsDetalle("Expediente").ValueField("nCumpleRequisito") = 1 Then
                intRequisito = 0
            Else
                intRequisito = 1
            End If
            'Actualiza indicador del requisito:
            StrSql = "UPDATE SclDetalleDocExpediente " & _
                     "SET nCumpleRequisito = " & intRequisito & ", dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                     "WHERE (nSclDetalleDocExpedienteID = " & XdsDetalle("Expediente").ValueField("nSclDetalleDocExpedienteID") & ")"
            XcDatos.ExecuteScalar(StrSql)

            MsgBox("Cambio realizado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
            'Guardar posición actual de la selección
            intPosicion = XdsDetalle("Expediente").ValueField("nSclDetalleDocExpedienteID")
            CargarExpediente()
            FormatoExpediente()
            'Ubicar la selección en la posición original
            XdsDetalle("Expediente").SetCurrentByID("nSclDetalleDocExpedienteID", intPosicion)
            Me.grdExpediente.Row = XdsDetalle("Expediente").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaEliminarExpediente
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un detalle de expediente existente en la FNC.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarExpediente()
        Dim XdtExpediente As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdExpediente.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el requisito seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XdtExpediente.ExecuteSqlNotTable("Delete From SclDetalleDocExpediente where nSclDetalleDocExpedienteID=" & XdsDetalle("Expediente").ValueField("nSclDetalleDocExpedienteID"))
                CargarExpediente()
                FormatoExpediente()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdExpediente.Caption = " Detalles de Expediente de Crédito (" + Me.grdExpediente.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtExpediente.Close()
            XdtExpediente = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            MsgBox("En construcción", MsgBoxStyle.Information, NombreSistema)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       grdExpediente_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un detalle de expediente existente, al hacer 
    '                       doble click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdExpediente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdExpediente.DoubleClick
        Try
            If blnModificar = True Then
                If Seg.HasPermission("DatosExpediente") Then
                    LlamaModificarExpediente()
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que se filtren registros en la FilterBar.
    Private Sub grdExpediente_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdExpediente.Filter
        Try
            XdsDetalle("Expediente").FilterLocal(e.Condition)
            Me.grdExpediente.Caption = " Detalles de Expediente de Crédito (" + Me.grdExpediente.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region

#Region "Detalle Resolución Crédito"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CargarResolucionCredito
    ' Descripción:          Este procedimiento permite cargar los datos de las 
    '                       Resoluciones Crediticias en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarResolucionCredito()
        Try
            Dim Strsql As String
            Me.grdResolucion.ClearFields()

            Strsql = " Select a.nSclFichaNotificacionDetalleID, a.nSclFichaNotificacionID, a.nSclFichaSociaID, " & _
                     " a.nSclGrupoSociaID, a.CodigoSocia, a.NombreSocia, a.nCoordinador, a.sNumeroCedula, a.nMontoSolicitado, a.nPlazoSolicitado, " & _
                     " a.nMontoCreditoAprobado, a.nPlazoAprobado, a.sTipoPlazo, a.nCreditoRechazado, a.CodEnvio, a.EstadoEnvio " & _
                     " From vwSclResolucionCreditoFNC a " & _
                     " Where (a.nSclFichaNotificacionID = " & Me.intFichaID & ") " & _
                     " Order By a.nCoordinador Desc, a.nSclFichaSociaID " 'a.CodigoSocia

            If XdsDetalle.ExistTable("Resolucion") Then
                XdsDetalle("Resolucion").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Resolucion")
                XdsDetalle("Resolucion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdResolucion.DataSource = XdsDetalle("Resolucion").Source
            'Refresh Grid.
            Me.grdResolucion.Rebind(False)
            Me.grdResolucion.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdResolucion.Caption = " Detalles de Resolución de Crédito (" + Me.grdResolucion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       FormatoResolucionCredito
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Resoluciones de Crédito en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoResolucionCredito()
        Try
            'Configuracion del Grid 
            Me.grdResolucion.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("nSclFichaSociaID").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("sTipoPlazo").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("nSclGrupoSociaID").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("CodEnvio").Visible = False

            'Pie del Grid para totalizar Monto Solicitado y Monto Aprobado:
            Me.grdResolucion.ColumnFooters = True
            Me.grdResolucion.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoSolicitado").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoSolicitado").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoSolicitado").FooterStyle.ForeColor = Color.Blue

            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCreditoAprobado").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCreditoAprobado").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCreditoAprobado").FooterStyle.ForeColor = Color.Blue

            Me.grdResolucion.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdResolucion.Splits(0).DisplayColumns("CodigoSocia").Width = 40
            Me.grdResolucion.Splits(0).DisplayColumns("NombreSocia").Width = 150
            Me.grdResolucion.Splits(0).DisplayColumns("nCoordinador").Width = 75
            Me.grdResolucion.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoSolicitado").Width = 70
            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoSolicitado").Width = 40
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCreditoAprobado").Width = 70
            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoAprobado").Width = 90
            Me.grdResolucion.Splits(0).DisplayColumns("nCreditoRechazado").Width = 60
            Me.grdResolucion.Splits(0).DisplayColumns("EstadoEnvio").Width = 120

            Me.grdResolucion.Columns("CodigoSocia").Caption = "Código"
            Me.grdResolucion.Columns("NombreSocia").Caption = "Nombre Socia"
            Me.grdResolucion.Columns("nCoordinador").Caption = "Coordinadora"
            Me.grdResolucion.Columns("nCoordinador").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdResolucion.Columns("sNumeroCedula").Caption = "Cédula Socia"
            Me.grdResolucion.Columns("nMontoSolicitado").Caption = "Solicitado C$"
            Me.grdResolucion.Columns("nPlazoSolicitado").Caption = "Plazo" '& Me.grdResolucion.Columns("sTipoPlazo").Value & ")"
            Me.grdResolucion.Columns("nMontoCreditoAprobado").Caption = "Aprobado C$"
            Me.grdResolucion.Columns("nPlazoAprobado").Caption = "Plazo (" & Me.grdResolucion.Columns("sTipoPlazo").Value & ")"
            Me.grdResolucion.Columns("nCreditoRechazado").Caption = "Denegado"
            Me.grdResolucion.Columns("nCreditoRechazado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdResolucion.Columns("EstadoEnvio").Caption = "Envio a CARUNA"

            Me.grdResolucion.Splits(0).DisplayColumns.Item("nMontoSolicitado").Style.BackColor = Color.WhiteSmoke
            Me.grdResolucion.Splits(0).DisplayColumns.Item("nMontoCreditoAprobado").Style.BackColor = Color.WhiteSmoke

            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoSolicitado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("CodigoSocia").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nCreditoRechazado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nCoordinador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoSolicitado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("CodigoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("NombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nCoordinador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoSolicitado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoSolicitado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCreditoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nCreditoRechazado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("EstadoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdResolucion.Columns("nMontoSolicitado").NumberFormat = "#,##0.00"
            Me.grdResolucion.Columns("nMontoCreditoAprobado").NumberFormat = "#,##0.00"

            'Calcular montos totales de crédito solicitado y aprobado para el GS:
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       CalcularMontos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Crédito Solicitado y Autorizado para 
    '                       visualizarlo en el Grid de Resolución de Crédito.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalMonto As Double = 0
            Dim vTotalAprobado As Double = 0

            For index As Integer = 0 To Me.grdResolucion.RowCount - 1
                Me.grdResolucion.Row = index
                vTotalMonto = vTotalMonto + Me.grdResolucion.Columns("nMontoSolicitado").Value
                vTotalAprobado = vTotalAprobado + Me.grdResolucion.Columns("nMontoCreditoAprobado").Value
            Next
            If Me.grdResolucion.RowCount > 0 Then
                Me.grdResolucion.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdResolucion.Columns("nMontoSolicitado").FooterText = Format(vTotalMonto, "C$ #,##0.00")
            Me.grdResolucion.Columns("nMontoCreditoAprobado").FooterText = Format(vTotalAprobado, "C$ #,##0.00")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       tbResolucion_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbResolucion.
    '-------------------------------------------------------------------------
    Private Sub tbResolucion_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbResolucion.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolAgregarRC"
                LlamaAgregarRC()
            Case "toolModificarRC"
                LlamaModificarRC()
            Case "toolEliminarRC"
                LlamaEliminarRC()
            Case "toolDenegarC"
                LlamaDenegarCredito()
            Case "toolRefrescarRC"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdResolucion.ClearFields()
                CargarResolucionCredito()
                FormatoResolucionCredito()
            Case "toolAyudaRC"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaAgregarRC
    ' Descripción:          Este procedimiento ingresar Fichas Verificadas
    '                       del GS seleccionado que no estan contenidas en
    '                       SclFichaNotificaciónDetalle.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRC()
        Dim XdtResolucion As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatosC As New BOSistema.Win.XComando
        Dim Strsql As String
        Try
            Dim IntEstadoID As Integer
            'Encuentra Estado de Envio a CARUNA En Proceso:
            Strsql = "SELECT StbValorCatalogo.nStbValorCatalogoID " & _
                     "FROM StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID " & _
                     "WHERE (StbCatalogo.sNombre = 'EstadoEnvioCARUNA') AND (StbValorCatalogo.sCodigoInterno = '1')"
            IntEstadoID = XcDatosC.ExecuteScalar(Strsql)

            'Fichas Verificadas NO contenidas en SclFichaNotificacionDetalle:
            Strsql = " SELECT c.nSclFichaSociaID, c.nMontoCreditoVerificado, c.nStbTipoPlazoVerificadoID, nPlazoVerificado " & _
                     " FROM   SclGrupoSolidario AS a INNER JOIN SclGrupoSocia AS b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID " & _
                     " INNER JOIN SclFichaSocia AS c ON b.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN StbValorCatalogo AS d ON c.nStbEstadoFichaID = d.nStbValorCatalogoID " & _
                     " WHERE (d.sCodigoInterno = '3') AND (a.nSclGrupoSolidarioID = " & ObjFichadr.nSclGrupoSolidarioID & ") " & _
                     " AND (NOT (c.nSclFichaSociaID IN (SELECT nSclFichaSociaID FROM  SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & Me.intFichaID & "))))"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("NO Existen Fichas de Inscripción VERIFICADAS no incorporadas" & Chr(13) & "dentro de los datos de la Resolución del Crédito.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de incorporar Fichas de Inscripción VERIFICADAS" & Chr(13) & "aún no ingresadas en la Resolución de Crédito?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                Strsql = " INSERT INTO SclFichaNotificacionDetalle (nSclFichaNotificacionID, nCodigoPrestamo, nNoPrestamoSocia, nStbEstadoEnvioID, nSclFichaSociaID, nMontoCreditoAprobado, nStbTipoPlazoAprobadoID, nPlazoAprobado, sUsuarioCreacion, dFechaCreacion)" & _
                         " SELECT " & Me.intFichaID & ", 0, 0, " & IntEstadoID & ", a.nSclFichaSociaID, a.nMontoCreditoVerificado, a.nStbTipoPlazoVerificadoID, a.nPlazoVerificado, '" & InfoSistema.LoginName & "',getdate()" & _
                         " FROM (" & Strsql & ") a "


                Strsql = "Exec SpAUDITSclFichaNotificacionDetalleAgregarFaltantes 'Insert','Agregar Fichas Detalle desde FNC'," & Me.intFichaID & "," & IntEstadoID & "," & ObjFichadr.nSclGrupoSolidarioID & "," & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "',1"

                XdtResolucion.ExecuteSqlNotTable(Strsql)
                CargarResolucionCredito()
                FormatoResolucionCredito()
                MsgBox("Las fichas se incorporaron satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdResolucion.Caption = " Detalles de Resolución de Crédito (" + Me.grdResolucion.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtResolucion.Close()
            XdtResolucion = Nothing

            XcDatosC.Close()
            XcDatosC = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaModificarRC
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditDetallesFNC para Modificar un detalle de FNC.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRC()
        Try
            Dim strSQL As String
            'Imposible si no existen registros:
            If Me.grdResolucion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Si la FNC fue Anulada con Regeneracion,
            'Y la Sra. esta Activa y Enviada a CARUNA en la Ficha Origen:
            'No modificar monto ni plazo:
            If IsNumeric(ObjFichadr.nSclFNCOrigenID) Then
                strSQL = "SELECT SclFichaNotificacionDetalle.nSclFichaSociaID " & _
                         "FROM SclFichaNotificacionDetalle INNER JOIN StbValorCatalogo ON SclFichaNotificacionDetalle.nStbEstadoEnvioID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (SclFichaNotificacionDetalle.nSclFichaSociaID = " & XdsDetalle("Resolucion").ValueField("nSclFichaSociaID") & ") AND (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & ObjFichadr.nSclFNCOrigenID & ") AND (StbValorCatalogo.sCodigoInterno = '3')"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("La Socia ya ha sido había sido enviada a CARUNA" & Chr(13) & "imposible modificar datos del crédito.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Prepara Ambiente para actualización:
            grpMontoAprobado.Visible = True
            tbResolucion.Enabled = False
            Me.tabPDatosGrales.Enabled = False
            Me.tabPExpediente.Enabled = False

            cneMontoAprobado.Value = XdsDetalle("Resolucion").ValueField("nMontoCreditoAprobado")
            cnePlazoAprobado.Value = CInt(XdsDetalle("Resolucion").ValueField("nPlazoAprobado"))
            Me.errFicha.Clear()
            MsgBox("Favor indicar monto y plazo aprobado.", MsgBoxStyle.Information)
            cneMontoAprobado.Focus()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/09/2007
    ' Procedure Name:       LlamaDenegarCredito
    ' Descripción:          Este procedimiento permite denegar el crédito de
    '                       forma parcial a una determinada socia del GS.
    '-------------------------------------------------------------------------
    Private Sub LlamaDenegarCredito()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplementoRechazo
        Dim XdtTmp As New BOSistema.Win.SclEntFicha.SclFichaNotificacionDetalleDataTable
        Dim XdrTmp As New BOSistema.Win.SclEntFicha.SclFichaNotificacionDetalleRow

        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing
        Try
            Dim strSQL As String
            Dim intPosicion As Integer
            Dim strCausaRechazo As String = ""
            Dim IntEnviar As Integer
            Dim intDatoMotivo As Integer

            'Imposible si no existen registros:
            If Me.grdResolucion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '************************************
            'Comentariado a partir de 23/02/2015

            'Imposible denegar Crédito a la Coordinadora del GS:
            'strSQL = "SELECT nSclGrupoSolidarioID FROM SclGrupoSocia WHERE (nCoordinador = 1) AND (nSclGrupoSociaID = " & XdsDetalle("Resolucion").ValueField("nSclGrupoSociaID") & ")"
            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("Imposible Denegar Crédito a Coordinadora del Grupo Solidario.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Imposible si el Crédito ya se encuentra Denegado:
            If XdsDetalle("Resolucion").ValueField("nCreditoRechazado") = 1 Then
                MsgBox("El Crédito de la Socia seleccionada se encuentra Denegado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '***********************************
            'Comentariado a partir de 23/02/2015

            'Imposible denegar si sólo existen 5 socias o menos (Valor almacenado en Parámetros):
            'que tengan el crédito Aprobado:
            '-- Si es Credito del Programa Usura Cero.
            'strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
            '         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
            '         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
            'If RegistrosAsociados(strSQL) Then 'Grupo Solidario usura cero
            '    strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 16)"
            'Else 'Grupo Solidario Ventana de Genero
            '    strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 58)"
            'End If
            'intNoMinimoSocias = XcDatos.ExecuteScalar(strSQL)
            ''Cantidad de Socias con el Crédito Aprobado:
            'strSQL = "SELECT COUNT(nSclFichaNotificacionDetalleID) AS NumSocias FROM SclFichaNotificacionDetalle WHERE  (nSclFichaNotificacionID = " & Me.intFichaID & ") AND (nCreditoRechazado = 0)"
            'If XcDatos.ExecuteScalar(strSQL) <= intNoMinimoSocias Then
            '    MsgBox("El número de socias con el Crédito Aprobado es el mínimo permitido.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Imposible Denegar Crédito si el Grupo Solidario se encuentra Cerrado:
            strSQL = "SELECT  SclGrupoSolidario.nSclGrupoSolidarioID FROM  SclGrupoSolidario INNER JOIN StbValorCatalogo ON SclGrupoSolidario.nStbEstadoGrupoID = StbValorCatalogo.nStbValorCatalogoID WHERE  (StbValorCatalogo.sCodigoInterno = '3') AND (dbo.SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Imposible Denegar Crédito. El Grupo Solidario se encuentra Cerrado." & Chr(13) & "Debería conformarse otro Grupo Solidario.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM Imposible Denegar Crédito si es la Segunda Vuelta del Crédito:
            strSQL = "SELECT  nSclFichaSociaID  FROM  SclFichaSocia WHERE  (nConsecutivoCredito > 1) AND (nSclFichaSociaID = " & XdsDetalle("Resolucion").ValueField("nSclFichaSociaID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Imposible Denegar Crédito. La socia tiene Créditos Otorgados con este Grupo." & Chr(13) & "Debería conformarse otro Grupo Solidario.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM Imposible Denegar Crédito si el Grupo Solidario tiene una o más FNCs Aprobadas:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     "FROM SclFichaNotificacionCredito INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclFichaNotificacionCredito.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2')"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Imposible Denegar Crédito. La socia tiene crédito(s) otorgado(s)" & Chr(13) & "con este grupo solidario.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Cambio:
            If MsgBox("¿Está seguro de DENEGAR el crédito a la socia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                'Cambiar cursor:
                Me.Cursor = Cursors.WaitCursor
                'Guardar posición actual de la selección
                intPosicion = XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")
                'Solicita al Usuario la Causa de la Anulación
                XdtTmp.Filter = " nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")
                XdtTmp.Retrieve()
                XdrTmp = XdtTmp.Current

                ObjFrmStbDatoComplemento.strPrompt = "¿Motivo de Rechazo del Crédito? "
                ObjFrmStbDatoComplemento.strTitulo = "Rechazo de Crédito"
                ObjFrmStbDatoComplemento.intAncho = XdrTmp.GetColumnLenght("sMotivoRechazo")
                ObjFrmStbDatoComplemento.strDato = ""
                ObjFrmStbDatoComplemento.strColor = "Verde"
                ObjFrmStbDatoComplemento.strMensaje = "El motivo del Rechazo del Crédito NO DEBE quedar vacío"
                ObjFrmStbDatoComplemento.ShowDialog()

                strCausaRechazo = ObjFrmStbDatoComplemento.strDato
                intDatoMotivo = ObjFrmStbDatoComplemento.intDatoMotivo



                'Valida que se ingrese la Causa de la Anulación
                'If strCausaRechazo = "" Then
                '    MsgBox("El motivo NO PUEDE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                '    Exit Sub
                'End If
                'Valida que se ingrese la Causa de la Anulación
                If intDatoMotivo = 0 Then
                    MsgBox("El motivo NO PUEDE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If




                'Determinar Si es una Ficha previamente Anulada, 
                'y la Señora esta Activa y Enviada a CARUNA en la Ficha Origen:
                strSQL = "SELECT SclFichaNotificacionDetalle.nSclFichaSociaID " & _
                         "FROM SclFichaNotificacionDetalle INNER JOIN StbValorCatalogo ON SclFichaNotificacionDetalle.nStbEstadoEnvioID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (SclFichaNotificacionDetalle.nSclFichaSociaID = " & XdsDetalle("Resolucion").ValueField("nSclFichaSociaID") & ") AND (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & ObjFichadr.nSclFNCOrigenID & ") AND (StbValorCatalogo.sCodigoInterno = '3')"
                If RegistrosAsociados(strSQL) Then
                    IntEnviar = 1
                Else
                    IntEnviar = 0
                End If

                ''Instanciar Trans:
                'Trans = New BOSistema.Win.Transact
                ''Inicio la Transaccion:
                'Trans.BeginTrans()
                ''1. Denegar crédito en SclFichaNotificacionDetalle y Actualiza Monto/Plazo a Cero:
                'strSQL = " Update SclFichaNotificacionDetalle " & _
                '         " SET sMotivoRechazo = '" & strCausaRechazo & "', sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), nCreditoRechazado = 1, nMontoCreditoAprobado = 0, nPlazoAprobado = 0" & _
                '         " WHERE nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")
                'Trans.ExecuteSql(strSQL)
                ''2. Denegar crédito en SclGrupoSocia:
                'strSQL = " Update SclGrupoSocia " & _
                '         " SET sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), nCreditoRechazado = 1" & _
                '         " WHERE nSclGrupoSociaID = " & XdsDetalle("Resolucion").ValueField("nSclGrupoSociaID")
                'Trans.ExecuteSql(strSQL)
                ''3. Si es una Ficha previamente Anulada, 
                ''y la Señora esta Activa y Enviada a CARUNA en la Ficha Origen:
                ''Marcar el estado actual de la Socia con Enviar a CARUNA:
                'If IsNumeric(ObjFichadr.nSclFNCOrigenID) Then
                '    If IntEnviar = 1 Then
                '        strSQL = " Update SclFichaNotificacionDetalle " & _
                '                 " SET sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), " & _
                '                 " nStbEstadoEnvioID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoEnvioCARUNA') " & _
                '                 " WHERE nSclFichaNotificacionDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID")
                '        Trans.ExecuteSql(strSQL)
                '    End If
                'End If

                ''Ejecutar Transacción:
                'Trans.Commit()



                strSQL = "Exec SpAUDITSclFichaNotificacionDetalleDenegarCredito  'Update','Denegar Ficha de Credito Detalle'," & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID") & "," & XdsDetalle("Resolucion").ValueField("nSclGrupoSociaID") & ",'" & strCausaRechazo & "'," & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "'," & IntEnviar & ",1," & intDatoMotivo
                XcDatos.ExecuteNonQuery(strSQL)






                'Ubicar la selección en la posición original:
                CargarResolucionCredito()
                FormatoResolucionCredito()
                XdsDetalle("Resolucion").SetCurrentByID("nSclFichaNotificacionDetalleID", intPosicion)
                Me.grdResolucion.Row = XdsDetalle("Resolucion").BindingSource.Position
                MsgBox("Crédito DENEGADO Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 15, "Crédito Denegado Grupo Socia ID:" & XdsDetalle("Resolucion").ValueField("nSclGrupoSociaID") & ".")

            End If
        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            Trans = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       LlamaEliminarRC
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una Resolución Crediticia existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRC()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            If Me.grdResolucion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible eliminar si sólo existen 5 socias o menos (Valor almacenado en Parámetros):
            'Que tengan Crédito Aprobado:
            strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 16)"
            intNoMinimoSocias = XcDatos.ExecuteScalar(strSQL)
            'Cantidad de Socias con el Crédito Aprobado:
            strSQL = "SELECT COUNT(nSclFichaNotificacionDetalleID) AS NumSocias FROM SclFichaNotificacionDetalle WHERE  (nSclFichaNotificacionID = " & Me.intFichaID & ") AND (nCreditoRechazado = 0)"
            If CInt(XcDatos.ExecuteScalar(strSQL)) <= intNoMinimoSocias Then
                MsgBox("Imposible eliminar: Unicamente existe(n) " & CInt(XcDatos.ExecuteScalar(strSQL)) & " socia(s) con el" & Chr(13) & "Crédito Aprobado en la Resolución de Crédito.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible Si la FNC fue Anulada con Regeneracion,
            'Y la Sra. esta Activa y Enviada a CARUNA en la Ficha Origen:
            If IsNumeric(ObjFichadr.nSclFNCOrigenID) Then
                strSQL = "SELECT SclFichaNotificacionDetalle.nSclFichaSociaID " & _
                         "FROM SclFichaNotificacionDetalle INNER JOIN StbValorCatalogo ON SclFichaNotificacionDetalle.nStbEstadoEnvioID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (SclFichaNotificacionDetalle.nSclFichaSociaID = " & XdsDetalle("Resolucion").ValueField("nSclFichaSociaID") & ") AND (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & ObjFichadr.nSclFNCOrigenID & ") AND (StbValorCatalogo.sCodigoInterno = '3')"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("La Socia ya ha sido había sido enviada a CARUNA" & Chr(13) & "imposible modificar datos del crédito.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
                'XcDatos.ExecuteNonQuery("Delete From SclFichaNotificacionDetalle where nSclFichaNotificacionDetalleID=" & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID"))
                strSQL = "Exec SpAUDITSclFichaNotificacionDetalleElimina 'Delete','Eliminar Ficha Detalle'," & XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID") & "," & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "',1"
                XcDatos.ExecuteNonQuery(strSQL)
                CargarResolucionCredito()
                FormatoResolucionCredito()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdResolucion.Caption = " Detalles de Resolución de Crédito (" + Me.grdResolucion.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/09/2007
    ' Procedure Name:       grdResolucion_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Resolución existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdResolucion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdResolucion.DoubleClick
        Try
            If blnModificar = True Then
                If Seg.HasPermission("DatosResolucion") Then
                    LlamaModificarRC()
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdResolucion_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdResolucion.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdExpediente_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdExpediente.Error
        Control_Error(e.Exception)
    End Sub

    'Sirve para realizar el filtro de la condición introducida en la Barra de Filtro
    Private Sub grdReferencia_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdResolucion.Filter
        Try
            XdsDetalle("Resolución").FilterLocal(e.Condition)
            Me.grdResolucion.Caption = " Detalles de Resolución de Crédito (" + Me.grdResolucion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cdeFechaEntregaCK_ModifiedChanged(sender As Object, e As EventArgs) Handles cdeFechaEntregaCK.ModifiedChanged
        Try
            CargarDiaPagos()
        Catch ex As Exception

        End Try
    End Sub
#End Region


End Class