Public Class FrmSsgEditAplicacion

    'Declaracion de Variables
    Dim ObjAplicaciondt As BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
    Dim ObjAplicaciondr As BOSistema.Win.SsgEntSeguridad.SsgAplicacionRow

    Dim ModoForm As String
    Dim IdAplicacionl As Long
    Dim vbModifico As Boolean
    Dim mNombreAplicacion As String
    '------------------------------------------
    'Permite manejar los diferentes estados 
    'que puede tener un formulario según sus 
    'acciones: Acepto o Cancelo.
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum
    Public AccionUsuario As AccionBoton
    '-------------------------------------------
    'Parámetro del formulario el Id del registro
    'que se está editando en caso que estemos en modo
    'edición.
    '-------------------------------------------
    Public Property IdAplicacion() As Long
        Get
            IdAplicacion = IdAplicacionl
        End Get
        Set(ByVal value As Long)
            IdAplicacionl = value
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

    Public Property NombreAplicacion() As String
        Get
            Return mNombreAplicacion
        End Get
        Set(ByVal value As String)
            mNombreAplicacion = value
        End Set
    End Property
    Private Sub FrmSsgEditAplicacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                'Liberando el espacio
                ObjAplicaciondt = Nothing
                ObjAplicaciondr = Nothing
            Else
                'Regresar la accion del Usuario al estado Inicial
                e.Cancel = True
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FrmSsgEditAplicacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            '-- Si el modo del formulario es Edición
            If ModoFrm = "UPD" Then
                CargarDatosAplicacion()
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
    '--------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    17 de Julio del 2006
    '-- Descripcion:                Inicializa las variables globales del formulario.
    '---------------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar aplicación"
            Else
                Me.Text = "Modificar aplicación"
                Me.txtCodInterno.Enabled = False
            End If
            ObjAplicaciondt = New BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
            ObjAplicaciondr = New BOSistema.Win.SsgEntSeguridad.SsgAplicacionRow

            'Definir el tamaño máximo permitido
            'por las columnas de Tipo Texto --------
            Me.txtCodInterno.MaxLength = ObjAplicaciondt.GetColumnLenght("CodInterno")
            Me.txtNombre.MaxLength = ObjAplicaciondt.GetColumnLenght("Nombre")
            Me.txtDescripcion.MaxLength = ObjAplicaciondt.GetColumnLenght("Descripcion")
            '---------------------------------------

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
                        If fncValidaParametros() Then
                            SalvarAplicacion()
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
            If fncValidaParametros() Then
                SalvarAplicacion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    17 de Julio del 2006
    '-- Descripcion:                Salvar aplicación los datos cambiados en la Base de Datos
    '--                             si el modo del formulario es Nuevo se instancia el DataRow como nuevo.
    '----------------------------------------------------------------------------------
    Private Sub SalvarAplicacion()
        Try
            If ModoFrm = "ADD" Then
                ObjAplicaciondr = ObjAplicaciondt.NewRow
            End If
            ObjAplicaciondr.CodInterno = RTrim(LTrim(Me.txtCodInterno.Text))
            ObjAplicaciondr.Nombre = RTrim(LTrim(Me.txtNombre.Text))
            mNombreAplicacion = Trim(Me.txtNombre.Text)
            If LTrim(RTrim(Me.txtDescripcion.Text)).Length = 0 Then
                ObjAplicaciondr.SetFieldNull("Descripcion")
            Else
                ObjAplicaciondr.Descripcion = LTrim(RTrim(Me.txtDescripcion.Text))
            End If

            If ModoFrm = "ADD" Then
                ObjAplicaciondr.UsuarioCreacion = InfoSistema.LoginName
                ObjAplicaciondr.FechaCreacion = FechaServer()
            Else
                ObjAplicaciondr.UsuarioModificacion = InfoSistema.LoginName
                ObjAplicaciondr.FechaModificacion = FechaServer()
            End If

            ObjAplicaciondr.Update()

            If ModoFrm = "ADD" Then
                MsgBox("Se agregó una nueva aplicación de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Se actualizaron los datos de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            End If
            IdAplicacion = ObjAplicaciondr.SsgAplicacionID
            AccionUsuario = AccionBoton.BotonAceptar

            'Liberando la memoria ----------------
            ObjAplicaciondr = Nothing
            ObjAplicaciondt = Nothing
            '-------------------------------------
            'Cerrar el formulario
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '---------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    17 de Julio del 2006
    '-- Descripcion:                Validar los parametros de entrada del formulario:
    '--                             1. El codigo interno es un valor requerido.
    '--                             2. El Nombre es un valor requerido   
    '--                             3. No pueden existir 2 aplicaciones con el mismo CodInterno
    '--                             4. No pueden existir 2 aplicaciones con el mismo Nombre
    '--------------------------------------------------------------------------------
    Private Function fncValidaParametros() As Boolean
        Dim ObjAplicacionl As BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
        Try
            '-- Declaración de Variables 
            Dim VbResultado As Boolean

            ObjAplicacionl = New BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
            VbResultado = False

            'Limpio el errorprovider
            Me.ErrorProvider1.Clear()

            '0. Si el modo del formulario es Edicion y no hay ID 
            If ModoFrm = "UPD" Then
                If IdAplicacion <= 0 Then
                    MsgBox("No se encontró un registro de aplicación válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.grpDatosAplicacion, "No se encontró un registro de aplicación válido.")
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

            '3. No pueden existir 2 aplicaciones con el mismo CodInterno
            If ModoFrm = "ADD" Then
                ObjAplicacionl.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = '" & UCase(Trim(Me.txtCodInterno.Text)) & "'"
            Else
                ObjAplicacionl.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = '" & UCase(Trim(Me.txtCodInterno.Text)) & "' And SsgAplicacionID <> " & IdAplicacion
            End If
            ObjAplicacionl.Retrieve()
            If ObjAplicacionl.Count > 0 Then
                MsgBox("Ya se encuentra definida una aplicación" & Chr(10) & _
                       "con el código interno " & Me.txtCodInterno.Text & ".", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodInterno, "Ya se encuentra definida una aplicación con el código interno " & Me.txtCodInterno.Text & ".")
                Me.txtCodInterno.Focus()
                GoTo SALIR
            End If

            '4. No pueden existir 2 aplicaciones con el mismo nombre
            If ModoFrm = "ADD" Then
                ObjAplicacionl.Filter = "Upper(Rtrim(Ltrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "'"
            Else
                ObjAplicacionl.Filter = "Upper(rtrim(ltrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "' And SsgAplicacionID <> " & IdAplicacion
            End If
            ObjAplicacionl.Retrieve()
            If ObjAplicacionl.Count > 0 Then
                MsgBox("Ya se encuentra registrada una aplicación " & Chr(10) & _
                       "con el nombre: " & Me.txtNombre.Text & ".", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtNombre, "Ya se encuentra registrada una aplicación con el nombre: " & Me.txtNombre.Text & ".")
                Me.txtNombre.Focus()
                GoTo SALIR
            End If
            VbResultado = True
SALIR:
            Return VbResultado


        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjAplicacionl = Nothing
        End Try
    End Function
    '-----------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    17 de Julio del 2006
    '-- Descripcion:                Cargar los datos del Id de Aplicacion seleccionado.
    '-----------------------------------------------------------------------
    Private Sub CargarDatosAplicacion()
        Try
            ObjAplicaciondt.Filter = "SsgAplicacionID = " & IdAplicacion
            ObjAplicaciondt.Retrieve()
            If ObjAplicaciondt.Count = 0 Then
                Exit Sub
            End If
            ObjAplicaciondr = ObjAplicaciondt.Current

            '-- Inicializar los controles con los datos 
            '-- del registro de aplicación.
            Me.txtCodInterno.Text = ObjAplicaciondr.CodInterno
            Me.txtNombre.Text = ObjAplicaciondr.Nombre
            If Not ObjAplicaciondr.IsFieldNull("Descripcion") Then
                Me.txtDescripcion.Text = ObjAplicaciondr.Descripcion
            Else
                Me.txtDescripcion.Text = ""
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