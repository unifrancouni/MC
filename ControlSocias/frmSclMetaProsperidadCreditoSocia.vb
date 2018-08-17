Public Class frmSclMetaProsperidadCreditoSocia


    Dim XdtCreditos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDepto As BOSistema.Win.XDataSet.xDataTable
    Dim StrCadena As String = ""
    Dim vllamaBuscarGrupo As Boolean = False

    Private Sub frmSclMetaProsperidadCreditoSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtCreditos.Close()
            XdtCreditos = Nothing
            XdtDepto.Close()
            XdtDepto = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub frmSclMetaProsperidadCreditoSocia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()

            Me.toolRefrescar.Visible = False

            CargarDepartamento()
            StrCadena = ""

            CargarCreditos(StrCadena)
            FormatoCreditos()
            'Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub InicializaVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            XdtCreditos = New BOSistema.Win.XDataSet.xDataTable
            XdtDepto = New BOSistema.Win.XDataSet.xDataTable

            Me.Text = "Ficha de Verificación"

            Me.grdFicha.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub

    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbDepartamento a " & _
                         " Order by a.sCodigo"

            XdtDepto.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdtDepto.Source
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Public Sub CargarCreditos(ByVal sCadenaFiltro As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.toolRefrescar.Visible = False
            Dim Strsql As String = ""

            Me.grdFicha.ClearFields()

            If sCadenaFiltro = "" Then
                Strsql = "SELECT * FROM vwSclMetaProsperidadCreditoSocia where nSclSociaID=0"
            Else
                Strsql = "SELECT * FROM vwSclMetaProsperidadCreditoSocia " & sCadenaFiltro
            End If

            XdtCreditos.ExecuteSql(Strsql)

            If vllamaBuscarGrupo = True Then
                Dim fichaNotificacionID As Integer
                fichaNotificacionID = XdtCreditos.ValueField("nSclFichaNotificacionID")
                Strsql = "SELECT * FROM vwSclMetaProsperidadCreditoSocia WHERE nSclFichaNotificacionID=" & fichaNotificacionID
                vllamaBuscarGrupo = False
            End If

            XdtCreditos.ExecuteSql(Strsql)

            If XdtCreditos.Count = 0 And sCadenaFiltro <> "" Then 'sCadenaFiltro <> "" para que no mande el mensaje en la primera
                MsgBox("No se encontraron registros.", vbCritical, "Error")
                CargarCreditos("")
            End If

            'Asignando a las fuentes de datos
            Me.grdFicha.DataSource = XdtCreditos.Source
            Me.grdFicha.Rebind(False)

            Me.grdFicha.Caption = " Listado de Creditos por Socia (" + Me.grdFicha.RowCount.ToString + " registros)"

            If grdFicha.RowCount > 0 Then
                Me.toolRefrescar.Visible = True
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar
            If Seg.HasPermission("BuscarFichaVerificacion") Then
                Me.toolBuscar.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
            End If

            'Imprimir 
            If Seg.HasPermission("ImprimirMetaProsperidad") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoCreditos()
        Try
            'Configuracion del Grid Comprobante
            Me.grdFicha.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("Departamento").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("Municipio").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("Distrito").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("Barrio").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbBarrioVerificadoID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("EstadoCredito").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("sCodigoEstadoFicha").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("sNombre1").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("sNombre2").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("sApellido1").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("sApellido2").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False


            Me.grdFicha.Splits(0).DisplayColumns("CodGrupo").Width = 120
            Me.grdFicha.Splits(0).DisplayColumns("Socia").Width = 140
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("sDireccionSocia").Width = 90
            Me.grdFicha.Splits(0).DisplayColumns("sTelefonoSocia").Width = 50
            Me.grdFicha.Splits(0).DisplayColumns("Grupo").Width = 150
            Me.grdFicha.Splits(0).DisplayColumns("MetaProsperidad").Width = 250

            Me.grdFicha.Columns("CodGrupo").Caption = "Código"
            Me.grdFicha.Columns("Socia").Caption = "Nombre Socia"
            Me.grdFicha.Columns("sNumeroCedula").Caption = "No.Cédula"
            Me.grdFicha.Columns("sDireccionSocia").Caption = "Dirección"
            Me.grdFicha.Columns("sTelefonoSocia").Caption = "Teléfono"
            Me.grdFicha.Columns("Grupo").Caption = "Grupo Solidario"
            Me.grdFicha.Columns("nMontoCreditoAprobado").Caption = "Monto Aprobado"
            Me.grdFicha.Columns("MetaProsperidad").Caption = "Meta de Prosperidad"
            Me.grdFicha.Columns("TotalCreditos").Caption = "Total Créditos"
            Me.grdFicha.Columns("nNoPrestamoSocia").Caption = "No. de Préstamo"


            Me.grdFicha.Splits(0).DisplayColumns("CodGrupo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("Socia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sTelefonoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("Grupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("MetaProsperidad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("nMontoCreditoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("TotalCreditos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("nNoPrestamoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub tbFicha_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolRefrescar"
                'InicializaVariables()
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                CargarCreditos(StrCadena)
                FormatoCreditos()

            Case "toolBuscar"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                LlamaBuscarSocia()
            Case "toolBuscarGrupo"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                LlamaBuscarGrupo()
            Case "toolImprimir"
                LlamaImprimir()
            'MsgBox("Notificacion: " & XdtCreditos.ValueField("nSclFichaNotificacionID"))
            Case "toolImprimirModulo"
                LlamaImprimirModulos()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()

        End Select
    End Sub

    Private Sub LlamaImprimirModulos()
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If Me.grdFicha.RowCount = 0 Then
                'MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Parametros("@nSclFichaSociaID") = 0
            Dim fichaID As Integer = XdtCreditos.ValueField("nSclFichaNotificacionID")
            frmVisor.Parametros("@nSclFichaNotificacionID") = fichaID
            frmVisor.NombreReporte = "RepSclCS68.rpt"
            frmVisor.Text = "Módulo Máximo Aprobado - Cursos"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
            frmVisor.Close()
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub LlamaBuscarSocia()
        Dim ObjFrmSclBusquedaSocias As New frmSclBusquedaSocias
        Try

            ObjFrmSclBusquedaSocias.StrCriterioSocia = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaSocias.IdDepartamento = XdtDepto.ValueField("nStbDepartamentoID")
            ObjFrmSclBusquedaSocias.IdConsultarDelegacion = 1
            ObjFrmSclBusquedaSocias.IdTipoBusqueda = 5 'Busqueda Por Nombre o Cédula Socias.
            ObjFrmSclBusquedaSocias.ShowDialog()
            If ObjFrmSclBusquedaSocias.StrCriterioSocia <> "0" Then
                Dim ca = ObjFrmSclBusquedaSocias.ContadorActual
                StrCadena = ObjFrmSclBusquedaSocias.StrCriterioSocia & " and nNoPrestamoSocia=" & ca
                CargarCreditos(StrCadena)
                FormatoCreditos()
            End If
            'LlamaRefrescarRecibo()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaSocias.Close()
            ObjFrmSclBusquedaSocias = Nothing
        End Try
    End Sub

    Private Sub LlamaBuscarGrupo()
        vllamaBuscarGrupo = True
        LlamaBuscarSocia()
    End Sub

    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If Me.grdFicha.RowCount = 0 Then
                'MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("NombreUsuario") = "'" & InfoSistema.UsrName & "'"
            frmVisor.Formulas("Cargo") = "'" & ObtenerCargoEmpleadoActual() & "'"
            frmVisor.Parametros("@nSclFichaNotificacionID") = XdtCreditos.ValueField("nSclFichaNotificacionID")
            frmVisor.NombreReporte = "RepSclCS58.rpt"
            frmVisor.Text = "Resumen por Grupo Solidario - Meta de Prosperidad"
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
            frmVisor.Close()
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ObtenerCargoEmpleadoActual() As String
        Dim StrSql As String
        Dim xdtDatos
        xdtDatos = New BOSistema.Win.XDataSet.xDataTable

        StrSql = "SELECT  Cargo FROM srhCargoEmpleado WHERE Id=" & InfoSistema.IDCuenta
        xdtDatos.ExecuteSql(StrSql)

        Return xdtDatos("Cargo")

    End Function

End Class