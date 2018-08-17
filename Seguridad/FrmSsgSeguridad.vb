
Public Class FrmSsgSeguridad
    'Declaración de Clases -------------------------------
    Dim ObjSegAplicaciones As BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
    Dim ObjSegUsuarios As BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable
    Dim ObjSegModulos As BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable
    Dim ObjSegServUsuarios As BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable
    Dim ObjSegRoles As BOSistema.Win.SsgEntSeguridad.SsgRolDataTable
    Dim ObjSegAcciones As BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable
    Dim ObjAcciones As BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable
    Dim XdsRolAccion As BOSistema.Win.XDataSet.xDataTable
    Dim XdsCuentaRol As BOSistema.Win.XDataSet.xDataTable
    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3

    Private Sub FrmSsgSeguridad_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjSegAplicaciones = Nothing
            ObjSegUsuarios = Nothing
            ObjSegModulos = Nothing
            ObjSegServUsuarios = Nothing
            ObjSegRoles = Nothing
            ObjSegAcciones = Nothing
            ObjAcciones = Nothing
            ObjReporte = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '-----------------------------------------------------
    Private Sub FrmSeguridad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI

            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Oro")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            LlenaArbolSeguridad()

            If Me.treeSeguridad.Nodes.Count > 0 Then
                Me.treeSeguridad.Nodes(0).Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub InicializaVariables()
        Try
            'Instanciando las clases
            ObjSegAplicaciones = New BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
            ObjSegUsuarios = New BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable
            ObjSegModulos = New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable
            ObjSegServUsuarios = New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable
            ObjSegRoles = New BOSistema.Win.SsgEntSeguridad.SsgRolDataTable
            ObjSegAcciones = New BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable
            ObjAcciones = New BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable
            XdsRolAccion = New BOSistema.Win.XDataSet.xDataTable("SsgRolAccion")
            XdsCuentaRol = New BOSistema.Win.XDataSet.xDataTable

            Me.grdDetallePadre.Splits(0).Locked = True

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCerrar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    17 de Julio del 2006
    '-- Descripcion:                Llenar el arbol de Seguridad con todos sus niveles: Usuarios, Aplicaciones
    '--                             Modulos, Roles, Servicios de Usuario y Acciones.
    '-----------------------------------------------------------------------------
    Private Sub LlenaArbolSeguridad()
        Dim XdtAccionRol As BOSistema.Win.XDataSet.xDataTable
        Dim XdtCuentaRol As BOSistema.Win.XDataSet.xDataTable
        Try
            Dim i As Integer
            Dim j As Integer
            Dim k As Integer
            Dim l As Integer
            Dim m As Integer
            Dim n As Integer
            Dim u As Integer
            Dim Key As Long
            Dim Strsql As String

            '-- Inicializar Variables 
            XdtAccionRol = New BOSistema.Win.XDataSet.xDataTable
            xdtcuentarol = New BOSistema.Win.XDataSet.xDataTable
            i = 0
            j = 0
            k = 0
            l = 0
            m = 0
            n = 0
            u = 0
            Key = 0
            Strsql = ""
            '-- Inicializar el arbol
            Me.treeSeguridad.BeginUpdate()
            Me.treeSeguridad.Nodes.Clear()
            Me.treeSeguridad.HideSelection = False

            '-- Creando el nodo raíz del árbol
            Me.treeSeguridad.Nodes.Add(New TreeNode("Seguridad"))
            Me.treeSeguridad.Nodes(0).Name = "Seguridad"
            Me.treeSeguridad.Nodes(0).ImageIndex = 0
            Me.treeSeguridad.Nodes(0).SelectedImageIndex = 0
            Me.treeSeguridad.Nodes(0).Tag = "NR"                    'Nodo Raiz
            Key = Key + 1

            '-- Creando los hijos del Primer nivel del árbol
            Me.treeSeguridad.Nodes(0).Nodes.Add(New TreeNode("Usuarios"))
            Me.treeSeguridad.Nodes(0).Nodes(0).Name = Key
            Me.treeSeguridad.Nodes(0).Nodes(0).ImageIndex = 1
            Me.treeSeguridad.Nodes(0).Nodes(0).SelectedImageIndex = 1
            Me.treeSeguridad.Nodes(0).Nodes(0).Tag = "NU"           'Nodo Usuarios
            Key = Key + 1

            '-- USUARIOS: Crear los hijos del Nodo Usuarios
            ObjSegUsuarios.OrderBy = "Login Asc"
            ObjSegUsuarios.Retrieve()
            If ObjSegUsuarios.Count > 0 Then
                For i = 0 To ObjSegUsuarios.Count - 1
                    Me.treeSeguridad.Nodes(0).Nodes(0).Nodes.Add(New TreeNode(ObjSegUsuarios.Itemn(i).Login))
                    Me.treeSeguridad.Nodes(0).Nodes(0).Nodes(i).Name = Key
                    Me.treeSeguridad.Nodes(0).Nodes(0).Nodes(i).Tag = "NUH" & ObjSegUsuarios.Itemn(i).SsgCuentaID
                    Me.treeSeguridad.Nodes(0).Nodes(0).Nodes(i).ImageIndex = 2
                    Me.treeSeguridad.Nodes(0).Nodes(0).Nodes(i).SelectedImageIndex = 2
                    Key = Key + 1
                Next
            End If

            Me.treeSeguridad.Nodes(0).Nodes.Add(New TreeNode("Aplicaciones"))
            Me.treeSeguridad.Nodes(0).Nodes(1).Name = Key
            Me.treeSeguridad.Nodes(0).Nodes(1).ImageIndex = 3
            Me.treeSeguridad.Nodes(0).Nodes(1).SelectedImageIndex = 3
            Me.treeSeguridad.Nodes(0).Nodes(1).Tag = "NA"           'Nodo Aplicaciones
            Key = Key + 1


            '-- APLICACIONES: Crear los hijos del Nodo Aplicaciones
            ObjSegAplicaciones.OrderBy = "Nombre Asc"
            ObjSegAplicaciones.Retrieve()
            If ObjSegAplicaciones.Count > 0 Then
                For i = 0 To ObjSegAplicaciones.Count - 1
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes.Add(New TreeNode(ObjSegAplicaciones.Itemn(i).Nombre))
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Name = Key
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Tag = "NAH" & ObjSegAplicaciones.Itemn(i).SsgAplicacionID
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).ImageIndex = 4
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).SelectedImageIndex = 4
                    Key = Key + 1

                    '-- Para cada subsistema crear 2 carpetas: La primera hace referencia
                    '-- a los módulos de ese subsistema y la otra a los Roles.
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes.Add(New TreeNode("Módulos"))
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Name = Key
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Tag = "NMP" & ObjSegAplicaciones.Itemn(i).SsgAplicacionID
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).ImageIndex = 5
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).SelectedImageIndex = 5
                    Key = Key + 1

                    '-- MODULO: Buscar los Hijos del módulo de aplicación creado.
                    ObjSegModulos.Filter = "ObjAplicacionID = " & ObjSegAplicaciones.Itemn(i).SsgAplicacionID
                    ObjSegModulos.OrderBy = "Nombre Asc"

                    ObjSegModulos.Retrieve()
                    If ObjSegModulos.Count > 0 Then
                        For j = 0 To ObjSegModulos.Count - 1
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes.Add(New TreeNode(ObjSegModulos.Itemn(j).Nombre))
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Name = Key
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Tag = "NMH" & ObjSegModulos.Itemn(j).SsgModuloID
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).ImageIndex = 6
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).SelectedImageIndex = 6
                            Key = Key + 1

                            '-- Buscar los servicios de Usuario 
                            '-- asociados al módulo seleccionado.
                            ObjSegServUsuarios.Filter = "ObjModuloID = " & ObjSegModulos.Itemn(j).SsgModuloID
                            ObjSegServUsuarios.OrderBy = "Nombre ASC"

                            ObjSegServUsuarios.Retrieve()
                            If ObjSegServUsuarios.Count > 0 Then
                                For k = 0 To ObjSegServUsuarios.Count - 1
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes.Add(New TreeNode(ObjSegServUsuarios.Itemn(k).Nombre))
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Name = Key
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Tag = "NSH" & ObjSegServUsuarios.Itemn(k).SsgServicioUsuarioID
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).ImageIndex = 7
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).SelectedImageIndex = 7
                                    Key = Key + 1

                                    'Para cada servicio de Usuario crear un Nodo de Acciones
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes.Add(New TreeNode("Acciones"))
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).Name = Key
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).Tag = "NEP" & ObjSegServUsuarios.Itemn(k).SsgServicioUsuarioID
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).ImageIndex = 5
                                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).SelectedImageIndex = 5
                                    Key = Key + 1

                                    '-- Cargar las Acciones del Servicio de Usuario actual.
                                    ObjSegAcciones.Filter = "ObjServicioUsuarioID = " & ObjSegServUsuarios.Itemn(k).SsgServicioUsuarioID
                                    ObjSegAcciones.OrderBy = "Nombre ASC"
                                    ObjSegAcciones.Retrieve()
                                    For l = 0 To ObjSegAcciones.Count - 1
                                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).Nodes.Add(New TreeNode(ObjSegAcciones.Itemn(l).Nombre))
                                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).Nodes(l).Name = Key
                                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).Nodes(l).Tag = "NEH" & ObjSegAcciones.Itemn(l).SsgAccionID
                                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).Nodes(l).ImageIndex = 8
                                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(0).Nodes(j).Nodes(k).Nodes(0).Nodes(l).SelectedImageIndex = 8
                                        Key = Key + 1
                                    Next l
                                Next k
                            End If
                        Next j
                    End If
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes.Add(New TreeNode("Roles"))
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Name = Key
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Tag = "NRP" & ObjSegAplicaciones.Itemn(i).SsgAplicacionID
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).ImageIndex = 5
                    Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).SelectedImageIndex = 5
                    Key = Key + 1

                    'Cargar los Roles de la Aplicación seleccionada.
                    ObjSegRoles.Filter = "ObjAplicacionID = " & ObjSegAplicaciones.Itemn(i).SsgAplicacionID & " And nRolEspecial = 0"
                    ObjSegRoles.OrderBy = "Nombre ASC"
                    ObjSegRoles.Retrieve()
                    For m = 0 To ObjSegRoles.Count - 1
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes.Add(New TreeNode(ObjSegRoles.Itemn(m).Nombre))
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Name = Key
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Tag = "NRH" & ObjSegRoles.Itemn(m).SsgRolID
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).ImageIndex = 9
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).SelectedImageIndex = 9
                        Key = Key + 1

                        'Crear el Nodo HIJO: ACCIONES AUTORIZADAS
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes.Add(New TreeNode("Acciones Autorizadas"))
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).Name = Key
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).Tag = "NTP" & ObjSegRoles.Itemn(m).SsgRolID
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).ImageIndex = 5
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).SelectedImageIndex = 5
                        Key = Key + 1

                        'Buscar los Hijos de ACCIONES 
                        'AUTORIZADAS para el ROL actual.
                        Strsql = " Select B.Nombre As NombreAccion, A.ObjRolID, A.ObjAccionID, A.SsgRolAccionID " & _
                                 " From   SsgRolAccion A, " & _
                                 "        SsgAccion    B " & _
                                 " Where  A.ObjAccionID = B.SsgAccionID And " & _
                                 "        A.ObjRolID    = " & ObjSegRoles.Itemn(m).SsgRolID.ToString() + "" & _
                                 " Order By B.Nombre ASC"
                        XdtAccionRol.ExecuteSql(Strsql)
                        If XdtAccionRol.Count > 0 Then
                            For n = 0 To XdtAccionRol.Count - 1
                                Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).Nodes.Add(New TreeNode(XdtAccionRol.Table.Rows(n).Item("NombreAccion")))
                                Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).Nodes(n).Name = Key
                                Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).Nodes(n).Tag = "NTH" & XdtAccionRol.Table.Rows(n).Item("SsgRolAccionID")
                                Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).Nodes(n).ImageIndex = 8
                                Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(0).Nodes(n).SelectedImageIndex = 8
                                Key = Key + 1
                            Next n
                        End If

                        'Crear el Nodo HIJO: USUARIOS QUE JUEGAN ESE ROL
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes.Add(New TreeNode("Usuarios que juegan el Rol"))
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).Name = Key
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).Tag = "NUP" & ObjSegRoles.Itemn(m).SsgRolID
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).ImageIndex = 5
                        Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).SelectedImageIndex = 5
                        Key = Key + 1

                        'Buscar los usuarios que juegan ese Rol
                        Strsql = " Select A.Login As NombreUsuario, B.SsgCuentaRolID " & _
                                 " From   SsgCuenta     A, " & _
                                 "        SsgCuentaRol  B  " & _
                                 " Where  A.SsgCuentaID = B.ObjCuentaID And " & _
                                 "        B.ObjRolID    = " & ObjSegRoles.Itemn(m).SsgRolID.ToString() + "" & _
                                 " Order By A.Login ASC"
                        XdtCuentaRol.ExecuteSql(Strsql)
                        For u = 0 To XdtCuentaRol.Count - 1
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).Nodes.Add(New TreeNode(XdtCuentaRol.Table.Rows(u).Item("NombreUsuario")))
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).Nodes(u).Name = Key
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).Nodes(u).Tag = "NWH" & XdtCuentaRol.Table.Rows(u).Item("SsgCuentaRolID")
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).Nodes(u).ImageIndex = 2
                            Me.treeSeguridad.Nodes(0).Nodes(1).Nodes(i).Nodes(1).Nodes(m).Nodes(1).Nodes(u).SelectedImageIndex = 2
                            Key = Key + 1
                        Next u
                    Next m
                Next i
            End If
            '---------------------------------------------------            
            Me.treeSeguridad.EndUpdate()

        Catch ex As Exception
            Control_Error(ex)

        Finally
            XdtAccionRol = Nothing
            XdtCuentaRol = Nothing
        End Try
    End Sub
    Private Sub toolAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregar.Click
        Try
            '-- Declaracion de Variables 
            Dim vNivel As String

            vNivel = ""
            If Me.treeSeguridad.SelectedNode Is Nothing Then
                Exit Sub
            End If
            vNivel = RTrim(LTrim(Mid(Me.treeSeguridad.SelectedNode.Tag, 1, 3)))
            Seg.RefreshPermissions()
            '----------------------------
            If vNivel = "NU" Then           'Nivel Usuario

                If Seg.HasPermission("AgregarCuentaUsuario") Then
                    LlamaAgregaCuenta()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para agregar un nuevo usuario.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NA" Then       'Nivel Aplicacion

                If Seg.HasPermission("AgregarAplicacion") Then
                    LlamaAgregaAplicacion()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para agregar una nueva aplicación.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NMP" Then      'Nivel Modulo

                If Seg.HasPermission("AgregarModulo") Then
                    LlamaAgregaModulo()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para agregar un nuevo módulo.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NMH" Then      'Nivel Servicios de Usuario

                If Seg.HasPermission("AgregarServUsuario") Then
                    LlamaAgregaServiciosUsuario()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para agregar un nuevo Servicio de Usuario.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NEP" Then      'Acciones del Servicio de Usuario

                If Seg.HasPermission("AgregarAccion") Then
                    LlamaAgregaAccion()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para agregar una nueva Acción.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NRP" Then

                If Seg.HasPermission("AgregarRol") Then
                    LlamaAgregaRol()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para agregar un nuevo Rol.", MsgBoxStyle.Critical, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub toolModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModificar.Click
        Try
            '-- Declaracion de Variables 
            Dim vNivel As String
            vNivel = ""

            'Verificar si hay un Nodo seleccionado
            If Me.treeSeguridad.SelectedNode Is Nothing Then
                Exit Sub
            End If

            vNivel = RTrim(LTrim(Mid(Me.treeSeguridad.SelectedNode.Tag, 1, 3)))
            Seg.RefreshPermissions()

            If vNivel = "NUH" Then
                '-----------------
                If Seg.HasPermission("EditarCuentaUsuario") Then
                    LlamaModificaUsuario()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                            "para modificar los datos del Usuario seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NAH" Then

                If Seg.HasPermission("EditarAplicacion") Then
                    LlamaModificaAplicacion()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para modificar los datos de una aplicación.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NMH" Then

                If Seg.HasPermission("EditarModulo") Then
                    LlamaModificaModulo()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para modificar los datos del módulo seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NSH" Then

                If Seg.HasPermission("EditarServUsuario") Then
                    LlamaModificaServUsuario()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos para " & Chr(10) & _
                           "modificar los datos del Servicio de Usuario seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NEH" Then

                If Seg.HasPermission("EditarAccion") Then
                    LlamaModificaAccion()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos para " & Chr(10) & _
                           "modificar la acción del Servicio de Usuario seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NRH" Then

                If Seg.HasPermission("EditarRol") Then
                    LlamaModificaRol()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para modificar el Rol seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub toolEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEliminar.Click
        Try
            '-- Declaracion de Variables 
            Dim vNivel As String
            vNivel = ""

            'Verificar si hay un Nodo seleccionado
            If Me.treeSeguridad.SelectedNode Is Nothing Then
                Exit Sub
            End If
            vNivel = RTrim(LTrim(Mid(Me.treeSeguridad.SelectedNode.Tag, 1, 3)))
            Seg.RefreshPermissions()

            If vNivel = "NUH" Then

                If Seg.HasPermission("EliminarCuentaUsuario") Then
                    If MsgBox("¿Está seguro de eliminar el Usuario seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaUsuario()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene " & Chr(10) & _
                           "permisos una cuenta de Usuario.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NAH" Then

                If Seg.HasPermission("EliminarAplicacion") Then
                    If MsgBox("¿Está seguro de eliminar el nodo de Aplicación seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaAplicacion()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene " & Chr(10) & _
                            "permisos para eliminar una Aplicación.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NMH" Then

                If Seg.HasPermission("EliminarModulo") Then
                    If MsgBox("¿Está seguro de eliminar el módulo seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaModulo()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene " & Chr(10) & _
                            "permisos para eliminar módulos.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NSH" Then

                If Seg.HasPermission("EliminarServUsuario") Then
                    If MsgBox("¿Está seguro de eliminar el Servicio de Usuario seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaServUsuario()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene " & Chr(10) & _
                           "permisos para eliminar servicios de Usuario.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NEH" Then

                If Seg.HasPermission("EliminarAccion") Then
                    If MsgBox("¿Está seguro de eliminar la acción seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaAccion()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene" & Chr(10) & _
                           "permiso para eliminar acciones.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NRH" Then

                If Seg.HasPermission("EliminarRol") Then
                    If MsgBox("¿Está seguro de eliminar el Rol seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaRol()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene" & Chr(10) & _
                           "permisos para eliminar roles.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NTH" Then

                If Seg.HasPermission("EliminarAccion") Then
                    If MsgBox("¿Está seguro de eliminar la Acción del Rol seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaRolAccion()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene" & Chr(10) & _
                           "permisos para eliminar acciones.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NWH" Then

                If Seg.HasPermission("EliminarRol") Then
                    If MsgBox("¿Está seguro de quitar este Rol al usuario seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                        LlamaEliminaCuentaRol()
                    End If
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene" & Chr(10) & _
                           "permisos para eliminar Roles.", MsgBoxStyle.Critical, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub toolRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRefrescar.Click
        Try
            LlenaArbolSeguridad()
            If Me.treeSeguridad.Nodes.Count > 0 Then
                Me.treeSeguridad.Nodes(0).Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '---------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    20 de Julio del 2006
    '-- Descripcion:                Llama agrega Cuenta de Usuario
    '---------------------------------------------------------------------------
    Private Sub LlamaAgregaCuenta()
        Dim Nodos() As TreeNode
        Dim ObjFrmEditCuenta As New FrmSsgEditCuenta

        Try
            'Delcaración de Variables 
            Dim KeyNodo As String


            'ObjFrmEditCuenta = New FrmSsgEditCuenta

            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditCuenta.ModoFrm = "ADD"
            ObjFrmEditCuenta.ShowDialog()

            If ObjFrmEditCuenta.AccionUsuario = FrmSsgEditCuenta.AccionBoton.BotonAceptar Then
                LlenaArbolSeguridad()
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            Nodos = Nothing

            ObjFrmEditCuenta.Close()
            ObjFrmEditCuenta = Nothing
        End Try
    End Sub
    '---------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    17 de Julio del 2006
    '-- Descripcion:                Llama al formulario que permite el registro
    '--                             de una nueva Aplicación.
    '---------------------------------------------------------------------------
    Private Sub LlamaAgregaAplicacion()
        Dim Nodos() As TreeNode
        Dim ObjFrmEditAplicacion As FrmSsgEditAplicacion

        Try
            'Declaracion de Variables 

            Dim KeyNodo As String


            ObjFrmEditAplicacion = New FrmSsgEditAplicacion
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditAplicacion.ModoFrm = "ADD"
            ObjFrmEditAplicacion.ShowDialog()

            If ObjFrmEditAplicacion.AccionUsuario = FrmSsgEditAplicacion.AccionBoton.BotonAceptar Then
                LlenaArbolSeguridad()
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            Nodos = Nothing
            ObjFrmEditAplicacion = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripcion:                Llama al formulario que permite el registro
    '--                             de un nuevo Módulo dentro de una aplicacion.
    '------------------------------------------------------------------------
    Private Sub LlamaAgregaModulo()
        'Declaración de Variables 

        Dim KeyNodo As String
        Dim Nodos() As TreeNode
        Dim ObjFrmEditModulo As FrmSsgEditModulo
        Try
            ObjFrmEditModulo = New FrmSsgEditModulo
            ObjFrmEditModulo.ModoFrm = "ADD"
            ObjFrmEditModulo.IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditModulo.ShowDialog()

            If ObjFrmEditModulo.AccionUsuario = FrmSsgEditModulo.AccionBoton.BotonAceptar Then
                LlenaArbolSeguridad()
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditModulo = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripcion:                Llama al formulario que permite el registro
    '--                             de un nuevo Servicio de Usuario dentro de una 
    '-                              Aplicación.
    '------------------------------------------------------------------------
    Private Sub LlamaAgregaServiciosUsuario()
        'Declaracion de Variables 
        Dim ObjFrmEditServUsuarios As FrmSsgEditServUsuarios
        Dim KeyNodo As String
        Dim Nodos() As TreeNode

        Try
            ObjFrmEditServUsuarios = New FrmSsgEditServUsuarios
            ObjFrmEditServUsuarios.ModoFrm = "ADD"
            ObjFrmEditServUsuarios.IdModulo = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditServUsuarios.ShowDialog()

            If ObjFrmEditServUsuarios.AccionUsuario = FrmSsgEditServUsuarios.AccionBoton.BotonAceptar Then
                LlenaArbolSeguridad()
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            Nodos = Nothing
            ObjFrmEditServUsuarios = Nothing

        End Try
    End Sub
    '------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    20 de Julio del 2006
    '-- Descripcion:                Llama al formulario que permite el registro
    '--                             de una nueva Accion.
    '------------------------------------------------------------------------
    Private Sub LlamaAgregaAccion()
        'Declaración de Variables 
        Dim ObjFrmEditAccion As FrmSsgEditAccion
        Dim KeyNodo As String
        Dim Nodos() As TreeNode
        Try
            ObjFrmEditAccion = New FrmSsgEditAccion

            ObjFrmEditAccion.ModoFrm = "ADD"
            ObjFrmEditAccion.IdServUsuario = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditAccion.ShowDialog()

            'Si aceptó agregar el Nodo en el árbol.
            If ObjFrmEditAccion.AccionUsuario = FrmSsgEditAccion.AccionBoton.BotonAceptar Then
                LlenaArbolSeguridad()
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Expand()
            End If
        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditAccion = Nothing
            Nodos = Nothing

        End Try
    End Sub
    '---------------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    20 de Julio del 2006
    '-- Descripcion:                Llamar al formulario que permite registrar los 
    '--                             datos de un nuevo Rol y las acciones asociadas al Rol.
    '---------------------------------------------------------------------------------------
    Private Sub LlamaAgregaRol()
        'Declaracion de Variables 
        Dim ObjFrmEditRol As FrmSsgEditRol
        Dim KeyNodo As String
        Dim Nodos() As TreeNode

        Try
            ObjFrmEditRol = New FrmSsgEditRol
            ObjFrmEditRol.ModoFrm = "ADD"
            ObjFrmEditRol.IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditRol.ShowDialog()

            If ObjFrmEditRol.AccionUsuario = FrmSsgEditRol.AccionBoton.BotonAceptar Then
                LlenaArbolSeguridad()
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditRol = Nothing
            Nodos = Nothing

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
        Dim KeyNodo As String
        Dim Nodos() As TreeNode
        Dim ObjFrmEditUsuario As New FrmSsgEditCuenta


        Try
            'ObjFrmEditUsuario = New FrmSsgEditCuenta
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditUsuario.ModoFrm = "UPD"
            '------------------------------------------
            'SI el modificar es en el ARBOL

            ObjFrmEditUsuario.IdUsuario = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            ObjFrmEditUsuario.ShowDialog()
            If ObjFrmEditUsuario.AccionUsuario = FrmSsgEditCuenta.AccionBoton.BotonAceptar Then
                Me.treeSeguridad.SelectedNode.Text = ObjFrmEditUsuario.NombreCuenta
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Parent.Expand()
            End If
        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditUsuario.Close()
            ObjFrmEditUsuario = Nothing

            Nodos = Nothing
        End Try
    End Sub
    '--------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripcion:                Llama al formulario de edicion de datos 
    '--                             del Modulo seleccionado que pertenece a una Aplicacion.
    '------------------------------------------------------------------------
    Private Sub LlamaModificaModulo()
        Dim ObjFrmEditModulo As New FrmSsgEditModulo
        Dim KeyNodo As String
        Dim Nodos() As TreeNode

        Try
            'ObjFrmEditModulo = New FrmSsgEditModulo

            ObjFrmEditModulo.ModoFrm = "UPD"
            ObjFrmEditModulo.IdModulo = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            ObjFrmEditModulo.IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Parent.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Parent.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditModulo.ShowDialog()
            If ObjFrmEditModulo.AccionUsuario = FrmSsgEditModulo.AccionBoton.BotonAceptar Then
                Me.treeSeguridad.SelectedNode.Text = ObjFrmEditModulo.NombreModulo
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Parent.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditModulo.Close()
            ObjFrmEditModulo = Nothing

            Nodos = Nothing
        End Try
    End Sub
    '---------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    17 de Julio del 2006
    '-- Descripcion:                Llama al formulario de edicion de datos 
    '--                             del nodo de aplicacion seleccionado.
    '---------------------------------------------------------------------------
    Private Sub LlamaModificaAplicacion()
        'Declaracion de Variables 
        Dim ObjFrmEditAplicacion As New FrmSsgEditAplicacion
        Dim KeyNodo As String
        Dim Nodos() As TreeNode
        '------------------------------------------------
        Try

            'ObjFrmEditAplicacion = New FrmSsgEditAplicacion
            If Me.treeSeguridad.SelectedNode Is Nothing Then
                Exit Sub
            End If
            ObjFrmEditAplicacion.ModoFrm = "UPD"
            ObjFrmEditAplicacion.IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditAplicacion.ShowDialog()
            If ObjFrmEditAplicacion.AccionUsuario = FrmSsgEditAplicacion.AccionBoton.BotonAceptar Then
                Me.treeSeguridad.SelectedNode.Text = ObjFrmEditAplicacion.NombreAplicacion
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Parent.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            Nodos = Nothing

            ObjFrmEditAplicacion.Close()
            ObjFrmEditAplicacion = Nothing
        End Try
    End Sub
    '-------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    17 de Julio del 2006
    '-- Descripcion:                Llama al formulario de edición de datos 
    '--                             del nodo de Servicio de Usuario seleccionado.
    '------------------------------------------------------------------------------
    Private Sub LlamaModificaServUsuario()
        'Declaración de Variables 
        Dim ObjFrmEditServUsuario As New FrmSsgEditServUsuarios
        Dim KeyNodo As String
        Dim Nodos() As TreeNode

        Try

            'ObjFrmEditServUsuario = New FrmSsgEditServUsuarios
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmEditServUsuario.ModoFrm = "UPD"
            ObjFrmEditServUsuario.IdModulo = CLng(Mid(Me.treeSeguridad.SelectedNode.Parent.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Parent.Tag)))
            ObjFrmEditServUsuario.IdServicio = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            ObjFrmEditServUsuario.ShowDialog()

            If ObjFrmEditServUsuario.AccionUsuario = FrmSsgEditServUsuarios.AccionBoton.BotonAceptar Then
                Me.treeSeguridad.SelectedNode.Text = ObjFrmEditServUsuario.NombreServicio
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Parent.Expand()
            End If
        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmEditServUsuario.Close()
            ObjFrmEditServUsuario = Nothing

            Nodos = Nothing
        End Try
    End Sub
    '-------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    20 de Julio del 2006
    '-- Descripcion:                Llama al formulario de edición de datos 
    '--                             de la accion seleccionada en modo EDICION.
    '------------------------------------------------------------------------------
    Private Sub LlamaModificaAccion()
        Dim ObjFrmAccion As New FrmSsgEditAccion
        Dim KeyNodo As String
        Dim Nodos() As TreeNode

        Try
            'ObjFrmAccion = New FrmSsgEditAccion

            'Asignacion de Parametros
            ObjFrmAccion.ModoFrm = "UPD"
            ObjFrmAccion.IdServUsuario = CLng(Mid(Me.treeSeguridad.SelectedNode.Parent.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Parent.Tag)))
            ObjFrmAccion.IdAccion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmAccion.ShowDialog()
            If ObjFrmAccion.AccionUsuario = FrmSsgEditAccion.AccionBoton.BotonAceptar Then
                Me.treeSeguridad.SelectedNode.Text = ObjFrmAccion.NombreAccion
                '-------------------------------------------------
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Parent.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjFrmAccion.Close()
            ObjFrmAccion = Nothing

            Nodos = Nothing
        End Try
    End Sub
    '--------------------------------------------------------------------------
    '--- Implementado Por:             
    '--- Fecha de Implementacion:       20 de Julio del 2006
    '--- Descripcion:                   Llama al formulario Modifica Rol.
    '--------------------------------------------------------------------------
    Private Sub LlamaModificaRol()
        'Declaracion de Variables 
        Dim ObjFrmRol As New FrmSsgEditRol
        Dim KeyNodo As String
        Dim Nodos() As TreeNode

        Try
            'ObjFrmRol = New FrmSsgEditRol

            ObjFrmRol.ModoFrm = "UPD"
            ObjFrmRol.IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Parent.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Parent.Tag)))
            ObjFrmRol.IdRol = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))
            KeyNodo = Me.treeSeguridad.SelectedNode.Name
            ObjFrmRol.ShowDialog()

            If ObjFrmRol.AccionUsuario = FrmSsgEditRol.AccionBoton.BotonAceptar Then
                LlenaArbolSeguridad()
                '  Me.treeSeguridad.SelectedNode.Text = ObjFrmRol.NombreRol
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                Me.treeSeguridad.SelectedNode = Nodos(0)
                Me.treeSeguridad.SelectedNode.Parent.Expand()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Nodos = Nothing

            ObjFrmRol.Close()
            ObjFrmRol = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    17 de Julio del 2006
    '-- Descripcion:                Elimina el registro de aplicacion seleccionado. 
    '--                             Para hacer esto debe validar:
    '--                             1. No tenga detalle de Roles
    '--                             2. No tenga detalle de modulos.
    '------------------------------------------------------------------------
    Private Sub LlamaEliminaAplicacion()

        'Declaracion de Variables 
        Dim IdAplicacion As Long
        Dim ObjAplicacion As BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
        Dim KeyNodo As Long
        Dim Nodos() As TreeNode
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado

        Try

            ObjAplicacion = New BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
            If Me.treeSeguridad.SelectedNode Is Nothing Then
                MsgBox("Debe seleccionar un registro para poder eliminar.", MsgBoxStyle.Critical, NombreSistema)
                GoTo SALIR
            End If

            IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If

            If IdAplicacion > 0 Then
                '-- Eliminar el registro actual
                ObjAplicacion.Filter = "SsgAplicacionID = " & IdAplicacion
                ObjAplicacion.Retrieve()
                If ObjAplicacion.Count > 0 Then

                    ObjAplicacion.DeleteCurrent()
                    'Remuevo el nodo seleccionado
                    Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)

                    'Ubicarlo en el nodo anterior ------------
                    Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                    'Si hay nodos hermanos posicionarlo en el anterior, sino se queda en el papa
                    If Nodos.Length > 0 Then
                        Me.treeSeguridad.SelectedNode = Nodos(0)
                        Me.treeSeguridad.SelectedNode.Parent.Expand()
                    End If
                    '-----------------------------------------
                End If
            End If
