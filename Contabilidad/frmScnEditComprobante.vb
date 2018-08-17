' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                20/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditComprobante.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       generales de Comprobantes de Diario del tipo CD:
'                       (CD: Comprobante de Diario).
'-------------------------------------------------------------------------
Public Class frmScnEditComprobante

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdScnComprobante As Long
    Dim IntHabilitar As Integer
    Dim IntCodificacion As Integer
    Dim dFechaCd As Date

    '-- Clases para procesar la informacion de los combos 
    Dim XdtFuenteFondos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtBeneficiario As BOSistema.Win.XDataSet.xDataTable
    Dim XdtMinutaDeposito As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset (conjunto de tablas):
    Dim ObjComprobantedt As BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableDataTable
    Dim ObjComprobantedr As BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableRow

    Dim TipoCD As String

    'Propiedad utilizada para identificar si el formulario responde a 
    'Elborar, Revisar o Autorizar una determinada Solicitud de Cheque:
    'CR: Credito (CR, CA[manual])
    'CD: Comprobantes (CD[manual], CC)
    Public Property sTipoCD() As String
        Get
            sTipoCD = TipoCD
        End Get
        Set(ByVal value As String)
            TipoCD = value
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
    Public Property dFecha() As Date
        Get
            dFecha = dFechaCd
        End Get
        Set(ByVal value As Date)
            dFechaCd = value
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
    ' Fecha:                20/11/2007
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

                XdtMinutaDeposito.Close()
                XdtMinutaDeposito = Nothing

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
    ' Fecha:                20/11/2007
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

            'Si es Comprobante Manual de Control de Crédito (Ajustes Manuales): 
            If TipoCD = "CR" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Comprobantes de Recuperación y Ajustes")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Comprobantes de Diario")
            End If

            InicializarVariables()

            'Cargar Combos:
            CargarFuenteFondos(0)
            CargarBeneficiario(0)
            CargarMinuta(0)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm = "UPD" Then
                CargarComprobanteDiario()
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
    ' Fecha:                20/11/2007
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
            ElseIf IntHabilitar = 1 Then
                '-- Si existe Codificación bloquear Fuente de Financiamiento:
                If IntCodifica > 0 Then
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
            Else 'IntHabilitar = 2. 
                'Comprobante de Recuperación de Crédito:
                'Solo Habilitar Descripción y Observaciones. 
                Me.cboFuente.Enabled = False
                Me.cdeFechaCD.Enabled = False
                Me.cdeFechaTC.Enabled = False
                Me.cboMinuta.Enabled = False
                Me.txtCUE.Enabled = False
                Me.cboBeneficiario.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Comprobante de Diario"
            Else
                Me.Text = "Modificar Comprobante de Diario"
            End If

            XdtFuenteFondos = New BOSistema.Win.XDataSet.xDataTable
            XdtBeneficiario = New BOSistema.Win.XDataSet.xDataTable
            XdtMinutaDeposito = New BOSistema.Win.XDataSet.xDataTable

            ObjComprobantedt = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableDataTable
            ObjComprobantedr = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionContableRow

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboBeneficiario.ClearFields()
            Me.cboMinuta.ClearFields()

            If ModoForm = "ADD" Then
                ObjComprobantedr = ObjComprobantedt.NewRow
                'Inicializar los Length de los campos String:
                Me.txtConcepto.MaxLength = ObjComprobantedr.GetColumnLenght("sDescripcion")
                Me.txtObservaciones.MaxLength = ObjComprobantedr.GetColumnLenght("sObservaciones")
                Me.txtCUE.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCUE")
            End If

            If TipoCD = "CD" Then
                Me.lblFechaD.Visible = False
                Me.cboMinuta.Visible = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       CargarComprobanteDiario
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Comprobante de Diario caso de estar en el Modo
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarComprobanteDiario()
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

            'ID de Persona Natural, Jurídica o Empleado
            If Not ObjComprobantedr.IsFieldNull("nStbPersonaBeneficiariaID") Then
                CargarBeneficiario(ObjComprobantedr.nStbPersonaBeneficiariaID)
                If XdtBeneficiario.Count > 0 Then
                    Me.cboBeneficiario.SelectedIndex = 0
                End If
                XdtBeneficiario.SetCurrentByID("nBeneficiarioID", ObjComprobantedr.nStbPersonaBeneficiariaID)

            Else
                Me.cboBeneficiario.Text = ""
                Me.cboBeneficiario.SelectedIndex = -1
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

            'Número CUE:
            If Not ObjComprobantedr.IsFieldNull("sNumeroCUE") Then
                Me.txtCUE.Text = ObjComprobantedr.sNumeroCUE
            Else
                Me.txtCUE.Text = ""
            End If

            'Número Depósito:
            If Not ObjComprobantedr.IsFieldNull("nSteMinutaDepositoID") Then
                CargarMinuta(ObjComprobantedr.nSteMinutaDepositoID)
                If cboMinuta.ListCount > 0 Then
                    Me.cboMinuta.SelectedIndex = 0
                End If
                XdtMinutaDeposito.SetCurrentByID("nSteMinutaDepositoID", ObjComprobantedr.nSteMinutaDepositoID)
            Else
                Me.cboMinuta.Text = ""
                Me.cboMinuta.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos:
            Me.txtConcepto.MaxLength = ObjComprobantedr.GetColumnLenght("sDescripcion")
            Me.txtObservaciones.MaxLength = ObjComprobantedr.GetColumnLenght("sObservaciones")
            Me.txtCUE.MaxLength = ObjComprobantedr.GetColumnLenght("sNumeroCUE")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarComprobantedeDiario()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
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
            If (DateDiff("d", Format(Me.cdeFechaCD.Value, "yyyy-MM-dd"), Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")) < 0) Then
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

            'Fuente de Financiamiento:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuente.Focus()
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

            'Imposible si el periodo de la fecha de transacción esta Cerrado:
            If PeriodoAbiertoDadaFecha(Me.cdeFechaCD.Value) = False Then
                MsgBox("El Período Contable correspondiente a la Fecha" & Chr(13) & "de Transacción se encuentra Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errComprobante.SetError(Me.cdeFechaCD, "Período Contable Cerrado.")
                Me.cdeFechaCD.Focus()
                Exit Function
            End If

            'Si es Comprobante Manual de Control de Crédito (Ajustes Manuales): 
            If (TipoCD = "CR") Then
                '1. Debe indicar Minuta de Depósito:
                If Me.cboMinuta.SelectedIndex = -1 Then
                    MsgBox("Debe indicar Minuta de Depósito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errComprobante.SetError(Me.cboMinuta, "Debe indicar Minuta de Depósito.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '2. Fecha de Deposito debe Coincidir con Fecha de la Transacción:
                If cboMinuta.Columns("dFechaDeposito").Value <> Format(Me.cdeFechaCD.Value, "yyyy-MM-dd") Then
                    MsgBox("Fecha del Depósito (" & cboMinuta.Columns("dFechaDeposito").Value & ") NO coincide con la" & Chr(13) & "Fecha de la Transacción (" & Me.cdeFechaCD.Value & ").", MsgBoxStyle.Critical, NombreSistema)
                    Me.errComprobante.SetError(Me.cboMinuta, "Fecha del Depósito NO coincide con la nueva Fecha de la Transacción.")
                    Me.cboMinuta.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
                '3. Número de Minuta NO debe estar contenido en otro Comprobante activo:
                strSQL = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                         "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN  StbValorCatalogo AS StbValorCatalogo_1 ON  ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                         "WHERE (ScnTransaccionContable.nScnTransaccionContableID <> " & IdComprobante & ") AND (StbValorCatalogo.sCodigoInterno = 'CA') AND (ScnTransaccionContable.nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") AND (StbValorCatalogo_1.sCodigoInterno <> '3')"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("La Minuta esta asociada a otro comprobante de ajuste activo.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errComprobante.SetError(Me.cboMinuta, "La Minuta ya ha sido asociada a otro comprobante de ajuste.")
                    Me.cboMinuta.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If


                '2. Depósito debe existir en algún Comprobante de Recuperación ACTIVO:
                'strSQL = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                '         "FROM  ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN StbValorCatalogo AS StbValorCatalogo_1 ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                '         "WHERE (StbValorCatalogo.sCodigoInterno = 'CR') AND (ScnTransaccionContable.nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") AND  (StbValorCatalogo_1.sCodigoInterno = '2')"
                'If RegistrosAsociados(strSQL) = False Then
                '    MsgBox("No existe Comprobante de Cierre de Cartera ACTIVO" & Chr(13) & "con esta Minuta de Depósito.", MsgBoxStyle.Critical, NombreSistema)
                '    ValidaDatosEntrada = False
                '    Me.errComprobante.SetError(Me.cboMinuta, "No existe Comprobante de Cierre de Cartera con esta Minuta de Depósito.")
                '    Me.cboMinuta.Focus()
                '    Exit Function
                'End If
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       SalvarComprobantedeDiario
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Encabezado del Comprobante de Diario.
    '-------------------------------------------------------------------------
    'Private Sub SalvarComprobantedeDiarioCOPIA()
    '    Dim ObjTmpComprobante As New BOSistema.Win.XDataSet
    '    Dim XcDatos As New BOSistema.Win.XComando

    '    Try
    '        Dim strSQL As String
    '        Dim StrNoAnterior As String

    '        'Actualiza usuario y fecha de creación:
    '        If ModoForm = "ADD" Then
    '            ObjComprobantedr.nUsuarioCreacionID = InfoSistema.IDCuenta
    '            ObjComprobantedr.dFechaCreacion = FechaServer()
    '            'Id Estado de la Transacción En Proceso:
    '            strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = '1') AND (b.sNombre = 'EstadoTransaccionContable')"
    '            ObjComprobantedr.nStbEstadoTransaccionID = XcDatos.ExecuteScalar(strSQL)
    '            'Id Tipo de Comprobante (CD):
    '            If TipoCD = "CD" Then
    '                strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = 'CD') AND (b.sNombre = 'TipoDocumentoContable')"
    '            Else 'Tipo Comprobante de Ajuste Manual: CA
    '                strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = 'CA') AND (b.sNombre = 'TipoDocumentoContable')"
    '            End If
    '            ObjComprobantedr.nStbTipoDocContableID = XcDatos.ExecuteScalar(strSQL)
    '            '-- Delegación de la Transacción:
    '            'No se ubica en el Update ya que podria estar modificando datos
    '            'un usuario de otra Delegación si esta tiene Acceso Total para
    '            'Edición con lo que se alteraría la Delegación del Comprobante.
    '            ObjComprobantedr.nStbDelegacionProgramaID = InfoSistema.IDDelegacion
    '        Else
    '            ObjComprobantedr.nUsuarioModificacionID = InfoSistema.IDCuenta
    '            ObjComprobantedr.dFechaModificacion = FechaServer()
    '        End If

    '        'Datos del Depósito:
    '        If TipoCD = "CD" Then
    '            ObjComprobantedr.SetFieldNull("nSteMinutaDepositoID")
    '        Else 'Comprobante de Ajuste (CA) almacena Minuta de Depósito::
    '            ObjComprobantedr.nSteMinutaDepositoID = cboMinuta.Columns("nSteMinutaDepositoID").Value
    '        End If

    '        'Fuente:
    '        ObjComprobantedr.nScnFuenteFinanciamientoID = cboFuente.Columns("nScnFuenteFinanciamientoID").Value

    '        'Beneficiario/Proveedor:
    '        If Me.cboBeneficiario.SelectedIndex <> -1 Then
    '            ObjComprobantedr.nStbPersonaBeneficiariaID = cboBeneficiario.Columns("nBeneficiarioID").Value
    '        Else
    '            ObjComprobantedr.SetFieldNull("nStbPersonaBeneficiariaID")
    '        End If

    '        'Fecha de Transacción:
    '        ObjComprobantedr.dFechaTransaccion = Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")

    '        'Fecha de Tipo de Cambio:
    '        ObjComprobantedr.dFechaTipoCambio = Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")

    '        'Descripción de la Transacción: 
    '        ObjComprobantedr.sDescripcion = LTrim(RTrim(Me.txtConcepto.Text))

    '        'Observaciones:
    '        If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
    '            ObjComprobantedr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
    '        Else
    '            ObjComprobantedr.SetFieldNull("sObservaciones")
    '        End If

    '        'Número CUE:
    '        If Trim(RTrim(Me.txtCUE.Text)).ToString.Length <> 0 Then
    '            ObjComprobantedr.sNumeroCUE = Trim(RTrim(Me.txtCUE.Text))
    '        Else
    '            ObjComprobantedr.SetFieldNull("sNumeroCUE")
    '        End If

    '        StrNoAnterior = Me.txtCodigo.Text
    '        'Asignación del Código siguiente:
    '        '-- 1. En caso de Adición.
    '        '-- 2. En caso de cambio de Fecha de la Transacción.
    '        'strSQL = "SELECT * FROM ScnTransaccionContable a " & _
    '        '         "WHERE (a.dFechaTransaccion = CONVERT(DATETIME, '" & Format(Me.cdeFechaCD.Value, "yyyy-MM-dd") & "', 102)) " & _
    '        '         "AND a.nStbTipoDocContableID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('CR','CD','CC','CA') And b.sNombre = 'TipoDocumentoContable')"
    '        strSQL = " SELECT ISNULL(MAX(CONVERT(int, SUBSTRING(sNumeroTransaccion, 13, LEN(sNumeroTransaccion)))), 0) AS maxCodigo " & _
    '                 " FROM ScnTransaccionContable AS a " & _
    '                 " WHERE (CONVERT(varchar(10), dFechaTransaccion, 120) = CONVERT(varchar(10), '" & Format(Me.cdeFechaCD.Value, "yyyy-MM-dd") & "', 120)) " & _
    '                 " AND (nStbTipoDocContableID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
    '                 " WHERE (a.sCodigoInterno IN ('CR', 'CD', 'CC', 'CA')) AND (b.sNombre = 'TipoDocumentoContable')))"
    '        If ObjTmpComprobante.ExistTable("CD") Then
    '            ObjTmpComprobante("CD").ExecuteSql(strSQL)
    '        Else
    '            ObjTmpComprobante.NewTable(strSQL, "CD")
    '            ObjTmpComprobante("CD").Retrieve()
    '        End If
    '        'Si es una Adición:
    '        If (ModoForm = "ADD") Then
    '            Me.txtCodigo.Text = "CD-" & Mid((cdeFechaCD.Value), 1, 2) & Mid((cdeFechaCD.Value), 4, 2) & Year(cdeFechaCD.Value) & "-" & (ObjTmpComprobante("CD").ValueField("maxCodigo") + 1)
    '        Else '-- Si es una Actualización y cambio la Fecha del CD:
    '            If (DateDiff("d", Me.dFecha, Me.cdeFechaCD.Value) <> 0) Then
    '                Me.txtCodigo.Text = "CD-" & Mid((cdeFechaCD.Value), 1, 2) & Mid((cdeFechaCD.Value), 4, 2) & Year(cdeFechaCD.Value) & "-" & (ObjTmpComprobante("CD").ValueField("maxCodigo") + 1)
    '            End If
    '        End If

    '        'Codigo Comprobante:
    '        ObjComprobantedr.sNumeroTransaccion = Me.txtCodigo.Text

    '        ObjComprobantedr.Update()
    '        'Asignar el Id a la variable publica del formulario
    '        IdScnComprobante = ObjComprobantedr.nScnTransaccionContableID
    '        '--------------------------------

    '        'Si el salvado se realizó de forma satisfactoria
    '        'enviar mensaje informando y cerrar el formulario.
    '        If ModoForm = "ADD" Then
    '            MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
    '        Else
    '            MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
    '        End If

    '        'Si cambio la Fecha generar Auditoría:
    '        If (ModoForm <> "ADD") Then
    '            If (DateDiff("d", Me.dFecha, Me.cdeFechaCD.Value) <> 0) Then
    '                Call GuardarAuditoria(4, 24, "Cambio de fecha de Comprobante de Diario No.: " & StrNoAnterior & " de " & Me.dFecha & " a " & Me.cdeFechaCD.Value & ". Asignándosele el nuevo Número: " & Me.txtCodigo.Text)
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjTmpComprobante.Close()
    '        ObjTmpComprobante = Nothing

    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/06/2009
    ' Procedure Name:       SalvarComprobantedeDiario
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Encabezado del Comprobante de Diario.
    '-------------------------------------------------------------------------
    Private Sub SalvarComprobantedeDiario()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            Dim intBeneficiarioID As Integer
            Dim intMinutaID As Integer
            Dim intTipoID As Integer

            Dim StrFechaCD As String
            Dim StrFechaTC As String
            Dim intCambioFechaCD As Integer
            Dim StrNoAnterior As String

            StrFechaCD = Format(Me.cdeFechaCD.Value, "yyyy-MM-dd")
            StrFechaTC = Format(Me.cdeFechaTC.Value, "yyyy-MM-dd")
            StrNoAnterior = Me.txtCodigo.Text

            'Id Tipo de Comprobante (CD):
            If TipoCD = "CD" Then
                strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = 'CD') AND (b.sNombre = 'TipoDocumentoContable')"
            Else 'Tipo Comprobante de Ajuste Manual: CA
                strSQL = "SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE  (a.sCodigoInterno = 'CA') AND (b.sNombre = 'TipoDocumentoContable')"
            End If
            intTipoID = XcDatos.ExecuteScalar(strSQL)

            'Datos del Depósito:
            If TipoCD = "CD" Then
                intMinutaID = -1
            Else 'Comprobante de Ajuste (CA) almacena Minuta de Depósito::
                intMinutaID = cboMinuta.Columns("nSteMinutaDepositoID").Value
            End If

            'Beneficiario/Proveedor:
            If Me.cboBeneficiario.SelectedIndex <> -1 Then
                intBeneficiarioID = cboBeneficiario.Columns("nBeneficiarioID").Value
            Else
                intBeneficiarioID = -1
            End If

            'En una Adición:
            If Me.ModoForm = "ADD" Then
                intCambioFechaCD = 0
            Else    'En una Edicion:              
                If (DateDiff("d", Me.dFecha, Me.cdeFechaCD.Value) <> 0) Then
                    intCambioFechaCD = 1 'Hubo cambio en la Fecha.
                Else
                    intCambioFechaCD = 0
                End If
            End If

            '-- Ejecuta Procedimiento Almacenado:
            strSQL = " EXEC spScnGrabarComprobanteDiario " & Me.IdScnComprobante & "," & intTipoID & ", " & InfoSistema.IDCuenta & "," & InfoSistema.IDDelegacion & ", " _
                        & intMinutaID & ", " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & "," & intBeneficiarioID & ", '" & StrFechaCD & "','" & StrFechaTC & "','" _
                        & LTrim(RTrim(Me.txtConcepto.Text)) & "','" & Trim(RTrim(Me.txtObservaciones.Text)) & "','" & Trim(RTrim(Me.txtCUE.Text)) & "'" _
                        & ",'" & Me.ModoForm & "', " & intCambioFechaCD
            Me.IdScnComprobante = XcDatos.ExecuteScalar(strSQL)

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.IdScnComprobante = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                If ModoForm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                    Call GuardarAuditoria(2, 24, "Modificación de Comprobante de Diario ID:" & Me.IdScnComprobante & ".")
                End If
            End If

            'Si cambio la Fecha generar Auditoría:
            If intCambioFechaCD = 1 Then
                Call GuardarAuditoria(4, 24, "Cambio de fecha de Comprobante de Diario No.: " & StrNoAnterior & " de " & Me.dFecha & " a " & Me.cdeFechaCD.Value & ". Asignándosele el nuevo Número: " & Me.txtCodigo.Text)
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
    ' Fecha:                20/11/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables: 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarComprobantedeDiario()
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
    ' Fecha:                20/11/2007
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
    ' Fecha:                17/12/2007
    ' Procedure Name:       CargarMinuta
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Minutas de Depósito.
    '-------------------------------------------------------------------------
    Private Sub CargarMinuta(ByVal intMinutaID As Integer)
        Try
            Dim Strsql As String = ""

            If intMinutaID = 0 Then
                Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta " & _
                         " From vwSteMinutaDeposito a " & _
                         " Where (a.nCerrada = 0) " & _
                         " Order by a.sNumeroDeposito"
            Else
                Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta " & _
                         " From vwSteMinutaDeposito a " & _
                         " Where (a.nCerrada = 0) or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                         " Order by a.sNumeroDeposito"
            End If

            XdtMinutaDeposito.ExecuteSql(Strsql)
            Me.cboMinuta.DataSource = XdtMinutaDeposito.Source

            Me.cboMinuta.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False

            'Configurar el combo
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").Width = 90
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").Width = 100
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 130

            Me.cboMinuta.Columns("sNumeroDeposito").Caption = "No. Minuta"
            Me.cboMinuta.Columns("dFechaDeposito").Caption = "Fecha Depósito"
            Me.cboMinuta.Columns("sNumeroCuenta").Caption = "Cuenta Bancaria"

            Me.cboMinuta.Columns("dFechaDeposito").NumberFormat = "dd/MM/yyyy"
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2007
    ' Procedure Name:       CargarBeneficiario
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Beneficiarios/Proveedores.
    '-------------------------------------------------------------------------
    Private Sub CargarBeneficiario(ByVal intBeneficiarioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBeneficiario.ClearFields()

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

            XdtBeneficiario.ExecuteSql(Strsql)
            Me.cboBeneficiario.DataSource = XdtBeneficiario.Source
            Me.cboBeneficiario.Rebind()

            'Configurar el combo:
            Me.cboBeneficiario.Splits(0).DisplayColumns("nBeneficiarioID").Visible = False
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboBeneficiario.Columns("sNombre").Caption = "Beneficiario/Proveedor"
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
End Class