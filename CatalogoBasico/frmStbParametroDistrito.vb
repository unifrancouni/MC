Public Class frmStbParametroDistrito

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdtEstados As BOSistema.Win.XDataSet.xDataTable
    Dim XdtPertenece As BOSistema.Win.XDataSet.xDataTable
    Dim Strsql As String

    'Listado de Reportes
    Public Enum EnumReportes
        rptStbDistrito = 1
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
            XdtPertenece = New BOSistema.Win.XDataSet.xDataTable
            XdtEstados = New BOSistema.Win.XDataSet.xDataTable

            'Titúlo de Reporte
            Select Case mNomRep

                Case EnumReportes.rptStbDistrito
                    Me.Text = "Parámetros Reporte de Distrito"
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12 de Septiembre del 2007
    ' Procedure name		   	:	CargarEstados
    ' Description			   	:	Cargar los estados de Distritos
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
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12 de Septiembre del 2007
    ' Procedure name		   	:	CargarPertenece
    ' Description			   	:	Cargar las posibles variantes de si pertenece al programa.
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarPertenece()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdPertenece, " & _
                     "      'Todos'     As Pertenece, " & _
                     "        0         As Orden "

            XdtPertenece.ExecuteSql(Strsql)
            XdtPertenece.AddRow()
            XdtPertenece("IdPertenece") = 1
            XdtPertenece("Pertenece") = "Si"
            XdtPertenece("Orden") = 1
            XdtPertenece.UpdateLocal()
            '--------------------------------

            XdtPertenece.AddRow()
            XdtPertenece("IdPertenece") = 0
            XdtPertenece("Pertenece") = "No"
            XdtPertenece("Orden") = 2
            XdtPertenece.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboIncluidoPrograma.DataSource = XdtPertenece.Source

            'Formateando el Combo
            Me.cboIncluidoPrograma.Splits(0).DisplayColumns("IdPertenece").Visible = False
            Me.cboIncluidoPrograma.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboIncluidoPrograma.Columns("Pertenece").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtPertenece.Count > 0 Then
                Me.cboIncluidoPrograma.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            'If ValidarParametros() = False Then
            '    Exit Sub
            'End If

            Me.Cursor = Cursors.WaitCursor

            Select Case mNomRep

                Case EnumReportes.rptStbDistrito
                    ObjReporte = RepDistrito()

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
                Case EnumReportes.rptStbDistrito
                    ObjVisorReporte.Text = "Reporte de Distrito"
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

    Private Sub frmSclParametroBarrio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing

            XdtEstados.Close()
            XdtEstados = Nothing

            XdtPertenece.Close()
            XdtPertenece = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroBarrio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            If mNomRep = EnumReportes.rptStbDistrito Then
                CargarPertenece()
                CargarEstados()
            End If

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
    '                           :   de Listado de Distritos
    ' -----------------------------------------------------------------------------------------
    Private Function RepDistrito() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptStbDistrito As rptStbDistrito

        Try
            ObjRptStbDistrito = New rptStbDistrito

            'Estado del Barrio
            ObjRptStbDistrito.IdEstado = XdtEstados("IdEstado")
            ObjRptStbDistrito.Estado = UCase(Me.cboEstado.Text)

            'Pertenece Programa
            ObjRptStbDistrito.IdPertenece = XdtPertenece("IdPertenece")
            ObjRptStbDistrito.Pertenece = UCase(Me.cboIncluidoPrograma.Text)

            Return ObjRptStbDistrito

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

End Class