SALIR:
            ObjAplicacion = Nothing
            Exit Sub

        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)
        Finally
            ObjAplicacion = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '--------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    25 de Julio del 2006
    '-- Descripción:                Desactivar este rol 
    '---------------------------------------------------------------------
    Private Sub LlamaEliminaCuentaRol()
        'Declaración de Variables 
        Dim IdCuentaRol As Long
        Dim ObjCuentaRol As BOSistema.Win.SsgEntSeguridad.SsgCuentaRolDataTable
        Dim KeyNodo As Long
        Dim Nodos() As TreeNode
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado
        '-------------------------------------------------------------

        Try

            ObjCuentaRol = New BOSistema.Win.SsgEntSeguridad.SsgCuentaRolDataTable
            IdCuentaRol = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If

            ObjCuentaRol.Filter = "SsgCuentaRolID = " & IdCuentaRol
            ObjCuentaRol.Retrieve()
            If ObjCuentaRol.Count > 0 Then

                ObjCuentaRol.DeleteCurrent()
                'Remuevo el nodo seleccionado
                Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)

                'Ubicarlo en el nodo anterior ------------
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                'Si hay nodos hermanos posicionarlo en el anterior, sino se queda en el papa
                If Nodos.Length > 0 Then
                    Me.treeSeguridad.SelectedNode = Nodos(0)
                    Me.treeSeguridad.SelectedNode.Parent.Expand()
                End If
                '-----------------------------------------
            End If
            ObjCuentaRol = Nothing
            Exit Sub
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)

        Finally
            ObjCuentaRol = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '--------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripción:                Eliminar el registro de módulo seleccionado siempre y cuando:
    '--                             1. No tenga servicios de Usuarios asociados.    
    '---------------------------------------------------------------------
    Private Sub LlamaEliminaModulo()

        'Declaracion de Variables ---------------------
        Dim IdModulo As Long
        Dim ObjModulo As BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable
        Dim KeyNodo As Long
        Dim Nodos() As TreeNode
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado
        '----------------------------------------------

        Try

            ObjModulo = New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable
            IdModulo = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If

            If IdModulo <= 0 Then
                GoTo SALIR
            End If

            '-- Eliminar el registro actual
            ObjModulo.Filter = "SsgModuloID = " & IdModulo
            ObjModulo.Retrieve()
            If ObjModulo.Count > 0 Then
                ObjModulo.DeleteCurrent()

                'Remuevo el nodo seleccionado
                Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)

                'Ubicarlo en el nodo anterior 
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                'Si hay nodos hermanos posicionarlo en el anterior, sino se queda en el papa
                If Nodos.Length > 0 Then
                    Me.treeSeguridad.SelectedNode = Nodos(0)
                    Me.treeSeguridad.SelectedNode.Parent.Expand()
                End If
                '-----------------------------------------
            End If
