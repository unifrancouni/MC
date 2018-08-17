Public Class FrmLogin

    'Declaracion de Variables Globales 
    Public XLoginIntentado As String
    Public XIntentos As Integer 'Contador de intentos
    Public xIntentosMaximo As Integer  'Numero de intento maximos
    Public mLoginSucessed As Boolean
    Dim BloquearCuenta As Boolean
    Dim BloquearCuentaParametro As Boolean


    Dim DiasCambioPalabraParametro As Integer
    Dim ObligaCambioPalabraParametro As Boolean

    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    'Propiedad que permite evaluar si el 
    'usuario tiene una contraseña válida.
    Property LoginSucessed() As Boolean
        Get
            LoginSucessed = mLoginSucessed
        End Get
        Set(ByVal value As Boolean)
            mLoginSucessed = value
        End Set
    End Property
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            LoginSucessed = False
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FrmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            InicializaVariables()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '---------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    02 de Agosto del 2006
    '-- Descripcion:                Inicializar las variables globales del formulario
    '--                             de autenticacion de Usuario.
    '---------------------------------------------------------------
    Private Sub InicializaVariables()

        'Declaracion de Variables
        Dim ObjCuentaDt As New BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable

        Try
            'ObjCuentaDt = New BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable

            'Definir la longitud maxima de los campos
            Me.txtUsuario.MaxLength = ObjCuentaDt.GetColumnLenght("Login")
            Me.txtContrasena.MaxLength = 10   'ObjCuentaDt.GetColumnLenght("Clave")

            'Inicializar el foco en el Login
            Me.txtUsuario.Focus()
            XIntentos = 0
            'Obtener el numero maximo de intentos
            XdtDatos.ExecuteSql(" SELECT      sValorParametro FROM         dbo.StbValorParametro  WHERE    nStbValorParametroID=101 ")
            If XdtDatos.Count > 0 Then

                xIntentosMaximo = XdtDatos.ValueField("sValorParametro")
            End If
            BloquearCuenta = True
            BloquearCuentaParametro = False
            'Obtener Si bloquea cuenta o no
            XdtDatos.ExecuteSql(" SELECT      sValorParametro FROM         dbo.StbValorParametro  WHERE    nStbValorParametroID=102 ")
            If XdtDatos.Count > 0 Then
                If XdtDatos.ValueField("sValorParametro") <> "0" Then
                    BloquearCuentaParametro = True
                End If
                'xIntentosMaximo = XdtDatos.ValueField("sValorParametro")
            End If

            DiasCambioPalabraParametro = 0
            ObligaCambioPalabraParametro = False
            XdtDatos.ExecuteSql(" SELECT      sValorParametro FROM         dbo.StbValorParametro  WHERE    nStbValorParametroID=103 ")
            If XdtDatos.Count > 0 Then
                If XdtDatos.ValueField("sValorParametro") <> "0" Then
                    ObligaCambioPalabraParametro = True
                    DiasCambioPalabraParametro = XdtDatos.ValueField("sValorParametro")
                End If
                'xIntentosMaximo = XdtDatos.ValueField("sValorParametro")
            End If


          







        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjCuentaDt.Close()
            ObjCuentaDt = Nothing
        End Try
    End Sub

    Private Sub LlamaModificaUsuario()
      
        Dim ObjFrmEditUsuario As FrmSsgEditCuenta


        Try
            ObjFrmEditUsuario = New FrmSsgEditCuenta

            ObjFrmEditUsuario.ModoFrm = "UPD"
            '------------------------------------------
            ObjFrmEditUsuario.IdUsuario = InfoSistema.IDCuenta             'CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            ObjFrmEditUsuario.sTipoLlamado = "PRINCIPAL"
            ObjFrmEditUsuario.ShowDialog()
      
        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditUsuario = Nothing
            'Nodos = Nothing
        End Try
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim StrMensaje As String
        Dim dFechaCorte As Date
        Dim sFechaCorteParametro As String

        Try
            StrMensaje = ""

            If Trim(Me.txtUsuario.Text).Length = 0 Then
                MsgBox("Ingrese un Login de Usuario válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtUsuario.Select()
                Exit Sub
            End If
            If Trim(Me.txtUsuario.Text.ToUpper) = "DESARROLLO" Then
                MsgBox("Ingrese un Login de Usuario válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtUsuario.Select()
                Exit Sub
            End If

            If Not UsuarioExcepcion(Me.txtUsuario.Text) And UsuarioBloqueado(Me.txtUsuario.Text) And BloquearCuentaParametro Then
                MsgBox("Su cuenta se encuentra bloqueada. Pida al administrador de sistemas que la desbloquee.", MsgBoxStyle.Critical, NombreSistema)
                Me.Close()
                Exit Sub
            End If

            If Seg.Connect(Me.txtUsuario.Text, Me.txtContrasena.Text, "SMUSURA0", StrMensaje) Then
                LoginSucessed = True
                SetUsuarioConect()





                ' --Comienza para obligar a cambiar palabra clave
                'Si no esta en lista de excepciones y esta ibligado a cambiar la palabra clave
                If Not UsuarioExcepcion(Me.txtUsuario.Text) And ObligaCambioPalabraParametro Then
                    'Ver 

                    XdtDatos.ExecuteSql("SELECT     TOP 1  FechaCreacion  FROM         dbo.SsgCuentaUltimaClave  WHERE     SsgCuentaID = " & InfoSistema.IDCuenta & "  ORDER BY FechaCreacion DESC")
                    If XdtDatos.Count = 0 Then 'No ha hecho ni un solo cambio, entonces buscar de parametros la minima fecha para comenzar a contar los dias al cambio obligado de password

                        XdtDatos.ExecuteSql("SELECT sValorParametro FROM StbValorParametro WHERE (nStbValorParametroID=104)")
                        If XdtDatos.Count > 0 Then
                            sFechaCorteParametro = XdtDatos.ValueField("sValorParametro")
                            dFechaCorte = Mid(sFechaCorteParametro, 1, 2) + "/" + Mid(sFechaCorteParametro, 3, 2) + "/" + Mid(sFechaCorteParametro, 5, 4)
                        End If
                    Else 'Si tiene entonces ver la ultima fecha de cambio
                        dFechaCorte = XdtDatos.ValueField("FechaCreacion")

                    End If




                    If (Math.Abs(DateDiff("d", FechaServer.Date, dFechaCorte)) >= DiasCambioPalabraParametro) Then
                        MsgBox("Debe Cambiar su palabra de acceso", MsgBoxStyle.Critical, NombreSistema)
                        If InfoSistema.IDCuenta > 0 Then
                            GSalvadoNuevoPassword = False
                            LlamaModificaUsuario()
                        End If
                        If GSalvadoNuevoPassword = False Then 'Salirse no cambio el password.
                            'Me.Close()

                            System.Windows.Forms.Application.Exit()
                        End If


                    End If


                End If

                ' --Fin para obligar a cambiar palabra clave




















                Me.Close()
            Else
                MsgBox(StrMensaje, MsgBoxStyle.Critical, NombreSistema)
                Me.txtUsuario.Select()


                If Not UsuarioExcepcion(Me.txtUsuario.Text) And xIntentosMaximo > 0 Then


                    XIntentos = XIntentos + 1

                    If XIntentos = 1 Then

                        XLoginIntentado = UCase(Me.txtUsuario.Text)
                    Else
                        If XLoginIntentado <> UCase(Me.txtUsuario.Text) Then
                            BloquearCuenta = False
                        End If

                    End If

                    If xIntentosMaximo > 0 And XIntentos >= xIntentosMaximo Then 'Si es obligado a un numero de intentos maximos
                        MsgBox("Numero maximo de intentos alcanzado", MsgBoxStyle.Critical, NombreSistema)

                        LoginSucessed = False
                        'Si hizo el numero de intento con el mismo login lo bloquea si esta el parametro que indique que se haga esto
                        If BloquearCuentaParametro And BloquearCuenta Then
                            XdtDatos.ExecuteSql(" INSERT INTO SsgCuentaBloqueada(SsgCuentaID,FechaCreacion)       SELECT      SsgCuentaID,GETDATE() FROM         dbo.SsgCuenta  WHERE     ({ fn UCASE(dbo.SsgCuenta.Login) } = { fn UCASE('" & txtUsuario.Text & "') }) ")
                            MsgBox("Su cuenta ha sido bloqueada. Pida al administrador de sistema que la desbloquee.", MsgBoxStyle.Critical, NombreSistema)
                        End If


                        'Me.Close()
                        System.Windows.Forms.Application.Exit()

                    End If
                End If
            End If


            'strSQL = " SELECT     nSclFichaNotificacionID  FROM         dbo.SttCentralFichaNotificacionCreditoEnviadas  WHERE     (nActiva = 1) AND (nSclFichaNotificacionID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionID") & ")"
            'XdtDatos.ExecuteSql(strSQL)


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function UsuarioExcepcion(ByVal UsuarioName As String) As Boolean
        Try

            XdtDatos.ExecuteSql("SELECT     dbo.SsgCuenta.Login FROM         dbo.SsgCuentaNoBloquear INNER JOIN  dbo.SsgCuenta ON dbo.SsgCuentaNoBloquear.SsgCuentaID = dbo.SsgCuenta.SsgCuentaID WHERE     ({ fn UCASE(dbo.SsgCuenta.Login) } = { fn UCASE('" & UsuarioName & "') }) AND nActiva=1")
            If XdtDatos.Count > 0 Then

                Return True  'Si esta en excepcion de intentos. y Bloqueo
            End If


            Return False


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    Private Function UsuarioBloqueado(ByVal UsuarioName As String) As Boolean
        Try

            XdtDatos.ExecuteSql("SELECT     dbo.SsgCuenta.Login FROM         dbo.SsgCuentaBloqueada INNER JOIN  dbo.SsgCuenta ON dbo.SsgCuentaBloqueada.SsgCuentaID = dbo.SsgCuenta.SsgCuentaID WHERE     ({ fn UCASE(dbo.SsgCuenta.Login) } = { fn UCASE('" & UsuarioName & "') }) ")
            If XdtDatos.Count > 0 Then

                Return True  'Tiene bloqueo por intentos de acceso. No ha sido desbloqueado por el administrador.
            End If


            Return False


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	03 de Agosto del 2006
    ' Procedure name		   	:	SetUsuarioConect
    ' Description			   	:	        
    ' -----------------------------------------------------------------------------------------
    Private Sub SetUsuarioConect()

        'Declaracion de Variables -------------------
        Dim ObjEmpleado As New BOSistema.Win.SrhEntEmpleado.SrhEmpleadoDataTable
        Dim ObjPersonaNat As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Dim objSsgCuentaDT As New BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable
        Dim StrNameUsr As String
        Dim StrNombreEmpleado As String
        '--------------------------------------------
        Try
            'Inicializar Variables 
            StrNameUsr = ""
            StrNombreEmpleado = ""

            'Instanciar las clases
            'ObjEmpleado = New BOSistema.Win.SrhEntEmpleado.SrhEmpleadoDataTable
            'ObjPersonaNat = New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable

            'Buscar el Empleado asociado al LOGIN
            If Seg.UserID > 0 Then
                'Buscar el Usuario
                ObjEmpleado.Filter = "nSrhEmpleadoID = " & Seg.UserID
                ObjEmpleado.Retrieve()

                If ObjEmpleado.Count > 0 Then
                    '-- Buscar el Nombre del Empleado
                    ObjPersonaNat.Filter = "nStbPersonaID = " & ObjEmpleado.Itemn(0).nStbPersonaID
                    ObjPersonaNat.Retrieve()

                    If ObjPersonaNat.Count > 0 Then
                        'Primer Nombre
                        StrNombreEmpleado = ObjPersonaNat.Itemn(0).sNombre1

                        'Segundo Nombre
                        If Not ObjPersonaNat.Itemn(0).IsFieldNull("sNombre2") Then
                            StrNombreEmpleado = StrNombreEmpleado & " " & ObjPersonaNat.Itemn(0).sNombre2
                        End If

                        'Primer Apellido
                        StrNombreEmpleado = StrNombreEmpleado & " " & ObjPersonaNat.Itemn(0).sApellido1RS

                        'Segundo Apellido
                        If Not ObjPersonaNat.Itemn(0).IsFieldNull("sApellido2") Then
                            StrNombreEmpleado = StrNombreEmpleado & " " & ObjPersonaNat.Itemn(0).sApellido2
                        End If

                    End If
                End If
            End If

            'Establecer las variables de ambiente
            'que hace referencia al usuario conectado.
            InfoSistema.LoginName = Seg.Login
            InfoSistema.UsrName = StrNombreEmpleado

            objSsgCuentaDT.Filter = "objEmpleadoID = " & Seg.UserID
            '& " and  Activo =1 "
            'objSsgCuentaDT.Filter = "Activo= " & 1
            objSsgCuentaDT.Retrieve()

            If objSsgCuentaDT.Count > 0 Then
                InfoSistema.IDCuenta = objSsgCuentaDT.ValueField("SsgCuentaID")
                InfoSistema.IDDelegacion = objSsgCuentaDT.ValueField("nStbDelegacionProgramaID")
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEmpleado.Close()
            ObjEmpleado = Nothing

            ObjPersonaNat.Close()
            ObjPersonaNat = Nothing

            objSsgCuentaDT.Close()
            objSsgCuentaDT = Nothing
        End Try
    End Sub
End Class