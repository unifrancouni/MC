Public Class FrmSsgEditCuenta
    'Declaracion de Variables 
    Dim ModoForm As String
    Dim IdUsuariol As Long
    Dim vbModifico As Boolean
    Dim mNombreCuenta As String
    Dim sFrmTipoLlamado As String

    'Clases Requeridas
    Dim ObjAplicaciones As BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
    Dim ObjCuentaDr As BOSistema.Win.SsgEntSeguridad.SsgCuentaRow

    Dim XdsRolesxApp As BOSistema.Win.XDataSet.xDataTable
    Dim XdsEmpleadosNat As BOSistema.Win.XDataSet.xDataTable
    Dim XdsDelegaciones As BOSistema.Win.XDataSet.xDataTable
    Dim XdsUsuarios As New BOSistema.Win.XDataSet

    '------------------------------------------
    'Permite manejar los diferentes estados 
    'que puede tener un formulario según sus 
    'acciones: Acepto o Cancelo.
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum
    '-------------------------------------------
    Public AccionUsuario As AccionBoton
    '-------------------------------------------
    'Parámetro del formulario el Id de la Aplicación
    'para la que se requiere agregar el Módulo
    '-------------------------------------------------
    Public Property IdUsuario() As Long
        Get
            IdUsuario = IdUsuariol
        End Get
        Set(ByVal value As Long)
            IdUsuariol = value
        End Set
    End Property

    Public Property sTipoLlamado() As String
        Get
            sTipoLlamado = sFrmTipoLlamado
        End Get
        Set(ByVal value As String)
            sFrmTipoLlamado = value
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

    Public Property NombreCuenta() As String
        Get
            Return mNombreCuenta
        End Get
        Set(ByVal value As String)
            mNombreCuenta = value
        End Set
    End Property

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        If FncValidaParametros() Then
                            SalvarCuentaUsuario()
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
    Private Sub FrmSsgEditCuenta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If AccionUsuario <> AccionBoton.BotonNinguno Then
            'Liberando el espacio
            ObjAplicaciones.Close()
            ObjAplicaciones = Nothing

            'ObjCuentaDr.Close()
            ObjCuentaDr = Nothing

            XdsRolesxApp.Close()
            XdsRolesxApp = Nothing

            XdsEmpleadosNat.Close()
            XdsEmpleadosNat = Nothing

            XdsDelegaciones.Close()
            XdsDelegaciones = Nothing
        Else

            'Regresar la accion del Usuario al estado Inicial
            e.Cancel = True
            AccionUsuario = AccionBoton.BotonCancelar
        End If
    End Sub
    Private Sub FrmEditCuenta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
            CargarEmpleados()
            CargarDelegaciones(0)
            CargarRolesxAplicacion()

            '-- Cargar los datos del Usuario seleccionado
            If ModoFrm = "UPD" Then
                CargarDatosUsuario()
            End If
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            'Iniciar en el Primer Tab y poner
            'el focon en el primer campo navegable
            Me.tabCuentaRol.SelectedIndex = 0

            If Me.sTipoLlamado = "PRINCIPAL" Then
                Me.txtPaswordAnterior.Select()
                Me.txtPaswordAnterior.Enabled = True
            Else
                If Me.chkActivo.Checked = False Then
                    Me.chkActivo.Select()
                Else
                    Me.cboEmpleado.Select()
                End If
                Me.txtPaswordAnterior.Enabled = False
            End If

            LlenarGridAccionesPosibles()
            CargarUsuarios()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub LlenarGridAccionesPosibles()

        Dim objAccionesAsignadas As New BOSistema.Win.XDataSet.xDataTable
        Dim sqlquery As String
        sqlquery = " SELECT sra.objAccionID, sa.Nombre," & _
                   "       sa.CodInterno" & _
                   " FROM SsgRolAccion sra" & _
                   "      INNER JOIN SsgRol sr ON sr.SsgRolID = sra.objRolID " & _
                   "      INNER JOIN SsgAccion sa ON sa.SsgAccionID = sra.objAccionID " & _
                   "      INNER JOIN SsgCuentaRol scr " & _
                   "      ON scr.objRolID = sr.SsgRolID " & _
                   "      INNER JOIN SsgCuenta sc" & _
                   "      ON sc.SsgCuentaID = scr.objCuentaID" & _
        String.Format("  WHERE sc.[Login] = '{0}'", Me.txtLogin.Text)
        objAccionesAsignadas.ExecuteSql(sqlquery)

        ''Inicializar el treeview
        Me.trvAccionesPosibles.BeginUpdate()
        Me.trvAccionesPosibles.Nodes.Clear()
        Me.trvAccionesPosibles.HideSelection = False
        Dim ContadorModulos As Integer = 0
        Dim ContadorPanatallas As Integer = 0
        Dim ContadorAcciones As Integer = 0
        Dim Key As Int16 = 0
        Dim objSegAccciones As New BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable()
        Dim ObjSegModulos As New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable()
        Dim ObjSegServUsuarios As New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable()
        ObjSegModulos.OrderBy = "Nombre ASC"
        ObjSegModulos.Retrieve()
        If ObjSegModulos.Count > 0 Then
            For i As Integer = 0 To ObjSegModulos.Count - 1
                Me.trvAccionesPosibles.Nodes.Add(New TreeNode(ObjSegModulos.Itemn(i).Nombre))
                Me.trvAccionesPosibles.Nodes(i).Name = Key
                Me.trvAccionesPosibles.Nodes(i).Tag = "NMH" & ObjSegModulos.Itemn(i).SsgModuloID
                Me.trvAccionesPosibles.Nodes(i).ImageIndex = 5
                Me.trvAccionesPosibles.Nodes(i).SelectedImageIndex = 5

                Key = Key + 1

                'Buscar las pantallas
                ' y asociarlas al módulo seleccionado.
                ObjSegServUsuarios.Filter = "ObjModuloID = " & ObjSegModulos.Itemn(i).SsgModuloID
                ObjSegServUsuarios.OrderBy = "Nombre ASC"

                ObjSegServUsuarios.Retrieve()
                If ObjSegServUsuarios.Count > 0 Then
                    ContadorPanatallas = 0
                    For p As Integer = 0 To ObjSegServUsuarios.Count - 1
                        Me.trvAccionesPosibles.Nodes(i).Nodes.Add(New TreeNode(ObjSegServUsuarios.Itemn(p).Nombre))
                        Me.trvAccionesPosibles.Nodes(i).Nodes(p).Name = Key
                        Me.trvAccionesPosibles.Nodes(i).Nodes(p).Tag = "NSH" & ObjSegServUsuarios.Itemn(p).SsgServicioUsuarioID
                        Me.trvAccionesPosibles.Nodes(i).Nodes(p).ImageIndex = 7
                        Me.trvAccionesPosibles.Nodes(i).Nodes(p).SelectedImageIndex = 7
                        Me.trvAccionesPosibles.Nodes(i).Nodes(p).ForeColor = Color.DarkSalmon
                        Key = Key + 1

                        'Buscar las acciones de cada pantalla 
                        ' y asociarlas 
                        objSegAccciones.Filter = "ObjServicioUsuarioID = " & ObjSegServUsuarios.Itemn(p).SsgServicioUsuarioID
                        objSegAccciones.OrderBy = "Nombre ASC"

                        objSegAccciones.Retrieve()
                        If objSegAccciones.Count > 0 Then
                            ContadorAcciones = 0
                            For l As Integer = 0 To objSegAccciones.Count - 1
                                Me.trvAccionesPosibles.Nodes(i).Nodes(p).Nodes.Add(New TreeNode(objSegAccciones.Itemn(l).Nombre))
                                Me.trvAccionesPosibles.Nodes(i).Nodes(p).Nodes(l).Name = Key
                                Me.trvAccionesPosibles.Nodes(i).Nodes(p).Nodes(l).Tag = "NEH" & objSegAccciones.Itemn(l).SsgAccionID
                                Me.trvAccionesPosibles.Nodes(i).Nodes(p).Nodes(l).ImageIndex = 8
                                Me.trvAccionesPosibles.Nodes(i).Nodes(p).Nodes(l).SelectedImageIndex = 8
                                Me.trvAccionesPosibles.Nodes(i).Nodes(p).Nodes(l).ForeColor = Color.Blue

                                objAccionesAsignadas.FilterLocal(String.Format("objAccionID = {0} ", objSegAccciones.Itemn(l).SsgAccionID))
                                If objAccionesAsignadas.CountFiltro > 0 Then
                                    Me.trvAccionesPosibles.Nodes(i).Nodes(p).Nodes(l).Checked = True
                                    ContadorAcciones += 1
                                End If
                                Key = Key + 1
                            Next l
                            If ContadorAcciones > 0 Then
                                Me.trvAccionesPosibles.Nodes(i).Nodes(p).Checked = True
                                ContadorPanatallas += 1
                            End If
                        End If
                    Next
                    If ContadorPanatallas > 0 Then
                        Me.trvAccionesPosibles.Nodes(i).Checked = True
                    End If
                End If
            Next
        End If
        trvAccionesPosibles.EndUpdate()

    End Sub
    '-----------------------------------------------------------------------------------
    '--- Implementado Por:          
    '--- Fecha de Implementacion:   22 de Julio del 2006
    '--- Descripcion:               Inicializar las variables generales del formulario.
    '-----------------------------------------------------------------------------------
    Private Sub InicializaVariables()

        'Declaracion de Variables
        Dim ObjCuentaDt As BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable

        Try
            ObjCuentaDt = New BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Cuenta de Usuario"
                Me.chkActivo.Enabled = False
                Me.cdeFechaExpiracion.Enabled = False
            Else
                Me.Text = "Modificar Cuenta de Usuario"
                Me.cboEmpleado.Enabled = False
                Me.txtLogin.Enabled = False
            End If
            'Instanciando las clases 
            ObjAplicaciones = New BOSistema.Win.SsgEntSeguridad.SsgAplicacionDataTable
            ObjCuentaDr = New BOSistema.Win.SsgEntSeguridad.SsgCuentaRow

            XdsRolesxApp = New BOSistema.Win.XDataSet.xDataTable
            XdsEmpleadosNat = New BOSistema.Win.XDataSet.xDataTable
            XdsDelegaciones = New BOSistema.Win.XDataSet.xDataTable

            Me.cdeFechaCreacion.Value = Now.Date()
            Me.cdeFechaCreacion.Enabled = False

            'Configurando el tamaño maximo
            'de las columnas de tipo texto --------------------------------
            Me.txtLogin.MaxLength = ObjCuentaDt.GetColumnLenght("Login")
            Me.txtPassword.MaxLength = 10    'ObjCuentaDt.GetColumnLenght("Clave")
            Me.txtConfirmacion.MaxLength = 10     'ObjCuentaDt.GetColumnLenght("Clave")
            '--------------------------------------------------------------
            If ModoFrm = "ADD" Then
                Me.chkActivo.Checked = True
            End If
            '--------------------------------------------------------------

            If Me.sTipoLlamado = "PRINCIPAL" Then
                Me.cboEmpleado.Enabled = False
                Me.chkActivo.Enabled = False
                Me.chkActivoEmpleado.Enabled = False
                Me.cdeFechaExpiracion.Enabled = False
                Me.tabPRoles.Enabled = False
                Me.cboDelegacion.Enabled = False
                Me.txtPassword.Select()
                'Else 'Desde usuario
                '    If UsuarioBloqueado(txtLogin.Text) And ModoFrm <> "ADD" Then
                '        lblBloqueada.Visible = True
                '        btnDesbloquear.Visible = True
                '    End If
            End If

            Me.chkActivoEmpleado.Enabled = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjCuentaDt = Nothing
        End Try
    End Sub
    Private Function UsuarioBloqueado(ByVal UsuarioName As String) As Boolean
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
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
    '-------------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    24 de JUlio del 2006
    '-- Descripcion:                Cargar los datos del Usuario seleccionado.
    '------------------------------------------------------------------------------
    Private Sub CargarDatosUsuario()
        Try
            ObjCuentaDr.RetrieveByID(IdUsuario)
            If ObjCuentaDr.Count = 0 Then
                Exit Sub
            End If
            Me.txtLogin.Text = ObjCuentaDr.Login
            Me.txtPassword.Text = DesencriptaOfHex(ObjCuentaDr.Clave)
            Me.txtConfirmacion.Text = DesencriptaOfHex(ObjCuentaDr.Clave)
            Me.cdeFechaCreacion.Value = Format(ObjCuentaDr.FechaCreacion, "dd-MM-yyyy")
            If ObjCuentaDr.IsFieldNull("FechaExpiracion") Then
                Me.cdeFechaExpiracion.ValueIsDbNull = True
            Else
                Me.cdeFechaExpiracion.Value = Format(ObjCuentaDr.FechaExpiracion, "dd-MM-yyyy")
            End If

            If ObjCuentaDr.Activo = True Then
                Me.chkActivo.Checked = True
            Else
                Me.chkActivo.Checked = False
                Me.chkActivo.Enabled = False
                Me.tabPRoles.Enabled = False
                Me.txtLogin.Enabled = False
                Me.txtPassword.Enabled = False
                Me.txtPaswordAnterior.Enabled = False
                Me.txtConfirmacion.Enabled = False
                Me.cboDelegacion.Enabled = False
                Me.cboEmpleado.Enabled = False
                Me.cdeFechaExpiracion.Enabled = False
            End If

            If Not ObjCuentaDr.IsFieldNull("ObjEmpleadoID") Then
                If Me.cboEmpleado.ListCount > 0 Then
                    Me.cboEmpleado.SelectedIndex = 0
                    XdsEmpleadosNat.SetCurrentByID("nSrhEmpleadoID", ObjCuentaDr.objEmpleadoID)
                End If
            End If
            If Not ObjCuentaDr.IsFieldNull("nStbDelegacionProgramaID") Then
                CargarDelegaciones(ObjCuentaDr.nStbDelegacionProgramaID)
                If Me.cboDelegacion.ListCount > 0 Then
                    Me.cboDelegacion.SelectedIndex = 0
                    XdsDelegaciones.SetCurrentByID("nStbDelegacionProgramaID", ObjCuentaDr.nStbDelegacionProgramaID)
                End If
            End If

            If Me.sTipoLlamado = "PRINCIPAL" Then
                
            Else 'Desde usuario
                If UsuarioBloqueado(txtLogin.Text) And ModoFrm <> "ADD" Then
                    lblBloqueada.Visible = True
                    btnDesbloquear.Visible = True
                End If
            End If



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '--------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    24 de Julio del 2006
    '-- Descripcion.                Cargar la lista de Empleados.
    '--------------------------------------------------------------------
    Private Sub CargarEmpleados()
        Try
            'Declaracion de Variables
            Dim Strsql As String

            Strsql = " Select NombreEmpleado, sNumCedula,       nSrhEmpleadoID, " &
                     "        nActivo,         dFechaIngreso, dFechaEgreso " &
                     " From   VwSsgEmpleadosNaturales " &
                     " " &
                     " Order By NombreEmpleado Asc"
            XdsEmpleadosNat.ExecuteSql(Strsql)
            Me.cboEmpleado.DataSource = XdsEmpleadosNat.Source

            'Configurando las columnas del Combo
            '-- Poner invisible las columnas       
            Me.cboEmpleado.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboEmpleado.Splits(0).DisplayColumns("dFechaIngreso").Visible = False
            Me.cboEmpleado.Splits(0).DisplayColumns("dFechaEgreso").Visible = False
            Me.cboEmpleado.Splits(0).DisplayColumns("nActivo").Visible = False

            '-- Dimensionando las columnas del combo        
            Me.cboEmpleado.Splits(0).DisplayColumns("NombreEmpleado").Width = 180
            Me.cboEmpleado.Splits(0).DisplayColumns("sNumCedula").Width = 100

            '-- Actualizando el Caption de las columnas del Grids
            Me.cboEmpleado.Columns("NombreEmpleado").Caption = "Nombre"
            Me.cboEmpleado.Columns("sNumCedula").Caption = "Cédula"

            '-- Agregar el elemento en blanco al combo puesto que 
            '-- el usuario puede decidir no asociar ningun Empleado.            
            'XdsEmpleadosNat.AddRow()
            'XdsEmpleadosNat("NombreEmpleado") = ""
            'XdsEmpleadosNat("sNumCedula") = ""
            'XdsEmpleadosNat("nSrhEmpleadoID") = -19
            'XdsEmpleadosNat.Sort = "NombreEmpleado ASC"
            'XdsEmpleadosNat.UpdateLocal()

            'Iniciar en el primer elemento el Combo
            'If XdsEmpleadosNat.Count > 0 Then
            '    Me.cboEmpleado.SelectedIndex = 0
            'End If
            Me.cboEmpleado.DisplayMember = "NombreEmpleado"
            Me.cboEmpleado.ValueMember = "nSrhEmpleadoID"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '--------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementación:    24 de Julio del 2006
    '-- Descripcion.                Cargar la lista de Empleados.
    '--------------------------------------------------------------------
    Private Sub CargarDelegaciones(ByVal IdDelegacionPrograma As Integer)
        Try
            'Declaracion de Variables
            Dim Strsql As String

            If IdDelegacionPrograma = 0 Then
                Strsql = " Select nStbDelegacionProgramaID,nCodigo,sNombreDelegacion " & _
                         " From   StbDelegacionPrograma " & _
                         " Where  nActiva = 1 " & _
                         " Order By nCodigo Asc"
            Else
                Strsql = " Select nStbDelegacionProgramaID,nCodigo,sNombreDelegacion " & _
                         " From   StbDelegacionPrograma " & _
                         " Where  nActiva = 1 Or nStbDelegacionProgramaID = " & IdDelegacionPrograma & _
                         " Order By nCodigo Asc"
            End If

            XdsDelegaciones.ExecuteSql(Strsql)
            Me.cboDelegacion.DataSource = XdsDelegaciones.Source

            'Configurando las columnas del Combo
            '-- Poner invisible las columnas       
            Me.cboDelegacion.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            '-- Dimensionando las columnas del combo        
            Me.cboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").Width = 180
            Me.cboDelegacion.Splits(0).DisplayColumns("nCodigo").Width = 80

            '-- Actualizando el Caption de las columnas del Grids
            Me.cboDelegacion.Columns("sNombreDelegacion").Caption = "Delegación"
            Me.cboDelegacion.Columns("nCodigo").Caption = "Código"

            Me.cboDelegacion.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '-- Agregar el elemento en blanco al combo puesto que 
            '-- el usuario puede decidir no asociar ningun Empleado.            
            'XdsEmpleadosNat.AddRow()
            'XdsEmpleadosNat("NombreEmpleado") = ""
            'XdsEmpleadosNat("sNumCedula") = ""
            'XdsEmpleadosNat("nSrhEmpleadoID") = -19
            'XdsEmpleadosNat.Sort = "NombreEmpleado ASC"
            'XdsEmpleadosNat.UpdateLocal()

            'Iniciar en el primer elemento el Combo
            'If XdsEmpleadosNat.Count > 0 Then
            '    Me.cboEmpleado.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    20 de Julio del 2006
    '-- Descripcion:                Cargar la lista de Roles x Aplicación
    '------------------------------------------------------------------------
    Private Sub CargarRolesxAplicacion()
        Try
            Dim Strsql As String

            If ModoFrm = "ADD" Then
                Strsql = " Select CAST(0 as Bit) As Selected, " & _
                         "        SsgAplicacion.SsgAplicacionID, " & _
                         "        SsgAplicacion.Nombre As NombreAplicacion, " & _
                         "        SsgRol.SsgRolID,  " & _
                         "        SsgRol.Nombre AS NombreRol" & _
                         " FROM   SsgRol        INNER JOIN " & _
                         "        SsgAplicacion ON SsgRol.objAplicacionID = SsgAplicacion.SsgAplicacionID " & _
                         " Where SsgRol.nRolEspecial = 0 " & _
                         " ORDER BY SsgAplicacion.Nombre, SsgRol.Nombre "
            Else
                Strsql = " Select Cast((Select count(*) From SsgCuentaRol " & _
                                      " Where ObjCuentaID = " & IdUsuario & " And " & _
                                      "       ObjRolID    = SsgRol.SsgRolID) As Bit) As Selected, " & _
                         "        SsgAplicacion.SsgAplicacionID, " & _
                         "        SsgAplicacion.Nombre As NombreAplicacion, " & _
                         "        SsgRol.SsgRolID,  " & _
                         "        SsgRol.Nombre AS NombreRol" & _
                         " FROM   SsgRol        INNER JOIN " & _
                         "        SsgAplicacion ON SsgRol.objAplicacionID = SsgAplicacion.SsgAplicacionID " & _
                         " Where SsgRol.nRolEspecial = 0 " & _
                         " ORDER BY SsgAplicacion.Nombre, SsgRol.Nombre "
            End If
            XdsRolesxApp.ExecuteSql(Strsql)
            Me.grdRoles.DataSource = XdsRolesxApp.Source

            'Configurando las columnas del GRID
            '-- Poner invisible las columnas       
            Me.grdRoles.Splits(0).DisplayColumns("SsgAplicacionID").Visible = False
            Me.grdRoles.Splits(0).DisplayColumns("SsgRolID").Visible = False

            '-- Dimensionando las columnas del combo     
            Me.grdRoles.Splits(0).DisplayColumns("Selected").Width = 40
            Me.grdRoles.Splits(0).DisplayColumns("NombreAplicacion").Width = 180
            Me.grdRoles.Splits(0).DisplayColumns("NombreRol").Width = 180

            'Lockear las columnas que no requieren edición           
            Me.grdRoles.Splits(0).DisplayColumns("NombreAplicacion").Locked = True
            Me.grdRoles.Splits(0).DisplayColumns("NombreRol").Locked = True

            '-- Cambiando los títulos de las columnas
            Me.grdRoles.Columns("Selected").Caption = ""
            Me.grdRoles.Columns("NombreAplicacion").Caption = "Aplicación"
            Me.grdRoles.Columns("NombreRol").Caption = "Rol"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '---------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    24 de Julio del 2006
    '-- Descripcion:                Cargar los datos del Empleado
    '---------------------------------------------------------------------
    Private Sub cboEmpleado_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEmpleado.SelectedValueChanged
        Try
            If Me.cboEmpleado.Columns("nSrhEmpleadoID").Value Is DBNull.Value Then
                Exit Sub
            End If
            CargarDatosEmpleado(Me.cboEmpleado.Columns("nSrhEmpleadoID").Value)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '---------------------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    24 de Julio del 2006
    '-- Descripcion:                Cargar los datos del Empleado seleccionado.
    '---------------------------------------------------------------------------
    Private Sub CargarDatosEmpleado(ByVal IdEmpleado As Long)
        Try
            'Declaracion de Variables -------------
            Dim Strsql As String
            Dim XdsDatEmpleado As BOSistema.Win.XDataSet.xDataTable


            XdsDatEmpleado = New BOSistema.Win.XDataSet.xDataTable
            '--------------------------------------
            'Si seleccionó el elemento vacio
            If IdEmpleado = -19 Then
                Me.txtNombreEmp.Text = ""
                Me.txtCedula.Text = ""
                Me.txtFechaFinEmp.Text = ""
                Me.txtFechaInicioEmp.Text = ""
                Me.chkActivoEmpleado.Checked = False
            Else
                Strsql = " Select * From VwSsgEmpleadosNaturales " & _
                     " Where  nSrhEmpleadoID = " & IdEmpleado
                XdsDatEmpleado.ExecuteSql(Strsql)

                '-- Cargar los datos del Empleado
                If XdsDatEmpleado.Count > 0 Then

                    'Datos Generales
                    Me.txtNombreEmp.Text = XdsDatEmpleado("NombreEmpleado")
                    Me.txtFechaInicioEmp.Text = XdsDatEmpleado("dFechaIngreso")

                    'Buscar la Fecha de Egreso
                    If XdsDatEmpleado.Table.Rows(0).IsNull("dFechaEgreso") Then
                        Me.txtFechaFinEmp.Text = ""
                    Else
                        Me.txtFechaFinEmp.Text = XdsDatEmpleado("dFechaEgreso")
                    End If
                    'Determinar si el Empleado está Activo o no 
                    If XdsDatEmpleado("nActivo") Then
                        Me.chkActivoEmpleado.Checked = True
                    Else
                        Me.chkActivoEmpleado.Checked = False
                    End If
                    'Cargar los datos de la Cédula
                    If XdsDatEmpleado.Table.Rows(0).IsNull("sNumCedula") Then
                        Me.txtCedula.Text = ""
                    Else
                        Me.txtCedula.Text = XdsDatEmpleado("sNumCedula")
                    End If
                End If
            End If

            'Liberaando el espacio
            XdsDatEmpleado = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If FncValidaParametros() Then
                SalvarCuentaUsuario()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '------------------------------------------------------------------------------------------
    '--- Implementado Por:          
    '--- Fecha de Implementacion:   24 de Julio del 2006
    '--- Descripcion:               Validar los parámetros de entrada de la cuenta de Usuario.
    '---                            1. El login no puede repetirse dentro del catálogo de Cuenta.
    '---                            2. El password es un valor requerido.
    '---                            3. El password con la confirmación deben coincidir.
    '---                            4. La fecha de expiración debe ser mayor o igual a la fecha de creación.
    '---                            5. Debe asociarse al menos un Rol.
    '-------------------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean

        'Declaracion de Variables 
        Dim XdsRolesClon As BOSistema.Win.XDataSet.xDataTable
        Dim ObjCuenta As BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable

        Try
            Dim VbResultado As Boolean
            Dim VTieneRoles As Boolean
            Dim i As Long

            'Limpio el error provider
            Me.ErrorProvider1.Clear()

            ObjCuenta = New BOSistema.Win.SsgEntSeguridad.SsgCuentaDataTable
            XdsRolesClon = New BOSistema.Win.XDataSet.xDataTable
            VTieneRoles = False
            VbResultado = False
            '----------------------------

            'Empleado
            If Me.cboEmpleado.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Empleado válido.", MsgBoxStyle.Critical, "SMUSURA0")
                Me.ErrorProvider1.SetError(Me.cboEmpleado, "Debe seleccionar un Empleado válido.")
                Me.cboEmpleado.Focus()
                GoTo SALIR
            End If

            'Delegación
            If Me.cboDelegacion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Delegación válida.", MsgBoxStyle.Critical, "SMUSURA0")
                Me.ErrorProvider1.SetError(Me.cboDelegacion, "Debe seleccionar una Delegación válida.")
                Me.cboDelegacion.Focus()
                GoTo SALIR
            End If

            '0. El Login es un valor requerido
            If Trim(Me.txtLogin.Text).Length = 0 Then
                MsgBox("Debe ingresar un valor válido para el Login.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtLogin, "Debe ingresar un valor válido para el Login.")
                Me.txtPassword.Focus()
                GoTo SALIR
            End If

            '1. El login no puede repetirse dentro del catálogo
            If ModoFrm = "ADD" Then
                ObjCuenta.Filter = " UPPER(rtrim(ltrim(Login))) = '" & UCase(LTrim(RTrim(Me.txtLogin.Text))) & "'"
            Else
                ObjCuenta.Filter = " UPPER(rtrim(ltrim(Login))) = '" & UCase(LTrim(RTrim(Me.txtLogin.Text))) & "' And SsgCuentaID <> " & IdUsuario
            End If

            ObjCuenta.Retrieve()

            If ObjCuenta.Count > 0 Then
                MsgBox("El login: " & Me.txtLogin.Text & " ya existe.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtLogin, "El login: " & Me.txtLogin.Text & " ya existe.")
                Me.txtLogin.Focus()
                GoTo SALIR
            End If

            '1. El empleado no puede repetirse dentro del catálogo
            If ModoFrm = "ADD" Then
                ObjCuenta.Filter = " Activo = 1 And objEmpleadoID = " & XdsEmpleadosNat("nSrhEmpleadoID")
            Else
                ObjCuenta.Filter = " Activo = 1 And objEmpleadoID = " & XdsEmpleadosNat("nSrhEmpleadoID") & " And SsgCuentaID <> " & IdUsuario
            End If

            ObjCuenta.Retrieve()

            If ObjCuenta.Count > 0 Then
                MsgBox("El Empleado tiene Cuenta Activa.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtLogin, "El Empleado tiene Cuenta Activa.")
                Me.txtLogin.Focus()
                GoTo SALIR
            End If


            '2. El password es un valor requerido.
            If Trim(Me.txtPassword.Text).Length = 0 Then
                MsgBox("Debe ingresar un valor válido para el Password.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtPassword, "Debe ingresar un valor válido para el Password.")
                Me.txtPassword.Focus()
                GoTo SALIR
            End If

            '3. Clave de confirmación
            If Trim(Me.txtConfirmacion.Text).Length = 0 Then
                MsgBox("Debe ingresar un valor válido para la Confirmación.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtConfirmacion, "Debe ingresar un valor válido para la Confirmación.")
                Me.txtConfirmacion.Focus()
                GoTo SALIR
            End If

            '4. El password debe coincidir con la cadena de confirmación.
            If Trim(Me.txtPassword.Text) <> Trim(Me.txtConfirmacion.Text) Then
                MsgBox(" El valor del Password debe coincidir con la Confirmación.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.txtPassword, " El valor del Password debe coincidir con la Confirmación.")
                Me.txtPassword.Focus()
                GoTo SALIR
            End If

            '5. La fecha de Expiración debe ser mayor a la Actual
            If Me.cdeFechaExpiracion.ValueIsDbNull = False Then
                If Me.cdeFechaExpiracion.Value < Me.cdeFechaCreacion.Value Then
                    MsgBox("La fecha de expiración: " & Me.cdeFechaExpiracion.Text & " debe ser " & Chr(10) & _
                           "mayor a la fecha de creación: " & Me.cdeFechaCreacion.Text, MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.cdeFechaExpiracion, "La fecha de expiración: " & Me.cdeFechaExpiracion.Text & " debe ser mayor a la fecha de creación: " & Me.cdeFechaCreacion.Text)
                    Me.cdeFechaExpiracion.Focus()
                    GoTo SALIR
                End If

                If Me.cdeFechaExpiracion.Value <> FechaServer.Date Then
                    MsgBox("La fecha de expiración: " & Me.cdeFechaExpiracion.Text & " debe ser " & Chr(10) & _
                           "igual a la fecha del servidor: " & FechaServer.Date, MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.cdeFechaExpiracion, "La fecha de expiración: " & Me.cdeFechaExpiracion.Text & " debe ser mayor a la fecha del servidor: " & FechaServer.Date)
                    Me.cdeFechaExpiracion.Focus()
                    GoTo SALIR
                End If
            End If


            If Me.sTipoLlamado = "PRINCIPAL" Then
                If Not Seg.Connect(Me.txtLogin.Text, Me.txtPaswordAnterior.Text, "SMUSURA0", "") Then
                    MsgBox("El Password Anterior DEBE ser su Password Actual que desea cambiar.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.txtPaswordAnterior, "El Password Anterior DEBE ser su Password Actual que desea cambiar.")
                    Me.txtPaswordAnterior.Focus()
                    GoTo SALIR
                End If


                '. El password nuevo no debe ser igual al anterior
                If UCase(Trim(Me.txtPassword.Text)) = UCase(Trim(Me.txtPaswordAnterior.Text)) Then
                    MsgBox("El valor del nuevo Password no debe coincidir con el actual.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.txtPassword, "El valor del nuevo Password no debe coincidir con el actual.")
                    Me.txtPassword.Focus()
                    GoTo SALIR
                End If








            End If

            '-- Recorrer las acciones del Grid para determinar 
            '-- si existe al menos una chequeada.
            XdsRolesClon = XdsRolesxApp
            For i = 0 To XdsRolesClon.Count - 1
                If XdsRolesClon.Table.Rows(i).Item("Selected") = True Then
                    VTieneRoles = True
                    Exit For
                End If
            Next i
            If VTieneRoles = False Then
                MsgBox("Debe asociar al menos un Rol a la cuenta de Usuario.", MsgBoxStyle.Critical, NombreSistema)
                Me.ErrorProvider1.SetError(Me.grdRoles, "Debe asociar al menos un Rol a la cuenta de Usuario.")
                Me.grdRoles.Focus()
                GoTo SALIR
            End If

            If Me.chkActivo.Checked = False Then
                If Me.cdeFechaExpiracion.ValueIsDbNull Then
                    MsgBox("Debe ingresar Fecha de Expiración.", MsgBoxStyle.Critical, NombreSistema)
                    Me.ErrorProvider1.SetError(Me.grdRoles, "Debe ingresar Fecha de Expiración.")
                    Me.cdeFechaExpiracion.Focus()
                    GoTo SALIR
                End If
            End If
            VbResultado = True

SALIR:
            Return VbResultado

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdsRolesClon = Nothing
            ObjCuenta = Nothing
        End Try
    End Function
    '------------------------------------------------------------------------------------------
    '--- Implementado POr:    Josué Herrera        
    '--- Fecha de Implementacion:   24 de Julio del 2012
    '--- Descripcion:               Salvar los datos registrados de la cuenta de Usuario
    '------------------------------------------------------------------------------------------
    Private Sub SalvarAcciones()
        Dim objSegAccciones As New BOSistema.Win.SsgEntSeguridad.SsgAccionDataTable()
        Dim ObjSegServUsuarios As New BOSistema.Win.SsgEntSeguridad.SsgServicioUsuarioDataTable()
        Dim ObjSegModulos As New BOSistema.Win.SsgEntSeguridad.SsgModuloDataTable()
        Dim Comando As New BOSistema.Win.XComando

        Try
            Dim objAccionesAsignadas As New BOSistema.Win.XDataSet.xDataTable
            Dim sqlquery As String
            sqlquery = " SELECT sra.objAccionID, sa.Nombre," & _
                       "       sa.CodInterno" & _
                       " FROM SsgRolAccion sra" & _
                       "      INNER JOIN SsgRol sr ON sr.SsgRolID = sra.objRolID " & _
                       "      INNER JOIN SsgAccion sa ON sa.SsgAccionID = sra.objAccionID " & _
                       "      INNER JOIN SsgCuentaRol scr " & _
                       "      ON scr.objRolID = sr.SsgRolID " & _
                       "      INNER JOIN SsgCuenta sc" & _
                       "      ON sc.SsgCuentaID = scr.objCuentaID" & _
            String.Format("  WHERE sc.[Login] = '{0}'", txtLogin.Text)

            objAccionesAsignadas.ExecuteSql(sqlquery)

            ObjSegModulos.OrderBy = "Nombre ASC"
            ObjSegModulos.Retrieve()

            ''Módulos
            For i As Int32 = 0 To ObjSegModulos.Count - 1
                ''Pantallas
                ObjSegServUsuarios.Filter = "ObjModuloID = " & ObjSegModulos.Itemn(i).SsgModuloID
                ObjSegServUsuarios.OrderBy = "Nombre ASC"
                ObjSegServUsuarios.Retrieve()

                For m As Int32 = 0 To ObjSegServUsuarios.Count - 1
                    ''Acciones
                    objSegAccciones.Filter = "ObjServicioUsuarioID = " & ObjSegServUsuarios.Itemn(m).SsgServicioUsuarioID
                    objSegAccciones.OrderBy = "Nombre ASC"
                    objSegAccciones.Retrieve()

                    For n As Int32 = 0 To objSegAccciones.Count - 1

                        Dim tNode As TreeNode = Me.trvAccionesPosibles.Nodes(i).Nodes(m).Nodes(n)
                        '' obtener el id de acción
                        Dim idAccion As Int32 = Convert.ToInt32(tNode.Tag.ToString().Replace("NEH", ""))

                        objAccionesAsignadas.FilterLocal(String.Format(" objAccionID = {0}", idAccion))

                        If objAccionesAsignadas.CountFiltro > 0 Then
                            ''El usuario tiene asignada la acción
                            If Not Me.trvAccionesPosibles.Nodes(i).Nodes(m).Nodes(n).Checked Then
                                '' quitarle el permiso
                                Comando.ExecuteNonQuery(String.Format(" exec spHabilitarPermiso {0}, {1}, '{2}', '{3}'", 0, idAccion, InfoSistema.LoginName, Me.txtLogin.Text))
                            End If
                        Else
                            ''El usuario no tiene asignada la acción
                            If Me.trvAccionesPosibles.Nodes(i).Nodes(m).Nodes(n).Checked Then
                                '' agregarle el permiso
                                Comando.ExecuteNonQuery(String.Format(" exec spHabilitarPermiso {0}, {1}, '{2}', '{3}'", 1, idAccion, InfoSistema.LoginName, Me.txtLogin.Text))
                            End If
                        End If

                    Next

                Next

            Next

        Catch ex As Exception
            Control_Error(ex)
        Finally

            objSegAccciones.Close()
            objSegAccciones = Nothing
            ObjSegServUsuarios.Close()
            ObjSegServUsuarios = Nothing
            ObjSegModulos.Close()
            ObjSegModulos = Nothing

        End Try
    End Sub
    '------------------------------------------------------------------------------------------
    '--- Implementado POr:          
    '--- Fecha de Implementacion:   24 de Julio del 2006
    '--- Descripcion:               Salvar los datos registrados de la cuenta de Usuario
    '------------------------------------------------------------------------------------------
    Private Sub SalvarCuentaUsuario(Optional ByVal salvarRolAndPermisos As Boolean = True)
        Try
            Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
            Dim ClaveAnterior As String
            Dim i As Integer
            Dim XdsRolClon As BOSistema.Win.XDataSet.xDataTable
            Dim ObjCuentaRolDt As BOSistema.Win.SsgEntSeguridad.SsgCuentaRolDataTable
            Dim ObjCuentaRolDr As BOSistema.Win.SsgEntSeguridad.SsgCuentaRolRow
            '--------------------------------------------------
            XdsRolClon = New BOSistema.Win.XDataSet.xDataTable
            ObjCuentaRolDt = New BOSistema.Win.SsgEntSeguridad.SsgCuentaRolDataTable
            ObjCuentaRolDr = New BOSistema.Win.SsgEntSeguridad.SsgCuentaRolRow

            'Si el modo del formulario es Nuevo
            If ModoFrm = "ADD" Then
                ObjCuentaDr.NewRow()
            Else
                ClaveAnterior = ObjCuentaDr.Clave
            End If
            If Trim(Me.cboEmpleado.Text) <> "" Then
                ObjCuentaDr.objEmpleadoID = XdsEmpleadosNat("nSrhEmpleadoID")
            Else
                ObjCuentaDr.SetFieldNull("ObjEmpleadoID")
            End If

            ObjCuentaDr.nStbDelegacionProgramaID = XdsDelegaciones("nStbDelegacionProgramaID")

            ObjCuentaDr.Login = Me.txtLogin.Text
            mNombreCuenta = Trim(Me.txtLogin.Text)
            ObjCuentaDr.Clave = EncriptaToHex(Me.txtPassword.Text)
            If Me.chkActivo.Checked Then
                ObjCuentaDr.Activo = True
            Else
                ObjCuentaDr.Activo = False
            End If
            If Trim(Me.cdeFechaExpiracion.Text).Length = 0 Then
                ObjCuentaDr.SetFieldNull("FechaExpiracion")
            Else
                ObjCuentaDr.FechaExpiracion = Me.cdeFechaExpiracion.Value
            End If

            If ModoFrm = "ADD" Then
                ObjCuentaDr.UsuarioCreacion = InfoSistema.LoginName
                ObjCuentaDr.FechaCreacion = FechaServer()
            Else
                ObjCuentaDr.UsuarioModificacion = InfoSistema.LoginName
                ObjCuentaDr.FechaModificacion = FechaServer()
            End If

            ObjCuentaDr.Update()
            IdUsuario = ObjCuentaDr.SsgCuentaID
            '----------------------------------------
            If IdUsuario <= 0 Then
                MsgBox("Ha ocurrido un error al registrar" & Chr(10) & _
                       "los datos de la cuenta de Usuario.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If


            If sTipoLlamado = "PRINCIPAL" Then
                If ModoFrm = "ADD" Then
                Else
                    'Salvar el password en historico
                    XdtDatos.ExecuteSql("Insert into SsgCuentaUltimaClave(SsgCuentaID, Clave, UsuarioCreacion, FechaCreacion) values(" & ObjCuentaDr.SsgCuentaID & ",'" & Trim(txtPaswordAnterior.Text) & "'," & InfoSistema.IDCuenta & ",Getdate())")
                    GSalvadoNuevoPassword = True
                End If

            End If

            If salvarRolAndPermisos Then

                'Asignar los Roles a la Cuenta de Usuario            
                XdsRolClon = XdsRolesxApp
                For i = 0 To XdsRolClon.Count - 1

                    '-- Buscar el Rol en CuentaRol
                    ObjCuentaRolDt.Filter = "ObjRolID = " & XdsRolClon.Table.Rows(i).Item("SsgRolID") & " And ObjCuentaID = " & IdUsuario
                    ObjCuentaRolDt.Retrieve()

                    'Si no encontró el ROL
                    If ObjCuentaRolDt.Count = 0 Then

                        'Si el ROL está seleccionado AGREGARLO
                        If XdsRolClon.Table.Rows(i).Item("Selected") = True Then
                            ObjCuentaRolDr.NewRow()
                            ObjCuentaRolDr.objRolID = XdsRolClon.Table.Rows(i).Item("SsgRolID")
                            ObjCuentaRolDr.objCuentaID = ObjCuentaDr.SsgCuentaID
                            ObjCuentaRolDr.UsuarioCreacion = InfoSistema.LoginName
                            ObjCuentaRolDr.FechaCreacion = FechaServer()
                            ObjCuentaRolDr.SetFieldNull("UsuarioModificacion")
                            ObjCuentaRolDr.SetFieldNull("FechaModificacion")
                            ObjCuentaRolDr.Update()
                        End If
                    Else
                        'Si el ROL no está seleccionado pero ya existía, ELIMINARLA
                        If XdsRolClon.Table.Rows(i).Item("Selected") = False Then
                            ObjCuentaRolDt.DeleteAll()
                        End If
                    End If
                Next i

                SalvarAcciones()

            End If

            '-----------------------------
            AccionUsuario = AccionBoton.BotonAceptar
            ObjCuentaDr = Nothing
            ObjCuentaRolDt = Nothing
            ObjCuentaRolDr = Nothing
            XdsRolClon = Nothing
            '-----------------------------
            If salvarRolAndPermisos Then
                Me.EndSaveUsuario()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub EndSaveUsuario()
        'Enviar mensaje satisfactorio
        If ModoFrm = "ADD" Then
            MsgBox("Se agregó una Cuenta de Usuario de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
        Else
            MsgBox("Se editaron los datos de la Cuenta de " & Chr(10) & _
                   "Usuario de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)

        End If
        
        'Cerrar el formulario
        Me.Close()
    End Sub

    Private Sub txtLogin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtLogin.TextChanged
        vbModifico = True
    End Sub
    Private Sub txtPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPassword.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtConfirmacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConfirmacion.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaCreacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCreacion.TextChanged
        vbModifico = True
    End Sub
    Private Sub cdeFechaExpiracion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaExpiracion.TextChanged
        vbModifico = True
    End Sub
    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        vbModifico = True
        If Me.chkActivo.Checked = True Then
            Me.cdeFechaExpiracion.Enabled = False
            Me.cdeFechaExpiracion.Value = Me.cdeFechaExpiracion.ValueIsDbNull
        ElseIf Me.chkActivo.Checked = False Then
            Me.cdeFechaExpiracion.Enabled = True
        End If
    End Sub
    Private Sub grdRoles_AfterColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles grdRoles.AfterColEdit
        vbModifico = True
    End Sub
    Private Sub cboEmpleado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpleado.TextChanged
        vbModifico = True
    End Sub

    Private Sub btnMarcarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarcarTodo.Click
        SeleccionarDesmarcar(True)
    End Sub


    Private Sub SeleccionarDesmarcar(ByVal checked As Boolean)
        'Dim Contador As Integer
        Dim treeNode As TreeNode = Me.trvAccionesPosibles.SelectedNode
        treeNode.Checked = checked
        For Each n As TreeNode In treeNode.Nodes
            n.Checked = checked
            RecorrerNodos(n, checked)
        Next

        'Me.trvAccionesPosibles.Nodes.Count

    End Sub
    Private Sub SeleccionarDesmarcarGrid(ByVal checked As Boolean)

        Dim Contador As Integer

        For Contador = 0 To Me.grdRoles.RowCount - 1
            grdRoles.Item(Contador, 0) = checked
        Next

  
    End Sub


    Private Sub RecorrerNodos(ByVal treeNode As TreeNode, ByVal checked As Boolean)
        Try
            'Si el nodo que recibimos tiene hijos se recorrerá
            'para luego verificar si esta o no checado
            For Each tn As TreeNode In treeNode.Nodes
                'Se Verifica si esta marcado...
                If tn.Checked = Not checked Then
                    'Si esta marcado mostramos el texto del nodo
                    tn.Checked = checked
                End If
                'Ahora hago verificacion a los hijos del nodo actual            
                'Esta iteración no acabara hasta llegar al ultimo nodo principal
                RecorrerNodos(tn, checked)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub btnDesmarcarTodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesmarcarTodo.Click
        SeleccionarDesmarcar(False)
    End Sub

    Private Sub CargarUsuarios()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable

        Try

            Dim StrNombre As String = "Usuarios"

            Dim Strsql As String

            Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre, sc.[Login] " & _
                     " From vwStbEmpleado a " & _
                     "      INNER JOIN SsgCuenta sc " & _
                     "      ON sc.objEmpleadoID = a.nSrhEmpleadoID " & _
                     " Order by a.nCodPersona"

            If XdsUsuarios.ExistTable(StrNombre) Then
                XdsUsuarios(StrNombre).ExecuteSql(Strsql)
            Else
                XdsUsuarios.NewTable(Strsql, StrNombre)
                XdsUsuarios(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboUsuarios.DataSource = XdsUsuarios(StrNombre).Source
            Me.cboUsuarios.Rebind()

            'Ubicarse en el registro recomendado de parámetros:
            If XdsUsuarios(StrNombre).Count > 0 Then
                XdsUsuarios(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo: 

            Me.cboUsuarios.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboUsuarios.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboUsuarios.Splits(0).DisplayColumns("nCodPersona").Width = 50
            Me.cboUsuarios.Splits(0).DisplayColumns("sNombre").Width = 150
            Me.cboUsuarios.Columns("nCodPersona").Caption = "Código"
            Me.cboUsuarios.Columns("sNombre").Caption = "Nombre Empleado"
            Me.cboUsuarios.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboUsuarios.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboUsuarios.Splits(0).DisplayColumns("Login").Visible = False

            ''Selecionar al primer usuario
            Me.cboUsuarios.SelectedIndex = 0

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub cboUsuarios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsuarios.TextChanged
        If cboUsuarios.SelectedIndex >= 0 Then
            txtLoginOfTransfer.Text = Me.cboUsuarios.Columns("Login").Value
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim XAdapter As New BOSistema.Win.XComando
        Try
            ''Conceder o denegar Roles
            If Not String.IsNullOrEmpty(Me.txtLogin.Text) Then
                '' Si el usuario aun no ha sido creado 
                If ModoFrm = "ADD" Then
                    Me.SalvarCuentaUsuario(False)
                    XAdapter.ExecuteNonQuery(String.Format(" exec spConcederRoles '{0}','{1}','{2}',{3}", Me.txtLogin.Text, Me.cboUsuarios.Columns("Login").Value, InfoSistema.LoginName, IIf(Me.rdoConceder.Checked, 1, 0)))
                Else
                    XAdapter.ExecuteNonQuery(String.Format(" exec spConcederRoles '{0}','{1}','{2}',{3}", Me.txtLogin.Text, Me.cboUsuarios.Columns("Login").Value, InfoSistema.LoginName, IIf(Me.rdoConceder.Checked, 1, 0)))
                End If
                '' Refrescar los Roles y Permisos
                Me.CargarRolesxAplicacion()
                Me.LlenarGridAccionesPosibles()
                MsgBox("Se editaron los datos de la Cuenta de " & Chr(10) & _
                                       "Usuario de forma satisfactoria.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XAdapter.Close()
            XAdapter = Nothing
        End Try
    End Sub

    Private Sub cmdRolesxAcción_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRolesxAcción.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim XdsEmpleadosNat As BOSistema.Win.XDataSet.xDataTable
        Dim strAccion As String, Strsql As String
        Dim idAccion As Integer

        Try
            XdsEmpleadosNat = New BOSistema.Win.XDataSet.xDataTable

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.NombreReporte = "RepSsgSG6.rpt"
            frmVisor.Text = "Listado de Roles por Acción"

            strAccion = trvAccionesPosibles.SelectedNode.Text
            Strsql = "SELECT SsgAccionID FROM dbo.SsgAccion WHERE Nombre = '" & strAccion & "'"
            XdsEmpleadosNat.ExecuteSql(Strsql)
            idAccion = XdsEmpleadosNat("SsgAccionID")

            frmVisor.SQLQuery = " Select * From vwSsgAccionRol Where SsgAccionID='" & idAccion & "'"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub cmdAccionesUsuario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAccionesUsuario.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.NombreReporte = "RepSsgSG8.rpt"
            frmVisor.Text = "Listado de Acción por Usuario"
            frmVisor.SQLQuery = " Select * From vwSsgAccionUsuario Where SsgCuentaID = '" & IdUsuario & "' order by Nombre"
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub BtnMarcarTodoRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMarcarTodoRoles.Click
        SeleccionarDesmarcarGrid(True)
    End Sub

    Private Sub BtnDesMarcarTodoRoles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDesMarcarTodoRoles.Click
        SeleccionarDesmarcarGrid(False)
    End Sub

    Private Sub btnDesbloquear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesbloquear.Click
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            XdtDatos.ExecuteSql(" Delete FROM         dbo.SsgCuentaBloqueada  WHERE     (SsgCuentaID IN  (SELECT     SsgCuentaBloqueada_1.SsgCuentaID FROM          dbo.SsgCuentaBloqueada AS SsgCuentaBloqueada_1 INNER JOIN  dbo.SsgCuenta ON SsgCuentaBloqueada_1.SsgCuentaID = dbo.SsgCuenta.SsgCuentaID  WHERE      ({ fn UCASE(dbo.SsgCuenta.Login) } = { fn UCASE('" & txtLogin.Text & "') })))")
            MsgBox("Cuenta ha sido Desbloqueada.", MsgBoxStyle.Critical, NombreSistema)
            Me.btnDesbloquear.Visible = False
            Me.lblBloqueada.Visible = False
        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub
End Class