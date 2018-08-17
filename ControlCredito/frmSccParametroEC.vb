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
    Dim intSociaID As Integer
    Dim intTipoID As Integer

    Dim StrCodigo As String
    Dim StrEstado As String
    Dim StrCodEstado As String
    Dim StrNombre As String
    Dim sColor As String

    Dim XdsEstado As BOSistema.Win.XDataSet

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

    Public Property intSclSociaID() As Integer
        Get
            Return intSociaID
        End Get
        Set(value As Integer)
            Me.intSociaID = value
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
            XdsEstado = New BOSistema.Win.XDataSet

            'Cargar datos:
            CargarDatos()
            CargarEstadoSocia()
            CargarEmpleados()

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

    Private Sub CargarEmpleados()
        Try
            Dim Strsql As String

            Me.cboOficial.ClearFields()

            Strsql = "Exec spSrhEmpleadoDelegacionRRHH " & InfoSistema.IDDelegacion

            If XdsEstado.ExistTable("Oficiales") Then
                XdsEstado("Oficiales").ExecuteSql(Strsql)
            Else
                XdsEstado.NewTable(Strsql, "Oficiales")
                XdsEstado("Oficiales").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboOficial.DataSource = XdsEstado("Oficiales").Source
            Me.cboOficial.Rebind()
            Me.cboOficial.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboOficial.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            'Configurar el combo: 
            Me.cboOficial.Splits(0).DisplayColumns("cNombresApellidos").Width = 210
            Me.cboOficial.Columns("cNombresApellidos").Caption = "Oficial"
            Me.cboOficial.Splits(0).DisplayColumns("cNombresApellidos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cboOficial.DisplayMember = "Oficial"
            Me.cboOficial.ValueMember = "nSrhEmpleadoID"

            'Si la socia tiene empleado visitante almacenado, mostrarlo
            Strsql = "SELECT ISNULL(nSrhEmpleadoVisitaID, -1)
                      FROM dbo.SclEstadoSocia INNER JOIN
                      dbo.StbValorCatalogo ON dbo.SclEstadoSocia.nStbEstadoSociaID = dbo.StbValorCatalogo.nStbValorCatalogoID
                      WHERE dbo.SclEstadoSocia.nSclSociaID=" & Me.intSclSociaID

            Dim cmd As New BOSistema.Win.XComando
            Dim emp As Integer
            emp = cmd.ExecuteScalar(Strsql)
            If emp <> -1 Then
                cboOficial.SelectedValue = emp
            Else
                cboOficial.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarEstadoSocia()
        Try
            Dim Strsql As String

            Me.txtOtroMotivo.Enabled = False
            Me.cdeFechaEstado.Value = Date.Now
            Me.cboEstado.ClearFields()

            Strsql = "Select * from vwSclEstadoSocia where nActivo=1"

            If XdsEstado.ExistTable("Estado") Then
                XdsEstado("Estado").ExecuteSql(Strsql)
            Else
                XdsEstado.NewTable(Strsql, "Estado")
                XdsEstado("Estado").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboEstado.DataSource = XdsEstado("Estado").Source
            Me.cboEstado.Rebind()

            Me.cboEstado.Splits(0).DisplayColumns("nStbCatalogoID").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("sCodigoInterno").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("nActivo").Visible = False

            'Configurar el combo: 
            Me.cboEstado.Splits(0).DisplayColumns("sDescripcion").Width = 210
            Me.cboEstado.Columns("sDescripcion").Caption = "Estado"
            Me.cboEstado.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cboEstado.DisplayMember = "Estado"
            Me.cboEstado.ValueMember = "sCodigoInterno"

            'Si la socia tiene estado almacenado mostrarlo
            Strsql = "SELECT ISNULL(CAST(dbo.StbValorCatalogo.sCodigoInterno as int), -1)
                      FROM dbo.SclEstadoSocia INNER JOIN
                      dbo.StbValorCatalogo ON dbo.SclEstadoSocia.nStbEstadoSociaID = dbo.StbValorCatalogo.nStbValorCatalogoID
                      WHERE dbo.SclEstadoSocia.nSclSociaID=" & Me.intSclSociaID
            Dim cmd As New BOSistema.Win.XComando
            Dim est, nmotivo As Integer
            Dim explique, observaciones As String
            est = cmd.ExecuteScalar(Strsql)
            If est <> -1 Then
                cboEstado.SelectedValue = est
            Else
                cboEstado.SelectedValue = 0
            End If


            Strsql = "SELECT ISNULL(dbo.SclEstadoSocia.nMotivoEstado,-1)
                        FROM dbo.SclEstadoSocia RIGHT OUTER JOIN
                        dbo.SclSocia ON dbo.SclEstadoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID
                        WHERE (dbo.SclSocia.nSclSociaID = " & Me.intSclSociaID & ")"
            nmotivo = cmd.ExecuteScalar(Strsql)
            Select Case nmotivo
                Case 1
                    rdFormatoVisita.Checked = True
                Case 2
                    rdCarta.Checked = True
                Case 3
                    rdActaDefuncion.Checked = True
                Case 4
                    rdOtro.Checked = True
            End Select


            Strsql = "SELECT ISNULL(dbo.SclEstadoSocia.sExplique, '')
                        FROM dbo.SclEstadoSocia RIGHT OUTER JOIN
                        dbo.SclSocia ON dbo.SclEstadoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID
                        WHERE (dbo.SclSocia.nSclSociaID = " & Me.intSclSociaID & ")"
            explique = cmd.ExecuteScalar(Strsql)
            txtOtroMotivo.Text = explique


            Strsql = "SELECT ISNULL(dbo.SclEstadoSocia.sObservaciones, '')
                        FROM dbo.SclEstadoSocia RIGHT OUTER JOIN
                        dbo.SclSocia ON dbo.SclEstadoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID
                        WHERE (dbo.SclSocia.nSclSociaID = " & Me.intSclSociaID & ")"
            observaciones = cmd.ExecuteScalar(Strsql)
            txtObservacionesEstado.Text = observaciones


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

        Dim xdtgrabaro As New BOSistema.Win.XDataSet.xDataTable
        Dim xcdatos As New BOSistema.Win.XComando
        'Dim strfirma As String, strcargo As String, strcodigoe As String, strnombre As String

        Dim frmvisor As New frmCRVisorReporte
        Try
            Dim strsql As String
            Me.Cursor = Cursors.WaitCursor
            Select Case mNomRep
                Case EnumReportes.rptSclEstadoCuentaResumen

                    'si se indicaron observaciones:
                    If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                        strsql = " update sclfichanotificacioncredito " & _
                                 " set sobservacionestadocuenta = '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', susuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate()" & _
                                 " where nsclfichanotificacionid = " & intSclFormatoID
                        xdtgrabaro.ExecuteSqlNotTable(strsql)
                    Else
                        strsql = " update sclfichanotificacioncredito " & _
                                 " set sobservacionestadocuenta = null, susuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate()" & _
                                 " where nsclfichanotificacionid = " & intSclFormatoID
                        xdtgrabaro.ExecuteSqlNotTable(strsql)
                    End If

                    ObjReporte = CargarRepEstadoCuentaResumenG()


            End Select

            'if objreporte is nothing then
            '    msgbox("no hay datos para mostrar el reporte.", msgboxstyle.critical, nombresistema)
            '    exit sub
            'end if
            'si el destino del reporte es pantalla
            If Me.radPantalla.Checked Then
                'frmvisor.Show()
                ImprimirEnPantalla(ObjReporte)
                'si el destino del reporte es impresora
            ElseIf Me.RadImpresora.Checked Then
                'frmvisor.Show()
                'frmvisor.CRVReportes.PrintReport()
                ImprimirEnImpresora(ObjReporte)
                'si el destino del reporte es archivo
            ElseIf Me.RadArchivo.Checked Then
                'frmvisor.Show()
                'frmvisor.CRVReportes.ExportReport()
                ImprimirEnArchivo(ObjReporte)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'reestablezco el cursor
            Me.Cursor = Cursors.Default

            xdtgrabaro.Close()
            xdtgrabaro = Nothing
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

            Seguridad()

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            ''Me.RadImpresora.Enabled = False
            ''Me.RadArchivo.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Seguridad()
        If Not Seg.HasPermission("EstadoSocia") Then
            grpEstadoSocia.Enabled = False
        End If
        If Seg.HasPermission("ModificarObservacionesCC38") Then
            txtObservaciones.ReadOnly = False
        End If
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


    Private Function ValidarDatos() As Boolean
        'Validar que seleccione un estado
        If cboEstado.SelectedIndex = -1 Then
            MsgBox("Debe seleccionar un estado.", vbCritical)
            Return False
        End If

        'Validar que seleccione un RadioButton
        If Not (rdFormatoVisita.Checked Or rdCarta.Checked Or rdActaDefuncion.Checked Or rdOtro.Checked) Then
            MsgBox("Debe seleccionar un motivo de cambio de estado.", vbCritical)
            Return False
        End If

        'Validar que si es 'otro' llene Explique
        If rdOtro.Checked And Trim(txtOtroMotivo.Text) = "" Then
            MsgBox("Debe llenar el campo: Explique", vbCritical)
            Return False
        End If

        'Validar que ingrese fecha y su concordancia
        If Not IsDate(cdeFechaEstado.Value) Then
            MsgBox("Debe ingresar fecha de estado.", vbCritical)
            Return False
        Else
            If cdeFechaEstado.Value > Date.Now Then
                MsgBox("La fecha de estado no debe ser mayor a la actual.", vbCritical)
                Return False
            End If
        End If

            'Llenar campo Observaciones siempre, justificando soporte
            If Trim(txtObservacionesEstado.Text) = "" Then
            MsgBox("Debe llenar observaciones con un indicio de la ubicación del archivo de soporte.", vbCritical)
            Return False
        End If

        Return True

    End Function

    Private Sub btnActualizaEstado_Click(sender As Object, e As EventArgs) Handles btnActualizaEstado.Click
        'Parametros:
        'Me.intSclSociaID, Me.cboEstado.SelectedValue, InfoSistema.LoginName

        Dim cmd As New BOSistema.Win.XComando
        Dim res As Integer

        Try
            If Not ValidarDatos() Then
                Exit Sub
            End If

            Dim strSQL As String
            strSQL = "exec spSclGrabarEstadoSocia " & Me.intSclSociaID & ", '" & Me.cboEstado.SelectedValue & "', " & IIf(Me.rdFormatoVisita.Checked, 1, IIf(Me.rdCarta.Checked, 2, IIf(Me.rdActaDefuncion.Checked, 3, IIf(Me.rdOtro.Checked, 4, 5)))) & ", '" & Me.txtOtroMotivo.Text & "', '" & Me.txtObservacionesEstado.Text & "', '" & Format(cdeFechaEstado.Value, "yyyy-MM-dd") & "'," & Me.cboOficial.SelectedValue & ", '" & InfoSistema.LoginName & "'"

            res = cmd.ExecuteScalar(strSQL)

            Select Case res
                Case -4
                    MsgBox("No se pudo actualizar estado de socia.", vbCritical)
                    Exit Sub
                Case -3
                    MsgBox("No se pudo ingresar estado de socia.", vbCritical)
                    Exit Sub
                Case -2
                    MsgBox("No se pudo ingresar estado de socia.", vbCritical)
                    Exit Sub
                Case -1
                    MsgBox("No se pudo ingresar estado de socia.", vbCritical)
                    Exit Sub
                Case 0
                    MsgBox("El estado de la socia se ingresó correctamente.", vbInformation)
                    Exit Sub
                Case 1
                    MsgBox("El estado de la socia se actualizó correctamente.", vbInformation)
                    Exit Sub
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rdOtro_CheckedChanged(sender As Object, e As EventArgs) Handles rdOtro.CheckedChanged
        txtOtroMotivo.Enabled = rdOtro.Checked
        If Not rdOtro.Checked Then
            txtOtroMotivo.Text = ""
        End If
    End Sub

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click
        txtObservaciones.AppendText("/ " & txtAñadir.Text)
        txtAñadir.Clear()
    End Sub
End Class