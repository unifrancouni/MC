Public Class frmSteEditSolicitudCajaCHicaDetalle

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim intFichaID As Long
    Dim intSolicitudID As Long
    Dim intNumRecibo As Integer
    Dim dFechaEmisionRec As Date

    '-- Clases para procesar la informacion de los combos
    Dim XdsEmpleado As BOSistema.Win.XDataSet
    Dim XdtFuente As BOSistema.Win.XDataSet.xDataTable
    Dim XdtTipoImpuesto As BOSistema.Win.XDataSet.xDataTable
    Dim XdtTipoImpuestoIVA As BOSistema.Win.XDataSet.xDataTable
    Dim XdtTipoImpuestoALCALDIA As BOSistema.Win.XDataSet.xDataTable

    Dim strFechaSolicita As String
    Dim dFechaEmision As String

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    'Dim ObjSolicituddt As BOSistema.Win.SccEntCredito.SccSolicitudDesembolsoCreditoDataTable
    'Dim ObjSolicituddr As BOSistema.Win.SccEntCredito.SccSolicitudDesembolsoCreditoRow

    Dim ObjSolicituddt As BOSistema.Win.SteEntProveedor.SteSolicitudCajaChicaDetalleDataTable
    Dim ObjSolicituddr As BOSistema.Win.SteEntProveedor.SteSolicitudCajaChicaDetalleRow


    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para obtener el ID de una de las Solicitudes de Desembolso 
    'en caso de Edición:
    Public Property intSccSolicitudID() As Long
        Get
            intSccSolicitudID = intSolicitudID
        End Get
        Set(ByVal value As Long)
            intSolicitudID = value
        End Set
    End Property

    'Propiedad utilizada para obtener Fecha de Emision  del Recibo:
    'en caso de Adición:
    Public Property dSccFechaRec() As Date
        Get
            dSccFechaRec = dFechaEmisionRec
        End Get
        Set(ByVal value As Date)
            dFechaEmisionRec = value
        End Set
    End Property

    Public Property nNumeroRecibo As Integer
        Get
            nNumeroRecibo = intNumRecibo
        End Get
        Set(ByVal value As Integer)
            intNumRecibo = value
        End Set
    End Property


    Dim IdSccSolicitudCajaChica As Long
    Dim IntHabilitar As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdtFuenteFondos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtTipoSolicitud As BOSistema.Win.XDataSet.xDataTable
    Dim XdtBeneficiario As BOSistema.Win.XDataSet.xDataTable
    Dim XdtEmpleado As BOSistema.Win.XDataSet.xDataTable



    Dim sColor As String
    ' ''Dim TipoChkAgregar As Integer
    'Color a mostrarse en el formulario
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property

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

    Public Property IntHabilito() As Integer
        Get
            IntHabilito = IntHabilitar
        End Get
        Set(ByVal value As Integer)
            IntHabilitar = value
        End Set
    End Property

    Private Sub frmSteEditSolicitudCajaCHicaDetalle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjSolicituddt.Close()
                ObjSolicituddt = Nothing

                ObjSolicituddr.Close()
                ObjSolicituddr = Nothing

                XdsEmpleado.Close()
                XdsEmpleado = Nothing

                XdtBeneficiario.Close()
                XdtBeneficiario = Nothing

                XdtFuente.Close()
                XdtFuente = Nothing

                XdtTipoImpuesto.Close()
                XdtTipoImpuestoIVA.Close()



                XdtTipoImpuestoALCALDIA.Close()

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub frmSteEditSolicitudCajaCHicaDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFirmas(0, 0, "FirmaElabora")
            CargarFirmas(0, 104, "FirmaTres")
            CargarFuente(0)
            Me.CargarBeneficiario(0)
            Me.CargarTipoImpuesto(0)
            Me.CargarTipoImpuestoIVA(0)
            Me.CargarTipoImpuestoALCALDIA(0)

            If ModoForm = "ADD" Then
                cdeFechaSolicita.Value = FechaServer()
                Me.cdeFechaEmision.Value = FechaServer()
                Me.cneMontoIREXENTO.Value = 0
                Me.cneMontoIVAEXENTO.Value = 0
                Me.cneMontoALCALDIAEXENTO.Value = 0
            End If


            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm = "UPD" Then
                CargarSolicitud()
                InhabilitarControles()
            End If

            Me.cdeFechaSolicita.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub InhabilitarControles()
        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Si la Solicitud no se encuentra en Proceso:
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoDesembolsoProveedores' "
            If ObjSolicituddr.nStbEstadoSolicitudID <> XcDatos.ExecuteScalar(Strsql) Then
                Me.cmdAceptar.Enabled = False
                Me.grpGenerales.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Solicitud de Pago Caja Chica"
            Else
                Me.Text = "Modificar Solicitud de Pago Caja Chica"
            End If

            ObjSolicituddt = New BOSistema.Win.SteEntProveedor.SteSolicitudCajaChicaDetalleDataTable
            ObjSolicituddr = New BOSistema.Win.SteEntProveedor.SteSolicitudCajaChicaDetalleRow

            XdsEmpleado = New BOSistema.Win.XDataSet
            XdtFuente = New BOSistema.Win.XDataSet.xDataTable
            XdtTipoImpuesto = New BOSistema.Win.XDataSet.xDataTable
            XdtTipoImpuestoIVA = New BOSistema.Win.XDataSet.xDataTable
            XdtTipoImpuestoALCALDIA = New BOSistema.Win.XDataSet.xDataTable

            XdtBeneficiario = New BOSistema.Win.XDataSet.xDataTable


            'Limpiar los combos:
            Me.cboFirmaE.ClearFields()
            Me.cboFirmaA.ClearFields()
            Me.cboFuente.ClearFields()
            Me.cboIR.ClearFields()
            Me.cboIVA.ClearFields()

            cdeFechaEmision.Value = dFechaEmisionRec

            If ModoForm = "ADD" Then
                ObjSolicituddr = ObjSolicituddt.NewRow
                'Inicializar los Length de los campos (Strings?)
                Me.txtObservacion.MaxLength = ObjSolicituddr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarSolicitud()
        Try

            '-- Buscar la Solicitud correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjSolicituddt.Filter = "nSteSolicitudCajaChicaDetalleID = " & intSccSolicitudID
            ObjSolicituddt.Retrieve()
            If ObjSolicituddt.Count = 0 Then
                Exit Sub
            End If
            ObjSolicituddr = ObjSolicituddt.Current 'Solicitud actual.

            'Fecha Solicitud:
            If Not ObjSolicituddr.IsFieldNull("dFechaSolicita") Then
                Me.cdeFechaSolicita.Value = ObjSolicituddr.dFechaSolicita
            Else
                Me.cdeFechaSolicita.Value = Me.cdeFechaSolicita.ValueIsDbNull
            End If

            'Fecha Desembolso:
            If Not ObjSolicituddr.IsFieldNull("dFechaEmision") Then
                Me.cdeFechaEmision.Value = ObjSolicituddr.dFechaEmision
            Else
                Me.cdeFechaEmision.Value = Me.cdeFechaSolicita.ValueIsDbNull
            End If


            'Impuesto IR:
            If Not ObjSolicituddr.IsFieldNull("nStbTipoImpuestoID") Then
                CargarTipoImpuesto(ObjSolicituddr.nStbTipoImpuestoID)

                If cboIR.ListCount > 0 Then
                    Me.cboIR.SelectedIndex = 0
                End If

                XdtTipoImpuesto.SetCurrentByID("nStbTipoImpuestoID", ObjSolicituddr.nStbTipoImpuestoID)
            Else
                Me.cboIR.Text = ""
                Me.cboIR.SelectedIndex = -1
            End If



            'Impuesto IVA:
            If Not ObjSolicituddr.IsFieldNull("nStbTipoIVAID") Then
                CargarTipoImpuestoIVA(ObjSolicituddr.nStbTipoIVAID)

                If cboIVA.ListCount > 0 Then
                    Me.cboIVA.SelectedIndex = 0
                End If

                XdtTipoImpuestoIVA.SetCurrentByID("nStbTipoImpuestoID", ObjSolicituddr.nStbTipoIVAID)
            Else
                Me.cboIVA.Text = ""
                Me.cboIVA.SelectedIndex = -1
            End If


            'Impuesto ALCALDIA:
            If Not ObjSolicituddr.IsFieldNull("nStbTipoALCALDIAID") Then
                CargarTipoImpuestoALCALDIA(ObjSolicituddr.nStbTipoALCALDIAID)

                If cboALCALDIA.ListCount > 0 Then
                    Me.cboALCALDIA.SelectedIndex = 0
                End If

                XdtTipoImpuestoALCALDIA.SetCurrentByID("nStbTipoImpuestoID", ObjSolicituddr.nStbTipoALCALDIAID)
            Else
                Me.cboALCALDIA.Text = ""
                Me.cboALCALDIA.SelectedIndex = -1
            End If



            'Empleado Elabora:
            If Not ObjSolicituddr.IsFieldNull("nSrhEmpleadoElaboraID") Then
                If Me.cboFirmaE.ListCount > 0 Then
                    Me.cboFirmaE.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaElabora").SetCurrentByID("nSrhEmpleadoID", ObjSolicituddr.nSrhEmpleadoElaboraID)
            Else
                Me.cboFirmaE.Text = ""
                Me.cboFirmaE.SelectedIndex = -1
            End If

            'Tercer Firma (Empleado de Comité de Crédito):
            If Not ObjSolicituddr.IsFieldNull("nSrhEmpleadoAutorizaID") Then
                If Me.cboFirmaA.ListCount > 0 Then
                    Me.cboFirmaA.SelectedIndex = 0
                End If
                XdsEmpleado("FirmaTres").SetCurrentByID("nSrhEmpleadoID", ObjSolicituddr.nSrhEmpleadoAutorizaID)
            Else
                Me.cboFirmaA.Text = ""
                Me.cboFirmaA.SelectedIndex = -1
            End If



            If Not ObjSolicituddr.IsFieldNull("sNumCedula") Then
                Me.txtCedula.Text = ObjSolicituddr.sNumCedula
            Else
                Me.txtCedula.Text = ""
            End If

            If Not ObjSolicituddr.IsFieldNull("sNumRUC") Then
                Me.txtNORUC.Text = ObjSolicituddr.sNumRUC
            Else
                Me.txtNORUC.Text = ""
            End If

            If Not ObjSolicituddr.IsFieldNull("sDireccion") Then
                Me.txtdireccion.Text = ObjSolicituddr.sDireccion
            Else
                Me.txtdireccion.Text = ""
            End If


            If Not ObjSolicituddr.IsFieldNull("sConceptoPago") Then
                Me.txtConcepto.Text = ObjSolicituddr.sConceptoPago
            Else
                Me.txtConcepto.Text = ""
            End If

            'Observaciones:
            If Not ObjSolicituddr.IsFieldNull("sObservaciones") Then
                Me.txtObservacion.Text = ObjSolicituddr.sObservaciones
            Else
                Me.txtObservacion.Text = ""
            End If


            'Beneficiario:
            If Not ObjSolicituddr.IsFieldNull("nStbPersonaBeneficiariaID") Then
                Me.CargarBeneficiario(ObjSolicituddr.nStbPersonaBeneficiariaID)


                If Me.cboBeneficiario.ListCount > 0 Then
                    Me.cboBeneficiario.SelectedIndex = 0
                End If


                XdtBeneficiario.SetCurrentByID("nStbPersonaID", ObjSolicituddr.nStbPersonaBeneficiariaID)
            Else
                Me.cboBeneficiario.Text = ""
                Me.cboBeneficiario.SelectedIndex = -1
            End If


            'Los montos

            If Not ObjSolicituddr.IsFieldNull("nMontoPago") Then
                Me.cneMonto.Value = ObjSolicituddr.nMontoPago - ObjSolicituddr.nMontoIVA + ObjSolicituddr.nMontoRetencion + ObjSolicituddr.nMontoALCALDIA
            Else
                Me.cneMonto.Value = 0
            End If

            If Not ObjSolicituddr.IsFieldNull("nMontoRetencion") Then
                Me.cneMontoIR.Value = ObjSolicituddr.nMontoRetencion
            Else
                Me.cneMontoIR.Value = 0
            End If

            If Not ObjSolicituddr.IsFieldNull("nMontoIVA") Then
                Me.cneMontoIVA.Value = ObjSolicituddr.nMontoIVA
            Else
                Me.cneMontoIVA.Value = 0
            End If

            If Not ObjSolicituddr.IsFieldNull("nMontoALCALDIA") Then
                Me.cneMontoALCALDIA.Value = ObjSolicituddr.nMontoALCALDIA
            Else
                Me.cneMontoALCALDIA.Value = 0
            End If


            If Not ObjSolicituddr.IsFieldNull("nMontoIRExento") Then
                Me.cneMontoIREXENTO.Value = ObjSolicituddr.nMontoIRExento
            Else
                Me.cneMontoIREXENTO.Value = 0
            End If


            If Not ObjSolicituddr.IsFieldNull("nMontoIVAExento") Then
                Me.cneMontoIVAEXENTO.Value = ObjSolicituddr.nMontoIVAExento
            Else
                Me.cneMontoIVAEXENTO.Value = 0
            End If

            If Not ObjSolicituddr.IsFieldNull("nMontoALCALDIAExento") Then
                Me.cneMontoALCALDIAEXENTO.Value = ObjSolicituddr.nMontoALCALDIAExento
            Else
                Me.cneMontoALCALDIAEXENTO.Value = 0
            End If


            MontoTotal()

            If Not ObjSolicituddr.IsFieldNull("nCodigo") Then
                Me.txtnCodigo.Text = ObjSolicituddr.nCodigo
            Else
                Me.txtnCodigo.Text = ""
            End If

            If Not ObjSolicituddr.IsFieldNull("nNumeroRecibo") Then
                Me.txtnRecibo.Text = ObjSolicituddr.nNumeroRecibo
            Else
                Me.txtnRecibo.Text = ""
            End If
            'Inicializar los Length de los campos:
            Me.txtObservacion.MaxLength = ObjSolicituddr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarFuente(ByVal intFuenteID As Integer)
        Try
            Dim Strsql As String = ""

            '-- Temporal solo permitir seleccionar nueva Fuente de Fondos: BANDES, VENTANA, FONDOS PROPIOS
            If intFuenteID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " &
                         " From ScnFuenteFinanciamiento a " &
                         " Where (a.nActiva = 1) And (a.nScnFuenteFinanciamientoID > 5) " &
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " &
                         " From ScnFuenteFinanciamiento a " &
                         " Where (a.nActiva = 1 And a.nScnFuenteFinanciamientoID > 5) Or (a.nScnFuenteFinanciamientoID = " & intFuenteID & ") " &
                         " Order by a.sCodigo"
            End If

            XdtFuente.ExecuteSql(Strsql)
            Me.cboFuente.DataSource = XdtFuente.Source

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


    Private Sub CargarFirmas(ByVal intEmpleadoID As Integer, ByVal intParametroID As Integer, ByVal StrNombre As String)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Dim XdtDelegacion As New BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaDataTable
        Try

            Dim Strsql As String

            If intParametroID = 0 Then
                Me.cboFirmaE.ClearFields()
            Else
                Me.cboFirmaA.ClearFields()
            End If

            If intParametroID = 0 Then 'Solo jefes de tesoreria contabilidad admon y principal del programa
                If intEmpleadoID = 0 Then
                    Strsql = " Select * " &
                             " From vwStbEmpleadoElaboraSolicitudes " &
                              " Where nCajaChica= 1 and nActivo=1" &
                             " Order by nCodPersona"
                Else
                    Strsql = " Select * " &
                             " From vwStbEmpleadoElaboraSolicitudes " &
                             " Where nCajachica= 1 and nActivo=1 " &
                             " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " &
                             " Order by nCodPersona"
                End If
            Else
                If intEmpleadoID = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " &
                             " From vwStbEmpleado a " &
                             " Where (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " &
                             " Order by a.nCodPersona"
                Else
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " &
                             " From vwStbEmpleado a " &
                             " Where ((a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " &
                             " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " &
                             " Order by a.nCodPersona"
                End If
            End If



            If XdsEmpleado.ExistTable(StrNombre) Then
                XdsEmpleado(StrNombre).ExecuteSql(Strsql)
            Else
                XdsEmpleado.NewTable(Strsql, StrNombre)
                XdsEmpleado(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos
            If intParametroID = 0 Then
                Me.cboFirmaE.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboFirmaE.Rebind()
            Else
                Me.cboFirmaA.DataSource = XdsEmpleado(StrNombre).Source
                Me.cboFirmaA.Rebind()
            End If

            'Ubicarse en el registro recomendado de parámetros:
            If intParametroID <> 0 Then

                XdtValorParametro.Filter = "nStbParametroID = " & intParametroID
                XdtValorParametro.Retrieve()

                If XdsEmpleado(StrNombre).Count > 0 Then
                    XdsEmpleado(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorParametro.ValueField("sValorParametro"))
                End If

                ''Con base en la delegacion:
                'XdtDelegacion.Filter = " nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion
                'XdtDelegacion.Retrieve()
                'XdsEmpleado(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtDelegacion.ValueField("nSrhEmpleadoFirmaCComiteID"))
            End If

            'Confugurar el combo:
            If intParametroID = 0 Then
                Me.cboFirmaE.SelectedIndex = 0
                Me.cboFirmaE.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("nProveedor").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("nActivo").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("nSrhCargoID").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("nSrhEmpleadoElaboraSolicitudesID").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("nCajachica").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("sCodEmpleado").Visible = False
                Me.cboFirmaE.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaE.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirmaE.Splits(0).DisplayColumns("sNombre").Width = 200
                Me.cboFirmaE.Columns("nCodPersona").Caption = "Código"
                Me.cboFirmaE.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirmaE.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaE.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                Me.cboFirmaA.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirmaA.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaA.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirmaA.Splits(0).DisplayColumns("sNombre").Width = 200
                Me.cboFirmaA.Columns("nCodPersona").Caption = "Código"
                Me.cboFirmaA.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirmaA.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirmaA.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing

            XdtDelegacion.Close()
            XdtDelegacion = Nothing
        End Try
    End Sub


    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            Me.CalcularIR()
            Me.CalcularIVA()
            MontoTotal()
            If ValidaDatosEntrada() Then
                SalvarSolicitudes()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CargarBeneficiario(ByVal nStbPersonaBeneficiariaID As Integer)
        Try
            Dim Strsql As String = ""

            '-- Temporal solo permitir seleccionar nueva Fuente de Fondos: BANDES, VENTANA, FONDOS PROPIOS
            'If Me.ModoFrm = "ADD" Then
            '    Strsql = "SELECT     dbo.StbPersona.nStbPersonaID,   dbo.StbPersona.sNombre1 + ' ' + dbo.StbPersona.sNombre2 + ' ' + dbo.StbPersona.sApellido1RS + ' ' + dbo.StbPersona.sApellido2 AS NombreBeneficiario, dbo.StbPersona.sNumCedula, dbo.StbPersona.sNumRUC,dbo.StbPersona.sDireccion " & _
            '             "FROM  dbo.StbPersona " & _
            '            " WHERE   StbPersona.nPersonaActiva = 1" & _
            '             " Order by NombreBeneficiario"
            'Else

            '    Strsql = "SELECT     dbo.StbPersona.nStbPersonaID,   dbo.StbPersona.sNombre1 + ' ' + dbo.StbPersona.sNombre2 + ' ' + dbo.StbPersona.sApellido1RS + ' ' + dbo.StbPersona.sApellido2 AS NombreBeneficiario, dbo.StbPersona.sNumCedula, dbo.StbPersona.sNumRUC,dbo.StbPersona.sDireccion  " & _
            '             "FROM  dbo.StbPersona INNER JOIN  SteSolicitudCajaChicaDetalle on StbPersona.nStbPersonaID = dbo.SteSolicitudCajaChicaDetalle.nStbPersonaBeneficiariaID " & _
            '             " WHERE     StbPersona.nPersonaActiva = 1 and  dbo.StbPersona.nStbPersonaID = " & nStbPersonaBeneficiariaID & _
            '             " Order by NombreBeneficiario"
            'End If



            If Me.ModoFrm = "ADD" Then
                Strsql = "SELECT     dbo.StbPersona.nStbPersonaID, dbo.StbPersona.sNombre1, dbo.StbPersona.sNumCedula, dbo.StbPersonaDatoFiscal.sNumRUC,sDireccion " &
                         "FROM         dbo.StbPersona INNER JOIN  dbo.SrhProveedor ON dbo.StbPersona.nStbPersonaID = dbo.SrhProveedor.nStbPersonaID LEFT OUTER JOIN dbo.StbPersonaDatoFiscal ON dbo.StbPersona.nStbPersonaID = dbo.StbPersonaDatoFiscal.nStbPersonaID" &
                        " WHERE     (dbo.SrhProveedor.nActivo = 1)" &
                         " Order by sNombre1"
            Else

                Strsql = "SELECT     dbo.StbPersona.nStbPersonaID, dbo.StbPersona.sNombre1, dbo.StbPersona.sNumCedula, dbo.StbPersonaDatoFiscal.sNumRUC,sDireccion " &
         "FROM         dbo.StbPersona INNER JOIN  dbo.SrhProveedor ON dbo.StbPersona.nStbPersonaID = dbo.SrhProveedor.nStbPersonaID LEFT OUTER JOIN dbo.StbPersonaDatoFiscal ON dbo.StbPersona.nStbPersonaID = dbo.StbPersonaDatoFiscal.nStbPersonaID" &
        " WHERE     (dbo.SrhProveedor.nActivo = 1) OR dbo.StbPersona.nStbPersonaID = " & nStbPersonaBeneficiariaID &
         " Order by sNombre1"
            End If


            Me.XdtBeneficiario.ExecuteSql(Strsql)
            Me.cboBeneficiario.DataSource = XdtBeneficiario.Source

            Me.cboBeneficiario.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            Me.cboBeneficiario.Splits(0).DisplayColumns("sDireccion").Visible = False


            Me.cboBeneficiario.Splits(0).DisplayColumns("sNombre1").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNumCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNumRUC").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNombre1").Width = 200
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNumCedula").Width = 50
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNumRUC").Width = 50


            Me.cboBeneficiario.Columns("sNombre1").Caption = "Nombre"
            Me.cboBeneficiario.Columns("sNumCedula").Caption = "Cédula"
            Me.cboBeneficiario.Columns("sNumRUC").Caption = "RUC"

            Me.cboBeneficiario.Splits(0).DisplayColumns("sNombre1").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNumCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBeneficiario.Splits(0).DisplayColumns("sNumRUC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarTipoImpuestoALCALDIA(ByVal TipoIR As Integer)
        Try
            Dim Strsql As String = ""

            '-- Temporal solo permitir seleccionar nueva Fuente de Fondos: BANDES, VENTANA, FONDOS PROPIOS
            If Me.ModoFrm = "ADD" Then
                Strsql = " SELECT     nStbTipoImpuestoID, sDescripcion, nPorcentaje " &
                         "FROM         dbo.StbTipoImpuesto WHERE     (nEsIR = -1) AND (nActivo = 1) " &
                         " Order by nPorcentaje"
            Else

                Strsql = " SELECT     nStbTipoImpuestoID, sDescripcion, nPorcentaje " &
                         "FROM         dbo.StbTipoImpuesto WHERE     (nEsIR = -1) AND (nActivo = 1)  " &
                         " OR  nStbTipoImpuestoID = " & TipoIR & " Order by nPorcentaje"
            End If


            Me.XdtTipoImpuestoALCALDIA.ExecuteSql(Strsql)
            Me.cboALCALDIA.DataSource = XdtTipoImpuestoALCALDIA.Source

            Me.cboALCALDIA.Splits(0).DisplayColumns("nStbTipoImpuestoID").Visible = False

            Me.cboALCALDIA.Splits(0).DisplayColumns("sDescripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboALCALDIA.Splits(0).DisplayColumns("nPorcentaje").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboALCALDIA.Splits(0).DisplayColumns("sDescripcion").Width = 50
            Me.cboALCALDIA.Splits(0).DisplayColumns("nPorcentaje").Width = 50

            Me.cboALCALDIA.Columns("sDescripcion").Caption = "Descripción"
            Me.cboALCALDIA.Columns("nPorcentaje").Caption = "Porcentaje"

            Me.cboALCALDIA.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboALCALDIA.Splits(0).DisplayColumns("nPorcentaje").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarTipoImpuesto(ByVal TipoIR As Integer)
        Try
            Dim Strsql As String = ""

            '-- Temporal solo permitir seleccionar nueva Fuente de Fondos: BANDES, VENTANA, FONDOS PROPIOS
            If Me.ModoFrm = "ADD" Then
                Strsql = " SELECT     nStbTipoImpuestoID, sDescripcion, nPorcentaje " &
                         "FROM         dbo.StbTipoImpuesto WHERE     (nEsIR = 1) AND (nActivo = 1) " &
                         " Order by nPorcentaje"
            Else

                Strsql = " SELECT     nStbTipoImpuestoID, sDescripcion, nPorcentaje " &
                         "FROM         dbo.StbTipoImpuesto WHERE     (nEsIR = 1) AND (nActivo = 1)  " &
                         " OR  nStbTipoImpuestoID = " & TipoIR & " Order by nPorcentaje"
            End If


            Me.XdtTipoImpuesto.ExecuteSql(Strsql)
            Me.cboIR.DataSource = XdtTipoImpuesto.Source

            Me.cboIR.Splits(0).DisplayColumns("nStbTipoImpuestoID").Visible = False

            Me.cboIR.Splits(0).DisplayColumns("sDescripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboIR.Splits(0).DisplayColumns("nPorcentaje").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboIR.Splits(0).DisplayColumns("sDescripcion").Width = 50
            Me.cboIR.Splits(0).DisplayColumns("nPorcentaje").Width = 50

            Me.cboIR.Columns("sDescripcion").Caption = "Descripción"
            Me.cboIR.Columns("nPorcentaje").Caption = "Porcentaje"

            Me.cboIR.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboIR.Splits(0).DisplayColumns("nPorcentaje").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarTipoImpuestoIVA(ByVal TipoIVA As Integer)
        Try
            Dim Strsql As String = ""

            '-- Temporal solo permitir seleccionar nueva Fuente de Fondos: BANDES, VENTANA, FONDOS PROPIOS
            If Me.ModoFrm = "ADD" Then
                Strsql = " SELECT     nStbTipoImpuestoID, sDescripcion, nPorcentaje " &
                         "FROM         dbo.StbTipoImpuesto WHERE     (nEsIR = 0) AND (nActivo = 1) " &
                         " Order by nPorcentaje"
            Else

                Strsql = " SELECT     nStbTipoImpuestoID, sDescripcion, nPorcentaje " &
                         "FROM         dbo.StbTipoImpuesto WHERE     (nEsIR = 0) AND (nActivo = 1)  " &
                         " OR  nStbTipoImpuestoID = " & TipoIVA & " Order by nPorcentaje"
            End If


            Me.XdtTipoImpuestoIVA.ExecuteSql(Strsql)
            Me.cboIVA.DataSource = XdtTipoImpuestoIVA.Source

            Me.cboIVA.Splits(0).DisplayColumns("nStbTipoImpuestoID").Visible = False
            Me.cboIVA.Splits(0).DisplayColumns("sDescripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboIVA.Splits(0).DisplayColumns("nPorcentaje").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboIVA.Splits(0).DisplayColumns("sDescripcion").Width = 50
            Me.cboIVA.Splits(0).DisplayColumns("nPorcentaje").Width = 50

            Me.cboIVA.Columns("sDescripcion").Caption = "Descripción"
            Me.cboIVA.Columns("nPorcentaje").Caption = "Porcentaje"

            Me.cboIVA.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboIVA.Splits(0).DisplayColumns("nPorcentaje").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatosF As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            Dim StrSesion As String = ""
            ValidaDatosEntrada = True
            Me.errSolicitudes.Clear()

            'Fecha de Solicitud:
            If Me.cdeFechaSolicita.ValueIsDbNull Then
                MsgBox("La Fecha de Solicitud  NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicita, "La Fecha de Solicitud del Desembolso NO DEBE quedar vacía.")
                Me.cdeFechaSolicita.Focus()
                Exit Function
            End If


            If ValidarNumRecibo() = False Then
                MsgBox("El numero de Recibo no es Válido", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.txtnRecibo, "Número de Recibo Inválido")
                Me.txtnRecibo.Focus()
                Exit Function
            End If

            'Fecha de Desembolso del Crédito:
            If Me.cdeFechaEmision.ValueIsDbNull Then
                MsgBox("La Fecha Esperada de Desembolso NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaEmision, "La Fecha de Desembolso del Crédito NO DEBE NO DEBE quedar vacía.")
                Me.cdeFechaEmision.Focus()
                Exit Function
            End If

            'Fechas de Solicitud y Desembolso deben ser de un Mes Contable Abierto:
            If PeriodoAbiertoDadaFecha(Me.cdeFechaSolicita.Value) = False Then
                MsgBox("La Fecha de Solicitud del Desembolso corresponde" & Chr(13) & "a un mes Contable Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicita, "Fecha de Solicitud de Desembolso Inválida.")
                Me.cdeFechaSolicita.Focus()
                Exit Function
            End If

            If PeriodoAbiertoDadaFecha(Me.cdeFechaEmision.Value) = False Then
                MsgBox("La Fecha del Desembolso corresponde" & Chr(13) & "a un mes Contable Cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaEmision, "Fecha de Desembolso Inválida.")
                Me.cdeFechaEmision.Focus()
                Exit Function
            End If

            'Fecha de Solicitud no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaSolicita.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Solicitud NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicita, "La Fecha de Solicitud NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaSolicita.Focus()
                Exit Function
            End If

            'Fecha de Solicitud no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaSolicita.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Solicitud NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicita, "La Fecha de Solicitud NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaSolicita.Focus()
                Exit Function
            End If

            'Fecha de Desembolso del Crédito: no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaEmision.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Desembolso  NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaEmision, "La Fecha de Desembolso NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaEmision.Focus()
                Exit Function
            End If

            'Fecha de Desembolso del Crédito: no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaEmision.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Desembolso  NO DEBE ser mayor" & Chr(13) & "que la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaEmision, "La Fecha de Desembolso NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaEmision.Focus()
                Exit Function
            End If

            'Debe existir un Tipo de Cambio para Fecha de Desembolso (Entrega de Cheque):
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaEmision.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha de Desembolso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaEmision, "No existe una Tasa de Cambio para la Fecha de Desembolso.")
                Me.cdeFechaEmision.Focus()
                Exit Function
            End If

            'Debe existir un Tipo de Cambio para Fecha de Solicitud (Codificacion Contable):
            strSQL = "SELECT nStbParidadCambiariaID FROM  vwStbTasasDeCambio WHERE (dFechaTCambio = CONVERT(DATETIME, '" & Format(Me.cdeFechaSolicita.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Tasa de Cambio para la Fecha de Solicitud de Desembolso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cdeFechaSolicita, "No existe una Tasa de Cambio para la Fecha Solicitud de Desembolso.")
                Me.cdeFechaSolicita.Focus()
                Exit Function
            End If

            'Advertir si Fecha de Desembolso cambio con respecto a la Fecha de Entrega
            'del Cheque de la FNC:
            If Me.ModoForm = "ADD" Then
                'If Format(Me.cdeFechaDesembolso.Value, "dd/MM/yyyy") <> Format(dFechaEmisionRec, "dd/MM/yyyy") Then
                '    If MsgBox("La modificación de la Fecha de Desembolso con respecto a" & Chr(13) _
                '            & "la Fecha de Entrega del Cheque indicada en la Ficha de" & Chr(13) _
                '            & "Notificación podría modificar las Tablas de Amortización." & Chr(13) & Chr(13) _
                '            & "¿Esta seguro que desea realizar el cambio?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                '        ValidaDatosEntrada = False
                '        Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Fecha de Desembolso difiere de Fecha de Entrega del Cheque.")
                '        Me.cdeFechaDesembolso.Focus()
                '        Exit Function
                '    End If
                'End If
            Else
                'If Format(Me.cdeFechaDesembolso.Value, "dd/MM/yyyy") <> Format(ObjSolicituddr.dFechaDesembolso, "dd/MM/yyyy") Then
                '    If MsgBox("La modificación de la Fecha de Desembolso con respecto a" & Chr(13) _
                '            & "la Fecha de Entrega del Cheque indicada en la Ficha de" & Chr(13) _
                '            & "Notificación podría modificar las Tablas de Amortización." & Chr(13) & Chr(13) _
                '            & "¿Esta seguro que desea realizar el cambio?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                '        ValidaDatosEntrada = False
                '        Me.errSolicitudes.SetError(Me.cdeFechaDesembolso, "Fecha de Desembolso difiere de Fecha de Entrega del Cheque.")
                '        Me.cdeFechaDesembolso.Focus()
                '        Exit Function
                '    End If
                'End If
            End If


            'Fuente de Financiamiento:
            'If Me.cboFuente.SelectedIndex = -1 Then
            '    MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitudes.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
            '    Me.cboFuente.Focus()
            '    Exit Function
            'End If

            'Elaborado:
            If Me.cboFirmaE.SelectedIndex = -1 Then
                MsgBox("Debe indicar Empleado que Elabora la Solicitud.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboFirmaE, "Debe indicar Empleado que Elabora la Solicitud.")
                Me.cboFirmaE.Focus()
                Exit Function
            End If

            'Autorizado:
            If Me.cboFirmaA.SelectedIndex = -1 Then
                MsgBox("Debe indicar Empleado que Autoriza la Solicitud.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboFirmaA, "Debe indicar Empleado que Autoriza la Solicitud.")
                If Me.cboFirmaA.Enabled Then
                    Me.cboFirmaA.Focus()
                End If
                Exit Function
            End If

            'Empleado Elabora debe ser diferente del que Autoriza:
            If Me.cboFirmaE.Columns("nSrhEmpleadoID").Value = Me.cboFirmaA.Columns("nSrhEmpleadoID").Value Then
                MsgBox("Empleado responsable de Autorizar" & Chr(13) & "NO debe ser el mismo que Elabora.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboFirmaA, "Empleado Autoriza NO debe ser el mismo que Elabora.")
                If Me.cboFirmaA.Enabled Then
                    Me.cboFirmaA.Focus()
                End If
                Exit Function
            End If



            If Me.cboBeneficiario.SelectedIndex = -1 Then
                MsgBox("Debe indicar el Proveedor.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboBeneficiario, "Debe indicar el Proveedor.")
                Me.cboBeneficiario.Focus()
                Exit Function
            End If



            If Me.cboIR.SelectedIndex = -1 Then
                MsgBox("Debe indicar el tipo de pago IR.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboIR, "Debe indicar el tipo de pago IR.")
                Me.cboIR.Focus()
                Exit Function
            End If

            If Me.cboIVA.SelectedIndex = -1 Then
                MsgBox("Debe indicar el tipo de pago IVA.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboIVA, "Debe indicar el tipo de pago IVA.")
                Me.cboIVA.Focus()
                Exit Function
            End If


            If Me.cboALCALDIA.SelectedIndex = -1 Then
                MsgBox("Debe indicar el tipo de pago ALCALDIA.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cboALCALDIA, "Debe indicar el tipo de pago ALCALDIA.")
                Me.cboALCALDIA.Focus()
                Exit Function
            End If
            If Me.txtConcepto.Text.Trim() = "" Then
                MsgBox("Debe indicar el concepto de pago.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.txtConcepto, "Debe indicar el concepto de pago.")
                Me.txtConcepto.Focus()
                Exit Function
            End If

            If Me.cneMonto.Value <= 0 Then
                MsgBox("Debe indicar el sub total mayor que cero.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cneMonto, "Debe indicar el sub total mayor que cero.")
                Me.cneMonto.Focus()
                Exit Function

            End If


            If Me.cneMontoIVAEXENTO.Value < 0 Then
                MsgBox("Debe indicar el monto exento de IVA mayor o igual que cero.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cneMontoIVAEXENTO, "Debe indicar el monto exento de IVA mayor o igual que cero.")
                Me.cneMontoIVAEXENTO.Focus()
                Exit Function
            End If

            If Me.cneMontoIREXENTO.Value < 0 Then
                MsgBox("Debe indicar el monto exento de IR mayor o igual que cero.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cneMontoIREXENTO, "Debe indicar el monto exento de IR mayor o igual que cero.")
                Me.cneMontoIREXENTO.Focus()
                Exit Function
            End If

            If Me.cneMontoALCALDIAEXENTO.Value < 0 Then
                MsgBox("Debe indicar el monto exento de ALCALDIA mayor o igual que cero.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitudes.SetError(Me.cneMontoALCALDIAEXENTO, "Debe indicar el monto exento de ALCALDIA mayor o igual que cero.")
                Me.cneMontoALCALDIAEXENTO.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosF.Close()
            XcDatosF = Nothing
        End Try
    End Function


    Private Sub SalvarSolicitudes()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            strFechaSolicita = Format(Me.cdeFechaSolicita.Value, "yyyy-MM-dd HH:mm")
            dFechaEmision = Format(Me.cdeFechaEmision.Value, "yyyy-MM-dd HH:mm")



            strSQL = " EXEC spSteGrabarSolicitudCajaChicaDetalle " & Me.intSolicitudID & ", " & Me.cboBeneficiario.Columns("nStbPersonaID").Value & ",'" & Trim(Me.txtConcepto.Text) & "'," & Me.nNumeroRecibo &
                        ",'" & strFechaSolicita & "', '" & dFechaEmision & "', " & cneMontoChequeTotal.Value & "," & Me.cboIR.Columns("nStbTipoImpuestoID").Value & "," & Me.cneMontoIR.Value & "," & Me.cboIVA.Columns("nStbTipoImpuestoID").Value &
                        "," & Me.cneMontoIVA.Value & ",'" & Me.txtCedula.Text.Trim & "','" & Me.txtNORUC.Text.Trim & "','" & Me.txtdireccion.Text.Trim & "'," & cboFirmaE.Columns("nSrhEmpleadoID").Value & "," & cboFirmaA.Columns("nSrhEmpleadoID").Value &
                        ", '" & Trim(RTrim(Me.txtObservacion.Text)) & "', '" & Me.ModoForm & "', '" & InfoSistema.LoginName & "'" & "," & InfoSistema.IDCuenta & "," & Me.cneMontoIVAEXENTO.Value & "," & Me.cneMontoIREXENTO.Value &
                        "," & Me.cboALCALDIA.Columns("nStbTipoImpuestoID").Value & "," & Me.cneMontoALCALDIA.Value & "," & Me.cneMontoALCALDIAEXENTO.Value

            Me.intSolicitudID = XcDatos.ExecuteScalar(strSQL)

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS INSERT DE AUDITORIA 

            ' Esto es para SccSolicitudDesembolsoCredito
            'StrQuery = "SELECT nSccSolicitudDesembolsoCreditoID FROM SccSolicitudDesembolsoCredito WHERE nSclFichaNotificacionDetalleID = " & IdnSclFichaNotificacionDetalle
            'XdtConsulta.ExecuteSql(StrQuery)

            'If XdtConsulta.Count > 0 Then
            '    IdnSccSolicitudDesembolsoCredito = XdtConsulta.ValueField("nSccSolicitudDesembolsoCreditoID")
            '    GuardarAuditoriaTablas(3, 1, "Agregar SccSolicitudDesembolsoCredito", IdnSccSolicitudDesembolsoCredito, InfoSistema.IDCuenta)
            'End If

            ' ------------------------------------------------------------------------------------------

            '-- Buscar la FNC correspondiente al Id especificado
            '-- como parámetro, en caso de edición.
            'ObjSolicituddt.Filter = "nSclFichaNotificacionID = " & Me.intFichaID
            'ObjSolicituddt.Retrieve()
            'If ObjSolicituddt.Count = 0 Then
            '    Exit Sub
            'End If
            'ObjSolicituddr = ObjSolicituddt.Current

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.intSolicitudID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                If ModoForm = "ADD" Then
                    MsgBox("Las Solicitudes de Pago de Caja Chica se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Las Solicitudes de pago de Caja Chica se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            Me.CalcularIR()
            Me.CalcularIVA()
            Me.CalcularALCALDIA()
            MontoTotal()
            If vbModifico = True Then
                res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarSolicitudes()
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

    Private Sub txtObservacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacion.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboFirmaE_Error(ByVal sender As System.Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFirmaE.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboFirmaE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirmaE.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirmaA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirmaA.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        vbModifico = True
    End Sub


    Private Sub cboIR_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIR.TextChanged

        vbModifico = True
        CalcularIR()
        MontoTotal()
    End Sub

    Private Sub cboIVA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIVA.TextChanged
        vbModifico = True
        CalcularIVA()
        MontoTotal()
    End Sub

    Private Sub txtConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcepto.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboIR_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIR.ItemChanged

    End Sub

    Private Sub cboIVA_ItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboIVA.ItemChanged

    End Sub
    Private Sub CalcularIVA()
        Dim impuestoiva As Double
        impuestoiva = Convert.ToDouble(Me.XdtTipoImpuestoIVA("nPorcentaje"))
        Me.cneMontoIVA.Value = (IIf(IsDBNull(Me.cneMonto.Value), 0, Me.cneMonto.Value) - IIf(IsDBNull(Me.cneMontoIVAEXENTO.Value), 0, Me.cneMontoIVAEXENTO.Value)) * (impuestoiva / 100)

        'Me.cneMontoIVA.Value = (IIf(IsDBNull(Me.cneMonto.Value), 0, Me.cneMonto.Value)) * (impuestoiva / 100)
    End Sub
    Private Sub MontoTotal()

        Try

            Me.cneMontoTotal.Visible = True
            Me.Label10.Visible = True
            Me.cneSubTotalExcentos.Value = IIf(IsDBNull(Me.cneMontoALCALDIAEXENTO.Value), 0, Me.cneMontoALCALDIAEXENTO.Value) + IIf(IsDBNull(Me.cneMontoIVAEXENTO.Value), 0, Me.cneMontoIVAEXENTO.Value) + IIf(IsDBNull(Me.cneMontoIREXENTO.Value), 0, Me.cneMontoIREXENTO.Value)
            Me.cneSubTotalExcentos.Visible = True

            Me.cneSubTotal2.Value = IIf(IsDBNull(Me.cneMonto.Value), 0, Me.cneMonto.Value) - IIf(IsDBNull(Me.cneSubTotalExcentos.Value), 0, Me.cneSubTotalExcentos.Value)
            Me.cneSubTotal2.Visible = True
            Me.cneMontoTotal.Value = IIf(IsDBNull(Me.cneSubTotal2.Value), 0, Me.cneSubTotal2.Value) + IIf(IsDBNull(Me.cneSubTotalExcentos.Value), 0, Me.cneSubTotalExcentos.Value) + IIf(IsDBNull(Me.cneMontoIVA.Value), 0, Me.cneMontoIVA.Value)
            Me.cneMontoChequeTotal.Value = IIf(IsDBNull(Me.cneMonto.Value), 0, Me.cneMonto.Value) - IIf(IsDBNull(Me.cneMontoIR.Value), 0, Me.cneMontoIR.Value) - IIf(IsDBNull(Me.cneMontoALCALDIA.Value), 0, Me.cneMontoALCALDIA.Value) + IIf(IsDBNull(Me.cneMontoIVA.Value), 0, Me.cneMontoIVA.Value)


        Catch ex As Exception
            Control_Error(ex)

        End Try

    End Sub
    Private Sub CalcularIR()

        Dim impuestoir As Double
        impuestoir = Convert.ToDouble(Me.XdtTipoImpuesto("nPorcentaje"))
        Me.cneMontoIR.Value = (IIf(IsDBNull(Me.cneMonto.Value), 0, Me.cneMonto.Value) - IIf(IsDBNull(Me.cneMontoIREXENTO.Value), 0, Me.cneMontoIREXENTO.Value)) * (impuestoir / 100)
    End Sub
    Private Sub CalcularALCALDIA()
        Dim impuestoalcaldia As Double
        impuestoalcaldia = Convert.ToDouble(Me.XdtTipoImpuestoALCALDIA("nPorcentaje"))
        Me.cneMontoALCALDIA.Value = (IIf(IsDBNull(Me.cneMonto.Value), 0, Me.cneMonto.Value) - IIf(IsDBNull(Me.cneMontoALCALDIAEXENTO.Value), 0, Me.cneMontoALCALDIAEXENTO.Value)) * (impuestoalcaldia / 100)

        'Me.cneMontoIVA.Value = (IIf(IsDBNull(Me.cneMonto.Value), 0, Me.cneMonto.Value)) * (impuestoiva / 100)
    End Sub
    Private Sub cneMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.TextChanged
        vbModifico = True
        CalcularIVA()
        CalcularIR()
        CalcularALCALDIA()
        MontoTotal()
    End Sub

    Private Sub cneMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.Leave
        vbModifico = True
        CalcularIVA()
        CalcularIR()
        CalcularALCALDIA()
        MontoTotal()
    End Sub

    Private Sub cneMontoIVAEXENTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
        CalcularIVA()
        CalcularIR()
        CalcularALCALDIA()
        MontoTotal()
    End Sub

    Private Sub cneMontoIREXENTO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
        CalcularIVA()
        CalcularIR()
        CalcularALCALDIA()
        MontoTotal()
    End Sub

    Private Sub cboMUNICIPAL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboALCALDIA.TextChanged
        vbModifico = True
        CalcularALCALDIA()
        MontoTotal()
    End Sub

    Private Function ValidarNumRecibo() As Boolean

        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtNRecibo As BOSistema.Win.XDataSet.xDataTable
        XdtNRecibo = New BOSistema.Win.XDataSet.xDataTable
        'Dim nRecNum As Integer
        Try
            Dim StrSql As String
            ValidarNumRecibo = True
            intNumRecibo = Integer.Parse(txtnRecibo.Text)
            'Busca el registro Consecutivo de Recibo
            StrSql = "SELECT nNumeroRecibo FROM SteSolicitudCajaChicaDetalle WHERE nNumeroRecibo=" & intNumRecibo & "and nSteSolicitudCajaChicaDetalleID <>" & intSccSolicitudID
            XdtNRecibo.ExecuteSql(StrSql)
            If XdtNRecibo.Count > 0 Then
                If Not IsDBNull(XdtNRecibo.Table.Rows(0).Item(0)) Then
                    Dim valor As Integer
                    valor = Convert.ToInt32(XdtNRecibo.Table.Rows(0).Item("nNumeroRecibo"))
                    If valor = intNumRecibo Then
                        ValidarNumRecibo = False
                    End If
                Else
                    If Not intNumRecibo = 1 Then
                        ValidarNumRecibo = False
                    End If
                    'End If
                End If

            End If
        Catch ex As Exception
            Control_Error(ex)
            ValidarNumRecibo = False
        Finally
            XdtNRecibo.Close()
            XdtNRecibo = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    Private Sub cboBeneficiario_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBeneficiario.TextChanged
        vbModifico = True

        Me.txtCedula.Text = IIf(IsDBNull(Me.XdtBeneficiario.ValueField("sNumCedula")), "", Me.XdtBeneficiario.ValueField("sNumCedula"))
        Me.txtNORUC.Text = IIf(IsDBNull(Me.XdtBeneficiario.ValueField("sNumRUC")), "", Me.XdtBeneficiario.ValueField("sNumRUC"))
        Me.txtdireccion.Text = IIf(IsDBNull(Me.XdtBeneficiario.ValueField("sDireccion")), "", Me.XdtBeneficiario.ValueField("sDireccion"))

    End Sub
End Class