' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditSocia.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Socias.
'-------------------------------------------------------------------------
Public Class frmSccEditReciboCajaManualAdicional

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim sMotivoAnulacion As String
    Dim IdSccSolicitudCheque As Integer
    Dim IdSccReciboOficialCaja As Integer
    Dim blnModificar As Boolean = True
    Dim intFuenteFID As Integer
    Dim dFechaPagoSinMora As Date
    Dim nInteresesMoratorios As Double = 0
    Dim IdSccEspecial As Short

    Dim blnPeriodoGracia As Boolean = True
    Dim blnPrimeraVez As Boolean = True
    Dim IdMinutaDeposito As Integer = 0
    Dim IdCaja As Integer = 0
    Dim idCodigoTipoPlanNegocio As Short = 0
    Dim idTipoPrograma As Short = 0
    Dim idCodigoPlazo As String = ""
    Dim nCodigoTalonario As Integer = 0

    ''-- Clases para procesar la informacion de los combos
    Dim XdsRecibo As BOSistema.Win.XDataSet

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
    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property MotivoAnulacion() As String
        Get
            MotivoAnulacion = sMotivoAnulacion
        End Get
        Set(ByVal value As String)
            sMotivoAnulacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdSolicitudCheque() As Integer
        Get
            IdSolicitudCheque = IdSccSolicitudCheque
        End Get
        Set(ByVal value As Integer)
            IdSccSolicitudCheque = value
        End Set
    End Property

    Public Property IdReciboOficialCaja() As Integer
        Get
            IdReciboOficialCaja = IdSccReciboOficialCaja
        End Get
        Set(ByVal value As Integer)
            IdSccReciboOficialCaja = value
        End Set
    End Property

    Public Property IdEspecial() As Short
        Get
            IdEspecial = IdSccEspecial
        End Get
        Set(ByVal value As Short)
            IdSccEspecial = value
        End Set
    End Property
    Public Property sTipoPrograma() As Short
        Get
            sTipoPrograma = idTipoPrograma
        End Get
        Set(ByVal value As Short)
            idTipoPrograma = value
        End Set
    End Property
    Public Property sCodigoTipoPlanNegocio() As Short
        Get
            sCodigoTipoPlanNegocio = idCodigoTipoPlanNegocio
        End Get
        Set(ByVal value As Short)
            idCodigoTipoPlanNegocio = value
        End Set
    End Property
    Public Property sCodigoPlazo() As String
        Get
            sCodigoPlazo = idCodigoPlazo
        End Get
        Set(ByVal value As String)
            idCodigoPlazo = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclEditSocia_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjRecibodt.Close()
                ObjRecibodt = Nothing

                ObjRecibodr.Close()
                ObjRecibodr = Nothing

                XdsRecibo.Close()
                XdsRecibo = Nothing
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
    ' Procedure Name:       frmSclEditSocia_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditReciboCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarRepresentante(0)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then

                CargarRecibo()
                ObtenerSiModifica()
                PresentacionControles()

                CargarPago()
                FormatoPago()
            End If

            Me.lblMontoCuota.Visible = False
            Me.lblMoraCuota.Visible = False
            Me.lblMontoAdeudado.Visible = False
            Me.lblMoraTotal.Visible = False
            Me.txtMontoAdeudadoCuota.Visible = False
            Me.txtMoraCuota.Visible = False
            Me.txtMontoAdeudado.Visible = False
            Me.txtMora.Visible = False

            Me.txtMontoAdeudadoCuota.Enabled = False
            Me.txtMontoAdeudado.Enabled = False
            Me.txtMoraCuota.Enabled = False
            Me.txtMora.Enabled = False
            Me.txtSerieDelegacion.Enabled = False
            Me.cboRepresentante.Enabled = False

            Me.txtNumRecibo.Select()

            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

            blnPrimeraVez = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub ObtenerSiModifica()
        Try
            blnModificar = False

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       PresentacionControles
    ' Descripción:          Este procedimiento permite habilitar o inhabilitar
    '                       controles dependiendo del estado de la ficha.
    '-------------------------------------------------------------------------
    Private Sub PresentacionControles()
        Try

            Me.CmdAceptar.Enabled = True

            If blnModificar = False Then
                If ObjRecibodr.nManual = 0 Or ObjRecibodr.nAplicado = 0 Then
                    InhabilitarControlesReciboAutomatico()
                Else
                    InhabilitarControles()
                End If
                Exit Sub
            End If

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
            Me.cmdAceptar.Enabled = False
            Me.txtConcepto.Enabled = False
            Me.txtNumRecibo.Enabled = False
            Me.cboRepresentante.Enabled = False
            Me.cdeFecha.Enabled = False
            Me.cneValor.Enabled = False
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
    Private Sub InhabilitarControlesReciboAutomatico()
        Try
            Me.cmdAceptar.Enabled = False
            Me.txtConcepto.Enabled = False
            Me.txtNumRecibo.Enabled = False
            Me.cboRepresentante.Enabled = False
            Me.cdeFecha.Enabled = False
            Me.cneValor.Enabled = False
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
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            'Dim IntRegistros As Integer
            Dim nMontoAdeudadoTotal As Double = 0
            Dim nMoraTotal As Double = 0
            Dim nMoraCuota As Double = 0
            Dim IDFichaNotificacion As Integer
            Dim IDFichaNotificacionDetalle As Integer

            strSQL = "SELECT sNombreGrupo,sNombreSocia,sSerieDelegacion,nSclFichaNotificacionID,nSclFichaNotificacionDetalleID FROM vwSccGrupoSociaChequeEmitido " & _
                     "WHERE nSccSolicitudChequeID = " & Me.IdSccSolicitudCheque

            XdtDatos.ExecuteSql(strSQL)

            Me.txtRecibimosDe.Text = XdtDatos.ValueField("sNombreSocia")
            Me.txtPorCuentaDe.Text = XdtDatos.ValueField("sNombreGrupo")
            Me.txtSerieDelegacion.Text = XdtDatos.ValueField("sSerieDelegacion")
            IDFichaNotificacion = XdtDatos.ValueField("nSclFichaNotificacionID")
            IDFichaNotificacionDetalle = XdtDatos.ValueField("nSclFichaNotificacionDetalleID")

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Recibo Oficial de Caja"

                Me.cdeFecha.Value = FechaServer.Date
                Me.cneValor.Value = 0
                Me.txtConcepto.Text = ""

                'strSQL = "EXEC spSccConsultaCuota " & Me.IdSccSolicitudCheque & "," & IDFichaNotificacionDetalle

                'XdtDatos.ExecuteSql(strSQL)
                'IntRegistros = XdtDatos.Count

                'If IntRegistros > 0 Then
                '    Me.cdeFecha.Value = XdtDatos.ValueField("dFechaPago")
                '    dFechaPagoSinMora = XdtDatos.ValueField("dFechaPago")
                '    Me.cneValor.Value = XdtDatos.ValueField("nCuota")

                '    Me.txtConcepto.Text = "PAGO DE CUOTA NO. " & XdtDatos.ValueField("nNumCuota")

                '    Me.cneValor.Value = XdtDatos.ValueField("nCuota") + nMoraCuota
                'End If

                'Me.cdeFecha.Value = dFechaPagoSinMora.Date

            Else
                Me.Text = "Modificar Recibo Oficial de Caja"

            End If

            Control.CheckForIllegalCrossThreadCalls = False

            Me.txtRecibimosDe.Enabled = False
            Me.txtPorCuentaDe.Enabled = False
            Me.txtCantidadDe.Enabled = False

            strSQL = " SELECT a.dFechaDesembolso,a.nScnFuenteFinanciamientoID FROM SccSolicitudDesembolsoCredito a " & _
                     " INNER JOIN SccSolicitudCheque b " & _
                     " ON a.nSccSolicitudDesembolsoCreditoID = b.nSccSolicitudDesembolsoCreditoID " & _
                     " WHERE b.nSccSolicitudChequeID = " & Me.IdSccSolicitudCheque

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                Me.cdeFecha.Calendar.MinDate = XdtDatos.ValueField("dFechaDesembolso")
                Me.cdeFecha.Calendar.MaxDate = FechaServer()
                intFuenteFID = XdtDatos.ValueField("nScnFuenteFinanciamientoID")
            End If

            ObjRecibodt = New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
            ObjRecibodr = New BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow

            XdsRecibo = New BOSistema.Win.XDataSet

            'Determinar la Caja
            'strSQL = " SELECT b.nSteCajaID FROM SclFichaNotificacionCredito a " & _
            '         " INNER JOIN SteCaja b " & _
            '         " ON a.nStbPersonaLugarPagosID = b.nStbPersonaLugarPagosID " & _
            '         " WHERE a.nSclFichaNotificacionID = " & IDFichaNotificacion

            strSQL = " SELECT b.nSteCajaID FROM SclFichaNotificacionCredito a " & _
                             " INNER JOIN SteCaja b " & _
                             " ON a.nStbPersonaLugarPagosID = b.nStbPersonaLugarPagosID " & _
                             " INNER JOIN                      dbo.StbValorCatalogo AS c ON b.nStbTipoProgramaID = c.nStbValorCatalogoID " & _
                             " INNER JOIN                      dbo.StbValorCatalogo AS d ON b.nStbTipoPlazoPagosID = d.nStbValorCatalogoID " & _
                             " WHERE (c.sCodigoInterno = '" & sTipoPrograma & "') And (d.sCodigoInterno = '" & sCodigoPlazo & "' ) AND (b.nCerrada = 0) And a.nSclFichaNotificacionID = " & IDFichaNotificacion




            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count = 0 Then
                MsgBox("No Existe una caja con el lugar de pago para el programa y el tipo de plazo.", MsgBoxStyle.Critical, "SMUSURA0")

                Me.cmdAceptar.Enabled = False
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cmdCancelar, "Existe mas de una caja con el lugar de pago para el programa y el tipo de plazo.")
                Me.cmdCancelar.Focus()
                Exit Sub
            End If


            If XdtDatos.Count > 1 Then
                MsgBox("Existe mas de una caja con el lugar de pago para el programa y el tipo de plazo.", MsgBoxStyle.Critical, "SMUSURA0")

                Me.cmdAceptar.Enabled = False
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cmdCancelar, "Existe mas de una caja con el lugar de pago para el programa y el tipo de plazo.")
                Me.cmdCancelar.Focus()
                Exit Sub
            End If


            If XdtDatos.Count > 0 Then
                IdCaja = XdtDatos.ValueField("nSteCajaID")
            End If

            If ModoFrm = "ADD" Then
                ObjRecibodr = ObjRecibodt.NewRow
                'Inicializar los Length de los campos (Strings?)
                Me.txtConcepto.MaxLength = ObjRecibodr.GetColumnLenght("sConceptoPago")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
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
        Try
            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjRecibodt.Filter = "nSccReciboOficialCajaID = " & Me.IdSccReciboOficialCaja
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

            'Fecha de Recibo 
            If Not ObjRecibodr.IsFieldNull("dFechaRecibo") Then
                Me.cdeFecha.Value = ObjRecibodr.dFechaRecibo
            Else
                Me.cdeFecha.Value = Me.cdeFecha.ValueIsDbNull
            End If

            'Concepto de Pago
            If Not ObjRecibodr.IsFieldNull("sConceptoPago") Then
                Me.txtConcepto.Text = ObjRecibodr.sConceptoPago
            Else
                Me.txtConcepto.Text = ""
            End If

            'Valor
            If Not ObjRecibodr.IsFieldNull("nValor") Then
                Me.cneValor.Value = ObjRecibodr.nValor
            Else
                Me.cneValor.Value = 0
            End If

            'Empleado (Cajera)
            If Not ObjRecibodr.IsFieldNull("nSrhEmpleadoCajeroID") Then
                CargarRepresentante(ObjRecibodr.nSrhEmpleadoCajeroID)
                If Me.cboRepresentante.ListCount > 0 Then
                    Me.cboRepresentante.SelectedIndex = 0
                    XdsRecibo("Representante").SetCurrentByID("nSrhEmpleadoID", ObjRecibodr.nSrhEmpleadoCajeroID)
                End If
            Else
                Me.cboRepresentante.Text = ""
                Me.cboRepresentante.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos
            Me.txtConcepto.MaxLength = ObjRecibodr.GetColumnLenght("sConceptoPago")

        Catch ex As Exception
            Control_Error(ex)
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
            Me.cmdAceptar.Enabled = False
            Me.cmdCancelar.Enabled = False
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
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            Dim dFechaRecibo As Date
            Dim dFechaUltimo As Date
            Dim dFechaArqueo As Date
            Dim nValorArqueo As Double = 0
            Dim nValorRecibo As Double = 0
            Dim sFuente As String = ""

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            strSQL = " SELECT sCodigo FROM ScnFuenteFinanciamiento " & _
                     " WHERE nScnFuenteFinanciamientoID = " & intFuenteFID

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.ValueField("sCodigo") = "93" Or XdtDatos.ValueField("sCodigo") = "94" Then
                sFuente = "CARUNA"
                MsgBox("FUENTE CARUNA NO PUEDE INGRESAR RECIBOS.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.txtNumRecibo, "FUENTE CARUNA NO PUEDE INGRESAR RECIBOS.")
                Me.txtNumRecibo.Focus()
                Exit Function

            End If

            If XdtDatos.ValueField("sCodigo") = "93" Or XdtDatos.ValueField("sCodigo") = "94" Then
                sFuente = "CARUNA"
            End If

            'Número de Recibo
            If Trim(RTrim(Me.txtNumRecibo.Text)).ToString.Length = 0 Then
                MsgBox("El Número de Recibo NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.txtNumRecibo, "El Número de Recibo NO DEBE quedar vacío.")
                Me.txtNumRecibo.Focus()
                Exit Function
            End If

            nCodigoTalonario = IntCodigoTalonario(cdeFecha.Value)
            If sFuente = "CARUNA" Then
                If ModoFrm = "UPD" Then
                    strSQL = " SELECT nSccReciboOficialCajaID FROM vwSccReciboSerie " & _
                             " WHERE (nManual = 1) And nScnFuenteFinanciamientoID = " & intFuenteFID & " And sCodigoInterno <> '3'"
                Else
                    strSQL = " SELECT nSccReciboOficialCajaID FROM vwSccReciboSerie " & _
                             " WHERE (nManual = 1) And nScnFuenteFinanciamientoID = " & intFuenteFID & " AND nCodigo = " & Me.txtNumRecibo.Text & " And sCodigoInterno <> '3'"
                End If
            Else
                'If ModoFrm = "UPD" Then
                '    strSQL = " SELECT nSccReciboOficialCajaID FROM vwSccReciboSerie " & _
                '             " WHERE (nManual = 1) And sSerieDelegacion = '" & Me.txtSerieDelegacion.Text & "' AND nCodigo = " & Me.txtNumRecibo.Text & " And nSccReciboOficialCajaID <> " & Me.IdSccReciboOficialCaja & " And sCodigoInterno <> '3'"
                'Else
                '    strSQL = " SELECT nSccReciboOficialCajaID FROM vwSccReciboSerie " & _
                '             " WHERE (nManual = 1) And sSerieDelegacion = '" & Me.txtSerieDelegacion.Text & "' AND nCodigo = " & Me.txtNumRecibo.Text & " And sCodigoInterno <> '3'"
                'End If


                If ModoFrm = "UPD" Then
                    'ObjTmpRecibo.Filter = " nCodigo = " & Me.txtNumRecibo.Text & " And nSccReciboOficialCajaID <> " & Me.IdSccReciboOficialCaja & " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') "
                    strSQL = " SELECT nSccReciboOficialCajaID FROM vwSccReciboSerie " & _
                             " WHERE (nManual = 1) And  nCodigoTalonario=" & nCodigoTalonario & " And sCodTipoPlazoPago= '" & sCodigoPlazo & "'   And sSerieDelegacion = '" & Me.txtSerieDelegacion.Text & "' AND TipoPrograma = " & sTipoPrograma & "   AND nCodigo = " & Me.txtNumRecibo.Text & " And nSccReciboOficialCajaID <> " & Me.IdSccReciboOficialCaja & " And sCodigoInterno <> '3'"
                Else
                    'ObjTmpRecibo.Filter = " nCodigo = " & Me.txtNumRecibo.Text & " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') "
                    strSQL = " SELECT nSccReciboOficialCajaID FROM vwSccReciboSerie " & _
                             " WHERE (nManual = 1)  And  nCodigoTalonario=" & nCodigoTalonario & " And sCodTipoPlazoPago= '" & sCodigoPlazo & "'   And sSerieDelegacion = '" & Me.txtSerieDelegacion.Text & "' AND TipoPrograma = " & sTipoPrograma & " AND nCodigo = " & Me.txtNumRecibo.Text & " And sCodigoInterno <> '3'"
                End If


            End If

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 1 Then 'REVISAR  Antes era > 0 Esto es por lo de los recibos discontinuos  a partir del 1ro de enero del 2015
                MsgBox("El Número del Recibo NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.txtNumRecibo, "El Número del Recibo NO DEBE repetirse. ")
                Me.txtNumRecibo.SelectAll()
                Me.txtNumRecibo.Focus()
                Exit Function
            End If

            'Fecha de Recibo
            If Me.cdeFecha.ValueIsDbNull Then
                MsgBox("La Fecha de Recibo NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cdeFecha, "La Fecha de Recibo NO DEBE quedar vacía.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            dFechaRecibo = Me.cdeFecha.Value

            'Fecha del Recibo no menor que la Fecha de Desembolso
            If dFechaRecibo.Date < Me.cdeFecha.Calendar.MinDate.Date Then
                MsgBox("Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Menor que la Fecha del Desembolso (" & Me.cdeFecha.Calendar.MinDate.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Menor que la Fecha del Desembolso (" & Me.cdeFecha.Calendar.MinDate.Date & ").")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Fecha del Recibo no mayor que la Fecha del Servidor
            If dFechaRecibo.Date > FechaServer.Date Then
                MsgBox("Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Valor
            If Me.cneValor.ValueIsDbNull Then
                MsgBox("El Valor del Recibo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cneValor, "El Valor del Recibo NO DEBE quedar vacío.")
                Me.cneValor.Focus()
                Exit Function
            End If

            If sFuente = "" Then
                'strSQL = " SELECT a.nValor, a.nSrhCajeroID, a.dFechaArqueo, a.nSteMinutaDepositoID " & _
                '         " FROM vwSteDatosReciboArqueo a " & _
                '         " WHERE a.sSerieDelegacion = '" & Me.txtSerieDelegacion.Text & "' And a.sEstadoArqueo = '2' and a.nCodigo = " & CInt(Me.txtNumRecibo.Text)

                strSQL = " SELECT a.nValor, a.nSrhCajeroID, a.dFechaArqueo, a.nSteMinutaDepositoID " & _
                         " FROM vwSteDatosReciboArqueo a " & _
                         " WHERE a.sSerieDelegacion = '" & Me.txtSerieDelegacion.Text & "' And a.sEstadoArqueo = '2' and a.nCodigo = " & CInt(Me.txtNumRecibo.Text) & " And ProgramaCaja='" & sTipoPrograma.ToString().Trim() & "'  And  nCodigoTalonario=" & nCodigoTalonario & "   And sCodTipoPlazoPago= '" & sCodigoPlazo & "' "



                XdtDatos.ExecuteSql(strSQL)

                If XdtDatos.Count > 0 Then
                    'Empleado (Cajera)
                    If Not XdtDatos.ValueField("nSrhCajeroID") Is DBNull.Value Then
                        CargarRepresentante(XdtDatos.ValueField("nSrhCajeroID"))
                        If Me.cboRepresentante.ListCount > 0 Then
                            Me.cboRepresentante.SelectedIndex = 0
                            XdsRecibo("Representante").SetCurrentByID("nSrhEmpleadoID", XdtDatos.ValueField("nSrhCajeroID"))
                        End If
                    Else
                        Me.cboRepresentante.Text = ""
                        Me.cboRepresentante.SelectedIndex = -1
                    End If

                    'Minuta de Depósito
                    If Not XdtDatos.ValueField("nSteMinutaDepositoID") Is DBNull.Value Then
                        IdMinutaDeposito = XdtDatos.ValueField("nSteMinutaDepositoID")
                    Else
                        IdMinutaDeposito = 0
                    End If

                    dFechaArqueo = XdtDatos.ValueField("dFechaArqueo")

                    'Minuta
                    If IdMinutaDeposito = 0 Then
                        MsgBox("No existe Minuta asociada al Arqueo.", MsgBoxStyle.Critical, "SMUSURA0")
                        ValidaDatosEntrada = False
                        Me.cmdAceptar.Enabled = True
                        Me.cmdCancelar.Enabled = True
                        Me.errRecibo.SetError(Me.cboRepresentante, "No existe Minuta asociada al Arqueo.")
                        Me.txtNumRecibo.Focus()
                        Exit Function
                    End If

                    'Fecha del Recibo DEBE SER igual a la Fecha del Arqueo
                    If dFechaRecibo.Date <> dFechaArqueo.Date Then
                        MsgBox("Fecha de Recibo DEBE ser Igual a la Fecha del Arqueo.", MsgBoxStyle.Critical, "SMUSURA0")
                        ValidaDatosEntrada = False
                        Me.cmdAceptar.Enabled = True
                        Me.cmdCancelar.Enabled = True
                        Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Recibo DEBE ser Igual a la Fecha del Arqueo.")
                        Me.cdeFecha.Focus()
                        Exit Function
                    End If

                    nValorArqueo = XdtDatos.ValueField("nValor")
                    nValorRecibo = Math.Round(Me.cneValor.Value, 2)

                    'Valor del Recibo DEBE SER igual al Valor ingresado en el Arqueo
                    If nValorRecibo <> nValorArqueo Then
                        MsgBox("El Valor del Recibo DEBE ser igual al valor ingresado en el Arqueo.", MsgBoxStyle.Critical, "SMUSURA0")
                        ValidaDatosEntrada = False
                        Me.cmdAceptar.Enabled = True
                        Me.cmdCancelar.Enabled = True
                        Me.errRecibo.SetError(Me.cneValor, "El Valor del Recibo DEBE ser igual al valor ingresado en el Arqueo.")
                        Me.cneValor.Focus()
                        Exit Function
                    End If

                    'Validar que la Minuta que se asoció al Recibo según el Arqueo 
                    'no haya sido enviada al MHCP
                    strSQL = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                             " INNER JOIN SteMinutaDeposito b " & _
                             " ON b.nStbEstadoMinutaID = a.nStbValorCatalogoID " & _
                             " WHERE b.nSteMinutaDepositoID = " & IdMinutaDeposito & _
                             " AND a.sCodigoInterno = '2'"

                    XdtDatos.ExecuteSql(strSQL)

                    'REM COMENTARIADO TEMPORALMENTE 16012008
                    If XdtDatos.Count > 0 Then
                        MsgBox("No DEBE asociar una Minuta que ya fue Enviada al MHCP.", MsgBoxStyle.Critical, "SMUSURA0")
                        ValidaDatosEntrada = False
                        Me.cmdAceptar.Enabled = True
                        Me.cmdCancelar.Enabled = True
                        Me.errRecibo.SetError(Me.txtNumRecibo, "No DEBE asociar una Minuta que ya fue Enviada al MHCP.")
                        Me.txtNumRecibo.Focus()
                        Exit Function
                    End If
                Else
                    Me.cboRepresentante.Text = ""
                    Me.cboRepresentante.SelectedIndex = -1

                    IdMinutaDeposito = 0

                    If dFechaRecibo.Month >= 2 And dFechaRecibo.Year >= 2008 Then
                        MsgBox("Recibo DEBE estar incluido en un Arqueo Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                        ValidaDatosEntrada = False
                        Me.cmdAceptar.Enabled = True
                        Me.cmdCancelar.Enabled = True
                        Me.errRecibo.SetError(Me.txtNumRecibo, "Recibo DEBE estar incluido en un Arqueo Cerrado.")
                        Me.txtNumRecibo.Focus()
                        Exit Function
                    End If
                    If dFechaRecibo.Day >= 19 And dFechaRecibo.Month = 1 And dFechaRecibo.Year = 2008 Then
                        MsgBox("Recibo DEBE estar incluido en un Arqueo Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                        ValidaDatosEntrada = False
                        Me.cmdAceptar.Enabled = True
                        Me.cmdCancelar.Enabled = True
                        Me.errRecibo.SetError(Me.txtNumRecibo, "Recibo DEBE estar incluido en un Arqueo Cerrado.")
                        Me.txtNumRecibo.Focus()
                        Exit Function
                    End If
                End If
            End If

            strSQL = " Select nSccCierreDiarioCajaID From vwSccReciboEstadoCierre " & _
                     " Where sEstadoCierre = 'Cerrado' And dFechaCierre = '" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'" & _
                     " And nScnFuenteFinanciamientoID = " & intFuenteFID

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede utilizarse la Fecha de Recibo ingresada, por tener Cierre Diario de Caja" & Chr(10) & _
                        "para dicha Fecha en Estado Cerrado, es decir que tiene Transacción Contable.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cdeFecha, "No puede utilizarse la Fecha de Recibo ingresada, por tener Cierre Diario de Caja" & Chr(10) & _
                        "para dicha Fecha en Estado Cerrado, es decir que tiene Transacción Contable.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Valor
            If Me.cneValor.Value = 0 Then
                MsgBox("El Valor del Recibo NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cneValor, "El Valor del Recibo NO DEBE ser Cero.")
                Me.cneValor.Focus()
                Exit Function
            End If

            'Concepto de Pago
            If Trim(RTrim(Me.txtConcepto.Text)).ToString.Length = 0 Then
                MsgBox("El Concepto de Pago NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.txtConcepto, "El Concepto de Pago NO DEBE quedar vacío.")
                Me.txtConcepto.Focus()
                Exit Function
            End If

            'Cajera
            If Me.cboRepresentante.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un(a) Cajero(a) válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboRepresentante, "Debe seleccionar un(a) Cajero(a) válido.")
                Me.cboRepresentante.Focus()
                Exit Function
            End If

            'Validar que el Recibo no tenga Fecha menor que un Recibo posterior.
            If blnModificar = True Then
                If ModoFrm <> "ACR" Then
                    If ModoFrm = "ADD" Then
                        strSQL = " SELECT dFechaRecibo FROM SccReciboOficialCaja " & _
                                 " WHERE nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                                 " AND nSccSolicitudChequeID = " & Me.IdSccSolicitudCheque & _
                                 " ORDER BY dFechaRecibo DESC"
                    Else
                        strSQL = " SELECT dFechaRecibo FROM SccReciboOficialCaja " & _
                                 " WHERE nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                                 " AND nSccSolicitudChequeID = " & Me.IdSccSolicitudCheque & _
                                 " AND nSccReciboOficialCajaID <> " & Me.IdSccReciboOficialCaja & _
                                 " ORDER BY dFechaRecibo DESC"
                    End If

                    XdtDatos.ExecuteSql(strSQL)

                    If XdtDatos.Count > 0 Then

                        dFechaUltimo = XdtDatos.ValueField("dFechaRecibo")

                        If dFechaRecibo.Date < dFechaUltimo.Date Then
                            MsgBox("No puede utilizarse la Fecha de Recibo ingresada," & Chr(10) & _
                                    "por existir Recibos con Fecha posterior .", MsgBoxStyle.Critical, "SMUSURA0")
                            ValidaDatosEntrada = False
                            Me.cmdAceptar.Enabled = True
                            Me.cmdCancelar.Enabled = True
                            Me.errRecibo.SetError(Me.cdeFecha, "No puede utilizarse la Fecha de Recibo ingresada," & Chr(10) & _
                                    "por existir Recibos con Fecha posterior .")
                            Me.cdeFecha.Focus()
                            Exit Function
                        End If
                    End If
                Else
                    strSQL = " SELECT dFechaRecibo FROM SccReciboOficialCaja " & _
                             " WHERE nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                             " AND convert(datetime,dFechaRecibo,105) < CONVERT(datetime,'" & ObjRecibodr.dFechaRecibo & "',105)" & _
                             " AND nSccSolicitudChequeID = " & Me.IdSccSolicitudCheque & _
                             " ORDER BY dFechaRecibo DESC"

                    XdtDatos.ExecuteSql(strSQL)

                    If XdtDatos.Count > 0 Then
                        dFechaUltimo = XdtDatos.ValueField("dFechaRecibo")

                        If dFechaRecibo.Date < dFechaUltimo.Date Then
                            MsgBox("No puede utilizarse la Fecha de Recibo ingresada," & Chr(10) & _
                                    "por existir Recibos con Fecha posterior .", MsgBoxStyle.Critical, "SMUSURA0")
                            ValidaDatosEntrada = False
                            Me.cmdAceptar.Enabled = True
                            Me.cmdCancelar.Enabled = True
                            Me.errRecibo.SetError(Me.cdeFecha, "No puede utilizarse la Fecha de Recibo ingresada," & Chr(10) & _
                                    "por existir Recibos con Fecha posterior .")
                            Me.cdeFecha.Focus()
                            Exit Function
                        End If
                    End If
                End If
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(dFechaRecibo.Date) = False Then
                MsgBox("El Mes Contable se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboRepresentante, "El Mes Contable se encuentra Cerrado.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
            Me.cmdCancelar.Enabled = True
        Finally
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
        Try
            Dim strSQL As String
            Dim dFechaRecibo As Date
            Dim intReciboTmpID As Integer

            dFechaRecibo = Me.cdeFecha.Value

            strSQL = " EXEC spSccGrabarReciboOficialCajaManualAdicional " & Me.IdSccReciboOficialCaja & "," & Me.IdSccSolicitudCheque & "," & Me.txtNumRecibo.Text & ",'" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'," & Me.cneValor.Value & ",'" & Me.txtConcepto.Text & "'," & XdsRecibo("Representante").ValueField("nSrhEmpleadoID") & "," & IdMinutaDeposito & ",'" & Me.ModoFrm & "'," & InfoSistema.IDCuenta & "," & Me.IdEspecial & "," & IdCaja & "," & nCodigoTalonario

            'Asignar el Id de la Socia a la variable publica del formulario
            intReciboTmpID = XcDatos.ExecuteScalar(strSQL)
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If intReciboTmpID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")
            ElseIf intReciboTmpID = -1 Then
                MsgBox("Los datos no pudieron grabarse. Valor del Recibo Mayor a la Deuda.", MsgBoxStyle.Information, "SMUSURA0")
                'ModoFrm = "ACR"
            Else
                If ModoFrm = "ADD" Then
                    Me.IdSccReciboOficialCaja = intReciboTmpID

                    '-- Buscar la ficha correspondiente al Id especificado
                    '-- como parámetro, en los casos que se esté editando una.
                    ObjRecibodt.Filter = "nSccReciboOficialCajaID = " & Me.IdSccReciboOficialCaja
                    ObjRecibodt.Retrieve()
                    If ObjRecibodt.Count = 0 Then
                        Exit Sub
                    End If
                    ObjRecibodr = ObjRecibodt.Current

                    'MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

#Region "Desglose Pago"
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDetalleRecibo
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos del Detalle del Recibo en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarPago()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSccTablaAmortizacionPagosID,a.nSccReciboOficialCajaID,a.nNumeroCuota,a.nPrincipal,a.nMantenimientoValor,a.nInteresesCorrientes,a.nInteresesMoratorios,(a.nPrincipal+a.nMantenimientoValor+a.nInteresesCorrientes+a.nInteresesMoratorios) as nTotalPagado,a.nSaldoActual " & _
                         " From SccTablaAmortizacionPagos a " & _
                         " Where a.nSccReciboOficialCajaID = " & Me.IdSccReciboOficialCaja

            If XdsRecibo.ExistTable("Pago") Then
                XdsRecibo("Pago").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Pago")
                XdsRecibo("Pago").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdDesglosePago.DataSource = XdsRecibo("Pago").Source
            Me.grdDesglosePago.FetchRowStyles = True

            'Actualizando el caption de los GRIDS
            Me.grdDesglosePago.Caption = " Listado de Desglose Pago (" + Me.grdDesglosePago.RowCount.ToString + " registros)"

            CalcularMontosPago()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       FormatoOtroCredito
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Otros Créditos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoPago()
        Try
            'Configuracion del Grid 
            Me.grdDesglosePago.Splits(0).DisplayColumns("nSccTablaAmortizacionPagosID").Visible = False
            Me.grdDesglosePago.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = False

            Me.grdDesglosePago.ColumnFooters = True
            Me.grdDesglosePago.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdDesglosePago.Splits(0).DisplayColumns("nPrincipal").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDesglosePago.Splits(0).DisplayColumns("nPrincipal").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDesglosePago.Splits(0).DisplayColumns("nPrincipal").FooterStyle.ForeColor = Color.Blue

            Me.grdDesglosePago.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDesglosePago.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDesglosePago.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.ForeColor = Color.Blue

            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.ForeColor = Color.Blue

            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.ForeColor = Color.Blue

            Me.grdDesglosePago.Splits(0).DisplayColumns("nTotalPagado").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDesglosePago.Splits(0).DisplayColumns("nTotalPagado").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDesglosePago.Splits(0).DisplayColumns("nTotalPagado").FooterStyle.ForeColor = Color.Blue

            Me.grdDesglosePago.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdDesglosePago.Splits(0).DisplayColumns("nNumeroCuota").Width = 70
            Me.grdDesglosePago.Splits(0).DisplayColumns("nPrincipal").Width = 110
            Me.grdDesglosePago.Splits(0).DisplayColumns("nMantenimientoValor").Width = 110
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesCorrientes").Width = 110
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesMoratorios").Width = 110
            Me.grdDesglosePago.Splits(0).DisplayColumns("nTotalPagado").Width = 110
            Me.grdDesglosePago.Splits(0).DisplayColumns("nSaldoActual").Width = 90

            Me.grdDesglosePago.Columns("nNumeroCuota").Caption = "Cuota No."
            Me.grdDesglosePago.Columns("nPrincipal").Caption = "Principal"
            Me.grdDesglosePago.Columns("nMantenimientoValor").Caption = "Mantenimiento"
            Me.grdDesglosePago.Columns("nInteresesCorrientes").Caption = "Int.Corrientes"
            Me.grdDesglosePago.Columns("nInteresesMoratorios").Caption = "Int.Moratorios"
            Me.grdDesglosePago.Columns("nTotalPagado").Caption = "Total Pagado"
            Me.grdDesglosePago.Columns("nSaldoActual").Caption = "Saldo Actual"

            Me.grdDesglosePago.Splits(0).DisplayColumns.Item("nPrincipal").Style.BackColor = Color.WhiteSmoke
            Me.grdDesglosePago.Splits(0).DisplayColumns.Item("nMantenimientoValor").Style.BackColor = Color.WhiteSmoke
            Me.grdDesglosePago.Splits(0).DisplayColumns.Item("nInteresesCorrientes").Style.BackColor = Color.WhiteSmoke
            Me.grdDesglosePago.Splits(0).DisplayColumns.Item("nInteresesMoratorios").Style.BackColor = Color.WhiteSmoke
            Me.grdDesglosePago.Splits(0).DisplayColumns.Item("nTotalPagado").Style.BackColor = Color.WhiteSmoke

            Me.grdDesglosePago.Splits(0).DisplayColumns("nNumeroCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDesglosePago.Splits(0).DisplayColumns("nPrincipal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDesglosePago.Splits(0).DisplayColumns("nMantenimientoValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesCorrientes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDesglosePago.Splits(0).DisplayColumns("nInteresesMoratorios").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDesglosePago.Splits(0).DisplayColumns("nSaldoActual").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDesglosePago.Splits(0).DisplayColumns("nTotalPagado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDesglosePago.Columns("nPrincipal").NumberFormat = "#,##0.00"
            Me.grdDesglosePago.Columns("nMantenimientoValor").NumberFormat = "#,##0.00"
            Me.grdDesglosePago.Columns("nInteresesCorrientes").NumberFormat = "#,##0.00"
            Me.grdDesglosePago.Columns("nInteresesMoratorios").NumberFormat = "#,##0.00"
            Me.grdDesglosePago.Columns("nSaldoActual").NumberFormat = "#,##0.00"
            Me.grdDesglosePago.Columns("nTotalPagado").NumberFormat = "#,##0.00"

            CalcularMontosPago()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CalcularMontos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total para visualizarlo en el Grid de Otros Créditos.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontosPago()
        Try
            Dim vTotalPrincipal As Double = 0
            Dim vTotalMantenimientoValor As Double = 0
            Dim vTotalInteresesCorrientes As Double = 0
            Dim vTotalInteresesMoratorios As Double = 0
            Dim vTotalPagado As Double = 0

            For index As Integer = 0 To Me.grdDesglosePago.RowCount - 1
                Me.grdDesglosePago.Row = index
                vTotalPrincipal = vTotalPrincipal + Me.grdDesglosePago.Columns("nPrincipal").Value
                vTotalMantenimientoValor = vTotalMantenimientoValor + Me.grdDesglosePago.Columns("nMantenimientoValor").Value
                vTotalInteresesCorrientes = vTotalInteresesCorrientes + Me.grdDesglosePago.Columns("nInteresesCorrientes").Value
                vTotalInteresesMoratorios = vTotalInteresesMoratorios + Me.grdDesglosePago.Columns("nInteresesMoratorios").Value
                vTotalPagado = vTotalPagado + Me.grdDesglosePago.Columns("nTotalPagado").Value
            Next
            If Me.grdDesglosePago.RowCount > 0 Then
                Me.grdDesglosePago.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdDesglosePago.Columns("nPrincipal").FooterText = Format(vTotalPrincipal, "#,##0.00")
            Me.grdDesglosePago.Columns("nMantenimientoValor").FooterText = Format(vTotalMantenimientoValor, "#,##0.00")
            Me.grdDesglosePago.Columns("nInteresesCorrientes").FooterText = Format(vTotalInteresesCorrientes, "#,##0.00")
            Me.grdDesglosePago.Columns("nInteresesMoratorios").FooterText = Format(vTotalInteresesMoratorios, "#,##0.00")
            Me.grdDesglosePago.Columns("nTotalPagado").FooterText = Format(vTotalPagado, "#,##0.00")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       tbAfectacion_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbAfectacion.
    '-------------------------------------------------------------------------
    'Private Sub tbOtrosCreditos_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbOtrosCreditos.ItemClicked
    '    Select Case e.ClickedItem.Name
    '        Case "toolAgregarOC"
    '            LlamaAgregarOC()
    '        Case "toolModificarOC"
    '            LlamaModificarOC()
    '        Case "toolEliminarOC"
    '            LlamaEliminarOC()
    '        Case "toolRefrescarOC"
    '            CargarOtroCredito()
    '        Case "toolAyudaOC"
    '            LlamaAyuda()
    '    End Select
    'End Sub
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Suárez Tijerino
    '' Fecha:                21/08/2007
    '' Procedure Name:       LlamaAgregarOC
    '' Descripción:          Este procedimiento permite llamar al formulario
    ''                       frmSclEditOtroCredito para Agregar un nuevo crédito vigente.
    ''-------------------------------------------------------------------------
    'Private Sub LlamaAgregarOC()
    '    Dim ObjFrmSclEditOtroCredito As New frmSclEditOtroCredito
    '    Try
    '        ObjFrmSclEditOtroCredito.ModoFrm = "ADD"
    '        ObjFrmSclEditOtroCredito.intFichaID = Me.intFichaID
    '        ObjFrmSclEditOtroCredito.sTipoFicha = "VERIFICACION"
    '        ObjFrmSclEditOtroCredito.strColor = "RojoLight"
    '        ObjFrmSclEditOtroCredito.ShowDialog()

    '        If ObjFrmSclEditOtroCredito.intOtroCreditoID <> 0 Then
    '            CargarOtroCredito()
    '            XdsDetalle("OtroCredito").SetCurrentByID("nSclOtroCreditoVigenteID", ObjFrmSclEditOtroCredito.intOtroCreditoID)
    '            Me.grdOtroCredito.Row = XdsDetalle("OtroCredito").BindingSource.Position
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        'ObjFrmScnEditAfectacionDetalle.Close()
    '        ObjFrmSclEditOtroCredito = Nothing

    '    End Try
    'End Sub
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Suárez Tijerino
    '' Fecha:                21/08/2006
    '' Procedure Name:       LlamaModificarOC
    '' Descripción:          Este procedimiento permite llamar al formulario
    ''                       frmScnEditAfectacionDetalle para Modificar una Afectación existente.
    ''-------------------------------------------------------------------------
    'Private Sub LlamaModificarOC()
    '    Dim ObjFrmSclEditOtroCredito As New frmSclEditOtroCredito
    '    Try
    '        If Me.grdOtroCredito.RowCount = 0 Then
    '            MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If
    '        ObjFrmSclEditOtroCredito.ModoFrm = "UPD"
    '        ObjFrmSclEditOtroCredito.intFichaID = Me.intFichaID
    '        ObjFrmSclEditOtroCredito.sTipoFicha = "VERIFICACION"
    '        ObjFrmSclEditOtroCredito.strColor = "RojoLight"
    '        ObjFrmSclEditOtroCredito.intOtroCreditoID = XdsDetalle("OtroCredito").ValueField("nSclOtroCreditoVigenteID")
    '        ObjFrmSclEditOtroCredito.ShowDialog()

    '        CargarOtroCredito()
    '        XdsDetalle("OtroCredito").SetCurrentByID("nSclOtroCreditoVigenteID", ObjFrmSclEditOtroCredito.intOtroCreditoID)
    '        Me.grdOtroCredito.Row = XdsDetalle("OtroCredito").BindingSource.Position

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        'ObjFrmScnEditAfectacionDetalle.Close()
    '        ObjFrmSclEditOtroCredito = Nothing
    '    End Try
    'End Sub
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Suárez Tijerino
    '' Fecha:                21/08/2006
    '' Procedure Name:       LlamaEliminarOC
    '' Descripción:          Este procedimiento permite eliminar un registro
    ''                       de un crédito vigente existente.
    ''-------------------------------------------------------------------------
    'Private Sub LlamaEliminarOC()
    '    Dim XdtOtroCredito As New BOSistema.Win.XDataSet.xDataTable
    '    Try
    '        If Me.grdOtroCredito.RowCount = 0 Then
    '            MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If
    '        If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

    '            XdtOtroCredito.ExecuteSqlNotTable("Delete From SclOtroCreditoVigente where nSclOtroCreditoVigenteID=" & XdsDetalle("OtroCredito").ValueField("nSclOtroCreditoVigenteID"))
    '            CargarOtroCredito()

    '            MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
    '            Me.grdOtroCredito.Caption = "Listado de Desglose Pago (" + Me.grdOtroCredito.RowCount.ToString + " registros)"
    '        End If
    '    Catch ex As Exception
    '        MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
    '        'Control_Error(ex)
    '    Finally
    '        XdtOtroCredito.Close()
    '        XdtOtroCredito = Nothing
    '    End Try
    'End Sub
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Suárez Tijerino
    '' Fecha:                21/08/2006
    '' Procedure Name:       LlamaAyuda
    '' Descripción:          Este procedimiento permite presentar la Ayuda en
    ''                       Línea al usuario. Actualmente en Construcción.
    ''-------------------------------------------------------------------------
    'Private Sub LlamaAyuda()
    '    Try
    '        MsgBox("En construcción", MsgBoxStyle.Information, "SMUSURA0")
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Suárez Tijerino
    '' Fecha:                21/08/2006
    '' Procedure Name:       grdOtroCredito_DoubleClick
    '' Descripción:          Este evento permite llamar al procedimiento encargado
    ''                       de Modificar Otro crédito existente, al hacer doble click
    ''                       sobre el registro deseado.
    ''-------------------------------------------------------------------------
    'Private Sub grdOtroCredito_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOtroCredito.DoubleClick
    '    Try
    '        If blnModificar = True Then
    '            LlamaModificarOC()
    '        End If
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    ''    'Sirve en caso que se filtren registros en la FilterBar
    'Private Sub grdOtroCredito_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdOtroCredito.Filter
    '    Try
    '        XdsDetalle("OtroCredito").FilterLocal(e.Condition)
    '        Me.grdOtroCredito.Caption = " Listado de Desglose Pago (" + Me.grdOtroCredito.RowCount.ToString + " registros)"

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

#End Region
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarRepresentante
    ' Descripción:          Este procedimiento permite cargar el listado de Empleados
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarRepresentante(ByVal intRepresentanteID As Integer)
        Try
            Dim Strsql As String

            Me.cboRepresentante.ClearFields()
            If intRepresentanteID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE a.nActivo = 1" & _
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE (a.nActivo = 1) " & _
                         " Or a.nSrhEmpleadoID = " & intRepresentanteID & _
                         " Order by a.nCodigo "
            End If

            '" WHERE (a.nActivo = 1 And a.sCodCargo = '04') " & _

            If XdsRecibo.ExistTable("Representante") Then
                XdsRecibo("Representante").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Representante")
                XdsRecibo("Representante").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboRepresentante.DataSource = XdsRecibo("Representante").Source
            Me.cboRepresentante.Rebind()

            Me.cboRepresentante.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False

            'Configurar el combo
            Me.cboRepresentante.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboRepresentante.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

            Me.cboRepresentante.Columns("nCodigo").Caption = "Código"
            Me.cboRepresentante.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboRepresentante.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboRepresentante.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Solo se permite Números, () , - BackSpace y la Barra espaciadora
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

    Private Sub cneValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneValor.TextChanged
        'Me.txtCantidadDe.Text = ModSMUSURA0.NroEnLetras(Me.cneValor.Value)
    End Sub

    Private Sub cneValor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cneValor.ValueChanged
        If Not Me.cneValor.ValueIsDbNull Then
            If Me.cneValor.Value > 0 Then
                Me.txtCantidadDe.Text = ModSMUSURA0.NroEnLetras(Me.cneValor.Value, True, "Córdoba", "Córdobas")
            End If
        End If
    End Sub

    Private Sub txtNumRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRecibo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNumRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumRecibo.TextChanged
        Try
            vbModifico = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cdeFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFecha.TextChanged

        vbModifico = True

    End Sub
    'NO ES UTILIZADA CALCULARMORA
    Private Function CalcularMora(ByVal nCuotaSinMora As Double, ByVal nPrincipalSinMora As Double, ByVal nMantValorSinMora As Double, ByVal dFechaPagoSinMora As Date) As Double   'cdeFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdeFecha.ValueChanged
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim nDiasTranscurridos As Integer = 0
            Dim nDiasHabiles As Integer = 0
            Dim dFechaRecibo As Date
            Dim nDiasCalculoMora As Integer = 360
            Dim nTasaMora As Double = 0.025
            Dim strSQL As String = ""

            blnPeriodoGracia = True

            'SET DATEFIRST 1;
            ' Obtener parámetro de días para el cálculo de la mora
            ' Puede ser 360 (anual) o 30 (mensual)
            strSQL = " Select sValorParametro " & _
                     " FROM StbValorParametro " & _
                     " WHERE (nStbValorParametroID = 29) "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                nDiasCalculoMora = XdtDatos.ValueField("sValorParametro")
            End If

            ' Obtener parámetro de Tasa de Interés por mora
            strSQL = " Select sValorParametro " & _
                     " FROM StbValorParametro " & _
                     " WHERE (nStbValorParametroID = 3) "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                nTasaMora = XdtDatos.ValueField("sValorParametro") / 100
            End If

            dFechaRecibo = Me.cdeFecha.Value

            If dFechaRecibo.Date > dFechaPagoSinMora.Date Then

                nDiasTranscurridos = DateDiff(DateInterval.Day, dFechaPagoSinMora.Date, dFechaRecibo.Date)

                nInteresesMoratorios = (nPrincipalSinMora + nMantValorSinMora) * nDiasTranscurridos * nTasaMora / nDiasCalculoMora
                blnPeriodoGracia = False
            Else
                nInteresesMoratorios = 0
                blnPeriodoGracia = True
            End If

            CalcularMora = nInteresesMoratorios
            Return CalcularMora

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function

End Class