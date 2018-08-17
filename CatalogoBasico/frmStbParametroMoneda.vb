' ------------------------------------------------------------------------
' Autor:                
' Fecha:                21/11/2006
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    FrmStbParametroMoneda.vb
' Descripción:          Este formulario posee los Parametros de Entrada de los 
'                       Reporte de rpStbMoneda
'-------------------------------------------------------------------------

Public Class frmStbParametroMoneda
    '-- Declaracion de Variables 
    'Dim strModoForm As String
    Dim mNomRep As EnumReportes
    Dim ObjReporteMoneda As DataDynamics.ActiveReports.ActiveReport3
    Dim XdtEstados As BOSistema.Win.XDataSet.xDataTable

    'Listado de Reportes
    Public Enum EnumReportes
        rptSteMoneda = 1
        rptStbCargo = 2
        rptStbProfesion = 3
    End Enum

    Private Sub frmStbParametroMoneda_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtEstados.Close()
            XdtEstados = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub frmStbParametroMoneda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarEstados()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    'Declaracion de Variables
    Private Sub InicializarVariables()
        Try
            XdtEstados = New BOSistema.Win.XDataSet.xDataTable

            'If ModoFrm = "IMPRIMIR" Then
            Select Case mNomRep
                Case EnumReportes.rptSteMoneda
                    Me.Text = "Parámetros Reporte de Moneda"
                Case EnumReportes.rptStbCargo
                    Me.Text = "Parámetros Reporte de Cargos"
                Case EnumReportes.rptStbProfesion
                    Me.Text = "Parámetros Reporte de Profesiones"
            End Select
            'End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Imprimir el Reporte.
    'Public Property ModoFrm() As String
    '    Get
    '        ModoFrm = strModoForm
    '    End Get
    '    Set(ByVal value As String)
    '        strModoForm = value
    '    End Set
    'End Property

    'Propiedad utilizada para el identificar el nombre de reporte que se va a generar 
    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case mNomRep
                Case EnumReportes.rptSteMoneda
                    ObjReporteMoneda = RepMoneda()
                Case EnumReportes.rptStbCargo
                    ObjReporteMoneda = RepCargo()
                Case EnumReportes.rptStbProfesion
                    ObjReporteMoneda = RepProfesion()
            End Select

            If ObjReporteMoneda Is Nothing Then
                MsgBox("No hay datos para mostrar el reporte.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Si el destino del reporte es Pantalla
            If Me.RadioPant.Checked Then
                ImprimirEnPantalla(ObjReporteMoneda)

                'Si el destino del reporte es Impresora
            ElseIf Me.radImpresora.Checked Then
                'Si el destino del reporte es Archivo

                ImprimirEnImpresora(ObjReporteMoneda)

            ElseIf Me.radArchivo.Checked Then
                ImprimirEnArchivo(ObjReporteMoneda)
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	21/11/2006
    ' Procedure name		   	:	ImprimirEnPantalla
    ' Description			   	:	Este procedimiento permite imprimir en pantalla un reporte
    ' Function Return Type Name	:
    ' Parameters				:
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnPantalla(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        Dim ObjVisorReporte As frmVisorReporte
        Try
            ObjVisorReporte = New frmVisorReporte
            'Seteo el text del reporte
            'Me.Cursor = Cursors.Default
            Select Case mNomRep
                Case EnumReportes.rptSteMoneda
                    ObjVisorReporte.Text = "Reporte de Moneda"
                Case EnumReportes.rptStbCargo
                    ObjVisorReporte.Text = "Reporte de Cargo"
                Case EnumReportes.rptStbProfesion
                    ObjVisorReporte.Text = "Reporte de Profesión"
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
    ' Author		    		:	
    ' Date			    		:	21/11/2006
    ' Procedure name		   	:	ImprimirEnImpresora
    ' Description			   	:	Este procedimiento permite imprimir en la impresora un reporte
    ' Function Return Type Name	:
    ' Parameters				:
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnImpresora(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        Try
            ObjReporte.Run()
            If ObjReporte.Document.Pages.Count > 0 Then
                ObjReporte.Document.Print(True, True)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	21/11/2006
    ' Procedure name		   	:	ImprimirEnArchivo
    ' Description			   	:	Este procedimiento permite imprimir en archivo un reporte
    ' Function Return Type Name	:
    ' Parameters				:
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
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12 de Septiembre del 2007
    ' Procedure name		   	:	CargarEstados
    ' Description			   	:	Cargar los estados de Moneda
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarEstados()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdEstado, " & _
                     "      'Todos'     As Estado, " & _
                     "        0         As Orden "

            XdtEstados.ExecuteSql(Strsql)
            XdtEstados.AddRow()
            XdtEstados("IdEstado") = 1
            XdtEstados("Estado") = "Activo"
            XdtEstados("Orden") = 1
            XdtEstados.UpdateLocal()
            '--------------------------------

            XdtEstados.AddRow()
            XdtEstados("IdEstado") = 0
            XdtEstados("Estado") = "Inactivo"
            XdtEstados("Orden") = 2
            XdtEstados.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboEstado.DataSource = XdtEstados.Source

            'Formateando el Combo
            Me.cboEstado.Splits(0).DisplayColumns("IdEstado").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboEstado.Columns("Estado").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtEstados.Count > 0 Then
                Me.cboEstado.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:  
    ' Date			    		:	21/11/2006
    ' Procedure name		   	:	RepMoneda
    ' Description			   	:	Esta Funcion permite generar el reporte de Moneda
    '                           
    ' Function Return Type Name	:    Objeto de tipo de reporte
    ' -----------------------------------------------------------------------------------------
    Private Function RepMoneda() As DataDynamics.ActiveReports.ActiveReport3
        Dim ObjRptStbMoneda As rptStbMoneda
        Try

            ObjRptStbMoneda = New rptStbMoneda

            'Estado del Barrio
            ObjRptStbMoneda.IdEstado = XdtEstados("IdEstado")
            ObjRptStbMoneda.Estado = UCase(Me.cboEstado.Text)


            Return ObjRptStbMoneda

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
        Return ObjRptStbMoneda
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	18/01/2007
    ' Procedure name		   	:	RepCuentaBancaria
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Cuenta Bancaria
    ' -----------------------------------------------------------------------------------------
    Private Function RepCargo() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRepCargo As rptStbCargo

        Try
            ObjRepCargo = New rptStbCargo

            ObjRepCargo.IdEstado = XdtEstados("IdEstado")
            ObjRepCargo.Estado = UCase(Me.cboEstado.Text)

            Return ObjRepCargo

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	18/01/2007
    ' Procedure name		   	:	RepProfesion
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Profesiones
    ' -----------------------------------------------------------------------------------------
    Private Function RepProfesion() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRepProfesion As rptStbProfesion

        Try
            ObjRepProfesion = New rptStbProfesion

            ObjRepProfesion.IdEstado = XdtEstados("IdEstado")
            ObjRepProfesion.Estado = UCase(Me.cboEstado.Text)

            Return ObjRepProfesion

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function
End Class