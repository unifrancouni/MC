' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                23/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditCheque.vb
' Descripción:          Este formulario permite MODIFICAR datos
'                       generales de Comprobantes de Cheque:
'                       CK: Cheque Socias (Entrega Préstamos).
'                       CE: Comprobante de Egreso (Otros Cheques)
'-------------------------------------------------------------------------
Public Class frmScnEditCheque

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdScnComprobante As Long
    Dim IntHabilitar As Integer
    Dim IntCodificacion As Integer
    Dim IdSccTipoSolicitud As Integer
    Dim StrNoCheque As String

    '-- Clases para procesar la informacion de los combos
    Dim XdtFuenteFondos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtBeneficiario As BOSistema.Win.XDataSet.xDataTable
    Dim XdtSolicitud As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset (conjunto de tablas):
    Dim ObjComprobantedt As BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableDataTable
    Dim ObjComprobantedr As BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableRow

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Comprobante.
    Public Property IdComprobante() As Long
        Get
            IdComprobante = IdScnComprobante
        End Get
        Set(ByVal value As Long)
            IdScnComprobante = value
        End Set
    End Property

    'Propiedad utilizada para Comparar Fecha CD.
    Public Property IdTipoSolicitud() As Integer
        Get
            IdTipoSolicitud = IdSccTipoSolicitud
        End Get
        Set(ByVal value As Integer)
            IdSccTipoSolicitud = value
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

    'Propiedad utilizada para habilitar o no Controles.
    Public Property IntCodifica() As Integer
        Get
            IntCodifica = IntCodificacion
        End Get
        Set(ByVal value As Integer)
            IntCodificacion = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       frmScnEditComprobante_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditComprobante_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjComprobantedt.Close()
                ObjComprobantedt = Nothing

                ObjComprobantedr.Close()
                ObjComprobantedr = Nothing

                XdtFuenteFondos.Close()
                XdtFuenteFondos = Nothing

                XdtBeneficiario.Close()
                XdtBeneficiario = Nothing

                XdtSolicitud.Close()
                XdtSolicitud = Nothing

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
    ' Fecha:                23/11/2007
    ' Procedure Name:       frmScnEditComprobante_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditComprobante_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFuenteFondos(0)
            CargarBeneficiario(IdTipoSolicitud, 0)
            CargarSolicitud(0)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm <> "ADD" Then 'Aplica para = "UPD" y para = "UPDCk"
                CargarComprobanteCheque()
                InhabilitarControles()
            End If

            'Numero de Cheque solo estaría habilitado para Gestión de Recursos.
            If Me.txtNoCheque.Enabled = True Then
                Me.txtNoCheque.Select()
            Else
                Me.txtCUE.Select()
            End If

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
    ' Fecha:                23/11/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            'En caso de Inhabilitar todo el Bloque de Datos Generales:
            If IntHabilitar = 0 Then
                Me.cmdAceptar.Enabled = False
                Me.grpDatosGenerales.Enabled = False
            Else
                '1. Si es edición del Contador:
                If ModoForm = "UPD" Then
                    Me.txtNoCheque.Enabled = False
                    Me.txtCUE.Enabled = True
                    Me.txtConcepto.Enabled = True
                    Me.txtObservaciones.Enabled = True
                    '2. Si es edición de Chequera (Gestión de Recursos):
                Else
                    Me.txtNoCheque.Enabled = True
                    Me.txtCUE.Enabled = False
                    Me.txtConcepto.Enabled = False
                    Me.txtObservaciones.Enabled = False
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Comprobante de Cheque"
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Comprobante de Cheque"
            Else
                Me.Text = "Modificar Número de Cheque"
            End If

            XdtFuenteFondos = New BOSistema.Win.XDataSet.xDataTable
            XdtBeneficiario = New BOSistema.Win.XDataSet.xDataTable
            XdtSolicitud = New BOSistema.Win.XDataSet.xDataTable

            ObjComprobantedt = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableDataTable
            ObjComprobantedr = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableRow

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboBeneficiario.ClearFields()
            Me.cboSolicitudCK.ClearFields()

            If ModoForm = "ADD" Then
                ObjComprobantedr = ObjComprobantedt.NewRow
                'Inicializar los Length de los campos String:
                Me.txtConcepto.MaxLength = ObjComprobantedr.GetColumnLenght("sDescripcion")
                Me.txtObservaciones.MaxLength = ObjComprobantedr.GetColumnLenght("sObservaciones")
                Me.txtCUE.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCUE")
                Me.txtNoCheque.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroTransaccion") - Len(txtCodigo.Text)
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       CargarComprobanteCheque
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Comprobante de Cheque.
    '-------------------------------------------------------------------------
    Private Sub CargarComprobanteCheque()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim IntLenCtaBanco As Integer
            Dim IdSolicitudD As Long
            Dim StrSql As String
            '-- Buscar el Comprobante correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjComprobantedt.Filter = "nScnTransaccionContableID = " & IdComprobante
            ObjComprobantedt.Retrieve()
            If ObjComprobantedt.Count = 0 Then
                Exit Sub
            End If
            ObjComprobantedr = ObjComprobantedt.Current

            'Fecha de Transacción:
            If Not ObjComprobantedr.IsFieldNull("dFechaTransaccion") Then
                Me.cdeFechaCD.Value = ObjComprobantedr.dFechaTransaccion
            Else
                Me.cdeFechaCD.Value = Me.cdeFechaCD.ValueIsDbNull
            End If

            'Fecha de Tipo de Cambio:
            If Not ObjComprobantedr.IsFieldNull("dFechaTipoCambio") Then
                Me.cdeFechaTC.Value = ObjComprobantedr.dFechaTipoCambio
            Else
                Me.cdeFechaTC.Value = Me.cdeFechaTC.ValueIsDbNull
            End If

            StrSql = "SELECT LEN(B.sNumeroCuenta) AS LenCta " & _
                     "FROM  ScnTransaccionContableDetalle D INNER JOIN ScnCatalogoContable C ON D.nScnCatalogoContableID = C.nScnCatalogoContableID INNER JOIN SteCuentaBancaria B ON C.nSteCuentaBancariaID = B.nSteCuentaBancariaID INNER JOIN StbValorCatalogo V ON B.nStbTipoCuentaID = V.nStbValorCatalogoID " & _
                     "WHERE   (D.nScnTransaccionContableID = " & IdComprobante & ") AND (V.sCodigoInterno = '2') AND (D.nDebito = 0)"
            IntLenCtaBanco = XcDatos.ExecuteScalar(StrSql)
            'Código de la Cuenta Bancaria / Código del Cheque:
            If Not ObjComprobantedr.IsFieldNull("sNumeroTransaccion") Then
                Me.txtCodigo.Text = Mid(ObjComprobantedr.sNumeroTransaccion, 1, IntLenCtaBanco)
                Me.txtNoCheque.Text = Mid(ObjComprobantedr.sNumeroTransaccion, IntLenCtaBanco + 1, Len(ObjComprobantedr.sNumeroTransaccion))
            Else
                Me.txtCodigo.Text = ""
                Me.txtNoCheque.Text = ""
            End If

            'Almacena variable con numero inicial del cheque para efectos de generar
            'pista de audotoria en caso de modificacion:
            StrNoCheque = ObjComprobantedr.sNumeroTransaccion

            'Número CUE:
            If Not ObjComprobantedr.IsFieldNull("sNumeroCUE") Then
                Me.txtCUE.Text = ObjComprobantedr.sNumeroCUE
            Else
                Me.txtCUE.Text = ""
            End If

            'Solicitud de Cheque:
            If Not ObjComprobantedr.IsFieldNull("nSccSolicitudChequeID") Then
                CargarSolicitud(ObjComprobantedr.nSccSolicitudChequeID)
                If cboSolicitudCK.ListCount > 0 Then
                    Me.cboSolicitudCK.SelectedIndex = 0
                End If
                XdtSolicitud.SetCurrentByID("nSccSolicitudChequeID", ObjComprobantedr.nSccSolicitudChequeID)
            Else
                Me.cboSolicitudCK.Text = ""
                Me.cboSolicitudCK.SelectedIndex = -1
            End If

            'Fuente de Fondos:
            If Not ObjComprobantedr.IsFieldNull("nScnFuenteFinanciamientoID") Then
                CargarFuenteFondos(ObjComprobantedr.nScnFuenteFinanciamientoID)
                If cboFuente.ListCount > 0 Then
                    Me.cboFuente.SelectedIndex = 0
                End If
                XdtFuenteFondos.SetCurrentByID("nScnFuenteFinanciamientoID", ObjComprobantedr.nScnFuenteFinanciamientoID)
            Else
                Me.cboFuente.Text = ""
                Me.cboFuente.SelectedIndex = -1
            End If

            'Beneficiario: ID de Persona Natural, Jurídica o Empleado:
            If Not ObjComprobantedr.IsFieldNull("nStbPersonaBeneficiariaID") Then
                CargarBeneficiario(IdTipoSolicitud, ObjComprobantedr.nStbPersonaBeneficiariaID)
                If XdtBeneficiario.Count > 0 Then
                    Me.cboBeneficiario.SelectedIndex = 0
                End If
                XdtBeneficiario.SetCurrentByID("nBeneficiarioID", ObjComprobantedr.nStbPersonaBeneficiariaID)
                'ID de Solicitud de Desembolso:
            Else
                IdSolicitudD = XcDatos.ExecuteScalar("SELECT nSccSolicitudDesembolsoCreditoID AS SolicitudID FROM SccSolicitudCheque WHERE  (nSccSolicitudChequeID = " & ObjComprobantedr.nSccSolicitudChequeID & ")")
                CargarBeneficiario(IdTipoSolicitud, IdSolicitudD)
                If XdtBeneficiario.Count > 0 Then
                    Me.cboBeneficiario.SelectedIndex = 0
                End If
                XdtBeneficiario.SetCurrentByID("nBeneficiarioID", IdSolicitudD)

            End If

            'Descripción de la Transacción del Pago:
            If Not ObjComprobantedr.IsFieldNull("sDescripcion") Then
                Me.txtConcepto.Text = ObjComprobantedr.sDescripcion
            Else
                Me.txtConcepto.Text = ""
            End If

            'Observaciones:
            If Not ObjComprobantedr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjComprobantedr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos:
            Me.txtConcepto.MaxLength = ObjComprobantedr.GetColumnLenght("sDescripcion")
            Me.txtObservaciones.MaxLength = ObjComprobantedr.GetColumnLenght("sObservaciones")
            Me.txtCUE.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCUE")
            Me.txtNoCheque.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroTransaccion") - Len(txtCodigo.Text)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarComprobanteCheque()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            ValidaDatosEntrada = True
            Me.errComprobante.Clear()
            Dim strSQL As String

            'Fecha de Transacción:
            If Me.cdeFechaCD.ValueIsDbNull Then
                MsgBox("La Fecha de Transacción NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE quedar vacía.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Imposible si el periodo de la fecha de transacción esta Cerrado
            If PeriodoAbiertoDadaFecha(Me.cdeFechaCD.Value) = False Then
                MsgBox("El Período Contable correspondiente a la Fecha" & Chr(13) & "de Transacción se encuentra Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "Período Contable Cerrado.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de T.C.:
            If Me.cdeFechaTC.ValueIsDbNull Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE NO DEBE quedar vacía.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Transacción no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Transacción no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Transacción < Fecha TC: 
            If (DateDiff("d", cdeFechaCD.Value, cdeFechaTC.Value) < 0) Then
                MsgBox("La Fecha de Transacción NO DEBE ser mayor a la de Tipo de Cambio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser mayor a la de Tipo de Cambio.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Debe existir un Tipo de Cambio para Fecha TC:
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaTC, "No existe una Tasa de Cambio para la Fecha.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Número de Comprobante:
            If (Me.txtCodigo.Text = "") Or (Me.txtNoCheque.Text = "") Then
                MsgBox("Debe indicar Número del Comprobante.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.txtNoCheque, "Debe indicar Número del Comprobante.")
                Me.txtNoCheque.Focus()
                Exit Function
            End If

            'Número de Comprobante ACTIVO NO debe ser Duplicado: 
            strSQL = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (ScnTransaccionContable.sNumeroTransaccion = '" & Me.txtCodigo.Text & Me.txtNoCheque.Text & "') AND (ScnTransaccionContable.nScnTransaccionContableID <> " & IdScnComprobante & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya existe Comprobante Activo con este Número de Cheque.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.txtNoCheque, "Existe comprobante con este Número de Cheque.")
                Me.txtNoCheque.Focus()
                Exit Function
            End If

            'Solicitud de Cheque:
            If Me.cboSolicitudCK.SelectedIndex = -1 Then
                MsgBox("Debe indicar Solicicitud de Cheque Autorizada.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cboSolicitudCK, "Debe indicar Solicitud de Cheque Autorizada.")
                Me.cboSolicitudCK.Focus()
                Exit Function
            End If

            'Fuente de Financiamiento:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuente.Focus()
                Exit Function
            End If

            'Beneficiario:
            If Me.cboBeneficiario.SelectedIndex = -1 Then
                MsgBox("Debe indicar Beneficiario del Cheque.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cboBeneficiario, "Debe indicar Beneficiario del Cheque.")
                Me.cboBeneficiario.Focus()
                Exit Function
            End If

            'Descripción de la Transacción: 
            If Me.txtConcepto.Text = "" Then
                MsgBox("Debe indicar Descripción del Comprobante.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.txtConcepto, "Debe indicar Descripción del Comprobante.")
                Me.txtConcepto.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       SalvarComprobanteCheque
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Encabezado del Comprobante de Diario.
    '-------------------------------------------------------------------------
    Private Sub SalvarComprobanteCheque()
        Dim ObjTmpComprobante As New BOSistema.Win.XDataSet
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim strSQL As String

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjComprobantedr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjComprobantedr.dFechaCreacion = FechaServer()
                'Id Estado de la Transacción En Proceso:
                strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = '1') AND (b.sNombre = 'EstadoTransaccionContable')"
                ObjComprobantedr.nStbEstadoTransaccionID = XcDatos.ExecuteScalar(strSQL)
                'Id Tipo de Comprobante (CE):
                strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = 'CE') AND (b.sNombre = 'TipoDocumentoContable')"
                ObjComprobantedr.nStbTipoDocContableID = XcDatos.ExecuteScalar(strSQL)
                '-- Delegación de la Transacción:
                'No se ubica en el Update ya que podria estar modificando datos
                'un usuario de otra Delegación si esta tiene Acceso Total para
                'Edición con lo que se alteraría la Delegación del Cheque.
                ObjComprobantedr.nStbDelegacionProgramaID = InfoSistema.IDDelegacion
            Else
                ObjComprobantedr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjComprobantedr.dFechaModificacion = FechaServer()
            End If

            'Fuente:
            ObjComprobantedr.nScnFuenteFinanciamientoID = cboFuente.Columns("nScnFuenteFinanciamientoID").Value
            'Solicitud de Cheque:
            ObjComprobantedr.nSccSolicitudChequeID = cboSolicitudCK.Columns("nSccSolicitudChequeID").Value
            'Beneficiario/Proveedor:
            If IdSccTipoSolicitud = 1 Then 'Cheque a Socias:
                ObjComprobantedr.SetFieldNull("nStbPersonaBeneficiariaID")
            Else
                If Me.cboBeneficiario.SelectedIndex <> -1 Then
                    ObjComprobantedr.nStbPersonaBeneficiariaID = cboBeneficiario.Columns("nBeneficiarioID").Value
                Else
                    ObjComprobantedr.SetFieldNull("nStbPersonaBeneficiariaID")
                End If
            End If
            
            'Fecha de Transacción:
            ObjComprobantedr.dFechaTransaccion = cdeFechaCD.Value
            'Fecha de Tipo de Cambio:
            ObjComprobantedr.dFechaTipoCambio = cdeFechaTC.Value
            'Descripción de la Transacción:
            ObjComprobantedr.sDescripcion = LTrim(RTrim(Me.txtConcepto.Text))
            'Observaciones:
            If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                ObjComprobantedr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
            Else
                ObjComprobantedr.SetFieldNull("sObservaciones")
            End If
            'Número CUE:
            If Trim(RTrim(Me.txtCUE.Text)).ToString.Length <> 0 Then
                ObjComprobantedr.sNumeroCUE = Trim(RTrim(Me.txtCUE.Text))
            Else
                ObjComprobantedr.SetFieldNull("sNumeroCUE")
            End If

            'Asignación del Código (Número de Comprobante):
            ObjComprobantedr.sNumeroTransaccion = Me.txtCodigo.Text & Me.txtNoCheque.Text

            ObjComprobantedr.Update()
            'Asignar el Id a la variable publica del formulario
            IdScnComprobante = ObjComprobantedr.nScnTransaccionContableID
            '--------------------------------

            'Si es Cambio de Chequera Actualizar Auditoria:
            If ModoForm = "UPDCk" Then
                If (StrNoCheque) <> (Me.txtCodigo.Text & Me.txtNoCheque.Text) Then
                    Call GuardarAuditoria(4, 24, "Modificación de Número de Cheque de " & StrNoCheque & " a " & Me.txtCodigo.Text & Me.txtNoCheque.Text & ".")
                    Dim Sql As String

                    Sql = " update SccSolicitudCheque" & _
                         " set nChequeProcesadoImpresion = NULL, nChequeImpreso = 0 , nNumeroCheque=  " & Me.txtNoCheque.Text & _
                         " where nSccSolicitudChequeID = " & cboSolicitudCK.Columns("nSccSolicitudChequeID").Value

                    XcDatos.ExecuteNonQuery(Sql)
                End If
            End If

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 24, "Modificación de Comprobante de Cheque ID:" & IdScnComprobante & ".")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpComprobante.Close()
            ObjTmpComprobante = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
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
                            SalvarComprobanteCheque()
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
    ' Fecha:                23/11/2007
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

            'Configurar el combo:
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
    ' Fecha:                23/11/2007
    ' Procedure Name:       CargarSolicitud
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Solicitudes de Cheques.
    '-------------------------------------------------------------------------
    Private Sub CargarSolicitud(ByVal intSolicitudID As Integer)
        Try
            Dim Strsql As String = ""

            If intSolicitudID = 0 Then
                Strsql = " SELECT SCK.nSccSolicitudChequeID, SCK.nCodigo, SCK.dFechaSolicitudCheque " & _
                         " FROM  SccSolicitudCheque AS SCK INNER JOIN StbValorCatalogo ON SCK.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE  (SCK.nSccSolicitudChequeID = " & intSolicitudID & ")"
                '" WHERE (StbValorCatalogo.sCodigoInterno = '4') OR  (StbValorCatalogo.sCodigoInterno = '6') " & _
                '" Order by SCK.nCodigo "
            Else
                Strsql = " SELECT SCK.nSccSolicitudChequeID, SCK.nCodigo, SCK.dFechaSolicitudCheque " & _
                         " FROM  SccSolicitudCheque AS SCK INNER JOIN StbValorCatalogo ON SCK.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE  (SCK.nSccSolicitudChequeID = " & intSolicitudID & ")"
                '" Where ((StbValorCatalogo.sCodigoInterno = '4') OR  (StbValorCatalogo.sCodigoInterno = '6')) Or (SCK.nSccSolicitudChequeID = " & intSolicitudID & ") " & _
                '" Order by SCK.nCodigo "
            End If

            XdtSolicitud.ExecuteSql(Strsql)
            Me.cboSolicitudCK.DataSource = XdtSolicitud.Source

            Me.cboSolicitudCK.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.cboSolicitudCK.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboSolicitudCK.Splits(0).DisplayColumns("dFechaSolicitudCheque").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboSolicitudCK.Splits(0).DisplayColumns("nCodigo").Width = 47
            Me.cboSolicitudCK.Splits(0).DisplayColumns("dFechaSolicitudCheque").Width = 100

            Me.cboSolicitudCK.Columns("nCodigo").Caption = "Código"
            Me.cboSolicitudCK.Columns("dFechaSolicitudCheque").Caption = "Fecha Solicitud"

            Me.cboSolicitudCK.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboSolicitudCK.Splits(0).DisplayColumns("dFechaSolicitudCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       CargarBeneficiario
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Beneficiarios del Cheque de acuerdo con Tipo de
    '                       Solicitud de Cheque:
    '                           1. CK a Socias: Beneficiario = Socia de la SDC.
    '                           2. En caso contrario: Beneficiario = nStbPersonaID (Natural o Empleado).
    '-------------------------------------------------------------------------
    Private Sub CargarBeneficiario(ByVal intTipoSolicitudID As Integer, ByVal intBeneficiarioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBeneficiario.ClearFields()

            If intTipoSolicitudID = 1 Then 'Cheque a Socias:
                If intBeneficiarioID = 0 Then
                    Strsql = " SELECT SCK.nSccSolicitudDesembolsoCreditoID AS nBeneficiarioID, SOCIA.sNombre1 + ' ' + SOCIA.sNombre2 + ' ' + SOCIA.sApellido1 + ' ' + SOCIA.sApellido2 AS sNombre " & _
                             " FROM  SccSolicitudCheque AS SCK INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN SclFichaNotificacionDetalle AS DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN SclFichaSocia AS FICHA ON DFNC.nSclFichaSociaID = FICHA.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FICHA.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS SOCIA ON GS.nSclSociaID = SOCIA.nSclSociaID INNER JOIN  StbValorCatalogo ON SCK.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                             " WHERE (SCK.nSccSolicitudDesembolsoCreditoID = " & intBeneficiarioID & ") "
                    '" WHERE (StbValorCatalogo.sCodigoInterno = '4' OR StbValorCatalogo.sCodigoInterno = '6') " & _
                    '" Order by sNombre "
                Else
                    Strsql = " SELECT SCK.nSccSolicitudDesembolsoCreditoID AS nBeneficiarioID, SOCIA.sNombre1 + ' ' + SOCIA.sNombre2 + ' ' + SOCIA.sApellido1 + ' ' + SOCIA.sApellido2 AS sNombre " & _
                             " FROM  SccSolicitudCheque AS SCK INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN SclFichaNotificacionDetalle AS DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN SclFichaSocia AS FICHA ON DFNC.nSclFichaSociaID = FICHA.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FICHA.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS SOCIA ON GS.nSclSociaID = SOCIA.nSclSociaID INNER JOIN  StbValorCatalogo ON SCK.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                             " WHERE (SCK.nSccSolicitudDesembolsoCreditoID = " & intBeneficiarioID & ") "
                    '" WHERE ((StbValorCatalogo.sCodigoInterno = '4' OR StbValorCatalogo.sCodigoInterno = '6')) Or (SCK.nSccSolicitudDesembolsoCreditoID = " & intBeneficiarioID & ") " & _
                    '" Order by sNombre "
                End If
            Else
                If intBeneficiarioID = 0 Then
                    Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                             " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                             " WHERE (StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno <> 'J') " & _
                             " Order by sNombre "
                Else
                    Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                             " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                             " WHERE (StbPersona.nStbPersonaID = " & intBeneficiarioID & ") OR ((StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno <> 'J'))  " & _
                             " Order by sNombre "
                End If
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

    'En caso que ocurra otro Tipo de Error
    Private Sub cboFuente_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFuente.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboBeneficiario_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboBeneficiario.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboSolicitudCK_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboSolicitudCK.Error
        Control_Error(e.Exception)
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

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCD.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaTC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaTC.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboBeneficiario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBeneficiario.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtCUE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCUE.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboSolicitudCK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSolicitudCK.TextChanged
        vbModifico = True
    End Sub

    'Sólo se permiten números:
    Private Sub txtNoCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoCheque.KeyPress
        Try
            If Numeros(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNoCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoCheque.TextChanged
        vbModifico = True
    End Sub
End Class