Public Class FrmSsgEditServUsuarios

    'Declaracion de Variables -------------------------
    Dim ObjServUsuarioDr As BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioRow
    Dim ObjServUsuarioDt As BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable
    '--------------------------------------------------
    Dim ModoForm As String
    Dim IdServiciol As Long
    Dim IdModulol As Long
    Dim vbModifico As Boolean
    Dim mNombreServicio As String
    '-------------------------------------------------
    'Permite manejar los diferentes estados 
    'que puede tener un formulario según sus 
    'acciones: Acepto o Cancelo.
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum
    Public AccionUsuario As AccionBoton
    '-------------------------------------------------
    'Parámetro del formulario Editando Aplicación
    'para determinar si está en modo Nuevo o Edicion.
    '-------------------------------------------------
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    '-------------------------------------------------
    'Parámetro del formulario para recibir el Id 
    'de Servicio seleccionado.
    '-------------------------------------------------
    Public Property IdServicio() As Long
        Get
            IdServicio = IdServiciol
        End Get
        Set(ByVal value As Long)
            IdServiciol = value
        End Set
    End Property
    '-----------------------------------------------
    'Parámetro del formulario para recibir el Id 
    'del Modulo seleccionado.
    '-----------------------------------------------
    Public Property IdModulo() As Long
        Get
            IdModulo = IdModulol
        End Get
        Set(ByVal value As Long)
            IdModulol = value
        End Set
    End Property

    Public Property NombreServicio() As String
        Get
            Return mNombreServicio
        End Get
        Set(ByVal value As String)
            mNombreServicio = value
        End Set
    End Property

    Private Sub FrmSsgEditServUsuarios_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AccionUsuario <> AccionBoton.BotonNinguno Then
            'Liberando el espacio
            ObjServUsuarioDr = Nothing
            ObjServUsuarioDt = Nothing
        Else
            'Regresar la accion del Usuario al estado Inicial
            e.Cancel = True
            AccionUsuario = AccionBoton.BotonCancelar
        End If
    End Sub

    Private Sub FrmSsgEditServUsuarios_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Declaración de Variables 
        Dim ObjGUI As GUI.ClsGUI

        Try

            ObjGUI = New GUI.ClsGUI

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Oro")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Inicializar las variables del formulario
            InicializaVariables()
            CargarDatosModulo()

            '-- Si el modo del formulario es Edición
            If ModoFrm = "UPD" Then
                CargarDatosServicioUsuario()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            'Poner el foco en el primer campo editable
            txtCodInterno.Select()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub InicializaVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Servicio de Usuario"
            Else
                Me.Text = "Modificar Servicio de Usuario"
                Me.txtCodInterno.Enabled = False
            End If
            ObjServUsuarioDr = New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioRow
            ObjServUsuarioDt = New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable

            'Inicializar el maxlenght de los campos -------------------------
            Me.txtCodInterno.MaxLength = ObjServUsuarioDt.GetColumnLenght("CodInterno")
            Me.txtNombre.MaxLength = ObjServUsuarioDt.GetColumnLenght("Nombre")
            Me.txtDescripcion.MaxLength = ObjServUsuarioDt.GetColumnLenght("Descripcion")
            '----------------------------------------------------------------


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripcion:                Cargar los datos del servicio de Usuario seleccionado.
    '------------------------------------------------------------------------------------
    Private Sub CargarDatosServicioUsuario()
        Try

            ObjServUsuarioDt.Filter = "SsgServicioUsuarioID = " & IdServicio
            ObjServUsuarioDt.Retrieve()
            If ObjServUsuarioDt.Count = 0 Then
                Exit Sub
            End If
            ObjServUsuarioDr = ObjServUsuarioDt.Current

            '-- Inicializar los controles con los datos 
            '-- del registro de módulo seleccionado.
            Me.txtCodInterno.Text = ObjServUsuarioDr.CodInterno
            Me.txtNombre.Text = ObjServUsuarioDr.Nombre
            If Not ObjServUsuarioDr.IsFieldNull("Descripcion") Then
                Me.txtDescripcion.Text = ObjServUsuarioDr.Descripcion
            Else
                Me.txtDescripcion.Text = ""
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    18 de Julio del 2006
    '-- Descripcion:                Salvar los datos de servicio de Usuario en la Base de Datos.
    '--                             Si el modo del formulario es Nuevo se instancia el DataRow como nuevo.
    '----------------------------------------------------------------------------------
    Private Sub SalvarServicioUsuario()
        Try
            If ModoFrm = "ADD" Then
                ObjServUsuarioDr = ObjServUsuarioDt.NewRow
            End If

            ObjServUsuarioDr.CodInterno = RTrim(LTrim(Me.txtCodInterno.Text))
            ObjServUsuarioDr.Nombre = RTrim(LTrim(Me.txtNombre.Text))
            mNombreServicio = Trim(Me.txtNombre.Text)

            If LTrim(RTrim(Me.txtDescripcion.Text)).Length = 0 Then
                ObjServUsuarioDr.SetFieldNull("Descripcion")
            Else
                ObjServUsuarioDr.Descripcion = LTrim(RTrim(Me.txtDescripcion.Text))
            End If
            ObjServUsuarioDr.objModuloID = IdModulo

            If ModoFrm = "ADD" Then
                ObjServUsuarioDr.UsuarioCreacion = InfoSistema.LoginName
                ObjServUsuarioDr.FechaCreacion = FechaServer()
            Else
                ObjServUsuarioDr.UsuarioModificacion = InfoSistema.LoginName
                ObjServUsuarioDr.FechaModificacion = FechaServer()
            End If
            ObjServUsuarioDr.Update()

            If ModoFrm = "ADD" Then
                MsgBox("Se agregó un nuevo registro de Servicio de Usuario de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Se actualizaron los datos del Servicio de Usuario de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            End If
            vbModifico = False
            AccionUsuario = AccionBoton.BotonAceptar

            'Liberando la memoria ----------------
            ObjServUsuarioDr = Nothing
            ObjServUsuarioDt = Nothing
            '-------------------------------------
            'Cerrar el formulario
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        If FncValidaParametros() Then
                            SalvarServicioUsuario()
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
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If FncValidaParametros() Then
                SalvarServicioUsuario()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '---------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    18 de Julio del 2006
    '-- Descripcion:                Validar los parametros de entrada del formulario:
    '--                             1. El codigo interno es un valor requerido.
    '--                             2. El codigo Interno debe ser unico.
    '--                             2. El Nombre del Servicio de Usuario es requerido.
    '--                             3. El nombre del Servicio de Usuario no puede repetirse dentro del modulo.
    '--------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean

        'Declaracion de Variables 
        Dim ObjServUsuariol As BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable

        Try
            '-- Declaración de Variables 
            Dim VbResultado As Boolean

            'Limpio el errorprovider
            Me.ErrorProvider1.Clear()

            ObjServUsuariol = New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable
            VbResultado = False

            '0. Si el modo del formulario es Edicion y no hay ID 
            If ModoFrm = "UPD" Then
                If IdServicio <= 0 Then
                    MsgBox("No se encontró un registro de Servicio de Usuario válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.grpDatosAplicacion, "No se encontró un registro de Servicio de Usuario válido.")
                    Me.grpDatosAplicacion.Focus()
                    GoTo SALIR
                End If
            End If

            '1. El código interno es un valor requerido
            If RTrim(LTrim(Me.txtCodInterno.Text)).Length = 0 Then
                MsgBox("Debe ingresar un valor válido para el Código Interno.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodInterno, "Debe ingresar un valor válido para el Código Interno.")
                Me.txtCodInterno.Focus()
                GoTo SALIR
            End If

            '2. El Nombre es un valor requerido
            If RTrim(LTrim(Me.txtNombre.Text)).Length = 0 Then
                MsgBox("Debe ingresar un valor válido para el Nombre.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtNombre, "Debe ingresar un valor válido para el Nombre.")
                Me.txtNombre.Focus()
                GoTo SALIR
            End If

            '3. No pueden existir 2 modulos con el mismo CodInterno
            If ModoFrm = "ADD" Then
                ObjServUsuariol.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = '" & UCase(LTrim(RTrim(Me.txtCodInterno.Text))) & "'"
            Else
                ObjServUsuariol.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = '" & UCase(LTrim(RTrim(Me.txtCodInterno.Text))) & "' And SsgServicioUsuarioID <> " & IdServicio
            End If
            ObjServUsuariol.Retrieve()
            If ObjServUsuariol.Count > 0 Then
                MsgBox("Ya se encuentra definido un Servicio" & Chr(10) & _
                       "de Usuario con el código interno " & Me.txtCodInterno.Text & ".", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodInterno, "Ya se encuentra definido un Servicio de Usuario con el código interno " & Me.txtCodInterno.Text & ".")
                Me.txtCodInterno.Focus()
                GoTo SALIR
            End If

            '4. No pueden existir 2 Servicios de Usuarios con el mismo 
            '   nombre dentro del mismo módulo.
            If ModoFrm = "ADD" Then
                ObjServUsuariol.Filter = "Upper(Rtrim(Ltrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "' And ObjModuloID = " & IdModulo
            Else
                ObjServUsuariol.Filter = "Upper(rtrim(ltrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "' And SsgServicioUsuarioID <> " & IdServicio & " And ObjModuloID = " & IdModulo
            End If
            ObjServUsuariol.Retrieve()
            If ObjServUsuariol.Count > 0 Then
                MsgBox("Ya se encuentra registrada un Servicio de Usuario con el " & Chr(10) & _
                       "nombre: " & Me.txtNombre.Text & " para este módulo.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtNombre, "Ya se encuentra registrada un Servicio de Usuario con el nombre: " & Me.txtNombre.Text & " para este módulo.")
                Me.txtNombre.Focus()
                GoTo SALIR
            End If

            VbResultado = True
SALIR:
            Return VbResultado

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjServUsuariol = Nothing
        End Try
    End Function
    '-----------------------------------------------------------------------------------
    '-- Implementado Por:            
    '-- Fecha de Implementacion:     20 de JUlio del 2006
    '-- Descripcion:                 Cargar los datos del Módulo para el que se creará el 
    '--                              servicio de Usuario.
    '-----------------------------------------------------------------------------------
    Public Sub CargarDatosModulo()
        Try
            Dim ObjModulo As BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable
            ObjModulo = New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable

            ObjModulo.Filter = "SsgModuloID = " & IdModulo
            ObjModulo.Retrieve()
            If ObjModulo.Count > 0 Then
                Me.txtCodInternoM.Text = ObjModulo("CodInterno")
                Me.txtNombreM.Text = ObjModulo("Nombre")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub txtCodInterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodInterno.KeyPress
        If e.KeyChar = " " Or e.KeyChar = "'" Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
    Private Sub txtCodInterno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodInterno.TextChanged
        vbModifico = True
    End Sub
    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        vbModifico = True
    End Sub
    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        vbModifico = True
    End Sub
End Class