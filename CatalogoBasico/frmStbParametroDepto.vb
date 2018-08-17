Public Class frmStbParametroDepto

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdtEstadosMunicipio As BOSistema.Win.XDataSet.xDataTable
    Dim XdtEstadosDepto As BOSistema.Win.XDataSet.xDataTable
    Dim XdtPerteneceMunicipio As BOSistema.Win.XDataSet.xDataTable
    Dim XdtPerteneceDepto As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDepartamento As BOSistema.Win.XDataSet.xDataTable

    Dim Strsql As String

    'Listado de Reportes
    Public Enum EnumReportes
        rptStbDepartamento = 1

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
            XdtEstadosMunicipio = New BOSistema.Win.XDataSet.xDataTable
            XdtEstadosDepto = New BOSistema.Win.XDataSet.xDataTable
            XdtPerteneceMunicipio = New BOSistema.Win.XDataSet.xDataTable
            XdtPerteneceDepto = New BOSistema.Win.XDataSet.xDataTable
            XdtDepartamento = New BOSistema.Win.XDataSet.xDataTable

            Me.cboEstadoMunic.Enabled = False
            Me.cboEstadoMunic.SelectedIndex = -1

            Me.cboIncluidoProgramaMunic.Enabled = False
            Me.cboIncluidoProgramaMunic.SelectedIndex = -1

            Me.cboDepartamento.Enabled = False
            Me.cboDepartamento.SelectedIndex = -1

            Me.chkMunicipio.Checked = False

            'Titúlo de Reporte
            Select Case mNomRep

                Case EnumReportes.rptStbDepartamento
                    Me.Text = "Parámetros Reporte de Departamento/Municipio"
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	18 de Enero del 2007
    ' Procedure name		   	:	CargarEstadosMunicipio
    ' Description			   	:	Cargar los estados de los Municipios
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarEstadosMunicipio()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdEstado, " & _
                     "      'Todos'     As Estado, " & _
                     "        0         As Orden "

            XdtEstadosMunicipio.ExecuteSql(Strsql)
            XdtEstadosMunicipio.AddRow()
            XdtEstadosMunicipio("IdEstado") = 1
            XdtEstadosMunicipio("Estado") = "Activo"
            XdtEstadosMunicipio("Orden") = 1
            XdtEstadosMunicipio.UpdateLocal()
            '--------------------------------

            XdtEstadosMunicipio.AddRow()
            XdtEstadosMunicipio("IdEstado") = 0
            XdtEstadosMunicipio("Estado") = "Inactivo"
            XdtEstadosMunicipio("Orden") = 2
            XdtEstadosMunicipio.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboEstadoMunic.DataSource = XdtEstadosMunicipio.Source

            'Formateando el Combo
            Me.cboEstadoMunic.Splits(0).DisplayColumns("IdEstado").Visible = False
            Me.cboEstadoMunic.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboEstadoMunic.Columns("Estado").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtEstadosMunicipio.Count > 0 Then
                Me.cboEstadoMunic.SelectedIndex = 0
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	18 de Enero del 2007
    ' Procedure name		   	:	CargarEstadosDepto
    ' Description			   	:	Cargar los estados de los Departamentos
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarEstadosDepto()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdEstado, " & _
                     "      'Todos'     As Estado, " & _
                     "        0         As Orden "

            XdtEstadosDepto.ExecuteSql(Strsql)
            XdtEstadosDepto.AddRow()
            XdtEstadosDepto("IdEstado") = 1
            XdtEstadosDepto("Estado") = "Activo"
            XdtEstadosDepto("Orden") = 1
            XdtEstadosDepto.UpdateLocal()
            '--------------------------------

            XdtEstadosDepto.AddRow()
            XdtEstadosDepto("IdEstado") = 0
            XdtEstadosDepto("Estado") = "Inactivo"
            XdtEstadosDepto("Orden") = 2
            XdtEstadosDepto.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboEstado.DataSource = XdtEstadosDepto.Source

            'Formateando el Combo
            Me.cboEstado.Splits(0).DisplayColumns("IdEstado").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboEstado.Columns("Estado").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtEstadosDepto.Count > 0 Then
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
    Private Sub CargarPerteneceMunic()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdPertenece, " & _
                     "      'Todos'     As Pertenece, " & _
                     "        0         As Orden "

            XdtPerteneceMunicipio.ExecuteSql(Strsql)
            XdtPerteneceMunicipio.AddRow()
            XdtPerteneceMunicipio("IdPertenece") = 1
            XdtPerteneceMunicipio("Pertenece") = "Si"
            XdtPerteneceMunicipio("Orden") = 1
            XdtPerteneceMunicipio.UpdateLocal()
            '--------------------------------

            XdtPerteneceMunicipio.AddRow()
            XdtPerteneceMunicipio("IdPertenece") = 0
            XdtPerteneceMunicipio("Pertenece") = "No"
            XdtPerteneceMunicipio("Orden") = 2
            XdtPerteneceMunicipio.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboIncluidoProgramaMunic.DataSource = XdtPerteneceMunicipio.Source

            'Formateando el Combo
            Me.cboIncluidoProgramaMunic.Splits(0).DisplayColumns("IdPertenece").Visible = False
            Me.cboIncluidoProgramaMunic.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboIncluidoProgramaMunic.Columns("Pertenece").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtPerteneceMunicipio.Count > 0 Then
                Me.cboIncluidoProgramaMunic.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"

            XdtDepartamento.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdtDepartamento.Source

            'XdtValorParametro.Filter = "nStbParametroID = 14"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsCombos("Departamento").Count > 0 Then
            '    XdsCombos("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDepartamento.ListCount > 0 Then
                XdtDepartamento.AddRow()
                XdtDepartamento.ValueField("Descripcion") = "Todos"
                XdtDepartamento.ValueField("nStbDepartamentoID") = -19
                XdtDepartamento.ValueField("Orden") = 0
                XdtDepartamento.UpdateLocal()
                XdtDepartamento.Sort = "Orden,sCodigo asc"
                Me.cboDepartamento.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12 de Septiembre del 2007
    ' Procedure name		   	:	CargarPertenece
    ' Description			   	:	Cargar las posibles variantes de si pertenece al programa.
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarPerteneceDepto()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdPertenece, " & _
                     "      'Todos'     As Pertenece, " & _
                     "        0         As Orden "

            XdtPerteneceDepto.ExecuteSql(Strsql)
            XdtPerteneceDepto.AddRow()
            XdtPerteneceDepto("IdPertenece") = 1
            XdtPerteneceDepto("Pertenece") = "Si"
            XdtPerteneceDepto("Orden") = 1
            XdtPerteneceDepto.UpdateLocal()
            '--------------------------------

            XdtPerteneceDepto.AddRow()
            XdtPerteneceDepto("IdPertenece") = 0
            XdtPerteneceDepto("Pertenece") = "No"
            XdtPerteneceDepto("Orden") = 2
            XdtPerteneceDepto.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboIncluidoPrograma.DataSource = XdtPerteneceDepto.Source

            'Formateando el Combo
            Me.cboIncluidoPrograma.Splits(0).DisplayColumns("IdPertenece").Visible = False
            Me.cboIncluidoPrograma.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboIncluidoPrograma.Columns("Pertenece").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtPerteneceDepto.Count > 0 Then
                Me.cboIncluidoPrograma.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean
        'Dim StrSQL As String = ""

        Try
            'VbResultado = False
            'XdtGeneral = New BOSiafi.Win.XDataSet.xDataTable
            'IdCtaBancaria = -19

            ''Reporte de Cuenta Bancarias
            'If mNomRep = EnumReportes.rptSteCuentaBancaria Then
            '    If Trim(Me.cboEstado.Text).Length = 0 Then
            '        IdCtaBancaria = -19
            '    Else
            '        IdCtaBancaria = ObjvalorCatalogo("StbValorCatalogoID")
            '    End If

            '    '-----------------
            '    If Me.chkMunicipio.Checked = True Then
            '        StrSQL = " Select isNull(count(*),0) as CantRegistros " & _
            '                 " From   VwSteCtaBancariaFirmas " & _
            '                 " Where  (IdEstadoCuenta  = " & XdtEstadosCuenta("IdEstadoC") & " Or " & XdtEstadosCuenta("IdEstadoC") & "  = -19) And " & _
            '                "(ActivoFirma     = " & XdtEstados("IdEstado") & " Or " & XdtEstados("IdEstado") & " = -19 ) "


            '    Else

            '        StrSQL = " Select isNull(count(*),0) as CantRegistros " & _
            '                 " From   VwSteCtaBancaria " & _
            '                " Where (IdEstadoCuenta      = " & XdtEstadosCuenta("IdEstadoC") & " Or " & XdtEstadosCuenta("IdEstadoC") & "  = -19 )"
            '    End If
            'End If

            'XdtGeneral.ExecuteSql(StrSQL)
            ''-----------------------------
            'If XdtGeneral("CantRegistros") <= 0 Then
            '    MsgBox("No se encontraron datos que mostrar en el reporte", MsgBoxStyle.Critical, NombreSistema)
            '    GoTo SALIR
            'End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtGeneral = Nothing
        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidarParametros() = False Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Select Case mNomRep

                Case EnumReportes.rptStbDepartamento
                    ObjReporte = RepDepartamento()

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
    ' Author		    		:	
    ' Date			    		:	19/01/2007
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
                Case EnumReportes.rptStbDepartamento
                    ObjVisorReporte.Text = "Reporte de Departamento/Municipio"
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
    ' Date			    		:	19/01/2007
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
    ' Date			    		:	19/01/2007
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

    Private Sub frmStbParamentroDepto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing

            XdtEstadosMunicipio.Close()
            XdtEstadosMunicipio = Nothing

            XdtEstadosDepto.Close()
            XdtEstadosDepto = Nothing

            XdtPerteneceDepto.Close()
            XdtPerteneceDepto = Nothing

            XdtPerteneceMunicipio.Close()
            XdtPerteneceMunicipio = Nothing

            XdtDepartamento.Close()
            XdtDepartamento = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSteParamentroDepto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            If mNomRep = EnumReportes.rptStbDepartamento Then
                CargarEstadosMunicipio()
                CargarEstadosDepto()
                CargarPerteneceDepto()
                CargarPerteneceMunic()
                CargarDepartamento()
            End If

            Me.cboDepartamento.SelectedIndex = -1
            Me.cboEstadoMunic.SelectedIndex = -1
            Me.cboIncluidoProgramaMunic.SelectedIndex = -1

            Me.cboIncluidoPrograma.Select()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	18/01/2007
    ' Procedure name		   	:	RepDepartamento
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   Cuenta Bancaria
    ' -----------------------------------------------------------------------------------------
    Private Function RepDepartamento() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjReporteDepto As New rptStbDepartamento
        Dim ObjReporteMunicipio As New rptStbMunicipio

        Try
            'Si requiere Municipios 
            If Me.chkMunicipio.Checked = True Then
                ObjReporteMunicipio.IdDepartamento = XdtDepartamento("nStbDepartamentoID")
                ObjReporteMunicipio.Departamento = UCase(Me.cboDepartamento.Text)

                ObjReporteMunicipio.IdEstadoDepto = XdtEstadosDepto("IdEstado")
                ObjReporteMunicipio.EstadoDepto = UCase(Me.cboEstado.Text)

                ObjReporteMunicipio.IdEstadoMunic = XdtEstadosMunicipio("IdEstado")
                ObjReporteMunicipio.EstadoMunic = UCase(Me.cboEstadoMunic.Text)

                ObjReporteMunicipio.IdPerteneceDepto = XdtPerteneceDepto("IdPertenece")
                ObjReporteMunicipio.PerteneceDepto = UCase(Me.cboIncluidoPrograma.Text)

                ObjReporteMunicipio.IdPerteneceMunic = XdtPerteneceMunicipio("IdPertenece")
                ObjReporteMunicipio.PerteneceMunic = UCase(Me.cboIncluidoProgramaMunic.Text)

            Else
                ObjReporteDepto.IdEstado = XdtEstadosDepto("IdEstado")
                ObjReporteDepto.Estado = UCase(Me.cboEstado.Text)

                ObjReporteDepto.IdPertenece = XdtPerteneceDepto("IdPertenece")
                ObjReporteDepto.Pertenece = UCase(Me.cboIncluidoPrograma.Text)

            End If

            'Si el reporte requiere Municipios
            If Me.chkMunicipio.Checked = True Then
                Return ObjReporteMunicipio
            Else
                Return ObjReporteDepto
            End If

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    Private Sub chkMunicipio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMunicipio.CheckedChanged
        Try
            If Me.chkMunicipio.Checked = True Then
                Me.cboEstadoMunic.Enabled = True
                Me.cboEstadoMunic.SelectedIndex = 0

                Me.cboIncluidoProgramaMunic.Enabled = True
                Me.cboIncluidoProgramaMunic.SelectedIndex = 0

                Me.cboDepartamento.Enabled = True
                Me.cboDepartamento.SelectedIndex = 0
            Else
                Me.cboEstadoMunic.SelectedIndex = -1
                Me.cboEstadoMunic.Enabled = False

                Me.cboIncluidoProgramaMunic.SelectedIndex = -1
                Me.cboIncluidoProgramaMunic.Enabled = False

                Me.cboDepartamento.Enabled = False
                Me.cboDepartamento.SelectedIndex = -1
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class