Public Class frmSclParametroFicha

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3

    Dim intFichaID As Integer
    Dim intConsecutivoPrestamo As Integer

    'Listado de Reportes
    Public Enum EnumReportes
        rptSclFichaInscripcion = 1
        rptSclFichaVerificacion = 2
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
    Public Property intSclFichaID() As Integer
        Get
            intSclFichaID = intFichaID
        End Get
        Set(ByVal value As Integer)
            intFichaID = value
        End Set
    End Property
    'Consecutivo de Préstamo del Grupo de la Ficha seleccionada
    Public Property IdConsecutivoPrestamo() As Integer
        Get
            IdConsecutivoPrestamo = intConsecutivoPrestamo
        End Get
        Set(ByVal value As Integer)
            intConsecutivoPrestamo = value
        End Set
    End Property


    Private Sub InicializarVariables()
        Dim XdtDatosEncabezado As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String


            strSQL = " Select a.sCodigo,b.sDescripcion as sEstado " & _
                     " From SclFichaSocia a INNER JOIN StbValorCatalogo b " & _
                     " ON a.nStbEstadoFichaID = b.nStbValorCatalogoID " & _
                     " WHERE a.nSclFichaSociaID = " & Me.intFichaID

            XdtDatosEncabezado.ExecuteSql(strSQL)

            If XdtDatosEncabezado.Count > 0 Then
                Me.txtCodigo.Text = XdtDatosEncabezado.ValueField("sCodigo")
                Me.txtEstado.Text = XdtDatosEncabezado.ValueField("sEstado")
            End If

            'Titúlo de Reporte
            Select Case mNomRep

                Case EnumReportes.rptSclFichaInscripcion
                    Me.Text = "Parámetros Reporte de Ficha de Inscripción"
                Case EnumReportes.rptSclFichaVerificacion
                    Me.Text = "Parámetros Reporte de Ficha de Verificación"

            End Select

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatosEncabezado.Close()
            XdtDatosEncabezado = Nothing
        End Try
    End Sub

    '    Private Function ValidarParametros() As Boolean

    '        'Declaracion de Variables 
    '        Dim VbResultado As Boolean
    '        Dim XdtGeneral As BOSiafi.Win.XDataSet.xDataTable
    '        Dim StrSQL As String = ""
    '        Dim IdCtaBancaria As Long

    '        Try
    '            VbResultado = False
    '            XdtGeneral = New BOSiafi.Win.XDataSet.xDataTable
    '            IdCtaBancaria = -19

    '            'Reporte de Cuenta Bancarias
    '            If mNomRep = EnumReportes.rptSteCuentaBancaria Then
    '                If Trim(Me.cboEstado.Text).Length = 0 Then
    '                    IdCtaBancaria = -19
    '                Else
    '                    IdCtaBancaria = ObjvalorCatalogo("StbValorCatalogoID")
    '                End If

    '                '-----------------
    '                'If Me.chkFirmas.Checked = True Then
    '                '    StrSQL = " Select isNull(count(*),0) as CantRegistros " & _
    '                '             " From   VwSteCtaBancariaFirmas " & _
    '                '             " Where  (IdEstadoCuenta  = " & XdtEstadosCuenta("IdEstadoC") & " Or " & XdtEstadosCuenta("IdEstadoC") & "  = -19) And " & _
    '                '            "(ActivoFirma     = " & XdtEstados("IdEstado") & " Or " & XdtEstados("IdEstado") & " = -19 ) "


    '                'Else

    '                StrSQL = " Select isNull(count(*),0) as CantRegistros " & _
    '                         " From   VwSteCtaBancaria " & _
    '                        " Where (IdEstadoCuenta      = " & XdtEstadosCuenta("IdEstadoC") & " Or " & XdtEstadosCuenta("IdEstadoC") & "  = -19 )"
    '            End If
    '            'End If

    '            XdtGeneral.ExecuteSql(StrSQL)
    '            '-----------------------------
    '            If XdtGeneral("CantRegistros") <= 0 Then
    '                MsgBox("No se encontraron datos que mostrar en el reporte", MsgBoxStyle.Critical, NombreSistema)
    '                GoTo SALIR
    '            End If

    '            VbResultado = True
    'salir:
    '            Return VbResultado
    '        Catch ex As Exception
    '            Control_Error(ex)
    '        Finally
    '            XdtGeneral = Nothing
    '        End Try
    '    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            'If ValidarParametros() = False Then
            '    Exit Sub
            'End If

            Me.Cursor = Cursors.WaitCursor

            Select Case mNomRep

                Case EnumReportes.rptSclFichaInscripcion
                    ObjReporte = RepFichaInscripcion()

                Case EnumReportes.rptSclFichaVerificacion
                    ObjReporte = RepFichaVerificacion()

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
                Case EnumReportes.rptSclFichaInscripcion
                    ObjVisorReporte.Text = "Reporte de Ficha de Inscripción"
                Case EnumReportes.rptSclFichaVerificacion
                    ObjVisorReporte.Text = "Reporte de Ficha de Verificación"
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

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSclParametroFicha_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

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
    ' Procedure name		   	:	RepFichaInscripcion
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Ficha
    ' -----------------------------------------------------------------------------------------
    Private Function RepFichaInscripcion() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclFichaInscripcion As rptSclFichaInscripcion

        Try
            ObjRptSclFichaInscripcion = New rptSclFichaInscripcion

            'Estado del Barrio
            ObjRptSclFichaInscripcion.IdFicha = Me.intFichaID
            ObjRptSclFichaInscripcion.IdConsecutivoPrestamo = Me.IdConsecutivoPrestamo

            Return ObjRptSclFichaInscripcion

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	RepFichaVerificacion
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Ficha
    ' -----------------------------------------------------------------------------------------
    Private Function RepFichaVerificacion() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclFichaVerificacion As rptSclFichaVerificacion

        Try
            ObjRptSclFichaVerificacion = New rptSclFichaVerificacion

            'Estado del Barrio
            ObjRptSclFichaVerificacion.IdFicha = Me.intFichaID
            'ObjRptSclFichaVerificacion.IdConsecutivoPrestamo = Me.IdConsecutivoPrestamo

            Return ObjRptSclFichaVerificacion

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function
End Class