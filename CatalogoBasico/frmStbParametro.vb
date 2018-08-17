
Public Class frmStbParametro

    Dim XdsParametro As BOSistema.Win.XDataSet

    Private Sub frmStbParametro_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsParametro.Close()
            XdsParametro = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub frmStbParametro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarParametro()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub CargarParametro()
        Try
            Dim Strsql As String

            Strsql = "SELECT     StbParametro.nStbParametroID, StbParametro.sDescripcionParametro, StbValorParametro.sValorParametro, " & _
                     "CASE StbValorParametro.sTipoDato WHEN 'N' THEN 'Numerico' WHEN 'D' THEN 'Fecha' WHEN 'S' THEN 'Texto' END AS sTipoDato,StbValorParametro.dFechaInicio, StbValorParametro.dFechaFin " & _
                     "FROM         StbParametro INNER JOIN " & _
                     "StbValorParametro ON StbParametro.nStbParametroID = StbValorParametro.nStbParametroID"

            If XdsParametro.ExistTable("Parametro") Then
                XdsParametro("Parametro").ExecuteSql(Strsql)
            Else
                XdsParametro.NewTable(Strsql, "Parametro")
                XdsParametro("Parametro").Retrieve()
            End If

            Me.grdParametro.DataSource = XdsParametro("Parametro").Source
            Me.grdParametro.Caption = " Listado de Parámetros (" + Me.grdParametro.RowCount.ToString + " registros)"
            FormatoParametro()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FormatoParametro()
        Try
            Me.grdParametro.Splits(0).DisplayColumns("nStbParametroID").Visible = False
            Me.grdParametro.Splits(0).DisplayColumns("sDescripcionParametro").Width = 450
            Me.grdParametro.Splits(0).DisplayColumns("sValorParametro").Width = 350
            Me.grdParametro.Splits(0).DisplayColumns("sTipoDato").Width = 90
            Me.grdParametro.Splits(0).DisplayColumns("dFechaInicio").Width = 90
            Me.grdParametro.Splits(0).DisplayColumns("dFechaFin").Width = 80

            Me.grdParametro.Columns("sDescripcionParametro").Caption = "Descripción"
            Me.grdParametro.Columns("sValorParametro").Caption = "Valor del Parámetro"
            Me.grdParametro.Columns("sTipoDato").Caption = "Tipo Dato"
            Me.grdParametro.Columns("dFechaInicio").Caption = "F. Inicio Uso"
            Me.grdParametro.Columns("dFechaFin").Caption = "F. Fin Uso"

            Me.grdParametro.Splits(0).DisplayColumns("sDescripcionParametro").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

            Me.grdParametro.Splits(0).DisplayColumns("sDescripcionParametro").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("sValorParametro").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("sTipoDato").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("dFechaInicio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("dFechaFin").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub InicializaVariables()
        Try
            XdsParametro = New BOSistema.Win.XDataSet
            Me.grdParametro.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub tbParametro_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbParametro.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarParametro()
            Case "toolModificar"
                LlamaModificarParametro()
            Case "toolEliminar"
                LlamaEliminarParametro()
            Case "toolRefrescar"
                InicializaVariables()
                CargarParametro()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaAgregarParametro()
        Dim ObjFrmScnEditParametro As New frmStbEditParametro
        Try
            ObjFrmScnEditParametro.ModoFrm = "ADD"
            ObjFrmScnEditParametro.ShowDialog()

            If ObjFrmScnEditParametro.IdParametro <> 0 Then
                CargarParametro()
                XdsParametro("Parametro").SetCurrentByID("nStbParametroID", ObjFrmScnEditParametro.IdParametro)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditParametro.Close()
            ObjFrmScnEditParametro = Nothing
        End Try
    End Sub
    Private Sub LlamaModificarParametro()
        Dim ObjFrmScnEditParametro As New frmStbEditParametro

        Try
            If IsDBNull(XdsParametro("Parametro").ValueField("dFechaFin")) Then
                If Me.grdParametro.RowCount = 0 Then
                    MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                ObjFrmScnEditParametro.ModoFrm = "UPD"
                ObjFrmScnEditParametro.IdParametro = XdsParametro("Parametro").ValueField("nStbParametroID")
                ObjFrmScnEditParametro.ShowDialog()

                If ObjFrmScnEditParametro.IdParametro <> 0 Then
                    InicializaVariables()
                    CargarParametro()
                    XdsParametro("Parametro").SetCurrentByID("nStbParametroID", ObjFrmScnEditParametro.IdParametro)
                    Me.grdParametro.Row = XdsParametro("Parametro").BindingSource.Position
                End If
            Else
                MsgBox("No Puede Modificarse, Parámetro inactivo.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditParametro.Close()
            ObjFrmScnEditParametro = Nothing
        End Try
    End Sub
    Private Sub LlamaEliminarParametro()
        Dim XdtParametro As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String
        Try

            If Me.grdParametro.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Inactivar el Valor del Parametro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
                If IsDBNull(XdsParametro("Parametro").ValueField("dFechaFin")) Then
                    Strsql = "Update StbValorParametro " & _
                                                   "SET dFechaFin = CONVERT(DATETIME,'" & Format(FechaServer(), "yyyy-MM-dd") & "', 102) " & _
                                                   "WHERE (nStbParametroID =" & XdsParametro("Parametro").ValueField("nStbParametroID") & ")"

                    XdtParametro.ExecuteSqlNotTable(Strsql)
                    MsgBox("El Valor del Parametro se Inactivo satisfactoriamente.", MsgBoxStyle.Information)
                    Me.grdParametro.Caption = "Listado de Parametro (" + Me.grdParametro.RowCount.ToString + " registros)"
                Else
                    MsgBox("El Valor del Parámetro ya ha sido Inactivado.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If
            End If

        Catch ex As Exception
            MsgBox("El Valor del Parámetro no se Pudo Inactivar.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtParametro.Close()
            XdtParametro = Nothing
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

    Private Sub grdCargo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdParametro.DoubleClick
        Try
            If Seg.HasPermission("ModificarParametro") Then
                LlamaModificarParametro()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdCargo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdParametro.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdParametro_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdParametro.Filter
        Try
            XdsParametro("Parametro").FilterLocal(e.Condition)
            Me.grdParametro.Caption = " Listado de Parámetros (" + Me.grdParametro.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarParametroVarios") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarParametroVarios") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarParametroVarios") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirParametroVarios") Then
                Me.ToolImprimir.Enabled = True
            Else
                Me.ToolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub ToolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImprimir.Click
        Dim frmVisor As New frmCRVisorReporte
        Try

            Dim strSQL As String = ""
            If Me.grdParametro.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepStbCB17.rpt"
            frmVisor.Text = "Parametros y sus Valores"
            frmVisor.SQLQuery = "Select * From vwStbValoresParametros"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub
End Class