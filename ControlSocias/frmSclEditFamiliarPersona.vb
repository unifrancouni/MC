' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditSocia.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Socias.
'-------------------------------------------------------------------------

Imports System.io

Public Class frmSclEditFamiliarPersona

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSclSocia As Long 'SclSocia.nSclSociaID
    Dim nLimpiar As Integer
    Dim StrFecha As String
    Dim bValidar As Boolean = True



    '-- Clases para procesar la informacion de los combos
    Dim XdtEstadoCivil As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDocumento As BOSistema.Win.XDataSet.xDataTable
    Dim XdsEscolaridad As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjSociadt As BOSistema.Win.SclEntSocia.SclSociaDataTable
    Dim ObjSociadr As BOSistema.Win.SclEntSocia.SclSociaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum


    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    Dim intFichaID As Integer

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

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdSocia() As Long
        Get
            IdSocia = IdSclSocia
        End Get
        Set(ByVal value As Long)
            IdSclSocia = value
        End Set
    End Property


    Public Property IdFicha() As Long
        Get
            IdFicha= intFichaID
        End Get
        Set(ByVal value As Long)
            intFichaID = value
        End Set
    End Property



    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclEditSocia_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjSociadt.Close()
                ObjSociadt = Nothing

                ObjSociadr.Close()
                ObjSociadr = Nothing

                XdtEstadoCivil.Close()
                XdtEstadoCivil = Nothing

                XdtDocumento.Close()
                XdtDocumento = Nothing

                XdsEscolaridad.Close()
                XdsEscolaridad = Nothing

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
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclEditSocia_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSocia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            'CargarDepartamento(0)
            CargarEstadoCivil()
            'CargarDocumento()
            'CargarPrimaria()
            'CargarSecundaria()
            'CargarCarreraTecnica()
            Seg.RefreshPermissions()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarSocia()
                InhabilitarControles()
                cmdBuscar.Enabled = False
                mtbNumCedula.Enabled = False
                ' Si no tiene permiso de agregar cédula deshabilitar la busqueda y modificación de la cédula
                If Not Seg.HasPermission("ModificarNombreSocia") Then
                    Me.mtbNumCedula.Enabled = False
                    Me.cmdBuscar.Enabled = False
                    Me.cmdEditarCedula.Enabled = False
                End If



            Else 'ADD.
                'mtbNumHijos.Text = 0
                'mtbHijosDep.Text = 0
                'chkFormarGS.Checked = True

                Me.cmdEditarCedula.Enabled = False

                ' Si no tiene permiso de agregar cédula deshabilitar la busqueda y modificación de la cédula
                Dim enabled As Boolean = Seg.HasPermission("ModificarNombreSocia")
                Me.txtNombre1.Enabled = enabled
                Me.txtNombre2.Enabled = enabled
                Me.txtApellido1.Enabled = enabled
                Me.txtApellido2.Enabled = enabled
            End If

            Me.mtbNumCedula.Select()
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
    ' Fecha:                07/09/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            'Si la Socia esta Inactiva:
            If ObjSociadr.nSociaActiva = 0 Then
                Me.cmdAceptar.Enabled = False
                Me.grpSociaGe.Enabled = False


            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Socia"
            Else
                Me.Text = "Modificar Socia"
            End If

            XdtEstadoCivil = New BOSistema.Win.XDataSet.xDataTable
            XdtDocumento = New BOSistema.Win.XDataSet.xDataTable
            XdsEscolaridad = New BOSistema.Win.XDataSet
            XdsUbicacion = New BOSistema.Win.XDataSet

            ObjSociadt = New BOSistema.Win.SclEntSocia.SclSociaDataTable
            ObjSociadr = New BOSistema.Win.SclEntSocia.SclSociaRow

            'Limpiar los combos:
      
            'Me.cboOtroDocumento.ClearFields()
       

            If ModoFrm = "ADD" Then
                ObjSociadr = ObjSociadt.NewRow
                'Inicializar los Length de los campos (Strings)
                Me.txtNombre1.MaxLength = ObjSociadr.GetColumnLenght("sNombre1")
                Me.txtNombre2.MaxLength = ObjSociadr.GetColumnLenght("sNombre2")
                Me.txtApellido1.MaxLength = ObjSociadr.GetColumnLenght("sApellido1")
                Me.txtApellido2.MaxLength = ObjSociadr.GetColumnLenght("sApellido2")

                'Me.txtTelefono.MaxLength = ObjSociadr.GetColumnLenght("sTelefonoSocia")

                Me.mtbNumCedula.MaxLength = ObjSociadr.GetColumnLenght("sNumeroCedula")
                'Me.txtOtroDocumento.MaxLength = ObjSociadr.GetColumnLenght("sNumeroOtroDocumento")
            End If

            'Siempre Inhabilitar Nombres:
            nLimpiar = 1




            Me.txtNombre1.Enabled = False
            Me.txtNombre2.Enabled = False
            Me.txtApellido1.Enabled = False
            Me.txtApellido2.Enabled = False



            'OJO TEMPORAL PROBAR SE ACTIVARA SOLO CON USUARIO CON PERMISO DE MODIFICAR
            Seg.RefreshPermissions()



            If Seg.HasPermission("ModificarNombreSocia") = True Then

                Me.txtNombre1.Enabled = True
                Me.txtNombre2.Enabled = True
                Me.txtApellido1.Enabled = True
                Me.txtApellido2.Enabled = True
            End If

            'OJO FIN 





        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarSocia
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarSocia()
        'Dim Strsql As String
        'Dim IdMunicipio As Long
        'Dim IdDepartamento As Long
        Dim XcUbicacion As New BOSistema.Win.XComando

        Try

            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjSociadt.Filter = "nSclSociaID = " & IdSocia
            ObjSociadt.Retrieve()
            If ObjSociadt.Count = 0 Then 'No hay socias registradas (ADD).
                Exit Sub
            End If
            ObjSociadr = ObjSociadt.Current 'Socia actual.

            'Cargar Combo de Estado Civil:
            If Not ObjSociadr.IsFieldNull("nStbEstadoCivilID") Then
                CargarEstadoCivil() 'EC de socia actual.
                If XdtEstadoCivil.Count > 0 Then
                    Me.cboEstadoCivil.SelectedIndex = 0
                End If
                XdtEstadoCivil.SetCurrentByID("nStbValorCatalogoID", ObjSociadr.nStbEstadoCivilID)
            Else 'Estado civil esta en Null.
                Me.cboEstadoCivil.Text = ""
                Me.cboEstadoCivil.SelectedIndex = -1
            End If

            'Cargar Combo de Tipo de Documentos de Identificacion:
            'If Not ObjSociadr.IsFieldNull("nStbTipoOtroDocumentoID") Then
            '    CargarDocumento()
            '    If XdtDocumento.Count > 0 Then
            '        Me.cboOtroDocumento.SelectedIndex = 0
            '    End If
            '    XdtDocumento.SetCurrentByID("nStbValorCatalogoID", ObjSociadr.nStbTipoOtroDocumentoID)
            'Else 'Documento esta en Null.
            '    Me.cboOtroDocumento.Text = ""
            '    Me.cboOtroDocumento.SelectedIndex = -1
            'End If

            ''Cargar Número de Documento de Identificación:
            'If Not ObjSociadr.IsFieldNull("sNumeroOtroDocumento") Then
            '    Me.txtOtroDocumento.Text = ObjSociadr.sNumeroOtroDocumento
            'Else
            '    Me.txtOtroDocumento.Text = ""
            'End If

            ''Cargar Combo de Primaria:
            'If Not ObjSociadr.IsFieldNull("nStbPrimariaID") Then
            '    'CargarPrimaria(ObjSociadr.nStbPrimariaID) 'EC de socia actual.
            '    CargarPrimaria()
            '    If XdsEscolaridad("Primaria").Count > 0 Then
            '        Me.cboPrimaria.SelectedIndex = 0
            '    End If
            '    XdsEscolaridad("Primaria").SetCurrentByID("nStbValorCatalogoID", ObjSociadr.nStbPrimariaID)
            'Else 'Estado civil esta en Null.
            '    Me.cboPrimaria.Text = ""
            '    Me.cboPrimaria.SelectedIndex = -1
            'End If

            ''Cargar Combo de Secundaria:
            'If Not ObjSociadr.IsFieldNull("nStbSecundariaID") Then
            '    CargarSecundaria()
            '    If XdsEscolaridad("Secundaria").Count > 0 Then
            '        Me.cboSecundaria.SelectedIndex = 0
            '    End If
            '    XdsEscolaridad("Secundaria").SetCurrentByID("nStbValorCatalogoID", ObjSociadr.nStbSecundariaID)
            'Else 'Estado civil esta en Null.
            '    Me.cboSecundaria.Text = ""
            '    Me.cboSecundaria.SelectedIndex = -1
            'End If

            ''Cargar Combo de Carrera Técnica:
            'If Not ObjSociadr.IsFieldNull("nStbCarreraTecnicaID") Then
            '    CargarCarreraTecnica()
            '    If XdsEscolaridad("CarreraTecnica").Count > 0 Then
            '        Me.cboCarreraTecnica.SelectedIndex = 0
            '    End If
            '    XdsEscolaridad("CarreraTecnica").SetCurrentByID("nStbValorCatalogoID", ObjSociadr.nStbCarreraTecnicaID)
            'Else 'Estado civil esta en Null.
            '    Me.cboCarreraTecnica.Text = ""
            '    Me.cboCarreraTecnica.SelectedIndex = -1
            'End If

            'Cargar Combo de Departamentos:
            'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
            '    'Determinar Id de Municipio:
            '    Strsql = " SELECT nStbMunicipioID FROM StbBarrio WHERE (nStbBarrioID = " & ObjSociadr.nStbBarrioID & ")"
            '    IdMunicipio = XcUbicacion.ExecuteScalar(Strsql)
            '    'Cargar Dpto:
            '    Strsql = " SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & IdMunicipio & ")"
            '    IdDepartamento = XcUbicacion.ExecuteScalar(Strsql)
            '    CargarDepartamento(IdDepartamento)
            '    If cboDepartamento.ListCount > 0 Then
            '        Me.cboDepartamento.SelectedIndex = 0
            '    End If
            '    XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XcUbicacion.ExecuteScalar(Strsql))
            'Else
            '    Me.cboDepartamento.Text = ""
            '    Me.cboDepartamento.SelectedIndex = -1
            'End If

            'Cargar Combo de Municipios:
            'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
            '    CargarMunicipio(0, IdMunicipio)
            '    If cboMunicipio.ListCount > 0 Then
            '        Me.cboMunicipio.SelectedIndex = 0
            '    End If
            '    XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", IdMunicipio)
            'Else
            '    Me.cboMunicipio.Text = ""
            '    Me.cboMunicipio.SelectedIndex = -1
            'End If

            'Cargar Combo de Distritos:
            'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
            '    Strsql = " SELECT nStbDistritoID FROM StbBarrio WHERE (nStbBarrioID = " & ObjSociadr.nStbBarrioID & ")"
            '    CargarDistrito(0, XcUbicacion.ExecuteScalar(Strsql))
            '    If cboDistrito.ListCount > 0 Then
            '        Me.cboDistrito.SelectedIndex = 0
            '    End If
            '    XdsUbicacion("Distrito").SetCurrentByID("nStbDistritoID", XcUbicacion.ExecuteScalar(Strsql))
            'Else
            '    Me.cboDistrito.Text = ""
            '    Me.cboDistrito.SelectedIndex = -1
            'End If

            'Cargar Combo de Barrios:
            'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
            '    CargarBarrio(0, ObjSociadr.nStbBarrioID)
            '    If cboBarrio.ListCount > 0 Then
            '        Me.cboBarrio.SelectedIndex = 0
            '    End If
            '    XdsUbicacion("Barrio").SetCurrentByID("nStbBarrioID", ObjSociadr.nStbBarrioID)
            'Else 'Estado civil esta en Null.
            '    Me.cboBarrio.Text = ""
            '    Me.cboBarrio.SelectedIndex = -1
            'End If

            'Codigo Interno:
            If Not ObjSociadr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjSociadr.nCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Num. Cédula:
            If Not ObjSociadr.IsFieldNull("sNumeroCedula") Then
                Me.mtbNumCedula.Text = ObjSociadr.sNumeroCedula
            Else
                Me.mtbNumCedula.Text = ""
            End If

            'Primer Nombre:
            If Not ObjSociadr.IsFieldNull("sNombre1") Then
                Me.txtNombre1.Text = ObjSociadr.sNombre1
            Else
                Me.txtNombre1.Text = ""
            End If

            'Segundo Nombre:
            If Not ObjSociadr.IsFieldNull("sNombre2") Then
                Me.txtNombre2.Text = ObjSociadr.sNombre2
            Else
                Me.txtNombre2.Text = ""
            End If

            'Primer Apellido:
            If Not ObjSociadr.IsFieldNull("sApellido1") Then
                Me.txtApellido1.Text = ObjSociadr.sApellido1
            Else
                Me.txtApellido1.Text = ""
            End If

            'Segundo Apellido:
            If Not ObjSociadr.IsFieldNull("sApellido2") Then
                Me.txtApellido2.Text = ObjSociadr.sApellido2
            Else
                Me.txtApellido2.Text = ""
            End If

            'Dirección:
            'If Not ObjSociadr.IsFieldNull("sDireccionSocia") Then
            '    Me.txtDireccion.Text = ObjSociadr.sDireccionSocia
            'Else
            '    Me.txtDireccion.Text = ""
            'End If

            ''Telefono:
            'If Not ObjSociadr.IsFieldNull("sTelefonoSocia") Then
            '    Me.txtTelefono.Text = ObjSociadr.sTelefonoSocia
            'Else
            '    Me.txtTelefono.Text = ""
            'End If

            'Dispuesta a Formar GS:            
            'If Not ObjSociadr.IsFieldNull("nDispuestaFormarGS") Then
            '    Me.chkFormarGS.Checked = ObjSociadr.nDispuestaFormarGS
            'End If
            ''Alfabetizada:            
            'If Not ObjSociadr.IsFieldNull("nAlfabetizada") Then
            '    Me.chkAlfabetizada.Checked = ObjSociadr.nAlfabetizada
            'End If

            ''Otros Estudios:
            'If Not ObjSociadr.IsFieldNull("sOtrosEstudios") Then
            '    Me.txtOtrosEstudios.Text = ObjSociadr.sOtrosEstudios
            'Else
            '    Me.txtOtrosEstudios.Text = ""
            'End If
            ''Número de Hijos NACIDOS Vivos:
            'If Not ObjSociadr.IsFieldNull("nNumHijosVivos") Then
            '    Me.mtbNumHijos.Text = ObjSociadr.nNumHijosVivos
            'Else
            '    Me.mtbNumHijos.Text = ""
            'End If

            ''Número de Personas Dependientes:
            'If Not ObjSociadr.IsFieldNull("nNumHijosDependientes") Then
            '    Me.mtbHijosDep.Text = ObjSociadr.nNumHijosDependientes
            'Else
            '    Me.mtbHijosDep.Text = ""
            'End If

            'Inicializar los Length de los campos
            Me.txtNombre1.MaxLength = ObjSociadr.GetColumnLenght("sNombre1")
            Me.txtNombre2.MaxLength = ObjSociadr.GetColumnLenght("sNombre2")
            Me.txtApellido1.MaxLength = ObjSociadr.GetColumnLenght("sApellido1")
            Me.txtApellido2.MaxLength = ObjSociadr.GetColumnLenght("sApellido2")
            'Me.txtDireccion.MaxLength = ObjSociadr.GetColumnLenght("sDireccionSocia")
            'Me.txtTelefono.MaxLength = ObjSociadr.GetColumnLenght("sTelefonoSocia")
            'Me.txtOtrosEstudios.MaxLength = ObjSociadr.GetColumnLenght("sOtrosEstudios")
            Me.mtbNumCedula.MaxLength = ObjSociadr.GetColumnLenght("sNumeroCedula")
            'Me.txtOtroDocumento.MaxLength = ObjSociadr.GetColumnLenght("sNumeroOtroDocumento")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarSocia()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaDataTable
        Dim ObjSclGS As New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable

        Try

            ValidaDatosEntrada = True
            Me.errSocia.Clear()

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'NO validar Número de Cédula si no corresponde a Formato:
            'Y establecer como fecha de nacimiento: 30/05/1964
            If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
                StrFecha = "30/05/1964"
            Else
                'Fecha válida en número de Cédula:
                StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
                If Not IsDate(StrFecha) Then
                    MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula debe contener una fecha válida.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
                'Determinar Duplicados en el Número de Cédula:
                If ModoFrm = "UPD" Then
                    ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And nSclSociaID <> " & IdSocia & " And nSociaActiva = 1 "
                Else
                    ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And nSociaActiva = 1 "
                End If
                ObjTmpSocia.Retrieve() 'Obtener los datos filtrados.
                If ObjTmpSocia.Count > 0 Then
                    MsgBox("El Número de Cédula NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula NO DEBE repetirse.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
                'Número de Cédula Válido:
                Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                    Case Cedula.Invalida
                        MsgBox("El Número de Cédula de la Socia es invalido.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia es invalido.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                    Case Cedula.LongitudIncorrecta
                        MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "La Longitud del Número de Cédula de la Socia es incorrecta.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                End Select
            End If

            'Primer Nombre Obligatorio:
            If Trim(RTrim(Me.txtNombre1.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Nombre de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtNombre1, "El Primer Nombre de la Socia NO DEBE quedar vacío.")
                Me.txtNombre1.Focus()
                Exit Function
            End If

            'Primer Apellido Obligatorio:
            If Trim(RTrim(Me.txtApellido1.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Apellido de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtApellido1, "El Primer Apellido de la Socia NO DEBE quedar vacío.")
                Me.txtApellido1.Focus()
                Exit Function
            End If


            'Número de hijos NACIDOS vivos:
            'If Not IsNumeric(Me.mtbNumHijos.Text) Then
            '    MsgBox("Debe indicar un número de hijos nacidos vivos válido.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.mtbNumHijos, "Debe indicar un número de hijos nacidos vivos válido.")
            '    Me.mtbNumHijos.Focus()
            '    Exit Function
            'End If

            ''Número de hijos dependientes:
            'If Not IsNumeric(Me.mtbHijosDep.Text) Then
            '    MsgBox("Debe indicar un número de personas dependientes válido.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.mtbHijosDep, "Debe indicar un número de personas dependientes válido.")
            '    Me.mtbHijosDep.Focus()
            '    Exit Function
            'End If

            'Si se indicó Otro tipo de Documento de Identificación:
            'If Me.cboOtroDocumento.SelectedIndex <> -1 Then
            '    If Trim(RTrim(Me.txtOtroDocumento.Text)).ToString.Length = 0 Then
            '        MsgBox("Debe indicar el Número de Documento.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSocia.SetError(Me.txtOtroDocumento, "Debe indicar el Número de Documento.")
            '        Me.txtOtroDocumento.Focus()
            '        Exit Function
            '    End If
            'End If

            ''Si se indicó Número de Documento de Identificación:
            'If Trim(RTrim(Me.txtOtroDocumento.Text)).ToString.Length <> 0 Then
            '    If Me.cboOtroDocumento.SelectedIndex = -1 Then
            '        MsgBox("Debe indicar el Tipo de Documento.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSocia.SetError(Me.cboOtroDocumento, "Debe indicar el Tipo de Documento.")
            '        Me.cboOtroDocumento.Focus()
            '        Exit Function
            '    End If
            'End If

            'Si la Socia no tiene Cédula obligar otro documento de identificación:
            'If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
            '    If Me.cboOtroDocumento.SelectedIndex = -1 Then
            '        MsgBox("Debe indicar Otro Tipo de Documento de Identificación.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSocia.SetError(Me.cboOtroDocumento, "Indicar Otro Tipo de Documento de Identificación.")
            '        Me.cboOtroDocumento.Focus()
            '        Exit Function
            '    End If
            'End If

            'Dirección Obligatoria:
            'If Trim(RTrim(Me.txtDireccion.Text)).ToString.Length = 0 Then
            '    MsgBox("La Dirección de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.txtDireccion, "La Dirección de la Socia NO DEBE quedar vacío.")
            '    Me.txtDireccion.Focus()
            '    Exit Function
            'End If

            ''Departamento:
            'If Me.cboDepartamento.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar Departamento donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboDepartamento, "Debe seleccionar Departamento donde reside la socia.")
            '    Me.cboDepartamento.Focus()
            '    Exit Function
            'End If

            ''Municipio:
            'If Me.cboMunicipio.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar Municipio donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboMunicipio, "Debe seleccionar Municipio donde reside la socia.")
            '    Me.cboMunicipio.Focus()
            '    Exit Function
            'End If

            ''Distrito:
            'If Me.cboDistrito.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar Distrito donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboDistrito, "Debe seleccionar Distrito donde reside la socia.")
            '    Me.cboDistrito.Focus()
            '    Exit Function
            'End If

            ''Barrio:
            'If Me.cboBarrio.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar Barrio donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboBarrio, "Debe seleccionar Barrio donde reside la socia.")
            '    Me.cboBarrio.Focus()
            '    Exit Function
            'End If

            ''Nivel de Educación Primaria:
            'If Me.cboPrimaria.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar un nivel de escolaridad Primaria.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboPrimaria, "Debe seleccionar un nivel de escolaridad Primaria.")
            '    Me.cboPrimaria.Focus()
            '    Exit Function
            'End If

            'Si al menos se indicó Educación primaria (último año) 
            ''no puede indicar Alfabetizada = 0:
            'If chkAlfabetizada.Checked = False Then
            '    If cboPrimaria.Columns("sCodigoInterno").Value = "7" Then
            '        MsgBox("Imposible indicar Socia NO Alfabetizada" & Chr(13) & _
            '           " si esta tiene la Primaria aprobada.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSocia.SetError(Me.chkAlfabetizada, "Imposible indicar Socia NO Alfabetizada si esta tiene la Primaria aprobada.")
            '        Me.chkAlfabetizada.Focus()
            '        Exit Function
            '    End If
            'End If

            ''Nivel de Educación Secundaria:
            'If Me.cboSecundaria.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar un nivel de escolaridad Secundaria.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboSecundaria, "Debe seleccionar un nivel de escolaridad Secundaria.")
            '    Me.cboSecundaria.Focus()
            '    Exit Function
            'End If

            'No se puede indicar secundaria > a NINGUNA 
            'si no se indicó último año de primaria:
            'If (CInt(cboSecundaria.Columns("sCodigoInterno").Value) > 1) And (cboPrimaria.Columns("sCodigoInterno").Value <> "7") Then
            '    MsgBox("Imposible indicar Educación Secundaria" & Chr(13) & _
            '           " si no se tiene la Primaria aprobada.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboSecundaria, "Imposible indicar Educación Secundaria si no se tiene la Primaria aprobada.")
            '    Me.cboSecundaria.Focus()
            '    Exit Function
            'End If

            ''Carrera Técnica:
            'If Me.cboCarreraTecnica.SelectedIndex = -1 Then
            '    MsgBox("Debe seleccionar una Carrera Técnica.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboCarreraTecnica, "Debe seleccionar una Carrera Técnica.")
            '    Me.cboCarreraTecnica.Focus()
            '    Exit Function
            'End If

            'No se puede indicar carrera técnica 
            'si no se indicó Secundaria con Ciclo Báscico:
            'If (CInt(cboCarreraTecnica.Columns("sCodigoInterno").Value) > 1) And (CInt(cboSecundaria.Columns("sCodigoInterno").Value) < 4) Then
            '    MsgBox("Imposible indicar Carrera Técnica si Socia" & Chr(13) & _
            '           " no tiene el Ciclo Básico aprobado.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSocia.SetError(Me.cboCarreraTecnica, "Imposible indicar Carrera Técnica si no se tiene el Ciclo Básico aprobado.")
            '    Me.cboCarreraTecnica.Focus()
            '    Exit Function
            'End If

            ''Verificar si la Socia ya forma parte de un GS no se puede
            ''Modificar el indicador de estar dispuesta a conformar GS.
            'If ModoFrm = "UPD" And Me.chkFormarGS.Checked = False Then
            '    ObjSclGS.Filter = " nSclSociaID = " & ObjSociadr.nSclSociaID
            '    ObjSclGS.Retrieve()
            '    If ObjSclGS.Count > 0 Then
            '        MsgBox("La socia ya forma parte de un GS.", MsgBoxStyle.Critical, NombreSistema)
            '        ValidaDatosEntrada = False
            '        Me.errSocia.SetError(Me.chkFormarGS, "La socia ya forma parte de un GS.")
            '        Me.chkFormarGS.Focus()
            '        Exit Function
            '    End If
            'End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjTmpSocia.Close()
            ObjTmpSocia = Nothing

            ObjSclGS.Close()
            ObjSclGS = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarSocia()
        Dim ObjTmpSocia As New BOSistema.Win.XDataSet
        Try
            Dim strSQL As String

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjSociadr.sUsuarioCreacion = InfoSistema.LoginName
                ObjSociadr.dFechaCreacion = FechaServer()
                '-- Delegación de la Socia:
                'No se ubica en el Update ya que podria estar modificando datos
                'un usuario de otra Delegación si esta tiene Acceso Total para
                'Edición con lo que se alteraría la Delegación de la Socia.
                ObjSociadr.nStbDelegacionProgramaID = InfoSistema.IDDelegacion
            Else
                ObjSociadr.sUsuarioModificacion = InfoSistema.LoginName
                ObjSociadr.dFechaModificacion = FechaServer()
            End If

            'Primer Nombre:
            ObjSociadr.sNombre1 = Trim(RTrim(Me.txtNombre1.Text))
            'Segundo Nombre:
            If Trim(RTrim(Me.txtNombre2.Text)).ToString.Length <> 0 Then
                ObjSociadr.sNombre2 = Trim(RTrim(Me.txtNombre2.Text))
            Else
                ObjSociadr.sNombre2 = ""
            End If
            'Primer Apellido:
            ObjSociadr.sApellido1 = Trim(RTrim(Me.txtApellido1.Text))
            'Segundo Apellido:
            If Trim(RTrim(Me.txtApellido2.Text)).ToString.Length <> 0 Then
                ObjSociadr.sApellido2 = Trim(RTrim(Me.txtApellido2.Text))
            Else
                ObjSociadr.sApellido2 = ""
            End If
            'Otro Tipo de Documento de Identificación:
            'If Me.cboOtroDocumento.SelectedIndex = -1 Then
            '    ObjSociadr.SetFieldNull("nStbTipoOtroDocumentoID")
            'Else
            '    ObjSociadr.nStbTipoOtroDocumentoID = Me.cboOtroDocumento.Columns("nStbValorCatalogoID").Value
            'End If
            'Otro Documento de Identificación:
            'If Trim(RTrim(Me.txtOtroDocumento.Text)).ToString.Length <> 0 Then
            '    ObjSociadr.sNumeroOtroDocumento = Trim(RTrim(Me.txtOtroDocumento.Text))
            'Else
            '    ObjSociadr.SetFieldNull("sNumeroOtroDocumento")
            'End If
            'Número de Cédula:
            ObjSociadr.sNumeroCedula = Trim(RTrim(Me.mtbNumCedula.Text))
            'Fecha de Nacimiento:
            ObjSociadr.dFechaNacimiento = CDate(StrFecha)
            'Estado Civil:
            If Me.cboEstadoCivil.SelectedIndex = -1 Then
                ObjSociadr.SetFieldNull("nStbEstadoCivilID")
            Else
                ObjSociadr.nStbEstadoCivilID = Me.cboEstadoCivil.Columns("nStbValorCatalogoID").Value
            End If
            'Número de hijos (vivos/dependientes):
            'ObjSociadr.nNumHijosVivos = Me.mtbNumHijos.Text
            'ObjSociadr.nNumHijosDependientes = Me.mtbHijosDep.Text
            ''Teléfono:
            'If Trim(RTrim(Me.txtTelefono.Text)).ToString.Length <> 0 Then
            '    ObjSociadr.sTelefonoSocia = Trim(RTrim(Me.txtTelefono.Text))
            'Else
            '    ObjSociadr.SetFieldNull("sTelefonoSocia")
            'End If
            ''Dispuesta a Formar GS:
            'If Me.chkFormarGS.Checked Then
            '    ObjSociadr.nDispuestaFormarGS = 1
            'Else
            '    ObjSociadr.nDispuestaFormarGS = 0
            'End If
            'Socia Activa:
            ObjSociadr.nSociaActiva = 1
            'Dirección:
            'If Trim(RTrim(Me.txtDireccion.Text)).ToString.Length <> 0 Then
            '    ObjSociadr.sDireccionSocia = Trim(RTrim(Me.txtDireccion.Text))
            'Else
            '    ObjSociadr.SetFieldNull("sDireccionSocia")
            'End If
            ''Ubicación Geográfica:
            'ObjSociadr.nStbBarrioID = Me.cboBarrio.Columns("nStbBarrioID").Value
            ''Nivel de Escolaridad:
            ''ObjSociadr.nStbPrimariaID = Me.cboPrimaria.Columns("nStbValorCatalogoID").Value
            'ObjSociadr.nStbSecundariaID = Me.cboSecundaria.Columns("nStbValorCatalogoID").Value
            'ObjSociadr.nStbCarreraTecnicaID = Me.cboCarreraTecnica.Columns("nStbValorCatalogoID").Value
            'If Me.chkAlfabetizada.Checked Then
            '    ObjSociadr.nAlfabetizada = 1
            'Else
            '    ObjSociadr.nAlfabetizada = 0
            'End If
            ''Otros Estudios:
            'If Trim(RTrim(Me.txtOtrosEstudios.Text)).ToString.Length <> 0 Then
            '    ObjSociadr.sOtrosEstudios = Trim(RTrim(Me.txtOtrosEstudios.Text))
            'Else
            '    ObjSociadr.SetFieldNull("sOtrosEstudios")
            'End If

            'Asignación del Código siguiente:
            If ModoForm = "ADD" Then
                strSQL = " SELECT max(nCodigo) as maxCodigo FROM SclSocia"
                If ObjTmpSocia.ExistTable("Socia") Then
                    ObjTmpSocia("Socia").ExecuteSql(strSQL)
                Else
                    ObjTmpSocia.NewTable(strSQL, "Socia")
                    ObjTmpSocia("Socia").Retrieve()
                End If

                If Not ObjTmpSocia("Socia").ValueField("maxCodigo") Is DBNull.Value Then
                    Me.txtCodigo.Text = Format(ObjTmpSocia("Socia").ValueField("maxCodigo") + 1) ', "00"
                Else
                    Me.txtCodigo.Text = "1"
                End If
            End If

            'Codigo: 
            ObjSociadr.nCodigo = Me.txtCodigo.Text

            If ModoForm <> "ADD" Then
                GuardarAuditoriaTablas(25, 2, "Actualizar Socia", ObjSociadr.nSclSociaID, InfoSistema.IDCuenta)
            End If




            ObjSociadr.Update()

            'Asignar el Id de la Socia a la variable publica del formulario:
            IdSclSocia = ObjSociadr.nSclSociaID

            If ModoForm = "ADD" Then
                GuardarAuditoriaTablas(25, 1, "Agregar Socia", ObjSociadr.nSclSociaID, InfoSistema.IDCuenta)
            End If
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
            ObjTmpSocia.Close()
            ObjTmpSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object
            'Si tenemos permiso para modificar
            If Me.cmdAceptar.Enabled Then

                If vbModifico = True Then
                    res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                    Select Case res
                        Case vbYes
                            'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                            If ValidaDatosEntrada() Then
                                SalvarSocia()
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
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarEstadoCivil
    ' Descripción:          Este procedimiento permite cargar el listado de Estados
    '                       Civiles en el combo para su selección.
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

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2007
    ' Procedure Name:       CargarDocumento
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Documentos de Identificación en el combo.
    '-------------------------------------------------------------------------
    'Private Sub CargarDocumento()
    '    Try
    '        Dim Strsql As String = ""

    '        'Limpiar Combo:
    '        Me.cboOtroDocumento.ClearFields()

    '        Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
    '                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
    '                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
    '                     " WHERE (b.sNombre = 'OtrosDocumentosIdentificacion') " & _
    '                     " ORDER BY a.sCodigoInterno"

    '        XdtDocumento.ExecuteSql(Strsql)
    '        Me.cboOtroDocumento.DataSource = XdtDocumento.Source
    '        cboOtroDocumento.Rebind()

    '        Me.cboOtroDocumento.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
    '        Me.cboOtroDocumento.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Configurar el combo
    '        Me.cboOtroDocumento.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
    '        Me.cboOtroDocumento.Splits(0).DisplayColumns("sDescripcion").Width = 100

    '        Me.cboOtroDocumento.Columns("sCodigoInterno").Caption = "Código"
    '        Me.cboOtroDocumento.Columns("sDescripcion").Caption = "Descripción"

    '        Me.cboOtroDocumento.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboOtroDocumento.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/09/2007
    ' Procedure Name:       CargarPrimaria
    ' Descripción:          Este procedimiento permite cargar el listado de niveles
    '                       de Escolaridad primaria en el combo para su selección.
    '-------------------------------------------------------------------------
    'Private Sub CargarPrimaria()
    '    Try
    '        Dim Strsql As String = ""

    '        Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
    '                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
    '                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
    '                     " WHERE (b.sNombre = 'EducacionPrimaria')" & _
    '                     " ORDER BY a.sCodigoInterno"

    '        If XdsEscolaridad.ExistTable("Primaria") Then
    '            XdsEscolaridad("Primaria").ExecuteSql(Strsql)
    '        Else
    '            XdsEscolaridad.NewTable(Strsql, "Primaria")
    '            XdsEscolaridad("Primaria").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboPrimaria.DataSource = XdsEscolaridad("Primaria").Source

    '        Me.cboPrimaria.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
    '        Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Configurar el combo
    '        Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
    '        Me.cboPrimaria.Splits(0).DisplayColumns("sDescripcion").Width = 100

    '        Me.cboPrimaria.Columns("sCodigoInterno").Caption = "Código"
    '        Me.cboPrimaria.Columns("sDescripcion").Caption = "Descripción"

    '        Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboPrimaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/09/2007
    ' Procedure Name:       CargarSecundaria
    ' Descripción:          Este procedimiento permite cargar el listado de niveles
    '                       de Escolaridad secundaria en el combo para su selección.
    '-------------------------------------------------------------------------
    'Private Sub CargarSecundaria()
    '    Try
    '        Dim Strsql As String = ""

    '        Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
    '                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
    '                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
    '                     " WHERE (b.sNombre = 'EducacionSecundaria') " & _
    '                     " ORDER BY a.sCodigoInterno"

    '        If XdsEscolaridad.ExistTable("Secundaria") Then
    '            XdsEscolaridad("Secundaria").ExecuteSql(Strsql)
    '        Else
    '            XdsEscolaridad.NewTable(Strsql, "Secundaria")
    '            XdsEscolaridad("Secundaria").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboSecundaria.DataSource = XdsEscolaridad("Secundaria").Source

    '        Me.cboSecundaria.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
    '        Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Configurar el combo
    '        Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
    '        Me.cboSecundaria.Splits(0).DisplayColumns("sDescripcion").Width = 100

    '        Me.cboSecundaria.Columns("sCodigoInterno").Caption = "Código"
    '        Me.cboSecundaria.Columns("sDescripcion").Caption = "Descripción"

    '        Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboSecundaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Ubicarlo en el primer registro:
    '        If Me.cboSecundaria.ListCount > 0 Then
    '            Me.cboSecundaria.SelectedIndex = 0
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    '' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/09/2007
    ' Procedure Name:       CargarCarreraTecnica
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Carreras Técnicas en el combo para su selección.
    '-------------------------------------------------------------------------
    'Private Sub CargarCarreraTecnica()
    '    Try
    '        Dim Strsql As String = ""

    '        Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
    '                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
    '                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
    '                     " WHERE (b.sNombre = 'CarreraTecnica') " & _
    '                     " ORDER BY a.sCodigoInterno"

    '        If XdsEscolaridad.ExistTable("CarreraTecnica") Then
    '            XdsEscolaridad("CarreraTecnica").ExecuteSql(Strsql)
    '        Else
    '            XdsEscolaridad.NewTable(Strsql, "CarreraTecnica")
    '            XdsEscolaridad("CarreraTecnica").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboCarreraTecnica.DataSource = XdsEscolaridad("CarreraTecnica").Source

    '        Me.cboCarreraTecnica.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
    '        Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Configurar el combo
    '        Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
    '        Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").Width = 100

    '        Me.cboCarreraTecnica.Columns("sCodigoInterno").Caption = "Código"
    '        Me.cboCarreraTecnica.Columns("sDescripcion").Caption = "Descripción"

    '        Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Ubicarlo en el primer registro:
    '        If Me.cboCarreraTecnica.ListCount > 0 Then
    '            Me.cboCarreraTecnica.SelectedIndex = 0
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    '' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    'Private Sub CargarDepartamento(ByVal intDepartamentoID As Integer)
    '    Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
    '    Try
    '        Dim Strsql As String

    '        If intDepartamentoID = 0 Then
    '            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
    '                     " From StbDepartamento a " & _
    '                     " Where (a.nActivo = 1) " & _
    '                     " Order by a.sCodigo"
    '        Else
    '            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
    '                     " From StbDepartamento a " & _
    '                     " Where (a.nActivo = 1) Or (a.nStbDepartamentoID = " & intDepartamentoID & ") " & _
    '                     " Order by a.sCodigo"
    '        End If


    '        If XdsUbicacion.ExistTable("Departamento") Then
    '            XdsUbicacion("Departamento").ExecuteSql(Strsql)
    '        Else
    '            XdsUbicacion.NewTable(Strsql, "Departamento")
    '            XdsUbicacion("Departamento").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

    '        XdtValorParametro.Filter = "nStbParametroID = 14"
    '        XdtValorParametro.Retrieve()

    '        'Ubicarse en el primer registro
    '        If XdsUbicacion("Departamento").Count > 0 Then
    '            XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
    '        End If

    '        'Configurar el combo Departamento:
    '        Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
    '        Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
    '        Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 80
    '        Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
    '        Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"
    '        Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XdtValorParametro.Close()
    '        XdtValorParametro = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    'Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
    '    Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
    '    Try
    '        Dim Strsql As String

    '        'Limpiar Combo:
    '        Me.cboMunicipio.ClearFields()

    '        If intLimpiarID = 0 Then
    '            If intMunicipioID = 0 Then
    '                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
    '                         " From StbMunicipio a " & _
    '                         " Where (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & _
    '                         " ) And (a.nActivo = 1) Order by a.sCodigo"
    '            Else
    '                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
    '                         " From StbMunicipio a " & _
    '                         " Where ((a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & ")" & _
    '                         " ) Or (a.nStbMunicipioID = " & intMunicipioID & _
    '                         " )  Order by a.sCodigo"
    '            End If
    '        Else
    '            Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
    '                     " From StbMunicipio a " & _
    '                     " WHERE a.nStbMunicipioID = 0" & _
    '                     " Order by a.sCodigo"
    '        End If

    '        If XdsUbicacion.ExistTable("Municipio") Then
    '            XdsUbicacion("Municipio").ExecuteSql(Strsql)
    '        Else
    '            XdsUbicacion.NewTable(Strsql, "Municipio")
    '            XdsUbicacion("Municipio").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboMunicipio.DataSource = XdsUbicacion("Municipio").Source
    '        Me.cboMunicipio.Rebind()

    '        XdtValorParametro.Filter = "nStbParametroID = 15"
    '        XdtValorParametro.Retrieve()

    '        'Ubicarse en el primer registro
    '        If XdsUbicacion("Municipio").Count > 0 Then
    '            XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
    '        End If

    '        'Configurar el combo Municipio:
    '        Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
    '        Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
    '        Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
    '        Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").Width = 100
    '        Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
    '        Me.cboMunicipio.Columns("sNombre").Caption = "Descripción"
    '        Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XdtValorParametro.Close()
    '        XdtValorParametro = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de Distritos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    'Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
    '    Try
    '        Dim Strsql As String

    '        'Limpiar Combo:
    '        Me.cboDistrito.ClearFields()

    '        If intLimpiarID = 0 Then
    '            If intDistritoID = 0 Then
    '                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
    '                         " From StbDistrito a " & _
    '                         " Where (a.nActivo = 1) " & _
    '                         " Order by a.sCodigo"
    '            Else
    '                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
    '                         " From StbDistrito a " & _
    '                         " Where (a.nActivo = 1) " & _
    '                         " Or (a.nStbDistritoID = " & intDistritoID & _
    '                         " )  Order by a.sCodigo"

    '            End If
    '        Else 'Limpiar = 0 Qry No regresa ningun Distrito:
    '            Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
    '                     " From StbDistrito a " & _
    '                     " Where a.nStbDistritoID = 0" & _
    '                     " Order by a.sCodigo"
    '        End If

    '        If XdsUbicacion.ExistTable("Distrito") Then
    '            XdsUbicacion("Distrito").ExecuteSql(Strsql)
    '        Else
    '            XdsUbicacion.NewTable(Strsql, "Distrito")
    '            XdsUbicacion("Distrito").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboDistrito.DataSource = XdsUbicacion("Distrito").Source
    '        Me.cboDistrito.Rebind()

    '        'Configurar el combo Distritos:
    '        Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
    '        Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
    '        Me.cboDistrito.Splits(0).DisplayColumns("sNombre").Width = 80
    '        Me.cboDistrito.Columns("sCodigo").Caption = "Código"
    '        Me.cboDistrito.Columns("sNombre").Caption = "Descripción"
    '        Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboDistrito.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    '' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    'Private Sub CargarBarrio(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
    '    Try
    '        Dim Strsql As String

    '        'Limpiar Combo:
    '        Me.cboBarrio.ClearFields()

    '        If intLimpiarID = 0 Then
    '            If intBarrioID = 0 Then
    '                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
    '                         " From StbBarrio a " & _
    '                         " Where (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
    '                         " )  And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & _
    '                         " ) Order by a.sCodigo"
    '            Else
    '                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
    '                         " From StbBarrio a " & _
    '                         " Where ((a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
    '                         " ) And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & ")" & _
    '                         " ) Or (a.nStbBarrioID = " & intBarrioID & _
    '                         " ) Order by a.sCodigo"
    '            End If
    '        Else
    '            Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
    '                     " From StbBarrio a " & _
    '                     " Where a.nStbBarrioID = 0"
    '        End If

    '        If XdsUbicacion.ExistTable("Barrio") Then
    '            XdsUbicacion("Barrio").ExecuteSql(Strsql)
    '        Else
    '            XdsUbicacion.NewTable(Strsql, "Barrio")
    '            XdsUbicacion("Barrio").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboBarrio.DataSource = XdsUbicacion("Barrio").Source
    '        Me.cboBarrio.Rebind()

    '        'Configurar el combo Barrio:
    '        Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
    '        Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
    '        Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
    '        Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
    '        Me.cboBarrio.Splits(0).DisplayColumns("sNombre").Width = 100
    '        Me.cboBarrio.Columns("sCodigo").Caption = "Código"
    '        Me.cboBarrio.Columns("sNombre").Caption = "Descripción"
    '        Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboBarrio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    'Solo se permite Letras A - Z, Letras con Acentos, BackSpace y la Barra espaciadora
    Private Sub txtNombre1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre1.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Nombre de la Sucursal
    Private Sub txtNombre1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre1.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, BackSpace y la Barra espaciadora
    Private Sub txtNombre2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre2.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Nombre del Gerente
    Private Sub txtNombre2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre2.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, números, BackSpace y la Barra espaciadora
    Private Sub txtApellido1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido1.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Primer Apellido
    Private Sub txtApellido1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido1.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, BackSpace y la Barra espaciadora:
    Private Sub txtApellido2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido2.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Nombre del Gerente
    Private Sub txtApellido2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellido2.TextChanged
        vbModifico = True
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboEstadoCivil_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboEstadoCivil.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en el Estado Civil
    Private Sub cboEstadoCivil_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstadoCivil.TextChanged
        vbModifico = True
    End Sub

    'Indicar que hubo modificación
    Private Sub chkFormarGS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    'Para controlar la ubicación del foco en el checkbox Formar GS
    Private Sub chkFormarGS_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Me.chkFormarGS.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Para controlar cuando el checkbox pierde el foco
    Private Sub chkFormarGS_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'Me.chkFormarGS.BackColor = Me.grpSociaGe.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()) BackSpace y la Barra espaciadora
    Private Sub txtDireccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en la Dirección
    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    'Solo se permite Números, () , - BackSpace y la Barra espaciadora
    Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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
    Private Sub txtTelefono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboDepartamento_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs)
        Control_Error(e.Exception)
    End Sub

    'En el cambio de Departamentos refresh CmbMunicipio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If Me.cboDepartamento.SelectedIndex <> -1 Then
        '    CargarMunicipio(0, 0)
        'Else
        '    CargarMunicipio(1, 0)
        'End If
        'vbModifico = True
    End Sub

    Private Sub mtbNumCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumCedula.TextChanged
        vbModifico = True
        If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
            Me.txtNombre1.Enabled = True
            Me.txtNombre2.Enabled = True
            Me.txtApellido1.Enabled = True
            Me.txtApellido2.Enabled = True
        End If

        'Si la longitud es 16:
        If Len(Me.mtbNumCedula.Text) = 16 Then
            'Si no es el Formato: "999-999999-9999Z"
            If Me.mtbNumCedula.Text <> "999-999999-9999Z" Then
                'Si es Cedula Valida del Padron o no se ha Buscado:
                If nLimpiar = 1 Then
                    'Limpiar Nombres y Apellidos:
                    Me.txtNombre1.Text = ""
                    Me.txtNombre2.Text = ""
                    Me.txtApellido1.Text = ""
                    Me.txtApellido2.Text = ""
                    'Bloquear Nombres y Apellidos:
                    Me.txtNombre1.Enabled = False
                    Me.txtNombre2.Enabled = False
                    Me.txtApellido1.Enabled = False
                    Me.txtApellido2.Enabled = False

                    'OJO SOLAMENTE QUE TENGA PERMISO PARA MODIFICAR SOCIAS
                    If Seg.HasPermission("ModificarNombreSocia") = True Then

                        Me.txtNombre1.Enabled = True
                        Me.txtNombre2.Enabled = True
                        Me.txtApellido1.Enabled = True


                        Me.txtApellido2.Enabled = True
                    End If
                    'FIN OJO
                    Me.ValidarCedula()
                End If
            End If
        End If
    End Sub

    Private Sub mtbNumHijos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub mtbHijosDep_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()) BackSpace y la Barra espaciadora
    Private Sub txtOtrosEstudios_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtOtrosEstudios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    If Me.cboMunicipio.SelectedIndex <> -1 Then
        '        If Me.cboMunicipio.Text = "Managua" Then
        '            CargarDistrito(0, 0)
        '            Me.cboDistrito.Enabled = True
        '        Else
        '            CargarDistrito(0, 0)
        '            If Me.cboDistrito.ListCount > 0 Then
        '                Me.cboDistrito.SelectedIndex = 0
        '            End If
        '            Me.cboDistrito.Enabled = False
        '        End If
        '    Else
        '        CargarDistrito(1, 0)
        '        CargarBarrio(1, 0)
        '    End If
        '    vbModifico = True

        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    If Me.cboDistrito.SelectedIndex <> -1 Then
        '        CargarBarrio(0, 0)
        '    Else
        '        CargarBarrio(1, 0)
        '    End If
        '    vbModifico = True
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboPrimaria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboSecundaria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboCarreraTecnica_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub chkAlfabetizada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub chkAlfabetizada_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        '    Me.chkAlfabetizada.BackColor = Color.White
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub chkAlfabetizada_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        '    Me.chkFormarGS.BackColor = Me.grpSociaGe.BackColor
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub cboOtroDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub txtOtroDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     29/09/2008
    ' Procedure name                :     BlnCedulaValidaPadron
    ' Description                   :     Indica si una Cedula existe en la BD del Padrón.
    ' -----------------------------------------------------------------------------------------
    Public Function BlnCedulaValidaPadron(ByVal sCedula As String, ByVal ModificarNombreSocia As Boolean, ByVal searchPadron As Boolean) As Boolean
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim XdtTmpConsulta2 As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrConsulta As String
            BlnCedulaValidaPadron = False

            If searchPadron And Me.ModoForm.Equals("ADD") Then

                StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2 " & _
                                             "FROM [SMCU0-Padron].dbo.SclCatalogoPersona " & _
                                             "WHERE (sNumeroCedula = '" & sCedula & "')"

                XdtTmpConsulta.ExecuteSql(StrConsulta)

                If XdtTmpConsulta.Count > 0 Then
                    BlnCedulaValidaPadron = True
                    Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                    Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                    Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                    Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                End If

            Else
                If searchPadron And (ModificarNombreSocia Or Me.ModoForm.Equals("UPD")) Then

                    Dim mensaje As String = ""

                    BlnCedulaValidaPadron = True

                    StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2 " & _
                                                                     "FROM dbo.SclSocia " & _
                                                                     "WHERE (sNumeroCedula = '" & sCedula & "')"

                    XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
                    XdtTmpConsulta.ExecuteSql(StrConsulta)

                    StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2 " & _
                                                                    "FROM [SMCU0-Padron].dbo.SclCatalogoPersona " & _
                                                                    "WHERE (sNumeroCedula = '" & sCedula & "')"

                    XdtTmpConsulta2.ExecuteSql(StrConsulta)

                    'If ModificarNombreSocia Then

                    If XdtTmpConsulta.Count > 0 Then

                        If XdtTmpConsulta2.Count > 0 Then

                            If ModificarNombreSocia Then

                                If XdtTmpConsulta2.ValueField("sNombre1") <> XdtTmpConsulta.ValueField("sNombre1") Then
                                    mensaje += "Primer Nombre"
                                End If
                                If XdtTmpConsulta2.ValueField("sNombre2") <> XdtTmpConsulta.ValueField("sNombre2") Then

                                    mensaje += IIf(String.IsNullOrEmpty(mensaje), "", ", ") + "Segundo Nombre"
                                End If
                                If XdtTmpConsulta2.ValueField("sApellido1") <> XdtTmpConsulta.ValueField("sApellido1") Then
                                    mensaje += IIf(String.IsNullOrEmpty(mensaje), "", ", ") + "Primer Apellido"
                                End If
                                If XdtTmpConsulta2.ValueField("sApellido2") <> XdtTmpConsulta.ValueField("sApellido2") Then
                                    mensaje += IIf(String.IsNullOrEmpty(mensaje), "", ", ") + "Segundo Apellido"
                                End If

                                If Not String.IsNullOrEmpty(mensaje) Then
                                    If MsgBox(String.Format("El {0} no coinciden entre el padron y la socia.", mensaje.ToString()) + (Chr(13)) _
                                            + "¿Desea tomar los valores del padron?", MsgBoxStyle.Information + MsgBoxStyle.OkCancel, "Datos Socia") = MsgBoxResult.Ok Then
                                        'Ubicar Nombres:
                                        Me.txtNombre1.Text = XdtTmpConsulta2.ValueField("sNombre1")
                                        Me.txtNombre2.Text = XdtTmpConsulta2.ValueField("sNombre2")
                                        Me.txtApellido1.Text = XdtTmpConsulta2.ValueField("sApellido1")
                                        Me.txtApellido2.Text = XdtTmpConsulta2.ValueField("sApellido2")
                                    Else
                                        Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                                        Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                                        Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                                        Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                                    End If
                                End If
                            End If
                        Else
                            Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                            Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                            Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                            Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                        End If


                    Else
                        'si no lo encuentra en la tabla socia
                        Me.txtNombre1.Text = XdtTmpConsulta2.ValueField("sNombre1")
                        Me.txtNombre2.Text = XdtTmpConsulta2.ValueField("sNombre2")
                        Me.txtApellido1.Text = XdtTmpConsulta2.ValueField("sApellido1")
                        Me.txtApellido2.Text = XdtTmpConsulta2.ValueField("sApellido2")
                        MsgBox(String.Format("La Socia con Cédula {0} no existe", sCedula), MsgBoxStyle.Information)
                    End If
                    BlnCedulaValidaPadron = True

                Else

                    If Not ModificarNombreSocia Then

                        StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2 " & _
                                                                          "FROM dbo.SclSocia " & _
                                                                          "WHERE (sNumeroCedula = '" & sCedula & "')"
                        XdtTmpConsulta.ExecuteSql(StrConsulta)

                        If XdtTmpConsulta.Count > 0 Then

                            BlnCedulaValidaPadron = True

                            Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                            Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                            Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                            Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")

                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            Control_Error(ex)
            BlnCedulaValidaPadron = False
        Finally
            XdtTmpConsulta.Close()
            XdtTmpConsulta = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Josué Herrera
    ' Date                          :     29/09/2008
    ' Procedure name                :     CedulaRepetida
    ' Description                   :     verifica si una cédula que no está en el padron,
    '                                     se encuentra repetida.
    ' -----------------------------------------------------------------------------------------
    Public Function CedulaRepetida(ByVal sCedula As String) As String
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim resultado As String = String.Empty
        Try
            Dim StrConsulta As String

            StrConsulta = "select * " & _
                           "from SclSocia s " & _
                           "where s.sNumeroCedula = '" & sCedula & "'" & _
                           "      and s.nSociaActiva = 1 "

            XdtTmpConsulta.ExecuteSql(StrConsulta)
            If XdtTmpConsulta.Count > 0 Then

                'Ubicar Nombres:
                resultado = XdtTmpConsulta.ValueField("sNombre1") + " "
                resultado += XdtTmpConsulta.ValueField("sNombre2") + " "
                resultado += XdtTmpConsulta.ValueField("sApellido1") + ""
                resultado += XdtTmpConsulta.ValueField("sApellido2")
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpConsulta.Close()
            XdtTmpConsulta = Nothing
        End Try
        Return resultado
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     29/09/2008
    ' Procedure name                :     cmdBuscar_Click
    ' Description                   :     Busca una Cedula en la BD del Padrón.
    ' -----------------------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Me.ValidarCedula(True)
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author                        :     Yesenia Gutiérrez
    ' Date                          :     29/09/2008
    ' Procedure name                :     cmdBuscar_Click
    ' Description                   :     Busca una Cedula en la BD del Padrón.
    ' -----------------------------------------------------------------------------------------
    Private Sub ValidarCedula(Optional ByVal searchPadron As Boolean = False)
        Try
            Me.errSocia.Clear()
            'Limpiar Nombres y Apellidos:
            Me.txtNombre1.Text = ""
            Me.txtNombre2.Text = ""
            Me.txtApellido1.Text = ""
            Me.txtApellido2.Text = ""

            nLimpiar = 0

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'NO Buscar en el Padrón si corresponde a Formato:
            If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
                MsgBox("El Número de Cédula NO existe en el Padrón." & Chr(13) & "Favor indicar Nombres y Apellidos.", MsgBoxStyle.Information, NombreSistema)
                'Habilitar Nombres:
                Me.txtNombre1.Enabled = True
                Me.txtNombre2.Enabled = True
                Me.txtApellido1.Enabled = True
                Me.txtApellido2.Enabled = True
                Me.txtNombre1.Select()
                Exit Sub
            End If

            'Fecha Valida:
            StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
            If Not IsDate(StrFecha) Then
                MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errSocia.SetError(Me.mtbNumCedula, "Fecha Inválida en el Número de Cédula.")
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Número de Cédula Válido:
            Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                Case Cedula.Invalida
                    MsgBox("El Número de Cédula de la Socia es invalido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "Número de Cédula de la Socia es invalido.")
                    Me.mtbNumCedula.Focus()
                    Exit Sub
                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "Longitud del Número de Cédula es incorrecta.")
                    Me.mtbNumCedula.Focus()
                    Exit Sub
            End Select

            Seg.RefreshPermissions()

            Dim ModificarNombreSocia As Boolean = False
            ModificarNombreSocia = Seg.HasPermission("ModificarNombreSocia")
            Dim Enabled As Boolean = Seg.HasPermission("AgregarCedula")

            'Buscar Cédula en el Padrón:
            '1. Si NO existe habilitar Nombres Else Bloquearlos:
            If BlnCedulaValidaPadron(Me.mtbNumCedula.Text, ModificarNombreSocia, searchPadron) = True Then
                Me.cmdAceptar.Enabled = True
                Me.txtNombre1.Enabled = ModificarNombreSocia
                Me.txtNombre2.Enabled = ModificarNombreSocia
                Me.txtApellido1.Enabled = ModificarNombreSocia
                Me.txtApellido2.Enabled = ModificarNombreSocia
                'Me.txtTelefono.Select()
                nLimpiar = 1
            Else
                ' Si tiene permiso para agregar cédula
                ' permitirle guardar a la socia, sin nececidad que esta
                ' se encuentre en el padron

                Dim str As String = String.Empty
                str = IIf(Not Enabled, " Usted no tiene permiso para agregar nuevas cédulas.", "")


                If searchPadron Then
                    MsgBox(String.Format("La cédula {0} no existe en el padron. {1} ", Me.mtbNumCedula.Text, str), MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, String.Format("La cédula {0} no existe en el padron. {1} ", Me.mtbNumCedula.Text, str))
                    Me.mtbNumCedula.Focus()
                End If

                cmdAceptar.Enabled = Enabled
                Me.txtNombre1.Enabled = Enabled
                Me.txtNombre2.Enabled = Enabled
                Me.txtApellido1.Enabled = Enabled
                Me.txtApellido2.Enabled = Enabled

                If Enabled And searchPadron Then
                    Dim socia As String = Me.CedulaRepetida(Me.mtbNumCedula.Text)
                    If String.IsNullOrEmpty(socia) Then
                        If Not MsgBox("El Número de Cédula NO existe en el Padrón." & Chr(13) & "Aún así desea agregar a la socia con esta Cédula?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                            Me.txtNombre1.Enabled = False
                            Me.txtNombre2.Enabled = False
                            Me.txtApellido1.Enabled = False
                            Me.txtApellido2.Enabled = False
                            cmdAceptar.Enabled = False
                            Me.txtNombre1.Select()
                        End If
                    Else
                        MsgBox(String.Format("La socia: {0} ya tiene asignada la cédula.", socia) & Chr(13) & "Favor indicar otro número de cédula.", MsgBoxStyle.Information, NombreSistema)
                    End If
                    'Else
                    '    MsgBox("El Número de Cédula NO existe en el Padrón." & Chr(13) & "Favor indicar Nombres y Apellidos.", MsgBoxStyle.Information, NombreSistema)
                    '    Me.txtNombre1.Enabled = True
                    '    Me.txtNombre2.Enabled = True
                    '    Me.txtApellido1.Enabled = True
                    '    Me.txtApellido2.Enabled = True
                    '    Me.bValidar = False
                    '    Me.txtNombre1.Select()
                    '    Me.bValidar = True
                End If

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mtbNumCedula_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bValidar Then
            Me.ValidarCedula()
        End If
    End Sub

    Private Sub cmdEditarCedula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditarCedula.Click
        Dim ObjFrm As New frmSclEditSociaCedula
        Try
            ObjFrm.IdSocia = Me.IdSocia
            ObjFrm.NombreSocia = Me.txtNombre1.Text & " " & Me.txtNombre2.Text & " " & Me.txtApellido1.Text & " " & Me.txtApellido2.Text
            ObjFrm.CedulaSocia = mtbNumCedula.Text
            ObjFrm.ModoFrm = "ADD"
            ObjFrm.ShowDialog()
            Me.mtbNumCedula.Text = ObjFrm.CedulaSocia
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrm.Close()
            ObjFrm = Nothing
        End Try
    End Sub
End Class