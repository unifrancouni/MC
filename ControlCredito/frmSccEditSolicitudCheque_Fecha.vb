' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                06/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccEditSolicitudCheque_Fecha.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       generales de Solicitudes de Cheques.
'-------------------------------------------------------------------------
Public Class frmSccEditSolicitudCheque_Fecha

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSccSolicitudCheque As Long
    Dim IntHabilitar As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdtFuenteFondos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtTipoSolicitud As BOSistema.Win.XDataSet.xDataTable
    Dim XdtBeneficiario As BOSistema.Win.XDataSet.xDataTable
    Dim XdtEmpleado As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset (conjunto de tablas):
    Dim ObjSolicituddt As BOSistema.Win.SccEntCredito.SccSolicitudChequeDataTable
    Dim ObjSolicituddr As BOSistema.Win.SccEntCredito.SccSolicitudChequeRow

    Dim sColor As String
    Dim TipoChkAgregar As Integer
    'Color a mostrarse en el formulario
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property

    '1 Es Cheque de Gastos Solicitud de Cheque (Pagos Proveedores)
    '0 Es Cheque de Pago a Delegadas Solicitud de Cheque (Otros Cheques)
    Public Property TipoChequeAgregar() As Integer
        Get
            TipoChequeAgregar = TipoChkAgregar
        End Get
        Set(ByVal value As Integer)
            TipoChkAgregar = value
        End Set
    End Property

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdSolicitudCheque() As Long
        Get
            IdSolicitudCheque = IdSccSolicitudCheque
        End Get
        Set(ByVal value As Long)
            IdSccSolicitudCheque = value
        End Set
    End Property

    'Propiedad utilizada para habilitar o no Controles.
    Public Property IntHabilito() As Integer
        Get
            IntHabilito = IntHabilitar
        End Get
        Set(ByVal value As Integer)
            IntHabilitar = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       frmSccEditSolicitudCheque_Fecha_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditSolicitudCheque_Fecha_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjSolicituddt.Close()
                ObjSolicituddt = Nothing

                ObjSolicituddr.Close()
                ObjSolicituddr = Nothing

                XdtFuenteFondos.Close()
                XdtFuenteFondos = Nothing

                XdtTipoSolicitud.Close()
                XdtTipoSolicitud = Nothing

                XdtBeneficiario.Close()
                XdtBeneficiario = Nothing

                XdtEmpleado.Close()
                XdtEmpleado = Nothing

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       frmSccEditSolicitudCheque_Fecha_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditSolicitudCheque_Fecha_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            If Me.sColor = "Verde" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Registrar Solicitudes de Cheque")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Revisión de Solicitudes de Cheque")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFuenteFondos(0)
            CargarTipoSolicitud()
            CargarFirmas(0, 13)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm = "UPD" Then
                CargarSolicitudCheque()
                InhabilitarControles()
            End If

            Me.cdeFechaS.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            Dim StrSql As String
            'Inhabilitar todo el Bloque de Datos Generales:
            If IntHabilito = 0 Then
                'Si la Solicitud esta Autorizada, Anulada o Autorizada con CK:
                StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno > '3') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & IdSolicitudCheque & ")"
                If RegistrosAsociados(StrSql) Then
                    'Me.cmdAceptar.Enabled = False
                    'Me.grpDatosGenerales.Enabled = False

                    txtCodigo.Enabled = False
                    cdeFechaS.Enabled = False
                    cdeFechaTC.Enabled = False
                    cneMonto.Enabled = False
                    cboTipoS.Enabled = False
                    cboFuente.Enabled = False
                    cboBeneficiario.Enabled = False
                    cboFirmaS.Enabled = False
                    txtConcepto.Enabled = False
                    txtObservaciones.Enabled = False
                    cdeFechaCheque.Enabled = True

                Else
                    'En caso contrario: Solo Habilitar Observaciones y Concepto del Pago:
                    cdeFechaS.Enabled = False
                    cdeFechaTC.Enabled = False
                    cneMonto.Enabled = False
                    cboTipoS.Enabled = False
                    cboFuente.Enabled = False
                    cboBeneficiario.Enabled = False
                    cboFirmaS.Enabled = False
                    Me.txtConcepto.Select()
                End If
            Else
                'Si el Tipo de Solicitud de Pago es Automática:
                'bloquear datos que provienen de la Solicitud
                'de Desembolso de Fondos:
                If cboTipoS.Columns("nAutomatica").Value = 1 Then
                    cdeFechaS.Enabled = False
                    cdeFechaTC.Enabled = False
                    cneMonto.Enabled = False
                    cboTipoS.Enabled = False
                    'cboFuente.Enabled = False Se permitirá modificar la Cuenta siempre que aún no exista Codificación Contable.
                    cboBeneficiario.Enabled = False
                End If
            End If

            cneMonto.Enabled = False
            cboTipoS.Enabled = False
            cboFuente.Enabled = False
            cboBeneficiario.Enabled = False
            cboFirmaS.Enabled = False
            txtConcepto.Enabled = False
            txtObservaciones.Enabled = False

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Solicitud de Cheque"
            Else
                Me.Text = "Modificar Solicitud de Cheque"
            End If

            XdtFuenteFondos = New BOSistema.Win.XDataSet.xDataTable
            XdtTipoSolicitud = New BOSistema.Win.XDataSet.xDataTable
            XdtBeneficiario = New BOSistema.Win.XDataSet.xDataTable
            XdtEmpleado = New BOSistema.Win.XDataSet.xDataTable

            ObjSolicituddt = New BOSistema.Win.SccEntCredito.SccSolicitudChequeDataTable
            ObjSolicituddr = New BOSistema.Win.SccEntCredito.SccSolicitudChequeRow

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboTipoS.ClearFields()
            Me.cboBeneficiario.ClearFields()
            Me.cboFirmaS.ClearFields()

            If ModoFrm = "ADD" Then
                ObjSolicituddr = ObjSolicituddt.NewRow
                'Inicializar los Length de los campos (Strings?)
                Me.txtConcepto.MaxLength = ObjSolicituddr.GetColumnLenght("sConceptoPago")
                Me.txtObservaciones.MaxLength = ObjSolicituddr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       CargarSolicitudCheque
    ' Descripción:          Este procedimiento permite cargar los datos de la 
    '                       Solicitud de Cheque seleccionada en caso de estar 
    '                       en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarSolicitudCheque()
        Try

            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjSolicituddt.Filter = "nSccSolicitudChequeID = " & IdSolicitudCheque
            ObjSolicituddt.Retrieve()
            If ObjSolicituddt.Count = 0 Then
                Exit Sub
            End If
            ObjSolicituddr = ObjSolicituddt.Current

            'Código de la Solicitud:
            If Not ObjSolicituddr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjSolicituddr.nCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Fecha de Solicitud:
            If Not ObjSolicituddr.IsFieldNull("dFechaSolicitudCheque") Then
                Me.cdeFechaS.Value = ObjSolicituddr.dFechaSolicitudCheque
            Else
                Me.cdeFechaS.Value = Me.cdeFechaS.ValueIsDbNull
            End If

            'Fecha de Tipo de Cambio:
            If Not ObjSolicituddr.IsFieldNull("dFechaTipoCambio") Then
                Me.cdeFechaTC.Value = ObjSolicituddr.dFechaTipoCambio
            Else
                Me.cdeFechaTC.Value = Me.cdeFechaTC.ValueIsDbNull
            End If

            'Fecha Cheque:
            If Not ObjSolicituddr.IsFieldNull("dFechaCheque") Then
                Me.cdeFechaCheque.Value = ObjSolicituddr.dFechaCheque
            Else
                Me.cdeFechaCheque.Value = Me.cdeFechaCheque.ValueIsDbNull
            End If

            'Monto de la Solicitud:
            If Not ObjSolicituddr.IsFieldNull("nMonto") Then
                Me.cneMonto.Value = ObjSolicituddr.nMonto
            Else
                Me.cneMonto.Value = 0
            End If

            'Fuente de Fondos:
            If Not ObjSolicituddr.IsFieldNull("nScnFuenteFinanciamientoID") Then
                CargarFuenteFondos(ObjSolicituddr.nScnFuenteFinanciamientoID)
                If cboFuente.ListCount > 0 Then
                    Me.cboFuente.SelectedIndex = 0
                End If
                XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", ObjSolicituddr.nScnFuenteFinanciamientoID)
            Else
                Me.cboFuente.Text = ""
                Me.cboFuente.SelectedIndex = -1
            End If

            'Tipo de Solicitud:
            If Not ObjSolicituddr.IsFieldNull("nSccTipoSolicitudChequeID") Then
                CargarTipoSolicitud()
                If XdtTipoSolicitud.Count > 0 Then
                    Me.cboTipoS.SelectedIndex = 0
                End If
                XdtTipoSolicitud.SetCurrentByID("nSccTipoSolicitudChequeID", ObjSolicituddr.nSccTipoSolicitudChequeID)
            Else
                Me.cboTipoS.Text = ""
                Me.cboTipoS.SelectedIndex = -1
            End If

            'Empleado responsable de Solicitar:
            If Not ObjSolicituddr.IsFieldNull("nSrhEmpleadoSolicitaID") Then
                If Me.cboFirmaS.ListCount > 0 Then
                    Me.cboFirmaS.SelectedIndex = 0
                End If
                XdtEmpleado.SetCurrentByID("nSrhEmpleadoID", ObjSolicituddr.nSrhEmpleadoSolicitaID)
            Else
                Me.cboFirmaS.Text = ""
                Me.cboFirmaS.SelectedIndex = -1
            End If

            'Beneficiario del Cheque (Socia del Programa):
            If Not ObjSolicituddr.IsFieldNull("nSccSolicitudDesembolsoCreditoID") Then
                CargarBeneficiario(1, 0, ObjSolicituddr.nSccSolicitudDesembolsoCreditoID)
                If XdtBeneficiario.Count > 0 Then
                    Me.cboBeneficiario.SelectedIndex = 0
                End If
                XdtBeneficiario.SetCurrentByID("nBeneficiarioID", ObjSolicituddr.nSccSolicitudDesembolsoCreditoID)

                'ID de Persona Natural, Jurídica o Empleado
            ElseIf Not ObjSolicituddr.IsFieldNull("nStbPersonaBeneficiariaID") Then
                CargarBeneficiario(0, 0, ObjSolicituddr.nStbPersonaBeneficiariaID)
                If XdtBeneficiario.Count > 0 Then
                    Me.cboBeneficiario.SelectedIndex = 0
                End If
                XdtBeneficiario.SetCurrentByID("nBeneficiarioID", ObjSolicituddr.nStbPersonaBeneficiariaID)

            Else
                Me.cboBeneficiario.Text = ""
                Me.cboBeneficiario.SelectedIndex = -1
            End If

            'Concepto del Pago:
            If Not ObjSolicituddr.IsFieldNull("sConceptoPago") Then
                Me.txtConcepto.Text = ObjSolicituddr.sConceptoPago
            Else
                Me.txtConcepto.Text = ""
            End If

            'Observaciones:
            If Not ObjSolicituddr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjSolicituddr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtConcepto.MaxLength = ObjSolicituddr.GetColumnLenght("sConceptoPago")
            Me.txtObservaciones.MaxLength = ObjSolicituddr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarSolicitudCheque()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try

            ValidaDatosEntrada = True
            Me.errSolicitud.Clear()

            'Fecha de Solicitud:
            If Me.cdeFechaCheque.ValueIsDbNull Then
                MsgBox("La Fecha del Cheque NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del ChequeNO DEBE quedar vacía.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            ' Fecha del Cheque < Fecha de Solicitud:
            If Me.cdeFechaCheque.Value < Me.cdeFechaS.Value Then
                MsgBox("La Fecha del Cheque NO DEBE ser menor a la Fecha de Solicitud.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE ser menor a la Fecha de Solicitud.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'MsgBox(DateDiff("d", FechaServer(), cdeFechaCheque.Value))

            If DateDiff("d", FechaServer(), cdeFechaCheque.Value) > 7 Then
                MsgBox("La Fecha del Cheque NO DEBE ser siete días mayor a la fecha actual.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE ser siete días mayor a la fecha actual.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If


            If DateDiff("d", cdeFechaCheque.Value, FechaServer()) > 1 Then
                MsgBox("La Fecha del Cheque NO DEBE ser menor que la fecha actual.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE ser menor que la fecha actual.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    Private Sub SalvarSolicitudCheque()
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim strSQL As String

            'Actualiza usuario y fecha de creación:
            If ModoForm = "UPD" Then
                strSQL = "UPDATE SccSolicitudCheque SET dFechaCheque = '" & Format(cdeFechaCheque.Value, "yyyy/MM/dd") & "' WHERE nSccSolicitudChequeID = " & IdSolicitudCheque
                XcDatos.ExecuteScalar(strSQL) ' ObjSolicituddr.nStbDelegacionProgramaID = 
                MsgBox("Los fecha del cheque se actualizó satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
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
                res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarSolicitudCheque()
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
    ' Fecha:                06/11/2007
    ' Procedure Name:       CargarTipoSolicitud
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Solicitudes de Pagos.
    '                       En caso de Adición sólo se muestran solicitudes 
    '                       manuales. Si es Edición se inhabilita el combo
    '                       de tipo de solicitud automática y se habilita si
    '                       es manual.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoSolicitud()
        Try
            Dim Strsql As String = ""

            'En Adición: Sólo mostrar Solicitudes Manuales:
            If ModoForm = "ADD" Then

                If (TipoChequeAgregar = 1) Then 'Solicitud de Cheque (Pagos Proveedores)
                    Strsql = " Select a.nSccTipoSolicitudChequeID, a.sDescripcion, a.nAutomatica " & _
                                             " From SccTipoSolicitudCheque a " & _
                                             " Where (a.nSccTipoSolicitudChequeID = 3) " & _
                                             " Order by a.nSccTipoSolicitudChequeID"

                Else 'Solicitud de Cheque (Otros Cheques)
                    Strsql = " Select a.nSccTipoSolicitudChequeID, a.sDescripcion, a.nAutomatica " & _
                                             " From SccTipoSolicitudCheque a " & _
                                             " Where (a.nAutomatica = 0) " & _
                                             " Order by a.nSccTipoSolicitudChequeID"
                End If
            Else
                Strsql = " Select a.nSccTipoSolicitudChequeID, a.sDescripcion, a.nAutomatica " & _
                         " From SccTipoSolicitudCheque a " & _
                         " Order by a.nSccTipoSolicitudChequeID"
            End If

            XdtTipoSolicitud.ExecuteSql(Strsql)
            Me.cboTipoS.DataSource = XdtTipoSolicitud.Source

            Me.cboTipoS.Splits(0).DisplayColumns("nSccTipoSolicitudChequeID").Visible = False
            Me.cboTipoS.Splits(0).DisplayColumns("nAutomatica").Visible = False

            'Configurar el combo:
            Me.cboTipoS.Splits(0).DisplayColumns("sDescripcion").Width = 100
            Me.cboTipoS.Columns("sDescripcion").Caption = "Tipo de Solicitud de Cheque"
            Me.cboTipoS.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       CargarEmpleado
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Empleados sugiriendo el empleado registrado en 
    '                       parámetros para tercer firma:
    '                       como Empleado Solicitante.
    '-------------------------------------------------------------------------
    Private Sub CargarFirmas(ByVal intEmpleadoID As Integer, ByVal intParametroID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try

            Dim Strsql As String
            Me.cboFirmaS.ClearFields()

            If intEmpleadoID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                         " From vwStbEmpleado a " & _
                         " Where (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " & _
                         " Order by a.nCodPersona"
            Else
                Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                         " From vwStbEmpleado a " & _
                         " Where ((a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " & _
                         " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " & _
                         " Order by a.nCodPersona"
            End If

            XdtEmpleado.ExecuteSql(Strsql)
            Me.cboFirmaS.DataSource = XdtEmpleado.Source
            Me.cboFirmaS.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = " & intParametroID
            XdtValorParametro.Retrieve()
            If XdtEmpleado.Count > 0 Then
                XdtEmpleado.SetCurrentByID("nSrhEmpleadoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboFirmaS.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboFirmaS.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFirmaS.Splits(0).DisplayColumns("nCodPersona").Width = 50
            Me.cboFirmaS.Splits(0).DisplayColumns("sNombre").Width = 200
            Me.cboFirmaS.Columns("nCodPersona").Caption = "Código"
            Me.cboFirmaS.Columns("sNombre").Caption = "Nombre Empleado"
            Me.cboFirmaS.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFirmaS.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       CargarFuenteFondos
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarFuenteFondos(ByVal intFuenteID As Integer)
        Try
            Dim Strsql As String = ""

            If intFuenteID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) Or (a.nScnFuenteFinanciamientoID = " & intFuenteID & ") " & _
                         " Order by a.sCodigo"
            End If

            XdtFuenteFondos.ExecuteSql(Strsql)
            Me.cboFuente.DataSource = XdtFuenteFondos.Source

            Me.cboFuente.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Width = 47
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboFuente.Columns("sCodigo").Caption = "Código"
            Me.cboFuente.Columns("sNombre").Caption = "Descripción"

            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       CargarBeneficiario
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Beneficiarios del Cheque de acuerdo con la selección
    '                       del Tipo de Solicitud:
    '                           1. CK a Socias: Beneficiario = Socia de la SDC.
    '                           2. En caso contrario: Beneficiario = nStbPersonaID (Natural o Empleado).
    '-------------------------------------------------------------------------
    Private Sub CargarBeneficiario(ByVal intTipoSolicitudID As Integer, ByVal intLimpiarID As Integer, ByVal intBeneficiarioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBeneficiario.ClearFields()

            If intLimpiarID = 0 Then

                If intTipoSolicitudID = 1 Then 'Cheque a Socias (Solicitud Automática):
                    Strsql = " SELECT SCK.nSccSolicitudDesembolsoCreditoID AS nBeneficiarioID, SOCIA.sNombre1 + ' ' + SOCIA.sNombre2 + ' ' + SOCIA.sApellido1 + ' ' + SOCIA.sApellido2 AS sNombre " & _
                             " FROM  SccSolicitudCheque AS SCK INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN  SclFichaNotificacionDetalle AS DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN SclFichaSocia AS FICHA ON DFNC.nSclFichaSociaID = FICHA.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FICHA.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN  SclSocia AS SOCIA ON GS.nSclSociaID = SOCIA.nSclSociaID " & _
                             " WHERE (SCK.nSccSolicitudDesembolsoCreditoID = " & intBeneficiarioID & ")"
                Else

                    If (TipoChequeAgregar = 1) Then 'Beneficiario proveedor persona juridica

                        If intBeneficiarioID = 0 Then
                            Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'P' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                                     " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                                     " WHERE (StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno = 'P') " & _
                                     " Order by sNombre"
                        Else
                            Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'P' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                                     " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                                     " WHERE (StbPersona.nStbPersonaID = " & intBeneficiarioID & ") OR ((StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno = 'P'))  " & _
                                     " Order by sNombre"
                        End If

                    Else  'Beneficiario persona natural son las delegadas.
                        If intBeneficiarioID = 0 Then
                            Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                                     " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                                     " WHERE (StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno <> 'J') " & _
                                     " Order by sNombre"
                        Else
                            Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                                     " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                                     " WHERE (StbPersona.nStbPersonaID = " & intBeneficiarioID & ") OR ((StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno <> 'J'))  " & _
                                     " Order by sNombre"
                        End If


                    End If

                End If
            Else 'Limpiar Combo Beneficiario:
                Strsql = " Select a.nStbPersonaID as nBeneficiarioID, a.sNombre1 as sNombre " & _
                         " From StbPersona a " & _
                         " WHERE a.nStbPersonaID = 0"
            End If

            XdtBeneficiario.ExecuteSql(Strsql)
            Me.cboBeneficiario.DataSource = XdtBeneficiario.Source
            Me.cboBeneficiario.Rebind()

            'Configurar el combo Municipio:
            Me.cboBeneficiario.Splits(0).DisplayColumns("nBeneficiarioID").Visible = False
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboBeneficiario.Columns("sNombre").Caption = "Beneficiario del Cheque"
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()) BackSpace y la Barra espaciadora
    Private Sub txtConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
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
    Private Sub txtConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcepto.TextChanged
        vbModifico = True
    End Sub

    'En el cambio de Tipo de Solicitud Refresh Beneficiario:
    Private Sub cboTipoS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoS.TextChanged
        If Me.cboTipoS.SelectedIndex <> -1 Then
            CargarBeneficiario(cboTipoS.Columns("nSccTipoSolicitudChequeID").Value, 0, 0)
        Else
            CargarBeneficiario(0, 1, 0)
        End If
        vbModifico = True
    End Sub

    'Solo se permite Letras A - Z, Números, (,;.-:()) BackSpace y la Barra espaciadora
    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaS.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaTC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaTC.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboBeneficiario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBeneficiario.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirmaS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirmaS.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub
End Class