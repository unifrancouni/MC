' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                22/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnComprobantesCheque.vb
' Descripción:          Formulario muestra Comprobantes de Cheques (Numero Cuenta Bancos-Consecutivo): 
'                       CK: Cheque Socias (Entrega Préstamos).
'                       CE: Comprobante de Egreso (Otros Cheques)
'-------------------------------------------------------------------------
Public Class frmScnComprobantesCheque
    '- Declaración de Variables 
    Dim XdsComprobante As BOSistema.Win.XDataSet
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       frmScnComprobantesCheque_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmScnComprobantesDiario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsComprobante.Close()
            XdsComprobante = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       frmScnComprobantesCheque_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnComprobantesDiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            'Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaD.Value = FechaServer()
            Me.cdeFechaH.Value = FechaServer()
            Me.cdeFechaD.Select()

            InicializaVariables()
            CargarComprobante()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	14/03/2008
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
    ' Fecha:                22/11/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros Delegación
            EncuentraParametros()

            XdsComprobante = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdComprobante.ClearFields()
            Me.grdDetalles.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       CargarComprobante
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarComprobante()
        Try
            Dim Strsql As String

            'CK: Cheque Socias (Entrega Préstamos).
            'CE: Comprobante de Egreso (Otros Cheques)
            'Maestro (Encabezado de Comprobantes de Diario):
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT a.* " & _
                         " FROM  vwScnComprobantesCk a " & _
                         " WHERE ((a.CodTipoCD = 'CK') OR (a.CodTipoCD = 'CE')) " & _
                         " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                         " Order by  a.sNumeroTransaccion, a.dFechaTransaccion"
            Else 'Solo Filtra las Minutas de Depósito de su Delegación:
                Strsql = " SELECT a.* " & _
                     " FROM  vwScnComprobantesCk a " & _
                     " WHERE (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And ((a.CodTipoCD = 'CK') OR (a.CodTipoCD = 'CE')) " & _
                     " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by  a.sNumeroTransaccion, a.dFechaTransaccion"
            End If

            If XdsComprobante.ExistTable("Comprobante") Then
                XdsComprobante("Comprobante").ExecuteSql(Strsql)
            Else
                XdsComprobante.NewTable(Strsql, "Comprobante")
                XdsComprobante("Comprobante").Retrieve()
            End If

            'Detalle: Cuentas Contables del Comprobante:
            Strsql = " SELECT a.* " & _
                     " FROM vwScnComprobantesDetalles a " & _
                     " WHERE ((a.CodTipoCD = 'CK') OR (a.CodTipoCD = 'CE')) " & _
                     " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.nDebito desc, a.sCodigoCuenta Option (Force Order)"

            If XdsComprobante.ExistTable("Cuentas") Then
                XdsComprobante("Cuentas").ExecuteSql(Strsql)
            Else
                XdsComprobante.NewTable(Strsql, "Cuentas")
                XdsComprobante("Cuentas").Retrieve()
            End If

            If XdsComprobante.ExistRelation("ComprobanteConCuentas") = False Then
                'Creando la relación entre el Primer Query y el Segundo
                XdsComprobante.NewRelation("ComprobanteConCuentas", "Comprobante", "Cuentas", "nScnTransaccionContableID", "nScnTransaccionContableID")
            End If

            XdsComprobante.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdComprobante.DataSource = XdsComprobante("Comprobante").Source
            Me.grdDetalles.DataSource = XdsComprobante("Cuentas").Source

            'Actualizando el caption de los GRIDS
            Me.grdComprobante.Caption = " Listado de Comprobantes de Cheque (" + Me.grdComprobante.RowCount.ToString + " registros)"
            Me.grdDetalles.Caption = " Codificación Contable Comprobante de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
            FormatoComprobante()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       FormatoComprobante
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoComprobante()
        Try

            'Configuracion del Grid Comprobante:
            Me.grdComprobante.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = True
            Me.grdComprobante.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("CodTipoCD").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("CodFuente").Visible = False
            'Codigo del Estado (1 = En Proceso), 2 = Mayorizada, 3 = Anulada:
            Me.grdComprobante.Splits(0).DisplayColumns("CodEstadoCD").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("nSccTipoSolicitudChequeID").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdComprobante.Splits(0).DisplayColumns("EstadoCD").Width = 70
            Me.grdComprobante.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 120
            Me.grdComprobante.Splits(0).DisplayColumns("CodSolicitudCK").Width = 110
            Me.grdComprobante.Splits(0).DisplayColumns("TipoSolicitudCK").Width = 200
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTransaccion").Width = 120
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTipoCambio").Width = 120
            Me.grdComprobante.Splits(0).DisplayColumns("Fuente").Width = 180
            Me.grdComprobante.Splits(0).DisplayColumns("Beneficiario").Width = 200
            Me.grdComprobante.Splits(0).DisplayColumns("sDescripcion").Width = 400

            Me.grdComprobante.Columns("EstadoCD").Caption = "Estado"
            Me.grdComprobante.Columns("sNumeroTransaccion").Caption = "Número"
            Me.grdComprobante.Columns("CodSolicitudCK").Caption = "No. Solicitud Cheque"
            Me.grdComprobante.Columns("TipoSolicitudCK").Caption = "Tipo Solicitud Cheque"
            Me.grdComprobante.Columns("dFechaTransaccion").Caption = "Fecha Comprobante"
            Me.grdComprobante.Columns("dFechaTipoCambio").Caption = "Fecha Tipo Cambio"
            Me.grdComprobante.Columns("Fuente").Caption = "Fuente de Financiamiento"
            Me.grdComprobante.Columns("Beneficiario").Caption = "Beneficiario"
            Me.grdComprobante.Columns("sDescripcion").Caption = "Descripción"

            Me.grdComprobante.Splits(0).DisplayColumns("EstadoCD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("CodSolicitudCK").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("TipoSolicitudCK").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTipoCambio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("Fuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("Beneficiario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Codificación Contable:
            Me.grdDetalles.Splits(0).DisplayColumns("nScnTransaccionContableDetalleID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nMontoC").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nMontoD").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("dFechaTransaccion").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("CodTipoCD").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("sNumeroTransaccion").Visible = False

            Me.grdDetalles.Splits(0).DisplayColumns("sCodigoCuenta").Width = 150
            Me.grdDetalles.Splits(0).DisplayColumns("sNombreCuenta").Width = 480
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").Width = 70
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").Width = 80
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").Width = 80
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").Width = 80
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").Width = 80

            Me.grdDetalles.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.grdDetalles.Columns("sNombreCuenta").Caption = "Nombre de la Cuenta"
            Me.grdDetalles.Columns("nDebito").Caption = "Débito"
            Me.grdDetalles.Columns("nDebeC").Caption = "Debe (C$)"
            Me.grdDetalles.Columns("nHaberC").Caption = "Haber (C$)"
            Me.grdDetalles.Columns("nDebeD").Caption = "Debe (US$)"
            Me.grdDetalles.Columns("nHaberD").Caption = "Haber (US$)"

            Me.grdDetalles.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Debito como checkbox y centrado:
            Me.grdDetalles.Columns("nDebito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Formato de campos Numericos:
            Me.grdDetalles.Columns("nDebeC").NumberFormat = "#,##0.00"
            Me.grdDetalles.Columns("nHaberC").NumberFormat = "#,##0.00"
            Me.grdDetalles.Columns("nDebeD").NumberFormat = "#,##0.00"
            Me.grdDetalles.Columns("nHaberD").NumberFormat = "#,##0.00"


            'Estilo para Totales en el Grid Detalles:
            Me.grdDetalles.ColumnFooters = True
            Me.grdDetalles.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            'Córdobas:
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.ForeColor = Color.Blue
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.ForeColor = Color.Blue
            'Dólares:
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").FooterStyle.ForeColor = Color.Green
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").FooterStyle.ForeColor = Color.Green
            'Color:
            Me.grdDetalles.FooterStyle.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nDebeC").Style.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nHaberC").Style.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nDebeD").Style.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nHaberD").Style.BackColor = Color.WhiteSmoke
            'Calcular montos totales de crédito solicitado y aprobado para el GS:
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       CalcularMontos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Débito y Crédito de la Jornalización.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalDebeC As Double = 0
            Dim vTotalHaberC As Double = 0
            Dim vTotalDebeD As Double = 0
            Dim vTotalHaberD As Double = 0

            For index As Integer = 0 To Me.grdDetalles.RowCount - 1
                Me.grdDetalles.Row = index
                vTotalDebeC = vTotalDebeC + Me.grdDetalles.Columns("nDebeC").Value
                vTotalHaberC = vTotalHaberC + Me.grdDetalles.Columns("nHaberC").Value
                vTotalDebeD = vTotalDebeD + Me.grdDetalles.Columns("nDebeD").Value
                vTotalHaberD = vTotalHaberD + Me.grdDetalles.Columns("nHaberD").Value
            Next
            If Me.grdDetalles.RowCount > 0 Then
                Me.grdDetalles.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdDetalles.Columns("nDebeC").FooterText = Format(vTotalDebeC, "C$ #,##0.00")
            Me.grdDetalles.Columns("nHaberC").FooterText = Format(vTotalHaberC, "C$ #,##0.00")
            Me.grdDetalles.Columns("nDebeD").FooterText = Format(vTotalDebeD, "US$ #,##0.00")
            Me.grdDetalles.Columns("nHaberD").FooterText = Format(vTotalHaberD, "US$ #,##0.00")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       tbComprobante_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbComprobante.
    '-------------------------------------------------------------------------
    Private Sub tbComprobante_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbComprobante.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarComprobante()
            Case "toolModificar"
                LlamaModificarComprobante()
            Case "toolModificarChequera"
                LlamaModificarChequera()
            Case "toolAnular"
                LlamaAnularComprobante()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                REM Máximo 6 días entre la fecha de inicio y corte: Solicitado por Melania 19/Enero/2009:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 6 días.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                InicializaVariables()
                CargarComprobante()
                'Case "toolImprimir"
                '    LlamaImprimir(0)
                'Case "toolImprimirf"
                '    LlamaImprimir(1)
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Comprobante
    '                       actual (No llama a parámetros).
    '                       nTipoImpresion = 0 (Comprobante Actual)
    '                       nTipoImpresion = 1 (Por Fechas de Corte).
    '                       nTipoImpresion = 2 (Por Rangos de Cheques).
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir(ByVal nTipoImpresion As Integer)
        Dim frmVisor As New frmCRVisorReporte
        Try

            Dim strSQL As String = ""
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If nTipoImpresion = 1 Then
                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If
                'Máximo 6 días entre la fecha de inicio y corte: Solicitado por Melania 19/Enero/2009:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 6 días.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            If RadGrande.Checked Then
                frmVisor.NombreReporte = "RepScnCN4.rpt"
            Else
                frmVisor.NombreReporte = "RepScnCN4_4cheques.rpt"
            End If


            frmVisor.Text = "Comprobante de Pago"


            If XdsComprobante("Comprobante").ValueField("nSccTipoSolicitudChequeID") <> 3 Then


                If nTipoImpresion = 0 Then
                    frmVisor.SQLQuery = "Select * From vwScnComprobantesDePago " & _
                                        "Where nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
                ElseIf nTipoImpresion = 1 Then
                    frmVisor.SQLQuery = "Select * From vwScnComprobantesDePago " & _
                                        "WHERE (dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                        "Order by NoCheque asc"
                End If
            Else

                If nTipoImpresion = 0 Then
                    frmVisor.SQLQuery = "Select * From vwScnComprobantesDePagoProveedores " & _
                                        "Where nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
                ElseIf nTipoImpresion = 1 Then
                    frmVisor.SQLQuery = "Select * From vwScnComprobantesDePagoProveedores " & _
                                        "WHERE (dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                        "Order by NoCheque asc"
                End If

            End If

            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       tbCuenta_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCuenta.
    '-------------------------------------------------------------------------
    Private Sub tbCuenta_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCuenta.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarC"
                LlamaAgregarCodificacion()
            Case "toolModificarC"
                LlamaModificarCodificacion()
            Case "toolAyudaC"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       LlamaAgregarComprobante
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditComprobante para Agregar un nuevo registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarComprobante()
        Try

            'La codificación se registra vía Solicitud de Cheque:
            MsgBox("Los Comprobantes de Cheque son generados de forma" & Chr(13) & "automática a partir de una Solicitud de Cheque Autorizada.", MsgBoxStyle.Information)
            Exit Sub

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       LlamaAgregarCodificacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCodificacion para Agregar una Jornalizacion.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCodificacion()
        Try

            Dim Strsql As String
            'No existen Comprobantes registrados:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen Comprobantes grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Comprobante esta Anulado:
            If XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'La codificación se registra vía Solicitud de Cheque:
            MsgBox("La Codificación Contable debe registrarse" & Chr(13) & "vía Solicitud de Cheque.", MsgBoxStyle.Information)
            Exit Sub

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       LlamaModificarComprobante
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditComprobante para Modificar un CD existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarComprobante()
        Dim ObjFrmScnEditComprobante As New frmScnEditCheque
        Try
            Dim Strsql As String
            ObjFrmScnEditComprobante.IntHabilito = 1
            'No existen registros:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Comprobante esta Anulado:
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Or (XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3") Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                ObjFrmScnEditComprobante.IntHabilito = 0
                'Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsComprobante("Comprobante").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                ObjFrmScnEditComprobante.IntHabilito = 0
                'Exit Sub
            End If

            'Sólo permitir modificar: Descripción, No. CUE y Observaciones:
            ObjFrmScnEditComprobante.ModoFrm = "UPD"
            ObjFrmScnEditComprobante.IdComprobante = XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditComprobante.IntCodifica = Me.grdDetalles.RowCount
            ObjFrmScnEditComprobante.IdTipoSolicitud = XdsComprobante("Comprobante").ValueField("nSccTipoSolicitudChequeID")
            ObjFrmScnEditComprobante.ShowDialog()

            CargarComprobante()
            XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditComprobante.IdComprobante)
            Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditComprobante.Close()
            ObjFrmScnEditComprobante = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/03/2009
    ' Procedure Name:       LlamaModificarChequera
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditComprobante para Modificar un número 
    '                       de cheque por parte de gestion de recursos.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarChequera()
        Dim ObjFrmScnEditComprobante As New frmScnEditCheque
        Try
            Dim Strsql As String
            ObjFrmScnEditComprobante.IntHabilito = 1
            'No existen registros:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Comprobante esta Anulado:
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Or (XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3") Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                ObjFrmScnEditComprobante.IntHabilito = 0
                'Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsComprobante("Comprobante").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                ObjFrmScnEditComprobante.IntHabilito = 0
                'Exit Sub
            End If

            'Sólo permitir modificar: No. Cheque físico.
            ObjFrmScnEditComprobante.ModoFrm = "UPDCk"
            ObjFrmScnEditComprobante.IdComprobante = XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditComprobante.IntCodifica = Me.grdDetalles.RowCount
            ObjFrmScnEditComprobante.IdTipoSolicitud = XdsComprobante("Comprobante").ValueField("nSccTipoSolicitudChequeID")
            ObjFrmScnEditComprobante.ShowDialog()

            CargarComprobante()
            XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditComprobante.IdComprobante)
            Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditComprobante.Close()
            ObjFrmScnEditComprobante = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       LlamaModificarCodificacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCodificacion para Modificar una Jornalización.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCodificacion()
        Try
            Dim Strsql As String
            'No existen Comprobantes registrados:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen Comprobantes grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Comprobante esta Anulado:
            If XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'La codificación se registra vía Solicitud de Cheque:
            MsgBox("La Codificación Contable esta basada en la" & Chr(13) & "correspondiente Solicitud de Cheque.", MsgBoxStyle.Information)
            Exit Sub

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       LlamaAnularComprobante
    ' Descripción:          Este procedimiento permite Anular un Comprobante.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularComprobante()

        Dim XcDatos As New BOSistema.Win.XComando
        Dim ComprobanteId As Long
        Try

            Dim Strsql As String
            Dim intPosicion As Integer

            'Imposible si no hay CD registrados:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'No existen Cuentas registradas:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No Existe Codificación Contable registrada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Comprobante esta Anulado:
            If XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ''Imposible si es Entrega de Cheque a Socias:
            'If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CK" Then
            '    MsgBox("Imposible Anulación manual de Comprobante de entrega de" & Chr(13) & "préstamos a Socias. Este debe Anularse desde la Ficha de" & Chr(13) & "Notificación de Crédito.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsComprobante("Comprobante").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si Codificación tiene Cuenta de Bancos con Conciliacion Activa:
            Strsql = "SELECT D.nScnTransaccionContableDetalleID " & _
                     "FROM  ScnTransaccionContableDetalle AS D INNER JOIN ScnCatalogoContable AS C ON D.nScnCatalogoContableID = C.nScnCatalogoContableID INNER JOIN  SteConciliacionTransacciones AS CT ON D.nScnTransaccionContableDetalleID = CT.nScnTransaccionContableDetalleID INNER JOIN SteConciliacionBancaria AS CB ON CT.nSteConciliacionBancariaID = CB.nSteConciliacionBancariaID INNER JOIN StbValorCatalogo ON CB.nStbEstadoConciliacionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (D.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.nSteCuentaBancariaID IS NOT NULL)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existe Conciliación Bancaria Activa.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible Transacción existe en Tabla de Conciliación Bancaria:
            Strsql = "SELECT C.nSteConciliacionTransaccionID FROM ScnTransaccionContableDetalle AS D INNER JOIN SteConciliacionTransacciones AS C ON D.nScnTransaccionContableDetalleID = C.nScnTransaccionContableDetalleID WHERE (D.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El Comprobante forma parte de una Conciliación Bancaria.", MsgBoxStyle.Information)
                Exit Sub
            End If
            REM Imposible si Anulación provoca Saldo Rojo:¿?


            'Confirmar Anulación:
            If MsgBox("¿Está seguro de Anular el Comprobante?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Anula Transaccion y revierte saldos contables:
            '(SIEMPRE: En caso de Anularse el CK la solicitud regresará a Autorizada):
            Strsql = "EXEC spScnAnularTransaccion " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & "," & InfoSistema.IDCuenta & ", " & XdsComprobante("Comprobante").ValueField("nSccSolicitudChequeID")
            'Temporal para anular cheques duplicados.
            'Strsql = "EXEC spScnAnularTransaccion " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & "," & InfoSistema.IDCuenta & ",0 "
            ComprobanteId = XcDatos.ExecuteScalar(Strsql)
            If ComprobanteId = 0 Then
                MsgBox("Comprobante NO pudo Anularse.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Comprobante Anulado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                'Almacena Pista de Auditoría:
                Call GuardarAuditoria(4, 24, "Anulación de Comprobante de Diario: " & XdsComprobante("Comprobante").ValueField("sNumeroTransaccion") & ".")
                'Guardar posición actual de la selección
                intPosicion = XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
                CargarComprobante()
                'Ubicar la selección en la posición original
                XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", intPosicion)
                Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite Salir de la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       grdComprobante_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un GS existente, al hacer doble click en
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdComprobante_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdComprobante.DoubleClick
        Try
            If Seg.HasPermission("ModificarCheque") Then
                LlamaModificarComprobante()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdComprobante_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdComprobante.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       grdComprobante_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdComprobante_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdComprobante.Filter
        Try
            XdsComprobante("Comprobante").FilterLocal(e.Condition)
            Me.grdComprobante.Caption = " Listado de Comprobantes de Cheque (" + Me.grdComprobante.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Agregar Cheque:
            If Seg.HasPermission("AgregarCheque") = False Then
                Me.tbComprobante.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbComprobante.Items("toolAgregar").Enabled = True
            End If
            'Editar Cheque:
            If Seg.HasPermission("ModificarCheque") = False Then
                Me.tbComprobante.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbComprobante.Items("toolModificar").Enabled = True
            End If
            'Editar Número de Chequera:
            If Seg.HasPermission("ModificarNumeroCheque") = False Then
                Me.tbComprobante.Items("toolModificarChequera").Enabled = False
            Else  'Habilita
                Me.tbComprobante.Items("toolModificarChequera").Enabled = True
            End If
            'Anular Cheque:
            If Seg.HasPermission("AnularCheque") = False Then
                Me.tbComprobante.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbComprobante.Items("toolAnular").Enabled = True
            End If
            'Imprimir Cheque:
            'If Seg.HasPermission("ImprimirCheque") = False Then
            '    Me.tbComprobante.Items("toolImprimir").Enabled = False
            'Else  'Habilita
            '    Me.tbComprobante.Items("toolImprimir").Enabled = True
            'End If
            If Seg.HasPermission("ImprimirCheque") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If
            'Imprimir Cheque entre fechas:
            If Seg.HasPermission("ImprimirCheque") Then
                Me.toolImprimirf.Enabled = True
            Else
                Me.toolImprimirf.Enabled = False
            End If
            'Imprimir Cheque entre numeros de cheque:
            If Seg.HasPermission("ImprimirCheque") Then
                Me.toolImprimirN.Enabled = True
            Else
                Me.toolImprimirN.Enabled = False
            End If

            '-- *****************************************************
            'Agregar Codificación:
            If Seg.HasPermission("AgregarCuentasCheque") = False Then
                Me.tbCuenta.Items("toolAgregarC").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolAgregarC").Enabled = True
            End If
            'Editar Codificación:
            If Seg.HasPermission("ModificarCuentasCheque") = False Then
                Me.tbCuenta.Items("toolModificarC").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolModificarC").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       grdComprobante_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Cuentas con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdComprobante_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdComprobante.RowColChange
        Me.grdDetalles.Caption = " Codificación Contable Comprobante de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
        CalcularMontos()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       grdSocias_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Codificación Contable, al hacer doble 
    '                       click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDetalles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalles.DoubleClick
        Try
            If Seg.HasPermission("ModificarCuentasCheque") Then
                LlamaModificarCodificacion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdDetalles_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDetalles.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/11/2007
    ' Procedure Name:       grdDetalles_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetalles.Filter
        Try
            XdsComprobante("Cuentas").FilterLocal(e.Condition)
            Me.grdDetalles.Caption = " Codificación Contable Comprobante de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimir.Click
        Try
            LlamaImprimir(0)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolImprimirf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirf.Click
        Try
            LlamaImprimir(1)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolImprimirN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirN.Click
        Dim ObjFrmParametrosCk As New FrmScnParametrosListadoCheques
        Try

            ObjFrmParametrosCk.NomRep = 2
            If RadPequeno.Checked Then
                ObjFrmParametrosCk.ModeloPequeno = 1
            Else
                ObjFrmParametrosCk.ModeloPequeno = 0
            End If

            ObjFrmParametrosCk.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmParametrosCk.Close()
            ObjFrmParametrosCk = Nothing
        End Try
    End Sub
End Class