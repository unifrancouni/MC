' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccReciboCajaAutomatico.vb
' Descripción:          Este formulario muestra un maestro - detalle, en el 
'                       maestro las Socias a las cuales se les ha otorgado
'                       préstamo y en el detalle los recibos de pago que se
'                       han ingresado por socia.
'-------------------------------------------------------------------------
Public Class frmSccCancelacionAnticipadaAutomatica

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

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       frmSccReciboCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccReciboCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsRecibo.Close()
            XdsRecibo = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmSccReciboCaja_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo maestro - detalle en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSccReciboCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()

            Me.Text = "Cancelación Anticipada Recibo Automático"
            CargarRecibo(0)

            Seguridad()

            Me.toolRefrescar.Enabled = False
            Me.toolRefrescar.Visible = False
            Me.toolRefrescarM.Visible = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarRecibo
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibo(ByVal IdFichaNotificacion As Integer)
        Try
            Dim Strsql As String

            Me.grdSocia.ClearFields()

            Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID ,a.sCodigoTipoPlanNegocio,a.CodigoPrograma As TipoPrograma , a.sCodTipoPlazoPago  " & _
                     " From vwSccGrupoSociaChequeEmitido a " & _
                     " Where a.sEstado = 'Aprobada' And a.nSclFichaNotificacionID = " & IdFichaNotificacion & _
                     " Order by a.nSclGrupoSolidarioID"

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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       FormatoDepartamento
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Departamentos en el Grid.
    '-------------------------------------------------------------------------
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

            Me.grdSocia.Splits(0).DisplayColumns("sDistrito").Width = 60

            Me.grdSocia.Columns("sNombreGrupo").Caption = "Nombre del Grupo Solidario"
            Me.grdSocia.Columns("sNombreSocia").Caption = "Nombre de la Socia"
            Me.grdSocia.Columns("sNumeroCedula").Caption = "Número Cédula"
            Me.grdSocia.Columns("sDistrito").Caption = "Distrito"

            Me.grdSocia.Splits(0).DisplayColumns("sNombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSocia.Splits(0).DisplayColumns("sCodigoTipoPlanNegocio").Visible = False
            ' Me.grdSocia.Splits(0).DisplayColumns("sCodTipoPlazoPago").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("TipoPrograma").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("sCodTipoPlazoPago").Visible = False


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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            XdsRecibo = New BOSistema.Win.XDataSet

            Me.toolSeparador1.Visible = False

            Control.CheckForIllegalCrossThreadCalls = False

            strSQL = " SELECT nAccesoTotalLectura,nAccesoTotalEdicion " & _
                     " FROM StbDelegacionPrograma " & _
                     " WHERE nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion

            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                nAccesoTotalLectura = XdtDatos.ValueField("nAccesoTotalLectura")
                nAccesoTotalEdicion = XdtDatos.ValueField("nAccesoTotalEdicion")
            End If

            strSQL = " SELECT nStbPersonaLugarPagosID,nSteCajaID,nStbTipoProgramaID,nStbTipoPlazoPagosID  " & _
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

            Me.toolSeparadorAutomatico.Visible = False

            Me.toolAgregarAutomatico.Visible = True
            Me.toolModificarAutomatico.Visible = True
            Me.toolEliminarAutomatico.Visible = True

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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbSocia_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbSocia.
    '-------------------------------------------------------------------------
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

    Private Sub LlamarCargaRecibo(ByVal sCadenaFiltro As String)
        Try
            CargarRecibo(0)

            LlamaRefrescarRecibo()

            Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbRecibo_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbMunicipio.
    '-------------------------------------------------------------------------
    Private Sub tbRecibo_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbRecibo.ItemClicked
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim xObligarConCajaLocal As Integer
        Dim XcDatos As New BOSistema.Win.XComando
        Dim strSQL As String = ""
        If e.ClickedItem.Name <> "toolModificarAutomatico" And e.ClickedItem.Name <> "toolAyudaM" And e.ClickedItem.Name <> "toolRefrescarM" And e.ClickedItem.Name <> "toolImprimirM" Then

            If e.ClickedItem.Name <> "toolAgregarAutomatico" Then
                If Me.grdRecibo.RowCount = 0 Then
                    MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
            
            strSQL = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 84)"
            xObligarConCajaLocal = XcDatos.ExecuteScalar(strSQL) 'Si es 1 entonces valida que la caja local este recepcionada y aplicada, sin generar el siguiente archivo de envio.


            'strSQL = " SELECT     NoEnvio, nSteCajaId, EstadoEnvio, SsgCuentaID, FechaGenera, AplicadoEnCentral  FROM         dbo.SttProcesarEnvioES WHERE     (nSteCajaId = " & IdSteCaja & ") AND (NoEnvio > 0) AND (AplicadoEnCentral = 0) "
            If xObligarConCajaLocal = 1 Then

                strSQL = " SELECT     nSclFichaNotificacionID  FROM         dbo.SttCentralFichaNotificacionCreditoEnviadas  WHERE     (nActiva = 1) AND (nSclFichaNotificacionID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionID") & ")"
                XdtDatos.ExecuteSql(strSQL)

                If XdtDatos.Count > 0 Then

                    MsgBox("No puede Agregar, Modificar o Anular Recibos. Por que Esa Ficha se encuentra en una base local enviada ." & Chr(13) & " Recuerde ingresar los recibos una vez aceptada la carga y antes de generar el siguiente envio.  ", MsgBoxStyle.Information)
                    Exit Sub


                End If
            End If
        End If

        Select Case e.ClickedItem.Name
            Case "toolAgregarAutomatico"
                LlamaAgregarReciboAutomatico(0)
            Case "toolModificarAutomatico"
                LlamaModificarReciboAutomatico(0)
            Case "toolEliminarAutomatico"
                LlamaEliminarRecibo(1)
            Case "toolRefrescarM"
                LlamaRefrescarRecibo()
            Case "toolImprimirM"
                LlamaImprimirRecibo()
            Case "toolAyudaM"
                LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaImprimirRecibo()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strsql As String = ""
            Dim dFechaServidor As Date
            Dim dFechaRecibo As Date

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Se verificar si el Estado del Recibo es diferente de Anulado
            strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            If XcDatos.ExecuteScalar(strsql) <> "3" Then
                MsgBox("Solo se permiten Imprimir Recibos Anulados.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If

            dFechaServidor = FechaServer.Date
            dFechaRecibo = XdsRecibo("Recibo").ValueField("dFechaRecibo")

            If dFechaServidor.Date <> dFechaRecibo.Date Then
                MsgBox("Fecha del Recibo Anulado a Imprimir DEBE ser Igual a la Fecha Actual.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If

            LlamaImprimirTicket(grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID"), 1, True)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub LlamaRefrescarRecibo()
        Try
            Dim strsql As String = ""

            Me.grdRecibo.ClearFields()

            If Me.grdSocia.RowCount = 0 Then
                strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo,a.nStbEstadoReciboID,a.login,a.nManual,a.nAplicado,a.nCodigoTalonario  " & _
                 " From vwSccReciboSocia a Where a.nSccSolicitudChequeID = 0" & _
                 " Order by a.nCodigoRecibo ASC,a.sEstadoRecibo ASC " & _
                 " OPTION (FORCE ORDER)"
            Else
                strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo,a.nStbEstadoReciboID,a.login,a.nManual,a.nAplicado,a.nCodigoTalonario  " & _
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditRecibo para Agregar un nuevo Recibo para una
    '                       determinadoa Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscar()
        Dim ObjFrmSclEditCedula As New frmSclEditCedula
        Try
            Dim IdFichaNotificacion As Integer

            ObjFrmSclEditCedula.nStbTipoPlazoPagosID = Me.nStbTipoPlazoPagosID
            ObjFrmSclEditCedula.nStbTipoProgramaID = Me.nStbTipoProgramaID


            ''------
            ObjFrmSclEditCedula.IdPersonaLugarPagosID = Me.IDPersonaLugarPagosID
            ObjFrmSclEditCedula.IdConsultarDelegacion = Me.nAccesoTotalLectura
            ObjFrmSclEditCedula.IdTipoRecibo = Me.IdSclTipoRecibo
            ObjFrmSclEditCedula.ShowDialog()
            IdFichaNotificacion = ObjFrmSclEditCedula.IdFichaNotificacion

            If ObjFrmSclEditCedula.IdFichaNotificacion <> 0 Then
                CargarRecibo(IdFichaNotificacion)
            End If

            LlamaRefrescarRecibo()
            Me.tbRecibo.Enabled = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditCedula.Close()
            ObjFrmSclEditCedula = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditRecibo para Agregar un nuevo Recibo para una
    '                       determinadoa Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarReciboAutomatico(ByVal IdEspecial As Short)
        Dim ObjFrmSccEditReciboCaja As New frmSccEditCancelacionAnticipadaAutomatica
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            Dim dFechaServidor As Date

            If Me.grdSocia.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            
            If XdsRecibo("Socia").ValueField("TipoPrograma") = 2 Then
                MsgBox("Esta Socia es de Ventana de Genero. Solo se acepta en recibos manuales.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XdsRecibo("Socia").ValueField("sCodTipoPlazoPago") = "D" Then
                MsgBox("Esta Socia es de Pago Mercado Diario . Solo se acepta en recibos manuales.", MsgBoxStyle.Information)
                Exit Sub
            End If


            dFechaServidor = FechaServer.Date

            'No permito Agregar si hay Cierre de Caja para el día actual
            strSQL = " SELECT nSteCierreDiarioCajaID FROM SteCierreDiarioCaja " & _
                     " WHERE convert(datetime,dFechaCierre,105) = convert(datetime,'" & dFechaServidor.Date & "',105)" & _
                     " AND nSteCajaID = " & IdSteCaja & _
                     " AND nCerrada = 1 "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("Caja Cerrada.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If

            strSQL = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
                     " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
                     " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No puede Agregar Recibos. Todas las Cuotas están Pagadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            strSQL = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Agregar Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSccEditReciboCaja.ModoFrm = "ADD"
            ObjFrmSccEditReciboCaja.IdEspecial = IdEspecial
            ObjFrmSccEditReciboCaja.IDFichaNotificacionDetalle = XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")
            ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            ObjFrmSccEditReciboCaja.ShowDialog()

            If ObjFrmSccEditReciboCaja.IdReciboOficialCaja <> 0 Then
                LlamaRefrescarRecibo()
                XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSccEditReciboCaja.IdSolicitudCheque)
                Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

                XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditReciboCaja.IdReciboOficialCaja)
                Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditReciboCaja.Close()
            ObjFrmSccEditReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditReciboCaja para Modificar un Recibo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarReciboAutomatico(ByVal IdEspecial As Short)
        Dim ObjFrmSccEditReciboCaja As New frmSccEditCancelacionAnticipadaAutomatica
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            'MsgBox("No se permite modificar recibos automaticos", MsgBoxStyle.Information)
            'Exit Sub

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Se verificar si el Estado del Recibo es Anulado
            strSQL = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            If XcDatos.ExecuteScalar(strSQL) = "3" Then
                MsgBox("El Recibo tiene Estado Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Permito mostrar los datos en la modificación, pero no modificarlos
            'si hay recibos con fecha posterior. Mando aqui mensaje de advertencia.
            strSQL = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE convert(datetime,dFechaRecibo,105) > convert(datetime,'" & XdsRecibo("Recibo").ValueField("dFechaRecibo") & "',105)" & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Modificado. Existen Recibos con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
                'Exit Sub
            End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            strSQL = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Modificar Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida que no se modifique si está Cancelado
            strSQL = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
                     " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
                     " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No puede Modificar Recibos. Crédito Cancelado.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            ObjFrmSccEditReciboCaja.ModoFrm = "UPD"
            ObjFrmSccEditReciboCaja.IdEspecial = IdEspecial
            ObjFrmSccEditReciboCaja.IDFichaNotificacionDetalle = XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")
            ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            ObjFrmSccEditReciboCaja.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditReciboCaja.Close()
            ObjFrmSccEditReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaEliminarMunicipio
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Municipio asociado a un Departamento existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRecibo(ByVal nOpcionAutomatico As Short)
        Dim XdtReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
        Dim XdrReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            Dim intPosicionSocia As Integer  'Posicion del registro seleccionado, ID de la Ficha
            Dim intPosicionRecibo As Integer
            Dim strCausaAnulacion As String
            Dim intReciboID As Integer

            If ValidaDatosAnular(nOpcionAutomatico) Then
                If MsgBox("¿Está seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                    'Solicita al Usuario la Causa de la Anulación
                    XdtReciboAnular.Filter = " nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
                    XdtReciboAnular.Retrieve()
                    XdrReciboAnular = XdtReciboAnular.Current

                    ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                    ObjFrmStbDatoComplemento.strTitulo = "Anulación del Recibo Oficial de Caja"
                    ObjFrmStbDatoComplemento.intAncho = XdrReciboAnular.GetColumnLenght("sMotivoAnulacion")
                    ObjFrmStbDatoComplemento.strDato = ""
                    ObjFrmStbDatoComplemento.strColor = "Verde"
                    ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                    ObjFrmStbDatoComplemento.ShowDialog()

                    strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                    'Valida que se ingrese la Causa de la Anulación
                    If strCausaAnulacion = "" Then

                        MsgBox("El Recibo NO PUEDE ser Anulado. Debe ingresar Causa de Anulación.", MsgBoxStyle.Critical, "SMUSURA0")
                        Exit Sub
                    End If

                    Strsql = " EXEC spSccAnularRecibo " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & "," & InfoSistema.IDCuenta & ",'" & strCausaAnulacion & "'," & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

                    intReciboID = XcDatos.ExecuteScalar(Strsql)

                    'Si el salvado se realizó de forma satisfactoria
                    'enviar mensaje informando y cerrar el formulario.
                    If intReciboID = 0 Then

                        MsgBox("La Anulación del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                    Else
                        MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                                "de forma satisfactoria.", MsgBoxStyle.Information)
                        'Guardar posición actual de la selección
                        intPosicionSocia = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
                        intPosicionRecibo = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

                        LlamaRefrescarRecibo()

                        XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", intPosicionSocia)
                        Me.grdRecibo.Row = XdsRecibo("Socia").BindingSource.Position

                        XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", intPosicionRecibo)
                        Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtReciboAnular.Close()
            XdtReciboAnular = Nothing

            XdrReciboAnular.Close()
            XdrReciboAnular = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosAnular
    ' Descripción:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de Anular un
    '                       Recibo.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAnular(ByVal nOpcionAutomatico As Short) As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim IntCodigoTalonario As Integer
        Try
            ValidaDatosAnular = True

            Dim Strsql As String
            Dim dFechaServidor As Date
            Dim dFechaRecibo As Date

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            dFechaServidor = FechaServer.Date
            dFechaRecibo = XdsRecibo("Recibo").ValueField("dFechaRecibo")

            'No permito Anular si hay Cierre de Caja para el día actual
            Strsql = " SELECT nSteCierreDiarioCajaID FROM SteCierreDiarioCaja " & _
                     " WHERE convert(datetime,dFechaCierre,105) = convert(datetime,'" & dFechaServidor.Date & "',105)" & _
                     " AND nSteCajaID = " & IdSteCaja & _
                     " AND nCerrada = 1 "

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("Caja Cerrada.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            If dFechaServidor.Date <> dFechaRecibo.Date Then
                MsgBox("Fecha del Recibo a Anular DEBE ser Igual a la Fecha Actual.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Se verificar si el Estado del Recibo es Anulado
            Strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            If XcDatos.ExecuteScalar(Strsql) = "3" Then
                MsgBox("El Recibo ya tiene Estado Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Se verificar si el Estado del Recibo es Cerrado
            Strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            If XcDatos.ExecuteScalar(Strsql) = "2" Then
                MsgBox("El Recibo NO PUEDE ser Anulado, porque actualmente tiene estado Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            Strsql = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Anular Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                ValidaDatosAnular = False
                Exit Function
            End If

            'No permito Anular si hay recibos con fecha posterior
            Strsql = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE convert(datetime,dFechaRecibo,105) > convert(datetime,'" & XdsRecibo("Recibo").ValueField("dFechaRecibo") & "',105)" & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Existen Recibos con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'No permito Anular si hay recibos posteriores
            Strsql = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE nSccReciboOficialCajaID > " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Existen Recibos posteriores.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 67)"
            IntCodigoTalonario = XcDatos.ExecuteScalar(Strsql)


            If XdsRecibo("Recibo").ValueField("nCodigoTalonario") < IntCodigoTalonario - 1 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Es menor que el penultimo tipo de talonario en el sistema ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If


            ''Valida que no se modifique si está Cancelado
            'Strsql = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
            '         " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
            '         " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            'XdtDatos.ExecuteSql(Strsql)

            'If XdtDatos.Count <= 0 Then
            '    MsgBox("No puede Anular Recibos. Crédito Cancelado.", MsgBoxStyle.Information)
            '    ValidaDatosAnular = False
            '    Exit Function
            'End If

        Catch ex As Exception
            ValidaDatosAnular = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de Departamento.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdSocia_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSocia.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdSocia_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocia_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSocia.Filter
        Try
            XdsRecibo("Socia").FilterLocal(e.Condition)

            Me.tbRecibo.Enabled = False

            Me.grdSocia.Caption = " Listado de Socias (" + Me.grdSocia.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ''            Exit Sub  ''''''''''''''''''''''''''''OJO



            ''''''''''''''''''''''''Quitar esto es momentaneo para permitir hacer todo 
            ''''''''''''''''''''''''''''OJO 


            ''''''''''''''

            ' Agregar Recibo Automático
            If Seg.HasPermission("AgregarReciboCancelacionAutomatica") Then
                Me.toolAgregarAutomatico.Enabled = True
            Else
                Me.toolAgregarAutomatico.Enabled = False
            End If

            'Modificar Recibo Automático
            If Seg.HasPermission("ModificarReciboCancelacionAutomatica") Then
                Me.toolModificarAutomatico.Enabled = True
            Else
                Me.toolModificarAutomatico.Enabled = False
            End If

            'Anular Recibo Automático
            If Seg.HasPermission("AnularReciboCancelacionAutomatica") Then
                Me.toolEliminarAutomatico.Enabled = True
            Else
                Me.toolEliminarAutomatico.Enabled = False
            End If

            'Buscar
            If Seg.HasPermission("BuscarGrupoSocia") Then
                Me.toolBuscar.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirReciboCancelacionAutomatica") Then
                Me.toolImprimirM.Enabled = True
            Else
                Me.toolImprimirM.Enabled = False
            End If

            'Imprimir Reporte CC62
            If Seg.HasPermission("ImprimirReporteCC62") Then
                Me.toolReporteCC62.Enabled = True
            Else
                Me.toolReporteCC62.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdSocia_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Recibos con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdSocia_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdSocia.RowColChange
        Dim strsql As String = ""

        LlamaRefrescarRecibo()
        Me.tbRecibo.Enabled = True

        Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"

    End Sub

    Private Sub grdRecibo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibo.DoubleClick
        Try
            If Seg.HasPermission("ModificarReciboAutomatico") And Me.tbRecibo.Enabled = True Then
                LlamaModificarReciboAutomatico(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdRecibo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdRecibo.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdRecibo_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdRecibo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdRecibo.Filter
        Try
            XdsRecibo("Recibo").FilterLocal(e.Condition)
            Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolReporteCC45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolReporteCC62.Click
        Try
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            LlamaImprimirReporteCC62()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaImprimirReporteCC62()
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Parametros("@FechaCorte") = Format(Now, "yyyy-MM-dd 00:00:00")
            frmVisor.Parametros("@FichaNotificacionDetalleId") = XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")
            frmVisor.NombreReporte = "RepSccCC62.rpt"
            frmVisor.Text = "Proyección Cancelación Anticipada"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub
End Class