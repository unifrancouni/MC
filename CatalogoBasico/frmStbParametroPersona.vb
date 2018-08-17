Public Class frmStbParametroPersona
    '-- Declaracion de Variables 
    Dim DesdeForm As String  'E = Empleado, J = Juridica, N = Natural, R = Reporte
    Dim IdStbPersona As Long
    'Dim TPersona As String ' E = Empleado, J = Juridica, N = Natural

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdtEstado As BOSistema.Win.XDataSet.xDataTable
    Dim XdtTipoPersona As BOSistema.Win.XDataSet.xDataTable
    Dim XdtOrdenadoPor As BOSistema.Win.XDataSet.xDataTable
    Dim strSQL As String

    'Propiedad utilizada para el identificar si el formulario es llamado
    'desde la pantalla de Persona Natural, Persona Juridica, Empleado o bien
    'desde la lista de consultas y reportes.
    Public Property LlamadoDesde() As String
        Get
            LlamadoDesde = DesdeForm
        End Get
        Set(ByVal value As String)
            DesdeForm = value
        End Set
    End Property

    Private Sub InicializarVariables()
        Try

            'Inicializar las clases 
            XdtEstado = New BOSistema.Win.XDataSet.xDataTable
            XdtTipoPersona = New BOSistema.Win.XDataSet.xDataTable
            XdtOrdenadoPor = New BOSistema.Win.XDataSet.xDataTable

            'Tit�lo de Reporte
            Select Case Me.LlamadoDesde
                Case "E"
                    Me.Text = "Par�metros Reporte de Empleado"
                Case "J"
                    Me.Text = "Par�metros Reporte de Persona Juridica"
                Case "N"
                    Me.Text = "Par�metros Reporte de Persona Natural"
                Case "R"
                    Me.Text = "Par�metros Reporte de Personas"
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False

            'Tipo de Persona
            If Me.cboTipoPersona.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Persona v�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboTipoPersona, "Debe seleccionar un Tipo de Persona v�lido.")
                Me.cboTipoPersona.Focus()
                GoTo SALIR
            End If

            'Estado
            If Me.cboEstado.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Estado v�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboEstado, "Debe seleccionar un Estado v�lido.")
                Me.cboEstado.Focus()
                GoTo SALIR
            End If

            'Orden
            If Me.cboOrdenadoPor.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Ordenaci�n v�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboOrdenadoPor, "Debe seleccionar un Tipo de Ordenaci�n v�lido.")
                Me.cboOrdenadoPor.Focus()
                GoTo SALIR
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	03 Octubre 2007
    ' Procedure name		   	:	ImprimirEnPantalla
    ' Description			   	:	Este procedimiento permite imprimir en pantalla un reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnPantalla(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        'Declaraci�n de Variables
        Dim ObjVisorReporte As frmVisorReporte

        Try

            ObjVisorReporte = New frmVisorReporte

            'Seteo el text del reporte
            Select Case Me.LlamadoDesde
                Case "N"
                    ObjVisorReporte.Text = "Reporte de Persona Natural"
                Case "J"
                    ObjVisorReporte.Text = "Reporte de Persona Jur�dica"
                Case "E"
                    ObjVisorReporte.Text = "Reporte de Empleado"

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
    ' Date			    		:	03 Octubre 2007
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
    ' Date			    		:	03 Octubre 2007
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
                    MsgBox("El reporte se export� en formato PDF con �xito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 2 'excel
                    Dim ObjExportXLS As DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS = New DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se export� en formato Excel con �xito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 4 'rtf
                    Dim ObjExportRTF As DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF = New DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se export� en formato RTF con �xito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 5 'HTML
                    Dim ObjExportHTML As DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML = New DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se export� en formato HTML con �xito !!!", MsgBoxStyle.Information, NombreSistema)
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroPersona_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing

            XdtEstado.Close()
            XdtEstado = Nothing

            XdtTipoPersona.Close()
            XdtTipoPersona = Nothing

            XdtOrdenadoPor.Close()
            XdtOrdenadoPor = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroPersona_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaraci�n de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'If mNomRep = EnumReportes.rptStbBarrio Then
            CargarOrden()
            CargarTipoPersona()
            CargarEstados()
            'End If

            If Me.LlamadoDesde <> "R" Then
                Me.cboTipoPersona.SelectedIndex = 0
                Me.cboTipoPersona.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	15 de Diciembre de 2006
    ' Procedure name		   	:	LlenarOrdenar
    ' Description			   	:	Cargar los parametros de  ordenar por c�digo y nombre.
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarOrden()

        'Declaracion de Variables

        Dim Strsql As String

        Try
            Strsql = "Select 1          as IdOrden," & _
                     "      'C�digo'     as Ordenar,  " & _
                     "       1          as Orden  "

            XdtOrdenadoPor.ExecuteSql(Strsql)

            If Me.LlamadoDesde = "J" Then
                XdtOrdenadoPor.AddRow()
                XdtOrdenadoPor("IdOrden") = 1
                XdtOrdenadoPor("Ordenar") = "N�mero RUC"
                XdtOrdenadoPor("Orden") = 1
                XdtOrdenadoPor.UpdateLocal()
                '--------------------------------
                XdtOrdenadoPor.AddRow()
                XdtOrdenadoPor("IdOrden") = 2
                XdtOrdenadoPor("Ordenar") = "Raz�n Social"
                XdtOrdenadoPor("Orden") = 2
                XdtOrdenadoPor.UpdateLocal()
            ElseIf Me.LlamadoDesde = "N" Then
                XdtOrdenadoPor.AddRow()
                XdtOrdenadoPor("IdOrden") = 1
                XdtOrdenadoPor("Ordenar") = "N�mero de C�dula"
                XdtOrdenadoPor("Orden") = 1
                XdtOrdenadoPor.UpdateLocal()
                '--------------------------------
                XdtOrdenadoPor.AddRow()
                XdtOrdenadoPor("IdOrden") = 2
                XdtOrdenadoPor("Ordenar") = "Nombre y Apellidos"
                XdtOrdenadoPor("Orden") = 2
                XdtOrdenadoPor.UpdateLocal()
            ElseIf Me.LlamadoDesde = "E" Then
                XdtOrdenadoPor.AddRow()
                XdtOrdenadoPor("IdOrden") = 1
                XdtOrdenadoPor("Ordenar") = "N�mero de C�dula"
                XdtOrdenadoPor("Orden") = 1
                XdtOrdenadoPor.UpdateLocal()
                '--------------------------------
                XdtOrdenadoPor.AddRow()
                XdtOrdenadoPor("IdOrden") = 2
                XdtOrdenadoPor("Ordenar") = "Nombre y Apellidos"
                XdtOrdenadoPor("Orden") = 2
                XdtOrdenadoPor.UpdateLocal()
            End If

            'Asignando la fuente de datos
            Me.cboOrdenadoPor.DataSource = XdtOrdenadoPor.Source

            'Formateando el Combo
            Me.cboOrdenadoPor.Splits(0).DisplayColumns("IdOrden").Visible = False
            Me.cboOrdenadoPor.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboOrdenadoPor.Columns("Ordenar").Caption = ""

            'Ubicarse en el primer registro
            If XdtOrdenadoPor.Count > 0 Then
                Me.cboOrdenadoPor.SelectedIndex = 0
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarTipoPersona
    ' Descripci�n:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selecci�n.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPersona()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""

            If Me.LlamadoDesde <> "R" Then
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPersona') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1  and a.sCodigoInterno = '" & Me.LlamadoDesde & "'" & _
                         " Order by a.sCodigoInterno "
            Else
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " From StbValorCatalogo a INNER JOIN " & _
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPersona') b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "
            End If

            XdtTipoPersona.ExecuteSql(Strsql)
            XdtTipoPersona.Retrieve()

            'Asignando a las fuentes de datos
            Me.cboTipoPersona.DataSource = XdtTipoPersona.Source

            Me.cboTipoPersona.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPersona.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPersona.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPersona.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoPersona.Columns("sCodigoInterno").Caption = "C�digo"
            Me.cboTipoPersona.Columns("sDescripcion").Caption = "Descripci�n"

            Me.cboTipoPersona.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPersona.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	15 de Diciembre de 2006
    ' Procedure name		   	:	CargarEstados
    ' Description			   	:	Cargar los Tipo de estados 
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarEstados()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdEstado, " & _
                     "      'Todos'     As Estado, " & _
                     "        0         As Orden "

            XdtEstado.ExecuteSql(Strsql)
            XdtEstado.AddRow()
            XdtEstado("IdEstado") = 1
            XdtEstado("Estado") = "Activo"
            XdtEstado("Orden") = 1
            XdtEstado.UpdateLocal()
            '--------------------------------

            XdtEstado.AddRow()
            XdtEstado("IdEstado") = 0
            XdtEstado("Estado") = "Inactivo"
            XdtEstado("Orden") = 2
            XdtEstado.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboEstado.DataSource = XdtEstado.Source

            'Formateando el Combo
            Me.cboEstado.Splits(0).DisplayColumns("IdEstado").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboEstado.Columns("Estado").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtEstado.Count > 0 Then
                cboEstado.SelectedIndex = 0
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidarParametros() = False Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.LlamadoDesde

                Case "N"
                    ObjReporte = RepPersonaNatural()
                Case "J"
                    ObjReporte = RepPersonaJuridica()
                Case "E"
                    ObjReporte = RepEmpleado()

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
    ' Author		    		:	Azucena Su�rez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	RepPersonaNatural
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Listado de Personas Naturales
    ' -----------------------------------------------------------------------------------------
    Private Function RepPersonaNatural() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptStbPersonaNatural As rptStbPersonaNatural

        Try
            ObjRptStbPersonaNatural = New rptStbPersonaNatural

            'Estado de Persona Natural
            ObjRptStbPersonaNatural.IdEstado = XdtEstado("IdEstado")
            ObjRptStbPersonaNatural.Estado = UCase(Me.cboEstado.Text)

            'Tipo de Persona
            ObjRptStbPersonaNatural.IdTipoPersona = XdtTipoPersona("nStbValorCatalogoID")
            ObjRptStbPersonaNatural.TipoPersona = UCase(Me.cboTipoPersona.Text)

            'Ordenaci�n
            ObjRptStbPersonaNatural.IdOrden = XdtOrdenadoPor("IdOrden")
            ObjRptStbPersonaNatural.Orden = UCase(Me.cboOrdenadoPor.Text)

            Return ObjRptStbPersonaNatural

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Su�rez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	RepPersonaNatural
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Listado de Personas Naturales
    ' -----------------------------------------------------------------------------------------
    Private Function RepPersonaJuridica() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptStbPersonaJuridica As rptStbPersonaJuridica

        Try
            ObjRptStbPersonaJuridica = New rptStbPersonaJuridica

            'Estado de Persona Juridica
            ObjRptStbPersonaJuridica.IdEstado = XdtEstado("IdEstado")
            ObjRptStbPersonaJuridica.Estado = UCase(Me.cboEstado.Text)

            'Tipo de Persona
            ObjRptStbPersonaJuridica.IdTipoPersona = XdtTipoPersona("nStbValorCatalogoID")
            ObjRptStbPersonaJuridica.TipoPersona = UCase(Me.cboTipoPersona.Text)

            'Ordenaci�n
            ObjRptStbPersonaJuridica.IdOrdenamiento = XdtOrdenadoPor("IdOrden")
            ObjRptStbPersonaJuridica.Ordenamiento = UCase(Me.cboOrdenadoPor.Text)

            Return ObjRptStbPersonaJuridica

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Su�rez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	RepPersonaNatural
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Listado de Personas Naturales
    ' -----------------------------------------------------------------------------------------
    Private Function RepEmpleado() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptStbPersonaNatural As rptStbPersonaNatural

        Try
            ObjRptStbPersonaNatural = New rptStbPersonaNatural

            'Estado de Persona Natural
            ObjRptStbPersonaNatural.IdEstado = XdtEstado("IdEstado")
            ObjRptStbPersonaNatural.Estado = UCase(Me.cboEstado.Text)

            'Tipo de Persona
            ObjRptStbPersonaNatural.IdTipoPersona = XdtTipoPersona("nStbValorCatalogoID")
            ObjRptStbPersonaNatural.TipoPersona = (Me.cboTipoPersona.Text)

            'Ordenaci�n
            ObjRptStbPersonaNatural.IdOrden = XdtOrdenadoPor("IdOrden")
            ObjRptStbPersonaNatural.Orden = UCase(Me.cboOrdenadoPor.Text)

            Return ObjRptStbPersonaNatural

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function
End Class