Imports Microsoft.Win32

Public Class frmPrincipal

    Private _VentanasPermitidas As Int32 = 0


    Public Property VentanasPermitidas()
        Get
            Return _VentanasPermitidas
        End Get
        Set(ByVal value)
            _VentanasPermitidas = value
        End Set
    End Property

    ' -----------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09 de Agosto del 2006
    ' Procedure name		   	:   LlamaPresupuesto
    ' Description			   	:	Llama al sistema de Presupuesto.    
    ' -----------------------------------------------------------------
    Private Sub LlamaControlSocias()

        'Declaracion de Variables 
        Dim ObjFrmControlSocias As FrmMDIControlSocias

        Try
            ObjFrmControlSocias = New FrmMDIControlSocias

            OpenForm(ObjFrmControlSocias)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmControlSocias = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09 de Agosto del 2006
    ' Procedure name		   	:   LlamaPresupuesto
    ' Description			   	:	Llama al sistema de Contabilidad.    
    ' -----------------------------------------------------------------
    Private Sub LlamaControlCredito()

        'Declaracion de Variables 
        Dim ObjFrmControlCredito As FrmMDIControlCredito

        Try
            ObjFrmControlCredito = New FrmMDIControlCredito

            OpenForm(ObjFrmControlCredito)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmControlCredito = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09 de Agosto del 2006
    ' Procedure name		   	:	LlamaTesoreria
    ' Description			   	:	Llama al subsistema de Contabilidad. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaContabilidad()

        'Declaracion de Variables 
        Dim ObjFrmContabilidad As FrmMDIContabilidad

        Try
            ObjFrmContabilidad = New FrmMDIContabilidad

            OpenForm(ObjFrmContabilidad)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmContabilidad = Nothing
        End Try
    End Sub
    ' ----------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09 de Agosto del 2006
    ' Procedure name		   	:	LLamaCompras
    ' Description			   	:	Llama al Subsistema de Compras    
    ' ----------------------------------------------------------------------
    Private Sub LLamaTesoreria()

        'Declaracion de Variables 
        Dim ObjFrmTesoreria As FrmMDITesoreria

        Try
            ObjFrmTesoreria = New FrmMDITesoreria

            OpenForm(ObjFrmTesoreria)
            'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmTesoreria = Nothing
        End Try
    End Sub
    ' ----------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09 de Agosto del 2006
    ' Procedure name		   	:	LLamaCompras
    ' Description			   	:	Llama al Subsistema de Compras    
    ' ----------------------------------------------------------------------
    Private Sub LLamaCatalogoBasico()

        'Declaracion de Variables 
        Dim ObjFrmCatalogoBasico As FrmMDICatalogoBasico

        Try
            ObjFrmCatalogoBasico = New FrmMDICatalogoBasico

            OpenForm(ObjFrmCatalogoBasico)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmCatalogoBasico = Nothing
        End Try
    End Sub
    '-------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    02 de Agosto del 2006
    '-- Descripcion:                Validar la autenticacion de entrada del usuario.
    '--------------------------------------------------------------------------------
    Private Sub SubMain()
        Try
            'Declaracion de Variables --------
            Dim ObjFrmLogin As FrmLogin

            'Dim ObjFrmPeriodo As FrmPeriodo
            Dim StrMensaje As String
            '---------------------------------

            'Instanciar la clase de Seguridad
            Seg = New SEA.seaPI

            StrMensaje = ""
            If DebugMode = True Then

                'Si el Login y Contraseña de Debug no es válido
                If Not Seg.Connect("DESARROLLO", "123", "SMUSURA0", StrMensaje) Then
                    MsgBox(StrMensaje, MsgBoxStyle.Critical, NombreSistema)
                    HabDeshOpciones("CARGAR")
                    End
                Else
                    InfoSistema.LoginName = "DESARROLLO"
                    InfoSistema.UsrName = "DESARROLLO"
                    HabDeshOpciones("LOGEODESARROLLO")

                End If

            Else
                ObjFrmLogin = New FrmLogin
                ObjFrmLogin.ShowDialog()
                If ObjFrmLogin.LoginSucessed Then

                    'El usuario se logeó
                    ObjFrmLogin = Nothing
                    Seguridad()
                    HabDeshOpciones("LOGEO")

                Else
                    ObjFrmLogin.Close()
                    ObjFrmLogin = Nothing
                    If Trim(InfoSistema.LoginName) = "NINGUNO" Or _
                       Trim(Me.txtUsuario.Text) = "" Then
                        HabDeshOpciones("CARGAR")
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    'Private Sub InicializaContextInfoUser()
    '    Try
    '        Dim XcDatos As New BOSistema.Win.XComando
    '        XcDatos.Execute("EXEC uspSrhCtxInfo '" & InfoSistema.IDCuenta & "'")
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    Private Sub ObtenerBanderaAuditoria()
        Try
            Dim XdTabla As New BOSistema.Win.XDataSet.xDataTable
            BGuardarAuditoria = False

            XdTabla.ExecuteSql("SELECT ISNULL(sValorParametro,0) as GuardarAud from StbValorParametro where nStbParametroID =100 ")
            If XdTabla.Count > 0 Then '
                If XdTabla.ValueField("GuardarAud") = 1 Then
                    BGuardarAuditoria = True
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try


    End Sub
    Private Sub frmPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Dim regKey As RegistryKey, strKeyPathFiles As String

            HabDeshOpciones("CARGAR")

            'Application.DoEvents()
            'frmLoadProgress.Show(Me)



            'If Environment.GetCommandLineArgs.Length <> 2 Then

            '    MsgBox("Entre desde el acceso directo del actualizador", MsgBoxStyle.Information, NombreSistema)
            '    End
            'End If
            'If Environment.GetCommandLineArgs(1) <> "-1" Then

            '    MsgBox("Entre desde el acceso directo del actualizador", MsgBoxStyle.Information, NombreSistema)
            '    End
            'End If



            SubMain()

            'InicializaContextInfoUser()
            InicializaDatosRegedit()

            ObtenerMaximoVentanasAbiertas()

            ObtenerBanderaAuditoria()
            'CargarMonedaNacional()
            System.Environment.CurrentDirectory = My.Application.Info.DirectoryPath

            'Registry Key Set via GPO AD, can be set via application too
            'System.Environment.CurrentDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            'regKey = Registry.LocalMachine.OpenSubKey("Software\NTierApps\FoldersUser", False)
            'If Not (regKey Is Nothing) Then
            '    strKeyPathFiles = regKey.GetValue("MyDocuments", My.Computer.FileSystem.SpecialDirectories.Temp)
            '    If Len(strKeyPathFiles) > 0 Then
            '        MyCurrentDocs = strKeyPathFiles
            '    Else
            '        MyCurrentDocs = My.Computer.FileSystem.SpecialDirectories.Temp
            '    End If
            'Else
            '    MyCurrentDocs = My.Computer.FileSystem.SpecialDirectories.Temp
            'End If

            MyCurrentDocs = My.Computer.FileSystem.SpecialDirectories.MyDocuments

            MyHelpNameSpace = My.Application.Info.DirectoryPath & "\SMUSURA0_HELP.chm"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ObtenerMaximoVentanasAbiertas() As Int32
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            strSQL = " SELECT sValorParametro " & _
                     " FROM         dbo.StbParametro INNER JOIN dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID " & _
                     " WHERE dbo.StbParametro.sDescripcionParametro= 'Numero Pantallas Maximas'"

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                VentanasPermitidas = XdtDatos.ValueField("sValorParametro")
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function

    '---------------------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    02 de Agosto del 2006
    '-- Descripcion:                Habilitar o deshabilitar los subsistemas según los permisos.
    '---------------------------------------------------------------------------------------------
    Private Sub HabDeshOpciones(ByVal PMomento As String)
        Try
            'Al momento de CARGAR el formulario Principal
            If PMomento = "CARGAR" Then

                'Poner invisible el Group Box de Conexion
                'Me.grpInfoConexion.Visible = False

                'Limpiar la informacion de 
                'estado del Usuario  -----  
                Me.txtUsuario.Text = "Ninguno"

                'Deshabilitar la entrada a los Subsistemas 
                Me.lblControlSocias.Enabled = False
                Me.lblControlCredito.Enabled = False
                Me.lblContabilidad.Enabled = False
                Me.lblTesoreria.Enabled = False
                Me.lblCatalogoBasico.Enabled = False
                Me.lblSeguridad.Enabled = False
                Me.lblManuales.Enabled = False
                'Me.lblSalir.Enabled = False
                Me.lblControlSocias.Cursor = Cursors.No
                Me.lblControlCredito.Cursor = Cursors.No
                Me.lblContabilidad.Cursor = Cursors.No
                Me.lblTesoreria.Cursor = Cursors.No
                Me.lblCatalogoBasico.Cursor = Cursors.No
                Me.lblSeguridad.Cursor = Cursors.No
                Me.lblManuales.Cursor = Cursors.No
                'Me.lblSalir.Cursor = Cursors.No
                '---------------------------------------------            
                'Deshabilitar las opciones del Toolbar de Abajo
                'Me.lblLogin.Enabled = True
                'Me.lblLogin.Cursor = Cursors.Hand

                'Me.lblCerrarSesion.Enabled = False
                'Me.lblPeriodo.Enabled = False
                'Me.lblMantPeriodo.Enabled = False
                'Me.lblConfiguracion.Enabled = False

                'Me.lblCerrar.Enabled = True
                'Me.lblCerrar.Cursor = Cursors.Hand
                '---------------------------------------------
                'Limpiar la estructura Global de la Info del Sistema
                InfoSistema.LoginName = "Ninguno"
                InfoSistema.UsrName = ""
                'InfoSistema.PeriodoID = 0
                'InfoSistema.FechaInicio = ""
                'InfoSistema.FechaFinal = ""
                'InfoSistema.Vigente = False
                'InfoSistema.CodEstadoPeriodo = ""
                'InfoSistema.DescEstadoPeriodo = ""

            ElseIf PMomento = "LOGEO" Then

                'Poner visible los cuadros que 
                'muestran la info de logeo.
                'Me.grpInfoConexion.Visible = True

                'Cargar la información del Usuario logeado            
                Me.txtUsuario.Text = InfoSistema.LoginName

                'Habilitar cerrar sesión
                'Me.lblCerrarSesion.Enabled = True
                'Me.lblCerrarSesion.Cursor = Cursors.Hand

                'Deshabilitar la opcion Login
                'Me.lblLogin.Enabled = False
                'Me.lblLogin.Cursor = Cursors.Default

            ElseIf PMomento = "LOGEODESARROLLO" Then

                'Poner visible los cuadros que 
                'muestran la info de logeo.
                'Me.grpInfoConexion.Visible = True
                Me.txtUsuario.Text = "DESARROLLO"

                'LImpiar del Periodo
                'Me.TxtAnioPer.Text = ""

                'Deshabilitar la opcion Login
                'Me.lblLogin.Enabled = False
                'Me.lblLogin.Cursor = Cursors.Default

                'Habilitar la entrada a los Subsistemas 
                Me.lblControlSocias.Enabled = True
                Me.lblControlCredito.Enabled = True
                Me.lblContabilidad.Enabled = True
                Me.lblTesoreria.Enabled = True
                Me.lblCatalogoBasico.Enabled = True
                Me.lblSeguridad.Enabled = True
                Me.lblManuales.Enabled = True
                Me.lblSalir.Enabled = True

                Me.lblControlSocias.Cursor = Cursors.Hand
                Me.lblControlCredito.Cursor = Cursors.Hand
                Me.lblContabilidad.Cursor = Cursors.Hand
                Me.lblTesoreria.Cursor = Cursors.Hand
                Me.lblCatalogoBasico.Cursor = Cursors.Hand
                Me.lblSeguridad.Cursor = Cursors.Hand
                Me.lblManuales.Cursor = Cursors.Hand
                Me.lblSalir.Cursor = Cursors.Hand
                '---------------------------------------------            
                'Habilitar las opciones del Toolbar de Abajo                
                'Me.lblCerrarSesion.Enabled = True

                '--------------------------------------------------------
                'Modificado Por:         
                'Fecha de Modificacion:  02 de Febrero del 2007
                'Descripcion:            Habilitar la opcion de Configuracion del Menu.
                '--------------------------------------------------------
                'Me.lblConfiguracion.Enabled = True
                'Me.lblConfiguracion.Cursor = Cursors.Hand

                'If HayPeriodos Then
                '    Me.lblPeriodo.Enabled = True
                '    Me.lblPeriodo.Cursor = Cursors.Hand
                'Else
                '    Me.lblPeriodo.Enabled = False
                '    Me.lblPeriodo.Cursor = Cursors.No
                'End If

                'Me.lblMantPeriodo.Enabled = True
                'Me.lblMantPeriodo.Cursor = Cursors.Hand

                'Me.lblCerrar.Enabled = True
                'Me.lblCerrar.Cursor = Cursors.Hand

            ElseIf PMomento = "SELECTPERIODO" Then
                'Cargar los datos del Periodo seleccionado
                'Me.TxtAnioPer.Text = InfoSistema.AnioPeriodo
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Ing. Azucena Suárez Tijerino
    ' Date			    		:	03 de Agosto del 2006
    ' Procedure name		   	:	SeguridadDeSubsistemas
    ' Description			   	:	Verifica los niveles de Acceso del Usuario logeado a la aplicación.    
    ' Parameters				:
    ' -----------------------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Pantalla Principal 
            'CONFIGURACION
            If Seg.HasPermission("mnuConfiguracion") Then
                'Me.lblConfiguracion.Enabled = True
                'Me.lblConfiguracion.Cursor = Cursors.Hand
            Else
                'Me.lblConfiguracion.Enabled = False
                'Me.lblConfiguracion.Cursor = Cursors.No
            End If

            'SELECCIONAR PERIODO
            If Seg.HasPermission("mnuMantPeriodo") Then
                'Me.lblMantPeriodo.Enabled = True
                'Me.lblMantPeriodo.Cursor = Cursors.Hand
            Else
                'Me.lblMantPeriodo.Enabled = False
                'Me.lblMantPeriodo.Cursor = Cursors.No
            End If

            'Determinar la habilitada de los Módulos según las acciones
            'CONTROL DE SOCIAS
            If Seg.HasPermission("mnuControlSocias") Then
                Me.lblControlSocias.Enabled = True
                Me.lblControlSocias.Cursor = Cursors.Hand
            Else
                Me.lblControlSocias.Enabled = False
                Me.lblControlSocias.Cursor = Cursors.No
            End If

            'CATALOGOS BASICOS
            If Seg.HasPermission("mnuCatalogosBasicos") Then
                Me.lblCatalogoBasico.Enabled = True
                Me.lblCatalogoBasico.Cursor = Cursors.Hand
            Else
                Me.lblCatalogoBasico.Enabled = False
                Me.lblCatalogoBasico.Cursor = Cursors.No
            End If

            'CONTROL CREDITO
            If Seg.HasPermission("mnuControlCredito") Then
                Me.lblControlCredito.Enabled = True
                Me.lblControlCredito.Cursor = Cursors.Hand
            Else
                Me.lblControlCredito.Enabled = False
                Me.lblControlCredito.Cursor = Cursors.No
            End If

            'CONTABILIDAD
            If Seg.HasPermission("mnuContabilidad") Then
                Me.lblContabilidad.Enabled = True
                Me.lblContabilidad.Cursor = Cursors.Hand
            Else
                Me.lblContabilidad.Enabled = False
                Me.lblContabilidad.Cursor = Cursors.No
            End If

            'TESORERIA
            If Seg.HasPermission("mnuTesoreria") Then
                Me.lblTesoreria.Enabled = True
                Me.lblTesoreria.Cursor = Cursors.Hand
            Else
                Me.lblTesoreria.Enabled = False
                Me.lblTesoreria.Cursor = Cursors.No
            End If

            'SEGURIDAD
            If Seg.HasPermission("mnuSeguridad") Then
                Me.lblSeguridad.Enabled = True
                Me.lblSeguridad.Cursor = Cursors.Hand
            Else
                Me.lblSeguridad.Enabled = False
                Me.lblSeguridad.Cursor = Cursors.No
            End If

            'MANUALES
            Me.lblManuales.Enabled = True
            Me.lblManuales.Cursor = Cursors.Hand

            'SALIR
            Me.lblSalir.Enabled = True
            Me.lblSalir.Cursor = Cursors.Hand

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	05/08/2006
    ' Procedure name		   	:   LlamaSeguridad
    ' Description			   	:	Llamar al subistema de Seguridad    
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaSeguridad()

        'Declaracion de Variables 
        Dim ObjFrmSeguridad As FrmSsgPrinSeguridad

        Try
            ObjFrmSeguridad = New FrmSsgPrinSeguridad

            OpenForm(ObjFrmSeguridad)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSeguridad = Nothing
        End Try
    End Sub
    '-----------------------------------------------------------------------------
    '-- Implementado Por:          
    '-- Fecha de Implementacion:    02 de Agosto del 2006
    '-- Descripcion:                Solicitar la contrasena y clave del Usuario
    '-----------------------------------------------------------------------------
    Private Sub lblLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Declaración de Variables 
            Dim ObjFrmLogin As FrmLogin

            ObjFrmLogin = New FrmLogin

            ObjFrmLogin.ShowDialog()
            If ObjFrmLogin.LoginSucessed Then

                'Todos los Permisos
                If InfoSistema.LoginName = "DESARROLLO" Then
                    InfoSistema.LoginName = "DESARROLLO"
                    InfoSistema.UsrName = "DESARROLLO"

                    'Limpiar el Periodo
                    'LimpiarPeriodoUnidadSalud()
                    HabDeshOpciones("LOGEODESARROLLO")
                Else
                    'Habilitar o deshabilitar las opciones según
                    'los permisos que tenga asociado el Usuario.
                    Seguridad()
                    HabDeshOpciones("LOGEO")
                End If

                'Si hay periodos REGISTRADOS o ABIERTO
                '                If HayPeriodos Then
                'REPETIR:
                '                    ObjFrmPeriodo.ShowDialog()
                '                    If ObjFrmPeriodo.PeriodoSucessed = False Then
                '                        GoTo REPETIR
                '                    End If
                '                    HabDeshOpciones("SELECTPERIODO")

                '                    'Cargar la Unidad de Salud
                '                    'CargarUnidadSaludLocal()
                '                    'Me.txtCodigoUnidad.Text = InfoSistema.CodigoUnidadLocal
                '                    'Me.txtUnidadSalud.Text = InfoSistema.UnidadSaludLocal
                '                End If
            Else
                'Si canceló y no habia ningun usuario Logeado
                If UCase(Trim(InfoSistema.LoginName)) = "Ninguno" Or Trim(Me.txtUsuario.Text) = "" Then
                    HabDeshOpciones("CARGAR")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    Private Sub lblCerrarSesion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            'Confirmar con el usuario si en 
            'realidad desea cerrar la sesión
            If MsgBox("¿Está seguro de cerrar la sesión actual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                'Limpiar las variables de la Estructura
                InfoSistema.LoginName = ""
                InfoSistema.UsrName = ""
                '---------------------------------------
                HabDeshOpciones("CARGAR")

                'Limpiar el Periodo
                'LimpiarPeriodoUnidadSalud()
                '----------------------------------------
                CloseForm(Me.Name)
                '----------------------------------------
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '-------------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	05/08/2006
    ' Procedure name		   	:	lblPeriodo_Click
    ' Description			   	:	Llamar al Período
    ' -----------------------------------------------------------------------------------------
    'Private Sub lblPeriodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    'Declaracion de Variables 
    '    Dim ObjFrmPeriodo As FrmPeriodo

    '    Try
    '        ObjFrmPeriodo = New FrmPeriodo

    '        'Para cambiar de Periodo es necesario que esté logeado
    '        If Trim(InfoSistema.LoginName).Length = 0 Or InfoSistema.LoginName = "Ninguno" Then
    '            MsgBox("Debe Logearse antes de seleccionar un Período.", MsgBoxStyle.Critical, NombreSistema)
    '            Exit Sub
    '        End If
    '        ObjFrmPeriodo.ShowDialog()
    '        If ObjFrmPeriodo.PeriodoSucessed Then
    '            'Me.TxtAnioPer.Text = InfoSistema.AnioPeriodo
    '            CargarUnidadSaludLocal()
    '            'Me.txtCodigoUnidad.Text = InfoSistema.CodigoUnidadLocal
    '            'Me.txtUnidadSalud.Text = InfoSistema.UnidadSaludLocal
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjFrmPeriodo = Nothing
    '    End Try
    'End Sub
    Private Sub lblCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Private Sub lblMantPeriodo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    'Declaracion de Variables 
    '    Dim ObjFrmPrinPeriodo As FrmSprPrinPeriodoPresup
    '    '----------------------------------------------
    '    Try

    '        ObjFrmPrinPeriodo = New FrmSprPrinPeriodoPresup
    '        '-- Poner el cursor en un estado de ocupado                   
    '        ObjFrmPrinPeriodo.WindowState = FormWindowState.Normal
    '        ObjFrmPrinPeriodo.StartPosition = FormStartPosition.CenterScreen
    '        ObjFrmPrinPeriodo.ShowDialog()

    '        'Si ingreso un Periodo Nuevo            
    '        If ObjFrmPrinPeriodo.IngresoPeriodo Then
    '            HayPeriodos = True
    '            'Me.lblPeriodo.Enabled = True
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjFrmPrinPeriodo = Nothing
    '    End Try
    'End Sub
#Region "Opciones Menu Principal"

    'Control Socias
    Private Sub lblControlSocias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblControlSocias.Click
        Try
            LlamaControlSocias()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Control de Credito
    Private Sub lblControlCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblControlCredito.Click
        Try
            LlamaControlCredito()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Contabilidad
    Private Sub lblContabilidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblContabilidad.Click
        Try
            LlamaContabilidad()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Compras
    Private Sub lblReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblTesoreria.Click
        Try
            LLamaTesoreria()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Catalogo Basico
    Private Sub lblCatalogoBasico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCatalogoBasico.Click
        Try
            LLamaCatalogoBasico()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Seguridad
    Private Sub lblSeguridad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSeguridad.Click
        Try
            LlamaSeguridad()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Manuales
    Private Sub lblManuales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblManuales.Click
        Try
            LlamaManuales()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Manuales
    Private Sub lblSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaManuales()

        'Declaracion de Variables 
        Dim ObjFrmManuales As FrmPrinManuales

        Try
            ObjFrmManuales = New FrmPrinManuales

            OpenForm(ObjFrmManuales)
            'MsgBox("En Construcción", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmManuales = Nothing
        End Try
    End Sub
#End Region

    Private Sub lblConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Declaracion de Variables 
        'Dim objFrmConfiguracion As frmConfiguracion
        ''----------------------------------------------
        'Try

        '    objFrmConfiguracion = New frmConfiguracion
        '    '-- Poner el cursor en un estado de ocupado                   
        '    objFrmConfiguracion.WindowState = FormWindowState.Normal
        '    objFrmConfiguracion.StartPosition = FormStartPosition.CenterScreen
        '    objFrmConfiguracion.ShowDialog()

        'Catch ex As Exception
        '    Control_Error(ex)
        'Finally
        '    objFrmConfiguracion = Nothing
        'End Try
    End Sub

    Private Sub picCuentaUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCuentaUsuario.Click
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            strSQL = " SELECT nSteCajaID " & _
                     " FROM SttProcesarParametroES "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                If XdtDatos.ValueField("nSteCajaID") <> 0 Then
                    Exit Sub
                End If
            End If

            If InfoSistema.IDCuenta > 0 Then
                LlamaModificaUsuario()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    '--------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    24 de Julio del 2006
    '-- Descripcion:                Llama al formulario de edición de datos 
    '--                             del Usuario seleccionado.
    '------------------------------------------------------------------------
    Private Sub LlamaModificaUsuario()
        'Declaracion de Variables 
        'Dim KeyNodo As String
        'Dim Nodos() As TreeNode
        Dim ObjFrmEditUsuario As FrmSsgEditCuenta


        Try
            ObjFrmEditUsuario = New FrmSsgEditCuenta
            'KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditUsuario.ModoFrm = "UPD"
            '------------------------------------------
            'SI el modificar es en el ARBOL


            ObjFrmEditUsuario.IdUsuario = InfoSistema.IDCuenta             'CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            ObjFrmEditUsuario.sTipoLlamado = "PRINCIPAL"
            ObjFrmEditUsuario.ShowDialog()
            'If ObjFrmEditUsuario.AccionUsuario = FrmSsgEditCuenta.AccionBoton.BotonAceptar Then
            '    Me.treeSeguridad.SelectedNode.Text = ObjFrmEditUsuario.NombreCuenta
            '    Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
            '    Me.treeSeguridad.SelectedNode = Nodos(0)
            '    Me.treeSeguridad.SelectedNode.Parent.Expand()
            'End If
        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditUsuario = Nothing
            'Nodos = Nothing
        End Try
    End Sub

    '<System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    'Private Sub BackgroundWorkerLoad_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerLoad.DoWork
    '    Dim frmView As New frmCRVisorReporte
    '    frmView.Formulas("Usuario") = "'BLANK'"
    '    frmView.NombreReporte = "RepStbLoadBlank.rpt"
    '    frmView.Size = New Size(0, 0)
    '    frmView.StartPosition = FormStartPosition.Manual
    '    frmView.Location = New Point(Screen.PrimaryScreen.Bounds.Height + 300, Screen.PrimaryScreen.Bounds.Width + 300)
    '    frmView.MaximizeBox = False
    '    frmView.MinimizeBox = False
    '    frmView.ControlBox = False
    '    frmView.ShowInTaskbar = False
    '    frmView.ShowIcon = False
    '    frmView.Show()
    '    System.Threading.Thread.Sleep(1500)
    '    frmView.Refresh()
    '    System.Threading.Thread.Sleep(1500)
    '    frmView.Close()
    '    frmView.Dispose()
    '    frmView = Nothing
    'End Sub


End Class