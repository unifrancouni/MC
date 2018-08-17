Public Class frmSteSolicitudProveedor
    Dim XdsSolicitudCheque As BOSistema.Win.XDataSet
    Dim ModoAcc As String
    Dim sColor As String
    Dim TipoChk As Integer
    Dim TipoChkAgregar As Integer
    Dim StrCadena As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    'Propiedad utilizada para identificar si el formulario responde a 
    'Elborar, Revisar o Autorizar una determinada Solicitud de Cheque:
    '0: Todos
    '1:Solo Tipo Cheque 1 y 2 Para Socias y Delegadas
    'Para que creditos no vea los cheques de pagos gastos 
    Public Property TipoCheque() As Integer
        Get
            TipoCheque = TipoChk
        End Get
        Set(ByVal value As Integer)
            TipoChk = value
        End Set
    End Property

    Public Property TipoChequeAgregar() As Integer
        Get
            TipoChequeAgregar = TipoChkAgregar
        End Get
        Set(ByVal value As Integer)
            TipoChkAgregar = value
        End Set
    End Property

    'Color a mostrarse en el formulario
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property
    'Propiedad utilizada para identificar si el formulario responde a 
    'Elborar, Revisar o Autorizar una determinada Solicitud de Cheque:
    'ELA: Elaborar
    'REV: Revisar
    'AUT: Autorizar
    Public Property ModoAccion() As String
        Get
            ModoAccion = ModoAcc
        End Get
        Set(ByVal value As String)
            ModoAcc = value
        End Set
    End Property
    Private Sub frmSteSolicitudProveedor_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try

            XdsSolicitudCheque.Close()
            XdsSolicitudCheque = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar Solicitudes:
            'If Seg.HasPermission("BuscarSCK") = False Then
            '    Me.tbSolicitud.Items("toolBuscar").Enabled = False
            'Else  'Habilita
            '    Me.tbSolicitud.Items("toolBuscar").Enabled = True
            'End If
            'Agregar Solicitud:
            If Seg.HasPermission("AgregarSolicitudProveedor") = False Then
                Me.tbSolicitud.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAgregar").Enabled = True
            End If
            'Editar Solicitud:
            If Seg.HasPermission("ModificarSolicitudProveedor") = False Then
                Me.tbSolicitud.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolModificar").Enabled = True
            End If
            'Anular Solicitud:
            If Seg.HasPermission("AnularSolicitudProveedor") = False Then
                Me.tbSolicitud.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAnular").Enabled = True
            End If
            'Revisar Solicitud:
            If Seg.HasPermission("AutorizarSolicitudProveedor") = False Then
                Me.tbSolicitud.Items("toolRevisar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolRevisar").Enabled = True
            End If
            'Generar Cheques en grupo:
            'If Seg.HasPermission("GenerarBloqueCKS") = False Then
            '    Me.tbSolicitud.Items("toolGenerarChecked").Enabled = False
            'Else  'Habilita
            '    Me.tbSolicitud.Items("toolGenerarChecked").Enabled = True
            'End If
            'Imprimir Formato de Solicitud de Cheque:
            If Seg.HasPermission("ImprimirReporteProveedorTE53") = False Then
                Me.toolImprimirTE53.Enabled = False

            Else  'Habilita
                Me.toolImprimirTE53.Enabled = True
            End If


            If Seg.HasPermission("ImprimirReporteProveedorTE54") = False Then
                Me.toolImprimirTE54.Enabled = False
            Else  'Habilita
                Me.toolImprimirTE54.Enabled = True
            End If

            If Seg.HasPermission("ImprimirReporteProveedorTE55") = False Then
                Me.toolImprimirTE55.Enabled = False
            Else  'Habilita
                Me.toolImprimirTE55.Enabled = True
            End If

            If Seg.HasPermission("ImprimirReporteProveedorTE57") = False Then
                Me.toolImprimirTE57.Enabled = False
            Else  'Habilita
                Me.toolImprimirTE57.Enabled = True
            End If

            ''Agregar Jornalización:
            'If Seg.HasPermission("AgregarCuentasSCK") = False Then
            '    Me.tbCuenta.Items("toolAgregarJ").Enabled = False
            'Else  'Habilita
            '    Me.tbCuenta.Items("toolAgregarJ").Enabled = True
            'End If
            ''Editar Jornalización:
            'If Seg.HasPermission("ModificarCuentasSCK") = False Then
            '    Me.tbCuenta.Items("toolModificarJ").Enabled = False
            'Else  'Habilita
            '    Me.tbCuenta.Items("toolModificarJ").Enabled = True
            'End If
            ''Eliminar Jornalización:
            'If Seg.HasPermission("EliminarCuentasSCK") = False Then
            '    Me.tbCuenta.Items("toolEliminarJ").Enabled = False
            'Else  'Habilita
            '    Me.tbCuenta.Items("toolEliminarJ").Enabled = True
            'End If

            

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSteSolicitudProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)
            Seguridad()
            If ModoAcc = "ELA" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Registrar Solicitudes de Pago a Proveedores")
                Me.Text = "Registrar Solicitudes de Pago a Proveedores"
                Me.toolRevisar.Visible = False
            ElseIf ModoAcc = "AUT" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Autorización Solicitudes de Pago a Proveedores")
                Me.Text = "Autorización Solicitudes de Pago a Proveedores"
                Me.toolRevisar.Visible = True
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            'cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaD.Value = FechaServer()
            'cdeFechaH.Value = cdeFechaD.Value
            cdeFechaD.Value = FechaServer()
            cdeFechaH.Value = FechaServer()

            InicializaVariables()
            'StrCadena = " WHERE (a.nSccSolicitudChequeID = 0) " 'Al cargar Grid en Blanco
            CargarSolicitudCheque(StrCadena, 0)
            'Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub


    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	10/03/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros de Delegación.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsSolicitudCheque = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los Grids, estructura y Datos:
            Me.grdSolicitud.ClearFields()


            'Determinar Parámetros de la Delegación del Usuario:
            EncuentraParametros()

            'Según usuario que accesa:
            If ModoAcc = "ELA" Then
                Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Registra solicitud de pago a proveedores"
                Me.Text = "Registro de Solicitudes de pago a proveedores"
            ElseIf ModoAcc = "AUT" Then
                Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Autorizar Solicitud"
                Me.Text = "Autorización de Solicitudes de pago a proveedores"
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2007
    ' Procedure Name:       CargarSolicitudCheque
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Grupos Solidarios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarSolicitudCheque(ByVal sCadenaFiltro As String, ByVal IntBit As Integer)
        Try
            Dim Strsql As String

            ''Limpiar los Grids, estructura y Datos:
            Me.grdSolicitud.ClearFields()


            'If Me.ModoAccion <> "REV" And Me.ModoAccion <> "AUT" Then

            '    If Me.TipoCheque = 1 Then 'Filtar para que no vean los cheques de egresos tipo solicitud cheque 3
            '        If Trim(sCadenaFiltro) = "" Then
            '            sCadenaFiltro = " where a.nSccTipoSolicitudChequeID<=2"
            '        Else

            '            sCadenaFiltro = sCadenaFiltro + " and a.nSccTipoSolicitudChequeID<=2"
            '        End If

            '    Else
            '        If Trim(sCadenaFiltro) = "" Then
            '            sCadenaFiltro = " where a.nSccTipoSolicitudChequeID=3"
            '        Else

            '            sCadenaFiltro = sCadenaFiltro + " and a.nSccTipoSolicitudChequeID=3"
            '        End If

            '    End If

            'End If



            Strsql = " SELECT a.* " & _
                               " FROM  vwSteSolicitudDesembolsoProveedor as a " & " WHERE (CONVERT(Varchar(10), dFechaSolicitudDesembolso, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dFechaSolicitudDesembolso, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) " & _
                               " Order by nCodigo " 'Option (Force Order)"




            

            If XdsSolicitudCheque.ExistTable("Solicitud") Then
                XdsSolicitudCheque("Solicitud").ExecuteSql(Strsql)
            Else
                XdsSolicitudCheque.NewTable(Strsql, "Solicitud")
                XdsSolicitudCheque("Solicitud").Retrieve()
            End If

            ''Detalle: Jornalización de Cuentas de la Solicitud:
            'Strsql = " SELECT a.* " & _
            '         " FROM vwSccSolicitudChequeDetalles as a " & sCadenaFiltro & _
            '         " Order by nDebito desc, sCodigoCuenta "  'Option (Force Order)"
            ' ''Strsql = "EXEC SpSccGridSolicitudCheque 0, 0, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
            ''Strsql = " SELECT * " & _
            ''         " FROM vwSccSolicitudChequeDetalles " & _
            ''         " WHERE (dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            ''         " Order by nDebito desc, sCodigoCuenta Option (Force Order)"
            'If XdsSolicitudCheque.ExistTable("Cuentas") Then
            '    XdsSolicitudCheque("Cuentas").ExecuteSql(Strsql)
            'Else
            '    XdsSolicitudCheque.NewTable(Strsql, "Cuentas")
            '    XdsSolicitudCheque("Cuentas").Retrieve()
            'End If

            'If XdsSolicitudCheque.ExistRelation("SolicitudConDetalles") = False Then
            '    'Creando la relación entre el Primer Query y el Segundo:
            '    XdsSolicitudCheque.NewRelation("SolicitudConDetalles", "Solicitud", "Cuentas", "nSccSolicitudChequeID", "nSccSolicitudChequeID")
            'End If
            'XdsSolicitudCheque.SincronizarRelaciones()

            'Asignando a las fuentes de datos:
            Me.grdSolicitud.DataSource = XdsSolicitudCheque("Solicitud").Source
            REM REBIND
            Me.grdSolicitud.Rebind(False)

            'Me.grdDetalles.DataSource = XdsSolicitudCheque("Cuentas").Source
            'REM REBIND
            'Me.grdDetalles.Rebind(False)

            'Actualizando el caption de los GRIDS:
            Me.grdSolicitud.Caption = " Listado de Solicitudes de Cheques (" + Me.grdSolicitud.RowCount.ToString + " registros)"
            'Me.grdDetalles.Caption = " Detalles de Solicitud de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
            FormatoSolicitudCheque()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       FormatoSolicitudCheque
    ' Descripción:          Este procedimiento permite configurar datos
    '                       sobre Solicitudes de Cheque en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoSolicitudCheque()
        Try
            Dim ContadorColumna As Integer
            'Configuracion del Grid Solicitudes de Cheques:
            Me.grdSolicitud.Splits(0).DisplayColumns("nSteSolicitudDesembolsoProveedorID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("sCodigoInterno").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbPersonaBeneficiariaID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbTipoIVAID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("DescripcionIR").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("DescripcionIVA").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("DescripcionALCALDIA").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("sNumCedula").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("sNumRUC").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nSrhEmpleadoElaboraID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nSrhEmpleadoAutorizaID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbTipoImpuestoID").Visible = False

            Me.grdSolicitud.Splits(0).DisplayColumns("nStbTipoALCALDIAID").Visible = False


     
            For ContadorColumna = 0 To Me.grdSolicitud.Splits(0).DisplayColumns.Count - 1
                Me.grdSolicitud.Splits(0).DisplayColumns(ContadorColumna).Locked = True
            Next

            'Me.grdSolicitud.Splits(0).DisplayColumns("Selected").Locked = False


            Me.grdSolicitud.Splits(0).DisplayColumns("NombreFuente").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicitudDesembolso").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaDesembolso").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("NombreProveedor").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoElabora").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAutoriza").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPago").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoRetencion").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoIVA").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPagoTotal").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIR").Width = 60
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIVA").Width = 60
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeALCALDIA").Width = 60

            Me.grdSolicitud.Columns("NombreFuente").Caption = "fuente"
            Me.grdSolicitud.Columns("sConceptoPago").Caption = "Concepto de Pago"
            Me.grdSolicitud.Columns("dFechaSolicitudDesembolso").Caption = "Fecha solicitud"
            Me.grdSolicitud.Columns("dFechaDesembolso").Caption = "Fecha a desembolsar"
            Me.grdSolicitud.Columns("NombreProveedor").Caption = "Proveedor"
            Me.grdSolicitud.Columns("EmpleadoElabora").Caption = "Solicitado por"
            Me.grdSolicitud.Columns("EmpleadoAutoriza").Caption = "Autorizado por"
            Me.grdSolicitud.Columns("EstadoSolicitud").Caption = "Estado"
            Me.grdSolicitud.Columns("nCodigo").Caption = "Número"
            Me.grdSolicitud.Columns("nMontoPago").Caption = "Sub Total(C$)"
            Me.grdSolicitud.Columns("nMontoRetencion").Caption = "IR(C$)"
            Me.grdSolicitud.Columns("nMontoIVA").Caption = "IVA(C$)"
            Me.grdSolicitud.Columns("nMontoALCALDIA").Caption = "ACALDIA(C$)"


            Me.grdSolicitud.Columns("nMontoPagoTotal").Caption = "Total (C$)"
            Me.grdSolicitud.Columns("PorcentajeIR").Caption = "% IR"
            Me.grdSolicitud.Columns("PorcentajeIVA").Caption = "% IVA"
            Me.grdSolicitud.Columns("PorcentajeALCALDIA").Caption = "% ALCALDIA"


            Me.grdSolicitud.Splits(0).DisplayColumns("NombreFuente").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicitudDesembolso").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaDesembolso").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("NombreProveedor").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoElabora").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAutoriza").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPago").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoRetencion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoIVA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoALCALDIA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPagoTotal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIR").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIVA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeALCALDIA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify




            Me.grdSolicitud.Splits(0).DisplayColumns("NombreFuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicitudDesembolso").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaDesembolso").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("NombreProveedor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoElabora").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAutoriza").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoRetencion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoIVA").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPagoTotal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIR").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIVA").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeALCALDIA").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


           

            Me.grdSolicitud.Columns("nMontoPago").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nMontoRetencion").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nMontoIVA").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nMontoALCALDIA").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nMontoPagoTotal").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("PorcentajeIR").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("PorcentajeIVA").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("PorcentajeALCALDIA").NumberFormat = "#,##0.00"




          

            

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaAgregarSolicitud()
        Dim ObjFrmSclEditSCK As New cneMontoCheque ' frmSccEditSolicitudCheque
        Try

            'Si no es el Area Solicitante Imposible Agregar Solicitud: 
            'If ModoAcc <> "ELA" Then
            '    MsgBox("Unicamente el Area Solicitante puede registrar" & Chr(13) & "Solicitudes de Cheque.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmSclEditSCK.sColorFrm = "Naranja"
            ObjFrmSclEditSCK.ModoFrm = "ADD"
            ObjFrmSclEditSCK.TipoChequeAgregar = TipoChequeAgregar
            ObjFrmSclEditSCK.ShowDialog()

            'En la adición se carga unicamente la Solicitud de Cheque recien ingresada:
            If ObjFrmSclEditSCK.intSccSolicitudID <> 0 Then
                StrCadena = "Where (a.nSccSolicitudChequeID = " & ObjFrmSclEditSCK.IdSolicitudCheque & ")"
                CargarSolicitudCheque(StrCadena, 0)
                'Se ubica sobre el registro recien agregado:
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSteSolicitudDesembolsoProveedorID", ObjFrmSclEditSCK.intSccSolicitudID)
                Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSCK.Close()
            ObjFrmSclEditSCK = Nothing
        End Try
    End Sub

    'Private Sub LlamaBuscarSolicitudes()
    '    Dim ObjFrmSccBusquedaS As New frmSteBusquedaSolicitudesProveedor
    '    Try

    '        ObjFrmSccBusquedaS.StrCriterioSolicitud = "0" 'Sin Criterio de Busqueda
    '        ObjFrmSccBusquedaS.IdConsultarDelegacion = IntPermiteConsultar
    '        ObjFrmSccBusquedaS.TipoCheque = Me.TipoCheque '0 Busca todos,1 no presenta los de proveedores .
    '        ObjFrmSccBusquedaS.sColorFrm = Me.sColor

    '        ObjFrmSccBusquedaS.ModoAccion = Me.ModoAccion

    '        ObjFrmSccBusquedaS.ShowDialog()
    '        If ObjFrmSccBusquedaS.StrCriterioSolicitud <> "0" Then
    '            StrCadena = ObjFrmSccBusquedaS.StrCriterioSolicitud
    '            CargarSolicitudCheque(StrCadena, 0)
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjFrmSccBusquedaS.Close()
    '        ObjFrmSccBusquedaS = Nothing
    '    End Try
    'End Sub

    Private Sub LlamaImprimirTE53()
        Dim frmVisor As New frmCRVisorReporte
        Try

            Dim strSQL As String = ""
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.NombreReporte = "RepSteTE53.rpt"
            frmVisor.Text = "Solicitud de desembolso de pago a proveedor"
            frmVisor.SQLQuery = "Select * From vwSteSolicitudDesembolsoProveedor Where nSteSolicitudDesembolsoProveedorID=" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")
            
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try



    End Sub

    Private Sub LlamaImprimirTE54()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable
            Dim strSQL As String = ""
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"



            strSQL = "SELECT     sValorParametro  FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 105)"
            XdtFichaTmp.ExecuteSql(strSQL)

            If XdtFichaTmp.Count = 0 Then
                MsgBox("No existe definido en stbvalorcatalogo el id para anulado de EstadoDesembolsoProveedores." & Chr(13), MsgBoxStyle.Information)
            End If

            frmVisor.Formulas("NRUC") = "'" & XdtFichaTmp.ValueField("sValorParametro") & "'"

            frmVisor.NombreReporte = "RepSteTE54.rpt"
            frmVisor.Text = "Constancia de desembolso de pago a proveedor"
            'frmVisor.SQLQuery = "Select * From vwSteSolicitudDesembolsoProveedor Where nSteSolicitudDesembolsoProveedorID=" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")

            frmVisor.CRVReportes.SelectionFormula = " {vwSteSolicitudDesembolsoProveedorCheque.nSteSolicitudDesembolsoProveedorID} =" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")


            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try



    End Sub

    Private Sub LlamaImprimirTE56()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable
            Dim strSQL As String = ""
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"



            'strSQL = "SELECT     sValorParametro  FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 105)"
            'XdtFichaTmp.ExecuteSql(strSQL)

            'If XdtFichaTmp.Count = 0 Then
            '    MsgBox("No existe definido en stbvalorcatalogo el id para anulado de EstadoDesembolsoProveedores." & Chr(13), MsgBoxStyle.Information)
            'End If

            'frmVisor.Formulas("NRUC") = "'" & XdtFichaTmp.ValueField("sValorParametro") & "'"

            frmVisor.NombreReporte = "RepSteTE56.rpt"
            frmVisor.Text = "Constancia de desembolso de pago a proveedor"
            'frmVisor.SQLQuery = "Select * From vwSteSolicitudDesembolsoProveedor Where nSteSolicitudDesembolsoProveedorID=" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")

            strSQL = " SELECT a.* " & _
                                 " FROM  vwSteSolicitudDesembolsoProveedor as a " & " WHERE (CONVERT(Varchar(10), dFechaSolicitudDesembolso, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dFechaSolicitudDesembolso, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) " & _
                                 " Order by nCodigo " 'Option (Force Order)"


            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try



    End Sub
    Private Sub LlamaImprimirTE57()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable
            Dim strSQL As String = ""
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"



            'strSQL = "SELECT     sValorParametro  FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 105)"
            'XdtFichaTmp.ExecuteSql(strSQL)

            'If XdtFichaTmp.Count = 0 Then
            '    MsgBox("No existe definido en stbvalorcatalogo el id para anulado de EstadoDesembolsoProveedores." & Chr(13), MsgBoxStyle.Information)
            'End If

            'frmVisor.Formulas("NRUC") = "'" & XdtFichaTmp.ValueField("sValorParametro") & "'"

            frmVisor.NombreReporte = "RepSteTE57.rpt"
            frmVisor.CRVReportes.SelectionFormula = " {vwSteSolicitudDesembolsoProveedorDatosChequeAutorizadosFORMATOALCALDIA.nSteSolicitudDesembolsoProveedorID} =" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")

            frmVisor.Text = "Constancia de retención Alcaldía"
            'frmVisor.SQLQuery = "Select * From vwSteSolicitudDesembolsoProveedor Where nSteSolicitudDesembolsoProveedorID=" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")

            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try



    End Sub
    Private Sub LlamaImprimirTE55()
        Dim frmVisor As New frmCRVisorReporte
        Try

            Dim strSQL As String = ""
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.NombreReporte = "RepSteTE55.rpt"
            frmVisor.Text = "Recibo de desembolso de pago a proveedor"
            frmVisor.SQLQuery = "Select * From vwSteSolicitudDesembolsoProveedor Where nSteSolicitudDesembolsoProveedorID=" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")

            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try



    End Sub
    Private Sub LlamaModificarSolicitud()
        Dim ObjFrmSclEditSCK As New cneMontoCheque ' frmSccEditSolicitudCheque
        Try

            'Si no es el Area Solicitante Imposible Agregar Solicitud: 
            'If ModoAcc <> "ELA" Then
            '    MsgBox("Unicamente el Area Solicitante puede registrar" & Chr(13) & "Solicitudes de Cheque.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmSclEditSCK.sColorFrm = "Naranja"
            ObjFrmSclEditSCK.ModoFrm = "UPD"
            ObjFrmSclEditSCK.intSccSolicitudID = XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")
            ObjFrmSclEditSCK.TipoChequeAgregar = TipoChequeAgregar
            ObjFrmSclEditSCK.ShowDialog()

            'En la adición se carga unicamente la Solicitud de Cheque recien ingresada:
            If ObjFrmSclEditSCK.intSccSolicitudID <> 0 Then
                StrCadena = "Where (a.nSccSolicitudChequeID = " & ObjFrmSclEditSCK.IdSolicitudCheque & ")"
                CargarSolicitudCheque(StrCadena, 0)
                'Se ubica sobre el registro recien agregado:
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSteSolicitudDesembolsoProveedorID", ObjFrmSclEditSCK.intSccSolicitudID)
                Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSCK.Close()
            ObjFrmSclEditSCK = Nothing
        End Try
    End Sub

    Private Sub LlamaAnularSolicitud()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable

        Try

            'Dim intDiaPagosID As Integer
            'Dim intLugarEntregaCKID As Integer
            'Dim intLugarPagosID As Integer
            'Dim intPlazoPeriodoGracia As Integer
            Dim strFechaCK As String

            Dim Strsql As String = ""
            Dim intPosicion As Integer
            Dim nstbestadoanulado As Integer
            Dim nSteSolicitudDesembolsoProveedorID As Integer

            'No existen registros:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If



            'Imposible generar si existen Cheques generados y el mes contable esta Cerrado.

            Strsql = "SELECT     dbo.SteSolicitudChequeProveedor.nSteSolicitudChequeProveedorID, dbo.SteSolicitudChequeProveedor.nSteSolicitudDesembolsoProveedorID,dbo.ScnTransaccionContable.dFechaTransaccion FROM         dbo.SteSolicitudChequeProveedor INNER JOIN                       dbo.SccSolicitudCheque ON dbo.SteSolicitudChequeProveedor.nSccSolicitudChequeID = dbo.SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN                       dbo.ScnTransaccionContable ON dbo.SccSolicitudCheque.nSccSolicitudChequeID = dbo.ScnTransaccionContable.nSccSolicitudChequeID Where dbo.SteSolicitudChequeProveedor.nSteSolicitudDesembolsoProveedorID=" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")

            If RegistrosAsociados(Strsql) Then
                'If PeriodoAbiertoDadaFecha(XcDatos.ExecuteScalar(Strsql)) = False Then
                MsgBox("Imposible Anular Solicitud de pago a proveedor." & Chr(13) & "Existen Comprobantes generados de un mes Contable Cerrado.", MsgBoxStyle.Information)
                Exit Sub
                'End If
            End If

            If XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno") <> 1 And XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno") <> 3 Then
                MsgBox("Solicitud Se encuentra en estado anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Confirmar Anulación: 
            If MsgBox("¿Desea ANULAR la Solicitud de pago a proveedor?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor: 
            Me.Cursor = Cursors.WaitCursor

            Strsql = "SELECT     dbo.StbValorCatalogo.nStbValorCatalogoID  FROM         dbo.StbCatalogo INNER JOIN  dbo.StbValorCatalogo ON dbo.StbCatalogo.nStbCatalogoID = dbo.StbValorCatalogo.nStbCatalogoID WHERE     (dbo.StbCatalogo.sNombre = 'EstadoDesembolsoProveedores') AND (dbo.StbValorCatalogo.sCodigoInterno = '2')"
            XdtFichaTmp.ExecuteSql(Strsql)

            If XdtFichaTmp.Count = 0 Then
                MsgBox("No existe definido en stbvalorcatalogo el id para anulado de EstadoDesembolsoProveedores." & Chr(13), MsgBoxStyle.Information)
            End If
            nstbestadoanulado = XdtFichaTmp.ValueField("nStbValorCatalogoID")

            Strsql = "Update SteSolicitudDesembolsoProveedor Set sUsuarioModificacion =  '" & InfoSistema.LoginName & "',dFechaModificacion=getdate(), nStbEstadoSolicitudID=" & nstbestadoanulado & " Where nSteSolicitudDesembolsoProveedorID= " & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")
            'Cargar XdtFichaTmp:  
            XdtFichaTmp.ExecuteSql(Strsql)


            MsgBox("La solicitud de desembolso de pago a proveedor Fue anulada.", MsgBoxStyle.Information, NombreSistema)


            nSteSolicitudDesembolsoProveedorID = XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")
            CargarSolicitudCheque(StrCadena, 0)
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSteSolicitudDesembolsoProveedorID", nSteSolicitudDesembolsoProveedorID)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position



        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing

            XdtFichaTmp.Close()
            XdtFichaTmp = Nothing
        End Try
    End Sub

    Private Sub LlamaAutorizarSolicitud()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable

        Try

            'Dim intDiaPagosID As Integer
            'Dim intLugarEntregaCKID As Integer
            'Dim intLugarPagosID As Integer
            'Dim intPlazoPeriodoGracia As Integer
            Dim strFechaCK As String

            Dim Strsql As String = ""
            Dim intPosicion As Integer
            Dim nstbestadoanulado As Integer
            Dim nSteSolicitudDesembolsoProveedorID As Integer
            Dim intExito As Integer
            'No existen registros:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If



            'Imposible generar si existen Cheques generados y el mes contable esta Cerrado.

            Strsql = "SELECT     dbo.SteSolicitudChequeProveedor.nSteSolicitudChequeProveedorID, dbo.SteSolicitudChequeProveedor.nSteSolicitudDesembolsoProveedorID,dbo.ScnTransaccionContable.dFechaTransaccion FROM         dbo.SteSolicitudChequeProveedor INNER JOIN                       dbo.SccSolicitudCheque ON dbo.SteSolicitudChequeProveedor.nSccSolicitudChequeID = dbo.SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN                       dbo.ScnTransaccionContable ON dbo.SccSolicitudCheque.nSccSolicitudChequeID = dbo.ScnTransaccionContable.nSccSolicitudChequeID Where dbo.SteSolicitudChequeProveedor.nSteSolicitudDesembolsoProveedorID=" & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")

            'If RegistrosAsociados(Strsql) Then
            '    'If PeriodoAbiertoDadaFecha(XcDatos.ExecuteScalar(Strsql)) = False Then
            '    MsgBox("Imposible Anular Solicitud de pago a proveedor." & Chr(13) & "Existen Comprobantes generados de un mes Contable Cerrado.", MsgBoxStyle.Information)
            '    Exit Sub
            '    'End If
            'End If

            If XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno") <> 1 Then
                MsgBox("Solicitud no se encuentra en estado en proceso .", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Confirmar Anulación: 
            If MsgBox("¿Desea dar por autorizada la Solicitud de pago a proveedor?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor: 
            Me.Cursor = Cursors.WaitCursor

            Strsql = "SELECT     dbo.StbValorCatalogo.nStbValorCatalogoID  FROM         dbo.StbCatalogo INNER JOIN  dbo.StbValorCatalogo ON dbo.StbCatalogo.nStbCatalogoID = dbo.StbValorCatalogo.nStbCatalogoID WHERE     (dbo.StbCatalogo.sNombre = 'EstadoDesembolsoProveedores') AND (dbo.StbValorCatalogo.sCodigoInterno = '3')"
            XdtFichaTmp.ExecuteSql(Strsql)

            If XdtFichaTmp.Count = 0 Then
                MsgBox("No existe definido en stbvalorcatalogo el id para Autorizado de EstadoDesembolsoProveedores." & Chr(13), MsgBoxStyle.Information)
            End If
            'nstbestadoanulado = XdtFichaTmp.ValueField("nStbValorCatalogoID")



            Strsql = " EXEC spSteAutorizarSolicitudDesembolsoProveedor " & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID") & ",'" & InfoSistema.LoginName & "'" & "," & InfoSistema.IDCuenta
            intExito = XcDatos.ExecuteScalar(Strsql)

            
            If intExito = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else

                MsgBox("La Solicitud de Pago a proveedor se autorizó satisfactoriamente .", MsgBoxStyle.Information, NombreSistema)
            End If













            'Strsql = "Update SteSolicitudDesembolsoProveedor Set sUsuarioModificacion =  '" & InfoSistema.LoginName & "',dFechaModificacion=getdate(), nStbEstadoSolicitudID=" & nstbestadoanulado & " Where nSteSolicitudDesembolsoProveedorID= " & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")
            ''Cargar XdtFichaTmp:  
            'XdtFichaTmp.ExecuteSql(Strsql)


            'MsgBox("La solicitud de desembolso de pago a proveedor Fue anulada.", MsgBoxStyle.Information, NombreSistema)


            nSteSolicitudDesembolsoProveedorID = XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")
            CargarSolicitudCheque(StrCadena, 0)
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSteSolicitudDesembolsoProveedorID", nSteSolicitudDesembolsoProveedorID)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position



        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing

            XdtFichaTmp.Close()
            XdtFichaTmp = Nothing
        End Try
    End Sub

    Private Sub tbSolicitud_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSolicitud.ItemClicked
        Select Case e.ClickedItem.Name
            'Case "toolCheck"
            '    LlamaCheck(1)
            'Case "toolUnchek"
            '    LlamaCheck(0)
            'Case "toolBuscar"
            '    LlamaBuscarSolicitudes()
            Case "toolAgregar"
                LlamaAgregarSolicitud()
            Case "toolModificar"
                LlamaModificarSolicitud()
            Case "toolAnular"
                LlamaAnularSolicitud()
            Case "toolRevisar" 'autoriza las solicitudes de cheque
                LlamaAutorizarSolicitud()

                'LlamaRevisarSolicitud()
                'Case "toolGenerarCK"
                '    LlamaGenerarCheques()
                'Case "toolRefrescar"
                '    'Fechas de Corte Validas:
                '    If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                '        MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                '        Exit Sub
                '    End If
                '    If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                '        MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                '        Exit Sub
                '    End If

                '    'Fecha de Corte no mayor a la de Inicio:
                '    If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                '        MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                '        Me.cdeFechaD.Focus()
                '        Exit Sub
                '    End If

                '    REM Máximo 6 días entre la fecha de inicio y corte: Solicitado por Melania 19/Enero/2009:
                '    If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                '        MsgBox("Imposible seleccionar cortes de fecha superiores a 6 días.", MsgBoxStyle.Information)
                '        Me.cdeFechaD.Focus()
                '        Exit Sub
                '    End If

                '    InicializaVariables()
                '    CargarSolicitudCheque()
                'Case "toolGenerarChecked"
                '    LlamaGenerarChecked()
                'Case "toolActualizarConcepto"
                '    LlamaActualizarConcepto()
            Case "toolRefrescar"
                Me.CargarSolicitudCheque("", 0)
                'Case "toolImprimirTE53"

                '    LlamaImprimirTE53()
                'Case "toolImprimirTE54"

                '    LlamaImprimirTE54()
                'Case "toolImprimirTE55"

                '    LlamaImprimirTE55()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                'LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

   
    Private Sub toolImprimirTE53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTE53.Click
        LlamaImprimirTE53()
    End Sub

    Private Sub toolImprimirTE54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTE54.Click
        LlamaImprimirTE54()
    End Sub

    Private Sub toolImprimirTE55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTE55.Click
        LlamaImprimirTE55()
    End Sub

    Private Sub toolImprimirTE56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTE56.Click
        LlamaImprimirTE56()
    End Sub

    Private Sub toolImprimirTE57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTE57.Click
        LlamaImprimirTE57()
    End Sub
End Class