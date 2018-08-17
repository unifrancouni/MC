' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccEditDetalleCierre.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Cierre.
'-------------------------------------------------------------------------
Public Class frmSccEditDetalleCierre

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSccCierreDiarioCaja As Integer
    Dim IdSccRecibo As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsMinuta As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjRecibodt As BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
    Dim ObjRecibodr As BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow

    'Enumerado para controlar las acciones sobre el Formulario
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
    Public Property IdCierreDiarioCaja() As Integer
        Get
            IdCierreDiarioCaja = IdSccCierreDiarioCaja
        End Get
        Set(ByVal value As Integer)
            IdSccCierreDiarioCaja = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdRecibo() As Integer
        Get
            IdRecibo = IdSccRecibo
        End Get
        Set(ByVal value As Integer)
            IdSccRecibo = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSccEditCierreCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditDetalleCierre_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjRecibodt.Close()
                ObjRecibodt = Nothing

                ObjRecibodr.Close()
                ObjRecibodr = Nothing

                XdsMinuta.Close()
                XdsMinuta = Nothing

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
    ' Autor:                
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSccEditCierreCaja_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditDetalleCierre_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarMinuta()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarRecibo()
                InhabilitarControles()
            End If

            Me.txtHastaRecibo.Select()

            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarMinuta
    ' Descripción:          Este procedimiento permite cargar el listado de Empleados
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMinuta()
        Try
            Dim Strsql As String

            Me.cboMinuta.ClearFields()

            Strsql = " Select a.nSteMinutaDepositoID,a.sNumeroDeposito,a.dFechaDeposito,a.nMontoDeposito " & _
                         " From vwSteMinutaDeposito a " & _
                         " Order by a.sNumeroDeposito "

            If XdsMinuta.ExistTable("Minuta") Then
                XdsMinuta("Minuta").ExecuteSql(Strsql)
            Else
                XdsMinuta.NewTable(Strsql, "Minuta")
                XdsMinuta("Minuta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMinuta.DataSource = XdsMinuta("Minuta").Source
            Me.cboMinuta.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboMinuta.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False

            'Configurar el combo
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").Width = 100
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").Width = 68
            Me.cboMinuta.Splits(0).DisplayColumns("nMontoDeposito").Width = 80

            Me.cboMinuta.Columns("sNumeroDeposito").Caption = "Número"
            Me.cboMinuta.Columns("dFechaDeposito").Caption = "Fecha"
            Me.cboMinuta.Columns("nMontoDeposito").Caption = "Monto"

            Me.cboMinuta.Columns("nMontoDeposito").NumberFormat = "#,##0.00"

            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("nMontoDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            'Me.grpLocalizacion.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""

            'If ModoFrm = "ADD" Then
            '    Me.Text = "Agregar Cierre Diario de Caja"
            'Else
            Me.Text = "Modificar Detalle Recibo"
            'End If

            ObjRecibodt = New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
            ObjRecibodr = New BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow

            Me.txtNumRecibo.Enabled = False
            Me.cdeFechaRecibo.Enabled = False
            Me.cneValor.Enabled = False
            Me.cdeFechaDeposito.Enabled = False

            XdsMinuta = New BOSistema.Win.XDataSet

            'If ModoFrm = "ADD" Then
            '    ObjCierredr = ObjCierredt.NewRow
            '    'Inicializar los Length de los campos (Strings?)
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarSocia
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibo()
        Dim ObjMinutaDT As New BOSistema.Win.SteEntTesoreria.SteMinutaDepositoDataTable
        Try
            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjRecibodt.Filter = "nSccReciboOficialCajaID = " & Me.IdSccRecibo
            ObjRecibodt.Retrieve()
            If ObjRecibodt.Count = 0 Then 'No hay socias registradas (ADD).
                Exit Sub
            End If
            ObjRecibodr = ObjRecibodt.Current 'Socia actual.

            'Número de Recibo
            If Not ObjRecibodr.IsFieldNull("nCodigo") Then
                Me.txtNumRecibo.Text = ObjRecibodr.nCodigo
            Else
                Me.txtNumRecibo.Text = ""
            End If

            'Número de Recibo Hasta
            If Not ObjRecibodr.IsFieldNull("nCodigo") Then
                Me.txtHastaRecibo.Text = ObjRecibodr.nCodigo
            Else
                Me.txtHastaRecibo.Text = ""
            End If

            'Fecha de Recibo 
            If Not ObjRecibodr.IsFieldNull("dFechaRecibo") Then
                Me.cdeFechaRecibo.Value = ObjRecibodr.dFechaRecibo
            Else
                Me.cdeFechaRecibo.Value = Me.cdeFechaRecibo.ValueIsDbNull
            End If

            'Minuta de Depósito
            If Not ObjRecibodr.IsFieldNull("nSteMinutaDepositoID") Then
                ObjMinutaDT.Filter = " nSteMinutaDepositoID = " & ObjRecibodr.nSteMinutaDepositoID
                ObjMinutaDT.Retrieve()

                If ObjMinutaDT.Count > 0 Then
                    If Me.cboMinuta.ListCount > 0 Then
                        Me.cboMinuta.SelectedIndex = 0
                        XdsMinuta("Minuta").SetCurrentByID("nSteMinutaDepositoID", ObjRecibodr.nSteMinutaDepositoID)
                    End If
                End If
            Else
                Me.cboMinuta.Text = ""
                Me.cboMinuta.SelectedIndex = -1
            End If

            'Número de Depósito
            'If Not ObjRecibodr.IsFieldNull("sNumeroDeposito") Then
            '    Me.txtNumDeposito.Text = ObjRecibodr.sNumeroDeposito
            'Else
            '    Me.txtNumDeposito.Text = ""
            'End If

            ''Fecha de Depósito 
            'If Not ObjRecibodr.IsFieldNull("dFechaDeposito") Then
            '    Me.cdeFechaDeposito.Value = ObjRecibodr.dFechaDeposito
            'Else
            '    Me.cdeFechaDeposito.Value = Me.cdeFechaDeposito.ValueIsDbNull
            'End If

            'Inicializar los Length de los campos
            'Me.txtNumDeposito.MaxLength = ObjRecibodr.GetColumnLenght("sNumeroDeposito")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjMinutaDT.Close()
            ObjMinutaDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
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
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        'Dim ObjTmpCierre As New BOSistema.Win.SccEntCartera.SccCierreDiarioCajaDataTable
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim dFechaDeposito As Date
            Dim dFechaDepositoInicial As Date
            Dim dFechaRecibo As Date
            Dim strSQL As String = ""

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Número de Recibo (Hasta)
            If Trim(RTrim(Me.txtHastaRecibo.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtHastaRecibo, "El Número del Recibo Final NO DEBE quedar vacío.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            'Número de Recibo (Hasta)
            If CInt(Me.txtHastaRecibo.Text) < CInt(Me.txtNumRecibo.Text) Then
                MsgBox("El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtHastaRecibo, "El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo seleccionado.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            'Número de Depósito
            'If Trim(RTrim(Me.txtNumDeposito.Text)).ToString.Length = 0 Then
            '    MsgBox("El Número del Depósito NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errRecibo.SetError(Me.txtNumDeposito, "El Número del Depósito NO DEBE quedar vacío.")
            '    Me.txtNumDeposito.Focus()
            '    Exit Function
            'End If

            'Fecha de Depósito
            'If Me.cdeFechaDeposito.ValueIsDbNull Then
            '    MsgBox("La Fecha de Depósito NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errRecibo.SetError(Me.cdeFechaDeposito, "La Fecha de Depósito NO DEBE quedar vacía.")
            '    Me.cdeFechaDeposito.Focus()
            '    Exit Function
            'End If

            'Minuta
            If Me.cboMinuta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Minuta de Depósito válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboMinuta, "Debe seleccionar una Minuta de Depósito válida.")
                Me.cboMinuta.Focus()
                Exit Function
            End If


            dFechaDeposito = Me.cdeFechaDeposito.Value
            dFechaRecibo = Me.cdeFechaRecibo.Value

            'Fecha del Depósito no menor que la Fecha del Recibo
            If dFechaDeposito.Date < dFechaRecibo.Date Then
                MsgBox("Fecha del Depósito (" & dFechaDeposito.Date & ") NO DEBE ser Menor que la Fecha del Recibo (" & dFechaRecibo.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaDeposito, "Fecha del Depósito (" & dFechaDeposito.Date & ") NO DEBE ser Menor que la Fecha del Recibo (" & dFechaRecibo.Date & ").")
                Me.cdeFechaDeposito.Focus()
                Exit Function
            End If

            'Fecha del Depósito no mayor que la Fecha del Servidor
            If dFechaDeposito.Date > FechaServer.Date Then
                MsgBox("Fecha de Depósito (" & dFechaDeposito.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaDeposito, "Fecha de Depósito (" & dFechaDeposito.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").")
                Me.cdeFechaDeposito.Focus()
                Exit Function
            End If

            'Validar que exista Tasa de Cambio para la Fecha de Cierre
            strSQL = " SELECT nMontoTCambio " & _
                     " FROM StbParidadCambiaria " & _
                  " WHERE dFechaTCambio = '" & Format(dFechaDeposito.Date, "yyyy-MM-dd") & "'" & _
                  " AND nStbMonedaBaseID = (Select sValorParametro From StbValorParametro Where nStbValorParametroID = 17)" & _
                  " AND nStbMonedaCambioID = (Select sValorParametro From StbValorParametro Where nStbValorParametroID = 18)"

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("Para Aplicar la Transacción Contable," & Chr(10) & _
                       "DEBE existir Tasa de Cambio para la Fecha del Depósito.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaDeposito, "Para Aplicar la Transacción Contable," & Chr(10) & _
                       "DEBE existir Tasa de Cambio para la Fecha del Depósito.")
                Me.cdeFechaDeposito.Focus()
                Exit Function
            End If

            strSQL = " SELECT dFechaDeposito FROM vwSccCierreDiarioCajaDetalle " & _
                     " where nSccCierreDiarioCajaID = " & Me.IdCierreDiarioCaja & _
                     " And sNumeroDeposito = '" & Me.cboMinuta.Text & "'" & _
                     " And dFechaDeposito <> '" & Format(dFechaDeposito.Date, "yyyy-MM-dd") & "'" & _
                     " And nSccReciboOficialCajaID <> " & Me.IdRecibo

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                dFechaDepositoInicial = XdtDatos.ValueField("dFechaDeposito")

                MsgBox("Existen Recibo con Número de Depósito ('" & Me.cboMinuta.Text & "')." & Chr(10) & _
                       "con otra Fecha de Depósito (" & Format(dFechaDepositoInicial.Date, "dd/MM/yyyy") & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaDeposito, "Existen Recibo con Número de Depósito ('" & Me.cboMinuta.Text & "')." & Chr(10) & _
                       "con otra Fecha de Depósito (" & Format(dFechaDepositoInicial.Date, "dd/MM/yyyy") & ").")
                Me.cdeFechaDeposito.Focus()
                Exit Function
            End If

            ''Determinar duplicados en la Fecha del Cierre para una misma Fuente de Financiamiento
            'If ModoFrm = "UPD" Then
            '    ObjTmpCierre.Filter = " nScnFuenteFinanciamientoID = " & XdsCierre("FuenteF").ValueField("nScnFuenteFinanciamientoID") & " and dFechaCierre = '" & Format(dFechaCierre.Date, "yyyy-MM-dd") & "' And nSccCierreDiarioCajaID <> " & Me.IdSccCierreDiarioCaja & " 	AND nStbEstadoCierreID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoCierreCartera')"

            'Else
            '    ObjTmpCierre.Filter = " nScnFuenteFinanciamientoID = " & XdsCierre("FuenteF").ValueField("nScnFuenteFinanciamientoID") & " And dFechaCierre = '" & Format(dFechaCierre.Date, "yyyy-MM-dd") & "' AND nStbEstadoCierreID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoCierreCartera')"
            'End If

            'ObjTmpCierre.Retrieve()

            'If ObjTmpCierre.Count > 0 Then
            '    MsgBox("La Fecha de Cierre NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errRecibo.SetError(Me.cdeFechaDeposito, "La Fecha de Cierre NO DEBE repetirse. ")
            '    Me.cdeFechaDeposito.SelectAll()
            '    Me.cdeFechaDeposito.Focus()
            '    Exit Function
            'End If

            'strSQL = " SELECT a.nSccTablaAmortizacionPagosID " & _
            '         " FROM SccTablaAmortizacionPagos a INNER JOIN SccReciboOficialCaja b " & _
            '      " ON a.nSccReciboOficialCajaID = b.nSccReciboOficialCajaID " & _
            '      " INNER JOIN SccSolicitudCheque c " & _
            '      " ON b.nSccSolicitudChequeID = c.nSccSolicitudChequeID " & _
            '      " WHERE b.dFechaRecibo = '" & Format(dFechaCierre.Date, "yyyy-MM-dd") & "'" & _
            '      " AND b.nStbEstadoReciboID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1') And b.sNombre = 'EstadoReciboOficialCaja')" & _
            '      " AND c.nScnFuenteFinanciamientoID = " & XdsCierre("FuenteF").ValueField("nScnFuenteFinanciamientoID")

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count <= 0 Then
            '    MsgBox("No existen Recibos para la Fuente Seleccionada en la Fecha ingresada.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errRecibo.SetError(Me.cdeFechaDeposito, "No existen Recibos para la Fuente Seleccionada en la Fecha ingresada.")
            '    Me.cdeFechaDeposito.Focus()
            '    Exit Function
            'End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            '    ObjTmpCierre.Close()
            '    ObjTmpCierre = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarRecibo()
        Dim XcDatos As New BOSistema.Win.XComando
        'Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String
            Dim dFechaDeposito As Date
            'Dim nReplicar As Integer = 0

            'strSQL = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
            '         " WHERE (dFechaDeposito is Null And sNumeroDeposito is Null) " & _
            '         " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('3') And b.sNombre = 'EstadoReciboOficialCaja') " & _
            '         " AND nSccReciboOficialCajaID IN (SELECT nSccReciboOficialCajaID FROM vwSccCierreDiarioCajaDetalle WHERE nSccCierreDiarioCajaID = " & Me.IdSccCierreDiarioCaja & ")"

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    If MsgBox("¿Desea replicar Número y Fecha del Depósito para el resto de recibo de este Cierre?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
            '        nReplicar = 1
            '    End If
            'End If

            dFechaDeposito = Me.cdeFechaDeposito.Value

            strSQL = " EXEC spSclGrabarDepositoRecibo " & Me.IdSccRecibo & "," & XdsMinuta("Minuta").ValueField("nSteMinutaDepositoID") & "," & InfoSistema.IDCuenta & "," & Me.IdSccCierreDiarioCaja & ",'" & Me.txtNumRecibo.Text & "','" & Me.txtHastaRecibo.Text & "'"

            'Asignar el Id de la Socia a la variable publica del formulario
            Me.IdSccRecibo = XcDatos.ExecuteScalar(strSQL)
            '--------------------------------

            '-- Buscar la ficha correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjRecibodt.Filter = "nSccReciboOficialCajaID = " & Me.IdSccRecibo
            ObjRecibodt.Retrieve()
            If ObjRecibodt.Count = 0 Then
                Exit Sub
            End If
            ObjRecibodr = ObjRecibodt.Current

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.IdSccRecibo = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            'XdtDatos.Close()
            'XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
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

    Private Sub txtNumDeposito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNumDeposito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub txtHastaRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaRecibo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtHastaRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHastaRecibo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboMinuta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMinuta.TextChanged
        If Me.cboMinuta.SelectedIndex <> -1 Then
            Me.cdeFechaDeposito.Value = XdsMinuta("Minuta").ValueField("dFechaDeposito")
            Me.cneValor.Value = XdsMinuta("Minuta").ValueField("nMontoDeposito")
        Else
            Me.cdeFechaDeposito.Value = Me.cdeFechaDeposito.ValueIsDbNull
            Me.cneValor.Value = 0
        End If
    End Sub
End Class