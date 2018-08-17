Public Class frmSccMetaCumplidaSocia

    Public intSclFichaID As Integer
    Dim XdsFicha As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet
    Dim ObjFichadt As BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoDataTable
    Dim ObjFichadr As BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoRow
    Dim XcMP As BOSistema.Win.XDataSet

    Private Sub frmSccMetaCumplidaSocia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            CargarFicha()
            CargarMeta()
            FormatoMeta()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub Seguridad()
        If Seg.HasPermission("CasoEspecialMetaProsperidad") = False Then
            toolMarcarCasoEspecial.Enabled = False
            toolMarcarReintegrada.Enabled = False
        End If
    End Sub

    Private Sub FormatoMeta()
        Try
            Dim i As Integer
            'Configuracion del Grid
            For i = 0 To Me.grdFicha.Splits(0).DisplayColumns.Count - 1
                Me.grdFicha.Splits(0).DisplayColumns(i).Visible = False
            Next

            Me.grdFicha.Splits(0).DisplayColumns("NombreSocia").Visible = True
            Me.grdFicha.Splits(0).DisplayColumns("CedulaSocia").Visible = True
            Me.grdFicha.Splits(0).DisplayColumns("MetaProsperidad").Visible = True
            Me.grdFicha.Splits(0).DisplayColumns("sMetaCumplida").Visible = True


            Me.grdFicha.Splits(0).DisplayColumns("NombreSocia").Width = 200
            Me.grdFicha.Splits(0).DisplayColumns("CedulaSocia").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("MetaProsperidad").Width = 300
            Me.grdFicha.Splits(0).DisplayColumns("sMetaCumplida").Width = 100

            Me.grdFicha.Columns("NombreSocia").Caption = "Nombre de la Socia"
            Me.grdFicha.Columns("CedulaSocia").Caption = "Cédula de la Socia"
            Me.grdFicha.Columns("MetaProsperidad").Caption = "Meta de Prosperidad"
            Me.grdFicha.Columns("sMetaCumplida").Caption = "Cumplimiento de Meta"
            Me.grdFicha.Columns("sMetaCumplida").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.Normal

            For i = 0 To Me.grdFicha.Splits(0).DisplayColumns.Count - 1
                Me.grdFicha.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            Me.grdFicha.Splits(0).DisplayColumns("CedulaSocia").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("nMetaCumplida").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarMeta()
        Try
            Dim StrSql As String

            StrSql = "exec spMetaProsperidadSociaGrupo " & Me.intSclFichaID

            If XcMP.ExistTable("Meta") Then
                XcMP("Meta").ExecuteSql(StrSql)
            Else
                XcMP.NewTable(StrSql, "Meta")
                XcMP("Meta").Retrieve()
            End If

            Me.grdFicha.DataSource = XcMP("Meta").Source
            Me.grdFicha.Rebind(False)
            Me.grdFicha.FetchRowStyles = True
            Me.grdFicha.Caption = " Listado de Metas de Prosperidad (" + Me.grdFicha.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarDepartamento()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                     " From StbDepartamento a " & _
                     " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                     " Order by a.sCodigo"

            If XdsFicha.ExistTable("Departamento") Then
                XdsFicha("Departamento").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Departamento")
                XdsFicha("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsFicha("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("Departamento").Count > 0 Then
                XdsFicha("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub InicializarVariables()
        Try


            ObjFichadt = New BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoDataTable
            ObjFichadr = New BOSistema.Win.SclEntFicha.SclFichaNotificacionCreditoRow

            XdsDetalle = New BOSistema.Win.XDataSet
            XdsFicha = New BOSistema.Win.XDataSet
            XcMP = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos:
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboBarrio.ClearFields()
            Me.cboGrupo.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarFicha()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Dim ObjUbicacionDT As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar la Ficha correspondiente al Id especificado como
            '-- parámetro, en los casos que se esté editando una.
            ObjFichadt.Filter = "nSclFichaNotificacionID = " & Me.intSclFichaID
            ObjFichadt.Retrieve()
            If ObjFichadt.Count = 0 Then
                Exit Sub
            End If
            ObjFichadr = ObjFichadt.Current

            'Código de la FNC:
            If Not ObjFichadr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjFichadr.nCodigo
            Else
                Me.txtCodigo.Text = ""
            End If

            'Estado FNC:
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjFichadr.nStbEstadoCreditoID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            '-- Ubicación y Grupo Solidario:
            strSQL = " Select a.nSclGrupoSolidarioID, a.nStbBarrioVerificadoID, a.nStbMunicipioID," & _
                     " a.nStbDepartamentoID, a.nStbDistritoID, a.Mercado, a.NombreGS " & _
                     " From vwSclFichaNotificacionCreditoGS a " & _
                     " Where a.nSclGrupoSolidarioID = " & ObjFichadr.nSclGrupoSolidarioID
            ObjUbicacionDT.ExecuteSql(strSQL)
            If ObjUbicacionDT.Count > 0 Then
                'Departamento:                
                XdsFicha("Departamento").SetCurrentByID("nStbDepartamentoID", ObjUbicacionDT.ValueField("nStbDepartamentoID"))
                'Municipio:
                CargarMunicipio(0, ObjUbicacionDT.ValueField("nStbMunicipioID"))
                If Me.cboMunicipio.ListCount > 0 Then
                    Me.cboMunicipio.SelectedIndex = 0
                    XdsFicha("Municipio").SetCurrentByID("nStbMunicipioID", ObjUbicacionDT.ValueField("nStbMunicipioID"))
                End If
                'Distrito: 
                CargarDistrito(0, ObjUbicacionDT.ValueField("nStbDistritoID"))
                If Me.cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                    XdsFicha("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))
                End If
                'Barrio:  
                CargarBarrio(0, ObjUbicacionDT.ValueField("nStbBarrioVerificadoID"))
                If Me.cboBarrio.ListCount > 0 Then
                    Me.cboBarrio.SelectedIndex = 0
                    XdsFicha("Barrio").SetCurrentByID("nStbBarrioID", ObjUbicacionDT.ValueField("nStbBarrioVerificadoID"))
                End If
                'Grupo Solidario:
                CargarGrupo(0, ObjUbicacionDT.ValueField("nSclGrupoSolidarioID"))
                If Me.cboGrupo.ListCount > 0 Then
                    Me.cboGrupo.SelectedIndex = 0
                    XdsFicha("Grupo").SetCurrentByID("nSclGrupoSolidarioID", ObjUbicacionDT.ValueField("nSclGrupoSolidarioID"))
                End If
                'Nombre GS:
                txtNombreGS.Text = ObjUbicacionDT.ValueField("NombreGS")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing

            ObjUbicacionDT.Close()
            ObjUbicacionDT = Nothing
        End Try
    End Sub

    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsFicha("Departamento").ValueField("nStbDepartamentoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where ((a.nActivo = 1) And (a.nPertenecePrograma = 1) And  (a.nStbDepartamentoID = " & XdsFicha("Departamento").ValueField("nStbDepartamentoID") & "))" & _
                             " Or (a.nStbMunicipioID = " & intMunicipioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsFicha.ExistTable("Municipio") Then
                XdsFicha("Municipio").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Municipio")
                XdsFicha("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsFicha("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("Municipio").Count > 0 Then
                XdsFicha("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("sNombre").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub CargarBarrio(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
        Try
            Dim Strsql As String

            Me.cboBarrio.ClearFields()
            If intLimpiarID = 0 Then
                If intBarrioID = 0 Then
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsFicha("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsFicha("Distrito").ValueField("nStbDistritoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsFicha("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsFicha("Distrito").ValueField("nStbDistritoID") & ")) " & _
                             " Or (a.nStbBarrioID = " & intBarrioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbBarrio a " & _
                         " Where a.nStbBarrioID = 0"
            End If

            If XdsFicha.ExistTable("Barrio") Then
                XdsFicha("Barrio").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Barrio")
                XdsFicha("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsFicha("Barrio").Source
            Me.cboBarrio.Rebind()

            Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("sNombre").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where (a.nPertenecePrograma = 1) And  (a.nActivo = 1) " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where ((a.nPertenecePrograma = 1) And (a.nActivo = 1)) " & _
                             " OR (a.nStbDistritoID = " & intDistritoID & ") " & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsFicha.ExistTable("Distrito") Then
                XdsFicha("Distrito").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Distrito")
                XdsFicha("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsFicha("Distrito").Source
            Me.cboDistrito.Rebind()

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").Width = 150

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("sNombre").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarGrupo(ByVal intLimpiarID As Integer, ByVal intGrupoID As Integer)
        Try
            Dim Strsql As String

            Me.cboGrupo.ClearFields()
            If intLimpiarID = 0 Then
                'Grupos En Proceso o Cerrados (NO permitir Anulados)
                'GS NO deberá formar parte de otra FNC ingresada con Estado: En Proceso. 
                If intGrupoID = 0 Then
                    Strsql = " Select b.sNombre AS Mercado, a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion, a.nSclTipodePlandeNegocioID , dbo.SclTipodePlandeNegocio.sDescripcion As DesPlanNegocio " & _
                             " FROM SclGrupoSolidario AS a INNER JOIN StbMercado AS b ON a.nStbMercadoVerificadoID = b.nStbMercadoID " & _
                             " INNER JOIN dbo.SclTipodePlandeNegocio ON a.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                             " WHERE (a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1','3')) And (b.sNombre = 'EstadoGrupo'))) " & _
                             " And (a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & ")" & _
                             " And (a.nSclGrupoSolidarioID NOT IN (Select nSclGrupoSolidarioID From SclFichaNotificacionCredito Where (nSclFichaNotificacionId <> " & Me.intSclFichaID & ") " & _
                             " And (nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1')) And (b.sNombre = 'EstadoCredito'))))) " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select b.sNombre AS Mercado, a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion, a.nSclTipodePlandeNegocioID , dbo.SclTipodePlandeNegocio.sDescripcion As DesPlanNegocio " & _
                             " FROM SclGrupoSolidario AS a INNER JOIN StbMercado AS b ON a.nStbMercadoVerificadoID = b.nStbMercadoID " & _
                             " INNER JOIN dbo.SclTipodePlandeNegocio ON a.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                             " WHERE (a.nStbEstadoGrupoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1','3')) And (b.sNombre = 'EstadoGrupo'))) " & _
                             " And (a.nStbBarrioVerificadoID = " & XdsFicha("Barrio").ValueField("nStbBarrioID") & ")" & _
                             " And (a.nSclGrupoSolidarioID NOT IN (Select nSclGrupoSolidarioID From SclFichaNotificacionCredito Where (nSclFichaNotificacionId <> " & Me.intSclFichaID & ") " & _
                             " And (nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                             " WHERE (a.sCodigoInterno IN ('1')) And (b.sNombre = 'EstadoCredito'))))) " & _
                             " Or (a.nSclGrupoSolidarioID = " & intGrupoID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nSclGrupoSolidarioID,a.nStbBarrioVerificadoID,a.sCodigo,a.sDescripcion as Descripcion, a.nSclTipodePlandeNegocioID " & _
                         " From SclGrupoSolidario a " & _
                         " WHERE a.nSclGrupoSolidarioID = 0"
            End If

            If XdsFicha.ExistTable("Grupo") Then
                XdsFicha("Grupo").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Grupo")
                XdsFicha("Grupo").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboGrupo.DataSource = XdsFicha("Grupo").Source
            Me.cboGrupo.Rebind()

            Me.cboGrupo.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nStbBarrioVerificadoID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("Mercado").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("nSclTipodePlandeNegocioID").Visible = False
            Me.cboGrupo.Splits(0).DisplayColumns("DesPlanNegocio").Visible = False

            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").Width = 90
            Me.cboGrupo.Splits(0).DisplayColumns("Descripcion").Width = 150

            Me.cboGrupo.Columns("sCodigo").Caption = "Código"
            Me.cboGrupo.Columns("Descripcion").Caption = "Descripción"

            Me.cboGrupo.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupo.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        'Dim XcDatos As New BOSistema.Win.XComando
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            'XcDatos.Close()
            'XcDatos = Nothing
        End Try
    End Sub

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        'Dim XcDatos As New BOSistema.Win.XComando
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            'XcDatos.Close()
            'XcDatos = Nothing
        End Try
    End Sub

    Private Sub tbFicha_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolRefrescar"
                CargarMeta()
                FormatoMeta()
            Case "toolMarcarCumplido"
                MetaSeleccionadaCumplida(1)
            Case "toolMarcarIncumplido"
                MetaSeleccionadaCumplida(0)
            Case "toolMarcarNoEvaluado"
                MetaSeleccionadaCumplida(2)
            Case "toolMarcarCambiado"
                MetaSeleccionadaCumplida(3)
            Case "toolMarcarCasoEspecial"
                MetaSeleccionadaCumplida(4)
            Case "toolMarcarReintegrada"
                MetaSeleccionadaCumplida(5)
        End Select
    End Sub

    Public Sub MetaSeleccionadaCumplida(ByVal n As Byte)
        Dim xdsM As New BOSistema.Win.XDataSet
        Dim fichaNegocio As Integer

        If IsDBNull(XcMP("Meta").Current("nSclFichaSociaNegocioID")) Then
            MsgBox("Esta socia no tiene meta de prosperidad.", vbCritical, "SMUSURA0")
            Exit Sub
        Else
            fichaNegocio = XcMP("Meta").Current("nSclFichaSociaNegocioID")
        End If

        If n = 1 Then
            Dim resp = MsgBox("¿Desea marcar Meta de Prosperidad como CUMPLIDA?", vbQuestion + vbYesNo, "SMUSURA0")
            If resp = vbYes Then
                xdsM.ExecuteSql("exec spSccMarcarMetaCumplimiento " & fichaNegocio & ", 1")
                MsgBox("La Meta se ha marcado como CUMPLIDA", vbInformation, "SMUSURA0")
            End If
        ElseIf n = 0 Then
            Dim resp = MsgBox("¿Desea marcar Meta de Prosperidad como INCUMPLIDA?", vbQuestion + vbYesNo, "SMUSURA0")
            If resp = vbYes Then
                xdsM.ExecuteSql("exec spSccMarcarMetaCumplimiento " & fichaNegocio & ", 0")
                MsgBox("La Meta se ha marcado como INCUMPLIDA", vbInformation, "SMUSURA0")
            End If
        ElseIf n = 2 Then
            Dim resp = MsgBox("¿Desea marcar Meta de Prosperidad como NO EVALUADA?", vbQuestion + vbYesNo, "SMUSURA0")
            If resp = vbYes Then
                xdsM.ExecuteSql("exec spSccMarcarMetaCumplimiento " & fichaNegocio & ", 2")
                MsgBox("La Meta se ha marcado como NO EVALUADA", vbInformation, "SMUSURA0")
            End If
        ElseIf n = 3 Then
            Dim resp = MsgBox("¿Desea marcar Meta de Prosperidad como CAMBIADA?", vbQuestion + vbYesNo, "SMUSURA0")
            If resp = vbYes Then
                xdsM.ExecuteSql("exec spSccMarcarMetaCumplimiento " & fichaNegocio & ", 3")
                MsgBox("La Meta se ha marcado como CAMBIADA", vbInformation, "SMUSURA0")
            End If
        ElseIf n = 4 Then
            Dim resp = MsgBox("¿Desea marcar Meta de Prosperidad como CASO ESPECIAL?", vbQuestion + vbYesNo, "SMUSURA0")
            If resp = vbYes Then
                xdsM.ExecuteSql("exec spSccMarcarMetaCumplimiento " & fichaNegocio & ", 4")
                MsgBox("La Meta se ha marcado como CASO ESPECIAL", vbInformation, "SMUSURA0")
            End If
        ElseIf n = 5 Then
            Dim resp = MsgBox("¿Desea marcar Meta de Prosperidad como REINTEGRADA?", vbQuestion + vbYesNo, "SMUSURA0")
            If resp = vbYes Then
                xdsM.ExecuteSql("exec spSccMarcarMetaCumplimiento " & fichaNegocio & ", 5")
                MsgBox("La Meta se ha marcado como REINTEGRADA", vbInformation, "SMUSURA0")
            End If
        End If

        'Actualizar
        CargarMeta()
        FormatoMeta()
    End Sub


End Class