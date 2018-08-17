' ------------------------------------------------------------------------
' Project Item Name:    frmSclEditSocia.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Conyuges de Socias.
'-------------------------------------------------------------------------
Imports System.io

Public Class frmSclEditSociaConyuge

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSclSocia As Long 'SclSocia.nSclSociaID
    Dim strNombreSocia As String
    Dim nLimpiar As Integer
    Dim StrFecha As String
    Dim bValidar As Boolean = True
    Dim nSclConyugeID As Integer

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjSociadt As BOSistema.Win.SclEntSocia.SclSociaConyugeDataTable
    Dim ObjSociadr As BOSistema.Win.SclEntSocia.SclSociaConyugeRow

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

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property NombreSocia() As String
        Get
            NombreSocia = strNombreSocia
        End Get
        Set(ByVal value As String)
            strNombreSocia = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Procedure Name:       frmSclEditSociaConyuge_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSociaConyuge_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjSociadt.Close()
                ObjSociadt = Nothing

                ObjSociadr.Close()
                ObjSociadr = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ---------------------------------------------------------------------------------------------------------------
    ' Procedure Name:       frmSclEditSociaConyuge_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables y se cargan datos de la Socia 
    '                       en caso de estar en el modo de Modificar.
    '----------------------------------------------------------------------------------------------------------------
    Private Sub frmSclEditSociaConyuge_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Dim XdtTmpConsulta As New BOSistema.Win.XDataSet.xDataTable
        Dim StrConsulta As String

        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            Seg.RefreshPermissions()
            Me.txtSocia.Text = Me.NombreSocia
            Me.optSi.Select()

            ' Buscar si existe un "Cónyuge" asociado a estar socia y si está activo
            StrConsulta = "SELECT nSclConyugeID FROM dbo.SclSociaConyuge GROUP BY nSclSociaID, nActivo, nSclConyugeID " & _
                          "HAVING nSclSociaID = " & Me.IdSclSocia & " AND nActivo = 1"
            XdtTmpConsulta.ExecuteSql(StrConsulta)
            If XdtTmpConsulta.Count > 0 Then
                nSclConyugeID = XdtTmpConsulta.ValueField("nSclConyugeID")
                ModoFrm = "UPD"
                CargarSocia()
                cmdAceptar.Enabled = True
                InhabilitarControles()
                ' Si no tiene permiso de agregar cédula deshabilitar la busqueda y modificación de la cédula
                If Not Seg.HasPermission("ModificarNombreSocia") Then
                    Me.mtbNumCedula.Enabled = False
                    Me.cmdBuscar.Enabled = False
                End If
            Else
                ModoFrm = "ADD"
                ' Si no tiene permiso de agregar cédula deshabilitar la busqueda y modificación de la cédula
                Dim enabled As Boolean = Seg.HasPermission("ModificarNombreSocia")
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
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            ''Si la Socia esta Inactiva:
            'If ObjSociadr.nSociaActiva = 0 Then
            '    Me.cmdAceptar.Enabled = False
            '    Me.grpSociaGe.Enabled = False
            'End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
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

            ObjSociadt = New BOSistema.Win.SclEntSocia.SclSociaConyugeDataTable
            ObjSociadr = New BOSistema.Win.SclEntSocia.SclSociaConyugeRow

            If ModoFrm = "ADD" Then
                ObjSociadr = ObjSociadt.NewRow
                'Inicializar los Length de los campos (Strings)
                Me.txtNombre1.MaxLength = ObjSociadr.GetColumnLenght("sNombre1")
                Me.txtNombre2.MaxLength = ObjSociadr.GetColumnLenght("sNombre2")
                Me.txtApellido1.MaxLength = ObjSociadr.GetColumnLenght("sApellido1")
                Me.txtApellido2.MaxLength = ObjSociadr.GetColumnLenght("sApellido2")
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

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Procedure Name:       CargarSocia
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarSocia()
        Dim XcUbicacion As New BOSistema.Win.XComando

        Try

            '-- Buscar la Socia correspondiente al Id especificado como parámetro, en los casos que se esté editando una.
            ObjSociadt.Filter = "nSclSociaID = " & IdSocia & " and nSclConyugeID = " & nSclConyugeID
            ObjSociadt.Retrieve()
            If ObjSociadt.Count = 0 Then 'No hay socias registradas (ADD).
                Exit Sub
            End If
            ObjSociadr = ObjSociadt.Current 'Socia actual.

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

            'Telefono:
            If Not ObjSociadr.IsFieldNull("sTelefonoConyuge") Then
                Me.txtTelefono.Text = ObjSociadr.sTelefonoConyuge
            Else
                Me.txtTelefono.Text = ""
            End If

            'Celular
            If Not ObjSociadr.IsFieldNull("sCelularConyuge") Then
                Me.txtCelular.Text = ObjSociadr.sCelularConyuge
            Else
                Me.txtCelular.Text = ""
            End If

            'Fax:
            If Not ObjSociadr.IsFieldNull("sFaxConyuge") Then
                Me.txtFax.Text = ObjSociadr.sFaxConyuge
            Else
                Me.txtFax.Text = ""
            End If

            'Email:
            If Not ObjSociadr.IsFieldNull("SEmailConyuge") Then
                Me.txtEmail.Text = ObjSociadr.SEmailConyuge
            Else
                Me.txtEmail.Text = ""
            End If

            'Sexo:
            If Not ObjSociadr.IsFieldNull("sSexo") Then
                If ObjSociadr.sSexo = "M" Then
                    optSMasculino.Checked = True
                Else
                    optSFemenino.Checked = True
                End If
            End If

            '¿Tiene Cedula?:
            If Not ObjSociadr.IsFieldNull("nTieneCedula") Then
                If ObjSociadr.nTieneCedula = "1" Then
                    optSi.Checked = True
                Else
                    optNo.Checked = True
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtNombre1.MaxLength = ObjSociadr.GetColumnLenght("sNombre1")
            Me.txtNombre2.MaxLength = ObjSociadr.GetColumnLenght("sNombre2")
            Me.txtApellido1.MaxLength = ObjSociadr.GetColumnLenght("sApellido1")
            Me.txtApellido2.MaxLength = ObjSociadr.GetColumnLenght("sApellido2")
            'Me.txtTelefono.MaxLength = ObjSociadr.GetColumnLenght("sTelefonoConyuge")
            'Me.mtbNumCedula.MaxLength = ObjSociadr.GetColumnLenght("sNumeroCedula")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
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
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaConyugeDataTable

        Try

            ValidaDatosEntrada = True
            Me.errSocia.Clear()

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) And optSi.Checked = True Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'NO validar Número de Cédula si no corresponde a Formato: Y establecer como fecha de nacimiento: 30/05/1964
            If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
                StrFecha = "30/05/1964"
            Else
                'Fecha válida en número de Cédula:
                StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
                If Not IsDate(StrFecha) And optSi.Checked = True Then
                    MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula debe contener una fecha válida.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
                'Determinar Duplicados en el Número de Cédula:
                If ModoFrm = "UPD" Then
                    ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And nSclSociaID <> " & IdSocia
                Else
                    ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "'" ' And nSclSociaID = " & IdSocia
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
                        If optSi.Checked = True Then
                            MsgBox("El Número de Cédula de la Socia es invalido.", MsgBoxStyle.Critical, NombreSistema)
                            ValidaDatosEntrada = False
                            Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia es invalido.")
                            Me.mtbNumCedula.Focus()
                            Exit Function
                        End If
                    Case Cedula.LongitudIncorrecta
                        If optSi.Checked = True Then
                            MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                            ValidaDatosEntrada = False
                            Me.errSocia.SetError(Me.mtbNumCedula, "La Longitud del Número de Cédula de la Socia es incorrecta.")
                            Me.mtbNumCedula.Focus()
                            Exit Function
                        End If
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

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjTmpSocia.Close()
            ObjTmpSocia = Nothing
        End Try
    End Function

    ' ----------------------------------------------------------------------------------
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-----------------------------------------------------------------------------------
    Private Sub SalvarSocia()
        Dim ObjTmpSocia As New BOSistema.Win.XDataSet
        Dim Data As New BOSistema.Win.XComando

        Try

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjSociadr.sUsuarioCreacion = InfoSistema.LoginName
                ObjSociadr.dFechaCreacion = FechaServer()
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

            'Teléfono:
            If Trim(RTrim(Me.txtTelefono.Text)).ToString.Length <> 0 Then
                ObjSociadr.sTelefonoConyuge = Trim(RTrim(Me.txtTelefono.Text))
            Else
                ObjSociadr.sTelefonoConyuge = ""
            End If

            'Celular:
            If Trim(RTrim(Me.txtCelular.Text)).ToString.Length <> 0 Then
                ObjSociadr.sCelularConyuge = Trim(RTrim(Me.txtCelular.Text))
            Else
                ObjSociadr.sCelularConyuge = ""
            End If

            'Fax:
            If Trim(RTrim(Me.txtFax.Text)).ToString.Length <> 0 Then
                ObjSociadr.sFaxConyuge = Trim(RTrim(Me.txtFax.Text))
            Else
                ObjSociadr.sFaxConyuge = ""
            End If

            'Email
            If Trim(RTrim(Me.txtEmail.Text)).ToString.Length <> 0 Then
                ObjSociadr.SEmailConyuge = Trim(RTrim(Me.txtEmail.Text))
            Else
                ObjSociadr.SEmailConyuge = ""
            End If

            'Sexo:
            If optSMasculino.Checked = True Then
                ObjSociadr.sSexo = "M"
            Else
                ObjSociadr.sSexo = "F"
            End If

            'TieneCedula?:
            If optSi.Checked = True Then
                ObjSociadr.nTieneCedula = 1
                ObjSociadr.dFechaNacimiento = CDate(StrFecha)
                'Cedula
                If Trim(RTrim(Me.mtbNumCedula.Text)).ToString.Length <> 0 Then
                    ObjSociadr.sNumeroCedula = Trim(RTrim(Me.mtbNumCedula.Text))
                Else
                    ObjSociadr.sNumeroCedula = ""
                End If
            Else
                ObjSociadr.nTieneCedula = 0
            End If

            ObjSociadr.nSclSociaID = Me.IdSocia
            ObjSociadr.nActivo = 1

            Data.Execute("Update SclSociaConyuge SET nActivo = 0 WHERE nSclSociaID = " & Me.IdSocia)

            ObjSociadr.Update()

            'Asignar el Id de la Socia a la variable publica del formulario:
            IdSclSocia = ObjSociadr.nSclSociaID

            'Si el salvado se realizó de forma satisfactoria enviar mensaje informando y cerrar el formulario.
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

    ' ----------------------------------------------------------------------------------
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-----------------------------------------------------------------------------------
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

    ' -----------------------------------------------------------------------------------------
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

                StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2, sSexo " & _
                                             "FROM [SMCU0-Padron].dbo.SclCatalogoPersona " & _
                                             "WHERE (sNumeroCedula = '" & sCedula & "')"
                XdtTmpConsulta.ExecuteSql(StrConsulta)
                If XdtTmpConsulta.Count > 0 Then
                    BlnCedulaValidaPadron = True
                    Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                    Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                    Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                    Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                    If XdtTmpConsulta.ValueField("sSexo") = "M" Then ' Masculino
                        optSMasculino.Select()
                    Else ' Femenino
                        optSFemenino.Select()
                    End If
                End If
            Else
                If searchPadron And (ModificarNombreSocia Or Me.ModoForm.Equals("UPD")) Then
                    Dim mensaje As String = ""

                    BlnCedulaValidaPadron = True

                    StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2, sSexo " & _
                                                                     "FROM dbo.SclSociaConyuge " & _
                                                                     "WHERE (sNumeroCedula = '" & sCedula & "')"

                    XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
                    XdtTmpConsulta.ExecuteSql(StrConsulta)

                    StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2, sSexo " & _
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
                                        If XdtTmpConsulta2.ValueField("sSexo") = "M" Then ' Masculino
                                            optSMasculino.Select()
                                        Else ' Femenino
                                            optSFemenino.Select()
                                        End If
                                    Else
                                        Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                                        Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                                        Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                                        Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                                        If XdtTmpConsulta.ValueField("sSexo") = "M" Then ' Masculino
                                            optSMasculino.Select()
                                        Else ' Femenino
                                            optSFemenino.Select()
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                            Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                            Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                            Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                            If XdtTmpConsulta.ValueField("sSexo") = "M" Then ' Masculino
                                optSMasculino.Select()
                            Else ' Femenino
                                optSFemenino.Select()
                            End If
                        End If
                    Else
                        'si no lo encuentra en la tabla socia
                        Me.txtNombre1.Text = XdtTmpConsulta2.ValueField("sNombre1")
                        Me.txtNombre2.Text = XdtTmpConsulta2.ValueField("sNombre2")
                        Me.txtApellido1.Text = XdtTmpConsulta2.ValueField("sApellido1")
                        Me.txtApellido2.Text = XdtTmpConsulta2.ValueField("sApellido2")
                        If XdtTmpConsulta2.ValueField("sSexo") = "M" Then ' Masculino
                            optSMasculino.Select()
                        Else ' Femenino
                            optSFemenino.Select()
                        End If
                        'MsgBox(String.Format("La Socia con Cédula {0} no existe", sCedula), MsgBoxStyle.Information)
                    End If
                    BlnCedulaValidaPadron = True
                Else
                    If Not ModificarNombreSocia Then
                        StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2, sSexo " & _
                                                                          "FROM dbo.SclSociaConyuge " & _
                                                                          "WHERE (sNumeroCedula = '" & sCedula & "')"
                        XdtTmpConsulta.ExecuteSql(StrConsulta)
                        If XdtTmpConsulta.Count > 0 Then
                            BlnCedulaValidaPadron = True
                            Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                            Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                            Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                            Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                            If XdtTmpConsulta.ValueField("sSexo") = "M" Then ' Masculino
                                optSMasculino.Select()
                            Else ' Femenino
                                optSFemenino.Select()
                            End If
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
                           "from SclSociaConyuge s " & _
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
    ' Procedure name                :     cmdBuscar_Click
    ' Description                   :     Busca una Cedula en la BD del Padrón.
    ' -----------------------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Me.ValidarCedula(True)
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Procedure name                :     cmdBuscar_Click
    ' Description                   :     Busca una Cedula en la BD del Padrón.
    ' -----------------------------------------------------------------------------------------
    Private Sub ValidarCedula(Optional ByVal searchPadron As Boolean = False)
        Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaConyugeDataTable

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
                MsgBox("El Número de Cédula NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula NO DEBE quedar vacío.")
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
                    MsgBox("El Número de Cédula es invalido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "Número de Cédula es invalido.")
                    Me.mtbNumCedula.Focus()
                    Exit Sub
                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del Número de Cédula es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "Longitud del Número de Cédula es incorrecta.")
                    Me.mtbNumCedula.Focus()
                    Exit Sub
            End Select

            If ModoFrm = "UPD" Then
                ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And nSclSociaID <> " & IdSocia
            Else
                ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "'" ' And nSclSociaID = " & IdSocia
            End If
            ObjTmpSocia.Retrieve() 'Obtener los datos filtrados.
            If ObjTmpSocia.Count > 0 Then
                MsgBox("El Número de Cédula NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula NO DEBE repetirse.")
                Me.txtNombre1.Text = ""
                Me.txtNombre2.Text = ""
                Me.txtApellido1.Text = ""
                Me.txtApellido2.Text = ""
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            Seg.RefreshPermissions()

            Dim ModificarNombreSocia As Boolean = False
            ModificarNombreSocia = Seg.HasPermission("ModificarNombreSocia")
            Dim Enabled As Boolean = Seg.HasPermission("AgregarCedula")

            'Buscar Cédula en el Padrón:
            '1. Si NO existe habilitar Nombres Else Bloquearlos:
            If BlnCedulaValidaPadron(Me.mtbNumCedula.Text, ModificarNombreSocia, searchPadron) = True Then
                Me.cmdAceptar.Enabled = True
                Me.txtNombre1.Enabled = False ' ModificarNombreSocia
                Me.txtNombre2.Enabled = False ' ModificarNombreSocia
                Me.txtApellido1.Enabled = False ' ModificarNombreSocia
                Me.txtApellido2.Enabled = False ' ModificarNombreSocia
                Me.txtTelefono.Select()
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
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtCelular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelular.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtCelular_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCelular.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtFax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFax.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And UCase(e.KeyChar) <> "_" And UCase(e.KeyChar) <> "." And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "@" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.TextChanged
        vbModifico = True
    End Sub

    Private Sub optNo_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optNo.MouseClick
        Try
            Me.mtbNumCedula.Enabled = False
            Me.lblCedula.ForeColor = Color.Black
            Me.txtNombre1.Select()
            Me.optSMasculino.Enabled = True
            Me.optSMasculino.Select()
            Me.optSFemenino.Enabled = True
            Me.mtbNumCedula.Text = ""

            Me.txtNombre1.Enabled = True
            Me.txtNombre2.Enabled = True
            Me.txtApellido1.Enabled = True
            Me.txtApellido2.Enabled = True
            Me.txtNombre1.Select()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub optSi_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles optSi.MouseClick
        Try
            Me.mtbNumCedula.Enabled = True
            Me.mtbNumCedula.Select()
            Me.lblCedula.ForeColor = Color.Blue
            Me.optSMasculino.Enabled = False
            Me.optSMasculino.Select()
            Me.optSFemenino.Enabled = False

            Me.txtNombre1.Enabled = False
            Me.txtNombre2.Enabled = False
            Me.txtApellido1.Enabled = False
            Me.txtApellido2.Enabled = False

            Me.txtNombre1.Text = ""
            Me.txtNombre2.Text = ""
            Me.txtApellido1.Text = ""
            Me.txtApellido2.Text = ""
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class