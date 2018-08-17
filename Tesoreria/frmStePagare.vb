
Public Class frmStePagare
    '- Declaración de Variables 
    Dim XdsPagare As BOSistema.Win.XDataSet

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    'Dim StrCadena As String

    Private Sub frmStePagare_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsPagare.Close()
            XdsPagare = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStePagare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaD.Select()

            InicializaVariables()
            'StrCadena = " Where (nStePagareID=0) "
            CargarPagare()

            'REM recordar quitar el comentario antes de pasarlo a producción
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
            '-- Encuentra parámetros Delegación
            EncuentraParametros()

            XdsPagare = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdPagare.ClearFields()
            Me.grdReciboPagare.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarPagare()
        Try
            Dim Strsql As String

            Me.grdPagare.ClearFields()
            Me.grdReciboPagare.ClearFields()

            'Maestro (DETALLES DE PAGARE):
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT nStePagareID, nNumPagare, nCodigo, nTrasladoValores, sNombre, MontoPagare, dFechaInicio, dFechaVencimiento, " & _
                         " sEstadoPagare " & _
                         " FROM vwSteGridPagare " & _
                         " WHERE     (dFechaInicio >='" & Format(Me.cdeFechaD.Value, "yyyy-MM-dd") & "')" & _
                         " AND (dFechaInicio <='" & Format(Me.cdeFechaH.Value, "yyyy-MM-dd") & "')" & _
                         " ORDER BY nStePagareID "
            Else
                Strsql = " SELECT nStePagareID, nNumPagare, nCodigo, nTrasladoValores, sNombre, MontoPagare, dFechaInicio, dFechaVencimiento, " & _
                         " sEstadoPagare " & _
                         " FROM vwSteGridPagare " & _
                         " WHERE  (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And ((dFechaInicio >='" & Format(Me.cdeFechaD.Value, "yyyy-MM-dd") & "')" & _
                         " AND (dFechaInicio <='" & Format(Me.cdeFechaH.Value, "yyyy-MM-dd") & "'))" & _
                         " ORDER BY nStePagareID "
            End If
            If XdsPagare.ExistTable("Pagare") Then
                XdsPagare("Pagare").ExecuteSql(Strsql)
            Else
                XdsPagare.NewTable(Strsql, "Pagare")
                XdsPagare("Pagare").Retrieve()
            End If

            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT  nStePagareID, nSteReciboPagareID, nNumRecibo, nValor, sNumeroDeposito, sConceptoPago, " & _
                         " dFechaRecibo, sEstadoRecibo, sMotivoAnulacion,nReciboPagoNomina" & _
                         " FROM      vwSteReciboPagare " & _
                         " WHERE     (dFechaInicio >='" & Format(Me.cdeFechaD.Value, "yyyy-MM-dd") & "')" & _
                         " AND (dFechaInicio <='" & Format(Me.cdeFechaH.Value, "yyyy-MM-dd") & "')"
            Else
                'Detalle: Detalle del Recibo de un Pagare :

                Strsql = " SELECT  nStePagareID, nSteReciboPagareID, nNumRecibo, nValor, sNumeroDeposito, sConceptoPago, " & _
                         " dFechaRecibo, sEstadoRecibo, sMotivoAnulacion,nReciboPagoNomina " & _
                         " FROM vwSteReciboPagare " & _
                         " WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                         " AND ((dFechaInicio >='" & Format(Me.cdeFechaD.Value, "yyyy-MM-dd") & "')" & _
                         " AND (dFechaInicio <='" & Format(Me.cdeFechaH.Value, "yyyy-MM-dd") & "'))"
            End If

                If XdsPagare.ExistTable("ReciboPagare") Then
                    XdsPagare("ReciboPagare").ExecuteSql(Strsql)
                Else
                    XdsPagare.NewTable(Strsql, "ReciboPagare")
                    XdsPagare("ReciboPagare").Retrieve()
                End If

                If XdsPagare.ExistRelation("PagareConReciboPagare") = False Then
                    'Creando la relación entre el Primer Query y el Segundo
                    XdsPagare.NewRelation("PagareConReciboPagare", "Pagare", "ReciboPagare", "nStePagareID", "nStePagareID")
                End If

                XdsPagare.SincronizarRelaciones()

                'Asignando a las fuentes de datos
            Me.grdPagare.DataSource = XdsPagare("Pagare").Source
            Me.grdPagare.Rebind(False)

            Me.grdReciboPagare.DataSource = XdsPagare("ReciboPagare").Source
            Me.grdReciboPagare.Rebind(False)

                'Actualizando el caption de los GRIDS
            Me.grdPagare.Caption = " Listado de Pagarés (" + Me.grdPagare.RowCount.ToString + " registros)"
            Me.grdReciboPagare.Caption = " Listado de Recibos aplicados a un Pagaré (" + Me.grdReciboPagare.RowCount.ToString + " registros)"
                FormatoComprobante()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       FormatoComprobante
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoComprobante()
        Try

            'Configuracion del Grid de Pagare:
            Me.grdPagare.Splits(0).DisplayColumns("nStePagareID").Visible = False

            Me.grdPagare.Splits(0).DisplayColumns("nCodigo").Width = 90
            Me.grdPagare.Splits(0).DisplayColumns("nNumPagare").Width = 90
            Me.grdPagare.Splits(0).DisplayColumns("sNombre").Width = 180
            Me.grdPagare.Splits(0).DisplayColumns("MontoPagare").Width = 110
            Me.grdPagare.Splits(0).DisplayColumns("dFechaInicio").Width = 110
            Me.grdPagare.Splits(0).DisplayColumns("dFechaVencimiento").Width = 110
            Me.grdPagare.Splits(0).DisplayColumns("nTrasladoValores").Width = 90
            Me.grdPagare.Splits(0).DisplayColumns("sEstadoPagare").Width = 90

            Me.grdPagare.Columns("nCodigo").Caption = "Código Arqueo"
            Me.grdPagare.Columns("nNumPagare").Caption = "Número Pagaré"
            Me.grdPagare.Columns("sNombre").Caption = "Nombre del Cajero"
            Me.grdPagare.Columns("MontoPagare").Caption = "Monto C$"
            Me.grdPagare.Columns("dFechaInicio").Caption = "Fecha Inicio"
            Me.grdPagare.Columns("dFechaVencimiento").Caption = "Fecha Vencimiento"
            Me.grdPagare.Columns("nTrasladoValores").Caption = "Traslado Valores"
            Me.grdPagare.Columns("sEstadoPagare").Caption = "Estado"

            Me.grdPagare.Columns("nTrasladoValores").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdPagare.Splits(0).DisplayColumns("nTrasladoValores").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdPagare.Splits(0).DisplayColumns("nNumPagare").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdPagare.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdPagare.Splits(0).DisplayColumns("dFechaInicio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("dFechaVencimiento").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdPagare.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("nNumPagare").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("MontoPagare").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("dFechaInicio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("dFechaVencimiento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("nTrasladoValores").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPagare.Splits(0).DisplayColumns("sEstadoPagare").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdPagare.Columns("MontoPagare").NumberFormat = "#,##0.00"

            'Me.grdReciboPagare.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.grdReciboPagare.Splits(0).DisplayColumns("nSteReciboPagareID").Visible = False
            Me.grdReciboPagare.Splits(0).DisplayColumns("nStePagareID").Visible = False
            Me.grdReciboPagare.Splits(0).DisplayColumns("nNumRecibo").Width = 90
            Me.grdReciboPagare.Splits(0).DisplayColumns("nValor").Width = 90
            Me.grdReciboPagare.Splits(0).DisplayColumns("sNumeroDeposito").Width = 90
            Me.grdReciboPagare.Splits(0).DisplayColumns("sConceptoPago").Width = 180
            Me.grdReciboPagare.Splits(0).DisplayColumns("dFechaRecibo").Width = 90
            Me.grdReciboPagare.Splits(0).DisplayColumns("sEstadoRecibo").Width = 90
            Me.grdReciboPagare.Splits(0).DisplayColumns("nReciboPagoNomina").Width = 90
            Me.grdReciboPagare.Splits(0).DisplayColumns("sMotivoAnulacion").Width = 200

            Me.grdReciboPagare.Columns("nNumRecibo").Caption = "Número Recibo"
            Me.grdReciboPagare.Columns("nValor").Caption = "Monto C$"
            Me.grdReciboPagare.Columns("sNumeroDeposito").Caption = "Número Minuta"
            Me.grdReciboPagare.Columns("sConceptoPago").Caption = "Concepto de Pago"
            Me.grdReciboPagare.Columns("dFechaRecibo").Caption = "Fecha Recibo"
            Me.grdReciboPagare.Columns("sEstadoRecibo").Caption = "Estado Recibo"
            Me.grdReciboPagare.Columns("nReciboPagoNomina").Caption = "Pago por Nómina"
            Me.grdReciboPagare.Columns("nReciboPagoNomina").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdReciboPagare.Splits(0).DisplayColumns("nReciboPagoNomina").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdReciboPagare.Columns("sMotivoAnulacion").Caption = "Motivo de Anulación"

            Me.grdReciboPagare.Splits(0).DisplayColumns("nNumRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReciboPagare.Splits(0).DisplayColumns("nValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReciboPagare.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReciboPagare.Splits(0).DisplayColumns("sConceptoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReciboPagare.Splits(0).DisplayColumns("dFechaRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReciboPagare.Splits(0).DisplayColumns("sEstadoRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReciboPagare.Splits(0).DisplayColumns("sMotivoAnulacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
          
            Me.grdReciboPagare.Columns("nValor").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub tbPagare_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbPagare.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAnularPagare"
                LlamaAnularPagare()
            Case "toolRefrescarPagare"

                'Fechas de Corte Validas:
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                'Máximo 31 días entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                CargarPagare()

            Case "toolImprimirPagare"
                LlamaImprimirPagare()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    Private Sub LlamaImprimirPagare()
        Dim frmVisor As New frmCRVisorReporte
        Try
            If Me.grdPagare.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.NombreReporte = "RepSteTE38.rpt"
            frmVisor.Text = "Pagaré"
            frmVisor.RegistrosSeleccion = "{vwSclPagareFondoNoPresupuestarioRep.nStePagareID}=" & XdsPagare("Pagare").ValueField("nStePagareID")
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub LlamaImprimirRecibo()
        Try
            If Me.grdReciboPagare.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            LlamaImprimirTicketPagare(XdsPagare("ReciboPagare").ValueField("nSteReciboPagareID"), 1, True)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub tbReciboPagare_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReciboPagare.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarRecibo"
                LlamaAgregarReciboPagare()
            Case "toolAnularRecibo"
                LlamaAnularReciboPagare()
            Case "toolImprimirRecibo"
                LlamaImprimirRecibo()
            Case "toolAyudaC"
                LlamaAyuda()
        End Select
    End Sub

    Private Sub LlamaAgregarReciboPagare()
        Dim ObjFrmSteEditReciboPagare As New frmSteEditReciboPagare
        Try
            Dim strsql As String = ""

            If Me.grdPagare.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si está Anulado: 
            strsql = "SELECT StePagare.nStePagareID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN StePagare ON C.nStbValorCatalogoID = StePagare.nStbEstadoPagareID " & _
                     "WHERE (C.sCodigoInterno = '3') AND (StePagare.nStePagareID = " & XdsPagare("Pagare").ValueField("nStePagareID") & ")"
            If (RegistrosAsociados(strsql) = True) Then
                MsgBox("Pagaré se encuentra Anulado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Valida si ya está Cancelado: 
            strsql = "SELECT StePagare.nStePagareID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN StePagare ON C.nStbValorCatalogoID = StePagare.nStbEstadoPagareID " & _
                     "WHERE (C.sCodigoInterno = '2') AND (StePagare.nStePagareID = " & XdsPagare("Pagare").ValueField("nStePagareID") & ")"
            If (RegistrosAsociados(strsql) = True) Then
                MsgBox("Pagaré ya se encuentra Cancelado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSteEditReciboPagare.ModoFrm = "ADD"
            ObjFrmSteEditReciboPagare.intStePermiteEditar = IntPermiteEditar
            ObjFrmSteEditReciboPagare.IdPagare = XdsPagare("Pagare").ValueField("nStePagareID")
            ObjFrmSteEditReciboPagare.ShowDialog()

            If ObjFrmSteEditReciboPagare.IdReciboPagare <> 0 Then
                CargarPagare()
                XdsPagare("Pagare").SetCurrentByID("nStePagareID", ObjFrmSteEditReciboPagare.IdPagare)
                Me.grdPagare.Row = XdsPagare("Pagare").BindingSource.Position

                'XdsCierre("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditCierreCaja.IdReciboOficialCaja)
                'Me.grdDetalleCierre.Row = XdsCierre("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditReciboPagare.Close()
            ObjFrmSteEditReciboPagare = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaAnularComprobante
    ' Descripción:          Este procedimiento permite Anular un Comprobante.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularPagare()

        Dim XcDatos As New BOSistema.Win.XComando

        Dim intPagareID As Integer
        Dim Strsql As String = ""
        Dim intPeriodoID As Integer

        Try
            If Me.grdPagare.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si ya esta Anulado: 
            Strsql = "SELECT StePagare.nStePagareID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN StePagare ON C.nStbValorCatalogoID = StePagare.nStbEstadoPagareID " & _
                     "WHERE (C.sCodigoInterno = '3') AND (StePagare.nStePagareID = " & XdsPagare("Pagare").ValueField("nStePagareID") & ")"
            If (RegistrosAsociados(Strsql) = True) Then
                MsgBox("Pagaré se encuentra Anulado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Valida si existen recibos activos asociados 
            Strsql = " SELECT nSteReciboPagareID " & _
                     " FROM vwSteReciboPagare " & _
                     " WHERE (sCodEstadoRecibo = '1') AND (nStePagareID = " & XdsPagare("Pagare").ValueField("nStePagareID") & ")"
            If (RegistrosAsociados(Strsql) = True) Then
                MsgBox("Pagaré tiene Recibos Generados.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Validar que la Fecha Inicio del Pagaré no sea de un Período Contable Cerrado
            intPeriodoID = IDPeriodo(XdsPagare("Pagare").ValueField("dFechaInicio"))
            If PeriodoAbierto(intPeriodoID) = False Then
                MsgBox("Imposible Anular el Pagaré." & Chr(10) & _
                       "Período Contable Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                Strsql = " EXEC spSteAnularPagare " & XdsPagare("Pagare").ValueField("nStePagareID") & "," & InfoSistema.IDCuenta

                intPagareID = XcDatos.ExecuteScalar(Strsql)

                If intPagareID = 0 Then
                    MsgBox("La Anulación del Pagare NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                                        "de forma satisfactoria.", MsgBoxStyle.Information)
                    CargarPagare()

                    XdsPagare("Pagare").SetCurrentByID("nStePagareID", intPagareID)
                    Me.grdPagare.Row = XdsPagare("Pagare").BindingSource.Position

                End If
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
    ' Procedure Name:       LlamaAnularComprobante
    ' Descripción:          Este procedimiento permite Anular un Comprobante.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularReciboPagare()

        Dim XdtPagareAnular As New BOSistema.Win.SteEntCaja.SteReciboPagareDataTable
        Dim XdrPagareAnular As New BOSistema.Win.SteEntCaja.SteReciboPagareRow
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XcDatos As New BOSistema.Win.XComando

        Dim intReciboPagareID As Integer
        Dim Strsql As String = ""
        Dim strCausaAnulacion As String
        Dim intPeriodoID As Integer
        Dim intPagareID As Integer

        Try
            intPagareID = XdsPagare("Pagare").ValueField("nStePagareID")

            ' Registros del Maestro
            If Me.grdPagare.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' Registros del detalle
            If Me.grdReciboPagare.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si ya esta Anulado: 
            Strsql = "SELECT SteReciboPagare.nSteReciboPagareID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteReciboPagare ON C.nStbValorCatalogoID = SteReciboPagare.nStbEstadoReciboID " & _
                     "WHERE (C.sCodigoInterno = '2') AND (SteReciboPagare.nSteReciboPagareID = " & XdsPagare("ReciboPagare").ValueField("nSteReciboPagareID") & ")"
            If (RegistrosAsociados(Strsql) = True) Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Validar que la Fecha del Recibo no sea de un Período Contable Cerrado
            intPeriodoID = IDPeriodo(XdsPagare("ReciboPagare").ValueField("dFechaRecibo"))
            If PeriodoAbierto(intPeriodoID) = False Then
                MsgBox("Imposible Anular el Recibo." & Chr(10) & _
                       "Período Contable Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If

            'Imposible anular si existen recibos activos superiores asociados al Pagare:
            Strsql = "SELECT SteReciboPagare.nSteReciboPagareID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteReciboPagare ON C.nStbValorCatalogoID = SteReciboPagare.nStbEstadoReciboID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteReciboPagare.nStePagareID = " & XdsPagare("Pagare").ValueField("nStePagareID") & ") AND (SteReciboPagare.nNumRecibo > " & XdsPagare("ReciboPagare").ValueField("nNumRecibo") & ")"
            If (RegistrosAsociados(Strsql) = True) Then
                MsgBox("Existen Recibos activos posteriores.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then


                'Solicita al Usuario la Causa de la Anulación
                XdtPagareAnular.Filter = "nSteReciboPagareID =" & XdsPagare("ReciboPagare").ValueField("nSteReciboPagareID")
                XdtPagareAnular.Retrieve()
                XdrPagareAnular = XdtPagareAnular.Current

                ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                ObjFrmStbDatoComplemento.strTitulo = "Anulación del Recibo"
                ObjFrmStbDatoComplemento.intAncho = XdrPagareAnular.GetColumnLenght("sMotivoAnulacion")
                ObjFrmStbDatoComplemento.strDato = ""
                ObjFrmStbDatoComplemento.strColor = "Naranja"
                ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                ObjFrmStbDatoComplemento.ShowDialog()

                strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                'Valida que se ingrese la Causa de la Anulación
                If strCausaAnulacion = "" Then

                    MsgBox("El Recibo NO PUEDE ser Anulado. Debe ingresar Causa de Anulación.", MsgBoxStyle.Critical, "SMUSURA0")
                    Exit Sub
                End If
                'spSteAnularPagare
                GuardarAuditoriaTablas(22, 2, "Modificar Recibo Pagaré Anular", XdsPagare("ReciboPagare").ValueField("nSteReciboPagareID"), InfoSistema.IDCuenta)
                Strsql = " EXEC spSteAnularReciboPagare " & XdsPagare("ReciboPagare").ValueField("nSteReciboPagareID") & "," & InfoSistema.IDCuenta & ",'" & strCausaAnulacion & "'," & XdsPagare("ReciboPagare").ValueField("nStePagareID")
            End If

            intReciboPagareID = XcDatos.ExecuteScalar(Strsql)

            If intReciboPagareID = 0 Then
                MsgBox("La Anulación del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                                    "de forma satisfactoria.", MsgBoxStyle.Information)
                CargarPagare()

                XdsPagare("Pagare").SetCurrentByID("nStePagareID", intPagareID)
                Me.grdPagare.Row = XdsPagare("Pagare").BindingSource.Position

                XdsPagare("ReciboPagare").SetCurrentByID("nSteReciboPagareID", intReciboPagareID)
                Me.grdReciboPagare.Row = XdsPagare("ReciboPagare").BindingSource.Position

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdPagare_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdPagare.Error, grdPagare.Error
        Control_Error(e.Exception)
    End Sub


    Private Sub grdPagare_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdPagare.Filter, grdPagare.Filter
        Try
            XdsPagare("Pagare").FilterLocal(e.Condition)
            Me.grdPagare.Caption = " Listado de Pagares (" + Me.grdPagare.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ''********* Permisos para el Grid de Recibos           

            'Agregar Recibo del Pagare:
            If Seg.HasPermission("AgregarReciboPagare") = False Then
                Me.tbReciboPagare.Items("toolAgregarRecibo").Enabled = False
            Else  'Habilita
                Me.tbReciboPagare.Items("toolAgregarRecibo").Enabled = True
            End If

            'Anular Recibo del Pagare:
            If Seg.HasPermission("AnularReciboPagare") = False Then
                Me.tbReciboPagare.Items("toolAnularRecibo").Enabled = False
            Else  'Habilita
                Me.tbReciboPagare.Items("toolAnularRecibo").Enabled = True
            End If

            'Imprimir Recibo del Pagare:
            If Seg.HasPermission("ImprimirReciboPagare") = False Then
                Me.tbReciboPagare.Items("toolImprimirRecibo").Enabled = False
            Else  'Habilita
                Me.tbReciboPagare.Items("toolImprimirRecibo").Enabled = True
            End If

            '-- *****************************************************
            ''********* Permisos para el Grid de Pagares   
            'Anular Pagare:
            If Seg.HasPermission("AnularPagare") = False Then
                Me.tbPagare.Items("toolAnularPagare").Enabled = False
            Else  'Habilita
                Me.tbPagare.Items("toolAnularPagare").Enabled = True
            End If

            'Imprimir Pagare:
            If Seg.HasPermission("ImprimirPagareCajeros") = False Then
                Me.tbPagare.Items("toolImprimirPagare").Enabled = False
            Else  'Habilita
                Me.tbPagare.Items("toolImprimirPagare").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdComprobante_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPagare.RowColChange, grdPagare.RowColChange
        Me.grdReciboPagare.Caption = " Listado de Recibos de Pagare (" + Me.grdReciboPagare.RowCount.ToString + " registros)"
        'CalcularMontos()
    End Sub


    Private Sub grdReciboPagare_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdReciboPagare.DoubleClick, grdReciboPagare.DoubleClick
        Try

        Catch ex As Exception

        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdDetalles_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdReciboPagare.Error, grdReciboPagare.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdSocias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdReciboPagare.Filter, grdReciboPagare.Filter
        Try
            XdsPagare("ReciboPagare").FilterLocal(e.Condition)
            Me.grdReciboPagare.Caption = " Listado de Recibos de pagare (" + Me.grdReciboPagare.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class