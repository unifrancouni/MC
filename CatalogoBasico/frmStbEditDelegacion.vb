' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                08/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbEditDelegacion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Delegaciones del Programa.
'-------------------------------------------------------------------------
Public Class frmStbEditDelegacion

    '-- Declaración de Variables:
    Dim ModoForm As String 'ADD/MOD
    Dim IdStbDelegacion As Integer

    '-- Clases para procesar la información de los combos:
    Dim XdsEmpleado As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas):
    Dim ObjDelegaciondt As BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaDataTable
    Dim ObjDelegaciondr As BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaRow

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para identificar si el formulario se utiliza  
    'para Agregar o bien Modificar los datos de la Delegación.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Delegación.
    Public Property IdDelegacion() As Long
        Get
            IdDelegacion = IdStbDelegacion
        End Get
        Set(ByVal value As Long)
            IdStbDelegacion = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       frmStbEditDelegacion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditDelegacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjDelegaciondt.Close()
                ObjDelegaciondt = Nothing

                ObjDelegaciondr.Close()
                ObjDelegaciondr = Nothing

                XdsEmpleado.Close()
                XdsEmpleado = Nothing

                XdsUbicacion.Close()
                XdsUbicacion = Nothing

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
    ' Fecha:                08/02/2008
    ' Procedure Name:       frmSclEditSocia_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditDelegacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarDepartamento(0)
            CargarFirmas(0, "FirmaUno")
            CargarFirmas(0, "FirmaDos")
            CargarFirmas(0, "FirmaTres")

            CargarFirmas(0, "RevisaCD")
            CargarFirmas(0, "AutorizaCD")
            CargarFirmas(0, "FirmaTesorero")
            CargarFirmas(0, "NotificaSocias")

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarDelegacion()
                InhabilitarControles()
            End If

            Me.cboDepartamento.Select()
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
    ' Fecha:                08/02/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            'Si esta Inactiva:
            If ObjDelegaciondr.nActiva = 0 Then
                Me.cmdAceptar.Enabled = False
                Me.grpGenerales.Enabled = False
                Me.grpComiteCredito.Enabled = False
                Me.grpComprobantes.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Delegación del Programa"
            Else
                Me.Text = "Modificar Delegación del Programa"
            End If

            XdsEmpleado = New BOSistema.Win.XDataSet
            XdsUbicacion = New BOSistema.Win.XDataSet

            ObjDelegaciondt = New BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaDataTable
            ObjDelegaciondr = New BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaRow


            'Limpiar los combos:
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboFirma1.ClearFields()
            Me.cboFirma2.ClearFields()
            Me.cboFirma3.ClearFields()
            Me.cboRevisaCD.ClearFields()
            Me.cboAutorizaCD.ClearFields()
            Me.cboNotificaSocias.ClearFields()
            Me.CboFirmaTesorero.ClearFields()
            If ModoFrm = "ADD" Then
                ObjDelegaciondr = ObjDelegaciondt.NewRow
                'Inicializar los Length de los campos (Strings)
                Me.txtUbicacion.MaxLength = ObjDelegaciondr.GetColumnLenght("sUbicacionDelegacion")
                Me.txtDireccion.MaxLength = ObjDelegaciondr.GetColumnLenght("sDireccionUbicacion")
                Me.txtTelefono.MaxLength = ObjDelegaciondr.GetColumnLenght("sTelefonoUbicacion")
                Me.txtUnidadNotificadora.MaxLength = ObjDelegaciondr.GetColumnLenght("sNombreUnidadNotificadora")
                Me.txtNombre.MaxLength = ObjDelegaciondr.GetColumnLenght("sNombreDelegacion")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       CargarDelegacion
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarDelegacion()
        Dim Strsql As String
        Dim IdDepartamento As Long
        Dim XcUbicacion As New BOSistema.Win.XComando

        Try

            '-- Buscar la Delegación correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjDelegaciondt.Filter = "nStbDelegacionProgramaID = " & IdDelegacion
            ObjDelegaciondt.Retrieve()
            If ObjDelegaciondt.Count = 0 Then
                Exit Sub
            End If
            ObjDelegaciondr = ObjDelegaciondt.Current

            'Codigo:
            If Not ObjDelegaciondr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjDelegaciondr.nCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Cargar Combo de Departamento:
            If Not ObjDelegaciondr.IsFieldNull("nStbMunicipioID") Then
                'Cargar Dpto:
                Strsql = " SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & ObjDelegaciondr.nStbMunicipioID & ")"
                IdDepartamento = XcUbicacion.ExecuteScalar(Strsql)
                CargarDepartamento(IdDepartamento)
                If cboDepartamento.ListCount > 0 Then
                    Me.cboDepartamento.SelectedIndex = 0
                End If
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XcUbicacion.ExecuteScalar(Strsql))
            Else
                Me.cboDepartamento.Text = ""
                Me.cboDepartamento.SelectedIndex = -1
            End If

            'Cargar Combo de Municipio:
            If Not ObjDelegaciondr.IsFieldNull("nStbMunicipioID") Then
                If Me.cboMunicipio.ListCount > 0 Then
                    Me.cboMunicipio.SelectedIndex = 0
                End If
                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", ObjDelegaciondr.nStbMunicipioID)
            Else
                Me.cboMunicipio.Text = ""
                Me.cboMunicipio.SelectedIndex = -1
            End If

            'Ubicación:
            If Not ObjDelegaciondr.IsFieldNull("sUbicacionDelegacion") Then
                Me.txtUbicacion.Text = ObjDelegaciondr.sUbicacionDelegacion
            Else
                Me.txtUbicacion.Text = ""
            End If

            'Dirección:
            If Not ObjDelegaciondr.IsFieldNull("sDireccionUbicacion") Then
                Me.txtDireccion.Text = ObjDelegaciondr.sDireccionUbicacion
            Else
                Me.txtDireccion.Text = ""
            End If

            'Telefono:
            If Not ObjDelegaciondr.IsFieldNull("sTelefonoUbicacion") Then
                Me.txtTelefono.Text = ObjDelegaciondr.sTelefonoUbicacion
            Else
                Me.txtTelefono.Text = ""
            End If

            'Nombre Delegación: 
            If Not ObjDelegaciondr.IsFieldNull("sNombreDelegacion") Then
                Me.txtNombre.Text = ObjDelegaciondr.sNombreDelegacion
            Else
                Me.txtNombre.Text = ""
            End If

            'Unidad Notificadora:
            If Not ObjDelegaciondr.IsFieldNull("sNombreUnidadNotificadora") Then
                Me.txtUnidadNotificadora.Text = ObjDelegaciondr.sNombreUnidadNotificadora
            Else
                Me.txtUnidadNotificadora.Text = ""
            End If

            'Primer Firma (Empleado de Comité de Crédito):
            If Not ObjDelegaciondr.IsFieldNull("nSrhEmpleadoFirmaAComiteID") Then
                If Me.cboFirma1.ListCount > 0 Then
                    Me.cboFirma1.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaUno").SetCurrentByID("nSrhEmpleadoID", ObjDelegaciondr.nSrhEmpleadoFirmaAComiteID)
            Else
                Me.cboFirma1.Text = ""
                Me.cboFirma1.SelectedIndex = -1
            End If

            'Segunda Firma (Empleado de Comité de Crédito):
            If Not ObjDelegaciondr.IsFieldNull("nSrhEmpleadoFirmaBComiteID") Then
                If Me.cboFirma2.ListCount > 0 Then
                    Me.cboFirma2.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaDos").SetCurrentByID("nSrhEmpleadoID", ObjDelegaciondr.nSrhEmpleadoFirmaBComiteID)
            Else
                Me.cboFirma2.Text = ""
                Me.cboFirma2.SelectedIndex = -1
            End If

            'Tercer Firma (Empleado de Comité de Crédito):
            If Not ObjDelegaciondr.IsFieldNull("nSrhEmpleadoFirmaCComiteID") Then
                If Me.cboFirma3.ListCount > 0 Then
                    Me.cboFirma3.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaTres").SetCurrentByID("nSrhEmpleadoID", ObjDelegaciondr.nSrhEmpleadoFirmaCComiteID)
            Else
                Me.cboFirma3.Text = ""
                Me.cboFirma3.SelectedIndex = -1
            End If

            'Revisa Comprobantes:
            If Not ObjDelegaciondr.IsFieldNull("nSrhEmpleadoRevisaComprobantesID") Then
                If Me.cboRevisaCD.ListCount > 0 Then
                    Me.cboRevisaCD.SelectedIndex = 0
                End If
                XdsEmpleado("RevisaCD").SetCurrentByID("nSrhEmpleadoID", ObjDelegaciondr.nSrhEmpleadoRevisaComprobantesID)
            Else
                Me.cboRevisaCD.Text = ""
                Me.cboRevisaCD.SelectedIndex = -1
            End If

            'Autoriza Comprobantes:
            If Not ObjDelegaciondr.IsFieldNull("nSrhEmpleadoAutorizaComprobantesID") Then
                If Me.cboAutorizaCD.ListCount > 0 Then
                    Me.cboAutorizaCD.SelectedIndex = 0
                End If
                XdsEmpleado("AutorizaCD").SetCurrentByID("nSrhEmpleadoID", ObjDelegaciondr.nSrhEmpleadoAutorizaComprobantesID)
            Else
                Me.cboAutorizaCD.Text = ""
                Me.cboAutorizaCD.SelectedIndex = -1
            End If

            'Firma del Tesorero
            If Not ObjDelegaciondr.IsFieldNull("nSrhEmpleadoFirmaTesoreroID") Then
                If Me.CboFirmaTesorero.ListCount > 0 Then
                    Me.CboFirmaTesorero.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaTesorero").SetCurrentByID("nSrhEmpleadoID", ObjDelegaciondr.nSrhEmpleadoFirmaTesoreroID)
            Else
                Me.CboFirmaTesorero.Text = ""
                Me.CboFirmaTesorero.SelectedIndex = -1
            End If

            'Notifica Socias:
            If Not ObjDelegaciondr.IsFieldNull("nSrhEmpleadoNotificaSociasID") Then
                If Me.cboNotificaSocias.ListCount > 0 Then
                    Me.cboNotificaSocias.SelectedIndex = 0
                End If
                XdsEmpleado("NotificaSocias").SetCurrentByID("nSrhEmpleadoID", ObjDelegaciondr.nSrhEmpleadoNotificaSociasID)
            Else
                Me.cboNotificaSocias.Text = ""
                Me.cboNotificaSocias.SelectedIndex = -1
            End If

            'Permitir Consultar todas las Delegaciones:            
            If Not ObjDelegaciondr.IsFieldNull("nAccesoTotalLectura") Then
                Me.chkConsultar.Checked = ObjDelegaciondr.nAccesoTotalLectura
            End If

            'Permitir Modificar todas las Delegaciones:            
            If Not ObjDelegaciondr.IsFieldNull("nAccesoTotalEdicion") Then
                Me.chkModificar.Checked = ObjDelegaciondr.nAccesoTotalEdicion
            End If

            'Inicializar los Length de los campos
            Me.txtUbicacion.MaxLength = ObjDelegaciondr.GetColumnLenght("sUbicacionDelegacion")
            Me.txtDireccion.MaxLength = ObjDelegaciondr.GetColumnLenght("sDireccionUbicacion")
            Me.txtTelefono.MaxLength = ObjDelegaciondr.GetColumnLenght("sTelefonoUbicacion")
            Me.txtUnidadNotificadora.MaxLength = ObjDelegaciondr.GetColumnLenght("sNombreUnidadNotificadora")
            Me.txtNombre.MaxLength = ObjDelegaciondr.GetColumnLenght("sNombreDelegacion")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarDelegacion()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            ValidaDatosEntrada = True
            Me.errDelegacion.Clear()

            'Departamento:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Departamento de la Delegación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboDepartamento, "Debe seleccionar Departamento.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Municipio de la Delegación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboMunicipio, "Debe seleccionar Municipio.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Nombre Delegación: 
            If Trim(RTrim(Me.txtNombre.Text)).ToString.Length = 0 Then
                MsgBox("Nombre de Delegación NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.txtNombre, "Nombre de Delegación NO DEBE quedar vacío.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Unidad Notificadora Obligatoria:
            If Trim(RTrim(Me.txtUnidadNotificadora.Text)).ToString.Length = 0 Then
                MsgBox("Unidad Notificadora de Créditos NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.txtUnidadNotificadora, "Unidad Notificadora de Créditos NO DEBE quedar vacía.")
                Me.txtUnidadNotificadora.Focus()
                Exit Function
            End If

            'Ubicación Obligatoria:
            If Trim(RTrim(Me.txtUbicacion.Text)).ToString.Length = 0 Then
                MsgBox("Ubicación de la Delegación NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.txtUbicacion, "Ubicación de la Delegación NO DEBE quedar vacía.")
                Me.txtUbicacion.Focus()
                Exit Function
            End If

            'Dirección Obligatoria:
            If Trim(RTrim(Me.txtDireccion.Text)).ToString.Length = 0 Then
                MsgBox("Dirección NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.txtDireccion, "Dirección NO DEBE quedar vacía.")
                Me.txtDireccion.Focus()
                Exit Function
            End If

            'Primer Firma:
            If Me.cboFirma1.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Primer Firma del Comité de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboFirma1, "Debe seleccionar Primer Firma del Comité de Crédito.")
                Me.cboFirma1.Focus()
                Exit Function
            End If

            'Segunda Firma:
            If Me.cboFirma2.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Segunda Firma del Comité de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboFirma2, "Debe seleccionar Segunda Firma del Comité de Crédito.")
                Me.cboFirma2.Focus()
                Exit Function
            End If

            'Tercer Firma:
            If Me.cboFirma3.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Tercer Firma del Comité de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboFirma3, "Debe seleccionar Tercer Firma del Comité de Crédito.")
                Me.cboFirma3.Focus()
                Exit Function
            End If

            'Revisa Comprobantes:
            If Me.cboRevisaCD.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar responsable de revisar" & Chr(13) & "Comprobantes de Diario de la Delegación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboRevisaCD, "Debe seleccionar Responsable de Revisión de Comprobantes de Diario.")
                Me.cboRevisaCD.Focus()
                Exit Function
            End If

            'Autoriza Comprobantes:
            If Me.cboAutorizaCD.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar responsable de autorizar" & Chr(13) & "Comprobantes de Diario de la Delegación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboAutorizaCD, "Debe seleccionar Responsable de Autorización de Comprobantes de Diario.")
                Me.cboAutorizaCD.Focus()
                Exit Function
            End If

            'Firma de Tesorero:
            If Me.CboFirmaTesorero.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar la Firma del Tesorero" & Chr(13) & " de la Delegación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.CboFirmaTesorero, "Debe seleccionar la Firma del Tesorero.")
                Me.CboFirmaTesorero.Focus()
                Exit Function
            End If

            'Notifica Socias:
            If Me.cboNotificaSocias.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar responsable de notificar créditos" & Chr(13) & "a socias (firma en ficha de notificación de créditos).", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.cboNotificaSocias, "Debe seleccionar Responsable de Autorización de Comprobantes de Diario.")
                Me.cboNotificaSocias.Focus()
                Exit Function
            End If

            'Si se indica Modificar todas las Delegaciones DEBE indicar Consultar:
            If (chkModificar.Checked = True) And (chkConsultar.Checked = False) Then
                MsgBox("Imposible modificar todas las Delegaciones sin" & Chr(13) & "acceso de Consulta a las mismas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDelegacion.SetError(Me.chkConsultar, "Debe indicar permiso de Consulta.")
                Me.chkConsultar.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       SalvarDelegacion
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Delegación en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarDelegacion()
        Dim ObjTmpDelegacion As New BOSistema.Win.XDataSet
        Try
            Dim strSQL As String

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjDelegaciondr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjDelegaciondr.dFechaCreacion = FechaServer()
            Else
                ObjDelegaciondr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjDelegaciondr.dFechaModificacion = FechaServer()
            End If

            'Delegación Activa:
            ObjDelegaciondr.nActiva = 1

            'Permitir Consultar todas las Delegaciones:
            If Me.chkConsultar.Checked Then
                ObjDelegaciondr.nAccesoTotalLectura = 1
            Else
                ObjDelegaciondr.nAccesoTotalLectura = 0
            End If

            'Permitir Modificar todas las Delegaciones:
            If Me.chkModificar.Checked Then
                ObjDelegaciondr.nAccesoTotalEdicion = 1
            Else
                ObjDelegaciondr.nAccesoTotalEdicion = 0
            End If

            'Ubicación Geográfica:
            ObjDelegaciondr.nStbMunicipioID = Me.cboMunicipio.Columns("nStbMunicipioID").Value

            'Firma 1:
            ObjDelegaciondr.nSrhEmpleadoFirmaAComiteID = Me.cboFirma1.Columns("nSrhEmpleadoID").Value

            'Firma 2:
            ObjDelegaciondr.nSrhEmpleadoFirmaBComiteID = Me.cboFirma2.Columns("nSrhEmpleadoID").Value

            'Firma 3:
            ObjDelegaciondr.nSrhEmpleadoFirmaCComiteID = Me.cboFirma3.Columns("nSrhEmpleadoID").Value

            'Revisa Comprobantes:
            ObjDelegaciondr.nSrhEmpleadoRevisaComprobantesID = Me.cboRevisaCD.Columns("nSrhEmpleadoID").Value

            'Autoriza Comprobantes:
            ObjDelegaciondr.nSrhEmpleadoAutorizaComprobantesID = Me.cboAutorizaCD.Columns("nSrhEmpleadoID").Value

            'Firma de Tesorero:
            ObjDelegaciondr.nSrhEmpleadoFirmaTesoreroID = Me.CboFirmaTesorero.Columns("nSrhEmpleadoID").Value

            'Notifica Socias:
            ObjDelegaciondr.nSrhEmpleadoNotificaSociasID = Me.cboNotificaSocias.Columns("nSrhEmpleadoID").Value

            'Ubicación:
            ObjDelegaciondr.sUbicacionDelegacion = Trim(RTrim(Me.txtUbicacion.Text))

            'Dirección Ubicación:
            ObjDelegaciondr.sDireccionUbicacion = Trim(RTrim(Me.txtDireccion.Text))

            'Telefóno:
            If Trim(RTrim(Me.txtTelefono.Text)).ToString.Length <> 0 Then
                ObjDelegaciondr.sTelefonoUbicacion = Trim(RTrim(Me.txtTelefono.Text))
            Else
                ObjDelegaciondr.sTelefonoUbicacion = ""
            End If

            'Nombre Delegación: 
            ObjDelegaciondr.sNombreDelegacion = Trim(RTrim(Me.txtNombre.Text))

            'Unidad Notificadora:
            ObjDelegaciondr.sNombreUnidadNotificadora = Trim(RTrim(Me.txtUnidadNotificadora.Text))

            'Asignación del Código siguiente:
            If ModoForm = "ADD" Then
                strSQL = " SELECT max(nCodigo) as maxCodigo FROM StbDelegacionPrograma"
                If ObjTmpDelegacion.ExistTable("Delegacion") Then
                    ObjTmpDelegacion("Delegacion").ExecuteSql(strSQL)
                Else
                    ObjTmpDelegacion.NewTable(strSQL, "Delegacion")
                    ObjTmpDelegacion("Delegacion").Retrieve()
                End If

                If Not ObjTmpDelegacion("Delegacion").ValueField("maxCodigo") Is DBNull.Value Then
                    Me.txtCodigo.Text = Format(ObjTmpDelegacion("Delegacion").ValueField("maxCodigo") + 1)
                Else
                    Me.txtCodigo.Text = "1"
                End If
            End If

            'Codigo
            ObjDelegaciondr.nCodigo = Me.txtCodigo.Text

            ObjDelegaciondr.Update()
            'Asignar el Id de la Delegación a la variable publica del formulario
            IdStbDelegacion = ObjDelegaciondr.nStbDelegacionProgramaID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpDelegacion.Close()
            ObjTmpDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
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
                            SalvarDelegacion()
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
    ' Fecha:                08/02/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento(ByVal intDepartamentoID As Integer)
        Try
            Dim Strsql As String

            If intDepartamentoID = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) Or (a.nStbDepartamentoID = " & intDepartamentoID & ") " & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            'Configurar el combo Departamento:
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMunicipio.ClearFields()

            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & _
                             " ) And (a.nActivo = 1) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where ((a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                             " ) Or (a.nStbMunicipioID = " & intMunicipioID & _
                             " )  Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Municipio") Then
                XdsUbicacion("Municipio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Municipio")
                XdsUbicacion("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsUbicacion("Municipio").Source
            Me.cboMunicipio.Rebind()

            'Configurar el combo Municipio:
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("sNombre").Caption = "Descripción"
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       CargarFirmas
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Empleados:
    '                       (Firma1); StrNombre = FirmaUno
    '                       (Firma2); StrNombre = FirmaDos
    '                       (Firma3); StrNombre = FirmaTres
    '                       (Revisa Comprobantes); StrNombre = RevisaCD    
    '                       (Autoriza Comprobantes); StrNombre = AutorizaCD 
    '                       (Notifica Socias); StrNombre = NotificaSocias
    '-------------------------------------------------------------------------
    Private Sub CargarFirmas(ByVal intEmpleadoID As Integer, ByVal StrNombre As String)
        Try

            Dim Strsql As String

            If StrNombre = "FirmaUno" Then
                Me.cboFirma1.ClearFields()
            ElseIf StrNombre = "FirmaDos" Then
                Me.cboFirma2.ClearFields()
            ElseIf StrNombre = "FirmaTres" Then
                Me.cboFirma3.ClearFields()
            ElseIf StrNombre = "RevisaCD" Then
                Me.cboRevisaCD.ClearFields()
            ElseIf StrNombre = "AutorizaCD" Then
                Me.cboAutorizaCD.ClearFields()
            ElseIf StrNombre = "FirmaTesorero" Then
                Me.CboFirmaTesorero.ClearFields()
            Else 'NotificaSocias
                Me.cboNotificaSocias.ClearFields()
            End If

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

            If XdsEmpleado.ExistTable(StrNombre) Then
                XdsEmpleado(StrNombre).ExecuteSql(Strsql)
            Else
                XdsEmpleado.NewTable(Strsql, StrNombre)
                XdsEmpleado(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos:
            If StrNombre = "FirmaUno" Then
                Me.cboFirma1.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboFirma1.Rebind()
            ElseIf StrNombre = "FirmaDos" Then
                Me.cboFirma2.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboFirma2.Rebind()
            ElseIf StrNombre = "FirmaTres" Then
                Me.cboFirma3.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboFirma3.Rebind()
            ElseIf StrNombre = "RevisaCD" Then
                Me.cboRevisaCD.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboRevisaCD.Rebind()
            ElseIf StrNombre = "AutorizaCD" Then
                Me.cboAutorizaCD.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboAutorizaCD.Rebind()
            ElseIf StrNombre = "FirmaTesorero" Then
                Me.CboFirmaTesorero.DataSource = XdsEmpleado(StrNombre).Source
                Me.CboFirmaTesorero.Rebind()
            Else
                Me.cboNotificaSocias.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboNotificaSocias.Rebind()
            End If

            'Configurar el combo:
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

            ElseIf StrNombre = "FirmaTres" Then
                Me.cboFirma3.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma3.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma3.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            ElseIf StrNombre = "RevisaCD" Then
                Me.cboRevisaCD.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboRevisaCD.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboRevisaCD.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboRevisaCD.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboRevisaCD.Columns("nCodPersona").Caption = "Código"
                Me.cboRevisaCD.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboRevisaCD.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboRevisaCD.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            ElseIf StrNombre = "AutorizaCD" Then
                Me.cboAutorizaCD.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboAutorizaCD.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboAutorizaCD.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboAutorizaCD.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboAutorizaCD.Columns("nCodPersona").Caption = "Código"
                Me.cboAutorizaCD.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboAutorizaCD.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboAutorizaCD.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ElseIf StrNombre = "FirmaTesorero" Then
                Me.CboFirmaTesorero.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.CboFirmaTesorero.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.CboFirmaTesorero.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.CboFirmaTesorero.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.CboFirmaTesorero.Columns("nCodPersona").Caption = "Código"
                Me.CboFirmaTesorero.Columns("sNombre").Caption = "Nombre Empleado"
                Me.CboFirmaTesorero.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.CboFirmaTesorero.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                Me.cboNotificaSocias.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboNotificaSocias.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboNotificaSocias.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboNotificaSocias.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboNotificaSocias.Columns("nCodPersona").Caption = "Código"
                Me.cboNotificaSocias.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboNotificaSocias.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboNotificaSocias.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()+) BackSpace y la Barra espaciadora
    Private Sub txtUbicacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUbicacion.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Nombre de la Ubicacion:
    Private Sub txtUbicacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUbicacion.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Números, () , - BackSpace y la Barra espaciadora
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

    'Se indica que hubo modificación en la Dirección
    Private Sub txtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelefono.TextChanged
        vbModifico = True
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboDepartamento_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboDepartamento.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboMunicipio_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboMunicipio.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        vbModifico = True
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboFirma1_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFirma1.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboFirma1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma1.TextChanged
        vbModifico = True
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboFirma2_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFirma2.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboFirma2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma2.TextChanged
        vbModifico = True
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboFirma3_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFirma3.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboFirma3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma3.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()+) BackSpace y la Barra espaciadora
    Private Sub txtUnidadNotificadora_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUnidadNotificadora.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtUnidadNotificadora_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnidadNotificadora.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()+) BackSpace y la Barra espaciadora
    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccion.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccion.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()+) BackSpace y la Barra espaciadora
    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboRevisaCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRevisaCD.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboAutorizaCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAutorizaCD.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboNotificaSocias_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboNotificaSocias.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboNotificaSocias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNotificaSocias.TextChanged
        vbModifico = True
    End Sub
End Class