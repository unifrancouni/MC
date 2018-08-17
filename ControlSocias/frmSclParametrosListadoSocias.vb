Public Class frmSclParametrosListadoSocias

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim strColorFrm As String
    Dim sActividadesSeleccionadas As String

    Dim IntPermiteConsultar As Integer
    'Dim IntPermiteEditar As Integer
    Dim IntDepartamento As Integer

    'Listado de Reportes
    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes 
    Public Enum EnumReportes
        Barrio = 1
        TipoNegocio = 2
        Socias = 3
        ListadoSocias = 4
        FichaSeguimiento = 5
        ListadoSociasCanceladasVigentes = 6
        TotalesDistribucionGeograficaYTipoNegocio = 7

    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property

    Private Sub InicializarVariables()
        Try
            XdsCombos = New BOSistema.Win.XDataSet

            EncuentraParametros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	13/03/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros de Delegación.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            ''Fecha Editar datos de Todas las Delegaciones:
            'Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            'IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

            'Departamento de la Delegación
            Strsql = "SELECT nStbDepartamentoID FROM vwStbDatosDelegacion WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntDepartamento = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
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

            If IntPermiteConsultar = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                         " From StbDepartamento a " & _
                         " Where a.nStbDepartamentoID = " & Me.IntDepartamento & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                         " From StbDepartamento a " & _
                         " Order by a.sCodigo"
            End If

            If XdsCombos.ExistTable("Departamento") Then
                XdsCombos("Departamento").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Departamento")
                XdsCombos("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboDepartamento.DataSource = XdsCombos("Departamento").Source
            Me.CboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.CboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.CboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.CboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '          Me.cboReporte.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            '           Me.cboReporte.Splits(0).DisplayColumns(0).Width = 238

            '            Me.cboReporte.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General


            'Ubicarlo en el primer registro
            If Me.CboDepartamento.ListCount > 0 And IntPermiteConsultar = 1 Then
                XdsCombos("Departamento").AddRow()
                XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Departamento").ValueField("Orden") = 0
                XdsCombos("Departamento").UpdateLocal()
                XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.CboDepartamento.SelectedIndex = 0
            End If
            HabilitarComboMunicipio()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer)
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                             " From StbMunicipio a " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsCombos.ExistTable("Municipio") Then
                XdsCombos("Municipio").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Municipio")
                XdsCombos("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsCombos("Municipio").Source
            Me.cboMunicipio.Rebind()
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboMunicipio.ListCount > 0 Then
                XdsCombos("Municipio").AddRow()
                XdsCombos("Municipio").ValueField("Descripcion") = "Todos"
                XdsCombos("Municipio").ValueField("nStbMunicipioID") = -19
                XdsCombos("Municipio").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Municipio").ValueField("Orden") = 0
                XdsCombos("Municipio").UpdateLocal()
                XdsCombos("Municipio").Sort = "Orden,sCodigo asc"
                Me.cboMunicipio.SelectedIndex = 0
            End If
            ''HabilitarComboBarrio()

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                             " From StbDistrito a " & _
                             " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsCombos.ExistTable("Distrito") Then
                XdsCombos("Distrito").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Distrito")
                XdsCombos("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsCombos("Distrito").Source
            Me.cboDistrito.Rebind()



            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 157

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDistrito.ListCount > 0 Then
                XdsCombos("Distrito").AddRow()
                XdsCombos("Distrito").ValueField("Descripcion") = "Todos"
                XdsCombos("Distrito").ValueField("nStbDistritoID") = -19
                XdsCombos("Distrito").ValueField("Orden") = 0
                XdsCombos("Distrito").UpdateLocal()
                XdsCombos("Distrito").Sort = "Orden,sCodigo asc"
                Me.cboDistrito.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '**************************************************************************    
    '* Cargar la lista de Barrios existente para un filtro de municipios 
    '**************************************************************************

    Private Sub CargarBarrio(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String
            Dim CadWhere As String '' Cadena para el filtro por todos o  departamento y o municipio

            Me.cboBarrio.ClearFields()
            CadWhere = ""
            If Me.cboDepartamento.SelectedIndex > 0 Then
                CadWhere = " Where  dbo.StbDepartamento.nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
            End If
            If Me.cboMunicipio.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
            End If
            If Me.cboDistrito.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbBarrio.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
            End If

            


            If intLimpiarID = 0 Then
                Strsql = " Select dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre as Descripcion,1 as Orden " & _
                             " FROM         dbo.StbBarrio INNER JOIN" & _
                             " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                             "  dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " & _
                             CadWhere & " Order by dbo.StbBarrio.sCodigo"
            Else
                Strsql = " Select dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre as Descripcion,1 as Orden " & _
                             " FROM     dbo.StbBarrio INNER JOIN" & _
                             " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                             "  dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " & _
                            " Where dbo.StbBarrio.nStbBarrioID = 0" & _
                         " Order by dbo.StbBarrio.sCodigo"
            End If

            If XdsCombos.ExistTable("Barrio") Then
                XdsCombos("Barrio").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Barrio")
                XdsCombos("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsCombos("Barrio").Source
            Me.cboBarrio.Rebind()

            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("Descripcion").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboBarrio.ListCount > 0 Then
                XdsCombos("Barrio").AddRow()
                XdsCombos("Barrio").ValueField("Descripcion") = "Todos"
                XdsCombos("Barrio").ValueField("nStbDistritoID") = -19
                XdsCombos("Barrio").ValueField("Orden") = 0
                XdsCombos("Barrio").UpdateLocal()
                XdsCombos("Barrio").Sort = "Orden,sCodigo asc"
                Me.cboBarrio.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False
            Me.errParametro.Clear()
            'Departamento
            If Me.CboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.CboDepartamento.Focus()
                GoTo SALIR
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                GoTo SALIR
            End If

            'Distrito
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                GoTo SALIR
            End If

            'Incluido Barrio
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Lugar de Pago válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboBarrio, "Debe seleccionar un Lugar de Pago válido.")
                Me.cboBarrio.Focus()
                GoTo SALIR
            End If
            If mNomRep = EnumReportes.TipoNegocio Or _
               mNomRep = EnumReportes.ListadoSocias Or _
               mNomRep = EnumReportes.ListadoSociasCanceladasVigentes Or _
               mNomRep = EnumReportes.FichaSeguimiento Or _
               mNomRep = EnumReportes.Barrio Or _
               mNomRep = EnumReportes.Socias Or _
               mNomRep = EnumReportes.TotalesDistribucionGeograficaYTipoNegocio Then
                If IsDBNull(cdeFechaInicial.Value) And mNomRep <> EnumReportes.ListadoSociasCanceladasVigentes Then
                    MsgBox("Debe seleccionar una fecha de inicio válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válido.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If

                If IsDBNull(CdeFechaFinal.Value) Then
                    MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                    Me.CdeFechaFinal.Focus()
                    GoTo SALIR
                End If
                If mNomRep <> EnumReportes.ListadoSociasCanceladasVigentes Then
                    If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                        MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                        Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                        Me.cdeFechaInicial.Focus()
                        GoTo SALIR
                    End If
                End If
            End If
            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        '----------------------------------------------------------------------------------
        'Llama a los reportes de consolidados y detalle de créditos por distritos y barrios
        '----------------------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim Agrupar As String
        Dim CadSql As String


        Try
            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""

            If CboDepartamento.Text <> "Todos" Then
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And  nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                Else
                    Filtro = " Where nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If

                If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                    Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                End If
            End If

            If cboMunicipio.SelectedIndex > 0 Then
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                Else
                    Filtro = " Where nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                End If
            End If

            frmVisor.WindowState = FormWindowState.Maximized

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            If cboDistrito.SelectedIndex > 0 Then
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                Else
                    Filtro = " Where nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                End If
            End If

            ''Select Case cboReporte.SelectedIndex
            Me.Cursor = Cursors.WaitCursor
            Select Case mNomRep
                Case EnumReportes.ListadoSocias
                    '                    CadSql = "SELECT     TOP (100) PERCENT dbo.vwStbUbicacionGeografica.Departamento, dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.Distrito, " & _
                    '                      "dbo.vwStbUbicacionGeografica.Barrio, dbo.SclGrupoSolidario.sDescripcion AS Grupo, LTRIM(RTRIM(ListaSocias.sNombre1))  " & _
                    '                      "+ ' ' + LTRIM(RTRIM(ListaSocias.sNombre2)) + ' ' + LTRIM(RTRIM(ListaSocias.sApellido1)) + ' ' + LTRIM(RTRIM(ListaSocias.sApellido2)) AS Socia, " & _
                    '                      " ListaSocias.sNumeroCedula, ListaSocias.sDireccionSocia, ListaSocias.nSclSociaID, dbo.vwStbUbicacionGeografica.nStbDepartamentoID,  " & _
                    '                      " dbo.vwStbUbicacionGeografica.nStbMunicipioID, dbo.vwStbUbicacionGeografica.nStbDistritoID, dbo.vwStbUbicacionGeografica.CodDistrito, " & _
                    '                      " dbo.SclGrupoSolidario.nStbMercadoVerificadoID " & _
                    '" FROM         (SELECT     dbo.SclGrupoSocia.nSclSociaID, dbo.SclSocia.sNombre1, dbo.SclSocia.sNombre2, dbo.SclSocia.sApellido1, dbo.SclSocia.sApellido2, " & _
                    '  "                                            dbo.SclSocia.sNumeroCedula, dbo.SclSocia.sDireccionSocia, MAX(dbo.SclGrupoSocia.nSclGrupoSolidarioID) AS nSclGrupoSolidarioID " & _
                    '   "                    FROM          dbo.SclFichaNotificacionCredito INNER JOIN " & _
                    '    "                                          dbo.SclFichaNotificacionDetalle ON  " & _
                    '     "                                         dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN " & _
                    '      "                                        dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                    '       "                                       dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " & _
                    '        "                                      dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                    '         "                                     dbo.SclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID " & _
                    '          "             WHERE      (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (dbo.StbValorCatalogo.sCodigoInterno = '2') " & _
                    '          " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') " & _
                    '           "            GROUP BY dbo.SclGrupoSocia.nSclSociaID, dbo.SclSocia.sNombre1, dbo.SclSocia.sNombre2, dbo.SclSocia.sApellido1, dbo.SclSocia.sApellido2," & _
                    '            "                                  dbo.SclSocia.sNumeroCedula, dbo.SclSocia.sDireccionSocia) AS ListaSocias INNER JOIN " & _
                    '             "         dbo.SclGrupoSolidario ON ListaSocias.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN " & _
                    '              "        dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID " '& _
                    '                    '" ORDER BY dbo.vwStbUbicacionGeografica.Departamento, dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.Distrito, " & _
                    '                    '"                    dbo.vwStbUbicacionGeografica.Barrio, Grupo, Socia"



                    'If cboBarrio.SelectedIndex > 0 Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    '    Else
                    '        Filtro = " Where nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    '    End If
                    'End If

                    'If Trim(Filtro) <> "" Then
                    '    Filtro = Filtro & " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    'Else
                    '    Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    'End If

                    'If cboMontoAprobado.SelectedIndex > 0 Then
                    '    If Trim(Filtro) <> "" Then
                    '        'MsgBox(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                    '        Filtro = Filtro & " And nMontoCreditoAprobado=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                    '    End If
                    'Else
                    '    'Filtro = Filtro & " And nMontoCreditoAprobado<>10000 And nMontoCreditoAprobado<>1850 And nMontoCreditoAprobado<>3700 And nMontoCreditoAprobado<>4600 And nMontoCreditoAprobado<>5500"
                    'End If

                    frmVisor.Parametros("@DepartamentoID") = CboDepartamento.Columns("nStbDepartamentoID").Value
                    frmVisor.Parametros("@MunicipioID") = cboMunicipio.Columns("nStbMunicipioID").Value
                    frmVisor.Parametros("@DistritoID") = cboDistrito.Columns("nStbDistritoID").Value
                    frmVisor.Parametros("@BarrioID") = cboBarrio.Columns("nStbBarrioID").Value
                    frmVisor.Parametros("@FechaINI") = cdeFechaInicial.Value
                    frmVisor.Parametros("@FechaFIN") = CdeFechaFinal.Value
                    If cboMontoAprobado.Text.Equals("(Todos)") Then
                        frmVisor.Parametros("@nMontoAprobado") = 0
                    Else
                        frmVisor.Parametros("@nMontoAprobado") = CDbl(cboMontoAprobado.Text)
                    End If



                    frmVisor.Formulas("Parametros") = "' Parámetros.  Dpto: " & Me.CboDepartamento.Text & " , Munic: " & Me.cboMunicipio.Text & "  , Monto C$:  " & Trim(cboMontoAprobado.Text) & "'"


                    If radConsolidado.Checked Then
                        frmVisor.NombreReporte = "RepSccCC36.rpt"
                        frmVisor.Text = "Listado de Socias que tienen han tenido creditos aprobados"
                        'frmVisor.SQLQuery = "Select * From vwSccListadoSocias  " & Filtro '& "  Order by  Departamento,Municipio,Distrito, Barrio "
                        frmVisor.Formulas("Encabezado") = "'TOTALES DE SOCIAS CON PRIMER CREDITO APROBADO ENTRE EL " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Y EL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
                    Else
                        frmVisor.NombreReporte = "RepSccCC33.rpt"
                        frmVisor.Text = "Listado de Socias que tienen han tenido creditos aprobados"
                        'frmVisor.SQLQuery = "Select * From vwSccListadoSocias  " & Filtro '& "  Order by  Departamento,Municipio,Distrito, Barrio "
                        frmVisor.Formulas("Encabezado") = "'LISTADO DE SOCIAS CON PRIMER CREDITO APROBADO ENTRE EL " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Y EL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
                    End If

                Case EnumReportes.Barrio


                    Filtro = " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "

                    If CboDepartamento.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And  vwStbUbicacionGeografica.nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        Else
                            Filtro = " Where vwStbUbicacionGeografica.nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        End If

                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And vwStbUbicacionGeografica.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " Where vwStbUbicacionGeografica.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If

                    frmVisor.WindowState = FormWindowState.Maximized

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And vwStbUbicacionGeografica.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " Where vwStbUbicacionGeografica.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And vwStbUbicacionGeografica.nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " Where vwStbUbicacionGeografica.nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    frmVisor.NombreReporte = "RepSclCS14.rpt"
                    frmVisor.Text = "Listado de Barrios con Grupos Solidarios con Créditos Aprobados"
                    'frmVisor.SQLQuery = " Select * From vwSccListadoBarriosCreditosAprobados " & Filtro & "  Order by  Departamento,Municipio,Distrito, Barrio "
                    frmVisor.SQLQuery = " SELECT     TOP (100) PERCENT dbo.vwStbUbicacionGeografica.nStbDepartamentoID, dbo.vwStbUbicacionGeografica.Departamento, " & _
                                      "    dbo.vwStbUbicacionGeografica.nStbMunicipioID, dbo.vwStbUbicacionGeografica.Municipio, dbo.StbBarrio.nStbDistritoID, " & _
                                      "    dbo.vwStbUbicacionGeografica.CodDistrito, dbo.vwStbUbicacionGeografica.Distrito, dbo.StbBarrio.sCodigo AS CodigoBarrio, " & _
                      " dbo.StbBarrio.nStbBarrioID, dbo.StbBarrio.sNombre AS Barrio " & _
" FROM         dbo.StbBarrio INNER JOIN " & _
"                      dbo.SclGrupoSolidario ON dbo.StbBarrio.nStbBarrioID = dbo.SclGrupoSolidario.nStbBarrioVerificadoID INNER JOIN " & _
"                      dbo.SclGrupoSocia ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID INNER JOIN " & _
"                      dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN " & _
"                      dbo.vwStbUbicacionGeografica ON dbo.StbBarrio.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN " & _
"                      dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
"                      dbo.SclFichaNotificacionCredito ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID AND  " & _
"                      dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID INNER JOIN " & _
"                      dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  " & _
"                    dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID " & _
" WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '7' OR dbo.StbValorCatalogo.sCodigoInterno = '5') " & _
"                       AND StbValorCatalogo_1.sCodigoInterno = '2' " & Filtro & _
" GROUP BY dbo.vwStbUbicacionGeografica.nStbDepartamentoID, dbo.vwStbUbicacionGeografica.Departamento, dbo.vwStbUbicacionGeografica.nStbMunicipioID,  " & _
"                      dbo.vwStbUbicacionGeografica.Municipio, dbo.StbBarrio.nStbDistritoID, dbo.vwStbUbicacionGeografica.CodDistrito,  " & _
"                    dbo.vwStbUbicacionGeografica.Distrito, dbo.StbBarrio.sCodigo, dbo.StbBarrio.nStbBarrioID, dbo.StbBarrio.sNombre " & _
" ORDER BY dbo.vwStbUbicacionGeografica.CodDistrito, CodigoBarrio "

                    frmVisor.Formulas("RangoFecha") = "'DEL" & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
                Case EnumReportes.FichaSeguimiento

                    'If radConsolidado.Checked = True Then

                    '    If cboBarrio.SelectedIndex > 0 Then
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And dbo.vwStbUbicacionGeografica.nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    '        Else
                    '            Filtro = " Where dbo.vwStbUbicacionGeografica.nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    '        End If
                    '    End If
                    'Else
                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " Where StbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If
                    'End If
                    If Me.RdDistrito.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbMercadoVerificadoID=1 "
                        Else
                            Filtro = " Where nStbMercadoVerificadoID=1 "
                        End If
                    ElseIf Me.RdMercado.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & "  And  nStbMercadoVerificadoID<>1 "
                        Else
                            Filtro = " Where  nStbMercadoVerificadoID<>1 "
                        End If
                    End If


                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And dFechaFicha>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaFicha<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    Else
                        Filtro = " Where dFechaFicha>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaFicha<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    End If








                    If Me.radTodos.Checked = True Then

                        frmVisor.Formulas("Parametro") = "' TODOS LOS TIPOS DE NEGOCIOS'"
                    Else
                        If Me.RadNuevos.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " AND nTieneNegocioVerificado = 0  "
                            Else
                                Filtro = " Where nTieneNegocioVerificado = 0 "
                            End If


                            frmVisor.Formulas("Parametro") = "' NEGOCIOS NUEVOS'"
                        Else
                            If Me.RadActuales.Checked = True Then
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " AND nTieneNegocioVerificado = 1  "
                                Else
                                    Filtro = " Where nTieneNegocioVerificado = 1 "
                                End If

                                frmVisor.Formulas("Parametro") = "' NEGOCIOS ACTUALES'"
                            End If
                        End If
                    End If
                    frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & " " & IIf(RdDistrito.Checked, "EN DISTRITOS", IIf(RdMercado.Checked, "EN MERCADOS", "EN DISTRITOS Y MERCADOS")) & " " & IIf(RadVigente.Checked, " CON CREDITOS VIGENTES", IIf(RadCancelado.Checked, "CON CREDITOS CANCELADOS", "TODOS LOS CREDITOS")) & "'"

                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                        Else
                            Filtro = " nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                        End If

                    End If


                    If Me.RadVigente.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And CodEstadoFicha='5'"
                        Else
                            Filtro = " Where CodEstadoFicha='5'"
                        End If
                    Else
                        If RadCancelado.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And CodEstadoFicha='7'"
                            Else
                                Filtro = " Where CodEstadoFicha='7'"
                            End If

                        End If

                    End If

                    frmVisor.NombreReporte = "RepSclCS35.rpt"
                    frmVisor.Text = "Listado de  Fichas de Seguimiento"
                    frmVisor.SQLQuery = " Select * From vwSclSeguimientoFichaSociaDatosPersonales " & Filtro & "  Order by  Departamento,Municipio,Distrito, Barrio "
                    frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"
                    frmVisor.Formulas("Parametros") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")'"


                Case EnumReportes.TotalesDistribucionGeograficaYTipoNegocio

                    Filtro = String.Empty
                    frmVisor.Text = "Total de Socias y Montos por Distibucion Geográfica y Tipo de Negocio"
                    frmVisor.Formulas("USUARIO") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.NombreReporte = "RepSclCS43.rpt"
                    frmVisor.Parametros("@Agrupacion") = 5

                    If Me.rdoDept.Checked And Me.chkDistribucion.Checked Then

                        frmVisor.NombreReporte = "RepSclCS43N.rpt"
                        frmVisor.Formulas("FILTRO_NEGOCIOS") = "'TOTAL A NIVEL NACIONAL'"
                        frmVisor.Parametros("@Agrupacion") = 1

                    ElseIf Me.rdoDept.Checked And (Me.chkDistribucion.Checked = False) Then

                        ''frmVisor.NombreReporte = "RepSclCS15D.rpt"
                        frmVisor.Formulas("FILTRO_NEGOCIOS") = "'TOTAL A NIVEL DEPARTAMENTAL'"
                        frmVisor.Formulas("TipoReporte") = "'2'"
                        ''frmVisor.Parametros("@Agrupacion") = 2

                    ElseIf Me.rdoMuni.Checked Then

                        ''frmVisor.NombreReporte = "RepSclCS15M.rpt"
                        ''frmVisor.Parametros("@Agrupacion") = 3
                        frmVisor.Formulas("FILTRO_NEGOCIOS") = "'TOTAL A NIVEL MUNICIPAL'"
                        frmVisor.Formulas("TipoReporte") = "'3'"

                    ElseIf Me.rdoDist.Checked Then

                        ''frmVisor.NombreReporte = "RepSclCS15Dist.rpt"
                        ''frmVisor.Parametros("@Agrupacion") = 4
                        frmVisor.Formulas("FILTRO_NEGOCIOS") = "'TOTAL A NIVEL DISTRITAL'"
                        frmVisor.Formulas("TipoReporte") = "'4'"

                    ElseIf Me.rdoBarrio.Checked Then

                        ''frmVisor.NombreReporte = "RepSclCS15B.rpt"
                        ''frmVisor.Parametros("@Agrupacion") = 5
                        frmVisor.Formulas("FILTRO_NEGOCIOS") = "'TOTAL EN BARRIOS'"
                        frmVisor.Formulas("TipoReporte") = "'5'"

                    End If

                    frmVisor.Formulas("Parametros") = "'Parámetros (Depto: " & Me.CboDepartamento.Text & ") , (Munic: " & Me.cboMunicipio.Text & ") , (Distrito:" & Me.cboDistrito.Text & ") , (Barrio: " & Me.cboBarrio.Text & ") , (Monto C$: " & Trim(cboMontoAprobado.Text) & ")'"
                    frmVisor.Parametros("@CodigoFuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, Nothing))
                    frmVisor.Parametros("@FechaDesde") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaHasta") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(Me.RdVentanadeGenero.Checked, 2, 3))
                    frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & " " & IIf(RdDistrito.Checked, "EN DISTRITOS", IIf(RdMercado.Checked, "EN MERCADOS", "EN DISTRITOS Y MERCADOS")) & " " & IIf(RadVigente.Checked, " CON CREDITOS VIGENTES", IIf(RadCancelado.Checked, "CON CREDITOS CANCELADOS", "TODOS LOS CREDITOS")) & "'"

                    If cboMontoAprobado.Text <> "(Todos)" Then
                        If Trim(Filtro) <> "" Then
                            'MsgBox(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                            'MsgBox(Trim(Me.cboMontoAprobado.Text))
                            Filtro = Filtro & " And {spSclSociasConCreditosAprobadosPorNegocio;1.MontoAprobado}=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                        Else
                            Filtro = " {spSclSociasConCreditosAprobadosPorNegocio;1.MontoAprobado}=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                        End If
                        'Filtro = Filtro & " {spSclSociasConCreditosAprobadosPorNegocio;1.MontoAprobado}<>10000 And {spSclSociasConCreditosAprobadosPorNegocio;1.MontoAprobado}<>1850 And {spSclSociasConCreditosAprobadosPorNegocio;1.MontoAprobado}<>3700 And {spSclSociasConCreditosAprobadosPorNegocio;1.MontoAprobado}<>4600 And {spSclSociasConCreditosAprobadosPorNegocio;1.MontoAprobado}<>5500"
                    End If

                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            'Filtro = Filtro & " And {spSclSociasConCreditosAprobadosPorNegocio;1.nFondoPresupuestario} =" & IIf(RdPresupuesto.Checked, "1", "0")
                        Else
                            'Filtro = " {spSclSociasConCreditosAprobadosPorNegocio;1.nFondoPresupuestario} = " & IIf(RdPresupuesto.Checked, "1", "0")
                        End If
                    End If

                    If (CboDepartamento.SelectedIndex > 0 Or CboDepartamento.Text <> "Todos") And Me.chkDistribucion.Checked = False Then

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " AND {spSclSociasConCreditosAprobadosPorNegocio;1.nStbDepartamentoID} = " & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        Else
                            Filtro = " {spSclSociasConCreditosAprobadosPorNegocio;1.nStbDepartamentoID} =" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        End If

                    End If

                    If cboMunicipio.SelectedIndex > 0 And Me.chkDistribucion.Checked = False Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " AND {spSclSociasConCreditosAprobadosPorNegocio;1.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " {spSclSociasConCreditosAprobadosPorNegocio;1.nStbMunicipioID} =" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboDistrito.SelectedIndex > 0 And Me.chkDistribucion.Checked = False Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " AND {spSclSociasConCreditosAprobadosPorNegocio;1.nStbDistritoID} =" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSclSociasConCreditosAprobadosPorNegocio;1.nStbDistritoID} =" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 And Me.chkDistribucion.Checked = False Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " AND {spSclSociasConCreditosAprobadosPorNegocio;1.nStbBarrioID} =" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSclSociasConCreditosAprobadosPorNegocio;1.nStbBarrioID} =" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If Not String.IsNullOrEmpty(Me.sActividadesSeleccionadas) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " AND {spSclSociasConCreditosAprobadosPorNegocio;1.Codigo Negocio} in [ " & sActividadesSeleccionadas & " ]"
                        Else
                            Filtro = " {spSclSociasConCreditosAprobadosPorNegocio;1.Codigo Negocio} in [ " & sActividadesSeleccionadas & " ]"
                        End If
                    End If

                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                Case EnumReportes.TipoNegocio

                    If radConsolidado.Checked = True Then

                        If Not (Me.RdCooperativa.Checked Or Me.RdMercado.Checked) Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And nStbMercadoVerificadoID=1 "
                            Else
                                Filtro = " Where nStbMercadoVerificadoID= 1 "
                            End If
                        End If

                        If cboBarrio.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And dbo.vwStbUbicacionGeografica.nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                            Else
                                Filtro = " Where dbo.vwStbUbicacionGeografica.nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                            End If
                        End If

                    Else
                        If cboBarrio.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                            Else
                                Filtro = " Where StbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                            End If
                        End If
                    End If

                    If Me.RdDistrito.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbMercadoVerificadoID=1 "
                        Else
                            Filtro = " Where nStbMercadoVerificadoID=1 "
                        End If
                    ElseIf Me.RdMercado.Checked Or Me.RdCooperativa.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & "  And  nStbMercadoVerificadoID<>1 "
                        Else
                            Filtro = " Where  nStbMercadoVerificadoID<>1 "
                        End If
                    End If

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    Else
                        Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    End If

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    Else
                        Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    End If

                    If radConsolidado.Checked = True Then
                        frmVisor.NombreReporte = "copiaRepSclCS15.rpt"
                        frmVisor.Formulas("RangoFecha") = "' DEL " & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & " AL " & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & " '"  '"  ' Al :" & CdeFechaFinal.Value

                        'AQUI CAMBIOS
                        'frmVisor.Formulas("TipoPrograma") = "'" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"

                        frmVisor.Formulas("Parametros") = "'Dpto: " & Me.CboDepartamento.Text & " , Munic: " & Me.cboMunicipio.Text & " , Monto C$:  " & Trim(cboMontoAprobado.Text) & "'"
                        frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)

                        'frmVisor.Formulas("TipoPrograma") = "'" & IIf(RdUsuraCero.Checked, "1", "2") & "'"

                        'If RdUsuraCero.Checked = True Then
                        '    frmVisor.Formulas("TipoPrograma") = "1"
                        'Else
                        '    frmVisor.Formulas("TipoPrograma") = "2"
                        'End If

                        frmVisor.Text = "Total de Socias con Créditos aprobados por distrito y tipo de negocio"

                        Agrupar = " GROUP  BY dbo.vwStbUbicacionGeografica.Barrio, dbo.vwStbUbicacionGeografica.Distrito, dbo.StbValorCatalogo.sDescripcion, dbo.vwStbUbicacionGeografica.nStbDepartamentoID, " & _
                                     " dbo.vwStbUbicacionGeografica.Departamento, dbo.vwStbUbicacionGeografica.nStbMunicipioID, dbo.vwStbUbicacionGeografica.Municipio,  " & _
                                     " dbo.vwStbUbicacionGeografica.nStbDistritoID, dbo.vwStbUbicacionGeografica.CodDistrito "
                        CadSql = "SELECT     TOP (100) PERCENT dbo.vwStbUbicacionGeografica.nStbDepartamentoID, dbo.vwStbUbicacionGeografica.Departamento, " & _
                                    " dbo.vwStbUbicacionGeografica.nStbMunicipioID, dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.nStbDistritoID, " & _
                                    "  dbo.vwStbUbicacionGeografica.CodDistrito, dbo.vwStbUbicacionGeografica.Distrito,dbo.vwStbUbicacionGeografica.Barrio, dbo.StbValorCatalogo.sDescripcion AS TipoNegocio, " & _
                                    " COUNT(dbo.SclFichaSocia.nSclGrupoSociaID) AS NoSocias, SUM(dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado) AS MontoAprobado " & _
                                    " FROM         dbo.SclFichaSocia INNER JOIN " & _
                                    " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbActividadEconomicaVerificadaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                                    " dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                                    " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN StbMercado sm ON sm.nStbMercadoID = dbo.SclGrupoSolidario.nStbMercadoID INNER JOIN " & _
                                    " dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN " & _
                                    " dbo.SclFichaNotificacionDetalle ON dbo.SclFichaSocia.nSclFichaSociaID = dbo.SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN " & _
                                    " dbo.SclFichaNotificacionCredito ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID AND " & _
                                    " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                                    " dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                                    " INNER JOIN dbo.SccSolicitudDesembolsoCredito ON dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
                                    " INNER JOIN  dbo.ScnFuenteFinanciamiento ON dbo.SccSolicitudDesembolsoCredito.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID "

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And     (StbValorCatalogo_1.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) "
                        Else
                            Filtro = " Where     (StbValorCatalogo_1.sCodigoInterno = '2') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)  "
                        End If

                        If Me.radTodos.Checked = True Then
                            'If Trim(Filtro) <> "" Then
                            '    Filtro = Filtro & " And (StbValorCatalogo_1.sCodigoInterno = '5')  "
                            'Else
                            '    Filtro = " Where (StbValorCatalogo_1.sCodigoInterno = '5')  "
                            'End If
                            'CadSql = "SELECT     TOP (100) PERCENT dbo.vwStbUbicacionGeografica.nStbDepartamentoID, dbo.vwStbUbicacionGeografica.Departamento,  " & _
                            '         " dbo.vwStbUbicacionGeografica.nStbMunicipioID, dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.nStbDistritoID, " & _
                            '         " dbo.vwStbUbicacionGeografica.Distrito, dbo.StbValorCatalogo.sDescripcion AS TipoNegocio, COUNT(dbo.SclFichaSocia.nSclGrupoSociaID) AS NoSocias " & _
                            '         " FROM         dbo.SclFichaSocia INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbActividadEconomicaVerificadaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                            '         " dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                            '         " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN " & _
                            '         " dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN " & _
                            '         "  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo_1.nStbValorCatalogoID "
                            frmVisor.Formulas("Parametro") = "' TODOS LOS TIPOS DE NEGOCIOS'"
                        Else
                            If Me.RadNuevos.Checked = True Then
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " AND (dbo.SclFichaSocia.nTieneNegocioVerificado = 0)  "
                                Else
                                    Filtro = " Where (dbo.SclFichaSocia.nTieneNegocioVerificado = 0) "
                                End If

                                'CadSql = "SELECT     TOP (100) PERCENT dbo.vwStbUbicacionGeografica.nStbDepartamentoID, dbo.vwStbUbicacionGeografica.Departamento,  " & _
                                '         " dbo.vwStbUbicacionGeografica.nStbMunicipioID, dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.nStbDistritoID, " & _
                                '         " dbo.vwStbUbicacionGeografica.Distrito, dbo.StbValorCatalogo.sDescripcion AS TipoNegocio, COUNT(dbo.SclFichaSocia.nSclGrupoSociaID) AS NoSocias " & _
                                '         " FROM         dbo.SclFichaSocia INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbActividadEconomicaVerificadaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                                '         " dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                                '         " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN " & _
                                '         " dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN " & _
                                '         "  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo_1.nStbValorCatalogoID "

                                frmVisor.Formulas("Parametro") = "' NEGOCIOS NUEVOS'"
                            Else
                                If Me.RadActuales.Checked = True Then
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " AND (dbo.SclFichaSocia.nTieneNegocioVerificado = 1)  "
                                    Else
                                        Filtro = " Where (dbo.SclFichaSocia.nTieneNegocioVerificado = 1) "
                                    End If

                                    'CadSql = "SELECT     TOP (100) PERCENT dbo.vwStbUbicacionGeografica.nStbDepartamentoID, dbo.vwStbUbicacionGeografica.Departamento,  " & _
                                    '         " dbo.vwStbUbicacionGeografica.nStbMunicipioID, dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.nStbDistritoID, " & _
                                    '         " dbo.vwStbUbicacionGeografica.Distrito, dbo.StbValorCatalogo.sDescripcion AS TipoNegocio, COUNT(dbo.SclFichaSocia.nSclGrupoSociaID) AS NoSocias " & _
                                    '         " FROM         dbo.SclFichaSocia INNER JOIN dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbActividadEconomicaVerificadaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                                    '         " dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                                    '         " dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN " & _
                                    '         " dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN " & _
                                    '         " dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo_1.nStbValorCatalogoID "
                                    frmVisor.Formulas("Parametro") = "' NEGOCIOS ACTUALES'"
                                End If
                            End If
                        End If

                        frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & " " & IIf(RdDistrito.Checked, "EN DISTRITOS", IIf(RdMercado.Checked, "EN MERCADOS", IIf(Me.RdCooperativa.Checked, "EN COOPERATIVAS", "EN DISTRITOS, MERCADOS Y COOPERATIVAS"))) & "'"
                        ''frmVisor.Formulas("DesFondo") = "'" & IIf(RdDistrito.Checked, "EN DISTRITOS", IIf(RdMercado.Checked, "EN MERCADOS", "EN DISTRITOS Y MERCADOS")) & "'"

                        If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And dbo.ScnFuenteFinanciamiento.nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                            Else
                                Filtro = " dbo.ScnFuenteFinanciamiento.nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                            End If
                        End If

                        If cboMontoAprobado.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                'MsgBox(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                                Filtro = Filtro & " And dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                            End If
                        Else
                            'Filtro = Filtro & " And MontoAprobado<>10000 And MontoAprobado<>1850 And MontoAprobado<>3700 And MontoAprobado<>4600 And MontoAprobado<>5500"
                        End If

                        If Me.RdCooperativa.Checked Or Me.RdMercado.Checked Then
                            Filtro = IIf(String.IsNullOrEmpty(Filtro), "", Filtro & " AND ") & String.Format(" sm.nCooperativa ={0}", IIf(Me.RdCooperativa.Checked, 1, 0))
                        End If

                        CadSql = CadSql & Filtro & Agrupar & "  Order by  Departamento,Municipio,Distrito,TipoNegocio "
                        frmVisor.SQLQuery = CadSql

                    Else  ' Es el detalle de negocio 
                        frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & " " & IIf(RdDistrito.Checked, "EN DISTRITOS", IIf(RdMercado.Checked, "EN MERCADOS", IIf(Me.RdCooperativa.Checked, "EN COOPERATIVAS", "EN DISTRITOS, MERCADOS Y COOPERATIVAS"))) & "'"

                        frmVisor.NombreReporte = "RepSclCS17.rpt"

                        frmVisor.Text = "Listado de Socias con Créditos aprobados por distrito y tipo de negocio"
                        frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
                        frmVisor.Formulas("Parametros") = "'Dpto: " & Me.CboDepartamento.Text & " , Munic: " & Me.cboMunicipio.Text & " , Monto C$:  " & Trim(cboMontoAprobado.Text) & "'"

                        If Me.radTodos.Checked = True Then
                            frmVisor.Formulas("Parametro") = "' TODOS LOS TIPOS DE NEGOCIOS'"
                        Else
                            If Me.RadNuevos.Checked = True Then
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And  (nTieneNegocioVerificado = 0)  "
                                Else
                                    Filtro = " Where (nTieneNegocioVerificado = 0) "
                                End If
                                frmVisor.Formulas("Parametro") = "' NEGOCIOS NUEVOS'"
                            Else
                                If Me.RadActuales.Checked = True Then
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " AND (nTieneNegocioVerificado = 1)  "
                                    Else
                                        Filtro = " Where (nTieneNegocioVerificado = 1) "
                                    End If

                                    frmVisor.Formulas("Parametro") = "' NEGOCIOS ACTUALES'"
                                End If 'If Me.RadActuales.Checked = True Then
                            End If ' If Me.RadNuevos.Checked = True Then
                        End If 'If Me.radTodos.Checked = True Then

                        If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                            Else
                                Filtro = " nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                            End If
                        End If

                        If Me.RdCooperativa.Checked Or Me.RdMercado.Checked Then
                            Filtro = IIf(String.IsNullOrEmpty(Filtro), "", Filtro & " And ") & String.Format(" nCooperativa = {0}", IIf(Me.RdCooperativa.Checked, 1, 0))
                        End If

                        If cboMontoAprobado.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                'MsgBox(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                                Filtro = Filtro & " And nMontoCreditoAprobado=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                            End If
                        Else
                            'Filtro = Filtro & " And nMontoCreditoAprobado<>10000 And nMontoCreditoAprobado<>1850 And nMontoCreditoAprobado<>3700 And nMontoCreditoAprobado<>4600 And nMontoCreditoAprobado<>5500"
                        End If

                        frmVisor.SQLQuery = " Select * From vwSccListadoNegociosCreditosPorDistritoAprobadosDetalle " & Filtro & "  Order by  Departamento,Municipio,Distrito,Barrio,TipoNegocio "

                    End If ' If radConsolidado.Checked = True Then

                    ''frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & "'"

                Case EnumReportes.Socias
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    Else
                        Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " Where nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If Me.radConsolidado.Checked Then
                        frmVisor.NombreReporte = "RepSclCS24.rpt"
                        frmVisor.Text = "Totales de Socias con Créditos aprobados "
                    Else
                        If Me.RadDetalle.Checked Then
                            frmVisor.NombreReporte = "RepSclCS22.rpt"
                            frmVisor.Text = "Listado de Socias con Créditos aprobados "
                        End If
                    End If

                    If radTodos.Checked Then
                        If Me.radConsolidado.Checked Then
                            frmVisor.Formulas("Parametro") = "'TOTALES DE CREDITOS APROBADOS (CANCELADOS Y VIGENTES) " & IIf(RdMercado.Checked, "EN LOS MERCADOS", IIf(Me.RdDistrito.Checked, "EN LOS DISTRITOS", IIf(Me.RdCooperativa.Checked, "EN LAS COOPERATIVAS", ""))) & "'"
                        Else
                            frmVisor.Formulas("Parametro") = "'LISTADO DE CREDITOS APROBADOS (CANCELADOS Y VIGENTES) " & IIf(RdMercado.Checked, "EN LOS MERCADOS", IIf(Me.RdDistrito.Checked, "EN LOS DISTRITOS", IIf(Me.RdCooperativa.Checked, "EN LAS COOPERATIVAS", ""))) & "'"
                        End If
                    End If

                    If Not RdTodos.Checked Then
                        Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), " Where ", " And ") & " nFondoPresupuestario = " & IIf(Me.RdPresupuesto.Checked, 1, 0)
                    End If

                    Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), " Where ", " And ") & " CodPrograma = " & IIf(Me.RdUsuraCero.Checked, 1, 0)

                    If RadNuevos.Checked Then
                        If Me.radConsolidado.Checked Then
                            frmVisor.Formulas("Parametro") = "'TOTALES DE CREDITOS APROBADOS QUE HAN SIDO CANCELADOS " & IIf(RdMercado.Checked, "EN LOS MERCADOS", IIf(Me.RdDistrito.Checked, "EN LOS DISTRITOS", IIf(Me.RdCooperativa.Checked, "EN LAS COOPERATIVAS", ""))) & "'"
                        Else
                            frmVisor.Formulas("Parametro") = "'LISTADO DE CREDITOS APROBADOS QUE HAN SIDO CANCELADOS " & IIf(RdMercado.Checked, "EN LOS MERCADOS", IIf(Me.RdDistrito.Checked, "EN LOS DISTRITOS", IIf(Me.RdCooperativa.Checked, "EN LAS COOPERATIVAS", ""))) & "'"
                        End If

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And EstadoCredito= '7'"
                        Else
                            Filtro = " Where EstadoCredito= '7'"
                        End If
                    End If

                    If RadActuales.Checked Then
                        If Me.radConsolidado.Checked Then
                            frmVisor.Formulas("Parametro") = "'TOTALES DE CREDITOS APROBADOS QUE ESTAN VIGENTE " & IIf(RdMercado.Checked, "EN LOS MERCADOS", IIf(Me.RdDistrito.Checked, "EN LOS DISTRITOS", IIf(Me.RdCooperativa.Checked, "EN LAS COOPERATIVAS", ""))) & "'"
                        Else
                            frmVisor.Formulas("Parametro") = "'LISTADO DE CREDITOS APROBADOS QUE ESTAN VIGENTE " & IIf(RdMercado.Checked, "EN LOS MERCADOS", IIf(Me.RdDistrito.Checked, "EN LOS DISTRITOS", IIf(Me.RdCooperativa.Checked, "EN LAS COOPERATIVAS", ""))) & "'"
                        End If

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And EstadoCredito= '5'"
                        Else
                            Filtro = " Where EstadoCredito= '5'"
                        End If
                    End If

                    'RadNuevos.Text = "Cancelados"
                    'RadActuales.Text = "Vigentes"

                    If Me.RdDistrito.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbMercadoVerificadoID=1 "
                        Else
                            Filtro = " Where nStbMercadoVerificadoID=1 "
                        End If
                    ElseIf Me.RdMercado.Checked Or Me.RdCooperativa.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & "  And  nStbMercadoVerificadoID <> 1 And nCooperativa = " & String.Format("{0}", IIf(Me.RdCooperativa.Checked, 1, 0))
                        Else
                            Filtro = " Where  nStbMercadoVerificadoID <> 1 And nCooperativa = " & String.Format("{0}", IIf(Me.RdCooperativa.Checked, 1, 0))
                        End If
                    End If

                    ' Monto Aprobado
                    If cboMontoAprobado.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            'MsgBox(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                            'MsgBox(Trim(Me.cboMontoAprobado.Text))
                            Filtro = Filtro & " And nMontoCreditoAprobado=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                        End If
                    Else
                        'Filtro = Filtro & " And nMontoCreditoAprobado<>10000 And nMontoCreditoAprobado<>1850 And nMontoCreditoAprobado<>3700 And nMontoCreditoAprobado<>4600 And nMontoCreditoAprobado<>5500"
                    End If

                    frmVisor.SQLQuery = " Select * From  vwSclListadoSociasAprobadas " & Filtro  '&  "  Order by  Departamento,Municipio,Distrito,Barrio "
                    frmVisor.Formulas("Parametros") = "' Parámetros.  Dpto: " & Me.CboDepartamento.Text & " , Munic: " & Me.cboMunicipio.Text & " , Monto C$:  " & Trim(cboMontoAprobado.Text) & "'"
                    frmVisor.Formulas("Programa") = "'PROGRAMA: " & IIf(Me.RdUsuraCero.Checked, " USURA 0", " VENTANA DE GENERO") & " '"

                Case EnumReportes.ListadoSociasCanceladasVigentes

                    Filtro = ""
                    REM Problema de Reporte CC63 en Delegación de León 02/06/2010.
                    'If CboDepartamento.SelectedIndex > 0 Then
                    If CboDepartamento.SelectedIndex <> -1 And CboDepartamento.Text <> "Todos" Then
                        Filtro = Filtro & " {spSccReporteCreditosEstadoAFecha.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteCreditosEstadoAFecha.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteCreditosEstadoAFecha.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteCreditosEstadoAFecha.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteCreditosEstadoAFecha.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteCreditosEstadoAFecha.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And  {spSccReporteCreditosEstadoAFecha.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = "  {spSccReporteCreditosEstadoAFecha.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & "'"

                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteCreditosEstadoAFecha.nFondoPresupuestario}=" & IIf(RdPresupuesto.Checked, "1", "0")
                        Else
                            Filtro = " {spSccReporteCreditosEstadoAFecha.nFondoPresupuestario}=" & IIf(RdPresupuesto.Checked, "1", "0")
                        End If
                    End If

                    If Me.RadVigente.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteCreditosEstadoAFecha.RestaApagar}>0"
                        Else
                            Filtro = "  {spSccReporteCreditosEstadoAFecha.RestaApagar}>0"
                        End If
                    Else
                        If RadCancelado.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteCreditosEstadoAFecha.RestaApagar}<=0"
                            Else
                                Filtro = "  {spSccReporteCreditosEstadoAFecha.RestaApagar}<=0"
                            End If
                        End If
                    End If

                    frmVisor.Formulas("Parametro") = "'" & IIf(RadTodosCreditos.Checked = True, "CREDITOS VIGENTES Y CANCELADOS", IIf(RadVigente.Checked = True, "CREDITOS VIGENTES", "CREDITOS CANCELADOS")) & "'"
                    frmVisor.NombreReporte = "RepSccCC63.rpt"
                    frmVisor.Text = "Listado de  Socias (Canceladas y Vigentes)"
                    ''frmVisor.SQLQuery = " Select * From vwSclListadoSocias " & Filtro & "  Order by  Departamento,Municipio,Distrito, Barrio "
                    frmVisor.Formulas("Parametros") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")'"
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    REM Problema CC63 Delegación de León 02/06/2010.
                    'frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    If CboDepartamento.SelectedIndex <> -1 And CboDepartamento.Text <> "Todos" Then
                        frmVisor.Parametros("@DepartamentoId") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    Else
                        frmVisor.Parametros("@DepartamentoId") = -1
                    End If
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
            End Select

            frmVisor.Show()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try

    End Sub

    Private Sub frmSclParametrosListadoSocias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.TextChanged
        If Me.CboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
            'CargarBarrio(0)
        Else
            CargarMunicipio(1)
        End If

        If Me.CboDepartamento.SelectedIndex <> 0 Then
            Me.chkDistribucion.Checked = False
            Me.chkDistribucion.Enabled = False
        Else
            Me.chkDistribucion.Enabled = True
            Me.chkDistribucion.Checked = True
        End If

        HabilitarComboMunicipio()
        'HabilitarComboBarrio()

    End Sub
    Private Sub HabilitarComboMunicipio()
        'If Me.CboDepartamento.SelectedIndex > 0 Then
        If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
            'Me.cboBarrio.Enabled = True

            HabilitarComboBarrio()


        Else
            Me.cboMunicipio.Enabled = False
            Me.cboBarrio.Enabled = False
        End If
    End Sub
    'Private Sub HabilitarComboBarrio()
    '    If Me.cboMunicipio.SelectedIndex > 0 Then
    '        Me.cboBarrio.Enabled = True
    '    Else
    '        Me.cboBarrio.Enabled = False
    '    End If
    'End Sub
    Private Sub HabilitarComboBarrio()
        If mNomRep = EnumReportes.Socias Or mNomRep = EnumReportes.TipoNegocio Or mNomRep = EnumReportes.FichaSeguimiento Or mNomRep = EnumReportes.ListadoSociasCanceladasVigentes Then
            If Me.cboMunicipio.Text = "Managua" Or Me.cboMunicipio.Text = "Todos" Then
                If Me.cboDistrito.SelectedIndex > 1 Then
                    Me.cboBarrio.Enabled = True
                Else
                    Me.cboBarrio.Enabled = False
                    If Me.cboBarrio.ListCount > 0 Then
                        Me.cboBarrio.SelectedIndex = 0
                    End If

                End If
            Else
                If Me.cboDistrito.SelectedIndex >= 0 Then
                    Me.cboBarrio.Enabled = True
                Else
                    Me.cboBarrio.Enabled = False
                    If Me.cboBarrio.ListCount > 0 Then
                        Me.cboBarrio.SelectedIndex = 0
                    End If
                End If

            End If
        Else
            Me.cboBarrio.Enabled = False
        End If
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0)
                Me.cboDistrito.Enabled = False
            End If
            CargarBarrio(0)
        Else
            CargarDistrito(1)
            CargarBarrio(1)
        End If
        'HabilitarComboBarrio()
    End Sub

    Private Sub frmSclParametrosListadoSocias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath

            If Trim(Me.strColor) <> "" Then
                ObjGUI.SetFormLayout(Me, Me.strColor)
            Else
                ObjGUI.SetFormLayout(Me, "RojoLight")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            HabilitarComboMunicipio()

            If Me.mNomRep = EnumReportes.TotalesDistribucionGeograficaYTipoNegocio Or Me.mNomRep = EnumReportes.ListadoSocias Or Me.mNomRep = EnumReportes.TipoNegocio Or Me.mNomRep = EnumReportes.Socias Then
                ' CS43, CC33, CC36, CS15, CS17, CS22 y CS24
                cboMontoAprobado.Enabled = True
                cboMontoAprobado.AddItem("(Todos)")
                cboMontoAprobado.AddItem("1,850.00")
                cboMontoAprobado.AddItem("3,700.00")
                cboMontoAprobado.AddItem("4,600.00")
                cboMontoAprobado.AddItem("5,500.00")
                cboMontoAprobado.AddItem("10,000.00")
                cboMontoAprobado.Columns(0).Caption = ""
                cboMontoAprobado.SelectedIndex = 0
            Else
                cboMontoAprobado.Enabled = False
            End If

            Me.cboBarrio.Enabled = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub frmSclParametrosListadoSocias_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If mNomRep = EnumReportes.Barrio Then
            grpNegocio.Enabled = False
            grpReporte.Enabled = False
            GrpFechas.Enabled = True
        End If

        If mNomRep = EnumReportes.Socias Then
            'grpNegocio.Enabled = False
            grpNegocio.Text = "Estado del Credito"
            RadNuevos.Text = "Cancelados"
            RadActuales.Text = "Vigentes"
            GrpFechas.Enabled = True
            grpDistritoOMercado.Enabled = True
        Else

            If mNomRep = EnumReportes.ListadoSocias Or mNomRep = EnumReportes.FichaSeguimiento Then
                grpNegocio.Enabled = False
                grpDistritoOMercado.Enabled = False
            Else
                grpDistritoOMercado.Enabled = False
            End If
            If mNomRep = EnumReportes.ListadoSocias Then
                grpPrograma.Enabled = False
            End If

        End If
        If mNomRep = EnumReportes.TipoNegocio Or mNomRep = EnumReportes.FichaSeguimiento Or mNomRep = EnumReportes.Socias Then
            grpFuente.Enabled = True
            RdSinFuente.Enabled = False
            grpDistritoOMercado.Enabled = True
        Else
            grpFuente.Enabled = False
        End If

        If mNomRep = EnumReportes.FichaSeguimiento Then
            grpNegocio.Enabled = True
            grpReporte.Enabled = False
            grpTipoCredito.Enabled = True
        Else
            grpTipoCredito.Enabled = False
        End If


        If mNomRep = EnumReportes.ListadoSociasCanceladasVigentes Then
            grpReporte.Enabled = False
            grpDistritoOMercado.Enabled = False
            grpNegocio.Enabled = False
            grpFuente.Enabled = True
            RdSinFuente.Enabled = False
            grpTipoCredito.Enabled = True
            cdeFechaInicial.Enabled = False
        End If

        If Me.NomRep = EnumReportes.TotalesDistribucionGeograficaYTipoNegocio Then

            Me.grpReporte.Enabled = False
            Me.grpDistritoOMercado.Enabled = False
            Me.grpTipoCredito.Enabled = False
            Me.grpFuente.Enabled = True
            Me.grpNegocio.Enabled = False
            Me.btnSelecionarTiposNegocios.Visible = True
            Me.RdSinFuente.Enabled = False

        End If

    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If mNomRep = EnumReportes.Socias Then
            'Me.cboBarrio.Enabled = True
            If Me.cboMunicipio.SelectedIndex <> -1 Then
                CargarBarrio(0)
            Else
                CargarBarrio(1)
            End If

        End If
        HabilitarComboBarrio()
    End Sub

    Private Sub btnSelecionarTiposNegocios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelecionarTiposNegocios.Click

        Dim ObjfrmSclSeleccionaActividadEconomica As New frmSclSeleccionaActividadEconomica
        ObjfrmSclSeleccionaActividadEconomica.ShowDialog()
        sActividadesSeleccionadas = Me.ListActividadesToString(ObjfrmSclSeleccionaActividadEconomica.ActividadesSeleccionadas)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                12/03/2012
    ' Procedure Name:       ListActividadesToString
    ' Descripción:          Este procedimiento permite convertir una lista de enteros 
    '                       en una string separando los valores con ",", para filtrar
    '                       el reporte sólo por aquellas actividades seleccionadas    
    '-------------------------------------------------------------------------
    Private Function ListActividadesToString(ByVal ActividadesSeleccionadas As List(Of Int32)) As String
        ' Si no ha seleccionado ninguna actividad, no se reliza el filtro
        If ActividadesSeleccionadas Is Nothing Or ActividadesSeleccionadas.Count = 0 Then
            Return String.Empty
        End If

        Dim list As String = ""
        For item As Int32 = 1 To ActividadesSeleccionadas.Count

            list += String.Format("{0}{1}{0}", Chr(34), ActividadesSeleccionadas(item - 1).ToString())

            If item <> ActividadesSeleccionadas.Count Then
                list += ","
            End If

        Next
        ListActividadesToString = list
    End Function

End Class