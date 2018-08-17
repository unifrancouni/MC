' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditFichaInscripcion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de una Ficha de Inscripción.
'-------------------------------------------------------------------------

Public Class frmSclEditFichaInscripcion

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intFichaID As Integer
    Dim blnModificar As Boolean = True


    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjFichadt As BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
    Dim ObjFichadr As BOSistema.Win.SclEntFicha.SclFichaSociaRow


    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton = AccionBoton.BotonNinguno
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
    Public Property intSclFichaID() As Integer
        Get
            intSclFichaID = intFichaID
        End Get
        Set(ByVal value As Integer)
            intFichaID = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclEditFichaInscripcion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFichaInscripcion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditFichaInscripcion_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de la Ficha en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFichaInscripcion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento(0)
            CargarPrimaria()
            CargarSecundaria()
            CargarCarreraTecnica(0)
            CargarTipoPlazo()
            CargarTipoNegocioActual(0)
            CargarTipoNegocioPropuesto(0)
            CargarTipoVenta()

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
                CargarGarantiaFiduciaria()
                FormatoGarantiaFiduciaria()
                CargarGarantiaPrendaria()
                FormatoGarantiaPrendaria()

                CargarReferenciaPersonal()
                CargarReferenciaBancaria()
                CargarReferenciaComercial()



            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            Me.cdeFechaInscripcion.Select()

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
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoFicha' "

            If ObjFichadr.nStbEstadoFichaID <> XcDatos.ExecuteScalar(Strsql) Then
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
            Me.tbGarantiaFiduciaria.Enabled = False
            Me.tbGarantiaPrendaria.Enabled = False
            Me.cboDepartamento.Enabled = False
            Me.cboMunicipio.Enabled = False
            Me.cboBarrio.Enabled = False
            Me.cboGrupo.Enabled = False
            Me.cboSocia.Enabled = False
            Me.cdeFechaInscripcion.Enabled = False
            Me.cneMontoSolicitado.Enabled = False
            Me.cboTipoNegocioActual.Enabled = False
            Me.cboTipoNegocioPropuesto.Enabled = False
            Me.cboTipoPlazo.Enabled = False
            Me.cboTipoPromedioVentas.Enabled = False
            Me.cdeFechaApertura.Enabled = False
            Me.cdeFechaInscripcion.Enabled = False
            Me.txtOtrosEstudios.Enabled = False
            Me.txtDireccionNegocio.Enabled = False
            Me.radSiTieneNegocio.Enabled = False
            Me.radNoTieneNegocio.Enabled = False
            Me.cnePromedioVentas.Enabled = False
            Me.cboDistrito.Enabled = False
            Me.txtPlazo.Enabled = False
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
                Me.Text = "Agregar Ficha de Inscripción"
                Me.tabPReferencia.Enabled = False
                Me.tabPOtrosCreditos.Enabled = False
                Me.tabPGarantia.Enabled = False

                Me.tbGarantiaPrendaria.Enabled = False
                btnDatosFinanciero.Enabled = False
                tbReferenciasPersonales.Enabled = False
                tbReferenciasBancarias.Enabled = False
                Me.grdReferenciaComerciales.Enabled = False


            Else
                Me.Text = "Modificar Ficha de Inscripción"
                Me.tabPOtrosCreditos.Enabled = True
                Me.tabPReferencia.Enabled = True
                Me.tabPGarantia.Enabled = True
                Me.tbGarantiaPrendaria.Enabled = True
                btnDatosFinanciero.Enabled = True
                tbReferenciasPersonales.Enabled = True
                tbReferenciasBancarias.Enabled = True
                Me.grdReferenciaComerciales.Enabled = True
            End If

            ObjFichadt = New BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
            ObjFichadr = New BOSistema.Win.SclEntFicha.SclFichaSociaRow
            XdsDetalle = New BOSistema.Win.XDataSet
            XdsFicha = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboTipoNegocioActual.ClearFields()
            Me.cboTipoNegocioPropuesto.ClearFields()
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboBarrio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboGrupo.ClearFields()
            Me.cboSocia.ClearFields()
            Me.grdReferencia.ClearFields()
            Me.grdOtroCredito.ClearFields()
            Me.grdGarantiaFiduciaria.ClearFields()
            Me.grdGarantiaPrendaria.ClearFields()
            Me.cboTipoPlazo.ClearFields()
            Me.cboTipoPromedioVentas.ClearFields()

            Me.tabFicha.SelectedIndex = 0

            'Me.cdeFechaInscripcion.Value = Me.cdeFechaInscripcion.ValueIsDbNull 'ModSMUSURA0.FechaServer
            Me.cneMontoSolicitado.Value = 0
            Me.txtPlazo.Text = 0
            Me.cnePromedioVentas.Value = 0

            Me.txtNumHijosDependientes.Enabled = False
            Me.cboMercado.Enabled = False
            Me.txtNumHijosVivos.Enabled = False
            Me.txtOtrosEstudios.Enabled = False
            Me.cboPrimaria.Enabled = False
            Me.cboSecundaria.Enabled = False
            Me.cboCarreraTecnica.Enabled = False
            Me.txtDireccion.Enabled = False
            Me.txtTelefono.Enabled = False
            Me.txtNumCedula.Enabled = False
            Me.txtEdad.Enabled = False
            Me.chkAlfabetizada.Enabled = False
            Me.cboTipoPlazo.Enabled = False

            Me.radSiTieneNegocio.Checked = True
            Me.cboTipoNegocioActual.Enabled = True
            Me.cboTipoNegocioPropuesto.Enabled = False

            XdtValorParametro.Filter = "nStbParametroID = 4"
            XdtValorParametro.Retrieve()

            strFecha = Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 1, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 3, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 5, 4)

            dFechaInicioPrograma = CDate(strFecha)
            Me.cdeFechaInscripcion.Calendar.MinDate = CDate(strFecha)
            Me.cdeFechaInscripcion.Calendar.MaxDate = FechaServer()


            If ModoFrm = "ADD" Then

                ObjFichadr = ObjFichadt.NewRow

                'Inicializar los Length de los campos
                Me.txtOtrosEstudios.MaxLength = ObjFichadr.GetColumnLenght("sOtrosEstudios")
                Me.txtDireccionNegocio.MaxLength = ObjFichadr.GetColumnLenght("sDireccionNegocio")
                Me.txtDireccion.MaxLength = ObjFichadr.GetColumnLenght("sDireccionSocia")

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
                Me.txtCodigoGC.Text = ObjFichadr.sCodigo
                Me.txtCodigoRB.Text = ObjFichadr.sCodigo
            Else
                Me.txtCodigo.Text = ""
                Me.txtCodigoOC.Text = ""
                Me.txtCodigoRC.Text = ""
                Me.txtCodigoGC.Text = ""
            End If

            'Estado
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjFichadr.nStbEstadoFichaID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoOC.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoRC.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoGC.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoRB.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            'Fecha de Inscripción 
            If Not ObjFichadr.IsFieldNull("dFechaInscripcion") Then
                Me.cdeFechaInscripcion.Value = ObjFichadr.dFechaInscripcion
            Else
                Me.cdeFechaInscripcion.Value = Me.cdeFechaInscripcion.ValueIsDbNull
            End If

            'Fecha de Apertura Negocio
            If Not ObjFichadr.IsFieldNull("dFechaAperturaNegocio") Then
                Me.cdeFechaApertura.Value = ObjFichadr.dFechaAperturaNegocio
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

                        If Not ObjUbicacionDT.ValueField("nStbDistritoID") Is DBNull.Value Then
                            CargarDistrito(0, ObjUbicacionDT.ValueField("nStbDistritoID"))
                            If Me.cboDistrito.ListCount > 0 Then
                                Me.cboDistrito.SelectedIndex = 0
                                XdsFicha("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))
                            End If
                        End If

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

                                If Not ObjFichadr.IsFieldNull("nSclGrupoSociaID") Then
                                    CargarSocia(0, ObjFichadr.nSclGrupoSociaID)
                                    If Me.cboSocia.ListCount > 0 Then
                                        Me.cboSocia.SelectedIndex = 0
                                        XdsFicha("Socia").SetCurrentByID("nSclGrupoSociaID", ObjFichadr.nSclGrupoSociaID)
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If

            'Dirección Socia
            If Not ObjFichadr.IsFieldNull("sDireccionSocia") Then
                Me.txtDireccion.Text = ObjFichadr.sDireccionSocia
            Else
                Me.txtDireccion.Text = ""
            End If

            'Dirección Negocio
            If Not ObjFichadr.IsFieldNull("sDireccionNegocio") Then
                Me.txtDireccionNegocio.Text = ObjFichadr.sDireccionNegocio
            Else
                Me.txtDireccionNegocio.Text = ""
            End If

            'Telefono
            If Not ObjFichadr.IsFieldNull("sTelefonoSocia") Then
                Me.txtTelefono.Text = ObjFichadr.sTelefonoSocia
            Else
                Me.txtTelefono.Text = ""
            End If

            'Primaria
            If Not ObjFichadr.IsFieldNull("nStbPrimariaID") Then
                XdsFicha("Primaria").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbPrimariaID)
            Else
                Me.cboPrimaria.Text = ""
                Me.cboPrimaria.SelectedIndex = -1
            End If

            'Secundaria
            If Not ObjFichadr.IsFieldNull("nStbSecundariaID") Then
                XdsFicha("Secundaria").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbSecundariaID)
            Else
                Me.cboSecundaria.Text = ""
                Me.cboSecundaria.SelectedIndex = -1
            End If

            'Carrera Técnica
            If Not ObjFichadr.IsFieldNull("nStbCarreraTecnicaID") Then
                CargarCarreraTecnica(ObjFichadr.nStbCarreraTecnicaID)
                If Me.cboCarreraTecnica.ListCount > 0 Then
                    Me.cboCarreraTecnica.SelectedIndex = 0
                    XdsFicha("CarreraTecnica").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbCarreraTecnicaID)
                End If
            Else
                Me.cboCarreraTecnica.Text = ""
                Me.cboCarreraTecnica.SelectedIndex = -1
            End If

            'Otros Estudios
            If Not ObjFichadr.IsFieldNull("sOtrosEstudios") Then
                Me.txtOtrosEstudios.Text = ObjFichadr.sOtrosEstudios
            Else
                Me.txtOtrosEstudios.Text = ""
            End If

            'Alfabetizada
            If Not ObjFichadr.IsFieldNull("nAlfabetizada") Then
                Me.chkAlfabetizada.Checked = ObjFichadr.nAlfabetizada
            End If

            'Monto Solicitado
            If Not ObjFichadr.IsFieldNull("nMontoCredito") Then
                Me.cneMontoSolicitado.Value = ObjFichadr.nMontoCredito
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
            If Not ObjFichadr.IsFieldNull("nPlazo") Then
                Me.txtPlazo.Text = ObjFichadr.nPlazo
            Else
                Me.txtPlazo.Text = ""
            End If

            'Tipo Plazo
            If Not ObjFichadr.IsFieldNull("nStbTipoPlazoID") Then
                XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoPlazoID)
            Else
                Me.cboTipoPlazo.Text = ""
                Me.cboTipoPlazo.SelectedIndex = -1
            End If

            'Tiene Negocio Actual
            If Not ObjFichadr.IsFieldNull("nTieneNegocio") Then
                If ObjFichadr.nTieneNegocio = 1 Then
                    Me.radSiTieneNegocio.Checked = True
                    Me.cboTipoNegocioActual.Enabled = True
                    Me.cboTipoNegocioPropuesto.Enabled = False

                    'Tipo Negocio Actual
                    If Not ObjFichadr.IsFieldNull("nStbActividadEconomicaID") Then
                        CargarTipoNegocioActual(ObjFichadr.nStbActividadEconomicaID)
                        If cboTipoNegocioActual.ListCount > 0 Then
                            Me.cboTipoNegocioActual.SelectedIndex = 0
                        End If
                        XdsFicha("TipoNegocioActual").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbActividadEconomicaID)
                    Else
                        Me.cboTipoNegocioActual.Text = ""
                        Me.cboTipoNegocioActual.SelectedIndex = -1
                    End If
                Else
                    Me.radNoTieneNegocio.Checked = True
                    Me.cboTipoNegocioActual.Enabled = False
                    Me.cboTipoNegocioPropuesto.Enabled = True

                    'Tipo Negocio Propuesto
                    If Not ObjFichadr.IsFieldNull("nStbActividadEconomicaID") Then
                        CargarTipoNegocioPropuesto(ObjFichadr.nStbActividadEconomicaID)
                        If Me.cboTipoNegocioPropuesto.ListCount > 0 Then
                            Me.cboTipoNegocioPropuesto.SelectedIndex = 0
                        End If
                        XdsFicha("TipoNegocioPropuesto").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbActividadEconomicaID)
                    Else
                        Me.cboTipoNegocioPropuesto.Text = ""
                        Me.cboTipoNegocioPropuesto.SelectedIndex = -1
                    End If
                End If
            End If

            'Promedio Ventas
            If Not ObjFichadr.IsFieldNull("nPromedioVentas") Then
                Me.cnePromedioVentas.Value = ObjFichadr.nPromedioVentas
            Else
                Me.cnePromedioVentas.Value = 0
            End If

            'Tipo Promedio Ventas
            If Not ObjFichadr.IsFieldNull("nStbTipoPlazoPromVentasID") Then
                XdsFicha("TipoVenta").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoPlazoPromVentasID)
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
            Me.txtOtrosEstudios.MaxLength = ObjFichadr.GetColumnLenght("sOtrosEstudios")
            Me.txtDireccionNegocio.MaxLength = ObjFichadr.GetColumnLenght("sDireccionNegocio")
            Me.txtDireccion.MaxLength = ObjFichadr.GetColumnLenght("sDireccionSocia")

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
    ' Fecha:                21/08/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then
                SalvarFicha()

                Me.tabPOtrosCreditos.Enabled = True
                Me.tabPReferencia.Enabled = True
                Me.tabPGarantia.Enabled = True


                Me.tbGarantiaPrendaria.Enabled = True
                btnDatosFinanciero.Enabled = True
                tbReferenciasPersonales.Enabled = True
                tbReferenciasBancarias.Enabled = True
                Me.grdReferenciaComerciales.Enabled = True



                Me.txtCodigo.Text = ObjFichadr.sCodigo
                Me.txtCodigoOC.Text = ObjFichadr.sCodigo
                Me.txtCodigoRC.Text = ObjFichadr.sCodigo
                Me.txtCodigoGC.Text = ObjFichadr.sCodigo

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
                        FormatoOtroCredito()
                        CargarReferencia()
                        FormatoReferencia()
                        CargarGarantiaFiduciaria()
                        FormatoGarantiaFiduciaria()
                        CargarGarantiaPrendaria()
                        FormatoGarantiaPrendaria()
                        Me.tabPOtrosCreditos.Show()
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim dFechaInicioPrograma As Date
            Dim dFechaInscripcion As Date
            Dim strFecha As String
            Dim strSQL As String

            ValidaDatosEntrada = True
            Me.errFicha.Clear()

            'Fecha de Inscripción
            If Me.cdeFechaInscripcion.ValueIsDbNull Then
                MsgBox("La Fecha de Inscripción NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFechaInscripcion, "La Fecha de Inscripción NO DEBE quedar vacía.")
                Me.cdeFechaInscripcion.Focus()
                Exit Function
            End If

            XdtValorParametro.Filter = "nStbParametroID = 4"
            XdtValorParametro.Retrieve()

            strFecha = Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 1, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 3, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 5, 4)

            dFechaInicioPrograma = CDate(strFecha)

            dFechaInscripcion = Me.cdeFechaInscripcion.Value

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

            'Departamento
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Distrito
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            'Barrio
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Barrio válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboBarrio, "Debe seleccionar un Barrio válido.")
                Me.cboBarrio.Focus()
                Exit Function
            End If

            'Grupo
            If Me.cboGrupo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Grupo Solidario válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboGrupo, "Debe seleccionar un Grupo Solidario válido.")
                Me.cboGrupo.Focus()
                Exit Function
            End If

            'Socia
            If Me.cboSocia.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Socia válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboSocia, "Debe seleccionar una Socia válida.")
                Me.cboSocia.Focus()
                Exit Function
            End If

            'XdtValorParametro.Filter = "nStbParametroID = 9"
            'XdtValorParametro.Retrieve()

            REM Plazo
            'If Me.txtPlazo.Text < XdtValorParametro.ValueField("sValorParametro") Then
            '    MsgBox("El Plazo NO DEBE ser menor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
            '        "establecido como mínimo por el Programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.txtPlazo, "El Plazo NO DEBE ser menor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
            '        "establecido como mínimo por el Programa USURA CERO.")
            '    Me.txtPlazo.Focus()
            '    Exit Function
            'End If

            'XdtValorParametro.Filter = "nStbParametroID = 10"
            'XdtValorParametro.Retrieve()

            REM Plazo
            'If Me.txtPlazo.Text > XdtValorParametro.ValueField("sValorParametro") Then
            '    MsgBox("El Plazo NO DEBE ser mayor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
            '        "establecido como máximo por el Programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.txtPlazo, "El Plazo NO DEBE ser mayor a " & XdtValorParametro.ValueField("sValorParametro") & "," & Chr(10) & _
            '        "establecido como máximo por el Programa USURA CERO.")
            '    Me.txtPlazo.Focus()
            '    Exit Function
            'End If

            'Tipo de Plazo
            If Me.cboTipoPlazo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboTipoPlazo, "Debe seleccionar un Tipo de Plazo válido.")
                Me.cboTipoPlazo.Focus()
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

            'XdtValorParametro.Filter = "nStbParametroID = 7"
            'XdtValorParametro.Retrieve()

            REM 'Monto Solicitado
            'If Me.cneMontoSolicitado.Value < XdtValorParametro.ValueField("sValorParametro") Then
            '    MsgBox("El Monto Solicitado NO DEBE ser menor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) & _
            '            "establecido como mínimo por el programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cneMontoSolicitado, "El Monto Solicitado NO DEBE ser menor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) & _
            '            "establecido como mínimo por el programa USURA CERO.")
            '    Me.cneMontoSolicitado.Focus()
            '    Exit Function
            'End If

            'XdtValorParametro.Filter = "nStbParametroID = 8"
            'XdtValorParametro.Retrieve()

            ''Monto Solicitado
            'If Me.cneMontoSolicitado.Value > XdtValorParametro.ValueField("sValorParametro") Then
            '    MsgBox("El Monto Solicitado NO DEBE ser mayor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) & _
            '            "establecido como máximo por el programa USURA CERO.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cneMontoSolicitado, "El Monto Solicitado NO DEBE ser mayor a C$ " & Format(CDbl(XdtValorParametro.ValueField("sValorParametro")), "#,##0.00") & "," & Chr(10) & _
            '            "establecido como máximo por el programa USURA CERO.")
            '    Me.cneMontoSolicitado.Focus()
            '    Exit Function
            'End If

            'Dirección
            If Trim(RTrim(Me.txtDireccion.Text)).ToString.Length = 0 Then
                MsgBox("La Dirección de la Socia NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.txtDireccion, "La Dirección de la Socia NO DEBE quedar vacía.")
                Me.txtDireccion.Focus()
                Exit Function
            End If

            If Me.radSiTieneNegocio.Checked = True Then

                'Tipo de Negocio Actual
                If Me.cboTipoNegocioActual.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Tipo de Negocio Actual válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoNegocioActual, "Debe seleccionar un Tipo de Negocio Actual válido.")
                    Me.cboTipoNegocioActual.Focus()
                    Exit Function
                End If
            Else
                'Tipo de Negocio Propuesto
                If Me.cboTipoNegocioPropuesto.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Tipo de Negocio Propuesto válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoNegocioPropuesto, "Debe seleccionar un Tipo de Negocio Propuesto válido.")
                    Me.cboTipoNegocioPropuesto.Focus()
                    Exit Function
                End If
            End If

            'Se valida solo que exista negocio actual
            If Me.radSiTieneNegocio.Checked = True Then
                'Promedio Ventas
                If Me.cnePromedioVentas.ValueIsDbNull Then
                    MsgBox("El Promedio en Ventas NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cnePromedioVentas, "El Promedio en Ventas NO DEBE quedar vacío.")
                    Me.cnePromedioVentas.Focus()
                    Exit Function
                End If

                'Promedio Ventas
                If Me.cnePromedioVentas.Value = 0 Then
                    MsgBox("El Promedio en Ventas NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cnePromedioVentas, "El Promedio en Ventas NO DEBE ser Cero.")
                    Me.cnePromedioVentas.Focus()
                    Exit Function
                End If

                'Tipo de ventas
                If Me.cboTipoPromedioVentas.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Tipo de Plazo del Promedio de Ventas válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoPromedioVentas, "Debe seleccionar un Tipo de Plazo del Promedio de Ventas válido.")
                    Me.cboTipoPromedioVentas.Focus()
                    Exit Function
                End If

                'Dirección del Negocio
                If Trim(RTrim(Me.txtDireccionNegocio.Text)).ToString.Length = 0 Then
                    MsgBox("La Dirección del Negocio NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.txtDireccionNegocio, "La Dirección del Negocio NO DEBE quedar vacía.")
                    Me.txtDireccionNegocio.Focus()
                    Exit Function
                End If

                'Fecha de Apertura del Negocio
                If Me.cdeFechaApertura.ValueIsDbNull Then
                    MsgBox("La Fecha de Apertura NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cdeFechaApertura, "La Fecha de Apertura NO DEBE quedar vacía.")
                    Me.cdeFechaApertura.Focus()
                    Exit Function
                End If
            End If

            'Validar si la socia seleccionada se encuentra en una Ficha Activa
            '(<> Rechazada (6), <> Anulada (4) y Cancelada (7)) en este u otro GS:
            If ModoFrm = "ADD" Then
                strSQL = " SELECT  a.nSclGrupoSociaID " &
                         " FROM    SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID  " &
                         " WHERE   (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ")"


                'strSQL = " SELECT  a.nSclGrupoSociaID " & _
                '         " FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID " & _
                '         " INNER JOIN SclFichaNotificacionDetalle ON a.nSclFichaSociaID = SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN SccSolicitudDesembolsoCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
                '         " INNER JOIN SccSolicitudCheque ON SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
                '         " INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN StbValorCatalogo AS EstadoFNC ON SclFichaNotificacionCredito.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID " & _
                '         " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ") AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1) AND ((EstadoFNC.sCodigoInterno <> '4') AND (EstadoFNC.sCodigoInterno <> '5'))"

                '       strSQL = " SELECT  a.nSclGrupoSociaID " & _
                '" FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID " & _
                '" INNER JOIN SclFichaNotificacionDetalle ON a.nSclFichaSociaID = SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN SccSolicitudDesembolsoCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
                '" INNER JOIN SccSolicitudCheque ON SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
                '" INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN StbValorCatalogo AS EstadoFNC ON SclFichaNotificacionCredito.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID " & _
                '" WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1) AND ((EstadoFNC.sCodigoInterno <> '4') AND (EstadoFNC.sCodigoInterno <> '5'))"

            Else
                strSQL = " SELECT  a.nSclGrupoSociaID " & _
                         " FROM    SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID  " & _
                         " WHERE   a.nSclFichaSociaID <> " & Me.intSclFichaID & " And (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ")"

                'strSQL = " SELECT  a.nSclGrupoSociaID " & _
                '         " FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID " & _
                '         " INNER JOIN SclFichaNotificacionDetalle ON a.nSclFichaSociaID = SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN SccSolicitudDesembolsoCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
                '         " INNER JOIN SccSolicitudCheque ON SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
                '         " INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN StbValorCatalogo AS EstadoFNC ON SclFichaNotificacionCredito.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID " & _
                '         " WHERE a.nSclFichaSociaID <> " & Me.intSclFichaID & " And (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ") AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1) AND ((EstadoFNC.sCodigoInterno <> '4') AND (EstadoFNC.sCodigoInterno <> '5'))"

            End If

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("La socia tiene Fichas registradas aún no Canceladas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboSocia, "La socia tiene Fichas registradas aún no Canceladas.")
                Me.cboSocia.Focus()
                Exit Function
            End If

            'Puesto en comentario a petición de Beyra Santana 10102008
            ''La Socia no debe tener malas referencias Activas asignadas:
            'strSQL = " SELECT nSclReferenciaSociaID FROM SclReferenciaSocia " & _
            '         " WHERE (nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ") AND (nActiva = 1)"
            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("La socia tiene malas referencias personales asociadas.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.cboSocia, "La socia tiene malas referencias personales asociadas.")
            '    Me.cboSocia.Focus()
            '    Exit Function
            'End If

            'Validar si la Socia forma parte de un grupo donde existe al menos una
            'Ficha(Activa) (<> Rechazada (6), <> Anulada (4) y Cancelada (7)) en este u otro GS:
            'strSQL = " SELECT c.nSclGrupoSolidarioID " & _
            '         " FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID  " & _
            '         " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') " & _
            '         " AND (c.nSclGrupoSolidarioID IN (SELECT nSclGrupoSolidarioID FROM SclGrupoSocia WHERE (nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ")))"

            strSQL = " SELECT c.nSclGrupoSolidarioID " & _
                     " FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID  " & _
                     " WHERE (b.sCodigoInterno = '5') " & _
                     " AND (c.nSclGrupoSolidarioID IN  (SELECT SclGrupoSocia.nSclGrupoSolidarioID FROM  SclGrupoSocia INNER JOIN SclFichaSocia ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (SclGrupoSocia.nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ") AND (StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '4')))"

            '   strSQL = " SELECT c.nSclGrupoSolidarioID, SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sNumeroCedula " & _
            '            " FROM  SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID " & _
            '            " INNER JOIN SclSocia ON c.nSclSociaID = SclSocia.nSclSociaID INNER JOIN SclFichaNotificacionDetalle ON a.nSclFichaSociaID = SclFichaNotificacionDetalle.nSclFichaSociaID  INNER JOIN SccSolicitudDesembolsoCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
            '            " INNER JOIN SccSolicitudCheque ON SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID  INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
            '            " INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN StbValorCatalogo AS EstadoCredito ON SclFichaNotificacionCredito.nStbEstadoCreditoID = EstadoCredito.nStbValorCatalogoID " & _
            '            " WHERE (b.sCodigoInterno = '5') " & _
            '            " AND (c.nSclGrupoSolidarioID IN  (SELECT SclGrupoSocia.nSclGrupoSolidarioID FROM  SclGrupoSocia INNER JOIN SclFichaSocia ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '            " WHERE (SclGrupoSocia.nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ") AND (StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '4'))) AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1) AND (EstadoCredito.sCodigoInterno <> '4' AND EstadoCredito.sCodigoInterno <> '5')"

            '   strSQL = " SELECT c.nSclGrupoSolidarioID, SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sNumeroCedula " & _
            '" FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN SclSocia ON c.nSclSociaID = SclSocia.nSclSociaID " & _
            '" WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') " & _
            '" AND (c.nSclGrupoSolidarioID IN  (SELECT SclGrupoSocia.nSclGrupoSolidarioID FROM  SclGrupoSocia INNER JOIN SclFichaSocia ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '" WHERE (SclGrupoSocia.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '4')))"

            'strSQL = " SELECT c.nSclGrupoSolidarioID, SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sNumeroCedula " & _
            '         " FROM  SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID " & _
            '         " INNER JOIN SclSocia ON c.nSclSociaID = SclSocia.nSclSociaID INNER JOIN SclFichaNotificacionDetalle ON a.nSclFichaSociaID = SclFichaNotificacionDetalle.nSclFichaSociaID  INNER JOIN SccSolicitudDesembolsoCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
            '         " INNER JOIN SccSolicitudCheque ON SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID  INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
            '         " INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN StbValorCatalogo AS EstadoCredito ON SclFichaNotificacionCredito.nStbEstadoCreditoID = EstadoCredito.nStbValorCatalogoID " & _
            '         " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') " & _
            '         " AND (c.nSclGrupoSolidarioID IN  (SELECT SclGrupoSocia.nSclGrupoSolidarioID FROM  SclGrupoSocia INNER JOIN SclFichaSocia ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         " WHERE (SclGrupoSocia.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '4'))) AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1) AND (EstadoCredito.sCodigoInterno <> '4' AND EstadoCredito.sCodigoInterno <> '5')"

            If RegistrosAsociados(strSQL) Then
                MsgBox("La socia forma parte de un Grupo Solidario" & Chr(13) & "en el cual existen Socias con Fichas aún no" & Chr(13) & "Canceladas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboSocia, "Otra(s) Integrante(s) del Grupo Solidario tiene(n) Fichas aún no Canceladas.")
                Me.cboSocia.Focus()
                Exit Function
            End If

            REM CORREO BEYRA 13/11/2009 SOLO PARA CREDITOS USURA:
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
            'strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
            '         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
            '         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & cboGrupo.Columns("nSclGrupoSolidarioID").Value & ") AND (SclTipodePlandeNegocio.nCodigo < 3)"
            If RegistrosAsociados(strSQL) Then 'Si es Grupo Solidario Usura Cero: 
                strSQL = " SELECT ISNULL(MAX(SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), 0) AS UltimoDetalleID " & _
                         " FROM SclSocia INNER JOIN SclGrupoSocia ON SclSocia.nSclSociaID = SclGrupoSocia.nSclSociaID INNER JOIN SclFichaNotificacionCredito INNER JOIN SclFichaNotificacionDetalle " & _
                         " ON SclFichaNotificacionCredito.nSclFichaNotificacionID = SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID " & _
                         " WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionDetalle.nCreditoRechazado = 0) " & _
                         " AND (SclSocia.nSclSociaID = " & cboSocia.Columns("nSclSociaID").Value & ")"
                XdtDatos.ExecuteSql(strSQL)
                If XdtDatos.ValueField("UltimoDetalleID") <> 0 Then
                    strSQL = " Select dbo.SclFichaSeguimiento.nSclFichaNotificacionDetalleID" & _
                             " FROM   dbo.SclFichaSeguimiento INNER JOIN" & _
                             " dbo.StbValorCatalogo ON dbo.SclFichaSeguimiento.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID" & _
                             " WHERE  (dbo.StbValorCatalogo.sCodigoInterno <> '3')" & _
                             " AND dbo.SclFichaSeguimiento.nSclFichaNotificacionDetalleID = " & XdtDatos.ValueField("UltimoDetalleID")
                    XdtDatos.ExecuteSql(strSQL)
                    If XdtDatos.Count = 0 Then
                        'MsgBox("La socia NO tiene Ficha Seguimiento del último crédito.", MsgBoxStyle.Critical, NombreSistema)
                        'ValidaDatosEntrada = False
                        'Me.errFicha.SetError(Me.cboSocia, "La socia NO tiene Ficha Seguimiento del último crédito.")
                        'Me.cboSocia.Focus()
                        'Exit Function
                    End If
                End If
            End If
            
        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try

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
            Dim dFechaInscripcion As Date
            Dim dFechaApertura As Date
            Dim intPrimariaID As Integer
            Dim intSecundariaID As Integer
            Dim intCarreraTecnicaID As Integer
            Dim intActividadEconomicaID As Integer
            Dim intTipoPromedioVentasID As Integer
            Dim intAlfabetizada As Short
            Dim intTieneNegocio As Short

            dFechaInscripcion = Me.cdeFechaInscripcion.Value

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


            If Me.cboTipoNegocioActual.SelectedIndex <> -1 Then
                intActividadEconomicaID = XdsFicha("TipoNegocioActual").ValueField("nStbValorCatalogoID")
            Else
                intActividadEconomicaID = XdsFicha("TipoNegocioPropuesto").ValueField("nStbValorCatalogoID")
            End If

            If Me.ModoFrm = "ADD" Then
                If Me.cdeFechaApertura.ValueIsDbNull Then
                    strSQL = " EXEC spSclGrabarFichaInscripcion " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "','" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "',Null," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtDireccionNegocio.Text & "'," & intTipoPromedioVentasID & ",'" & XdsFicha("Grupo").ValueField("sCodigo") & "','" & InfoSistema.LoginName & "'," & XdsFicha("Grupo").ValueField("nConsecutivoCredito") & "," & InfoSistema.IDCuenta
                Else
                    dFechaApertura = Me.cdeFechaApertura.Value
                    strSQL = " EXEC spSclGrabarFichaInscripcion " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "','" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "','" & Format(dFechaApertura.Date, "yyyy-MM-dd") & "'," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtDireccionNegocio.Text & "'," & intTipoPromedioVentasID & ",'" & XdsFicha("Grupo").ValueField("sCodigo") & "','" & InfoSistema.LoginName & "'," & XdsFicha("Grupo").ValueField("nConsecutivoCredito") & "," & InfoSistema.IDCuenta
                End If
            Else
                ' -------------------------------------------------------------------------------------------------
                GuardarAuditoriaTablas(7, 2, "Modificar SclFichaSocia", XdsFicha("Socia").ValueField("nSclGrupoSociaID"), InfoSistema.IDCuenta)
                ' -------------------------------------------------------------------------------------------------
                If Me.cdeFechaApertura.ValueIsDbNull Then
                    strSQL = " EXEC spSclGrabarFichaInscripcion " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "','" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "',Null," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtDireccionNegocio.Text & "'," & intTipoPromedioVentasID & ",'" & Me.txtCodigo.Text & "','" & InfoSistema.LoginName & "'," & XdsFicha("Grupo").ValueField("nConsecutivoCredito") & "," & InfoSistema.IDCuenta
                Else
                    dFechaApertura = Me.cdeFechaApertura.Value
                    strSQL = " EXEC spSclGrabarFichaInscripcion " & XdsFicha("Socia").ValueField("nSclGrupoSociaID") & "," & Me.intSclFichaID & "," & Me.txtPlazo.Text & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & Me.txtNumHijosVivos.Text & "," & Me.txtNumHijosDependientes.Text & ",'" & Me.ModoFrm & "','" & Format(dFechaInscripcion.Date, "yyyy-MM-dd") & "','" & Format(dFechaApertura.Date, "yyyy-MM-dd") & "'," & Me.cnePromedioVentas.Value & "," & Me.cneMontoSolicitado.Value & "," & intPrimariaID & "," & intSecundariaID & "," & intCarreraTecnicaID & "," & Me.txtEdad.Text & ",'" & Me.txtDireccion.Text & "','" & Me.txtTelefono.Text & "'," & intAlfabetizada & ",'" & Me.txtOtrosEstudios.Text & "'," & intTieneNegocio & "," & intActividadEconomicaID & ",'" & Me.txtDireccionNegocio.Text & "'," & intTipoPromedioVentasID & ",'" & Me.txtCodigo.Text & "','" & InfoSistema.LoginName & "'," & XdsFicha("Grupo").ValueField("nConsecutivoCredito") & "," & InfoSistema.IDCuenta
                End If
            End If

            Me.intFichaID = XcDatos.ExecuteScalar(strSQL)

            If Me.ModoFrm = "ADD" Then
                ' ------------------------------------------------------------------------------------------
                ' VAMOS CON LOS INSERT DE AUDITORIA 
                GuardarAuditoriaTablas(7, 1, "Agregar SclFichaSocia", intFichaID, InfoSistema.IDCuenta)
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
                    Call GuardarAuditoria(2, 15, "Modificación de Ficha de Inscripción ID: " & Me.intFichaID & ".")

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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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

            strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoFicha' "

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
        If TextoValido(e.KeyChar) = True Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    Private Sub txtDireccionNegocio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccionNegocio.KeyPress
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
    Private Sub txtDireccionNegocio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccionNegocio.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cdeFechaInscripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaInscripcion.TextChanged
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
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
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
    Private Sub radNoTieneNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radNoTieneNegocio.CheckedChanged
        If Me.radSiTieneNegocio.Checked = True Then
            Me.cboTipoNegocioActual.Enabled = True
            Me.cboTipoNegocioPropuesto.Enabled = False
            Me.cboTipoNegocioPropuesto.SelectedIndex = -1

            Me.txtDireccionNegocio.Enabled = True
            'Me.txtDireccionNegocio.Text = ""
            Me.cdeFechaApertura.Enabled = True
            'Me.cdeFechaApertura.Value = Me.cdeFechaApertura.ValueIsDbNull
            Me.cnePromedioVentas.Enabled = True

            Me.cboTipoPromedioVentas.Enabled = True
        Else
            Me.cboTipoNegocioActual.Enabled = False
            Me.cboTipoNegocioPropuesto.Enabled = True
            Me.cboTipoNegocioActual.SelectedIndex = -1

            Me.txtDireccionNegocio.Enabled = False
            Me.txtDireccionNegocio.Text = ""
            Me.cdeFechaApertura.Enabled = False
            Me.cdeFechaApertura.Value = Me.cdeFechaApertura.ValueIsDbNull
            Me.cnePromedioVentas.Enabled = False
            Me.cnePromedioVentas.Value = 0
            Me.cboTipoPromedioVentas.Enabled = False
            Me.cboTipoPromedioVentas.SelectedIndex = -1
        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub radSiTieneNegocio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSiTieneNegocio.CheckedChanged
        If Me.radSiTieneNegocio.Checked = True Then
            Me.cboTipoNegocioActual.Enabled = True
            Me.cboTipoNegocioPropuesto.Enabled = False
            Me.cboTipoNegocioPropuesto.SelectedIndex = -1

            Me.txtDireccionNegocio.Enabled = True
            'Me.txtDireccionNegocio.Text = ""
            Me.cdeFechaApertura.Enabled = True
            'Me.cdeFechaApertura.Value = Me.cdeFechaApertura.ValueIsDbNull
            Me.cnePromedioVentas.Enabled = True

            Me.cboTipoPromedioVentas.Enabled = True
        Else
            Me.cboTipoNegocioActual.Enabled = False
            Me.cboTipoNegocioPropuesto.Enabled = True
            Me.cboTipoNegocioActual.SelectedIndex = -1

            Me.txtDireccionNegocio.Enabled = False
            Me.txtDireccionNegocio.Text = ""
            Me.cdeFechaApertura.Enabled = False
            Me.cdeFechaApertura.Value = Me.cdeFechaApertura.ValueIsDbNull
            Me.cnePromedioVentas.Enabled = False
            Me.cnePromedioVentas.Value = 0
            Me.cboTipoPromedioVentas.Enabled = False
            Me.cboTipoPromedioVentas.SelectedIndex = -1

        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboTipoNegocioActual_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNegocioActual.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboTipoNegocioPropuesto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNegocioPropuesto.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cdeFechaApertura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaApertura.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cnePromedioVentas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cnePromedioVentas.TextChanged
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboTipoPromedioVentas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPromedioVentas.TextChanged
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
                         " From StbValorCatalogo a INNER JOIN     " & _
                         " (select nstbCatalogoID From StbCatalogo Where nStbCatalogoID =10 ) b " & _
                         " ON a.nStbCatalogoID =b.nStbCatalogoID " & _
                         " WHERE a.nActivo <>0 " & _
                         " Order by a.sDescripcion "

                '" From StbValorCatalogo a INNER JOIN " & _
                '        " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " & _
                '        " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                '        " WHERE a.nActivo = 1  " & _
                '        " Order by a.sDescripcion "

                'Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                '" From StbValorCatalogo a INNER JOIN " & _
                '" (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " & _
                '" ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                '" WHERE a.nActivo = 1  " & _
                '" Order by a.sDescripcion "

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

            'Asignando a las fuentes de datos
            Me.cboTipoNegocioActual.DataSource = XdsFicha("TipoNegocioActual").Source

            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sDescripcion").Width = 250

            Me.cboTipoNegocioActual.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoNegocioActual.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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

            'Asignando a las fuentes de datos
            Me.cboTipoNegocioPropuesto.DataSource = XdsFicha("TipoNegocioPropuesto").Source

            Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoNegocioPropuesto.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoNegocioPropuesto.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoNegocioPropuesto.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
                     " Order by a.sCodigoInterno "

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
                'If intGrupoID = 0 Then
                '    Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nConsecutivoCredito " & _
                '             " From SclGrupoSolidario a " & _
                '             " WHERE a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','3') And b.sNombre = 'EstadoGrupo') " & _
                '             " And ((SELECT count(*) From SclGrupoSocia Where nSclGrupoSolidarioID = a.nSclGrupoSolidarioID and nCreditoRechazado = 0) >= (Select sValorParametro From StbValorParametro Where nStbParametroID = 16) OR nCreditoIndividual = 1) " & _
                '             " And a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & _
                '             " And a.nSclGrupoSolidarioID NOT IN (SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito Where nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('3') And b.sNombre = 'EstadoCredito')) " & _
                '             " Order by a.sCodigo"
                'Else
                '    Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nConsecutivoCredito " & _
                '             " From SclGrupoSolidario a " & _
                '             " WHERE (a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','3') And b.sNombre = 'EstadoGrupo') " & _
                '             " And ((SELECT count(*) From SclGrupoSocia Where nSclGrupoSolidarioID = a.nSclGrupoSolidarioID and nCreditoRechazado = 0) >= (Select sValorParametro From StbValorParametro Where nStbParametroID = 16) OR nCreditoIndividual = 1) " & _
                '             " And a.nSclGrupoSolidarioID NOT IN (SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito Where nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('3') And b.sNombre = 'EstadoCredito')) " & _
                '             " And a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & ")" & _
                '             " Or a.nSclGrupoSolidarioID = " & intGrupoID & _
                '             " Order by a.sCodigo"
                'End If
                If intGrupoID = 0 Then
                    Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nConsecutivoCredito " & _
                             " From SclGrupoSolidario a " & _
                             " WHERE a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','3') And b.sNombre = 'EstadoGrupo') " & _
                             " And a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & _
                             " Order by a.sCodigo"
                    REM Correo Leonor Corea (01/06/2010):
                    '" And a.nSclGrupoSolidarioID NOT IN (SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito Where nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('3') And b.sNombre = 'EstadoCredito')) " & _
                Else
                    Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nConsecutivoCredito " & _
                             " From SclGrupoSolidario a " & _
                             " WHERE (a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','3') And b.sNombre = 'EstadoGrupo') " & _
                             " And a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & ")" & _
                             " Or a.nSclGrupoSolidarioID = " & intGrupoID & _
                             " Order by a.sCodigo"
                    REM Correo Leonor Corea (01/06/2010):
                    '" And a.nSclGrupoSolidarioID NOT IN (SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito Where nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('3') And b.sNombre = 'EstadoCredito')) " & _
                End If
            Else
                Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion,a.nStbMercadoVerificadoID,a.nConsecutivoCredito " & _
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
            Me.cboGrupo.Splits(0).DisplayColumns("nStbMercadoVerificadoID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nConsecutivoCredito").Visible = False

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
                             " WHERE b.nSociaActiva = 1 And a.nCreditoRechazado = 0 " & _
                             " And a.nSclGrupoSolidarioID = " & XdsFicha("Grupo").ValueField("nSclGrupoSolidarioID") & _
                             " And a.nSclGrupoSociaID NOT IN (Select nSclGrupoSociaID From SclFichaSocia Where nStbEstadoFichaID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2','3','5') And b.sNombre = 'EstadoFicha'))" & _
                             " AND b.sNumeroCedula NOT IN (Select sNumCedula FROM vwSclFiadorFichaActiva) " & _
                             " Order by b.sNumeroCedula "
                    REM Correo Leonor Corea 01/06/2010:
                    '" And a.nSclGrupoSociaID NOT IN (Select nSclGrupoSociaID From SclFichaSocia Where nStbEstadoFichaID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2','3','5','6') And b.sNombre = 'EstadoFicha'))" & _
                Else
                    Strsql = " Select a.nSclGrupoSociaID,b.nSclSociaID,a.nSclGrupoSolidarioID,b.sNumeroCedula,(b.sNombre1 + ' ' + b.sNombre2 + ' ' + b.sApellido1 + ' ' + b.sApellido2) as Descripcion, " & _
                             " b.sDireccionSocia,b.sTelefonoSocia,b.nAlfabetizada,b.nStbPrimariaID,b.nStbSecundariaID,b.nStbCarreraTecnicaID,b.sOtrosEstudios, " & _
                             " b.nNumHijosVivos,b.nNumHijosDependientes,b.dFechaNacimiento" & _
                             " From SclGrupoSocia a INNER JOIN SclSocia b " & _
                             " ON a.nSclSociaID = b.nSclSociaID" & _
                             " WHERE (b.nSociaActiva = 1 And a.nCreditoRechazado = 0 " & _
                             " And a.nSclGrupoSociaID NOT IN (Select nSclGrupoSociaID From SclFichaSocia Where nStbEstadoFichaID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2','3','5') And b.sNombre = 'EstadoFicha'))" & _
                             " AND b.sNumeroCedula NOT IN (Select sNumCedula FROM vwSclFiadorFichaActiva) " & _
                             " And a.nSclGrupoSolidarioID = " & XdsFicha("Grupo").ValueField("nSclGrupoSolidarioID") & ")" & _
                             " Or a.nSclGrupoSociaID = " & intGrupoSociaID & _
                             " Order by b.sNumeroCedula "
                    REM Correo Leonor Corea 01/06/2010:
                    '" And a.nSclGrupoSociaID NOT IN (Select nSclGrupoSociaID From SclFichaSocia Where nStbEstadoFichaID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2','3','5','6') And b.sNombre = 'EstadoFicha'))" & _
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
                         " a.sPeriodicidad,a.nSaldo " & _
                         " From vwSclOtroCredito a " & _
                         " Where a.nSclFichaSociaID = " & Me.intFichaID & " and a.nAltaVerificacion = 0"

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

            Me.grdOtroCredito.Splits(0).DisplayColumns("sSiglas").Width = 100
            Me.grdOtroCredito.Splits(0).DisplayColumns("nPlazo").Width = 50
            Me.grdOtroCredito.Splits(0).DisplayColumns("sTipoPlazo").Width = 70
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoCuota").Width = 90
            Me.grdOtroCredito.Splits(0).DisplayColumns("sPeriodicidad").Width = 70
            Me.grdOtroCredito.Splits(0).DisplayColumns("nSaldo").Width = 30
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").Width = 100
            Me.grdOtroCredito.Splits(0).DisplayColumns("sOtroPrestamista").Width = 100

            Me.grdOtroCredito.Columns("sSiglas").Caption = "Institución"
            Me.grdOtroCredito.Columns("nMontoDeuda").Caption = "Monto Crédito"
            Me.grdOtroCredito.Columns("nPlazo").Caption = "Plazo"
            Me.grdOtroCredito.Columns("sTipoPlazo").Caption = "Tipo Plazo"
            Me.grdOtroCredito.Columns("nMontoCuota").Caption = "Monto Cuota"
            Me.grdOtroCredito.Columns("sPeriodicidad").Caption = "Periodicidad"
            Me.grdOtroCredito.Columns("nSaldo").Caption = "Saldo"
            Me.grdOtroCredito.Columns("sOtroPrestamista").Caption = "Prestamista"

            'Me.grdOtroCredito.Columns("Monto").Caption = "Monto " & strSimbolo

            'Me.grdOtroCredito.Splits(0).DisplayColumns("nPlazo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdOtroCredito.Splits(0).DisplayColumns("sTipoPlazo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoCuota").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdOtroCredito.Splits(0).DisplayColumns("sPeriodicidad").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdOtroCredito.Splits(0).DisplayColumns("nSaldo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdOtroCredito.Splits(0).DisplayColumns.Item("nMontoDeuda").Style.BackColor = Color.WhiteSmoke

            Me.grdOtroCredito.Splits(0).DisplayColumns("nPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sTipoPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sPeriodicidad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("nSaldo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("nMontoDeuda").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOtroCredito.Splits(0).DisplayColumns("sOtroPrestamista").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
            ObjFrmSclEditOtroCredito.sTipoFicha = "INSCRIPCION"
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
            ObjFrmSclEditOtroCredito.sTipoFicha = "INSCRIPCION"
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

                GuardarAuditoriaTablas(15, 3, "Eliminar Otro Credito Vigente", XdsDetalle("OtroCredito").ValueField("nSclOtroCreditoVigenteID"), InfoSistema.IDCuenta)

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
            Help.ShowHelp(Me, MyHelpNameSpace)
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
    Private Sub grdOtroCredito_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOtroCredito.DoubleClick
        Try
            If blnModificar = True Then
                LlamaModificarOC()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '    'Sirve en caso que se filtren registros en la FilterBar
    Private Sub grdOtroCredito_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdOtroCredito.Filter
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
    Private Sub tbReferencia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferencia.ItemClicked
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
            If Me.grdReferencia.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtReferencia.ExecuteSqlNotTable("Delete From SclReferenciaCrediticia where nSclReferenciaCrediticiaID=" & XdsDetalle("Referencia").ValueField("nSclReferenciaCrediticiaID"))
                Me.CargarReferencia()

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
#Region "Detalle Garantías Crediticias"
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarGarantiaFiduciaria
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de las Garantías Fiduciarias en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarGarantiaFiduciaria()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclGarantiaFiduciariaID,a.sFiador,a.sNumCedula,a.sTelefono " & _
                     " From vwSclGarantiaFiduciaria a " & _
                     " Where a.nSclFichaSociaID = " & Me.intFichaID

            If XdsDetalle.ExistTable("GarantiaFiduciaria") Then
                XdsDetalle("GarantiaFiduciaria").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "GarantiaFiduciaria")
                XdsDetalle("GarantiaFiduciaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdGarantiaFiduciaria.DataSource = XdsDetalle("GarantiaFiduciaria").Source
            Me.grdGarantiaFiduciaria.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdGarantiaFiduciaria.Caption = " Listado de Garantías Fiduciarias (" + Me.grdGarantiaFiduciaria.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarGarantiaPrendaria
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de las Garantías Prendarias en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarGarantiaPrendaria()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclGarantiaPrendariaID,a.sDescripcion,a.nValorGarantia " & _
                     " From vwSclGarantiaPrendaria a " & _
                     " Where a.nSclFichaSociaID = " & Me.intFichaID

            If XdsDetalle.ExistTable("GarantiaPrendaria") Then
                XdsDetalle("GarantiaPrendaria").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "GarantiaPrendaria")
                XdsDetalle("GarantiaPrendaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdGarantiaPrendaria.DataSource = XdsDetalle("GarantiaPrendaria").Source
            Me.grdGarantiaPrendaria.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdGarantiaPrendaria.Caption = " Listado de Garantías Prendarias (" + Me.grdGarantiaPrendaria.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       FormatoGarantiaFiduciaria
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Garantías Fiduciarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoGarantiaFiduciaria()
        Try
            'Configuracion del Grid 
            Me.grdGarantiaFiduciaria.Splits(0).DisplayColumns("nSclGarantiaFiduciariaID").Visible = False

            Me.grdGarantiaFiduciaria.Splits(0).DisplayColumns("sFiador").Width = 250
            Me.grdGarantiaFiduciaria.Splits(0).DisplayColumns("sNumCedula").Width = 160
            Me.grdGarantiaFiduciaria.Splits(0).DisplayColumns("sTelefono").Width = 80

            Me.grdGarantiaFiduciaria.Columns("sFiador").Caption = "Nombre del Fiador"
            Me.grdGarantiaFiduciaria.Columns("sNumCedula").Caption = "Número de Cédula"
            Me.grdGarantiaFiduciaria.Columns("sTelefono").Caption = "Teléfono"

            Me.grdGarantiaFiduciaria.Splits(0).DisplayColumns("sFiador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGarantiaFiduciaria.Splits(0).DisplayColumns("sNumCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGarantiaFiduciaria.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       FormatoGarantiaPrendaria
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Garantías Prendarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoGarantiaPrendaria()
        Try

            'Configuracion del Grid 
            Me.grdGarantiaPrendaria.Splits(0).DisplayColumns("nSclGarantiaPrendariaID").Visible = False

            Me.grdGarantiaPrendaria.Splits(0).DisplayColumns("sDescripcion").Width = 350
            Me.grdGarantiaPrendaria.Splits(0).DisplayColumns("nValorGarantia").Width = 50

            Me.grdGarantiaPrendaria.Columns("sDescripcion").Caption = "Descripción de la Garantía"
            Me.grdGarantiaPrendaria.Columns("nValorGarantia").Caption = "Valor de la Garantía C$"

            Me.grdGarantiaPrendaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGarantiaPrendaria.Splits(0).DisplayColumns("nValorGarantia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdGarantiaPrendaria.Columns("nValorGarantia").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       tbGarantiaFiduciaria_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbGarantiaFiduciaria.
    '-------------------------------------------------------------------------
    Private Sub tbGarantiaFiduciaria_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbGarantiaFiduciaria.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarGF"
                LlamaAgregarGF()
            Case "toolModificarGF"
                LlamaModificarGF()
            Case "toolEliminarGF"
                LlamaEliminarGF()
            Case "toolRefrescarGF"
                CargarGarantiaFiduciaria()
            Case "toolAyudaGF"
                LlamaAyuda()
            Case "toolMantenimientoFiador"
                LlamaMantenimientoFiador()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       tbGarantiaPrendaria_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbGarantiaPrendaria.
    '-------------------------------------------------------------------------
    Private Sub tbGarantiaPrendaria_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbGarantiaPrendaria.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarGP"
                LlamaAgregarGP()
            Case "toolModificarGP"
                LlamaModificarGP()
            Case "toolEliminarGP"
                LlamaEliminarGP()
            Case "toolRefrescarGP"
                CargarGarantiaPrendaria()
            Case "toolAyudaGP"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaAgregarGF
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditGarantiaFiduciaria para Agregar una nueva Garantía.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarGF()
        Dim ObjFrmSclEditGarantiaFiduciaria As New frmSclEditGarantiaFiduciaria
        Try
            ObjFrmSclEditGarantiaFiduciaria.ModoFrm = "ADD"
            ObjFrmSclEditGarantiaFiduciaria.intFichaID = Me.intFichaID
            ObjFrmSclEditGarantiaFiduciaria.strColor = "RojoLight"
            ObjFrmSclEditGarantiaFiduciaria.ShowDialog()

            If ObjFrmSclEditGarantiaFiduciaria.intGarantiaFiduciariaID <> 0 Then
                CargarGarantiaFiduciaria()
                XdsDetalle("GarantiaFiduciaria").SetCurrentByID("nSclGarantiaFiduciariaID", ObjFrmSclEditGarantiaFiduciaria.intGarantiaFiduciariaID)
                Me.grdGarantiaFiduciaria.Row = XdsDetalle("GarantiaFiduciaria").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditGarantiaFiduciaria.Close()
            ObjFrmSclEditGarantiaFiduciaria = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaAgregarGP
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditGarantiaPrendaria para Agregar una nueva Garantía.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarGP()
        Dim ObjFrmSclEditGarantiaPrendaria As New frmSclEditGarantiaPrendaria
        Try
            ObjFrmSclEditGarantiaPrendaria.ModoFrm = "ADD"
            ObjFrmSclEditGarantiaPrendaria.intFichaID = Me.intFichaID
            ObjFrmSclEditGarantiaPrendaria.strColor = "RojoLight"
            ObjFrmSclEditGarantiaPrendaria.ShowDialog()

            If ObjFrmSclEditGarantiaPrendaria.intGarantiaPrendariaID <> 0 Then
                CargarGarantiaPrendaria()
                XdsDetalle("GarantiaPrendaria").SetCurrentByID("nSclGarantiaPrendariaID", ObjFrmSclEditGarantiaPrendaria.intGarantiaPrendariaID)
                Me.grdGarantiaFiduciaria.Row = XdsDetalle("GarantiaPrendaria").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditGarantiaPrendaria.Close()
            ObjFrmSclEditGarantiaPrendaria = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaModificarGF
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditGarantiaFiduciaria para Modificar una Garantía existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarGF()
        Dim ObjFrmSclEditGarantiaFiduciaria As New frmSclEditGarantiaFiduciaria
        Try
            If Me.grdGarantiaFiduciaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditGarantiaFiduciaria.ModoFrm = "UPD"
            ObjFrmSclEditGarantiaFiduciaria.intFichaID = Me.intFichaID
            ObjFrmSclEditGarantiaFiduciaria.intGarantiaFiduciariaID = XdsDetalle("GarantiaFiduciaria").ValueField("nSclGarantiaFiduciariaID")
            ObjFrmSclEditGarantiaFiduciaria.strColor = "RojoLight"
            ObjFrmSclEditGarantiaFiduciaria.ShowDialog()

            CargarGarantiaFiduciaria()
            XdsDetalle("GarantiaFiduciaria").SetCurrentByID("nSclGarantiaFiduciariaID", ObjFrmSclEditGarantiaFiduciaria.intGarantiaFiduciariaID)
            Me.grdGarantiaFiduciaria.Row = XdsDetalle("GarantiaFiduciaria").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditGarantiaFiduciaria.Close()
            ObjFrmSclEditGarantiaFiduciaria = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       LlamaModificarGP
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditGarantiaPrendaria para Modificar una Garantía existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarGP()
        Dim ObjFrmSclEditGarantiaPrendaria As New frmSclEditGarantiaPrendaria
        Try
            If Me.grdGarantiaPrendaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditGarantiaPrendaria.ModoFrm = "UPD"
            ObjFrmSclEditGarantiaPrendaria.intFichaID = Me.intFichaID
            ObjFrmSclEditGarantiaPrendaria.intGarantiaPrendariaID = XdsDetalle("GarantiaPrendaria").ValueField("nSclGarantiaPrendariaID")
            ObjFrmSclEditGarantiaPrendaria.strColor = "RojoLight"
            ObjFrmSclEditGarantiaPrendaria.ShowDialog()

            CargarGarantiaPrendaria()
            XdsDetalle("GarantiaPrendaria").SetCurrentByID("nSclGarantiaPrendariaID", ObjFrmSclEditGarantiaPrendaria.intGarantiaPrendariaID)
            Me.grdGarantiaPrendaria.Row = XdsDetalle("GarantiaPrendaria").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditGarantiaPrendaria.Close()
            ObjFrmSclEditGarantiaPrendaria = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       LlamaEliminarGF
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una Garantía Fiduciaria existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarGF()
        Dim XdtGarantiaFiduciaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdGarantiaFiduciaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
                GuardarAuditoriaTablas(13, 3, "Eliminar Garantia Fiduciaria", XdsDetalle("GarantiaFiduciaria").ValueField("nSclGarantiaFiduciariaID"), InfoSistema.IDCuenta)

                XdtGarantiaFiduciaria.ExecuteSqlNotTable("Delete From SclGarantiaFiduciaria where nSclGarantiaFiduciariaID=" & XdsDetalle("GarantiaFiduciaria").ValueField("nSclGarantiaFiduciariaID"))
                CargarGarantiaFiduciaria()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdGarantiaFiduciaria.Caption = "Listado de Garantías Fiduciarias (" + Me.grdGarantiaFiduciaria.RowCount.ToString + " registros)"



            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaFiduciaria.Close()
            XdtGarantiaFiduciaria = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       LlamaEliminarGP
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una Garantía Prendaria existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarGP()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Dim nSclGarantiaPrendariaID As Integer

        Try
            If Me.grdGarantiaPrendaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                nSclGarantiaPrendariaID = XdsDetalle("GarantiaPrendaria").ValueField("nSclGarantiaPrendariaID")

                GuardarAuditoriaTablas(14, 3, "Eliminar Garantia Prendaria", nSclGarantiaPrendariaID, InfoSistema.IDCuenta)

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclGarantiaPrendaria where nSclGarantiaPrendariaID=" & XdsDetalle("GarantiaPrendaria").ValueField("nSclGarantiaPrendariaID"))
                CargarGarantiaPrendaria()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdGarantiaPrendaria.Caption = "Listado de Garantías Prendarias (" + Me.grdGarantiaPrendaria.RowCount.ToString + " registros)"

            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       grdGarantiaFiduciaria_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Garantía Fiduciaria existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdGarantiaFiduciaria_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGarantiaFiduciaria.DoubleClick
        Try
            If blnModificar = True Then
                LlamaModificarGF()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       grdGarantiaPrendaria_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Garantía Prendaria existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdGarantiaPrendaria_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGarantiaPrendaria.DoubleClick
        Try
            If blnModificar = True Then
                LlamaModificarGP()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Sirve para realizar el filtro de la condición introducida en la Barra de Filtro
    Private Sub grdGarantiaFiduciaria_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdGarantiaFiduciaria.Filter
        Try
            XdsDetalle("GarantiaFiduciaria").FilterLocal(e.Condition)
            Me.grdGarantiaFiduciaria.Caption = " Listado de Garantías Fiduciarias (" + Me.grdGarantiaFiduciaria.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Sirve para realizar el filtro de la condición introducida en la Barra de Filtro
    Private Sub grdGarantiaPrendaria_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdGarantiaPrendaria.Filter
        Try
            XdsDetalle("GarantiaPrendaria").FilterLocal(e.Condition)
            Me.grdGarantiaPrendaria.Caption = " Listado de Garantías Prendarias (" + Me.grdGarantiaPrendaria.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
#End Region
 
    

    Private Sub LlamaAgregarRP()
        Dim ObjFrmSclEditReferenciaPersonal As New frmSclEditReferenciaPersonal
        Try
            ObjFrmSclEditReferenciaPersonal.ModoFrm = "ADD"
            ObjFrmSclEditReferenciaPersonal.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaPersonal.intSclTipoPersona = 1
            ObjFrmSclEditReferenciaPersonal.strColor = "RojoLight"
            ObjFrmSclEditReferenciaPersonal.ShowDialog()

            If ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID <> 0 Then
                CargarReferenciaPersonal()
                XdsDetalle("ReferenciaPersonal").SetCurrentByID("nSclReferenciaPersonalID", ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID)
                Me.grdReferenciaPersonal.Row = XdsDetalle("ReferenciaPersonal").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaPersonal.Close()
            ObjFrmSclEditReferenciaPersonal = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarRP()
        Dim ObjFrmSclEditReferenciaPersonal As New frmSclEditReferenciaPersonal
        Try
            If Me.grdReferenciaPersonal.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditReferenciaPersonal.intSclTipoPersona = 1 'Es Credito no fiador.
            ObjFrmSclEditReferenciaPersonal.ModoFrm = "UPD"
            ObjFrmSclEditReferenciaPersonal.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaPersonal.intReferenciaCrediticiaID = 0
            ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID = XdsDetalle("ReferenciaPersonal").ValueField("nSclReferenciaPersonalID")
            ObjFrmSclEditReferenciaPersonal.intPersonalID = XdsDetalle("ReferenciaPersonal").ValueField("nStbPersonaReferenciaID")

            ObjFrmSclEditReferenciaPersonal.strColor = "RojoLight"
            ObjFrmSclEditReferenciaPersonal.ShowDialog()

            CargarReferenciaPersonal()
            XdsDetalle("ReferenciaPersonal").SetCurrentByID("nSclReferenciaPersonalID", ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID)
            Me.grdReferenciaPersonal.Row = XdsDetalle("ReferenciaPersonal").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaPersonal.Close()
            ObjFrmSclEditReferenciaPersonal = Nothing
        End Try
    End Sub

    Private Sub LlamaEliminarRP()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReferenciaPersonal.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclReferenciaPersonal  where nSclReferenciaPersonalID=" & XdsDetalle("ReferenciaPersonal").ValueField("nSclReferenciaPersonalID"))
                CargarReferenciaPersonal()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferenciaPersonal.Caption = "Listado de Referencias Personales (" + Me.grdReferenciaPersonal.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub
    Public Sub CargarReferenciaPersonal()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclReferenciaPersonalID as nSclReferenciaPersonalID ,a.nStbPersonaReferenciaID  as nStbPersonaReferenciaID,a.sFiador,a.sNumCedula,a.sTelefono,a.sCelular,a.sDireccion " & _
                     " From vwSclReferenciaPersonal a " & _
                     " Where a.nSclFichaSociaID = " & Me.intFichaID

            If XdsDetalle.ExistTable("ReferenciaPersonal") Then
                XdsDetalle("ReferenciaPersonal").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "ReferenciaPersonal")
                XdsDetalle("ReferenciaPersonal").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferenciaPersonal.DataSource = XdsDetalle("ReferenciaPersonal").Source
            Me.grdReferenciaPersonal.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferenciaPersonal.Caption = " Listado de Referencias Personales (" + Me.grdReferenciaPersonal.RowCount.ToString + " registros)"


            'Configuracion del Grid 
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("nSclReferenciaPersonalID").Visible = False
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("nStbPersonaReferenciaID").Visible = False


            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sFiador").Width = 250
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sNumCedula").Width = 100
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sTelefono").Width = 100
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sCelular").Width = 100
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sDireccion").Width = 250
     

            Me.grdReferenciaPersonal.Columns("sFiador").Caption = "Nombre"
            Me.grdReferenciaPersonal.Columns("sNumCedula").Caption = "Cédula"
            Me.grdReferenciaPersonal.Columns("sTelefono").Caption = "Teléfono"
            Me.grdReferenciaPersonal.Columns("sCelular").Caption = "Celular"
            Me.grdReferenciaPersonal.Columns("sDireccion").Caption = "Dirección"
            

            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sFiador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sNumCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaPersonal.Splits(0).DisplayColumns("sDireccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    Private Sub tbReferenciasBancarias_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferenciasBancarias.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarRB"
                LlamaAgregarRB()
            Case "toolModificarRB"
                LlamaModificarRB()
            Case "toolEliminarRB"
                LlamaEliminarRB()
            Case "toolRefrescarRB"
                CargarReferenciaBancaria()
            Case "toolAyudaRP"
                LlamaAyuda()
        End Select
    End Sub

    Private Sub tbReferenciasComerciales_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferenciasComerciales.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarRCO"
                LlamaAgregarRCO()
            Case "toolModificarRCO"
                LlamaModificarRCO()
            Case "toolEliminarRCO"
                LlamaEliminarRCO()
            Case "toolRefrescarRCO"
                CargarReferenciaComercial()
            Case "toolAyudaRP"
                LlamaAyuda()
        End Select
    End Sub

 
    Private Sub tbReferenciasPersonales_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferenciasPersonales.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregarRP"
                LlamaAgregarRP()
            Case "toolModificarRP"
                LlamaModificarRP()
            Case "toolEliminarRP"
                LlamaEliminarRP()
            Case "toolRefrescarRP"
                CargarReferenciaPersonal()
            Case "toolAyudaRP"
                LlamaAyuda()
        End Select
    End Sub
    'Llama la pantalla de los datos del fiador que son identicos a los pedidos por credito al cliente
    'Esto es el formato del BFP.
    Private Sub LlamaMantenimientoFiador()
        Dim ObjFrmSclEditMantenimientoFiador As New frmSclEditMantenimientoFiador
        Try
            If Me.grdGarantiaFiduciaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'ObjFrmSclEditReferenciaPersonal.intSclTipoPersona = 1 'Es Credito no fiador.
            'ObjFrmSclEditReferenciaPersonal.ModoFrm = "UPD"
            'ObjFrmSclEditReferenciaPersonal.intFichaID = Me.intFichaID
            'ObjFrmSclEditReferenciaPersonal.intReferenciaCrediticiaID = 0
            'ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID = XdsDetalle("ReferenciaPersonal").ValueField("nSclReferenciaPersonalID")
            'ObjFrmSclEditReferenciaPersonal.intPersonalID = XdsDetalle("ReferenciaPersonal").ValueField("nStbPersonaReferenciaID")
            ObjFrmSclEditMantenimientoFiador.sCodigoFicha = txtCodigoRB.Text
            ObjFrmSclEditMantenimientoFiador.sEstadoFicha = txtEstadoRB.Text
            ObjFrmSclEditMantenimientoFiador.sNombreFiador = XdsDetalle("GarantiaFiduciaria").ValueField("sFiador")
            ObjFrmSclEditMantenimientoFiador.intFiadorGarantiaFiduciariaID = XdsDetalle("GarantiaFiduciaria").ValueField("nSclGarantiaFiduciariaID")

            ObjFrmSclEditMantenimientoFiador.strColor = "RojoLight"
            ObjFrmSclEditMantenimientoFiador.ShowDialog()

            'CargarReferenciaPersonal()
            'XdsDetalle("ReferenciaPersonal").SetCurrentByID("nSclReferenciaPersonalID", ObjFrmSclEditReferenciaPersonal.intReferenciaPersonalID)
            'Me.grdReferenciaPersonal.Row = XdsDetalle("ReferenciaPersonal").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditMantenimientoFiador.Close()
            ObjFrmSclEditMantenimientoFiador = Nothing
        End Try
    End Sub

    Private Sub LlamaAgregarRB()
        Dim ObjFrmSclEditReferenciaBancaria As New frmSclEditReferenciaBancaria
        Try
            ObjFrmSclEditReferenciaBancaria.ModoFrm = "ADD"
            ObjFrmSclEditReferenciaBancaria.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaBancaria.intSclTipoPersona = 1
            ObjFrmSclEditReferenciaBancaria.strColor = "RojoLight"
            ObjFrmSclEditReferenciaBancaria.ShowDialog()

            If ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID <> 0 Then
                CargarReferenciaBancaria()
                XdsDetalle("ReferenciaBancaria").SetCurrentByID("nSclReferenciaBancariaID", ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID)
                Me.grdReferenciaBancaria.Row = XdsDetalle("ReferenciaBancaria").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaBancaria.Close()
            ObjFrmSclEditReferenciaBancaria = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarRB()
        Dim ObjFrmSclEditReferenciaBancaria As New frmSclEditReferenciaBancaria
        Try
            If Me.grdReferenciaPersonal.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditReferenciaBancaria.intSclTipoPersona = 1 'Es Credito no fiador.
            ObjFrmSclEditReferenciaBancaria.ModoFrm = "UPD"
            ObjFrmSclEditReferenciaBancaria.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaBancaria.intReferenciaCrediticiaID = 0
            ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID = XdsDetalle("ReferenciaBancaria").ValueField("nSclReferenciaBancariaID")
            ObjFrmSclEditReferenciaBancaria.intPersonalID = XdsDetalle("ReferenciaBancaria").ValueField("nStbPersonaReferenciaID")

            ObjFrmSclEditReferenciaBancaria.strColor = "RojoLight"
            ObjFrmSclEditReferenciaBancaria.ShowDialog()

            CargarReferenciaBancaria()
            XdsDetalle("ReferenciaBancaria").SetCurrentByID("nSclReferenciaBancariaID", ObjFrmSclEditReferenciaBancaria.intReferenciaBancariaID)
            Me.grdReferenciaBancaria.Row = XdsDetalle("ReferenciaBancaria").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaBancaria.Close()
            ObjFrmSclEditReferenciaBancaria = Nothing
        End Try
    End Sub

    Private Sub LlamaEliminarRB()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReferenciaBancaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclReferenciaBancaria  where nSclReferenciaBancariaID=" & XdsDetalle("ReferenciaBancaria").ValueField("nSclReferenciaBancariaID"))
                CargarReferenciaBancaria()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferenciaBancaria.Caption = "Listado de Referencias Bancarias (" + Me.grdReferenciaBancaria.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub

    Public Sub CargarReferenciaBancaria()
        Try
            Dim Strsql As String

            'Strsql = " Select a.nSclReferenciaPersonalID as nSclReferenciaPersonalID ,a.nStbPersonaReferenciaID  as nStbPersonaReferenciaID,a.sFiador,a.sNumCedula,a.sTelefono,a.sCelular,a.sDireccion " & _
            '         " From vwSclReferenciaBancaria a " & _
            '         " Where a.nSclFichaSociaID = " & Me.intFichaID

            Strsql = "SELECT     a.nSclReferenciaBancariaID, a.nStbPersonaReferenciaID, a.sFiador, a.sNumCedula, a.sTelefono, a.sCelular, a.DesBanco, a.DesTipoCuenta, a.DesTipoMoneda, a.nMontoPromedio, a.dFechaReferencia, a.nAnionRelacion  FROM         dbo.vwSclReferenciaBancaria AS a Where a.nSclFichaSociaID = " & Me.intFichaID


            If XdsDetalle.ExistTable("ReferenciaBancaria") Then
                XdsDetalle("ReferenciaBancaria").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "ReferenciaBancaria")
                XdsDetalle("ReferenciaBancaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferenciaBancaria.DataSource = XdsDetalle("ReferenciaBancaria").Source
            Me.grdReferenciaBancaria.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferenciaBancaria.Caption = " Listado de Referencias Bancarias (" + Me.grdReferenciaBancaria.RowCount.ToString + " registros)"


            'Configuracion del Grid 
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nSclReferenciaBancariaID").Visible = False
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nStbPersonaReferenciaID").Visible = False


            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sFiador").Width = 250
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sNumCedula").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sTelefono").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sCelular").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesBanco").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoCuenta").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoMoneda").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nMontoPromedio").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("dFechaReferencia").Width = 100
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nAnionRelacion").Width = 100



            Me.grdReferenciaBancaria.Columns("sFiador").Caption = "Nombre"
            Me.grdReferenciaBancaria.Columns("sNumCedula").Caption = "Cédula"
            Me.grdReferenciaBancaria.Columns("sTelefono").Caption = "Teléfono"
            Me.grdReferenciaBancaria.Columns("sCelular").Caption = "Celular"
            Me.grdReferenciaBancaria.Columns("DesBanco").Caption = "Banco"
            Me.grdReferenciaBancaria.Columns("DesTipoCuenta").Caption = "Tipo de Cuenta"
            Me.grdReferenciaBancaria.Columns("DesTipoMoneda").Caption = "Tipo de Moneda"
            Me.grdReferenciaBancaria.Columns("nMontoPromedio").Caption = "Monto Promedio"
            Me.grdReferenciaBancaria.Columns("dFechaReferencia").Caption = "Fecha Referencia"
            Me.grdReferenciaBancaria.Columns("nAnionRelacion").Caption = "Años de Relación"




            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sFiador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sNumCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesBanco").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("DesTipoMoneda").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nMontoPromedio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("dFechaReferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaBancaria.Splits(0).DisplayColumns("nAnionRelacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center





        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    '-------------Referencia Comercial




    Private Sub LlamaAgregarRCO()
        Dim ObjFrmSclEditReferenciaComercial As New frmSclEditReferenciaComercial
        Try
            ObjFrmSclEditReferenciaComercial.ModoFrm = "ADD"
            ObjFrmSclEditReferenciaComercial.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaComercial.intSclTipoPersona = 1
            ObjFrmSclEditReferenciaComercial.strColor = "RojoLight"
            ObjFrmSclEditReferenciaComercial.ShowDialog()

            If ObjFrmSclEditReferenciaComercial.intReferenciaComercialID <> 0 Then
                CargarReferenciaComercial()
                XdsDetalle("ReferenciaComercial").SetCurrentByID("nSclReferenciaComercialID", ObjFrmSclEditReferenciaComercial.intReferenciaComercialID)
                'Me.grdReferenciaComerciales.Row = XdsDetalle("ReferenciaComecial").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaComercial.Close()
            ObjFrmSclEditReferenciaComercial = Nothing
        End Try
    End Sub

    Private Sub LlamaModificarRCO()
        Dim ObjFrmSclEditReferenciaComercial As New frmSclEditReferenciaComercial
        Try
            If Me.grdReferenciaComerciales.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSclEditReferenciaComercial.intSclTipoPersona = 1 'Es Credito no fiador.
            ObjFrmSclEditReferenciaComercial.ModoFrm = "UPD"
            ObjFrmSclEditReferenciaComercial.intFichaID = Me.intFichaID
            ObjFrmSclEditReferenciaComercial.intReferenciaCrediticiaID = 0
            ObjFrmSclEditReferenciaComercial.intReferenciaComercialID = XdsDetalle("ReferenciaComercial").ValueField("nSclReferenciaComercialID")
            ObjFrmSclEditReferenciaComercial.intPersonalID = XdsDetalle("ReferenciaComercial").ValueField("nStbPersonaReferenciaID")

            ObjFrmSclEditReferenciaComercial.strColor = "RojoLight"
            ObjFrmSclEditReferenciaComercial.ShowDialog()

            CargarReferenciaComercial()
            XdsDetalle("ReferenciaComercial").SetCurrentByID("nSclReferenciaComercialID", ObjFrmSclEditReferenciaComercial.intReferenciaComercialID)
            Me.grdReferenciaComerciales.Row = XdsDetalle("ReferenciaComercial").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferenciaComercial.Close()
            ObjFrmSclEditReferenciaComercial = Nothing
        End Try
    End Sub

    Private Sub LlamaEliminarRCO()
        Dim XdtGarantiaPrendaria As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReferenciaComerciales.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtGarantiaPrendaria.ExecuteSqlNotTable("Delete From SclReferenciaComercial  where nSclReferenciaComercialID=" & XdsDetalle("ReferenciaComercial").ValueField("nSclReferenciaComercialID"))
                CargarReferenciaComercial()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReferenciaComerciales.Caption = "Listado de Referencias Comerciales (" + Me.grdReferenciaComerciales.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtGarantiaPrendaria.Close()
            XdtGarantiaPrendaria = Nothing
        End Try
    End Sub

    Public Sub CargarReferenciaComercial()
        Try
            Dim Strsql As String

            'Strsql = " Select a.nSclReferenciaPersonalID as nSclReferenciaPersonalID ,a.nStbPersonaReferenciaID  as nStbPersonaReferenciaID,a.sFiador,a.sNumCedula,a.sTelefono,a.sCelular,a.sDireccion " & _
            '         " From vwSclReferenciaBancaria a " & _
            '         " Where a.nSclFichaSociaID = " & Me.intFichaID

            Strsql = "SELECT     a.nSclReferenciaComercialID, a.nStbPersonaReferenciaID, a.sFiador, a.sNumCedula, a.sTelefono, a.sCelular, a.DesComercio,a.dFechaReferencia, a.nAnionRelacion  FROM         dbo.vwSclReferenciaComercial AS a Where a.nSclFichaSociaID = " & Me.intFichaID


            If XdsDetalle.ExistTable("ReferenciaComercial") Then
                XdsDetalle("ReferenciaComercial").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "ReferenciaComercial")
                XdsDetalle("ReferenciaComercial").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReferenciaComerciales.DataSource = XdsDetalle("ReferenciaComercial").Source
            Me.grdReferenciaComerciales.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdReferenciaComerciales.Caption = " Listado de Referencias Comercial (" + Me.grdReferenciaComerciales.RowCount.ToString + " registros)"


            'Configuracion del Grid 
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nSclReferenciaComercialID").Visible = False
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nStbPersonaReferenciaID").Visible = False


            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sFiador").Width = 250
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sNumCedula").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sTelefono").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sCelular").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("DesComercio").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("dFechaReferencia").Width = 100
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nAnionRelacion").Width = 100



            Me.grdReferenciaComerciales.Columns("sFiador").Caption = "Nombre"
            Me.grdReferenciaComerciales.Columns("sNumCedula").Caption = "Cédula"
            Me.grdReferenciaComerciales.Columns("sTelefono").Caption = "Teléfono"
            Me.grdReferenciaComerciales.Columns("sCelular").Caption = "Celular"
            Me.grdReferenciaComerciales.Columns("DesComercio").Caption = "Comercio"
            Me.grdReferenciaComerciales.Columns("dFechaReferencia").Caption = "Fecha Referencia"
            Me.grdReferenciaComerciales.Columns("nAnionRelacion").Caption = "Años de Relación"




            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sFiador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sNumCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("sCelular").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("DesComercio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("dFechaReferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferenciaComerciales.Splits(0).DisplayColumns("nAnionRelacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center





        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub







    '-----------Fin Referencia comercial









    Private Sub btnDatosFinanciero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDatosFinanciero.Click
        Dim ObjFrmSclEditInformacionFinanciera As New frmSclEditInformacionFinanciera
        Try
            ObjFrmSclEditInformacionFinanciera.ModoFrm = "ADD"
            ObjFrmSclEditInformacionFinanciera.intFichaID = Me.intFichaID
            ObjFrmSclEditInformacionFinanciera.intSclTipoPersona = 1
            ObjFrmSclEditInformacionFinanciera.strColor = "RojoLight"
            ObjFrmSclEditInformacionFinanciera.ShowDialog()

            
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditInformacionFinanciera.Close()
            ObjFrmSclEditInformacionFinanciera = Nothing
        End Try
    End Sub
End Class