' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                25/07/2006
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditCtaBancaria.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de CtaBancaria.
'-------------------------------------------------------------------------
Public Class frmSteEditCtaBancaria

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdStbCtaBancaria As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsMetaTabla As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjCtaBancariadt As BOSistema.Win.SteEntTesoreria.SteCuentaBancariaDataTable
    Dim ObjCtaBancariadr As BOSistema.Win.SteEntTesoreria.SteCuentaBancariaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la CtaBancaria.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la CtaBancaria que corresponde al campo
    'SteCtaBancariaID de la tabla SteCtaBancaria.
    Public Property IdCtaBancaria() As Integer
        Get
            IdCtaBancaria = IdStbCtaBancaria
        End Get
        Set(ByVal value As Integer)
            IdStbCtaBancaria = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       frmStbEditCtaBancaria_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditCtaBancaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjCtaBancariadt = Nothing
                ObjCtaBancariadr = Nothing
                XdsMetaTabla = Nothing
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       frmStbEditCtaBancaria_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de la CtaBancaria en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditCtaBancaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            Me.HelpProvider.SetHelpKeyword(Me, "Cuentas Bancarias") 'Cuentas Bancarias (Tesorería)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarInstitucion(0)
            CargarMoneda(0)
            CargarTipoCuenta(0)

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoFrm = "UPD" Then
                CargarCtaBancaria()
                ObtenerSiModifica()
                If Me.chkCerrada.Checked = True Then
                    Me.chkCerrada.Select()
                Else
                    If Me.txtNombre.Enabled = True Then
                        Me.txtNombre.Select()
                    Else
                        Me.txtNumFinalCheque.Select()
                    End If
                End If
            Else
                Me.txtNumero.Select()
            End If
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub ObtenerSiModifica()
        Dim XdtCatalogoContable As New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
        Try
            XdtCatalogoContable.Filter = " nSteCuentaBancariaID = " & Me.IdStbCtaBancaria
            XdtCatalogoContable.Retrieve()

            'Si ya existe en Catalogo Contable:
            If XdtCatalogoContable.Count > 0 Then
                'If Me.chkCerrada.Checked = True Then
                Me.txtNumero.Enabled = False
                Me.txtNombre.Enabled = False
                Me.cboInstitucion.Enabled = False
                Me.cboTipoCuenta.Enabled = False
                Me.txtNumInicialCheque.Enabled = False
                Me.cboMoneda.Enabled = False
                Me.cdeFechaApertura.Enabled = False
                Me.cdeFechaCierre.Enabled = False
                Me.chkCerrada.Enabled = True
                Me.txtNumFinalCheque.Enabled = True

                'ElseIf Me.chkCerrada.Checked = False Then
                '    Me.txtNumero.Enabled = False
                '    Me.txtNombre.Enabled = True
                '    Me.cboInstitucion.Enabled = False
                '    Me.cboTipoCuenta.Enabled = True
                '    Me.cboMoneda.Enabled = False
                '    Me.cdeFechaApertura.Enabled = False
                '    Me.txtNumInicialCheque.Enabled = False
                '    'Me.cdeFechaCierre.Enabled = True
                'End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtCatalogoContable.Close()
            XdtCatalogoContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim strFecha As String
            Dim dFechaInicioPrograma As Date

            If ModoFrm = "ADD" Then
                Me.chkCerrada.Enabled = False
                Me.Text = "Agregar Cuenta Bancaria"
            Else
                Me.Text = "Modificar Cuenta Bancaria"
            End If

            ObjCtaBancariadt = New BOSistema.Win.SteEntTesoreria.SteCuentaBancariaDataTable
            ObjCtaBancariadr = New BOSistema.Win.SteEntTesoreria.SteCuentaBancariaRow
            XdsMetaTabla = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            XdtValorParametro.Filter = "nStbParametroID = 4"
            XdtValorParametro.Retrieve()

            strFecha = Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 1, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 3, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 5, 4)

            dFechaInicioPrograma = CDate(strFecha)
            Me.cdeFechaApertura.Calendar.MinDate = CDate(strFecha)
            Me.cdeFechaApertura.Calendar.MaxDate = FechaServer()

            Me.cdeFechaApertura.Value = FechaServer.Date
            Me.cdeFechaCierre.Enabled = False
            Me.chkCerrada.Checked = False

            'Limpiar los combos
            Me.cboInstitucion.ClearFields()
            Me.cboMoneda.ClearFields()
            Me.cboTipoCuenta.ClearFields()

            If ModoFrm = "ADD" Then
                ObjCtaBancariadr = ObjCtaBancariadt.NewRow

                'Inicializar los Length de los campos
                Me.txtNumero.MaxLength = ObjCtaBancariadr.GetColumnLenght("sNumeroCuenta")
                Me.txtNombre.MaxLength = ObjCtaBancariadr.GetColumnLenght("sNombreCuenta")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       CargarCtaBancaria
    ' Descripción:          Este procedimiento permite cargar los datos de la CtaBancaria
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarCtaBancaria()
        Try

            '-- Buscar la CtaBancaria correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjCtaBancariadt.Filter = "nSteCuentaBancariaID = " & IdCtaBancaria
            ObjCtaBancariadt.Retrieve()
            If ObjCtaBancariadt.Count = 0 Then
                Exit Sub
            End If
            ObjCtaBancariadr = ObjCtaBancariadt.Current

            'Institución
            If Not ObjCtaBancariadr.IsFieldNull("nStbPersonaID") Then
                CargarInstitucion(ObjCtaBancariadr.nStbPersonaID)
                If Me.cboInstitucion.ListCount > 0 Then
                    Me.cboInstitucion.SelectedIndex = 0
                End If
                XdsMetaTabla("Institucion").SetCurrentByID("nStbPersonaID", ObjCtaBancariadr.nStbPersonaID)
            Else
                Me.cboInstitucion.Text = ""
                Me.cboInstitucion.SelectedIndex = -1
            End If

            'Número de la Cuenta
            If Not ObjCtaBancariadr.IsFieldNull("sNumeroCuenta") Then
                Me.txtNumero.Text = ObjCtaBancariadr.sNumeroCuenta
            Else
                Me.txtNumero.Text = ""
            End If

            'Nombre de la Cuenta
            If Not ObjCtaBancariadr.IsFieldNull("sNombreCuenta") Then
                Me.txtNombre.Text = ObjCtaBancariadr.sNombreCuenta
            Else
                Me.txtNombre.Text = ""
            End If

            'Moneda
            If Not ObjCtaBancariadr.IsFieldNull("nStbMonedaID") Then
                CargarMoneda(ObjCtaBancariadr.nStbMonedaID)
                If Me.cboMoneda.ListCount > 0 Then
                    Me.cboMoneda.SelectedIndex = 0
                End If
                XdsMetaTabla("TipoMoneda").SetCurrentByID("nStbMonedaID", ObjCtaBancariadr.nStbMonedaID)
            Else
                Me.cboMoneda.Text = ""
                Me.cboMoneda.SelectedIndex = -1
            End If

            'Tipo de Cuenta
            If Not ObjCtaBancariadr.IsFieldNull("nStbTipoCuentaID") Then
                CargarTipoCuenta(ObjCtaBancariadr.nStbTipoCuentaID)
                If XdsMetaTabla("TipoCuenta").Count > 0 Then
                    Me.cboTipoCuenta.SelectedIndex = 0
                End If
                XdsMetaTabla("TipoCuenta").SetCurrentByID("nStbValorCatalogoID", ObjCtaBancariadr.nStbTipoCuentaID)
            Else
                Me.cboTipoCuenta.Text = ""
                Me.cboTipoCuenta.SelectedIndex = -1
            End If

            'Número Inicial de Cheque
            If Not ObjCtaBancariadr.IsFieldNull("nNumeroInicialCheque") Then
                Me.txtNumInicialCheque.Text = ObjCtaBancariadr.nNumeroInicialCheque
            Else
                Me.txtNumInicialCheque.Text = ""
            End If

            'Número Final de Cheque
            If Not ObjCtaBancariadr.IsFieldNull("nNumeroFinalCheque") Then
                Me.txtNumFinalCheque.Text = ObjCtaBancariadr.nNumeroFinalCheque
            Else
                Me.txtNumFinalCheque.Text = ""
            End If

            'Fecha de Apertura
            If Not ObjCtaBancariadr.IsFieldNull("dFechaApertura") Then
                Me.cdeFechaApertura.Value = ObjCtaBancariadr.dFechaApertura
            Else
                Me.cdeFechaApertura.Value = FechaServer()
            End If

            'Estado
            If Not ObjCtaBancariadr.IsFieldNull("nCerrada") Then
                If ObjCtaBancariadr.nCerrada = 1 Then
                    Me.chkCerrada.Checked = True
                Else
                    Me.chkCerrada.Checked = False
                End If
                If Me.chkCerrada.Checked = True Then
                    Me.txtNumero.Enabled = False
                    Me.txtNombre.Enabled = False
                    Me.cboInstitucion.Enabled = False
                    Me.cboTipoCuenta.Enabled = False
                    Me.txtNumInicialCheque.Enabled = False
                    Me.cboMoneda.Enabled = False
                    Me.cdeFechaApertura.Enabled = False
                    Me.cdeFechaCierre.Enabled = False
                    Me.txtNumFinalCheque.Enabled = False
                ElseIf Me.chkCerrada.Checked = False Then
                    Me.txtNumero.Enabled = True
                    Me.txtNombre.Enabled = True
                    Me.cboInstitucion.Enabled = True
                    Me.cboTipoCuenta.Enabled = True
                    Me.cboMoneda.Enabled = True
                    Me.cdeFechaApertura.Enabled = True
                    Me.txtNumInicialCheque.Enabled = True
                    Me.txtNumFinalCheque.Enabled = True
                    'Me.cdeFechaCierre.Enabled = True
                End If
            Else
                Me.chkCerrada.Checked = False
            End If

            'Fecha de Cierre
            If Not ObjCtaBancariadr.IsFieldNull("dFechaCierre") Then
                Me.cdeFechaCierre.Value = ObjCtaBancariadr.dFechaCierre
            End If

            If Not ObjCtaBancariadr.IsFieldNull("nCerrada") Then
                If ObjCtaBancariadr.nCerrada = 0 Then
                    Me.chkCerrada.Checked = False
                    Me.cdeFechaCierre.Enabled = False
                Else
                    Me.chkCerrada.Checked = True
                    Me.cdeFechaCierre.Enabled = True
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtNumero.MaxLength = ObjCtaBancariadr.GetColumnLenght("sNumeroCuenta")
            Me.txtNombre.MaxLength = ObjCtaBancariadr.GetColumnLenght("sNombreCuenta")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                11/07/2006
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCtaBancaria()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                11/07/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjCuenta As New BOSistema.Win.SteEntTesoreria.SteCuentaBancariaDataTable
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim dtmFecha As Date
            Dim strSQL As String = ""
            Dim dFechaInicioPrograma As Date
            Dim dtmFechaCierre As Date
            Dim strFecha As String

            ValidaDatosEntrada = True
            Me.errCtaBancaria.Clear()

            'Número de la Cuenta:
            If Trim(RTrim(Me.txtNumero.Text)).ToString.Length = 0 Then
                MsgBox("El Número de la Cuenta NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.txtNumero, "El Número de la Cuenta NO DEBE quedar vacío.")
                Me.txtNumero.Focus()
                Exit Function
            End If

            'Institución:
            If Me.cboInstitucion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Institución Bancaria válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.cboInstitucion, "Debe seleccionar una Institución Bancaria válida.")
                Me.cboInstitucion.Focus()
                Exit Function
            End If

            'Determinar duplicados en el Número de la Cuenta para un mismo Banco:
            If ModoFrm = "UPD" Then
                ObjCuenta.Filter = " Upper(sNumeroCuenta) = '" & UCase(Me.txtNumero.Text) & "' And nStbPersonaID = " & XdsMetaTabla("Institucion").ValueField("nStbPersonaID") & " And nSteCuentaBancariaID <> " & ObjCtaBancariadr.nSteCuentaBancariaID
            Else
                ObjCuenta.Filter = " Upper(sNumeroCuenta) = '" & UCase(Me.txtNumero.Text) & "' And nStbPersonaID = " & XdsMetaTabla("Institucion").ValueField("nStbPersonaID")
            End If

            ObjCuenta.Retrieve()

            If ObjCuenta.Count > 0 Then
                MsgBox("Número de Cuenta NO DEBE repetirse para un mismo Banco. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.txtNumero, "Número de Cuenta NO DEBE repetirse para un mismo Banco.")
                Me.txtNumero.Focus()
                Exit Function
            End If

            'Nombre de la Cuenta:
            If Trim(RTrim(Me.txtNombre.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre de la Cuenta NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.txtNombre, "El Nombre de la Cuenta NO DEBE quedar vacío.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Determinar duplicados en el Nombre de la Cuenta para un mismo Banco:
            If ModoFrm = "UPD" Then
                ObjCuenta.Filter = " LTrim(RTrim(sNombreCuenta)) = '" & LTrim(RTrim(Me.txtNombre.Text)) & "' And nStbPersonaID = " & XdsMetaTabla("Institucion").ValueField("nStbPersonaID") & " And nSteCuentaBancariaID <> " & ObjCtaBancariadr.nSteCuentaBancariaID
            Else
                ObjCuenta.Filter = " LTrim(RTrim(sNombreCuenta)) = '" & LTrim(RTrim(Me.txtNombre.Text)) & "' And nStbPersonaID = " & XdsMetaTabla("Institucion").ValueField("nStbPersonaID")
            End If

            ObjCuenta.Retrieve()

            If ObjCuenta.Count > 0 Then
                MsgBox("Nombre de la Cuenta NO DEBE repetirse para una misma Institución. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.txtNombre, "Nombre de la Cuenta NO DEBE repetirse para una misma Institución.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Fecha de Apertura:
            If Me.cdeFechaApertura.ValueIsDbNull Then
                MsgBox("La Fecha de Apertura NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.cdeFechaApertura, "La Fecha de Apertura NO DEBE quedar vacía.")
                Me.cdeFechaApertura.Focus()
                Exit Function
            End If

            dtmFecha = Me.cdeFechaApertura.Value

            XdtValorParametro.Filter = "nStbParametroID = 4"
            XdtValorParametro.Retrieve()

            strFecha = Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 1, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 3, 2) & "-" & _
                    Strings.Mid(XdtValorParametro.ValueField("sValorParametro"), 5, 4)

            dFechaInicioPrograma = CDate(strFecha)

            'Fecha de Inscripción no menor que la Fecha de Inicio del Programa:
            If dtmFecha.Date < dFechaInicioPrograma.Date Then
                MsgBox("Fecha de Apertura (" & dtmFecha.Date & ") NO DEBE ser Menor que la Fecha de Inicio del Programa (" & dFechaInicioPrograma.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.cdeFechaApertura, "Fecha de Apertura (" & dtmFecha.Date & ") NO DEBE ser Menor que la Fecha de Inicio del Programa (" & dFechaInicioPrograma.Date & ").")
                Me.cdeFechaApertura.Focus()
                Exit Function
            End If

            'Fecha de Apertura no mayor que la Fecha del Servidor:
            If dtmFecha.Date > FechaServer().Date Then
                MsgBox("Fecha de Apertura (" & dtmFecha.Date & ") NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.cdeFechaApertura, "Fecha de Apertura (" & dtmFecha.Date & ") NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").")
                Me.cdeFechaApertura.Focus()
                Exit Function
            End If

            'Tipo de Cuenta:
            If Me.cboTipoCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Cuenta válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.cboTipoCuenta, "Debe seleccionar un Tipo de Cuenta válido.")
                Me.cboTipoCuenta.Focus()
                Exit Function
            End If

            'Validar que si la Cuenta es Corriente, debe especificar 
            'Número Inicial y Número Final de Chequera:
            If XdsMetaTabla("TipoCuenta").ValueField("sCodigoInterno") = "2" Then 'Cta Corriente
                'Indicar Número Inicial de Cheque: 
                If Trim(RTrim(Me.txtNumInicialCheque.Text)).ToString.Length = 0 Then
                    MsgBox("El Número Inicial de Cheque NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.txtNumInicialCheque, "El Número Inicial de Cheque NO DEBE quedar vacío.")
                    Me.txtNumInicialCheque.Focus()
                    Exit Function
                End If
                'Número Inicial diferente de Cero:
                If CInt(Me.txtNumInicialCheque.Text) = 0 Then
                    MsgBox("El Número Inicial de Cheque DEBE ser Mayor que Cero(0).", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.txtNumInicialCheque, "El Número Inicial de Cheque DEBE ser Mayor que Cero(0).")
                    Me.txtNumInicialCheque.Focus()
                    Exit Function
                End If
                'Indicar Número Final de Cheque: 
                If Trim(RTrim(Me.txtNumFinalCheque.Text)).ToString.Length = 0 Then
                    MsgBox("El Número Final de Chequera NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.txtNumFinalCheque, "El Número Final de Chequera NO DEBE quedar vacío.")
                    Me.txtNumFinalCheque.Focus()
                    Exit Function
                End If
                'Número Final diferente de Cero:
                If CInt(Me.txtNumFinalCheque.Text) = 0 Then
                    MsgBox("El Número Final de Chequera DEBE ser Mayor que Cero(0).", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.txtNumFinalCheque, "El Número Final de Chequera DEBE ser Mayor que Cero(0).")
                    Me.txtNumFinalCheque.Focus()
                    Exit Function
                End If
                'Numero Final debe ser mayor que el Inicial:
                If CInt(Me.txtNumFinalCheque.Text) <= CInt(Me.txtNumInicialCheque.Text) Then
                    MsgBox("El Número Final de Chequera DEBE ser Mayor que el Inicial.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.txtNumFinalCheque, "El Número Final de Chequera DEBE ser Mayor que Inicial.")
                    Me.txtNumFinalCheque.Focus()
                    Exit Function
                End If
            End If

            'Moneda:
            If Me.cboMoneda.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Moneda válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCtaBancaria.SetError(Me.cboMoneda, "Debe seleccionar una Moneda válida.")
                Me.cboMoneda.Focus()
                Exit Function
            End If

            'Permitir que el usuario cambie el estado de la cuenta a Abierto si su saldo de
            'cuenta bancaria es cero.
            'If Me.ModoFrm = "UPD" And Me.ObjCtaBancariadr.objEstadoCtaBancariaID <> XdsMetaTabla("EstadoCuenta").ValueField("StbValorCatalogoID") Then
            '    If XdsMetaTabla("EstadoCuenta").ValueField("CodigoInterno") = "A" Then
            '        If Me.ObjCtaBancariadr.Saldo <= 0 Then
            '            MsgBox("No puede Abrir la Cuenta. Saldo cero.", MsgBoxStyle.Critical, "SIAFI")
            '            ValidaDatosEntrada = False
            '            Me.errCtaBancaria.SetError(Me.cboEstadoCuenta, "No puede Abrir la Cuenta. Saldo cero.")
            '            Me.cboEstadoCuenta.Focus()
            '            Exit Function
            '        End If
            '    End If
            'End If

            'Cerrada - Fecha de Cierre
            If Me.chkCerrada.Checked = True Then

                strSQL = " SELECT nScnTransaccionParametroID FROM vwScnParametroTransaccion " & _
                         " WHERE nSteCuentaBancariaID = " & Me.IdStbCtaBancaria

                XdtDatos.ExecuteSql(strSQL)

                If XdtDatos.Count > 0 Then
                    MsgBox("La Cuenta NO DEBE ser Cerrada." & Chr(10) & _
                            "Existe como Parámetro para Transacciones automáticas.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.chkCerrada, "La Cuenta NO DEBE ser Cerrada." & Chr(10) & _
                            "Existe como Parámetro para Transacciones automáticas.")
                    Me.chkCerrada.Focus()
                    Exit Function
                End If

                If Me.cdeFechaCierre.ValueIsDbNull Then
                    MsgBox("La Fecha de Cierre NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.cdeFechaCierre, "La Fecha de Cierre NO DEBE quedar vacía.")
                    Me.cdeFechaCierre.Focus()
                    Exit Function
                End If

                dtmFechaCierre = Me.cdeFechaCierre.Value

                'Fecha de Cierre Menor que la Fecha de Apertura
                If dtmFechaCierre.Date < dtmFecha.Date Then
                    MsgBox("Fecha de Cierre (" & dtmFechaCierre.Date & ") NO DEBE ser Menor que la Fecha de Apertura (" & dtmFecha.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.cdeFechaCierre, "Fecha Cierre (" & dtmFechaCierre.Date & ") NO DEBE ser Menor que la Fecha de Apertura (" & dtmFecha.Date & ").")
                    Me.cdeFechaCierre.Focus()
                    Exit Function
                End If

                'Fecha de Cierre mayor que la fecha del servidor
                If dtmFechaCierre.Date > FechaServer.Date Then
                    MsgBox("Fecha de Cierre (" & dtmFechaCierre.Date & ") NO DEBE ser Mayor que Fecha Actual (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCtaBancaria.SetError(Me.cdeFechaCierre, "Fecha de Cierre (" & dtmFechaCierre.Date & ") NO DEBE ser Mayor que Fecha Actual (" & FechaServer.Date & ").")
                    Me.cdeFechaCierre.Focus()
                    Exit Function
                End If

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjCuenta.Close()
            ObjCuenta = Nothing

            XdtValorParametro.Close()
            XdtValorParametro = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       SalvarCtaBancaria
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Cuenta en la Base de Datos.
    '-------------------------------------------------------------------------
    Public Sub SalvarCtaBancaria()
        Try
            If ModoFrm = "ADD" Then
                ' ObjCtaBancariadr = ObjCtaBancariadt.NewRow
                ObjCtaBancariadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjCtaBancariadr.dFechaCreacion = FechaServer()
            Else
                ObjCtaBancariadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjCtaBancariadr.dFechaModificacion = FechaServer()
            End If

            ObjCtaBancariadr.sNombreCuenta = Me.txtNombre.Text
            ObjCtaBancariadr.sNumeroCuenta = Me.txtNumero.Text
            ObjCtaBancariadr.dFechaApertura = Me.cdeFechaApertura.Value
            ObjCtaBancariadr.nNumeroInicialCheque = Me.txtNumInicialCheque.Text
            ObjCtaBancariadr.nNumeroFinalCheque = Me.txtNumFinalCheque.Text

            If Me.cdeFechaCierre.ValueIsDbNull Then
                ObjCtaBancariadr.SetFieldNull("dFechaCierre")
            Else
                ObjCtaBancariadr.dFechaCierre = Me.cdeFechaCierre.Value
            End If

            ObjCtaBancariadr.nStbPersonaID = XdsMetaTabla("Institucion").ValueField("nStbPersonaID")
            ObjCtaBancariadr.nStbMonedaID = XdsMetaTabla("TipoMoneda").ValueField("nStbMonedaID")
            ObjCtaBancariadr.nStbTipoCuentaID = XdsMetaTabla("TipoCuenta").ValueField("nStbValorCatalogoID")

            If Me.chkCerrada.Checked = False Then
                ObjCtaBancariadr.nCerrada = 0
                ObjCtaBancariadr.SetFieldNull("dFechaCierre")
            Else
                ObjCtaBancariadr.nCerrada = 1
                ObjCtaBancariadr.dFechaCierre = Me.cdeFechaCierre.Value
            End If

            ObjCtaBancariadr.Update()

            'Asignar el Id de la CtaBancaria a la 
            'variable publica del formulario
            IdStbCtaBancaria = ObjCtaBancariadr.nSteCuentaBancariaID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
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
                        If ValidaDatosEntrada() Then
                            SalvarCtaBancaria()
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
                        Me.IdCtaBancaria = 0
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.IdCtaBancaria = 0
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       CargarInstitucion
    ' Descripción:          Este procedimiento permite cargar el listado de Bancos
    '                       en el combo para su selección y carga también el combo
    '                       para Sucursales que trabaja como Maestro-Detalle con el de Bancos.
    '-------------------------------------------------------------------------
    Public Sub CargarInstitucion(ByVal intInstitucionID As Integer)
        Try
            Dim Strsql As String

            If intInstitucionID = 0 Then
                Strsql = " Select a.nStbPersonaID,a.sSiglas,a.sNombre1 AS sRazonSocial,a.sNumRUC " & _
                         " From StbPersona a " & _
                         " WHERE (a.nOtorgaCredito = 1 And a.nPersonaActiva = 1)" & _
                         " Order by a.sSiglas Asc"
            Else
                Strsql = " Select a.nStbPersonaID,a.sSiglas,a.sNombre1 as sRazonSocial,a.sNumRUC " & _
                         " From StbPersona a " & _
                         " WHERE (a.nOtorgaCredito = 1 And a.nPersonaActiva = 1) or a.nStbPersonaID = " & intInstitucionID & _
                         " Order by a.sSiglas Asc"
            End If

            If XdsMetaTabla.ExistTable("Institucion") Then
                XdsMetaTabla("Institucion").ExecuteSql(Strsql)
            Else
                XdsMetaTabla.NewTable(Strsql, "Institucion")
                XdsMetaTabla("Institucion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboInstitucion.DataSource = XdsMetaTabla("Institucion").Source

            Me.cboInstitucion.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            'Me.cboInstitucion.Splits(0).DisplayColumns("Sigla").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboInstitucion.Splits(0).DisplayColumns("sSiglas").Width = 70
            Me.cboInstitucion.Splits(0).DisplayColumns("sRazonSocial").Width = 120
            Me.cboInstitucion.Splits(0).DisplayColumns("sNumRUC").Width = 100

            Me.cboInstitucion.Columns("sSiglas").Caption = "Siglas"
            Me.cboInstitucion.Columns("sRazonSocial").Caption = "Razón Social"
            Me.cboInstitucion.Columns("sNumRUC").Caption = "No.RUC"

            Me.cboInstitucion.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboInstitucion.Splits(0).DisplayColumns("sRazonSocial").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboInstitucion.Splits(0).DisplayColumns("sNumRUC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       CargarMoneda
    ' Descripción:          Este procedimiento permite cargar el listado de Monedas
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarMoneda(ByVal intMonedaID As Integer)
        Try
            Dim Strsql As String = ""

            If intMonedaID = 0 Then
                Strsql = " Select a.nStbMonedaID,a.sCodigoInterno,a.sDescripcion,a.sSimbolo " & _
                         " From StbMoneda a " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "
            Else
                Strsql = " Select a.nStbMonedaID,a.sCodigoInterno,a.sDescripcion,a.sSimbolo " & _
                         " From StbMoneda a " & _
                         " WHERE a.nActivo = 1 or a.nStbMonedaID = " & intMonedaID & _
                         " Order by a.sCodigoInterno "
            End If

            If XdsMetaTabla.ExistTable("TipoMoneda") Then
                XdsMetaTabla("TipoMoneda").ExecuteSql(Strsql)
            Else
                XdsMetaTabla.NewTable(Strsql, "TipoMoneda")
                XdsMetaTabla("TipoMoneda").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMoneda.DataSource = XdsMetaTabla("TipoMoneda").Source

            Me.cboMoneda.Splits(0).DisplayColumns("nStbMonedaID").Visible = False
            Me.cboMoneda.Splits(0).DisplayColumns("sSimbolo").Visible = False

            Me.cboMoneda.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMoneda.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboMoneda.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboMoneda.Columns("sCodigoInterno").Caption = "Código"
            Me.cboMoneda.Columns("sDescripcion").Caption = "Descripción"

            Me.cboMoneda.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMoneda.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       CargarTipoCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos de Cuentas
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarTipoCuenta(ByVal intTipoCuentaID As Integer)
        Try
            Dim Strsql As String = ""

            If intTipoCuentaID = 0 Then
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoCuentaBancaria') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "
            Else
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoCuentaBancaria') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 OR a.nStbValorCatalogoID = " & intTipoCuentaID & _
                         " Order by a.sCodigoInterno "
            End If

            If XdsMetaTabla.ExistTable("TipoCuenta") Then
                XdsMetaTabla("TipoCuenta").ExecuteSql(Strsql)
            Else
                XdsMetaTabla.NewTable(Strsql, "TipoCuenta")
                XdsMetaTabla("TipoCuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoCuenta.DataSource = XdsMetaTabla("TipoCuenta").Source

            Me.cboTipoCuenta.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoCuenta.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoCuenta.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoCuenta.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoCuenta.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoCuenta.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoCuenta.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoCuenta.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboInstitucion_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboInstitucion.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en el Banco
    Private Sub cboInstitucion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInstitucion.TextChanged
        vbModifico = True
    End Sub
    'Solo se permite números, BackSpace 
    Private Sub txtNumero_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        Try
            If e.KeyChar <> Convert.ToChar(Keys.Back) And (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Número de la Cuenta
    Private Sub txtNumero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumero.TextChanged
        vbModifico = True
    End Sub
    'Solo se permite Letras A - Z, números, BackSpace y la Barra espaciadora
    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "/" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "." Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el Nombre de la Cuenta
    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Fecha de Apertura
    Private Sub cdeFechaApertura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaApertura.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Fecha de Cierre
    Private Sub cdeFechaCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCierre.TextChanged
        vbModifico = True
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub cboTipoCuenta_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboTipoCuenta.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en el Tipo de Cuenta
    Private Sub cboTipoCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCuenta.TextChanged
        If Me.cboTipoCuenta.SelectedIndex <> -1 Then
            If XdsMetaTabla("TipoCuenta").ValueField("sCodigoInterno") = "1" Then  'Ahorro
                Me.txtNumInicialCheque.Enabled = False
                Me.txtNumInicialCheque.Text = "0"
                Me.txtNumFinalCheque.Enabled = False
                Me.txtNumFinalCheque.Text = "0"
            ElseIf XdsMetaTabla("TipoCuenta").ValueField("sCodigoInterno") = "2" Then 'Corriente
                Me.txtNumInicialCheque.Enabled = True
                Me.txtNumFinalCheque.Enabled = True
            End If
        End If
        vbModifico = True
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub cboMoneda_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboMoneda.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en el Combo de la Moneda
    Private Sub cboMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMoneda.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkCerrada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCerrada.CheckedChanged
        Try
            If Me.chkCerrada.Checked = False Then
                Me.cdeFechaCierre.Value = Me.cdeFechaCierre.ValueIsDbNull
                Me.cdeFechaCierre.Enabled = False
            Else
                Me.cdeFechaCierre.Enabled = True
                Me.cdeFechaCierre.BackColor = Color.White
            End If
            vbModifico = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNumInicialCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumInicialCheque.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNumInicialCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumInicialCheque.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNumFinalCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumFinalCheque.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNumFinalCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumFinalCheque.TextChanged
        vbModifico = True
    End Sub
End Class