' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                30/04/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditCajeros.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Cajeros y Cajas asignadas por
'                       Cajeros del Programa.
'-------------------------------------------------------------------------
Public Class frmSteEditCajeros

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSteCajero As Integer
    Dim IdSteCaja As Integer
    Dim IntSteCajero As Integer
    Dim IntPermiteEditar As Integer

    '-- Crear un data table de tipo Xdataset para el Control de Cajeros:
    Dim ObjCajerodt As BOSistema.Win.SteEntTesoreria.SteCajeroDataTable
    Dim ObjCajerodr As BOSistema.Win.SteEntTesoreria.SteCajeroRow

    '-- Crear un data table de tipo Xdataset para el Control de Cajas:
    Dim ObjCajadt As BOSistema.Win.SteEntTesoreria.SteCajeroCajasDataTable
    Dim ObjCajadr As BOSistema.Win.SteEntTesoreria.SteCajeroCajasRow

    '-- Crear un data table de tipo Xdataset para el Control de Combos:
    Dim XdsCajeroCaja As BOSistema.Win.XDataSet

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
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

    'Propiedad utilizada para obtener el ID de Cajero.
    Public Property IdCajero() As Integer
        Get
            IdCajero = IdSteCajero
        End Get
        Set(ByVal value As Integer)
            IdSteCajero = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Caja asignada al Cajero.
    Public Property IdCaja() As Integer
        Get
            IdCaja = IdSteCaja
        End Get
        Set(ByVal value As Integer)
            IdSteCaja = value
        End Set
    End Property

    'Propiedad utilizada para obtener si se esta Ingresando 
    'un Cajero (1) o una Caja (0).
    Public Property IntCajero() As Integer
        Get
            IntCajero = IntSteCajero
        End Get
        Set(ByVal value As Integer)
            IntSteCajero = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       frmSteEditCajeros_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCajeros_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjCajerodt.Close()
                ObjCajerodt = Nothing

                ObjCajerodr.Close()
                ObjCajerodr = Nothing

                ObjCajadt.close()
                ObjCajadt = Nothing

                ObjCajadr.close()
                ObjCajadr = Nothing

                XdsCajeroCaja.Close()
                XdsCajeroCaja = Nothing

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
    ' Fecha:                30/04/2008
    ' Procedure Name:       frmSteEditCajeros_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCajeros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            If Me.IntSteCajero = 1 Then 'Cajeros
                Me.grpCajas.Visible = False
                CargarComboCajero(0)
            Else 'Cajas asignadas
                Me.grpCajero.Visible = False
                CargarComboCaja(0)
            End If

            'Si el formulario está en modo edición:
            If ModoForm <> "ADD" Then
                If Me.IntSteCajero = 1 Then
                    CargarCajero()
                Else
                    CargarCaja()
                End If
                'Si el Cajero esta Inactivo:
                InhabilitarControles()
            End If

            If Me.IntSteCajero = 1 Then
                Me.cboCajero.Select()
            Else
                Me.cboCaja.Select()
            End If

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
    ' Fecha:                30/04/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Dim Strsql As String
        Try
            'Si el Cajero no se encuentra Activo:
            If Me.IntSteCajero = 1 Then
                Strsql = " SELECT a.nActivo FROM SteCajero a WHERE (a.nActivo = 1) And (a.nSteCajeroID = " & IdSteCajero & ")"
            Else
                Strsql = " SELECT a.nActiva FROM SteCajeroCajas a WHERE (a.nActiva = 1) And (a.nSteCajeroCajasID = " & IdSteCaja & ")"
            End If

            If RegistrosAsociados(Strsql) = False Then
                Me.CmdAceptar.Enabled = False
                Me.grpCajero.Enabled = False
                Me.grpCajas.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If Me.IntSteCajero = 1 Then
                If ModoForm = "ADD" Then
                    Me.Text = "Agregar Cajero del Programa"
                Else
                    Me.Text = "Modificar Cajero del Programa"
                End If
            Else
                If ModoForm = "ADD" Then
                    Me.Text = "Asignar Caja a un Cajero del Programa"
                Else
                    Me.Text = "Modificar Caja a un Cajero del Programa"
                End If
            End If

            ObjCajerodt = New BOSistema.Win.SteEntTesoreria.SteCajeroDataTable
            ObjCajerodr = New BOSistema.Win.SteEntTesoreria.SteCajeroRow

            ObjCajadt = New BOSistema.Win.SteEntTesoreria.SteCajeroCajasDataTable
            ObjCajadr = New BOSistema.Win.SteEntTesoreria.SteCajeroCajasRow

            XdsCajeroCaja = New BOSistema.Win.XDataSet
            Control.CheckForIllegalCrossThreadCalls = False
            Me.cboCajero.ClearFields()
            Me.cboCaja.ClearFields()

            If ModoForm = "ADD" Then
                If Me.IntSteCajero = 1 Then
                    ObjCajerodr = ObjCajerodt.NewRow
                Else
                    ObjCajadr = ObjCajadt.NewRow
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       CargarCajero
    ' Descripción:          Este procedimiento permite cargar los datos del Cajero
    '                       seleccionado en caso de estar en Modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCajero()
        Try

            '-- Buscar el Cajero correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjCajerodt.Filter = "nSteCajeroID = " & IdSteCajero
            ObjCajerodt.Retrieve()
            If ObjCajerodt.Count = 0 Then
                Exit Sub
            End If
            ObjCajerodr = ObjCajerodt.Current

            'Codigo 
            Me.txtCodigo.Text = ObjCajerodr.nCodigo

            'Cajero:
            If Not ObjCajerodr.IsFieldNull("nSrhEmpleadoID") Then
                If Me.cboCajero.ListCount > 0 Then
                    Me.cboCajero.SelectedIndex = 0
                End If
                XdsCajeroCaja("Cajero").SetCurrentByID("nSrhEmpleadoID", ObjCajerodr.nSrhEmpleadoID)
            Else
                Me.cboCajero.Text = ""
                Me.cboCajero.SelectedIndex = -1
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       CargarCaja
    ' Descripción:          Este procedimiento permite cargar los datos de la 
    '                       Caja seleccionada en caso de estar en Modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCaja()
        Try

            '-- Buscar Caja correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjCajadt.Filter = "nSteCajeroCajasID = " & IdSteCaja
            ObjCajadt.Retrieve()
            If ObjCajadt.Count = 0 Then
                Exit Sub
            End If
            ObjCajadr = ObjCajadt.Current

            'Caja:
            If Not ObjCajadr.IsFieldNull("nSteCajaID") Then
                If Me.cboCaja.ListCount > 0 Then
                    Me.cboCaja.SelectedIndex = 0
                End If
                XdsCajeroCaja("Caja").SetCurrentByID("nSteCajaID", ObjCajadr.nSteCajaID)
            Else
                Me.cboCaja.Text = ""
                Me.cboCaja.SelectedIndex = -1
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                If Me.IntSteCajero = 1 Then
                    SalvarCajero()
                Else
                    SalvarCaja()
                End If
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try

            ValidaDatosEntrada = True
            Me.errCajeroCajas.Clear()
            Dim StrSql As String

            '-- Validaciones para Cajeros:
            If Me.IntSteCajero = 1 Then
                'Cajero válido:
                If Me.cboCajero.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Cajero válido.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCajeroCajas.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                    Me.cboCajero.Focus()
                    Exit Function
                End If
                'Imposible agregar más de una vez el mismo Cajero activo:
                StrSql = "SELECT * FROM  SteCajero " & _
                         "WHERE (nSrhEmpleadoID = " & cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (nActivo = 1) AND (nSteCajeroID <> " & Me.IdSteCajero & ")"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("El Cajero seleccionado ya ha sido ingresado.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCajeroCajas.SetError(Me.cboCajero, "El Cajero seleccionado ya ha sido ingresado.")
                    Me.cboCajero.Focus()
                    Exit Function
                End If
            Else '-- Validaciones para Cajas:
                'Caja válida:
                If Me.cboCaja.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar una Caja válida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCajeroCajas.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                    Me.cboCaja.Focus()
                    Exit Function
                End If
                'Imposible agregar más de una vez la misma Caja activa al Cajero:
                StrSql = "SELECT * FROM  SteCajeroCajas " & _
                         "WHERE (nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (nActiva = 1) AND (nSteCajeroCajasID <> " & Me.IdSteCaja & ") AND (nSteCajeroID = " & Me.IdSteCajero & ")"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("La Caja ya ha sido asignada al Cajero.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCajeroCajas.SetError(Me.cboCaja, "La Caja ya ha sido asignada al Cajero.")
                    Me.cboCaja.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       SalvarCajero
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Cajero en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCajero()
        Dim ObjTmpCajero As New BOSistema.Win.XDataSet
        Try
            Dim strSQL As String

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjCajerodr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjCajerodr.dFechaCreacion = FechaServer()
                ObjCajerodr.nActivo = 1
            Else
                ObjCajerodr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjCajerodr.dFechaModificacion = FechaServer()
            End If

            'Cajero:
            If Me.cboCajero.SelectedIndex = -1 Then
                ObjCajerodr.SetFieldNull("nSrhEmpleadoID")
            Else
                ObjCajerodr.nSrhEmpleadoID = Me.cboCajero.Columns("nSrhEmpleadoID").Value
            End If

            'Asignación del Código siguiente:
            If ModoForm = "ADD" Then
                strSQL = " SELECT max(nCodigo) as maxCodigo FROM SteCajero"
                If ObjTmpCajero.ExistTable("Cajero") Then
                    ObjTmpCajero("Cajero").ExecuteSql(strSQL)
                Else
                    ObjTmpCajero.NewTable(strSQL, "Cajero")
                    ObjTmpCajero("Cajero").Retrieve()
                End If
                If Not ObjTmpCajero("Cajero").ValueField("maxCodigo") Is DBNull.Value Then
                    Me.txtCodigo.Text = Format(ObjTmpCajero("Cajero").ValueField("maxCodigo") + 1) ', "00"
                Else
                    Me.txtCodigo.Text = "1"
                End If
            End If

            'Código: 
            ObjCajerodr.nCodigo = Me.txtCodigo.Text
			
			If ModoForm <> "ADD" Then
                GuardarAuditoriaTablas(11, 2, "Modificar SteCajero", ObjCajerodr.nSteCajeroID, InfoSistema.IDCuenta)
			End If

            ObjCajerodr.Update()
            'Asignar el Id del Cajero a la variable publica del formulario:
            IdSteCajero = ObjCajerodr.nSteCajeroID
            '-------------------------------------

            'Si el salvado se realizó de forma satisfactoria enviar mensaje informando y cerrar el formulario.
            If ModoForm = "ADD" Then
                GuardarAuditoriaTablas(11, 1, "Agregar SteCajero", IdSteCajero, InfoSistema.IDCuenta)
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If

            

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpCajero.Close()
            ObjTmpCajero = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       SalvarCaja
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Caja en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCaja()
        Try

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjCajadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjCajadr.dFechaCreacion = FechaServer()
                ObjCajadr.nActiva = 1
            Else
                ObjCajadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjCajadr.dFechaModificacion = FechaServer()
            End If

            'Caja:
            If Me.cboCaja.SelectedIndex = -1 Then
                ObjCajadr.SetFieldNull("nSteCajaID")
            Else
                ObjCajadr.nSteCajaID = Me.cboCaja.Columns("nSteCajaID").Value
            End If

            'Cajero:
            ObjCajadr.nSteCajeroID = Me.IdSteCajero
			
			If ModoForm <> "ADD" Then
				GuardarAuditoriaTablas(12, 2, "Modificar CajaCajero", IdSteCaja, InfoSistema.IDCuenta)
			End If

            ObjCajadr.Update()
            'Asignar el Id de la Caja a la variable publica del formulario:
            IdSteCaja = ObjCajadr.nSteCajeroCajasID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                GuardarAuditoriaTablas(12, 1, "Agregar CajaCajero", IdSteCaja, InfoSistema.IDCuenta)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Caja asociada a Cajero. ID: " & Me.IdSteCaja & ").")                
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
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
                            If Me.IntSteCajero = 1 Then
                                SalvarCajero()
                            Else
                                SalvarCaja()
                            End If
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
    ' Fecha:                30/04/2008
    ' Procedure Name:       CargarComboCajero
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajeros en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarComboCajero(ByVal intCajeroID As Integer)
        Try
            Dim Strsql As String

            Me.cboCajero.ClearFields()
            If intCajeroID = 0 Then
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    'Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                    '         " From vwSclRepresentantePrograma a " & _
                    '         " WHERE (a.nActivo = 1) And (a.sCodCargo = '04') AND (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                    '         " Order by a.nCodigo "

                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE (a.nActivo = 1) And ((a.sCodCargo = '04') OR (a.sCodCargo = '15') OR (a.sCodCargo = '27')) AND (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                             " Order by a.nCodigo "

                Else
                    'Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                    '         " From vwSclRepresentantePrograma a " & _
                    '         " WHERE (a.nActivo = 1) And (a.sCodCargo = '04') " & _
                    '         " Order by a.nCodigo "

                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE (a.nActivo = 1) And ((a.sCodCargo = '04') OR (a.sCodCargo = '15')  OR (a.sCodCargo = '27')) " & _
                             " Order by a.nCodigo "



                    'Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                    '       " From vwSclRepresentantePrograma a " & _
                    '       " WHERE (a.nActivo = 1)  " & _
                    '       " Order by a.nCodigo "
                End If
                
            Else
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE ((a.nActivo = 1) And (a.sCodCargo = '04') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) " & _
                             " Or (a.nSrhEmpleadoID = " & intCajeroID & _
                             " ) Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE ((a.nActivo = 1) And (a.sCodCargo = '04')) " & _
                             " Or (a.nSrhEmpleadoID = " & intCajeroID & _
                             " ) Order by a.nCodigo "
                End If
            End If

            If XdsCajeroCaja.ExistTable("Cajero") Then
                XdsCajeroCaja("Cajero").ExecuteSql(Strsql)
            Else
                XdsCajeroCaja.NewTable(Strsql, "Cajero")
                XdsCajeroCaja("Cajero").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboCajero.DataSource = XdsCajeroCaja("Cajero").Source
            Me.cboCajero.Rebind()

            Me.cboCajero.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False

            'Configurar el combo: 
            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

            Me.cboCajero.Columns("nCodigo").Caption = "Código"
            Me.cboCajero.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/04/2008
    ' Procedure Name:       CargarComboCaja
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajas en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarComboCaja(ByVal intCajaID As Integer)
        Try
            Dim Strsql As String
            Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
            Dim BandFiltraVG As Boolean = False
            Dim CadFiltroVG As String
            Strsql = "SELECT     dbo.StbValorParametro.sValorParametro  FROM         dbo.StbValorParametro INNER JOIN  dbo.StbParametro ON dbo.StbValorParametro.nStbParametroID = dbo.StbParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Seleccionar Caja VG Recibos Automtacios')"
            RegTmp.ExecuteSql(Strsql)
            If RegTmp.Count > 0 Then
                If RegTmp.ValueField("sValorParametro") = "1" Then
                    BandFiltraVG = True
                End If
            End If
            Me.cboCaja.ClearFields()

            CadFiltroVG = ""
            If Not BandFiltraVG Then
                CadFiltroVG = "  AND CodPrograma<>'2' "
            End If
            If intCajaID = 0 Then
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID " & _
                             " From vwSteCaja a " & _
                             " WHERE (a.nCerrada = 0) AND (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & CadFiltroVG & _
                             " Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID " & _
                             " From vwSteCaja a " & _
                             " WHERE a.nCerrada = 0 " & CadFiltroVG & _
                             " Order by a.nCodigo "
                End If

            Else
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID  " & _
                             " From vwSteCaja a " & _
                             " WHERE ((a.nCerrada = 0) AND (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & " )) " & _
                             " Or a.nSteCajaID = " & intCajaID & CadFiltroVG & _
                             " Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID  " & _
                             " From vwSteCaja a " & _
                             " WHERE (a.nCerrada = 0) " & _
                             " Or a.nSteCajaID = " & intCajaID & CadFiltroVG & _
                             " Order by a.nCodigo "
                End If
            End If

            If XdsCajeroCaja.ExistTable("Caja") Then
                XdsCajeroCaja("Caja").ExecuteSql(Strsql)
            Else
                XdsCajeroCaja.NewTable(Strsql, "Caja")
                XdsCajeroCaja("Caja").Retrieve()
            End If

            'Asignando las fuentes de datos:
            Me.cboCaja.DataSource = XdsCajeroCaja("Caja").Source
            Me.cboCaja.Rebind()

            'Configurar el combo:
            Me.cboCaja.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").Width = 250
            Me.cboCaja.Splits(0).DisplayColumns("sLugarPagos").Width = 150
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").Width = 90

            Me.cboCaja.Columns("nCodigo").Caption = "Código"
            Me.cboCaja.Columns("sDescripcionCaja").Caption = "Descripción Caja"
            Me.cboCaja.Columns("sLugarPagos").Caption = "Lugar de Pagos"
            Me.cboCaja.Columns("dFechaApertura").Caption = "Fecha Apertura"

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("sLugarPagos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Columns("dFechaApertura").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboCajero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCajero.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.TextChanged
        vbModifico = True
        txtCodigoCaja.Text = cboCaja.Columns("nCodigo").Value
    End Sub
End Class