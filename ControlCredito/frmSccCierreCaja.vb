' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccCierreCaja.vb
' Descripción:          Este formulario muestra un maestro - detalle, en el 
'                       maestro las Socias a las cuales se les ha otorgado
'                       préstamo y en el detalle los recibos de pago que se
'                       han ingresado por socia.
'-------------------------------------------------------------------------
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.VisualBasic.DateAndTime
Imports System.Data.OleDb
Public Class frmSccCierreCaja

    '- Declaración de Variables:
    Dim XdsCierre As BOSistema.Win.XDataSet
    Dim sColor As String


    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       frmSccCierreCaja_FormClosing 
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccCierreCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsCierre.Close()
            XdsCierre = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmSccCierreCaja_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo maestro - detalle en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSccCierreCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarCierre()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarCierre
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCierre()
        Try

            Dim Strsql As String
            'Dim dFechaInicio As Date
            'Dim dFechaFin As Date

            'dFechaInicio = cdeFechaInicio.Value
            'dFechaFin = cdeFechaFin.Value

            Me.grdCierre.ClearFields()

            'Me.grdDetalleCierre.ClearFields()

            'PRIMERA VERSION
            'Strsql = " Select a.nSccCierreDiarioCajaID,a.dFechaCierre,a.sCodFuenteF + ' ' + a.sNombre as sCodFuenteF,a.sEstadoCierre,a.nScnFuenteFinanciamientoID " & _
            '         " From vwSccCierreDiarioCaja a " & _
            '         " WHERE (a.dFechaCierre BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "', 102)) "    '& _

            Strsql = " EXEC spSccGridCierre '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "','" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "'"

            If XdsCierre.ExistTable("Cierre") Then
                XdsCierre("Cierre").ExecuteSql(Strsql)
            Else
                XdsCierre.NewTable(Strsql, "Cierre")
                XdsCierre("Cierre").Retrieve()
            End If

            'PRIMERA VERSION
            'Strsql = " Select a.nSccCierreDiarioCajaID,a.nSccCierreDiarioCajaDetalleID,a.nSccTablaAmortizacionPagosID,a.nSccReciboOficialCajaID," & _
            '         " a.nCodigo,a.nPrincipal,a.nInteresesCorrientes,a.nMantenimientoValor,a.nInteresesMoratorios,a.nPrincipal+a.nInteresesCorrientes+a.nMantenimientoValor+a.nInteresesMoratorios as nTotal,a.sNumeroDeposito,a.dFechaDeposito,a.nSteMinutaDepositoID " & _
            '         " From vwSccCierreDiarioCajaDetalle a " & _
            '         " WHERE (a.dFechaCierre BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "', 102)) " & _
            '         " Order by a.nCodigo "

            'Strsql = " EXEC spSccGridCierre 0, '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "','" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "'"

            'If XdsCierre.ExistTable("DetalleCierre") Then
            '    XdsCierre("DetalleCierre").ExecuteSql(Strsql)
            'Else
            '    XdsCierre.NewTable(Strsql, "DetalleCierre")
            '    XdsCierre("DetalleCierre").Retrieve()
            'End If

            'If XdsCierre.ExistRelation("CierreConDetalleCierre") = False Then
            '    'Creando la relación entre el Primer Query y el Segundo
            '    XdsCierre.NewRelation("CierreConDetalleCierre", "Cierre", "DetalleCierre", "nSccCierreDiarioCajaID", "nSccCierreDiarioCajaID")
            'End If

            'XdsCierre.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdCierre.DataSource = XdsCierre("Cierre").Source
            Me.grdCierre.Rebind(False)

            'Me.grdDetalleCierre.DataSource = XdsCierre("DetalleCierre").Source
            'Me.grdDetalleCierre.Rebind(False)

            'Actualizando el caption de los GRIDS
            Me.grdCierre.Caption = " Listado de Cierres (" + Me.grdCierre.RowCount.ToString + " registros)"
            'Me.grdDetalleCierre.Caption = " Listado Detalle del Cierre (" + Me.grdDetalleCierre.RowCount.ToString + " registros)"
            FormatoCierre()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarCierre
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCierreDetalle()
        Try

            Dim Strsql As String
            'Dim dFechaInicio As Date
            'Dim dFechaFin As Date

            'dFechaInicio = cdeFechaInicio.Value
            'dFechaFin = cdeFechaFin.Value

            'Me.grdCierre.ClearFields()
            Me.grdDetalleCierre.ClearFields()


            'PRIMERA VERSION
            'Strsql = " Select a.nSccCierreDiarioCajaID,a.dFechaCierre,a.sCodFuenteF + ' ' + a.sNombre as sCodFuenteF,a.sEstadoCierre,a.nScnFuenteFinanciamientoID " & _
            '         " From vwSccCierreDiarioCaja a " & _
            '         " WHERE (a.dFechaCierre BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "', 102)) "    '& _

            'Strsql = " EXEC spSccGridCierre 1, '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "','" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "'"

            'If XdsCierre.ExistTable("Cierre") Then
            '    XdsCierre("Cierre").ExecuteSql(Strsql)
            'Else
            '    XdsCierre.NewTable(Strsql, "Cierre")
            '    XdsCierre("Cierre").Retrieve()
            'End If

            'PRIMERA VERSION
            'Strsql = " Select a.nSccCierreDiarioCajaID,a.nSccCierreDiarioCajaDetalleID,a.nSccTablaAmortizacionPagosID,a.nSccReciboOficialCajaID," & _
            '         " a.nCodigo,a.nPrincipal,a.nInteresesCorrientes,a.nMantenimientoValor,a.nInteresesMoratorios,a.nPrincipal+a.nInteresesCorrientes+a.nMantenimientoValor+a.nInteresesMoratorios as nTotal,a.sNumeroDeposito,a.dFechaDeposito,a.nSteMinutaDepositoID " & _
            '         " From vwSccCierreDiarioCajaDetalle a " & _
            '         " WHERE (a.dFechaCierre BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "', 102)) " & _
            '         " Order by a.nCodigo "

            If Me.grdCierre.RowCount = 0 Then
                Strsql = " EXEC spSccGridCierreDetalle 0"
            Else
                Strsql = " EXEC spSccGridCierreDetalle " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")
            End If

            If XdsCierre.ExistTable("DetalleCierre") Then
                XdsCierre("DetalleCierre").ExecuteSql(Strsql)
            Else
                XdsCierre.NewTable(Strsql, "DetalleCierre")
                XdsCierre("DetalleCierre").Retrieve()
            End If

            'If XdsCierre.ExistRelation("CierreConDetalleCierre") = False Then
            '    'Creando la relación entre el Primer Query y el Segundo
            '    XdsCierre.NewRelation("CierreConDetalleCierre", "Cierre", "DetalleCierre", "nSccCierreDiarioCajaID", "nSccCierreDiarioCajaID")
            'End If

            'XdsCierre.SincronizarRelaciones()

            ''Asignando a las fuentes de datos
            'Me.grdCierre.DataSource = XdsCierre("Cierre").Source
            'Me.grdCierre.Rebind(False)

            Me.grdDetalleCierre.DataSource = XdsCierre("DetalleCierre").Source
            Me.grdDetalleCierre.Rebind(False)

            'Actualizando el caption de los GRIDS
            'Me.grdCierre.Caption = " Listado de Cierres (" + Me.grdCierre.RowCount.ToString + " registros)"
            Me.grdDetalleCierre.Caption = " Listado Detalle del Cierre (" + Me.grdDetalleCierre.RowCount.ToString + " registros)"
            FormatoCierreDetalle()

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
    Private Sub FormatoCierre()
        Try
            'Configuracion del Grid Cierre
            Me.grdCierre.Splits(0).DisplayColumns("nSccCierreDiarioCajaID").Visible = False
            Me.grdCierre.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False

            Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").Width = 90
            Me.grdCierre.Splits(0).DisplayColumns("sCodFuenteF").Width = 200
            Me.grdCierre.Splits(0).DisplayColumns("sEstadoCierre").Width = 90
            'Me.grdCierre.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 90
            'Me.grdCierre.Splits(0).DisplayColumns("dFechaTransaccion").Width = 90
            'Me.grdCierre.Splits(0).DisplayColumns("sDescripcion").Width = 150

            'Me.grdCierre.Columns("nCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdCierre.Columns("dFechaCierre").Caption = "Fecha Cierre"
            Me.grdCierre.Columns("sEstadoCierre").Caption = "Estado"
            Me.grdCierre.Columns("sCodFuenteF").Caption = "Fuente"
            'Me.grdCierre.Columns("sNumeroTransaccion").Caption = "No.Transacción"
            'Me.grdCierre.Columns("sDescripcion").Caption = "Descripción Transacción"
            'Me.grdCierre.Columns("dFechaTransaccion").Caption = "F.Transacción"

            Me.grdCierre.Splits(0).DisplayColumns("sCodFuenteF").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdCierre.Splits(0).DisplayColumns("dFechaTransaccion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("sCodFuenteF").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdCierre.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdCierre.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdCierre.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierre.Splits(0).DisplayColumns("sEstadoCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            ''Configuracion del Grid Detalle Cierre
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccCierreDiarioCajaDetalleID").Visible = False
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccCierreDiarioCajaID").Visible = False
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccTablaAmortizacionPagosID").Visible = False
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = False
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False

            ''Me.grdDetalleCierre.ColumnFooters = True
            ''Me.grdDetalleCierre.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").FooterStyle.ForeColor = Color.Blue

            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.ForeColor = Color.Blue

            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.ForeColor = Color.Blue

            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.ForeColor = Color.Blue

            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").FooterStyle.ForeColor = Color.Blue

            ''Me.grdDetalleCierre.FooterStyle.BackColor = Color.WhiteSmoke

            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nNumeroCuota").Width = 80
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").Width = 120
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").Width = 110
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").Width = 110
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").Width = 110
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nCodigo").Width = 80
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("sNumeroDeposito").Width = 90
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("dFechaDeposito").Width = 90
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").Width = 120
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nMontoDeposito").Width = 120

            'Me.grdDetalleCierre.Columns("nCodigo").Caption = "No.Recibo"
            ''Me.grdDetalleCierre.Columns("nNumeroCuota").Caption = "No.Cuota"
            'Me.grdDetalleCierre.Columns("nPrincipal").Caption = "Principal"
            'Me.grdDetalleCierre.Columns("nInteresesCorrientes").Caption = "Int.Corrientes"
            'Me.grdDetalleCierre.Columns("nInteresesMoratorios").Caption = "Int.Moratorios"
            'Me.grdDetalleCierre.Columns("nMantenimientoValor").Caption = "Mantenimiento"
            'Me.grdDetalleCierre.Columns("sNumeroDeposito").Caption = "No.Depósito"
            'Me.grdDetalleCierre.Columns("dFechaDeposito").Caption = "Fecha Depósito"
            'Me.grdDetalleCierre.Columns("nTotal").Caption = "Valor Total"
            ''Me.grdDetalleCierre.Columns("nMontoDeposito").Caption = "Monto Depósito"

            ''Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nPrincipal").Style.BackColor = Color.WhiteSmoke
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nMantenimientoValor").Style.BackColor = Color.WhiteSmoke
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nInteresesCorrientes").Style.BackColor = Color.WhiteSmoke
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nInteresesMoratorios").Style.BackColor = Color.WhiteSmoke
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nTotal").Style.BackColor = Color.WhiteSmoke

            'Me.grdDetalleCierre.Splits(0).DisplayColumns("dFechaDeposito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nNumeroCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("dFechaDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ''Me.grdDetalleCierre.Splits(0).DisplayColumns("nMontoDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.grdDetalleCierre.Columns("nPrincipal").NumberFormat = "#,##0.00"
            'Me.grdDetalleCierre.Columns("nMantenimientoValor").NumberFormat = "#,##0.00"
            'Me.grdDetalleCierre.Columns("nInteresesCorrientes").NumberFormat = "#,##0.00"
            'Me.grdDetalleCierre.Columns("nInteresesMoratorios").NumberFormat = "#,##0.00"
            'Me.grdDetalleCierre.Columns("nTotal").NumberFormat = "#,##0.00"
            ''Me.grdDetalleCierre.Columns("nMontoDeposito").NumberFormat = "#,##0.00"

            'CalcularMontos()

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
    Private Sub FormatoCierreDetalle()
        Try
            ''Configuracion del Grid Cierre
            'Me.grdCierre.Splits(0).DisplayColumns("nSccCierreDiarioCajaID").Visible = False
            'Me.grdCierre.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False

            'Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").Width = 90
            'Me.grdCierre.Splits(0).DisplayColumns("sCodFuenteF").Width = 200
            'Me.grdCierre.Splits(0).DisplayColumns("sEstadoCierre").Width = 90
            ''Me.grdCierre.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 90
            ''Me.grdCierre.Splits(0).DisplayColumns("dFechaTransaccion").Width = 90
            ''Me.grdCierre.Splits(0).DisplayColumns("sDescripcion").Width = 150

            ''Me.grdCierre.Columns("nCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            'Me.grdCierre.Columns("dFechaCierre").Caption = "Fecha Cierre"
            'Me.grdCierre.Columns("sEstadoCierre").Caption = "Estado"
            'Me.grdCierre.Columns("sCodFuenteF").Caption = "Fuente"
            ''Me.grdCierre.Columns("sNumeroTransaccion").Caption = "No.Transacción"
            ''Me.grdCierre.Columns("sDescripcion").Caption = "Descripción Transacción"
            ''Me.grdCierre.Columns("dFechaTransaccion").Caption = "F.Transacción"

            'Me.grdCierre.Splits(0).DisplayColumns("sCodFuenteF").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ''Me.grdCierre.Splits(0).DisplayColumns("dFechaTransaccion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.grdCierre.Splits(0).DisplayColumns("dFechaCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdCierre.Splits(0).DisplayColumns("sCodFuenteF").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ''Me.grdCierre.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ''Me.grdCierre.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ''Me.grdCierre.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdCierre.Splits(0).DisplayColumns("sEstadoCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Detalle Cierre
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccCierreDiarioCajaDetalleID").Visible = False
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccCierreDiarioCajaID").Visible = False
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccTablaAmortizacionPagosID").Visible = False
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = False
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False

            'Me.grdDetalleCierre.ColumnFooters = True
            'Me.grdDetalleCierre.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").FooterStyle.ForeColor = Color.Blue

            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").FooterStyle.ForeColor = Color.Blue

            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").FooterStyle.ForeColor = Color.Blue

            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").FooterStyle.ForeColor = Color.Blue

            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").FooterStyle.ForeColor = Color.Blue

            'Me.grdDetalleCierre.FooterStyle.BackColor = Color.WhiteSmoke

            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nNumeroCuota").Width = 80
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").Width = 120
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").Width = 110
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").Width = 110
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").Width = 110
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nCodigo").Width = 80
            Me.grdDetalleCierre.Splits(0).DisplayColumns("sNumeroDeposito").Width = 90
            Me.grdDetalleCierre.Splits(0).DisplayColumns("dFechaDeposito").Width = 90
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").Width = 120
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nMontoDeposito").Width = 120

            Me.grdDetalleCierre.Columns("nCodigo").Caption = "No.Recibo"
            'Me.grdDetalleCierre.Columns("nNumeroCuota").Caption = "No.Cuota"
            Me.grdDetalleCierre.Columns("nPrincipal").Caption = "Principal"
            Me.grdDetalleCierre.Columns("nInteresesCorrientes").Caption = "Int.Corrientes"
            Me.grdDetalleCierre.Columns("nInteresesMoratorios").Caption = "Int.Moratorios"
            Me.grdDetalleCierre.Columns("nMantenimientoValor").Caption = "Mantenimiento"
            Me.grdDetalleCierre.Columns("sNumeroDeposito").Caption = "No.Depósito"
            Me.grdDetalleCierre.Columns("dFechaDeposito").Caption = "Fecha Depósito"
            Me.grdDetalleCierre.Columns("nTotal").Caption = "Valor Total"
            'Me.grdDetalleCierre.Columns("nMontoDeposito").Caption = "Monto Depósito"

            'Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nPrincipal").Style.BackColor = Color.WhiteSmoke
            'Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nMantenimientoValor").Style.BackColor = Color.WhiteSmoke
            'Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nInteresesCorrientes").Style.BackColor = Color.WhiteSmoke
            'Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nInteresesMoratorios").Style.BackColor = Color.WhiteSmoke
            'Me.grdDetalleCierre.Splits(0).DisplayColumns.Item("nTotal").Style.BackColor = Color.WhiteSmoke

            Me.grdDetalleCierre.Splits(0).DisplayColumns("dFechaDeposito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDetalleCierre.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nNumeroCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nPrincipal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesCorrientes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nInteresesMoratorios").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nMantenimientoValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleCierre.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleCierre.Splits(0).DisplayColumns("dFechaDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleCierre.Splits(0).DisplayColumns("nTotal").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdDetalleCierre.Splits(0).DisplayColumns("nMontoDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDetalleCierre.Columns("nPrincipal").NumberFormat = "#,##0.00"
            Me.grdDetalleCierre.Columns("nMantenimientoValor").NumberFormat = "#,##0.00"
            Me.grdDetalleCierre.Columns("nInteresesCorrientes").NumberFormat = "#,##0.00"
            Me.grdDetalleCierre.Columns("nInteresesMoratorios").NumberFormat = "#,##0.00"
            Me.grdDetalleCierre.Columns("nTotal").NumberFormat = "#,##0.00"
            'Me.grdDetalleCierre.Columns("nMontoDeposito").NumberFormat = "#,##0.00"

            'CalcularMontos()

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
    Private Sub CalcularMontos()
        Try
            'Dim vTotalPrincipal As Double = 0
            'Dim vTotalMantenimientoValor As Double = 0
            'Dim vTotalInteresesCorrientes As Double = 0
            'Dim vTotalInteresesMoratorios As Double = 0
            Dim vTotal As Double = 0

            For index As Integer = 0 To Me.grdDetalleCierre.RowCount - 1
                Me.grdDetalleCierre.Row = index
                'vTotalPrincipal = vTotalPrincipal + Me.grdDetalleCierre.Columns("nPrincipal").Value
                'vTotalMantenimientoValor = vTotalMantenimientoValor + Me.grdDetalleCierre.Columns("nMantenimientoValor").Value
                'vTotalInteresesCorrientes = vTotalInteresesCorrientes + Me.grdDetalleCierre.Columns("nInteresesCorrientes").Value
                'vTotalInteresesMoratorios = vTotalInteresesMoratorios + Me.grdDetalleCierre.Columns("nInteresesMoratorios").Value
                vTotal = vTotal + Me.grdDetalleCierre.Columns("nTotal").Value
            Next
            If Me.grdDetalleCierre.RowCount > 0 Then
                Me.grdDetalleCierre.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            'Me.grdDetalleCierre.Columns("nPrincipal").FooterText = Format(vTotalPrincipal, "#,##0.00")
            'Me.grdDetalleCierre.Columns("nMantenimientoValor").FooterText = Format(vTotalMantenimientoValor, "#,##0.00")
            'Me.grdDetalleCierre.Columns("nInteresesCorrientes").FooterText = Format(vTotalInteresesCorrientes, "#,##0.00")
            'Me.grdDetalleCierre.Columns("nInteresesMoratorios").FooterText = Format(vTotalInteresesMoratorios, "#,##0.00")
            Me.grdDetalleCierre.Columns("nTotal").FooterText = Format(vTotal, "#,##0.00")

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
        Try
            XdsCierre = New BOSistema.Win.XDataSet

            Me.toolAgregarM.Visible = False
            Me.toolModificarM.Visible = False
            Me.toolEliminarM.Visible = False
            Me.toolSeparadorM.Visible = False
            Me.toolRefrescarM.Visible = False
            Me.tbDetalleCierre.Visible = True

            'Limpiar los Grids, estructura y Datos
            Me.grdCierre.ClearFields()
            Me.grdDetalleCierre.ClearFields()

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            cdeFechaInicio.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            cdeFechaFin.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))     'CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbCierreMaestro_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbSocia.
    '-------------------------------------------------------------------------
    Private Sub tbCierreMaestro_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCierreMaestro.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCierre()
            Case "toolModificar"
                LlamaModificarCierre()
            Case "toolEliminar"
                LlamaEliminarCierre()
            Case "toolAplicar"
                LlamaAplicar()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Not IsDate(cdeFechaInicio.Value)) Or (Not IsDate(cdeFechaFin.Value)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Fecha de Corte no mayor a la de Inicio:
                If cdeFechaInicio.Text <> cdeFechaFin.Text Then
                    MsgBox("Fecha de Inicio DEBE ser igual a la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaInicio.Focus()
                    Exit Sub
                End If

                ''Fecha de Corte no mayor a la de Inicio:
                'If cdeFechaInicio.Value > cdeFechaFin.Value Then
                '    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                '    Me.cdeFechaInicio.Focus()
                '    Exit Sub
                'End If

                ''Fecha de Corte no mayor a la de Inicio:
                'If cdeFechaFin.Value <> cdeFechaFin.Value) Then
                '    MsgBox("Prueba.", MsgBoxStyle.Information)
                '    Me.cdeFechaInicio.Focus()
                '    Exit Sub
                'End If

                'InicializaVariables()
                CargarCierre()
                CargarCierreDetalle()

                'CalcularMontos()
                'Case "toolImprimir"
                '    LlamaImprimir()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    Private Function EjecutarComandoPasar(ByVal connectionString As String, ByVal queryString As String) As String
        'Dim queryString As String = _
        '    "SELECT OrderID, CustomerID FROM dbo.Orders;"
        Dim XResult As String
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()
            'command.ResetCommandTimeout()
            command.CommandTimeout = 0
            Dim reader As SqlDataReader = command.ExecuteReader()
            Try
                reader.Read()
                XResult = reader(0)
            Finally
                ' Always call Close when done reading.+
                reader.Close()
            End Try
        End Using
        Return XResult
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaConfirmar
    ' Descripción:          Este procedimiento permite realizar el cambio a Pendiente
    '                       Verificación para la Ficha de Inscripción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAplicar()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim XNum As Integer
        Try
            Dim Conex As New DSSistema.DSSistema
            Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName & ";Connection Timeout=0"
            Dim Strsql As String = ""
            Dim intPosicion As Integer
            'Dim intTransaccionContableID As Integer




            If ValidaDatosAplicacion() Then

                'Strsql = " EXEC spSccAplicarCierreDiarioContable " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & "," & InfoSistema.IDCuenta
                Strsql = " EXEC spSccAplicarCierreDiarioContableDoble " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & "," & InfoSistema.IDCuenta


                'intTransaccionContableID = XcDatos.ExecuteScalar(Strsql)

                XNum = EjecutarComandoPasar(myConnectionString, Strsql)


                'Si el salvado se realizó de forma satisfactoria
                'enviar mensaje informando y cerrar el formulario.
                If XNum = 0 Then
                    MsgBox("La Aplicación del Cierre Diario de Cartera NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    Call GuardarAuditoria(5, 23, "Generación de Comprobantes Contables de Cierre Diario de Cartera ID: " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & ".")

                    MsgBox("Aplicación Contable del Cierre realizada Exitosamente.", MsgBoxStyle.Information, "SMUSURA0")

                    'Guardar posición actual de la selección
                    intPosicion = XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")
                    CargarCierre()

                    'Ubicar la selección en la posición original
                    XdsCierre("Cierre").SetCurrentByID("nSccCierreDiarioCajaID", intPosicion)
                    Me.grdCierre.Row = XdsCierre("Cierre").BindingSource.Position
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosConfirmacion
    ' Descripción:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de cambiar a
    '                       Pendiente Verificación a una Ficha de Inscripción.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAplicacion() As Boolean
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim xnStbTipoDocContableID As Integer
        Try

            ValidaDatosAplicacion = True

            Dim Strsql As String

            'Validar si no existen cierres
            If Me.grdCierre.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                ValidaDatosAplicacion = False
                Exit Function
            End If

            If Me.grdDetalleCierre.RowCount = 0 Then
                MsgBox("No Existen recibos relacionados al Cierre.", MsgBoxStyle.Information)
                ValidaDatosAplicacion = False
                Exit Function
            End If





            'Valida si el Cierre tiene estado "En Proceso"
            Strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccCierreDiarioCaja b " & _
                     " ON b.nStbEstadoCierreID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")

            'If XdsCierre("Cierre").ValueField("sEstadoCierre") <> "En Proceso" Then
            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.ValueField("sCodigoInterno") <> "1" Then

                MsgBox("Para Aplicar la Transacción Contable," & Chr(10) & _
                       "el Cierre DEBE estar actualmente En Proceso.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAplicacion = False
                Exit Function
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsCierre("Cierre").ValueField("dFechaCierre")) = False Then
                MsgBox("El Mes Contable se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaDatosAplicacion = False
                Exit Function
            End If

            'Valida si el Cierre tiene estado "En Proceso"
            'If XdsCierre("Cierre").ValueField("sEstadoCierre") <> "En Proceso" Then
            '    MsgBox("Para Aplicar la Transacción Contable," & Chr(10) & _
            '           "el Cierre DEBE estar actualmente En Proceso.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAplicacion = False
            '    Exit Function
            'End If

            ''Validar que exista Tasa de Cambio para la Fecha de Cierre
            'Strsql = " SELECT nMontoTCambio " & _
            '         " FROM StbParidadCambiaria " & _
            '      " WHERE dFechaTCambio = '" & XdsCierre("Cierre").ValueField("dFechaCierre") & "'" & _
            '      " AND nStbMonedaBaseID = (Select sValorParametro From StbValorParametro Where nStbValorParametroID = 17)" & _
            '      " AND nStbMonedaCambioID = (Select sValorParametro From StbValorParametro Where nStbValorParametroID = 18)"

            'XdtDatos.ExecuteSql(Strsql)

            'If XdtDatos.Count <= 0 Then
            '    MsgBox("Para Aplicar la Transacción Contable," & Chr(10) & _
            '           "DEBE existir Tasa de Cambio para la Fecha del Cierre.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAplicacion = False
            '    Exit Function
            'End If

            'Recibos incluidos en el Cierre pero que no están en el nuevo proceso

            '--------------INICIO ANALIZAR POR QUE SE PEGA




            Strsql = " SELECT nSccTablaAmortizacionPagosID FROM SccCierreDiarioCajaDetalle " & _
                     " WHERE nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & _
                     " AND nSccTablaAmortizacionPagosID NOT IN " & _
                     " (SELECT a.nSccTablaAmortizacionPagosID " & _
                     " FROM SccTablaAmortizacionPagos a INNER JOIN SccReciboOficialCaja b " & _
                     " ON a.nSccReciboOficialCajaID = b.nSccReciboOficialCajaID " & _
                     " INNER JOIN SccSolicitudCheque c " & _
                     " ON b.nSccSolicitudChequeID = c.nSccSolicitudChequeID " & _
                     " WHERE convert(datetime,b.dFechaRecibo,105) = convert(datetime,'" & XdsCierre("Cierre").ValueField("dFechaCierre") & "',105)" & _
                     " AND b.nStbEstadoReciboID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1') And b.sNombre = 'EstadoReciboOficialCaja')" & _
                     " AND c.nScnFuenteFinanciamientoID = " & XdsCierre("Cierre").ValueField("nScnFuenteFinanciamientoID") & ")"

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("DEBE Reprocesar el Cierre Diario de Cartera," & Chr(10) & _
                       "Existen Recibos que no deberían estar incluidos en el Cierre.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAplicacion = False
                Exit Function
            End If



            '--------------FIN ANALIZAR

            'Recibos incluidos en el Cierre pero que no están en el nuevo proceso
            Strsql = " SELECT a.nSccTablaAmortizacionPagosID " & _
                      " FROM SccTablaAmortizacionPagos a INNER JOIN SccReciboOficialCaja b " & _
                      " ON a.nSccReciboOficialCajaID = b.nSccReciboOficialCajaID " & _
                      " INNER JOIN SccSolicitudCheque c " & _
                      " ON b.nSccSolicitudChequeID = c.nSccSolicitudChequeID " & _
                      " WHERE convert(datetime,b.dFechaRecibo,105) = convert(datetime,'" & XdsCierre("Cierre").ValueField("dFechaCierre") & "',105)" & _
                      " AND b.nStbEstadoReciboID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1') And b.sNombre = 'EstadoReciboOficialCaja')" & _
                      " AND c.nScnFuenteFinanciamientoID = " & XdsCierre("Cierre").ValueField("nScnFuenteFinanciamientoID") & _
                      " AND a.nSccTablaAmortizacionPagosID NOT IN " & _
                      " (SELECT nSccTablaAmortizacionPagosID FROM SccCierreDiarioCajaDetalle " & _
                      " WHERE nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & ")"

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("DEBE Reprocesar el Cierre Diario de Cartera," & Chr(10) & _
                       "Existen Recibos que no están incluidos en el Cierre.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAplicacion = False
                Exit Function
            End If

            'Recibos sin Información del Depósito: 
            Strsql = " SELECT A.nSccReciboOficialCajaID FROM SccReciboOficialCaja AS A INNER JOIN " & _
                     " (SELECT nSccReciboOficialCajaID FROM vwSccCierreDiarioCajaDetalle " & _
                     " WHERE (nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & ")) AS B_1 ON A.nSccReciboOficialCajaID = B_1.nSccReciboOficialCajaID " & _
                     " WHERE (A.nSteMinutaDepositoID IS NULL) AND (A.nStbEstadoReciboID NOT IN " & _
                     " (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (a.sCodigoInterno = '3') AND (b.sNombre = 'EstadoReciboOficialCaja')))"
            REM 12/01/2010 TimeOut: Modificado:
            'Strsql = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
            '         " WHERE (nSteMinutaDepositoID is Null) " & _
            '         " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('3') And b.sNombre = 'EstadoReciboOficialCaja') " & _
            '         " AND nSccReciboOficialCajaID IN (SELECT nSccReciboOficialCajaID FROM vwSccCierreDiarioCajaDetalle WHERE nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & ")"
            XdtDatos.ExecuteSql(Strsql)
            If XdtDatos.Count > 0 Then
                MsgBox("Existen Recibos sin Información del Depósito.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAplicacion = False
                Exit Function
            End If

            'Validar que no realicen Cierres dejando fechas anteriores sin cerrar: 
            Strsql = " SELECT nSccCierreDiarioCajaID FROM SccCierreDiarioCaja " & _
                     " WHERE nStbEstadoCierreID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1') And b.sNombre = 'EstadoCierreCartera')" & _
                     " AND convert(datetime,dFechaCierre,105) < convert(datetime,'" & XdsCierre("Cierre").ValueField("dFechaCierre") & "',105)"
            XdtDatos.ExecuteSql(Strsql)
            If XdtDatos.Count > 0 Then
                MsgBox("Existen Cierres previos sin Aplicar.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAplicacion = False
                Exit Function
            End If


            'Agregado para validar que exista definido en parametros contables para  Febrero 2012



            Strsql = "SELECT  isnull(a.nStbValorCatalogoID,0) as IdTipoDocumento FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = 'CR' And b.sNombre = 'TipoDocumentoContable'"





            'Valida si el Cierre tiene estado "En Proceso"
 
            'If XdsCierre("Cierre").ValueField("sEstadoCierre") <> "En Proceso" Then
            XdtDatos.ExecuteSql(Strsql)


            If XdtDatos.Count = 0 Then
                MsgBox("No existe definido el Registro de Catalogo para el  Tipo Documento Contable para el Comprobante Diario de Recuperacion," & Chr(10) & _
                       "ingresarlo en catalogos.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAplicacion = False
                Exit Function
            End If

            xnStbTipoDocContableID = XdtDatos.ValueField("IdTipoDocumento")



            Strsql = " SELECT     ListaRecibosCierre.dFechaDeposito, ListaRecibosCierre.sNumeroDeposito, ListaRecibosCierre.nSteMinutaDepositoID, " & _
            "          ListaRecibosCierre.nStbPersonaID, ListaRecibosCierre.nScnFuenteFinanciamientoID, ParAfectacion.sCodAfectacion, " & _
            "          ParAfectacion.nStbPersonaID AS Expr1, ParAfectacion.nScnFuenteFinanciamientoID AS Expr2, dbo.SteCuentaBancaria.sNumeroCuenta,dbo.SteCuentaBancaria.sNombreCuenta " & _
            " FROM         (SELECT     dbo.vwSccReciboCierre.dFechaDeposito, dbo.vwSccReciboCierre.sNumeroDeposito, dbo.vwSccReciboCierre.nSteMinutaDepositoID, " & _
            " dbo.vwSccReciboCierre.nStbPersonaID, dbo.SccCierreDiarioCaja.nScnFuenteFinanciamientoID " & _
            "           FROM          dbo.vwSccReciboCierre INNER JOIN " & _
            "                                  dbo.SccCierreDiarioCaja ON dbo.vwSccReciboCierre.nSccCierreDiarioCajaID = dbo.SccCierreDiarioCaja.nSccCierreDiarioCajaID" & _
            "           WHERE      (dbo.vwSccReciboCierre.nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & ")" & _
            "           GROUP BY dbo.vwSccReciboCierre.dFechaDeposito, dbo.vwSccReciboCierre.sNumeroDeposito, dbo.vwSccReciboCierre.nSteMinutaDepositoID, " & _
            "                                  dbo.vwSccReciboCierre.nStbPersonaID, dbo.SccCierreDiarioCaja.nScnFuenteFinanciamientoID) AS ListaRecibosCierre INNER JOIN" & _
            "         dbo.SteMinutaDeposito ON ListaRecibosCierre.nSteMinutaDepositoID = dbo.SteMinutaDeposito.nSteMinutaDepositoID INNER JOIN" & _
            "          dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID LEFT OUTER JOIN" & _
            "              (SELECT     dbo.vwScnParametroAfectacion.sCodAfectacion, SteCuentaBancaria_1.nStbPersonaID," & _
            " dbo.vwScnParametroAfectacion.nScnFuenteFinanciamientoID" & _
                           " FROM          dbo.vwScnParametroAfectacion INNER JOIN " & _
                            "                       dbo.ScnCatalogoContable ON " & _
                             "                      dbo.vwScnParametroAfectacion.nScnCatalogoContableID = dbo.ScnCatalogoContable.nScnCatalogoContableID INNER JOIN " & _
                              "                     dbo.SteCuentaBancaria AS SteCuentaBancaria_1 ON " & _
            " dbo.ScnCatalogoContable.nSteCuentaBancariaID = SteCuentaBancaria_1.nSteCuentaBancariaID" & _
            "                WHERE      (dbo.vwScnParametroAfectacion.sCodAfectacion = '5') AND (dbo.vwScnParametroAfectacion.nStbTipoDocContableID =" & xnStbTipoDocContableID & "))" & _
            "          AS ParAfectacion ON ListaRecibosCierre.nScnFuenteFinanciamientoID = ParAfectacion.nScnFuenteFinanciamientoID AND " & _
            " ListaRecibosCierre.nStbPersonaID = ParAfectacion.nStbPersonaID " & _
            " WHERE(ParAfectacion.sCodAfectacion Is NULL) "



            XdtDatos.ExecuteSql(Strsql)


            If XdtDatos.Count > 0 Then
                MsgBox("No existe definido la Cuenta Contable a afectar para la Cuenta Bancaria en los Parametros Contables (Comprobante de Recuperación Créditos). " & Chr(13) & "Encontrada Primer Minuta Deposito No: " & XdtDatos.ValueField("sNumeroDeposito") & " Cuenta Bancaria: " & XdtDatos.ValueField("sNombreCuenta") & Chr(10) & _
                       "ingresarlo en  los parametros contables.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAplicacion = False
                Exit Function
            End If







            'Valida si crea partida con INGRESOS POR DIFERENCIA DE CREDITOS

            Strsql = "SELECT     dbo.StbValorParametro.sValorParametro, dbo.StbParametro.sDescripcionParametro, dbo.StbParametro.nStbParametroID " & _
                     " FROM         dbo.StbValorParametro INNER JOIN  dbo.StbParametro ON dbo.StbValorParametro.nStbParametroID = dbo.StbParametro.nStbParametroID  WHERE(dbo.StbParametro.nStbParametroID = 73) "

            'If XdsCierre("Cierre").ValueField("sEstadoCierre") <> "En Proceso" Then
            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.ValueField("sValorParametro") <> "0" Then


                Strsql = " SELECT     ListaRecibosCierre.dFechaDeposito, ListaRecibosCierre.sNumeroDeposito, ListaRecibosCierre.nSteMinutaDepositoID, " & _
                           "          ListaRecibosCierre.nStbPersonaID, ListaRecibosCierre.nScnFuenteFinanciamientoID, ParAfectacion.sCodAfectacion " & _
                           "          , ParAfectacion.nScnFuenteFinanciamientoID AS Expr2" & _
                           " FROM         (SELECT     dbo.vwSccReciboCierre.dFechaDeposito, dbo.vwSccReciboCierre.sNumeroDeposito, dbo.vwSccReciboCierre.nSteMinutaDepositoID, " & _
                           " dbo.vwSccReciboCierre.nStbPersonaID, dbo.SccCierreDiarioCaja.nScnFuenteFinanciamientoID " & _
                           "           FROM          dbo.vwSccReciboCierre INNER JOIN " & _
                           "                                  dbo.SccCierreDiarioCaja ON dbo.vwSccReciboCierre.nSccCierreDiarioCajaID = dbo.SccCierreDiarioCaja.nSccCierreDiarioCajaID" & _
                           "           WHERE      (dbo.vwSccReciboCierre.nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & ")" & _
                           "           GROUP BY dbo.vwSccReciboCierre.dFechaDeposito, dbo.vwSccReciboCierre.sNumeroDeposito, dbo.vwSccReciboCierre.nSteMinutaDepositoID, " & _
                           "                                  dbo.vwSccReciboCierre.nStbPersonaID, dbo.SccCierreDiarioCaja.nScnFuenteFinanciamientoID) AS ListaRecibosCierre INNER JOIN" & _
                           "         dbo.SteMinutaDeposito ON ListaRecibosCierre.nSteMinutaDepositoID = dbo.SteMinutaDeposito.nSteMinutaDepositoID " & _
                           "           LEFT OUTER JOIN" & _
                           "              (SELECT     dbo.vwScnParametroAfectacion.sCodAfectacion, " & _
                           " dbo.vwScnParametroAfectacion.nScnFuenteFinanciamientoID" & _
                                          " FROM          dbo.vwScnParametroAfectacion INNER JOIN " & _
                                           "                       dbo.ScnCatalogoContable ON " & _
                                            "                      dbo.vwScnParametroAfectacion.nScnCatalogoContableID = dbo.ScnCatalogoContable.nScnCatalogoContableID " & _
                                             "        " & _
                           " " & _
                           "                WHERE      (dbo.vwScnParametroAfectacion.sCodAfectacion = '14') AND (dbo.vwScnParametroAfectacion.nStbTipoDocContableID =" & xnStbTipoDocContableID & "))" & _
                           "          AS ParAfectacion ON ListaRecibosCierre.nScnFuenteFinanciamientoID = ParAfectacion.nScnFuenteFinanciamientoID  " & _
                           " " & _
                           " WHERE(ParAfectacion.sCodAfectacion Is NULL) "








                XdtDatos.ExecuteSql(Strsql)


                If XdtDatos.Count > 0 Then
                    MsgBox("No existe definido la Cuenta Contable a afectar para la Cuenta de Ingresos por Diferencia Cambiaria en los Parametros Contables (Comprobante de Recuperación Créditos). " & Chr(13) & "Encontrada Primer Minuta Deposito No: " & XdtDatos.ValueField("sNumeroDeposito") & Chr(10) & _
                           "ingresarlo en  los parametros contables.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosAplicacion = False
                    Exit Function
                End If


                'Buscar a que fuente se pondria los ingresos por diferencia cambiaria. en caso que la minuta tenga recibos de dos o mas fuentes.
                'se supone que van a fondos propios pero esto se busca en parametros

                '

                Strsql = "SELECT     dbo.StbValorParametro.sValorParametro, dbo.StbParametro.sDescripcionParametro, dbo.StbParametro.nStbParametroID " & _
                         " FROM         dbo.StbValorParametro INNER JOIN  dbo.StbParametro ON dbo.StbValorParametro.nStbParametroID = dbo.StbParametro.nStbParametroID  WHERE(dbo.StbParametro.nStbParametroID = 74) "


                XdtDatos.ExecuteSql(Strsql)

                If XdtDatos.Count = 0 Then
                    MsgBox("No existe definido en la tabla de StbValorParametros que Fuente Financiera afectara para Ingresos por Diferencia de Creditos  Cuando la Minuta tenga mas de una fuente. " & _
                           "ingresarlo en  StbValorParametros .", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosAplicacion = False
                    Exit Function

                End If






                'Para generar comprobante. Deben estar generado los registros de los cierres de ese dia para todas las fuentes ç
                'Except COOPERATIVA DE AHORRO Y CREDITO  CAJA RURAL NACIONAL  RL  CARUNA
                'BANDES(CARUNA)
                'FINANCIERA NICARAGUENSE DE INVERSIONES SA
                'ALBA(CARUNA)

                '






                Strsql = " SELECT nSccTablaAmortizacionPagosID FROM SccCierreDiarioCajaDetalle " & _
                         " WHERE nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & _
                         " AND nSccTablaAmortizacionPagosID NOT IN " & _
                         " (SELECT a.nSccTablaAmortizacionPagosID " & _
                         " FROM SccTablaAmortizacionPagos a INNER JOIN SccReciboOficialCaja b " & _
                         " ON a.nSccReciboOficialCajaID = b.nSccReciboOficialCajaID " & _
                         " INNER JOIN SccSolicitudCheque c " & _
                         " ON b.nSccSolicitudChequeID = c.nSccSolicitudChequeID " & _
                         " WHERE convert(datetime,b.dFechaRecibo,105) = convert(datetime,'" & XdsCierre("Cierre").ValueField("dFechaCierre") & "',105)" & _
                         " AND b.nStbEstadoReciboID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1') And b.sNombre = 'EstadoReciboOficialCaja')" & _
                         " AND c.nScnFuenteFinanciamientoID = " & XdsCierre("Cierre").ValueField("nScnFuenteFinanciamientoID") & ")"








                Strsql = "SELECT     CierresValidos.nScnFuenteFinanciamientoID AS nScnFuenteFinanciamientoIDFalta, dbo.ScnFuenteFinanciamiento.sNombre " & _
                         "       FROM         (SELECT     dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID" & _
                       " FROM          dbo.SccReciboOficialCaja INNER JOIN " & _
                       "                       dbo.SteMinutaDeposito ON dbo.SccReciboOficialCaja.nSteMinutaDepositoID = dbo.SteMinutaDeposito.nSteMinutaDepositoID INNER JOIN " & _
                       "                       dbo.StbValorCatalogo ON dbo.SccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                       "                       dbo.SccSolicitudCheque ON dbo.SccReciboOficialCaja.nSccSolicitudChequeID = dbo.SccSolicitudCheque.nSccSolicitudChequeID " & _
                       " WHERE      (dbo.StbValorCatalogo.sCodigoInterno <> '3') AND (convert(datetime, dbo.SccReciboOficialCaja.dFechaRecibo,105) = CONVERT(DATETIME, '" & XdsCierre("Cierre").ValueField("dFechaCierre") & "', 105))" & _
                         "                      AND (dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID <> 5) AND (dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID <> 6)  " & _
                          "                    AND (dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID <> 7) AND (dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID <> 9) " & _
                      " GROUP BY dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID) AS DiaFuentesRecibos INNER JOIN dbo.ScnFuenteFinanciamiento ON DiaFuentesRecibos.nScnFuenteFinanciamientoID=dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID     LEFT OUTER JOIN " & _
                       "   (SELECT     StbValorCatalogo_1.sCodigoInterno, StbValorCatalogo_1.sDescripcion, dbo.SccCierreDiarioCaja.dFechaCierre,  " & _
                " dbo.SccCierreDiarioCaja.nScnFuenteFinanciamientoID  " & _
                 "           FROM          dbo.SccCierreDiarioCaja INNER JOIN " & _
                 "                                  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  " & _
                " dbo.SccCierreDiarioCaja.nStbEstadoCierreID = StbValorCatalogo_1.nStbValorCatalogoID  " & _
                 "           WHERE      (StbValorCatalogo_1.sCodigoInterno <> '3') AND (convert(datetime,dbo.SccCierreDiarioCaja.dFechaCierre,105) = CONVERT(DATETIME, '" & XdsCierre("Cierre").ValueField("dFechaCierre") & "', 105))" & _
                 "                                  ) AS CierresValidos ON DiaFuentesRecibos.nScnFuenteFinanciamientoID = CierresValidos.nScnFuenteFinanciamientoID " & _
                " WHERE(CierresValidos.nScnFuenteFinanciamientoID Is NULL) "

                'Strsql = "SELECT     dbo.StbValorParametro.sValorParametro, dbo.StbParametro.sDescripcionParametro, dbo.StbParametro.nStbParametroID " & _
                '         " FROM         dbo.StbValorParametro INNER JOIN  dbo.StbParametro ON dbo.StbValorParametro.nStbParametroID = dbo.StbParametro.nStbParametroID  WHERE(dbo.StbParametro.nStbParametroID = 74) "


                XdtDatos.ExecuteSql(Strsql)

                If XdtDatos.Count > 0 Then
                    MsgBox("Existe al menos una fuente  (" & XdtDatos.ValueField("sNombre") & ") Que no ha sido Generada " & Chr(13) & _
                           "Se necesita que esten ingresadas para todas las fuentes." & Chr(13) & "Para poder generar el Ingresos por Diferencia de Creditos", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosAplicacion = False
                    Exit Function

                End If

            End If









        Catch ex As Exception
            ValidaDatosAplicacion = False
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir listado por
    '                       Departamento y Municipio. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Formulas("Parametro") = "Podria ser nScnTransaccionContableID "
            frmVisor.NombreReporte = "RepScnCN8.rpt"
            frmVisor.Text = "Cierre Diario de Cartera"
            If Me.grdCierre.RowCount > 0 Then
                frmVisor.CRVReportes.SelectionFormula = "{SpSccCierreDiarioCajaDetalleRep.nSccCierreDiarioCajaID}=" & grdCierre.Item(grdCierre.Row, "nSccCierreDiarioCajaID")
                frmVisor.Parametros("@nSccCierreDiarioCajaID") = grdCierre.Item(grdCierre.Row, "nSccCierreDiarioCajaID")
                frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicio.Value, "yyyy-MM-dd HH:mm:ss")
                frmVisor.Parametros("@FechaFinal") = Format(Me.cdeFechaFin.Value, "yyyy-MM-dd HH:mm:ss")
                frmVisor.ShowDialog()
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            'frmVisor.Close()
            'frmVisor.Dispose()
            frmVisor = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir listado por
    '                       Departamento y Municipio. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirM()
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Formulas("Parametro") = "Podria ser nScnTransaccionContableID "
            frmVisor.NombreReporte = "RepScnCN17.rpt"
            frmVisor.Text = "Recibos Asociados a la Minuta"

            If Me.grdDetalleCierre.RowCount > 0 And Not IsDBNull(grdDetalleCierre.Item(grdDetalleCierre.Row, "nSteMinutaDepositoID")) Then
                frmVisor.Parametros("@nSteMinutaDepositoID") = grdDetalleCierre.Item(grdDetalleCierre.Row, "nSteMinutaDepositoID")
                frmVisor.Parametros("@nSccCierreDiarioCajaID") = 0
                frmVisor.CRVReportes.SelectionFormula = "{SpSccRecibosMinutaDetalleRep.nSteMinutaDepositoID} =" & grdDetalleCierre.Item(grdDetalleCierre.Row, "nSteMinutaDepositoID")
                frmVisor.ShowDialog()
            ElseIf Me.grdDetalleCierre.RowCount > 0 And Not IsDBNull(grdDetalleCierre.Item(grdDetalleCierre.Row, "nSccCierreDiarioCajaID")) Then
                frmVisor.Parametros("@nSteMinutaDepositoID") = -1
                frmVisor.Parametros("@nSccCierreDiarioCajaID") = grdDetalleCierre.Item(grdDetalleCierre.Row, "nSccCierreDiarioCajaID")
                frmVisor.ShowDialog()

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'frmVisor.Close()
            'frmVisor.Dispose()
            frmVisor = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbRecibo_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbMunicipio.
    '-------------------------------------------------------------------------
    Private Sub tbRecibo_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbDetalleCierre.ItemClicked
        Select Case e.ClickedItem.Name
            'Case "toolAgregarM"
            '    LlamaAgregarRecibo()
            Case "toolModificarM"
                LlamaModificarRecibo()
            Case "toolImprimirM"
                LlamaImprimirM()

                'Case "toolEliminarM"
                '    LlamaEliminarRecibo()
            Case "toolAyudaM"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditRecibo para Agregar un nuevo Recibo para una
    '                       determinadoa Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCierre()
        Dim ObjFrmSccEditCierreCaja As New frmSccEditCierreCaja
        'Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            'Departamento Inactivo
            'If XdsCierre("Departamento").ValueField("nActivo") = False Then
            '    MsgBox("No puede Agregar Municipios, Departamento Inactivo.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'Dim strSQL As String = ""

            'strSQL = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo " & _
            '         " From vwSccReciboSocia a " & _
            '         " Where a.nSccSolicitudChequeID = " & XdsCierre("Socia").ValueField("nSccSolicitudChequeID") & _
            '         " And a.sEstadoRecibo = 'En Proceso'"

            'XdtDatos.ExecuteSql(strSQL)
            'If XdtDatos.Count > 0 Then
            '    MsgBox("No puede Agregar Recibos, porque existen Recibos En Proceso.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmSccEditCierreCaja.ModoFrm = "ADD"
            ObjFrmSccEditCierreCaja.FechaCierre = CDate(Me.cdeFechaInicio.Text)
            If Me.sColor = "Celeste" Then
                ObjFrmSccEditCierreCaja.sColorFrm = "CelesteLight"
            Else
                ObjFrmSccEditCierreCaja.sColorFrm = Me.sColor
            End If
            ObjFrmSccEditCierreCaja.IdCierreDiarioCaja = XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")
            ObjFrmSccEditCierreCaja.ShowDialog()

            If ObjFrmSccEditCierreCaja.IdCierreDiarioCaja <> 0 Then
                CargarCierre()
                XdsCierre("Cierre").SetCurrentByID("nSccCierreDiarioCajaID", ObjFrmSccEditCierreCaja.IdCierreDiarioCaja)
                Me.grdCierre.Row = XdsCierre("Cierre").BindingSource.Position

                'XdsCierre("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditCierreCaja.IdReciboOficialCaja)
                'Me.grdDetalleCierre.Row = XdsCierre("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditCierreCaja.Close()
            ObjFrmSccEditCierreCaja = Nothing

            'XdtDatos.Close()
            'XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditReciboCaja para Modificar un Recibo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCierre()
        Dim ObjFrmSccEditCierreCaja As New frmSccEditCierreCaja
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            If Me.grdCierre.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si el Cierre tiene estado "En Proceso"
            strSQL = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccCierreDiarioCaja b " & _
                     " ON b.nStbEstadoCierreID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")

            'If XdsCierre("Cierre").ValueField("sEstadoCierre") <> "En Proceso" Then
            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.ValueField("sCodigoInterno") <> "1" Then

                MsgBox("Para Modificar el Cierre," & Chr(10) & _
                       "DEBE estar actualmente En Proceso.", MsgBoxStyle.Critical, "SMUSURA0")
                'ValidaDatosAplicacion = False
                Exit Sub
            End If
            ObjFrmSccEditCierreCaja.ModoFrm = "UPD"
            If Me.sColor = "Celeste" Then
                ObjFrmSccEditCierreCaja.sColorFrm = "CelesteLight"
            Else
                ObjFrmSccEditCierreCaja.sColorFrm = Me.sColor
            End If

            ObjFrmSccEditCierreCaja.IdCierreDiarioCaja = XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")
            ObjFrmSccEditCierreCaja.ShowDialog()

            CargarCierre()
            XdsCierre("Cierre").SetCurrentByID("nSccCierreDiarioCajaID", ObjFrmSccEditCierreCaja.IdCierreDiarioCaja)
            Me.grdCierre.Row = XdsCierre("Cierre").BindingSource.Position

            'XdsCierre("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditCierreCaja.IdReciboOficialCaja)
            'Me.grdDetalleCierre.Row = XdsCierre("Recibo").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditCierreCaja.Close()
            ObjFrmSccEditCierreCaja = Nothing

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
    Private Sub LlamaModificarRecibo()
        Dim ObjFrmSccEditDetalleCierre As New frmSccEditDetalleCierre
        Try
            If Me.grdDetalleCierre.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida si el Cierre tiene estado "Cerrado"
            If XdsCierre("Cierre").ValueField("sEstadoCierre") <> "En Proceso" Then
                MsgBox("Para Modificar el Recibo," & Chr(10) & _
                       "El Cierre DEBE estar actualmente En Proceso.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If

            ObjFrmSccEditDetalleCierre.ModoFrm = "UPD"
            ObjFrmSccEditDetalleCierre.IdCierreDiarioCaja = XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")
            ObjFrmSccEditDetalleCierre.IdRecibo = XdsCierre("DetalleCierre").ValueField("nSccReciboOficialCajaID")
            ObjFrmSccEditDetalleCierre.ShowDialog()

            CargarCierre()
            XdsCierre("Cierre").SetCurrentByID("nSccCierreDiarioCajaID", ObjFrmSccEditDetalleCierre.IdCierreDiarioCaja)
            Me.grdCierre.Row = XdsCierre("Cierre").BindingSource.Position

            XdsCierre("DetalleCierre").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditDetalleCierre.IdRecibo)
            Me.grdDetalleCierre.Row = XdsCierre("DetalleCierre").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditDetalleCierre.Close()
            ObjFrmSccEditDetalleCierre = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaEliminarMunicipio
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Municipio asociado a un Departamento existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarCierre()
        Dim XdtCierreAnular As New BOSistema.Win.SccEntCartera.SccCierreDiarioCajaDataTable
        Dim XdrCierreAnular As New BOSistema.Win.SccEntCartera.SccCierreDiarioCajaRow
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String = ""
            Dim intPosicion As Integer
            Dim intCierreID As Integer
            Dim strCausaAnulacion As String

            If MsgBox("¿Está seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                If ValidaDatosAnulacion() Then

                    'Solicita al Usuario la Causa de la Anulación
                    XdtCierreAnular.Filter = " nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")
                    XdtCierreAnular.Retrieve()
                    XdrCierreAnular = XdtCierreAnular.Current

                    ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                    ObjFrmStbDatoComplemento.strTitulo = "Anulación del Cierre Diario de Cartera"
                    ObjFrmStbDatoComplemento.intAncho = XdrCierreAnular.GetColumnLenght("sMotivoAnulacion")
                    ObjFrmStbDatoComplemento.strDato = ""
                    If Me.sColor = "Celeste" Then
                        ObjFrmStbDatoComplemento.strColor = "CelesteLight"
                    Else
                        ObjFrmStbDatoComplemento.strColor = Me.sColor
                    End If

                    'ObjFrmStbDatoComplemento.strColor = "Verde"
                    ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                    ObjFrmStbDatoComplemento.ShowDialog()

                    strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                    'Valida que se ingrese la Causa de la Anulación:
                    If strCausaAnulacion = "" Then
                        MsgBox("El Cierre NO PUEDE ser Anulado. Debe ingresar Causa de Anulación.", MsgBoxStyle.Critical, "SMUSURA0")
                        Exit Sub
                    End If

                    If Me.grdDetalleCierre.RowCount = 0 Then
                        Strsql = " EXEC spSccAnularCierreSinRecibos " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & "," & InfoSistema.IDCuenta & ",'" & strCausaAnulacion & "'"
                    Else
                        Strsql = " EXEC spSccAnularCierreDiarioContable " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & "," & InfoSistema.IDCuenta & ",'" & strCausaAnulacion & "'"
                    End If

                    intCierreID = XcDatos.ExecuteScalar(Strsql)

                    'Si el salvado se realizó de forma satisfactoria
                    'enviar mensaje informando y cerrar el formulario.
                    If intCierreID = 0 Then
                        MsgBox("La Anulación del Cierre Diario NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                    Else
                        Call GuardarAuditoria(4, 23, "Anulación de Cierre Diario de Cartera ID: " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & ".")

                        MsgBox("Anulación del Cierre realizada Exitosamente.", MsgBoxStyle.Information, "SMUSURA0")

                        'Guardar posición actual de la selección
                        intPosicion = XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID")
                        CargarCierre()

                        'Ubicar la selección en la posición original
                        XdsCierre("Cierre").SetCurrentByID("nSccCierreDiarioCajaID", intPosicion)
                        Me.grdCierre.Row = XdsCierre("Cierre").BindingSource.Position
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtCierreAnular.Close()
            XdtCierreAnular = Nothing

            XdrCierreAnular.Close()
            XdrCierreAnular = Nothing

            ObjFrmStbDatoComplemento = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosConfirmacion
    ' Descripción:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de cambiar a
    '                       Pendiente Verificación a una Ficha de Inscripción.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAnulacion() As Boolean
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim intPeriodoID As Integer
            Dim Strsql As String

            ValidaDatosAnulacion = True

            'Dim Strsql As String

            If Me.grdCierre.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                ValidaDatosAnulacion = False
                Exit Function
            End If

            If Me.grdDetalleCierre.RowCount = 0 Then
                'MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                'ValidaDatosAnulacion = False
                Exit Function
            End If

            'Valida si el Cierre tiene estado "Cerrado"
            If XdsCierre("Cierre").ValueField("sEstadoCierre") <> "Cerrado" Then
                MsgBox("Para Anular el Cierre Diario," & Chr(10) & _
                       "DEBE estar actualmente Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnulacion = False
                Exit Function
            End If

            'Validar que la Fecha de Cierre no sea de un Período Contable Cerrado
            intPeriodoID = IDPeriodo(XdsCierre("Cierre").ValueField("dFechaCierre"))
            If PeriodoAbierto(intPeriodoID) = False Then
                MsgBox("Imposible Anular el Cierre Diario." & Chr(10) & _
                       "Período Contable Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnulacion = False
                Exit Function
            End If

            'No permito Anular si hay Cierres "Cerrados" (con Aplicación Contable) con fecha posterior
            'REM Está comentariado para evitar atrasos al tener que anular todos los cierres posteriores a la
            'REM fecha que se desea anular.
            'Strsql = " SELECT nSccCierreDiarioCajaID FROM SccCierreDiarioCaja " & _
            '         " WHERE convert(datetime,dFechaCierre,105) > convert(datetime,'" & XdsCierre("Cierre").ValueField("dFechaCierre") & "',105)" & _
            '         " AND nStbEstadoCierreID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoCierreCartera') "

            'XdtDatos.ExecuteSql(Strsql)

            'If XdtDatos.Count > 0 Then
            '    MsgBox("El Cierre NO PUEDE ser Anulado. Existen Cierres con Estado Cerrado con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAnulacion = False
            '    Exit Function
            'End If

            'Valido que no se pueda anular el cierre si ya marcó cualquiera de las minutas
            'asociadas al cierre para Enviar al Ministerio
            'de Hacienda.
            Strsql = " SELECT b.nSteMinutaDepositoID " & _
                     " FROM vwSccCierreDiarioCajaDetalle a " & _
                     " INNER JOIN SteMinutaDeposito b " & _
                     " ON a.nSteMinutaDepositoID = b.nSteMinutaDepositoID " & _
                     " WHERE a.nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & _
                     " and b.nStbEstadoMinutaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoMinutaDeposito')"

            XdtDatos.ExecuteSql(Strsql)

            'REM Comentariado temporalmente
            If XdtDatos.Count > 0 Then
                MsgBox("El Cierre NO PUEDE ser Anulado. Información ya ha sido marcada para Envío al MHCP.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnulacion = False
                Exit Function
            End If

            'Valido que no se pueda anular el cierre si ya se envió la información
            'asociada a cualquiera de las minutas que contiene el cierre al Ministerio
            'de Hacienda.
            'Strsql = " SELECT * " & _
            '         " FROM vwSccCierreDiarioCajaDetalle a " & _
            '         " INNER JOIN [SMCU0-WebService].dbo.WScEnvioEncabezado b " & _
            '         " ON a.nSteMinutaDepositoID = b.nSteMinutaDepositoID " & _
            '         " WHERE a.nSccCierreDiarioCajaID = " & XdsCierre("Cierre").ValueField("nSccCierreDiarioCajaID") & _
            '         " and b.nEstadoProceso <> 9 "

            'XdtDatos.ExecuteSql(Strsql)

            ''REM Comentariado temporalmente
            'If XdtDatos.Count > 0 Then
            '    MsgBox("El Cierre NO PUEDE ser Anulado. Información ya ha sido enviada al Ministerio de Hacienda.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAnulacion = False
            '    Exit Function
            'End If

        Catch ex As Exception
            ValidaDatosAnulacion = False
            Control_Error(ex)
        Finally
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

    Private Sub grdCierre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCierre.DoubleClick
        Try
            If Seg.HasPermission("ModificarCierre") Then
                LlamaModificarCierre()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdCierre_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCierre.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdCierre_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    'Private Sub grdCierre_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCierre.Filter
    '    Try
    '        XdsCierre("Cierre").FilterLocal(e.Condition)
    '        Me.grdCierre.Caption = " Listado de Cierres (" + Me.grdCierre.RowCount.ToString + " registros)"

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
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

            ' Agregar
            If Seg.HasPermission("AgregarCierre") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar
            If Seg.HasPermission("ModificarCierre") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Anular
            If Seg.HasPermission("AnularCierre") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir Listado de Recibos del Cierre CN8
            If Seg.HasPermission("ImprimirCN8") Then
                Me.toolImprimirCN8.Enabled = True
            Else
                Me.toolImprimirCN8.Enabled = False
            End If

            'Imprimir Listado de Recibos del Cierre CN8 por fecha:
            If Seg.HasPermission("ImprimirCN8xFechaCierre") Then
                Me.toolImprimirCN8f.Enabled = True
            Else
                Me.toolImprimirCN8f.Enabled = False
            End If

            'Imprimir Listado de Comprobantes del Cierre / Diario:
            If Seg.HasPermission("ImprimirCN5xFechaCierre") Then
                Me.toolImprimirCN5f.Enabled = True
            Else
                Me.toolImprimirCN5f.Enabled = False
            End If
            If Seg.HasPermission("ImprimirCN5xFechaCierre") Then
                Me.toolImprimirCN5m.Enabled = True
            Else
                Me.toolImprimirCN5m.Enabled = False
            End If

            'Imprimir Listado de Recibos del Cierre CN23
            If Seg.HasPermission("ImprimirCN23") Then
                Me.toolImprimirCN23.Enabled = True
            Else
                Me.toolImprimirCN23.Enabled = False
            End If

            'Imprimir Listado de Recibos del Cierre de una Minuta
            If Seg.HasPermission("ImprimirCierreMinuta") Then
                Me.toolImprimirM.Enabled = True
            Else
                Me.toolImprimirM.Enabled = False
            End If

            ' Aplicar
            If Seg.HasPermission("AplicarCierre") Then
                Me.toolAplicar.Enabled = True
            Else
                Me.toolAplicar.Enabled = False
            End If

            ' Modificar Detalle Cierre
            If Seg.HasPermission("ModificarDetalleCierre") Then
                Me.toolModificarM.Enabled = True
            Else
                Me.toolModificarM.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdCierre_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Recibos con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdCierre_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdCierre.RowColChange

        CargarCierreDetalle()

        Me.grdDetalleCierre.Caption = " Listado Detalle del Cierre (" + Me.grdDetalleCierre.RowCount.ToString + " registros)"
        'CalcularMontos()
    End Sub

    Private Sub grdDetalleCierre_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalleCierre.DoubleClick
        Try
            If Seg.HasPermission("ModificarDetalleCierre") Then
                LlamaModificarRecibo()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdDetalleCierre_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDetalleCierre.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdDetalleCierre_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdDetalleCierre_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetalleCierre.Filter
        Try
            XdsCierre("DetalleCierre").FilterLocal(e.Condition)
            Me.grdDetalleCierre.Caption = " Listado Detalle del Cierre (" + Me.grdDetalleCierre.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cdeFechaInicio_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdeFechaInicio.ValueChanged
        Me.cdeFechaFin.Value = Me.cdeFechaInicio.Value
    End Sub

    Private Sub CierreDiarioPorFuenteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCN8.Click
        LlamaImprimir()
    End Sub
    Private Sub LlamaImprimirPorFecha()
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Formulas("Parametro") = "Podria ser nScnTransaccionContableID "
            frmVisor.NombreReporte = "RepSCNCN23.rpt"
            frmVisor.Text = "Cierre Diario de Cartera Por Depósito"
            If Me.grdCierre.RowCount > 0 Then
                frmVisor.Parametros("@FechaCierre") = Format(grdCierre.Item(grdCierre.Row, "dFechaCierre"), "yyyy-MM-dd HH:mm:ss")
                frmVisor.ShowDialog()
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            'frmVisor.Close()
            'frmVisor.Dispose()
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub CierreDiarioPorMinutaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCN23.Click
        LlamaImprimirPorFecha()
    End Sub

    Private Sub toolImprimirM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirM.Click

    End Sub

    Private Sub toolImprimirCN8f_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCN8f.Click
        LlamaImprimirCN8f()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Gamaliel Mejia
    ' Fecha:                17/11/2009
    ' Procedure Name:       LlamaImprimirCN8f
    ' Descripción:          Este procedimiento permite Imprimir listado por
    '                       dia de cierre.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirCN8f()
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepScnCN8.rpt"
            frmVisor.Text = "Cierre Diario de Cartera"
            If Me.grdCierre.RowCount > 0 Then
                'frmVisor.CRVReportes.SelectionFormula = "{SpSccCierreDiarioCajaDetalleRep.nSccCierreDiarioCajaID}=" & grdCierre.Item(grdCierre.Row, "nSccCierreDiarioCajaID")
                'frmVisor.Parametros("@nSccCierreDiarioCajaID") = grdCierre.Item(grdCierre.Row, "nSccCierreDiarioCajaID")
                frmVisor.Parametros("@nSccCierreDiarioCajaID") = -1
                frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicio.Value, "yyyy-MM-dd HH:mm:ss")
                frmVisor.Parametros("@FechaFinal") = Format(Me.cdeFechaFin.Value, "yyyy-MM-dd HH:mm:ss")
                frmVisor.ShowDialog()
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub toolImprimirCN5f_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCN5f.Click
        LlamaImprimirCN5f()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/11/2009
    ' Procedure Name:       LlamaImprimirCN5f
    ' Descripción:          Este procedimiento permite Imprimir listado de
    '                       comprobantes del dia de cierre. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirCN5f()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdCierre.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepScnCN5.rpt"
            frmVisor.Text = "Comprobante de Recuperación/Ajustes"
            'Comprobantes de Recuperacion y Ajuste mayorizados
            'para la fecha del cierre.
            frmVisor.SQLQuery = "SELECT * FROM vwScnComprobantesDiario " & _
                                "WHERE (CodEstadoCD = '2') AND (CodTipoCD = 'CR') " & _
                                "AND (dFechaCierre = CONVERT(DATETIME, '" & Format(grdCierre.Item(grdCierre.Row, "dFechaCierre"), "yyyy-MM-dd") & "', 102))"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub toolImprimirCN5m_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirCN5m.Click
        LlamaImprimirCN5m()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/05/2010
    ' Procedure Name:       LlamaImprimirCN5m
    ' Descripción:          Este procedimiento permite Imprimir listado de
    '                       comprobantes de diario mayorizados para el rango
    '                       de fechas indicadas.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirCN5m()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""

            'Fechas de Corte Validas:
            If (Not IsDate(cdeFechaInicio.Text)) Or (Not IsDate(cdeFechaFin.Text)) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If (Trim(RTrim(Me.cdeFechaInicio.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaFin.Text)).ToString.Length <> 10) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Fecha de Corte no mayor a la de Inicio:
            If CDate(cdeFechaInicio.Text) > CDate(cdeFechaFin.Text) Then
                MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                Me.cdeFechaInicio.Focus()
                Exit Sub
            End If

            ''Máximo 31 días entre la fecha de inicio y corte:
            'If DateDiff(DateInterval.Day, CDate(cdeFechaInicio.Text), CDate(cdeFechaFin.Text)) > 30 Then
            '    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
            '    Me.cdeFechaInicio.Focus()
            '    Exit Sub
            'End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepScnCN5.rpt"
            frmVisor.Text = "Comprobantes de Diario"
            frmVisor.SQLQuery = "SELECT * FROM vwScnComprobantesDiario " & _
                                "WHERE (CodEstadoCD = '2') AND (CodTipoCD = 'CD' or CodTipoCD = 'CA') " & _
                                "AND (dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaInicio.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaFin.Text), "yyyy-MM-dd") & "', 102))"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub
End Class