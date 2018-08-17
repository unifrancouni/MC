'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                18/08/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccParametroEC.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Estado de Cuenta Resumen por Grupo
'----------------------------------------------------------------------------
Public Class frmSccParametroEC

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3

    Dim intFormatoID As Integer
    Dim intTipoID As Integer

    Dim StrCodigo As String
    Dim StrEstado As String
    Dim StrCodEstado As String
    Dim StrNombre As String
    Dim sColor As String

    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes
    Public Enum EnumReportes
        rptSclEstadoCuentaResumen = 1
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    Public Property intSclFormatoID() As Integer
        Get
            intSclFormatoID = intFormatoID
        End Get
        Set(ByVal value As Integer)
            intFormatoID = value
        End Set
    End Property

    Public Property intSccTipoID() As Integer
        Get
            intSccTipoID = intTipoID
        End Get
        Set(ByVal value As Integer)
            intTipoID = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/08/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Permite Inicializar variables y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            'Cargar datos:
            CargarDatos()
            Me.txtObservaciones.Select()

            'Si impresión es un Formato desde una Interfaz:
            Me.txtCodigo.Text = StrCodigo
            Me.txtEstado.Text = StrEstado
            sColor = "Verde"

            'Titúlo de Reporte:
            Select Case mNomRep
                Case EnumReportes.rptSclEstadoCuentaResumen
                    Me.Text = "Estado de Cuenta Resumen"
                    lblCodigo.Text = "Código de Ficha:"
                    lblEstado.Text = "Estado del Crédito:"
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/08/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Permite Inicializar variables y controles.
    '-------------------------------------------------------------------------
    Private Sub CargarDatos()
        Dim xdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            xdtDatos = New BOSistema.Win.XDataSet.xDataTable

            StrSql = "SELECT  c.nCodigo AS Codigo, a.sCodigo + ' - ' + a.sDescripcion AS Nombre, b.sDescripcion AS Estado, b.sCodigoInterno AS CodEstado, c.sNumSesion, c.dFechaNotificacion, c.sObservacionEstadoCuenta " & _
                     "FROM  SclGrupoSolidario AS a INNER JOIN SclFichaNotificacionCredito AS c ON a.nSclGrupoSolidarioID = c.nSclGrupoSolidarioID INNER JOIN StbValorCatalogo AS b ON c.nStbEstadoCreditoID = b.nStbValorCatalogoID " & _
                     "WHERE (c.nSclFichaNotificacionID = " & intSclFormatoID & ")"
            xdtDatos.ExecuteSql(StrSql)
            If xdtDatos.Count > 0 Then
                StrCodigo = xdtDatos.ValueField("Codigo")
                StrNombre = xdtDatos.ValueField("Nombre")
                StrEstado = xdtDatos.ValueField("Estado")
                StrCodEstado = xdtDatos.ValueField("CodEstado")
                If xdtDatos.ValueField("sObservacionEstadoCuenta").ToString.Length = 0 Then
                    Me.txtObservaciones.Text = ""
                Else
                    Me.txtObservaciones.Text = xdtDatos.ValueField("sObservacionEstadoCuenta")
                End If

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            xdtDatos.Close()
            xdtDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/08/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim XdtGrabarO As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Dim StrFirma As String, StrCargo As String, StrCodigoE As String, StrNombre As String

        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim Strsql As String
            Me.Cursor = Cursors.WaitCursor
            Select Case mNomRep
                Case EnumReportes.rptSclEstadoCuentaResumen
                    'Datos de Empleado que Imprime el Reporte:
                    Strsql = "SELECT vwStbEmpleado.sNombre " & _
                             "FROM SsgCuenta INNER JOIN SrhEmpleado ON SsgCuenta.objEmpleadoID = SrhEmpleado.nSrhEmpleadoID INNER JOIN vwStbEmpleado ON SrhEmpleado.nSrhEmpleadoID = vwStbEmpleado.nSrhEmpleadoID " & _
                             "WHERE (SsgCuenta.SsgCuentaID = " & InfoSistema.IDCuenta & ")"
                    StrNombre = XcDatos.ExecuteScalar(Strsql)

                    If RegistrosAsociados(Strsql) Then
                        StrFirma = XcDatos.ExecuteScalar(Strsql)
                        Strsql = "SELECT vwStbEmpleado.sNombreCargo " & _
                                 "FROM SsgCuenta INNER JOIN SrhEmpleado ON SsgCuenta.objEmpleadoID = SrhEmpleado.nSrhEmpleadoID INNER JOIN vwStbEmpleado ON SrhEmpleado.nSrhEmpleadoID = vwStbEmpleado.nSrhEmpleadoID " & _
                                 "WHERE (SsgCuenta.SsgCuentaID = " & InfoSistema.IDCuenta & ")"
                        StrCargo = XcDatos.ExecuteScalar(Strsql)
                        Strsql = "SELECT vwStbEmpleado.sCodigo " & _
                                 "FROM SsgCuenta INNER JOIN SrhEmpleado ON SsgCuenta.objEmpleadoID = SrhEmpleado.nSrhEmpleadoID INNER JOIN vwStbEmpleado ON SrhEmpleado.nSrhEmpleadoID = vwStbEmpleado.nSrhEmpleadoID " & _
                                 "WHERE (SsgCuenta.SsgCuentaID = " & InfoSistema.IDCuenta & ")"
                        StrCodigoE = XcDatos.ExecuteScalar(Strsql)
                    Else
                        StrFirma = "Impreso Por"
                        StrCargo = ""
                        StrCodigoE = "0000"
                    End If

                    Dim query As String = "select sValorParametro from StbValorParametro where nstbparametroID=38"
                    XdtGrabarO.ExecuteSql(query)
                    Dim ruta_imagenes As String = IIf(XdtGrabarO.ValueField(0) <> Nothing, XdtGrabarO.ValueField(0).ToString, "")

                    frmVisor.Parametros("@nSclFichaNotificacionID") = Me.intFormatoID
                    frmVisor.Formulas("FirmaUsuarioImpresion") = "'" & StrFirma & "'"
                    frmVisor.Formulas("CargoUsuarioImpresion") = "'" & StrCargo & "'"
                    frmVisor.Formulas("codigo_empleado") = "'" & StrCodigoE & "'"
                    frmVisor.Formulas("NombreUsuarioImpresion") = "'" & StrNombre & "'"
                    frmVisor.Formulas("path_images") = "'" & ruta_imagenes & "'"
                    frmVisor.Formulas("Observacion") = "'" & Trim(RTrim(Me.txtObservaciones.Text)) & "'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.NombreReporte = "RepSccCC38.rpt"

                    'Si se indicaron observaciones:
                    If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                        Strsql = " Update SclFichaNotificacionCredito " & _
                                 " SET sObservacionEstadoCuenta = '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate()" & _
                                 " WHERE nSclFichaNotificacionID = " & intSclFormatoID
                        XdtGrabarO.ExecuteSqlNotTable(Strsql)
                    Else
                        Strsql = " Update SclFichaNotificacionCredito " & _
                                 " SET sObservacionEstadoCuenta = Null, sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate()" & _
                                 " WHERE nSclFichaNotificacionID = " & intSclFormatoID
                        XdtGrabarO.ExecuteSqlNotTable(Strsql)
                    End If


                    ''ObjReporte = CargarRepEstadoCuentaResumenG()

            End Select

            'If ObjReporte Is Nothing Then
            '    MsgBox("No hay datos para mostrar el reporte.", MsgBoxStyle.Critical, NombreSistema)
            '    Exit Sub
            'End If
            'Si el destino del reporte es Pantalla
            If Me.radPantalla.Checked Then
                frmVisor.Show()
                'ImprimirEnPantalla(ObjReporte)
                'Si el destino del reporte es Impresora
            ElseIf Me.RadImpresora.Checked Then
                frmVisor.Show()
                frmVisor.CRVReportes.PrintReport()
                ''ImprimirEnImpresora(ObjReporte)
                'Si el destino del reporte es Archivo
            ElseIf Me.RadArchivo.Checked Then
                frmVisor.Show()
                frmVisor.CRVReportes.ExportReport()
                'ImprimirEnArchivo(ObjReporte)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Reestablezco el cursor
            Me.Cursor = Cursors.Default

            XdtGrabarO.Close()
            XdtGrabarO = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/08/2008
    ' Procedure name		   	:	ImprimirEnPantalla
    ' Description			   	:	Permite imprimir en pantalla un reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnPantalla(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        'Declaración de Variables
        Dim ObjVisorReporte As frmVisorReporte

        Try

            ObjVisorReporte = New frmVisorReporte

            'Seteo el text del reporte
            Select Case mNomRep
                Case EnumReportes.rptSclEstadoCuentaResumen
                    ObjVisorReporte.Text = "Estado de Cuenta Resumen por Grupo"
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
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/08/2008
    ' Procedure name		   	:	ImprimirEnImpresora
    ' Description			   	:	Permite imprimir en la impresora un reporte.
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
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/08/2008
    ' Procedure name		   	:	ImprimirEnArchivo
    ' Description			   	:	Permite imprimir en archivo un reporte.
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

    '--------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/08/2008
    ' Procedure Name:       frmSccParametroEC_FormClosin
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '--------------------------------------------------------------------------
    Private Sub frmSccParametroEC_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/08/2008
    ' Procedure Name:       frmSccParametroEC_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables.
    '-------------------------------------------------------------------------
    Private Sub frmSccParametroEC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            InicializarVariables()
            ObjGUI.SetFormLayout(Me, sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            Me.RadImpresora.Enabled = False
            Me.RadArchivo.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	18/08/2008
    ' Procedure name		   	:	CargarRepEstadoCuentaResumenG
    ' Description			   	:	Esta Función permite generar el reporte Estado
    '                               de Cuenta Resumen por Grupo Solidario.
    ' -----------------------------------------------------------------------------------------
    Private Function CargarRepEstadoCuentaResumenG() As DataDynamics.ActiveReports.ActiveReport3
        Dim ObjRptSccEstadoCuentaResumen As rptSccEstadoCuentaResumen
        Try

            ObjRptSccEstadoCuentaResumen = New rptSccEstadoCuentaResumen
            ObjRptSccEstadoCuentaResumen.IdFicha = Me.intFormatoID
            ObjRptSccEstadoCuentaResumen.CodigoFicha = Me.StrCodigo
            ObjRptSccEstadoCuentaResumen.NombreGrupo = Me.StrNombre
            ObjRptSccEstadoCuentaResumen.Estado = Me.StrCodEstado
            Return ObjRptSccEstadoCuentaResumen

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub
End Class