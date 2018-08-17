Public Class frmSteSolicitudCajaChicaDetalle
    Dim XdsSolicitudCajaChica As BOSistema.Win.XDataSet
    Dim ModoAcc As String
    Dim sColor As String
    Dim StrCadena As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

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
    Private Sub frmSteSolicitudCajaChicaDetalle_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try

            XdsSolicitudCajaChica.Close()
            XdsSolicitudCajaChica = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()


            'Agregar Solicitud:
            If Seg.HasPermission("AgregarSolicitudCajaChica") = False Then
                Me.tbSolicitud.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAgregar").Enabled = True
            End If
            'Editar Solicitud:
            If Seg.HasPermission("ModificarSolicitudCajaChica") = False Then
                Me.tbSolicitud.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolModificar").Enabled = True
            End If
            'Anular Solicitud:
            If Seg.HasPermission("AnularSolicitudCajaChica") = False Then
                Me.tbSolicitud.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAnular").Enabled = True
            End If
            'Revisar Solicitud:
            If Seg.HasPermission("AutorizarSolicitudCajaChica") = False Then
                Me.tbSolicitud.Items("toolRevisar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolRevisar").Enabled = True
            End If
            If Seg.HasPermission("ImprimirReporteCajaChicaTE54") = False Then
                Me.toolImprimirTE54.Enabled = False
            Else  'Habilita
                Me.toolImprimirTE54.Enabled = True
            End If

            If Seg.HasPermission("ImprimirReporteCajaChicaTE57") = False Then
                Me.toolImprimirTE57.Enabled = False
            Else  'Habilita
                Me.toolImprimirTE57.Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSteSolicitudCajaChicaDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)
            'Seguridad()
            If ModoAcc = "ELA" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Registrar Solicitudes de Pago de Caja Chica")
                Me.Text = "Registrar Solicitudes de Pago de Caja Chica"
                Me.toolRevisar.Visible = False
            ElseIf ModoAcc = "AUT" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Autorización Solicitudes de Pago de Caja Chica")
                Me.Text = "Autorización Solicitudes de Pago de Caja Chica"
                Me.toolRevisar.Visible = True
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

         
            cdeFechaD.Value = FechaServer()
            cdeFechaH.Value = FechaServer()

            InicializaVariables()
            'StrCadena = " WHERE (a.nSccSolicitudChequeID = 0) " 'Al cargar Grid en Blanco
            CargarSolicitudCajaChica(StrCadena, 0)
            'Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

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


    Private Sub InicializaVariables()
        Try
            XdsSolicitudCajaChica = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los Grids, estructura y Datos:
            Me.grdSolicitud.ClearFields()


            'Determinar Parámetros de la Delegación del Usuario:
            EncuentraParametros()

            'Según usuario que accesa:
            If ModoAcc = "ELA" Then
                Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Registra solicitud de pago de Caja Chica"
                Me.Text = "Registro de Solicitudes de pagos de Caja Chica"
            ElseIf ModoAcc = "AUT" Then
                Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Autorizar Solicitud"
                Me.Text = "Autorización de Solicitudes de pago de Caja Chica"
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarSolicitudCajaChica(ByVal sCadenaFiltro As String, ByVal IntBit As Integer)
        Try
            Dim Strsql As String

            ''Limpiar los Grids, estructura y Datos:
            Me.grdSolicitud.ClearFields()


            Strsql = " SELECT a.* " & _
                               " FROM  vwSteSolicitudDesembolsoCajaChicaDetalle as a " & " WHERE (CONVERT(Varchar(10), dFechaEmision, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dFechaEmision, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) " & _
                               " Order by nCodigo " 'Option (Force Order)"


            If XdsSolicitudCajaChica.ExistTable("Solicitud") Then
                XdsSolicitudCajaChica("Solicitud").ExecuteSql(Strsql)
            Else
                XdsSolicitudCajaChica.NewTable(Strsql, "Solicitud")
                XdsSolicitudCajaChica("Solicitud").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdSolicitud.DataSource = XdsSolicitudCajaChica("Solicitud").Source
            REM REBIND
            Me.grdSolicitud.Rebind(False)

            'Actualizando el caption de los GRIDS:
            Me.grdSolicitud.Caption = " Listado de Solicitudes de caja chica (" + Me.grdSolicitud.RowCount.ToString + " registros)"
            'Me.grdDetalles.Caption = " Detalles de Solicitud de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
            FormatoSolicitudCajaChica()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub FormatoSolicitudCajaChica()
        Try
            Dim ContadorColumna As Integer
            'Configuracion del Grid Solicitudes de Cheques:
            Me.grdSolicitud.Splits(0).DisplayColumns("nSteSolicitudCajaChicaDetalleID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbTipoImpuestoID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbTipoIVAID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nSrhEmpleadoElaboraID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nSrhEmpleadoAutorizaID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbTipoALCALDIAID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbPersonaBeneficiariaID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbEstadoSolicitudID").Visible = False

            For ContadorColumna = 0 To Me.grdSolicitud.Splits(0).DisplayColumns.Count - 1
                Me.grdSolicitud.Splits(0).DisplayColumns(ContadorColumna).Locked = True
            Next

            ''Me.grdSolicitud.Splits(0).DisplayColumns("Selected").Locked = False

            Me.grdSolicitud.Splits(0).DisplayColumns("NombreBeneficiario").Width = 250
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaEmision").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicita").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpladoSolicita").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAutoriza").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.grdSolicitud.Splits(0).DisplayColumns("nNumeroRecibo").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPago").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoRetencion").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoIVA").Width = 100
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPagoTotal").Width = 100
            'Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIR").Width = 60
            'Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIVA").Width = 60
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeALCALDIA").Width = 60

            Me.grdSolicitud.Columns("NombreBeneficiario").Caption = "Beneficiario"
            Me.grdSolicitud.Columns("sConceptoPago").Caption = "Concepto de Pago"
            Me.grdSolicitud.Columns("dFechaEmision").Caption = "Fecha de emosión"
            Me.grdSolicitud.Columns("dFechaSolicita").Caption = "Fecha de solicitud"
            Me.grdSolicitud.Columns("EmpladoSolicita").Caption = "Solicitado por"
            Me.grdSolicitud.Columns("EmpleadoAutoriza").Caption = "Autorizado por"
            Me.grdSolicitud.Columns("EstadoSolicitud").Caption = "Estado"
            Me.grdSolicitud.Columns("nCodigo").Caption = "Número"
            Me.grdSolicitud.Columns("nNumeroRecibo").Caption = "Número Recibo"
            Me.grdSolicitud.Columns("nMontoPago").Caption = "Sub Total(C$)"
            Me.grdSolicitud.Columns("nMontoRetencion").Caption = "IR(C$)"
            Me.grdSolicitud.Columns("nMontoIVA").Caption = "IVA(C$)"
            Me.grdSolicitud.Columns("nMontoALCALDIA").Caption = "ACALDIA(C$)"


            Me.grdSolicitud.Columns("nMontoPagoTotal").Caption = "Total (C$)"
            'Me.grdSolicitud.Columns("PorcentajeIR").Caption = "% IR"
            'Me.grdSolicitud.Columns("PorcentajeIVA").Caption = "% IVA"
            Me.grdSolicitud.Columns("PorcentajeALCALDIA").Caption = "% ALCALDIA"


            Me.grdSolicitud.Splits(0).DisplayColumns("NombreBeneficiario").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaEmision").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicita").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpladoSolicita").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAutoriza").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nNumeroRecibo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPago").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoRetencion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoIVA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoALCALDIA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPagoTotal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            'Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIR").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            'Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIVA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            ''Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeALCALDIA").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify



            Me.grdSolicitud.Splits(0).DisplayColumns("NombreBeneficiario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaEmision").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicita").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpladoSolicita").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAutoriza").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nNumeroRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoRetencion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoIVA").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMontoPagoTotal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIR").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeIVA").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("PorcentajeALCALDIA").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center




            Me.grdSolicitud.Columns("nMontoPago").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nMontoRetencion").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nMontoIVA").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nMontoPagoTotal").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("PorcentajeALCALDIA").NumberFormat = "#,##0.00"


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaAgregarSolicitud()
        Dim ObjFrmSclEditSCC As New frmSteEditSolicitudCajaCHicaDetalle  ' frmSccEditSolicitudCheque
        Try

            'Si no es el Area Solicitante Imposible Agregar Solicitud: 
            'If ModoAcc <> "ELA" Then
            '    MsgBox("Unicamente el Area Solicitante puede registrar" & Chr(13) & "Solicitudes a Caja Chica.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmSclEditSCC.sColorFrm = "Naranja"
            ObjFrmSclEditSCC.ModoFrm = "ADD"
            'ObjFrmSclEditSCK.TipoChequeAgregar = TipoChequeAgregar
            ObjFrmSclEditSCC.ShowDialog()

            'En la adición se carga unicamente la Solicitud de Cheque recien ingresada:
            If ObjFrmSclEditSCC.intSccSolicitudID <> 0 Then
                StrCadena = "Where (a.nSteSolicitudCajaChicaDetalleID = " & ObjFrmSclEditSCC.intSccSolicitudID & ")"
                CargarSolicitudCajaChica(StrCadena, 0)
                'Se ubica sobre el registro recien agregado:
                XdsSolicitudCajaChica("Solicitud").SetCurrentByID("nSteSolicitudCajaChicaDetalleID", ObjFrmSclEditSCC.intSccSolicitudID)
                Me.grdSolicitud.Row = XdsSolicitudCajaChica("Solicitud").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSCC.Close()
            ObjFrmSclEditSCC = Nothing
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
                MsgBox("No existe definido en stbvalorcatalogo el id para anulado de EstadoDesembolsoCajaChica." & Chr(13), MsgBoxStyle.Information)
            End If

            frmVisor.Formulas("NRUC") = "'" & XdtFichaTmp.ValueField("sValorParametro") & "'"

            frmVisor.NombreReporte = "RepSteTE54CajaChica.rpt"
            frmVisor.Text = "Constancia de desembolso de pago de Caja Chica"
            frmVisor.SQLQuery = "Select * From vwSteSolicitudCajaChica Where nSteSolicitudCajaChicaDetalleID=" & XdsSolicitudCajaChica("Solicitud").ValueField("nSteSolicitudCajaChicaDetalleID")

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



            strSQL = "SELECT     sValorParametro  FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 105)"
            XdtFichaTmp.ExecuteSql(strSQL)

            If XdtFichaTmp.Count = 0 Then
                MsgBox("No existe definido en stbvalorcatalogo el id para anulado de EstadoDesembolsoCajaChica." & Chr(13), MsgBoxStyle.Information)
            End If

            frmVisor.Formulas("NRUC") = "'" & XdtFichaTmp.ValueField("sValorParametro") & "'"

            frmVisor.NombreReporte = "RepSteTE57CajaChica.rpt"
            frmVisor.CRVReportes.SelectionFormula = " {vwSteSolicitudCajaChicaFORMATOALCALDIA.nSteSolicitudCajaChicaDetalleID} =" & XdsSolicitudCajaChica("Solicitud").ValueField("nSteSolicitudCajaChicaDetalleID")

            frmVisor.Text = "Constancia de retención Alcaldía"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try



    End Sub


    Private Sub LlamaModificarSolicitud()
        Dim ObjFrmSclEditSCK As New frmSteEditSolicitudCajaCHicaDetalle ' frmSccEditSolicitudCheque
        Try

            'Si no es el Area Solicitante Imposible Agregar Solicitud: 
            If ModoAcc <> "ELA" Then
                MsgBox("Unicamente el Area Solicitante puede registrar" & Chr(13) & "Solicitudes de Caja Chica.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditSCK.sColorFrm = "Naranja"
            ObjFrmSclEditSCK.ModoFrm = "UPD"
            ObjFrmSclEditSCK.intSccSolicitudID = XdsSolicitudCajaChica("Solicitud").ValueField("nSteSolicitudCajaChicaDetalleID")
            'ObjFrmSclEditSCK.TipoChequeAgregar = TipoChequeAgregar
            ObjFrmSclEditSCK.ShowDialog()

            'En la adición se carga unicamente la Solicitud de Cheque recien ingresada:
            If ObjFrmSclEditSCK.intSccSolicitudID <> 0 Then
                StrCadena = "Where (a.nSteSolicitudCajaChicaDetalleID = " & ObjFrmSclEditSCK.intSccSolicitudID & ")"
                CargarSolicitudCajaChica(StrCadena, 0)
                'Se ubica sobre el registro recien agregado:
                XdsSolicitudCajaChica("Solicitud").SetCurrentByID("nSteSolicitudCajaChicaDetalleID", ObjFrmSclEditSCK.intSccSolicitudID)
                Me.grdSolicitud.Row = XdsSolicitudCajaChica("Solicitud").BindingSource.Position
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

            Dim Strsql As String = ""

            Dim nstbestadoanulado As Integer
            Dim nSteSolicitudCajaChicaDetalleID As Integer

            'No existen registros:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If


            If XdsSolicitudCajaChica("Solicitud").ValueField("nStbEstadoSolicitudID") = 957 Then
                MsgBox("Solicitud Se encuentra en estado anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Confirmar Anulación: 
            If MsgBox("¿Desea ANULAR la Solicitud de pago de caja chica?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
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

            Strsql = "Update SteSolicitudCajaChicaDetalle Set sUsuarioModificacion =  '" & InfoSistema.LoginName & "',dFechaModificacion=getdate(), nStbEstadoSolicitudID=" & nstbestadoanulado & " Where nSteSolicitudCajaChicaDetalleID= " & XdsSolicitudCajaChica("Solicitud").ValueField("nSteSolicitudCajaChicaDetalleID")
            ''Cargar XdtFichaTmp:  
            XdtFichaTmp.ExecuteSql(Strsql)


            MsgBox("La solicitud de desembolso de pago de caja chica Fue anulada.", MsgBoxStyle.Information, NombreSistema)


            nSteSolicitudCajaChicaDetalleID = XdsSolicitudCajaChica("Solicitud").ValueField("nSteSolicitudCajaChicaDetalleID")
            CargarSolicitudCajaChica(StrCadena, 0)
            XdsSolicitudCajaChica("Solicitud").SetCurrentByID("nSteSolicitudCajaChicaDetalleID", nSteSolicitudCajaChicaDetalleID)
            Me.grdSolicitud.Row = XdsSolicitudCajaChica("Solicitud").BindingSource.Position



        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing

        End Try
    End Sub

    Private Sub LlamaAutorizarSolicitud()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim Strsql As String = ""
            Dim nSteSolicitudCajaChicaDetalleID As Integer
            Dim intExito As Integer
            'No existen registros:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Dim valor = Convert.ToInt32(XdsSolicitudCajaChica("Solicitud").ValueField("nStbEstadoSolicitudID"))

            If XdsSolicitudCajaChica("Solicitud").ValueField("nStbEstadoSolicitudID") <> 956 Then
                MsgBox("Solicitud no se encuentra en estado en proceso .", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Confirmar Anulación: 
            If MsgBox("¿Desea dar por autorizada la Solicitud de pago de caja chica?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
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



            Strsql = " EXEC spSteAutorizarSolicitudDesembolsoCajaChica " & XdsSolicitudCajaChica("Solicitud").ValueField("nSteSolicitudCajaChicaDetalleID") & ",'" & InfoSistema.LoginName & "'" & "," & InfoSistema.IDCuenta
            intExito = XcDatos.ExecuteScalar(Strsql)


            If intExito = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else

                MsgBox("La Solicitud de Pago de Caja Chica se autorizó satisfactoriamente .", MsgBoxStyle.Information, NombreSistema)
            End If



            'Strsql = "Update SteSolicitudDesembolsoProveedor Set sUsuarioModificacion =  '" & InfoSistema.LoginName & "',dFechaModificacion=getdate(), nStbEstadoSolicitudID=" & nstbestadoanulado & " Where nSteSolicitudDesembolsoProveedorID= " & XdsSolicitudCheque("Solicitud").ValueField("nSteSolicitudDesembolsoProveedorID")
            ''Cargar XdtFichaTmp:  
            'XdtFichaTmp.ExecuteSql(Strsql)


            'MsgBox("La solicitud de desembolso de pago a proveedor Fue anulada.", MsgBoxStyle.Information, NombreSistema)


            nSteSolicitudCajaChicaDetalleID = XdsSolicitudCajaChica("Solicitud").ValueField("nSteSolicitudCajaChicaDetalleID")
            CargarSolicitudCajaChica(StrCadena, 0)
            XdsSolicitudCajaChica("Solicitud").SetCurrentByID("nSteSolicitudCajaChicaDetalleID", nSteSolicitudCajaChicaDetalleID)
            Me.grdSolicitud.Row = XdsSolicitudCajaChica("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing

        End Try
    End Sub

    Private Sub tbSolicitud_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSolicitud.ItemClicked
        Select Case e.ClickedItem.Name

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
                Me.CargarSolicitudCajaChica("", 0)
                
            Case "toolImprimirTE54"

                LlamaImprimirTE54()
            Case "toolImprimirTE57"

                LlamaImprimirTE57()
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


    Private Sub toolImprimirTE54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTE54.Click
        LlamaImprimirTE54()
    End Sub


    Private Sub toolImprimirTE57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTE57.Click
        LlamaImprimirTE57()
    End Sub

End Class