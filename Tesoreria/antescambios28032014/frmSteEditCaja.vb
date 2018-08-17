' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                07/01/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditCaja.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Cajas del Programa.
'-------------------------------------------------------------------------
Public Class frmSteEditCaja

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSteCaja As Integer

    '-- Crear un data table de tipo Xdataset
    Dim ObjCajadt As BOSistema.Win.SteEntArqueo.SteCajaDataTable
    Dim ObjCajadr As BOSistema.Win.SteEntArqueo.SteCajaRow

    '-- Crear un data table de tipo Xdataset para Combos
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    Dim IntPermiteEditar As Integer

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener Permisos de edición fuera de la Delegación.
    Public Property intStePermiteEditar() As Long
        Get
            intStePermiteEditar = IntPermiteEditar
        End Get
        Set(ByVal value As Long)
            IntPermiteEditar = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Caja
    Public Property IdCaja() As Integer
        Get
            IdCaja = IdSteCaja
        End Get
        Set(ByVal value As Integer)
            IdSteCaja = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/01/2008
    ' Procedure Name:       frmSteEditCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjCajadt.Close()
                ObjCajadt = Nothing

                ObjCajadr.Close()
                ObjCajadr = Nothing

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
    ' Fecha:                07/01/2008
    ' Procedure Name:       frmSteEditCaja_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Caja en caso de estar en el modo
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento(0)
            CargarLugarPagos(0)
            CargarTipoPrograma()
            CargarTipoPlazoPagos()

            'Si el formulario está en modo edición:
            'cargar los datos de la Caja.
            If ModoFrm <> "ADD" Then
                CargarCaja()
                'Si la Caja no se encuentra Abierta:
                InhabilitarControles()
            End If

            Me.cboTipoPrograma.Select()
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
    ' Fecha:                07/01/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Si la Caja no se encuentra Abierta:
            Strsql = "SELECT nCerrada FROM SteCaja WHERE (nSteCajaID = " & IdSteCaja & ")"
            If (XcDatos.ExecuteScalar(Strsql) = 1) Then
                Me.cmdAceptar.Enabled = False
                Me.grpGenerales.Enabled = False
                Me.grpLocalizacion.Enabled = False
                Me.grpCierre.Enabled = False
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
    ' Fecha:                07/01/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Registro de Datos de Caja"
            ElseIf ModoFrm = "UPD" Then
                Me.Text = "Modificar Datos de Caja"
            Else
                Me.Text = "Inactivar Caja"
            End If

            ObjCajadt = New BOSistema.Win.SteEntArqueo.SteCajaDataTable
            ObjCajadr = New BOSistema.Win.SteEntArqueo.SteCajaRow

            XdsUbicacion = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboBarrio.ClearFields()
            Me.cboMercado.ClearFields()
            Me.cboLugarPagos.ClearFields()
            Me.cboTipoPrograma.ClearFields()
            Me.cboTipoPlazoPagos.ClearFields()

            If ModoFrm = "ADD" Then
                ObjCajadr = ObjCajadt.NewRow
                'Inicializar los Length de los campos String:
                Me.txtNombre.MaxLength = ObjCajadr.GetColumnLenght("sDescripcionCaja")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/01/2008
    ' Procedure Name:       CargarCaja
    ' Descripción:          Este procedimiento permite cargar los datos de la 
    '                       Caja seleccionada en caso de estar en Modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCaja()
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim Strsql As String
        Dim IdMunicipio As Long
        Dim IdDepartamento As Long

        Try
            '-- Buscar Caja correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjCajadt.Filter = "nSteCajaID = " & IdSteCaja
            ObjCajadt.Retrieve()
            If ObjCajadt.Count = 0 Then
                Exit Sub
            End If
            ObjCajadr = ObjCajadt.Current
            
            'Codigo 
            Me.txtCodigo.Text = ObjCajadr.nCodigo

            'Descripcion
            Me.txtNombre.Text = ObjCajadr.sDescripcionCaja

            '-- Cargar Ubicación Geográfica:
            'Cargar Combo de Departamentos:
            If Not ObjCajadr.IsFieldNull("nStbBarrioID") Then
                'Determinar Id de Municipio:
                Strsql = " SELECT nStbMunicipioID FROM StbBarrio WHERE (nStbBarrioID = " & ObjCajadr.nStbBarrioID & ")"
                IdMunicipio = XcUbicacion.ExecuteScalar(Strsql)
                'Cargar Dpto:
                Strsql = " SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & IdMunicipio & ")"
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
            'Cargar Combo de Municipios:
            If Not ObjCajadr.IsFieldNull("nStbBarrioID") Then
                CargarMunicipio(0, IdMunicipio)
                If cboMunicipio.ListCount > 0 Then
                    Me.cboMunicipio.SelectedIndex = 0
                End If
                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", IdMunicipio)
            Else
                Me.cboMunicipio.Text = ""
                Me.cboMunicipio.SelectedIndex = -1
            End If
            'Cargar Combo de Distritos: 
            If Not ObjCajadr.IsFieldNull("nStbBarrioID") Then
                Strsql = " SELECT nStbDistritoID FROM StbBarrio WHERE (nStbBarrioID = " & ObjCajadr.nStbBarrioID & ")"
                CargarDistrito(0, XcUbicacion.ExecuteScalar(Strsql))
                If cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                End If
                XdsUbicacion("Distrito").SetCurrentByID("nStbDistritoID", XcUbicacion.ExecuteScalar(Strsql))
            Else
                Me.cboDistrito.Text = ""
                Me.cboDistrito.SelectedIndex = -1
            End If
            'Cargar Combo de Barrios:
            If Not ObjCajadr.IsFieldNull("nStbBarrioID") Then
                CargarBarrio(0, ObjCajadr.nStbBarrioID)
                If cboBarrio.ListCount > 0 Then
                    Me.cboBarrio.SelectedIndex = 0
                End If
                XdsUbicacion("Barrio").SetCurrentByID("nStbBarrioID", ObjCajadr.nStbBarrioID)
            Else
                Me.cboBarrio.Text = ""
                Me.cboBarrio.SelectedIndex = -1
            End If
            'Cargar Combo de Mercados:
            If Not ObjCajadr.IsFieldNull("nStbMercadoID") Then
                CargarMercado(0, ObjCajadr.nStbMercadoID)
                If cboMercado.ListCount > 0 Then
                    Me.cboMercado.SelectedIndex = 0
                End If
                XdsUbicacion("Mercado").SetCurrentByID("nStbMercadoID", ObjCajadr.nStbMercadoID)
            Else
                Me.cboMercado.Text = ""
                Me.cboMercado.SelectedIndex = -1
            End If

            'Lugar de Pagos:
            If Not ObjCajadr.IsFieldNull("nStbPersonaLugarPagosID") Then
                CargarLugarPagos(ObjCajadr.nStbPersonaLugarPagosID)
                If Me.cboLugarPagos.ListCount > 0 Then
                    Me.cboLugarPagos.SelectedIndex = 0
                End If
                XdsUbicacion("LugarPagos").SetCurrentByID("nStbPersonaID", ObjCajadr.nStbPersonaLugarPagosID)
            Else
                Me.cboLugarPagos.Text = ""
                Me.cboLugarPagos.SelectedIndex = -1
            End If

            'Cargar Combo de Tipo de Programa:
            If Not ObjCajadr.IsFieldNull("nStbTipoProgramaID") Then
                CargarTipoPrograma()
                If Me.cboTipoPrograma.ListCount > 0 Then
                    Me.cboTipoPrograma.SelectedIndex = 0
                End If
                XdsUbicacion("TipoPrograma").SetCurrentByID("nStbValorCatalogoID", ObjCajadr.nStbTipoProgramaID)
            Else
                Me.cboTipoPrograma.Text = ""
                Me.cboTipoPrograma.SelectedIndex = -1
            End If

            'Tipo Plazo Pagos Socias:
            If Not ObjCajadr.IsFieldNull("nStbTipoPlazoPagosID") Then
                CargarTipoPlazoPagos()
                If Me.cboTipoPlazoPagos.ListCount > 0 Then
                    Me.cboTipoPlazoPagos.SelectedIndex = 0
                End If
                XdsUbicacion("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", ObjCajadr.nStbTipoPlazoPagosID)
            Else
                Me.cboTipoPlazoPagos.Text = ""
                Me.cboTipoPlazoPagos.SelectedIndex = -1
            End If

            'Fecha de Apertura:
            If Not ObjCajadr.IsFieldNull("dFechaApertura") Then
                Me.cdeFechaA.Value = ObjCajadr.dFechaApertura
            Else
                Me.cdeFechaA.Value = Me.cdeFechaA.ValueIsDbNull
            End If

            'En caso de Edición:
            If ModoFrm = "UPD" Then
                'Indicador de Caja Cerrada:
                If Not ObjCajadr.IsFieldNull("nCerrada") Then
                    Me.chkCerrada.Checked = ObjCajadr.nCerrada
                End If
            End If
            
            'Fecha de Cierre:
            If Not ObjCajadr.IsFieldNull("dFechaCierre") Then
                Me.cdeFechaC.Value = ObjCajadr.dFechaCierre
            Else
                Me.cdeFechaC.Value = Me.cdeFechaA.ValueIsDbNull
            End If

            'Inicializar los Length de los campos:
            Me.txtNombre.MaxLength = ObjCajadr.GetColumnLenght("sDescripcionCaja")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/01/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCaja()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/01/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            ValidaDatosEntrada = True
            Dim StrSql As String
            Me.errCaja.Clear()

            'Fecha de Apertura:
            If Me.cdeFechaA.ValueIsDbNull Then
                MsgBox("La Fecha de Apertura NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cdeFechaA, "La Fecha de Apertura NO DEBE quedar vacía.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Apertura no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Apertura NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cdeFechaA, "La Fecha de Apertura NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Apertura no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Apertura NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cdeFechaA, "La Fecha de Apertura NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Tipo de Programa:
            If Me.cboTipoPrograma.SelectedIndex = -1 Then
                MsgBox("Debe indicar el Tipo de Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboTipoPrograma, "Debe indicar el Tipo de Programa.")
                Me.cboTipoPrograma.Focus()
                Exit Function
            End If

            'Plazo de periodicidad de pagos:
            If Me.cboTipoPlazoPagos.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo para Pagos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                Me.cboTipoPlazoPagos.Focus()
                Exit Function
            End If

            'El Plazo debe existir dentro del Programa seleccionado:
            StrSql = "SELECT nStbTipoProgramaID FROM SclTipodePlandeNegocio " & _
                     "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No existe esta Periodicidad de Pagos en el Tipo de Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                Me.cboTipoPlazoPagos.Focus()
                Exit Function
            End If

            'Descripción:
            If Trim(RTrim(Me.txtNombre.Text)).ToString.Length = 0 Then
                MsgBox("La Descripción de la Caja NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.txtNombre, "La Descripción de la Caja NO DEBE quedar vacía.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Indicar Departamento:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Departamento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboDepartamento, "Debe indicar un Departamento.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Indicar Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Municipio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboMunicipio, "Debe indicar un Municipio.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Debe existir Delegacion para el Dpto:
            StrSql = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                     "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                     "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No existe una Delegación registrada" & Chr(13) & "para el Departamento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboDepartamento, "Delegación Invalida.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            REM REM
            'Si NO tiene permisos de Edición fuera de su Delegación: 
            'El Municipio seleccionado Debe corresponder con el de la Delegación del usuario:
            'If IntPermiteEditar = 0 Then
            '    StrSql = "SELECT nStbMunicipioID FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            '    If cboMunicipio.Columns("nStbMunicipioId").Value <> XcDatos.ExecuteScalar(StrSql) Then
            '        MsgBox("Municipio no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errCaja.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
            '        Me.cboMunicipio.Focus()
            '        Exit Function
            '    End If
            'End If

            'Cambio: 17/Marzo/2009 Pruebas Azucena.
            'Si NO tiene permisos de Edición fuera de su Delegación: 
            'El Departamento seleccionado Debe corresponder con el de la Delegación del usuario:
            If IntPermiteEditar = 0 Then
                StrSql = "SELECT StbMunicipio.nStbDepartamentoID " & _
                         "FROM  StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                         "WHERE (StbDelegacionPrograma.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                If cboDepartamento.Columns("nStbDepartamentoID").Value <> XcDatos.ExecuteScalar(StrSql) Then
                    MsgBox("Departamento no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCaja.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Function
                End If
            End If

            'Indicar Distrito:
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Distrito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboDistrito, "Debe indicar un Distrito.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            'Indicar Barrio:
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Barrio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboBarrio, "Debe indicar un Barrio.")
                Me.cboBarrio.Focus()
                Exit Function
            End If

            'Indicar Mercado:
            If Me.cboMercado.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Mercado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboMercado, "Debe indicar un Mercado.")
                Me.cboMercado.Focus()
                Exit Function
            End If

            'Indicar Lugar de Pagos:
            If Me.cboLugarPagos.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Lugar de Pagos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboLugarPagos, "Debe indicar un Lugar de Pagos.")
                Me.cboLugarPagos.Focus()
                Exit Function
            End If

            'No permitir el mismo lugar de pagos para mas de una Caja
            'para el Programa y Periodicidad de Pagos.
            StrSql = "SELECT * FROM SteCaja " & _
                     "WHERE (nStbPersonaLugarPagosID = " & Me.cboLugarPagos.Columns("nStbPersonaID").Value & ") " & _
                     "AND (nSteCajaID <> " & IdSteCaja & ") AND (nCerrada = 0) " & _
                     "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                     "AND (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Lugar de pagos esta asociado a otra Caja Activa" & Chr(13) & "en este Programa y Periodicidad de Pagos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCaja.SetError(Me.cboLugarPagos, "Lugar de pagos esta asociado a otra Caja Activa.")
                Me.cboLugarPagos.Focus()
                Exit Function
            End If

            'Si se indica Cierre de Caja: 
            If chkCerrada.Checked = True Then
                'Indicar Fecha de Cierre:
                If Me.cdeFechaC.ValueIsDbNull Then
                    MsgBox("La Fecha de Cierre NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCaja.SetError(Me.cdeFechaC, "La Fecha de Cierre NO DEBE quedar vacía.")
                    Me.cdeFechaC.Focus()
                    Exit Function
                End If
                'Fecha Cierre no menor que la fecha de inicio del Programa:
                If BlnFechaInferiorParametros(Format(Me.cdeFechaC.Value, "yyyy-MM-dd")) Then
                    MsgBox("La Fecha de Cierre NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCaja.SetError(Me.cdeFechaC, "La Fecha de Cierre NO DEBE ser menor a la de inicio del Programa.")
                    Me.cdeFechaC.Focus()
                    Exit Function
                End If
                'Fecha Cierre no mayor que la fecha de corte en parámetros:
                If BlnFechaSuperiorParametros(Format(Me.cdeFechaC.Value, "yyyy-MM-dd")) Then
                    MsgBox("La Fecha de Cierre NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCaja.SetError(Me.cdeFechaC, "La Fecha de Cierre NO DEBE ser mayor a la de corte en parámetros.")
                    Me.cdeFechaC.Focus()
                    Exit Function
                End If
                'Fecha de Cierre mayor que Fecha de Apertura:
                If Me.cdeFechaC.Value <= cdeFechaA.Value Then
                    MsgBox("Fecha de Cierre DEBE ser superior" & Chr(13) & "a la de Apertura de la Caja.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCaja.SetError(Me.cdeFechaC, "Fecha de Cierre DEBE ser superior a la de Apertura de la Caja.")
                    Me.cdeFechaC.Focus()
                    Exit Function
                End If
                'La Fecha de Cierre No debe ser inferior a la de los Arqueos generados:
                StrSql = "SELECT * FROM SteArqueoCaja " & _
                         "WHERE (nSteCajaID = " & IdCaja & ") AND (dFechaArqueo > CONVERT(DATETIME, '" & Format(Me.cdeFechaC.Value, "yyyy-MM-dd") & "', 102))"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Existen Arqueos con Fecha superior a la" & Chr(13) & "Fecha de Cierre indicada.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCaja.SetError(Me.cdeFechaC, "Existen Arqueos con Fecha superior.")
                    Me.cdeFechaC.Focus()
                    Exit Function
                End If

            End If

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
    ' Fecha:                07/01/2008
    ' Procedure Name:       SalvarCaja
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Caja en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCaja()
        Dim ObjTmpCaja As New BOSistema.Win.XDataSet
        Dim XcDelegacion As New BOSistema.Win.XComando
        Try
            Dim strSQL As String

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjCajadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjCajadr.dFechaCreacion = FechaServer()
                '-- Delegación de la Caja:
                'No se ubica en el Update ya que podria estar modificando datos
                'un usuario de otra Delegación si esta tiene Acceso Total para
                'Edición con lo que se alteraría la Delegación de la Solicitud.
                REM ObjCajadr.nStbDelegacionProgramaID = InfoSistema.IDDelegacion
                strSQL = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                         "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                         "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
                ObjCajadr.nStbDelegacionProgramaID = XcDelegacion.ExecuteScalar(strSQL)

            Else
                ObjCajadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjCajadr.dFechaModificacion = FechaServer()


                strSQL = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                      "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                      "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
                ObjCajadr.nStbDelegacionProgramaID = XcDelegacion.ExecuteScalar(strSQL)
            End If

            'Fecha de Apertura: 
            ObjCajadr.dFechaApertura = Format(Me.cdeFechaA.Value, "yyyy-MM-dd")

            'Tipo de Programa:
            ObjCajadr.nStbTipoProgramaID = Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value

            'Plazo de Pagos:
            ObjCajadr.nStbTipoPlazoPagosID = Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value

            'Descripción:
            ObjCajadr.sDescripcionCaja = Trim(RTrim(Me.txtNombre.Text))
            
            'Indicador de Caja Cerrada:
            If Me.chkCerrada.Checked Then
                ObjCajadr.nCerrada = 1
                ObjCajadr.dFechaCierre = Format(cdeFechaC.Value, "yyyy-MM-dd")
            Else
                ObjCajadr.nCerrada = 0
                ObjCajadr.SetFieldNull("dFechaCierre")
            End If

            'Ubicación Caja:
            ObjCajadr.nStbBarrioID = Me.cboBarrio.Columns("nStbBarrioID").Value
            ObjCajadr.nStbMercadoID = Me.cboMercado.Columns("nStbMercadoID").Value
            ObjCajadr.nStbPersonaLugarPagosID = Me.cboLugarPagos.Columns("nStbPersonaID").Value

            'Asignación del Código siguiente:
            If ModoForm = "ADD" Then
                strSQL = " SELECT max(nCodigo) as maxCodigo FROM SteCaja"
                If ObjTmpCaja.ExistTable("Caja") Then
                    ObjTmpCaja("Caja").ExecuteSql(strSQL)
                Else
                    ObjTmpCaja.NewTable(strSQL, "Caja")
                    ObjTmpCaja("Caja").Retrieve()
                End If

                If Not ObjTmpCaja("Caja").ValueField("maxCodigo") Is DBNull.Value Then
                    Me.txtCodigo.Text = Format(ObjTmpCaja("Caja").ValueField("maxCodigo") + 1) ', "00"
                Else
                    Me.txtCodigo.Text = "1"
                End If
            End If

            'Código:
            ObjCajadr.nCodigo = Me.txtCodigo.Text

            ObjCajadr.Update()
            'Asignar el Id de la Caja a variable publica:
            IdSteCaja = ObjCajadr.nSteCajaID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Caja ID: " & Me.IdSteCaja & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpCaja.Close()
            ObjTmpCaja = Nothing

            XcDelegacion.Close()
            XcDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/01/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables: 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarCaja()
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

    'Solo se permite Letras A - Z, BackSpace 
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

    'Se indica que hubo modificación en la Descripción del Documento Soporte
    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub

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
        Else
            CargarDistrito(1, 0)
            CargarBarrio(1, 0)
            CargarMercado(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex <> -1 Then
            CargarBarrio(0, 0)
        Else
            CargarBarrio(1, 0)
            CargarMercado(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrio.TextChanged
        If Me.cboBarrio.SelectedIndex <> -1 Then
            CargarMercado(0, 0)
        Else
            CargarMercado(1, 0)
        End If
        vbModifico = True
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/01/2007
    ' Procedure Name:       CargarLugarPagos
    ' Descripción:          Este procedimiento permite cargar el listado de lugares
    '                       para Pagos de Cuotas de un GS.
    '-------------------------------------------------------------------------
    Private Sub CargarLugarPagos(ByVal intPersonaID As Integer)
        Try
            Dim Strsql As String
            Me.cboLugarPagos.ClearFields()

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

            If XdsUbicacion.ExistTable("LugarPagos") Then
                XdsUbicacion("LugarPagos").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "LugarPagos")
                XdsUbicacion("LugarPagos").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboLugarPagos.DataSource = XdsUbicacion("LugarPagos").Source
            Me.cboLugarPagos.Rebind()
            'Configurar el Combo:
            Me.cboLugarPagos.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            Me.cboLugarPagos.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboLugarPagos.Splits(0).DisplayColumns("nCodPersona").Width = 50
            Me.cboLugarPagos.Splits(0).DisplayColumns("sNombre").Width = 150
            Me.cboLugarPagos.Columns("nCodPersona").Caption = "Código"
            Me.cboLugarPagos.Columns("sNombre").Caption = "Institución"
            Me.cboLugarPagos.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboLugarPagos.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/09/2007
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento(ByVal intDepartamentoID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If intDepartamentoID = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where ((a.nActivo = 1) AND (a.nPertenecePrograma = 1)) or (a.nStbDepartamentoID = " & intDepartamentoID & ") " & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos: 
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro:
            If XdsUbicacion("Departamento").Count > 0 Then
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

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
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMunicipio.ClearFields()

            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where ((a.nActivo = 1) And (a.nPertenecePrograma = 1) And  (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & "))" & _
                             " Or (a.nStbMunicipioID = " & intMunicipioID & _
                             " ) Order by a.sCodigo"
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

            'Asignando a las fuentes de datos:
            Me.cboMunicipio.DataSource = XdsUbicacion("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro:
            If XdsUbicacion("Municipio").Count > 0 Then
                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

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
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de Distritos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
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
            Else 'Limpiar = 0 Qry No regresa ningun Distrito:
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Distrito") Then
                XdsUbicacion("Distrito").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Distrito")
                XdsUbicacion("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDistrito.DataSource = XdsUbicacion("Distrito").Source
            Me.cboDistrito.Rebind()

            'Configurar el combo Distritos:
            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").Width = 80
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
    ' Fecha:                14/12/2009
    ' Procedure Name:       CargarTipoPrograma
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Programas.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPrograma()
        Try
            Dim Strsql As String = ""

            'Limpiar Combo:
            Me.cboTipoPrograma.ClearFields()

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoDePrograma') " & _
                     " ORDER BY a.sCodigoInterno"

            If XdsUbicacion.ExistTable("TipoPrograma") Then
                XdsUbicacion("TipoPrograma").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "TipoPrograma")
                XdsUbicacion("TipoPrograma").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboTipoPrograma.DataSource = XdsUbicacion("TipoPrograma").Source
            Me.cboTipoPrograma.Rebind()

            'Configurar el combo:
            Me.cboTipoPrograma.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPrograma.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboTipoPrograma.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboTipoPrograma.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoPrograma.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPrograma.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPrograma.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPrograma.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2010
    ' Procedure Name:       CargarTipoPlazoPagos
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección de periodicidad
    '                       de pagos de las socias.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPlazoPagos()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""
            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsUbicacion.ExistTable("TipoPlazoPagos") Then
                XdsUbicacion("TipoPlazoPagos").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "TipoPlazoPagos")
                XdsUbicacion("TipoPlazoPagos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPlazoPagos.DataSource = XdsUbicacion("TipoPlazoPagos").Source
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarse en Periodicidad Semanal:
            XdtValorParametro.Filter = "nStbParametroID = 6"
            XdtValorParametro.Retrieve()
            If XdsUbicacion("TipoPlazoPagos").Count > 0 Then
                XdsUbicacion("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sDescripcion").Width = 70

            Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazoPagos.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarBarrio(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBarrio.ClearFields()

            If intLimpiarID = 0 Then
                If intBarrioID = 0 Then
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & ")) " & _
                             " Or (a.nStbBarrioID = " & intBarrioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbBarrio a " & _
                         " Where a.nStbBarrioID = 0"
            End If

            If XdsUbicacion.ExistTable("Barrio") Then
                XdsUbicacion("Barrio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Barrio")
                XdsUbicacion("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboBarrio.DataSource = XdsUbicacion("Barrio").Source
            Me.cboBarrio.Rebind()

            'Configurar el combo Barrio:
            Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
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
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("Barrio").ValueField("nStbBarrioID") & _
                             " )) Or (a.nStbMercadoID = 1) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                             " From StbMercado a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("Barrio").ValueField("nStbBarrioID") & _
                             " ) Or (a.nStbMercadoID = 1)) Or (a.nStbMercadoID = " & intMercadoID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                         " From StbMercado a " & _
                         " Where a.nStbMercadoID = 0"
            End If

            If XdsUbicacion.ExistTable("Mercado") Then
                XdsUbicacion("Mercado").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Mercado")
                XdsUbicacion("Mercado").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboMercado.DataSource = XdsUbicacion("Mercado").Source
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

            'Ubicarlo en el primer registro:
            If Me.cboMercado.ListCount > 0 Then
                Me.cboMercado.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboMercado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMercado.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaA.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboLugarPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLugarPagos.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkCerrada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCerrada.CheckedChanged
        vbModifico = True
    End Sub

    'Para controlar la ubicación del foco en el checkbox:
    Private Sub chkCerrada_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCerrada.GotFocus
        Try
            Me.chkCerrada.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Para controlar cuando el checkbox pierde el foco:
    Private Sub chkCerrada_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCerrada.LostFocus
        Try
            Me.chkCerrada.BackColor = Me.grpGenerales.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cdeFechaC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaC.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPrograma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPrograma.TextChanged
        vbModifico = True
    End Sub

    Private Sub cmdAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

    End Sub

    Private Sub cboTipoPlazoPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazoPagos.TextChanged
        vbModifico = True
    End Sub
End Class