SALIR:
            ObjModulo = Nothing
            Exit Sub
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)

        Finally
            ObjModulo = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '--------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    20 de Julio del 2006
    '-- Descripción:                Elimina la accion seleccionada siempre y cuando
    '--                             no tenga datos asociados.
    '---------------------------------------------------------------------
    Private Sub LlamaEliminaAccion()
        'Declaración de Variables ---------------
        Dim IdAccion As Long
        Dim ObjAccion As BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable
        Dim KeyNodo As Long
        Dim Nodos() As TreeNode
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado

        Try

            'Instanciar las clases             
            ObjAccion = New BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable
            IdAccion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If


            If IdAccion <= 0 Then
                GoTo SALIR
            End If

            'Eliminar la acción seleccionada.
            ObjAccion.Filter = "SsgAccionID = " & IdAccion
            ObjAccion.Retrieve()
            If ObjAccion.Count > 0 Then
                ObjAccion.DeleteCurrent()
                'Remuevo el nodo seleccionado
                Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)


                'Ubicarlo en el nodo anterior 
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                'Si hay nodos hermanos posicionarlo en el anterior, sino se queda en el papa
                If Nodos.Length > 0 Then
                    Me.treeSeguridad.SelectedNode = Nodos(0)
                    Me.treeSeguridad.SelectedNode.Parent.Expand()
                End If
            End If
