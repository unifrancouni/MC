Public Class frmStbParamCatalogoValor

    'Declaracion de Variables 
    Dim XdtEstados As BOSistema.Win.XDataSet.xDataTable
    Dim XdtCatalogos As BOSistema.Win.XDataSet.xDataTable
    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3

    'Listado de Reportes
    Public Enum EnumReportesCatalogoValor
        StbCatCatalogoValor = 1
    End Enum
    Dim mNombreReporte As EnumReportesCatalogoValor
    Public Property NombreReporteCat() As EnumReportesCatalogoValor
        Get
            Return mNombreReporte
        End Get
        Set(ByVal value As EnumReportesCatalogoValor)
            mNombreReporte = value
        End Set
    End Property
    Private Sub frmStbParamCatalogoValor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Declaracion de Variables 
        Dim ObjGUI As GUI.ClsGUI

        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            EstablecerTituloReporte()

            If mNombreReporte = EnumReportesCatalogoValor.StbCatCatalogoValor Then
                CargarEstados()              
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	InicializaVariables
    ' Description			   	:	Inicializa las variables generales de la pantalla de parametro
    '                               del Catalogo Valor.
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdtEstados = New BOSistema.Win.XDataSet.xDataTable
            XdtCatalogos = New BOSistema.Win.XDataSet.xDataTable
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	EstablecerTituloReporte
    ' Description			   	:	Definir el titulo del reporte segun la opcion seleccionada
    '                               por el usuario
    ' -----------------------------------------------------------------------------------------
    Private Sub EstablecerTituloReporte()
        Try
            'Seteo el text del reporte
            Select Case mNombreReporte
                Case EnumReportesCatalogoValor.StbCatCatalogoValor
                    Me.Text = "Parámetros Reporte de Catálogos y sus Valores"
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If FncValidaParametros() = False Then
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor

            Select Case mNombreReporte
                Case EnumReportesCatalogoValor.StbCatCatalogoValor                
                    ObjReporte = RepCatalogoValor()
            End Select

            If ObjReporte Is Nothing Then
                MsgBox("No se encontraron datos que mostrar", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Verificar el Destino del Reporte
            'Si es PANTALLA
            If Me.RadioPant.Checked Then
                ImprimirEnPantalla(ObjReporte)
                'Si es IMPRESORA
            ElseIf Me.radImpresora.Checked Then
                'Si es ARCHIVO
                ImprimirEnImpresora(ObjReporte)
            ElseIf Me.radArchivo.Checked Then
                ImprimirEnArchivo(ObjReporte)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	FncValidaParametros
    ' Description			   	:	Esta función valida los datos requeridos para imprimir la 
    '                               opción de Reporte seleccionada.
    ' -----------------------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean

        'Declaración de Variables -----------------------
        Dim VbResultado As Boolean
        Dim XdtGeneral As BOSistema.Win.XDataSet.xDataTable
        Dim IdCatalogo As Long
        Dim IdEstado As Integer
        Dim StrSql As String
        '-------------------------------------------------
        Try
            VbResultado = False
            XdtGeneral = New BOSistema.Win.XDataSet.xDataTable
            StrSql = ""
            IdCatalogo = -19
            IdEstado = -19
            '-----------------
            'Si el Reporte es el de Catalogo y sus Valores
            If mNombreReporte = EnumReportesCatalogoValor.StbCatCatalogoValor Then
                If Trim(Me.cboCatalogo.Text).Length = 0 Then
                    IdCatalogo = -19
                Else
                    IdCatalogo = XdtCatalogos("nStbCatalogoID")
                End If

                If Trim(Me.cboEstado.Text).Length <> 0 Then
                    IdEstado = XdtEstados("IdEstado")
                End If
                '--------------------------------------------------------
                StrSql = " Select IsNull(Count(*),0) As CantRegistros " & _
                         " From   vwStbCatalogos " & _
                         " Where (nStbCatalogoID  = " & IdCatalogo & " Or " & IdCatalogo & " = -19) And " & _
                         "       (nActivo         = " & IdEstado & " Or " & IdEstado & " = -19)"
                '--------------------------------------------------------
            End If
            XdtGeneral.ExecuteSql(StrSql)
            If XdtGeneral("CantRegistros") <= 0 Then
                MsgBox("No se encontraron datos que mostrar en el reporte", MsgBoxStyle.Critical, NombreSistema)
                GoTo SALIR
            End If

            VbResultado = True
SALIR:
            Return VbResultado

        Catch ex As Exception
            Control_Error(ex)
            Return False
        Finally
            XdtGeneral = Nothing
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	RepCatalogoValor
    ' Description			   	:	Esta funcion crea la instancia y establece los parametros
    '                               del reporte de Catalogo y Valor Catálogo.
    ' -----------------------------------------------------------------------------------------
    Private Function RepCatalogoValor() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables 
        Dim ObjReporte As rptStbCatCatalogoValor
        Dim IdCatalogo As Long
        Dim IdEstado As Integer

        Try
            ObjReporte = New rptStbCatCatalogoValor
            '---------------------
            If Trim(Me.cboCatalogo.Text).Length = 0 Then
                IdCatalogo = 0
            Else
                IdCatalogo = XdtCatalogos("nStbCatalogoID")
            End If
            If Trim(Me.cboEstado.Text).Length = 0 Then
                IdEstado = -19
            Else
                IdEstado = XdtEstados("IdEstado")
            End If
            '----------------------            
            ObjReporte.IdCatalogo = IdCatalogo
            ObjReporte.Catalogo = Me.cboCatalogo.Text
            ObjReporte.IdEstado = IdEstado
            ObjReporte.EstadoEstado = Trim(Me.cboEstado.Text)
            '----------------------
            Return ObjReporte

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	ImprimirEnPantalla
    ' Description			   	:	Este procedimiento permite imprimir en pantalla la opción de
    '                               Reporte seleccionada por el Usuario.
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnPantalla(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)

        'Declaracion de Variables 
        Dim ObjFrmVisorRep As frmVisorReporte

        Try
            ObjFrmVisorRep = New frmVisorReporte

            'Verificar el Reporte seleccionado
            Select Case mNombreReporte
                Case EnumReportesCatalogoValor.StbCatCatalogoValor
                    ObjFrmVisorRep.Text = "Reporte del Catálogo y sus Valores"
            End Select
            ObjReporte.Run()
            ObjFrmVisorRep.visorReportes.Document = ObjReporte.Document
            ObjFrmVisorRep.WindowState = FormWindowState.Maximized
            ObjFrmVisorRep.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmVisorRep = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	ImprimirEnArchivo
    ' Description			   	:	Este procedimiento permite imprimir en archivo un reporte    
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnArchivo(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)

        'Declaracion de Variables 
        Dim ObjExportPDF As DataDynamics.ActiveReports.Export.Pdf.PdfExport
        Dim ObjExportXLS As DataDynamics.ActiveReports.Export.Xls.XlsExport
        Dim ObjExportRTF As DataDynamics.ActiveReports.Export.Rtf.RtfExport
        Dim ObjExportHTML As DataDynamics.ActiveReports.Export.Html.HtmlExport

        Try
            Exportar.InitialDirectory = MyCurrentDocs
            Exportar.OverwritePrompt = True

            Exportar.ShowDialog()
            ObjExportPDF = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
            ObjExportXLS = New DataDynamics.ActiveReports.Export.Xls.XlsExport
            ObjExportRTF = New DataDynamics.ActiveReports.Export.Rtf.RtfExport
            ObjExportHTML = New DataDynamics.ActiveReports.Export.Html.HtmlExport

            If Not Exportar.FileName Is Nothing Or _
                   Exportar.FileName <> "" Then
                ObjReporte.Run()

                If ObjReporte.Document.Pages.Count = 0 Then
                    Exit Sub
                End If

                Select Case Exportar.FilterIndex
                    Case 1 'PDF
                        ObjExportPDF.Export(ObjReporte.Document, Exportar.FileName)
                        MsgBox("El reporte se exportó en formato PDF con éxito", MsgBoxStyle.Information, NombreSistema)

                    Case 2 'EXCEL
                        ObjExportXLS.Export(ObjReporte.Document, Exportar.FileName)
                        MsgBox("El reporte se exportó en formato Excel con éxito", MsgBoxStyle.Information, NombreSistema)

                    Case 4 'RTF
                        ObjExportRTF.Export(ObjReporte.Document, Exportar.FileName)
                        MsgBox("El reporte se exportó en formato rtf con éxito", MsgBoxStyle.Information, NombreSistema)

                    Case 5 'HTML
                        ObjExportHTML.Export(ObjReporte.Document, Exportar.FileName)
                        MsgBox("El reporte se exportó en formato HTML con éxito", MsgBoxStyle.Information, NombreSistema)
                End Select
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjExportPDF = Nothing
            ObjExportXLS = Nothing
            ObjExportRTF = Nothing
            ObjExportHTML = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
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
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	CargarEstados
    ' Description			   	:	Cargar los Estados posibles     
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarEstados()

        'Declaracion de Variables 
        Dim Strsql As String

        Try
            Strsql = ""
            '---------------------------------------
            Strsql = " Select -19    As IdEstado," & _
                     "       'Todos' As Estado, " & _
                     "       0       As Orden "
            XdtEstados.ExecuteSql(Strsql)
            XdtEstados.AddRow()
            XdtEstados("IdEstado") = 1
            XdtEstados("Estado") = "Activo"
            XdtEstados("Orden") = 1
            XdtEstados.UpdateLocal()

            XdtEstados.AddRow()
            XdtEstados("IdEstado") = 0
            XdtEstados("Estado") = "Inactivo"
            XdtEstados("Orden") = 2
            XdtEstados.UpdateLocal()
            '-----------------------------------
            Me.cboEstado.DataSource = XdtEstados.Source

            Me.cboEstado.Splits(0).DisplayColumns("IdEstado").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Estado").Width = 80
            Me.cboEstado.DisplayMember = "Estado"
            Me.cboEstado.ValueMember = "IdEstado"
            '--------------
            If XdtEstados.Count > 0 Then
                cboEstado.SelectedIndex = 0
            End If
            '--------------
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	CargarCatalogos
    ' Description			   	:	Cargar la lista de Catálogos
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarCatalogos()

        'Declaracion de Variables 
        Dim Strsql As String
        Dim IdEstado As Integer

        Try
            Strsql = ""
            XdtCatalogos = New BOSistema.Win.XDataSet.xDataTable
            '-------------------
            IdEstado = -19
            If Trim(Me.cboEstado.Text).Length <> 0 Then
                IdEstado = XdtEstados("IdEstado")
            End If
            '--------------------
            Strsql = " Select nStbCatalogoID, " & _
                     "        sNombre, " & _
                     "        nActivo, " & _
                     "        1 As Orden " & _
                     " From   StbCatalogo " & _
                     " Where (nActivo = " & IdEstado & " Or " & IdEstado & " = -19)"
            XdtCatalogos.ExecuteSql(Strsql)
            '---------------------
            XdtCatalogos.AddRow()
            XdtCatalogos("nStbCatalogoID") = -19
            XdtCatalogos("sNombre") = "Todos"
            XdtCatalogos("Orden") = 0
            XdtCatalogos.UpdateLocal()
            XdtCatalogos.Sort = "Orden, sNombre ASC"
            '---------------------
            Me.cboCatalogo.DataSource = XdtCatalogos.Source
            Me.cboCatalogo.Columns("nActivo").Caption = "¿Activo?"
            Me.cboCatalogo.Splits(0).DisplayColumns("nStbCatalogoID").Visible = False
            Me.cboCatalogo.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboCatalogo.Columns("nActivo").ValueItems.Presentation = C1.Win.C1List.PresentationEnum.CheckBox

            Me.cboCatalogo.Splits(0).DisplayColumns("sNombre").Width = 150
            Me.cboCatalogo.Splits(0).DisplayColumns("nActivo").Width = 30

            Me.cboCatalogo.DisplayMember = "sNombre"
            Me.cboCatalogo.ValueMember = "nStbCatalogoID"
            '---------------------
            If XdtCatalogos.Count > 0 Then
                XdtCatalogos.Source.MoveFirst()
                Me.cboCatalogo.SelectedIndex = XdtCatalogos.Source.Position                
            End If
            '---------------------
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cboEstado_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedValueChanged
        Try
            If Trim(Me.cboEstado.Text).Length = 0 Then
                Exit Sub
            End If

            'Refrescar la lista de Catalogos segun el Estado
            CargarCatalogos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class