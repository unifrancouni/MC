' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                02/07/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditFichaSeguimiento.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Fichas de Seguimiento al crédito.
'-------------------------------------------------------------------------
Public Class frmSclEditFichaSeguimiento

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSclFicha As Integer
    Dim IntPermiteEditarDelegacion As Integer

    '-- Crear un data table de tipo Xdataset
    Dim ObjFichadt As BOSistema.Win.SclEntFicha.SclFichaSeguimientoDataTable
    Dim ObjFichadr As BOSistema.Win.SclEntFicha.SclFichaSeguimientoRow

    '-- Crear un data table de tipo Xdataset para Combos
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener Permisos de edición fuera de la Delegación.
    Public Property intSclPermiteEditarDelegacion() As Integer
        Get
            intSclPermiteEditarDelegacion = IntPermiteEditarDelegacion
        End Get
        Set(ByVal value As Integer)
            IntPermiteEditarDelegacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Formato.
    Public Property IdFicha() As Integer
        Get
            IdFicha = IdSclFicha
        End Get
        Set(ByVal value As Integer)
            IdSclFicha = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       frmSclEditFichaSeguimiento_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFichaSeguimiento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjFichadt.Close()
                ObjFichadt = Nothing

                ObjFichadr.Close()
                ObjFichadr = Nothing

                XdsUbicacion.Close()
                XdsUbicacion = Nothing

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
    ' Fecha:                02/07/2009
    ' Procedure Name:       frmSclEditFichaSeguimiento_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Formato en caso de estar en el modo
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditFichaSeguimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarTipoNegocio()
            CargarTipoEjecucion()
            CargarActividad(0)
            CargarTecnico(0)
            CargarModalidadNegocio()
            CargarCausasNoTieneNegocio()

            'Si el formulario está en modo edición
            'cargar los datos del Formulario.
            If ModoForm <> "ADD" Then
                CargarFicha()
                'Si el Registro no se encuentra Activo:
                InhabilitarControles()
            End If
            DatosInhabilitados()

            Me.cboTecnico.Select()
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            Dim strsql As String
            strsql = "SELECT SclFichaSeguimiento.nSclFichaSeguimientoID " & _
                     "FROM SclFichaSeguimiento INNER JOIN StbValorCatalogo ON SclFichaSeguimiento.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID  " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SclFichaSeguimiento.nSclFichaSeguimientoID = " & ObjFichadr.nSclFichaSeguimientoID & ")"
            If RegistrosAsociados(strsql) = False Then
                Me.grpGenerales.Enabled = False
                Me.grpNegocio.Enabled = False
                Me.grpEjecucion.Enabled = False
                Me.grpRegistroContable.Enabled = False
                Me.grpControlPagos.Enabled = False
                Me.grpObservaciones.Enabled = False
                Me.grpTecnico.Enabled = False
                Me.CmdAceptar.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/07/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub DatosInhabilitados()
        Try
            'Existencia de Registros Contables:
            If Me.RdRegistrosSi.Checked = True Then
                Me.txtRegistros.Enabled = False
                Me.txtRegistros.BackColor = Color.WhiteSmoke
            Else
                Me.txtRegistros.Enabled = True
                Me.txtRegistros.BackColor = Color.White
            End If
            'Cuotas Atrasadas:
            If Me.RdPagosSi.Checked Then
                Me.txtCuotasAtrasadas.Enabled = False
                Me.txtCuotasAtrasadas.BackColor = Color.WhiteSmoke
                'Me.txtCuotasAtrasadas.Text = "0"
            Else
                Me.txtCuotasAtrasadas.Enabled = True
                Me.txtCuotasAtrasadas.BackColor = Color.White
            End If
            'Inicio de Ejecucion:
            If Me.RdEjecucionSi.Checked Then 'Ya inicio la ejecucion de fondos
                Me.txtInversion.Enabled = True
                Me.txtInversion.BackColor = Color.White
                Me.txtJustificacionSubejecucion.Enabled = False
                Me.txtJustificacionSubejecucion.BackColor = Color.WhiteSmoke
                'Habilitar Bloque de Negocio:
                Me.grpNegocio.Enabled = True
                'Habilitar Bloque de Registro Contable SI tiene negocio:
                If Me.rdTieneNegocioNo.Checked Then
                    Me.grpRegistroContable.Enabled = False
                    'Habilitar Causas de la Inexistencia:
                    Me.cboCausasInexistenciaNegocio.Enabled = True
                Else
                    Me.grpRegistroContable.Enabled = True
                    'DesHabilitar Causas de la Inexistencia:
                    Me.cboCausasInexistenciaNegocio.Enabled = False
                End If
            Else
                Me.txtJustificacionSubejecucion.Enabled = True
                Me.txtJustificacionSubejecucion.BackColor = Color.White
                Me.txtInversion.Enabled = False
                Me.txtInversion.BackColor = Color.WhiteSmoke
                'Desabilitar Bloque de Negocio:
                Me.grpNegocio.Enabled = False
                'Desabilitar Bloque de Registro Contable con NO:
                Me.grpRegistroContable.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Ficha de Seguimiento"
            ElseIf ModoFrm = "UPD" Then
                Me.Text = "Modificar Ficha de Seguimiento"
            End If

            ObjFichadt = New BOSistema.Win.SclEntFicha.SclFichaSeguimientoDataTable
            ObjFichadr = New BOSistema.Win.SclEntFicha.SclFichaSeguimientoRow
            XdsUbicacion = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False
            Me.cboClasificacion.ClearFields()
            Me.cboTipoEjecucion.ClearFields()
            Me.cboTipoNegocio.ClearFields()
            Me.cboTecnico.ClearFields()
            Me.cboModalidad.ClearFields()
            Me.cboCausasInexistenciaNegocio.ClearFields()

            If ModoForm = "ADD" Then
                ObjFichadr = ObjFichadt.NewRow
                'Inicializar los Length de los campos
                Me.txtInversion.MaxLength = ObjFichadr.GetColumnLenght("sDescripcionInversion")
                Me.txtRegistros.MaxLength = ObjFichadr.GetColumnLenght("sFormaRegistroContable")
                Me.txtJustificacionSubejecucion.MaxLength = ObjFichadr.GetColumnLenght("sJustificacionSubejecucion")
                Me.txtObservaciones.MaxLength = ObjFichadr.GetColumnLenght("sObservaciones")
                Me.txtTelefono.MaxLength = ObjFichadr.GetColumnLenght("sTelefono")
                Me.txtUbicacionNegocio.MaxLength = ObjFichadr.GetColumnLenght("sUbicacionNegocio")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       CargarFicha
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Formato en caso de estar en Modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarFicha()
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim Strsql As String
        Try
            '-- Buscar el correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjFichadt.Filter = "nSclFichaSeguimientoID = " & IdSclFicha
            ObjFichadt.Retrieve()
            If ObjFichadt.Count = 0 Then
                Exit Sub
            End If
            ObjFichadr = ObjFichadt.Current

            'Cargar Combo de Tecnico:
            If Not ObjFichadr.IsFieldNull("nSrhTecnicoID") Then
                CargarTecnico(ObjFichadr.nSrhTecnicoID)
                If cboTecnico.ListCount > 0 Then
                    Me.cboTecnico.SelectedIndex = 0
                End If
                XdsUbicacion("Tecnico").SetCurrentByID("nSrhEmpleadoID", ObjFichadr.nSrhTecnicoID)
            Else
                Me.cboTecnico.Text = ""
                Me.cboTecnico.SelectedIndex = -1
            End If

            'Fecha de Ficha:
            If Not ObjFichadr.IsFieldNull("dFechaFicha") Then
                Me.cdeFecha.Value = ObjFichadr.dFechaFicha
            Else
                Me.cdeFecha.Value = Me.cdeFecha.ValueIsDbNull
            End If

            'Telefono Socia:
            If Not ObjFichadr.IsFieldNull("sTelefono") Then
                Me.txtTelefono.Text = ObjFichadr.sTelefono
            Else
                Me.txtTelefono.Text = ""
            End If

            '-- Localizar resto de informacion de la Socia:
            '1. Cédula Socia:
            Strsql = " SELECT S.sNumeroCedula " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjFichadr.nSclFichaNotificacionDetalleID & ")"
            Me.mtbNumCedula.Text = XcUbicacion.ExecuteScalar(Strsql)
            '2. Nombre Socia:
            Strsql = " SELECT S.sNombre1 + ' ' + S.sNombre2 + ' ' + S.sApellido1 + ' ' + S.sApellido2 as Socia " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjFichadr.nSclFichaNotificacionDetalleID & ")"
            Me.txtNombreSocia.Text = XcUbicacion.ExecuteScalar(Strsql)
            '3. Nombre Grupo Solidario:
            Strsql = " SELECT SclGrupoSolidario.sDescripcion " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID INNER JOIN SclGrupoSolidario ON GS.nSclGrupoSolidarioID = SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjFichadr.nSclFichaNotificacionDetalleID & ")"
            Me.txtNombreGrupo.Text = XcUbicacion.ExecuteScalar(Strsql)
            '4. Dirección Socia:
            Strsql = " SELECT S.sDireccionSocia " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjFichadr.nSclFichaNotificacionDetalleID & ")"
            Me.txtDireccion.Text = XcUbicacion.ExecuteScalar(Strsql)
            '5. Monto Aprobado:
            Strsql = " SELECT DFN.nMontoCreditoAprobado " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjFichadr.nSclFichaNotificacionDetalleID & ")"
            Me.txtMontoA.Text = XcUbicacion.ExecuteScalar(Strsql)
            '6. Negocio Aprobado:
            Strsql = " SELECT StbValorCatalogo.sDescripcion AS Actividad " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID INNER JOIN StbValorCatalogo ON FS.nStbActividadEconomicaVerificadaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjFichadr.nSclFichaNotificacionDetalleID & ")"
            Me.txtNegocioA.Text = XcUbicacion.ExecuteScalar(Strsql)
            '7. Número de Crédito:
            Me.txtNoCredito.Text = ObjFichadr.nCreditoNumero
            Me.txtFichaNotificacionDetalleID.Text = ObjFichadr.nSclFichaNotificacionDetalleID

            'Cargar Combo de Actividad Económica y leyenda de tipo de clasificación:
            If Not ObjFichadr.IsFieldNull("nSclClasificacionEconomicaID") Then
                CargarActividad(ObjFichadr.nSclClasificacionEconomicaID)
                If cboClasificacion.ListCount > 0 Then
                    Me.cboClasificacion.SelectedIndex = 0
                End If
                XdsUbicacion("Clasificacion").SetCurrentByID("nSclClasificacionEconomicaID", ObjFichadr.nSclClasificacionEconomicaID)
                Me.txtTipoClasificacion.Text = Me.cboClasificacion.Columns("TipoClasificacion").Value
            Else
                Me.cboClasificacion.Text = ""
                Me.cboClasificacion.SelectedIndex = -1
                Me.txtTipoClasificacion.Text = ""
            End If

            'Cargar Combo de Tipo de Negocio:
            If Not ObjFichadr.IsFieldNull("nStbTipoNegocioID") Then
                CargarTipoNegocio()
                If cboTipoNegocio.ListCount > 0 Then
                    Me.cboTipoNegocio.SelectedIndex = 0
                End If
                XdsUbicacion("TipoNegocio").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoNegocioID)
            Else
                Me.cboTipoNegocio.Text = ""
                Me.cboTipoNegocio.SelectedIndex = -1
            End If

            'Cargar Combo de Modalidad de Negocio:
            If Not ObjFichadr.IsFieldNull("nStbModalidadNegocioID") Then
                CargarModalidadNegocio()
                If cboModalidad.ListCount > 0 Then
                    Me.cboModalidad.SelectedIndex = 0
                End If
                XdsUbicacion("ModalidadNegocio").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbModalidadNegocioID)
            Else
                Me.cboModalidad.Text = ""
                Me.cboModalidad.SelectedIndex = -1
            End If

            'Ubiacción Negocio:
            If Not ObjFichadr.IsFieldNull("sUbicacionNegocio") Then
                Me.txtUbicacionNegocio.Text = ObjFichadr.sUbicacionNegocio
            Else
                Me.txtUbicacionNegocio.Text = ""
            End If

            'Indicador de Inicio de Ejecución de Fondos:
            If ObjFichadr.nEjecucionFondosIniciada = 1 Then
                Me.RdEjecucionSi.Checked = True
                Me.txtInversion.Enabled = True
                Me.txtInversion.BackColor = Color.White
                Me.txtJustificacionSubejecucion.Enabled = False
                Me.txtJustificacionSubejecucion.BackColor = Color.WhiteSmoke
            Else
                Me.RdEjecucionNo.Checked = True
                Me.txtJustificacionSubejecucion.Enabled = True
                Me.txtJustificacionSubejecucion.BackColor = Color.White
                Me.txtInversion.Enabled = False
                Me.txtInversion.BackColor = Color.WhiteSmoke
            End If

            'Cargar Combo de Tipo de Ejecución de Fondos:
            If Not ObjFichadr.IsFieldNull("nStbTipoEjecucionFondosID") Then
                CargarTipoEjecucion()
                If cboTipoEjecucion.ListCount > 0 Then
                    Me.cboTipoEjecucion.SelectedIndex = 0
                End If
                XdsUbicacion("TipoEjecucion").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbTipoEjecucionFondosID)
            Else
                Me.cboTipoEjecucion.Text = ""
                Me.cboTipoEjecucion.SelectedIndex = -1
            End If

            'Justificacion de la Subejecucion: 
            If Not ObjFichadr.IsFieldNull("sJustificacionSubejecucion") Then
                Me.txtJustificacionSubejecucion.Text = ObjFichadr.sJustificacionSubejecucion
            Else
                Me.txtJustificacionSubejecucion.Text = ""
            End If

            'Descripción Inversión: 
            If Not ObjFichadr.IsFieldNull("sDescripcionInversion") Then
                Me.txtInversion.Text = ObjFichadr.sDescripcionInversion
            Else
                Me.txtInversion.Text = ""
            End If

            'Indicador de existencia de Registros Contables:
            If ObjFichadr.nRegistrosContables = 1 Then
                Me.RdRegistrosSi.Checked = True
                Me.txtRegistros.Enabled = False
                Me.txtRegistros.BackColor = Color.WhiteSmoke
            Else
                Me.RdRegistrosNo.Checked = True
                Me.txtRegistros.Enabled = True
                Me.txtRegistros.BackColor = Color.White
            End If

            'Registros Contables alternos:
            If Not ObjFichadr.IsFieldNull("sFormaRegistroContable") Then
                Me.txtRegistros.Text = ObjFichadr.sFormaRegistroContable
            Else
                Me.txtRegistros.Text = ""
            End If

            'Indicador de pagos al dia:
            If ObjFichadr.nCuotasAlDia = 1 Then
                Me.RdPagosSi.Checked = True
                Me.txtCuotasAtrasadas.Enabled = False
                Me.txtCuotasAtrasadas.BackColor = Color.WhiteSmoke
            Else
                Me.RdPagosNo.Checked = True
                Me.txtCuotasAtrasadas.Enabled = True
                Me.txtCuotasAtrasadas.BackColor = Color.White
            End If

            'Indicador de existencia del negocio:
            If ObjFichadr.nTieneNegocioActualmente = 1 Then
                Me.rdTieneNegocioSi.Checked = True
            Else
                Me.rdTieneNegocioNo.Checked = True
            End If

            'Cargar Combo de Causas de Inexistencia del Negocio:
            If Not ObjFichadr.IsFieldNull("nStbCausasInexistenciaNegocioID") Then
                CargarCausasNoTieneNegocio()
                If Me.cboCausasInexistenciaNegocio.ListCount > 0 Then
                    Me.cboCausasInexistenciaNegocio.SelectedIndex = 0
                End If
                XdsUbicacion("CausasNoTieneNegocio").SetCurrentByID("nStbValorCatalogoID", ObjFichadr.nStbCausasInexistenciaNegocioID)
            Else
                Me.cboCausasInexistenciaNegocio.Text = ""
                Me.cboCausasInexistenciaNegocio.SelectedIndex = -1
            End If

            'Total de Cuotas Atrasadas:
            Me.txtCuotasAtrasadas.Text = ObjFichadr.nTotalCuotasAtrasadas
            'Total de Cuotas Canceladas:
            Me.txtCuotasCanceladas.Text = ObjFichadr.nTotalCuotasCanceladas
            'Ultimo Recibo:
            'If ObjFichadr.nNumeroUltimoRecibo = 0 Then
            '    Me.txtUltimoRecibo.Text = ""
            'Else
            Me.txtUltimoRecibo.Text = ObjFichadr.nNumeroUltimoRecibo
            'End If

            'Observaciones: 
            If Not ObjFichadr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjFichadr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos:
            Me.txtInversion.MaxLength = ObjFichadr.GetColumnLenght("sDescripcionInversion")
            Me.txtRegistros.MaxLength = ObjFichadr.GetColumnLenght("sFormaRegistroContable")
            Me.txtJustificacionSubejecucion.MaxLength = ObjFichadr.GetColumnLenght("sJustificacionSubejecucion")
            Me.txtObservaciones.MaxLength = ObjFichadr.GetColumnLenght("sObservaciones")
            Me.txtTelefono.MaxLength = ObjFichadr.GetColumnLenght("sTelefono")
            Me.txtUbicacionNegocio.MaxLength = ObjFichadr.GetColumnLenght("sUbicacionNegocio")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarFicha()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            ValidaDatosEntrada = True
            Me.errFicha.Clear()
            Dim StrSql As String

            'Indicar Tecnico:
            If Me.cboTecnico.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del técnico.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboTecnico, "Debe indicar nombre del Técnico.")
                Me.cboTecnico.Focus()
                Exit Function
            End If

            'Fecha de la Ficha:
            If Me.cdeFecha.ValueIsDbNull Then
                MsgBox("La Fecha NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFecha, "La Fecha NO DEBE quedar vacía.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Fecha no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFecha.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha NO DEBE ser menor que" & Chr(13) & "fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFecha, "La Fecha NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Fecha no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFecha.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha NO DEBE ser mayor que fecha de corte" & Chr(13) & "indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFecha, "La Fecha NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Fecha no mayor que Fecha Server:
            If Format(Me.cdeFecha.Value, "yyyy-MM-dd") > FechaServer().Date Then
                MsgBox("Fecha NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFecha, "Fecha NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Indicar Socia:
            If (Me.txtNombreSocia.Text = "") Or (Trim(txtNombreSocia.Text).Length = 0) Then
                MsgBox("Debe buscar una Socia válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.mtbNumCedula, "Debe buscar una Socia válida.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If
            If (Me.txtFichaNotificacionDetalleID.Text = "") Or (Trim(txtFichaNotificacionDetalleID.Text).Length = 0) Or (Me.txtFichaNotificacionDetalleID.Text = "0") Then
                MsgBox("Debe buscar una Socia válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.mtbNumCedula, "Debe buscar una Socia válida.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'Imposible si ya se registro la Ficha ACTIVA para la Fecha y Socia:
            StrSql = " SELECT SclFichaSeguimiento.nSclFichaSeguimientoID " & _
                     " FROM SclFichaSeguimiento INNER JOIN StbValorCatalogo ON SclFichaSeguimiento.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (SclFichaSeguimiento.nSclFichaSeguimientoID <> " & Me.IdSclFicha & ") " & _
                     " AND (SclFichaSeguimiento.nSclFichaNotificacionDetalleID = " & Me.txtFichaNotificacionDetalleID.Text & ") AND (SclFichaSeguimiento.dFechaFicha = CONVERT(DATETIME, '" & Format(CDate(cdeFecha.Text), "yyyy-MM-dd") & "', 102)) "
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existe registro ACTIVO para esta Socia" & Chr(13) & "en esta fecha.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cdeFecha, "Ficha Registrada para la fecha y socia.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Indicar Tipo de Ejecución de Fondos:
            If Me.cboTipoEjecucion.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Tipo de Ejecución.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.cboTipoEjecucion, "Debe indicar un Tipo de Ejecucón.")
                Me.cboTipoEjecucion.Focus()
                Exit Function
            End If

            'Si ya se inicio la ejecucion no indicar el Tipo Sin Ejecutar:
            If Me.RdEjecucionSi.Checked Then
                If Me.cboTipoEjecucion.Columns("sCodigoInterno").Value = 3 Then
                    MsgBox("Tipo de ejecución inválido.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoEjecucion, "Tipo de ejecución inválido.")
                    Me.cboTipoEjecucion.Focus()
                    Exit Function
                End If
            End If

            'Si no se ha iniciado la ejecucion solo es posible indicar el tipo sin ejecutar:
            If Me.RdEjecucionNo.Checked Then
                If Me.cboTipoEjecucion.Columns("sCodigoInterno").Value <> 3 Then
                    MsgBox("Tipo de ejecución inválido.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoEjecucion, "Tipo de ejecución inválido.")
                    Me.cboTipoEjecucion.Focus()
                    Exit Function
                End If
            End If

            'Si no se ha iniciado la ejecicion de Fondos:
            If Me.RdEjecucionNo.Checked = True Then
                'Indicar Motivo:
                If Trim(txtJustificacionSubejecucion.Text).Length = 0 Then
                    MsgBox("Debe indicar motivo de subejecución de fondos.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.txtJustificacionSubejecucion, "Debe indicar motivo de subejecución de fondos.")
                    Me.txtJustificacionSubejecucion.Focus()
                    Exit Function
                End If
            Else 'En caso de ya haber iniciado la ejecucion de fondos:
                'Indicar en que se invirtio el Crédito:
                If Trim(txtInversion.Text).Length = 0 Then
                    MsgBox("Debe indicar en que se invirtió el crédito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.txtInversion, "Debe indicar en que se invirtió el crédito.")
                    Me.txtInversion.Focus()
                    Exit Function
                End If

                '-- Si hubo inicio de Ejecución de Fondos Obligar Datos del Negocio:
                'Indicar Actividad Economica:
                If Me.cboClasificacion.SelectedIndex = -1 Then
                    MsgBox("Debe indicar una Actividad Económica.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboClasificacion, "Debe indicar una Actividad Económica.")
                    Me.cboClasificacion.Focus()
                    Exit Function
                End If

                'Indicar Tipo de Negocio:
                If Me.cboTipoNegocio.SelectedIndex = -1 Then
                    MsgBox("Debe indicar un Tipo de Negocio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboTipoNegocio, "Debe indicar un Tipo de Negocio.")
                    Me.cboTipoNegocio.Focus()
                    Exit Function
                End If

                'Indicar Modalidad del negocio:
                If Me.cboModalidad.SelectedIndex = -1 Then
                    MsgBox("Debe indicar Modalidad del Negocio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.cboModalidad, "Debe indicar Modalidad del Negocio.")
                    Me.cboModalidad.Focus()
                    Exit Function
                End If

                'Indicar Ubicacion del Negocio:
                If Trim(txtUbicacionNegocio.Text).Length = 0 Then
                    MsgBox("Debe indicar ubicación del Negocio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.txtUbicacionNegocio, "Debe indicar ubicación del Negocio.")
                    Me.txtUbicacionNegocio.Focus()
                    Exit Function
                End If

                'Si inicio la ejecucion y Actualmente no tiene negocio se debe de indicar el motivo:
                If Me.rdTieneNegocioNo.Checked = True Then
                    If (Me.cboCausasInexistenciaNegocio.SelectedIndex = -1) Or (Me.cboCausasInexistenciaNegocio.Text = "") Then
                        MsgBox("Debe indicar causas de la inexistencia actual del Negocio.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errFicha.SetError(Me.cboCausasInexistenciaNegocio, "Debe indicar causas de la inexistencia actual del Negocio.")
                        Me.cboCausasInexistenciaNegocio.Focus()
                        Exit Function
                    End If
                End If
            End If

            'Si no se llevan registros contables: 
            If Me.RdRegistrosNo.Checked And Me.grpRegistroContable.Enabled Then
                'Indicar de que forma se llevan:
                If Trim(txtRegistros.Text).Length = 0 Then
                    MsgBox("Debe indicar como se llevan registros contables.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.txtRegistros, "Debe indicar como se llevan registros contables.")
                    Me.txtRegistros.Focus()
                    Exit Function
                End If
            End If

            'Imposible si no se indicó Cantidad de Cuotas Atrasadas: (Puede ser cero)
            If Not IsNumeric(Me.txtCuotasAtrasadas.Text) Then
                MsgBox("Cantidad de Cuotas Atrasadas Inválida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.txtCuotasAtrasadas, "Cantidad de Cuotas Atrasadas Inválida.")
                Me.txtCuotasAtrasadas.Focus()
                Exit Function
            End If

            'Si no va al dia con los pagos:
            If Me.RdPagosNo.Checked Then
                'Indicar total de cuotas atrasadas:
                If (CDbl(txtCuotasAtrasadas.Text) = 0) Then
                    MsgBox("Debe indicar total de cuotas atrasadas.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFicha.SetError(Me.txtCuotasAtrasadas, "Debe indicar total de cuotas atrasadas.")
                    Me.txtCuotasAtrasadas.Focus()
                    Exit Function
                End If
            End If

            'Imposible si no se indicó Cantidad de Cuotas Canceladas: (Puede ser cero)
            If Not IsNumeric(Me.txtCuotasCanceladas.Text) Then
                MsgBox("Cantidad de Cuotas Canceladas Inválida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFicha.SetError(Me.txtCuotasCanceladas, "Cantidad de Cuotas Canceladas Inválida.")
                Me.txtCuotasCanceladas.Focus()
                Exit Function
            End If

            REM se va a permitir el recibo 0, en caso de no conocerse:
            'Si las cuotas canceladas es cero no indicar ultimo recibo:
            'If (Me.txtCuotasCanceladas.Text = "0") And (Trim(txtUltimoRecibo.Text).Length <> 0) Then
            '    MsgBox("Si no existen cuotas canceladas no debe" & Chr(13) & "indicarse el número del ultimo recibo.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errFicha.SetError(Me.txtUltimoRecibo, "Ultimo recibo cancelado Inválido.")
            '    Me.txtUltimoRecibo.Focus()
            '    Exit Function
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
    ' Fecha:                02/07/2009
    ' Procedure Name:       SalvarFicha
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Formato en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarFicha()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim StrFecha As String
        Dim StrFechaCancelacion As String

        Dim StrTelefono As String
        Dim StrJustificacionSubejecucion As String
        Dim StrDescripcionInversion As String
        Dim StrFormaRegistroContable As String
        Dim StrObservaciones As String
        Dim IntUltimoRecibo As Integer
        Dim StrUbicacionNegocio As String
        Dim IntClasificacionID As Integer
        Dim IntTipoNegocioID As Integer
        Dim IntModalidadNegocioID As Integer
        Dim IntCausasInexistenciaNegocioID As Integer

        Try
            Dim strSQL As String = ""

            StrFecha = Format(Me.cdeFecha.Value, "yyyy-MM-dd")

            '-- DATOS QUE PUEDEN SER NULOS:
            'sTelefono:
            If Trim(Me.txtTelefono.Text).Length = 0 Then
                StrTelefono = "Null"
            Else
                StrTelefono = Trim(Me.txtTelefono.Text)
            End If

            'sJustificacionSubejecucion:
            If Trim(Me.txtJustificacionSubejecucion.Text).Length = 0 Then
                StrJustificacionSubejecucion = "Null"
            Else
                StrJustificacionSubejecucion = Trim(Me.txtJustificacionSubejecucion.Text)
            End If

            'sDescripcionInversion:
            If Trim(Me.txtInversion.Text).Length = 0 Then
                StrDescripcionInversion = "Null"
            Else
                StrDescripcionInversion = Trim(Me.txtInversion.Text)
            End If

            'sFormaRegistroContable:
            If Trim(Me.txtRegistros.Text).Length = 0 Then
                StrFormaRegistroContable = "Null"
            Else
                StrFormaRegistroContable = Trim(Me.txtRegistros.Text)
            End If

            'sObservaciones:
            If Trim(Me.txtObservaciones.Text).Length = 0 Then
                StrObservaciones = "Null"
            Else
                StrObservaciones = Trim(Me.txtObservaciones.Text)
            End If

            'nNumeroUltimoRecibo:
            If Trim(Me.txtUltimoRecibo.Text).Length = 0 Then
                IntUltimoRecibo = 0
            Else
                IntUltimoRecibo = Me.txtUltimoRecibo.Text
            End If

            '-- DATOS DEL NEGOCIO:
            'StrUbicacionNegocio
            If Trim(Me.txtUbicacionNegocio.Text).Length = 0 Then
                StrUbicacionNegocio = "Null"
            Else
                StrUbicacionNegocio = Trim(Me.txtUbicacionNegocio.Text)
            End If

            'Clasificacion Negocio:
            If Me.cboClasificacion.SelectedIndex <> -1 Then
                IntClasificacionID = Me.cboClasificacion.Columns("nSclClasificacionEconomicaID").Value
            Else
                IntClasificacionID = 0
            End If

            'Tipo Negocio:
            If Me.cboTipoNegocio.SelectedIndex <> -1 Then
                IntTipoNegocioID = Me.cboTipoNegocio.Columns("nStbValorCatalogoID").Value
            Else
                IntTipoNegocioID = 0
            End If
            
            'Modalidad Negocio:
            If Me.cboModalidad.SelectedIndex <> -1 Then
                IntModalidadNegocioID = Me.cboModalidad.Columns("nStbValorCatalogoID").Value
            Else
                IntModalidadNegocioID = 0
            End If

            'Causas de Inexistencia del Negocio:
            If Me.rdTieneNegocioSi.Checked = True Then
                IntCausasInexistenciaNegocioID = 0
            Else
                If Me.cboCausasInexistenciaNegocio.SelectedIndex <> -1 Then
                    IntCausasInexistenciaNegocioID = Me.cboCausasInexistenciaNegocio.Columns("nStbValorCatalogoID").Value
                Else
                    IntCausasInexistenciaNegocioID = 0
                End If
            End If

            'Encontrar Fecha de cancelacion del detalle de la FNC:
            strSQL = "SELECT SclFichaNotificacionCredito.dFechaUltimaCuota " & _
                     "FROM SclFichaNotificacionDetalle INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     "WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = " & Me.txtFichaNotificacionDetalleID.Text & ")"
            StrFechaCancelacion = Format(XcDatos.ExecuteScalar(strSQL), "yyyy-MM-dd")


            If ModoForm <> "ADD" Then
                GuardarAuditoriaTablas(26, 2, "Modificar SclFichaSeguimiento", IdSclFicha, InfoSistema.IDCuenta)
            End If


            '-- Ejecuta Procedimiento Almacenado:
            strSQL = " EXEC spSclGrabarFichaSeguimiento " & Me.IdSclFicha & ", '" & StrFecha & "', " & Me.txtFichaNotificacionDetalleID.Text & ", '" & StrTelefono & "', '" & StrUbicacionNegocio & "' " & _
                     ", " & Me.txtNoCredito.Text & ", '" & StrFechaCancelacion & "', " & IntClasificacionID & ", " & IntTipoNegocioID & ", " & IntModalidadNegocioID & ", " & IIf(Me.rdTieneNegocioSi.Checked, 1, 0) & "," & IntCausasInexistenciaNegocioID & ", " & IIf(Me.RdEjecucionSi.Checked, 1, 0) & ", " & Me.cboTipoEjecucion.Columns("nStbValorCatalogoID").Value & _
                     ", " & "'" & StrJustificacionSubejecucion & "', '" & StrDescripcionInversion & "', " & IIf(Me.RdRegistrosSi.Checked, 1, 0) & ", '" & StrFormaRegistroContable & "', " & IIf(Me.RdPagosSi.Checked, 1, 0) & ", " & Me.txtCuotasAtrasadas.Text & ", " & Me.txtCuotasCanceladas.Text & ", " & IntUltimoRecibo & ", " & _
                     "'" & StrObservaciones & "', " & Me.cboTecnico.Columns("nSrhEmpleadoID").Value & ", " & InfoSistema.IDDelegacion & ", " & InfoSistema.IDCuenta & ", '" & Me.ModoForm & "'"
            Me.IdSclFicha = XcDatos.ExecuteScalar(strSQL)

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.IdSclFicha = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                If ModoForm = "ADD" Then
                    GuardarAuditoriaTablas(26, 1, "Agregar SclFichaSeguimiento", IdSclFicha, InfoSistema.IDCuenta)

                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                    'Call GuardarAuditoria(2, 15, "Modificación de Ficha de Seguimiento ID:" & Me.IdSclFicha & ".")
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
    ' Fecha:                02/07/2009
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
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/07/2009
    ' Procedure Name:       CargarTecnico
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Técnicos del Programa.
    '-------------------------------------------------------------------------
    Private Sub CargarTecnico(ByVal intTecnicoID As Integer)
        Try
            Dim Strsql As String

            Me.cboTecnico.ClearFields() '01: Verificador, 03: Director Promocion, 12: Tecnico de Promocion, '15': Delegadas Departamentales, '10': Oficiales de Crédito.

            If intTecnicoID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where (a.sCodCargo = '01') or (a.sCodCargo = '03') or (a.sCodCargo = '12') or (a.sCodCargo = '10') or (a.sCodCargo = '15') " & _
                     " Order by a.sNombreEmpleado "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where ((a.sCodCargo = '01') or (a.sCodCargo = '03') or (a.sCodCargo = '12') or (a.sCodCargo = '10') or (a.sCodCargo = '15')) " & _
                     "  or (a.nSrhEmpleadoID = " & intTecnicoID & ") " & _
                     " Order by a.sNombreEmpleado "
            End If

            If XdsUbicacion.ExistTable("Tecnico") Then
                XdsUbicacion("Tecnico").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Tecnico")
                XdsUbicacion("Tecnico").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboTecnico.DataSource = XdsUbicacion("Tecnico").Source
            Me.cboTecnico.Rebind()

            Me.cboTecnico.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nActivo").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Visible = False

            'Configurar el combo: 
            'Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").Width = 210

            'Me.cboTecnico.Columns("nCodigo").Caption = "Código"
            Me.cboTecnico.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            'Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       CargarActividad
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Actividades en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarActividad(ByVal intClasificacionID As Integer)
        Try
            Dim Strsql As String = ""

            If intClasificacionID = 0 Then
                Strsql = " SELECT CE.nSclClasificacionEconomicaID, A.sCodigoInterno AS CodigoActividad, A.sDescripcion AS sActividad, TA.sDescripcion AS TipoClasificacion " & _
                         " FROM SclClasificacionEconomica as CE INNER JOIN StbValorCatalogo as TA ON CE.nStbTipoActividadEconomicaID = TA.nStbValorCatalogoID INNER JOIN StbValorCatalogo AS A ON CE.nStbActividadEconomicaID = A.nStbValorCatalogoID " & _
                         " WHERE (CE.nActiva = 1) " & _
                         " ORDER BY a.sCodigoInterno"
            Else
                Strsql = " SELECT CE.nSclClasificacionEconomicaID, A.sCodigoInterno AS CodigoActividad, A.sDescripcion AS sActividad, TA.sDescripcion AS TipoClasificacion " & _
                         " FROM SclClasificacionEconomica as CE INNER JOIN StbValorCatalogo as TA ON CE.nStbTipoActividadEconomicaID = TA.nStbValorCatalogoID INNER JOIN StbValorCatalogo AS A ON CE.nStbActividadEconomicaID = A.nStbValorCatalogoID " & _
                         " WHERE (CE.nActiva = 1) or (CE.nSclClasificacionEconomicaID = " & intClasificacionID & ") " & _
                         " ORDER BY a.sCodigoInterno"
            End If

            If XdsUbicacion.ExistTable("Clasificacion") Then
                XdsUbicacion("Clasificacion").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Clasificacion")
                XdsUbicacion("Clasificacion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboClasificacion.DataSource = XdsUbicacion("Clasificacion").Source

            Me.cboClasificacion.Splits(0).DisplayColumns("nSclClasificacionEconomicaID").Visible = False
            Me.cboClasificacion.Splits(0).DisplayColumns("TipoClasificacion").Visible = False

            Me.cboClasificacion.Splits(0).DisplayColumns("CodigoActividad").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboClasificacion.Splits(0).DisplayColumns("CodigoActividad").Width = 47
            Me.cboClasificacion.Splits(0).DisplayColumns("sActividad").Width = 100

            Me.cboClasificacion.Columns("CodigoActividad").Caption = "Código"
            Me.cboClasificacion.Columns("sActividad").Caption = "Descripción"

            Me.cboClasificacion.Splits(0).DisplayColumns("CodigoActividad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboClasificacion.Splits(0).DisplayColumns("sActividad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       CargarTipoNegocio
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Negocio en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoNegocio()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'ClaseNegocio')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsUbicacion.ExistTable("TipoNegocio") Then
                XdsUbicacion("TipoNegocio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "TipoNegocio")
                XdsUbicacion("TipoNegocio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoNegocio.DataSource = XdsUbicacion("TipoNegocio").Source

            Me.cboTipoNegocio.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoNegocio.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoNegocio.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboTipoNegocio.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoNegocio.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoNegocio.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoNegocio.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoNegocio.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2009
    ' Procedure Name:       CargarCausasNoTieneNegocio
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       causas de inexistencia actual del negocio.
    '-------------------------------------------------------------------------
    Private Sub CargarCausasNoTieneNegocio()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'CausasInexistenciaNegocio')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsUbicacion.ExistTable("CausasNoTieneNegocio") Then
                XdsUbicacion("CausasNoTieneNegocio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "CausasNoTieneNegocio")
                XdsUbicacion("CausasNoTieneNegocio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCausasInexistenciaNegocio.DataSource = XdsUbicacion("CausasNoTieneNegocio").Source

            Me.cboCausasInexistenciaNegocio.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboCausasInexistenciaNegocio.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboCausasInexistenciaNegocio.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboCausasInexistenciaNegocio.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboCausasInexistenciaNegocio.Columns("sCodigoInterno").Caption = "Código"
            Me.cboCausasInexistenciaNegocio.Columns("sDescripcion").Caption = "Descripción"

            Me.cboCausasInexistenciaNegocio.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCausasInexistenciaNegocio.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
    ' Procedure Name:       CargarModalidadNegocio
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       modalidades de Negocio en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarModalidadNegocio()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'ModalidadNegocio')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsUbicacion.ExistTable("ModalidadNegocio") Then
                XdsUbicacion("ModalidadNegocio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "ModalidadNegocio")
                XdsUbicacion("ModalidadNegocio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboModalidad.DataSource = XdsUbicacion("ModalidadNegocio").Source

            Me.cboModalidad.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboModalidad.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboModalidad.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboModalidad.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboModalidad.Columns("sCodigoInterno").Caption = "Código"
            Me.cboModalidad.Columns("sDescripcion").Caption = "Descripción"

            Me.cboModalidad.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboModalidad.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/07/2009
    ' Procedure Name:       CargarTipoEjecucion
    ' Descripción:          Este procedimiento permite cargar el listado de Tipo
    '                       de Ejecucion de Fondos.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoEjecucion()
        Try
            Dim Strsql As String = ""
            'If Me.RdEjecucionSi.Checked Then
            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoEjecucionFondos')" & _
                     " ORDER BY a.sCodigoInterno" '(a.sCodigoInterno <> '3')
            'Else 'Solo muestra Sin Ejecutar
            'Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
            '         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
            '         " WHERE (a.sCodigoInterno = '3') And (b.sNombre = 'TipoEjecucionFondos')" & _
            '         " ORDER BY a.sCodigoInterno"
            'End If

            If XdsUbicacion.ExistTable("TipoEjecucion") Then
                XdsUbicacion("TipoEjecucion").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "TipoEjecucion")
                XdsUbicacion("TipoEjecucion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoEjecucion.DataSource = XdsUbicacion("TipoEjecucion").Source

            Me.cboTipoEjecucion.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoEjecucion.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoEjecucion.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboTipoEjecucion.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoEjecucion.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoEjecucion.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoEjecucion.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoEjecucion.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cdeFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFecha.TextChanged
        vbModifico = True
        'Limpiar Datos Socia:
        Me.txtNombreSocia.Text = ""
        Me.txtNombreGrupo.Text = ""
        Me.txtDireccion.Text = ""
        Me.txtNoCredito.Text = ""
        Me.txtFichaNotificacionDetalleID.Text = "0"
        Me.txtMontoA.Text = ""
        Me.txtNegocioA.Text = ""
    End Sub

    Private Sub txtCuotasAtrasadas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuotasAtrasadas.KeyPress
        Try
            'Solo numeros: 
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtCuotasCanceladas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCuotasCanceladas.KeyPress
        Try
            'Solo numeros: 
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    
    Private Sub txtUltimoRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUltimoRecibo.KeyPress
        Try
            'Solo numeros: 
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim XcDatosB As New BOSistema.Win.XComando
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim StrFecha As String
            Dim Strsql As String = ""
            Me.errFicha.Clear()

            'Limpiar Datos Socia:
            Me.txtNombreSocia.Text = ""
            Me.txtNombreGrupo.Text = ""
            Me.txtDireccion.Text = ""
            Me.txtNoCredito.Text = ""
            Me.txtFichaNotificacionDetalleID.Text = "0"
            Me.txtNegocioA.Text = ""
            Me.txtMontoA.Text = ""

            'Imposible si no se ha indicado Fecha válida:
            If Not IsDate(Me.cdeFecha.Value) Then
                MsgBox("Debe indicar una Fecha válida.", MsgBoxStyle.Information, NombreSistema)
                Me.cdeFecha.Focus()
                Exit Sub
            End If

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Fecha Valida en la Cédula:
            StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
            If Not IsDate(StrFecha) Then
                MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Número de Cédula Válido:
            Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                Case Cedula.Invalida
                    MsgBox("El Número de Cédula de la Socia es invalido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.mtbNumCedula.Focus()
                    Exit Sub
                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    Me.mtbNumCedula.Focus()
                    Exit Sub
            End Select

            'Localizar el Ultimo Detalle de FNC APROBADA para la Cedula y menor o igual a la fecha indicada:
            Strsql = "SELECT ISNULL(MAX(SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), 0) AS UltimoDetalle " & _
                     "FROM SclSocia INNER JOIN SclGrupoSocia ON SclSocia.nSclSociaID = SclGrupoSocia.nSclSociaID INNER JOIN SclFichaNotificacionCredito INNER JOIN SclFichaNotificacionDetalle " & _
                     "ON SclFichaNotificacionCredito.nSclFichaNotificacionID = SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionDetalle.nCreditoRechazado = 0) " & _
                     "AND (CONVERT(Varchar(10), SclFichaNotificacionCredito.dFechaNotificacion, 112) <= CONVERT(Varchar(10), '" & Format(Me.cdeFecha.Value, "yyyy-MM-dd") & "', 112)) " & _
                     "AND (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            Me.txtFichaNotificacionDetalleID.Text = XcDatosB.ExecuteScalar(Strsql)

            'Si no se encontro Ficha:
            If Me.txtFichaNotificacionDetalleID.Text = "0" Then
                MsgBox("No se encontro Crédito Aprobado para la Socia indicada" & Chr(13) & _
                       "con fecha menor o igual a " & Format(Me.cdeFecha.Value, "dd/MM/yyyy") & ".", MsgBoxStyle.Critical, NombreSistema)
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Ubicar Datos Socia con base en el detalle de Ficha de Notificacion Localizado: 
            Strsql = "SELECT SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sDireccionSocia, SclGrupoSolidario.sDescripcion AS GrupoSolidario, SclFichaNotificacionDetalle.nMontoCreditoAprobado, StbValorCatalogo.sDescripcion AS Actividad " & _
                     "FROM  SclFichaNotificacionDetalle INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID " & _
                     "INNER JOIN SclSocia ON SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID INNER JOIN SclGrupoSolidario ON SclGrupoSocia.nSclGrupoSolidarioID = SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbActividadEconomicaVerificadaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = " & Me.txtFichaNotificacionDetalleID.Text & ")"
            If RegistrosAsociados(Strsql) Then
                '1. Ubicar Info de Socia:
                XdtSocia.ExecuteSql(Strsql)
                Me.txtNombreSocia.Text = XdtSocia.ValueField("Socia")
                Me.txtNombreGrupo.Text = XdtSocia.ValueField("GrupoSolidario")
                Me.txtDireccion.Text = XdtSocia.ValueField("sDireccionSocia")
                Me.txtNegocioA.Text = XdtSocia.ValueField("Actividad")
                Me.txtMontoA.Text = XdtSocia.ValueField("nMontoCreditoAprobado")

                '2. Calcula No. de Creditos otorgados a la fecha de la Ficha:
                Strsql = "SELECT ISNULL(COUNT(SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), 0) AS UltimoDetalle " & _
                         "FROM SclSocia INNER JOIN SclGrupoSocia ON SclSocia.nSclSociaID = SclGrupoSocia.nSclSociaID INNER JOIN SclFichaNotificacionCredito INNER JOIN SclFichaNotificacionDetalle " & _
                         "ON SclFichaNotificacionCredito.nSclFichaNotificacionID = SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionDetalle.nCreditoRechazado = 0) " & _
                         "AND (CONVERT(Varchar(10), SclFichaNotificacionCredito.dFechaNotificacion, 112) <= CONVERT(Varchar(10), '" & Format(Me.cdeFecha.Value, "yyyy-MM-dd") & "', 112)) " & _
                         "AND (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
                Me.txtNoCredito.Text = XcDatosB.ExecuteScalar(Strsql)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosB.Close()
            XcDatosB = Nothing

            XdtSocia.Close()
            XdtSocia = Nothing
        End Try
    End Sub

    Private Sub RdPagosSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdPagosSi.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub RdEjecucionSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdEjecucionSi.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub RdRegistrosSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdRegistrosSi.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub RdRegistrosNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdRegistrosNo.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub txtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelefono.TextChanged
        vbModifico = True
    End Sub

    Private Sub mtbNumCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumCedula.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoNegocio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoNegocio.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtUbicacionNegocio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUbicacionNegocio.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoEjecucion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoEjecucion.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtJustificacionSubejecucion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJustificacionSubejecucion.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtInversion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInversion.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtRegistros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRegistros.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtCuotasAtrasadas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuotasAtrasadas.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtCuotasCanceladas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCuotasCanceladas.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtUltimoRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUltimoRecibo.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClasificacion.TextChanged
        vbModifico = True
        Me.txtTipoClasificacion.Text = Me.cboClasificacion.Columns("TipoClasificacion").Value
    End Sub

    Private Sub RdRegistrosSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdRegistrosSi.Click
        If Me.RdRegistrosSi.Checked = True Then
            Me.txtRegistros.Enabled = False
            Me.txtRegistros.BackColor = Color.WhiteSmoke
            Me.txtRegistros.Text = ""
        Else
            Me.txtRegistros.Enabled = True
            Me.txtRegistros.BackColor = Color.White
        End If
    End Sub

    Private Sub RdRegistrosNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdRegistrosNo.Click
        If Me.RdRegistrosNo.Checked = True Then
            Me.txtRegistros.Enabled = True
            Me.txtRegistros.BackColor = Color.White
        Else
            Me.txtRegistros.Enabled = False
            Me.txtRegistros.BackColor = Color.WhiteSmoke
            Me.txtRegistros.Text = ""
        End If
    End Sub

    Private Sub RdEjecucionSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdEjecucionSi.Click
        Try
            If Me.RdEjecucionSi.Checked Then 'Ya inicio la ejecucion de fondos
                Me.txtInversion.Enabled = True
                Me.txtInversion.BackColor = Color.White
                Me.txtJustificacionSubejecucion.Enabled = False
                Me.txtJustificacionSubejecucion.BackColor = Color.WhiteSmoke
                Me.txtJustificacionSubejecucion.Text = ""
                'Habilitar Bloque de Negocio:
                Me.grpNegocio.Enabled = True
                'Habilitar Bloque de Registro Contable SI tiene negocio:
                If Me.rdTieneNegocioNo.Checked Then
                    Me.grpRegistroContable.Enabled = False
                    'Habilitar Causas de la Inexistencia:
                    Me.cboCausasInexistenciaNegocio.Enabled = True
                Else
                    Me.grpRegistroContable.Enabled = True
                    'DesHabilitar Causas de la Inexistencia:
                    Me.cboCausasInexistenciaNegocio.Enabled = False
                    Me.cboCausasInexistenciaNegocio.Text = ""
                End If
            Else
                Me.txtJustificacionSubejecucion.Enabled = True
                Me.txtJustificacionSubejecucion.BackColor = Color.White
                Me.txtInversion.Enabled = False
                Me.txtInversion.BackColor = Color.WhiteSmoke
                Me.txtInversion.Text = ""
                'Desabilitar Bloque de Negocio:
                Me.grpNegocio.Enabled = False
                Me.cboClasificacion.Text = ""
                Me.txtTipoClasificacion.Text = ""
                Me.cboTipoNegocio.Text = ""
                Me.cboModalidad.Text = ""
                Me.txtUbicacionNegocio.Text = ""
                Me.rdTieneNegocioNo.Checked = True
                'Desabilitar Bloque de Registro Contable con NO:
                Me.grpRegistroContable.Enabled = False
                Me.RdRegistrosNo.Checked = True
                'DesHabilitar Causas de la Inexistencia:
                Me.cboCausasInexistenciaNegocio.Text = ""
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub RdEjecucionNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdEjecucionNo.Click
        Try
            If Me.RdEjecucionNo.Checked Then 'NO se inicio la ejecucion de fondos
                Me.txtJustificacionSubejecucion.Enabled = True
                Me.txtJustificacionSubejecucion.BackColor = Color.White
                Me.txtInversion.Enabled = False
                Me.txtInversion.BackColor = Color.WhiteSmoke
                Me.txtInversion.Text = ""
                'Desabilitar Bloque de Negocio:
                Me.grpNegocio.Enabled = False
                Me.cboClasificacion.Text = ""
                Me.txtTipoClasificacion.Text = ""
                Me.cboTipoNegocio.Text = ""
                Me.cboModalidad.Text = ""
                Me.txtUbicacionNegocio.Text = ""
                Me.rdTieneNegocioNo.Checked = True
                'DesHabilitar Causas de la Inexistencia:
                Me.cboCausasInexistenciaNegocio.Text = ""
                'Desabilitar Bloque de Registro Contable con NO:
                Me.grpRegistroContable.Enabled = False
                Me.RdRegistrosNo.Checked = True
            Else 'Ya inicio la ejecucion de fondos
                Me.txtInversion.Enabled = True
                Me.txtInversion.BackColor = Color.White
                Me.txtJustificacionSubejecucion.Enabled = False
                Me.txtJustificacionSubejecucion.BackColor = Color.WhiteSmoke
                Me.txtJustificacionSubejecucion.Text = ""
                'Habilitar Bloque de Negocio:
                Me.grpNegocio.Enabled = True
                'Habilitar Bloque de Registro Contable SI tiene negocio:
                If Me.rdTieneNegocioNo.Checked Then
                    Me.grpRegistroContable.Enabled = False
                    'Habilitar Causas de la Inexistencia:
                    Me.cboCausasInexistenciaNegocio.Enabled = True
                Else
                    Me.grpRegistroContable.Enabled = True
                    'DesHabilitar Causas de la Inexistencia:
                    Me.cboCausasInexistenciaNegocio.Enabled = False
                    Me.cboCausasInexistenciaNegocio.Text = ""
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub RdPagosSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdPagosSi.Click
        Try
            If Me.RdPagosSi.Checked Then
                Me.txtCuotasAtrasadas.Enabled = False
                Me.txtCuotasAtrasadas.BackColor = Color.WhiteSmoke
                Me.txtCuotasAtrasadas.Text = "0"
            Else
                Me.txtCuotasAtrasadas.Enabled = True
                Me.txtCuotasAtrasadas.BackColor = Color.White
            End If
            vbModifico = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub RdPagosNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RdPagosNo.Click
        Try
            If Me.RdPagosNo.Checked Then
                Me.txtCuotasAtrasadas.Enabled = True
                Me.txtCuotasAtrasadas.BackColor = Color.White
            Else
                Me.txtCuotasAtrasadas.Enabled = False
                Me.txtCuotasAtrasadas.BackColor = Color.WhiteSmoke
                Me.txtCuotasAtrasadas.Text = "0"
            End If
            vbModifico = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboTecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTecnico.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboModalidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModalidad.TextChanged
        vbModifico = True
    End Sub

    Private Sub rdTieneNegocioSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTieneNegocioSi.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub rdTieneNegocioNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdTieneNegocioNo.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub rdTieneNegocioSi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTieneNegocioSi.Click
        Try
            If Me.rdTieneNegocioSi.Checked Then 'TIENE negocio en la actualidad
                'Habilitar Bloque de Registro Contable:
                Me.grpRegistroContable.Enabled = True
                'Si esta en no tiene registros habilitar causas:
                If Me.RdRegistrosNo.Checked Then
                    Me.txtRegistros.Enabled = True
                Else
                    Me.txtRegistros.Enabled = False
                End If
                'DesHabilitar Causas de la Inexistencia:
                Me.cboCausasInexistenciaNegocio.Enabled = False
                Me.cboCausasInexistenciaNegocio.Text = ""
            Else
                'Desabilitar Bloque de Registro Contable con NO:
                Me.grpRegistroContable.Enabled = False
                Me.RdRegistrosNo.Checked = True
                Me.txtRegistros.Text = ""
                'Habilitar Causas de la Inexistencia:
                Me.cboCausasInexistenciaNegocio.Enabled = True
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rdTieneNegocioNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdTieneNegocioNo.Click
        Try
            If Me.rdTieneNegocioNo.Checked Then 'NO TIENE negocio en la actualidad
                'Desabilitar Bloque de Registro Contable con NO:
                Me.grpRegistroContable.Enabled = False
                Me.RdRegistrosNo.Checked = True
                Me.txtRegistros.Text = ""
                'Habilitar Causas de la Inexistencia:
                Me.cboCausasInexistenciaNegocio.Enabled = True
            Else
                'Habilitar Bloque de Registro Contable:
                Me.grpRegistroContable.Enabled = True
                'Si esta en no tiene registros habilitar causas:
                If Me.RdRegistrosNo.Checked Then
                    Me.txtRegistros.Enabled = True
                Else
                    Me.txtRegistros.Enabled = False
                End If
                'DesHabilitar Causas de la Inexistencia:
                Me.cboCausasInexistenciaNegocio.Enabled = False
                Me.cboCausasInexistenciaNegocio.Text = ""
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboCausasInexistenciaNegocio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCausasInexistenciaNegocio.TextChanged
        vbModifico = True
    End Sub
End Class