SALIR:
            ObjAccion = Nothing
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)

        Finally
            ObjAccion = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '--------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    18 de Julio del 2006
    '-- Descripción:                Eliminar el registro de Servicio de Usuario 
    '--                             seleccionado siempre y cuando
    '--                             no tenga Acciones asociadas.
    '---------------------------------------------------------------------
    Private Sub LlamaEliminaServUsuario()
        'Declaracion de Variables ---------------------
        Dim IdServUsuario As Long
        Dim ObjServUsuario As BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable
        Dim KeyNodo As Long
        Dim Nodos() As TreeNode
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado
        '----------------------------------------------

        Try

            ObjServUsuario = New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable
            IdServUsuario = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If

            If IdServUsuario <= 0 Then
                GoTo SALIR
            End If

            '-- Eliminar el registro actual
            ObjServUsuario.Filter = "SsgServicioUsuarioID = " & IdServUsuario
            ObjServUsuario.Retrieve()
            If ObjServUsuario.Count > 0 Then

                ObjServUsuario.DeleteCurrent()

                'Remuevo el nodo seleccionado
                Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)

                'Ubicarlo en el nodo anterior 
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                'Si hay nodos hermanos posicionarlo en el anterior, sino se queda en el papa
                If Nodos.Length > 0 Then
                    Me.treeSeguridad.SelectedNode = Nodos(0)
                    Me.treeSeguridad.SelectedNode.Parent.Expand()
                End If
                '-----------------------------------------
            End If
