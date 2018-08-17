Public Class FrmSsgEditModulo
    'Declaracion de Variables
    Dim ObjModuloDr As BOSistema.Win.SsgEntSeguridad.SsgModuloRow
    Dim ObjModuloDt As BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable

    Dim ModoForm As String
    Dim IdModulol As Long
    Dim IdAplicacionl As Long
    Dim vbModifico As Boolean
    Dim mNombreModulo As String
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
    'Parámetro del formulario el Id de la Aplicación
    'para la que se requiere agregar el Módulo
    '-------------------------------------------------
    Public Property IdAplicacion() As Long
        Get
            IdAplicacion = IdAplicacionl
        End Get
        Set(ByVal value As Long)
            IdAplicacionl = value
        End Set
    End Property
    '-------------------------------------------------
    'Parámetro del formulario el Id del registro
    'que se está editando en caso que estemos en modo
    'edición.
    '-------------------------------------------------
    Public Property IdModulo() As Long
        Get
            IdModulo = IdModulol
        End Get
        Set(ByVal value As Long)
            IdModulol = value
        End Set
    End Property
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
    'Parámetro del formulario 
    'que devuelve el text del nodo editado
    '-------------------------------------------------
    Public Property NombreModulo() As String
        Get
            Return mNombreModulo
        End Get
        Set(ByVal value As String)
            mNombreModulo = value
        End Set
    End Property

    Private Sub FrmSsgEditModulo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AccionUsuario <> AccionBoton.BotonNinguno Then
            'Liberando el espacio
            ObjModuloDr = Nothing
            ObjModuloDt = Nothing
        Else
            'Regresar la accion del Usuario al estado Inicial
            e.Cancel = True
            AccionUsuario = AccionBoton.BotonCancelar
        End If
    End Sub
    Private Sub FrmSsgEditModulo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Declaracion de Variables 
        Dim ObjGUI As GUI.ClsGUI

        Try

            ObjGUI = New GUI.ClsGUI

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Oro")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Inicializar las variables del formulario
            InicializaVariables()
            CargarDatosAplicacion()

            '-- Si el modo del formulario es Edición
            If ModoFrm = "UPD" Then
                CargarDatosModulo()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            'Poner el foco en el Codigo Interno
            txtCodInterno.Select()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    '-----------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripcion:                Inicializar las variables generales del formulario.
    '-----------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar módulo"
            Else
                Me.Text = "Modificar módulo"
                Me.txtCodInterno.Enabled = False
            End If
            ObjModuloDr = New BOSistema.Win.SsgEntSeguridad.SsgModuloRow
            ObjModuloDt = New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable

            'Inicializar el MaxLeng de los campos -------------------------
            Me.txtCodInterno.MaxLength = ObjModuloDt.GetColumnLenght("CodInterno")
            Me.txtNombre.MaxLength = ObjModuloDt.GetColumnLenght("Nombre")
            Me.txtDescripcion.MaxLength = ObjModuloDt.GetColumnLenght("Descripcion")
            '--------------------------------------------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '--------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripcion:                Cargar los datos del registro seleccionado.
    '--------------------------------------------------------------------------
    Private Sub CargarDatosModulo()
        Try
            ObjModuloDt.Filter = "SsgModuloID = " & IdModulo
            ObjModuloDt.Retrieve()
            If ObjModuloDt.Count = 0 Then
                Exit Sub
            End If
            ObjModuloDr = ObjModuloDt.Current

            '-- Inicializar los controles con los datos 
            '-- del registro de módulo seleccionado.
            Me.txtCodInterno.Text = ObjModuloDr.CodInterno
            Me.txtNombre.Text = ObjModuloDr.Nombre
            If Not ObjModuloDr.IsFieldNull("Descripcion") Then
                Me.txtDescripcion.Text = ObjModuloDr.Descripcion
            Else
                Me.txtDescripcion.Text = ""
            End If

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
                            SalvarModulo()
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
    '----------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    18 de Julio del 2006
    '-- Descripcion:                Agregar o editar un nuevo registro de módulo en la 
    '--                             Base de Datos.
    '----------------------------------------------------------------------------------
    Private Sub SalvarModulo()
        Try
            If ModoFrm = "ADD" Then
                ObjModuloDr = ObjModuloDt.NewRow
            End If
            ObjModuloDr.CodInterno = RTrim(LTrim(Me.txtCodInterno.Text))
            ObjModuloDr.Nombre = RTrim(LTrim(Me.txtNombre.Text))

            'Guardo el nombre del modulo editado o agregado
            mNombreModulo = Trim(Me.txtNombre.Text)

            If LTrim(RTrim(Me.txtDescripcion.Text)).Length = 0 Then
                ObjModuloDr.SetFieldNull("Descripcion")
            Else
                ObjModuloDr.Descripcion = LTrim(RTrim(Me.txtDescripcion.Text))
            End If
            ObjModuloDr.objAplicacionID = IdAplicacion

            If ModoFrm = "ADD" Then
                ObjModuloDr.UsuarioCreacion = InfoSistema.LoginName
                ObjModuloDr.FechaCreacion = FechaServer()
            Else
                ObjModuloDr.UsuarioModificacion = InfoSistema.LoginName
                ObjModuloDr.FechaModificacion = FechaServer()
            End If
            ObjModuloDr.Update()

            If ModoFrm = "ADD" Then
                MsgBox("Se agregó una nueva aplicación de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Se actualizaron los datos de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            End If
            IdModulo = ObjModuloDr.SsgModuloID
            AccionUsuario = AccionBoton.BotonAceptar


            'Liberando la memoria ----------------
            ObjModuloDr = Nothing
            ObjModuloDt = Nothing
            '-------------------------------------
            'Cerrar el formulario
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If FncValidaParametros() Then
                SalvarModulo()
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
    '--                             2. El Nombre del modulo requerido.
    '--                             3. El nombre de modulo no puede duplicarse dentro de una misma aplicacion
    '--------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean
        Dim ObjModulol As BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable
        Try
            '-- Declaración de Variables 
            Dim VbResultado As Boolean

            'Limpio el errorprovider
            Me.ErrorProvider1.Clear()

            ObjModulol = New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable
            VbResultado = False

            '0. Si el modo del formulario es Edicion y no hay ID 
            If ModoFrm = "UPD" Then
                If IdModulo <= 0 Then
                    MsgBox("No se encontró un registro de módulo válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.grpDatosAplicacion, "No se encontró un registro de módulo válido.")
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
                ObjModulol.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = '" & UCase(LTrim(RTrim(Me.txtCodInterno.Text))) & "'"
            Else
                ObjModulol.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = '" & UCase(LTrim(RTrim(Me.txtCodInterno.Text))) & "' And SsgModuloID <> " & IdModulo
            End If
            ObjModulol.Retrieve()
            If ObjModulol.Count > 0 Then
                MsgBox("Ya se encuentra definida un módulo" & Chr(10) & _
                       "con el código interno " & Me.txtCodInterno.Text & ".", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodInterno, "Ya se encuentra definida un módulo con el código interno " & Me.txtCodInterno.Text & ".")
                Me.txtCodInterno.Focus()
                GoTo SALIR
            End If

            '4. No pueden existir 2 módulos con el mismo nombre dentro de la misma Aplicación
            If ModoFrm = "ADD" Then
                ObjModulol.Filter = "Upper(Rtrim(Ltrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "' And ObjAplicacionID = " & IdAplicacion
            Else
                ObjModulol.Filter = "Upper(rtrim(ltrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "' And SsgModuloID <> " & IdModulo & " And ObjAplicacionID = " & IdAplicacion
            End If
            ObjModulol.Retrieve()
            If ObjModulol.Count > 0 Then
                MsgBox("Ya se encuentra registrada un módulo con el " & Chr(10) & _
                       "nombre: " & Me.txtNombre.Text & " para este subsistema.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtNombre, "Ya se encuentra registrada un módulo con el nombre: " & Me.txtNombre.Text & " para este subsistema.")
                Me.txtNombre.Focus()
                GoTo SALIR
            End If

            VbResultado = True
SALIR:
            Return VbResultado

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjModulol = Nothing
        End Try
    End Function
    '-------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        20 de Julio del 2006
    '-- Descripcion:                    Cargar los datos de la Aplicación.
    '-------------------------------------------------------------------------
    Private Sub CargarDatosAplicacion()
        Try
            Dim ObjSegAplicacion As BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
            ObjSegAplicacion = New BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable

            ObjSegAplicacion.Filter = "SsgAplicacionID = " & IdAplicacion
            ObjSegAplicacion.Retrieve()
            If ObjSegAplicacion.Count > 0 Then
                Me.txtCodInternoA.Text = ObjSegAplicacion("CodInterno")
                Me.txtNombreA.Text = ObjSegAplicacion("Nombre")
            End If

            ObjSegAplicacion = Nothing

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