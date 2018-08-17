' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                28/03/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccEditReestructuracionDeuda.vb
' Descripci�n:          Este formulario permite ingresar o modificar datos
'                       de una Reestructuraci�n de Cr�dito.
'-------------------------------------------------------------------------
Public Class frmSccEditReestructuracionDeuda

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intFichaID As Long
    Dim intReestructuracionID As Integer
    Dim IntHabilitar As Integer
    Dim dFechaAnterior As Date

    '-- Clases para procesar la informacion de los combos
    Dim XdsDetalle As BOSistema.Win.XDataSet
    Dim XdtSocia As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset
    Dim ObjReestructuraciondt As BOSistema.Win.SclEntFicha.SclReestructuracionDeudaDataTable
    Dim ObjReestructuraciondr As BOSistema.Win.SclEntFicha.SclReestructuracionDeudaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
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

    'Propiedad utilizada para obtener el ID de la Reestructuraci�n.
    Public Property intSclReestructuracionID() As Long
        Get
            intSclReestructuracionID = intReestructuracionID
        End Get
        Set(ByVal value As Long)
            intReestructuracionID = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Ficha de Notificaci�n.
    Public Property intSclFichaID() As Long
        Get
            intSclFichaID = intFichaID
        End Get
        Set(ByVal value As Long)
            intFichaID = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       frmSccEditReestructuracionDeuda_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditReestructuracionDeuda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjReestructuraciondt.Close()
                ObjReestructuraciondt = Nothing

                ObjReestructuraciondr.Close()
                ObjReestructuraciondr = Nothing

                XdsDetalle.Close()
                XdsDetalle = Nothing

                XdtSocia.Close()
                XdtSocia = Nothing
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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       frmSccEditReestructuracionDeuda_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Reestructuraci�n en caso de estar 
    '                       en el modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditReestructuracionDeuda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario est� en modo edici�n
            'cargar los datos de la ficha.
            If ModoForm = "UPD" Then
                CargarReestructuracion()
                InhabilitarControles()
                'Cargar segunda pesta�a:
                CargarResolucionCredito()
                FormatoResolucionCredito()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            If cdeFechaReestructuracion.Enabled Then
                Me.cdeFechaReestructuracion.Select()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripci�n:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            'En caso de Inhabilitar:
            If IntHabilitar = 0 Then
                Me.tbResolucion.Enabled = False
                Me.grpDatosGenerales.Enabled = False
                Me.grpReestructuracionSocia.Enabled = False
                Me.CmdAceptar.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       InicializarVariables
    ' Descripci�n:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Reestructuraci�n de Cr�dito"
                'Obligar ingresar Encabezado de la Reestructuraci�n:
                Me.tabPResolucion.Enabled = False
            Else
                Me.Text = "Modificar Reestructuraci�n de Cr�dito"
                Me.tabPResolucion.Enabled = True
            End If

            Me.tbResolucion.Visible = True
            Me.cboSocia.ClearFields()

            ObjReestructuraciondt = New BOSistema.Win.SclEntFicha.SclReestructuracionDeudaDataTable
            ObjReestructuraciondr = New BOSistema.Win.SclEntFicha.SclReestructuracionDeudaRow

            XdsDetalle = New BOSistema.Win.XDataSet
            XdtSocia = New BOSistema.Win.XDataSet.xDataTable

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los Grids:
            Me.grdResolucion.ClearFields()
            'Por defecto se abre en Datos Generales:
            Me.tabFicha.SelectedIndex = 0

            'Inicializar Fecha:
            Me.cdeFechaReestructuracion.Value = ModSMUSURA0.FechaServer

            If ModoForm = "ADD" Then
                ObjReestructuraciondr = ObjReestructuraciondt.NewRow
                Me.txtObservaciones.MaxLength = ObjReestructuraciondr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       CargarReestructuracion
    ' Descripci�n:          Este procedimiento permite cargar los datos de la 
    '                       Reestructuraci�n seleccionada.
    '-------------------------------------------------------------------------
    Private Sub CargarReestructuracion()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar la Reestructuraci�n correspondiente al Id especificado como
            '-- par�metro, en los casos que se est� editando una.
            ObjReestructuraciondt.Filter = "nSclReestructuracionDeudaID = " & Me.intSclReestructuracionID
            ObjReestructuraciondt.Retrieve()
            If ObjReestructuraciondt.Count = 0 Then
                Exit Sub
            End If
            ObjReestructuraciondr = ObjReestructuraciondt.Current

            'C�digo de la Reestructuraci�n:
            If Not ObjReestructuraciondr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjReestructuraciondr.nCodigo
                Me.txtCodigoR.Text = ObjReestructuraciondr.nCodigo
            Else
                Me.txtCodigo.Text = ""
                Me.txtCodigoR.Text = ""
            End If

            'Estado Reestructuraci�n:
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjReestructuraciondr.nStbEstadoReestructuracionID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoR.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            'Fecha de Reestructuraci�n del Cr�dito:
            If Not ObjReestructuraciondr.IsFieldNull("dFechaReestructuracion") Then
                Me.cdeFechaReestructuracion.Value = ObjReestructuraciondr.dFechaReestructuracion
            Else
                Me.cdeFechaReestructuracion.Value = Me.cdeFechaReestructuracion.ValueIsDbNull
            End If

            'Observaciones:
            If Not ObjReestructuraciondr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjReestructuraciondr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjReestructuraciondr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       CmdCancelActualizacion_Click
    ' Descripci�n:          Este evento permite ocultar datos de actualizaci�n
    '                       de Reestructuraci�n de la deuda de una Socia
    '                       y rehabilitar tbResolucion sin haberse efectuado 
    '                       ning�n cambio en monto y plazo.
    '-------------------------------------------------------------------------
    Private Sub CmdCancelActualizacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCancelActualizacion.Click
        'Reestablecer ambiente:
        grpReestructuracionSocia.Visible = False
        tbResolucion.Enabled = True
        Me.tabPDatosGrales.Enabled = True
        'MsgBox("No se realiz� ning�n cambio.", MsgBoxStyle.Information)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       ValidaDatosReestructuracion
    ' Descripci�n:          Esta funci�n permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosReestructuracion() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try

            Dim strSQL As String = ""
            Dim IntUltimaCuota As Integer
            Dim IntUltimaReestructuracion As Integer
            Dim nMontoAbonado As Double

            ValidaDatosReestructuracion = True
            Me.errReestructuracion.Clear()

            'Debe Indicar una Socia Valida:
            If Me.cboSocia.SelectedIndex = -1 Then
                MsgBox("Debe indicar una Socia V�lida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cboSocia, "Socia Inv�lida.")
                Me.cboSocia.Focus()
                Exit Function
            End If

            'Imposible si la Socia ya forma parte de los Detalles de la Reestructuraci�n:
            If CmdActualizar.Tag = "ADD" Then
                strSQL = "Select * FROM SclReestructuracionDeudaDetalles " & _
                         "WHERE (nSclReestructuracionDeudaID = " & Me.intReestructuracionID & ") AND (nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ")"
            Else
                strSQL = "Select * FROM SclReestructuracionDeudaDetalles " & _
                         "WHERE (nSclReestructuracionDeudaDetalleID <> " & XdsDetalle("Resolucion").ValueField("nSclReestructuracionDeudaDetalleID") & ") And (nSclReestructuracionDeudaID = " & Me.intReestructuracionID & ") AND (nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ")"
            End If
            If RegistrosAsociados(strSQL) Then
                MsgBox("La Socia ya forma parte de la Reestructuraci�n.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cboSocia, "Socia Inv�lida.")
                Me.cboSocia.Focus()
                Exit Function
            End If

            'Imposible si la Socia NO tiene Cuotas Pendientes de Pago:
            strSQL = "SELECT DFNC.nSclFichaNotificacionID " & _
                     "FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (TA.nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("La Socia NO tiene Cuotas Pendientes de Pago.", MsgBoxStyle.Information)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cboSocia, "Socia NO tiene Cuotas Pendientes de Pago.")
                Me.cboSocia.Focus()
                Exit Function
            End If

            'Imposible si no se indic� un N�mero de Ultima Cuota v�lida:
            If Not IsNumeric(cneUltimaCuota.Value) Then
                MsgBox("Ultima Cuota Inv�lida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cneUltimaCuota, "Ultima Cuota Inv�lida.")
                Me.cneUltimaCuota.Focus()
                Exit Function
            End If

            'Encuentra la Ultima Reestructuracion Aplicada de la Ficha:
            strSQL = "SELECT ISNULL(MAX(SclReestructuracionDeuda.nSclReestructuracionDeudaID), 0) AS IdReestructuracion " & _
                     "FROM SclReestructuracionDeuda INNER JOIN StbValorCatalogo ON SclReestructuracionDeuda.nStbEstadoReestructuracionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclReestructuracionDeuda.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (StbValorCatalogo.sCodigoInterno = '2')"
            IntUltimaReestructuracion = XcDatos.ExecuteScalar(strSQL)

            'El Numero de la Ultima Cuota DEBE ser la Ultima con Pago Total o Parcial: 
            strSQL = " SELECT SccTablaAmortizacionPagos.nNumeroCuota AS NoCuota " & _
                     " FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID " & _
                     " INNER JOIN SccTablaAmortizacionPagos ON TA.nSccTablaAmortizacionID = SccTablaAmortizacionPagos.nSccTablaAmortizacionID INNER JOIN SccReciboOficialCaja ON SccTablaAmortizacionPagos.nSccReciboOficialCajaID = SccReciboOficialCaja.nSccReciboOficialCajaID  INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID LEFT OUTER JOIN SclReestructuracionDeudaDetalles ON TA.nSclReestructuracionDeudaDetalleID = SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaDetalleID " & _
                     " WHERE (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (TA.nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND  (C.sCodigoInterno <> '4') " & _
                     " AND (ISNULL(SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaID, 0) = " & IntUltimaReestructuracion & ")"
            If RegistrosAsociados(strSQL) Then
                strSQL = " SELECT MAX(SccTablaAmortizacionPagos.nNumeroCuota) AS NoCuota " & _
                         " FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID " & _
                         " INNER JOIN SccTablaAmortizacionPagos ON TA.nSccTablaAmortizacionID = SccTablaAmortizacionPagos.nSccTablaAmortizacionID INNER JOIN SccReciboOficialCaja ON SccTablaAmortizacionPagos.nSccReciboOficialCajaID = SccReciboOficialCaja.nSccReciboOficialCajaID  INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID LEFT OUTER JOIN SclReestructuracionDeudaDetalles ON TA.nSclReestructuracionDeudaDetalleID = SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaDetalleID " & _
                         " WHERE (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (TA.nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.sCodigoInterno <> '4') " & _
                         " AND (ISNULL(SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaID, 0) = " & IntUltimaReestructuracion & ")"
                IntUltimaCuota = XcDatos.ExecuteScalar(strSQL)
                If Me.cneUltimaCuota.Value <> IntUltimaCuota Then
                    MsgBox("La Ultima Cuota Cancelada indicada NO corresponde" & Chr(13) & "con la del ultimo pago efectuado por la Socia.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosReestructuracion = False
                    Me.errReestructuracion.SetError(Me.cneUltimaCuota, "Ultima Cuota Cancelada Inv�lida.")
                    Me.cneUltimaCuota.Focus()
                    Exit Function
                End If
            Else 'La Socia No hab�a efectuado ningun Pago Total o Parcial: Ubicar Cuota en Cero. 
                If Me.cneUltimaCuota.Value <> 0 Then
                    MsgBox("Ultima Cuota Cancelada Inv�lida." & Chr(13) & "La Socia NO hab�a efectuado ning�n pago.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosReestructuracion = False
                    Me.errReestructuracion.SetError(Me.cneUltimaCuota, "Ultima Cuota Cancelada Inv�lida.")
                    Me.cneUltimaCuota.Focus()
                    Exit Function
                End If
            End If

            'Fecha de Primer Pago V�lida:
            If Me.cdeFechaPrimerPago.ValueIsDbNull Then
                MsgBox("Fecha de Primer Pago de Cuota de la Reestructuraci�n" & Chr(13) & "del Cr�dito NO DEBE quedar vac�a.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cdeFechaPrimerPago, "La Fecha Primer Pago de Reestructuraci�n Inv�lida.")
                Me.cdeFechaPrimerPago.Focus()
                Exit Function
            End If

            'Fecha De Primer Pago debe ser Mayor que la Ultima Cuota Cancelada por la Socia (Total o Parcial):
            '-- Cuotas Pagadas o Pagadas Parciales (Pendiente de Pago en Amortizacion Pagos con Recibos <> Anulado)
            strSQL = " SELECT SccTablaAmortizacionPagos.dFechaPago AS UltimoPago " & _
                     " FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID " & _
                     " INNER JOIN SccTablaAmortizacionPagos ON TA.nSccTablaAmortizacionID = SccTablaAmortizacionPagos.nSccTablaAmortizacionID INNER JOIN SccReciboOficialCaja ON SccTablaAmortizacionPagos.nSccReciboOficialCajaID = SccReciboOficialCaja.nSccReciboOficialCajaID  INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (TA.nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.sCodigoInterno <> '4')"
            If RegistrosAsociados(strSQL) Then
                strSQL = " SELECT MAX(SccTablaAmortizacionPagos.dFechaPago) AS UltimoPago " & _
                         " FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID " & _
                         " INNER JOIN SccTablaAmortizacionPagos ON TA.nSccTablaAmortizacionID = SccTablaAmortizacionPagos.nSccTablaAmortizacionID INNER JOIN SccReciboOficialCaja ON SccTablaAmortizacionPagos.nSccReciboOficialCajaID = SccReciboOficialCaja.nSccReciboOficialCajaID  INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (TA.nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.sCodigoInterno <> '4')"
                dFechaAnterior = XcDatos.ExecuteScalar(strSQL)
                If Format(Me.cdeFechaPrimerPago.Value, "yyyy-MM-dd") <= dFechaAnterior Then
                    MsgBox("Fecha de Primer Pago DEBE ser superior a fecha" & Chr(13) & "de la Ultima Cuota Cancelada por la Socia.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosReestructuracion = False
                    Me.errReestructuracion.SetError(Me.cdeFechaPrimerPago, "Fecha de Primer Pago Inv�lida.")
                    Me.cdeFechaPrimerPago.Focus()
                    Exit Function
                End If
            End If

            'Fecha de Primer Pago debe ser Mayor que la de la Reestructuraci�n del Credito:
            If Format(Me.cdeFechaPrimerPago.Value, "yyyy-MM-dd") <= Format(Me.cdeFechaReestructuracion.Value, "yyyy-MM-dd") Then
                MsgBox("Fecha de Primer Pago de la Socia DEBE ser superior" & Chr(13) & "a la de Fecha de la Reestructuraci�n del Cr�dito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cdeFechaPrimerPago, "Fecha de Primer Pago Inv�lida.")
                Me.cdeFechaPrimerPago.Focus()
                Exit Function
            End If

            'Imposible si no se indic� un plazo v�lido:
            If Not IsNumeric(cnePlazoAprobado.Value) Then
                MsgBox("Plazo Reestructurado Inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cnePlazoAprobado, "Plazo Reestructurado Inv�lido.")
                Me.cnePlazoAprobado.Focus()
                Exit Function
            End If
            If CDbl(cnePlazoAprobado.Value) = 0 Then
                MsgBox("Plazo Reestructurado Inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cnePlazoAprobado, "Plazo Reestructurado Inv�lido.")
                Me.cnePlazoAprobado.Focus()
                Exit Function
            End If

            'Validar Plazo M�ximo:
            XdtValorParametro.Filter = "nStbParametroID = 10"
            XdtValorParametro.Retrieve()
            If CInt(Me.cnePlazoAprobado.Value) > CInt(XdtValorParametro.ValueField("sValorParametro")) Then
                MsgBox("El Plazo NO DEBE ser mayor a " & XdtValorParametro.ValueField("sValorParametro") & ", establecido como plazo m�ximo" & Chr(10) & _
                    "por el Programa USURA CERO.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cnePlazoAprobado, "Plazo Aprobado Inv�lido.")
                Me.cnePlazoAprobado.Focus()
                Exit Function
            End If

            'En casos de Adici�n Validar Iguales Fechas y Plazos (En la Edici�n NO en caso que se deseen Cambiar).
            If CmdActualizar.Tag = "ADD" Then
                '-- 1. Imposible si existen Socias en la Reestructuraci�n con Otra Fecha para el Primer Pago:
                strSQL = "SELECT nSclReestructuracionDeudaID FROM  SclReestructuracionDeudaDetalles " & _
                         "WHERE (nSclReestructuracionDeudaID = " & Me.intReestructuracionID & ") AND (dFechaPrimerCuota <> CONVERT(DATETIME, '" & Format(Me.cdeFechaPrimerPago.Value, "yyyy-MM-dd") & "', 102))"
                'Edici�n:
                'strSQL = "SELECT nSclReestructuracionDeudaID FROM  SclReestructuracionDeudaDetalles " & _
                '         "WHERE (nSclReestructuracionDeudaDetalleID <> " & XdsDetalle("Resolucion").ValueField("nSclReestructuracionDeudaDetalleID") & ") And (nSclReestructuracionDeudaID = " & Me.intReestructuracionID & ") AND (dFechaPrimerCuota <> CONVERT(DATETIME, '" & Format(Me.cdeFechaPrimerPago.Value, "yyyy-MM-dd") & "', 102))"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existen Socias en la Reestructuraci�n con diferente Fecha de Primer Pago." & Chr(13) & "Antes Debe igualar las Fechas de Primer Pagos de las Socias ya ingresadas.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosReestructuracion = False
                    Me.errReestructuracion.SetError(Me.cdeFechaPrimerPago, "Fecha de Primer Pago Inv�lida.")
                    Me.cdeFechaPrimerPago.Focus()
                    Exit Function
                End If
                '-- 2. Imposible si existen Socias en la Reestructuraci�n con Otro Plazo:
                strSQL = "SELECT nSclReestructuracionDeudaID FROM  SclReestructuracionDeudaDetalles " & _
                         "WHERE (nSclReestructuracionDeudaID = " & Me.intReestructuracionID & ") AND (nPlazoAprobado <> " & Me.cnePlazoAprobado.Value & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existen Socias en la Reestructuraci�n con diferente Plazo Reestructurado." & Chr(13) & "Antes Debe igualar los plazos de las Socias ya ingresadas.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosReestructuracion = False
                    Me.errReestructuracion.SetError(Me.cnePlazoAprobado, "Plazo Reestructurado Inv�lido.")
                    Me.cnePlazoAprobado.Focus()
                    Exit Function
                End If
            End If

            'Imposible si no se indic� un Monto V�lido:
            If Not IsNumeric(cneMontoAprobado.Value) Then
                MsgBox("Monto Reestructurado Inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cneMontoAprobado, "Monto Reestructurado Inv�lido.")
                Me.cneMontoAprobado.Focus()
                Exit Function
            End If
            If CDbl(cneMontoAprobado.Value) = 0 Then
                MsgBox("Monto Reestructurado Inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cneMontoAprobado, "Monto Reestructurado Inv�lido.")
                Me.cneMontoAprobado.Focus()
                Exit Function
            End If

            'Monto debe Corresponder con las Cuotas No Pagadas en la Reestructuraci�n:
            '-- Monto Total Deuda (Principal + Mantenimiento del Valor) de Cuotas No Anuladas en T.A.:
            strSQL = "SELECT ISNULL(SUM(TA.nAmortizacion) + SUM(TA.nMantValor), 0) AS nMonto " & _
                     "FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID " & _
                     "LEFT OUTER JOIN SclReestructuracionDeudaDetalles ON TA.nSclReestructuracionDeudaDetalleID = SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaDetalleID " & _
                     "WHERE (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (TA.nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ") AND (C.sCodigoInterno <> '4') " & _
                     "AND (ISNULL(SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaID, 0) = " & IntUltimaReestructuracion & ")"
            nMontoAbonado = XcDatos.ExecuteScalar(strSQL)
            '-- Monto Abonado por la Socia en T.A.P. con Recibos de Caja Activos de Cuotas No Anuladas en TA
            '   y Recibos de Caja diferentes de Anulados:
            strSQL = "SELECT ISNULL(SUM(SccTablaAmortizacionPagos.nPrincipal) + SUM(SccTablaAmortizacionPagos.nMantenimientoValor), 0) AS MontoAbonado " & _
                     "FROM SccTablaAmortizacion AS TA INNER JOIN SclFichaNotificacionDetalle AS DFNC ON TA.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN StbValorCatalogo AS C ON TA.nStbEstadoPagoID = C.nStbValorCatalogoID  INNER JOIN SccTablaAmortizacionPagos " & _
                     "ON TA.nSccTablaAmortizacionID = SccTablaAmortizacionPagos.nSccTablaAmortizacionID INNER JOIN SccReciboOficialCaja ON SccTablaAmortizacionPagos.nSccReciboOficialCajaID = SccReciboOficialCaja.nSccReciboOficialCajaID INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "LEFT OUTER JOIN SclReestructuracionDeudaDetalles ON TA.nSclReestructuracionDeudaDetalleID = SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaDetalleID " & _
                     "WHERE (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (TA.nSclFichaNotificacionDetalleID = " & cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ") AND (C.sCodigoInterno <> '4') AND (dbo.StbValorCatalogo.sCodigoInterno <> '3') " & _
                     "AND (ISNULL(SclReestructuracionDeudaDetalles.nSclReestructuracionDeudaID, 0) = " & IntUltimaReestructuracion & ")"
            '-- Monto No Pagado = Total Deuda Socia - Monto Abonado:
            nMontoAbonado = Math.Round(nMontoAbonado - CDbl(XcDatos.ExecuteScalar(strSQL)), 2)
            If nMontoAbonado <> Me.cneMontoAprobado.Value Then
                MsgBox("El Monto Reestructurado DEBE corresponder con la Suma" & Chr(10) & _
                       "de las Cuotas a�n No Canceladas por la Socia.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosReestructuracion = False
                Me.errReestructuracion.SetError(Me.cneMontoAprobado, "Monto Reestructurado Inv�lido.")
                Me.cneMontoAprobado.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosReestructuracion = False
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       CmdActualizar_Click
    ' Descripci�n:          Este evento permite actualizar los datos de 
    '                       reestructuraci�n de la deuda de una Socia. 
    '-------------------------------------------------------------------------
    Private Sub CmdActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdActualizar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            Dim intPosicion As Integer

            'Si los datos son Validos:
            If ValidaDatosReestructuracion() Then
                'Confirmar Cambio:
                If MsgBox("�Est� seguro de registrar los datos del Cr�dito" & Chr(13) & "Reestructurado para la socia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                    'Adicionar Reestructuraci�n: 
                    If CmdActualizar.Tag = "ADD" Then
                        strSQL = "Insert Into SclReestructuracionDeudaDetalles " & _
                                 "(nSclReestructuracionDeudaID, nSclFichaNotificacionDetalleID, dFechaPrimerCuota, " & _
                                 "nStbTipoPlazoID, nNumeroUltimoCuota, nPlazoAprobado, nMontoCredito, nUsuarioCreacionID, dFechaCreacion) " & _
                                 " Values (" & Me.intReestructuracionID & ", " & Me.cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ", '" & Format(Me.cdeFechaPrimerPago.Value, "yyyy-MM-dd") & "'" & _
                                 " , " & Me.cboSocia.Columns("nStbTipoPlazoAprobadoID").Value & ", " & Me.cneUltimaCuota.Value & ", " & Me.cnePlazoAprobado.Value & ", " & Me.cneMontoAprobado.Value & ", " & InfoSistema.IDCuenta & ", getdate())"
                    Else
                        'Actualizar Reestructuraci�n:
                        strSQL = " Update SclReestructuracionDeudaDetalles " & _
                                 " SET nUsuariomodificacionId = " & InfoSistema.IDCuenta & ", dfechamodificacion = getdate(), nMontoCredito = " & Me.cneMontoAprobado.Value & ", nPlazoAprobado = " & Me.cnePlazoAprobado.Value & ", " & _
                                 " nSclFichaNotificacionDetalleID = " & Me.cboSocia.Columns("nSclFichaNotificacionDetalleID").Value & ", dFechaPrimerCuota = '" & Format(Me.cdeFechaPrimerPago.Value, "yyyy-MM-dd") & "', nNumeroUltimoCuota = " & Me.cneUltimaCuota.Value & " Where " & _
                                 " nSclReestructuracionDeudaDetalleID = " & XdsDetalle("Resolucion").ValueField("nSclReestructuracionDeudaDetalleID")
                    End If
                    XcDatos.ExecuteNonQuery(strSQL)
                    'Guardar posici�n actual de la selecci�n
                    intPosicion = XdsDetalle("Resolucion").ValueField("nSclReestructuracionDeudaDetalleID")
                    'Refrescar Cambios:
                    CargarResolucionCredito()
                    FormatoResolucionCredito()
                    'Ubicar la selecci�n en la posici�n original
                    XdsDetalle("Resolucion").SetCurrentByID("nSclReestructuracionDeudaDetalleID", intPosicion)
                    Me.grdResolucion.Row = XdsDetalle("Resolucion").BindingSource.Position
                End If

                'Reestablecer ambiente:
                grpReestructuracionSocia.Visible = False
                tbResolucion.Enabled = True
                Me.tabPDatosGrales.Enabled = True

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       CargarSocia
    ' Descripci�n:          Este procedimiento permite cargar el listado de Socias
    '                       en el combo para su selecci�n.
    '-------------------------------------------------------------------------
    Public Sub CargarSocia(ByVal intDetalleFNCID As Integer)
        Try
            Dim Strsql As String = ""
            If intDetalleFNCID = 0 Then
                'Socias de la Ficha con Credito Aprobado y a�n NO contenidas en la Reestructuraci�n:
                Strsql = " SELECT DFNC.nSclFichaNotificacionDetalleID, S.sNumeroCedula,  S.sNombre1 + ' ' + S.sNombre2 + ' ' + S.sApellido1 + ' ' + S.sApellido2 AS NombreSocia, DFNC.nStbTipoPlazoAprobadoID " & _
                         " FROM SclFichaSocia AS FS INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FS.nSclFichaSociaID = DFNC.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                         " WHERE  (DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (DFNC.nCreditoRechazado = 0) " & _
                         " AND (NOT (DFNC.nSclFichaNotificacionDetalleID IN  (SELECT nSclFichaNotificacionDetalleID FROM SclReestructuracionDeudaDetalles WHERE (nSclReestructuracionDeudaID = " & Me.intReestructuracionID & ")))) " & _
                         " ORDER BY S.sNumeroCedula"
            Else
                'Socias de la Ficha con Credito Aprobado y a�n NO contenidas en la Reestructuraci�n:
                Strsql = " SELECT DFNC.nSclFichaNotificacionDetalleID, S.sNumeroCedula,  S.sNombre1 + ' ' + S.sNombre2 + ' ' + S.sApellido1 + ' ' + S.sApellido2 AS NombreSocia, DFNC.nStbTipoPlazoAprobadoID " & _
                         " FROM SclFichaSocia AS FS INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FS.nSclFichaSociaID = DFNC.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                         " WHERE  ((DFNC.nSclFichaNotificacionID = " & Me.intFichaID & ") AND (DFNC.nCreditoRechazado = 0) " & _
                         " AND (NOT (DFNC.nSclFichaNotificacionDetalleID IN  (SELECT nSclFichaNotificacionDetalleID FROM SclReestructuracionDeudaDetalles WHERE (nSclReestructuracionDeudaID = " & Me.intReestructuracionID & "))))) " & _
                         " Or (DFNC.nSclFichaNotificacionDetalleID = " & intDetalleFNCID & ") " & _
                         " ORDER BY S.sNumeroCedula"
            End If

            XdtSocia.ExecuteSql(Strsql)
            Me.cboSocia.DataSource = XdtSocia.Source

            Me.cboSocia.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("nStbTipoPlazoAprobadoID").Visible = False
            Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").Width = 110
            Me.cboSocia.Splits(0).DisplayColumns("NombreSocia").Width = 280

            Me.cboSocia.Columns("sNumeroCedula").Caption = "C�dula"
            Me.cboSocia.Columns("NombreSocia").Caption = "Nombre Socia"

            Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboSocia.Splits(0).DisplayColumns("NombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboSocia_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboSocia.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificaci�n en el M�dulo
    Private Sub cboSocia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSocia.TextChanged
        vbModifico = True
        txtNombreS.Text = cboSocia.Columns("NombreSocia").Value
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripci�n:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then

                'Guarda Encabezado de la FNC:
                SalvarReestructuracion()

                'Habilita la siguiente Pesta�a:
                Me.tabPResolucion.Enabled = True

                'Actualiza Etiqueta del C�digo de la FNC:
                Me.txtCodigo.Text = ObjReestructuraciondr.nCodigo
                Me.txtCodigoR.Text = ObjReestructuraciondr.nCodigo

                'Actualiza Estado:
                ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjReestructuraciondr.nStbEstadoReestructuracionID
                ObjEstadoDT.Retrieve()
                If ObjEstadoDT.Count > 0 Then
                    Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoR.Text = ObjEstadoDT.ValueField("sDescripcion")
                End If

                If Me.intReestructuracionID <> 0 Then
                    If MsgBox("�Desea Continuar Ingresando Datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    Else
                        ModoFrm = "UPD"
                        REM Se Posiciona sobre el registro Recien Ingresado:
                        ObjReestructuraciondr = ObjReestructuraciondt.Current
                        CargarResolucionCredito()
                        FormatoResolucionCredito()
                        Me.tabPResolucion.Show()
                    End If
                Else
                    AccionUsuario = AccionBoton.BotonAceptar
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripci�n:          Esta funci�n permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errReestructuracion.Clear()

            'Fecha de Reestructuraci�n del Cr�dito V�lida:
            If Me.cdeFechaReestructuracion.ValueIsDbNull Then
                MsgBox("Fecha de Reestructuraci�n del Cr�dito Inv�lida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errReestructuracion.SetError(Me.cdeFechaReestructuracion, "La Fecha de Reestructuraci�n del Cr�dito NO DEBE quedar vac�a.")
                Me.cdeFechaReestructuracion.Focus()
                Exit Function
            End If

            'Fecha de Reestructuraci�n no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaReestructuracion.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Reestructuraci�n NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errReestructuracion.SetError(Me.cdeFechaReestructuracion, "La Fecha de Reestructuraci�n NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaReestructuracion.Focus()
                Exit Function
            End If

            'Fecha de Reestructuraci�n no mayor que la fecha de corte en par�metros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaReestructuracion.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Reestructuraci�n NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en par�metros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errReestructuracion.SetError(Me.cdeFechaReestructuracion, "La Fecha de Reestructuraci�n NO DEBE ser mayor a la de corte en par�metros.")
                Me.cdeFechaReestructuracion.Focus()
                Exit Function
            End If

            'Fecha debe ser superior a la Ultima Reestructuraci�n ACTIVA:
            strSQL = " SELECT  SclReestructuracionDeuda.nSclReestructuracionDeudaID " & _
                     " FROM  SclReestructuracionDeuda INNER JOIN StbValorCatalogo ON SclReestructuracionDeuda.nStbEstadoReestructuracionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (SclReestructuracionDeuda.nSclFichaNotificacionID = " & Me.intSclFichaID & ") AND (StbValorCatalogo.sCodigoInterno <> '3') " & _
                     " AND (SclReestructuracionDeuda.nSclReestructuracionDeudaID <> " & Me.intSclReestructuracionID & ")"
            If RegistrosAsociados(strSQL) Then
                strSQL = " SELECT SclReestructuracionDeuda.dFechaReestructuracion " & _
                         " FROM (SELECT MAX(nSclReestructuracionDeudaID) AS Id " & _
                         " FROM (SELECT R.nSclReestructuracionDeudaID, R.dFechaReestructuracion FROM SclReestructuracionDeuda AS R INNER JOIN StbValorCatalogo AS C ON R.nStbEstadoReestructuracionID = C.nStbValorCatalogoID " & _
                         " WHERE (R.nSclFichaNotificacionID = " & Me.intSclFichaID & ") AND (C.sCodigoInterno <> '3') AND (R.nSclReestructuracionDeudaID <> " & Me.intSclReestructuracionID & ")) AS a) AS b INNER JOIN SclReestructuracionDeuda ON b.Id = SclReestructuracionDeuda.nSclReestructuracionDeudaID"
                dFechaAnterior = XcDatos.ExecuteScalar(strSQL)
                If Format(Me.cdeFechaReestructuracion.Value, "yyyy-MM-dd") <= dFechaAnterior Then
                    MsgBox("Fecha de Reestructuraci�n DEBE ser superior a fecha" & Chr(13) & "de la Ultima Reestructuraci�n ACTIVA (" & dFechaAnterior & ")" & Chr(13) & "para la Ficha de Notificaci�n.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errReestructuracion.SetError(Me.cdeFechaReestructuracion, "Fecha de Reestructuraci�n Inv�lida.")
                    Me.cdeFechaReestructuracion.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       SalvarReestructuracion
    ' Descripci�n:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Reestructuraci�n de la Deuda.
    '-------------------------------------------------------------------------
    Private Sub SalvarReestructuracion()
        Dim ObjTmpReestructuracion As New BOSistema.Win.XDataSet
        Dim XcEstado As New BOSistema.Win.XComando

        Try
            Dim strSQL As String

            'Actualiza usuario y fecha de creaci�n:
            If ModoForm = "ADD" Then
                ObjReestructuraciondr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjReestructuraciondr.dFechaCreacion = FechaServer()
                'Estado de la Reestructuraci�n En Proceso:
                strSQL = " SELECT a.nStbValorCatalogoID FROM  StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE (b.sNombre = 'EstadoReestructuracion') AND (a.sCodigoInterno = '1') "
                ObjReestructuraciondr.nStbEstadoReestructuracionID = XcEstado.ExecuteScalar(strSQL)
                'Id de la Ficha de Notificaci�n:
                ObjReestructuraciondr.nSclFichaNotificacionID = Me.intFichaID
            Else
                ObjReestructuraciondr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjReestructuraciondr.dFechaModificacion = FechaServer()
            End If

            'Fecha de Reestructuraci�n:
            ObjReestructuraciondr.dFechaReestructuracion = Format(Me.cdeFechaReestructuracion.Value, "yyyy-MM-dd")

            'Observaciones:
            If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                ObjReestructuraciondr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
            Else
                ObjReestructuraciondr.SetFieldNull("sObservaciones")
            End If

            'Asignaci�n del C�digo siguiente de la Reestructuraci�n para la FNC:
            If ModoForm = "ADD" Then
                strSQL = " SELECT max(nCodigo) as maxCodigo FROM SclReestructuracionDeuda WHERE (nSclFichaNotificacionID = " & Me.intFichaID & ")"
                If ObjTmpReestructuracion.ExistTable("CodigoR") Then
                    ObjTmpReestructuracion("CodigoR").ExecuteSql(strSQL)
                Else
                    ObjTmpReestructuracion.NewTable(strSQL, "CodigoR")
                    ObjTmpReestructuracion("CodigoR").Retrieve()
                End If

                If Not ObjTmpReestructuracion("CodigoR").ValueField("maxCodigo") Is DBNull.Value Then
                    Me.txtCodigo.Text = Format(ObjTmpReestructuracion("CodigoR").ValueField("maxCodigo") + 1) ', "00"
                Else
                    Me.txtCodigo.Text = "1"
                End If
            End If

            'Codigo: 
            ObjReestructuraciondr.nCodigo = Me.txtCodigo.Text

            ObjReestructuraciondr.Update()
            'Asignar el Id de la Reestructuraci�n  a la variable publica del formulario:
            intSclReestructuracionID = ObjReestructuraciondr.nSclReestructuracionDeudaID
            '--------------------------------

            'Si el salvado se realiz� de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 23, "Modificaci�n de Reestructuraci�n de deuda ID:" & Me.intSclReestructuracionID & ".")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpReestructuracion.Close()
            ObjTmpReestructuracion = Nothing

            XcEstado.Close()
            XcEstado = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripci�n:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Declaracion de Variables 
            Dim res As Object
            Dim strSQL As String

            strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoReestructuracion' "

            If (vbModifico = True) And (ObjReestructuraciondr.nStbEstadoReestructuracionID = XcDatos.ExecuteScalar(strSQL)) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarReestructuracion()
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
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    'Se indica que hubo modificaci�n en la Observaci�n:
    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub


    'En caso que haya habido alg�n cambio
    Private Sub cdeFechaReestructuracion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaReestructuracion.TextChanged
        vbModifico = True
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       LlamaAyuda
    ' Descripci�n:          Este procedimiento permite presentar la Ayuda en
    '                       L�nea al usuario. Actualmente en Construcci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            MsgBox("En construcci�n", MsgBoxStyle.Information, NombreSistema)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#Region "Detalle Resoluci�n Cr�dito"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       CargarResolucionCredito
    ' Descripci�n:          Este procedimiento permite cargar los datos de las 
    '                       Resoluciones Crediticias en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarResolucionCredito()
        Try
            Dim Strsql As String
            Me.grdResolucion.ClearFields()

            Strsql = " Select a.nSclFichaNotificacionDetalleID, a.nSclReestructuracionDeudaDetalleID, a.nSclReestructuracionDeudaID, a.nSclFichaSociaID, " & _
                     " a.nCodigo, a.NombreSocia, a.nCoordinador, a.sNumeroCedula, a.nMontoCredito, a.nPlazoAprobado, a.nNumeroUltimoCuota, a.sTipoPlazo, a.dFechaPrimerCuota " & _
                     " From vwSclReestructuracionDetalles a " & _
                     " Where (a.nSclReestructuracionDeudaID = " & Me.intReestructuracionID & ") " & _
                     " Order By a.nCoordinador Desc, a.nSclFichaSociaID "
            If XdsDetalle.ExistTable("Resolucion") Then
                XdsDetalle("Resolucion").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Resolucion")
                XdsDetalle("Resolucion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdResolucion.DataSource = XdsDetalle("Resolucion").Source
            'Refresh Grid.
            Me.grdResolucion.Rebind(False)
            Me.grdResolucion.FetchRowStyles = True
            Me.grdResolucion.Caption = " Resoluci�n de Reestructuraci�n de Cr�ditos a Socias (" + Me.grdResolucion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       FormatoResolucionCredito
    ' Descripci�n:          Este procedimiento permite configurar los datos
    '                       sobre Resoluciones de Cr�dito en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoResolucionCredito()
        Try

            'Configuracion del Grid: 
            Me.grdResolucion.Splits(0).DisplayColumns("nSclReestructuracionDeudaDetalleID").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("nSclReestructuracionDeudaID").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("nSclFichaSociaID").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("sTipoPlazo").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("nCodigo").Visible = False
            Me.grdResolucion.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False

            'Pie del Grid para totalizar Monto Reestructurado:
            Me.grdResolucion.ColumnFooters = True
            Me.grdResolucion.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCredito").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCredito").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCredito").FooterStyle.ForeColor = Color.Blue
            Me.grdResolucion.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdResolucion.Splits(0).DisplayColumns("NombreSocia").Width = 180
            Me.grdResolucion.Splits(0).DisplayColumns("nCoordinador").Width = 75
            Me.grdResolucion.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdResolucion.Splits(0).DisplayColumns("nNumeroUltimoCuota").Width = 120
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCredito").Width = 120
            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoAprobado").Width = 100
            Me.grdResolucion.Splits(0).DisplayColumns("dFechaPrimerCuota").Width = 100

            Me.grdResolucion.Columns("NombreSocia").Caption = "Nombre Socia"
            Me.grdResolucion.Columns("nCoordinador").Caption = "Coordinadora"
            Me.grdResolucion.Columns("nCoordinador").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdResolucion.Columns("sNumeroCedula").Caption = "C�dula Socia"
            Me.grdResolucion.Columns("nMontoCredito").Caption = "M. Reestructurado C$"
            Me.grdResolucion.Columns("nPlazoAprobado").Caption = "Plazo (" & Me.grdResolucion.Columns("sTipoPlazo").Value & ")"
            Me.grdResolucion.Columns("nNumeroUltimoCuota").Caption = "Ultima Cuota Pagada"
            Me.grdResolucion.Columns("dFechaPrimerCuota").Caption = "Fecha Primer Pago"

            Me.grdResolucion.Splits(0).DisplayColumns.Item("nMontoCredito").Style.BackColor = Color.WhiteSmoke

            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nCoordinador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("dFechaPrimerCuota").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdResolucion.Splits(0).DisplayColumns("NombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nCoordinador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nNumeroUltimoCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nMontoCredito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("nPlazoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdResolucion.Splits(0).DisplayColumns("dFechaPrimerCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdResolucion.Columns("nMontoCredito").NumberFormat = "#,##0.00"

            'Calcular montos totales de cr�dito Reestructurado:
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       CalcularMontos
    ' Descripci�n:          Este procedimiento permite Calcular el Monto
    '                       Total de Cr�dito Autorizado.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalAprobado As Double = 0

            For index As Integer = 0 To Me.grdResolucion.RowCount - 1
                Me.grdResolucion.Row = index
                vTotalAprobado = vTotalAprobado + Me.grdResolucion.Columns("nMontoCredito").Value
            Next
            If Me.grdResolucion.RowCount > 0 Then
                Me.grdResolucion.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdResolucion.Columns("nMontoCredito").FooterText = Format(vTotalAprobado, "C$ #,##0.00")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       tbResolucion_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbResolucion.
    '-------------------------------------------------------------------------
    Private Sub tbResolucion_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbResolucion.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolAgregarR"
                LlamaAgregarR()
            Case "toolModificarR"
                LlamaModificarR()
            Case "toolEliminarR"
                LlamaEliminarR()
            Case "toolRefrescarR"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdResolucion.ClearFields()
                CargarResolucionCredito()
                FormatoResolucionCredito()
            Case "toolAyudaR"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       LlamaAgregarR
    ' Descripci�n:          Este procedimiento ingresar Detalles de la
    '                       Reestructuraci�n de Cr�dito por Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarR()
        Try

            'Prepara Ambiente para Adici�n:
            grpReestructuracionSocia.Visible = True
            tbResolucion.Enabled = False
            Me.tabPDatosGrales.Enabled = False
            Me.CmdActualizar.Tag = "ADD"

            'Limpiar Datos para Adici�n:
            CargarSocia(0)
            Me.cboSocia.Text = ""
            Me.txtNombreS.Text = ""
            Me.cneMontoAprobado.Value = 0
            Me.cnePlazoAprobado.Value = 0
            Me.cneUltimaCuota.Value = 0
            Me.cdeFechaPrimerPago.Value = FechaServer()
            Me.errReestructuracion.Clear()
            cboSocia.Focus()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       LlamaModificarR
    ' Descripci�n:          Este procedimiento permite llamar Modificar 
    '                       un detalle de Reestructuraci�n de Cr�dito.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarR()
        Try
            'Imposible si no existen registros:
            If Me.grdResolucion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Prepara Ambiente para actualizaci�n:
            grpReestructuracionSocia.Visible = True
            tbResolucion.Enabled = False
            Me.tabPDatosGrales.Enabled = False
            Me.CmdActualizar.Tag = "UPD"

            'Ubicar Datos de la Reestructuraci�n:
            CargarSocia(XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID"))
            If XdtSocia.Count > 0 Then
                Me.cboSocia.SelectedIndex = 0
            End If
            XdtSocia.SetCurrentByID("nSclFichaNotificacionDetalleID", XdsDetalle("Resolucion").ValueField("nSclFichaNotificacionDetalleID"))

            Me.cneUltimaCuota.Value = XdsDetalle("Resolucion").ValueField("nNumeroUltimoCuota")
            Me.cneMontoAprobado.Value = XdsDetalle("Resolucion").ValueField("nMontoCredito")
            Me.cnePlazoAprobado.Value = CInt(XdsDetalle("Resolucion").ValueField("nPlazoAprobado"))
            Me.cdeFechaPrimerPago.Value = XdsDetalle("Resolucion").ValueField("dFechaPrimerCuota")
            Me.errReestructuracion.Clear()
            cboSocia.Focus()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       LlamaEliminarR
    ' Descripci�n:          Este procedimiento permite eliminar un registro
    '                       de una Reestructuraci�n Crediticia existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarR()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            If Me.grdResolucion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("�Est� seguro de eliminar a la Socia seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
                XcDatos.ExecuteNonQuery("Delete From SclReestructuracionDeudaDetalles where nSclReestructuracionDeudaDetalleID =" & XdsDetalle("Resolucion").ValueField("nSclReestructuracionDeudaDetalleID"))
                CargarResolucionCredito()
                FormatoResolucionCredito()
                MsgBox("El registro se elimin� satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdResolucion.Caption = " Resoluci�n de Reestructuraci�n de Cr�ditos a Socias (" + Me.grdResolucion.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                28/03/2008
    ' Procedure Name:       grdResolucion_DoubleClick
    ' Descripci�n:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Reestructuraci�n existente, al hacer 
    '                       doble click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdResolucion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdResolucion.DoubleClick
        Try
            LlamaModificarR()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdResolucion_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdResolucion.Error
        Control_Error(e.Exception)
    End Sub

    'Sirve para realizar el filtro de la condici�n introducida en la Barra de Filtro
    Private Sub grdReferencia_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdResolucion.Filter
        Try
            XdsDetalle("Resoluci�n").FilterLocal(e.Condition)
            Me.grdResolucion.Caption = " Resoluci�n de Reestructuraci�n de Cr�ditos a Socias (" + Me.grdResolucion.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
#End Region
End Class