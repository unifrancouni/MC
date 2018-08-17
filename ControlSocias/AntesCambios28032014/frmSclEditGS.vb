' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                05/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditGS.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Grupos Solidarios.
'-------------------------------------------------------------------------
Public Class frmSclEditGS

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSclGrupoSolidario As Long
    Dim IdStbBarrioVerificado As Long
    Dim IntPermiteEditarFNC As Integer
    Const TipoGrupo As Int16 = 59


    '-- Crear un data table de tipo Xdataset
    Dim ObjGrupoSolidariodt As BOSistema.Win.SclEntSocia.SclGrupoSolidarioDataTable
    Dim ObjGrupoSolidariodr As BOSistema.Win.SclEntSocia.SclGrupoSolidarioRow

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
    'Agregar o bien Modificar los datos de Doc. Soporte.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
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

    'Propiedad utilizada para obtener el ID de Grupo Solidario que corresponde al campo
    'SclGrupoSolidarioID de la tabla SclGrupoSolidario.
    Public Property IdGrupoSolidario() As Long
        Get
            IdGrupoSolidario = IdSclGrupoSolidario
        End Get
        Set(ByVal value As Long)
            IdSclGrupoSolidario = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Barrio Verificado actual
    'StbBarrioVerificadoID de la tabla SclGrupoSolidario.
    Public Property IdBarrioVerificado() As Long
        Get
            IdBarrioVerificado = IdStbBarrioVerificado
        End Get
        Set(ByVal value As Long)
            IdStbBarrioVerificado = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/09/2007
    ' Procedure Name:       frmSclEditGS_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditGS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjGrupoSolidariodt.Close()
                ObjGrupoSolidariodt = Nothing

                ObjGrupoSolidariodr.Close()
                ObjGrupoSolidariodr = Nothing

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
    ' Fecha:                05/09/2007
    ' Procedure Name:       frmSclEditGS_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Grupo Solidario en caso de estar en
    '                       el modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditGS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento(0)
            CargarDepartamentoV(0)
            CargarClasificacion(0)

            'Si el formulario está en modo edición
            'cargar los datos del Grupo Solidario.
            If ModoForm = "ADD" Then
                grpGS.Enabled = True
                grpLocalizacion.Enabled = True
                grpLocalizacionV.Enabled = False
            Else
                CargarGrupoSolidario()
                grpGS.Enabled = True
                grpLocalizacion.Enabled = False
                grpLocalizacionV.Enabled = True
                'Si el Grupo Solidario no se encuentra en Proceso:
                InhabilitarControles()
            End If

            'Me.cboClasificacion.Select()
            Me.txtDescripcion.Select()

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
    ' Fecha:                07/09/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Seg.RefreshPermissions()
            'Si el GS no se encuentra en Proceso:
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoGrupo' "
            If ObjGrupoSolidariodr.nStbEstadoGrupoID <> XcDatos.ExecuteScalar(Strsql) Then

                Dim Enabled As Boolean = Seg.HasPermission("ModificarLocalizacionVGS")

                Me.CmdAceptar.Enabled = Enabled
                Me.grpGS.Enabled = False
                Me.grpLocalizacion.Enabled = False
                Me.grpLocalizacionV.Enabled = Enabled
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
    ' Fecha:                05/09/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Grupo Solidario"
            ElseIf ModoFrm = "UPD" Then
                Me.Text = "Modificar Grupo Solidario"
            End If

            ObjGrupoSolidariodt = New BOSistema.Win.SclEntSocia.SclGrupoSolidarioDataTable
            ObjGrupoSolidariodr = New BOSistema.Win.SclEntSocia.SclGrupoSolidarioRow

            XdsUbicacion = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboBarrio.ClearFields()
            Me.cboMercado.ClearFields()
            Me.cboClasificacion.ClearFields()

            Me.cboDepartamentoV.ClearFields()
            Me.cboMunicipioV.ClearFields()
            Me.cboDistritoV.ClearFields()
            Me.cboBarrioV.ClearFields()
            Me.cboMercadoV.ClearFields()

            If ModoFrm = "ADD" Then
                ObjGrupoSolidariodr = ObjGrupoSolidariodt.NewRow
                'Inicializar los Length de los campos
                Me.txtDescripcion.MaxLength = ObjGrupoSolidariodr.GetColumnLenght("sDescripcion")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/09/2007
    ' Procedure Name:       CargarGrupoSolidario
    ' Descripción:          Este procedimiento permite cargar los datos del Grupo
    '                       Solidario seleccionado en caso de estar en Modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarGrupoSolidario()
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim Strsql As String
        Dim IdMunicipio As Long
        Dim IdMunicipioV As Long
        Dim IdDepartamento As Long
        Dim IdDepartamentoV As Long
        Dim nCooperativa As Int32

        Try
            '-- Buscar el GS correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjGrupoSolidariodt.Filter = "nSclGrupoSolidarioID = " & IdSclGrupoSolidario
            ObjGrupoSolidariodt.Retrieve()
            If ObjGrupoSolidariodt.Count = 0 Then
                Exit Sub
            End If
            ObjGrupoSolidariodr = ObjGrupoSolidariodt.Current

            'Codigo 
            Me.txtCodigo.Text = ObjGrupoSolidariodr.sCodigo
            'Descripcion
            Me.txtDescripcion.Text = ObjGrupoSolidariodr.sDescripcion

            'Cargar Combo de Tipo de Plan de Negocio:
            If Not ObjGrupoSolidariodr.IsFieldNull("nSclTipodePlandeNegocioID") Then
                CargarClasificacion(ObjGrupoSolidariodr.nSclTipodePlandeNegocioID)
                If cboClasificacion.ListCount > 0 Then
                    Me.cboClasificacion.SelectedIndex = 0
                End If
                XdsUbicacion("Clase").SetCurrentByID("nSclTipodePlandeNegocioID", ObjGrupoSolidariodr.nSclTipodePlandeNegocioID)
            Else
                Me.cboClasificacion.Text = ""
                Me.cboClasificacion.SelectedIndex = -1
            End If

            'No permitir modificar el tipo de plan en caso de error: ANULAR-
            Me.cboClasificacion.Enabled = False

            '-- Cargar Ubicación Geográfica Original:
            'Cargar Combo de Departamentos:
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioID") Then
                'Determinar Id de Municipio:
                Strsql = " SELECT nStbMunicipioID FROM StbBarrio WHERE (nStbBarrioID = " & ObjGrupoSolidariodr.nStbBarrioID & ")"
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
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioID") Then
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
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioID") Then
                Strsql = " SELECT nStbDistritoID FROM StbBarrio WHERE (nStbBarrioID = " & ObjGrupoSolidariodr.nStbBarrioID & ")"
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
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioID") Then
                CargarBarrio(0, ObjGrupoSolidariodr.nStbBarrioID)
                If cboBarrio.ListCount > 0 Then
                    Me.cboBarrio.SelectedIndex = 0
                End If
                XdsUbicacion("Barrio").SetCurrentByID("nStbBarrioID", ObjGrupoSolidariodr.nStbBarrioID)
            Else
                Me.cboBarrio.Text = ""
                Me.cboBarrio.SelectedIndex = -1
            End If
            
            'Cargar Combo de Mercados:
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbMercadoID") Then
                Strsql = String.Format("SELECT nCooperativa FROM StbMercado sm WHERE sm.nStbMercadoID = {0}", ObjGrupoSolidariodr.nStbMercadoID)
                nCooperativa = XcUbicacion.ExecuteScalar(Strsql)

                If ObjGrupoSolidariodr.nStbMercadoID <> 1 Then
                    If nCooperativa = 1 Then
                        Me.rdbCooperativa.Checked = True
                    Else
                        Me.rdbMercado.Checked = True
                    End If
                Else
                    Me.rdbNoAplica.Checked = True
                End If

                CargarMercado(0, ObjGrupoSolidariodr.nStbMercadoID, nCooperativa)
                'If cboMercado.ListCount > 0 Then
                '    Me.cboMercado.SelectedIndex = 0
                'End If

                Me.cboMercado.SelectedValue = ObjGrupoSolidariodr.nStbMercadoID

                XdsUbicacion("Mercado").SetCurrentByID("nStbMercadoID", ObjGrupoSolidariodr.nStbMercadoID)
            Else
                Me.cboMercado.Text = ""
                Me.cboMercado.SelectedIndex = -1
            End If

            '-- Cargar Ubicación Geográfica Verificada:
            'Cargar Combo de Departamentos:
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioVerificadoID") Then
                'Determinar Id de Municipio:
                Strsql = " SELECT nStbMunicipioID FROM StbBarrio WHERE (nStbBarrioID = " & ObjGrupoSolidariodr.nStbBarrioVerificadoID & ")"
                IdMunicipioV = XcUbicacion.ExecuteScalar(Strsql)
                'Cargar Dpto:
                Strsql = " SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & IdMunicipioV & ")"
                IdDepartamentoV = XcUbicacion.ExecuteScalar(Strsql)
                CargarDepartamentoV(IdDepartamentoV)
                If cboDepartamentoV.ListCount > 0 Then
                    Me.cboDepartamentoV.SelectedIndex = 0
                End If
                XdsUbicacion("DepartamentoV").SetCurrentByID("nStbDepartamentoID", XcUbicacion.ExecuteScalar(Strsql))
            Else
                Me.cboDepartamentoV.Text = ""
                Me.cboDepartamentoV.SelectedIndex = -1
            End If
            'Cargar Combo de Municipios:
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioVerificadoID") Then
                CargarMunicipioV(0, IdMunicipioV)
                If cboMunicipioV.ListCount > 0 Then
                    Me.cboMunicipioV.SelectedIndex = 0
                End If
                XdsUbicacion("MunicipioV").SetCurrentByID("nStbMunicipioID", IdMunicipioV)
            Else
                Me.cboMunicipioV.Text = ""
                Me.cboMunicipioV.SelectedIndex = -1
            End If
            'Cargar Combo de Distritos:
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioVerificadoID") Then
                Strsql = " SELECT nStbDistritoID FROM StbBarrio WHERE (nStbBarrioID = " & ObjGrupoSolidariodr.nStbBarrioVerificadoID & ")"
                CargarDistritoV(0, XcUbicacion.ExecuteScalar(Strsql))
                If cboDistritoV.ListCount > 0 Then
                    Me.cboDistritoV.SelectedIndex = 0
                End If
                XdsUbicacion("DistritoV").SetCurrentByID("nStbDistritoID", XcUbicacion.ExecuteScalar(Strsql))
            Else
                Me.cboDistritoV.Text = ""
                Me.cboDistritoV.SelectedIndex = -1
            End If
            'Cargar Combo de Barrios:
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbBarrioVerificadoID") Then
                CargarBarrioV(0, ObjGrupoSolidariodr.nStbBarrioVerificadoID)
                If cboBarrioV.ListCount > 0 Then
                    Me.cboBarrioV.SelectedIndex = 0
                End If
                XdsUbicacion("BarrioV").SetCurrentByID("nStbBarrioID", ObjGrupoSolidariodr.nStbBarrioVerificadoID)
            Else
                Me.cboBarrioV.Text = ""
                Me.cboBarrioV.SelectedIndex = -1
            End If
            'Cargar Combo de Mercados:
            If Not ObjGrupoSolidariodr.IsFieldNull("nStbMercadoVerificadoID") Then

                Strsql = String.Format("SELECT nCooperativa FROM StbMercado sm WHERE sm.nStbMercadoID = {0}", ObjGrupoSolidariodr.nStbMercadoVerificadoID)
                nCooperativa = IIf(XcUbicacion.ExecuteScalar(Strsql) = True, 1, 0)

                If ObjGrupoSolidariodr.nStbMercadoVerificadoID <> 1 Then
                    If nCooperativa = 1 Then
                        Me.rdbCooperativaV.Checked = True
                    Else
                        Me.rdbMercadoV.Checked = True
                    End If
                Else
                    Me.rdbNoAplicaV.Checked = True
                End If

                CargarMercadoV(0, ObjGrupoSolidariodr.nStbMercadoVerificadoID, nCooperativa)
                'If cboMercadoV.ListCount > 0 Then
                '    Me.cboMercadoV.SelectedIndex = 0
                'End If
                Me.cboMercadoV.SelectedValue = ObjGrupoSolidariodr.nStbMercadoVerificadoID

                XdsUbicacion("MercadoV").SetCurrentByID("nStbMercadoID", ObjGrupoSolidariodr.nStbMercadoVerificadoID)
            Else 'Estado civil esta en Null.
                Me.cboMercadoV.Text = ""
                Me.cboMercadoV.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos:
            Me.txtDescripcion.MaxLength = ObjGrupoSolidariodr.GetColumnLenght("sDescripcion")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/09/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarGrupoSolidario()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/09/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            ValidaDatosEntrada = True
            Me.errGrupoSolidario.Clear()
            Dim StrSql As String

            'Indicar clasificación:
            If Me.cboClasificacion.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Tipo de Plan de Negocio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errGrupoSolidario.SetError(Me.cboClasificacion, "Debe indicar un Tipo de Plan de Negocio.")
                Me.cboClasificacion.Focus()
                Exit Function
            End If

            'Descripción:
            If Trim(RTrim(Me.txtDescripcion.Text)).ToString.Length = 0 Then
                MsgBox("El nombre del Grupo Solidario NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errGrupoSolidario.SetError(Me.txtDescripcion, "El nombre del Grupo Solidario NO DEBE quedar vacío.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            '-- Si es Adición del GS:
            If ModoFrm = "ADD" Then
                'Indicar Departamento:
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe indicar un Departamento.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboDepartamento, "Debe indicar un Departamento.")
                    Me.cboDepartamento.Focus()
                    Exit Function
                End If
                'Indicar Municipio:
                If Me.cboMunicipio.SelectedIndex = -1 Then
                    MsgBox("Debe indicar un Municipio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboMunicipio, "Debe indicar un Municipio.")
                    Me.cboMunicipio.Focus()
                    Exit Function
                End If
                'Debe existir Delegacion para el Dpto:
                StrSql = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                         "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                         "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("No existe Delegación para el Departamento.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboDepartamento, "Delegación Invalida.")
                    Me.cboDepartamento.Focus()
                    Exit Function
                End If
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                'El Municipio seleccionado Debe corresponder con el de la Delegación del usuario:
                If IntPermiteEditarFNC = 0 Then
                    'StrSql = "SELECT nStbMunicipioID FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    StrSql = "SELECT b.nStbDepartamentoID FROM StbDelegacionPrograma a INNER JOIN StbMunicipio b ON a.nStbMunicipioID = b.nStbMunicipioID WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    If Me.cboDepartamento.Columns("nStbDepartamentoId").Value <> XcDatos.ExecuteScalar(StrSql) Then
                        MsgBox("Departamento no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errGrupoSolidario.SetError(Me.cboMunicipio, "Departamento no corresponde a su Delegación.")
                        Me.cboDepartamento.Focus()
                        Exit Function
                    End If
                End If
                'Indicar Distrito:
                If Me.cboDistrito.SelectedIndex = -1 Then
                    MsgBox("Debe indicar un Distrito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboDistrito, "Debe indicar un Distrito.")
                    Me.cboDistrito.Focus()
                    Exit Function
                End If
                'Indicar Barrio:
                If Me.cboBarrio.SelectedIndex = -1 Then
                    MsgBox("Debe indicar un Barrio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboBarrio, "Debe indicar un Barrio.")
                    Me.cboBarrio.Focus()
                    Exit Function
                End If
                'Indicar Mercado:
                If Me.cboMercado.SelectedIndex = -1 Then
                    MsgBox("Debe indicar un Mercado.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboMercado, "Debe indicar un Mercado.")
                    Me.cboMercado.Focus()
                    Exit Function
                End If
                'Si es Grupo Solidario de Pago de Mercados debe seleccionarse un mercado:
                'If cboClasificacion.Columns("nCodigo").Value = "5" Then

                'End If
                If cboClasificacion.Columns("nCodigo").Value = "7" Then
                    If (Me.cboMercado.SelectedIndex = 0) Or (Me.cboMercado.Text = "No Aplica") Then
                        MsgBox("Debe seleccionar un Mercado.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errGrupoSolidario.SetError(Me.cboMercado, "Debe seleccionar un Mercado.")
                        Me.cboMercado.Focus()
                        Exit Function
                    End If
                End If
                'Imposible registrar más de un Grupo Solidario 
                'con el mismo Nombre y el mismo Barrio:
                REM REM REM
                StrSql = "SELECT nSclGrupoSolidarioID FROM SclGrupoSolidario " & _
                         "WHERE (sDescripcion = '" & LTrim(RTrim(txtDescripcion.Text)) & "') AND (nStbBarrioVerificadoID = " & cboBarrio.Columns("nStbBarrioID").Value & ")"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Ya existe un Grupo Solidario con este nombre" & Chr(13) & "para esta Ubicación Geográfica.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.txtDescripcion, "Ya existe un Grupo Solidario con este nombre para esta Ubicación Geográfica.")
                    Me.txtDescripcion.Focus()
                    Exit Function
                End If
            End If

            '-- Si se esta Verificando la ubicación Geográfica:
            If ModoFrm = "UPD" Then
                'Verificar Departamento:
                If Me.cboDepartamentoV.SelectedIndex = -1 Then
                    MsgBox("Debe verificar el Departamento.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboDepartamentoV, "Debe verificar el Departamento.")
                    Me.cboDepartamentoV.Focus()
                    Exit Function
                End If
                'Verificar Municipio:
                If Me.cboMunicipioV.SelectedIndex = -1 Then
                    MsgBox("Debe verificar el Municipio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboMunicipioV, "Debe verificar el Municipio.")
                    Me.cboMunicipioV.Focus()
                    Exit Function
                End If
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                'El Municipio seleccionado Debe corresponder con el de la Delegación del usuario:
                If IntPermiteEditarFNC = 0 Then
                    StrSql = "SELECT b.nStbDepartamentoID FROM StbDelegacionPrograma a INNER JOIN StbMunicipio b ON a.nStbMunicipioID = b.nStbMunicipioID WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    If Me.cboDepartamentoV.Columns("nStbDepartamentoId").Value <> XcDatos.ExecuteScalar(StrSql) Then
                        MsgBox("Departamento no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errGrupoSolidario.SetError(Me.cboDepartamentoV, "Departamento no corresponde a su Delegación.")
                        Me.cboDepartamentoV.Focus()
                        Exit Function
                    End If
                End If
                'Verificar Distrito:
                If (Me.cboDistritoV.SelectedIndex = -1) And (Me.cboDistritoV.Enabled) Then
                    MsgBox("Debe verificar el Distrito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboDistritoV, "Debe verificar el Municipio.")
                    Me.cboDistritoV.Focus()
                    Exit Function
                End If
                'Verificar Barrio:
                If Me.cboBarrioV.SelectedIndex = -1 Then
                    MsgBox("Debe verificar el Barrio.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboBarrioV, "Debe verificar el Barrio.")
                    Me.cboBarrioV.Focus()
                    Exit Function
                End If
                'Verificar Mercado:
                If Me.cboMercadoV.SelectedIndex = -1 Then
                    MsgBox("Debe verificar el Mercado.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.cboMercadoV, "Debe verificar el Mercado.")
                    Me.cboMercadoV.Focus()
                    Exit Function
                End If
                'Si es Grupo Solidario de Pago de Mercados debe seleccionarse un mercado:
                'If cboClasificacion.Columns("nCodigo").Value = "5" Then
                If cboClasificacion.Columns("nCodigo").Value = "7" Then
                    If (Me.cboMercadoV.SelectedIndex = 0) Or (Me.cboMercadoV.Text = "No Aplica") Then
                        MsgBox("Debe seleccionar un Mercado.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errGrupoSolidario.SetError(Me.cboMercadoV, "Debe seleccionar un Mercado.")
                        Me.cboMercadoV.Focus()
                        Exit Function
                    End If
                End If
                'Imposible registrar más de un Grupo Solidario 
                'con el mismo Nombre y el mismo Barrio:
                StrSql = "SELECT nSclGrupoSolidarioID FROM SclGrupoSolidario " & _
                         "WHERE (sDescripcion = '" & LTrim(RTrim(txtDescripcion.Text)) & "') AND (nSclGrupoSolidarioID <> " & IdSclGrupoSolidario & ") AND (nStbBarrioVerificadoID = " & cboBarrioV.Columns("nStbBarrioID").Value & ")"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Ya existe un Grupo Solidario con este nombre" & Chr(13) & "para esta Ubicación Geográfica.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupoSolidario.SetError(Me.txtDescripcion, "Ya existe un Grupo Solidario con este nombre para esta Ubicación Geográfica.")
                    Me.txtDescripcion.Focus()
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
    ' Fecha:                05/09/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function RegresaCodigoGS() As String
        Dim ObjTmpGS As New BOSistema.Win.XDataSet
        RegresaCodigoGS = ""
        Try
            Dim strSQL As String

            'Encuentra No. Máximo de GS dentro de la nueva Ubicación:
            If ModoForm = "ADD" Then
                strSQL = " SELECT MAX(Codigo) AS maxCodigo " & _
                         " FROM  " & _
                            " (SELECT  RIGHT(sCodigo, 3) AS Codigo " & _
                            " FROM SclGrupoSolidario " & _
                            " WHERE (nStbBarrioVerificadoID = " & cboBarrio.Columns("nStbBarrioID").Value & ")) AS a "
            Else
                strSQL = " SELECT MAX(Codigo) AS maxCodigo " & _
                         " FROM  " & _
                           " (SELECT  RIGHT(sCodigo, 3) AS Codigo " & _
                           " FROM SclGrupoSolidario " & _
                           " WHERE (nStbBarrioVerificadoID = " & cboBarrioV.Columns("nStbBarrioID").Value & ")) AS a "
            End If

            If ObjTmpGS.ExistTable("GS") Then
                ObjTmpGS("GS").ExecuteSql(strSQL)
            Else
                ObjTmpGS.NewTable(strSQL, "GS")
                ObjTmpGS("GS").Retrieve()
            End If

            If Not ObjTmpGS("GS").ValueField("maxCodigo") Is DBNull.Value Then
                RegresaCodigoGS = Format(ObjTmpGS("GS").ValueField("maxCodigo") + 1, "000")
            Else
                RegresaCodigoGS = "001"
            End If

            If ModoForm = "ADD" Then
                RegresaCodigoGS = cboDepartamento.Columns("sCodigo").Value + "-" + cboMunicipio.Columns("sCodigo").Value + "-" + _
                                  cboDistrito.Columns("sCodigo").Value + "-" + cboBarrio.Columns("sCodigo").Value + "-" + RegresaCodigoGS
            Else
                RegresaCodigoGS = cboDepartamentoV.Columns("sCodigo").Value + "-" + cboMunicipioV.Columns("sCodigo").Value + "-" + _
                                  cboDistritoV.Columns("sCodigo").Value + "-" + cboBarrioV.Columns("sCodigo").Value + "-" + RegresaCodigoGS
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpGS.Close()
            ObjTmpGS = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       SalvarGrupoSolidario
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Grupo Solidario en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarGrupoSolidario()
        Dim Trans As BOSistema.Win.Transact
        Dim StrSql As String = ""
        Dim StrCodigoGS As String = ""
        Dim IntEstagoGS As Integer
        Dim XcEstadoGS As New BOSistema.Win.XComando

        Trans = Nothing
        Try

            Dim IntDelegacionID As Integer
            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact

            '-- Encuentra Código del Grupo Solidario:
            If (ModoForm = "UPD") Then
                If (IdStbBarrioVerificado <> cboBarrioV.Columns("nStbBarrioID").Value) Then
                    StrCodigoGS = RegresaCodigoGS() 'Si cambio el BarrioVerificado.
                Else
                    StrCodigoGS = txtCodigo.Text
                End If
            Else 'ADD de nuevo GS:
                StrCodigoGS = RegresaCodigoGS()
            End If

            '-- Encontrar ID de Delegacion con base en el Departamento:
            StrSql = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                     "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                     "WHERE (StbMunicipio.nStbDepartamentoID = " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & ")"
            IntDelegacionID = XcEstadoGS.ExecuteScalar(StrSql)

            'Inicio la Transaccion:
            Trans.BeginTrans()

            'Inserta / Actualiza GS:
            If ModoForm = "ADD" Then
                'Buscar Estado En Proceso: 
                StrSql = " SELECT a.nStbValorCatalogoID FROM  StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE (b.sNombre = 'EstadoGrupo') AND (a.sCodigoInterno = '1') "
                IntEstagoGS = XcEstadoGS.ExecuteScalar(StrSql)
                'Insertar Grupo Solidario: 
                StrSql = "Insert Into SclGrupoSolidario " & _
                     "(nStbEstadoGrupoID, " & _
                     "sUsuarioCreacion, " & _
                     "dFechaCreacion ," & _
                     "sCodigo ," & _
                     "sDescripcion ," & _
                     "nStbMercadoID, " & _
                     "nStbMercadoVerificadoID, " & _
                     "nConsecutivoCredito, " & _
                     "nStbBarrioID, " & _
                     "nStbDelegacionProgramaID, " & _
                     "nSclTipodePlandeNegocioID, " & _
                     "nStbBarrioVerificadoID) " & _
                     " Values (" & IntEstagoGS & ",'" & InfoSistema.LoginName & "'," & "GetDate(), '" & _
                     StrCodigoGS & "','" & Trim(RTrim(Me.txtDescripcion.Text)) & "', " & cboMercado.Columns("nStbMercadoID").Value & ", " & cboMercado.Columns("nStbMercadoID").Value & ",1, " & _
                     cboBarrio.Columns("nStbBarrioID").Value & ", " & IntDelegacionID & ", " & Me.cboClasificacion.Columns("nSclTipodePlandeNegocioID").Value & ", " & cboBarrio.Columns("nStbBarrioID").Value & ")"
                Trans.ExecuteSql(StrSql)
            Else
                StrSql = "UPDATE SclGrupoSolidario " & _
                         "SET nSclTipodePlandeNegocioID = " & Me.cboClasificacion.Columns("nSclTipodePlandeNegocioID").Value & ", sCodigo = '" & StrCodigoGS & "', sDescripcion = '" & Trim(RTrim(Me.txtDescripcion.Text)) & _
                         "', nStbMercadoVerificadoID = " & cboMercadoV.Columns("nStbMercadoID").Value & ", nStbBarrioVerificadoID = " & cboBarrioV.Columns("nStbBarrioID").Value & _
                         ", dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                         "WHERE (nSclGrupoSolidarioID = " & IdSclGrupoSolidario & ")"
                Trans.ExecuteSql(StrSql)
                'Actualiza Código de Ficha de Inscripción asociada a las socias del GS (Si existen):
                If (IdStbBarrioVerificado <> cboBarrioV.Columns("nStbBarrioID").Value) Then
                    StrSql = " Update SclFichaSocia " & _
                             " SET sCodigo = '" & StrCodigoGS & "' + Right(sCodigo,6)" & _
                             ", dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                             " WHERE nSclGrupoSociaID IN (SELECT nSclGrupoSociaID FROM SclGrupoSocia WHERE  (nSclGrupoSolidarioID = " & IdSclGrupoSolidario & ")) "
                    Trans.ExecuteSql(StrSql)
                End If
            End If

            'Finaliza Transacción:
            Trans.Commit()

            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                If (IdStbBarrioVerificado <> cboBarrioV.Columns("nStbBarrioID").Value) Then
                    Call GuardarAuditoria(5, 15, "Cambio de Ubicación Geográfica a Grupo Solidario Código: " & StrCodigoGS & " (Código Anterior: " & txtCodigo.Text & ")")
                End If
            End If

            'Asignar Id del GS a variable
            'publica del formulario
            If ModoForm = "ADD" Then
                StrSql = "SELECT MAX(nSclGrupoSolidarioID) AS C FROM SclGrupoSolidario"
                IdSclGrupoSolidario = XcEstadoGS.ExecuteScalar(StrSql)
            End If
            '--------------------------------

        Catch ex As Exception
            Control_Error(ex)
            Trans.RollBack()
        Finally
            Me.Cursor = Cursors.Default
            Trans = Nothing

            XcEstadoGS.Close()
            XcEstadoGS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/09/2007
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
                            SalvarGrupoSolidario()
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
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
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
    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
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
            CargarMercado(1, 0, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex <> -1 Then
            CargarBarrio(0, 0)
        Else
            CargarBarrio(1, 0)
            CargarMercado(1, 0, 0)

        End If
        vbModifico = True
    End Sub

    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrio.TextChanged
        If Me.cboBarrio.SelectedIndex <> -1 Then
            CargarMercado(0, 0, IIf(Me.rdbCooperativa.Checked, 1, 0))
        Else
            CargarMercado(1, 0, IIf(Me.rdbCooperativa.Checked, 1, 0))
        End If
        vbModifico = True
    End Sub

    Private Sub cboDepartamentoV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamentoV.TextChanged
        If Me.cboDepartamentoV.SelectedIndex <> -1 Then
            CargarMunicipioV(0, 0)
        Else
            CargarMunicipioV(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboMunicipioV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipioV.TextChanged
        If Me.cboMunicipioV.SelectedIndex <> -1 Then
            If Me.cboMunicipioV.Text = "Managua" Then
                CargarDistritoV(0, 0)
                Me.cboDistritoV.Enabled = True
            Else
                CargarDistritoV(0, 0)
                If Me.cboDistritoV.ListCount > 0 Then
                    Me.cboDistritoV.SelectedIndex = 0
                End If
                Me.cboDistritoV.Enabled = False
            End If
        Else
            CargarDistritoV(1, 0)
            CargarBarrioV(1, 0)
            'Me.CargarFiltroTipoGrupo(0, Me.cboFiltro2)
            'CargarMercadoV(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboDistritoV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistritoV.TextChanged
        If Me.cboDistritoV.SelectedIndex <> -1 Then
            CargarBarrioV(0, 0)
            'CargarMercadoV(0, 0)
            'Me.CargarFiltroTipoGrupo(0, Me.cboFiltro2)
        Else
            CargarBarrioV(1, 0)
            'CargarMercadoV(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboBarrioV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrioV.TextChanged
        If Me.cboBarrioV.SelectedIndex <> -1 Then
            'CargarFiltroTipoGrupo(0, Me.cboFiltro2)
            'CargarMercadoV(0, 0)
        Else
            'CargarMercadoV(1, 0)
            'CargarFiltroTipoGrupo(0, Me.cboFiltro2)
        End If
        vbModifico = True
    End Sub


    Private Sub CargarFiltroTipoGrupo(ByVal intMercadoID As Int32, ByRef Combo As C1.Win.C1List.C1Combo)
        Try
            Dim Strsql As String
            Strsql = " SELECT nStbValorCatalogoID," & _
                     "        sCodigoInterno," & _
                     "        sDescripcion " & _
                     " FROM   StbValorCatalogo" & _
                     String.Format(" WHERE  (nStbCatalogoID = {0})", Me.TipoGrupo)

            If XdsUbicacion.ExistTable("TipoGrupo") Then
                XdsUbicacion("TipoGrupo").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "TipoGrupo")
                XdsUbicacion("TipoGrupo").Retrieve()
            End If
            'Asignando a las fuentes de datos
            Combo.DataSource = XdsUbicacion("TipoGrupo").Source
            Combo.Rebind()

            If intMercadoID <> 0 Then
            Else

            End If

            Combo.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Combo.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Combo.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Combo.Splits(0).DisplayColumns("sDescripcion").Width = 80
            Combo.Columns("sCodigoInterno").Caption = "Código"
            Combo.Columns("sDescripcion").Caption = " Descripción "
            Combo.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Combo.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
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
    ' Fecha:                06/09/2007
    ' Procedure Name:       CargarDepartamentoV
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       Verificados en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamentoV(ByVal intDepartamentoID As Integer)
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
                         " Where ((a.nActivo = 1) AND (a.nPertenecePrograma = 1)) Or (a.nStbDepartamentoID = " & intDepartamentoID & ") " & _
                         " Order by a.sCodigo"
            End If


            If XdsUbicacion.ExistTable("DepartamentoV") Then
                XdsUbicacion("DepartamentoV").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "DepartamentoV")
                XdsUbicacion("DepartamentoV").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamentoV.DataSource = XdsUbicacion("DepartamentoV").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsUbicacion("DepartamentoV").Count > 0 Then
                XdsUbicacion("DepartamentoV").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo Departamento:
            Me.cboDepartamentoV.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamentoV.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamentoV.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamentoV.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDepartamentoV.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamentoV.Columns("sNombre").Caption = "Descripción"
            Me.cboDepartamentoV.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamentoV.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsUbicacion("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
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
    ' Procedure Name:       CargarMunicipioV
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       Verificados en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipioV(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMunicipioV.ClearFields()

            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where (a.nPertenecePrograma = 1) And  (a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsUbicacion("DepartamentoV").ValueField("nStbDepartamentoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where ((a.nPertenecePrograma = 1) And  (a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsUbicacion("DepartamentoV").ValueField("nStbDepartamentoID") & ")) " & _
                             " Or (a.nStbMunicipioID = " & intMunicipioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("MunicipioV") Then
                XdsUbicacion("MunicipioV").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "MunicipioV")
                XdsUbicacion("MunicipioV").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipioV.DataSource = XdsUbicacion("MunicipioV").Source
            Me.cboMunicipioV.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsUbicacion("MunicipioV").Count > 0 Then
                XdsUbicacion("MunicipioV").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo Municipio:
            Me.cboMunicipioV.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipioV.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipioV.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipioV.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipioV.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboMunicipioV.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipioV.Columns("sNombre").Caption = "Descripción"
            Me.cboMunicipioV.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipioV.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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

            'Asignando a las fuentes de datos
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
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarDistritoV
    ' Descripción:          Este procedimiento permite cargar el listado de Distritos
    '                       Verificados en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistritoV(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboDistritoV.ClearFields()

            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where (a.nPertenecePrograma = 1) And  (a.nActivo = 1) " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where ((a.nPertenecePrograma = 1) And  (a.nActivo = 1)) " & _
                             " OR (a.nStbDistritoID = " & intDistritoID & ") " & _
                             " Order by a.sCodigo"
                End If
            Else 'Limpiar = 0 Qry No regresa ningun Distrito:
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("DistritoV") Then
                XdsUbicacion("DistritoV").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "DistritoV")
                XdsUbicacion("DistritoV").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistritoV.DataSource = XdsUbicacion("DistritoV").Source
            Me.cboDistritoV.Rebind()

            'Configurar el combo Distritos:
            Me.cboDistritoV.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistritoV.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistritoV.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistritoV.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDistritoV.Columns("sCodigo").Caption = "Código"
            Me.cboDistritoV.Columns("sNombre").Caption = "Descripción"
            Me.cboDistritoV.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistritoV.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       CargarClasificacion
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       clasificaciones económicas.
    '-------------------------------------------------------------------------
    Private Sub CargarClasificacion(ByVal intClasificacionID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String
            If InfoSistema.IDDelegacion = 1 Then 'Si es delegacion central ver todo'
                If intClasificacionID = 0 Then
                    Strsql = " Select a.nSclTipodePlandeNegocioID, a.nCodigo, a.sDescripcion " & _
                         " FROM SclTipodePlandeNegocio a  " & _
                         " Where (a.nCreditoIndividual = 0) " & _
                         " Order by a.nSclTipodePlandeNegocioID"
                Else
                    Strsql = " Select a.nSclTipodePlandeNegocioID, a.nCodigo, a.sDescripcion " & _
                         " FROM SclTipodePlandeNegocio a  " & _
                         " Where (a.nCreditoIndividual = 0) or (a.nSclTipodePlandeNegocioID = " & intClasificacionID & ")  " & _
                         " Order by a.nSclTipodePlandeNegocioID"
                End If
            Else 'Solo ver hasta ventana de genero no ver PDIBA para las demas delegaciones
                If intClasificacionID = 0 Then
                    Strsql = " Select a.nSclTipodePlandeNegocioID, a.nCodigo, a.sDescripcion " & _
                         " FROM SclTipodePlandeNegocio a  " & _
                         " Where (a.nCreditoIndividual = 0) and (a.nCodigo<=4) " & _
                         " Order by a.nSclTipodePlandeNegocioID"
                Else
                    Strsql = " Select a.nSclTipodePlandeNegocioID, a.nCodigo, a.sDescripcion " & _
                         " FROM SclTipodePlandeNegocio a  " & _
                         " Where ( (a.nCreditoIndividual = 0) and  (a.nCodigo<=4) ) or (a.nSclTipodePlandeNegocioID = " & intClasificacionID & ")  " & _
                         " Order by a.nSclTipodePlandeNegocioID"
                End If


            End If
            

            If XdsUbicacion.ExistTable("Clase") Then
                XdsUbicacion("Clase").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Clase")
                XdsUbicacion("Clase").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboClasificacion.DataSource = XdsUbicacion("Clase").Source

            'Ubicarse en el registro recomendado de parámetros:
            XdtValorParametro.Filter = "nStbParametroID = 63"
            XdtValorParametro.Retrieve()
            If XdsUbicacion("Clase").Count > 0 Then
                Me.cboClasificacion.SelectedIndex = 0
                XdsUbicacion("Clase").SetCurrentByID("nSclTipodePlandeNegocioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo: 
            Me.cboClasificacion.Splits(0).DisplayColumns("nSclTipodePlandeNegocioID").Visible = False
            Me.cboClasificacion.Splits(0).DisplayColumns("nCodigo").Visible = False
            'Me.cboClasificacion.Splits(0).DisplayColumns("nCodigo").Width = 80
            Me.cboClasificacion.Splits(0).DisplayColumns("sDescripcion").Width = 120
            'Me.cboClasificacion.Columns("nCodigo").Caption = "Código"
            Me.cboClasificacion.Columns("sDescripcion").Caption = "Tipo Plan de Negocio"
            Me.cboClasificacion.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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

            'Asignando a las fuentes de datos
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
    Private Sub CargarMercado(ByVal intLimpiarID As Integer, ByVal intMercadoID As Integer, ByVal Cooperativa As Int32)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMercado.ClearFields()

            Dim filtroBarrio As Boolean = Not (XdsUbicacion("Barrio") Is Nothing)
            If filtroBarrio Then
                If intLimpiarID = 0 Then

                    If intMercadoID = 0 Then 'Mercados del Barrio Indicado:

                        Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                                                     " From StbMercado a " & _
                                                     " Where ( ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("Barrio").ValueField("nStbBarrioID") & _
                                                     " )) Or (a.nStbMercadoID = 1) " & _
                                                     String.Format(" ) And (  nCooperativa = {0}", Cooperativa) & IIf(Cooperativa = 1, " Or nStbMercadoID =1 )", ")") & _
                                                     " Order by a.sCodigo"


                    Else
                        Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                                 " From StbMercado a " & _
                                 " Where ( ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("Barrio").ValueField("nStbBarrioID") & _
                                 " ) Or (a.nStbMercadoID = 1)) Or (a.nStbMercadoID = " & intMercadoID & _
                                 " ) )" & _
                                 String.Format(" And nCooperativa = {0}", Cooperativa) & _
                                " Order by a.sCodigo"
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

                'Asignando a las fuentes de datos
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
                If Me.cboMercado.ListCount > 0 And intMercadoID = 0 Then
                    Me.cboMercado.SelectedIndex = 0
                Else
                    Me.cboMercado.SelectedValue = intMercadoID
                End If
            End If
            

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/09/2007
    ' Procedure Name:       CargarMercadoV
    ' Descripción:          Este procedimiento permite cargar el listado de Mercados
    '                       verificados en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMercadoV(ByVal intLimpiarID As Integer, ByVal intMercadoID As Integer, ByVal Cooperativa As Int16)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMercadoV.ClearFields()

            If intLimpiarID = 0 Then
                If intMercadoID = 0 Then 'Mercados del Barrio Indicado:
                    Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                             " From StbMercado a " & _
                             " Where  ( ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("BarrioV").ValueField("nStbBarrioID") & _
                             " )) Or (a.nStbMercadoID = 1) ) " & _
                             String.Format(" And (  nCooperativa = {0}", Cooperativa) & IIf(Cooperativa = 1, " Or nStbMercadoID =1 ) ", ")") & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                             " From StbMercado a " & _
                            " Where  ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbBarrioID = " & XdsUbicacion("BarrioV").ValueField("nStbBarrioID") & String.Format(" ) And nCooperativa = {0} ", Cooperativa) & _
                            " And (a.nStbMercadoID = " & intMercadoID & " ) ) Or (a.nStbMercadoID = 1) " & _
                            " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMercadoID,a.nStbBarrioID,a.sCodigo,a.sNombre " & _
                         " From StbMercado a " & _
                         " Where a.nStbMercadoID = 0"
            End If

            If XdsUbicacion.ExistTable("MercadoV") Then
                XdsUbicacion("MercadoV").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "MercadoV")
                XdsUbicacion("MercadoV").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMercadoV.DataSource = XdsUbicacion("MercadoV").Source
            Me.cboMercadoV.Rebind()

            'Configurar el combo Barrio:
            Me.cboMercadoV.Splits(0).DisplayColumns("nStbMercadoID").Visible = False
            Me.cboMercadoV.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboMercadoV.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercadoV.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMercadoV.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboMercadoV.Columns("sCodigo").Caption = "Código"
            Me.cboMercadoV.Columns("sNombre").Caption = "Descripción"
            Me.cboMercadoV.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercadoV.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarBarrioV
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       Verificados en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarBarrioV(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBarrioV.ClearFields()

            If intLimpiarID = 0 Then
                If intBarrioID = 0 Then
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("MunicipioV").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsUbicacion("DistritoV").ValueField("nStbDistritoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("MunicipioV").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsUbicacion("DistritoV").ValueField("nStbDistritoID") & ")) " & _
                             " Or (a.nStbBarrioID = " & intBarrioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbBarrio a " & _
                         " Where a.nStbBarrioID = 0"
            End If

            If XdsUbicacion.ExistTable("BarrioV") Then
                XdsUbicacion("BarrioV").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "BarrioV")
                XdsUbicacion("BarrioV").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrioV.DataSource = XdsUbicacion("BarrioV").Source
            Me.cboBarrioV.Rebind()

            'Configurar el combo Barrio:
            Me.cboBarrioV.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrioV.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrioV.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboBarrioV.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrioV.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrioV.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboBarrioV.Columns("sCodigo").Caption = "Código"
            Me.cboBarrioV.Columns("sNombre").Caption = "Descripción"
            Me.cboBarrioV.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrioV.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboMercado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMercado.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboMercadoV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMercadoV.TextChanged
        vbModifico = True
    End Sub

    Private Sub rdbNoAplica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNoAplica.CheckedChanged
        If rdbNoAplica.Checked Then
            If Not Me.cboMercado.DataSource Is Nothing Then
                Me.cboMercado.SelectedIndex = 0
            End If
            Me.cboMercado.Enabled = False
        Else
            Me.cboMercado.Enabled = True
        End If
    End Sub

    Private Sub rdbNoAplicaV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbNoAplicaV.CheckedChanged
        If rdbNoAplicaV.Checked Then
            If Not Me.cboMercadoV.DataSource Is Nothing Then
                Me.cboMercadoV.SelectedIndex = 0
            End If
            Me.cboMercadoV.Enabled = False
        Else
            Me.cboMercadoV.Enabled = True
        End If
    End Sub

    Private Sub rdbMercado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMercado.CheckedChanged
        If rdbMercado.Checked Then
            Me.CargarMercado(0, 0, 0)
        End If
    End Sub

    Private Sub rdbCooperativa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCooperativa.CheckedChanged
        If rdbCooperativa.Checked Then
            Me.CargarMercado(0, 0, 1)
        End If
    End Sub

    Private Sub rdbMercadoV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbMercadoV.CheckedChanged
        If rdbMercadoV.Checked Then
            Me.CargarMercadoV(0, 0, 0)
        End If
    End Sub

    Private Sub rdbCooperativaV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbCooperativaV.CheckedChanged
        If rdbCooperativaV.Checked Then
            Me.CargarMercadoV(0, 0, 1)
        End If
    End Sub
End Class