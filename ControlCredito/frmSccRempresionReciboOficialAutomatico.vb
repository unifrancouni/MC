Imports System.Drawing.Printing
Public Class frmSccRempresionReciboOficialAutomatico

    '- Declaración de Variables 
    Dim XdsRecibo As BOSistema.Win.XDataSet
    Dim nAccesoTotalLectura As Short
    Dim nAccesoTotalEdicion As Short
    Dim IdSclTipoRecibo As Integer
    Dim IDPersonaLugarPagosID As Integer
    Dim IdSteCaja As Integer
    Dim nStbTipoProgramaID As Integer
    Dim nStbTipoPlazoPagosID As Integer


    Public Property IdTipoRecibo() As Integer
        Get
            IdTipoRecibo = IdSclTipoRecibo
        End Get
        Set(ByVal value As Integer)
            IdSclTipoRecibo = value
        End Set
    End Property

    Private Sub tbSocia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSocia.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscar()
            Case "toolRefrescar"
                CargarRecibo(0)
                LlamaRefrescarRecibo()
                Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaBuscar()
        Dim ObjFrmSccReImpresionRecibos As New frmSccReImpresionRecibos
        Try
            Dim IdFichaNotificacion As Integer

            ObjFrmSccReImpresionRecibos.IdPersonaLugarPagosID = Me.IDPersonaLugarPagosID

            ''Agregado para filtrar por tipo de programa y tipo de plazo para diferenciar
            '' los que son Usura Cero Vs Ventana de Genero y los que son Plazo diario mercado de semanal.

            ObjFrmSccReImpresionRecibos.nStbTipoPlazoPagosID = Me.nStbTipoPlazoPagosID
            ObjFrmSccReImpresionRecibos.nStbTipoProgramaID = Me.nStbTipoProgramaID
            '' fin agregado
            ObjFrmSccReImpresionRecibos.IdConsultarDelegacion = Me.nAccesoTotalLectura
            ObjFrmSccReImpresionRecibos.IdTipoRecibo = Me.IdSclTipoRecibo

            ObjFrmSccReImpresionRecibos.ShowDialog()
            IdFichaNotificacion = ObjFrmSccReImpresionRecibos.IdFichaNotificacion

            If ObjFrmSccReImpresionRecibos.IdFichaNotificacion <> 0 Then
                CargarRecibo(IdFichaNotificacion)
            End If

            LlamaRefrescarRecibo()
            Me.tbRecibo.Enabled = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccReImpresionRecibos.Close()
            ObjFrmSccReImpresionRecibos = Nothing
        End Try
    End Sub

    Private Sub LlamaRefrescarRecibo()
        Try
            Dim strsql As String = ""

            Me.grdRecibo.ClearFields()

            If Me.grdSocia.RowCount = 0 Then
                strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo,a.nStbEstadoReciboID,a.login,a.nManual,a.nAplicado,a.nCodigoTalonario " & _
                 " From vwSccReciboSocia a Where a.nSccSolicitudChequeID = 0" & _
                 " Order by a.nCodigoRecibo ASC,a.sEstadoRecibo ASC " & _
                 " OPTION (FORCE ORDER)"
            Else
                strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo,a.nStbEstadoReciboID,a.login,a.nManual,a.nAplicado,a.nCodigoTalonario " & _
                 " From vwSccReciboSocia a Where a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID") & _
                 " Order by a.nCodigoRecibo ASC,a.sEstadoRecibo ASC " & _
                 " OPTION (FORCE ORDER)"
            End If

            If XdsRecibo.ExistTable("Recibo") Then
                XdsRecibo("Recibo").ExecuteSql(strsql)
            Else
                XdsRecibo.NewTable(strsql, "Recibo")
                XdsRecibo("Recibo").Retrieve()
            End If

            Me.grdRecibo.DataSource = XdsRecibo("Recibo").Source

            Me.grdRecibo.Rebind(False)

            FormatoDetalleRecibo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoDetalleRecibo()
        Try

            'Configuracion del Grid Recibo
            Me.grdRecibo.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nStbEstadoReciboID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nManual").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nAplicado").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nCodigoTalonario").Visible = False

            Me.grdRecibo.Splits(0).DisplayColumns("nCodigo").Width = 100
            Me.grdRecibo.Splits(0).DisplayColumns("sConceptoPago").Width = 200
            Me.grdRecibo.Splits(0).DisplayColumns("nValor").Width = 100
            Me.grdRecibo.Splits(0).DisplayColumns("sEstadoRecibo").Width = 110
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").Width = 110
            Me.grdRecibo.Splits(0).DisplayColumns("login").Width = 110

            Me.grdRecibo.Columns("nCodigo").Caption = "Código"
            Me.grdRecibo.Columns("sConceptoPago").Caption = "Concepto del Pago"
            Me.grdRecibo.Columns("nValor").Caption = "Valor"
            Me.grdRecibo.Columns("sEstadoRecibo").Caption = "Estado"
            Me.grdRecibo.Columns("dFechaRecibo").Caption = "Fecha"
            Me.grdRecibo.Columns("login").Caption = "Ingresado Por"

            Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdRecibo.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("sConceptoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("nValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("sEstadoRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdRecibo.Columns("nValor").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarRecibo(ByVal IdFichaNotificacion As Integer)
        Try
            Dim Strsql As String

            Me.grdSocia.ClearFields()

            'If IdFichaNotificacion <> 0 Then

            '****original
            Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID,a.sCodigoTipoPlanNegocio,a.CodigoPrograma As TipoPrograma , a.sCodTipoPlazoPago " & _
            " From vwSccGrupoSociaChequeEmitido a " & _
            " Where a.nSclFichaNotificacionID = " & IdFichaNotificacion & _
            " Order by a.nSclGrupoSolidarioID"

            '*****OJO PRUEBA DE IMPRESION DE RECIBO CANCELADO FECHA:15-06-2011******

            'Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID,a.sCodigoTipoPlanNegocio,a.CodigoPrograma As TipoPrograma , a.sCodTipoPlazoPago " & _
            '        " From vwSccGrupoSociaChequeEmitido1 a " & _
            '        " Where  a.nSclFichaNotificacionID = " & IdFichaNotificacion & _
            '        " Order by a.nSclGrupoSolidarioID"

            '****************************************************
            'Else
            'Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID " & _
            '         " From vwSccGrupoSociaChequeEmitido a " & _
            '         " Where a.sEstado = 'Aprobada' And a.nSclFichaNotificacionID = " & IdFichaNotificacion & _
            '         " Order by a.nSclGrupoSolidarioID"

            'If nAccesoTotalLectura = 1 Then
            '    Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID " & _
            '             " From vwSccGrupoSociaChequeEmitido a " & _
            '             " Where a.nStbEstadoSolicitudID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('4','6') And b.sNombre = 'EstadoSolicitudCheque') " & _
            '             " And a.sEstado = 'Aprobada' And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
            '             " Order by a.nSclGrupoSolidarioID"
            'Else
            '    Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID " & _
            '             " From vwSccGrupoSociaChequeEmitido a " & _
            '             " Where a.nStbEstadoSolicitudID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('4','6') And b.sNombre = 'EstadoSolicitudCheque') " & _
            '             " And a.sEstado = 'Aprobada' And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
            '             " AND a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & _
            '             " Order by a.nSclGrupoSolidarioID"
            'End If
            'End If

            If XdsRecibo.ExistTable("Socia") Then
                XdsRecibo("Socia").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Socia")
                XdsRecibo("Socia").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdSocia.DataSource = XdsRecibo("Socia").Source
            Me.grdSocia.Rebind(False)

            'Actualizando el caption de los GRIDS
            Me.grdSocia.Caption = " Listado de Socias (" + Me.grdSocia.RowCount.ToString + " registros)"

            FormatoRecibo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSccRempresionReciboOficialAutomatico_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            XdsRecibo.Close()
            XdsRecibo = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSccRempresionReciboOficialAutomatico_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()

            Me.Text = "Reimpresión de Recibo Oficial de Caja Automático"
            CargarRecibo(0)

            Me.toolRefrescar.Enabled = False
            Me.toolRefrescar.Visible = False
            Me.toolRefrescarM.Visible = False

            Call obtener_impresoras(Me.ListBoxImpresora)
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub InicializaVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            XdsRecibo = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            strSQL = " SELECT nAccesoTotalLectura,nAccesoTotalEdicion " & _
                     " FROM StbDelegacionPrograma " & _
                     " WHERE nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion

            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                nAccesoTotalLectura = XdtDatos.ValueField("nAccesoTotalLectura")
                nAccesoTotalEdicion = XdtDatos.ValueField("nAccesoTotalEdicion")
            End If

            strSQL = " SELECT nStbPersonaLugarPagosID,nSteCajaID,nStbTipoProgramaID,nStbTipoPlazoPagosID " & _
                     " FROM vwSclCajaCajero " & _
                     " WHERE ssgCuentaID = " & InfoSistema.IDCuenta & _
                     " AND nActiva = 1 "
            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                IDPersonaLugarPagosID = XdtDatos.ValueField("nStbPersonaLugarPagosID")
                IdSteCaja = XdtDatos.ValueField("nSteCajaID")
                nStbTipoProgramaID = XdtDatos.ValueField("nStbTipoProgramaID")
                nStbTipoPlazoPagosID = XdtDatos.ValueField("nStbTipoPlazoPagosID")

            End If

            'Limpiar los Grids, estructura y Datos
            Me.grdSocia.ClearFields()
            Me.grdRecibo.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub

    Private Sub FormatoRecibo()
        Try
            'Configuracion del Grid Socia
            Me.grdSocia.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("sCodigoGrupo").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("sFuente").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("sEstado").Visible = False

            Me.grdSocia.Splits(0).DisplayColumns("sNombreGrupo").Width = 150
            Me.grdSocia.Splits(0).DisplayColumns("sNombreSocia").Width = 330
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").Width = 110

            'Me.grdSocia.Splits(0).DisplayColumns("sFuente").Width = 150
            Me.grdSocia.Splits(0).DisplayColumns("sDistrito").Width = 60
            'Me.grdSocia.Splits(0).DisplayColumns("sCodigoGrupo").Width = 60
            'Me.grdSocia.Splits(0).DisplayColumns("sEstado").Width = 60

            Me.grdSocia.Columns("sNombreGrupo").Caption = "Nombre del Grupo Solidario"
            Me.grdSocia.Columns("sNombreSocia").Caption = "Nombre de la Socia"
            Me.grdSocia.Columns("sNumeroCedula").Caption = "Número Cédula"
            'Me.grdSocia.Columns("sFuente").Caption = "Fuente de Financiamiento"
            Me.grdSocia.Columns("sDistrito").Caption = "Distrito"
            'Me.grdSocia.Columns("sCodigoGrupo").Caption = "Grupo"
            'Me.grdSocia.Columns("sEstado").Caption = "Estado"

            'Me.grdSocia.Splits(0).DisplayColumns("sCodigoGrupo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSocia.Splits(0).DisplayColumns("sNombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSocia.Splits(0).DisplayColumns("sFuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSocia.Splits(0).DisplayColumns("sCodigoGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSocia.Splits(0).DisplayColumns("sEstado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSocia.Splits(0).DisplayColumns("sCodigoTipoPlanNegocio").Visible = False
            ' Me.grdSocia.Splits(0).DisplayColumns("sCodTipoPlazoPago").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("TipoPrograma").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("sCodTipoPlazoPago").Visible = False

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdSocia_RowColChange(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdSocia.RowColChange
        Dim strsql As String = ""

        LlamaRefrescarRecibo()
        Me.tbRecibo.Enabled = True

        Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"

    End Sub

    Private Sub LlamaSeleccionarImpresora()
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            grpImpresora.Visible = True
            tbSocia.Enabled = False
            tbRecibo.Enabled = False

            
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub tbRecibo_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbRecibo.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolImprimirM"
                LlamaImprimirRecibo()
            Case "toolSeleccionarImpresora"
                LlamaSeleccionarImpresora()
        End Select
    End Sub

    Private Sub LlamaImprimirRecibo()
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strsql As String = ""

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            strsql = "Select  b.dFechaCreacion, b.nManual" & _
                     " FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            XcDatos.ExecuteSql(strsql)

            If Convert.ToInt32(XcDatos.ValueField("nManual")) <> 0 Then
                MsgBox("Solo se permite la impresión de recibos automáticos.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'LlamaImprimirTicket(grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID"), 1, True, True, grdRecibo.Item(grdRecibo.Row, "login"), Convert.ToDateTime(XcDatos.ValueField("dFechaCreacion")))

            LlamaImprimirTicketImpresoraSeleccionada(grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID"), 1, True, True, grdRecibo.Item(grdRecibo.Row, "login"), Convert.ToDateTime(XcDatos.ValueField("dFechaCreacion")), Me.ListBoxImpresora.Text)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        grpImpresora.Visible = False
        tbSocia.Enabled = True
        tbRecibo.Enabled = True
    End Sub

    Public Sub obtener_impresoras(ByVal sender As Object)
        'Sender es el objeto donde se veran las impresoras
        'en este caso yo utilizo un ListBox pero podria tambien ser un ComboBox
        'un List, entre otros que sean de tipo collections
        Dim pd As New PrintDocument
        Dim i As Integer
        'Se define el print Document.
        Dim impresora_predeterminada As String = pd.PrinterSettings.PrinterName            '   ”Todo muy claro pero en ingles, se asigna en una variable el nombre
        'de la impresora predeterminada.
        For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
            'Por todas las impresoras instaladas ir agregandolas al objeto sender
            If (PrinterSettings.InstalledPrinters.Item(i).ToString().Contains("Ticket")) Then
                sender.Items.Add(PrinterSettings.InstalledPrinters.Item(i).ToString)
            End If
        Next
        For i = 0 To sender.Items.Count - 1
            If sender.Items.Item(i).ToString = impresora_predeterminada Then
                'La impresora de la lista que posea el nombre de la predeterminada
                'sera la seleccionada
                sender.SelectedIndex = i
            End If
        Next
    End Sub
End Class