SALIR:
            ObjServUsuario = Nothing
            Exit Sub
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)

        Finally
            ObjServUsuario = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        20 de Julio del 2006
    '-- Descripcion:                    Elimina el Rol y las acciones definidas para el ROL
    '--                                 seleccionado.
    '--                                 1. Validar que no esté siendo usado por CuentaRol
    '------------------------------------------------------------------------------------
    Private Sub LlamaEliminaRol()

        'Declaracion de Variables ---------------------
        Dim IdRol As Long
        Dim ObjRol As BOSistema.Win.SsgEntSeguridad.SsgRolDataTable
        Dim KeyNodo As Long
        Dim Nodos() As TreeNode
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado

        Try

            ObjRol = New BOSistema.Win.SsgEntSeguridad.SsgRolDataTable
            IdRol = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If

            If IdRol <= 0 Then
                GoTo SALIR
            End If

            'Eliminar el Rol seleccionado
            ObjRol.Filter = "SsgRolID = " & IdRol
            ObjRol.Retrieve()
            If ObjRol.Count > 0 Then

                ObjRol.DeleteCurrent()
                'Remuevo el nodo seleccionado
                Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)

                'Ubicarlo en el nodo anterior 
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)

                'Si hay nodos hermanos posicionarlo en el anterior, 
                'sino se queda en el papa.
                If Nodos.Length > 0 Then
                    Me.treeSeguridad.SelectedNode = Nodos(0)
                    Me.treeSeguridad.SelectedNode.Parent.Expand()
                End If
                '-----------------------------------------
            End If
