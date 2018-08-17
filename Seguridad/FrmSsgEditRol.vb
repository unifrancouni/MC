Public Class FrmSsgEditRol
    'Declaracion de Variables
    Dim ObjRolDr As BOSistema.Win.SsgEntSeguridad.SsgRolRow
    Dim ObjRolDt As BOSistema.Win.SsgEntSeguridad.SsgRolDataTable
    Dim XdsAcciones As BOSistema.Win.XDataSet.xDataTable

    Dim ModoForm As String
    Dim IdRoll As Long
    Dim IdAplicacionl As Long
    Dim vbModifico As Boolean
    Dim mNombreRol As String
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
    Public Property IdRol() As Long
        Get
            IdRol = IdRoll
        End Get
        Set(ByVal value As Long)
            IdRoll = value
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

    Public Property NombreRol() As String
        Get
            Return mNombreRol
        End Get
        Set(ByVal value As String)
            mNombreRol = value
        End Set
    End Property

    Private Sub FrmSsgEditRol_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If AccionUsuario <> AccionBoton.BotonNinguno Then
            'Liberando el espacio
            ObjRolDr = Nothing
            ObjRolDt = Nothing
            XdsAcciones = Nothing
        Else
            'Regresar la accion del Usuario al estado Inicial
            e.Cancel = True
            AccionUsuario = AccionBoton.BotonCancelar
        End If
    End Sub

    Private Sub FrmSsgEditRol_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            CargarAcciones()

            '-- Si el modo del formulario es Edición
            If ModoFrm = "UPD" Then
                CargarDatosRol()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            'Inicializar el foco en la primera pestaña y 
            'en el campo Nombre  -----------------------
            Me.tabRolAccion.SelectedIndex = 0
            Me.txtNombre.Select()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    '-----------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    20 de Julio del 2006
    '-- Descripcion:                Inicializar las variables generales del formulario.
    '-----------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Rol"
            Else
                Me.Text = "Modificar Rol"
            End If
            ObjRolDr = New BOSistema.Win.SsgEntSeguridad.SsgRolRow
            ObjRolDt = New BOSistema.Win.SsgEntSeguridad.SsgRolDataTable
            XdsAcciones = New BOSistema.Win.XDataSet.xDataTable("SsgAcciones")

            'Definir el MaxLenght de los campos tipo texto ------------
            Me.txtNombre.MaxLength = ObjRolDt.GetColumnLenght("Nombre")
            Me.txtDescripcion.MaxLength = ObjRolDt.GetColumnLenght("Descripcion")
            '----------------------------------------------------------
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
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
    '----------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        20 de Julio del 2006
    '-- Descripcion:                    Cargar los datos del Rol seleccionado.
    '--                                 En el caso que se esté editando un dato.
    '----------------------------------------------------------------------------
    Private Sub CargarDatosRol()
        Try
            ObjRolDt.Filter = "SsgRolID = " & IdRol
            ObjRolDt.Retrieve()
            If ObjRolDt.Count = 0 Then
                Exit Sub
            End If
            ObjRolDr = ObjRolDt.Current

            'Asignar los datos del Rol a los 
            'controles del formulario.
            Me.txtNombre.Text = ObjRolDr.Nombre
            If Not ObjRolDr.IsFieldNull("Descripcion") Then
                Me.txtDescripcion.Text = ObjRolDr.Descripcion
            Else
                Me.txtDescripcion.Text = ""
            End If
            '---------------------------------
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '-----------------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    20 de Julio del 2006
    '-- Descripcion:                Validar los parámetros de entrada que permitan registrar
    '--                             un Rol de forma satisfactoria.
    '--                             1. El Nombre del Rol no puede duplicarse dentro de la Aplicación.
    '--                             2. Debe asociar al menos una acción al Rol para poderlo registrar.
    '----------------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean
        Dim XdsAccionesClon As BOSistema.Win.XDataSet.xDataTable
        Dim ObjRoll As BOSistema.Win.SsgEntSeguridad.SsgRolDataTable

        Try
            'Declaración de Variables 
            Dim i As Long
            Dim vTieneAcciones As Boolean
            Dim Strsql As String
            Dim VbResultado As Boolean

            'Limpio el errorprovider
            Me.ErrorProvider1.Clear()

            '-----------------------------
            XdsAccionesClon = New BOSistema.Win.XDataSet.xDataTable
            ObjRoll = New BOSistema.Win.SsgEntSeguridad.SsgRolDataTable
            vTieneAcciones = False
            i = 0
            Strsql = ""
            VbResultado = False
            '-----------------------------
            If ModoFrm = "ADD" Then
                ObjRoll.Filter = "Ltrim(Rtrim(UPPER(Nombre))) = '" & UCase(Trim(Me.txtNombre.Text)) & "'"
            Else
                ObjRoll.Filter = "Ltrim(Rtrim(UPPER(Nombre))) = '" & UCase(Trim(Me.txtNombre.Text)) & "' And SsgRolID <> " & IdRol
            End If
            ObjRoll.Retrieve()
            If ObjRoll.Count > 0 Then
                MsgBox("El Nombre de Rol establecido ya existe.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtNombre, "El Nombre de Rol establecido ya existe.")
                Me.txtNombre.Focus()
                GoTo SALIR
            End If

            '-- Recorrer las acciones del Grid para determinar 
            '-- si existe al menos una chequeada.
            XdsAccionesClon = XdsAcciones
            For i = 0 To XdsAccionesClon.Count - 1
                If XdsAccionesClon.Table.Rows(i).Item("Selected") = True Then
                    vTieneAcciones = True
                    Exit For
                End If
            Next i
            If vTieneAcciones = False Then
                MsgBox("Debe asociar al menos una acción.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.grdAcciones, "Debe asociar al menos una acción.")
                Me.grdAcciones.Focus()
                GoTo SALIR
            End If

            VbResultado = True
SALIR:
            Return VbResultado
            Exit Function

        Catch ex As Exception
            Control_Error(ex)

        Finally
            XdsAccionesClon = Nothing
            ObjRoll = Nothing
        End Try
    End Function
    '-----------------------------------------------------------------------
    '-- Implementado Por:            
    '-- Fecha de Implementacion:     20 de Julio del 2006
    '-- Descripcion:                 Salvar los cambios realizados en el Rol que se 
    '--                              está agregando o editando.
    '-----------------------------------------------------------------------
    Private Sub SalvarRol()
        Try
            'Declaracion de Variables 
            Dim i As Integer
            Dim XdsAccionClon As BOSistema.Win.XDataSet.xDataTable
            Dim ObjAccionRolDt As BOSistema.Win.SsgEntSeguridad.SsgRolAccionDataTable
            Dim ObjAccionRolDr As BOSistema.Win.SsgEntSeguridad.SsgRolAccionRow
            '--------------------------------------------------
            XdsAccionClon = New BOSistema.Win.XDataSet.xDataTable
            ObjAccionRolDr = New BOSistema.Win.SsgEntSeguridad.SsgRolAccionRow
            ObjAccionRolDt = New BOSistema.Win.SsgEntSeguridad.SsgRolAccionDataTable

            If ModoFrm = "ADD" Then
                ObjRolDr = ObjRolDt.NewRow
                ObjRolDr.nRolEspecial = 0
            End If
            '-------------------------------------------------
            'Asignando a la clase los valores que se 
            'requieren salvar en la Base de Datos.
            ObjRolDr.Nombre = RTrim(LTrim(Me.txtNombre.Text))

            mNombreRol = Trim(Me.txtNombre.Text)

            If ModoFrm = "ADD" Then
                ObjRolDr.UsuarioCreacion = InfoSistema.LoginName
                ObjRolDr.FechaCreacion = FechaServer()
            Else
                ObjRolDr.UsuarioModificacion = InfoSistema.LoginName
                ObjRolDr.FechaModificacion = FechaServer()
            End If

            If LTrim(RTrim(Me.txtDescripcion.Text)).Length = 0 Then
                ObjRolDr.SetFieldNull("Descripcion")
            Else
                ObjRolDr.Descripcion = LTrim(RTrim(Me.txtDescripcion.Text))
            End If
            ObjRolDr.objAplicacionID = IdAplicacion
            ObjRolDr.Update()
            IdRol = ObjRolDr.SsgRolID
            If IdRol <= 0 Then
                MsgBox("Ha ocurrido un error mientras " & Chr(10) & _
                       "se registraba el Rol.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If
            '--------------------------------------------------
            'Asignar las acciones al Rol
            XdsAccionClon = XdsAcciones
            For i = 0 To XdsAccionClon.Count - 1

                '-- Buscar la Accion en AccionRol
                ObjAccionRolDt.Filter = "ObjAccionID = " & XdsAccionClon.Table.Rows(i).Item("SsgAccionID") & " And ObjRolID = " & IdRol
                ObjAccionRolDt.Retrieve()

                'Si no encontró la ACCION
                If ObjAccionRolDt.Count = 0 Then

                    'Si la ACCION está seleccionada AGREGARLA
                    If XdsAccionClon.Table.Rows(i).Item("Selected") = True Then

                        ObjAccionRolDr.NewRow()
                        ObjAccionRolDr.objAccionID = XdsAccionClon.Table.Rows(i).Item("SsgAccionID")
                        ObjAccionRolDr.objRolID = ObjRolDr.SsgRolID

                        ObjAccionRolDr.UsuarioCreacion = InfoSistema.LoginName
                        ObjAccionRolDr.FechaCreacion = FechaServer()

                        ObjAccionRolDr.SetFieldNull("UsuarioModificacion")
                        ObjAccionRolDr.SetFieldNull("FechaModificacion")
                        ObjAccionRolDr.Update()

                    End If
                Else
                    'Si la ACCION no está seleccionada pero ya existía, ELIMINARLA
                    If XdsAccionClon.Table.Rows(i).Item("Selected") = False Then
                        ObjAccionRolDt.DeleteAll()
                    End If
                End If
            Next i
            '-------------------------------------------------
            If ModoFrm = "ADD" Then
                MsgBox("Se agregó un Rol de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Se actualizaron los datos del Rol de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            End If
            IdRol = ObjRolDr.SsgRolID
            AccionUsuario = AccionBoton.BotonAceptar
            '-------------------------------------------------

            ObjRolDr = Nothing
            ObjRolDt = Nothing
            ObjAccionRolDr = Nothing
            ObjAccionRolDt = Nothing
            '-------------------------------------
            'Cerrar el formulario
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '--- Implementado Por:          
    '--- Fecha de Implementacion:   21 de Julio del 2006
    '--- Descripción:               Cargar la lista de Acciones asociadas a los servicios de 
    '---                            de Usuario de los Módulos de la Aplicación seleccionada.
    '------------------------------------------------------------------------------------
    Private Sub CargarAcciones()
        Try
            'Declaración de Variables 
            Dim Strsql As String
            '------------------------------------
            Strsql = ""
            If ModoFrm = "ADD" Then
                Strsql = " Select CAST(0 as bit) as Selected, " & _
                         "        SsgModuloID," & _
                         "        NombreModulo, " & _
                         "        objAplicacionID, " & _
                         "        SsgServicioUsuarioID," & _
                         "        NombreServicio,  " & _
                         "        SsgAccionID, " & _
                         "        NombreAccion,  " & _
                         "        CodInternoAccion " & _
                         " From   VwSsgAccionesxServicioxModulo " & _
                         " Where  ObjAplicacionID = " & IdAplicacion
            Else
                Strsql = " Select Cast((Select count(*) From SsgRolAccion " & _
                                  " Where ObjAccionID = VwSsgAccionesxServicioxModulo.SsgAccionID And " & _
                                  "       ObjRolID    = " & IdRol & ") As Bit) As Selected, " & _
                                         "        SsgModuloID," & _
                                         "        NombreModulo, " & _
                                         "        objAplicacionID, " & _
                                         "        SsgServicioUsuarioID," & _
                                         "        NombreServicio, " & _
                                         "        SsgAccionID, " & _
                                         "        NombreAccion, " & _
                                         "        CodInternoAccion " & _
                                         " From   VwSsgAccionesxServicioxModulo " & _
                                         " Where  ObjAplicacionID = " & IdAplicacion

            End If           
            XdsAcciones.ExecuteSql(Strsql)
            Me.grdAcciones.DataSource = XdsAcciones.Source

            'Configurando los campos del Grid
            'Configurando el Grid.
            Me.grdAcciones.Splits(0).DisplayColumns("SsgModuloID").Visible = False
            Me.grdAcciones.Splits(0).DisplayColumns("objAplicacionID").Visible = False
            Me.grdAcciones.Splits(0).DisplayColumns("SsgServicioUsuarioID").Visible = False
            Me.grdAcciones.Splits(0).DisplayColumns("SsgAccionID").Visible = False
            Me.grdAcciones.Splits(0).DisplayColumns("CodInternoAccion").Visible = False
         

            'Configurando el Caption de algunas columnas
            Me.grdAcciones.Columns("NombreAccion").Caption = "Acción"
            Me.grdAcciones.Columns("NombreModulo").Caption = "Módulo"
            Me.grdAcciones.Columns("NombreServicio").Caption = "Servicio"
            Me.grdAcciones.Columns("Selected").Caption = ""

            'Lockear las columnas que no sean el Selected
            Me.grdAcciones.Splits(0).DisplayColumns("NombreAccion").Locked = True
            Me.grdAcciones.Splits(0).DisplayColumns("NombreModulo").Locked = True
            Me.grdAcciones.Splits(0).DisplayColumns("NombreServicio").Locked = True

            'Dimensionando el ancho de las columnas
            Me.grdAcciones.Splits(0).DisplayColumns("Selected").Width = 30
            Me.grdAcciones.Splits(0).DisplayColumns("NombreModulo").Width = 120
            Me.grdAcciones.Splits(0).DisplayColumns("NombreServicio").Width = 120

            'Actualizando el caption de los GRIDS
            Me.grdAcciones.Caption = " Listado de Acciones (" + Me.grdAcciones.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub grdAcciones_Filter1(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdAcciones.Filter
        Try

            XdsAcciones.FilterLocal(e.Condition)
            Me.grdAcciones.Caption = " Listado de Acciones (" + Me.grdAcciones.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub txtNombre_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        vbModifico = True
    End Sub
    Private Sub txtDescripcion_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        vbModifico = True
    End Sub
    Private Sub cmdAceptar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If FncValidaParametros() Then
                SalvarRol()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        If FncValidaParametros() Then
                            SalvarRol()
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
End Class