Public Class frmStbParametroTasaCambio

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String

    'Listado de Reportes
    Public Enum EnumReportes
        rptStbTasaCambio = 1
    End Enum
    Dim mNomRep As EnumReportes

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property
    Private Sub InicializarVariables()
        Try

            'Inicializar las clases 
            XdsCombos = New BOSistema.Win.XDataSet

            'Titúlo de Reporte
            Select Case mNomRep

                Case EnumReportes.rptStbTasaCambio
                    Me.Text = "Parámetros Reporte de Tasa de Cambio"
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarMonedaBase
    ' Descripción:          Este procedimiento permite cargar el listado de Monedas
    '                       Base en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMonedaBase()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbMonedaID,a.sCodigoInterno,a.sDescripcion,a.sSimbolo " & _
                         " From StbMoneda a " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "

            If XdsCombos.ExistTable("MonedaBase") Then
                XdsCombos("MonedaBase").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "MonedaBase")
                XdsCombos("MonedaBase").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMonedaBase.DataSource = XdsCombos("MonedaBase").Source

            XdtValorParametro.Filter = "nStbParametroID = 17"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsCombos("MonedaBase").Count > 0 Then
                Me.cboMonedaBase.SelectedIndex = 0
                XdsCombos("MonedaBase").SetCurrentByID("nStbMonedaID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboMonedaBase.Splits(0).DisplayColumns("nStbMonedaID").Visible = False
            Me.cboMonedaBase.Splits(0).DisplayColumns("sSimbolo").Visible = False

            Me.cboMonedaBase.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMonedaBase.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboMonedaBase.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboMonedaBase.Columns("sCodigoInterno").Caption = "Código"
            Me.cboMonedaBase.Columns("sDescripcion").Caption = "Descripción"

            Me.cboMonedaBase.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMonedaBase.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarMonedaCambio
    ' Descripción:          Este procedimiento permite cargar el listado de Monedas
    '                       Cambio en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMonedaCambio()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbMonedaID,a.sCodigoInterno,a.sDescripcion,a.sSimbolo " & _
                         " From StbMoneda a " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "

            If XdsCombos.ExistTable("MonedaCambio") Then
                XdsCombos("MonedaCambio").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "MonedaCambio")
                XdsCombos("MonedaCambio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMonedaCambio.DataSource = XdsCombos("MonedaCambio").Source

            XdtValorParametro.Filter = "nStbParametroID = 18"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsCombos("MonedaCambio").Count > 0 Then
                Me.cboMonedaCambio.SelectedIndex = 0
                XdsCombos("MonedaCambio").SetCurrentByID("nStbMonedaID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboMonedaCambio.Splits(0).DisplayColumns("nStbMonedaID").Visible = False
            Me.cboMonedaCambio.Splits(0).DisplayColumns("sSimbolo").Visible = False

            Me.cboMonedaCambio.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMonedaCambio.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboMonedaCambio.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboMonedaCambio.Columns("sCodigoInterno").Caption = "Código"
            Me.cboMonedaCambio.Columns("sDescripcion").Caption = "Descripción"

            Me.cboMonedaCambio.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMonedaCambio.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean
        Dim dFechaDesde As Date
        Dim dFechaHasta As Date

        Try
            VbResultado = False

            'Moneda Base
            If Me.cboMonedaBase.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Moneda Base válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMonedaBase, "Debe seleccionar una Moneda Base válida.")
                Me.cboMonedaBase.Focus()
                GoTo SALIR
            End If

            'Moneda Cambio
            If Me.cboMonedaCambio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Moneda Cambio válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMonedaCambio, "Debe seleccionar una Moneda Cambio válida.")
                Me.cboMonedaCambio.Focus()
                GoTo SALIR
            End If

            dFechaDesde = Me.cdeFechaDesde.Value
            dFechaHasta = Me.cdeFechaHasta.Value

            'Fecha Desde y Hasta
            If dFechaDesde.Date > dFechaHasta.Date Then
                MsgBox("La Fecha Hasta DEBE ser mayor o igual que la Fecha Desde.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaHasta, "La Fecha Hasta DEBE ser mayor o igual que la Fecha Desde.")
                Me.cdeFechaHasta.Focus()
                GoTo SALIR
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidarParametros() = False Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Select Case mNomRep

                Case EnumReportes.rptStbTasaCambio
                    ObjReporte = RepTasaCambio()

            End Select

            If ObjReporte Is Nothing Then
                MsgBox("No hay datos para mostrar el reporte.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Si el destino del reporte es Pantalla
            If Me.radPantalla.Checked Then
                ImprimirEnPantalla(ObjReporte)

                'Si el destino del reporte es Impresora
            ElseIf Me.RadImpresora.Checked Then
                ImprimirEnImpresora(ObjReporte)

                'Si el destino del reporte es Archivo
            ElseIf Me.RadArchivo.Checked Then
                ImprimirEnArchivo(ObjReporte)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Reestablezco el cursor
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	ImprimirEnPantalla
    ' Description			   	:	Este procedimiento permite imprimir en pantalla un reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnPantalla(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        'Declaración de Variables
        Dim ObjVisorReporte As frmVisorReporte

        Try

            ObjVisorReporte = New frmVisorReporte

            'Seteo el text del reporte
            Select Case mNomRep
                Case EnumReportes.rptStbTasaCambio
                    ObjVisorReporte.Text = "Reporte de Tasa de Cambio"
            End Select

            ObjReporte.Run()
            ObjVisorReporte.VisorReportes.Document = ObjReporte.Document
            ObjVisorReporte.WindowState = FormWindowState.Maximized
            ObjVisorReporte.ShowDialog()


        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	ImprimirEnImpresora
    ' Description			   	:	Este procedimiento permite imprimir en la impresora un reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnImpresora(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        Try
            ObjReporte.Run()
            If ObjReporte.Document.Pages.Count > 0 Then
                ObjReporte.Document.Print(True, True)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	ImprimirEnArchivo
    ' Description			   	:	Este procedimiento permite imprimir en archivo un reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnArchivo(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)

        Try
            With Exportar

                .FilterIndex = 1
                .Filter = "PDF|*.pdf|XLS|*.xls|RTF|*.rtf"
                .Title = "Exportar Reporte"
                .InitialDirectory = MyCurrentDocs
                .OverwritePrompt = True
            End With

            If Exportar.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                ObjReporte.Run()
                If ObjReporte.Document.Pages.Count = 0 Then
                    Exit Sub
                End If
            End If

            Select Case Exportar.FilterIndex
                Case 1 'pdf
                    Dim ObjExportPDF As DataDynamics.ActiveReports.Export.Pdf.PdfExport
                    ObjExportPDF = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
                    ObjExportPDF.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato PDF con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 2 'excel
                    Dim ObjExportXLS As DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS = New DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato Excel con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 4 'rtf
                    Dim ObjExportRTF As DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF = New DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato rtf con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 5 'HTML
                    Dim ObjExportHTML As DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML = New DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato HTML con éxito !!!", MsgBoxStyle.Information, NombreSistema)
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSclParametroTasaCambio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing

            XdsCombos.Close()
            XdsCombos = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroTasaCambio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            CargarMonedaBase()
            CargarMonedaCambio()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	RepBarrio
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Listado de Tasas de Cambio
    ' -----------------------------------------------------------------------------------------
    Private Function RepTasaCambio() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptStbTasaCambio As rptStbTasaCambio

        Try
            ObjRptStbTasaCambio = New rptStbTasaCambio

            'Moneda Base
            ObjRptStbTasaCambio.IdMonedaBase = XdsCombos("MonedaBase").ValueField("nStbMonedaID")
            ObjRptStbTasaCambio.MonedaBase = UCase(Me.cboMonedaBase.Text)

            'Moneda Cambio
            ObjRptStbTasaCambio.IdMonedaCambio = XdsCombos("MonedaCambio").ValueField("nStbMonedaID")
            ObjRptStbTasaCambio.MonedaCambio = UCase(Me.cboMonedaCambio.Text)

            'Fecha Desde
            ObjRptStbTasaCambio.FechaDesde = Me.cdeFechaDesde.Value

            'Fecha Hasta
            ObjRptStbTasaCambio.FechaHasta = Me.cdeFechaHasta.Value

            Return ObjRptStbTasaCambio

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

End Class