SALIR:
            ObjRol = Nothing
            Exit Sub
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)
        Finally
            ObjRol = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        18 de Julio del 2006
    '-- Descripcion:                    Eliminar el registro de Rol Acción seleccionado.
    '------------------------------------------------------------------------------------
    Private Sub LlamaEliminaRolAccion()

        'Declaracion de Variables 
        Dim IdRolAccion As Long
        Dim KeyNodo As Long
        Dim Nodos() As TreeNode
        Dim ObjRolAccion As BOSistema.Win.SsgEntSeguridad.SsgRolAccionDataTable
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado
        '--------------------------------------------------------------------

        Try

            ObjRolAccion = New BOSistema.Win.SsgEntSeguridad.SsgRolAccionDataTable
            IdRolAccion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If

            If IdRolAccion <= 0 Then
                GoTo SALIR
            End If

            ObjRolAccion.Filter = "SsgRolAccionID = " & IdRolAccion
            ObjRolAccion.Retrieve()
            If ObjRolAccion.Count > 0 Then

                ObjRolAccion.DeleteCurrent()

                'Remuevo el nodo seleccionado
                Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)

                'Ubicarlo en el nodo anterior 
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)

                'Si hay nodos hermanos posicionarlo en el anterior, 
                'sino se queda en el papa
                If Nodos.Length > 0 Then
                    Me.treeSeguridad.SelectedNode = Nodos(0)
                End If
                ''-----------------------------------------
            End If
