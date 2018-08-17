' ------------------------------------------------------------------------
' Autor:                
' Fecha:                31/10/2014
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditFichaVerificacion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de una Ficha de Verificación.
'-------------------------------------------------------------------------

Public Class frmSclEditFichaVerificacionNueva

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intFichaID As Integer
    Dim blnModificar As Boolean = True

    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet
    Dim XdsNFam As BOSistema.Win.XDataSet

    Dim XdtEstadoCivil As BOSistema.Win.XDataSet.xDataTable
    Dim XdtPromotor As BOSistema.Win.XDataSet.xDataTable
    Dim XdtRubro As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset
    Dim ObjFichadt As BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
    Dim ObjFichadr As BOSistema.Win.SclEntFicha.SclFichaSociaRow
    Dim ObjFichaNegociodt As BOSistema.Win.SclEntFicha.SclFichaSociaNegocioDataTable
    Dim ObjFichaNegociodr As BOSistema.Win.SclEntFicha.SclFichaSociaNegocioRow

    '-- Variables FichaNegocio (A partir del 30/10/2014)
    Dim EstadoCivilID As Integer
    Dim TipoActividadID As Integer 'RadioBotones III
    Dim OtraActividad As String 'TextBox III
    Dim TieneNegocioNuevo As Integer 'Radio Botones IV-1
    Dim DescripcionNegocio As String 'TextBox IV-1
    Dim RubroNegocio As String 'ComboBox IV-13
    Dim CaracteristicaNegocio As Integer 'Radio IV-2
    Dim FuncionamientoNegocio As Integer 'Radio IV-3
    Dim RegistrosVentas As Integer 'Radio IV-4
    Dim VentaBrutaMes As Single 'Radio IV-51
    Dim VentaBrutaSemana As Single 'Radio IV-52
    Dim VentaBrutaOtro As Single 'Radio IV-53
    Dim TieneFinanciamientoOtraInstitucion As Integer 'Radio V-1
    Dim FinanciamientoOtraInstitucionMonto As Single 'TextBox Value V-1
    Dim RecibeMercaderiaConsignacion As Integer 'Radio V-2
    Dim RecibeMercaderiaConsignacionMonto As Single 'TextBox Value V-2
    Dim CreditosOtrasEmpresas As Integer 'Radios V-3
    Dim CreditosOtrasEmpresasMonto As Single 'textBox Value V-3
    Dim LeHaAgregadoAlNegocio As Integer 'rdVI01-02
    Dim QueleAgregadoAlNegocio As String 'Siempre Vacio
    Dim OtrosProductosServicios As Integer 'Radio VI-11
    Dim LoCambio As Integer ''Radio VI-12
    Dim DescripcionOtrosProductosServicios As String 'TextBox VI-11
    Dim DescripcionCambio As String 'TextBox VI-12
    Dim CausasDelCambio As Integer 'Radios VI-2
    Dim DescripcionCausasDelCambioOtro As String 'TextBox VI-2
    Dim CuantasPersonasTrabajan As Integer ' 0=Solo ella, >0=IndicarCantidad  Radios+TextBox VI-3
    Dim DescripcionCambiosEquipo As String 'TextBox1 VI-4
    Dim DescripcionCambiosInfraestructura As String 'TextBox2 VI-4
    Dim DescripcionCambiosMuebles As String 'TextBox3 VI-4
    Dim MejoriaPercibidaAlimentacion As Integer   'Radios PM-1
    Dim MejoriaPercibidaEquiposElectronicos As Integer  'Radios PM-2
    Dim MejoriaPercibidaCasa As Integer  'Radios PM-3
    Dim MejoriaPercibidaMuebles As Integer  'Radios PM-4
    Dim MejoriaPercibidaEstudios As Integer  'Radios PM-5
    Dim MejoriaPercibidaConocimientoAutoEstima As Integer   'Radios PM-6
    Dim Observaciones As String  'TextBox PM-Observaciones
    Dim Meta As String 'TextBox PM-Meta
    Dim Promotor As Integer 'Combo al final de todo
    Dim Turismo As Integer 'Acapite III-IV


    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton = AccionBoton.BotonNinguno
    Dim vbModifico As Boolean
    'Dim cboTipoNegocioPropuesto As Object

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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclEditFichaVerificacion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFichaVerificacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                XdsFicha.Close()
                XdsFicha = Nothing
                ObjFichadt.Close()
                ObjFichadt = Nothing

                XdtEstadoCivil.Close()
                XdtEstadoCivil = Nothing

                XdtPromotor.Close()
                XdtPromotor = Nothing

                XdtRubro.Close()
                XdtRubro = Nothing

                'ObjFichadr.Close()
                ObjFichadr = Nothing

                XdsDetalle.Close()
                XdsDetalle = Nothing

                XdsNFam.Close()
                XdsNFam = Nothing
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditFichaVerificacion_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de la Ficha en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------

    Private Sub CargarEstadoCivil()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (b.sNombre = 'EstadoCivil') " & _
                         " ORDER BY a.sCodigoInterno"

            XdtEstadoCivil.ExecuteSql(Strsql)
            Me.cboEstadoCivil.DataSource = XdtEstadoCivil.Source

            Me.cboEstadoCivil.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboEstadoCivil.Columns("sCodigoInterno").Caption = "Código"
            Me.cboEstadoCivil.Columns("sDescripcion").Caption = "Descripción"

            Me.cboEstadoCivil.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboEstadoCivil.DisplayMember = "Descripción"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Public Sub CargarCreditoNo()
        Dim gruposocia As Integer = ObjFichadr.nSclGrupoSociaID
        Dim objsocia As New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable
        objsocia.Filter = "nSclGrupoSociaID = " & gruposocia
        objsocia.Retrieve()
        Dim idsocia As Integer = objsocia.ValueField("nSclSociaID")

        Dim cn As New BOSistema.Win.XComando
        Dim strSQL As String
        strSQL = "SELECT     COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID) AS TotalCancelados " & _
                               "   FROM         dbo.SclSocia INNER JOIN  dbo.SclGrupoSocia ON dbo.SclSocia.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID INNER JOIN " & _
                               " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN  " & _
                               " dbo.SclFichaNotificacionCredito INNER JOIN  dbo.SclFichaNotificacionDetalle ON  dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN " & _
                               " dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID AND  " & _
                               " dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " & _
                               " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID  " & _
                               " WHERE     (dbo.SclFichaNotificacionDetalle.nSclFichaSociaID<>" & Me.intFichaID & " and dbo.SclGrupoSocia.nSclSociaID = " & idsocia & "  ) AND (dbo.StbValorCatalogo.sCodigoInterno = '7') AND (StbValorCatalogo_1.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)"
        Dim cnI As Integer
        cnI = cn.ExecuteScalar(strSQL) + 1
        txtCreditoNo.Text = "" & cnI
    End Sub

    Private Sub frmSclEditFichaVerificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbNucleoFamiliar.BringToFront()
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarRepresentante(0)
            CargarDepartamento(0)
            CargarPrimaria()
            CargarSecundaria()
            CargarUniversidad()
            CargarCarreraTecnica(0)
            CargarTipoPlazo()
            CargarConoceSocias()
            CargarTipoNegocioActual(0)
            ''CargarTipoNegocioPropuesto(0)
            CargarTipoVenta()
            CargarEstadoCivil()
            CargarPromotor()

            'Si el formulario está en modo edición
            'cargar los datos de la ficha.
            If ModoFrm = "UPD" Then
                CargarFicha()
                ObtenerSiModifica()
                PresentacionControles()

                CargarOtroCredito()
                FormatoOtroCredito()
                CargarReferencia()
                FormatoReferencia()

                '-- A PARTIR DE NOVIEMBRE-2014
                CargarNucleoFamiliar()
                CargarCreditoNo()
                'CargarRubro()
                'If XdtRubro.Count > 0 Then
                'cboIV13.SelectedIndex = 0
                'End If

                'Cuando agregamos un nuevo campo actualizar estas dos funciones
                AsignarVariablesNuevasBase()
                CargarControlesNuevos()

                'Cuando viene Barrio No Aplica, es Turismo (Definido el 30 08 2016)
                Dim cmd As New BOSistema.Win.XComando
                Dim ret As Object
                ret = cmd.ExecuteScalar("Select Barrio from vwSclBarrioPorGrupoSolidarioFicha where nSclFichaSociaID=" & Me.intFichaID)
                If ret = "No Aplica" Then
                    turismoT.Checked = True
                    grdTurismo.Enabled = False
                End If
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            Me.cboDistrito.Enabled = False
            Me.cdeFechaVerificacion.Select()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub ObtenerSiModifica()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql, Strsql2 As String

            'Valida que el Estado actual sea "En Proceso"
            'de lo contrario se sale del procedimiento
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoFicha' "
            Strsql2 = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoFicha' "

            If ObjFichadr.nStbEstadoFichaID <> XcDatos.ExecuteScalar(Strsql) Then
                blnModificar = False
                If InfoSistema.IDDelegacion = 1 And ObjFichadr.nStbEstadoFichaID = XcDatos.ExecuteScalar(Strsql2) Then
                    blnModificar = True
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                03/11/2006
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas Datos Grales,Otros Créditos y Referencias Crediticias.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            Me.CmdAceptar.Enabled = False
            Me.tbReferencia.Enabled = False
            Me.tbOtrosCreditos.Enabled = False
            Me.tbNucleoFamiliar.Enabled = False
            Me.cboDepartamento.Enabled = False
            Me.cboMunicipio.Enabled = False
            Me.cboBarrio.Enabled = False
            Me.cboGrupo.Enabled = False
            Me.cboSocia.Enabled = False
            Me.cdeFechaVerificacion.Enabled = False
            Me.cneMontoSolicitado.Enabled = False
            Me.cboTipoNegocioActual.Enabled = False
            'Me.cboTipoNegocioPropuesto.Enabled = False
            Me.cboTipoPlazo.Enabled = False
            Me.cboTipoPromedioVentas.Enabled = False
            Me.cdeFechaApertura.Enabled = False
            Me.cdeFechaVerificacion.Enabled = False
            Me.txtOtrosEstudios.Enabled = False
            Me.txtIV12.Enabled = False
            Me.radSiTieneNegocio.Enabled = False
            Me.radNoTieneNegocio.Enabled = False
            Me.cdeFechaInscripcion.Enabled = False
            Me.cnePromedioVentas.Enabled = False
            Me.cboDistrito.Enabled = False
            Me.txtPlazo.Enabled = False
            Me.cboRepresentante.Enabled = False
            Me.txtDireccion.Enabled = False
            Me.txtTelefono.Enabled = False
            Me.cboPrimaria.Enabled = False
            Me.cboSecundaria.Enabled = False
            Me.cboCarreraTecnica.Enabled = False
            Me.chkAlfabetizada.Enabled = False
            Me.txtObservaciones.Enabled = False
            Me.cboConoceSocias.Enabled = False
            Me.cboEstadoCivil.Enabled = False
            Me.grdIII.Enabled = False
            Me.grdIV.Enabled = False
            Me.grdV.Enabled = False
            Me.grdVI.Enabled = False
            Me.grdVII.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim strFecha As String
            Dim dFechaInicioPrograma As Date

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Ficha de Verificación"
                Me.tabPReferencia.Enabled = False
                Me.tabPOtrosCreditos.Enabled = False
            Else
                Me.Text = "Modificar Ficha de Verificación"
                Me.tabPOtrosCreditos.Enabled = True
                Me.tabPReferencia.Enabled = False
            End If
            'tbReferencia.Enabled = False

            XdtEstadoCivil = New BOSistema.Win.XDataSet.xDataTable
            ObjFichadt = New BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
            ObjFichadr = New BOSistema.Win.SclEntFicha.SclFichaSociaRow
            XdsDetalle = New BOSistema.Win.XDataSet
            XdsFicha = New BOSistema.Win.XDataSet
            XdsNFam = New BOSistema.Win.XDataSet
            XdtPromotor = New BOSistema.Win.XDataSet.xDataTable
            XdtRubro = New BOSistema.Win.XDataSet.xDataTable
            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboTipoNegocioActual.ClearFields()
            ''Me.cboTipoNegocioPropuesto.ClearFields()
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboBarrio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboGrupo.ClearFields()
            Me.cboSocia.ClearFields()
            Me.grdReferencia.ClearFields()
            Me.grdOtroCredito.ClearFields()
            Me.cboTipoPlazo.ClearFields()
            Me.cboTipoPromedioVentas.ClearFields()

            Me.tabFicha.SelectedIndex = 0

            Me.cdeFechaVerificacion.Value = ModSMUSURA0.FechaServer
            Me.cneMontoSolicitado.Value = 0
            Me.txtPlazo.Text = 0
            Me.cnePromedioVentas.Value = 0

            Me.toolEliminarOC.Enabled = False
            Me.toolEliminarOC.Visible = False

            Me.cboDepartamento.Enabled = False
            Me.cboMunicipio.Enabled = False
            Me.cboMercado.Enabled = False
            Me.cboDistrito.Enabled = False
            Me.cboBarrio.Enabled = False
            Me.cboGrupo.Enabled = False
            Me.cboSocia.Enabled = False
            Me.cboBarrio.Enabled = False
            Me.cboTipoPlazo.Enabled = False

            Me.txtNumHijosDependientes.Enabled = False
            Me.txtNumHijosVivos.Enabled = False
            'Me.cdeFechaInscripcion.Enabled = False
            'Me.txtOtrosEstudios.Enabled = False
            'Me.cboPrimaria.Enabled = False
            'Me.cboSecundaria.Enabled = False
            'Me.cboCarreraTecnica.Enabled = False
            'Me.txtDireccion.Enabled = False
            'Me.txtTelefono.Enabled = False
            Me.txtNumCedula.Enabled = False
            Me.txtEdad.Enabled = False
            'Me.chkAlfabetizada.Enabled = False

            Me.radSiTieneNegocio.Checked = True
            Me.cboTipoNegocioActual.Enabled = True
            ''Me.cboTipoNegocioPropuesto.Enabled = False

            XdtValorParametro.Filter = "nStbParametroID = 4"
            XdtValorParametro.Retrieve()

            strFecha = Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 1, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 3, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 5, 4)

            dFechaInicioPrograma = CDate(strFecha)
            Me.cdeFechaVerificacion.Calendar.MinDate = CDate(strFecha)
            Me.cdeFechaVerificacion.Calendar.MaxDate = FechaServer()

            Me.cdeFechaInscripcion.Calendar.MinDate = CDate(strFecha)
            Me.cdeFechaInscripcion.Calendar.MaxDate = FechaServer()

            If ModoFrm = "ADD" Then

                ObjFichadr = ObjFichadt.NewRow

                'Inicializar los Length de los campos
                Me.txtOtrosEstudios.MaxLength = ObjFichadr.GetColumnLenght("sOtrosEstudios")
                Me.txtTelefono.MaxLength = ObjFichadr.GetColumnLenght("sTelefonoSocia")
                Me.txtIV12.MaxLength = ObjFichadr.GetColumnLenght("sDireccionNegocio")
                Me.txtDireccion.MaxLength = ObjFichadr.GetColumnLenght("sDireccionSocia")
                Me.txtObservaciones.MaxLength = ObjFichadr.GetColumnLenght("sObservacionesVerificacion")

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarFicha
    ' Descripción:          Este procedimiento permite cargar los datos de la Ficha
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------

    Public Function ExtraerEstadoCivil() As String
        Dim gruposocia As Integer = ObjFichadr.nSclGrupoSociaID
        Dim objsocia As New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable
        Dim socia As New BOSistema.Win.SclEntSocia.SclSociaDataTable
        'Dim objsociaR As New BOSistema.Win.SclEntSocia.SclGrupoSociaRow
        objsocia.Filter = "nSclGrupoSociaID = " & gruposocia
        objsocia.Retrieve()
        Dim idsocia As Integer = objsocia.ValueField("nSclSociaID")
        'MsgBox("iD SOCIA : " & idsocia)
        socia.Filter = "nSclSociaID = " & idsocia
        socia.Retrieve()
        'MsgBox("aCA TODO BIEN: nSclSociaID")

        If (String.IsNullOrEmpty(socia.ValueField("nStbEstadoCivilID").ToString)) Then
            EstadoCivilID = 1
        Else
            EstadoCivilID = CInt(socia.ValueField("nStbEstadoCivilID").ToString)
        End If
        'Dim idestadocivil As Integer = CInt()

        Dim Ovalorcatalogo As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Ovalorcatalogo.Filter = "nStbCatalogoID=1 and nStbValorCatalogoID=" & EstadoCivilID
        Ovalorcatalogo.Retrieve()
        Dim ec As String = Ovalorcatalogo.ValueField("sDescripcion")
        Return ec
    End Function

    Public Function ExtraerEstadoCivilID() As Integer
        Dim catalogo As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        catalogo.Filter = " nStbCatalogoID=1 and sDescripcion='" & cboEstadoCivil.Text & "'"
        catalogo.Retrieve()
        Dim id = catalogo.ValueField("nStbValorcatalogoID")
        Return id
    End Function

    Private Sub CargarFicha()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Dim ObjUbicacionDT As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar la Ficha correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjFichadt.Filter = "nSclFichaSociaID = " & Me.intFichaID
            ObjFichadt.Retrieve()
            If ObjFichadt.Count = 0 Then
                Exit Sub
            End If
            ObjFichadr = ObjFichadt.Current





            'No. de Comprobante 
            If Not ObjFichadr.IsFieldNull("sCodigo") Then
                Me.txtCodigo.Text = ObjFichadr.sCodigo
                Me.txtCodigoOC.Text = ObjFichadr.sCodigo
                Me.txtCodigoRC.Text = ObjFichadr.sCodigo
            Else
                Me.txtCodigo.Text = ""
                Me.txtCodigoOC.Text = ""
                Me.txtCodigoRC.Text = ""
            End If

            'Estado
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjFichadr.nStbEstadoFichaID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoOC.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoRC.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            'Fecha de Inscripción 
            If Not ObjFichadr.IsFieldNull("dFechaInscripcion") Then
                Me.cdeFechaInscripcion.Value = ObjFichadr.dFechaInscripcion
            Else
                Me.cdeFechaInscripcion.Value = Me.cdeFechaInscripcion.ValueIsDbNull
            End If

            'Fecha de Verificación 
            If Not ObjFichadr.IsFieldNull("dFechaHoraVerificacion") Then
                Me.cdeFechaVerificacion.Value = ObjFichadr.dFechaHoraVerificacion
            Else
                Me.cdeFechaVerificacion.Value = Me.cdeFechaVerificacion.ValueIsDbNull
            End If

            'Fecha de Apertura Negocio
            If Not ObjFichadr.IsFieldNull("dFechaAperturaNegocioVerificada") Then
                Me.cdeFechaApertura.Value = ObjFichadr.dFechaAperturaNegocioVerificada
            Else
                Me.cdeFechaApertura.Value = Me.cdeFechaApertura.ValueIsDbNull
            End If

            'Socia
            strSQL = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.nStbMunicipioID,a.nStbDepartamentoID," & _
                     " a.nStbDistritoID" & _
                     " From vwSclUbicacionFichaInscripcion a " & _
                     " Where a.nSclGrupoSociaID = " & ObjFichadr.nSclGrupoSociaID

            ObjUbicacionDT.ExecuteSql(strSQL)
            If ObjUbicacionDT.Count > 0 Then
                If Not ObjUbicacionDT.ValueField("nStbDepartamentoID") Is DBNull.Value Then
                    CargarDepartamento(ObjUbicacionDT.ValueField("nStbDepartamentoID"))
                    If Me.cboDepartamento.ListCount > 0 Then
                        Me.cboDepartamento.SelectedIndex = 0
                        XdsFicha("Departamento").SetCurrentByID("nStbDepartamentoID", ObjUbicacionDT.ValueField("nStbDepartamentoID"))
                    End If

                    If Not ObjUbicacionDT.ValueField("nStbMunicipioID") Is DBNull.Value Then
                        CargarMunicipio(0, ObjUbicacionDT.ValueField("nStbMunicipioID"))
                        If Me.cboMunicipio.ListCount > 0 Then
                            Me.cboMunicipio.SelectedIndex = 0
                            XdsFicha("Municipio").SetCurrentByID("nStbMunicipioID", ObjUbicacionDT.ValueField("nStbMunicipioID"))
                        End If

                        XdsFicha("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))

                        If Not ObjUbicacionDT.ValueField("nStbBarrioVerificadoID") Is DBNull.Value Then
                            CargarBarrio(0, ObjUbicacionDT.ValueField("nStbBarrioVerificadoID"))
                            If Me.cboBarrio.ListCount > 0 Then
                                Me.cboBarrio.SelectedIndex = 0
                                XdsFicha("Barrio").SetCurrentByID("nStbBarrioID", ObjUbicacionDT.ValueField("nStbBarrioVerificadoID"))
                            End If

                            If Not ObjUbicacionDT.ValueField("nSclGrupoSolidarioID") Is DBNull.Value Then
                                CargarGrupo(0, ObjUbicacionDT.ValueField("nSclGrupoSolidarioID"))
                                If Me.cboGrupo.ListCount > 0 Then
                                    Me.cboGrupo.SelectedIndex = 0
                                    XdsFicha("Grupo").SetCurrentByID("nSclGrupoSolidarioID", ObjUbicacionDT.ValueField("nSclGrupoSolidarioID"))
                                End If

                                If Me.cboSocia.ListCount > 0 Then
                                    Me.cboSocia.SelectedIndex = 0
                                    XdsFicha("Socia").SetCurrentByID("nSclGrupoSociaID", ObjFichadr.nSclGrupoSociaID)
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'Dirección Socia
            If Not ObjFichadr.IsFieldNull("sDireccionSociaVerificada") Then
                Me.txtDireccion.Text = ObjFichadr.sDireccionSociaVerificada
            Else
                Me.txtDireccion.Text = ""
            End If

            'Dirección Negocio
            If Not ObjFichadr.IsFieldNull("sDireccionNegocioVerificada") Then
                Me.txtIV12.Text = ObjFichadr.sDireccionNegocioVerificada
            Else
                Me.txtIV12.Text = ""
            End If

            'Observaciones Verificación
            If Not ObjFichadr.IsFieldNull("sObservacionesVerificacion") Then
                Me.txtObservaciones.Text = ObjFichadr.sObservacionesVerificacion
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Telefono
            If Not ObjFichadr.IsFieldNull("sTelefonoSociaVerificado") Then
                Me.txtTelefono.Text = ObjFichadr.sTelefonoSociaVerificado
            Else
                Me.txtTelefono.Text = ""
            End If

            'Representante Programa
            If Not ObjFichadr.IsFieldNull("nSrhEmpleadoProgramaID") Then
                CargarRepresentante(ObjFichadr.nSrhEmpleadoProgramaID)
                If Me.cboRepresentante.ListCount > 0 Then
                    Me.cboRepresentante.SelectedIndex = 0
                    XdsFicha("Representante").SetCurrentByID("nSrhEmpleadoID", ObjFichadr.nSrhEmpleadoProgramaID)
                End If
            Else
                Me.cboRepresentante.Text = ""
                Me.cboRepresentante.SelectedIndex = -1
            End If

            'Buscar el que actualmente tiene la socia
            cboEstadoCivil.SelectedText = ExtraerEstadoCivil()

            'Primaria
            If Not ObjFichadr.IsFieldNull("nStbPrimariaVerificadaID") Then
                XdsFicha("Primaria").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbPrimariaVerificadaID)
            Else
                Me.cboPrimaria.Text = ""
                Me.cboPrimaria.SelectedIndex = -1
            End If

            'Secundaria
            If Not ObjFichadr.IsFieldNull("nStbSecundariaVerificadaID") Then
                XdsFicha("Secundaria").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbSecundariaVerificadaID)
            Else
                Me.cboSecundaria.Text = ""
                Me.cboSecundaria.SelectedIndex = -1
            End If

            'Carrera Técnica
            If Not ObjFichadr.IsFieldNull("nStbCarreraTecnicaVerificadaID") Then
                CargarCarreraTecnica(ObjFichadr.nStbCarreraTecnicaVerificadaID)
                If Me.cboCarreraTecnica.ListCount > 0 Then
                    Me.cboCarreraTecnica.SelectedIndex = 0
                    XdsFicha("CarreraTecnica").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbCarreraTecnicaVerificadaID)
                End If
            Else
                Me.cboCarreraTecnica.Text = ""
                Me.cboCarreraTecnica.SelectedIndex = -1
            End If

            'Conoce Socias
            If Not ObjFichadr.IsFieldNull("nStbSociasConocidasID") Then
                If Me.cboConoceSocias.ListCount > 0 Then
                    Me.cboConoceSocias.SelectedIndex = 0
                    XdsFicha("SociasConocidas").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbSociasConocidasID)
                End If
            Else
                Me.cboConoceSocias.Text = ""
                Me.cboConoceSocias.SelectedIndex = -1
            End If

            'Otros Estudios
            If Not ObjFichadr.IsFieldNull("sOtrosEstudiosVerificado") Then
                Me.txtOtrosEstudios.Text = ObjFichadr.sOtrosEstudiosVerificado
            Else
                Me.txtOtrosEstudios.Text = ""
            End If

            'Alfabetizada
            If Not ObjFichadr.IsFieldNull("nAlfabetizadaVerificada") Then
                Me.chkAlfabetizada.Checked = ObjFichadr.nAlfabetizadaVerificada
            End If

            'Monto Solicitado
            If Not ObjFichadr.IsFieldNull("nMontoCreditoVerificado") Then
                Me.cneMontoSolicitado.Value = ObjFichadr.nMontoCreditoVerificado
            Else
                Me.cneMontoSolicitado.Value = 0
            End If

            'Número Hijos Vivos
            If Not ObjFichadr.IsFieldNull("nNumHijosVivos") Then
                Me.txtNumHijosVivos.Text = ObjFichadr.nNumHijosVivos
            Else
                Me.txtNumHijosVivos.Text = ""
            End If

            'Número Hijos Dependientes
            If Not ObjFichadr.IsFieldNull("nNumHijosDependientes") Then
                Me.txtNumHijosDependientes.Text = ObjFichadr.nNumHijosDependientes
            Else
                Me.txtNumHijosDependientes.Text = ""
            End If

            'Plazo
            If Not ObjFichadr.IsFieldNull("nPlazoVerificado") Then
                Me.txtPlazo.Text = ObjFichadr.nPlazoVerificado
            Else
                Me.txtPlazo.Text = ""
            End If

            'Tipo Plazo
            If Not ObjFichadr.IsFieldNull("nStbTipoPlazoVerificadoID") Then
                XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoPlazoVerificadoID)
            Else
                Me.cboTipoPlazo.Text = ""
                Me.cboTipoPlazo.SelectedIndex = -1
            End If

            'Tiene Negocio Actual
            If Not ObjFichadr.IsFieldNull("nTieneNegocioVerificado") Then
                If ObjFichadr.nTieneNegocioVerificado = 1 Then
                    Me.radSiTieneNegocio.Checked = True
                    Me.cboTipoNegocioActual.Enabled = True


                    'Tipo Negocio Actual
                    If Not ObjFichadr.IsFieldNull("nStbActividadEconomicaVerificadaID") Then
                        CargarTipoNegocioActual(ObjFichadr.nStbActividadEconomicaVerificadaID)
                        If Me.cboTipoNegocioActualRubro.ListCount > 0 Then
                            Me.cboTipoNegocioActualRubro.SelectedIndex = 0
                        End If
                        XdsFicha("TipoNegocioActual").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbActividadEconomicaVerificadaID)
                        CargarRubro()
                    Else
                        CargarTipoNegocioActual(39)
                        Me.cboTipoNegocioActualRubro.Text = ""
                        Me.cboTipoNegocioActualRubro.SelectedIndex = -1

                        CargarTipoNegocioActual(ObjFichadr.nStbActividadEconomicaID)
                        If Me.cboTipoNegocioActualRubro.ListCount > 0 Then
                            Me.cboTipoNegocioActualRubro.SelectedIndex = 0
                        End If
                        XdsFicha("TipoNegocioActual").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbActividadEconomicaID)

                        CargarRubro()


                    End If
                Else
                    '    Me.radNoTieneNegocio.Checked = True
                    '    Me.cboTipoNegocioActualRubro.Enabled = False
                    '    Me.cboTipoNegocioPropuesto.Enabled = True

                    '    'Tipo Negocio Propuesto
                    '    'If Not ObjFichadr.IsFieldNull("nStbActividadEconomicaVerificadaID") Then
                    '    '    CargarTipoNegocioPropuesto(ObjFichadr.nStbActividadEconomicaVerificadaID)
                    '    '    If Me.cboTipoNegocioPropuesto.ListCount > 0 Then
                    '    '        Me.cboTipoNegocioPropuesto.SelectedIndex = 0
                    '    '    End If

                    '    '    XdsFicha("TipoNegocioPropuesto").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbActividadEconomicaVerificadaID)
                    '    'Else
                    '    Me.cboTipoNegocioPropuesto.Text = ""
                    '    Me.cboTipoNegocioPropuesto.DataSource = Nothing
                    '    'End If
                End If
            End If

            'Promedio Ventas
            If Not ObjFichadr.IsFieldNull("nPromedioVentasVerificado") Then
                Me.cnePromedioVentas.Value = ObjFichadr.nPromedioVentasVerificado
            Else
                Me.cnePromedioVentas.Value = 0
            End If

            'Tipo Promedio Ventas
            If Not ObjFichadr.IsFieldNull("nStbTipoPlazoPromVentasVerificadoID") Then
                XdsFicha("TipoVenta").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoPlazoPromVentasVerificadoID)
            Else
                Me.cboTipoPromedioVentas.Text = ""
                Me.cboTipoPromedioVentas.SelectedIndex = -1
            End If

            'Edad
            If Not ObjFichadr.IsFieldNull("nEdadAnios") Then
                Me.txtEdad.Text = ObjFichadr.nEdadAnios
            Else
                Me.txtEdad.Text = ""
            End If







            'Inicializar los Length de los campos
            Me.txtOtrosEstudios.MaxLength = ObjFichadr.GetColumnLenght("sOtrosEstudiosVerificado")
            Me.txtIV12.MaxLength = ObjFichadr.GetColumnLenght("sDireccionNegocioVerificada")
            Me.txtDireccion.MaxLength = ObjFichadr.GetColumnLenght("sDireccionSociaVerificada")
            Me.txtObservaciones.MaxLength = ObjFichadr.GetColumnLenght("sObservacionesVerificacion")
            Me.txtTelefono.MaxLength = ObjFichadr.GetColumnLenght("sTelefonoSocia")

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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim dFechaInscripcion As Date
            Dim dFechaVerificacion As Date
            Dim strSQL As String
            Dim dFechaInicioPrograma As Date
            Dim strFecha As String
            Dim nTipoPlan As Integer

            ValidaDatosEntrada = True
            Me.errFicha.Clear()

            nTipoPlan = XdsFicha("Grupo").ValueField("nSclTipodePlandeNegocioID")

            'Fecha de Inscripción
            If Me.cdeFechaInscripcion.ValueIsDbNull Then
                MsgBox("La Fecha de Inscripción NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaInscripcion, "La Fecha de Inscripción NO DEBE quedar vacía.")
                Me.cdeFechaInscripcion.Focus()
                Exit Function
            End If

            'Fecha de Verificación
            If Me.cdeFechaVerificacion.ValueIsDbNull Then
                MsgBox("La Fecha de Verificación NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaVerificacion, "La Fecha de Verificación NO DEBE quedar vacía.")
                Me.cdeFechaVerificacion.Focus()
                Exit Function
            End If

            dFechaInscripcion = Me.cdeFechaInscripcion.Value
            dFechaVerificacion = Me.cdeFechaVerificacion.Value

            XdtValorParametro.Filter = "nStbParametroID = 4"
            XdtValorParametro.Retrieve()

            strFecha = Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 1, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 3, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 5, 4)

            dFechaInicioPrograma = CDate(strFecha)

            'dFechaInscripcion = Me.cdeFechaInscripcion.Value

            'Fecha de Inscripción no menor que la Fecha de Inicio del Programa
            If dFechaInscripcion.Date < dFechaInicioPrograma.Date Then
                MsgBox("Fecha de Inscripción (" & dFechaInscripcion.Date & ") NO DEBE ser Menor que la Fecha de Inicio del Programa (" & dFechaInicioPrograma.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaInscripcion, "Fecha de Inscripción (" & dFechaInscripcion.Date & ") NO DEBE ser Menor que la Fecha de Inicio del Programa (" & dFechaInicioPrograma.Date & ").")
                Me.cdeFechaInscripcion.Focus()
                Exit Function
            End If

            'Fecha de Inscripción no mayor que la Fecha del Servidor
            If dFechaInscripcion.Date > FechaServer().Date Then
                MsgBox("Fecha de Inscripción (" & dFechaInscripcion.Date & ") NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaInscripcion, "Fecha de Inscripción (" & dFechaInscripcion.Date & ") NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").")
                Me.cdeFechaInscripcion.Focus()
                Exit Function
            End If

            'Fecha de Verificación
            If dFechaInscripcion.Date > dFechaVerificacion.Date Then
                MsgBox("La Fecha de Verificación DEBE ser Mayor o Igual que la Fecha de Inscripción.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaVerificacion, "La Fecha de Verificación DEBE ser Mayor o Igual que la Fecha de Inscripción.")
                Me.cdeFechaVerificacion.Focus()
                Exit Function
            End If

            'Fecha de Verificación no mayor que la Fecha del Servidor
            If dFechaVerificacion.Date > FechaServer().Date Then
                MsgBox("Fecha de Verificación (" & dFechaVerificacion.Date & ") NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaVerificacion, "Fecha de Verificación (" & dFechaVerificacion.Date & ") NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").")
                Me.cdeFechaVerificacion.Focus()
                Exit Function
            End If

            'Departamento
            'If Me.cboDepartamento.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
            '    Me.cboDepartamento.Focus()
            '    Exit Function
            'End If

            'Municipio
            'If Me.cboMunicipio.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
            '    Me.cboMunicipio.Focus()
            '    Exit Function
            'End If

            'Distrito
            'If Me.cboDistrito.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
            '    Me.cboDistrito.Focus()
            '    Exit Function
            'End If

            'Barrio
            'If Me.cboBarrio.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar un Barrio válido.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cboBarrio, "Debe seleccionar un Barrio válido.")
            '    Me.cboBarrio.Focus()
            '    Exit Function
            'End If

            'Grupo
            'If Me.cboGrupo.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar un Grupo Solidario válido.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cboGrupo, "Debe seleccionar un Grupo Solidario válido.")
            '    Me.cboGrupo.Focus()
            '    Exit Function
            'End If

            'Representante del Programa
            If Me.cboRepresentante.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Representante del Programa válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboRepresentante, "Debe seleccionar un Representante del Programa válido.")
                Me.cboRepresentante.Focus()
                Exit Function
            End If

            'Nivel de Educación Primaria:
            If Me.cboPrimaria.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un nivel de escolaridad Primaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboPrimaria, "Debe seleccionar un nivel de escolaridad Primaria.")
                Me.cboPrimaria.Focus()
                Exit Function
            End If

            'Si al menos se indicó Educación primaria (último año) 
            'no puede indicar Alfabetizada = 0:
            If chkAlfabetizada.Checked = False Then
                If cboPrimaria.Columns("sCodigoInterno").Value = "7" Then
                    MsgBox("Imposible indicar Socia NO Alfabetizada" & Chr(13) & _
                       " si esta tiene la Primaria aprobada.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.chkAlfabetizada, "Imposible indicar Socia NO Alfabetizada si esta tiene la Primaria aprobada.")
                    Me.chkAlfabetizada.Focus()
                    Exit Function
                End If
            End If

            'Nivel de Educación Secundaria:
            If Me.cboSecundaria.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un nivel de escolaridad Secundaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboSecundaria, "Debe seleccionar un nivel de escolaridad Secundaria.")
                Me.cboSecundaria.Focus()
                Exit Function
            End If

            'No se puede indicar secundaria > a NINGUNA 
            'si no se indicó último año de primaria:
            If (CInt(cboSecundaria.Columns("sCodigoInterno").Value) > 1) And (cboPrimaria.Columns("sCodigoInterno").Value <> "7") Then
                MsgBox("Imposible indicar Educación Secundaria" & Chr(13) & _
                       " si no se tiene la Primaria aprobada.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboSecundaria, "Imposible indicar Educación Secundaria si no se tiene la Primaria aprobada.")
                Me.cboSecundaria.Focus()
                Exit Function
            End If

            'Nivel de educacion universitaria
            If Me.cboUniversidad.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un nivel de escolaridad Universitario.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboSecundaria, "Debe seleccionar un nivel de escolaridad Universitario.")
                Me.cboSecundaria.Focus()
                Exit Function
            End If

            'No se puede indicar universidad > a Ninguno
            ' si no se indico secundaria 5to año
            If (CInt(cboUniversidad.Columns("sCodigoInterno").Value) > 1) And (cboSecundaria.Columns("sCodigoInterno").Value <> "6") Then
                MsgBox("Imposible indicar Educación Universitaria" & Chr(13) & _
                       " si no se tiene la Secundaria aprobada.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboSecundaria, "Imposible indicar Educación Universitaria si no se tiene la Secundaria aprobada.")
                Me.cboSecundaria.Focus()
                Exit Function
            End If

            'Carrera Técnica:
            If Me.cboCarreraTecnica.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Carrera Técnica.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboCarreraTecnica, "Debe seleccionar una Carrera Técnica.")
                Me.cboCarreraTecnica.Focus()
                Exit Function
            End If

            'No se puede indicar carrera técnica 
            'si no se indicó Secundaria con Ciclo Báscico:
            If (CInt(cboCarreraTecnica.Columns("sCodigoInterno").Value) > 1) And (CInt(cboSecundaria.Columns("sCodigoInterno").Value) < 4) Then
                MsgBox("Imposible indicar Carrera Técnica si Socia" & Chr(13) & _
                       " no tiene el Ciclo Básico aprobado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboCarreraTecnica, "Imposible indicar Carrera Técnica si no se tiene el Ciclo Básico aprobado.")
                Me.cboCarreraTecnica.Focus()
                Exit Function
            End If

            'Usura Cero / 
            If nTipoPlan = 1 Or nTipoPlan = 2 Then
                XdtValorParametro.Filter = "nStbParametroID = 9"
            Else
                If nTipoPlan = 5 Or nTipoPlan = 6 Then 'PDIBA
                    XdtValorParametro.Filter = "nStbParametroID = 88"
                Else  'Ventana Genero
                    XdtValorParametro.Filter = "nStbParametroID = 56"
                End If

            End If
            XdtValorParametro.Retrieve()

            'Plazo Mínimo
            If CInt(Me.txtPlazo.Text) < CInt(XdtValorParametro.ValueField("sValorParametro")) Then
                MsgBox("El Plazo NO DEBE ser menor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
                    "establecido como mínimo por el Programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.txtPlazo, "El Plazo NO DEBE ser menor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
                    "establecido como mínimo por el Programa USURA CERO.")
                Me.txtPlazo.Focus()
                Exit Function
            End If

            'Usura Cero:
            If nTipoPlan = 1 Or nTipoPlan = 2 Then
                XdtValorParametro.Filter = "nStbParametroID = 10"
            ElseIf nTipoPlan = 5 Or nTipoPlan = 6 Then 'PDIBA
                XdtValorParametro.Filter = "nStbParametroID = 89"
            Else 'Ventana de Género.
                XdtValorParametro.Filter = "nStbParametroID = 57"
            End If
            XdtValorParametro.Retrieve()

            'Plazo Máximo
            If CInt(Me.txtPlazo.Text) > CInt(XdtValorParametro.ValueField("sValorParametro")) Then
                MsgBox("El Plazo NO DEBE ser mayor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
                    "establecido como máximo por el Programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.txtPlazo, "El Plazo NO DEBE ser mayor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
                    "establecido como máximo por el Programa USURA CERO.")
                Me.txtPlazo.Focus()
                Exit Function
            End If

            'Tipo de Plazo
            If Me.cboTipoPlazo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboTipoPlazo, "Debe seleccionar un Tipo de Plazo válido.")
                Me.cboTipoPlazo.Focus()
                Exit Function
            End If

            'Conoce Socias:
            If Me.cboConoceSocias.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Socias Conocidas válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboConoceSocias, "Debe seleccionar un Tipo de Socias Conocidas válido.")
                Me.cboConoceSocias.Focus()
                Exit Function
            End If

            'Monto Solicitado
            If Me.cneMontoSolicitado.ValueIsDbNull Then
                MsgBox("El Monto Solicitado NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cneMontoSolicitado, "El Monto Solicitado NO DEBE quedar vacío.")
                Me.cneMontoSolicitado.Focus()
                Exit Function
            End If

            If nTipoPlan = 1 Or nTipoPlan = 2 Or nTipoPlan = 5 Or nTipoPlan = 6 Then
                XdtValorParametro.Filter = "nStbParametroID = 7"
            Else
                XdtValorParametro.Filter = "nStbParametroID = 54"
            End If
            XdtValorParametro.Retrieve()


            If Not turismoT.Checked Then 'Validacion de Montos no Aplica para turismo
                'Monto Solicitado
                If Me.cneMontoSolicitado.Value < CDbl(XdtValorParametro.ValueField("sValorParametro")) Then
                    MsgBox("El Monto Solicitado NO DEBE ser menor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) &
                            "establecido como mínimo por el programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cneMontoSolicitado, "El Monto Solicitado NO DEBE ser menor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) &
                            "establecido como mínimo por el programa USURA CERO.")
                    Me.cneMontoSolicitado.Focus()
                    Exit Function
                End If
            End If

            'Usura Cero
            If nTipoPlan = 1 Or nTipoPlan = 2 Then
                XdtValorParametro.Filter = "nStbParametroID = 8"
            ElseIf nTipoPlan = 5 Or nTipoPlan = 6 Then 'PDIBA 
                XdtValorParametro.Filter = "nStbParametroID = 65"
            Else 'Ventana de Género
                XdtValorParametro.Filter = "nStbParametroID = 55"
            End If
            XdtValorParametro.Retrieve()

            'Monto Solicitado
            If Not turismoT.Checked Then
                If Me.cneMontoSolicitado.Value > CDbl(XdtValorParametro.ValueField("sValorParametro")) Then
                    MsgBox("El Monto Solicitado NO DEBE ser mayor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) &
                        "establecido como máximo por el programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cneMontoSolicitado, "El Monto Solicitado NO DEBE ser mayor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) &
                        "establecido como máximo por el programa USURA CERO.")
                    Me.cneMontoSolicitado.Focus()
                    Exit Function
                End If
            End If

            If nTipoPlan = 1 Or nTipoPlan = 2 Or nTipoPlan = 5 Or nTipoPlan = 6 Then
                'Monto debe estar contenido en la Tabla de Amortización:
                strSQL = "SELECT * FROM  StbTablaAmortizacion WHERE  (nMonto = " & Me.cneMontoSolicitado.Value & ")"

                If nTipoPlan = 1 Or nTipoPlan = 2 Then
                    strSQL &= " and nAplicaUsuraCero=1"
                ElseIf nTipoPlan = 5 Or nTipoPlan = 6 = 1
                    strSQL &= " and nAplicaPdiba=1"
                End If

                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Monto NO está contenido dentro de las Tablas de Amortización" & Chr(10) & _
                           "establecidas por el Programa USURA CERO.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cneMontoSolicitado, "Monto Aprobado Inválido.")
                    Me.cneMontoSolicitado.Focus()
                    Exit Function
                End If

                'Plazo debe estar contenido en la Tabla de Amortización:
                strSQL = "SELECT * FROM  StbTablaAmortizacion WHERE  (nPlazo = " & CInt(Me.txtPlazo.Text) & ")"

                If nTipoPlan = 1 Or nTipoPlan = 2 Then
                    strSQL &= " and nAplicaUsuraCero=1"
                ElseIf nTipoPlan = 5 Or nTipoPlan = 6 = 1
                    strSQL &= " and nAplicaPdiba=1"
                End If

                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Plazo NO está contenido dentro de las Tablas de Amortización" & Chr(10) & _
                           "establecidas por el Programa USURA CERO.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.txtPlazo, "Plazo Aprobado Inválido.")
                    Me.txtPlazo.Focus()
                    Exit Function
                End If
            End If

            'Dirección
            If Trim(RTrim(Me.txtDireccion.Text)).ToString.Length = 0 Then
                MsgBox("La Dirección de la Socia NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.txtDireccion, "La Dirección de la Socia NO DEBE quedar vacía.")
                Me.txtDireccion.Focus()
                Exit Function
            End If

            'If Me.radSiTieneNegocio.Checked = True Then

            '    'Tipo de Negocio Actual
            '    If Me.cboTipoNegocioActualRubro.SelectedIndex = -1 Then
            '        MsgBox("Debe seleccionar un Tipo de Negocio Actual válido.", MsgBoxStyle.Critical, "SMUSURA0")
            '        ValidaDatosEntrada = False
            '        Me.errFicha.SetError(Me.cboTipoNegocioActual, "Debe seleccionar un Tipo de Negocio Actual válido.")
            '        Me.cboTipoNegocioActual.Focus()
            '        Exit Function
            '    End If
            'Else
            '    'Tipo de Negocio Propuesto
            '    'If Me.cboTipoNegocioPropuesto.SelectedIndex = -1 Then
            '    '    MsgBox("Debe seleccionar un Tipo de Negocio Propuesto válido.", MsgBoxStyle.Critical, "SMUSURA0")
            '    '    ValidaDatosEntrada = False
            '    '    Me.errFicha.SetError(Me.cboTipoNegocioPropuesto, "Debe seleccionar un Tipo de Negocio Propuesto válido.")
            '    '    Me.cboTipoNegocioPropuesto.Focus()
            '    '    Exit Function
            '    'End If
            'End If

            If Me.radSiTieneNegocio.Checked = True Then
                'Dirección del Negocio
                'If Trim(RTrim(Me.txtIV12.Text)).ToString.Length = 0 Then
                '    MsgBox("La Dirección del Negocio NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                '    ValidaDatosEntrada = False
                '    Me.errFicha.SetError(Me.txtIV12, "La Dirección del Negocio NO DEBE quedar vacía.")
                '    Me.txtIV12.Focus()
                '    Exit Function
                'End If

                'Fecha de Apertura del Negocio --eliminada el 06/03/2015
                'If Me.cdeFechaApertura.ValueIsDbNull Then
                '    MsgBox("La Fecha de Apertura NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                '    ValidaDatosEntrada = False
                '    Me.errFicha.SetError(Me.cdeFechaVerificacion, "La Fecha de Apertura NO DEBE quedar vacía.")
                '    Me.cdeFechaVerificacion.Focus()
                '    Exit Function
                'End If

                'Promedio Ventas
                If Me.cnePromedioVentas.ValueIsDbNull Then
                    MsgBox("El Promedio en Ventas NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cnePromedioVentas, "El Promedio en Ventas NO DEBE quedar vacío.")
                    Me.cnePromedioVentas.Focus()
                    Exit Function
                End If

                'Promedio Ventas -- eliminado 06/03/2015
                'If Me.cnePromedioVentas.Value = 0 Then
                '    MsgBox("El Promedio en Ventas NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                '    ValidaDatosEntrada = False
                '    Me.errFicha.SetError(Me.cnePromedioVentas, "El Promedio en Ventas NO DEBE ser Cero.")
                '    Me.cnePromedioVentas.Focus()
                '    Exit Function
                'End If

                'Tipo de ventas
                'If Me.cboTipoPromedioVentas.SelectedIndex = -1 Then
                '    MsgBox("Debe seleccionar un Tipo de Plazo del Promedio de Ventas válido.", MsgBoxStyle.Critical, "SMUSURA0")
                '    ValidaDatosEntrada = False
                '    Me.errFicha.SetError(Me.cboTipoPromedioVentas, "Debe seleccionar un Tipo de Plazo del Promedio de Ventas válido.")
                '    Me.cboTipoPromedioVentas.Focus()
                '    Exit Function
                'End If
            End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Function

    Public Function ExistenDatosNuevosFicha(ByVal nSclFichaSociaID As Integer) As Boolean
        Dim fichaNegocio As New BOSistema.Win.SclEntFicha.SclFichaSociaNegocioDataTable
        fichaNegocio.Filter = " nSclFichaSociaID=" & nSclFichaSociaID
        fichaNegocio.Retrieve()
        If fichaNegocio.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function


    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       SalvarFicha
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Ficha en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarFicha()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            Dim dFechaVerificacion As Date
            Dim dFechaApertura As Date
            Dim intPrimariaID As Integer
            Dim intSecundariaID As Integer
            Dim intCarreraTecnicaID As Integer
            Dim intActividadEconomicaID As Integer
            Dim intTipoPromedioVentasID As Integer
            Dim intSociasConocidasID As Integer
            Dim intAlfabetizada As Short
            Dim intTieneNegocio As Short
            Dim dFechaInscripcion As Date

            'Dim intSociaConocida As Short

            dFechaInscripcion = Me.cdeFechaInscripcion.Value

            dFechaVerificacion = Me.cdeFechaVerificacion.Value

            'Alfabetizada
            If Me.chkAlfabetizada.Checked = True Then
                intAlfabetizada = 1
            Else
                intAlfabetizada = 0
            End If

            'Tiene Negocio
            If Me.radSiTieneNegocio.Checked = True Then
                intTieneNegocio = 1
            Else
                intTieneNegocio = 0
            End If

            'Primaria
            If Me.cboPrimaria.SelectedIndex <> -1 Then
                intPrimariaID = XdsFicha("Primaria").ValueField("nStbValorCatalogoID")
            Else
                intPrimariaID = -1
            End If

            'Socias Conocidas
            If Me.cboConoceSocias.SelectedIndex <> -1 Then
                intSociasConocidasID = XdsFicha("SociasConocidas").ValueField("nStbValorCatalogoID")
            Else
                intSociasConocidasID = -1
            End If

            'Secundaria
            If Me.cboSecundaria.SelectedIndex <> -1 Then
                intSecundariaID = XdsFicha("Secundaria").ValueField("nStbValorCatalogoID")
            Else
                intSecundariaID = -1
            End If

            'Carrera Técnica
            If Me.cboCarreraTecnica.SelectedIndex <> -1 Then
                intCarreraTecnicaID = XdsFicha("CarreraTecnica").ValueField("nStbValorCatalogoID")
            Else
                intCarreraTecnicaID = -1
            End If

            'Tipo Promedio Ventas
            If Me.cboTipoPromedioVentas.SelectedIndex <> -1 Then
                intTipoPromedioVentasID = XdsFicha("TipoVenta").ValueField("nStbValorCatalogoID")
            Else
                intTipoPromedioVentasID = -1
            End If

            ObjFichadr.sCodigo = Me.txtCodigo.Text

            If Me.cboTipoNegocioActualRubro.SelectedIndex <> -1 Then
                intActividadEconomicaID = XdsFicha("TipoNegocioActual").ValueField("nStbValorCatalogoID")
            Else
                'intActividadEconomicaID = XdsFicha("TipoNegocioPropuesto").ValueField("nStbValorCatalogoID")
                intActividadEconomicaID = 0
            End If

            If Me.ModoFrm = "ADD" Then
                If Me.cdeFechaApertura.ValueIsDbNull Then
                    strSQL = " EXEC spSclGrabarHojaVerificacion " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "',Null," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtIV12.Text & "'," & intTipoPromedioVentasID & ",'" & XdsFicha("Grupo").ValueField("sCodigo") & "','" & InfoSistema.LoginName & "','" & Me.txtObservaciones.Text & "','" & Format(Me.cdeFechaVerificacion.Value, "yyyy-MM-dd") & "'," & XdsFicha("Representante").ValueField("nSrhEmpleadoID") & "," & intSociasConocidasID & ",'" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta
                Else
                    dFechaApertura = Me.cdeFechaApertura.Value
                    strSQL = " EXEC spSclGrabarHojaVerificacion " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "','" & Format(dFechaApertura.Date, "yyyy-MM-dd") & "'," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtIV12.Text & "'," & intTipoPromedioVentasID & ",'" & XdsFicha("Grupo").ValueField("sCodigo") & "','" & InfoSistema.LoginName & "','" & Me.txtObservaciones.Text & "','" & Format(Me.cdeFechaVerificacion.Value, "yyyy-MM-dd") & "'," & XdsFicha("Representante").ValueField("nSrhEmpleadoID") & "," & intSociasConocidasID & ",'" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta
                End If
            Else
                ' -------------------------------------------------------------------------------------------------
                GuardarAuditoriaTablas(25, 2, "Modificar Ficha verificacion SclSocia", XdsFicha("Socia").ValueField("nSclSociaID"), InfoSistema.IDCuenta)
                GuardarAuditoriaTablas(7, 2, "Modificar Ficha verificacion SclFichaSocia", Me.intSclFichaID, InfoSistema.IDCuenta)
                ' -------------------------------------------------------------------------------------------------
                If Me.cdeFechaApertura.ValueIsDbNull Then
                    strSQL = " EXEC spSclGrabarHojaVerificacionNuevo " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "',Null," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtIV12.Text & "'," & intTipoPromedioVentasID & ",'" & Me.txtCodigo.Text & "','" & InfoSistema.LoginName & "','" & Me.txtObservaciones.Text & "','" & Format(Me.cdeFechaVerificacion.Value, "yyyy-MM-dd") & "'," & XdsFicha("Representante").ValueField("nSrhEmpleadoID") & "," & intSociasConocidasID & ",'" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta
                    strSQL &= "," & EstadoCivilID
                    strSQL &= "," & TipoActividadID
                    strSQL &= "," & OtraActividad
                    strSQL &= "," & TieneNegocioNuevo
                    strSQL &= "," & DescripcionNegocio
                    strSQL &= "," & RubroNegocio
                    strSQL &= "," & CaracteristicaNegocio
                    strSQL &= "," & FuncionamientoNegocio
                    strSQL &= "," & VentaBrutaMes
                    strSQL &= "," & VentaBrutaSemana
                    strSQL &= "," & VentaBrutaOtro
                    strSQL &= "," & RegistrosVentas
                    strSQL &= "," & TieneFinanciamientoOtraInstitucion
                    strSQL &= "," & FinanciamientoOtraInstitucionMonto
                    strSQL &= "," & RecibeMercaderiaConsignacion
                    strSQL &= "," & RecibeMercaderiaConsignacionMonto
                    strSQL &= "," & CreditosOtrasEmpresas
                    strSQL &= "," & CreditosOtrasEmpresasMonto
                    strSQL &= "," & LeHaAgregadoAlNegocio
                    strSQL &= "," & QueleAgregadoAlNegocio
                    strSQL &= "," & OtrosProductosServicios
                    strSQL &= "," & DescripcionOtrosProductosServicios
                    strSQL &= "," & LoCambio
                    strSQL &= "," & DescripcionCambio
                    strSQL &= "," & CausasDelCambio
                    strSQL &= "," & DescripcionCausasDelCambioOtro
                    strSQL &= "," & CuantasPersonasTrabajan
                    strSQL &= "," & DescripcionCambiosEquipo
                    strSQL &= "," & DescripcionCambiosInfraestructura
                    strSQL &= "," & DescripcionCambiosMuebles
                    strSQL &= "," & MejoriaPercibidaAlimentacion
                    strSQL &= "," & MejoriaPercibidaEquiposElectronicos
                    strSQL &= "," & MejoriaPercibidaCasa
                    strSQL &= "," & MejoriaPercibidaMuebles
                    strSQL &= "," & MejoriaPercibidaEstudios
                    strSQL &= "," & MejoriaPercibidaConocimientoAutoEstima
                    strSQL &= "," & Observaciones
                    strSQL &= "," & Meta
                    strSQL &= "," & Promotor



                    strSQL &= "," & txtnMontoInventario.Value
                    strSQL &= "," & Turismo
                    'Clipboard.SetText(strSQL)

                Else
                    dFechaApertura = Me.cdeFechaApertura.Value
                    strSQL = " EXEC spSclGrabarHojaVerificacionNuevo " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "','" & Format(dFechaApertura.Date, "yyyy-MM-dd") & "'," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtIV12.Text & "'," & intTipoPromedioVentasID & ",'" & Me.txtCodigo.Text & "','" & InfoSistema.LoginName & "','" & Me.txtObservaciones.Text & "','" & Format(Me.cdeFechaVerificacion.Value, "yyyy-MM-dd") & "'," & XdsFicha("Representante").ValueField("nSrhEmpleadoID") & "," & intSociasConocidasID & ",'" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta
                    strSQL &= "," & EstadoCivilID
                    strSQL &= "," & TipoActividadID
                    strSQL &= "," & OtraActividad
                    strSQL &= "," & TieneNegocioNuevo
                    strSQL &= "," & DescripcionNegocio
                    strSQL &= "," & RubroNegocio
                    strSQL &= "," & CaracteristicaNegocio
                    strSQL &= "," & FuncionamientoNegocio
                    strSQL &= "," & VentaBrutaMes
                    strSQL &= "," & VentaBrutaSemana
                    strSQL &= "," & VentaBrutaOtro
                    strSQL &= "," & RegistrosVentas
                    strSQL &= "," & TieneFinanciamientoOtraInstitucion
                    strSQL &= "," & FinanciamientoOtraInstitucionMonto
                    strSQL &= "," & RecibeMercaderiaConsignacion
                    strSQL &= "," & RecibeMercaderiaConsignacionMonto
                    strSQL &= "," & CreditosOtrasEmpresas
                    strSQL &= "," & CreditosOtrasEmpresasMonto
                    strSQL &= "," & LeHaAgregadoAlNegocio
                    strSQL &= "," & QueleAgregadoAlNegocio
                    strSQL &= "," & OtrosProductosServicios
                    strSQL &= "," & DescripcionOtrosProductosServicios
                    strSQL &= "," & LoCambio
                    strSQL &= "," & DescripcionCambio
                    strSQL &= "," & CausasDelCambio
                    strSQL &= "," & DescripcionCausasDelCambioOtro
                    strSQL &= "," & CuantasPersonasTrabajan
                    strSQL &= "," & DescripcionCambiosEquipo
                    strSQL &= "," & DescripcionCambiosInfraestructura
                    strSQL &= "," & DescripcionCambiosMuebles
                    strSQL &= "," & MejoriaPercibidaAlimentacion
                    strSQL &= "," & MejoriaPercibidaEquiposElectronicos
                    strSQL &= "," & MejoriaPercibidaCasa
                    strSQL &= "," & MejoriaPercibidaMuebles
                    strSQL &= "," & MejoriaPercibidaEstudios
                    strSQL &= "," & MejoriaPercibidaConocimientoAutoEstima
                    strSQL &= "," & Observaciones
                    strSQL &= "," & Meta
                    strSQL &= "," & Promotor

                    strSQL &= "," & txtnMontoInventario.Value
                    strSQL &= "," & Turismo

                    'Clipboard.SetText(strSQL)

                End If
            End If






            Me.intFichaID = XcDatos.ExecuteScalar(strSQL)
            Dim strSQL2 As String
            strSQL2 = "spSclGrabarUniversidadSocia " & XdsFicha("Socia").ValueField("nSclSociaID") & ", " & cboUniversidad.SelectedValue & ", " & InfoSistema.IDCuenta
            Dim intUniversidadSocia = XcDatos.ExecuteScalar(strSQL2)

            If intUniversidadSocia = -1 Then
                MsgBox("Error al grabar dato de universidad de la socia.", vbCritical, "SMUSURA0")
            End If

            If Me.ModoFrm = "ADD" Then
                ' ------------------------------------------------------------------------------------------
                ' VAMOS CON LOS INSERT DE AUDITORIA 
                GuardarAuditoriaTablas(25, 1, "Agregar SclFichaSocia", intFichaID, InfoSistema.IDCuenta)
                ' ------------------------------------------------------------------------------------------
            End If

            '-- Buscar la ficha correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjFichadt.Filter = "nSclFichaSociaID = " & Me.intFichaID

            ObjFichadt.Retrieve()

            If ObjFichadt.Count = 0 Then
                Exit Sub
            End If
            ObjFichadr = ObjFichadt.Current

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.intFichaID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    Call GuardarAuditoria(2, 15, "Modificación de Ficha de Verificación ID: " & Me.intFichaID & ".")

                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    '    'Se indica que hubo modificación en la Fecha de Imputación
    '    Private Sub cdeFechaImputacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaImputacion.TextChanged
    '        Try
    '            'If Me.cboTipoMoneda.SelectedIndex <> -1 Then
    '            '    If XdsComprobante("TipoMoneda").ValueField("Nacional") = False Then
    '            '        CargarParidad()
    '            '    End If
    '            'End If
    '            vbModifico = True
    '        Catch ex As Exception
    '            Control_Error(ex)
    '        End Try
    '    End Sub
    '    'Se indica que hubo modificación en el Total Afectado
    '    Private Sub cneTotalAfectado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneTotalAfectado.TextChanged
    '        'If Me.strSigno = "-" Then
    '        '    Me.cneTotalAfectado.Value = Me.cneTotalAfectado.Value * (-1)
    '        'Else
    '        '    Me.cneTotalAfectado.Value = Me.cneTotalAfectado.Value
    '        'End If
    '        vbModifico = True
    '    End Sub

    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    Private Sub txtIV12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    'Se indica que hubo modificación en la Dirección de la Socia
    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged
        vbModifico = True
    End Sub
    'Se indica que hubo modificación en la Dirección del Negocio
    Private Sub txtIV12_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cdeFechaInscripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaVerificacion.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
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
                'CargarBarrio(0, 0)
            End If
        Else
            CargarDistrito(1, 0)
            CargarBarrio(1, 0)
        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex <> -1 Then
            CargarBarrio(0, 0)
        Else
            CargarBarrio(1, 0)
        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrio.TextChanged
        If Me.cboBarrio.SelectedIndex <> -1 Then
            CargarGrupo(0, 0)
            CargarMercado(0, 0)
        Else
            CargarGrupo(1, 0)
            CargarMercado(1, 0)
        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboGrupo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupo.TextChanged
        If Me.cboGrupo.SelectedIndex <> -1 Then
            If Me.cboMercado.ListCount > 0 Then
                Me.cboMercado.SelectedIndex = 0
                XdsFicha("Mercado").SetCurrentByID("nStbMercadoID", XdsFicha("Grupo").ValueField("nStbMercadoVerificadoID"))
            End If
            CargarSocia(0, 0)
        Else
            Me.cboMercado.SelectedIndex = -1
            CargarSocia(1, 0)
        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboSocia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSocia.TextChanged
        Try
            If Me.cboSocia.SelectedIndex <> -1 Then
                Me.txtNumCedula.Text = XdsFicha("Socia").ValueField("sNumeroCedula")

                'Telefono
                If Not XdsFicha("Socia").ValueField("sTelefonoSocia") Is DBNull.Value Then
                    Me.txtTelefono.Text = XdsFicha("Socia").ValueField("sTelefonoSocia")
                Else
                    Me.txtTelefono.Text = ""
                End If

                'NumHijosVivos
                Me.txtNumHijosVivos.Text = XdsFicha("Socia").ValueField("nNumHijosVivos")

                'Dirección
                Me.txtDireccion.Text = XdsFicha("Socia").ValueField("sDireccionSocia")

                'NumHijosDependientes
                Me.txtNumHijosDependientes.Text = XdsFicha("Socia").ValueField("nNumHijosDependientes")

                'Primaria
                If Not XdsFicha("Socia").ValueField("nStbPrimariaID") Is DBNull.Value Then
                    If Me.cboPrimaria.ListCount > 0 Then
                        Me.cboPrimaria.SelectedIndex = 0
                    End If
                    XdsFicha("Primaria").SetCurrentByID("nStbValorCatalogoID", XdsFicha("Socia").ValueField("nStbPrimariaID"))
                Else
                    Me.cboPrimaria.Text = ""
                    Me.cboPrimaria.SelectedIndex = -1
                End If

                'Secundaria
                If Not XdsFicha("Socia").ValueField("nStbSecundariaID") Is DBNull.Value Then
                    If Me.cboSecundaria.ListCount > 0 Then
                        Me.cboSecundaria.SelectedIndex = 0
                    End If
                    XdsFicha("Secundaria").SetCurrentByID("nStbValorCatalogoID", XdsFicha("Socia").ValueField("nStbSecundariaID"))
                Else
                    Me.cboSecundaria.Text = ""
                    Me.cboSecundaria.SelectedIndex = -1
                End If

                'Carrera Técnica
                If Not XdsFicha("Socia").ValueField("nSclCarreraTecnicaID") Is DBNull.Value Then
                    CargarCarreraTecnica(XdsFicha("Socia").ValueField("nStbCarreraTecnicaID"))
                    If Me.cboCarreraTecnica.ListCount > 0 Then
                        Me.cboCarreraTecnica.SelectedIndex = 0
                    End If
                    XdsFicha("CarreraTecnica").SetCurrentByID("nStbValorCatalogoID", XdsFicha("Socia").ValueField("nStbCarreraTecnicaID"))
                Else
                    Me.cboCarreraTecnica.Text = ""
                    Me.cboCarreraTecnica.SelectedIndex = -1
                End If

                'Otros Estudios
                If Not XdsFicha("Socia").ValueField("sOtrosEstudios") Is DBNull.Value Then
                    Me.txtOtrosEstudios.Text = XdsFicha("Socia").ValueField("sOtrosEstudios")
                Else
                    Me.txtOtrosEstudios.Text = ""
                End If

                'Alfabetizada
                If Not XdsFicha("Socia").ValueField("nAlfabetizada") Is DBNull.Value Then
                    Me.chkAlfabetizada.Checked = XdsFicha("Socia").ValueField("nAlfabetizada")
                End If

                'Edad
                Me.txtEdad.Text = DateDiff(DateInterval.Year, XdsFicha("Socia").ValueField("dFechaNacimiento"), ModSMUSURA0.FechaServer)

            End If
            vbModifico = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que haya habido algún cambio
    Private Sub txtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelefono.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboPrimaria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrimaria.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboSecundaria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSecundaria.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboCarreraTecnica_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCarreraTecnica.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtOtrosEstudios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtrosEstudios.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que haya habido algún cambio
    Private Sub txtOtrosEstudios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtrosEstudios.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub chkAlfabetizada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAlfabetizada.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub txtNumHijosVivos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumHijosVivos.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    'En caso que haya habido algún cambio
    Private Sub txtNumHijosVivos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumHijosVivos.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNumHijosDependientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumHijosDependientes.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    'En caso que haya habido algún cambio
    Private Sub txtNumHijosDependientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumHijosDependientes.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cneMontoSolicitado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMontoSolicitado.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtPlazo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlazo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    'En caso que haya habido algún cambio
    Private Sub txtPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlazo.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboTipoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazo.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub radNoTieneNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'En caso que haya habido algún cambio
    Private Sub radSiTieneNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboTipoNegocioActual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    'Private Sub cboTipoNegocioPropuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    vbModifico = True
    'End Sub
    'En caso que haya habido algún cambio
    Private Sub cdeFechaApertura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cnePromedioVentas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboTipoPromedioVentas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

#Region "Combos"
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarPrimaria
    ' Descripción:          Este procedimiento permite cargar el listado de niveles
    '                       para primaria en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarPrimaria()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'EducacionPrimaria') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("Primaria") Then
                XdsFicha("Primaria").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Primaria")
                XdsFicha("Primaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboPrimaria.DataSource = XdsFicha("Primaria").Source

            Me.cboPrimaria.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboPrimaria.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboPrimaria.Columns("sCodigoInterno").Caption = "Código"
            Me.cboPrimaria.Columns("sDescripcion").Caption = "Descripción"

            Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboPrimaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarSecundaria
    ' Descripción:          Este procedimiento permite cargar el listado de niveles
    '                       para secundaria en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarSecundaria()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'EducacionSecundaria') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("Secundaria") Then
                XdsFicha("Secundaria").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Secundaria")
                XdsFicha("Secundaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboSecundaria.DataSource = XdsFicha("Secundaria").Source

            Me.cboSecundaria.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboSecundaria.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboSecundaria.Columns("sCodigoInterno").Caption = "Código"
            Me.cboSecundaria.Columns("sDescripcion").Caption = "Descripción"

            Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboSecundaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarUniversidad()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'EducacionUniversitaria') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("Universidad") Then
                XdsFicha("Universidad").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Universidad")
                XdsFicha("Universidad").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboUniversidad.DataSource = XdsFicha("Universidad").Source

            Me.cboUniversidad.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboUniversidad.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboUniversidad.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboUniversidad.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboUniversidad.Columns("sCodigoInterno").Caption = "Código"
            Me.cboUniversidad.Columns("sDescripcion").Caption = "Descripción"

            Me.cboUniversidad.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboUniversidad.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboUniversidad.DisplayMember = "Descripción"
            Me.cboUniversidad.ValueMember = "nStbValorCatalogoID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarCarreraTecnica
    ' Descripción:          Este procedimiento permite cargar el listado de carreras
    '                       técnicas en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCarreraTecnica(ByVal intCarreraTecnicaID As Integer)
        Try
            Dim Strsql As String = ""

            If intCarreraTecnicaID = 0 Then
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'CarreraTecnica') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "
            Else
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'CarreraTecnica') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 or a.nStbValorCatalogoID = " & intCarreraTecnicaID & _
                         " Order by a.sCodigoInterno "
            End If

            If XdsFicha.ExistTable("CarreraTecnica") Then
                XdsFicha("CarreraTecnica").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "CarreraTecnica")
                XdsFicha("CarreraTecnica").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCarreraTecnica.DataSource = XdsFicha("CarreraTecnica").Source

            Me.cboCarreraTecnica.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboCarreraTecnica.Columns("sCodigoInterno").Caption = "Código"
            Me.cboCarreraTecnica.Columns("sDescripcion").Caption = "Descripción"

            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarConoceSocias
    ' Descripción:          Este procedimiento permite cargar el listado de Conoce
    '                       Socias en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarConoceSocias()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'SociasConocidas') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("SociasConocidas") Then
                XdsFicha("SociasConocidas").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "SociasConocidas")
                XdsFicha("SociasConocidas").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboConoceSocias.DataSource = XdsFicha("SociasConocidas").Source

            Me.cboConoceSocias.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboConoceSocias.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboConoceSocias.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboConoceSocias.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboConoceSocias.Columns("sCodigoInterno").Caption = "Código"
            Me.cboConoceSocias.Columns("sDescripcion").Caption = "Descripción"

            Me.cboConoceSocias.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboConoceSocias.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoNegocioActual
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoNegocioActual(ByVal intTipoNegocioActualID As Integer)
        Try
            Dim Strsql As String = ""

            If intTipoNegocioActualID = 0 Then
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "
            Else
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 or a.nStbValorCatalogoID = " & intTipoNegocioActualID & _
                         " Order by a.sCodigoInterno "
            End If

            If XdsFicha.ExistTable("TipoNegocioActual") Then
                XdsFicha("TipoNegocioActual").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoNegocioActual")
                XdsFicha("TipoNegocioActual").Retrieve()
            End If

            ''Asignando a las fuentes de datos
            Me.cboTipoNegocioActual.DataSource = XdsFicha("TipoNegocioActual").Source

            'Me.cboTipoNegocioActual.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            'Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            ''Configurar el combo
            'Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            'Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sDescripcion").Width = 140

            'Me.cboTipoNegocioActual.Columns("sCodigoInterno").Caption = "Código"
            'Me.cboTipoNegocioActual.Columns("sDescripcion").Caption = "Descripción"

            'Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            '''''''''''''''''''''''''''''''''''
            'Cambio el 02/03/2015
            'Asignando a las fuentes de datos
            Me.cboTipoNegocioActualRubro.DataSource = XdsFicha("TipoNegocioActual").Source

            Me.cboTipoNegocioActualRubro.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoNegocioActualRubro.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoNegocioActualRubro.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoNegocioActualRubro.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoNegocioActualRubro.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoNegocioActualRubro.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoNegocioActualRubro.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoNegocioActualRubro.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboTipoNegocioActualRubro.ValueMember = "nStbValorCatalogoID"
            Me.cboTipoNegocioActualRubro.DisplayMember = "sDescripcion"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoNegocioPropuesto
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoNegocioPropuesto(ByVal intTipoNegocioPropuestoID As Integer)
        Try
            Dim Strsql As String = ""

            If intTipoNegocioPropuestoID = 0 Then
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "
            Else
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 or a.nStbValorCatalogoID = " & intTipoNegocioPropuestoID & _
                         " Order by a.sCodigoInterno "
            End If

            If XdsFicha.ExistTable("TipoNegocioPropuesto") Then
                XdsFicha("TipoNegocioPropuesto").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoNegocioPropuesto")
                XdsFicha("TipoNegocioPropuesto").Retrieve()
            End If

            ''Asignando a las fuentes de datos
            'Me.cboTipoNegocioPropuesto.DataSource = XdsFicha("TipoNegocioPropuesto").Source

            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            ''Configurar el combo
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sDescripcion").Width = 140

            'Me.cboTipoNegocioPropuesto.Columns("sCodigoInterno").Caption = "Código"
            'Me.cboTipoNegocioPropuesto.Columns("sDescripcion").Caption = "Descripción"

            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '''''''''''''''''''''''''''''''''''
            'Cambio el 02/03/2015
            'Asignando a las fuentes de datos
            'Me.cboTipoNegocioPropuesto.DataSource = XdsFicha("TipoNegocioPropuesto").Source

            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            ''Configurar el combo
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sDescripcion").Width = 140

            'Me.cboTipoNegocioPropuesto.Columns("sCodigoInterno").Caption = "Código"
            'Me.cboTipoNegocioPropuesto.Columns("sDescripcion").Caption = "Descripción"

            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.cboTipoNegocioPropuesto.ValueMember = "nStbValorCatalogoID"
            'Me.cboTipoNegocioPropuesto.DisplayMember = "sDescripcion"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoVentas
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo para el promedio en ventas en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoVenta()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.nStbValorCatalogoID "

            If XdsFicha.ExistTable("TipoVenta") Then
                XdsFicha("TipoVenta").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoVenta")
                XdsFicha("TipoVenta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPromedioVentas.DataSource = XdsFicha("TipoVenta").Source

            Me.cboTipoPromedioVentas.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPromedioVentas.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPromedioVentas.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPromedioVentas.Splits(0).DisplayColumns("sDescripcion").Width = 70

            Me.cboTipoPromedioVentas.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPromedioVentas.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPromedioVentas.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPromedioVentas.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento(ByVal intDepartamentoID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If intDepartamentoID = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbDepartamento a " & _
                         " Where a.nPertenecePrograma = 1 And a.nActivo = 1" & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbDepartamento a " & _
                         " Where (a.nPertenecePrograma = 1 And a.nActivo = 1) or a.nStbDepartamentoID = " & intDepartamentoID & _
                         " Order by a.sCodigo"
            End If

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
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbMunicipio a " & _
                             " Where a.nStbDepartamentoID = " & XdsFicha("Departamento").ValueField("nStbDepartamentoID") & _
                             " And a.nPertenecePrograma = 1 and a.nActivo = 1" & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsFicha("Departamento").ValueField("nStbDepartamentoID") & _
                             " And a.nPertenecePrograma = 1 and a.nActivo = 1)" & _
                             " Or a.nStbMunicipioID = " & intMunicipioID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
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
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbBarrio a " & _
                             " Where a.nStbMunicipioID = " & XdsFicha("Municipio").ValueField("nStbMunicipioID") & _
                             " And a.nStbDistritoID = " & XdsFicha("Distrito").ValueField("nStbDistritoID") & _
                             " And a.nPertenecePrograma = 1 and a.nActivo = 1" & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbBarrio a " & _
                             " Where (a.nStbMunicipioID = " & XdsFicha("Municipio").ValueField("nStbMunicipioID") & _
                             " And a.nStbDistritoID = " & XdsFicha("Distrito").ValueField("nStbDistritoID") & _
                             " And a.nPertenecePrograma = 1 and a.nActivo = 1)" & _
                             " Or a.nStbBarrioID = " & intBarrioID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
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

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("Descripcion").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbDistrito a " & _
                             " Where a.nPertenecePrograma = 1 and a.nActivo = 1" & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbDistrito a " & _
                             " Where a.nPertenecePrograma = 1 and a.nActivo = 1" & _
                             " Or a.nStbDistritoID = " & intDistritoID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
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

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/09/2007
    ' Procedure Name:       CargarMercado
    ' Descripción:          Este procedimiento permite cargar el listado de Mercados
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMercado(ByVal intLimpiarID As Integer, ByVal intMercadoID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMercado.ClearFields()

            If intLimpiarID = 0 Then
                If intMercadoID = 0 Then 'Mercados del Barrio Indicado:
                    Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                             " From StbMercado a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & _
                             " )) Or (a.nStbMercadoID = 1) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                             " From StbMercado a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & _
                             " ) Or (a.nStbMercadoID = 1)) Or (a.nStbMercadoID = " & intMercadoID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                         " From StbMercado a " & _
                         " Where a.nStbMercadoID = 0"
            End If

            If XdsFicha.ExistTable("Mercado") Then
                XdsFicha("Mercado").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Mercado")
                XdsFicha("Mercado").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMercado.DataSource = XdsFicha("Mercado").Source
            Me.cboMercado.Rebind()

            'Configurar el combo Barrio:
            Me.cboMercado.Splits(0).DisplayColumns("nStbMercadoID").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMercado.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboMercado.Columns("sCodigo").Caption = "Código"
            Me.cboMercado.Columns("sNombre").Caption = "Descripción"
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercado.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarGrupo
    ' Descripción:          Este procedimiento permite cargar el listado de Grupos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarGrupo(ByVal intLimpiarID As Integer, ByVal intGrupoID As Integer)
        Try
            Dim Strsql As String

            Me.cboGrupo.ClearFields()
            If intLimpiarID = 0 Then
                If intGrupoID = 0 Then
                    Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nSclTipodePlandeNegocioID " & _
                             " From SclGrupoSolidario a " & _
                             " WHERE a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','3') And b.sNombre = 'EstadoGrupo') " & _
                             " And a.nStbBarrioID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nSclTipodePlandeNegocioID " & _
                             " From SclGrupoSolidario a " & _
                             " WHERE (a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','3') And b.sNombre = 'EstadoGrupo') " & _
                             " And a.nStbBarrioID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & ")" & _
                             " Or a.nSclGrupoSolidarioID = " & intGrupoID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nSclTipodePlandeNegocioID " & _
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

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboGrupo.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nStbBarrioVerificadoID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nSclTipodePlandeNegocioID").Visible = False

            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").Width = 90
            Me.cboGrupo.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboGrupo.Columns("sCodigo").Caption = "Código"
            Me.cboGrupo.Columns("Descripcion").Caption = "Descripción"

            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupo.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarSocia
    ' Descripción:          Este procedimiento permite cargar el listado de Socias
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarSocia(ByVal intLimpiarID As Integer, ByVal intGrupoSociaID As Integer)
        Try
            Dim Strsql As String

            Me.cboSocia.ClearFields()
            If intLimpiarID = 0 Then
                If intGrupoSociaID = 0 Then
                    Strsql = " Select a.nSclGrupoSociaID,b.nSclSociaID,a.nSclGrupoSolidarioID,b.sNumeroCedula,(b.sNombre1 + ' ' + b.sNombre2 + ' ' + b.sApellido1 + ' ' + b.sApellido2) as Descripcion, " & _
                             " b.sDireccionSocia,b.sTelefonoSocia,b.nAlfabetizada,b.nStbPrimariaID,b.nStbSecundariaID,b.nStbCarreraTecnicaID,b.sOtrosEstudios, " & _
                             " b.nNumHijosVivos,b.nNumHijosDependientes,b.dFechaNacimiento" & _
                             " From SclGrupoSocia a INNER JOIN SclSocia b " & _
                             " ON a.nSclSociaID = b.nSclSociaID" & _
                             " WHERE b.nSociaActiva = 1 " & _
                             " And a.nSclGrupoSolidarioID = " & XdsFicha("Grupo").ValueField("nSclGrupoSolidarioID") & _
                             " Order by b.sNumeroCedula "
                Else
                    Strsql = " Select a.nSclGrupoSociaID,b.nSclSociaID,a.nSclGrupoSolidarioID,b.sNumeroCedula,(b.sNombre1 + ' ' + b.sNombre2 + ' ' + b.sApellido1 + ' ' + b.sApellido2) as Descripcion, " & _
                             " b.sDireccionSocia,b.sTelefonoSocia,b.nAlfabetizada,b.nStbPrimariaID,b.nStbSecundariaID,b.nStbCarreraTecnicaID,b.sOtrosEstudios, " & _
                             " b.nNumHijosVivos,b.nNumHijosDependientes,b.dFechaNacimiento" & _
                             " From SclGrupoSocia a INNER JOIN SclSocia b " & _
                             " ON a.nSclSociaID = b.nSclSociaID" & _
                             " WHERE (b.nSociaActiva = 1 " & _
                             " And a.nSclGrupoSolidarioID = " & XdsFicha("Grupo").ValueField("nSclGrupoSolidarioID") & ")" & _
                             " Or a.nSclGrupoSociaID = " & intGrupoSociaID & _
                             " Order by b.sNumeroCedula "
                End If
            Else
                Strsql = " Select a.nSclGrupoSociaID,b.nSclSociaID,a.nSclGrupoSolidarioID,b.sNumeroCedula,(b.sNombre1 + ' ' + b.sNombre2 + ' ' + b.sApellido1 + ' ' + b.sApellido2) as Descripcion, " & _
                         " b.sDireccionSocia,b.sTelefonoSocia,b.nAlfabetizada,b.nStbPrimariaID,b.nStbSecundariaID,b.nStbCarreraTecnicaID,b.sOtrosEstudios, " & _
                         " b.nNumHijosVivos,b.nNumHijosDependientes,b.dFechaNacimiento" & _
                         " From SclGrupoSocia a INNER JOIN SclSocia b " & _
                         " ON a.nSclSociaID = b.nSclSociaID" & _
                         " WHERE a.nSclGrupoSociaID = 0 "
            End If

            If XdsFicha.ExistTable("Socia") Then
                XdsFicha("Socia").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Socia")
                XdsFicha("Socia").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboSocia.DataSource = XdsFicha("Socia").Source
            Me.cboSocia.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboSocia.Splits(0).DisplayColumns("nSclGrupoSociaID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("sDireccionSocia").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("sTelefonoSocia").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nAlfabetizada").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nStbPrimariaID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nStbSecundariaID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nStbCarreraTecnicaID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("sOtrosEstudios").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nNumHijosVivos").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nNumHijosDependientes").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("dFechaNacimiento").Visible = False

            Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.cboSocia.Splits(0).DisplayColumns("Descripcion").Width = 120

            Me.cboSocia.Columns("sNumeroCedula").Caption = "No.Cédula"
            Me.cboSocia.Columns("Descripcion").Caption = "Nombres y Apellidos"

            Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboSocia.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarRepresentante
    ' Descripción:          Este procedimiento permite cargar el listado de Empleados
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarRepresentante(ByVal intRepresentanteID As Integer)
        Try
            Dim Strsql As String

            Me.cboSocia.ClearFields()

            If intRepresentanteID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE a.nActivo = 1 And a.sCodCargo IN ('01','03','10', '12', '15') " & _
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE (a.nActivo = 1 And a.sCodCargo IN ('01','03','10','12','15')) " & _
                         " Or a.nSrhEmpleadoID = " & intRepresentanteID & _
                         " Order by a.nCodigo "
            End If

            If XdsFicha.ExistTable("Representante") Then
                XdsFicha("Representante").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Representante")
                XdsFicha("Representante").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboRepresentante.DataSource = XdsFicha("Representante").Source
            Me.cboRepresentante.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboRepresentante.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False

            'Configurar el combo
            Me.cboRepresentante.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboRepresentante.Splits(0).DisplayColumns("sNombreEmpleado").Width = 350

            Me.cboRepresentante.Columns("nCodigo").Caption = "Código"
            Me.cboRepresentante.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboRepresentante.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboRepresentante.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub chkAlfabetizada_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAlfabetizada.GotFocus
        Try
            Me.chkAlfabetizada.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub chkAlfabetizada_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAlfabetizada.LostFocus
        Try
            Me.chkAlfabetizada.BackColor = Me.grpDatosGenerales.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
#End Region
#Region "Detalle Otros Créditos"
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarOtroCredito
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de Otros Créditos vigentes en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarOtroCredito()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclOtroCreditoVigenteID,a.sSiglas,a.sOtroPrestamista,a.nMontoDeuda,a.nPlazo,a.sTipoPlazo,a.nMontoCuota, " & _
                         " a.sPeriodicidad,a.nSaldo,a.nActivo " & _
                         " From vwSclOtroCreditoVerificado a " & _
                         " Where a.nSclFichaSociaID = " & Me.intFichaID

            If XdsDetalle.ExistTable("OtroCredito") Then
                XdsDetalle("OtroCredito").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "OtroCredito")
                XdsDetalle("OtroCredito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdOtroCredito.DataSource = XdsDetalle("OtroCredito").Source
            Me.grdOtroCredito.FetchRowStyles = True

            'Actualizando el caption de los GRIDS
            Me.grdOtroCredito.Caption = " Listado de Otros Créditos (" + Me.grdOtroCredito.RowCount.ToString + " registros)"

            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       FormatoOtroCredito
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Otros Créditos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoOtroCredito()
        Try
            'Configuracion del Grid 
            Me.grdOtroCredito.Splits(0).DisplayColumns("nSclOtroCreditoVigenteID").Visible = False

            Me.grdOtroCredito.ColumnFooters = True
            Me.grdOtroCredito.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").FooterStyle.ForeColor = Color.Blue

            Me.grdOtroCredito.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdOtroCredito.Splits(0).DisplayColumns("sSiglas").Width = 90
            Me.grdOtroCredito.Splits(0).DisplayColumns("nPlazo").Width = 50
            Me.grdOtroCredito.Splits(0).DisplayColumns("sTipoPlazo").Width = 70
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoCuota").Width = 90
            Me.grdOtroCredito.Splits(0).DisplayColumns("sPeriodicidad").Width = 70
            Me.grdOtroCredito.Splits(0).DisplayColumns("nSaldo").Width = 70
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").Width = 100
            Me.grdOtroCredito.Splits(0).DisplayColumns("sOtroPrestamista").Width = 90
            Me.grdOtroCredito.Splits(0).DisplayColumns("nActivo").Width = 60

            Me.grdOtroCredito.Columns("sSiglas").Caption = "Institución"
            Me.grdOtroCredito.Columns("nMontoDeuda").Caption = "Monto Crédito"
            Me.grdOtroCredito.Columns("nPlazo").Caption = "Plazo"
            Me.grdOtroCredito.Columns("sTipoPlazo").Caption = "Tipo Plazo"
            Me.grdOtroCredito.Columns("nMontoCuota").Caption = "Monto Cuota"
            Me.grdOtroCredito.Columns("sPeriodicidad").Caption = "Periodicidad"
            Me.grdOtroCredito.Columns("nSaldo").Caption = "Saldo"
            Me.grdOtroCredito.Columns("sOtroPrestamista").Caption = "Prestamista"
            Me.grdOtroCredito.Columns("nActivo").Caption = "Activo"

            Me.grdOtroCredito.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            'Me.grdOtroCredito.Columns("Monto").Caption = "Monto " & strSimbolo

            Me.grdOtroCredito.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdOtroCredito.Splits(0).DisplayColumns.Item("nMontoDeuda").Style.BackColor = Color.WhiteSmoke

            Me.grdOtroCredito.Splits(0).DisplayColumns("nPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sTipoPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sPeriodicidad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("nSaldo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sOtroPrestamista").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdOtroCredito.Columns("nMontoDeuda").NumberFormat = "#,##0.00"
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CalcularMontos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total para visualizarlo en el Grid de Otros Créditos.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalMonto As Double = 0

            For index As Integer = 0 To Me.grdOtroCredito.RowCount - 1
                Me.grdOtroCredito.Row = index
                vTotalMonto = vTotalMonto + Me.grdOtroCredito.Columns("nMontoDeuda").Value
                'vTotalMontoAprobado = vTotalMontoAprobado + Me.grdPresupuestoAnual.Columns("MontoAprobado").Value
            Next
            If Me.grdOtroCredito.RowCount > 0 Then
                Me.grdOtroCredito.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdOtroCredito.Columns("nMontoDeuda").FooterText = Format(vTotalMonto, "#,##0.00")
            'Me.grdPresupuestoAnual.Columns("MontoAprobado").FooterText = Format(vTotalMontoAprobado, "##,###,###,##0.00")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       tbAfectacion_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbAfectacion.
    '-------------------------------------------------------------------------

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       LlamaAgregarOC
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditOtroCredito para Agregar un nuevo crédito vigente.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarOC()
        Dim ObjFrmSclEditOtroCredito As New frmSclEditOtroCredito
        Try
            ObjFrmSclEditOtroCredito.ModoFrm = "ADD"
            ObjFrmSclEditOtroCredito.intFichaID = Me.intFichaID
            ObjFrmSclEditOtroCredito.sTipoFicha = "VERIFICACION"
            ObjFrmSclEditOtroCredito.strColor = "RojoLight"
            ObjFrmSclEditOtroCredito.ShowDialog()

            If ObjFrmSclEditOtroCredito.intOtroCreditoID <> 0 Then
                CargarOtroCredito()
                XdsDetalle("OtroCredito").SetCurrentByID("nSclOtroCreditoVigenteID", ObjFrmSclEditOtroCredito.intOtroCreditoID)
                Me.grdOtroCredito.Row = XdsDetalle("OtroCredito").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditOtroCredito.Close()
            ObjFrmSclEditOtroCredito = Nothing

        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaModificarOC
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditAfectacionDetalle para Modificar una Afectación existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarOC()
        Dim ObjFrmSclEditOtroCredito As New frmSclEditOtroCredito
        Try
            If Me.grdOtroCredito.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditOtroCredito.ModoFrm = "UPD"
            ObjFrmSclEditOtroCredito.intFichaID = Me.intFichaID
            ObjFrmSclEditOtroCredito.sTipoFicha = "VERIFICACION"
            ObjFrmSclEditOtroCredito.strColor = "RojoLight"
            ObjFrmSclEditOtroCredito.intOtroCreditoID = XdsDetalle("OtroCredito").ValueField("nSclOtroCreditoVigenteID")
            ObjFrmSclEditOtroCredito.ShowDialog()

            CargarOtroCredito()
            XdsDetalle("OtroCredito").SetCurrentByID("nSclOtroCreditoVigenteID", ObjFrmSclEditOtroCredito.intOtroCreditoID)
            Me.grdOtroCredito.Row = XdsDetalle("OtroCredito").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditOtroCredito.Close()
            ObjFrmSclEditOtroCredito = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaEliminarOC
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un crédito vigente existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarOC()
        Dim XdtOtroCredito As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdOtroCredito.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtOtroCredito.ExecuteSqlNotTable("Delete From SclOtroCreditoVigente where nSclOtroCreditoVigenteID=" & XdsDetalle("OtroCredito").ValueField("nSclOtroCreditoVigenteID"))
                CargarOtroCredito()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdOtroCredito.Caption = "Listado de Otros Créditos (" + Me.grdOtroCredito.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtOtroCredito.Close()
            XdtOtroCredito = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            MsgBox("En construcción", MsgBoxStyle.Information, "SMUSURA0")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       grdOtroCredito_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar Otro crédito existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdOtroCredito_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If blnModificar = True Then
                LlamaModificarOC()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '    'Sirve en caso que se filtren registros en la FilterBar
    Private Sub grdOtroCredito_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs)
        Try
            XdsDetalle("OtroCredito").FilterLocal(e.Condition)
            Me.grdOtroCredito.Caption = " Listado de Otros Créditos (" + Me.grdOtroCredito.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region
#Region "Detalle Referencias Crediticias"
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarReferencia
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de las Referencias Crediticias en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarReferencia()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclReferenciaCrediticiaID,a.sSiglas,a.nMontoObtenido,a.nPlazo,a.sTipoPlazo,a.dFechaSolicitud,a.dFechaCancelacion " & _
                     " From vwSclReferenciaCrediticia a " & _
                     " Where a.nSclFichaSociaID = " & Me.intFichaID

            If XdsDetalle.ExistTable("Referencia") Then
                XdsDetalle("Referencia").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Referencia")
                XdsDetalle("Referencia").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferencia.DataSource = XdsDetalle("Referencia").Source
            Me.grdReferencia.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferencia.Caption = " Listado de Referencias Crediticias (" + Me.grdReferencia.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       FormatoReferencia
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Afectaciones Presupuestarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoReferencia()
        Try
            'Configuracion del Grid 
            Me.grdReferencia.Splits(0).DisplayColumns("nSclReferenciaCrediticiaID").Visible = False

            Me.grdReferencia.Splits(0).DisplayColumns("nMontoObtenido").Width = 120
            Me.grdReferencia.Splits(0).DisplayColumns("nPlazo").Width = 50
            Me.grdReferencia.Splits(0).DisplayColumns("sTipoPlazo").Width = 80
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaSolicitud").Width = 80
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaCancelacion").Width = 80
            Me.grdReferencia.Splits(0).DisplayColumns("sSiglas").Width = 120

            Me.grdReferencia.Columns("nMontoObtenido").Caption = "Monto"
            Me.grdReferencia.Columns("nPlazo").Caption = "Plazo"
            Me.grdReferencia.Columns("sTipoPlazo").Caption = "Tipo Plazo"
            Me.grdReferencia.Columns("dFechaSolicitud").Caption = "Fecha Solicitud"
            Me.grdReferencia.Columns("dFechaCancelacion").Caption = "Fecha Cancelación"
            Me.grdReferencia.Columns("sSiglas").Caption = "Institución"

            Me.grdReferencia.Splits(0).DisplayColumns("dFechaSolicitud").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaCancelacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdReferencia.Splits(0).DisplayColumns("nMontoObtenido").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("nPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("sTipoPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaSolicitud").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("dFechaCancelacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencia.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       tbReferencia_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbReferencia.
    '-------------------------------------------------------------------------
    Private Sub tbReferencia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        Select Case e.ClickedItem.Name
            Case "toolAgregarRC"
                LlamaAgregarRC()
            Case "toolModificarRC"
                LlamaModificarRC()
            Case "toolEliminarRC"
                LlamaEliminarRC()
            Case "toolRefrescarRC"
                CargarReferencia()
            Case "toolAyudaRC"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaAgregarRC
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnDetalleDocSoporte para Agregar un Nuevo DocSoporte.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRC()
        Dim ObjFrmSclEditReferencia As New frmSclEditReferencia
        Try
            ObjFrmSclEditReferencia.ModoFrm = "ADD"
            ObjFrmSclEditReferencia.intFichaID = Me.intFichaID
            ObjFrmSclEditReferencia.strColor = "RojoLight"
            ObjFrmSclEditReferencia.ShowDialog()

            If ObjFrmSclEditReferencia.intReferenciaID <> 0 Then
                CargarReferencia()
                XdsDetalle("Referencia").SetCurrentByID("nSclReferenciaCrediticiaID", ObjFrmSclEditReferencia.intReferenciaID)
                Me.grdReferencia.Row = XdsDetalle("Referencia").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferencia.Close()
            ObjFrmSclEditReferencia = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaModificarRC
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnDetalleDocSoporte para Modificar un DocSoporte existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRC()
        Dim ObjFrmSclEditReferencia As New frmSclEditReferencia
        Try
            If Me.grdReferencia.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditReferencia.ModoFrm = "UPD"
            ObjFrmSclEditReferencia.intFichaID = Me.intFichaID
            ObjFrmSclEditReferencia.intReferenciaID = XdsDetalle("Referencia").ValueField("nSclReferenciaCrediticiaID")
            ObjFrmSclEditReferencia.strColor = "RojoLight"
            ObjFrmSclEditReferencia.ShowDialog()

            CargarReferencia()
            XdsDetalle("Referencia").SetCurrentByID("nSclReferenciaCrediticiaID", ObjFrmSclEditReferencia.intReferenciaID)
            Me.grdReferencia.Row = XdsDetalle("Referencia").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferencia.Close()
            ObjFrmSclEditReferencia = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       LlamaEliminarRC
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una Referencia Crediticia existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRC()
        Dim XdtReferencia As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdOtroCredito.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtReferencia.ExecuteSqlNotTable("Delete From SclReferenciaCrediticia where nSclReferenciaCrediticiaID=" & XdsDetalle("Referencia").ValueField("nSclReferenciaCrediticiaID"))
                CargarOtroCredito()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferencia.Caption = "Listado de Referencias Crediticias (" + Me.grdReferencia.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtReferencia.Close()
            XdtReferencia = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       grdReferencia_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Referencia Crediticia existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdReferencia_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdReferencia.DoubleClick
        Try
            If blnModificar = True Then
                LlamaModificarRC()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '    'En caso que ocurra otro Tipo de Error
    '    Private Sub grdDocSoporte_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDocSoporte.Error
    '        Control_Error(e.Exception)
    '    End Sub
    'Sirve para realizar el filtro de la condición introducida en la Barra de Filtro
    Private Sub grdReferencia_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdReferencia.Filter
        Try
            XdsDetalle("Referencia").FilterLocal(e.Condition)
            Me.grdReferencia.Caption = " Listado de Referencias Crediticias (" + Me.grdReferencia.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
#End Region

#Region "Controles Nuevos"
    Private Sub rdIII5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIII5.CheckedChanged
        txtIII.Enabled = rdIII5.Checked
        txtIII.ReadOnly = False
        If rdIII5.Checked = False Then
            txtIII.Text = ""
            txtIII.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtIII.BackColor = Color.White
        End If
    End Sub
    Private Sub rdIV11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIV11.CheckedChanged
        txtIV1.Enabled = rdIV11.Checked

        'txtIV12.Enabled = rdIV11.Checked
        ''cboIV13.Enabled = rdIV11.Checked
        'cboTipoNegocioActualRubro.Enabled = rdIV11.Checked
        'txtIV1.ReadOnly = False
        'txtIV12.ReadOnly = False





        If rdIV11.Checked = False Then
            ''cboTipoNegocioPropuesto.Enabled = True
            ''cboTipoNegocioActualRubro.Enabled = False
            ''txtIV12.Enabled = True
            ''cboIV13.Enabled = True


            txtIV1.Text = ""
            'txtIV12.Text = ""
            'cboIV13.Text = ""
            ''cboTipoNegocioActualRubro.Text = ""
            txtIV1.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            'txtIV12.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            ''cboIV13.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            'cboTipoNegocioActual.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            grdIV2.Enabled = False
            grdIV3.Enabled = False
            grdIV4.Enabled = False
            grdIV5.Enabled = False
        Else
            ''cboTipoNegocioPropuesto.Enabled = False
            ''cboTipoNegocioActualRubro.Enabled = True
            txtIV12.Enabled = True
            ''cboIV13.Enabled = True



            grdIV2.Enabled = True
            grdIV3.Enabled = True
            grdIV4.Enabled = True
            grdIV5.Enabled = True
            txtIV1.BackColor = Color.White
            'txtIV12.BackColor = Color.White
            ''cboIV13.BackColor = Color.White
            ''cboTipoNegocioActualRubro.BackColor = Color.White
        End If
    End Sub
    Private Sub rdV11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdV11.CheckedChanged
        txtV1.Enabled = rdV11.Checked
        txtV1.ReadOnly = False
        If rdV11.Checked = False Then
            txtV1.Value = 0
            txtV1.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtV1.BackColor = Color.White
        End If
    End Sub
    Private Sub rdV21_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdV21.CheckedChanged
        txtV2.Enabled = rdV21.Checked
        txtV2.ReadOnly = False
        If rdV21.Checked = False Then
            txtV2.Value = 0
            txtV2.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtV2.BackColor = Color.White
        End If
    End Sub
    Private Sub rdV31_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdV31.CheckedChanged
        txtV3.Enabled = rdV31.Checked
        txtV3.ReadOnly = False
        If rdV31.Checked = False Then
            txtV3.Value = 0
            txtV3.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtV3.BackColor = Color.White
        End If
    End Sub
    Private Sub rdVI24_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVI24.CheckedChanged
        txtVI2.Enabled = rdVI24.Checked
        txtVI2.ReadOnly = False
        If rdVI24.Checked = False Then
            txtVI2.Text = ""
            txtVI2.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtVI2.BackColor = Color.White
        End If
    End Sub
    Private Sub rdVI32_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVI32.CheckedChanged
        txtVI3.Enabled = rdVI32.Checked
        txtVI3.ReadOnly = False
        If rdVI32.Checked = False Then
            txtVI3.Value = 0
            txtVI3.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtVI3.BackColor = Color.White
        End If
    End Sub
    Private Sub rdIV51_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIV51.CheckedChanged
        txtIV51.Enabled = True
        txtIV52.Enabled = False
        txtIV53.Enabled = False
        txtIV51.BackColor = Color.White
        txtIV52.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        txtIV53.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        txtIV52.Value = 0
        txtIV53.Value = 0
    End Sub

    Private Sub rdIV52_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIV52.CheckedChanged
        txtIV51.Enabled = False
        txtIV52.Enabled = True
        txtIV53.Enabled = False
        txtIV52.BackColor = Color.White
        txtIV51.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        txtIV53.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        txtIV51.Value = 0
        txtIV53.Value = 0
    End Sub

    Private Sub rdIV53_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIV53.CheckedChanged
        txtIV51.Enabled = False
        txtIV52.Enabled = False
        txtIV53.Enabled = True
        txtIV53.BackColor = Color.White
        txtIV51.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        txtIV52.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        txtIV51.Value = 0
        txtIV52.Value = 0
    End Sub

    Private Sub rdIV12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIV12.CheckedChanged
        If rdIV12.Checked = True Then
            txtIV1.Text = ""
            ''txtIV12.Text = ""
            ''cboIV13.Text = ""
            ''txtIV12.Enabled = True
            ''cboIV13.Enabled = True

            txtIV1.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            'txtIV12.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            ''cboTipoNegocioActualRubro.BackColor = Color.FromArgb(255, 224, 224, 224)
            ''cboIV13.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            grdIV2.Enabled = False
            grdIV3.Enabled = False
            grdIV4.Enabled = False
            grdIV5.Enabled = False
        End If
    End Sub
    Private Sub rdVI01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVI01.CheckedChanged
        If rdVI01.Checked Then
            grdVI1.Enabled = True
            rdVI11.Checked = False
            rdVI12.Checked = False
            txtVI11.Text = ""
            txtVI12.Text = ""
            txtVI2.Text = ""
            txtVI11.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            txtVI12.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            grdVI1.Enabled = False
            grdVI2.Enabled = False
            rdVI11.Checked = False
            rdVI12.Checked = False
            txtVI11.Text = ""
            txtVI12.Text = ""
            rdVI21.Checked = False
            rdVI22.Checked = False
            rdVI23.Checked = False
            rdVI24.Checked = False
            txtVI2.Text = ""
        End If
    End Sub

    Private Sub rdVI12_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVI12.CheckedChanged
        grdVI2.Enabled = rdVI12.Checked
        txtVI12.Enabled = rdVI12.Checked
        txtVI12.ReadOnly = False
        If rdVI12.Checked = False Then
            txtVI12.Text = ""
            txtVI12.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtVI12.BackColor = Color.White
        End If
    End Sub

    Private Sub rdVI11_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVI11.CheckedChanged
        txtVI11.Enabled = rdVI11.Checked
        txtVI11.ReadOnly = False
        If rdVI11.Checked = False Then
            txtVI11.Text = ""
            txtVI11.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
        Else
            txtVI11.BackColor = Color.White
        End If
        rdVI21.Checked = False
        rdVI22.Checked = False
        rdVI23.Checked = False
        rdVI24.Checked = False
        txtVI2.Text = ""
        grdVI2.Enabled = False
    End Sub
#End Region

#Region "Validacion de lo nuevo"

    Private Function TodoNuevoValidado() As Boolean

        Return Negocios1Validado() And Negocios2Validado() And PercepcionMejoriaValidada()
    End Function

    Private Function Negocios1Validado() As Boolean
        'Acapite III
        Dim res As Boolean = (rdIII1.Checked Or rdIII2.Checked Or rdIII3.Checked Or rdIII4.Checked Or (rdIII5.Checked And TextBoxAceptable(txtIII)))

        Dim sql As String
        sql = "select 1 from vwSclClasificacionEconomica where nStbActividadEconomicaID=" & cboTipoNegocioActualRubro.SelectedValue
        If turismoNO.Checked Then
            sql &= " and nNVT=1 "
        ElseIf turismoSI.Checked Then
            sql &= " and nVT=1 "
        ElseIf turismoT.Checked Then
            sql &= " and nT=1 "
        End If

        Dim cmd As New BOSistema.Win.XComando
        Dim bueno As Short = 1

        If Not RegistrosAsociados(sql) Then ' Componer codigo fuente la consulta esta buena
            bueno = 0
        End If



        'Acapite IV    
        If rdIV11.Checked = True Then
            'res = res And ((rdIV11.Checked And TextBoxAceptable(txtIV1) And TextBoxAceptable(txtIV12)) Or rdIV12.Checked) _
            res = res And ((rdIV11.Checked And cboTipoNegocioActualRubro.SelectedIndex >= 0 And TextBoxAceptable(txtIV12)) Or rdIV12.Checked) _
            And (rdIV31.Checked Or rdIV32.Checked) _
            And (rdIV41.Checked Or rdIV42.Checked) _
            And ((rdIV51.Checked And CInt(txtIV51.Value) > 0) Or (rdIV52.Checked And CInt(txtIV52.Value) > 0) Or (rdIV53.Checked And CInt(txtIV53.Value > 0))) _
            And (turismoSI.Checked Or turismoNO.Checked Or turismoT.Checked) _
            And CBool(bueno)
        End If

        If Not CBool(bueno) Then
            MsgBox("Se intenta grabar una actividad que no corresponde al tipo de turismo marcado.", vbCritical, "SMUSURA0")
            Exit Function
        End If

        If res = False Then
            MsgBox("Debe llenar todos los datos de Negocios III-IV", vbCritical, "SMUSURA0")
        End If

        Return res
    End Function

    Private Function Negocios2Validado() As Boolean
        Dim res As Boolean

        'Acapite V
        res = ((rdV11.Checked And TextBoxAceptable(txtV1)) Or rdV12.Checked) _
            And ((rdV21.Checked And TextBoxAceptable(txtV2)) Or rdV22.Checked) _
            And ((rdV31.Checked And TextBoxAceptable(txtV3)) Or rdV32.Checked)


        If rdV11.Checked = True Then
            res = res And (rdVI01.Checked Or rdVI02.Checked)
            If rdVI01.Checked = True Then
                If (rdVI31.Checked Or (rdVI32.Checked And TextBoxAceptable(txtVI3))) Then
                    res = res And True
                Else
                    res = res And False
                End If
            End If
        End If

        'Acapite VI

        '            And ((rdVI11.Checked And TextBoxAceptable(txtVI11)) Or (rdVI12.Checked And TextBoxAceptable(txtVI12))) _
        '            And ((rdVI31.Checked) Or (rdVI32.Checked And TextBoxAceptable(txtVI3))) _
        '            And (TextBoxAceptable(txtVI41) And TextBoxAceptable(txtVI42) And TextBoxAceptable(txtVI43))

        'If rdVI12.Checked Then
        '    If (rdVI21.Checked Or rdVI22.Checked Or rdVI23.Checked) Or (rdVI24.Checked And TextBoxAceptable(txtVI2)) Then
        '        res = res And True
        '    Else
        '        res = res And False
        '    End If
        'End If

        If res = False Then
            MsgBox("Debe llenar todos los datos de Negocios V-VI", vbCritical, "SMUSURA0")
        End If

        Return res
    End Function

    Private Function PercepcionMejoriaValidada() As Boolean

        'Todo Acapite VII
        Dim res As Boolean = True

        If CInt(Me.txtCreditoNo.Text) = 1 Then
            Return True
        End If

        res = ((rdPM11.Checked) Or rdPM12.Checked) _
            And ((rdPM21.Checked) Or rdPM22.Checked) _
            And ((rdPM31.Checked) Or rdPM32.Checked) _
            And ((rdPM41.Checked) Or rdPM42.Checked) _
            And ((rdPM51.Checked) Or rdPM52.Checked) _
            And ((rdPM61.Checked) Or rdPM62.Checked) _
            And TextBoxAceptable(txtPMobservaciones) And cboPromotor.Text <> ""

        If res = False Then
            MsgBox("Debe llenar todos los datos del acápite VII para socias subsecuentes.", vbCritical, "SMUSURA0")
        End If

        Return res
    End Function

    Private Function TextBoxAceptable(ByRef txt As TextBox) As Boolean
        Dim i As Integer = 0
        If txt.TextLength = 0 Then
            Return False
        ElseIf txt.TextLength = 1 And txt.Text <> " " Then
            Return True
        End If
        For i = 1 To txt.TextLength - 1
            If Mid(txt.Text, i, 1) <> " " Then
                Return True
            End If
        Next
        Return False
    End Function

#End Region

    Private Function ComprobarTurismo() As Boolean
        If turismoNO.Checked = False And turismoSI.Checked = False And turismoT.Checked = False Then
            Return False
        End If
        If Turismo = 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() And TodoNuevoValidado() Then

                ''TURISMO validar que sean socias únicamente de primer crédito
                'If turismoT.Checked Then
                '    Dim objsocia As New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable
                '    Dim gruposocia As Integer = ObjFichadr.nSclGrupoSociaID
                '    objsocia.Filter = "nSclGrupoSociaID = " & gruposocia
                '    objsocia.Retrieve()
                '    Dim idsocia As Integer = objsocia.ValueField("nSclSociaID")

                '    'Hacia créditos anteriores no debería tener nada que no sea turismo
                'End If


                'Cuando agregamos un nuevo campo actualizar estas dos funciones (SclFichaSociaNegocio)
                AsignarVariablesNuevasForm()

                If Not ComprobarTurismo() Then
                    MsgBox("No se ha seleccionado correctamente una opción de actividad: No viculada a Turismo, Vinculada a Turismo y Turismo. Elija una.", vbCritical, "SMUSURA0")
                    Exit Sub
                End If

                SalvarFicha()

                Me.tabPOtrosCreditos.Enabled = True
                Me.tabPReferencia.Enabled = True

                Me.txtCodigo.Text = ObjFichadr.sCodigo
                Me.txtCodigoOC.Text = ObjFichadr.sCodigo
                Me.txtCodigoRC.Text = ObjFichadr.sCodigo

                'Estado
                ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjFichadr.nStbEstadoFichaID
                ObjEstadoDT.Retrieve()
                If ObjEstadoDT.Count > 0 Then
                    Me.txtEstado.Text = ObjEstadoDT.ValueField("sNombre")
                End If

                If Me.intFichaID <> 0 Then
                    If MsgBox("¿Desea Continuar Ingresando Datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.No Then
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    Else
                        ModoFrm = "UPD"
                        CargarOtroCredito()
                        CargarNucleoFamiliar()
                        FormatoOtroCredito()
                        CargarReferencia()
                        FormatoReferencia()
                        CargarCreditoNo()
                        CargarEstadoCivil()
                        Me.tabNucleoFamiliar.Show()
                        tbNucleoFamiliar.Enabled = True
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

    Public Sub AsignarVariablesNuevasBase() 'Leidas de la Base
        Dim FichaSociaNegocio As New BOSistema.Win.SclEntFicha.SclFichaSociaNegocioDataTable
        FichaSociaNegocio.Filter = "nSclFichaSociaID=" & ObjFichadr.nSclFichaSociaID
        FichaSociaNegocio.Retrieve()

        If FichaSociaNegocio.Count = 0 Then
            txtnMontoInventario.Value = 0
            Exit Sub
        End If

        Dim rowFichaSociaNegocio As BOSistema.Win.SclEntFicha.SclFichaSociaNegocioRow = FichaSociaNegocio.Current
        TipoActividadID = rowFichaSociaNegocio.nTipoActividad
        OtraActividad = rowFichaSociaNegocio.sOtraActividad
        TieneNegocioNuevo = rowFichaSociaNegocio.nTieneNegocio
        DescripcionNegocio = rowFichaSociaNegocio.sDescripcionNegocio
        RubroNegocio = rowFichaSociaNegocio.nStbRubroNegocioID
        CaracteristicaNegocio = rowFichaSociaNegocio.nCaracteristicaNegocio
        FuncionamientoNegocio = rowFichaSociaNegocio.nFuncionamientodelNegocio
        RegistrosVentas = rowFichaSociaNegocio.nVentaBrutaLlevaRegistro
        VentaBrutaMes = rowFichaSociaNegocio.nVentaBrutaMes
        VentaBrutaSemana = rowFichaSociaNegocio.nVentaBrutaSemana
        VentaBrutaOtro = rowFichaSociaNegocio.nVentaBrutaOtros
        TieneFinanciamientoOtraInstitucion = rowFichaSociaNegocio.nTienefinanciamientoOtraInstirucion
        FinanciamientoOtraInstitucionMonto = rowFichaSociaNegocio.nFinanciamientoOtraInstitucionMonto
        RecibeMercaderiaConsignacion = rowFichaSociaNegocio.nRecibeMercaderiaConsignacion
        RecibeMercaderiaConsignacionMonto = rowFichaSociaNegocio.nRecibeMercaderiaConsignacionMonto
        CreditosOtrasEmpresas = rowFichaSociaNegocio.nCreditosOtrasEmpresas
        CreditosOtrasEmpresasMonto = rowFichaSociaNegocio.nCreditosOtrasEmpresasMonto
        LeHaAgregadoAlNegocio = rowFichaSociaNegocio.nLehaAgregadoAlNegocio
        QueleAgregadoAlNegocio = rowFichaSociaNegocio.sQueleAgregadoAlNegocio
        OtrosProductosServicios = rowFichaSociaNegocio.nOtrosProductosServicios
        LoCambio = rowFichaSociaNegocio.nLoCambio
        DescripcionOtrosProductosServicios = rowFichaSociaNegocio.sDescripcionOtrosProductosServicios
        DescripcionCambio = rowFichaSociaNegocio.sDescripcionCambio
        CausasDelCambio = rowFichaSociaNegocio.nCausasDelCambio
        DescripcionCausasDelCambioOtro = rowFichaSociaNegocio.sDescripcionCausasDelCambioOtro
        CuantasPersonasTrabajan = rowFichaSociaNegocio.nCuantasPersonasTrabajan
        DescripcionCambiosEquipo = rowFichaSociaNegocio.sDescripcionCambiosEquipo
        DescripcionCambiosInfraestructura = rowFichaSociaNegocio.sDescripcionCambiosInfraestructura
        DescripcionCambiosMuebles = rowFichaSociaNegocio.sDescripcionCambiosMuebles
        MejoriaPercibidaAlimentacion = rowFichaSociaNegocio.nMejoriaPercibidaAlimentacion
        MejoriaPercibidaEquiposElectronicos = rowFichaSociaNegocio.nMejoriaPercibidaEquiposElectronicos
        MejoriaPercibidaCasa = rowFichaSociaNegocio.nMejoriaPercibidaCasa
        MejoriaPercibidaMuebles = rowFichaSociaNegocio.nMejoriaPercibidaMuebles
        MejoriaPercibidaEstudios = rowFichaSociaNegocio.nMejoriaPercibidaEstudios
        MejoriaPercibidaConocimientoAutoEstima = rowFichaSociaNegocio.nMejoriaPercibidaConocimientoAutoEstima
        Observaciones = rowFichaSociaNegocio.sObservaciones
        Meta = rowFichaSociaNegocio.sMeta
        Promotor = rowFichaSociaNegocio.nSrhEmpleadoPromotorID
        txtnMontoInventario.Value = rowFichaSociaNegocio.nMontoInventario

        'Turismo = rowFichaSociaNegocio.nTipoTurismo '(No existe)

        Dim cmd As New BOSistema.Win.XComando
        Dim tTurismo As Integer
        tTurismo = cmd.ExecuteScalar("select nTipoTurismo from SclFichaSociaNegocio where nSclFichaSociaID=" & ObjFichadr.nSclFichaSociaID)
        Turismo = tTurismo

    End Sub

    Private Sub AsignarUniversidadSocia()
        Dim sociaID As Integer = XdsFicha("Socia").ValueField("nSclSociaID")
        Dim strSQL As String
        strSQL = "select * from vwStbUniversidadSocia where nSclSociaID=" & sociaID

        If XdsFicha.ExistTable("UniversidadSocia") Then
            XdsFicha("UniversidadSocia").ExecuteSql(strSQL)
        Else
            XdsFicha.NewTable(strSQL, "UniversidadSocia")
            XdsFicha("UniversidadSocia").Retrieve()
        End If

        If IsDBNull(XdsFicha("UniversidadSocia").ValueField("nSclSociaID")) Or XdsFicha("UniversidadSocia").ValueField("nSclSociaID") Is Nothing Then
            cboUniversidad.SelectedIndex = 0
        Else
            cboUniversidad.SelectedValue = CInt(XdsFicha("UniversidadSocia").ValueField("nStbValorCatalogoID"))
        End If

    End Sub

    Private Sub CargarControlesNuevos()
        Dim FichaSociaNegocio As New BOSistema.Win.SclEntFicha.SclFichaSociaNegocioDataTable
        FichaSociaNegocio.Filter = "nSclFichaSociaID=" & ObjFichadr.nSclFichaSociaID
        FichaSociaNegocio.Retrieve()

        AsignarUniversidadSocia()

        If FichaSociaNegocio.Count = 0 Then
            Exit Sub
        End If



        'TipoActividad
        If TipoActividadID = 1 Then
            rdIII1.Checked = True
        ElseIf TipoActividadID = 2 Then
            rdIII2.Checked = True
        ElseIf TipoActividadID = 3 Then
            rdIII3.Checked = True
        ElseIf TipoActividadID = 4 Then
            rdIII4.Checked = True
        ElseIf TipoActividadID = 5 Then
            rdIII5.Checked = True
        End If
        'OtraActividad
        txtIII.Text = OtraActividad
        'TieneNegocioNuevo
        If TieneNegocioNuevo = 1 Then
            rdIV11.Checked = True
        ElseIf TieneNegocioNuevo = 0 Then
            rdIV12.Checked = True
        End If
        'DescripcionNegocio
        txtIV1.Text = DescripcionNegocio
        'CaracteristicasDelNegocio
        If CaracteristicaNegocio = 1 Then
            rdIV21.Checked = True
        ElseIf CaracteristicaNegocio = 2 Then
            rdIV22.Checked = True
        End If
        'RubroNegocio
        'cboIV13.SelectedValue = RubroNegocio
        'FuncionamientoDelNegocio
        If FuncionamientoNegocio = 1 Then
            rdIV31.Checked = True
        ElseIf FuncionamientoNegocio = 2 Then
            rdIV32.Checked = True
        End If
        'Turismo
        If Turismo = 0 Then
        ElseIf Turismo = 1 Then
            turismoNO.Checked = True
        ElseIf Turismo = 2 Then
            turismoSI.Checked = True
        ElseIf Turismo = 3 Then
            turismoT.Checked = True
        End If
        'RegistroVentas
        If RegistrosVentas = 1 Then
            rdIV41.Checked = True
        ElseIf RegistrosVentas = 0 Then
            rdIV42.Checked = True
        End If
        'MontoVentasButas
        txtIV51.Value = VentaBrutaMes
        txtIV52.Value = VentaBrutaSemana
        txtIV53.Value = VentaBrutaOtro
        If txtIV51.Value > 0 Then
            rdIV51.Checked = True
        ElseIf txtIV52.Value > 0 Then
            rdIV52.Checked = True
        ElseIf txtIV53.Value > 0 Then
            rdIV53.Checked = True
        End If
        'TieneFinanciamientosNegocio
        If TieneFinanciamientoOtraInstitucion = 1 Then
            rdV11.Checked = True
        ElseIf TieneFinanciamientoOtraInstitucion = 0 Then
            rdV12.Checked = True
        End If
        'FinanciamientoOtraInstitucionMonto
        txtV1.Value = FinanciamientoOtraInstitucionMonto
        'RecibeMercaderiaConsignacion
        If RecibeMercaderiaConsignacion = 1 Then
            rdV21.Checked = True
        ElseIf RecibeMercaderiaConsignacion = 0 Then
            rdV22.Checked = True
        End If
        'RecibeMercaderiaConsignacionMonto
        txtV2.Value = RecibeMercaderiaConsignacionMonto
        'CréditosOtrasEmpresas
        If CreditosOtrasEmpresas = 1 Then
            rdV31.Checked = True
        ElseIf CreditosOtrasEmpresas = 0 Then
            rdV32.Checked = True
        End If
        'CreditosOtrasEmpresasMonto
        txtV3.Value = CreditosOtrasEmpresasMonto
        'Le ha agregado al negocio
        If LeHaAgregadoAlNegocio = 0 Then
            rdVI01.Checked = True
            rdVI02.Checked = True
        Else
            rdVI02.Checked = True
            rdVI01.Checked = True
        End If
        'QueleAgregadoAlNegocio
        QueleAgregadoAlNegocio = "'N/A'"
        'OtrosProductosServicios
        If OtrosProductosServicios = 1 Then
            rdVI11.Checked = True
        End If
        'Locambio
        If LoCambio = 1 Then
            rdVI12.Checked = True
        End If
        'DescripcionOtrosProductos
        txtVI11.Text = DescripcionOtrosProductosServicios
        'DescripcionLoCambio
        txtVI12.Text = DescripcionCambio
        'CausasDelCambio
        If CausasDelCambio = 1 Then
            rdVI21.Checked = True
        ElseIf CausasDelCambio = 2 Then
            rdVI22.Checked = True
        ElseIf CausasDelCambio = 3 Then
            rdVI23.Checked = True
        ElseIf CausasDelCambio = 4 Then
            rdVI24.Checked = True
        End If
        'DescripcionCausasDelCambioOtro (Texto)
        txtVI2.Text = DescripcionCausasDelCambioOtro
        'CuantasPersonaTrabajan
        If CuantasPersonasTrabajan > 0 Then
            rdVI32.Checked = True
        Else
            rdVI31.Checked = True
        End If
        txtVI3.Value = CuantasPersonasTrabajan
        'DescripcionCambiosEquipo, Infraestructura y Muebles (Textos)
        txtVI41.Text = DescripcionCambiosEquipo
        txtVI42.Text = DescripcionCambiosInfraestructura
        txtVI43.Text = DescripcionCambiosMuebles
        'MejoriaPercepcionAlimentacion
        If MejoriaPercibidaAlimentacion = 1 Then
            rdPM11.Checked = True
        ElseIf MejoriaPercibidaAlimentacion = 0 Then
            rdPM12.Checked = True
        End If


        'MejoriaPercibidaEquiposElectronicos (0,1)
        If MejoriaPercibidaEquiposElectronicos = 1 Then
            rdPM21.Checked = True
        ElseIf MejoriaPercibidaEquiposElectronicos = 0 Then
            rdPM22.Checked = True
        End If
        'MejoriaPercibidaCasa (0,1)
        If MejoriaPercibidaCasa = 1 Then
            rdPM31.Checked = True
        ElseIf MejoriaPercibidaCasa = 0 Then
            rdPM32.Checked = True
        End If




        'MejoriaPercibidaMuebles (0,1)
        If MejoriaPercibidaMuebles = 1 Then
            rdPM41.Checked = True
        ElseIf MejoriaPercibidaMuebles = 0 Then
            rdPM42.Checked = True
        End If
        'MejoriaPercibidaEstudios (0,1)
        If MejoriaPercibidaEstudios = 1 Then
            rdPM51.Checked = True
        ElseIf MejoriaPercibidaEstudios = 0 Then
            rdPM52.Checked = True
        End If
        'MejoriaPercibidaConocimientoAutoEstima (0,1)
        If MejoriaPercibidaConocimientoAutoEstima = 1 Then
            rdPM61.Checked = True
        ElseIf MejoriaPercibidaConocimientoAutoEstima = 0 Then
            rdPM62.Checked = True
        End If
        'Observaciones (Texto)
        txtPMobservaciones.Text = Observaciones
        'Meta (Texto Value)
        txtMetaProsperidad.Text = Meta
        cboPromotor.SelectedValue = Promotor


    End Sub

    Public Sub AsignarVariablesNuevasForm() 'Leidas del Formulario
        'EstadoCivil (1-5)
        EstadoCivilID = ExtraerEstadoCivilID()
        'TipoActividadSocia (1-5)
        If rdIII1.Checked Then
            TipoActividadID = 1
        ElseIf rdIII2.Checked Then
            TipoActividadID = 2
        ElseIf rdIII3.Checked Then
            TipoActividadID = 3
        ElseIf rdIII4.Checked Then
            TipoActividadID = 4
        ElseIf rdIII5.Checked Then
            TipoActividadID = 5
        Else
            TipoActividadID = 0
        End If
        'OtraActividad (Texto)
        OtraActividad = "'" & txtIII.Text & "'"
        'TieneNegocioNuevo (0,1)
        If rdIV11.Checked Then
            TieneNegocioNuevo = 1
        ElseIf rdIV12.Checked Then
            TieneNegocioNuevo = 0
        Else
            TieneNegocioNuevo = 2
        End If
        'DescripcioNegocio (Texto)
        DescripcionNegocio = "'" & txtIV1.Text & "'"
        'RubroNegocio
        If cboIV13.Text = "" Then
            RubroNegocio = 401
        Else
            RubroNegocio = cboIV13.SelectedValue
        End If
        'Turismo
        If turismoNO.Checked Then
            Turismo = 1
        ElseIf turismoSI.Checked Then
            Turismo = 2
        ElseIf turismoT.Checked Then
            Turismo = 3
        Else
            Turismo = 1
        End If
        'Caracteristicas del negocio (1,2)
        If rdIV21.Checked Then
            CaracteristicaNegocio = 1
        ElseIf rdIV22.Checked Then
            CaracteristicaNegocio = 2
        Else
            CaracteristicaNegocio = 3
        End If
        'FuncionamientoNegocio (1,2)
        If rdIV31.Checked Then
            FuncionamientoNegocio = 1
        ElseIf rdIV32.Checked Then
            FuncionamientoNegocio = 2
        Else
            FuncionamientoNegocio = 3
        End If
        'RegistroVentas (0,1)
        If rdIV41.Checked Then
            RegistrosVentas = 1
        ElseIf rdIV42.Checked Then
            RegistrosVentas = 0
        Else
            RegistrosVentas = 2
        End If
        'MontosVentasBrutas
        VentaBrutaMes = txtIV51.Value
        VentaBrutaSemana = txtIV52.Value
        VentaBrutaOtro = txtIV53.Value
        'TieneFinanciamientoOtraInstitucion (0,1)
        If rdV11.Checked Then
            TieneFinanciamientoOtraInstitucion = 1
        ElseIf rdV12.Checked Then
            TieneFinanciamientoOtraInstitucion = 0
        Else
            TieneFinanciamientoOtraInstitucion = 2
        End If
        'FinanciamientoOtraInstitucionMonto (Valor Moneda)
        FinanciamientoOtraInstitucionMonto = txtV1.Value
        'RecibeMercaderiaConsignacion (0,1)
        If rdV21.Checked Then
            RecibeMercaderiaConsignacion = 1
        ElseIf rdV22.Checked Then
            RecibeMercaderiaConsignacion = 0
        Else
            RecibeMercaderiaConsignacion = 2
        End If
        'RecibeMercaderiaConsignacionMonto (Valor Moneda)
        RecibeMercaderiaConsignacionMonto = txtV2.Value
        'CreditosOtrasEmpresas (0,1)
        If rdV31.Checked Then
            CreditosOtrasEmpresas = 1
        ElseIf rdV32.Checked Then
            CreditosOtrasEmpresas = 0
        Else
            CreditosOtrasEmpresas = 2
        End If
        'CreditosOtrasEmpresasMonto (Valor Moneda)
        CreditosOtrasEmpresasMonto = txtV3.Value
        'Le ha agregado al negocio
        If rdVI01.Checked Then
            LeHaAgregadoAlNegocio = 1
        ElseIf rdVI02.Checked Then
            LeHaAgregadoAlNegocio = 0
        Else
            LeHaAgregadoAlNegocio = 2
        End If
        'QueleAgregadoAlNegocio (Vacio)
        QueleAgregadoAlNegocio = "'N/A'"
        If rdVI11.Checked Then
            'OtrosProductosServicios (0,1)
            OtrosProductosServicios = 1
        Else
            OtrosProductosServicios = 0
        End If
        If rdVI12.Checked Then
            'LoCambio (0,1)
            LoCambio = 1
        Else
            LoCambio = 0
        End If
        'Descripciones de QuelehaAgregado
        'DescripcionOtrosProductosServicios (Texto)
        DescripcionOtrosProductosServicios = "'" & txtVI11.Text & "'"
        'DescripcionCambio (Texto)
        DescripcionCambio = "'" & txtVI12.Text & "'"
        'CausasDelCambio (1-4)
        If rdVI21.Checked Then
            CausasDelCambio = 1
        ElseIf rdVI22.Checked Then
            CausasDelCambio = 2
        ElseIf rdVI23.Checked Then
            CausasDelCambio = 3
        ElseIf rdVI24.Checked Then
            CausasDelCambio = 4
        Else
            CausasDelCambio = 0
        End If
        'DescripcionCausasDelCambioOtro (Texto)
        DescripcionCausasDelCambioOtro = "'" & txtVI2.Text & "'"
        'CuantasPersonasTrabajan (=0:Solo ella; >0:Cantidad)
        CuantasPersonasTrabajan = txtVI3.Value
        'DescripcionCambiosEquipo, Infraestructura y Muebles (Textos)
        DescripcionCambiosEquipo = "'" & txtVI41.Text & "'"
        DescripcionCambiosInfraestructura = "'" & txtVI42.Text & "'"
        DescripcionCambiosMuebles = "'" & txtVI43.Text & "'"
        'MejoriaPercibidaAlimentacion (0,1)
        If rdPM11.Checked Then
            MejoriaPercibidaAlimentacion = 1
        ElseIf rdPM12.Checked Then
            MejoriaPercibidaAlimentacion = 0
        Else
            MejoriaPercibidaAlimentacion = 2
        End If
        'MejoriaPercibidaEquiposElectronicos (0,1)
        If rdPM21.Checked Then
            MejoriaPercibidaEquiposElectronicos = 1
        ElseIf rdPM22.Checked Then
            MejoriaPercibidaEquiposElectronicos = 0
        Else
            MejoriaPercibidaEquiposElectronicos = 2
        End If
        'MejoriaPercibidaCasa (0,1)
        If rdPM31.Checked Then
            MejoriaPercibidaCasa = 1
        ElseIf rdPM32.Checked Then
            MejoriaPercibidaCasa = 0
        Else
            MejoriaPercibidaCasa = 2
        End If
        'MejoriaPercibidaMuebles (0,1)
        If rdPM41.Checked Then
            MejoriaPercibidaMuebles = 1
        ElseIf rdPM42.Checked Then
            MejoriaPercibidaMuebles = 0
        Else
            MejoriaPercibidaMuebles = 2
        End If
        'MejoriaPercibidaEstudios (0,1)
        If rdPM51.Checked Then
            MejoriaPercibidaEstudios = 1
        ElseIf rdPM52.Checked Then
            MejoriaPercibidaEstudios = 0
        Else
            MejoriaPercibidaEstudios = 2
        End If
        'MejoriaPercibidaConocimientoAutoEstima (0,1)
        If rdPM61.Checked Then
            MejoriaPercibidaConocimientoAutoEstima = 1
        ElseIf rdPM62.Checked Then
            MejoriaPercibidaConocimientoAutoEstima = 0
        Else
            MejoriaPercibidaConocimientoAutoEstima = 2
        End If
        'Observaciones (Texto)
        Observaciones = "'" & txtPMobservaciones.Text & "'"
        'Meta (Texto Value)
        Meta = "'" & txtMetaProsperidad.Text & "'"
        Promotor = CInt(cboPromotor.SelectedValue)
    End Sub

    Private Sub CargarPromotor()
        Try
            Dim Strsql As String = ""

            Strsql = "SELECT dbo.SrhEmpleado.nSrhEmpleadoID as Codigo,(dbo.StbPersona.sNombre1+' '+dbo.StbPersona.sNombre2+' '+dbo.StbPersona.sApellido1RS+' '+dbo.StbPersona.sApellido2) as Nombre " _
                         & " FROM dbo.SrhEmpleado INNER JOIN dbo.StbPersona " _
                         & " ON dbo.SrhEmpleado.nStbPersonaID = dbo.StbPersona.nStbPersonaID " _
                         & " ORDER BY Nombre"

            XdtPromotor.ExecuteSql(Strsql)
            Me.cboPromotor.DataSource = XdtPromotor.Source

            'Me.cboPromotor.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = True
            Me.cboPromotor.Splits(0).DisplayColumns("Codigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboPromotor.Splits(0).DisplayColumns(0).Width = 50
            Me.cboPromotor.Splits(0).DisplayColumns("Nombre").Width = 350
            Me.cboPromotor.AutoSize = True

            Me.cboPromotor.Columns("Codigo").Caption = "Código"


            Me.cboPromotor.Splits(0).DisplayColumns("Codigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboPromotor.Splits(0).DisplayColumns("Nombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboPromotor.DisplayMember = "Nombre"
            Me.cboPromotor.ValueMember = "Codigo"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Public Sub LlamaAgregarFamiliar()
        Dim v As New frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar
        Try
            v.ModoForm = "ADD"
            v.intFichaID = Me.intFichaID
            v.strColor = "RojoLight"
            v.ShowDialog()
            LlamaRefrescarNucleoFamiliar()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            v.Close()
            v = Nothing
        End Try
    End Sub
    Public Sub LlamaModificarFamiliar()
        Dim v As New frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar
        Try
            If Me.grdNucleoFamiliar.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            v.ModoForm = "UPD"
            v.intFichaID = Me.intFichaID
            v.intFichaSociaFamiliaresID = XdsNFam("NucleoFamiliar").ValueField("Codigo")
            v.strColor = "RojoLight"

            XdsNFam("NucleoFamiliar").SetCurrentByID("Codigo", v.intFichaSociaFamiliaresID)
            Me.grdNucleoFamiliar.Row = XdsNFam("NucleoFamiliar").BindingSource.Position
            v.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            LlamaRefrescarNucleoFamiliar()
            v.Close()
            v = Nothing
        End Try
    End Sub
    Public Sub LlamaEliminarFamiliar() 'Editar esto
        Dim cmd As New BOSistema.Win.XComando
        Try
            If Me.grdNucleoFamiliar.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
                Dim strsql As String = "Delete From SclFichaSociaFamiliares where nSclFichaSociaFamiliaresID=" & XdsNFam("NucleoFamiliar").ValueField("Codigo")
                cmd.ExecuteNonQuery(strsql)
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
            End If

            LlamaRefrescarNucleoFamiliar()
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            cmd.Close()
            cmd = Nothing
        End Try
    End Sub
    Public Sub LlamaRefrescarNucleoFamiliar() 'Editar esto
        CargarNucleoFamiliar()
    End Sub

    Public Sub CargarNucleoFamiliar()
        Try
            Dim Strsql As String

            Strsql = "SELECT nSclFichaSociaFamiliaresID as Codigo, " & _
                    "(sNombre1+' '+ " & _
                    "sNombre2+' '+ " & _
                    "sApellido1+' '+ " & _
                    "sApellido2) as [Nombre Completo], " & _
                    "sNumeroCedula as Cedula, " & _
                    "StbValorCatalogo.sDescripcion as Parentesco " & _
                    "FROM SclFichaSociaFamiliares  " & _
                    "INNER JOIN StbValorCatalogo " & _
                    "ON nStbParentescoID=StbValorCatalogo.nStbValorCatalogoID " & _
                    "WHERE nSclFichaSociaNegocioID = " & _
                    "(SELECT nSclFichaSociaNegocioID FROM SclFichaSociaNegocio WHERE SclFichaSociaNegocio.nSclFichaSociaID=" & Me.intFichaID & ")"

            If XdsNFam.ExistTable("NucleoFamiliar") Then
                XdsNFam("NucleoFamiliar").ExecuteSql(Strsql)
            Else
                XdsNFam.NewTable(Strsql, "NucleoFamiliar")
                XdsNFam("NucleoFamiliar").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdNucleoFamiliar.DataSource = XdsNFam("NucleoFamiliar").Source
            Me.grdNucleoFamiliar.FetchRowStyles = True

            'Actualizando el caption de los GRIDS
            Me.grdNucleoFamiliar.Caption = " Listado de los familiares (" + Me.grdNucleoFamiliar.RowCount.ToString + " registros)"

            Dim FichaSociaNegocio As New BOSistema.Win.SclEntFicha.SclFichaSociaNegocioDataTable
            FichaSociaNegocio.Filter = "nSclFichaSociaID=" & ObjFichadr.nSclFichaSociaID
            FichaSociaNegocio.Retrieve()

            If FichaSociaNegocio.ValueField("nSclFichaSociaNegocioID") <> Nothing And CInt(FichaSociaNegocio.ValueField("nSclFichaSociaNegocioID")) <> 0 Then
                If blnModificar Then
                    tbNucleoFamiliar.Enabled = True
                End If

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdNucleoFamiliar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdNucleoFamiliar.DoubleClick
        Try
            'If blnModificar = True Then
            LlamaModificarFamiliar()
            'End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarRubro()
        Try
            Dim Strsql As String = ""

            'Strsql = "SELECT     nStbValorCatalogoID, sCodigoInterno as Codigo, sDescripcion as Descripcion " & _
            '        "FROM         dbo.StbValorCatalogo " & _
            '        "WHERE     nStbCatalogoID = 39"

            If cboTipoNegocioActualRubro.SelectedIndex = -1 Then
                Strsql = "SELECT * " & _
                         "FROM vwSclClasificacionEconomica AS a " & _
                         "where a.nStbActividadEconomicaID=0"
            Else
                Strsql = "SELECT * " & _
                         "FROM vwSclClasificacionEconomica AS a " & _
                         "where a.nActiva=1 AND a.nStbActividadEconomicaID=" & cboTipoNegocioActualRubro.SelectedValue
            End If


            XdtRubro.ExecuteSql(Strsql)
            Me.cboIV13.DataSource = XdtRubro.Source

            Dim i As Integer
            For i = 0 To Me.cboIV13.Splits(0).DisplayColumns.Count - 1
                Me.cboIV13.Splits(0).DisplayColumns(i).Visible = False
            Next

            Me.cboIV13.Splits(0).DisplayColumns("CodigoClase").Visible = True
            Me.cboIV13.Splits(0).DisplayColumns("ClaseActividad").Visible = True


            Me.cboIV13.Splits(0).DisplayColumns("CodigoClase").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboIV13.Splits(0).DisplayColumns("CodigoClase").Width = 47
            Me.cboIV13.Splits(0).DisplayColumns("ClaseActividad").Width = 100

            Me.cboIV13.Columns("CodigoClase").Caption = "Código"
            Me.cboIV13.Columns("ClaseActividad").Caption = "Descripción"

            Me.cboIV13.Splits(0).DisplayColumns("CodigoClase").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboIV13.Splits(0).DisplayColumns("ClaseActividad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboIV13.DisplayMember = "Descripción"
            Me.cboIV13.ValueMember = "nStbTipoActividadEconomicaID"

            If XdtRubro.Count > 0 Then
                cboIV13.SelectedIndex = 0
                txtIV1.Text = cboIV13.Text
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Declaracion de Variables 
            Dim res As Object
            Dim strSQL As String

            strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoFicha' "

            If (vbModifico = True) And (ObjFichadr.nStbEstadoFichaID = XcDatos.ExecuteScalar(strSQL)) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
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

    Private Sub tbReferencia_ItemClicked_2(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferencia.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarRC"
                LlamaAgregarRC()
            Case "toolModificarRC"
                LlamaModificarRC()
            Case "toolEliminarRC"
                LlamaEliminarRC()
            Case "toolRefrescarRC"
                CargarReferencia()
            Case "toolAyudaRC"
                LlamaAyuda()
        End Select
    End Sub

    Private Sub rdVI02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdVI02.CheckedChanged
        Call rdVI01_CheckedChanged(sender, e)
    End Sub

    Private Sub tbOtrosCreditos_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbOtrosCreditos.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarOC"
                LlamaAgregarOC()
            Case "toolModificarOC"
                LlamaModificarOC()
            Case "toolEliminarOC"
                LlamaEliminarOC()
            Case "toolRefrescarOC"
                CargarOtroCredito()
            Case "toolAyudaOC"
                LlamaAyuda()
        End Select
    End Sub

    Private Sub tbNucleoFamiliar_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbNucleoFamiliar.ItemClicked
        Select Case e.ClickedItem.Name
            Case "btnAgregar"
                LlamaAgregarFamiliar()
            Case "btnEditar"
                LlamaModificarFamiliar()
            Case "btnEliminar"
                LlamaEliminarFamiliar()
            Case "btnRefrescar"
                LlamaRefrescarNucleoFamiliar()
        End Select
    End Sub

    Private Sub rdIV21_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdIV21.CheckedChanged

    End Sub

    Private Sub cboTipoNegocioActualRubro_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTipoNegocioActualRubro.SelectedValueChanged
        CargarRubro()
    End Sub

End Class