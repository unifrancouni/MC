' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                21/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditReciboIngresoFondos.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       generales de Recibos de Ingreso de Fondos (RC).
'-------------------------------------------------------------------------
Public Class frmScnEditReciboIngresoFondos

    '-- Declaracion de Variables: 
    Dim ModoForm As String 'ADD/MOD
    Dim IdScnComprobante As Long
    Dim IntHabilitar As Integer
    Dim IntCodificacion As Integer

    '-- Clases para procesar la informacion de los combos:
    Dim XdtFuenteFondos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtBeneficiario As BOSistema.Win.XDataSet
    Dim XdtBanco As BOSistema.Win.XDataSet.xDataTable

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
    ' Fecha:                21/11/2007
    ' Procedure Name:       frmScnEditReciboIngresoFondos_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditReciboIngresoFondos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

                XdtBanco.Close()
                XdtBanco = Nothing

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
    ' Fecha:                21/11/2007
    ' Procedure Name:       frmScnEditReciboIngresoFondos_Load
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
            CargarBeneficiario(0, "RecibidoDe")
            CargarBeneficiario(0, "PorCuentaDe")
            CargarBanco(0)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm = "UPD" Then
                CargarRecibo()
                InhabilitarControles()
            End If

            Me.cdeFechaCD.Select()
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
    ' Fecha:                21/11/2007
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
                '-- Si existe Codificación (detalles de cuentas):
                '1. Bloquear Fuente Financiamiento pues los detalles de Cuentas corresponden a esta:
                '2. Bloquear Fecha de Transacción pues si cambio mes/año debo revertir y remayorizar.
                '3. Bloquear Fecha de Tipo de Cambio pues se deben Recalcular los montos en US$ de los Detalles.
                If IntCodifica > 0 Then
                    Me.cboFuente.Enabled = False
                    Me.cdeFechaCD.Enabled = False
                    Me.cdeFechaTC.Enabled = False
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Recibo de Ingreso de Fondos"
            Else
                Me.Text = "Modificar Recibo de Ingreso de Fondos"
            End If

            XdtFuenteFondos = New BOSistema.Win.XDataSet.xDataTable
            XdtBeneficiario = New BOSistema.Win.XDataSet
            XdtBanco = New BOSistema.Win.XDataSet.xDataTable

            ObjComprobantedt = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableDataTable
            ObjComprobantedr = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableRow

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboRecibidoDe.ClearFields()
            Me.cboPorCuentaDe.ClearFields()
            Me.cboBanco.ClearFields()

            If ModoForm = "ADD" Then
                ObjComprobantedr = ObjComprobantedt.NewRow
                'Inicializar los Length de los campos String:
                Me.txtConcepto.MaxLength = ObjComprobantedr.GetColumnLenght("sDescripcion")
                Me.txtObservaciones.MaxLength = ObjComprobantedr.GetColumnLenght("sObservaciones")
                Me.txtCUE.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCUE")
                Me.txtNoCheque.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCKRecibo")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       CargarRecibo
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Recibo de Ingreso en caso de estar en el Modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibo()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            '-- Buscar el Comprobante correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjComprobantedt.Filter = "nScnTransaccionContableID = " & IdComprobante
            ObjComprobantedt.Retrieve()
            If ObjComprobantedt.Count = 0 Then
                Exit Sub
            End If
            ObjComprobantedr = ObjComprobantedt.Current

            'Código del Comprobante:
            If Not ObjComprobantedr.IsFieldNull("sNumeroTransaccion") Then
                Me.txtCodigo.Text = ObjComprobantedr.sNumeroTransaccion
            Else
                Me.txtCodigo.Text = ""
            End If

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

            'Recibimos De:
            If Not ObjComprobantedr.IsFieldNull("nStbPersonaBeneficiariaID") Then
                CargarBeneficiario(ObjComprobantedr.nStbPersonaBeneficiariaID, "RecibidoDe")
                If XdtBeneficiario("RecibidoDe").Count > 0 Then
                    Me.cboRecibidoDe.SelectedIndex = 0
                End If
                XdtBeneficiario("RecibidoDe").SetCurrentByID("nBeneficiarioID", ObjComprobantedr.nStbPersonaBeneficiariaID)
            Else
                Me.cboRecibidoDe.Text = ""
                Me.cboRecibidoDe.SelectedIndex = -1
            End If

            'Por Cuenta De:
            If Not ObjComprobantedr.IsFieldNull("nStbPersonaReciboID") Then
                CargarBeneficiario(ObjComprobantedr.nStbPersonaReciboID, "PorCuentaDe")
                If XdtBeneficiario("PorCuentaDe").Count > 0 Then
                    Me.cboPorCuentaDe.SelectedIndex = 0
                End If
                XdtBeneficiario("PorCuentaDe").SetCurrentByID("nBeneficiarioID", ObjComprobantedr.nStbPersonaReciboID)
            Else
                Me.cboPorCuentaDe.Text = ""
                Me.cboPorCuentaDe.SelectedIndex = -1
            End If

            'Concepto del Ingreso:
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

            'Número CUE:
            If Not ObjComprobantedr.IsFieldNull("sNumeroCUE") Then
                Me.txtCUE.Text = ObjComprobantedr.sNumeroCUE
            Else
                Me.txtCUE.Text = ""
            End If

            'Recibido Con:
            If Not ObjComprobantedr.IsFieldNull("nStbTipoIngresoReciboID") Then
                If XcDatos.ExecuteScalar("SELECT sCodigoInterno FROM  StbValorCatalogo WHERE (nStbValorCatalogoID = " & ObjComprobantedr.nStbTipoIngresoReciboID & ")") = "EF" Then
                    radEfectivo.Checked = True
                ElseIf XcDatos.ExecuteScalar("SELECT sCodigoInterno FROM  StbValorCatalogo WHERE (nStbValorCatalogoID = " & ObjComprobantedr.nStbTipoIngresoReciboID & ")") = "CK" Then
                    RadCheque.Checked = True
                Else '-- TB.
                    RadTB.Checked = True
                End If
            End If

            'Número Cheque:
            If Not ObjComprobantedr.IsFieldNull("sNumeroCKRecibo") Then
                Me.txtNoCheque.Text = ObjComprobantedr.sNumeroCKRecibo
            Else
                Me.txtNoCheque.Text = ""
            End If

            'Nombre del Banco:
            If Not ObjComprobantedr.IsFieldNull("nStbPersonaBancoID") Then
                CargarBanco(ObjComprobantedr.nStbPersonaBancoID)
                If XdtBanco.Count > 0 Then
                    Me.cboBanco.SelectedIndex = 0
                End If
                XdtBanco.SetCurrentByID("nBeneficiarioID", ObjComprobantedr.nStbPersonaBancoID)
            Else
                Me.cboBanco.Text = ""
                Me.cboBanco.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos:
            Me.txtConcepto.MaxLength = ObjComprobantedr.GetColumnLenght("sDescripcion")
            Me.txtObservaciones.MaxLength = ObjComprobantedr.GetColumnLenght("sObservaciones")
            Me.txtCUE.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCUE")
            Me.txtNoCheque.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCKRecibo")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarRecibo()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()
            Dim strSQL As String

            'Fecha de Transacción:
            If Me.cdeFechaCD.ValueIsDbNull Then
                MsgBox("La Fecha de Transacción NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE quedar vacía.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Imposible si el periodo de la fecha de transacción esta Cerrado
            If PeriodoAbiertoDadaFecha(Me.cdeFechaCD.Value) = False Then
                MsgBox("El Período Contable correspondiente a la Fecha" & Chr(13) & "de Transacción se encuentra Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaCD, "Período Contable Cerrado.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de T.C.:
            If Me.cdeFechaTC.ValueIsDbNull Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE NO DEBE quedar vacía.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Transacción < Fecha TC:
            If (DateDiff("d", cdeFechaCD.Value, cdeFechaTC.Value) < 0) Then
                MsgBox("La Fecha de Transacción NO DEBE ser mayor a la de Tipo de Cambio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser mayor a la de Tipo de Cambio.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Debe existir un Tipo de Cambio para Fecha TC:
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaTC.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaTC, "No existe una Tasa de Cambio para la Fecha.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Transacción no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Transacción no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Transacción NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaCD, "La Fecha de Transacción NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fecha de Tipo de Cambio no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Tipo de Cambio NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaTC, "La Fecha de Tipo de Cambio NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaTC.Focus()
                Exit Function
            End If

            'Fuente de Financiamiento:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuente.Focus()
                Exit Function
            End If

            'Recibido De:
            If Me.cboRecibidoDe.SelectedIndex = -1 Then
                MsgBox("Debe indicar de quien se recibe el Ingreso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboRecibidoDe, "Debe indicar de quien se recibe el Ingreso.")
                Me.cboRecibidoDe.Focus()
                Exit Function
            End If

            'Por Cuenta De:
            If Me.cboPorCuentaDe.SelectedIndex = -1 Then
                MsgBox("Debe indicar Por cuenta de quien se recibe el Ingreso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboPorCuentaDe, "Debe indicar Por cuenta de quien se recibe el Ingreso.")
                Me.cboPorCuentaDe.Focus()
                Exit Function
            End If

            'Concepto del Ingreso:
            If Me.txtConcepto.Text = "" Then
                MsgBox("Debe indicar Concepto del Ingreso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtConcepto, "Debe indicar Concepto del Ingreso.")
                Me.txtConcepto.Focus()
                Exit Function
            End If

            '-- Si el Tipo de Ingreso es Con Cheque:
            If RadCheque.Checked Then
                'Debe indicar No. de Cheque:
                If Me.txtNoCheque.Text = "" Then
                    MsgBox("Debe indicar Número del Cheque.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errRecibo.SetError(Me.txtNoCheque, "Debe indicar Número del Cheque.")
                    Me.txtNoCheque.Focus()
                    Exit Function
                End If
                'Debe Indicar Nombre del Banco:
                If Me.cboBanco.SelectedIndex = -1 Then
                    MsgBox("Debe indicar Nombre del Banco.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errRecibo.SetError(Me.cboBanco, "Debe indicar Nombre del Banco.")
                    Me.cboBanco.Focus()
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
    ' Fecha:                21/11/2007
    ' Procedure Name:       SalvarRecibo
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Encabezado del Recibo de Ingreso.
    '-------------------------------------------------------------------------
    Private Sub SalvarRecibo()
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
                'Id Tipo de Comprobante (RC):
                strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = 'RC') AND (b.sNombre = 'TipoDocumentoContable')"
                ObjComprobantedr.nStbTipoDocContableID = XcDatos.ExecuteScalar(strSQL)
                '-- Delegación de la Transacción:
                'No se ubica en el Update ya que podria estar modificando datos
                'un usuario de otra Delegación si esta tiene Acceso Total para
                'Edición con lo que se alteraría la Delegación del Recibo.
                ObjComprobantedr.nStbDelegacionProgramaID = InfoSistema.IDDelegacion
            Else
                ObjComprobantedr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjComprobantedr.dFechaModificacion = FechaServer()
            End If

            'Fuente:
            ObjComprobantedr.nScnFuenteFinanciamientoID = cboFuente.Columns("nScnFuenteFinanciamientoID").Value
            'Recibido De:
            If Me.cboRecibidoDe.SelectedIndex <> -1 Then
                ObjComprobantedr.nStbPersonaBeneficiariaID = cboRecibidoDe.Columns("nBeneficiarioID").Value
            Else
                ObjComprobantedr.SetFieldNull("nStbPersonaBeneficiariaID")
            End If
            'Por Cuenta De:
            If Me.cboPorCuentaDe.SelectedIndex <> -1 Then
                ObjComprobantedr.nStbPersonaReciboID = cboPorCuentaDe.Columns("nBeneficiarioID").Value
            Else
                ObjComprobantedr.SetFieldNull("nStbPersonaReciboID")
            End If
            'Tipo de Ingreso:
            If radEfectivo.Checked = True Then 'Efectivo:
                ObjComprobantedr.nStbTipoIngresoReciboID = XcDatos.ExecuteScalar("SELECT StbValorCatalogo.nStbValorCatalogoID FROM  StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID WHERE (StbCatalogo.sNombre = 'TipoIngresoCaja') AND (StbValorCatalogo.sCodigoInterno = 'EF')")
            ElseIf RadCheque.Checked = True Then 'Cheque:
                ObjComprobantedr.nStbTipoIngresoReciboID = XcDatos.ExecuteScalar("SELECT StbValorCatalogo.nStbValorCatalogoID FROM  StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID WHERE (StbCatalogo.sNombre = 'TipoIngresoCaja') AND (StbValorCatalogo.sCodigoInterno = 'CK')")
            Else 'Traspaso Bancario.
                ObjComprobantedr.nStbTipoIngresoReciboID = XcDatos.ExecuteScalar("SELECT StbValorCatalogo.nStbValorCatalogoID FROM  StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID WHERE (StbCatalogo.sNombre = 'TipoIngresoCaja') AND (StbValorCatalogo.sCodigoInterno = 'TB')")
            End If

            'Si el Ingreso fue con Cheque:
            If RadCheque.Checked = True Then
                'No. de Cheque:
                If Trim(RTrim(Me.txtNoCheque.Text)).ToString.Length <> 0 Then
                    ObjComprobantedr.sNumeroCKRecibo = Trim(RTrim(Me.txtNoCheque.Text))
                Else
                    ObjComprobantedr.SetFieldNull("sNumeroCKRecibo")
                End If
                'Nombre Banco:
                If Me.cboBanco.SelectedIndex <> -1 Then
                    ObjComprobantedr.nStbPersonaBancoID = cboBanco.Columns("nBeneficiarioID").Value
                Else
                    ObjComprobantedr.SetFieldNull("nStbPersonaBancoID")
                End If
            Else
                ObjComprobantedr.SetFieldNull("sNumeroCKRecibo")
                ObjComprobantedr.SetFieldNull("nStbPersonaBancoID")
            End If

            'Fecha de Transacción:
            ObjComprobantedr.dFechaTransaccion = cdeFechaCD.Value
            'Fecha de Tipo de Cambio:
            ObjComprobantedr.dFechaTipoCambio = cdeFechaTC.Value
            'En Concepto De:
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

            'Asignación del Código siguiente:
            If ModoForm = "ADD" Then
                'strSQL = " SELECT max(sNumeroTransaccion) as maxCodigo FROM ScnTransaccionContable " & _
                '         "WHERE nStbTipoDocContableID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = 'RC' And b.sNombre = 'TipoDocumentoContable')"
                strSQL = " SELECT COUNT(maxCodigo) AS maxCodigo " & _
                         " FROM (SELECT sNumeroTransaccion AS maxCodigo FROM ScnTransaccionContable " & _
                         " WHERE (nStbTipoDocContableID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE (a.sCodigoInterno = 'RC') AND (b.sNombre = 'TipoDocumentoContable')))) a"
                If ObjTmpComprobante.ExistTable("Recibo") Then
                    ObjTmpComprobante("Recibo").ExecuteSql(strSQL)
                Else
                    ObjTmpComprobante.NewTable(strSQL, "Recibo")
                    ObjTmpComprobante("Recibo").Retrieve()
                End If

                If Not ObjTmpComprobante("Recibo").ValueField("maxCodigo") Is DBNull.Value Then
                    Me.txtCodigo.Text = Format(ObjTmpComprobante("Recibo").ValueField("maxCodigo") + 1) ', "00"
                Else
                    Me.txtCodigo.Text = "1"
                End If
            End If
            'Codigo Recibo:
            ObjComprobantedr.sNumeroTransaccion = Me.txtCodigo.Text

            ObjComprobantedr.Update()
            'Asignar el Id a la variable publica del formulario
            IdScnComprobante = ObjComprobantedr.nScnTransaccionContableID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(4, 24, "Modificación de Recibo de Ingreso de Fondos ID:" & Me.IdScnComprobante & ".")
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
    ' Fecha:                21/11/2007
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
                            SalvarRecibo()
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
    ' Fecha:                21/11/2007
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
    ' Fecha:                21/11/2007
    ' Procedure Name:       CargarBanco
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Entidades Pagadoras.
    '-------------------------------------------------------------------------
    Private Sub CargarBanco(ByVal intBancoID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBanco.ClearFields()

            If intBancoID = 0 Then
                Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                         " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE (StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno = 'J') AND (StbPersona.nOtorgaCredito = 1) " & _
                         " Order by sNombre"
            Else
                Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                         " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE (StbPersona.nStbPersonaID = " & intBancoID & ") OR ((StbPersona.nPersonaActiva = 1) AND (StbValorCatalogo.sCodigoInterno = 'J') AND (StbPersona.nOtorgaCredito = 1))  " & _
                         " Order by sNombre"
            End If

            XdtBanco.ExecuteSql(Strsql)
            Me.cboBanco.DataSource = XdtBanco.Source
            Me.cboBanco.Rebind()

            'Configurar el combo:
            Me.cboBanco.Splits(0).DisplayColumns("nBeneficiarioID").Visible = False
            Me.cboBanco.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboBanco.Columns("sNombre").Caption = "Entidad Bancaria"
            Me.cboBanco.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       CargarBeneficiario
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Beneficiarios/Proveedores.
    '                       StrNombre = RecibidoDe, PorCuentaDe
    '-------------------------------------------------------------------------
    Private Sub CargarBeneficiario(ByVal intBeneficiarioID As Integer, ByVal StrNombre As String)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            If StrNombre = "RecibidoDe" Then
                Me.cboRecibidoDe.ClearFields()
            Else
                Me.cboPorCuentaDe.ClearFields()
            End If

            If intBeneficiarioID = 0 Then
                Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                         " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE (StbPersona.nPersonaActiva = 1) " & _
                         " Order by sNombre"
            Else
                Strsql = " SELECT StbPersona.nStbPersonaID AS nBeneficiarioID, CASE StbValorCatalogo.sCodigoInterno WHEN 'J' THEN StbPersona.sNombre1 ELSE StbPersona.sNombre1 + ' ' + StbPersona.sNombre2  + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 END AS sNombre " & _
                         " FROM StbPersona INNER JOIN StbValorCatalogo ON StbPersona.nStbTipoPersonaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE (StbPersona.nStbPersonaID = " & intBeneficiarioID & ") OR ((StbPersona.nPersonaActiva = 1) )  " & _
                         " Order by sNombre"
            End If

            If XdtBeneficiario.ExistTable(StrNombre) Then
                XdtBeneficiario(StrNombre).ExecuteSql(Strsql)
            Else
                XdtBeneficiario.NewTable(Strsql, StrNombre)
                XdtBeneficiario(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos
            If StrNombre = "RecibidoDe" Then
                Me.cboRecibidoDe.DataSource = XdtBeneficiario(StrNombre).Source
                Me.cboRecibidoDe.Rebind()
            Else
                Me.cboPorCuentaDe.DataSource = XdtBeneficiario(StrNombre).Source
                Me.cboPorCuentaDe.Rebind()
            End If

            'Confugurar el combo:
            If StrNombre = "RecibidoDe" Then
                Me.cboRecibidoDe.Splits(0).DisplayColumns("nBeneficiarioID").Visible = False
                Me.cboRecibidoDe.Splits(0).DisplayColumns("sNombre").Width = 100
                Me.cboRecibidoDe.Columns("sNombre").Caption = "Recibido De"
                Me.cboRecibidoDe.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                Me.cboPorCuentaDe.Splits(0).DisplayColumns("nBeneficiarioID").Visible = False
                Me.cboPorCuentaDe.Splits(0).DisplayColumns("sNombre").Width = 100
                Me.cboPorCuentaDe.Columns("sNombre").Caption = "Por Cuenta De"
                Me.cboPorCuentaDe.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboFuente_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFuente.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboRecibidoDe_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboRecibidoDe.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboPorCuentaDe_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboPorCuentaDe.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboBanco_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboBanco.Error
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

    Private Sub cboRecibidoDe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecibidoDe.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtCUE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCUE.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboPorCuentaDe_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPorCuentaDe.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNoCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoCheque.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboBanco_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBanco.TextChanged
        vbModifico = True
    End Sub

    Private Sub radEfectivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radEfectivo.CheckedChanged
        vbModifico = True
        If (radEfectivo.Checked = True) Or (RadTB.Checked = True) Then
            Me.txtNoCheque.Text = ""
            Me.cboBanco.Text = ""
            Me.cboBanco.SelectedIndex = -1
            Me.txtNoCheque.Enabled = False
            Me.cboBanco.Enabled = False
        Else
            Me.txtNoCheque.Enabled = True
            Me.cboBanco.Enabled = True
        End If
    End Sub

    Private Sub RadCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCheque.CheckedChanged
        vbModifico = True
        If (radEfectivo.Checked = True) Or (RadTB.Checked = True) Then
            Me.txtNoCheque.Text = ""
            Me.cboBanco.Text = ""
            Me.cboBanco.SelectedIndex = -1
            Me.txtNoCheque.Enabled = False
            Me.cboBanco.Enabled = False
        Else
            Me.txtNoCheque.Enabled = True
            Me.cboBanco.Enabled = True
        End If
    End Sub

    Private Sub RadTB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadTB.CheckedChanged
        vbModifico = True
        If (radEfectivo.Checked = True) Or (RadTB.Checked = True) Then
            Me.txtNoCheque.Text = ""
            Me.cboBanco.Text = ""
            Me.cboBanco.SelectedIndex = -1
            Me.txtNoCheque.Enabled = False
            Me.cboBanco.Enabled = False
        Else
            Me.txtNoCheque.Enabled = True
            Me.cboBanco.Enabled = True
        End If
    End Sub

End Class