' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                21/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnReciboIngresoFondos.vb
' Descripci�n:          Formulario muestra Recibos de Ingreso de Fondos.
'                       Tipo de Comprobante: RC.
'-------------------------------------------------------------------------
Public Class frmScnReciboIngresoFondos
    '- Declaraci�n de Variables 
    Dim XdsRecibo As BOSistema.Win.XDataSet
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       frmScnReciboIngresoFondos_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmScnReciboIngresoFondos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsRecibo.Close()
            XdsRecibo = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       frmScnReciboIngresoFondos_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnReciboIngresoFondos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicaci�n.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaD.Select()

            InicializaVariables()
            CargarRecibo()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	14/03/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar par�metros de Delegaci�n.
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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       InicializaVariables
    ' Descripci�n:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra par�metros Delegaci�n
            EncuentraParametros()

            XdsRecibo = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdRecibo.ClearFields()
            Me.grdDetalles.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       CargarRecibo
    ' Descripci�n:          Este procedimiento permite cargar los
    '                       datos de Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibo()
        Try
            Dim Strsql As String

            'RC: Recibo de Ingreso a Caja.
            'Maestro (Encabezado de Recibos de Ingreso):
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT a.* " & _
                         " FROM  vwScnComprobantes a " & _
                         " WHERE (a.CodTipoCD = 'RC') " & _
                         " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                         " Order by a.nScnTransaccionContableID, a.dFechaTransaccion"
            Else 'Solo Filtra las Recibos de su Delegaci�n:
                Strsql = " SELECT a.* " & _
                         " FROM  vwScnComprobantes a " & _
                         " WHERE (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And (a.CodTipoCD = 'RC') " & _
                         " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                         " Order by a.nScnTransaccionContableID, a.dFechaTransaccion"
            End If

            If XdsRecibo.ExistTable("Recibo") Then
                XdsRecibo("Recibo").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Recibo")
                XdsRecibo("Recibo").Retrieve()
            End If

            'Detalle: Cuentas Contables del Recibo:
            Strsql = " SELECT a.* " & _
                     " FROM vwScnComprobantesDetalles a " & _
                     " WHERE (a.CodTipoCD = 'RC') " & _
                     " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.nDebito desc, a.sCodigoCuenta Option (Force Order)"

            If XdsRecibo.ExistTable("Cuentas") Then
                XdsRecibo("Cuentas").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Cuentas")
                XdsRecibo("Cuentas").Retrieve()
            End If

            If XdsRecibo.ExistRelation("ReciboConCuentas") = False Then
                'Creando la relaci�n entre el Primer Query y el Segundo:
                XdsRecibo.NewRelation("ReciboConCuentas", "Recibo", "Cuentas", "nScnTransaccionContableID", "nScnTransaccionContableID")
            End If

            XdsRecibo.SincronizarRelaciones()

            'Asignando a las fuentes de datos:
            Me.grdRecibo.DataSource = XdsRecibo("Recibo").Source
            Me.grdDetalles.DataSource = XdsRecibo("Cuentas").Source

            'Actualizando el caption de los GRIDS:
            Me.grdRecibo.Caption = " Listado de Recibos de Ingreso de Fondos (" + Me.grdRecibo.RowCount.ToString + " registros)"
            Me.grdDetalles.Caption = " Codificaci�n Contable Recibo de Ingreso de Fondos (" + Me.grdDetalles.RowCount.ToString + " registros)"
            FormatoRecibo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       FormatoRecibo
    ' Descripci�n:          Este procedimiento permite configurar los
    '                       datos sobre Recibos de Ingreso en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoRecibo()
        Try

            'Configuracion del Grid Recibo:
            Me.grdRecibo.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("CodTipoCD").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("CodFuente").Visible = False
            'Codigo del Estado (1 = En Proceso), 2 = Mayorizada, 3 = Anulada:
            Me.grdRecibo.Splits(0).DisplayColumns("CodEstadoCD").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaCierre").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("sNumeroDeposito").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nMontoDeposito").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdRecibo.Splits(0).DisplayColumns("EstadoCD").Width = 70
            Me.grdRecibo.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 70
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaTransaccion").Width = 110
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaTipoCambio").Width = 110
            Me.grdRecibo.Splits(0).DisplayColumns("Fuente").Width = 190
            Me.grdRecibo.Splits(0).DisplayColumns("Beneficiario").Width = 200
            Me.grdRecibo.Splits(0).DisplayColumns("sDescripcion").Width = 400

            Me.grdRecibo.Columns("EstadoCD").Caption = "Estado"
            Me.grdRecibo.Columns("sNumeroTransaccion").Caption = "N�mero"
            Me.grdRecibo.Columns("dFechaTransaccion").Caption = "Fecha Recibo"
            Me.grdRecibo.Columns("dFechaTipoCambio").Caption = "Fecha Tipo Cambio"
            Me.grdRecibo.Columns("Fuente").Caption = "Fuente de Financiamiento"
            Me.grdRecibo.Columns("Beneficiario").Caption = "Recibido De"
            Me.grdRecibo.Columns("sDescripcion").Caption = "En Concepto De"

            Me.grdRecibo.Splits(0).DisplayColumns("EstadoCD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaTipoCambio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("Fuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("Beneficiario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Codificaci�n Contable:
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

            Me.grdDetalles.Columns("sCodigoCuenta").Caption = "C�digo Cuenta"
            Me.grdDetalles.Columns("sNombreCuenta").Caption = "Nombre de la Cuenta"
            Me.grdDetalles.Columns("nDebito").Caption = "D�bito"
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
            'C�rdobas:
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.ForeColor = Color.Blue
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.ForeColor = Color.Blue
            'D�lares:
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
            'Calcular montos totales de cr�dito solicitado y aprobado para el GS:
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       CalcularMontos
    ' Descripci�n:          Este procedimiento permite Calcular el Monto
    '                       Total de D�bito y Cr�dito de la Jornalizaci�n.
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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       tbRecibo_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbRecibo.
    '-------------------------------------------------------------------------
    Private Sub tbRecibo_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbRecibo.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarRecibo()
            Case "toolModificar"
                LlamaModificarRecibo()
            Case "toolAnular"
                LlamaAnularRecibo()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte V�lidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte V�lidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                REM M�ximo 6 d�as entre la fecha de inicio y corte: Solicitado por Melania 19/Enero/2009:
                'If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                '    MsgBox("Imposible seleccionar cortes de fecha superiores a 6 d�as.", MsgBoxStyle.Information)
                '    Me.cdeFechaD.Focus()
                '    Exit Sub
                'End If

                InicializaVariables()
                CargarRecibo()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripci�n:          Este procedimiento permite Imprimir El Recibo
    '                       de Ingreso de Fondos actual.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Formulas("Parametro") = "Podria ser nScnTransaccionContableID "
            frmVisor.NombreReporte = "RepScnCN6.rpt"
            frmVisor.Text = "Recibo de Ingreso de Fondos"
            frmVisor.SQLQuery = "Select * From vwScnComprobantesDeIngresos Where nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID")
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       tbCuenta_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmScnEditReciboIngresoFondos para Agregar un registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRecibo()
        Dim ObjFrmScnEditComprobante As New frmScnEditReciboIngresoFondos
        Try

            ObjFrmScnEditComprobante.ModoFrm = "ADD"
            ObjFrmScnEditComprobante.ShowDialog()

            If ObjFrmScnEditComprobante.IdComprobante <> 0 Then
                CargarRecibo()
                'Se ubica sobre el registro recien agregado:
                XdsRecibo("Recibo").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditComprobante.IdComprobante)
                Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditComprobante.Close()
            ObjFrmScnEditComprobante = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaAgregarCodificacion
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCodificacion para Agregar una Jornalizacion.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCodificacion()
        Dim ObjFrmScnEditCuentas As New frmScnEditCodificacion
        Try
            Dim Strsql As String
            'No existen Comprobantes registrados:
            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen Comprobantes grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es de otra Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Recibos de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Recibo esta Anulado:
            If XdsRecibo("Recibo").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                    "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                    "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si ya se registro la Codificaci�n:
            If Me.grdDetalles.RowCount > 0 Then
                MsgBox("Ya se ingres� la Codificaci�n Contable.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsRecibo("Recibo").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmScnEditCuentas.ModoFrm = "ADD"
            ObjFrmScnEditCuentas.IdComprobante = XdsRecibo("Recibo").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditCuentas.ShowDialog()

            'Si se ingreso el registro correctamente:
            If ObjFrmScnEditCuentas.IdComprobante <> 0 Then
                CargarRecibo()
                'Se ubica sobre el CD:
                XdsRecibo("Recibo").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditCuentas.IdComprobante)
                Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditCuentas.Close()
            ObjFrmScnEditCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmScnEditReciboIngresoFondos para Modificar un registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRecibo()
        Dim ObjFrmScnEditComprobante As New frmScnEditReciboIngresoFondos
        Try
            Dim StrSql As String
            ObjFrmScnEditComprobante.IntHabilito = 1
            'No existen registros:
            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es de otra Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Recibos de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Recibo esta Anulado:
            StrSql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(StrSql)) Or (XdsRecibo("Recibo").ValueField("CodEstadoCD") = "3") Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information)
                ObjFrmScnEditComprobante.IntHabilito = 0
                'Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsRecibo("Recibo").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                ObjFrmScnEditComprobante.IntHabilito = 0
                'Exit Sub
            End If

            ObjFrmScnEditComprobante.ModoFrm = "UPD"
            ObjFrmScnEditComprobante.IdComprobante = XdsRecibo("Recibo").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditComprobante.IntCodifica = Me.grdDetalles.RowCount
            ObjFrmScnEditComprobante.ShowDialog()

            CargarRecibo()
            XdsRecibo("Recibo").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditComprobante.IdComprobante)
            Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditComprobante.Close()
            ObjFrmScnEditComprobante = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                23/11/2007
    ' Procedure Name:       LlamaModificarCodificacion
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCodificacion para Modificar una Jornalizaci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCodificacion()
        Dim ObjFrmScnEditCuentas As New frmScnEditCodificacion
        Try
            Dim StrSql As String
            'No existen Cuentas registradas:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es de otra Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Recibos de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Recibo esta Anulado:
            If XdsRecibo("Recibo").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(StrSql)) Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsRecibo("Recibo").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si Codificaci�n tiene Cuenta de Bancos con Conciliacion Activa:
            StrSql = "SELECT D.nScnTransaccionContableDetalleID " & _
                     "FROM  ScnTransaccionContableDetalle AS D INNER JOIN ScnCatalogoContable AS C ON D.nScnCatalogoContableID = C.nScnCatalogoContableID INNER JOIN  SteConciliacionTransacciones AS CT ON D.nScnTransaccionContableDetalleID = CT.nScnTransaccionContableDetalleID INNER JOIN SteConciliacionBancaria AS CB ON CT.nSteConciliacionBancariaID = CB.nSteConciliacionBancariaID INNER JOIN StbValorCatalogo ON CB.nStbEstadoConciliacionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (D.nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.nSteCuentaBancariaID IS NOT NULL)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existe Conciliaci�n Bancaria Activa.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmScnEditCuentas.ModoFrm = "UPD"
            ObjFrmScnEditCuentas.IdComprobante = XdsRecibo("Recibo").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditCuentas.ShowDialog()

            CargarRecibo()
            XdsRecibo("Recibo").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditCuentas.IdComprobante)
            Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditCuentas.Close()
            ObjFrmScnEditCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       LlamaAnularRecibo
    ' Descripci�n:          Este procedimiento permite Anular un Recibo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularRecibo()


        Dim XcDatos As New BOSistema.Win.XComando
        Dim ComprobanteId As Long
        Try

            Dim Strsql As String
            Dim intPosicion As Integer

            'Imposible si no hay CD registrados:
            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es de otra Delegaci�n:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Recibos de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'No existen Cuentas registradas:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No Existe Codificaci�n Contable registrada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Recibo esta Anulado:
            If XdsRecibo("Recibo").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Recibo se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsRecibo("Recibo").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si Codificaci�n tiene Cuenta de Bancos con Conciliacion Activa:
            Strsql = "SELECT D.nScnTransaccionContableDetalleID " & _
                     "FROM  ScnTransaccionContableDetalle AS D INNER JOIN ScnCatalogoContable AS C ON D.nScnCatalogoContableID = C.nScnCatalogoContableID INNER JOIN  SteConciliacionTransacciones AS CT ON D.nScnTransaccionContableDetalleID = CT.nScnTransaccionContableDetalleID INNER JOIN SteConciliacionBancaria AS CB ON CT.nSteConciliacionBancariaID = CB.nSteConciliacionBancariaID INNER JOIN StbValorCatalogo ON CB.nStbEstadoConciliacionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (D.nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.nSteCuentaBancariaID IS NOT NULL)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existe Conciliaci�n Bancaria Activa.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible Transacci�n existe en Tabla de Conciliaci�n Bancaria:
            Strsql = "SELECT C.nSteConciliacionTransaccionID FROM ScnTransaccionContableDetalle AS D INNER JOIN SteConciliacionTransacciones AS C ON D.nScnTransaccionContableDetalleID = C.nScnTransaccionContableDetalleID WHERE (D.nScnTransaccionContableID = " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El Recibo forma parte de una Conciliaci�n Bancaria.", MsgBoxStyle.Information)
                Exit Sub
            End If
            REM Imposible si Anulaci�n provoca Saldo Rojo:�?

            'Confirmar Anulacion:
            If MsgBox("�Est� seguro de Anular el Recibo de Ingreso?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Anula Transaccion y revierte saldos contables:
            Strsql = "EXEC spScnAnularTransaccion " & XdsRecibo("Recibo").ValueField("nScnTransaccionContableID") & "," & InfoSistema.IDCuenta & ", 0"
            ComprobanteId = XcDatos.ExecuteScalar(Strsql)
            If ComprobanteId = 0 Then
                MsgBox("Recibo NO pudo Anularse.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Recibo Anulado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                'Almacena Pista de Auditor�a:
                Call GuardarAuditoria(4, 24, "Anulaci�n de Recibo de Ingreso de Fondos: " & XdsRecibo("Recibo").ValueField("sNumeroTransaccion") & ".")
                'Guardar posici�n actual de la selecci�n
                intPosicion = XdsRecibo("Recibo").ValueField("nScnTransaccionContableID")
                CargarRecibo()
                'Ubicar la selecci�n en la posici�n original
                XdsRecibo("Recibo").SetCurrentByID("nScnTransaccionContableID", intPosicion)
                Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
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
    ' Fecha:                21/11/2007
    ' Procedure Name:       LlamaSalir
    ' Descripci�n:          Este procedimiento permite Salir de la opci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       LlamaAyuda
    ' Descripci�n:          Este procedimiento permite presentar la Ayuda en
    '                       L�nea al usuario. Actualmente en Construcci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       grdRecibo_DoubleClick
    ' Descripci�n:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Recibo existente, al hacer doble click en
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdRecibo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibo.DoubleClick
        Try
            If Seg.HasPermission("ModificarReciboIngresoFondos") Then
                LlamaModificarRecibo()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdRecibo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdRecibo.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       grdRecibo_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdRecibo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdRecibo.Filter
        Try
            XdsRecibo("Recibo").FilterLocal(e.Condition)
            Me.grdRecibo.Caption = " Listado de Recibos de Ingreso de Fondos (" + Me.grdRecibo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       Seguridad
    ' Descripci�n:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Agregar Recibo:
            If Seg.HasPermission("AgregarReciboIngresoFondos") = False Then
                Me.tbRecibo.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbRecibo.Items("toolAgregar").Enabled = True
            End If
            'Editar Recibo:
            If Seg.HasPermission("ModificarReciboIngresoFondos") = False Then
                Me.tbRecibo.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbRecibo.Items("toolModificar").Enabled = True
            End If
            'Anular Recibo:
            If Seg.HasPermission("AnularReciboIngresoFondos") = False Then
                Me.tbRecibo.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbRecibo.Items("toolAnular").Enabled = True
            End If
            'Imprimir Recibo:
            If Seg.HasPermission("ImprimirReciboIngresoFondos") = False Then
                Me.tbRecibo.Items("toolImprimir").Enabled = False
            Else  'Habilita
                Me.tbRecibo.Items("toolImprimir").Enabled = True
            End If
            '-- *****************************************************
            'Agregar Codificaci�n:
            If Seg.HasPermission("AgregarCuentasReciboIngresoFondos") = False Then
                Me.tbCuenta.Items("toolAgregarC").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolAgregarC").Enabled = True
            End If
            'Editar Codificaci�n:
            If Seg.HasPermission("ModificarCuentasReciboIngresoFondos") = False Then
                Me.tbCuenta.Items("toolModificarC").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolModificarC").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       grdRecibo_RowColChange
    ' Descripci�n:          Este evento permite actualizar el t�tulo del grid
    '                       de Cuentas con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdRecibo_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdRecibo.RowColChange
        Me.grdDetalles.Caption = " Codificaci�n Contable Recibo de Ingreso de Fondos (" + Me.grdDetalles.RowCount.ToString + " registros)"
        CalcularMontos()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       grdDetalles_DoubleClick
    ' Descripci�n:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Codificaci�n Contable, al hacer doble 
    '                       click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDetalles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalles.DoubleClick
        Try
            If Seg.HasPermission("ModificarCuentasReciboIngresoFondos") Then
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

    '------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                21/11/2007
    ' Procedure Name:       grdDetalles_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdDetalles_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetalles.Filter
        Try
            XdsRecibo("Cuentas").FilterLocal(e.Condition)
            Me.grdDetalles.Caption = " Codificaci�n Contable Recibo de Ingreso de Fondos (" + Me.grdDetalles.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class