SALIR:
            ObjRolAccion = Nothing
            Exit Sub
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)
        Finally
            ObjRolAccion = Nothing
            Nodos = Nothing

        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        24 de Julio del 2006
    '-- Descripcion:                    Elimina al usuario seleccionado.
    '------------------------------------------------------------------------------------
    Private Sub LlamaEliminaUsuario()
        'Declaracion de Variables 
        Dim KeyNodo As String
        Dim Nodos() As TreeNode
        Dim ObjCuentaUsuarioDt As BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable
        Dim IdUsuario As Long
        Dim IndexNodo As Integer 'Esta variable me dara el index de mi nodo seleccionado

        Try

            ObjCuentaUsuarioDt = New BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable
            IdUsuario = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            'Si el papa de mi nodo seleccionado tiene mas hijos
            If Me.treeSeguridad.SelectedNode.Parent.Nodes.Count > 1 Then
                IndexNodo = Me.treeSeguridad.SelectedNode.Parent.Nodes.IndexOf(Me.treeSeguridad.SelectedNode)
                If IndexNodo = 0 Then
                    IndexNodo = 1
                Else
                    IndexNodo = IndexNodo - 1
                End If
                KeyNodo = CLng(Me.treeSeguridad.SelectedNode.Parent.Nodes(IndexNodo).Name)
            Else
                KeyNodo = -1
            End If

            '-------------------------
            ObjCuentaUsuarioDt.Filter = "SsgCuentaID = " & IdUsuario
            ObjCuentaUsuarioDt.Retrieve()
            If ObjCuentaUsuarioDt.Count > 0 Then
                ObjCuentaUsuarioDt.DeleteCurrent()
                'LlenaArbolSeguridad()
                'Remuevo el nodo seleccionado
                Me.treeSeguridad.SelectedNode.Parent.Nodes.Remove(Me.treeSeguridad.SelectedNode)

                'Ubicarse en el Nodo actual
                Nodos = Me.treeSeguridad.Nodes.Find(KeyNodo, True)
                'Si hay nodos hermanos posicionarlo en el anterior, sino se queda en el papa
                If Nodos.Length > 0 Then
                    Me.treeSeguridad.SelectedNode = Nodos(0)
                    Me.treeSeguridad.SelectedNode.Parent.Expand()
                End If

            End If
            '-------------------------
        Catch ex As Exception
            MsgBox("No se pudo eliminar el registro porque tiene relaciones con otras tablas!", MsgBoxStyle.Critical, NombreSistema)
        Finally
            ObjCuentaUsuarioDt = Nothing
            Nodos = Nothing
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        18 de Julio del 2006
    '-- Descripcion:                    Cargar los Usuarios del Nodo Usuarios
    '------------------------------------------------------------------------------------
    Private Sub CargarUsuarios()
        Try

            ObjSegUsuarios.FilterLocal("")
            ObjSegUsuarios.OrderBy = "Login Asc"
            ObjSegUsuarios.Retrieve("*, (Select NombreEmpleado From VwSsgEmpleadosNaturales " & _
                                       " Where  nSrhEmpleadoID = objEmpleadoID) As Empleado , '' As ColumnaMentira")

            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = ObjSegUsuarios.Source

            'Configurar el Grid de Usuarios           
            Me.grdDetallePadre.Splits(0).DisplayColumns("SsgCuentaID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("Clave").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("ObjEmpleadoID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdDetallePadre.Splits(0).DisplayColumns("Login").Width = 100
            Me.grdDetallePadre.Splits(0).DisplayColumns("Activo").Width = 40
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaExpiracion").Width = 100
            Me.grdDetallePadre.Splits(0).DisplayColumns("Empleado").Width = 200

            'Captions
            Me.grdDetallePadre.Columns("FechaExpiracion").Caption = "Fecha Expiración"
            Me.grdDetallePadre.Columns("ColumnaMentira").Caption = ""

            'Alineaciones
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaExpiracion").HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaExpiracion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaExpiracion").Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaExpiracion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Usuarios)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        18 de Julio del 2006
    '-- Descripcion:                    Cargar las Aplicaciones registradas en el modulo de Seguridad.
    '------------------------------------------------------------------------------------
    Private Sub CargarAplicaciones()
        Try

            ObjSegAplicaciones.FilterLocal("")
            ObjSegAplicaciones.OrderBy = "CodInterno Asc"
            ObjSegAplicaciones.Retrieve("")
            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = ObjSegAplicaciones.Source

            '-- Configurando el Grid de Aplicaciones 
            Me.grdDetallePadre.Splits(0).DisplayColumns("SsgAplicacionID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaModificacion").Visible = False

            Me.grdDetallePadre.Splits(0).DisplayColumns("CodInterno").Width = 200
            Me.grdDetallePadre.Splits(0).DisplayColumns("Nombre").Width = 250
            Me.grdDetallePadre.Splits(0).DisplayColumns("Descripcion").Width = 200

            Me.grdDetallePadre.Columns("CodInterno").Caption = "Código"
            Me.grdDetallePadre.Columns("Descripcion").Caption = "Descripción"
            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " aplicaciones)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        18 de Julio del 2006
    '-- Descripcion:                    Cargar las Aplicaciones registradas en el módulo 
    '--                                 de Seguridad.
    '------------------------------------------------------------------------------------
    Private Sub CargarModulos()
        Try
            'Declaracion de Variables 
            Dim IdAplicacion As Long

            'Inicializar Variables 
            IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            ObjSegModulos.FilterLocal("")
            ObjSegModulos.Filter = "ObjAplicacionID = " & IdAplicacion
            ObjSegModulos.OrderBy = "CodInterno Asc"
            ObjSegModulos.Retrieve()

            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = ObjSegModulos.Source

            'Configurando el Grid de Modulos       
            Me.grdDetallePadre.Splits(0).DisplayColumns("SsgModuloID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("ObjAplicacionID").Visible = False

            'Dimensionando las columnas
            Me.grdDetallePadre.Splits(0).DisplayColumns("CodInterno").Width = 60
            Me.grdDetallePadre.Splits(0).DisplayColumns("Nombre").Width = 250
            Me.grdDetallePadre.Splits(0).DisplayColumns("Descripcion").Width = 200

            Me.grdDetallePadre.Columns("CodInterno").Caption = "Código"
            Me.grdDetallePadre.Columns("Descripcion").Caption = "Descripción"
            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " módulos)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        18 de Julio del 2006
    '-- Descripcion:                    Cargar los Servicios de Usuario del módulo seleccionado.
    '------------------------------------------------------------------------------------
    Private Sub CargarServicioUsuario()
        Try
            Dim IdModulo As Long

            IdModulo = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            ObjSegServUsuarios.FilterLocal("")
            ObjSegServUsuarios.Filter = "ObjModuloID = " & IdModulo
            ObjSegServUsuarios.OrderBy = "CodInterno Asc"
            ObjSegServUsuarios.Retrieve()

            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = ObjSegServUsuarios.Source

            'Configurando el Grid
            Me.grdDetallePadre.Splits(0).DisplayColumns("SsgServicioUsuarioID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("ObjModuloID").Visible = False

            'Dimensionando las columnas del Grid
            Me.grdDetallePadre.Splits(0).DisplayColumns("CodInterno").Width = 200
            Me.grdDetallePadre.Splits(0).DisplayColumns("Nombre").Width = 250
            Me.grdDetallePadre.Splits(0).DisplayColumns("Descripcion").Width = 200


            Me.grdDetallePadre.Columns("CodInterno").Caption = "Código"
            Me.grdDetallePadre.Columns("Descripcion").Caption = "Descripción"
            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Servicios de Usuarios)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        18 de Julio del 2006
    '-- Descripcion:                    Cargar los roles que están asociados al Modulo de 
    '--                                 Aplicación seleccionado.
    '------------------------------------------------------------------------------------
    Private Sub CargarRoles()
        Try
            'Declaracion de Variables 
            Dim IdAplicacion As Long

            IdAplicacion = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            ObjSegRoles.FilterLocal("")
            ObjSegRoles.Filter = "ObjAplicacionID = " & IdAplicacion
            ObjSegRoles.OrderBy = "Nombre Asc"
            ObjSegRoles.Retrieve()

            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = ObjSegRoles.Source

            'Configurando el Grid.
            Me.grdDetallePadre.Splits(0).DisplayColumns("SsgRolID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("ObjAplicacionID").Visible = False

            'Dimensionando las columnas del Grid
            Me.grdDetallePadre.Splits(0).DisplayColumns("Nombre").Width = 250
            Me.grdDetallePadre.Splits(0).DisplayColumns("Descripcion").Width = 200

            'Buscando los titulos de las Columnas del Grid
            Me.grdDetallePadre.Columns("Descripcion").Caption = "Descripción"
            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Roles)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub treeSeguridad_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeSeguridad.AfterSelect
        Try
            'Declaracion de Variables 
            Dim vNivel As String

            vNivel = RTrim(LTrim(Mid(Me.treeSeguridad.SelectedNode.Tag, 1, 3)))
            '----------------------------
            If vNivel = "NR" Then           'Nivel Seguridad
                LimpiarGrid()
            ElseIf vNivel = "NU" Then       'Nivel Usuario
                CargarUsuarios()
            ElseIf vNivel = "NUH" Then      'Nivel Hijos Usuario
                LimpiarGrid()
            ElseIf vNivel = "NA" Then       'Nivel Aplicacion
                CargarAplicaciones()
            ElseIf vNivel = "NAH" Then      'Nivel Hijos de Aplicaciones
                LimpiarGrid()
            ElseIf vNivel = "NMP" Then      'Nivel Modulo
                CargarModulos()
            ElseIf vNivel = "NMH" Then      'Nivel Servicios de Usuario
                CargarServicioUsuario()
            ElseIf vNivel = "NSH" Then       'Nivel Hijos Servicios de Usuario del Módulo
                LimpiarGrid()
            ElseIf vNivel = "NEP" Then      'Nivel Accion
                CargarAcciones()
            ElseIf vNivel = "NEH" Then      'Hijos de Acciones del Servicio de Usuario
                LimpiarGrid()
            ElseIf vNivel = "NRP" Then      'Nivel Rol 
                CargarRoles()
            ElseIf vNivel = "NRH" Then      'Hijos de Roles de la Acción seleccionada
                LimpiarGrid()
            ElseIf vNivel = "NTP" Then      'Nivel Accion Rol
                CargarAccionRol()
            ElseIf vNivel = "NTH" Then      'Nivel Hijos de Acciones Autorizadas
                LimpiarGrid()
            ElseIf vNivel = "NUP" Then      'Nivel Usuario que juegan ese Rol
                CargarUsuariosRol()
            ElseIf vNivel = "NWH" Then
                LimpiarGrid()               'Nivel Hijos de Usuarios que juegan ese Rol
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        20 de Julio del 2006
    '-- Descripcion:                    Cargar la lista de acciones.
    '------------------------------------------------------------------------------------
    Private Sub CargarAcciones()
        Try
            'Declaracion de Variables 
            Dim IdServUsuario As Long

            IdServUsuario = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            ObjAcciones.FilterLocal("")
            ObjAcciones.Filter = "ObjServicioUsuarioID  = " & IdServUsuario
            ObjAcciones.OrderBy = "Nombre Asc"
            ObjAcciones.Retrieve()
            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = ObjAcciones.Source

            'Configurando el Grid.
            Me.grdDetallePadre.Splits(0).DisplayColumns("SsgAccionID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("FechaModificacion").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("ObjServicioUsuarioID").Visible = False

            'Dimensionando las columnas del Grid
            Me.grdDetallePadre.Splits(0).DisplayColumns("Nombre").Width = 250
            Me.grdDetallePadre.Splits(0).DisplayColumns("Descripcion").Width = 200
            Me.grdDetallePadre.Splits(0).DisplayColumns("CodInterno").Width = 200

            'Cambiando los titulos de las columnas
            Me.grdDetallePadre.Columns("Descripcion").Caption = "Descripción"
            Me.grdDetallePadre.Columns("CodInterno").Caption = "Código"

            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Acciones)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------
    '-- Implementado Por:               
    '-- Fecha de Implementacion:        22 de Julio del 2006
    '-- Descripcion:                    Cargar la lista de Acciones por Rol
    '------------------------------------------------------------------------------------
    Private Sub CargarAccionRol()
        Try
            'Declaracion de Variables -----------------
            Dim IdRol As Long
            Dim Strsql As String
            '------------------------------------------
            'Buscar el Id del Rol
            Strsql = ""
            IdRol = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            XdsRolAccion.FilterLocal("")
            '------------------------------------------
            Strsql = " Select B.Nombre As Accion,   C.Nombre As Rol," & _
                     "        A.SsgRolAccionID,     '' As ColumnMentira " & _
                     " From   SsgRolAccion A, " & _
                     "        SsgAccion    B, " & _
                     "        SsgRol       C " & _
                     " Where  A.ObjAccionID = B.SsgAccionID And " & _
                     "        A.ObjRolID    = C.SsgRolID    And " & _
                     "        A.ObjRolID    = " & IdRol
            XdsRolAccion.ExecuteSql(Strsql)
            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = XdsRolAccion.Source

            'Configurando el GRID
            Me.grdDetallePadre.Splits(0).DisplayColumns("SsgRolAccionID").Visible = False
            Me.grdDetallePadre.Splits(0).DisplayColumns("Accion").Width = 160
            Me.grdDetallePadre.Splits(0).DisplayColumns("Rol").Width = 160

            Me.grdDetallePadre.Columns("ColumnMentira").Caption = ""
            Me.grdDetallePadre.Columns("Accion").Caption = "Acción"

            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Acciones con este Rol)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '--------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    25 de JUlio del 2006
    '-- Descripcion:                Limpiar el Grid.
    '---------------------------------------------------------------------
    Private Sub LimpiarGrid()
        'Declaración de Variables 
        Dim Strsql As String
        Dim XdtLimpiador As BOSistema.Win.XDataSet.xDataTable
        '-------------------------------------------------------------
        Try
            Strsql = "Select '' as Vacio From SsgCuenta Where 1 = 2 "
            XdtLimpiador = New BOSistema.Win.XDataSet.xDataTable
            XdtLimpiador.ExecuteSql(Strsql)
            Me.grdDetallePadre.DataSource = XdtLimpiador.Source

            Me.grdDetallePadre.Columns("Vacio").Caption = ""
            Me.grdDetallePadre.Caption = ""

        Catch ex As Exception
            Control_Error(ex)

        Finally
            XdtLimpiador = Nothing
        End Try
    End Sub
    '---------------------------------------------------------------------
    '--- Implementado Por:          
    '--- Fecha de Implementacion:   25 de Julio del 2006
    '--- Descripcion:               Cargar la lista de Usuarios que juegan un Rol determinado.
    '---------------------------------------------------------------------
    Private Sub CargarUsuariosRol()
        Try
            'Declaración de Variables          
            Dim Strsql As String
            Dim IdRol As Long
            '------------------------
            IdRol = CLng(Mid(Me.treeSeguridad.SelectedNode.Tag, 4, Len(Me.treeSeguridad.SelectedNode.Tag)))

            Strsql = ""
            Strsql = " Select A.Login, B.Nombre As Rol, '' As ColumnMentira " & _
                     " From   SsgCuenta     A, " & _
                     "        SsgRol        B, " & _
                     "        SsgCuentaRol  C " & _
                     " Where  C.ObjCuentaID = A.SsgCuentaID And " & _
                     "        C.ObjRolID    = B.SsgRolID    And " & _
                     "        C.ObjRolID    = " & IdRol

            XdsCuentaRol.FilterLocal("")
            XdsCuentaRol.ExecuteSql(Strsql)
            Me.grdDetallePadre.DataSource = Nothing
            Me.grdDetallePadre.DataSource = XdsCuentaRol.Source

            'Configurando el GRID          
            Me.grdDetallePadre.Splits(0).DisplayColumns("Rol").Width = 200
            Me.grdDetallePadre.Splits(0).DisplayColumns("Login").Width = 100
            Me.grdDetallePadre.Columns("ColumnMentira").Caption = ""
            Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Usuarios asignados a este Rol)"


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub grdDetallePadre_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetallePadre.Filter
        Try
            'Declaracion de Variables 
            Dim vNivel As String

            vNivel = RTrim(LTrim(Mid(Me.treeSeguridad.SelectedNode.Tag, 1, 3)))
            '----------------------------
            If vNivel = "NR" Then           'Nivel Seguridad  

            ElseIf vNivel = "NU" Then       'Nivel Usuario
                ObjSegUsuarios.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Usuarios)"

            ElseIf vNivel = "NUH" Then      'Nivel Hijos Usuario

            ElseIf vNivel = "NA" Then       'Nivel Aplicacion
                ObjSegAplicaciones.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " aplicaciones)"

            ElseIf vNivel = "NAH" Then      'Nivel Hijos de Aplicaciones

            ElseIf vNivel = "NMP" Then      'Nivel Modulo
                ObjSegModulos.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " módulos)"

            ElseIf vNivel = "NMH" Then      'Nivel Servicios de Usuario
                ObjSegServUsuarios.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Servicios de Usuarios)"

            ElseIf vNivel = "NSH" Then      'Nivel Hijos Servicios de Usuario del Módulo                

            ElseIf vNivel = "NEP" Then      'Nivel Accion
                ObjAcciones.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Acciones)"

            ElseIf vNivel = "NEH" Then      'Hijos de Acciones del Servicio de Usuario

            ElseIf vNivel = "NRP" Then      'Nivel Rol 
                ObjSegRoles.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Roles)"

            ElseIf vNivel = "NRH" Then      'Hijos de Roles de la Acción seleccionada

            ElseIf vNivel = "NTP" Then      'Nivel Accion Rol
                XdsRolAccion.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Acciones con este Rol)"

            ElseIf vNivel = "NTH" Then      'Nivel Hijos de Acciones Autorizadas

            ElseIf vNivel = "NUP" Then      'Nivel Usuario que juegan ese Rol
                XdsCuentaRol.FilterLocal(e.Condition)
                Me.grdDetallePadre.Caption = "(" & Me.grdDetallePadre.RowCount.ToString & " Usuarios asignados a este Rol)"

            ElseIf vNivel = "NWH" Then

            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub treeSeguridad_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles treeSeguridad.DoubleClick
        Try
            '-- Declaracion de Variables 
            Dim vNivel As String
            vNivel = ""

            'Verificar si hay un Nodo seleccionado
            If Me.treeSeguridad.SelectedNode Is Nothing Then
                Exit Sub
            End If

            vNivel = RTrim(LTrim(Mid(Me.treeSeguridad.SelectedNode.Tag, 1, 3)))
            Seg.RefreshPermissions()

            If vNivel = "NUH" Then
                '-----------------
                If Seg.HasPermission("EditarCuentaUsuario") Then
                    LlamaModificaUsuario()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                            "para modificar los datos del Usuario seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NAH" Then

                If Seg.HasPermission("EditarAplicacion") Then
                    LlamaModificaAplicacion()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para modificar los datos de una aplicación.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NMH" Then

                If Seg.HasPermission("EditarModulo") Then
                    LlamaModificaModulo()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para modificar los datos del módulo seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NSH" Then

                If Seg.HasPermission("EditarServUsuario") Then
                    LlamaModificaServUsuario()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos para " & Chr(10) & _
                           "modificar los datos del Servicio de Usuario seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NEH" Then

                If Seg.HasPermission("EditarAccion") Then
                    LlamaModificaAccion()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos para " & Chr(10) & _
                           "modificar la acción del Servicio de Usuario seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If

            ElseIf vNivel = "NRH" Then

                If Seg.HasPermission("EditarRol") Then
                    LlamaModificaRol()
                Else
                    MsgBox("El usuario " & UCase(InfoSistema.LoginName) & " no tiene permisos " & Chr(10) & _
                           "para modificar el Rol seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimir.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            'frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSsgSG1.rpt"
            frmVisor.Text = "Listado de Acciones del Sistema"
            frmVisor.SQLQuery = " Select SsgModuloID, " & _
                                "        sModulo, " & _
                                "        sServicioUsuario, " & _
                                "        sAccion " & _
                                " From vwStbListadoOpciones " & _
                                " Where CodInterno <> 'SSG' " & _
                                " Order by sModulo desc,sServicioUsuario desc,sAccion "
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    '    'Declaración de Variables
    '    Dim ObjVisorReporte As frmVisorReporte
    '    Dim ObjRptSsgAcciones As rptSsgAcciones
    '    Try
    '        'Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3

    '        ObjVisorReporte = New frmVisorReporte

    '        ObjRptSsgAcciones = New rptSsgAcciones

    '        ObjReporte = ObjRptSsgAcciones

    '        'Seteo el text del reporte
    '        'Select Case mNomRep
    '        '    Case EnumReportes.rptSclFichaInscripcion
    '        '        ObjVisorReporte.Text = "Reporte de Ficha de Inscripción"
    '        '    Case EnumReportes.rptSclFichaVerificacion
    '        ObjVisorReporte.Text = "Reporte de Opciones"
    '        'End Select

    '        ObjReporte.Run()
    '        ObjVisorReporte.VisorReportes.Document = ObjReporte.Document
    '        ObjVisorReporte.WindowState = FormWindowState.Maximized
    '        ObjVisorReporte.ShowDialog()


    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        'ObjReporte = Nothing

    '    End Try
    'End Sub

  

    Private Sub toolAuditoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAuditoria.Click
        Try
            LlamaConsulta()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub LlamaConsulta()
        Try
            Dim ObjFrmConsulta As FrmSsgConsulta
            ObjFrmConsulta = New FrmSsgConsulta

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            'ObjFrmConsulta.MdiParent = Me
            ObjFrmConsulta.Text = "Consulta"
            ObjFrmConsulta.ShowDialog()
            'ObjFrmConsulta.WindowState = FormWindowState.Maximized
            'OpenForm(ObjFrmConsulta)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            'ObjFrmConsulta.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    
End Class