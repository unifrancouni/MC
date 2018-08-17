
Public Class FrmSsgEditAccion
    'Declaracion de Variables
    Dim ObjAccionDr As BOSistema.Win.SsgEntSeguridad.SsgAccionRow
    Dim ObjAccionDt As BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable

    Dim ModoForm As String
    Dim IdAccionl As Long
    Dim IdServUsuariol As Long
    Dim vbModifico As Boolean
    Dim mNombreAcccion As String
    '------------------------------------------
    'Permite manejar los diferentes estados 
    'que puede tener un formulario seg�n sus 
    'acciones: Acepto o Cancelo.
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum
    Public AccionUsuario As AccionBoton
    '-------------------------------------------
    'Par�metro del formulario el Id del Servicio de Usuario
    'para el que se registrar�n las acciones.
    '-------------------------------------------
    Public Property IdServUsuario() As Long
        Get
            IdServUsuario = IdServUsuariol
        End Get
        Set(ByVal value As Long)
            IdServUsuariol = value
        End Set
    End Property
    '-------------------------------------------------
    'Par�metro del formulario el Id del registro
    'que se est� editando en caso que estemos en modo
    'edici�n.
    '-------------------------------------------------
    Public Property IdAccion() As Long
        Get
            IdAccion = IdAccionl
        End Get
        Set(ByVal value As Long)
            IdAccionl = value
        End Set
    End Property
    '-------------------------------------------------
    'Par�metro del formulario Editando Aplicaci�n
    'para determinar si est� en modo Nuevo o Edicion.
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
    'Par�metro del formulario Editando Aplicaci�n
    'para obtener el nombre de la accion editada o agregada.
    '-------------------------------------------------
    Public Property NombreAccion() As String
        Get
            Return mNombreAcccion
        End Get
        Set(ByVal value As String)
            mNombreAcccion = value
        End Set
    End Property
    Private Sub FrmSsgEditAccion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                'Liberando el espacio
                ObjAccionDr = Nothing
                ObjAccionDt = Nothing
            Else

                'Regresar la accion del Usuario al estado Inicial
                e.Cancel = True
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FrmSsgEditAccion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            CargarDatosServUsuario()

            '-- Si el modo del formulario es Edici�n
            If ModoFrm = "UPD" Then
                CargarDatosAccion()
            End If
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            'Poner el foco en el codigo interno
            Me.txtCodInterno.Select()

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjGUI = Nothing

        End Try
    End Sub
    '----------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    20 de Julio del 2006
    '-- Descripcion:                Inicializar las variables generales del formulario
    '--                             de registro de acciones.
    '----------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            '-- Instanciar las clases de Accion
            ObjAccionDt = New BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable
            ObjAccionDr = New BOSistema.Win.SsgEntSeguridad.SsgAccionRow

            '-- Limpiar campos
            Me.txtCodInterno.Text = ""
            Me.txtCodInternoS.Text = ""
            Me.txtNombre.Text = ""
            Me.txtNombreS.Text = ""
            Me.txtDescripcion.Text = ""

            'Definir la longitud m�xima 
            'de los campos -------------
            Me.txtCodInterno.MaxLength = ObjAccionDt.GetColumnLenght("CodInterno")
            Me.txtNombre.MaxLength = ObjAccionDt.GetColumnLenght("Nombre")
            Me.txtDescripcion.MaxLength = ObjAccionDt.GetColumnLenght("Descripcion")
            '---------------------------
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Acci�n"
            Else
                Me.Text = "Modificar Acci�n"
            End If



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    20 de Julio del 2006
    '-- Descripcion:                Cargar los datos del Servicio de Usuario seleccionado.
    '----------------------------------------------------------------------------
    Private Sub CargarDatosServUsuario()
        Dim ObjServUsuario As BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable

        Try

            ObjServUsuario = New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable

            ObjServUsuario.Filter = "SsgServicioUsuarioID = " & IdServUsuario
            ObjServUsuario.Retrieve()
            If ObjServUsuario.Count > 0 Then
                Me.txtCodInternoS.Text = ObjServUsuario.Itemn(0).CodInterno
                Me.txtNombreS.Text = ObjServUsuario.Itemn(0).Nombre
            End If
            ObjServUsuario = Nothing

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjServUsuario = Nothing
        End Try
    End Sub
    '----------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    20 de Julio del 2006
    '-- Descripcion:                Cargar los datos de la Acci�n seleccionada.
    '----------------------------------------------------------------------------
    Private Sub CargarDatosAccion()
        Try
            'Buscar el registro correspondiente 
            'a la accion seleccionada.
            ObjAccionDt.Filter = "SsgAccionID = " & IdAccion
            ObjAccionDt.Retrieve()
            If ObjAccionDt.Count = 0 Then
                Exit Sub
            End If
            ObjAccionDr = ObjAccionDt.Current

            'Cargar los datos de la Acci�n en el formulario
            Me.txtCodInterno.Text = ObjAccionDr.CodInterno
            Me.txtNombre.Text = ObjAccionDr.Nombre
            If ObjAccionDr.IsFieldNull("Descripcion") Then
                Me.txtDescripcion.Text = ""
            Else
                Me.txtDescripcion.Text = ObjAccionDr.Descripcion
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    20 de Julio del 2006
    '-- Descripcion:                Salvar los datos registrados de la accion
    '--                             en la Base de Datos.
    '----------------------------------------------------------------------------
    Private Sub SalvarAccion()
        Dim xSave As New BOSistema.Win.XComando
        Try
            If ModoFrm = "ADD" Then
                ObjAccionDr = ObjAccionDt.NewRow
            End If
            ObjAccionDr.CodInterno = RTrim(LTrim(Me.txtCodInterno.Text))
            ObjAccionDr.Nombre = RTrim(LTrim(Me.txtNombre.Text))
            mNombreAcccion = Trim(Me.txtNombre.Text)

            If LTrim(RTrim(Me.txtDescripcion.Text)).Length = 0 Then
                ObjAccionDr.SetFieldNull("Descripcion")
            Else
                ObjAccionDr.Descripcion = LTrim(RTrim(Me.txtDescripcion.Text))
            End If
            ObjAccionDr.objServicioUsuarioID = IdServUsuario

            If ModoFrm = "ADD" Then
                ObjAccionDr.UsuarioCreacion = InfoSistema.LoginName
                ObjAccionDr.FechaCreacion = FechaServer()
            Else
                ObjAccionDr.UsuarioModificacion = InfoSistema.LoginName
                ObjAccionDr.FechaModificacion = FechaServer()
            End If

            ObjAccionDr.Update()

            If ModoFrm = "ADD" Then
                ''Agregar un rol especial
                xSave = New BOSistema.Win.XComando
                Dim strsql As String
                strsql = String.Format(" exec spSsgAgregarRol {0},'{1}','{2}','{3}' ", ObjAccionDr.SsgAccionID, ObjAccionDr.CodInterno, ObjAccionDr.Nombre, ObjAccionDr.UsuarioCreacion)
                xSave.ExecuteNonQuery(strsql)
            End If

            If ModoFrm = "ADD" Then
                MsgBox("Se agreg� una nueva Acci�n de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Se actualizaron los datos de la acci�n de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            End If
            IdAccion = ObjAccionDr.SsgAccionID
            AccionUsuario = AccionBoton.BotonAceptar

            'Liberando la memoria ----------------
            ObjAccionDr = Nothing
            ObjAccionDt = Nothing
            '-------------------------------------
            'Cerrar el formulario
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            xSave.Close()
            xSave = Nothing
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
                            SalvarAccion()
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
                SalvarAccion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------
    '-- Implementado Por:              
    '-- Fecha de Implementacion:        20 de Julio del 2006
    '-- Descripcion:                    Validar los parametros de entrada del registro
    '--                                 de acciones:
    '--                                 1. El codigo interno es un valor requerido.
    '--                                 2. El nombre es un valor requerido.
    '--                                 3. El codigo interno no puede repetirse dentro de la aplicaci�n.
    '--                                 4. El nombre de la acci�n no puede repetirse dentro de la aplicaci�n.
    '----------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean
        Dim ObjAccion As BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable

        Try

            'Declaraci�n de Variables ------------------
            Dim VbResultado As Boolean

            '-------------------------------------------
            VbResultado = False
            'Limpio el error provider
            Me.ErrorProvider1.Clear()

            ObjAccion = New BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable

            'El Codigo Interno es un valor requerido
            If LTrim(RTrim(Me.txtCodInterno.Text)).Length = 0 Then
                MsgBox("Debe especificar un valor v�lido " & Chr(10) & _
                       "para el c�digo Interno.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodInterno, "Debe especificar un valor v�lido para el c�digo Interno.")
                Me.txtCodInterno.Focus()
                GoTo SALIR
            End If

            'El nombre de la Accion es un valor requerido
            If LTrim(RTrim(Me.txtNombre.Text)).Length = 0 Then
                MsgBox("Debe especificar un valor v�lido " & Chr(10) & _
                        "para el Nombre de la Acci�n.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtNombre, "Debe especificar un valor v�lido para el Nombre de la Acci�n.")
                Me.txtNombre.Focus()
                GoTo SALIR
            End If

            'El codigo interno no debe repetirse 
            'dentro de la Aplicaci�n -----------
            If ModoFrm = "ADD" Then
                ObjAccion.Filter = "UPPER(Ltrim(Rtrim(CodInterno))) = '" & UCase(LTrim(RTrim(Me.txtCodInterno.Text))) & "'"
            Else
                ObjAccion.Filter = "UPPER(Ltrim(Rtrim(CodInterno))) = '" & UCase(LTrim(RTrim(Me.txtCodInterno.Text))) & "' And SsgAccionID <> " & IdAccion
            End If
            ObjAccion.Retrieve()
            If ObjAccion.Count > 0 Then
                MsgBox("Ya se defini� una Acci�n con el c�digo Interno: " & Me.txtCodInterno.Text, MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtCodInterno, "Ya se defini� una Acci�n con el c�digo Interno: " & Me.txtCodInterno.Text)
                Me.txtCodInterno.Focus()
                GoTo SALIR
            End If

            'El Nombre del Rol debe ser �nico dentro de la Aplicaci�n
            If ModoFrm = "ADD" Then
                ObjAccion.Filter = "UPPER(Ltrim(Rtrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "'"
            Else
                ObjAccion.Filter = "UPPER(Ltrim(Rtrim(Nombre))) = '" & UCase(LTrim(RTrim(Me.txtNombre.Text))) & "' And SsgAccionID <> " & IdAccion
            End If
            ObjAccion.Retrieve()
            If ObjAccion.Count > 0 Then
                MsgBox("Ya se defini� una Acci�n con este nombre: " & Me.txtNombre.Text, MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtNombre, "Ya se defini� una Acci�n con este nombre: " & Me.txtNombre.Text)
                Me.txtNombre.Focus()
                GoTo SALIR
            End If
            VbResultado = True
SALIR:

            Return VbResultado

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjAccion = Nothing
        End Try
    End Function
    Private Sub txtCodInterno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodInterno.KeyPress
        If e.KeyChar = " " Or e.KeyChar = "'" Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
        vbModifico = True
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