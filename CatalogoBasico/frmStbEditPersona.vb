' ------------------------------------------------------------------------
' Autor:                Edgard Delgado
' Fecha:                17 Septiembre 2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditPersona.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Personas Naturales, Personas Juridicas y Empleados
'-------------------------------------------------------------------------
Public Class frmStbEditPersona

    Dim CONTROLaCTIVO As String



    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdStbPersona As Long
    Dim TPersona As String ' E = Empleado, J = Juridica, N = Natural
    Dim strFecha As String
    Dim CPersona As Boolean ' True = Cambiar Persona Natural a Empleado, False = No hace nada

    '-- Clases para procesar la informacion de los combos
    Dim XdsPersona As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjPersonaDT As BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
    Dim ObjPersonaDR As BOSistema.Win.StbEntCatalogo.StbPersonaRow

    Dim ObjEmpleadoDT As BOSistema.Win.SrhEntEmpleado.SrhEmpleadoDataTable
    Dim ObjEmpleadoDR As BOSistema.Win.SrhEntEmpleado.SrhEmpleadoRow


    Dim ObjProveedorDT As BOSistema.Win.SrhEntEmpleado.SrhProveedorDataTable
    Dim ObjProveedorDR As BOSistema.Win.SrhEntEmpleado.SrhProveedorRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Sucursal.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Persona que corresponde al campo
    'StbPersonaID de la tabla StbPersona.
    Public Property IdPersona() As Long
        Get
            IdPersona = IdStbPersona
        End Get
        Set(ByVal value As Long)
            IdStbPersona = value
        End Set
    End Property

    Public Property TipoPersona() As String
        Get
            Return TPersona
        End Get
        Set(ByVal value As String)
            TPersona = value
        End Set
    End Property

    Public Property CambioPersona() As Boolean
        Get
            Return CPersona
        End Get
        Set(ByVal value As Boolean)
            CPersona = value
        End Set
    End Property

    Private Function EncabezadoTipoPersona() As String
        Select Case Me.TipoPersona
            Case "E" : Return "Empleado"
            Case "J" : Return "Persona Juridica"
            Case "N" : Return "Persona Natural"
            Case "P" : Return "Proveedor"
            Case Else : Return ""
        End Select
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       frmStbEditPersona_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditPersona_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjPersonaDT.Close()
                ObjPersonaDT = Nothing

                ObjPersonaDR.Close()
                ObjPersonaDR = Nothing

                XdsPersona.Close()
                XdsPersona = Nothing
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
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       frmStbEditPersona_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de la Persona Natural, Juridica o Empleado
    '                       en caso de estar en el modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditPersona_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            If Me.TipoPersona = "E" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Empleados")
            ElseIf Me.TipoPersona = "J" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Personas Jurídicas")
            ElseIf Me.TipoPersona = "N" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Personas Naturales")
            ElseIf Me.TipoPersona = "P" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Proveedores")

            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición
            'cargar los datos de la Persona.
            If ModoFrm = "UPD" Then
                Select Case Me.TipoPersona
                    Case "E" : CargarEmpleado()
                    Case "J" : CargarPersonaJuridica()
                    Case "N" : CargarPersonaNatural()
                    Case "P" : CargarPersonaJuridica()
                End Select
            Else

                Select Case Me.TipoPersona
                    Case "E" : Me.txtPrimerNombreEP.Select()
                    Case "J" : Me.txtNombreInstitucionPJ.Select()
                    Case "N" : Me.txtPrimerNombrePN.Select()
                    Case "P" : Me.txtNombreInstitucionPJ.Select()
                        Me.grpObligaciones.Visible = True
                        chkActivoPJ.Visible = False
                        chkActivoPP.Visible = True
                        ''NO PORNER AUTOMATICAMENTE ACTIVOS SI ES UN UPDATE

                        Me.chkActivoPP.Checked = True
                        Me.chkActivoPJ.Checked = True
                        'ver analisis
                End Select

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
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar " & Me.EncabezadoTipoPersona
            Else
                Me.Text = "Modificar " & Me.EncabezadoTipoPersona
            End If

            ObjPersonaDT = New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
            ObjPersonaDR = New BOSistema.Win.StbEntCatalogo.StbPersonaRow
            XdsPersona = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            Select Case Me.TipoPersona
                Case "E"
                    Me.grpPN.Enabled = False : Me.grpPN.Visible = False
                    Me.grpPJ.Enabled = False : Me.grpPJ.Visible = False
                    Me.grpEP.Enabled = True : Me.grpEP.Visible = True
                    Me.cmdAceptar.Location = New Point(Me.cmdAceptar.Location.X, grpEP.Location.Y + grpEP.Height + 5)
                    Me.cmdCancelar.Location = New Point(Me.cmdCancelar.Location.X, grpEP.Location.Y + grpEP.Height + 5)
                    Me.Height = cmdAceptar.Location.Y + cmdAceptar.Height + 30

                    Me.cboCargo.ClearFields()
                    Me.cboProfesion.ClearFields()

                    CargarCargo(0)
                    CargarProfesion(0)

                    'Solo para la Tabla de Empleado
                    ObjEmpleadoDT = New BOSistema.Win.SrhEntEmpleado.SrhEmpleadoDataTable
                    ObjEmpleadoDR = New BOSistema.Win.SrhEntEmpleado.SrhEmpleadoRow

                    If ModoFrm = "ADD" Then

                        ObjPersonaDR = ObjPersonaDT.NewRow
                        ObjEmpleadoDR = ObjEmpleadoDT.NewRow

                        'Inicializar los Length de los campos
                        Me.txtPrimerNombreEP.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre1")
                        Me.txtSegundoNombreEP.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre2")
                        Me.txtPrimerApellidoEP.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido1RS")
                        Me.txtSegundoApellidoEP.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido2")
                        Me.txtDireccionEP.MaxLength = ObjPersonaDR.GetColumnLenght("sDireccion")
                        Me.txtTelefonoEP.MaxLength = ObjPersonaDR.GetColumnLenght("sTelefono")
                        Me.txtCelularEP.MaxLength = ObjPersonaDR.GetColumnLenght("sCelular")
                        Me.txtFaxEP.MaxLength = ObjPersonaDR.GetColumnLenght("sFax")
                        Me.txtEmailEP.MaxLength = ObjPersonaDR.GetColumnLenght("sEMail")
                        Me.txtNoInssEP.MaxLength = ObjEmpleadoDR.GetColumnLenght("sNumINSS")

                        Me.chkActivoEP.Checked = True
                        Me.chkActivoEP.Enabled = False
                    Else
                        Me.chkActivoEP.Enabled = True
                    End If

                    Dim ObjValorParametros As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
                    Dim strFecha As String

                    ObjValorParametros.Filter = "nStbValorParametroID = 4 And nStbParametroId = 4"
                    ObjValorParametros.Retrieve()
                    strFecha = Strings.Mid(ObjValorParametros.ValueField("sValorParametro"), 1, 2) & "-" & _
                            Strings.Mid(ObjValorParametros.ValueField("sValorParametro"), 3, 2) & "-" & _
                            Strings.Mid(ObjValorParametros.ValueField("sValorParametro"), 5, 4)

                    Me.cdeFechaIngresoEP.Calendar.MinDate = CDate(strFecha)
                    Me.cdeFechaEgresoEP.Calendar.MinDate = CDate(strFecha)

                    ObjValorParametros.Close()
                    ObjValorParametros = Nothing

                Case "J", "P"
                    Me.grpPN.Enabled = False : Me.grpPN.Visible = False
                    Me.grpEP.Enabled = False : Me.grpEP.Visible = False
                    Me.grpPJ.Enabled = True : Me.grpPJ.Visible = True
                    Me.cmdAceptar.Location = New Point(Me.cmdAceptar.Location.X, grpPJ.Location.Y + grpPJ.Height + 5)
                    Me.cmdCancelar.Location = New Point(Me.cmdCancelar.Location.X, grpPJ.Location.Y + grpPJ.Height + 5)
                    Me.Height = cmdAceptar.Location.Y + cmdAceptar.Height + 30

                    Me.Label7.Visible = True
                    Me.chkChequeARepresentante.Visible = True


                    'Solo para la Tabla de Empleado
                    ObjProveedorDT = New BOSistema.Win.SrhEntEmpleado.SrhProveedorDataTable
                    ObjProveedorDR = New BOSistema.Win.SrhEntEmpleado.SrhProveedorRow

                    If ModoFrm = "ADD" Then

                        ObjPersonaDR = ObjPersonaDT.NewRow

                        If Me.TipoPersona = "P" Then
                            ObjProveedorDR = ObjProveedorDT.NewRow
                        End If



                        'Inicializar los Length de los campos
                        Me.txtNombreInstitucionPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre1")
                        Me.txtRazonSocialPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido1RS")
                        Me.txtSiglasPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sSiglas")
                        Me.txtDireccionPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sDireccion")
                        Me.txtTelefonoPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sTelefono")
                        Me.txtCelularPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sCelular")
                        Me.txtFaxPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sFax")
                        Me.txtEmailPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sEMail")
                        Me.txtSitioWebPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sSitioWeb")
                        Me.txtRepresentanteLegalPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sRepresentanteLegal")
                        Me.txtNombreContactoPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre2")
                        If Me.TipoPersona = "J" Then
                            Me.chkActivoPJ.Checked = True
                            Me.chkActivoPJ.Enabled = False
                        Else
                            Me.chkActivoPP.Checked = True
                            Me.chkActivoPP.Enabled = False
                        End If



                    Else
                        If Me.TipoPersona = "J" Then
                            Me.chkActivoPJ.Enabled = True
                            Me.chkActivoPP.Enabled = True
                        End If


                    End If

                Case "N"
                    Me.grpEP.Enabled = False : Me.grpEP.Visible = False
                    Me.grpPJ.Enabled = False : Me.grpPJ.Visible = False
                    Me.grpPN.Enabled = True : Me.grpPN.Visible = True
                    Me.cmdAceptar.Location = New Point(Me.cmdAceptar.Location.X, grpPN.Location.Y + grpPN.Height + 5)
                    Me.cmdCancelar.Location = New Point(Me.cmdCancelar.Location.X, grpPN.Location.Y + grpPN.Height + 5)
                    Me.Height = cmdAceptar.Location.Y + cmdAceptar.Height + 30

                    If ModoFrm = "ADD" Then

                        ObjPersonaDR = ObjPersonaDT.NewRow

                        'Inicializar los Length de los campos
                        Me.txtPrimerNombrePN.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre1")
                        Me.txtSegundoNombrePN.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre2")
                        Me.txtPrimerApellidoPN.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido1RS")
                        Me.txtSegundoApellidoPN.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido2")
                        Me.txtDireccionPN.MaxLength = ObjPersonaDR.GetColumnLenght("sDireccion")
                        Me.txtTelefonoPN.MaxLength = ObjPersonaDR.GetColumnLenght("sTelefono")
                        Me.txtCelularPN.MaxLength = ObjPersonaDR.GetColumnLenght("sCelular")
                        Me.txtFaxPN.MaxLength = ObjPersonaDR.GetColumnLenght("sFax")
                        Me.txtEmailPN.MaxLength = ObjPersonaDR.GetColumnLenght("sEMail")

                        Me.chkActivoPN.Checked = True
                        Me.chkActivoPN.Enabled = False
                    Else
                        Me.chkActivoPN.Enabled = True
                    End If

            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       CargarPersonaNatural
    ' Descripción:          Este procedimiento permite cargar los datos de la Persona Natural
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarPersonaNatural()
        Try

            '-- Buscar la Persona corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjPersonaDT.Filter = "nStbPersonaId = " & Me.IdPersona
            ObjPersonaDT.Retrieve()
            If ObjPersonaDT.Count = 0 Then
                Exit Sub
            End If
            ObjPersonaDR = ObjPersonaDT.Current

            'Codigo Interno
            Me.txtCodigoPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("nCodigo"), ObjPersonaDR.nCodigo, "")

            Me.txtPrimerNombrePN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre1"), ObjPersonaDR.sNombre1, "")
            Me.txtSegundoNombrePN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre2"), ObjPersonaDR.sNombre2, "")
            Me.txtPrimerApellidoPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sApellido1RS"), ObjPersonaDR.sApellido1RS, "")
            Me.txtSegundoApellidoPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sApellido2"), ObjPersonaDR.sApellido2, "")
            Me.mtbNumCedulaPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNumCedula"), ObjPersonaDR.sNumCedula, "")
            Me.txtDireccionPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sDireccion"), ObjPersonaDR.sDireccion, "")
            Me.txtTelefonoPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sTelefono"), ObjPersonaDR.sTelefono, "")
            Me.txtCelularPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sCelular"), ObjPersonaDR.sCelular, "")
            Me.txtFaxPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sFax"), ObjPersonaDR.sFax, "")
            If Not ObjPersonaDR.IsFieldNull("sSexo") Then
                Me.rbSexoMasculinoPN.Checked = IIf(ObjPersonaDR.sSexo = "M", True, False)
                Me.rbSexoFemeninoPN.Checked = IIf(ObjPersonaDR.sSexo = "F", True, False)
            Else
                Me.rbSexoMasculinoPN.Checked = False
                Me.rbSexoFemeninoPN.Checked = False
            End If
            Me.txtEmailPN.Text = IIf(Not ObjPersonaDR.IsFieldNull("sEMail"), ObjPersonaDR.sEMail, "")
            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") Then
                Me.chkActivoPN.Checked = IIf(ObjPersonaDR.nPersonaActiva = 1, True, False)
            End If

            'Activo
            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") Then
                If ObjPersonaDR.nPersonaActiva <> 1 Then
                    For Each ctrl As Control In Me.grpPN.Controls
                        If InStr(ctrl.Name, "lbl") = 0 Then
                            ctrl.Enabled = IIf(InStr(ctrl.Name, "chkActivo") <> 0, True, False)
                        End If
                    Next
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtPrimerNombrePN.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre1")
            Me.txtSegundoNombrePN.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre2")
            Me.txtPrimerApellidoPN.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido1RS")
            Me.txtSegundoApellidoPN.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido2")
            Me.txtDireccionPN.MaxLength = ObjPersonaDR.GetColumnLenght("sDireccion")
            Me.txtTelefonoPN.MaxLength = ObjPersonaDR.GetColumnLenght("sTelefono")
            Me.txtCelularPN.MaxLength = ObjPersonaDR.GetColumnLenght("sCelular")
            Me.txtFaxPN.MaxLength = ObjPersonaDR.GetColumnLenght("sFax")
            Me.txtEmailPN.MaxLength = ObjPersonaDR.GetColumnLenght("sEMail")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       CargarEmpleado
    ' Descripción:          Este procedimiento permite cargar los datos del Empleado
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarEmpleado()
        Try

            '-- Buscar la Persona corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjPersonaDT.Filter = "nStbPersonaId = " & Me.IdPersona
            ObjPersonaDT.Retrieve()
            If ObjPersonaDT.Count = 0 Then
                Exit Sub
            End If
            ObjPersonaDR = ObjPersonaDT.Current

            ObjEmpleadoDT.Filter = "nStbPersonaId = " & Me.IdPersona
            ObjEmpleadoDT.Retrieve()
            If Me.CambioPersona = False Then
                If ObjEmpleadoDT.Count = 0 Then
                    Exit Sub
                End If
                ObjEmpleadoDR = ObjEmpleadoDT.Current
            Else
                ObjEmpleadoDR = ObjEmpleadoDT.NewRow
            End If

            'Codigo Interno
            Me.txtCodigoEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("nCodigo"), ObjPersonaDR.nCodigo, "")

            Me.txtPrimerNombreEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre1"), ObjPersonaDR.sNombre1, "")
            Me.txtSegundoNombreEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre2"), ObjPersonaDR.sNombre2, "")
            Me.txtPrimerApellidoEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sApellido1RS"), ObjPersonaDR.sApellido1RS, "")
            Me.txtSegundoApellidoEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sApellido2"), ObjPersonaDR.sApellido2, "")
            Me.mtbNumCedulaEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNumCedula"), ObjPersonaDR.sNumCedula, "")
            Me.txtDireccionEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sDireccion"), ObjPersonaDR.sDireccion, "")
            Me.txtTelefonoEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sTelefono"), ObjPersonaDR.sTelefono, "")
            Me.txtCelularEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sCelular"), ObjPersonaDR.sCelular, "")
            Me.txtFaxEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sFax"), ObjPersonaDR.sFax, "")
            If Not ObjPersonaDR.IsFieldNull("sSexo") Then
                Me.rbSexoMasculinoEP.Checked = IIf(ObjPersonaDR.sSexo = "M", True, False)
                Me.rbSexoFemeninoEP.Checked = IIf(ObjPersonaDR.sSexo = "F", True, False)
            Else
                Me.rbSexoMasculinoEP.Checked = False
                Me.rbSexoFemeninoEP.Checked = False
            End If
            Me.txtEmailEP.Text = IIf(Not ObjPersonaDR.IsFieldNull("sEMail"), ObjPersonaDR.sEMail, "")
            If Me.CambioPersona = False Then
                Me.txtNoInssEP.Text = IIf(Not ObjEmpleadoDR.IsFieldNull("sNumINSS"), ObjEmpleadoDR.sNumINSS, "")
                Me.cdeFechaIngresoEP.Value = IIf(Not ObjEmpleadoDR.IsFieldNull("dFechaIngreso"), ObjEmpleadoDR.dFechaIngreso, DBNull.Value)
                Me.cdeFechaEgresoEP.Value = IIf(Not ObjEmpleadoDR.IsFieldNull("dFechaEgreso"), ObjEmpleadoDR.dFechaEgreso, DBNull.Value)
                Me.txtSalarioEP.Text = IIf(Not ObjEmpleadoDR.IsFieldNull("nSalario"), ObjEmpleadoDR.nSalario, "")
            End If
            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") Then
                Me.chkActivoEP.Checked = IIf(ObjPersonaDR.nPersonaActiva = 1, True, False)
            End If

            'Activo Persona y Empleado - Desactiva controles si esta desactivado la persona
            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") And Not ObjEmpleadoDR.IsFieldNull("nActivo") Then
                If ObjPersonaDR.nPersonaActiva <> 1 And ObjEmpleadoDR.nActivo <> 1 Then
                    For Each ctrl As Control In Me.grpEP.Controls
                        If InStr(ctrl.Name, "lbl") = 0 Then
                            ctrl.Enabled = IIf(InStr(ctrl.Name, "chkActivo") <> 0, True, False)
                        End If
                    Next
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtPrimerNombreEP.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre1")
            Me.txtSegundoNombreEP.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre2")
            Me.txtPrimerApellidoEP.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido1RS")
            Me.txtSegundoApellidoEP.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido2")
            Me.txtDireccionEP.MaxLength = ObjPersonaDR.GetColumnLenght("sDireccion")
            Me.txtTelefonoEP.MaxLength = ObjPersonaDR.GetColumnLenght("sTelefono")
            Me.txtCelularEP.MaxLength = ObjPersonaDR.GetColumnLenght("sCelular")
            Me.txtFaxEP.MaxLength = ObjPersonaDR.GetColumnLenght("sFax")
            Me.txtEmailEP.MaxLength = ObjPersonaDR.GetColumnLenght("sEMail")
            Me.txtNoInssEP.MaxLength = ObjEmpleadoDR.GetColumnLenght("sNumINSS")

            'Cargo
            If Not ObjEmpleadoDR.IsFieldNull("nSrhCargoID") Then
                CargarCargo(ObjEmpleadoDR.nSrhCargoID)
                If Me.cboCargo.ListCount > 0 Then
                    Me.cboCargo.SelectedIndex = 0
                    XdsPersona("Cargo").SetCurrentByID("nSrhCargoID", ObjEmpleadoDR.nSrhCargoID)
                End If
            Else
                Me.cboCargo.Text = ""
                Me.cboCargo.SelectedIndex = -1
            End If

            'Profesión
            If Not ObjEmpleadoDR.IsFieldNull("nStbProfesionID") Then
                CargarProfesion(ObjEmpleadoDR.nStbProfesionID)
                If Me.cboProfesion.ListCount > 0 Then
                    Me.cboProfesion.SelectedIndex = 0
                    XdsPersona("Profesion").SetCurrentByID("nStbProfesionID", ObjEmpleadoDR.nStbProfesionID)
                End If
            Else
                Me.cboProfesion.Text = ""
                Me.cboProfesion.SelectedIndex = -1
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       CargarPersonaJuridica
    ' Descripción:          Este procedimiento permite cargar los datos del Persona Juridica
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarPersonaJuridica()
        Try


            'Dim SRUC As String


            '-- Buscar la Persona corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjPersonaDT.Filter = "nStbPersonaId = " & Me.IdPersona
            ObjPersonaDT.Retrieve()
            If ObjPersonaDT.Count = 0 Then
                Exit Sub
            End If
            ObjPersonaDR = ObjPersonaDT.Current

            txtCodigoPP.Visible = False
            txtCodigoPJ.Visible = True

            'Codigo Interno
            Me.txtCodigoPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("nCodigo"), ObjPersonaDR.nCodigo, "")

            Me.txtNombreInstitucionPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre1"), ObjPersonaDR.sNombre1, "")
            Me.txtRazonSocialPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sApellido1RS"), ObjPersonaDR.sApellido1RS, "")
            Me.txtSiglasPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sSiglas"), ObjPersonaDR.sSiglas, "")
            Me.mtbNumCedulaPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNumCedula"), ObjPersonaDR.sNumCedula, "")


            'Me.mtbNumRucPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNumRUC"), ObjPersonaDR.sNumRUC, "")

            ' tipo StbPersonaDatoFiscal
            Dim ObjTmpPersona As New BOSistema.Win.XDataSet.xDataTable
            ObjTmpPersona.ExecuteSql("Select sNumRUC From StbPersonaDatoFiscal Where nStbPersonaID=" & Me.IdPersona)
            If ObjTmpPersona.Count > 0 Then
                If IsDBNull(ObjTmpPersona.ValueField("sNumRUC")) Then

                    Me.txtNumRucPJ.Text = ""
                Else
                    Me.txtNumRucPJ.Text = ObjTmpPersona.ValueField("sNumRUC")
                End If
                'Me.txtNumRucPJ = IIf(Not ObjTmpPersona.ValueField("sNumRUC"), ObjTmpPersona.ValueField("sNumRUC").ToString(), "")
            End If

            'Conseguri el num ruc verdadero de la tabla StbPersonaDatoFiscal por que con la ccaja virtual al aumentar el campo daria problemas.


            Me.cdeFechaAperturaPJ.Value = IIf(Not ObjPersonaDR.IsFieldNull("dFechaNacApertura"), ObjPersonaDR.dFechaNacApertura, DBNull.Value)
            Me.txtDireccionPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sDireccion"), ObjPersonaDR.sDireccion, "")
            Me.txtTelefonoPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sTelefono"), ObjPersonaDR.sTelefono, "")
            Me.txtCelularPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sCelular"), ObjPersonaDR.sCelular, "")
            Me.txtFaxPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sFax"), ObjPersonaDR.sFax, "")
            Me.txtEmailPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sEMail"), ObjPersonaDR.sEMail, "")
            Me.txtSitioWebPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sSitioWeb"), ObjPersonaDR.sSitioWeb, "")
            Me.txtRepresentanteLegalPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sRepresentanteLegal"), ObjPersonaDR.sRepresentanteLegal, "")
            Me.txtNombreContactoPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre2"), ObjPersonaDR.sNombre2, "")
            If Not ObjPersonaDR.IsFieldNull("nOtorgaCredito") Then
                Me.chkOtorgaCreditosPJ.Checked = IIf(ObjPersonaDR.nOtorgaCredito = 1, True, False)
                If ObjPersonaDR.nOtorgaCredito = 1 Then
                    'Verificar si ya esta como referencia y si es asi no dejar que lo modifiquen
                    Dim ObjCredito1 As New BOSistema.Win.SclEntFicha.SclReferenciaCrediticiaDataTable
                    Dim ObjCredito2 As New BOSistema.Win.SclEntFicha.SclOtroCreditoVigenteDataTable

                    ObjCredito1.Filter = "nStbPersonaCreditoId = " & Me.IdPersona
                    ObjCredito1.Retrieve()

                    ObjCredito2.Filter = "nStbPersonaCreditoId = " & Me.IdPersona & " Or nStbPersonaCreditoVerificadaId = " & Me.IdPersona
                    ObjCredito2.Retrieve()

                    If ObjCredito1.Count > 0 Or ObjCredito2.Count > 0 Then
                        Me.chkOtorgaCreditosPJ.Enabled = False
                    End If

                    ObjCredito1.Close()
                    ObjCredito1 = Nothing

                    ObjCredito2.Close()
                    ObjCredito2 = Nothing

                End If
            End If
            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") Then
                Me.chkActivoPJ.Checked = IIf(ObjPersonaDR.nPersonaActiva = 1, True, False)

                Dim ObjTmpProveedor As New BOSistema.Win.XDataSet.xDataTable
                ObjTmpProveedor.ExecuteSql("SELECT nActivo FROM dbo.SrhProveedor  WHERE nStbPersonaID =" & Me.IdPersona)

                If Not IsDBNull(ObjTmpProveedor.ValueField("nActivo")) Then
                    If ObjTmpProveedor.ValueField("nActivo") = 1 Then
                        chkActivoPP.Checked = True
                    Else
                        chkActivoPP.Checked = False

                    End If


                End If
            End If


            If Not ObjPersonaDR.IsFieldNull("nLugarPagosPrograma") Then
                Me.chkDesembolsoPago.Checked = IIf(ObjPersonaDR.nLugarPagosPrograma = 1, True, False)
            End If

            'Activo

            'If Me.TipoPersona = "J" Then


            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") Then
                If ObjPersonaDR.nPersonaActiva <> 1 Then
                    For Each ctrl As Control In Me.grpPJ.Controls
                        If InStr(ctrl.Name, "lbl") = 0 Then
                            ctrl.Enabled = IIf(InStr(ctrl.Name, "chkActivo") <> 0, True, False)
                        End If
                    Next
                End If
            End If


            'End If


            'Inicializar los Length de los campos
            Me.txtNombreInstitucionPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre1")
            Me.txtRazonSocialPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido1RS")
            Me.txtSiglasPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sSiglas")
            Me.txtDireccionPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sDireccion")
            Me.txtTelefonoPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sTelefono")
            Me.txtCelularPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sCelular")
            Me.txtFaxPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sFax")
            Me.txtEmailPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sEMail")
            Me.txtSitioWebPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sSitioWeb")
            Me.txtRepresentanteLegalPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sRepresentanteLegal")
            Me.txtNombreContactoPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre2")


            If Me.TipoPersona = "P" Then 'Es proveedor
                txtCodigoPP.Visible = True
                txtCodigoPJ.Visible = False
                chkActivoPJ.Visible = False
                chkActivoPP.Visible = True
                grpObligaciones.Visible = True
                '-- Buscar la Persona corerspondiente al Id especificado
                '-- como parámetro, en los casos que se esté editando una.
                'ObjProveedorDT.Filter = "nStbPersonaId = " & Me.IdPersona
                'ObjProveedorDT.Retrieve()
                'If ObjProveedorDT.Count = 0 Then
                '    Exit Sub
                'End If
                'ObjPersonaDR = ObjPersonaDT.Current

                ObjProveedorDT.Filter = "nStbPersonaId = " & Me.IdPersona
                ObjProveedorDT.Retrieve()
                If Me.CambioPersona = False Then
                    If ObjProveedorDT.Count = 0 Then
                        Exit Sub
                    End If
                    ObjProveedorDR = ObjProveedorDT.Current
                Else
                    'Es primera vez que se ingresa la persona proveedor
                    ObjProveedorDR = ObjProveedorDT.NewRow
                    Me.txtCodigoPJ.Visible = True
                    Me.txtCodigoPP.Visible = False
                    'chkActivoPJ.Visible = True
                    chkActivoPP.Visible = True
                    chkActivoPP.Checked = True
                End If

                If Not ObjProveedorDR.IsFieldNull("sCodigo") Then
                    Me.txtCodigoPP.Text = ObjProveedorDR.sCodigo
                End If

                If Not ObjProveedorDR.IsFieldNull("nPagaIR") Then
                    Me.chkPagaIR.Checked = IIf(ObjProveedorDR.nPagaIR = 1, True, False)
                End If
                If Not ObjProveedorDR.IsFieldNull("nPagaIVA") Then
                    Me.chkPagaIVA.Checked = IIf(ObjProveedorDR.nPagaIVA = 1, True, False)
                End If
                If Not ObjProveedorDR.IsFieldNull("sDescripcionNegocio") Then
                    Me.txtDescripcionNegocio.Text = ObjProveedorDR.sDescripcionNegocio

                End If

                If Not ObjPersonaDR.IsFieldNull("nChequeARepresentanteLegal") Then
                    Me.chkChequeARepresentante.Checked = IIf(ObjPersonaDR.nChequeARepresentanteLegal = 1, True, False)
                End If


                If Not ObjProveedorDR.IsFieldNull("nActivo") Then
                    Me.chkActivoPP.Checked = IIf(ObjProveedorDR.nActivo = 1, True, False)
                End If


            Else
                chkActivoPJ.Visible = True
                chkActivoPP.Visible = False
            End If



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CargarP()
        Try

            '-- Buscar la Persona corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjPersonaDT.Filter = "nStbPersonaId = " & Me.IdPersona
            ObjPersonaDT.Retrieve()
            If ObjPersonaDT.Count = 0 Then
                Exit Sub
            End If
            ObjPersonaDR = ObjPersonaDT.Current

            'Codigo Interno
            Me.txtCodigoPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("nCodigo"), ObjPersonaDR.nCodigo, "")

            Me.txtNombreInstitucionPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre1"), ObjPersonaDR.sNombre1, "")
            Me.txtRazonSocialPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sApellido1RS"), ObjPersonaDR.sApellido1RS, "")
            Me.txtSiglasPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sSiglas"), ObjPersonaDR.sSiglas, "")
            Me.txtNumRucPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNumRUC"), ObjPersonaDR.sNumRUC, "")
            Me.cdeFechaAperturaPJ.Value = IIf(Not ObjPersonaDR.IsFieldNull("dFechaNacApertura"), ObjPersonaDR.dFechaNacApertura, DBNull.Value)
            Me.txtDireccionPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sDireccion"), ObjPersonaDR.sDireccion, "")
            Me.txtTelefonoPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sTelefono"), ObjPersonaDR.sTelefono, "")
            Me.txtCelularPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sCelular"), ObjPersonaDR.sCelular, "")
            Me.txtFaxPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sFax"), ObjPersonaDR.sFax, "")
            Me.txtEmailPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sEMail"), ObjPersonaDR.sEMail, "")
            Me.txtSitioWebPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sSitioWeb"), ObjPersonaDR.sSitioWeb, "")
            Me.txtRepresentanteLegalPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sRepresentanteLegal"), ObjPersonaDR.sRepresentanteLegal, "")
            Me.txtNombreContactoPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNombre2"), ObjPersonaDR.sNombre2, "")
            If Not ObjPersonaDR.IsFieldNull("nOtorgaCredito") Then
                Me.chkOtorgaCreditosPJ.Checked = IIf(ObjPersonaDR.nOtorgaCredito = 1, True, False)
                If ObjPersonaDR.nOtorgaCredito = 1 Then
                    'Verificar si ya esta como referencia y si es asi no dejar que lo modifiquen
                    Dim ObjCredito1 As New BOSistema.Win.SclEntFicha.SclReferenciaCrediticiaDataTable
                    Dim ObjCredito2 As New BOSistema.Win.SclEntFicha.SclOtroCreditoVigenteDataTable

                    ObjCredito1.Filter = "nStbPersonaCreditoId = " & Me.IdPersona
                    ObjCredito1.Retrieve()

                    ObjCredito2.Filter = "nStbPersonaCreditoId = " & Me.IdPersona & " Or nStbPersonaCreditoVerificadaId = " & Me.IdPersona
                    ObjCredito2.Retrieve()

                    If ObjCredito1.Count > 0 Or ObjCredito2.Count > 0 Then
                        Me.chkOtorgaCreditosPJ.Enabled = False
                    End If

                    ObjCredito1.Close()
                    ObjCredito1 = Nothing

                    ObjCredito2.Close()
                    ObjCredito2 = Nothing

                End If
            End If
            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") Then
                Me.chkActivoPJ.Checked = IIf(ObjPersonaDR.nPersonaActiva = 1, True, False)
            End If

            If Not ObjPersonaDR.IsFieldNull("nLugarPagosPrograma") Then
                Me.chkDesembolsoPago.Checked = IIf(ObjPersonaDR.nLugarPagosPrograma = 1, True, False)
            End If

            'Activo
            If Not ObjPersonaDR.IsFieldNull("nPersonaActiva") Then
                If ObjPersonaDR.nPersonaActiva <> 1 Then
                    For Each ctrl As Control In Me.grpPJ.Controls
                        If InStr(ctrl.Name, "lbl") = 0 Then
                            ctrl.Enabled = IIf(InStr(ctrl.Name, "chkActivo") <> 0, True, False)
                        End If
                    Next
                End If
            End If


            'Inicializar los Length de los campos
            Me.txtNombreInstitucionPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre1")
            Me.txtRazonSocialPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sApellido1RS")
            Me.txtSiglasPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sSiglas")
            Me.txtDireccionPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sDireccion")
            Me.txtTelefonoPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sTelefono")
            Me.txtCelularPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sCelular")
            Me.txtFaxPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sFax")
            Me.txtEmailPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sEMail")
            Me.txtSitioWebPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sSitioWeb")
            Me.txtRepresentanteLegalPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sRepresentanteLegal")
            Me.txtNombreContactoPJ.MaxLength = ObjPersonaDR.GetColumnLenght("sNombre2")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarCargo
    ' Descripción:          Este procedimiento permite cargar el listado de posibles
    '                       cargos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCargo(ByVal intCargoID As Integer)
        Try
            Dim Strsql As String = ""

            If intCargoID = 0 Then
                Strsql = " Select a.nSrhCargoID,a.sCodigo,a.sNombreCargo " & _
                         " From SrhCargo a " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigo "
            Else
                Strsql = " Select a.nSrhCargoID,a.sCodigo,a.sNombreCargo " & _
                         " From SrhCargo a " & _
                         " WHERE a.nActivo = 1 or a.nSrhCargoID = " & intCargoID & _
                         " Order by a.sCodigo "
            End If

            If XdsPersona.ExistTable("Cargo") Then
                XdsPersona("Cargo").ExecuteSql(Strsql)
            Else
                XdsPersona.NewTable(Strsql, "Cargo")
                XdsPersona("Cargo").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCargo.DataSource = XdsPersona("Cargo").Source

            Me.cboCargo.Splits(0).DisplayColumns("nSrhCargoID").Visible = False
            Me.cboCargo.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboCargo.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboCargo.Splits(0).DisplayColumns("sNombreCargo").Width = 140

            Me.cboCargo.Columns("sCodigo").Caption = "Código"
            Me.cboCargo.Columns("sNombreCargo").Caption = "Descripción"

            Me.cboCargo.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCargo.Splits(0).DisplayColumns("sNombreCargo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarProfesion
    ' Descripción:          Este procedimiento permite cargar el listado de posibles
    '                       profesiones en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarProfesion(ByVal intProfesionID As Integer)
        Try
            Dim Strsql As String = ""

            If intProfesionID = 0 Then
                Strsql = " Select a.nStbProfesionID,a.sCodigo,a.sNombreCarrera " & _
                         " From StbProfesion a " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigo "
            Else
                Strsql = " Select a.nStbProfesionID,a.sCodigo,a.sNombreCarrera " & _
                         " From StbProfesion a " & _
                         " WHERE a.nActivo = 1 or a.nStbProfesionID = " & intProfesionID & _
                         " Order by a.sCodigo "
            End If

            If XdsPersona.ExistTable("Profesion") Then
                XdsPersona("Profesion").ExecuteSql(Strsql)
            Else
                XdsPersona.NewTable(Strsql, "Profesion")
                XdsPersona("Profesion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboProfesion.DataSource = XdsPersona("Profesion").Source

            Me.cboProfesion.Splits(0).DisplayColumns("nStbProfesionID").Visible = False
            Me.cboProfesion.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboProfesion.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboProfesion.Splits(0).DisplayColumns("sNombreCarrera").Width = 140

            Me.cboProfesion.Columns("sCodigo").Caption = "Código"
            Me.cboProfesion.Columns("sNombreCarrera").Caption = "Descripción"

            Me.cboProfesion.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboProfesion.Splits(0).DisplayColumns("sNombreCarrera").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            Select Case Me.TipoPersona
                Case "E"
                    If ValidaDatosEntradaEmpleado() Then
                        SalvarEmpleado()
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    End If
                Case "J", "P"
                    If ValidaDatosEntradaPersonaJuridica() Then
                        SalvarPersonaJuridica()
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    End If
                Case "N"
                    If ValidaDatosEntradaPersonaNatural() Then
                        SalvarPersonaNatural()
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    End If
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       ValidaDatosEntradaPersonaNatural
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntradaPersonaNatural() As Boolean
        Dim ObjTmpPersona As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Try

            ValidaDatosEntradaPersonaNatural = True
            Me.errPersona.Clear()

            'Primer Nombre Obligatorio:
            If Trim(RTrim(Me.txtPrimerNombrePN.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Nombre de la Persona Natural NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaNatural = False
                Me.errPersona.SetError(Me.txtPrimerNombrePN, "El Primer Nombre de la Persona Natural NO DEBE quedar vacío.")
                Me.txtPrimerNombrePN.Focus()
                Exit Function
            End If

            'Primer Apellido Obligatorio:
            If Trim(RTrim(Me.txtPrimerApellidoPN.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Apellido de la Persona Natural NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaNatural = False
                Me.errPersona.SetError(Me.txtPrimerApellidoPN, "El Primer Apellido de la Persona Natural NO DEBE quedar vacío.")
                Me.txtPrimerApellidoPN.Focus()
                Exit Function
            End If

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedulaPN.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Persona Natural NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaNatural = False
                Me.errPersona.SetError(Me.mtbNumCedulaPN, "El Número de Cédula de la Persona Natural NO DEBE quedar vacío.")
                Me.mtbNumCedulaPN.Focus()
                Exit Function
            End If

            'Verificacion de Número de Cédula Valida Obligatorio:
            Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedulaPN.Text)
                Case Cedula.Invalida
                    MsgBox("El Número de Cédula del Empleado es invalida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaPersonaNatural = False
                    Me.errPersona.SetError(Me.mtbNumCedulaPN, "El Número de Cédula del Empleado es invalida.")
                    Me.mtbNumCedulaPN.Focus()
                    Exit Function

                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del Número de Cédula del Empleado es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaPersonaNatural = False
                    Me.errPersona.SetError(Me.mtbNumCedulaPN, "La Longitud del Número de Cédula del Empleado es incorrecta.")
                    Me.mtbNumCedulaPN.Focus()
                    Exit Function
            End Select

            'Fecha válida en número de Cédula:
            strFecha = Mid(Trim(RTrim(Me.mtbNumCedulaPN.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaPN.Text)), 7, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaPN.Text)), 9, 2)
            If Not IsDate(strFecha) Then
                MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaNatural = False
                Me.errPersona.SetError(Me.mtbNumCedulaPN, "El Número de Cédula debe contener una fecha válida.")
                Me.mtbNumCedulaPN.Focus()
                Exit Function
            End If

            'Determinar duplicados en el Número de Cédula:
            If ModoFrm = "UPD" Then
                ObjTmpPersona.Filter = " sNumCedula = '" & Me.mtbNumCedulaPN.Text & "' And nStbPersonaID <> " & Me.IdPersona
            Else
                ObjTmpPersona.Filter = " sNumCedula = '" & Me.mtbNumCedulaPN.Text & "'"
            End If
            ObjTmpPersona.Retrieve() 'Obtener los datos filtrados.
            If ObjTmpPersona.Count > 0 Then
                MsgBox("El Número de Cédula NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaNatural = False
                Me.errPersona.SetError(Me.mtbNumCedulaPN, "El Número de Cédula NO DEBE repetirse.")
                Me.mtbNumCedulaPN.Focus()
                Exit Function
            End If

            'Dirección Obligatoria:
            If Trim(RTrim(Me.txtDireccionPN.Text)).ToString.Length = 0 Then
                MsgBox("La Dirección de la Persona Natural NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaNatural = False
                Me.errPersona.SetError(Me.txtDireccionPN, "La Dirección de la Persona Natural NO DEBE quedar vacío.")
                Me.txtDireccionPN.Focus()
                Exit Function
            End If

            'Sexo Obligatoria:
            If Me.rbSexoMasculinoPN.Checked = False And Me.rbSexoFemeninoPN.Checked = False Then
                MsgBox("El Sexo de la Persona Natural NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaNatural = False
                Me.errPersona.SetError(Me.rbSexoFemeninoPN, "El Sexo de la Persona Natural NO DEBE quedar vacío.")
                Exit Function
            End If

            'Correo Electronico:
            If Trim(RTrim(Me.txtEmailPN.Text)).ToString.Length > 0 Then
                If (Me.txtEmailPN.Text Like "*[@]*[.]*") = False Or SMUSURA0.ValidEmail(Me.txtEmailPN.Text, "") = False Then
                    MsgBox("Formato del Correo Electronico no es valido.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntradaPersonaNatural = False
                    Me.errPersona.SetError(Me.txtEmailPN, "Formato del Correo Electronico no es valido.")
                    Me.txtEmailPN.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpPersona.Close()
            ObjTmpPersona = Nothing

        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       SalvarPersonaNatural
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Persona Natural en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarPersonaNatural()
        Dim ObjTmpPersona As New BOSistema.Win.XDataSet
        Try
            Dim strSQL As String

            If ModoForm = "ADD" Then
                'Asignación del Código siguiente:
                strSQL = "Select IsNull(Max(nCodigo), 0) + 1 As nCodigoSiguiente From StbPersona"
                If ObjTmpPersona.ExistTable("Persona") Then
                    ObjTmpPersona("Persona").ExecuteSql(strSQL)
                Else
                    ObjTmpPersona.NewTable(strSQL, "Persona")
                    ObjTmpPersona("Persona").Retrieve()
                End If

                ObjPersonaDR.nCodigo = ObjTmpPersona("Persona").ValueField("nCodigoSiguiente")
                'Codigo
                Me.txtCodigoPN.Text = ObjPersonaDR.nCodigo

                'Asignacion del Tipo de Persona
                strSQL = _
                    "Select A.nStbValorCatalogoID As nStbTipoPersonaID " & _
                    "From StbValorCatalogo A " & _
                        "Inner Join StbCatalogo B On A.nStbCatalogoID = B.nStbCatalogoID " & _
                    "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And B.sNombre = 'TipoPersona'"
                If ObjTmpPersona.ExistTable("Persona") Then
                    ObjTmpPersona("Persona").ExecuteSql(strSQL)
                Else
                    ObjTmpPersona.NewTable(strSQL, "Persona")
                    ObjTmpPersona("Persona").Retrieve()
                End If

                ObjPersonaDR.nStbTipoPersonaID = ObjTmpPersona("Persona").ValueField("nStbTipoPersonaID")

                'Actualiza usuario y fecha de creación:
                ObjPersonaDR.sUsuarioCreacion = InfoSistema.LoginName
                ObjPersonaDR.dFechaCreacion = FechaServer()

                'Campos Obligatorios Siempre Nuevo
                ObjPersonaDR.nOtorgaCredito = 0
            Else
                ObjPersonaDR.sUsuarioModificacion = InfoSistema.LoginName
                ObjPersonaDR.dFechaModificacion = FechaServer()
            End If

            'Lugar de Entrega del Cheque / Pago
            ObjPersonaDR.nLugarPagosPrograma = 0

            'Primer Nombre:
            ObjPersonaDR.sNombre1 = Trim(RTrim(Me.txtPrimerNombrePN.Text))

            'Segundo Nombre:
            If Trim(RTrim(Me.txtSegundoNombrePN.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sNombre2 = Trim(RTrim(Me.txtSegundoNombrePN.Text))
            Else
                ObjPersonaDR.sNombre2 = ""
            End If

            'Primer Apellido:
            ObjPersonaDR.sApellido1RS = Trim(RTrim(Me.txtPrimerApellidoPN.Text))

            'Segundo Apellido:
            If Trim(RTrim(Me.txtSegundoApellidoPN.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sApellido2 = Trim(RTrim(Me.txtSegundoApellidoPN.Text))
            Else
                ObjPersonaDR.sApellido2 = ""
            End If

            'Número de Cédula:
            ObjPersonaDR.sNumCedula = Trim(RTrim(Me.mtbNumCedulaPN.Text))

            'Fecha de Nacimiento:
            ObjPersonaDR.dFechaNacApertura = CDate(strFecha)

            'Dirección:
            If Trim(RTrim(Me.txtDireccionPN.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sDireccion = Trim(RTrim(Me.txtDireccionPN.Text))
            Else
                ObjPersonaDR.SetFieldNull("sDireccion")
            End If

            'Teléfono:
            If Trim(RTrim(Me.txtTelefonoPN.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sTelefono = Trim(RTrim(Me.txtTelefonoPN.Text))
            Else
                ObjPersonaDR.SetFieldNull("sTelefono")
            End If

            'Celular:
            If Trim(RTrim(Me.txtCelularPN.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sCelular = Trim(RTrim(Me.txtCelularPN.Text))
            Else
                ObjPersonaDR.SetFieldNull("sCelular")
            End If

            'Fax:
            If Trim(RTrim(Me.txtFaxPN.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sFax = Trim(RTrim(Me.txtFaxPN.Text))
            Else
                ObjPersonaDR.SetFieldNull("sFax")
            End If

            'Sexo:
            If Me.rbSexoMasculinoPN.Checked = True And Me.rbSexoFemeninoPN.Checked = False Then
                ObjPersonaDR.sSexo = "M"
            ElseIf Me.rbSexoMasculinoPN.Checked = False And Me.rbSexoFemeninoPN.Checked = True Then
                ObjPersonaDR.sSexo = "F"
            End If

            'Email:
            If Trim(RTrim(Me.txtEmailPN.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sEMail = Me.txtEmailPN.Text
            Else
                ObjPersonaDR.SetFieldNull("sEMail")
            End If

            'Activo
            ObjPersonaDR.nPersonaActiva = IIf(Me.chkActivoPN.Checked = True, 1, 0)

            ObjPersonaDR.Update()

            'Asignar el Id de la Orden a la 
            'variable publica del formulario
            Me.IdPersona = Me.ObjPersonaDR.nStbPersonaID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpPersona.Close()
            ObjTmpPersona = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       ValidaDatosEntradaEmpleado
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntradaEmpleado() As Boolean
        Dim ObjTmpPersona As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Try

            ValidaDatosEntradaEmpleado = True
            Me.errPersona.Clear()

            'Primer Nombre Obligatorio:
            If Trim(RTrim(Me.txtPrimerNombreEP.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Nombre del Empleado NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.txtPrimerNombreEP, "El Primer Nombre del Empleado NO DEBE quedar vacío.")
                Me.txtPrimerNombreEP.Focus()
                Exit Function
            End If

            'Primer Apellido Obligatorio:
            If Trim(RTrim(Me.txtPrimerApellidoEP.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Apellido del Empleado NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.txtPrimerApellidoEP, "El Primer Apellido del Empleado NO DEBE quedar vacío.")
                Me.txtPrimerApellidoEP.Focus()
                Exit Function
            End If

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedulaEP.Text, 1, 1)) Then
                MsgBox("El Número de Cédula del Empleado NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.mtbNumCedulaEP, "El Número de Cédula del Empleado NO DEBE quedar vacío.")
                Me.mtbNumCedulaEP.Focus()
                Exit Function
            End If

            'Verificacion de Número de Cédula Valida Obligatorio:
            Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedulaEP.Text)
                Case Cedula.Invalida
                    MsgBox("El Número de Cédula del Empleado es invalida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaEmpleado = False
                    Me.errPersona.SetError(Me.mtbNumCedulaEP, "El Número de Cédula del Empleado es invalida.")
                    Me.mtbNumCedulaEP.Focus()
                    Exit Function

                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del Número de Cédula del Empleado es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaEmpleado = False
                    Me.errPersona.SetError(Me.mtbNumCedulaEP, "La Longitud del Número de Cédula del Empleado es incorrecta.")
                    Me.mtbNumCedulaEP.Focus()
                    Exit Function

            End Select

            'Fecha válida en número de Cédula:
            strFecha = Mid(Trim(RTrim(Me.mtbNumCedulaEP.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaEP.Text)), 7, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaEP.Text)), 9, 2)
            If Not IsDate(strFecha) Then
                MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.mtbNumCedulaEP, "El Número de Cédula debe contener una fecha válida.")
                Me.mtbNumCedulaEP.Focus()
                Exit Function
            End If

            'Determinar duplicados en el Número de Cédula:
            If ModoFrm = "UPD" Then
                ObjTmpPersona.Filter = " sNumCedula = '" & Me.mtbNumCedulaEP.Text & "' And nStbPersonaID <> " & Me.IdPersona
            Else
                ObjTmpPersona.Filter = " sNumCedula = '" & Me.mtbNumCedulaEP.Text & "'"
            End If
            ObjTmpPersona.Retrieve() 'Obtener los datos filtrados.
            If ObjTmpPersona.Count > 0 Then
                MsgBox("El Número de Cédula NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.mtbNumCedulaEP, "El Número de Cédula NO DEBE repetirse.")
                Me.mtbNumCedulaEP.Focus()
                Exit Function
            End If

            'Dirección Obligatoria:
            If Trim(RTrim(Me.txtDireccionEP.Text)).ToString.Length = 0 Then
                MsgBox("La Dirección del Empleado NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.txtDireccionEP, "La Dirección del Empleado NO DEBE quedar vacío.")
                Me.txtDireccionEP.Focus()
                Exit Function
            End If

            'Sexo Obligatoria:
            If Me.rbSexoMasculinoEP.Checked = False And Me.rbSexoFemeninoEP.Checked = False Then
                MsgBox("El Sexo del Empleado NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.rbSexoFemeninoEP, "El Sexo del Empleado NO DEBE quedar vacío.")
                Exit Function
            End If

            'Correo Electronico:
            If Trim(RTrim(Me.txtEmailEP.Text)).ToString.Length > 0 Then
                If (Me.txtEmailEP.Text Like "*[@]*[.]*") = False Or ValidEmail(Me.txtEmailEP.Text, "") = False Then
                    MsgBox("Formato del Correo Electronico no es valido.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntradaEmpleado = False
                    Me.errPersona.SetError(Me.txtEmailEP, "Formato del Correo Electronico no es valido.")
                    Me.txtEmailEP.Focus()
                    Exit Function
                End If
            End If

            'Numero Inss:
            If Trim(RTrim(Me.txtNoInssEP.Text)).ToString.Length > 0 Then
                Dim objTmpEmpleado As New BOSistema.Win.SrhEntEmpleado.SrhEmpleadoDataTable

                'Determinar duplicados en el Número de Cédula:
                If ModoFrm = "UPD" Then
                    objTmpEmpleado.Filter = " sNumINSS = '" & Me.txtNoInssEP.Text & "' And nStbPersonaID <> " & Me.IdPersona
                Else
                    objTmpEmpleado.Filter = " sNumINSS = '" & Me.txtNoInssEP.Text & "'"
                End If
                objTmpEmpleado.Retrieve() 'Obtener los datos filtrados.
                If objTmpEmpleado.Count > 0 Then
                    MsgBox("El Número de INSS NO DEBE repetirse.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaEmpleado = False
                    Me.errPersona.SetError(Me.txtNoInssEP, "El Número de INSS NO DEBE repetirse.")
                    Me.txtNoInssEP.Focus()
                    Exit Function
                End If
                objTmpEmpleado.Close()
                objTmpEmpleado = Nothing

            End If

            'Fecha de Ingreso:
            If Me.cdeFechaIngresoEP.ValueIsDbNull Then
                MsgBox("La Fecha de Ingreso del Empleado NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.cdeFechaIngresoEP, "La Fecha de Ingreso del Empleado NO DEBE quedar vacía.")
                Me.cdeFechaIngresoEP.Focus()
                Exit Function
            End If

            'Salario:
            If Trim(RTrim(Me.txtSalarioEP.Text)).ToString.Length = 0 Then
                MsgBox("El Salario del Empleado NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.txtSalarioEP, "El Salario del Empleado NO DEBE quedar vacío.")
                Me.txtSalarioEP.Focus()
                Exit Function
            End If

            'Cargo
            If Me.cboCargo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Cargo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntradaEmpleado = False
                Me.errPersona.SetError(Me.cboCargo, "Debe seleccionar un Cargo válido.")
                Me.cboCargo.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpPersona.Close()
            ObjTmpPersona = Nothing

        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       SalvarEmpleado
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Empleado en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarEmpleado()
        Dim ObjTmpPersona As New BOSistema.Win.XDataSet
        Try
            Dim strSQL As String

            If ModoForm = "ADD" Then
                'Asignación del Código siguiente:
                strSQL = "Select IsNull(Max(nCodigo), 0) + 1 As nCodigoSiguiente From StbPersona"
                If ObjTmpPersona.ExistTable("Persona") Then
                    ObjTmpPersona("Persona").ExecuteSql(strSQL)
                Else
                    ObjTmpPersona.NewTable(strSQL, "Persona")
                    ObjTmpPersona("Persona").Retrieve()
                End If

                ObjPersonaDR.nCodigo = ObjTmpPersona("Persona").ValueField("nCodigoSiguiente")
                'Codigo
                Me.txtCodigoEP.Text = ObjPersonaDR.nCodigo

                'Asignacion del Tipo de Persona
                strSQL = _
                    "Select A.nStbValorCatalogoID As nStbTipoPersonaID " & _
                    "From StbValorCatalogo A " & _
                        "Inner Join StbCatalogo B On A.nStbCatalogoID = B.nStbCatalogoID " & _
                    "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And B.sNombre = 'TipoPersona'"
                If ObjTmpPersona.ExistTable("Persona") Then
                    ObjTmpPersona("Persona").ExecuteSql(strSQL)
                Else
                    ObjTmpPersona.NewTable(strSQL, "Persona")
                    ObjTmpPersona("Persona").Retrieve()
                End If

                ObjPersonaDR.nStbTipoPersonaID = ObjTmpPersona("Persona").ValueField("nStbTipoPersonaID")

                'Actualiza usuario y fecha de creación:
                ObjPersonaDR.sUsuarioCreacion = InfoSistema.LoginName
                ObjPersonaDR.dFechaCreacion = FechaServer()

                'Campos Obligatorios Siempre Nuevo
                ObjPersonaDR.nOtorgaCredito = 0
            Else
                If Me.CambioPersona = True Then
                    'Asignacion del Tipo de Persona
                    strSQL = _
                        "Select A.nStbValorCatalogoID As nStbTipoPersonaID " & _
                        "From StbValorCatalogo A " & _
                            "Inner Join StbCatalogo B On A.nStbCatalogoID = B.nStbCatalogoID " & _
                        "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And B.sNombre = 'TipoPersona'"
                    If ObjTmpPersona.ExistTable("Persona") Then
                        ObjTmpPersona("Persona").ExecuteSql(strSQL)
                    Else
                        ObjTmpPersona.NewTable(strSQL, "Persona")
                        ObjTmpPersona("Persona").Retrieve()
                    End If

                    ObjPersonaDR.nStbTipoPersonaID = ObjTmpPersona("Persona").ValueField("nStbTipoPersonaID")
                End If
                ObjPersonaDR.sUsuarioModificacion = InfoSistema.LoginName
                ObjPersonaDR.dFechaModificacion = FechaServer()
            End If

            'Lugar de entrega del Cheque / pago
            ObjPersonaDR.nLugarPagosPrograma = 0

            'Primer Nombre:
            ObjPersonaDR.sNombre1 = Trim(RTrim(Me.txtPrimerNombreEP.Text))

            'Segundo Nombre:
            If Trim(RTrim(Me.txtSegundoNombreEP.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sNombre2 = Trim(RTrim(Me.txtSegundoNombreEP.Text))
            Else
                ObjPersonaDR.sNombre2 = ""
            End If

            'Primer Apellido:
            ObjPersonaDR.sApellido1RS = Trim(RTrim(Me.txtPrimerApellidoEP.Text))

            'Segundo Apellido:
            If Trim(RTrim(Me.txtSegundoApellidoEP.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sApellido2 = Trim(RTrim(Me.txtSegundoApellidoEP.Text))
            Else
                ObjPersonaDR.sApellido2 = ""
            End If

            'Número de Cédula:
            ObjPersonaDR.sNumCedula = Trim(RTrim(Me.mtbNumCedulaEP.Text))

            'Fecha de Nacimiento:
            ObjPersonaDR.dFechaNacApertura = CDate(strFecha)

            'Dirección:
            If Trim(RTrim(Me.txtDireccionEP.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sDireccion = Trim(RTrim(Me.txtDireccionEP.Text))
            Else
                ObjPersonaDR.SetFieldNull("sDireccion")
            End If

            'Teléfono:
            If Trim(RTrim(Me.txtTelefonoEP.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sTelefono = Trim(RTrim(Me.txtTelefonoEP.Text))
            Else
                ObjPersonaDR.SetFieldNull("sTelefono")
            End If

            'Celular:
            If Trim(RTrim(Me.txtCelularEP.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sCelular = Trim(RTrim(Me.txtCelularEP.Text))
            Else
                ObjPersonaDR.SetFieldNull("sCelular")
            End If

            'Fax:
            If Trim(RTrim(Me.txtFaxEP.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sFax = Trim(RTrim(Me.txtFaxEP.Text))
            Else
                ObjPersonaDR.SetFieldNull("sFax")
            End If

            'Sexo:
            If Me.rbSexoMasculinoEP.Checked = True And Me.rbSexoFemeninoEP.Checked = False Then
                ObjPersonaDR.sSexo = "M"
            ElseIf Me.rbSexoMasculinoEP.Checked = False And Me.rbSexoFemeninoEP.Checked = True Then
                ObjPersonaDR.sSexo = "F"
            End If

            'Email:
            If Trim(RTrim(Me.txtEmailEP.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sEMail = Me.txtEmailPN.Text
            Else
                ObjPersonaDR.SetFieldNull("sEMail")
            End If

            'Activo
            ObjPersonaDR.nPersonaActiva = IIf(Me.chkActivoEP.Checked = True, 1, 0)

            ObjPersonaDR.Update()

            'Asignar el Id de la Orden a la 
            'variable publica del formulario
            Me.IdPersona = Me.ObjPersonaDR.nStbPersonaID
            '--------------------------------

            'Para la Parte de Empleado
            If ModoForm = "ADD" Then
                'Asignación del Código siguiente :
                strSQL = _
                "Select Replicate('0', 4 - Len(nCodigoSiguiente)) + Convert(varchar(4), nCodigoSiguiente) sCodigoSiguiente " & _
                "From (" & _
                    "Select IsNull(Max(sCodigo),0) + 1 nCodigoSiguiente From SrhEmpleado" & _
                ") A"

                If ObjTmpPersona.ExistTable("Persona") Then
                    ObjTmpPersona("Persona").ExecuteSql(strSQL)
                Else
                    ObjTmpPersona.NewTable(strSQL, "Persona")
                    ObjTmpPersona("Persona").Retrieve()
                End If
                'Codigo Empleado
                ObjEmpleadoDR.sCodigo = ObjTmpPersona("Persona").ValueField("sCodigoSiguiente")
                'Codigo de la Persona 
                ObjEmpleadoDR.nStbPersonaID = ObjPersonaDR.nStbPersonaID

                'Actualiza usuario y fecha de creación:
                ObjEmpleadoDR.UsuarioCreacion = InfoSistema.LoginName
                ObjEmpleadoDR.FechaCreacion = FechaServer()

            Else
                If Me.CambioPersona = True Then
                    'Asignación del Código siguiente :
                    strSQL = _
                    "Select Replicate('0', 4 - Len(nCodigoSiguiente)) + Convert(varchar(4), nCodigoSiguiente) sCodigoSiguiente " & _
                    "From (" & _
                        "Select IsNull(Max(sCodigo),0) + 1 nCodigoSiguiente From SrhEmpleado" & _
                    ") A"

                    If ObjTmpPersona.ExistTable("Persona") Then
                        ObjTmpPersona("Persona").ExecuteSql(strSQL)
                    Else
                        ObjTmpPersona.NewTable(strSQL, "Persona")
                        ObjTmpPersona("Persona").Retrieve()
                    End If
                    'Codigo Empleado
                    ObjEmpleadoDR.sCodigo = ObjTmpPersona("Persona").ValueField("sCodigoSiguiente")
                    'Codigo de la Persona 
                    ObjEmpleadoDR.nStbPersonaID = ObjPersonaDR.nStbPersonaID

                    'Actualiza usuario y fecha de creación:
                    ObjEmpleadoDR.UsuarioCreacion = InfoSistema.LoginName
                    ObjEmpleadoDR.FechaCreacion = FechaServer()

                End If
                ObjEmpleadoDR.UsuarioModifica = InfoSistema.LoginName
                ObjEmpleadoDR.FechaModifica = FechaServer()
            End If

            'No INSS:
            If Trim(RTrim(Me.txtNoInssEP.Text)).ToString.Length <> 0 Then
                ObjEmpleadoDR.sNumINSS = Trim(RTrim(Me.txtNoInssEP.Text))
            Else
                ObjEmpleadoDR.SetFieldNull("sNumINSS")
            End If

            'Fecha Ingreso:
            ObjEmpleadoDR.dFechaIngreso = Me.cdeFechaIngresoEP.Value

            'Fecha Egreso:
            If Not Me.cdeFechaEgresoEP.ValueIsDbNull Then
                ObjEmpleadoDR.dFechaEgreso = Me.cdeFechaEgresoEP.Value
            Else
                ObjEmpleadoDR.SetFieldNull("dFechaEgreso")
            End If

            'Salario:
            ObjEmpleadoDR.nSalario = Trim(RTrim(Me.txtSalarioEP.Text))

            'Cargo
            If Me.cboCargo.SelectedIndex <> -1 Then
                ObjEmpleadoDR.nSrhCargoID = XdsPersona("Cargo").ValueField("nSrhCargoID")
            Else
                ObjEmpleadoDR.SetFieldNull("nSrhCargoID")
            End If

            'Profesion
            If Me.cboProfesion.SelectedIndex <> -1 Then
                ObjEmpleadoDR.nStbProfesionID = XdsPersona("Profesion").ValueField("nStbProfesionID")
            Else
                ObjEmpleadoDR.SetFieldNull("nStbProfesionID")
            End If

            'Activo
            ObjEmpleadoDR.nActivo = IIf(Me.chkActivoEP.Checked = True, 1, 0)

            ObjEmpleadoDR.Update()

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                If Me.CambioPersona = True Then
                    MsgBox("El cambio de la Persona Natural a Emplado se realizo satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpPersona.Close()
            ObjTmpPersona = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       ValidaDatosEntradaPersonaJuridica
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntradaPersonaJuridica() As Boolean
        Dim ObjTmpPersona As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Try

            ValidaDatosEntradaPersonaJuridica = True
            Me.errPersona.Clear()

            'Nombre Institucion Obligatorio:
            If Trim(RTrim(Me.txtNombreInstitucionPJ.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre Institucion de la Persona Juridica NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaJuridica = False
                Me.errPersona.SetError(Me.txtNombreInstitucionPJ, "El Nombre Institucion de la Persona Juridica NO DEBE quedar vacío.")
                Me.txtNombreInstitucionPJ.Focus()
                Exit Function
            End If

            'Razon Social Obligatorio:
            If Trim(RTrim(Me.txtRazonSocialPJ.Text)).ToString.Length = 0 Then
                MsgBox("La Razon Social de la Persona Juridica NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaJuridica = False
                Me.errPersona.SetError(Me.txtRazonSocialPJ, "La Razon Social de la Persona Juridica NO DEBE quedar vacío.")
                Me.txtRazonSocialPJ.Focus()
                Exit Function
            End If

            'Número RUC Obligatorio:
            'If Not IsNumeric(Mid(Me.mtbNumRucPJ.Text, 1, 1)) Then
            '    MsgBox("El Número RUC de la Persona Juridica NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaPersonaJuridica = False
            '    Me.errPersona.SetError(Me.mtbNumRucPJ, "El Número RUC de la Persona Juridica NO DEBE quedar vacío.")
            '    Me.mtbNumRucPJ.Focus()
            '    Exit Function
            'End If

            'If Trim(RTrim(Me.mtbNumRucPJ.Text)).ToString.Length > 0 And Trim(RTrim(Me.mtbNumRucPJ.Text)).ToString.Length < 11 Then
            '    MsgBox("El Número RUC de la Persona Juridica NO TIENE la longitud correcta.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaPersonaJuridica = False
            '    Me.errPersona.SetError(Me.mtbNumRucPJ, "El Número RUC de la Persona Juridica NO TIENE la longitud correcta.")
            '    Me.mtbNumRucPJ.Focus()
            '    Exit Function
            'End If

            'Fecha válida en número de RUC:
            'strFecha = Mid(Trim(RTrim(Me.mtbNumCedulaPN.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaPN.Text)), 7, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaPN.Text)), 9, 2)
            'If Not IsDate(strFecha) Then
            '    MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaPersonaNatural = False
            '    Me.errPersona.SetError(Me.mtbNumCedulaPN, "El Número de Cédula debe contener una fecha válida.")
            '    Me.mtbNumCedulaPN.Focus()
            '    Exit Function
            'End If

            If Trim(RTrim(Me.txtNumRucPJ.Text)).ToString.Length = 11 Then
                'Determinar duplicados en el Número de Cédula:
                If ModoFrm = "UPD" Then
                    ObjTmpPersona.Filter = " sNumRUC = '" & Me.txtNumRucPJ.Text & "' And nStbPersonaID <> " & Me.IdPersona
                Else
                    ObjTmpPersona.Filter = " sNumRUC = '" & Me.txtNumRucPJ.Text & "'"
                End If
                ObjTmpPersona.Retrieve() 'Obtener los datos filtrados.
                If ObjTmpPersona.Count > 0 Then
                    MsgBox("El Número del RUC de la Persona Juridica NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaPersonaJuridica = False
                    Me.errPersona.SetError(Me.txtNumRucPJ, "El Número del RUC de la Persona Juridica NO DEBE repetirse.")
                    Me.txtNumRucPJ.Focus()
                    Exit Function
                End If
            End If

            'Determinar duplicados en el Nombre de la Persona Jurídica
            If ModoFrm = "UPD" Then
                ObjTmpPersona.Filter = " sNombre1 = '" & Me.txtNombreInstitucionPJ.Text & "' And nStbPersonaID <> " & Me.IdPersona
            Else
                ObjTmpPersona.Filter = " sNombre1 = '" & Me.txtNombreInstitucionPJ.Text & "'"
            End If
            ObjTmpPersona.Retrieve() 'Obtener los datos filtrados.
            If ObjTmpPersona.Count > 0 Then
                MsgBox("El Nombre de la Persona Juridica NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaJuridica = False
                Me.errPersona.SetError(Me.txtNombreInstitucionPJ, "El Nombre de la Persona Juridica NO DEBE repetirse.")
                Me.txtNombreInstitucionPJ.Focus()
                Exit Function
            End If

            'Dirección Obligatoria:
            If Trim(RTrim(Me.txtDireccionPJ.Text)).ToString.Length = 0 Then
                MsgBox("La Dirección de la Persona Juridica NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntradaPersonaJuridica = False
                Me.errPersona.SetError(Me.txtDireccionPJ, "La Dirección de la Persona Juridica NO DEBE quedar vacío.")
                Me.txtDireccionPJ.Focus()
                Exit Function
            End If

            'Correo Electronico:
            If Trim(RTrim(Me.txtEmailPJ.Text)).ToString.Length > 0 Then
                If (Me.txtEmailPJ.Text Like "*[@]*[.]*") = False Or SMUSURA0.ValidEmail(Me.txtEmailPJ.Text, "") = False Then
                    MsgBox("Formato del Correo Electronico no es valido.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntradaPersonaJuridica = False
                    Me.errPersona.SetError(Me.txtEmailPJ, "Formato del Correo Electronico no es valido.")
                    Me.txtEmailPJ.Focus()
                    Exit Function
                End If
            End If

            'Representante Legal Obligatoria:
            'If Trim(RTrim(Me.txtRepresentanteLegalPJ.Text)).ToString.Length = 0 Then
            '    MsgBox("El Representante Legal de la Persona Juridica NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaPersonaJuridica = False
            '    Me.errPersona.SetError(Me.txtRepresentanteLegalPJ, "El Representante Legal de la Persona Juridica NO DEBE quedar vacío.")
            '    Me.txtRepresentanteLegalPJ.Focus()
            '    Exit Function
            'End If

            'Nombre Contacto Obligatoria:
            'If Trim(RTrim(Me.txtNombreContactoPJ.Text)).ToString.Length = 0 Then
            '    MsgBox("El Nombre del Contacto de la Persona Juridica NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntradaPersonaJuridica = False
            '    Me.errPersona.SetError(Me.txtNombreContactoPJ, "El Nombre del Contacto de la Persona Juridica NO DEBE quedar vacío.")
            '    Me.txtNombreContactoPJ.Focus()
            '    Exit Function
            'End If
            If Me.TipoPersona = "P" Then

                'Nombre Descripcion Negocio:
                If Trim(RTrim(Me.txtDescripcionNegocio.Text)).ToString.Length = 0 Then
                    MsgBox("La Descripción de la naturaleza del negocio NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaPersonaJuridica = False
                    Me.errPersona.SetError(Me.txtDescripcionNegocio, "La Descripción de la naturaleza del negocio NO DEBE quedar vacío.")
                    Me.txtDescripcionNegocio.Focus()
                    Exit Function
                End If



                'Verificacion de Número de Cédula Valida Obligatorio:
                Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedulaPJ.Text)
                    Case Cedula.Invalida
                        MsgBox("El Número de Cédula  es invalido.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntradaPersonaJuridica = False
                        Me.errPersona.SetError(Me.mtbNumCedulaPJ, "El Número de Cédula es invalido.")
                        Me.mtbNumCedulaPJ.Focus()
                        Exit Function

                    Case Cedula.LongitudIncorrecta
                        If (Me.mtbNumCedulaPJ.Text <> "   -      -") Then


                            MsgBox("La Longitud del Número de Cédula  es incorrecto.", MsgBoxStyle.Critical, NombreSistema)
                            ValidaDatosEntradaPersonaJuridica = False
                            Me.errPersona.SetError(Me.mtbNumCedulaPJ, "La Longitud del Número de Cédula es incorrecto.")
                            Me.mtbNumCedulaPJ.Focus()
                            Exit Function
                        End If
                End Select

                'Fecha válida en número de Cédula:
                strFecha = Mid(Trim(RTrim(Me.mtbNumCedulaPJ.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaPJ.Text)), 7, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedulaPJ.Text)), 9, 2)
                If Not IsDate(strFecha) Then
                    If (Me.mtbNumCedulaPJ.Text <> "   -      -") Then
                        MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntradaPersonaJuridica = False
                        Me.errPersona.SetError(Me.mtbNumCedulaPJ, "El Número de Cédula debe contener una fecha válida.")
                        Me.mtbNumCedulaPJ.Focus()
                        Exit Function
                    End If
                End If
                'Determinar duplicados en el Número de Cédula:
                If ModoFrm = "UPD" Then
                    ObjTmpPersona.Filter = " sNumCedula = '" & Me.mtbNumCedulaPJ.Text & "' And nStbPersonaID <> " & Me.IdPersona
                Else
                    ObjTmpPersona.Filter = " sNumCedula = '" & Me.mtbNumCedulaPJ.Text & "'"
                End If
                ObjTmpPersona.Retrieve() 'Obtener los datos filtrados.
                If ObjTmpPersona.Count > 0 Then
                    MsgBox("El Número de Cédula NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntradaPersonaJuridica = False
                    Me.errPersona.SetError(Me.mtbNumCedulaPJ, "El Número de Cédula NO DEBE repetirse.")
                    Me.mtbNumCedulaPJ.Focus()
                    Exit Function
                End If




            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpPersona.Close()
            ObjTmpPersona = Nothing

        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                17 Septiembre 2007
    ' Procedure Name:       SalvarPersonaNatural
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Persona Juridica en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarPersonaJuridica()
        Dim ObjTmpPersona As New BOSistema.Win.XDataSet
        Try
            Dim strSQL As String

            If ModoForm = "ADD" Then
                'Asignación del Código siguiente:
                strSQL = "Select IsNull(Max(nCodigo), 0) + 1 As nCodigoSiguiente From StbPersona"
                If ObjTmpPersona.ExistTable("Persona") Then
                    ObjTmpPersona("Persona").ExecuteSql(strSQL)
                Else
                    ObjTmpPersona.NewTable(strSQL, "Persona")
                    ObjTmpPersona("Persona").Retrieve()
                End If

                ObjPersonaDR.nCodigo = ObjTmpPersona("Persona").ValueField("nCodigoSiguiente")
                'Codigo
                Me.txtCodigoPN.Text = ObjPersonaDR.nCodigo

                'Asignacion del Tipo de Persona
                strSQL = _
                    "Select A.nStbValorCatalogoID As nStbTipoPersonaID " & _
                    "From StbValorCatalogo A " & _
                        "Inner Join StbCatalogo B On A.nStbCatalogoID = B.nStbCatalogoID " & _
                    "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And B.sNombre = 'TipoPersona'"
                If ObjTmpPersona.ExistTable("Persona") Then
                    ObjTmpPersona("Persona").ExecuteSql(strSQL)
                Else
                    ObjTmpPersona.NewTable(strSQL, "Persona")
                    ObjTmpPersona("Persona").Retrieve()
                End If

                ObjPersonaDR.nStbTipoPersonaID = ObjTmpPersona("Persona").ValueField("nStbTipoPersonaID")

                'Actualiza usuario y fecha de creación:
                ObjPersonaDR.sUsuarioCreacion = InfoSistema.LoginName
                ObjPersonaDR.dFechaCreacion = FechaServer()

                'Campos Obligatorios Siempre Nuevo
                ObjPersonaDR.sApellido2 = ""
            Else
                If Me.TipoPersona = "P" Then
                    'Asignacion del Tipo de Persona
                    strSQL = _
                        "Select A.nStbValorCatalogoID As nStbTipoPersonaID " & _
                        "From StbValorCatalogo A " & _
                            "Inner Join StbCatalogo B On A.nStbCatalogoID = B.nStbCatalogoID " & _
                        "Where A.sCodigoInterno = '" & Me.TipoPersona & "' And B.sNombre = 'TipoPersona'"
                    If ObjTmpPersona.ExistTable("Persona") Then
                        ObjTmpPersona("Persona").ExecuteSql(strSQL)
                    Else
                        ObjTmpPersona.NewTable(strSQL, "Persona")
                        ObjTmpPersona("Persona").Retrieve()
                    End If

                    ObjPersonaDR.nStbTipoPersonaID = ObjTmpPersona("Persona").ValueField("nStbTipoPersonaID")


                End If

                ObjPersonaDR.sUsuarioModificacion = InfoSistema.LoginName
                ObjPersonaDR.dFechaModificacion = FechaServer()
            End If

            If Me.chkDesembolsoPago.Checked = True Then
                ObjPersonaDR.nLugarPagosPrograma = 1
            Else
                ObjPersonaDR.nLugarPagosPrograma = 0
            End If

            'Nombre Institucion:
            ObjPersonaDR.sNombre1 = Trim(RTrim(Me.txtNombreInstitucionPJ.Text))

            'Razon Social:
            ObjPersonaDR.sApellido1RS = Trim(RTrim(Me.txtRazonSocialPJ.Text))

            'Razon Social:
            ObjPersonaDR.sSiglas = Trim(RTrim(Me.txtSiglasPJ.Text))

            'Número RUC:
            If Trim(RTrim(Me.txtNumRucPJ.Text)).Length = 11 Then
                ObjPersonaDR.sNumRUC = Trim(RTrim(Me.txtNumRucPJ.Text))
            Else
                ObjPersonaDR.SetFieldNull("sNumRUC")
            End If

            'Fecha de Apertura:
            If Not Me.cdeFechaAperturaPJ.ValueIsDbNull Then
                ObjPersonaDR.dFechaNacApertura = Me.cdeFechaAperturaPJ.Value
            Else
                ObjPersonaDR.SetFieldNull("dFechaNacApertura")
            End If

            'Dirección:
            If Trim(RTrim(Me.txtDireccionPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sDireccion = Trim(RTrim(Me.txtDireccionPJ.Text))
            Else
                ObjPersonaDR.SetFieldNull("sDireccion")
            End If

            'Teléfono:
            If Trim(RTrim(Me.txtTelefonoPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sTelefono = Trim(RTrim(Me.txtTelefonoPJ.Text))
            Else
                ObjPersonaDR.SetFieldNull("sTelefono")
            End If

            'Celular:
            If Trim(RTrim(Me.txtCelularPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sCelular = Trim(RTrim(Me.txtCelularPJ.Text))
            Else
                ObjPersonaDR.SetFieldNull("sCelular")
            End If

            'Fax:
            If Trim(RTrim(Me.txtFaxPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sFax = Trim(RTrim(Me.txtFaxPJ.Text))
            Else
                ObjPersonaDR.SetFieldNull("sFax")
            End If

            'Email:
            If Trim(RTrim(Me.txtEmailPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sEMail = Me.txtEmailPJ.Text
            Else
                ObjPersonaDR.SetFieldNull("sEMail")
            End If

            'Sitio Web:
            If Trim(RTrim(Me.txtSitioWebPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sSitioWeb = Me.txtSitioWebPJ.Text
            Else
                ObjPersonaDR.SetFieldNull("sSitioWeb")
            End If

            'Representante Legal:
            If Trim(RTrim(Me.txtRepresentanteLegalPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sRepresentanteLegal = Me.txtRepresentanteLegalPJ.Text
            Else
                ObjPersonaDR.SetFieldNull("sRepresentanteLegal")
            End If

            'Nombre Contacto:
            If Trim(RTrim(Me.txtNombreContactoPJ.Text)).ToString.Length <> 0 Then
                ObjPersonaDR.sNombre2 = Trim(RTrim(Me.txtNombreContactoPJ.Text))
            Else
                ObjPersonaDR.sNombre2 = ""
            End If

            'Otorga Credito
            ObjPersonaDR.nOtorgaCredito = IIf(Me.chkOtorgaCreditosPJ.Checked = True, 1, 0)

            'Activo
            If Me.TipoPersona = "P" Then
                ObjPersonaDR.nPersonaActiva = IIf(Me.chkActivoPP.Checked = True, 1, 0)
            Else
                ObjPersonaDR.nPersonaActiva = IIf(Me.chkActivoPJ.Checked = True, 1, 0)
            End If


            If (Me.mtbNumCedulaPJ.Text <> "   -      -") Then
                ObjPersonaDR.sNumCedula = Trim(RTrim(Me.mtbNumCedulaPJ.Text))
            Else
                ObjPersonaDR.sNumCedula = ""
            End If

            If Me.chkChequeARepresentante.Checked = True Then
                ObjPersonaDR.nChequeARepresentanteLegal = 1
            Else
                ObjPersonaDR.nChequeARepresentanteLegal = 0
            End If



            ObjPersonaDR.Update()

            'Asignar el Id de la Orden a la 
            'variable publica del formulario
            Me.IdPersona = Me.ObjPersonaDR.nStbPersonaID
            '--------------------------------
            'Salvar informacion de proveedor.
            If Me.TipoPersona = "P" Then





                'Para la Parte de Empleado
                If ModoForm = "ADD" Then
                    'Asignación del Código siguiente :
                    strSQL = _
                    "Select Replicate('0', 4 - Len(nCodigoSiguiente)) + Convert(varchar(4), nCodigoSiguiente) sCodigoSiguiente " & _
                    "From (" & _
                        "Select IsNull(Max(sCodigo),0) + 1 nCodigoSiguiente From SrhProveedor" & _
                    ") A"

                    If ObjTmpPersona.ExistTable("Persona") Then
                        ObjTmpPersona("Persona").ExecuteSql(strSQL)
                    Else
                        ObjTmpPersona.NewTable(strSQL, "Persona")
                        ObjTmpPersona("Persona").Retrieve()
                    End If
                    'Codigo Empleado
                    ObjProveedorDR.sCodigo = ObjTmpPersona("Persona").ValueField("sCodigoSiguiente")
                    'Codigo de la Persona 
                    ObjProveedorDR.nStbPersonaID = ObjPersonaDR.nStbPersonaID

                    'Actualiza usuario y fecha de creación:
                    ObjProveedorDR.UsuarioCreacion = InfoSistema.LoginName
                    ObjProveedorDR.FechaCreacion = FechaServer()

                Else
                    If Me.CambioPersona = True Then
                        'Asignación del Código siguiente :
                        strSQL = _
                        "Select Replicate('0', 4 - Len(nCodigoSiguiente)) + Convert(varchar(4), nCodigoSiguiente) sCodigoSiguiente " & _
                        "From (" & _
                            "Select IsNull(Max(sCodigo),0) + 1 nCodigoSiguiente From SrhProveedor" & _
                        ") A"

                        If ObjTmpPersona.ExistTable("Persona") Then
                            ObjTmpPersona("Persona").ExecuteSql(strSQL)
                        Else
                            ObjTmpPersona.NewTable(strSQL, "Persona")
                            ObjTmpPersona("Persona").Retrieve()
                        End If
                        'Codigo Empleado
                        ObjProveedorDR.sCodigo = ObjTmpPersona("Persona").ValueField("sCodigoSiguiente")
                        'Codigo de la Persona 
                        ObjProveedorDR.nStbPersonaID = ObjPersonaDR.nStbPersonaID

                        'Actualiza usuario y fecha de creación:
                        ObjProveedorDR.UsuarioCreacion = InfoSistema.LoginName
                        ObjProveedorDR.FechaCreacion = FechaServer()


                    End If
                    ObjProveedorDR.UsuarioModifica = InfoSistema.LoginName
                    ObjProveedorDR.FechaModifica = FechaServer()
                    ObjProveedorDR.nActivo = IIf(Me.chkActivoPP.Checked = True, 1, 0)


                End If




                'Activo
                ObjProveedorDR.nPagaIR = IIf(Me.chkPagaIR.Checked = True, 1, 0)
                ObjProveedorDR.nPagaIVA = IIf(Me.chkPagaIVA.Checked = True, 1, 0)

                ObjProveedorDR.sDescripcionNegocio = Me.txtDescripcionNegocio.Text

                'Activo
                ObjProveedorDR.nActivo = IIf(Me.chkActivoPP.Checked = True, 1, 0)


                ObjProveedorDR.Update()


            End If


            If Me.TipoPersona = "P" Or Me.TipoPersona = "J" Then
                Dim ObjTmpPersona2 As New BOSistema.Win.XDataSet.xDataTable
                ObjTmpPersona2.ExecuteSql("Select sNumRUC From StbPersonaDatoFiscal Where nStbPersonaID=" & Me.IdPersona)
                If ObjTmpPersona2.Count > 0 Then
                    ObjTmpPersona2.ExecuteSql("Update StbPersonaDatoFiscal Set sUsuarioModificacion= '" & InfoSistema.LoginName & "',dFechaModificacion =Getdate(),sNumRUC=  '" & Me.txtNumRucPJ.Text & "' From StbPersonaDatoFiscal Where nStbPersonaID=" & Me.IdPersona)
                    'Me.mtbNumRucPJ.Text = IIf(Not ObjPersonaDR.IsFieldNull("sNumRUC"), ObjPersonaDR.sNumRUC, "")
                Else
                    ObjTmpPersona2.ExecuteSql("Insert Into StbPersonaDatoFiscal(nStbPersonaID,sNumRUC,sUsuarioCreacion,dFechaCreacion ) Values(" & Me.IdPersona & ",'" & Me.txtNumRucPJ.Text & "','" & InfoSistema.LoginName & "',Getdate())")

                End If


            End If







            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpPersona.Close()
            ObjTmpPersona = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Edgard Delgado
    ' Fecha:                25/07/2006
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

                        Select Case Me.TipoPersona
                            Case "E"
                                If ValidaDatosEntradaEmpleado() Then
                                    SalvarEmpleado()
                                    AccionUsuario = AccionBoton.BotonAceptar
                                    Me.Close()
                                Else
                                    AccionUsuario = AccionBoton.BotonNinguno
                                End If
                            Case "J", "P"
                                If ValidaDatosEntradaPersonaJuridica() Then
                                    SalvarPersonaJuridica()
                                    AccionUsuario = AccionBoton.BotonAceptar
                                    Me.Close()
                                Else
                                    AccionUsuario = AccionBoton.BotonNinguno
                                End If
                            Case "N"
                                If ValidaDatosEntradaPersonaNatural() Then
                                    SalvarPersonaNatural()
                                    AccionUsuario = AccionBoton.BotonAceptar
                                    Me.Close()
                                Else
                                    AccionUsuario = AccionBoton.BotonNinguno
                                End If
                        End Select

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

    'Solo se permite Letras A - Z, BackSpace y la Barra espaciadora
    Private Sub txtNombres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtPrimerNombrePN.KeyPress, txtSegundoNombrePN.KeyPress, txtPrimerApellidoPN.KeyPress, txtSegundoApellidoPN.KeyPress, _
        txtPrimerNombreEP.KeyPress, txtSegundoNombreEP.KeyPress, txtPrimerApellidoEP.KeyPress, txtSegundoApellidoEP.KeyPress, _
        txtNombreInstitucionPJ.KeyPress, txtRazonSocialPJ.KeyPress, txtSiglasPJ.KeyPress, txtRepresentanteLegalPJ.KeyPress, txtNombreContactoPJ.KeyPress
        Try
            If (e.KeyChar < "0" Or e.KeyChar > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "." And UCase(e.KeyChar) <> "-" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en los Nombres
    Private Sub txtNombres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtPrimerNombrePN.TextChanged, txtSegundoNombrePN.TextChanged, txtPrimerApellidoPN.TextChanged, txtSegundoApellidoPN.TextChanged, _
        txtPrimerNombreEP.TextChanged, txtSegundoNombreEP.TextChanged, txtPrimerApellidoEP.TextChanged, txtSegundoApellidoEP.TextChanged, _
        txtNombreInstitucionPJ.TextChanged, txtRazonSocialPJ.TextChanged, txtSiglasPJ.TextChanged, txtRepresentanteLegalPJ.TextChanged, txtNombreContactoPJ.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Cedula
    Private Sub mtbNumCedulaRuc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles mtbNumCedulaPN.TextChanged, mtbNumCedulaEP.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()) BackSpace y la Barra espaciadora
    Private Sub txtDirecciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtDireccionPN.KeyPress, txtDireccionEP.KeyPress, txtDireccionPJ.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en la Dirección
    Private Sub txtDirecciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtDireccionPN.TextChanged, txtDireccionEP.TextChanged, txtDireccionPJ.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Números, () , - BackSpace y la Barra espaciadora
    Private Sub txtNumerosTelefonicos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtTelefonoPN.KeyPress, txtCelularPN.KeyPress, txtFaxPN.KeyPress, _
        txtTelefonoEP.KeyPress, txtCelularEP.KeyPress, txtFaxEP.KeyPress, _
        txtTelefonoPJ.KeyPress, txtCelularPJ.KeyPress, txtFaxPJ.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en los Numeros Telefonicos
    Private Sub txtNumerosTelefonicos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtTelefonoPN.TextChanged, txtCelularPN.TextChanged, txtFaxPN.TextChanged, _
        txtTelefonoEP.TextChanged, txtCelularEP.TextChanged, txtFaxEP.TextChanged, _
        txtTelefonoPJ.TextChanged, txtCelularPJ.TextChanged, txtFaxPJ.TextChanged
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, Números, -, _ y BackSpace
    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtEmailPN.KeyPress, txtEmailEP.KeyPress, txtEmailPJ.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And UCase(e.KeyChar) <> "_" And UCase(e.KeyChar) <> "." And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "@" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Email
    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtEmailPN.TextChanged, txtEmailEP.TextChanged, txtEmailPJ.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en las Opciones
    Private Sub OpcionesCambiaron_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles rbSexoMasculinoPN.CheckedChanged, rbSexoFemeninoPN.CheckedChanged, _
        rbSexoMasculinoEP.CheckedChanged, rbSexoFemeninoEP.CheckedChanged, _
        chkOtorgaCreditosPJ.CheckedChanged, _
        chkActivoPN.CheckedChanged, chkActivoEP.CheckedChanged, chkActivoPJ.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub OpcionesCambiaron_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles rbSexoMasculinoPN.GotFocus, rbSexoFemeninoPN.GotFocus, _
        rbSexoMasculinoEP.GotFocus, rbSexoFemeninoEP.GotFocus, _
        chkOtorgaCreditosPJ.GotFocus, _
        chkActivoPN.GotFocus, chkActivoEP.GotFocus, chkActivoPJ.GotFocus
        Try
            sender.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub OpcionesCambiaron_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles rbSexoMasculinoPN.LostFocus, rbSexoFemeninoPN.LostFocus, _
        rbSexoMasculinoEP.LostFocus, rbSexoFemeninoEP.LostFocus, _
        chkOtorgaCreditosPJ.LostFocus, _
        chkActivoPN.LostFocus, chkActivoEP.LostFocus, chkActivoPJ.LostFocus
        Try
            sender.BackColor = Me.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtSalarioEP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtSalarioEP.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And UCase(e.KeyChar) <> "." And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtSalarioEP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtSalarioEP.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNoInssEP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoInssEP.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNoInssEP_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtNoInssEP.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtSitioWebPJ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtSitioWebPJ.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And UCase(e.KeyChar) <> "." And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "/" And UCase(e.KeyChar) <> ":" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtSitioWebPJ_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtSitioWebPJ.TextChanged
        vbModifico = True
    End Sub

    Private Sub lblActivoPJ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblActivoPJ.Click

    End Sub

    Private Sub mtbNumRucPJ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumRucPJ.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkActivoPP_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkActivoPP.CheckedChanged
        CONTROLaCTIVO = Me.chkActivoPP.Name

    End Sub
End Class